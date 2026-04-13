'ﾌｧｲﾙ名：xxEN0160.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット分割　メインフォーム
'作成日：2004/04/13 (Tue) 12:32:45 K.Takano
'更新日：2016/09/28 (Wed) 15:54:00 S.Otaki
'備　考：
'　　　：2007/07/26 (Thu) 11:00:27 N.Kasai  ｿｰｽ整備
'Copyright(C)2003-2016, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0160
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0160    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0160
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0160
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0160)
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
    '========================================Public=========================================
    '========================================Private========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "11.02"


    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN0160

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:09:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:09:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_divide__Ver          As String = "02.00"         'ﾛｯﾄ分割
    Private Const CMstrlot_waferlistVer         As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    Private Const CMstrlot_dividedirectVer      As String = "01.00"         'ﾛｯﾄ分割(一括移載)
    Private Const CMstrlot_throwrsvVer          As String = "03.00"         '投入予約登録
    Private Const CMstrlot_approveVer           As String = "01.04"         '投入ﾛｯﾄ承認要求
    '@↓2019/12/19 (Thu) 19:16:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_rsvlist_Ver          As String = "02.00"         '投入予定ﾛｯﾄ一覧
    Private Const CMstrlot_rsvlist_Ver          As String = "03.00"         '投入予定ﾛｯﾄ一覧
    '@↑2019/12/19 (Thu) 19:16:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
	'kkw 蒸着2回対応
	Private Const CMstrlot_chkjbatchlistVer     As String = "01.02"         '蒸着ﾊﾞｯﾁ組実施有無
    Private Const CMstrcarrcurstateVer          As String = "05.02"         'ｷｬﾘｱ状態確認
    Private Const CMstrcarrlist____Ver          As String = "07.00"         'ｷｬﾘｱ一覧
    Private Const CMstrcarradditionVer          As String = "01.00"         'ｷｬﾘｱ追加
    Private Const CMstrmas_pdentrylistVer       As String = "03.00"         'ﾏｽﾀ工順一覧
    Private Const CMstrlot_dividerecipeVer      As String = "01.00"         'ﾛｯﾄ分割ﾚｼﾋﾟ状態ﾁｪｯｸ
    Private Const CMstrlot_chksecpriorityVer    As String = "01.00"         'ﾛｯﾄ区間優先状態ﾁｪｯｸ
    '@↓2019/11/26 (Tue) 10:03:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrmas_definelistVer        As String = "01.00"         'DEFINE情報取得
    Private Const CMstrlot_chggrbclassVer       As String = "01.00"         'GRB区分更新(親ﾛｯﾄ単体)
    '@↑2019/11/26 (Tue) 10:03:59 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngColSlot                  As Integer = 0                 'ｽﾛｯﾄ
    Private Const CMlngColWFID                  As Integer = 1                 'WFID
    Private Const CMlngColClass                 As Integer = 2                 'CLASS
    Private Const CMlngColBatchId               As Integer = 3                 'ﾊﾞｯﾁID
    '@↓2019/11/26 (Tue) 09:36:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngColGRB                   As Integer = 4                 'GRB
    '@↑2019/11/26 (Tue) 09:36:25 Y.Yoneyama 「.Netへ反映未」 **************************************************

    ’Private Const CMlngColNum                   As Integer = 4                 'ｶﾗﾑ数
    Private Const CMlngColNum                   As Integer = 5                 'ｶﾗﾑ数

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngColSlotWidth             As Integer = 29                'ｽﾛｯﾄWidth
    Private Const CMlngColWFIDWidth             As Integer = 120               'WFIDWidth
    Private Const CMlngColClassWidth            As Integer = 70                'CLASSWidth
    Private Const CMlngColGRBWidth              As Integer = 30               'GRB

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrSlotMapColTSlot          As String = vbNullString        'ｽﾛｯﾄNO
    Private Const CMstrSlotMapColTWFID          As String = "WFID"              'WFID
    Private Const CMstrSlotMapColTClass         As String = "状態"              'CLASS
    Private Const CMstrSlotMapColBatchID        As String = "バッチID"          'ﾊﾞｯﾁID(無機流動時のみ)
    Private Const CMstrSlotMapColTGRB           As String = "GRB"               'GRB


    '@vsfSlotMapの定数宣言(その他)
    Private Const CMlngSlotMapRowTitle          As Integer = 0                 'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMlngSlotHMaCellFontSize      As Integer = 12                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngSlotMapRowS              As Integer = 26                '行数
    Private Const CMlngSlotMapHHeight           As Integer = 20'300            'ﾍｯﾀﾞｰの高さ
    Private Const CMlngSlotMapHeight            As Integer = 38  '570          '1ｽﾛｯﾄの高さ
    Private Const CMlngSlotMapSTopRow           As Integer = 16                '初期表示行番号
    Private Const CMlngSlotMapPageRows          As Integer = 10                '1ﾍﾟｰｼﾞ表示行数
    Private Const CMlngSlotMapSlotNo10Row       As Integer = 17                '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
    Private Const CMlngSlotMapSlotNo16Row       As Integer = 11                '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№16の行番号

    '@その他
    Private Const CMlngDivideNumTwo             As Integer = 2                 '分割先LOTのWF枚数
    Private Const CMlngBackColorCel             As Integer = &H8000000D        'ｸﾞﾘｯﾄﾞのﾊﾞｯｸｶﾗｰｾﾙ(紺)

    '@Msg表示用
    Private Const CMstrNoJBatchID               As String = "蒸着バッチ組み条件が無い"
    Private Const CMstrOverTwoJBatchID          As String = "蒸着バッチ組み条件が2以上有る"
    Private Const CMstrBeJBatchID               As String = "蒸着バッチ組み条件が有る"
    Private Const CMstrFewWF                    As String = "ウェハ数が少ない"
    Private Const CMstrManyWF                   As String = "ウェハ数が多い"

    '@ﾃｷｽﾄの1ﾍﾟｰｼﾞの行数
    Private Const CMlngMaxDispMemoRow           As Integer = 3                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@分割先ﾛｯﾄのWF数(簡易分割用)
    Private Const CMstrWFDefault                As String = "0"             'WF枚数ｾﾞﾛ入力時比較用定数
    Private Const CMstrDumCarrierTypeID         As String = "CARRSYS0"      '簡易分割用仮想ｷｬﾘｱのﾀｲﾌﾟ
    Private Const CMstrDumCarrierFirstWords     As String = "I"             'ｼｽﾃﾑ検証用仮想ｷｬﾘｱID1桁目
    Private Const CMstrFormatCarrIdSerial       As String = "00000"         '仮想ｷｬﾘｱIDﾍﾞﾝﾀﾞｰｼﾘｱﾙ
    Private Const CMstrAri                      As String = "あり"          'CARRIER.EMPTY_FLAG

    '@DEFINE情報
    Private Const CMstrTableName                As String = "GRB_CLASS"
    Private Const CMstrColumnName               As String = "GRB_DATA"
    Private Const CMstrGRBNoneSelect            As String = "なし"

    '@その他
    Private Const CMstrGrbDivideComment         As String = "ロットGRB分割実施"  'GRB分割(理由)
    Private Const CMstrPipeString               As String = " | "                'ﾊﾟｲﾌﾟ文字
    Private Const CMstrGrbPlural                As String = "GRB_PLURAL"         'GRB区分複数有り

    '************************************************************************************\***
    '                                    *構造体の記述*
    '***************************************************************************************
    '========================================Private========================================
    '@ｽﾛｯﾄﾏｯﾌﾟ退避用構造体
    Private Structure WFTmp
        Dim strSlotNo                               As String                   'ｽﾛｯﾄ№
        Dim strWfId                                 As String                   'WFID
        Dim strClass                                As String                   '状態
        '@↓2019/11/26 (Tue) 09:43:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim strGRB                                  As String                   'GRB
        '@↑2019/11/26 (Tue) 09:43:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
    End Structure

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '========================================Private========================================
    Private mstrLotLastUpdate                   As String                   'ﾛｯﾄ最終更新日時
    Private mstrEventName                       As String                   'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
    Private mstrCarrier                         As String                   'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrCarrierTypeID                   As String                   'ｷｬﾘｱﾀｲﾌﾟID(LOADER側)
    Private mstrDumCarrierID                    As String                   '簡易分割仮想ｷｬﾘｱ
    Private mstrLotId                           As String                   '分割子ﾛｯﾄID
    Private mstrFlowClass                       As String                   '分割子ﾛｯﾄ区分
    Private mstrDummyCarrierId                  As String                   '仮想ｷｬﾘｱID
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mblnTpalBefFlag                     As Boolean                  'TPAL前簡易分割実施可否識別ﾌﾗｸﾞ(無機流動用)
    Private mlngVsfBottomRow                    As Integer                  '画面の一番下の行(WF№01の行)
    Private mlngSlotMapRowS                     As Integer                  '行数
    Private mlngWFNum                           As Integer                  'WF枚数
    Private mtypJBatList                        As JBatchFromLotList        '蒸着ﾊﾞｯﾁ組ﾘｽﾄ
    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private blnKeepNonRedraw                    As Boolean                  'NSYS validateによる画面ちらつき回避ﾌﾗｸﾞ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ
    Private ReadOnly vbButtonFace               As Color = SystemColors.ControlLight 'NSYS vbButtonFace定義
    Private ReadOnly vbWhite                    As Color = Color.White               'NSYS vbWhite定義
    Private Const  vbInactiveTitleBar           As Integer = &H80000003
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
        pubVsfMouseWheelManager_Set(vsfSlotMap, cmdUp, cmdDown)
        pubVsfMouseWheelManager_Set(vsfSlotMapStck, cmdUp, cmdDown)


        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '========================================Private========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 15:52:03 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 13:03:21 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@Escﾎﾞﾀﾝを無効(ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない対応)
            Me.CancelButton = Nothing 
            
            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0160, CMstrLocalVersion)
            
            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：機能Ver不一致"か
            If lblnAns = False Then
                
                '@=======================
                '@ ﾒﾆｭｰｻｲｽﾞ変更処理
                '@=======================
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@　ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@作業ﾒﾓ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝを初期化
            cmdMemoUp.Enabled = False           '上(▲)
            cmdMemoDown.Enabled = False         '下(▼)
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN0160_Init()


            '@***********************
            '@ 無機専用簡易分割実施の場合は、
            '@ 分割直前までの処理を自動実行
            '@***********************
            '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
            If pblnMkEasyDivFlag = True Then
                
                '@TPAL簡易分割ﾌﾗｸﾞの初期化
                mblnTpalBefFlag = False
                
                '@=======================
                '@ 簡易分割処理
                '@=======================
                lblnAns = prvblnEasyDivideAutoExe_Proc
                    
                '@戻り値の判定
                If lblnAns = False Then
                    Exit Sub
                End If
            End If
            
            '@Form_Loadﾌﾗｸﾞに"True：正常"をｾｯﾄ
            pblnFormLoad = True
            
            '@引継ぎ情報表示済みﾌﾗｸﾞの初期化
            mblnTakeOverDispFlg = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:47:42 H.Wajima
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
                       
            '@-----------------------
            '@ 引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@ ⇒FormLoad後、最初の1回しか処理しない
            '@-----------------------
            If mblnTakeOverDispFlg = True Then
                '@"True：引継ぎ情報が表示済み"
                
                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄ
            mblnTakeOverDispFlg = True

            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose

            '@引数のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外(引継ぎｷｬﾘｱあり)
                
                '@ｷｬﾘｱIDにｾｯﾄ
                txtCarrier.Text = ptypCommonInfo.strCarrierId

                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(False))
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            Else
                '@NULL以外(引継ぎｷｬﾘｱなし)

                '@引継ぎｷｬﾘｱIDの初期化
                ptypCommonInfo.strCarrierId = vbNullString
            End If


            '@***********************
            '@ 無機対応
            '@***********************
            '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
            If pblnMkEasyDivFlag = True Then
                
                '@各種ｺﾝﾄﾛｰﾙの初期化(無効化)
				'↓kkw 蒸着治具紐付け機能改修でキャリアID,任意のWF分割を変更可能にする
				If pstrSBID = CPstrSBID2A0 Then
					txtCarrier.Enabled = True              'ｷｬﾘｱIDﾃｷｽﾄ
					cmdMove.Enabled = False                 '">"ﾎﾞﾀﾝ ｸﾞﾘｯﾄﾞ選択前は無効
					cmdDel.Enabled = False                  '"<"ﾎﾞﾀﾝ ｸﾞﾘｯﾄﾞ選択前は無効
					vsfSlotMapStck.Enabled = True          '分割元ｽﾛｯﾄﾏｯﾌﾟ
					vsfSlotMap.Enabled = True              '分割先ｽﾛｯﾄﾏｯﾌﾟ
				Else
					txtCarrier.Enabled = False              'ｷｬﾘｱIDﾃｷｽﾄ
					cmdMove.Enabled = False                 '">"ﾎﾞﾀﾝ
					cmdDel.Enabled = False                  '"<"ﾎﾞﾀﾝ
					vsfSlotMapStck.Enabled = False          '分割元ｽﾛｯﾄﾏｯﾌﾟ
					vsfSlotMap.Enabled = False              '分割先ｽﾛｯﾄﾏｯﾌﾟ
				End if
				'↑kkw ここまで変更

				cmdMoveGRB.Enabled = False             '">>"ﾎﾞﾀﾝ
                cmdDelGRB.Enabled = False               '"<<"ﾎﾞﾀﾝ
                cmdLotSelect.Enabled = False            '投入予定ﾛｯﾄ選択ﾎﾞﾀﾝ

                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外か
                If txtToCarrier.Text <> vbNullString Then
                    
                    '@各種ｺﾝﾄﾛｰﾙの初期化(無効化)
					'↓kkw 蒸着治具紐付け機能改修でキャリアID,任意のWF分割を変更可能にする
                    txtToCarrier.Enabled = True        'ｱﾝﾛｰﾀﾞｷｬﾘｱIDﾃｷｽﾄ
					cmdCarrierSelect.Enabled = True    '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
					'↑kkw ここまで変更
                    chkMoveSkip.Enabled = False         '移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽ

                    
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLの場合
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier)
                End If
                
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾎﾞｰﾄﾞｷｰ押下時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：Shift,Ctrl,Altｷｰ状態
    '戻り値：
    '作成日：2004/04/13 (Tue) 17:09:20 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Dim llngRow              As Integer      '対象行格納用
        Dim llngTopRow           As Integer      '先頭行
        Dim lstrCRow             As String       'ｶﾚﾝﾄ行
        Dim lintKeyCode          As Short        'ｶﾚﾝﾄ行

        Try
                      
            '@以下の場合、Key入力を無効にし処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor
                
                e.Handled = True
                Exit Sub
            End If

            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 分割元ｽﾛｯﾄﾏｯﾌﾟ 〓
                Case vsfSlotMapStck.Name
                    
                    With vsfSlotMapStck
                        
                        '@各種値を退避
                        lintKeyCode = e.KeyCode     'ｷｰｺｰﾄﾞ
                        llngRow = .Row              '現在行
                        llngTopRow = .TopRow        '先頭行
                        
                        '@=======================
                        '@ Tag値(前回TopRow、前回Key値)取得(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        lstrCRow = pubstrVsfTag_Get(vsfSlotMapStck, 1)
                        
                        '@=======================
                        '@ Tag値(前回TopRow、前回Key値)保持(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubblnVsfTag_Set(vsfSlotMap, 1, lstrCRow)
                        
                        '@=======================
                        '@ 分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubVsf_KeyDown(e, .Name, vsfSlotMapStck, cmdUP, cmdDown, False)                  '分割元ﾏｯﾌﾟ
                        
                        '@各種退避しておいた値を戻す
                        vsfSlotMap.Row = llngRow
                        vsfSlotMap.TopRow = llngTopRow
                        
                        '@=======================
                        '@ 分割先ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubVsf_KeyDown(e, vsfSlotMap.Name, vsfSlotMap, cmdUP, cmdDown, False)            '分割先ﾏｯﾌﾟ
                        
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSlotMapStck)

                    End With
                    
                    
                '@〓 分割先ｽﾛｯﾄﾏｯﾌﾟ 〓
                Case vsfSlotMap.Name
                    
                    With vsfSlotMap
                        
                        '@各種値を退避
                        lintKeyCode = e.KeyCode       'ｷｰｺｰﾄﾞ
                        llngRow = .Row                '現在行
                        llngTopRow = .TopRow          '先頭行
                        
                        '@=======================
                        '@ Tag値(前回TopRow、前回Key値)取得(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        lstrCRow = pubstrVsfTag_Get(vsfSlotMap, 1)
                        
                        '@=======================
                        '@ Tag値(前回TopRow、前回Key値)保持(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubblnVsfTag_Set(vsfSlotMapStck, 1, lstrCRow)

                        '@=======================
                        '@ 分割先ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubVsf_KeyDown(e, .Name, vsfSlotMap, cmdUP, cmdDown, False)                      '分割元ﾏｯﾌﾟ
                        
                        '@各種退避しておいた値を戻す
                        vsfSlotMapStck.Row = llngRow
                        vsfSlotMapStck.TopRow = llngTopRow
                        
                        '@=======================
                        '@ 分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
                        '@=======================
                        Call pubVsf_KeyDown(e, vsfSlotMapStck.Name, vsfSlotMapStck, cmdUP, cmdDown, False)    '分割先ﾏｯﾌﾟ
                        
                        '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSlotMap)

                    End With

            End Select


            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
                
                '@〓 vbKeyReturn：Enterｷｰ 〓
                Case Keys.Return
                    
                    '@ﾌｫｰｶｽがｷｬﾘｱIDにある場合
                    If ActiveControl.Name = "txtCarrier" Then
                        
                        '@=======================
                        '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                        '@=======================
                        RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                　　　　Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(False))
                        AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        
                        Exit Sub
                    End If
                    
                    '@ｺﾒﾝﾄにﾌｫｰｶｽがある場合
                    If ActiveControl.Name = "txtWorkMemo" Then
                        
                        '@改行処理は行わないようにする
                        Exit Sub
                    End If

                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True


                '@〓 vbKeyDelete：Deleteｷｰ 〓
                Case Keys.Delete
                    
                    '@ﾌｫｰｶｽが分割先ｽﾛｯﾄﾏｯﾌﾟにある場合
                    If ActiveControl.Name = "vsfSlotMap" Then
                        
                        '@削除ﾎﾞﾀﾝが有効か
                        If cmdDel.Enabled = True Then
                            
                            '@=======================
                            '@ 分割WF戻し("<")ﾎﾞﾀﾝ処理
                            '@=======================
                            Call cmdDel_Click(Me,e)
                            e.Handled = True
                        End If
                    End If
                'NSYS [↑]ｷｰ
                Case Keys.Up                        
                   If ActiveControl.Name = vsfSlotMapStck.Name Then
                        With vsfSlotMapStck
                          'NSYS VB6互換動作 複数行選択されている場合グリッドをスクロールさせない
                            If .Row <> .RowSel AndAlso .RowSel = .TopRow AndAlso e.Shift Then
                                e.Handled = True
                            End If
                        End With
                    End If
                'NSYS [↓]ｷｰ
                Case Keys.Down
                    If ActiveControl.Name = vsfSlotMapStck.Name Then
                        With vsfSlotMapStck
                          'NSYS VB6互換動作 複数行選択されている場合グリッドをスクロールさせない
                            If .Row <> .RowSel AndAlso .RowSel = .BottomRow AndAlso e.Shift Then
                                e.Handled = True
                            End If
                        End With
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
         
        End Try
     End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　ｱﾝﾛｰﾄﾞ時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 15:55:55 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:18:33 T.Kitagawa   閉じるﾎﾞﾀﾝ統合
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納

        Try
                                   
            '@ﾌｫｰﾑの"×"押下ﾄﾘｶﾞでのCallか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@ACT初期化ﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@ACTを自前で初期化した場合
                
                '@=======================
                '@ ACTｵﾌﾞｼﾞｪｸﾄの開放
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                
                '@***********************
                '@ 無機対応
                '@***********************
                '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
                If pblnMkEasyDivFlag = True Then
                    
                    '@処理なし
                Else
                    '@=======================
                    '@ ﾒﾆｭｰ伸縮処理
                    '@=======================
                    Call pubMenuExpand_Disp()
                End If
            End If

            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの関連付けを解除
            
            '@画面連携用変数の初期値
            pstrLotID = vbNullString
            pstrFlowClass = vbNullString
            pblnMkEasyDivFlag = False
             
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 15:55:24 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo      As CommonInfo

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@引継ぎｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then

                '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"で、かつ作業開始or冶具ｳｪﾊｾｯﾄ画面からの起動か
                If pblnMkEasyDivFlag = True And _
                    (pblnfrmxxEN0030Kbn = True Or pblnfrmxxEN02F0kbn = True) Then
                    
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    Me.Close()
                Else
                    '@=======================
                    '@ 親画面切り替え引継ぎ制御
                    '@=======================
                    Call pubChangeScreen_Set(Me)
                End If
            Else
                '@引継ぎｷｬﾘｱIDがNULLの場合
                
                '@=======================
                '@ 終了処理
                '@=======================
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 
                Call publngEnd_Proc(CPstrKeyEN0160, ltypCommonInfo)
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/17 (Wed) 07:38:09 T.Sawaguchi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN0160_Init(False)
            
            '@初期値をｾｯﾄ
            ptypLotRlst.strLotID = vbNullString             '分割先ﾛｯﾄID
            ptypLotRlst.strFlowClass = vbNullString         '流動区分
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱﾃｷｽﾄ　選択確定時(Validate)処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 15:56:42 Y.Yamagishi
    '更新日：2016/05/11 (Wed) 14:40:26 T.Inafune
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    '　　　：2012/03/12 (Mon) 09:41:52 T.Oide       無機装置追加対応(REQ-1303)
    '　　　：2016/05/11 (Wed) 13:39:47 T.Inafune    ロット簡易分割不具合対応(REQ-1467)
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating
        
        Dim lblnAns                         As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotprestate                 As Lotprestate          'ﾛｯﾄ現在状態格納構造体
        Dim ltypWaferList                   As Waferlist            'WF情報格納用構造体

        Try
                       
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
                  
            '@ｷｬﾘｱIDが空白か
            If txtCarrier.Text = vbNullString Then
                
                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、処理終了
                SendKeys.SendWait(CPstrSendKeysTab)
                Exit Sub
            End If

            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If LenB(txtCarrier.Text) < CPlngCarrierMaxLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@=======================
                '@ ｽﾛｯﾄﾏｯﾌﾟ初期化処理(分割元ﾛｯﾄのｽﾛｯﾄﾏｯﾌﾟ)
                '@=======================
                Call prvvsfSlotMap_init(vsfSlotMapStck)

                '@ｽﾛｯﾄﾏｯﾌﾟ上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                cmdUP.Enabled = False
                cmdDown.Enabled = False

                '@ﾌｫｰｶｽをｷｬﾘｱIDに留める
                e.Cancel = True
                Exit Sub
            End If


            '@ｷｬﾘｱIDがNULL以外、かつ前回入力ｷｬﾘｱIDと異なるか
            If Trim$(txtCarrier.Text) <> vbNullString And _
                txtCarrier.Text <> mstrCarrier Then
                '@NULL以外、前回入力ｷｬﾘｱと異なる場合
                
        '@↓2016/05/11 (Wed) 13:39:47 T.Inafune **************************************************
                ptypCommonInfo.strCarrierId = vbNullString
        '@↑2016/05/11 (Wed) 13:39:47 T.Inafune **************************************************
                
                '@ﾚｽﾎﾟﾝｽ測定開始
                mstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@=======================
                '@ ﾛｯﾄ現在状態取得(1A：ﾛｯﾄ分割)
                '@=======================
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                CPstrCD1A, _
                                                txtCarrier.Text, _
                                                ltypLotprestate)
                
                '@ﾛｯﾄ現在状態取得結果が"True：取得成功"か
                If lblnAns = True Then
                    
                    '@ﾚｽﾎﾟﾝｽ測定終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@=======================
                    '@ 画面情報表示処理
                    '@=======================
                    Call prvFrmxxEN0160_Disp(ltypLotprestate)
                    
                    '@WF枚数、ｷｬﾘｱﾀｲﾌﾟをﾓｼﾞｭｰﾙ変数に格納
                    mlngWFNum = CLng(ltypLotprestate.strWfNum)
                    mstrCarrierTypeID = ltypLotprestate.strCarrierTypeID
                    
                    '@ﾚｽﾎﾟﾝｽ測定開始
                    Call pubResponseStart(Me.Name, mstrEventName)
                    
                    '@=======================
                    '@ ﾛｯﾄWF情報取得(0T：有効WF)
                    '@=======================
                    lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                     txtCarrier.Text, _
                                                     CPstrCD0T, _
                                                     ltypWaferList)
                    
                    '@ﾛｯﾄWF情報取得結果が"True：取得成功"か
                    If lblnAns = True Then
                        
                        '@ﾚｽﾎﾟﾝｽ測定終了
                        Call publngResponseEnd(Me.Name, mstrEventName)
                        
                        '@各種値をﾓｼﾞｭｰﾙ変数に格納
                        mlngVsfBottomRow = ltypWaferList.strSlotSize        'WF№01の行
                        mlngSlotMapRowS = ltypWaferList.strSlotSize + 1     'ｽﾛｯﾄ数
                        mstrCarrier = txtCarrier.Text                       'ｷｬﾘｱID
                        
                        '@=======================
                        '@ ｽﾛｯﾄﾏｯﾌﾟ表示処理
                        '@=======================
                        Call prvvsfSlotMap_Set(ltypWaferList, vsfSlotMapStck)
                        
                        '@***********************
                        '@ 無機対応
                        '@***********************
                        '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
                        If pblnMkEasyDivFlag = True Then
                            
                            '@ﾚｽﾎﾟﾝｽ測定開始
                            Call pubResponseStart(Me.Name, mstrEventName)
                            
                            '@=======================
                            '@ 蒸着ﾊﾞｯﾁ組実施有無取得
                            '@=======================
        '@↓2012/03/15 (Thu) 15:38:30 T.Oide **************************************************
        '@                    lblnAns = pubblnLotChkJBatchList_Sel(CMstrlot_chkjbatchlistVer, _
        '@                                                         pstrSBID, _
        '@                                                         ltypLotprestate.strLotId, _
        '@                                                         mtypJBatList)
                                                                 
                            lblnAns = pubblnLotChkJBatchList_Sel(CMstrlot_chkjbatchlistVer, _
                                                                 pstrSBID, _
                                                                 ltypLotprestate.strLotID, _
                                                                 mtypJBatList, _
                                                                 ltypLotprestate.strTpalClass)
        '@↑2012/03/15 (Thu) 15:38:30 T.Oide **************************************************
                            
                            '@蒸着ﾊﾞｯﾁ組実施有無取得結果が"True：取得成功"か
                            If lblnAns = True Then
                                
                                '@ﾚｽﾎﾟﾝｽ測定終了
                                Call publngResponseEnd(Me.Name, mstrEventName)
                                
                                '@=======================
                                '@ ｽﾛｯﾄﾏｯﾌﾟへの蒸着ﾊﾞｯﾁID設定処理(分割元ﾛｯﾄのｽﾛｯﾄﾏｯﾌﾟ)
                                '@=======================
                                Call prvJBatchID_Set(vsfSlotMapStck)

                            Else
                                '@蒸着ﾊﾞｯﾁ組実施有無取得結果が"False：取得失敗"の場合
                            
                                '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                                e.Cancel = True
                                
                                '@ﾚｽﾎﾟﾝｽ測定ｷｬﾝｾﾙ
                                Call pubResponseCancel(Me.Name, mstrEventName)
                            End If
                            
                        End If
                        
                        '@=======================
                        '@ ｽﾛｯﾄﾏｯﾌﾟの先頭行表示設定処理
                        '@=======================
                        Call prvVsfSlotMapTopRow_Set()
                        
                        With vsfSlotMapStck
                            
                            '@対象ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ数が10以上か
                            If .Rows.Count > CMlngSlotMapPageRows + 1 Then
                                
                                '@ﾍﾟｰｼﾞの先頭行が"1"か
                                If .TopRow = .Rows.Fixed Then
                                    
                                    '@上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                                    cmdUP.Enabled = False       '上(▲)：無効
                                    cmdDown.Enabled = True      '下(▼)：有効
                                Else
                                    '@ﾍﾟｰｼﾞの先頭行が"1"以外か
                                
                                    '@上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                                    cmdUP.Enabled = True        '上(▲)：有効
                                    cmdDown.Enabled = False     '下(▼)：無効
                                End If
                            Else
                                '@対象ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ数が10以下の場合
                            
                                '@1ﾍﾟｰｼﾞで表示出来るので、ｽｸﾛｰﾙは無効
                                cmdUP.Enabled = False           '上(▲)：無効
                                cmdDown.Enabled = False         '下(▼)：無効
                            End If
                        End With
                        
                        '各種ｺﾝﾄﾛｰﾙを有効にする
                        cmdLotSelect.Enabled = True                 '投入予定ﾛｯﾄ選択ﾎﾞﾀﾝ
                        chkMoveSkip.Enabled = True                  '移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽ
                        
                        '@***********************
                        '@ 無機対応
                        '@***********************
                        '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
                        If pblnMkEasyDivFlag = True Then
                            
                            '@移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽをﾁｪｯｸONにする
                            chkMoveSkip.CheckState = 1
                        Else
                            '@無機用簡易分割識別ﾌﾗｸﾞが"False：簡易分割未実施"の場合

                            If ActiveControl.Name = txtCarrier.name
                                '@移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(chkMoveSkip)
                            End if
                        End If

                        '@↓2020/02/21 (Fri) 17:06:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@防湿ALD
                        If pstrSBID = CPstrSBID3A0 Then
                            chkMoveSkip.CheckState = 1
                            chkMoveSkip.Enabled = False
                        End If
                        '@↑2020/02/21 (Fri) 17:06:33 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    Else
                        '@ﾛｯﾄWF情報取得結果が"False：取得失敗"か
                    
                        '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                        e.Cancel = True
                        
                        '@ﾚｽﾎﾟﾝｽ測定ｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                    End If
                Else
                    '@ﾛｯﾄ現在状態取得結果が"False：取得失敗"か

                    '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽ測定ｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                End If
            Else
                '@NULL、または前回入力ｷｬﾘｱと同じ場合

                '@↓2020/02/25 (Tue) 11:38:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                If chkMoveSkip.Enabled = True Then
                    '@移載ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(chkMoveSkip)
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                '@↑2020/02/25 (Tue) 11:38:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkMoveSkip_Click
    '機　能：移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/07/23 (Mon) 16:18:06 N.Kasai
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub chkMoveSkip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkMoveSkip.CheckedChanged

        Dim lblnAns     As Boolean      '戻り値

        Try
                       
            '@移載工程ｽｷｯﾌﾟがﾁｪｯｸONか
            If chkMoveSkip.CheckState = 1 Then
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを有効にする
                cmdCarrierSelect.Enabled = True
                
                '@ｱﾝﾛｰﾄﾞｷｬﾘｱﾃｷｽﾄの設定
                With txtToCarrier

                    .Enabled = True                 '有効
                    .GotBackColor = vbWhite         '白(ﾌｫｰｶｽ取得ﾊﾞｯｸｶﾗｰ)
                    .BackColor = vbWhite            '白(ﾊﾞｯｸｶﾗｰ)
                End With
            Else
                '@移載工程ｽｷｯﾌﾟがﾁｪｯｸOFFか
            
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
                cmdCarrierSelect.Enabled = False

                '@ｱﾝﾛｰﾄﾞｷｬﾘｱﾃｷｽﾄの設定
                With txtToCarrier

                    .Text = vbNullString            'NULL
                    .Enabled = False                '無効
                    .GotBackColor = vbButtonFace    'ｸﾞﾚｰ(ﾌｫｰｶｽ取得ﾊﾞｯｸｶﾗｰ)
                    .BackColor = vbButtonFace       'ｸﾞﾚｰ(ﾊﾞｯｸｶﾗｰ)
                End With
            End If
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblncmdRegist_Chk

            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnAns = True Then
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkMoveSkip_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrier_Change
    '機　能：ｱﾝﾛｰﾀﾞｷｬﾘｱﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/02 (Thu) 15:52:01 N.Kasai
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub txtToCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtToCarrier.Change

        Dim lblnAns     As Boolean      '戻り値
        
        Try
                       
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblncmdRegist_Chk

            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnAns = True Then
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrier_Validate
    '機　能：ｱﾝﾛｰﾀﾞｷｬﾘｱﾃｷｽﾄ　選択確定時(Validate)処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/07/24 (Tue) 10:33:03 N.Kasai
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub txtToCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrier.Validating
        
        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)
        Dim ltypCarrCurstate        As CarrCurstate         'ｷｬﾘｱ状態確認要求構造体

        Try
                        
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
            If Trim(txtToCarrier.Text) = vbNullString Then
                Exit Sub
            End If
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDが6桁以上か
            If txtToCarrier.NowByte < txtToCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽを留める
                e.Cancel = True
                If ActiveControl.Name = txtToCarrier.Name 
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier)
                End if
                Exit Sub
            End If


            '@***********************
            '@ ｷｬﾘｱ情報(要求ﾃﾞｰﾀ)格納
            '@***********************
            With ltypCarrCurstate
                
                .strCarrierId = txtToCarrier.Text           'UnLoaderｷｬﾘｱID
				If pblnMkEasyDivFlag = True And pstrSBID = CPstrSBID2A0 Then
					.strClassDivision = CPstrCD4U               '4U：空ｷｬﾘｱﾁｪｯｸ(蒸着簡易分割)
				Else
					.strClassDivision = CPstrCD2D               '2D：空ｷｬﾘｱﾁｪｯｸ
				End If

                .strMsgVer = CMstrcarrcurstateVer           'ﾒｯｾｰｼﾞVer
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierTypeID = mstrCarrierTypeID       'Loaderｷｬﾘｱﾀｲﾌﾟ
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "txtToCarrier_Validate"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@=======================
            '@ ｷｬﾘｱ状態確認
            '@=======================
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True)
            
            '@ｷｬﾘｱ状態確認結果が"True：確認OK"か
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
            Else
                '@ｷｬﾘｱ状態確認結果が"False：確認NG"の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                If ActiveControl.Name = txtToCarrier.Name 
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier)
                End If 
                Exit Sub
            End If
            
            If ActiveControl.Name = txtToCarrier.Name 
                '@確定ﾎﾞﾀﾝが有効か
                If cmdRegist.Enabled = True Then
                
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
              
                    '@投入予定ﾛｯﾄ選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdLotSelect)
                End If
            End if

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/07/23 (Mon) 16:18:44 N.Kasai
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click
        
        Try
           
			Dim lstrPCarrierId As String

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
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@***********************
            '@ 起動条件格納
            '@ 条件の確認(2007/07/23 落合様確認)
            '@ ｷｬﾘｱﾀｲﾌﾟはLOADER側と同じﾀｲﾌﾟであること。(同一ﾀｲﾌﾟ以外の分割はあり得ません！！)
            '@ 洗浄ﾀｲﾌﾟは見る必要はありません。
            '@***********************

			lstrPCarrierId = pstrCarrierID          '引継ぎ元退避
            pstrCarrierID = txtToCarrier.Text       'ｱﾝﾛｰﾀﾞｷｬﾘｱID
            pstrCarrierTypeID = mstrCarrierTypeID   'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString       '洗浄条件(NULL)
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance = New frmxxCM00E0()
            
            '@Form_Loadﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00E0.Instance = Nothing
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance.ShowDialog(Me)
            frmxxCM00E0.Instance = Nothing
                 
            '@子画面で空きｷｬﾘｱが選択されたか
            If pstrCarrierID <> vbNullString Then
                
                '@選択されたｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                txtToCarrier.Text = pstrCarrierID

            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
			If pblnMkEasyDivFlag = True Then
				pstrCarrierID = lstrPCarrierId              'ｷｬﾘｱID
			Else
				pstrCarrierID = vbNullString                'ｷｬﾘｱID
			End If

            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtToCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMapStck_Click
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 15:43:29 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub vsfSlotMapStck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMapStck.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMapStck.Rows.Count <= vsfSlotMapStck.Rows.Fixed Then
                Return
            End If
            
            '@↓2019/12/17 (Tue) 17:59:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@基板工程でGRB選択あり
            If pstrSBID = CPstrSBID1A0 And cmbDivideGrbSel.Enabled = True Then
                If cmbDivideGrbSel.Value <> CMstrGRBNoneSelect Then
                    Exit Sub
                End If
            End If
            '@↑2019/12/17 (Tue) 17:59:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '@=======================
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　ｾﾙ選択時処理
            '@=======================
            Call vsfSlotMapStck_EnterCell(Me, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMapStck_EnterCell
    '機　能：分割元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　ｾﾙ選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/07 (Wed) 11:20:27 N.Kasai
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub vsfSlotMapStck_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMapStck.EnterCell
        
        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMapStck.Rows.Count <= vsfSlotMapStck.Rows.Fixed Then
                Return
            End If
            
            '@↓2019/12/17 (Tue) 17:59:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@基板工程でGRB選択あり
            If pstrSBID = CPstrSBID1A0 And cmbDivideGrbSel.Enabled = True Then
                If cmbDivideGrbSel.Value <> CMstrGRBNoneSelect Then
                    Exit Sub
                End If
            End If
            '@↑2019/12/17 (Tue) 17:59:17 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                
                '@ﾀｲﾄﾙ行か
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then

                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else

                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If

                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのﾊﾞｯｸｶﾗｰが灰色、またはWFIDがNULLか
                    If .GetCellRange(llngCnt, CMlngColWFID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Or _
                        .GetData(llngCnt, CMlngColWFID) = vbNullString Then
                        
                        '@分割(">")ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False
                        '@↓2019/12/17 (Tue) 17:12:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        cmdMoveGRB.Enabled = False
                        '@↑2019/12/17 (Tue) 17:12:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        Exit For
                    Else
                        '@ﾊﾞｯｸｶﾗｰが白、かつWFIDがNULL以外
                        
                        '@***********************
                        '@ 無機対応
                        '@***********************
                        '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
                        If pblnMkEasyDivFlag = True Then
                            
                            '@分割(">")ﾎﾞﾀﾝを無効にする
							'kkw 蒸着治具紐付け機能改修 有効に変更
                            cmdMove.Enabled = True
							'↑kkw ここまで変更
                            cmdMoveGRB.Enabled = False

                        Else
                            '@分割(">")ﾎﾞﾀﾝを有効にする
                            cmdMove.Enabled = True
                            '@↓2019/12/17 (Tue) 17:13:11 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cmdMoveGRB.Enabled = False
                            '@↑2019/12/17 (Tue) 17:13:11 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                    
                    End If
                Next llngCnt
            
            End With


            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
            
                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟのﾊﾞｯｸｶﾗｰが灰色、またはWFIDがNULLか
                    If .GetCellRange(llngCnt, CMlngColWFID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Or _
                        .GetData(llngCnt, CMlngColWFID) = vbNullString Then
                        
                        '@分割WF戻し("<")ﾎﾞﾀﾝを無効にする
                        cmdDel.Enabled = False
                        Exit Sub
                    Else
                        '@ﾊﾞｯｸｶﾗｰが白、かつWFIDがNULL以外
                        
                        '@***********************
                        '@ 無機対応
                        '@***********************
                        '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
                        If pblnMkEasyDivFlag = True Then
                            
                            '@分割WF戻し("<")ﾎﾞﾀﾝを無効にする
                            cmdDel.Enabled = False
                        Else
                            '@分割WF戻し("<")ﾎﾞﾀﾝを有効にする
                            cmdDel.Enabled = True
                        End If
                        
                    End If
                Next llngCnt
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMapStck_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotSelect_Click
    '機　能：投入予定ﾛｯﾄ選択ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 10:03:35 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 09:52:57 M.Miura　    ｽﾛｯﾄﾏｯﾌﾟの初期ｶﾚﾝﾄ行をﾀｲﾄﾙにした為、Row設定、ﾎﾞﾀﾝの制御を削除
    '　　　：2005/12/02 (Fri) 13:01:19 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdLotSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotSelect.Click

        '@↓2019/11/26 (Tue) 10:03:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim ltypMasDefineReq    As MasDefineReq 'DEFINE情報（要求）
        Dim ltypMasDefineAns    As MasDefineAns 'DEFINE情報（応答）
        Dim lblnAnsGrb          As Boolean      'GRBｺｰﾄﾞ取得結果格納
        '@↑2019/11/26 (Tue) 10:03:00 Y.Yoneyama 「.Netへ反映未」 **************************************************

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

            '@取得区分に値ｾｯﾄ(0N：分割ﾛｯﾄ)
            pstrfrmxxCM0090Kbn = CPstrCD0N
            
            '@引継ぎ変数にﾛｯﾄIDを格納
            pstrLotID = lblLotID.Text
            
            '@Form_Loadﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 投入予定ﾛｯﾄ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0090.Instance = New frmxxCM0090()
            
            '@Form_Loadﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0090.Instance = Nothing
                Exit Sub
            End If
            
            '@子画面を一旦非表示にし、ﾓｰﾀﾞﾙ表示にする
            frmxxCM0090.Instance.Hide
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 投入予定ﾛｯﾄ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0090.Instance.ShowDialog(Me)
            frmxxCM0090.Instance = Nothing
            
            '@値をｾｯﾄ
            lblDivideLotID.Text = ptypLotRlst.strLotID               '分割先ﾛｯﾄID
            lblDivideFlowClass.Text = ptypLotRlst.strFlowClass       '分割先ﾛｯﾄ流動区分
            
            '@ﾛｯｸ解除
            lblDivideLotID.Enabled = True                               '分割先ﾛｯﾄID
            lblDivideFlowClass.Enabled = True                           '分割先ﾛｯﾄ流動区分
            
            '@分割先ﾛｯﾄIDがNULLか
            If lblDivideLotID.Text = vbNullString Then
                Exit Sub
            End If
            
            '@=======================
            '@ 取消ﾎﾞﾀﾝ押下時処理
            '@=======================
            Call cmdClear_Click(Me, New EventArgs())

            '@分割元ﾛｯﾄIDがNULLか
            If lblLotID.Text = vbNullString Then
                Exit Sub
            End If

            '@分割先ｽﾛｯﾄﾏｯﾌﾟ制御
            With vsfSlotMap
                .Enabled = True
            End With


            '@分割元ｽﾛｯﾄﾏｯﾌﾟ制御
            With vsfSlotMapStck

                '@分割元ｽﾛｯﾄﾏｯﾌﾟを有効にする
                .Enabled = True
                    
                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
            
                '@WFIDがNULLか
                If .GetData(.Row, CMlngColWFID) = vbNullString Then
                    
                    '@=======================
                    '@ ｽﾛｯﾄﾏｯﾌﾟのｾﾙの背景色変更処理
                    '@=======================
                    Call prvVsfSlotMapBackColor_Set()
                End If
            End With

            '@↓2019/11/26 (Tue) 10:02:11 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@基板工程、LOT.GRBが混在[*]の場合
            If pstrSBID = CPstrSBID1A0 And lblLotGRB.Text <> vbNullString Then
        
                '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
                cmbDivideGrbSel.Clear                       '分割先GRB区分
                cmbDivideGrbSel.Enabled = True              '有効
                cmbDivideGrbSel.CausesValidation = True     'Validate処理不要
                cmbDivideGrbSel.BackColor = vbWhite         '白(ﾊﾞｯｸｶﾗｰ)
        
                '@DEFINE情報取得(GRBｺｰﾄﾞ)
                With ltypMasDefineReq
                    .strMsgVer = CMstrmas_definelistVer     'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strTableName = CMstrTableName          'ﾃｰﾌﾞﾙ名
                    .strColumnName = CMstrColumnName        'ｶﾗﾑ名
                End With
            
                '@MSG通信【DEFINE情報取得】
                lblnAnsGrb = pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns)

                '@戻り値判定
                If lblnAnsGrb = True Then
                    '@配列の件数ﾁｪｯｸ
                    If ltypMasDefineAns.lngMasDefineListCnt > 0 Then
                        '@GRBｺｰﾄﾞをｺﾝﾎﾞへｾｯﾄ
                        Call prvGrbInfo_Disp(ltypMasDefineAns)
                    End If
                End If
            End If
            '@↑2019/11/26 (Tue) 10:02:11 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@作業ﾒﾓを有効にする
            txtWorkMemo.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｽﾛｯﾄﾏｯﾌﾟ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 09:58:42 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 09:43:07 M.Miura      削除ﾎﾞﾀﾝ、分割ﾎﾞﾀﾝ制御を削除(ﾎﾞﾀﾝを押下しても選択ｾﾙが変わらない為)
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfSlotMapStck, cmdUP, cmdDown)            '分割元ｽﾛｯﾄﾏｯﾌﾟ
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfSlotMap, cmdUP, cmdDown)                '分割先ｽﾛｯﾄﾏｯﾌﾟ
            
            '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝが無効か
            If cmdUP.Enabled = False Then
                
                '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdDown)
            Else
                '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdUP)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｽﾛｯﾄﾏｯﾌﾟ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 09:58:42 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 09:52:23 M.Miura      削除ﾎﾞﾀﾝ、分割ﾎﾞﾀﾝ制御を削除(ﾎﾞﾀﾝを押下しても選択ｾﾙが変わらない為)
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfSlotMapStck, cmdUP, cmdDown, False)       '分割元ｽﾛｯﾄﾏｯﾌﾟ
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfSlotMap, cmdUP, cmdDown, False)           '分割先ｽﾛｯﾄﾏｯﾌﾟ
            
            '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝが無効か
            If cmdDown.Enabled = False Then

                '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdUP)
            Else
                '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdDown)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMove_Click
    '機　能：分割(">")ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 10:45:44 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2005/01/05 (Wed) 11:24:12 H.Wajima     表示されていない行が選択されても移載対象にならないように修正
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Click

        Dim lblnRtn             As Boolean      '戻り値変数
        Dim lblnVsfSlotMapNull  As Boolean      'ﾍﾟｰｼﾞDOWNのﾎﾞﾀﾝ状態退避
        Dim llngCnt             As Integer      'ﾙｰﾌﾟのｶｳﾝﾄ
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行
        Dim ScrollPosition      As Point 'NSYS スクロール位置格納用変数

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           
           ScrollPosition = vsfSlotMapStck.ScrollPosition
           vsfSlotMap.Redraw = false
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then

                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else

                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If
                
                '@-----------------------
                '@ 最上段と最下段を画面に表示されている範囲に限定
                '@-----------------------
                '@最上段
                For llngCnt = llngRowTop To llngRowBottom
                    
                    '@選択された行が表示領域か
                    If llngCnt >= .TopRow AndAlso llngCnt <= .BottomRow Then
                        '@表示領域内の場合
                        
                        '@選択最上段行に設定
                        llngRowTop = llngCnt
                        Exit For
                    End If
                Next llngCnt
                
                '@-----------------------
                '@ 選択最下行が表示最下行より下かどうかを判定
                '@ 表示最下行の境目でRowIsVisibleが正しく判定されない為
                '@ →ｸﾞﾘｯﾄﾞの高さを縮めるとRowIsVisibleが正しく判定できるが、一番下にｽｸﾛｰﾙしたときに
                '@ 　ｾﾙのない部分が表示されてしまうので注意
                '@-----------------------
                If llngRowBottom > .TopRow + CMlngSlotMapPageRows - 1 Then
                    '@選択最下行が表示最下行より下の場合
                    
                    '@選択最下行に表示最下行を設定
                    llngRowBottom = .TopRow + CMlngSlotMapPageRows - 1
                End If
            End With


            '@=======================
            '@ 分割元⇒分割先への移載処理
            '@=======================
            Call prvWFTempSet_Proc(llngRowTop, llngRowBottom)

            '@=======================
            '@ 分割元/分割先の背景色変更
            '@=======================
            Call prvGridGRBBackColorChange
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnRtn = prvblncmdRegist_Chk(lblnVsfSlotMapNull)
            
            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnRtn = True Then
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If
            
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにWFなしの場合
            If lblnVsfSlotMapNull = True Then
                
                '@=======================
                '@ 分割WF戻し("<")ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdDelClear_Proc(False)
            Else
                '@=======================
                '@ 分割WF戻し("<")ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdDelClear_Proc(True)
            End If
            
            '@選択範囲の指定
            With vsfSlotMap
                
                '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMap)

                .Row = llngRowTop                 'ｶﾚﾝﾄ行の設定
                .RowSel = llngRowBottom           '選択範囲の設定
            End With
            vsfSlotMap.ScrollPosition = New Point (vsfSlotMapStck.ScrollPosition.X,ScrollPosition.Y)  
            vsfSlotMap.Redraw = True
            '@分割(">")ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMove_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDel_Click
    '機　能：分割WF戻し("<")ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 10:57:38 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2005/01/05 (Wed) 11:33:53 H.Wajima     表示されていない行が選択されても移載対象にならないように修正
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDel.Click

        Dim llngRow             As Integer      '分割先ｽﾛｯﾄﾏｯﾌﾟの戻し対象行格納用
        Dim llngSlotNo          As Integer      'ｽﾛｯﾄNo格納用
        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行
        Dim ScrollPosition      As Point 'NSYS スクロール位置格納用変数
        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
             
            ScrollPosition = vsfSlotMap.ScrollPosition
            vsfSlotMapStck.Redraw = False 
            '@分割先ｽﾛｯﾄﾏｯﾌﾟの戻し対象行格納
            llngRow = vsfSlotMap.Row

            '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfSlotMap)
            
            
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then

                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else
                    '@上の場合
                    
                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If
                
                '@-----------------------
                '@ 最上段と最下段を画面に表示されている範囲に限定
                '@-----------------------
                '@最上段
                For llngCnt = llngRowTop To llngRowBottom
                    
                    '@選択された行が表示領域か
                    If llngCnt >= .TopRow AndAlso llngCnt <= .BottomRow Then
                        '@表示領域内の場合
                        
                        '@選択最上段行に設定
                        llngRowTop = llngCnt
                        Exit For
                    End If
                Next llngCnt
                
                '@-----------------------
                '@ 選択最下行が表示最下行より下かどうかを判定
                '@ 表示最下行の境目でRowIsVisibleが正しく判定されない為
                '@ →ｸﾞﾘｯﾄﾞの高さを縮めるとRowIsVisibleが正しく判定できるが、一番下にｽｸﾛｰﾙしたときに
                '@ 　ｾﾙのない部分が表示されてしまうので注意!!
                '@-----------------------
                If llngRowBottom > .TopRow + CMlngSlotMapPageRows - 1 Then
                    '@選択最下行が表示最下行より下の場合
                    
                    '@選択最下行に表示最下行を設定
                    llngRowBottom = .TopRow + CMlngSlotMapPageRows - 1
                End If
                
                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = llngRowBottom To llngRowTop Step -1
                
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@=======================
                        '@ 分割WF戻し処理＆各種ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvWFTempDel_Proc(llngCnt)
            
                        '@分割先ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№格納
                        llngSlotNo = .GetData(llngCnt, CMlngColSlot)
                        
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄｾﾙ設定
                        vsfSlotMapStck.Row = mlngSlotMapRowS - llngSlotNo
                        
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSlotMapStck)
                        
                        '@分割WF戻し("<")ﾎﾞﾀﾝを無効にする
                        cmdDel.Enabled = False
                    End If
                Next llngCnt
            End With
            
            '@=======================
            '@ 分割元/分割先の背景色変更
            '@=======================
            Call prvGridGRBBackColorChange            

            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck

                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
                
                .Row = llngRowTop           'ｶﾚﾝﾄ行の設定
                .RowSel = llngRowBottom     '選択範囲の設定
            End With
            vsfSlotMapStck.ScrollPosition = New Point (vsfSlotMap.ScrollPosition.X,ScrollPosition.Y)
            vsfSlotMapStck.Redraw  = True 
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDel_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_Click
    '機　能：分割先ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 15:45:12 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub vsfSlotMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            '@↓2019/12/17 (Tue) 17:59:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@基板工程でGRB選択あり
            If pstrSBID = CPstrSBID1A0 And cmbDivideGrbSel.Enabled = True Then
                If cmbDivideGrbSel.Value <> CMstrGRBNoneSelect Then
                    Exit Sub
                End If
            End If
            '@↑2019/12/17 (Tue) 17:59:17 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@=======================
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟの選択時処理
            '@=======================
            Call vsfSlotMap_EnterCell(Me, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_EnterCell
    '機　能：分割先ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 08:51:05 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 10:26:51 M.Miura      分割ﾎﾞﾀﾝの無効設定削除、分割ﾎﾞﾀﾝの有効/無効制御追加
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub vsfSlotMap_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.EnterCell

        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行

        Try
            
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            '@↓2019/12/17 (Tue) 17:59:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@基板工程でGRB選択あり
            If pstrSBID = CPstrSBID1A0 And cmbDivideGrbSel.Enabled = True Then
                If cmbDivideGrbSel.Value <> CMstrGRBNoneSelect Then
                    Exit Sub
                End If
            End If
            '@↑2019/12/17 (Tue) 17:59:17 Y.Yoneyama 「.Netへ反映未」 **************************************************            

            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                '@ﾀｲﾄﾙ行か
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then

                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else

                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If
            End With
            
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                
                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのWFIDのﾊﾞｯｸｶﾗｰがｸﾞﾚｰ、またはWFIDがNULLか
                    If .GetCellRange(llngCnt, CMlngColWFID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Or _
                        .GetData(llngCnt, CMlngColWFID) = vbNullString Then
                        
                        '@分割(">")ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False
                        '@↓2019/12/17 (Tue) 17:14:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        cmdMoveGRB.Enabled = False
                        '@↑2019/12/17 (Tue) 17:14:20 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        Exit For
                    Else
                        '@分割元ｽﾛｯﾄﾏｯﾌﾟのWFIDのﾊﾞｯｸｶﾗｰが白、かつWFIDがNULL以外
                        
                        '@***********************
                        '@ 無機対応
                        '@***********************
                        '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
                        If pblnMkEasyDivFlag = True Then

                            '@分割(">")ﾎﾞﾀﾝを無効にする
							'↓kkw 蒸着治具紐付け機能改修 有効に変更
							If pstrSBID = CPstrSBID2A0 Then
								cmdMove.Enabled = True
							Else
								cmdMove.Enabled = False
							End If
							'↑kkw ここまで変更
                            cmdMoveGRB.Enabled = False

                        Else
                            '@分割(">")ﾎﾞﾀﾝを有効にする
                            cmdMove.Enabled = True
                            '@↓2019/12/17 (Tue) 17:14:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cmdMoveGRB.Enabled = False
                            '@↑2019/12/17 (Tue) 17:14:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                        
                    End If
                Next llngCnt
            End With
            
            
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            '@選択行数分ﾙｰﾌﾟ
            For llngCnt = llngRowBottom To llngRowTop Step -1
                
                '@分割先ｽﾛｯﾄﾏｯﾌﾟのﾊﾞｯｸｶﾗｰが灰色、またはWFIDがNULLか
                If vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Or _
                    vsfSlotMap.GetData(llngCnt, CMlngColWFID) = vbNullString Then
                    
                    '@分割WF戻し("<")ﾎﾞﾀﾝを無効にする
                    cmdDel.Enabled = False
                    Exit Sub
                Else
                
                    '@***********************
                    '@ 無機対応
                    '@***********************
                    '@無機用簡易分割識別ﾌﾗｸﾞが"True：簡易分割実施"か
                    If pblnMkEasyDivFlag = True Then
                        
						If pstrSBID = CPstrSBID2A0 Then
                        '@分割WF戻し("<")ﾎﾞﾀﾝを無効にする
							'↓kkw 蒸着治具紐付け機能改修 有効に変更
							cmdDel.Enabled = True
							'↑kkw ここまで変更
						Else
							cmdDel.Enabled = False
						End If
                    Else
                        
                        '@分割WF戻し("<")ﾎﾞﾀﾝを有効にする
                        cmdDel.Enabled = True
                    End If
                End If
            Next llngCnt
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:39:17 M.Miura
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 12:59:39 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte     As Integer  '現在のﾊﾞｲﾄ数

        Try
                       
            '@現在のﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@ 現在のﾊﾞｲﾄ数を表示処理(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                           
            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
                       
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓ　ｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：Shift,Ctrl,Altｷｰ状態
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            
            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：Shift,Ctrl,Altｷｰ状態
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            
            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:52:32 M.Miura
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 12:57:22 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@=======================
            '@ ﾃｷｽﾄ上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:53:27 M.Miura
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 12:58:24 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@=======================
            '@ ﾃｷｽﾄ下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：取消ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 11:15:57 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
             
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                For llngCnt = 1 To mlngSlotMapRowS - 1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@=======================
                        '@ 分割WF戻し処理＆各種ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvWFTempDel_Proc(llngCnt)
                    End If
                Next llngCnt
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟを有効にする
                .Enabled = True
            End With


            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                
                .Enabled = True             '有効
                .Row = vsfSlotMap.Row       '分割先ｽﾛｯﾄﾏｯﾌﾟの選択行
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
            End With

            '@=======================
            '@ 取消・削除("<")ﾎﾞﾀﾝ制御処理(無効化)
            '@=======================
            Call prvCmdDelClear_Proc(False)
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdRegist_Proc(False)
                
            '@↓2019/12/18 (Wed) 10:38:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@-----------------------
            '@ GRB一括ﾎﾞﾀﾝ制御
            '@-----------------------
            Call prvGRBButtonCntrol
            '@↑2019/12/18 (Wed) 10:38:28 Y.Yoneyama 「.Netへ反映未」 **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClear_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 13:50:34 Y.Yamagishi
    '更新日：2011/09/28 (Wed) 09:05:15 Y.Yoneyama
    '備　考：
    '　　　：2004/09/10 (Fri) 09:23:43 Y.Yamagishi  不具合対応(№358)
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     試作実験ﾛｯﾄの場合、確定時に検査工数削減のMsgを表示する。(案件№03542)
    '　　　：2010/06/21 (Mon) 15:33:52 T.Oide       No.04022対応、分割前の枚葉ﾚｼﾋﾟなしﾁｪｯｸ追加2011/09/28 (Wed) 10:34:20
    '      ：2011/09/28 (Wed) 10:34:25 Y.Yoneyama   区間優先度対応
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim ltypUsechange           As Lotdivide            'Lot分割(要求)
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ1
        Dim lstrMsg2                As String               '変換後ﾒｯｾｰｼﾞ2
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim ltypChkDivderRecipe     As typChkDivderRecipe   'ﾒｯｾｰｼﾞ送信用構造体
        Dim llngMsgAns              As Integer              'ﾒｯｾｰｼﾞﾎﾞｯｸｽの結果格納
        Dim llngCnt2                As Integer
        Dim llngCnt3                As Integer
        Dim lstrResult              As String               '区間優先度判定結果格納
        
        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑのﾛｯｸ中
            If Cursor.Current = Cursors.WaitCursor 
                
                Exit Sub
            End If

            '@=======================
            '@ 確定時ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk()
            
            '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If

            '@↓2019/12/24 (Tue) 13:12:10 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@=======================
            '@ WF.GRBﾁｪｯｸ
            '@=======================
            lblnAns = prvblnGRB_Chk()
    
            If lblnAns = False Then
                Exit Sub
            End If
            '@↑2019/12/24 (Tue) 13:12:10 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '構造体に値をｾｯﾄ
            With ltypChkDivderRecipe
                .strSbID = pstrSBID
                .strLotID = lblLotID.Text
                
                '@ｳｪﾊｰﾘｽﾄを格納
                llngCnt2 = 0
                llngCnt3 = 0
                .strWfList = New List(Of String)
                Do While vsfSlotMapStck.Rows.Count-1 > llngCnt2
                    If vsfSlotMapStck.GetData(llngCnt2, CMlngColWFID) <> vbNullString Then
                        Dim lstrTmp As String = New String("")
                        .strWfList.Add(lstrTmp)
                        .strWfList(llngCnt3) = vsfSlotMapStck.GetData(llngCnt2, CMlngColWFID)
                        llngCnt3 = llngCnt3 + 1
                    End If
                    llngCnt2 = llngCnt2 + 1
                Loop
                
                .strDivLotID = lblDivideLotID.Text
                
                '@分割先ｳｪﾊｰﾘｽﾄを格納
                llngCnt2 = 0
                llngCnt3 = 0
                .strDiveWFList= New List(Of String)
                Do While vsfSlotMap.Rows.Count-1 > llngCnt2
                    If vsfSlotMap.GetData(llngCnt2, CMlngColWFID) <> vbNullString Then
                        Dim lstrTmp As String = New String("")
                        .strDiveWFList.Add(lstrTmp)
                        .strDiveWFList(llngCnt3) = vsfSlotMap.GetData(llngCnt2, CMlngColWFID)
                        llngCnt3 = llngCnt3 + 1
                    End If
                    llngCnt2 = llngCnt2 + 1
                Loop
            
            End With
            
            '@***********************
            '@ 分割前に枚葉ﾚｼﾋﾟが全て空になる工程が無いかﾁｪｯｸ
            '@***********************
            lblnAns = prvblnDivideWfRecipeNull_Chk(CMstrlot_dividerecipeVer, ltypChkDivderRecipe)
            
            '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾒｯｾｰｼﾞがある場合継続or中断のﾒｯｾｰｼﾞ表示
            If ltypChkDivderRecipe.strMsgCode <> vbNullString Then
            
                '@"<MESI0001>$$レシピが未設定な工程が存在しますが、[ロット分割]を実行しますか....
                pstrDMsg = pubstrMsgReplace_Set(CPstrStartMsgCode & ltypChkDivderRecipe.strMsgCode & _
                                                CPstrEndMsgCode & CPstrMsgCrCode & ltypChkDivderRecipe.strMsg)
                llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
            
                '@結果確認
                If llngMsgAns = vbNo Then
                    '@いいえの場合は処理中止
                    Exit Sub
                End If
                
            End If
            
        '@↓2011/09/27 (Tue) 17:43:30 Y.Yoneyama **************************************************
            
            '@***********************
            '@ 分割元ﾛｯﾄに区間優先度設定があるかﾁｪｯｸ
            '@***********************
            lblnAns = prvblnLotSectionPriority_Chk(CMstrlot_chksecpriorityVer, pstrLotID, lstrResult)
            
            '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@結果「1」の場合継続or中断のﾒｯｾｰｼﾞ表示
            If lstrResult = CPstrOne Then
            
                '@"<TRM79I>$$分割元ロット[%1]には区間優先設定がされています。$分割先ロットに区間優先設定はコピーされませんので、$必要に応じ再設定してください。$よろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0079, pstrLotID)
                llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
            
                '@結果確認
                If llngMsgAns = vbNo Then
                    '@いいえの場合は処理中止
                    Exit Sub
                End If
                
            End If
            
        '@↑2011/09/27 (Tue) 17:43:30 Y.Yoneyama **************************************************
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞが入力されたか
            If pstrUserID = vbNullString Then
                
                '@未入力の場合、処理終了
                Exit Sub
            End If

            '@***********************
            '@ 分割確定ﾃﾞｰﾀ作成
            '@***********************
            With ltypUsechange
                
                '@移載工程ｽｷｯﾌﾟがﾁｪｯｸOFFか
                If chkMoveSkip.CheckState = 0 Then
                    .strMsgVer = CMstrlot_divide__Ver           '移載工程あり
                Else
                    .strMsgVer = CMstrlot_dividedirectVer       '移載工程なし
                End If

                .strLotID = lblLotID.Text                       '分割元ﾛｯﾄID
                .strDivideLotID = lblDivideLotID.Text           '分割先ﾛｯﾄID
                .strComments = txtWorkMemo.Text                 '作業ﾒﾓ
                .strEmpID = pstrUserID                          '作業者ｺｰﾄﾞ
                .strLotLastUpdate = mstrLotLastUpdate           '最終更新日時
                .strToCarrierId = txtToCarrier.Text             '分割先ｷｬﾘｱID(ｱﾝﾛｰﾀﾞｷｬﾘｱID)
                
                '@ｽﾛｯﾄﾏｯﾌﾟ処理
                .typWFMap = New List(Of DivideWFMap)()
                For llngCnt = 1 To mlngVsfBottomRow
                    
                    Dim typ As DivideWFMap = New DivideWFMap
                    typ.strSlotPosition = CStr(Format$(llngCnt, CPstrSlotNoFormat))                     'ｽﾛｯﾄ№
                    typ.strWfID = vsfSlotMap.GetData(mlngSlotMapRowS - llngCnt, CMlngColWFID)           'WFID
                    .typWFMap.Add(typ)
                Next llngCnt
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdUseChange_Click"
            Call pubResponseStart(Me.Name, mstrEventName)
            
           
            
            
            '@移載工程ｽｷｯﾌﾟのﾁｪｯｸがOFFか
            If chkMoveSkip.CheckState = 0 Then
                
                '@=======================
                '@ ﾛｯﾄ分割(移載工程あり)
                '@=======================
                lblnAns = pubblnLotDivide_Upd(ltypUsechange, _
                                              lstrGuidMsg, _
                                              lstrGuidMsgCode)
                
                lstrMsg = "ロット分割予約"
                
                '@"<TRM30I>$$[%1]しました。分割元キャリア[%2] 分割元ロット[%3] 分割先ロット[%4]"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0030, lstrMsg, txtCarrier.Text, lblLotID.Text, lblDivideLotID.Text)

            Else
            
                '@=======================
                '@ ﾛｯﾄ分割(移載工程なし)
                '@=======================
                lblnAns = pubblnLotDivideDirect_Upd(ltypUsechange, lstrGuidMsg, lstrGuidMsgCode)
                
                lstrMsg = "ロット分割"
                
                '@"<TRM31I>$$[%1]しました。分割元キャリア[%2] 分割元ロット[%3] 分割先キャリア[%4] 分割先ロット[%5]"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0031, lstrMsg, txtCarrier.Text, lblLotID.Text, txtToCarrier.Text, lblDivideLotID.Text)

            End If
                
            '@ﾛｯﾄ分割結果が"True：成功"か
            If lblnAns = True Then


                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
                
                '@=======================
                '@ ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
                '@=======================
                Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
                
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@起動SBが"1A0：基板"、かつ移載工程ｽｷｯﾌﾟか(♪移載工程ｽｷｯﾌﾟの場合はこのﾀｲﾐﾝｸﾞで表示)
                If pstrSBID = CPstrSBID1A0 And chkMoveSkip.CheckState = 1 Then
            
                    '@ﾛｯﾄの種別が"試作/実験品：GG,TS,WS,ZZ"か
                    If lblFlowClass.Text = CPstrFlowClassGG Or _
                        lblFlowClass.Text = CPstrFlowClassTS Or _
                        lblFlowClass.Text = CPstrFlowClassWS Or _
                        lblFlowClass.Text = CPstrFlowClassZZ Then
                        
                        '@表示ﾒｯｾｰｼﾞを編集(分割元ロット[XXX] 分割先ロット[XXX])
                        lstrMsg = CPstrDivideFrom & CPstrBrLeft & lblLotID.Text & CPstrBrRight
                        lstrMsg2 = CPstrDivideTo & CPstrBrLeft & lblDivideLotID.Text & CPstrBrRight
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM1ZI>$$%1が[%2]されました。$検査工数削減の為、必要に応じて外観・現像検査工程の
                        '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0024, CPstrLot, CPstrDivide, lstrMsg, lstrMsg2)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    End If
                End If

                '@=======================
                '@ 画面初期化処理
                '@=======================
                Call prvFrmxxEN0160_Init()

				If pblnMkEasyDivFlag = True Then
					'簡易分割が成功したら引継ぎｷｬﾘｱIDを消す
					pstrCarrierID = vbNullString
				End If

            Else
                '@ﾛｯﾄ分割結果が"False：失敗"の場合
            
                
                

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If
            
            '@ｷｬﾘｱIDﾃｷｽﾄが無効か
            If txtCarrier.Enabled = False Then
                
                '@ｷｬﾘｱIDﾃｷｽﾄを有効にする
                txtCarrier.Enabled = True
            End If

            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivideGrbSel_Change
    '機　能：GRB区分選択変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/12 (Fri) 09:29:34 H.Hayashi
    '更新日：
    '備　考：
    Private Sub cmbDivideGrbSel_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivideGrbSel.Change

        Try
            
            '@基板工程以外は対象外
            If pstrSBID <> CPstrSBID1A0 Then
                Exit Sub
            End If

            '@=======================
            '@ 取消ﾎﾞﾀﾝ　押下＆Click時処理
            '@=======================
            'cmdClear_Click
    
            '@GRB選択なし
            '@通常分割
            If cmbDivideGrbSel.Value = CMstrGRBNoneSelect Then
                '@GRB一括分割(">>")ﾎﾞﾀﾝは無効
                cmdMoveGRB.Enabled = False
                cmdDelGRB.Enabled = False
                Exit Sub
            End If
    
            '@通常分割ﾎﾞﾀﾝは使用不可
            cmdMove.Enabled = False
            cmdDel.Enabled = False
    
            '@-----------------------
            '@ GRB一括ﾎﾞﾀﾝ制御
            '@-----------------------
            Call prvGRBButtonCntrol
                            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMoveGRB_Click
    '機　能：GRB一括移動(">>")ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/12/17 (Tue) 18:07:13 Y.Yoneyama 「.Netへ反映未」
    '更新日：
    '備　考：
    Private Sub cmdMoveGRB_Click(sender As Object, e As EventArgs) Handles cmdMoveGRB.Click

        Dim lblnRtn             As Boolean
        Dim lblnVsfSlotMapNull  As Boolean
        Dim llngCnt             As Integer
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                For llngCnt = 1 To .Rows.Count - 1
                    '@GRB一致
                    If .GetData(llngCnt, CMlngColGRB) = cmbDivideGrbSel.Value Then
                        '@=======================
                        '@ 分割元⇒分割先への移載処理
                        '@=======================
                        Call prvWFTempSet_Proc(llngCnt, llngCnt)
                    End If
                Next
            End With
    
            '@=======================
            '@ 分割元/分割先の背景色変更
            '@=======================
            Call prvGridGRBBackColorChange

            '@-----------------------
            '@ GRB一括ﾎﾞﾀﾝ制御
            '@-----------------------
            Call prvGRBButtonCntrol

            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnRtn = prvblncmdRegist_Chk(lblnVsfSlotMapNull)
    
            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnRtn = True Then
        
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If
    
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにWFなしの場合
            If lblnVsfSlotMapNull = True Then
                cmdClear.Enabled = False        '取消
                cmdDel.Enabled = False          '<
                cmdMove.Enabled = False         '>
            Else
                cmdClear.Enabled = True         '取消
                cmdDel.Enabled = False          '<
                cmdMove.Enabled = False         '>
            End If
    
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfSlotMap)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMoveGRB_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
         
        End Try

    End Sub

    '関数名：cmdDelGRB_Click
    '機　能：分割WF戻し("<<")ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/12/17 (Tue) 18:34:13 Y.Yoneyama 「.Netへ反映未」
    '更新日：
    '備　考：
    Private Sub cmdDelGRB_Click(sender As Object, e As EventArgs) Handles cmdDelGRB.Click

        Dim lblnRtn             As Boolean
        Dim lblnVsfSlotMapNull  As Boolean
        Dim llngCnt             As Integer

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                
                '@選択行数分ﾙｰﾌﾟ
                For llngCnt = 1 To .Rows.Count - 1
        
                    '@GRB一致
                    If .GetData(llngCnt, CMlngColGRB) = cmbDivideGrbSel.Value Then
                
                        '@=======================
                        '@ 分割WF戻し処理＆各種ﾎﾞﾀﾝ制御処理
                        '@=======================
                        Call prvWFTempDel_Proc(llngCnt)

                    End If
                Next llngCnt
            End With

            '@=======================
            '@ 分割元/分割先の背景色変更
            '@=======================
            Call prvGridGRBBackColorChange

            '@-----------------------
            '@ GRB一括ﾎﾞﾀﾝ制御
            '@-----------------------
            Call prvGRBButtonCntrol

            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnRtn = prvblncmdRegist_Chk(lblnVsfSlotMapNull)
    
            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnRtn = True Then
        
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If
    
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにWFなしの場合
            If lblnVsfSlotMapNull = True Then
                cmdClear.Enabled = False        '取消
                cmdDel.Enabled = False          '<
                cmdMove.Enabled = False         '>
            Else
                cmdClear.Enabled = True         '取消
                cmdDel.Enabled = False          '<
                cmdMove.Enabled = False         '>
            End If
    
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfSlotMap)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDelGRB_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
         
        End Try

    End Sub


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '========================================Private========================================

    '関数名：prvFrmxxEN0160_Init
    '機　能：画面初期化処理
    '引　数：lblnCarrier    ：True：ｷｬﾘｱ項目削除、False：ｷｬﾘｱ項目未削除
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 15:44:34 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 14:11:06 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2005/12/02 (Fri) 13:02:08 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2007/07/23 (Mon) 12:08:40 N.Kasai      ｿｰｽ整備
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvFrmxxEN0160_Init(Optional ByVal lblnCarrier As Boolean = True)

        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数格納
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@=======================
            '@ 機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0160, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝ
            cmdLotSelect.Text = "投入予定" & vbCrLf & "ロット選択"
            
            '@引数で"True：ｷｬﾘｱ項目削除"が渡されたか
            If lblnCarrier = True Then
                
                '@ｷｬﾘｱIDを初期化
                txtCarrier.Text = vbNullString
            End If
            
            '@-----------------------
            '@ ｱﾝﾛｰﾀﾞｷｬﾘｱの初期設定
            '@-----------------------
            With txtToCarrier
                
                .Text = vbNullString                    'NULL
                .Enabled = False                        '無効
                .GotBackColor = vbButtonFace            'ｸﾞﾚｰ
                .BackColor = vbButtonFace               'ｸﾞﾚｰ
            End With
            
            '@各種ﾗﾍﾞﾙの初期化
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '種別ｺｰﾄﾞ
            lblStatus.Text = vbNullString            '状態
            lblOpID.Text = vbNullString              '大工程名
            lblStepID.Text = vbNullString            '小工程名
            lblDivideLotID.Text = vbNullString       '分割先ﾛｯﾄID
            lblDivideFlowClass.Text = vbNullString   '分割先種別ｺｰﾄﾞ
            '@↓2019/11/26 (Tue) 09:53:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblLotGRB.Text = vbNullString            'GRB
            lblLotGRB.BackColor = lblDivideFlowClass.BackColor
      
            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            cmbDivideGrbSel.Clear                       '分割先GRB区分
            cmbDivideGrbSel.Enabled = False             '無効
            cmbDivideGrbSel.CausesValidation = False    'Validate処理不要
            cmbDivideGrbSel.BackColor = vbButtonFace    'ｸﾞﾚｰ(ﾊﾞｯｸｶﾗｰ)
    
            '@基板工程のみ
            If pstrSBID = CPstrSBID1A0 Then
                'lblLotGRB.Visible = True
                lblGRBSel.Visible = True
                cmbDivideGrbSel.Visible = True
            Else
                'lblLotGRB.Visible = False
                lblGRBSel.Visible = False
                cmbDivideGrbSel.Visible = False
            End If
            '@↑2019/11/26 (Tue) 09:53:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '@作業ﾒﾓ初期化
            With txtWorkMemo
                
                .ChrMaxByte = CPlngLotCommentsMaxByte   '2048byte
                .Text = vbNullString                    'NULL
                llngNowByte = .NowByte                  '現状のﾊﾞｲﾄ数を格納
                
                '@=======================
                '@ 現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                '@=======================
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            End With
            
            txtWorkMemo.Enabled = False                     'ｺﾒﾝﾄ：無効

            '@=======================
            '@ ｽﾛｯﾄﾏｯﾌﾟの初期化
            '@=======================
            Call prvvsfSlotMap_init(vsfSlotMapStck)         '左：分割元
            Call prvvsfSlotMap_init(vsfSlotMap)             '右：分割先

            '@両ｽﾛｯﾄﾏｯﾌﾟ共に初期値は無効
            vsfSlotMapStck.Enabled = False                  '分割元ｽﾛｯﾄﾏｯﾌﾟ
            vsfSlotMap.Enabled = False                      '分割先ｽﾛｯﾄﾏｯﾌﾟ

            '@各種ﾎﾞﾀﾝの初期化
            cmdLotSelect.Enabled = False                    '投入予定ﾛｯﾄ選択
            cmdClear.Enabled = False                        '一括取消
            cmdRegist.Enabled = False                       '確定
            cmdUP.Enabled = False                           '分割元ｽﾛｯﾄﾏｯﾌﾟの上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                         '分割元ｽﾛｯﾄﾏｯﾌﾟの下(▼)ｽｸﾛｰﾙ
            cmdMove.Enabled = False                         '移動( > )
            cmdDel.Enabled = False                          '戻す( < )
            '@↓2019/12/17 (Tue) 17:15:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
            cmdMoveGRB.Enabled = False                      '移動( >> )
            cmdDelGRB.Enabled = False                       '戻す( << )
    
            '@基板工程のみ
            If pstrSBID = CPstrSBID1A0 Then
                cmdMoveGRB.Visible = True
                cmdDelGRB.Visible = True
            Else
                cmdMoveGRB.Visible = False
                cmdDelGRB.Visible = False
            End If
            '@↑2019/12/17 (Tue) 17:15:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '@空きｷｬﾘｱ選択ﾎﾞﾀﾝの初期化
            cmdCarrierSelect.Enabled = False                '無効
            cmdCarrierSelect.CausesValidation = False       'Validate処理不要
            
            '@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽの初期化
            chkMoveSkip.Enabled = False                     '無効
            chkMoveSkip.CheckState = 0                           'ﾁｪｯｸOFF
            
            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrCarrier = vbNullString                      'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrLotLastUpdate = vbNullString                'ﾛｯﾄ最終更新日時
            mstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟID(LOADER側)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN0160_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN0160_Disp
    '機　能：画面情報表示処理
    '引　数：ltypLotprestate：ﾛｯﾄ現在状態格納構造体
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 15:59:54 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvFrmxxEN0160_Disp(ByRef ltypLotprestate As Lotprestate)

        Try
            
            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
                
                lblLotID.Text = .strLotID                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass        '流動区分
                lblOpID.Text = .strOpID                  '大工程
                lblStatus.Text = .strNowST               'ﾛｯﾄ状態
                lblStepID.Text = .strStepID              '小工程
                mstrLotLastUpdate = .strLotLastUpdate       '最終更新日時
                '@↓2019/12/17 (Tue) 11:04:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblLotGRB.Text = .strGRBClass            'GRB
                lblLotGRB.BackColor = pubGRBBackColor(.strGRBClass, lblFlowClass.BackColor)
                '@↑2019/12/17 (Tue) 11:04:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN0160_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ初期化処理
    '引　数：lobjControl    ：対象ｸﾞﾘｯﾄﾞ
    '戻り値：なし
    '作成日：2004/03/30 (Tue) 11:24:20 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 09:41:16 M.Miura      「.Row、.Col」の設定はEnterCellｲﾍﾞﾝﾄが実行されるので削除
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvvsfSlotMap_init(ByRef lobjControl As Object)

        Dim llngCnt     As Integer   '汎用ｶｳﾝﾀ
               
        Try
            
            '@引数で渡されたｵﾌﾞｼﾞｪｸﾄが「ｸﾞﾘｯﾄﾞ」か
            If TypeOf lobjControl Is C1FlexGrid Then
                With Ctype(lobjControl,C1FlexGrid)
                    
                    '@-----------------------
                    '@ 各種ﾌﾟﾛﾊﾟﾃｨ設定
                    '@-----------------------
                    .Clear  
                    .Cols.Count = CMlngColNum                                                               '列数
                    .Rows.Count = CMlngSlotMapRowS                                                          '行数
                    'NSYSグリッド表題設定
                    '@↓2019/11/26 (Tue) 09:38:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
                     'Dim CellRange As CellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColClass) 
                     Dim CellRange As CellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColGRB)
                    '@↑2019/11/26 (Tue) 09:38:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    Dim headerStyle As CellStyle= .Styles.Add("headerStyle")
                    headerStyle.TextAlign = TextAlignEnum.CenterCenter                                      '表題表示位置(中央)
                    headerStyle.ForeColor = Color.Yellow                                                    '文字色
                    headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                       '背景色
                    With .Font                                                                              'ﾌｫﾝﾄｻｲｽﾞ
                        headerStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, _
                                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                    End With
                    .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHHeight                                '高さ
                    '非表示行選択
                    .Cols(CMlngColBatchId).Visible = false                                                                 
                    CellRange.Style = headerStyle 

                    '@Slot№設定
                    Dim slotNoStyle As CellStyle = .Styles.Add("slotNoStyle")
                    slotNoStyle.TextAlign = TextAlignEnum.CenterCenter  
                    slotNoStyle.BackColor = System.Drawing.SystemColors.ControlLight
                    For llngCnt = 1 To CMlngSlotMapRowS - 1
                        cellRange = .GetCellRange(llngCnt, CMlngColSlot, llngCnt, CMlngColSlot)
                        With .Font                                                                              
                            slotNoStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize+3, .Style, _
                                                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        cellRange.Style = slotNoStyle
                        .SetData(llngCnt, CMlngColSlot, _
                            CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                        .Rows(llngCnt).Height = CMlngSlotMapHeight
                    Next llngCnt
                           
                    '@-----------------------
                    '@ 列幅、ﾀｲﾄﾙ設定
                    '@-----------------------
                    '@ｽﾛｯﾄID
                    .Cols(CMlngColSlot).Width = CMlngColSlotWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColSlot, CMstrSlotMapColTSlot)
                    
                    '@WFID
                    .Cols(CMlngColWFID).Width = CMlngColWFIDWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColWFID, CMstrSlotMapColTWFID)
                    
                    '@状態
                    .Cols(CMlngColClass).Width = CMlngColClassWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColClass, CMstrSlotMapColTClass)

                    '@↓2019/11/26 (Tue) 09:39:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '@GRB
                    .Cols(CMlngColGRB).Width = CMlngColGRBWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColGRB, CMstrSlotMapColTGRB)
                    '@↑2019/11/26 (Tue) 09:39:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    
                    '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                    .Cols(CMlngColSlot).TextAlign = TextAlignEnum.CenterCenter 

                    '@スロットマップの色指定
                    ’@ここで色指定をしないと背景色を後で取得できない
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                    cellRange = .GetCellRange(CMlngSlotMapRowTitle + 1, CMlngColWFID, .Rows.Count - 1, CMlngColGRB)
                    cellRange.Style = newStyle

                    '@ﾛｯｸ
                    .Enabled = False
                    
                    '@初期表示行番号設定
                    .TopRow = CMlngSlotMapSTopRow
                    
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMap_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ表示処理
    '引　数：ltypWaferInfo  ：ﾛｯﾄWF情報
    '　　　：lobjControl    ：対象ｸﾞﾘｯﾄﾞ
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 17:35:08 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/10/15 (Fri) 18:12:18 M.Miura      ｽﾛｯﾄﾎﾟｼﾞｼｮﾝの数値ﾁｪｯｸを追加
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvvsfSlotMap_Set(ByRef ltypWaferList As Waferlist, _
                                  ByRef lobjControl As Object)

        Dim llngCnt         As Integer      'ｷｬﾘｱのｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込む行

        Try
            
            '@引数で渡されたｵﾌﾞｼﾞｪｸﾄが「ｸﾞﾘｯﾄﾞ」か
            If TypeOf lobjControl Is C1FlexGrid Then

                vsfSlotMapStck.Redraw = False
                vsfSlotMap.Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟの最大ｽﾛｯﾄ数をｷｬﾘｱに応じたｽﾛｯﾄ数に変更
                vsfSlotMapStck.Rows.Count = ltypWaferList.strSlotSize + 1
                vsfSlotMap.Rows.Count = ltypWaferList.strSlotSize + 1
                
                vsfSlotMapStck.Redraw = True
                vsfSlotMap.Redraw = True
                
                'NSYS スロットサイズ25以外における、▲ボタン入力後のグリッドスクロール対策
                Call pubblnVsfTag_Set(vsfSlotMapStck, 1, vsfSlotMapStck.TopRow)
                Call pubblnVsfTag_Set(vsfSlotMap, 1, vsfSlotMap.TopRow)

                '@-----------------------
                '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ、分割先ｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄ№を設定
                '@-----------------------
                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngCnt = 1
                
                Do While vsfSlotMapStck.Rows.Count > llngCnt
                    
                    '@分割元
                    vsfSlotMapStck.SetData(vsfSlotMapStck.Rows.Count - llngCnt, CMlngColSlot, _
                        Format$(llngCnt, CPstrSlotNoFormat))
                    
                    '@分割先
                    vsfSlotMap.SetData(vsfSlotMap.Rows.Count - llngCnt, CMlngColSlot, _
                        Format$(llngCnt, CPstrSlotNoFormat))
                    
                    '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                    llngCnt = llngCnt + 1
                Loop

                '@-----------------------
                '@ WF情報の設定
                '@-----------------------
                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngCnt = 0
                
                Do While ltypWaferList.lngListCnt-1 >= llngCnt
                    
                    With ltypWaferList.typWfList(llngCnt)
                        
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値か
                        If IsNumeric(.strSlotPosition) = True Then
                            
                            '@書き込み行設定(下から№01となる)
                            llngWriteRow = mlngVsfBottomRow + 1 - CLng(.strSlotPosition)
                            
                            '@WFID
                            lobjControl.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                            
                            '@★ WF状態により処理分岐 ★
                            Select Case .strClass

                                '@〓 1：良品 〓
                                Case CPstrClass1

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass1J)    '"良品"を表示
                                
                                '@〓 2：不良 〓
                                Case CPstrClass2

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass2J)    '"不良"を表示
                                
                                '@〓 3：払出 〓
                                Case CPstrClass3

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass3J)    '"払出"を表示
                                
                                '@〓 4：保留 〓
                                Case CPstrClass4

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass4J)    '"保留"を表示
                                
                                '@〓 5：傾向 〓
                                Case CPstrClass5

                                    lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass5J)    '"傾向"を表示
                            
                            End Select

                            '@↓2019/11/26 (Tue) 09:40:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            '@GRB
                            lobjControl.SetData(llngWriteRow, CMlngColGRB, .strGRBClass)
                    
                            '@GRB背景色
                            If .strGRBClass <> vbNullString Then
                                Dim styleGRB As CellStyle = lobjControl.Styles.Add("GRBColor" + llngWriteRow.ToString)
                                styleGRB.BackColor = pubGRBBackColor(.strGRBClass)
                                Dim cellGRB As CellRange = lobjControl.GetCellRange(llngWriteRow, CMlngColGRB)
                                cellGRB.Style = styleGRB
                            End If
                            '@↑2019/11/26 (Tue) 09:40:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                        
                        '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                        llngCnt = llngCnt + 1
                    
                    End With
                Loop
                
                '@-----------------------
                '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ(WFがない場所または、既にｺｰﾄﾞが入っている個所(基本的にない)を灰色に変更する)
                '@-----------------------
                With vsfSlotMapStck
                    
                    '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                    llngCnt = 1
                    
                    Do While .Rows.Count > llngCnt
                        
                        '@WFIDがNULLか
                        If .GetData(llngCnt, CMlngColWFID) = vbNullString Then
                            
                            '@分割元ｽﾛｯﾄﾏｯｯﾌﾟを灰色に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            '@↓2019/11/26 (Tue) 09:41:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            'Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngColWFID)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGRB)
                            '@↑2019/11/26 (Tue) 09:41:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cellRange.Style = newStyle

                            '@分割先ｽﾛｯﾄﾏｯｯﾌﾟを灰色に変更
                            newStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray )
                            '@↓2019/11/26 (Tue) 09:42:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID, llngCnt, CMlngColGRB)
                            '@↑2019/11/26 (Tue) 09:42:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cellRange.Style = newStyle
                        End If
                        
                        '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                        llngCnt = llngCnt + 1
                    Loop
                End With
            
            End If
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMap_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnVsfSlotMapCnt_Chk
    '機　能：ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ
    '引　数：lobjControl    ：対象ｵﾌﾞｼﾞｪｸﾄ
    '戻り値：True：WFあり、False：WFなし
    '作成日：2004/04/13 (Tue) 17:33:32 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Function prvblnVsfSlotMapCnt_Chk(ByRef lobjControl As Object) As Boolean

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@戻り値の初期化
            prvblnVsfSlotMapCnt_Chk = False
            
            '@ｽﾛｯﾄﾏｯﾌﾟの件数ﾁｪｯｸ
            With lobjControl
                
                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngCnt = 1

                For llngCnt = 1 To mlngSlotMapRowS - 1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@戻り値に"True：WFあり"をｾｯﾄ
                        prvblnVsfSlotMapCnt_Chk = True
                        Exit Function
                    End If
                Next llngCnt
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnVsfSlotMapCnt_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvVsfSlotMapBackColor_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟのｾﾙの背景色変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 09:34:07 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvVsfSlotMapBackColor_Set()

        Dim lctlControl     As Control      'ｺﾝﾄﾛｰﾙ名称取得用変数

        Try

            '@当ﾌｫｰﾑ内のｺﾝﾄﾛｰﾙが対象
            For Each lctlControl In GetAllControls(me) 
                
                '@ｸﾞﾘｯﾄﾞか
                If TypeOf lctlControl Is C1FlexGrid Then

                    '@ｽﾛｯﾄﾏｯﾌﾟのｾﾙの背景色をｸﾞﾚｰに変更
                    lctlControl.BackColor = ColorTranslator.FromWin32(CMlngBackColorCel)
                End If
            Next
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapBackColor_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMapTopRow_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの先頭行表示設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 17:14:26 M.Miura
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 10:28:52 M.Miura      初期表示時のｶﾚﾝﾄ行をﾀｲﾄﾙ行に変更
    '　　　：2004/10/26 (Tue) 10:28:52 M.Miura      ｽﾛｯﾄﾏｯﾌﾟの上部、下部表示を追加
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvVsfSlotMapTopRow_Set()

        Dim llngCnt         As Integer      'ｶｳﾝﾄ
        Dim llngRows        As Integer      '行数
        Dim lblnWFFlag      As Boolean      'WF有無ﾌﾗｸﾞ(True：WF有り、False：WF無し)

        Try
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@ ※一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            '@-----------------------
            With vsfSlotMapStck
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟの行数取得
                llngRows = .Rows.Count
                
                '@最大ｽﾛｯﾄが25より小さいか
                If llngRows < CMlngSlotMapRowS Then
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    vsfSlotMap.Row = vsfSlotMap.Rows.Fixed - 1
                    Exit Sub
                End If
                
                '@ｽﾛｯﾄ№01～10までWFがあるかﾁｪｯｸ
                For llngCnt = CMlngSlotMapRowS - 1 To CMlngSlotMapSlotNo10Row Step -1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@WF有無ﾌﾗｸﾞに"True：WF有り"をｾｯﾄ
                        lblnWFFlag = True
                        Exit For
                    End If
                Next llngCnt
                
                '@ｽﾛｯﾄ№01～10にWFがない場合
                If lblnWFFlag = False Then
                    
                    '@ｽﾛｯﾄ№25～16までWFがあるかﾁｪｯｸ
                    For llngCnt = .Rows.Fixed To CMlngSlotMapSlotNo16Row
                        
                        '@WFIDがNULL以外か
                        If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                            
                            '@WF有無ﾌﾗｸﾞに"True：WF有り"をｾｯﾄ
                            lblnWFFlag = True
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@WF有無ﾌﾗｸﾞに"False：WF無し"をｾｯﾄ
                    lblnWFFlag = False
                End If
                
                '@WF有無ﾌﾗｸﾞが"True：WF有り"か
                If lblnWFFlag = True Then
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟの先頭行を"1"(最上行)にｾｯﾄ
                    .TopRow = .Rows.Fixed
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟの先頭行を設定
                    vsfSlotMap.TopRow = vsfSlotMapStck.Rows.Fixed
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    vsfSlotMap.Row = vsfSlotMapStck.Rows.Fixed - 1
                Else
                    '@WF有無ﾌﾗｸﾞが"False：WF無し"の場合
                
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟの先頭行を最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号にｾｯﾄ
                    .TopRow = CMlngSlotMapSlotNo10Row
                    
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟの先頭行を設定
                    vsfSlotMap.TopRow = CMlngSlotMapSlotNo10Row
                    
                    '@分割先ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    vsfSlotMap.Row = vsfSlotMap.Rows.Fixed - 1
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMapTopRow_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnCmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
    '引　数：lblnVsfSlotMapNull ：分割先ｽﾛｯﾄﾏｯﾌﾟのWF有無を返す(True：なし)
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/04/13 (Tue) 17:32:20 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Function prvblncmdRegist_Chk(Optional ByRef lblnVsfSlotMapNull As Boolean= False) As Boolean

        Dim lblnRtn1    As Boolean      '分割元ｽﾛｯﾄﾏｯﾌﾟの件数格納
        Dim lblnRtn2    As Boolean      '分割先ｽﾛｯﾄﾏｯﾌﾟの件数格納

        Try

            '@戻り値の初期化
            prvblncmdRegist_Chk = False
            
            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
                Exit Function
            End If
            
            '@投入予定ﾛｯﾄIDがNULLか
            If lblLotID.Text = vbNullString Then
                Exit Function
            End If
            
            '@=======================
            '@ ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ(分割元ｽﾛｯﾄﾏｯﾌﾟ)
            '@=======================
            lblnRtn1 = prvblnVsfSlotMapCnt_Chk(vsfSlotMapStck)
            
            '@分割元ｽﾛｯﾄﾏｯﾌﾟにWFがないか
            If lblnRtn1 = False Then
                Exit Function
            End If


            '@=======================
            '@ ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ(分割先ｽﾛｯﾄﾏｯﾌﾟ)
            '@=======================
            lblnRtn2 = prvblnVsfSlotMapCnt_Chk(vsfSlotMap)
            
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにWFがないか
            If lblnRtn2 = False Then
                
                '@分割先ｽﾛｯﾄﾏｯﾌﾟのWF有無に"True：WFなし"をｾｯﾄ
                lblnVsfSlotMapNull = True
                Exit Function
            End If
            
            '@移載工程ｽｷｯﾌﾟにﾁｪｯｸが付いているのに、ｱﾝﾛｰﾀﾞｷｬﾘｱが指定されていないか
            If chkMoveSkip.CheckState = 1 And _
                txtToCarrier.Text = vbNullString Then

                Exit Function
            End If
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblncmdRegist_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmdRegist_Proc
    '機　能：確定ﾎﾞﾀﾝ制御処理
    '引　数：lblnRtn    ：ﾎﾞﾀﾝの有効/無効(True or False)
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 17:44:52 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvCmdRegist_Proc(ByVal lblnRtn As Boolean)

        Try

            '@引数値により確定ﾎﾞﾀﾝの有効/無効を制御
            cmdRegist.Enabled = lblnRtn
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdRegist_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdDelClear_Proc
    '機　能：取消・削除("<")ﾎﾞﾀﾝ制御処理
    '引　数：lblnRtn    ：ﾎﾞﾀﾝの有効/無効(True or False)
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 17:44:52 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvCmdDelClear_Proc(ByVal lblnRtn As Boolean)

        Try

            '@引数値により各種ﾎﾞﾀﾝの有効/無効を制御
            cmdClear.Enabled = lblnRtn              '取消ﾎﾞﾀﾝ
            cmdDel.Enabled = lblnRtn                '削除ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdDelClear_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFTempSet_Proc
    '機　能：分割元⇒分割先への移載処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 10:51:47 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvWFTempSet_Proc(ByVal llngRowTop As Integer, ByVal llngRowBottom As Integer)

        Dim ltypWFTmp       As WFTmp    'ｽﾛｯﾄﾏｯﾌﾟの内容格納のための構造体
        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ

        Try
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟの値を格納
            '@-----------------------
            With vsfSlotMapStck
                
                For llngCnt = llngRowBottom To llngRowTop Step -1
                    
                    '@WFIDがNULLか
                    If vsfSlotMap.GetData(llngCnt, CMlngColWFID) = vbNullString Then
                        
                        ltypWFTmp.strWfId = .GetData(llngCnt, CMlngColWFID)                     'WFID
                        ltypWFTmp.strClass = .GetData(llngCnt, CMlngColClass)                   'WF状態
                        '@↓2019/11/26 (Tue) 09:43:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        ltypWFTmp.strGRB = .GetData(llngCnt, CMlngColGRB)                       'GRB
                        '@↑2019/11/26 (Tue) 09:43:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        
                        '@分割先ｽﾛｯﾄﾏｯﾌﾟへ反映
                        vsfSlotMap.SetData(llngCnt, CMlngColWFID, ltypWFTmp.strWfId)            'WFID
                        vsfSlotMap.SetData(llngCnt, CMlngColClass, ltypWFTmp.strClass)          'WF状態
                        '@↓2019/11/26 (Tue) 09:43:53 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        vsfSlotMap.SetData(llngCnt, CMlngColGRB, ltypWFTmp.strGRB)              'GRB
                        '@↑2019/11/26 (Tue) 09:43:53 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@分割元ｽﾛｯﾄﾏｯﾌﾟにNULLをｾｯﾄ
                        .SetData(llngCnt, CMlngColWFID, vbNullString)                           'WFID
                        .SetData(llngCnt, CMlngColClass, vbNullString)                          'WF状態
                        '@↓2019/11/26 (Tue) 09:44:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(llngCnt, CMlngColGRB, vbNullString)                            'GRB
                        '@↑2019/11/26 (Tue) 09:44:17 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    End If
                Next llngCnt
            End With
            
            '@=======================
            '@ 分割元/分割先の背景色変更
            '@=======================
            'Call prvGridGRBBackColorChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWFTempSet_Proc"
                '.strErrMessage = vbNullString
                .strErrMessage = ex.Message
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFTempDel_Proc
    '機　能：分割WF戻し処理＆各種ﾎﾞﾀﾝ制御処理
    '引　数：llngRow    ：対象行
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 10:58:52 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvWFTempDel_Proc(ByVal llngRow As Integer)

        Dim ltypWFTmp           As WFTmp        'ｽﾛｯﾄﾏｯﾌﾟの内容格納のための構造体
        Dim lblnRtn             As Boolean      '戻り値
        Dim llngRowTop          As Integer      '選択最上段行
        Dim llngRowBottom       As Integer      '選択最下段行

        Try

            '@分割先ｽﾛｯﾄﾏｯﾌﾟの情報を格納
            With vsfSlotMap
                
                ltypWFTmp.strSlotNo = .GetData(llngRow, CMlngColSlot)          'ｽﾛｯﾄNo
                ltypWFTmp.strWfId = .GetData(llngRow, CMlngColWFID)            'WFID
                ltypWFTmp.strClass = .GetData(llngRow, CMlngColClass)          'WF状態
                '@↓2019/11/26 (Tue) 09:44:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                ltypWFTmp.strGRB = .GetData(llngRow, CMlngColGRB)              'GRB
                '@↑2019/11/26 (Tue) 09:44:41 Y.Yoneyama 「.Netへ反映未」 **************************************************            

                '@分割先ｽﾛｯﾄﾏｯﾌﾟの対象行に空白をｾｯﾄ
                .SetData(llngRow, CMlngColWFID, vbNullString)                 'WFID
                .SetData(llngRow, CMlngColClass, vbNullString)                'WF状態
                '@↓2019/11/26 (Tue) 09:45:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .SetData(llngRow, CMlngColGRB, vbNullString)                  'GRB
                '@↑2019/11/26 (Tue) 09:45:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
            End With
                    
            '@分割元ｽﾛｯﾄﾏｯﾌﾟへ戻し情報を反映
            With vsfSlotMapStck

                '@分割元ｽﾛｯﾄﾏｯﾌﾟの対象ｾﾙの背景色がｸﾞﾚｰ以外か
                If .BackColor <> ColorTranslator.FromWin32 (CPlngGridDarkGray) Then

                    '@WFIDがNULLか
                    If .GetData(mlngSlotMapRowS - Integer.Parse(ltypWFTmp.strSlotNo), CMlngColWFID) = vbNullString Then

                        .SetData(mlngSlotMapRowS - Integer.Parse(ltypWFTmp.strSlotNo), CMlngColWFID, ltypWFTmp.strWfId)      'WFID
                        .SetData(mlngSlotMapRowS - Integer.Parse(ltypWFTmp.strSlotNo), CMlngColClass, ltypWFTmp.strClass)    'WF状態
                        '@↓2019/11/26 (Tue) 09:45:30 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(mlngSlotMapRowS - Integer.Parse(ltypWFTmp.strSlotNo), CMlngColGRB, ltypWFTmp.strGRB)        'GRB
                        '@↑2019/11/26 (Tue) 09:45:30 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                Else
                    '@ｸﾞﾚｰの場合、処理終了
                    Exit Sub
                End If
            End With
            
            '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(vsfSlotMap)

            With vsfSlotMap
                
                '@選択行が選択範囲行より下か
                If .Row < .RowSel Then
                    
                    llngRowTop = .Row           '選択最上段行を格納
                    llngRowBottom = .RowSel     '選択最下段行を格納
                Else
                    llngRowTop = .RowSel        '選択最下段行を格納
                    llngRowBottom = .Row        '選択最上段行を格納
                End If
            End With
            
            '@=======================
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ選択確定時処理
            '@=======================
            Call vsfSlotMapStck_EnterCell(Me, New EventArgs)
            
            '@=======================
            '@ ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ(分割元ｽﾛｯﾄﾏｯﾌﾟ)
            '@=======================
            lblnRtn = prvblnVsfSlotMapCnt_Chk(vsfSlotMap)
            
            '@ﾁｪｯｸ結果が"False：WFなし"か
            If lblnRtn = False Then
                
                '@=======================
                '@ 取消・削除("<")ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdDelClear_Proc(False)
            Else
                '@ﾁｪｯｸ結果が"True：WFあり"か

                '@=======================
                '@ 取消・削除("<")ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdDelClear_Proc(True)
            End If
                    
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnRtn = prvblncmdRegist_Chk
            
            '@確定ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
            If lblnRtn = True Then
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(有効化)
                '@=======================
                Call prvCmdRegist_Proc(True)
            Else
                
                '@=======================
                '@ 確定ﾎﾞﾀﾝ制御処理(無効化)
                '@=======================
                Call prvCmdRegist_Proc(False)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWFTempDel_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：確定時ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/04/14 (Wed) 13:52:29 Y.Yamagishi
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Function prvblnInput_Chk() As Boolean

        Dim llblRtn     As Boolean      '戻り値

        Try

            '@戻り値の初期化
            prvblnInput_Chk = False
            
            '@-----------------------
            '@ 分割元情報のﾁｪｯｸ
            '@-----------------------
            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDの桁数が6桁未満か
            If txtCarrier.Text.Length < CPlngCarrierMaxLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If

            '@分割元ﾛｯﾄIDがNULLか
            If lblLotID.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM22W>$$ロットIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@=======================
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ
            '@=======================
            llblRtn = prvblnVsfSlotMapCnt_Chk(vsfSlotMapStck)
            
            '@"False：WF無し"か
            If llblRtn = False Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM38W>$$全数分割はできません。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0038)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
                Exit Function
            End If
            
            
            '@-----------------------
            '@ 分割先情報のﾁｪｯｸ
            '@-----------------------
            '@=======================
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟのWF有無ﾁｪｯｸ
            '@=======================
            llblRtn = prvblnVsfSlotMapCnt_Chk(vsfSlotMap)
            
            '@"False：WF無し"か
            If llblRtn = False Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM39W>$$ウエハIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0039)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@分割先ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMap)
                Exit Function
            End If
            

            '@-----------------------
            '@ 移載工程ｽｷｯﾌﾟのﾁｪｯｸ
            '@-----------------------
            '@移載工程ｽｷｯﾌﾟがﾁｪｯｸONか
            If chkMoveSkip.CheckState = 1 Then
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                If txtToCarrier.Text = vbNullString Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier)
                    Exit Function
                End If
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDの桁数が6桁未満か
                If txtCarrier.Text.Length  < CPlngCarrierMaxLength Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier)
                    Exit Function
                End If
            End If
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnEasyDivideAutoExe_Proc
    '機　能：簡易分割処理
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2009/06/17 (Wed) 09:26:22 K.Nishizawa
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Function prvblnEasyDivideAutoExe_Proc() As Boolean

        Dim lblnAns                 As Boolean
        
        Try
            
            '@戻り値の初期化
            prvblnEasyDivideAutoExe_Proc = False
            
            '@=======================
            '@ 分割ﾛｯﾄ取得処理
            '@=======================
            lblnAns = prvGetDivideLotId_Sel
            
            '@分割ﾛｯﾄ取得処理結果が"False：失敗"か
            If lblnAns = False Then
                Exit Function
            End If
            
            '@引継ぎｷｬﾘｱIDをｾｯﾄ(txtCarrier_chageが走行します)
            txtCarrier.Text = pstrCarrierID


            '@=======================
            '@ ｷｬﾘｱﾃｷｽﾄのValidate処理
            '@=======================
            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 
            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs)
            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 

            '@=======================
            '@ 蒸着ﾊﾞｯﾁﾘｽﾄのﾁｪｯｸ
            '@=======================
            lblnAns = prvblnJBatchList_Chk
            
            '@蒸着ﾊﾞｯﾁﾘｽﾄのﾁｪｯｸ結果が"False：分割不可"か
            If lblnAns = False Then
                Exit Function
            End If
            
            '@分割先ﾛｯﾄID、流動区分をｾｯﾄ
            lblDivideLotID.Text = mstrLotId
            lblDivideFlowClass.Text = mstrFlowClass


            '@=======================
            '@ 簡易分割用移載設定処理
            '@=======================
            Call prvAutoWaferMove_Proc()

            '@-----------------------
            '@ 作業開始画面以外から簡易分割を実行した場合
            '@ ※現状作業開始画面からの起動はTPAL作業開始しかない
            '@-----------------------
            If pblnfrmxxEN0030Kbn = False Then
                
                '@=======================
                '@ 簡易分割時仮想ｷｬﾘｱID取得処理
                '@=======================
                Call prvGetDummyCarrierId()
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
                cmdCarrierSelect.Enabled = False

            End If
            
            '@戻り値に"True：成功"をｾｯﾄ
            prvblnEasyDivideAutoExe_Proc = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnEasyDivideAutoExe_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvMakeDivideLotId_Exec
    '機　能：分割子ﾛｯﾄ取得処理(簡易分割用)
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2009/06/17 (Wed) 09:26:22 K.Nishizawa
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Function prvGetDivideLotId_Sel() As Boolean

        Dim lblnAns             As Boolean                   '戻り値格納用
        Dim ltypLotCurState     As Lotprestate               'ﾛｯﾄ現在状態取得結果格納用
        Dim ltypLotRsrv         As Lotresvlist               '投入予定ﾛｯﾄ一覧格納用
        Dim ltypLotRlstList     As List(Of typLotRlst)       '投入予定ﾛｯﾄ一覧格納用(???)
        Dim llngCnt             As Integer                   '汎用ｶｳﾝﾀ
        Dim llngFlowClassCnt    As Integer                   '流動区分件数
         
        Try
            
            '@戻り値の初期化
            prvGetDivideLotId_Sel = False
            
            '@=======================
            '@ ﾛｯﾄ現在状態取得
            '@=======================
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD36, _
                                            vbNullString, _
                                            ltypLotCurState, _
                                            pstrLotID)

            '@ﾛｯﾄ現在状態取得結果が"True：取得成功"か
            If lblnAns = True Then
                
                '@流動区分ﾘｽﾄの初期化
                If ltypLotRsrv.typFlowClassList Is Nothing 
                    ltypLotRsrv.typFlowClassList = New List(Of FlowClassList) 
                Else 
                    ltypLotRsrv.typFlowClassList.Clear()
                End If
                
                ltypLotRsrv.strLotID = ltypLotCurState.strLotID     'ﾛｯﾄID
                ltypLotRsrv.strClassDivision = CPstrCD0N            '処理区分：分割ﾛｯﾄ
                
                '@流動区分ﾘｽﾄの配列定義
                Dim typFlowClassListtmp As FlowClassList = New FlowClassList
                typFlowClassListtmp.strFlowClass = ltypLotCurState.strFlowClass
                ltypLotRsrv.typFlowClassList.Add(typFlowClassListtmp) '流動区分
                     
                
                '@投入LOT予定ﾘｽﾄの初期化
                 If ltypLotRlstList is Nothing Then
                    ltypLotRlstList = New List(Of typLotRlst) 
                 Else 
                    ltypLotRlstList.Clear()
                 End If
                
                '@=======================
                '@ 投入予定ﾛｯﾄ一覧取得
                '@=======================
                lblnAns = pubblnLotRsvlist__Sel(CMstrlot_rsvlist_Ver, _
                                                ltypLotRlstList, _
                                                llngFlowClassCnt, _
                                                ltypLotRsrv)
                
                '@投入予定ﾛｯﾄ一覧取得結果が"True：取得成功"か
                If lblnAns = True Then

                    '@流動区分が0件以上あるか
                    If llngFlowClassCnt <> 0 Then

                        For llngCnt = 0 To llngFlowClassCnt
                            
                            '@1件だけ取得して終了
                            mstrLotId = ltypLotRlstList(llngCnt).strLotID           'ﾛｯﾄID
                            mstrFlowClass = ltypLotRlstList(llngCnt).strFlowClass   '流動区分
                            
                            Exit For
                        Next llngCnt
                    Else
                        '@流動区分が0件の場合
                        
                        '@=======================
                        '@ 分割子ﾛｯﾄの自動生成処理
                        '@=======================
                        Call prvAutoMakeDivideLotID_Proc(ltypLotCurState)
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    prvGetDivideLotId_Sel = True
                End If
            
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGetDivideLotId_Sel"
                .strErrMessage = vbNullString
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvAutoWaferMove_Proc
    '機　能：簡易分割用移載設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/17 (Wed) 09:26:22 K.Nishizawa
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvAutoWaferMove_Proc()
        
        Dim llngCnt         As Integer      '行ｶｳﾝﾀ
        Dim llngWFcnt       As Integer      '移載WFｶｳﾝﾄ
        Dim llngJBatchCnt   As Integer      '蒸着ﾊﾞｯﾁIDｶｳﾝﾀ
        Dim lstrBatchID     As String       'ﾊﾞｯﾁID
        
        Try
            
            '@移載WFｶｳﾝﾄの初期化
            llngWFcnt = 0
            
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@ ※移動させる対象のWaferIDを検索する
            '@-----------------------
            With vsfSlotMapStck
                
                '@分割元ｽﾛｯﾄﾏｯﾌﾟを有効にする
                .Enabled = True
                
                '@蒸着ﾊﾞｯﾁIDｶｳﾝﾀの初期化
                llngJBatchCnt = 1
                
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        
                        '@-----------------------
                        '@ 蒸着ﾊﾞｯﾁIDがNULLか
                        '@ ※蒸着工程での簡易分割を想定
                        '@-----------------------
                        If .GetData(llngCnt, CMlngColBatchId) = vbNullString Then
                            
                            '@=======================
                            '@ 分割元⇒分割先への移載処理
                            '@=======================
                            Call prvWFTempSet_Proc(llngCnt, llngCnt)
                            
                            '@移戴WFｶｳﾝﾄ
                            llngWFcnt = llngWFcnt + 1

                        Else
                            '@-----------------------
                            '@ 蒸着ﾊﾞｯﾁIDがある場合
                            '@ ※TPALでの簡易分割を想定
                            '@-----------------------
                        
                            '@TPAL前簡易分割実施可否識別ﾌﾗｸﾞ(無機流動用)が"True：簡易分割実施"か
                            If mblnTpalBefFlag = True Then
                                
                                '@ﾊﾞｯﾁIDが存在する一番最初の行は無条件で移載
                                If llngJBatchCnt = CPlngNumOne Then
                                    
                                    '@=======================
                                    '@ 分割元⇒分割先への移載処理
                                    '@=======================
                                    Call prvWFTempSet_Proc(llngCnt, llngCnt)
                                    
                                    '@ﾊﾞｯﾁIDを変数に退避
                                    lstrBatchID = .GetData(llngCnt, CMlngColBatchId)
                                    
                                    '@蒸着ﾊﾞｯﾁIDｶｳﾝﾀを+1する
                                    llngJBatchCnt = llngJBatchCnt + 1
                                    
                                    '@移戴WFｶｳﾝﾄを+1する
                                    llngWFcnt = llngWFcnt + 1
                                Else
                                    '@蒸着ﾊﾞｯﾁIDｶｳﾝﾀが1以外の場合
                                
                                    '@ﾊﾞｯﾁIDがある場合はﾊﾞｯﾁIDが同じもの同士で分割する
                                    If lstrBatchID = .GetData(llngCnt, CMlngColBatchId) Then
                                        
                                        '@=======================
                                        '@ 分割元⇒分割先への移載処理
                                        '@=======================
                                        Call prvWFTempSet_Proc(llngCnt, llngCnt)
                                        
                                        '@蒸着ﾊﾞｯﾁIDｶｳﾝﾀを+1する
                                        llngJBatchCnt = llngJBatchCnt + 1

                                        '@移戴WFｶｳﾝﾄを+1する
                                        llngWFcnt = llngWFcnt + 1
                                    End If
                                End If
                            End If
                        End If
                    End If
                    
                    '@TPAL前簡易分割実施可否識別ﾌﾗｸﾞ(無機流動用)が"False：簡易分割未実施"か
                    If Not mblnTpalBefFlag Then
                        
                        '@分割元ﾛｯﾄは2WF(全WF-移戴WF=残り親ﾛｯﾄ)
                        If (mtypJBatList.lngJBatchLotListCnt - llngWFcnt) <= 2 Then
                            Exit For
                        End If
                    End If
                Next llngCnt
            End With
            
            '@分割先ｽﾛｯﾄﾏｯﾌﾟを有効にする
            vsfSlotMap.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAutoWaferMove_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAutoMakeDivideLotID_Proc
    '機　能：分割子ﾛｯﾄの自動生成処理
    '引　数：ltypLotCurStatus   ：ﾛｯﾄ現在情報構造体
    '戻り値：なし
    '作成日：2009/06/17 (Wed) 09:26:22 K.Nishizawa
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvAutoMakeDivideLotID_Proc(ByRef ltypLotCurState As Lotprestate)

        Dim ltypLotReserve      As LotReserve
        Dim lblnAns             As Boolean

        Try


            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotReserve
                
                .strSbID = pstrSBID
                
                '@親画面から引き渡されたﾛｯﾄIDがNULL以外か
                If pstrLotID <> vbNullString Then

                    .strDivideLotID = pstrLotID         '分割ﾛｯﾄID
                    .strCopySeqLotID = pstrLotID        '分割元ﾛｯﾄID
                Else
                    Exit Sub
                End If

                '@分割ﾛｯﾄ&工順ｺﾋﾟｰ(0N0Q)
                .strClassDivision = CPstrCD0N & CPstrCD0Q
                
                '@分割ﾛｯﾄ作成の場合は機種&WF数は必要なし
                .strPdId = vbNullString                 'NULL
                .strWfNum = CMstrWFDefault              '0
                
                '@lot_curstateから情報ｾｯﾄ
                .strFlowClass = ltypLotCurState.strFlowClass            '流動区分
                .strEngEmpId = ltypLotCurState.strEngEmpId              '技術担当
                .strPlanThrowinDate = Format$(Now, CPstrDateTimeYMD)    '投入予定日
                .strLotSendFlag = ltypLotCurState.strLotSendFlag        '送品ﾌﾗｸﾞ
                .strPROrderID = ltypLotCurState.strPROrderID            'P/Rｵｰﾀﾞｰ
                
                '@ﾕｰｻﾞｰIDは"工程管理ﾕｰｻﾞｰ(9999995)"とする
                .strEmpID = CPstrEasyLotDivideUserID
            End With
            
            '@=======================
            '@ ﾛｯﾄ投入予約
            '@=======================
            lblnAns = pubblnLotThrowrsv_Ins(CMstrlot_throwrsvVer, _
                                            ltypLotReserve)
                            
            '@ﾛｯﾄ投入予約結果が"True：成功"か
            If lblnAns Then

                mstrLotId = ltypLotReserve.strLotID             '採番ﾛｯﾄID
                mstrFlowClass = ltypLotReserve.strFlowClass     '流動区分
                
                '@=======================
                '@ ﾛｯﾄ予約承認
                '@=======================
                lblnAns = pubblnLotApprove_Ins(CMstrlot_approveVer, _
                                               ltypLotReserve)
                
                '@ﾛｯﾄ予約承認結果が"True：成功"か
                If lblnAns Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM03I>$$投入予定ロット[%1]を登録しました。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0003, mstrLotId)
                    Call pubVsfInfo_Disp(pstrDMsg)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAutoMakeDivideLotID_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGetDummyCarrierId
    '機　能：簡易分割時仮想ｷｬﾘｱID取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/17 (Wed) 09:26:22 K.Nishizawa
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvGetDummyCarrierId()

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim llngCarrierIDSerialNum  As Integer              'ｷｬﾘｱIDの連番
        Dim ltypCarrierList         As CarrList             'ｷｬﾘｱ一覧取得結果格納用
        Dim ltypCarrierListReq      As CarrierListReq       '仮想ｷｬﾘｱ検索送信ﾃﾞｰﾀ格納用
        Dim ltypCarrierAdd          As CarrierAdd           '
        Dim lblnAns                 As Boolean              '戻り値格納用
        Dim lblnMakeAns             As Boolean              '
        Dim lstrFormatSerialNum     As String               'ﾌｫｰﾏｯﾄしたｷｬﾘｱIDの連番
        
        Try
            
            '@簡易分割仮想ｷｬﾘｱの初期化
            mstrDumCarrierID = vbNullString
            
            '@***********************
            '@ 仮想ｷｬﾘｱ検索送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypCarrierListReq

                .strMsgVer = CMstrcarrlist____Ver               'ﾒｯｾｰｼﾞVer
                .strClassDivision = CPstrCD02                   '処理区分(02：全て)
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strCarrierTypeID = CMstrDumCarrierTypeID       'ｷｬﾘｱﾀｲﾌﾟ(CARRSYS0：簡易分割用仮想ｷｬﾘｱのﾀｲﾌﾟ)
            End With
            
            '@=======================
            '@ ｷｬﾘｱ一覧取得(空き仮想ｷｬﾘｱ)
            '@=======================
            lblnAns = pubblnCarrList_Sel(ltypCarrierListReq, _
                                         ltypCarrierList)
            
            '@ｷｬﾘｱ一覧取得結果が"True：取得成功"か
            If lblnAns = True Then

                With ltypCarrierList
                    
                    '@ｷｬﾘｱIDの連番の初期化
                    llngCarrierIDSerialNum = 1
                    
                    '@-----------------------
                    '@ 空き仮想ｷｬﾘｱがなければ無条件でｷｬﾘｱを作成
                    '@-----------------------
                    '@空き仮想ｷｬﾘｱﾘｽﾄが0件か
                    If .lngCarrierListCnt = 0 Then
                        '@0件の場合
                        
                        '@仮想ｷｬﾘｱ情報を作成("I"+"NNNNN")
                        lstrFormatSerialNum = Format$(CLng(llngCarrierIDSerialNum), CMstrFormatCarrIdSerial)
                        ltypCarrierAdd.strCarrierId = CMstrDumCarrierFirstWords & lstrFormatSerialNum
                        ltypCarrierAdd.strSbID = pstrSBID
                        ltypCarrierAdd.strStartTime = Format$(Now, CPstrDateTimeYMD)
                        ltypCarrierAdd.strCarrierTypeID = CMstrDumCarrierTypeID
                        ltypCarrierAdd.strProductionDate = Format$(Now, CPstrDateTimeYMD)
                    Else
                        '@空き仮想ｷｬﾘｱがある場合
                    
                        '@対象のｷｬﾘｱがあれば使えるもののみ(1ｷｬﾘｱだけ)を探す
                        For llngCnt = 0 To .lngCarrierListCnt-1
                            
                            '@WF搭載なし、かつﾛｯﾄID紐付きなしか
                            If .typCarrierList(llngCnt).strEmptyFlag <> CMstrAri And _
                                .typCarrierList(llngCnt).strLotID = vbNullString Then

                                '@仮想ｷｬﾘｱ退避変数に退避
                                mstrDumCarrierID = .typCarrierList(llngCnt).strCarrierId
                                Exit For
                            Else
                                '@WF搭載あり、またはﾛｯﾄID紐付きありの場合
                                
                                '@ｷｬﾘｱIDの連番と仮想ｷｬﾘｱﾘｽﾄの件数が同じか
                                If llngCarrierIDSerialNum = .lngCarrierListCnt Then
                                    
                                    '@ｼﾘｱﾙ部分をｲﾝｸﾘﾒﾝﾄする
                                    '@ｷｬﾘｱIDでORDER BYしているので最後のﾘｽﾄのIDをMAX値としてｲﾝｸﾘﾒﾝﾄする
                                    llngCarrierIDSerialNum = CLng(Strings.Right(.typCarrierList(llngCnt).strCarrierId, 5))
                                    llngCarrierIDSerialNum = llngCarrierIDSerialNum + 1
                                    
                                    '@使えるものがないので、ｷｬﾘｱIDを生成
                                    lstrFormatSerialNum = Format$(CLng(llngCarrierIDSerialNum), CMstrFormatCarrIdSerial)
                                    ltypCarrierAdd.strCarrierId = CMstrDumCarrierFirstWords & lstrFormatSerialNum
                                    ltypCarrierAdd.strSbID = pstrSBID
                                    ltypCarrierAdd.strStartTime = Format$(Now, CPstrDateTimeYMD)
                                    ltypCarrierAdd.strCarrierTypeID = CMstrDumCarrierTypeID
                                    ltypCarrierAdd.strProductionDate = Format$(Now, CPstrDateTimeYMD)
                                End If
                            End If
                            
                            '@ｷｬﾘｱIDの連番を+1する
                            llngCarrierIDSerialNum = llngCarrierIDSerialNum + 1
                        Next
                    End If
                    
                    '@仮想ｷｬﾘｱIDの作成情報があるか
                    If ltypCarrierAdd.strCarrierId <> vbNullString Then
                        
                        '@=======================
                        '@ ｷｬﾘｱ新規追加
                        '@=======================
                        lblnMakeAns = pubblnCarrierID_Ins(CMstrcarradditionVer, _
                                                          ltypCarrierAdd)
                        
                        '@仮想ｷｬﾘｱ退避変数に新規登録したｷｬﾘｱIDを退避
                        mstrDumCarrierID = ltypCarrierAdd.strCarrierId
                    End If
                End With
            End If
            
            '@仮想ｷｬﾘｱIDをｱﾝﾛｰﾀﾞｷｬﾘｱIDにｾｯﾄ
            txtToCarrier.Text = mstrDumCarrierID
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGetDummyCarrierId"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvJBatchID_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟへの蒸着ﾊﾞｯﾁID設定処理
    '引　数：lobjControl    ：対象ｽﾛｯﾄﾏｯﾌﾟ
    '戻り値：なし
    '作成日：2009/06/23 (Tue) 17:35:08 K.Nishizawa
    '更新日：2009/08/06 (Thu) 15:09:33 N.Kojima
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Sub prvJBatchID_Set(ByRef lobjControl As Object)

        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
        Dim llngRowCnt          As Integer  'ｽﾛｯﾄﾏｯﾌﾟｶｳﾝﾀ
        Dim griddata            As String   'NSYS グリッドから取り出したデータ格納

        Try
            
            If TypeOf lobjControl Is C1FlexGrid Then
                
                With mtypJBatList
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟのﾙｰﾌﾟ
                    For llngRowCnt = 1 To lobjControl.Rows.Count-1
                        
                        '@蒸着ﾊﾞｯﾁﾘｽﾄのﾙｰﾌﾟ
                        For llngCnt = 0 To .lngJBatchLotListCnt-1
                            griddata = lobjControl.GetData(llngRowCnt, CMlngColWFID)
                            With .typJBatchLotList(llngCnt)                                
                                '@蒸着ﾊﾞｯﾁﾘｽﾄのWFIDがNULL以外、かつ対象ｽﾛｯﾄのWFIDと蒸着ﾊﾞｯﾁﾘｽﾄのWFIDが同じか
                                If .strBatchId <> vbNullString And _
                                    griddata =.strWfId
                                    
                                    '@ﾊﾞｯﾁID(非表示)をｾｯﾄ
                                    lobjControl.SetData(llngRowCnt, CMlngColBatchId, .strBatchId)
                                
                                End If
                            End With
                        Next llngCnt
                    Next llngRowCnt
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvJBatchID_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnJBatchList_Chk
    '機　能：対象ﾛｯﾄが簡易分割可能かのﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：分割可、False：分割不可
    '作成日：2009/06/25 (Thu) 17:01:48 Y.Yoneyama
    '更新日：2016/09/28 (Wed) 15:53:13 S.Otaki
    '備　考：
    '　　　：2009/08/06 (Thu) 15:09:33 N.Kojima     確定後にMsg表示する件のついでにｿｰｽ整備。(案件№03542)
    Private Function prvblnJBatchList_Chk() As Boolean

        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim lstrJBatchId1       As String
        Dim lstrJBatchId2       As String
             
        Try

            '@戻り値の初期化
            prvblnJBatchList_Chk = False
            
            '@変数初期化
            lstrJBatchId1 = vbNullString
            lstrJBatchId2 = vbNullString
            
            '@蒸着ﾊﾞｯﾁIDのﾁｪｯｸ
            For llngCnt = 0 To mtypJBatList.lngJBatchLotListCnt-1
          
                '@-----------------------
                '@ 作業開始画面以外から簡易分割を実行したか
                '@ ※現状作業開始画面からの起動は、TPAL作業開始しか無い
                '@-----------------------
                If pblnfrmxxEN0030Kbn = True Then

                    '@蒸着ﾊﾞｯﾁIDがNULL
                    If mtypJBatList.typJBatchLotList(llngCnt).strBatchId = vbNullString Then
                        '@NULLの場合はｴﾗｰ
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM9YW>$$ロット[%1]は[%2]為、簡易分割出来ません。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Y, pstrLotID, CMstrNoJBatchID)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                        Exit Function
                    Else
                        '@蒸着ﾊﾞｯﾁIDがある場合
                        
                        '@***********************
                        '@ 分割対象は2種類の蒸着ﾊﾞｯﾁIDのみ
                        '@***********************

                        '@1番目の蒸着ﾊﾞｯﾁIDがNULLか
                        If lstrJBatchId1 = vbNullString Then
                            
                            '@1番目の蒸着ﾊﾞｯﾁIDに設定する
                            lstrJBatchId1 = mtypJBatList.typJBatchLotList(llngCnt).strBatchId
                        End If
                        
                        '@1番目の蒸着ﾊﾞｯﾁIDと異なるか
                        If lstrJBatchId1 <> mtypJBatList.typJBatchLotList(llngCnt).strBatchId Then
                            
                            '@2番目の蒸着ﾊﾞｯﾁIDがNULLか
                            If lstrJBatchId2 = vbNullString Then
                                
                                '@2番目の蒸着ﾊﾞｯﾁIDを設定する
                                lstrJBatchId2 = mtypJBatList.typJBatchLotList(llngCnt).strBatchId
                            End If
                            
                            '@2番目の蒸着ﾊﾞｯﾁIDと異なるか
                            If lstrJBatchId2 <> mtypJBatList.typJBatchLotList(llngCnt).strBatchId Then
                            
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM9YW>$$ロット[%1]は[%2]為、簡易分割出来ません。"のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Y, pstrLotID, CMstrOverTwoJBatchID)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                                Exit Function
                            End If
                        End If
                    End If
                    
                    '@TPAL前簡易分割実施可否識別ﾌﾗｸﾞに"True：???"をｾｯﾄ
                    mblnTpalBefFlag = True

                Else
                    '@-----------------------
                    '@ 作業開始画面以外から簡易分割を実行した場合
                    '@ ※蒸着工程での簡易分割を想定
                    '@-----------------------

                    '@蒸着ﾊﾞｯﾁIDがNULL以外か
                    If mtypJBatList.typJBatchLotList(llngCnt).strBatchId <> vbNullString Then
                            
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM9YW>$$ロット[%1]は[%2]為、簡易分割出来ません。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Y, pstrLotID, CMstrBeJBatchID)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                        Exit Function
                    End If
                    
                    '@TPAL前簡易分割実施可否識別ﾌﾗｸﾞに"False：???"をｾｯﾄ
                    mblnTpalBefFlag = False

                End If
            
            Next llngCnt
            
            '@TPAL前簡易分割実施可否識別ﾌﾗｸﾞが"True：???"か
            If mblnTpalBefFlag = True Then
                
                '@TPAL作業待ちからの簡易分割
                
                '@-----------------------
                '@ 簡易分割できる最小WF数は"2"
                '@-----------------------
                '@蒸着ﾊﾞｯﾁﾛｯﾄが2件以下か
                If mtypJBatList.lngJBatchLotListCnt < 2 Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@<TRM9YW>$$ロット[%1]は[%2]為、簡易分割出来ません。
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Y, pstrLotID, CMstrFewWF)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Function
                End If
            Else
                '@TPAL以外からの簡易分割(蒸着工程を想定)
                
                '@-----------------------
                '@ 簡易分割できる最小WF数は"2"
                '@-----------------------
                '@蒸着ﾊﾞｯﾁﾛｯﾄが2件以下か
                If mtypJBatList.lngJBatchLotListCnt < 2 Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM9YW>$$ロット[%1]は[%2]為、簡易分割出来ません。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Y, pstrLotID, CMstrFewWF)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Function
                End If
            End If


        '@↓2016/09/28 (Wed) 15:52:25 S.Otaki **************************************************
            '@簡易分割できる最大WF数設定と判定
            '@ TPAL前は4　その他は5(蒸着前)
            Dim divMaxCnt As Short
            If mblnTpalBefFlag = True Then
                divMaxCnt = 4
            Else
				'kkw 組立投入WF枚数変更
				'20枚投入&分割を可能にする
                divMaxCnt = 21
            End If
            If mtypJBatList.lngJBatchLotListCnt > divMaxCnt Then
        '@↑2016/09/28 (Wed) 15:52:25 S.Otaki **************************************************
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM9YW>$$ロット[%1]は[%2]為、簡易分割出来ません。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Y, pstrLotID, CMstrManyWF)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                Exit Function
            End If
            
            '@戻り値に"True：分割可能"をｾｯﾄ
            prvblnJBatchList_Chk = True
            
            Exit Function
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnJBatchList_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvGrbInfo_Disp
    '機　能：GRB区分ｺｰﾄﾞをｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2016/02/14 (Sun) 15:23:40 H.Hayashi
    '更新日：
    '備　考：
    Private Sub prvGrbInfo_Disp(ByRef ltypMasDefineAns As MasDefineAns)
    
        Dim llngCnt         As Integer
        Dim llngRowCnt      As Integer

        Try
    
            With cmbDivideGrbSel
    
                .Clear
        
                '@指定なし
                .AddItem(CMstrGRBNoneSelect)

                For llngCnt = 0 To ltypMasDefineAns.lngMasDefineListCnt -1
                    '@WF.GRBを対象とする
                    For llngRowCnt = 1 To vsfSlotMapStck.Rows.Count - 1
            
                        '@WFIDがNULL以外か
                        If vsfSlotMapStck.GetData(llngRowCnt, CMlngColGRB) = ltypMasDefineAns.typMasDefineList(llngCnt).strName Then
                            '@GRB区分ｺｰﾄﾞ
                            .AddItem(ltypMasDefineAns.typMasDefineList(llngCnt).strName)
                            Exit For
                        End If
                    Next
                Next llngCnt
        
                '@GRB区分ｺｰﾄﾞが１件の場合
                If .ListCount = 1 Then
                    '@１件目表示
                    .ListIndex = 0
                Else
                    .ListIndex = 0
                End If
        
            End With
    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGrbInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGRBButtonCntrol
    '機　能：GRBﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2019/12/18 (Wed) 09:44:49 Y.Yoneyama 「.Netへ反映未」
    '更新日：
    '備　考：
    Private Sub prvGRBButtonCntrol()
    
        Dim llngCnt         As Integer

        Try    
            '@初期化
            cmdMoveGRB.Enabled = False
            cmdDelGRB.Enabled = False
    
            '@基板工程以外は対象外
            If pstrSBID <> CPstrSBID1A0 Then
                Exit Sub
            End If
    
            '@GRB選択無効は対象外
            If cmbDivideGrbSel.Enabled = False Then
                Exit Sub
            End If
    
            '@GRB選択ありは対象外
            If cmbDivideGrbSel.Value = CMstrGRBNoneSelect Then
                Exit Sub
            End If
    
            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                For llngCnt = 1 To .Rows.Count - 1
                    '@GRB一致
                    If .GetData(llngCnt, CMlngColGRB) = cmbDivideGrbSel.Value Then
                        '@分割元に該当GRBがある場合
                        cmdMoveGRB.Enabled = True
                        Exit For
                    End If
                Next
            End With
    
            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                For llngCnt = 1 To .Rows.Count - 1
                    '@GRB一致
                    If .GetData(llngCnt, CMlngColGRB) = cmbDivideGrbSel.Value Then
                        '@分割先に該当GRBがある場合
                        cmdDelGRB.Enabled = True
                        Exit For
                    End If
                Next
            End With
    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGRBButtonCntrol"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnGRB_Chk
    '機　能：GRBﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2019/12/19 (Thu) 19:22:24 Y.Yoneyama 「.Netへ反映未」
    '更新日：
    '備　考：
    Private Function prvblnGRB_Chk() As Boolean

        Dim llngCnt         As Integer
        Dim llngWFcnt       As Integer
        Dim llngGRBNullCnt  As Integer
        Dim lstrFirstGRB As String
        Dim lblnGRBMix      As Boolean
        Dim llngMsgAns      As Integer
    
        
        Try

            '@戻り値の初期化
            prvblnGRB_Chk = False
    
            '@基板専用
            If pstrSBID <> CPstrSBID1A0 Then
                prvblnGRB_Chk = True
            End If
    
            '@-----------------------
            '@NG条件
            '@WF.GRB=NULLとWF.GRB=ありの混在NG
            '@
            '@OK条件
            '@WF.GRB=NULL
            '@WF.GRB=あり(混在OK)
            '@-----------------------
    
            '@初期化
            llngWFcnt = 0
            llngGRBNullCnt = 0
            lstrFirstGRB = vbNullString
            lblnGRBMix = False
    
            '@-----------------------
            '@ 分割先のWF.GRBﾁｪｯｸ
            '@-----------------------
            With vsfSlotMap
                For llngCnt = 1 To .Rows.Count - 1
                    '@WFIDあり
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        '@WF数
                        llngWFcnt = llngWFcnt + 1
                
                        '@WF.GRB=NULL
                        If .GetData(llngCnt, CMlngColGRB) = vbNullString Then
                            llngGRBNullCnt = llngGRBNullCnt + 1
                        Else
                            '@最初のWF.GRBをSET
                            If lstrFirstGRB = vbNullString Then
                                lstrFirstGRB = .GetData(llngCnt, CMlngColGRB)
                            Else
                                '@WF.GRBが異なる場合は混在とする
                                If lstrFirstGRB <> .GetData(llngCnt, CMlngColGRB) Then
                                    lblnGRBMix = True
                                End If
                            End If
                        End If
                    End If
                Next
            End With
    
            '@全WF.GRB=NULL
            If llngWFcnt = llngGRBNullCnt Then
                prvblnGRB_Chk = True
                Exit Function
            End If
    
            '@WF.GRBありとWF.GRBなしの混在NG
            If lstrFirstGRB <> vbNullString And llngGRBNullCnt > 0 Then
        
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM169W>$$GRB設定あり/なしのウエハが混在しています。$設定を見直してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0169)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
        
                '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfSlotMapStck)
        
                prvblnGRB_Chk = False
                Exit Function
            End If

            '@WF.GRB単一
            If lstrFirstGRB <> vbNullString And lblnGRBMix = False Then
                prvblnGRB_Chk = True
                Exit Function
            End If

            '@WF.GRB混在の場合
            '@警告文を表示して終了(分割はOK)
            If lblnGRBMix = True Then
        
                '@"<TRM7UI>$$GRB設定の異なるウエハが混在しています。$よろしいですか？"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007U)
                llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
    
                '@結果確認
                If llngMsgAns = vbNo Then
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfSlotMapStck)
                    prvblnGRB_Chk = False
                Else
                    prvblnGRB_Chk = True
                End If
        
                Exit Function
            End If
    
            '@-----------------------
            '@ ここまで来ると想定外
            '@-----------------------
            '@"<TRM170W>$$$[%1]のGRB設定チェックで想定外のエラーが発生しました。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0170, Me.Text)
            llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
    
            prvblnGRB_Chk = False
    
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnGRB_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvGridGRBBackColorChange
    '機　能：グリッドのGRBセルの背景色変更
    '引　数：なし
    '戻り値：なし
    '作成日：2020/11/06
    '更新日：
    '備　考：
    Private Sub prvGridGRBBackColorChange()
    
        Dim intCnt  As Integer

        Try

            If lblLotGRB.Text = vbNullString Then
                Exit Sub
            End If

            '@-----------------------
            '@ 分割元ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMapStck
                For intCnt = 1 To .Rows.Count -1
                    Dim styleGRB As CellStyle = .Styles.Add("GRBColor" + intCnt.ToString)
                    styleGRB.BackColor = pubGRBBackColor(.GetData(intCnt, CMlngColGRB), .GetCellStyle(intCnt, CMlngColWFID).BackColor)
                    Dim cellGRB As CellRange = .GetCellRange(intCnt, CMlngColGRB)
                    cellGRB.Style = styleGRB
                Next
            End With

            '@-----------------------
            '@ 分割先ｽﾛｯﾄﾏｯﾌﾟ
            '@-----------------------
            With vsfSlotMap
                For intCnt = 1 To .Rows.Count -1
                    Dim styleGRB As CellStyle = .Styles.Add("GRBColor" + intCnt.ToString)
                    styleGRB.BackColor = pubGRBBackColor(.GetData(intCnt, CMlngColGRB), .GetCellStyle(intCnt, CMlngColWFID).BackColor)
                    Dim cellGRB As CellRange = .GetCellRange(intCnt, CMlngColGRB)
                    cellGRB.Style = styleGRB
                Next
            End With
    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGridGRBBackColorChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFromLot.Paint, fraToLot.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSlotMap.BeforeDoubleClick, vsfSlotMapStck.BeforeDoubleClick

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


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfSlotMap.KeyDownEdit, vsfSlotMapStck.KeyDownEdit

        With CType(sender, C1FlexGrid)
            '@'ｶﾚﾝﾄｾﾙがﾍｯﾀﾞｰ行でない場合
            If e.Row >= .Rows.Fixed Then
                Select Case e.KeyCode
                    Case Keys.Left  '[←]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが先頭の場合は、
                        '   左隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                    CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = 0 AndAlso editor.SelectionLength = 0)) Then
                            If .FinishEditing() = True Then
                                ' 左側で固定行直前まで移動可能なセルを探す
                                For lintCnt As Integer = .Col - 1 To .Cols.Fixed Step -1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                    Case Keys.Right '[→]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが末尾の場合は、
                        '   右隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = editor.Text.Length)) Then
                            If .FinishEditing() = True Then
                                ' 右側でグリッドの最後まで移動可能なセルを探す
                                For lintCnt As Integer = .Col + 1 To .Cols.Count - 1 Step 1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                End Select
            End If
        End With

    End Sub

    '関数名：flex_SetupEditor
    '機　能：グリッド内コンボボックス表示行数調整
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/11/14 (Thu) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlotMap.SetupEditor, vsfSlotMapStck.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles txtCarrier.Enter,
                                                                       txtToCarrier.Enter,
                                                                       cmdCarrierSelect.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdRegist.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '空きｷｬﾘｱ選択、閉じるボタンの場合は自動Validate = OFF
            Case "cmdCarrierSelect", "cmdClose"
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
                '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

    '関数名：vsfSlotMapStck_AfterScroll
    '機　能：グリッドスクロール時の動作
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/07/24 (Wed) 10:00:00 NSYS
    '備　考：
    Private Sub vsfSlotMapStck_AfterScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSlotMapStck.AfterScroll

        If Not IsNothing(Me.ActiveControl) Then
            If ActiveControl.Name = vsfSlotMapStck.Name Then
                vsfSlotMap.TopRow = vsfSlotMapStck.TopRow
            End If
        End If

    End Sub

    '関数名：vsfSlotMap_AfterScroll
    '機　能：グリッドスクロール時の動作
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/07/24 (Wed) 10:00:00 NSYS
    '備　考：
    Private Sub vsfSlotMap_AfterScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSlotMap.AfterScroll

        If Not IsNothing(Me.ActiveControl) Then
            If ActiveControl.Name = vsfSlotMap.Name Then
                vsfSlotMapStck.TopRow = vsfSlotMap.TopRow
            End If
        End If

    End Sub

End Class
