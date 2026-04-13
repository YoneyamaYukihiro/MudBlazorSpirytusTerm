'ﾌｧｲﾙ名：xxMG01M0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾚﾁｸﾙﾏﾆｭｱﾙ搬送 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2005/02/18 (Fri) 11:21:11 N.Kasai
'更新日：2005/02/18 (Fri) 11:21:11
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01M0
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnrtclwpout____Upd
    '機　能：ﾚﾁｸﾙ払出指示
    '引　数：ltypRtclWpout：ﾚﾁｸﾙ払出し応答構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/02/23 (Wed) 16:20:43 N.Kasai
    '更新日：2005/02/23 (Wed) 16:20:43
    '備　考：
    Public Function pubblnrtclwpout____Upd(ByRef ltypRtclWpout As RtclWpout) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "レチクル払出指示"
            
            pubblnrtclwpout____Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            With ltypRtclWpout

                '@送信ﾒｯｾｰｼﾞ作成
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                      'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                  'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)    '処理区分
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)                      'WPID
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                If .strReticleID <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_ID, .strReticleID)            'ﾚﾁｸﾙID
                Else
                    Call lrMsg.addString(CPstrRETICLE_ID, CPstrMsgNull)
                End If
            
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                   '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrrtclwpout___, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
            
                        '@関数の処理結果(成功)格納
                        pubblnrtclwpout____Upd = True
            
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
            
                        '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
            End With
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblncarrtransfer_Upd
    '機　能：ｽﾄｯｶｰ/装置搬送指示
    '引　数：ltypCarrTransfer：ｽﾄｯｶｰ/装置搬送指示応答格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/02/23 (Wed) 09:34:37 N.Kasai
    '更新日：2005/02/23 (Wed) 09:34:37
    '備　考：
    Public Function pubblncarrtransfer_Upd(ByRef ltypCarrTransfer As CarrTransfer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "ストッカー/装置搬送指示"
            
            pubblncarrtransfer_Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            With ltypCarrTransfer

                '@送信ﾒｯｾｰｼﾞ作成
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                              'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)                '処理区分
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)                        'SMIF
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                If .strCurrentPositionID <> vbNullString Then
                    Call lrMsg.addString(CPstrCURRENT_POSITION_ID, .strCurrentPositionID)       '搬送元ID（ｽﾄｯｶｰ搬送時：装置ID、装置搬送時：ｽﾄｯｶｰID)
                Else
                    Call lrMsg.addString(CPstrCURRENT_POSITION_ID, CPstrMsgNull)
                End If
                If .strDestPositionID <> vbNullString Then
                    Call lrMsg.addString(CPstrDEST_POSITION_ID, .strDestPositionID)             '搬送先ID（ｽﾄｯｶｰ搬送時：ｽﾄｯｶｰID、装置搬送時：装置ID)
                Else
                    Call lrMsg.addString(CPstrDEST_POSITION_ID, CPstrMsgNull)
                End If
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                                '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrrcarrtransfer, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
            
                        '@関数の処理結果(成功)格納
                        pubblncarrtransfer_Upd = True
            
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
            
                        '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
            End With
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

End Module
