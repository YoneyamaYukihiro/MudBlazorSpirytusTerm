'ﾌｧｲﾙ名：xxMG0200.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程別ロット一覧(小工程別)　通信メッセージ用標準モジュール
'作成日：2004/10/20 (Wed) 14:55:08 N.Kasai
'更新日：2010/01/05 (Tue) 15:27:29 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0200
    '関数名：pubblnOpLotList_Sel
    '機　能：工程別ﾛｯﾄ一覧取得
    '引　数：ltypOpLotList      ：送信格納ﾃﾞｰﾀ
    '　　　：ltypLotList        ：受信格納ﾃﾞｰﾀ
    '　　　：llngLotListCnt     ：受信格納ﾃﾞｰﾀ数
    '戻り値：True：正常、False：異常
    '作成日：2004/10/20 (Wed) 16:26:05 Y.Yamagishi
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2004/11/05 (Fri) 17:05:12 T.Kitagawa   ﾃﾝﾌﾟﾚｰﾄ表示対応(不具合№199)　→　処理区分(27：工程別、02:全工程、3J:ﾃﾝﾌﾟﾚｰﾄ)追加
    '　　　：2005/07/21 (Thu) 16:42:26 N.Kasai      応答ﾀｸﾞ(LC_DIRECTION)追加
    '　　　：2007/05/02 (Wed) 15:32:26 N.Kasai      応答ﾀｸﾞ削除(№01902)
    '　　　：2007/11/07 (Wed) 10:38:23 N.Kasai      応答ﾀｸﾞ追加(plan_ship_date)
    '　　　：2008/06/12 (Thu) 08:43:44 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 11:38:23 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/09/30 (Wed) 12:46:03 N.Kojima     応答に"PD_ID"、"PD_VERSION"追加。(案件№03611)
    '　　　：2009/10/05 (Mon) 12:45:48 N.Kojima     応答ﾀｸﾞに"J_BATCH_ID","CF_FLAG","LP_FLAG","VA_FLAG","TPAL_CLASS"追加。(案件№03791)
    '　　　：2009/12/02 (Wed) 18:42:24 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Public Function pubblnOpLotList_Sel(ByRef ltypOpLotList As OpLotList, _
                                        ByRef ltypLotList As LotList, _
                                        ByRef llngLotListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '送信ﾒｯｾｰｼﾞ(temp)
        Dim ltMsg2              As TfMsg            '送信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry1              As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lrAry2              As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "工程別ロット一覧取得"
            pubblnOpLotList_Sel = False

            lrMsg = New TfMsg
            ltMsg1 = New TfMsg
            ltMsg2 = New TfMsg
            lrAry1 = New TfMsgAry
            lrAry2 = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@ 送信ﾀｸﾞ設定
            '@***********************
            With ltypOpLotList

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

                '@処理区分
                If .strClassDivision <> vbNullString Then
                     Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@大工程
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If

                '@小工程
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If

                '@検索開始日
                If .strStartDate <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_DATE, .strStartDate)
                Else
                    Call lrMsg.addString(CPstrSTART_DATE, CPstrMsgNull)
                End If

                '@検索終了日
                If .strEndDate <> vbNullString Then
                    Call lrMsg.addString(CPstrEND_DATE, .strEndDate)
                Else
                    Call lrMsg.addString(CPstrEND_DATE, CPstrMsgNull)
                End If

                '@機種IDﾘｽﾄ
                If .lngPdCnt > 0 Then

                    For llngCnt = 0 To .lngPdCnt - 1

                        '@機種ID
                        If .typPdList(llngCnt).strPdId <> vbNullString Then
                            Call ltMsg1.addString(CPstrPD_ID, .typPdList(llngCnt).strPdId)
                        Else
                            Call ltMsg1.addString(CPstrPD_ID, CPstrMsgNull)
                        End If

                        Call lrAry1.Add(ltMsg1)
                        ltMsg1.Clear
                    Next
                End If

                Call lrMsg.addMsgAry(CPstrPD_LIST, lrAry1)
                lrAry1.Clear

                '@流動区分(種別ID)ﾘｽﾄ
                If .lngFlowClassCnt > 0 Then

                    For llngCnt = 0 To .lngFlowClassCnt - 1

                        '@流動区分
                        If .typFlowClassList(llngCnt).strFlowClass <> vbNullString Then
                            Call ltMsg2.addString(CPstrFLOW_CLASS, .typFlowClassList(llngCnt).strFlowClass)
                        Else
                            Call ltMsg2.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                        End If

                        Call lrAry2.Add(ltMsg2)
                        ltMsg2.Clear
                    Next
                End If

                Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry2)
                lrAry2.Clear
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_oplotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    llngLotListCnt = laAry.Count

                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngLotListCnt > 0 Then

                        '@配列領域の確保
                        ltypLotList.typLotListList = New List(Of LotListList)

                        Dim ltypLotListListTmp As New LotListList

                        '@ｶｳﾝﾀの初期化
                        llngCnt = 1

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry

                            With ltypLotListListTmp

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
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   'ﾛｯﾄ位置(和名)
                                Call ltMsg.getString(CPstrLOT_COMMENTS_FLAG, .strLotCommentsFlg)            'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrTO_CARRIER_ID, .strToCarrierId)                   'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                                Call ltMsg.getString(CPstrALT_NUMBER, .strAltNumber)                        '代替番号
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               'LOT最終更新日時
                                Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸ中　0:ﾘﾜｰｸなし)
                                Call ltMsg.getString(CPstrTEMPLATE_SEQ_NUM, .strTemplateSeqNum)             'ﾃﾝﾌﾟﾚｰﾄ工順表示順序
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                    '液晶方向(L/R/Null)
                                Call ltMsg.getString(CPstrPLAN_SHIP_DATE, .strPlanShipDate)                 '送品予定日
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                         '送品先
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種ID
                                Call ltMsg.getString(CPstrPD_VERSION, .strPdVersion)                        '機種Ver
                                Call ltMsg.getString(CPstrJ_BATCH_ID, .strJBatchId)                         '蒸着ﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)                              'CFﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLP_FLAG, .strLpFlag)                              'LPﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrVA_FLAG, .strVaFlag)                              '無機ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrTPAL_CLASS, .strTpalClass)                        'TPAL区分
                                Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                              'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
                                Call ltMsg.getString(CPstrEDIT_LAST_UPDATE, .strEditLastUpdate)             '(LOT_EVENT_ID=14の)最終更新日時
                                Call ltMsg.getString(CPstrEDIT_EMP_NAME, .strEditEmpName)                   '(LOT_EVENT_ID=14の)最終更新者

                            End With

                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                            ltypLotList.typLotListList.Add(ltypLotListListTmp)
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnOpLotList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypOpLotList.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            lrAry1 = Nothing
            lrAry2 = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            lrAry1 = Nothing
            lrAry2 = Nothing
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
