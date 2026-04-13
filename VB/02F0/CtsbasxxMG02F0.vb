'ﾌｧｲﾙ名：xxMG02F0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Wafer治具セット機能共通ﾓｼﾞｭｰﾙ
'作成日：2009/06/09 (Tue) 13:05:10 K.Nishizawa
'更新日：2009/06/09 (Tue) 13:05:10
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02F0
    Public Const CPstrjigusecheck__                 As String = "jig_.usechk__"
    Public Const CPstrwfjigset__                    As String = "wf__.jigset__"

    '@判定可否用Msg
    Public Structure JigCheck
        Dim strSbID             As String                                   'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strjigId            As String                                   '治具ID
        Dim strScreenSizeID     As String                                   'ｽｸﾘｰﾝｻｲｽﾞ
        Dim strLotID            As String                                   'LOT_ID
        Dim strOpID             As String                                   '大工程
        Dim strStepID           As String                                   '小工程
    End Structure

    '@紐付け実行(Wafer)
    Public Structure JigWfList
        Dim strWfId             As String                                   'ｳｪﾊｰID
        Dim strGuideId          As String                                   '治具ID
		Dim strMaskId			As String
		Dim strHolderId			As String
    End Structure

    '@紐付け実行
    Public Structure JigSetInf
        Dim strSbID             As String                                   'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strLotID            As String                                   'LOT_ID
        Dim strEmpID            As String                                   '作業者ID
        Dim typWfList           As List(Of JigWfList)                       'ｳｪﾊｰﾘｽﾄ
    End Structure


    '関数名：pubblnJycJigList_Sel
    '機　能：蒸着治具使用可否判定
    '引　数：lstrClassDivision  : 処理区分(CLASS_DIVISION)
    '      ：lstrJigUseChk_ver : Msgﾊﾞｰｼﾞｮﾝ(jig_.usecheck)
    '      ：lypJigChk : Msg送信用ｵﾌﾞｼﾞｪｸﾄ(JigCheck)
    '      ：lstrGudMsgCode : ﾒｯｾｰｼﾞ№
    '      ：lstrGuidMsg    : 返信ﾒｯｾｰｼﾞ
    '戻り値：True:成功/Flase：失敗
    '作成日：2009/06/09 (Tue) 17:05:04 K.Nishizawa
    '更新日：2009/06/09 (Tue) 07:05:04 K.Nishizawa
    '備　考：
    Public Function pubblnJycJigUse_Check(ByVal lstrClassDivision As String, _
                                            ByVal lstrJigUseChk_ver As String, _
                                            ByRef ltypJigChk As JigCheck, _
                                            ByRef lstrGuidMsgCode As String, _
                                            ByRef lstrGuidMsg As String _
                                            ) As Boolean

        Dim lrMsg           As TfMsg
        Dim laMsg           As TfMsg
        Dim lstrRET         As String

        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            

            pstrMessageName = "治具一覧取得"
            
            pubblnJycJigUse_Check = False
            
            With ltypJigChk
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                If .strjigId <> vbNullString Then
                    Call lrMsg.addString(CPstrJIG_ID, .strjigId)
                Else
                    Call lrMsg.addString(CPstrJIG_ID, CPstrMsgNull)
                End If
                
                If .strScreenSizeID <> vbNullString Then
                    Call lrMsg.addString(CPstrSCREEN_SIZE_ID, .strScreenSizeID)
                Else
                    Call lrMsg.addString(CPstrSCREEN_SIZE_ID, CPstrMsgNull)
                End If
                
                If lstrClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                
                If lstrJigUseChk_ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrJigUseChk_ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjigusecheck__, lrMsg, laMsg)
            
            '@結果受信
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                Case CPstrTRUE
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)
                    
                    pubblnJycJigUse_Check = True
                    
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrJigUseChk_ver)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnWaferJigSet_Upd
    '機　能：蒸着治具使用可否判定
    '引　数：ltypJigSet:紐付け実行Object
    '戻り値：True:成功/Flase：失敗
    '作成日：2009/06/09 (Tue) 17:05:04 K.Nishizawa
    '更新日：2009/06/09 (Tue) 07:05:04 K.Nishizawa
    '備　考：
    Public Function pubblnWaferJigSet_Upd(ByVal lstrWfjigsetMsg_Ver As String, _
                                    ByVal lstrJigStatus As String, _
									ByVal lstrJigEventId As String, _
                                    ByRef ltypJigSet As JigSetInf) As Boolean

        Dim lrMsg               As TfMsg
        Dim lrMsg2              As TfMsg
        Dim lrAry               As TfMsgAry
        Dim laMsg               As TfMsg
        Dim lstrRET             As String
        Dim llngCnt             As Integer

        Try
            
            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            pstrMessageName = "治具Wafer紐付け"
            
            pubblnWaferJigSet_Upd = False
            
            With ltypJigSet
                '@Msg_Ver取得
                If lstrWfjigsetMsg_Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrWfjigsetMsg_Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@ｼｽﾃﾑﾌﾞﾛｯｸ取得
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@ﾛｯﾄID取得
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@作業者ID取得
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                For llngCnt = 0 To .typWfList.Count - 1
                    If .typWfList(llngCnt).strWfId <> vbNullString Then
                        Call lrMsg2.addString(CPstrWF_ID, .typWfList(llngCnt).strWfId)
                    Else
                        Call lrMsg2.addString(CPstrWF_ID, CPstrMsgNull)
                    End If
                    If .typWfList(llngCnt).strGuideId <> vbNullString Then
                        Call lrMsg2.addString(CPstrJIG_ID, .typWfList(llngCnt).strGuideId)
                    Else
                        Call lrMsg2.addString(CPstrJIG_ID, CPstrMsgNull)
                    End If
					If .typWfList(llngCnt).strMaskId <> vbNullString Then
                        Call lrMsg2.addString(CPstrMASK_ID, .typWfList(llngCnt).strMaskId)
                    Else
                        Call lrMsg2.addString(CPstrMASK_ID, CPstrMsgNull)
                    End If
					If .typWfList(llngCnt).strHolderId <> vbNullString Then
                        Call lrMsg2.addString(CPstrHOLDER_ID, .typWfList(llngCnt).strHolderId)
                    Else
                        Call lrMsg2.addString(CPstrHOLDER_ID, CPstrMsgNull)
                    End If
                    If lstrJigStatus <> vbNullString Then
                        Call lrMsg2.addString(CPstrJIG_STATUS, lstrJigStatus)
                    Else
                        Call lrMsg2.addString(CPstrJIG_STATUS, CPstrMsgNull)
                    End If
					'@治具イベントID
					If lstrJigEventId <> vbNullString Then
						Call lrMsg2.addString(CPstrJIG_EVENT_ID, lstrJigEventId)
					Else
						Call lrMsg2.addString(CPstrJIG_EVENT_ID, CPstrMsgNull)
					End If

                    Call lrAry.Add(lrMsg2)
                    lrMsg2.Clear
                Next
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
                lrAry.Clear
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrwfjigset__, lrMsg, laMsg)
            
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                Case CPstrTRUE
                    pubblnWaferJigSet_Upd = True
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrWfjigsetMsg_Ver)

                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)

                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing

            Exit Function
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
        End Try
    End Function


	'=========================================Public=========================================
    '関数名：pubblnJJig_Sel
    '機　能：蒸着治具情報単体取得
    '引　数：
    '      ：ltypJJigAns  ：蒸着治具単体結果(from Svr)
    '      ：lstrJigId      :治具ｽﾃｰﾀｽ

    '戻り値：True:成功/Flase：失敗
    '作成日：
    '更新日：
    '備　考：
    Public Function pubblnJJig_Sel(ByVal lstrjig_jjiggetVer As String, _
                                         ByVal lstrJigId As String, _
                                         ByRef ltypJJigAns As JJigList) _
                                         As Boolean
                                        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得


        Try
            
            pstrMessageName = "蒸着治具情報単体取得"
            
            '戻り値初期化
            pubblnJJig_Sel = False
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            
            'Msgの作成
            With lrMsg
                '@MsgVerｾｯﾄ
                Call .addString(CPstrMSG_VER, lstrjig_jjiggetVer)
                '@治具ｽﾃｰﾀｽｾｯﾄ
                If lstrJigId <> vbNullString Then
                    Call .addString(CPstrJIG_ID, lstrJigId)
                Else
                    Exit Function
                End If

            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjig_jjigget, lrMsg, laMsg)
            
            '@ﾒｯｾｰｼﾞ受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '結果によって処理分岐
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
               
					'ﾘｽﾄｾｯﾄ準備
                    Dim tmpJJigList As JJigList = New JJigList()
                        
                    With tmpJJigList
                            
                        Call laMsg.getString(CPstrJIG_ID, .strJJigId)                               'ｼﾞｸﾞID
                        Call laMsg.getString(CPstrJIG_STATUS, .strJJigStatusId)                     'ｼﾞｸﾞ状態
                        Call laMsg.getString(CPstrJ_JIG_CATEGORY, .strJJigCategoryId)				'蒸着治具ｶﾃｺﾞﾘ
                        Call laMsg.getString(CPstrSET_GUIDE_ID, .strSetGuideId)						'組立ｶﾞｲﾄﾞﾘﾝｸﾞID
                        Call laMsg.getString(CPstrSET_MASK_ID, .strSetMaskId)						'組立ﾏｽｸID
                        Call laMsg.getString(CPstrSET_HOLDER_ID, .strSetHolderId)					'紐付けホルダID			
                        Call laMsg.getString(CPstrSET_EMP_ID, .strSetEmpID)							'組立担当者Id
                        Call laMsg.getString(CPstrSTART_TIME, .strStartTime)						'使用開始日時
                        Call laMsg.getString(CPstrCLEAN_TIME, .strCleanTime)						'最終洗浄日時
                        Call laMsg.getString(CPstrUSE_NUM, .strUseNum)								'使用回数
                        Call laMsg.getString(CPstrNEXT_STOCK_READY_FLAG, .strNextStockReadyFlag)	'次回在庫準備フラグ   
                        Call laMsg.getString(CPstrEMP_ID, .strEmpID)								'最終使用者(氏名ｺｰﾄﾞ)
                        Call laMsg.getString(CPstrCOMMENTS, .strComments)							'コメント
                        Call laMsg.getString(CPstrWASH_USE_NUM, .strWashUseNum)						'洗浄後使用回数
                        Call laMsg.getString(CPstrWASH_USE_LIMIT, .strWashUseLimit)					'洗浄後上限回数
                                
                    End With
                    
					ltypJJigAns = tmpJJigList

                '@結果OK
                pubblnJJig_Sel = True
                    
            '@〓 1：FALSE(失敗) 〓
            Case CPstrFALSE

                '@=======================
                '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                '@=======================
                Call pubstrErrMsg_Set(laMsg, CPstrjig_jjigget)


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
            lrAry = Nothing
            laAry = Nothing

        End Try
    End Function

End Module
