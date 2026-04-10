'ﾌｧｲﾙ名：xxMG0151.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置別ﾛｯﾄ一覧(防湿ALD)　通信ﾒｯｾｰｼﾞ処理ﾓｼﾞｭｰﾙ
'作成日：2018/07/31 (Tue) 14:13:48 Y.Yoneyama
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2018-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0151
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public==========================================
    '@vsfAreaEquipmentの定数宣言
    Public Const CMlngvsfAreaEqColNo                   As Integer = 0              '№
    Public Const CMlngvsfAreaEqColKb                   As Integer = 1              '保/停区分
    Public Const CMlngvsfAreaEqColNowSt                As Integer = 2              '状態
    Public Const CMlngvsfAreaEqColLimitTime            As Integer = 3              '時間制限
    Public Const CMlngvsfAreaEqColRecipe               As Integer = 4              'ﾚｼﾋﾟ
    Public Const CMlngvsfAreaEqColPdID                 As Integer = 5              '機種
    Public Const CMlngvsfAreaEqColLotID                As Integer = 6              'ﾛｯﾄID
    Public Const CMlngvsfAreaEqColWfId                 As Integer = 7              'WFIDの下3桁の結合("#01,#02,#03,#04,#05")
    Public Const CMlngvsfAreaEqColWfNum                As Integer = 8              'WF枚数
    Public Const CMlngvsfAreaEqColChipNum              As Integer = 9              'ﾁｯﾌﾟ数
    Public Const CMlngvsfAreaEqColCarrierID            As Integer = 10             'ｷｬﾘｱID
    Public Const CMlngvsfAreaEqColACarrierID           As Integer = 11             'AｷｬﾘｱID
    Public Const CMlngvsfAreaEqColTapeBatchID          As Integer = 12             'ﾃｰﾌﾟﾊﾞｯﾁID
    Public Const CMlngvsfAreaEqColOvenBatchID          As Integer = 13             'ｵｰﾌﾞﾊﾞｯﾁID
    Public Const CMlngvsfAreaEqColALDBatchID           As Integer = 14             'ALDﾊﾞｯﾁID
    Public Const CMlngvsfAreaEqColMonitorUseFlag       As Integer = 15
    Public Const CMlngvsfAreaEqColFlowClass            As Integer = 16             '種別
    Public Const CMlngvsfAreaEqColPriority             As Integer = 17             '優先順位
    Public Const CMlngvsfAreaEqColLcDirection          As Integer = 18             '液晶方向
    Public Const CMlngvsfAreaEqColOpID                 As Integer = 19             '大工程
    Public Const CMlngvsfAreaEqColStepID               As Integer = 20             '小工程
    Public Const CMlngvsfAreaEqColLotManagerName       As Integer = 21             'ﾛｯﾄ担当
    Public Const CMlngvsfAreaEqColLotComments          As Integer = 22             'ｺﾒﾝﾄ
    Public Const CMlngvsfAreaEqColALDProcessNum        As Integer = 23             '防湿ALD処理番号
    Public Const CMlngvsfAreaEqColALDProcessName       As Integer = 24             '防湿ALD処理名
    Public Const CMlngvsfAreaEqColBatchFlowClass       As Integer = 25


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：pubblnLotListALD_Sel
    '機　能：新・ﾛｯﾄ一覧情報取得
    '引　数：ltypLotListReq ：要求ﾃﾞｰﾀ格納構造体
    '　　　：ltypLotList()  ：格納ﾃﾞｰﾀ
    '　　　：llngLotListCnt ：ﾃﾞｰﾀ件数
    '戻り値：True：正常、False：異常
    '作成日：2018/07/31 (Tue) 14:22:15 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnLotListALD_Sel(ByRef ltypLotListReq As LotListReq, _
                                      ByRef ltypLotListAns As LotListALDAns, _
                                      ByRef llngLotListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        Dim llngCnt2            As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        pubblnLotListALD_Sel = False

        Try

            '@各種初期設定
            pstrMessageName = "ロット一覧情報取得(防湿ALD)"
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            lrAry = New TfMsgAry
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotListReq
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                     Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_listald_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    With ltypLotListAns
                        
                        Call laMsg.getString(CPstrWP_TYPE_FLAG, .strWpTypeFlag)                     'WPﾀｲﾌﾟﾌﾗｸﾞ
                        Call laMsg.getString(CPstrUSE_ID, .strUseId)                                '用途ID
                        Call laMsg.getString(CPstrUSE_NAME, .strUseName)                            '用途名
                        Call laMsg.getString(CPstrMES_MODE_ID, .strMesModeId)                       '運用ﾓｰﾄﾞ
                        Call laMsg.getString(CPstrWP_STOP_FLAG, .strWpStopFlag)                     'WP停止ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrWP_STATUS_NAME, .strWpStatusName)                 '装置状態名
                        Call laMsg.getString(CPstrMC_TYPE, .strMcType)                              '装置ﾀｲﾌﾟ(Normal,Batch,Exdummy)
                    End With
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    llngLotListCnt = laAry.Count
                    
                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngLotListCnt > 0 Then
                    
                        '@配列領域の確保
                        If IsNothing(ltypLotListAns.typLotList) Then
                            ltypLotListAns.typLotList = New List(Of LotListLotListALD)()
                        Else
                            ltypLotListAns.typLotList.Clear()
                        End If
                        
                        '@ｶｳﾝﾀの初期化
                        llngCnt = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        For Each ltMsg In laAry
                            Dim tmpLotListAns As LotListLotListALD = New LotListLotListALD()
                        
                            '@受信結果取得
                            With tmpLotListAns
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                Call ltMsg.getString(CPstrNOW_ST, .strNowST)                                'ﾛｯﾄ状態
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                     'ﾛｯﾄ担当者名
                                Call ltMsg.getString(CPstrWF_NUM, .strWfNum)                                'WF枚数
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                  'ﾁｯﾌﾟ
                                Call ltMsg.getString(CPstrLOT_COMMENTS_FLAG, .strLotCommentsFlg)            'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                   'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)                   'ﾛｯﾄ停止ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                                Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)                          'ﾚｼﾋﾟID
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                    '液晶方向
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               'LOT最終更新日時
                                Call ltMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)             '制限ﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                        '制限時間(時間制約)
                                Call ltMsg.getString(CPstrWARN_TIME, .strWarnTime)                          '警告時間
                                Call ltMsg.getString(CPstrTO_OP_ID, .strToOpId)                             '制限時間先大工程
                                Call ltMsg.getString(CPstrTO_STEP_ID, .strToStepId)                         '制限時間先小工程
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                         '送品先
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種ID
                                Call ltMsg.getString(CPstrPD_VERSION, .strPdVersion)                        '機種Ver
                                Call ltMsg.getString(CPstrVA_FLAG, .strVaFlag)                              '無機ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                              'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
                                Call ltMsg.getString(CPstrALD_PROCESS_NUM, .strALDProcessNum)               'ALD処理番号
                                Call ltMsg.getString(CPstrALD_PROCESS_NAME, .strALDProcessName)             'ALD処理名
                                Call ltMsg.getString(CPstrTAPE_STICK_BATCH_ID, .strTapeBatchId)             'ﾃｰﾌﾟﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrOVEN_BATCH_ID, .strOvenBatchId)                   'ｵｰﾌﾞﾝﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrALD_BATCH_ID, .strAldBatchId)                     'ALDﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrA_CARRIER_ID, .strACarrierId)                     'AｷｬﾘｱID
                                Call ltMsg.getString(CPstrBATCH_FLOW_CLASS, .strBatchFlowClass)
                                Call ltMsg.getString(CPstrMONITOR_USE_FLAG, .strMonitorUseFlag)

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：WFﾘｽﾄ
                                Call ltMsg.getMsgAry(CPstrWF_LIST, laAry2)
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2数：WFﾘｽﾄﾃﾞｰﾀ数
                                .lngWfListCnt = laAry2.Count
                                
                                '@WFﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                If .lngWfListCnt > 0 Then
                                
                                    '@配列領域の確保
                                    If IsNothing(.typWfList) Then
                                        .typWfList = New List(Of LotListWfList)()
                                    End If
                                    
                                    '@ｶｳﾝﾀの初期化
                                    llngCnt2 = 0
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                                    For Each ltMsg2 In laAry2
                                        Dim tmpWfList As LotListWfList = New LotListWfList()
                                    
                                        '@WFIDを格納
                                        Call ltMsg2.getString(CPstrWF_ID, tmpWfList.strWfId)

                                        .typWfList.Add(tmpWfList)
                                        
                                        '@ｶｳﾝﾀ2を+1する
                                        llngCnt2 = llngCnt2 + 1
                                    Next
                                End If
                            End With
                            
                            ltypLotListAns.typLotList.Add(tmpLotListAns)

                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotListALD_Sel = True
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypLotListReq.strMsgVer)
                    
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
            laAry2 = Nothing
            ltMsg2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrAry = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

End Module
