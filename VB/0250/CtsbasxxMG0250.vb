'ﾌｧｲﾙ名：xxMG0250.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程ｽｷｯﾌﾟﾒｯｾｰｼﾞ関数
'作成日：2004/05/11 (Tue) 11:17:55 H.Wajima
'更新日：2005/03/31 (Thu) 17:17:27 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0250
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
    '　　　　　　　　　　　　　　　* プロパティの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Friend =====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Public =====================================

    '関数名：pubblnLotSkipStep_Upd
    '機　能：ﾛｯﾄ工程ｽｷｯﾌﾟﾒｯｾｰｼﾞを送信する
    '引　数：lstrlot_skipstepVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID：ﾛｯﾄID
    '　　　：lstrOpID：大工程ID
    '　　　：lstrStepID：小工程ID
    '　　　：lstrLastUpDate：最終更新日時
    '　　　：lstrEmpID：作業者ID
    '　　　：lstrActionFlag：ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ
    '　　　：lstrSendResult：送信結果(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/05/14 (Fri) 10:00:07 H.Wajima
    '更新日：2005/01/07 (Fri) 11:44:16 N.Kasai
    '備　考：2004/09/28 (Tue) 09:07:29 M.Miura　引数と受信ﾒｯｾｰｼﾞにｱｸｼｮﾝ予約実行ﾌﾗｸﾞを追加
    '　　　：2005/01/07 (Fri) 11:44:16 N.Kasai  引数と応答ﾒｯｾｰｼﾞに送信結果を追加
    Public Function pubblnLotSkipStep_Upd(ByVal lstrlot_skipstepVer As String, _
                                      ByVal lstrLotID As String, _
                                      ByVal lstrOpID As String, _
                                      ByVal lstrStepID As String, _
                                      ByVal lstrLastUpDate As String, _
                                      ByVal lstrEmpID As String, _
                                      ByRef lstrActionFlag As String, _
                                      ByRef lstrSendResult As String, _
                                      ByRef lstrGuidMsg As String, _
                                      ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ロット工程スキップ"
            pubblnLotSkipStep_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            '@大工程ID
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            '@小工程ID
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            '@最終更新日時
            If lstrLastUpDate <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, lstrLastUpDate)
            Else
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
            End If
            '@作業者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_skipstepVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_skipstepVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_skipstep, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@判定結果を取得
                    Call laMsg.getString(CPstrACTION_FLAG, lstrActionFlag)  'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ
                    Call laMsg.getString(CPstrSEND_RESULT, lstrSendResult)  '送信結果
        '@↓2005/03/31 (Thu) 14:07:45 N.Kojima **************************************************
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        '@↑2005/03/31 (Thu) 14:07:45 N.Kojima **************************************************
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotSkipStep_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_skipstepVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
                
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnNextStepChk_Chk
    '機　能：次工程ｽｷｯﾌﾟﾌﾗｸﾞﾁｪｯｸ
    '引　数：lstrlot_stepskipchkVer：Msgﾊﾞｰｼﾞｮﾝ
    '  　  ：strCarrierID：ｷｬﾘｱID
    '戻り値：True:正常終了、False:異常終了
    '作成日：2004/05/19 (Wed) 15:29:50 H.Wajima
    '更新日：2005/03/23 (Wed) 10:14:25 N.Kasai
    '備　考：
    '　　　：2005/03/23 (Wed) 10:14:25 N.Kasai      要求MSGをﾛｯﾄIDからｷｬﾘｱIDへ変更
    '　　　：2005/05/18 (Wed) 17:02:34 S.Deguchi    応答にOP_ID/STEP_IDを追加
    Public Function pubblnNextStepChk_Chk(ByVal lstrlot_stepskipchkVer As String, _
                                          ByVal lstrCarrierID As String, _
                                          ByRef lstrResult As String, _
                                          ByRef lstrOpID As String, _
                                          ByRef lstrStepID As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "工程スキップ可否確認"
            
            '@当関数の戻り値にFalseを設定
            pubblnNextStepChk_Chk = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_stepskipchkVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_stepskipchkVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkskipstep, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@判定結果を取得
                    Call laMsg.getString(CPstrRESULT, lstrResult)
                    
        '@↓2005/05/18 (Wed) 17:02:59 S.Deguchi **************************************************追加
                    '@返却情報をｾｯﾄ
                    Call laMsg.getString(CPstrOP_ID, lstrOpID)
                    Call laMsg.getString(CPstrSTEP_ID, lstrStepID)
        '@↑2005/05/18 (Wed) 17:02:59 S.Deguchi **************************************************追加
                    
                    '@当関数の戻り値にTrue（成功）を設定
                    pubblnNextStepChk_Chk = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_stepskipchkVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function



End Module
