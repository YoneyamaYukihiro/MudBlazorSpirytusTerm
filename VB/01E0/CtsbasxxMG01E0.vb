'ﾌｧｲﾙ名：xxMG01E0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Wafer移載 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/06/01 (Tue) 10:24:41 Y.Yamagishi
'更新日：2004/06/01 (Tue) 10:24:41
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01E0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    ''Public Const CPstrTO_LOT_ID             As String = "TO_LOT_ID"     '移載先ﾛｯﾄID

    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubblnInvmoveinfo_Sel
    '機　能：在庫ﾛｯﾄ移載情報取得
    '引　数：lstrInv_moveinfoVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCarrierID：ｷｬﾘｱID
    '　　　：ltypLotmoveinfo：取得結果格納構造体
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/06/01 (Tue) 10:25:46 Y.Yamagishi
    '更新日：2004/09/17 (Fri) 17:43:11 M.Miura
    '備　考：2004/09/10 (Fri) 16:29:20 Y.Yamagishi "ORG_DIVIDE_COMBINE_LOT_ID","ORG_LOT_ID1"追加対応(不具合改善№679)
    '　　　：2004/09/17 (Fri) 17:43:11 M.Miura     応答の"LOT_LAST_UPDATE3"を削除,"DIVIDE_COMBINE_LOTID"を"TO_LOT_ID"に変更追加対応(不具合改善№679)
    '　　　：                                      "ORG_DIVIDE_COMBINE_LOT_ID"を削除,"TO_CARRIER_ID"、"TO_FLOW_CLASS"を追加
    Public Function pubblnInvmoveinfo_Sel(ByVal lstrInv_moveinfoVer As String, ByVal lstrCarrierID As String, ByRef ltypLotmoveinfo As InvMoveInfo) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim lstrWFID            As String           'WFID
         
        Try
            
            pstrMessageName = "在庫ロット移載情報取得"
            pubblnInvmoveinfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrInv_moveinfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrInv_moveinfoVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_moveinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    With ltypLotmoveinfo
                        Call laMsg.getString(CPstrLOT_EVENT_ID, .strLotEventId)             'ﾛｯﾄｲﾍﾞﾝﾄID
                        Call laMsg.getString(CPstrLOT_ID1, .strLotID1)                      'ﾛｯﾄID
                        Call laMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                '流動区分
                        Call laMsg.getString(CPstrPD_ID, .strPdId)                          '機種ID
                        Call laMsg.getString(CPstrNOW_ST, .strNowST)                        'ﾛｯﾄ状態
                        Call laMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)           'ﾛｯﾄ停止ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)           'ﾛｯﾄ保留ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrWF_NUM, .strWfNum)                        'WF枚数
        ''                Call laMsg.getString(CPstrWF_CARRY_FLAG, .strWfCarryFlag)           'WF移載ﾌﾗｸﾞ
                    End With
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                    
                    ltypLotmoveinfo.lngWfListCnt = laAry.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypLotmoveinfo.lngWfListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        '@配列の要素数を設定
                        'ReDim Preserve ltypLotmoveinfo.typInvMoveInfoWFList(ltypLotmoveinfo.lngWfListCnt)
                        If IsNothing(ltypLotmoveinfo.typInvMoveInfoWFList) Then
                            ltypLotmoveinfo.typInvMoveInfoWFList = New List(Of InvMoveInfoWFList)()
                        Else
                            ltypLotmoveinfo.typInvMoveInfoWFList.Clear()
                        End If

                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim tmpInvMoveInfoWFList As InvMoveInfoWFList = New InvMoveInfoWFList()
                            With tmpInvMoveInfoWFList
                                Call ltMsg.getString(CPstrWF_ID, .strWfId)                                      'WFID
                                Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)                      'ｽﾛｯﾄNO
                                Call ltMsg.getString(CPstrWF_STATUS, .strWFStatus)                              'WFｽﾃｰﾀｽ
                                Call ltMsg.getString(CPstrTO_CARRY_SLOT_POSITION, .strToCarrySlotPosition)      '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                                Call ltMsg.getString(CPstrDIVIDE_COMBINE_STATUS, .strDivideCombineStatus)       '分割/統合ｽﾃｰﾀｽ
                                Call ltMsg.getString(CPstrTO_LOT_ID, .strDivideCombineLotID)                    '移載先ﾛｯﾄID
                                '@前回の移載先ﾛｯﾄIDと違う場合
                                If lstrWFID <> .strDivideCombineLotID Then
                                    Call ltMsg.getString(CPstrTO_CARRIER_ID, .strToCarrierId)                       '移載先ｷｬﾘｱID
                                    Call ltMsg.getString(CPstrTO_FLOW_CLASS, .strToFlowClass)                       '移載先流動区分
                                    Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)                   '移載先ﾛｯﾄ最終更新日時
                                    Call ltMsg.getString(CPstrCARRIER_TYPE_ID, .strCarrierTypeID)                   'ｷｬﾘｱﾀｲﾌﾟID
                                    Call ltMsg.getString(CPstrSLOT_SIZE, .strSlotSize)                              'ｽﾛｯﾄ数
                                End If
                                '@次回比較用移載先ﾛｯﾄID退避
                                lstrWFID = .strDivideCombineLotID
                            End With
                            ltypLotmoveinfo.typInvMoveInfoWFList.Add(tmpInvMoveInfoWFList)
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    
                    pubblnInvmoveinfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrInv_moveinfoVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnInvMove_____Ins
    '機　能：在庫ﾛｯﾄ移載
    '引　数：lstrInv_move____Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotMoveStart：在庫ﾛｯﾄ移載構造体(送信)
    '　　　：llngWfCnt：WF枚数
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/02 (Wed) 12:35:29 Y.Yamagishi
    '更新日：2004/10/21 (Thu) 15:02:03 N.Kojima
    '備　考：2004/09/17 (Fri) 17:38:21 M.Miura　送信msgの処理区分、ｷｬﾘｱID3、ﾛｯﾄID3、ﾛｯﾄ最終更新日時3を削除（不具合№548）
    '　　　：2004/10/21 (Thu) 15:02:03 N.Kojima　空ﾀｸﾞ挿入処理追加
    Public Function pubblnInvMove_____Ins(ByVal lstrInv_move____Ver As String, ByRef ltypInvMove____ As InvMove____) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'カウント
        
        Try

            pstrMessageName = "在庫ロット移載"
            pubblnInvMove_____Ins = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypInvMove____
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@移載元ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@移載先ﾛｯﾄﾘｽﾄﾒｯｾｰｼﾞ作成
                If .llngMoveListCnt > 0 Then
                    For llngCnt = 0 To .llngMoveListCnt - 1
                        With ltypInvMove____.typMoveList(llngCnt)
                            '@移載先ﾛｯﾄ最終更新日時
                            If .strLotLastUpdate <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                            Else
                                Call ltMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                            End If
                            '@移載先ｷｬﾘｱID
                            If .strCarrierId <> vbNullString Then
                                Call ltMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                            Else
                                Call ltMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                            End If
                            '@移載先ﾛｯﾄID
                            If .strLotID <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_ID, .strLotID)
                            Else
                                Call ltMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                            End If
                        End With
                        
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    Next llngCnt
                Else
                    ltMsg.Clear
                End If
                Call lrMsg.addMsgAry(CPstrMOVE_LIST, lrAry)
                lrAry.Clear
                
            End With
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrInv_move____Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrInv_move____Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_move____, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnInvMove_____Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrInv_move____Ver)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception
            
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    ''
    '''関数名：pubblnInvMove_____Ins
    '''機　能：ﾛｯﾄ移載
    '''引　数：lstrlot_move____Ver：Msgﾊﾞｰｼﾞｮﾝ
    '''　　　：ltypLotMoveStart：ﾛｯﾄ移載構造体(送信)
    '''　　　：llngWfCnt：WF枚数
    '''戻り値：True：成功、False：失敗
    '''作成日：2004/06/02 (Wed) 12:35:29 Y.Yamagishi
    '''更新日：2004/09/17 (Fri) 17:38:21 M.Miura
    '''備　考：2004/09/17 (Fri) 17:38:21 M.Miura　送信msgの処理区分、ｷｬﾘｱID3、ﾛｯﾄID3、ﾛｯﾄ最終更新日時3を削除（不具合№548）
    ''Public Function pubblnInvMove_____Ins(ByVal lstrlot_move____Ver As String, ByRef ltypLotMove____ As LotMove____, ByVal llngWFcnt As Long) As Boolean
    ''
    ''    Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
    ''    Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
    ''    Dim ltMsg               As TfMsg            'ｱﾚｰの各要素作成用
    ''    Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
    ''    Dim lstrRET             As String           '応答取得
    ''    Dim lstrErrMsg          As String           'ｴﾗｰ用
    ''    Dim llngCnt             As Long             'カウント
    ''    Dim lstrMSG             As String           'ﾒｯｾｰｼﾞ内容格納
    ''
    ''    On Error GoTo Error_Handler
    ''
    ''    pstrMessageName = "ロット移載"
    ''    pubblnInvMove_____Ins = False
    ''
    ''    Set lrMsg = New TfMsg
    ''    Set lrAry = New TfMsgAry
    ''    Set ltMsg = New TfMsg
    ''    Set laMsg = New TfMsg
    ''
    ''    With ltypLotMove____
    ''
    ''        '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
    ''        '@ｼｽﾃﾑﾌﾞﾛｯｸ
    ''        If .strSBID <> vbNullString Then
    ''            Call lrMsg.addString(CPstrSB_ID, .strSBID)
    ''        Else
    ''            Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
    ''        End If
    ''        '@移載元ｷｬﾘｱID
    ''        If .strCarrierID1 <> vbNullString Then
    ''            Call lrMsg.addString(CPstrCARRIER_ID1, .strCarrierID1)
    ''        Else
    ''            Call lrMsg.addString(CPstrCARRIER_ID1, CPstrMsgNull)
    ''        End If
    ''        '@移載元ﾛｯﾄ最終更新日時
    ''        If .strLotLastUpdate1 <> vbNullString Then
    ''            Call lrMsg.addString(CPstrLOT_LAST_UPDATE1, .strLotLastUpdate1)
    ''        Else
    ''            Call lrMsg.addString(CPstrLOT_LAST_UPDATE1, CPstrMsgNull)
    ''        End If
    ''        '@移載先ｷｬﾘｱID
    ''        If .strCarrierID2 <> vbNullString Then
    ''            Call lrMsg.addString(CPstrCARRIER_ID2, .strCarrierID2)
    ''        Else
    ''            Call lrMsg.addString(CPstrCARRIER_ID2, CPstrMsgNull)
    ''        End If
    ''        '@移載先ﾛｯﾄID
    ''        If .strLotID2 <> vbNullString Then
    ''            Call lrMsg.addString(CPstrLOT_ID2, .strLotID2)
    ''        Else
    ''            Call lrMsg.addString(CPstrLOT_ID2, CPstrMsgNull)
    ''        End If
    ''        '@移載先ﾛｯﾄ最終更新日時
    ''        If .strLotLastUpdate2 <> vbNullString Then
    ''            Call lrMsg.addString(CPstrLOT_LAST_UPDATE2, .strLotLastUpdate2)
    ''        Else
    ''            Call lrMsg.addString(CPstrLOT_LAST_UPDATE2, CPstrMsgNull)
    ''        End If
    ''        '@作業者ID
    ''        If .strEmpID <> vbNullString Then
    ''            Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
    ''        Else
    ''            Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
    ''        End If
    ''        'WFMAP情報ﾒｯｾｰｼﾞ作成
    ''        llngCnt = 1
    ''        If llngWFcnt > 0 Then
    ''            Do While llngWFcnt >= llngCnt
    ''
    ''                Call ltMsg.addString(CPstrSLOT_POSITION, .typWFMapList(llngCnt).strSlotPosition)    'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
    ''                Call ltMsg.addString(CPstrWF_ID, .typWFMapList(llngCnt).strWFID)                    'WFID
    ''                Call lrAry.Add(ltMsg)
    ''                ltMsg.Clear
    ''                llngCnt = llngCnt + 1
    ''            Loop
    ''        Else
    ''            Call ltMsg.addString(CPstrSLOT_POSITION, CPstrMsgNull)              'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
    ''            Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)                      'WFID
    ''            Call lrAry.Add(ltMsg)
    ''            ltMsg.Clear
    ''        End If
    ''        Call lrMsg.addMsgAry(CPstrWF_MAP_LIST, lrAry)
    ''        lrAry.Clear
    ''
    ''    End With
    ''    Call lrMsg.addString(CPstrMSG_VER, lstrlot_move____Ver)                                    'Msgﾊﾞｰｼﾞｮﾝ
    ''
    ''    '@ﾒｯｾｰｼﾞ送信
    ''    Call pTerm.sendRequest(CPstrlot_move____, lrMsg, laMsg)
    ''
    ''    '@受信結果取得
    ''    Call laMsg.getString(CPstrRET, lstrRET)
    ''
    ''    '@結果判定
    ''    Select Case lstrRET
    ''        '@成功の場合(true)
    ''        Case CPstrTRUE
    ''            '@関数の処理結果(成功)格納
    ''            pubblnInvMove_____Ins = True
    ''
    ''        '@失敗の場合(false)
    ''        Case CPstrFALSE
    ''
    ''            '@ﾊﾞｰｼﾞｮﾝ判定
    ''            Call pubstrErrMsg_Set(laMsg, lstrlot_move____Ver)
    ''
    ''        '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
    ''        Case Else
    ''            '@表示ﾒｯｾｰｼﾞ変換
    ''            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
    ''            '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
    ''            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
    ''    End Select
    ''
    ''    Set lrMsg = Nothing
    ''    Set lrAry = Nothing
    ''    Set ltMsg = Nothing
    ''    Set laMsg = Nothing
    ''
    ''    Exit Function
    ''
    '''@例外処理
    ''Error_Handler:
    ''
    ''    Set lrMsg = Nothing
    ''    Set lrAry = Nothing
    ''    Set ltMsg = Nothing
    ''    Set laMsg = Nothing
    ''
    ''    '@表示ﾒｯｾｰｼﾞ変換
    ''    Call pubErrMsg_Proc(Err)
    ''
    ''End Function

End Module
