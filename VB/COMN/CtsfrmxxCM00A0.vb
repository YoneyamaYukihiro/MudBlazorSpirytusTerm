'ﾌｧｲﾙ名：xxCM00A0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CFKI作業終了
'作成日：2004/06/25 (Fri) 15:30:00 H.Wajima
'更新日：2009/07/07 (Tue) 09:50:16 N.Kojima
'備　考：
'　　　：2004/10/27 (Wed) 15:08:18 S.Deguchi    不具合改善№167の対応でﾒｯｾｰｼﾞの引数追加(機能/ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ変更)
'　　　：2005/01/17 (Mon) 13:13:00 S.Deguchi    不具合改善№136対応でｷｬﾘｱIDValidate処理修正
'　　　：2005/02/07 (Mon) 10:34:19 S.Deguchi    不具合改善№465対応でｽﾛｯﾄﾏｯﾌﾟの表示を他PGへ合わせる処理を追加
'　　　：2005/04/01 (Fri) 15:15:51 S.Deguchi    確定処理で数量入力にｶﾝﾏ編集解除処理を追加
'　　　：2005/08/31 (Wed) 16:44:37 S.Deguchi    On Error/SetFocus対応
'　　　：2007/07/27 (Fri) 16:18:26 N.Kasai      ｿｰｽ整備
'　　　：2009/06/29 (Mon) 11:46:29 Y.Yoneyama   無機対応
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00A0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00A0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00A0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00A0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00A0)
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
    '@↓2009/07/07 (Tue) 09:51:01 N.Kojima **************************************************
    'Private Const CMstrLocalVersion                 As String = "07.01"                 '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                 As String = "08.00"                 '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2009/07/07 (Tue) 09:51:01 N.Kojima **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00E0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_cfkilotinfoVer           As String = "01.02"                 'CFKIﾛｯﾄ情報取得
    Private Const CMstrmas_chipcountVer             As String = "02.00"                 'ﾊﾟﾚｯﾄﾁｯﾌﾟ合計数取得
    Private Const CMstrlot_tpallotinfoVer           As String = "01.00"                 'TPAL編成ﾛｯﾄ情報取得
    '@↓2009/06/30 (Tue) 12:01:22 Y.Yoneyama **************************************************
    Private Const CMstrlot_cfkimoveVer              As String = "02.00"                 'CFKI作業入力要求
    '@↑2009/06/30 (Tue) 12:01:22 Y.Yoneyama **************************************************
    Private Const CMstrcarrcurstateVer              As String = "05.02"                 'ｷｬﾘｱ状態確認

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMstrGridFontName                 As String = "ＭＳ ゴシック"
    Private Const CMlngGridFontSize                 As Integer = 11                        'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridTitleHeight              As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                As Integer = 18                        '1明細の高さ
    Private Const CMlngGrid3DBlank                  As Integer = 2                         'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngGridRowTitle                 As Integer = 0                         'ﾀｲﾄﾙ行（行）
    Private Const CMlngGridScrollBarWidth           As Integer = 16                        '縦ｽｸﾛｰﾙﾊﾞｰの幅
    Private Const CMlngGridUnChoosingListIndex      As Integer = -1                        'ｸﾞﾘｯﾄﾞ未選択

    '@金属ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの定数宣言
    Private Const CMlngMetalGridFixedCols           As Integer = 1                         'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngMetalGridFixedRows           As Integer = 1                         'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngMetalGridPageRows            As Integer = 18                        '1ﾍﾟｰｼﾞのｾﾙの行数
    Private Const CMlngMetalGridCols                As Integer = 4                         '列数

    '@金属ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの定数宣言（ColWidth）
    Private Const CMlngMetalGridColWidthNo          As Integer = 29                        'No
    Private Const CMlngMetalGridColWidthPaletteID   As Integer = 100                       'ﾊﾟﾚｯﾄID
    Private Const CMlngMetalGridColWidthThickness   As Integer = 20                        '板厚
    Private Const CMlngMetalGridColWidthChip        As Integer = 0                         'ﾁｯﾌﾟ

    '@金属ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの定数宣言（ｶﾗﾑ）
    Private Const CMlngMetalGridColNo               As Integer = 0                         'No
    Private Const CMlngMetalGridColPaletteID        As Integer = 1                         'ﾊﾟﾚｯﾄID
    Private Const CMlngMetalGridColThickness        As Integer = 2                         '板厚
    Private Const CMlngMetalGridColChip             As Integer = 3                         'ﾁｯﾌﾟ

    '@金属ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrMetalGridTitleNo             As String = "№"
    Private Const CMstrMetalGridTitlePaletteID      As String = "パレットID"
    Private Const CMstrMetalGridTitleThickness      As String = "厚"
    Private Const CMstrMetalGridTitleChip           As String = "チップ"

    '@金属ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの幅
    Private Const CMlngMetalGridWidth               As Integer = CMlngMetalGridColWidthNo _
                                                    + CMlngMetalGridColWidthPaletteID _
                                                    + CMlngMetalGridColWidthThickness _
                                                    + CMlngMetalGridColWidthChip _
                                                    + CMlngGrid3DBlank _
                                                    + CMlngGridScrollBarWidth

    '@金属ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngMetalGridHeight              As Integer = (CMlngGridTitleHeight _
                                                    * CMlngMetalGridFixedRows) _
                                                    + (CMlngGridRowHeight _
                                                    * CMlngMetalGridPageRows) _
                                                    + CMlngGrid3DBlank

    '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの定数宣言
    Private Const CMlngResinGridFixedCols           As Integer = 0                         'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngResinGridFixedRows           As Integer = 1                         'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngResinGridPageRows            As Integer = 7                         '1ﾍﾟｰｼﾞのｾﾙの行数
    '@↓2009/06/29 (Mon) 16:08:15 Y.Yoneyama **************************************************
    Private Const CMlngResinGridCols                As Integer = 8                         '列数
    '@↑2009/06/29 (Mon) 16:08:15 Y.Yoneyama **************************************************

    '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの定数宣言（ColWidth）
    Private Const CMlngResinGridColWidthNo          As Integer = 43                        'No
    Private Const CMlngResinGridColWidthCarrierID   As Integer = 101                       'ｷｬﾘｱID
    Private Const CMlngResinGridColWidthTPALLotID   As Integer = 123                       'TPALﾛｯﾄID
    Private Const CMlngResinGridColWidthRework      As Integer = 115                       'ﾘﾜｰｸ数
    Private Const CMlngResinGridColWidthCarrying    As Integer = 64                        '詰め数
    '@↓2009/06/29 (Mon) 16:04:19 Y.Yoneyama **************************************************
    Private Const CMlngResinGridColWidthCfArea      As Integer = 72                        'CF左右区分
    Private Const CMlngResinGridColWidthCfAreaCode  As Integer = 72                        'CF左右区分ｺｰﾄﾞ
    '@↑2009/06/29 (Mon) 16:04:19 Y.Yoneyama **************************************************
    Private Const CMlngResinGridColWidthComments    As Integer = 200                       'ﾛｯﾄｺﾒﾝﾄ
    Private Const CMlngResinGridFrozenCols          As Integer = 2                         '静止列

    '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの定数宣言（ｶﾗﾑ）
    Private Const CMlngResinGridColNo               As Integer = 0                         'No
    Private Const CMlngResinGridColCarrierID        As Integer = 1                         'ｷｬﾘｱID
    Private Const CMlngResinGridColTPALLotID        As Integer = 2                         'TPALﾛｯﾄID
    Private Const CMlngResinGridColRework           As Integer = 3                         'ﾘﾜｰｸ数
    Private Const CMlngResinGridColCarrying         As Integer = 4                         '詰め数
    '@↓2009/06/29 (Mon) 14:54:24 Y.Yoneyama **************************************************
    Private Const CMlngResinGridColCfArea           As Integer = 5                         'CF左右区分
    Private Const CMlngResinGridColCfAreaCode       As Integer = 6                         'CF左右区分ｺｰﾄﾞ
    '@↑2009/06/29 (Mon) 14:54:24 Y.Yoneyama **************************************************
    Private Const CMlngResinGridColComments         As Integer = 7                         'ﾛｯﾄｺﾒﾝﾄ

    '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrResinGridTitleNo             As String = "№"
    Private Const CMstrResinGridTitleCarrierID      As String = "キャリアID"
    Private Const CMstrResinGridTitleTPALLotID      As String = "TPALロットID"
    Private Const CMstrResinGridTitleRework         As String = "リワーク回数"
    Private Const CMstrResinGridTitleCarrying       As String = "詰め数"
    '@↓2009/06/29 (Mon) 14:54:28 Y.Yoneyama **************************************************
    Private Const CMstrResinGridTitleCfArea         As String = "左右区分"
    Private Const CMstrResinGridTitleCfAreaCode     As String = "左右区分ｺｰﾄﾞ"
    '@↑2009/06/29 (Mon) 14:54:28 Y.Yoneyama **************************************************
    Private Const CMstrResinGridTitleComments       As String = "ロットコメント"

    '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの幅
    Private Const CMlngResinGridWidth               As Integer = CMlngResinGridColWidthNo _
                                                    + CMlngResinGridColWidthCarrierID _
                                                    + CMlngResinGridColWidthTPALLotID _
                                                    + CMlngResinGridColWidthRework _
                                                    + CMlngResinGridColWidthCarrying _
                                                    + CMlngGrid3DBlank

    '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngResinGridHeight              As Integer = (CMlngGridTitleHeight _
                                                    * CMlngResinGridFixedRows) _
                                                    + (CMlngGridRowHeight _
                                                    * CMlngResinGridPageRows) _
                                                    + 3 _
                                                    + CMlngGridScrollBarWidth

    '@↓2009/06/29 (Mon) 13:20:47 Y.Yoneyama **************************************************
    '@CF左右区分ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngComboDispCols                As Integer = 1                         '表示列数
    Private Const CMlngComboColAreaName             As Integer = 0                         '区分名列
    Private Const CMlngComboColAreaCode             As Integer = 1                         '区分ｺｰﾄﾞ列
    Private Const CMlngComboFontSize                As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboGridFontSize            As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight               As Integer = 22                        '行の高さ
    Private Const CMlngComboDefaultIndex            As Integer = 0                         'ｲﾝﾃﾞｯｸｽ初期値

    Private Const CMstrCfSelectNameNone             As String = "区分なし"
    Private Const CMstrCfSelectNameLeft             As String = "左"
    Private Const CMstrCfSelectNameRight            As String = "右"

    Private Const CMstrCfSelectCodeNone             As String = vbNullString
    Private Const CMstrCfSelectCodeLeft             As String = "L"
    Private Const CMstrCfSelectCodeRight            As String = "R"
    '@↑2009/06/29 (Mon) 13:20:47 Y.Yoneyama **************************************************

    '@その他
    Private Const CMstrCarringCountSeparator        As String = "/ "                       '詰め数分母区切り文字
    Private Const CMlngPalettePerCarrierNum         As Integer = 20                        'ｷｬﾘｱあたりのﾊﾟﾚｯﾄ数
    Private Const CMlngResinCarryingMaxByte         As Integer = 6                         '詰数MAXﾊﾞｲﾄ数
    Private Const CMlngMaxDispRow                   As Integer = 6                         'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(金属/樹脂ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mblnFormStartKbn                        As Boolean                          'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動)
    '@↓2009/06/29 (Mon) 14:15:42 Y.Yoneyama **************************************************
    Private mstrCfAreaSel                           As String                           'CF区分選択
    '@↑2009/06/29 (Mon) 14:15:42 Y.Yoneyama **************************************************

    '@退避情報
    Private mstrTaihiCarrierID                      As String                           'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrLotLastUpdate                       As String                           'ﾛｯﾄ最終更新日時
    Private mstrResinCarrierID                      As String                           'TPALｷｬﾘｱID
    Private mstrEventName                           As String                           'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
    Private mlngPaletteNum                          As Integer                          'ﾊﾟﾚｯﾄﾁｯﾌﾟ数合計
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ

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
    '======================================Public===========================================
    '関数名：Form_Load
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 10:36:36 S.Deguchi
    '更新日：2004/11/04 (Thu) 12:06:24 T.Kitagawa
    '備　考：2004/11/04 (Thu) 12:06:24 T.Kitagawa　 子画面起動の場合はForm_Loadﾌﾗｸﾞが常に正常になってしまうので,
    '　　　：                                       単体起動のみ設定するように変更
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@単独起動の場合のみ機能ﾊﾞｰｼﾞｮﾝの判定を行う
            If pblnfrmxxCM00A0Kbn = False Then
                '@機能ﾊﾞｰｼﾞｮﾝの判定
                lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00E0, CMstrLocalVersion)
                '@戻り値の判定
                If lblnAns = False Then
                '@異常終了の場合
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    Exit Sub
                End If
            End If

            '@ﾌｫｰﾑ起動区分の設定
            mblnFormStartKbn = pblnfrmxxCM00A0Kbn
                
            '@連携情報の初期化
            With ptypCfkiRenkeiInfo
                .lngChipQuantity = 0                '受入数
                .lngChipCarryingCount = 0           '既詰数
                .lngChipExpenditureCount = 0        '払出数
                .lngChipScrapCount = 0              '不良数
                .lngChipReworkCount = 0             'ﾘﾜｰｸ数
                .lngChipRemainCount = 0             '残数
                .strLotLastUpdate = vbNullString    '最終更新日時
            End With

            '@画面情報の初期化
            Call prvfrmxxCM00A0_Init()
            
            '@ﾎﾞﾀﾝの初期化
            Call prvfrmxxCM00A0_cmbInit()
            
            '@ﾌｫｰﾑ起動区分判定
            If mblnFormStartKbn = False Then
                '@ｷｬﾘｱIDを使用可能
                txtMetalCarrierID.Enabled = True
                txtMetalCarrierID.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                
                '@Form_Loadﾌﾗｸﾞ（正常）
                pblnFormLoad = True
            Else
                '@ｷｬﾘｱIDを使用不可能
                With txtMetalCarrierID
                    .Enabled = True
                    .Locked = True
                    .TabStop = False
                    .BackColor = SystemColors.ControlLight
                    .GotBackColor = SystemColors.ControlLight
                    .GotHighLight = False
                    .Text = ptypCfkiRenkeiInfo.strCarrierId
                End With
                
                '@ｷｬﾘｱIDの自動取得
                Call txtMetalCarrierID_Validate(txtMetalCarrierID,New CancelEventArgs(True))
            End If
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = Me.cmdClose
            
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
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 15:20:04 H.Wajima
    '更新日：2004/11/01 (Mon) 15:11:00 N.Kasai
    '備　考：2004/11/01 (Mon) 15:11:00 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝ押下でのCallか
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾌｫｰﾑ起動区分の確認
            If pblnfrmxxCM00A0Kbn = True Then
                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxCM00A0Kbn = False
            Else
                '@ActInitﾌﾗｸﾞの判定
                If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                    '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                    lblnAnsTerm = pubblnAct_Term
                    If lblnAnsTerm = True Then
                        '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                    End If
                End If
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 15:21:46 H.Wajima
    '更新日：2005/12/05 (Mon) 11:08:25 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 11:08:25 N.Kasai      一覧画面へ戻れない不具合を修正
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑを閉じる。（個別起動はしないので終了関数は呼ばない）
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

    '関数名：cmdLotCommentInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 15:38:20 H.Wajima
    '更新日：2005/12/05 (Mon) 11:00:48 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 11:00:48 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdLotCommentInput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotCommentInput.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@渡すﾃﾞｰﾀを格納
            With frmxxCM00D0.Instance
                .lblCarrierID.Text = txtResinCarrierID.Text      'ｷｬﾘｱID
                .txtLotCommnt.Text = txtResinLotComment.Text     'ﾛｯﾄｺﾒﾝﾄ
                
                '@ﾛｯﾄｺﾒﾝﾄ表示画面を表示
                frmxxCM00D0.Instance.ShowDialog(Me)
                frmxxCM00D0.Instance = Nothing
                
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotCommentInput_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：全部取消ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 15:23:05 H.Wajima
    '更新日：2005/12/05 (Mon) 11:12:19 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 11:12:19 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@単体起動と他画面からの起動で処理を振り分ける
            If txtMetalCarrierID.Locked = False Then
            '@単体起動の場合
                '@画面情報の初期化
                Call prvfrmxxCM00A0_Init()
                '@金属ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtMetalCarrierID)
            Else
                '@画面情報の初期化
                Call prvfrmxxCM00A0_Init(, , True)
                
                '@TPALﾊﾟﾚｯﾄ関連のｺﾝﾄﾛｰﾙの使用可・不可
                txtResinCarrierID.Enabled = True
                txtResinCarryingCount.Enabled = True
                vsfResinPalette.Enabled = True
                
                '@既詰数の初期化
                ptypCfkiRenkeiInfo.lngChipCarryingCount = 0
                
                '@残数の再計算・再表示
                Call prvChipCount_Disp()
                
                '@詰め数の初期化
                Call prvPaletteNum_Init()
                
        '@↓2009/06/29 (Mon) 13:40:44 Y.Yoneyama **************************************************
                '@CF左右区分初期化
                cmbCfArea.ListIndex = CMlngComboDefaultIndex
        '@↑2009/06/29 (Mon) 13:40:44 Y.Yoneyama **************************************************
                
                '@樹脂ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtResinCarrierID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClear_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMetalCarrierID_Change
    '機　能：金属ﾊﾟﾚｯﾄｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 17:08:59 H.Wajima
    '更新日：2004/06/25 (Fri) 17:08:59
    '備　考：
    Private Sub txtMetalCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtMetalCarrierID.Change

        Try
            '@ｷｬﾘｱIDを修正する場合はﾛｯﾄ情報をｸﾘｱする
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxCM00A0_Init(True)
            
            '@ﾎﾞﾀﾝのﾛｯｸ
            Call prvfrmxxCM00A0_cmbInit()
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMetalCarrierID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMetalCarrierID_Validate
    '機　能：金属ﾊﾟﾚｯﾄｷｬﾘｱID入力後処理
    '引　数：Cancel：ﾌｫｰｶｽ移動
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 17:06:11 H.Wajima
    '更新日：2004/11/04 (Thu) 12:16:03 T.Kitagawa
    '備　考：2004/10/04 (Mon) 17:08:52 H.Wajima     pubblnLotTpalLotInfo_Selの戻り値がFalseの場合、ﾒｯｾｰｼﾞ表示後に処理が戻ってくる
    '　　　：                                       はずなので、表示ﾒｯｾｰｼﾞを削除。
    '　　　：                                       (CPstrMsgErr000A 登録済みCFKI作業終了の情報が取得されていません。 システム担当者に連絡して下さい。を削除)
    '　　　：2004/10/27 (Wed) 15:09:56 S.Deguchi    mas_.ChipCountﾒｯｾｰｼﾞの引数にｼｽﾃﾑﾌﾞﾛｯｸ追加
    '　　　：2004/11/04 (Thu) 12:16:03 T.Kitagawa   Form_Loadﾌﾗｸﾞ設定処理を追加
    '　　　：2005/01/17 (Mon) 13:10:24 S.Deguchi    ｽﾛｯﾄﾏｯﾌﾟ情報が0件の場合の処理を追加
    Private Sub txtMetalCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtMetalCarrierID.Validating
        
        Dim ltypLotCfkiLotInfo      As LotCfkiLotinfo
        Dim ltypLotTpalLotInfo      As LotTpalLotInfo       'TPALﾛｯﾄﾘｽﾄ
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrPaletteNum          As String               'ﾊﾟﾚｯﾄﾁｯﾌﾟ数合計

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空ENTERの場合はﾌｫｰｶｽ移動のみ
            If Trim(txtMetalCarrierID.Text) = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtMetalCarrierID.NowByte < txtMetalCarrierID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16, False)
                e.Cancel = True
                'NSYS 自コントロール処理の場合のみフォーカス移動
                If ActiveControl.Name = txtMetalCarrierID.Name Then
                    Call pubSetFocus(txtMetalCarrierID)
                End If
                Exit Sub
            End If
            
            '@CFKIﾛｯﾄ情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行）
            If Trim$(txtMetalCarrierID.Text) <> vbNullString And _
                Len(Trim$(txtMetalCarrierID.Text)) = CPlngCarrierMaxLength And _
                txtMetalCarrierID.Text <> mstrTaihiCarrierID Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                mstrEventName = "txtMetalCarrierID_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@CFKIﾛｯﾄ情報の取得
                lblnAns = pubblnLotCfkilotinfo_Sel(CMstrlot_cfkilotinfoVer, _
                                                   txtMetalCarrierID.Text, _
                                                   ltypLotCfkiLotInfo)
                '@結果判定
                If lblnAns = True Then
                    '@正常終了の場合
                    '@金属ﾊﾟﾚｯﾄのｽﾛｯﾄﾏｯﾌﾟ情報から処理分岐
                    If ltypLotCfkiLotInfo.lngMetalPaletteMapListCnt <> 0 Then
                        '@ｽﾛｯﾄﾏｯﾌﾟが存在する場合
                        '@画面表示処理
                        Call prvfrmxxCM00A0_Disp(ltypLotCfkiLotInfo)
                    
                        '@ｷｬﾘｱID退避（ﾒｯｾｰｼﾞ成功時)
                        mstrTaihiCarrierID = txtMetalCarrierID.Text
                        
                        '@最終更新日時の退避
                        ptypCfkiRenkeiInfo.strLotLastUpdate = ltypLotCfkiLotInfo.strLotLastUpdate
                    Else
                        '@ｽﾛｯﾄﾏｯﾌﾟが存在しない場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                        
                        '@"<TRM4QW>$$金属パレット情報が取得できません。設定を見直してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004Q)
                        '@警告ﾒｯｾｰｼﾞ
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16, False)
                        
                        Exit Sub
                    End If
                    
                    '@樹脂ﾊﾟﾚｯﾄのﾁｯﾌﾟ詰め数を取得する【CPstrCD2S：ﾊﾟﾚｯﾄﾁｯﾌﾟ合計数量取得(樹脂ﾊﾟﾚｯﾄ)】
                    lblnAns = pubblnMasChipCount_Sel(CMstrmas_chipcountVer, _
                                                     CPstrCD2S, _
                                                     ltypLotCfkiLotInfo.strPdId, _
                                                     pstrSBID, _
                                                     lstrPaletteNum)
                    '@結果判定
                    If lblnAns = True Then
                        '@正常終了の場合
                        '@ﾊﾟﾚｯﾄﾁｯﾌﾟ数合計にｷｬﾘｱあたりのﾊﾟﾚｯﾄ数を掛けた値を設定する
                        mlngPaletteNum = lstrPaletteNum * CMlngPalettePerCarrierNum
                        
                        '@Form_Loadﾌﾗｸﾞ（正常）
                        pblnFormLoad = True
                    Else
                        '@異常終了の場合
                        '@ﾊﾟﾚｯﾄﾁｯﾌﾟ数合計に0を設定する
                        mlngPaletteNum = 0
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, mstrEventName)
                        
                        Exit Sub
                    End If
                    
                    '@ﾁｯﾌﾟの受入数が0の場合は、CFKI作業終了が登録済みと判断し、
                    '@登録済みの樹脂ﾊﾟﾚｯﾄの情報を取得する
                    If ltypLotCfkiLotInfo.strChipQuantity = 0 Then
                        '@受入数が0の場合（登録済み）
                        '@登録済み樹脂ﾊﾟﾚｯﾄの情報を取得する
                        lblnAns = pubblnLotTpalLotInfo_Sel(CMstrlot_tpallotinfoVer, _
                                                           mstrTaihiCarrierID, _
                                                           ltypLotTpalLotInfo)
                        '@結果判定
                        If lblnAns = True Then
                            '@正常終了の場合
                            '@取得した情報を画面に表示する
                            Call prvLotTpalLotList_Disp(ltypLotTpalLotInfo)
                            
                            '@残数の再計算・再表示
                            Call prvChipCount_Disp()
                            
                            '@閉じるﾎﾞﾀﾝ以外の画面の項目を操作不能にする
                            Call prvfrmxxCM00A0_cmbInit()
                            
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(Me.Name, mstrEventName)
                                            
                            '@"<TRM0HI>$$このキャリア[%1]はCFKI作業終了が登録済です。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000H, mstrTaihiCarrierID)
                            '@警告ﾒｯｾｰｼﾞ
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16, False)
                        Else
                        '@異常終了の場合
                            '@閉じるﾎﾞﾀﾝ以外の画面の項目を操作不能にする
                            Call prvfrmxxCM00A0_cmbInit()
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, mstrEventName)
                            
                            '@Form_Loadﾌﾗｸﾞ（異常）
                            pblnFormLoad = False
                        End If
                    Else
                        '@受入数が0以外の場合（未登録）
                        '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化（使用可）
                        Call prv_ResinPalette_Init(True)
                        
                        '@ﾛｯﾄｺﾒﾝﾄｺﾋﾟｰ（金属→樹脂）
                        txtResinLotComment.Text = txtMetalLotComment.Text
                        
                        '@詰め数の初期化
                        Call prvPaletteNum_Init()
                                
                        '@Formが表示済みかどうかを判定
                        If Me.Visible = True Then
                            '@表示済みの場合
                            'NSYS 自コントロール処理の場合のみフォーカス移動
                            If ActiveControl.Name = txtMetalCarrierID.Name Then
                                '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱIDへﾌｫｰｶｽ設定
                                Call pubSetFocus(txtResinCarrierID)
                            End If
                        End If
                                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, mstrEventName)
                    End If
                Else
                    '@異常終了の場合
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    '@ﾊｲﾗｲﾄ表示
                    Call pubHighlight(txtMetalCarrierID)
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                End If
            Else
                '@上記以外の場合
                '@入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と同じか判定する
                If txtMetalCarrierID.Text = mstrTaihiCarrierID Then
                    '@入力ｷｬﾘｱIDと前回のｷｬﾘｱIDが同じ場合
                    '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱIDが使用可能かどうかを判定
                    If txtResinCarrierID.Enabled = True Then
                    '@使用可能の場合
                        'NSYS 自コントロール処理の場合のみフォーカス移動
                        If ActiveControl.Name = txtMetalCarrierID.Name Then
                            '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱIDへﾌｫｰｶｽ設定
                            Call pubSetFocus(txtResinCarrierID)
                        End If
                    Else
                    '@使用不能の場合
                        'NSYS 自コントロール処理の場合のみフォーカス移動
                        If ActiveControl.Name = txtMetalCarrierID.Name Then
                            '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽ設定
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMetalCarrierID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMetalLotComment_Change
    '機　能：金属ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/02 (Fri) 09:51:43 N.Kasai
    '更新日：2005/12/02 (Fri)
    '備　考：
    Private Sub txtMetalLotComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtMetalLotComment.Change
        
        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtMetalLotComment, CMlngMaxDispRow, cmdMetalUp, cmdMetalDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMetalLotComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMetalLotComment_KeyUp
    '機　能：金属ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtMetalLotComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMetalLotComment.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtMetalLotComment, CMlngMaxDispRow, cmdMetalUp, cmdMetalDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMetalLotComment_MouseUp
    '機　能：金属ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtMetalLotComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtMetalLotComment.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtMetalLotComment, CMlngMaxDispRow, cmdMetalUp, cmdMetalDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMetalLotComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtResinCarrierID_Change
    '機　能：樹脂ﾊﾟﾚｯﾄｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 14:46:24 H.Wajima
    '更新日：2004/07/05 (Mon) 14:46:24
    '備　考：
    Private Sub txtResinCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtResinCarrierID.Change

        Try
            '@樹脂ﾊﾟﾚｯﾄ項目入力ﾁｪｯｸ
            Call prvResinInput_chk()
            
        '@↓2009/06/29 (Mon) 13:40:44 Y.Yoneyama **************************************************
            '@CF左右区分初期化
            cmbCfArea.ListIndex = CMlngComboDefaultIndex
        '@↑2009/06/29 (Mon) 13:40:44 Y.Yoneyama **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtResinCarrierID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtResinCarrierID_Validate
    '機　能：樹脂ﾊﾟﾚｯﾄｷｬﾘｱID入力後処理
    '引　数：Cancel：ﾌｫｰｶｽ移動
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 15:24:17 H.Wajima
    '更新日：2004/09/28 (Tue) 20:12:50 H.Wajima
    '備　考：2004/09/28 (Tue) 20:12:50 H.Wajima     ｷｬﾘｱID存在ﾁｪｯｸ追加
    '　　　：2005/10/07 (Fri) 12:04:12 S.Deguchi    不具合№2995の対応で,ｷｬﾘｱの状態取得の処理区分を3Zへ変更
    Private Sub txtResinCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtResinCarrierID.Validating
        
        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lblnAns             As Boolean          '戻り値

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空ENTERの場合はﾌｫｰｶｽ移動のみ
            If Trim(txtResinCarrierID.Text) = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDがある場合
            If Trim$(txtResinCarrierID.Text) <> vbNullString Then
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If txtResinCarrierID.NowByte < txtResinCarrierID.ChrMaxByte Then
                    '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16, False)
                    e.Cancel = True
                    Call pubSetFocus(txtResinCarrierID)
                    Exit Sub
                End If

                '@前回ｷｬﾘｱIDのﾁｪｯｸ
                If mstrResinCarrierID = txtResinCarrierID.Text Then
                    '@前回ｷｬﾘｱIDと同じ場合
                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得開始
                mstrEventName = "txtResinCarrierID_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)

                '@ｷｬﾘｱ情報（要求）格納
                With ltypCarrCurstate
                    .strCarrierId = txtResinCarrierID.Text  'TPALｷｬﾘｱID
                    .strClassDivision = CPstrCD3Z           '空ｷｬﾘｱﾁｪｯｸ(CPstrCD3Z:空ｷｬﾘｱ一覧未洗浄可)
                    .strMsgVer = CMstrcarrcurstateVer       'MSGVER
                    .strSbID = pstrSBID                     '処理区分
                    .strCarrierTypeID = CPstrCarrTypeTPAL   'ｷｬﾘｱﾀｲﾌﾟ（判断はできない）
                    .strLotID = lblMetalLotID.Text       'ﾛｯﾄID
                End With

                '@ｷｬﾘｱ状態取得
                lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True)
                '@取得結果確認
                If lblnAns = True Then
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@TPALｷｬﾘｱIDの退避
                    mstrResinCarrierID = txtResinCarrierID.Text
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    '@TPALｷｬﾘｱIDのｸﾘｱ
                    mstrResinCarrierID = vbNullString
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    
                    '@ｾｯﾄﾌｫｰｶｽ処理
                    'NSYS コントロールが自分だった場合
                    If ActiveControl.Name = txtResinCarrierID.Name Then
                        Call pubSetFocus(txtResinCarrierID)
                    End If
                    
                    Exit Sub
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtResinCarrierID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtResinCarryingCount_Change
    '機　能：樹脂ﾊﾟﾚｯﾄ詰め数変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 14:47:39 H.Wajima
    '更新日：2004/07/05 (Mon) 14:47:39
    '備　考：
    Private Sub txtResinCarryingCount_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtResinCarryingCount.Change

        Try
            '@樹脂ﾊﾟﾚｯﾄ項目入力ﾁｪｯｸ
            Call prvResinInput_chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtResinCarryingCount_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdReworkScrap_Click
    '機　能：ﾘﾜｰｸ不良入力ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 15:26:15 H.Wajima
    '更新日：2004/06/30 (Wed) 15:26:15
    '備　考：
    '　　　：2005/01/17 (Mon) 12:41:48 S.Deguchi    ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞを初期化する(引継ぎの場合の為)
    Private Sub cmdReworkScrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReworkScrap.Click
        
        Dim lstrCarrierID       As String

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾌｫｰﾑ起動区分設定
            pblnfrmxxCM00B0Kbn = True
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化
            pblnFormLoad = False
            
            '@対向基板ﾘﾜｰｸ不良画面表示
            frmxxCM00B0.Instance.ShowDialog(Me)
            frmxxCM00B0.Instance = Nothing
            
            '@画面情報を再度取得し直す
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxCM00A0_Init(True)
            
            '@ﾎﾞﾀﾝのﾛｯｸ
            Call prvfrmxxCM00A0_cmbInit()
            
            '@ﾛｯﾄｱｳﾄ処理が行われた場合
            If ptypCfkiRenkeiInfo.strCarrierId = vbNullString Then
                '@ｷｬﾘｱIDを退避
                lstrCarrierID = txtMetalCarrierID.Text
                
                '@初期化
                Call prvfrmxxCM00A0_Init(False, True, False)
                
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
            Else
                '@ｷｬﾘｱIDのValidate処理へ
                Call txtMetalCarrierID_Validate(sender,New CancelEventArgs(True))
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdReworkScrap_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:31:48 S.Deguchi
    '更新日：2004/05/28 (Fri) 11:35:23 N.Kasai
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
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

            Select Case ActiveControl.Name
                Case txtMetalCarrierID.Name
                    '@金属ﾊﾟﾚｯﾄｷｬﾘｱIDの場合
                    '@ｷｰｺｰﾄﾞの判定
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@Enterｷｰの場合
                            Call txtMetalCarrierID_Validate(sender,New CancelEventArgs(False))
                            e.Handled = True
                    End Select
                
                Case Else
                    Select Case e.KeyCode
                        '@上記以外のEnterｷｰの場合
                        Case Keys.Return
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

    '関数名：cmdMove_Click
    '機　能：>ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 08:52:25 H.Wajima
    '更新日：2004/07/05 (Mon) 08:52:25
    '備　考：
    Private Sub cmdMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Click

        Dim lstrItem        As String       'ｸﾞﾘｯﾄﾞ追加文字列
        Dim lstrAddItem()   As String       'ｸﾞﾘｯﾄﾞ追加文字列配列

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfResinPalette
                '@既に入力されたｷｬﾘｱIDかどうかを判定
                If .FindRow(txtResinCarrierID.Text, .Rows.Fixed, CMlngResinGridColCarrierID, False) <> CMlngGridUnChoosingListIndex Then
                    '@入力されたｷｬﾘｱIDと一致する行がある場合
                    
                    '@"<TRM0CW>$$キャリアIDが重複しています。設定を見直してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000C)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16, False)
                    '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtResinCarrierID)
                    
                    Exit Sub
                End If
                
                '@配列の初期化
                ReDim lstrAddItem(CMlngResinGridColNo To CMlngResinGridColComments)
                
                '@描画の停止
                .Redraw = False
                '@№番号
                lstrAddItem(CMlngResinGridColNo) = CStr(.Rows.Count - .Rows.Fixed) + 1
                
                '@ｷｬﾘｱID
                lstrAddItem(CMlngResinGridColCarrierID) = txtResinCarrierID.Text
                
                '@TPALﾛｯﾄID
                lstrAddItem(CMlngResinGridColTPALLotID) = vbNullString
                
                '@ﾘﾜｰｸ数
                lstrAddItem(CMlngResinGridColRework) = lblMetalRework.Text
                
                '@詰め数
                If IsNumeric(txtResinCarryingCount.Text) Then
                    lstrAddItem(CMlngResinGridColCarrying) = FormatNumber(CLng(txtResinCarryingCount.Text), 0)
                Else
                    lstrAddItem(CMlngResinGridColCarrying) = txtResinCarryingCount.Text
                End If
                
        '@↓2009/06/29 (Mon) 14:55:50 Y.Yoneyama **************************************************
                '@CF左右区分
                Select Case mstrCfAreaSel
                    
                    '@CF左
                    Case CMstrCfSelectCodeLeft
                        lstrAddItem(CMlngResinGridColCfArea) = CMstrCfSelectNameLeft
                        lstrAddItem(CMlngResinGridColCfAreaCode) = CMstrCfSelectCodeLeft
                    
                    '@CF右
                    Case CMstrCfSelectCodeRight
                        lstrAddItem(CMlngResinGridColCfArea) = CMstrCfSelectNameRight
                        lstrAddItem(CMlngResinGridColCfAreaCode) = CMstrCfSelectCodeRight
                    
                    '@CF区分なし
                    Case Else
                        lstrAddItem(CMlngResinGridColCfArea) = CMstrCfSelectNameNone
                        lstrAddItem(CMlngResinGridColCfAreaCode) = CMstrCfSelectCodeNone
                
                End Select
        '@↑2009/06/29 (Mon) 14:55:50 Y.Yoneyama **************************************************
                
                '@ﾛｯﾄｺﾒﾝﾄ
                lstrAddItem(CMlngResinGridColComments) = txtResinLotComment.Text
                
                '@ｸﾞﾘｯﾄﾞ追加文字列の編集
                lstrItem = Join(lstrAddItem, vbTab)
                
                '@ｸﾞﾘｯﾄﾞに行を追加
                .AddItem (lstrItem)

                'NSYS 追加行の書式設定
                Dim newStyle = vsfResinPalette.Styles.Add("CustomStyle_VsfResinPalette_DataRow")
                Dim cellRange = vsfResinPalette.GetCellRange(vsfResinPalette.Rows.Count - 1 ,0 , vsfResinPalette.Rows.Count - 1, vsfResinPalette.Cols.Count - 1)
                newStyle.ForeColor = SystemColors.WindowText
                newStyle.BackColor = SystemColors.Window
                cellRange.Style = newStyle
                
                '@ﾀﾌﾞｷｰでﾌｫｰｶｽを取得する
                .TabStop = True
                
                '@自動調整の対象を列幅に設定
                '.AutoSizeMode = flexAutoSizeColWidth
                
                '@列幅を自動調整
                .AutoSizeCol(CMlngResinGridColComments, 6)
                
                '@行の高さ
                .Rows(.Rows.Count - 1).Height = CMlngGridRowHeight
                
                '@描画の再開
                .Redraw = True
            End With
            
            '@ﾁｯﾌﾟ情報の計算
            With ptypCfkiRenkeiInfo
                '@既詰数の加算
                .lngChipCarryingCount = .lngChipCarryingCount + CLng(txtResinCarryingCount.Text)
            End With
            
            '@残数の再計算・再表示
            Call prvChipCount_Disp()
            
            '@配列の初期化
            Erase lstrAddItem
            
            '@樹脂ﾊﾟﾚｯﾄ入力項目の初期化
            '@ｷｬﾘｱID
            txtResinCarrierID.Text = vbNullString
            
            '@詰め数
            txtResinCarryingCount.Text = vbNullString
            
            '@詰め数分母
            lblResinCarryingCountDenominator.Text = vbNullString
            
            '@樹脂ﾊﾟﾚｯﾄ項目入力ﾁｪｯｸ
            Call prvResinInput_chk()

            '@詰め数の初期化
            Call prvPaletteNum_Init()
            
            '@確定ﾎﾞﾀﾝの判定
            If cmdEnter.Enabled = True Then
                '@確定ﾎﾞﾀﾝが押せるとき
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄする
                Call pubSetFocus(cmdEnter)
            Else
                '@確定ﾎﾞﾀﾝが押せないとき
                '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱIDにﾌｫｰｶｽをｾｯﾄする
                Call pubSetFocus(txtResinCarrierID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMove_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRemove_Click
    '機　能：<ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 08:52:41 H.Wajima
    '更新日：2005/12/05 (Mon) 10:59:47 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 10:59:47 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRemove.Click

        Dim llngCnt                                 As Integer                          '汎用ｶｳﾝﾀ
        Dim lstrResinCarryingCount                  As String                           '詰め数

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfResinPalette
                '@描画の停止
                .Redraw = False
                
                '@ﾁｯﾌﾟ情報の計算
                With ptypCfkiRenkeiInfo
                    '@既詰数の減算
                    .lngChipCarryingCount = .lngChipCarryingCount _
                                          - CLng(vsfResinPalette.GetData(vsfResinPalette.Row, CMlngResinGridColCarrying))
                End With
                
                '@残数の再計算・再表示
                Call prvChipCount_Disp()
                
                '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱIDの設定
                txtResinCarrierID.Text = .GetData(.Row, CMlngResinGridColCarrierID)
                
                '@ﾛｯﾄｺﾒﾝﾄの設定
                txtResinLotComment.Text = .GetData(.Row, CMlngResinGridColComments)
                
                '@詰め数の保存
                lstrResinCarryingCount = .GetData(.Row, CMlngResinGridColCarrying)
                
        '@↓2009/06/29 (Mon) 16:16:52 Y.Yoneyama **************************************************
                For llngCnt = 0 To cmbCfArea.ListCount
                    '@ｺﾝﾎﾞﾎﾞｯｸｽのﾘｽﾄ検索
                    cmbCfArea.ListIndex = llngCnt
                    
                    '@該当ﾘｽﾄがあれば終了
                    If cmbCfArea.Value = .GetData(.Row, CMlngResinGridColCfAreaCode) Then
                        Exit For
                    End If
                Next
        '@↑2009/06/29 (Mon) 16:16:52 Y.Yoneyama **************************************************
                
                '@選択されている行を削除する
                .RemoveItem (.Row)
                
                '@ﾀｲﾄﾙ行だけの場合
                If .Rows.Fixed = .Rows.Count Then
                    '@詰め数の初期化
                    Call prvPaletteNum_Init()
                    
                    '@詰め数の設定
                    txtResinCarryingCount.Text = lstrResinCarryingCount
                    
                    '@描画の再開
                    .Redraw = True
                    
                    '@ﾀﾌﾞｷｰでﾌｫｰｶｽを取得しない
                    .TabStop = False
                        
                    '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱIDにﾌｫｰｶｽをｾｯﾄする
                    Call pubSetFocus(txtResinCarrierID)
                    
                    Exit Sub
                End If
                
                '@明細行のﾙｰﾌﾟ
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@№を振りなおす
                    .SetData(llngCnt, CMlngResinGridColNo, CStr(llngCnt))
                Next llngCnt
                
                '@自動調整の対象を列幅に設定
                '.AutoSizeMode = flexAutoSizeColWidth
                
                '@列幅を自動調整
                .AutoSizeCol(CMlngResinGridColComments, 6)
                
                '@描画の再開
                .Redraw = True
           
                '@ﾀﾌﾞｷｰでﾌｫｰｶｽを取得する
                .TabStop = True
            End With
            
            '@詰め数の初期化
            Call prvPaletteNum_Init()
            
            '@詰め数の設定
            txtResinCarryingCount.Text = lstrResinCarryingCount
            
            '@樹脂ﾊﾟﾚｯﾄ項目入力ﾁｪｯｸ
            Call prvResinInput_chk()
            
            '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱIDにﾌｫｰｶｽをｾｯﾄする
            Call pubSetFocus(txtResinCarrierID)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRemove_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMetalUp_Click
    '機　能：金属ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 13:47:23 H.Wajima
    '更新日：2005/12/05 (Mon) 08:51:33 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 08:51:33 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMetalUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMetalUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtMetalLotComment, CMlngMaxDispRow, cmdMetalUp, cmdMetalDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMetalUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMetalDown_Click
    '機　能：金属ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 13:47:21 H.Wajima
    '更新日：2005/12/05 (Mon) 08:53:03 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 08:53:03 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdMetalDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMetalDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtMetalLotComment, CMlngMaxDispRow, cmdMetalUp, cmdMetalDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMetalDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdResinUp_Click
    '機　能：樹脂ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 13:47:29 H.Wajima
    '更新日：2005/12/05 (Mon) 09:06:14 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 09:06:14 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdResinUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdResinUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtResinLotComment, CMlngMaxDispRow, cmdResinUp, cmdResinDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdResinUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdResinDown_Click
    '機　能：樹脂ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 13:47:26 H.Wajima
    '更新日：2005/12/05 (Mon) 09:07:14 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 09:07:14 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdResinDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdResinDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtResinLotComment, CMlngMaxDispRow, cmdResinUp, cmdResinDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdResinDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEnter_Click
    '機　能：確定ﾎﾞﾀﾝｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/06 (Tue) 14:02:39 H.Wajima
    '更新日：2004/07/06 (Tue) 14:02:39
    '備　考：
    '　　　：2005/04/01 (Fri) 15:15:51 S.Deguchi    確定処理で数量入力にｶﾝﾏ編集解除処理を追加
    Private Sub cmdEnter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEnter.Click
        
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim llngRow                 As Integer              'ｸﾞﾘｯﾄﾞ行番号格納
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotCfkiMove         As LotCfkiMove          'CFKI作業入力要求構造体
        Dim ltypLotCfkiMoveAns      As LotCfkiMoveAns       'CFKI作業入力要求応答構造体
        Dim ltypLotCfkiLotInfo      As LotCfkiLotinfo       'CFKIﾛｯﾄ情報取得構造体

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

            mstrEventName = "cmdEnter_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)

            '@CFKI作業入力要求ﾃﾞｰﾀ格納
            With ltypLotCfkiMove
                .strSbID = pstrSBID                                                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierID1 = ptypCfkiRenkeiInfo.strCarrierId                                                '移載元ｷｬﾘｱID
                .strLotLastUpdate = ptypCfkiRenkeiInfo.strLotLastUpdate                                         '最終更新日時

                '@移載先ｷｬﾘｱﾏｯﾌﾟの初期化
                'ReDim .typCfkiCarrierList(vsfResinPalette.Rows.Fixed To vsfResinPalette.Rows.Count - 1)
                .typCfkiCarrierList = New List(Of CfkiCarrierList)

                '@移載先ｷｬﾘｱ数の設定
                .lngCfkiCarrierListCnt = vsfResinPalette.Rows.Count - vsfResinPalette.Rows.Fixed

                '@移載先のｷｬﾘｱ数分ﾙｰﾌﾟ
                For llngCnt = vsfResinPalette.Rows.Fixed To vsfResinPalette.Rows.Count - 1

                    'NSYS 編集用構造体初期化
                    Dim typCfkiCarrierListTmp As CfkiCarrierList = New CfkiCarrierList 

                    With typCfkiCarrierListTmp
                        .strCarrierID2 = vsfResinPalette.GetData(llngCnt, CMlngResinGridColCarrierID)  'ｷｬﾘｱID
                        '詰め数
                        If IsNumeric(vsfResinPalette.GetData(llngCnt, CMlngResinGridColCarrying)) Then
                            .strNum = Format$(CLng(vsfResinPalette.GetData(llngCnt, CMlngResinGridColCarrying)), CPstrNoKanmaFormat)
                        Else
                            .strNum = vsfResinPalette.GetData(llngCnt, CMlngResinGridColCarrying)
                        End If

        '@↓2009/06/29 (Mon) 17:31:02 Y.Yoneyama **************************************************
                        .strCfArea = vsfResinPalette.GetData(llngCnt, CMlngResinGridColCfAreaCode)     'CF区分
        '@↑2009/06/29 (Mon) 17:31:02 Y.Yoneyama **************************************************
                        
                        .strComments = vsfResinPalette.GetData(llngCnt, CMlngResinGridColComments)     'ﾛｯﾄｺﾒﾝﾄ
                    End With

                    'NSYS 編集済み構造体を追加
                    .typCfkiCarrierList.Add(typCfkiCarrierListTmp)

                Next llngCnt
                
                .strEmpID = pstrUserID                                                                          '作業者ID
            End With

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnLotCfkiMove_Ins(CMstrlot_cfkimoveVer, _
                                            ltypLotCfkiMove, _
                                            ltypLotCfkiMoveAns)
            '@結果取得
            If lblnAns = True Then
            '@正常終了
                '@応答ﾒｯｾｰｼﾞの内容を格納
                With ltypLotCfkiMoveAns
                    '@応答ﾒｯｾｰｼﾞの件数分ﾙｰﾌﾟ
                    For llngCnt = 0 To .lngTpLotListCnt - 1
                        '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞから移載先ｷｬﾘｱIDが一致する行を取得する
                        llngRow = vsfResinPalette.FindRow(.typTPLotList(llngCnt).strCarrierId ,llngCnt ,CMlngResinGridColCarrierID ,False)
                        
                        If llngRow <> CMlngGridUnChoosingListIndex Then
                        '@一致する行が見つかった場合
                            vsfResinPalette.SetData(llngRow, CMlngResinGridColTPALLotID, .typTPLotList(llngCnt).strTpLotID)
                        Else
                        '@一致する行が見つからなかった場合
                            vsfResinPalette.SetData(llngRow, CMlngResinGridColTPALLotID, vbNullString)
                        End If

                    Next llngCnt
                End With

                '@更新後の最終更新日時を取得する為、CFKIﾛｯﾄ情報取得を行う。
                '@CFKIﾛｯﾄ情報の取得
                lblnAns = pubblnLotCfkilotinfo_Sel(CMstrlot_cfkilotinfoVer, _
                                                   ptypCfkiRenkeiInfo.strCarrierId, _
                                                   ltypLotCfkiLotInfo)
                '@結果判定
                If lblnAns = True Then
                '@正常終了の場合
                    '@最終更新日時の退避
                    ptypCfkiRenkeiInfo.strLotLastUpdate = ltypLotCfkiLotInfo.strLotLastUpdate
                Else
                '@異常終了の場合
                    '@最終更新日時の退避
                    ptypCfkiRenkeiInfo.strLotLastUpdate = vbNullString
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
               
                '@"<TRM0JI>$$CFKI作業を終了しました。キャリア[%1] ロット[%2]$TPALロットは画面の一覧を確認してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000J, ptypCfkiRenkeiInfo.strCarrierId, lblMetalLotID.Text)
                '@ﾒｯｾｰｼﾞ表示
                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16, False)
                '@ｽﾃｰﾀｽ画面に表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱID使用不可
                txtResinCarrierID.Enabled = False
                
                '@樹脂ﾊﾟﾚｯﾄ詰め数使用不可
                txtResinCarryingCount.Enabled = False
                
                '@閉じるﾎﾞﾀﾝ以外を押下不能にする
                Call prvfrmxxCM00A0_cmbInit()
            Else
                '@異常終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEnter_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きｷｬﾘｱ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 13:12:38 S.Deguchi
    '更新日：2004/10/19 (Tue) 16:39:53 Y.Yamagishi
    '備　考：2004/10/19 (Tue) 16:39:53 Y.Yamagishi ｷｬﾘｱﾀｲﾌﾟIDはTPALﾄﾚｲｶｾｯﾄ(CARR0006)のみ
    '　　　：2005/10/06 (Thu) 16:34:39 S.Deguchi    ｷｬﾘｱの洗浄条件設定処理を追加
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@Form_Loadﾌﾗｸﾞ（異常）
            pblnFormLoad = False
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し
            pstrCarrierTypeID = CPstrCarrTypeTPAL
            
            '@ｷｬﾘｱの洗浄条件：未洗浄可
            pstrCleanCondition = CPstrCarrierClean1
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance = New frmxxCM00K0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00K0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@ｷｬﾘｱIDをｾｯﾄ
                txtResinCarrierID.Text = pstrCarrierID
            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtResinCarrierID)

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

    '関数名：txtResinLotComment_Change
    '機　能：樹脂ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 16:55:43 T.Kitagawa
    '更新日：2005/12/02 (Fri) 09:51:43 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 09:51:43 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtResinLotComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtResinLotComment.Change
        
        Try
            Call pubtxtChange_Proc(txtResinLotComment, CMlngMaxDispRow, cmdResinUp, cmdResinDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtResinLotComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtResinLotComment_KeyUp
    '機　能：樹脂ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtResinLotComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtResinLotComment.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtResinLotComment, CMlngMaxDispRow, cmdResinUp, cmdResinDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtResinLotComment_MouseUp
    '機　能：樹脂ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtResinLotComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtResinLotComment.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtResinLotComment, CMlngMaxDispRow, cmdResinUp, cmdResinDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtResinLotComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResinPalette_BeforeUserResize
    '機　能：樹脂ﾊﾟﾚｯﾄﾘｽﾄﾘｻｲｽﾞ前処理
    '引　数：Row：ﾘｻｲｽﾞ行
    '　　　：Col：ﾘｻｲｽﾞ列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 16:25:46 H.Wajima
    '更新日：2004/07/15 (Thu) 16:25:46
    '備　考：
    Private Sub vsfResinPalette_BeforeUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfResinPalette.BeforeResizeColumn, vsfResinPalette.BeforeResizeRow

        Try
            '@ﾘｻｲｽﾞ対象列の判定
            Select Case e.Col
                Case CMlngResinGridColNo
                '@№列の場合
                    '@ﾘｻｲｽﾞしない
                    e.Cancel = True
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfResinPalette_BeforeUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResinPalette_RowColChange
    '機　能：樹脂ﾊﾟﾚｯﾄﾏｯﾌﾟｱｸﾃｨﾌﾞｾﾙ移動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 17:07:53 H.Wajima
    '更新日：2004/07/05 (Mon) 17:07:53
    '備　考：
    Private Sub vsfResinPalette_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfResinPalette.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfResinPalette.Rows.Count <= vsfResinPalette.Rows.Fixed Then
                Return
            End If

            '@樹脂ｷｬﾘｱIDが操作可能の場合
            '@(登録済みのデータを表示している場合は処理しない)
            If txtResinCarrierID.Enabled = True Then
                '@樹脂ﾊﾟﾚｯﾄ項目入力ﾁｪｯｸ
                Call prvResinInput_chk()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfResinPalette_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCfArea_Validate
    '機　能：CF左右区分Validate処理
    '引　数：Cancel：
    '戻り値：なし
    '作成日：2009/06/29 (Mon) 14:20:18 Y.Yoneyama
    '更新日：2009/06/29 (Mon) 14:20:18
    '備　考：
    Private Sub cmbCfArea_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCfArea.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            With cmbCfArea
                '@選択ｺｰﾄﾞ取得
                mstrCfAreaSel = .Value
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCfArea_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCfArea_Change
    '機　能：CF左右区分Change処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/29 (Mon) 16:56:32 Y.Yoneyama
    '更新日：2009/06/29 (Mon) 16:56:32
    '備　考：
    Private Sub cmbCfArea_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCfArea.Change
        
        Try
            '@Validate処理を呼ぶ
            Call cmbCfArea_Validate(sender,New CancelEventArgs(False))
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCfArea_Change"
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

    '関数名：prv_ResinPalette_Init
    '機　能：樹脂ﾊﾟﾚｯﾄ項目初期化処理
    '引　数：lblnEnabled：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 14:41:11 H.Wajima
    '更新日：2005/12/05 (Mon) 09:22:00 N.Kasai
    '備　考：
    '　　　：2005/12/05 (Mon) 09:22:00 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prv_ResinPalette_Init(ByVal lblnEnabled As Boolean)
        
        Dim llngMaxCarringCount                     As Integer                          '詰め数最大値

        Try
            
            Select Case lblnEnabled
                Case False
                    '@ｺﾝﾄﾛｰﾙ使用不可が指定された場合
                    '@金属ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ上ﾎﾞﾀﾝ
                    cmdMetalUp.Enabled = False
                    
                    '@金属ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ下ﾎﾞﾀﾝ
                    cmdMetalDown.Enabled = False
                    
                    '@樹脂ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ上ﾎﾞﾀﾝ
                    cmdResinUp.Enabled = False
                    
                    '@樹脂ﾊﾟﾚｯﾄﾛｯﾄｺﾒﾝﾄ下ﾎﾞﾀﾝ
                    cmdResinDown.Enabled = False
            End Select
            
            '@樹脂ﾊﾟﾚｯﾄｷｬﾘｱID
            txtResinCarrierID.Enabled = lblnEnabled
                
            '@残数の再計算
            Call prvChipCount_Disp()
            
            '@詰め数の判定
            If ptypCfkiRenkeiInfo.lngChipRemainCount < mlngPaletteNum Then
            '@残数よりもﾊﾟﾚｯﾄﾁｯﾌﾟ数合計の方が大きい場合
                '@詰め数最大値に残数を設定する
                llngMaxCarringCount = ptypCfkiRenkeiInfo.lngChipRemainCount
            Else
            '@上記以外の場合
                '@詰め数最大値にﾊﾟﾚｯﾄﾁｯﾌﾟ数合計を設定する
                llngMaxCarringCount = mlngPaletteNum
            End If
            
            '@引数の判定
            If lblnEnabled = True Then
            '@引数がTrueの場合
                '@詰め数
                With txtResinCarryingCount
                    .Enabled = lblnEnabled
                    .Text = CStr(llngMaxCarringCount)
                    .NumMin = 0
                    .NumMax = llngMaxCarringCount
                End With
                
                '@詰め数分母
                With lblResinCarryingCountDenominator
                    .Text = CMstrCarringCountSeparator & CStr(llngMaxCarringCount)
                End With
            Else
            '@引数がFalseの場合
                '@詰め数
                With txtResinCarryingCount
                    .Enabled = lblnEnabled
                    .Text = vbNullString
                End With
                
                '@詰め数分母
                With lblResinCarryingCountDenominator
                    .Text = vbNullString
                End With
            End If
            
            '@>ﾎﾞﾀﾝ
            cmdMove.Enabled = False
            
            '@<ﾎﾞﾀﾝ
            cmdRemove.Enabled = False
            
            '@ｷｬﾘｱ一覧
            With vsfResinPalette
                .Enabled = lblnEnabled
                'NSYS 不要なHandler処理が実行されないようにする
                RemoveHandler vsfResinPalette.BeforeRowColChange,AddressOf vsfResinPalette_RowColChange
                .Rows.Count = .Rows.Fixed
                .Row = - 1
                AddHandler vsfResinPalette.BeforeRowColChange,AddressOf vsfResinPalette_RowColChange
            End With
            
            '@ﾘﾜｰｸ不良入力ﾎﾞﾀﾝ
            cmdReworkScrap.Enabled = lblnEnabled
            
            '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
            cmdLotCommentInput.Enabled = False
            
            '@空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            cmdCarrierSelect.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prv_ResinPalette_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00A0_Disp
    '機　能：画面表示処理
    '引　数：ltypLotCFKILotInfo：CFKIﾛｯﾄ情報取得構造体
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 13:43:56 H.Wajima
    '更新日：2004/07/02 (Fri) 13:43:56
    '備　考：
    '　　　：2005/02/07 (Mon) 10:42:28 S.Deguchi    ｽﾛｯﾄﾏｯﾌﾟの表示を修正
    Private Sub prvfrmxxCM00A0_Disp(ByRef ltypLotCfkiLotInfo As LotCfkiLotinfo)

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim newStyle                As CellStyle
        Dim cellRange               As CellRange

        Try
            
            With ltypLotCfkiLotInfo
                '@CFKIﾛｯﾄ情報が取得できた場合
                If .lngMetalPaletteMapListCnt > 0 Then
                '@ﾃﾞｰﾀ件数が0件よりも多い場合
                    '@ﾁｯﾌﾟ情報の退避
                    With ptypCfkiRenkeiInfo
                        .strCarrierId = txtMetalCarrierID.Text                                      'ｷｬﾘｱID
                        .lngChipQuantity = ltypLotCfkiLotInfo.strChipQuantity                       '受入数
                        .lngChipCarryingCount = 0                                                   '既詰数
                        .lngChipExpenditureCount = 0                                                '払出数
                        .lngChipScrapCount = 0                                                      '不良数
                        .lngChipReworkCount = 0                                                     'ﾘﾜｰｸ数
                        .lngChipRemainCount = 0                                                     '残数
                        .strLotLastUpdate = ltypLotCfkiLotInfo.strLotLastUpdate                     '最終更新日時
                    End With
                    
                    '@画面項目の設定
                    lblMetalLotID.Text = .strLotID                                               'ﾛｯﾄID
                    lblMetalProduct.Text = .strPdId                                              '機種
                    lblMetalRework.Text = .strReworkCount                                        'ﾘﾜｰｸ回数
                    lblMetalPartCode.Text = .strPartCode                                         '部品ID
                    lblMetalPartName.Text = .strPartName                                         '部品名
                    lblVenderName.Text = .strVenderName                                          'ﾍﾞﾝﾀﾞｰ名
                    txtMetalLotComment.Text = .strComments                                          'ﾛｯﾄｺﾒﾝﾄ
                    
                    With ptypCfkiRenkeiInfo
                        '受入数
                        lblChipQuantity.Text = FormatNumber(.lngChipQuantity, 0)
                        lblChipCarryingCount.Text = FormatNumber(.lngChipCarryingCount, 0)
                        lblChipExpenditureCount.Text = FormatNumber(.lngChipExpenditureCount, 0) '払出数
                        lblChipScrapCount.Text = FormatNumber(.lngChipScrapCount, 0)             '不良数
                        lblChipReworkCount.Text = FormatNumber(.lngChipReworkCount, 0)           'ﾘﾜｰｸ数
                        lblChipRemainCount.Text = FormatNumber(.lngChipRemainCount, 0)           '残数
                    End With
                    
                    '@ﾊﾟﾚｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞの初期化
                    cellRange = vsfMetalPalette.GetCellRange(1, CMlngMetalGridColPaletteID,CMlngMetalGridPageRows, CMlngMetalGridColChip)
                    vsfMetalPalette.SetData(cellRange, vbNullString)

                    'NSYS 選択行をヘッダーに設定
                    vsfMetalPalette.Row = - 1

                    '@ﾊﾟﾚｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞの初期化(全てのｽﾛｯﾄを濃いｸﾞﾚｰ表記にする)
                    For llngCnt = 1 To CMlngMetalGridPageRows
                        newStyle = vsfMetalPalette.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray" & llngCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        cellRange = vsfMetalPalette.GetCellRange(llngCnt, CMlngMetalGridColPaletteID, _
                                                              llngCnt, vsfMetalPalette.Cols.Count - 1)
                        cellRange.Style = newStyle

                        'NSYS No.列背景色をライトグレーにする
                        newStyle = vsfMetalPalette.Styles.Add("CustomStyle_BackColor_ControlLight" & llngCnt.ToString)
                        newStyle.ForeColor = SystemColors.WindowText
                        newStyle.BackColor = SystemColors.ControlLight
                        cellRange = vsfMetalPalette.GetCellRange(llngCnt, CMlngMetalGridColNo, llngCnt, CMlngMetalGridColNo)
                        cellRange.Style = newStyle
                    Next llngCnt

                    '@ﾊﾟﾚｯﾄﾏｯﾌﾟの設定
                    For llngCnt = 0 To .lngMetalPaletteMapListCnt - 1
                        With .typMetalPaletteMapList(llngCnt)
                            '@ﾊﾟﾚｯﾄIDをｸﾞﾘｯﾄﾞに設定する
                            vsfMetalPalette.SetData(CInt(.strSlotPosition), CMlngMetalGridColPaletteID, .strPaletteID)
                            
                            '@板厚をｸﾞﾘｯﾄﾞに設定する
                            vsfMetalPalette.SetData(CInt(.strSlotPosition), CMlngMetalGridColThickness, .strThicknessCode)
                                
                            '@ﾁｯﾌﾟをｸﾞﾘｯﾄﾞに設定する
                            vsfMetalPalette.SetData(CInt(.strSlotPosition), CMlngMetalGridColChip, .strChipCount)

                            '@背景色を白にする
                            newStyle = vsfMetalPalette.Styles.Add("CustomStyle_BackColor_vbWhite" & .strSlotPosition)
                            newStyle.ForeColor = SystemColors.WindowText
                            newStyle.BackColor = Color.White
                            cellRange = vsfMetalPalette.GetCellRange(CInt(.strSlotPosition), CMlngMetalGridColPaletteID, CInt(.strSlotPosition), vsfMetalPalette.Cols.Count - 1)
                            cellRange.Style = newStyle
                        End With
                    Next llngCnt
                Else
                    '@ﾃﾞｰﾀ件数が0件の場合
                    '@ﾁｯﾌﾟ情報の初期化
                    With ptypCfkiRenkeiInfo
                        .strCarrierId = vbNullString                    'ｷｬﾘｱID
                        .lngChipQuantity = 0                            '受入数
                        .lngChipCarryingCount = 0                       '既詰数
                        .lngChipExpenditureCount = 0                    '払出数
                        .lngChipScrapCount = 0                          '不良数
                        .lngChipReworkCount = 0                         'ﾘﾜｰｸ数
                        .lngChipRemainCount = 0                         '残数
                        .strLotLastUpdate = vbNullString                '最終更新日時
                    End With
                    
                    lblMetalLotID.Text = vbNullString                'ﾛｯﾄID
                    lblMetalProduct.Text = vbNullString              '機種
                    lblMetalPartCode.Text = vbNullString             '部品ID
                    lblMetalPartName.Text = vbNullString             '部品名
                    lblVenderName.Text = vbNullString                'ﾍﾞﾝﾀﾞｰ名
                    txtMetalLotComment.Text = vbNullString           'ﾛｯﾄｺﾒﾝﾄ
                    lblChipQuantity.Text = vbNullString              '受入数
                    lblChipCarryingCount.Text = vbNullString         '既詰数
                    lblChipExpenditureCount.Text = vbNullString      '払出数
                    lblChipScrapCount.Text = vbNullString            '不良数
                    lblChipReworkCount.Text = vbNullString           'ﾘﾜｰｸ数
                    lblChipRemainCount.Text = vbNullString           '残数
                    
                    '@ﾊﾟﾚｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞの初期化
                    cellRange = vsfMetalPalette.GetCellRange(1, CMlngMetalGridColPaletteID,CMlngMetalGridPageRows, CMlngMetalGridColChip)
                    vsfMetalPalette.SetData(cellRange, vbNullString)

                    'NSYS 選択行をヘッダーに設定
                    vsfMetalPalette.Row = - 1
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00A0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00A0_Init
    '機　能：画面情報の初期化
    '引　数：lblnCarrierIDHold：ｷｬﾘｱID保持ﾌﾗｸﾞ(True:ｷｬﾘｱIDをｸﾘｱしない　False:ｷｬﾘｱIDをｸﾘｱする)
    '　　　：lblnTPALClear：TPALﾊﾟﾚｯﾄﾏｯﾌﾟｸﾘｱﾌﾗｸﾞ(True:ｸﾘｱする　False:ｸﾘｱしない)
    '　　　：lblnTpalOnlyClearFlg：TPAL情報のみ初期化ﾌﾗｸﾞ(True:TPAL情報のみ初期化、False:通常の初期化)
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 11:24:32 H.Wajima
    '更新日：2004/10/19 (Tue) 13:20:53 M.Miura
    '備　考：2004/09/28 (Tue) 20:13:35 H.Wajima TPALｷｬﾘｱIDﾁｪｯｸ追加
    '　　　：2004/10/04 (Mon) 10:36:25 H.Wajima ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2004/10/27 (Wed) 16:42:15 S.Deguchi Validateﾌﾗｸﾞの初期化処理を追加
    Private Sub prvfrmxxCM00A0_Init(ByRef Optional lblnCarrierIDHold As Boolean = False, _
                                    ByRef Optional lblnTPALClear As Boolean = True, _
                                    ByRef Optional lblnTpalOnlyClearFlg As Boolean = False)

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lstrFormTitle           As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00E0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            If lblnTpalOnlyClearFlg = False Then
                '@変数の初期化
                '@ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
                mstrTaihiCarrierID = vbNullString
                '@ﾛｯﾄ最終更新日時
                mstrLotLastUpdate = vbNullString
                
                '@各ｺﾝﾄﾛｰﾙの初期化
                '@**************************************************
                '@金属ﾊﾟﾚｯﾄ
                '@**************************************************
                '@ｷｬﾘｱID
                '@ｷｬﾘｱID保持ﾌﾗｸﾞの判定
                If lblnCarrierIDHold = False Then
                    '@Falseの場合
                    With txtMetalCarrierID
                        .TextAlign = HorizontalAlignment.Left   '文字配置
                        .ChrMaxByte = CPlngCarrierMaxLength     '桁数
                        .IMEMode = ImeMode.Off                  'IMEﾓｰﾄﾞ
                        .ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper '大文字/小文字
                        .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku  '表示ﾀｲﾌﾟ
                        .Enabled = True                         'ｲﾍﾞﾝﾄ認識
                        .Text = vbNullString                    'ﾃｷｽﾄ
                    End With
                End If
                
                '@ﾛｯﾄID
                With lblMetalLotID
                    .TextAlign = ContentAlignment.TopLeft'文字配置
                    .Text = vbNullString                 'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@機種
                With lblMetalProduct
                    .TextAlign = ContentAlignment.TopLeft'文字配置
                    .Text = vbNullString                 'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@ﾘﾜｰｸ回数
                With lblMetalRework
                    .TextAlign = ContentAlignment.TopRight'文字配置
                    .Text = vbNullString                  'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@部品ｺｰﾄﾞ
                With lblMetalPartCode
                    .TextAlign = ContentAlignment.TopLeft'文字配置
                    .Text = vbNullString                 'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@部品名称
                With lblMetalPartName
                    .TextAlign = ContentAlignment.TopLeft'文字配置
                    .Text = vbNullString                 'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@ﾍﾞﾝﾀﾞｰ
                With lblVenderName
                    .TextAlign = ContentAlignment.TopLeft'文字配置
                    .Text = vbNullString                 'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@ﾛｯﾄｺﾒﾝﾄ
                With txtMetalLotComment
                    .TextAlign = HorizontalAlignment.Left'文字配置
                    .Text = vbNullString                 'ｷｬﾌﾟｼｮﾝ
                    .Locked = True                       'ﾛｯｸ
                    'ﾌｫﾝﾄ名
                    'ﾌｫﾝﾄｻｲｽﾞ
                    .Font = New Font(CMstrGridFontName, CMlngGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                    .MultiLineEx = True                  'ﾏﾙﾁﾗｲﾝ
                    .TabStop = False                     'ﾀﾌﾞｽﾄｯﾌﾟ
                    .GotHighLight = False                'ﾌｫｰｶｽ取得時ﾊｲﾗｲﾄ
                End With
                
                '@▲ﾎﾞﾀﾝ
                cmdMetalUp.Enabled = False
                
                '@▼ﾎﾞﾀﾝ
                cmdMetalDown.Enabled = False
                
                '@金属ﾊﾟﾚｯﾄﾏｯﾌﾟ
                With vsfMetalPalette
                    .Clear                               'ｾﾙの初期化
                    'ﾌｫﾝﾄ名
                    'ﾌｫﾝﾄｻｲｽﾞ
                    .Font = New Font(CMstrGridFontName, CMlngGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                    .Rows.Fixed = CMlngMetalGridFixedRows                            '固定行
                    '.Cols.Fixed = CMlngMetalGridFixedCols                            '固定列
                    'NSYS 不要なHandler処理を抑止
                    RemoveHandler vsfResinPalette.BeforeRowColChange,AddressOf vsfResinPalette_RowColChange
                    .Rows.Count = CMlngMetalGridPageRows + CMlngMetalGridFixedRows   '行数
                    .Cols.Count = CMlngMetalGridCols                                 '列数
                    AddHandler vsfResinPalette.BeforeRowColChange,AddressOf vsfResinPalette_RowColChange
                    
                    
                    '@列幅の設定
                    .Cols(CMlngMetalGridColNo).Width = CMlngMetalGridColWidthNo
                    .Cols(CMlngMetalGridColPaletteID).Width = CMlngMetalGridColWidthPaletteID
                    .Cols(CMlngMetalGridColThickness).Width = CMlngMetalGridColWidthThickness
                    .Cols(CMlngMetalGridColChip).Width = CMlngMetalGridColWidthChip
                    
                    '@行の高さの設定
                    .Rows.DefaultSize = CMlngGridRowHeight
                    .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                    
                    .Width = CMlngMetalGridWidth                                    'ｸﾞﾘｯﾄﾞ幅
                    .Height = CMlngMetalGridHeight                                  'ｸﾞﾘｯﾄﾞ高さ
                    '.ScrollBars = ScrollBars.Both                                   'ｽｸﾛｰﾙﾊﾞｰ
                    .ScrollTrack = False                                            '同期ｽｸﾛｰﾙ
                    '.FillStyle = flexFillRepeat                                    'ﾌﾟﾛﾊﾟﾃｨの設定対象
                    .ExtendLastCol = True                                           '最終列幅自動調整
                    '.AllowSelection = False                                        '範囲選択
                    .FocusRect = FocusRectEnum.None                                 'ﾌｫｰｶｽ枠
                    .SelectionMode = SelectionModeEnum.Row                          'ｾﾙ選択ﾓｰﾄﾞ
                    .HighLight = HighLightEnum.Always                               'ﾊｲﾗｲﾄ
                    '.ExplorerBar = flexExNone                                      'ﾍｯﾀﾞのｿｰﾄ
                    
                    '@ﾀｲﾄﾙ行の設定
                    Dim newStyle As CellStyle = vsfMetalPalette.Styles.Add("CustomStyle_VsfMetalPalette_Header")
                    Dim cellRange As CellRange = vsfMetalPalette.GetCellRange(CMlngGridRowTitle, 0, CMlngGridRowTitle, 3)
                    newStyle.ForeColor = Color.Yellow
                    newStyle.BackColor = Color.Navy
                    newStyle.TextAlign = TextAlignEnum.CenterCenter
                    cellRange.Style = newStyle
                    
                    '@文字位置
                    .Cols(CMlngMetalGridColNo).TextAlign = TextAlignEnum.RightCenter                                    '№
                    .Cols(CMlngMetalGridColPaletteID).TextAlign = TextAlignEnum.LeftCenter                              'ﾊﾟﾚｯﾄID
                    .Cols(CMlngMetalGridColThickness).TextAlign = TextAlignEnum.LeftCenter                              '板厚
                    .Cols(CMlngMetalGridColChip).TextAlign = TextAlignEnum.RightCenter                                  'ﾁｯﾌﾟ数
                    
                    '@ﾀｲﾄﾙ
                    .SetData(CMlngGridRowTitle, CMlngMetalGridColNo, CMstrMetalGridTitleNo)                   '№
                    .SetData(CMlngGridRowTitle, CMlngMetalGridColPaletteID, CMstrMetalGridTitlePaletteID)     'ﾊﾟﾚｯﾄID
                    .SetData(CMlngGridRowTitle, CMlngMetalGridColThickness, CMstrMetalGridTitleThickness)     '板厚
                    .SetData(CMlngGridRowTitle, CMlngMetalGridColChip, CMstrMetalGridTitleChip)               'ﾁｯﾌﾟ数
                    
                    .Styles.Normal.Trimming = StringTrimming.None                   '省略符号
                    
                    '@№列に連番を振る
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        .SetData(llngCnt, 0, llngCnt)
                    Next llngCnt

                    'NSYS 無効化
                    .Enabled = False
                    
                    .TabStop = False                                                'TabStop
                End With
                
                '@ﾁｯﾌﾟ情報
                '@受入数
                With lblChipQuantity
                    .TextAlign = ContentAlignment.TopRight'文字配置
                    .Text = vbNullString                  'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@既詰数
                With lblChipCarryingCount
                    .TextAlign = ContentAlignment.TopRight'文字配置
                    .Text = vbNullString                  'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@払出数
                With lblChipExpenditureCount
                    .TextAlign = ContentAlignment.TopRight'文字配置
                    .Text = vbNullString                  'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@不良数
                With lblChipScrapCount
                    .TextAlign = ContentAlignment.TopRight'文字配置
                    .Text = vbNullString                  'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@ﾘﾜｰｸ数
                With lblChipReworkCount
                    .TextAlign = ContentAlignment.TopRight'文字配置
                    .Text = vbNullString                  'ｷｬﾌﾟｼｮﾝ
                End With
                
                '@残数
                With lblChipRemainCount
                    .TextAlign = ContentAlignment.TopRight'文字配置
                    .Text = vbNullString                  'ｷｬﾌﾟｼｮﾝ
                End With
            Else
            '@TPAL情報のみ初期化ﾌﾗｸﾞがTrueの場合
                '@TPALﾊﾟﾚｯﾄﾏｯﾌﾟｸﾘｱﾌﾗｸﾞを強制的にTrueにする
                lblnTPALClear = True
            End If
            
            '@**************************************************
            '@樹脂ﾊﾟﾚｯﾄ
            '@**************************************************
            '@ｷｬﾘｱID
            With txtResinCarrierID
                .TextAlign = HorizontalAlignment.Left   '文字配置
                .ChrMaxByte = CPlngCarrierMaxLength     '桁数
                .IMEMode = ImeMode.Off                  'IMEﾓｰﾄﾞ
                .ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper '大文字/小文字
                .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num'表示ﾀｲﾌﾟ
                .Enabled = False                        'ｲﾍﾞﾝﾄ認識
                .Text = vbNullString                    'ﾃｷｽﾄ
            End With
            
            mstrResinCarrierID = vbNullString           '退避用TPALｷｬﾘｱIDの初期化
            
            '@詰め数
            With txtResinCarryingCount
                .TextAlign = HorizontalAlignment.Right  '文字配置
                .ChrMaxByte = CMlngResinCarryingMaxByte '桁数
                .IMEMode = ImeMode.Off                  'IMEﾓｰﾄﾞ
                .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric '表示ﾀｲﾌﾟ
                .Enabled = False                        'ｲﾍﾞﾝﾄ認識
                .Text = vbNullString                    'ﾃｷｽﾄ
            End With
            
            '@詰め数分母
            With lblResinCarryingCountDenominator
                .TextAlign = ContentAlignment.TopLeft'文字配置
                .Text = vbNullString                 'ｷｬﾌﾟｼｮﾝ
            End With
            
            '@ﾛｯﾄｺﾒﾝﾄ
            With txtResinLotComment
                .TextAlign = HorizontalAlignment.Left   '文字配置
                .Text = vbNullString                    'ｷｬﾌﾟｼｮﾝ
                .Locked = True                          'ﾛｯｸ
                'ﾌｫﾝﾄ名
                'ﾌｫﾝﾄｻｲｽﾞ
                .Font = New Font(CMstrGridFontName, CMlngGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .TabStop = False                        'ﾀﾌﾞｽﾄｯﾌﾟ
                .MultiLineEx = True                     'ﾏﾙﾁﾗｲﾝ
                .GotHighLight = False                   'ﾌｫｰｶｽ取得時ﾊｲﾗｲﾄ
            End With
            
            '@▲ﾎﾞﾀﾝ
            cmdResinUp.Enabled = False
            '@▼ﾎﾞﾀﾝ
            cmdResinDown.Enabled = False
            
        '@↓2009/06/29 (Mon) 11:42:49 Y.Yoneyama **************************************************
            Call prvCmbCfArea_Init()                    '左右区分の初期化
        '@↑2009/06/29 (Mon) 11:42:49 Y.Yoneyama **************************************************
            
            '@TPALｸﾘｱﾌﾗｸﾞの判定
            If lblnTPALClear = True Then
            '@Trueの場合、TPALﾊﾟﾚｯﾄﾏｯﾌﾟを初期化する
                '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞ
                With vsfResinPalette
                    .Clear                                                              '画面の初期化
                    .LeftCol = CMlngResinGridColNo                                      'ｽｸﾛｰﾙ左端列
                    'ﾌｫﾝﾄ名
                    'ﾌｫﾝﾄｻｲｽﾞ
                    .Font = New Font(CMstrGridFontName, CMlngGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                    .Rows.Fixed = CMlngResinGridFixedRows                                '固定行
                    .Cols.Fixed = CMlngResinGridFixedCols                                '固定列
                    .Cols.Frozen = CMlngResinGridFrozenCols                              '静止列
                    'NSYS 不要なHandler処理を抑止
                    RemoveHandler vsfResinPalette.BeforeRowColChange,AddressOf vsfResinPalette_RowColChange
                    .Rows.Count = .Rows.Fixed                                            '行数
                    .Cols.Count = CMlngResinGridCols                                     '列数
                    AddHandler vsfResinPalette.BeforeRowColChange,AddressOf vsfResinPalette_RowColChange
                    .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight               '行の高さ
                    
                    '@列の幅
                    .Cols(CMlngResinGridColNo).Width = CMlngResinGridColWidthNo
                    .Cols(CMlngResinGridColCarrierID).Width = CMlngResinGridColWidthCarrierID
                    .Cols(CMlngResinGridColTPALLotID).Width = CMlngResinGridColWidthTPALLotID
                    .Cols(CMlngResinGridColRework).Width = CMlngResinGridColWidthRework
                    .Cols(CMlngResinGridColCarrying).Width = CMlngResinGridColWidthCarrying
        '@↓2009/06/29 (Mon) 16:03:51 Y.Yoneyama **************************************************
                    .Cols(CMlngResinGridColCfArea).Width = CMlngResinGridColWidthCfArea
                    .Cols(CMlngResinGridColCfAreaCode).Width = CMlngResinGridColWidthCfAreaCode
        '@↑2009/06/29 (Mon) 16:03:51 Y.Yoneyama **************************************************
                    .Cols(CMlngResinGridColComments).Width = CMlngResinGridColWidthComments
                    
                    .Width = CMlngResinGridWidth                                        'ｸﾞﾘｯﾄﾞの幅
                    .Height = CMlngResinGridHeight                                      'ｸﾞﾘｯﾄﾞの高さ
                    .ScrollBars = ScrollBars.Both                                       'ｽｸﾛｰﾙﾊﾞｰ
                    .ScrollTrack = True                                                 '同期ｽｸﾛｰﾙ
                    '.FillStyle = flexFillRepeat                                        'ﾌﾟﾛﾊﾟﾃｨの設定対象
                    .ExtendLastCol = True                                               '最終列幅自動調整
                    '.AllowSelection = False                                            '範囲選択
                    .FocusRect = FocusRectEnum.None                                     'ﾌｫｰｶｽ枠
                    .SelectionMode = SelectionModeEnum.Row                              'ｾﾙ選択ﾓｰﾄﾞ
                    .HighLight = HighLightEnum.Always                                   'ﾊｲﾗｲﾄ
                    '.ExplorerBar = flexExNone                                          'ﾍｯﾀﾞのｿｰﾄ
                    
                    '@ﾀｲﾄﾙ行の設定
                    Dim newStyle As CellStyle = vsfResinPalette.Styles.Add("CustomStyle_vsfResinPalette_Header")
                    Dim cellRange As CellRange = vsfResinPalette.GetCellRange(CMlngGridRowTitle, 0, CMlngGridRowTitle, 7)
                    newStyle.ForeColor = Color.Yellow
                    newStyle.BackColor = Color.Navy
                    newStyle.TextAlign = TextAlignEnum.CenterCenter
                    cellRange.Style = newStyle
                    
                    '@文字位置
                    .Cols(CMlngResinGridColNo).TextAlign = TextAlignEnum.RightCenter       '№
                    .Cols(CMlngResinGridColCarrierID).TextAlign = TextAlignEnum.LeftCenter 'ｷｬﾘｱID
                    .Cols(CMlngResinGridColTPALLotID).TextAlign = TextAlignEnum.LeftCenter 'TPALﾛｯﾄID
                    .Cols(CMlngResinGridColRework).TextAlign = TextAlignEnum.RightCenter   'ﾘﾜｰｸ回数
                    .Cols(CMlngResinGridColCarrying).TextAlign = TextAlignEnum.RightCenter '詰め数
        '@↓2009/06/29 (Mon) 16:10:52 Y.Yoneyama **************************************************
                    .Cols(CMlngResinGridColCfArea).TextAlign = TextAlignEnum.LeftCenter    'CF左右区分
                    .Cols(CMlngResinGridColCfAreaCode).TextAlign = TextAlignEnum.LeftCenter'CF左右区分ｺｰﾄﾞ
        '@↑2009/06/29 (Mon) 16:10:52 Y.Yoneyama **************************************************
                    .Cols(CMlngResinGridColComments).TextAlign = TextAlignEnum.LeftCenter  'ｺﾒﾝﾄ
                    
                    '@ﾀｲﾄﾙ
                    .SetData(CMlngGridRowTitle, CMlngResinGridColNo, CMstrResinGridTitleNo)
                    .SetData(CMlngGridRowTitle, CMlngResinGridColCarrierID, CMstrResinGridTitleCarrierID)
                    .SetData(CMlngGridRowTitle, CMlngResinGridColTPALLotID, CMstrResinGridTitleTPALLotID)
                    .SetData(CMlngGridRowTitle, CMlngResinGridColRework, CMstrResinGridTitleRework)
                    .SetData(CMlngGridRowTitle, CMlngResinGridColCarrying, CMstrResinGridTitleCarrying)
        '@↓2009/06/29 (Mon) 16:05:43 Y.Yoneyama **************************************************
                    .SetData(CMlngGridRowTitle, CMlngResinGridColCfArea, CMstrResinGridTitleCfArea)
                    .SetData(CMlngGridRowTitle, CMlngResinGridColCfAreaCode, CMstrResinGridTitleCfAreaCode)
        '@↑2009/06/29 (Mon) 16:05:43 Y.Yoneyama **************************************************
                    .SetData(CMlngGridRowTitle, CMlngResinGridColComments, CMstrResinGridTitleComments)

                    'NSYS 左右コード列を非表示
                    .Cols(CMlngResinGridColCfAreaCode).Visible = False
                    
                    .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter          '省略符号(データ行)
                    .Styles.Fixed.Trimming = StringTrimming.None                        'NSYS 省略符号(ヘッダー行)
                    .AllowResizing = AllowResizingEnum.Columns                          'ﾏｳｽで列幅変更
                    
                    '@自動調整の対象を列幅に設定
                    '.AutoSizeMode = flexAutoSizeColWidth
                    
                    '@列幅を自動調整
                    .AutoSizeCol(CMlngResinGridColComments, 6)
                    
                    .Enabled = False                                                    'ｲﾍﾞﾝﾄ認識
                    .TabStop = False
                End With
            Else
            '@Falseの場合、TPALﾊﾟﾚｯﾄﾏｯﾌﾟを初期化しない
                '@樹脂ﾊﾟﾚｯﾄｸﾞﾘｯﾄﾞ
                With vsfResinPalette
                    .Enabled = False
                    .TabStop = False
                End With
            End If
            
            '@Validateを実行しない
            cmdCarrierSelect.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00A0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00A0_cmbInit
    '機　能：ﾎﾞﾀﾝの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 17:10:59 H.Wajima
    '更新日：2004/06/25 (Fri) 17:10:59
    '備　考：
    Private Sub prvfrmxxCM00A0_cmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try

            '@ﾎﾞﾀﾝの設定
            cmdMove.Enabled = lblnEnable                '>
            cmdRemove.Enabled = lblnEnable              '<
            cmdCarrierSelect.Enabled = lblnEnable       '空きｷｬﾘｱ選択
            cmdEnter.Enabled = lblnEnable               '確定
            cmdReworkScrap.Enabled = lblnEnable         'ﾘﾜｰｸ不良
            cmdLotCommentInput.Enabled = lblnEnable     'ﾛｯﾄｺﾒﾝﾄ
            cmdClose.Enabled = True                     '閉じる
            
            '@ｷｬﾘｱIDが入力可能かどうかを判定
            If txtMetalCarrierID.Locked = True Then
                '@入力不可能な場合
                cmdClear.Enabled = lblnEnable           '全部取消
            Else
                '@入力可能な場合
                If txtMetalCarrierID.Text <> vbNullString Then
                    cmdClear.Enabled = True             '全部取消
                Else
                    cmdClear.Enabled = lblnEnable       '全部取消
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00A0_cmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00A0Enabled_Chk
    '機　能：画面項目ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/25 (Fri) 17:52:36 H.Wajima
    '更新日：2004/06/25 (Fri) 17:52:36
    '備　考：
    Private Sub prvfrmxxCM00A0Enabled_Chk()

        Try

            '@金属ﾊﾟﾚｯﾄのﾛｯﾄIDの判定
            If lblMetalLotID.Text <> vbNullString Then
                '@ﾛｯﾄが確定している場合
                txtResinCarrierID.Enabled = True            '樹脂ﾊﾟﾚｯﾄｷｬﾘｱID
                txtResinCarryingCount.Enabled = True        '樹脂ﾊﾟﾚｯﾄ詰め数
                cmdRemove.Enabled = True                    '<ﾎﾞﾀﾝ
                cmdClear.Enabled = True                     '全部取消ﾎﾞﾀﾝ
                
                '@樹脂ﾊﾟﾚｯﾄのｷｬﾘｱIDの判定
                If Len(txtResinCarrierID.Text) = CPlngCarrierMaxLength Then
                    '@ｷｬﾘｱが確定している場合
                    cmdMove.Enabled = True                  '>ﾎﾞﾀﾝ
                    cmdReworkScrap.Enabled = True           'ﾘﾜｰｸ不良入力ﾎﾞﾀﾝ
                    cmdLotCommentInput.Enabled = True       'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
                Else
                    '@ｷｬﾘｱが確定していない場合
                    cmdMove.Enabled = True                  '>ﾎﾞﾀﾝ
                    cmdReworkScrap.Enabled = False          'ﾘﾜｰｸ不良入力ﾎﾞﾀﾝ
                    cmdLotCommentInput.Enabled = False      'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
                End If
                
                '@残数の判定
                If lblChipRemainCount.Text = "0" Then
                    '@残数が0の場合
                    cmdEnter.Enabled = True                '確定ﾎﾞﾀﾝ
                Else
                    '@残数が0以外の場合
                    cmdEnter.Enabled = False               '確定ﾎﾞﾀﾝ
                End If
            Else
                Call prvfrmxxCM00A0_Init(True)
            End If
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00A0Enabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvResinInput_chk
    '機　能：樹脂ﾊﾟﾚｯﾄ項目入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2004/07/02 (Fri) 16:23:00 H.Wajima
    '更新日：2004/08/27 (Fri) 18:25:18 N.Kasai
    '備　考：2004/08/27 (Fri) 18:25:18 N.Kasai TPALｺﾒﾝﾄ使用制限を追加
    Private Sub prvResinInput_chk()

        Try

            '@<ﾎﾞﾀﾝの判定
            '@ｷｬﾘｱID、詰め数のﾁｪｯｸ
            If txtResinCarrierID.NowByte = CPlngCarrierMaxLength And _
               txtResinCarryingCount.NowByte <> 0 Then
                '@ｷｬﾘｱIDが6桁入力されていて、かつ詰め数が空白以外の場合
                '@更に詰め数のﾁｪｯｸ
                Select Case CLng(txtResinCarryingCount.Text)
                    Case 1 To mlngPaletteNum
                    '@1以上、最大枚数以下の場合
                        '@>ﾎﾞﾀﾝ押下可能
                        cmdMove.Enabled = True
                        '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ押下可能
                        cmdLotCommentInput.Enabled = True
                    Case Else
                    '@上記以外の場合
                        '@>ﾎﾞﾀﾝ押下不能
                        cmdMove.Enabled = False
                        '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ押下不能
                        cmdLotCommentInput.Enabled = False
                End Select
            Else
                '@>ﾎﾞﾀﾝ押下不能
                cmdMove.Enabled = False
                '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ押下不能
                cmdLotCommentInput.Enabled = False
            End If
            
            '@>ﾎﾞﾀﾝの判定
            With vsfResinPalette
                '@明細の件数ﾁｪｯｸ
                If .Rows.Fixed = .Rows.Count Then
                '@ﾀｲﾄﾙ行だけの場合
                    '@<ﾎﾞﾀﾝ押下不能
                    cmdRemove.Enabled = False
                Else
                    '@明細行がある場合
                    If .Row >= .Rows.Fixed And _
                       .Row <> CMlngGridUnChoosingListIndex Then
                    '@明細行が選択されている場合
                        '@<ﾎﾞﾀﾝ押下可能
                        cmdRemove.Enabled = True
                    Else
                    '@明細行が選択されていない場合
                        '@<ﾎﾞﾀﾝ押下不能
                        cmdRemove.Enabled = False
                    End If
                End If
            End With
            
            '@確定ﾎﾞﾀﾝの判定
            If ptypCfkiRenkeiInfo.lngChipRemainCount = 0 Then
            '@残数が0の場合
                '@既詰数の判定
                If ptypCfkiRenkeiInfo.lngChipCarryingCount > 0 Then
                    '@既詰数が0より大きい場合
                    '@確定ﾎﾞﾀﾝ押下可能
                    cmdEnter.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝ押下不能
                    cmdEnter.Enabled = False
                End If
            Else
            '@残数が0以外の場合
                '@確定ﾎﾞﾀﾝ押下不能
                cmdEnter.Enabled = False
            End If
            
            '@ﾘﾜｰｸ不良入力ﾎﾞﾀﾝの判定
            If ptypCfkiRenkeiInfo.lngChipRemainCount = 0 Then
            '@残数が0の場合
                '@既詰数の判定
                '@ﾘﾜｰｸ不良入力ﾎﾞﾀﾝ押下不能
                cmdReworkScrap.Enabled = False
            Else
            '@残数が0以外の場合
                '@ﾘﾜｰｸ不良入力ﾎﾞﾀﾝ押下可能
                cmdReworkScrap.Enabled = True
            End If
            
            '@全部取消ﾎﾞﾀﾝの判定
            '@他画面から起動された（金属ｷｬﾘｱIDが編集不能）場合は
            '@樹脂ｷｬﾘｱIDのChangeで判定を行う。（単体起動の場合は、金属ｷｬﾘｱIDのChangeで判定）
            If txtMetalCarrierID.Locked = True Then
                '@金属ｷｬﾘｱIDが編集不能の場合
                If txtResinCarrierID.Text <> vbNullString Then
                '@樹脂ｷｬﾘｱIDが空白の以外の場合
                    '@全部取消ﾎﾞﾀﾝ押下可能
                    cmdClear.Enabled = True
                    '@TPALｺﾒﾝﾄﾎﾞﾀﾝ押下可能
                    cmdLotCommentInput.Enabled = True
                Else
                    '@樹脂ｷｬﾘｱIDが空白の場合
                    '@TPALﾛｯﾄﾘｽﾄの明細があるかどうかを判定
                    If vsfResinPalette.Rows.Fixed = vsfResinPalette.Rows.Count Then
                    '@明細がない場合
                        '@全部取消ﾎﾞﾀﾝ押下不能
                        cmdClear.Enabled = False
                    Else
                    '@明細がある場合
                        '@全部取消ﾎﾞﾀﾝ押下可能
                        cmdClear.Enabled = True
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvResinInput_chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipCount_Disp
    '機　能：ﾁｯﾌﾟ情報 枚数ｶｳﾝﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 13:20:17 H.Wajima
    '更新日：2004/07/05 (Mon) 13:20:17
    '備　考：
    Private Sub prvChipCount_Disp()

        Try
            
            '@残数の再計算
            With ptypCfkiRenkeiInfo
                '@残数の再計算（）
                .lngChipRemainCount = .lngChipQuantity _
                                    - .lngChipCarryingCount _
                                    - .lngChipExpenditureCount _
                                    - .lngChipScrapCount _
                                    - .lngChipReworkCount
            End With
            
            '@画面項目の設定
            With ptypCfkiRenkeiInfo
                lblChipQuantity.Text = FormatNumber(.lngChipQuantity, 0)                 '受入数
                lblChipCarryingCount.Text = FormatNumber(.lngChipCarryingCount, 0)       '既詰数
                lblChipExpenditureCount.Text = FormatNumber(.lngChipExpenditureCount, 0) '払出数
                lblChipScrapCount.Text = FormatNumber(.lngChipScrapCount, 0)             '不良数
                lblChipReworkCount.Text = FormatNumber(.lngChipReworkCount, 0)           'ﾘﾜｰｸ数
                lblChipRemainCount.Text = FormatNumber(.lngChipRemainCount, 0)           '残数
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChipCount_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotTpalLotList_Disp
    '機　能：TPAL編成ﾛｯﾄ情報表示
    '引　数：ltypLotTpalLotList：
    '戻り値：なし
    '作成日：2004/07/14 (Wed) 13:26:29 H.Wajima
    '更新日：2004/07/14 (Wed) 13:26:29
    '備　考：
    Private Sub prvLotTpalLotList_Disp(ByRef ltypLotTpalLotInfo As LotTpalLotInfo)

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lstrItem                As String               'ｸﾞﾘｯﾄﾞ追加文字列
        Dim lstrAddItem()           As String               'ｸﾞﾘｯﾄﾞ追加文字列配列

        Try
            
            With ltypLotTpalLotInfo
                '@ﾘｽﾄｶｳﾝﾄの判定
                If .lngLotTpalLotListCnt = 0 Then
                    '@0件の場合処理を抜ける
                    Exit Sub
                End If
                
                '@描画の停止
                vsfResinPalette.Redraw = False
                
                '@ﾘｽﾄのﾙｰﾌﾟ
                For llngCnt = 1 To .lngLotTpalLotListCnt
                    With .typLotTpalLotList(llngCnt - 1)
                        '@配列の初期化
                        ReDim lstrAddItem(CMlngResinGridColNo To CMlngResinGridColComments)
                        
                        '@№番号
                        lstrAddItem(CMlngResinGridColNo) = llngCnt
                        
                        '@ｷｬﾘｱID
                        lstrAddItem(CMlngResinGridColCarrierID) = .strCarrierId
                        
                        '@TPALﾛｯﾄID
                        lstrAddItem(CMlngResinGridColTPALLotID) = .strTpLotID
                        
                        '@ﾘﾜｰｸ数
                        If IsNumeric(.strReworkCount) Then
                            lstrAddItem(CMlngResinGridColRework) = FormatNumber(CLng(.strReworkCount), 0)
                        Else
                            lstrAddItem(CMlngResinGridColRework) = .strReworkCount
                        End If

                        '@詰め数
                        If IsNumeric(.strNum) Then
                            lstrAddItem(CMlngResinGridColCarrying) = FormatNumber(CLng(.strNum), 0)
                        Else
                            lstrAddItem(CMlngResinGridColCarrying) = .strNum
                        End If
                        
                        '@詰め数の加算
                        '@詰め数が数値かどうかを判定する
                        If IsNumeric(.strNum) = True Then
                        '@数値の場合
                            '@詰め数の加算
                            ptypCfkiRenkeiInfo.lngChipCarryingCount = ptypCfkiRenkeiInfo.lngChipCarryingCount + CLng(.strNum)
                        End If
                        
                        '@ﾛｯﾄｺﾒﾝﾄ
                        lstrAddItem(CMlngResinGridColComments) = .strComments
                        
                        '@ｸﾞﾘｯﾄﾞ追加文字列の編集
                        lstrItem = Join(lstrAddItem, vbTab)
                        
                        '@ｸﾞﾘｯﾄﾞに行を追加
                        vsfResinPalette.AddItem (lstrItem)

                        'NSYS 追加行の書式設定
                        Dim newStyle = vsfResinPalette.Styles.Add("CustomStyle_VsfResinPalette_DataRow")
                        Dim cellRange = vsfResinPalette.GetCellRange(llngCnt, vsfResinPalette.Rows.Count - 1, llngCnt, vsfResinPalette.Cols.Count - 1)
                        newStyle.ForeColor = SystemColors.WindowText
                        newStyle.BackColor = SystemColors.Window
                        cellRange.Style = newStyle

                    End With
                Next llngCnt
            End With
            
            With vsfResinPalette
                '@ﾀﾌﾞｷｰでﾌｫｰｶｽを取得しない
                .TabStop = False
                
                '@自動調整の対象を列幅に設定
                '.AutoSizeMode = flexAutoSizeColWidth
                
                '@列幅を自動調整
                .AutoSizeCol(CMlngResinGridColComments, 6)
                
                '@行の高さ
                .Rows(.Rows.Count - 1).Height = CMlngGridRowHeight

                'NSYS ヘッダーを選択
                .Row = - 1

                '@描画の再開
                .Redraw = True
                
                '@ｲﾍﾞﾝﾄ有効
                .Enabled = True
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotTpalLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPaletteNum_Init
    '機　能：詰め数初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 18:16:59 H.Wajima
    '更新日：2004/07/05 (Mon) 18:17:24 H.Wajima
    '備　考：
    Private Sub prvPaletteNum_Init()
        
        Dim llngMaxCarringCount                     As Integer                          '詰め数最大値

        Try
            
            '@詰め数の判定
            If ptypCfkiRenkeiInfo.lngChipRemainCount < mlngPaletteNum Then
            '@残数よりもﾊﾟﾚｯﾄﾁｯﾌﾟ数合計の方が大きい場合
                '@詰め数最大値に残数を設定する
                llngMaxCarringCount = ptypCfkiRenkeiInfo.lngChipRemainCount
            Else
            '@上記以外の場合
                '@詰め数最大値にﾊﾟﾚｯﾄﾁｯﾌﾟ数合計を設定する
                llngMaxCarringCount = mlngPaletteNum
            End If
            
            '@詰め数
            With txtResinCarryingCount
                .Enabled = True
                .NumMin = 0
                .NumMax = llngMaxCarringCount
                .Text = CStr(llngMaxCarringCount)
            End With
            
            '@詰め数分母
            With lblResinCarryingCountDenominator
                .Text = CMstrCarringCountSeparator & CStr(llngMaxCarringCount)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPaletteNum_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbCfArea_Init
    '機　能：CF左右区分ｺﾝﾎﾞﾎﾞｯｸｽの設定をする
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/29 (Mon) 13:29:27 Y.Yoneyama
    '更新日：2009/06/29 (Mon) 13:29:27
    '備　考：
    Private Sub prvCmbCfArea_Init()

        Try
            
            '@CF区分選択初期化
            mstrCfAreaSel = vbNullString
            
            '@ComboBoxExの設定
            With cmbCfArea
                .Clear                                      'ｸﾘｱ
                .BackColor = SystemColors.Window            'NSYS 背景色設定
                .DirectInput = False                        '入力不可
                .DispCols = CMlngComboDispCols              '表示項目数
                .GetCol = CMlngComboColAreaName             'ﾃｷｽﾄ表示列
                .ValueCol = CMlngComboColAreaCode           '値取得列
                .Font = New Font(.Font.FontFamily, CMlngComboFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)        'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.FontFamily, CMlngComboGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngComboRowHeight            '行の高さ
                .ColAlignment(CMlngComboColAreaName) = TextAlignEnum.LeftCenter '左中央
                .ColAlignment(CMlngComboColAreaCode) = TextAlignEnum.LeftCenter '左中央

                '@項目追
                .AddItem(CMstrCfSelectNameNone & vbTab & CMstrCfSelectCodeNone)
                .AddItem(CMstrCfSelectNameLeft & "(ポート#2)" & vbTab & CMstrCfSelectCodeLeft)
                .AddItem(CMstrCfSelectNameRight & "(ポート#3)" & vbTab & CMstrCfSelectCodeRight)
                        
                '@1件目表示
                .ListIndex = CMlngComboDefaultIndex
                
                '@無機ﾛｯﾄの場合
                If ptypLotprestate.strVaFlag = CPstrOne Then
                    .Enabled = True                         'ｲﾍﾞﾝﾄ認識あり
                
                '@無機ﾛｯﾄ以外の場合
                Else
                    .Enabled = False                        'ｲﾍﾞﾝﾄ認識なし
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbCfArea_Init"
                .strErrMessage = vbNullString
            End With

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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraChip.Paint, fraMetal.Paint, fraResin.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfResinPalette.BeforeDoubleClick

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

            'No.列は自動調整不要
            If colindex <> 0 Then
                'サイズを自動調整
                gridObj.AutoSizeCol(colindex,6)
            End If
        End If

    End Sub

End Class
