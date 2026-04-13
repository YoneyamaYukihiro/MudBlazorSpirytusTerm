'ﾌｧｲﾙ名：xxMG00Y0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：特殊流動　通信メッセージ用標準モジュール
'作成日：2004/08/23 (Mon) 10:04:11 M.Miura
'更新日：2008/07/28 (Mon) 15:19:32 N.Kojima
'備　考：
'　　　：2004/10/21 (Thu) 13:04:49 S.Deguchi ﾛｯﾄﾘﾜｰｸを「特殊流動」へ変更
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00Y0
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnLotReworkSet_Upd
    '機　能：特殊流動登録
    '引　数：lstrlot_reworksetVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotReworkSet       ：特殊流動登録構造体
    '　　　：lstrLotID              ：特殊流動ﾛｯﾄID
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：正常、False：異常
    '作成日：2004/08/24 (Tue) 19:47:37 M.Miura
    '更新日：2008/07/29 (Tue) 14:16:42 N.Kojima
    '備　考：
    '　　　：2004/10/20 (Wed) 12:00:40 S.Deguchi    ClassDivision追加
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/08/23 (Tue) 16:56:04 S.Deguchi    最終更新日時を応答に追加
    '　　　：2005/09/20 (Tue) 08:38:40 S.Deguchi    運用障害№540の対応でﾘﾜｰｸ原因を追加
    '　　　：2008/07/29 (Tue) 14:16:42 N.Kojima     要求に「ﾘﾜｰｸ原因(小分類)」を追加。(案件№03007)
    Public Function pubblnLotReworkSet_Upd(ByRef ltypLotReWorkSet As LotReWorkSet, _
                                           ByRef lstrLotID As String, _
                                           ByRef lstrGuidMsg As String, _
                                           ByRef lstrGuidMsgCode As String) As Boolean
                                           
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            '@各種初期設定
            pstrMessageName = "特殊流動登録"
            pubblnLotReworkSet_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotReWorkSet

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@作業者ﾒﾓ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@ﾘﾜｰｸ原因(大分類)
                If .strReworkReason <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_CODE, .strReworkReason)
                Else
                    Call lrMsg.addString(CPstrREASON_CODE, CPstrMsgNull)
                End If
                
                '@ﾘﾜｰｸ原因(小分類)
                If .strReworkSubReason <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_SUB_CODE, .strReworkSubReason)
                Else
                    Call lrMsg.addString(CPstrREASON_SUB_CODE, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
                '@分割有/無
                If .strDivFlag <> vbNullString Then
                     Call lrMsg.addString(CPstrDIVIDE_FLAG, .strDivFlag)
                Else
                    Call lrMsg.addString(CPstrDIVIDE_FLAG, CPstrMsgNull)
                End If

                '@ﾙｰﾄID
                If .strRouteID <> vbNullString Then
                    Call lrMsg.addString(CPstrROUTE_ID, .strRouteID)
                Else
                    Call lrMsg.addString(CPstrROUTE_ID, CPstrMsgNull)
                End If

                '@Aryﾒｯｾｰｼﾞ作成
                For llngCnt = 0 To .lngWfMapListCnt - 1
                    
                    '@WFID
                    If .typReWrkWFMapList(llngCnt).strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, .typReWrkWFMapList(llngCnt).strWfId)
                        Call lrAry.Add(ltMsg)
                    End If
                    
                    ltMsg.Clear
                    
                Next llngCnt
                
                Call lrMsg.addMsgAry(CPstrWF_MAP_LIST, lrAry)
                lrAry.Clear
                
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_reworkset, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_ID, lstrLotID)                                        '特殊流動ﾛｯﾄID
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                                         'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                                'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, ltypLotReWorkSet.strLotLastUpdate)       '最終更新日時
                    Call laMsg.getString(CPstrTO_LOT_ID, ltypLotReWorkSet.strToLotID)                   '移載ﾛｯﾄID
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotReworkSet_Upd = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypLotReWorkSet.strMsgVer)
                    
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
            lrAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnMasReworkReson_Sel
    '機　能：ﾘﾜｰｸ原因(大分類)情報取得
    '引　数：lstrmas_reworkreasonVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypReasonCodeList     ：理由ｺｰﾄﾞ格納用構造体
    '戻り値：True：成功、False：失敗
    '作成日：2005/08/17 (Wed) 13:40:27 S.Deguchi
    '更新日：2008/07/30 (Wed) 14:46:36 N.Kojima
    '備　考：
    '　　　：2008/07/30 (Wed) 14:46:36 N.Kojima     ｿｰｽ整備。(案件№03007)
    Public Function pubblnMasReworkReson_Sel(ByVal lstrmas_reworkreasonVer As String, _
                                             ByRef ltypReasonCodeList As ReasonCode) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            '@各種初期設定
            pstrMessageName = "リワーク原因コード取得"
            pubblnMasReworkReson_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_reworkreasonVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_reworkreasonVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_reworkreason, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    With ltypReasonCodeList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾘﾜｰｸ原因(大分類)ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrREASON_CODE_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾘﾜｰｸ原因(大分類)ﾘｽﾄﾃﾞｰﾀ数
                        .lngReasonCodeListCnt = laAry.Count
                        
                        '@ﾘﾜｰｸ原因(大分類)ﾘｽﾄﾃﾞｰﾀ数が1件以上存在するか
                        If .lngReasonCodeListCnt <> 0 Then
                            '@配列領域の確保
                            If .typReasonCodeList Is Nothing Then
                                .typReasonCodeList = New List(Of ReasonCodeList)
                            Else
                                .typReasonCodeList.Clear
                            End If
                            
                            '@ｶｳﾝﾀ初期化
                            'llngCnt = 1
                            
                            '@取得情報格納
                            For Each ltMsg In laAry                            
                                Dim tmpTypReasonCodeList = New ReasonCodeList
                                With tmpTypReasonCodeList
                                    Call ltMsg.getString(CPstrREASON_CODE, .strReasonCode)     '理由ｺｰﾄﾞ
                                    Call ltMsg.getString(CPstrREASON_NAME, .strReasonName)     '理由名
                                    Call ltMsg.getString(CPstrHOLD_FLAG, .strHoldFlag)         '保留ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrEXCP_FLAG, .strExcpFlag)         '異常処理ﾌﾗｸﾞ
                                End With
                                .typReasonCodeList.Add(tmpTypReasonCodeList)

                                '@ｶｳﾝﾀを+1する
                                'llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasReworkReson_Sel = True
                    
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_reworkreasonVer)
                    
                    
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

    '@↓2008/07/30 (Wed) 14:45:20 N.Kojima **************************************************
    '関数名：pubblnMasReworkSubReson_Sel
    '機　能：ﾘﾜｰｸ原因(小分類)情報取得
    '引　数：lstrmas_reworksubreasonVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrReasonCode             ：理由ｺｰﾄﾞ(大分類)　※ﾘﾜｰｸ原因(大分類)
    '　　　：ltypReasonSubCodeList      ：理由ｺｰﾄﾞ(小分類)格納用構造体
    '戻り値：True：成功、False：失敗
    '作成日：2008/07/30 (Wed) 14:46:29 N.Kojima
    '更新日：2008/07/30 (Wed) 14:46:29
    '備　考：
    Public Function pubblnMasReworkSubReson_Sel(ByVal lstrmas_reworksubreasonVer As String, _
                                                ByVal lstrReasonCode As String, _
                                                ByRef ltypReasonSubCodeList As ReasonSubCode) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            '@各種初期設定
            pstrMessageName = "リワーク原因(小分類)コード取得"
            pubblnMasReworkSubReson_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_reworksubreasonVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_reworksubreasonVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾘﾜｰｸ原因(大分類)
            If lstrReasonCode <> vbNullString Then
                Call lrMsg.addString(CPstrREASON_CODE, lstrReasonCode)
            Else
                Call lrMsg.addString(CPstrREASON_CODE, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_reworksubreason, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    With ltypReasonSubCodeList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾘﾜｰｸ原因(小分類)ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrREASON_SUB_CODE_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾘﾜｰｸ原因(小分類)ﾘｽﾄﾃﾞｰﾀ数
                        .lngReasonSubCodeListCnt = laAry.Count
                        
                        '@ﾘﾜｰｸ原因(小分類)ﾘｽﾄﾃﾞｰﾀ数が1件以上存在するか
                        If .lngReasonSubCodeListCnt <> 0 Then
                        
                            '@配列領域の確保
                            If .typReasonSubCodeList Is Nothing Then
                                .typReasonSubCodeList = New List(Of ReasonSubCodeList)
                            Else
                                .typReasonSubCodeList.Clear
                            End If
                            
                            '@ｶｳﾝﾀ初期化
                            'llngCnt = 1
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                Dim tmpTypReasonSubCodeList = New ReasonSubCodeList
                                With tmpTypReasonSubCodeList
                                    Call ltMsg.getString(CPstrREASON_SUB_CODE, .strReasonSubCode)     '理由ｺｰﾄﾞ(小分類)
                                    Call ltMsg.getString(CPstrREASON_SUB_NAME, .strReasonSubName)     '理由名(小分類)
                                End With
                                .typReasonSubCodeList.Add(tmpTypReasonSubCodeList)

                                '@ｶｳﾝﾀを+1する
                                'llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasReworkSubReson_Sel = True
                    
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_reworksubreasonVer)
                    
                    
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
    '@↑2008/07/30 (Wed) 14:45:20 N.Kojima **************************************************

    '関数名：pubblnLotReworkSetDirect_Upd
    '機　能：ﾛｯﾄﾘﾜｰｸ(一括移載)
    '引　数：ltypLotReWorkSet   ：ﾛｯﾄﾘﾜｰｸ登録ﾃﾞｰﾀ格納用
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：lstrGuidMsg        ：ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ
    '　　　：lstrGuidMsgCode    ：ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2008/03/04 (Tue) 16:43:55 N.Kojima
    '更新日：2008/07/29 (Tue) 14:18:33 N.Kojima
    '備　考：
    '　　　：2008/03/04 (Tue) 16:43:55 N.Kojima     ﾍｯﾀﾞｰｺﾒﾝﾄが抜けていたので、追加。内容の変更はなし。
    '　　　：2008/07/29 (Tue) 14:18:33 N.Kojima     要求に「ﾘﾜｰｸ原因(小分類)」を追加。(案件№03007)
    Public Function pubblnLotReworkSetDirect_Upd(ByRef ltypLotReWorkSet As LotReWorkSet, _
                                                 ByRef lstrLotID As String, _
                                                 ByRef lstrGuidMsg As String, _
                                                 ByRef lstrGuidMsgCode As String) As Boolean
                                           
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            '@各種初期設定
            pstrMessageName = "ロットリワーク(一括移載)"
            pubblnLotReworkSetDirect_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotReWorkSet

                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@作業者ﾒﾓ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@ﾘﾜｰｸ原因(大分類)
                If .strReworkReason <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_CODE, .strReworkReason)
                Else
                    Call lrMsg.addString(CPstrREASON_CODE, CPstrMsgNull)
                End If
                
                '@ﾘﾜｰｸ原因(小分類)
                If .strReworkSubReason <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_SUB_CODE, .strReworkSubReason)
                Else
                    Call lrMsg.addString(CPstrREASON_SUB_CODE, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
                '@移載先ｷｬﾘｱID
                If .strToCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrTO_CARRIER_ID, .strToCarrierId)
                Else
                    Call lrMsg.addString(CPstrTO_CARRIER_ID, CPstrMsgNull)
                End If

                '@ﾙｰﾄID
                If .strRouteID <> vbNullString Then
                    Call lrMsg.addString(CPstrROUTE_ID, .strRouteID)
                Else
                    Call lrMsg.addString(CPstrROUTE_ID, CPstrMsgNull)
                End If

                '@WFﾏｯﾌﾟのﾘｽﾄを作成
                For llngCnt = 0 To .lngWfMapListCnt - 1
                
                    '@WFID
                    If .typReWrkWFMapList(llngCnt).strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, .typReWrkWFMapList(llngCnt).strWfId)
                        Call lrAry.Add(ltMsg)
                    End If

                    ltMsg.Clear

                Next llngCnt

                Call lrMsg.addMsgAry(CPstrWF_MAP_LIST, lrAry)
                lrAry.Clear

            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_reworksetdirect, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_ID, lstrLotID)                                        '特殊流動ﾛｯﾄID
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                                         'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                                'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, ltypLotReWorkSet.strLotLastUpdate)       '最終更新日時
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotReworkSetDirect_Upd = True

                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypLotReWorkSet.strMsgVer)
                
                
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
            lrAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

End Module
