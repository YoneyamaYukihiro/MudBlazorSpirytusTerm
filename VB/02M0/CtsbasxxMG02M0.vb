'ﾌｧｲﾙ名：xxMG02M0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：GRB属性設定　GRB属性設定
'作成日：2016/02/11 (Thu) 23:18:36 H.Hayashi
'更新日：
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2016-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02M0
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

    '関数名：pubblnLotChgGrb_Upd
    '機　能：GRB属性設定
    '引　数：lstrlot_chggrbclassVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：lstrEmpID              ：作業者ID
    '　　　：lstrGrbClass           ：GRB区分
    '　　　：lstrLotLastUpdate      ：ﾛｯﾄ最終更新日
    '戻り値：True：成功、False：失敗
    '作成日：2016/02/11 (Thu) 23:15:41 H.Hayashi
    '更新日：
    '備　考：
    Public Function pubblnLotChgGrb_Upd(ByVal lstrlot_chggrbclassVer As String, _
                                         ByVal lstrLotID As String, _
                                         ByVal lstrEmpID As String, _
                                         ByVal lstrGrbClass As String, _
                                         ByRef lstrLotLastUpdate As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
            
        Try

            pstrMessageName = "GRB属性設定"
            pubblnLotChgGrb_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
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

            '@GRB区分
            If lstrGrbClass <> vbNullString Then
                Call lrMsg.addString(CPstrGRB_CLASS, lstrGrbClass)
            Else
                Call lrMsg.addString(CPstrGRB_CLASS, CPstrMsgNull)
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
            If lstrlot_chggrbclassVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_chggrbclassVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chggrbclass, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)   'ﾛｯﾄ最終更新日時
                    '@関数の処理結果(成功)格納
                    pubblnLotChgGrb_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_chggrbclassVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
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
