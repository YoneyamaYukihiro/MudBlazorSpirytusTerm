'ﾌｧｲﾙ名：xxMG00G0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ｷｬﾘｱ管理 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2006/02/21 (Tue) 13:21:21 N.Kojima
'更新日：
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00G0
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

    '関数名：pubblnCarrUpdate_Upd
    '機　能：ｷｬﾘｱ情報更新要求
    '引　数：lstrcarrupdate__Ver    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：llngCarrierCnt         ：更新ｷｬﾘｱ数
    '　　　：ltypCarrierUpdate      ：ｷｬﾘｱ情報更新内容格納構造体
    '　　　：lstrEditTime           ：最終更新日時
    '戻り値：Ture:正常、False:異常
    '作成日：2006/02/21 (Tue) 13:21:50 N.Kojima
    '更新日：
    '備　考：
    Public Function pubblnCarrUpdate_Upd(ByVal lstrcarrupdate__Ver As String, _
                                         ByVal lstrSBID As String, _
                                         ByVal llngCarrierCnt As Integer, _
                                         ByRef ltypCarrierUpdate As CarrierUpdateList, _
                                         ByRef lstrEditTime As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        
        Try
            
            '@初期化
            pubblnCarrUpdate_Upd = False
            '@ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ設定
            pstrMessageName = "キャリア情報更新"
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrcarrupdate__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrcarrupdate__Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@SBID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@作業者ID
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If

            '@ｷｬﾘｱ情報
            For llngCnt = 0 To llngCarrierCnt - 1
                
                With ltypCarrierUpdate.typCarrierUpdateInfo(llngCnt)
                    '@ｷｬﾘｱID
                    If .strCarrierId <> vbNullString Then
                        Call ltMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                    Else
                        Call ltMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                    End If
                    
                    '@ｶﾃｺﾞﾘID
                    If .strCategoryID <> vbNullString Then
                        Call ltMsg.addString(CPstrCATEGORY_ID, .strCategoryID)
                    Else
                        Call ltMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
                    End If
                    
                    '@ｺﾒﾝﾄ
                    If .strComments <> vbNullString Then
                        Call ltMsg.addString(CPstrCOMMENTS, .strComments)
                    Else
                        Call ltMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                
                End With
                
            Next llngCnt
                
            Call lrMsg.addMsgAry(CPstrCARRIER_LIST, lrAry)
            lrAry.Clear
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrupdate__, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    Call laMsg.getString(CPstrEDIT_TIME, lstrEditTime)        'ﾛｯﾄ最終更新日時
                
                    '@関数の処理結果(成功)格納
                    pubblnCarrUpdate_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrcarrupdate__Ver)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
                
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

        End Try
    End Function

End Module
