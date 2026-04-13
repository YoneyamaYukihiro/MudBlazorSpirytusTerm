'ﾌｧｲﾙ名：xxMG01D0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ｶﾞｲﾀﾞﾝｽ表示 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/09/16 (Thu) 13:19:10 T.Kitagawa
'更新日：2004/09/16 (Thu) 13:19:10
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01D0
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

    '関数名：pubblnGuidInfo_Sel
    '機　能：ｶﾞｲﾀﾞﾝｽ情報取得
    '引　数：lstrSBID：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrguidinfo____Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCalssDivision：処理区分（07:最新、3G:期間指定）
    '　　　：lstrStartDate：検索開始日
    '　　　：lstrStartTime：検索開始時刻
    '　　　：lstrEndDate：検索終了日
    '　　　：lstrEndTime：検索終了時刻
    '　　　：lstrGuideLevelID：ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙID
    '　　　：lstrWpID：WPID
    '　　　：lstrMcGroupID：装置ｸﾞﾙｰﾌﾟID
    '　　　：lstrSortClass：ｿｰﾄ区分
    '　　　：ltypGuidInfoList：格納ﾃﾞｰﾀ
    '戻り値：Ture:正常、False:異常
    '作成日：2004/09/16 (Thu) 13:51:33 T.Kitagawa
    '更新日：2004/10/06 (Wed) 10:19:11 T.Kitagawa
    '備　考：2004/10/06 (Wed) 10:19:11 T.Kitagawa　処理区分、ｿｰﾄ区分追加（不具合№808）
    Public Function pubblnGuidInfo_Sel(ByVal lstrSBID As String, ByVal lstrguidinfo____Ver As String, _
                                        ByVal lstrCalssDivision As String, _
                                        ByVal lstrStartDate As String, ByVal lstrStartTime As String, _
                                        ByVal lstrEndDate As String, ByVal lstrEndTime As String, _
                                        ByVal lstrGuideLevelID As String, ByVal lstrWpId As String, _
                                        ByVal lstrMcGroupID As String, ByVal lstrSortClass As String, _
                                        ByRef ltypGuidInfoList As GuidInfoList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        
        Try
            
            pstrMessageName = "ガイダンス情報取得"
            pubblnGuidInfo_Sel = False
            
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                          'ｼｽﾃﾑﾌﾞﾛｯｸ
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrguidinfo____Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrguidinfo____Ver)             'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrCalssDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrCalssDivision)        '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            If lstrStartDate <> vbNullString Then
                Call lrMsg.addString(CPstrSTART_DATE, lstrStartDate)                '検索開始日
            Else
                Call lrMsg.addString(CPstrSTART_DATE, CPstrMsgNull)
            End If
            If lstrStartTime <> vbNullString Then
                Call lrMsg.addString(CPstrSTART_TIME, lstrStartTime)                '検索開始時刻
            Else
                Call lrMsg.addString(CPstrSTART_TIME, CPstrMsgNull)
            End If
            If lstrEndDate <> vbNullString Then
                Call lrMsg.addString(CPstrEND_DATE, lstrEndDate)                    '検索終了日
            Else
                Call lrMsg.addString(CPstrEND_DATE, CPstrMsgNull)
            End If
            If lstrEndTime <> vbNullString Then
                Call lrMsg.addString(CPstrEND_TIME, lstrEndTime)                    '検索終了時刻
            Else
                Call lrMsg.addString(CPstrEND_TIME, CPstrMsgNull)
            End If
            If lstrGuideLevelID <> vbNullString Then
                Call lrMsg.addString(CPstrGUIDE_LEVEL_ID, lstrGuideLevelID)         'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙID
            Else
                Call lrMsg.addString(CPstrGUIDE_LEVEL_ID, CPstrMsgNull)
            End If
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)                          'WPID
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            If lstrMcGroupID <> vbNullString Then
                Call lrMsg.addString(CPstrMC_GROUP_ID, lstrMcGroupID)               '装置ｸﾞﾙｰﾌﾟID
            Else
                Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
            End If
            If lstrSortClass <> vbNullString Then
                Call lrMsg.addString(CPstrSORT_CLASS, lstrSortClass)                'ｿｰﾄ区分
            Else
                Call lrMsg.addString(CPstrSORT_CLASS, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrguidinfo____, lrMsg, laMsg)
            
            With ltypGuidInfoList
                
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
                
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信結果取得
                        '@ｱﾚｰを格納
                        Call laMsg.getMsgAry(CPstrGUIDANCE_LIST, laAry)
                        '@ﾘｽﾄｶｳﾝﾄ格納
                        .lngGuidInfoCnt = laAry.Count
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngGuidInfoCnt > 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            '@配列の要素数を設定
                            .typGuidInfo = New List(Of GuidInfo)

                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry

                                'NSYS 編集用構造体初期化
                                Dim typGuidInfoTmp As GuidInfo = New GuidInfo

                                With typGuidInfoTmp
                                    Call ltMsg.getString(CPstrGUIDE_TIME, .strGuideTime)            '発生日時
                                    Call ltMsg.getString(CPstrWP_ID, .strWpID)                      'WPID
                                    Call ltMsg.getString(CPstrWP_NAME, .strWpName)                  '装置名
                                    Call ltMsg.getString(CPstrPORT_ID, .strPortID)                  'ﾎﾟｰﾄID
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)            'ｷｬﾘｱID
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                      '大工程
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                  '小工程
                                    Call ltMsg.getString(CPstrGUIDE_LEVEL_ID, .strGuideLevelID)     'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ
                                    Call ltMsg.getString(CPstrGUIDE_CODE, .strGuideCode)            'ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ
                                    Call ltMsg.getString(CPstrGUIDE_MESSAGE, .strGuideMessage)      'ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ
                                End With

                                'NSYS 編集済み構造体を追加
                                .typGuidInfo.Add(typGuidInfoTmp)

                            Next
                        End If
                        
                        '@関数の処理結果(成功)格納
                        pubblnGuidInfo_Sel = True
                        
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, lstrguidinfo____Ver)
                                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
            
                        '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
            End With
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

End Module
