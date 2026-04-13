'ﾌｧｲﾙ名：xxEN01X3.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：処理条件編集
'作成日：2006/06/21 (Wed) 10:42:15 N.Kasai
'更新日：2018/03/29 (Thu) 10:23:39 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01X3
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01X3    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01X3
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01X3
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01X3)
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
    '                                   * 定数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01X3      'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '@↓2008/10/14 (Tue) 16:58:51 M.Koni **************************************************
    Private Const CMstrprocwaferlistVer         As String = "02.00"             'ﾛｯﾄWF情報取得
    '@↑2008/10/14 (Tue) 16:58:51 M.Koni **************************************************
    Private Const CMstrmas_wplist__Ver          As String = "05.01"             '装置一覧取得
    Private Const CMstrmas_recipnamelistVer     As String = "01.01"             'ﾚｼﾋﾟ名一覧取得

    '@作業条件の最大ﾊﾞｲﾄ数
    Private Const CMlngOptionTextMaxByte        As Integer = 128

    '@ﾌｫｰﾑのﾀｲﾄﾙ
    Private Const CMstrFormTitle                As String = "処理条件編集"

    '@選択行の背景色
    Private Const CMlngBackColorSBlue           As Integer = &HFFFFC0           '水色

    '@使用ﾚｼﾋﾟｸﾞﾘｯﾄの列番号
    Private Const CMlngUseRecipeNoCol           As Integer = 0                  '№
    Private Const CMlngUseRecipeWPNameCol       As Integer = 1                  '装置名
    Private Const CMlngUseRecipeWFCol           As Integer = 2                  'WFID
    Private Const CMlngUseRecipeIDCol           As Integer = 3                  'ﾚｼﾋﾟID
    Private Const CMlngUseRecipeVerCol          As Integer = 4                  'ﾚｼﾋﾟVer
    Private Const CMlngUseRecipeWPIDCol         As Integer = 5                  'WPID
    Private Const CMlngUseRecipeCommentsCol     As Integer = 6                  'ｺﾒﾝﾄ

    '@装置ｸﾞﾘｯﾄﾞ
    Private Const CMlngUseWPNoCol               As Integer = 0                  '№
    Private Const CMlngUseWPCKCol               As Integer = 1                  'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngUseWPIDCol               As Integer = 2                  'WPID
    Private Const CMlngUseWPNameCol             As Integer = 3                  '装置名


    Private Const CMstrFlgOn                    As String = "1"                 'ﾌﾗｸﾞON
    Private Const CMstrFlgOff                   As String = "0"                 'ﾌﾗｸﾞOFF

    '@背景色
    Private Const CMlngBackColorGray            As Integer = &HE0E0E0           '灰色

    '@種別（1:ﾛｯﾄ工順変更、2:組立工順一時保存）
    Private Const CMstrClsLotProcessEdit        As String = "1"

    '@ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ
    Private Const CMstrLotRecipeFlag            As String = "1"                 '(0:枚葉ﾚｼﾋﾟ設定可 1:枚葉ﾚｼﾋﾟ設定不可 2:単一枚葉ﾚｼﾋﾟ）


    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow               As Integer = 2                  'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    ''@ｴﾗｰﾒｯｾｰｼﾞ
    'Private Const CMstrRecipeMSG                As String = "枚葉レシピ設定不可"
    'Private Const CMstrBatchMSG                 As String = "バッチ"

    '@ﾀﾌﾞｲﾝﾃﾞｯｸｽ
    Private Const CMlngCommonTab                As Integer = 0                  '装置共通ﾚｼﾋﾟﾀﾌﾞ
    Private Const CMlngOptionTab                As Integer = 1                  '装置個別ﾚｼﾋﾟﾀﾌﾞ

    '@ﾚｼﾋﾟｵﾌﾟｼｮﾝﾎﾞﾀﾝｲﾝﾃﾞｯｸｽ
    Private Const CMlngOptionLotOpt             As Integer = 0                  '装置個別ﾛｯﾄﾚｼﾋﾟｲﾝﾃﾞｸｽ
    Private Const CMlngOptionWfOpt              As Integer = 1                  '装置個別枚葉ﾚｼﾋﾟｲﾝﾃﾞｸｽ
    Private Const CMlngCommonLotOpt             As Integer = 2                  '装置共通ﾛｯﾄﾚｼﾋﾟｲﾝﾃﾞｸｽ
    Private Const CMlngCommonWfOpt              As Integer = 3                  '装置共通枚葉ﾚｼﾋﾟｲﾝﾃﾞｸｽ

    '@その他
    Private Const CMstrGridCombFirst            As String = " |"
    Private Const CMstrPipeString               As String = "|"                 'ﾊﾟｲﾌﾟ文字

    '@↓2008/10/14 (Tue) 17:10:42 M.Koni **************************************************
    '@WAFER_RECIPE_KIND定数宣言
    Private Const CMstrDoNotCare            As String = "0"     '指定してもしなくても可
    Private Const CMstrRequireWfRecipe      As String = "1"     '指定必須
    Private Const CMstrInvalidWfRecipe      As String = "2"     '指定不可
    '@↑2008/10/14 (Tue) 17:10:42 M.Koni **************************************************


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================

    '@ｽﾛｯﾄNo配列
    Private mstrWFID                            As List(Of String)

    '@使用ﾚｼﾋﾟ構造体
    Private Structure UseRecipe
        Dim lstrWPName                          As String                       '装置名
        Dim lstrWpId                            As String                       '装置ID
        Dim lstrRecipeID                        As String                       'ﾚｼﾋﾟID
        Dim lstrRecipeVer                       As String                       'ﾚｼﾋﾟVer
        Dim lstrComments                        As String                       'ﾚｼﾋﾟｺﾒﾝﾄ
    End Structure

    Private mlngOptRecipeFlag                   As Boolean                      'ﾚｼﾋﾟ成功ﾌﾗｸﾞ
    Private mblnFormLoadFlag                    As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞ中ﾌﾗｸﾞ（Ture:ﾌｫｰﾑﾛｰﾄﾞ中、False:ﾌｫｰﾑﾛｰﾄﾞ完了）

    '@装置一覧格納用
    Private mtypWpList                          As List(Of WpList)              '装置一覧格納用
    Private mlngWpListCnt                       As Integer                      '装置一覧件数

    Private mtypMasRecipeNameList               As List(Of MasRecipeNameList)   'ﾚｼﾋﾟ一覧格納用
    Private mlngRecipeNameListCnt               As Integer                      'ﾚｼﾋﾟ一覧件数

    '@ｳｴﾊ情報
    Private mtypProcWaferList                   As ProcWaferList                'ﾛｯﾄｳｴﾊ情報

    Private buttonProcessing                    As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                      'NSYS WindowCloseフラグ

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
    '                              * イベントハンドラの記述 *
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑのﾛｰﾄﾞ時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:46:26 N.Kasai
    '更新日：2006/07/12 (Wed) 11:46:26
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrWP                  As String               '装置
        Dim ltypMasRecipeNameList   As MasRecipeNameList    'ﾚｼﾋﾟﾘｽﾄ
        Dim llngRow                 As Integer              '行ｶｳﾝﾀ
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名格納（ﾚｽﾎﾟﾝｽ用）

        Try  
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "Form_Load"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@ﾌｫｰﾑﾛｰﾄﾞ中ﾌﾗｸﾞの設定（Ture:ﾌｫｰﾑﾛｰﾄﾞ中）
            mblnFormLoadFlag = True
            
            '@ﾌｫｰﾑの初期化
            Call prvfrmxxEN01X3_Init()

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@ﾌｫｰﾑへﾃﾞｰﾀ表示
            Call prvfrmxxEN01X3_Disp()
            
            '@MSG【装置情報取得】(CPstrCD1O：処理条件指定)
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                       mlngWpListCnt, _
                                       pstrSBID, _
                                       CPstrCD1O, , , _
                                       lblConditionId.Text, _
                                       lblVer.Text)
            '@結果判定
            If lblnAns = True Then
                '@成功の場合
                '@装置一覧情報の退避
                mtypWpList = ptypWPList
                
                '@枚葉ﾚｼﾋﾟ可能判定
                Call prvOptRecipeEnabled_Set()
            Else
                '@失敗の場合
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                Exit Sub
            End If
            
            With vsfUseWP

                mtypMasRecipeNameList = New List(Of MasRecipeNameList)
                For llngRow = 1 To .Rows.Count - 1
                    '@装置ID退避
                    lstrWP = .GetData(llngRow, CMlngUseWPIDCol)

                    '@MSG【ﾚｼﾋﾟ名一覧取得】
                    ltypMasRecipeNameList = New MasRecipeNameList
                    lblnAns = pubblnMasRecipeNameList_Sel(pstrSBID, _
                                                          CMstrmas_recipnamelistVer, _
                                                          vbNullString, _
                                                          lstrWP, _
                                                          vbNullString, _
                                                          ltypMasRecipeNameList)
                    '@結果判定
                    If lblnAns = True Then
                    '@成功の場合
                       
                        '@ﾚｼﾋﾟ一覧取得件数
                        mlngRecipeNameListCnt = llngRow
                        
                        '@ﾚｼﾋﾟﾘｽﾄの退避
                        mtypMasRecipeNameList.Add(ltypMasRecipeNameList)
                    
                        '@行追加ﾎﾞﾀﾝの判別
                        lblnAns = prvblnWPList_Chk
                        If lblnAns = True Then
                            '@行追加ﾎﾞﾀﾝを活性化
                            cmdRowAdd.Enabled = True
                        Else
                            '@行追加ﾎﾞﾀﾝを非活性化
                            cmdRowAdd.Enabled = False
                        End If
                    Else
                    '@失敗の場合
                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                        
                        Exit Sub
                    End If
                Next
            End With
            
            
            With frmxxEN01X2.Instance.vsfFlowList0
                '@処理条件が編集不可以外の場合(背景色がｸﾞﾚｰ)
                If .GetData(.Row, CPlngvsfFlowPermit) <> "2" Then
                    '@ﾛｯﾄｳｴﾊ情報取得に成功したら
                    If mlngOptRecipeFlag = True Then
                        
                        '@一覧にﾃﾞｰﾀ行が存在するか否かで判別
                        If vsfUseRecipe1.Rows.Count > 2 Then
                            cmdDelRecipe.Enabled = True
                        End If
                        
                        '@確定ﾎﾞﾀﾝﾁｪｯｸ
                        Call prvcmdUpdate_Chk()
                    End If
                End If
            End With

			'ﾀﾌﾞをオーナードローする
            stbRecipe.DrawMode = TabDrawMode.OwnerDrawFixed
            
            '@ﾌｫｰﾑﾛｰﾄﾞ中ﾌﾗｸﾞの完了（False:ﾌｫｰﾑﾛｰﾄﾞ完了）
            mblnFormLoadFlag = False

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    
    '関数名：StbRecipe_DrawItem
    '機　能：StbRecipeの描画ｲﾍﾞﾝﾄをﾊﾝﾄﾞﾙする
    '引　数：sender：ｲﾍﾞﾝﾄ発行元ｵﾌﾞｼﾞｪｸﾄ
    '　　　：e     ：DrawItemｲﾍﾞﾝﾄ引数
    '戻り値：なし
    Private Sub StbRecipe_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles stbRecipe.DrawItem

        Try
            '@対象のTabControlを取得
            Dim lTabControl As TabControl = CType(sender, TabControl)
            '@ﾀﾌﾞﾍﾟｰｼﾞのﾃｷｽﾄを取得
            Dim lstrTabText As String = lTabControl.TabPages(e.Index).Text

            '@書式の設定
            Dim lStringFormat As New StringFormat
            lStringFormat.Alignment = StringAlignment.Center
            lStringFormat.LineAlignment = StringAlignment.Center

            '@ﾀﾌﾞのﾃｷｽﾄと背景描画用のﾌﾞﾗｼ
            Dim lbrsForeBrush, lbrsBackBrush As SolidBrush

            '@装置共通ﾚｼﾋﾟ可能な場合
            If ptypMasCondDetailList.strWpCommonRecipeFlag = CMstrFlgOn Then

                '@ﾀﾌﾞの選択状態によって色付けを変更する
                If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                    '@選択中ﾀﾌﾞの場合
                    lbrsForeBrush = New SolidBrush(Color.Black)
                    lbrsBackBrush = New SolidBrush(Color.White)

                Else
                    '@選択されていないﾀﾌﾞの場合
                    lbrsForeBrush = New SolidBrush(Color.Black)
                    lbrsBackBrush = New SolidBrush(SystemColors.ButtonFace)

                End If
            Else
                '@どちらのﾀﾌﾞのDrawItemｲﾍﾞﾝﾄかによって色付けを変更する
                If e.Index = CMlngCommonTab Then
                    '@「装置共通ﾚｼﾋﾟ」ﾀﾌﾞは使用不可表示
                    lbrsForeBrush = New SolidBrush(Color.Gray)
                    lbrsBackBrush = New SolidBrush(SystemColors.ButtonFace)

                Else
                    '@「装置個別ﾚｼﾋﾟ」ﾀﾌﾞは使用可表示
                    lbrsForeBrush = New SolidBrush(Color.Black)
                    lbrsBackBrush = New SolidBrush(Color.White)

                End If
            End If

            '@背景の描画
            e.Graphics.FillRectangle(lbrsBackBrush, e.Bounds)
            '@ﾃｷｽﾄの描画
            e.Graphics.DrawString(lstrTabText, e.Font, lbrsForeBrush, RectangleF.op_Implicit(e.Bounds), lStringFormat)

            '@確保領域を開放
            lStringFormat.Dispose()
            lbrsForeBrush.Dispose()
            lbrsBackBrush.Dispose()

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "StbRecipe_DrawItem"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ｴﾝﾀｰで次項目に進む
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：未使用
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:44:41 N.Kasai
    '更新日：2006/06/21 (Wed) 15:44:41
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@砂時計の場合はキーボド入力を抑止します
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ｴﾝﾀｰでﾀﾌﾞと同じように進む
            If e.KeyCode = Keys.Return Then
                If ActiveControl IsNot vsfUseRecipe1.Editor And
                   ActiveControl IsNot vsfUseRecipe2.Editor And
                   ActiveControl IsNot vsfUseWP.Editor Then
                        SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
                End If

            'Deleteボタン
            ElseIf e.KeyCode = Keys.Delete Then 
                'コントロールが装置個別レシピのグリッド
                If ActiveControl.Name = "vsfUseRecipe1" Then
                    If vsfUseRecipe1.Col = CMlngUseRecipeIDCol Then
                        If vsfUseRecipe1.ComboList IsNot Nothing Then
                            'レシピクリア
                            If vsfUseRecipe1.ComboList.Contains(CPstrSpace) Then
                                vsfUseRecipe1.SetData(vsfUseRecipe1.Row, CMlngUseRecipeIDCol, CPstrSpace)
                            End If
                        End If
                    End If
                '共通レシピ
                ElseIf ActiveControl.Name = "vsfUseRecipe2" Then
                    If vsfUseRecipe2.Col = CMlngUseRecipeIDCol Then
                        If vsfUseRecipe2.ComboList IsNot Nothing Then
                            'レシピクリア
                            If vsfUseRecipe2.ComboList.Contains(CPstrSpace) Then
                                vsfUseRecipe2.SetData(vsfUseRecipe2.Row, CMlngUseRecipeIDCol, CPstrSpace)
                            End If
                        End If
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑのｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel    ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:46:06 N.Kasai
    '更新日：2006/06/21 (Wed) 15:46:06
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim llngMsgAns As Integer '戻り値

        Try

            
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            With frmxxEN01X2.Instance.vsfFlowList0
                '@処理条件が編集可能工程の場合
                If .GetData(.Row, CPlngvsfFlowPermit) = "2" Or _
                    pblnEdit = False Then
                    
                    '@画面を閉じる
                Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001I)
                    '@「ﾚｼﾋﾟを設定せずに終了してもよろしいですか？」ﾒｯｾｰｼﾞ表示
                    llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, CMstrFormTitle, True, 16, False)
                
                    '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                    Select Case llngMsgAns
                        Case vbYes      '「はい」を選択
                            '@画面を閉じる
                        Case vbNo       '「いいえ」を選択
                            e.Cancel = True
                            Exit Sub
                    End Select
                End If
            End With
            
            '@配列のｸﾘｱ
            If mstrWFID Isnot Nothing Then
                mstrWFID.Clear()
            End If
            If mtypWpList Isnot Nothing Then
                mtypWpList.Clear()
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUpdate_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:51:51 N.Kasai
    '更新日：2018/03/15 (Thu) 13:12:14 T.Oide
    '備　考：
    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
        
        Dim llngRow     As Integer  '行ｶｳﾝﾀ
        Dim lblnRtn     As Boolean  '汎用戻り値
        Dim llngCnt     As Integer  'ｶｳﾝﾀ
        Dim llngIndex   As Integer  'ｸﾞﾘｯﾄﾞｲﾝﾃﾞｯｸｽ
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2018/03/15 (Thu) 13:13:09 T.Oide **************************************************
            '@「ﾚｼﾋﾟ選択APC」削除ﾁｪｯｸ
            If pubRecpSelApcSettingDel_chk( _
                    frmxxEN01X2.Instance.vsfFlowList0.Row, CPstrParsonalCondition) = False Then
                '@ﾁｪｯｸ結果Falseなら処理中止
                Exit Sub
            End If
        '@↑2018/03/15 (Thu) 13:13:09 T.Oide **************************************************
            
            '@ﾚｼﾋﾟIDﾁｪｯｸ
            lblnRtn = False
            
            '@選択ﾀﾌﾞの判定
            If stbRecipe.SelectedIndex = CMlngOptionTab Then
                llngIndex = 1
            Else
                llngIndex = 2
            End If
            
            If llngIndex = 1 Then
                With vsfUseRecipe1
                    For llngCnt = 1 To .Rows.Count - 1
                        '@「＠レシピ」を検索
                        If .GetData(llngCnt, CMlngUseRecipeIDCol) = CPstrRecpNotID Then
                            lblnRtn = True
                            Exit For
                        End If
                    Next
                End With
            Else
                With vsfUseRecipe2
                    For llngCnt = 1 To .Rows.Count - 1
                        '@「＠レシピ」を検索
                        If .GetData(llngCnt, CMlngUseRecipeIDCol) = CPstrRecpNotID Then
                            lblnRtn = True
                            Exit For
                        End If
                    Next
                End With
            End If
            
            '@ｴﾗｰありの場合
            If lblnRtn = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008F, CMstrFormTitle)
                '@"<TRM8FW>$$個別処理条件の設定に未設定のレシピが存在します。$設定を見直してください。"
                Call publngMsgBox(pstrDMsg, vbExclamation, CMstrFormTitle, True, 16, False)
                Exit Sub
            End If

            
            '@枚葉ﾚｼﾋﾟ使用可否ﾁｪｯｸ
            Select Case stbRecipe.SelectedIndex
                '@装置共通
                Case CMlngCommonTab
                    If optRecipe3.Checked = True Then
                        '@枚葉ﾚｼﾋﾟ設定可能ﾁｪｯｸ
                        lblnRtn = prvblnWfRecipe_Chk(2)
                        If lblnRtn = False Then
                            Exit Sub
                        End If
                        '@枚葉ﾚｼﾋﾟ内容ﾁｪｯｸ
                        lblnRtn = prvblnRecipeBlank_Chk(2)
                        If lblnRtn = False Then
                            Exit Sub
                        End If
                    End If
                
                '@装置個別
                Case CMlngOptionTab
                    If optRecipe1.Checked = True Then
                        '@枚葉ﾚｼﾋﾟ設定可能ﾁｪｯｸ
                        lblnRtn = prvblnWfRecipe_Chk(1)
                        If lblnRtn = False Then
                            Exit Sub
                        End If
                        '@枚葉ﾚｼﾋﾟ内容ﾁｪｯｸ
                        lblnRtn = prvblnRecipeBlank_Chk(1)
                        If lblnRtn = False Then
                            Exit Sub
                        End If
                    End If
            End Select

            '@更新処理
            '@個別処理設定配列にﾃﾞｰﾀをｾｯﾄ
            Call prvAryConData_Set()
            
            '@//* ﾌﾟﾛｾｽ編集画面を編集 *//
            With frmxxEN01X2.Instance
                
                '@装置個別ﾚｼﾋﾟﾀﾌﾞが選択されている場合
                If stbRecipe.SelectedIndex = CMlngOptionTab Then
            
                    If optRecipe0.Checked = True Then
                    '@ﾛｯﾄﾚｼﾋﾟの場合
                        '@ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞｵﾝ
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowLotRecipeFlag, CMstrFlgOn)
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowWFRecipeFlag, CMstrFlgOff)
                        .vsfConditionList2.Cols(CPlngvsfConDetailListWFCol).Visible = False
                        
                        '@「個別」を表示（全数）
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowConditionOne, CPstrRecpAll)
                    Else
                    '@枚葉ﾚｼﾋﾟの場合
                        '@枚葉ﾚｼﾋﾟﾌﾗｸﾞｵﾝ
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowLotRecipeFlag, CMstrFlgOff)
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowWFRecipeFlag, CMstrFlgOn)
                        .vsfConditionList2.Cols(CPlngvsfConDetailListWFCol).Visible = True
                        
                        '@判定値初期化
                        lblnRtn = False
                        
                        '@ﾚｼﾋﾟIDを検索
                        For llngRow = 1 To vsfUseRecipe1.Rows.Count - 1
                            If Trim$(vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeIDCol)) = vbNullString Then
                                lblnRtn = True
                                Exit For
                            End If
                        Next
                        '@戻り値判定
                        If lblnRtn = True Then
                            '@「個別」を表示（部分）
                            .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowConditionOne, CPstrRecppartial)
                        Else
                             '@「個別」を表示（全数）
                            .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowConditionOne, CPstrRecpAll)
                        End If
                    End If
                Else
                     If optRecipe2.Checked = True Then
                    '@ﾛｯﾄﾚｼﾋﾟの場合
                        '@ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞｵﾝ
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowLotRecipeFlag, CMstrFlgOn)
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowWFRecipeFlag, CMstrFlgOff)
                        .vsfConditionList2.Cols(CPlngvsfConDetailListWFCol).Visible = False
                        
                        '@「個別」を表示（全数）
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowConditionOne, CPstrRecpAll)
                    Else
                    '@枚葉ﾚｼﾋﾟの場合
                        '@枚葉ﾚｼﾋﾟﾌﾗｸﾞｵﾝ
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowLotRecipeFlag, CMstrFlgOff)
                        .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowWFRecipeFlag, CMstrFlgOn)
                        .vsfConditionList2.Cols(CPlngvsfConDetailListWFCol).Visible = True
                        
                        '@判定値初期化
                        lblnRtn = False
                        
                        '@ﾚｼﾋﾟIDを検索
                        For llngRow = 1 To vsfUseRecipe2.Rows.Count - 1
                            If Trim$(vsfUseRecipe2.GetData(llngRow, CMlngUseRecipeIDCol)) = vbNullString Then
                                lblnRtn = True
                                Exit For
                            End If
                        Next
                        '@戻り値判定
                        If lblnRtn = True Then
                            '@「個別」を表示（部分）
                            .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowConditionOne, CPstrRecppartial)
                        Else
                             '@「個別」を表示（全数）
                            .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowConditionOne, CPstrRecpAll)
                        End If
                    End If
                End If
                

                Dim newStyle As CellStyle = .vsfFlowList0.Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                Dim cellRange As CellRange = .vsfFlowList0.GetCellRange(.vsfFlowList0.Row, CPlngvsfFlowConditionOne)
                '@ﾊﾞｯｸｶﾗｰを変更
                newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)

                '@文字色を変更
                newStyle.ForeColor = Color.Black
                cellRange.Style = newStyle
                
                '@工順ﾚｼﾋﾟ変更ﾌﾗｸﾞｵﾝ
                .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowRecipeChgFlg, CMstrFlgOn)
                .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowChange, CMstrFlgOn)           '変更区分（変更あり）
                  
                '@作業条件設定
                .vsfFlowList0.SetData(.vsfFlowList0.Row, CPlngvsfFlowWorkCondition, txtWorkCondition.Text)
                
                '@処理条件ｾｯﾄIDにﾌｫｰｶｽをｾｯﾄ
                .vsfFlowList0.Col = CPlngvsfFlowConditionID
                .vsfFlowList0.ShowCell(.vsfFlowList0.Row, CPlngvsfFlowConditionID)
                
                '@ﾌﾚｰﾑのﾀｲﾄﾙを「処理条件セットID　詳細」→「個別処理条件」に編集
                .fraCondition2.Text = CPstrParsonalCondition
                
                '@個別処理条件を表示
                With .vsfConditionList2
                    '@初期化
                    .Rows.Count = 1
                    '@使用ﾚｼﾋﾟを個別処理条件へ設定
                    For llngRow = 1 To vsfUseRecipe1.Rows.Count - 1
                        '@装置名が設定されている場合
                        If vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeWPNameCol) <> vbNullString Then
                            .AddItem(vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeNoCol) & vbTab & _
                                     vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeWPNameCol) & vbTab & _
                                     vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeWFCol) & vbTab & _
                                     vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeIDCol))
                        End If
                    Next
                    '@列幅自動調整
                    .AutoSizeCols(CMlngUseRecipeNoCol, CMlngUseRecipeIDCol, 6)
                    
                    '@ﾛｯﾄﾚｼﾋﾟの場合
                    If optRecipe0.Checked = True Then
                        .Cols(CPlngvsfConDetailListWFCol).Visible = False 'WF非表示
                    '@枚葉ﾚｼﾋﾟの場合
                    Else
                        .Cols(CPlngvsfConDetailListWFCol).Visible = True  'WF表示
                    End If
                End With
            
                '@個別処理条件を表示
                With .vsfConditionList3
                    '@初期化
                    .Rows.Count = 1
                    '@使用ﾚｼﾋﾟを個別処理条件へ設定
                    For llngRow = 1 To vsfUseRecipe2.Rows.Count - 1
                        '@装置名が設定されている場合
                        If vsfUseRecipe2.GetData(llngRow, CMlngUseRecipeWPNameCol) <> vbNullString Then
                            .AddItem(vsfUseRecipe2.GetData(llngRow, CMlngUseRecipeNoCol) & vbTab & _
                                     vsfUseRecipe2.GetData(llngRow, CMlngUseRecipeWPNameCol) & vbTab & _
                                     vsfUseRecipe2.GetData(llngRow, CMlngUseRecipeWFCol) & vbTab & _
                                     vsfUseRecipe2.GetData(llngRow, CMlngUseRecipeIDCol))
                        End If
                    Next
                    '@列幅自動調整
                    .AutoSizeCols(CMlngUseRecipeNoCol, CMlngUseRecipeIDCol, 6)
                    
                    '@ﾛｯﾄﾚｼﾋﾟの場合
                    If optRecipe2.Checked = True Then
                        .Cols(CPlngvsfConDetailListWFCol).Visible = False 'WF非表示
                    '@枚葉ﾚｼﾋﾟの場合
                    Else
                        .Cols(CPlngvsfConDetailListWFCol).Visible = True  'WF表示
                    End If
                End With
            
                '@個別処理条件を表示
                With .vsfConditionWP
                    '@初期化
                    .Rows.Count = 1
                    '@使用ﾚｼﾋﾟを個別処理条件へ設定
                    For llngRow = 1 To vsfUseWP.Rows.Count - 1
                        '@装置名が設定されている場合
                        If vsfUseWP.GetData(llngRow, CMlngUseRecipeWPNameCol) <> vbNullString Then
                            .AddItem(vsfUseWP.GetData(llngRow, CMlngUseWPNoCol) & vbTab & _
                                     vsfUseWP.GetData(llngRow, CMlngUseWPCKCol) & vbTab & _
                                     vsfUseWP.GetData(llngRow, CMlngUseWPIDCol) & vbTab & _
                                     vsfUseWP.GetData(llngRow, CMlngUseWPNameCol))
                        End If
                    Next
                    '@列幅自動調整
                    .AutoSizeCols(.Cols.Fixed, .Cols.Count - 1, 6)
                    
                End With
            
                '@使用可能ﾀﾌﾞの制御
                If stbRecipe.SelectedIndex = CMlngOptionTab Then
                    .fraRecipe.Visible = True
                    .fraRecipeAll.Visible = False
                Else
                    .fraRecipe.Visible = False
                    .fraRecipeAll.Visible = True
                End If
            End With
            
            
            '@ﾌﾟﾛｾｽ編集変更ﾌﾗｸﾞｵﾝ
            pblnEN01X2Edit = True
            
            '@編集ﾌﾗｸﾞをOFF
            pblnEdit = False
            
            '@画面を閉じる
            Me.Close()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdUpdate_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:47:05 N.Kasai
    '更新日：2006/06/21 (Wed) 15:47:05
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
            
            '@画面を閉じる
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:47:29 N.Kasai
    '更新日：2006/06/21 (Wed) 15:47:29
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

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdUP_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:47:46 N.Kasai
    '更新日：2006/06/21 (Wed) 15:47:46
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

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：stbRecipe_Click
    '機　能：装置共通/個別ﾚｼﾋﾟTab選択処理
    '引　数：PreviousTab：使用しない
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:48:32 N.Kasai
    '更新日：2008/12/25 (Thu) 11:32:09 M.Koni
    '備　考：
    '　　　：2008/12/25 (Thu) 11:24:20 M.Koni       <案件NO.03340> 「装置個別ﾚｼﾋﾟ」ﾀﾌﾞで表題欄しか無い場合の削除ﾎﾞﾀﾝ無効化
    Private Sub stbRecipe_Click(ByVal sender As Object, ByVal e As EventArgs) Handles stbRecipe.SelectedIndexChanged

        Try
            
            '@編集ﾌﾗｸﾞによる判別処理
            If pblnEdit = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004W)
                '@"<TRM4WI>$$装置共通レシピ/装置個別レシピ表示を変更します。$確定ボタン押下時は画面に表示されている内容で登録します。"
                publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, CMstrFormTitle, True, 16, False)
            End If
            
            '@確定ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            Call prvcmdUpdate_Chk()
            
            '@枚葉ﾚｼﾋﾟ可能判定ﾁｪｯｸ
            Call prvOptRecipeEnabled_Set()

        '@↓2008/12/25 (Thu) 11:24:20 M.Koni **************************************************

            '@「装置個別ﾚｼﾋﾟ」ﾀﾌﾞ選択時は，　ﾘｽﾄ行数を確認し，表題欄しか無いなら，
            '@ 「削除」ﾎﾞﾀﾝを無効にする。（ｲﾍﾞﾝﾄが先に発生するので，ﾀﾌﾞ番号に注意）
            If stbRecipe.SelectedIndex = CMlngOptionTab Then
                            
                '@1行以上ある場合
                If vsfUseRecipe1.Rows.Count > 2 Then
                    '@ﾌｫｰｶｽのｾｯﾄ
                    vsfUseRecipe1.Row = 1
                    '@削除ﾎﾞﾀﾝ有効
                    cmdDelRecipe.Enabled = True
                Else
                    '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝ無効
                    cmdDelRecipe.Enabled = False
                End If
            End If

        '@↑2008/12/25 (Thu) 11:24:20 M.Koni **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "stbRecipe_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ｽｸﾛｰﾙﾎﾞﾀﾝ対応
    '関数名：txtComments_Change
    '機　能：ｺﾒﾝﾄ欄変更
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:49:07 N.Kasai
    '更新日：2006/06/21 (Wed) 15:49:07
    '備　考：
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ｽｸﾛｰﾙﾎﾞﾀﾝ対応
    '関数名：txtComments_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:49:23 N.Kasai
    '更新日：2006/06/21 (Wed) 15:49:23
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp
        
        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdUP, cmdDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ｽｸﾛｰﾙﾎﾞﾀﾝ対応
    '関数名：txtComments_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:49:43 N.Kasai
    '更新日：2006/06/21 (Wed) 15:49:43
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtWorkCondition_Change
    '機　能：作業条件変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 15:50:26 N.Kasai
    '更新日：2006/06/21 (Wed) 15:50:26
    '備　考：
    Private Sub txtWorkCondition_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkCondition.Change
        
        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkCondition.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblOptionWordCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                              llngNowByte, _
                                                              CMlngOptionTextMaxByte)
            
            '@ﾌｫｰﾑﾛｰﾄﾞ中は判定しない
            If mblnFormLoadFlag = False Then
                '@変更ﾌﾗｸﾞON
                pblnEdit = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWorkCondition_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optRecipe_Click
    '機　能：ﾛｯﾄﾚｼﾋﾟ・枚葉ﾚｼﾋﾟ選択時
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:52:57 N.Kasai
    '更新日：2008/11/07 (Fri) 16:52:34 M.Koni
    '備　考：
    '　　　：2008/10/14 (Tue) 16:31:31 M.Koni       ltypProcWaferList をﾓｼﾞｭｰﾙ変数化。<案件No.02871>
    '　　　：2008/11/07 (Fri) 16:52:34 M.Koni       枚葉ﾚｼﾋﾟ設定時のﾚｼﾋﾟ反映方法変更。<案件No.03256>
    Private Sub optRecipe_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optRecipe0.CheckedChanged,
                                                                                      optRecipe1.CheckedChanged,
                                                                                      optRecipe2.CheckedChanged,
                                                                                      optRecipe3.CheckedChanged
        

        Dim ltypProcWaferList   As ProcWaferList    'ﾛｯﾄｳｪﾊ情報
        Dim ltypUseRecipe       As List(Of UseRecipe)   '使用ﾚｼﾋﾟ
        Dim lblnAns             As Boolean          '戻り値
        Dim llngRow             As Integer          '行ｶｳﾝﾀ
        Dim llngAryCount        As Integer          '配列ｶｳﾝﾀ
        Dim llngSlotCnt         As Integer          'ｽﾛｯﾄNoｶｳﾝﾀ
        Dim llngWFcnt           As Integer          'WFｶｳﾝﾀ
        Dim llngNo              As Integer          '№
        Dim llngCnt             As Integer          'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrEventName       As String           'ｲﾍﾞﾝﾄ名格納（ﾚｽﾎﾟﾝｽ用）
        Dim llngLineNo          As Integer          'ｳｴﾊﾘｽﾄの行番号
        Dim lstrSlotNo          As String           'proc.waferlist の SLOT_POSITION
        Dim lstrWaferRecipeKind As String           'proc.waferlist の WAFER_RECIPE_KIND
        Dim llngNo2             As Integer          '№(ｳｴﾊﾚｼﾋﾟ設定用)
        Dim llngOffSet          As Integer          '行ｵﾌｾｯﾄ値(ｳｴﾊﾚｼﾋﾟ設定用)
        Dim llngAryCountOld     As Integer          '旧配列ｶｳﾝﾀ(ｳｴﾊﾚｼﾋﾟ設定用)

        Try

            'NSYS クリックオフは処理を抜ける
            If sender.Checked = False Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "optRecipe_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            
            '@№の初期化
            llngNo = 1
            
            '@編集ﾌﾗｸﾞON
            If mblnFormLoadFlag = False Then
                '@ﾌｫｰﾑﾛｰﾄﾞ中以外の場合は編集ﾌﾗｸﾞをON
                pblnEdit = True
            End If
            
            'NSYS senderの名称の番号(1番右端の文字)を取得
            Select Case  Strings.Right(sender.Name,1)
                Case CMlngOptionLotOpt
                '@ﾛｯﾄﾚｼﾋﾟ
                    '@WF列非表示
                    vsfUseRecipe1.Cols(CMlngUseRecipeWFCol).Visible = False
                    '@使用ﾚｼﾋﾟｸﾘｱ
                    vsfUseRecipe1.Rows.Count = 1
                    
                    '@取得件数分だけﾙｰﾌﾟ
                    For llngCnt = 1 To ptypMasCondDetailList.lngMasCondDetailCnt
                        '@ﾚｼﾋﾟを表示
                        vsfUseRecipe1.Rows.Count = vsfUseRecipe1.Rows.Count + 1
                        '@№
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeNoCol, llngCnt)
                        
                        '@装置名
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeWPNameCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strWpName)
                            
                        '@ﾚｼﾋﾟ
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeIDCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strRecipeId)
                            
                        '@装置ID
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeWPIDCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strWpID)
                         
                        '@ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeVerCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strRecipeVersion)
                        
                        '@ｺﾒﾝﾄ
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeCommentsCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strComments)
                            
                        '@WFID(非表示に付きNULL)
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeWFCol, _
                            vbNullString)
                    Next llngCnt
                
                    '@2行以上ある場合
                    If vsfUseRecipe1.Rows.Count > 2 Then
                        '@ﾌｫｰｶｽのｾｯﾄ
                        vsfUseRecipe1.Row = 1
                        '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝ有効
                        cmdDelRecipe.Enabled = True
                    Else
                        '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝ無効
                        cmdDelRecipe.Enabled = False
                    End If
                
                    '@内部件数
                    If vsfUseRecipe1.Rows.Count < ptypMasCondDetailList.lngMasCondDetailCnt Then
                        cmdRowAdd.Enabled = True
                    Else
                        cmdRowAdd.Enabled = False
                    End If
                    
                    '@内部件数
                    If ptypMasCondDetailList.lngMasCondDetailCnt = 1 Then
                        cmdDelRecipe.Enabled = False
                        cmdRowAdd.Enabled = False
                    End If
                    
                Case CMlngCommonLotOpt
                '@装置共通ﾛｯﾄﾚｼﾋﾟｲﾝﾃﾞｯｸｽ
                    '@使用ﾚｼﾋﾟｸﾘｱ
                    vsfUseRecipe2.Rows.Count = 1
                    '@WF列非表示
                    vsfUseRecipe2.Cols(CMlngUseRecipeWFCol).Visible = False
                    
                    
                    '@必ず1件のみ
                    For llngCnt = 1 To 1
                        '@ﾚｼﾋﾟを表示
                        vsfUseRecipe2.Rows.Count = vsfUseRecipe2.Rows.Count + 1
                        '@№
                        vsfUseRecipe2.SetData(llngCnt, CMlngUseRecipeNoCol, llngCnt)
                        
                        '@装置名
                        vsfUseRecipe2.SetData(llngCnt, CMlngUseRecipeWPNameCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strWpName)
                            
                        '@ﾚｼﾋﾟ
                        vsfUseRecipe2.SetData(llngCnt, CMlngUseRecipeIDCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strRecipeId)
                            
                        '@装置ID
                        vsfUseRecipe2.SetData(llngCnt, CMlngUseRecipeWPIDCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strWpID)
                         
                        '@ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                        vsfUseRecipe2.SetData(llngCnt, CMlngUseRecipeVerCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strRecipeVersion)
                        
                        
                        '@ｺﾒﾝﾄ
                        vsfUseRecipe2.SetData(llngCnt, CMlngUseRecipeCommentsCol, _
                            ptypMasCondDetailList.typMasCondDetail(llngCnt - 1).strComments)
                            
                        '@WFID(非表示に付きNULL)
                        vsfUseRecipe2.SetData(llngCnt, CMlngUseRecipeWFCol, _
                            vbNullString)
                        
                    Next llngCnt
                
                    '@列幅自動調整
                    vsfUseRecipe2.AutoSizeCols(CMlngUseRecipeNoCol, CMlngUseRecipeWPIDCol, 6)
                    
                    '@1行以上ある場合
                    If vsfUseRecipe2.Rows.Count > 1 Then
                        '@ﾌｫｰｶｽのｾｯﾄ
                        vsfUseRecipe2.Row = 1
                    End If
                
                Case CMlngOptionWfOpt
                '@枚葉ﾚｼﾋﾟ
                    
        '@↓2008/10/14 (Tue) 16:54:12 M.Koni **************************************************

                    '@ﾛｯﾄｳｴﾊ情報構造体の初期化
                    mtypProcWaferList = ltypProcWaferList

                    '@MSG【ﾛｯﾄｳｪﾊ情報取得】
                    lblnAns = pubblnProcWaferList_Sel(CMstrprocwaferlistVer, mtypProcWaferList, pstrSBID, pstrLotID)

        '@↑2008/10/14 (Tue) 16:54:12 M.Koni **************************************************
                                                     
                    '@結果判定
                    If lblnAns = True Then
                    '@成功の場合
                        '@ﾃﾞｰﾀがない場合、処理中止
                        If mtypProcWaferList.lngProcWFListCnt = 0 Then
                        
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, lstrEventName)
                            
                            '@ﾛｯﾄﾚｼﾋﾟ選択
                            optRecipe0.Checked = True
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002Z)
                            '@「ウエハ情報が設定されていません。」ﾒｯｾｰｼﾞ表示
                            publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, CMstrFormTitle, True, 16, False)
                            
                            '@失敗
                            mlngOptRecipeFlag = False
                            
                            Exit Sub
                        End If

                        '@WF列表示
                        vsfUseRecipe1.Cols(CMlngUseRecipeWFCol).Visible = True

                        '@取得したｽﾛｯﾄNoを配列に格納
                        With mtypProcWaferList
                            '@ｳｴﾊID配列の定義
                            If mstrWFID Is Nothing Then
                                mstrWFID = New List(Of String)
                            Else
                                mstrWFID.Clear()
                            End If
                            For llngWFcnt = 0 To mtypProcWaferList.lngProcWFListCnt - 1
                                '@ｳｴﾊID配列を作成
                                Dim typString As String
                                typString = .typProcWFList(llngWFcnt).strWfId
                                mstrWFID.Add(typString)
                            Next
                        End With
            
                        With vsfUseRecipe1
                            '@使用ﾚｼﾋﾟが設定されていない場合、処理中止
                            If .Rows.Count = 1 Then
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(Me.Name, lstrEventName)
                                '@削除ﾎﾞﾀﾝ無効
                                cmdDelRecipe.Enabled = False
                                '@登録ﾎﾞﾀﾝ無効
                                cmdUpdate.Enabled = False
                                Exit Sub
                            End If
                            
                            '@使用ﾚｼﾋﾟ配列の定義
                            ltypUseRecipe = New List(Of UseRecipe)
                            
                            '@使用ﾚｼﾋﾟを配列に格納
                            For llngRow = 0 To ptypMasCondDetailList.lngMasCondDetailCnt - 1
                                Dim typUseRecipe = New UseRecipe
                                typUseRecipe.lstrRecipeID = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strRecipeId             'ﾚｼﾋﾟ
                                    
                                typUseRecipe.lstrRecipeVer = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strRecipeVersion        'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                                    
                                typUseRecipe.lstrWpId = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strWpID                 '装置ID
                                    
                                typUseRecipe.lstrWPName = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strWpName               '装置名
                                    
                                typUseRecipe.lstrComments = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strComments             'ﾚｼﾋﾟｺﾒﾝﾄ
                                ltypUseRecipe.Add(typUseRecipe)
                            Next
                            
                            '@初期化
                            .Rows.Count = 1

        '@↓2008/11/07 (Fri) 16:52:34 M.Koni **************************************************

                            '@旧ﾃﾞｰﾀを初期化（llngAryCountと同一化）
                            llngAryCountOld = 0

                            '@使用ﾚｼﾋﾟ配列の検索
                            For llngAryCount = 0 To ltypUseRecipe.Count - 1
                                '@装置名が設定されている場合
                                If ltypUseRecipe(llngAryCount).lstrWpId <> vbNullString Then
                                    '@ｳｴﾊID配列の検索
                                    For llngSlotCnt = 0 To mstrWFID.Count - 1
                                        '@使用ﾚｼﾋﾟ×ｳｴﾊID分のﾃﾞｰﾀを作成【装置名｜WFID｜ﾚｼﾋﾟID｜ﾚｼﾋﾟVer｜装置ID】
                                        .AddItem(llngNo & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrWPName & vbTab & _
                                                 mstrWFID(llngSlotCnt) & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrRecipeID & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrRecipeVer & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrWpId & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrComments)
                                        '№のｶｳﾝﾄｱｯﾌﾟ
                                        llngNo = llngNo + 1
                                    Next
                                End If

                                '@先頭装置を除き，同一装置の場合は，同じｵﾌｾｯﾄ値を使用する。
                                If llngAryCount = llngAryCountOld Then
                                    If llngAryCount = 0 Then
                                        llngOffSet = 0                  '@先頭装置の場合は，ｾﾞﾛ固定
                                        llngNo2 = llngNo - 1
                                    End If
                                
                                Else
                                    '@装置変更時は，その時の行番号を退避
                                    llngOffSet = llngNo2
                                    llngNo2 = llngNo - 1
                                    llngAryCountOld = llngAryCount

                                End If

                                '@ Msg:"proc.waferlist" の WAFER_RECIPE_KIND の設定を反映し，枚葉設定不可(=2)の
                                '@ ｳｴﾊに対し，表示情報のｸﾘｱ処理を行う。

                                For llngCnt = 0 To mtypProcWaferList.lngProcWFListCnt - 1

                                    '@ Msg:"proc.waferlist" の SLOT_POSITION, WAFER_RECIPE_KIND を入手
                                    lstrSlotNo = mtypProcWaferList.typProcWFList(llngCnt).strSlotPosition

                                    '@SLOT_POSITIONが得られなかったら，WAFER_RECIPE_KIND=0 とする。
                                    If lstrSlotNo <> vbNullString Then
                                        lstrWaferRecipeKind = mtypProcWaferList.typProcWFList(llngCnt).strWaferRecipeKind
                                    Else
                                        lstrWaferRecipeKind = CMstrDoNotCare
                                    End If

                                    '@ WAFER_RECIPE_KIND が，枚葉設定不可の場合，ｸﾘｱ処理を行う
                                    If lstrWaferRecipeKind = CMstrInvalidWfRecipe Then

                                        '@ 行番号     ｵﾌｾｯﾄ       配列番号
                                        llngLineNo = llngOffSet + llngCnt + 1

                                        '@枚葉設定不可領域のｸﾘｱ
                                        .SetData(llngLineNo, CMlngUseRecipeIDCol, vbNullString)
                                        .SetData(llngLineNo, CMlngUseRecipeCommentsCol, vbNullString)
                                    
                                        '@ｸﾞﾚｰ表示化(無効化判断のための)
                                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorGray")
                                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorGray)
                                        Dim cellRange As CellRange = .GetCellRange(llngLineNo, CMlngUseRecipeIDCol)
                                        cellRange.Style = newStyle
                                        Dim cellRange2 As CellRange = .GetCellRange(llngLineNo, CMlngUseRecipeCommentsCol)
                                        cellRange2.Style = newStyle

                                    End If
                                Next
                            Next

        '@↑2008/11/07 (Fri) 16:52:34 M.Koni **************************************************

                            '@列幅自動調整
                            ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
                            .AllowMerging = AllowMergingEnum.None
                            .AutoSizeCols(CMlngUseRecipeNoCol, CMlngUseRecipeWPIDCol, 6)
                            .AllowMerging = AllowMergingEnum.Free
                            
                            '@1行以上ある場合
                            If .Rows.Count > 2 Then
                                '@ﾌｫｰｶｽのｾｯﾄ
                                .Row = 1
                                '@削除ﾎﾞﾀﾝ有効
                                cmdDelRecipe.Enabled = True
                            Else
                                '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝ無効
                                cmdDelRecipe.Enabled = False
                            End If
                            
                            '@内部件数
                            If ptypMasCondDetailList.lngMasCondDetailCnt = 1 Then
                                cmdDelRecipe.Enabled = False
                                cmdRowAdd.Enabled = False
                            End If
                        End With
                        
                    Else
                    '@失敗の場合
                        '@使用ﾚｼﾋﾟ削除
                        vsfUseRecipe1.Rows.Count = 1
                        
                        '@確定ﾎﾞﾀﾝ使用不可
                        cmdUpdate.Enabled = False
                        '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝ使用不可
                        cmdDelRecipe.Enabled = False
                        
                        '@失敗
                        mlngOptRecipeFlag = False
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                        Exit Sub
                    End If
                 
                Case CMlngCommonWfOpt
                '@装置共通枚葉ﾚｼﾋﾟｲﾝﾃﾞｸｽ
                    '@枚葉ﾚｼﾋﾟ
                    
                    
                    '@----------------
                    '@ﾛｯﾄｳｪﾊ情報取得
                    '@----------------
        '@↓2008/10/14 (Tue) 16:54:34 M.Koni **************************************************
                    
                    '@ﾛｯﾄｳｴﾊ情報構造体の初期化
                    mtypProcWaferList = ltypProcWaferList
                    
                    '@MSG【ﾛｯﾄｳｪﾊ情報取得】（CPstrCD0L：ﾛｯﾄ指定）
                    lblnAns = pubblnProcWaferList_Sel(CMstrprocwaferlistVer, mtypProcWaferList, pstrSBID, pstrLotID)

        '@↑2008/10/14 (Tue) 16:54:34 M.Koni **************************************************
                    
                    '@結果判定
                    If lblnAns = True Then
                    '@成功の場合
                        '@ﾃﾞｰﾀがない場合、処理中止
                        If mtypProcWaferList.lngProcWFListCnt = 0 Then
                        
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, lstrEventName)
                            
                            '@ﾛｯﾄﾚｼﾋﾟ選択
                            optRecipe2.Checked = True
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002Z)
                            '@「ウエハ情報が設定されていません。」ﾒｯｾｰｼﾞ表示
                            publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, CMstrFormTitle, True, 16, False)
                            
                            '@失敗
                            mlngOptRecipeFlag = False
                            
                            Exit Sub
                        End If
                        
                        '@WF列表示
                        vsfUseRecipe2.Cols(CMlngUseRecipeWFCol).Visible = True

                        '@取得したｽﾛｯﾄNoを配列に格納
                        With mtypProcWaferList
                            '@ｳｴﾊID配列の定義
                            If mstrWFID Is Nothing Then
                                mstrWFID = New List(Of String)
                            Else
                                mstrWFID.Clear()
                            End If
                            For llngWFcnt = 0 To mtypProcWaferList.lngProcWFListCnt - 1
                                '@ｳｴﾊID配列を作成
                                Dim typString As String
                                typString = .typProcWFList(llngWFcnt).strWfId
                                mstrWFID.Add(typString)
                            Next
                        End With
            
                        With vsfUseRecipe2
                            '@使用ﾚｼﾋﾟが設定されていない場合、処理中止
                            If .Rows.Count = 1 Then
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(Me.Name, lstrEventName)
                                '@削除ﾎﾞﾀﾝ無効
                                cmdDelRecipe.Enabled = False
                                '@登録ﾎﾞﾀﾝ無効
                                cmdUpdate.Enabled = False
                                Exit Sub
                            End If

                            '@使用ﾚｼﾋﾟ配列の定義
                            ltypUseRecipe = New List(Of UseRecipe)
                            
                            '@使用ﾚｼﾋﾟを配列に格納
                            For llngRow = 0 To ptypMasCondDetailList.lngMasCondDetailCnt - 1
                                Dim typUseRecipe = New UseRecipe
                                typUseRecipe.lstrRecipeID = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strRecipeId             'ﾚｼﾋﾟ
                                    
                                typUseRecipe.lstrRecipeVer = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strRecipeVersion        'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                                    
                                typUseRecipe.lstrWpId = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strWpID                 '装置ID
                                    
                                typUseRecipe.lstrWPName = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strWpName               '装置名
                                    
                                typUseRecipe.lstrComments = _
                                    ptypMasCondDetailList.typMasCondDetail(llngRow).strComments             'ﾚｼﾋﾟｺﾒﾝﾄ
                                ltypUseRecipe.Add(typUseRecipe)
                            Next
                            
                            '@初期化
                            .Rows.Count = 1

        '@↓2008/11/07 (Fri) 16:52:34 M.Koni **************************************************

                            '@旧ﾃﾞｰﾀを初期化（llngAryCountと同一化）
                            llngAryCountOld = 0

                            '@使用ﾚｼﾋﾟ配列の検索
                            For llngAryCount = 0 To 0
                                '@装置名が設定されている場合
                                If ltypUseRecipe(llngAryCount).lstrWpId <> vbNullString Then
                                    '@ｳｴﾊID配列の検索
                                    For llngSlotCnt = 0 To mstrWFID.Count - 1
                                        '@使用ﾚｼﾋﾟ×ｳｴﾊID分のﾃﾞｰﾀを作成【装置名｜WFID｜ﾚｼﾋﾟID｜ﾚｼﾋﾟVer｜装置ID】
                                        .AddItem(llngNo & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrWPName & vbTab & _
                                                 mstrWFID(llngSlotCnt) & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrRecipeID & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrRecipeVer & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrWpId & vbTab & _
                                                 ltypUseRecipe(llngAryCount).lstrComments)
                                        '№のｶｳﾝﾄｱｯﾌﾟ
                                        llngNo = llngNo + 1
                                    Next
                                End If

                                '@先頭装置を除き，同一装置の場合は，同じｵﾌｾｯﾄ値を使用する。
                                If llngAryCount = llngAryCountOld Then
                                    If llngAryCount = 0 Then
                                        llngOffSet = 0                  '@先頭装置の場合は，ｾﾞﾛ固定
                                        llngNo2 = llngNo - 1
                                    End If
                                
                                Else
                                    '@装置変更時は，その時の行番号を退避
                                    llngOffSet = llngNo2
                                    llngNo2 = llngNo - 1
                                    llngAryCountOld = llngAryCount

                                End If

                                '@ Msg:"proc.waferlist" の WAFER_RECIPE_KIND の設定を反映し，枚葉設定不可(=2)の
                                '@ ｳｴﾊに対し，表示情報のｸﾘｱ処理を行う。

                                For llngCnt = 0 To mtypProcWaferList.lngProcWFListCnt - 1

                                    '@ Msg:"proc.waferlist" の SLOT_POSITION, WAFER_RECIPE_KIND を入手
                                    lstrSlotNo = mtypProcWaferList.typProcWFList(llngCnt).strSlotPosition
                                    
                                    '@SLOT_POSITIONが得られなかったら，WAFER_RECIPE_KIND=0 とする。
                                    If lstrSlotNo <> vbNullString Then
                                        lstrWaferRecipeKind = mtypProcWaferList.typProcWFList(llngCnt).strWaferRecipeKind
                                    Else
                                        lstrWaferRecipeKind = CMstrDoNotCare
                                    End If

                                    '@ WAFER_RECIPE_KIND が，枚葉設定不可の場合，ｸﾘｱ処理を行う
                                    If lstrWaferRecipeKind = CMstrInvalidWfRecipe Then

                                        '@ 行番号     ｵﾌｾｯﾄ       配列番号
                                        llngLineNo = llngOffSet + llngCnt + 1

                                        '@枚葉設定不可領域のｸﾘｱ
                                        .SetData(llngLineNo, CMlngUseRecipeIDCol, vbNullString)
                                        .SetData(llngLineNo, CMlngUseRecipeCommentsCol, vbNullString)
                                    
                                        '@ｸﾞﾚｰ表示化(無効化判断のための)
                                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorGray")
                                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorGray)
                                        Dim cellRange As CellRange = .GetCellRange(llngLineNo, CMlngUseRecipeIDCol)
                                        cellRange.Style = newStyle
                                        Dim cellRange2 As CellRange = .GetCellRange(llngLineNo, CMlngUseRecipeCommentsCol)
                                        cellRange2.Style = newStyle

                                    End If
                                Next
                            Next

        '@↑2008/11/07 (Fri) 16:52:34 M.Koni **************************************************

                            '@列幅自動調整
                            .AutoSizeCols(CMlngUseRecipeNoCol, CMlngUseRecipeWPIDCol, 6)
                            
                            '@1行以上ある場合
                            If .Rows.Count > 2 Then
                                '@ﾌｫｰｶｽのｾｯﾄ
                                .Row = 1
                                '@削除ﾎﾞﾀﾝ有効
                                cmdDelRecipe.Enabled = True
                            Else
                                '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝ無効
                                cmdDelRecipe.Enabled = False
                            End If
                    
                        End With
                        
                    Else
                    '@失敗の場合
                        '@使用ﾚｼﾋﾟ削除
                        vsfUseRecipe1.Rows.Count = 1
                        
                        '@確定ﾎﾞﾀﾝ使用不可
                        cmdUpdate.Enabled = False
                        '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝ使用不可
                        cmdDelRecipe.Enabled = False
                        
                        '@失敗
                        mlngOptRecipeFlag = False
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                        Exit Sub
                    End If
                
            End Select
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdUpdate_Chk()
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optRecipe_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseRecipe_AfterScroll
    '機　能：使用ﾚｼﾋﾟ　ｽｸﾛｰﾙ後処理
    '引　数：OldTopRow ：未使用
    '　　　：OldLeftCol：未使用
    '　　　：NewTopRow ：未使用
    '　　　：NewLeftCol：未使用
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 16:00:33 N.Kasai
    '更新日：2006/06/21 (Wed) 16:00:33
    '備　考：
    Private Sub vsfUseRecipe_AfterScroll(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfUseRecipe1.AfterScroll,
                                                                                                    vsfUseRecipe2.AfterScroll
        Try

            'NSYS データ行がない場合は処理を抜ける
            If sender.Rows.Count <= sender.Rows.Fixed Then
                Return
            End If

            '@ﾍﾟｰｼﾞ先頭行取得
            Call pubVsfAfterScroll(sender)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfUseRecipe_AfterScroll"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseRecipe_BeforeRowColChange
    '機　能：使用ﾚｼﾋﾟ 編集制御
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 16:06:24 N.Kasai
    '更新日：2006/06/21 (Wed) 16:06:24
    '備　考：
    Private Sub vsfUseRecipe_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfUseRecipe1.BeforeRowColChange,
                                                                                                           vsfUseRecipe2.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If sender.Rows.Count <= sender.Rows.Fixed Then
                Return
            End If

            With CType(sender,C1FlexGrid)
                '@ﾀｲﾄﾙ行の場合には処理しない
                If e.NewRange.r1 < .Rows.Fixed Then
                    Exit Sub
                End If
                
                '@変更可否判定
                Select Case e.NewRange.c1
                    Case CMlngUseRecipeIDCol
                    '@ﾚｼﾋﾟID
                        If .GetData(e.NewRange.r1, CMlngUseRecipeWPNameCol) <> vbNullString Then
                            '@編集する
                            .AllowEditing = True
                        End If
                        If .GetData(e.NewRange.r1, CMlngUseRecipeIDCol) = vbNullString Then
                            .Styles.Editor.BackColor = .Styles.Normal.BackColor
                        End If
                    Case CMlngUseRecipeWPNameCol
                    '@装置ID
                        '@編集する
                        .AllowEditing = True
                    
                    Case Else
                    '@その他
                        '@編集しない
                        .AllowEditing = False
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfUseRecipe_BeforeRowColChange"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseRecipe_AfterEdit
    '機　能：使用ﾚｼﾋﾟ　変更後処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 16:09:15 N.Kasai
    '更新日：2006/06/21 (Wed) 16:09:15
    '備　考：
    Private Sub vsfUseRecipe_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfUseRecipe1.AfterEdit,
                                                                                                   vsfUseRecipe2.AfterEdit
        
        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrWP                  As String               '装置
        Dim ltypMasRecipeNameList   As MasRecipeNameList    'ﾚｼﾋﾟﾘｽﾄ
        Dim llngCnt                 As Integer              'ｶｳﾝﾀ
        Dim recipever               As String               'NSYS ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
        Dim wpid                    As String               'NSYS 装置ID

        Try
            
            With CType(sender,C1FlexGrid)
            
                '@確定ﾎﾞﾀﾝﾁｪｯｸ
                Call prvcmdUpdate_Chk()
                
                '@列幅自動調整
                ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
                .AllowMerging = AllowMergingEnum.None
                .AutoSizeCols(CMlngUseRecipeWPNameCol, CMlngUseRecipeWPIDCol, 6)
                .AllowMerging = AllowMergingEnum.Free
            
                '@ﾛｯﾄﾚｼﾋﾟが選択されている場合
                If optRecipe0.Checked = True Then
                    Select Case .Col
                        '@ｶﾚﾝﾄ列がﾚｼﾋﾟIDの場合の場合
                        Case CMlngUseRecipeIDCol
                            '@ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝをｾｯﾄ
                            recipever = prvGetRecipeVer(.GetData(.Row,CMlngUseRecipeWPIDCol), .GetData(.Row,CMlngUseRecipeIDCol))
                            .SetData(.Row, CMlngUseRecipeVerCol, recipever)
                            
                        '@ｶﾚﾝﾄ列が装置名の場合
                        Case CMlngUseRecipeWPNameCol
                        
                            '@装置IDをｾｯﾄ
                            wpid = prvGetWpid(.GetData(.Row,CMlngUseRecipeWPNameCol))
                            .SetData(.Row, CMlngUseRecipeWPIDCol, wpid)
                            
                            '@枚葉ﾚｼﾋﾟ可能判定
                            Call prvOptRecipeEnabled_Set()
                            
                            '@ﾚｼﾋﾟ一覧取得件数分ﾙｰﾌﾟ
                            For llngCnt = 0 To mlngRecipeNameListCnt - 1
                                '@装置IDが同じ場合
                                If .GetData(.Row, CMlngUseRecipeWPIDCol) = mtypMasRecipeNameList(llngCnt).strWpID Then
                                    '@処理を抜ける
                                    Exit Sub
                                End If
                            Next
                            
                            '@装置ID退避
                            lstrWP = .GetData(.Row, CMlngUseRecipeWPIDCol)
                            '@MSG[ﾚｼﾋﾟ名一覧取得]を実行
                            lblnAns = pubblnMasRecipeNameList_Sel(pstrSBID, CMstrmas_recipnamelistVer, vbNullString, lstrWP, _
                                                                  vbNullString, ltypMasRecipeNameList)
                            '@結果判定
                            If lblnAns = True Then
                                '@ﾚｼﾋﾟ一覧取得件数
                                mlngRecipeNameListCnt = mtypMasRecipeNameList.Count + 1
                                '@ﾚｼﾋﾟﾘｽﾄの退避
                                mtypMasRecipeNameList.Add(ltypMasRecipeNameList)
                            '@失敗の場合
                            Else
                            End If
                    End Select
                Else
                '@枚葉ﾚｼﾋﾟが選択されている場合
                    Select Case .Col
                        '@ｶﾚﾝﾄ列がﾚｼﾋﾟIDの場合の場合
                        Case CMlngUseRecipeIDCol
                            '@ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝをｾｯﾄ
                            recipever = prvGetRecipeVer(.GetData(.Row,CMlngUseRecipeWPIDCol), .GetData(.Row,CMlngUseRecipeIDCol))
                            .SetData(.Row, CMlngUseRecipeVerCol, recipever)
                            
                        '@ｶﾚﾝﾄ列が装置名の場合
                        Case CMlngUseRecipeWPNameCol
                            For llngCnt = 1 To .Rows.Count - 1
                                '@装置が同じ場合
                                If .GetData(.Row, CMlngUseRecipeWPNameCol) = _
                                    .GetData(llngCnt, CMlngUseRecipeWPNameCol) Then
                                    
                                    '@装置IDをｾｯﾄ
                                    wpid = prvGetWpid(.GetData(.Row,CMlngUseRecipeWPNameCol))
                                    .SetData(llngCnt, CMlngUseRecipeWPIDCol, wpid)
                                End If
                            Next
                            '@ﾚｼﾋﾟ一覧取得件数分ﾙｰﾌﾟ
                            For llngCnt = 0 To mlngRecipeNameListCnt - 1
                                '@装置IDが同じ場合
                                If .GetData(.Row, CMlngUseRecipeWPIDCol) = _
                                    mtypMasRecipeNameList(llngCnt).strWpID Then
                                    
                                    '@処理を抜ける
                                    Exit Sub
                                End If
                            Next
                            
                            '@装置ID退避
                            lstrWP = .GetData(.Row, CMlngUseRecipeWPIDCol)
                            '@MSG[ﾚｼﾋﾟ名一覧取得]を実行
                            lblnAns = pubblnMasRecipeNameList_Sel(pstrSBID, _
                                                                  CMstrmas_recipnamelistVer, _
                                                                  vbNullString, _
                                                                  lstrWP, _
                                                                  vbNullString, _
                                                                  ltypMasRecipeNameList)
                            '@結果判定
                            If lblnAns = True Then
                                '@ﾚｼﾋﾟ一覧取得件数
                                mlngRecipeNameListCnt = mtypMasRecipeNameList.Count + 1
                                
                                '@ﾚｼﾋﾟﾘｽﾄの退避
                                mtypMasRecipeNameList.Add(ltypMasRecipeNameList)
                            End If
                    End Select
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfUseRecipe_AfterEdit"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseRecipe_BeforeEdit
    '機　能：使用ﾚｼﾋﾟ編集前処理　ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄの項目を設定
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:53:59 N.Kasai
    '更新日：2008/12/02 (Tue) 09:39:19 M.Koni
    '備　考：2008/12/01 (Mon) 16:05:38 M.Koni   <案件No.03256> ﾚｼﾋﾟﾘｽﾄの無効化追加
    '　　　：
    Private Sub vsfUseRecipe_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfUseRecipe1.BeforeEdit,
                                                                                                    vsfUseRecipe2.BeforeEdit
        Try

            'NSYS データ行がない場合は処理を抜ける
            If sender.Rows.Count <= sender.Rows.Fixed Then
                Return
            End If

            Select Case sender.Col
                '@ﾚｼﾋﾟIDの場合
                Case CMlngUseRecipeIDCol
                    With CType(sender, C1FlexGrid)
                        '@ﾀｲﾄﾙ行以外の場合
                        If .Row > 0 Then

                            '@↓2008/12/01 (Mon) 16:05:38 M.Koni **************************************************
                            '@背景がｸﾞﾚｰの場合は処理しない。
                            '@単純な処理抜けでは，ﾌﾟﾙﾀﾞｳﾝﾘｽﾄを抑制できないので，Editableで無効化
                            If .GetCellRange(.Row, .Col).StyleDisplay.BackColor = ColorTranslator.FromWin32(CMlngBackColorGray) Then
                                .AllowEditing = False
                                Exit Sub
                            End If
                            '@↑2008/12/01 (Mon) 16:05:38 M.Koni **************************************************

                            '@ﾚｼﾋﾟIDﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄの項目を設定
                            .ComboList = prvSetRecipe_Edit(sender)

                            '@ComboﾘｽﾄがNullの場合
                            If .ComboList = vbNullString Then
                                '@編集不可
                                .AllowEditing = False
                            End If
                        End If
                    End With

                '@装置名の場合
                Case CMlngUseRecipeWPNameCol
                    With CType(sender, C1FlexGrid)
                        '@ﾀｲﾄﾙ行以外の場合
                        If .Row > 0 Then
                            '@ﾚｼﾋﾟIDﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄの項目を設定
                            .ComboList = prvSetWP_Edit(mlngWpListCnt)

                            '@ComboﾘｽﾄがNullの場合
                            If .ComboList = vbNullString Then
                                '@編集不可
                                .AllowEditing = False
                            End If
                        End If
                    End With
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfUseRecipe_BeforeEdit"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseRecipe_ChangeEdit
    '機　能：使用ﾚｼﾋﾟ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:55:13 N.Kasai
    '更新日：2006/07/12 (Wed) 11:55:13
    '備　考：
    Private Sub vsfUseRecipe_ChangeEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfUseRecipe1.ChangeEdit,
                                                                                              vsfUseRecipe2.ChangeEdit

        Dim llngCnt                 As Integer              'ｶｳﾝﾀ
        Dim llngWkRow               As Integer              '行
        Dim llngWkCol               As Integer              '列
        Dim wpid                    As String               'NSYS 装置ID
        Dim llngWfListNo        As Integer          'proc.waferlist の 配列番号
        Dim lstrWaferRecipeKind As String           'proc.waferlist の WAFER_RECIPE_KIND
        llngWfListNo = 0                            '初期化

        Try

            'NSYS データ行がない場合は処理を抜ける
            If sender.Rows.Count <= sender.Rows.Fixed Then
                Return
            End If
            
            '@編集ﾌﾗｸﾞON
            If mblnFormLoadFlag = False Then
                '@ﾌｫｰﾑﾛｰﾄﾞ中以外の場合は編集ﾌﾗｸﾞをON
                pblnEdit = True
            End If
            
            With CType(sender,C1FlexGrid)
                Select Case .Col
                    '@ｶﾚﾝﾄ列が装置名の場合
                    Case CMlngUseRecipeWPNameCol
                        '@ﾛｯﾄﾚｼﾋﾟが選択されている場合
                        If optRecipe0.Checked = True Then
                            '@ﾚｼﾋﾟIDを初期化
                            .SetData(.Row, CMlngUseRecipeIDCol, vbNullString)
                            '@ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝを初期化
                            .SetData(.Row, CMlngUseRecipeVerCol, vbNullString)
                            '@ﾚｼﾋﾟｺﾒﾝﾄを初期化
                            .SetData(.Row, CMlngUseRecipeCommentsCol, vbNullString)
                            '@ﾚｼﾋﾟID列にｾｯﾄﾌｫｰｶｽ
                            .Col = CMlngUseRecipeIDCol
                        Else
                        '@枚葉ﾚｼﾋﾟが選択されている場合
                            '@ｶﾚﾝﾄ行退避
                            llngWkRow = .Row
                            '@ｶﾚﾝﾄ列退避
                            llngWkCol = .Col
                            '@WFIDが設定されていない場合
                            If .GetData(.Row, CMlngUseRecipeWFCol) = vbNullString Then
                                llngCnt = 0
                                '@ｶﾚﾝﾄ行にWFID設定
                                .SetData(.Row, CMlngUseRecipeWFCol, mstrWFID(llngCnt))

        '@↓2008/12/18 (Thu) 08:40:02 M.Koni **************************************************
                                
                                '@ Msg:"proc.waferlist" の WAFER_RECIPE_KIND を入手
                                lstrWaferRecipeKind = mtypProcWaferList.typProcWFList(llngWfListNo).strWaferRecipeKind

                                '@ WAFER_RECIPE_KIND が，枚葉設定不可の場合，ｸﾘｱ処理を行う
                                If lstrWaferRecipeKind = CMstrInvalidWfRecipe Then

                                    '@枚葉設定不可領域のｸﾘｱ
                                    .SetData(.Row, CMlngUseRecipeIDCol, vbNullString)
                                    .SetData(.Row, CMlngUseRecipeCommentsCol, vbNullString)
                                    
                                    '@ｸﾞﾚｰ表示化(無効化判断のための)
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorGray")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorGray)
                                    Dim cellRange As CellRange = .GetCellRange(.Row, CMlngUseRecipeIDCol)
                                    cellRange.Style = newStyle
                                    Dim cellRange2 As CellRange = .GetCellRange(.Row, CMlngUseRecipeCommentsCol)
                                    cellRange2.Style = newStyle
                                End If
                                
                                llngWfListNo = llngWfListNo + 1

        '@↑2008/12/18 (Thu) 08:40:02 M.Koni **************************************************

                                '@ｳｴﾊID配列の検索
                                For llngCnt = 1 To mstrWFID.Count - 1
                                    '@行追加
                                    .AddItem(llngWkRow + llngCnt, llngWkRow + llngCnt)          '行追加
                                    
                                    Call prvNo_Set                                              '№振り直し処理
                                    .TopRow = llngWkRow                                         'ｽｸﾛｰﾙﾊﾞｰの移動
                                    .Row = llngWkRow + llngCnt                                  'ｶﾚﾝﾄｾﾙの設定
                                    
                                    '@新行に装置名を設定
                                    .SetData(.Row, CMlngUseRecipeWPNameCol, _
                                        .GetData(llngWkRow, CMlngUseRecipeWPNameCol))
                                        
                                    '@新行に装置IDを設定
                                    wpid = prvGetWpid(.GetData(.Row,CMlngUseRecipeWPNameCol))
                                    .SetData(.Row, CMlngUseRecipeWPIDCol, wpid)
                                    
                                    '@新行にWFIDを設定
                                    .SetData(.Row, CMlngUseRecipeWFCol, mstrWFID(llngCnt))

        '@↓2008/12/18 (Thu) 08:40:02 M.Koni **************************************************
                                    
                                    '@ Msg:"proc.waferlist" の WAFER_RECIPE_KIND を入手
                                    lstrWaferRecipeKind = mtypProcWaferList.typProcWFList(llngWfListNo).strWaferRecipeKind

                                    '@ WAFER_RECIPE_KIND が，枚葉設定不可の場合，ｸﾘｱ処理を行う
                                    If lstrWaferRecipeKind = CMstrInvalidWfRecipe Then

                                        '@枚葉設定不可領域のｸﾘｱ
                                        .SetData(.Row, CMlngUseRecipeIDCol, vbNullString)
                                        .SetData(.Row, CMlngUseRecipeCommentsCol, vbNullString)
                                    
                                        '@ｸﾞﾚｰ表示化(無効化判断のための)
                                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorGray")
                                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorGray)
                                        Dim cellRange As CellRange = .GetCellRange(.Row, CMlngUseRecipeIDCol)
                                        cellRange.Style = newStyle
                                        Dim cellRange2 As CellRange = .GetCellRange(.Row, CMlngUseRecipeCommentsCol)
                                        cellRange2.Style = newStyle
                                    End If
                                    
                                    llngWfListNo = llngWfListNo + 1

        '@↑2008/12/18 (Thu) 08:40:02 M.Koni **************************************************

                                    Call pubSetFocus(sender)
            
                                Next

                            End If
                            For llngCnt = 1 To .Rows.Count - 1
                                '@同じ装置の場合
                                If .GetData(.Row, CMlngUseRecipeWPNameCol) = _
                                    .GetData(llngCnt, CMlngUseRecipeWPNameCol) Then
                                    
                                    '@ﾚｼﾋﾟIDを初期化
                                    .SetData(llngCnt, CMlngUseRecipeIDCol, vbNullString)
                                    '@ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝを初期化
                                    .SetData(llngCnt, CMlngUseRecipeVerCol, vbNullString)
                                    
                                    '@ﾚｼﾋﾟｺﾒﾝﾄを初期化
                                    .SetData(llngCnt, CMlngUseRecipeCommentsCol, vbNullString)
                                    
                                End If
                            Next
                            '@ﾚｼﾋﾟID列にｾｯﾄﾌｫｰｶｽ
                            .Row = llngWkRow
                            .Col = CMlngUseRecipeIDCol
                        End If
                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfUseRecipe_ChangeEdit"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseRecipe_ComboCloseUp
    '機　能：使用ﾚｼﾋﾟ　ｺﾝﾎﾞﾎﾞｯｸｽの閉じる前処理
    '引　数：Row：行
    '　　　：Col：列
    '　　　：FinishEdit：
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:55:28 N.Kasai
    '更新日：2006/07/12 (Wed) 11:55:28
    '備　考：
    Private Sub vsfUseRecipe_ComboCloseUp(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfUseRecipe1.ComboCloseUp,
                                                                                                      vsfUseRecipe2.ComboCloseUp
        
        Dim lstrRecipeID        As String       'ﾚｼﾋﾟID退避
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ大
        Dim llngCnt2            As Integer      '汎用ｶｳﾝﾀ小
        Dim lblnGetFlag         As Boolean      '判定ﾌﾗｸﾞ

        Try
            
            With CType(sender,C1FlexGrid)
                '@ﾚｼﾋﾟID変更場合
                If .Col = CMlngUseRecipeIDCol Then
                    '@ｺﾝﾎﾞを選択していない場合
                    If .ComboBoxEditor.SelectedIndex = -1 Then
                        '@処理抜け
                        Exit Sub
                    End If
                    
                    '@ﾌﾗｸﾞ初期化
                    lblnGetFlag = False
                    '@ﾚｼﾋﾟIDを退避
                    lstrRecipeID = .ComboBoxEditor.SelectedItem
                    
                    '@ﾚｼﾋﾟ一覧取得件数分ﾙｰﾌﾟ
                    For llngCnt = 0 To mlngRecipeNameListCnt - 1
                        '@ﾚｼﾋﾟ一覧格納用の装置IDとｸﾞﾘｯﾄﾞの装置IDが同じ場合
                        If .GetData(.Row, CMlngUseRecipeWPIDCol) = mtypMasRecipeNameList(llngCnt).strWpID Then
                            '@ﾚｼﾋﾟ数分ﾙｰﾌﾟ
                            For llngCnt2 = 0 To mtypMasRecipeNameList(llngCnt).lngMasRecipeNameCnt - 1
                                '@退避したﾚｼﾋﾟIDと同じIDNo場合
                                If mtypMasRecipeNameList(llngCnt).typMasRecipeName(llngCnt2).strRecipeId = lstrRecipeID Then
                                    '@ｸﾞﾘｯﾄﾞへ
                                    .SetData(.Row, CMlngUseRecipeCommentsCol, _
                                        mtypMasRecipeNameList(llngCnt).typMasRecipeName(llngCnt2).strComments)
                                    
                                    '@ﾌﾗｸﾞを立てる
                                    lblnGetFlag = True
                                    
                                    Exit For
                                End If
                            Next
                        Exit For
                        End If
                    Next
                End If
                
                '@ﾌﾗｸﾞが立っている場合
                If lblnGetFlag = False Then
                    '@ﾚｼﾋﾟｺﾒﾝﾄにNullを設定
                    .SetData(.Row, CMlngUseRecipeCommentsCol, vbNullString)
                End If
                
                '@列幅自動調整
                ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
                .AllowMerging = AllowMergingEnum.None
                .AutoSizeCols(CMlngUseRecipeWPNameCol, CMlngUseRecipeWPIDCol, 6)
                .AllowMerging = AllowMergingEnum.Free
            End With
            
            '@編集を完了する
            e.Cancel = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfUseRecipe_ComboCloseUp"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRowAdd_Click
    '機　能：行追加ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:55:57 N.Kasai
    '更新日：2006/07/12 (Wed) 11:55:57
    '備　考：
    Private Sub cmdRowAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRowAdd.Click

        Dim lblnAns         As Boolean          '結果判定

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfUseRecipe1
                '@行追加
                .AddItem(.Rows.Count)          '最終行（行番号の再採番も同時に行う）
                .TopRow = .Rows.Count - 1     'ｽｸﾛｰﾙﾊﾞｰの移動
                .Row = .Rows.Count - 1        'ｶﾚﾝﾄｾﾙの設定
                
                '@ﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfUseRecipe1)
                
                '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝの使用許可
                If .Rows.Count > 2 Then
                    cmdDelRecipe.Enabled = True
                End If
            
            End With
            
            '@行追加ﾎﾞﾀﾝの判別
            lblnAns = prvblnWPList_Chk
            If lblnAns = True Then
                '@行追加ﾎﾞﾀﾝを活性化
                cmdRowAdd.Enabled = True
            Else
                '@行追加ﾎﾞﾀﾝを非活性化
                cmdRowAdd.Enabled = False
            End If
            
             '@確定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdUpdate_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRowAdd_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDelRecipe_Click
    '機　能：ﾚｼﾋﾟ削除
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:56:24 N.Kasai
    '更新日：2008/12/25 (Thu) 11:34:20 M.Koni
    '備　考：2008/12/25 (Thu) 10:10:15 M.Koni       <案件No.03340> 表題欄削除のﾌｪｰﾙｾｰﾌ対応
    '　　　：
    Private Sub cmdDelRecipe_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelRecipe.Click
        
        Dim llngRowStart    As Integer  'ｽﾀｰﾄ行
        Dim llngRowEnd      As Integer  'ｴﾝﾄﾞ行
        Dim llngCount       As Integer  'ｶｳﾝﾀ
        Dim lstrWpId        As String   '装置ID
        Dim lblnAns         As Boolean  '結果判定

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfUseRecipe1
                '@装置IDを取得
                lstrWpId = .GetData(.Row, CMlngUseRecipeWPIDCol)
            
                '@使用ﾚｼﾋﾟを検索（前から）
                For llngCount = 1 To .Rows.Count - 1
                    '@装置IDで検索
                    If lstrWpId = .GetData(llngCount, CMlngUseRecipeWPIDCol) And _
                        .GetData(llngCount, CMlngUseRecipeWPIDCol) <> vbNullString Then
                        
                        llngRowStart = llngCount  '始めの行を取得
                        
                        Exit For
                    End If
                    '@装置IDで検索(空白の場合)
                    If .GetData(llngCount, CMlngUseRecipeWPIDCol) = vbNullString Then
                        llngRowStart = llngCount  '始めの行を取得
                        llngRowEnd = llngCount  '最後の行を取得
                        Exit For
                    End If
                Next
                
                '@使用ﾚｼﾋﾟを検索（後ろから）
                For llngCount = .Rows.Count - 1 To 1 Step -1
                    '@装置IDで検索
                    If lstrWpId = .GetData(llngCount, CMlngUseRecipeWPIDCol) And _
                        .GetData(llngCount, CMlngUseRecipeWPIDCol) <> vbNullString Then
                        
                        llngRowEnd = llngCount  '最後の行を取得
                        
                        Exit For
                    End If
                Next

        '@↓2008/12/25 (Thu) 10:10:15 M.Koni **************************************************
        '@ 削除開始行が表題欄（ｾﾞﾛ行目）となった場合は，削除処理をｽｷｯﾌﾟする。
        '@ 　→　存在しない行を削除しようとすると，ｴﾗｰになるので注意。
        '@
                If llngRowStart <> 0 Then

                    '@開始行から最終行まで削除
                    .Redraw = False
                    For llngCount = llngRowStart To llngRowEnd
                        .RemoveItem(llngRowStart)
                        
                        '@編集ﾌﾗｸﾞON
                        If mblnFormLoadFlag = False Then
                            '@ﾌｫｰﾑﾛｰﾄﾞ中以外の場合は編集ﾌﾗｸﾞをON
                            pblnEdit = True
                        End If
                    
                    Next
                    .Redraw = True
                End If

        '@↑2008/12/25 (Thu) 10:10:15 M.Koni **************************************************

                '@Noの再ｾｯﾄ
                Call prvNo_Set()
                '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝの使用許可
                If .Rows.Count = 1 Then
                    cmdDelRecipe.Enabled = False
                End If
            End With

            '@枚葉ﾚｼﾋﾟ可能判定
            Call prvOptRecipeEnabled_Set()
            
            '@行追加ﾎﾞﾀﾝの判別
            lblnAns = prvblnWPList_Chk
            If lblnAns = True Then
                '@行追加ﾎﾞﾀﾝを活性化
                cmdRowAdd.Enabled = True
            Else
                '@行追加ﾎﾞﾀﾝを非活性化
                cmdRowAdd.Enabled = False
            End If
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdUpdate_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDelRecipe_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                                   * 関数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：prvfrmxxEN01X3_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 11:13:25 N.Kasai
    '更新日：2006/06/21 (Wed) 11:13:25
    '備　考：
    Private Sub prvfrmxxEN01X3_Init()

        Try
            '@内容のｸﾘｱ
            
            '@ﾗﾍﾞﾙ
            lblConditionId.Text = vbNullString           '処理条件ｾｯﾄID
            lblVer.Text = vbNullString                   '処理条件Ver
            lblCategory.Text = vbNullString              'ｶﾃｺﾞﾘ
            lblSkipFlag.Text = vbNullString              '工程ｽｷｯﾌﾟ
            lblPortType.Text = vbNullString              'ﾎﾟｰﾄ状態
            lblTransMode.Text = vbNullString             '移載ﾓｰﾄﾞ
            lblBeforeCarrierTypeName.Text = vbNullString '移載元ｷｬﾘｱﾀｲﾌﾟ
            lblAfterCarrierTypeName.Text = vbNullString  '移載先ｷｬﾘｱﾀｲﾌﾟ
            '@ﾃｷｽﾄ
            txtComments.Text = vbNullString                 'ｺﾒﾝﾄ
            txtWorkCondition.Text = vbNullString            '作業ﾒﾓ
            txtRecipeFilter.Text = vbNullString             'レシピフィルタ(個別レシピ)
            '@ﾛｯｸ
            txtComments.Locked = True
            
            'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ（初期値）
            optRecipe0.Checked = True
            optRecipe2.Checked = True

            '@ｸﾞﾘｯﾄﾞ
            With vsfUseRecipe1                              '装置個別
                .Rows.Count = 1
                '@装置名が同じ場合はﾏｰｼﾞする
                .AllowMerging = AllowMergingEnum.Free
                .Cols(1).AllowMerging = True
                '@WF非表示
                .Cols(CMlngUseRecipeWFCol).Visible = False
            End With
            
            With vsfUseRecipe2                              '装置共通
                .Rows.Count = 1
                '@WF非表示
                .Cols(CMlngUseRecipeWFCol).Visible = False
            End With
            
            vsfUseWP.Rows.Count = 1                               'WP
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
            cmdUpdate.Enabled = False                       '確定
            cmdDelRecipe.Enabled = False                    '削除
            cmdUP.Enabled = False                           '▲ﾎﾞﾀﾝ
            cmdDown.Enabled = False                         '▼ﾎﾞﾀﾝ
           
            '@枚葉ﾚｼﾋﾟ選択許可
            '@ﾕｰｻﾞﾌﾟﾛｾｽの場合は枚葉ﾚｼﾋﾟを選択できない
            If pstrEN01X0KindFlag = CMstrClsLotProcessEdit Then
                optRecipe1.Enabled = True
                optRecipe3.Enabled = True
            Else
                optRecipe1.Enabled = False
                optRecipe3.Enabled = False
            End If
           
            '@装置共通ﾚｼﾋﾟ可能な場合
            If ptypMasCondDetailList.strWpCommonRecipeFlag = CMstrFlgOn Then
                stbRecipe.TabPages(CMlngCommonTab).Enabled = True
                stbRecipe.TabPages(CMlngOptionTab).Enabled = True
                If frmxxEN01X2.Instance.fraRecipeAll.Visible = True Then
                    '@共通設定
                    stbRecipe.SelectedIndex = CMlngCommonTab
                Else
                    '個別設定
                    stbRecipe.SelectedIndex = CMlngOptionTab
                End If
            Else
                stbRecipe.TabPages(CMlngCommonTab).Enabled = False
                stbRecipe.TabPages(CMlngOptionTab).Enabled = True
                '個別設定
                stbRecipe.SelectedIndex = CMlngOptionTab
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X3_Init"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01X3_Disp
    '機　能：ﾌｫｰﾑの初期ﾃﾞｰﾀ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:57:10 N.Kasai
    '更新日：2008/12/18 (Thu) 08:41:46 M.Koni
    '備　考：2008/12/18 (Thu) 08:40:02 M.Koni   <案件No.03340> 処理対象ｳｴﾊの表示設定対応
    '　　　：
    Private Sub prvfrmxxEN01X3_Disp()
        
        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim llngWpCnt       As Integer  '装置ｶｳﾝﾀ
        Dim lstrWpId        As String   'WPID退避
        Dim lstrWP          As String   'WPID退避
        Dim llngWpRow       As Integer  'WPｸﾞﾘｯﾄﾞ行
        Dim llngRecipeRow   As Integer  'ﾚｼﾋﾟｸﾞﾘｯﾄﾞ行
        Dim lblnGetFlag     As Boolean  '判定ﾌﾗｸﾞ
        Dim llngIndex       As Integer  'ｲﾝﾃﾞｯｸｽ退避
        Dim ltypProcWaferList   As ProcWaferList    'ﾛｯﾄｳｪﾊ情報
        Dim lstrSlotNo          As String           'proc.waferlist の SLOT_POSITION
        Dim lstrWaferRecipeKind As String           'proc.waferlist の WAFER_RECIPE_KIND
        Dim lstrOldWpName1      As String           '旧装置名(1)
        Dim lstrNewWpName1      As String           '新装置名(1)
        Dim llngWfListNo1       As Integer          'proc.waferlist の ﾘｽﾄ番号(1)
        Dim lstrOldWpName2      As String           '旧装置名(2)
        Dim lstrNewWpName2      As String           '新装置名(2)
        Dim llngWfListNo2       As Integer          'proc.waferlist の ﾘｽﾄ番号(2)
		Dim UserProcFlag		As Boolean	= False		'ユーザープロセスフラグ


        Try

        '@↓2008/12/18 (Thu) 08:44:09 M.Koni **************************************************
            
            '@ﾛｯﾄｳｴﾊ情報構造体の初期化
            mtypProcWaferList = ltypProcWaferList
            
            '@MSG【ﾛｯﾄｳｪﾊ情報取得】
            lblnGetFlag = pubblnProcWaferList_Sel(CMstrprocwaferlistVer, mtypProcWaferList, pstrSBID, pstrLotID)

            '@ proc.waferlist の応答がNGの場合
            If lblnGetFlag = False Then

                '@使用ﾚｼﾋﾟ削除  vsfUseRecipe(1)は，「装置個別ﾚｼﾋﾟ」のﾚｼﾋﾟ表
                vsfUseRecipe1.Rows.Count = 1

                '@確定ﾎﾞﾀﾝ使用不可
                cmdUpdate.Enabled = False
                '@ﾚｼﾋﾟ削除ﾎﾞﾀﾝ使用不可
                cmdDelRecipe.Enabled = False

                '@ﾚｼﾋﾟ取得失敗ｾｯﾄ
                mlngOptRecipeFlag = False

                Exit Sub
            End If

			'1文字目が@から始まるユーザープロセスIDの場合
			If Strings.Left$(pstrLotID, 1) = "@" Then
				UserProcFlag = True
			End If

        '@↑2008/12/18 (Thu) 08:44:09 M.Koni **************************************************

            '@ﾒｲﾝ画面処理条件ｾｯﾄID一覧より選択済みの処理条件ｾｯﾄIDとVerの取得
            With frmxxEN01X2.Instance.vsfConditionList1
                lblConditionId.Text = .GetData(.Row, CPlngvsfConListConID)      '処理条件ID
                lblVer.Text = .GetData(.Row, CPlngvsfConListVer)                '処理条件Ver
            End With
            
            lblCategory.Text = frmxxEN01X2.Instance.cmbConditionCategory.Text   'ｶﾃｺﾞﾘｰ
            
            '@ﾒｲﾝ画面より取得したﾏｽﾀ情報より表示
            With ptypMasCondDetailList
                '@工程ｽｷｯﾌﾟ
                If .strSkipFlag = CMstrFlgOn Then
                    lblSkipFlag.Text = "可能"        '可能
                Else
                    lblSkipFlag.Text = "不可能"      '不可能
                End If
            
                '@ﾎﾟｰﾄ属性
                If .strLoaderUnloaderFlag = CMstrFlgOn Then
                    lblPortType.Text = "Loader/Unloader運用"
                Else
                    lblPortType.Text = "UNIPORT運用"
                End If
            
                lblTransMode.Text = .strTransModeName                       '移載ﾓｰﾄﾞ名
                lblBeforeCarrierTypeName.Text = .strBeforeCarrierTypeName   '移載元ｷｬﾘｱ名
                lblAfterCarrierTypeName.Text = .strAfterCarrierTypeName     '移載先ｷｬﾘｱ名
                txtComments.Text = .strComments                             'ｺﾒﾝﾄ
            End With
            
            With frmxxEN01X2.Instance.vsfFlowList0
                '@編集ﾌﾗｸﾞ初期化
                pblnEdit = False
                
                '@初期化
                mlngOptRecipeFlag = True
                
                '@初期化
                plngLotCondDetailIndex = -1
                
                '@ﾛｯﾄ工順変更画面にﾚｼﾋﾟﾌﾗｸﾞによりﾚｼﾋﾟ区分を設定
                If .GetData(.Row, CPlngvsfFlowWFRecipeFlag) = CMstrFlgOn Then
                    optRecipe1.Checked = True   '枚葉ﾚｼﾋﾟｵﾝ
                    '@ﾛｯﾄｳｴﾊ情報取得に失敗したら
                    If mlngOptRecipeFlag = False Then
                        Exit Sub
                    End If
                    optRecipe3.Checked = True   '枚葉ﾚｼﾋﾟｵﾝ
                Else
                    optRecipe0.Checked = True   'ﾛｯﾄﾚｼﾋﾟｵﾝ
                    optRecipe2.Checked = True   'ﾛｯﾄﾚｼﾋﾟｵﾝ
                End If
                
                '@作業条件の表示
                txtWorkCondition.Text = .GetData(.Row, CPlngvsfFlowWorkCondition)
                If txtWorkCondition.Text = vbNullString Then
                    txtWorkCondition.Text = ptypMasCondDetailList.strWorkCondition          'ﾏｽﾀの作業条件
                End If
            End With
            
            '@退避ｲﾝﾃﾞｯｸｽの初期化
            llngIndex = -1
            
            '@処理条件情報の設定の確認
            With frmxxEN01X2.Instance.vsfFlowList0
            
                If .GetData(.Row, CPlngvsfFlowWFRecipeFlag) = CMstrFlgOn Or _
                        .GetData(.Row, CPlngvsfFlowLotRecipeFlag) = CMstrFlgOn Then
            
                    '@個別処理設定配列を検索
                    For llngCnt = 0 To ptypProcCondDetailList.lngProcCondDetailCnt - 1
                        '@工順番号が一致するｲﾝﾃﾞｯｸｽ取得
                        If ptypProcCondDetailList.typProcCondDetail(llngCnt).strAbsNo = .GetData(.Row, CPlngvsfFlowAbsNo) Then
                            '@ｲﾝﾃﾞｯｸｽを保持
                            plngLotCondDetailIndex = llngCnt
                            '@有効ﾃﾞｰﾀ
                            If ptypProcCondDetailList.typProcCondDetail(llngCnt).blnEnableFlag = True Then
                                llngIndex = llngCnt
                            End If
                            Exit For
                        End If
                    Next
                
                End If
            
            
            End With
            
            '@変数の初期化
            llngWpRow = 1
            llngRecipeRow = 1
            lblnGetFlag = False

            '@ｲﾝﾃﾞｯｸｽが存在する場合
            If llngIndex <> -1 Then
                '@格納構造体より個別処理条件を表示する。
                
                '@取得件数分だけﾙｰﾌﾟ
                With ptypMasCondDetailList
                    For llngCnt = 0 To .lngMasCondDetailCnt - 1
                        '@装置が異なる場合
                        If lstrWP <> .typMasCondDetail(llngCnt).strWpID Then
                            '@WPｸﾞﾘｯﾄﾞ表示
                            vsfUseWP.Rows.Count = .lngMasCondDetailCnt + 1                                                '最大行数変更
                            vsfUseWP.SetData(llngWpRow, CMlngUseWPNoCol, llngWpRow)                                       '№
                            vsfUseWP.SetData(llngWpRow, CMlngUseWPCKCol, CMstrFlgOff)                                     'ﾁｪｸﾎﾞｯｸｽOFF(初期値）
                            vsfUseWP.SetData(llngWpRow, CMlngUseWPIDCol, .typMasCondDetail(llngCnt).strWpID)              '装置ID
                            vsfUseWP.SetData(llngWpRow, CMlngUseWPNameCol, .typMasCondDetail(llngCnt).strWpName)          '装置名
                            '@ｶｳﾝﾀｱｯﾌﾟ
                            llngWpRow = llngWpRow + 1
                            '@WP_IDを退避
                            lstrWP = .typMasCondDetail(llngCnt).strWpID
                        End If
                    Next
                End With
                
                '@変数の初期化
                lstrWP = vbNullString
                llngWfListNo1 = 0
                llngWfListNo2 = 0

                With ptypProcCondDetailList.typProcCondDetail(llngIndex)
                    '@個別処理設定配列の詳細ﾃﾞｰﾀを検索
                    For llngWpCnt = 1 To .lngCondDetailCnt
                        With .typProcCond(llngWpCnt - 1)
                            '@装置個別ﾚｼﾋﾟ表示
                            vsfUseRecipe1.Rows.Count = vsfUseRecipe1.Rows.Count + 1
                            vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeNoCol, llngWpCnt)            '№
                            vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeWPNameCol, .strWpName)       '装置名
                            vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeWFCol, .strWfId)             'WFID
                            vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeIDCol, .strRecipeId)         'ﾚｼﾋﾟID
                            vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeVerCol, .strRecipeVersion)   'ﾚｼﾋﾟVer
                            vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeWPIDCol, .strWpID)           'WP_ID
                            vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeCommentsCol, .strComments)   'ﾚｼﾋﾟｺﾒﾝﾄ

        '@↓2008/12/18 (Thu) 08:40:02 M.Koni **************************************************
                            
                            '現在の装置を格納
                            lstrNewWpName1 = .strWpName

                            'ﾘｽﾄの先頭ならば，装置を一致化
                            If llngWpCnt = 1 Then
                                lstrNewWpName1 = .strWpName
                                lstrOldWpName1 = .strWpName
                            End If

                            '同一装置じゃないなら，ｳｴﾊﾘｽﾄ番号を初期化し，装置を退避
                            If lstrOldWpName1 <> lstrNewWpName1 Then
                                llngWfListNo1 = 0
                                lstrOldWpName1 = lstrNewWpName1
                            End If

							'ユーザープロセスの場合はtypProcWFListがnullとなりエラーになるため回避
							If UserProcFlag = False Then
								'@ Msg:"proc.waferlist" の SLOT_POSITION, WAFER_RECIPE_KIND を入手
								lstrSlotNo = mtypProcWaferList.typProcWFList(llngWfListNo1).strSlotPosition
                            End If

                            '@SLOT_POSITIONが得られなかったら，WAFER_RECIPE_KIND=0 とする。
                            If lstrSlotNo <> vbNullString Then
                                lstrWaferRecipeKind = mtypProcWaferList.typProcWFList(llngWfListNo1).strWaferRecipeKind
                            Else
                                lstrWaferRecipeKind = CMstrDoNotCare
                            End If

                            '@ WAFER_RECIPE_KIND が，枚葉設定不可の場合，ｸﾘｱ処理を行う
                            If lstrWaferRecipeKind = CMstrInvalidWfRecipe Then

                                '@枚葉設定不可領域のｸﾘｱ
                                vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeIDCol, vbNullString)
                                vsfUseRecipe1.SetData(llngWpCnt, CMlngUseRecipeCommentsCol, vbNullString)
                                    
                                '@ｸﾞﾚｰ表示化(無効化判断のための)
                                Dim newStyle As CellStyle = vsfUseRecipe1.Styles.Add("CustomStyle_BackColor_CMlngBackColorGray")
                                newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorGray)
                                Dim cellRange As CellRange = vsfUseRecipe1.GetCellRange(llngWpCnt, CMlngUseRecipeIDCol)
                                cellRange.Style = newStyle
                                Dim cellRange2 As CellRange = vsfUseRecipe1.GetCellRange(llngWpCnt, CMlngUseRecipeCommentsCol)
                                cellRange2.Style = newStyle

                            End If

        '@↑2008/12/18 (Thu) 08:40:02 M.Koni **************************************************

                            '@装置ID比較
                            If lstrWP <> .strWpID Then
                                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ判定
                                If .strDefaultFlag = CMstrFlgOn Then
                                    '@個別処理条件設定済みの場合はﾃﾞﾌｫﾙﾄﾌﾗｸﾞは立たない。
                                    '@何もしない
                                Else
                                    '@装置分ﾙｰﾌﾟ
                                    For llngWpRow = 1 To vsfUseWP.Rows.Count - 1
                                        If vsfUseWP.GetData(llngWpRow, CMlngUseWPIDCol) = .strWpID Then
                                            vsfUseWP.SetData(llngWpRow, CMlngUseWPCKCol, CMstrFlgOn)      'ﾁｪｯｸﾎﾞｯｸｽON
                                            Exit For
                                        End If
                                    Next
                                    
                                    '@WPIDが変更となった場合のみ変数に格納
                                    If lblnGetFlag = False Then
                                        lstrWpId = .strWpID     'WPID
                                        lblnGetFlag = True      'ﾌﾗｸﾞON
                                    End If
                                    
                                End If
                            End If
                            
                            '@装置共通ﾚｼﾋﾟ表示
                            If lstrWpId = .strWpID Then
                                vsfUseRecipe2.Rows.Count = llngRecipeRow + 1
                                vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeNoCol, llngRecipeRow)        '№
                                vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeWPNameCol, .strWpName)       '装置名
                                vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeWFCol, .strWfId)             'WFID
                                vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeIDCol, .strRecipeId)         'ﾚｼﾋﾟID
                                vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeVerCol, .strRecipeVersion)   'ﾚｼﾋﾟVer
                                vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeWPIDCol, .strWpID)           'WPID
                                vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeCommentsCol, .strComments)   'ｺﾒﾝﾄ

        '@↓2008/12/18 (Thu) 08:40:02 M.Koni **************************************************
                                
                                '現在の装置を格納
                                lstrNewWpName2 = .strWpName

                                'ﾘｽﾄの先頭ならば，装置を一致化
                                If llngRecipeRow = 1 Then
                                    lstrNewWpName2 = .strWpName
                                    lstrOldWpName2 = .strWpName
                                End If

                                '同一装置じゃないなら，ｳｴﾊﾘｽﾄ番号を初期化し，装置を退避
                                If lstrOldWpName2 <> lstrNewWpName2 Then
                                    llngWfListNo2 = 0
                                    lstrOldWpName2 = lstrNewWpName2
                                End If

                                '@ Msg:"proc.waferlist" の SLOT_POSITION, WAFER_RECIPE_KIND を入手
															'ユーザープロセスの場合はtypProcWFListがnullとなりエラーになるため回避
								If UserProcFlag = False Then
									lstrSlotNo = mtypProcWaferList.typProcWFList(llngWfListNo2).strSlotPosition
                                End If
                                '@SLOT_POSITIONが得られなかったら，WAFER_RECIPE_KIND=0 とする。
                                If lstrSlotNo <> vbNullString Then
                                    lstrWaferRecipeKind = mtypProcWaferList.typProcWFList(llngWfListNo2).strWaferRecipeKind
                                Else
                                    lstrWaferRecipeKind = CMstrDoNotCare
                                End If

                                '@ WAFER_RECIPE_KIND が，枚葉設定不可の場合，ｸﾘｱ処理を行う
                                If lstrWaferRecipeKind = CMstrInvalidWfRecipe Then

                                    '@枚葉設定不可領域のｸﾘｱ
                                    vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeIDCol, vbNullString)
                                    vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeCommentsCol, vbNullString)
                                    
                                    '@ｸﾞﾚｰ表示化(無効化判断のための)
                                    Dim newStyle As CellStyle = vsfUseRecipe2.Styles.Add("CustomStyle_BackColor_CMlngBackColorGray")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorGray)
                                    Dim cellRange As CellRange = vsfUseRecipe2.GetCellRange(llngRecipeRow, CMlngUseRecipeIDCol)
                                    cellRange.Style = newStyle
                                    Dim cellRange2 As CellRange = vsfUseRecipe2.GetCellRange(llngRecipeRow, CMlngUseRecipeCommentsCol)
                                    cellRange2.Style = newStyle

                                End If
                                llngRecipeRow = llngRecipeRow + 1
                                llngWfListNo2 = llngWfListNo2 + 1

                            End If
                            llngWfListNo1 = llngWfListNo1 + 1
                            
        '@↑2008/12/18 (Thu) 08:40:02 M.Koni **************************************************
                        
                        End With
                    Next
                    
                    '@個別処理設定配列が1件以上存在する場合
                    If .lngCondDetailCnt > 0 Then
                        vsfUseRecipe1.Row = 1  'ﾌｫｰｶｽのｾｯﾄ
                        vsfUseRecipe2.Row = 1  'ﾌｫｰｶｽのｾｯﾄ
                        vsfUseWP.Row = 1
                    End If
                End With
            Else

                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟの場合
                '@ﾏｽﾀより表示
                With ptypMasCondDetailList
                
                    '@取得件数分だけﾙｰﾌﾟ
                    For llngCnt = 1 To .lngMasCondDetailCnt
                    
                        '@装置個別ﾚｼﾋﾟに表示
                        vsfUseRecipe1.Rows.Count = .lngMasCondDetailCnt + 1
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeNoCol, llngCnt)                                            '№
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeWPNameCol, .typMasCondDetail(llngCnt - 1).strWpName)       '装置名
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeIDCol, .typMasCondDetail(llngCnt - 1).strRecipeId)         'ﾚｼﾋﾟ
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeWPIDCol, .typMasCondDetail(llngCnt - 1).strWpID)           '装置ID
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeVerCol, .typMasCondDetail(llngCnt - 1).strRecipeVersion)   'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeCommentsCol, .typMasCondDetail(llngCnt - 1).strComments)   'ｺﾒﾝﾄ
                        vsfUseRecipe1.SetData(llngCnt, CMlngUseRecipeWFCol, .typMasCondDetail(llngCnt - 1).strWfId)             'WFID

                        '@WPID比較
                        If lstrWP <> .typMasCondDetail(llngCnt - 1).strWpID Then
                            '@WPｸﾞﾘｯﾄﾞ表示
                            vsfUseWP.Rows.Count = vsfUseRecipe1.Rows.Count + 1
                            vsfUseWP.SetData(llngWpRow, CMlngUseWPNoCol, llngWpRow)
                                 
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ判定
                            If .typMasCondDetail(llngCnt - 1).strDefaultFlag = CMstrFlgOn Then
                                vsfUseWP.SetData(llngWpRow, CMlngUseWPCKCol, CMstrFlgOff)     'ﾁｪｯｸOFF
                            Else
                                vsfUseWP.SetData(llngWpRow, CMlngUseWPCKCol, CMstrFlgOn)      'ﾁｪｯｸON
                                '@初回読込判定
                                If lblnGetFlag = False Then
                                    lstrWpId = .typMasCondDetail(llngCnt - 1).strWpID
                                    lblnGetFlag = True
                                End If
                             End If
                             
                             vsfUseWP.SetData(llngWpRow, CMlngUseWPIDCol, .typMasCondDetail(llngCnt - 1).strWpID)              '装置ID
                             vsfUseWP.SetData(llngWpRow, CMlngUseWPNameCol, .typMasCondDetail(llngCnt - 1).strWpName)          '装置名
                            '@表示ｶｳﾝﾄｱｯﾌﾟ
                            llngWpRow = llngWpRow + 1
                            '@WPID退避
                            lstrWP = .typMasCondDetail(llngCnt - 1).strWpID
                        End If
                        
                        If lstrWpId = .typMasCondDetail(llngCnt - 1).strWpID Then
                        
                            vsfUseRecipe2.Rows.Count = vsfUseRecipe1.Rows.Count + 1
                            vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeNoCol, llngRecipeRow)                                    '№
                            vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeWPNameCol, .typMasCondDetail(llngCnt - 1).strWpName)     '装置名
                            vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeIDCol, .typMasCondDetail(llngCnt - 1).strRecipeId)       'ﾚｼﾋﾟ
                            vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeWPIDCol, .typMasCondDetail(llngCnt - 1).strWpID)         '装置ID
                            vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeVerCol, .typMasCondDetail(llngCnt - 1).strRecipeVersion) 'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                            vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeCommentsCol, .typMasCondDetail(llngCnt - 1).strComments) 'ｺﾒﾝﾄ
                            vsfUseRecipe2.SetData(llngRecipeRow, CMlngUseRecipeWFCol, .typMasCondDetail(llngCnt - 1).strWfId) 'WFID

                            llngRecipeRow = llngRecipeRow + 1

                        End If
                    Next llngCnt

                End With
                
                vsfUseWP.Rows.Count = llngWpRow
                vsfUseRecipe2.Rows.Count = llngRecipeRow
                
                '@ﾏｽﾀ処理条件配列が1件以上存在する場合
                If ptypMasCondDetailList.lngMasCondDetailCnt > 0 Then
                    vsfUseRecipe1.Row = 1  'ﾌｫｰｶｽのｾｯﾄ  vsfUseRecipe(1)は，「装置個別ﾚｼﾋﾟ」のﾚｼﾋﾟ表
                    vsfUseRecipe2.Row = 1  'ﾌｫｰｶｽのｾｯﾄ  vsfUseRecipe(2)は，「装置共通ﾚｼﾋﾟ」のﾚｼﾋﾟ表
                    vsfUseWP.Row = 1       'ﾌｫｰｶｽのｾｯﾄ  vsfUseWPは，「装置共通ﾚｼﾋﾟ」の装置表
                End If
            End If

            '@列幅自動調整
            ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
            vsfUseRecipe1.AllowMerging = AllowMergingEnum.None
            vsfUseRecipe1.AutoSizeCols(CMlngUseRecipeNoCol, CMlngUseRecipeWPIDCol, 6)
            vsfUseRecipe1.AllowMerging = AllowMergingEnum.Free
            vsfUseRecipe2.AutoSizeCols(CMlngUseRecipeNoCol, CMlngUseRecipeWPIDCol, 6)
            vsfUseWP.AutoSizeCols(vsfUseWP.Cols.Fixed, vsfUseWP.Cols.Count - 1, 6)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X3_Disp"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAryConData_Set
    '機　能：LOT処理条件詳細情報登録ﾃﾞｰﾀの作成
    '引　数：ptypLotCondDetailList:LOT処理条件詳細情報
    '戻り値：なし
    '作成日：2006/06/23 (Fri) 16:07:37 N.Kasai
    '更新日：2006/06/23 (Fri) 16:07:37
    '備　考：
    Private Sub prvAryConData_Set()
        
        Dim llngConDelCnt   As Integer  '詳細ｶｳﾝﾀ
        Dim llngRow         As Integer  '行ｶｳﾝﾀ
        Dim llngRecipeCnt   As Integer  'ﾚｼﾋﾟｶｳﾝﾄ
        Dim llngRecipeRow   As Integer  'ﾚｼﾋﾟ行ｶｳﾝﾄ
        
        
        Dim lstrWFID        As String   'WDID
        Dim lstrRecipeID    As String   'ﾚｼﾋﾟID
        Dim lblnRtn         As Boolean  '戻り値
        Dim llngRow1        As Integer  'ｶｳﾝﾀ大
        Dim llngRow2        As Integer  'ｶｳﾝﾀ小
        
        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        
        Try

            
            '@初期化
            llngConDelCnt = 0
            llngRecipeCnt = 1
            
            
        '@↓2006/08/18 (Fri) 13:34:07 N.Kasai **************************************************
            
            plngLotCondDetailIndex = -1
            
            '@個別処理設定配列を検索
            For llngCnt = 0 To ptypProcCondDetailList.lngProcCondDetailCnt - 1
                '@工順番号が一致するｲﾝﾃﾞｯｸｽ取得
                If ptypProcCondDetailList.typProcCondDetail(llngCnt).strAbsNo = frmxxEN01X2.Instance.vsfFlowList0.GetData(frmxxEN01X2.Instance.vsfFlowList0.Row, CPlngvsfFlowAbsNo) Then
                    '@ｲﾝﾃﾞｯｸｽを保持
                    plngLotCondDetailIndex = llngCnt
                    Exit For
                End If
            Next
        '@↑2006/08/18 (Fri) 13:34:07 N.Kasai **************************************************
            
            '@ｲﾝﾃﾞｯｸｽが存在しない場合
            If plngLotCondDetailIndex = -1 Then
            
                With ptypProcCondDetailList

                    '@個別処理設定配列を再定義
                    .lngProcCondDetailCnt = .lngProcCondDetailCnt + 1
                    Dim typProcCondDetail = New ProcCondDetail

                    '@工順番号・大工程・小工程をｾｯﾄ
                    With typProcCondDetail
                        .strAbsNo = frmxxEN01X2.Instance.vsfFlowList0.GetData(frmxxEN01X2.Instance.vsfFlowList0.Row, CPlngvsfFlowAbsNo)
                        .strOpID = frmxxEN01X2.Instance.vsfFlowList0.GetData(frmxxEN01X2.Instance.vsfFlowList0.Row, CPlngvsfFlowOpID)
                        .strStepID = frmxxEN01X2.Instance.vsfFlowList0.GetData(frmxxEN01X2.Instance.vsfFlowList0.Row, CPlngvsfFlowStepID)
                    End With
                    If .typProcCondDetail Is Nothing Then
                        .typProcCondDetail = New List(Of ProcCondDetail)
                    End If
                    .typProcCondDetail.Add(typProcCondDetail)

                    '@ｲﾝﾃﾞｯｸｽを設定
                    plngLotCondDetailIndex = .lngProcCondDetailCnt - 1
                End With
            End If
            
            Dim tmp As ProcCondDetail = ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex)
            tmp.blnEnableFlag = True
            ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex) = tmp

            '@個別ﾀﾌﾞの場合
            If stbRecipe.SelectedIndex = CMlngOptionTab Then
            
                '@LOT処理条件詳細情報(装置名)の再定義
                Dim typProCondtmp As ProcCondDetail = ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex)
                If typProCondtmp.typProcCond Is Nothing Then
                    typProCondtmp.typProcCond = New List(Of ProcCond)
                    ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex) = typProCondtmp
                Else
                    ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex).typProcCond.Clear()
                End If
                '@装置IDを検索
                For llngRow = 1 To vsfUseRecipe1.Rows.Count - 1
                
                    If vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeWPNameCol) <> vbNullString Then
                    
                        Dim typProcCondtmp = New ProcCond
                        
                        With typProcCondtmp
                            '@内容をｾｯﾄ
                            .strWpID = vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeWPIDCol)
                            .strWpName = vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeWPNameCol)
                            
                            '@ﾚｼﾋﾟIDが空白の場合はﾚｼﾋﾟIDは半角ｽﾍﾟｰｽ、ﾊﾞｰｼﾞｮﾝは「0」を送る【2005/07/19:SVより依頼】
                            If vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeIDCol) = vbNullString Then
                                .strRecipeId = CPstrSpace
                                .strRecipeVersion = "0"
                            Else
                                .strRecipeId = vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeIDCol)
                                .strRecipeVersion = vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeVerCol)
                            End If
                            
                            .strWfId = vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeWFCol)
                            .strComments = vsfUseRecipe1.GetData(llngRow, CMlngUseRecipeCommentsCol)
                        End With
                        ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex).typProcCond.Add(typProcCondtmp)
                        llngConDelCnt = llngConDelCnt + 1
                    End If
                Next
                
                '@詳細情報のｶｳﾝﾄを設定
                Dim tmp2 As ProcCondDetail = ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex)
                tmp2.lngCondDetailCnt = llngConDelCnt
                ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex) = tmp2
                
                lblnRtn = False
                
                '@ﾛｯﾄﾚｼﾋﾟの場合
                If optRecipe0.Checked = True Then
                
                    '@ﾛｯﾄﾚｼﾋﾟの場合
                    '@1件目のﾚｼﾋﾟIDと後続のﾚｼﾋﾟIDを比較し1件でも相違した場合は個別
                    lstrRecipeID = vsfUseRecipe1.GetData(1, CMlngUseRecipeIDCol)
                    
                    For llngRow1 = 1 To vsfUseRecipe1.Rows.Count - 1
                        If lstrRecipeID <> vsfUseRecipe1.GetData(llngRow1, CMlngUseRecipeIDCol) Then
                            lblnRtn = True
                            Exit For
                        End If
                    Next
                Else
                    '@枚葉ﾚｼﾋﾟの場合
                    For llngRow1 = 1 To vsfUseRecipe1.Rows.Count - 1
                        lstrWFID = vsfUseRecipe1.GetData(llngRow1, CMlngUseRecipeWFCol)
                        lstrRecipeID = vsfUseRecipe1.GetData(llngRow1, CMlngUseRecipeIDCol)
                            
                        For llngRow2 = llngRow1 + 1 To vsfUseRecipe1.Rows.Count - 1
                             
                            If lstrWFID = vsfUseRecipe1.GetData(llngRow2, CMlngUseRecipeWFCol) Then
                                If lstrRecipeID <> vsfUseRecipe1.GetData(llngRow2, CMlngUseRecipeIDCol) Then
                                    lblnRtn = True
                                    Exit For
                                End If
                            End If
                        Next
                        If lblnRtn = True Then
                            Exit For
                        End If
                    Next
                End If
            
                If lblnRtn = False Then
                    '@装置共通ﾚｼﾋﾟ
                    Dim tmp3 As ProcCondDetail = ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex)
                    tmp3.strWpCommonRecipeFlag = CMstrFlgOn
                    ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex) = tmp3
                Else
                    '@装置個別ﾚｼﾋﾟ
                    Dim tmp4 As ProcCondDetail = ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex)
                    tmp4.strWpCommonRecipeFlag = CMstrFlgOff
                    ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex) = tmp4
                End If
            Else
                '@LOT処理条件詳細情報(装置名)の再定義
                Dim typProCondtmp As ProcCondDetail = ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex)
                If typProCondtmp.typProcCond Is Nothing Then
                    typProCondtmp.typProcCond = New List(Of ProcCond)
                    ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex) = typProCondtmp
                Else
                    ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex).typProcCond.Clear()
                End If
                For llngRow = 1 To vsfUseWP.Rows.Count - 1
                    '@ﾁｪｯｸ
                    If vsfUseWP.GetCellCheck(llngRow, CMlngUseWPCKCol) = CheckEnum.Checked Then
                        For llngRecipeRow = 1 To vsfUseRecipe2.Rows.Count - 1
                            Dim typProcCondtmp = New ProcCond
                            
                            With typProcCondtmp
                                '@内容をｾｯﾄ
                                .strWpID = vsfUseWP.GetData(llngRow, CMlngUseWPIDCol)
                                .strWpName = vsfUseWP.GetData(llngRow, CMlngUseWPNameCol)
                                
                                '@ﾚｼﾋﾟIDが空白の場合はﾚｼﾋﾟIDは半角ｽﾍﾟｰｽ、ﾊﾞｰｼﾞｮﾝは「0」を送る【2005/07/19:SVより依頼】
                                If vsfUseRecipe2.GetData(llngRecipeRow, CMlngUseRecipeIDCol) = vbNullString Then
                                    .strRecipeId = CPstrSpace
                                    .strRecipeVersion = "0"
                                Else
                                    .strRecipeId = vsfUseRecipe2.GetData(llngRecipeRow, CMlngUseRecipeIDCol)
                                    .strRecipeVersion = vsfUseRecipe2.GetData(llngRecipeRow, CMlngUseRecipeVerCol)
                                End If
                                
                                .strWfId = vsfUseRecipe2.GetData(llngRecipeRow, CMlngUseRecipeWFCol)
                                .strComments = vsfUseRecipe2.GetData(llngRecipeRow, CMlngUseRecipeCommentsCol)
                                llngRecipeCnt = llngRecipeCnt + 1
                            End With
                            ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex).typProcCond.Add(typProcCondtmp)
                            llngConDelCnt = llngConDelCnt + 1
                        Next
                    End If
                Next
            
                '@詳細情報のｶｳﾝﾄを設定
                Dim tmp2 As ProcCondDetail = ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex)
                tmp2.lngCondDetailCnt = llngConDelCnt
                tmp2.strWpCommonRecipeFlag = CMstrFlgOn
                ptypProcCondDetailList.typProcCondDetail(plngLotCondDetailIndex) = tmp2
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvAryConData_Set"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvNo_Set
    '機　能：Noを振りなおす
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 16:02:11 N.Kasai
    '更新日：2006/06/21 (Wed) 16:02:11
    '備　考：
    Private Sub prvNo_Set()
        
        Dim llngRow As Integer 'ｸﾞﾘｯﾄの行

        Try

            With vsfUseRecipe1
                For llngRow = 1 To .Rows.Count - 1
                    .SetData(llngRow, CMlngUseRecipeNoCol, llngRow)
                Next
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvNo_Set"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvOptRecipeEnabled_Set
    '機　能：枚葉ﾚｼﾋﾟ可能判定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 11:58:37 N.Kasai
    '更新日：
    '備　考：
    Private Sub prvOptRecipeEnabled_Set()

        Dim lblnEnableKbn   As Boolean      '使用可能区分（False:無効、True:有効）
        Dim llngCnt         As Integer      'ｶｳﾝﾀ
        Dim llngWpCnt       As Integer      'ｶｳﾝﾀ

        Try
                
                
            '@枚葉ﾚｼﾋﾟ選択許可
            '@ﾕｰｻﾞﾌﾟﾛｾｽの場合は枚葉ﾚｼﾋﾟを選択できない
            If pstrEN01X0KindFlag = "2" Then
                Exit Sub
            End If
                
                
            '@使用可能区分の初期設定
            lblnEnableKbn = True    '有効
            
            '@装置個別ﾚｼﾋﾟﾀﾌﾞ
            If stbRecipe.SelectedIndex = CMlngOptionTab Then
            
                '@ﾊﾞｯﾁ装置の存在確認
                With vsfUseRecipe1
                    For llngCnt = 1 To .Rows.Count - 1
                        For llngWpCnt = 0 To mlngWpListCnt - 1
                            '@ﾊﾞｯﾁ装置が1件でも存在する場合は枚葉ﾚｼﾋﾟ設定を禁止にする
                            If .GetData(llngCnt, CMlngUseRecipeWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                If mtypWpList(llngWpCnt).strEqType = CPstrEqTypeBatch Then
                                    lblnEnableKbn = False    '無効
                                End If
                                Exit For
                            End If
                        Next llngWpCnt
                        If lblnEnableKbn = False Then
                            Exit For
                        End If
                    Next llngCnt
                End With
                
                '@枚葉ﾚｼﾋﾟ可能判定
                If lblnEnableKbn = True Then
                    optRecipe1.Enabled = True     '枚葉可能
                Else
                    optRecipe1.Enabled = False    '枚葉不可
                End If
                
                
                '@既に枚葉不可の場合は改めてﾁｪｯｸする必要なし。
                '@ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞの判定
                If lblnEnableKbn = True Then
                    With vsfUseRecipe1
                        For llngCnt = 1 To .Rows.Count - 1
                            For llngWpCnt = 0 To mlngWpListCnt - 1
                                If .GetData(llngCnt, CMlngUseRecipeWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                    '@枚葉ﾚｼﾋﾟ設定可否を判定（CMstrLotRecipeFlag：1:枚葉ﾚｼﾋﾟ設定不可）
                                    If mtypWpList(llngWpCnt).strLotRecipeFlag = CMstrLotRecipeFlag Then
                                        lblnEnableKbn = False    '無効
                                        Exit For
                                    End If
                                End If
                            Next llngWpCnt
                            If lblnEnableKbn = False Then
                                Exit For
                            End If
                        Next llngCnt
                    End With
                    
                    '@枚葉ﾚｼﾋﾟ可能判定
                    If lblnEnableKbn = True Then
                        optRecipe1.Enabled = True     '枚葉可能
                    Else
                        optRecipe1.Enabled = False    '枚葉不可
                    End If
                End If

            Else
                
                '@ﾊﾞｯﾁ装置の存在確認
                With vsfUseWP
                    For llngCnt = 1 To .Rows.Count - 1
                        For llngWpCnt = 0 To mlngWpListCnt - 1
                            '@ﾊﾞｯﾁ装置が1件でも存在する場合は枚葉ﾚｼﾋﾟ設定を禁止にする
                            '@ﾁｪｯｸ済のみ対象
                            If .GetCellCheck(llngCnt, CMlngUseWPCKCol) = CheckEnum.Checked Then
                                If .GetData(llngCnt, CMlngUseWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                    If mtypWpList(llngWpCnt).strEqType = CPstrEqTypeBatch Then
                                        lblnEnableKbn = False    '無効
                                        Exit For
                                    End If
                                End If
                            End If
                        Next llngWpCnt
                        If lblnEnableKbn = False Then
                            Exit For
                        End If
                    Next llngCnt
                End With
                
                
                '@枚葉ﾚｼﾋﾟ可能判定
                If lblnEnableKbn = True Then
                    optRecipe3.Enabled = True     '枚葉可能
                Else
                    optRecipe3.Enabled = False    '枚葉不可
                End If
                    
                    
                '@既に枚葉不可の場合は改めてﾁｪｯｸする必要なし。
                '@ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞの判定
                If lblnEnableKbn = True Then
                    With vsfUseWP
                        For llngCnt = 1 To .Rows.Count - 1
                            For llngWpCnt = 0 To mlngWpListCnt - 1
                            '@ﾁｪｯｸ済のみ対象
                            If .GetCellCheck(llngCnt, CMlngUseWPCKCol) = CheckEnum.Checked Then
                                If .GetData(llngCnt, CMlngUseWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                    '@枚葉ﾚｼﾋﾟ設定可否を判定（CMstrLotRecipeFlag：1:枚葉ﾚｼﾋﾟ設定不可）
                                    If mtypWpList(llngWpCnt).strLotRecipeFlag = CMstrLotRecipeFlag Then
                                        lblnEnableKbn = False    '無効
                                        Exit For
                                    End If
                                   
                                End If
                            End If
                            Next llngWpCnt
                            If lblnEnableKbn = False Then
                                Exit For
                            End If
                        Next llngCnt
                    End With
                    
                   '@枚葉ﾚｼﾋﾟ可能判定
                    If lblnEnableKbn = True Then
                        optRecipe3.Enabled = True     '枚葉可能
                    Else
                        optRecipe3.Enabled = False    '枚葉不可
                    End If
                End If
               
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvOptRecipeEnabled_Set"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnWfRecipe_Chk
    '機　能：確定ﾎﾞﾀﾝ押下時のWFﾚｼﾋﾟ設定可否ﾁｪｯｸ
    '引　数：llngUseRecipeIndex：ｸﾞﾘｯﾄﾞｲﾝﾃﾞｯｸｽ
    '戻り値：TRUE:正常、FALSE：異常
    '作成日：2006/07/12 (Wed) 11:59:08 N.Kasai
    '更新日：2006/07/12 (Wed) 11:59:08
    '備　考：
    Private Function prvblnWfRecipe_Chk(ByVal llngUseRecipeIndex As Integer) As Boolean

        Dim lblnEnableKbn   As Boolean      '使用可能区分（False:無効、True:有効）
        Dim llngCnt         As Integer      'ｶｳﾝﾀ
        Dim llngWpCnt       As Integer      'ｶｳﾝﾀ

        Try
            
            '@使用可能区分の初期設定
            prvblnWfRecipe_Chk = True
            
            lblnEnableKbn = True
            
            
            Select Case llngUseRecipeIndex
                Case 1
                    '@ﾊﾞｯﾁ装置の存在確認
                    With vsfUseRecipe1
                        For llngCnt = 1 To .Rows.Count - 1
                            For llngWpCnt = 0 To mlngWpListCnt - 1
                                '@ﾊﾞｯﾁ装置が1件でも存在する場合は枚葉ﾚｼﾋﾟ設定を禁止にする
                                If .GetData(llngCnt, CMlngUseRecipeWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                    If mtypWpList(llngWpCnt).strEqType = CPstrEqTypeBatch Then
                                        lblnEnableKbn = False    '無効
                                        Exit For
                                    End If
                                    
                                End If
                            Next llngWpCnt
                            If lblnEnableKbn = False Then
                                Exit For
                            End If
                        Next llngCnt
                    End With
                    
                    '@枚葉ﾚｼﾋﾟ可能判定
                    If lblnEnableKbn = False Then
                      prvblnWfRecipe_Chk = False
                      '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005Q, mtypWpList(llngWpCnt).strWpName, CPstrWFBatchNgMSG)
                            '@"<TRM4WI>$$装置[%1]は%2装置です。枚葉レシピの設定はできません。$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrFormTitle, True, 16)
                      Exit Function
                    End If
                    
                    
                    '@既に枚葉不可の場合は改めてﾁｪｯｸする必要なし。
                    '@ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞの判定
                    If lblnEnableKbn = True Then
                        With vsfUseRecipe1
                            For llngCnt = 1 To .Rows.Count - 1
                                For llngWpCnt = 0 To mlngWpListCnt - 1
                                    If .GetData(llngCnt, CMlngUseRecipeWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                        '@枚葉ﾚｼﾋﾟ設定可否を判定（CMstrLotRecipeFlag：1:枚葉ﾚｼﾋﾟ設定不可）
                                        If mtypWpList(llngWpCnt).strLotRecipeFlag = CMstrLotRecipeFlag Then
                                            lblnEnableKbn = False    '無効
                                            Exit For
                                        End If
                                       
                                    End If
                                Next llngWpCnt
                                If lblnEnableKbn = False Then
                                    Exit For
                                End If
                            Next llngCnt
                        End With
                        
                        '@枚葉ﾚｼﾋﾟ可能判定
                        If lblnEnableKbn = False Then
                        
                            prvblnWfRecipe_Chk = False
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005Q, mtypWpList(llngWpCnt).strWpName, CPstrWFRecipeNgMSG)
                            
                            '@"<TRM4WI>$$装置[%1]は%2装置です。枚葉レシピの設定はできません。$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrFormTitle, True, 16)
                            
                            Exit Function
                        End If
                    End If
            
                Case 2
                    '@ﾊﾞｯﾁ装置の存在確認
                    With vsfUseWP
                        For llngCnt = 1 To .Rows.Count - 1
                            For llngWpCnt = 0 To mlngWpListCnt - 1
                                '@ﾊﾞｯﾁ装置が1件でも存在する場合は枚葉ﾚｼﾋﾟ設定を禁止にする
                                '@ﾁｪｯｸ済のみ対象
                                If .GetCellCheck(llngCnt, CMlngUseWPCKCol) = CheckEnum.Checked Then
                                    If .GetData(llngCnt, CMlngUseWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                        If mtypWpList(llngWpCnt).strEqType = CPstrEqTypeBatch Then
                                            lblnEnableKbn = False    '無効
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next llngWpCnt
                            If lblnEnableKbn = False Then
                                Exit For
                            End If
                        Next llngCnt
                    End With
                    
                    '@枚葉ﾚｼﾋﾟ可能判定
                    If lblnEnableKbn = False Then
                      prvblnWfRecipe_Chk = False
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005Q, mtypWpList(llngWpCnt).strWpName, CPstrWFBatchNgMSG)
                            '@"<TRM4WI>$$装置[%1]は%2装置です。枚葉レシピの設定はできません。$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrFormTitle, True, 16)
                      Exit Function
                      
                    End If
                    
                    
                    '@既に枚葉不可の場合は改めてﾁｪｯｸする必要なし。
                    '@ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞの判定
                    If lblnEnableKbn = True Then
                        With vsfUseWP
                            For llngCnt = 1 To .Rows.Count - 1
                                For llngWpCnt = 0 To mlngWpListCnt - 1
                                '@ﾁｪｯｸ済のみ対象
                                If .GetCellCheck(llngCnt, CMlngUseWPCKCol) = CheckEnum.Checked Then
                                    If .GetData(llngCnt, CMlngUseWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                        '@枚葉ﾚｼﾋﾟ設定可否を判定（CMstrLotRecipeFlag：1:枚葉ﾚｼﾋﾟ設定不可）
                                        If mtypWpList(llngWpCnt).strLotRecipeFlag = CMstrLotRecipeFlag Then
                                            lblnEnableKbn = False    '無効
                                            Exit For
                                        End If
                                       
                                    End If
                                End If
                                Next llngWpCnt
                                If lblnEnableKbn = False Then
                                    Exit For
                                End If
                            Next llngCnt
                        End With
                        
                        '@枚葉ﾚｼﾋﾟ可能判定
                        If lblnEnableKbn = False Then
                        
                            prvblnWfRecipe_Chk = False
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005Q, mtypWpList(llngWpCnt).strWpName, CPstrWFRecipeNgMSG)
                            
                            '@"<TRM4WI>$$装置[%1]は%2装置です。枚葉レシピの設定はできません。$設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrFormTitle, True, 16)
                            
                            Exit Function
                        End If
                    End If
            End Select
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnWfRecipe_Chk"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvSetRecipe_Edit
    '機　能：ﾚｼﾋﾟIDｺﾝﾎﾞﾎﾞｯｸｽ　文字列作成
    '引　数：なし
    '戻り値：String ：ｺﾝﾎﾞﾎﾞｯｸｽ用文字列
    '作成日：2006/07/12 (Wed) 11:59:24 N.Kasai
    '更新日：2006/07/12 (Wed) 11:59:24
    '備　考：
    Private Function prvSetRecipe_Edit(ByVal sender As Object) As String
        
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer              'ﾙｰﾌﾟｶｳﾝﾀ2
        Dim llngCntCmbList          As Integer              '配列ｶｳﾝﾀ
        Dim llngWkCol               As Integer              '列
        Dim llngWkRow               As Integer              '行
        Dim lstrWkString            As List(Of String)      'ｺﾝﾎﾞ用文字列格納
        Dim lstrAddString           As String               'ｺﾝﾎﾞ用文字列格納2

        Try
            With sender
                '@ｶﾚﾝﾄ列/行を取得
                llngWkCol = .Col       '列
                llngWkRow = .Row       '行
                '@初期値設定
                lstrAddString = CMstrGridCombFirst
                '@配列ｶｳﾝﾀ初期化
                llngCntCmbList = 1
                '@配列定義
                lstrWkString = New List(Of String)
                '@ﾚｼﾋﾟ一覧取得件数分ﾙｰﾌﾟ
                For llngCnt = 0 To mlngRecipeNameListCnt - 1
                    '@ﾚｼﾋﾟ一覧格納用の装置IDとｸﾞﾘｯﾄﾞの装置IDが同じ場合
                    If .GetData(.Row, CMlngUseRecipeWPIDCol) = mtypMasRecipeNameList(llngCnt).strWpID Then
                        
                        '@ﾚｼﾋﾟ数分ﾙｰﾌﾟ
                        For llngCnt2 = 0 To mtypMasRecipeNameList(llngCnt).lngMasRecipeNameCnt - 1

                            '@配列定義
                            Dim typString As String
                            '@WPIDが一致したﾚｼﾋﾟIDを配列に格納
                            typString = mtypMasRecipeNameList(llngCnt).typMasRecipeName(llngCnt2).strRecipeId

                            '2022/06/29 フォト等で登録レシピが多い装置の場合
                            '全レシピをCombo設定すると描画が遅くなる(ユーザー要望)
                            'フィルタを付け該当するレシピをComboにする様に対応した

                            '装置個別レシピタブでレシピフィルタに値がある場合
                            If stbRecipe.SelectedIndex = CMlngOptionTab And _ 
                               txtRecipeFilter.Text <> vbNullString Then

                                Dim strTmp1 As String = typString.ToUpper
                                Dim strTmp2 As String = txtRecipeFilter.Text.ToUpper
                                
                                'フィルタ文字と部分一致した場合
                                If strTmp1.Contains(strTmp2) Then
                                    '@ｶｳﾝﾄｱｯﾌﾟ
                                    llngCntCmbList = llngCntCmbList + 1
                                    lstrWkString.Add(typString)
                                End If
                            Else
                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngCntCmbList = llngCntCmbList + 1
                                lstrWkString.Add(typString)
                            End If
                        Next
                        Exit For
                    End If
                Next

                '@配列が存在する場合
                If llngCntCmbList > 1 Then
                    '@取得した小工程名ﾘｽﾄを結合
                    For llngCnt = 0 To lstrWkString.Count - 1
                        '@結合文字列ﾁｪｯｸ
                        If llngCnt = 0 Then
                            '@最初の文字列の場合
                            lstrAddString = lstrWkString(llngCnt)
                        Else
                            '@2番目以降の場合(前回文字列に"|"を付加して結合)
                            lstrAddString = lstrAddString _
                                          & CMstrPipeString _
                                          & lstrWkString(llngCnt)
                        End If
                    Next
                End If

                '@取得件数ﾁｪｯｸ
                If llngCntCmbList - 1 = 1 Then
                    '@取得件数が１件のみの場合

                    '@文字列を変数に代入
                    lstrAddString = lstrWkString(0)
                End If
            End With
                
            '@----------------------------------------------------------------------
            '@Uni運用で枚葉ﾚｼﾋﾟが設定されている場合は
            '@ﾚｼﾋﾟﾘｽﾄ指定なし（空白）を表示選択可とする。(=Loader/Unloader運用の場合は表示選択不可)
            '@但しこの機能は客先送品可能な "PR","ES"のみ使用不可とする。（仕様）
            '@----------------------------------------------------------------------
            
            If stbRecipe.SelectedIndex = CMlngOptionTab Then
                
                '@装置個別ﾚｼﾋﾟで"枚葉ﾚｼﾋﾟ"が選択されている場合
                If optRecipe1.Checked = True Then
                    '@種別の判定
                    Select Case pstrFlowClass
                        '@PR,ESの場合
                        Case CPstrFlowClassPR, CPstrFlowClassES
                            '@ﾚｼﾋﾟIDの空白設定は不可
                        Case Else
                            '@ﾎﾟｰﾄ属性がUni運用の場合
                            If ptypMasCondDetailList.strLoaderUnloaderFlag = "0" Then
                                '@先頭に空白をｾｯﾄする(ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝは「0」をｾｯﾄする。
                                lstrAddString = CPstrSpace & "|" & lstrAddString
                            End If
                    End Select
                End If
            Else
                '@装置共通ﾚｼﾋﾟで"枚葉ﾚｼﾋﾟ"が選択されている場合
                If optRecipe3.Checked = True Then
                    '@種別の判定
                    Select Case pstrFlowClass
                        '@PR,ESの場合
                        Case CPstrFlowClassPR, CPstrFlowClassES
                            '@ﾚｼﾋﾟIDの空白設定は不可
                        Case Else
                            '@ﾎﾟｰﾄ属性がUni運用の場合
                            If ptypMasCondDetailList.strLoaderUnloaderFlag = "0" Then

                                '@先頭に空白をｾｯﾄする(ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝは「0」をｾｯﾄする。
                                lstrAddString = CPstrSpace & "|" & lstrAddString
                            End If
                    End Select
                End If
            
            End If
            
            '@ﾚｼﾋﾟID件数有無
            If lstrAddString = CMstrGridCombFirst Then
                prvSetRecipe_Edit = vbNullString
            Else
                '@結合した文字列を戻り値としてｾｯﾄする
                prvSetRecipe_Edit = lstrAddString
            End If
            
            '@配列のｸﾘｱ
            lstrWkString.Clear()

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvSetRecipe_Edit"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvSetWP_Edit
    '機　能：装置名ｺﾝﾎﾞﾎﾞｯｸｽ　文字列作成
    '引　数：llngWPCount:装置数
    '戻り値：String ：ｺﾝﾎﾞﾎﾞｯｸｽ用文字列
    '作成日：2006/07/12 (Wed) 12:00:39 N.Kasai
    '更新日：2006/07/12 (Wed) 12:00:39
    '備　考：
    Private Function prvSetWP_Edit(ByVal llngWpCount As Integer) As String
        
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2                As Integer              'ﾙｰﾌﾟｶｳﾝﾀ2
        Dim llngCntCmbList          As Integer              '配列ｶｳﾝﾀ
        Dim llngWkCol               As Integer              '列
        Dim llngWkRow               As Integer              '行
        Dim lstrWkString            As List(Of String)      'ｺﾝﾎﾞ用文字列格納
        Dim lstrAddString           As String               'ｺﾝﾎﾞ用文字列格納2
        Dim lblnFlg                 As Boolean              '重複項目有無ﾌﾗｸﾞ
        Dim lstrWkWPName            As String               'ｶﾚﾝﾄ行装置名
        Dim lstrTempName            As String               '配列文字列
        Dim lblnTemp                As Boolean              '配列判別

        Try
            
            '@WFﾚｼﾋﾟが取得できない場合は処理しない
            If mlngOptRecipeFlag = False Then
                Exit Function
            End If
            
            With vsfUseRecipe1
                '@ｶﾚﾝﾄ列/行を取得
                llngWkCol = .Col       '列
                llngWkRow = .Row       '行
                '@初期値設定
                lstrAddString = CMstrGridCombFirst
                
                '@配列ｶｳﾝﾀ初期化
                llngCntCmbList = 0
                
                '@ｶﾚﾝﾄ行の装置名を退避
                lstrWkWPName = .GetData(.Row, CMlngUseRecipeWPNameCol)
                
                '@配列定義
                lstrWkString = New List(Of String)
                
                '@装置数分ﾙｰﾌﾟ
                For llngCnt = 0 To llngWpCount - 1
                    '@一覧の装置数分ﾙｰﾌﾟ
                    For llngCnt2 = 1 To .Rows.Count - 1
                        '@ﾛｯﾄﾚｼﾋﾟが選択されている場合
                        If optRecipe0.Checked = True Then
                            '@ｶﾚﾝﾄ行以外の場合
                            If llngCnt2 <> .Row Then
                                '@使用ﾚｼﾋﾟ一覧にある装置はｺﾝﾎﾞのﾘｽﾄから外す
                                If .GetData(llngCnt2, CMlngUseRecipeWPNameCol) _
                                   = ptypWPList(llngCnt).strWpName Then
                                    
                                    lblnFlg = True
                                    Exit For
                                End If
                            End If
                        Else
                        '@枚葉ﾚｼﾋﾟが選択されている場合

                            '@ﾊﾞｯﾁ装置の場合はｺﾝﾎﾞのﾘｽﾄから外す
                            If ptypWPList(llngCnt).strEqType = CPstrEqTypeBatch Then
                                lblnFlg = True
                                Exit For
                            End If

                            '@ｶﾚﾝﾄ行以外又はｶﾚﾝﾄ行の装置名と同じ場合
                            If (.GetData(llngCnt2, CMlngUseRecipeWPNameCol) <> lstrWkWPName) Then
                                '@使用ﾚｼﾋﾟ一覧にある装置はｺﾝﾎﾞのﾘｽﾄから外す
                                If .GetData(llngCnt2, CMlngUseRecipeWPNameCol) _
                                   = ptypWPList(llngCnt).strWpName Then
                                    
                                    lblnFlg = True
                                    Exit For
                                End If
                            Else
                                lblnFlg = False
                            End If
                        End If
                    Next

                    '@使用ﾚｼﾋﾟ一覧内で重複していない場合
                    If lblnFlg <> True Then
                        '@配列文字列を定義
                        lstrTempName = ptypWPList(llngCnt).strWPName
                        
                        '@ﾌﾗｸﾞ初期化
                        lblnTemp = True
                        
                        '@既に配列に存在している場合には定義されている装置との重複ﾁｪｯｸを行う
                        If llngCntCmbList <> 0 Then
                            For llngCnt2 = 0 To llngCntCmbList - 1
                                '@既に配列に定義されている装置と比較して同じものがあった場合には配列に入れない
                                If lstrWkString(llngCnt2) = lstrTempName Then
                                    '@既に存在する
                                    lblnTemp = False
                                    Exit For
                                End If
                            Next llngCnt2
                        End If
                        
                        '@配列内に存在していない場合には配列へ格納
                        If lblnTemp = True Then
                            '@配列定義
                            Dim typString As String
                            '@装置ID、装置名を配列に格納
                            typString = lstrTempName
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCntCmbList = llngCntCmbList + 1
                            lstrWkString.Add(typString)
                        End If
                    End If
                    
                    '@ﾌﾗｸﾞ初期化
                    lblnFlg = False
                Next

                 '@配列が存在する場合
                 If llngCntCmbList > 0 Then
                    '@取得した小工程名ﾘｽﾄを結合
                    For llngCnt = 0 To lstrWkString.Count - 1
                        '@結合文字列ﾁｪｯｸ
                        If llngCnt = 0 Then
                            '@最初の文字列の場合
                            lstrAddString = lstrWkString(llngCnt)
                        Else
                            '@2番目以降の場合(前回文字列に"|"を付加して結合)
                            lstrAddString = lstrAddString _
                                          & CMstrPipeString _
                                          & lstrWkString(llngCnt)
                        End If
                    Next
                 End If

                 '@取得件数ﾁｪｯｸ
                 If llngCntCmbList = 1 Then
                    '@取得件数が１件のみの場合

                    '@文字列を変数に代入
                    lstrAddString = lstrWkString(0)
                End If
           End With

            '@結合した文字列を戻り値としてｾｯﾄする
            If lstrAddString = CMstrGridCombFirst Then
                prvSetWP_Edit = vbNullString
            Else
                prvSetWP_Edit = lstrAddString
            End If

            '@配列のｸﾘｱ
            lstrWkString.Clear()

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvSetWP_Edit"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnWPList_Chk
    '機　能：装置のﾘｽﾄﾁｪｯｸ
    '引　数：なし
    '戻り値：True:余剰装置名有/False:余剰装置名無
    '作成日：2006/07/12 (Wed) 12:01:09 N.Kasai
    '更新日：2006/07/12 (Wed) 12:01:09
    '備　考：
    Private Function prvblnWPList_Chk() As Boolean
        
        Dim lstrWkString        As List(Of String)  '退避装置ID(Msg)
        Dim llngWkCnt           As Integer      '退避装置ｶｳﾝﾄ(Msg)
        Dim lstrGrString        As List(Of String)  '退避装置ID(Msg)
        Dim llngGrCnt           As Integer      '退避装置ｶｳﾝﾄ(Msg)
        Dim llngCnt             As Integer      '汎用ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt2            As Integer      '汎用ﾙｰﾌﾟｶｳﾝﾀ2
        Dim lstrTempName        As String       '退避文字列(装置名)
        Dim lblnTemp            As Boolean      '配列重複有無ﾌﾗｸﾞ

        Try
            
            '@結果初期化
            prvblnWPList_Chk = False
            
            lstrWkString = New List(Of String)
            lstrGrString = New List(Of String)

            '@現在の装置(使用ﾚｼﾋﾟ)のｶｳﾝﾄを取得
            With vsfUseRecipe1
                '@配列ｶｳﾝﾀ初期化
                llngWkCnt = 0
                llngGrCnt = 0
                
                '@取得したﾒｯｾｰｼﾞから装置数を取得
                For llngCnt = 0 To mlngWpListCnt - 1
                    '@配列文字列を定義(装置ID)
                    lstrTempName = mtypWpList(llngCnt).strWpID
                    
                    '@ﾌﾗｸﾞ初期化
                    lblnTemp = True
                    
                    '@既に配列に存在している場合には定義されている装置との重複ﾁｪｯｸを行う
                    If llngWkCnt <> 0 Then
                        For llngCnt2 = 0 To llngWkCnt - 1
                            '@既に配列に定義されている装置と比較して同じものがあった場合には配列に入れない
                            If lstrWkString(llngCnt2) = lstrTempName Then
                                '@既に存在する
                                lblnTemp = False
                                Exit For
                            End If
                        Next llngCnt2
                    End If
                    
                    '@配列内に存在していない場合には配列へ格納
                    If lblnTemp = True Then
                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngWkCnt = llngWkCnt + 1
                        
                        '@装置IDを配列に格納
                        lstrWkString.Add(lstrTempName)
                    End If
                Next
                
                '@一覧から装置数を取得
                For llngCnt = 1 To .Rows.Count - 1
                    '@配列文字列を定義(装置ID)
                    lstrTempName = .GetData(llngCnt, CMlngUseRecipeWPIDCol)
                    
                    '@ﾌﾗｸﾞ初期化
                    lblnTemp = True
                    
                    '@既に配列に存在している場合には定義されている装置との重複ﾁｪｯｸを行う
                    If llngGrCnt <> 0 Then
                        For llngCnt2 = 0 To llngGrCnt - 1
                            '@既に配列に定義されている装置と比較して同じものがあった場合には配列に入れない
                            If lstrGrString(llngCnt2) = lstrTempName Then
                                '@既に存在する
                                lblnTemp = False
                                Exit For
                            End If
                        Next llngCnt2
                    End If
                    
                    '@配列内に存在していない場合には配列へ格納
                    If lblnTemp = True Then
                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngGrCnt = llngGrCnt + 1
                        
                        '@装置IDを配列に格納
                        lstrGrString.Add(lstrTempName)
                    End If
                Next
                
                '@装置名の配列数から結果を返す
                If llngWkCnt <> llngGrCnt Then
                    '@余剰装置有
                    prvblnWPList_Chk = True
                Else
                    '@余剰装置無
                    prvblnWPList_Chk = False
                End If
            End With

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnWPList_Chk"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：vsfUseWP_Click
    '機　能：WPｸﾞﾘｯﾄﾞﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:01:23 N.Kasai
    '更新日：2006/07/12 (Wed) 12:01:23
    '備　考：
    Private Sub vsfUseWP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfUseWP.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfUseWP.Rows.Count <= vsfUseWP.Rows.Fixed Then
                Return
            End If

            With vsfUseWP
                   '@明細行以外は変更不可
                   If .MouseRow < .Rows.Fixed Or .Row < .Rows.Fixed Then
                       Exit Sub
                   End If
                   
                   '@対象列（CMlngUseWPCKCol）
                   Select Case .Col
                           Case CMlngUseWPCKCol
                       '@ﾁｪｯｸﾌﾗｸﾞ
                           If .GetCellCheck(.Row, CMlngUseWPCKCol) = CheckEnum.Unchecked Then
                               '@ﾁｪｯｸなし→ﾁｪｯｸ
                               .AllowEditing = True
                               .SetCellCheck(.Row, CMlngUseWPCKCol, CheckEnum.Checked)     'ﾁｪｯｸ
                               .AllowEditing = False
                           Else
                               '@ﾁｪｯｸ→ﾁｪｯｸなし
                               .AllowEditing = True
                               .SetCellCheck(.Row, CMlngUseWPCKCol, CheckEnum.Unchecked)   'ﾁｪｯｸ解除
                               .AllowEditing = False
                           End If
                   End Select
            
             End With
             
             '@確定ﾎﾞﾀﾝﾁｪｯｸ
             Call prvcmdUpdate_Chk()
             '@枚葉ﾚｼﾋﾟ使用可否ﾁｪｯｸ
             Call prvOptRecipeEnabled_Set()
             
            '@編集ﾌﾗｸﾞON
            If mblnFormLoadFlag = False Then
                '@ﾌｫｰﾑﾛｰﾄﾞ中以外の場合は編集ﾌﾗｸﾞをON
                pblnEdit = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfUseWP_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdUpdate_Chk
    '機　能：確定ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/21 (Wed) 16:10:36 N.Kasai
    '更新日：2009/01/30 (Fri) 17:06:57 M.Koni
    '備　考：
    '　　　：2008/11/10 (Mon) 10:25:23 M.Koni   誤記訂正 Exit Sub -> Exit For <案件No.03256>
    '　　　：2009/01/30 (Fri) 17:00:45 M.Koni   枚葉ﾚｼﾋﾟの「確定」ﾎﾞﾀﾝ有効条件変更 <案件No.03345>
    Private Sub prvcmdUpdate_Chk()

        Dim lblnRtn     As Boolean  '汎用戻り値
        Dim lblnRtn1    As Boolean  '汎用戻り値
        Dim lblnRtn2    As Boolean  '汎用戻り値
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        Dim lstrWpId    As String   '装置ID退避
        Dim llngRow     As Integer  'ｶｳﾝﾀ
        Dim llngRow2    As Integer  'ｶｳﾝﾀ小

        Try
            '@ﾁｪｯｸ
            '@共通ﾚｼﾋﾟ設定ﾀﾌﾞの場合
            If stbRecipe.SelectedIndex = CMlngCommonTab Then
                With vsfUseWP
                    '@ﾌﾗｸﾞ初期化
                    lblnRtn1 = False
                    
                    '@一覧から装置数を取得
                    For llngCnt = 1 To .Rows.Count - 1
                        If .GetCellCheck(llngCnt, CMlngUseWPCKCol) = CheckEnum.Checked Then
                           lblnRtn1 = True
                        End If
                    Next
                End With
                
                With vsfUseRecipe2
                    '@ﾌﾗｸﾞ初期化
                    lblnRtn2 = False
                    
                    '@一覧から装置数を取得
                    For llngCnt = 1 To .Rows.Count - 1
                        If .GetData(llngCnt, CMlngUseRecipeIDCol) <> CPstrSpace Then
                           lblnRtn2 = True
                           Exit For
                        End If
                    Next
                End With
                
                '@結果判定
                If lblnRtn1 = False Or lblnRtn2 = False Then
                    '@確定ﾎﾞﾀﾝ使用不可
                    cmdUpdate.Enabled = False
                Else
                    '@確定ﾎﾞﾀﾝ使用可
                    cmdUpdate.Enabled = True
                End If
            Else
                '@確定ﾎﾞﾀﾝ使用不可
                cmdUpdate.Enabled = False

                With vsfUseRecipe1
                    '@ﾀｲﾄﾙ以外存在しない
                    If .Rows.Count = 1 Then
                        '@処理抜け
                        Exit Sub
                    End If

                    '@ﾛｯﾄﾚｼﾋﾟの場合
                    If optRecipe0.Checked = True Then
                        For llngRow = 1 To .Rows.Count - 1
                            '@装置またはﾚｼﾋﾟが設定されていない場合
                            If .GetData(llngRow, CMlngUseRecipeWPNameCol) = vbNullString Or _
                                .GetData(llngRow, CMlngUseRecipeIDCol) = vbNullString Then
                                '@処理を抜ける
                                Exit Sub
                            End If
                        Next
                    End If
                    
                    '@枚葉ﾚｼﾋﾟﾁｪｯｸ（枚葉ﾚｼﾋﾟの場合のみﾚｼﾋﾟIDが空白の設定が可能のため）
                    If optRecipe1.Checked = True Then

        '@↓2009/01/30 (Fri) 17:00:45 M.Koni **************************************************
                        
                        For llngRow = 1 To .Rows.Count - 1

        '                   '@装置またはﾚｼﾋﾟが設定されていない場合
        '                   If .Cell(flexcpText, llngRow, CMlngUseRecipeWPNameCol) = vbNullString And _
        '                       .Cell(flexcpText, llngRow, CMlngUseRecipeIDCol) = vbNullString Then
                                
                            '@ 今まで，「装置名が空白」且つ「ﾚｼﾋﾟが空白」となっていたが，装置名が空白で，
                            '@ ﾚｼﾋﾟが設定される状況はありえない。
                            '@ 　よって，装置名が空白となっている状態では「確定」ﾎﾞﾀﾝ有効を除外する。
                            '@
                            '@ 装置が設定されていない場合
                            
                            If .GetData(llngRow, CMlngUseRecipeWPNameCol) = vbNullString Then
                                '@処理を抜ける
                                Exit Sub
                            End If
                        Next

        '@↑2009/01/30 (Fri) 17:00:45 M.Koni **************************************************


                    
                        '@変数初期化
                        lblnRtn = False

                        '@退避変数初期化
                        lstrWpId = vbNullString

                        '@WFID分ﾙｰﾌﾟ
                        For llngRow = 1 To .Rows.Count - 1
                            If lstrWpId <> .GetData(llngRow, CMlngUseRecipeWPIDCol) Then
                               lstrWpId = .GetData(llngRow, CMlngUseRecipeWPIDCol)
                                '@ﾌﾗｸﾞ初期化
                                lblnRtn = False

                                For llngRow2 = 1 To .Rows.Count - 1
                                    If lstrWpId = .GetData(llngRow2, CMlngUseRecipeWPIDCol) Then
                                        '@ﾚｼﾋﾟが1件でも設定されている場合
                                        If .GetData(llngRow2, CMlngUseRecipeIDCol) <> CPstrSpace And _
                                           .GetData(llngRow2, CMlngUseRecipeIDCol) <> vbNullString Then
                                            '@ﾌﾗｸﾞ立て
                                            lblnRtn = True
                                            
                                            '@処理抜け
                                            Exit For
                                        End If
                                    End If
                                Next
                               
                                '@ﾌﾗｸﾞが立っていない場合
                                If lblnRtn = False Then
        '@↓2008/11/10 (Mon) 10:18:56 M.Koni **************************************************
                                    '@処理を抜ける
                                    Exit For
        '@↑2008/11/10 (Mon) 10:18:56 M.Koni **************************************************
                                End If
                            End If
                        Next
                    End If
                End With
                
                '@確定ﾎﾞﾀﾝ使用可
                cmdUpdate.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmdUpdate_Chk"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRecipeBlank_Chk
    '機　能：枚葉ﾚｼﾋﾟIDﾁｪｯｸ
    '引　数：llngUseRecipeIndex：ｸﾞﾘｯﾄﾞｲﾝﾃﾞｯｸｽ
    '戻り値：TRUE:正常、FALSE：異常
    '作成日：2006/08/21 (Mon) 10:53:16 N.Kasai
    '更新日：2008/10/14 (Tue) 16:14:42 M.Koni
    '備　考：
    '　　　：2007/08/27 (Mon) 18:27:22 N.Kasai  №02141
    '　　　：2008/10/14 (Tue) 16:14:52 M.Koni   枚葉ﾚｼﾋﾟ設定状態確認処理追加。<案件No.02871>
    Private Function prvblnRecipeBlank_Chk(ByVal llngUseRecipeIndex As Integer) As Boolean
        
        Dim llngCnt             As Integer          'ｶｳﾝﾀ
        Dim lstrWpId            As String           'WPID退避
        Dim llngWpCnt           As Integer          'WP構造体ｶｳﾝﾄ
        Dim lstrLotRecipeFlag   As String           'M_WP.LOT_RECIPE_FLAG退避
        Dim lstrRecipeID        As String           'ﾚｼﾋﾟID退避
        Dim llngCnt2            As Integer          'ｶｳﾝﾀ小
        Dim lblnCheckFlag       As Boolean          'ﾁｪｯｸﾌﾗｸﾞ（True:ﾁｪｯｸ要、False:ﾁｪｯｸ不要）
        Dim lobjRecipe          As Object           'NSYS OBJECT     
    '@↓2008/10/14 (Tue) 16:20:36 M.Koni **************************************************
        Dim lstrChkWfId         As String           'WF_ID確認用ﾊﾞｯﾌｧ
        Dim llngWfListQty       As Integer          'ﾛｯﾄﾘｽﾄ内のｳｴﾊ数
        Dim llngWFListCnt       As Integer          'ｳｴﾊ数ｶｳﾝﾀ
        Dim lstrWaferRecipeKind As String           'WAFER_RECIPE_KIND確認用ﾊﾞｯﾌｧ
    '@↑2008/10/14 (Tue) 16:20:36 M.Koni **************************************************
        
        Try
            '@----------------------------------------------------------------------
            '@ﾁｪｯｸ内容
            '@Uni運用で枚葉ﾚｼﾋﾟが設定されている場合は
            '@ﾚｼﾋﾟﾘｽﾄ指定なし（空白）を表示選択可とする。
            '@但しこの機能は客先送品可能な "PR","ES"のみ使用不可とする。（仕様）
            '@Loader/Unloader運用の場合はﾚｼﾋﾟIDの空白は不可（これも仕様）
            '@M_WP.LOT_RECIPE_FLAGを判定し、単一枚葉ﾚｼﾋﾟの場合は異なるﾚｼﾋﾟIDの設定は不可
            '@但し、ﾚｼﾋﾟID空白はOKです。
            '@----------------------------------------------------------------------

            '@引数初期化
            prvblnRecipeBlank_Chk = True

            'NSYS グリッド設定
            Select Case llngUseRecipeIndex
                '@装置個別ﾚｼﾋﾟの場合
                Case 1
                    lobjRecipe = vsfUseRecipe1
                '@装置共通ﾚｼﾋﾟ
                Case 2
                    lobjRecipe = vsfUseRecipe2
            End Select

            '@種別の判定
            Select Case pstrFlowClass
                
                '@PR,ESの場合
                Case CPstrFlowClassPR, CPstrFlowClassES

        '@↓2008/10/14 (Tue) 16:12:32 M.Koni **************************************************

                    '@ﾚｼﾋﾟIDの空白設定は基本的に不可
                    '@ﾁｪｯｸ処理へ

                    
                    With CType(lobjRecipe, C1FlexGrid)
            
                        For llngCnt = 1 To .Rows.Count - 1
                            '@ﾚｼﾋﾟID = 空白ﾁｪｯｸ
                            If .GetData(llngCnt, CMlngUseRecipeIDCol) = vbNullString Or _
                                .GetData(llngCnt, CMlngUseRecipeIDCol) = CPstrSpace Then

                                '@空白ﾚｼﾋﾟが見つかったので，本当にNGかどうか判断する。
                                '@対象WF_ID の WAFER_RECIPE_KIND がどうなっているか，proc.waferlist の格納先
                                '@である，mtypProcWaferList を検索し，枚葉ﾚｼﾋﾟの設定可否を判断する。
                                '@
                                '@"ﾚｼﾋﾟID = 空白" 時のWFIDを入手
                                lstrChkWfId = .GetData(llngCnt, CMlngUseRecipeWFCol)

                                '@ｳｪﾊﾚｼﾋﾟ設定状態を確認するため，mtypProcWaferList 内のｳｴﾊ数入手
                                llngWfListQty = mtypProcWaferList.lngProcWFListCnt

                                '@変数初期化
                                lstrWaferRecipeKind = CMstrDoNotCare

                                With mtypProcWaferList

                                    '@ｳｴﾊﾘｽﾄ内から対象のWF_IDを検索　ﾚｼﾋﾟIDが，Null/空白のｳｴﾊのｳｪﾊﾚｼﾋﾟ設定状態を確認
                                    For llngWFListCnt = 0 To llngWfListQty - 1

                                        '@一致するWF_IDを検索
                                        If .typProcWFList(llngWFListCnt).strWfId = lstrChkWfId Then
                                            '@そのｳｴﾊの WAFER_RECIPE_KIND を入手
                                            lstrWaferRecipeKind = .typProcWFList(llngWFListCnt).strWaferRecipeKind
                                            '@ﾙｰﾌﾟを抜ける
                                            Exit For
                                        End If
                                    Next
                                End With

                                '@ｳｴﾊﾚｼﾋﾟ（枚葉ﾚｼﾋﾟ）設定可否判断　（ここは，PR,ES品の処理内）
                                '@入手した WAFER_RECIPE_KIND を評価し判断を決定する。
                                '@
                                '@ WAFER_RECIPE_KIND = 0 　どちらでも可(CMstrDoNotCare) → あり得ない設定
                                '@ WAFER_RECIPE_KIND = 1 　枚葉指定必須判断(CMstrRequireWfRecipe)
                                '@ WAFER_RECIPE_KIND = 2 　枚葉指定不可判断(CMstrInvalidWfRecipe)
                                '@
                                '@ 空白の場合，WAFER_RECIPE_KIND = 0 or 2 であるなら正常判断となるが，
                                '@ ここは，PR,ES品のみ走るので，WAFER_RECIPE_KIND = 2 ならＯＫ判断とする。

                                Select Case lstrWaferRecipeKind
                                    '@どちらでも可の場合(WAFER_RECIPE_KIND = 0)
                                    Case CMstrDoNotCare
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008Q, pstrFlowClass & "品")
                                            '@"<TRM8QW>$$[%1]です。未設定のレシピIDが存在します。$設定を見直してしてください。"
                                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                            prvblnRecipeBlank_Chk = False
                                            Exit Function


                                    '@枚葉指定必須判断(WAFER_RECIPE_KIND = 1)
                                    Case CMstrRequireWfRecipe
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008Q, pstrFlowClass & "品")
                                            '@"<TRM8QW>$$[%1]です。未設定のレシピIDが存在します。$設定を見直してしてください。"
                                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                            prvblnRecipeBlank_Chk = False
                                            Exit Function

                                    '@枚葉指定不可判断(WAFER_RECIPE_KIND = 2)
                                    Case CMstrInvalidWfRecipe
                                            '@ここは正しい設定なので，何もしない。

                                    '@その他(ここが走ることは無い)
                                    Case Else
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                                            '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                            prvblnRecipeBlank_Chk = False
                                            Exit Function

                                End Select
                            End If
                        Next

                    End With

        '@↑2008/10/14 (Tue) 16:12:32 M.Koni **************************************************

                Case Else
                    '@ﾎﾟｰﾄ属性がLoader/Unloader運用の場合
                    '@ﾚｼﾋﾟIDの空白設定は不可
                    '@ﾁｪｯｸ処理へ
                    
                    If ptypMasCondDetailList.strLoaderUnloaderFlag = "1" Then
                    
                        With CType(lobjRecipe, C1FlexGrid)
                
                            For llngCnt = 1 To .Rows.Count - 1
                                '@ﾚｼﾋﾟID = 空白ﾁｪｯｸ
                                If .GetData(llngCnt, CMlngUseRecipeIDCol) = vbNullString Or _
                                    .GetData(llngCnt, CMlngUseRecipeIDCol) = CPstrSpace Then
                                    
                                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008Q, lblPortType.Text)
                                    '@"<TRM8QW>$$[%1]です。未設定のレシピIDが存在します。$設定を見直してしてください。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    prvblnRecipeBlank_Chk = False
                                    Exit Function
                                End If
                            Next
                
                        End With
                    End If
            End Select
            
        '@↓2007/08/27 (Mon) 18:27:15 N.Kasai **************************************************
            '@M_WP.LOT_RECIPE_FLAGの判定
            '@M_WP.LOT_RECIPE_FLAG = "2"（単一枚葉ﾚｼﾋﾟ可能）の場合
            '@ﾁｪｯｸ処理へ
            Select Case llngUseRecipeIndex
                '@装置個別ﾚｼﾋﾟの場合
                Case 1
                    '@装置ID退避
                    lstrWpId = vbNullString
                    
                    With vsfUseRecipe1
                        For llngCnt = 1 To .Rows.Count - 1
                            If .GetData(llngCnt, CMlngUseRecipeWPIDCol) <> lstrWpId Then
                                lstrWpId = .GetData(llngCnt, CMlngUseRecipeWPIDCol)
                                For llngWpCnt = 0 To mlngWpListCnt - 1
                                    If .GetData(llngCnt, CMlngUseRecipeWPIDCol) = mtypWpList(llngWpCnt).strWpID Then
                                        lstrLotRecipeFlag = mtypWpList(llngWpCnt).strLotRecipeFlag
                                        Exit For
                                    End If
                                Next
                
                                '@単一枚葉ﾚｼﾋﾟの場合
                                If lstrLotRecipeFlag = CPstrWfRecpSiFlag Then
                                    
                                    '@ﾚｼﾋﾟIDを格納
                                    lstrRecipeID = .GetData(llngCnt, CMlngUseRecipeIDCol)
                                    
                                    '@ﾚｼﾋﾟは空白以外
                                    If lstrRecipeID <> vbNullString And lstrRecipeID <> CPstrSpace Then
                                        For llngCnt2 = 1 To .Rows.Count - 1
                                            If .GetData(llngCnt, CMlngUseRecipeWPIDCol) = .GetData(llngCnt2, CMlngUseRecipeWPIDCol) _
                                                And .GetData(llngCnt2, CMlngUseRecipeIDCol) <> vbNullString _
                                                And .GetData(llngCnt2, CMlngUseRecipeIDCol) <> CPstrSpace _
                                                And llngCnt2 <> llngCnt Then
                                                '@ﾚｼﾋﾟID相違
                                                If lstrRecipeID <> .GetData(llngCnt2, CMlngUseRecipeIDCol) Then
                                                    '@"<TRM0GW>$$装置[%1]は%2装置です。$異なったレシピの設定はできません。$設定を見直してください。"
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000G, mtypWpList(llngWpCnt).strWpName, CPstrWFRecipeMSG)
                                                    '@警告ﾒｯｾｰｼﾞ
                                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrFormTitle, True, 16)
                                                    prvblnRecipeBlank_Chk = False
                                                    Exit Function
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                
                            Else
                                '@単一枚葉ﾚｼﾋﾟの場合
                                If lstrLotRecipeFlag = CPstrWfRecpSiFlag Then
                                    
                                    '@ﾚｼﾋﾟIDを格納
                                    lstrRecipeID = .GetData(llngCnt, CMlngUseRecipeIDCol)
                                    
                                    '@ﾚｼﾋﾟは空白以外
                                    If lstrRecipeID <> vbNullString And lstrRecipeID <> CPstrSpace Then
                                        For llngCnt2 = 1 To .Rows.Count - 1
                                            If .GetData(llngCnt, CMlngUseRecipeWPIDCol) = .GetData(llngCnt2, CMlngUseRecipeWPIDCol) _
                                                And .GetData(llngCnt2, CMlngUseRecipeIDCol) <> vbNullString _
                                                And .GetData(llngCnt2, CMlngUseRecipeIDCol) <> CPstrSpace _
                                                And llngCnt2 <> llngCnt Then
                                                '@ﾚｼﾋﾟID相違
                                                If lstrRecipeID <> .GetData(llngCnt2, CMlngUseRecipeIDCol) Then
                                                    '@"<TRM0GW>$$装置[%1]は%2装置です。$異なったレシピの設定はできません。$設定を見直してください。"
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000G, mtypWpList(llngWpCnt).strWpName, CPstrWFRecipeMSG)
                                                    '@警告ﾒｯｾｰｼﾞ
                                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrFormTitle, True, 16)
                                                    prvblnRecipeBlank_Chk = False
                                                    Exit Function
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                        Next
                    End With

                '@装置共通ﾚｼﾋﾟ
                Case 2
                    
                    '@ﾁｪｯｸﾌﾗｸﾞ（ﾁｪｯｸ不要）
                    lblnCheckFlag = False
                    lstrWpId = vbNullString
                    
                    With vsfUseWP
                        For llngCnt = 1 To .Rows.Count - 1
                            '@装置ｸﾞﾘｯﾄﾞより該当ﾁｪｯｸ済み装置を取得
                            If .GetCellCheck(llngCnt, CMlngUseWPCKCol) = CheckEnum.Checked Then
                                '@装置ID退避
                                lstrWpId = .GetData(llngCnt, CMlngUseWPIDCol)
                                '@装置IDからLOT_RECIPE_FLAGの情報を取得
                                For llngWpCnt = 0 To mlngWpListCnt - 1
                                    If lstrWpId = mtypWpList(llngWpCnt).strWpID Then
                                        lstrLotRecipeFlag = mtypWpList(llngWpCnt).strLotRecipeFlag
                                        Exit For
                                    End If
                                Next
                                '@指定装置に1件でも単一枚葉ﾚｼﾋﾟ設定が存在する場合
                                If lstrLotRecipeFlag = CPstrWfRecpSiFlag Then
                                    '@ﾁｪｯｸﾌﾗｸﾞ（ﾁｪｯｸ要）
                                    lblnCheckFlag = True
                                    Exit For
                                End If
                            
                            End If
                        Next
                    End With
                    
                    '@ﾁｪｯｸ要の場合
                    If lblnCheckFlag = True Then
                        
                        With vsfUseRecipe2
                            For llngCnt = 1 To .Rows.Count - 1
                                '@ﾚｼﾋﾟIDを格納
                                lstrRecipeID = .GetData(llngCnt, CMlngUseRecipeIDCol)
                                
                                '@ﾚｼﾋﾟは空白以外
                                If lstrRecipeID <> vbNullString And lstrRecipeID <> CPstrSpace Then
                                    For llngCnt2 = 1 To .Rows.Count - 1
                                        If .GetData(llngCnt2, CMlngUseRecipeIDCol) <> vbNullString _
                                            And .GetData(llngCnt2, CMlngUseRecipeIDCol) <> CPstrSpace _
                                            And llngCnt2 <> llngCnt Then
                                            '@ﾚｼﾋﾟID相違
                                            If lstrRecipeID <> .GetData(llngCnt2, CMlngUseRecipeIDCol) Then
                                                '@"<TRM0GW>$$装置[%1]は%2装置です。$異なったレシピの設定はできません。$設定を見直してください。"
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000G, mtypWpList(llngWpCnt).strWpName, CPstrWFRecipeMSG)
                                                '@警告ﾒｯｾｰｼﾞ
                                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrFormTitle, True, 16)
                                                prvblnRecipeBlank_Chk = False
                                                Exit Function
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End With
                    End If
            
            End Select
        '@↑2007/08/27 (Mon) 18:27:15 N.Kasai **************************************************
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnRecipeBlank_Chk"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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

                End Select

            Case WM_CLOSE
                'Application.Exit以外で閉じられようとしている場合
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Frame1.Paint, fraCondition.Paint, fraLoader.Paint, fraUseRecipe.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfUseRecipe1.BeforeDoubleClick, vsfUseRecipe2.BeforeDoubleClick, vsfUseWP.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        Dim colindex As Integer 'ダブルクリックした列番号

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X, e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

            'ダブルクリックした列番号を格納
            colindex = gridObj.HitTest(e.X, e.Y).Column

            'サイズを自動調整
            ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
            vsfUseRecipe1.AllowMerging = AllowMergingEnum.None
            gridObj.AutoSizeCol(colindex, 6)
            vsfUseRecipe1.AllowMerging = AllowMergingEnum.Free
        End If

        '@ﾍｯﾀﾞｰ部以外をｸﾘｯｸした場合、処理中止
        If sender.MouseRow > 0 Then
            e.Cancel = True
        End If

    End Sub

    '関数名：flexGrid_KeyDown
    '機　能：
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    '備　考：
    Private Sub flexGrid_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfUseRecipe1.KeyDown, vsfUseRecipe2.KeyDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If sender.Rows.Count <= sender.Rows.Fixed Then
                Return
            End If

            With CType(sender, C1FlexGrid)
                '@ﾚｼﾋﾟID
                If .Col = CMlngUseRecipeIDCol Or .Col = CMlngUseRecipeWPNameCol Then
                    '@Enter、矢印、F4Keyは制御外
                    Select Case e.KeyCode
                        Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Return, Keys.F4
                            Exit Sub
                        Case Else
                            If e.KeyCode = Keys.Space Or e.KeyCode = Keys.F2 Then  'ｽﾍﾟｰｽ、F2は無効
                                e.SuppressKeyPress = True
                                .StartEditing()                                    '編集可能にする
                            End If
                    End Select
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "flexGrid_KeyDown"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：flex_SetupEditor
    '機　能：グリッド内コンボボックス表示行数調整
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/11/14 (Thu) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfUseRecipe1.SetupEditor, vsfUseRecipe2.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                '装置名の場合
                If sender.Col = CMlngUseRecipeWPNameCol Then
                    editor.DropDownHeight = 220
                    editor.MaxDropDownItems = 12
                Else
                'レシピの場合
                    editor.DrawMode = DrawMode.OwnerDrawFixed
                    editor.DropDownHeight = 106
                    editor.MaxDropDownItems = 12
                    editor.DropDownWidth = editor.DropDownWidth + 2
                End If
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：stbRecipe_Selecting
    '機　能：Tabページのクリック抑止
    '作成日：2019/09/11 (Wed) 20:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub stbRecipe_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles stbRecipe.Selecting

        Try

            If e.TabPageIndex = CMlngCommonTab AndAlso Tab0.Enabled = False Then
                e.Cancel = true
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：vsfUseRecipe_Leav
    '機　能：ｸﾞﾘｯﾄﾞLostFocus
    '引　数：sender：ｲﾍﾞﾝﾄ発生元
    '戻り値：なし
    '作成日：2019/10/04 (Fri) NSYS
    '更新日：
    '備　考：
    Private Sub vsfUseRecipe_Leave(sender As Object, e As EventArgs) Handles vsfUseRecipe1.Leave, vsfUseRecipe2.Leave

        Try
            With CType(sender, C1FlexGrid)
                .AllowEditing = False
            End With

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey      '機能ID
                .strProcName = "vsfUseRecipe_Leave"  '処理名
                .strErrMessage = vbNullString        'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseRecipe_Enter
    '機　能：ｸﾞﾘｯﾄﾞFocusIn
    '引　数：sender：ｲﾍﾞﾝﾄ発生元
    '戻り値：なし
    '作成日：2019/10/04 (Fri) NSYS
    '更新日：
    '備　考：
    Private Sub vsfUseRecipe_Enter(sender As Object, e As EventArgs) Handles vsfUseRecipe1.Enter, vsfUseRecipe2.Enter

        Try
            With CType(sender, C1FlexGrid)
                vsfUseRecipe_BeforeRowColChange(sender, New RangeEventArgs(.Selection, .Selection))
            End With

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey      '機能ID
                .strProcName = "vsfUseRecipe_Enter"  '処理名
                .strErrMessage = vbNullString        'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGetRecipeVer
    '機　能：装置ID取得
    '引　数：wpname:装置名
    '戻り値：String ：装置ID
    '作成日：2019/09/11 (Wed) 10:00:00 NSYS
    '更新日：2019/09/11 (Wed) 10:00:00
    '備　考：
    Private Function prvGetRecipeVer(ByVal wpid As String, ByVal recipe As String) As String
        
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            prvGetRecipeVer = vbNullString

            '@装置数分ﾙｰﾌﾟ
            For llngCnt = 0 To mlngRecipeNameListCnt - 1
                '@ﾚｼﾋﾟ一覧格納用の装置IDとｸﾞﾘｯﾄﾞの装置IDが同じ場合
                If wpid = mtypMasRecipeNameList(llngCnt).strWpId Then
                    '@ﾚｼﾋﾟ数分ﾙｰﾌﾟ
                    For llngCnt2 = 0 To mtypMasRecipeNameList(llngCnt).lngMasRecipeNameCnt - 1
                        If recipe = mtypMasRecipeNameList(llngCnt).typMasRecipeName(llngCnt2).strRecipeId Then
                            prvGetRecipeVer = mtypMasRecipeNameList(llngCnt).typMasRecipeName(llngCnt2).strRecipeVersion
                            Exit Function
                        End If
                    Next
                End If
            Next

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvGetRecipeVer"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvGetWpid
    '機　能：装置ID取得
    '引　数：wpname:装置名
    '戻り値：String ：装置ID
    '作成日：2019/09/11 (Wed) 10:00:00 NSYS
    '更新日：2019/09/11 (Wed) 10:00:00
    '備　考：
    Private Function prvGetWpid(ByVal wpname As String) As String
        
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            prvGetWpid = vbNullString

            '@装置数分ﾙｰﾌﾟ
            For llngCnt = 0 To mlngWpListCnt - 1
                If wpname = ptypWPList(llngCnt).strWPName Then
                    prvGetWpid = ptypWPList(llngCnt).strWpID
                    Exit For
                End If
            Next

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvGetWpid"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

End Class
