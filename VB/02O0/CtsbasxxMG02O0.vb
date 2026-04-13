'ﾌｧｲﾙ名：xxMG02O0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：時間制限流動管理　通信MSG用標準モジュール
'作成日：2018/01/05 (Fri) 16:47:57 Y.Yoneyama
'更新日：2018/01/05 (Fri) 16:47:57 Y.Yoneyama
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02O0
    '関数名：pubblnRestrictStatus_Sel
    '機　能：時間制限流動設定取得
    '引　数：lstrmsgVer                 ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrRestrictType           ：制限ﾀｲﾌﾟ
    '　　　：ltypRestrictStatus         ：時間制限設定造体
    '戻り値：True：正常、False：異常
    '作成日：2018/01/11 (Thu) 11:58:44 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 11:58:44 Y.Yoneyama
    '備　考：
    Public Function pubblnRestrictStatus_Sel(ByVal lstrMsgVer As String, _
                                             ByVal lstrSBID As String, _
                                             ByVal lstrRestrictType As String, _
                                             ByRef ltypRestrictStatus As TimeRestrict) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得

        Try

            pstrMessageName = "時間制限流動設定取得"
            pubblnRestrictStatus_Sel = False

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '制限ﾀｲﾌﾟ
            If lstrRestrictType <> vbNullString Then
                Call lrMsg.addString(CPstrRESTRICT_TYPE, lstrRestrictType)
            Else
                Call lrMsg.addString(CPstrRESTRICT_TYPE, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrtimerestrictstatus, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    'Call laMsg.getString(CPstrSB_ID, ltypRestrictStatus.strSbId)
                    Call laMsg.getString(CPstrRESTRICT_TYPE, ltypRestrictStatus.strRestrictType)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrRESTRICT_FLOW_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypRestrictStatus.lngFlowListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypRestrictStatus.lngFlowListCnt > 0 Then

                        If ltypRestrictStatus.typRestrictFlowList Is Nothing Then
                            ltypRestrictStatus.typRestrictFlowList = New List(Of typRestrictFlow) 
                        Else 
                            ltypRestrictStatus.typRestrictFlowList.Clear 
                        End If

                        '@構造体初期化
                        Dim typRestrictFlowListRec As typRestrictFlow
                        typRestrictFlowListRec = New typRestrictFlow 

                        For Each ltMsg In laAry

                            '@受信結果取得
                            With typRestrictFlowListRec

                                Call ltMsg.getString(CPstrFROM_OP_ID, .strFromOpId)
                                Call ltMsg.getString(CPstrFROM_STEP_ID, .strFromStepId)
                                Call ltMsg.getString(CPstrTO_OP_ID, .strToOpId)
                                Call ltMsg.getString(CPstrTO_STEP_ID, .strToStepId)
                                Call ltMsg.getString(CPstrLOT_STOP_ON, .strLotStopOn)
                                Call ltMsg.getString(CPstrEDIT_EMP_NAME, .strEditEmpName)
                                Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)

                            End With
                            ltypRestrictStatus.typRestrictFlowList.Add(typRestrictFlowListRec)
                        Next
                    End If
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrRESTRICT_WP_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    ltypRestrictStatus.lngWpListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypRestrictStatus.lngWpListCnt > 0 Then

                        If ltypRestrictStatus.typRestrictWpList Is Nothing Then
                            ltypRestrictStatus.typRestrictWpList = New List(Of typRestrictWp)
                        Else 
                            ltypRestrictStatus.typRestrictWpList.Clear 
                        End If

                        '@構造体初期化
                        Dim typRestrictWpRec As typRestrictWp
                        typRestrictWpRec = New typRestrictWp 

                        For Each ltMsg In laAry

                            '@受信結果取得
                            With typRestrictWpRec

                                Call ltMsg.getString(CPstrWP_ID, .strWpID)
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)
                                Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)
                                Call ltMsg.getString(CPstrPROCESSING_NAME, .strProcessingName)
                                Call ltMsg.getString(CPstrLOT_STOP_OFF, .strLotStopOff)
                                Call ltMsg.getString(CPstrWAIT_LOT_NUM, .strWaitLotNum)
                                Call ltMsg.getString(CPstrEDIT_EMP_NAME, .strEditEmpName)
                                Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)

                            End With
                            ltypRestrictStatus.typRestrictWpList.Add(typRestrictWpRec) 
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnRestrictStatus_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnRestrictRegist_Upd
    '機　能：時間制限流動設定登録
    '引　数：lstrMsgVer                 ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrEmpId                  ：確定作業者ID
    '　　　：ltypRestrictStatus         ：時間制限設定造体
    '戻り値：True：正常、False：異常
    '作成日：2018/01/15 (Mon) 11:28:29 Y.Yoneyama
    '更新日：2018/01/15 (Mon) 11:28:29 Y.Yoneyama
    '備　考：
    Public Function pubblnRestrictRegist_Upd(ByVal lstrMsgVer As String, _
                                             ByVal lstrSBID As String, _
                                             ByVal lstrEmpID As String, _
                                             ByRef ltypRestrictStatus As TimeRestrict) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "時間制限流動設定登録"
            pubblnRestrictRegist_Upd = False

            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypRestrictStatus

                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If lstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, lstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@登録作業者ID
                If lstrEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@流動制限方式
                If .strRestrictType <> vbNullString Then
                    Call lrMsg.addString(CPstrRESTRICT_TYPE, .strRestrictType)
                Else
                    Call lrMsg.addString(CPstrRESTRICT_TYPE, CPstrMsgNull)
                End If
                
                '@***********************
                '@時間制限流動設定(工程)
                '@***********************
                If .lngFlowListCnt > 0 Then

                    llngCnt = 1

                    Do While .lngFlowListCnt >= llngCnt

                        With .typRestrictFlowList(llngCnt - 1)
                        
                            '@編集ﾌﾗｸﾞ
                            If .strEditFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrEDIT_FLAG, .strEditFlag)
                            Else
                                Call ltMsg.addString(CPstrEDIT_FLAG, CPstrMsgNull)
                            End If
                        
                            '@FROM_OP_ID
                            If .strFromOpId <> vbNullString Then
                                Call ltMsg.addString(CPstrFROM_OP_ID, .strFromOpId)
                            Else
                                Call ltMsg.addString(CPstrFROM_OP_ID, CPstrMsgNull)
                            End If

                            '@FROM_STEP_ID
                            If .strFromStepId <> vbNullString Then
                                Call ltMsg.addString(CPstrFROM_STEP_ID, .strFromStepId)
                            Else
                                Call ltMsg.addString(CPstrFROM_STEP_ID, CPstrMsgNull)
                            End If
                            
                            '@TO_OP_ID
                            If .strToOpId <> vbNullString Then
                                Call ltMsg.addString(CPstrTO_OP_ID, .strToOpId)
                            Else
                                Call ltMsg.addString(CPstrTO_OP_ID, CPstrMsgNull)
                            End If
                            
                            '@TO_STEP_ID
                            If .strToStepId <> vbNullString Then
                                Call ltMsg.addString(CPstrTO_STEP_ID, .strToStepId)
                            Else
                                Call ltMsg.addString(CPstrTO_STEP_ID, CPstrMsgNull)
                            End If

                            '@LOT_STOP_ON
                            If .strLotStopOn <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_STOP_ON, .strLotStopOn)
                            Else
                                Call ltMsg.addString(CPstrLOT_STOP_ON, CPstrMsgNull)
                            End If
                                
                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear
                            llngCnt = llngCnt + 1
                        End With
                    Loop
                Else
                    ltMsg.Clear
                End If

                Call lrMsg.addMsgAry(CPstrRESTRICT_FLOW_LIST, lrAry)
                lrAry.Clear
                
                '@***********************
                '@時間制限流動設定(装置)
                '@***********************
                If .lngWpListCnt > 0 Then

                    llngCnt = 1

                    Do While .lngWpListCnt >= llngCnt

                        With .typRestrictWpList(llngCnt - 1)
                        
                            '@編集ﾌﾗｸﾞ
                            If .strEditFlag <> vbNullString Then
                                Call ltMsg.addString(CPstrEDIT_FLAG, .strEditFlag)
                            Else
                                Call ltMsg.addString(CPstrEDIT_FLAG, CPstrMsgNull)
                            End If
                        
                            '@WP_ID
                            If .strWpID <> vbNullString Then
                                Call ltMsg.addString(CPstrWP_ID, .strWpID)
                            Else
                                Call ltMsg.addString(CPstrWP_ID, CPstrMsgNull)
                            End If

                            '@SEQ_NUM
                            If .strSeqNum <> vbNullString Then
                                Call ltMsg.addString(CPstrSEQ_NUM, .strSeqNum)
                            Else
                                Call ltMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)
                            End If
                            
                            '@LOT_STOP_OFF
                            If .strLotStopOff <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_STOP_OFF, .strLotStopOff)
                            Else
                                Call ltMsg.addString(CPstrLOT_STOP_OFF, CPstrMsgNull)
                            End If
                                
                            '@WAIT_LOT_NUM
                            If .strWaitLotNum <> vbNullString Then
                                Call ltMsg.addString(CPstrWAIT_LOT_NUM, .strWaitLotNum)
                            Else
                                Call ltMsg.addString(CPstrWAIT_LOT_NUM, CPstrMsgNull)
                            End If
                                
                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear
                            llngCnt = llngCnt + 1
                        End With
                    Loop
                Else
                    ltMsg.Clear
                End If

                Call lrMsg.addMsgAry(CPstrRESTRICT_WP_LIST, lrAry)
                lrAry.Clear
                
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrtimerestrictregist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnRestrictRegist_Upd = True


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

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

End Module
