'ﾌｧｲﾙ名：xxMG0120.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット編成(保留/払出Wafer)用標準ﾓｼﾞｭｰﾙ
'作成日：2004/03/29 (Mon) 15:49:32 N.Kasai
'更新日：2004/06/01 (Tue) 15:17:12 N.Kasai
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0120
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubblnInvThrowin_Sel
    '機　能：ロット編成(保留/払出WF)
    '引　数：lstrlot_send____Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypwfstockinfo：編成内容格納
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/30 (Tue) 09:32:08 N.Kasai
    '更新日：2005/03/31 (Thu) 16:19:46 N.Kojima
    '備　考：旧名称：pubblnWFstckthrowin_Ins
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    'Public Function pubblnInvThrowin_Ins(ByVal lstrlot_send____Ver As String, ByRef ltypwfstckthrowin As WFstockthrowin) As Boolean
    Public Function pubblnInvThrowin_Sel(ByVal lstrlot_send____Ver As String, _
                                         ByRef ltypwfstckthrowin As WFstockthrowin, _
                                         ByRef lstrGuidMsg As String, _
                                         ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ）
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "在庫ロット投入"
            pubblnInvThrowin_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypwfstckthrowin
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@SB_ID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrlot_send____Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_send____Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@優先度
                If .strLotPriority <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_PRIORITY, .strLotPriority)
                Else
                    Call lrMsg.addString(CPstrLOT_PRIORITY, CPstrMsgNull)
                End If

            End With
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_throwin_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
        '@↓2005/03/31 (Thu) 14:07:45 N.Kojima **************************************************
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        '@↑2005/03/31 (Thu) 14:07:45 N.Kojima **************************************************
                
                    '@関数の処理結果(成功)格納
                    pubblnInvThrowin_Sel = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_send____Ver)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
            '@例外処理
        Catch ex As Exception
            
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
              
        End Try
    End Function

End Module
