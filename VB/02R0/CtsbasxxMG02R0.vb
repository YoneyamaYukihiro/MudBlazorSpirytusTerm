'ﾌｧｲﾙ名：xxMG02R0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット投入(ALD)　通信メッセージ用標準モジュール
'作成日：2018/08/02 (Thu) 16:39:08 T.Oide
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2018-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02R0
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

    '関数名：prvblnAldLotThlowin
    '機　能：ﾛｯﾄ投入ALD
    '引　数：ltypAldBatch   ：登録ﾊﾞｯﾁ情報
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/23 (Thu) 15:40:28 T.Oide
    '更新日：2018/08/23 (Thu) 15:40:28
    '備　考：
    Public Function prvblnAldLotThlowin(ByRef ltypLotThrowinAld As LotAsmThrowIn) As Boolean
        
        Dim lrMsg       As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg       As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET     As String           '応答取得

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg


            '@初期設定
            pstrMessageName = "ﾛｯﾄ投入(ALD)"
            prvblnAldLotThlowin = False


            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotThrowinAld

                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ﾊﾞｯﾁID
                If .strBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrBATCH_ID, .strBatchId)
                Else
                    Call lrMsg.addString(CPstrBATCH_ID, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@機種
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
                
                '@優先度
                If .strLotPriority <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_PRIORITY, .strLotPriority)
                Else
                    Call lrMsg.addString(CPstrLOT_PRIORITY, CPstrMsgNull)
                End If
                
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@ﾕｰｻﾞID
                If pstrUserID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@流動区分
                If .strFlowClass <> vbNullString Then
                    Call lrMsg.addString(CPstrFLOW_CLASS, .strFlowClass)
                Else
                    Call lrMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                End If
                
                '@ｴﾝﾄﾘｰﾌﾗｸﾞ
                If .strEntryFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_FLAG, .strEntryFlag)
                Else
                    Call lrMsg.addString(CPstrENTRY_FLAG, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ担当者
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrENG_EMP_ID, .strEngEmpId)
                Else
                    Call lrMsg.addString(CPstrENG_EMP_ID, CPstrMsgNull)
                End If
                
                '@CLASS_DIVISION
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@ｵｰﾀﾞｰ番号
                If .strOrderNum <> vbNullString Then
                    Call lrMsg.addString(CPstrORDER_NUM, .strOrderNum)
                Else
                    Call lrMsg.addString(CPstrORDER_NUM, CPstrMsgNull)
                End If

                '@ｴﾝﾄﾘｰID
                If .strEntryID <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_ID, .strEntryID)
                Else
                    Call lrMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
                End If

                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_throwinald, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@★ 通信結果(SVからの応答)により処理分岐 ★
                Select Case lstrRET
            
                    '@〓 0：TRUE(成功) 〓
                    Case CPstrTRUE
            
                        '@戻り値に"True：成功"をｾｯﾄ
                        prvblnAldLotThlowin = True
            
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
