'ﾌｧｲﾙ名：xxMG0290.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット情報変更/削除　通信メッセージ用標準モジュール
'作成日：2007/10/09 (Tue) 14:46:58 N.Kasai
'更新日：2016/02/11 (Thu) 22:57:32 H.Hayashi
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0290
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private===========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private===========================================

    '関数名：pubblnLotChgAttribute_Upd
    '機　能：ﾛｯﾄ情報変更
    '引　数：ltypLotchgAttribute：ﾃﾞｰﾀ格納構造体
    '戻り値：True：成功、False：失敗
    '作成日：2007/10/09 (Tue) 16:23:19 N.Kasai
    '更新日：2010/05/07 (Fri) 11:20:36 T.Oide
    '備　考：
    '　　　：2008/06/12 (Thu) 14:41:46 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/09 (Wed) 11:34:39 M.Koni       1stﾌｫﾄ号機設定変更対応 <案件No.02959>
    '　　　：2010/05/06 (Thu) 15:30:14 T.Oide       組立投入予定日追加対応<案件No.04021>
    Public Function pubblnLotChgAttribute_Upd(ByRef ltypLotchgAttribute As LotchgAttribute) As Boolean

        Dim lrMsg              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET            As String           '応答取得
         
        Try
            
            '@各種初期設定
            pstrMessageName = "ロット情報変更"
            pubblnLotChgAttribute_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotchgAttribute
            
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
                
                '@投入予定WF枚数
                If .strPlanThrowinQuantity <> vbNullString Then
                    Call lrMsg.addString(CPstrPLAN_THROWIN_QUANTITY, .strPlanThrowinQuantity)
                Else
                    Call lrMsg.addString(CPstrPLAN_THROWIN_QUANTITY, CPstrMsgNull)
                End If
                
                '@投入予定日
                If .strPlanThrowinDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPLAN_THROWIN_DATE, .strPlanThrowinDate)
                Else
                    Call lrMsg.addString(CPstrPLAN_THROWIN_DATE, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ担当者ID
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrENG_EMP_ID, .strEngEmpId)
                Else
                    Call lrMsg.addString(CPstrENG_EMP_ID, CPstrMsgNull)
                End If
                
                '優先度ID
                If .strLotPriority <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_PRIORITY, .strLotPriority)
                Else
                    Call lrMsg.addString(CPstrLOT_PRIORITY, CPstrMsgNull)
                End If
                
                '@P/RｵｰﾀﾞｰID
                If .strPROrderID <> vbNullString Then
                    Call lrMsg.addString(CPstrPR_ORDER_ID, .strPROrderID)
                Else
                    Call lrMsg.addString(CPstrPR_ORDER_ID, CPstrMsgNull)
                End If
                
                '@送品先ID
                If .strSendSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSEND_SB_ID, .strSendSBID)
                Else
                    Call lrMsg.addString(CPstrSEND_SB_ID, CPstrMsgNull)
                End If
                
                '@送品ﾌﾗｸﾞ
                If .strLotSendFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_SEND_FLAG, .strLotSendFlag)
                Else
                    Call lrMsg.addString(CPstrLOT_SEND_FLAG, CPstrMsgNull)
                End If
                
                '@送品予定日
                If .strPlanShipDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPLAN_SHIP_DATE, .strPlanShipDate)
                Else
                    Call lrMsg.addString(CPstrPLAN_SHIP_DATE, CPstrMsgNull)
                End If
                
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If

                '@1stﾌｫﾄ
                If .strFirstPhotoWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrFIRST_PHOTO_WP_ID, .strFirstPhotoWpID)
                Else
                    Call lrMsg.addString(CPstrFIRST_PHOTO_WP_ID, CPstrMsgNull)
                End If
                
        '@↓2010/05/07 (Fri) 11:21:28 T.Oide **************************************************
                '@組立投入予定日
                If .strPlanAssThrowinDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPLAN_ASS_THROWIN_DATE, .strPlanAssThrowinDate)
                Else
                    Call lrMsg.addString(CPstrPLAN_ASS_THROWIN_DATE, CPstrMsgNull)
                End If
        '@↑2010/05/07 (Fri) 11:21:28 T.Oide **************************************************

                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_chgattribute, lrMsg, laMsg)
                
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
                
                
                '@★ 通信結果(SVからの応答)により処理分岐 ★
                Select Case lstrRET
                
                    '@〓 0：TRUE(成功) 〓
                    Case CPstrTRUE
                    
                        '@戻り値に"True：成功"をｾｯﾄ
                        pubblnLotChgAttribute_Upd = True
                    
                    
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

    '関数名：pubblnLotAttribute_Sel
    '機　能：ﾛｯﾄ情報取得
    '引　数：ltypLotAttribute：ﾃﾞｰﾀ格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2007/10/09 (Tue) 15:37:26 N.Kasai
    '更新日：2016/02/11 (Thu) 22:57:11 H.Hayashi
    '備　考：
    '　　　：2008/06/12 (Thu) 14:45:15 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/04 (Fri) 13:57:46 M.Koni       1stﾌｫﾄ号機設定変更対応 <案件No.02959>
    '　　　：2010/05/06 (Thu) 15:30:14 T.Oide       組立投入予定日追加対応<案件No.04021>
    '　　　：2011/10/05 (Wed) 10:25:36 T.Oide       R8-4区間優先設定対応＜REQ-1109＞
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnLotAttribute_Sel(ByRef ltypLotAttribute As LotAttribute) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            '@各種初期設定
            pstrMessageName = "ロット情報取得"
            pubblnLotAttribute_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotAttribute
                
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
                
                '@ﾛｯﾄID
                If .strReqLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strReqLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱID
                If .strReqCarrierID <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strReqCarrierID)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_attribute, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)


                '@★ 通信結果(SVからの応答)により処理分岐 ★
                Select Case lstrRET
                    
                    '@〓 0：TRUE(成功) 〓
                    Case CPstrTRUE

                        '@受信結果格納
                        Call laMsg.getString(CPstrORDER_NUM, .strOrderNum)                      'ATLASｵｰﾀﾞｰ№
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                            'ﾛｯﾄID
                        Call laMsg.getString(CPstrCARRIER_ID, .strCarrierId)                    'ｷｬﾘｱID
                        Call laMsg.getString(CPstrPD_ID, .strPdId)                              '機種
                        Call laMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                    '流動区分
        '@↓2016/01/25 (Mon) 00:37:55 H.Hayashi **************************************************
                        Call laMsg.getString(CPstrGRB_CLASS, .strGrbClass)                      'GRB区分
        '@↑2016/01/25 (Mon) 00:37:55 H.Hayashi **************************************************
                        Call laMsg.getString(CPstrNOW_ST, .strNowST)                            '現在状態
                        Call laMsg.getString(CPstrSTART_TIME, .strStartTime)                    '処理開始時刻
                        Call laMsg.getString(CPstrDISPATCH_START_TIME, .strDispatchStartTime)   '投入予定時刻
                        Call laMsg.getString(CPstrOP_ID, .strOpID)                              '大工程
                        Call laMsg.getString(CPstrSTEP_ID, .strStepID)                          '小工程
                        Call laMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                    '制限時間
                        Call laMsg.getString(CPstrWARN_TIME, .strWarnTime)                      '警告時間
                        Call laMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)         '時間制限ﾀｲﾌﾟ
                        Call laMsg.getString(CPstrENTRY_ID, .strEntryID)                        'ｴﾝﾄﾘID
                        Call laMsg.getString(CPstrENTRY_NAME, .strEntryName)                    'ｴﾝﾄﾘ名
                        Call laMsg.getString(CPstrS_FLAG, .strSpecialFlag)                      '特殊特性
                        Call laMsg.getString(CPstrWF_NUM, .strWfNum)                            'WF枚数
                        Call laMsg.getString(CPstrMAX_WF_COUNT, .strMaxWFCount)                 '最大WF枚数
                        Call laMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)              'ﾁｯﾌﾟ現在数量
                        Call laMsg.getString(CPstrENG_EMP_ID, .strEngEmpId)                     'ﾛｯﾄ担当者ID
                        Call laMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                 'ﾛｯﾄ担当者名
                        Call laMsg.getString(CPstrPLAN_THROWIN_DATE, .strPlanThrowinDate)       '投入予定日
                        Call laMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                '優先度ID
                        Call laMsg.getString(CPstrLOT_PRIORITY_NAME, .strLotPriorityName)       '優先度名
                        Call laMsg.getString(CPstrPR_ORDER_ID, .strPROrderID)                   'P/RｵｰﾀﾞｰID
                        Call laMsg.getString(CPstrLOT_SEND_FLAG, .strLotSendFlag)               '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
                        Call laMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                     '送品先ID
                        Call laMsg.getString(CPstrSEND_SB_NAME, .strSendSBName)                 '送品先名(和名)
                        Call laMsg.getString(CPstrCF_FLAG, .strCfFlag)                          'CFﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLP_FLAG, .strLpFlag)                          'LPﾌﾗｸﾞ
                        Call laMsg.getString(CPstrDIVIDE_FLAG, .strDivideFlag)                  '分割ﾌﾗｸﾞ(0:親、1:子)
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           'ﾛｯﾄ最終更新日時
                        Call laMsg.getString(CPstrPLAN_SHIP_DATE, .strPlanShipDate)             '送品予定日
                        Call laMsg.getString(CPstrUSE_ID, .strUseId)                            '製品区分
                        Call laMsg.getString(CPstrFIRST_PHOTO_WP_ID, .strFirstPhotoWpID)        '1stﾌｫﾄ号機名
                        Call laMsg.getString(CPstrFIRST_PHOTO_WP_NAME, .strFirstPhotoWpName)    '1stﾌｫﾄ号機和名
                        Call laMsg.getString(CPstrPLAN_ASS_THROWIN_DATE, .strPlanAssThrowinDate) '組立投入予定日
                        Call laMsg.getString(CPstrSECTION_PRIORITY_FLAG, .strSecPriorityFlag)   '区間優先設定フラグ
        '@↓2013/05/16 (Thu) 15:41:37 T.Oide **************************************************
                        Call laMsg.getString(CPstrATLAS_FLOW_NUMBER, .strAtlasFlowNumber)        'ATLASﾌﾛｰﾅﾝﾊﾞｰ
                        Call laMsg.getString(CPstrSCREEN_SIZE_ID, .strScreenSizeID)              'ｽｸﾘｰﾝｻｲｽﾞ
                        Call laMsg.getString(CPstrCF_SCREEN_SIZE_ID, .strCfScreenSizeID)         'CF(貼合せ相手)ｽｸﾘｰﾝｻｲｽﾞ
        '@↑2013/05/16 (Thu) 15:41:37 T.Oide **************************************************

                        '@戻り値に"True：成功"をｾｯﾄ
                        pubblnLotAttribute_Sel = True


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

    '関数名：pubblnLotCancelPlan_Del
    '機　能：投入予定ﾛｯﾄ削除
    '引　数：ltypLotCancelPlan：要求ﾀﾞｰﾀ
    '戻り値：True：正常、False：異常
    '作成日：2007/10/12 (Fri) 12:06:03 N.Kasai
    '更新日：2008/06/12 (Thu) 14:47:44 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 14:47:44 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnLotCancelPlan_Del(ByRef ltypLotCancelPlan As LotCancelPlan) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try
            
            '@各種初期設定
            pstrMessageName = "投入予定ロット削除"
            pubblnLotCancelPlan_Del = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotCancelPlan

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
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
            

                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_cancelplan, lrMsg, laMsg)
                
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
                
                
                '@★ 通信結果(SVからの応答)により処理分岐 ★
                Select Case lstrRET
                
                    '@〓 0：TRUE(成功) 〓
                    Case CPstrTRUE
                        
                        '@戻り値に"True：成功"をｾｯﾄ
                        pubblnLotCancelPlan_Del = True
                    
                    
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
End Module
