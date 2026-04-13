'ﾌｧｲﾙ名：xxMG02N0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：バッチ装置管理　通信MSG用標準モジュール
'作成日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
'更新日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02N0
    '関数名：pubblnBatComposeStatus_Sel
    '機　能：ﾊﾞｯﾁ編成設定取得
    '引　数：lstrbat_composestatusVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrWpId                   ：装置ID
    '　　　：ltypBatComposeStatus       ：ﾊﾞｯﾁ編成設定構造体
    '戻り値：True：正常、False：異常
    '作成日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
    '更新日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
    '備　考：
    Public Function pubblnBatComposeStatus_Sel(ByVal lstrbat_composestatusVer As String, _
                                               ByVal lstrSBID As String, _
                                               ByVal lstrWpId As String, _
                                               ByRef ltypBatComposeStatus As BatComposeStatus) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用

        Try

            pstrMessageName = "バッチ編成設定取得"
            pubblnBatComposeStatus_Sel = False

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrbat_composestatusVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrbat_composestatusVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_composestatus, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    Call laMsg.getString(CPstrWP_ID, ltypBatComposeStatus.strWpID)
                    Call laMsg.getString(CPstrBATCH_COMPOSE_TYPE, ltypBatComposeStatus.strBatchComposeType)
                    Call laMsg.getString(CPstrEDIT_EMP_NAME, ltypBatComposeStatus.strEditEmpName)
                    Call laMsg.getString(CPstrEDIT_TIME, ltypBatComposeStatus.strEditTime)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrRECIPE_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypBatComposeStatus.lngRecipeListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypBatComposeStatus.lngRecipeListCnt > 0 Then

                        '@構造体初期化
                        If IsNothing(ltypBatComposeStatus.typRecipeList) Then
                            ltypBatComposeStatus.typRecipeList = New list(Of typBatchControlRecipe)
                        Else
                            ltypBatComposeStatus.typRecipeList.Clear()
                        End If
                        llngCnt = 1

                        For Each ltMsg In laAry

                            '@受信結果取得
                            Dim item As typBatchControlRecipe
                            With item

                                Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)
                                Call ltMsg.getString(CPstrBATCH_RECIPE_TYPE, .strRecipeType)
                                Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)
                                Call ltMsg.getString(CPstrWF_NUM, .strWfNum)
                                Call ltMsg.getString(CPstrTIME_NUM, .strTimeNum)
                                Call ltMsg.getString(CPstrTIME_WF_NUM, .strTimeWfNum)
                                Call ltMsg.getString(CPstrEDIT_EMP_NAME, .strEditEmpName)
                                Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)

                            End With
                            ltypBatComposeStatus.typRecipeList.Add(item)

                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnBatComposeStatus_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrbat_composestatusVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnBatRecipeList_Sel
    '機　能：ﾊﾞｯﾁﾚｼﾋﾟ一覧取得
    '引　数：lstrbat_recipelistVer      ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrWpId                   ：装置ID
    '　　　：ltypBatRecipeList          ：ﾊﾞｯﾁﾚｼﾋﾟ構造体
    '戻り値：True：正常、False：異常
    '作成日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
    '更新日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
    '備　考：
    Public Function pubblnBatRecipeList_Sel(ByVal lstrbat_recipelistVer As String, _
                                            ByVal lstrSBID As String, _
                                            ByVal lstrWpId As String, _
                                            ByRef ltypBatRecipeList As BatRecipeList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用

        Try

            pstrMessageName = "バッチレシピ一覧取得"
            pubblnBatRecipeList_Sel = False

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrbat_recipelistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrbat_recipelistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_recipelist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    Call laMsg.getString(CPstrWP_ID, ltypBatRecipeList.strWpID)
                    Call laMsg.getString(CPstrMAX_PROCESS_QUANTITY, ltypBatRecipeList.strMaxProcessQuantity)
                    Call laMsg.getString(CPstrTIME_NUM_ITEM, ltypBatRecipeList.strTimeNumItem)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrRECIPE_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypBatRecipeList.lngRecipeListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypBatRecipeList.lngRecipeListCnt > 0 Then

                        '@構造体初期化
                        If IsNothing(ltypBatRecipeList.typRecipeList) Then
                            ltypBatRecipeList.typRecipeList = New List(Of typBatchRecipe)()
                        Else
                            ltypBatRecipeList.typRecipeList.Clear()
                        End If

                        llngCnt = 1

                        For Each ltMsg In laAry

                            '@受信結果取得
                            Dim item As typBatchRecipe
                            With item

                                Call ltMsg.getString(CPstrBATCH_RECIPE_TYPE, .strRecipeType)
                                Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)
                                Call ltMsg.getString(CPstrSTAT_ID, .strStatId)

                            End With
                            ltypBatRecipeList.typRecipeList.Add(item)

                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnBatRecipeList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrbat_recipelistVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnBatComposeRegist_Upd
    '機　能：ﾊﾞｯﾁ編成設定
    '引　数：lstrbat_composeregist_Ver  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrEmpId                  ：確定作業者ID
    '　　　：ltypBatchComposeStatus     ：ﾊﾞｯﾁ編成構造体
    '戻り値：True：正常、False：異常
    '作成日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
    '更新日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
    '備　考：
    Public Function pubblnBatComposeRegist_Upd(ByVal lstrbat_composeregist_Ver As String, _
                                         ByVal lstrSBID As String, _
                                         ByVal lstrEmpID As String, _
                                         ByRef ltypBatchComposeStatus As BatComposeStatus) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "バッチ編成登録"
            pubblnBatComposeRegist_Upd = False

            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatchComposeStatus

                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrbat_composeregist_Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrbat_composeregist_Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If lstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, lstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@WPID
                If ltypBatchComposeStatus.strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, ltypBatchComposeStatus.strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@登録作業者ID
                If lstrEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@ﾊﾞｯﾁ編成方式
                If .strBatchComposeType <> vbNullString Then
                    Call lrMsg.addString(CPstrBATCH_COMPOSE_TYPE, .strBatchComposeType)
                Else
                    Call lrMsg.addString(CPstrBATCH_COMPOSE_TYPE, CPstrMsgNull)
                End If
                
                '@編集ﾌﾗｸﾞ
                If .strEditFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_FLAG, .strEditFlag)
                Else
                    Call lrMsg.addString(CPstrEDIT_FLAG, CPstrMsgNull)
                End If
                
                
                
                '@ﾛｯﾄ情報ｾｯﾄ
                If .lngRecipeListCnt > 0 Then

                    llngCnt = 1

                    Do While .lngRecipeListCnt >= llngCnt

                        With .typRecipeList(llngCnt - 1)

                            '@処理順序
                            If .strSeqNum <> vbNullString Then
                                Call ltMsg.addString(CPstrSEQ_NUM, .strSeqNum)
                            Else
                                Call ltMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)
                            End If

                            '@ﾚｼﾋﾟﾀｲﾌﾟ
                            If .strRecipeType <> vbNullString Then
                                Call ltMsg.addString(CPstrBATCH_RECIPE_TYPE, .strRecipeType)
                            Else
                                Call ltMsg.addString(CPstrBATCH_RECIPE_TYPE, CPstrMsgNull)
                            End If

                            '@ﾚｼﾋﾟID
                            If .strRecipeId <> vbNullString Then
                                Call ltMsg.addString(CPstrRECIPE_ID, .strRecipeId)
                            Else
                                Call ltMsg.addString(CPstrJIG_ID, CPstrMsgNull)
                            End If

                            '@WF設定
                            If .strWfNum <> vbNullString Then
                                Call ltMsg.addString(CPstrWF_NUM, .strWfNum)
                            Else
                                Call ltMsg.addString(CPstrWF_NUM, CPstrMsgNull)
                            End If

                            '@時間設定
                            If .strTimeNum <> vbNullString Then
                                Call ltMsg.addString(CPstrTIME_NUM, .strTimeNum)
                            Else
                                Call ltMsg.addString(CPstrTIME_NUM, CPstrMsgNull)
                            End If

                            '@時間WF数
                            If .strTimeWfNum <> vbNullString Then
                                Call ltMsg.addString(CPstrTIME_WF_NUM, .strTimeWfNum)
                            Else
                                Call ltMsg.addString(CPstrTIME_WF_NUM, CPstrMsgNull)
                            End If

                            '@編集ﾌﾗｸﾞ
                            If ltypBatchComposeStatus.typRecipeList(llngCnt - 1).strEditFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrEDIT_FLAG, ltypBatchComposeStatus.typRecipeList(llngCnt - 1).strEditFlag)
                            Else
                                Call ltMsg.addString(CPstrEDIT_FLAG, CPstrMsgNull)
                            End If

                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear
                            llngCnt = llngCnt + 1
                        End With
                    Loop
                Else
                    ltMsg.Clear
                End If

                Call lrMsg.addMsgAry(CPstrRECIPE_LIST, lrAry)
                lrAry.Clear

            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_composeregist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnBatComposeRegist_Upd = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrbat_composeregist_Ver)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnBatWaitingLotList_Sel
    '機　能：ﾊﾞｯﾁ装置待ちﾛｯﾄ一覧取得
    '引　数：lstrMsgVer                 ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrWpId                   ：装置ID
    '　　　：ltypBatWatingLotList       ：ﾊﾞｯﾁ装置待ちﾛｯﾄ一覧構造体
    '戻り値：True：正常、False：異常
    '作成日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
    '更新日：2017/06/27 (Tue) 10:10:53 Y.Yoneyama
    '備　考：
    Public Function pubblnBatWaitingLotList_Sel(ByVal lstrMsgVer As String, _
                                                ByVal lstrWpId As String, _
                                                ByRef ltypBatWatingLotList As BatWaitingLotList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用

        Try

            pstrMessageName = "バッチ装置待ちロット一覧取得"
            pubblnBatWaitingLotList_Sel = False

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_waitinglotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    Call laMsg.getString(CPstrWP_ID, ltypBatWatingLotList.strWpID)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypBatWatingLotList.lngBatLotCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypBatWatingLotList.lngBatLotCnt > 0 Then

                        '@構造体初期化
                        If IsNothing(ltypBatWatingLotList.typBatLotList) Then
                            ltypBatWatingLotList.typBatLotList = New List(Of typBatchWaitingLot)()
                        Else
                            ltypBatWatingLotList.typBatLotList.Clear()
                        End If

                        llngCnt = 1

                        For Each ltMsg In laAry

                            '@受信結果取得
                            Dim item As typBatchWaitingLot
                            With item

                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)
                                Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)
                                Call ltMsg.getString(CPstrWF_QUANTITY, .strWfQty)
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)
                                Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)
                                Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)
                                Call ltMsg.getString(CPstrSTOCKER_ID, .strStockerId)
                                Call ltMsg.getString(CPstrWAIT_TIME_H, .strWaitTimeH)

                            End With
                            ltypBatWatingLotList.typBatLotList.Add(item)

                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnBatWaitingLotList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

End Module
