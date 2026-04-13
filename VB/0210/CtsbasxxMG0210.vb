'ﾌｧｲﾙ名：xxMG0210.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：部材受入 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/04/27 (Tue) 09:44:13 S.Deguchi
'更新日：2004/06/01 (Tue) 15:46:51 N.Kasai
'備　考：2004/09/14 (Tue) 10:33:57 S.Deguchi ｺﾒﾝﾄｱｳﾄ行を削除
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0210
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

    '関数名：pubblnInvPartaccept_Ins
    '機　能：部材受入要求
    '引　数：lstrinv_accept__Ver：Msgﾊﾞｰｼﾞｮﾝ
    '  　  ：ltypartaccept：格納ﾃﾞｰﾀ
    '戻り値：True：正常、False：異常
    '作成日：2004/04/28 (Wed) 09:49:00 S.Deguchi
    '更新日：2004/09/14 (Tue) 11:04:28 N.Kasai
    '備　考：2004/09/14 (Tue) 11:04:28 N.Kasai CPstrinv_accept__定数を修正（統一）
    Public Function pubblnInvPartaccept_Ins(ByVal lstrinv_accept__Ver As String, ByRef ltypartaccept As PartAcceptList) As Boolean

        Dim lrMsg              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET            As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "部材受入要求"
            pubblnInvPartaccept_Ins = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypartaccept
                '@部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
                If .strPartCode <> vbNullString Then
                    Call lrMsg.addString(CPstrPART_CODE, .strPartCode)
                Else
                    Call lrMsg.addString(CPstrPART_CODE, CPstrMsgNull)
                End If
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@製造ﾛｯﾄID
                If .strProductionLotId <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCTION_LOT_ID, .strProductionLotId)
                Else
                    Call lrMsg.addString(CPstrPRODUCTION_LOT_ID, CPstrMsgNull)
                End If
                '@ｹｰｽ数
                If .strCaseNum <> vbNullString Then
                    Call lrMsg.addString(CPstrCASE_NUM, .strCaseNum)
                Else
                    Call lrMsg.addString(CPstrCASE_NUM, CPstrMsgNull)
                End If
                '@受入数
                If .strNum <> vbNullString Then
                    Call lrMsg.addString(CPstrNUM, .strNum)
                Else
                    Call lrMsg.addString(CPstrNUM, CPstrMsgNull)
                End If
                '@受入日時
                If .strDate <> vbNullString Then
                    Call lrMsg.addString(CPstrDATE, .strDate)
                Else
                    Call lrMsg.addString(CPstrDATE, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@出荷ﾛｯﾄID判別
                If .strShippingLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrSHIPPING_LOT_ID, .strShippingLotID)
                Else
                    Call lrMsg.addString(CPstrSHIPPING_LOT_ID, CPstrMsgNull)
                End If
                '@CF板厚判別
                If .strBoardThickness <> vbNullString Then
                    Call lrMsg.addString(CPstrTHICKNESS_CODE, .strBoardThickness)
                Else
                    Call lrMsg.addString(CPstrTHICKNESS_CODE, CPstrMsgNull)
                End If
                '@ﾘﾜｰｸ回数判別
                If .strReworkCount <> vbNullString Then
                    Call lrMsg.addString(CPstrREWORK_COUNT, .strReworkCount)
                Else
                    Call lrMsg.addString(CPstrREWORK_COUNT, CPstrMsgNull)
                End If
                '@部品ID
                If .strClassCode <> vbNullString Then
                    Call lrMsg.addString(CPstrVENDER_CLASS_ID, .strClassCode)
                Else
                    Call lrMsg.addString(CPstrVENDER_CLASS_ID, CPstrMsgNull)
                End If
            End With
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_accept__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_accept__Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_accept__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    '@受信ﾒｯｾｰｼﾞﾃﾞｰﾀ無し
                    
                    '@関数の処理結果(成功)格納
                    pubblnInvPartaccept_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrinv_accept__Ver)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function
End Module
