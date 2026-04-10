'ﾌｧｲﾙ名：xxMG0150.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置別ﾛｯﾄ一覧　通信ﾒｯｾｰｼﾞ処理ﾓｼﾞｭｰﾙ
'作成日：2004/09/22 (Wed) 11:55:25 N.Kasai
'更新日：2012/07/04 (Wed) 10:30:57 H.Hayashi
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0150
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public==========================================
    'Public pblnTerminalBCR              As Boolean              'ﾀｰﾐﾅﾙにBCR付属


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：pubblnLotchgctlwp_Upd
    '機　能：処理順号機設定解除
    '引　数：typChgctlwp    ：処理順号機設定解除要求格納構造体
    '　　　：lstrGuidMsg    ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：処理成功、False：処理失敗
    '作成日：2004/09/22 (Wed) 12:16:50 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/09/27 (Mon) 10:26:51 N.Kasai      要求ﾀｸﾞにALT_NUMBERを追加
    '　　　：2004/10/07 (Thu) 12:08:14 N.Kasai      要求ﾀｸﾞにLOT_LAST_UPDATEを追加
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Public Function pubblnLotchgctlwp_Upd(ByRef typChgctlwp As Chgctlwp, _
                                          ByRef lstrGuidMsg As String, _
                                          ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "処理順号機設定/解除"
            pubblnLotchgctlwp_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With typChgctlwp
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@大工程ID
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                
                '@小工程ID
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                
                '@設定/解除ﾌﾗｸﾞ
                If .strKindFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrKIND_FLAG, .strKindFlag)
                Else
                    Call lrMsg.addString(CPstrKIND_FLAG, CPstrMsgNull)
                End If
                
                '@代替番号
                If .strAltNumber <> vbNullString Then
                    Call lrMsg.addString(CPstrALT_NUMBER, .strAltNumber)
                Else
                    Call lrMsg.addString(CPstrALT_NUMBER, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If


                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_chgctlwp, lrMsg, laMsg)
            
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
                        pubblnLotchgctlwp_Upd = True
                        
                    '@〓 1：FALSE(失敗) 〓
                    Case CPstrFALSE
                    
                        '@=======================
                        '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                        '@=======================
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                        
                    '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                    Case Else

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞを表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
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
            
            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnDumyCarOut_Upd
    '機　能：ﾀﾞﾐｰｷｬﾘｱ払出要求
    '引　数：lstrWPID               ：WPID
    '　　　：lstrCarrierID          ：ｷｬﾘｱID
    '　　　：lstrdumy_carout__Ver   ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotLastUpdate      ：最終更新日時
    '戻り値：True：払出成功、False：払出失敗
    '作成日：2005/04/18 (Mon) 20:50:00 N.Kojima
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Public Function pubblnDumyCarOut_Upd(ByVal lstrWpId As String, _
                                         ByVal lstrCarrierID As String, _
                                         ByVal lstrdumy_carout__Ver As String, _
                                         ByVal lstrLotLastUpdate As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "ダミーキャリア払出"
            pubblnDumyCarOut_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrdumy_carout__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrdumy_carout__Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@WPID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@作業者ID
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@最終更新日時
            If lstrLotLastUpdate <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)
            Else
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrdumycarout__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
                
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@戻り値に"True：払出成功"をｾｯﾄ
                    pubblnDumyCarOut_Upd = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                
                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrdumy_carout__Ver)
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞを表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
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
            
            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function
End Module
