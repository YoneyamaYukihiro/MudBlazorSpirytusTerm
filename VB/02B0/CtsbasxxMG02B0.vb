'ﾌｧｲﾙ名：xxMG02B0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット情報一括変更　通信メッセージ用標準モジュール
'作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
'更新日：2011/10/05 (Wed) 11:20:53 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02B0
    '関数名：pubblnOpLotList2_Sel
    '機　能：ﾛｯﾄ一覧情報(MSG[大工程ﾛｯﾄ検索一覧]実行)
    '引　数：ltypOpLotList      ：送信格納ﾃﾞｰﾀ
    '　　　：ltypOpLotListAns   ：受信格納ﾃﾞｰﾀ
    '　　　：llngOpLotListCnt   ：受信格納ﾃﾞｰﾀ数
    '戻り値：True：取得成功、False：取得失敗
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2013/01/30 (Wed) 13:48:33 Y.Yoneyama
    '備　考：
    '　　　：2008/06/12 (Thu) 15:08:51 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/09/30 (Wed) 12:46:03 N.Kojima     応答に"PD_ID"、"PD_VERSION"追加。(案件№03611)
    '　　　：2009/10/05 (Mon) 12:45:48 N.Kojima     応答ﾀｸﾞに"J_BATCH_ID","CF_FLAG","LP_FLAG","VA_FLAG","TPAL_CLASS"追加。(案件№03791)
    '　　　：2009/12/02 (Wed) 21:06:42 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    '　　　：2011/10/05 (Wed) 11:20:53 T.Oide       R8-4区間優先対応<REQ-1109>
    '　　　：2013/01/30 (Wed) 13:48:33 Y.Yoneyama   ﾛｯﾄ進捗管理対応
    Public Function pubblnOpLotList2_Sel(ByRef ltypOpLotList As OpLotList, _
                                         ByRef ltypOpLotListAns As OpLotListAns, _
                                         ByRef llngOpLotListCnt As Integer) As Boolean

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

            '@各種初期設定
            pstrMessageName = "ロット一覧情報取得"
            pubblnOpLotList2_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            ltMsg2 = New TfMsg
            lrAry1 = New TfMsgAry
            lrAry2 = New TfMsgAry
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
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

                '在庫フラグ
                If .strInventoryFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrINVENTORY_FLAG, .strInventoryFlag)
                Else
                    Call lrMsg.addString(CPstrINVENTORY_FLAG, CPstrMsgNull)
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
                    Next llngCnt
                End If

                '@機種IDﾘｽﾄ追加
                Call lrMsg.addMsgAry(CPstrPD_LIST, lrAry1)
                lrAry1.Clear


                '@流動区分(種別ID)ﾘｽﾄ
                If .lngFlowClassCnt > 0 Then

                    For llngCnt = 0 To .lngFlowClassCnt - 1

                        '@種別
                        If .typFlowClassList(llngCnt).strFlowClass <> vbNullString Then
                            Call ltMsg2.addString(CPstrFLOW_CLASS, .typFlowClassList(llngCnt).strFlowClass)
                        Else
                            Call ltMsg2.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                        End If

                        Call lrAry2.Add(ltMsg2)
                        ltMsg2.Clear
                    Next
                End If

                '@種別ﾘｽﾄ追加
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
                    llngOpLotListCnt = laAry.Count

                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngOpLotListCnt > 0 Then

                        '@配列領域の確保
                        ltypOpLotListAns.typOpLotListList = New List(Of OpLotListList)(llngOpLotListCnt)

                        '@ｶｳﾝﾀの初期化
                        llngCnt = 1

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry

                            Dim ltypOpLotListListTmp As New OpLotListList

                            With ltypOpLotListListTmp

                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                Call ltMsg.getString(CPstrALT_NUMBER, .strAltNumber)                        '代替番号
                                Call ltMsg.getString(CPstrNOW_ST, .strNowST)                                'ﾛｯﾄ状態
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                     'ﾛｯﾄ担当
                                Call ltMsg.getString(CPstrWF_NUM, .strWfNum)                                'WF枚数
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                  'ﾁｯﾌﾟ
                                Call ltMsg.getString(CPstrLOT_COMMENTS_FLAG, .strLotCommentsFlg)            'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                   'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)                   'ﾛｯﾄ停止ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                                Call ltMsg.getString(CPstrSECTION_PRIORITY_FLAG, .strSecPriorityFlag)       '区間優先度ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   'ﾛｯﾄ位置(和名)
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               'LOT最終更新日時
                                Call ltMsg.getString(CPstrTEMPLATE_SEQ_NUM, .strTemplateSeqNum)             'ﾃﾝﾌﾟﾚｰﾄ工順表示順序
                                Call ltMsg.getString(CPstrTO_CARRIER_ID, .strToCarrierId)                   'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                                Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸ中　0:ﾘﾜｰｸなし)
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                    '液晶方向(L/R/Null)
                                Call ltMsg.getString(CPstrPLAN_SHIP_DATE, .strPlanShipDate)                 '送品予定日
                                Call ltMsg.getString(CPstrPLAN_FINISH_DATE, .strPlanFinishDate)             '完成予定日
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                         '送品先SBID
                                Call ltMsg.getString(CPstrSEND_SB_NAME, .strSendSBName)                     '送品先名
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
                                Call ltMsg.getString(CPstrPLAN_ASS_THROWIN_DATE, .strPlanAssembleThrowinDate)
                                                                                                            '組立投入予定日
                                Call ltMsg.getString(CPstrSHIP_DIFF_DAY, .strShipDiffDay)                   '進捗度
                            End With

                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1

                            ltypOpLotListAns.typOpLotListList.Add(ltypOpLotListListTmp)
                        Next
                    End If

                    '@戻り値に"True：取得成功"をｾｯﾄ
                    pubblnOpLotList2_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypOpLotList.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
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

    '関数名：pubblnLotChgAttributes_Upd
    '機　能：ﾛｯﾄ情報一括変更(MSG[ﾛｯﾄ情報変更(複数)]実行)
    '引　数：ltypLotchgAttributes  ：要求ﾃﾞｰﾀ
    '戻り値：True：更新成功、False：更新失敗
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2013/01/31 (Thu) 15:52:53 Y.Yoneyama
    '備　考：
    '　　　：2008/06/12 (Thu) 15:55:19 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    '　　　：2013/01/31 (Thu) 15:52:53 Y.Yoneyama   組立投入日対応
    Public Function pubblnLotChgAttributes_Upd(ByRef ltypLotchgAttributes As LotchgAttributes, _
                                               ByRef llngLotCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '送信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry1              As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@各種初期設定
            pstrMessageName = "ロット情報一括変更"
            pubblnLotChgAttributes_Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            lrAry1 = New TfMsgAry

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotchgAttributes

                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@作業ﾒﾓ
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

                '在庫フラグ
                If .strInventoryFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrINVENTORY_FLAG, .strInventoryFlag)
                Else
                    Call lrMsg.addString(CPstrINVENTORY_FLAG, CPstrMsgNull)
                End If

                '@ﾛｯﾄﾘｽﾄ
                If llngLotCnt > 0 Then

                    For llngCnt = 0 To llngLotCnt - 1

                        '@ﾛｯﾄID
                        If .typChgAttrList(llngCnt).strLotID <> vbNullString Then
                            Call ltMsg1.addString(CPstrLOT_ID, .typChgAttrList(llngCnt).strLotID)
                        Else
                            Call ltMsg1.addString(CPstrLOT_ID, CPstrMsgNull)
                        End If

                        '@送品予定日
                        If .typChgAttrList(llngCnt).strLotPlanShipDate <> vbNullString Then
                            Call ltMsg1.addString(CPstrLOT_PLAN_SHIP_DATE, .typChgAttrList(llngCnt).strLotPlanShipDate)
                        Else
                            Call ltMsg1.addString(CPstrLOT_PLAN_SHIP_DATE, CPstrMsgNull)
                        End If

                        '@組立投入予定日
                        If .typChgAttrList(llngCnt).strLotPlanAssThrowDate <> vbNullString Then
                            Call ltMsg1.addString(CPstrPLAN_ASS_THROWIN_DATE, .typChgAttrList(llngCnt).strLotPlanAssThrowDate)
                        Else
                            Call ltMsg1.addString(CPstrPLAN_ASS_THROWIN_DATE, CPstrMsgNull)
                        End If

                        '@優先度
                        If .typChgAttrList(llngCnt).strLotPriority <> vbNullString Then
                            Call ltMsg1.addString(CPstrLOT_PRIORITY, .typChgAttrList(llngCnt).strLotPriority)
                        Else
                            Call ltMsg1.addString(CPstrLOT_PRIORITY, CPstrMsgNull)
                        End If

                        '@完成予定日
                        If .typChgAttrList(llngCnt).strLotPlanFinishDate <> vbNullString Then
                            Call ltMsg1.addString(CPstrPLAN_FINISH_DATE, .typChgAttrList(llngCnt).strLotPlanFinishDate)
                        Else
                            Call ltMsg1.addString(CPstrPLAN_FINISH_DATE, CPstrMsgNull)
                        End If

                        Call lrAry1.Add(ltMsg1)
                        ltMsg1.Clear
                    Next llngCnt

                    '@ﾛｯﾄﾘｽﾄ追加
                    Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry1)
                End If
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chgattributes, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotChgAttributes_Upd = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypLotchgAttributes.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            lrAry1 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            lrAry1 = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function
End Module
