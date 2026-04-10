'ﾌｧｲﾙ名：xxCM0070.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：共通関数
'作成日：2005/11/11 (Fri) 13:05:10 N.Kasai
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'ﾃｷｽﾄ&ｽｸﾛｰﾙﾎﾞﾀﾝ制御
'親画面連携
'ｶﾞｲﾀﾞﾝｽ表示
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports SETextBoxEx
Imports System.ComponentModel
Imports System.Security.Permissions
Public Module basxxCM0070
    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '======================================Public===========================================
    'TEXT系MESSAGE
    Public Const EM_GETFIRSTVISIBLELINE = &HCE      '先頭行を取得します。
    Public Const EM_GETLINECOUNT = &HBA             '最大行数を取得します。

    '@今後使用する場合を考慮してｺﾒﾝﾄとして残しておきます。

    'Public Const EM_CANUNDO = &HC6                  'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙの操作を取り消せるかどうかを判断します
    'Public Const EM_EMPTYUNDOBUFFER = &HCD          'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙのｱﾝﾄﾞｩﾌﾗｸﾞをﾘｾｯﾄ (ｸﾘｱ) します。
    'Public Const EM_FMTLINES = &HC8                 'ｿﾌﾄ改行文字の設定をONまたはOFFにします。
    'Public Const EM_GETHANDLE = &HBD                'MLE用ﾒﾓﾘのﾊﾝﾄﾞﾙを取得します。
    'Public Const EM_GETLINE = &HC4                  'MLEから1行取得します。
    'Public Const EM_GETMODIFY = &HB8                'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙの内容が変更されたかどうかをﾁｪｯｸます。
    'Public Const EM_GETPASSWORDCHAR = &HD2          'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙのﾊﾟｽﾜｰﾄﾞ文字を取得します。
    'Public Const EM_GETRECT = &HB2                  'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙ長方形の座標を取得します。
    'Public Const EM_GETSEL = &HB0                   'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙの現在の選択項目の位置を取得します。
    'Public Const EM_GETTHUMB = &HBE
    'Public Const EM_GETWORDBREAKPROC = &HD1         'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙのﾜｰﾄﾞﾗｯﾌﾟ関数を取得します。
    'Public Const EM_LIMITTEXT = &HC5                'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙ内のﾃｷｽﾄの文字数を制限します。
    'Public Const EM_LINEFROMCHAR = &HC9             '文字ｲﾝﾃﾞｯｸｽから行番号を取得します。
    'Public Const EM_LINEINDEX = &HBB                'MLEの行の文字ｲﾝﾃﾞｯｸｽを取得します。
    'Public Const EM_LINELENGTH = &HC1               'MLE内の行の長さを取得します。
    'Public Const EM_LINESCROLL = &HB6               'MLE内のﾃｷｽﾄをｽｸﾛｰﾙさせます。
    'Public Const EM_REPLACESEL = &HC2               'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙ内の現在の選択項目を置き換えます。
    'Public Const EM_SCROLL = &HB5
    'Public Const EM_SCROLLCARET = &HB7              'ｷｬﾚｯﾄをｽｸﾛｰﾙさせて表示します。
    'Public Const EM_SETHANDLE = &HBC                'MLEのﾒﾓﾘ ﾊﾝﾄﾞﾙを設定します。
    'Public Const EM_SETMODIFY = &HB9                'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙの変更ﾌﾗｸﾞをｾｯﾄまたはｸﾘｱします。
    'Public Const EM_SETPASSWORDCHAR = &HCC          'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙのﾊﾟｽﾜｰﾄﾞ文字を設定または削除します。
    'Public Const EM_SETREADONLY = &HCF              'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙの読み取り専用ｽﾀｲﾙを設定します。
    'Public Const EM_SETRECT = &HB3                  'MLEの書式化長方形を設定します。
    'Public Const EM_SETRECTNP = &HB4                'MLEの書式化長方形を設定します。
    'Public Const EM_SETSEL = &HB1                   'ｺﾝﾄﾛｰﾙ内部のﾃｷｽﾄを選択します。
    'Public Const EM_SETTABSTOPS = &HCB              'MLE内のﾀﾌﾞｽﾄｯﾌﾟを設定します。
    'Public Const EM_SETWORDBREAKPROC = &HD0         'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙ内で使うカスタムのﾜｰﾄﾞﾌﾞﾚｲｸ文字を提供します。
    'Public Const EM_UNDO = &HC7                     'ｴﾃﾞｨｯﾄｺﾝﾄﾛｰﾙ内での直前の操作を取り消します。

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '=========================================Public=========================================
    '****************************************************************************************
    '                                      *ＡＰＩの記述*
    '****************************************************************************************
    '=========================================Public=========================================

    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        
    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '=========================================Public=========================================

    '関数名：pubtxtCmdUp_Proc
    '機　能：ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
    '引　数：lobjtxtEx：ﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄ名
    '　　　：llngMaxDispRow：1ﾍﾟｰｼﾞ最大表示行数
    '　　　：lobjcmdUp：▲ﾎﾞﾀﾝ名
    '　　　：lobjcmdDown：▼ﾎﾞﾀﾝ名
    '戻り値：なし
    '作成日：2005/11/11 (Fri) 13:29:35 N.Kasai
    '更新日：2005/11/21 (Mon) 10:54:37 N.Kasai
    '備　考：
    Public Sub pubtxtCmdUp_Proc(ByVal lobjtxtEx As TextBoxEx, ByVal llngMaxDispRow As Integer, Optional ByVal lobjcmdUp As Button = Nothing, _
                           Optional ByVal lobjcmdDown As Button = Nothing)
        
        Dim llngStartRow        As Integer  '先頭行
        Dim llngAllRow          As Integer  '最大行
        
        With lobjtxtEx

            '@ﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(lobjtxtEx)
            
            '@PageUpｷｰ
            SendKeys.SendWait(CPstrSendKeysPageUp)
            
            '@先頭行
            llngStartRow = SendMessage(lobjtxtEx.hwnd, EM_GETFIRSTVISIBLELINE, 0, 0) + 1
            '@総行数
            llngAllRow = SendMessage(lobjtxtEx.hwnd, EM_GETLINECOUNT, 0, 0)

            '@上ｽｸﾛｰﾙ
            If llngStartRow = 1 Then
                lobjcmdUp.Enabled = False
            Else
                lobjcmdUp.Enabled = True
            End If
            
            '@下ｽｸﾛｰﾙ
            If llngAllRow > llngMaxDispRow Then
                lobjcmdDown.Enabled = True
            Else
                lobjcmdDown.Enabled = False
            End If
            
        End With
        
    End Sub

    '関数名：pubtxtCmdDown_Proc
    '機　能：ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
    '引　数：lobjtxtEx：ﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄ名
    '　　　：llngMaxDispRow：1ﾍﾟｰｼﾞ最大表示行数
    '　　　：lobjcmdUp：▲ﾎﾞﾀﾝ名
    '　　　：lobjcmdDown：▼ﾎﾞﾀﾝ名
    '戻り値：なし
    '作成日：2005/11/11 (Fri) 13:34:20 N.Kasai
    '更新日：2005/11/21 (Mon) 10:54:54 N.Kasai
    '備　考：
    Public Sub pubtxtCmdDown_Proc(ByVal lobjtxtEx As TextBoxEx, ByVal llngMaxDispRow As Integer, Optional ByVal lobjcmdUp As Button = Nothing, _
                             Optional ByVal lobjcmdDown As Button = Nothing)
        
        Dim llngStartRow        As Integer  '先頭行
        Dim llngAllRow          As Integer  '最大行

        
        With lobjtxtEx

            '@ﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(lobjtxtEx)

            '@PageDownｷｰ
            SendKeys.SendWait(CPstrSendKeysPageDown)
            
            '@先頭行
            llngStartRow = SendMessage(lobjtxtEx.hwnd, EM_GETFIRSTVISIBLELINE, 0, 0) + 1
            '@総行数
            llngAllRow = SendMessage(lobjtxtEx.hwnd, EM_GETLINECOUNT, 0, 0)
            
            '@上ｽｸﾛｰﾙ
            If llngStartRow = 1 Then
                lobjcmdUp.Enabled = False
            Else
                lobjcmdUp.Enabled = True
            End If
            
            '@下ｽｸﾛｰﾙ
            If llngAllRow - llngStartRow + 1 > llngMaxDispRow Then
                lobjcmdDown.Enabled = True
            Else
                lobjcmdDown.Enabled = False
            End If
            
        End With
        
    End Sub

    '関数名：pubtxtChange_Proc
    '機　能：ﾃｷｽﾄ変更処理
    '引　数：lobjtxtEx：ﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄ名
    '　　　：llngMaxDispRow：1ﾍﾟｰｼﾞ最大表示行数
    '　　　：lobjcmdUp：▲ﾎﾞﾀﾝ名
    '　　　：lobjcmdDown：▼ﾎﾞﾀﾝ名
    '戻り値：なし
    '作成日：2005/11/11 (Fri) 13:39:46 N.Kasai
    '更新日：2005/11/21 (Mon) 10:55:10 N.Kasai
    '備　考：ChangeとMouseUPに記述して下さい。
    Public Sub pubtxtChange_Proc(ByVal lobjtxtEx As TextBoxEx, ByVal llngMaxDispRow As Integer, Optional ByVal lobjcmdUp As Button = Nothing, _
                             Optional ByVal lobjcmdDown As Button = Nothing, Optional ByVal llngButton As MouseButtons = MouseButtons.Left)
        
        Dim llngStartRow        As Integer  '先頭行
        Dim llngAllRow          As Integer  '最大行
        
        '@MouseMoveにて左ｸﾘｯｸ以外は処理しない。
        Select Case llngButton
            '@ﾏｳｽｱｯﾌﾟ、右ｸﾘｯｸ
            Case MouseButtons.None, MouseButtons.Right
                Exit Sub
        End Select
        
        With lobjtxtEx

            '@総行数
            llngAllRow = SendMessage(lobjtxtEx.hwnd, EM_GETLINECOUNT, 0, 0)
            '@先頭行を取得
            llngStartRow = SendMessage(lobjtxtEx.hwnd, EM_GETFIRSTVISIBLELINE, 0, 0) + 1

            '@上ｽｸﾛｰﾙ
            If llngStartRow > 1 Then
                lobjcmdUp.Enabled = True
            Else
                lobjcmdUp.Enabled = False
            End If
            
            '@下ｽｸﾛｰﾙ
            If llngAllRow - llngStartRow > llngMaxDispRow - 1 Then
                lobjcmdDown.Enabled = True
            Else
                lobjcmdDown.Enabled = False
            End If
            
        End With
        
    End Sub

    '関数名：pubtxtKeyUp_Proc
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：lintKeyCode：ｷｰｺｰﾄﾞ
    '　　　：lobjtxtEx：ﾃｷｽﾄｵﾌﾞｼﾞｪｸﾄ名
    '　　　：llngMaxDispRow：1ﾍﾟｰｼﾞ最大表示行数
    '　　　：lobjcmdUp：▲ﾎﾞﾀﾝ名
    '　　　：lobjcmdDown：▼ﾎﾞﾀﾝ名
    '戻り値：なし
    '作成日：2005/11/14 (Mon) 12:57:38 N.Kasai
    '更新日：2005/12/05 (Mon) 14:18:44 N.Kojima
    '備　考：
    '　　　：2005/12/05 (Mon) 14:18:44 N.Kojima     Caseの判定に"CPlngKeyCode65"(Ctrl+Aｷｰ判定用)追加
    Public Sub pubtxtKeyUp_Proc(ByRef lintKeyCode As Keys, ByVal lobjtxtEx As TextBoxEx, ByVal llngMaxDispRow As Integer, _
                                Optional ByVal lobjcmdUp As Button = Nothing, _
                                Optional ByVal lobjcmdDown As Button = Nothing)


        Dim llngStartRow        As Integer  '先頭行
        Dim llngAllRow          As Integer  '最大行
        
        With lobjtxtEx
            '@Keyｺｰﾄﾞ判定
            Select Case lintKeyCode
            
                '@←、→、↑、↓、ﾍﾟｰｼﾞup、ﾍﾟｰｼﾞdown、delete、end、home、ctrl+A ｷｰの場合
                Case Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.PageDown, _
                    Keys.PageUp, Keys.Delete, Keys.End, Keys.Home, CPlngKeyCode65
                
                    '@総行数
                    llngAllRow = SendMessage(lobjtxtEx.hwnd, EM_GETLINECOUNT, 0, 0)
                    '@先頭行を取得
                    llngStartRow = SendMessage(lobjtxtEx.hwnd, EM_GETFIRSTVISIBLELINE, 0, 0) + 1
            
                    '@上ｽｸﾛｰﾙ
                    If llngStartRow > 1 Then
                        lobjcmdUp.Enabled = True
                    Else
                        lobjcmdUp.Enabled = False
                    End If
                    
                    '@下ｽｸﾛｰﾙ
                    If llngAllRow - llngStartRow > llngMaxDispRow - 1 Then
                        lobjcmdDown.Enabled = True
                    Else
                        lobjcmdDown.Enabled = False
                    End If
            
            End Select
            
        End With

    End Sub

    '関数名：pubvsfSideKeyDown
    '機　能：ｸﾞﾘｯﾄﾞｷｰ制御(左右)
    '引　数：lintKeyCode：ｷｰｺｰﾄﾞ
    '　　　：lstrActiveCtlNm：ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名
    '　　　：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    '　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    '　　　：lblnCmdButton：ｺﾏﾝﾄﾞﾎﾞﾀﾝの有無（True:あり、False:なし）
    '戻り値：なし
    '作成日：2007/07/10 (Tue) 09:10:19 N.Kasai
    '更新日：2007/07/10 (Tue) 09:10:19
    '備　考：
    Public Sub pubvsfSideKeyDown(ByRef lKeyEventArgs As KeyEventArgs, _
                                 ByVal lstrActiveCtlNm As String, _
                                 ByVal lobjvsfGrid As C1FlexGrid, _
                                 Optional ByVal lobjcmdLeft As Button = Nothing, _
                                 Optional ByVal lobjcmdRight As Button = Nothing, _
                                 Optional ByVal lblnCmdButton As Boolean = True)
        
        Dim llngRow             As Integer      'ｶｳﾝﾄ
        Dim llngActiveCol       As Integer      'ﾌｫｰｶｽがあたっているCol番号
        Dim llngLeftCol         As Integer      '画面表示最左Col番号
        Dim llngLeftColCal      As Integer      '計算後の最左Col番号
        Dim llngMinCol          As Integer      '固定Col数(最小Col数)
        Dim llngWidthAll        As Integer      'Col全体の幅
        Dim ltypScrollPos       As Point        'スクロール位置
        Dim ltypScrollRect      As Rectangle    'スクロール可能な部分

        '@初期設定
        llngLeftCol = 0
        llngLeftColCal = 0
        llngMinCol = 0
        llngWidthAll = 0
        

        With lobjvsfGrid
            Select Case lstrActiveCtlNm
                '@ｸﾞﾘｯﾄﾞﾌｫｰｶｽがある場合
                Case .Name
                    Select Case lKeyEventArgs.KeyCode
                       '@ｸﾞﾘｯﾄﾞｷｰ制御（[←]ｷｰﾎﾞﾀﾝ）
                        Case Keys.Left
                        
                            '@画面表示最左Col番号取得
                            llngLeftCol = .LeftCol

                            '@ﾌｫｰｶｽがあたっているCol番号取得
                            llngActiveCol = .Col

                            '@固定Col番号取得(CMlngvsfFrozenCols:固定列数 -1)
                            llngMinCol = .Cols.Fixed + .Cols.Frozen - 1

                            '@スクロール位置の取得
                            ltypScrollPos = .ScrollPosition
                            '@スクロール可能な部分の取得
                            ltypScrollRect = .ScrollableRectangle
                            
                            '@-----------
                            '@ｽｸﾛｰﾙ制御
                            '@-----------
                            If llngActiveCol = llngLeftCol Then
                                For llngloopcount = llngLeftCol - 1 To llngMinCol Step -1
                                    If llngloopcount >= 0 AndAlso _
                                            .Cols(llngloopcount).Visible = True Then
                                        llngLeftColCal = llngloopcount
                                        .ShowCell(llngRow, llngLeftColCal)
                                        Exit For
                                    End If
                                Next llngloopcount
                                
                            ElseIf llngLeftCol >= 0 AndAlso _
                                    ltypScrollRect.X + -(ltypScrollPos.X) <> .Cols(llngLeftCol).Left Then

                                'NSYS LeftColがスクロール境界からずれている場合(.NET)
                                'NSYS 左隣のセルがLeftColかどうか
                                Dim llngNextCol As Integer = -1
                                For llngloopcount = llngActiveCol - 1 To llngLeftCol Step -1
                                    If .Cols(llngloopcount).Visible = True Then
                                        llngNextCol = llngloopcount
                                        Exit For
                                    End If
                                Next
                                If llngNextCol = llngLeftCol Then
                                    'NSYS 左隣のセルがLeftColで境界がずれている場合、境界を揃える
                                    ltypScrollPos.X = -(.Cols(.LeftCol).Left - ltypScrollRect.X)
                                    .ScrollPosition = ltypScrollPos
                                End If
                            End If
                            
                            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝが存在する場合
                            If lblnCmdButton = True Then
                                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ使用可否制御
                                pubCmdLREnable_Set(lobjvsfGrid, lobjcmdLeft, lobjcmdRight)
                            End If
                            
                            '@ﾌｫｰｶｽをｾｯﾄ
                            Call pubSetFocus(lobjvsfGrid)
                            
                       '@ｸﾞﾘｯﾄﾞｷｰ制御（[→]ｷｰﾎﾞﾀﾝ）
                        Case Keys.Right
                        
                            '@画面表示最左Col番号取得。可動列がない場合は、-1
                            llngLeftCol = .LeftCol

                            '@ﾌｫｰｶｽがあたっているCol番号取得
                            llngActiveCol = .Col
                            
                            '@固定Col番号取得(CMlngvsfFrozenCols:固定列数 -1)
                            llngMinCol = .Cols.Fixed + .Cols.Frozen - 1
                            
                            '@全列数の幅取得(非表示項目は含めない)
                            If .Cols.Count <> 0 Then
                                llngWidthAll = .Cols(.Cols.Count - 1).Right
                            End If

                            '@スクロール位置の取得
                            ltypScrollPos = .ScrollPosition
                            '@スクロール可能な部分の取得
                            ltypScrollRect = .ScrollableRectangle

                            '@ｽｸﾛｰﾙ制御
                            If llngActiveCol > llngMinCol Then
                                If ltypScrollRect.X + -(ltypScrollPos.X) + ltypScrollRect.Width < llngWidthAll Then

                                    .LeftCol = llngLeftCol + 1
                                End If
                            End If
                            
                            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝが存在する場合
                            If lblnCmdButton = True Then
                                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ使用可否制御
                                pubCmdLREnable_Set(lobjvsfGrid, lobjcmdLeft, lobjcmdRight)
                            End If
                            
                            '@ﾌｫｰｶｽをｾｯﾄ
                            Call pubSetFocus(lobjvsfGrid)

                    End Select

            End Select
        End With

    End Sub

    '関数名：pubVsfCmdLeft
    '機　能：ｸﾞﾘｯﾄﾞ左ｽｸﾛｰﾙ処理
    '引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    '　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    '戻り値：なし
    '作成日：2007/06/27 (Wed) 10:24:07 N.Kasai
    '更新日：2007/06/27 (Wed) 10:24:07
    '備　考：
    Public Sub pubVsfCmdLeft(ByVal lobjvsfGrid As C1FlexGrid, _
                             Optional ByVal lobjcmdLeft As Button = Nothing, _
                             Optional ByVal lobjcmdRight As Button = Nothing)

        Dim llngLeftCol         As Integer  '画面表示最左Col番号
        Dim llngLeftColCal      As Integer  '計算後の最左Col番号
        Dim llngMinCol          As Integer  '固定Col数
        Dim llngRow             As Integer  '取得Row番号
        Dim ltypScrollPos       As Point        'スクロール位置
        Dim ltypScrollRect      As Rectangle    'スクロール可能な部分

        '@初期設定
        llngLeftCol = 0
        llngLeftColCal = 0
        llngMinCol = 0

        With lobjvsfGrid
            '@画面表示最左Col番号取得
            llngLeftCol = .LeftCol
            
            '@固定Col番号取得(=.FrozenCols:固定列数 -1)
            llngMinCol = .Cols.Fixed + .Cols.Frozen - 1
            
            '@スクロール位置の取得
            ltypScrollPos = .ScrollPosition
            '@スクロール可能な部分の取得
            ltypScrollRect = .ScrollableRectangle
            
            '@一覧ｽｸﾛｰﾙ制御
            If llngLeftCol >= 0 AndAlso _
                    ltypScrollRect.X + -(ltypScrollPos.X) <> .Cols(llngLeftCol).Left Then

                'NSYS LeftColがスクロール境界からずれている場合がある(.NET)
                '     LeftColがスクロール境界からずれている場合、境界を揃える
                ltypScrollPos.X = -(.Cols(.LeftCol).Left - ltypScrollRect.X)
                .ScrollPosition = ltypScrollPos

            ElseIf ltypScrollPos.X < 0 Then
                '@ｸﾞﾘｯﾄﾞの固定列より,可動する列(最左)が小さい場合
                '@前列の表示列の検索
                For llngloopcount = llngLeftCol - 1 To llngMinCol Step -1
                    If llngloopcount >= 0 AndAlso _
                            .Cols(llngloopcount).Visible = True Then
                        llngLeftColCal = llngloopcount
                        '@前列の表示
                        .ShowCell(llngRow, llngLeftColCal)
                        Exit For
                    End If
                Next llngloopcount
            End If
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ使用可否制御
            pubCmdLREnable_Set(lobjvsfGrid, lobjcmdLeft, lobjcmdRight)
            
            '@ﾌｫｰｶｽをｾｯﾄ
            Call pubSetFocus(lobjvsfGrid)
        End With

    End Sub

    '関数名：pubVsfCmdRight
    '機　能：ｸﾞﾘｯﾄﾞ右ｽｸﾛｰﾙ処理
    '引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    '　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    '戻り値：なし
    '作成日：2007/06/27 (Wed) 10:16:21 N.Kasai
    '更新日：2007/06/27 (Wed) 10:16:21
    '備　考：
    Public Sub pubVsfCmdRight(ByVal lobjvsfGrid As C1FlexGrid, _
                              Optional ByVal lobjcmdLeft As Button = Nothing, _
                              Optional ByVal lobjcmdRight As Button = Nothing)

        Dim llngLeftCol         As Integer      '画面表示最左Col番号
        Dim llngWidthAll        As Integer      'Col全体の幅
        Dim ltypScrollPos       As Point        'スクロール位置
        Dim ltypScrollRect      As Rectangle    'スクロール可能な部分

        '@初期設定
        llngLeftCol = 0
        
        With lobjvsfGrid
            '@ｽｸﾛｰﾙ制御(最終列直前まで)
            llngLeftCol = .LeftCol
            .LeftCol = llngLeftCol + 1

            If .LeftCol = llngLeftCol Then
                'NSYS LeftColでスクロールしない場合、ScrollPositionで右端までスクロールする
                If .Cols.Count <> 0 Then
                    '@全列数の幅取得(非表示項目は含めない)
                    llngWidthAll = .Cols(.Cols.Count - 1).Right

                    '@スクロール位置の取得
                    ltypScrollPos = .ScrollPosition
                    '@スクロール可能な部分の取得
                    ltypScrollRect = .ScrollableRectangle

                    ltypScrollPos.X = -(llngWidthAll - ltypScrollRect.X - ltypScrollRect.Width)
                    .ScrollPosition = ltypScrollPos
                End If
            End If

            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ使用可否制御
            pubCmdLREnable_Set(lobjvsfGrid, lobjcmdLeft, lobjcmdRight)
        
            '@ﾌｫｰｶｽをｾｯﾄ
            Call pubSetFocus(lobjvsfGrid)
        End With

    End Sub

    ' ----------------------------------------------------------------------------------------
    '    ****** スクロール位置の計算方法 (.NET版) ******   NSYS 2019/05/20
    '
    '以下のようなグリッドがあるとする。
    '
    '  .Cols.Fixed = 1
    '  .Cols.Frozen = 2
    '  .Cols.Count = 10
    '
    'スクロール領域を考慮しない場合の全体の配置と幅は、以下の通り
    '
    '        Fix   Fro   Fro
    '      +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
    'Cols  | 列0 | 列1 | 列2 | 列3 | 列4 | 列5 | 列6 | 列7 | 列8 | 列9 |
    '      +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
    'Hidden|     | Hid |     |     |     |     | Hid |     |     |     |
    '      +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
    'Width | 100 |   0 | 100 | 100 | 100 | 100 |   0 | 100 | 100 | 100 |
    '      +-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
    '       <---> <---> <---> <---> <---> <---> <---> <---> <---> <--->
    'Right       ^100  ^100  ^200  ^300  ^400  ^500  ^500  ^600  ^700  ^800 ←総幅
    '
    'Cols(x).Right プロパティは、グリッドの左端からこの列の右端までのピクセル数。
    '最右のセルのRightプロパティは総幅に一致する。
    '非表示行は 0ピクセルと計算される。
    'ちなみに、C1FlexGrid本体の Width プロパティは内側のボーダーを含む外形のためボーダー分、
    '数ピクセルほど大きい。
    '
    '      +-----------------+----------------------------+
    '      |    固定列       |  ScrollableRectangle       |
    '      +-----------------+----------------------------+
    '      |---------------->
    '                        ^ X=200
    '                         <-------------------------->
    '                                                     ^ Width=379
    '
    'ScrollableRectangle は、X が固定行の右端の位置、Widthがスクロール領域の幅を示す。
    'ScrollPosition は、実際のスクロールの表示位置が固定列の右端からどれくらいずれているかを示す。
    'スクロール領域の左端を原点(0)とみて、マイナス値を返す。
    '
    '●スクロール位置が列3の左端の場合
    '
    '      +-----------------+----------------------------+             |
    '      |    固定列       |  ScrollableRectangle       |             |
    '      +-----------------+----------------------------+             |
    '             X=200                  Width=379                      総幅=800
    '       <--------------->+<-------------------------->
    '       ScrollPosition   ^ X=0
    '
    '●スクロール位置が列5の左端の場合
    '
    '      +-----------------+           +---------------------------+  |
    '      |    固定列       |           |  ScrollableRectangle      |  |
    '      +-----------------+           +---------------------------+  |
    '             X=200                             Width=379           総幅=800
    '       <--------------->             <------------------------->
    '                         <----------|
    '       ScrollPosition   ^ X=(-200)  0
    '          固定列の幅    +    ずれ   +      スクロール領域の幅   = スクロール右端の位置
    '              200       +  -(-200)  +            379            =  779
    '                                                                (右端から21ピクセル離れている)
    '
    '●スクロール位置が列9の右端の場合
    '
    '      +-----------------+             +----------------------------+
    '      |    固定列       |             |  ScrollableRectangle       |
    '      +-----------------+             +----------------------------+
    '             X=200                               Width=379         総幅=800
    '       <--------------->               <-------------------------->
    '                         <------------|
    '       ScrollPosition   ^ X=(-221)    0
    '          固定列の幅    +    ずれ     +      スクロール領域の幅    = スクロール右端の位置
    '              200       +  -(-221)    +            379             = 800
    '                                                                  (右端に達している)
    ' ----------------------------------------------------------------------------------------

    '関数名：pubCmdLREnable_Set
    '機　能：左右ｽｸﾛｰﾙﾎﾞﾀﾝ使用可否制御
    '引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    '　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    '戻り値：なし
    '作成日：2007/07/09 (Mon) 12:01:47 N.Kasai
    '更新日：2007/07/09 (Mon) 12:01:47
    '備　考：
    Public Sub pubCmdLREnable_Set(ByVal lobjvsfGrid As C1FlexGrid, _
                              Optional ByVal lobjcmdLeft As Button = Nothing, _
                              Optional ByVal lobjcmdRight As Button = Nothing)
        
        Dim llngWidthAll        As Integer  'ｸﾞﾘｯﾄﾞ幅
        Dim ltypScrollPos       As Point        'スクロール位置
        Dim ltypScrollRect      As Rectangle    'スクロール可能な部分

        
        With lobjvsfGrid
            
            '@ﾃﾞｰﾀ0件の場合
            If .Rows.Count = .Rows.Fixed + .Rows.Frozen Then
                lobjcmdLeft.Enabled = False
                lobjcmdRight.Enabled = False
                Exit Sub
            End If
            
            '@全列数の幅取得(非表示項目は含めない)
            If .Cols.Count <> 0 Then
                llngWidthAll = .Cols(.Cols.Count - 1).Right
            End If
            
            '@スクロール位置の取得
            ltypScrollPos = .ScrollPosition
            '@スクロール可能な部分の取得
            ltypScrollRect = .ScrollableRectangle
            
            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ
            '@使用可の判定
            If ltypScrollPos.X = 0 Then
                lobjcmdLeft.Enabled = False
            Else
                lobjcmdLeft.Enabled = True
            End If

            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ
            '@ｸﾞﾘｯﾄﾞ幅と比較して右ｽｸﾛｰﾙﾎﾞﾀﾝを使用可とするか判断
            '@全列数の幅が表示領域よりも狭い場合もある
            If ltypScrollRect.X + -(ltypScrollPos.X) + ltypScrollRect.Width >= llngWidthAll Then
                lobjcmdRight.Enabled = False
            Else
                lobjcmdRight.Enabled = True
            End If
            
        End With

    End Sub

    '関数名：pubChangeScreen_Set
    '機　能：親画面切り替え引継ぎ制御
    '引　数：lobjForm：自ﾌｫｰﾑ
    '戻り値：なし
    '作成日：2007/07/12 (Thu) 11:14:15 N.Kasai
    '更新日：2007/07/12 (Thu) 11:14:15
    '備　考：
    Public Sub pubChangeScreen_Set(ByVal lobjForm As Form)
     
        '@引継ぎ親画面を判定
        Select Case True
        
            Case pblnfrmxxEN0150Kbn
                '@装置別ﾛｯﾄ一覧を起動する
                Call pubMenuSelect_Proc(CPstrKeyEN0150)

    '@↓2018/08/09 (Thu) 17:56:06 Y.Yoneyama **************************************************
            Case pblnfrmxxEN0151Kbn
                '@装置別ﾛｯﾄ一覧(防湿ALD)を起動する
                Call pubMenuSelect_Proc(CPstrKeyEN0151)
    '@↑2018/08/09 (Thu) 17:56:06 Y.Yoneyama **************************************************
            
            Case pblnfrmxxEN00J0Kbn
                '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                Call pubMenuSelect_Proc(CPstrKeyEN00J0)
            
            Case pblnfrmxxEN0200Kbn
                '@工程別ﾛｯﾄ一覧を起動する
                Call pubMenuSelect_Proc(CPstrKeyEN0200)
        
            Case Else
                '@例外処理
                 lobjForm.Close()
                 
        End Select

    End Sub

    '関数名：pubGuidMsg_Set
    '機　能：ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
    '引　数：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ
    '　　　：lobjForm：自ﾌｫｰﾑ
    '戻り値：なし
    '作成日：2007/07/23 (Mon) 11:54:40 N.Kasai
    '更新日：2007/07/23 (Mon) 11:54:40
    '備　考：
    Public Sub pubGuidMsg_Set(ByVal lstrGuidMsgCode As String, ByVal lstrGuidMsg As String, ByVal lobjForm As Form)
        
        Dim lstrEditGuidance As String  'ﾒｯｾｰｼﾞ内容編集

        '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
        If lstrGuidMsgCode <> vbNullString Then
        
            '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
            lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & _
                                CPstrBracketRight & CPstrMsgCrCode & lstrGuidMsg
            
            '@【警告】ガイダンスメッセージ$$ガイダンスコード[  ]$$
            pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
            '@ﾒｯｾｰｼﾞ表示
            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lobjForm.Text, True, 16)
        End If

    End Sub

    '関数名：pubLotNextSendResultPopUp
    '機　能：次工程送出ﾒｯｾｰｼﾞ送信結果受信時のﾎﾟｯﾌﾟｱｯﾌﾟ表示
    '引　数：strSendResult       ：[lot_.nextsend]のSEND_RESULT
    '引　数：strCarrierId        ：ｷｬﾘｱID
    '引　数：strLotId            ：ﾛｯﾄID
    '戻り値：なし
    '作成日：2009/01/16 (Fri) 14:18:06 M.Koni
    '更新日：
    '備　考：
    Public Sub pubLotNextSendResultPopUp(ByVal strSendResult As String, _
                                         ByVal strCarrierId As String, _
                                         ByVal strLotID As String)

        Select Case strSendResult
            '@完成在庫へ
            Case CPstrKansei
                '@表示ﾒｯｾｰｼﾞ変換("<TRM3UI>$$流動、完了しました。キャリア[%1] ロット[%2]$[完成在庫へ送出]しました。")
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003U, strCarrierId, strLotID, CPstrKanseiZaiko)
        
            '@中間在庫へ
            Case CPstrChukan
                '@表示ﾒｯｾｰｼﾞ変換("<TRM3UI>$$流動、完了しました。キャリア[%1] ロット[%2]$[中間在庫へ送出]しました。")
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003U, strCarrierId, strLotID, CPstrChukanZaiko)
        
            '@組立送品(受入在庫)
            Case CPstrSouhin
                '@表示ﾒｯｾｰｼﾞ変換("<TRM3UI>$$流動、完了しました。キャリア[%1] ロット[%2]$[組立工程へ送品]しました。")
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003U, strCarrierId, strLotID, CPstrSouhinZaiko)

            '送出待ち
            Case CPstrSendWait
                '"<TRM84I>$$組立投入予定日前のため、送出を中止しました。キャリア[%1] ロット[%2]$[%3]しました。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0084, strCarrierId, strLotID, CPstrInvSendAbortMsg)

            '送出中止
            Case CPstrSendAbort
                '"<TRM85I>$$送出を中止しました。キャリア[%1] ロット[%2]$[%3]しました。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0085, strCarrierId, strLotID, CPstrSendAbortMsg)

            '@例外(通常skip)
            Case Else
                '@表示ﾒｯｾｰｼﾞ変換("<TRM0AI>$$流動、完了しました。キャリア[%1] ロット[%2]")
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000A, strCarrierId, strLotID)
        End Select

    End Sub

    '関数名：prvFocus_Set
    '機　能：ﾌｫｰｶｽの戻り位置を設定
    '引　数：lobjControl: VSFlexGridオブジェクト
    '　　　：lstrKeyID：KeyID
    '　　　：llngKeyColNo：KeyIDのCol位置
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 11:04:48 N.Kasai
    '更新日：2012/01/24 (Tue) 09:30:40 T.Oide
    '備　考：ﾛｯﾄNoを検索してHitした場合は該当行にﾌｫｰｶｽｾｯﾄする。ない場合はｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
    '　　　：PrivateからPublicの関数に変更(元：prvFocus_Set）
    Public Sub pubGridFocus_Set(ByVal lobjControl As C1FlexGrid, _
                                ByVal lstrKeyID As String, _
                                ByVal llngKeyColNo As Integer, _
                                ByVal lobjCmdControl As Button)

        Dim llngRowCnt     As Integer      'ｶｳﾝﾄ
        
        With lobjControl
        
            '@確定ﾎﾞﾀﾝ押下前のﾌｫｰｶｽ位置を検索
            For llngRowCnt = 0 To .Rows.Count - 1
            
                '@ﾛｯﾄNo検索
                If .GetData(llngRowCnt, llngKeyColNo) = lstrKeyID Then
                    
                    '@行の選択範囲を設定
                    .Row = llngRowCnt
                    
                    '@選択行を表示
                    .ShowCell(llngRowCnt, llngKeyColNo)
                    
                    Exit Sub
                    
                End If
                
            Next llngRowCnt
            
            '@ﾌｫｰｶｽｾｯﾄ
            '@明細行が1件もない場合ﾌｫｰｶｽの戻り位置を制御
            If .Enabled = False Then
                Call pubSetFocus(lobjCmdControl)
            Else
                Call pubSetFocus(lobjControl)
            End If
        End With

    End Sub


    '***************************************************************************************
    '                              * NSYS 追加　関数 *
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：pubVsfMouseWheelManager_Set
    '機　能：ｸﾞﾘｯﾄﾞｷｰ制御(マウスホイールマネージャー)設定
    '引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：lobjCmdUp：前頁ﾎﾞﾀﾝ
    '　　　：lobjCmdDown：次頁ﾎﾞﾀﾝ
    '　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    '　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    '戻り値：VsfMouseWheelManager オブジェクト
    '作成日：2019/06/22 (Sat) 12:00:00 NSYS
    '更新日：
    '備　考：
    Public Function pubVsfMouseWheelManager_Set( _
                                ByVal lobjvsfGrid As C1FlexGrid, _
                                ByVal lobjcmdUp As Button, _
                                ByVal lobjcmdDown As Button, _
                                Optional ByVal lobjcmdLeft As Button = Nothing, _
                                Optional ByVal lobjcmdRight As Button = Nothing) As VsfMouseWheelManager

        pubVsfMouseWheelManager_Set = New VsfMouseWheelManager(lobjvsfGrid, lobjCmdUp, lobjcmdDown, lobjcmdLeft, lobjcmdRight)

    End Function

    'クラス：VsfMouseWheelManager
    '機　能：ｸﾞﾘｯﾄﾞ制御(マウスホイールマネージャー)
    '作成日：2019/06/22 (Sat) 12:00:00 NSYS
    '更新日：
    '備　考：
    Public Class VsfMouseWheelManager

        'NSYS ホイール移動処理後 発生する
        Public Event AfterMouseWheel(ByVal sender As Object, ByVal e As EventArgs)

        Private Dim mobjvsfGrid         As C1FlexGrid       'グリッド
        Private Dim mobjcmdUp           As Button           '前頁ﾎﾞﾀﾝ
        Private Dim mobjcmdDown         As Button           '次頁ﾎﾞﾀﾝ
        Private Dim mobjcmdLeft         As Button           '左ﾎﾞﾀﾝ
        Private Dim mobjcmdRight        As Button           '右ﾎﾞﾀﾝ
        Private Dim mblnInvisible       As Boolean          '上の行が非表示になっているか

        '関数名：コンストラクタ
        '機　能：ｸﾞﾘｯﾄﾞｷｰ制御(マウスホイールマネージャー)生成
        '引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
        '　　　：lobjCmdUp：前頁ﾎﾞﾀﾝ
        '　　　：lobjCmdDown：次頁ﾎﾞﾀﾝ
        '戻り値：なし
        '作成日：2019/06/22 (Sat) 12:00:00 NSYS
        '更新日：
        '備　考：
        Sub New(ByVal lobjvsfGrid As C1FlexGrid, _
                ByVal lobjcmdUp As Button, _
                ByVal lobjcmdDown As Button, _
                ByVal lobjcmdLeft As Button, _
                ByVal lobjcmdRight As Button)

            mobjvsfGrid = lobjvsfGrid
            mobjcmdUp = lobjcmdUp
            mobjcmdDown = lobjcmdDown
            mobjcmdLeft = lobjcmdLeft
            mobjcmdRight = lobjcmdRight

            AddHandler lobjvsfGrid.MouseWheel, AddressOf flex_MouseWheel
            AddHandler lobjvsfGrid.BeforeScroll, AddressOf flex_BeforeScroll
            AddHandler lobjvsfGrid.AfterScroll, AddressOf flex_AfterScroll
        End Sub

        '関数名：flex_MouseWheel
        '機　能：マウスホイールでのスクロール時の処理を行う
        '引　数：sender：イベント発生源のオブジェクト
        '　　　：e  ：イベントに関連する補足情報
        '戻り値：なし
        '作成日：2019/06/22 (Sat) 12:00:00 NSYS
        '更新日：
        '備　考：
        Private Sub flex_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim llngRow 		As Integer  '行
            Dim lstrTopRow 		As String   '前回TopRow
            Dim llngTopRow      As Integer  '前回TopRow (数値)
            Dim llngScrollLines As Integer  'マウスの回転数あたりのスクロールライン数

            'NSYS 上の行が非表示になっている場合
            If mblnInvisible = True AndAlso e.Delta > 0 Then

                With mobjvsfGrid

                    '@非表示行を表示
                    For llngRow = .Rows.Fixed To .Rows.Count - 1
                        .Rows.Item(llngRow).Visible = True
                    Next llngRow

                    '@前回TopRowを取得
                    lstrTopRow = pubstrVsfTag_Get(mobjvsfGrid, 1)

                    If lstrTopRow = vbNullString Then
                        '@前回ｶﾚﾝﾄ行がない場合
                        '@頁先頭行格納
                        llngTopRow = .TopRow
                    Else
                        llngTopRow = Val(lstrTopRow)
                    End If

                    'NSYS 前回TopRowが 2行目以降
                    If llngTopRow > (.Rows.Fixed + .Rows.Frozen) Then

                        'NSYS システム設定のスクロール行数取得
                        llngScrollLines = SystemInformation.MouseWheelScrollLines
                        'NSYS スクロール行数分、上に移動する
                        '     この代入で flex_AfterScroll イベントが発生し、活性制御が行われる
                        .TopRow = llngTopRow - llngScrollLines
                    End If

                End With

            End If

            'NSYS フラグを元に戻す
            mblnInvisible = False
            
            'NSYS イベント送信
            RaiseEvent AfterMouseWheel(Me, EventArgs.Empty)

        End Sub

        '関数名：flex_BeforeScroll
        '機　能：スクロール前処理
        '引　数：sender：イベント発生源のオブジェクト
        '　　　：e  ：イベントに関連する補足情報
        '戻り値：なし
        '作成日：2019/06/22 (Sat) 12:00:00 NSYS
        '更新日：
        '備　考：
        Private Sub flex_BeforeScroll(ByVal sender As Object, ByVal e As RangeEventArgs)

            'NSYS ここより上の行が非表示になっている場合、True
            '     非表示行を除き表示できる行の一番上が表示されている状態で、ホイールを上に回すと、
            '     e.NewRange.r1 = -1 が設定されイベントが発生する
            If e.NewRange.r1 < 0 Then
                mblnInvisible = True
            Else
                mblnInvisible = False
            End If
        End Sub

        '関数名：flex_AfterScroll
        '機　能：スクロール後処理
        '引　数：sender：イベント発生源のオブジェクト
        '　　　：e  ：イベントに関連する補足情報
        '戻り値：なし
        '作成日：2019/07/03 (Wed) 10:00:00 NSYS
        '更新日：
        '備　考：
        Private Sub flex_AfterScroll(sender As Object, e As EventArgs)

            Dim lstrTopRow 		As String   '前回TopRow
            Dim llngTopRow      As Integer  '前回TopRow (数値)

            lstrTopRow = pubstrVsfTag_Get(mobjvsfGrid, 1)
            If lstrTopRow <> vbNullString Then
                llngTopRow = Val(lstrTopRow)
            End If

            'NSYS TagのTopRowと.TopRowが異なる場合、活性制御を行う
            If lstrTopRow = vbNullString OrElse llngTopRow <> mobjvsfGrid.TopRow Then
            
                'NSYS ｸﾞﾘｯﾄﾞ表示後処理（グリッド共通仕様）を実行する
                Call pubVsfDisp(mobjvsfGrid, mobjCmdUp, mobjCmdDown)

                'NSYS グリッド共通仕様で対応できない行の高さがバラバラの場合に対応
                If mobjcmdDown IsNot Nothing Then
                    If mobjvsfGrid.BottomRow >= mobjvsfGrid.Rows.Count - 1 OrElse _
                        mobjvsfGrid.BottomRow < 0 Then
                        '@ﾛｯｸ
                        mobjcmdDown.Enabled = False
                    Else
                        '@ﾛｯｸ解除
                        mobjcmdDown.Enabled = True
                    End If
                End If
            End If

            If mobjcmdLeft IsNot Nothing OrElse mobjcmdRight IsNot Nothing Then
                pubCmdLREnable_Set(mobjvsfGrid, mobjcmdLeft, mobjcmdRight)
            End If

        End Sub

    End Class

End Module
