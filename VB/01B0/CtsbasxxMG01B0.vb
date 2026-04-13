'ﾌｧｲﾙ名：xxMG01B0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾛｯﾄ再測定用ﾒｯｾｰｼﾞ処理ﾓｼﾞｭｰﾙ
'作成日：2004/09/07 (Tue) 10:00:39 H.Wajima
'更新日：2005/04/01 (Fri) 10:58:38 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01B0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public==========================================

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：pubblnLotStepRestart_Upd
    '機　能：ﾛｯﾄ再測定
    '引　数：lstrlot_steprestartVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotStepRestart     ：ﾛｯﾄ再測定構造体(送信)
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/09/07 (Tue) 09:39:00 H.Wajima
    '更新日：2005/04/01 (Fri) 10:59:08 N.Kojima
    '備　考：
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    'Public Function pubblnLotStepRestart_Ins(ByVal lstrlot_steprestartVer As String, ByRef ltypLotStepRestart As LotStepRestart) As Boolean
    Public Function pubblnLotStepRestart_Upd(ByVal lstrlot_steprestartVer As String, _
                                             ByRef ltypLotStepRestart As LotStepRestart, _
                                             ByRef lstrGuidMsg As String, _
                                             ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
         
        Try
            
            pstrMessageName = "ロット再測定"
            '@当関数の戻り値にFalseを設定する
            pubblnLotStepRestart_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypLotStepRestart
                '@送信ﾒｯｾｰｼﾞ作成
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                    '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)   'LOT最終更新日時
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
            End With
            
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                      'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrlot_steprestartVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_steprestartVer)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_steprestart, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
        '@↓2005/04/01 (Fri) 09:12:18 N.Kojima **************************************************
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        '@↑2005/04/01 (Fri) 09:12:18 N.Kojima **************************************************
                
                    '@関数の処理結果(成功)格納
                    pubblnLotStepRestart_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_steprestartVer)
                                        
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception
            
            lrMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function


End Module
