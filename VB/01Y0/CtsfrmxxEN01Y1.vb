'ﾌｧｲﾙ名：ﾌｧｲﾙ名：xxEN01Y1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：星取表表示(過去在庫一覧サブフォーム)
'作成日：2006/08/01 (Tue) 13:19:23 N.Kojima
'更新日：2014/01/16 (Thu) 11:07:59 T.Oide
'備　考：
'　　　：2006/10/05 (Thu) 16:48:39 N.Kojima     ほぼ作り直しに伴い、ｺｰﾄﾞは削除しています。一部ｺﾒﾝﾄｱｳﾄ。(案件№01517)
'　　　：2014/01/16 (Thu) 11:07:59 T.Oide       GNS対応
'Copyright(C)SEIKO EPSON CORPORATION 2014. All rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01Y1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance As frmxxEN01Y1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01Y1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01Y1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01Y1)
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
    '@機能ID
    Private Const CMstrLocalMenuKey As String = CPstrKeyEN01Y1          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrwf__chipsnapshotlistVer As String = "01.00"                 '星取表情報取得

    '@ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのｶﾗﾑ定数
    '@ｸﾞﾘｯﾄの単位
    Private Const CMlngvsfWtips As Integer = 1                         'ｸﾞﾘｯﾄのTwips単位
    Private Const CMvsfTitleFontSize As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

    '@WF情報(Col)
    Private Const CMlngvsfWFMapID As Integer = 0                         'WF_ID
    Private Const CMlngvsfWFMapChkBox As Integer = 1                         'ﾁｪｯｸﾎﾞｯｸｽ

    '@WF情報(ｸﾞﾘｯﾄ設定)
    Private Const CMlngvsfWFMapMaxSlotID As Integer = 25                        'ｽﾛｯﾄ№の最大値
    Private Const CMlngvsfWFMapTitleHeight As Integer = 18                       'ﾀｲﾄﾙ行の高さ
    Private Const CMlngvsfWFMapRowHeightMin As Integer = 20                       '行の高さの最小値

    '@ﾁｯﾌﾟ情報
    Private Const CMlngvsfChipMapNo As Integer = 0                       '№
    Private Const CMlngvsfChipMapTitleHeight As Integer = 26                      'ﾀｲﾄﾙ行の高さ
    Private Const CMlngvsfChipMapTitleWidth As Integer = 20                      'ﾀｲﾄﾙ行の幅
    Private Const CMlngvsfChipMapRowHeightMin As Integer = 33                      '行の高さの最小値
    Private Const CMlngvsfChipMapColWidthMin As Integer = 61                      '列の幅の最小値
    Private Const CMlngvsfChipMapNomalHeight As Integer = 470                     '標準高さ
    Private Const CMlngvsfChipMapNomalWidth As Integer = 814                     '標準幅
    Private Const CMlngvsfChipMapNomalMaxRows As Integer = 19                        '標準行数
    Private Const CMlngvsfChipMapNomalMaxCols As Integer = 13                        '標準列数

    '@ｸﾞﾘｯﾄﾞ共通定数
    Private Const CMlngvsfFixedRow As Integer = 0                         'ﾀｲﾄﾙ行
    Private Const CMlngvsfFixedCol As Integer = 0                         '基準列

    '@色宣言
    Private Const CMlngEnableFalseColor As Integer = &H80000004                '灰色(使用不可)
    Private Const CMlngChipNoForeColor As Integer = &H808080                  '灰色(ﾁｯﾌﾟ№文字色)
    Private Const CMlngFuryouColor As Integer = &HC0C0FF                  'ﾋﾟﾝｸ(不良色)
    Private Const CMlngHaraidashiColor As Integer = &HC0FFC0                  '薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ(払出色)
    Private Const CMlngChipOmoteBackColor As Integer = &H404040                  '濃い灰色(ﾁｯﾌﾟ用表表示時の概観ﾊﾞｯｸｶﾗｰ)

    '@入力ﾁｪｯｸ区分宣言
    Private Const CMstrstrInputCheckKbn0 As String = ""                      '入力ﾁｪｯｸ区分(ﾁｯﾌﾟ情報未読込)
    Private Const CMstrstrInputCheckKbn1 As String = "1"                     '入力ﾁｪｯｸ区分(ﾁｯﾌﾟ情報未入力)
    Private Const CMstrstrInputCheckKbn2 As String = "2"                     '入力ﾁｪｯｸ区分(ﾁｯﾌﾟ情報入力済)

    '@自工程更新ﾌﾗｸﾞ
    Private Const CMstrNowstepEditDisable As String = "0"                     '自工程更新なし
    Private Const CMstrNowstepEditEnable As String = "1"                     '自工程更新あり

    '@その他宣言
    Private Const CMstrYenSign As String = "\"                     'ﾌｧｲﾙﾊﾟｽ用
    Private Const CMstrFormatDate As String = "yyMMddHHmmss"          'ﾌｧｲﾙﾊﾟｽ用

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName As String = "frmxxEN01Y1"
    Private Const CMstrPrvWFInfoSel As String = "prvWFInfo_Sel"         'ﾚｽﾎﾟﾝｽ用
    Private Const CMstrVsfWFMapEnterCell As String = "vsfWFMap_EnterCell"    'ﾚｽﾎﾟﾝｽ用

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mlblnRowHeigthOver As Boolean                  '高さｵｰﾊﾞｰ区分(True:ｵｰﾊﾞｰ,False:規定内)
    Private mlblnColWidthOver As Boolean                  '幅ｵｰﾊﾞｰ区分(True:ｵｰﾊﾞｰ,False:規定内)
    Private mlngWFNowIndex As Integer                  'WFﾏｯﾌﾟ情報の現在ｲﾝﾃﾞｯｸｽ(1～25)
    Private mlngAllDisplayRowHeigth As Integer                  '全体表示時の1行の高さ
    Private mlngAllDisplayColWidth As Integer                  '全体表示時の1列の幅
    Private mblnPrinting As Boolean                  '印刷中区分(True：印刷中、False：印刷前/印刷後)

    '@画面構造体情報
    '@ﾁｯﾌﾟGrid構造体
    Private mblnChipGridMap(,) As Boolean                  'ﾁｯﾌﾟGridのMAP情報
    Private mlngChipGridMaxRows As Integer                  'ﾁｯﾌﾟGridの最大行数
    Private mlngChipGridMaxCols As Integer                  'ﾁｯﾌﾟGridの最大列数

    '@ﾁｯﾌﾟ情報
    Private Structure LotWFChipInfo
        Dim blnEnableKbn As Boolean                  '使用可能区分(True:使用可能、False:使用不可)→　ﾊﾞｯｸｶﾗｰと同様
        Dim strChipId As String                   'ﾁｯﾌﾟID
        Dim strOldClass As String                   '入力前区分(1:良品、2:不良、3:払い出し、4:保留、5:傾向)
        Dim strOldClassID As String                   '入力前項目ID
        Dim strNewClass As String                   '入力後区分(1:良品、2:不良、3:払い出し、4:保留、5:傾向)
        Dim strNewClassID As String                   '入力後項目ID
    End Structure

    '@WF情報
    Private Structure LotWFInfo
        Dim strWfId As String                   'WFID
        Dim strClass As String                   '区分
        Dim strClassID As String                   '項目ID
        Dim typChipList(,) As LotWFChipInfo            'ﾁｯﾌﾟ情報ﾘｽﾄ
        Dim strInputCheckKbn As String                   '入力ﾁｪｯｸ区分(空白:ﾁｯﾌﾟ情報が未読込み、1:未入力、2:入力済)
    End Structure
    Private mtypWFInfo() As LotWFInfo                'WF情報ﾘｽﾄ

    '@初回表示ﾌﾗｸﾞ
    Private mlngCnt As Integer                  '引継ぎ構造体配列要素用ｶｳﾝﾀ
    Private mlngBeforeRow As Integer                  '印刷前行番号
    Private mblnFirstDispFlg As Boolean                  '初回表示判定ﾌﾗｸﾞ
    Private mblnCancelFlg As Boolean                  '処理ｷｬﾝｾﾙﾌﾗｸﾞ
    Private buttonProcessing As Boolean                  'NSYS ボタン2度押し対策   
    Private mblnCloseFromControlMenu As Boolean                  'NSYS システムコマンドでの画面クローズ   
    Private mblnWindowClose As Boolean                  'NSYS WindowCloseフラグ
    Private mobjBitmap As Bitmap                   'NSYS キャプチャー画像

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
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 17:25:34 N.Kojima
    '更新日：2006/10/05 (Thu) 19:03:44 N.Kojima
    '備　考：
    '　　　：2006/10/05 (Thu) 19:03:44 N.Kojima     棚卸の機能変更に伴い、処理削除。(案件№01517)
    Private Sub Form_Load()

        Try

            '@=======================
            '@ 画面初期化
            '@=======================
            Call prvfrmxxEN01Y1_Init()

            'NSYS 画面表示位置
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
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

    '関数名：frmxxEN01Y1_Shown
    '機　能：フォームOpen時の処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/11/06 NSYS
    '更新日：2019/11/06 NSYS
    '備　考：星取表のハードコピー白抜け対策
    Private Sub frmxxEN01Y1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Dim llngCnt As Integer  '汎用ｶｳﾝﾀ

        Try

            '再描画
            Me.Refresh()

            'NSYS Form_Activateから移動（ボタンのクリック処理が実行されない対策）START ------------------------------
            '@印刷区分を設定（印刷中）
            mblnPrinting = True

            For mlngCnt = 0 To plngPrintLotCnt - 1
                '@処理ｷｬﾝｾﾙﾌﾗｸﾞがTrueか
                If mblnCancelFlg = True Then
                    Exit For
                End If

                '@各種ﾗﾍﾞﾙに引継ぎ情報を表示
                lblCarrierID.Text = ptypTakeOverDataEN01Y0(mlngCnt).strCarrierId             'ｷｬﾘｱID
                lblLotID.Text = ptypTakeOverDataEN01Y0(mlngCnt).strLotID                     'ﾛｯﾄID
                lblFlowClass.Text = ptypTakeOverDataEN01Y0(mlngCnt).strFlowClass             '種別
                lblOpName.Text = ptypTakeOverDataEN01Y0(mlngCnt).strOpID                     '大工程
                lblStepName.Text = ptypTakeOverDataEN01Y0(mlngCnt).strStepID                 '小工程
                '@↓2014/02/18 (Tue) 09:07:28 H.Hayashi ************************************************** GNS_IF対応
                '@        lblMPROrder.Caption = ptypTakeOverDataEN01Y0(mlngCnt).strMPROrder               '量産ｵｰﾀﾞｰ
                '@↑2014/02/18 (Tue) 09:07:28 H.Hayashi ************************************************** GNS_IF対応
                lblPartCode.Text = ptypTakeOverDataEN01Y0(mlngCnt).strPartCode               '部品ｺｰﾄﾞ
                '@↓2014/02/18 (Tue) 09:07:56 H.Hayashi ************************************************** GNS_IF対応
                '@        lblPoint.Caption = ptypTakeOverDataEN01Y0(mlngCnt).strPoint                     'ﾎﾟｲﾝﾄ
                '@↑2014/02/18 (Tue) 09:07:56 H.Hayashi ************************************************** GNS_IF対応

                '@必要とあらば復活
                '''        '@制御をOSに渡す
                '''        '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
                '''        '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
                '''        DoEvents

                '@引数のﾛｯﾄIDが空白かどうか判定する
                If ptypTakeOverDataEN01Y0(mlngCnt).strLotID <> vbNullString Then
                    '@空白でない場合

                    '@WF情報取得
                    Call prvWFInfo_Sel()

                    '@印刷要求判定ﾌﾗｸﾞがTrue(印刷)の場合
                    If pblnReqPrint = True Then

                        With vsfWFMap
                            For llngCnt = 1 To .Rows.Count - 1
                                '@WF_IDが存在する場合
                                If .GetData(llngCnt, CMlngvsfWFMapID) <> vbNullString Then
                                    '@ﾁｪｯｸ処理
                                    .SetCellCheck(llngCnt, CMlngvsfWFMapChkBox, CheckEnum.Checked)
                                Else
                                    '@ﾁｪｯｸﾎﾞｯｸｽの初期化
                                    .SetCellCheck(llngCnt, CMlngvsfWFMapChkBox, CheckEnum.Unchecked)
                                End If
                            Next llngCnt
                        End With

                        '@各種ﾎﾞﾀﾝを有効にする
                        cmdPrint.Enabled = True             '星取表印刷
                        cmdAllCancel.Enabled = True         '全取消

                        '@全選択ﾎﾞﾀﾝを無効にする
                        cmdAllSelect.Enabled = False

                        '@印刷処理前の行番号を格納
                        mlngBeforeRow = vsfWFMap.Row

                        '@星取表印刷中止ﾎﾞﾀﾝを有効にする
                        cmdPrintCancel.Enabled = True

                        '@WF分だけ印刷処理を実行
                        Call prvFormPrint_proc()

                        '@印刷処理前の行番号にする
                        vsfWFMap.Row = mlngBeforeRow

                        '@印刷中止ﾎﾞﾀﾝを無効にする
                        cmdPrintCancel.Enabled = False
                    End If
                End If
            Next mlngCnt

            mlngCnt = 0

            '@印刷区分を設定（印刷終了）
            mblnPrinting = False

            '@処理ｷｬﾝｾﾙﾌﾗｸﾞの初期化
            mblnCancelFlg = False

            With vsfWFMap
                '@WF一覧が有効な場合
                If .Enabled = True Then
                    '@WFID列に設定
                    .Col = CMlngvsfWFMapID
                    '@WF一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfWFMap)
                End If
            End With
            'NSYS Form_Activateから移動（ボタンのクリック処理が実行されない対策）END   ------------------------------

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "frmxxEN01Y1_Shown"
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
    '作成日：2006/08/02 (Wed) 18:08:26 N.Kojima
    '更新日：2006/08/02 (Wed) 18:08:26
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@FormLoad後、最初の1回しか処理しない
            If mblnFirstDispFlg = True Then
                Exit Sub
            End If

            '@処理ｷｬﾝｾﾙﾌﾗｸﾞがTrueの場合は処理しない
            If mblnCancelFlg = True Then
                Exit Sub
            End If

            '@初回表示ﾌﾗｸﾞをTrue(=表示済み)に設定
            mblnFirstDispFlg = True

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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　ｱﾝﾛｰﾄﾞ時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 18:10:01 N.Kojima
    '更新日：2006/08/02 (Wed) 18:10:01
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@以下の条件の場合処理ｷｬﾝｾﾙ
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②DoEvents制御中の場合
            '@　③印刷中の場合
            If Cursor.Current = Cursors.WaitCursor Or
                pblnTrnFlag = True Or
                mblnPrinting = True Then

                e.Cancel = True
                Exit Sub
            End If

            '@"×"にて閉じたか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ　押下＆Click時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            Erase mtypWFInfo     'WF情報格納用配列   
            'mtypWFInfo = New List(Of LotWFInfo)
            Erase mblnChipGridMap                       'ﾁｯﾌﾟ情報格納用配列
            mlngCnt = 0                                 '引継ぎ構造体配列要素用ｶｳﾝﾀ
            mlngBeforeRow = 0                           '印刷前行番号
            mblnFirstDispFlg = False                    '初回表示判定ﾌﾗｸﾞ

            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｸﾘｱ
            Clipboard.Clear()

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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　KeyDown時処理
    '引　数：KeyCode    ：入力ｷｰｺｰﾄﾞ
    '　　　：Shift      ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 18:08:53 N.Kojima
    '更新日：2006/08/02 (Wed) 18:08:53
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の条件の場合処理ｷｬﾝｾﾙ
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Then


                Exit Sub
            End If

            '@Enterｷｰの場合
            If e.KeyCode = Keys.Return Then
                SendKeys.SendWait(CPstrSendKeysTab)
                e.Handled = True
            End If

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 WFｽﾛｯﾄﾏｯﾌﾟ 〓
                Case vsfWFMap.Name

                    With vsfWFMap

                        '@ｽﾍﾟｰｽｷｰではない場合は抜ける
                        If e.KeyCode <> Keys.Space Then
                            Exit Sub
                        End If

                        '@=======================
                        '@ WFｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click処理
                        '@=======================
                        Call vsfWFMap_Click(sender, e)

                    End With
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/04 (Fri) 14:58:55 N.Kojima
    '更新日：2006/08/04 (Fri) 14:58:55
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

            '@以下の条件の場合処理ｷｬﾝｾﾙ
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②DoEvents制御中の場合
            '@　③印刷中の場合
            If Cursor.Current = Cursors.WaitCursor Or
                pblnTrnFlag = True Or
                mblnPrinting = True Then

                Exit Sub
            End If

            '@∇∇∇∇∇∇∇∇∇∇∇
            '@ ｱﾝﾛｰﾄﾞ処理
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWFMap_Click
    '機　能：WFｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/04 (Fri) 17:07:19 N.Kojima
    '更新日：2006/10/10 (Tue) 10:29:12 N.Kojima
    '備　考：
    '　　　：2006/10/10 (Tue) 10:29:12 N.Kojima     全選択ﾎﾞﾀﾝの制御を追加。(案件№01517)
    Private Sub vsfWFMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWFMap.Click

        Dim llngCnt As Integer  '汎用ｶｳﾝﾀ
        Dim lblnCkeckFlag As Boolean  'ﾁｪｯｸ判定ﾌﾗｸﾞ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            'NSYS データ行がない場合は処理を抜ける
            If vsfWFMap.Rows.Count <= vsfWFMap.Rows.Fixed Then
                Return
            End If


            '@印刷中の場合
            If mblnPrinting = True Then
                Exit Sub
            End If

            With vsfWFMap

                '@ﾁｪｯｸﾎﾞｯｸｽ行以外の行、又はWF_IDがNULLの場合は、処理終了          
                If .Col <> CMlngvsfWFMapChkBox Or .GetData(.Row, CMlngvsfWFMapID) = vbNullString Then
                    Exit Sub
                End If

                '@ﾁｪｯｸ判定ﾌﾗｸﾞの初期化
                lblnCkeckFlag = False

                '@選択行のﾁｪｯｸﾎﾞｯｸｽのﾁｪｯｸが外れている場合
                If .GetCellCheck(.Row, CMlngvsfWFMapChkBox) = CheckEnum.Unchecked Then
                    '@ﾁｪｯｸなし→ﾁｪｯｸ
                    .AllowEditing = True
                    .SetCellCheck(.Row, CMlngvsfWFMapChkBox, CheckEnum.Checked)     'ﾁｪｯｸ
                    .AllowEditing = False

                    '@各種ﾎﾞﾀﾝを有効にする
                    cmdPrint.Enabled = True             '星取表印刷
                    cmdAllCancel.Enabled = True         '全取消

                    '@全選択ﾎﾞﾀﾝの制御
                    For llngCnt = 1 To .Rows.Count - 1
                        '@WFIDが存在するか
                        If .GetData(llngCnt, CMlngvsfWFMapID) <> vbNullString Then
                            '@ﾁｪｯｸが付いているか
                            If .GetCellCheck(llngCnt, CMlngvsfWFMapChkBox) = CheckEnum.Checked Then
                                '@ﾁｪｯｸ付いている場合は、ﾌﾗｸﾞをTrue(=ﾁｪｯｸあり)にする
                                lblnCkeckFlag = True
                            Else
                                '@ﾁｪｯｸ付いていない場合は、ﾌﾗｸﾞをFalse(=ﾁｪｯｸなし)にする
                                lblnCkeckFlag = False
                                Exit For
                            End If
                        End If
                    Next llngCnt

                    '@全ての行がﾁｪｯｸされている場合は、全選択ﾎﾞﾀﾝを無効にする
                    If lblnCkeckFlag = True Then
                        cmdAllSelect.Enabled = False     '全選択
                    End If

                Else
                    '@ﾁｪｯｸ→ﾁｪｯｸなし
                    .AllowEditing = True
                    .SetCellCheck(.Row, CMlngvsfWFMapChkBox, CheckEnum.Unchecked)   'ﾁｪｯｸ解除
                    .AllowEditing = False

                    '@全選択ﾎﾞﾀﾝを有効にする
                    cmdAllSelect.Enabled = True

                    For llngCnt = 1 To .Rows.Count - 1

                        '@ﾁｪｯｸが付いているか
                        If .GetCellCheck(llngCnt, CMlngvsfWFMapChkBox) = CheckEnum.Checked Then

                            '@ﾁｪｯｸ付いている場合は、ﾌﾗｸﾞをTrue(=ﾁｪｯｸあり)にする
                            lblnCkeckFlag = True
                            Exit For
                        End If
                    Next llngCnt

                    '@ﾁｪｯｸ行が存在しない場合は、各種ﾎﾞﾀﾝを無効にする
                    If lblnCkeckFlag = False Then

                        cmdPrint.Enabled = False            '星取表印刷
                        cmdPrintCancel.Enabled = False      '星取表印刷中止
                        cmdAllCancel.Enabled = False        '全取消
                    End If
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWFMap_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWFMap_EnterCell
    '機　能：WFｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/04 (Fri) 16:11:30 N.Kojima
    '更新日：2006/10/05 (Thu) 17:07:51 N.Kojima
    '備　考：
    '　　　：2006/10/05 (Thu) 17:07:51 N.Kojima     棚卸の機能変更に伴い、処理修正。(案件№01517)
    Private Sub vsfWFMap_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWFMap.EnterCell

        Dim lblnAns As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypWFMapInfo As WFMapInfo            'WFﾏｯﾌﾟ情報構造体
        Dim llngCnt As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngWFStartIndex As Integer              'WFの開始ｽﾛｯﾄ№
        Dim llngStartRowPos As Integer              '開始行位置
        Dim llngStartColPos As Integer              '開始列位置
        Dim llngEndRowPos As Integer              '終了行位置
        Dim llngEndColPos As Integer              '終了列位置
        Dim lstrSearchDate As String               '検索日時
        Dim lcellRange As CellRange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfWFMap.Rows.Count <= vsfWFMap.Rows.Fixed Then
                Return
            End If


            '@読み込み判定
            If vsfWFMap.Row < 1 Then
                Exit Sub
            End If

            '@取得してからWFMAP移動を取得と同時にMAP移動とする為に,DoEvents処理を追加


            '@WFﾏｯﾌﾟ情報の現在ｲﾝﾃﾞｯｸｽ(1～25)の設定
            mlngWFNowIndex = CMlngvsfWFMapMaxSlotID - vsfWFMap.Row + 1

            '@ﾚｽﾎﾟﾝｽ測定開始(初期WF_IDの場合はｷｬﾘｱのLost自に行う為、初期WF以外の場合に測定する)
            llngWFStartIndex = 0

            For llngCnt = 0 To CMlngvsfWFMapMaxSlotID - 1

                '@WF構造体からの検索
                If mtypWFInfo(llngCnt).strWfId <> vbNullString Then

                    llngWFStartIndex = llngCnt
                    Exit For
                End If
            Next llngCnt

            '@ｽﾛｯﾄﾏｯﾌﾟの現在ｲﾝﾃﾞｯｸｽより、WFの開始ｽﾛｯﾄ№が小さい場合
            If mlngWFNowIndex > llngWFStartIndex Then

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrVsfWFMapEnterCell)
            End If

            '@WFﾏｯﾌﾟ情報の設定
            With mtypWFInfo(mlngWFNowIndex)

                '@WFﾏｯﾌﾟ情報が未入力の場合、読み込みを行う
                If .strInputCheckKbn = CMstrstrInputCheckKbn0 And
                    .strWfId <> vbNullString Then

                    '@検索日時の設定
                    lstrSearchDate = ptypTakeOverDataEN01Y0(0).strSearchDate

                    '@=======================
                    '@ ﾁｯﾌﾟ情報取得処理
                    '@=======================
                    '@Msg送信
                    lblnAns = pubblnWfChipSnapShotList_Sel(CMstrwf__chipsnapshotlistVer,
                                                           lblLotID.Text,
                                                           .strWfId,
                                                           lstrSearchDate,
                                                           ltypWFMapInfo)

                    '@結果判定
                    If lblnAns = True Then

                        '@=======================
                        '@ WF情報設定処理
                        '@=======================
                        Call prvWFMapInfo_Set(ltypWFMapInfo)

                        '@WF情報ｸﾞﾘｯﾄﾞを有効にする
                        vsfWFMap.Enabled = True
                    End If
                Else
                    '@ﾚｽﾎﾟﾝｽ測定中止
                    If mlngWFNowIndex > llngWFStartIndex Then

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrVsfWFMapEnterCell)
                    End If
                End If

                '@=======================
                '@ ﾁｯﾌﾟｸﾞﾘｯﾄﾞ設定処理
                '@=======================
                Call prvChipMapGrid_Set()

            End With

            '@-----------------------
            '@ ﾁｯﾌﾟ№の表示
            '@-----------------------
            '@ﾁｯﾌﾟ範囲選択判定
            If vsfChipMap.Row >= 1 And vsfChipMap.Col >= 1 Then

                '@ﾁｯﾌﾟGridの選択状態の参照
                lcellRange = vsfChipMap.Selection
                llngStartRowPos = lcellRange.r1
                llngStartColPos = lcellRange.c1
                llngEndRowPos = lcellRange.r2
                llngEndColPos = lcellRange.c2
            End If

            '@ﾚｽﾎﾟﾝｽ終了
            If mlngWFNowIndex > llngWFStartIndex Then

                '@ﾚｽﾎﾟﾝｽ終了
                Call publngResponseEnd(CMstrFormName, CMstrVsfWFMapEnterCell)
            End If

            '@選択されているWFの「ｳｪﾊ№」をﾗﾍﾞﾙに表示
            With vsfWFMap

                '@ﾃﾞｰﾀ行が選択され、かつWF№が存在する場合
                If .Row > 0 And .GetData(.Row, CMlngvsfWFMapID) <> vbNullString Then

                    '@ﾗﾍﾞﾙにｳｪﾊ№を表示
                    lblWFNo.Text = .GetData(.Row, CMlngvsfWFMapID)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWFMap_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChipMap_EnterCell
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/04 (Fri) 16:12:08 N.Kojima
    '更新日：2006/08/04 (Fri) 16:12:08
    '備　考：
    Private Sub vsfChipMap_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfChipMap.EnterCell

        Dim llngStartRowPos As Integer      '開始行位置
        Dim llngStartColPos As Integer      '開始列位置
        Dim llngEndRowPos As Integer      '終了行位置
        Dim llngEndColPos As Integer      '終了列位置
        Dim lcellRange As CellRange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfChipMap.Rows.Count <= vsfChipMap.Rows.Fixed Then
                Return
            End If


            '@ﾁｯﾌﾟ範囲選択判定
            If vsfChipMap.Row < 1 Or vsfChipMap.Col < 1 Then

                '@未選択時は処理ｽｷｯﾌﾟ
                Exit Sub
            End If

            '@ﾁｯﾌﾟGridの選択状態の参照
            lcellRange = vsfChipMap.Selection
            llngStartRowPos = lcellRange.r1
            llngStartColPos = lcellRange.c1
            llngEndRowPos = lcellRange.r2
            llngEndColPos = lcellRange.c2


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfChipMap_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdAllSelect_Click
    '機　能：全選択ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 11:20:24 N.Kojima
    '更新日：2006/08/02 (Wed) 11:20:24
    '備　考：
    Private Sub cmdAllSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllSelect.Click

        Dim llngCnt As Integer  '汎用ｶｳﾝﾀ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            '@印刷中の場合
            If mblnPrinting = True Then
                Exit Sub
            End If

            With vsfWFMap
                For llngCnt = 1 To .Rows.Count - 1
                    '@WF_IDが存在する場合
                    If .GetData(llngCnt, CMlngvsfWFMapID) <> vbNullString Then
                        '@ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸを付ける
                        .SetCellCheck(llngCnt, CMlngvsfWFMapChkBox, CheckEnum.Checked)
                    End If
                Next llngCnt

                '@全選択ﾎﾞﾀﾝを無効にする
                cmdAllSelect.Enabled = False

                '@各種ﾎﾞﾀﾝを有効にする
                cmdAllCancel.Enabled = True     '全取消
                cmdPrint.Enabled = True         '星取表印刷
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAllSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdAllCancel_Click
    '機　能：全取消ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 11:20:24 N.Kojima
    '更新日：2006/08/02 (Wed) 11:20:24
    '備　考：
    Private Sub cmdAllCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllCancel.Click

        Dim llngCnt As Integer  '汎用ｶｳﾝﾀ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            '@印刷中の場合
            If mblnPrinting = True Then
                Exit Sub
            End If

            With vsfWFMap

                For llngCnt = 1 To .Rows.Count - 1

                    '@ﾁｪｯｸﾎﾞｯｸｽのﾁｪｯｸを外す
                    .SetCellCheck(llngCnt, CMlngvsfWFMapChkBox, CheckEnum.Unchecked)
                Next llngCnt

                '@各種ﾎﾞﾀﾝを無効にする
                cmdAllCancel.Enabled = False        '全取消
                cmdPrint.Enabled = False            '星取表印刷

                '@全選択ﾎﾞﾀﾝを有効にする
                cmdAllSelect.Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAllCancel_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPrint_Click
    '機　能：印刷ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 12:03:21 N.Kojima
    '更新日：2006/10/11 (Wed) 15:48:22 N.Kojima
    '備　考：
    '　　　：2006/10/11 (Wed) 15:48:22 N.Kojima     棚卸機能の改善に伴う、処理追加。(案件№01517)
    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPrint.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005W)
            '@"<TRM5WI>$$印刷を行います。処理に時間がかかりますが、画面には触れずにお待ちください。
            '@           $印刷途中で処理を中断する場合は、[星取表印刷中止]ボタンを$押下してください。"
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

            '@処理ｷｬﾝｾﾙﾌﾗｸﾞの初期化
            mblnCancelFlg = False

            '@印刷区分を設定(印刷中)
            mblnPrinting = True

            '@=======================
            '@ 印刷処理　※WF枚数分
            '@=======================
            Call prvFormPrint_proc()

            '@印刷中止ﾎﾞﾀﾝを無効にする
            cmdPrintCancel.Enabled = False

            '@印刷区分を設定(印刷終了)
            mblnPrinting = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPrint_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

            '@印刷区分を設定(印刷終了)
            mblnPrinting = False

        End Try
    End Sub

    '関数名：cmdPrintCancel_Click
    '機　能：印刷中止ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 12:03:21 N.Kojima
    '更新日：2006/10/10 (Tue) 13:45:06 N.Kojima
    '備　考：
    '　　　：2006/10/10 (Tue) 13:45:06 N.Kojima     棚卸機能の改善に伴い、処理修正。(案件№01517)
    Private Sub cmdPrintCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPrintCancel.Click

        Dim llngAns As Integer  '戻り値格納用

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005V)
            '@"<TRM5VI>$$印刷処理を中止します。よろしいですか？"
            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

            '@要求確認
            If llngAns = vbNo Then
                '@印刷続行
                Exit Sub
            End If

            'NSYS ファイルは作成しないため不要
            '@印刷jobを直ちに終了           
            'Printer.KillDoc
            'Printer.EndDoc

            '@星取表印刷中止ﾎﾞﾀﾝを無効にする
            cmdPrintCancel.Enabled = False

            '@処理ｷｬﾝｾﾙﾌﾗｸﾞをTrueに
            mblnCancelFlg = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPrintCancel_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              *関数の記述*
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：prvfrmxxEN01Y1_Init
    '機　能：画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 17:27:10 N.Kojima
    '更新日：2014/01/16 (Thu) 11:47:08 T.Oide
    '備　考：
    '　　　：2006/09/26 (Tue) 09:55:32 N.Kojima     棚卸機能改善に伴い、処理修正&削除。(案件№01517)
    Private Sub prvfrmxxEN01Y1_Init()

        Try

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = CPstrSubFormEN01Y1

            '@各ｺﾝﾄﾛｰﾙを初期化
            '@ﾍｯﾀﾞｰ
            lblCarrierID.Text = vbNullString         'ｷｬﾘｱID
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '種別
            lblOpName.Text = vbNullString            '大工程名
            lblStepName.Text = vbNullString          '小工程名

            '@ﾎﾞﾃﾞｨ
            lblWFNo.Text = vbNullString              'ｳｪﾊ№
            '@↓2014/01/16 (Thu) 11:46:51 T.Oide **************************************************
            '@    lblMPROrder.Caption = vbNullString          '量産ｵｰﾀﾞｰ
            '@↑2014/01/16 (Thu) 11:46:51 T.Oide **************************************************
            lblPartCode.Text = vbNullString          '部品ｺｰﾄﾞ

            '@↓2014/01/16 (Thu) 11:45:03 T.Oide **************************************************
            '@    lblPoint.Caption = vbNullString             'ﾎﾟｲﾝﾄ
            '@↑2014/01/16 (Thu) 11:45:03 T.Oide **************************************************

            '@各種ﾎﾞﾀﾝの初期化
            cmdPrint.Enabled = False                    '星取表印刷
            cmdPrintCancel.Enabled = False              '星取表印刷中止
            cmdAllCancel.Enabled = False                '全取消
            cmdAllSelect.Enabled = False                '全選択

            '@ﾓｼﾞｭｰﾙ変数の初期化
            mblnFirstDispFlg = False                    '初回表示判定ﾌﾗｸﾞ
            mblnCancelFlg = False                       '処理ｷｬﾝｾﾙﾌﾗｸﾞ
            mlngCnt = 0                                 '引継ぎ構造体配列要素用ｶｳﾝﾀ
            mlngBeforeRow = 0                           '印刷前選択行
            mblnPrinting = False                        '印刷中区分

            '@=======================
            '@ 各種ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfWFMap_Init()                       'WF情報
            Call prvVsfChipMap_Init()                     'ﾁｯﾌﾟ情報(WFﾏｯﾌﾟ)

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01Y1_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfWFMap_Init
    '機　能：WF情報ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 17:27:10 N.Kojima
    '更新日：2006/08/02 (Wed) 17:27:10
    '備　考：
    Private Sub prvVsfWFMap_Init()

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ

        Try

            '@WF情報の初期化
            With vsfWFMap

                .Rows(CMlngvsfFixedRow).Height = CMlngvsfWFMapTitleHeight     'ﾀｲﾄﾙの高さ設定(270)                             
                .Select(CMlngvsfWFMapID, CMlngvsfWFMapID, CMlngvsfWFMapID, .Cols.Count - 1)    'Col選択(WFID～ﾁｪｯｸBOX)
                .Font = New Font(.Font.FontFamily, CMvsfTitleFontSize)                          'ﾌｫﾝﾄｻｲｽﾞ設定(12pt)                          
                .FocusRect = FocusRectEnum.Light                                 'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠(細い枠)

                '@ﾀｲﾄﾙの色設定(WFID,ﾁｪｯｸBOX)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.BackColor = Color.Navy              '背景色
                lFixedStyle.ForeColor = Color.Yellow            '文字色

                '@行番号、書式、高さの設定
                For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                    '@背景色設定(白)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID, llngCnt, .Cols.Count - 1)
                    cellRange.Style = newStyle
                    '@高さ
                    .Rows(llngCnt).Height = CMlngvsfWFMapRowHeightMin
                Next llngCnt

                '@ｸﾞﾘｯﾄﾞ無効
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfWFMap_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfChipMap_Init
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 17:27:10 N.Kojima
    '更新日：2006/08/02 (Wed) 17:27:10
    '備　考：
    Private Sub prvVsfChipMap_Init()

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt2 As Integer      '汎用ｶｳﾝﾀ2

        Try

            '@ﾁｯﾌﾟ情報(WFﾏｯﾌﾟ)の初期化
            With vsfChipMap
                .Rows.Count = CMlngvsfChipMapNomalMaxRows + 1       '行数設定
                .Cols.Count = CMlngvsfChipMapNomalMaxCols + 1       '列数設定
                .BackColor = Color.White                            '背景色設定
                .ForeColor = Color.Black                            '文字色設定
                .Row = -1                                           'ｶﾚﾝﾄ行設定
                .Col = -1                                           'ｶﾚﾝﾄ列設定
                .AllowResizing = False                               '編集可否(編集不可)
                .Select(CMlngvsfChipMapNo, CMlngvsfChipMapNo, CMlngvsfChipMapNo, .Cols.Count - 1)
                .Font = New Font(.Font.FontFamily, CMvsfTitleFontSize)              'ﾌｫﾝﾄｻｲｽﾞ

                '@文字配置(右中央寄せ)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_flexAlignRightCenter")
                Dim cellRange As CellRange = .GetCellRange(1, 1, mlngChipGridMaxRows, mlngChipGridMaxCols)
                newStyle.TextAlign = TextAlignEnum.RightCenter
                '@背景色(白)
                newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle.BackColor = Color.White
                cellRange = .GetCellRange(1, 1, CMlngvsfChipMapNomalMaxRows, CMlngvsfChipMapNomalMaxCols)
                cellRange.Style = newStyle

                '@ﾀｲﾄﾙの高さ、幅の設定
                .Rows(CMlngvsfFixedRow).Height = CMlngvsfChipMapTitleHeight
                .Cols(CMlngvsfFixedCol).Width = CMlngvsfChipMapTitleWidth

                '@ﾀｲﾄﾙの色設定(文字：黄色、背景：青) 
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.BackColor = Color.Navy              '背景色
                lFixedStyle.ForeColor = Color.Yellow            '文字色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                '@高さ、幅の最小値、最大値の初期設定
                .Rows.MaxSize = 0
                .Rows.MinSize = 0
                .Cols.MaxSize = 0
                .Cols.MinSize = 0

                '@行番号、書式、高さの設定
                For llngCnt = 1 To CMlngvsfChipMapNomalMaxRows
                    .SetData(llngCnt, CMlngvsfChipMapNo, Format$(llngCnt, CPstrSlotNoFormat))
                    .Cols(CMlngvsfChipMapNo).TextAlign = TextAlignEnum.RightCenter
                    .Rows(llngCnt).Height = CMlngvsfChipMapRowHeightMin
                Next llngCnt

                '@列№、書式、幅の設定
                For llngCnt2 = 1 To CMlngvsfChipMapNomalMaxCols
                    .SetData(CMlngvsfChipMapNo, llngCnt2, Chr(CPlngKeyAsciiUppA + llngCnt2 - 1))
                    .Cols(CMlngvsfChipMapNo).TextAlign = TextAlignEnum.CenterCenter
                    .Cols(llngCnt2).Width = CMlngvsfChipMapColWidthMin
                Next llngCnt2

                '@Gridの高さ、幅の再調整
                .Height = CMlngvsfChipMapNomalHeight
                .Width = CMlngvsfChipMapNomalWidth

                '@ｳｪﾊﾏｯﾌﾟを無効にする
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfChipMap_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipGridInfo_Set
    '機　能：ﾁｯﾌﾟ情報設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 11:43:40 N.Kojima
    '更新日：2006/10/05 (Thu) 18:58:33 N.Kojima
    '備　考：
    '　　　：2006/10/05 (Thu) 18:58:33 N.Kojima     棚卸の機能変更に伴い、処理修正。(案件№01517)
    Private Sub prvChipGridInfo_Set()

        Dim llngCnt As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngChipCount As Integer      'ﾁｯﾌﾟ数

        Try

            '@ﾁｯﾌﾟGridの最大行列数の初期化
            mlngChipGridMaxRows = 0
            mlngChipGridMaxCols = 0

            '@ﾁｯﾌﾟGrid構造体の設定
            Erase mblnChipGridMap

            '@最大行数の設定
            mlngChipGridMaxRows = ptypTakeOverDataEN01Y0(mlngCnt).lngRowNumListCnt

            '@最大列数の設定
            For llngCnt = 0 To ptypTakeOverDataEN01Y0(mlngCnt).lngRowNumListCnt - 1
                With ptypTakeOverDataEN01Y0(mlngCnt).typRowNumList(llngCnt)
                    '@最大列数の設定
                    If IsNumeric(.strChipCount) = True And IsNumeric(.strStartColumn) = True Then
                        llngChipCount = Val(.strStartColumn) + Val(.strChipCount) - 1
                        If llngChipCount > mlngChipGridMaxCols Then
                            mlngChipGridMaxCols = llngChipCount
                        End If
                    End If
                End With
            Next llngCnt

            '@ﾁｯﾌﾟGrid構造体の配列定義
            If mlngChipGridMaxRows = 0 Or mlngChipGridMaxCols = 0 Then
                Exit Sub
            End If
            ReDim mblnChipGridMap(mlngChipGridMaxRows, mlngChipGridMaxCols)


            '@-----------------------
            '@ ﾁｯﾌﾟGridの高さ、幅のｵｰﾊﾞｰ区分設定
            '@-----------------------
            '@高さ
            If mlngChipGridMaxRows > CMlngvsfChipMapNomalMaxRows Then
                mlblnRowHeigthOver = True
            Else
                mlblnRowHeigthOver = False
            End If

            '@幅
            If mlngChipGridMaxCols > CMlngvsfChipMapNomalMaxCols Then
                mlblnColWidthOver = True
            Else
                mlblnColWidthOver = False
            End If


            '@ﾁｯﾌﾟGrid構造体の使用可否設定
            For llngCnt = 0 To mlngChipGridMaxRows - 1

                With ptypTakeOverDataEN01Y0(mlngCnt).typRowNumList(llngCnt)

                    If llngCnt = .strRowNum - 1 Then

                        '@使用不可を設定
                        For llngCnt2 = 0 To Val(.strStartColumn - 1) - 1
                            mblnChipGridMap(llngCnt + 1, llngCnt2 + 1) = False
                        Next llngCnt2

                        '@使用可を設定
                        For llngCnt2 = Val(.strStartColumn - 1) To Val(.strStartColumn - 1) + Val(.strChipCount) - 1
                            mblnChipGridMap(llngCnt + 1, llngCnt2 + 1) = True
                        Next llngCnt2

                        '@使用不可を設定
                        For llngCnt2 = Val(.strStartColumn - 1) + Val(.strChipCount) + 1 To mlngChipGridMaxCols - 1
                            mblnChipGridMap(llngCnt + 1, llngCnt2 + 1) = False
                        Next llngCnt2
                    Else
                        '@使用不可を設定
                        For llngCnt2 = 0 To mlngChipGridMaxCols - 1
                            mblnChipGridMap(llngCnt + 1, llngCnt2 + 1) = False
                        Next llngCnt2
                    End If
                End With
            Next llngCnt


            '@-----------------------
            '@ ﾁｯﾌﾟGridのｶﾗｰ、使用可否定義
            '@-----------------------
            With vsfChipMap

                '@全体の設定
                .Rows.Count = mlngChipGridMaxRows + 1
                .Cols.Count = mlngChipGridMaxCols + 1
                .BackColor = Color.White
                .ForeColor = Color.Black
                .Row = -1
                .Col = -1
                .AllowResizing = False
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_flexAlignRightCenter_2")
                Dim cellRange As CellRange = .GetCellRange(1, 1, mlngChipGridMaxRows, mlngChipGridMaxCols)
                newStyle.TextAlign = TextAlignEnum.RightCenter
                cellRange.Style = newStyle

                '@ﾀｲﾄﾙの高さ、幅の設定
                .Rows(CMlngvsfChipMapNo).Height = CMlngvsfChipMapTitleHeight
                .Cols(CMlngvsfChipMapNo).Width = CMlngvsfChipMapTitleWidth
                .Select(CMlngvsfChipMapNo, CMlngvsfChipMapNo, CMlngvsfChipMapNo, .Cols.Count - 1)
                .Styles.Fixed.Font = New Font(.Font.Name, CMvsfTitleFontSize, .Font.Style)

                '@ﾀｲﾄﾙの色設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.BackColor = Color.Navy              '背景色
                lFixedStyle.ForeColor = Color.Yellow            '文字色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                'NSYS No列の背景色の設定
                Dim newStyleNo As CellStyle
                Dim CellRangeNo As CellRange
                newStyleNo = .Styles.Add("CustomStyle_BackColor_No")
                newStyleNo.BackColor = System.Drawing.SystemColors.ControlLight
                Dim llngContNo As Integer
                For llngContNo = 1 To mlngChipGridMaxRows
                    CellRangeNo = .GetCellRange(llngContNo, CMlngvsfChipMapNo, llngContNo, CMlngvsfChipMapNo)
                    CellRangeNo.Style = newStyleNo
                Next llngContNo

                '@高さ、幅の最小値、最大値の初期設定
                .Rows.MaxSize = 0
                .Rows.MinSize = 0
                .Cols.MaxSize = 0
                .Cols.MinSize = 0

                '@行番号、書式、高さの設定
                mlngAllDisplayRowHeigth = 0
                mlngAllDisplayRowHeigth = (CMlngvsfChipMapNomalHeight - CMlngvsfChipMapTitleHeight) / mlngChipGridMaxRows
                mlngAllDisplayRowHeigth = Fix(mlngAllDisplayRowHeigth / CMlngvsfWtips) * CMlngvsfWtips
                For llngCnt = 1 To mlngChipGridMaxRows
                    .SetData(llngCnt, CMlngvsfChipMapNo, Format$(llngCnt, CPstrSlotNoFormat))
                    .Cols(CMlngvsfChipMapNo).TextAlign = TextAlignEnum.RightCenter
                    .Rows(llngCnt).Height = mlngAllDisplayRowHeigth
                Next llngCnt
                '@列№、書式、幅の設定
                mlngAllDisplayColWidth = 0
                mlngAllDisplayColWidth = Fix((CMlngvsfChipMapNomalWidth - CMlngvsfChipMapTitleWidth) / mlngChipGridMaxCols)
                mlngAllDisplayColWidth = Fix(mlngAllDisplayColWidth / CMlngvsfWtips) * CMlngvsfWtips
                For llngCnt2 = 1 To mlngChipGridMaxCols
                    .SetData(CMlngvsfChipMapNo, llngCnt2, Chr(CPlngKeyAsciiUppA + llngCnt2 - 1))
                    .Cols(CMlngvsfChipMapNo).TextAlign = TextAlignEnum.CenterCenter
                    .Cols(llngCnt2).Width = mlngAllDisplayColWidth
                    .Styles.Fixed.Font = New Font(.Font.Name, CMvsfTitleFontSize, .Font.Style)
                    .Font = New Font(.Font.FontFamily, 9)
                Next llngCnt2

                '@Gridの高さ再調整
                .Height = CMlngvsfChipMapTitleHeight + (mlngAllDisplayRowHeigth * mlngChipGridMaxRows)

                '@幅の再調整
                .Width = CMlngvsfChipMapTitleWidth + (mlngAllDisplayColWidth * mlngChipGridMaxCols)

            End With

            Exit Sub


        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChipGridInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfWFMap_Disp
    '機　能：WF情報設定＆表示処理
    '引　数：ltypWaferInfo  ：ﾛｯﾄWF情報構造体
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 11:45:32 N.Kojima
    '更新日：2006/10/05 (Thu) 19:01:30 N.Kojima
    '備　考：
    '　　　：2006/10/05 (Thu) 19:01:30 N.Kojima     棚卸の機能変更に伴い、処理修正。(案件№01517)
    Private Sub prvVsfWFMap_Disp()

        Dim llngCnt As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try

            '@WFﾏｯﾌﾟ情報構造体の初期設定
            Erase mtypWFInfo
            ReDim mtypWFInfo(CMlngvsfWFMapMaxSlotID)

            '@WFﾏｯﾌﾟ情報ｸﾞﾘｯﾄﾞの1～25ｽﾛｯﾄ分
            For llngCnt = 1 To CMlngvsfWFMapMaxSlotID

                With mtypWFInfo(llngCnt)
                    '@WF_IDの初期化
                    .strWfId = vbNullString

                    '@WFﾏｯﾌﾟ情報の初期化
                    ReDim .typChipList(mlngChipGridMaxRows, mlngChipGridMaxCols)

                    '@WFﾏｯﾌﾟの行(横)数分
                    For llngCnt2 = 1 To mlngChipGridMaxRows
                        '@WFﾏｯﾌﾟの列(縦)数分
                        For llngCnt3 = 1 To mlngChipGridMaxCols
                            '@使用可能区分の設定
                            .typChipList(llngCnt2, llngCnt3).blnEnableKbn = mblnChipGridMap(llngCnt2, llngCnt3)

                            '@ﾁｯﾌﾟIDの設定
                            .typChipList(llngCnt2, llngCnt3).strChipId = vbNullString

                            '@入力前後の設定
                            .typChipList(llngCnt2, llngCnt3).strOldClass = vbNullString
                            .typChipList(llngCnt2, llngCnt3).strOldClassID = vbNullString
                            .typChipList(llngCnt2, llngCnt3).strNewClass = vbNullString
                            .typChipList(llngCnt2, llngCnt3).strNewClassID = vbNullString
                        Next llngCnt3
                    Next llngCnt2

                End With
            Next llngCnt

            '@引継ぎ構造体からWFﾏｯﾌﾟ構造体へ設定
            For llngCnt = 0 To ptypTakeOverDataEN01Y0(mlngCnt).lngWfListCnt - 1
                With ptypTakeOverDataEN01Y0(mlngCnt).typWfList(llngCnt)
                    mtypWFInfo(llngCnt + 1).strWfId = .strWfId
                End With
            Next llngCnt

            '@ｽﾛｯﾄﾏｯﾌﾟ情報ｸﾞﾘｯﾄﾞの設定
            '@ｽﾛｯﾄﾏｯﾌﾟ情報ｸﾞﾘｯﾄﾞの設定
            With vsfWFMap
                '@全体の設定
                .Redraw = False                    '描画ﾛｯｸ
                .Rows.Count = CMlngvsfWFMapMaxSlotID + 1      '行設定
                .BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)          '背景色(濃いｸﾞﾚｰ)
                .ForeColor = Color.Black                    '文字色(黒)
                .Row = -1                               '選択状態設定(ﾀｲﾄﾙ)
                .Col = -1                               '選択状態設定(ﾀｲﾄﾙ)
                .AllowResizing = False

                '@ｽﾛｯﾄ№、WF_ID、傾向、不良の設定
                For llngCnt = 1 To CMlngvsfWFMapMaxSlotID - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If 25 < CMlngvsfWFMapMaxSlotID - llngCnt Then
                        '@背景ｸﾞﾚｰ、WF_IDはNULL
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID)
                        cellRange.Style = newStyle                    'WF_ID
                    Else
                        '@WF_IDの設定
                        .SetData(llngCnt + 1, CMlngvsfWFMapID,
                            mtypWFInfo(CMlngvsfWFMapMaxSlotID - llngCnt).strWfId)

                        '@表示位置設定
                        .Cols(CMlngvsfWFMapID).TextAlign = TextAlignEnum.LeftCenter          'WF_ID(左寄中央揃え)
                        .Cols(CMlngvsfWFMapChkBox).TextAlign = TextAlignEnum.CenterCenter    'ﾁｪｯｸﾎﾞｯｸｽ(右寄中央揃え)

                        '@全選択ﾎﾞﾀﾝを有効にする
                        cmdAllSelect.Enabled = True

                        '@背景色設定
                        If .GetData(llngCnt, CMlngvsfWFMapID) <> vbNullString Then
                            '@WFIDが存在する場合は「白」
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Else
                            '@WFIDが存在しない場合は「濃い灰色」
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If

                    End If
                Next llngCnt

                '@再描画
                .Redraw = True
            End With

            '@制御をOSに渡す
            '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
            '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
            'DoEvents

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfWFMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFInfo_Sel
    '機　能：WF情報取得処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 11:11:51 N.Kojima
    '更新日：2006/08/03 (Thu) 11:11:51
    '備　考：
    Private Sub prvWFInfo_Sel()

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ

        Try

            '@=======================
            '@ ﾁｯﾌﾟ情報(WFﾏｯﾌﾟ)設定処理
            '@=======================
            Call prvChipGridInfo_Set()

            '@=======================
            '@ WF情報　設定＆表示処理
            '@=======================
            Call prvVsfWFMap_Disp()

            '@WFｸﾞﾘｯﾄﾞの初期設定
            mlngWFNowIndex = 0

            For llngCnt = 1 To CMlngvsfWFMapMaxSlotID

                '@WF構造体からの検索
                If mtypWFInfo(llngCnt).strWfId <> vbNullString Then

                    mlngWFNowIndex = llngCnt
                    Exit For
                End If
            Next llngCnt

            '@ｶﾚﾝﾄ行設定
            If mlngWFNowIndex = 0 Then
                mlngWFNowIndex = 1
            End If

            If mlngWFNowIndex > 0 Then
                vsfWFMap.Row = CMlngvsfWFMapMaxSlotID - mlngWFNowIndex + 1
            End If

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWFInfo_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWFMapInfo_Set
    '機　能：WF情報設定処理
    '引　数：ltypWFMapInfo  ：WFﾏｯﾌﾟ構造体
    '戻り値：なし
    '作成日：2006/08/04 (Fri) 16:05:08 N.Kojima
    '更新日：2006/08/04 (Fri) 16:05:08
    '備　考：
    Private Sub prvWFMapInfo_Set(ByRef ltypWFMapInfo As WFMapInfo)

        Dim llngCnt As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ2
        Dim llngCnt3 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ3
        Dim lblnChipSetFlg As Boolean      'ﾁｯﾌﾟ情報設定ﾌﾗｸﾞ(True:設定済、False:未設定)

        Try

            '@ﾁｯﾌﾟ情報が未入力の場合のみ読み込み
            If mtypWFInfo(mlngWFNowIndex).strInputCheckKbn <> vbNullString Or
                mtypWFInfo(mlngWFNowIndex).strWfId = vbNullString Then

                Exit Sub
            End If

            '@WFﾏｯﾌﾟ構造体からﾁｯﾌﾟ構造体へ設定
            With ltypWFMapInfo

                '@LP_FLAG(大判ﾌﾗｸﾞ),CF_FLAGが立っているか=CF(大判)ﾛｯﾄか
                If ptypTakeOverDataEN01Y0(mlngCnt).strCfFlag = CPstrOne And
                    ptypTakeOverDataEN01Y0(mlngCnt).strLpFlag = CPstrOne Then

                    '@CF(大判)ﾛｯﾄの場合
                    For llngCnt = 0 To .lngListCnt - 1

                        '@ﾁｯﾌﾟ情報設定ﾌﾗｸﾞの初期化
                        lblnChipSetFlg = False

                        '@ﾁｯﾌﾟ構造体へ設定
                        For llngCnt2 = 1 To mlngChipGridMaxRows

                            If lblnChipSetFlg = True Then
                                Exit For
                            End If

                            For llngCnt3 = mlngChipGridMaxCols To 1 Step -1

                                '@ﾁｯﾌﾟIDの設定済みﾁｪｯｸ
                                If mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).blnEnableKbn = True And
                                   mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strChipId = vbNullString Then

                                    '@ﾁｯﾌﾟIDのｾｯﾄ
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strChipId = .typChipList(llngCnt).strChipId
                                    '@区分のｾｯﾄ
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClass = .typChipList(llngCnt).strClass
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strNewClass = .typChipList(llngCnt).strClass
                                    '@区分IDのｾｯﾄ
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClassID = .typChipList(llngCnt).strClassID
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strNewClassID = .typChipList(llngCnt).strClassID

                                    '@1WF毎不良の場合は、全Chip不良と置換える
                                    If mtypWFInfo(mlngWFNowIndex).strClass = CPstrClass2 Then
                                        '@ﾁｯﾌﾟ状態が不良以外の場合は置換える
                                        If mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClass <> CPstrClass2 Then
                                            '@区分の再ｾｯﾄ
                                            mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClass = mtypWFInfo(mlngWFNowIndex).strClass
                                            mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strNewClass = mtypWFInfo(mlngWFNowIndex).strClass
                                            '@区分IDの再ｾｯﾄ
                                            mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClassID = mtypWFInfo(mlngWFNowIndex).strClassID
                                            mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strNewClassID = mtypWFInfo(mlngWFNowIndex).strClassID
                                        End If
                                    End If

                                    '@ﾁｯﾌﾟ情報設定ﾌﾗｸﾞの設定済み
                                    lblnChipSetFlg = True
                                    Exit For
                                End If
                            Next

                        Next llngCnt2
                    Next llngCnt
                Else
                    '@CF(大判)ﾛｯﾄではない場合=TFT基板ﾛｯﾄの場合

                    For llngCnt = 0 To .lngListCnt - 1

                        '@ﾁｯﾌﾟ情報設定ﾌﾗｸﾞの初期化
                        lblnChipSetFlg = False

                        '@ﾁｯﾌﾟ構造体へ設定
                        For llngCnt2 = 1 To mlngChipGridMaxRows

                            If lblnChipSetFlg = True Then
                                Exit For
                            End If

                            For llngCnt3 = 1 To mlngChipGridMaxCols

                                '@ﾁｯﾌﾟIDの設定済みﾁｪｯｸ
                                If mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).blnEnableKbn = True And
                                   mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strChipId = vbNullString Then

                                    '@ﾁｯﾌﾟIDのｾｯﾄ
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strChipId = .typChipList(llngCnt).strChipId

                                    '@区分のｾｯﾄ
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClass = .typChipList(llngCnt).strClass
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strNewClass = .typChipList(llngCnt).strClass
                                    '@区分IDのｾｯﾄ
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClassID = .typChipList(llngCnt).strClassID
                                    mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strNewClassID = .typChipList(llngCnt).strClassID

                                    '@1WF毎不良の場合は、全Chip不良と置換える
                                    If mtypWFInfo(mlngWFNowIndex).strClass = CPstrClass2 Then
                                        '@変更後のﾁｯﾌﾟ状態が不良以外の場合は置換える
                                        If mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClass <> CPstrClass2 Then
                                            '@区分の再ｾｯﾄ
                                            mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClass = mtypWFInfo(mlngWFNowIndex).strClass
                                            mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strNewClass = mtypWFInfo(mlngWFNowIndex).strClass
                                            '@区分IDの再ｾｯﾄ
                                            mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strOldClassID = mtypWFInfo(mlngWFNowIndex).strClassID
                                            mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngCnt3).strNewClassID = mtypWFInfo(mlngWFNowIndex).strClassID
                                        End If
                                    End If

                                    '@ﾁｯﾌﾟ情報設定ﾌﾗｸﾞの設定済み
                                    lblnChipSetFlg = True
                                    Exit For
                                End If
                            Next llngCnt3
                        Next llngCnt2
                    Next llngCnt
                End If

            End With

            '@入力ﾁｪｯｸ区分を読み込み済みで未入力に設定する
            mtypWFInfo(mlngWFNowIndex).strInputCheckKbn = CMstrstrInputCheckKbn1

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWFMapInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipMapGrid_Set
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 11:47:19 N.Kojima
    '更新日：2009/05/19 (Tue) 15:23:49 N.Kojima
    '備　考：
    '　　　：2009/05/19 (Tue) 15:23:49 N.Kojima     払出ﾁｯﾌﾟの表示処理を追加。(案件№03434)
    Private Sub prvChipMapGrid_Set()

        Dim llngCnt As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt3 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngChipCol As Integer      'ﾁｯﾌﾟ情報の列位置(表裏用判定)

        Try

            '@WFGridの設定
            With vsfWFMap
                '@ｽﾛｯﾄ№、WF_ID、傾向、不良の設定
                For llngCnt = 1 To CMlngvsfWFMapMaxSlotID
                    '@WFIDがNULLかどうか
                    If .GetData(llngCnt, CMlngvsfWFMapID) <> vbNullString Then
                        '@WFIDが存在する場合は「白」
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID)
                        cellRange.Style = newStyle
                    Else
                        '@NULLの場合は「濃い灰色」
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfWFMapID)
                        cellRange.Style = newStyle
                    End If
                Next llngCnt
            End With

            '@ﾁｯﾌﾟGridの表題変更
            With vsfChipMap
                For llngCnt = 1 To mlngChipGridMaxCols
                    '@"表"表示
                    .SetData(CMlngvsfChipMapNo, llngCnt, Chr(CPlngKeyAsciiUppA + llngCnt - 1))
                Next llngCnt
            End With

            '@ﾁｯﾌﾟGridの設定
            With vsfChipMap

                For llngCnt2 = 1 To mlngChipGridMaxRows

                    For llngCnt3 = 1 To mlngChipGridMaxCols

                        '@ﾁｯﾌﾟ配列の列変換("表"表示)
                        llngChipCol = llngCnt3

                        '@使用区分の判定
                        If mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).blnEnableKbn = True Then

                            '@WF_IDとﾁｯﾌﾟID存在ﾁｪｯｸ
                            If mtypWFInfo(mlngWFNowIndex).strWfId <> vbNullString And
                               mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).strChipId <> vbNullString Then

                                '@ﾁｯﾌﾟIDの文字色を灰色にする
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngChipNoForeColor")
                                newStyle.ForeColor = ColorTranslator.FromWin32(CMlngChipNoForeColor)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt2, llngCnt3)
                                cellRange.Style = newStyle
                                '@ﾁｯﾌﾟIDの表示("表"表示)
                                .SetData(llngCnt2, llngCnt3, Strings.Right$(mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).strChipId, 3))

                                '@区分IDが設定されている場合
                                If mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).strNewClassID <> vbNullString Then

                                    '@↓2009/05/19 (Tue) 15:41:00 N.Kojima **************************************************

                                    '@不良/払出の時のみ、文字色=黒でIDを表示
                                    '                            If mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).strNewClass = CPstrClass2 Then
                                    If mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).strNewClass = CPstrClass2 Or
                                        mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).strNewClass = CPstrClass3 Then

                                        '@↑2009/05/19 (Tue) 15:41:00 N.Kojima **************************************************

                                        '@文字色を黒色に戻す
                                        newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                                        newStyle.ForeColor = Color.Black
                                        cellRange = .GetCellRange(llngCnt2, llngCnt3)
                                        cellRange.Style = newStyle
                                        '@区分IDの表示
                                        .SetData(llngCnt2, llngCnt3, mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).strNewClassID)
                                    End If
                                End If

                                Dim newStyle2 As CellStyle
                                '@★ ﾁｯﾌﾟ区分により処理分岐 ★
                                Select Case mtypWFInfo(mlngWFNowIndex).typChipList(llngCnt2, llngChipCol).strNewClass

                                    '@〓 1：良品 〓
                                    Case CPstrClass1

                                        newStyle2 = .Styles.Add("CustomStyle_BackColor_vbWhite_" & llngCnt2.ToString & "_" & llngCnt3.ToString)
                                        newStyle2.BackColor = Color.White
                                        newStyle2.ForeColor = newStyle.ForeColor
                                        newStyle2.TextAlign = TextAlignEnum.RightCenter
                                        cellRange = .GetCellRange(llngCnt2, llngCnt3)
                                        cellRange.Style = newStyle2            '良品(白)

                                    '@〓 2：不良 〓
                                    Case CPstrClass2

                                        newStyle2 = .Styles.Add("CustomStyle_BackColor_CMlngFuryouColor_" & llngCnt2.ToString & "_" & llngCnt3.ToString)
                                        newStyle2.BackColor = ColorTranslator.FromWin32(CMlngFuryouColor)
                                        newStyle2.ForeColor = newStyle.ForeColor
                                        newStyle2.TextAlign = TextAlignEnum.RightCenter
                                        cellRange = .GetCellRange(llngCnt2, llngCnt3)
                                        cellRange.Style = newStyle2   '不良(ﾋﾟﾝｸ)

        '@↓2009/05/19 (Tue) 13:20:12 N.Kojima **************************************************

                                    '@〓 3：払出 〓
                                    Case CPstrClass3

                                        newStyle2 = .Styles.Add("CustomStyle_BackColor_CMlngHaraidashiColor")
                                        newStyle2.BackColor = ColorTranslator.FromWin32(CMlngHaraidashiColor)
                                        newStyle2.ForeColor = newStyle.ForeColor
                                        newStyle2.TextAlign = TextAlignEnum.RightCenter
                                        cellRange = .GetCellRange(llngCnt2, llngCnt3)
                                        cellRange.Style = newStyle2   '払出(薄いｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ)

                                        '@↑2009/05/19 (Tue) 13:20:12 N.Kojima **************************************************

                                        '@〓 その他 〓
                                    Case Else

                                        newStyle2 = .Styles.Add("CustomStyle_BackColor_vbWhite_" & llngCnt2.ToString & "_" & llngCnt3.ToString)
                                        newStyle2.BackColor = Color.White
                                        newStyle2.ForeColor = newStyle.ForeColor
                                        newStyle2.TextAlign = TextAlignEnum.RightCenter
                                        cellRange = .GetCellRange(llngCnt2, llngCnt3)
                                        cellRange.Style = newStyle2


                                End Select
                            Else
                                '@文字消去
                                .SetData(llngCnt2, llngCnt3, vbNullString)
                                '@WF_ID、ﾁｯﾌﾟIDが存在しない場合は灰色設定
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngEnableFalseColor")
                                'newStyle.BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                                newStyle.BackColor = System.Drawing.SystemColors.ControlLight 'NSYS 背景色をフォームと同様に変更
                                Dim cellRange As CellRange = .GetCellRange(llngCnt2, llngCnt3)
                                cellRange.Style = newStyle
                            End If
                        Else
                            '@文字消去
                            .SetData(llngCnt2, llngCnt3, vbNullString)
                            '@ﾊﾞｯｸｶﾗｰ変更("表"表示)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngChipOmoteBackColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngChipOmoteBackColor)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt2, llngCnt3)
                            cellRange.Style = newStyle
                        End If
                    Next llngCnt3
                Next llngCnt2

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChipMapGrid_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChipMapGridDisplayKbn_Set
    '機　能：ﾁｯﾌﾟｸﾞﾘｯﾄﾞ表示切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/04 (Fri) 17:17:11 N.Kojima
    '更新日：2006/08/04 (Fri) 17:17:11
    '備　考：
    Private Sub prvChipMapGridDisplayKbn_Set()

        Dim llngCnt As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2 As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngRowHeigth As Integer      '1行の高さ
        Dim llngColWidth As Integer      '1列の幅
        Dim llngCurrentRow As Integer      'ｶﾚﾝﾄ行
        Dim llngCurrentCol As Integer      'ｶﾚﾝﾄ列

        Try

            '@ﾁｯﾌﾟGridの設定
            With vsfChipMap

                '@ｶﾚﾝﾄ行列の位置退避
                If .Row > 0 And .Col > 0 Then
                    llngCurrentRow = .Row
                    llngCurrentCol = .Col
                End If

                '@高さの設定
                If mlblnRowHeigthOver = True Then

                    '@最小値を設定
                    llngRowHeigth = CMlngvsfChipMapRowHeightMin
                    '@Grid全体の高さを標準値へ設定
                    .Height = CMlngvsfChipMapNomalHeight

                    '@高さの再設定
                    For llngCnt = 1 To mlngChipGridMaxRows
                        .Rows(llngCnt).Height = llngRowHeigth
                    Next llngCnt
                End If

                '@幅の設定
                If mlblnColWidthOver = True Then
                    '@最小値を設定
                    llngColWidth = CMlngvsfChipMapColWidthMin
                    '@Grid全体の幅を標準値へ設定
                    .Width = CMlngvsfChipMapNomalWidth

                    For llngCnt2 = 1 To mlngChipGridMaxCols
                        .Cols(llngCnt2).Width = llngColWidth
                    Next llngCnt2
                End If

                '@ｽｸﾛｰﾙﾊﾞｰの設定
                '@全体表示
                If mlblnRowHeigthOver = True Or mlblnColWidthOver = True Then
                    .ScrollBars = ScrollBars.Both
                Else
                    .ScrollBars = ScrollBars.None
                End If

                '@ﾁｯﾌﾟGrid位置の再表示
                If llngCurrentRow > 0 And llngCurrentCol > 0 Then
                    '@ｽｸﾛｰﾙ移動
                    .ShowCell(llngCurrentRow, llngCurrentCol)

                    '@ﾁｯﾌﾟGridへﾌｫｰｶｽｾｯﾄする
                    If vsfChipMap.Enabled = True Then
                        Call pubSetFocus(vsfChipMap)
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChipMapGridDisplayKbn_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFormPrint_proc
    '機　能：印刷処理　※WF枚数分
    '引　数：なし
    '戻り値：True：正常、False：異常
    '作成日：2006/08/07 (Mon) 11:42:25 N.Kojima
    '更新日：2006/10/06 (Fri) 10:36:42 N.Kojima
    '備　考：
    '　　　：2006/10/06 (Fri) 10:36:42 N.Kojima     印刷処理の不具合修正。(案件№01517関連)
    Private Sub prvFormPrint_proc()

        Dim llngCnt As Integer              '汎用ｶｳﾝﾀ
        Dim lstrWFID As String               'WFID格納用
        Dim lblnAns As Boolean              '戻り値判定用

        Try

            '@処理ｷｬﾝｾﾙﾌﾗｸﾞをTrueの場合は処理しない
            If mblnCancelFlg = True Then
                Exit Sub
            End If

            '@ESCでの画面終了無効
            Me.CancelButton = Nothing

            '@星取表印刷中止ﾎﾞﾀﾝを有効にする
            cmdPrintCancel.Enabled = True

            With vsfWFMap

                '@WF枚数分ﾙｰﾌﾟさせる(=擬似的にWF情報読み込みを行なう)
                For llngCnt = 1 To .Rows.Count - 1

                    '@WF_IDがNULLではなく、ﾁｪｯｸが付いている場合
                    If .GetData(llngCnt, CMlngvsfWFMapID) <> vbNullString And
                        .GetCellCheck(llngCnt, CMlngvsfWFMapChkBox) = CheckEnum.Checked Then

                        '@行を選択し、ﾁｯﾌﾟ情報を格納する。(※色々処理が走るので追ってみて下さい)
                        .Row = llngCnt

                        '@制御をOSに渡す
                        'DoEvents

                        '@引継ぎ用にWFIDを格納
                        lstrWFID = .GetData(llngCnt, CMlngvsfWFMapID)

                        '@=======================
                        '@ 印刷処理:ActiveWindowのみをｸﾘｯﾌﾟﾎﾞｰﾄﾞにｺﾋﾟｰ
                        '@=======================
                        lblnAns = prvPrint_proc(lstrWFID, True, True)

                        '@印刷処理が正常だった場合
                        If lblnAns = True Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM5UI>$$印刷しました。WFID[%1]"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005U, lblWFNo.Text)
                            Call pubVsfInfo_Disp(pstrDMsg)
                        End If

                        '@処理ｷｬﾝｾﾙﾌﾗｸﾞがTrueか
                        If mblnCancelFlg = True Then
                            Exit For
                        End If
                    End If
                Next llngCnt

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose


            End With

            Exit Sub

        Catch ex As Exception

            Me.CancelButton = cmdClose


            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey          '機能ID
                .strProcName = "prvFormPrint_proc"          '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPrint_proc
    '機　能：印刷処理
    '引　数：lstrWFID   ：ｳｪﾊID
    '　　　：lblnActWind：ｱｸﾃｨﾌﾞｳｨﾝﾄﾞｳを対象とするか(True:対象、False:対象外)
    '　　　：lblnPrintOn：印刷するか(True:する、False:しない)
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 16:10:41 N.Kojima
    '更新日：2006/08/07 (Mon) 16:11:05 N.Kojima
    '備　考：
    Private Function prvPrint_proc(ByVal lstrWFID As String,
                                   ByRef Optional lblnActWind As Boolean = True,
                                   ByRef Optional lblnPrintOn As Boolean = True)

        Dim apppath = System.Reflection.Assembly.GetExecutingAssembly().Location

        Dim pd As System.Drawing.Printing.PrintDocument 'NSYS 印刷ドキュメントを格納
        Dim pPaperSz As System.Drawing.Printing.PaperKind     'NSYS 用紙サイズ設定用
        Dim pkSize As System.Drawing.Printing.PaperSize     'NSYS 用紙サイズ設定用



        '@処理ｷｬﾝｾﾙﾌﾗｸﾞをTrueの場合は処理しない
        If mblnCancelFlg = True Then
            Exit Function
        End If

        '@初期化
        prvPrint_proc = False

        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｸﾘｱ
        'Clipboard.Clear 'NSYS クリップボードコピー方式でないため不要

        'NSYS 画面再描画
        Me.lblWFNo.Refresh()
        Me.lblPartCode.Refresh()
        Me.vsfChipMap.Refresh()

        'NSYS ↓VB6版 (ELSEケースはlblnActWindがTrue固定になっているため削除)
        '@OSﾊﾞｰｼﾞｮﾝ取得
        '@ﾃｽﾄ環境(Meta)では、"SysInfo.SYSINFO"が存在しない為、仕方なく固定打ち。
        '    lsinOsVer = CreateObject("SysInfo.SYSINFO").OSVersion
        'lsinOsVer = 5.2 'NSYS 使用しないため削除
        'If lblnActWind = True Then
        '    '@ActiveWindowのｽﾅｯﾌﾟｼｮｯﾄを取得する
        '    '@以下の2方法どれでもOK(Win98SE/WinXP/Win95）
        '    '@どの方法でも上記確認機種は同じ動作しますのでMSのｻﾝﾌﾟﾙの方法を使用
        '    Call keybd_event(VK_LMENU, &H56, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        '    Call keybd_event(VK_SNAPSHOT, &H79, KEYEVENTF_EXTENDEDKEY Or 0, 0)
        '    Call keybd_event(VK_SNAPSHOT, &H79, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        '    Call keybd_event(VK_LMENU, &H56, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        'Else
        '    '@OSﾊﾞｰｼﾞｮﾝが"5:2000/XP"でｳｨﾝﾄﾞｳがｱｸﾃｨﾌﾞではない場合
        '    If lblnActWind = False And lsinOsVer < 5 Then
        '        '@画面全体のｽﾅｯﾌﾟｼｮｯﾄを取得する(Win98SE/Win95)
        '        Call keybd_event(VK_SNAPSHOT, 1, KEYEVENTF_EXTENDEDKEY, 0)
        '        Call keybd_event(VK_SNAPSHOT, 1, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        '    Else
        '        '@画面全体のｽﾅｯﾌﾟｼｮｯﾄを取得する(WinXP)
        '        Call keybd_event(VK_SNAPSHOT, 0, KEYEVENTF_EXTENDEDKEY, 0)
        '        Call keybd_event(VK_SNAPSHOT, 0, KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, 0)
        '    End If
        'End If
        'NSYS ↑VB6版

        '@必要とあらば復活
        '        '@DoEvents前にﾌﾗｸﾞ・画面無効化の設定を行う
        '        Call pubDoEventsBefoer(frmxxEN01Y1)

        '@制御をOSに渡す
        '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
        '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
        Application.DoEvents()

        '@処理ｷｬﾝｾﾙﾌﾗｸﾞがTrueか
        If mblnCancelFlg = True Then
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞをｸﾘｱし、閉じる
            'Clipboard.Clear 'NSYS クリップボードコピー方式でないため不要
            Exit Function
        End If

        '        '@DoEvents後にﾌﾗｸﾞ・画面有効化の設定を行う
        '        Call pubDoEventsAfter(frmxxEN01Y1)

        'NSYS クリップボードから値を取得しないように変更したため、不要 Start ----------------------
        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞ内にBMP形式のﾃﾞｰﾀがあるか調べる
        'If data.GetDataPresent(DataFormats.Bitmap) = True Then
        'NSYS クリップボードから値を取得しないように変更したため、不要 End   ----------------------

        '@印刷
        If lblnPrintOn Then

            '@表示ﾃﾞｰﾀをBMP形式のﾃﾞｰﾀで保存
            mobjBitmap = CaptureForm() 'NSYS 印刷方式変更（関数追加）

            '@印刷する場合
            pd = New System.Drawing.Printing.PrintDocument

            'AddHandlerされ続けないようにするため、念のため記述
            RemoveHandler pd.PrintPage, AddressOf PrintDocument_PrintPage
            'PrintDocument_PrintPageを印刷処理時にCallする。
            AddHandler pd.PrintPage, AddressOf PrintDocument_PrintPage

            '用紙サイズA4
            pPaperSz = Printing.PaperKind.A4
            For Each pkSize In pd.PrinterSettings.PaperSizes
                If pkSize.Kind = pPaperSz Then
                    pd.DefaultPageSettings.PaperSize = pkSize
                End If
            Next
            '横向き
            pd.DefaultPageSettings.Landscape = True
            '印刷中ダイアログを出さない
            pd.PrintController = New System.Drawing.Printing.StandardPrintController
            'ファイル名(PDF印刷時等のファイル名重複防止用)
            pd.DocumentName = vsfWFMap.GetData(vsfWFMap.Row, CMlngvsfWFMapID) & "_" & Format$(Now, CMstrFormatDate)
            '印刷
            pd.Print()

        End If

        'NSYS クリップボードから値を取得しないように変更したため、不要 Start ----------------------
        '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞをｸﾘｱし、閉じる
        'Clipboard.Clear

        ''@ﾌｧｲﾙを削除する 
        'Kill (lstrMyFileName)
        '
        'Else

        '    '@表示ﾒｯｾｰｼﾞ変換
        '    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000K)
        '    '@"<TRM0KE>$$クリップボードに保存出来ませんでした。システム担当者に連絡してください。"
        '    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

        '    Exit Function
        'End If
        'NSYS クリップボードから値を取得しないように変更したため、不要 End   ----------------------

        '@成功を返却
        prvPrint_proc = True

        Exit Function

Error_Handler:



        '@表示ﾒｯｾｰｼﾞ変換
        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000I, lstrWFID)
        '@"<TRM0IE>$$WF_ID[%1]の印刷に失敗しました。$プリンタ設定等の印刷が可能な状況であることを確認してください。"
        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

        '@ｴﾗｰ情報設定
        With ptypOnErrorInfo
            .strMenuKey = CMstrLocalMenuKey             '機能ID
            .strProcName = "prvPrint_proc"              '処理名
            .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
        End With

        '@=======================
        '@ 共通ｴﾗｰ処理
        '@=======================
        Call pubOnError_Proc()

    End Function

    '関数名：PrintDocumentのPrintPage
    '機　能：印刷ファイル描画処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/11/06 NSYS
    '更新日：2019/11/06 NSYS
    '備　考：prvPrint_procでAddHandlerして呼び出す
    Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim printRectangle As System.Drawing.Rectangle

        Try
            '印刷位置を調整
            printRectangle.X = 75
            printRectangle.Y = 75

            '印刷サイズを調整
            printRectangle.Width = Me.Width + (My.Settings.FormOffset * 2)
            printRectangle.Height = Me.Height + My.Settings.FormOffset

            If mobjBitmap IsNot Nothing Then
                '印刷対象を描画
                e.Graphics.DrawImage(mobjBitmap, printRectangle)

                'ファイルを開放
                mobjBitmap.Dispose()
                mobjBitmap = Nothing
            End If

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey          '機能ID
                .strProcName = "PrintDocument_PrintPage" '処理名
                .strErrMessage = ""                      'ｴﾗｰﾒｯｾｰｼﾞ
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
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const WM_CLOSE As Integer = &H10
        Const WM_ENDSESSION As Integer = &H16
        Const SC_MOVE As Long = &HF010L
        Const SC_CLOSE As Long = &HF060L
        Dim lblnSysCommandScClose As Boolean = False  'NSYS コントロールメニュー SC_CLOSE処理時 True



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

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
    End Sub


    '関数名：CaptureForm
    '機　能：自フォームの画像をBitmapオブジェクトで取得する
    '引　数：なし
    '戻り値：画像のBitmapオブジェクト
    '作成日：2019/11/22 (Fri) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Function CaptureForm() As Bitmap

        ' オフセット値を取得
        Dim offset = My.Settings.FormOffset

        ' Graphicsオブジェクトの生成
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' 取得するフォームサイズ計算
        Dim sz As Size = New Size(Me.Size.Width - (offset * 2), Me.Size.Height - offset)
        ' スクリーンキャプチャするためのBitmapオブジェクトの生成
        Dim memoryImage As Bitmap = New Bitmap(sz.Width, sz.Height, myGraphics)
        ' Graphicsオブジェクトの生成
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        ' CopyFromScreenメソッドでキャプチャ
        memoryGraphics.CopyFromScreen(Me.Location.X + offset, Me.Location.Y, 0, 0, sz)

        Return memoryImage

    End Function

End Class
