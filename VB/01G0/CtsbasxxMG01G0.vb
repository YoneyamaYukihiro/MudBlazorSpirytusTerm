'ﾌｧｲﾙ名：xxMG01G0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾛｯﾄ流動票　ﾒｯｾｰｼﾞ処理ﾓｼﾞｭｰﾙ
'作成日：2004/10/21 (Thu) 14:10:07 H.Wajima
'更新日：2016/02/11 (Thu) 22:51:05 H.Hayashi
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01G0
    '*******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Friend =====================================
    '================================== Private ====================================
    '関数名：pubblnLotDetailList_Sel
    '機　能：ﾛｯﾄ流動票取得
    '引　数：lstrlot_detaillist_Ver ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：lstrCarrierID          ：ｷｬﾘｱID
    '　　　：lstrStartSeqNum        ：検索開始工順
    '　　　：lstrBeforeNum          ：前方検索数
    '　　　：lstrAfterNum           ：後方検索数
    '　　　：ltypLotDetailList      ：流動票情報格納構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/10/19 (Tue) 17:21:43 H.Wajima
    '更新日：2016/02/11 (Thu) 22:50:55 H.Hayashi
    '備　考：
    '　　　：2005/11/04 (Fri) 16:48:45 N.Kasai      応答MSG修正(RECIPE_LIST削除し、RESIPE_IDを外出し)
    '　　　：2009/03/24 (Tue) 17:31:19 N.Kojima     限定品工程を判別する為、応答に"SEND_SB_ID"、"CDEN_CLASS"を追加。(案件№03402)
    '　　　：2009/12/03 (Thu) 15:05:51 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnLotDetailList_Sel(ByVal lstrlot_detaillist_Ver As String, _
                                            ByVal lstrSBID As String, _
                                            ByVal lstrLotID As String, _
                                            ByVal lstrCarrierID As String, _
                                            ByVal lstrStartSeqNum As String, _
                                            ByVal lstrBeforeNum As String, _
                                            ByVal lstrAfterNum As String, _
                                            ByRef ltypLotDetailList As LotDetailList) As Boolean
                                            
        
        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laAry1          As TfMsgAry         'ｱﾚｰ作成用
        Dim laAry2          As TfMsgAry         'ｱﾚｰ作成用
        Dim laAry3          As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg1          As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg2          As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg3          As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET         As String           '応答取得
        Dim llngCnt1        As Integer          'ｶｳﾝﾄ
        Dim llngCnt2        As Integer          'ｶｳﾝﾄ
        Dim llngCnt3        As Integer          'ｶｳﾝﾄ
        
        Try
            
            pstrMessageName = "ロット流動票取得"
            pubblnLotDetailList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            If ltypLotDetailList.typDetailList Is Nothing Then
                ltypLotDetailList.typDetailList = New List(Of LotDetailListAry)
            End If
            
            '@***********************
            '@ 送信ﾒｯｾｰｼﾞ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_detaillist_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_detaillist_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@SBID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@検索開始工順
            If lstrStartSeqNum <> vbNullString Then
                Call lrMsg.addString(CPstrSTART_SEQ_NUM, lstrStartSeqNum)
            Else
                Call lrMsg.addString(CPstrSTART_SEQ_NUM, CPstrMsgNull)
            End If
            
            '@後方検索数
            If lstrStartSeqNum <> vbNullString Then
                Call lrMsg.addString(CPstrBEFORE_NUM, lstrBeforeNum)
            Else
                Call lrMsg.addString(CPstrBEFORE_NUM, CPstrMsgNull)
            End If
            
            '@前方検索数
            If lstrStartSeqNum <> vbNullString Then
                Call lrMsg.addString(CPstrAFTER_NUM, lstrAfterNum)
            Else
                Call lrMsg.addString(CPstrAFTER_NUM, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_detaillist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
                
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    With ltypLotDetailList
                        
                        '@受信ﾒｯｾｰｼﾞから各ﾃﾞｰﾀ取得
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                            'ﾛｯﾄID
                        Call laMsg.getString(CPstrCARRIER_ID, .strCarrierId)                    'ｷｬﾘｱID
                        Call laMsg.getString(CPstrPD_ID, .strPdId)                              '機種ID
                        Call laMsg.getString(CPstrCURRENT_SEQ_NUM, .strCurrentSeqNum)           '現在工順№
                        Call laMsg.getString(CPstrOP_ID, .strOpID)                              '現在大工程
                        Call laMsg.getString(CPstrSTEP_ID, .strStepID)                          '現在小工程
                        Call laMsg.getString(CPstrNOW_ST, .strNowST)                            'ﾛｯﾄ現在状態
                        Call laMsg.getString(CPstrWF_NUM, .strWfNum)                            'WF現在枚数
                        Call laMsg.getString(CPstrHOLD_FLAG, .strHoldFlag)                      '保留ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLAST_SEQ_NUM, .strLastSeqNum)                 '最終工順№
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           '最終更新日時
                        Call laMsg.getString(CPstrLOT_STOP_FLAG, .strStopFlag)                  '停止ﾌﾗｸﾞ
        '@↓2009/03/24 (Tue) 17:29:27 N.Kojima **************************************************
                        Call laMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                     '送品先
        '@↑2009/03/24 (Tue) 17:29:27 N.Kojima **************************************************
        '@↓2009/12/03 (Thu) 15:06:47 H.Hayashi **************************************************
                        Call laMsg.getString(CPstrSB_AREA, .strSbArea)                          'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        '@↑2009/12/03 (Thu) 15:06:47 H.Hayashi **************************************************
        '@↓2016/01/25 (Mon) 10:34:46 H.Hayashi **************************************************
                        Call laMsg.getString(CPstrGRB_CLASS, .strLotGrbClass)                   'GRB区分(LOT)
        '@↑2016/01/25 (Mon) 10:34:46 H.Hayashi **************************************************

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                        Call laMsg.getMsgAry(CPstrDETAIL_LIST, laAry1)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1のﾃﾞｰﾀ数
                        .lngDetailListCount = laAry1.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1のﾃﾞｰﾀ数が1件以上あるか
                        If .lngDetailListCount > 0 Then
                            Do While(.typDetailList.Count < .lngDetailListCount)
                                .typDetailList.Add(New LotDetailListAry)
                            Loop
                            
                            '@配列の再定義
                            Dim typDetailListTmp As LotDetailListAry = New LotDetailListAry
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲ1用ｶｳﾝﾀの初期化
                            llngCnt1 = 0
                            
                            For Each ltMsg1 In laAry1
                                
                                '@受信結果1取得
                                With typDetailListTmp
                                    
                                    '@ﾃﾞｰﾀ格納
                                    Call ltMsg1.getString(CPstrSEQ_NUM, .strSeqNum)                     'ﾛｯﾄ工順
                                    Call ltMsg1.getString(CPstrCARRIER_ID, .strCarrierId)               'ｷｬﾘｱID
                                    Call ltMsg1.getString(CPstrOP_ID, .strOpID)                         '大工程ID
                                    Call ltMsg1.getString(CPstrSTEP_ID, .strStepID)                     '小工程ID
                                    Call ltMsg1.getString(CPstrSTART_TIME, .strStartTime)               '作業開始日時
                                    Call ltMsg1.getString(CPstrEND_TIME, .strEndTime)                   '作業終了日時
                                    Call ltMsg1.getString(CPstrCOLLECTION_FLAG, .strCollectionFlag)     'ﾃﾞｰﾀ収集有無
                                    Call ltMsg1.getString(CPstrWF_NUM, .strWfNum)                       'WF枚数
                                    Call ltMsg1.getString(CPstrCHIP_NUM, .strChipNum)                   'ﾁｯﾌﾟ良品数
                                    Call ltMsg1.getString(CPstrSTART_EMP_NAME, .strStartEmpName)        '開始作業者名
                                    Call ltMsg1.getString(CPstrEND_EMP_NAME, .strEndEmpName)            '終了作業者名
                                    Call ltMsg1.getString(CPstrCOMMENT_FLAG, .strCommentFlag)           'ﾛｯﾄｺﾒﾝﾄ有無
                                    Call ltMsg1.getString(CPstrCOMMENT_TIME, .strCommentTime)           'ｺﾒﾝﾄ日時
                                    Call ltMsg1.getString(CPstrRECIPE_ID, .strRecipeId)                 'ﾚｼﾋﾟID
        '@↓2009/03/24 (Tue) 17:29:27 N.Kojima **************************************************
                                    Call ltMsg1.getString(CPstrCDEN_CLASS, .strCdenClass)               'ﾁｯﾌﾟ電特区分(限定工程設定=C：ﾁｯﾌﾟ品限定工程、M：ﾓｼﾞｭｰﾙ品限定工程、設定なし(NULL)：共通工程)
        '@↑2009/03/24 (Tue) 17:29:27 N.Kojima **************************************************
        '@↓2016/01/25 (Mon) 10:34:13 H.Hayashi **************************************************
                                    Call ltMsg1.getString(CPstrGRB_CLASS, .strDetailGrbClass)           'GRB区分(流動票)
        '@↑2016/01/25 (Mon) 10:34:13 H.Hayashi **************************************************

                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2取得
                                    Call ltMsg1.getMsgAry(CPstrWP_LIST, laAry2)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2のﾃﾞｰﾀ数格納
                                    .lngWpListCount = laAry2.Count
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2のﾃﾞｰﾀ数が1件以上あるか
                                    If .lngWpListCount > 0 Then
                                        .typWPList = New List(Of LotDetailListWPListAry)

                                        Do While (.typWPList.Count < .lngWPListCount)
                                            .typWPList.Add(New LotDetailListWPListAry)
                                        Loop
                                        
                                        '@配列の再定義
                                        Dim typWpListTmp As LotDetailListWPListAry = New LotDetailListWPListAry
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ2用ｶｳﾝﾀの初期化
                                        llngCnt2 = 0
                                        
                                        For Each ltMsg2 In laAry2
                                            
                                            '@受信結果2取得
                                            With typWpListTmp
                                                
                                                '@ﾃﾞｰﾀ格納
                                                Call ltMsg2.getString(CPstrWP_NAME, .strWpName)                 '装置名
                                                Call ltMsg2.getString(CPstrWP_ID, .strWpID)                     '装置ID
                                                
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ3取得(PORT_ID)
                                                Call ltMsg2.getMsgAry(CPstrPORT_LIST, laAry3)
                                                
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ3のﾃﾞｰﾀ数格納
                                                .lngPortIDCount = laAry3.Count
                                                
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ3のﾃﾞｰﾀ数が1件以上あるか
                                                If .lngPortIDCount > 0 Then
                                                    
                                                    '@配列の再定義
                                                    .strPortName = New List(Of String)

                                                    Do While(.strPortName.Count < .lngPortIDCount)
                                                        .strPortName.Add("")
                                                    Loop
                                                    
                                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3用ｶｳﾝﾀの初期化
                                                    llngCnt3 = 0
                                                    
                                                    '@受信結果3取得
                                                    For Each ltMsg3 In laAry3
                                                        
                                                        '@ﾃﾞｰﾀ格納
                                                        Call ltMsg3.getString(CPstrPORT_NAME, .strPortName(llngCnt3))       'ﾎﾟｰﾄID

                                                        '@ｶｳﾝﾀ3をｲﾝｸﾘﾒﾝﾄ
                                                        llngCnt3 = llngCnt3 + 1
                                                    Next
                                                End If
                                                
                                            End With

                                            .typWpList(llngCnt2) = typWpListTmp
                                            
                                            '@ｶｳﾝﾀ2をｲﾝｸﾘﾒﾝﾄ
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                    
                                End With
                                .typDetailList(llngCnt1) = typDetailListTmp
                                
                                '@ｶｳﾝﾀ1をｲﾝｸﾘﾒﾝﾄ
                                llngCnt1 = llngCnt1 + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotDetailList_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_detaillist_Ver)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞを表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            laAry1 = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            laAry1 = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotEventComment_Sel
    '機　能：履歴ｺﾒﾝﾄ取得
    '引　数：lstrLot_TravCommentVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrLotID：ﾛｯﾄID
    '　　　：lstrSeqNum：工順№
    '　　　：lstrEntryTime：ｲﾍﾞﾝﾄ日時
    '　　　：lstrComments：履歴ﾛｯﾄｺﾒﾝﾄ
    '戻り値：True：正常、False：異常
    '作成日：2004/10/26 (Tue) 11:13:26 H.Wajima
    '更新日：2004/10/26 (Tue) 18:13:34 H.Wajima
    '備　考：
    Public Function pubblnLotEventComment_Sel(ByVal lstrLot_EventCommentVer As String, _
                                                ByVal lstrSBID As String, _
                                                ByVal lstrLotID As String, _
                                                ByVal lstrSeqNum As String, _
                                                ByVal lstrEntryTime As String, _
                                                ByRef lstrComments As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "履歴コメント取得"
            pubblnLotEventComment_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrLot_EventCommentVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrLot_EventCommentVer)  'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, lstrSBID)                 'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            If lstrSeqNum <> vbNullString Then
                Call lrMsg.addString(CPstrSEQ_NUM, lstrSeqNum)              '工順№
            Else
                Call lrMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)
            End If
            
            If lstrEntryTime <> vbNullString Then
                Call lrMsg.addString(CPstrENTRY_TIME, lstrEntryTime)        'ｲﾍﾞﾝﾄ日時
            Else
                Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_eventcomment, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrCOMMENTS, lstrComments)
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotEventComment_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrLot_EventCommentVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotUseRecp_Sel
    '機　能：ﾚｼﾋﾟ情報取得
    '引　数：ltypUseRecpRec：ﾚｼﾋﾟ情報取得要求格納
    '　　　：ltypUseRecpAns：ﾚｼﾋﾟ情報取得応答格納
    '戻り値：True：正常、False：異常
    '作成日：2005/10/27 (Thu) 13:14:12 N.Kasai
    '更新日：2005/10/27 (Thu) 13:14:12
    '備　考：
    Public Function pubblnLotUseRecp_Sel(ByRef ltypUseRecpRec As UseRecpRec, ByRef ltypUseRecpAns As UseRecpAns) As Boolean
                                            
        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1          As TfMsg            'ｱﾚｰの各要素作成用1
        Dim ltMsg2          As TfMsg            'ｱﾚｰの各要素作成用2
        Dim ltMsg3          As TfMsg            'ｱﾚｰの各要素作成用3
        Dim laAry1          As TfMsgAry         'ｱﾚｰ作成用1
        Dim laAry2          As TfMsgAry         'ｱﾚｰ作成用2
        Dim laAry3          As TfMsgAry         'ｱﾚｰ作成用3
        Dim lstrRET         As String           '応答取得
        Dim llngCnt1        As Integer          'ｱﾚｲｶｳﾝﾄ1
        Dim llngCnt2        As Integer          'ｱﾚｲｶｳﾝﾄ2
        Dim llngCnt3        As Integer          'ｱﾚｲｶｳﾝﾄ3
        
        Try
            
            pstrMessageName = "レシピ情報取得"
            
            pubblnLotUseRecp_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            ltMsg1 = New TfMsg
            ltMsg2 = New TfMsg
            ltMsg3 = New TfMsg
            
            laAry1 = New TfMsgAry
            laAry2 = New TfMsgAry
            laAry3 = New TfMsgAry

            If ltypUseRecpAns.typUseWpList Is Nothing Then
                ltypUseRecpAns.typUseWpList = New List(Of UseWpList)
            End If
            
            '@【送信ﾒｯｾｰｼﾞ作成】
            With ltypUseRecpRec
                '@MSG_VER
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@OP_ID
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                '@STEP_ID
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                '@LOT_ID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
            End With
            
            '@【ﾒｯｾｰｼﾞ送信】
            Call pTerm.sendRequest(CPstrlot_userecp_, lrMsg, laMsg)
            
            '@【受信結果取得】
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@【結果判定】
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@ﾃﾞｰﾀを応答構造体へ格納
                    With ltypUseRecpAns
                        '@ﾃﾞｰﾀ格納
                        Call laMsg.getString(CPstrSELECT_CONDITION_ID, .strSelectConditionID)                           'WF選択条件
                    
                        '@【受信ﾒｯｾｰｼﾞｱﾚｲ1取得】
                        Call laMsg.getMsgAry(CPstrWP_LIST, laAry1)

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                        .lngUseWpListCnt = laAry1.Count
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngUseWpListCnt > 0 Then
                            '@領域確保
                            Do While (.typUseWpList.Count < .lngUseWpListCnt)
                                .typUseWpList.Add(New UseWpList)
                            Loop
                            
                            Dim UseWpListTmp As UseWpList = New UseWpList
                            
                            '@【受信ﾒｯｾｰｼﾞｱﾚｲ1より各項目取得】
                            llngCnt1 = 0
                            For Each ltMsg1 In laAry1
                                '@ﾃﾞｰﾀ格納
                                Call ltMsg1.getString(CPstrWP_ID, UseWpListTmp.strWpID)                      '装置ID
                                Call ltMsg1.getString(CPstrWP_NAME, UseWpListTmp.strWpName)                  '装置名
                                Call ltMsg1.getString(CPstrWF_ID, UseWpListTmp.strWfId)                      'WFID
                                Call ltMsg1.getString(CPstrHISTORY_FLAG, UseWpListTmp.strHistoryFlag)        '実績ﾌﾗｸﾞ
                                
                                '@【受信ﾒｯｾｰｼﾞｱﾚｲ2取得】
                                Call ltMsg1.getMsgAry(CPstrRECIPE_LIST, laAry2)
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2のｶｳﾝﾄ数
                                UseWpListTmp.lngtypUseRecipeListCnt = laAry2.Count
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                If UseWpListTmp.lngtypUseRecipeListCnt > 0 Then

                                    UseWpListTmp.typUseRecipeList = New List(Of UseRecipeList)

                                    '@領域確保
                                    Do While (UseWpListTmp.typUseRecipeList.Count < UseWpListTmp.lngtypUseRecipeListCnt)
                                        UseWpListTmp.typUseRecipeList.Add(New UseRecipeList)
                                    Loop

                                    Dim UseRecipeListTmp As UseRecipeList = New UseRecipeList

                                    '@【受信ﾒｯｾｰｼﾞｱﾚｲ2より各項目取得】
                                    llngCnt2 = 0
                                    For Each ltMsg2 In laAry2
                                        '@ﾃﾞｰﾀ格納
                                        Call ltMsg2.getString(CPstrRECIPE_ID, _
                                                UseRecipeListTmp.strRecipeId)         'ﾚｼﾋﾟID
                                        Call ltMsg2.getString(CPstrDEFAULT_FLAG, _
                                                UseRecipeListTmp.strDefaultFlag)      'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                                        Call ltMsg2.getString(CPstrRECIPE_COMMENTS, _
                                                UseRecipeListTmp.strRecipeComments)   'ﾚｼﾋﾟｺﾒﾝﾄ
                                        
                                       '@【受信ﾒｯｾｰｼﾞｱﾚｲ3取得】
                                        Call ltMsg2.getMsgAry(CPstrRECIPE_BODY_LIST, laAry3)
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ3のｶｳﾝﾄ格納
                                        UseRecipeListTmp.lngUseRecipeBodyListCnt = laAry3.Count
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                        If UseRecipeListTmp.lngUseRecipeBodyListCnt > 0 Then

                                            UseRecipeListTmp.typUseRecipeBodyList = New List(Of UseRecipeBodyList)

                                            '@領域確保
                                            Do While (UseRecipeListTmp.typUseRecipeBodyList.Count < UseRecipeListTmp.lngUseRecipeBodyListCnt)
                                                UseRecipeListTmp.typUseRecipeBodyList.Add(New UseRecipeBodyList)
                                            Loop
            
                                            Dim UseRecipeBodyListTmp As UseRecipeBodyList = New UseRecipeBodyList

                                            '@【受信ﾒｯｾｰｼﾞｱﾚｲ3より各項目取得】
                                            llngCnt3 = 0
                                            For Each ltMsg3 In laAry3
                                                '@ﾃﾞｰﾀ格納
                                                Call ltMsg3.getString(CPstrRECIPE_VALUE, _
                                                    UseRecipeBodyListTmp.strRecipeValue)       'ﾚｼﾋﾟ値/ﾚﾁｸﾙ型番
                                                Call ltMsg3.getString(CPstrRECIPE_ITEM, _
                                                    UseRecipeBodyListTmp.strRecipeItem)        'ﾚｼﾋﾟｱｲﾃﾑ
                                                Call ltMsg3.getString(CPstrVALUE_TYPE, _
                                                    UseRecipeBodyListTmp.strValueType)         'ﾃﾞｰﾀﾀｲﾌﾟ

                                                UseRecipeListTmp.typUseRecipeBodyList(llngCnt3) = UseRecipeBodyListTmp
                                                
                                                '@ｶｳﾝﾀ3ｲﾝｸﾘﾒﾝﾄ
                                                llngCnt3 = llngCnt3 + 1
                                            Next
                                        End If
                                        UseWpListTmp.typUseRecipeList(llngCnt2) = UseRecipeListTmp
                                        
                                        '@ｶｳﾝﾀ2ｲﾝｸﾘﾒﾝﾄ
                                        llngCnt2 = llngCnt2 + 1
                                    Next
                                End If
                                .typUseWpList(llngCnt1) = UseWpListTmp

                                '@ｶｳﾝﾀ1ｲﾝｸﾘﾒﾝﾄ
                                llngCnt1 = llngCnt1 + 1
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnLotUseRecp_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypUseRecpRec.strMsgVer)
                    
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
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            laAry1 = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            laAry1 = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            
        End Try
    End Function

End Module
