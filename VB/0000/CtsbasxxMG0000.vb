'ﾌｧｲﾙ名：xxMG0000.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：メニュー 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/06/08 (Tue) 18:28:47 H.Wajima
'更新日：2004/06/08 (Tue) 18:28:47
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0000
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
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Friend =====================================
    '================================== Private ====================================
    '関数名：pubblnUtilRefMenuFavor_Sel
    '機　能：メニューお気に入り取得
    '引　数：lstrutilrefmenu_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrEmpID：ﾕｰｻﾞｰ名
    '　　　：lstrMenuKind：ﾒﾆｭｰ種別
    '　　　：llngFavoriteListCnt：お気に入りﾘｽﾄ件数
    '　　　：ltyprefmenufavor：お気に入り取得構造体
    '戻り値：True:成功、False:失敗
    '作成日：2004/04/27 (Tue) 17:44:38 H.Wajima
    '更新日：2004/09/13 (Mon) 10:37:25 N.Kasai
    '備　考：2004/09/13 (Mon) 10:37:25 N.Kasai 新com対応
    Public Function pubblnUtilRefMenuFavor_Sel(ByVal lstrutilrefmenu_Ver As String, ByVal lstrLoginID As String, ByVal lstrMenuKind As String, _
                                          ByRef llngFavoriteListCnt As Integer, ByRef ltyprefmenu_ As refmenu_) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim lstrErrMsg          As String           'ｴﾗｰ用
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim lstrSeqNum          As String           '順番退避領域
        Dim lstrFunctionID      As String           '機能名退避領域
        
        Try
            
            '@メッセージ用処理名の設定
            pstrMessageName = "お気に入り取得"
            '@当関数の戻り値にFalseを設定する
            pubblnUtilRefMenuFavor_Sel = False
            
            '@メッセージ領域の初期化
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrLoginID <> vbNullString Then
                Call lrMsg.addString(CPstrLOGIN_ID, lstrLoginID)        'ﾕｰｻﾞｰ名
            Else
                Call lrMsg.addString(CPstrLOGIN_ID, CPstrMsgNull)       'ﾕｰｻﾞｰ名
            End If
            If lstrMenuKind <> vbNullString Then
                Call lrMsg.addString(CPstrMENU_KIND, lstrMenuKind)      'ﾒﾆｭｰ種別
            Else
                Call lrMsg.addString(CPstrMENU_KIND, CPstrMsgNull)      'ﾒﾆｭｰ種別
            End If
            Call lrMsg.addString(CPstrMSG_VER, lstrutilrefmenu_Ver)    'Msgﾊﾞｰｼﾞｮﾝ
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrutilrefmenu_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@ﾃﾞｰﾀを取得
                    Call laMsg.getString(CPstrTAKING_OVER_FLAG, ltyprefmenu_.strTakingOverFlag)     '引継ぎフラグ
                    Call laMsg.getMsgAry(CPstrFAVORITE_LIST, laAry)
                    '@ｱﾚｰの数が0じゃなければ処理
                    Select Case laAry.Count
                        Case 1
                            '@1件の場合、ﾃﾞｰﾀが1件あるのか、0件でﾀﾞﾐｰｱﾚｲが1件なのかを判定
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Call ltMsg.getString(CPstrSEQ_NUM, lstrSeqNum)                  '順番
                                Call ltMsg.getString(CPstrFUNCTION_ID, lstrFunctionID)          '機能名
                            Next
                            '@順番と機能名が空白かどうかを判定
                            If lstrSeqNum = CPstrMsgNull And lstrFunctionID = CPstrMsgNull Then
                                '@両方とも空白の場合
                                '@ﾘｽﾄ件数に0を設定
                                llngFavoriteListCnt = 0
                                '@配列の要素数を設定
                                ltyprefmenu_.typFavoriteList.Add(New FavoriteList)
                            Else
                                '@中身が入っている場合
                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                llngCnt = laAry.Count
                                llngFavoriteListCnt = llngCnt
                                '@配列の要素数を設定
                                For i As Integer = 0 To llngCnt - 1
                                    ltyprefmenu_.typFavoriteList.Add(New FavoriteList)
                                Next
                                llngCnt = 0
                                '@ｱﾚｰの各要素取得
                                For Each ltMsg In laAry
                                    Dim typFavoriteListTmp As FavoriteList = ltyprefmenu_.typFavoriteList(llngCnt)
                                    With typFavoriteListTmp
                                        Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)                  '順番
                                        Call ltMsg.getString(CPstrFUNCTION_ID, .strFunctionID)          '機能名
                                    End With
                                    ltyprefmenu_.typFavoriteList(llngCnt) = typFavoriteListTmp
                                    llngCnt = llngCnt + 1
                                Next
                            End If
                        Case Is <> 0
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = laAry.Count
                            llngFavoriteListCnt = llngCnt
                            '@配列の要素数を設定
                            If ltyprefmenu_.typFavoriteList Is Nothing
                                ltyprefmenu_.typFavoriteList = New List(Of FavoriteList)
                            End If
                            For i As Integer = 0 To llngCnt - 1
                                ltyprefmenu_.typFavoriteList.Add(New FavoriteList)
                            Next
                            llngCnt = 0
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Dim typFavoriteListTmp As FavoriteList = ltyprefmenu_.typFavoriteList(llngCnt)
                                With typFavoriteListTmp
                                    Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)                  '順番
                                    Call ltMsg.getString(CPstrFUNCTION_ID, .strFunctionID)          '機能名
                                End With
                                ltyprefmenu_.typFavoriteList(llngCnt) = typFavoriteListTmp
                                llngCnt = llngCnt + 1
                            Next
                    End Select
                    
                    '@関数の処理結果(成功)格納
                    pubblnUtilRefMenuFavor_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ｴﾗｰﾒｯｾｰｼﾞ取得
                    Call laMsg.getString(CPstrERRMSG, lstrErrMsg)
                    
                    '@ｻｰﾊﾞｰﾒｯｾｰｼﾞ判別
                    If Left(lstrErrMsg, CPlngVersion) = CPstrVersion Then
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, lstrutilrefmenu_Ver)
                    Else
                        '@「お気に入り取得に失敗しました。」  ﾒｯｾｰｼﾞ表示
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        
                    End If
                    
                    '@メッセージボックス共通関数を実行する
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「お気に入り取得に失敗しました。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            
        End Try
    End Function

    '関数名：pubblnUtilRegMenuFavor_Upd
    '機　能：メニューお気に入り登録
    '引　数：lstrutilregmenu_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypRegMenuFavor：お気に入り登録構造体
    '戻り値：True:成功、False:失敗
    '作成日：2004/04/27 (Tue) 18:03:16 H.Wajima
    '更新日：2004/04/27 (Tue) 18:03:16
    '備　考：
    Public Function pubblnUtilRegMenuFavor_Upd(ByVal lstrutilregmenu_Ver As String, ByRef ltypRegMenu_ As regmenu_) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        Dim lstrErrMsg          As String           'ｴﾗｰ用
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            '@メッセージ用処理名の設定
            pstrMessageName = "お気に入り登録"
            '@当関数の戻り値にFalseを設定する
            pubblnUtilRegMenuFavor_Upd = False
            
            '@メッセージ領域の初期化
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypRegMenu_
            
                If .strLogInID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOGIN_ID, .strLogInID)                                    'ﾕｰｻﾞｰ名
                Else
                    Call lrMsg.addString(CPstrLOGIN_ID, CPstrMsgNull)                                   'ﾕｰｻﾞｰ名
                End If
                If .strMenuKind <> vbNullString Then
                    Call lrMsg.addString(CPstrMENU_KIND, .strMenuKind)                                  'ﾒﾆｭｰ種別
                Else
                    Call lrMsg.addString(CPstrMENU_KIND, CPstrMsgNull)                                  'ﾒﾆｭｰ種別
                End If
                If .strTakingOverFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrTAKING_OVER_FLAG, .strTakingOverFlag)                 '引継ぎフラグ
                Else
                    Call lrMsg.addString(CPstrTAKING_OVER_FLAG, CPstrMsgNull)                       '引継ぎフラグ
                End If
                
                '@お気に入りﾘｽﾄ
                llngCnt = 0
                Do While .typFavoriteList.Count - 1 >= llngCnt
                    If .typFavoriteList(llngCnt).strSeqNum <> vbNullString Then
                        Call ltMsg.addString(CPstrSEQ_NUM, .typFavoriteList(llngCnt).strSeqNum)         '順番
                    Else
                        Call ltMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)                                '順番
                    End If
                    If .typFavoriteList(llngCnt).strFunctionID <> vbNullString Then
                        Call ltMsg.addString(CPstrFUNCTION_ID, .typFavoriteList(llngCnt).strFunctionID) '機能名
                    Else
                        Call ltMsg.addString(CPstrFUNCTION_ID, CPstrMsgNull)                            '機能名
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                    llngCnt = llngCnt + 1
                Loop
                
                Call lrMsg.addMsgAry(CPstrFAVORITE_LIST, lrAry)
                lrAry.Clear
                
            End With
            Call lrMsg.addString(CPstrMSG_VER, lstrutilregmenu_Ver)                                'Msgﾊﾞｰｼﾞｮﾝ
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrutilregmenu_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnUtilRegMenuFavor_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ｴﾗｰﾒｯｾｰｼﾞ取得
                    Call laMsg.getString(CPstrERRMSG, lstrErrMsg)
                    
                    '@ｻｰﾊﾞｰﾒｯｾｰｼﾞ判別
                    If Left(lstrErrMsg, CPlngVersion) = CPstrVersion Then
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, lstrutilregmenu_Ver)
                    Else
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(lstrErrMsg)
                    End If
                    
                    '@メッセージボックス共通関数を実行する
                    '@publngMsgBoxInfo("メッセージコード：C_E13%0$$お気に入りへ登録できませんでした。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0013)
                    '@publngMsgBoxInfo("メッセージコード：C_E13%0$$お気に入りへ登録できませんでした。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnUtilInformation_Sel
    '機　能：メニューお知らせ取得
    '引　数：lstrUtilFuncInfo_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrTerminalMode：端末区分(M：工程端末、S：ｽﾀｯﾌ端末)
    '　　　：lstrInformation：お知らせ
    '戻り値：
    '作成日：2004/07/20 (Tue) 10:31:44 H.Wajima
    '更新日：2004/07/21 (Wed) 11:25:51 H.Wajima
    '備　考：
    Public Function pubblnUtilInformation_Sel(ByVal lstrUtilFuncInfo_Ver As String, _
                                            ByVal lstrSBID As String, _
                                            ByVal lstrTerminalMode As String, _
                                            ByRef lstrInformation As String)
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim lstrErrMsg          As String           'ｴﾗｰ用
        
        Try
            
            '@メッセージ用処理名の設定
            pstrMessageName = "お知らせ取得"
            '@当関数の戻り値にFalseを設定する
            pubblnUtilInformation_Sel = False
            
            '@メッセージ領域の初期化
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            Call lrMsg.addString(CPstrMSG_VER, lstrUtilFuncInfo_Ver)    'Msgﾊﾞｰｼﾞｮﾝ
            
            '@SBID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@端末種別
            If lstrTerminalMode <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS, lstrTerminalMode)
            Else
                Call lrMsg.addString(CPstrCLASS, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrutilinformation, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@ﾃﾞｰﾀを取得
                    Call laMsg.getString(CPstrINFORMATION, lstrInformation)     'お知らせ
                    
                    '@関数の処理結果(成功)格納
                    pubblnUtilInformation_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ｴﾗｰﾒｯｾｰｼﾞ取得
                    Call laMsg.getString(CPstrERRMSG, lstrErrMsg)
                    
                    '@ｻｰﾊﾞｰﾒｯｾｰｼﾞ判別
                    If Left(lstrErrMsg, CPlngVersion) = CPstrVersion Then
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, lstrUtilFuncInfo_Ver)
                    Else
                        '@「閉じるボタンを押してメニューを選択して下さい。」  ﾒｯｾｰｼﾞ表示
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    End If
                    
                    '@メッセージボックス共通関数を実行する
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function
End Module
