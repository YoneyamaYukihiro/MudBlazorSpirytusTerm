'ﾌｧｲﾙ名：xxEN02J0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：TEOS F/B　検索条件・変更・参照 標準モジュール
'作成日：2012/03/19 (Mon) 21:21:53　H.Hayashi
'更新日：2012/03/19 (Mon) 21:21:53
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2012-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02J0
    '*******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Private ====================================
    '@Nothing

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Private ====================================
    '@Nothing

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Private ====================================
    '@Nothing

    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Private ====================================
    Private lstrDummy                 As String             'ﾀﾞﾐｰ変数(処理内で使用はなし。ﾍｯﾀﾞｰ宣言との境界線作成の為)

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Friend =====================================
    '@Nothing

    '================================== Private ====================================
    '関数名：Main
    '機　能：ﾒｲﾝ関数
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/19 (Mon) 21:21:53　H.Hayashi
    '更新日：2012/03/19 (Mon) 21:21:53
    '備　考：
    '　　　：ｺﾏﾝﾄﾞﾗｲﾝの引数内容
    '　　　：lstrCommand(0)：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrCommand(1)：ﾚｽﾎﾟﾝｽ表示（D:表示、なし:非表示）

    '未使用機能NSYS ↓
    'Private Sub Main()
        '
        'Dim llngRet                 As Long         '戻り値
        'Dim lblnAns                 As Boolean      '戻り値
        'Dim ltypCommonInfoDummy     As CommonInfo   'ﾀﾞﾐｰ構造体
        'Dim lblnAnsInit             As Boolean      '戻り値
        'Dim lstrTitle               As String       'ﾀｲﾄﾙ
        'Dim lstrFormName            As String       'ﾌｫｰﾑ名
        '
        ''@=======================
        ''@　起動引数確認処理
        ''@=======================
        'lblnAns = pubblnCommand_Chk
        '
        ''@起動引数確認処理結果が"False:確認結果NG"か
        'If lblnAns = False Then
        '    '@起動引数確認処理結果：NGの場合
        '
        '    '@ﾒｯｾｰｼﾞ名(ｴﾗｰMsgBox用)の設定
        '    pstrMessageName = "起動"
        '
        '    '@表示ﾒｯｾｰｼﾞ変換
        '    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0070)
        '    '@ﾒｯｾｰｼﾞ表示:"<TRM70W>$$起動時の情報が不足しています。システム担当者に連絡してください。"
        '    Call publngMsgBox(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
        '
        '    End
        'End If
        '
        ''@=======================
        ''@　ACT初期化処理
        ''@=======================
        'lblnAnsInit = pubblnAct_Init
        '
        ''@ACT初期化処理結果が"False:初期化失敗"か
        'If lblnAnsInit = False Then
        '    '@ACT初期化処理結果：初期化失敗の場合
        '    End
        'End If
        '
        ''@=======================
        ''@　機能関連情報取得処理
        ''@=======================
        'Call pubblnFuncInfo_Set
        '
        ''@=======================
        ''@　機能ID照合、ﾌｫｰﾑ名称取得処理
        ''@=======================
        'Call pubMenuItemCorrelation_Set(CPstrKeyEN02J0, lstrTitle, , lstrFormName)
        '
        ''@ACT初期化ﾌﾗｸﾞに"True:初期化成功"をｾｯﾄ
        'pblnActInitFlg = True
        '
        ''@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        ''@　TEOS F/B変更/参照画面　表示処理
        ''@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        'Call frmxxEN02J0.Show(vbModal)
    
    'End Sub

    '関数名：pubblnFbTeosResultCondList_Sel
    '機　能：TEOS F/B 計算結果検索条件取得
    '引　数：lstrFbTeosResultCondListVer：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '      ：lstrSbId：SB_ID
    '　　　：lstrWpId：WP_ID
    '　　　：ltypFbTeosResultCondList：TEOS F/B 結果検索条件情報
    '戻り値：
    '作成日：2012/03/19 (Mon) 21:21:53　H.Hayashi
    '更新日：2012/03/19 (Mon) 21:21:53
    '備　考：
    Public Function pubblnFbTeosResultCondList_Sel(ByVal lstrFbTeosResultCondListVer As String, _
                                       ByVal lstrSBID As String, _
                                       ByVal lstrWpId As String, _
                                       ByRef ltypFbTeosResultCondList As typFbTeosResultCondList) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry             '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry             '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        Dim llngCnt             As Integer              'ｶｳﾝﾀ
           
        Try

            pstrMessageName = "TEOS F/B 計算結果検索条件取得"
            pubblnFbTeosResultCondList_Sel = False

            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrFbTeosResultCondListVer <> vbNullString Then                                 'Msgﾊﾞｰｼﾞｮﾝ
                Call lrMsg.addString(CPstrMSG_VER, lstrFbTeosResultCondListVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrSBID <> vbNullString Then                                                    'SB_ID
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrWpId <> vbNullString Then                                                    'WP_ID
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrfb__teosresultcondlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    With ltypFbTeosResultCondList
                    
                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrRC_LIST, laAry)                               'ﾘｱｸﾀﾘｽﾄ

                        '@ｱﾚｰの数が0じゃなければ処理
                        If laAry.Count <> 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            .lngRcListCnt = laAry.Count
                            
                            '@配列の要素数を設定
                            'ReDim Preserve .rcList(.lngRcListCnt)
                            If IsNothing(.rcList) Then
                                .rcList = New List(Of typRcList)
                            Else
                                .rcList.Clear()
                            End If
                            llngCnt = 0
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Dim tmpTypRcList As typRcList
                                With tmpTypRcList
                                    Call ltMsg.getString(CPstrRC, .strRc)                       'ﾘｱｸﾀ
                                    Call ltMsg.getString(CPstrRC_NAME, .strRcName)              'ﾘｱｸﾀ名
                                End With
                                .rcList.Add(tmpTypRcList)
                                llngCnt = llngCnt + 1
                            Next

                        Else
                            '@ｱﾚｰが0の場合
                            .lngRcListCnt = laAry.Count
                        End If
                        
                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrRECIPE_LIST, laAry)                           'ﾚｼﾋﾟﾘｽﾄ

                        '@ｱﾚｰの数が0じゃなければ処理
                        If laAry.Count <> 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            .lngRecipeListCnt = laAry.Count
                                
                            '@配列の要素数を設定
                            'ReDim Preserve .recipeList(.lngRecipeListCnt)
                            If IsNothing(.recipeList) Then
                                .recipeList = New List(Of typRecipeList)
                            Else
                                .recipeList.Clear()
                            End If
                            llngCnt = 0
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Dim tmpTypRecipeList As typRecipeList
                                With tmpTypRecipeList
                                    Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)          'ﾚｼﾋﾟID
                                End With
                                .recipeList.Add(tmpTypRecipeList)
                                llngCnt = llngCnt + 1
                            Next

                        Else
                            '@ｱﾚｰが0の場合
                            .lngRecipeListCnt = laAry.Count
                        End If

                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrFB_REASON_LIST, laAry)                        '更新種別ﾘｽﾄ
                        
                        '@ｱﾚｰの数が0じゃなければ処理
                        If laAry.Count <> 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            .lngFbReasonListCnt = laAry.Count

                            '@配列の要素数を設定
                            'ReDim Preserve .fbReasonList(.lngFbReasonListCnt)
                            If IsNothing(.fbReasonList) Then
                                .fbReasonList = New List(Of typFbReasonList)
                            Else
                                .fbReasonList.Clear()
                            End If
                            llngCnt = 0
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Dim tmpTypFbReasonList As typFbReasonList
                                With tmpTypFbReasonList
                                    Call ltMsg.getString(CPstrFB_REASON_ID, .strFbReasonId)     '更新種別ID
                                    Call ltMsg.getString(CPstrFB_REASON_NAME, .strFbReasonName) '更新種別名
                                End With
                                .fbReasonList.Add(tmpTypFbReasonList)
                                llngCnt = llngCnt + 1
                            Next

                        Else
                            '@ｱﾚｰが0の場合
                            .lngFbReasonListCnt = laAry.Count
                        End If
                        
                        '@関数の処理結果(成功)格納
                        pubblnFbTeosResultCondList_Sel = True
                    End With

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrFbTeosResultCondListVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function


    '関数名：pubblnFbTeosResultList_Sel
    '機　能：TEOS F/B 計算結果取得
    '引　数：lstrFbTeosResultListVer：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '      ：lstrSbId：SB_ID
    '　　　：lstrWpId：WP_ID
    '      ：lstrRc：RC
    '      ：lstrRecipeID：RECIPE_ID
    '　　　：lstrReasonId：REASON_ID
    '　　　：lpubTypFbTeosRresultList：TEOS F/B 結果情報
    '戻り値：
    '作成日：2012/03/19 (Mon) 21:21:53　H.Hayashi
    '更新日：2012/03/19 (Mon) 21:21:53
    '備　考：
    Public Function pubblnFbTeosResult_Sel(ByVal lstrFbTeosResultListVer As String, _
                                       ByVal lstrSBID As String, _
                                       ByVal lstrWpId As String, _
                                       ByVal lstrRc As String, _
                                       ByVal lstrRecipeID As String, _
                                       ByVal lstrReasonId As String, _
                                       ByRef lpubTypFbTeosRresultList As pubTypFbTeosRresultList) As Boolean

        Dim lrMsg                       As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg                       As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg                       As TfMsg                '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry                       As TfMsgAry             '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET                     As String               '応答取得
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ
        Dim lstrWorkChangeProhibitFlag  As String               '書き換え禁止ﾌﾗｸﾞ格納用
        Dim lstrWorkValidFlag           As String               '有効ﾌﾗｸﾞ格納用
        Dim lstrWorkState               As String               '状態格納用
        
        Try

            pstrMessageName = "TEOS F/B 結果結果取得"
            pubblnFbTeosResult_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrFbTeosResultListVer <> vbNullString Then                     'Msgﾊﾞｰｼﾞｮﾝ
                Call lrMsg.addString(CPstrMSG_VER, lstrFbTeosResultListVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrSBID <> vbNullString Then                                        'SB_ID
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrWpId <> vbNullString Then                                        'WP_ID
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
                
            If lstrRc <> vbNullString Then                                          'ﾘｱｸﾀ
                Call lrMsg.addString(CPstrRC, lstrRc)
            Else
                Call lrMsg.addString(CPstrRC, CPstrMsgNull)
            End If
            
            If lstrRecipeID <> vbNullString Then                                    'ﾚｼﾋﾟID
                Call lrMsg.addString(CPstrRECIPE_ID, lstrRecipeID)
            Else
                Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
            End If
            
            If lstrReasonId <> vbNullString Then                                    '更新種別ID
                Call lrMsg.addString(CPstrFB_REASON_ID, lstrReasonId)
            Else
                Call lrMsg.addString(CPstrFB_REASON_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrfb__teosresultlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    With lpubTypFbTeosRresultList

                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrTEOS_FB_RESULT_LIST, laAry)       '保留ﾘｽﾄ

                        '@ｱﾚｰの数が0じゃなければ処理
                        If laAry.Count <> 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            .lngFbTeosRresultListCnt = laAry.Count
                            
                            '@配列の要素数を設定
                            'ReDim Preserve .fbTeosRresultList(.lngFbTeosRresultListCnt)
                            If IsNothing(.fbTeosRresultList) Then
                                .fbTeosRresultList = New List(Of typFbTeosRresultList)
                            Else
                                .fbTeosRresultList.Clear()
                            End If
                            llngCnt = 0
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Dim tmpTypFbTeosRresultList As typFbTeosRresultList
                                With tmpTypFbTeosRresultList
                                
                                    '@TEOS F/B結果状態判断
                                    '@①書き換え禁止ﾌﾗｸﾞを見て、禁止状態の場合は状態を禁止と判断する。
                                    '@②有効ﾌﾗｸﾞを見て、有効の場合は状態を有効と判断する。
                                    '@　尚、書き換え禁止ﾌﾗｸﾞは禁止状態となっていないことする。
                                    '@③上記以外は状態は何も表示しない。
                                    '@・CHANGE_PROHIBIT_FLAG（1:書換禁止/0:書換可能）
                                    '@・VALID_FLAG（1:有効/0:無効）
                                    
                                    '@書き換え禁止ﾌﾗｸﾞより値を取得
                                    Call ltMsg.getString(CPstrCHANGE_PROHIBIT_FLAG, lstrWorkChangeProhibitFlag)
                                                                
                                    '@有効ﾌﾗｸﾞより値を取得
                                    Call ltMsg.getString(CPstrVALID_FLAG, lstrWorkValidFlag)

                                    '@書き換え禁止ﾌﾗｸﾞが禁止状態の場合
                                    If lstrWorkChangeProhibitFlag = "1" Then
                                    
                                    
                                        If lstrWorkValidFlag = "1" Then
                                            
                                            lstrWorkState = CPstrStateFbNg
                                    
                                        Else
                                        
                                            lstrWorkState = CPstrMsgNull
                                            
                                        End If
                                    
                                    '@有効ﾌﾗｸﾞが有効の場合
                                    ElseIf lstrWorkValidFlag = "1" Then
                                        
                                        lstrWorkState = CPstrStateFbData
                                    
                                    '@上記条件以外
                                    Else
                                        lstrWorkState = CPstrMsgNull

                                    End If
                                        
                                                       
                                    .strState = lstrWorkState                                               '状態
                                    Call ltMsg.getString(CPstrCHANGE_PROHIBIT_FLAG, .strChangeProhibitFlag) '書き換え禁止ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrVALID_FLAG, .strValidFlag)                    '有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)                    '日時
                                    Call ltMsg.getString(CPstrFB_REASON_ID, .strFbStatId)                   '更新種別ID
                                    Call ltMsg.getString(CPstrFB_REASON_NAME, .strFbStatName)               '更新種別名
                                    Call ltMsg.getString(CPstrPROCESS_TIME, .strProcessTime)                '補正値(DEPO時間)
                                    Call ltMsg.getString(CPstrMIN_PROCESS_TIME, .strMinProcessTime)         '補正DEPO時間(MIN)
                                    Call ltMsg.getString(CPstrMAX_PROCESS_TIME, .strMaxProcessTime)         '補正DEPO時間(MAX)
                                    Call ltMsg.getString(CPstrFB_LOT_ID, .strFbLotId)                       '補正ﾛｯﾄID
                                    Call ltMsg.getString(CPstrFB_RECIPE_ID_1, .strFbRecipeId1)              '補正ﾚｼﾋﾟID_1
                                    Call ltMsg.getString(CPstrFB_RECIPE_ID_2, .strFbRecipeId2)              '補正ﾚｼﾋﾟID_2
                                    Call ltMsg.getString(CPstrEMP_ID, .strUserID)                           '実施者ID
                                    Call ltMsg.getString(CPstrEMP_NAME, .strUserName)                       '実施者
                                End With
                                .fbTeosRresultList.Add(tmpTypFbTeosRresultList)
                                llngCnt = llngCnt + 1
                            Next

                        Else
                            '@ｱﾚｰが0の場合
                            .lngFbTeosRresultListCnt = laAry.Count
                        End If
                        
          
                        '@関数の処理結果(成功)格納
                        '@pubblnFbTeosResultCondList_Sel = True
                        
                        pubblnFbTeosResult_Sel = True
                        
                    End With


                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrFbTeosResultListVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnFbTeosResult_Update
    '機　能：TEOS F/B 計算結果更新
    '引　数：lstrFbTeosResultUpdateVer：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '      ：lstrSbId：SB_ID
    '　　　：lstrWpId：WP_ID
    '      ：lstrRc：RC
    '      ：lstrRecipeID：RECIPE_ID
    '　　　：lstrReasonId：REASON_ID
    '　　　：lstrProcessTime：補正時間
    '      ：lstrEmpID：実施者
    '　　　：lstrTeosFbUpdateResult：TEOS FB 更新結果情報
    '戻り値：
    '作成日：2012/03/19 (Mon) 21:21:53　H.Hayashi
    '更新日：2012/03/19 (Mon) 21:21:53
    '備　考：

    Public Function pubblnFbTeosResult_Update(ByVal lstrFbTeosResultUpdateVer As String, _
                                       ByVal lstrSBID As String, _
                                       ByVal lstrWpId As String, _
                                       ByVal lstrRc As String, _
                                       ByVal lstrRecipeID As String, _
                                       ByVal lstrReasonId As String, _
                                       ByVal lstrProcessTime As String, _
                                       ByVal lstrEmpID As String, _
                                       ByRef lstrTeosFbUpdateResult As String) As Boolean

        Dim lrMsg                       As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg                       As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET                     As String               '応答取得

        Try

            pstrMessageName = "TEOS F/B 計算結果更新"
            pubblnFbTeosResult_Update = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrFbTeosResultUpdateVer <> vbNullString Then                       'Msgﾊﾞｰｼﾞｮﾝ
                Call lrMsg.addString(CPstrMSG_VER, lstrFbTeosResultUpdateVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrSBID <> vbNullString Then                                        'SB_ID
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrWpId <> vbNullString Then                                        'WP_ID
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
                
            If lstrRc <> vbNullString Then                                          'ﾘｱｸﾀ
                Call lrMsg.addString(CPstrRC, lstrRc)
            Else
                Call lrMsg.addString(CPstrRC, CPstrMsgNull)
            End If
            
            If lstrRecipeID <> vbNullString Then                                    'ﾚｼﾋﾟID
                Call lrMsg.addString(CPstrRECIPE_ID, lstrRecipeID)
            Else
                Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
            End If
            
            If lstrReasonId <> vbNullString Then                                    '更新種別ID
                Call lrMsg.addString(CPstrFB_REASON_ID, lstrReasonId)
            Else
                Call lrMsg.addString(CPstrFB_REASON_ID, CPstrMsgNull)
            End If
            
            If lstrProcessTime <> vbNullString Then                                 'DEPO補正時刻
                Call lrMsg.addString(CPstrPROCESS_TIME, lstrProcessTime)
            Else
                Call lrMsg.addString(CPstrPROCESS_TIME, CPstrMsgNull)
            End If
            
            If lstrEmpID <> vbNullString Then                                       '作業者ID
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrfb__teosresultupdate, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@判定結果
                     Call laMsg.getString(CPstTEOS_FB_UPDATE_RESULT, lstrTeosFbUpdateResult)
                       
                     pubblnFbTeosResult_Update = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrFbTeosResultUpdateVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function
End Module
