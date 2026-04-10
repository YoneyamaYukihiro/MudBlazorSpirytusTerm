'ﾌｧｲﾙ名：xxCM00O0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：パレット情報
'作成日：2004/10/06 (Wed) 11:32:38 N.Kojima
'更新日：008/04/08 (Tue) 14:54:38 T.Sawaguchi
'備　考：2008/04/08 (Tue) 14:54:38 T.Sawaguchi  案件No02762　ｽﾛｯﾄ表示を逆にする
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00O0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00O0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00O0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00O0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00O0)
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
    '======================================Private==========================================
    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyCM00O0  'ﾛｰｶﾙ機能ID

    '@vsfCfParetteListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfCfParetteListColNo                As Integer = 0              '№
    Private Const CMlngvsfCfParetteListColParetteID         As Integer = 1              'ﾊﾟﾚｯﾄID
    Private Const CMlngvsfCfParetteListColChipQuantity      As Integer = 2              '枚数(ﾁｯﾌﾟ)
    Private Const CMlngvsfCfParetteListColThicknessCode     As Integer = 3              '板厚
    Private Const CMlngvsfCfParetteListColReworkCnt         As Integer = 4              'ﾘﾜｰｸ回数
    Private Const CMlngvsfCfParetteListColProductionLotID   As Integer = 5              '製造ﾛｯﾄID
    Private Const CMlngvsfCfParetteListColShippingLotID     As Integer = 6              '出荷ﾛｯﾄID

    '@vsfCfParetteListの定数宣言（表示幅）
    Private Const CMlngvsfCfParetteListColWNo               As Integer = 29             '№
    Private Const CMlngvsfCfParetteListColWParetteID        As Integer = 137            'ﾊﾟﾚｯﾄID
    Private Const CMlngvsfCfParetteListColWChipQuantity     As Integer = 72             '枚数
    Private Const CMlngvsfCfParetteListColWThicknessCode    As Integer = 44             '板厚
    Private Const CMlngvsfCfParetteListColWReworkCnt        As Integer = 44             'ﾘﾜｰｸ回数
    Private Const CMlngvsfCfParetteListColWProductionLotID  As Integer = 144            '製造ﾛｯﾄID
    Private Const CMlngvsfCfParetteListColWShippingLotID    As Integer = 144            '出荷ﾛｯﾄID

    Private Const CMlngvsfCfParetteListColm                 As Integer = 7              'ｶﾗﾑ数
    Private Const CMlngvsfCfParetteListTRow                 As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMlngvsfCfParetteListRows                 As Integer = 19             '行数
    Private Const CMlngvsfCfParetteListHFontSize            As Integer = 12             'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfCfParetteListRowHeight            As Integer = 27             '行の高さ（ﾍｯﾀﾞｰのみ）
    Private Const CMlngvsfCfParetteListHeight               As Integer = 24             '行の高さ
    Private Const CMlngvsfCfParetteListAll                  As Integer = -1             '表全体

    '@vsfCfParetteListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfCfParetteListColTNo               As String = " №"           '№
    Private Const CMstrvsfCfParetteListColTParetteID        As String = "パレットID"     'ﾊﾟﾚｯﾄID
    Private Const CMstrvsfCfParetteListColTChipQuantity     As String = "枚数"          '枚数
    Private Const CMstrvsfCfParetteListColTThicknessCode    As String = "板厚"          '板厚
    Private Const CMstrvsfCfParetteListColTReworkCnt        As String = "RW"            'ﾘﾜｰｸ回数
    Private Const CMstrvsfCfParetteListColTProductionLotID  As String = "製造ロットID"   '製造ﾛｯﾄID
    Private Const CMstrvsfCfParetteListColTShippingLotID    As String = "出荷ロットID"   '出荷ﾛｯﾄID

    '@その他
    Private Const CMstrZero                                 As String = "0"             'ｾﾞﾛ
    Private Const CmlngNineTeen                             As Integer = 19             '19
    Private Const CmlngMinusOne                             As Integer = -1             '-1
    Private Const CmlngNine                                 As Integer = 9              '9

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_cfkilotinfoVer                   As String = "01.02"         'CFKIﾛｯﾄ情報取得

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================

    Private buttonProcessing                                As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                 As Boolean                  'NSYS WindowCloseフラグ

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
    '作成日：2004/10/06 (Wed) 13:29:34 N.Kojima
    '更新日：2004/10/06 (Wed) 13:29:34
    '備　考：
    Private Sub Form_Load()
        
        Dim ltypLotCfkiLotInfo      As LotCfkiLotinfo   'CFKIﾛｯﾄ情報格納構造体
        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrFormName            As String           'ﾌｫｰﾑ名
        Dim lstrEventName           As String           'ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名

        Try
                
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
                
            '@画面の初期化
            Call prvfrmxxCM00O0_Init()
            
            '@ﾌｫｰﾑ名格納
            lstrFormName = Me.Name
            
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@CFKIﾛｯﾄ情報の取得
            lblnAns = pubblnLotCfkilotinfo_Sel(CMstrlot_cfkilotinfoVer, _
                                               pstrCarrierID, _
                                               ltypLotCfkiLotInfo)
            '@結果確認
            If lblnAns = True Then
            '@成功の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@該当ﾃﾞｰﾀがなかった場合
                If ltypLotCfkiLotInfo.lngMetalPaletteMapListCnt = 0 Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Form_Loadﾌﾗｸﾞ（異常）
                    pblnFormLoad = False
                    
                    '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, CMstrZero)

                    '@publngMsgBoxInfo("メッセージコード：TRM29I$$該当件数 ： 0 件")
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                Else
                    '@取得OKなら結果表示
                    Call prvfrmxxCM00O0_Disp(ltypLotCfkiLotInfo)
            
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@Form_Loadﾌﾗｸﾞ（正常）
                    pblnFormLoad = True
                End If
            Else
            '@失敗の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
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
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/06 (Wed) 11:50:26 N.Kojima
    '更新日：2004/10/06 (Wed) 11:50:26
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
         
            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name
                '@その他の場合
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@次項目へｾｯﾄﾌｫｰｶｽ
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/10/06 (Wed) 13:26:43 N.Kojima
    '更新日：2004/10/06 (Wed) 13:26:43
    '備　考：
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

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 09:27:46 Y.Yamagishi
    '更新日：2004/06/02 (Wed) 09:27:46
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxCM00O0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/06 (Wed) 12:54:07 N.Kojima
    '更新日：2004/10/06 (Wed) 12:54:07
    '備　考：
    Private Sub prvfrmxxCM00O0_Init()

        Try
            
            '@閉じるﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfCfParetteList_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00O0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCfParetteList_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/06 (Wed) 12:54:52 N.Kojima
    '更新日：2004/10/22 (Fri) 20:17:40 N.Kojima
    '備　考：
    '　　　：2004/10/22 (Fri) 20:17:40 N.Kojima　製造ﾛｯﾄIDと出荷ﾛｯﾄID追加(不具合№43)
    Private Sub prvvsfCfParetteList_Init()

        Try
            
            With vsfCfParetteList
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@CFｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Rows.Count = 1
            
                '@ﾌｫﾝﾄの設定
                With .Font
                    vsfCfParetteList.Font = New Font(.FontFamily, CMlngvsfCfParetteListHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@行の高さ指定
                .Rows.DefaultSize = CMlngvsfCfParetteListHeight
                .Rows(0).Height = CMlngvsfCfParetteListRowHeight
                
                .Select(0, CMlngvsfCfParetteListColNo, _
                        .Rows.Fixed - 1, CMlngvsfCfParetteListColShippingLotID)
                
                '@見出し行の色設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngBlueColor_ForeColor_vbYellow")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                      '背景色：紺
                newStyle.ForeColor = Color.Yellow                                                   '文字色：黄色
                '@見出し行の文字位置設定：中央寄せ中央揃え
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                Dim cellRange As CellRange = .GetCellRange(0, CMlngvsfCfParetteListColNo, _
                                       .Rows.Fixed - 1, CMlngvsfCfParetteListColShippingLotID)
                cellRange.Style = newStyle
                
                '@列幅の設定
                .Cols(CMlngvsfCfParetteListColNo).Width = CMlngvsfCfParetteListColWNo
                .Cols(CMlngvsfCfParetteListColParetteID).Width = CMlngvsfCfParetteListColWParetteID
                .Cols(CMlngvsfCfParetteListColChipQuantity).Width = CMlngvsfCfParetteListColWChipQuantity
                .Cols(CMlngvsfCfParetteListColThicknessCode).Width = CMlngvsfCfParetteListColWThicknessCode
                .Cols(CMlngvsfCfParetteListColReworkCnt).Width = CMlngvsfCfParetteListColWReworkCnt
                .Cols(CMlngvsfCfParetteListColProductionLotID).Width = CMlngvsfCfParetteListColWProductionLotID
                .Cols(CMlngvsfCfParetteListColShippingLotID).Width = CMlngvsfCfParetteListColWShippingLotID
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCfParetteList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00O0_Disp
    '機　能：ｷｬﾘｱﾘｽﾄ表示
    '引　数：ltypLotCfkiLotInfo:CFKIﾛｯﾄ情格納構造体
    '戻り値：なし
    '作成日：2004/10/06 (Wed) 13:15:22 N.Kojima
    '更新日：2008/04/08 (Tue) 14:54:20 T.Sawaguchi
    '備　考：
    '　　　：2004/10/18 (Mon) 11:21:57 N.Kojima　   移載モードに従った表示に修正(不具合№792)
    '　　　：2004/10/22 (Fri) 20:16:20 N.Kojima　   製造ﾛｯﾄIDと出荷ﾛｯﾄID追加(不具合№43)
    '　　　：2004/11/17 (Wed) 15:03:39 H.Wajima     空ｽﾛｯﾄの背景色をｸﾞﾚｰにする(不具合№224)
    '　　　：2008/04/08 (Tue) 14:54:38 T.Sawaguchi  案件No02762　ｽﾛｯﾄ表示を逆にする
    Private Sub prvfrmxxCM00O0_Disp(ByRef ltypLotCfkiLotInfo As LotCfkiLotinfo)
        
        Dim llngCnt                     As Integer      'ｶｳﾝﾄ
        Dim llngRow                     As Integer      'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ

        Try
            
            With vsfCfParetteList
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@行数設定
                vsfCfParetteList.Rows.Count = CMlngvsfCfParetteListRows
                
                '@一旦、全てのｾﾙの背景色をｸﾞﾚｰにする
                With vsfCfParetteList
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                    Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfCfParetteListColParetteID, _
                                           .Rows.Count - 1, CMlngvsfCfParetteListColShippingLotID)
                    cellRange.Style = newStyle                                                      '背景色濃いｸﾞﾚｰ
                End With
                
                Dim lstrSlotNo As String
                lstrSlotNo = ""
                '@ﾃﾞｰﾀ表示
                For llngCnt = 0 To ltypLotCfkiLotInfo.lngMetalPaletteMapListCnt - 1
                    With ltypLotCfkiLotInfo.typMetalPaletteMapList(llngCnt)
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値の場合
                        If IsNumeric(.strSlotPosition) = True Then
        '@↓2008/04/08 (Tue) 14:27:20 T.Sawaguchi 案件02762**************************
                            'ｽﾛｯﾄをCFﾛｯﾄ編成と同じくする為に、ｽﾛｯﾄを算出する。
                            '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ格納
                            llngRow = (.strSlotPosition - CmlngNineTeen) * CmlngMinusOne
        '@↑2008/04/08 (Tue) 14:27:20 T.Sawaguchi 案件02762**************************
                            
                            '@ｸﾞﾘｯﾄの設定
                            vsfCfParetteList.SetData(llngRow, CMlngvsfCfParetteListColParetteID, .strPaletteID)                       'ﾊﾟﾚｯﾄID
                            vsfCfParetteList.SetData(llngRow, CMlngvsfCfParetteListColChipQuantity, .strChipCount)                    '枚数
                            vsfCfParetteList.SetData(llngRow, CMlngvsfCfParetteListColThicknessCode, .strThicknessCode)               '板厚
                            vsfCfParetteList.SetData(llngRow, CMlngvsfCfParetteListColReworkCnt, ltypLotCfkiLotInfo.strReworkCount)   'RW(ﾘﾜｰｸ回数)
                            vsfCfParetteList.SetData(llngRow, CMlngvsfCfParetteListColProductionLotID, .strProductionLotId)           '製造ﾛｯﾄID
                            vsfCfParetteList.SetData(llngRow, CMlngvsfCfParetteListColShippingLotID, .strShippingLotID)               '出荷ﾛｯﾄID
                            
                            '@ﾃﾞｰﾀが入っている行のｾﾙの背景色を白にする
                            Dim newStyle As CellStyle = vsfCfParetteList.Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = vsfCfParetteList.GetCellRange(llngRow, CMlngvsfCfParetteListColParetteID, _
                                                                   llngRow, CMlngvsfCfParetteListColShippingLotID)
                            cellRange.Style = newStyle                                                                                '背景色白
                        
                        End If
                    End With
                Next llngCnt
                
        '@↓2008/04/08 (Tue) 14:29:09 T.Sawaguchi 案件02762 **************************
                For llngCnt = 1 To CMlngvsfCfParetteListRows - 1
                    llngRow = (llngCnt - CmlngNineTeen) * CmlngMinusOne
                     '@NOを2桁でｾｯﾄする。
                    If llngRow <= CmlngNine Then
                        lstrSlotNo = "0" & LTrim(RTrim(str(llngRow)))
                    Else
                        lstrSlotNo = LTrim(RTrim(str(llngRow)))
                    End If
                    vsfCfParetteList.SetData(llngCnt, CMlngvsfCfParetteListColNo, lstrSlotNo)    '№
                Next llngCnt
        '@↑2008/04/08 (Tue) 14:29:09 T.Sawaguchi 案件02762 **************************
            
                '@描画ﾛｯｸ解除
                .Redraw = True
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00O0_Disp"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraParetteInfo.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
