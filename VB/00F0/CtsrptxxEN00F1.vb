'ﾌｧｲﾙ名：xxEN00F1.Dsr
'説　明：ﾛｯﾄ検定表 ﾚﾎﾟｰﾄ
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit
Imports System.ComponentModel
Imports System.Security.Permissions
Imports C1.Win.FlexViewer

Public Class rptxxEN00F1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    Private Shared _instance        As rptxxEN00F1    ' ただ一つのフォームのインスタンスを保持する変数

    '関数名：Instance
    '機　能：ただ一つのフォームにアクセスするためのプロパティ
    '備　考：
    Public Shared Property Instance() As rptxxEN00F1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New rptxxEN00F1
            End If
            Return _instance
        End Get
        Set(ByVal value As rptxxEN00F1)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '関数名：IsInstance
    '機　能：単一インスタンスがインスタンス化されているかどうか確認
    '引　数：なし
    '戻り値：True：インスタンス化されている場合
    '備　考：
    Public Shared Function IsInstance() As Boolean
        Return _instance IsNot Nothing
    End Function


    '@送品伝票印刷ﾃﾞｰﾀ
    Private Structure LotExamInfoField
        Dim strLotID                                    As String   'ﾛｯﾄID
        Dim strBoxNo                                    As String   '箱№
        Dim strFlowClass                                As String   '種別
        Dim strWFQuantity                               As String   '送品WF数
        Dim strChipQuantity                             As String   '送品ﾁｯﾌﾟ数
        Dim strPdId                                     As String   '機種
        Dim strSendDate                                 As String   '送品日
        Dim strSendSBName                               As String   '送品先SB名
        Dim strWFThrowinDate                            As String   'WF投入日
        Dim strWFThrowinQuantity                        As String   '投入WF数
        Dim strWFFinishDate                             As String   'WF完成日
        Dim strWFFinishQuantity                         As String   '完成WF数
        Dim strWFOutQuantity                            As String   '不良WF数
        Dim strWFIssueQuantity                          As String   '払出WF数
        Dim strChipIssueQuantity                        As String   '払出ﾁｯﾌﾟ数
        Dim strNo                                       As String   '№
        Dim strWfId                                     As String   'WFID
        Dim strWFChipQuantity                           As String   'ﾁｯﾌﾟ数 
        Dim strChipThrowinQuantity                      As String   '投入ﾁｯﾌﾟ数
        Dim strChipOutQuantity                          As String   '不良ﾁｯﾌﾟ数
        Dim strGoodChipRatio                            As String   '組立歩留率
        Dim strInvComments                              As String   '次SB連絡ｺﾒﾝﾄ
    End Structure
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyRPTEN00F1

    Private Const CMstrLocalFactoryName         As String = "千歳"      '工場名
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    Private mtypLotExamInfoField                As LotExamInfoData.LotExamInfoField             '明細格納
    Private mtypLotExamInfoList                 As List(Of LotExamInfoData.LotExamInfoField)    '明細格納構造体
    Private buttonProcessing                    As Boolean                 'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                 'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                 'NSYS WindowCloseフラグ
    '*******************************************************************************
    '                              * コンストラクタの記述 *
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：New
    '機　能：コンストラクタ
    '引　数：なし
    '戻り値：なし
    '備　考：
    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Form_Load()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub
    '*******************************************************************************
    '　　　　　　　　　　　　　* イベントハンドラの記述 *
    '*******************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '備　考：
    Private Sub Form_Load()

        Dim lintCnt As Integer  '汎用ｶｳﾝﾀ
        Dim lhMenu  As IntPtr   'ﾒﾆｭｰﾊﾝﾄﾞﾙ

        Try

            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@ｼｽﾃﾑﾒﾆｭｰの設定
            lhMenu = GetSystemMenu(Me.Handle, 0)
            For lintCnt = 0 To 6
                '@ｼｽﾃﾑﾒﾆｭｰの上から項目を削除
                Call DeleteMenu(lhMenu, 0, MF_BYPOSITION)
            Next

            'レポートデータ設定
            prvReport_DataInitialize()

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
    '関数名：Form_Shown
    '機　能：ﾌｫｰﾑの表示完了処理
    '引　数：なし
    '戻り値：なし
    '備　考：
    Private Sub Form_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        Try
            'Viewerのリボン最小化
            viwLotExamInfo.ExecuteAction(FlexViewerAction.MinimizeRibbon)

            Exit Sub
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Shown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ ｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '================================== Public =====================================
    '関数名：pubPrintReport
    '機　能：レポートデータ印刷
    '引　数：なし
    '戻り値：なし
    '備　考：
    Public Sub pubPrintReport()
        Try
            If viwLotExamInfo.ActionIsEnabled(FlexViewerAction.Print) Then
                ' 印刷実行（ダイアログ非表示）
                viwLotExamInfo.DocumentSource.Print()
            End If

            Exit Sub

        Catch ex As Exception
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "pubPrintReport"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '関数名：prvReport_DataInitialize
    '機　能：レポートデータ初期化
    '引　数：なし
    '戻り値：なし
    '備　考：
    Private Sub prvReport_DataInitialize()
        Dim llngCnt                                     As Integer              '汎用ｶｳﾝﾀ
        Dim llngCnt2                                    As Integer              '汎用ｶｳﾝﾀ
        Dim llngDataCount                               As Integer              'ﾃﾞｰﾀｶｳﾝﾀ
        Dim record                                      As LotExamInfoData    'NSYS DataSource RecordSet

        Try
            '@ﾚﾎﾟｰﾄ構造体初期化
            mtypLotExamInfoField = New LotExamInfoData.LotExamInfoField()
            mtypLotExamInfoList = New List(Of LotExamInfoData.LotExamInfoField)()
            record = New LotExamInfoData()
            record.Clear()

            '@ﾃﾞｰﾀｶｳﾝﾀ初期化
            llngDataCount = 0
            '@ﾃﾞｰﾀ引継ぎ構造体の件数分処理する
            For llngCnt = 0 To ptypGetLotExamInfo.Count-1              
                With ptypGetLotExamInfo(llngCnt)
                    For llngCnt2 = 0 To 12
                        mtypLotExamInfoField = New LotExamInfoData.LotExamInfoField()
                        mtypLotExamInfoField.strLotID = .strLotID
                        mtypLotExamInfoField.strBoxNo = .strBoxNo
                        mtypLotExamInfoField.strFlowClass = .strFlowClass
                        mtypLotExamInfoField.intWFQuantity = .strWFQuantity
                        mtypLotExamInfoField.intChipQuantity = .strChipQuantity
                        mtypLotExamInfoField.strPdId = .strPdId
                        mtypLotExamInfoField.strSendDate = .strSendDate
                        mtypLotExamInfoField.strSendSBName = .strSendSBName
                        mtypLotExamInfoField.strWFThrowinDate = .strWFThrowinDate
                        mtypLotExamInfoField.intWFThrowinQuantity = .strWFThrowinQuantity
                        mtypLotExamInfoField.strWFFinishDate = .strWFFinishDate
                        mtypLotExamInfoField.intWFFinishQuantity = .strWFFinishQuantity
                        mtypLotExamInfoField.intWFOutQuantity = .strWFOutQuantity
                        mtypLotExamInfoField.intWFIssueQuantity = .strWFIssueQuantity
                        mtypLotExamInfoField.intChipIssueQuantity = .strChipOutQuantity
                        
                        If llngCnt2 <= ptypGetLotExamInfo(llngCnt).lngWFListCount-1 Then
                            mtypLotExamInfoField.strNo = llngCnt2+1
                            mtypLotExamInfoField.strWfId = .typWfList(llngCnt2).strWfId
                            mtypLotExamInfoField.strWFChipQuantity = .typWfList(llngCnt2).strChipQuantity
                        Else
                            mtypLotExamInfoField.strNo = ""
                            mtypLotExamInfoField.strWfId = ""
                            mtypLotExamInfoField.strWFChipQuantity = ""
                        End If

                        mtypLotExamInfoField.intChipThrowinQuantity = .strChipThrowinQuantity
                        mtypLotExamInfoField.intChipOutQuantity = .strChipOutQuantity
                        mtypLotExamInfoField.dblGoodChipRatio = Double.Parse(.strGoodChipRatio)/100
                        mtypLotExamInfoField.strInvComments = .strInvComments

                        mtypLotExamInfoList.Add(mtypLotExamInfoField)
                    Next llngCnt2
                End With
                
            Next llngCnt
            
            'ﾚﾎﾟｰﾄ表示ﾃﾞｰﾀをRecordSetに設定
            For Each elm As LotExamInfoData.LotExamInfoField In mtypLotExamInfoList
                record.Add(elm)
            Next
            'ﾚﾎﾟｰﾄにRecordSetを設定
            rptLotExamInfo.DataSource.Recordset = record

            'ViewerにReportを設定
            viwLotExamInfo.DocumentSource = rptLotExamInfo

        Catch ex As Exception
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvReport_DataInitialize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：Application_Idle
    '機　能：アイドル時に呼び出される
    '引　数：sender：未使用
    '　　　：e  ：未使用
    '戻り値：なし
    '備　考：
    Private Sub Application_Idle(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.buttonProcessing = False
    End Sub

    '関数名：WndProc
    '機　能：Windowsメッセージを処理する
    '引　数：m：Windowsメッセージ
    '戻り値：なし
    '更新日：
    '備　考：
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND         As Integer  = &H0112
        Const WM_CLOSE              As Integer  = &H0010
        Const WM_ENDSESSION         As Integer  = &H0016
        Const SC_MOVE               As Long     = &HF010L
        Const SC_CLOSE              As Long     = &HF060L
        Dim lblnSysCommandScClose   As Boolean = False  'NSYS コントロールメニュー SC_CLOSE処理時 True

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
    End Sub
End Class
