'ﾌｧｲﾙ名：xxMG00M0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：バッチ管理　通信MSG用標準モジュール
'作成日：2004/07/22 (Thu) 11:02:47 T.Kitagawa
'更新日：2019/06/10 (Mon) 09:51:59 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00M0
    '関数名：pubblnLotMcGpLotList_Sel
    '機　能：装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ取得
    '引　数：lstrlot_mcgplotlistVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrMcGroupID          ：装置ｸﾞﾙｰﾌﾟID
    '　　　：lstrClassDivision      ：処理区分（2T：ﾌﾟﾛﾀﾞｸﾄﾛｯﾄ、2Z：ﾓﾆﾀｰﾛｯﾄ)
    '　　　：ltypMcGpLotInfo        ：装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体
    '戻り値：True：正常、False：異常
    '作成日：2004/07/22 (Thu) 11:18:43 T.Kitagawa
    '更新日：2009/07/24 (Fri) 11:16:15 N.Kojima
    '備　考：
    '　　　：2004/09/09 (Thu) 14:50:47 Y.Yamagishi  応答ﾀｸﾞに警告時間追加
    '　　　：2004/09/26 (Sun) 12:49:36 Y.Yamagishi  応答ﾀｸﾞに制限ﾀｲﾌﾟ追加
    '　　　：2004/10/18 (Mon) 14:19:20 N.Kasai      応答ﾀｸﾞにﾘﾜｰｸﾌﾗｸﾞ追加
    '　　　：2005/09/13 (Tue) 11:00:13 T.Kitagawa   応答ﾀｸﾞに処理予定日時を追加
    '　　　：2009/06/08 (Mon) 10:09:49 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/24 (Fri) 11:16:15 N.Kojima     無機対応Phase2、応答ﾀｸﾞに"USE_ID"追加。(案件№03661)
    Public Function pubblnLotMcGpLotList_Sel(ByVal lstrlot_mcgplotlistVer As String, _
                                             ByVal lstrSBID As String, _
                                             ByVal lstrMcGroupID As String, _
                                             ByVal lstrClassDivision As String, _
                                             ByRef ltypMcGpLotInfo As McGpLotInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim ltMsg3              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用3
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim laAry3              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ3
        Dim lstrRET             As String           '応答取得

        Try

            pstrMessageName = "装置グループ仕掛ロット取得"
            pubblnLotMcGpLotList_Sel = False

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry3 = New TfMsgAry
            ltMsg3 = New TfMsg

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_mcgplotlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_mcgplotlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@装置ｸﾞﾙｰﾌﾟID
            If lstrMcGroupID <> vbNullString Then
                Call lrMsg.addString(CPstrMC_GROUP_ID, lstrMcGroupID)
            Else
                Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
            End If

            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_mcgplotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypMcGpLotInfo.lngMcGpLotListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypMcGpLotInfo.lngMcGpLotListCnt > 0 Then

                        '@構造体初期化
                        If ltypMcGpLotInfo.typMcGpLotList Is Nothing Then
                            ltypMcGpLotInfo.typMcGpLotList = New List(Of McGpLotList)
                        Else
                            ltypMcGpLotInfo.typMcGpLotList.Clear()
                        End If

                        For Each ltMsg In laAry
                            Dim ltypMcGpLotListtmp = New McGpLotList

                            '@受信結果取得
                            With ltypMcGpLotListtmp

                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                                Call ltMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                        '制限時間(時間制約)
                                Call ltMsg.getString(CPstrWF_QUANTITY, .strWFQuantity)                      'WF枚数
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                Call ltMsg.getMsgAry(CPstrWP_LIST, laAry2)                                  'WPﾘｽﾄ

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                .lngMcGpLotWpListCnt = laAry2.Count

                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                '@配列があればﾃﾞｰﾀ格納
                                If .lngMcGpLotWpListCnt > 0 Then

                                    '@構造体初期化
                                    .typMcGpLotWpList = New List(Of McGpLotWpList)

                                    For Each ltMsg2 In laAry2
                                        Dim typMcGpLotWpListtmp = New McGpLotWpList
                                        '@受信結果取得
                                        With typMcGpLotWpListtmp
                                            Call ltMsg2.getString(CPstrWP_ID, .strWpID)                     'WPID
                                            Call ltMsg2.getString(CPstrWP_NAME, .strWpName)                 'WP名
                                        End With
                                        .typMcGpLotWpList.Add(typMcGpLotWpListtmp)
                                    Next
                                End If

                                Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)                          'ﾚｼﾋﾟID
                                Call ltMsg.getString(CPstrOPTION_TEXT, .strOptionText)                      '作業条件
                                Call ltMsg.getString(CPstrCURRENT_STATUS, .strCurrentStatusID)              '現在状態ID
                                Call ltMsg.getString(CPstrCURRENT_STATUS_NAME, .strCurrentStatusName)       '現在状態名
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               '最終更新日
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                                Call ltMsg.getString(CPstrFLOW_CLASS_NAME, .strFlowClassName)               '流動区分名
                                Call ltMsg.getString(CPstrUSE_ID, .strUseId)                                '機種区分
                                Call ltMsg.getString(CPstrTO_OP_ID, .strToOpId)                             '制限時間先大工程
                                Call ltMsg.getString(CPstrTO_STEP_ID, .strToStepId)                         '制限時間先小工程
                                Call ltMsg.getString(CPstrWARN_TIME, .strWarnTime)                          '警告時間
                                Call ltMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)             '制限ﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrDISPATCH_START_TIME, .strDispatchStartTime)       '処理予定日時
                                Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)                              'CFﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLP_FLAG, .strLpFlag)                              'LPﾌﾗｸﾞ
        '@↓2019/05/16 (Thu) 14:05:02 Y.Yoneyama **************************************************
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種
                                Call ltMsg.getString(CPstrVA_FLAG, .strVaFlag)                              '無機ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrJ_BATCH_ID, .strJBatchId)                         '蒸着ﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrH_BATCH_ID, .strHBatchId)                         '表面処理ﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrINSPECT_ONLINE_FLAG, .strInspectFlag)             '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrJ_BATCH_PAIR_CARRIER, .strPairCarrier)            '対ｷｬﾘｱ
        '@↑2019/05/16 (Thu) 14:05:02 Y.Yoneyama **************************************************

                                Call ltMsg.getMsgAry(CPstrWF_LIST, laAry3)                                  'WFﾘｽﾄ

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                .lngMcGpLotWFListCnt = laAry3.Count

                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                '@配列があればﾃﾞｰﾀ格納
                                If .lngMcGpLotWFListCnt > 0 Then

                                    '@構造体初期化
                                    .typMcGpLotWFList = New List(Of WfList)

                                    For Each ltMsg3 In laAry3
                                        Dim WfListtmp = New WfList
                                        '@受信結果取得
                                        With WfListtmp
                                            Call ltMsg3.getString(CPstrWF_ID, .strWfId)                     'WFID
                                            Call ltMsg3.getString(CPstrPALETTE_ID, .strjigId)               '冶具ID(WAFER.PALETTE_IDに格納されるらしい)
                                        End With
                                        .typMcGpLotWFList.Add(WfListtmp)
                                    Next
                                End If
                            End With
                            ltypMcGpLotInfo.typMcGpLotList.Add(ltypMcGpLotListtmp)

                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotMcGpLotList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_mcgplotlistVer)


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

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnBatChange_Upd
    '機　能：ﾊﾞｯﾁ組ﾛｯﾄ登録変更
    '引　数：lstrbat_changeVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrClassDivision  ：処理区分（空白：新規、05：削除、06：変更)
    '　　　：ltypBatChange      ：ﾊﾞｯﾁ組ﾛｯﾄ登録変更構造体
    '　　　：lstrBatchID        ：応答ﾊﾞｯﾁID
    '　　　：lstrGuidMsg        ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode    ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/07/22 (Thu) 16:29:57 T.Kitagawa
    '更新日：009/06/15 (Mon) 10:15:58 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 13:15:38 N.Kojima     空ﾀｸﾞ挿入処理削除
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2009/06/15 (Mon) 10:15:58 N.Kojima     無機対応。各種送信MSG追加。(案件№03560)
    Public Function pubblnBatChange_Upd(ByVal lstrbat_change__Ver As String, _
                                        ByVal lstrSBID As String, _
                                        ByVal lstrClassDivision As String, _
                                        ByRef ltypBatChange As BatChange, _
                                        ByRef lstrBatchID As String, _
                                        ByRef lstrGuidMsg As String, _
                                        ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "バッチ組ロット登録変更"
            pubblnBatChange_Upd = False

            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatChange

                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrbat_change__Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrbat_change__Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If lstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, lstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@処理区分
                If lstrClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@ﾊﾞｯﾁID
                If .strBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrBATCH_ID, .strBatchId)
                Else
                    Call lrMsg.addString(CPstrBATCH_ID, CPstrMsgNull)
                End If

                '@ﾛｯﾄ情報ｾｯﾄ
                If .lngBatChangeLotListCnt > 0 Then

                    llngCnt = 0

                    Do While .lngBatChangeLotListCnt > llngCnt

                        With .typBatChangeLotList(llngCnt)

                            '@ﾊﾞｯﾁ順序
                            If .strSeqNum <> vbNullString Then
                                Call ltMsg.addString(CPstrSEQ_NUM, .strSeqNum)
                            Else
                                Call ltMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)
                            End If

                            '@ｷｬﾘｱID
                            If .strCarrierId <> vbNullString Then
                                Call ltMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                            Else
                                Call ltMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                            End If

                            '@冶具ID
                            If .strjigId <> vbNullString Then
                                Call ltMsg.addString(CPstrJIG_ID, .strjigId)
                            Else
                                Call ltMsg.addString(CPstrJIG_ID, CPstrMsgNull)
                            End If

                            '@ﾛｯﾄID
                            If .strLotID <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_ID, .strLotID)
                            Else
                                Call ltMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                            End If

                            '@LOT最終更新日時
                            If .strLotLastUpdate <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                            Else
                                Call ltMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                            End If

                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱID
                            If .strUldCarrierID <> vbNullString Then
                                Call ltMsg.addString(CPstrUNLOADER_CARRIER_ID, .strUldCarrierID)
                            Else
                                Call ltMsg.addString(CPstrUNLOADER_CARRIER_ID, CPstrMsgNull)
                            End If

                            '@WFID
                            If .strWfId <> vbNullString Then
                                Call ltMsg.addString(CPstrWF_ID, .strWfId)
                            Else
                                Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                            End If

                            '@ﾊﾟﾈﾙ種類
                            If .strPanelKind <> vbNullString Then
                                Call ltMsg.addString(CPstrPANEL_KIND, .strPanelKind)
                            Else
                                Call ltMsg.addString(CPstrPANEL_KIND, CPstrMsgNull)
                            End If

                            '@蒸着処理条件
                            If .strVaConditionID <> vbNullString Then
                                Call ltMsg.addString(CPstrVA_CONDITION_ID, .strVaConditionID)
                            Else
                                Call ltMsg.addString(CPstrVA_CONDITION_ID, CPstrMsgNull)
                            End If

                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear
                            llngCnt = llngCnt + 1
                        End With
                    Loop
                Else
                    ltMsg.Clear
                End If

                Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
                lrAry.Clear

                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If

                '@装置ﾀｲﾌﾟ(EQ_TYPE)
                If .strEqType <> vbNullString Then
                    Call lrMsg.addString(CPstrEQ_TYPE, .strEqType)
                Else
                    Call lrMsg.addString(CPstrEQ_TYPE, CPstrMsgNull)
                End If

                '@ﾚｼﾋﾟID
                If .strRecipeId <> vbNullString Then
                    Call lrMsg.addString(CPstrRECIPE_ID, .strRecipeId)
                Else
                    Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
                End If

                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If

            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_change__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信結果取得
                    Call laMsg.getString(CPstrBATCH_ID, lstrBatchID)            'ﾊﾞｯﾁID
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                 'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)        'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnBatChange_Upd = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrbat_change__Ver)


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

    '関数名：pubblnMasVaCondition_Sel
    '機　能：蒸着処理条件情報取得
    '引　数：lstrmas_vaconditionVer ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrRecipeID           ：ﾚｼﾋﾟID
    '　　　：lstrWPID               ：装置ID
    '　　　：ltypVaConditionListAns ：蒸着処理条件格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2009/06/08 (Mon) 14:56:17 N.Kojima
    '更新日：2009/11/17 (Tue) 19:33:35 N.Kojima
    '備　考：
    '　　　：2009/11/17 (Tue) 19:33:35 N.Kojima     応答ﾀｸﾞに"VA_CONDITION_FLAG"追加。(案件№03790)
    Public Function pubblnMasVaCondition_Sel(ByVal lstrmas_vaconditionVer As String, _
                                             ByVal lstrSBID As String, _
                                             ByVal lstrRecipeID As String, _
                                             ByVal lstrWpId As String, _
                                             ByRef ltypVaConditionListAns As VaConditionListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "蒸着処理条件取得"
            pubblnMasVaCondition_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_vaconditionVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_vaconditionVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@ﾚｼﾋﾟID
            If lstrRecipeID <> vbNullString Then
                Call lrMsg.addString(CPstrRECIPE_ID, lstrRecipeID)
            Else
                Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
            End If

            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_vacondition, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：蒸着処理条件ﾘｽﾄ(ｽﾛｯﾄﾘｽﾄ)
                    Call laMsg.getMsgAry(CPstrSLOT_LIST, laAry)

                    With ltypVaConditionListAns

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納：蒸着処理条件ﾃﾞｰﾀ数
                        .lngVaConditionListCnt = laAry.Count

                        '@蒸着処理条件ﾃﾞｰﾀ数が1件以上存在するか
                        If .lngVaConditionListCnt > 0 Then

                            '@格納配列の領域確保
                            .typVaConditionList = New List(Of VaConditionList)

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            For Each ltMsg In laAry
                                Dim VaConditionListtmp = New VaConditionList
                                '@受信結果取得
                                With VaConditionListtmp

                                    Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)                      '順序(処理部№)
                                    Call ltMsg.getString(CPstrPANEL_KIND, .strPanelKind)                'ﾊﾟﾈﾙ種類(0：TFT、1：CF)
                                    Call ltMsg.getString(CPstrVA_CONDITION_ID, .strVaConditionID)       '蒸着処理条件
        '@↓2009/11/17 (Tue) 19:01:30 N.Kojima **************************************************
                                    Call ltMsg.getString(CPstrVA_CONDITION_FLAG, .strVaConditionFlag)   '蒸着処理条件制限ﾌﾗｸﾞ(1：有効、0：無効)
        '@↑2009/11/17 (Tue) 19:01:30 N.Kojima **************************************************
                                End With
                                .typVaConditionList.Add(VaConditionListtmp)
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnMasVaCondition_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_vaconditionVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

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
