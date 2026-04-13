'ﾌｧｲﾙ名：xxMG00Q0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット投入(組立)　機能メッセージ処理
'作成日：2004/07/26 (Mon) 17:03:19 S.Deguchi
'更新日：2009/02/23 (Mon) 14:12:04 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00Q0
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

    '関数名：pubblnLotAsmthrowin_Upd
    '機　能：組立ﾛｯﾄ投入処理
    '引　数：ltypLotAsmThrowIn  ：組立ﾛｯﾄ投入構造体
    '　　　：lstrGuidMsg        ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode    ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True:成功/False:失敗
    '作成日：2004/07/27 (Tue) 17:14:01 S.Deguchi
    '更新日：2009/02/23 (Mon) 14:12:47 N.Kojima
    '備　考：
    '　　　：2004/09/27 (Mon) 10:18:56 S.Deguchi    "ENTRY_FLAG"の対応
    '　　　：2004/11/24 (Wed) 18:20:35 S.Deguchi    技術担当者IDを送信ﾃﾞｰﾀに追加
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/06/02 (Thu) 16:54:15 S.Deguchi    Tag：ORDER_NUM追加
    '　　　：2007/12/27 (Thu) 11:32:11 N.Kojima     ﾁｯﾌﾟ電特対応。要求に"CDEN_FLAG"追加。(案件№02263)
    '　　　：2008/06/11 (Wed) 13:08:12 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/23 (Mon) 14:12:47 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ削除、ﾁｯﾌﾟ電特区分(限定工程設定)追加。(案件№03402)
    Public Function pubblnLotAsmthrowin_Upd(ByRef ltypLotAsmThrowIn As LotAsmThrowIn, _
                                            ByRef lstrGuidMsg As String, _
                                            ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@初期設定
            pstrMessageName = "ロット投入(組立)"
            pubblnLotAsmthrowin_Upd = False
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotAsmThrowIn
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@機種ID
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
                
                '@種別ID
                If .strFlowClass <> vbNullString Then
                    Call lrMsg.addString(CPstrFLOW_CLASS, .strFlowClass)
                Else
                    Call lrMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                End If
                
                '@ｴﾝﾄﾘﾌﾗｸﾞ
                If .strEntryFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_FLAG, .strEntryFlag)
                Else
                    Call lrMsg.addString(CPstrENTRY_FLAG, CPstrMsgNull)
                End If
                
                '@ｴﾝﾄﾘID
                If .strEntryID <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_ID, .strEntryID)
                Else
                    Call lrMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
                End If
                
                '@優先度
                If .strLotPriority <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_PRIORITY, .strLotPriority)
                Else
                    Call lrMsg.addString(CPstrLOT_PRIORITY, CPstrMsgNull)
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
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            
                '@ﾛｯﾄ担当者
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrENG_EMP_ID, .strEngEmpId)
                Else
                    Call lrMsg.addString(CPstrENG_EMP_ID, CPstrMsgNull)
                End If
                
                '@ｵｰﾀﾞｰ
                If .strOrderNum <> vbNullString Then
                    Call lrMsg.addString(CPstrORDER_NUM, .strOrderNum)
                Else
                    Call lrMsg.addString(CPstrORDER_NUM, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
        '@↓2009/02/23 (Mon) 14:12:29 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
               
        '        '@ﾁｯﾌﾟ電特ﾌﾗｸﾞ
        '        If .strCdenFlag <> vbNullString Then
        '            Call lrMsg.addString(CPstrCDEN_FLAG, .strCdenFlag)
        '        Else
        '            Call lrMsg.addString(CPstrCDEN_FLAG, CPstrMsgNull)
        '        End If

        '@↑2009/02/23 (Mon) 14:12:29 N.Kojima **************************************************

            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_asmthrowin, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotAsmthrowin_Upd = True
                    
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypLotAsmThrowIn.strMsgVer)
                
                
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
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnAtlsOrderList_Sel
    '機　能：ｵｰﾀﾞｰﾘｽﾄ取得
    '引　数：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrMsgVer         ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：ltypAtlsOrderList  ：応答構造体
    '戻り値：True：成功/False：失敗
    '作成日：2005/05/16 (Mon) 15:46:19 S.Deguchi
    '更新日：2009/12/03 (Thu) 12:59:47 H.Hayashi
    '備　考：
    '　　　：2005/07/21 (Thu) 15:44:01 N.Kasai      応答ﾒｯｾｰｼﾞLC_DIRECTION追加
    '　　　：2006/09/11 (Mon) 10:24:05 N.Kojima     応答に"SEND_SB_ID","SEND_SB_NAME"追加。(案件№01452)
    '　　　：2007/01/18 (Thu) 13:32:49 N.Kasai      要求にPD_ID追加(№01269)
    '　　　：2008/06/11 (Wed) 17:21:21 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/12/03 (Thu) 12:59:47 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    Public Function pubblnAtlsOrderList_Sel(ByVal lstrSBID As String, _
                                            ByVal lstrMsgVer As String, _
                                            ByVal lstrPdID As String, _
                                            ByRef ltypAtlsOrderList As AtlsOrderList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@初期設定
            pstrMessageName = "オーダー情報取得"
            pubblnAtlsOrderList_Sel = False
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
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
            
            '@機種ID
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstratlsorderlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ｵｰﾀﾞｰﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrORDER_LIST, laAry)
                    
                    With ltypAtlsOrderList
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ｵｰﾀﾞｰﾘｽﾄﾃﾞｰﾀ数格納
                        .lngAltsOrderListCnt = laAry.Count

                        '@ｵｰﾀﾞｰﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngAltsOrderListCnt > 0 Then
                        
                            '@配列領域の確保
                            'ReDim .typOrderList(.lngAltsOrderListCnt)
                            If IsNothing(.typOrderList) Then
                                .typOrderList = New List(Of OrderNoList)()
                            Else
                                .typOrderList.Clear()
                            End If
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim tmpOrderNoList As OrderNoList = New OrderNoList()
                                With tmpOrderNoList                            
                                    Call ltMsg.getString(CPstrPLAN_THROWIN_DATE, .strPlanThrowinDate)     '投入予定日
                                    Call ltMsg.getString(CPstrPD_ID, .strPdId)                            '機種
                                    Call ltMsg.getString(CPstrLR_FLAG, .strLR)                            'L/R
                                    Call ltMsg.getString(CPstrPLAN_QUANTITY, .strQuantity)                '数量
                                    Call ltMsg.getString(CPstrORDER_NUM, .strOrderNum)                    'ｵｰﾀﾞｰ№
                                    Call ltMsg.getString(CPstrPARENT_PD_ID, .strParentPdId)               '親機種
                                    Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)              'L/R表示
                                    Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                   '送品先ID
                                    Call ltMsg.getString(CPstrSEND_SB_NAME, .strSendSBName)               '送品先名(和名)
        '@↓2009/12/03 (Thu) 13:01:14 H.Hayashi **************************************************
                                    Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                        'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        '@↑2009/12/03 (Thu) 13:01:14 H.Hayashi **************************************************
                                End With
                                .typOrderList.Add(tmpOrderNoList)
                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnAtlsOrderList_Sel = True
                
                
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
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function
End Module
