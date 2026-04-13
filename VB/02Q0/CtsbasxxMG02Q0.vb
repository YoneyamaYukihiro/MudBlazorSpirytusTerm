'ﾌｧｲﾙ名：xxMG02Q0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：「防湿ALDﾛｯﾄ流動」機能ﾒｯｾｰｼﾞ処理
'作成日：2018/08/18 (Sat) 11:36:48 Y.Yoneyama
'更新日：2019/02/13 (Wed) 15:22:28 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2018-2019, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02Q0
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Public ptypACarrierGroup            As ACarrierGroup

    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnWorkLotList_Sel
    '機　能：防湿ALD作業作業ﾛｯﾄ一覧取得
    '引　数：lstrMsgVer         ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotId          ：ｴﾘｱID
    '　　　：lstrCarrierId      ：ｴﾘｱID
    '　　　：lstrSbId           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：ltypWorkLotList    ：格納ﾃﾞｰﾀ
    '　　　：llngWorkLotListCnt ：ﾃﾞｰﾀ件数
    '戻り値：True：正常、False：異常
    '作成日：2018/08/18 (Sat) 11:36:48 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnWorkLotList_Sel(ByVal lstrMsgVer As String, _
                                          ByVal lstrLotID As String, _
                                          ByVal lstrCarrierID As String, _
                                          ByVal lstrSBID As String, _
                                          ByRef ltypWorkLotList As WorkALDLotList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            '@初期設定
            pstrMessageName = "防湿ALD作業作業ﾛｯﾄ一覧取得"
            pubblnWorkLotList_Sel = False
            
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
            
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_workaldlotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    With ltypWorkLotList
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)
                        Call laMsg.getString(CPstrCARRIER_ID, .strCarrierId)
                        Call laMsg.getString(CPstrALD_PROCESS_UNIT, .strProcessUnit)
                        Call laMsg.getString(CPstrALD_PROCESS_NUM, .strProcessNum)
                        Call laMsg.getString(CPstrALD_PROCESS_NAME, .strProcessName)
                        Call laMsg.getString(CPstrTAPE_STICK_BATCH_ID, .strTapeBatchId)
                        Call laMsg.getString(CPstrOVEN_BATCH_ID, .strOvenBatchId)
                        Call laMsg.getString(CPstrALD_BATCH_ID, .strAldBatchId)
                        Call laMsg.getString(CPstrMONITOR_USE_FLAG, .strMonitorUseFlag)
                        Call laMsg.getString(CPstrBATCH_FLOW_CLASS, .strBatchFlowClass)
                    End With

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypWorkLotList.lngAldWorkLotListCnt = laAry.Count
                    
                    If ltypWorkLotList.lngAldWorkLotListCnt > 0 Then
                        If IsNothing(ltypWorkLotList.typAldWorkLotList) Then
                            ltypWorkLotList.typAldWorkLotList = New List(Of AldWorkLotList)()
                        Else
                            ltypWorkLotList.typAldWorkLotList.Clear()
                        End If
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            '@受信結果取得
                            'ReDim Preserve ltypWorkLotList.typAldWorkLotList(llngCnt)
                            Dim tmpAldWorkLotList As AldWorkLotList = New AldWorkLotList()
                            With tmpAldWorkLotList
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)
                                Call ltMsg.getString(CPstrTO_CARRIER_ID, .strToCarrierId)
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)
                                Call ltMsg.getString(CPstrENG_EMP_ID, .strEngEmpId)
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)
                                Call ltMsg.getString(CPstrNOW_ST, .strNowST)
                                Call ltMsg.getString(CPstrWF_NUM, .strWfNum)
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)
                                Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)
                                Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)
                                Call ltMsg.getString(CPstrTO_OP_ID, .strToOpId)
                                Call ltMsg.getString(CPstrTO_STEP_ID, .strToStepId)
                                Call ltMsg.getString(CPstrLIMIT_TIME, .strLimitTime)
                                Call ltMsg.getString(CPstrWARN_TIME, .strWarnTime)
                                Call ltMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)
                                Call ltMsg.getString(CPstrPD_VERSION, .strPdVersion)
                                Call ltMsg.getString(CPstrALD_PROCESS_NUM, .strProcessNum)
                                Call ltMsg.getString(CPstrALD_PROCESS_NAME, .strProcessName)
                                Call ltMsg.getString(CPstrWORK_CONDITION, .strWorkCondition)
                                Call ltMsg.getString(CPstrCOMMENTS, .strComments)
                                Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)
                                Call ltMsg.getString(CPstrCOLLECTION_ID, .strCollectionID)
                                Call ltMsg.getString(CPstrCOLLECTION_VERSION, .strCollectionVersion)
                            End With

                            ltypWorkLotList.typAldWorkLotList.Add(tmpAldWorkLotList)

                            llngCnt = llngCnt + 1
                        Next
                    End If
                        
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrA_CARRIER_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypWorkLotList.lngAldWorkACarrierListCnt = laAry.Count
                    
                    If ltypWorkLotList.lngAldWorkACarrierListCnt > 0 Then
                        If IsNothing(ltypWorkLotList.typAldWorkACarrierList) Then
                            ltypWorkLotList.typAldWorkACarrierList = New List(Of AldWorkACarrierList)()
                        Else
                            ltypWorkLotList.typAldWorkACarrierList.Clear()
                        End If
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            '@受信結果取得
                            'ReDim Preserve ltypWorkLotList.typAldWorkACarrierList(llngCnt)
                            Dim tmpAldWorkACarrierList As AldWorkACarrierList = New AldWorkACarrierList()
                            With tmpAldWorkACarrierList
                                Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)
                                Call ltMsg.getString(CPstrA_CARRIER_GROUP, .strACarrierGroup)
                                Call ltMsg.getString(CPstrTAPE_STICK_BATCH_ID, .strTapeBatchId)
                                Call ltMsg.getString(CPstrOVEN_BATCH_ID, .strOvenBatchId)
                                Call ltMsg.getString(CPstrALD_BATCH_ID, .strAldBatchId)
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)
                                Call ltMsg.getString(CPstrA_CARRIER_ID, .strACarrierId)
                            End With
                            ltypWorkLotList.typAldWorkACarrierList.Add(tmpAldWorkACarrierList)
                            llngCnt = llngCnt + 1
                        Next
                    End If
                        
                    '@関数の処理結果(成功)格納
                    pubblnWorkLotList_Sel = True
                    
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

    '関数名：pubblnLotWplistALD_Sel
    '機　能：ﾛｯﾄ装置情報取得
    '引　数：lstrMsgVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：lstrOpID               ：大工程ID
    '　　　：lstrStepID             ：小工程ID
    '　　　：lstrAltNumber          ：代替工程№
    '　　　：ltypWpList             ：装置情報格納用構造体
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/10 (Fri) 10:38:27 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnLotWplistALD_Sel(ByVal lstrMsgVer As String, _
                                           ByVal lstrClassDivision As String, _
                                           ByVal lstrLotID As String, _
                                           ByVal lstrOpID As String, _
                                           ByVal lstrStepID As String, _
                                           ByRef ltypALDWpList As ALDWpList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "ロット装置情報取得(防湿ALD)"
            pubblnLotWplistALD_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_wplistald, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@ﾃﾞｰﾀを取得
                    Call laMsg.getMsgAry(CPstrWP_LIST, laAry)
                    
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypALDWpList.lngALDWpListListCnt = laAry.Count
                        
                        '@配列の要素数を設定
                        'ReDim Preserve ltypALDWpList.typALDWpListList(ltypALDWpList.lngALDWpListListCnt)
                        If IsNothing(ltypALDWpList.typALDWpListList) Then
                            ltypALDWpList.typALDWpListList = New List(Of ALDWpListList)()
                        Else
                            ltypALDWpList.typALDWpListList.Clear()
                        End If
                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim tmpALDWpListList As ALDWpListList = New ALDWpListList()
                            With tmpALDWpListList
                            
                                Call ltMsg.getString(CPstrWP_ID, .strWpID)
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)
                                Call ltMsg.getString(CPstrWP_STATUS_NAME, .strWpStatusName)
                                Call ltMsg.getString(CPstrWP_STOP_FLAG, .strWpStopFlag)
                                Call ltMsg.getString(CPstrWP_TYPE_FLAG, .strWpTypeFlag)
                                Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)
                                Call ltMsg.getString(CPstrLOT_RECIPE_FLAG, .strLotRecipeFlag)
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)
                                Call ltMsg.getString(CPstrNEXT_OP_ID, .strNextOpId)
                                Call ltMsg.getString(CPstrNEXT_STEP_ID, .strNextStepId)
                                Call ltMsg.getString(CPstrEQ_TYPE, .strEqType)
                                Call ltMsg.getString(CPstrMC_TYPE, .strMcType)
                                Call ltMsg.getString(CPstrFTP_DATA_FLAG, .strFtpDataFlag)
                                Call ltMsg.getString(CPstrMES_MODE_ID, .strMesModeId)
                                Call ltMsg.getString(CPstrUSE_ID, .strUseId)
                                Call ltMsg.getString(CPstrLOADER_UNLOADER_FLAG, .strLoaderUnloaderFlag)
                                Call ltMsg.getString(CPstrBEFORE_CARRIER_TYPE_ID, .strBeforeCarrierTypeId)
                                Call ltMsg.getString(CPstrBEFORE_CARRIER_TYPE_NAME, .strBeforeCarrierTypeName)
                                Call ltMsg.getString(CPstrAFTER_CARRIER_TYPE_ID, .strAfterCarrierTypeId)
                                Call ltMsg.getString(CPstrAFTER_CARRIER_TYPE_NAME, .strAfterCarrierTypeName)
                                Call ltMsg.getString(CPstrCLEAN_CONDITION, .strCleanCondition)
                                Call ltMsg.getString(CPstrALD_PROCESS_NUM, .strProcessNum)
                                Call ltMsg.getString(CPstrALD_PROCESS_NAME, .strProcessName)
                            
                            End With
                            ltypALDWpList.typALDWpListList.Add(tmpALDWpListList)
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotWplistALD_Sel = True
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnACarrierGroupInfo_Sel
    '機　能：Aｷｬﾘｱｸﾞﾙｰﾌﾟ情報
    '引　数：lstrMsgVer             ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrTapeBatchID        ：ﾃｰﾌﾟﾊﾞｯﾁID
    '　　　：lstrOvenBatchID        ：ｵｰﾌﾞﾝﾊﾞｯﾁID
    '　　　：lstrAldBatchID         ：ALDﾊﾞｯﾁID
    '　　　：ltypACarrierGroupInfo  ：AｷｬﾘｱINFO
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/10 (Fri) 10:38:27 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnACarrierGroupInfo_Sel(ByVal lstrMsgVer As String, _
                                           ByVal lstrTapeBatchID As String, _
                                           ByVal lstrOvenBatchID As String, _
                                           ByVal lstrAldBatchID As String, _
                                           ByRef ltypACarrierGroupInfo As ACarrierGroupInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "Aｷｬﾘｱｸﾞﾙｰﾌﾟ情報"
            pubblnACarrierGroupInfo_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾃｰﾌﾟ
            If lstrTapeBatchID <> vbNullString Then
                Call lrMsg.addString(CPstrTAPE_STICK_BATCH_ID, lstrTapeBatchID)
            Else
                Call lrMsg.addString(CPstrTAPE_STICK_BATCH_ID, CPstrMsgNull)
            End If
                
            '@ｵｰﾌﾞﾝ
            If lstrOvenBatchID <> vbNullString Then
                Call lrMsg.addString(CPstrOVEN_BATCH_ID, lstrOvenBatchID)
            Else
                Call lrMsg.addString(CPstrOVEN_BATCH_ID, CPstrMsgNull)
            End If
            
            '@ALD
            If lstrAldBatchID <> vbNullString Then
                Call lrMsg.addString(CPstrALD_BATCH_ID, lstrAldBatchID)
            Else
                Call lrMsg.addString(CPstrALD_BATCH_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarracrgroupinfo, lrMsg, laMsg)
            
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    With ltypACarrierGroupInfo
                        Call laMsg.getString(CPstrBATCH_FLOW_CLASS, .strBatchFlowClass)
                        Call laMsg.getString(CPstrBATCH_STATUS, .strBatchStatus)
                        Call laMsg.getString(CPstrMONITOR_USE_FLAG, .strMonitorUseFlag)

                    End With
                    
                    Call laMsg.getMsgAry(CPstrTAPE_STICK_GROUP_LIST, laAry)
                    
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypACarrierGroupInfo.lngTapeGroupListCnt = laAry.Count
                        
                        '@配列の要素数を設定
                        'ReDim Preserve ltypACarrierGroupInfo.typtapeGroupList(ltypACarrierGroupInfo.lngTapeGroupListCnt)
                        If IsNothing(ltypACarrierGroupInfo.typtapeGroupList) Then
                            ltypACarrierGroupInfo.typtapeGroupList = New List(Of TapeGroup)()
                        Else
                            ltypACarrierGroupInfo.typtapeGroupList.Clear()
                        End If
                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim tmpTapeGroup As TapeGroup = New TapeGroup()
                            With tmpTapeGroup
                            
                                Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)
                                Call ltMsg.getString(CPstrA_CARRIER_GROUP, .strACarrierGroup)
                                Call ltMsg.getString(CPstrTAPE_STICK_BATCH_ID, .strTapeBatchId)
                                Call ltMsg.getString(CPstrOVEN_BATCH_ID, .strOvenBatchId)
                                Call ltMsg.getString(CPstrALD_BATCH_ID, .strAldBatchId)
                                Call ltMsg.getString(CPstrTAPE_STICK_GROUP, .strTapeStickGroup)
                                Call ltMsg.getString(CPstrA_CARRIER_ID, .strACarrierId)
                            
                            End With
                            ltypACarrierGroupInfo.typtapeGroupList.Add(tmpTapeGroup)
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnACarrierGroupInfo_Sel = True
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnACarrierList_Sel
    '機　能：Aｷｬﾘｱﾘｽﾄ
    '引　数：lstrMsgVer             ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrACarrierClass      ：区分
    '　　　：lstrTapeGroup          ：ｸﾞﾙｰﾌﾟID
    '　　　：lstrTapeBatchID        ：ﾃｰﾌﾟﾊﾞｯﾁID
    '　　　：ltypACarierList        ：ACarrier構造体
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/10 (Fri) 10:38:27 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnACarrierList_Sel(ByVal lstrMsgVer As String, _
                                           ByVal lstrACarrierClass As String, _
                                           ByVal lstrTapeGroup As String, _
                                           ByVal lstrTapeBatchID As String, _
                                           ByRef ltypACarierList As List(Of ACarrierList)) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim llngListCnt         As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "Aｷｬﾘｱﾘｽﾄ"
            pubblnACarrierList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrACarrierClass <> vbNullString Then
                Call lrMsg.addString(CPstrA_CARRIER_CLASS, lstrACarrierClass)
            Else
                Call lrMsg.addString(CPstrA_CARRIER_CLASS, CPstrMsgNull)
            End If
            
            If lstrTapeGroup <> vbNullString Then
                 Call lrMsg.addString(CPstrTAPE_STICK_GROUP, lstrTapeGroup)
            Else
                Call lrMsg.addString(CPstrTAPE_STICK_GROUP, CPstrMsgNull)
            End If
            
            If lstrTapeBatchID <> vbNullString Then
                Call lrMsg.addString(CPstrTAPE_STICK_BATCH_ID, lstrTapeBatchID)
            Else
                Call lrMsg.addString(CPstrTAPE_STICK_BATCH_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarracarlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@ﾃﾞｰﾀを取得
                    Call laMsg.getMsgAry(CPstrA_CARRIER_LIST, laAry)
                    
                    If IsNothing(ltypACarierList) Then
                        ltypACarierList = New List(Of ACarrierList)
                    Else
                        ltypACarierList.Clear()
                    End If
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngListCnt = laAry.Count
                        
                        '@配列の要素数を設定
                        'ReDim Preserve ltypACarierList(llngListCnt)
                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim tmpACarrierList As ACarrierList = New ACarrierList()
                            With tmpACarrierList
                            
                                Call ltMsg.getString(CPstrA_CARRIER_ID, .strACarrierId)
                                Call ltMsg.getString(CPstrA_TRAY_NUM, .strATrayNum)
                            
                            End With
                            ltypACarierList.Add(tmpACarrierList)
                            llngCnt = llngCnt + 1
                        Next
                    Else
                        'ReDim ltypACarierList(1)
                        ltypACarierList.Add(New ACarrierList())
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnACarrierList_Sel = True
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnACarrierSet_Upd
    '機　能：Aｷｬﾘｱﾘｽﾄ
    '引　数：lstrMsgVer             ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypACarierList        ：ACarrier構造体
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/10 (Fri) 10:38:27 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnACarrierSet_Upd(ByVal lstrMsgVer As String, _
                                           ByRef ltypACarrierGroup As ACarrierGroup) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrMsg2              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "Aｷｬﾘｱｾｯﾄ"
            pubblnACarrierSet_Upd = False
            
            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg

            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@作業者ID取得
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            With ltypACarrierGroup
            
                If .strTapeBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrTAPE_STICK_BATCH_ID, .strTapeBatchId)
                Else
                    Call lrMsg.addString(CPstrTAPE_STICK_BATCH_ID, CPstrMsgNull)
                End If

                If .strOvenBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrOVEN_BATCH_ID, .strOvenBatchId)
                Else
                    Call lrMsg.addString(CPstrOVEN_BATCH_ID, CPstrMsgNull)
                End If

                If .strAldBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrALD_BATCH_ID, .strAldBatchId)
                Else
                    Call lrMsg.addString(CPstrALD_BATCH_ID, CPstrMsgNull)
                End If

                For llngCnt = 0 To .lngGroupListCnt - 1
                
                    If .typACarrierGroupList(llngCnt).strACarrierId <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_CARRIER_ID, .typACarrierGroupList(llngCnt).strACarrierId)
                    Else
                        Call lrMsg2.addString(CPstrA_CARRIER_ID, CPstrMsgNull)
                    End If
                    
                    If .typACarrierGroupList(llngCnt).strACarrierGroup <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_CARRIER_GROUP, .typACarrierGroupList(llngCnt).strACarrierGroup)
                    Else
                        Call lrMsg2.addString(CPstrA_CARRIER_GROUP, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(lrMsg2)
                    lrMsg2.Clear
                Next
            End With
            Call lrMsg.addMsgAry(CPstrA_CARRIER_LIST, lrAry)
            lrAry.Clear

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarracarset_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                                
                    '@関数の処理結果(成功)格納
                    pubblnACarrierSet_Upd = True
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnACarrierLotCancel_Upd
    '機　能：Aｷｬﾘｱﾛｯﾄ設定解除
    '引　数：lstrMsgVer             ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypACarierList        ：ACarrier構造体
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/10 (Fri) 10:38:27 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnACarrierLotCancel_Upd(ByVal lstrMsgVer As String, _
                                           ByRef ltypACarrierGroup As ACarrierGroup) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrMsg2              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "Aｷｬﾘｱﾛｯﾄｾｯﾄ"
            pubblnACarrierLotCancel_Upd = False
            
            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg

            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@作業者ID取得
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@SBID取得
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            
            With ltypACarrierGroup
            
                If .strAldBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrALD_BATCH_ID, .strAldBatchId)
                Else
                    Call lrMsg.addString(CPstrALD_BATCH_ID, CPstrMsgNull)
                End If

                For llngCnt = 0 To .lngGroupListCnt - 1
                
                    If .typACarrierGroupList(llngCnt).strLotID <> vbNullString Then
                        Call lrMsg2.addString(CPstrLOT_ID, .typACarrierGroupList(llngCnt).strLotID)
                    Else
                        Call lrMsg2.addString(CPstrLOT_ID, CPstrMsgNull)
                    End If
                
                    If .typACarrierGroupList(llngCnt).strACarrierClass <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_CARRIER_CLASS, .typACarrierGroupList(llngCnt).strACarrierClass)
                    Else
                        Call lrMsg2.addString(CPstrA_CARRIER_CLASS, CPstrMsgNull)
                    End If
                    
                    If .typACarrierGroupList(llngCnt).strACarrierId <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_CARRIER_ID, .typACarrierGroupList(llngCnt).strACarrierId)
                    Else
                        Call lrMsg2.addString(CPstrA_CARRIER_ID, CPstrMsgNull)
                    End If
                    
                    If .typACarrierGroupList(llngCnt).strACarrierGroup <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_CARRIER_GROUP, .typACarrierGroupList(llngCnt).strACarrierGroup)
                    Else
                        Call lrMsg2.addString(CPstrA_CARRIER_GROUP, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(lrMsg2)
                    lrMsg2.Clear
                Next
            End With
            Call lrMsg.addMsgAry(CPstrA_CARRIER_LIST, lrAry)
            lrAry.Clear

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarracarlotcancel, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                                
                    '@関数の処理結果(成功)格納
                    pubblnACarrierLotCancel_Upd = True
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnACarrierLotSet_Upd
    '機　能：Aｷｬﾘｱﾛｯﾄ設定
    '引　数：lstrMsgVer             ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypACarierList        ：ACarrier構造体
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/10 (Fri) 10:38:27 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnACarrierLotSet_Upd(ByVal lstrMsgVer As String, _
                                           ByRef ltypACarrierGroup As ACarrierGroup) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrMsg2              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "Aｷｬﾘｱﾛｯﾄｾｯﾄ"
            pubblnACarrierLotSet_Upd = False
            
            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg

            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@作業者ID取得
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@SBID取得
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            
            With ltypACarrierGroup
            
                If .strAldBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrALD_BATCH_ID, .strAldBatchId)
                Else
                    Call lrMsg.addString(CPstrALD_BATCH_ID, CPstrMsgNull)
                End If

                For llngCnt = 0 To .lngGroupListCnt - 1 
                
                    If .typACarrierGroupList(llngCnt).strLotID <> vbNullString Then
                        Call lrMsg2.addString(CPstrLOT_ID, .typACarrierGroupList(llngCnt).strLotID)
                    Else
                        Call lrMsg2.addString(CPstrLOT_ID, CPstrMsgNull)
                    End If
                
                    If .typACarrierGroupList(llngCnt).strACarrierClass <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_CARRIER_CLASS, .typACarrierGroupList(llngCnt).strACarrierClass)
                    Else
                        Call lrMsg2.addString(CPstrA_CARRIER_CLASS, CPstrMsgNull)
                    End If
                    
                    If .typACarrierGroupList(llngCnt).strACarrierId <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_CARRIER_ID, .typACarrierGroupList(llngCnt).strACarrierId)
                    Else
                        Call lrMsg2.addString(CPstrA_CARRIER_ID, CPstrMsgNull)
                    End If
                    
                    If .typACarrierGroupList(llngCnt).strACarrierGroup <> vbNullString Then
                        Call lrMsg2.addString(CPstrA_CARRIER_GROUP, .typACarrierGroupList(llngCnt).strACarrierGroup)
                    Else
                        Call lrMsg2.addString(CPstrA_CARRIER_GROUP, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(lrMsg2)
                    lrMsg2.Clear
                Next
            End With
            Call lrMsg.addMsgAry(CPstrA_CARRIER_LIST, lrAry)
            lrAry.Clear

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarracarlotset, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                                
                    '@関数の処理結果(成功)格納
                    pubblnACarrierLotSet_Upd = True
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnAldMakeRecipe_Upd
    '機　能：防湿ALDﾚｼﾋﾟ作成要求
    '引　数：lstrWpId
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/10 (Fri) 10:38:27 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnAldMakeRecipe_Upd(ByVal lstrWpId As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim lstrMsgVer          As String
        
        Try
            
            pstrMessageName = "防湿ALDﾚｼﾋﾟ作成"
            pubblnAldMakeRecipe_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@装置への送信(ﾒｯｾｰｼﾞVer管理はないのでここでは01.00で固定)
            lstrMsgVer = "01.00"
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrftp_aldmakerecipe, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnAldMakeRecipe_Upd = True
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function
End Module
