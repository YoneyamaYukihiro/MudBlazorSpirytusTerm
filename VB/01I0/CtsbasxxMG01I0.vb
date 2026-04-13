'ﾌｧｲﾙ名：xxMG01I0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：部材履歴一覧 標準ﾓｼﾞｭｰﾙ
'作成日：2005/01/05 (Wed) 12:48:33 S.Deguchi
'更新日：2005/01/05 (Wed) 12:48:33
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01I0
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

    '関数名：pubblnInvHistory_Sel
    '機　能：部材履歴取得
    '引　数：ltypHistoryRequest：要求格納構造体
    '　　　：mtypInvHistoryList：部材履歴格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/11/05 (Fri) 10:12:52 S.Deguchi
    '更新日：2004/11/05 (Fri) 10:12:52
    '備　考：
    '　　　：2005/01/05 (Wed) 17:13:04 S.Deguchi    部材履歴の要求・応答内容変更による修正
    '　　　：2005/02/08 (Tue) 12:43:48 S.Deguchi    ﾘﾜｰｸ元ﾛｯﾄID追加
    Public Function pubblnInvHistory_Sel(ByRef ltypHistoryRequest As HistoryRequest, _
                                         ByRef mtypInvHistoryList As InvHistory) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET            As String            '応答取得
        Dim llngCnt1           As Integer           'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@初期設定
            pstrMessageName = "部材履歴要求"
            pubblnInvHistory_Sel = False
            mtypInvHistoryList.typInvHistoryList = New List(Of AnswerHistory)

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypHistoryRequest
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@部品種別
                If .strVenderClassId <> vbNullString Then
                    Call lrMsg.addString(CPstrVENDER_CLASS_ID, .strVenderClassId)
                Else
                    Call lrMsg.addString(CPstrVENDER_CLASS_ID, CPstrMsgNull)
                End If
                '@部品
                If .strPartCode <> vbNullString Then
                    Call lrMsg.addString(CPstrPART_CODE, .strPartCode)
                Else
                    Call lrMsg.addString(CPstrPART_CODE, CPstrMsgNull)
                End If
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                '@検索開始日時
                If .strStartDate <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_DATE, .strStartDate)
                Else
                    Call lrMsg.addString(CPstrSTART_DATE, CPstrMsgNull)
                End If
                '@検索終了日時
                If .strEndDate <> vbNullString Then
                    Call lrMsg.addString(CPstrEND_DATE, .strEndDate)
                Else
                    Call lrMsg.addString(CPstrEND_DATE, CPstrMsgNull)
                End If
                '@製造ﾛｯﾄID
                If .strProductionLotId <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCTION_LOT_ID, .strProductionLotId)
                Else
                    Call lrMsg.addString(CPstrPRODUCTION_LOT_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_history_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrHISTORY_LIST, laAry)
                    
                    With mtypInvHistoryList
                        '@受信ﾒｯｾｰｼﾞ取得
                        Call laMsg.getString(CPstrNOW_NUM, .strNowNum)                      '現在数量
                        Call laMsg.getString(CPstrACCEPT_TOTAL_NUM, .strAcceptTotalNum)     '受入数量合計
                        Call laMsg.getString(CPstrSCRAP_TOTAL_NUM, .strScrapTotalNum)       '払出数量合計
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                        .lngInvHistoryListCnt = laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngInvHistoryListCnt > 0 Then
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt1 = 1
                            For Each ltMsg In laAry
                                '@受信結果取得(ﾃﾞｰﾀ格納)
                                Dim ltypInvHistoryList As New AnswerHistory
                                Call ltMsg.getString(CPstrEVENT_CLASS, ltypInvHistoryList.strEventClass)              'ｲﾍﾞﾝﾄ区分
                                Call ltMsg.getString(CPstrEVENT_NAME, ltypInvHistoryList.strEventName)                'ｲﾍﾞﾝﾄ区分名
                                Call ltMsg.getString(CPstrREASON_CODE, ltypInvHistoryList.strReasonCode)              '理由ｺｰﾄﾞ
                                Call ltMsg.getString(CPstrREASON_NAME, ltypInvHistoryList.strReasonName)              '理由ｺｰﾄﾞ(和名)
                                Call ltMsg.getString(CPstrLOT_ID, ltypInvHistoryList.strLotID)                        '在庫ID
                                Call ltMsg.getString(CPstrPRODUCTION_LOT_ID, ltypInvHistoryList.strProductionLotId)   '製造ﾛｯﾄID
                                Call ltMsg.getString(CPstrACCEPT_NUM, ltypInvHistoryList.strAcceptNum)                '受入数量
                                Call ltMsg.getString(CPstrSCRAP_NUM, ltypInvHistoryList.strScrapNum)                  '払出数量
                                Call ltMsg.getString(CPstrRECORD_TIME, ltypInvHistoryList.strRecordTime)              '日時
                                Call ltMsg.getString(CPstrEMP_ID, ltypInvHistoryList.strEmpID)                        '作業者ID
                                Call ltMsg.getString(CPstrEMP_NAME, ltypInvHistoryList.strEmpName)                    '作業者名
                                Call ltMsg.getString(CPstrSHIPPING_LOT_ID, ltypInvHistoryList.strShippingLotID)       '出荷ﾛｯﾄID
                                Call ltMsg.getString(CPstrTHICKNESS_CODE, ltypInvHistoryList.strThicknessCode)        '板厚
                                Call ltMsg.getString(CPstrREWORK_COUNT, ltypInvHistoryList.strReworkCount)            'ﾘﾜｰｸ数
                                Call ltMsg.getString(CPstrCOMMENTS, ltypInvHistoryList.strComments)                   '作業ﾒﾓ
                                Call ltMsg.getString(CPstrISSUE_LOT_ID, ltypInvHistoryList.strIssueLotID)             '払出ﾛｯﾄID
                                Call ltMsg.getString(CPstrACCEPT_LOT_ID, ltypInvHistoryList.strAcceptLotID)           'ﾘﾜｰｸ元ﾛｯﾄID
                            
                                .typInvHistoryList.Add(ltypInvHistoryList)
                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngCnt1 = llngCnt1 + 1
                            Next
                        End If
                    
                        '@関数の処理結果(成功)格納
                        pubblnInvHistory_Sel = True
                    End With

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypHistoryRequest.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function
End Module
