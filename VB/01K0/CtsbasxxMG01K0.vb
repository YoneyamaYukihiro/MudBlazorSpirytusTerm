'ﾌｧｲﾙ名：xxMG01K0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：流動票バージョンアップ　通信メッセージ用標準モジュール
'作成日：2004/11/11 (Thu) 12:43:35 N.Kasai
'更新日：2008/06/11 (Wed) 15:50:56 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01K0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubblnChgTrvlist_Sel
    '機　能：流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ対象一覧
    '引　数：ltypChgTrvListRec  ：要求ﾒｯｾｰｼﾞ格納構造体
    '　　　：ltypChgTrvListAns()：応答ﾒｯｾｰｼﾞ格納構造体
    '　　　：llngLotListCnt     ：要求ﾘｽﾄｶｳﾝﾄ
    '戻り値：True：成功、False：失敗
    '作成日：2004/11/12 (Fri) 14:35:20 N.Kasai
    '更新日：2009/12/02 (Wed) 20:19:19 H.Hayashi
    '備　考：
    '　　　：2005/06/02 (Thu) 13:14:44 S.Deguchi    不具合№781の対応で種別をﾘｽﾄへ変更
    '　　　：2005/08/01 (Mon) 13:54:17 N.Kasai      応答ﾒｯｾｰｼﾞにLC_DIRECTION追加(L/R表示)
    '　　　：2007/04/05 (Thu) 15:21:39 N.Kasai      流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ禁止№01831
    '　　　：2007/07/03 (Tue) 08:53:21 N.Kasai      機種複数選択№02006
    '　　　：2007/12/06 (Thu) 12:14:32 N.Kasai      ｻﾝﾌﾟﾘﾝｸﾞ追加
    '　　　：2008/06/11 (Wed) 15:51:42 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 12:10:52 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/12/02 (Wed) 20:19:19 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    Public Function pubblnChgTrvlist_Sel(ByRef ltypChgTrvListRec As ChgTrvListRec, _
                                         ByRef ltypChgTrvListAns As List(Of ChgTrvListAns), _
                                         ByRef llngLotListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信     
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "流動票バージョンアップ対象一覧"
            pubblnChgTrvlist_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            lrAry = New TfMsgAry
            ltMsg2 = New TfMsg
            lrAry2 = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypChgTrvListRec
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@機種ﾘｽﾄ
                For llngCnt = 0 To .lngPdCnt - 1
                    
                    '@機種ID
                    If .typPdList(llngCnt).strPdId <> vbNullString Then
                        Call ltMsg.addString(CPstrPD_ID, .typPdList(llngCnt).strPdId)
                    Else
                        Call ltMsg.addString(CPstrPD_ID, CPstrMsgNull)
                    End If

                    Call lrAry.Add(ltMsg)
                Next
                '@機種ﾘｽﾄ
                Call lrMsg.addMsgAry(CPstrPD_LIST, lrAry)
                
                '@種別ﾘｽﾄ
                For llngCnt = 0 To .lngFlowClassListCnt - 1
                    '@種別
                    If .typFlowClassList(llngCnt).strDivisionID <> vbNullString Then
                        Call ltMsg2.addString(CPstrFLOW_CLASS, .typFlowClassList(llngCnt).strDivisionID)
                    Else
                        Call ltMsg2.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                    End If

                    Call lrAry2.Add(ltMsg2)
                Next
                '@種別ﾘｽﾄ
                Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry2)

                '@ﾛｯﾄ流動ｽﾃｰﾀｽID
                If .strLotFlowStatusID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_FLOW_STATUS_ID, .strLotFlowStatusID)
                Else
                    Call lrMsg.addString(CPstrLOT_FLOW_STATUS_ID, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chgtrvlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：流動票VerUp対象ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認：流動票VerUp対象ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    llngLotListCnt = laAry.Count
                    
                    '@流動票VerUp対象ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngLotListCnt > 0 Then
                    
                        '@配列領域の確保
                        If IsNothing(ltypChgTrvListAns) Then
                            ltypChgTrvListAns = New List(Of ChgTrvListAns)
                        Else
                            ltypChgTrvListAns.Clear()
                        End If

                        Dim ltypChgTrvListAnsTmp As ChgTrvListAns = New ChgTrvListAns
                        
                        '@ｶｳﾝﾀの初期化
                        llngCnt = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry
                            
                            '@受信結果取得
                            With ltypChgTrvListAnsTmp
                                
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                Call ltMsg.getString(CPstrNOW_ST, .strNowST)                                'ﾛｯﾄ状態
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                     'ﾛｯﾄ担当
                                Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                   'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)                   'ﾛｯﾄ停止ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   'ﾛｯﾄ位置(和名)
                                Call ltMsg.getString(CPstrLOT_COMMENTS_FLAG, .strLotCommentsFlg)            'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrCOMMIT_FLAG, .strCommitFlag)                      '号機指定(1：指定　0：指定なし)
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               'LOT最終更新日時
                                Call ltMsg.getString(CPstrPROC_CHANGE_FLAG, .strProcChangeFlag)             '工順変更有無(0：変更なし　1:変更あり)
                                Call ltMsg.getString(CPstrVERSION_CHANGE_FLAG, .strVersionChangeFlag)       '流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ有無(0：変更なし　1:変更あり)
                                Call ltMsg.getString(CPstrENTRY_ID, .strEntryID)                            'ｴﾝﾄﾘID
                                Call ltMsg.getString(CPstrWF_RECIPE_FLAG, .strWfRecipeFlag)                 'WF個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ(0：ﾏｽﾀﾚｼﾋﾟ　1：個別ﾚｼﾋﾟ)
                                Call ltMsg.getString(CPstrLOT_RECIPE_FLAG, .strLotRecipeFlag)               'ﾛｯﾄ個別ﾚｼﾋﾟ設定ﾌﾗｸﾞ(0：ﾏｽﾀﾚｼﾋﾟ　1：個別ﾚｼﾋﾟ)
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種ID
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                    '液晶方向(L/R/Null)
                                Call ltMsg.getString(CPstrMAS_ENTRY_ID, .strMasEntryID)                     'ｴﾝﾄﾘID(ﾏｽﾀの最新ｴﾝﾄﾘID)
                                Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸの有無(0:なし、1:あり)
                                Call ltMsg.getString(CPstrSWAP_FLAG, .strSwapFlag)                          '入替の有無(0:なし、1:あり)
                                Call ltMsg.getString(CPstrALT_FLAG, .strAltFlag)                            '代替の有無(0:なし、1:あり)
                                Call ltMsg.getString(CPstrWF_CARRY_FLAG, .strWfCarryFlag)                   'WF移載の有無(0:なし、1:あり)
                                Call ltMsg.getString(CPstrVERUP_PROHIBITED_FLAG, .strVerUpProhibitedFlag)   'ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ(0:可、1:不可)
                                Call ltMsg.getString(CPstrPROHIBITED_EMP_NAME, .strProhibitedEmpName)       '禁止設定者名
                                Call ltMsg.getString(CPstrPROHIBITED_DEPT_NAME, .strProhibitedDeptName)     '禁止設定者部署名
                                Call ltMsg.getString(CPstrREWORK_COUNT, .strReworkCount)                    'ﾘﾜｰｸｶｳﾝﾄ(ﾘﾜｰｸ実績)
                                Call ltMsg.getString(CPstrSAMPLING_FLAG, .strSamplingFlag)                  'ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ(未来工程のﾏｽﾀ流動票にｻﾝﾌﾟﾘﾝｸﾞ設定がある場合1、それ以外0)
        '@↓2009/02/25 (Wed) 12:11:47 N.Kojima **************************************************
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                         '送品先
        '@↑2009/02/25 (Wed) 12:11:47 N.Kojima **************************************************
        '@↓2009/12/02 (Wed) 20:20:08 H.Hayashi **************************************************
                                Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                              'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
        '@↑2009/12/02 (Wed) 20:20:08 H.Hayashi **************************************************

                                ltypChgTrvListAns.Add(ltypChgTrvListAnsTmp)

                            End With
                            
                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnChgTrvlist_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypChgTrvListRec.strMsgVer)

                    
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
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnLotChgTraveler_Upd
    '機　能：流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ
    '引　数：ltypChgTraveler    ：要求ﾒｯｾｰｼﾞ格納構造体
    '　　　：ltypAnsTraveler    ：応答ﾒｯｾｰｼﾞ格納構造体
    '戻り値：True:成功、False：失敗
    '作成日：2004/11/11 (Thu) 15:29:53 N.Kasai
    '更新日：2008/06/11 (Wed) 17:31:57 N.Kojima
    '備　考：
    '　　　：2007/12/06 (Thu) 12:14:04 N.Kasai      ｻﾝﾌﾟﾘﾝｸﾞ追加
    '　　　：2008/06/11 (Wed) 17:31:57 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnLotChgTraveler_Upd(ByRef ltypChgTraveler As ChgTraveler, _
                                             ByRef ltypAnsTraveler As AnsTraveler) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用

        Try
            
            pstrMessageName = "流動票バージョンアップ"
            pubblnLotChgTraveler_Upd = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypChgTraveler
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@該当ﾛｯﾄ格納
                llngCnt = 0
                Do While .typChgTravelerList.Count - 1 >= llngCnt
                
                    With .typChgTravelerList(llngCnt)
                        
                        '@ﾛｯﾄID
                        If .strLotID <> vbNullString Then
                            Call ltMsg.addString(CPstrLOT_ID, .strLotID)
                        Else
                            Call ltMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                        End If
                        
                        '@ｺﾒﾝﾄ
                        If .strComments <> vbNullString Then
                            Call ltMsg.addString(CPstrCOMMENTS, .strComments)
                        Else
                            Call ltMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                        End If
                        
                        '@最終更新日時
                        If .strLotLastUpdate <> vbNullString Then
                            Call ltMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                        Else
                            Call ltMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                        End If
                        
                        '@ｻﾝﾌﾟﾘﾝｸﾞﾌﾗｸﾞ
                        If .strSamplingFlag <> vbNullString Then
                            Call ltMsg.addString(CPstrSAMPLING_FLAG, .strSamplingFlag)
                        Else
                            Call ltMsg.addString(CPstrSAMPLING_FLAG, CPstrMsgNull)
                        End If
                        
                    End With
                    
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear()
                    llngCnt = llngCnt + 1
                Loop
                Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
                lrAry.Clear
            
            
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_chgTraveler, lrMsg, laMsg)
                
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
            
                '@★ 通信結果(SVからの応答)により処理分岐 ★
                Select Case lstrRET
                
                    '@〓 0：TRUE(成功) 〓
                    Case CPstrTRUE
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｰ格納：ﾛｯﾄﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                        
                        With ltypAnsTraveler
                        
                            '@受信ﾒｯｾｰｼﾞｱﾚｰ数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数を格納する
                            .lngAnsTravelerCnt = laAry.Count
                            
                            '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                            If .lngAnsTravelerCnt <> 0 Then
                            
                                '@配列領域の確保
                                If IsNothing(ltypAnsTraveler.typAnsTravelerList) Then
                                    ltypAnsTraveler.typAnsTravelerList = New List(Of AnsTravelerList)
                                Else
                                    ltypAnsTraveler.typAnsTravelerList.Clear()
                                End If

                                Dim typAnsTravelerListTmp As AnsTravelerList
                                
                                '@ｶｳﾝﾀの初期化
                                llngCnt = 0
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                                For Each ltMsg In laAry

                                    typAnsTravelerListTmp = New AnsTravelerList

                                    Call ltMsg.getString(CPstrLOT_ID, typAnsTravelerListTmp.strLotID)         'ﾛｯﾄID
                                    Call ltMsg.getString(CPstrOP_ID, typAnsTravelerListTmp.strOpID)           '大工程
                                    Call ltMsg.getString(CPstrSTEP_ID, typAnsTravelerListTmp.strStepID)       '小工程

                                    ltypAnsTraveler.typAnsTravelerList.Add(typAnsTravelerListTmp)

                                    '@ｶｳﾝﾀを+1する
                                    llngCnt = llngCnt + 1
                                Next
                            End If
                        End With

                        '@戻り値に"True：成功"をｾｯﾄ
                        pubblnLotChgTraveler_Upd = True

                    
                    '@〓 1：FALSE(失敗) 〓
                    Case CPstrFALSE
                        
                        '@=======================
                        '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                        '@=======================
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                        
                        
                    '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                    Case Else
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

                End Select
            
            End With

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            laAry = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            laAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnLotChgtrvprohibit_Upd
    '機　能：流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ状態変更
    '引　数：ltypLotChgtrvprohibitReq   ：要求ﾃﾞｰﾀ
    '戻り値：True:成功、False：失敗
    '作成日：2007/04/03 (Tue) 16:17:47 N.Kasai
    '更新日：2008/06/11 (Wed) 17:36:49 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 17:36:49 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnLotChgtrvprohibit_Upd(ByRef ltypLotChgtrvprohibitReq As LotChgtrvprohibitReq) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try
            
            pstrMessageName = "流動票バージョンアップ状態変更"
            
            pubblnLotChgtrvprohibit_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotChgtrvprohibitReq
            
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
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
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@状態(0:解除、1:禁止)
                If .strVerUpProhibitedFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrVERUP_PROHIBITED_FLAG, .strVerUpProhibitedFlag)
                Else
                    Call lrMsg.addString(CPstrVERUP_PROHIBITED_FLAG, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_chgtrvprohibit, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            

                '@★ 通信結果(SVからの応答)により処理分岐 ★
                Select Case lstrRET
                
                    '@〓 0：TRUE(成功) 〓
                    Case CPstrTRUE
                        
                        '@戻り値に"True：成功"をｾｯﾄ
                        pubblnLotChgtrvprohibit_Upd = True
                       
         
                    '@〓 1：FALSE(失敗) 〓
                    Case CPstrFALSE
                    
                        '@=======================
                        '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                        '@=======================
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                    
                    
                    '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                    Case Else
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

                End Select

            End With
            
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

    '関数名：prvblnContEtApc_Chk
    '機　能：CONTｴｯﾁｬｰAPC(2M-1P)区間かﾁｪｯｸ
    '引　数：lstrMsgVer：ﾒｯｾｰｼﾞVer
    '　　　：lstrLotID：ﾛｯﾄID
    '　　　：lsrtResult：判定結果（0:VerUp OK、1:VerUp NG、9:処理失敗)
    '戻り値：True：成功、False：失敗
    '作成日：2020/03/27 (Fri) 14:15:01 T.Oide 「.Netへ反映未」
    '更新日：2020/03/27 (Fri) 14:15:01
    '備　考：
    Public Function prvblnContEtApc_Chk(ByVal lstrMsgVer As String, _
                                    ByVal lstrLotID As String, _
                                    ByRef lsrtResult As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "CONTｴｯﾁｬｰAPC(2M-1P)区間チェック"
    
            prvblnContEtApc_Chk = False
    
            lrMsg = New TfMsg
            laMsg = New TfMsg
    
    
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
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@LotId
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
    
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkchkContEtApc, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
    
    
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
    
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
            
                    '@受信結果取得
                    Call laMsg.getString(CPstrRESULT, lsrtResult)
            
                    '@戻り値に"True：成功"をｾｯﾄ
                    prvblnContEtApc_Chk = True
            
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

End Module
