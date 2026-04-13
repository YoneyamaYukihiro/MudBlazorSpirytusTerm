'ﾌｧｲﾙ名：xxEN00F2.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：在庫払出(在庫管理サブフォーム)
'作成日：2004/06/29 (Tue) 11:03:06 N.Kasai
'更新日：2009/04/15 (Wed) 10:10:50 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F2
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F2    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F2
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F2
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F2)
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
    '======================================Public===========================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00F2          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2019/10/04 (Fri) 10:03:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrinv_waferlistVer             As String = "03.02"                 'ｳｪﾊ在庫情報取得
    Private Const CMstrinv_waferlistVer             As String = "04.00"                 'ｳｪﾊ在庫情報取得
    '@↑2019/10/04 (Fri) 10:03:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrmas_reasoncodeVer            As String = "02.00"                 '理由ｺｰﾄﾞ取得
    Private Const CMstrinv_changstateVer            As String = "03.01"                 '部材状態変更

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)

    '@↓2019/10/03 (Thu) 17:14:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngvsfSlotMapColSlot            As Integer = 0                         'ｽﾛｯﾄ№
    'Private Const CMlngvsfSlotMapColCheck           As Integer = 1                         'ﾁｪｯｸﾎﾞｯｸｽ
    'Private Const CMlngvsfSlotMapColWFID            As Integer = 2                         'WFID
    'Private Const CMlngvsfSlotMapColClassID         As Integer = 3                         'CALSSID
    'Private Const CMlngvsfSlotMapColClass           As Integer = 4                         'CALSS
    Private Const CMlngvsfSlotMapColSlot            As Integer = 0                         'ｽﾛｯﾄ№
    Private Const CMlngvsfSlotMapColCheck           As Integer = 1                         'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfSlotMapColWFID            As Integer = 2                         'GRB
    Private Const CMlngvsfSlotMapColGRB             As Integer = 3                         'WFID
    Private Const CMlngvsfSlotMapColClassID         As Integer = 4                         'CALSSID
    Private Const CMlngvsfSlotMapColClass           As Integer = 5                         'CALSS
    '@↑2019/10/03 (Thu) 17:14:48 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngvsfSlotMapColWSlot           As Integer = 37                       'ｽﾛｯﾄ№
    Private Const CMlngvsfSlotMapColWCheck          As Integer = 19                       'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfSlotMapColWWFID           As Integer = 88                       'WFID
    Private Const CMlngvsfSlotMapColWClassID        As Integer = 88                       'CALSSID
    Private Const CMlngvsfSlotMapColWClass          As Integer = 88                       'CALSS
    '@↓2019/10/03 (Thu) 17:14:27 Y.Yoneyama 「.Netへ反映未」 **************************************************   
    Private Const CMlngvsfSlotMapColWGRB            As Integer = 40                       'GRB
    '@↑2019/10/03 (Thu) 17:14:27 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfSlotMapColTSlot           As String = " "                     'ｽﾛｯﾄNO
    Private Const CMstrvsfSlotMapColTWFID           As String = "WFID"                  'WFID
    Private Const CMstrvsfSlotMapColTClassID        As String = "ClassID"               'CLASSID
    Private Const CMstrvsfSlotMapColTClass          As String = "状態"                  'CLASS
    '@↓2019/10/03 (Thu) 17:14:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfSlotMapColTGRB            As String = "GRB"                   'GRB
    '@↑2019/10/03 (Thu) 17:14:32 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMlngvsfSlotMapRowTitle           As Integer = 0                         'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMlngvsfSlotMapColTitle           As Integer = 0                         'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMlngvsfSlotMapFixedCols          As Integer = 0                         'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngvsfSlotMapFixedRows          As Integer = 1                         'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngvsfSlotMapPageRows           As Integer = 25                        'ｽﾛｯﾄの行数
    Private Const CMlngvsfSlotMap3DBlank            As Integer = 60                        'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngvsfSlotMapHFontSize          As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfSlotMapRows               As Integer = 26                        '行数
    Private Const CMlngvsfSlotMapHHeight            As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfSlotMapHeight             As Integer = 18                        '1ｽﾛｯﾄの高さ

    '@ｸﾞﾘｯﾄﾞの幅
    Private Const CMlngGridWidth                As Integer = CMlngvsfSlotMapColWSlot _
                                                + CMlngvsfSlotMapColWCheck _
                                                + CMlngvsfSlotMapColWWFID _
                                                + CMlngvsfSlotMapColWClass _
                                                + CMlngvsfSlotMap3DBlank _
    '@ｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngGridHeight               As Integer = (CMlngvsfSlotMapHHeight _
                                                * CMlngvsfSlotMapFixedRows) _
                                                + (CMlngvsfSlotMapHeight _
                                                * CMlngvsfSlotMapPageRows) _
                                                + CMlngvsfSlotMap3DBlank

    '@払出ｺｰﾄﾞ
    Private Const CMstrPutOutID                 As String = "18"                    '払出ｺｰﾄﾞ(="18")

    '@払出理由ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize          As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMstrCmbFontName              As String = "ＭＳ ゴシック"         'ｺﾝﾎﾞﾎﾞｯｸｽのﾌｫﾝﾄ名
    Private Const CMlngCmbGridColExpendName     As Integer = 0                      '払出理由列番
    Private Const CMlngCmbGridColExpendID       As Integer = 1                      '払出理由ID列番(非表示項目)
    Private Const CMlngCmbSortAsc               As Integer = 1                      '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols              As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight             As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbFirstListIndex        As Integer = 0                      '1件目のﾃﾞｰﾀ表示用

    '@その他
    Private Const CMlngPutTab                   As Integer = 0                      '受入在庫ﾀﾌﾞIndex
    Private Const CMlngFinishTab                As Integer = 3                      '完成在庫ﾀﾌﾞIndex

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                 As String = "frmxxEN00F2"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                 As String = "Form_Load"             'ﾌｫｰﾑﾛｰﾄﾞ時処理
    Private Const CMstrCmdRegistClick           As String = "cmdRegist_Click"       '確定ﾎﾞﾀﾝ押下時処理

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mtypInvWaferList                    As InvWaferList                     '在庫WFﾘｽﾄ格納構造体
    Private mtypMasItemList                     As MasItemList                      '理由ｺｰﾄﾞ格納構造体
    Private mstrLastUpdate                      As String                           '最終更新日時
    Private mlngWFNum                           As Integer                          '在庫WFﾘｽﾄ取得時のWF枚数格納用
    Private mstrFirstSlotNo                     As String                           'ｽﾛｯﾄ№(有効WF№の最小値)
    Private mblnFormLoadFlag                    As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：処理済/False：未処理)

    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ
    Private ReadOnly vbButtonFace As Color = SystemColors.ControlLight              'NSYS ボタンの背景色

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
    '機　能：ﾌｫｰﾑ　Load時起動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 17:21:36 N.Kasai
    '更新日：2008/05/01 (Thu) 17:58:54 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 16:35:37 N.Kasai      pubblnInvWaferlist_Sel変更対応
    '　　　：2008/05/01 (Thu) 17:58:54 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          'ﾛｯﾄ保留理由取得戻り値(True/False)

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@=======================
            '@　画面初期化処理
            '@=======================
            Call prvFrmxxEN00F2_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@【在庫WFﾘｽﾄ取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnInvWaferlist_Sel(CMstrinv_waferlistVer, _
                                             ptypHoldConnect.strCarrierId, _
                                             pstrSBID, _
                                             mtypInvWaferList)
            
            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@在庫WFﾘｽﾄが0件か
                If mtypInvWaferList.lngInvWaferListCnt = 0 Then
                    '@0件の場合
                    
                    '@各種ｺﾝﾄﾛｰﾙを無効にする
                    cmdRegist.Enabled = False       '確定ﾎﾞﾀﾝ
                    cmbExpend.Enabled = False       '払出理由ｺﾝﾎﾞ
                Else
                    '@1件以上存在する場合
                
                    '@【理由ｺｰﾄﾞ取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                                     CPstrCD2V, _
                                                     mtypMasItemList)

                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        
                        '@Escﾎﾞﾀﾝを有効
                        Me.CancelButton = cmdClose
                        
                        Exit Sub
                    End If
                End If
            Else
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

            'NSYS ヘッダ行を選択状態にする
            vsfSlotMap.Row =0

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾍﾞｲﾄ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 14:19:43 S.Deguchi
    '更新日：2008/05/01 (Thu) 18:03:52 N.Kojima
    '備　考：
    '　　　：2008/05/01 (Thu) 18:03:52 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False:未処理"か
            If mblnFormLoadFlag = False Then
                '@未処理の場合
                
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True:処理済"をｾｯﾄ
                mblnFormLoadFlag = True
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@=======================
                '@　画面表示処理
                '@=======================
                Call prvFrmxxEN00F2_Disp()
                
                '@=======================
                '@　払出理由ｺﾝﾎﾞ作成処理
                '@=======================
                Call prvCmbExpendList_Disp()
                
                '@=======================
                '@　WFｽﾛｯﾄﾏｯﾌﾟの作成処理
                '@=======================
                Call prvVsfSlotMap_Disp(mtypInvWaferList)
                
                'NSYS フォーカスの状態をVB6版と合わせる
                Call pubSetFocus(cmbExpend)
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:15:32 N.Kasai
    '更新日：2008/05/01 (Thu) 18:14:42 N.Kojima
    '備　考：
    '　　　：2008/05/01 (Thu) 18:14:42 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Dim llngRow     As Integer

        Try

            
            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にし、処理終了
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
                    
                        '@〓〓 払出理由ｺﾝﾎﾞ 〓〓
                        Case cmbExpend.Name
                        
                            '@払出理由ｺﾝﾎﾞ(表示状態)がNULL以外か
                            If cmbExpend.Text <> vbNullString Then
                                
                                With vsfSlotMap
                                    
                                    '@WFｽﾛｯﾄﾏｯﾌﾟを有効にし、ﾌｫｰｶｽｾｯﾄ
                                    .Enabled = True
                                    Call pubSetFocus(vsfSlotMap)
                                    
                                    '@WFｽﾛｯﾄﾏｯﾌﾟの行の選択範囲を設定し、選択状態にする
                                    llngRow = CMlngvsfSlotMapRows - CLng(mstrFirstSlotNo) + 1
                                    .Select(llngRow - 1, CMlngvsfSlotMapColWFID, llngRow - 1, CMlngvsfSlotMapColWFID)
                                    
                                    Exit Sub
                                End With
                            End If
                    End Select
                    
                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
                
                
                '@〓 Spaceｷｰ 〓
                Case Keys.Space
                    
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                    
                        '@〓〓 WFｽﾛｯﾄﾏｯﾌﾟ 〓〓
                        Case vsfSlotMap.Name
                            
                            '@=======================
                            '@　WFｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸﾎﾞｯｸｽ制御処理
                            '@=======================
                            Call prvCheckBoxControl_Proc()
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/07/09 (Fri) 09:54:25 N.Kasai
    '更新日：2008/05/01 (Thu) 18:25:58 N.Kojima
    '備　考：
    '　　　：2008/05/01 (Thu) 18:25:58 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim ltypInvWaferList        As InvWaferList     '在庫WFﾘｽﾄ格納構造体初期化用
        Dim ltypMasItemList         As MasItemList      '在庫WFﾘｽﾄ格納構造体初期化用

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
            
                '@終了処理をｷｬﾝｾﾙする
                e.Cancel = True
                Exit Sub
            End If

            '@ﾓｼﾞｭｰﾙ構造体、変数の初期化
            mtypInvWaferList = ltypInvWaferList             '在庫WFﾘｽﾄ格納構造体
            mtypMasItemList = ltypMasItemList               '理由ｺｰﾄﾞ格納構造体
            
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

    '関数名：cmbExpend_Change
    '機　能：払出理由ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 13:47:11 N.Kasai
    '更新日：2008/05/02 (Fri) 13:21:37 N.Kojima
    '備　考：
    '　　　：2008/05/02 (Fri) 13:21:37 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmbExpend_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbExpend.Change

        Dim lblnAns     As Boolean      '戻り値格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@払出理由がNULL以外か
            If cmbExpend.Text <> vbNullString Then
                '@NULL以外の場合
                
                '@WFｽﾛｯﾄﾏｯﾌﾟを有効にする
                vsfSlotMap.Enabled = True
                
                '@=======================
                '@　入力ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnInput_Chk
                
                '@処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
                    
                    '@確定ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                Else
                    '@結果：正常の場合
                    
                    '@確定ﾎﾞﾀﾝを有効にする
                    cmdRegist.Enabled = True
                End If
            Else
                '@NULLの場合
            
                '@WFｽﾛｯﾄﾏｯﾌﾟを無効にする
                vsfSlotMap.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbExpend_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbExpend_CloseUp
    '機　能：払出理由ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/30 (Thu) 19:49:13 S.Deguchi
    '更新日：2008/05/02 (Fri) 13:27:51 N.Kojima
    '備　考：
    '　　　：2008/05/02 (Fri) 13:27:51 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmbExpend_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbExpend.CloseUp

        Dim llngRow         As Integer

        Try
            
            '@払出理由がNULLか
            If cmbExpend.Text = vbNullString Then

                Exit Sub
            Else
                '@NULL以外
            
                '@WFｽﾛｯﾄﾏｯﾌﾟが有効か
                If vsfSlotMap.Enabled = True Then
                    '@有効な場合
                    
                    With vsfSlotMap
                    
                        '@WFｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSlotMap)
                        
                        '@WFｽﾛｯﾄﾏｯﾌﾟの行の選択範囲を設定し、選択状態にする
                        llngRow = CMlngvsfSlotMapRows - CLng(mstrFirstSlotNo) + 1
                        .Select(llngRow - 1, CMlngvsfSlotMapColWFID, llngRow - 1, CMlngvsfSlotMapColWFID)
                    End With
                Else
                    '@無効な場合
                
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbExpend_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_Click
    '機　能：WFｽﾛｯﾄﾏｯﾌﾟ　ｸﾘｯｸ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 17:19:01 N.Kasai
    '更新日：2008/05/02 (Fri) 13:31:27 N.Kojima
    '備　考：
    '　　　：2008/05/02 (Fri) 13:31:27 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub vsfSlotMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.Click

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@　WFｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸﾎﾞｯｸｽ制御処理
            '@=======================
            Call prvCheckBoxControl_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なり
    '作成日：2004/07/02 (Fri) 17:21:58 N.Kasai
    '更新日：2008/05/02 (Fri) 13:32:18 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 11:21:52 N.Kasai      確定後、ｲﾝﾌｫﾒｰｼｮﾝ表示追加
    '　　　：2004/12/16 (Thu) 12:05:38 H.Wajima     受入在庫と完成在庫の判定を追加
    '　　　：2005/01/06 (Thu) 16:38:50 H.Wajima     完成在庫で全数以外の場合、「移載してください」のﾒｯｾｰｼﾞが表示されるよう修正
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2008/05/02 (Fri) 13:32:18 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean          '戻り値格納用
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ
        Dim ltypChangeStateList     As ChangeStateList  '在庫状態構造体
        Dim llngCheckCnt            As Integer          'WFｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸ数ｶｳﾝﾄ
        Dim llngWriteRow            As Integer          '登録WFのｽﾛｯﾄ№
        Dim llngWFNum               As Integer          '払出しWF枚数格納
        Dim llngDataCnt             As Integer          '構造体用ﾃﾞｰﾀｶｳﾝﾀ
        Dim lstrGuidMsg             As String           'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String           'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String           '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

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
            
            '@各種変数の初期化
            llngCheckCnt = 0        'WFｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸ数ｶｳﾝﾄ
            llngDataCnt = 0         'WFｽﾛｯﾄﾏｯﾌﾟのｽﾛｯﾄｶｳﾝﾄ
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@=======================
            '@　払出権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnRegistAuthority_Chk()
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypChangeStateList

                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strClassDivison = CPstrCD34            '処理区分：34(組立在庫払出処理)
                .strLotID = lblLotID.Text            '(在庫)ﾛｯﾄID
                .strLotEventId = CMstrPutOutID          'ﾛｯﾄｲﾍﾞﾝﾄID：18(払出)
                .strReasonCode = cmbExpend.Value        '払出理由ｺｰﾄﾞ
                .strComments = vbNullString             'ｺﾒﾝﾄ(作業ﾒﾓ)
                .strEmpID = pstrUserID                  '作業者ID
                .strLotLastUpdate = mstrLastUpdate      '最終更新日時
                
                For llngCnt = 1 To CMlngvsfSlotMapPageRows
                    '@検索行がﾁｪｯｸされているか
                    If vsfSlotMap.GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) = CheckEnum.Checked Then
                        '@ﾁｪｯｸされている場合、ﾁｪｯｸｶｳﾝﾀを+1する
                        llngCheckCnt = llngCheckCnt + 1
                    End If
                Next llngCnt
                .strNum = llngCheckCnt                  '数量(払出数量をｾｯﾄ)
                
                '@登録WF情報分の領域確保
                If .typWfList Is Nothing Then
                   .typWfList = New List(Of WFList)
                End If
                Do While(.typWfList.Count - 1 < .strNum)
                    .typWfList.Add(New WFList)
                Loop
                Dim typWfListtmp As WFList = New WFList
                
                For llngCnt = 1 To CMlngvsfSlotMapPageRows
                    
                    '@登録対象ｽﾛｯﾄ№を格納
                    llngWriteRow = CMlngvsfSlotMapRows - llngCnt
                    
                    '@対象行がﾁｪｯｸされているか
                    If vsfSlotMap.GetCellCheck(llngWriteRow, CMlngvsfSlotMapColCheck) = CheckEnum.Checked Then
                    
                        typWfListtmp.strSlotPosition _
                            = vsfSlotMap.GetData(llngWriteRow, CMlngvsfSlotMapColSlot)     'ｽﾛｯﾄﾅﾝﾊﾞｰ
                            
                        typWfListtmp.strWfId _
                            = vsfSlotMap.GetData(llngWriteRow, CMlngvsfSlotMapColWFID)     'WFID
                            
                        typWfListtmp.strClass = CPstrClass3J                             '区分(ｸﾗｽ)：払出
                        typWfListtmp.strClassID = CPstrClass3                            '区分(ｸﾗｽID)："3"
                        .typWfList(llngDataCnt) = typWfListtmp
                        '@構造体ﾃﾞｰﾀｶｳﾝﾄを+1する
                        llngDataCnt = llngDataCnt + 1
                    End If
                Next llngCnt
                
                .lngWfListCnt = llngDataCnt         'WFﾘｽﾄｶｳﾝﾄ
                llngWFNum = .lngWfListCnt           '払出WF枚数を格納
                
                .strHoldTermDate = vbNullString     '保留期限:Null
                .strHoldEmpID = vbNullString        '保留責任者:Null
                .strEntryTime = vbNullString        '登録日時:Null

            End With
            
            '@【在庫状態変更】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnInvChangState_Upd(CMstrinv_changstateVer, _
                                              ltypChangeStateList, _
                                              lstrGuidMsg, _
                                              lstrGuidMsgCode)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                If lstrGuidMsgCode <> vbNullString Then
                    '@何らかのｺｰﾄﾞが格納されている場合
                
                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                       CPstrMsgCrCode & lstrGuidMsg
                    
                    '@ﾒｯｾｰｼﾞ表示"編集済みｶﾞｲﾀﾞﾝｽMsg"
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                
                '@-------------------------------------------
                '@受入在庫と完成在庫で処理を振り分ける
                '@　①受入在庫→全数払出→中間在庫へ(ﾛｯﾄｱｳﾄ)
                '@　②完成在庫→全数払出→移載処理へ
                '@-------------------------------------------
                '@★ 在庫管理の選択ﾀﾌﾞにより処理分岐 ★
                Select Case ptypHoldConnect.lngTabFlag
                
                    '@〓 受入在庫Tab 〓
                    Case CMlngPutTab
                    
                        '@在庫WFﾘｽﾄ取得時のWF枚数と払出登録WF枚数が同じか
                        If mlngWFNum = llngWFNum Then
                            '@全数払出の場合
                        
                            '@ﾒｯｾｰｼﾞ表示："<TRM32I>$$ロット[%2]終了しました。キャリア[%1]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0032, lblCarrier.Text, lblLotID.Text)
                            Call pubVsfInfo_Disp(pstrDMsg)
                        Else
                            '@部分払出の場合
                        
                            '@ﾒｯｾｰｼﾞ表示："<TRM70I>$$在庫払出をしました。移載を行って下さい。キャリア[%1] ロット[%2]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0070, lblCarrier.Text, lblLotID.Text)
                            Call pubVsfInfo_Disp(pstrDMsg)
                            
                            '@ﾒｯｾｰｼﾞﾎﾞｯｸｽにてﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        End If
                        
                        
                    '@〓 完成在庫Tab 〓
                    Case CMlngFinishTab
                    
                        '@在庫WFﾘｽﾄ取得時のWF枚数と払出登録WF枚数が同じか
                        If mlngWFNum = llngWFNum Then
                            '@全数払出の場合
                            
                            '@ﾒｯｾｰｼﾞ表示："<TRM3SI>$$在庫払出を行い、ロット終了しました。キャリア[%1] ロット[%2]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003S, lblCarrier.Text, lblLotID.Text)
                            Call pubVsfInfo_Disp(pstrDMsg)
                        Else
                            '@部分払出の場合
                            
                            '@ﾒｯｾｰｼﾞ表示："<TRM70I>$$ 在庫払出をしました。移載を行って下さい。キャリア[%1] ロット[%2]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0070, lblCarrier.Text, lblLotID.Text)
                            Call pubVsfInfo_Disp(pstrDMsg)
                            
                            '@ﾒｯｾｰｼﾞﾎﾞｯｸｽにてﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        End If
                End Select
                
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                Call cmdClose_Click(cmdClose, New EventArgs)
                
            Else
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                Exit Sub
            End If

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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:16:50 N.Kasai
    '更新日：2008/05/02 (Fri) 13:06:53 N.Kojima
    '備　考：
    '　　　：2008/05/02 (Fri) 13:06:53 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@∇∇∇∇∇∇∇∇∇∇∇
            '@　ｱﾝﾛｰﾄﾞ処理
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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvFrmxxEN00F2_Init
    '機　能：画面の初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:35:43 N.Kasai
    '更新日：2005/01/06 (Thu) 17:08:01 H.Wajima
    '備　考：2005/01/06 (Thu) 17:08:01 H.Wajima  ｺﾝﾎﾞのﾌｫﾝﾄ名の設定処理を追加
    Private Sub prvFrmxxEN00F2_Init()

        Dim ltypInvWaferList        As InvWaferList     '在庫WFﾘｽﾄ格納構造体初期化用
        Dim ltypMasItemList         As MasItemList      '在庫WFﾘｽﾄ格納構造体初期化用

        Try
            
            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrLastUpdate = vbNullString           '最終更新日時格納用
            mlngWFNum = 0                           '在庫WFﾘｽﾄ取得時のWF枚数
            mstrFirstSlotNo = vbNullString          '有効WFｽﾛｯﾄ№(Min)
            
            '@各種ﾓｼﾞｭｰﾙ構造体の初期化
            mtypInvWaferList = ltypInvWaferList     '在庫WFﾘｽﾄ格納構造体
            mtypMasItemList = ltypMasItemList       '理由ｺｰﾄﾞ格納構造体
            
            '@各種ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False               '確定ﾎﾞﾀﾝ：無効
            
            '@各種ﾗﾍﾞﾙの初期化
            lblCarrier.Text = vbNullString       'ｷｬﾘｱID
            lblLotID.Text = vbNullString         'ﾛｯﾄID
            lblFlowClass.Text = vbNullString     '流動区分
            
            '@=======================
            '@　WFｽﾛｯﾄﾏｯﾌﾟの初期化処理
            '@=======================
            Call prvvsfSlotMap_init()
            
            '@閉じるﾎﾞﾀﾝ押下時に各種ｺﾝﾄﾛｰﾙのValidateｲﾍﾞﾝﾄを実行しないようにする
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00F2_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN00F2_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 17:20:55 N.Kasai
    '更新日：2008/05/02 (Fri) 14:24:06 N.Kojima
    '備　考：
    '　　　：2008/05/02 (Fri) 14:24:06 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvFrmxxEN00F2_Disp()

        Try
            
            '@引継ぎ情報構造体からﾃﾞｰﾀをｾｯﾄする
            With ptypHoldConnect
            
                lblCarrier.Text = .strCarrierId              'ｷｬﾘｱID
                lblLotID.Text = .strLotID                    'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass            '流動区分
                
                mstrLastUpdate = .strLastUpdate                 '最終更新日時
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00F2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbExpendList_Disp
    '機　能：払出理由ｺﾝﾎﾞ初期化＆作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/06 (Wed) 14:25:22 S.Deguchi
    '更新日：2008/05/02 (Fri) 14:25:40 N.Kojima
    '備　考：
    '　　　：2008/05/02 (Fri) 14:25:40 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvCmbExpendList_Disp()

        Dim llngCnt             As Integer          '汎用ｶｳﾝﾝﾀ

        Try

            With cmbExpend
            
                '@ﾌﾟﾛﾊﾟﾃｨの初期設定
                .Clear
                .DispCols = CMlngCmbDispCols                                        'ｺﾝﾎﾞ表示列数
                .GetCol = CMlngCmbGridColExpendName                                 'ﾃｷｽﾄ(払出理由)表示列
                .ValueCol = CMlngCmbGridColExpendID                                 '値(払出理由ID)取得列
                .DirectInput = False                                                '直接入力禁止
                .Text = vbNullString                                                'ﾃｷｽﾄ初期化
                .Font = New Font(.Font.Name, Ctype(CMlngCmbFontSize, Single))                   'ﾌｫﾝﾄｻｲｽﾞ
                .Font = New Font(CMstrCmbFontName, .Font.Size)                                  'ﾌｫﾝﾄ名
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single))           'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(CMstrCmbFontName, .Font.Size)                              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄ名
                .RowHeight = CMlngCmbRowHeight                                      '行の高さ
                .ColAlignment(CMlngCmbGridColExpendName) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@払出理由ｺﾝﾎﾞの内容作成
                For llngCnt = 0 To mtypMasItemList.lngListCnt - 1
                
                    '@払出名称/払出ID
                    .AddItem(mtypMasItemList.typeMasItem(llngCnt).strItemName & _
                             vbTab & _
                             mtypMasItemList.typeMasItem(llngCnt).strItemID)
                Next llngCnt
                
                '@払出理由が1件か
                If .ListCount = 1 Then
                    '@1件目をﾃﾞﾌｫﾙﾄ表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbExpendList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Init
    '機　能：WFｽﾛｯﾄﾏｯﾌﾟの初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:35:43 N.Kasai
    '更新日：2008/05/02 (Fri) 14:29:50 N.Kojima
    '備　考：
    '　　　：2004/10/12 (Tue) 11:16:05 N.Kasai      ﾁｪｯｸﾎﾞｯｸｽはprvvsfSlotMap_Dispで制御
    '　　　：2008/05/02 (Fri) 14:29:50 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvvsfSlotMap_init()

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try


            With vsfSlotMap
                .Clear(ClearFlags.Content)                  'ｸﾘｱ
                .SelectionMode = SelectionModeEnum.Row      '選択ﾓｰﾄﾞ：行単位
                                                            '範囲選択は不可
                .ExtendLastCol = True                       '最終列幅自動調整を行なう
                .AllowEditing = False                       '編集は不可
                
                .Rows.Count = CMlngvsfSlotMapRows           '行数：26
                .BackColor = Color.White                    'ｾﾙ背景色：白
                
                '@ﾀｲﾄﾙ行の基本設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfSlotMapRowTitle, CMlngvsfSlotMapColSlot, CMlngvsfSlotMapRowTitle, CMlngvsfSlotMapColClass) '表題
                Dim lFixedStyle As CellStyle = .Styles.Add("lFixedStyle")
                lFixedStyle.ForeColor = Color.Yellow                                                                                '文字色
                lFixedStyle.BackColor = Color.Navy                                                                                  '背景色
                lFixedStyle.Font = New Font(.Font.Name, CMlngvsfSlotMapHFontSize, .Font.Style)                                      'ﾌｫﾝﾄｻｲｽﾞ
                cellRange.Style = lFixedStyle
                .Rows(CMlngvsfSlotMapRowTitle).Height = CMlngvsfSlotMapHHeight    '高さ
                
                '@ｽﾛｯﾄ№設定
                For llngCnt = 0 To CMlngvsfSlotMapRows - 1
                
                    .SetData(llngCnt, CMlngvsfSlotMapColSlot, _
                        CStr(Format$(CMlngvsfSlotMapRows - llngCnt, CPstrSlotNoFormat)))
                    
                    .Rows(llngCnt).Height = CMlngvsfSlotMapHeight
                Next llngCnt

                '@ﾃﾞｰﾀ行の列幅、ﾀｲﾄﾙ設定
                '@ｽﾛｯﾄ№
                .Cols(CMlngvsfSlotMapColSlot).Width = CMlngvsfSlotMapColWSlot                           '列幅
                .SetData(CMlngvsfSlotMapRowTitle, CMlngvsfSlotMapColSlot, CMstrvsfSlotMapColTSlot)      'ﾀｲﾄﾙ
                
                '@WFID
                .Cols(CMlngvsfSlotMapColWFID).Width = CMlngvsfSlotMapColWWFID                           '列幅
                .SetData(CMlngvsfSlotMapRowTitle, CMlngvsfSlotMapColWFID, CMstrvsfSlotMapColTWFID)      'ﾀｲﾄﾙ
                
                '@↓2019/10/03 (Thu) 17:16:10 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@GRB
                .Cols(CMlngvsfSlotMapColGRB).Width = CMlngvsfSlotMapColWGRB
                .SetData(CMlngvsfSlotMapRowTitle, CMlngvsfSlotMapColGRB, CMstrvsfSlotMapColTGRB)
        
                '@ClassID
                .Cols(CMlngvsfSlotMapColClassID).Width = CMlngvsfSlotMapColWClassID
                .SetData(CMlngvsfSlotMapRowTitle, CMlngvsfSlotMapColClassID, CMstrvsfSlotMapColTClassID)
                '@↑2019/10/03 (Thu) 17:16:10 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@状態
                .Cols(CMlngvsfSlotMapColClass).Width = CMlngvsfSlotMapColWClass                         '列幅
                .SetData(CMlngvsfSlotMapRowTitle, CMlngvsfSlotMapColClass, CMstrvsfSlotMapColTClass)    'ﾀｲﾄﾙ
                
                '@表示位置設定
                .Cols(CMlngvsfSlotMapColSlot).TextAlign = TextAlignEnum.RightCenter        'ｽﾛｯﾄ№
                .Cols(CMlngvsfSlotMapColWFID).TextAlign = TextAlignEnum.LeftCenter         'WFID
                '@↓2019/10/03 (Thu) 17:17:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfSlotMapColGRB).TextAlign = TextAlignEnum.LeftCenter          'GRB
                '@↑2019/10/03 (Thu) 17:17:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfSlotMapColClass).TextAlign = TextAlignEnum.LeftCenter        '区分
                .Cols(CMlngvsfSlotMapColClassID).TextAlign = TextAlignEnum.LeftCenter      '区分ID

                '@↓2019/10/03 (Thu) 16:57:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
                '@非表示設定
                .Cols(CMlngvsfSlotMapColClassID).Visible = False

                .AutoSizeCol(CMlngvsfSlotMapColGRB)
                .AutoSizeCol(CMlngvsfSlotMapColClass)
                '@↑2019/10/03 (Thu) 16:57:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                '@WFｽﾛｯﾄﾏｯﾌﾟを無効にする
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfSlotMap_Disp
    '機　能：WFｽﾛｯﾄﾏｯﾌﾟの表示処理
    '引　数：ltypInvWaferList   ：取得構造体
    '戻り値：なし
    '作成日：2004/07/05 (Mon) 12:06:33 S.Deguchi
    '更新日：2008/05/02 (Fri) 14:34:19 N.Kojima
    '備　考：
    '　　　：2004/10/12 (Tue) 11:10:16 N.Kasai      ｽﾛｯﾄｻｲｽﾞ分のﾁｪｯｸﾎﾞｯｸｽを表示するよう対応
    '　　　：2004/10/19 (Tue) 13:42:48 N.Kasai      mlngWfNum追加(確定時払出し数量と比較する為)
    '　　　：2004/10/26 (Tue) 10:56:26 Y.Yamagishi  最大ｽﾛｯﾄ数を越えたｾﾙのﾊﾞｯｸｶﾗｰを薄いｸﾞﾚｰに変更
    '　　　：                                   　  最大ｽﾛｯﾄ数以内のWFの存在しないｾﾙのﾊﾞｯｸｶﾗｰをｸﾞﾚｰに変更
    '　　　：2004/12/16 (Thu) 11:41:22 H.Wajima     受入在庫/完成在庫の判定を確定ﾎﾞﾀﾝ押下時に行うよう変更
    '　　　：2008/05/02 (Fri) 14:34:19 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvVsfSlotMap_Disp(ByRef ltypInvWaferList As InvWaferList)

        Dim llngCnt         As Integer  'ｶｳﾝﾄ(=1:固定)
        Dim llngLoopCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngWriteRow    As Integer  '書き込み行

        Try

            With vsfSlotMap
                
                '@描画をﾛｯｸする(最後に一斉描画)
                .Redraw = False
                
                '@在庫WFﾘｽﾄにﾃﾞｰﾀが存在するか
                If ltypInvWaferList.lngInvWaferListCnt > 0 Then
                    '@ﾃﾞｰﾀがある場合
                
                    '@ﾃﾞｰﾀ数を退避
                    llngCnt = ltypInvWaferList.lngInvWaferListCnt
                    
                    '@ﾃﾞｰﾀ数(在庫WFﾘｽﾄ取得時のWF枚数)を格納(確定ﾎﾞﾀﾝ押下時に払出数量と比較するのに使用)
                    mlngWFNum = ltypInvWaferList.lngInvWaferListCnt
                    
                    
                    '@-----------------------
                    '@　ﾃﾞｰﾀ行の初期化＆背景色設定
                    '@-----------------------
                    '@引継ぎ情報のｽﾛｯﾄｻｲｽﾞが数値か
                    If IsNumeric(ptypHoldConnect.strSlotSize) = True Then
                    
                        '@ｽﾛｯﾄｻｲｽﾞ以上のｽﾛｯﾄ№を空白に、背景色を灰色(ﾎﾞﾀﾝの表面の色)に変更(初期化)
                        For llngCnt = 1 To CMlngvsfSlotMapRows - 1
                            
                            '@ｶｳﾝﾀがｽﾛｯﾄｻｲｽﾞ以下か
                            If llngCnt <= CMlngvsfSlotMapRows - CLng(ptypHoldConnect.strSlotSize) - 1 Then
                                '@ｽﾛｯﾄｻｲｽﾞ以下の場合は、ﾃﾞｰﾀ行(WFが入っている可能性がある行)
                            
                                .SetData(llngCnt, CMlngvsfSlotMapColSlot, vbNullString)               'ｽﾛｯﾄ№
                                .SetData(llngCnt, CMlngvsfSlotMapColCheck, vbNullString)              'ﾁｪｯｸ
                                
                                '@各種列の背景色をｸﾞﾚｰに設定
                                '@↓2019/10/03 (Thu) 17:17:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace")
                                newStyle1.BackColor = vbButtonFace
                                Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColCheck, llngCnt, CMlngvsfSlotMapColClass)
                                cellRange1.Style = newStyle1       
                                '@↑2019/10/03 (Thu) 17:17:34 Y.Yoneyama 「.Netへ反映未」 **************************************************

                            Else
                                '@ｽﾛｯﾄｻｲｽﾞ以上の場合は、非ﾃﾞｰﾀ行(WFが入っている可能性はない行)
                                
                                .SetData(llngCnt, CMlngvsfSlotMapColCheck, vbNullString)
                                
                                '@各種列の背景色を濃いｸﾞﾚｰに設定
                                '@↓2019/10/03 (Thu) 17:17:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                                newStyle1.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngGridDarkGray)
                                Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColCheck, llngCnt, CMlngvsfSlotMapColClass)
                                cellRange1.Style = newStyle1    'ﾁｪｯｸ
                                '@↑2019/10/03 (Thu) 17:17:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            End If
                        Next
                    End If
                    
                    
                    '@-----------------------
                    '@　ﾃﾞｰﾀ設定
                    '@-----------------------
                    '@WF情報の設定
                    For llngLoopCnt = 0 To ltypInvWaferList.lngInvWaferListCnt -1
                        
                        '@ﾃﾞｰﾀ設定行の設定(ｽﾛｯﾄ№01から書き込む)
                        llngWriteRow = CMlngvsfSlotMapRows - CLng(ltypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition)
                        
                        .SetCellCheck(llngWriteRow, CMlngvsfSlotMapColCheck, CheckEnum.Unchecked)     'ﾁｪｯｸ：未ﾁｪｯｸ
                        
                        .SetData(llngWriteRow, CMlngvsfSlotMapColWFID, _
                            ltypInvWaferList.typInvWaferList(llngLoopCnt).strWfId)                       'WFID

                        '@↓2019/10/03 (Thu) 17:20:19 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(llngWriteRow, CMlngvsfSlotMapColGRB, _
                            ltypInvWaferList.typInvWaferList(llngLoopCnt).strGRBClass)                   'GRB
                        '@↑2019/10/03 (Thu) 17:20:19 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            
                        .SetData(llngWriteRow, CMlngvsfSlotMapColClassID, _
                            ltypInvWaferList.typInvWaferList(llngLoopCnt).strWFStatusID)                 '区分ID(1、2、3etc...)
                            
                        .SetData(llngWriteRow, CMlngvsfSlotMapColClass, _
                            ltypInvWaferList.typInvWaferList(llngLoopCnt).strWFStatus)                   '区分(良品、不良etc...)
                        
                        '@背景色変更
                        '@↓2019/10/03 (Thu) 17:17:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = .GetCellRange(llngWriteRow, CMlngvsfSlotMapColCheck, llngWriteRow, CMlngvsfSlotMapColClass)
                        cellRange.Style = newStyle           
                
                        '@GRB背景色
                        Dim newStyleGRB As CellStyle = .Styles.Add("CustomStyle_BackColor_GRB" + llngWriteRow.ToString)
                        newStyleGRB.BackColor = pubGRBBackColor(ltypInvWaferList.typInvWaferList(llngLoopCnt).strGRBClass, Color.White)
                        Dim cellRangeGRB As CellRange = .GetCellRange(llngWriteRow, CMlngvsfSlotMapColGRB, llngWriteRow, CMlngvsfSlotMapColGRB)
                        cellRangeGRB.Style = newStyleGRB 
                        '@↑2019/10/03 (Thu) 17:17:34 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@1回目のﾙｰﾌﾟか
                        If llngLoopCnt = 0 Then
                        
                            '@1回目ﾙｰﾌﾟ処理ﾃﾞｰﾀのｽﾛｯﾄ№を退避
                            mstrFirstSlotNo = ltypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition
                        Else
                            '@2回目以降
                        
                            '@1回目に格納したｽﾛｯﾄ№が、現在ﾙｰﾌﾟ中の格納ﾃﾞｰﾀのｽﾛｯﾄ№より大きいか
                            If CLng(mstrFirstSlotNo) > CLng(ltypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition) Then
                                
                                '@現在ﾙｰﾌﾟ処理ﾃﾞｰﾀのｽﾛｯﾄ№で再格納(結局、一番若いｽﾛｯﾄ№にﾌｫｰｶｽをｾｯﾄしたい為)
                                mstrFirstSlotNo = ltypInvWaferList.typInvWaferList(llngLoopCnt).strSlotPosition
                            End If
                        End If
                    Next llngLoopCnt
                End If
                
                '@↓2019/10/03 (Thu) 16:57:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .AutoSizeCol(CMlngvsfSlotMapColClass)
                '@↑2019/10/03 (Thu) 16:57:28 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@描画する
                .Redraw = True
                
                '@WFｽﾛｯﾄﾏｯﾌﾟを無効にする
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCheckBoxControl_Proc
    '機　能：WFｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸﾎﾞｯｸｽ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 17:20:15 N.Kasai
    '更新日：2008/05/02 (Fri) 15:11:55 N.Kojima
    '備　考：
    '　　　：2004/10/12 (Tue) 11:13:43 N.Kasai      ｽﾛｯﾄｻｲｽﾞ以外の行はﾁｪｯｸさせない
    '　　　：2008/05/02 (Fri) 15:11:55 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvCheckBoxControl_Proc()

        Dim lblnAns     As Boolean      '汎用戻り値

        Try

            With vsfSlotMap
            
                '@ｽﾛｯﾄｻｲｽﾞ以外の行は処理しない
                If .GetCellRange(.Row, CMlngvsfSlotMapColCheck).StyleDisplay.BackColor = System.Drawing.ColorTranslator.FromWin32(CPlngGridDarkGray) Then
                    Exit Sub
                End If
            
                '@WFIDがNULL以外か
                If .GetData(.Row, CMlngvsfSlotMapColWFID) <> vbNullString Then
                    '@WFIDがNULL以外
                    
                    '@現在の状態が"未ﾁｪｯｸ"か
                    If .GetCellCheck(.Row, CMlngvsfSlotMapColCheck) = CheckEnum.Unchecked Then
                        '@未ﾁｪｯｸ→ﾁｪｯｸにする
                        .AllowEditing = True
                        .SetCellCheck(.Row, CMlngvsfSlotMapColCheck, CheckEnum.Checked)       'ﾁｪｯｸ
                        .AllowEditing = False
                    Else
                        '@ﾁｪｯｸ→未ﾁｪｯｸにする
                        .AllowEditing = True
                        .SetCellCheck(.Row, CMlngvsfSlotMapColCheck, CheckEnum.Unchecked)     '未ﾁｪｯｸ
                        .AllowEditing = False
                    End If
                Else
                    '@WFIDがNULLの場合
                
                    '@ﾁｪｯｸ→未ﾁｪｯｸにする
                    .AllowEditing = True
                    .SetCellCheck(.Row, CMlngvsfSlotMapColCheck, CheckEnum.Unchecked)         '未ﾁｪｯｸ解除
                    .AllowEditing = False
                End If
            End With
            
            '@=======================
            '@　入力ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnInput_Chk
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            Else
                '@結果：正常の場合
                
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCheckBoxControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：入力ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:35:43 N.Kasai
    '更新日：2008/05/02 (Fri) 13:23:06 N.Kojima
    '備　考：
    '　　　：2008/05/02 (Fri) 13:23:06 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Function prvblnInput_Chk() As Boolean

        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ

        Try
            
            '@戻り値の初期化
            prvblnInput_Chk = False
            
            '@-----------------------
            '@　払出理由のﾁｪｯｸ
            '@-----------------------
            '@払出理由がNULLか
            If cmbExpend.Text = vbNullString Then
                Exit Function
            End If
            
            '@-----------------------
            '@　WFｽﾛｯﾄﾏｯﾌﾟのﾁｪｯｸ
            '@-----------------------
            With vsfSlotMap
            
                For llngCnt = 0 To .Rows.Count - 1
                    
                    '@ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸされているか
                    If .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) = CheckEnum.Checked Then
                        '@ﾁｪｯｸされている場合
                        
                        '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄし、処理終了
                        prvblnInput_Chk = True
                        Exit For
                    End If
                Next llngCnt
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2008/05/01 (Thu) 11:43:50 N.Kojima **************************************************
    '関数名：prvblnRegistAuthority_Chk
    '機　能：払出権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True:成功、False:失敗
    '作成日：2008/04/22 (Tue) 15:18:39 N.Kojima
    '更新日：2008/04/22 (Tue) 15:18:39
    '備　考：
    Private Function prvblnRegistAuthority_Chk() As Boolean
        
        Dim lstrFunctionID          As String       '機能ID
        Dim lstrActionID            As String       'ｱｸｼｮﾝID
        Dim lstrWkEmpID             As String       '作業者ID(退避用)
        Dim lstrEmpName             As String       '作業者名
        Dim lblnAuthorityCheckFlag  As Boolean      '権限ﾁｪｯｸ制御ﾌﾗｸﾞ(True：権限ﾁｪｯｸを行なう、Flase：権限ﾁｪｯｸを行なわない)
        Dim lblnAns                 As Boolean      '戻り値格納用

        Try
            
            '@戻り値を初期化する
            prvblnRegistAuthority_Chk = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Function
            End If
            
            '@作業者IDを退避
            lstrWkEmpID = pstrUserID
            
            '@***************************
            '@　権限ﾁｪｯｸが必要か判定する
            '@***************************
            '@★ 所属ｸﾞﾙｰﾌﾟIDにより処理分岐 ★
            Select Case pstrGroupID
            
                '@〓 STAFF(技術) 〓
                Case CPstrDeptIDStaff
                
                    '@権限ﾁｪｯｸなし
            
            
                '@〓 LINE(製造) or その他(現在はSYSTEMのみ) 〓
                Case Else

                    '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
                    lblnAuthorityCheckFlag = True
                    
            End Select
                    
            '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
            If lblnAuthorityCheckFlag = True Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾊﾟｽﾜｰﾄﾞ付き作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                With frmxxCM0020.Instance
                    .txtUserID.Text = lstrWkEmpID
                    .txtUserID.Enabled = False
                    Call .ShowDialog
                End With
                frmxxCM0020.Instance = Nothing
                
                '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                If pblnCancel = True Then
                    Exit Function
                End If
                
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN00F0             '機能ID：EN00F0(在庫管理)
                lstrActionID = CPstrWFStatusChange          'ｱｸｼｮﾝID：不良/払出
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名：NULL
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                
                '@=======================
                '@　実行権限ﾁｪｯｸ処理
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           pstrUserID, _
                                           lstrEmpName, _
                                           pstrSBID)

                '@通信結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
            
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    Exit Function
                End If
            Else
                '@権限ﾁｪｯｸを行なわない場合
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            End If

            '@戻り値に"True:権限ﾁｪｯｸOK"をｾｯﾄ
            prvblnRegistAuthority_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegistAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2008/05/01 (Thu) 11:43:50 N.Kojima **************************************************



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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFrame.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSlotMap.BeforeDoubleClick

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

    '関数名：flex_SetupEditor
    '機　能：グリッド内コンボボックス表示行数調整
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/11/14 (Thu) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSlotMap.SetupEditor

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

End Class
