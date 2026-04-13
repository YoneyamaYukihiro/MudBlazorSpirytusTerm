'ﾌｧｲﾙ名：xxMG0080.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：「処理終了」機能ﾒｯｾｰｼﾞ処理
'作成日：2004/03/16 (Tue) 09:34:56 K.Takano
'更新日：2012/02/29 (Wed) 15:40:50 Y.Yoneyama
'備　考：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports TFLib
Public Module basxxMG0080
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnLotProcend_Upd
    '機　能：ﾛｯﾄ処理終了
    '引　数：lstrlot_procend_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID          ：ﾛｯﾄID（送信）
    '　　　：lstrEmpID          ：作業者ID（送信）
    '　　　：lstrComments       ：ﾛｯﾄｺﾒﾝﾄ（送信）
    '　　　：lstrLotLastUpdate  ：ﾛｯﾄ最終更新日時（送信）
    '　　　：lstrFTPResult      ：FTPﾃﾞｰﾀ登録結果（受信）
    '　　　：lstrGuidMsg        ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode    ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '　　　：lstrPlcResult          ：PLCﾚｼﾋﾟ照合結果
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/16 (Tue) 11:25:28 K.Takano
    '更新日：2012/02/29 (Wed) 15:44:56 Y.Yoneyama
    '備　考：
    '　　　：2005/03/25 (Fri) 13:43:13 N.Kojima     応答に「FTP_TRIGGER_RESULT」追加(改善№625)
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2007/06/19 (Tue) 13:38:30 N.Kasai      応答FTP_RESULT削除（№01975）
    '      ：2012/02/29 (Wed) 15:45:19 Y.Yoneyama   PLCﾚｼﾋﾟ照合機能対応
    Public Function pubblnLotProcend_Upd(ByVal lstrlot_procend_Ver As String, _
                                         ByVal lstrClassDivision As String, _
                                         ByVal lstrLotID As String, _
                                         ByVal lstrEmpID As String, _
                                         ByVal lstrComments As String, _
                                         ByVal lstrLotLastUpdate As String, _
                                         ByRef lstrGuidMsg As String, _
                                         ByRef lstrGuidMsgCode As String, _
                                         ByRef lstrPlcResult As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
         
        Try

            pstrMessageName = "ロット処理終了"
            pubblnLotProcend_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            '@作業者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            '@ﾛｯﾄｺﾒﾝﾄ
            If lstrComments <> vbNullString Then
                Call lrMsg.addString(CPstrCOMMENTS, lstrComments)
            Else
                Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
            End If
            '@ﾛｯﾄ最終更新日時
            If lstrLotLastUpdate <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)
            Else
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
            End If
            '@SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_procend_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_procend_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_procend_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        '@↓2012/02/28 (Tue) 17:15:47 Y.Yoneyama **************************************************
                    Call laMsg.getString(CPstrPLC_RECIPE_COMPARE_RESULT, lstrPlcResult)     'PLCﾚｼﾋﾟ照合結果
        '@↑2012/02/28 (Tue) 17:15:47 Y.Yoneyama **************************************************

                    '@関数の処理結果(成功)格納
                    pubblnLotProcend_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_procend_Ver)
                    
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
