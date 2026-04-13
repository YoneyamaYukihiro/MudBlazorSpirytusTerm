'ﾌｧｲﾙ名：xxEN02T0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Aｷｬﾘｱ管理　メインフォーム
'作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
'更新日：2019/12/12 (Thu) 10:46:21 T.Oide
'備　考：
'　　　：
'Copyright(C)2003-2019, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02T0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02T0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02T0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02T0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02T0)
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
    'Private Const CMstrLocalVersion             As String = "01.02"
    Private Const CMstrLocalVersion             As String = "01.03"

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN02T0

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarracarstatVer          As String = "01.00"         'Aｷｬﾘｱ状態取得
    Private Const CMstrcarrchgatrayVer          As String = "01.00"         'AｷｬﾘｱAﾄﾚｲ情報変更
    Private Const CMstrAtray_list____Ver        As String = "01.00"         'AﾄﾚｰﾘｽﾄMsgVer
    Private Const CMstrcarrclean___Ver          As String = "01.00"         'ｷｬﾘｱ洗浄
    Private Const CMstrmas_pdlist__Ver          As String = "03.00"         '機種区分一覧取得
    Private Const CMstrmas_partlistVer          As String = "03.00"         '部材ﾘｽﾄ
    Private Const CMstrmas_definelistVer        As String = "01.00"         'DEFINE情報取得
    '@↓2019/11/25 (Mon) 10:39:24 T.Oide **************************************************
    'Private Const CMstrmas_invpartlistaldVer    As String = "01.00"         '在庫一覧取得(ALD_ﾓﾆﾀｰ用)
    Private Const CMstrmas_invpartlistaldVer    As String = "01.01"         '在庫一覧取得(ALD_ﾓﾆﾀｰ用)
    '@↑2019/11/25 (Mon) 10:39:24 T.Oide **************************************************

    '@vsfSlot定数宣言(ｶﾗﾑ)
    Private Const CMlngSlotColNo                As Integer = 0              'ｽﾛｯﾄNo
    Private Const CMlngSlotColATrayId           As Integer = 1              'ATRAYID
    Private Const CMlngSlotColATrayStatus       As Integer = 2              '状態
    Private Const CMlngSlotColATrayClass        As Integer = 3              '区分
    Private Const CMlngSlotColTapeGroup         As Integer = 4              'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Private Const CMlngSlotColALDCount          As Integer = 5              '使用回数
    Private Const CMlngSlotColALDLimit          As Integer = 6              '上限回数
    Private Const CMlngSlotColCleanCount        As Integer = 7              '洗浄回数
    Private Const CMlngSlotColCurrentClass      As Integer = 8              '区分(選択された物の区分)
    '@↓2019/11/26 (Tue) 16:38:33 T.Oide **************************************************
    '@Private Const CMlngSlotColInvLotId          As Long = 9                 '在庫ﾛｯﾄID
    '@Private Const CMlngSlotColBender            As Long = 10                'ベンダー
    '@Private Const CMlngSlotColProductionLotId   As Long = 11                '製造ﾛｯﾄID
    '@Private Const CMlngSlotColQty               As Long = 12                '数量
    '@↑2019/11/26 (Tue) 16:38:33 T.Oide **************************************************

    '@vsfSlot定数宣言(表示幅)
    Private Const CMlngSlotColWNo               As Integer = 33
    Private Const CMlngSlotColWATrayId          As Integer = 122       '3000
    Private Const CMlngSlotColWAtrayStatus      As Integer = 100       '3000
    Private Const CMlngSlotColWAtrayClasss      As Integer = 103       '3000
    Private Const CMlngSlotColWTapeGroup        As Integer = 129       '3000
    Private Const CMlngSlotColWALDCount         As Integer = 76        '1500
    Private Const CMlngSlotColWALDLimit         As Integer = 76        '1500
    Private Const CMlngSlotColWCleanCount       As Integer = 76        '1500
    Private Const CMlngSlotColWCurrentClass     As Integer = 76        '1500
    '@↓2019/11/26 (Tue) 16:45:36 T.Oide **************************************************
    '@Private Const CMlngSlotColWInvLotId         As Long = 3000
    '@Private Const CMlngSlotColWBender           As Long = 3000
    '@Private Const CMlngSlotColWProductionLotId  As Long = 3000
    '@Private Const CMlngSlotColWQty              As Long = 1545
    '@↑2019/11/26 (Tue) 16:45:36 T.Oide **************************************************

    '@vsfSlot定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrSlotColTNo               As String = ""
    Private Const CMstrSlotColTATrayId          As String = "AトレイID"
    Private Const CMstrSlotColTATrayStatus      As String = "状態"
    Private Const CMstrSlotColTATrayClass       As String = "区分"
    Private Const CMstrSlotColTTapeGroup        As String = "ﾃｰﾌﾟ貼ｸﾞﾙｰﾌﾟ"
    Private Const CMstrSlotColTALDCount         As String = "使用回数"
    Private Const CMstrSlotColTALDLimit         As String = "上限回数"
    Private Const CMstrSlotColTCleanCount       As String = "洗浄回数"
    Private Const CMstrSlotColTCurrentClass     As String = "現在区分"
    '@↓2019/11/26 (Tue) 16:45:42 T.Oide **************************************************
    '@Private Const CMstrSlotColTInvLotId         As String = "在庫ﾛｯﾄID"
    '@Private Const CMstrSlotColTBender           As String = "ベンダー"
    '@Private Const CMstrSlotColTProductionLotId  As String = "製造ロットID"
    '@Private Const CMstrSlotColTQty              As String = "数量"
    '@↑2019/11/26 (Tue) 16:45:42 T.Oide **************************************************

    '@↓2019/11/21 (Thu) 10:36:55 T.Oide **************************************************
    '@vsfInvList定数宣言(ｶﾗﾑ)
    Private Const CMlngInvListColNo             As Integer = 0              'No
    Private Const CMlngInvListColVenderClsId    As Integer = 1              'ﾍﾞﾝﾀﾞｰｸﾗｽID
    Private Const CMlngInvListColVenderClsName  As Integer = 2              'ﾍﾞﾝﾀﾞｰｸﾗｽ名
    Private Const CMlngInvListColVenderId       As Integer = 3              'ベンダーID
    Private Const CMlngInvListColVenderName     As Integer = 4              'ベンダー名
    Private Const CMlngInvListColPartCode       As Integer = 5              'ﾊﾟｰﾂｺｰﾄﾞ
    Private Const CMlngInvListColPartName       As Integer = 6              'ﾊﾟｰﾂ名
    Private Const CMlngInvListColLotId          As Integer = 7              '在庫ロット
    Private Const CMlngInvListColInvQty         As Integer = 8              '在庫数量
    Private Const CMlngInvListColUseQty         As Integer = 9              '使用数量
    Private Const CMlngInvListColProdcLotId     As Integer = 10             '製造ロット

    '@vsfInvList定数宣言(表示幅)
    Private Const CMlngInvListColWNo            As Integer = 32
    Private Const CMlngInvListColWVenderClsId   As Integer = 139
    Private Const CMlngInvListColWVenderClsName As Integer = 142
    Private Const CMlngInvListColWVenderId      As Integer = 124
    Private Const CMlngInvListColWVenderName    As Integer = 256
    Private Const CMlngInvListColWPartCode      As Integer = 96
    Private Const CMlngInvListColWPartName      As Integer = 207
    Private Const CMlngInvListColWLotId         As Integer = 133
    Private Const CMlngInvListColWInvQty        As Integer = 96
    Private Const CMlngInvListColWUseQty        As Integer = 96
    Private Const CMlngInvListColWProdcLotId    As Integer = 133

    '@vsfInvList定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrInvListColTNo            As String = "№"
    Private Const CMstrInvListColTVenderClsId   As String = "ﾍﾞﾝﾀﾞｰｸﾗｽID"
    Private Const CMstrInvListColTVenderClsName As String = "ﾍﾞﾝﾀﾞｰｸﾗｽ名"
    Private Const CMstrInvListColTVenderId      As String = "ベンダーID"
    Private Const CMstrInvListColTVenderName    As String = "ベンダー名"
    Private Const CMstrInvListColTPartCode      As String = "部材コード"
    Private Const CMstrInvListColTPartName      As String = "利用部材"
    Private Const CMstrInvListColTLotId         As String = "在庫ロット"
    Private Const CMstrInvListColTInvQty        As String = "在庫数量"
    Private Const CMstrInvListColTUseQty        As String = "使用数量"
    Private Const CMstrInvListColTProdcLotId    As String = "製造ロット"

    '@vsfSlot定数宣言(その他)
    Private Const CMvsfInvListCols              As Integer = 11            'ｶﾗﾑ数
    Private Const CMvsfInvListRows              As Integer = 1             '初期行数
    Private Const CMvsfInvUseMaxLen             As Integer = 5             '使用部材の最大桁数
    Private Const CMvsfInvHeight                As Integer = 25            '1ｽﾛｯﾄの高さ
    '@↑2019/11/21 (Thu) 10:36:55 T.Oide **************************************************

    '@vsfSlot定数宣言(その他)
    '@↓2019/11/26 (Tue) 16:48:48 T.Oide **************************************************
    '@Private Const CMvsfSlotCols                 As Long = 13                'ｶﾗﾑ数
    Private Const CMvsfSlotCols                 As Integer = 9             'ｶﾗﾑ数
    '@↑2019/11/26 (Tue) 16:48:48 T.Oide **************************************************
    Private Const CMvsfSlotRows                 As Integer = 16             '行数
    Private Const CMvsfSlotHHeight              As Integer = 21             'ﾍｯﾀﾞｰの高さ
    Private Const CMvsfSlotHeight               As Integer = 27             '1ｽﾛｯﾄの高さ
    Private Const CMvsfSlotTitleRow             As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMvsfSlotTFontSize            As Integer = 12             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfSlotFontSize             As Integer = 16             'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ

    '@vsfSlotの製品時の(大)ｻｲｽﾞ
    Private Const CMvsfSlotLargeHeight          As Integer = 429
    Private Const CMvsfSlotLargeTop             As Integer = 146

    '@vsfSlotのﾓﾆﾀｰ、ﾀﾞﾐｰ時の(小)ｻｲｽﾞ
    Private Const CMvsfSlotSmallHeight          As Integer = 185
    Private Const CMvsfSlotSmallTop             As Integer = 146

    '@利用部材ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngComboDispCols            As Integer = 2          '表示列数
    Private Const CMlngComboColPartCode         As Integer = 0          'PartCode列
    Private Const CMlngComboColPartName         As Integer = 1          'PartName列
    Private Const CMlngComboColVenderName       As Integer = 2          'VenderName列
    Private Const CMlngComboColPart             As Integer = 3          'PartCode + PartName列
    Private Const CMlngComboFontSize            As Integer = 16         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboGridFontSize        As Integer = 16         'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight           As Integer = 43         '行の高さ

    '@Aｷｬﾘｱ用途
    Private Const CMstrProduct                  As String = "0"         '製品(ﾓﾆﾀｰ無)
    Private Const CMstrProductWithMo            As String = "1"         '製品(ﾓﾆﾀｰ有)
    Private Const CMstrFillDummy                As String = "2"         'ﾀﾞﾐｰ(ﾓﾆﾀｰ無)
    Private Const CMstrFillDummyWithMo          As String = "3"         'ﾀﾞﾐｰ(ﾓﾆﾀｰ有)
    Private Const CMstrQuMo                     As String = "4"         '品確、ﾓﾆﾀ-

    Private Const CMstrEmptyFlagOn              As String = "空"
    Private Const CMstrEmptyFlagOff             As String = "積載"
    Private Const CMstrCleanFlagOn              As String = "要"
    Private Const CMstrCleanFlagOff             As String = "不要"

    '@Defineﾃｰﾌﾞﾙ定義
    Private Const CmstrAldMonitorCount          As String = "ALD_MONITOR_COUNT"     'ALDﾓﾆﾀｰ数(ｳｪﾊｰorﾁｯﾌﾟ)
    Private Const CmstrChipCount                As String = "CHIP_COUNT"            'ﾁｯﾌﾟ数

    '@ｴﾗｰ表示定数
    Private Const CMstrErr01                    As String = "重複"
    Private Const CMstrErr02                    As String = "空"
    Private Const CMstrErr03                    As String = "Aトレイ未選択"
    Private Const CMstrErr04                    As String = "区分不一致"
    Private Const CMstrErr05                    As String = "ﾃｰﾌﾟ貼ｸﾞﾙｰﾌﾟ空"
    Private Const CMstrErr06                    As String = "ﾃｰﾌﾟ貼ｸﾞﾙｰﾌﾟ不一致"
    Private Const CMstrErr07                    As String = "指定外登録"
    Private Const CMstrErr08                    As String = "使用不可"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '========================================Private========================================
    Private mtypACarrierState                   As ACarrierState        'Aｷｬﾘｱ状態格納構造体
    Private mtypAtrayList                       As typeAtrayList        'Aﾄﾚｰﾘｽﾄ
    Private mtypALDPartList                     As typALDPartList       '防湿膜ALD部材在庫情報
    Private mstrEventName                       As String               'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
    '@↓2019/11/25 (Mon) 16:35:27 T.Oide **************************************************
    '@Private mstrMoPd                            As String               'ﾓﾆﾀｰ機種
    '@Private mstrMoPdVer                         As String               'ﾓﾆﾀｰ機種Ver
    '@Private mstrQuPd                            As String               '品確機種
    '@Private mstrQuPdVer                         As String               '品確機種Ver
    '@Private mstrQuMoChipNum                     As String               '品確、ﾓﾆﾀｰのﾁｯﾌﾟ数
    '@↑2019/11/25 (Mon) 16:35:27 T.Oide **************************************************

    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean              'NSYS WindowCloseフラグ

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
    '========================================Private========================================

    '関数名：Form_Load
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02T0, CMstrLocalVersion)
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
            
            '@入力項目初期化
            txtACarrierId.Text = vbNullString
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN02T0_Init()
                
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try

            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
            
                '@〓 Enterｷｰ 〓
                Case Keys.Return
                
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                    
                        '@〓〓 ｷｬﾘｱID 〓〓
                        Case txtACarrierId.Name
                            
                            '@=======================
                            '@ AｷｬﾘｱIDﾃｷｽﾄValidate処理
                            '@=======================
                            RemoveHandler txtACarrierId.Validating, AddressOf txtACarrierId_Validate
                            Call txtACarrierId_Validate(sender, New CancelEventArgs(False))
                            AddHandler txtACarrierId.Validating, AddressOf txtACarrierId_Validate
                            e.Handled = True
                            
                        '@〓〓 ｷｬﾘｱID 〓〓
                        Case txtATrayId.Name
                            
                            '@=======================
                            '@ AﾄﾚｲDﾃｷｽﾄValidate処理
                            '@=======================
                            RemoveHandler txtATrayId.Validating, AddressOf txtATrayId_Validate
                            Call txtATrayId_Validate(sender, New CancelEventArgs(False))
                            AddHandler txtATrayId.Validating, AddressOf txtATrayId_Validate
                            e.Handled = True
                            
                        '@〓〓 その他 〓〓
                        Case Else
                        
                            If ActiveControl IsNot vsfInvList.Editor Then
                                vsfInvList.AllowEditing = False
                                vsfInvList.Col = 0
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                    
                    End Select
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyDown"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：2004/11/01 (Mon) 16:18:33 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
           
            '@ｸﾞﾛｰﾊﾞﾙな変数を初期化
            pstrLotID = vbNullString
            pstrCarrierID = vbNullString
            pblnMkEasyDivFlag = False
            pstrAtlasFlowNumber = vbNullString

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler  MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

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

    '@↓2019/11/21 (Thu) 10:16:12 T.Oide **************************************************
    '@'関数名：cmdVenderLot_Click
    '@'機　能：ﾍﾞﾝﾀﾞｰﾛｯﾄ選択画面表示
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2018/11/15 (Thu) 13:34:55 T.Oide
    '@'更新日：2018/11/15 (Thu) 13:34:55
    '@'備　考：
    '@Private Sub cmdVenderLot_Click()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
    '@    If Screen.MousePointer = vbHourglass Then
    '@        Exit Sub
    '@    End If
    '@
    '@    '@呼出元ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄｾｯﾄ
    '@    Set ptypPart.objParentFrom = frmxxEN02T0
    '@
    '@    '@Form_Loadﾌﾗｸﾞ(異常)
    '@    pblnFormLoad = False
    '@
    '@    '@ﾍﾞﾝﾀﾞｰﾛｯﾄ一覧表示
    '@    Load frmxxCM01C0
    '@
    '@    '@Form_Loadﾌﾗｸﾞが異常の場合
    '@    If pblnFormLoad = False Then
    '@        '@異常の場合は子画面終了
    '@        Unload frmxxCM01C0
    '@        Exit Sub
    '@    End If
    '@
    '@    '@ﾍﾞﾝﾀﾞｰﾛｯﾄ選択画面表示
    '@    Call frmxxCM01C0.Show(vbModal)
    '@
    '@    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID、在庫数が設定されている場合
    '@    If lblInvLotID.Caption <> vbNullString And _
    '@       IsNumeric(lblInvNum.Caption) = True Then
    '@
    '@        '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ解除
    '@        vsfSlot.Enabled = True
    '@    Else
    '@        '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
    '@        vsfSlot.Enabled = False
    '@
    '@    End If
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "cmdVenderLot_Click"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2019/11/21 (Thu) 10:16:12 T.Oide **************************************************

    '関数名：cmdATrayClear_Click
    '機　能：ATRAY紐付き解除
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub cmdATrayClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdATrayClear.Click

        Dim ltypACarrierState   As ACarrierState
        Dim lblnAns             As Boolean
        Dim ltypALDPartList     As typALDPartList   '防湿膜ALD部材情報(初期化用)
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdATrayClear_Click"
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@品確・ﾓﾆﾀｰの解除か
            If optClass4.Checked = True Then
                
                '@品確、ﾓﾆﾀｰの場合、紐付いている部材は、解除で
                ' 自動的には在庫に戻らないため、手動で戻すようにﾒｯｾｰｼﾞを表示する
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007R)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            '@送信ﾃﾞｰﾀ作成
            ltypACarrierState.strACarrierId = txtACarrierId.Text
            ltypACarrierState.strACarrierClass = vbNullString
            ltypACarrierState.lngATrayListCnt = 0
            
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@Msg送信処理実行
            lblnAns = pubblnACarrierChangeATray_Upd(CMstrcarrchgatrayVer, ltypACarrierState)
            
            '@結果判定
            If lblnAns = True Then
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0065, txtACarrierId.Text)
                '@"<TRM65I>$$Ａキャリア[%1]の全Ａトレイを取外しました。"
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@画面の初期化
                Call prvfrmxxEN02T0_Init()
                
                '@再ロード
                txtACarrierId.Text = ltypACarrierState.strACarrierId
                Call txtACarrierId_Validate(sender, New CancelEventArgs(True))
                
            Else

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            
            End If

            '@在庫情報を取直したいので持っている情報をﾘｾｯﾄ
            mtypALDPartList = ltypALDPartList

            '@ﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtACarrierId)
            
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
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
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

            '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@親ﾌｫｰﾑから呼ばれた場合
                '@親画面切り替え引継ぎ制御
                Call pubChangeScreen_Set(Me)
            Else
            '@空白の場合
                '@終了関数を実行する
                Call publngEnd_Proc(CPstrKeyEN02T0, ltypCommonInfo)
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

    '関数名：optClass_Click
    '機　能：用途変更
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub optClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optClass0.CheckedChanged,
                                                                                     optClass1.CheckedChanged,
                                                                                     optClass2.CheckedChanged,
                                                                                     optClass3.CheckedChanged,
                                                                                     optClass4.CheckedChanged
        
        Dim llngGrayRows        As Integer
        Dim ltypALDPartList     As typALDPartList       '防湿膜ALD部材情報(初期化用)
        Dim lblnAns             As Boolean
        Dim lindex              As Integer              'NSYS Index取得用
        Dim llngDoCnt           As Integer              'NSYS ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngDoCnt2          As Integer              'NSYS ﾙｰﾌﾟｶｳﾝﾄ
        
        Try

            'NSYS FALSEは処理を抜ける
            If sender.Checked = False Then
                Exit Sub
            End If
            
            mstrEventName = "ptClass_Click"
            
            With vsfSlot
            
                .Redraw = False

                '@背景色(白)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                Dim cellRange As CellRange = .GetCellRange(1, CMlngSlotColATrayId, .Rows.Count - 1, .Cols.Count - 1)
                cellRange.Style = newStyle
                '@区分
                llngDoCnt = 1
                Do While .Rows.Count - 1 >= llngDoCnt
                    llngDoCnt2 = 1
                    Do While .Cols.Count - 1 >= llngDoCnt2
                        .SetData(llngDoCnt, llngDoCnt2, vbNullString)
                        llngDoCnt2 = llngDoCnt2 + 1
                    Loop
                   llngDoCnt = llngDoCnt + 1
                Loop

                lindex = Cint(Mid(sender.Name.ToString, sender.Name.ToString.Length))

                Select Case CStr(lindex)
            
                    Case CMstrProduct
                        llngGrayRows = 2
                        llngDoCnt = 1
                        Do While .Rows.Count - 1 - llngGrayRows >= llngDoCnt
                            .SetData(llngDoCnt, CMlngSlotColATrayClass, CPstrSpecUseProductName)
                            llngDoCnt = llngDoCnt + 1
                        Loop

                    Case CMstrProductWithMo
                        llngGrayRows = 3
                        llngDoCnt = 1
                        Do While .Rows.Count - 1 - llngGrayRows >= llngDoCnt
                            .SetData(llngDoCnt, CMlngSlotColATrayClass, CPstrSpecUseProductName)
                            llngDoCnt = llngDoCnt + 1
                        Loop
                    
                    Case CMstrFillDummy
                        llngGrayRows = 2
                        llngDoCnt = 1
                        Do While .Rows.Count - 1 - llngGrayRows >= llngDoCnt
                            .SetData(llngDoCnt, CMlngSlotColATrayClass, CPstrSpecUseDummyName)
                            llngDoCnt = llngDoCnt + 1
                        Loop
                
                    Case CMstrFillDummyWithMo
                        llngGrayRows = 3
                        llngDoCnt = 1
                        Do While .Rows.Count - 1 - llngGrayRows >= llngDoCnt
                            .SetData(llngDoCnt, CMlngSlotColATrayClass, CPstrSpecUseDummyName)
                            llngDoCnt = llngDoCnt + 1
                        Loop
                        
                    Case CMstrQuMo
                        
        '@↓2018/12/05 (Wed) 15:18:30 T.Oide **************************************************
        '@                llngGrayRows = 11
        '@
        '@
        '@                .Cell(flexcpText, 1, CMlngSlotColATrayClass, 1, CMlngSlotColATrayClass) = CPstrSpecUseDummyName
        '@                .Cell(flexcpText, 2, CMlngSlotColATrayClass, .Rows - 1 - llngGrayRows, CMlngSlotColATrayClass) = CPstrSpecUseMonitorName
        '@
        '@                '@ﾀﾞﾐｰ行の「在庫ﾛｯﾄID」～「数量」灰色(1行目のみ)
        '@                .Cell(flexcpBackColor, 1, CMlngSlotColInvLotId, 1, CMlngSlotColQty) = CPlngGridGray
        '@-------------------------------------------------------------------------------------
        '@※15ｽﾛｯﾄをﾀﾞﾐｰ入りに戻す場合は、上記を有効にする

                        llngGrayRows = 12

                        llngDoCnt = 1
                        Do While .Rows.Count - 1 - llngGrayRows >= llngDoCnt
                            .SetData(llngDoCnt, CMlngSlotColATrayClass, CPstrSpecUseMonitorName)
                            llngDoCnt = llngDoCnt + 1
                        Loop

        '@↑2018/12/05 (Wed) 15:18:30 T.Oide **************************************************
          
        '@↓2019/11/21 (Thu) 15:21:12 T.Oide **************************************************
        '@                '@ﾓﾆﾀｰ、ﾀﾞﾐｰ機種の一覧を取得して変数(mstrMoPd,mstrQuPd)に格納する
        '@                If prvGetMoQuPd = False Then
        '@                    Exit Sub
        '@                End If
        '@
        '@                '@部材の一覧を取得する
        '@                If prvGetInventry(Index) = False Then
        '@                    Exit Sub
        '@                End If
        '@
        '@                '@ﾁｯﾌﾟ使用数を取得する
        '@                If prvGetChipNum = False Then
        '@                    Exit Sub
        '@                End If
        '@↑2019/11/21 (Thu) 15:21:12 T.Oide **************************************************
                        
                    Case Else
                        Exit Sub
                        
                End Select

                '@ｸﾞﾘｯﾄﾞｻｲｽﾞ設定
                Call prvvsfSlotSizeSet(lindex)

                '@背景色(灰色)
                Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                newStyle2.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                Dim cellRange2 As CellRange = .GetCellRange(.Rows.Count - llngGrayRows, CMlngSlotColATrayId, .Rows.Count - 1, .Cols.Count - 1)
                cellRange2.Style = newStyle2
                
                .Redraw = True

            End With
                
            '@=======================
            '@ QU/MO用の部材ﾘｽﾄを取得
            '@=======================
            '@QU,MOのﾁｪｯｸONか
            If optClass4.Checked = True Then
                
                '@Aﾄﾚｰに部材の紐付けはあるか
                If mtypACarrierState.typAtrayUsePart.lngAldPartCnt = 0 Then
                    
                    '@部材ﾘｽﾄは取得済か
                    If mtypALDPartList.lngAldPartCnt = 0 Then
                    
                        '@部材の在庫情報を取得する
                        mtypALDPartList = ltypALDPartList
                        lblnAns = pubblnPartListAld_Sel(CMstrmas_invpartlistaldVer, mtypALDPartList)
                    
                        '@結果確認
                        If lblnAns = False Then
                            '@失敗の場合、ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, mstrEventName)
                            Exit Sub
                        End If
                
                    End If
                    
                    '@部材の在庫情報を表示
                    Call prvInvList_Disp(mtypALDPartList, True)
                
                Else

                    '@使用した部材情報を表示
                    Call prvInvList_Disp(mtypACarrierState.typAtrayUsePart, False)
                
                End If
                
            End If
            
            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvEnable_Chk()
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optClass_Click"
                .strErrMessage = vbNullString
            End With
            
        End Try
    End Sub

    '関数名：txtACarrierId_Change
    '機　能：ｷｬﾘｱ変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub txtACarrierId_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtACarrierId.Change
        
        Try
                
            '@検索ﾃﾞｰﾀがある場合
            If mtypACarrierState.strACarrierId <> vbNullString Then
                '@=======================
                '@　画面情報初期化処理
                '@=======================
                Call prvfrmxxEN02T0_Init()
                Exit Sub
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

    '関数名：txtACarrierId_Validate
    '機　能：ｷｬﾘｱIDのValidateｲﾍﾞﾝﾄ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub txtACarrierId_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtACarrierId.Validating

        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim ltypACarrierState       As ACarrierState    'Aｷｬﾘｱ状態格納構造体
        Dim ltypAtrayList           As typeAtrayList    'Aﾄﾚｰﾘｽﾄ
        
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If


            '@ｷｬﾘｱIDがない場合は抜ける
            If txtACarrierId.Text = vbNullString Then
                Exit Sub
            End If
            
            '@ﾒﾝﾊﾞｰ変数比較
            If mtypACarrierState.strACarrierId = txtACarrierId.Text Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtACarrierId.NowByte <> txtACarrierId.ChrMaxByte Then
            
                '@検索ﾃﾞｰﾀが無い場合
                If mtypACarrierState.strACarrierId = vbNullString Then
                    Exit Sub
                End If
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ移動
                Call pubSetFocus(txtACarrierId)
                
                '@再入力
                e.Cancel = True
                
                Exit Sub
            End If

            '@砂時計表示
            Cursor.Current = Cursors.WaitCursor

            '@ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名格納
            mstrEventName = "txtACarrierId_Validate"

            '@ﾚｽﾎﾟﾝｽ測定開始
            Call pubResponseStart(Me.Name, mstrEventName)

            '@=======================
            '@ Aｷｬﾘｱ状態取得
            '@=======================
            mtypACarrierState = ltypACarrierState
            lblnAns = pubblnACarrierStatus_Sel(CMstrcarracarstatVer, txtACarrierId.Text, mtypACarrierState)

            '@結果確認
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(Me.Name, mstrEventName)
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            '@Aｷｬﾘｱ情報を表示
            Call prvACarrier_Disp                       'ﾍｯﾀﾞｰ情報表示(Aﾄﾚｲが紐付く場合ｸﾞﾘｯﾄﾞの区分だけ表示)
            Call prvVsfSlot_Disp(mtypACarrierState)     '紐付くAﾄﾚｲ情報表示

            '@=======================
            '@ 利用可能Aﾄﾚｲ一覧取得
            '@=======================
            '@Aﾄﾚｰは取得済ではないか
            If mtypAtrayList.lngAtraytListCnt = 0 Then
                mtypAtrayList = ltypAtrayList
                lblnAns = pubblnAtrayAvailableList_Sel(CMstrAtray_list____Ver, mtypAtrayList)
            
                '@結果確認
                If lblnAns = False Then
                    '@失敗の場合、ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
            End If
            
            '@ﾎﾞﾀﾝ有効/無効制御
            Call prvEnable_Chk()

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)
            Cursor.Current = Cursors.Default

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtACarrierId_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtATrayId_Validate
    '機　能：ｷｬﾘｱIDのValidateｲﾍﾞﾝﾄ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub txtATrayId_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtATrayId.Validating

        Dim llngRowCnt  As Integer
        Dim lblnInsert  As Boolean
        Dim rowColEv As RowColEventArgs
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If


            '@AﾄﾚｲIDがない場合は抜ける
            If txtATrayId.Text = vbNullString Then
                Exit Sub
            End If
            
            With vsfSlot
            
                '@SLOT無効の場合
                If .Enabled = False Then
                    Exit Sub
                End If
                
                '@入力判定初期
                lblnInsert = False
                
                '@SLOTの上よりAﾄﾚｲ入力
                For llngRowCnt = 1 To .Rows.Count - 1
                        
                    '@背景色(白)&ATrayがNULL
                    If .GetCellRange(llngRowCnt, CMlngSlotColATrayId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) And _
                        .GetData(llngRowCnt, CMlngSlotColATrayId) = vbNullString Then
                    
                        '@ATrayId入力
                        .SetData(llngRowCnt, CMlngSlotColATrayId, Trim(txtATrayId.Text))
                        
                        '@編集確定
                        rowColEv = New RowColEventArgs(llngRowCnt, CMlngSlotColATrayId)
                        Call vsfSlot_AfterEdit(llngRowCnt, rowColEv)
                        
                        lblnInsert = True
                        Exit For
                    End If
                Next
            End With
            
            '@入力出来なかった場合
            If lblnInsert = False Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0032, txtATrayId.Text)
                '@"<TRM32W>$$AトレイID「%1」は入力できませんでした。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

            End If
            
            txtATrayId.Text = vbNullString

            '@ﾌｫｰｶｽ移動
            Call pubSetFocus(txtATrayId)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtATrayId_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlot_AfterEdit
    '機　能：ｽﾛｯﾄ変更後処理
    '引　数：行 Row 列 Col
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub vsfSlot_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlot.AfterEdit
        
        Dim llngCnt     As Integer
        Dim llngRowCnt  As Integer
        Dim lblnFind    As Boolean

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlot.Rows.Count <= vsfSlot.Rows.Fixed Then
                Return
            End If
            
            With vsfSlot
            
                '@ATrayIdが空の場合はﾁｪｯｸをﾊﾟｽ
                '@空以外か
                If .GetData(e.Row, CMlngSlotColATrayId) <> vbNullString Then
                
                    '@ATrayId重複ﾁｪｯｸ
                    For llngRowCnt = 1 To .Rows.Count - 1
                        If llngRowCnt <> e.Row Then
                            If .GetData(llngRowCnt, CMlngSlotColATrayId) = .GetData(e.Row, CMlngSlotColATrayId) Then
                        
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037, .GetData(e.Row, CMlngSlotColATrayId), CMstrErr01)
                                '@"<TRM37W>$$AトレイID[%1] 理由[%2]$$設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                                '@入力値ｸﾘｱ
                                .SetData(e.Row, CMlngSlotColATrayId, vbNullString)
                                '@ﾌｫｰｶｽｾｯﾄ
                                'Call pubSetFocus(txtATrayId)
                                .Col = .Col + 1
                                .AllowEditing = False
                                
                                Exit Sub
                            End If
                        End If
                    Next
            
                    '@構造体から該当ATray情報を探して表示
                    lblnFind = False
                    For llngCnt = 0 To mtypAtrayList.lngAtraytListCnt - 1
                        If mtypAtrayList.typAtraytList(llngCnt).strAtrayId = .GetData(e.Row, CMlngSlotColATrayId) Then
                    
                            .SetData(e.Row, CMlngSlotColATrayStatus, mtypAtrayList.typAtraytList(llngCnt).strAtrayStatusName)
                            .SetData(e.Row, CMlngSlotColTapeGroup, mtypAtrayList.typAtraytList(llngCnt).strTapeStickGr)
                            .SetData(e.Row, CMlngSlotColALDCount, mtypAtrayList.typAtraytList(llngCnt).strWashUseNum)
                            .SetData(e.Row, CMlngSlotColALDLimit, mtypAtrayList.typAtraytList(llngCnt).strWashUseLimit)
                            .SetData(e.Row, CMlngSlotColCleanCount, mtypAtrayList.typAtraytList(llngCnt).strCleanCount)
                            .SetData(e.Row, CMlngSlotColCurrentClass, mtypAtrayList.typAtraytList(llngCnt).strAtrayClass)
                            
                            lblnFind = True
                            Exit For
                        End If
                    Next
                    
                    '@構造体の中にATray登録情報が無い場合ﾒｯｾｰｼﾞを表示
                    If lblnFind = False Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037, .GetData(e.Row, CMlngSlotColATrayId), CMstrErr08)
                        '@"<TRM37W>$$AトレイID[%1] 理由[%2]$$設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@入力値ｸﾘｱ
                        .SetData(e.Row, CMlngSlotColATrayId, vbNullString)
                        
                        '@ﾌｫｰｶｽｾｯﾄ
                        'Call pubSetFocus(txtATrayId)
                        .Col = .Col + 1
                        .AllowEditing = False
                        
                        Exit Sub
                    End If
                    
                End If
            End With
            
            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvEnable_Chk()
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlot_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlot_BeforeEdit
    '機　能：編集前にAtrayのｺﾝﾎﾞﾘｽﾄ作成
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2018/11/20 (Tue) 10:39:54 T.Oide
    '更新日：2019/12/09 (Mon) 13:22:40 T.Oide
    '備　考：
    Private Sub vsfSlot_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlot.BeforeEdit

        Dim strClass        As String

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlot.Rows.Count <= vsfSlot.Rows.Fixed Then
                Return
            End If

            With vsfSlot
                Select Case .GetData(.Row, CMlngSlotColATrayClass)
                    
                    '@製品の場合
                    Case CPstrSpecUseProductName
                        strClass = CPstrUseIDProduct
                    
                    '@モニタの場合
                    Case CPstrSpecUseMonitorName
                        strClass = CPstrUseIDMonitor
                    
                    '@ダミーの場合
                    Case CPstrSpecUseDummyName
                        strClass = CPstrUseIDDummy
                    Case Else
                        strClass = vbNullString
                End Select
                
                '@ｸﾞﾘｯﾄﾞｺﾝﾎﾞ作成
                .Cols(CMlngSlotColATrayId).ComboList = prvstrATrayCombList_Set(strClass)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlot_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlot_ChangeEdit
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2019/12/09 (Mon) 13:22:51 T.Oide
    '更新日：2019/12/09 (Mon) 13:22:51
    '備　考：
    Private Sub vsfSlot_ChangeEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlot.ChangeEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlot.Rows.Count <= vsfSlot.Rows.Fixed Then
                Return
            End If
            
            '@ｶﾗﾑにより分岐
            Select Case vsfSlot.Col
            
                Case CMlngSlotColATrayId
                    '@[RIGHT]ｷｰ押下
                    Call SendKeys.Send(CPstrSendKeysRight)
                    
            End Select
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlot_ChangeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '@↓2019/12/09 (Mon) 13:32:00 T.Oide **************************************************
    '@'関数名：vsfSlot_KeyPress
    '@'機　能：ｽﾛｯﾄ制御
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '@'更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '@'備　考：
    '@Private Sub vsfSlot_KeyPress(KeyAscii As Integer)
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ｸﾞﾘｯﾄﾞの編集制御
    '@    Call prvInvLotSet
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "vsfSlot_KeyPress"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2019/12/09 (Mon) 13:32:00 T.Oide **************************************************

    '@↓2019/12/09 (Mon) 13:32:24 T.Oide **************************************************
    '@'関数名：vsfSlot_Click
    '@'機　能：ｽﾛｯﾄ制御
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '@'更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '@'備　考：
    '@Private Sub vsfSlot_Click()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ｸﾞﾘｯﾄﾞの編集制御
    '@    Call prvInvLotSet
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "vsfSlot_Click"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2019/12/09 (Mon) 13:32:24 T.Oide **************************************************

    '関数名：vsfSlot_EnterCell
    '機　能：SLOT入力制御
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub vsfSlot_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlot.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlot.Rows.Count <= vsfSlot.Rows.Fixed Then
                Return
            End If


            With vsfSlot

                '@ﾍｯﾀﾞの場合
                If .Row < .Rows.Fixed Or .Col < .Cols.Fixed Then
                    Exit Sub
                End If

                Select Case .Col

                    '@ATRAY_ID
                    Case CMlngSlotColATrayId

                        '@背景色(白)
                        If .GetCellRange(.Row, CMlngSlotColATrayId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                            '@編集可能
                            .AllowEditing = True
                        Else
                            '@編集不可
                            .AllowEditing = False
                        End If

                    '@その他
                    Case Else

                        '@編集不可
                        .AllowEditing = False

                End Select

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlot_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfInvList_AfterEdit
    '機　能：使用数量が適正がﾁｪｯｸ
    '引　数：Row：
    '　　　：Col：
    '戻り値：なし
    '作成日：2019/12/12 (Thu) 10:46:21 T.Oide
    '更新日：2019/12/12 (Thu) 10:46:21 T.Oide
    '備　考：
    Private Sub vsfInvList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfInvList.AfterEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvList.Rows.Count <= vsfInvList.Rows.Fixed Then
                Return
            End If

            With vsfInvList

                '@編集後の値は数値か
                If IsNumeric(.GetData(e.Row, e.Col)) = False Then

                    '@ﾒｯｾｰｼﾞ表示(<TRM7QW>$$数値を入力して下さい)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Q)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    .SetData(e.Row, e.Col, CPlngNumZero)
                    Exit Sub
                End If

                '@整数か
                If CDbl(.GetData(e.Row, e.Col)) - CDbl(Fix(.GetData(e.Row, e.Col))) <> 0 Then

                    '@ﾒｯｾｰｼﾞ表示("<TRM7PS>$$少数は入力できません。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007S)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    .SetData(e.Row, e.Col, CPlngNumZero)
                    Exit Sub
                End If

                '@0以上か
                If CDbl(.GetData(e.Row, e.Col)) < 0 Then

                    '@ﾒｯｾｰｼﾞ表示("<TRM7PT>$$マイナスは入力できません。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007T)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    .SetData(e.Row, e.Col, CPlngNumZero)
                    Exit Sub
                End If


                '@使用数量が在庫数を超えていないか
                If CLng(.GetData(e.Row, e.Col)) > CLng(.GetData(e.Row, CMlngInvListColInvQty)) Then

                    '@ﾒｯｾｰｼﾞ表示(<TRM73I>$$在庫数以上の設定はできません。)
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0073)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    .SetData(e.Row, e.Col, CPlngNumZero)
                    Exit Sub
                End If

                '@先頭0にならない対策
                .SetData(e.Row, e.Col, CLng(.GetData(e.Row, e.Col)))

            End With

            '@ﾎﾞﾀﾝ有効/無効制御
            Call prvEnable_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfInvList_BeforeEdit
    '機　能：編集前処理(EditMaxLength設定)
    '引　数：Row：
    '　　　：Col：
    '　　　：Cancel：
    '戻り値：
    '作成日：2019/11/25 (Mon) 17:13:07 T.Oide
    '更新日：2019/11/25 (Mon) 17:13:07
    '備　考：
    Private Sub vsfInvList_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfInvList.BeforeEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvList.Rows.Count <= vsfInvList.Rows.Fixed Then
                Return
            End If
            
            '@使用数の最大値を5桁にする(使用数しか編集出来ないので特に列の設定はしていない)
            'CType(vsfInvList.Editor, TextBox).MaxLength = CMvsfInvUseMaxLen

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvList_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfInvList_EnterCell
    '機　能：利用部材ｸﾞﾘｯﾄﾞ入力制御
    '引　数：なし
    '戻り値：なし
    '作成日：2019/11/25 (Mon) 15:53:10 T.Oide
    '更新日：2019/11/25 (Mon) 15:53:10
    '備　考：
    Private Sub vsfInvList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfInvList.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvList.Rows.Count <= vsfInvList.Rows.Fixed Then
                Return
            End If

            With vsfInvList

                '@ﾍｯﾀﾞの場合
                If .Row < .Rows.Fixed Or .Col < .Cols.Fixed Then
                    Exit Sub
                End If

                '@列で分岐
                Select Case .Col

                    '@使用数量
                    Case CMlngInvListColUseQty

                        .Styles.Editor.BackColor = SystemColors.Window
                        .Styles.Editor.ForeColor = SystemColors.WindowText
                        .AllowEditing = True

                    '@その他
                    Case Else

                        '@編集不可
                        .AllowEditing = False

                End Select

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2019/11/21 (Thu) 10:09:36 T.Oide **************************************************
    '@'関数名：cmbPartName_Change
    '@'機　能：利用部材ﾘｽﾄ選択
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2018/11/15 (Thu) 14:24:50 T.Oide
    '@'更新日：2018/11/15 (Thu) 14:24:50
    '@'備　考：
    '@Private Sub cmbPartName_Change()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With cmbPartName
    '@        '@一致した文字列に対応するIDを構造体にｾｯﾄする
    '@        .ValueCol = CMlngComboColPartName       '部材名列
    '@        ptypPart.strPartName = .Value           '利用部材
    '@
    '@        .ValueCol = CMlngComboColPartCode       '部材ｺｰﾄﾞ列
    '@        ptypPart.strPartCode = .Value           '部材ｺｰﾄﾞ
    '@
    '@        .ValueCol = CMlngComboColVenderName     'ﾍﾞﾝﾀﾞｰ名列
    '@        lblVenderName.Caption = .Value          'ﾍﾞﾝﾀﾞｰ名
    '@        ptypPart.strVenderName = .Value         'ﾍﾞﾝﾀﾞｰ名
    '@
    '@        '@ﾍﾞﾝﾀﾞｰﾛｯﾄID削除
    '@        lblInvLotID.Caption = vbNullString
    '@
    '@        '@製造ﾛｯﾄID削除
    '@        lblProductionLotID.Caption = vbNullString
    '@
    '@        '@在庫数削除
    '@        lblInvNum.Caption = vbNullString
    '@
    '@        .ValueCol = CMlngComboColPartCode
    '@        If .Value <> vbNullString Then
    '@            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID選択ﾎﾞﾀﾝ表示
    '@            cmdVenderLot.Enabled = True
    '@        Else
    '@            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID選択ﾎﾞﾀﾝ表示
    '@            cmdVenderLot.Enabled = False
    '@        End If
    '@    End With
    '@
    '@    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID、在庫数が設定されている場合
    '@    If lblInvLotID.Caption <> vbNullString And _
    '@       IsNumeric(lblInvNum.Caption) = True Then
    '@
    '@        '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ解除
    '@        vsfSlot.Enabled = True
    '@    Else
    '@        '@ｽﾛｯﾄﾏｯﾌﾟのﾛｯｸ
    '@        vsfSlot.Enabled = False
    '@
    '@    End If
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "cmbPartName_Change"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2019/11/21 (Thu) 10:09:36 T.Oide **************************************************

    '@↓2019/11/21 (Thu) 10:11:12 T.Oide **************************************************
    '@'関数名：cmbPartName_CloseUp
    '@'機　能：利用部材ﾘｽﾄ選択
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2018/11/15 (Thu) 14:25:13 T.Oide
    '@'更新日：2018/11/15 (Thu) 14:25:13
    '@'備　考：
    '@Private Sub cmbPartName_CloseUp()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With cmbPartName
    '@        '@一致した文字列に対応するIDを構造体とﾗﾍﾞﾙにｾｯﾄする
    '@        .ValueCol = CMlngComboColPartName
    '@        ptypPart.strPartName = .Value        '利用部材
    '@
    '@        .ValueCol = CMlngComboColPartCode
    '@        ptypPart.strPartCode = .Value        '部材ｺｰﾄﾞ
    '@
    '@        .ValueCol = CMlngComboColVenderName
    '@        lblVenderName.Caption = .Value       'ﾍﾞﾝﾀﾞｰ名
    '@        ptypPart.strVenderName = .Value      'ﾍﾞﾝﾀﾞｰ名
    '@    End With
    '@
    '@    With cmbPartName
    '@        .ValueCol = CMlngComboColPartCode
    '@        '@部材ｺｰﾄﾞﾁｪｯｸ
    '@        If .Value <> vbNullString Then
    '@            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID選択ﾎﾞﾀﾝ表示
    '@            cmdVenderLot.Enabled = True
    '@
    '@            '@次項目にﾌｫｰｶｽｾｯﾄ
    '@            Call pubSetFocus(cmdVenderLot)
    '@        Else
    '@            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID選択ﾎﾞﾀﾝ表示
    '@            cmdVenderLot.Enabled = False
    '@        End If
    '@    End With
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "cmbPartName_CloseUp"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2019/11/21 (Thu) 10:11:12 T.Oide **************************************************

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim ltypACarrierState   As ACarrierState
        Dim lblnAns             As Boolean

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

            '@確定情報ﾁｪｯｸ&登録ﾃﾞｰﾀ格納
            lblnAns = prvblnRegist_Chk(ltypACarrierState)
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdUseChange_Click"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@Msg送信処理実行
            lblnAns = pubblnACarrierChangeATray_Upd(CMstrcarrchgatrayVer, ltypACarrierState)

            '@結果判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005B)
                '@"<TRM5BI>$$キャリア情報を更新しました。"
                Call pubVsfInfo_Disp(pstrDMsg)

                '@画面の初期化
                Call prvfrmxxEN02T0_Init()

                '@再ロード
                Call txtACarrierId_Validate(sender, New CancelEventArgs(True))

            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If

            '@ﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtACarrierId)

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

    '関数名：cmdCarrierSelect_Click
    '機　能：空きキャリア一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/22 (Thu) 13:41:30 T.Oide
    '更新日：2018/11/22 (Thu) 13:41:30
    '備　考：
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click

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
            
            '@移載先ｷｬﾘｱID保存
            pstrCarrierID = txtACarrierId.Text
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し
            pstrCarrierTypeID = CPstrCarrTypeA
            
            '@未洗浄可
            pstrCleanCondition = CPstrCarrierClean1
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00E0.Instance = New frmxxCM00E0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00E0.Instance = Nothing
                Exit Sub
            End If
            
            '@ｷｬﾘｱ一覧表示
            frmxxCM00E0.Instance.ShowDialog(Me)
            frmxxCM00E0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@ｷｬﾘｱIDをｾｯﾄ
                txtACarrierId.Text = pstrCarrierID
                
                '@ｷｬﾘｱの情報取得
                txtACarrierId_Validate (sender, New CancelEventArgs(False))
            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdScanClear_Click
    '機　能：SCAN全取消
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub cmdScanClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScanClear.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@選択区分を確定
            If optClass0.Checked = True Then
                '@選択区分を使って初期化
                Call optClass_Click(optClass0, e)
            End If
            If optClass1.Checked = True Then
                '@選択区分を使って初期化
                Call optClass_Click(optClass1, e)
            End If
            If optClass2.Checked = True Then
                '@選択区分を使って初期化
                Call optClass_Click(optClass2, e)
            End If
            If optClass3.Checked = True Then
                '@選択区分を使って初期化
                Call optClass_Click(optClass3, e)
            End If
            If optClass4.Checked = True Then
                '@選択区分を使って初期化
                Call optClass_Click(optClass4, e)
            End If
            
            '@ﾌｫｰｶｽ移動
            Call pubSetFocus(txtATrayId)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScanClear_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierClean_Click
    '機　能：ｷｬﾘｱ指定洗浄ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：
    '作成日：2018/12/10 (Mon) 12:55:17 T.Oide
    '更新日：2018/12/10 (Mon) 12:55:17
    '備　考：
    Private Sub cmdCarrierClean_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierClean.Click
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

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
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdCarrierClean_Click"
            Call pubResponseStart(Me.Name, mstrEventName)

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnCarrClean_Upd(CMstrcarrclean___Ver, txtACarrierId.Text, pstrUserID)
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000C, txtACarrierId.Text)
                '@成功ﾒｯｾｰｼﾞ表示
                '@pubVsfInfo_Disp("C_I0C%0$$キャリア[%1]の洗浄を完了しました。$いつでも利用可能です。")
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ｷｬﾘｱID格納（親画面に引継ぎ）
                pstrCarrierID = txtACarrierId.Text
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
                
                '@画面を閉じる
                frmxxCM00C1.Instance = Nothing
            
                '@画面の初期化
                Call prvfrmxxEN02T0_Init()
                
                '@再ロード
                Call txtACarrierId_Validate(sender, New CancelEventArgs(True))
            
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                '@ｷｬﾘｱﾀｲﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtACarrierId)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierClean_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '========================================Private========================================
    '関数名：prvfrmxxEN02T0_Init
    '機　能：各ｵﾌﾞｼﾞｪｸﾄの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2019/12/06 (Fri) 11:33:33 T.Oide
    '備　考：
    Private Sub prvfrmxxEN02T0_Init()

        Dim lstrFormTitle       As String = Nothing
        Dim ltypACarrierState   As ACarrierState = Nothing
        Dim ltypAtrayList       As typeAtrayList = Nothing

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02T0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@ﾒﾝﾊﾞｰ変数初期化
            mtypACarrierState = ltypACarrierState
            mtypAtrayList = ltypAtrayList

            '@ﾃｷｽﾄ
            txtACarrierId.CausesValidation = True
            txtATrayId.CausesValidation = True
            txtATrayId.Text = vbNullString
            
            '@ﾎﾞﾀﾝ
            cmdCarrierSelect.CausesValidation = False
            
            '@各ﾗﾍﾞﾙの初期化
            lblEmptyFlag.Text = vbNullString
            lblCleanFlag.Text = vbNullString
            lblALDCount.Text = vbNullString
            lblALDLimit.Text = vbNullString
            lblCleanCount.Text = vbNullString
            lblLot.Text = vbNullString
            
            '@Aｷｬﾘｱ区分(初期状態として「製品(ﾓﾆﾀ無)」のみﾁｪｯｸ）
            optClass0.Enabled = False
            optClass1.Enabled = False
            optClass2.Enabled = False
            optClass3.Enabled = False
            optClass4.Enabled = False
            optClass0.Checked = True
            optClass1.Checked = False
            optClass2.Checked = False
            optClass3.Checked = False
            optClass4.Checked = False
            
            '@=======================
            '@ Aｷｬﾘｱ(SLOT)ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfSlot_Init()
            
        '@↓2019/11/21 (Thu) 10:35:15 T.Oide **************************************************
            '@=======================
            '@ 在庫ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfInvList_Init()
        '@↑2019/11/21 (Thu) 10:35:15 T.Oide **************************************************
            
            '@=======================
            '@ 有効/無効ﾁｪｯｸ
            '@=======================
            Call prvEnable_Chk()
                        
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02T0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlot_Init
    '機　能：Aｷｬﾘｱｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2019/12/09 (Mon) 13:24:06 T.Oide
    '備　考：
    Private Sub prvvsfSlot_Init()

        Dim llngCnt     As Integer

        Try
            
            With vsfSlot
                        
                '@ﾛｯｸ
                '.Enabled = False
                
                '@ｸﾘｱ
                .Clear
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                '@ﾏｳｽでｾﾙ範囲選択不可
                '.AllowSelection = False
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                .Styles.Fixed.Trimming = StringTrimming.None          'NSYS ヘッダは省略なし
                '@ﾏｳｽでｶﾗﾑ幅変更可能
                .AllowResizing = AllowResizingEnum.Columns
                
                'NSYS 初期化
                .Row = - 1

                '@列数設定
                .Cols.Count = CMvsfSlotCols
                '@行数設定
                .Rows.Count = CMvsfSlotRows
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.Light
                .HighLight = HighLightEnum.Always
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMvsfSlotTitleRow, CMlngSlotColNo, CMvsfSlotTitleRow, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMvsfSlotTFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)      'ﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '中央表示
                cellRange.Style = headerStyle
                .Rows(CMvsfSlotTitleRow).Height = CMvsfSlotHHeight                                                                               '高さ
                                                        
                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMvsfSlotTitleRow, CMlngSlotColNo, CMstrSlotColTNo)
                .SetData(CMvsfSlotTitleRow, CMlngSlotColATrayId, CMstrSlotColTATrayId)
                .SetData(CMvsfSlotTitleRow, CMlngSlotColATrayStatus, CMstrSlotColTATrayStatus)
                .SetData(CMvsfSlotTitleRow, CMlngSlotColATrayClass, CMstrSlotColTATrayClass)
                .SetData(CMvsfSlotTitleRow, CMlngSlotColTapeGroup, CMstrSlotColTTapeGroup)
        '@↓2019/12/09 (Mon) 13:24:15 T.Oide **************************************************
                '@.Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColInvLotId) = CMstrSlotColTInvLotId
                '@.Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColBender) = CMstrSlotColTBender
                '@.Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColProductionLotId) = CMstrSlotColTProductionLotId
        '@↑2019/12/09 (Mon) 13:24:15 T.Oide **************************************************
                .SetData(CMvsfSlotTitleRow, CMlngSlotColALDCount, CMstrSlotColTALDCount)
                .SetData(CMvsfSlotTitleRow, CMlngSlotColALDLimit, CMstrSlotColTALDLimit)
                .SetData(CMvsfSlotTitleRow, CMlngSlotColCleanCount, CMstrSlotColTCleanCount)
                .SetData(CMvsfSlotTitleRow, CMlngSlotColCurrentClass, CMstrSlotColTCurrentClass)
        '@↓2019/12/09 (Mon) 13:24:37 T.Oide **************************************************
                '@.Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColQty) = CMstrSlotColTQty
        '@↑2019/12/09 (Mon) 13:24:37 T.Oide **************************************************

                .Cols(CMlngSlotColNo).Width = CMlngSlotColWNo
                .Cols(CMlngSlotColATrayId).Width = CMlngSlotColWATrayId
                .Cols(CMlngSlotColATrayStatus).Width = CMlngSlotColWAtrayStatus
                .Cols(CMlngSlotColATrayClass).Width = CMlngSlotColWAtrayClasss
                .Cols(CMlngSlotColTapeGroup).Width = CMlngSlotColWTapeGroup
        '@↓2019/12/09 (Mon) 13:24:22 T.Oide **************************************************
                '@.ColWidth(CMlngSlotColInvLotId) = CMlngSlotColWInvLotId
                '@.ColWidth(CMlngSlotColBender) = CMlngSlotColWBender
                '@.ColWidth(CMlngSlotColProductionLotId) = CMlngSlotColWProductionLotId
        '@↑2019/12/09 (Mon) 13:24:22 T.Oide **************************************************
                .Cols(CMlngSlotColALDCount).Width = CMlngSlotColWALDCount
                .Cols(CMlngSlotColALDLimit).Width = CMlngSlotColWALDLimit
                .Cols(CMlngSlotColCleanCount).Width = CMlngSlotColWCleanCount
                .Cols(CMlngSlotColCurrentClass).Width = CMlngSlotColWCurrentClass
        '@↓2019/12/09 (Mon) 13:24:50 T.Oide **************************************************
                '@.ColWidth(CMlngSlotColQty) = CMlngSlotColWQty
        '@↑2019/12/09 (Mon) 13:24:50 T.Oide **************************************************
                
                '@列位置の設定
                .Cols(CMlngSlotColNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngSlotColATrayId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngSlotColATrayStatus).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngSlotColATrayClass).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngSlotColTapeGroup).TextAlign = TextAlignEnum.LeftCenter
        '@↓2019/12/09 (Mon) 13:25:00 T.Oide **************************************************
                '@.ColAlignment(CMlngSlotColInvLotId) = flexAlignLeftCenter
                '@.ColAlignment(CMlngSlotColBender) = flexAlignLeftCenter
                '@.ColAlignment(CMlngSlotColProductionLotId) = flexAlignLeftCenter
        '@↑2019/12/09 (Mon) 13:25:00 T.Oide **************************************************
                .Cols(CMlngSlotColALDCount).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngSlotColALDLimit).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngSlotColCleanCount).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngSlotColCurrentClass).TextAlign = TextAlignEnum.LeftCenter
        '@↓2019/12/09 (Mon) 13:25:08 T.Oide **************************************************
                '@.ColAlignment(CMlngSlotColQty) = flexAlignLeftCenter
        '@↑2019/12/09 (Mon) 13:25:08 T.Oide **************************************************

                '@非表示列設定
                .Cols(CMlngSlotColCurrentClass).Visible = False
        '@↓2019/12/09 (Mon) 13:25:19 T.Oide **************************************************
                '@.ColHidden(CMlngSlotColQty) = True
                '@.ColHidden(CMlngSlotColProductionLotId) = True
        '@↑2019/12/09 (Mon) 13:25:19 T.Oide **************************************************
                        
                '@ｽﾛｯﾄﾏｯﾌﾟの1行からｽﾛｯﾄﾏｯﾌﾟの最後まで
                For llngCnt = 1 To .Rows.Count - 1
                    '@ｽﾛｯﾄ№設定
                    '.CellFontSize = CMvsfSlotFontSize           'ﾌｫﾝﾄｻｲｽﾞ
                    .Rows(llngCnt).Height = CMvsfSlotHeight       '高さ
                    .SetData(llngCnt, CMlngSlotColNo, Format$(.Rows.Count - llngCnt, CPstrSlotNoFormat))
                Next llngCnt
                
                .Row = 0

                '@ｸﾞﾘｯﾄﾞｻｲｽﾞ(大)設定
                Call prvvsfSlotSizeSet(CMstrProduct)
                
                '@ﾛｯｸ
                .Enabled = True
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlot_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfInvList_Init
    '機　能：在庫ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/11/21 (Thu) 10:32:27 T.Oide
    '更新日：2019/11/21 (Thu) 10:32:27 T.Oide
    '備　考：
    Private Sub prvvsfInvList_Init()

        Try
            
            With vsfInvList
                        
                '@ﾛｯｸ
                '.Enabled = False
                
                '@ｸﾘｱ
                .Clear
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                '@ﾏｳｽでｾﾙ範囲選択不可
                '.AllowSelection = False
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                '@ﾏｳｽでｶﾗﾑ幅変更可能
                .AllowResizing = AllowResizingEnum.Columns
                
                '@列数設定
                .Cols.Count = CMvsfInvListCols
                '@行数設定
                .Rows.Count = CMvsfInvListRows
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.Light
                .HighLight = HighLightEnum.Always
                
                '@折り返し
                .Styles.Normal.WordWrap = True
                .Styles.Fixed.Trimming = StringTrimming.None    'NSYS ヘッダは省略なし

                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMvsfSlotTitleRow, CMlngSlotColNo, CMvsfSlotTitleRow, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMvsfSlotTFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)      'ﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '中央表示
                cellRange.Style = headerStyle
                .Rows(CMvsfSlotTitleRow).Height = CMvsfSlotHHeight                                                                               '高さ
                .ScrollBars = Scrollbars.Both
                                                        
                 '@ﾏｰｼﾞ
                .AllowMerging = AllowMergingEnum.Free
                .Cols(CMlngInvListColVenderClsId).AllowMerging = True
                .Cols(CMlngInvListColVenderClsName).AllowMerging = True
                .Cols(CMlngInvListColVenderId).AllowMerging = True
                .Cols(CMlngInvListColVenderName).AllowMerging = True
                .Cols(CMlngInvListColPartCode).AllowMerging = True
                .Cols(CMlngInvListColPartName).AllowMerging = True
                                      
                '@ﾀｲﾄﾙ設定
                .SetData(CMvsfSlotTitleRow, CMlngInvListColNo, CMstrInvListColTNo)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColVenderClsId, CMstrInvListColTVenderClsId)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColVenderClsName, CMstrInvListColTVenderClsName)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColVenderId, CMstrInvListColTVenderId)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColVenderName, CMstrInvListColTVenderName)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColPartCode, CMstrInvListColTPartCode)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColPartName, CMstrInvListColTPartName)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColLotId, CMstrInvListColTLotId)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColInvQty, CMstrInvListColTInvQty)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColUseQty, CMstrInvListColTUseQty)
                .SetData(CMvsfSlotTitleRow, CMlngInvListColProdcLotId, CMstrInvListColTProdcLotId)
                
                '@列幅
                .Cols(CMlngInvListColNo).Width = CMlngSlotColWNo
                .Cols(CMlngInvListColVenderClsId).Width = CMlngInvListColWVenderClsId
                .Cols(CMlngInvListColVenderClsName).Width = CMlngInvListColWVenderClsName
                .Cols(CMlngInvListColVenderId).Width = CMlngInvListColWVenderId
                .Cols(CMlngInvListColVenderName).Width = CMlngInvListColWVenderName
                .Cols(CMlngInvListColPartName).Width = CMlngInvListColWPartName
                .Cols(CMlngInvListColLotId).Width = CMlngInvListColWLotId
                .Cols(CMlngInvListColInvQty).Width = CMlngInvListColWInvQty
                .Cols(CMlngInvListColUseQty).Width = CMlngInvListColWUseQty
                .Cols(CMlngInvListColProdcLotId).Width = CMlngInvListColWProdcLotId
                
                '@列位置の設定
                .Cols(CMlngInvListColNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngInvListColVenderClsId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngInvListColVenderClsName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngInvListColVenderId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngInvListColVenderName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngInvListColPartCode).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngInvListColPartName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngInvListColLotId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngInvListColInvQty).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngInvListColUseQty).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngInvListColProdcLotId).TextAlign = TextAlignEnum.LeftCenter
                
                '@非表示列設定
                .Cols(CMlngInvListColVenderClsId).Visible = False   'ﾍﾞﾝﾀﾞｰｸﾗｽID
                .Cols(CMlngInvListColVenderId).Visible = False      'ﾍﾞﾝﾀﾞｰID
                .Cols(CMlngInvListColPartCode).Visible = False      'ﾊﾟｰﾂｺｰﾄﾞ
                .Cols(CMlngInvListColProdcLotId).Visible = False    '製造ﾛｯﾄ
                
                '@ﾛｯｸ
                .Enabled = True
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlot_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

'未使用機能NSYS ↓
'関数名：prvvsfSlot_Clear
'機　能：ﾃﾞｰﾀｸﾘｱ
'引　数：なし
'戻り値：なし
'作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
'更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
'備　考：
'    Private Sub prvvsfSlot_Clear()

'    Dim llngCnt     As Long

'    On Error GoTo Error_Handler
    
'    With vsfSlot
                
'        '@ﾛｯｸ
'        .Enabled = False
        
'        '@ｸﾘｱ
'        .Clear
        
'        '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
'        .FillStyle = flexFillRepeat
        
'        '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
'        .AllowBigSelection = False
'        '@ﾏｳｽでｾﾙ範囲選択不可
'        .AllowSelection = False
'        '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
'        .Ellipsis = flexEllipsisEnd
        
'        '@列数設定
'        .Cols = CMvsfSlotCols
'        '@行数設定
'        .Rows = CMvsfSlotRows
        
'        '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
'        .FocusRect = flexFocusLight
'        .HighLight = flexHighlightAlways
        
'        '@一覧表の表題設定
'        .Select CMvsfSlotTitleRow, CMlngSlotColNo, CMvsfSlotTitleRow, .Cols - 1
'        .CellAlignment = flexAlignCenterCenter                  '中央表示
'        .CellForeColor = vbYellow                               '文字色
'        .CellBackColor = CPlngBlueColor                         '背景色
'        .CellFontSize = CMvsfSlotTFontSize                      'ﾌｫﾝﾄｻｲｽﾞ
'        .RowHeight(CMvsfSlotTitleRow) = CMvsfSlotHHeight        '高さ
                                                
'        '@列幅、ﾀｲﾄﾙ設定
'        .Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColNo) = CMstrSlotColTNo
'        .Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColATrayId) = CMstrSlotColTATrayId
'        .Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColATrayStatus) = CMstrSlotColTATrayStatus
'        .Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColATrayClass) = CMstrSlotColTATrayClass
'        .Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColALDCount) = CMstrSlotColTALDCount
'        .Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColALDLimit) = CMstrSlotColTALDLimit
'        .Cell(flexcpText, CMvsfSlotTitleRow, CMlngSlotColCleanCount) = CMstrSlotColTCleanCount

'        .ColWidth(CMlngSlotColNo) = CMlngSlotColWNo
'        .ColWidth(CMlngSlotColATrayId) = CMlngSlotColWATrayId
'        .ColWidth(CMlngSlotColATrayStatus) = CMlngSlotColWAtrayStatus
'        .ColWidth(CMlngSlotColATrayClass) = CMlngSlotColWAtrayClasss
'        .ColWidth(CMlngSlotColALDCount) = CMlngSlotColWALDCount
'        .ColWidth(CMlngSlotColALDLimit) = CMlngSlotColWALDLimit
'        .ColWidth(CMlngSlotColCleanCount) = CMlngSlotColWCleanCount
        
'        '@列位置の設定
'        .ColAlignment(CMlngSlotColNo) = flexAlignRightCenter
'        .ColAlignment(CMlngSlotColATrayId) = flexAlignLeftCenter
'        .ColAlignment(CMlngSlotColATrayStatus) = flexAlignLeftCenter
'        .ColAlignment(CMlngSlotColATrayClass) = flexAlignLeftCenter
'        .ColAlignment(CMlngSlotColALDCount) = flexAlignRightCenter
'        .ColAlignment(CMlngSlotColALDLimit) = flexAlignRightCenter
'        .ColAlignment(CMlngSlotColCleanCount) = flexAlignRightCenter
        
'        '@非表示列設定
'        '.ColHidden(CMvsfLotColKb) = True
                
'        '@ｽﾛｯﾄﾏｯﾌﾟの1行からｽﾛｯﾄﾏｯﾌﾟの最後まで
'        For llngCnt = 1 To .Rows - 1
'            '@ｽﾛｯﾄ№設定
'            '.CellFontSize = CMvsfSlotFontSize           'ﾌｫﾝﾄｻｲｽﾞ
'            .RowHeight(llngCnt) = CMvsfSlotHeight       '高さ
'            .Cell(flexcpText, llngCnt, CMlngSlotColNo) = Format$(.Rows - llngCnt, CPstrSlotNoFormat)
'        Next llngCnt
              
'        '@ﾛｯｸ
'        .Enabled = True
        
'    End With

'    Exit Sub

'Error_Handler:

'    '@ｴﾗｰ情報設定
'    With ptypOnErrorInfo
'        .strMenuKey = CMstrLocalMenuKey
'        .strProcName = "prvvsfSlot_Clear"
'        .strErrMessage = vbNullString
'    End With

'    '@=======================
'    '@ 共通ｴﾗｰ処理
'    '@=======================
'    Call pubOnError_Proc

'End Sub
'未使用機能NSYS ↑

    '関数名：prvACarrier_Disp
    '機　能：ｽﾛｯﾄ情報の取得
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub prvACarrier_Disp()
                    
        Try
                
            '@EMPTY_FLAG
            If mtypACarrierState.strEmptyFlag = CPstrFlagOn Then
                lblEmptyFlag.Text = CMstrEmptyFlagOn
            Else
                lblEmptyFlag.Text = CMstrEmptyFlagOff
            End If
            
            '@CLEAN_FLAG
            If mtypACarrierState.strCleanFlag = CPstrFlagOn Then
                lblCleanFlag.Text = CMstrCleanFlagOn
            Else
                lblCleanFlag.Text = CMstrCleanFlagOff
            End If
            
            lblALDCount.Text = mtypACarrierState.strWashUseNum
            lblALDLimit.Text = mtypACarrierState.strWashUseLimit
            lblCleanCount.Text = mtypACarrierState.strCleanCount
            
            '@ﾛｯﾄ割当
            If mtypACarrierState.strTapeStickBatchId = vbNullString Then
                lblLot.Text = CPstrNasiFlg
            Else
                lblLot.Text = CPstrAriFlg
            End If
                     
            '@Aｷｬﾘｱ区分
            '@ｲﾍﾞﾝﾄを発生させる為初期化
            optClass0.Checked = False
            optClass1.Checked = False
            optClass2.Checked = False
            optClass3.Checked = False
            optClass4.Checked = False

            Select Case mtypACarrierState.strACarrierClass
                
                '@「製品(ﾓﾆﾀｰ有)」「品確、ﾓﾆﾀｰ」
                Case CMstrProductWithMo
                    optClass1.Checked = True
                Case CMstrFillDummy
                    optClass2.Checked = True
                Case CMstrFillDummyWithMo
                    optClass3.Checked = True
                Case CMstrQuMo
                    optClass4.Checked = True
                '@指定なしの場合は製品(「製品(ﾓﾆﾀｰ無)」)
                Case Else
            
                    optClass0.Checked = True
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvACarrier_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlot_Disp
    '機　能：ｽﾛｯﾄ情報の表示位置設定
    '引　数：ltypACarrierState:表示情報
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2019/12/06 (Fri) 13:07:36 T.Oide
    '備　考：
    Private Sub prvVsfSlot_Disp(ByRef ltypACarrierState As ACarrierState)
        
        Dim llngRowCnt              As Integer
        Dim llngCnt                 As Integer
        Dim llngCnt2                As Integer
        
        Try
            
            With vsfSlot
                  
                '@区分以外をｸﾘｱ
                llngCnt = 1
                Do While .Rows.Count - 1 >= llngCnt
                    llngCnt2 = CMlngSlotColATrayId
                    Do While CMlngSlotColATrayClass - 1 >= llngcnt2
                        .SetData(llngCnt, llngCnt2, vbNullString)
                        llngcnt2 = llngcnt2 + 1
                    Loop
                    llngCnt = llngCnt + 1
                Loop
                llngCnt = 1
                Do While .Rows.Count - 1 >= llngCnt
                    llngCnt2 = CMlngSlotColATrayClass + 1
                    Do While .Cols.Count - 1 >= llngcnt2
                        .SetData(llngCnt, llngCnt2, vbNullString)
                        llngcnt2 = llngcnt2 + 1
                    Loop
                    llngCnt = llngCnt + 1
                Loop
                
                '@Aﾄﾚｲ表示
                For llngCnt = 0 To ltypACarrierState.lngATrayListCnt - 1
                
                    '@ｽﾛｯﾄ検索
                    For llngRowCnt = 1 To .Rows.Count - 1
                        
                        With ltypACarrierState.typAtrayList(llngCnt)
                        
                            '@ｽﾛｯﾄが見つかった場合
                            If vsfSlot.GetData(llngRowCnt, CMlngSlotColNo) = .strSlotPosition Then
                
                                vsfSlot.SetData(llngRowCnt, CMlngSlotColATrayId, .strAtrayId)
                                vsfSlot.SetData(llngRowCnt, CMlngSlotColATrayStatus, .strAtrayStatusName)
                                vsfSlot.SetData(llngRowCnt, CMlngSlotColTapeGroup, .strTapeStickGroup)
                                vsfSlot.SetData(llngRowCnt, CMlngSlotColALDCount, .strWashUseNum)
                                vsfSlot.SetData(llngRowCnt, CMlngSlotColALDLimit, .strWashUseLimit)
                                vsfSlot.SetData(llngRowCnt, CMlngSlotColCleanCount, .strCleanCount)
                                vsfSlot.SetData(llngRowCnt, CMlngSlotColCurrentClass, .strAtrayClass)
                                
                                Exit For
                                
                            End If
                            
                        End With
                        
                    Next
                    
                Next
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlot_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvstrATrayCombList_Set
    '機　能：ｸﾞﾘｯﾄﾞのATrayのｺﾝﾎﾞﾘｽﾄを作成する
    '引　数：なし
    '戻り値：strClass：Aﾄﾚｰｸﾗｽ
    '作成日：2018/11/20 (Tue) 10:44:49 T.Oide
    '更新日：2018/11/20 (Tue) 10:44:49
    '備　考：
    Private Function prvstrATrayCombList_Set(ByVal strClass As String) As String
        
        Dim llngCnt     As Integer
        Dim lstrCombList   As String
        
        Try
            
            prvstrATrayCombList_Set = vbNullString
            lstrCombList = vbNullString
            
            '@ﾃﾞｰﾀ無
            If mtypAtrayList.lngAtraytListCnt = 0 Then
                Exit Function
            End If
            
            '@ATrayﾘｽﾄが入っている構造体を回して、指定ｸﾗｽのｺﾝﾎﾞﾘｽﾄを作成する
            For llngCnt = 0 To mtypAtrayList.lngAtraytListCnt - 1
                
                '@ｸﾗｽは一致するか
                If strClass = mtypAtrayList.typAtraytList(llngCnt).strAtrayClass Then
                    lstrCombList = lstrCombList & CPstrPipeString & mtypAtrayList.typAtraytList(llngCnt).strAtrayId
                End If
                
            Next
            
            '@結果を返す
            prvstrATrayCombList_Set = lstrCombList
            
            Exit Function
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvstrATrayCombList_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnRegist_Chk
    '機　能：確定情報ﾁｪｯｸ
    '引　数：なし
    '戻り値：TRUE:成功 FALSE:失敗
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2019/12/09 (Mon) 13:25:59 T.Oide
    '備　考：
    Private Function prvblnRegist_Chk(ByRef ltypACarrierState As ACarrierState) As Boolean
        
        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer
        Dim llngRowCnt      As Integer
        Dim llngATrayCnt    As Integer
    '@↓2019/11/26 (Tue) 17:57:46 T.Oide **************************************************
        Dim llngUsePartCnt  As Integer
    '@↑2019/11/26 (Tue) 17:57:46 T.Oide **************************************************
        Dim strClass        As String

        Try
            
            prvblnRegist_Chk = False
            
            '@------------------
            '@Aｷｬﾘｱ
            '@------------------
            '@ID
            If mtypACarrierState.strACarrierId <> txtACarrierId.Text Then
                Exit Function
            End If
            
            '@積載(空)
            If mtypACarrierState.strEmptyFlag <> CPstrFlagOn Then
                Exit Function
            End If
            
            '@洗浄(不要)
            If mtypACarrierState.strCleanFlag <> CPstrFlagOff Then
                Exit Function
            End If
            
            '@使用回数(上限以下)
            If CLng(mtypACarrierState.strWashUseNum) > CLng(mtypACarrierState.strWashUseLimit) Then
                Exit Function
            End If
            
            '@累積使用回数(上限以下)
            If CLng(mtypACarrierState.strUseNum) > CLng(mtypACarrierState.strUseLimit) Then
                Exit Function
            End If

            '@ﾛｯﾄ紐付なし
            If mtypACarrierState.strTapeStickBatchId <> vbNullString Or _
                mtypACarrierState.strOvenBatchId <> vbNullString Or _
                mtypACarrierState.strAldBatchId <> vbNullString Then
                Exit Function
            End If

            '@Aｷｬﾘｱ
            ltypACarrierState.strACarrierId = mtypACarrierState.strACarrierId
            If optClass0.Checked = True Then
                ltypACarrierState.strACarrierClass = 0
            Else If optClass1.Checked = True Then
                ltypACarrierState.strACarrierClass = 1
            Else If optClass2.Checked = True Then
                ltypACarrierState.strACarrierClass = 2
            Else If optClass3.Checked = True Then
                ltypACarrierState.strACarrierClass = 3
            Else If optClass4.Checked = True Then
                ltypACarrierState.strACarrierClass = 4
            End If
            If ltypACarrierState.strACarrierClass = vbNullString Then
                Exit Function
            End If

            '@------------------
            '@SLOT
            '@------------------
            llngATrayCnt = 0
            ltypACarrierState.typAtrayList = New List(Of ATrayList)
            With vsfSlot
                For llngRowCnt = 1 To .Rows.Count - 1
                    '@------------------
                    '@背景色(白)
                    '@------------------
                    If .GetCellRange(llngRowCnt, CMlngSlotColATrayId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                        '@------------------
                        '@ATrayId
                        '@------------------
                        If .GetData(llngRowCnt, CMlngSlotColATrayId) = vbNullString Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037, CMstrErr02, CMstrErr03)
                            '@"<TRM37W>$$AトレイID[空] 理由[未選択]$$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                            Exit Function
                        End If
                        
                        '@------------------
                        '@区分
                        '@------------------
                        Select Case .GetData(llngRowCnt, CMlngSlotColATrayClass)
                            '@製品の場合
                            Case CPstrSpecUseProductName
                                strClass = CPstrUseIDProduct
                            
                            '@モニタの場合
                            Case CPstrSpecUseMonitorName
                                strClass = CPstrUseIDMonitor
                            
                            '@ダミーの場合
                            Case CPstrSpecUseDummyName
                                strClass = CPstrUseIDDummy
                            Case Else
                                strClass = vbNullString
                        End Select
                        
                        If strClass <> .GetData(llngRowCnt, CMlngSlotColCurrentClass) Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037, .GetData(llngRowCnt, CMlngSlotColATrayId), CMstrErr04)
                            '@"<TRM37W>$$AトレイID[%1] 理由[未選択]$$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                        
                        '@------------------
                        '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                        '@------------------
                        '@区分:PRODUCT
                        If .GetData(llngRowCnt, CMlngSlotColATrayClass) = CPstrUseIDProduct Then
                            
                            If llngRowCnt = 1 Then
                                '@空でないこと
                                If .GetData(llngRowCnt, CMlngSlotColTapeGroup) = vbNullString Then
                                
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037, .GetData(llngRowCnt, CMlngSlotColATrayId), CMstrErr05)
                                    '@"<TRM37W>$$AトレイID[%1] 理由[未選択]$$設定を見直してください。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                    Exit Function
                                End If
                            Else
                                '@一つ上と同じであること
                                If .GetData(llngRowCnt, CMlngSlotColTapeGroup) <> .GetData(llngRowCnt - 1, CMlngSlotColTapeGroup) Then
                                
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037, .GetData(llngRowCnt, CMlngSlotColATrayId), CMstrErr06)
                                    '@"<TRM37W>$$AトレイID[%1] 理由[未選択]$$設定を見直してください。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                    Exit Function
                                End If
                            End If

                        End If
                        
                        '@------------------
                        '@登録ﾃﾞｰﾀを構造体に格納
                        '@------------------
                        llngATrayCnt = llngATrayCnt + 1
                        ltypACarrierState.lngATrayListCnt = llngATrayCnt
                        Dim typATrayListtmp = New ATrayList
                        typATrayListtmp.strAtrayId = _
                                .GetData(llngRowCnt, CMlngSlotColATrayId)                      'AﾄﾚｰID
                        typATrayListtmp.strSlotPosition = _
                                .GetData(llngRowCnt, CMlngSlotColNo)                           'ｽﾛｯﾄﾏｯﾌﾟ
                        ltypACarrierState.typAtrayList.Add(typATrayListtmp)

        '@↓2019/11/21 (Thu) 10:11:55 T.Oide **************************************************
        '@                '@QU、MOか
        '@                If optClass(CMstrQuMo).Value = True Then
        '@
        '@                    '@QU、MOの場合、利用部材の情報を格納
        '@
        '@                    ltypACarrierState.typAtrayList(llngATrayCnt).strPartCode = _
        '@                            cmbPartName.Value                                           '利用部材
        '@                    ltypACarrierState.typAtrayList(llngATrayCnt).strInvLotId = _
        '@                            .Cell(flexcpText, llngRowCnt, CMlngSlotColInvLotId)         '在庫ﾛｯﾄID
        '@                    ltypACarrierState.typAtrayList(llngATrayCnt).strProductionLotId = _
        '@                            .Cell(flexcpText, llngRowCnt, CMlngSlotColProductionLotId)  '製造ﾛｯﾄID
        '@                    ltypACarrierState.typAtrayList(llngATrayCnt).strQty = _
        '@                            .Cell(flexcpText, llngRowCnt, CMlngSlotColQty)              'ﾁｯﾌﾟ数
        '@
        '@                End If
        '@↑2019/11/21 (Thu) 10:11:55 T.Oide **************************************************

                    '@------------------
                    '@背景色(白)以外
                    '@------------------
                    Else
                        If .GetData(llngRowCnt, CMlngSlotColATrayId) <> vbNullString Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037, .GetData(llngRowCnt, CMlngSlotColATrayId), CMstrErr07)
                            '@"<TRM37W>$$AトレイID[%1] 理由[未選択]$$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                            Exit Function
                        End If
                    End If
                Next
            End With
            
        '@↓2019/11/26 (Tue) 17:52:13 T.Oide **************************************************
            '@------------------
            '@QU、MOの場合、使用部材を格納
            '@------------------
            If optClass4.Checked = True Then
                With vsfInvList
                
                    '@部材ｸﾞﾘｯﾄﾞを回す
                    ltypACarrierState.typAtrayUsePart.typeAldPart = New List(Of typALDPart)
                    For llngRowCnt = 1 To .Rows.Count - 1
                    
                        '@使用数量が0以外の列の値を格納する
                        If .GetData(llngRowCnt, CMlngInvListColUseQty) <> CPlngNumZero Then
                            llngUsePartCnt = llngUsePartCnt + 1
                            Dim typtypALDParttmp = New typALDPart
                            ltypACarrierState.typAtrayUsePart.lngAldPartCnt = llngUsePartCnt
                            typtypALDParttmp.strLotID = .GetData(llngRowCnt, CMlngInvListColLotId)
                            typtypALDParttmp.strPartCode = .GetData(llngRowCnt, CMlngInvListColPartCode)
                            typtypALDParttmp.strChipQty = .GetData(llngRowCnt, CMlngInvListColUseQty)
                            typtypALDParttmp.strProdcLotId = .GetData(llngRowCnt, CMlngInvListColProdcLotId)
                            ltypACarrierState.typAtrayUsePart.typeAldPart.Add(typtypALDParttmp)
                        End If
                    Next
                End With
            End If
        '@↑2019/11/26 (Tue) 17:52:13 T.Oide **************************************************
            
            '@------------------
            '@ATray重複ﾁｪｯｸ
            '@------------------
            For llngCnt = 0 To ltypACarrierState.lngATrayListCnt - 1
                For llngCnt2 = 0 To ltypACarrierState.lngATrayListCnt - 1
                    If llngCnt <> llngCnt2 Then
                        If ltypACarrierState.typAtrayList(llngCnt).strAtrayId = ltypACarrierState.typAtrayList(llngCnt2).strAtrayId Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037, ltypACarrierState.typAtrayList(llngCnt).strAtrayId, CMstrErr01)
                            '@"<TRM37W>$$AトレイID[%1] 理由[未選択]$$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    End If
                Next
            Next
            
            prvblnRegist_Chk = True
            
            Exit Function
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvvsfSlotSizeSet
    '機　能：：vsfSlotのｻｲｽﾞ設定と部材表示/非表示、ｶﾗﾑの表示/非表示
    '引　数：lngIndex：選択したｵﾌﾟｼｮﾝのIndex
    '戻り値：
    '作成日：2018/11/13 (Tue) 16:11:01 T.Oide
    '更新日：2019/12/09 (Mon) 13:27:36 T.Oide
    '備　考：
    Private Sub prvvsfSlotSizeSet(ByVal lngIndex As Integer)

        Try
            
            With vsfSlot
            
                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝのIndexで分岐
                Select Case lngIndex
                    
                    '@ﾓﾆﾀｰ・品確の場合
                    Case CMstrQuMo
                        .Height = CMvsfSlotSmallHeight              '小
                        .Top = CMvsfSlotSmallTop                    '小
                        .Cols(CMlngSlotColTapeGroup).Visible = False    'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ非表示
        '@↓2019/11/21 (Thu) 10:26:43 T.Oide **************************************************
        '@                frmInventry.Visible = True                  '部材ﾌﾚｰﾑ表示
                        vsfInvList.Visible = True                   '部材ｸﾞﾘｯﾄﾞ表示
        '@↑2019/11/21 (Thu) 10:26:43 T.Oide **************************************************
                    
                    '@その他
                    Case Else
                        .Height = CMvsfSlotLargeHeight              '大
                        .Top = CMvsfSlotLargeTop                    '大
                        .Cols(CMlngSlotColTapeGroup).Visible = True   'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ表示
        '@↓2019/11/21 (Thu) 10:26:43 T.Oide **************************************************
        '@                frmInventry.Visible = False                 '部材ﾌﾚｰﾑ非表示
                        vsfInvList.Visible = True                   '部材ｸﾞﾘｯﾄﾞ表示
        '@↑2019/11/21 (Thu) 10:26:43 T.Oide **************************************************
                        
                End Select

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2019/11/25 (Mon) 16:39:29 T.Oide **************************************************
    '@'関数名：prvGetMoQuPd
    '@'機　能：ﾓﾆﾀｰ機種と品確機種を取得する(部材ﾘｽﾄを取得するため)
    '@'引　数：なし
    '@'戻り値：True：成功、False：失敗
    '@'作成日：2018/11/15 (Thu) 10:50:15 T.Oide
    '@'更新日：2018/11/15 (Thu) 10:50:15
    '@'備　考：
    '@Private Function prvGetMoQuPd() As Boolean
    '@
    '@    Dim lstrClassDivision   As String
    '@    Dim ltypProductList()   As ProductList                      '機種格納変数
    '@    Dim llngProductListCnt  As Long                             '機種格納数
    '@    Dim lblnAns             As Boolean
    '@    Dim llngCnt             As Long
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ﾚｽﾎﾟﾝｽ取得開始
    '@    Call pubResponseStart(frmxxEN02T0.Name, mstrEventName)
    '@
    '@    prvGetMoQuPd = False
    '@
    '@    '@処理区分に"2Z02：品確、ﾓﾆﾀｰ、ﾀﾞﾐｰ 全て"をｾｯﾄ
    '@    lstrClassDivision = CPstrCD2Z & CPstrCD02
    '@
    '@    '@=======================
    '@    '@ 機種区分一覧取得
    '@    '@=======================
    '@    lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
    '@                                  lstrClassDivision, _
    '@                                  ltypProductList(), _
    '@                                  llngProductListCnt, _
    '@                                  pstrSBID)
    '@
    '@    '@機種区分一覧取得結果が"False：取得失敗"か
    '@    If lblnAns = False Then
    '@
    '@        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
    '@        Call pubResponseCancel(frmxxEN02T0.Name, mstrEventName)
    '@        Exit Function
    '@    End If
    '@
    '@    '@変数に機種を格納する
    '@    ' メモ：ALDの行程で品確やﾓﾆﾀｰ機種が複数できる場合、下記のﾛｼﾞｯｸは見直さないとだめ
    '@    For llngCnt = 1 To llngProductListCnt
    '@
    '@        '@品確か
    '@        If ltypProductList(llngCnt).strUseId = CPstrQuality Then
    '@            mstrQuPd = ltypProductList(llngCnt).strProductID
    '@            mstrQuPdVer = ltypProductList(llngCnt).strMasPdVersion
    '@        End If
    '@
    '@        '@ﾓﾆﾀｰか
    '@        If ltypProductList(llngCnt).strUseId = CPstrMonitor Then
    '@            mstrMoPd = ltypProductList(llngCnt).strProductID
    '@            mstrMoPdVer = ltypProductList(llngCnt).strMasPdVersion
    '@        End If
    '@
    '@    Next
    '@
    '@    '@ﾚｽﾎﾟﾝｽ取得終了
    '@    Call publngResponseEnd(frmxxEN02T0.Name, mstrEventName)
    '@
    '@    prvGetMoQuPd = True
    '@
    '@    Exit Function
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvGetMoQuPd"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Function
    '@↑2019/11/25 (Mon) 16:39:29 T.Oide **************************************************

    '@↓2019/11/21 (Thu) 15:22:30 T.Oide **************************************************
    '@'関数名：prvGetInventry
    '@'機　能：利用部材のﾘｽﾄを取得してｺﾝﾎﾞのﾘｽﾄに設定する
    '@'引　数：なし
    '@'戻り値：True：成功、False：失敗
    '@'作成日：2018/11/15 (Thu) 11:23:47 T.Oide
    '@'更新日：2018/11/15 (Thu) 11:23:47
    '@'備　考：
    '@Private Function prvGetInventry(ByVal lngIndex As Long) As Boolean
    '@
    '@    Dim lblnAns                     As Boolean          '汎用戻り値
    '@    Dim llngPartLotListCnt          As Long             '部材ﾘｽﾄのｶｳﾝﾄ
    '@    Dim ltypMasPartlist             As MasPartlist      '部材ｺｰﾄﾞﾘｽﾄ要求構造体
    '@    Dim ltypPartList()              As PartClassList    '部材ﾘｽﾄ構造体
    '@    Dim lstrPdID                    As String
    '@    Dim lstrPdVer                   As String
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    prvGetInventry = False
    '@
    '@    '==================================
    '@    '@QUの部材ﾘｽﾄ取得
    '@    '==================================
    '@    With ltypMasPartlist
    '@        .strSbID = pstrSBID                         '処理区分
    '@        .strMsgVer = CMstrmas_partlistVer           'ﾒｯｾｰｼﾞVersion
    '@        .strPdId = mstrQuPd                         '機種ID
    '@        .strMasPdVersion = mstrQuPdVer              '機種Ver
    '@        .strVenderClassID = vbNullString
    '@    End With
    '@
    '@    '@部材ｺｰﾄﾞ、ﾍﾞﾝﾀﾞｰ取得
    '@    lblnAns = pubblnMasPartList_Sel(ltypMasPartlist, llngPartLotListCnt, ltypPartList())
    '@    '@結果判定
    '@    If lblnAns = False Then
    '@        '@ｴﾗｰの場合
    '@        '@異常の場合終了
    '@        Exit Function
    '@    End If
    '@
    '@    '==================================
    '@    '@MOの部材ﾘｽﾄ取得
    '@    '==================================
    '@    With ltypMasPartlist
    '@        .strSbID = pstrSBID                         '処理区分
    '@        .strMsgVer = CMstrmas_partlistVer           'ﾒｯｾｰｼﾞVersion
    '@        .strPdId = mstrMoPd                         '機種ID
    '@        .strMasPdVersion = mstrMoPdVer              '機種Ver
    '@        .strVenderClassID = vbNullString
    '@    End With
    '@
    '@    '@部材ｺｰﾄﾞ、ﾍﾞﾝﾀﾞｰ取得
    '@    lblnAns = pubblnMasPartList_Sel(ltypMasPartlist, llngPartLotListCnt, ltypPartList())
    '@    '@結果判定
    '@    If lblnAns = False Then
    '@        '@ｴﾗｰの場合
    '@        '@異常の場合終了
    '@        Exit Function
    '@    End If
    '@
    '@    '==================================
    '@    '@利用部材ｺﾝﾎﾞﾎﾞｯｸｽ設定表示
    '@    '==================================
    '@'@↓2019/11/21 (Thu) 10:12:44 T.Oide **************************************************
    '@'@    Call prvCmbPartName_Disp(llngPartLotListCnt, ltypPartList(), ltypMasPartlist.strPdId)
    '@'@↑2019/11/21 (Thu) 10:12:44 T.Oide **************************************************
    '@
    '@    prvGetInventry = True
    '@
    '@    Exit Function
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvGetInventry"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Function
    '@↑2019/11/21 (Thu) 15:22:30 T.Oide **************************************************

    '@↓2019/11/21 (Thu) 15:22:59 T.Oide **************************************************
    '@'関数名：prvGetChipNum
    '@'機　能：MO,QUのﾓﾆﾀｰChip使用数をDefineから取得する
    '@'引　数：なし
    '@'戻り値：True：成功、Flae：失敗
    '@'作成日：2018/11/28 (Wed) 14:26:33 T.Oide
    '@'更新日：2018/11/28 (Wed) 14:26:33
    '@'備　考：
    '@Private Function prvGetChipNum() As Boolean
    '@
    '@    Dim ltypMasDefineReq            As MasDefineReq         'DEFINE情報（要求）
    '@    Dim ltypMasDefineAns            As MasDefineAns         'DEFINE情報（応答)
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    prvGetChipNum = False
    '@
    '@    '@ ==================================
    '@    '@「ALD_MONITOR_COUNT」「CHIP_COUNT」取得
    '@    '@ ==================================
    '@    '@ﾘｸｴｽﾄﾒｯｾｰｼﾞ情報設定
    '@    With ltypMasDefineReq
    '@        .strMsgVer = CMstrmas_definelistVer
    '@        .strTableName = CmstrAldMonitorCount
    '@        .strColumnName = CmstrChipCount
    '@    End With
    '@
    '@    '@Define情報取得
    '@    If pubblnMasDfineList_Sel(ltypMasDefineReq, ltypMasDefineAns) = False Then
    '@        Exit Function
    '@    End If
    '@
    '@    With ltypMasDefineAns
    '@        '@1件以上取得できたか
    '@        If .lngMasDefineListCnt > 0 Then
    '@            '@ﾁｯﾌﾟｶｳﾝﾄ格納(ﾚｺｰﾄﾞは1件のみなのでﾙｰﾌﾟはしない)
    '@            mstrQuMoChipNum = .typMasDefineList(.lngMasDefineListCnt).strId
    '@        End If
    '@    End With
    '@
    '@    prvGetChipNum = True
    '@
    '@    Exit Function
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvGetInventry"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Function
    '@↑2019/11/21 (Thu) 15:22:59 T.Oide **************************************************

    '@↓2019/11/21 (Thu) 10:13:10 T.Oide **************************************************
    '@'関数名：prvCmbPartName_Disp
    '@'機　能：利用部材ｺﾝﾎﾞﾎﾞｯｸｽの設定をする
    '@'引　数：llngPartLotListCnt：
    '@'　　　：ltyppartlist()：
    '@'　　　：slrPd：
    '@'戻り値：
    '@'作成日：2018/11/15 (Thu) 11:43:29 T.Oide
    '@'更新日：2018/11/15 (Thu) 11:43:29
    '@'備　考：
    '@Private Sub prvCmbPartName_Disp(ByVal llngPartLotListCnt As Long, ByRef ltypPartList() As PartClassList, ByVal slrPd As String)
    '@
    '@    Dim llngCnt                     As Long         'ｶｳﾝﾀ変数
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ComboBoxExの設定
    '@    With cmbPartName
    '@        .Clear                                      'ｸﾘｱ
    '@        .DirectInput = False                        '入力不可
    '@        .DispCols = CMlngComboDispCols              '表示項目数(=2)
    '@        .GetCol = CMlngComboColPart                 '項目選択時返却
    '@        .Font.Size = CMlngComboFontSize             'ﾌｫﾝﾄｻｲｽﾞ
    '@        .GridFont.Size = CMlngComboGridFontSize     'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    '@        .RowHeight = CMlngComboRowHeight            '行の高さ
    '@        .ColAlignment(CMlngComboColPartCode) = flexAlignLeftCenter      '左中央
    '@        .ColAlignment(CMlngComboColPartName) = flexAlignLeftCenter      '左中央
    '@
    '@        '@配列の件数ﾁｪｯｸ
    '@        If llngPartLotListCnt > 0 Then
    '@            For llngCnt = 1 To llngPartLotListCnt
    '@                .AddItem ltypPartList(llngCnt).strPartCode & vbTab & _
    '@                         ltypPartList(llngCnt).strPartName & vbTab & _
    '@                         ltypPartList(llngCnt).strVenderName & vbTab & _
    '@                         ltypPartList(llngCnt).strPartCode & CPstrSpace & _
    '@                         ltypPartList(llngCnt).strPartName
    '@            Next
    '@        End If
    '@
    '@        '@利用部材が0件の場合
    '@        If .ListCount = 0 Then
    '@            '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
    '@            '@"<TRM1CW>$$機種[%1]の利用部材は存在しません。"
    '@            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001C, slrPd)
    '@            '@ｲﾝﾌｫﾒｰｼｮﾝ表示
    '@            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Caption, True, 16)
    '@            Exit Sub
    '@        End If
    '@
    '@        '@利用部材が1件の場合
    '@        If .ListCount = 1 Then
    '@            '@1件目表示
    '@            .ListIndex = 0
    '@        End If
    '@
    '@    End With
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvcmbPartName_Disp"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2019/11/21 (Thu) 10:13:10 T.Oide **************************************************

    '関数名：prvInvList_Disp
    '機　能：部材ﾘｽﾄ表示
    '引　数：ptypALDPartLis：表示ﾃﾞｰﾀ
    '　　　：lblnInput：True：入力可、Flase：不可
    '戻り値：
    '作成日：2019/11/25 (Mon) 13:22:36 T.Oide
    '更新日：2019/11/25 (Mon) 13:22:36
    '備　考：
    Private Sub prvInvList_Disp(ByRef ltypALDPartList As typALDPartList, ByRef lblnInput As Boolean)

        Dim llngCnt     As Integer

        Try
            'NSYS 初期値
            If vsfInvList.Row < 1 Then
                vsfInvList.Row = - 1
            End If
            vsfInvList.Rows.Count = ltypALDPartList.lngAldPartCnt + 1
            
            '@取得したﾘｽﾄ数でﾙｰﾌﾟ
            For llngCnt = 1 To ltypALDPartList.lngAldPartCnt
            
                With ltypALDPartList.typeAldPart(llngCnt - 1)
                    vsfInvList.SetData(llngCnt, CMlngInvListColNo, llngCnt)                           '№
                    vsfInvList.SetData(llngCnt, CMlngInvListColVenderClsId, .strVenderClassId)        'ﾍﾞﾝﾀﾞｰｸﾗｽID
                    vsfInvList.SetData(llngCnt, CMlngInvListColVenderClsName, .strVenderClassName)    'ﾍﾞﾝﾀﾞｰｸﾗｽ名
                    vsfInvList.SetData(llngCnt, CMlngInvListColVenderId, .strVenderId)                'ﾍﾞﾝﾀﾞｰID
                    vsfInvList.SetData(llngCnt, CMlngInvListColVenderName, .strVenderName)            'ﾍﾞﾝﾀﾞｰ名
                    vsfInvList.SetData(llngCnt, CMlngInvListColPartCode, .strPartCode)                'ﾊﾟｰﾂｺｰﾄﾞ
                    vsfInvList.SetData(llngCnt, CMlngInvListColPartName, .strPartName)                'ﾊﾟｰﾂ名
                    vsfInvList.SetData(llngCnt, CMlngInvListColLotId, .strLotID)                      '在庫ﾛｯﾄID
                    
                    '@入力可とするか
                    If lblnInput = True Then
                        '@入力可の場合は在庫数を表示
                        vsfInvList.Cols(CMlngInvListColInvQty).Visible = True                         '在庫数表示
                        vsfInvList.SetData(llngCnt, CMlngInvListColInvQty, .strChipQty)               '在庫数
                        vsfInvList.SetData(llngCnt, CMlngInvListColUseQty, CPlngNumZero)              '使用数
                        vsfInvList.Enabled = True

                    Else
                        '@入力不可の場合は使用数を表示
                        vsfInvList.Cols(CMlngInvListColInvQty).Visible = False                        '在庫数非表示
                        vsfInvList.SetData(llngCnt, CMlngInvListColInvQty, CPlngNumZero)              '在庫数(一応0で埋めとく)
                        vsfInvList.SetData(llngCnt, CMlngInvListColUseQty, .strChipQty)               '使用数
                        vsfInvList.Enabled = False
                    End If
                    
                    vsfInvList.SetData(llngCnt, CMlngInvListColProdcLotId, .strProdcLotId)            '製造ﾛｯﾄ
                    vsfInvList.Rows(llngCnt).Height = CMvsfInvHeight                                  '高さ
                End With
                
            Next
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInvList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '@↓2019/12/09 (Mon) 13:31:26 T.Oide **************************************************
    '@'関数名：prvInvLotSet
    '@'機　能：
    '@'引　数：なし
    '@'戻り値：
    '@'作成日：2018/11/20 (Tue) 14:43:20 T.Oide
    '@'更新日：2018/11/20 (Tue) 14:43:20
    '@'備　考：
    '@Private Sub prvInvLotSet()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With vsfSlot
    '@
    '@        '@ﾍｯﾀﾞの場合
    '@        If .Row < .FixedRows Or .Col < .FixedCols Then
    '@            Exit Sub
    '@        End If
    '@
    '@        '@列で分岐
    '@        Select Case .Col
    '@
    '@            '@在庫ﾛｯﾄID、ﾍﾞﾝﾀﾞｰ
    '@            Case CMlngSlotColInvLotId, CMlngSlotColBender
    '@
    '@                '@品確、ﾓﾆﾀｰの場合、在庫をｸﾞﾘｯﾄﾞに表示/非表示する
    '@                '@品確、ﾓﾆﾀｰの設定で、背景色(白)で、ﾍﾞﾝﾀﾞｰ(在庫ﾛｯﾄID)選択済か
    '@
    '@                If optClass(CMstrQuMo).Value = True And _
    '@                   .Cell(flexcpBackColor, .Row, CMlngSlotColBender) = CPlngEnableTrueColor And _
    '@                   lblInvLotID.Caption <> vbNullString Then
    '@
    '@                    '@ｸﾞﾘｯﾄﾞでﾍﾞﾝﾀﾞｰ(在庫ﾛｯﾄID)設定済か
    '@
    '@                    If .Cell(flexcpText, .Row, CMlngSlotColBender) = vbNullString Then
    '@
    '@                        '@選択した在庫ﾛｯﾄID、ﾍﾞﾝﾀﾞｰをｸﾞﾘｯﾄﾞに設定
    '@                        .Cell(flexcpText, .Row, CMlngSlotColInvLotId) = lblInvLotID.Caption                 '在庫ﾛｯﾄID
    '@                        .Cell(flexcpText, .Row, CMlngSlotColBender) = lblVenderName.Caption                 'ﾍﾞﾝﾀﾞｰ
    '@
    '@                        .Cell(flexcpText, .Row, CMlngSlotColProductionLotId) = lblProductionLotID.Caption   '製造ﾛｯﾄID
    '@                        .Cell(flexcpText, .Row, CMlngSlotColQty) = mstrQuMoChipNum                          'ﾁｯﾌﾟ数
    '@                    Else
    '@                        '@ｸﾞﾘｯﾄﾞのﾍﾞﾝﾀﾞｰ(在庫ﾛｯﾄID)をｸﾘｱ
    '@                        .Cell(flexcpText, .Row, CMlngSlotColInvLotId) = vbNullString                        '在庫ﾛｯﾄIDｸﾘｱ
    '@                        .Cell(flexcpText, .Row, CMlngSlotColBender) = vbNullString                          'ﾍﾞﾝﾀﾞｰｸﾘｱ
    '@                        .Cell(flexcpText, .Row, CMlngSlotColProductionLotId) = vbNullString                 '製造ﾛｯﾄID
    '@                        .Cell(flexcpText, .Row, CMlngSlotColQty) = vbNullString                             'ﾁｯﾌﾟ数ｸﾘｱ
    '@                    End If
    '@
    '@                End If
    '@
    '@        End Select
    '@
    '@    End With
    '@
    '@    '@ｵﾌﾞｼﾞｪｸﾄ有効/無効ﾁｪｯｸ
    '@    prvEnable_Chk
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvInvLotSet"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2019/12/09 (Mon) 13:31:26 T.Oide **************************************************

    '関数名：prvEnable_Chk
    '機　能：有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2019/11/26 (Tue) 17:31:18 T.Oide
    '備　考：
    Private Sub prvEnable_Chk()
        
        Dim llngCnt             As Integer
    '@↓2019/11/26 (Tue) 17:31:07 T.Oide **************************************************
        Dim lbnFind             As Boolean
    '@↑2019/11/26 (Tue) 17:31:07 T.Oide **************************************************

        Try

            '@------------------
            '@「Aｷｬﾘｱ区分(ｵﾌﾟｼｮﾝﾎﾞﾀﾝ)」
            '@------------------
            If mtypACarrierState.lngATrayListCnt = 0 And _
               mtypACarrierState.strEmptyFlag = CPstrFlagOn And _
               mtypACarrierState.strCleanFlag = CPstrFlagOff Then

                '@有効化
                fraClass.Enabled = True
                optClass0.Enabled = True
                optClass1.Enabled = True
                optClass2.Enabled = True
                optClass3.Enabled = True
                optClass4.Enabled = True
                '@当面ﾀﾞﾐｰは使わないので無効化
                optClass2.Enabled = False
                optClass3.Enabled = False
                
            Else
            
                '@無効化
                fraClass.Enabled = False
                optClass0.Enabled = False
                optClass1.Enabled = False
                optClass2.Enabled = False
                optClass3.Enabled = False
                optClass4.Enabled = False
            End If

        '@↓2019/11/21 (Thu) 10:15:16 T.Oide **************************************************
        '@    '@------------------
        '@    '@「在庫ﾛｯﾄ選択」ﾍﾞﾝﾀﾞｰが設定済なら有効
        '@    '@------------------
        '@
        '@    If lblVenderName.Caption <> vbNullString Then
        '@        cmdVenderLot.Enabled = True
        '@    Else
        '@        cmdVenderLot.Enabled = False
        '@    End If
        '@↑2019/11/21 (Thu) 10:15:16 T.Oide **************************************************
            
            '@------------------
            '@「閉じる」常に有効
            '@------------------
            cmdClose.Enabled = True

            '@------------------
            '@「Aｷｬﾘｱ洗浄」空の場合
            '@------------------
            If lblEmptyFlag.Text = "空" Then
                cmdCarrierClean.Enabled = True      '有効化
            Else
                cmdCarrierClean.Enabled = False     '無効化
            End If

            '@------------------
            '@ATRAY取外
            '@------------------
            If mtypACarrierState.lngATrayListCnt > 0 Then
                cmdATrayClear.Enabled = True
            Else
                cmdATrayClear.Enabled = False
            End If

            '@------------------
            '@「SLOT」「SCAN全取消」「AﾄﾚｲIDSCAN」
            '@------------------
            '@Aｷｬﾘｱ区分が有効か
            If fraClass.Enabled = True Then
                
                '@有効化
                vsfSlot.Enabled = True
                cmdScanClear.Enabled = True
                txtATrayId.Enabled = True
            Else
                
                '@無効化
                vsfSlot.Enabled = False
                cmdScanClear.Enabled = False
                txtATrayId.Enabled = False
            End If

        '@↓2019/11/21 (Thu) 10:27:48 T.Oide **************************************************
        '@    '@------------------
        '@    '@部材選択ﾌﾚｰﾑ
        '@    '@------------------
        '@    If mtypACarrierState.lngATrayListCnt > 0 Then
        '@        frmInventry.Enabled = False
        '@    Else
        '@        frmInventry.Enabled = True
        '@    End If
        '@↑2019/11/21 (Thu) 10:27:48 T.Oide **************************************************

            '@------------------
            '@確定
            '@------------------
            '@情報が入力済みか
            With vsfSlot
            
                For llngCnt = 1 To .Rows.Count - 1
                
                    '@背景色(白)&ATrayがNULL
                    If .GetCellRange(llngCnt, CMlngSlotColATrayId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) And _
                       .GetData(llngCnt, CMlngSlotColATrayId) = vbNullString Then
                        
                        cmdRegist.Enabled = False   '無効化
                        Exit Sub
                    End If

        '@↓2019/11/26 (Tue) 16:43:06 T.Oide **************************************************
        '@            '@品確、ﾓﾆﾀｰの場合で、「ﾍﾞﾝﾀﾞｰ」「在庫ﾛｯﾄID」がNULLの背景白の場合、
        '@            If optClass(CMstrQuMo).Value = True And _
        '@               .Cell(flexcpBackColor, llngCnt, CMlngSlotColBender) = CPlngEnableTrueColor And _
        '@               .Cell(flexcpText, llngCnt, CMlngSlotColBender) = vbNullString Then
        '@
        '@                cmdRegist.Enabled = False   '無効化
        '@                Exit Sub
        '@            End If
        '@↑2019/11/26 (Tue) 16:43:06 T.Oide **************************************************

                Next
            End With
            
        '@↓2019/11/26 (Tue) 17:28:54 T.Oide **************************************************
            '@QU,MOの場合
            If optClass4.Checked = True Then
                With vsfInvList
                    lbnFind = False
                    '@部材のｸﾞﾘｯﾄﾞをﾙｰﾌﾟ
                    For llngCnt = 1 To .Rows.Count - 1
                        '@部材の数量を0以外を入力済か
                        If .GetData(llngCnt, CMlngInvListColUseQty) <> CPlngNumZero Then
                            lbnFind = True
                            Exit For
                        End If
                    Next
                    
                End With
                
                '@全て0だったか
                If lbnFind = False Then
                    cmdRegist.Enabled = False   '無効化
                    Exit Sub
                End If
                
            End If
        '@↑2019/11/26 (Tue) 17:28:54 T.Oide **************************************************
            
            
            '@ATray数0「未登録」
            If mtypACarrierState.lngATrayListCnt = 0 Then
                cmdRegist.Enabled = True            '有効化
            Else
                cmdRegist.Enabled = False           '無効化
            End If

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEnable_Chk"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraClass.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfInvList.BeforeDoubleClick, vsfSlot.BeforeDoubleClick

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
            'gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfInvList.KeyDownEdit, vsfSlot.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfInvList.SetupEditor, vsfSlot.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 9
            End If
            'NSYS BeforeEditから移設
            If sender.Name = vsfInvList.Name Then
                 '@使用数の最大値を5桁にする(使用数しか編集出来ないので特に列の設定はしていない)
                 With vsfInvList
                     CType(.Editor, Textbox).MaxLength = CMvsfInvUseMaxLen
                 End With
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：flexGrid_Leave
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽｱｳﾄ処理
    '引　数：sender：ｲﾍﾞﾝﾄ発生元
    '　　　：e     ：ｲﾍﾞﾝﾄｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2020/04/20 (Mon) 15:00:00 NSYS
    '備　考：
    Private Sub flexGrid_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlot.Leave

        Try

            With CType(sender, C1FlexGrid)
                .AllowEditing = False
            End With

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "flexGrid_Leave"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：vsfSlot_GotFocus
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽin処理
    '引　数：なし
    '戻り値：
    '作成日：2020/04/20 (Mon) 15:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flexGrid_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlot.Enter

        Try

            '@グリッド選択呼出し
            Call vsfSlot_EnterCell(sender, e)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "flexGrid_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

End Class
