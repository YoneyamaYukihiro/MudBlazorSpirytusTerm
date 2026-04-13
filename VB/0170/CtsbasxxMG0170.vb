'ﾌｧｲﾙ名：xxMG0170.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット終了用メッセージ用モジュール
'作成日：2004/04/19 (Mon) 11:22:16 M.Matsuura
'更新日：2009/03/25 (Wed) 10:11:18 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0170
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

    '関数名：pubblnLotTerminate_Upd
    '機　能：ﾛｯﾄ終了
    '引　数：lstrlot_terminateVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分(1E)
    '　　　：ltypLotEnd             ：格納ﾃﾞｰﾀ
    '戻り値：True：成功、False：失敗
    '作成日：2004/04/19 (Mon) 11:18:19 M.Matsuura
    '更新日：2009/03/25 (Wed) 12:10:53 N.Kojima
    '備　考：
    '　　　：2005/10/05 (Wed) 16:07:07 S.Deguchi    最終更新日時を追加
    '　　　：2009/03/25 (Wed) 12:10:53 N.Kojima     要求ﾀｸﾞに"CLASS_DIVISION"を追加。(案件№03402)
    Public Function pubblnLotTerminate_Upd(ByVal lstrlot_terminateVer As String, _
                                           ByVal lstrClassDivision As String, _
                                           ByRef ltypLotEnd As LotEnd) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "ロット終了"
            pubblnLotTerminate_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotEnd

                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
        '@↓2009/03/25 (Wed) 12:12:32 N.Kojima **************************************************

                '@処理区分
                If lstrClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

        '@↑2009/03/25 (Wed) 12:12:32 N.Kojima **************************************************
                
                '@終了区分
                If .strClass <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS, .strClass)
                Else
                    Call lrMsg.addString(CPstrCLASS, CPstrMsgNull)
                End If
                
                '@理由ｺｰﾄﾞ
                If .strReasonCode <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_CODE, .strReasonCode)
                Else
                    Call lrMsg.addString(CPstrREASON_CODE, CPstrMsgNull)
                End If
                
                '@作業ﾒﾓ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@責任者ID
                If .strResponsble_Emp_ID <> vbNullString Then
                    Call lrMsg.addString(CPstrRESPONSIBLE_EMP_ID, .strResponsble_Emp_ID)
                Else
                    Call lrMsg.addString(CPstrRESPONSIBLE_EMP_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
            End With
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_terminateVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_terminateVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_terminate, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotTerminate_Upd = True
                    
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_terminateVer)
                
                
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
