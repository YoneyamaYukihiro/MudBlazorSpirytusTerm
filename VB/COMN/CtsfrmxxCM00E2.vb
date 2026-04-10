'ﾌｧｲﾙ名：xxCM00E2.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Aｷｬﾘｱ(ﾓﾆﾀ/品確/ﾀﾞﾐｰ)選択画面
'作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00E2
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00E2    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00E2
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00E2
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00E2)
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
    '====================================Private============================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00E2  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarracargroupinfo_Ver        As String = "01.00"         'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
    Private Const CMstrcarracarlist_Ver             As String = "01.00"         'Aｷｬﾘｱﾘｽﾄ
    Private Const CMstrcarracarlotset_Ver           As String = "01.00"         'Aｷｬﾘｱﾛｯﾄ設定
    Private Const CMstrcarracarlotcancel_Ver        As String = "01.00"         'Aｷｬﾘｱﾛｯﾄ設定解除

    '@vsfTateroImage定数宣言(ｶﾗﾑ)
    Private Const CMlngImageColNo                   As Integer = 0                 '縦炉ｿﾞｰﾝNo
    Private Const CMlngImageColLotId                As Integer = 1                 'ﾛｯﾄID
    Private Const CMlngImageColFlowClass            As Integer = 2                 '区分
    Private Const CMlngImageColACarrierId           As Integer = 3                 'AｷｬﾘｱID
    Private Const CMlngImageColATrayNum             As Integer = 4                 'Aﾄﾚｲ数
    Private Const CMlngImageColACarrierClass        As Integer = 5                 'Aｷｬﾘｱ区分
    Private Const CMlngImageColACarrierGroup        As Integer = 6                 'Aｷｬﾘｱｸﾞﾙｰﾌﾟ

    '@vsfTateroImage定数宣言(表示幅)
    Private Const CMlngImageColWNo                  As Integer = 100 '1500         '縦炉ｿﾞｰﾝNo
    Private Const CMlngImageColWLotId               As Integer = 233 '3500         'ﾛｯﾄID
    Private Const CMlngImageColWFlowClass           As Integer = 67  '1000         '区分
    Private Const CMlngImageColWACarrierId          As Integer = 200 '3000         'AｷｬﾘｱID
    Private Const CMlngImageColWATrayNum            As Integer = 200 '3000         'Aﾄﾚｲ数
    Private Const CMlngImageColWACarrierClass       As Integer = 200 '3000         'Aｷｬﾘｱ区分
    Private Const CMlngImageColWACarrierGroup       As Integer = 200 '3000         'Aｷｬﾘｱｸﾞﾙｰﾌﾟ

    '@vsfTateroImage定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrImageColTNo                  As String = "縦炉ゾーン"
    Private Const CMstrImageColTLotId               As String = "ロットID"
    Private Const CMstrImageColTFlowClass           As String = "区分"
    Private Const CMstrImageColTACarrierId          As String = "AキャリアID"
    Private Const CMstrImageColTATrayNum            As String = "Aトレイ数"
    Private Const CMstrImageColTACarrierClass       As String = "Aキャリア区分"
    Private Const CMstrImageColTACarrierGroup       As String = "AキャリアGr"

    '@vsfLot定数宣言(その他)
    Private Const CMvsfImageCols                    As Integer = 7                 'ｶﾗﾑ数
    Private Const CMvsfImageRows                    As Integer = 6                 '行数
    Private Const CMvsfImageHHeight                 As Integer = 37 '550           'ﾍｯﾀﾞｰの高さ
    Private Const CMvsfImageHeight                  As Integer = 37 '550           '1ｽﾛｯﾄの高さ
    Private Const CMvsfImageTitleRow                As Integer = 0                 'ﾀｲﾄﾙ行
    Private Const CMvsfImageTitleCol                As Integer = 0                 'ﾀｲﾄﾙ列
    Private Const CMvsfImageTFontSize               As Integer = 16                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfImbageFontSize               As Integer = 16                'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ

    '@その他
    Private Const CMlngATrayCont_Monitor_On         As Integer = 12                'ﾓﾆﾀｰ有時のAtray数
    Private Const CMlngATrayCont_Monitor_Off        As Integer = 13                'ﾓﾆﾀｰ無時のAtray数
    Private Const CMlngATrayCont_Monitor            As Integer = 3                 'ﾓﾆﾀｰのAtray数
    Private Const CMstrNoAnser                      As String = "-"
    '@↓2020/07/06 (Mon) 16:26:09 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrProduct                      As String = "PRODUCT"
    Private Const CMstrQuality                      As String = "QUALITY"
    '@↑2020/07/06 (Mon) 16:26:09 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ｴﾗｰ表示定数
    Private Const CMstrErr01                        As String = "重複"
    Private Const CMstrErr02                        As String = "使用不可"
    Private Const CMstrErr03                        As String = "Aトレイ数不正"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    Private mblnFormLoadFlag                        As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mstrEventName                           As String                   'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
    Private mtypACarrierGroupInfo                   As ACarrierGroupInfo
    Private mtypACarierListDummyMoniOn              As List(Of ACarrierList)
    Private mtypACarierListDummyMoniOff             As List(Of ACarrierList)
    Private mtypACarierListMoQu                     As List(Of ACarrierList)
    Private mblnAllSelect                           As Boolean

    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                  'NSYS WindowCloseフラグ
    Private Const flexRDNone                        As Boolean = False          'Redraw制御用
    Private Const flexRDDirect                      As Boolean = True           'Redraw制御用

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
    '機　能：ﾌｫｰﾑ初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean
            
        Try
            
            '@ｲﾍﾞﾝﾄ名格納
            mstrEventName = "Form_Load"
            

            
            '@画面の初期化
            Call prvfrmxxCM00E2_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@引継ALDﾊﾞｯﾁID
            If ptypACarrierGroup.strAldBatchId = vbNullString Then
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@=======================
            '@Aｷｬﾘｱｸﾞﾙｰﾌﾟ取得(ALDﾊﾞｯﾁ指定)
            '@=======================
            lblnAns = pubblnACarrierGroupInfo_Sel(CMstrcarracargroupinfo_Ver, _
                                                vbNullString, _
                                                vbNullString, _
                                                ptypACarrierGroup.strAldBatchId, _
                                                mtypACarrierGroupInfo)
            '@結果確認
            If lblnAns = True Then

                '@ﾃｰﾌﾟｸﾞﾙｰﾌﾟが無い場合は終了
                If mtypACarrierGroupInfo.lngTapeGroupListCnt < 1 Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007Q)
                    '@"<TRM7PQ>$$防湿ALDバッチ編成情報からキャリアクループが取得できませんでした。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, mstrEventName)
                    
                    '@ｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                    
                    Exit Sub
                End If
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@=======================
            '@Aｷｬﾘｱﾘｽﾄ取得(Dummy&Mo無)
            '@=======================
            '@2018/12/04仕様未確定(暫定で製品用ATRAYｷｬﾘｱを使用する)
            'lblnAns = pubblnACarrierList_Sel(CMstrcarracarlist_Ver, _
            '                                 CPstrACarDummyMoniOff, _
            '                                 vbNullString, _
            '                                 vbNullString, _
            '                                 mtypACarierListDummyMoniOff)
            
            
            lblnAns = pubblnACarrierList_Sel(CMstrcarracarlist_Ver, _
                                             CPstrACarProductMoniOff, _
                                             vbNullString, _
                                             vbNullString, _
                                             mtypACarierListDummyMoniOff)
            
            '@結果確認
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@=======================
            '@Aｷｬﾘｱﾘｽﾄ取得(Dummy&Mo有)
            '@=======================
            '@2018/12/04仕様未確定(暫定で製品用ATRAYｷｬﾘｱを使用する)
            'lblnAns = pubblnACarrierList_Sel(CMstrcarracarlist_Ver, _
            '                                 CPstrACarDummyMoniOn, _
            '                                 vbNullString, _
            '                                 vbNullString, _
            '                                 mtypACarierListDummyMoniOn)
                                             
            lblnAns = pubblnACarrierList_Sel(CMstrcarracarlist_Ver, _
                                             CPstrACarProductMoniOn, _
                                             vbNullString, _
                                             vbNullString, _
                                             mtypACarierListDummyMoniOn)
                                             
            '@結果確認
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@=======================
            '@Aｷｬﾘｱﾘｽﾄ取得(Qu&Mo)
            '@=======================
            lblnAns = pubblnACarrierList_Sel(CMstrcarracarlist_Ver, _
                                             CPstrACarQuality, _
                                             vbNullString, _
                                             vbNullString, _
                                             mtypACarierListMoQu)
            '@結果確認
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)
            
            '@=======================
            '@表示
            '@=======================
            Call prvTateroImage_Disp()
                
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
            '@以下の条件の場合、ｷｰｺｰﾄﾞを初期化し処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
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
                            Call txtACarrierId_Validate(txtACarrierId,New CancelEventArgs(False))
                            AddHandler txtACarrierId.Validating, AddressOf txtACarrierId_Validate
                            e.Handled = True
                            
                        '@〓〓 その他 〓〓
                        Case Else
                        
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    
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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑのｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try
                   
            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvEnable_Chk()
              
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@引継ｷｬﾘｱﾀｲﾌﾟの初期化
            pstrCarrierTypeID = vbNullString

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
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
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
           
            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞ
            Me.Close()
            
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

    '関数名：cmdRegist_Click
    '機　能：選択確定ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim llngRowCnt          As Integer
        Dim llngCnt             As Integer
        Dim lstrEventName       As String
        Dim lblnAns             As Boolean

        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfTateroImage
            
                '@領域を確保
                ptypACarrierGroup.lngGroupListCnt = lblACarrierCnt.Text
                If IsNothing(ptypACarrierGroup.typACarrierGroupList) Then
                    ptypACarrierGroup.typACarrierGroupList = New List(Of ACarrierGroupList)
                Else
                    ptypACarrierGroup.typACarrierGroupList.Clear
                End If 
                
                Dim typACarrierGroupListTmp As ACarrierGroupList = New ACarrierGroupList

                llngCnt = 0
                For llngRowCnt = 1 To .Rows.Count - 1
                
                    '@背景色(白)
                    If .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                        llngCnt = llngCnt + 1
                        typACarrierGroupListTmp.strACarrierGroup = .GetData(llngRowCnt, CMlngImageColACarrierGroup)
                        typACarrierGroupListTmp.strACarrierId = .GetData(llngRowCnt, CMlngImageColACarrierId)
                        typACarrierGroupListTmp.strATrayNum = .GetData(llngRowCnt, CMlngImageColATrayNum)
                        typACarrierGroupListTmp.strACarrierClass = .GetData(llngRowCnt, CMlngImageColACarrierClass)
                        
                        '@ﾛｯﾄID未確定の場合
                        If .GetData(llngRowCnt, CMlngImageColLotId) = CMstrNoAnser Then
                            typACarrierGroupListTmp.strLotID = vbNullString
                        Else
                            typACarrierGroupListTmp.strLotID = .GetData(llngRowCnt, CMlngImageColLotId)
                        End If

                        ptypACarrierGroup.typACarrierGroupList.Add(typACarrierGroupListTmp)

                    End If
                Next
            End With
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdRegist_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Text, lstrEventName)
                
            '@新規登録実行
            lblnAns = pubblnACarrierLotSet_Upd(CMstrcarracarlotset_Ver, ptypACarrierGroup)
            
            '@結果判定
            If lblnAns = False Then
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Text, lstrEventName)
                
                '@ﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Text, lstrEventName)
                
            '@ﾌｫｰﾑを閉じる
            Me.Close()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRegist_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegistClear_Click
    '機　能：確定取消ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub cmdRegistClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegistClear.Click
        
        Dim llngRowCnt          As Integer
        Dim llngCnt             As Integer
        Dim lstrEventName       As String
        Dim lblnAns             As Boolean

        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfTateroImage
            
                '@領域を確保
                ptypACarrierGroup.lngGroupListCnt = lblACarrierCnt.Text
                If IsNothing(ptypACarrierGroup.typACarrierGroupList) Then
                    ptypACarrierGroup.typACarrierGroupList = New List(Of ACarrierGroupList)
                Else
                    ptypACarrierGroup.typACarrierGroupList.Clear
                End If 
                
                Dim typACarrierGroupListTmp As ACarrierGroupList = New ACarrierGroupList

                llngCnt = 0
                For llngRowCnt = 1 To .Rows.Count - 1
                
                    '@背景色(白)
                    If .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                        llngCnt = llngCnt + 1
                        typACarrierGroupListTmp.strACarrierGroup = .GetData(llngRowCnt, CMlngImageColACarrierGroup)
                        typACarrierGroupListTmp.strACarrierId = .GetData(llngRowCnt, CMlngImageColACarrierId)
                        typACarrierGroupListTmp.strATrayNum = .GetData(llngRowCnt, CMlngImageColATrayNum)
                        typACarrierGroupListTmp.strACarrierClass = .GetData(llngRowCnt, CMlngImageColACarrierClass)
                        
                        '@ﾛｯﾄID未確定の場合
                        If .GetData(llngRowCnt, CMlngImageColLotId) = CMstrNoAnser Then
                            typACarrierGroupListTmp.strLotID = vbNullString
                        Else
                            typACarrierGroupListTmp.strLotID = .GetData(llngRowCnt, CMlngImageColLotId)
                        End If
                        ptypACarrierGroup.typACarrierGroupList.Add(typACarrierGroupListTmp)
                    End If
                Next
            End With
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "cmdClear_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Text, lstrEventName)
                
            '@ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnACarrierLotCancel_Upd(CMstrcarracarlotcancel_Ver, ptypACarrierGroup)
            
            '@結果判定
            If lblnAns = False Then
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Text, lstrEventName)
                
                '@ﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Text, lstrEventName)
            
            '@ﾌｫｰﾑを閉じる
            Me.Close()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRegistClear_Click"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtACarrierId_Change
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub txtACarrierId_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtACarrierId.Change

        Try

            '@起動時には処理を行わない
            If mblnFormLoadFlag = True Then
                
                '@ｸﾞﾘｯﾄﾞの初期化
                Call prvvsfTateroImageList_Init()
                
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtACarrierId_Change"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    'NSYS .NET版に当イベントハンドラがなく、実行しなくても処理に影響しないためコメントアウト
    ''関数名：txtACarrierId_CloseUp
    ''機　能：ｷｬﾘｱ一覧表示処理
    ''引　数：なし
    ''戻り値：なし
    ''作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    ''更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    ''備　考：
    'Private Sub txtACarrierId_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtACarrierId.CloseUp

    '    Try

    '        '@Validate処理へ
    '        Call txtACarrierId_Validate(txtACarrierId, New CancelEventArgs(True))
            
    '        Exit Sub
            
    '    Catch ex As Exception
            
    '        '@ｴﾗｰ情報設定
    '        With ptypOnErrorInfo
    '            .strMenuKey = CMstrLocalMenuKey             '機能ID
    '            .strProcName = "txtACarrierId_CloseUp"         '処理名
    '            .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
    '        End With

    '        '@共通ｴﾗｰ処理
    '        Call pubOnError_Proc()
            
    '    End Try
    'End Sub

    '関数名：txtACarrierId_Validate
    '機　能：ｷｬﾘｱ一覧表示処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub txtACarrierId_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtACarrierId.Validating

        Dim llngRowCnt  As Integer
        Dim lblnInsert  As Boolean
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ACarrierIDがない場合は抜ける
            If txtACarrierId.Text = vbNullString Then
                Exit Sub
            End If
            
            '@ACarrierIDの桁ﾁｪｯｸ
            If txtACarrierId.NowByte <> txtACarrierId.ChrMaxByte Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@ｷｬﾘｱIDにﾌｫｰｶｽ移動
                Call pubSetFocus(txtACarrierId)
                
                Exit Sub
            End If
            
            With vsfTateroImage
            
                '@無効の場合
                If .Enabled = False Then
                    Exit Sub
                End If
                
                '@入力判定初期
                lblnInsert = False
                
                '@上より入力
                For llngRowCnt = 1 To .Rows.Count - 1
                        
                    '@背景色(白)&ACarrierがNULL
                    If .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) And _
                        .GetData(llngRowCnt, CMlngImageColACarrierId) = vbNullString Then
                    
                        '@ATrayId入力
                        .SetData(llngRowCnt, CMlngImageColACarrierId, Trim(txtACarrierId.Text))
                        
                        '@編集確定
                        Call vsfTateroImage_AfterEdit(vsfTateroImage, New RowColEventArgs(llngRowCnt, CMlngImageColACarrierId))
                        
                        lblnInsert = True
                        Exit For
                    End If
                Next
            End With
            
            '@入力出来なかった場合
            If lblnInsert = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003N, txtACarrierId.Text)
                '@"<TRM3NW>$$キャリアID「%1」は入力できませんでした。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

            End If
                
            txtACarrierId.Text = vbNullString

            '@ﾌｫｰｶｽ移動
            If ActiveControl.Name = txtACarrierId.Name Then
                Call pubSetFocus(txtACarrierId)
            End If
            
            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvEnable_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtACarrierId_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfTateroImage_AfterEdit
    '機　能：入力制御
    '引　数：行 Row 列 Col
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub vsfTateroImage_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfTateroImage.AfterEdit
        
        Dim llngCnt     As Integer
        Dim llngRowCnt  As Integer
        Dim lblnFind    As Boolean
        Dim ltypACarierList            As List(Of ACarrierList)
        
        Try

            'NSYS 画面を閉じる(ActiveControlがない)場合は処理を抜ける
            If ActiveControl.Name = "" Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfTateroImage.Rows.Count <= vsfTateroImage.Rows.Fixed Then
                Return
            End If
            
            With vsfTateroImage
                
                '@空の場合
                If .GetData(e.Row, CMlngImageColACarrierId) = vbNullString Then
                    '@ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtACarrierId)
                    Exit Sub
                End If
            
                '@ACarrierId重複ﾁｪｯｸ
                For llngRowCnt = 1 To .Rows.Count - 1
                    If llngRowCnt <> e.Row Then
                        If .GetData(llngRowCnt, CMlngImageColACarrierId) = .GetData(e.Row, CMlngImageColACarrierId) Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003B, .GetData(e.Row, CMlngImageColACarrierId), CMstrErr01)
                            '@"<TRM3BW>$$<TRM3BW>$$AキャリアID[%1] 理由[%2]$$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                            '@入力値ｸﾘｱ
                            .SetData(e.Row, CMlngImageColACarrierId, vbNullString)
                            
                            '@ﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtACarrierId)
                            
                            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
                            Call prvEnable_Chk()
                            
                            Exit Sub
                        End If
                    End If
                Next
                
                '@各ACarrier情報を振り分け
                Select Case .GetData(e.Row, CMlngImageColACarrierClass)
                    
                    Case CPstrACarDummyMoniOff
                        ltypACarierList = mtypACarierListDummyMoniOff
                    
                    Case CPstrACarDummyMoniOn
                        ltypACarierList = mtypACarierListDummyMoniOn
                    
                    Case CPstrACarQuality
                        ltypACarierList = mtypACarierListMoQu
                    
                End Select
            
                '@ATray情報から該当IDを検索
                lblnFind = False
                For llngCnt = 0 To ltypACarierList.Count -1
                    '@入力ACarrierと比較
                    If ltypACarierList(llngCnt).strACarrierId = .GetData(e.Row, CMlngImageColACarrierId) Then
                    
                        '@ATray数比較
                        If ltypACarierList(llngCnt).strATrayNum = .GetData(e.Row, CMlngImageColATrayNum) Then
                            lblnFind = True
                            Exit For
                            
                        Else
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003B, .GetData(e.Row, CMlngImageColACarrierId), CMstrErr03)
                            '@"<TRM3BW>$$<TRM3BW>$$AキャリアID[%1] 理由[%2]$$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@入力値ｸﾘｱ
                            .SetData(e.Row, CMlngImageColACarrierId, vbNullString)
                            
                            '@ﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtACarrierId)
                            
                            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
                            Call prvEnable_Chk()
                            
                            Exit Sub
                            
                        End If
                    End If
                Next
                
                '@ACarrier登録情報が無い場合
                If lblnFind = False Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003B, .GetData(e.Row, CMlngImageColACarrierId), CMstrErr02)
                    '@"<TRM3BW>$$<TRM3BW>$$AキャリアID[%1] 理由[%2]$$設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@入力値ｸﾘｱ
                    .SetData(e.Row, CMlngImageColACarrierId, vbNullString)
                            
                    '@ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtACarrierId)
                    
                    '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
                    Call prvEnable_Chk()
                    
                    Exit Sub
                End If
                        
            End With
            
            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvEnable_Chk()
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTateroImage_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTateroImage_MouseDown
    '機　能：入力制御
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub vsfTateroImage_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles vsfTateroImage.MouseDown
        
        Try
            
            Call vsfTateroImage_Click(vsfTateroImage, New EventArgs)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTateroImage_MouseDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTateroImage_KeyPress
    '機　能：入力制御
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub vsfTateroImage_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles vsfTateroImage.KeyPress

        Try
            
            Call vsfTateroImage_Click(vsfTateroImage, New EventArgs)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTateroImage_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTateroImage_Click
    '機　能：ｽﾛｯﾄ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub vsfTateroImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTateroImage.Click

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfTateroImage.Rows.Count <= vsfTateroImage.Rows.Fixed Then
                Return
            End If               
             
            With vsfTateroImage

                '@ﾍｯﾀﾞの場合
                If .Row < .Rows.Fixed Or .Col < .Cols.Fixed Then
                    Exit Sub
                End If
            
                '@選択行の色指定
                .BackColor = .GetCellRange(.Row, CMlngImageColACarrierId).StyleDisplay.BackColor
                .ForeColor = .ForeColor

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTateroImage_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTateroImage_EnterCell
    '機　能：入力制御
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub vsfTateroImage_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTateroImage.EnterCell

        Try

            With vsfTateroImage
            
                '@編集不可
                .AllowEditing = False
                
                '@選択済みの場合
                If mblnAllSelect = True Then
                    Exit Sub
                End If
                
                '@ﾍｯﾀﾞの場合
                If .Row <= CMvsfImageTitleRow Then
                    Exit Sub
                End If
                        
                Select Case .Col

                    '@ACARRIER_ID
                    Case CMlngImageColACarrierId
                        
                        '@背景色(白)
                        If .GetCellRange(.Row, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                                    
                            '@ｸﾞﾘｯﾄﾞｺﾝﾎﾞ作成
                            .Cols(CMlngImageColACarrierId).ComboList = prvstrACarrierCombData_Sel(.GetData(.Row, CMlngImageColACarrierClass))
                        
                            '@編集可能
                            .AllowEditing = True

                        End If
                        
                End Select
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTateroImage_EnterCell"
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
            
        Dim llngRowCnt As Integer
            
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfTateroImage
                For llngRowCnt = CMvsfImageTitleRow + 1 To .Rows.Count - 1
                    '@編集可能色の場合
                    If .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                        .SetData(llngRowCnt, CMlngImageColACarrierId, vbNullString)
                    End If
                Next
            End With
            
            '@ﾌｫｰｶｽ移動
            Call pubSetFocus(txtACarrierId)
            
            '@ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call prvEnable_Chk()
            
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


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxCM00E2_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub prvfrmxxCM00E2_Init()
        
        Try
            
            '@ﾃｷｽﾄ
            txtACarrierId.CausesValidation = True
            txtACarrierId.Text = vbNullString
            
            '@各ﾗﾍﾞﾙの初期化
            lblACarrierCnt.Text = vbNullString
                
            '@=======================
            '@ ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfTateroImageList_Init()
            
            '@=======================
            '@ 有効/無効ﾁｪｯｸ
            '@=======================
            Call prvEnable_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00E2_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfTateroImageList_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub prvvsfTateroImageList_Init()
        
        Dim llngCnt As Integer
        
        Try
            
            With vsfTateroImage
            
                '@ﾛｯｸ
                .Enabled = False
                
                '@ｸﾘｱ
                .Clear
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@列数設定
                .Cols.Count = CMvsfImageCols
                '@行数設定
                .Rows.Count = CMvsfImageRows

                '@一覧表の表題設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngBlueColor")
                newStyle.TextAlign = TextAlignEnum.CenterCenter          '中央表示
                newStyle.BackColor = Color.Navy                          '背景色
                newStyle.ForeColor = Color.Yellow                        '文字色
                'ﾌｫﾝﾄｻｲｽﾞ
                With .Font                                              
                    newStyle.Font = New Font(.FontFamily, CMvsfImageTFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                '@見出し行の文字位置設定
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                newStyle.Trimming = StringTrimming.None              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                .Rows(CMvsfImageTitleRow).Height = CMvsfImageHHeight      '高さ

                'NSYS ハイライト、フォーカス時の背景色が設定されないようにする
                .Styles.Focus.Clear
                .Styles.Highlight.Clear

                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed - 1, .Cols.Fixed -1, .Rows.Fixed - 1, .Cols.Count - 1)
                cellRange.Style = newStyle

                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMvsfImageTitleRow, CMlngImageColNo, CMstrImageColTNo)
                .SetData(CMvsfImageTitleRow, CMlngImageColLotId, CMstrImageColTLotId)
                .SetData(CMvsfImageTitleRow, CMlngImageColFlowClass, CMstrImageColTFlowClass)
                .SetData(CMvsfImageTitleRow, CMlngImageColACarrierId, CMstrImageColTACarrierId)
                .SetData(CMvsfImageTitleRow, CMlngImageColATrayNum, CMstrImageColTATrayNum)
                .SetData(CMvsfImageTitleRow, CMlngImageColACarrierClass, CMstrImageColTACarrierClass)
                .SetData(CMvsfImageTitleRow, CMlngImageColACarrierGroup, CMstrImageColTACarrierGroup)
                
                .Cols(CMlngImageColNo).Width = CMlngImageColWNo
                .Cols(CMlngImageColLotId).Width = CMlngImageColWLotId
                .Cols(CMlngImageColFlowClass).Width = CMlngImageColWFlowClass
                .Cols(CMlngImageColACarrierId).Width = CMlngImageColWACarrierId
                .Cols(CMlngImageColATrayNum).Width = CMlngImageColWATrayNum
                .Cols(CMlngImageColACarrierClass).Width = CMlngImageColWACarrierClass
                .Cols(CMlngImageColACarrierGroup).Width = CMlngImageColWACarrierGroup
                
                '@列位置の設定
                .Cols(CMlngImageColNo).TextAlign = TextAlignEnum.CenterCenter
                .Cols(CMlngImageColLotId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngImageColFlowClass).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngImageColACarrierId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngImageColATrayNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngImageColACarrierClass).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngImageColACarrierGroup).TextAlign = TextAlignEnum.RightCenter
                
                '@非表示
                .Cols(CMlngImageColACarrierClass).Visible = False
                .Cols(CMlngImageColACarrierGroup).Visible = False
                
                '@1行から最後まで
                For llngCnt = CMvsfImageTitleCol + 1 To .Rows.Count - 1
                    '.CellFontSize = CMvsfTateroImageFontSize           'ﾌｫﾝﾄｻｲｽﾞ
                    .Rows(llngCnt).Height = CMvsfImageHeight       '高さ
                    
                    '@A_CARRIER_GROUP
                    .SetData(llngCnt, CMlngImageColACarrierGroup, Format$(llngCnt, CPstrSlotNoFormat))
                        
                    '@最終行はﾓﾆﾀｰ用
                    If llngCnt = .Rows.Count - 1 Then
                        .SetData(llngCnt, CMlngImageColNo, CPstrSpecUseMonitorName)
                    Else
                        '@ｽﾛｯﾄ№設定
                        .SetData(llngCnt, CMlngImageColNo, Format$(llngCnt, CPstrSlotNoFormat))
                    End If
                Next llngCnt
                
                '@自動列幅設定=自動調整する
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngImageColNo, .Cols.Count - 1, 6)
                
                'NSYS ヘッダを選択状態にする
                .Row = 0
                .Col = 0

                '@ﾛｯｸ解除
                .Enabled = True
                
            End With
                    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfTateroImageList_Init"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvTateroImage_Disp
    '機　能：ｷｬﾘｱﾘｽﾄ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/11/26 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub prvTateroImage_Disp()
        
        Dim llngCnt             As Integer
        Dim llngRowCnt          As Integer
        Dim llngCarrierCnt      As Integer
        Dim lblnLotDisp         As Boolean
        Dim lblnWhiteBack       As Boolean
        
        Try
                
            '@変数初期化
            llngCarrierCnt = 0
                
            With vsfTateroImage
            
                '@描画ﾛｯｸ
                .Redraw = flexRDNone
                
                '@背景色(灰)
                Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle1.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange1 As CellRange = .GetCellRange(CMvsfImageTitleCol + 1, CMlngImageColLotId, .Rows.Count - 1, .Cols.Count - 1)
                cellRange1.Style = newStyle1

                '@ALDﾊﾞｯﾁを検索
                For llngCnt = 0 To mtypACarrierGroupInfo.lngTapeGroupListCnt -1
                    
                    '@初期化
                    lblnLotDisp = False
                    lblnWhiteBack = False
                
                    '@ﾛｯﾄ区分(FD/SD)の場合(ﾀﾞﾐｰ系)
                    If mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strFlowClass = CPstrFillerDummy Or _
                        mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strFlowClass = CPstrSideDummy Then

                        For llngRowCnt = CMvsfImageTitleRow + 1 To .Rows.Count - 1
                            '@縦炉ｿﾞｰﾝとAｷｬﾘｱｸﾞﾙｰﾌﾟが同じ場合
                            If mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strACarrierGroup = .GetData(llngRowCnt, CMlngImageColNo) And _
                                .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                                
                                '@ATray情報(ATRAY=12or13)
                                '@ﾓﾆﾀｰ有
                                If mtypACarrierGroupInfo.strMonitorUseFlag = CPstrFlagOn Then
                                    .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_On))
                                    .SetData(llngRowCnt, CMlngImageColACarrierClass, CPstrACarDummyMoniOn)
                                    
                                Else
                                    .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_Off))
                                    .SetData(llngRowCnt, CMlngImageColACarrierClass, CPstrACarDummyMoniOff)
                                    
                                End If
                                
                                lblnLotDisp = True
                                lblnWhiteBack = True
                                Exit For
                            End If
                        Next
                    
                    '@ﾛｯﾄ区分(MO/QU)の場合(ﾓﾆﾀｰ系)
                    ElseIf mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strFlowClass = CPstrFlowClassMO Or _
                        mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strFlowClass = CPstrFlowClassQU Then

                        For llngRowCnt = CMvsfImageTitleRow + 1 To .Rows.Count - 1
                            '@縦炉ｿﾞｰﾝとAｷｬﾘｱｸﾞﾙｰﾌﾟが同じ場合
                            If .GetData(llngRowCnt, CMlngImageColNo) = CPstrSpecUseMonitorName And _
                                .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                            
                                '@ATray情報(ATRAY=4)
                                '@ﾓﾆﾀ
                                .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor))
                                .SetData(llngRowCnt, CMlngImageColACarrierClass, CPstrACarQuality)
                                                    
                                lblnLotDisp = True
                                lblnWhiteBack = True
                                Exit For
                            End If
                        Next
                    
                    '@その他は製品を想定
                    Else
                    
                        For llngRowCnt = CMvsfImageTitleRow + 1 To .Rows.Count - 1
                            '@縦炉ｿﾞｰﾝとAｷｬﾘｱｸﾞﾙｰﾌﾟが同じ場合
                            If mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strACarrierGroup = .GetData(llngRowCnt, CMlngImageColNo) And _
                                .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                                
                                '@ATray情報(ATRAY=12or13)
                                '@ﾓﾆﾀｰ有
                                If mtypACarrierGroupInfo.strMonitorUseFlag = CPstrFlagOn Then
                                    .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_On))
                                Else
                                    .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_Off))
                                End If
                                
                                lblnLotDisp = True
                                lblnWhiteBack = False
                                Exit For
                            End If
                        Next
                    End If
                    
                    '@表示
                    If lblnLotDisp = True Then
                        If lblnWhiteBack = True Then
                            '@背景色(白)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            Dim cellRange As CellRange = .GetCellRange(llngRowCnt, CMlngImageColLotId, llngRowCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                                                
                            llngCarrierCnt = llngCarrierCnt + 1
                        End If
                        
                        '@ﾛｯﾄ情報
                        .SetData(llngRowCnt, CMlngImageColLotId, mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strLotID)
                        .SetData(llngRowCnt, CMlngImageColFlowClass, mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strFlowClass)
                        .SetData(llngRowCnt, CMlngImageColACarrierId, mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strACarrierId)
                        
                    End If
                Next
                
                '@再度度ｸﾞﾘｯﾄﾞ検索
                '@DUMMYは現時点(2018/12/04)では仕様が未確定の為
                '@製品/MO/QU以外のｸﾞﾚｰ行にはﾛｯﾄ未割当ACARRIERをﾛｯﾄID無で登録できる様にする
                For llngRowCnt = CMvsfImageTitleRow + 1 To .Rows.Count - 1
                    '@ｸﾞﾚｰ行でﾛｯﾄIDが無い場合
                    If .GetData(llngRowCnt, CMlngImageColLotId) = vbNullString And _
                        .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                        
                        .SetData(llngRowCnt, CMlngImageColLotId, CMstrNoAnser)
                        .SetData(llngRowCnt, CMlngImageColFlowClass, CMstrNoAnser)
                        
                        '@ATray情報(ATRAY=12or13)
                        '@ﾓﾆﾀｰ有
                        'If mtypACarrierGroupInfo.strMonitorUseFlag = CPstrFlagOn Then
                        '    .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_On))
                        '    .SetData(llngRowCnt, CMlngImageColACarrierClass, CPstrACarDummyMoniOn)
                        'Else
                        '    .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_Off))
                        '    .SetData(llngRowCnt, CMlngImageColACarrierClass, CPstrACarDummyMoniOff)
                        'End If
                        
                        '@↓2020/07/06 (Mon) 16:31:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@ATray情報(ATRAY=12or13)
                        '@品確の場合
                        If mtypACarrierGroupInfo.strBatchFlowClass = CMstrQuality Then
                            '@12確定
                            .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_On))
                            .SetData(llngRowCnt, CMlngImageColACarrierClass, CPstrACarDummyMoniOn)
                    
                        Else
                            '@ﾓﾆﾀｰ有
                            If mtypACarrierGroupInfo.strMonitorUseFlag = CPstrFlagOn Then
                                .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_On))
                                .SetData(llngRowCnt, CMlngImageColACarrierClass, CPstrACarDummyMoniOn)
                            Else
                                .SetData(llngRowCnt, CMlngImageColATrayNum, CStr(CMlngATrayCont_Monitor_Off))
                                .SetData(llngRowCnt, CMlngImageColACarrierClass, CPstrACarDummyMoniOff)
                            End If
                        End If
                        '@↑2020/07/06 (Mon) 16:31:20 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@背景色(白)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                        Dim cellRange As CellRange = .GetCellRange(llngRowCnt, CMlngImageColLotId, llngRowCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                        
                        llngCarrierCnt = llngCarrierCnt + 1
                    End If
                Next
                                
                '@再度度ｸﾞﾘｯﾄﾞ検索(全選択済みが確認)
                mblnAllSelect = False
                For llngRowCnt = CMvsfImageTitleRow + 1 To .Rows.Count - 1
                    '@選択行でA_CARRIERがある場合
                    If .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                        If .GetData(llngRowCnt, CMlngImageColACarrierId) <> vbNullString Then
                            mblnAllSelect = True
                        Else
                            Exit For
                        End If
                    End If
                Next
                                
                '@列幅の設定
                .AutoSizeCols(CMlngImageColNo, .Cols.Count - 1, 6)

                'NSYS ヘッダを選択状態にする
                .Row = 0
                
                '@描画ﾛｯｸ解除
                .Redraw = flexRDDirect
                   
            End With
            
            '@選択Aｷｬﾘｱ数
            lblACarrierCnt.Text = CStr(llngCarrierCnt)
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvTateroImage_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvstrACarrierCombData_Sel
    '機　能：ｺﾝﾎﾞ文字設定
    '引　数：lstrACarrierClass
    '戻り値：ｺﾝﾎﾞ文字
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Function prvstrACarrierCombData_Sel(ByVal lstrACarrierClass As String) As String
        
        Dim llngCnt     As Integer
        
        Try
            
            prvstrACarrierCombData_Sel = vbNullString
            
            If lstrACarrierClass = vbNullString Then
                Exit Function
            End If
            
            Select Case lstrACarrierClass
                
                '@Dummy&Mo無
                Case CPstrACarDummyMoniOff
            
                    '@ATray区分のｺﾝﾎﾞ文字作成
                    For llngCnt = 0 To mtypACarierListDummyMoniOff.Count -1
                        If prvstrACarrierCombData_Sel = vbNullString Then
                            prvstrACarrierCombData_Sel = mtypACarierListDummyMoniOff(llngCnt).strACarrierId
                        Else
                            prvstrACarrierCombData_Sel = prvstrACarrierCombData_Sel & "|" & mtypACarierListDummyMoniOff(llngCnt).strACarrierId
                        End If
                    Next
            
                '@Dummy&Mo有
                Case CPstrACarDummyMoniOn
            
                    '@ATray区分のｺﾝﾎﾞ文字作成
                    For llngCnt = 0 To mtypACarierListDummyMoniOn.Count -1
                        If prvstrACarrierCombData_Sel = vbNullString Then
                            prvstrACarrierCombData_Sel = mtypACarierListDummyMoniOn(llngCnt).strACarrierId
                        Else
                            prvstrACarrierCombData_Sel = prvstrACarrierCombData_Sel & "|" & mtypACarierListDummyMoniOn(llngCnt).strACarrierId
                        End If
                    Next
            
                '@Qu/Mo
                Case CPstrACarQuality
            
                    '@ATray区分のｺﾝﾎﾞ文字作成
                    For llngCnt = 0 To mtypACarierListMoQu.Count -1
                        If prvstrACarrierCombData_Sel = vbNullString Then
                            prvstrACarrierCombData_Sel = mtypACarierListMoQu(llngCnt).strACarrierId
                        Else
                            prvstrACarrierCombData_Sel = prvstrACarrierCombData_Sel & "|" & mtypACarierListMoQu(llngCnt).strACarrierId
                        End If
                    Next
            
            End Select
            
            Exit Function
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvstrACarrierCombData_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvEnable_Chk
    '機　能：有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Sub prvEnable_Chk()
        
        Dim llngCnt              As Integer
            
        Try
            

            '@初期化
            cmdClose.Enabled = True
            cmdScanClear.Enabled = False
            cmdRegist.Enabled = False
            cmdRegistClear.Enabled = False
            
            '@Load中の場合
            If pblnFormLoad = False Then
                Exit Sub
            End If
            
            '@------------------
            '@確定取消
            '@------------------
            If mblnAllSelect = True Then
                cmdRegistClear.Enabled = True
                '@ﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegistClear)
                Exit Sub
            End If
            
            '@------------------
            '@SCAN全取消
            '@------------------
            With vsfTateroImage
                For llngCnt = 1 To .Rows.Count - 1
                    '@背景色(白)&ATrayがNULL
                    If .GetCellRange(llngCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) And _
                            .GetData(llngCnt, CMlngImageColACarrierId) <> vbNullString Then
                            
                        cmdScanClear.Enabled = True
                        Exit For
                    End If
                Next
            End With
                
            '@------------------
            '@確定
            '@------------------
            '@全ACarrierが入力済み
            With vsfTateroImage
                For llngCnt = 1 To .Rows.Count - 1
                    '@背景色(白)&ACarrierがNULL
                    If .GetCellRange(llngCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) And _
                        .GetData(llngCnt, CMlngImageColACarrierId) = vbNullString Then
                        
                        '@ﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtACarrierId)
                        
                        Exit Sub
                    End If
                Next
            End With

            cmdRegist.Enabled = True
            
            '@ﾌｫｰｶｽｾｯﾄ
            'Call pubSetFocus(cmdRegist)

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

    '関数名：flexGrid_BeforeDoubleClick
    '機　能：ｸﾞﾘｯﾄﾞ　ダブルクリック時前処理
    '引　数：sender：ｲﾍﾞﾝﾄ発生元
    '　　　：e     ：ｲﾍﾞﾝﾄｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2020/04/20 (Mon) 15:00:00 NSYS
    '備　考：
    Private Sub flexGrid_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfTateroImage.BeforeDoubleClick

        Try

            With CType(sender, C1FlexGrid)
                'NSYS 対象行が見出し行の場合、または、見出し行ダブルクリック時は抜ける
                If .Row < .Rows.Fixed OrElse .MouseRow < .Rows.Fixed Then
                    Exit Sub
                End If

                'NSYS DataMap対応列以外は抜ける
                If .Cols(.Col).ComboList Is Nothing OrElse .Cols(.Col).ComboList = vbNullString Then
                    Exit Sub
                End If

                'NSYS 背景色が灰色の場合は編集不可
                If .GetCellRange(.Row, CMlngImageColACarrierId).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
                    Exit Sub
                End If

                If sender.Name = vsfTateroImage.Name Then
                    If sender.Col <> CMlngImageColACarrierId Then
                        If sender.HitTest(e.X,e.Y).Type = HitTestTypeEnum.Cell Then
                            '本来の処理をキャンセル
                            Exit Sub
                        ElseIf sender.HitTest(e.X,e.Y).Type = HitTestTypeEnum.EditButton Then
                            '本来の処理をキャンセル
                            Exit Sub
                        End If
                    End If
                Else
                    If sender.HitTest(e.X,e.Y).Type = HitTestTypeEnum.Cell Then
                        '本来の処理をキャンセル
                        Exit Sub
                    ElseIf sender.HitTest(e.X,e.Y).Type = HitTestTypeEnum.EditButton Then
                        '本来の処理をキャンセル
                        Exit Sub
                    End If
                End If

                'NSYS DataMap対応列の場合、VB.NETのデフォルトの動作をキャンセルする
                e.Cancel = True

                'NSYS VB6互換で編集を開始し、ドロップダウンを展開する
                .StartEditing()
                CType(.Editor, ComboBox).DroppedDown = True
            End With

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "flexGrid_BeforeDoubleClick"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfTateroImage.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfTateroImage.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：flex_SetupEditor
    '機　能：グリッドからフォーカスが外れたときの処理
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2020/05/20 NSYS
    '更新日：
    '備　考：
    Private Sub flexGrid_Leave(sender As Object, e As EventArgs) Handles vsfTateroImage.Leave
        
        Dim CMlngTopRow As Integer

        Try

            'グリッド内コンボボックス編集解除
            with sender
                CMlngTopRow = .TopRow
                .Col = 0
                .AllowEditing = False
                .TopRow = CMlngTopRow
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

End Class
