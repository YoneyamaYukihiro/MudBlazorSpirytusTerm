'ﾌｧｲﾙ名：xxMN0001.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：お気に入り登録画面
'作成日：2004/05/06 (Thu) 13:12:49 H.Wajima
'更新日：2004/05/06 (Thu) 13:12:49
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxMN0001
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxMN0001    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxMN0001
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxMN0001
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxMN0001)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '*******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrFormMN0000         'ﾛｰｶﾙ機能ID

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '関数名：prvMenuFavoritesGrid_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:29:06 H.Wajima
    '更新日：2004/05/06 (Thu) 13:29:06
    '備　考：
    Private Sub prvMenuFavoritesGrid_init()

        Dim lctlControl     As Control

        Try
            
            '@ｸﾞﾘｯﾄﾞの初期化
            '@ﾌｫｰﾑ上のｺﾝﾄﾛｰﾙに対して処理を繰り返す
            For Each lctlControl In GetAllControls(Me)
                '@ｺﾝﾄﾛｰﾙがVSFlexGridかどうかを判定する
                If TypeOf lctlControl Is C1FlexGrid Then
                    '@VSFlexGridの場合
                    With CType(lctlControl, C1FlexGrid)
                        .Redraw = False
                        '@ｸﾞﾘｯﾄﾞの初期化
                        .Cols.Fixed = 0
                        .Rows.Fixed = 0
                        .Cols.Count = CPlngMenuGridCols
                        If .Rows.Count < CPlngMenuGridPageRows Then
                            .Rows.Count = CPlngMenuGridPageRows
                        End If
                        For i As Integer = 0 To .Rows.Count - 1
                            .Rows(i).Height = CPlngMenuGridRowHeight
                        Next
                        .ScrollBars = ScrollBars.None
                        .Cols(CPlngMenuKeyCol).Width = 0
                        .Cols(CPlngMenuTitleCol).Width = CPlngMenuTitleColWidth + CPlngMenuGridButtonSize
                        .FocusRect = FocusRectEnum.None
                        .HighLight = HighLightEnum.Always
                        .SelectionMode = SelectionModeEnum.Row
                        'NSYS フラグ列を非表示
                        .Cols(CPlngMenuExecuteCol).Visible = False
                        .Cols(CPlngMenuCarrTakeOver).Visible = False
                        .Redraw = True
                    End With
                End If
            Next
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMenuFavoritesGrid_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMenuMove_chk
    '機　能：>ﾎﾞﾀﾝ表示判定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:04:58 H.Wajima
    '更新日：2004/09/02 (Thu) 08:59:47 H.Wajima
    '備　考：2004/09/02 (Thu) 08:59:47 H.Wajima 左側のｸﾞﾘｯﾄﾞで「空白行」を選択した時に、>ﾎﾞﾀﾝが押せないように変更。
    Private Sub prvMenuMove_chk()

        Dim lstrFindKey     As String       '@検索用ﾒﾆｭｰｷｰ
        Dim llngFindRow     As Integer      '@検索用行番号

        Try
            
            With vsfFavorites
                '@ﾀﾌﾞの状態により処理を振り分ける
                Select Case tabMenu1.SelectedIndex
                    Case CPlngMenuTabFlow
                        '@流動系ﾀﾌﾞの場合
                        With vsfFlow
                            '@ﾌｫｰﾑにﾌｫｰｶｽが当たっているか判定する
                            If .Row = CPlngMenuVSFlexGridUnChoosing Then
                                '@行が選択できないとき
                                '@>ﾎﾞﾀﾝを押せなくする
                                cmdMove.Enabled = False
                                '@処理を抜ける
                                Exit Sub
                            Else
                                '@行選択が有効なとき
                                '@ｾﾙのﾒﾆｭｰｷｰを取得する
                                lstrFindKey = .GetData(.Row, CPlngMenuKeyCol)
                            End If
                        End With
                        
                    Case CPlngMenuTabTool
                        '@ﾂｰﾙ系ﾀﾌﾞの場合
                        With vsfTool
                            '@ﾌｫｰﾑにﾌｫｰｶｽが当たっているか判定する
                            If .Row = CPlngMenuVSFlexGridUnChoosing Then
                                '@行が選択できないとき
                                '@>ﾎﾞﾀﾝを押せなくする
                                cmdMove.Enabled = False
                                '@処理を抜ける
                                Exit Sub
                            Else
                                '@行選択が有効なとき
                                '@ｾﾙのﾒﾆｭｰｷｰを取得する
                                lstrFindKey = .GetData(.Row, CPlngMenuKeyCol)
                            End If
                        End With
                End Select
                
                '@ﾒﾆｭｰｷｰの判定
                Select Case lstrFindKey
                    Case CPstrMenuKeySpace
                        '@空白行の場合
                        '@>ﾎﾞﾀﾝを押せなくする
                        cmdMove.Enabled = False
                        
                    Case Is <> vbNullString
                        '@ﾒﾆｭｰｷｰが空白以外の場合
                        '@既にお気に入りに登録されているか確認する
                        llngFindRow = vsfFavorites.FindRow(lstrFindKey, .Rows.Fixed, CPlngMenuKeyCol, False, True, True)
                        '@検索結果の確認
                        If llngFindRow <> CPlngMenuVSFlexGridUnChoosing Then
                            '@既にお気に入りに登録されていた場合
                            '@>ﾎﾞﾀﾝを押せなくする
                            cmdMove.Enabled = False
                        Else
                            '@>ﾎﾞﾀﾝを押ｾﾙようにする
                            cmdMove.Enabled = True
                        End If
                        
                    Case Else
                        '@ﾒﾆｭｰｷｰが空白(未設定行)の場合
                        '@>ﾎﾞﾀﾝを押せなくする
                        cmdMove.Enabled = False
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMenuMove_chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMenuRemove_chk
    '機　能：<ﾎﾞﾀﾝ表示判定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:30:05 H.Wajima
    '更新日：2004/05/06 (Thu) 13:30:05
    '備　考：
    Private Sub prvMenuRemove_chk()

        Dim llngListCount   As Integer      'ﾒﾆｭｰ件数ｶｳﾝﾀ

        Try
                
                '@お気に入りｸﾞﾘｯﾄﾞにﾌｫｰｶｽが当たっているか確認する
                If vsfFavorites.Row = CPlngMenuVSFlexGridUnChoosing Then
                    '@有効な行が選択されていない場合
                    '@<ﾎﾞﾀﾝを非活性化する
                    cmdRemove.Enabled = False
                    '@処理を抜ける
                    Exit Sub
                End If
                
                '@お気に入りｸﾞﾘｯﾄﾞのﾃﾞｰﾀ件数を取得する
                Call pubMenuFavoritesCount_proc(vsfFavorites, llngListCount)
                
                '@ﾒﾆｭｰ件数の判定
                Select Case llngListCount
                    Case 0
                        '@0件の場合
                        '@<ﾎﾞﾀﾝを非活性化する
                        cmdRemove.Enabled = False
                        
                    Case Is <= vsfFavorites.Row
                        '@空白行が選択されている場合
                        '@<ﾎﾞﾀﾝを非活性化する
                        cmdRemove.Enabled = False
                        
                    Case Else
                        '@上記以外の場合
                        '@<ﾎﾞﾀﾝを活性化する
                        cmdRemove.Enabled = True
                End Select
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMenuRemove_chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMoveButton_chk
    '機　能：↑↓ﾎﾞﾀﾝ表示判定処理
    '引　数：なし
    '戻り値：
    '作成日：2004/04/26 (Mon) 15:42:09 H.Wajima
    '更新日：2004/04/26 (Mon) 15:42:09
    '備　考：
    Private Sub prvMoveUDButton_chk()

        Try
            
            With vsfFavorites
                '@お気に入りｸﾞﾘｯﾄﾞの行が選択状態かどうかを判定する
                If .Row = CPlngMenuVSFlexGridUnChoosing Then
                    '@お気に入りｸﾞﾘｯﾄﾞが未選択の場合
                    '@↑ﾎﾞﾀﾝを押せなくする
                    cmdMoveUp.Enabled = False
                    '@↓ﾎﾞﾀﾝを押せなくする
                    cmdMoveDown.Enabled = False
                    '@処理を抜ける
                    Exit Sub
                End If
                
                '@↑ﾎﾞﾀﾝのﾁｪｯｸ
                Call prvMoveUp_chk()
                
                '@↓ﾎﾞﾀﾝのﾁｪｯｸ
                Call prvMoveDown_chk()
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMoveUDButton_chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMoveUp_chk
    '機　能：↑ﾎﾞﾀﾝ表示判定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 15:42:17 H.Wajima
    '更新日：2004/04/26 (Mon) 15:42:17
    '備　考：
    Private Sub prvMoveUp_chk()

        Try
            
            With vsfFavorites
                '@↑ﾎﾞﾀﾝのﾁｪｯｸ
                '@現在の行が先頭行かどうかを判定する
                If .Row = 0 Then
                    '@ｸﾞﾘｯﾄﾞの先頭行の場合
                    '@↑ﾎﾞﾀﾝを押せなくする
                    cmdMoveUp.Enabled = False
                    '@処理を抜ける
                    Exit Sub
                End If
                
                '@現在の行が空白行かどうかを判定する
                If .GetData(.Row, CPlngMenuKeyCol) = vbNullString Then
                    '@現在の行が空白の場合
                    '@↑ﾎﾞﾀﾝを押せなくする
                    cmdMoveUp.Enabled = False
                    '@処理を抜ける
                    Exit Sub
                End If
                
                '@↑ﾎﾞﾀﾝを押ｾﾙようにする
                cmdMoveUp.Enabled = True
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMoveUp_chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMoveDown_chk
    '機　能：↓ﾎﾞﾀﾝ表示判定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 15:42:12 H.Wajima
    '更新日：2004/04/26 (Mon) 15:42:12
    '備　考：
    Private Sub prvMoveDown_chk()

        Dim llngListCount       As Integer

        Try
            
            With vsfFavorites
                '@↓ﾎﾞﾀﾝのﾁｪｯｸ
                '@お気に入りｸﾞﾘｯﾄﾞの選択行の判定
                If .Row = .Rows.Count - 1 Then
                    '@ｸﾞﾘｯﾄﾞの最終行の場合
                    '@↓ﾎﾞﾀﾝを押せなくする
                    cmdMoveDown.Enabled = False
                    '@処理を抜ける
                    Exit Sub
                End If
                    
                '@お気に入りｸﾞﾘｯﾄﾞのﾃﾞｰﾀ件数を取得する
                Call pubMenuFavoritesCount_proc(vsfFavorites, llngListCount)
                    
                '有効なﾃﾞｰﾀが選択されているかどうかを判定する
                If llngListCount <= .Row + 1 Then
                    '@1行下に有効なﾃﾞｰﾀがある場合
                    '@↓ﾎﾞﾀﾝを押せなくする
                    cmdMoveDown.Enabled = False
                    '@処理を抜ける
                    Exit Sub
                End If
                    
                '@↓ﾎﾞﾀﾝを押ｾﾙようにする
                cmdMoveDown.Enabled = True
                
            End With
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMoveDown_chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRowMove_set
    '機　能：行の入れ替え処理
    '引　数：llngFromRow：入れ替え元の行番号
    '　　　：llngToRow：入れ替え先の行番号
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:19:54 H.Wajima
    '更新日：2004/05/06 (Thu) 13:19:54
    '備　考：
    Private Sub prvRowMove_set(ByVal llngFromRow As Integer, ByVal llngToRow As Integer)

        Dim lstrGridTextItem        As List(Of String)
        Dim llngCnt                 As Integer

        Try
            
            With vsfFavorites
                '@配列の初期化
                lstrGridTextItem = New List(Of String)
                For i As Integer = CPlngMenuKeyCol To CPlngMenuCarrTakeOver
                    lstrGridTextItem.Add(New String(""))
                Next
                
                '@選択行の値の退避
                For llngCnt = CPlngMenuKeyCol To CPlngMenuCarrTakeOver
                    '@各列の値を退避する
                    lstrGridTextItem(llngCnt) = .GetData(llngFromRow, llngCnt)
                Next llngCnt
                
                '@1行上のﾃﾞｰﾀを現在の行に移す
                For llngCnt = CPlngMenuKeyCol To CPlngMenuCarrTakeOver
                    .SetData(llngFromRow, llngCnt, .GetData(llngToRow, llngCnt))
                Next
                
                '@退避した行を1行上の行に戻す
                For llngCnt = CPlngMenuKeyCol To CPlngMenuCarrTakeOver
                    '@各列の値を退避する
                    .SetData(llngToRow, llngCnt, lstrGridTextItem(llngCnt))
                Next llngCnt
                
                '@配列の開放
                lstrGridTextItem.Clear
                
                '@移動先の列を選択する
                .Row = llngToRow
                
                '@ｸﾞﾘｯﾄﾞ共通関数でｸﾞﾘｯﾄﾞの表示位置・上下ﾎﾞﾀﾝを初期化
                Call pubVsfDisp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)
                
                Call pubSetFocus(vsfFavorites)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRowMove_set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '*******************************************************************************
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

        'NSYS マウスホイール対応
        pubVsfMouseWheelManager_Set(vsfFlow, cmdFlowUp, cmdFlowDown)
        pubVsfMouseWheelManager_Set(vsfTool, cmdToolUp, cmdToolDown)
        pubVsfMouseWheelManager_Set(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '　　　　　　　　　　　　　* イベントハンドラの記述 *
    '*******************************************************************************
    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝCick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:13:16 H.Wajima
    '更新日：2004/05/06 (Thu) 13:13:16
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

            '@ﾌｫｰﾑを閉じる
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

    '関数名：cmdConfirm_Click
    '機　能：確定ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:13:37 H.Wajima
    '更新日：2004/09/16 (Thu) 13:59:12 H.Wajima
    '備　考：2004/08/31 (Tue) 18:20:55 H.Wajima 空白行のみ登録された場合に、未選択行に変換するよう修正
    '　　　：2004/09/16 (Thu) 13:59:12 H.Wajima ﾒﾆｭｰ画面でTopRowが変更された状態でお気に入りの整理(項目削除)を行った場合、
    '　　　：                                   ﾒﾆｭｰ画面に戻った時にｲﾝﾃﾞｯｸｽｴﾗｰが出るため、TopRowの設定を追加。
    '　　　：2004/09/16 (Thu) 13:59:12 H.Wajima ﾒﾆｭｰ画面の項目数が1ﾍﾟｰｼﾞの行数の倍数でない場合、1ﾍﾟｰｼﾞの倍数になるまで
    '　　　：                                   空白行で埋めるように変更。(№828)
    Private Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdConfirm.Click

        Dim llngCnt                 As Integer  '汎用ｶｳﾝﾀ
        Dim lblnAgreementFlg        As Boolean  '一致ﾌﾗｸﾞ
        Dim lblnRet                 As Boolean  '戻り値

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfFavorites
                '@一致ﾌﾗｸﾞにTrueを設定する
                lblnAgreementFlg = True
                
                '@空白行だけかどうかの判定
                For llngCnt = 0 To .Rows.Count - 1
                    Select Case .GetData(llngCnt, CPlngMenuKeyCol)
                        Case vbNullString
                            '@未設定行の場合
                            '@何もしない
                        Case CPstrMenuKeySpace
                            '@空白行の場合
                            '@一致ﾌﾗｸﾞにFalseを設定する
                            lblnAgreementFlg = False
                        Case Else
                            '@上記以外の場合
                            '@一致ﾌﾗｸﾞにTrueを設定する
                            lblnAgreementFlg = True
                            Exit For
                    End Select
                Next llngCnt
                
                '@一致ﾌﾗｸﾞの判定
                If lblnAgreementFlg = False Then
                    '@空白行と未設定行だけの場合
                    '@ﾒｯｾｰｼﾞを表示して処理を抜ける
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002T)
                    '@"<TRM2TW>$$空白行のみでお気に入りの登録はできません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Sub
                End If
            End With
            
            '@お気に入りｸﾞﾘｯﾄﾞの中身を、ﾒﾆｭｰ画面のお気に入りｸﾞﾘｯﾄﾞにｺﾋﾟｰする
            With frmxxMN0000.Instance.vsfFavorites
                .Redraw = False
                '@行数が1ﾍﾟｰｼﾞの行数の倍数になるようにする
                If Me.vsfFavorites.Rows.Count Mod CPlngMenuGridPageRows = 0 Then
                    '@行数が1ﾍﾟｰｼﾞの行数の倍数の場合
                    '@行数を合わｾﾙ
                    .Rows.Count = Me.vsfFavorites.Rows.Count
                Else
                    '@行数が1ﾍﾟｰｼﾞの行数の倍数以外の場合
                    '@行数をﾍﾟｰｼﾞの表示行数の倍数に設定する
                    .Rows.Count = (Me.vsfFavorites.Rows.Count \ CPlngMenuGridPageRows + 1) * CPlngMenuGridPageRows
                End If
                
                '@TopRowを合わｾﾙ
                lblnRet = pubblnVsfTag_Set(frmxxMN0000.Instance.vsfFavorites, 1, 0)
                
                '@ﾒﾆｭｰ画面のｸﾞﾘｯﾄﾞのｾﾙのｸﾘｱ
                .Clear
                
                With Me.vsfFavorites
                    '@空白行の判定
                    For llngCnt = 0 To .Rows.Count - 1
                        If .GetData(llngCnt, CPlngMenuKeyCol) = CPstrMenuKeySpace Then
                            '@空白行の場合
                            '@ﾒﾆｭｰのタイトルを空白に戻す
                            .SetData(llngCnt, CPlngMenuTitleCol, vbNullString)
                        End If
                    Next llngCnt
                End With
                
                '@ｸﾞﾘｯﾄﾞの内容のｺﾋﾟｰ
                For rowCnt As Integer = 0 To Me.vsfFavorites.Rows.Count - 1
                    For colCnt As Integer = 0 To Me.vsfFavorites.Cols.Count - 1
                        .SetData(rowCnt, colCnt, Me.vsfFavorites.GetData(rowCnt, colCnt))
                    Next
                Next
                    
                '@行の高さを設定する
                For i As Integer = 0 To .Rows.Count - 1
                    .Rows(i).Height = CPlngMenuGridRowHeight
                Next

                'NSYS フラグ列を非表示
                .Cols(CPlngMenuExecuteCol).Visible = False
                .Cols(CPlngMenuCarrTakeOver).Visible = False

                .Redraw = True
            End With
            
            '@引継ぎﾌﾗｸﾞを格納
            If chkMenu.Checked = True Then
                plngTakingOverFlag = 1
            Else
                plngTakingOverFlag = 0
            End If
            
            '@ﾌｫｰﾑを閉じる
            Me.Close()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdConfirm_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSpace_Click
    '機　能：空白行挿入ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 17:02:00 H.Wajima
    '更新日：2004/09/16 (Thu) 14:05:15 H.Wajima
    '備　考：2004/09/16 (Thu) 14:05:15 H.Wajima 追加した行の表示処理を追加
    Private Sub cmdSpace_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSpace.Click

        Dim lstrAddItem     As List(Of String)  '追加項目
        Dim llngListCount   As Integer          '行ｶｳﾝﾀ
        Dim llngCnt         As Integer          '汎用ｶｳﾝﾀ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfFavorites
                '@非表示列の再描画
                For llngCnt = 0 To .Rows.Count - 1
                    .Rows(llngCnt).Visible = True
                Next llngCnt
                
                '@お気に入りｸﾞﾘｯﾄﾞのﾃﾞｰﾀ件数を取得する
                Call pubMenuFavoritesCount_proc(vsfFavorites, llngListCount)
                
                '@行数をﾃﾞｰﾀ行数にする(空白行削除)
                .Rows.Count = llngListCount
                
                '@追加項目の初期化
                lstrAddItem = New List(Of String)
                For i As Integer = CPlngMenuKeyCol To CPlngMenuCarrTakeOver
                    lstrAddItem.Add(New String(""))
                Next
            
                '@再描画の抑止
                .Redraw = False
            
                '@空白行ﾃﾞｰﾀの作成
                lstrAddItem(CPlngMenuKeyCol) = CPstrMenuKeySpace                    'ﾒﾆｭｰｷｰ
                lstrAddItem(CPlngMenuTitleCol) = CPlngFavoritesEditCaptionSpace     'タイトル
                lstrAddItem(CPlngMenuExecuteCol) = CPlngMenuSuspendFlg              '実行状態
                lstrAddItem(CPlngMenuCarrTakeOver) = CPlngMenuCarrTakeOverDisable   'キャリア引継ぎフラグ
            
                '@項目の追加
                .AddItem (Join(lstrAddItem.ToArray, Chr(9)))
                
                '@ｸﾞﾘｯﾄﾞの初期化
                Call prvMenuFavoritesGrid_init()
                
                '@描画の再開
                .Redraw = True
            
                '@追加した行を表示する
                .ShowCell(.Rows.Count - 1, CPlngMenuTitleCol)
                
                '@ｸﾞﾘｯﾄﾞ共通関数で上下ﾎﾞﾀﾝを初期化
                '@<ﾎﾞﾀﾝの表示判定
                Call prvMenuRemove_chk()
                
                '@お気に入りｸﾞﾘｯﾄﾞの追加した行を選択する
                vsfFavorites.Select(llngListCount, 0)
                
                '@ｸﾞﾘｯﾄﾞ共通関数でｸﾞﾘｯﾄﾞの表示位置・上下ﾎﾞﾀﾝを初期化
                Call pubVsfDisp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)
                
                '@お気に入りｸﾞﾘｯﾄﾞにﾌｫｰｶｽをあわせる
                Call pubSetFocus(vsfFavorites)
                
                '@↑↓ﾎﾞﾀﾝの表示判定
                Call prvMoveUDButton_chk()
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSpace_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdToolUp_Click
    '機　能：ﾂｰﾙ系ｸﾞﾘｯﾄﾞの▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:06:21 H.Wajima
    '更新日：2004/04/30 (Fri) 15:06:21
    '備　考：
    Private Sub cmdToolUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdToolUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾂｰﾙﾀﾌﾞ▲ﾎﾞﾀﾝ押下処理を実行する(ｸﾞﾘｯﾄﾞ共通関数)
            Call pubVsfCmdUp(vsfTool, cmdToolUp, cmdToolDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdToolUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdToolDown_Click
    '機　能：ﾂｰﾙ系ｸﾞﾘｯﾄﾞの▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 15:05:56 H.Wajima
    '更新日：2004/04/30 (Fri) 15:05:56
    '備　考：
    Private Sub cmdToolDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdToolDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾂｰﾙﾀﾌﾞ▼ﾎﾞﾀﾝ押下処理を実行する(ｸﾞﾘｯﾄﾞ共通関数)
            Call pubVsfCmdDown(vsfTool, cmdToolUp, cmdToolDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdToolDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFavoritesDown_Click
    '機　能：お気に入りｸﾞﾘｯﾄﾞ▼ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:14:17 H.Wajima
    '更新日：2004/05/06 (Thu) 13:14:17
    '備　考：
    Private Sub cmdFavoritesDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFavoritesDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@お気に入りｸﾞﾘｯﾄﾞ▼ﾎﾞﾀﾝ押下処理を実行する(ｸﾞﾘｯﾄﾞ共通関数)
            Call pubVsfCmdDown(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFavoritesDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFavoritesUp_Click
    '機　能：お気に入りｸﾞﾘｯﾄﾞ▲ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:14:46 H.Wajima
    '更新日：2004/05/06 (Thu) 13:14:46
    '備　考：
    Private Sub cmdFavoritesUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFavoritesUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@お気に入りｸﾞﾘｯﾄﾞ▲ﾎﾞﾀﾝ押下処理を実行する(ｸﾞﾘｯﾄﾞ共通関数)
            Call pubVsfCmdUp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFavoritesUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFlowDown_Click
    '機　能：流動系ｸﾞﾘｯﾄﾞ▼ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:17:35 H.Wajima
    '更新日：2004/05/06 (Thu) 13:17:35
    '備　考：
    Private Sub cmdFlowDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFlowDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@流動ﾀﾌﾞ▼ﾎﾞﾀﾝ押下処理を実行する(ｸﾞﾘｯﾄﾞ共通関数)
            Call pubVsfCmdDown(vsfFlow, cmdFlowUp, cmdFlowDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFlowDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFlowUp_Click
    '機　能：流動系ｸﾞﾘｯﾄﾞ▲ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:18:43 H.Wajima
    '更新日：2004/05/06 (Thu) 13:18:43
    '備　考：
    Private Sub cmdFlowUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFlowUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@流動ｸﾞﾘｯﾄﾞ▲ﾎﾞﾀﾝ押下処理を実行する(ｸﾞﾘｯﾄﾞ共通関数)
            Call pubVsfCmdUp(vsfFlow, cmdFlowUp, cmdFlowDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFlowUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMoveUp_Click
    '機　能：↑ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:19:17 H.Wajima
    '更新日：2004/05/06 (Thu) 13:19:17
    '備　考：
    Private Sub cmdMoveUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMoveUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfFavorites
                '@行の入れ替え処理を行う
                Call prvRowMove_set(.Row, .Row - 1)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMoveUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMoveDown_Click
    '機　能：↓ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:19:44 H.Wajima
    '更新日：2004/05/06 (Thu) 13:19:44
    '備　考：
    Private Sub cmdMoveDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMoveDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfFavorites
                '@行の入れ替え処理を行う
                Call prvRowMove_set(.Row, .Row + 1)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMoveDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRemove_Click
    '機　能：<ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:21:09 H.Wajima
    '更新日：2004/05/06 (Thu) 13:21:09
    '備　考：
    Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRemove.Click
        
        Dim llngListCount                   As Integer  '行ｶｳﾝﾀ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfFavorites
                '@行の選択状態の判定
                If .Row = CPlngMenuVSFlexGridUnChoosing Then
                    '@行が選択されていない場合
                    '@処理を終了する
                    Exit Sub
                End If
                
                '@選択行のﾒﾆｭｰｷｰが空白かどうか判定する
                If .GetData(.Row, CPlngMenuKeyCol) <> vbNullString Then
                    '@選択されている行が空白でない場合
                    '@選択されている行を削除する
                    .RemoveItem (.Row)
                    
                    '@お気に入りの実際の行数を数える
                    Call pubMenuFavoritesCount_proc(vsfFavorites, llngListCount)
                    
                    '@行数をﾃﾞｰﾀ行数にする(空白行削除)
                    If .Rows.Count < CPlngMenuGridPageRows Then
                        '@ﾃﾞｰﾀの件数が１ページの行数より少ない場合
                        .Rows.Count = CPlngMenuGridPageRows
                    Else
                        '@ﾃﾞｰﾀの件数が1ページの行数より多い場合
                        .Rows.Count = llngListCount
                    End If
                End If
                
                '@ｸﾞﾘｯﾄﾞの初期化
                Call prvMenuFavoritesGrid_init()
                
                '@ｸﾞﾘｯﾄﾞ共通関数でｸﾞﾘｯﾄﾞの表示位置・上下ﾎﾞﾀﾝを初期化
                Call pubVsfDisp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)
                
                '@お気に入りｸﾞﾘｯﾄﾞにﾌｫｰｶｽをあわせる
                Call pubSetFocus(vsfFavorites)
            End With
            
            '@>ﾎﾞﾀﾝの表示判定
            prvMenuMove_chk
            
            '@<ﾎﾞﾀﾝの表示判定
            Call prvMenuRemove_chk()
            
            '@↑↓ﾎﾞﾀﾝの表示判定
            Call prvMoveUDButton_chk()

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

    '関数名：cmdMove_Click
    '機　能：>ﾎﾞﾀﾝClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:22:47 H.Wajima
    '更新日：2004/09/02 (Thu) 08:58:43 H.Wajima
    '備　考：2004/09/02 (Thu) 08:58:43 H.Wajima 行追加時に１ページの行数を超えていた場合、追加した行が表示されるように修正
    Private Sub cmdMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Click

        Dim llngCnt         As Integer
        Dim llngListCount   As Integer          'ﾒﾆｭｰ件数ｶｳﾝﾀ
        Dim lstrAddItem     As List(Of String)  '追加項目
        Dim lstrFindKey     As String           '検索ｷｰ
        Dim llngFindRow     As Integer          '検索行

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfFavorites
                '@ﾀﾌﾞの判定
                Select Case tabMenu1.SelectedIndex
                    Case CPlngMenuTabFlow
                        '@流動系ﾀﾌﾞの場合
                        With vsfFlow
                            '@該当行のﾒﾆｭｰｷｰを求める
                            lstrFindKey = .GetData(.Row, CPlngMenuKeyCol)
                        End With
                    Case CPlngMenuTabTool
                        '@ﾂｰﾙ系ﾀﾌﾞの場合
                        With vsfTool
                            '@該当行のﾒﾆｭｰｷｰを求める
                            lstrFindKey = .GetData(.Row, CPlngMenuKeyCol)
                        End With
                End Select
                
                '@既にお気に入りに登録されているか確認する
                llngFindRow = vsfFavorites.FindRow(lstrFindKey, .Rows.Fixed, CPlngMenuKeyCol, False, True, True)
                
                '@検索結果の確認
                If llngFindRow <> CPlngMenuVSFlexGridUnChoosing Then
                    '@既にお気に入りに登録されていた場合
                    '@処理を抜ける
                    Exit Sub
                End If
            
                '@再描画の抑止
                .Redraw = False
                
                '@非表示列の再描画
                For llngCnt = 0 To .Rows.Count - 1
                    .Rows(llngCnt).Visible = True
                Next llngCnt
                
                '@お気に入りｸﾞﾘｯﾄﾞのﾃﾞｰﾀ件数を取得する
                Call pubMenuFavoritesCount_proc(vsfFavorites, llngListCount)
                
                '@行数をﾃﾞｰﾀ行数にする(空白行削除)
                .Rows.Count = llngListCount
                
                '@追加項目の初期化
                lstrAddItem = New List(Of String)
                For i As Integer = CPlngMenuKeyCol To CPlngMenuCarrTakeOver
                    lstrAddItem.Add(New String(""))
                Next
                
                '@左側のリストで選択された行を、右側に追加する
                '@ﾀﾌﾞの判定
                Select Case tabMenu1.SelectedIndex
                    Case CPlngMenuTabFlow
                        '@流動系ﾀﾌﾞの場合
                        With vsfFlow
                            '@ｸﾞﾘｯﾄﾞの列数分、処理を繰り返す
                            For llngCnt = CPlngMenuKeyCol To CPlngMenuCarrTakeOver
                                '@ｸﾞﾘｯﾄﾞのｾﾙの内容を、配列に退避する
                                lstrAddItem(llngCnt) = .GetData(.Row, llngCnt)
                            Next llngCnt
                        End With
                        
                    Case CPlngMenuTabTool
                        '@ﾂｰﾙ系ﾀﾌﾞの場合
                        With vsfTool
                            '@ｸﾞﾘｯﾄﾞの列数分、処理を繰り返す
                            For llngCnt = CPlngMenuKeyCol To CPlngMenuCarrTakeOver
                                '@ｸﾞﾘｯﾄﾞの列数分、処理を繰り返す
                                lstrAddItem(llngCnt) = .GetData(.Row, llngCnt)
                            Next llngCnt
                        End With
                End Select
                
                '@項目の追加
                .AddItem (Join(lstrAddItem.ToArray, Chr(9)))
                
                '@ｸﾞﾘｯﾄﾞの初期化
                Call prvMenuFavoritesGrid_init()
                
                '@描画の再開
                .Redraw = True
                
                '@追加した行を表示する
                .ShowCell(.Rows.Count - 1, CPlngMenuTitleCol)
            End With

            '@ｸﾞﾘｯﾄﾞ共通関数で上下ﾎﾞﾀﾝを初期化
            '@<ﾎﾞﾀﾝの表示判定
            Call prvMenuRemove_chk()
            
            '@お気に入りｸﾞﾘｯﾄﾞの追加した行を選択する
            vsfFavorites.Select(llngListCount, 0)
            
            '@ｸﾞﾘｯﾄﾞ共通関数でｸﾞﾘｯﾄﾞの表示位置・上下ﾎﾞﾀﾝを初期化
            Call pubVsfDisp(vsfFavorites, cmdFavoritesUp, cmdFavoritesDown)
            
            '@お気に入りｸﾞﾘｯﾄﾞにﾌｫｰｶｽをあわせる
            Call pubSetFocus(vsfFavorites)
            
            '@↑↓ﾎﾞﾀﾝの表示判定
            Call prvMoveUDButton_chk()
            
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

    '関数名：Form_Activate
    '機　能：Form_Activate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:43:19 H.Wajima
    '更新日：2004/05/06 (Thu) 13:43:19
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown

        Try

            '@ﾀﾌﾞの初期化(ﾀﾌﾞのｸﾘｯｸ処理を実行する)
            Call tabMenu_Click(tabMenu1, New EventArgs())

            '@ｸﾞﾘｯﾄﾞの初期化
            vsfFavorites.Row = CPlngMenuVSFlexGridUnChoosing
            vsfFlow.Row = 0
            Call pubSetFocus(vsfFlow)

            '@引継ぎﾌﾗｸﾞを設定
            If plngTakingOverFlag = 1 Then
                chkMenu.CheckState = CheckState.Checked
            Else 
                chkMenu.CheckState = CheckState.Unchecked
            End If
            
            '@>ﾎﾞﾀﾝの表示判定
            prvMenuMove_chk
            
            '@<ﾎﾞﾀﾝの表示判定
            Call prvMenuRemove_chk()

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
    '機　能：Form_KeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:45:11 H.Wajima
    '更新日：2004/11/04 (Thu) 10:44:41 M.Miura
    '備　考：2004/11/04 (Thu) 10:44:41 M.Miura　引継ぎﾁｪｯｸﾎﾞｯｸｽのﾌｫｰｶｽ移動追加(不具合№190)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Dim lintKeyCode         As Short        'ｷｰｺｰﾄﾞ

        Try
            
            '@KeyCodeを退避する
            lintKeyCode = e.KeyCode
            
            '@ﾀﾌﾞ上のどのｺﾝﾄﾛｰﾙが有効かどうかで、処理を振り分ける
            Select Case ActiveControl.Name
                Case vsfFlow.Name
                    '@流動系のｸﾞﾘｯﾄﾞがActiveな場合
                    If ActiveControl IsNot vsfFlow.Editor Then
                        '@ｸﾞﾘｯﾄﾞ共通関数のKeyDown処理を実行する
                        Call pubVsf_KeyDown(e, ActiveControl.Name, vsfFlow, cmdFlowUp, cmdFlowDown, False)
                        '@押されたｷｰにより処理を振り分ける
                        '@(PageUp、PageDownのｷｰｺｰﾄﾞは、ｸﾞﾘｯﾄﾞ共通関数で初期化されるので、
                        '@退避したｷｰｺｰﾄﾞを使用)
                        Select Case lintKeyCode
                            Case Keys.Return, Keys.Space
                                '@EnterまたはSpaceｷｰが押下された場合
                                '@>ﾎﾞﾀﾝｸﾘｯｸ処理を実行する
                                Call cmdMove_Click(cmdMove, New EventArgs())
                                '@ﾌｫｰｶｽを戻す(連続入力可能なように)
                                Call pubSetFocus(vsfFlow)
                            Case Keys.Up
                                '@↑ｷｰが押下された場合
                                '@ｸﾞﾘｯﾄﾞの選択行により処理を振り分ける
                                If vsfFlow.Row = vsfFlow.Rows.Fixed Then
                                    '@ｸﾞﾘｯﾄﾞの先頭行が選択されているとき
                                    '@ﾀﾌﾞにﾌｫｰｶｽを移動する
                                    Call pubSetFocus(tabMenu1)
                                End If
                        End Select
                    End If
                    
                Case vsfTool.Name
                    '@ﾂｰﾙ系のｸﾞﾘｯﾄﾞがActiveな場合
                    If ActiveControl IsNot vsfTool.Editor Then
                        '@ｸﾞﾘｯﾄﾞ共通関数のKeyDown処理を実行する
                        Call pubVsf_KeyDown(e, ActiveControl.Name, vsfTool, cmdToolUp, cmdToolDown, False)
                        '@押されたｷｰにより処理を振り分ける
                        '@(PageUp、PageDownのｷｰｺｰﾄﾞは、ｸﾞﾘｯﾄﾞ共通関数で初期化されるので、
                        '@退避したｷｰｺｰﾄﾞを使用)
                        Select Case lintKeyCode
                            Case Keys.Return, Keys.Space
                                '@EnterまたはSpaceｷｰが押下された場合
                                '@>ﾎﾞﾀﾝｸﾘｯｸ処理を実行する
                                Call cmdMove_Click(cmdMove, New EventArgs())
                                '@ﾌｫｰｶｽを戻す(連続入力可能なように)
                                Call pubSetFocus(vsfTool)
                            Case Keys.Up
                                '@↑ｷｰが押下された場合
                                '@ｸﾞﾘｯﾄﾞの選択行により処理を振り分ける
                                If vsfTool.Row = vsfTool.Rows.Fixed Then
                                    '@ｸﾞﾘｯﾄﾞの先頭行が選択されているとき
                                    '@ﾀﾌﾞにﾌｫｰｶｽを移動する
                                    Call pubSetFocus(tabMenu1)
                                End If
                        End Select
                    End If
                    
                Case vsfFavorites.Name
                    '@お気に入りﾀﾌﾞのｸﾞﾘｯﾄﾞがActiveな場合
                    If ActiveControl IsNot vsfFavorites.Editor Then
                        '@ｸﾞﾘｯﾄﾞ共通関数のKeyDown処理を実行する
                        Call pubVsf_KeyDown(e, ActiveControl.Name, vsfFavorites, cmdFavoritesUp, cmdFavoritesDown, False)
                        '@押されたｷｰにより処理を振り分ける
                        '@(PageUp、PageDownのｷｰｺｰﾄﾞは、ｸﾞﾘｯﾄﾞ共通関数で初期化されるので、
                        '@退避したｷｰｺｰﾄﾞを使用)
                        Select Case lintKeyCode
                            Case Keys.Return, Keys.Space
                                '@EnterまたはSpaceｷｰが押下された場合
                                '@<ﾎﾞﾀﾝｸﾘｯｸ処理を実行する
                                Call cmdRemove_Click(cmdRemove, New EventArgs())
                                '@ﾌｫｰｶｽを戻す(連続入力可能なように)
                                Call pubSetFocus(vsfFavorites)
                            Case Keys.Up
                                '@↑ｷｰが押下された場合
                                '@ｸﾞﾘｯﾄﾞの選択行により処理を振り分ける
                                If vsfFavorites.Row = vsfFavorites.Rows.Fixed Then
                                    '@ｸﾞﾘｯﾄﾞの先頭行が選択されているとき
                                    '@ﾀﾌﾞにﾌｫｰｶｽを移動する
                                    Call pubSetFocus(tabMenu2)
                                End If
                        End Select
                    End If
                    
                Case chkMenu.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@ﾌｫｰｶｽ移動
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
                'NSYS タブにフォーカスがある状態で↑キー押下時はShift+Tab押下時の動作
                Case tabMenu1.Name ,tabMenu2.Name
                    Select Case lintKeyCode
                        '@↑ｷｰの場合
                        Case Keys.Up
                            '@ﾌｫｰｶｽ移動
                            SendKeys.SendWait("+" & CPstrSendKeysTab)
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
    '作成日：2004/07/28 (Wed) 10:02:22 H.Wajima
    '更新日：2004/07/28 (Wed) 10:02:22
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

    '関数名：tabMenu_Click
    '機　能：ﾀﾌﾞ(左側)Click処理
    '引　数：PreviousTab：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:54:36 H.Wajima
    '更新日：2004/05/06 (Thu) 13:54:36
    '備　考：
    Private Sub tabMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabMenu1.SelectedIndexChanged

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@選択されたﾀﾌﾞのｸﾞﾘｯﾄﾞの選択状態を初期化する
            Select Case tabMenu1.SelectedIndex
                Case CPlngMenuTabFlow
                    '@流動系ﾀﾌﾞの場合
                    '@自ﾀﾌﾞのｺﾝﾄﾛｰﾙを活性化
                    vsfFlow.Enabled = True
                    '@他のﾀﾌﾞのｺﾝﾄﾛｰﾙを非活性化
                    vsfTool.Enabled = False
                    '@ｸﾞﾘｯﾄﾞの選択状態の初期化
                    vsfFlow.Row = CPlngMenuVSFlexGridUnChoosing

                Case CPlngMenuTabTool
                    '@ﾂｰﾙ系ﾀﾌﾞの場合
                    '@自ﾀﾌﾞのｺﾝﾄﾛｰﾙを活性化
                    vsfTool.Enabled = True
                    '@他のﾀﾌﾞのｺﾝﾄﾛｰﾙを非活性化
                    vsfFlow.Enabled = False
                    '@ｸﾞﾘｯﾄﾞの選択状態の初期化
                    vsfTool.Row = CPlngMenuVSFlexGridUnChoosing
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabMenu_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFavorites_GotFocus
    '機　能：お気に入りｸﾞﾘｯﾄﾞGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:58:37 H.Wajima
    '更新日：2004/05/06 (Thu) 13:58:37
    '備　考：
    Private Sub vsfFavorites_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFavorites.Enter

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFavorites.Rows.Count <= vsfFavorites.Rows.Fixed Then
                Return
            End If
            
            '@↑↓ﾎﾞﾀﾝ表示判定処理を実行する
            Call prvMoveUDButton_chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFavorites_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFavorites_MouseMove
    '機　能：お気に入りｸﾞﾘｯﾄﾞMouseMove処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：x：未使用
    '　　　：y：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:59:46 H.Wajima
    '更新日：2004/05/06 (Thu) 13:59:46
    '備　考：
    Private Sub vsfFavorites_MouseMove(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFavorites.MouseMove

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFavorites.Rows.Count <= vsfFavorites.Rows.Fixed Then
                Return
            End If

            '@各ｸﾞﾘｯﾄﾞ共通のMouseMove処理を実行する(ToolTipﾃｷｽﾄ表示)
            Call pubMenuGridMouseMove_Proc(vsfTool, ToolTip)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFavorites_MouseMove"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFavorites_SelChange
    '機　能：お気に入りｸﾞﾘｯﾄﾞSelChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:00:21 H.Wajima
    '更新日：2004/05/06 (Thu) 14:00:21
    '備　考：
    Private Sub vsfFavorites_SelChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFavorites.SelChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFavorites.Rows.Count <= vsfFavorites.Rows.Fixed Then
                Return
            End If
            
            '@↑↓ﾎﾞﾀﾝ表示判定処理を実行する
            Call prvMoveUDButton_chk()
            
            '@<ﾎﾞﾀﾝ表示判定処理を実行する
            Call prvMenuMove_chk()
            
            '@>ﾎﾞﾀﾝ表示判定処理を実行する
            Call prvMenuRemove_chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFavorites_SelChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_DblClick
    '機　能：流動系ｸﾞﾘｯﾄﾞDblClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:07:17 H.Wajima
    '更新日：2004/08/18 (Wed) 09:20:33 H.Wajima
    '備　考：
    Private Sub vsfFlow_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFlow.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If
            
            '@>ﾎﾞﾀﾝClick処理を実行する
            Call cmdMove_Click(cmdMove, New EventArgs())
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFlow_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_GotFocus
    '機　能：流動系ｸﾞﾘｯﾄﾞGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:08:17 H.Wajima
    '更新日：2004/05/06 (Thu) 14:08:17
    '備　考：
    Private Sub vsfFlow_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFlow.Enter

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If
            
            '@>ﾎﾞﾀﾝ表示判定処理
            Call prvMenuMove_chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFlow_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_MouseMove
    '機　能：流動系ｸﾞﾘｯﾄﾞMouseMove処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：x：未使用
    '　　　：y：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:09:07 H.Wajima
    '更新日：2004/05/06 (Thu) 14:09:07
    '備　考：
    Private Sub vsfFlow_MouseMove(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFlow.MouseMove

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If
            
            '@各ｸﾞﾘｯﾄﾞ共通のMouseMove処理を実行する(ToolTipﾃｷｽﾄ表示)
            Call pubMenuGridMouseMove_Proc(vsfTool, ToolTip)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFlow_MouseMove"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_SelChange
    '機　能：流動系ｸﾞﾘｯﾄﾞSelChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:10:01 H.Wajima
    '更新日：2004/05/06 (Thu) 14:10:01
    '備　考：
    Private Sub vsfFlow_SelChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFlow.SelChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If
            
            '@>ﾎﾞﾀﾝ表示判定処理を実行する
            Call prvMenuMove_chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfFlow_SelChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTool_DblClick
    '機　能：ﾂｰﾙ系ｸﾞﾘｯﾄﾞDblClick処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:10:41 H.Wajima
    '更新日：2004/05/06 (Thu) 14:10:41
    '備　考：
    Private Sub vsfTool_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTool.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfTool.Rows.Count <= vsfTool.Rows.Fixed Then
                Return
            End If
            
            '@>ﾎﾞﾀﾝ表示判定処理を実行する
            Call cmdMove_Click(cmdMove, New EventArgs())

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTool_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTool_GotFocus
    '機　能：ﾂｰﾙ系ｸﾞﾘｯﾄﾞGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:11:25 H.Wajima
    '更新日：2004/05/06 (Thu) 14:11:25
    '備　考：
    Private Sub vsfTool_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTool.Enter

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfTool.Rows.Count <= vsfTool.Rows.Fixed Then
                Return
            End If
            
            '@>ﾎﾞﾀﾝ表示判定処理を実行する
            Call prvMenuMove_chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTool_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTool_MouseMove
    '機　能：ﾂｰﾙ系ｸﾞﾘｯﾄﾞMouseMove処理
    '引　数：Button：未使用
    '　　　：Shift：未使用
    '　　　：x：未使用
    '　　　：y：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:11:55 H.Wajima
    '更新日：2004/05/06 (Thu) 14:11:55
    '備　考：
    Private Sub vsfTool_MouseMove(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTool.MouseMove

        Try

            '@各ｸﾞﾘｯﾄﾞ共通のMouseMove処理を実行する(ToolTipﾃｷｽﾄ表示)
            Call pubMenuGridMouseMove_Proc(vsfTool, ToolTip)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTool_MouseMove"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfTool_SelChange
    '機　能：ﾂｰﾙ系ｸﾞﾘｯﾄﾞSelChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 14:12:29 H.Wajima
    '更新日：2004/05/06 (Thu) 14:12:29
    '備　考：
    Private Sub vsfTool_SelChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfTool.SelChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfTool.Rows.Count <= vsfTool.Rows.Fixed Then
                Return
            End If
            
            '@>ﾎﾞﾀﾝ表示判定処理を実行する
            Call prvMenuMove_chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTool_SelChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '機　能：ﾀﾌﾞ(左側)KeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:55:25 H.Wajima
    '更新日：2004/05/06 (Thu) 13:55:25
    '備　考：
    Private Sub tabMenu_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tabMenu1.KeyDown

        Dim llngTopRow          As Integer  'ｸﾞﾘｯﾄﾞのTopRow

        Try
            
            '@ｷｰｺｰﾄﾞの判定
            Select Case e.KeyCode
                Case Keys.Down
                    '@↓ｷｰが押下された場合
                    '@表示中のﾀﾌﾞにより処理を振り分ける
                    Select Case tabMenu1.SelectedIndex
                        Case CPlngMenuTabFlow
                            '@流動系ﾀﾌﾞが表示されている場合
                            If vsfFlow.Row < 0 OrElse ActiveControl Is tabMenu1 Then
                                '@ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で値を取得。
                                '@TopRowを取得する
                                llngTopRow = pubstrVsfTag_Get(vsfFlow, 1)
                                vsfFlow.Row = llngTopRow
                                '@流動系のｸﾞﾘｯﾄﾞにﾌｫｰｶｽをｾｯﾄする
                                Call pubSetFocus(vsfFlow)

                                'NSYS グリッドが ActiveControl の場合、グリッドでもキー処理が行われるのを防ぐため
                                If Me.ActiveControl Is vsfFlow Then
                                    e.Handled = True
                                End If
                            End If
                            
                        Case CPlngMenuTabTool
                            '@ﾂｰﾙ系ﾀﾌﾞが表示されている場合
                            If vsfTool.Row < 0 OrElse ActiveControl Is tabMenu1 Then
                                '@ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で値を取得。
                                '@TopRowを取得する
                                llngTopRow = pubstrVsfTag_Get(vsfTool, 1)
                                vsfTool.Row = llngTopRow
                                '@ﾂｰﾙ系のｸﾞﾘｯﾄﾞにﾌｫｰｶｽをｾｯﾄする
                                Call pubSetFocus(vsfTool)

                                'NSYS グリッドが ActiveControl の場合、グリッドでもキー処理が行われるのを防ぐため
                                If Me.ActiveControl Is vsfTool Then
                                    e.Handled = True
                                End If
                            End If
                    End Select
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabMenu_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：tabMenu2_KeyDown
    '機　能：ﾀﾌﾞ(右側)KeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：未使用
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 13:56:49 H.Wajima
    '更新日：2004/05/06 (Thu) 13:56:49
    '備　考：
    Private Sub tabMenu2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tabMenu2.KeyDown

        Dim llngTopRow          As Integer  'ｸﾞﾘｯﾄﾞのTopRow

        Try
                
            '@ｷｰｺｰﾄﾞの判定
            Select Case e.KeyCode
                Case Keys.Down
                    '@↓ｷｰが押下された場合
                    If vsfFavorites.Row < 0 OrElse ActiveControl Is tabMenu2 Then
                        '@ｸﾞﾘｯﾄﾞ共通関数がRowHiddenを使用しているため、共通関数で値を取得。
                        '@TopRowを取得する
                        llngTopRow = pubstrVsfTag_Get(vsfFavorites, 1)
                        vsfFavorites.Row = llngTopRow
                    
                        '@お気に入りのｸﾞﾘｯﾄﾞにﾌｫｰｶｽをｾｯﾄする
                        Call pubSetFocus(vsfFavorites)

                        'NSYS グリッドが ActiveControl の場合、グリッドでもキー処理が行われるのを防ぐため
                        If Me.ActiveControl Is vsfFavorites Then
                            e.Handled = True
                        End If
                    End If
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabMenu2_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkMenu_Click
    '機　能：ｷｬﾘｱID引継ぎﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/04 (Thu) 10:14:56 M.Miura
    '更新日：2004/11/04 (Thu) 10:14:56
    '備　考：
    Private Sub chkMenu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkMenu.CheckedChanged

        Try

            '@お気に入り編集ﾌﾗｸﾞにTrueを設定
            pblnFavoritesEdit = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkMenu_Click"
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
    '機　能：画面移動不可
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/06 (Mon) 18:00:00 NSYS
    '更新日：
    '備　考：
    <SecurityPermission(SecurityAction.Demand, 
    Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_MOVE As Long = &HF010L

        If m.Msg = WM_SYSCOMMAND AndAlso _
            (m.WParam.ToInt64() And &HFFF0L) = SC_MOVE Then
            m.Result = IntPtr.Zero
            Return
        End If

        MyBase.WndProc(m)
    End Sub

End Class
