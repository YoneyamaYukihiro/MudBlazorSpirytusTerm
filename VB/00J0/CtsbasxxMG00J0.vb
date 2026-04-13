'ﾌｧｲﾙ名：xxMG00J0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧　通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/07/13 (Tue) 09:55:39 N.Kasai
'更新日：2009/10/13 (Tue) 18:42:31 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00J0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public==========================================
    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：pubblnLotMcallLotList_Sel
    '機　能：装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ取得
    '引　数：lstrlot_mcalllotlistVer：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrMcGroupID          ：装置ｸﾞﾙｰﾌﾟID
    '　　　：ltypMcLotList          ：装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ構造体
    '戻り値：True：正常、False：異常
    '作成日：2004/07/16 (Fri) 10:04:19 N.Kasai
    '更新日：2009/12/02 (Wed) 17:52:07 H.Hayashi
    '備　考：
    '　　　：2004/09/26 (Sun) 12:52:02 Y.Yamagishi　応答ﾀｸﾞに制限ﾀｲﾌﾟ追加
    '　　　：2004/10/18 (Mon) 12:53:47 N.Kasai      応答ﾀｸﾞにREWORK_FLAGを追加
    '　　　：2005/03/03 (Thu) 11:24:37 N.Kojima     応答ﾀｸﾞにstrToCarrierID等追加(改善№512)
    '　　　：2005/07/21 (Thu) 13:48:36 N.Kasai      応答ﾀｸﾞにLC_DIRECTION追加
    '　　　：2007/07/11 (Wed) 10:26:59 N.Kasai      不要ﾀｸﾞ削除(№01998)
    '　　　：2009/02/25 (Wed) 11:14:39 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/08/24 (Mon) 14:22:10 N.Kojima     応答ﾀｸﾞに"PD_ID"、"PD_VERSION"追加。(案件№03611)
    '　　　：2009/10/05 (Mon) 12:45:48 N.Kojima     応答ﾀｸﾞに"J_BATCH_ID","CF_FLAG","LP_FLAG","VA_FLAG","TPAL_CLASS"追加。(案件№03791)
    '　　　：2009/12/02 (Wed) 17:52:07 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    Public Function pubblnLotMcallLotList_Sel(ByVal lstrlot_mcalllotlistVer As String, _
                                            ByVal lstrSBID As String, _
                                            ByVal lstrMcGroupID As String, _
                                            ByRef ltypMcLotList As McLotList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "装置グループロットリスト"
            pubblnLotMcallLotList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@装置ｸﾞﾙｰﾌﾟID
            If lstrMcGroupID <> vbNullString Then
                Call lrMsg.addString(CPstrMC_GROUP_ID, lstrMcGroupID)
            Else
                Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
            End If
            
            '@SB_ID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_mcalllotlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_mcalllotlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_mcalllotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
                
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypMcLotList.lngMcLotListCnt = laAry.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypMcLotList.lngMcLotListCnt > 0 Then
                        
                        '@構造体初期化
                        'ReDim ltypMcLotList.typMcLotList(ltypMcLotList.lngMcLotListCnt)
                        'llngCnt = 1
                        ltypMcLotList.typMcLotList = New List(Of McLot)
                        
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim typMcLotListTmp As McLot = New McLot
                            
                            '@受信結果取得
                            With typMcLotListTmp
                                
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                Call ltMsg.getString(CPstrNOW_ST, .strNowST)                                'ﾛｯﾄ状態
                                Call ltMsg.getString(CPstrDISPATCH_START_TIME, .strDispatchStartTime)       '投入予定時刻
                                Call ltMsg.getString(CPstrWF_NUM, .strWfNum)                                'WF枚数
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                  'ﾁｯﾌﾟ
                                Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                   'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)                   'ﾛｯﾄ停止ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                                Call ltMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                        '制限時間(時間制約)
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   '現在位置名
                                Call ltMsg.getString(CPstrTO_OP_ID, .strToOpId)                             '制限時間先大工程
                                Call ltMsg.getString(CPstrTO_STEP_ID, .strToStepId)                         '制限時間先小工程
                                Call ltMsg.getString(CPstrWARN_TIME, .strWarnTime)                          '警告時間
                                Call ltMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)             '制限ﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸ中　0:ﾘﾜｰｸなし)
                                Call ltMsg.getString(CPstrTO_CARRIER_ID, .strToCarrierId)                   'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                                Call ltMsg.getString(CPstrALT_NUMBER, .strAltNumber)                        '代替番号
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                    'L/R表示
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                         '送品先
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種
                                Call ltMsg.getString(CPstrPD_VERSION, .strPdVersion)                        '機種Ver
        '@↓2009/10/13 (Tue) 14:31:57 N.Kojima **************************************************
                                Call ltMsg.getString(CPstrJ_BATCH_ID, .strJBatchId)                         '蒸着ﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)                              'CFﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLP_FLAG, .strLpFlag)                              'LPﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrVA_FLAG, .strVaFlag)                              '無機ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrTPAL_CLASS, .strTpalClass)                        'TPAL区分
        '@↑2009/10/13 (Tue) 14:31:57 N.Kojima **************************************************
        '@↓2009/12/02 (Wed) 17:50:13 H.Hayashi **************************************************
                                Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                              'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        '@↑2009/12/02 (Wed) 17:50:13 H.Hayashi **************************************************

                            End With

                            'NSYS 編集済み構造体追加
                            ltypMcLotList.typMcLotList.Add(typMcLotListTmp)
                            
                            'llngCnt = llngCnt + 1
                        
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotMcallLotList_Sel = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_mcalllotlistVer)
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞを表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
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
            
            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

End Module
