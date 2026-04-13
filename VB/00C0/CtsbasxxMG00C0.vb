'ﾌｧｲﾙ名：xxMG00C0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：運用ﾓｰﾄﾞ/装置状態変更 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/06/18 (Fri) 16:47:40 S.Deguchi
'更新日：2008/02/18 (Mon) 14:57:58 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00C0
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

    '関数名：pubblnEqChgMode_Upd
    '機　能：運用ﾓｰﾄﾞ/装置状態変更要求
    '引　数：ltypEqChgMode  ：運用ﾓｰﾄﾞ変更構造体
    '　　　：lstrGuidMsg    ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '　　　：lstrEntryTime  ：登録日時(WP_EVENT_HISTORYの登録日時)
    '戻り値：Ture:正常、False:異常
    '作成日：2004/06/21 (Mon) 17:16:02 N.Kasai
    '更新日：2007/03/23 (Fri) 10:20:18 N.Kojima
    '備　考：
    '　　　：2005/03/01 (Tue) 18:54:43 N.Kojima　   要求に変更前装置状態ID、変更後装置状態ID、停止ﾌﾗｸﾞを追加(改善№524、525)
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/12/16 (Fri) 14:58:20 N.Kasai      要求MSGにMESSAGE_IDを追加
    '　　　：2005/12/22 (Thu) 15:49:40 N.Kasai      要求MSGにPORT_LISTを追加
    '　　　：2006/01/13 (Fri) 11:51:23 N.Kasai      仕様変更↑PORT_LISTを削除
    '　　　：2007/03/23 (Fri) 10:20:18 N.Kojima     応答ﾀｸﾞに"ENTRY_TIME"を追加。(案件№01830)
    Public Function pubblnEqChgMode_Upd(ByRef ltypEqChgMode As EqChgMode, _
                                        ByRef lstrGuidMsg As String, _
                                        ByRef lstrGuidMsgCode As String, _
                                        ByRef lstrEntryTime As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "運用モード変更要求"
            pubblnEqChgMode_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypEqChgMode
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@MESﾓｰﾄﾞ(M1,M2,S1,S2,F)
                If .strMesModeId <> vbNullString Then
                    Call lrMsg.addString(CPstrMES_MODE_ID, .strMesModeId)
                Else
                    Call lrMsg.addString(CPstrMES_MODE_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@変更後装置状態ID
                If .strUseId <> vbNullString Then
                    Call lrMsg.addString(CPstrUSE_ID, .strUseId)
                Else
                    Call lrMsg.addString(CPstrUSE_ID, CPstrMsgNull)
                End If
                
                '@変更前装置状態ID
                If .strOldUseID <> vbNullString Then
                    Call lrMsg.addString(CPstrOLD_USE_ID, .strOldUseID)
                Else
                    Call lrMsg.addString(CPstrOLD_USE_ID, CPstrMsgNull)
                End If
                
                '@WP停止ﾌﾗｸﾞ
                If .strWpStopFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_STOP_FLAG, .strWpStopFlag)
                Else
                    Call lrMsg.addString(CPstrWP_STOP_FLAG, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞID
                If .strMessageID <> vbNullString Then
                    Call lrMsg.addString(CPstrMESSAGE_ID, .strMessageID)
                Else
                    Call lrMsg.addString(CPstrMESSAGE_ID, CPstrMsgNull)
                End If
         
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__chgmode_, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    
                    '@成功の場合(true)
                    Case CPstrTRUE
                        
                        '@受信結果取得
                        Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                        Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                        Call laMsg.getString(CPstrENTRY_TIME, lstrEntryTime)             '登録日時(WP_EVENT_HISTORYの登録日時)
                        
                        '@関数の処理結果(成功)格納
                        pubblnEqChgMode_Upd = True
                        
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
                
            End With
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@解放
            lrMsg = Nothing
            laMsg = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnEqEmgChgMode_Upd
    '機　能：運用ﾓｰﾄﾞ強制変更要求
    '引　数：ltypEqChgMode  ：運用ﾓｰﾄﾞ変更構造体(共用する)
    '　　　：lstrEntryTime  ：WP_EVENT_HISTORYの登録日時
    '戻り値：Ture:正常、False:異常
    '作成日：2004/08/26 (Thu) 11:42:37 N.Kojima
    '更新日：2005/12/16 (Fri) 15:01:21 N.Kasai
    '備　考：2005/03/01 (Tue) 18:54:43 N.Kojima　   要求に変更前装置状態ID、変更後装置状態ID、停止ﾌﾗｸﾞを追加(改善№524、525)
    '　　　：2005/12/16 (Fri) 15:01:21 N.Kasai      要求MSGにMESSAGE_IDを追加
    '　　　：2007/03/23 (Fri) 10:20:18 N.Kojima     応答ﾀｸﾞに"ENTRY_TIME"を追加。(案件№01830)
    Public Function pubblnEqEmgChgMode_Upd(ByRef ltypEqChgMode As EqChgMode, _
                                           ByRef lstrEntryTime As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "運用モード強制変更要求"
            pubblnEqEmgChgMode_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypEqChgMode
            
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)              'WPID
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                If .strMesModeId <> vbNullString Then
                    Call lrMsg.addString(CPstrMES_MODE_ID, .strMesModeId)   'MESﾓｰﾄﾞ(M1)
                Else
                    Call lrMsg.addString(CPstrMES_MODE_ID, CPstrMsgNull)
                End If
                
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)            '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)       'ｺﾒﾝﾄ(作業ﾒﾓ)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@変更後装置状態ID
                If .strUseId <> vbNullString Then
                    Call lrMsg.addString(CPstrUSE_ID, .strUseId)
                Else
                    Call lrMsg.addString(CPstrUSE_ID, CPstrMsgNull)
                End If
                
                '@変更前装置状態ID
                If .strOldUseID <> vbNullString Then
                    Call lrMsg.addString(CPstrOLD_USE_ID, .strOldUseID)
                Else
                    Call lrMsg.addString(CPstrOLD_USE_ID, CPstrMsgNull)
                End If
                
                '@WP停止ﾌﾗｸﾞ
                If .strWpStopFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_STOP_FLAG, .strWpStopFlag)
                Else
                    Call lrMsg.addString(CPstrWP_STOP_FLAG, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞID
                If .strMessageID <> vbNullString Then
                    Call lrMsg.addString(CPstrMESSAGE_ID, .strMessageID)
                Else
                    Call lrMsg.addString(CPstrMESSAGE_ID, CPstrMsgNull)
                End If

                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__emgchgmode, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信結果取得
                        '@受信ﾒｯｾｰｼﾞﾃﾞｰﾀ無し
                        
                        Call laMsg.getString(CPstrENTRY_TIME, lstrEntryTime)             '登録日時(WP_EVENT_HISTORYの登録日時)
                        
                        '@関数の処理結果(成功)格納
                        pubblnEqEmgChgMode_Upd = True
                        
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@「TRM01E　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
                
            End With
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@解放
            lrMsg = Nothing
            laMsg = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnChgtrnstat_Upd
    '機　能：搬送ﾎﾟｰﾄ有効・無効変更要求
    '引　数：ltypChgtrnstatReq：要求格納構造体
    '戻り値：Ture:正常、False:異常
    '作成日：2005/12/21 (Wed) 17:12:33 N.Kasai
    '更新日：2005/12/21 (Wed) 17:12:33
    '備　考：
    Public Function pubblnChgtrnstat_Upd(ByRef ltypChgtrnstatReq As ChgtrnstatReq) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try
            
            pstrMessageName = "搬送ポート 有効・無効変更要求"
            
            pubblnChgtrnstat_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypChgtrnstatReq
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@WP_ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@EMP_ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@COMMENTS
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@ﾎﾟｰﾄﾘｽﾄ
                For llngCnt = 0 To .llngtrnportListCnt - 1
                    '@PORT_ID
                    If .typtrnportList(llngCnt).strPortID <> vbNullString Then
                        Call ltMsg.addString(CPstrPORT_ID, .typtrnportList(llngCnt).strPortID)
                    Else
                        Call ltMsg.addString(CPstrPORT_ID, CPstrMsgNull)
                    End If
                    '@TRANS_SERVICE_STATUS
                    If .typtrnportList(llngCnt).strTransServiceStatus <> vbNullString Then
                        Call ltMsg.addString(CPstrTRANS_SERVICE_STATUS, .typtrnportList(llngCnt).strTransServiceStatus)
                    Else
                        Call ltMsg.addString(CPstrTRANS_SERVICE_STATUS, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    Call ltMsg.Clear
                Next
                '@PORT_LIST
                Call lrMsg.addMsgAry(CPstrPORT_LIST, lrAry)
                Call lrAry.Clear
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__chgtrnstat, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得

                    '@関数の処理結果(成功)格納
                    pubblnChgtrnstat_Upd = True

                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypChgtrnstatReq.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

        End Try
    End Function

    '関数名：pubblnEqChgProcOrder_Upd
    '機　能：装置処理順変更要求
    '引　数：ltypEqChgProcOrderReq  ：装置処理順変更構造体
    '　　　：llngCollectTypeCnt     ：選択ﾚｼﾋﾟｸﾞﾙｰﾌﾟ数
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：Ture:正常、False:異常
    '作成日：2006/08/29 (Tue) 10:29:47 T.Kitagawa
    '更新日：2009/10/20 (Tue) 10:26:59 T.Oide
    '備　考：
    '　　　：2007/10/15 (Mon) 19:43:04 N.Kojima     要求に"COLLECT_TYPE_LIST"追加。(案件№02152)
    '　　　：2009/10/20 (Tue) 10:26:59 T.Oide       搬送モード追加(案件№03761)
    Public Function pubblnEqChgProcOrder_Upd(ByRef ltypEqChgProcOrderReq As EqChgProcOrderReq, _
                                             ByVal llngCollectTypeCnt As Integer, _
                                             ByRef lstrGuidMsg As String, _
                                             ByRef lstrGuidMsgCode As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ：temp)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim llngCnt             As Integer          '汎用ｶｳﾝﾀ
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "装置処理順変更要求"
            pubblnEqChgProcOrder_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypEqChgProcOrderReq
            
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)              'WPID
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                If .strRecipeFlowNum <> vbNullString Then
                    Call lrMsg.addString(CPstrRECIPE_FLOW_NUM, .strRecipeFlowNum)   '連続処理ﾛｯﾄ数
                Else
                    Call lrMsg.addString(CPstrRECIPE_FLOW_NUM, CPstrMsgNull)
                End If
                
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)       'ｺﾒﾝﾄ(作業ﾒﾓ)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)            '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
        '@↓2009/10/20 (Tue) 11:05:14 T.Oide **************************************************
                If .strCollectTypeFlg <> vbNullString Then
                    Call lrMsg.addString(CPstrCOLLECT_TYPE_FLAG, .strCollectTypeFlg)    'ｺﾚｸﾄﾀｲﾌﾟﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrCOLLECT_TYPE_FLAG, CPstrMsgNull)
                End If
        '@↑2009/10/20 (Tue) 11:05:14 T.Oide **************************************************
                
                '@Aryﾒｯｾｰｼﾞ作成(ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾘｽﾄ)
                For llngCnt = 0 To llngCollectTypeCnt - 1
                    If .typCollectTypeList(llngCnt).strCollectTypeNum <> vbNullString Then
                        Call ltMsg.addString(CPstrCOLLECT_TYPE_NUM, .typCollectTypeList(llngCnt).strCollectTypeNum)    'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ番号(ID)
                    Else
                        Call ltMsg.addString(CPstrCOLLECT_TYPE_NUM, CPstrMsgNull)
                    End If

                    Call lrAry.Add(ltMsg)
                Next
                Call lrMsg.addMsgAry(CPstrCOLLECT_TYPE_LIST, lrAry)
                
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__chgprocorder, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信結果取得
                        Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                        Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                        
                        '@関数の処理結果(成功)格納
                        pubblnEqChgProcOrder_Upd = True
                        
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@「TRM01E　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
                
            End With
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMasWpProcessingList_Sel
    '機　能：装置処理部用途取得
    '引　数：ltypWpProcessingNameListReq：要求格納
    '　　　：ltypWpProcessingNameListAns：応答格納
    '戻り値：Ture:正常、False:異常
    '作成日：2006/11/21 (Tue) 10:08:13 N.Kasai
    '更新日：2006/11/21 (Tue) 10:08:13
    '備　考：
    Public Function pubblnMasWpProcessingList_Sel(ByRef ltypWpProcessingNameListReq As WpProcessingNameListReq, _
                                                  ByRef ltypWpProcessingNameListAns As WpProcessingNameListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "装置処理部用途取得"
            
            pubblnMasWpProcessingList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypWpProcessingNameListReq
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@処理区分
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@WP_ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_wpprocessingnamelist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrPROCESSING_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    ltypWpProcessingNameListAns.lngProcessingListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypWpProcessingNameListAns.lngProcessingListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        ltypWpProcessingNameListAns.typProcessingList = New List(Of ProcessingList)(ltypWpProcessingNameListAns.lngProcessingListCnt)
                        
                        '@ｶｳﾝﾄ初期化
                        llngCnt = 1
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypProcessingListTmp As New ProcessingList
                            With ltypProcessingListTmp
                                Call ltMsg.getString(CPstrCHAMBER_ID, .strChamberId)                '処理部用途ID
                                Call ltMsg.getString(CPstrPROCESSING_NAME, .strProcessingName)      '処理部用途名
                                Call ltMsg.getString(CPstrDISP_ON_FLAG, .strDispOnFlag)             '0: 表示しない､1: 表示する
                            End With
                            
                            ltypWpProcessingNameListAns.typProcessingList.Add(ltypProcessingListTmp)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnMasWpProcessingList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypWpProcessingNameListReq.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
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

    '関数名：pubblnMasChamberUseList_Sel
    '機　能：装置処理部状態取得
    '引　数：lstrMsgVer：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：ltypChamberUseListAns：応答格納
    '戻り値：Ture:正常、False:異常
    '作成日：2006/11/21 (Tue) 10:22:26 N.Kasai
    '更新日：2006/11/21 (Tue) 10:22:26
    '備　考：
    Public Function pubblnMasChamberUseList_Sel(ByVal lstrMsgVer As String, _
                                                   ByRef ltypChamberUseListAns As ChamberuseListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用


        Try

            pstrMessageName = "装置処理部状態取得"
            
            pubblnMasChamberUseList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_chamberuselist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrCHAMBER_USE_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    ltypChamberUseListAns.lngChamberUseListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypChamberUseListAns.lngChamberUseListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        ltypChamberUseListAns.typChamberUseList = New List(Of ChamberUseList)(ltypChamberUseListAns.lngChamberUseListCnt)
                        
                        '@ｶｳﾝﾄ初期化
                        llngCnt = 1
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypChamberUseListTmp As New ChamberUseList
                            With ltypChamberUseListTmp
                                Call ltMsg.getString(CPstrUSE_ID, .strUseId)          '処理部状態ID
                                Call ltMsg.getString(CPstrUSE_NAME, .strUseName)      '処理部状態名
                            End With

                            ltypChamberUseListAns.typChamberUseList.Add(ltypChamberUseListTmp)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnMasChamberUseList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
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

    '関数名：pubblnEqWpProcessingUse_Sel
    '機　能：装置処理部用途ﾘｽﾄ取得
    '引　数：ltypWpProcessingUseReq：要求格納
    '　　　：ltypWpProcessingUseAns：応答格納
    '戻り値：Ture:正常、False:異常
    '作成日：2006/11/21 (Tue) 10:36:43 N.Kasai
    '更新日：2006/11/21 (Tue) 10:36:43
    '備　考：
    Public Function pubblnEqWpProcessingUse_Sel(ByRef ltypWpProcessingUseReq As WpProcessingUseReq, _
                                                   ByRef ltypWpProcessingUseAns As WpProcessingUseAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "装置処理部用途リスト取得"
            
            pubblnEqWpProcessingUse_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypWpProcessingUseReq
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@WP_ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__wpprocessinguse, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrPROCESSING_USE_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    ltypWpProcessingUseAns.lngProcessingUseListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypWpProcessingUseAns.lngProcessingUseListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        ltypWpProcessingUseAns.typProcessingUseList = New List(Of ProcessingUseList)(ltypWpProcessingUseAns.lngProcessingUseListCnt)
                        
                        '@ｶｳﾝﾄ初期化
                        llngCnt = 1
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypProcessingUseListTmp As ProcessingUseList
                            With ltypProcessingUseListTmp
                                Call ltMsg.getString(CPstrNO, .strNo)                           '順番
                                Call ltMsg.getString(CPstrCHAMBER_ID, .strChamberId)            '処理部用途ID
                                Call ltMsg.getString(CPstrCHAMBER_USE_ID, .strChamberUseId)     '処理部状態ID
                                Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)              '更新日時
                            End With
                            
                            ltypWpProcessingUseAns.typProcessingUseList.Add(ltypProcessingUseListTmp)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnEqWpProcessingUse_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypWpProcessingUseReq.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
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

    '関数名：pubblnChgWpProcessingUse_Upd
    '機　能：装置処理部用途変更
    '引　数：ltypChgWpProcessingUseReq：要求格納
    '戻り値：Ture:正常、False:異常
    '作成日：2006/11/21 (Tue) 10:48:20 N.Kasai
    '更新日：2006/11/21 (Tue) 10:48:20
    '備　考：
    Public Function pubblnChgWpProcessingUse_Upd(ByRef ltypChgWpProcessingUseReq As ChgWpProcessingUseReq) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try
            
            pstrMessageName = "装置処理部用途変更"
            
            pubblnChgWpProcessingUse_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypChgWpProcessingUseReq
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@処理区分
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@WP_ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@EMP_ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@COMMENTS
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@処理部用途状態ﾘｽﾄ
                For llngCnt = 0 To .lngProcessingUseListCnt - 1
                    '@№
                    If .typProcessingUseList(llngCnt).strNo <> vbNullString Then
                        Call ltMsg.addString(CPstrNO, .typProcessingUseList(llngCnt).strNo)
                    Else
                        Call ltMsg.addString(CPstrNO, CPstrMsgNull)
                    End If
                    '@処理部用途ID
                    If .typProcessingUseList(llngCnt).strChamberId <> vbNullString Then
                        Call ltMsg.addString(CPstrCHAMBER_ID, .typProcessingUseList(llngCnt).strChamberId)
                    Else
                        Call ltMsg.addString(CPstrCHAMBER_ID, CPstrMsgNull)
                    End If
                    '@処理部状態ID
                    If .typProcessingUseList(llngCnt).strChamberUseId <> vbNullString Then
                        Call ltMsg.addString(CPstrCHAMBER_USE_ID, .typProcessingUseList(llngCnt).strChamberUseId)
                    Else
                        Call ltMsg.addString(CPstrCHAMBER_USE_ID, CPstrMsgNull)
                    End If
                    '@処理部用途ID(変更前)
                    If .typProcessingUseList(llngCnt).strOldChamberId <> vbNullString Then
                        Call ltMsg.addString(CPstrOLD_CHAMBER_ID, .typProcessingUseList(llngCnt).strOldChamberId)
                    Else
                        Call ltMsg.addString(CPstrOLD_CHAMBER_ID, CPstrMsgNull)
                    End If
                    '@処理部状態ID(変更前)
                    If .typProcessingUseList(llngCnt).strOldChamberUseId <> vbNullString Then
                        Call ltMsg.addString(CPstrOLD_CHAMBER_USE_ID, .typProcessingUseList(llngCnt).strOldChamberUseId)
                    Else
                        Call ltMsg.addString(CPstrOLD_CHAMBER_USE_ID, CPstrMsgNull)
                    End If
                    '@処理部状態ID(変更前)
                    If .typProcessingUseList(llngCnt).strEditTime <> vbNullString Then
                        Call ltMsg.addString(CPstrEDIT_TIME, .typProcessingUseList(llngCnt).strEditTime)
                    Else
                        Call ltMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    Call ltMsg.Clear
                Next
                '@PORT_LIST
                Call lrMsg.addMsgAry(CPstrPROCESSING_USE_LIST, lrAry)
                Call lrAry.Clear
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__chgwpprocessinguse, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得

                    '@関数の処理結果(成功)格納
                    pubblnChgWpProcessingUse_Upd = True

                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypChgWpProcessingUseReq.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

        End Try
    End Function

    '関数名：pubblnEqCarUnload_Upd
    '機　能：ｷｬﾘｱ強制搬出要求
    '引　数：ltypEqCarUnloadReq：要求格納
    '戻り値：Ture:正常、False:異常
    '作成日：2007/11/28 (Wed) 11:35:24 Y.yoneyama
    '更新日：2007/11/28 (Wed) 11:35:24
    '備　考：
    Public Function pubblnEqCarUnload_Upd(ByRef ltypEqCarUnloadReq As EqCarUnloadReq) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "キャリア強制搬出要求"
            
            pubblnEqCarUnload_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypEqCarUnloadReq
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@WP_ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@ﾎﾟｰﾄID
                If .strPortID = vbNullString Then
                    Call lrMsg.addString(CPstrPORT_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrPORT_ID, .strPortID)
                End If
                
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
                '@EMP_ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__carunload, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得

                    '@関数の処理結果(成功)格納
                    pubblnEqCarUnload_Upd = True

                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypEqCarUnloadReq.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
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

End Module
