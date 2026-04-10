'ﾌｧｲﾙ名：xxCM00E1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Aｷｬﾘｱ選択画面
'作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
'更新日：2019/02/13 (Wed) 15:13:26 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00E1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00E1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00E1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00E1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00E1)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00E1  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarracargroupinfo_Ver        As String = "01.00"         'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
    Private Const CMstrcarracarlist_Ver             As String = "01.00"         'Aｷｬﾘｱﾘｽﾄ

    '@vsfTateroImage定数宣言(ｶﾗﾑ)
    Private Const CMlngImageColNo                   As Integer = 0                 '縦炉ｿﾞｰﾝNo
    Private Const CMlngImageColACarrierId           As Integer = 1                 'AｷｬﾘｱID
    Private Const CMlngImageColATrayNum             As Integer = 2                 'Aﾄﾚｲ数

    '@vsfTateroImage定数宣言(表示幅)
    Private Const CMlngImageColWNo                  As Integer = 100 '1500         '縦炉ｿﾞｰﾝNo
    Private Const CMlngImageColWACarrierId          As Integer = 200 '3000         'AｷｬﾘｱID
    Private Const CMlngImageColWATrayNum            As Integer = 200 '3000         'Aﾄﾚｲ数

    '@vsfTateroImage定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrImageColTNo                  As String = "縦炉ゾーン"
    Private Const CMstrImageColTACarrierId          As String = "AキャリアID"
    Private Const CMstrImageColTATrayNum            As String = "Aトレイ数"

    '@vsfLot定数宣言(その他)
    Private Const CMvsfImageCols                    As Integer = 3                 'ｶﾗﾑ数
    Private Const CMvsfImageRows                    As Integer = 5                 '行数
    Private Const CMvsfImageHHeight                 As Integer = 37 '550           'ﾍｯﾀﾞｰの高さ
    Private Const CMvsfImageHeight                  As Integer = 37 '550           '1ｽﾛｯﾄの高さ
    Private Const CMvsfImageTitleRow                As Integer = 0                 'ﾀｲﾄﾙ行
    Private Const CMvsfImageTitleCol                As Integer = 0                 'ﾀｲﾄﾙ列
    Private Const CMvsfImageTFontSize               As Integer = 16                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfImbageFontSize               As Integer = 16                'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ

    '@その他
    Private Const CMlngATrayCont_Monitor_On         As Integer = 12                'ﾓﾆﾀｰ有時のAtray数
    Private Const CMlngATrayCont_Monitor_Off        As Integer = 13                'ﾓﾆﾀｰ無時のAtray数

    '@ｴﾗｰ表示定数
    Private Const CMstrErr01                        As String = "重複"
    Private Const CMstrErr02                        As String = "使用不可"
    Private Const CMstrErr03                        As String = "Aトレイ数不一致"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    Private mblnFormLoadFlag                        As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mstrEventName                           As String                   'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名
    Private mtypACarrierGroupInfo                   As ACarrierGroupInfo
    Private mtypACarierList                         As List(Of ACarrierList)

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
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean
        Dim lstrACarrierClass   As String
            
        Try
            
            '@ｲﾍﾞﾝﾄ名格納
            mstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@画面の初期化
            Call prvfrmxxCM00E1_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@引継ﾃｰﾌﾟﾊﾞｯﾁID
            If ptypACarrierGroup.strTapeBatchId = vbNullString Then
                Exit Sub
            End If
                    
            '@=======================
            '@Aｷｬﾘｱｸﾞﾙｰﾌﾟ取得(ﾃｰﾌﾟﾊﾞｯﾁ指定)
            '@=======================
            lblnAns = pubblnACarrierGroupInfo_Sel(CMstrcarracargroupinfo_Ver, _
                                                ptypACarrierGroup.strTapeBatchId, _
                                                vbNullString, _
                                                vbNullString, _
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
            '@ACarrierClass変換
            '@=======================
            lstrACarrierClass = pubstrToACarrierClass_Sel(mtypACarrierGroupInfo.strBatchFlowClass, _
                                                        mtypACarrierGroupInfo.strMonitorUseFlag)
            
            '@=======================
            '@Aｷｬﾘｱﾘｽﾄ取得
            '@=======================
            lblnAns = pubblnACarrierList_Sel(CMstrcarracarlist_Ver, _
                                                lstrACarrierClass, _
                                                mtypACarrierGroupInfo.typtapeGroupList(0).strTapeStickGroup, _
                                                vbNullString, _
                                                mtypACarierList)
            '@結果確認
            If lblnAns = True Then
                
            Else
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
                            Call txtACarrierId_Validate(txtACarrierId, New CancelEventArgs(False))
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
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try
                
            '@ｾｯﾄﾌｫｰｶｽ
            Call pubSetFocus(txtACarrierId)
                
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
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
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
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
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
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim llngRowCnt  As Integer
        
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
                ptypACarrierGroup.lngGroupListCnt = .Rows.Count - 1
                If IsNothing(ptypACarrierGroup.typACarrierGroupList) Then
                    ptypACarrierGroup.typACarrierGroupList = New List(Of ACarrierGroupList)
                Else
                    ptypACarrierGroup.typACarrierGroupList.Clear
                End If 
            
                Dim typACarrierGroupListTmp As ACarrierGroupList = New ACarrierGroupList

                For llngRowCnt = 1 To .Rows.Count - 1
                    typACarrierGroupListTmp.strACarrierGroup = .GetData(llngRowCnt, CMlngImageColNo)
                    typACarrierGroupListTmp.strACarrierId = .GetData(llngRowCnt, CMlngImageColACarrierId)
                    typACarrierGroupListTmp.strATrayNum = .GetData(llngRowCnt, CMlngImageColATrayNum)
                    ptypACarrierGroup.typACarrierGroupList.Add(typACarrierGroupListTmp)
                Next
            End With
                
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

    '関数名：txtACarrierId_Change
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
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
    ''作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    ''更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
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
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
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
                '@未入力の場合
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
                            
                            Exit Sub
                        End If
                    End If
                Next
            
                '@ACarrier情報から該当IDを検索
                lblnFind = False
                For llngCnt = 0 To mtypACarierList.Count -1
                    If mtypACarierList(llngCnt).strACarrierId = .GetData(e.Row, CMlngImageColACarrierId) Then
                        
                        '@ATray数確認
                        If mtypACarierList(llngCnt).strATrayNum <> lblATrayCnt.Text Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003B, .GetData(e.Row, CMlngImageColACarrierId), CMstrErr03)
                            '@"<TRM3BW>$$<TRM3BW>$$AキャリアID[%1] 理由[%2]$$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                            '@入力値ｸﾘｱ
                            .SetData(e.Row, CMlngImageColACarrierId, vbNullString)
                            
                            '@ﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtACarrierId)
                            
                            Exit Sub
                            
                        End If
                        
                        '@ATray数表示
                        .SetData(e.Row, CMlngImageColATrayNum, mtypACarierList(llngCnt).strATrayNum)
                        
                        lblnFind = True
                        Exit For
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
            'NSYS データ行がない場合は処理を抜ける
            If vsfTateroImage.Rows.Count <= vsfTateroImage.Rows.Fixed Then
                Return
            End If

            With vsfTateroImage
            
                '@ﾍｯﾀﾞの場合
                If .Row <= CMvsfImageTitleRow Then
                    Exit Sub
                End If
                        
                Select Case .Col

                    '@ACARRIER_ID
                    Case CMlngImageColACarrierId
                        
                        '@背景色(白)
                        If .GetCellRange(.Row, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) Then
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
            
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfTateroImage
                .Clear(ClearFlags.Content,.GetCellRange(1, CMlngImageColACarrierId, .Rows.Count - 1, .Cols.Count - 1))
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

    '関数名：prvfrmxxCM00E1_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub prvfrmxxCM00E1_Init()
        
        Try
            
            '@ﾃｷｽﾄ
            txtACarrierId.CausesValidation = True
            txtACarrierId.Text = vbNullString
            
            '@各ﾗﾍﾞﾙの初期化
            lblACarrierCnt.Text = vbNullString
            lblATrayCnt.Text = vbNullString
                
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
                .strProcName = "prvfrmxxCM00E1_Init"        '処理名
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
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub prvvsfTateroImageList_Init()
        
        Dim llngCnt As Integer
        
        Try
            
            With vsfTateroImage
            
                '@ﾛｯｸ
                '.Enabled = False
                
                '@ｸﾘｱ
                .Clear(ClearFlags.Content)

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
                .SetData(CMvsfImageTitleRow, CMlngImageColACarrierId, CMstrImageColTACarrierId)
                .SetData(CMvsfImageTitleRow, CMlngImageColATrayNum, CMstrImageColTATrayNum)
                
                .Cols(CMlngImageColNo).Width = CMlngImageColWNo
                .Cols(CMlngImageColACarrierId).Width = CMlngImageColWACarrierId
                .Cols(CMlngImageColATrayNum).Width = CMlngImageColWATrayNum
                
                '@列位置の設定
                .Cols(CMlngImageColNo).TextAlign = TextAlignEnum.CenterCenter
                .Cols(CMlngImageColACarrierId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngImageColATrayNum).TextAlign = TextAlignEnum.RightCenter
                
                '@1行から最後まで
                For llngCnt = CMvsfImageTitleCol + 1 To .Rows.Count - 1
                    '@ｽﾛｯﾄ№設定
                    '.CellFontSize = CMvsfTateroImageFontSize           'ﾌｫﾝﾄｻｲｽﾞ
                    .Rows(llngCnt).Height = CMvsfImageHeight       '高さ
                    .SetData(llngCnt, CMlngImageColNo, Format$(llngCnt, CPstrSlotNoFormat))
                Next llngCnt
                
                '@自動列幅設定=自動調整する
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngImageColNo, .Cols.Count - 1, 6)
                
                '@ﾛｯｸ解除
                '.Enabled = True
                
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
    '作成日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '更新日：2018/10/22 (Mon) 19:09:07 Y.Yoneyama
    '備　考：
    Private Sub prvTateroImage_Disp()
        
        Dim llngCnt             As Integer
        Dim llngRowCnt          As Integer
        Dim llngCarrierCnt      As Integer

            
        Try
            
            '@変数初期化
            llngCarrierCnt = 0
                
            With vsfTateroImage
            
                '@描画ﾛｯｸ
                .Redraw = flexRDNone
                
                '@背景色(灰)
                Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle1.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange1 As CellRange = .GetCellRange(CMvsfImageTitleCol + 1, CMlngImageColACarrierId, .Rows.Count - 1, .Cols.Count - 1)
                cellRange1.Style = newStyle1

                '@Aｷｬﾘｱ数を抽出
                For llngCnt = 0 To mtypACarrierGroupInfo.lngTapeGroupListCnt -1
                    For llngRowCnt = CMvsfImageTitleRow + 1 To .Rows.Count - 1
                        '@縦炉ｿﾞｰﾝとAｷｬﾘｱｸﾞﾙｰﾌﾟが同じ場合
                        If mtypACarrierGroupInfo.typtapeGroupList(llngCnt).strACarrierGroup = .GetData(llngRowCnt, CMlngImageColNo) And _
                            .GetCellRange(llngRowCnt, CMlngImageColACarrierId).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                            
                            '@背景色(白)
                            Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            Dim cellRange2 As CellRange = .GetCellRange(llngRowCnt, CMlngImageColACarrierId, llngRowCnt, .Cols.Count - 1)
                            cellRange2.Style = newStyle2
                            
                            llngCarrierCnt = llngCarrierCnt + 1
                            Exit For
                        End If
                    Next
                Next
                
                '@ｸﾞﾘｯﾄﾞｺﾝﾎﾞ作成
                .Cols(CMlngImageColACarrierId).ComboList = prvstrACarrierCombData_Sel

                'NSYS ヘッダを選択状態にする
                .Row = 0
                .Col = 0
                
                '@描画ﾛｯｸ解除
                .Redraw = flexRDDirect
                   
            End With
            
            '@選択Aｷｬﾘｱ数
            lblACarrierCnt.Text = CStr(llngCarrierCnt)
            
            '@ATray数
            If mtypACarrierGroupInfo.strBatchFlowClass = UCase(CPstrProduct) Then
                If mtypACarrierGroupInfo.strMonitorUseFlag = CPstrFlagOn Then
                    lblATrayCnt.Text = CStr(CMlngATrayCont_Monitor_On)
                Else
                    lblATrayCnt.Text = CStr(CMlngATrayCont_Monitor_Off)
                End If
            End If
            
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
    '引　数：なし
    '戻り値：ｺﾝﾎﾞ文字
    '作成日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '更新日：2018/09/27 (Thu) 17:22:56 Y.Yoneyama
    '備　考：
    Private Function prvstrACarrierCombData_Sel() As String
        
        Dim llngCnt     As Integer
        
        Try
            
            prvstrACarrierCombData_Sel = vbNullString
                
            '@ATray区分のｺﾝﾎﾞ文字作成
            For llngCnt = 0 To mtypACarierList.Count -1
                If prvstrACarrierCombData_Sel = vbNullString Then
                    prvstrACarrierCombData_Sel = mtypACarierList(llngCnt).strACarrierId
                Else
                    prvstrACarrierCombData_Sel = prvstrACarrierCombData_Sel & "|" & mtypACarierList(llngCnt).strACarrierId
                End If
            Next
                
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
            
            '@Load中の場合
            If pblnFormLoad = False Then
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
            Call pubSetFocus(cmdRegist)

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

                '背景色が灰色の場合は編集不可
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
