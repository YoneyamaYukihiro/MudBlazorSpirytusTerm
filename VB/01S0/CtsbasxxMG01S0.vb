'ﾌｧｲﾙ名：xxMG01S0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：P/Rオーダー管理　機能メッセージ処理
'作成日：2005/12/19 (Mon) 12:57:09 T.Kitagawa
'更新日：2005/12/19 (Mon) 12:57:09
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01S0
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

    '関数名：pubblnPrChgOrder_Upd
    '機　能：P/Rｵｰﾀﾞｰ登録・更新・削除
    '引　数：ltypPrChgOrderReq：P/Rｵｰﾀﾞｰ登録構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/12/19 (Mon) 18:12:12 T.Kitagawa
    '更新日：2005/12/19 (Mon) 18:12:12
    '備　考：
    Public Function pubblnPrChgOrder_Upd(ByRef ltypPrChgOrderReq As PrChgOrderReq) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp）-送信
        Dim lstrRET            As String            '応答取得

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg

            '@初期設定
            pstrMessageName = "Ｐ／Ｒオーダー登録・更新・削除"
            pubblnPrChgOrder_Upd = False
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypPrChgOrderReq
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
                
                '@P/RｵｰﾀﾞｰID
                If .strPROrderID <> vbNullString Then
                    Call lrMsg.addString(CPstrPR_ORDER_ID, .strPROrderID)
                Else
                    Call lrMsg.addString(CPstrPR_ORDER_ID, CPstrMsgNull)
                End If
                
                '@ｵｰﾀﾞｰｺﾒﾝﾄ
                If .strOrderComments <> vbNullString Then
                    Call lrMsg.addString(CPstrORDER_COMMENTS, .strOrderComments)
                Else
                    Call lrMsg.addString(CPstrORDER_COMMENTS, CPstrMsgNull)
                End If
                
                '@部門
                If .strGlobalDept <> vbNullString Then
                    Call lrMsg.addString(CPstrGLOBAL_DEPT, .strGlobalDept)
                Else
                    Call lrMsg.addString(CPstrGLOBAL_DEPT, CPstrMsgNull)
                End If
                
                '@原価ｺｰﾄﾞ
                If .strCostCode <> vbNullString Then
                    Call lrMsg.addString(CPstrCOST_CODE, .strCostCode)
                Else
                    Call lrMsg.addString(CPstrCOST_CODE, CPstrMsgNull)
                End If
                
                '@原価ｺｰﾄﾞ
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrpr__chgorder_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnPrChgOrder_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypPrChgOrderReq.strMsgVer)
                    
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
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

        End Try
    End Function
End Module
