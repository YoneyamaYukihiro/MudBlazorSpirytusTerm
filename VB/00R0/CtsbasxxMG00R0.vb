'ﾌｧｲﾙ名：xxMG00R0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ダミー管理用ﾒｯｾｰｼﾞ処理ﾓｼﾞｭｰﾙ
'作成日：2004/08/03 (Tue) 11:15:41 T.Kitagawa
'更新日：2005/04/18 (Mon) 19:27:55 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00R0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public==========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '関数名：pubblnDumyChgState_Upd
    '機　能：ﾀﾞﾐｰｶｾｯﾄﾛｰﾄﾞ/ｱﾝﾛｰﾄﾞ
    '引　数：lstrdumychgcarrierVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSbID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrClassDivision      ：処理区分（01：ｸﾗｲｱﾝﾄ、ZZ：装置）
    '　　　：ltypDumyChgState       ：ﾀﾞﾐｰｶｾｯﾄﾛｰﾄﾞ/ｱﾝﾛｰﾄﾞ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/08/03 (Tue) 13:00:37 T.Kitagawa
    '更新日：2005/04/18 (Mon) 19:29:57 N.Kojima
    '備　考：
    Public Function pubblnDumyChgState_Upd(ByVal lstrdumychgcarrierVer As String, _
                                           ByVal lstrSBID As String, _
                                           ByVal lstrClassDivision As String, _
                                           ByRef ltypDumyChgState As DumyChgState) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "ダミーカセットLoad／Unload／再投入"
            pubblnDumyChgState_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrdumychgcarrierVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrdumychgcarrierVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@SB_ID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            With ltypDumyChgState
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                '@ｷｬﾘｱ状態ﾌﾗｸﾞ
                If .strCarrierStateFlg <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_STATE_FLG, .strCarrierStateFlg)
                Else
                    Call lrMsg.addString(CPstrCARRIER_STATE_FLG, CPstrMsgNull)
                End If
                '@大工程ID
                If .strOpID = vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                End If
                '@小工程ID
                If .strStepID = vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                End If
                '@WPID
                If .strWpID = vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                End If
                '@ﾎﾟｰﾄID
                If .strPortID = vbNullString Then
                    Call lrMsg.addString(CPstrPORT_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrPORT_ID, .strPortID)
                End If
                '@作業者ID
                If .strEmpID = vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                End If
                '@LOT最終更新日時
                If .strLotLastUpdate = vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                End If
                '@作業ﾒﾓ
                If .strComment = vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, .strComment)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrdumychgstate, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnDumyChgState_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrdumychgcarrierVer)
                    
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
