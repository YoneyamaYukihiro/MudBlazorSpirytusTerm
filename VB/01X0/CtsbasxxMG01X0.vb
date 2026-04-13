'ﾌｧｲﾙ名：xxMG01X0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット工順変更　通信メッセージ用標準モジュール
'作成日：2006/07/04 (Tue) 09:56:25 N.Kasai
'更新日：2018/06/25 (Mon) 17:10:37 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01X0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubblnProcList_Sel
    '機　能：ﾛｯﾄ一覧情報取得
    '引　数：ltypProcLotListReq ：要求
    '　　　：ltypProcLotListAns ：応答
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/06/29 (Thu) 19:13:24 N.Kasai
    '更新日：2009/12/02 (Wed) 22:01:45 H.Hayashi
    '備　考：
    '　　　：2007/04/05 (Thu) 15:24:08 N.Kasai      応答ﾀｸﾞ追加(№01831)
    '　　　：2007/06/26 (Tue) 14:50:54 N.Kasai      応答ﾀｸﾞ削除(№01997)
    '　　　：2007/07/03 (Tue) 10:53:10 N.Kasai      機種複数要求(№02006)
    '　　　：2008/06/11 (Wed) 16:09:23 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/03/09 (Mon) 17:40:18 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/12/02 (Wed) 22:01:45 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    Public Function pubblnProcList_Sel(ByRef ltypProcLotListReq As ProcLotListReq, _
                                       ByRef ltypProcLotListAns As ProcLotListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg2              As TfMsg            '送信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "ロット一覧情報取得"
            pubblnProcList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            lrAry = New TfMsgAry
            ltMsg2 = New TfMsg
            lrAry2 = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypProcLotListReq
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ｱｸｼｮﾝ
                If .strAction <> vbNullString Then
                    Call lrMsg.addString(CPstrACTION, .strAction)
                Else
                    Call lrMsg.addString(CPstrACTION, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ流動ｽﾃｰﾀｽID
                If .strLotFlowStatusID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_FLOW_STATUS_ID, .strLotFlowStatusID)
                Else
                    Call lrMsg.addString(CPstrLOT_FLOW_STATUS_ID, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                     Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                     Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
                '@機種ﾘｽﾄ
                For llngCnt = 0 To .lngPdCnt - 1
                
                    If .typPdList(llngCnt).strPdId <> vbNullString Then
                        Call ltMsg.addString(CPstrPD_ID, .typPdList(llngCnt).strPdId)
                    Else
                        Call ltMsg.addString(CPstrPD_ID, CPstrMsgNull)
                    End If
                    
                    '@格納
                    Call lrAry.Add(ltMsg)
                Next
                '@機種ﾘｽﾄ
                Call lrMsg.addMsgAry(CPstrPD_LIST, lrAry)
                
                '@種別ﾘｽﾄ
                For llngCnt = 0 To .lngFlowClassListCnt -1
                    
                    If .typFlowClassList(llngCnt).strFlowClass <> vbNullString Then
                        Call ltMsg2.addString(CPstrFLOW_CLASS, .typFlowClassList(llngCnt).strFlowClass)
                    Else
                        Call ltMsg2.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                    End If
                    
                    '@格納
                    Call lrAry2.Add(ltMsg2)
                Next
                '@種別ﾘｽﾄ
                Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry2)

            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrproclist____, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    ltypProcLotListAns.lngProcLotListCnt = laAry.Count
                    
                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If ltypProcLotListAns.lngProcLotListCnt > 0 Then
                    
                        '@配列領域の確保
                        ltypProcLotListAns.typProcLotList = New List(Of ProcLotList)

                        '@ｶｳﾝﾀの初期化
                        llngCnt = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry
                            Dim typProcLotListTmp As New ProcLotList

                            With typProcLotListTmp
                                
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                Call ltMsg.getString(CPstrNOW_ST, .strNowST)                                'ﾛｯﾄ状態
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                     'ﾛｯﾄ担当者名
                                Call ltMsg.getString(CPstrWF_NUM, .strWfNum)                                'WF枚数
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                  'ﾁｯﾌﾟ
                                Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                   'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)                   'ﾛｯﾄ停止ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrWF_CARRY_FLAG, .strWfCarryFlag)                   'WF移載中ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   'ﾛｯﾄ位置(和名)
                                Call ltMsg.getString(CPstrCOMMENTS, .strComments)                           'ﾛｯﾄｺﾒﾝﾄ
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               'LOT最終更新日時
                                Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸﾌﾗｸﾞ(0:ﾘﾜｰｸなし　1:ﾘﾜｰｸ　2:追加流動)
                                Call ltMsg.getString(CPstrPROC_FLAG, .strProcFlag)                          'ﾛｯﾄ種別(0:通常　1:ﾘﾜｰｸ、特殊)
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種ID
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                    '液晶方向
                                Call ltMsg.getString(CPstrVERUP_PROHIBITED_FLAG, .strVerUpProhibitedFlag)   'VerUp禁止(0:可、1:不可)
                                Call ltMsg.getString(CPstrPROHIBITED_EMP_NAME, .strProhibitedEmpName)       '禁止設定者
                                Call ltMsg.getString(CPstrPROHIBITED_DEPT_NAME, .strProhibitedDeptName)     '禁止設定者部署
        '@↓2009/03/09 (Mon) 17:40:33 N.Kojima **************************************************
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                         '送品先
        '@↑2009/03/09 (Mon) 17:40:33 N.Kojima **************************************************
        '@↓2009/12/02 (Wed) 22:02:40 H.Hayashi **************************************************
                                Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                              'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        '@↑2009/12/02 (Wed) 22:02:40 H.Hayashi **************************************************

                            End With

                            ltypProcLotListAns.typProcLotList.Add(typProcLotListTmp)

                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcList_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypProcLotListReq.strMsgVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnProcProcChgList_Sel
    '機　能：工順変更中ﾛｯﾄ工順情報取得
    '引　数：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrlot_procchglistVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypProcChgList        ：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/06/27 (Tue) 09:54:55 N.Kasai
    '更新日：2009/12/02 (Wed) 19:56:31 H.Hayashi
    '備　考：
    '　　　：2007/04/05 (Thu) 10:46:39 N.Kasai      応答ﾀｸﾞ追加(№01831)
    '　　　：2008/06/11 (Wed) 17:44:50 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/03/05 (Thu) 13:53:09 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/12/02 (Wed) 19:56:31 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    Public Function pubblnProcProcChgList_Sel(ByVal lstrSBID As String, _
                                              ByVal lstrprocprocchglistVer As String, _
                                              ByRef ltypProcChgList As ProcChgList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "工順変更中ロット工順取得"
            pubblnProcProcChgList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrprocprocchglistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrprocprocchglistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrprocprocchglist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypProcChgList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾛｯﾄﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                        .lngProcChgCnt = laAry.Count
                        
                        '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngProcChgCnt > 0 Then
                        
                            '@配列領域の確保
                            .typProcChg = New List(Of ProcChg)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typProcChgTmp As New ProcChg

                                With typProcChgTmp
                                    
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程
                                    Call ltMsg.getString(CPstrCURRENT_STATUS, .strCurrentStatus)                '現在状態
                                    Call ltMsg.getString(CPstrCURRENT_STATUS_NAME, .strCurrentStatusName)       '現在状態(和名)
                                    Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strLotPos)                'ﾛｯﾄ位置
                                    Call ltMsg.getString(CPstrEDIT_STATUS, .strEditStatus)                      '編集状態
                                    Call ltMsg.getString(CPstrEMP_ID, .strEmpID)                                '編集者ID
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                            '編集者名
                                    Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)                          '最終更新日時
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)                           'ｺﾒﾝﾄ
                                    Call ltMsg.getString(CPstrKIND_FLAG, .strKindFlag)                          '種別
                                    Call ltMsg.getString(CPstrUSER_PRC_NAME, .strUserPrcName)                   'ﾕｰｻﾞｰﾌﾟﾛセｽ名
                                    Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                                    Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                   'ﾛｯﾄ保留ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)                   'ﾛｯﾄ停止ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrWF_CARRY_FLAG, .strWfCarryFlag)                   'WF移載中ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種ID
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                    Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                    '液晶方向
                                    Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸ状態(0：なし、1:ﾘﾜｰｸ、2:追加)
                                    Call ltMsg.getString(CPstrPROC_FLAG, .strProcFlag)                          'ﾛｯﾄ種別(0：通常、1:ﾘﾜｰｸ(特殊))
                                    Call ltMsg.getString(CPstrVERUP_PROHIBITED_FLAG, .strVerUpProhibitedFlag)   'ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ(0:可、1:不可)
                                    Call ltMsg.getString(CPstrPROHIBITED_EMP_NAME, .strProhibitedEmpName)       '禁止設定者名
                                    Call ltMsg.getString(CPstrPROHIBITED_DEPT_NAME, .strProhibitedDeptName)     '禁止設定者部署名
                                    Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               '最終更新日時(LOT_STATUS.EDIT_TIME)
                                    Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                         '送品先
                                    Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                              'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        '@↓2017/07/20 (Thu) 12:52:30 Y.Yoneyama **************************************************
                                    Call ltMsg.getString(CPstrFLOW_CHANGE_COUNT, .strFlowChangeCount)           '工順変更回数
        '@↑2017/07/20 (Thu) 12:52:30 Y.Yoneyama **************************************************
                                End With
                                
                                .typProcChg.Add(typProcChgTmp)

                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcProcChgList_Sel = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrprocprocchglistVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnProcProcchgstatus_Upd
    '機　能：工順状態変更
    '引　数：ltypprocchgstatusReq   ：要求構造体
    '　　　：lstrResult             ：結果(OK,NG)
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/06/27 (Tue) 10:30:05 N.Kasai
    '更新日：2008/06/11 (Wed) 17:56:53 N.Kojima
    '備　考：
    '　　　：2007/04/05 (Thu) 10:23:38 N.Kasai      要求ﾀｸﾞ追加(№01831)
    '　　　：2007/11/20 (Tue) 15:37:57 N.Kasai      要求ﾀｸﾞ削除(№02347)
    '　　　：2008/06/11 (Wed) 17:56:53 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnProcProcchgstatus_Upd(ByRef ltypProcchgstatusReq As ProcchgstatusReq, _
                                                Optional ByRef lstrResult As String = vbNullString, _
                                                Optional ByRef lstrGuidMsg As String = vbNullString, _
                                                Optional ByRef lstrGuidMsgCode As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "工順状態変更"
            pubblnProcProcchgstatus_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypProcchgstatusReq
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@ｱｸｼｮﾝ
                If .strAction <> vbNullString Then
                    Call lrMsg.addString(CPstrACTION, .strAction)
                Else
                    Call lrMsg.addString(CPstrACTION, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@編集者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
            
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrprocprocchgstatus, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrRESULT, lstrResult)                   '判定結果(OK、NG)
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                     'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)            'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcProcchgstatus_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypProcchgstatusReq.strMsgVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnProcCancelProcEdit_Upd
    '機　能：工順編集取消し
    '引　数：lstrSbID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrproccancelproceditVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID                  ：ﾛｯﾄID
    '　　　：lstrEmpId                  ：編集者ID
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/06/29 (Thu) 12:46:12 N.Kasai
    '更新日：2008/06/11 (Wed) 17:59:53 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 17:59:53 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnProcCancelProcEdit_Upd(ByVal lstrSBID As String, _
                                                 ByVal lstrproccancelproceditVer As String, _
                                                 ByVal lstrLotID As String, _
                                                 ByVal lstrEmpID As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "工順編集取消し"
            pubblnProcCancelProcEdit_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrproccancelproceditVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrproccancelproceditVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@編集者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrproccancelprocedit, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcCancelProcEdit_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrproccancelproceditVer)

                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnProcProcFlowList_Sel
    '機　能：工程ﾌﾛｰ取得
    '引　数：ltypProcFlowListReq    ：要求
    '　　　：ltypProcFlowListAns    ：応答
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/07/04 (Tue) 10:02:38 N.Kasai
    '更新日：2018/03/12 (Mon) 15:40:11 T.Oide
    '備　考：
    Public Function pubblnProcProcFlowList_Sel(ByRef ltypProcFlowListReq As ProcFlowListReq, _
                                               ByRef ltypProcFlowListAns As ProcFlowListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim ltMsg3              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用3
        Dim ltMsg4              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用4(ﾚｼﾋﾟ選択APC)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim laAry3              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ3
        Dim laAry4              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ4(ﾚｼﾋﾟ選択APC)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim llngCnt2            As String           'ｶｳﾝﾄ用2
        Dim llngCnt3            As String           'ｶｳﾝﾄ用3
        Dim llngCnt4            As String           'ｶｳﾝﾄ用4
        Dim strWork             As String
        
        Try
            
            pstrMessageName = "工程フロー取得"
            pubblnProcProcFlowList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry3 = New TfMsgAry
            ltMsg3 = New TfMsg
        '@↓2018/03/12 (Mon) 15:42:06 T.Oide **************************************************
            laAry4 = New TfMsgAry
            ltMsg4 = New TfMsg
        '@↑2018/03/12 (Mon) 15:42:06 T.Oide **************************************************

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypProcFlowListReq
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@ﾄﾗﾍﾞﾗｰﾀｲﾌﾟ(流動票ﾀｲﾌﾟ)
                If .strTravelerType <> vbNullString Then
                    Call lrMsg.addString(CPstrTRAVELER_TYPE, .strTravelerType)
                Else
                    Call lrMsg.addString(CPstrTRAVELER_TYPE, CPstrMsgNull)
                End If
            
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrprocprocflowlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@SVからの応答により処理分岐
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypProcFlowListAns
                    
                        '@受信結果取得
                        Call laMsg.getString(CPstrCURRENT_STATUS, .strCurrentStatus)                            '現在状態
                        Call laMsg.getString(CPstrCURRENT_STATUS_NAME, .strCurrentStatusName)                   '現在状態(和名)
                        Call laMsg.getString(CPstrCURRENT_OP_ID, .strCurrentOpID)                               '現在大工程
                        Call laMsg.getString(CPstrCURRENT_STEP_ID, .strCurrentStepID)                           '現在小工程
                        Call laMsg.getString(CPstrCHANGE, .strChange)                                           '全体変更区分
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：工順ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrPROCESS_FLOW_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認：工順ﾘｽﾄﾃﾞｰﾀ数
                        .lngLotProcFlowCnt = laAry.Count
                        
                        '@工順ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngLotProcFlowCnt > 0 Then
                        
                            '@配列領域の確保
                            If .typLotProcFlow Is Nothing Then
                                .typLotProcFlow = New List(Of FlowList)
                            Else
                                .typLotProcFlow.Clear
                            End If

                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typLotProcFlowTmp As New FlowList

                                With typLotProcFlowTmp

                                    Call ltMsg.getString(CPstrSTATE, .strState)                                 '状態
                                    Call ltMsg.getString(CPstrPERMIT, .strPermit)                               '編集可否
                                    Call ltMsg.getString(CPstrCHANGE, .strChange)                               '変更区分
                                    Call ltMsg.getString(CPstrABS_NO, .strAbsNo)                                '絶対工順番号
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                    Call ltMsg.getString(CPstrCONDITION_ID, .strConditionId)                    '処理条件ID
                                    Call ltMsg.getString(CPstrCONDITION_VERSION, .strConditionVersion)          '処理条件ﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrSELECT_CONDITION_ID, .strSelectConditionID)       '測定条件ｾｯﾄID
                                    Call ltMsg.getString(CPstrCOLLECTION_ID, .strCollectionID)                  '収集項目ID
                                    Call ltMsg.getString(CPstrCOLLECTION_VERSION, .strCollectionVersion)        '収集項目ﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrLOT_SCRAP_SET_ID, .strLotScrapSetID)              '不良項目ｾｯﾄID
                                    Call ltMsg.getString(CPstrREWORK_ROUTE_ID, .strReworkRouteID)               'ﾘﾜｰｸﾙｰﾄID
                                    Call ltMsg.getString(CPstrREWORK_RETURN_OP_ID, .strReworkReturnOpID)        'ﾘﾜｰｸ戻り大工程
                                    Call ltMsg.getString(CPstrREWORK_RETURN_STEP_ID, .strReworkReturnStepID)    'ﾘﾜｰｸ戻り小工程
                                    Call ltMsg.getString(CPstrSPECIAL_ROUTE_ID, .strSpecialRouteID)             '追加ﾙｰﾄID
                                    Call ltMsg.getString(CPstrSPECIAL_RETURN_OP_ID, .strSpecialReturnOpID)      '追加戻り大工程
                                    Call ltMsg.getString(CPstrSPECIAL_RETURN_STEP_ID, .strSpecialReturnStepID)  '追加戻り小工程
                                    Call ltMsg.getString(CPstrSWAP_INDICATOR, .strSwapIndicator)                '入替可能工程
                                    Call ltMsg.getString(CPstrALT_START_FLAG, .strAltStartFlag)                 '代替開始ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrALT_END_FLAG, .strAltEndFlag)                     '代替終了ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrALT_POINTER, .strAltPointer)                      '代替ﾎﾟｲﾝﾀ
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：時間制約ﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrTIME_RESTRICT_LIST, laAry2)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2ﾃﾞｰﾀ数：時間制約ﾘｽﾄﾃﾞｰﾀ数
                                    .lngTimeOrderCnt = laAry2.Count
                                    
                                    '@時間制約ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngTimeOrderCnt > 0 Then
                                    
                                        '@配列領域2の確保
                                        .typTimeOrder = New List(Of TimeOrder)
                                        
                                        '@ｶｳﾝﾀの初期化
                                        llngCnt2 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各ﾃﾞｰﾀ取得
                                        For Each ltMsg2 In laAry2
                                            Dim typTimeOrderTmp As New TimeOrder

                                            With typTimeOrderTmp
                                            
                                                Call ltMsg2.getString(CPstrLIST_ORDER, .strListOrder)               '時間制約
                                                Call ltMsg2.getString(CPstrSTATUS_FLAG, .strStatusFlag)             '時間制約状態ﾌﾗｸﾞ
                                                Call ltMsg2.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)    '制約ﾀｲﾌﾟ
                                                Call ltMsg2.getString(CPstrOUT_SIDE_FLAG, .strOutSideFlag)          '外部開始・終了

                                            End With
                                            
                                            .typTimeOrder.Add(typTimeOrderTmp)

                                            '@ｶｳﾝﾀを+1する
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3の格納：APCﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrAPC_LIST, laAry3)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3ﾃﾞｰﾀ数：APCﾘｽﾄﾃﾞｰﾀ数
                                    .lngApcOrderCnt = laAry3.Count
                                    
                                    '@APCﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngApcOrderCnt > 0 Then
                                    
                                        '@配列領域3の確保
                                        .typApcOrder = New List(Of ApcOrder)

                                        '@ｶｳﾝﾀの初期化
                                        llngCnt3 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ3から各ﾃﾞｰﾀ取得
                                        For Each ltMsg3 In laAry3
                                            Dim typApcOrderTmp As New ApcOrder

                                            With typApcOrderTmp
                                            
                                                Call ltMsg3.getString(CPstrLIST_ORDER, .strListOrder)               'APCｵｰﾀﾞ番号
                                                Call ltMsg3.getString(CPstrSTATUS_FLAG, .strStatusFlag)             'APC状態ﾌﾗｸﾞ
                                                Call ltMsg3.getString(CPstrAPC_TYPE, .strApcType)                   'APCﾀｲﾌﾟ
        '@↓2018/03/12 (Mon) 15:47:45 T.Oide **************************************************
        '@                                        Dim strWork As String
        '@↑2018/03/12 (Mon) 15:47:45 T.Oide **************************************************
                                                Call ltMsg3.getString(CPstrAPC_WF_UNIT_FLG, strWork)               '@APC枚葉設定
                                               .blnApcWfUnitFlg = CBool(strWork)
                                                
                                            End With
                                            .typApcOrder.Add(typApcOrderTmp)
                                            '@ｶｳﾝﾀを+1する
                                            llngCnt3 = llngCnt3 + 1
                                        Next
                                    End If
                                    
                                    Call ltMsg.getString(CPstrLOT_RECIPE_FLAG, .strLotRecipeFlag)                   'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrWF_RECIPE_FLAG, .strWfRecipeFlag)                     'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrS_FLAG, .strSFlag)                                    '特殊特性ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrENTRY_ID, .strEntryID)                                'ｴﾝﾄﾘｰID
                                    Call ltMsg.getString(CPstrWORK_CONDITION, .strWorkCondition)                    '作業条件
                                    Call ltMsg.getString(CPstrPROC_CHANGE_RECIPE_FLAG, .strProcChangeRecipeFlag)    '工順変更ﾚｼﾋﾟﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCOMMIT_FLAG, .strCommitFlag)                          '号機指定
                                    Call ltMsg.getString(CPstrJUDGE_SKIP_FLAG, .strJudgeSkipFlag)                   'SPC判定ｽｷｯﾌﾟﾌﾗｸﾞ( 0: SKIP不可、1:SKIP可)
                                    Call ltMsg.getString(CPstrWF_PARTIAL_RECIPE_FLAG, .strWfPartialRecipeFlag)      '枚葉ﾚｼﾋﾟ設定 ﾌﾗｸﾞ(0：全数、1:部分)
        '                            Call ltMsg.getString(CPstrAPC_TYPE, .strApcType)                                'APCﾀｲﾌﾟ
        '                            Call ltMsg.getString(CPstrLIST_ORDER, .strListOrder)                            'ﾘｽﾄｵｰﾀﾞ
        '                            Call ltMsg.getString(CPstrSTATUS_FLAG, .strStatusFlag)                          'F/B工程ﾌﾗｸﾞ(P：処理、M：測定)
                                    Call ltMsg.getString(CPstrAPC_SKIP_FLAG, .strApcSkipFlag)                       'APC適用外(0：適用、1：適用外)
                                    Call ltMsg.getString(CPstrAPC_CALC_SKIP_FLAG, .strApcCalcSkipFlag)              'APC計算除外(0：計算実施、1：計算除外)
                                    Call ltMsg.getString(CPstrWP_RESTRICT_KIND, .strWpRestrictKind)                 '号機限定種別(1:記憶、2:限定)
                                    Call ltMsg.getString(CPstrWP_RESTRICT_NUM, .strWpRestrictNum)                   '号機限定番号
                                    Call ltMsg.getString(CPstrCDEN_CLASS, .strCdenClass)                            'CDEN_CLASS
                                    Call ltMsg.getString(CPstrGRB_CLASS, .strGrbClass)                              'GRB限定工程設定
                                    Call ltMsg.getString(CPstrTPAL_CLASS, .strTpalClass)                            'TPAL区分
                                    Call ltMsg.getString(CPstrCARRIER_CATEGORY_ID, .strCarrierCategoryId)           'ｷｬﾘｱｶﾃｺﾞﾘ
                                    Call ltMsg.getString(CPstrMAP_USE_FLAG, .strMapUseFlag)                         'ﾏｯﾌﾟ適用ﾌﾗｸﾞ( 0:非自動適用、1:自動適用)
                                    Call ltMsg.getString(CPstrPRIORITY, .strPriority)                               '区間優先度
                                    Call ltMsg.getString(CPstrAPC_TEOS_GROUP_NO, .typApcTeos.strGroupNo)            'APC TEOSグループ番号
                                    Call ltMsg.getString(CPstrAPC_TEOS_NO_IN_GROUP, .typApcTeos.strNoInGroup)       'APC TEOSグループ内番号
                                    Call ltMsg.getString(CPstrAPC_TEOS_CALC_SKIP, .typApcTeos.strCalcSkipFlag)      'APC TEOS計算スキップ
                                    Call ltMsg.getString(CPstrAPC_TEOS_FB_TYPE, .typApcTeos.strApcType)             'APC TEOS設定可否
                                    Call ltMsg.getString(CPstrTEOS_PRISM_APC_GROUP_NO, .typTeosPrismApc.strGroupNo)         'TEOS PrismAPCグループ№
                                    Call ltMsg.getString(CPstrTEOS_PRISM_APC_NO_IN_GROUP, .typTeosPrismApc.strNoInGroup)    'TEOS PrismAPCグループ内№
                                    Call ltMsg.getString(CPstrTEOS_PRISM_APC_CALC_SKIP, .typTeosPrismApc.strCalcSkipFlag)   'TEOS PrismAPC計算スキップ
                                    Call ltMsg.getString(CPstrTEOS_PRISM_APC_TYPE, .typTeosPrismApc.strApcType)             'TEOS PrismAPCタイプ
                                    
                                    '@ﾃﾞｨｽｺﾝ
                                    Call ltMsg.getString(CPstrOP_VALID, .strOpValid)                                '大工程有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrSTEP_VALID, .strStepValid)                            '小工程有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCONDITION_VALID, .strConditionValid)                  '処理条件有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCOLLECTION_VALID, .strCollectionValid)                '収集項目有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrREWORK_ROUTE_VALID, .strReworkRouteValid)             'ﾘﾜｰｸﾙｰﾄ有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrSPECIAL_ROUTE_VALID, .strSpecialRouteValid)           '特殊ﾙｰﾄ有効ﾌﾗｸﾞ
                                    
        '@↓2018/03/12 (Mon) 15:39:03 T.Oide **************************************************
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3の格納：ﾚｼﾋﾟ選択APCﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrRECP_SEL_APC_LIST, laAry4)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ4ﾃﾞｰﾀ数：「ﾚｼﾋﾟ選択APC」ﾘｽﾄﾃﾞｰﾀ数
                                    .lngRecpSelApcCnt = laAry4.Count
                                    
                                    '@APCﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngRecpSelApcCnt > 0 Then
                                    
                                        '@配列領域3の確保
                                        .typRecpSelApc = New List(Of ApcOrder)

                                        '@ｶｳﾝﾀの初期化
                                        llngCnt4 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ4から各ﾃﾞｰﾀ取得
                                        For Each ltMsg4 In laAry4
                                            Dim typRecpSelApcTmp As New ApcOrder
                                            With typRecpSelApcTmp
                                            
                                                Call ltMsg4.getString(CPstrLIST_ORDER, .strListOrder)       'APCｵｰﾀﾞ番号
                                                Call ltMsg4.getString(CPstrSTATUS_FLAG, .strStatusFlag)     'APC状態ﾌﾗｸﾞ
                                                Call ltMsg4.getString(CPstrAPC_TYPE, .strApcType)           'APCﾀｲﾌﾟ
                                                Call ltMsg4.getString(CPstrAPC_WF_UNIT_FLG, strWork)        '@APC枚葉設定
                                               .blnApcWfUnitFlg = CBool(strWork)
                                                
                                            End With
                                            
                                            .typRecpSelApc.Add(typRecpSelApcTmp)

                                            '@ｶｳﾝﾀを+1する
                                            llngCnt4 = llngCnt4 + 1
                                        Next
                                    End If
        '@↑2018/03/12 (Mon) 15:39:03 T.Oide **************************************************
                                    
                                End With
                                
                                .typLotProcFlow.Add(typLotProcFlowTmp)

                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcProcFlowList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypProcFlowListReq.strMsgVer)

                    
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
            laAry2 = Nothing
            ltMsg2 = Nothing
            laAry3 = Nothing
            ltMsg3 = Nothing
        '@↓2018/03/12 (Mon) 15:42:33 T.Oide **************************************************
            laAry4 = Nothing
            ltMsg4 = Nothing
        '@↑2018/03/12 (Mon) 15:42:33 T.Oide **************************************************


            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing
            laAry3 = Nothing
            ltMsg3 = Nothing
        '@↓2018/03/12 (Mon) 15:42:33 T.Oide **************************************************
            laAry4 = Nothing
            ltMsg4 = Nothing
        '@↑2018/03/12 (Mon) 15:42:33 T.Oide **************************************************

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '@'関数名：pubblnProcProcRegist_Ins
    '@'機　能：ﾌﾟﾛｾｽ登録
    '@'引　数：ltypProcRegistReq      ：ﾌﾟﾛｾｽ登録要求
    '@'　　　：ltypLotCghCollectRecp  ：ﾚｼﾋﾟ一括変更ﾃﾞｰﾀ
    '@'　　　：ltypProcTimeLimitInfo  ：時間制約設定ﾃﾞｰﾀ
    '@'　　　：ltypProcRegistAns      ：ﾌﾟﾛｾｽ登録応答
    '@'      ：lstApcTeosStep         ：APC TEOS用データ
    '@'      ：lstTeosPrismAPCStep    ：TEOSPrismAPC用データ
    '@'戻り値：True:成功、Flase：失敗
    '@'作成日：2006/07/12 (Wed) 13:05:31 N.Kasai
    '@'更新日：2016/02/11 (Thu) 22:54:10 H.Hayashi
    '@'備　考：
    '@'　　　：2007/04/05 (Thu) 15:23:19 N.Kasai      応答ﾀｸﾞ追加(LOT_LAST_UPDATE)　№01831
    '@'　　　：2007/05/29 (Tue) 15:03:50 N.Kasai      処理号機対応(№01934)
    '@'　　　：2007/11/20 (Tue) 15:39:42 N.Kasai      要求ﾀｸﾞ追加(№02347)
    '@'　　　：2008/06/11 (Wed) 18:24:41 N.Kojima     ｿｰｽ整備。(案件№02884)
    '@'　　　：2009/02/11 (Tue) 15:28:00 T.Oide       Chip電特対応(CDEN_CLASS追加)
    '@'　　　：2013/08/06 (Tue) 10:24:56 T.Oide       TEOS PrismAPC対応
    '@'      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    '@Public Function pubblnProcProcRegist_Ins(ByRef ltypProcRegistReq As ProcRegistReq, _
    '@                                         ByRef ltypLotCghCollectRecp As ProcChgCollectRecp, _
    '@                                         ByRef ltypProcTimeLimitInfo As ProcTimeLimitInfo, _
    '@                                         ByRef ltypProcRegistAns As ProcRegistAns, _
    '@                                         ByRef lstApcTeosStep() As TypeApcTeosStep, _
    '@                                         ByRef ltypTeosPrismAPCStep() As TypeApcTeosStep) As Boolean
    '関数名：pubblnProcProcRegist_Ins
    '機　能：ﾌﾟﾛｾｽ登録
    '引　数：ltypProcRegistReq      ：ﾌﾟﾛｾｽ登録要求
    '　　　：ltypLotCghCollectRecp  ：ﾚｼﾋﾟ一括変更ﾃﾞｰﾀ
    '　　　：ltypProcTimeLimitInfo  ：時間制約設定ﾃﾞｰﾀ
    '　　　：ltypProcRegistAns      ：ﾌﾟﾛｾｽ登録応答
    '      ：lstApcTeosStep         ：APC TEOS用データ
    '      ：ltypTeosPrismAPCStep   ：TEOSPrismAPC用データ
    '      ：ltypRecipSelApc        ：ﾚｼﾋﾟ選択APCデータ
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/07/12 (Wed) 13:05:31 N.Kasai
    '更新日：2018/03/14 (Wed) 15:54:45 T.Oide
    '備　考：
    Public Function pubblnProcProcRegist_Ins(ByRef ltypProcRegistReq As ProcRegistReq, _
                                             ByRef ltypLotCghCollectRecp As ProcChgCollectRecp, _
                                             ByRef ltypProcTimeLimitInfo As ProcTimeLimitInfo, _
                                             ByRef ltypProcRegistAns As ProcRegistAns, _
                                             ByRef lstApcTeosStep As List(Of TypeApcTeosStep), _
                                             ByRef ltypTeosPrismAPCStep As List(Of TypeApcTeosStep), _
                                             ByRef ltypRecipSelApc As RecipeSelApc) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim lrAry2              As TfMsgAry         'ｱﾚｰ作成用
        Dim lrAry3              As TfMsgAry         'ｱﾚｰ作成用
        Dim lrAry4              As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim ltMsg2              As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg3              As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg4              As TfMsg            'ｱﾚｰの各要素作成用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ
        Dim llngCnt3            As Integer          'ｶｳﾝﾄ
        Dim llngCnt4            As Integer          'ｶｳﾝﾄ
        Dim nApcTeosDataCount   As Integer          'APC TEOS用データ数
        Dim i                   As Integer          '汎用カウンタ
        Dim llngTeosPrismApcCnt As Integer          'TEOS PrismAPCのﾃﾞｰﾀ数
        
        Try

            pstrMessageName = "プロセス登録"
            pubblnProcProcRegist_Ins = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            lrAry2 = New TfMsgAry
            lrAry3 = New TfMsgAry
        '@↓2018/03/14 (Wed) 16:05:02 T.Oide **************************************************
            lrAry4 = New TfMsgAry
        '@↑2018/03/14 (Wed) 16:05:02 T.Oide **************************************************
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
            ltMsg3 = New TfMsg
        '@↓2018/03/14 (Wed) 16:04:53 T.Oide **************************************************
            ltMsg4 = New TfMsg
        '@↑2018/03/14 (Wed) 16:04:53 T.Oide **************************************************

            '@***********************
            '@　送信ﾃﾞｰﾀ作成(ﾌﾟﾛｾｽ登録ﾃﾞｰﾀ)
            '@***********************
            With ltypProcRegistReq
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@ｱｸｼｮﾝ(1：一時保存、2:確定)
                If .strAction <> vbNullString Then
                    Call lrMsg.addString(CPstrACTION, .strAction)
                Else
                    Call lrMsg.addString(CPstrACTION, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@開始変更工順
                If .strStartSeqNum <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_SEQ_NUM, .strStartSeqNum)
                Else
                    Call lrMsg.addString(CPstrSTART_SEQ_NUM, CPstrMsgNull)
                End If
                
                '@全体変更区分
                If .strChange <> vbNullString Then
                    Call lrMsg.addString(CPstrCHANGE, .strChange)
                Else
                    Call lrMsg.addString(CPstrCHANGE, CPstrMsgNull)
                End If
                
                '@Ver禁止設定(0:可、1:不可)
                If .strVerUpProhibitedFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrVERUP_PROHIBITED_FLAG, .strVerUpProhibitedFlag)
                Else
                    Call lrMsg.addString(CPstrVERUP_PROHIBITED_FLAG, CPstrMsgNull)
                End If
                
                '@工程情報ｾｯﾄ
                If .lngProcFlowCnt > 0 Then
                    
                    llngCnt = 0
                    
                    Do While .lngProcFlowCnt -1 > = llngCnt
                        
                        With .typProcFlow(llngCnt)
                            
                            '@状態
                            If .strState <> vbNullString Then
                                Call ltMsg.addString(CPstrSTATE, .strState)
                            Else
                                Call ltMsg.addString(CPstrSTATE, CPstrMsgNull)
                            End If
                            
                            '@編集可否
                            If .strPermit <> vbNullString Then
                                Call ltMsg.addString(CPstrPERMIT, .strPermit)
                            Else
                                Call ltMsg.addString(CPstrPERMIT, CPstrMsgNull)
                            End If
                            
                            '@変更区分
                            If .strChange <> vbNullString Then
                                Call ltMsg.addString(CPstrCHANGE, .strChange)
                            Else
                                Call ltMsg.addString(CPstrCHANGE, CPstrMsgNull)
                            End If
                            
                            '@絶対工順番号
                            If .strAbsNo <> vbNullString Then
                                Call ltMsg.addString(CPstrABS_NO, .strAbsNo)
                            Else
                                Call ltMsg.addString(CPstrABS_NO, CPstrMsgNull)
                            End If
                            
                            '@ﾛｯﾄ工順
                            If .strSeqNum <> vbNullString Then
                                Call ltMsg.addString(CPstrSEQ_NUM, .strSeqNum)
                            Else
                                Call ltMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)
                            End If
                            
                            '@大工程ID
                            If .strOpID <> vbNullString Then
                                Call ltMsg.addString(CPstrOP_ID, .strOpID)
                            Else
                                Call ltMsg.addString(CPstrOP_ID, CPstrMsgNull)
                            End If
                            
                            '@小工程ID
                            If .strStepID <> vbNullString Then
                                Call ltMsg.addString(CPstrSTEP_ID, .strStepID)
                            Else
                                Call ltMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                            End If
                            
                            '@処理条件ID
                            If .strConditionId <> vbNullString Then
                                Call ltMsg.addString(CPstrCONDITION_ID, .strConditionId)
                            Else
                                Call ltMsg.addString(CPstrCONDITION_ID, CPstrMsgNull)
                            End If
                            
                            '@処理条件ﾊﾞｰｼﾞｮﾝ
                            If .strConditionVersion <> vbNullString Then
                                Call ltMsg.addString(CPstrCONDITION_VERSION, .strConditionVersion)
                            Else
                                Call ltMsg.addString(CPstrCONDITION_VERSION, CPstrMsgNull)
                            End If
                            
                            '@測定条件ｾｯﾄID
                            If .strSelectConditionID <> vbNullString Then
                                Call ltMsg.addString(CPstrSELECT_CONDITION_ID, .strSelectConditionID)
                            Else
                                Call ltMsg.addString(CPstrSELECT_CONDITION_ID, CPstrMsgNull)
                            End If
                            
                            '@収集項目ID
                            If .strCollectionID <> vbNullString Then
                                Call ltMsg.addString(CPstrCOLLECTION_ID, .strCollectionID)
                            Else
                                Call ltMsg.addString(CPstrCOLLECTION_ID, CPstrMsgNull)
                            End If
                            
                            '@収集項目ﾊﾞｰｼﾞｮﾝ
                            If .strCollectionVersion <> vbNullString Then
                                Call ltMsg.addString(CPstrCOLLECTION_VERSION, .strCollectionVersion)
                            Else
                                Call ltMsg.addString(CPstrCOLLECTION_VERSION, CPstrMsgNull)
                            End If
                            
                            '@不良項目ｾｯﾄID
                            If .strLotScrapSetID <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_SCRAP_SET_ID, .strLotScrapSetID)
                            Else
                                Call ltMsg.addString(CPstrLOT_SCRAP_SET_ID, CPstrMsgNull)
                            End If
                            
                            '@ﾘﾜｰｸﾙｰﾄID
                            If .strReworkRouteID <> vbNullString Then
                                Call ltMsg.addString(CPstrREWORK_ROUTE_ID, .strReworkRouteID)
                            Else
                                Call ltMsg.addString(CPstrREWORK_ROUTE_ID, CPstrMsgNull)
                            End If
                            
                            '@ﾘﾜｰｸ戻り大工程
                            If .strReworkReturnOpID <> vbNullString Then
                                Call ltMsg.addString(CPstrREWORK_RETURN_OP_ID, .strReworkReturnOpID)
                            Else
                                Call ltMsg.addString(CPstrREWORK_RETURN_OP_ID, CPstrMsgNull)
                            End If
                            
                            '@ﾘﾜｰｸ戻り小工程
                            If .strReworkReturnStepID <> vbNullString Then
                                Call ltMsg.addString(CPstrREWORK_RETURN_STEP_ID, .strReworkReturnStepID)
                            Else
                                Call ltMsg.addString(CPstrREWORK_RETURN_STEP_ID, CPstrMsgNull)
                            End If
                            
                            '@追加ﾙｰﾄID
                            If .strSpecialRouteID <> vbNullString Then
                                Call ltMsg.addString(CPstrSPECIAL_ROUTE_ID, .strSpecialRouteID)
                            Else
                                Call ltMsg.addString(CPstrSPECIAL_ROUTE_ID, CPstrMsgNull)
                            End If
                            
                            '@追加戻り大工程
                            If .strSpecialReturnOpID <> vbNullString Then
                                Call ltMsg.addString(CPstrSPECIAL_RETURN_OP_ID, .strSpecialReturnOpID)
                            Else
                                Call ltMsg.addString(CPstrSPECIAL_RETURN_OP_ID, CPstrMsgNull)
                            End If
                            
                            '@追加戻り小工程
                            If .strSpecialReturnStepID <> vbNullString Then
                                Call ltMsg.addString(CPstrSPECIAL_RETURN_STEP_ID, .strSpecialReturnStepID)
                            Else
                                Call ltMsg.addString(CPstrSPECIAL_RETURN_STEP_ID, CPstrMsgNull)
                            End If
                            
                            '@SPC判定ｽｷｯﾌﾟﾌﾗｸﾞ( 0: SKIP不可、1:SKIP可)
                            If .strJudgeSkipFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrJUDGE_SKIP_FLAG, .strJudgeSkipFlag)
                            Else
                                Call ltMsg.addString(CPstrJUDGE_SKIP_FLAG, CPstrMsgNull)
                            End If

                            '@工程情報ｾｯﾄ
                            If .lngApcOrderCnt > 0 Then
                            
                                llngCnt3 = 0
                                
                                Do While .lngApcOrderCnt -1 >= llngCnt3
                                    
                                    With .typApcOrder(llngCnt3)
                                        
                                        '@F/B工程フラグ(S：開始、E：終了)
                                        If .strStatusFlag <> vbNullString Then
                                            Call ltMsg3.addString(CPstrSTATUS_FLAG, .strStatusFlag)
                                        Else
                                            Call ltMsg3.addString(CPstrSTATUS_FLAG, CPstrMsgNull)
                                        End If
                                        
                                        '@APCﾀｲﾌﾟ
                                        If .strApcType <> vbNullString Then
                                            Call ltMsg3.addString(CPstrAPC_TYPE, .strApcType)
                                        Else
                                            Call ltMsg3.addString(CPstrAPC_TYPE, CPstrMsgNull)
                                        End If
                                        
                                        '@APCﾘｽﾄｵｰﾀﾞ
                                        If .strListOrder <> vbNullString Then
                                            Call ltMsg3.addString(CPstrLIST_ORDER, .strListOrder)
                                        Else
                                            Call ltMsg3.addString(CPstrLIST_ORDER, CPstrMsgNull)
                                        End If
                                        
                                        '@APC枚葉設定
                                        If .blnApcWfUnitFlg <> False Then
                                            'サーバーとクラインのTRUEの定義が異なるためここで吸収します
                                            Call ltMsg3.addString(CPstrAPC_WF_UNIT_FLG, "1")
                                        Else
                                            Call ltMsg3.addString(CPstrAPC_WF_UNIT_FLG, "0")
                                        End If
                                        
                                        Call lrAry3.Add(ltMsg3)
                                        ltMsg3.Clear
                                        
                                        llngCnt3 = llngCnt3 + 1
                                        
                                    End With
                                Loop
                            Else
                                ltMsg3.Clear
                            End If
                            
                            Call ltMsg.addMsgAry(CPstrAPC_LIST, lrAry3)
                            lrAry3.Clear
                            
                            '@APC適用外( 0: 適用、1:適用外)
                            If .strApcSkipFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrAPC_SKIP_FLAG, .strApcSkipFlag)
                            Else
                                Call ltMsg.addString(CPstrAPC_SKIP_FLAG, CPstrMsgNull)
                            End If
                            
                            '@APC計算除外( 0: 対象、1:除外)
                            If .strApcCalcSkipFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrAPC_CALC_SKIP_FLAG, .strApcCalcSkipFlag)
                            Else
                                Call ltMsg.addString(CPstrAPC_CALC_SKIP_FLAG, CPstrMsgNull)
                            End If
                            
                            '@入替可能工程
                            If .strSwapIndicator <> vbNullString Then
                                Call ltMsg.addString(CPstrSWAP_INDICATOR, .strSwapIndicator)
                            Else
                                Call ltMsg.addString(CPstrSWAP_INDICATOR, CPstrMsgNull)
                            End If
                            
                            '@代替開始ﾌﾗｸﾞ
                            If .strAltStartFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrALT_START_FLAG, .strAltStartFlag)
                            Else
                                Call ltMsg.addString(CPstrALT_START_FLAG, CPstrMsgNull)
                            End If
                            
                            '@代替終了ﾌﾗｸﾞ
                            If .strAltEndFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrALT_END_FLAG, .strAltEndFlag)
                            Else
                                Call ltMsg.addString(CPstrALT_END_FLAG, CPstrMsgNull)
                            End If
                            
                            '@代替ﾎﾟｲﾝﾀ
                            If .strAltPointer <> vbNullString Then
                                Call ltMsg.addString(CPstrALT_POINTER, .strAltPointer)
                            Else
                                Call ltMsg.addString(CPstrALT_POINTER, CPstrMsgNull)
                            End If
                            
                            '@ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                            If .strLotRecipeFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_RECIPE_FLAG, .strLotRecipeFlag)
                            Else
                                Call ltMsg.addString(CPstrLOT_RECIPE_FLAG, CPstrMsgNull)
                            End If
                            
                            '@WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                            If .strWfRecipeFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrWF_RECIPE_FLAG, .strWfRecipeFlag)
                            Else
                                Call ltMsg.addString(CPstrWF_RECIPE_FLAG, CPstrMsgNull)
                            End If
                            
                            '@特殊特性ﾌﾗｸﾞ
                            If .strSFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrS_FLAG, .strSFlag)
                            Else
                                Call ltMsg.addString(CPstrS_FLAG, CPstrMsgNull)
                            End If
                            
                            '@ｴﾝﾄﾘｰID
                            If .strEntryID <> vbNullString Then
                                Call ltMsg.addString(CPstrENTRY_ID, .strEntryID)
                            Else
                                Call ltMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
                            End If
                            
                            '@作業条件
                            If .strWorkCondition <> vbNullString Then
                                Call ltMsg.addString(CPstrWORK_CONDITION, .strWorkCondition)
                            Else
                                Call ltMsg.addString(CPstrWORK_CONDITION, CPstrMsgNull)
                            End If
                            
                            '@工順変更ﾚｼﾋﾟﾌﾗｸﾞ
                            If .strProcChangeRecipeFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrPROC_CHANGE_RECIPE_FLAG, .strProcChangeRecipeFlag)
                            Else
                                Call ltMsg.addString(CPstrPROC_CHANGE_RECIPE_FLAG, CPstrMsgNull)
                            End If
                            
                            '@枚葉ﾚｼﾋﾟ設定 ﾌﾗｸﾞ(0：全数、1:部分)
                            If .strWfPartialRecipeFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrWF_PARTIAL_RECIPE_FLAG, .strWfPartialRecipeFlag)
                            Else
                                Call ltMsg.addString(CPstrWF_PARTIAL_RECIPE_FLAG, CPstrMsgNull)
                            End If
                            
                            '@処理号機種別(1：記憶、2:限定)
                            If .strWpRestrictKind <> vbNullString Then
                                Call ltMsg.addString(CPstrWP_RESTRICT_KIND, .strWpRestrictKind)
                            Else
                                Call ltMsg.addString(CPstrWP_RESTRICT_KIND, CPstrMsgNull)
                            End If
                            
                            '@処理号機番号
                            If .strWpRestrictNum <> vbNullString Then
                                Call ltMsg.addString(CPstrWP_RESTRICT_NUM, .strWpRestrictNum)
                            Else
                                Call ltMsg.addString(CPstrWP_RESTRICT_NUM, CPstrMsgNull)
                            End If
                            
                            '@CDEN_CLASS
                            If .strCdenClass <> vbNullString Then
                                Call ltMsg.addString(CPstrCDEN_CLASS, .strCdenClass)
                            Else
                                Call ltMsg.addString(CPstrCDEN_CLASS, CPstrMsgNull)
                            End If
                            
                            '@GRB_CLASS
                            If .strGrbClass <> vbNullString Then
                                Call ltMsg.addString(CPstrGRB_CLASS, .strGrbClass)
                            Else
                                Call ltMsg.addString(CPstrGRB_CLASS, CPstrMsgNull)
                            End If
                            
                            '@TPAL_CLASS
                            If .strTpalClass <> vbNullString Then
                                Call ltMsg.addString(CPstrTPAL_CLASS, .strTpalClass)
                            Else
                                Call ltMsg.addString(CPstrTPAL_CLASS, CPstrMsgNull)
                            End If
                            
                            '@CARRIER_CATEGORY_ID
                            If .strCarrierCategoryId <> vbNullString Then
                                Call ltMsg.addString(CPstrCARRIER_CATEGORY_ID, .strCarrierCategoryId)
                            Else
                                Call ltMsg.addString(CPstrCARRIER_CATEGORY_ID, CPstrMsgNull)
                            End If

                            '@ﾏｯﾌﾟ適用( 0:非自動適用、1:自動適用)
                            If .strMapUseFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrMAP_USE_FLAG, .strMapUseFlag)
                            Else
                                Call ltMsg.addString(CPstrMAP_USE_FLAG, CPstrMsgNull)
                            End If
                            
                            '@PRIORITY
                            If .strPriority <> vbNullString Then
                                Call ltMsg.addString(CPstrPRIORITY, .strPriority)
                            Else
                                Call ltMsg.addString(CPstrPRIORITY, CPstrMsgNull)
                            End If
                            
                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear
                            
                            llngCnt = llngCnt + 1
                        End With
                    Loop
                Else
                    ltMsg.Clear
                End If
                
                Call lrMsg.addMsgAry(CPstrPROCESS_FLOW_LIST, lrAry)
                lrAry.Clear
            
            End With
            
            
            '@-----------------------
            '@　ﾚｼﾋﾟ一括変更ﾃﾞｰﾀ
            '@-----------------------
            With ltypLotCghCollectRecp
            
                '@工程情報ｾｯﾄ
                If .lngProcRecpListCnt > 0 Then
                    
                    llngCnt = 0
                    
                    Do While .lngProcRecpListCnt -1 >= llngCnt
                        
                        With .typProcRecpList(llngCnt)
                            
                            '@大工程
                            If .strOpID <> vbNullString Then
                                Call ltMsg.addString(CPstrOP_ID, .strOpID)
                            Else
                                Call ltMsg.addString(CPstrOP_ID, CPstrMsgNull)
                            End If
                            
                            '@小工程
                            If .strStepID <> vbNullString Then
                                Call ltMsg.addString(CPstrSTEP_ID, .strStepID)
                            Else
                                Call ltMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                            End If
                            
                            '@ﾚｼﾋﾟ一括変更WPﾘｽﾄ
                            If .lngProcCondListCnt > 0 Then
                                
                                llngCnt2 = 0
                                
                                Do While .lngProcCondListCnt -1 >= llngCnt2
                                
                                    With .typProcCondList(llngCnt2)
                                        
                                        '@WPID
                                        If .strWpID <> vbNullString Then
                                            Call ltMsg2.addString(CPstrWP_ID, .strWpID)
                                        Else
                                            Call ltMsg2.addString(CPstrWP_ID, CPstrMsgNull)
                                        End If
                                        
                                        '@ﾚｼﾋﾟID
                                        If .strRecipeId <> vbNullString Then
                                            Call ltMsg2.addString(CPstrRECIPE_ID, .strRecipeId)
                                        Else
                                            Call ltMsg2.addString(CPstrRECIPE_ID, CPstrMsgNull)
                                        End If
                                        
                                        '@WFID
                                        If .strWfId <> vbNullString Then
                                            Call ltMsg2.addString(CPstrWF_ID, .strWfId)
                                        Else
                                            Call ltMsg2.addString(CPstrWF_ID, CPstrMsgNull)
                                        End If
                                        
                                        '@ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                                        If .strRecipeVersion <> vbNullString Then
                                            Call ltMsg2.addString(CPstrRECIPE_VERSION, .strRecipeVersion)
                                        Else
                                            Call ltMsg2.addString(CPstrRECIPE_VERSION, CPstrMsgNull)
                                        End If
                                        
                                        Call lrAry2.Add(ltMsg2)
                                        ltMsg2.Clear
                                        llngCnt2 = llngCnt2 + 1
                                    End With
                                Loop
                            Else
                                ltMsg2.Clear
                            End If
                            
                            '@WPﾘｽﾄ
                            Call ltMsg.addMsgAry(CPstrWP_LIST, lrAry2)
                            lrAry2.Clear
                            
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
            
            
            '@-----------------------
            '@　時間制約設定ﾃﾞｰﾀ
            '@-----------------------
            With ltypProcTimeLimitInfo
            
                '@時間制約ﾘｽﾄ情報ｾｯﾄ
                If .lngProcTimeLimitCnt > 0 Then
                    
                    llngCnt = 0
                    
                    Do While .lngProcTimeLimitCnt -1 >= llngCnt
                        
                        With .typProcTimeLimit(llngCnt)
                            
                            '@時間制約番号
                            If .strListOrder <> vbNullString Then
                                Call ltMsg.addString(CPstrLIST_ORDER, .strListOrder)
                            Else
                                Call ltMsg.addString(CPstrLIST_ORDER, CPstrMsgNull)
                            End If
                            
                            '@元大工程ID
                            If .strFromOpId <> vbNullString Then
                                Call ltMsg.addString(CPstrFROM_OP_ID, .strFromOpId)
                            Else
                                Call ltMsg.addString(CPstrFROM_OP_ID, CPstrMsgNull)
                            End If
                            
                            '@先大工程ID
                            If .strToOpId <> vbNullString Then
                                Call ltMsg.addString(CPstrTO_OP_ID, .strToOpId)
                            Else
                                Call ltMsg.addString(CPstrTO_OP_ID, CPstrMsgNull)
                            End If
                            
                            '@元小工程ID
                            If .strFromStepId <> vbNullString Then
                                Call ltMsg.addString(CPstrFROM_STEP_ID, .strFromStepId)
                            Else
                                Call ltMsg.addString(CPstrFROM_STEP_ID, CPstrMsgNull)
                            End If
                            
                            '@先小工程ID
                            If .strToStepId <> vbNullString Then
                                Call ltMsg.addString(CPstrTO_STEP_ID, .strToStepId)
                            Else
                                Call ltMsg.addString(CPstrTO_STEP_ID, CPstrMsgNull)
                            End If
                            
                            '@制限(制約)ﾀｲﾌﾟ名
                            If .strRestrictTypeID <> vbNullString Then
                                Call ltMsg.addString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)
                            Else
                                Call ltMsg.addString(CPstrRESTRICT_TYPE_ID, CPstrMsgNull)
                            End If
                            
                            '@警告時間
                            If .strWarnTime <> vbNullString Then
                                Call ltMsg.addString(CPstrWARN_TIME, .strWarnTime)
                            Else
                                Call ltMsg.addString(CPstrWARN_TIME, CPstrMsgNull)
                            End If
                            
                            '@制限(制約)時間
                            If .strLimitTime <> vbNullString Then
                                Call ltMsg.addString(CPstrLIMIT_TIME, .strLimitTime)
                            Else
                                Call ltMsg.addString(CPstrLIMIT_TIME, CPstrMsgNull)
                            End If
                            
                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear
                            
                            llngCnt = llngCnt + 1
                        End With
                    Loop
                Else
                    ltMsg.Clear
                End If
                
                Call lrMsg.addMsgAry(CPstrTIME_RESTRICT_LIST, lrAry)
                lrAry.Clear
            
            End With
            
            '@-----------------------
            '@ APC TEOS用工程の情報を設定
            '@-----------------------
            '領域のクリア
            lrAry.Clear
            ltMsg.Clear
            
            'データ数を取得
            nApcTeosDataCount = lstApcTeosStep.Count

            For i = 0 To nApcTeosDataCount - 1
                '大工程名
                If lstApcTeosStep(i).strOpID <> vbNullString Then
                    Call ltMsg.addString(CPstrOP_ID, lstApcTeosStep(i).strOpID)
                Else
                    Call ltMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                
                '小工程名
                If lstApcTeosStep(i).strStepID <> vbNullString Then
                    Call ltMsg.addString(CPstrSTEP_ID, lstApcTeosStep(i).strStepID)
                Else
                    Call ltMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                
                'グループ番号
                If lstApcTeosStep(i).typApcTeos.strGroupNo <> vbNullString Then
                    Call ltMsg.addString(CPstrAPC_TEOS_GROUP_NO, lstApcTeosStep(i).typApcTeos.strGroupNo)
                Else
                    Call ltMsg.addString(CPstrAPC_TEOS_GROUP_NO, CPstrMsgNull)
                End If

                'グループ内番号
                If lstApcTeosStep(i).typApcTeos.strNoInGroup <> vbNullString Then
                    Call ltMsg.addString(CPstrAPC_TEOS_NO_IN_GROUP, lstApcTeosStep(i).typApcTeos.strNoInGroup)
                Else
                    Call ltMsg.addString(CPstrAPC_TEOS_NO_IN_GROUP, CPstrMsgNull)
                End If
                  
                '計算除外
                If lstApcTeosStep(i).typApcTeos.strCalcSkipFlag <> vbNullString Then
                    Call ltMsg.addString(CPstrAPC_TEOS_CALC_SKIP, lstApcTeosStep(i).typApcTeos.strCalcSkipFlag)
                Else
                    Call ltMsg.addString(CPstrAPC_TEOS_CALC_SKIP, CPstrMsgNull)
                End If
                
                '工程タイプ
                If lstApcTeosStep(i).typApcTeos.strApcType <> vbNullString Then
                    Call ltMsg.addString(CPstrAPC_TEOS_FB_TYPE, lstApcTeosStep(i).typApcTeos.strApcType)
                Else
                    Call ltMsg.addString(CPstrAPC_TEOS_FB_TYPE, CPstrMsgNull)
                End If
                
                '1工程分の情報を配列に入れる
                Call lrAry.Add(ltMsg)
                ltMsg.Clear
            Next
            
            '作った情報を送信メッセージに追加
            Call lrMsg.addMsgAry(CPstrAPC_TEOS_STEP_LIST, lrAry)
            lrAry.Clear


            '@-----------------------
            '@ TEOS PrismAPC情報を設定
            '@-----------------------
            '@データ数を取得
            llngTeosPrismApcCnt =ltypTeosPrismAPCStep.Count
            
            '@配列要素分繰返し('配列の宣言の仕方が必ず最後の要素は空になるようにしているので-1)
            For llngCnt4 = 0 To llngTeosPrismApcCnt - 1
            
                With ltypTeosPrismAPCStep(llngCnt4)
                
                    '@大工程名
                    If .strOpID <> vbNullString Then
                        Call ltMsg.addString(CPstrOP_ID, .strOpID)
                    Else
                        Call ltMsg.addString(CPstrOP_ID, CPstrMsgNull)
                    End If
                    
                    '@小工程名
                    If .strStepID <> vbNullString Then
                        Call ltMsg.addString(CPstrSTEP_ID, .strStepID)
                    Else
                        Call ltMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                    End If
                    
                    With .typApcTeos
                        
                        '@グループ№
                        If .strGroupNo <> vbNullString Then
                            Call ltMsg.addString(CPstrTEOS_PRISM_APC_GROUP_NO, .strGroupNo)
                        Else
                            Call ltMsg.addString(CPstrTEOS_PRISM_APC_GROUP_NO, CPstrMsgNull)
                        End If
                        
                        '@グループ内№
                        If .strNoInGroup <> vbNullString Then
                            Call ltMsg.addString(CPstrTEOS_PRISM_APC_NO_IN_GROUP, .strNoInGroup)
                        Else
                            Call ltMsg.addString(CPstrTEOS_PRISM_APC_NO_IN_GROUP, CPstrMsgNull)
                        End If
                        
                        '@APCタイプ
                        If .strApcType <> vbNullString Then
                            Call ltMsg.addString(CPstrTEOS_PRISM_APC_TYPE, .strApcType)
                        Else
                            Call ltMsg.addString(CPstrTEOS_PRISM_APC_TYPE, CPstrMsgNull)
                        End If
                        
                        '@計算除外
                        If .strCalcSkipFlag <> vbNullString Then
                            Call ltMsg.addString(CPstrTEOS_PRISM_APC_CALC_SKIP, .strCalcSkipFlag)
                        Else
                            Call ltMsg.addString(CPstrTEOS_PRISM_APC_CALC_SKIP, CPstrMsgNull)
                        End If
                        
                    End With
                    
                End With
                
                '@1工程分の情報を配列に入れる
                Call lrAry.Add(ltMsg)
                ltMsg.Clear
                
            Next
            
            '@作った情報を送信メッセージに追加
            Call lrMsg.addMsgAry(CPstrTEOS_PRISM_APC_STEP_LIST, lrAry)
            lrAry.Clear
            
        '@↓2018/03/14 (Wed) 15:56:38 T.Oide **************************************************
            '@ﾚｼﾋﾟ選択APC情報
            With ltypRecipSelApc
            
                '@配列要素分繰返し('配列の宣言の仕方が必ず最後の要素は空になるようにしているので-1)
                For llngCnt4 = 0 To .lngRecipeSelApcCnt -1
                
                    With .typRecipeSelApc(llngCnt4)
                    
                        '@要素追加
                        Call ltMsg4.addString(CPstrAPC_TYPE, .strApcType)            'APCﾀｲﾌﾟ
                        Call ltMsg4.addString(CPstrLIST_ORDER, .strListOrder)        'ﾘｽﾄｵｰﾀﾞ
                        Call ltMsg4.addString(CPstrMEASURE_OP_ID, .strMeasOpId)      '測定大工程
                        Call ltMsg4.addString(CPstrMEASURE_STEP_ID, .strMeasStepId)  '測定小工程
                        Call ltMsg4.addString(CPstrPROCESS_OP_ID, .strProcOpId)      '処理大工程
                        Call ltMsg4.addString(CPstrPROCESS_STEP_ID, .strProcStepId)  '処理小工程
                        
                        '@APC枚葉ﾌﾗｸﾞはTrueか
                        If .blnApcWfUnitFlg = True Then
                            Call ltMsg4.addString(CPstrAPC_WF_UNIT_FLG, CPstrFlagOn)
                        Else
                            Call ltMsg4.addString(CPstrAPC_WF_UNIT_FLG, CPstrFlagOff)
                        End If
                        
                    End With
                    
                    '@1工程分の情報をｱﾚｰに追加
                    Call lrAry4.Add(ltMsg4)
                    ltMsg4.Clear
                    
                Next
                
                '@ｱﾚｰをﾘｸｴｽﾄﾒｯｾｰｼﾞに追加
                Call lrMsg.addMsgAry(CPstrRECP_SEL_APC_LIST, lrAry4)
                lrAry4.Clear
            
            End With
        '@↑2018/03/14 (Wed) 15:56:38 T.Oide **************************************************
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrprocprocregist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    With ltypProcRegistAns
                        Call laMsg.getString(CPstrMESSAGE_STR, .strMessageStr)          '論理ﾁｪｯｸｴﾗｰﾒｯｾｰｼﾞ
                        Call laMsg.getString(CPstrERROR_ABS_NO, .strErrorAbsNo)         'ｴﾗｰ絶対番号
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)   '最終更新日時
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcProcRegist_Ins = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypProcRegistReq.strMsgVer)
                    
                    
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
            lrAry2 = Nothing
            lrAry3 = Nothing
        '@↓2018/03/14 (Wed) 16:05:51 T.Oide **************************************************
            lrAry4 = Nothing
        '@↑2018/03/14 (Wed) 16:05:51 T.Oide **************************************************
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
        '@↓2018/03/14 (Wed) 16:05:59 T.Oide **************************************************
            ltMsg4 = Nothing
        '@↑2018/03/14 (Wed) 16:05:59 T.Oide **************************************************

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            lrAry2 = Nothing
            lrAry3 = Nothing
        '@↓2018/03/14 (Wed) 16:05:51 T.Oide **************************************************
            lrAry4 = Nothing
        '@↑2018/03/14 (Wed) 16:05:51 T.Oide **************************************************
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
        '@↓2018/03/14 (Wed) 16:05:59 T.Oide **************************************************
            ltMsg4 = Nothing
        '@↑2018/03/14 (Wed) 16:05:59 T.Oide **************************************************

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
                                
        End Try
    End Function

    '関数名：pubblnProcEventList_Sel
    '機　能：工順ﾛｯﾄｲﾍﾞﾝﾄ履歴取得
    '引　数：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrproceventlistVer   ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：ltypProcEventList      ：応答格納構造体
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/06/29 (Thu) 12:57:36 N.Kasai
    '更新日：2008/06/11 (Wed) 18:40:49 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 18:40:49 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnProcEventList_Sel(ByVal lstrSBID As String, _
                                            ByVal lstrproceventlistVer As String, _
                                            ByVal lstrLotID As String, _
                                            ByRef ltypProcEventList As ProcEventList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "工順ロットイベント履歴取得"
            pubblnProcEventList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrproceventlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrproceventlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrproceventlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypProcEventList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ｲﾍﾞﾝﾄﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrEVENT_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ｲﾍﾞﾝﾄﾘｽﾄﾃﾞｰﾀ数
                        .lngProcEventCnt = laAry.Count
                        
                        '@ｲﾍﾞﾝﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngProcEventCnt > 0 Then
                        
                            '@配列領域の確保
                            .typProcEvent = New List(Of ProcEvent)

                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typProcEventTmp As New ProcEvent

                                With typProcEventTmp
                                
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)    'ｲﾍﾞﾝﾄ日時
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)       'ｺﾒﾝﾄ
                                    Call ltMsg.getString(CPstrEMP_ID, .strEmpID)            'ﾕｰｻﾞｰID
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)        'ﾕｰｻﾞｰ名
                                End With
                                
                                .typProcEvent.Add(typProcEventTmp)

                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcEventList_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrproceventlistVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnProcProcEditStart_Upd
    '機　能：ﾌﾟﾛｾｽ編集開始
    '引　数：ltypproceditstartReq   ：要求格納
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/06/29 (Thu) 18:04:54 N.Kasai
    '更新日：2008/06/11 (Wed) 18:53:48 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 18:53:48 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnProcProcEditStart_Upd(ByRef ltypproceditstartReq As proceditstartReq) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "プロセス編集開始"
            pubblnProcProcEditStart_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypproceditstartReq
                
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
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@ｱｸｼｮﾝ
                If .strAction <> vbNullString Then
                    Call lrMsg.addString(CPstrACTION, .strAction)
                Else
                    Call lrMsg.addString(CPstrACTION, CPstrMsgNull)
                End If
               
                '@編集開始大工程
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                
                '@編集開始小工程
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                
                '@絶対工順番号(編集開始)
                If .strAbsNo <> vbNullString Then
                    Call lrMsg.addString(CPstrABS_NO, .strAbsNo)
                Else
                    Call lrMsg.addString(CPstrABS_NO, CPstrMsgNull)
                End If
                
                '@現在大工程
                If .strCurrentOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrCURRENT_OP_ID, .strCurrentOpID)
                Else
                    Call lrMsg.addString(CPstrCURRENT_OP_ID, CPstrMsgNull)
                End If
                
                '@現在小工程
                If .strCurrentStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrCURRENT_STEP_ID, .strCurrentStepID)
                Else
                    Call lrMsg.addString(CPstrCURRENT_STEP_ID, CPstrMsgNull)
                End If

            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrprocproceditstart, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcProcEditStart_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypproceditstartReq.strMsgVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnMasProcFlowList_Sel
    '機　能：ﾏｽﾀ工順ｺﾋﾟｰ表示
    '引　数：ltypMstFlowListReq ：要求構造体
    '　　　：ltypMstFlowListAns ：応答構造体
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/07/03 (Mon) 12:29:17 N.Kasai
    '更新日：2018/04/05 (Thu) 13:27:00 T.Oide
    '備　考：
    Public Function pubblnMasProcFlowList_Sel(ByRef ltypMstFlowListReq As MstFlowListReq, _
                                              ByRef ltypMstFlowListAns As ProcFlowListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim ltMsg3              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用3
        Dim ltMsg4              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用4(ﾚｼﾋﾟ選択APC)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim laAry3              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ3
        Dim laAry4              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ4(ﾚｼﾋﾟ選択APC)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ用
        Dim llngCnt3            As Integer          'ｶｳﾝﾄ用
        Dim llngCnt4            As String           'ｶｳﾝﾄ用4
        Dim strWork             As String
        
        Try
            
            pstrMessageName = "マスタ工程フロー取得"
            pubblnMasProcFlowList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            laAry3 = New TfMsgAry
            ltMsg2 = New TfMsg
            ltMsg3 = New TfMsg
            laAry4 = New TfMsgAry
            ltMsg4 = New TfMsg

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypMstFlowListReq
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@機種
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
                
                '@ｴﾝﾄﾘID
                If .strEntryID <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_ID, .strEntryID)
                Else
                    Call lrMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
                End If
                
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_procflowlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMstFlowListAns
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：工順ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrFLOW_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：工順ﾘｽﾄﾃﾞｰﾀ数
                        .lngLotProcFlowCnt = laAry.Count
                        
                        '@工順ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngLotProcFlowCnt > 0 Then
                            
                            '@配列領域を確保
                            .typLotProcFlow = New List(Of FlowList)

                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typLotProcFlowTmp As New FlowList

                                With typLotProcFlowTmp
                                
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                    Call ltMsg.getString(CPstrCONDITION_ID, .strConditionId)                    '処理条件ID
                                    Call ltMsg.getString(CPstrCONDITION_VERSION, .strConditionVersion)          '処理条件ﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrSELECT_CONDITION_ID, .strSelectConditionID)       '測定条件ｾｯﾄID
                                    Call ltMsg.getString(CPstrCOLLECTION_ID, .strCollectionID)                  '収集項目ID
                                    Call ltMsg.getString(CPstrCOLLECTION_VERSION, .strCollectionVersion)        '収集項目ﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrLOT_SCRAP_SET_ID, .strLotScrapSetID)              '不良項目ｾｯﾄID
                                    Call ltMsg.getString(CPstrREWORK_ROUTE_ID, .strReworkRouteID)               'ﾘﾜｰｸﾙｰﾄID
                                    Call ltMsg.getString(CPstrREWORK_RETURN_OP_ID, .strReworkReturnOpID)        'ﾘﾜｰｸ戻り大工程
                                    Call ltMsg.getString(CPstrREWORK_RETURN_STEP_ID, .strReworkReturnStepID)    'ﾘﾜｰｸ戻り小工程
                                    Call ltMsg.getString(CPstrSPECIAL_ROUTE_ID, .strSpecialRouteID)             '追加ﾙｰﾄID
                                    Call ltMsg.getString(CPstrSPECIAL_RETURN_OP_ID, .strSpecialReturnOpID)      '追加戻り大工程
                                    Call ltMsg.getString(CPstrSPECIAL_RETURN_STEP_ID, .strSpecialReturnStepID)  '追加戻り小工程
                                    Call ltMsg.getString(CPstrSWAP_INDICATOR, .strSwapIndicator)                '入替可能工程
                                    Call ltMsg.getString(CPstrALT_START_FLAG, .strAltStartFlag)                 '代替開始ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrALT_END_FLAG, .strAltEndFlag)                     '代替終了ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrALT_POINTER, .strAltPointer)                      '代替ﾎﾟｲﾝﾀ
                                    Call ltMsg.getString(CPstrGRB_CLASS, .strGrbClass)                          'GRB限定工程設定
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：時間制約ﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrTIME_RESTRICT_LIST, laAry2)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：時間制約ﾘｽﾄﾃﾞｰﾀ数
                                    .lngTimeOrderCnt = laAry2.Count
                                    
                                    '@時間制約ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngTimeOrderCnt > 0 Then
                                        
                                        '@配列領域の確保
                                        .typTimeOrder = New List(Of TimeOrder)
                                        
                                        '@ｶｳﾝﾀ2の初期化
                                        llngCnt2 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各ﾃﾞｰﾀ取得
                                        For Each ltMsg2 In laAry2
                                            Dim typTimeOrderTmp As New TimeOrder
                                            With typTimeOrderTmp
                                            
                                                Call ltMsg2.getString(CPstrLIST_ORDER, .strListOrder)               '時間制約
                                                Call ltMsg2.getString(CPstrSTATUS_FLAG, .strStatusFlag)             '時間制約状態ﾌﾗｸﾞ
                                                Call ltMsg2.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)    '制約ﾀｲﾌﾟ
                                            End With
                                            .typTimeOrder.Add(typTimeOrderTmp)
                                            '@ｶｳﾝﾀ2を+1する
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3格納：APCﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrAPC_LIST, laAry3)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3数：APCﾘｽﾄﾃﾞｰﾀ数
                                    .lngApcOrderCnt = laAry3.Count
                                    
                                    '@APCﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngApcOrderCnt > 0 Then
                                    
                                        '@配列領域の確保
                                        .typApcOrder = New List(Of ApcOrder)
                                        
                                        '@ｶｳﾝﾀ3の初期化
                                        llngCnt3 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ3から各ﾃﾞｰﾀ取得
                                        For Each ltMsg3 In laAry3
                                            Dim typApcOrderTmp As New ApcOrder

                                            With typApcOrderTmp
                                            
                                                Call ltMsg3.getString(CPstrLIST_ORDER, .strListOrder)               'APCｵｰﾀﾞ番号
                                                Call ltMsg3.getString(CPstrSTATUS_FLAG, .strStatusFlag)             'APC状態ﾌﾗｸﾞ
                                                Call ltMsg3.getString(CPstrAPC_TYPE, .strApcType)                   'APCﾀｲﾌﾟ
                                            End With
                                            .typApcOrder.Add(typApcOrderTmp)
                                            '@ｶｳﾝﾀ3を+1する
                                            llngCnt3 = llngCnt3 + 1
                                        Next
                                    End If
                                    
                                    Call ltMsg.getString(CPstrS_FLAG, .strSFlag)                                    '特殊特性ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrWORK_CONDITION, .strWorkCondition)                    '作業条件
                                    Call ltMsg.getString(CPstrWP_RESTRICT_KIND, .strWpRestrictKind)                 '処理号機種別(1:記憶、2:限定)
                                    Call ltMsg.getString(CPstrWP_RESTRICT_NUM, .strWpRestrictNum)                   '処理号機番号
                                    
                                    '@ﾃﾞｨｽｺﾝ
                                    Call ltMsg.getString(CPstrOP_VALID, .strOpValid)                                '大工程有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrSTEP_VALID, .strStepValid)                            '小工程有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCONDITION_VALID, .strConditionValid)                  '処理条件有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCOLLECTION_VALID, .strCollectionValid)                '収集項目有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrREWORK_ROUTE_VALID, .strReworkRouteValid)             'ﾘﾜｰｸﾙｰﾄ有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrSPECIAL_ROUTE_VALID, .strSpecialRouteValid)           '特殊ﾙｰﾄ有効ﾌﾗｸﾞ
                                    
                                    '@無機用
                                    Call ltMsg.getString(CPstrTPAL_CLASS, .strTpalClass)                            'TPAL設定
                                    Call ltMsg.getString(CPstrCARRIER_CATEGORY_ID, .strCarrierCategoryId)           'ｷｬﾘｱｶﾃｺﾞﾘID

                                    Call ltMsg.getString(CPstrMAP_USE_FLAG, .strMapUseFlag)                         'ﾏｯﾌﾟ適用ﾌﾗｸﾞ( 0:非自動適用、1:自動適用)
                                    Call ltMsg.getString(CPstrPRIORITY, .strPriority)                               '区間優先度

                                    '@TEOS F/B設定
                                    Call ltMsg.getString(CPstrAPC_TEOS_GROUP_NO, .typApcTeos.strGroupNo)            'APC TEOSグループ番号
                                    Call ltMsg.getString(CPstrAPC_TEOS_NO_IN_GROUP, .typApcTeos.strNoInGroup)       'APC TEOSグループ内番号
                                    Call ltMsg.getString(CPstrAPC_TEOS_CALC_SKIP, .typApcTeos.strCalcSkipFlag)      'APC TEOS計算スキップ
                                    Call ltMsg.getString(CPstrAPC_TEOS_FB_TYPE, .typApcTeos.strApcType)             'APC TEOS設定可否
                                
                                    '@TEOS PrismAPC設定
                                    Call ltMsg.getString(CPstrTEOS_PRISM_APC_GROUP_NO, .typTeosPrismApc.strGroupNo)         'グループ番号
                                    Call ltMsg.getString(CPstrTEOS_PRISM_APC_NO_IN_GROUP, .typTeosPrismApc.strNoInGroup)    'グループ内番号
                                    Call ltMsg.getString(CPstrTEOS_PRISM_APC_CALC_SKIP, .typTeosPrismApc.strCalcSkipFlag)   '計算スキップ
                                    Call ltMsg.getString(CPstrTEOS_PRISM_APC_TYPE, .typTeosPrismApc.strApcType)             'APCタイプ

        '@↓2018/04/05 (Thu) 13:33:07 T.Oide **************************************************
                                   '@受信ﾒｯｾｰｼﾞｱﾚｲ3の格納：ﾚｼﾋﾟ選択APCﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrRECP_SEL_APC_LIST, laAry4)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ4ﾃﾞｰﾀ数：「ﾚｼﾋﾟ選択APC」ﾘｽﾄﾃﾞｰﾀ数
                                    .lngRecpSelApcCnt = laAry4.Count
                                    
                                    '@APCﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngRecpSelApcCnt > 0 Then
                                    
                                        '@配列領域3の確保
                                        .typRecpSelApc = New List(Of ApcOrder)
                                        
                                        '@ｶｳﾝﾀの初期化
                                        llngCnt4 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ4から各ﾃﾞｰﾀ取得
                                        For Each ltMsg4 In laAry4
                                            Dim typRecpSelApcTmp As New ApcOrder
                                            With typRecpSelApcTmp
                                            
                                                Call ltMsg4.getString(CPstrLIST_ORDER, .strListOrder)       'APCｵｰﾀﾞ番号
                                                Call ltMsg4.getString(CPstrSTATUS_FLAG, .strStatusFlag)     'APC状態ﾌﾗｸﾞ
                                                Call ltMsg4.getString(CPstrAPC_TYPE, .strApcType)           'APCﾀｲﾌﾟ
                                                Call ltMsg4.getString(CPstrAPC_WF_UNIT_FLG, strWork)        '@APC枚葉設定
                                               .blnApcWfUnitFlg = CBool(strWork)
                                                
                                            End With
                                            .typRecpSelApc.Add(typRecpSelApcTmp)
                                            '@ｶｳﾝﾀを+1する
                                            llngCnt4 = llngCnt4 + 1
                                        Next
                                    End If
        '@↑2018/04/05 (Thu) 13:33:07 T.Oide **************************************************
                                                        
                                End With
                                
                                .typLotProcFlow.Add(typLotProcFlowTmp)

                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasProcFlowList_Sel = True

                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypMstFlowListReq.strMsgVer)

                    
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
            laAry2 = Nothing
            laAry3 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
        '@↓2018/04/05 (Thu) 13:30:53 T.Oide **************************************************
            laAry4 = Nothing
            ltMsg4 = Nothing
        '@↑2018/04/05 (Thu) 13:30:53 T.Oide **************************************************

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
        '@↓2018/04/05 (Thu) 13:30:53 T.Oide **************************************************
            laAry4 = Nothing
            ltMsg4 = Nothing
        '@↑2018/04/05 (Thu) 13:30:53 T.Oide **************************************************


            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnProcCondDetailList_Sel
    '機　能：ﾛｯﾄ処理条件詳細取得
    '引　数：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrprocconddetaillistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID                  ：ﾛｯﾄID
    '　　　：lstrTravelerType           ：ﾄﾗﾍﾞﾗｰﾀｲﾌﾟ(0:temp,1:real)
    '　　　：ltypProcCondDetailList     ：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/06/29 (Thu) 15:44:24 N.Kasai
    '更新日：2008/06/11 (Wed) 19:04:51 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 19:04:51 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnProcCondDetailList_Sel(ByVal lstrSBID As String, _
                                                 ByVal lstrprocconddetaillistVer As String, _
                                                 ByVal lstrLotID As String, _
                                                 ByVal lstrTravelerType As String, _
                                                 ByRef ltypProcCondDetailList As ProcCondDetailList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim llngCnt2            As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "ロット処理条件詳細取得"
            pubblnProcCondDetailList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrprocconddetaillistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrprocconddetaillistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ﾄﾗﾍﾞﾗｰﾀｲﾌﾟ(0:temp,1:real)
            If lstrTravelerType <> vbNullString Then
                Call lrMsg.addString(CPstrTRAVELER_TYPE, lstrTravelerType)
            Else
                Call lrMsg.addString(CPstrTRAVELER_TYPE, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrprocconddetaillist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypProcCondDetailList
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾚｼﾋﾟﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrRECIPE_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾚｼﾋﾟﾘｽﾄﾃﾞｰﾀ数
                        .lngProcCondDetailCnt = laAry.Count
                        
                        '@ﾚｼﾋﾟﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngProcCondDetailCnt > 0 Then
                            
                            '@配列領域の確保
                           .typProcCondDetail = New List(Of ProcCondDetail)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typProcCondDetailTmp As New ProcCondDetail

                                With typProcCondDetailTmp
                                
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程
                                    Call ltMsg.getString(CPstrWP_COMMON_RECIPE_FLAG, .strWpCommonRecipeFlag)    '装置共通ﾚｼﾋﾟﾌﾗｸﾞ
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：WPﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrWP_LIST, laAry2)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2数：WPﾘｽﾄﾃﾞｰﾀ数
                                    .lngCondDetailCnt = laAry2.Count
                                    
                                    '@WPﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngCondDetailCnt > 0 Then
                                        
                                        '@配列領域の確保
                                        .typProcCond = New List(Of ProcCond)
                                        
                                        '@ｶｳﾝﾀ2の初期化
                                        llngCnt2 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各Msg取得
                                        For Each ltMsg2 In laAry2
                                            Dim typProcCondTmp As New ProcCond
                                            With typProcCondTmp
                                                
                                                Call ltMsg2.getString(CPstrWP_ID, .strWpID)                     '装置ID
                                                Call ltMsg2.getString(CPstrWP_NAME, .strWpName)                 '装置名
                                                Call ltMsg2.getString(CPstrRECIPE_ID, .strRecipeId)             'ﾚｼﾋﾟID
                                                Call ltMsg2.getString(CPstrWF_ID, .strWfId)                     'WFID
                                                Call ltMsg2.getString(CPstrRECIPE_VERSION, .strRecipeVersion)   'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                                                Call ltMsg2.getString(CPstrCOMMENTS, .strComments)              'ｺﾒﾝﾄ
                                                Call ltMsg2.getString(CPstrSLOT_POSITION, .strSlotPosition)     'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                                              
                                            End With
                                            .typProcCond.Add(typProcCondTmp)
                                            '@ｶｳﾝﾀ2を+1する
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                End With
                                .typProcCondDetail.Add(typProcCondDetailTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcCondDetailList_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrprocconddetaillistVer)
                
                
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
            laAry2 = Nothing
            ltMsg2 = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnProcTimeLimitInfo_Sel
    '機　能：時間制約情報取得
    '引　数：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrproctimelimitinfoVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID                  ：ﾛｯﾄID
    '　　　：ltypProcTimeLimitInfo      ：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/06/29 (Thu) 15:52:10 N.Kasai
    '更新日：2008/06/11 (Wed) 19:11:34 N.Kojima
    '備　考：
    '　　　：2006/10/13 (Fri) 10:31:16 N.Kasai      応答追加(LIST_ORDER_BASE)
    '　　　：2008/06/11 (Wed) 19:11:34 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnProcTimeLimitInfo_Sel(ByVal lstrSBID As String, _
                                                ByVal lstrproctimelimitinfoVer As String, _
                                                ByVal lstrLotID As String, _
                                                ByRef ltypProcTimeLimitInfo As ProcTimeLimitInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "時間制約情報取得"
            pubblnProcTimeLimitInfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrproctimelimitinfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrproctimelimitinfoVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrproctimelimitinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    With ltypProcTimeLimitInfo
                    
                        '@受信結果取得
                        Call laMsg.getString(CPstrLIST_ORDER_BASE, .strListOrderBase)                   '時間制約番号基底値
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：時間制約ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrTIME_RESTRICT_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：時間制約ﾘｽﾄﾃﾞｰﾀ数
                        .lngProcTimeLimitCnt = laAry.Count
                        
                        '@時間制約ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngProcTimeLimitCnt > 0 Then
                            
                            '@配列領域の確保
                            .typProcTimeLimit = New List(Of ProcTimeLimit)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            For Each ltMsg In laAry
                                Dim typProcTimeLimitTmp As New ProcTimeLimit
                                With typProcTimeLimitTmp
                                
                                    Call ltMsg.getString(CPstrLIST_ORDER, .strListOrder)                '時間制約番号
                                    Call ltMsg.getString(CPstrFROM_OP_ID, .strFromOpId)                 '元大工程ID
                                    Call ltMsg.getString(CPstrTO_OP_ID, .strToOpId)                     '先大工程ID
                                    Call ltMsg.getString(CPstrFROM_STEP_ID, .strFromStepId)             '元小工程ID
                                    Call ltMsg.getString(CPstrTO_STEP_ID, .strToStepId)                 '先小工程ID
                                    Call ltMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)     '制限(制約)ﾀｲﾌﾟ名
                                    Call ltMsg.getString(CPstrWARN_TIME, .strWarnTime)                  '警告時間
                                    Call ltMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                '制限(制約)時間
                                End With
                                .typProcTimeLimit.Add(typProcTimeLimitTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcTimeLimitInfo_Sel = True

                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrproctimelimitinfoVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnProcWaferList_Sel
    '機　能：ﾛｯﾄWF情報取得
    '引　数：lstrprocwaferlistVer   ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：mtypProcWaferList      ：処理ｳｴﾊﾘｽﾄ情報
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '戻り値：True:成功、False：失敗
    '作成日：2006/08/08 (Tue) 17:44:07 N.Kasai
    '更新日：2008/10/14 (Tue) 15:54:39 M.Koni
    '備　考：
    '　　　：2008/06/11 (Wed) 19:15:58 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/10/14 (Tue) 15:54:51 M.Koni       応答ﾀｸﾞ[WAFER_RECIPE_KIND]追加。
    '　　　：                                       ltypProcWaferList をﾓｼﾞｭｰﾙ変数化。 <案件No.02871>
    Public Function pubblnProcWaferList_Sel(ByVal lstrprocwaferlistVer As String, _
                                            ByRef mtypProcWaferList As ProcWaferList, _
                                            ByVal lstrSBID As String, _
                                            ByVal lstrLotID As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim llngCnt             As Integer          'ｶｳﾝﾄ
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim llngListCnt         As Integer          'ﾘｽﾄｶｳﾝﾄ
        Dim lstrRET             As String           '応答取得
            
        Try
            
            pstrMessageName = "ロットＷＦ情報取得"
            pubblnProcWaferList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@指定ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrprocwaferlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrprocwaferlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrprocwaferlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：WFﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：WFﾘｽﾄﾃﾞｰﾀ数
                    llngListCnt = laAry.Count
                    mtypProcWaferList.lngProcWFListCnt = llngListCnt
                    
                    '@WFﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngListCnt > 0 Then
                    
                        '@配列領域の確保
                        mtypProcWaferList.typProcWFList = New List(Of ProcWFList)
                    
                        '@ｶｳﾝﾀの初期化
                        llngCnt = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry
                            Dim typProcWFListTmp As New ProcWFList

                            With typProcWFListTmp
                            
                                Call ltMsg.getString(CPstrWF_ID, .strWfId)                                  'ｳｪﾊID
                                Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)                  'ｳｪﾊｽﾛｯﾄ№
                                Call ltMsg.getString(CPstrWAFER_RECIPE_KIND, .strWaferRecipeKind)           '枚葉ﾚｼﾋﾟ設定状態
                            End With
                            mtypProcWaferList.typProcWFList.Add(typProcWFListTmp)
                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcWaferList_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrprocwaferlistVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                                      
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnProcWpRule_Sel
    '機　能：工順変更確定時ﾙｰﾙﾁｪｯｸ
    '引　数：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '戻り値：True:成功、False：失敗
    '作成日：2009/03/11 (Wed) 10:36:57 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnProcWpRuleChk_Sel(ByVal lstrprocwprulechkVer As String, _
                                            ByVal lstrSBID As String, _
                                            ByVal lstrLotID As String, _
                                            ByRef lstrJudgeFlag As String, _
                                            ByRef mtypRuleList As RuleListAns) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
        Dim llngListCnt         As Integer          'ﾘｽﾄｶｳﾝﾄ
        Dim llngCnt             As Integer          'ｶｳﾝﾄ
            
        Try
            
            pstrMessageName = "工順ルールチェック"
            pubblnProcWpRuleChk_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@指定ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrprocwprulechkVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrprocwprulechkVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrprocwprulechk, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrJUDGE_FLAG, lstrJudgeFlag)            '判定結果取得
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：WFﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrRULE_LIST, laAry)
                                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：WFﾘｽﾄﾃﾞｰﾀ数
                    llngListCnt = laAry.Count
                    
                    '@WFﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngListCnt > 0 Then
                    
                        '@配列領域の確保
                        mtypRuleList.typRuleList = New List(Of RuleList)
                    
                        '@ｶｳﾝﾀの初期化
                        llngCnt = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry
                            Dim typRuleListTmp As New RuleList

                            With typRuleListTmp
                                Call ltMsg.getString(CPstrRULE_ID, .strRuleID)      'ﾙｰﾙID
                                Call ltMsg.getString(CPstrRULE_NAME, .strRuleName)  'ﾙｰﾙ名
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)          'ﾙｰﾙ違反大工程
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)      'ﾙｰﾙ違反小工程
                                Call ltMsg.getString(CPstrJUDGE_MSG, .strJudgeMsg)  '判定結果内容
                            End With
                            mtypRuleList.typRuleList.Add(typRuleListTmp)
                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    'Call laMsg.getString(CPstrJUDGE_MSG, lstrJudeeMsg)      '判定結果ﾒｯｾｰｼﾞ取得
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcWpRuleChk_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrprocwprulechkVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                                      
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnMasApcList_Sel
    '機　能：APC情報取得
    '引　数：lstrmas_apclistVer ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：ltypApcAns         ：応答格納構造体
    '戻り値：True：成功/False：失敗
    '作成日：2006/06/29 (Thu) 16:48:20 N.Kasai
    '更新日：2008/06/11 (Wed) 19:20:43 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 19:20:43 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasApcList_Sel(ByVal lstrmas_apclistVer As String, _
                                         ByRef ltypApcAns As ApcAns) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "APC情報取得"
            pubblnMasApcList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_apclistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_apclistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_apclist_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypApcAns
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：APCﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrAPC_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：APCﾘｽﾄﾃﾞｰﾀ数
                        .lngApcListCnt = laAry.Count
                        
                        '@APCﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngApcListCnt > 0 Then
                        
                            '@配列領域の確保
                            .typApcList = New List(Of ApcList)
                            
                            '@ｶｳﾝﾀを初期化する
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typApcListTmp As New ApcList
                                Call ltMsg.getString(CPstrAPC_TYPE, typApcListTmp.strApcType)                    'APCﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrPROCESS_EQ_TYPE, typApcListTmp.strProcessEqType)       '処理装置ﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrPROCESS_WP_NAME, typApcListTmp.strProcessWpName)       '処理装置名
                                Call ltMsg.getString(CPstrMEASURE_EQ_TYPE, typApcListTmp.strMeasuerEqType)       '測定装置ﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrMEASURE_WP_NAME, typApcListTmp.strMeasuerWpName)       '測定装置名

                                .typApcList.Add(typApcListTmp)

                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasApcList_Sel = True
                    
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_apclistVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnProcProcFlowChgList_Sel
    '機　能：工順ﾌﾛｰ変更点取得
    '引　数：ltypProcFlowChgListReq ：要求
    '　　　：ltypProcFlowChgListAns ：応答
    '戻り値：True：成功/False：失敗
    '作成日：2006/07/05 (Wed) 12:58:30 N.Kasai
    '更新日：2008/06/11 (Wed) 19:24:02 N.Kojima
    '備　考：
    '　　　：2007/05/29 (Tue) 14:22:05 N.Kasai      号機限定対応(№01934)
    '　　　：2007/09/26 (Wed) 10:31:11 N.Kasai      APC対応(露光)
    '　　　：2008/06/11 (Wed) 19:24:02 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnProcProcFlowChgList_Sel(ByRef ltypProcFlowChgListReq As ProcFlowListReq, _
                                                  ByRef ltypProcFlowChgListAns As ProcFlowListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim ltMsg3              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用3
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim laAry3              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ3
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim llngCnt2            As String           'ｶｳﾝﾄ用
        Dim llngCnt3            As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "工程フロー変更点取得"
            pubblnProcProcFlowChgList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            laAry3 = New TfMsgAry
            ltMsg2 = New TfMsg
            ltMsg3 = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypProcFlowChgListReq
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If

            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrproprocflowchglist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypProcFlowChgListAns
                    
                        '@受信結果取得
                        Call laMsg.getString(CPstrCHANGE, .strChange)                   '全体変更区分
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：工順ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrPROCESS_FLOW_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：工順ﾘｽﾄﾃﾞｰﾀ数
                        .lngLotProcFlowCnt = laAry.Count
                        
                        '@工順ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngLotProcFlowCnt > 0 Then
                            
                            '@配列領域の確保
                            .typLotProcFlow = New List(Of FlowList)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typLotProcFlowTmp As New FlowList

                                With typLotProcFlowTmp

                                    Call ltMsg.getString(CPstrSTATE, .strState)                                 '状態
                                    Call ltMsg.getString(CPstrPERMIT, .strPermit)                               '編集可否
                                    Call ltMsg.getString(CPstrCHANGE, .strChange)                               '変更区分
                                    Call ltMsg.getString(CPstrABS_NO, .strAbsNo)                                '絶対工順番号
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                    Call ltMsg.getString(CPstrCONDITION_ID, .strConditionId)                    '処理条件ID
                                    Call ltMsg.getString(CPstrCONDITION_VERSION, .strConditionVersion)          '処理条件ﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrSELECT_CONDITION_ID, .strSelectConditionID)       '測定条件ｾｯﾄID
                                    Call ltMsg.getString(CPstrCOLLECTION_ID, .strCollectionID)                  '収集項目ID
                                    Call ltMsg.getString(CPstrCOLLECTION_VERSION, .strCollectionVersion)        '収集項目ﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrLOT_SCRAP_SET_ID, .strLotScrapSetID)              '不良項目ｾｯﾄID
                                    Call ltMsg.getString(CPstrREWORK_ROUTE_ID, .strReworkRouteID)               'ﾘﾜｰｸﾙｰﾄID
                                    Call ltMsg.getString(CPstrREWORK_RETURN_OP_ID, .strReworkReturnOpID)        'ﾘﾜｰｸ戻り大工程
                                    Call ltMsg.getString(CPstrREWORK_RETURN_STEP_ID, .strReworkReturnStepID)    'ﾘﾜｰｸ戻り小工程
                                    Call ltMsg.getString(CPstrSPECIAL_ROUTE_ID, .strSpecialRouteID)             '追加ﾙｰﾄID
                                    Call ltMsg.getString(CPstrSPECIAL_RETURN_OP_ID, .strSpecialReturnOpID)      '追加戻り大工程
                                    Call ltMsg.getString(CPstrSPECIAL_RETURN_STEP_ID, .strSpecialReturnStepID)  '追加戻り小工程
                                    Call ltMsg.getString(CPstrSWAP_INDICATOR, .strSwapIndicator)                '入替可能工程
                                    Call ltMsg.getString(CPstrALT_START_FLAG, .strAltStartFlag)                 '代替開始ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrALT_END_FLAG, .strAltEndFlag)                     '代替終了ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrALT_POINTER, .strAltPointer)                      '代替ﾎﾟｲﾝﾀ
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：時間制約ﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrTIME_RESTRICT_LIST, laAry2)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2数：時間制約ﾘｽﾄﾃﾞｰﾀ数
                                    .lngTimeOrderCnt = laAry2.Count
                                    
                                    '@時間制約ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngTimeOrderCnt > 0 Then
                                    
                                        '@配列領域の確保
                                        .typTimeOrder = New List(Of TimeOrder)
                                        
                                        '@ｶｳﾝﾀ2の初期化
                                        llngCnt2 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各ﾃﾞｰﾀ取得
                                        For Each ltMsg2 In laAry2
                                            Dim typTimeOrderTmp As New TimeOrder

                                            With typTimeOrderTmp
                                            
                                                Call ltMsg2.getString(CPstrLIST_ORDER, .strListOrder)               '時間制約
                                                Call ltMsg2.getString(CPstrSTATUS_FLAG, .strStatusFlag)             '時間制約状態ﾌﾗｸﾞ
                                                Call ltMsg2.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)    '制約ﾀｲﾌﾟ
                                            End With
                                            .typTimeOrder.Add(typTimeOrderTmp)
                                            '@ｶｳﾝﾀ2を+1する
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3格納：APCﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrAPC_LIST, laAry3)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3数：APCﾘｽﾄﾃﾞｰﾀ数
                                    .lngApcOrderCnt = laAry3.Count
                                    
                                    '@APCﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngApcOrderCnt > 0 Then
                                    
                                        '@配列領域の確保
                                        .typApcOrder = New List(Of ApcOrder)
                                        
                                        '@ｶｳﾝﾀ3の初期化
                                        llngCnt3 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ3から各ﾃﾞｰﾀ取得
                                        For Each ltMsg3 In laAry3
                                            Dim typApcOrderTmp As New ApcOrder

                                            With typApcOrderTmp
                                            
                                                Call ltMsg3.getString(CPstrLIST_ORDER, .strListOrder)               'APCｵｰﾀﾞ番号
                                                Call ltMsg3.getString(CPstrSTATUS_FLAG, .strStatusFlag)             'APC状態ﾌﾗｸﾞ
                                                Call ltMsg3.getString(CPstrAPC_TYPE, .strApcType)                   'APCﾀｲﾌﾟ
                                            End With
                                            .typApcOrder.Add(typApcOrderTmp)
                                            '@ｶｳﾝﾀ3を+1する
                                            llngCnt3 = llngCnt3 + 1
                                        Next
                                    End If
                                    
                                    Call ltMsg.getString(CPstrLOT_RECIPE_FLAG, .strLotRecipeFlag)                   'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrWF_RECIPE_FLAG, .strWfRecipeFlag)                     'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrS_FLAG, .strSFlag)                                    '特殊特性ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrENTRY_ID, .strEntryID)                                'ｴﾝﾄﾘｰID
                                    Call ltMsg.getString(CPstrWORK_CONDITION, .strWorkCondition)                    '作業条件
                                    Call ltMsg.getString(CPstrPROC_CHANGE_RECIPE_FLAG, .strProcChangeRecipeFlag)    '工順変更ﾚｼﾋﾟﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCOMMIT_FLAG, .strCommitFlag)                          '号機指定
                                    Call ltMsg.getString(CPstrJUDGE_SKIP_FLAG, .strJudgeSkipFlag)                   'SPC判定ｽｷｯﾌﾟﾌﾗｸﾞ( 0: SKIP不可、1:SKIP可)
                                    Call ltMsg.getString(CPstrWF_PARTIAL_RECIPE_FLAG, .strWfPartialRecipeFlag)      '枚葉ﾚｼﾋﾟ設定 ﾌﾗｸﾞ(0：全数、1:部分)
        '                            Call ltMsg.getString(CPstrAPC_TYPE, .strApcType)                                'APCﾀｲﾌﾟ
        '                            Call ltMsg.getString(CPstrLIST_ORDER, .strListOrder)                            'ﾘｽﾄｵｰﾀﾞ
        '                            Call ltMsg.getString(CPstrSTATUS_FLAG, .strStatusFlag)                          'F/B工程ﾌﾗｸﾞ(P：処理、M：測定)
                                    Call ltMsg.getString(CPstrAPC_SKIP_FLAG, .strApcSkipFlag)                       'APC適用外(0：適用、1：適用外)
                                    Call ltMsg.getString(CPstrAPC_CALC_SKIP_FLAG, .strApcCalcSkipFlag)              'APC計算除外(0：計算実施、1：計算除外)
                                    Call ltMsg.getString(CPstrWP_RESTRICT_KIND, .strWpRestrictKind)                 '装置限定 0:変更なし、1:変更あり
                                    Call ltMsg.getString(CPstrWP_RESTRICT_NUM, .strWpRestrictNum)                   '装置限定順序(SEQ)　 0:変更なし、1:変更あり
                                    
                                    '@Discon
                                    Call ltMsg.getString(CPstrOP_VALID, .strOpValid)                                '大工程有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrSTEP_VALID, .strStepValid)                            '小工程有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCONDITION_VALID, .strConditionValid)                  '処理条件有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCOLLECTION_VALID, .strCollectionValid)                '収集項目有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrREWORK_ROUTE_VALID, .strReworkRouteValid)             'ﾘﾜｰｸﾙｰﾄ有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrSPECIAL_ROUTE_VALID, .strSpecialRouteValid)           '特殊ﾙｰﾄ有効ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrTPAL_CLASS, .strTpalClass)                            'TPAL区分
                                    Call ltMsg.getString(CPstrCARRIER_CATEGORY_ID, .strCarrierCategoryId)           'ｷｬﾘｱｶﾃｺﾞﾘID
                                    
        '@↓2012/02/20 (Mon) 10:00:00 M.Sakka **************************************************
                                    Call ltMsg.getString(CPstrAPC_TEOS_CALC_SKIP, .typApcTeos.strCalcSkipFlag)      'APC TEOS計算スキップ
        '@↑2012/02/20 (Mon) 10:00:00 M.Sakka **************************************************
                                End With
                                .typLotProcFlow.Add(typLotProcFlowTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnProcProcFlowChgList_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypProcFlowChgListReq.strMsgVer)
                
                    
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
            laAry2 = Nothing
            laAry3 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnMasPcList_Sel
    '機　能：ﾌﾟﾛｾｽﾘｽﾄ取得ﾒｯｾｰｼﾞ
    '引　数：ltypMasPclistReq   ：要求構造体
    '　　　：ltypMasPclistAns   ：応答構造体
    '戻り値：True：成功/False：失敗
    '作成日：2006/07/04 (Tue) 10:09:04 N.Kasai
    '更新日：2008/06/11 (Wed) 19:31:44 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 19:31:44 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasPcList_Sel(ByRef ltypMasPclistReq As pclistreq, _
                                        ByRef ltypMasPclistAns As pclistAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "プロセスリスト取得"
            pubblnMasPcList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypMasPclistReq
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@流動ﾀｲﾌﾟ
                If .strFlowType <> vbNullString Then
                    Call lrMsg.addString(CPstrFLOW_TYPE, .strFlowType)
                Else
                    Call lrMsg.addString(CPstrFLOW_TYPE, CPstrMsgNull)
                End If
                
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_pclist__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasPclistAns

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾌﾟﾛｾｽﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrPC_LIST, laAry)

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾌﾟﾛｾｽﾘｽﾄﾃﾞｰﾀ数
                        .lngPCListCnt = laAry.Count
                        
                        '@ﾌﾟﾛｾｽﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngPCListCnt > 0 Then
                        
                            '@配列領域の確保
                            If .typPCList Is Nothing Then
                                .typPCList = New List(Of pclist)
                            Else
                                .typPCList.Clear
                            End If
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typPCListTmp As New pclist
                                Call ltMsg.getString(CPstrPC_ID, typPCListTmp.strPCID)   'ﾌﾟﾛｾｽﾘｽﾄ
                                .typPCList.Add(typPCListTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasPcList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypMasPclistReq.strMsgVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnMasCondDetailList_Sel
    '機　能：ﾏｽﾀ処理条件詳細取得
    '引　数：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrmas_conddetaillistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrConditionID            ：処理条件ID
    '　　　：lstrConditionVersion       ：処理条件ﾊﾞｰｼﾞｮﾝ
    '　　　：ltypCondDetailList         ：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/07/04 (Tue) 10:06:45 N.Kasai
    '更新日：2008/06/11 (Wed) 19:39:09 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 19:39:09 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasCondDetailList_Sel(ByVal lstrSBID As String, _
                                                ByVal lstrmas_conddetaillistVer As String, _
                                                ByVal lstrConditionID As String, _
                                                ByVal lstrConditionVersion As String, _
                                                ByRef ltypMasCondDetailList As MasCondDetailList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用

        Try

            pstrMessageName = "マスタ処理条件詳細取得"
            pubblnMasCondDetailList_Sel = False

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_conddetaillistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_conddetaillistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理条件ID
            If lstrConditionID <> vbNullString Then
                Call lrMsg.addString(CPstrCONDITION_ID, lstrConditionID)
            Else
                Call lrMsg.addString(CPstrCONDITION_ID, CPstrMsgNull)
            End If
            
            '@処理条件ﾊﾞｰｼﾞｮﾝ
            If lstrConditionVersion <> vbNullString Then
                Call lrMsg.addString(CPstrCONDITION_VERSION, lstrConditionVersion)
            Else
                Call lrMsg.addString(CPstrCONDITION_VERSION, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_conddetaillist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasCondDetailList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：WFﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrWP_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：WFﾘｽﾄﾃﾞｰﾀ数
                        .lngMasCondDetailCnt = laAry.Count
                        
                        '@WFﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngMasCondDetailCnt > 0 Then
                        
                            '@配列領域の確保
                            .typMasCondDetail = New List(Of CondDetail)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typMasCondDetailTmp As New CondDetail

                                With typMasCondDetailTmp
                                
                                    Call ltMsg.getString(CPstrWP_ID, .strWpID)                          '装置ID
                                    Call ltMsg.getString(CPstrWP_NAME, .strWpName)                      '装置名
                                    Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)                  'ﾚｼﾋﾟID
                                    Call ltMsg.getString(CPstrDEFAULT_FLAG, .strDefaultFlag)            'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrRECIPE_VERSION, .strRecipeVersion)        'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)                   'ｺﾒﾝﾄ(ﾚｼﾋﾟ)
                                End With
                                .typMasCondDetail.Add(typMasCondDetailTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                        
                        Call laMsg.getString(CPstrSKIP_FLAG, .strSkipFlag)                              'ｽｷｯﾌﾟﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLOADER_UNLOADER_FLAG, .strLoaderUnloaderFlag)         'ﾛｰﾀﾞｰｱﾝﾛｰﾀﾞｰﾌﾗｸﾞ
                        Call laMsg.getString(CPstrTRANS_MODE_NAME, .strTransModeName)                   '移載ﾓｰﾄﾞ名
                        Call laMsg.getString(CPstrWORK_CONDITION, .strWorkCondition)                    '作業条件
                        Call laMsg.getString(CPstrCOMMENTS, .strComments)                               'ｺﾒﾝﾄ
                        Call laMsg.getString(CPstrBEFORE_CARRIER_TYPE_NAME, .strBeforeCarrierTypeName)  '移載元ｷｬﾘｱ名
                        Call laMsg.getString(CPstrAFTER_CARRIER_TYPE_NAME, .strAfterCarrierTypeName)    '移載先ｷｬﾘｱ名
                        Call laMsg.getString(CPstrWP_COMMON_RECIPE_FLAG, .strWpCommonRecipeFlag)        '装置共通ﾚｼﾋﾟﾌﾗｸﾞ( 0: 個別、1: 共通)
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasCondDetailList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_conddetaillistVer)
                    

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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMasMeasureTermsList_Sel
    '機　能：WF選択条件取得
    '引　数：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrmas_measuretermslistVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypMasMeasureTermsList    ：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/07/04 (Tue) 10:07:32 N.Kasai
    '更新日：2008/06/11 (Wed) 19:43:04 N.Kojima
    '備　考：
    '　　　：2007/03/12 (Mon) 17:08:23 N.Kasai      MIDDLE_WAFERS追加
    '　　　：2008/06/11 (Wed) 19:43:04 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasMeasureTermsList_Sel(ByVal lstrSBID As String, _
                                                  ByVal lstrmas_measuretermslistVer As String, _
                                                  ByRef ltypMasMeasureTermsList As MasMeasureTermsList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "WF選択条件取得"
            pubblnMasMeasureTermsList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_measuretermslistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_measuretermslistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_measuretermslist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasMeasureTermsList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：WF選択条件ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrSELECT_CONDITION_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：WF選択条件ﾘｽﾄﾃﾞｰﾀ数
                        .lngMeasureTermsCnt = laAry.Count
                        
                        '@WF選択条件ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngMeasureTermsCnt > 0 Then
                        
                            '@配列領域の確保
                            .typMeasureTerms = New List(Of MeasureTerms)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typMeasureTermsTmp As New MeasureTerms

                                With typMeasureTermsTmp
                                
                                    Call ltMsg.getString(CPstrSELECT_CONDITION_ID, .strSelectConditionID)       '測定条件ｾｯﾄID
                                    Call ltMsg.getString(CPstrSLOTS, .strSlots)                                 'ｽﾛｯﾄ(2桁の連番でｽﾛｯﾄを表す)
                                    Call ltMsg.getString(CPstrBOTTOM_WAFERS, .strBottomWafers)                  '下からのｳｴﾊｰ枚数
                                    Call ltMsg.getString(CPstrMIDDLE_WAFERS, .strMiddleWafers)                  '真中からのｳｴﾊｰ枚数
                                    Call ltMsg.getString(CPstrTOP_WAFERS, .strTopWafers)                        '上からのｳｴﾊｰ枚数
                                    Call ltMsg.getString(CPstrUSER_SELECT_FLAG, .strUserSelectFlag)             'ﾕｰｻﾞ選択ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrSELECT_RULE_ID, .strSelectRuleID)                 '選択ﾙｰﾙID
                                End With
                                .typMeasureTerms.Add(typMeasureTermsTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasMeasureTermsList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_measuretermslistVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnMasProcCollectionList_Sel
    '機　能：収集項目取得
    '引　数：lstrSBID                       ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrmas_proccollectionlistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision              ：処理区分(1P:収集項目ID指定、2M:ｶﾃｺﾞﾘID指定)
    '　　　：ltypMasProcCollectionList      ：格納ﾃﾞｰﾀ
    '　　　：lstrCollectionID               ：収集項目ID
    '　　　：lstrCategoryID                 ：ｶﾃｺﾞﾘID
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/07/04 (Tue) 10:08:07 N.Kasai
    '更新日：2008/06/11 (Wed) 19:47:12 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 19:47:12 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasProcCollectionList_Sel(ByVal lstrSBID As String, _
                                                    ByVal lstrmas_proccollectionlistVer As String, _
                                                    ByVal lstrClassDivision As String, _
                                                    ByRef ltypMasProcCollectionList As MasProcCollectionList, _
                                                    Optional ByVal lstrCollectionID As String = vbNullString, _
                                                    Optional ByVal lstrCategoryId As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim llngCnt2            As String           'ｶｳﾝﾄ用

        Try

            pstrMessageName = "収集項目取得"
            pubblnMasProcCollectionList_Sel = False

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_proccollectionlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_proccollectionlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@収集項目ID
            If lstrCollectionID <> vbNullString Then
                Call lrMsg.addString(CPstrCOLLECTION_ID, lstrCollectionID)
            Else
                Call lrMsg.addString(CPstrCOLLECTION_ID, CPstrMsgNull)
            End If
            
            '@ｶﾃｺﾞﾘID
            If lstrCategoryId <> vbNullString Then
                Call lrMsg.addString(CPstrCATEGORY_ID, lstrCategoryId)
            Else
                Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_proccollectionlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasProcCollectionList
                        
                        '@受信結果取得
                        Call laMsg.getString(CPstrCATEGORY_ID, .strCategoryID)      'ｶﾃｺﾞﾘID
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：作業記録(装置ﾃﾞｰﾀ)ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrCOLLECTION_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：作業記録(装置ﾃﾞｰﾀ)ﾘｽﾄﾃﾞｰﾀ数
                        .lngMasProcCollectionCnt = laAry.Count
                        
                        '@作業記録(装置ﾃﾞｰﾀ)ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngMasProcCollectionCnt > 0 Then
                        
                            '@配列領域の確保
                            .typMasProcCollection = New List(Of MasProcCollection)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typMasProcCollectionTmp As New MasProcCollection

                                With typMasProcCollectionTmp
                                
                                    Call ltMsg.getString(CPstrCOLLECTION_ID, .strCollectionID)              '収集項目ID
                                    Call ltMsg.getString(CPstrCOLLECTION_VERSION, .strCollectionVersion)    '収集項目ﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrSTAT_ID, .strStatId)                          'ﾃﾞｰﾀ認定状態
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：ﾊﾟﾗﾒｰﾀﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrPARAMETER_LIST, laAry2)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2数：ﾊﾟﾗﾒｰﾀﾘｽﾄﾃﾞｰﾀ数
                                    .lngMasProcCollectionParaCnt = laAry2.Count
                                    
                                    '@ﾊﾟﾗﾒｰﾀﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                    If .lngMasProcCollectionParaCnt > 0 Then
                                    
                                        '@配列領域の確保
                                        .typMasProcCollectionPara = New List(Of MasProcCollectionPara)
                                        
                                        '@ｶｳﾝﾀ2の初期化
                                        llngCnt2 = 0
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各Msg取得
                                        For Each ltMsg2 In laAry2
                                            Dim typMasProcCollectionParaTmp As New MasProcCollectionPara

                                            With typMasProcCollectionParaTmp
                                                Call ltMsg2.getString(CPstrPARAMETER_ID, .strParameterID)           'ﾊﾟﾗﾒｰﾀID
                                            End With
                                            .typMasProcCollectionPara.Add(typMasProcCollectionParaTmp)
                                            '@ｶｳﾝﾀ2を+1する
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                End With
                                .typMasProcCollection.Add(typMasProcCollectionTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasProcCollectionList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_proccollectionlistVer)


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
            laAry2 = Nothing
            ltMsg2 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMasScrapSetIdList_Sel
    '機　能：不良項目ｾｯﾄID取得
    '引　数：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrmas_scrapsetidlistVer  ：MSGﾊﾞｰｼﾞｮﾝ
    '　　　：ltypMasScrapSetIdList      ：不良項目格納用構造体
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/07/04 (Tue) 10:08:39 N.Kasai
    '更新日：2008/06/11 (Wed) 19:56:12 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 19:56:12 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasScrapSetIdList_Sel(ByVal lstrSBID As String, _
                                                ByVal lstrmas_scrapsetidlistVer As String, _
                                                ByRef ltypMasScrapSetIdList As MasScrapSetIdList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "不良項目セットＩＤ取得"
            pubblnMasScrapSetIdList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_scrapsetidlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_scrapsetidlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_scrapsetidlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasScrapSetIdList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：不良項目ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrLOT_SCRAP_ITEM_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：不良項目ﾘｽﾄﾃﾞｰﾀ数
                        .lngMasScrapSetIDCnt = laAry.Count
                        
                        '@不良項目ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngMasScrapSetIDCnt > 0 Then
                        
                            '@配列領域の確保
                            .typMasScrapSetID = New List(Of MasScrapSetId)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typMasScrapSetIDTmp As New MasScrapSetId

                                With typMasScrapSetIDTmp
                                    Call ltMsg.getString(CPstrLOT_SCRAP_SET_ID, .strLotScrapSetID)          '不良項目ｾｯﾄID
                                End With
                                .typMasScrapSetID.Add(typMasScrapSetIDTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasScrapSetIdList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_scrapsetidlistVer)

                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnMasCategoryIdList_Sel
    '機　能：ｶﾃｺﾞﾘID取得
    '引　数：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrmas_categoryidlistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision          ：処理区分(28:大工程ID指定、20:小工程ID指定、1O:処理条件ID指定、1P:収集項目ID指定、37:ﾚｼﾋﾟID指定)
    '　　　：ltypMasCategoryIdList      ：ｶﾃｺﾞﾘ格納構造体
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/08/24 (Tue) 13:03:38 T.Kitagawa
    '更新日：2008/06/11 (Wed) 20:00:16 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 20:00:16 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasCategoryIdList_Sel(ByVal lstrSBID As String, _
                                                ByVal lstrmas_categoryidlistVer As String, _
                                                ByVal lstrClassDivision As String, _
                                                ByRef ltypMasCategoryIdList As MasCategoryIdList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "カテゴリＩＤ取得"
            pubblnMasCategoryIdList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_categoryidlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_categoryidlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_categoryidlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasCategoryIdList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ｶﾃｺﾞﾘﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrCATEGORY_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ｶﾃｺﾞﾘﾘｽﾄﾃﾞｰﾀ数
                        .lngMasCategoryIDCnt = laAry.Count
                        
                        '@ｶﾃｺﾞﾘﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngMasCategoryIDCnt > 0 Then
                        
                            '@配列領域の確保
                            .typMasCategoryID = New List(Of MasCategoryId)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typMasCategoryIDTmp As New MasCategoryId

                                With typMasCategoryIDTmp
                                    Call ltMsg.getString(CPstrCATEGORY_ID, .strCategoryID)                  'ｶﾃｺﾞﾘID
                                End With
                                .typMasCategoryID.Add(typMasCategoryIDTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasCategoryIdList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_categoryidlistVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnMasUseStepList_Sel
    '機　能：小工程ﾏｽﾀ取得
    '引　数：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrmas_usesteplistVer ：MSGﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分(02:全て、2M:ｶﾃｺﾞﾘID指定、29:小工程ID指定)
    '　　　：ltypMasStepList        ：小工程ﾘｽﾄ格納構造体
    '　　　：lstrStepID             ：小工程ID
    '　　　：lstrCategoryId         ：ｶﾃｺﾞﾘID
    '戻り値：True：正常、False：異常
    '作成日：2006/07/04 (Tue) 10:05:42 N.Kasai
    '更新日：2008/06/11 (Wed) 20:05:33 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 20:05:33 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasUseStepList_Sel(ByVal lstrSBID As String, _
                                             ByVal lstrmas_usesteplistVer As String, _
                                             ByVal lstrClassDivision As String, _
                                             ByRef ltypMasStepList As MasStepList, _
                                             Optional ByVal lstrStepID As String = vbNullString, _
                                             Optional ByVal lstrCategoryId As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "小工程マスタ取得"
            pubblnMasUseStepList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_usesteplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_usesteplistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@小工程ID
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            
            '@ｶﾃｺﾞﾘID
            If lstrCategoryId <> vbNullString Then
                Call lrMsg.addString(CPstrCATEGORY_ID, lstrCategoryId)
            Else
                Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_usesteplist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasStepList
                        
                        '@受信結果取得
                        Call laMsg.getString(CPstrCATEGORY_ID, .strCategoryID)          'ｶﾃｺﾞﾘID

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：小工程ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrSTEP_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：小工程ﾘｽﾄﾃﾞｰﾀ数
                        .lngMasStepCnt = laAry.Count
                        
                        '@小工程ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngMasStepCnt > 0 Then
                        
                            '@配列領域の確保
                            .typMasStepId = New List(Of MasStepId)
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typMasStepIdTmp As New MasStepId

                                With typMasStepIdTmp
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                      '小工程ID
                                    Call ltMsg.getString(CPstrVALID_FLAG, .strValidFlag)                '有効ﾌﾗｸﾞ
                                End With
                                .typMasStepId.Add(typMasStepIdTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasUseStepList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_usesteplistVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubblnMasConditionList_Sel
    '機　能：処理条件ｾｯﾄID取得
    '引　数：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrmas_conditionlistVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision          ：処理区分(1O:処理条件ID指定、2M:ｶﾃｺﾞﾘID指定)
    '　　　：ltypMasConditionList       ：処理条件格納用構造体
    '　　　：lstrConditionID            ：処理条件ID
    '　　　：lstrCategoryID             ：ｶﾃｺﾞﾘID
    '戻り値：True:成功、Flase：失敗
    '作成日：2006/07/04 (Tue) 10:06:03 N.Kasai
    '更新日：2018/06/25 (Mon) 17:09:38 T.Oide
    '備　考：
    '　　　：2008/06/11 (Wed) 20:09:31 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasConditionList_Sel(ByVal lstrSBID As String, _
                                               ByVal lstrmas_conditionlistVer As String, _
                                               ByVal lstrClassDivision As String, _
                                               ByRef ltypMasConditionList As MasConditionList, _
                                               Optional ByVal lstrConditionID As String = vbNullString, _
                                               Optional ByVal lstrCategoryId As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "処理条件セットＩＤ取得"
            pubblnMasConditionList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_conditionlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_conditionlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@処理条件ID
            If lstrConditionID <> vbNullString Then
                Call lrMsg.addString(CPstrCONDITION_ID, lstrConditionID)
            Else
                Call lrMsg.addString(CPstrCONDITION_ID, CPstrMsgNull)
            End If
            
            '@ｶﾃｺﾞﾘID
            If lstrCategoryId <> vbNullString Then
                Call lrMsg.addString(CPstrCATEGORY_ID, lstrCategoryId)
            Else
                Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_conditionlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasConditionList
                        
                        '@受信結果取得
                        Call laMsg.getString(CPstrCATEGORY_ID, .strCategoryID)      'ｶﾃｺﾞﾘID
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：処理条件ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrCONDITION_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：処理条件ﾘｽﾄﾃﾞｰﾀ数
                        .lngConditionCnt = laAry.Count
                        
                        '@処理条件ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngConditionCnt > 0 Then
                        
                            '@配列領域の確保
                            If .typMasCondition Is Nothing Then
                                .typMasCondition = New List(Of MasCondition)
                            Else
                                .typMasCondition.Clear
                            End If
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim typMasConditionTmp As New MasCondition

                                With typMasConditionTmp
                                
                                    Call ltMsg.getString(CPstrCONDITION_ID, .strConditionId)                    '処理条件ID
                                    Call ltMsg.getString(CPstrCONDITION_VERSION, .strConditionVersion)          '処理条件ﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrOPTION_TEXT, .strOptionText)                      '作業条件
                                    Call ltMsg.getString(CPstrSKIP_FLAG, .strSkipFlag)                          'ｽｷｯﾌﾟﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrSTAT_ID, .strStatId)                              'ﾃﾞｰﾀ認定状態
                                    Call ltMsg.getString(CPstrTRANS_MODE, .strTransMode)                        '移載ﾓｰﾄﾞ
                                    Call ltMsg.getString(CPstrLOADER_UNLOADER_FLAG, .strLoaderUnloaderFlag)     'ﾎﾟｰﾄ属性
        '@↓2018/06/25 (Mon) 17:10:59 T.Oide **************************************************
                                    Call ltMsg.getString(CPstrMAX_VER_FALSG, .strMaxVerFlag)                    'MAX_VER_FLAG
        '@↑2018/06/25 (Mon) 17:10:59 T.Oide **************************************************
                                End With
                                .typMasCondition.Add(typMasConditionTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasConditionList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_conditionlistVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：pubRecpSelApcSettingDel_chk
    '機　能：ﾚｼﾋﾟ選択APCの削除ﾁｪｯｸ
    '引　数：lngRow         ：削除対象行（工順変更流動表の行)
    '      ：lstrMsgString  ：削除時のﾒｯｾｰｼﾞ
    '戻り値：True：削除実行、False：削除中止
    '作成日：2018/03/15 (Thu) 13:20:07 T.Oide
    '更新日：2018/03/15 (Thu) 13:20:07
    '備　考：
    Public Function pubRecpSelApcSettingDel_chk(ByVal lngRow As Integer, ByVal lstrMsgString As String) As Boolean

        Dim llngMsgAns      As Integer

        Try

            '@結果の初期化
            pubRecpSelApcSettingDel_chk = False

            '@ﾚｼﾋﾟ選択APCﾁｪｯｸ
            With frmxxEN01X2.Instance.vsfFlowList0

                '@「ﾚｼﾋﾟ選択APC」設定はあるか
                If .GetData(.Row, CPlngvsfFlowRecpSelApc) <> vbNullString Then
                
                    '@処理工程か
                    If Mid$(.GetData(.Row, CPlngvsfFlowRecpSelApc), 8, 1) = CPstrProcessMark Then
                        
                        '@"<TRM148W>$$「ﾚｼﾋﾟ選択APC」の処理工程の[%1]を変更すると$「ﾚｼﾋﾟ選択APC」が解除されます。$よろしいですか?"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0148, lstrMsgString)
                        llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, "ロット工順変更", True, 16, False)
                    
                        '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                        If llngMsgAns = vbNo Then       '「いいえ」を選択(削除処理ｷｬﾝｾﾙ)
                            Exit Function
                        End If
                                       
                        '@Yesの場合、｢ﾚｼﾋﾟ選択APC｣を削除
                        Call pubRecpSelApcSettingDel(Mid$(.GetData(.Row, CPlngvsfFlowRecpSelApc), 1, 6))
                        
                    End If
                End If
            
            End With
            
            '@削除OK
            pubRecpSelApcSettingDel_chk = True
            
            Exit Function
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = "ロット工順変更"             '機能ID
                .strProcName = "pubRecpSelApcSettingDel_chk"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc
            
        End Try
    End Function
        
    '関数名：pubRecpSelApcSettingDel
    '機　能：ﾚｼﾋﾟ選択APC設定を削除する
    '引　数：lstrApc：削除するAPC設定(FF-001)
    '戻り値：
    '作成日：2018/03/15 (Thu) 12:55:28 T.Oide
    '更新日：2018/04/05 (Thu) 11:10:12 T.Oide
    '備　考：
    Public Sub pubRecpSelApcSettingDel(ByVal lstrApc As String)

        Dim llngRow         As Integer
        Dim lstrTmpString   As String

        Try
            
            With frmxxEN01X2.Instance.vsfFlowList0
                
                '@=============================
                '@測定行程の設定を見つけて削除
                '@=============================
                '@測定行程の設定値を検索用に格納
                lstrTmpString = lstrApc & CPstrHiphen & CPstrMeasureMark
                
                '@ｸﾞﾘｯﾄﾞから検索
        '@↓2018/04/05 (Thu) 11:09:39 T.Oide **************************************************
        '        llngRow = .FindRow(lstrTmpString, , CPlngvsfFlowRecpSelApc)
                llngRow = .FindRow(lstrTmpString, .Rows.Fixed, CPlngvsfFlowRecpSelApc, False, False, False)
        '@↑2018/04/05 (Thu) 11:09:39 T.Oide **************************************************
                
                '@見つからなかったら削除
                If llngRow <> -1 Then
                    '@測定行程の設定を削除
                    .SetData(llngRow, CPlngvsfFlowRecpSelApc, vbNullString)
                End If

                
                '@=============================
                '@処理行程の設定を見つけて削除
                '@=============================
                '@処理行程の設定値を検索用に格納
                lstrTmpString = lstrApc & CPstrHiphen & CPstrProcessMark
                
                '@ｸﾞﾘｯﾄﾞから検索
        '@↓2018/04/05 (Thu) 11:09:56 T.Oide **************************************************
        '        llngRow = .FindRow(lstrTmpString, , CPlngvsfFlowRecpSelApc)
                llngRow = .FindRow(lstrTmpString, .Rows.Fixed, CPlngvsfFlowRecpSelApc, False, False, False)
        '@↑2018/04/05 (Thu) 11:09:56 T.Oide **************************************************
                
                '@見つかったら削除
                If llngRow <> -1 Then
                    '@処理工程の設定を削除
                    .SetData(llngRow, CPlngvsfFlowRecpSelApc, vbNullString)
                End If
                
                
            End With
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = "ロット工順変更"              '機能ID
                .strProcName = "pubRecpSelApcSettingDel"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc
            
        End Try
    End Sub

End Module
