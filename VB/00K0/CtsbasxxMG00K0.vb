'ﾌｧｲﾙ名：xxMG00K0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：「バッチ作業終了」機能ﾒｯｾｰｼﾞ処理
'作成日：2004/07/20 (Mon) 17:03:19 S.Deguchi
'更新日：2009/07/06 (Mon) 15:50:16 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00K0
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

    '関数名：pubblnbatEndWrk_Upd
    '機　能：ﾊﾞｯﾁﾛｯﾄ作業終了
    '引　数：ltypBatEndWrk  ：ﾊﾞｯﾁﾛｯﾄ作業終了要求構造体
    '　　　：BatLotEndList  ：ﾊﾞｯﾁ作業終了結果格納構造体
    '　　　：lstrGuidMsg    ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True:成功/False:失敗
    '作成日：2004/07/20 (Tue) 19:46:58 S.Deguchi
    '更新日：2009/06/29 (Mon) 09:43:39 N.Kojima
    '備　考：
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2009/06/29 (Mon) 09:43:39 N.Kojima     無機対応。(案件№03560)
    Public Function pubblnbatEndWrk_Upd(ByRef ltypBatEndWrk As BatEndWrk, _
                                        ByRef ltypBatLotEndList As BatLotEndList, _
                                        ByRef lstrGuidMsg As String, _
                                        ByRef lstrGuidMsgCode As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim lrAry1              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt1            As Integer          'ｱﾚｲｶｳﾝﾄ用

        '@初期設定
        pstrMessageName = "バッチ作業終了"
        pubblnbatEndWrk_Upd = False

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            lrAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry

            '@***********************
            '@ 送信ﾒｯｾｰｼﾞﾃﾞｰﾀ作成
            '@***********************
            With ltypBatEndWrk
                
                '@ﾊﾞｯﾁID
                If .strBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrBATCH_ID, .strBatchId)
                Else
                    Call lrMsg.addString(CPstrBATCH_ID, CPstrMsgNull)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
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

                '@ｺﾒﾝﾄ(作業ﾒﾓ)
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If

                '@-----------------------
                '@ ﾛｯﾄﾘｽﾄ
                '@-----------------------
                If .lngBLotListCnt <> 0 Then
                    
                    For llngCnt1 = 0 To .lngBLotListCnt - 1
                        
                        Call ltMsg1.addString(CPstrLOT_ID, .typBLotList(llngCnt1).strLotID)                     'ﾛｯﾄID
                        Call ltMsg1.addString(CPstrLOT_LAST_UPDATE, .typBLotList(llngCnt1).strLotLastUpdate)    '最終更新日時
                        Call ltMsg1.addString(CPstrLOT_KIND, .typBLotList(llngCnt1).strLotKind)                 'ﾛｯﾄ区分
                        Call lrAry1.Add(ltMsg1)
                    Next llngCnt1
                    
                    Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry1)
                Else
                    Call lrMsg.addString(CPstrLOT_LIST, CPstrMsgNull)
                End If
                
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
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

        '@↓2009/06/26 (Fri) 17:30:20 N.Kojima **************************************************

                '@装置ﾀｲﾌﾟ
                If .strEqType <> vbNullString Then
                    Call lrMsg.addString(CPstrEQ_TYPE, .strEqType)
                Else
                    Call lrMsg.addString(CPstrEQ_TYPE, CPstrMsgNull)
                End If

        '@↑2009/06/26 (Fri) 17:30:20 N.Kojima **************************************************
                
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_endwrk__, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果により処理分岐 ★
            Select Case lstrRET

                '@〓 True：通信成功 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                
                    '@最終更新日時の取得
                    With ltypBatLotEndList
                        
                        '@ﾛｯﾄﾘｽﾄｱﾚｲを格納
                        Call laMsg.getMsgAry(CPstrLOT_LIST, laAry2)
                        
                        '@配列数(ﾛｯﾄﾘｽﾄ件数)を格納
                        .lngLotEndListCnt = laAry2.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                         If .lngLotEndListCnt > 0 Then
                            
                            If IsNothing(.typLotEndList) Then
                                .typLotEndList = New List(Of LotEndList)()
                            Else
                                .typLotEndList.Clear()
                            End If
                            
                            llngCnt1 = 0
                            
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg2 In laAry2
                                Dim tmpLotEndList As LotEndList = New LotEndList()
                                
                                Call ltMsg2.getString(CPstrLOT_ID, tmpLotEndList.strLotID)                   'ﾛｯﾄID
                                Call ltMsg2.getString(CPstrLOT_LAST_UPDATE, tmpLotEndList.strLastUpdate)     '最終更新日時
                                Call ltMsg2.getString(CPstrRESULT_FLAG, tmpLotEndList.strResultFlag)         '処理結果ﾌﾗｸﾞ
                                .typLotEndList.Add(tmpLotEndList)
                                llngCnt1 = llngCnt1 + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：通信成功"をｾｯﾄ
                    pubblnbatEndWrk_Upd = True


                '@〓 False：通信失敗 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypBatEndWrk.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            lrAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            lrAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換処理
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

	Public Function pubblnGetAfterJReserveCombineList(ByVal lstrMsgVer As String, 
														ByRef ltypAfterJReservelist As typAfterJReserveDetail, _
													  ByRef ltypAfterJRsvCombineList As typAfterJRsvCombine
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
            pstrMessageName = "蒸着後流動予約統合対象ロット取得"
            pubblnGetAfterJReserveCombineList = False
            
			With ltypAfterJReservelist
				'@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
				If lstrMsgVer <> vbNullString Then
					Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
				Else
					Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
				End If

				'システムブロック
				Call lrMsg.addString(CPstrSB_ID, CPstrSBID2A0)
				

				'@ロットID取得
				If .strLotId <> vbNullString Then
					Call lrMsg.addString(CPstrLOT_ID, .strLotId)
				Else
					Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
				End If

				'予約ID
				If .strReserveId <> vbNullString Then
					Call lrMsg.addString(CPstrRESERVE_ID, .strReserveId)
				Else
					Call lrMsg.addString(CPstrRESERVE_ID, CPstrMsgNull)
				End If
			
				'予約グループ
				If .strReserveGroup <> vbNullString Then
					Call lrMsg.addString(CPstrRESERVE_GROUP, .strReserveGroup)
				Else
					Call lrMsg.addString(CPstrRESERVE_GROUP, CPstrMsgNull)
				End If

			End With

            Call lrMsg.addMsgAry(CPstrAFTER_J_RESERVE_COMBINE_LIST, lrAry)
            lrAry.Clear
                     
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_afterjrsvcombinelist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

			ltypAfterJRsvCombineList.lngAfterJReserveDetailListCnt = 0

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    With ltypAfterJRsvCombineList
                    
						'機種
						Call laMsg.getString(CPstrPD_ID, .strPdId)
						'小工程
						Call laMsg.getString(CPstrSTEP_ID, .strStepId)

						'ｱﾚｰを取得
						Call laMsg.getMsgAry(CPstrAFTER_J_RESERVE_COMBINE_LIST, laAry)
                        
						.lngAfterJReserveDetailListCnt = laAry.Count

						'ﾘｽﾄ件数は0以上か
						If laAry.Count > 0 Then

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
									Call ltMsg.getString(CPstrPD_ID, .strPdId)
									Call ltMsg.getString(CPstrSTEP_ID, .strStepId)
									Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)
									Call ltMsg.getString(CPstrRESERVE_GROUP, .strReserveGroup)
									Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)
									Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)
								End With
								.typAfterJReserveDetailList.add(tmp)
							Next
						End If
                    
					End With

                    '@関数の処理結果(成功)格納
                    pubblnGetAfterJReserveCombineList = True
                    
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


	Public Function pubblnAfterJReserveCompleteChk(ByVal lstrMsgVer As String, 
													ByVal lstrLotId As string,
													ByRef lstrCompleteFlag As String
													)As Boolean

    Dim lrMsg As New TfMsg      '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
    Dim laMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
    Dim ltMsg As New TfMsg      '受信ﾒｯｾｰｼﾞ(temp)
    Dim laAry As New TfMsgAry   '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
    Dim lrMsg2 As New TfMsg            
    Dim lrAry As New TfMsgAry
    Dim lstrRET As String = vbNullString

    Try

        '@初期設定
        pstrMessageName = "蒸着後流動予約統合対象ロット取得"
        pubblnAfterJReserveCompleteChk = False
            

			'@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
			If lstrMsgVer <> vbNullString Then
				Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
			Else
				Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
			End If

			'システムブロック
			Call lrMsg.addString(CPstrSB_ID, CPstrSBID2A0)
				

			'@ロットID取得
			If lstrLotId <> vbNullString Then
				Call lrMsg.addString(CPstrLOT_ID, lstrLotId)
			Else
				Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
			End If

                     
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_afterjrsvcompletechk, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

					Call laMsg.getString(CPstrAFTER_J_RESERVE_COMPLETE_FLAG, lstrCompleteFlag)

                    '@関数の処理結果(成功)格納
                    pubblnAfterJReserveCompleteChk = True
                    
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
