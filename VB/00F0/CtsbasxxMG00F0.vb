'ﾌｧｲﾙ名：xxMG00F0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：在庫管理　通信メッセージ用標準モジュール
'作成日：2004/06/25 (Fri) 10:57:45 S.Deguchi
'更新日：2013/12/05 (Thu) 19:01:50 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00F0
    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '=========================================Public=========================================
    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '=========================================Public=========================================

    '関数名：pubblnLotAsmdivide_Ins
    '機　能：組立在庫分割予約
    '引　数：lstrlot_asmdivide_Ver  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltyplotasmdivide       ：組立在庫構造体
    '　　　：lstrDivideLotID1       ：分割先WFﾏｯﾌﾟ1のﾛｯﾄID
    '　　　：lstrDivideLotID2       ：分割先WFﾏｯﾌﾟ2のﾛｯﾄID
    '戻り値：True:OK/False:NG
    '作成日：2004/07/06 (Tue) 11:31:39 S.Deguchi
    '更新日：2008/06/11 (Wed) 16:25:09 N.Kojima
    '備　考：
    '　　　：2004/09/24 (Fri) 20:59:02 N.Kasai      分割先ｷｬﾘｱﾀｸﾞ追加
    '　　　：2004/10/14 (Thu) 10:17:11 N.Kasai      INV_LOT_LAST_UPDATE項目削除(LOT_LAST_UPDATEと一本化して管理)
    '　　　：2004/10/21 (Thu) 15:08:17 N.Kojima　   空ﾀｸﾞ挿入処理削除、Nullﾁｪｯｸ追加
    '　　　：2005/07/06 (Wed) 09:53:02 S.Deguchi    不具合№535(2058)の対応で応答Tagに"CPstrDIVIDE_LOT_ID2"を追加
    '　　　：2008/06/11 (Wed) 16:25:09 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnLotAsmdivide_Ins(ByVal lstrlot_asmdivide_Ver As String, _
                                           ByRef ltyplotasmdivide As LotAsmdivide, _
                                           ByRef lstrDivideLotID1 As String, _
                                           ByRef lstrDivideLotID2 As String) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim llngCnt1           As Integer           'ｱﾚｲｶｳﾝﾄ用
        Dim lrAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim llngCnt2           As Integer           'ｱﾚｲｶｳﾝﾄ用
        Dim lstrRET            As String            '応答取得
        
        Try
            
            '@初期化
            lrMsg = New TfMsg
            laMsg = New TfMsg
            lrAry1 = New TfMsgAry
            ltMsg1 = New TfMsg
            lrAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            
            '@初期設定
            pstrMessageName = "組立在庫分割予約"
            pubblnLotAsmdivide_Ins = False
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltyplotasmdivide
            
                '@分割元ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                    
                '@-----------------------
                '@　分割先WFﾏｯﾌﾟ1
                '@-----------------------
                If .lngDivedewfMapListCnt <> 0 Then
                
                    For llngCnt1 = 0 To .lngDivedewfMapListCnt -1
                        
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        If .typDivedeWfMapList(llngCnt1).strSlotPosition <> vbNullString Then
                            Call ltMsg1.addString(CPstrSLOT_POSITION, .typDivedeWfMapList(llngCnt1).strSlotPosition)
                        Else
                            Call ltMsg1.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                        End If
                        
                        '@WF_ID
                        If .typDivedeWfMapList(llngCnt1).strWfId <> vbNullString Then
                            Call ltMsg1.addString(CPstrWF_ID, .typDivedeWfMapList(llngCnt1).strWfId)
                        Else
                            Call ltMsg1.addString(CPstrWF_ID, CPstrMsgNull)
                        End If
                        
                        Call lrAry1.Add(ltMsg1)
                        ltMsg1.Clear
                    Next
                Else
                    ltMsg1.Clear
                End If
                Call lrMsg.addMsgAry(CPstrDIVIDE_WF_MAP_LIST, lrAry1)       '分割先WFﾏｯﾌﾟ1
                lrAry1.Clear
                
                '@-----------------------
                '@　分割先WFﾏｯﾌﾟ2
                '@-----------------------
                If .lngDivedewfMapListCnt2 <> 0 Then
                    
                    For llngCnt2 = 0 To .lngDivedewfMapListCnt2 -1
                        
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        If .typDivedeWfMapList2(llngCnt2).strSlotPosition <> vbNullString Then
                            Call ltMsg2.addString(CPstrSLOT_POSITION, .typDivedeWfMapList2(llngCnt2).strSlotPosition)
                        Else
                            Call ltMsg2.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                        End If
                        
                        '@WF_ID
                        If .typDivedeWfMapList2(llngCnt2).strWfId <> vbNullString Then
                            Call ltMsg2.addString(CPstrWF_ID, .typDivedeWfMapList2(llngCnt2).strWfId)
                        Else
                            Call ltMsg2.addString(CPstrWF_ID, CPstrMsgNull)
                        End If
                        
                        Call lrAry2.Add(ltMsg2)
                        ltMsg2.Clear
                    Next
                Else
                    ltMsg2.Clear
                End If
                Call lrMsg.addMsgAry(CPstrDIVIDE_WF_MAP_LIST2, lrAry2)      '分割先WFﾏｯﾌﾟ2
                lrAry2.Clear
                
                '@作業者ID
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
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            
                '@分割先ｷｬﾘｱID1
                If .strToCarrierID1 <> vbNullString Then
                    Call lrMsg.addString(CPstrTO_CARRIER_ID1, .strToCarrierID1)
                Else
                    Call lrMsg.addString(CPstrTO_CARRIER_ID1, CPstrMsgNull)
                End If
         
                '@分割先ｷｬﾘｱID2
                If .strToCarrierID2 <> vbNullString Then
                    Call lrMsg.addString(CPstrTO_CARRIER_ID2, .strToCarrierID2)
                Else
                    Call lrMsg.addString(CPstrTO_CARRIER_ID2, CPstrMsgNull)
                End If
            
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_asmdivide, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrDIVIDE_LOT_ID1, lstrDivideLotID1)     '分割先1ﾛｯﾄID取得
                    Call laMsg.getString(CPstrDIVIDE_LOT_ID2, lstrDivideLotID2)     '分割先2ﾛｯﾄID取得
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotAsmdivide_Ins = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_asmdivide_Ver)
                    
                    
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
            lrAry1 = Nothing
            ltMsg1 = Nothing
            lrAry2 = Nothing
            ltMsg2 = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry1 = Nothing
            ltMsg1 = Nothing
            lrAry2 = Nothing
            ltMsg2 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnLotHoldList_Sel
    '機　能：保留在庫ﾛｯﾄﾘｽﾄ取得
    '引　数：lstrlot_holdlistVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypRequestList    ：要求格納構造体
    '　　　：ltypInvAcptLotList ：保留在庫ﾛｯﾄ格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/06/28 (Mon) 16:28:54 S.Deguchi
    '更新日：2009/12/03 (Thu) 13:33:35 H.Hayashi
    '備　考：
    '　　　：2004/08/27 (Fri) 12:44:37 N.Kasai      保留ｺﾒﾝﾄ追加
    '　　　：2004/09/08 (Wed) 11:26:19 N.Kasai      LOT状態 (和名対応)ﾀｸﾞ追加
    '　　　：2004/09/13 (Mon) 20:40:57 N.Kasai      新COM対応　CPstrREASON_CODE_ID →　CPstrREASON_CODEへ変更
    '　　　：2005/08/01 (Mon) 10:07:10 N.Kasai      応答ﾒｯｾｰｼﾞにLC_DIRECTION追加
    '　　　：2005/09/12 (Mon) 14:42:05 N.Kojima     応答に"SLOT_SIZE"追加。(不具合№3047)
    '　　　：2007/01/31 (Wed) 11:26:17 N.Kasai      応答ﾀｸﾞ削除 INV_HOLD_COMMENTS(№01714)
    '　　　：2007/12/11 (Tue) 16:17:11 N.Kasai      要求ﾀｸﾞ削除(PD_LIST)
    '　　　：2008/06/11 (Wed) 11:45:26 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 15:33:04 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/12/03 (Thu) 13:33:35 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    Public Function pubblnLotHoldList_Sel(ByVal lstrlot_holdlistVer As String, _
                                          ByRef ltypRequestList As InvAcptListRequest, _
                                          ByRef ltypInvAcptLotList As InvAcptLotList) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim lstrRET            As String            '応答取得
        Dim llngCnt1           As Integer           'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg2 = New TfMsg
            lrAry2 = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry

            '@初期設定
            pstrMessageName = "保留在庫ロットリスト"
            pubblnLotHoldList_Sel = False
            If ltypInvAcptLotList.typInvAcptLot Is Nothing Then
                ltypInvAcptLotList.typInvAcptLot = New List(Of InvAcptLot)
            Else
                ltypInvAcptLotList.typInvAcptLot.Clear
            End If
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypRequestList
            
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                 
                '@種別ﾘｽﾄ
                For llngCnt1 = 0 To .lngFlowClassCnt -1
                    Call ltMsg2.addString(CPstrFLOW_CLASS_ID, .typFlowClassList(llngCnt1).strFlowClass)
                    Call lrAry2.Add(ltMsg2)
                Next
                Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry2)
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
            End With
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_holdlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_holdlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_holdlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                        
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：受入在庫ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry1)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲのｶｳﾝﾄ格納：受入在庫ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    ltypInvAcptLotList.InvAcptLotListCnt = laAry1.Count

                    '@受入在庫ﾛｯﾄﾘｽﾄが1件以上存在するか
                    If ltypInvAcptLotList.InvAcptLotListCnt > 0 Then
                    
                        '@配列領域の確保
                        Dim tyInvAcptLottmp As New InvAcptLot

                        '@ｶｳﾝﾀの初期化
                        llngCnt1 = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg1 In laAry1

                            With tyInvAcptLottmp
                                
                                '@ﾃﾞｰﾀ格納
                                Call ltMsg1.getString(CPstrCARRIER_ID, .strCarrierId)                   'ｷｬﾘｱID
                                Call ltMsg1.getString(CPstrLOT_ID, .strLotID)                           'ﾛｯﾄID
                                Call ltMsg1.getString(CPstrFLOW_CLASS, .strFlowClass)                   '流動区分
                                Call ltMsg1.getString(CPstrPD_ID, .strPdId)                             '機種名
                                Call ltMsg1.getString(CPstrWF_QUANTITY, .strWFQuantity)                 'WF枚数
                                Call ltMsg1.getString(CPstrCHIP_QUANTITY, .strChipQuantity)             'ﾁｯﾌﾟ枚数
                                Call ltMsg1.getString(CPstrSTAY_TIME, .strStayTime)                     '停滞時間
                                Call ltMsg1.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlg)               '保留ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrRECORD_TIME, .strRecordTime)                 '保留開始日時
                                Call ltMsg1.getString(CPstrEMP_ID, .strEmpID)                           '作業者
                                Call ltMsg1.getString(CPstrEMP_NAME, .strEmpName)                       '作業者名
                                Call ltMsg1.getString(CPstrREASON_CODE, .strReasonCode)                 '保留理由ID
                                Call ltMsg1.getString(CPstrREASON_NAME, .strReasonName)                 '保留理由
                                Call ltMsg1.getString(CPstrCOMMENTS, .strComments)                      'ﾛｯﾄｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrENTRY_TIME, .strEditTime)                    '最終更新日
                                Call ltMsg1.getString(CPstrLOT_PRIORITY, .strLotPriority)               '優先度
                                Call ltMsg1.getString(CPstrOP_ID, .strOpID)                             '大工程
                                Call ltMsg1.getString(CPstrSTEP_ID, .strStepID)                         '小工程
                                Call ltMsg1.getString(CPstrWP_ID, .strWpID)                             'WP_ID
                                Call ltMsg1.getString(CPstrHOLD_STAY_DATE, .strHoldStayTime)            '保留期間
                                Call ltMsg1.getString(CPstrHOLD_EMP_ID, .strHoldEmpID)                  '保留担当ID
                                Call ltMsg1.getString(CPstrHOLD_EMP_NAME, .strHoldEmpName)              '保留担当
                                Call ltMsg1.getString(CPstrWP_NAME, .strWpName)                         'WP名称
                                Call ltMsg1.getString(CPstrHOLD_TERM_DATE, .strHoldTermDate)            '保留期限
                                Call ltMsg1.getString(CPstrENTRY_ID, .strEntryID)                       'ｴﾝﾄﾘID
                                Call ltMsg1.getString(CPstrENG_EMP_ID, .strEngEmpId)                    'ﾛｯﾄ担当者ID
                                Call ltMsg1.getString(CPstrENG_EMP_NAME, .strEngEmpName)                'ﾛｯﾄ担当者名
                                Call ltMsg1.getString(CPstrNOW_ST, .strCurrentStatus)                   'LOT状態(和名対応)
                                Call ltMsg1.getString(CPstrLC_DIRECTION, .strLcDirection)               '液晶方向(L/R/Null)
                                Call ltMsg1.getString(CPstrSLOT_SIZE, .strSlotSize)                     'ｽﾛｯﾄｻｲｽﾞ
        '@↓2009/02/25 (Wed) 15:34:06 N.Kojima **************************************************
                                Call ltMsg1.getString(CPstrSEND_SB_ID, .strSendSBID)                    '送品先
        '@↑2009/02/25 (Wed) 15:34:06 N.Kojima **************************************************
        '@↓2009/12/03 (Thu) 13:34:31 H.Hayashi **************************************************
                                Call ltMsg1.getString(CPstrSB_AREA, .strSbArea)                         'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        '@↑2009/12/03 (Thu) 13:34:31 H.Hayashi **************************************************

                            End With
                            ltypInvAcptLotList.typInvAcptLot.Add(tyInvAcptLottmp)
                            '@ｶｳﾝﾀを+1する
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotHoldList_Sel = True
                  
                  
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_holdlistVer)
                    
                    
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
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnInvGetSendOrderList_Sel
    '機　能：送品伝票情報取得
    '引　数：lstrinv_GetSendOrderListVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotList()              ：ﾛｯﾄﾘｽﾄ
    '　　　：ltypGetSendOrderList       ：送品伝票情報取得構造体
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/11/26 (Fri) 11:18:24 H.Wajima
    '更新日：2013/12/05 (Thu) 19:01:38 T.Oide
    '備　考：
    '　　　：2005/01/25 (Tue) 11:39:36 H.Wajima     仕掛品ｺｰﾄﾞを追加
    '　　　：2005/02/21 (Mon) 13:44:32 S.Deguchi    ﾒｯｾｰｼﾞ構成変更による修正
    '　　　：2006/03/27 (Mon) 13:29:30 N.Kojima     種別追加に伴い、応答ﾀｸﾞに"FLOW_CLASS"追加。(ﾕｰｻﾞｰ要望№0171)
    '　　　：2008/06/11 (Wed) 16:29:42 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/12/03 (Thu) 14:18:41 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Public Function pubblnInvGetSendOrderList_Sel(ByVal lstrinv_GetSendOrderListVer As String, _
                                                  ByVal llngLotListCount As Integer, _
                                                  ByRef lstrLotList As List (Of String), _
                                                  ByRef ltypGetSendOrderList As GetSendOrderList) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim lstrRET            As String            '応答取得
        Dim llngCnt1           As Integer           'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg2 = New TfMsg
            lrAry2 = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry

            '@初期設定
            pstrMessageName = "送品伝票情報取得"
            pubblnInvGetSendOrderList_Sel = False
            If ltypGetSendOrderList.typLotList Is Nothing Then
                ltypGetSendOrderList.typLotList = New List(Of GetSendOrderListLotList)
            Else
                ltypGetSendOrderList.typLotList.Clear()
            End If
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ﾛｯﾄID
            For llngCnt1 = 0 To llngLotListCount -1
                Call ltMsg.addString(CPstrLOT_ID, lstrLotList(llngCnt1))
                Call lrAry.Add(ltMsg)
            Next
            Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)      'ﾛｯﾄﾘｽﾄ
                
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_GetSendOrderListVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_GetSendOrderListVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_getsendorderlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry1)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲのｶｳﾝﾄ格納：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    ltypGetSendOrderList.lngLotListCount = laAry1.Count

                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If ltypGetSendOrderList.lngLotListCount > 0 Then
                        
                        '@配列領域の確保
                        Dim typLotListtmp As New GetSendOrderListLotList

                        '@ｶｳﾝﾀの初期化
                        llngCnt1 = 1
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg1 In laAry1

                            With typLotListtmp
                                
                                '@ﾃﾞｰﾀ格納
                                Call ltMsg1.getString(CPstrSB_NAME, .strSBName)                         '送品元
                                Call ltMsg1.getString(CPstrATLAS_POINT, .strAtlasPoint)                 '送品元ATLASﾎﾟｲﾝﾄ
                                Call ltMsg1.getString(CPstrSEND_SB_NAME, .strSendSBName)                '送品先
                                Call ltMsg1.getString(CPstrSEND_ATLAS_POINT, .strSendAtlasPoint)        '送品先ATALASﾎﾟｲﾝﾄ
                                Call ltMsg1.getString(CPstrEMP_NAME, .strEmpName)                       '送品担当
                                Call ltMsg1.getString(CPstrSEND_DATE, .strSendDate)                     '送品日
                                Call ltMsg1.getString(CPstrLOT_ID, .strLotID)                           'ﾛｯﾄID
                                Call ltMsg1.getString(CPstrBOX_NO, .strBoxNo)                           '箱№
                                Call ltMsg1.getString(CPstrFLOW_CLASS, .strFlowClass)                   '種別
                                Call ltMsg1.getString(CPstrWF_QUANTITY, .strWFQuantity)                 'WF枚数
                                Call ltMsg1.getString(CPstrCHIP_QUANTITY, .strChipQuantity)             'ﾁｯﾌﾟ枚数
                                Call ltMsg1.getString(CPstrPD_ID, .strPdId)                             '機種ID

                                Call ltMsg1.getString(CPstrEXT_PART_CODE, .strExtPartCode)              '仕掛品ｺｰﾄﾞ
                                Call ltMsg1.getString(CPstrATLAS_ORDER_NO, .strAtlasOrderNo)            'ATLASｵｰﾀﾞｰ№
                                Call ltMsg1.getString(CPstrINV_COMMENTS, .strInvComments)               '送品時ｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrSB_AREA, .strSbArea)                         'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
                                
                            End With
                            ltypGetSendOrderList.typLotList.Add(typLotListtmp)
                            '@ｶｳﾝﾀを+1する
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnInvGetSendOrderList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrinv_GetSendOrderListVer)
                    

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
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnInvGetLotExamInfo_Sel
    '機　能：ﾛｯﾄ検定表情報取得
    '引　数：lstrinv_GetLotExamInfoVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：llngLotID                  ：ﾛｯﾄID
    '　　　：ltypGetLotExamInfo         ：ﾛｯﾄ検定表情報取得構造体
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/11/26 (Fri) 16:00:51 H.Wajima
    '更新日：2008/06/11 (Wed) 16:33:17 N.Kojima
    '備　考：
    '　　　：2005/02/21 (Mon) 14:11:23 S.Deguchi    仕掛品ｺｰﾄﾞ追加
    '　　　：2006/03/27 (Mon) 13:29:30 N.Kojima     種別追加に伴い、応答ﾀｸﾞに"FLOW_CLASS"追加。(ﾕｰｻﾞｰ要望№0171)
    '　　　：2008/06/11 (Wed) 16:33:17 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnInvGetLotExamInfo_Sel(ByVal lstrinv_GetLotExamInfoVer As String, _
                                                ByRef lstrLotID As String, _
                                                ByRef ltypGetLotExamInfo As GetLotExamInfo) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim lstrRET            As String            '応答取得
        Dim llngCnt1           As Integer           'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg2 = New TfMsg
            lrAry2 = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry

            '@初期設定
            pstrMessageName = "ロット検定表情報取得"
            pubblnInvGetLotExamInfo_Sel = False
            If IsNothing(ltypGetLotExamInfo.typWFList) Then
                ltypGetLotExamInfo.typWFList = New List(Of GetLotExamInfoWFList)()
            Else
                ltypGetLotExamInfo = New GetLotExamInfo
                ltypGetLotExamInfo.typWFList = New List(Of GetLotExamInfoWFList)()
            End If

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ﾛｯﾄID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_GetLotExamInfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_GetLotExamInfoVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_getlotexaminfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞ取得
                    With ltypGetLotExamInfo
                    
                        .strLotID = lstrLotID                                                       'ﾛｯﾄID
                        
                        Call laMsg.getString(CPstrBOX_NO, .strBoxNo)                                '箱№
                        Call laMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '種別
                        Call laMsg.getString(CPstrWF_QUANTITY, .strWFQuantity)                      '送品WF数
                        Call laMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                  '送品ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrPD_ID, .strPdId)                                  '機種
                        Call laMsg.getString(CPstrATLAS_ORDER_NO, .strAtlasOrderNo)                 'ATLASｵｰﾀﾞｰ№
                        Call laMsg.getString(CPstrSEND_DATE, .strSendDate)                          '送品日
                        Call laMsg.getString(CPstrSEND_SB_NAME, .strSendSBName)                     '送品先SB名
                        Call laMsg.getString(CPstrWF_THROWIN_DATE, .strWFThrowinDate)               'WF投入日
                        Call laMsg.getString(CPstrWF_THROWIN_QUANTITY, .strWFThrowinQuantity)       '投入WF数
                        Call laMsg.getString(CPstrWF_FINISH_DATE, .strWFFinishDate)                 'WF完成日
                        Call laMsg.getString(CPstrWF_FINISH_QUANTITY, .strWFFinishQuantity)         '完成WF数
                        Call laMsg.getString(CPstrWF_OUT_QUANTITY, .strWFOutQuantity)               '不良WF数
                        Call laMsg.getString(CPstrWF_ISSUE_QUANTITY, .strWFIssueQuantity)           '払出WF数
                        Call laMsg.getString(CPstrCHIP_THROWIN_QUANTITY, .strChipThrowinQuantity)   '投入ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrCHIP_OUT_QUANTITY, .strChipOutQuantity)           '不良ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrGOOD_CHIP_RATIO, .strGoodChipRatio)               '組立歩留率
                        Call laMsg.getString(CPstrINV_COMMENTS, .strInvComments)                    '次SB連絡ｺﾒﾝﾄ
                        Call laMsg.getString(CPstrEXT_PART_CODE, .strExtPartCode)                   '仕掛品ｺｰﾄﾞ
                    End With
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：WFﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrWF_LIST, laAry1)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲのｶｳﾝﾄ格納：WFﾘｽﾄﾃﾞｰﾀ数
                    ltypGetLotExamInfo.lngWFListCount = laAry1.Count

                    '@WFﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If ltypGetLotExamInfo.lngWFListCount > 0 Then
                    
                        '@配列領域の確保
                        Dim typWfListTmp As New GetLotExamInfoWFList

                        '@ｶｳﾝﾀの初期化
                        llngCnt1 = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg1 In laAry1
                        
                            '@受信結果取得
                            With typWfListTmp
                                
                                '@ﾃﾞｰﾀ格納
                                Call ltMsg1.getString(CPstrWF_ID, .strWfId)                             'WFID
                                Call ltMsg1.getString(CPstrCHIP_QUANTITY, .strChipQuantity)             'ﾁｯﾌﾟ数
                            End With
                            ltypGetLotExamInfo.typWfList.Add(typWfListTmp)
                            '@ｶｳﾝﾀを+1する
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnInvGetLotExamInfo_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrinv_GetLotExamInfoVer)
                    

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
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnInvChgComm_Upd
    '機　能：次SB連絡ｺﾒﾝﾄ登録
    '引　数：lstrinv_chgcmmentVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：lstrEmpID              ：作業者ID
    '　　　：lstrInvComments        ：次SB連絡ｺﾒﾝﾄ
    '　　　：lstrLotLastUpdate      ：ﾛｯﾄ最終更新日
    '戻り値：True：成功、False：失敗
    '作成日：2004/11/26 (Fri) 18:54:06 H.Wajima
    '更新日：2008/06/11 (Wed) 16:57:31 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 16:57:31 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnInvChgComm_Upd(ByVal lstrinv_chgcmmentVer As String, _
                                         ByVal lstrLotID As String, _
                                         ByVal lstrEmpID As String, _
                                         ByVal lstrInvComments As String, _
                                         ByRef lstrLotLastUpdate As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
            
        Try

            pstrMessageName = "次SB連絡コメント登録"
            pubblnInvChgComm_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
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
            
            '@作業者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄｺﾒﾝﾄ
            If lstrInvComments <> vbNullString Then
                Call lrMsg.addString(CPstrINV_COMMENTS, lstrInvComments)
            Else
                Call lrMsg.addString(CPstrINV_COMMENTS, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄ最終更新日時
            If lstrLotLastUpdate <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)
            Else
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_chgcmmentVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_chgcmmentVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_chgcomm_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)   'ﾛｯﾄ最終更新日時
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnInvChgComm_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrinv_chgcmmentVer)
                
                
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

    '関数名：pubblnInvCFForward_Upd
    '機　能：CF在庫払出処理
    '引　数：ltypInvCFForward   ：要求構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/12/27 (Mon) 11:28:38 S.Deguchi
    '更新日：2012/01/12 (Thu) 15:10:27 T.Oide
    '備　考：
    Public Function pubblnInvCFForward_Upd(ByRef ltypInvCFForward As InvCFForward) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
            
        Try

            pstrMessageName = "CF在庫払出登録"
            pubblnInvCFForward_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypInvCFForward
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
        '@↓2012/01/12 (Thu) 15:10:46 T.Oide **************************************************
                '@払出理由ｺｰﾄﾞ
                If .strEventClass <> vbNullString Then
                    Call lrMsg.addString(CPstrEVENT_CLASS, .strEventClass)
                Else
                    Call lrMsg.addString(CPstrEVENT_CLASS, CPstrMsgNull)
                End If
        '@↑2012/01/12 (Thu) 15:10:46 T.Oide **************************************************
                
                '@払出理由ｺｰﾄﾞ
                If .strReasonCode <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_CODE, .strReasonCode)
                Else
                    Call lrMsg.addString(CPstrREASON_CODE, CPstrMsgNull)
                End If
                
                '@払出理由名
                If .strReasonName <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_NAME, .strReasonName)
                Else
                    Call lrMsg.addString(CPstrREASON_NAME, CPstrMsgNull)
                End If
                
                '@ﾁｯﾌﾟ数
                If .strChipNum <> vbNullString Then
                    Call lrMsg.addString(CPstrCHIP_NUM, .strChipNum)
                Else
                    Call lrMsg.addString(CPstrCHIP_NUM, CPstrMsgNull)
                End If
                
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
            
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_cfforward, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnInvCFForward_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypInvCFForward.strMsgVer)
                    
                
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

    '関数名：pubblnInvCFLotInfo_Sel
    '機　能：CFﾛｯﾄ情報取得
    '引　数：ltypInvCFLotInfo       ：要求構造体
    '　　　：ltypInvCFLotInfoList   ：応答構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/12/27 (Mon) 11:39:44 S.Deguchi
    '更新日：2008/06/11 (Wed) 17:05:33 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 17:05:33 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnInvCFLotInfo_Sel(ByRef ltypInvCFLotInfo As InvCFLotInfo, _
                                           ByRef ltypInvCFLotInfoList As InvCFLotInfoList) As Boolean

        Dim lrMsg               As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry               As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim lstrRET             As String            '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "CFロット情報取得"
            pubblnInvCFLotInfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypInvCFLotInfo
                
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
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

            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_cflotinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypInvCFLotInfoList
                    
                        '@受信ﾒｯｾｰｼﾞ取得
                        Call laMsg.getString(CPstrREWORK_COUNT, .strReworkCount)                    'CFﾘﾜｰｸ数
                        Call laMsg.getString(CPstrREGENERATION_COUNT, .strRegenerationCount)        '最大ﾘﾜｰｸ数
                                
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：板厚ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrTHICKNESS_LIST, laAry)
            
                        '@受信ﾒｯｾｰｼﾞｱﾚｲのｶｳﾝﾄ格納：板厚ﾘｽﾄﾃﾞｰﾀ数
                        .lngThicknessCnt = laAry.Count

                        '@板厚ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngThicknessCnt > 0 Then
                            
                            '@配列領域の確保
                            .typThicknessList = New List(Of ThicknessList)

                            Dim typThicknessListTmp As New ThicknessList

                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                
                                '@ﾃﾞｰﾀ格納
                                Call ltMsg.getString(CPstrTHICKNESS_CODE, typThicknessListTmp.strThicknessCode)   '板厚ｺｰﾄﾞ
                                .typThicknessList.Add(typThicknessListTmp)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnInvCFLotInfo_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypInvCFLotInfo.strMsgVer)
                
                    
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

    '関数名：pubblnInvCFRework_Upd
    '機　能：CF在庫ﾘﾜｰｸ登録
    '引　数：ltypInvRework  ：要求構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/12/27 (Mon) 12:12:17 S.Deguchi
    '更新日：2008/06/11 (Wed) 17:10:32 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 17:10:32 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnInvCFRework_Upd(ByRef ltypInvRework As InvRework) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim lstrRET            As String            '応答取得
        Dim llngCnt            As Integer           'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@初期設定
            pstrMessageName = "CF在庫リワーク登録"
            pubblnInvCFRework_Upd = False
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypInvRework
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
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
                
                '@板厚ﾘｽﾄ/ﾁｯﾌﾟ数
                If .lngThicknessCnt <> 0 Then
                
                    For llngCnt = 0 To .lngThicknessCnt -1
                        
                        Call ltMsg.addString(CPstrTHICKNESS_CODE, .typCFReowrkThickness(llngCnt).strThicknessCode)  '板厚
                        Call ltMsg.addString(CPstrCHIP_NUM, .typCFReowrkThickness(llngCnt).strChipNum)              'ﾁｯﾌﾟ数
                        
                        Call lrAry.Add(ltMsg)
                    Next
                    
                    '@板厚ﾘｽﾄ/ﾁｯﾌﾟ数
                    Call lrMsg.addMsgAry(CPstrTHICKNESS_LIST, lrAry)
                End If
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_cfrework, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnInvCFRework_Upd = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypInvRework.strMsgVer)

                
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
            lrAry = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnlotCancelSend_Upd
    '機　能：ﾛｯﾄ送品取消
    '引　数：ltypSendCancelList ：在庫ﾛｯﾄ送品取消格納ﾃﾞｰﾀ
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/11/29 (Mon) 10:56:52 H.Wajima
    '更新日：2008/06/11 (Wed) 17:12:59 N.Kojima
    '備　考：
    '　　　：2005/03/23 (Wed) 13:05:18 S.Deguchi    送品取消の処理を修正の為ﾒｯｾｰｼﾞ全面改訂
    '　　　：2008/06/11 (Wed) 17:12:59 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnlotCancelSend_Upd(ByRef ltypSendCancelList As SendCancelList) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得

        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@初期設定
            pstrMessageName = "ロット送品取消"
            pubblnlotCancelSend_Upd = False

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypSendCancelList
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
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
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cancelsend, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnlotCancelSend_Upd = True
                    
           
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypSendCancelList.strMsgVer)

                    
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

    '関数名：pubblnlotSend_Upd
    '機　能：ﾛｯﾄ送品処理
    '引　数：ltypLotSendReq ：要求ﾃﾞｰﾀ
    '戻り値：True:正常終了、False:異常終了
    '作成日：2007/03/30 (Fri) 09:47:34 N.Kasai
    '更新日：2008/06/11 (Wed) 17:15:34 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 17:15:34 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnlotSend_Upd(ByRef ltypLotSendReq As LotSendReq) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得

        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@初期設定
            pstrMessageName = "ロット送品"
            pubblnlotSend_Upd = False

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotSendReq
            
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@送品先ID
                If .strSendSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSEND_SB_ID, .strSendSBID)
                Else
                    Call lrMsg.addString(CPstrSEND_SB_ID, CPstrMsgNull)
                End If
                
                '@箱№
                If .strBoxNo <> vbNullString Then
                    Call lrMsg.addString(CPstrBOX_NO, .strBoxNo)
                Else
                    Call lrMsg.addString(CPstrBOX_NO, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If pstrSBID = vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_send____, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnlotSend_Upd = True
                    
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypLotSendReq.strMsgVer)
                    
                    
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
End Module
