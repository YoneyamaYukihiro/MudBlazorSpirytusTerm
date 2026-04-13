'ﾌｧｲﾙ名：xxMG00X0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：投入予定工順登録(組立)用　通信メッセージ用標準モジュール
'作成日：2004/08/18 (Wed) 20:30:41 N.Kasai
'更新日：2008/06/11 (Wed) 14:05:18 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00X0
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnLotAssythrowrsv_Ins
    '機　能：投入予定工順組立登録
    '引　数：mtypLotReserveIns：投入予定工順組立登録構造体
    '戻り値：True：正常、False：異常
    '作成日：2004/08/18 (Wed) 20:35:44 N.Kasai
    '更新日：2008/06/11 (Wed) 14:06:13 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 14:06:13 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Public Function pubblnLotAssythrowrsv_Ins(ByRef mtypAssythrowrsv As Assythrowrsv) As Boolean

        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET         As String           '応答取得

        Try

            pstrMessageName = "投入予定工順組立登録"
            pubblnLotAssythrowrsv_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With mtypAssythrowrsv
                
                '@SBID
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
                
                '@新規作成ｴﾝﾄﾘID
                If .strEntryID <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_ID, .strEntryID)
                Else
                    Call lrMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
                End If
                
                '@新規作成ｴﾝﾄﾘ名
                If .strEntryName <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_NAME, .strEntryName)
                Else
                    Call lrMsg.addString(CPstrENTRY_NAME, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ担当
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrENG_EMP_ID, .strEngEmpId)
                Else
                    Call lrMsg.addString(CPstrENG_EMP_ID, CPstrMsgNull)
                End If
                
                '@ｺﾋﾟｰ元ﾛｯﾄID
                If .strCopySeqLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrCOPY_SEQ_LOT_ID, .strCopySeqLotID)
                Else
                    Call lrMsg.addString(CPstrCOPY_SEQ_LOT_ID, CPstrMsgNull)
                End If
                
                '@ｺﾋﾟｰ元ｴﾝﾄﾘID
                If .strCopySeqEntryID <> vbNullString Then
                    Call lrMsg.addString(CPstrCOPY_SEQ_ENTRY_ID, .strCopySeqEntryID)
                Else
                    Call lrMsg.addString(CPstrCOPY_SEQ_ENTRY_ID, CPstrMsgNull)
                End If
                
                '@ｺﾒﾝﾄ
                If .strComment <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComment)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If


                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_assythrowrsv, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)


                '@★ 通信結果(SVからの応答)により処理分岐 ★
                Select Case lstrRET
                
                    '@〓 0：TRUE(成功) 〓
                    Case CPstrTRUE
                    
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)   '生成ﾛｯﾄID(ENTRY_ID)
                        
                        '@戻り値に"True：成功"をｾｯﾄ
                        pubblnLotAssythrowrsv_Ins = True
                        
                        
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
