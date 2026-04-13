'ﾌｧｲﾙ名：xxMG02A0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程戻し　通信メッセージ用標準モジュール
'作成日：2008/05/09 (Fri) 15:25:11 N.Kojima
'更新日：2008/06/12 (Thu) 14:52:39 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02A0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubblnMntOpStepList_Sel
    '機　能：戻し大工程/小工程取得
    '引　数：lstrmnt_opsteplistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：ltypOpStepList         ：流動済工程情報格納用構造体
    '戻り値：True：成功、False：失敗
    '作成日：2008/05/13 (Tue) 11:22:15 N.Kojima
    '更新日：2008/06/12 (Thu) 14:52:57 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 14:52:57 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMntOpStepList_Sel(ByVal lstrmnt_opsteplistVer As String, _
                                            ByVal lstrLotID As String, _
                                            ByRef ltypOpStepList As OpStepList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim llngCnt2            As String           'ｶｳﾝﾄ用2

        Try

            '@ﾒｯｾｰｼﾞ名(ｴﾗｰMsgBox用)の設定、戻り値の初期化
            pstrMessageName = "流動済工程情報取得"
            pubblnMntOpStepList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmnt_opsteplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmnt_opsteplistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送受信
            Call pTerm.sendRequest(CPstrmnt_opsteplist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：戻し大工程ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrOP_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：戻し大工程ﾘｽﾄﾃﾞｰﾀ数
                    ltypOpStepList.lngOpListCnt = laAry.Count

                    '@戻し大工程ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If ltypOpStepList.lngOpListCnt > 0 Then
                        '@配列領域の確保
                        'ReDim ltypOpStepList.typOpList(ltypOpStepList.lngOpListCnt)
                        If ltypOpStepList.typOpList Is Nothing then
                            ltypOpStepList.typOpList = New List(Of RollBackOpList)
                        Else
                            ltypOpStepList.typOpList.Clear()
                        End if

                        '@ｶｳﾝﾀの初期化
                        llngCnt = 1

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry
                            Dim tmpOpList As RollBackOpList
                            tmpOpList = New RollBackOpList

                            With tmpOpList
                                '@戻し大工程IDを格納
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：戻し小工程ﾘｽﾄ
                                Call ltMsg.getMsgAry(CPstrSTEP_LIST, laAry2)

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数：戻し小工程ﾘｽﾄﾃﾞｰﾀ数
                                .lngStepListCnt = laAry2.Count

                                '@戻し小工程ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                If .lngStepListCnt > 0 Then
                                    '@配列領域の確保
                                    'ReDim .typStepList(.lngStepListCnt)
                                    .typStepList = New List(Of RollBackStepList)

                                    '@ｶｳﾝﾀ2の初期化
                                    llngCnt2 = 1

                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各ﾃﾞｰﾀ取得
                                    For Each ltMsg2 In laAry2
                                        Dim tmpStepList As RollBackStepList
                                        tmpStepList = New RollBackStepList

                                        With tmpStepList
                                            Call ltMsg2.getString(CPstrSTEP_ID, .strStepID)     '戻り小工程ID
                                        End With

                                        .typStepList.Add(tmpStepList)

                                        '@ｶｳﾝﾀ2を+1する
                                        llngCnt2 = llngCnt2 + 1
                                    Next
                                End If
                            End With

                            ltypOpStepList.typOpList.Add(tmpOpList)

                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMntOpStepList_Sel = True

                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmnt_opsteplistVer)

                '@〓 その他のｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ表示："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            laAry = Nothing
            laAry2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            laAry = Nothing
            laAry2 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMntEventHist_Sel
    '機　能：ｲﾍﾞﾝﾄ履歴一覧取得
    '引　数：ltypReqEventInfo       ：ｲﾍﾞﾝﾄ履歴一覧要求格納構造体
    '　　　：ltypAnsEventInfo       ：ｲﾍﾞﾝﾄ履歴一覧応答格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2008/05/13 (Tue) 12:44:21 N.Kojima
    '更新日：2008/06/12 (Thu) 14:59:11 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 14:59:11 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMntEventHist_Sel(ByRef ltypReqEventInfo As ReqEventInfo, _
                                           ByRef ltypAnsEventInfo As AnsEventInfo) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET            As String            '応答取得
        Dim llngCnt            As Integer           'ｱﾚｲｶｳﾝﾄ用

        Try

            '@ﾒｯｾｰｼﾞ名(ｴﾗｰMsgBox用)の設定、戻り値の初期化
            pstrMessageName = "イベント履歴取得"
            pubblnMntEventHist_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypReqEventInfo
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If

                '@大工程ID
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If

                '@小工程ID
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送受信
            Call pTerm.sendRequest(CPstrmnt_eventhist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    With ltypAnsEventInfo
                        '@受信結果取得
                        Call laMsg.getString(CPstrSB_ID, .strSbID)                      'ｼｽﾃﾑﾌﾞﾛｯｸID
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)   '最終更新日時

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ｲﾍﾞﾝﾄ履歴ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrEVENT_LIST, laAry)

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：：ｲﾍﾞﾝﾄ履歴ﾘｽﾄﾃﾞｰﾀ数
                        .lngEventListCnt = laAry.Count

                        '@ｲﾍﾞﾝﾄ履歴ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngEventListCnt > 0 Then
                            '@配列領域の確保
                            'ReDim .typEventList(.lngEventListCnt)
                            If .typEventList Is Nothing then
                                .typEventList = New List(Of EventList)
                            Else
                                .typEventList.Clear()
                            End if

                            '@ｶｳﾝﾀの初期化
                            llngCnt = 1

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim tmpEventList As EventList
                                tmpEventList = New EventList

                                '@受信結果格納
                                Call ltMsg.getString(CPstrOP_ID, tmpEventList.strOpID)                            '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, tmpEventList.strStepID)                        '小工程ID
                                Call ltMsg.getString(CPstrLOT_EVENT_ID, tmpEventList.strLotEventId)               'ﾛｯﾄｲﾍﾞﾝﾄID
                                Call ltMsg.getString(CPstrEVENT_NAME, tmpEventList.strLotEventName)               'ﾛｯﾄｲﾍﾞﾝﾄ名
                                Call ltMsg.getString(CPstrENTRY_TIME, tmpEventList.strEntryTime)                  '登録日時
                                Call ltMsg.getString(CPstrEMP_ID, tmpEventList.strEmpID)                          '作業者ID
                                Call ltMsg.getString(CPstrEMP_NAME, tmpEventList.strEmpName)                      '作業者名
                                Call ltMsg.getString(CPstrCOMMENTS, tmpEventList.strComments)                     '作業ﾒﾓ
                                Call ltMsg.getString(CPstrDELETE_PROHIBITED, tmpEventList.strDeleteProhibited)    '削除可否判定ﾌﾗｸﾞ(0:削除可、1:削除不可)

                                .typEventList.Add(tmpEventList)

                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If

                        '@戻り値に"True：成功"をｾｯﾄ
                        pubblnMntEventHist_Sel = True
                    End With

                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　機能Ver判定処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypReqEventInfo.strMsgVer)

                '@〓 その他のｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ表示："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMntDelHist__Upd
    '機　能：ｲﾍﾞﾝﾄ履歴削除
    '引　数：ltypReqEventInfo   ：ｲﾍﾞﾝﾄ履歴一覧要求格納構造体
    '戻り値：True：成功、False：失敗
    '作成日：2008/05/13 (Tue) 14:19:46 N.Kojima
    '更新日：2008/06/12 (Thu) 15:02:15 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 15:02:15 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMntDelHist__Upd(ByRef ltypReqEventInfo As ReqEventInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得

        Try

            '@ﾒｯｾｰｼﾞ名(ｴﾗｰMsgBox用)の設定、戻り値の初期化
            pstrMessageName = "イベント履歴削除"
            pubblnMntDelHist__Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypReqEventInfo
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If

                '@大工程ID
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If

                '@小工程ID
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If

                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If

                '@作業ﾒﾓ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If

                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送受信
            Call pTerm.sendRequest(CPstrmnt_delhist_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMntDelHist__Upd = True

                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypReqEventInfo.strMsgVer)

                '@〓 その他のｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ表示："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function
End Module
