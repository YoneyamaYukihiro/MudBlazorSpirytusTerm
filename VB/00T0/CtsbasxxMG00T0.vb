'ﾌｧｲﾙ名：xxMG00T0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置ﾃﾞｰﾀ登録/参照 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/09/20 (Mon) 11:27:13 N.Kojima
'更新日：2004/09/20 (Mon) 11:27:13
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00T0
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

    '関数名：pubblnLotCollectParams_Sel
    '機　能：装置収集項目取得
    '引　数：lstrlot_collectparamslistVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID：ﾛｯﾄID
    '　　　：lstrOpid：大工程ID
    '　　　：lstrStepid：小工程ID
    '　　　：lstrDataUnit：取得情報ﾌﾗｸﾞ(1:ﾛｯﾄ/2:WF)
    '　　　：lstrWFID：WFID(Lot単位選択：NULL/WF単位選択：WFIDをｾｯﾄ)
    '　　　：ltypLotCollectParamsList：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/09/20 (Mon) 11:40:38 N.Kojima
    '更新日：2007/01/29 (Mon) 13:02:48 N.Kojima
    '備　考：
    '　　　：2005/01/25 (Tue) 10:08:32 S.Deguchi    SPCｻｰﾊﾞ対応(不具合改善№416)
    '　　　：2006/12/21 (Thu) 08:51:08 N.Kasai      応答ﾀｸﾞ追加(COLLECTION_TYPE)
    '　　　：2007/01/23 (Tue) 16:10:48 N.Kasai      応答ﾀｸﾞ追加(CEID)№01428
    '　　　：2007/01/29 (Mon) 13:02:48 N.Kojima     要求ﾀｸﾞ追加(WF_ID)。(案件№01428)
    Public Function pubblnLotCollectParams_Sel(ByVal lstrlot_collectparamslistVer As String, _
                                                   ByVal lstrLotID As String, _
                                                   ByVal lstrOpID As String, _
                                                   ByVal lstrStepID As String, _
                                                   ByVal lstrDataUnit As String, _
                                                   ByVal lstrWFID As String, _
                                                   ByRef ltypLotCollectParamsList As LotCollectParamsList) As Boolean

        Dim lrMsg               As TfMsg              '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg              '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg              '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry               As TfMsgAry           '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET             As String             '応答取得
        Dim llngCnt             As Integer            'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "収集データパラメータ取得"
            pubblnLotCollectParams_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrlot_collectparamslistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_collectparamslistVer)        'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                              'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                            'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)                              '大工程ID
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)                          '小工程ID
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            If lstrDataUnit <> vbNullString Then
                Call lrMsg.addString(CPstrDATA_UNIT, lstrDataUnit)                      'ﾃﾞｰﾀﾕﾆｯﾄ
            Else
                Call lrMsg.addString(CPstrDATA_UNIT, CPstrMsgNull)
            End If
        '@↓2007/01/29 (Mon) 13:02:27 N.Kojima **************************************************
            If lstrWFID <> vbNullString Then
                Call lrMsg.addString(CPstrWF_ID, lstrWFID)                              'WF_ID
            Else
                Call lrMsg.addString(CPstrWF_ID, CPstrMsgNull)
            End If
        '@↑2007/01/29 (Mon) 13:02:27 N.Kojima **************************************************

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_collectparams, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypLotCollectParamsList
                        '@受信結果取得
                        Call laMsg.getString(CPstrCATEGORY_ID, .strCategoryID)                              'ｶﾃｺﾞﾘID
                        Call laMsg.getString(CPstrLOT_DATA_COLL_COMP_FLAG, .strLotDataCollCompFlag)         'ﾛｯﾄﾃﾞｰﾀ収集完了ﾌﾗｸﾞ

                        Call laMsg.getMsgAry(CPstrCOLLECTION_LIST, laAry)       '収集ﾃﾞｰﾀﾘｽﾄ
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .llngLotCollectParamsCnt = laAry.Count
                        If .llngLotCollectParamsCnt > 0 Then
                            If IsNothing(.typLotCollectParams) Then
                                .typLotCollectParams = New List(Of LotCollectParams)
                            Else
                                .typLotCollectParams.Clear()
                            End If
                            Dim typLotCollectParamsTmp = New LotCollectParams
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 1
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typLotCollectParamsTmp
                                    Call ltMsg.getString(CPstrPARAMETER_ID, .strParameterID)                'ﾊﾟﾗﾒｰﾀID
                                    Call ltMsg.getString(CPstrPARAMETER_VERSION, .strParameterVersion)      'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrUNIT, .strUnit)                               '単位
                                    Call ltMsg.getString(CPstrDATA_TYPE, .strDataType)                      'ﾃﾞｰﾀﾀｲﾌﾟ
                                    Call ltMsg.getString(CPstrCLASSIFICATION_1, .strClassification1)        'ﾃﾞｰﾀ分類1名
                                    Call ltMsg.getString(CPstrCLASSIFICATION_2, .strClassification2)        'ﾃﾞｰﾀ分類2名
                                    Call ltMsg.getString(CPstrCLASSIFICATION_3, .strClassification3)        'ﾃﾞｰﾀ分類3名
                                    Call ltMsg.getString(CPstrCLASSIFICATION_4, .strClassification4)        'ﾃﾞｰﾀ分類4名
                                    Call ltMsg.getString(CPstrMANDATORY_COUNT, .strMandatoryCount)          '必須項目数
                                    Call ltMsg.getString(CPstrDV_NAME, .strDvName)                          '装置報告ﾃﾞｰﾀ名
                                    Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)                          'CFﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrLP_FLAG, .strLpFlag)                          '大板ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrDATA_UNIT, .strDataUnit)                      'ﾃﾞｰﾀ単位
                                    Call ltMsg.getString(CPstrMEASURE_MODE, .strMeasureMode)                '測定ﾓｰﾄﾞ
                                    Call ltMsg.getString(CPstrDATA_RETAIN_FLAG, .strDataRetainFlag)         '装置ﾃﾞｰﾀ引継ぎﾌﾗｸﾞ
        '@↓2006/12/21 (Thu) 08:52:07 N.Kasai **************************************************
                                    Call ltMsg.getString(CPstrCOLLECTION_TYPE, .strCollectionType)          '収集項目ﾀｲﾌﾟ(0:作業記録、1:装置ﾃﾞｰﾀ）
        '@↑2006/12/21 (Thu) 08:52:07 N.Kasai **************************************************
        '@↓2007/01/23 (Tue) 16:10:44 N.Kasai **************************************************
                                    Call ltMsg.getString(CPstrCEID, .strCeId)                               'CEID(0:正、1:異、NULL:正）
        '@↑2007/01/23 (Tue) 16:10:44 N.Kasai **************************************************
                                End With
                                .typLotCollectParams.Add(typLotCollectParamsTmp)
                                llngCnt = llngCnt + 1
                            Next
                           
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnLotCollectParams_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_collectparamslistVer)

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

    '関数名：pubblnSpcWfCollectionInfo_Sel
    '機　能：装置ﾃﾞｰﾀ参照
    '引　数：ltypSpcCollectionInfo：要求ﾃﾞｰﾀ構造体
    '　　　：ltypwfCollectionInfo：応答ﾃﾞｰﾀ構造体
    '戻り値：True:成功、Flase：失敗
    '作成日：2005/01/25 (Tue) 11:12:55 S.Deguchi
    '更新日：2005/01/25 (Tue) 11:12:55
    '備　考：
    Public Function pubblnSpcCollectionInfo_Sel(ByRef ltypSpcCollectionInfo As CollectionInfoRequest, _
                                                ByRef ltypwfCollectionInfo As WfCollectionInfo) As Boolean

        Dim lrMsg               As TfMsg              '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg              '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg              '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry               As TfMsgAry           '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET             As String             '応答取得
        Dim llngCnt             As Integer            'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "装置データ参照"
            pubblnSpcCollectionInfo_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypSpcCollectionInfo
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                          'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                              'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                            'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                If .strParameterID <> vbNullString Then
                    Call lrMsg.addString(CPstrPARAMETER_ID, .strParameterID)                'ﾊﾟﾗﾒｰﾀID
                Else
                    Call lrMsg.addString(CPstrPARAMETER_ID, CPstrMsgNull)
                End If
                If .strParameterVersion <> vbNullString Then
                    Call lrMsg.addString(CPstrPARAMETER_VERSION, .strParameterVersion)      'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrPARAMETER_VERSION, CPstrMsgNull)
                End If
                If .strWfId <> vbNullString Then
                    Call lrMsg.addString(CPstrWF_ID, .strWfId)                              'WFID
                Else
                    Call lrMsg.addString(CPstrWF_ID, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrspc_collectioninfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@↓2005/10/28 (Fri) 10:56:18 S.Deguchi **************************************************
                    '            '@ｵﾝﾗｲﾝﾃｽﾄ用ﾀﾞﾐｰﾃﾞｰﾀ：近いうちに削除しても可
                    '            If ltypSpcCollectionInfo.strParameterID = "DEG_LOT_Para_ON" Then
                    '                '@関数の処理結果(成功)格納
                    '                pubblnSpcCollectionInfo_Sel = True
                    '
                    '                With ltypwfCollectionInfo
                    '                    ReDim Preserve .typWfCollectionInfoList(2)
                    '                    .lngWfCollectionInfoListCnt = 2
                    '                    .typWfCollectionInfoList(1).strClassification1 = "1"
                    '                    .typWfCollectionInfoList(1).strClassification2 = "2"
                    '                    .typWfCollectionInfoList(1).strClassification3 = vbNullString
                    '                    .typWfCollectionInfoList(1).strClassification4 = vbNullString
                    '                    .typWfCollectionInfoList(1).strData = "10"
                    '                    .typWfCollectionInfoList(2).strClassification1 = "3"
                    '                    .typWfCollectionInfoList(2).strClassification2 = "4"
                    '                    .typWfCollectionInfoList(2).strClassification3 = vbNullString
                    '                    .typWfCollectionInfoList(2).strClassification4 = vbNullString
                    '                    .typWfCollectionInfoList(2).strData = "20"
                    '                End With
                    '
                    '                Exit Function
                    '            End If
                    '
                    '            If ltypSpcCollectionInfo.strParameterID = "DEG_WF_Para_ON" Then
                    '                '@関数の処理結果(成功)格納
                    '                pubblnSpcCollectionInfo_Sel = True
                    '
                    '                With ltypwfCollectionInfo
                    '                    ReDim Preserve .typWfCollectionInfoList(1)
                    '                    .lngWfCollectionInfoListCnt = 1
                    '                    .typWfCollectionInfoList(1).strClassification1 = "11"
                    '                    .typWfCollectionInfoList(1).strClassification2 = "12"
                    '                    .typWfCollectionInfoList(1).strClassification3 = vbNullString
                    '                    .typWfCollectionInfoList(1).strClassification4 = vbNullString
                    '                    .typWfCollectionInfoList(1).strData = "100"
                    '                End With
                    '
                    '                Exit Function
                    '            End If
                    '@↑2005/10/28 (Fri) 10:56:18 S.Deguchi **************************************************

                    With ltypwfCollectionInfo
                        '@受信結果取得
                        Call laMsg.getMsgAry(CPstrCLIENT_DATA_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngWfCollectionInfoListCnt = laAry.Count
                        If .lngWfCollectionInfoListCnt > 0 Then
                            If IsNothing(.typWfCollectionInfoList) Then
                                .typWfCollectionInfoList = New List(Of WfCollectionInfoList)
                            Else
                                .typWfCollectionInfoList.Clear()
                            End If
                            Dim typWfCollectionInfoListTmp = New WfCollectionInfoList
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 1
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typWfCollectionInfoListTmp
                                    Call ltMsg.getString(CPstrCLASSIFICATION_1, .strClassification1)        'ﾃﾞｰﾀ分類1名
                                    Call ltMsg.getString(CPstrCLASSIFICATION_2, .strClassification2)        'ﾃﾞｰﾀ分類2名
                                    Call ltMsg.getString(CPstrCLASSIFICATION_3, .strClassification3)        'ﾃﾞｰﾀ分類3名
                                    Call ltMsg.getString(CPstrCLASSIFICATION_4, .strClassification4)        'ﾃﾞｰﾀ分類4名
                                    Call ltMsg.getString(CPstrDATA, .strData)                               '登録値
                                    Call ltMsg.getString(CPstrSPEC_CHECK, .strSpecCheck)                    '判定結果
                                End With
                                .typWfCollectionInfoList.Add(typWfCollectionInfoListTmp)
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnSpcCollectionInfo_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypSpcCollectionInfo.strMsgVer)

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

    '関数名：pubblnSpcRegCollect_Ins
    '機　能：装置ﾃﾞｰﾀ登録
    '引　数：ltypWfChgCollection：格納ﾃﾞｰﾀ構造体
    '　　　：lstrLotLastUpdate：最終更新日時
    '戻り値：True：成功、False：失敗
    '作成日：2005/01/26 (Wed) 14:43:09 S.Deguchi
    '更新日：2005/01/26 (Wed) 14:43:09
    '備　考：
    '　　　：2005/12/05 (Mon) 09:24:31 S.Deguchi    運用障害№619対応で,送信TAG：DATA_DIVISION追加
    Public Function pubblnSpcRegCollect_Ins(ByRef ltypWfChgCollection As WfChgCollection, _
                                            ByRef lstrLotLastUpdate As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
 
        Try

            pstrMessageName = "装置データ登録"
            pubblnSpcRegCollect_Ins = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg2 = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypWfChgCollection
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                              'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                                  'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)                '処理区分
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
        '@↓2005/12/05 (Mon) 09:26:53 S.Deguchi **************************************************
                If .strDataDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrDATA_DIVISION, .strDataDivision)                  'ﾃﾞｰﾀ区分
                Else
                    Call lrMsg.addString(CPstrDATA_DIVISION, CPstrMsgNull)
                End If
        '@↑2005/12/05 (Mon) 09:26:53 S.Deguchi **************************************************
                If .strParameterID <> vbNullString Then
                    Call lrMsg.addString(CPstrPARAMETER_ID, .strParameterID)                    'ﾊﾟﾗﾒｰﾀID
                Else
                    Call lrMsg.addString(CPstrPARAMETER_ID, CPstrMsgNull)
                End If
                If .strParameterVersion <> vbNullString Then
                    Call lrMsg.addString(CPstrPARAMETER_VERSION, .strParameterVersion)          'ﾊﾟﾗﾒｰﾀﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrPARAMETER_VERSION, CPstrMsgNull)
                End If
                If .strSlotPosition <> vbNullString Then
                    Call lrMsg.addString(CPstrSLOT_POSITION, .strSlotPosition)                  'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                Else
                    Call lrMsg.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                End If
                
                '@装置WF登録ﾃﾞｰﾀ情報ｾｯﾄ
                llngCnt = 0
                Do While .lngEqWfDataEntryCnt > llngCnt
                    With .typEqWfDataEntry(llngCnt)
                        If .strDvName <> vbNullString Then
                            Call ltMsg.addString(CPstrDV_NAME, .strDvName)                      'ﾃﾞｰﾀ名
                        Else
                            Call ltMsg.addString(CPstrDV_NAME, CPstrMsgNull)
                        End If
                        If .strDvNameParameter <> vbNullString Then
                            Call ltMsg.addString(CPstrDV_NAME_PARAMETER, .strDvNameParameter)   'ﾊﾟﾗﾒｰﾀID名
                        Else
                            Call ltMsg.addString(CPstrDV_NAME_PARAMETER, CPstrMsgNull)
                        End If
                        If .strDvValue <> vbNullString Then
                            Call ltMsg.addString(CPstrDV_VALUE, .strDvValue)                    'ﾃﾞｰﾀ
                        Else
                            Call ltMsg.addString(CPstrDV_VALUE, CPstrMsgNull)
                        End If
        '@↓2006/12/20 (Wed) 15:36:42 N.Kasai **************************************************
                        If .strCollectionType <> vbNullString Then
                            Call ltMsg.addString(CPstrCOLLECTION_TYPE, .strCollectionType)      '収集項目ﾀｲﾌﾟ(0:作業記録/1:装置ﾃﾞｰﾀ）
                        Else
                            Call ltMsg.addString(CPstrCOLLECTION_TYPE, CPstrMsgNull)
                        End If
        '@↑2006/12/20 (Wed) 15:36:42 N.Kasai **************************************************
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                        llngCnt = llngCnt + 1
                    End With
                Loop
                Call lrMsg.addMsgAry(CPstrDATA_LIST, lrAry)
                lrAry.Clear
                
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                                '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               'ﾛｯﾄ最終更新日時
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrspc_regcollect, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)           'ﾛｯﾄ最終更新日時
                    
                    '@関数の処理結果(成功)格納
                    pubblnSpcRegCollect_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypWfChgCollection.strMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            ltMsg2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            ltMsg2 = Nothing
                                
        End Try
    End Function


End Module
