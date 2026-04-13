'ﾌｧｲﾙ名：xxMG02T0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Aｷｬﾘｱ管理共通ﾓｼﾞｭｰﾙ
'作成日：2018/09/27 (Thu) 17:17:17 Y.Yoneyama
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02T0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '@ACarrierClass
    Public Const CPstrACarProductMoniOff        As String = "0"
    Public Const CPstrACarProductMoniOn         As String = "1"
    Public Const CPstrACarDummyMoniOff          As String = "2"
    Public Const CPstrACarDummyMoniOn           As String = "3"
    Public Const CPstrACarQuality               As String = "4"
    Public Const CPstrACarMonitor               As String = "5"

    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubstrToACarrierClass_Sel
    '機　能：Aキャリア区分変換
    '引　数：lstrBatchFlowClass  : ALDﾊﾞｯﾁ情報(BATCH_FLOW_CLASS)
    '      ：lstrMonitorUseFlag  : ALDﾊﾞｯﾁ情報(MONITOR_USE_FLAG)
    '戻り値：True:成功/Flase：失敗
    '作成日：2018/10/04 (Thu) 13:59:54 Y.Yoneyama
    '更新日：2018/10/04 (Thu) 13:59:54 Y.Yoneyama
    '備　考：
    Public Function pubstrToACarrierClass_Sel(ByVal lstrBatchFlowClass As String, _
                                              ByVal lstrMonitorUseFlag As String) As String
        
        Try

            '@初期設定
            pubstrToACarrierClass_Sel = vbNullString
            
            '@------------------
            '@PRODUCT
            '@------------------
            If lstrBatchFlowClass = UCase(CPstrProduct) And lstrMonitorUseFlag = CPstrFlagOff Then
                
                pubstrToACarrierClass_Sel = CPstrACarProductMoniOff

            '@------------------
            '@PRODUCT&MONITOR
            '@------------------
            ElseIf lstrBatchFlowClass = UCase(CPstrProduct) And lstrMonitorUseFlag = CPstrFlagOn Then
                
                pubstrToACarrierClass_Sel = CPstrACarProductMoniOn

            '@------------------
            '@QUALITY
            '@------------------
            ElseIf lstrBatchFlowClass = UCase(CPstrQuality) And lstrMonitorUseFlag = CPstrFlagOff Then
                
                pubstrToACarrierClass_Sel = CPstrACarQuality
                    
            End If
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnACarrierStatus_Sel
    '機　能：Aキャリア状態取得
    '引　数：lstrMsgVer         : Msgﾊﾞｰｼﾞｮﾝ
    '      ：lstrACarrierID     : AｷｬﾘｱID
    '      ：ltypACarrierState  : Msg送信用ｵﾌﾞｼﾞｪｸﾄ
    '戻り値：True:成功/Flase：失敗
    '作成日：2018/10/04 (Thu) 13:59:54 Y.Yoneyama
    '更新日：2018/10/04 (Thu) 13:59:54 Y.Yoneyama
    '備　考：
    Public Function pubblnACarrierStatus_Sel(ByVal lstrMsgVer As String, _
                                             ByVal lstrACarrierID As String, _
                                             ByRef ltypACarrierState As ACarrierState) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "Aキャリア状態取得"
            pubblnACarrierStatus_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrACarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrA_CARRIER_ID, lstrACarrierID)
            Else
                Call lrMsg.addString(CPstrA_CARRIER_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarracarstat, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    With ltypACarrierState
                        Call laMsg.getString(CPstrA_CARRIER_ID, .strACarrierId)
                        Call laMsg.getString(CPstrCARRIER_STAT_ID, .strACarrierStatId)
                        Call laMsg.getString(CPstrA_CARRIER_CLASS, .strACarrierClass)
                        Call laMsg.getString(CPstrEMPTY_FLAG, .strEmptyFlag)
                        Call laMsg.getString(CPstrCLEAN_FLAG, .strCleanFlag)
                        Call laMsg.getString(CPstrCLEAN_COUNT, .strCleanCount)
                        Call laMsg.getString(CPstrWASH_USE_NUM, .strWashUseNum)
                        Call laMsg.getString(CPstrWASH_USE_LIMIT, .strWashUseLimit)
                        Call laMsg.getString(CPstrUSE_NUM, .strUseNum)
                        Call laMsg.getString(CPstrUSE_LIMIT, .strUseLimit)
                        Call laMsg.getString(CPstrTAPE_STICK_BATCH_ID, .strTapeStickBatchId)
                        Call laMsg.getString(CPstrOVEN_BATCH_ID, .strOvenBatchId)
                        Call laMsg.getString(CPstrALD_BATCH_ID, .strAldBatchId)
                    End With

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrA_TRAY_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲAﾄﾚｲ数
                    ltypACarrierState.lngATrayListCnt = laAry.Count
                    
                    If ltypACarrierState.lngATrayListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲAﾄﾚｲ数から各Msg取得
                        If ltypACarrierState.typAtrayList Is Nothing Then
                           ltypACarrierState.typAtrayList = New List(Of ATrayList)
                        Else 
                            ltypACarrierState.typAtrayList.Clear 
                        End If
                        For Each ltMsg In laAry
                            '@受信結果取得
 
                            Dim typAtrayListRec As ATrayList
                            typAtrayListRec = New ATrayList

                            With typAtrayListRec
                                Call ltMsg.getString(CPstrA_TRAY_ID, .strAtrayId)
                                Call ltMsg.getString(CPstrA_TRAY_STATUS, .strAtrayStatus)
                                Call ltMsg.getString(CPstrA_TRAY_STATUS_NAME, .strAtrayStatusName)
                                Call ltMsg.getString(CPstrA_TRAY_CLASS, .strAtrayClass)
                                Call ltMsg.getString(CPstrTAPE_STICK_GROUP, .strTapeStickGroup)
                                Call ltMsg.getString(CPstrWASH_USE_NUM, .strWashUseNum)
                                Call ltMsg.getString(CPstrWASH_USE_LIMIT, .strWashUseLimit)
                                Call ltMsg.getString(CPstrUSE_NUM, .strUseNum)
                                Call ltMsg.getString(CPstrUSE_LIMIT, .strUseLimit)
                                Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)          'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                                Call ltMsg.getString(CPstrCLEAN_COUNT, .strCleanCount)              '洗浄回数
                            End With

                            ltypACarrierState.typAtrayList.Add(typAtrayListRec)

                        Next
                    End If
                    
                    '@受信ﾒｯｾｰｼﾞﾊﾟｰﾂｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrPART_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞﾊﾟｰﾂｱﾚｲ数
                    ltypACarrierState.typAtrayUsePart.lngAldPartCnt = laAry.Count
                    
                    If ltypACarrierState.typAtrayUsePart.lngAldPartCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        If ltypACarrierState.typAtrayUsePart.typeAldPart Is Nothing Then
                            ltypACarrierState.typAtrayUsePart.typeAldPart = New List(Of typALDPart) 
                        Else 
                            ltypACarrierState.typAtrayUsePart.typeAldPart.Clear 
                        End If
                        For Each ltMsg In laAry
                            '@受信結果取得

                            Dim typeAldPartRec As typALDPart
                            typeAldPartRec = New typALDPart

                            With typeAldPartRec
                                Call ltMsg.getString(CPstrVENDER_CLASS_ID, .strVenderClassId)
                                Call ltMsg.getString(CPstrVENDER_CLASS_NAME, .strVenderClassName)
                                Call ltMsg.getString(CPstrVENDER_ID, .strVenderId)
                                Call ltMsg.getString(CPstrVENDER_NAME, .strVenderName)
                                Call ltMsg.getString(CPstrPART_CODE, .strPartCode)
                                Call ltMsg.getString(CPstrPART_NAME, .strPartName)
                                Call ltMsg.getString(CPstrINV_LOT_ID, .strLotID)
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQty)
                                Call ltMsg.getString(CPstrPRODUCTION_LOT_ID, .strProdcLotId)
                            End With

                            ltypACarrierState.typAtrayUsePart.typeAldPart.Add(typeAldPartRec)

                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnACarrierStatus_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
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

    '関数名：pubblnACarrierChangeATray_Upd
    '機　能：Aｷｬﾘｱに紐付くAﾄﾚｲ変更
    '引　数：lstrMsgVer         : Msgﾊﾞｰｼﾞｮﾝ
    '      ：ltypACarrierState  : Msg送信用ｵﾌﾞｼﾞｪｸﾄ
    '戻り値：True:成功/Flase：失敗
    '作成日：2009/06/09 (Tue) 17:05:04 K.Nishizawa
    '更新日：2019/12/04 (Wed) 12:59:44 T.Oide
    '備　考：
    Public Function pubblnACarrierChangeATray_Upd(ByVal lstrMsgVer As String, _
                                                  ByRef ltypACarrierState As ACarrierState) As Boolean

        Dim lrMsg               As TfMsg
        Dim lrMsg2              As TfMsg
    '@↓2019/12/04 (Wed) 12:59:05 T.Oide **************************************************
        Dim lrMsg3              As TfMsg
    '@↑2019/12/04 (Wed) 12:59:05 T.Oide **************************************************
        Dim lrAry               As TfMsgAry
    '@↓2019/12/04 (Wed) 12:59:29 T.Oide **************************************************
        Dim lrAry2              As TfMsgAry
    '@↑2019/12/04 (Wed) 12:59:29 T.Oide **************************************************

        Dim laMsg               As TfMsg
        Dim lstrRET             As String
        Dim llngCnt             As Integer

        Try
            
            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
        '@↓2019/12/04 (Wed) 13:02:30 T.Oide **************************************************
            lrMsg3 = New TfMsg
        '@↑2019/12/04 (Wed) 13:02:30 T.Oide **************************************************
            laMsg = New TfMsg
            lrAry = New TfMsgAry
        '@↓2019/12/04 (Wed) 13:03:03 T.Oide **************************************************
            lrAry2 = New TfMsgAry
        '@↑2019/12/04 (Wed) 13:03:03 T.Oide **************************************************

            pstrMessageName = "Aｷｬﾘｱに紐付くAﾄﾚｲ変更"
            
            pubblnACarrierChangeATray_Upd = False
            
            With ltypACarrierState
            
                '@Msg_Ver取得
                If lstrMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                        
                '@AｷｬﾘｱID取得
                If .strACarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrA_CARRIER_ID, .strACarrierId)
                Else
                    Call lrMsg.addString(CPstrA_CARRIER_ID, CPstrMsgNull)
                End If
                
                '@Aｷｬﾘｱ区分取得
                If .strACarrierClass <> vbNullString Then
                    Call lrMsg.addString(CPstrA_CARRIER_CLASS, .strACarrierClass)
                Else
                    Call lrMsg.addString(CPstrA_CARRIER_CLASS, CPstrMsgNull)
                End If
                
                '@作業者ID取得
                If pstrUserID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                  
                '@Aﾄﾚｰの属性情報
                For llngCnt = 0 To .lngATrayListCnt - 1
                
                    '@AﾄﾚｰID
                    If .typAtrayList(llngCnt).strAtrayId <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_TRAY_ID, .typAtrayList(llngCnt).strAtrayId)
                    Else
                        Call lrMsg2.addString(CPstrA_TRAY_ID, CPstrMsgNull)
                    End If
                    
                    '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                    If .typAtrayList(llngCnt).strSlotPosition <> vbNullString Then
                        Call lrMsg2.addString(CPstrSLOT_POSITION, .typAtrayList(llngCnt).strSlotPosition)
                    Else
                        Call lrMsg2.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                    End If
                    

        '@↓2019/11/26 (Tue) 18:07:31 T.Oide **************************************************あとで見直し
        '@            '@利用部材
        '@            If .typAtrayList(llngCnt).strPartCode <> vbNullString Then
        '@                Call lrMsg2.addString(CPstrPART_CODE, .typAtrayList(llngCnt).strPartCode)
        '@            Else
        '@                Call lrMsg2.addString(CPstrPART_CODE, CPstrMsgNull)
        '@            End If
        '@
        '@            '@在庫ﾛｯﾄID
        '@            If .typAtrayList(llngCnt).strInvLotId <> vbNullString Then
        '@                Call lrMsg2.addString(CPstrINV_LOT_ID, .typAtrayList(llngCnt).strInvLotId)
        '@            Else
        '@                Call lrMsg2.addString(CPstrINV_LOT_ID, CPstrMsgNull)
        '@            End If
        '@
        '@            '@製造ﾛｯﾄID
        '@            If .typAtrayList(llngCnt).strProductionLotId <> vbNullString Then
        '@                Call lrMsg2.addString(CPstrPRODUCTION_LOT_ID, .typAtrayList(llngCnt).strProductionLotId)
        '@            Else
        '@                Call lrMsg2.addString(CPstrPRODUCTION_LOT_ID, CPstrMsgNull)
        '@            End If
        '@
        '@
        '@            '@ﾁｯﾌﾟ数量
        '@            If .typAtrayList(llngCnt).strQty <> vbNullString Then
        '@                Call lrMsg2.addString(CPstrCHIP_QUANTITY, .typAtrayList(llngCnt).strQty)
        '@            Else
        '@                Call lrMsg2.addString(CPstrCHIP_QUANTITY, CPstrMsgNull)
        '@            End If
        '@↑2019/11/26 (Tue) 18:07:31 T.Oide **************************************************
                    Call lrAry.Add(lrMsg2)
                    lrMsg2.Clear
                Next
                
                Call lrMsg.addMsgAry(CPstrA_TRAY_LIST, lrAry)
                lrAry.Clear
                
                
         '@↓2019/11/26 (Tue) 18:07:31 T.Oide **************************************************
                '@利用部材
                For llngCnt = 0 To .typAtrayUsePart.lngAldPartCnt - 1
                
                    With .typAtrayUsePart.typeAldPart(llngCnt)
                
                        If .strPartCode <> vbNullString Then
                            Call lrMsg3.addString(CPstrPART_CODE, .strPartCode)
                        Else
                            Call lrMsg3.addString(CPstrPART_CODE, CPstrMsgNull)
                        End If
            
                        '@在庫ﾛｯﾄID
                        If .strLotID <> vbNullString Then
                            Call lrMsg3.addString(CPstrINV_LOT_ID, .strLotID)
                        Else
                            Call lrMsg3.addString(CPstrINV_LOT_ID, CPstrMsgNull)
                        End If
           
                        '@ﾁｯﾌﾟ数量
                        If .strChipQty <> vbNullString Then
                            Call lrMsg3.addString(CPstrCHIP_QUANTITY, .strChipQty)
                        Else
                            Call lrMsg3.addString(CPstrCHIP_QUANTITY, CPstrMsgNull)
                        End If

                        '@製造ﾛｯﾄID
                        If .strProdcLotId <> vbNullString Then
                            Call lrMsg3.addString(CPstrPRODUCTION_LOT_ID, .strProdcLotId)
                        Else
                            Call lrMsg3.addString(CPstrPRODUCTION_LOT_ID, CPstrMsgNull)
                        End If

                    End With
                    
                    Call lrAry2.Add(lrMsg3)
                    lrMsg3.Clear
                Next
                
                Call lrMsg.addMsgAry(CPstrPART_LIST, lrAry2)
                lrAry2.Clear
        '@↑2019/11/26 (Tue) 18:07:31 T.Oide **************************************************
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrachgatray, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                
                Case CPstrTRUE
                    pubblnACarrierChangeATray_Upd = True
                
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)

                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)

                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
        '@↓2019/12/04 (Wed) 13:04:20 T.Oide **************************************************
            lrAry2 = Nothing
        '@↑2019/12/04 (Wed) 13:04:20 T.Oide **************************************************
            laMsg = Nothing
        '@↓2019/12/04 (Wed) 13:04:31 T.Oide **************************************************
            lrMsg3 = Nothing
        '@↑2019/12/04 (Wed) 13:04:31 T.Oide **************************************************

            Exit Function
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrAry = Nothing
        '@↓2019/12/04 (Wed) 13:04:20 T.Oide **************************************************
            lrAry2 = Nothing
        '@↑2019/12/04 (Wed) 13:04:20 T.Oide **************************************************
            laMsg = Nothing
        '@↓2019/12/04 (Wed) 13:04:31 T.Oide **************************************************
            lrMsg3 = Nothing
        '@↑2019/12/04 (Wed) 13:04:31 T.Oide **************************************************

        End Try
    End Function

    '関数名：pubblnAtrayAvailableList_Sel
    '機　能：利用可能Aトレイ取
    '引　数：lstrMsgVer     :ﾒｯｾｰｼﾞVer
    '      ：ltypAtrayList  :Aﾄﾚｲ構造体
    '戻り値：True:成功/Flase：失敗
    '作成日：2009/05/27 (Wed) 17:05:04 K.Nishizawa
    '更新日：2009/07/21 (Tue) 16:58:25 T.Oide
    '備　考：
    Public Function pubblnAtrayAvailableList_Sel(ByVal lstrMsgVer As String, _
                                        ByRef ltypAtrayList As typeAtrayList) As Boolean
                                        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "利用可能Aトレイ取得"
            
            '戻り値初期化
            pubblnAtrayAvailableList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laAry = New TfMsgAry
            
            Call lrMsg.addMsgAry(CPstrA_TRAY_CLASS_LIST, lrAry)
            Call lrMsg.addMsgAry(CPstrTAPE_STICK_GROUP_LIST, lrAry)
            
            '@Msg_Ver取得
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@利用可能ﾌﾗｸﾞ
            Call lrMsg.addString(CPstrAVAILABLE_FLAG, CPstrFlagOn)


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrAtraylist, lrMsg, laMsg)
            
            '@ﾒｯｾｰｼﾞ受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '結果によって処理分岐
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                            
                    With ltypAtrayList
                    
                        '@ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrA_TRAY_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                        
                            '配列準備
                            .lngAtraytListCnt = laAry.Count

                            If .typAtraytList Is Nothing Then 
                                .typAtraytList = New List(Of typeAtray)
                            Else 
                                .typAtraytList.Clear 
                            End If

                            Dim typAtraytListRec AS typeAtray
                            typAtraytListRec = New typeAtray 
                            
                            '@ｱﾚｰ内の各要素を変数に取得
                            For Each ltMsg In laAry
                            
                                With typAtraytListRec
                                
                                    Call ltMsg.getString(CPstrA_TRAY_ID, .strAtrayId)               'AトレーID
                                    Call ltMsg.getString(CPstrA_TRAY_STATUS, .strAtrayStatus)       'ステータス
                                    Call ltMsg.getString(CPstrA_TRAY_CLASS, .strAtrayClass)         'Aトレー区分
                                    Call ltMsg.getString(CPstrTAPE_STICK_GROUP, .strTapeStickGr)    'テープ貼りグループ
                                    Call ltMsg.getString(CPstrSTART_TIME, .strStartTime)            '使用開始日時
                                    Call ltMsg.getString(CPstrCLEAN_TIME, .strCleanTime)            '最終洗浄日時
                                    Call ltMsg.getString(CPstrWASH_USE_NUM, .strWashUseNum)         '洗浄後使用回数
                                    Call ltMsg.getString(CPstrWASH_USE_LIMIT, .strWashUseLimit)     '洗浄後使用回数上限
                                    Call ltMsg.getString(CPstrUSE_NUM, .strUseNum)                  '累積使用回数
                                    Call ltMsg.getString(CPstrUSE_LIMIT, .strUseLimit)              '累積使用回数上限
                                    Call ltMsg.getString(CPstrA_CARRIER_ID, .strACarrierId)         'AキャリアID
                                    Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)      'スロットポジション
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                'ユーザ名
                                    Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)              '更新日時
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)               'コメント
                                    Call ltMsg.getString(CPstrA_TRAY_STATUS_NAME, .strAtrayStatusName)
                                    Call ltMsg.getString(CPstrCLEAN_COUNT, .strCleanCount)
                                    
                                End With
                                .typAtraytList.Add(typAtraytListRec)
                            Next
                        
                        End If
                    
                    End With
                    
                    '@結果OK
                    pubblnAtrayAvailableList_Sel = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
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
            lrAry = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnPartListAld_Sel
    '機　能：防湿膜ALD部品ﾘｽﾄ取得
    '引　数：typALDPart ：部品ﾘｽﾄ格納
    '      ：strMsgVer  ：ﾒｯｾｰｼﾞVer
    '戻り値：True：成功、Flase：失敗
    '作成日：2019/11/25 (Mon) 09:59:52 T.Oide
    '更新日：2019/11/25 (Mon) 10:04:46 T.Oide
    '備　考：
    Public Function pubblnPartListAld_Sel(ByVal lstrMsgVer As String, ByRef ltypALDPartList As typALDPartList)

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "防湿膜ALD部品取得"
            
            '戻り値初期化
            pubblnPartListAld_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg
            
            '@Msg_Ver取得
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_partlistAld, lrMsg, laMsg)
            
            '@ﾒｯｾｰｼﾞ受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '結果によって処理分岐
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                            
                    With ltypALDPartList
                    
                        '@ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrPART_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                        
                            '配列準備
                            .lngAldPartCnt = laAry.Count

                            If .typeAldPart Is Nothing Then 
                                .typeAldPart = New List(Of typALDPart)
                            Else 
                                .typeAldPart.Clear 
                            End If

                            Dim typeAldPartRec As typALDPart
                            typeAldPartRec = New typALDPart 

                            '@ｱﾚｰ内の各要素を変数に取得
                            For Each ltMsg In laAry
                            
                                With typeAldPartRec
                                    Call ltMsg.getString(CPstrVENDER_CLASS_ID, .strVenderClassId)       'ﾍﾞﾝﾀﾞｰｸﾗｽID
                                    Call ltMsg.getString(CPstrVENDER_CLASS_NAME, .strVenderClassName)   'ﾍﾞﾝﾀﾞｰｸﾗｽ名
                                    Call ltMsg.getString(CPstrVENDER_ID, .strVenderId)                  'ﾍﾞﾝﾀﾞｰID
                                    Call ltMsg.getString(CPstrVENDER_NAME, .strVenderName)              'ﾍﾞﾝﾀﾞｰ名
                                    Call ltMsg.getString(CPstrPART_CODE, .strPartCode)                  'ﾊﾟｰﾁｺｰﾄﾞ
                                    Call ltMsg.getString(CPstrPART_NAME, .strPartName)                  'ﾊﾟｰﾂ名
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotID)                        'ﾛｯﾄID
                                    Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQty)               '在庫ﾁｯﾌﾟ数
                                    Call ltMsg.getString(CPstrPRODUCTION_LOT_ID, .strProdcLotId)        '製造ﾛｯﾄID
                                    
                                End With
                                .typeAldPart.Add(typeAldPartRec)
                            Next
                        
                        End If
                    
                    End With
                    
                    '@結果OK
                    pubblnPartListAld_Sel = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing
            
        End Try
    End Function

End Module
