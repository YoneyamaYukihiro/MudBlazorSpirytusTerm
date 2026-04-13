'ﾌｧｲﾙ名：xxMG01V0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置使用部材管理 標準ﾓｼﾞｭｰﾙ（Msg用）
'作成日：2006/04/13 (Thu) 17:07:00 N.Kojima
'更新日：2006/11/28 (Tue) 18:11:55 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01V0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubblnMasMaterialType_Sel
    '機　能：部材種別取得
    '引　数：lstrmas_materialtypeVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypMaterialType           ：部材種別構造体
    '戻り値：True：成功、False：失敗
    '作成日：2006/04/12 (Wed) 17:46:33 N.Kojima
    '更新日：2006/10/03 (Tue) 16:53:00 N.Kojima
    '備　考：
    '　　　：2006/10/03 (Tue) 16:53:00 N.Kojima     応答に"PD_LIMIT_FLAG"を追加
    Public Function pubblnMasMaterialType_Sel(ByVal lstrmas_materialtypeVer As String, _
                                              ByRef ltypMaterialType As MaterialWPList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "部材種別取得"
            pubblnMasMaterialType_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            'SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_materialtypeVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_materialtypeVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_materialtype, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrMATERIAL_TYPE_LIST, laAry)
                    
                    '@部材種別数を格納
                    ltypMaterialType.lngMaterialTypeCnt = laAry.Count
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypMaterialType.lngMaterialTypeCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        '@配列の要素数を設定
                        If ltypMaterialType.typMaterialTypeList Is Nothing Then 
                            ltypMaterialType.typMaterialTypeList = New List(Of MaterialTypeList) 
                        Else 
                            ltypMaterialType.typMaterialTypeList.Clear 
                        End If
                        Dim MaterialTypeListRec As MaterialTypeList
                        MaterialTypeListRec = New MaterialTypeList 

                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With MaterialTypeListRec
                                Call ltMsg.getString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)     '部材種別ID
                                Call ltMsg.getString(CPstrPD_LIMIT_FLAG, .strPdLimitFlag)           '機種限定ﾌﾗｸﾞ
                            End With
                            ltypMaterialType.typMaterialTypeList.Add (MaterialTypeListRec)
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasMaterialType_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_materialtypeVer)
                    
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
            ltMsg = Nothing
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
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnMasMaterial_Sel
    '機　能：部材取得
    '引　数：lstrmas_materialVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrMaterialTypeID     ：部材種別ID
    '　　　：ltypMaterial           ：部材構造体
    '戻り値：True：成功、False：失敗
    '作成日：2006/04/13 (Thu) 14:42:31 N.Kojima
    '更新日：2006/10/18 (Wed) 18:42:05 N.Kojima
    '備　考：
    '　　　：2006/10/18 (Wed) 18:42:05 N.Kojima     応答に"ORDER_REMAIN_NUM"追加。(案件№01095)
    Public Function pubblnMasMaterial_Sel(ByVal lstrmas_materialVer As String, _
                                          ByVal lstrMaterialTypeID As String, _
                                          ByRef ltypMaterial As MaterialTypeList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "部材取得"
            pubblnMasMaterial_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            'SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_materialVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_materialVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@部材管理ID
            If lstrMaterialTypeID <> vbNullString Then
                Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, lstrMaterialTypeID)
            Else
                Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_material, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrMATERIAL_LIST, laAry)
                    
                    '@部材種別数を格納
                    ltypMaterial.lngMaterialCnt = laAry.Count
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypMaterial.lngMaterialCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        '@配列の要素数を設定
                        If ltypMaterial.typMaterialIDList Is Nothing Then 
                            ltypMaterial.typMaterialIDList = New List(Of MaterialIDList) 
                        Else 
                            ltypMaterial.typMaterialIDList.Clear 
                        End If
                        Dim MaterialIDListRec As MaterialIDList
                        MaterialIDListRec = New MaterialIDList 
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With MaterialIDListRec
                                Call ltMsg.getString(CPstrMATERIAL_ID, .strMaterialID)              '部材ID
                                Call ltMsg.getString(CPstrORDER_REMAIN_NUM, .strOrderRemainNum)     '発注ﾎﾟｲﾝﾄ
                            End With
                            ltypMaterial.typMaterialIDList.Add(MaterialIDListRec)
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasMaterial_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_materialVer)
                    
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
            ltMsg = Nothing
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
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnMasMaterialWP_Sel
    '機　能：部材使用装置取得
    '引　数：lstrmas_materialwpVer      ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrMaterialTypeID         ：部材種別ID
    '　　　：lstrMaterialID             ：部材ID
    '　　　：ltypMaterialWP             ：部材使用装置格納構造体
    '戻り値：True：成功、False：失敗
    '作成日：2006/04/13 (Thu) 14:46:36 N.Kojima
    '更新日：2006/04/13 (Thu) 14:46:36
    '備　考：
    Public Function pubblnMasMaterialWP_Sel(ByVal lstrmas_materialwpVer As String, _
                                            ByVal lstrMaterialTypeID As String, _
                                            ByVal lstrMaterialID As String, _
                                            ByRef ltypMaterialWP As MaterialWP) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "部材使用装置取得"
            pubblnMasMaterialWP_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            'SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_materialwpVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_materialwpVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@部材管理ID
            If lstrMaterialTypeID <> vbNullString Then
                Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, lstrMaterialTypeID)
            Else
                Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
            End If
            
            '@部材ID
            If lstrMaterialID <> vbNullString Then
                Call lrMsg.addString(CPstrMATERIAL_ID, lstrMaterialID)
            Else
                Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_materialwp, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrWP_LIST, laAry)
                    
                    '@部材種別数を格納
                    ltypMaterialWP.lngMaterialWPCnt = laAry.Count
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypMaterialWP.lngMaterialWPCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        '@配列の要素数を設定
                        If ltypMaterialWP.typMaterialWPList Is Nothing Then 
                            ltypMaterialWP.typMaterialWPList = New List(Of MaterialWPList) 
                        Else 
                            ltypMaterialWP.typMaterialWPList.Clear 
                        End If

                        Dim MaterialWPListRec As MaterialWPList
                        MaterialWPListRec = New MaterialWPList 

                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With MaterialWPListRec
                                Call ltMsg.getString(CPstrWP_ID, .strWpID)          '装置ID
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)      '装置名
                            End With
                            ltypMaterialWP.typMaterialWPList.Add(MaterialWPListRec)
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasMaterialWP_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_materialwpVer)
                    
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
            ltMsg = Nothing
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
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnMatAllList_Sel
    '機　能：装置使用部材一覧取得
    '引　数：lstrmat_alllist_Ver    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrMaterialTypeID     ：部材種別ID
    '　　　：lstrMaterialID         ：部材ID
    '　　　：lstrWPID               ：装置ID
    '　　　：ltypMaterialAll        ：装置使用部材一覧格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2006/04/13 (Thu) 15:02:29 N.Kojima
    '更新日：2006/11/28 (Tue) 17:54:06 N.Kojima
    '備　考：
    '　　　：2006/11/28 (Tue) 17:54:06 N.Kojima     応答に"VENDER_WARRANT_WARNING_DAYS","ACCEPT_WARRANT_WARNING_DAYS",
    '　　　：                                       "VENDER_WARRANT_WARNING_DAYS_JUDGE","ACCEPT_WARRANT_WARNING_DAYS_JUDGE"を追加。(案件№01586)
    '　　　：2008/01/17 (Thu) 11:23:00 S.Ochiai     応答に"HOLD_FLAG"を追加。(案件№02463)
    '　　　：2009/09/28 (Mon) 14:09:00 T.Oide       単位追加
    '　　　：2009/11/17 (Tue) 16:30:42 T.Oide       単位追加(装置使用制限時間の単位)(№03820)
    Public Function pubblnMatAllList_Sel(ByVal lstrmat_alllist_Ver As String, _
                                         ByVal lstrMaterialTypeID As String, _
                                         ByVal lstrMaterialID As String, _
                                         ByVal lstrWpId As String, _
                                         ByRef ltypMaterialAll As MaterialAll) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET            As String            '応答取得

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@初期設定
            pstrMessageName = "装置使用部材一覧取得"
            pubblnMatAllList_Sel = False

            '@送信ﾒｯｾｰｼﾞ作成
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmat_alllist_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmat_alllist_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@部品種別ID
            If lstrMaterialTypeID <> vbNullString Then
                Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, lstrMaterialTypeID)
            Else
                Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
            End If
            
            '@部品ID
            If lstrMaterialID <> vbNullString Then
                Call lrMsg.addString(CPstrMATERIAL_ID, lstrMaterialID)
            Else
                Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
            End If
            
            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_alllist_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    With ltypMaterialAll
                    
                        '@受信結果取得
                        Call laMsg.getString(CPstrVENDER_WARRANT_DAYS, .strVenderWarrantDays)               'ﾒｰｶｰ保証期間
                        Call laMsg.getString(CPstrACCEPT_WARRANT_DAYS, .strAcceptWarrantDays)               '受入制限時間
        '@↓2009/09/28 (Mon) 14:08:41 T.Oide **************************************************
                        Call laMsg.getString(CPstrUNIT_CLASS_VWD, .strUnitClassVwd)                         '単位(ﾒｰｶｰ保証期間)
                        Call laMsg.getString(CPstrUNIT_CLASS_AWD, .strUnitClassAwd)                         '単位(受入制限時間)
        '@↑2009/09/28 (Mon) 14:08:41 T.Oide **************************************************
                        Call laMsg.getString(CPstrUSE_VALID_PERIOD, .strUseValidPeriod)                     '使用可能時間
        '@↓2009/11/17 (Tue) 16:33:46 T.Oide **************************************************
                        Call laMsg.getString(CPstrUNIT_CLASS_UVP, .strUnitClassUvp)                         '単位(装置使用可能期間)
        '@↑2009/11/17 (Tue) 16:33:46 T.Oide **************************************************
                        Call laMsg.getString(CPstrUSE_INVALID_PERIOD, .strUseInvalidPeriod)                 '使用禁止(不可)時間
                        Call laMsg.getString(CPstrWARNING_PERIOD, .strWarningPeriod)                        'ﾜｰﾆﾝｸﾞ表示時間
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                        Call laMsg.getMsgAry(CPstrMATERIAL_STATUS_LIST, laAry)
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                        .lngMaterialAllCnt = laAry.Count
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngMaterialAllCnt > 0 Then
                            
                            If .typMaterialAllList Is Nothing Then 
                                .typMaterialAllList = New List(Of MaterialAllList) 
                            Else 
                                .typMaterialAllList.Clear 
                            End If
                            Dim MaterialAllListRec As MaterialAllList 
                            MaterialAllListRec = New MaterialAllList 

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            For Each ltMsg In laAry
                                '@受信結果取得(ﾃﾞｰﾀ格納)
                                Call ltMsg.getString(CPstrMATERIAL_LOT_ID, MaterialAllListRec.strMaterialLotID)                       '部材管理ID
                                Call ltMsg.getString(CPstrMATERIAL_STATUS, MaterialAllListRec.strMaterialStatus)                      '部材状態
                                Call ltMsg.getString(CPstrWP_ID, MaterialAllListRec.strWpID)                                          '装置ID
                                Call ltMsg.getString(CPstrWP_NAME, MaterialAllListRec.strWpName)                                      '装置名
                                Call ltMsg.getString(CPstrPRODUCTION_DATE, MaterialAllListRec.strProductionDate)                      '製造日
                                Call ltMsg.getString(CPstrACCEPTANCE_DATE, MaterialAllListRec.strAcceptanceDate)                      '受入日
                                Call ltMsg.getString(CPstrUSE_TIME, MaterialAllListRec.strUseTime)                                    '使用開始日時
                                Call ltMsg.getString(CPstrVENDER_WARRANT_DAYS, MaterialAllListRec.strVenderWarrantDays)               'ﾒｰｶｰ保証期間
                                Call ltMsg.getString(CPstrACCEPT_WARRANT_DAYS, MaterialAllListRec.strAcceptWarrantDays)               '受入制限期間
                                Call ltMsg.getString(CPstrVENDER_WARRANT_WARNING_DAYS, MaterialAllListRec.strVenderWarrantWarningDays)        'ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間
                                Call ltMsg.getString(CPstrACCEPT_WARRANT_WARNING_DAYS, MaterialAllListRec.strAcceptWarrantWarningDays)        '受入制限ﾜｰﾆﾝｸﾞ期間
                                Call ltMsg.getString(CPstrUSE_VALID_PERIOD, MaterialAllListRec.strUseValidPeriod)                     '使用可能時間
                                Call ltMsg.getString(CPstrUSE_INVALID_PERIOD, MaterialAllListRec.strUseInvalidPeriod)                 '使用禁止(不可)時間
                                Call ltMsg.getString(CPstrWARNING_PERIOD, MaterialAllListRec.strWarningPeriod)                        'ﾜｰﾆﾝｸﾞ表示時間
                                Call ltMsg.getString(CPstrVENDER_WARRANT_DAYS_JUDGE, MaterialAllListRec.strVenderWarrantDaysJudge)    'ﾒｰｶｰ保証期間判定ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrACCEPT_WARRANT_DAYS_JUDGE, MaterialAllListRec.strAcceptWarrantDaysJudge)    '受入制限期間判定ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrVENDER_WARRANT_WARNING_DAYS_JUDGE, MaterialAllListRec.strVenderWarrantWarningDaysJudge)     'ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間判定ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrACCEPT_WARRANT_WARNING_DAYS_JUDGE, MaterialAllListRec.strAcceptWarrantWarningDaysJudge)     '受入制限ﾜｰﾆﾝｸﾞ期間判定ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrUSE_VALID_PERIOD_JUDGE, MaterialAllListRec.strUseValidPeriodJudge)          '使用可能時間判定ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrUSE_INVALID_PERIOD_JUDGE, MaterialAllListRec.strUseInvalidPeriodJudge)      '使用禁止(不可)時間判定ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrWARNING_PERIOD_JUDGE, MaterialAllListRec.strWarningPeriodJudge)             'ﾜｰﾆﾝｸﾞ表示時間判定ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrHOLD_FLAG, MaterialAllListRec.strHoldFlag)                                  '保留ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrEDIT_TIME, MaterialAllListRec.strEditTime)                                  '最終更新日時
                            
                                .typMaterialAllList.Add(MaterialAllListRec)
                            Next
                        End If
                    
                        '@関数の処理結果(成功)格納
                        pubblnMatAllList_Sel = True
                    End With

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmat_alllist_Ver)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
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

    '関数名：pubblnMatRegMaterial_Upd
    '機　能：装置使用部材登録/分割
    '引　数：ltypRegMaterial    ：装置使用部材登録用構造体
    '　　　：lstrEditTime       ：最終更新日時
    '戻り値：True：成功、False：失敗
    '作成日：2006/04/13 (Thu) 16:17:29 N.Kojima
    '更新日：2006/10/20 (Fri) 11:21:56 N.Kojima
    '備　考：
    '　　　：2006/10/20 (Fri) 11:21:56 N.Kojima     要求に"MATERIAL_ORDER_ID"追加。(案件№01095)
    Public Function pubblnMatRegMaterial_Upd(ByRef ltypRegMaterial As RegMaterial, _
                                             ByRef lstrEditTime As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        
        Try
            
            With ltypRegMaterial
            
                '@処理区分によってﾒｯｾｰｼﾞﾀｲﾄﾙを変更
                If .strClassDivision = CPstrCD39 Then
                    '@登録の場合
                    pstrMessageName = "装置使用部材登録"
                Else
                    '@分割の場合
                    pstrMessageName = "装置使用部材分割"
                End If
                
                pubblnMatRegMaterial_Upd = False
                
                lrMsg = New TfMsg
                laMsg = New TfMsg
                ltMsg = New TfMsg
                
                '@送信ﾒｯｾｰｼﾞ作成
                'SB_ID
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
                
                '@処理区分(39:新規登録、44:分割)
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@発注ID
                If .strMaterialOrderID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ORDER_ID, .strMaterialOrderID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ORDER_ID, CPstrMsgNull)
                End If
                
                '@部材種別ID
                If .strMaterialTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
                End If
                
                '@部材ID
                If .strMaterialID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ID, .strMaterialID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
                End If
                
                '@分割元部材管理ID
                If .strSrcMaterialLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrSRC_MATERIAL_LOT_ID, .strSrcMaterialLotID)
                Else
                    Call lrMsg.addString(CPstrSRC_MATERIAL_LOT_ID, CPstrMsgNull)
                End If
                
                '@分割先(新規登録)部材管理ID
                If .strMaterialLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, .strMaterialLotID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, CPstrMsgNull)
                End If
                
                '@製造日
                If .strProductionDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCTION_DATE, .strProductionDate)
                Else
                    Call lrMsg.addString(CPstrPRODUCTION_DATE, CPstrMsgNull)
                End If
                
                '@受入日
                If .strAcceptanceDate <> vbNullString Then
                    Call lrMsg.addString(CPstrACCEPTANCE_DATE, .strAcceptanceDate)
                Else
                    Call lrMsg.addString(CPstrACCEPTANCE_DATE, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_regmaterial, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrEDIT_TIME, lstrEditTime)        '最終更新日時
                    
                    '@関数の処理結果(成功)格納
                    pubblnMatRegMaterial_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypRegMaterial.strMsgVer)
                    
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
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMatChgMaterialDate_Upd
    '機　能：装置部材日付変更
    '引　数：ltypRegMaterial    ：装置部材日付変更用構造体
    '　　　：lstrEditTime       ：最終更新日時
    '戻り値：True：成功、False：失敗
    '作成日：2006/06/23 (Fri) 14:34:37 N.Kojima
    '更新日：2006/07/04 (Tue) 14:19:57 N.Kojima
    '備　考：
    Public Function pubblnMatChgMaterialDate_Upd(ByRef ltypRegMaterial As RegMaterial, _
                                                 ByRef lstrEditTime As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        
        Try
            
            With ltypRegMaterial
            
                '@ﾒｯｾｰｼﾞﾀｲﾄﾙ設定
                pstrMessageName = "装置使用部材日付変更"
                
                pubblnMatChgMaterialDate_Upd = False
                
                lrMsg = New TfMsg
                laMsg = New TfMsg
                ltMsg = New TfMsg
                
                '@送信ﾒｯｾｰｼﾞ作成
                'SB_ID
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

                '@部材種別ID
                If .strMaterialTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
                End If
                
                '@部材ID
                If .strMaterialID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ID, .strMaterialID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
                End If
                
                '@部材管理ID
                If .strMaterialLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, .strMaterialLotID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, CPstrMsgNull)
                End If
                
                '@製造日
                If .strProductionDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCTION_DATE, .strProductionDate)
                Else
                    Call lrMsg.addString(CPstrPRODUCTION_DATE, CPstrMsgNull)
                End If
                
                '@受入日
                If .strAcceptanceDate <> vbNullString Then
                    Call lrMsg.addString(CPstrACCEPTANCE_DATE, .strAcceptanceDate)
                Else
                    Call lrMsg.addString(CPstrACCEPTANCE_DATE, CPstrMsgNull)
                End If
                
                '@使用開始日時
                If .strUseTime <> vbNullString Then
                    Call lrMsg.addString(CPstrUSE_TIME, .strUseTime)
                Else
                    Call lrMsg.addString(CPstrUSE_TIME, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_chgmaterialdate, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrEDIT_TIME, lstrEditTime)        '最終更新日時
                    
                    '@関数の処理結果(成功)格納
                    pubblnMatChgMaterialDate_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypRegMaterial.strMsgVer)
                    
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
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMatChgMaterialState_Upd
    '機　能：装置使用部材状態変更
    '引　数：ltypRegMaterial    ：装置使用部材状態変更用構造体
    '　　　：lstrWpExcutingFlag ：装置処理実行中ﾌﾗｸﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2006/04/13 (Thu) 16:43:48 N.Kojima
    '更新日：2006/06/26 (Mon) 17:27:03 N.Kojima
    '備　考：
    '　　　：2006/06/26 (Mon) 17:27:03 N.Kojima     応答に"WP_EXECUTING_FLAG"追加。(ﾕｰｻﾞｰ要望№0189)
    Public Function pubblnMatChgMaterialState_Upd(ByRef ltypChgMaterial As ChgMaterial, _
                                                  ByRef lstrWpExcutingFlag As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "装置使用部材状態変更"
            pubblnMatChgMaterialState_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
                
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypChgMaterial
                
                'SB_ID
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
                
                '@処理区分(14:保留、15:保留解除、45:廃棄、46:装置使用開始、47:使用開始、48:装置使用解除)
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@部材種別ID
                If .strMaterialTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
                End If
                
                '@部材ID
                If .strMaterialID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ID, .strMaterialID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
                End If
                
                '@部材管理ID
                If .strMaterialLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, .strMaterialLotID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, CPstrMsgNull)
                End If
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
        '        '@強制実行ﾌﾗｸﾞ
        '        If .strForcedAction <> vbNullString Then
        '            Call lrMsg.addString(CPstrFORCED_ACTION, .strForcedAction)
        '        Else
        '            Call lrMsg.addString(CPstrFORCED_ACTION, CPstrMsgNull)
        '        End If
                
                '@最終更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_chgmaterialstat, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrWP_EXECUTING_FLAG, lstrWpExcutingFlag)        '装置処理実行中ﾌﾗｸﾞ
                    
                    '@関数の処理結果(成功)格納
                    pubblnMatChgMaterialState_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypChgMaterial.strMsgVer)
                    
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
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMatChkMaterialStock_Chk
    '機　能：装置使用部材在庫ﾁｪｯｸ
    '引　数：ltypChkMaterialStock   ：装置部材在庫ﾁｪｯｸ用構造体
    '　　　：lstrErrorMessage       ：ｴﾗｰﾒｯｾｰｼﾞ格納用
    '戻り値：True：成功、False：失敗
    '作成日：2006/10/20 (Fri) 11:50:17 N.Kojima
    '更新日：2006/10/20 (Fri) 11:50:17
    '備　考：
    Public Function pubblnMatChkMaterialStock_Chk(ByRef ltypChkMaterialStock As ChkMaterial, _
                                                  ByRef lstrErrorMessage As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        
        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            
            '@ﾒｯｾｰｼﾞﾀｲﾄﾙ設定
            pstrMessageName = "装置使用部材在庫チェック"
            
            pubblnMatChkMaterialStock_Chk = False
                
            With ltypChkMaterialStock
                
                '@送信ﾒｯｾｰｼﾞ作成
                'SB_ID
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

                '@部材種別ID
                If .strMaterialTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
                End If
                
                '@部材ID
                If .strMaterialID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ID, .strMaterialID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
                End If
                
                '@部材管理ID
                If .strMaterialLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, .strMaterialLotID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_chkmaterialstock, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrERROR_MESSAGE, lstrErrorMessage)        'ｴﾗｰﾒｯｾｰｼﾞ
                    
                    '@関数の処理結果(成功)格納
                    pubblnMatChkMaterialStock_Chk = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypChkMaterialStock.strMsgVer)
                    
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
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMatMaterialStockNum_Sel
    '機　能：装置使用部材在庫数量取得
    '引　数：ltypMaterialStockNum   ：装置使用部材在庫数量格納用構造体
    '　　　：lstrStockNum           ：在庫数
    '　　　：lstrOrderNum           ：発注数
    '　　　：lstrDeliverDate        ：受入予定日
    '戻り値：True：成功、False：失敗
    '作成日：2006/10/20 (Fri) 11:50:29 N.Kojima
    '更新日：2006/10/20 (Fri) 11:50:29
    '備　考：
    Public Function pubblnMatMaterialStockNum_Sel(ByRef ltypMaterialStockNum As ChkMaterial, _
                                                  ByRef lstrStockNum As String, _
                                                  ByRef lstrOrderNum As String, _
                                                  ByRef lstrDeliverDate As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        
        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            
            '@ﾒｯｾｰｼﾞﾀｲﾄﾙ設定
            pstrMessageName = "装置使用部材在庫数量取得"
            
            pubblnMatMaterialStockNum_Sel = False
                
            With ltypMaterialStockNum
                
                '@送信ﾒｯｾｰｼﾞ作成
                'SB_ID
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

                '@部材種別ID
                If .strMaterialTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
                End If
                
                '@部材ID
                If .strMaterialID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ID, .strMaterialID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_materialstocknum, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrSTOCK_NUM, lstrStockNum)          '在庫数
                    Call laMsg.getString(CPstrORDER_NUM, lstrOrderNum)          '発注数
                    Call laMsg.getString(CPstrDELIVER_DATE, lstrDeliverDate)    '受入予定日
                    
                    '@関数の処理結果(成功)格納
                    pubblnMatMaterialStockNum_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypMaterialStockNum.strMsgVer)
                    
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
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMatOrderMaterial_Ins
    '機　能：装置使用部材発注
    '引　数：ltypOrderMaterial  ：装置使用部材在庫数量格納用構造体
    '　　　：lstrEditTime       ：最終更新日時
    '戻り値：True：成功、False：失敗
    '作成日：2006/10/20 (Fri) 11:50:29 N.Kojima
    '更新日：2007/06/14 (Thu) 10:01:05 N.Kasai
    '備　考：
    '　　　：2007/06/14 (Thu) 10:01:05 N.Kasai  発注数追加
    Public Function pubblnMatOrderMaterial_Ins(ByRef ltypOrderMaterial As RegMaterial, _
                                                ByRef lstrStartNum As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        
        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            
            '@ﾒｯｾｰｼﾞﾀｲﾄﾙ設定
            pstrMessageName = "装置使用部材発注"
            
            pubblnMatOrderMaterial_Ins = False
                
            With ltypOrderMaterial
                
                '@送信ﾒｯｾｰｼﾞ作成
                'SB_ID
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

                '@部材種別ID
                If .strMaterialTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
                End If
                
                '@部材ID
                If .strMaterialID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ID, .strMaterialID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
                End If
                
                '@発注ID
                If .strMaterialOrderID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ORDER_ID, .strMaterialOrderID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ORDER_ID, CPstrMsgNull)
                End If
                
                '@発注数
                If .strMaterialOrderNum <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ORDER_NUM, .strMaterialOrderNum)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ORDER_NUM, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@受入予定日(strAcceptanceDateを使い回し。画面上は同項目)
                If .strAcceptanceDate <> vbNullString Then
                    Call lrMsg.addString(CPstrDELIVER_DATE, .strAcceptanceDate)
                Else
                    Call lrMsg.addString(CPstrDELIVER_DATE, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_ordermaterial, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrSTART_NUM, lstrStartNum)      '発注ID(更新開始番号)
                    
                    '@関数の処理結果(成功)格納
                    pubblnMatOrderMaterial_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypOrderMaterial.strMsgVer)
                    
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
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

        End Try
    End Function

End Module
