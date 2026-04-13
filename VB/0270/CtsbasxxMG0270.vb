'ﾌｧｲﾙ名：xxMG0270.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：アクション予約　通信メッセージ用標準モジュール
'作成日：2004/06/14 (Mon) 15:48:48 H.Wajima
'更新日：2012/11/07 (Wed) 09:13:23 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0270
    '***************************************************************************************
    '                                     * 型の記述 *
    '***************************************************************************************
    '======================================= Public=========================================
    '=======================================Private=========================================
    '***************************************************************************************
    '                                     *定数の記述*
    '***************************************************************************************
    '=======================================Private=========================================
    '***************************************************************************************
    '                                     *変数の記述*
    '***************************************************************************************
    '======================================= Public=========================================
    '***************************************************************************************
    '                                     *関数の記述*
    '***************************************************************************************
    '=======================================Private=========================================

    '関数名：pubblnStepUsedWpList_Sel
    '機　能：装置使用工程取得
    '引　数：lstrmas_stepusedwplistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：llngStepListCnt            ：装置使用工程ﾘｽﾄｶｳﾝﾄ
    '　　　：lstrWpID                   ：装置ID
    '　　　：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '戻り値：True:正常終了　False:異常終了
    '作成日：2004/05/24 (Mon) 16:52:49 N.Kasai
    '更新日：2008/06/12 (Thu) 13:26:08 N.Kojima
    '備　考：
    '　　　：2005/04/26 (Tue) 15:55:28 S.Deguchi    応答に,Action_Flagを追加
    '　　　：2008/06/12 (Thu) 13:26:08 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnStepUsedWpList_Sel(ByVal lstrmas_stepusedwplistVer As String, _
                                             ByRef llngStepListCnt As Integer, _
                                             ByVal lstrWpId As String, _
                                             ByVal lstrSBID As String) As Boolean

        Dim lrMsg                       As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry                       As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET                     As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "装置使用工程取得"
            pubblnStepUsedWpList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_stepusedwplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_stepusedwplistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_stepusedwplist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
        '@↓2012/11/06 (Tue) 15:29:52 T.Oide **************************************************
                    '@WF_ACTION_FLAG取得
                    Call laMsg.getString(CPstrWF_ACTION_FLAG, pstrWfActionFlag)
        '@↑2012/11/06 (Tue) 15:29:52 T.Oide **************************************************
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：装置使用工程ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrSTEP_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：装置使用工程ﾘｽﾄﾃﾞｰﾀ数
                    llngStepListCnt = laAry.Count
                    
                    '@装置使用工程ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngStepListCnt > 0 Then
                    
                        '@配列領域の確保
                        ptypWpuseinfo = New List(Of Wpuseinfo)
                        
                        '@ｶｳﾝﾀの初期化
                        'llngCnt = 1
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim ptypWpuseinfoTmp As Wpuseinfo = New Wpuseinfo
                        
                            '@受信結果取得
                            With ptypWpuseinfoTmp
                            
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                  '大工程
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)              '小工程
                                Call ltMsg.getString(CPstrACTION_FLAG, .strActionFlag)      'ｱｸｼｮﾝﾌﾗｸﾞ
                            End With

                            'NSYS 編集済み構造体追加
                            ptypWpuseinfo.Add(ptypWpuseinfoTmp)
                            
                            '@ｶｳﾝﾀを+1する
                            'llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnStepUsedWpList_Sel = True
                     
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_stepusedwplistVer)
                    
                    
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

    '関数名：pubblnLotTraveler_Sel
    '機　能：ﾛｯﾄｽﾃｯﾌﾟ取得
    '引　数：lstrlot_travelerVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：llngStepListCnt    ：ﾛｯﾄ工程ﾘｽﾄｶｳﾝﾄ
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrTechManID      ：技術担当者ID
    '　　　：lstrTechManName    ：技術担当者名
    '　　　：lstrFlowClass      ：種別
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/05/25 (Tue) 12:41:33 N.Kasai
    '更新日：2008/06/12 (Thu) 13:26:39 N.Kojima
    '備　考：
    '　　　：2004/09/27 (Mon) 10:53:27 M.Miura　    引数と受信ﾒｯｾｰｼﾞに技術担当者ID、名を追加
    '　　　：2005/04/26 (Tue) 15:55:28 S.Deguchi    応答に,Action_Flagを追加
    '　　　：2005/11/25 (Fri) 15:06:15 S.Deguchi    応答に"FLOW_CLASS"を追加
    Public Function pubblnLotTraveler_Sel(ByVal lstrlot_travelerVer As String, _
                                          ByRef llngStepListCnt As Integer, _
                                          ByVal lstrLotID As String, _
                                          ByVal lstrSBID As String, _
                                          ByRef lstrTechManID As String, _
                                          ByRef lstrTechManName As String, _
                                          ByRef lstrFlowClass As String) As Boolean
                                          
        '@********************************************************************************
        '@　ｱｸｼｮﾝ予約画面専用ﾒｯｾｰｼﾞです。他の機能と併用して使用しないで下さい。(SVより依頼)
        '@　※工順変更中のﾛｯﾄはﾃﾞｰﾀの対象外とするとのこと。
        '@********************************************************************************
                                          

        Dim lrMsg                       As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry                       As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET                     As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "ロットステップ取得"
            pubblnLotTraveler_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_travelerVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_travelerVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_traveler, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrENG_EMP_ID, lstrTechManID)            '技術担当者ID
                    Call laMsg.getString(CPstrENG_EMP_NAME, lstrTechManName)        '技術担当者名
                    Call laMsg.getString(CPstrFLOW_CLASS, lstrFlowClass)            '種別
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾛｯﾄ工程ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrSTEP_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾛｯﾄ工程ﾘｽﾄﾃﾞｰﾀ数
                    llngStepListCnt = laAry.Count
                    
                    '@ﾛｯﾄ工程ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngStepListCnt > 0 Then
                        
                        '@配列領域の確保
                        ptypWpuseinfo = New List(Of Wpuseinfo)
                        
                        '@ｶｳﾝﾀの初期化
                        'llngCnt = 1
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim ptypWpuseinfoTmp As Wpuseinfo = New Wpuseinfo
                            
                            With ptypWpuseinfoTmp
                            
                                Call ltMsg.getString(CPstrSTEP_NUM, .strSTEPNUM)            'ｽﾃｯﾌﾟ番号
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                  '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)              '小工程ID
                                Call ltMsg.getString(CPstrALT_STEP_FLAG, .strAltStepFlag)   '代替工程有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrACTION_FLAG, .strActionFlag)      'ｱｸｼｮﾝﾌﾗｸﾞ
                            End With

                            'NSYS 編集済み構造体追加
                            ptypWpuseinfo.Add(ptypWpuseinfoTmp)
                            
                            '@ｶｳﾝﾀを+1する
                            'llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotTraveler_Sel = True
                 
                     
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_travelerVer)
                
                
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

    '関数名：pubblnMasPdtraveler_Sel
    '機　能：機種別ｽﾃｯﾌﾟ取得
    '引　数：lstrmas_pdtravelerVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：llngStepListCnt        ：機種工程ﾘｽﾄｶｳﾝﾄ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrPdID               ：機種ID
    '　　　：lstrEntryID            ：機種ﾊﾞｰｼﾞｮﾝ
    '戻り値：True:正常終了、False:以上終了
    '作成日：2004/06/29 (Tue) 17:53:08 H.Wajima
    '更新日：2008/06/12 (Thu) 13:44:55 N.Kojima
    '備　考：
    '　　　：2004/09/14 (Tue) 12:00:05 N.Kasai      新COM対応　lstrClassDivision削除(不要ﾀｸﾞ)
    '　　　：2005/04/26 (Tue) 15:55:28 S.Deguchi    応答に,Action_Flagを追加
    '　　　：2008/06/12 (Thu) 13:44:55 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasPdtraveler_Sel(ByVal lstrmas_pdtravelerVer As String, _
                                            ByRef llngStepListCnt As Integer, _
                                            ByVal lstrSBID As String, _
                                            ByVal lstrPdID As String, _
                                            ByVal lstrEntryID As String) As Boolean

        Dim lrMsg                       As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry                       As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET                     As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "機種別ステップ取得"
            pubblnMasPdtraveler_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
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
            
            '@ｴﾝﾄﾘID
            If lstrEntryID <> vbNullString Then
                Call lrMsg.addString(CPstrENTRY_ID, lstrEntryID)
            Else
                Call lrMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_pdtravelerVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_pdtravelerVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_pdtraveler, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：機種工程ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrSTEP_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：機種工程ﾘｽﾄﾃﾞｰﾀ数
                    llngStepListCnt = laAry.Count
                    
                    '@機種工程ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngStepListCnt > 0 Then
                    
                        '@配列領域の確保
                        ptypWpuseinfo = New List(Of Wpuseinfo)
                        
                        '@ｶｳﾝﾀの初期化
                        'llngCnt = 1
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim ptypWpuseinfoTmp As Wpuseinfo = New Wpuseinfo

                            With ptypWpuseinfoTmp
                            
                                Call ltMsg.getString(CPstrSTEP_NUM, .strSTEPNUM)                    'ｽﾃｯﾌﾟ番号
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                          '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                      '小工程ID
                                Call ltMsg.getString(CPstrALT_STEP_FLAG, .strAltStepFlag)           '代替工程有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrREWORK_STEP_FLAG, .strReworkStepFlag)     'ﾘﾜｰｸ工程有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrREWORK_ROUTE_ID, .strReworkRouteID)       'ﾘﾜｰｸﾙｰﾄID
                                Call ltMsg.getString(CPstrSPECIAL_STEP_FLAG, .strSpecialStepFlag)   '特殊工程有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrSPECIAL_ROUTE_ID, .strSpecialRouteID)     '特殊ﾙｰﾄID
                                Call ltMsg.getString(CPstrACTION_FLAG, .strActionFlag)              'ｱｸｼｮﾝﾌﾗｸﾞ
                            End With

                            'NSYS 編集済み構造体追加
                            ptypWpuseinfo.Add(ptypWpuseinfoTmp)
                            
                            '@ｶｳﾝﾀを+1する
                            'llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasPdtraveler_Sel = True
                
                     
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_pdtravelerVer)

                    
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

    '関数名：pubblnLotActinfo_Sel
    '機　能：ｱｸｼｮﾝ内容検索
    '引　数：lstrlot_actinfo_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrLotActionTypeID：ｱｸｼｮﾝ予約ﾀｲﾌﾟ
    '　　　：lstrOpID           ：大工程
    '　　　：lstrStepID         ：小工程
    '　　　：lstrItemName       ：項目名
    '　　　：lstrActionTrigger  ：ｱｸｼｮﾝﾄﾘｶﾞｰ
    '戻り値：True:正常終了、False:以上終了
    '作成日：2004/06/17 (Thu) 20:04:34 H.Wajima
    '更新日：2012/11/06 (Tue) 16:37:40 T.Oide
    '備　考：
    '　　　：2005/08/09 (Tue) 16:44:14 N.Kojima     応答ﾀｸﾞ変更。"HOLD_TERM_DATE"→"HOLD_PERIOD"(不具合№2985)
    '　　　：2008/04/14 (Mon) 17:00:53 M.Koni       CLASS_DIVISION引数削除 <案件No.02254>
    '　　　：2012/11/06 (Tue) 16:38:11 T.Oide       Chip誤送品防止対応
    Public Function pubblnLotActinfo_Sel(ByVal lstrlot_actinfo_Ver As String, _
                                         ByVal lstrSBID As String, _
                                         ByVal lstrLotActionTypeID As String, _
                                         ByVal lstrOpID As String, _
                                         ByVal lstrStepID As String, _
                                         ByVal lstrItemName As String, _
                                         ByVal lstrActionTrigger As String) As Boolean

        Dim lrMsg                       As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry                       As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET                     As String           '応答取得

        Try

            pstrMessageName = "アクション内容検索"
            pubblnLotActinfo_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ
            If lstrLotActionTypeID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ACTION_TYPE_ID, lstrLotActionTypeID)
            Else
                Call lrMsg.addString(CPstrLOT_ACTION_TYPE_ID, CPstrMsgNull)
            End If
            
            '@大工程
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            
            '@小工程
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            
            '@項目名
            If lstrItemName <> vbNullString Then
                Call lrMsg.addString(CPstrITEM_NAME, lstrItemName)
            Else
                Call lrMsg.addString(CPstrITEM_NAME, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_actinfo_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_actinfo_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｱｸｼｮﾝﾄﾘｶﾞｰ
            If lstrActionTrigger <> vbNullString Then
                Call lrMsg.addString(CPstrACTION_TRIGGER, lstrActionTrigger)
            Else
                Call lrMsg.addString(CPstrACTION_TRIGGER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_actinfo_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    With ptypLotActioninfo
                    
                        Call laMsg.getString(CPstrLOT_ACTION_ID, .strLotActionID)           'ﾛｯﾄｱｸｼｮﾝ予約ID
                        Call laMsg.getString(CPstrMESSAGE, .strMessage)                     'ｱｸｼｮﾝﾒｯｾｰｼﾞ
                        Call laMsg.getString(CPstrWORK_DIRECTION_ID, .strWorkDirectionID)   '作業指示書№
                        Call laMsg.getString(CPstrENG_EMP_ID, .strEngEmpId)                 '技術担当者ID
                        Call laMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)             '技術担当者名
                        Call laMsg.getString(CPstrSTOP_HOLD_FLAG, .strStopHoldFlag)         '停止/保留ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrHOLD_REASON_ID, .strHoldReasonID)         '保留理由
                        Call laMsg.getString(CPstrSTART_TIME, .strStartTime)                '開始日時
                        Call laMsg.getString(CPstrEND_TIME, .strEndTime)                    '終了日時
                        Call laMsg.getString(CPstrEDIT_TIME, .strEditTime)                  '最終更新日時
                        Call laMsg.getString(CPstrHOLD_COMMENTS, .strHoldComments)          '保留ｺﾒﾝﾄ
                        Call laMsg.getString(CPstrHOLD_PERIOD, .strHoldPeriod)              '保留期限(相対日数)
                        Call laMsg.getString(CPstrHOLD_EMP_ID, .strHoldEmpID)               '保留責任者ID
                        Call laMsg.getString(CPstrHOLD_EMP_NAME, .strHoldEmpName)           '保留責任者名
                        
        '@↓2012/11/06 (Tue) 16:46:08 T.Oide **************************************************
                        '@ｳｪﾊｰｱｸｼｮﾝ設定の情報取得
                        Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                        
                        '@初期化
                        .lngWfActionCnt = 0
                        
                        '@ｱﾚｰが1件以上存在するか
                        If laAry.Count > 0 Then
                            
                            '@ｶｳﾝﾄ数設定
                            .lngWfActionCnt = laAry.Count
                            
                            '@配列領域の確保
                            .typWfAction = New List(Of WfAction)
                            
                            '@ｶｳﾝﾀの初期化
                            'llngCnt = 1
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry

                                'NSYS 編集用構造体追加
                                Dim typWfActionTmp As WfAction = New WfAction

                                With typWfActionTmp
                                    Call ltMsg.getString(CPstrWF_ID, .strWfId)              'WF_ID
                                    Call ltMsg.getString(CPstrEXEC_TIME, .strExecTime)      '実行時刻
                                End With

                                'NSYS 編集済み構造体追加
                                .typWfAction.Add(typWfActionTmp)

                                '@ｶｳﾝﾀを+1する
                                'llngCnt = llngCnt + 1
                            Next
                            
                        End If
        '@↑2012/11/06 (Tue) 16:46:08 T.Oide **************************************************

                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotActinfo_Sel = True
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_actinfo_Ver)

                                
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

    '関数名：pubblnLotactrsv_Upd
    '機　能：ｱｸｼｮﾝ予約設定
    '　　　：lstrlot_actrsv__Ver    ：Msgﾊﾞｰｼﾞｮﾝ
    '引　数：ltypLotactrsv          ：ｱｸｼｮﾝ予約設定構造体(送信)
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/05/25 (Tue) 17:15:42 N.Kasai
    '更新日：2012/10/30 (Tue) 15:41:50 T.Oide
    '備　考：
    Public Function pubblnLotactrsv_Upd(ByVal lstrlot_actrsv__Ver As String, _
                                        ByRef ltypLotactrsv As Lotactrsv) As Boolean

        Dim lrMsg                       As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry                       As TfMsgAry         'ｱﾚｰ作成用(ﾘｸｴｽﾄ)
        Dim ltMsg                       As TfMsg            'ｱﾚｰの各要素作成用(ﾘｸｴｽﾄ)
        Dim laMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET                     As String           '応答取得
        Dim llngCnt                     As Integer          'ｶｳﾝﾀ
        
        Try

            '@初期設定
            pstrMessageName = "アクション予約設定"
            pubblnLotactrsv_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg
            
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotactrsv
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ(0:ﾛｯﾄ、1:機種、2:装置、3:工程)
                If .strLotActionTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ACTION_TYPE_ID, .strLotActionTypeID)
                Else
                    Call lrMsg.addString(CPstrLOT_ACTION_TYPE_ID, CPstrMsgNull)
                End If
                
                '@大工程
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                
                '@小工程
                If .strSTEP_ID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strSTEP_ID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                
                '@項目名(予約ﾀｲﾌﾟで右項目をｾｯﾄ(0:ﾛｯﾄ、1:機種Ver、2:装置)
                If .strItemName <> vbNullString Then
                    Call lrMsg.addString(CPstrITEM_NAME, .strItemName)
                Else
                    Call lrMsg.addString(CPstrITEM_NAME, CPstrMsgNull)
                End If
                
                '@ｱｸｼｮﾝﾄﾘｶﾞｰ(0:作業開始、1:作業終了、2:全ﾀｲﾐﾝｸﾞ)
                If .strActionTrigger <> vbNullString Then
                    Call lrMsg.addString(CPstrACTION_TRIGGER, .strActionTrigger)
                Else
                    Call lrMsg.addString(CPstrACTION_TRIGGER, CPstrMsgNull)
                End If
                
                '@ｱｸｼｮﾝﾒｯｾｰｼﾞ(256文字)
                If .strMessage <> vbNullString Then
                    Call lrMsg.addString(CPstrMESSAGE, .strMessage)
                Else
                    Call lrMsg.addString(CPstrMESSAGE, CPstrMsgNull)
                End If
                
                '@作業指示書No
                If .strWorkDirectionID <> vbNullString Then
                    Call lrMsg.addString(CPstrWORK_DIRECTION_ID, .strWorkDirectionID)
                Else
                    Call lrMsg.addString(CPstrWORK_DIRECTION_ID, CPstrMsgNull)
                End If
                
                '@技術担当者ID
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrENG_EMP_ID, .strEngEmpId)
                Else
                    Call lrMsg.addString(CPstrENG_EMP_ID, CPstrMsgNull)
                End If
                
                '@停止/保留ﾌﾗｸﾞ(0:なし、1:停止、2:保留)
                If .strStopHoldFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrSTOP_HOLD_FLAG, .strStopHoldFlag)
                Else
                    Call lrMsg.addString(CPstrSTOP_HOLD_FLAG, CPstrMsgNull)
                End If
                
                '@保留理由ID
                If .strHoldReasonID <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_REASON_ID, .strHoldReasonID)
                Else
                    Call lrMsg.addString(CPstrHOLD_REASON_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@開始日付
                If .strStartTime <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_TIME, .strStartTime)
                Else
                    Call lrMsg.addString(CPstrSTART_TIME, CPstrMsgNull)
                End If
                
                '@終了日付
                If .strEndTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEND_TIME, .strEndTime)
                Else
                    Call lrMsg.addString(CPstrEND_TIME, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@保留ｺﾒﾝﾄ
                If .strHoldComments <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_COMMENTS, .strHoldComments)
                Else
                    Call lrMsg.addString(CPstrHOLD_COMMENTS, CPstrMsgNull)
                End If
                
                '@保留相対日数(保留期限)
                If .strHoldPeriod <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_PERIOD, .strHoldPeriod)
                Else
                    Call lrMsg.addString(CPstrHOLD_PERIOD, CPstrMsgNull)
                End If
                
                '@保留責任者ID
                If .strHoldEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_EMP_ID, .strHoldEmpID)
                Else
                    Call lrMsg.addString(CPstrHOLD_EMP_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrlot_actrsv__Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_actrsv__Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
        '@↓2012/10/30 (Tue) 15:43:09 T.Oide **************************************************
                '@WF設定ｱｸｼｮﾝ予約がある場合
                If .lngWfActionCnt <> 0 Then
                    For llngCnt = 0 To .lngWfActionCnt - 1
                        
                        '@WF_ID
                        If .typWfAction(llngCnt).strWfId <> vbNullString Then
                            Call ltMsg.addString(CPstrWF_ID, .typWfAction(llngCnt).strWfId)     'WF_ID
                        Else
                            Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                        End If
                        
                        '@実行時刻
                        If .typWfAction(llngCnt).strExecTime <> vbNullString Then
                            Call ltMsg.addString(CPstrEXEC_TIME, .typWfAction(llngCnt).strExecTime) '実行時刻
                        Else
                            Call ltMsg.addString(CPstrEXEC_TIME, CPstrMsgNull)
                        End If
                        
                        '@ｱﾚｰの要素追加
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear

                    Next llngCnt

                End If
                
                '@ｱﾚｰ追加(WF設定ｱｸｼｮﾝ予約が無い場合でも空のLISTﾀｸﾞは付けておく)
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
                lrAry.Clear
        '@↑2012/10/30 (Tue) 15:43:09 T.Oide **************************************************
                
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_actrsv__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotactrsv_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_actrsv__Ver)

                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
        '@↓2012/10/30 (Tue) 16:20:45 T.Oide **************************************************
            lrAry = Nothing
            ltMsg = Nothing
        '@↑2012/10/30 (Tue) 16:20:45 T.Oide **************************************************
            laMsg = Nothing
                
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
        '@↓2012/10/30 (Tue) 16:20:45 T.Oide **************************************************
            lrAry = Nothing
            ltMsg = Nothing
        '@↑2012/10/30 (Tue) 16:20:45 T.Oide **************************************************
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnLotDelAct_Upd
    '機　能：ｱｸｼｮﾝ予約削除
    '引　数：lstrlot_delact__Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotActionID    ：ﾛｯﾄｱｸｼｮﾝ予約ID
    '　　　：lstrEditTime       ：最終更新日時
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/06/28 (Mon) 20:48:19 H.Wajima
    '更新日：2008/06/12 (Thu) 14:01:28 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 14:01:28 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnLotDelAct_Upd(ByVal lstrlot_delact__Ver As String, _
                                        ByVal lstrLotActionID As String, _
                                        ByVal lstrEditTime As String)

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            '@初期設定
            pstrMessageName = "アクション予約削除"
            pubblnLotDelAct_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ﾛｯﾄｱｸｼｮﾝ予約ID
            If lstrLotActionID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ACTION_ID, lstrLotActionID)
            Else
                Call lrMsg.addString(CPstrLOT_ACTION_ID, CPstrMsgNull)
            End If
            
            '@最終更新日時
            If lstrEditTime <> vbNullString Then
                Call lrMsg.addString(CPstrEDIT_TIME, lstrEditTime)
            Else
                Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_delact__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_delact__Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_delact__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotDelAct_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_delact__Ver)

                    
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

    '関数名：pubblnLotAltTraveler_Sel
    '機　能：代替工程取得
    '引　数：ltypLotAltTraveler：代替工程取得要求構造体
    '　　　：ltypLotAltStepList：代替工程取得応答構造体
    '戻り値：True：正常、False：異常
    '作成日：2004/09/09 (Thu) 09:33:23 M.Miura
    '更新日：2008/06/12 (Thu) 14:01:48 N.Kojima
    '備　考：
    '　　　：2005/04/26 (Tue) 15:55:28 S.Deguchi    応答に,Action_Flagを追加
    '　　　：2008/06/12 (Thu) 14:01:48 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnLotAltTraveler_Sel(ByRef ltypLotAltTraveler As LotAltTraveler, _
                                             ByRef ltypLotAltStepList As LotAltStepList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ(temp1)
        Dim laAry1              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ1)
        Dim lstrRET             As String           '応答取得
        Dim llngSCnt            As Integer          '総件数

        Try

            '@初期設定
            pstrMessageName = "代替工程取得"
            pubblnLotAltTraveler_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotAltTraveler

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
            
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
            
                '@機種ID
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
            
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
            
                '@ｽﾃｯﾌﾟ番号
                If .strSTEPNUM <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_NUM, .strSTEPNUM)
                Else
                    Call lrMsg.addString(CPstrSTEP_NUM, CPstrMsgNull)
                End If
            
                '@ｴﾝﾄﾘID
                If .strEntryID <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_ID, .strEntryID)
                Else
                    Call lrMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
                End If
            
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_alttraveler, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypLotAltStepList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：代替工程ﾘｽﾄ1(代替番号と代替工程ﾘｽﾄ(詳細))
                        Call laMsg.getMsgAry(CPstrALT_STEP_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：代替工程ﾘｽﾄ1ﾃﾞｰﾀ数
                        .lngAltNumberCnt = laAry.Count
                        
                        '@総件数
                        llngSCnt = 0
                        
                        '@代替工程ﾘｽﾄ1ﾃﾞｰﾀが1件以上存在するか
                        If .lngAltNumberCnt > 0 Then

                            '@配列領域の確保
                            .typAltNumberList = New List(Of AltNumberList)

                            '@ｶｳﾝﾀの初期化
                            'llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry

                                'NSYS 編集用構造体初期化
                                Dim typAltNumberListTmp As AltNumberList = New AltNumberList
                                
                                '@代替番号を格納
                                Call ltMsg.getString(CPstrALT_NUMBER, typAltNumberListTmp.strAltNumber)

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：代替工程ﾘｽﾄ2
                                Call ltMsg.getMsgAry(CPstrSTEP_LIST, laAry1)

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2数：代替工程ﾘｽﾄ2ﾃﾞｰﾀ数
                                typAltNumberListTmp.lngAltStepCnt = laAry1.Count

                                '@代替工程ﾘｽﾄ2ﾃﾞｰﾀが1件以上存在するか
                                If typAltNumberListTmp.lngAltStepCnt > 0 Then
                                
                                    '@配列領域の確保(ﾙｰﾌﾟ数により配列が再定義されるので、"ReDim Preserve"使用)
                                    typAltNumberListTmp.typAltStepList = New List(Of AltStepList)
                                    
                                    '@ｶｳﾝﾀ2の初期化
                                    'llngCnt1 = 1
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各Msg取得
                                    For Each ltMsg1 In laAry1

                                        'NSYS 編集用構造体初期化
                                        Dim typAltStepListTmp As AltStepList = New AltStepList
                                    
                                        Call ltMsg1.getString(CPstrOP_ID, typAltStepListTmp.strOpID)                      '大工程ID
                                        Call ltMsg1.getString(CPstrSTEP_ID, typAltStepListTmp.strStepID)                  '小工程ID
                                        Call ltMsg1.getString(CPstrSEQ_NUM, typAltStepListTmp.strSeqNum)                  'ﾛｯﾄ工順
                                        Call ltMsg1.getString(CPstrREWORK_FLAG, typAltStepListTmp.strReworkFlag)          'ﾘﾜｰｸﾌﾗｸﾞ
                                        Call ltMsg1.getString(CPstrREWORK_ROUTE_ID, typAltStepListTmp.strReworkRouteID)   'ﾘﾜｰｸ時ﾙｰﾄID
                                        Call ltMsg1.getString(CPstrACTION_FLAG, typAltStepListTmp.strActionFlag)          'ｱｸｼｮﾝﾌﾗｸﾞ

                                        '@ｶｳﾝﾀ2を+1する
                                        'llngCnt1 = llngCnt1 + 1
                                        
                                        '@総件数を+1する
                                        llngSCnt = llngSCnt + 1

                                        'NSYS 編集済み構造体追加
                                        typAltNumberListTmp.typAltStepList.Add(typAltStepListTmp)
                                    Next
                                End If
                                
                                '@ｶｳﾝﾀを+1する
                                'llngCnt = llngCnt + 1

                                'NSYS 編集済み構造体追加
                                .typAltNumberList.Add(typAltNumberListTmp)
                            Next
                        End If
                        
                        '@総件数格納
                        .lngStepCnt = llngSCnt
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotAltTraveler_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypLotAltTraveler.strMsgVer)


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
            ltMsg1 = Nothing
            laAry1 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMasReworkTraveler_Sel
    '機　能：ﾘﾜｰｸ工程取得
    '引　数：lstrMsgVer             ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrOpID               ：大工程ID
    '　　　：lstrReworkRouteID      ：ﾘﾜｰｸﾙｰﾄID
    '　　　：lstrLotActionTypeID    ：ｱｸｼｮﾝ予約ﾀｲﾌﾟ(0:ﾛｯﾄ,1:機種,2:装置,3:工程)
    '　　　：lstrPdID               ：機種ID
    '　　　：ltypMasReworkTraveler  ：ﾘﾜｰｸ工程取得
    '戻り値：True：正常、False：なし
    '作成日：2004/09/09 (Thu) 10:00:43 M.Miura
    '更新日：2008/06/12 (Thu) 14:15:36 N.Kojima
    '備　考：
    '　　　：2005/04/26 (Tue) 15:55:28 S.Deguchi    応答に,Action_Flagを追加
    '　　　：2005/05/06 (Fri) 14:19:09 S.Deguchi    送信Tagに大工程を追加
    '　　　：2007/06/22 (Fri) 16:37:59 N.Kasai      要求ﾀｸﾞ追加(LOT_ACTION_TYPE_ID,PD_ID)№01965
    '　　　：2008/06/12 (Thu) 14:15:36 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasReworkTraveler_Sel(ByVal lstrMsgVer As String, _
                                                ByVal lstrOpID As String, _
                                                ByVal lstrReworkRouteID As String, _
                                                ByVal lstrLotActionTypeID As String, _
                                                ByVal lstrPdID As String, _
                                                ByRef ltypMasReworkTraveler As MasReworkTraveler) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "リワーク工程取得"
            pubblnMasReworkTraveler_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@大工程ID
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            
            '@ﾘﾜｰｸﾙｰﾄID
            If lstrReworkRouteID <> vbNullString Then
                Call lrMsg.addString(CPstrREWORK_ROUTE_ID, lstrReworkRouteID)
            Else
                Call lrMsg.addString(CPstrREWORK_ROUTE_ID, CPstrMsgNull)
            End If
            
            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ(0:ﾛｯﾄ、1:機種、2:装置、3:工程)
            If lstrLotActionTypeID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ACTION_TYPE_ID, lstrLotActionTypeID)
            Else
                Call lrMsg.addString(CPstrLOT_ACTION_TYPE_ID, CPstrMsgNull)
            End If
         
            '@機種ID
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_reworktraveler, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    With ltypMasReworkTraveler
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾘﾜｰｸ工程ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrREWORK_STEP_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾘﾜｰｸ工程ﾘｽﾄﾃﾞｰﾀ数
                        .lngReworkStepCnt = laAry.Count

                        '@ﾘﾜｰｸ工程ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngReworkStepCnt > 0 Then
                            
                            '@配列領域の確保
                            .typReworkStepList = New List(Of ReworkStepList)
                        
                            '@ｶｳﾝﾀの初期化
                            'llngCnt = 1

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry

                                'NSYS 編集用構造体初期化
                                Dim typReworkStepListTmp As ReworkStepList = New ReworkStepList
                            
                                Call ltMsg.getString(CPstrSTEP_NUM, typReworkStepListTmp.strSTEPNUM)                         'ｽﾃｯﾌﾟ番号
                                Call ltMsg.getString(CPstrOP_ID, typReworkStepListTmp.strOpID)                               '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, typReworkStepListTmp.strStepID)                           '小工程ID
                                Call ltMsg.getString(CPstrREWORK_RETURN_OP_ID, typReworkStepListTmp.strReworkReturnOpID)     'ﾘﾜｰｸ戻り先大工程
                                Call ltMsg.getString(CPstrREWORK_RETURN_STEP_ID, typReworkStepListTmp.strReworkReturnStepID) 'ﾘﾜｰｸ戻り先小工程
                                Call ltMsg.getString(CPstrACTION_FLAG, typReworkStepListTmp.strActionFlag)                   'ｱｸｼｮﾝﾌﾗｸﾞ

                                'NSYS 編集済み構造体追加
                                .typReworkStepList.Add(typReworkStepListTmp)
                                
                                '@ｶｳﾝﾀを+1する
                                'llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasReworkTraveler_Sel = True


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
