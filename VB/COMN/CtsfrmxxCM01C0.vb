'ﾌｧｲﾙ名：xxCM01C0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾍﾞﾝﾀﾞｰﾛｯﾄID一覧表示
'作成日：2004/03/01 (Mon) 13:05:38 K.Takano
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：2018/11/15 EN0042から共通化のためCM01C0に変更
'　　　：「ﾛｯﾄ投入(基板)」「Aｷｬﾘｱ管理」で使用
'Copyright(C)2003-2018, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM01C0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM01C0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM01C0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM01C0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM01C0)
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
    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrinv_partlistVer              As String = "02.00"             '部材一覧取得

    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM01C0

    '@vsfVenderLotListの定数宣言（ｶﾗﾑ）
    Private Const CMvsfVenderLotListColNo           As Integer = 0                     'No
    Private Const CMvsfVenderLotListColInvLotID     As Integer = 1                     'ﾍﾞﾝﾀﾞｰﾛｯﾄID
    Private Const CMvsfVenderLotListColdate         As Integer = 2                     '受入日
    Private Const CMvsfVenderLotListColProLotID     As Integer = 3                     '製造ﾛｯﾄID(PRODUCTION_LOT_ID)
    Private Const CMvsfVenderLotListColInvNum       As Integer = 4                     '在庫数

    '@vsfVenderLotListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMvsfVenderLotListNo              As String = "№"
    Private Const CMvsfVenderLotListLotID           As String = "在庫ロットID"
    Private Const CMvsfVenderLotListdate            As String = "受入日"
    Private Const CMvsfVenderLotListProLotID        As String = "製造ロットID"
    Private Const CMvsfVenderLotListNum             As String = "在庫数"

    '@vsfVenderLotListの定数宣言（表示幅）
    Private Const CMvsfVenderLotListColWNo          As Integer = 40                    'No
    Private Const CMvsfVenderLotListColWInvLotID    As Integer = 166                   'ﾍﾞﾝﾀﾞｰﾛｯﾄID
    Private Const CMvsfVenderLotListColWInvNum      As Integer = 166                   '在庫数
    Private Const CMvsfVenderLotListColWInvProLotID As Integer = 166                   '製造ﾛｯﾄID(PRODUCTION_LOT_ID)
    Private Const CMvsfVenderLotListColWInvdate     As Integer = 200                   '受入日

    '@ｸﾞﾘｯﾄﾞその他
    Private Const CMvsfVenderLotListRowTitle        As Integer = 0                     'ﾀｲﾄﾙ
    Private Const CMlngGrid3DBlank                  As Integer = 4                     'ﾌﾞﾗﾝｸ
    Private Const CMvsfVenderLotListHHeight         As Integer = 28                    'ﾍｯﾀﾞｰの高さ
    Private Const CMvsfVenderLotListHeight          As Integer = 38                    '１ｽﾛｯﾄの高さ
    Private Const CMvsfVenderLotListColmNum         As Integer = 5                     'ｶﾗﾑ数
    Private Const CMvsfVenderLotListFontSize        As Integer = 12                    'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

    '@ｸﾞﾘｯﾄﾞの幅
    Private Const CMlngGridWidth                    As Integer = CMvsfVenderLotListColWNo _
                                                    + CMvsfVenderLotListColWInvLotID _
                                                    + CMvsfVenderLotListColWInvNum _
                                                    + CMvsfVenderLotListColWInvProLotID _
                                                    + CMvsfVenderLotListColWInvdate _
                                                    + CMlngGrid3DBlank
    '@ﾍﾞﾝﾀﾞｰﾛｯﾄ状態(正常)
    Private Const CMInvLotNormal                    As String = "正常"

    '@↓2018/11/15 (Thu) 15:40:59 T.Oide **************************************************
    '@呼出元親ﾌｫｰﾑ
    Private Const CMstrEN0040                       As String = "frmxxEN0040"       'ﾛｯﾄ投入(基板)
    Private Const CMstrEN02T0                       As String = "frmxxEN02T0"       'Aｷｬﾘｱ管理
    '@↑2018/11/15 (Thu) 15:40:59 T.Oide **************************************************

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypvenderLotList                       As List(Of PartLotList)         'ﾍﾞﾝﾀﾞｰﾛｯﾄ一覧
    Private mlngvenderLotListCnt                    As Integer                      'ﾍﾞﾝﾀﾞｰﾛｯﾄ一覧ｶｳﾝﾄ
    Private mtypChgSort                             As ChgSort                      'ｿｰﾄ保持用
    Private mstrEventName                           As String                       'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfvenderLotList, cmdUp, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/01 (Mon) 13:07:27 K.Takano
    '更新日：2004/09/30 (Thu) 12:53:19 N.Kasai
    '備　考：2004/09/30 (Thu) 12:53:19 N.Kasai  pubblnInvPartList_Sel 処理区分 0G削除（№1002）
    Private Sub Form_Load()
        
        Dim lstrPartCode                As String       '部材ｺｰﾄﾞ
        Dim lstrVenderClassID           As String       '部品ID(部材ID)
        Dim lblnAns                     As Boolean      'ﾍﾞﾝﾀﾞｰﾛｯﾄID取得戻り値(True/False)

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "Form_Load"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@画面情報の初期化
            Call prvfrmxxCM01C0_Init()
            
            '@利用部材,部材ｺｰﾄﾞ,ﾍﾞﾝﾀﾞｰ設定
            With ptypPart
                lblInvPointID.Text = .strPartCode & CPstrSpace & .strPartName
                lblVenderName.Text = .strVenderName
                lstrPartCode = .strPartCode
                lstrVenderClassID = vbNullString
            End With
            
            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID取得結果
            lblnAns = prvblnvenderLotList_Sel(lstrPartCode, lstrVenderClassID)
            
            '@結果判定
            If lblnAns = True Then
                '@成功の場合
                '@取得件数による処理判別
                If mlngvenderLotListCnt = 0 Then
                    '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    '@"<TRM29I>$$該当件数 ： %1 件"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, mlngvenderLotListCnt)
                    '@ｲﾝﾌｫﾒｰｼｮﾝ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                Else
                    '@該当件数が0件以上の場合
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄﾘｽﾄの表示処理
                    Call prvvsfvenderLotList_Disp()
                End If
            Else
                '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)
            
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
                
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

    '関数名：Form_KeyDown
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/03/17 (Wed) 15:18:41 M.Miura
    '更新日：2004/04/12 (Mon) 15:08:42 S.Deguchi
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
            
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）処理を実行する。
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfvenderLotList, cmdUP, cmdDown, False)
            
            '@確定ﾎﾞﾀﾝが無効の場合
            If cmdRegist.Enabled = False Then
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                End Select
            Else
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        '@一覧にﾌｫｰｶｽがある場合
                        If ActiveControl.Name = vsfvenderLotList.Name Then
                            With vsfvenderLotList
                                '@ﾃﾞｰﾀ行の場合
                                If .Row >= .Rows.Fixed Then
                                    '@確定処理
                                    Call cmdRegist_Click(sender,e)
                                End If
                            End With
                        Else
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                End Select
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑのQueryUnload処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/05/25 (Tue) 12:56:16 S.Deguchi
    '更新日：2018/11/15 (Thu) 15:25:27 T.Oide
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            '@Private構造体のｸﾘｱ
            mtypvenderLotList = New List(Of PartLotList)
            mtypChgSort.typChgSortList = New List(Of ChgSortList)

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
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/01 (Mon) 13:06:47 K.Takano
    '更新日：2004/03/01 (Mon) 13:06:47
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

    '関数名：cmdLotList_Click
    '機　能：最新取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 16:05:30 N.Kojima
    '更新日：2004/09/30 (Thu) 12:57:04 N.Kasai
    '備　考：2004/09/30 (Thu) 12:57:04 N.Kasai      pubblnInvPartList_Sel 処理区分 0G削除（№1002）
    '　　　：2005/04/11 (Mon) 14:27:31 S.Deguchi    不具合№723の対応で確定ﾎﾞﾀﾝ活性化処理を修正
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click
        
        Dim lstrPartCode                As String       '部材ｺｰﾄﾞ
        Dim lstrVenderClassID           As String       '部品ID(部材ID)
        Dim lblnAns                     As Boolean      'ﾍﾞﾝﾀﾞｰﾛｯﾄID取得戻り値(True/False)

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

            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdLotList_Click"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@ﾍﾞﾝﾀﾞｰﾛｯﾄ一覧の初期化
            'Call prvvsfvenderLotList_init()
            
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
            '@該当件数を初期化
            lblLotCnt.Text = vbNullString
            
            '@利用部材,部材ｺｰﾄﾞ,ﾍﾞﾝﾀﾞｰ設定
            With ptypPart
                lstrPartCode = .strPartCode
                lstrVenderClassID = vbNullString
            End With
            
            '@ﾍﾞﾝﾀﾞｰﾛｯﾄID取得結果
            lblnAns = prvblnvenderLotList_Sel(lstrPartCode, lstrVenderClassID)
            '@結果判定
            If lblnAns = True Then
                '@成功の場合
                '@取得件数による処理判別
                If mlngvenderLotListCnt > 0 Then
                    '@該当件数が0件以上の場合
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄﾘｽﾄの表示処理
                    Call prvvsfvenderLotList_Disp()
                    'NSYS 一覧をフォーカスする
                    Call pubSetFocus(vsfvenderLotList)
                End If
            Else
                '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, mstrEventName)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：前ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/04 (Thu) 12:56:02 M.Miura
    '更新日：2004/04/12 (Mon) 15:54:37 H.Wajima
    '備　考：
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfvenderLotList, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：次ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/04 (Thu) 12:56:27 M.Miura
    '更新日：2004/03/04 (Thu) 12:56:27
    '備　考：
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfvenderLotList, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfVenderLotList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：ｿｰﾄした列の番号
    '　　　：Order：並べ替え方法（1:昇順、2:降順）
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 16:56:06 H.Wajima
    '更新日：2004/10/15 (Fri) 11:24:39 M.Miura
    '備　考：2004/10/15 (Fri) 11:24:39 M.Miura　ｿｰﾄ順の格納を追加
    Private Sub vsfVenderLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfVenderLotList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfVenderLotList.Rows.Count <= vsfVenderLotList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                'NSYS ソート情報格納用構造体初期化
                'ReDim Preserve .typChgSortList(.lngCnt)
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                'NSYS 編集済みソート情報を追加
                .typChgSortList.add(typChgSortListTmp)
            End With

            '@ｿｰﾄ後処理
            Call pubVsfAfterSort(vsfvenderLotList, _
                                 CMvsfVenderLotListColInvLotID & _
                                 vbTab & _
                                 CMvsfVenderLotListColInvNum, _
                                 cmdUP, _
                                 cmdDown)
            
            'NSYS イベントハンドラーを元に戻す
            AddHandler vsfVenderLotList.BeforeRowColChange, AddressOf vsfVenderLotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfVenderLotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfVenderLotList_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 11:26:20 M.Miura
    '更新日：2004/10/15 (Fri) 11:26:20
    '備　考：
    Private Sub vsfVenderLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfVenderLotList.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfVenderLotList.Rows.Count <= vsfVenderLotList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（ｷｬﾘｱID）
                mtypChgSort.strKey = vsfvenderLotList.GetData(e.NewRange.r1, CMvsfVenderLotListColInvLotID) & _
                                     vsfvenderLotList.GetData(e.NewRange.r1, CMvsfVenderLotListColInvNum)
                                     
                With cmdRegist
                    '@確定ﾎﾞﾀﾝが表示されていて無効の場合
                    If .Enabled = False Then
                        '@確定ﾎﾞﾀﾝを有効
                        .Enabled = True
                    End If
                End With
            End If
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfVenderLotList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfVenderLotList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：ｿｰﾄした列の番号
    '　　　：Order：並べ替え方法（1:昇順、2:降順）
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 16:56:04 H.Wajima
    '更新日：2004/04/12 (Mon) 16:56:04
    '備　考：
    Private Sub vsfVenderLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfVenderLotList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfVenderLotList.Rows.Count <= vsfVenderLotList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ前処理
            Call pubVsfBeforeSort(vsfvenderLotList, _
                                  CMvsfVenderLotListColInvLotID & _
                                  vbTab & _
                                  CMvsfVenderLotListColInvNum)
            
            'NSYS BeforeRowColChangeイベントを抑止し、ボタンの状態変更やｿｰﾄ検索用ｷｰ設定を抑える
            RemoveHandler vsfVenderLotList.BeforeRowColChange, AddressOf vsfVenderLotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfVenderLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfVenderLotList_DblClick
    '機　能：ﾍﾞﾝﾀﾞｰﾛｯﾄ一覧ﾀﾞﾌﾞﾙｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/05 (Fri) 13:05:16 M.Miura
    '更新日：2004/03/05 (Fri) 13:05:16
    '備　考：
    Private Sub vsfVenderLotList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfVenderLotList.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfVenderLotList.Rows.Count <= vsfVenderLotList.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfvenderLotList.MouseRow <= 0 Then
                Exit Sub
            End If
                
            '@選択確定
            Call cmdRegist_Click(sender,e)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfVenderLotList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：ﾍﾞﾝﾀﾞｰﾛｯﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/04 (Thu) 14:19:10 M.Miura
    '更新日：2004/03/04 (Thu) 14:19:10
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@行が選択されていない場合は格納しない
            If vsfvenderLotList.Row >= 1 Then
                With vsfvenderLotList
                    CType(ptypPart.objParentFrom,frmxxEN0040).lblInvLotID.Text _
                        = .GetData(.Row, CMvsfVenderLotListColInvLotID)                                'ﾛｯﾄID
                    
                    'NSYS 在庫数 数値の場合のみフォーマット
                    If IsNumeric(.GetData(.Row, CMvsfVenderLotListColInvNum)) Then
                        CType(ptypPart.objParentFrom,frmxxEN0040).lblInvNum.Text _
                            = Format$(CLng(.GetData(.Row, CMvsfVenderLotListColInvNum)), CPstrDateFormatKanma)
                    Else
                        CType(ptypPart.objParentFrom,frmxxEN0040).lblInvNum.Text = .GetData(.Row, CMvsfVenderLotListColInvNum)
                    End If
                    
                    CType(ptypPart.objParentFrom,frmxxEN0040).lblProductionLotID.Text = _
                        .GetData(.Row, CMvsfVenderLotListColProLotID)                                  '製造ﾛｯﾄID
                End With
                
                '@ﾌｫｰﾑを閉じる
                Me.Close()
                
        '@↓2018/11/15 (Thu) 15:20:17 T.Oide **************************************************
                If ptypPart.objParentFrom.Name = CMstrEN0040 Then
        '@↑2018/11/15 (Thu) 15:20:17 T.Oide **************************************************

                    With CType(ptypPart.objParentFrom,frmxxEN0040)
                        '@投入予定ﾛｯﾄが選択されていない場合
                        If .lblLotID.Text = vbNullString Then
                            '@投入予定ﾛｯﾄﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(.cmdResvLot)
                            Exit Sub
                        End If
                        
                        '@ｷｬﾘｱIDが設定されていない場合
                        If .txtCarrierID.Text = vbNullString Then
                            '@投入予定ﾛｯﾄﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(.txtCarrierID)
                            Exit Sub
                        End If
                    End With
                    
        '@↓2018/11/15 (Thu) 15:20:41 T.Oide **************************************************
                End If
        '@↑2018/11/15 (Thu) 15:20:41 T.Oide **************************************************

            End If
            
            '@↓2018/11/15 (Thu) 15:25:23 T.Oide **************************************************
            '@呼出元ﾌｫｰﾑｸﾘｱ
            ptypPart.objParentFrom = Nothing
            '@↑2018/11/15 (Thu) 15:25:23 T.Oide **************************************************
            
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
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxCM01C0_Init
    '機　能：画面の初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/02 (Wed) 09:40:23 S.Deguchi
    '更新日：2005/11/02 (Wed) 09:40:23
    '備　考：
    Private Sub prvfrmxxCM01C0_Init()
        
        Try

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = CPstrSubFormCM01C0
            
            '@ﾗﾍﾞﾙの初期化
            lblInvPointID.Text = vbNullString    '利用部材
            lblVenderName.Text = vbNullString    '部材ｺｰﾄﾞ
            lblNowDate.Text = vbNullString       '情報取得日時
            lblLotCnt.Text = vbNullString        '該当件数

            '@ﾍﾞﾝﾀﾞｰﾛｯﾄ一覧の初期化
            Call prvvsfvenderLotList_init()

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化
            cmdLotList.Enabled = False              '最新取得
            cmdRegist.Enabled = False               '確定
            
            '@ｸﾞﾘｯﾄﾞ変数
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM01C0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfvenderLotList_init
    '機　能：ﾍﾞﾝﾀﾞｰﾛｯﾄID一覧初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/02 (Tue) 11:34:12 K.Takano
    '更新日：2004/03/02 (Tue) 11:34:12
    '備　考：
    Private Sub prvvsfvenderLotList_init()

        Try
            
            '@一覧表示の各ｶﾗﾑの幅,ﾀｲﾄﾙを設定
            With vsfvenderLotList
                '@文字表示位置設定
                .Cols(CMvsfVenderLotListColNo).TextAlign = TextAlignEnum.RightCenter     '右中央
                .Cols(CMvsfVenderLotListColInvLotID).TextAlign = TextAlignEnum.LeftCenter'左中央
                .Cols(CMvsfVenderLotListColdate).TextAlign = TextAlignEnum.LeftCenter    '左中央
                .Cols(CMvsfVenderLotListColProLotID).TextAlign = TextAlignEnum.LeftCenter'左中央
                .Cols(CMvsfVenderLotListColInvNum).TextAlign = TextAlignEnum.RightCenter '右中央
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定（なし）
                .FocusRect = FocusRectEnum.None
                .Cols.Count = CMvsfVenderLotListColmNum
                
                '@受入日を日付ﾀｲﾌﾟに設定
                '.Cols(CMvsfVenderLotListColdate).DataType = GetType(Date) NSYS 日付文字列対応のため削除
                
                '@投入予定日（左中よせ）
                .Cols(CMvsfVenderLotListColdate).TextAlign = TextAlignEnum.LeftCenter
                
                '@ｸﾞﾘｯﾄﾞの幅
                .Width = CMlngGridWidth
                
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMvsfVenderLotListColNo).Width = CMvsfVenderLotListColWNo
                .SetData(CMvsfVenderLotListRowTitle, CMvsfVenderLotListColNo, CMvsfVenderLotListNo)               '№
                
                .Cols(CMvsfVenderLotListColInvLotID).Width = CMvsfVenderLotListColWInvLotID
                .SetData(CMvsfVenderLotListRowTitle, CMvsfVenderLotListColInvLotID, CMvsfVenderLotListLotID)      '在庫ﾛｯﾄID
                
                .Cols(CMvsfVenderLotListColdate).Width = CMvsfVenderLotListColWInvdate
                .SetData(CMvsfVenderLotListRowTitle, CMvsfVenderLotListColdate, CMvsfVenderLotListdate)           '受入日
                
                .Cols(CMvsfVenderLotListColProLotID).Width = CMvsfVenderLotListColWInvProLotID
                .SetData(CMvsfVenderLotListRowTitle, CMvsfVenderLotListColProLotID, CMvsfVenderLotListProLotID)   '製造ﾛｯﾄID
                        
                .Cols(CMvsfVenderLotListColInvNum).Width = CMvsfVenderLotListColWInvNum
                .SetData(CMvsfVenderLotListRowTitle, CMvsfVenderLotListColInvNum, CMvsfVenderLotListNum)          '在庫数
                
                '@一覧表の表題設定
                '.FillStyle = flexFillRepeat
                .Select(CMvsfVenderLotListRowTitle, CMvsfVenderLotListColNo, CMvsfVenderLotListRowTitle, .Cols.Count - 1)
                Dim headerSellRange = .GetCellRange(CMvsfVenderLotListRowTitle, CMvsfVenderLotListColNo, CMvsfVenderLotListRowTitle, .Cols.Count - 1)
                Dim headerStyle = .Styles.Add("headerStyle")

                headerStyle.TextAlign = TextAlignEnum.CenterCenter                              '中央表示
                headerStyle.ForeColor = Color.Yellow                                            '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)               '背景色
                headerStyle.Font = New Font(.Font.Name, CMvsfVenderLotListFontSize,.Font.Style) 'ﾌｫﾝﾄｻｲｽﾞ
                headerSellRange.Style = headerStyle
                .Rows(CMvsfVenderLotListRowTitle).Height = CMvsfVenderLotListHHeight            '高さ
                
                '@ﾍｯﾀﾞｿｰﾄ方法設定
                .AllowSorting = AllowSortingEnum.SingleColumn
                
                '@行数設定
                .Rows.Count = CMvsfVenderLotListRowTitle + 1
                
                '@SORT
                '.Cols(CMvsfVenderLotListColdate).Sort = SortFlags.Ascending          '受入日：昇順 NSYS削除
                .Cols(CMvsfVenderLotListColProLotID).Sort = SortFlags.Descending      '製造ロットID：降順
                .Cols(CMvsfVenderLotListColInvNum).Sort = SortFlags.Descending        '在庫数：降順
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfvenderLotList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfvenderLotList_Disp
    '機　能：ﾍﾞﾝﾀﾞｰﾛｯﾄID一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/02 (Wed) 09:53:58 S.Deguchi
    '更新日：2005/11/02 (Wed) 09:53:58
    '備　考：
    Private Sub prvvsfvenderLotList_Disp()

        Dim llngCnt                     As Integer      'ｶｳﾝﾄ
        Dim llngNo                      As Integer      '№

        Try
            
            '@変数初期化
            llngNo = 0
            
            '@一覧情報を設定
            With vsfvenderLotList
                '@描画ﾛｯｸ
                .Redraw = False
                '@行設定の初期化
                RemoveHandler vsfvenderLotList.BeforeRowColChange,AddressOf vsfVenderLotList_BeforeRowColChange
                .Rows.Count = .Rows.Fixed
                AddHandler vsfvenderLotList.BeforeRowColChange,AddressOf vsfVenderLotList_BeforeRowColChange
                '@非活性化
                '.Enabled = False NSYS ちらつき対応のため削除
                
                For llngCnt = 0 To mlngvenderLotListCnt - 1
                    '@現在状態が「正常」の場合はｸﾞﾘｯﾄﾞに表示する
                    If mtypvenderLotList(llngCnt).strCurrentStatus = CMInvLotNormal Then
                        '@行追加
                        RemoveHandler vsfvenderLotList.BeforeRowColChange,AddressOf vsfVenderLotList_BeforeRowColChange
                        .Rows.Count = .Rows.Count + 1
                        AddHandler vsfvenderLotList.BeforeRowColChange,AddressOf vsfVenderLotList_BeforeRowColChange
                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngNo = llngNo + 1
                        '@№
                        .SetData(llngNo, CMvsfVenderLotListColNo, llngNo)
                        '@在庫ﾛｯﾄID
                        .SetData(llngNo, CMvsfVenderLotListColInvLotID, mtypvenderLotList(llngCnt).strLotID)
                        '@受入日
                        .SetData(llngNo, CMvsfVenderLotListColdate, mtypvenderLotList(llngCnt).strDate)
                        '@製造ﾛｯﾄID
                        .SetData(llngNo, CMvsfVenderLotListColProLotID, mtypvenderLotList(llngCnt).strProductionLotId)
                        '@在庫数 NSYS 数値の場合のみフォーマット
                        If IsNumeric(mtypvenderLotList(llngCnt).strNum) Then
                            .SetData(llngNo, CMvsfVenderLotListColInvNum, Format$(CLng(mtypvenderLotList(llngCnt).strNum), CPstrDateFormatKanma))
                        Else
                            .SetData(llngNo, CMvsfVenderLotListColInvNum, mtypvenderLotList(llngCnt).strNum)
                        End If
                    
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngNo).Height = CMvsfVenderLotListHeight
                    End If
                Next llngCnt
            
                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                '@該当件数を格納
                lblLotCnt.Text = llngNo
            
                '@描画ﾛｯｸ解除
                '.Redraw = True NSYS ちらつき対策のため削除
                '@活性化
                '.Enabled = True
            
                '@次前頁ﾎﾞﾀﾝ制御
                Call pubVsfDisp(vsfvenderLotList, cmdUP, cmdDown)
                
                '@見出し以外の行が存在するかどうかをﾁｪｯｸする
                If .Rows.Fixed <> .Rows.Count Then
                    '@見出し以外の行が存在する場合
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@初期選択行の検索
                        If CType(ptypPart.objParentFrom,frmxxEN0040).lblInvLotID.Text _
                           = .GetData(llngCnt, CMvsfVenderLotListColInvLotID) Then
                            '@親画面のﾍﾞﾝﾀﾞｰﾛｯﾄIDとｸﾞﾘｯﾄﾞのﾍﾞﾝﾀﾞｰﾛｯﾄIDが同じ場合
                            .Row = .Rows.Fixed - 1
                            '@該当行を初期選択行に設定する
                            .Select(llngCnt, .Cols.Fixed, llngCnt, .Cols.Count - 1)
                            Exit For
                        End If
                    Next llngCnt
                    
                    'NSYS削除
                    ''@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                    'Call pubVsfBeforeSort(vsfvenderLotList, _
                    '                      CMvsfVenderLotListColInvLotID & _
                    '                      vbTab & _
                    '                      CMvsfVenderLotListColInvNum)
                    ' 
                    ''@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                    'Call pubVsfAfterSort(vsfvenderLotList, _
                    '                     CMvsfVenderLotListColInvLotID & _
                    '                     vbTab & _
                    '                     CMvsfVenderLotListColInvNum, _
                    '                     cmdUP, _
                    '                     cmdDown)
                End If
            
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        '@該当行をｿｰﾄ
                        '.Cell(flexcpSort, .Rows.Fixed, mtypChgSort.typChgSortList(llngCnt).lngCol, .Rows.Count - 1) _
                        '    = mtypChgSort.typChgSortList(llngCnt).lngOrder
                        'NSYS ソート呼び出し変更
                        RemoveHandler vsfvenderLotList.BeforeRowColChange,AddressOf vsfVenderLotList_BeforeRowColChange
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder,mtypChgSort.typChgSortList(llngCnt).lngCol)
                        AddHandler vsfvenderLotList.BeforeRowColChange,AddressOf vsfVenderLotList_BeforeRowColChange
                    Next llngCnt
                End If
                
                '@ｿｰﾄ検索用ｷｰ（ｷｬﾘｱID）がある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ｷｬﾘｱID、大工程、小工程が同じ場合
                        If .GetData(llngCnt, CMvsfVenderLotListColInvLotID) & _
                           .GetData(llngCnt, CMvsfVenderLotListColInvNum) = mtypChgSort.strKey Then
                           
                            RemoveHandler vsfvenderLotList.BeforeRowColChange,AddressOf vsfVenderLotList_BeforeRowColChange
                            .Row = llngCnt
                            AddHandler vsfvenderLotList.BeforeRowColChange,AddressOf vsfVenderLotList_BeforeRowColChange
                            
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                            Call pubVsfBeforeSort(vsfvenderLotList, _
                                                  CMvsfVenderLotListColInvLotID & _
                                                  vbTab & _
                                                  CMvsfVenderLotListColInvNum)
                            
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                            Call pubVsfAfterSort(vsfvenderLotList, _
                                                 CMvsfVenderLotListColInvLotID & _
                                                 vbTab & _
                                                 CMvsfVenderLotListColInvNum, _
                                                 cmdUP, _
                                                 cmdDown)
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｶﾚﾝﾄ行初期化
                    .Row = .Rows.Fixed - 1
                    .TopRow = .Rows.Fixed
                End If
            
                '@活性化
                .Redraw = True
            
                '@最新取得ﾎﾞﾀﾝの制御
                If .Rows.Count > 1 Then
                    cmdLotList.Enabled = True
                Else
                    cmdLotList.Enabled = False
                End If
            
                '@選択確定ﾎﾞﾀﾝの制御
                If .Row >= .Rows.Fixed Then
                    cmdRegist.Enabled = True
                Else
                    '@ﾛｯｸ
                    cmdRegist.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfvenderLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnvenderLotList_Sel
    '機　能：在庫ﾛｯﾄ一覧取得処理
    '引　数：lstrPartCode：利用部材ID
    '　　　：lstrVenderClassID：ﾍﾞﾝﾀﾞｰｸﾗｽID
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/02 (Wed) 10:37:40 S.Deguchi
    '更新日：2018/11/15 (Thu) 15:17:51 T.Oide
    '備　考：
    Private Function prvblnvenderLotList_Sel(ByVal lstrPartCode As String, _
                                             ByVal lstrVenderClassID As String) As Boolean

        Dim lblnAns     As Boolean      '汎用戻り値
        
        Try
            
            '@初期化
            prvblnvenderLotList_Sel = False

            mtypvenderLotList = New List(Of PartLotList)
            mlngvenderLotListCnt = 0
            
        '@↓2018/11/15 (Thu) 15:17:41 T.Oide **************************************************
            '@呼出元で分岐
            Select Case ptypPart.objParentFrom.Name
            
                Case CMstrEN0040
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID取得【CPstrCD0A:部品ｺｰﾄﾞ別】
                    lblnAns = pubblnInvPartList_Sel(CMstrinv_partlistVer, _
                                                    CPstrCD0A, _
                                                    lstrPartCode, _
                                                    lstrVenderClassID, _
                                                    mtypvenderLotList, _
                                                    mlngvenderLotListCnt, , , _
                                                    CType(ptypPart.objParentFrom,frmxxEN0040).lblPd.Text)
                Case CMstrEN02T0
                    '@ﾍﾞﾝﾀﾞｰﾛｯﾄID取得【CPstrCD0A:部品ｺｰﾄﾞ別】
                    lblnAns = pubblnInvPartList_Sel(CMstrinv_partlistVer, _
                                                    CPstrCD0A, _
                                                    lstrPartCode, _
                                                    lstrVenderClassID, _
                                                    mtypvenderLotList, _
                                                    mlngvenderLotListCnt, , , _
                                                    vbNullString)
            End Select
        '@↑2018/11/15 (Thu) 15:17:41 T.Oide **************************************************
                                            
            '@結果判定
            If lblnAns = True Then
                '@成功を返す
                prvblnvenderLotList_Sel = True
            End If
            
            Exit Function
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnvenderLotList_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
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
