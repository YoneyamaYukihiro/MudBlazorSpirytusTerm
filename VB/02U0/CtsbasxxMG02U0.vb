Option Explicit On
Imports TFLib

''' <summary>
''' ODF予約関連のFunction
''' </summary>
Public Module basxxMG02U0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    ''' <summary>
    ''' ODF予約可能なTFT/CFの機種リスト取得
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="ltypTFTandCFList"></param>
    ''' <returns></returns>
    Public Function pubblnOdfTftCfList_Sel(ByVal lstrMsgVer As String, _
                                           ByRef ltypTFTandCFList As List(Of typTFTandCF)) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET As String = vbNullString
        
        Try

            '@初期設定
            pstrMessageName = "TFT/CF貼り合せ機種取得"
            pubblnOdfTftCfList_Sel = False
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
                            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_odftftcflist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                   With ltypTFTandCFList
                    
                        '@ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrPD_ID_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                            For Each ltMsg In laAry
                                Dim tmp As New typTFTandCF
                                With tmp
                                    Call ltMsg.getString(CPstrPD_ID, .strPdId)                  'TFT機種ID
                                    Call ltMsg.getString(CPstrPD_VERSION, .strPdVersion)        'TFT機種バージョン
                                    Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)    '液晶方向
                                    Call ltMsg.getString(CPstrCF_PD_ID, .strCfPdId)             'CF機種ID
                                    Call ltMsg.getString(CPstrCF_PD_VERSION, .strCfPdVersion)   'CF機種バージョン

                                    '@★ L/Rにより処理分岐 ※背景色を格納する(組立工程の機種ｺﾝﾎﾞで使用する) ★
                                    Select Case .strLcDirection
                                    
                                        '@〓 L 〓
                                        Case CPstrPDIDL
                                            .strBackColor = CPlngLColor     '水色
                                            .strForeColor = vbNullString    'NULL
                                        
                                        '@〓 R 〓
                                        Case CPstrPDIDR
                                            .strBackColor = CPlngRColor     'ﾋﾟﾝｸ
                                            .strForeColor = vbNullString    'NULL
                                        
                                        '@〓 その他 〓
                                        Case Else
                                            .strBackColor = vbNullString    'NULL
                                            .strForeColor = vbNullString    'NULL

                                    End Select                                    
                                End With
                                .add(tmp)
                            Next
                        End If
                    
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnOdfTftCfList_Sel = True
                    
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
                     
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 貼り合わせ予約可能一覧
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="lstrPdId"></param>
    ''' <param name="lstrCfPdId"></param>
    ''' <param name="ltypOdfReserveInfo"></param>
    ''' <returns></returns>
    Public Function pubblnOdfReserveList_Sel(ByVal lstrMsgVer As String, _
                                            ByVal lstrPdId As String, ByVal lstrCfPdId As String, _
                                           ByRef ltypOdfReserveInfo As List(Of typOdfReserveRep)) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET As String = vbNullString
        
        Try

            '@初期設定
            pstrMessageName = "貼り合わせ予約可能一覧"
            pubblnOdfReserveList_Sel = False

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
                     
            '@TFT側PDID
            If lstrPdId <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdId)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If

            '@CF側PDID
            If lstrCfPdId <> vbNullString Then
                Call lrMsg.addString(CPstrCF_PD_ID, lstrCfPdId)
            Else
                Call lrMsg.addString(CPstrCF_PD_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_odfreservelist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    With ltypOdfReserveInfo
                    
                        '@ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                            For Each ltMsg In laAry
                                Dim tmp As typOdfReserveRep
                                With tmp
                                    Call ltMsg.getString(CPstrPD_ID, .strPdId)                
                                    Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)        
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotId)    
                                    Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)
                                    Call ltMsg.getString(CPstrWF_ID, .strWfId) 
                                    Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)
                                    Call ltMsg.getString(CPstrRESERVE_FLAG, .strReserveFlag)                                   
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                                   
                                    Call ltMsg.getString(CPstrCURRENT_STATUS, .strCurrentStatus)                                   
                                    Call ltMsg.getString(CPstrCURRENT_STATUS_NAME, .strCurrentStatusName)                                   
                                End With
                                .add(tmp)
                            Next
                        End If
                    
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnOdfReserveList_Sel = True
                    
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
                        
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

    ''' <summary>
    ''' ODF予約情報更新(登録・削除)
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="ltyptypOdfReserveRegist"></param>
    ''' <returns></returns>
    Public Function pubblnOdfReserveRegist_Upd(ByVal lstrMsgVer As String, ByVal lstrRegType As String,
            ByRef ltyptypOdfReserveRegist As List(Of typOdfReserveRegist), 
            ByRef lstrHReserveFlag As String) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lrMsg2 As New TfMsg            
        Dim lrAry As New TfMsgAry
        Dim lstrRET As String = vbNullString

        Try

            '@初期設定
            pstrMessageName = "貼り合わせ予約登録/解除"
            pubblnOdfReserveRegist_Upd = False
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
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

            '登録タイプ
            If lstrRegType <> vbNullString Then
                Call lrMsg.addString(CPstrREGIST_TYPE, lstrRegType)
            Else
                Call lrMsg.addString(CPstrREGIST_TYPE, CPstrMsgNull)
            End If

            Dim lstrTFTLotId = vbNullString
            Dim lstrCFLotId = vbNullString

            'WFLIST
            For Each tmp As typOdfReserveRegist In ltyptypOdfReserveRegist

                Call lrMsg2.addString(CPstrWF_ID, tmp.strWfId)
                Call lrMsg2.addString(CPstrCF_WF_ID, tmp.strCfWfId)
                Call lrMsg2.addString(CPstrLOT_ID, tmp.strLotId)
                Call lrMsg2.addString(CPstrCF_LOT_ID, tmp.strCfLotId)
                Call lrMsg2.addString(CPstrCARRIER_ID, tmp.strCarrierId)
                Call lrMsg2.addString(CPstrCF_CARRIER_ID, tmp.strCfCarrierId)
                Call lrMsg2.addString(CPstrSLOT_POSITION, tmp.strSlotPosition)

                If lstrTFTLotId = vbNullString Then
                    lstrTFTLotId = tmp.strLotId
                End If

                If lstrCFLotId = vbNullString Then
                    lstrCFLotId = tmp.strCfLotId
                End If

                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
            Next
            
            'LOT_ID
            If lstrTFTLotId <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrTFTLotId)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            'CF_LOT_ID
            If lstrCFLotId <> vbNullString Then
                Call lrMsg.addString(CPstrCF_LOT_ID, lstrCFLotId)
            Else
                Call lrMsg.addString(CPstrCF_LOT_ID, CPstrMsgNull)
            End If

            Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
            lrAry.Clear
                     
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_odfreserveregist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@ｱﾚｰを取得
                    Call laMsg.getString(CPstrH_RESERVE_FLAG, lstrHReserveFlag)    

                    '@関数の処理結果(成功)格納
                    pubblnOdfReserveRegist_Upd = True
                    
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

            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
        End Try
    End Function

    ''' <summary>
    ''' ODF予約情報の取得
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="lstrLotId"></param>
    ''' <param name="lstrWfId"></param>
    ''' <param name="ltypOdfReserveInfo"></param>
    ''' <returns></returns>
    Public Function pubblnOdfReserveInfo_Sel(ByVal lstrMsgVer As String, _
                                            ByVal lstrLotId As String, ByVal lstrWfId As String, _
                                            ByRef ltypOdfReserveInfo As List(Of typOdfReserveInfo)) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET As String = vbNullString
        
        Try

            '@初期設定
            pstrMessageName = "貼り合わせ予約情報"
            pubblnOdfReserveInfo_Sel = False

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
                     
            '@LOTID(TFT/CFどちらでも可)
            If lstrLotId <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotId)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            '@WFID(TFT/CFどちらでも可)
            If lstrWfId <> vbNullString Then
                Call lrMsg.addString(CPstrWF_ID, lstrWfId)
            Else
                Call lrMsg.addString(CPstrWF_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_odfreserveinfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                   With ltypOdfReserveInfo
                    
                        '@ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                            For Each ltMsg In laAry
                                Dim tmp = New typOdfReserveInfo
                                With tmp
                                    Call ltMsg.getString(CPstrWF_ID, .strWfId)
                                    Call ltMsg.getString(CPstrCF_WF_ID, .strCfWfId)
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotId)    
                                    Call ltMsg.getString(CPstrCF_LOT_ID, .strCFLotId)
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)
                                    Call ltMsg.getString(CPstrCF_CARRIER_ID, .strCfCarrierId) 
                                    Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)                                 
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                                 
                                    Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)                                 
                                    Call ltMsg.getString(CPstrCURRENT_LOT_ID, .strCurrentLotId)
                                    Call ltMsg.getString(CPstrCURRENT_CF_LOT_ID, .strCurrentCfLotId)
                                    Call ltMsg.getString(CPstrCURRENT_CARRIER_ID, .strCurrentCarrierId)
                                    Call ltMsg.getString(CPstrCURRENT_CF_CARRIER_ID, .strCurrentCfCarrierId) 
                                End With
                                .add(tmp)
                            Next
                        End If
                    
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnOdfReserveInfo_Sel = True
                    
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
            
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 表面処理群の予約情報
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="lstrSelectOpstion"></param>
    ''' <param name="ltypHyoumenReserveInfo"></param>
    ''' <returns></returns>
    Public Function pubblnHReserveInfo_Sel(ByVal lstrMsgVer As String, _
                ByVal lstrSelectOpstion As String, _
                ByRef ltypHyoumenReserveInfo As List(Of typHyoumenReserveInfo)) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET As String = vbNullString
        
        Try

            '初期設定
            pstrMessageName = "表面処理予約情報"
            pubblnHReserveInfo_Sel = False

            '送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '検索オプション
            If lstrSelectOpstion <> vbNullString Then
                Call lrMsg.addString(CPstrSELECT_OPTION, lstrSelectOpstion)
            Else
                Call lrMsg.addString(CPstrSELECT_OPTION, CPstrMsgNull)
            End If

            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_hreserveinfo, lrMsg, laMsg)

            '受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '結果判定
            Select Case lstrRET
                '成功の場合(true)
                Case CPstrTRUE
                
                   With ltypHyoumenReserveInfo
                    
                        'ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                            For Each ltMsg In laAry
                                Dim tmp = New typHyoumenReserveInfo
                                With tmp
                                    Call ltMsg.getString(CPstrWF_ID, .strWfId)
                                    Call ltMsg.getString(CPstrCF_WF_ID, .strCfWfId)
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotId)    
                                    Call ltMsg.getString(CPstrCF_LOT_ID, .strCFLotId)
                                    Call ltMsg.getString(CPstrCURRENT_LOT_ID, .strCurrentLotId)
                                    Call ltMsg.getString(CPstrCURRENT_CF_LOT_ID, .strCurrentCfLotId)
                                    Call ltMsg.getString(CPstrCURRENT_CARRIER_ID, .strCurrentCarrierId)
                                    Call ltMsg.getString(CPstrCURRENT_CF_CARRIER_ID, .strCurrentCfCarrierId)
                                    Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)
                                    Call ltMsg.getString(CPstrH_RESERVE_EMP_NAME, .strHReserveEmpName)                                 
                                    Call ltMsg.getString(CPstrH_RESERVE_TIME, .strHReserveTime)    
                                    Call ltMsg.getString(CPstrRECIPE_ID, .strHRecipeId)
                                End With
                                .add(tmp)
                            Next
                        End If
                    
                    End With

                    pubblnHReserveInfo_Sel = True
                    
                '失敗の場合(false)
                Case CPstrFALSE
                    
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                'その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 表面処理予約の情報更新(登録・削除)
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="ltypHyounenReserveRegist"></param>
    ''' <returns></returns>
    Public Function pubblnHyoumenReserveRegist_Upd(ByVal lstrMsgVer As String, ByVal lstrRegType As String,
            ByRef ltypHyounenReserveRegist As List(Of typHyoumenReserveRegist)) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lrMsg2 As New TfMsg            
        Dim lrAry As New TfMsgAry
        Dim lstrRET As String = vbNullString
        
        Try

            '@初期設定
            pstrMessageName = "表面処理予約登録/解除"
            pubblnHyoumenReserveRegist_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            lrMsg2 = New TfMsg
            lrAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
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

            '登録タイプ
            If lstrRegType <> vbNullString Then
                Call lrMsg.addString(CPstrREGIST_TYPE, lstrRegType)
            Else
                Call lrMsg.addString(CPstrREGIST_TYPE, CPstrMsgNull)
            End If


            'WFLIST
            For Each tmp As typHyoumenReserveRegist In ltypHyounenReserveRegist
                Call lrMsg2.addString(CPstrWF_ID, tmp.strWfId)
                Call lrMsg2.addString(CPstrCF_WF_ID, tmp.strCfWfId)
                Call lrMsg2.addString(CPstrLOT_ID, tmp.strLotId)
                Call lrMsg2.addString(CPstrCF_LOT_ID, tmp.strCfLotId)
                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
            Next
            Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
            lrAry.Clear
                     
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_hreserveregist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@関数の処理結果(成功)格納
                    pubblnHyoumenReserveRegist_Upd = True
                    
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
                        
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrMsg2 = Nothing         
            lrAry = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 表面処理の予約グループ
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="lstrLotId"></param>
    ''' <param name="ltypHyoumenReserveGroup"></param>
    ''' <returns></returns>
    Public Function pubblnHReserveGroup_Sel(ByVal lstrMsgVer As String, _
                ByVal lstrLotId As String, _
                ByRef ltypHyoumenReserveGroup As List(Of typHyoumenReserveGroup)) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET As String = vbNullString
        
        Try

            '初期設定
            pstrMessageName = "表面処理予約グループ"
            pubblnHReserveGroup_Sel = False
            
            '送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            'LOTID
            If lstrLotId <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotId)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_hreservegroup, lrMsg, laMsg)

            '受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '結果判定
            Select Case lstrRET
                '成功の場合(true)
                Case CPstrTRUE
                
                   With ltypHyoumenReserveGroup
                    
                        'ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                            For Each ltMsg In laAry
                                Dim tmp = New typHyoumenReserveGroup
                                With tmp
                                    Call ltMsg.getString(CPstrH_RESERVE_TIME, .strHReserveTime)
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotId)
                                    Call ltMsg.getString(CPstrWF_ID, .strWfId)
                                    Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)
                                End With
                                .add(tmp)
                            Next
                        End If
                    
                    End With

                    pubblnHReserveGroup_Sel = True
                    
                '失敗の場合(false)
                Case CPstrFALSE
                    
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                'その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
                        
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 現在のCFロット情報を取得する
    ''' ODF貼り合せ予約情報を参照しているので無い場合もある
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="lstrLotId"></param>
    ''' <param name="ltypCurCfLotInfo"></param>
    ''' <returns></returns>
    Public Function pubblnCurCfLotInfo_Sel(ByVal lstrMsgVer As String, _
                ByVal lstrLotId As String, _
                ByRef ltypCurCfLotInfo As List(Of typCurCfLotInfo)) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET As String = vbNullString
        
        Try

            '初期設定
            pstrMessageName = "現在のCFロット情報の取得"
            pubblnCurCfLotInfo_Sel = False
            
            '送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            'LOTID
            If lstrLotId <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotId)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_curcflotinfo, lrMsg, laMsg)

            '受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '結果判定
            Select Case lstrRET
                '成功の場合(true)
                Case CPstrTRUE
                
                   With ltypCurCfLotInfo
                    
                        'ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                            For Each ltMsg In laAry
                                Dim tmp = New typCurCfLotInfo
                                With tmp
                                    Call ltMsg.getString(CPstrCURRENT_CF_LOT_ID, .strCfLotId)
                                    Call ltMsg.getString(CPstrWF_NUM, .strWfNum)

                                End With
                                .add(tmp)
                            Next
                        End If
                    
                    End With

                    pubblnCurCfLotInfo_Sel = True
                    
                '失敗の場合(false)
                Case CPstrFALSE
                    
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                'その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 貼り合せ予約とのチェック
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <param name="lstrLotId"></param>
    ''' <param name="lstrCfLotId"></param>
    ''' <param name="lstrCarrierId"></param>
    ''' <param name="lstrCfCarrierId"></param>
    ''' <param name="lstrResult"></param>
    ''' <param name="ltypChkOdfReserve"></param>
    ''' <returns></returns>
    Public Function pubblnChkOdfReserve(ByVal lstrMsgVer As String, _
                ByVal lstrLotId As String, ByVal lstrCfLotId As String, _
                ByVal lstrCarrierId As String, ByVal lstrCfCarrierId As String, _
                ByRef lstrResult As String, _
                ByRef ltypChkOdfReserve As List(Of typChkOdfReserve)) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET As String = vbNullString
        
        Try
        
            '初期設定
            pstrMessageName = "貼り合せ予約とのチェック"
            pubblnChkOdfReserve = False
            
            '送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            'LOT_ID
            If lstrLotId <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotId)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            'CF_LOT_ID
            If lstrCfLotId <> vbNullString Then
                Call lrMsg.addString(CPstrCF_LOT_ID, lstrCfLotId)
            Else
                Call lrMsg.addString(CPstrCF_LOT_ID, CPstrMsgNull)
            End If


            'CARRIER_ID
            If lstrCarrierId <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierId)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If

            'CF_CARRIER_ID
            If lstrCarrierId <> vbNullString Then
                Call lrMsg.addString(CPstrCF_CARRIER_ID, lstrCfCarrierId)
            Else
                Call lrMsg.addString(CPstrCF_CARRIER_ID, CPstrMsgNull)
            End If


            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrasm_chkodfreserve, lrMsg, laMsg)

            '受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '結果判定
            Select Case lstrRET
                '成功の場合(true)
                Case CPstrTRUE
                    
                    Call laMsg.getString(CPstrRESULT, lstrResult)

                    With ltypChkOdfReserve
                    
                        'ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                            For Each ltMsg In laAry
                                Dim tmp = New typChkOdfReserve
                                With tmp
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotId)
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)
                                    Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)
                                    Call ltMsg.getString(CPstrWF_ID, .strWfId)
                                    Call ltMsg.getString(CPstrCF_WF_ID, .strCfWfId)
                                    Call ltMsg.getString(CPstrCF_LOT_ID, .strCfLotId)
                                    Call ltMsg.getString(CPstrCF_CARRIER_ID, .strCfCarrierId)
                                    Call ltMsg.getString(CPstrCF_SLOT_POSITION, .strCfSlotPosition)

                                End With
                                .add(tmp)
                            Next
                        End If
                    
                    End With

                    pubblnChkOdfReserve = True
                    
                '失敗の場合(false)
                Case CPstrFALSE
                    
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                'その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

	''' <summary>
    ''' 流動予約情報取得
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <returns></returns>
    Public Function pubblnGetAfterJReserveDetail(ByVal lstrMsgVer As String, _
				ByVal lstrCarrierId As String,  _
                ByVal lstrLotId As String,  _
				ByVal lstrReserveId As String,  _
				ByVal lstrReserveGroup As String,  _
				ByVal lstrClassDivision As String,  _
                ByRef ltypWflist As List(Of WfList), _
				ByRef ltypAfterJReserveDetailList As AfterJReserveDetailList )As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lrMsg2 As New TfMsg            
        Dim lrAry As New TfMsgAry
        Dim lstrRET As String = vbNullString
        
        Try
        
            '初期設定
            pstrMessageName = "蒸着後流動予約情報詳細取得"
            pubblnGetAfterJReserveDetail = False
            
            '送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
			'CLASS_DIVISION
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If

            'LOT_ID
            If lstrLotId <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotId)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            'CARRIER_ID
            If lstrCarrierId <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierId)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If

			'RESERVE_ID
            If lstrReserveId <> vbNullString Then
                Call lrMsg.addString(CPstrRESERVE_ID, lstrReserveId)
            Else
                Call lrMsg.addString(CPstrRESERVE_ID, CPstrMsgNull)
            End If

			'RESERVE_GROUP
            If lstrReserveGroup <> vbNullString Then
                Call lrMsg.addString(CPstrRESERVE_GROUP, lstrReserveGroup)
            Else
                Call lrMsg.addString(CPstrRESERVE_GROUP, CPstrMsgNull)
            End If

			'WFLIST
            For Each tmp As Wflist In ltypWflist

                Call lrMsg2.addString(CPstrWF_ID, tmp.strWfId)
                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
            Next
            

            Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
            lrAry.Clear


            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_afterjrsvdetail, lrMsg, laMsg)

            '受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '結果判定
            Select Case lstrRET
                '成功の場合(true)
                Case CPstrTRUE
                    

                    With ltypAfterJReserveDetailList
                    
                        'ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrAFTER_J_RESERVE_DETAIL_LIST, laAry)
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then


							 '配列準備
							.lngAfterJReserveDetailListCnt = laAry.Count
							'ReDim .typAtraytList(.lngAtraytListCnt)
							If IsNothing(.typAfterJReserveDetailList) Then
								.typAfterJReserveDetailList = New List(Of typAfterJReserveDetail)
							Else
								.typAfterJReserveDetailList.Clear()
							End If                            


                            For Each ltMsg In laAry
                                Dim tmp = New typAfterJReserveDetail
                                With tmp
									Call ltMsg.getString(CPstrRESERVE_ID, .strReserveId)
                                    Call ltMsg.getString(CPstrWF_ID, .strWfId)
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotId)
									Call ltMsg.getString(CPstrRESERVE_GROUP, .strReserveGroup)
									Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)
									Call ltMsg.getString(CPstrMOVE_COMPLETE_FLAG, .strMoveCompleteFlag)
                                    Call ltMsg.getString(CPstrEMP_ID, .strEmpId)
									Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)

                                End With
                                .typAfterJReserveDetailList.add(tmp)
                            Next

							Call laMsg.getString(CPstrNG_FLAG, .strNGFlag)

                        End If
                    
                    End With

                    pubblnGetAfterJReserveDetail = True
                    
                '失敗の場合(false)
                Case CPstrFALSE
                    
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                'その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

	''' <summary>
    ''' 蒸着後流動予約情報一覧取得
    ''' </summary>
    ''' <param name="lstrMsgVer"></param>
    ''' <returns></returns>
    Public Function pubblnGetAfterJReserveList(ByVal lstrMsgVer As String, _
				ByRef ltypAfterJReserveList As AfterJReserveList )As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lrMsg2 As New TfMsg            
        Dim lrAry As New TfMsgAry
        Dim lstrRET As String = vbNullString
        
        Try
        
            '初期設定
            pstrMessageName = "蒸着後流動予約情報一覧取得"
            pubblnGetAfterJReserveList = False
            
            '送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            

            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_afterjrsvlist, lrMsg, laMsg)

            '受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '結果判定
            Select Case lstrRET
                '成功の場合(true)
                Case CPstrTRUE
                    

                    With ltypAfterJReserveList
                    
                        'ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrAFTER_J_RESERVE_LIST, laAry)
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then


							 '配列準備
							.lngAfterJReserveListCnt = laAry.Count
							If IsNothing(.typAfterJReserveList) Then
								.typAfterJReserveList = New List(Of typAfterJReserve)
							Else
								.typAfterJReserveList.Clear()
							End If                            


                            For Each ltMsg In laAry
                                Dim tmp = New typAfterJReserve
                                With tmp
									Call ltMsg.getString(CPstrRESERVE_ID, .strReserveId)
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotId)
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)
									Call ltMsg.getString(CPstrEMP_ID, .strEmpId)
									Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)
                                End With
                                .typAfterJReserveList.add(tmp)
                            Next

                        End If
                    
                    End With

                    pubblnGetAfterJReserveList = True
                    
                '失敗の場合(false)
                Case CPstrFALSE
                    
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                'その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
        End Try
    End Function

	Public Function pubblnAfterJReserveRegist_Ins(ByVal lstrMsgVer As String, ByVal lstrRegType As String, _
												  ByVal lstrLotId As String, _
													ByRef ltypAfterJReservelist As List(Of typAfterJReserveDetail), _
													ByRef lstrReserveId As String _ 
													) As Boolean

        Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lrMsg2 As New TfMsg            
        Dim lrAry As New TfMsgAry
        Dim lstrRET As String = vbNullString

        Try

            '@初期設定
            pstrMessageName = "蒸着後流動予約登録/解除"
            pubblnAfterJReserveRegist_Ins = False
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
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

			'@ロットID取得
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotId)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            '登録タイプ
            If lstrRegType <> vbNullString Then
                Call lrMsg.addString(CPstrREGIST_TYPE, lstrRegType)
            Else
                Call lrMsg.addString(CPstrREGIST_TYPE, CPstrMsgNull)
            End If
			
			'予約ID(削除用)
            If lstrReserveId <> vbNullString Then
                Call lrMsg.addString(CPstrRESERVE_ID, lstrReserveId)
            Else
                Call lrMsg.addString(CPstrRESERVE_ID, CPstrMsgNull)
            End If

            'LIST
            For Each tmp As typAfterJReserveDetail In ltypAfterJReservelist

                Call lrMsg2.addString(CPstrWF_ID, tmp.strWfId)
                Call lrMsg2.addString(CPstrSLOT_POSITION, tmp.strSlotPosition)
                Call lrMsg2.addString(CPstrRESERVE_GROUP, tmp.strReserveGroup)
                Call lrMsg2.addString(CPstrCARRIER_ID, tmp.strCarrierId)


                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
            Next
            

            Call lrMsg.addMsgAry(CPstrAFTER_J_RESERVE_LIST, lrAry)
            lrAry.Clear
                     
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_afterjrsvregist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
					
					Call laMsg.getString(CPstrRESERVE_ID, lstrReserveId)

                    '@関数の処理結果(成功)格納
                    pubblnAfterJReserveRegist_Ins = True
                    
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

            Exit Function
            
        Catch ex As Exception
            Call pubErrMsg_Proc(Err)

        Finally
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
        End Try
    End Function

End Module

 