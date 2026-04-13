'ﾌｧｲﾙ名：xxMG0180.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：WFの不良/保留/払出し用ﾒｯｾｰｼﾞ処理ﾓｼﾞｭｰﾙ
'作成日：2006/11/07 (Tue) 14:39:19 N.Kasai
'更新日：2006/11/07 (Tue) 14:39:19
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0180
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public==========================================
    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：pubblnWfDirectScrap_Upd
    '機　能：WF直接廃棄処理
    '引　数：ltypDirectScrap：要求ﾃﾞｰﾀ格納
    '　　　：lstrResult：結果
    '戻り値：True：成功、False：失敗
    '作成日：2006/11/07 (Tue) 15:09:54 N.Kasai
    '更新日：2009/03/31 (Tue) 14:37:53 N.Kojima
    '備　考：
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    Public Function pubblnWfDirectScrap_Upd(ByRef ltypDirectScrap As DirectScrap, _
                                                ByRef lstrResult As String) As Boolean

        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim lrAry           As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg           As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET         As String           '応答取得
        Dim llngCnt         As Integer          'ｶｳﾝﾄ
            
        Try

            pstrMessageName = "ＷＦ直接廃棄"
            pubblnWfDirectScrap_Upd = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypDirectScrap
                '@送信ﾒｯｾｰｼﾞ作成
                
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                            'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)                    'ｷｬﾘｱID
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
                '@WF毎の不良情報ｾｯﾄ
                llngCnt = 0
                
                Do While ltypDirectScrap.lngScrapWFListCnt > llngCnt
                    
                    With .typScrapWFList(llngCnt)
                        
                        If .strWfId <> vbNullString Then
                            Call ltMsg.addString(CPstrWF_ID, .strWfId)                      'ｳｪﾊID
                        Else
                            Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                        End If
                        
                        If .strSlotPosition <> vbNullString Then
                            Call ltMsg.addString(CPstrSLOT_POSITION, .strSlotPosition)      'ｳｪﾊｽﾛｯﾄ№
                        Else
                            Call ltMsg.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                        End If
                        
                        If .strClass <> vbNullString Then
                            Call ltMsg.addString(CPstrCLASS, .strClass)                     '区分
                        Else
                            Call ltMsg.addString(CPstrCLASS, CPstrMsgNull)
                        End If
                        
                        If .strClassID <> vbNullString Then
                            Call ltMsg.addString(CPstrCLASS_ID, .strClassID)                '項目ID
                        Else
                            Call ltMsg.addString(CPstrCLASS_ID, CPstrMsgNull)
                        End If
                        
        '@↓2009/04/21 (Tue) 12:05:55 N.Kojima **************************************************

                        If .strRegistChipOutNum <> vbNullString Then
                            Call ltMsg.addString(CPstrCHIP_OUT_QUANTITY, .strRegistChipOutNum)          '登録不良ﾁｯﾌﾟ数
                        Else
                            Call ltMsg.addString(CPstrCHIP_OUT_QUANTITY, CPstrZero)
                        End If
                        
                        If .strRegistChipForwardNum <> vbNullString Then
                            Call ltMsg.addString(CPstrCHIP_FORWARD_QUANTITY, .strRegistChipForwardNum)  '登録払出ﾁｯﾌﾟ数
                        Else
                            Call ltMsg.addString(CPstrCHIP_FORWARD_QUANTITY, CPstrZero)
                        End If

        '@↑2009/04/21 (Tue) 12:05:55 N.Kojima **************************************************
                        
                        llngCnt = llngCnt + 1
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    End With
                Loop
                
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)                                   'ｳｪﾊﾘｽﾄ
                lrAry.Clear
                
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEngEmpId)                         '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           'LOT最終更新日時
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                If .strResponsble_Emp_ID <> vbNullString Then
                    Call lrMsg.addString(CPstrRESPONSIBLE_EMP_ID, .strResponsble_Emp_ID)    '責任者ID
                Else
                    Call lrMsg.addString(CPstrRESPONSIBLE_EMP_ID, CPstrMsgNull)
                End If
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                              'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                          'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrwf__directscrap, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@最終更新日時書き換え（連続して登録する場合の対策）
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, ptypLotprestate.strLotLastUpdate)
                    
                    '@結果を格納
                    Call laMsg.getString(CPstrRESULT, lstrResult)
                    
                    '@関数の処理結果(成功)格納
                    pubblnWfDirectScrap_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypDirectScrap.strMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function


End Module
