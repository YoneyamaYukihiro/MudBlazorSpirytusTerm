'ﾌｧｲﾙ名：xxMG0130.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：処理開始取消用ﾒｯｾｰｼﾞ処理ﾓｼﾞｭｰﾙ
'作成日：2004/04/12 (Mon) 14:34:43 T.Kitagawa
'更新日：2004/06/01 (Tue) 15:35:51 N.Kasai
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0130
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public==========================================
    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：pubblnCancelStart_Upd
    '機　能：ﾛｯﾄ作業開始取消
    '引　数：lstrlot_cnclwrkstartVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotCnclWrkStart：ﾛｯﾄ作業開始取消構造体(送信)
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/04/05 (Mon) 18:00:11 T.Kitagawa
    '更新日：2005/04/01 (Fri) 10:10:27 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 11:33:43 N.Kasai      処理中取消対応（№468）　応答MSGにCENCEL_MODEを追加
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    'Public Function pubblnCancelStart_Ins(ByVal lstrlot_cnclwrkstartVer As String, ByRef ltypLotCnclWrkStart As LotCnclWrkStart) As Boolean
    Public Function pubblnCancelStart_Upd(ByVal lstrlot_cnclwrkstartVer As String, _
                                          ByRef ltypLotCnclWrkStart As LotCnclWrkStart, _
                                          ByRef lstrGuidMsg As String, _
                                          ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '@送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '@受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '@応答取得
         
        Try
            
            pstrMessageName = "ロット作業開始取消"
            pubblnCancelStart_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypLotCnclWrkStart
                '@送信ﾒｯｾｰｼﾞ作成
                
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEngEmpId)                 '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
        '@↓：2005/02/02 (Wed) 11:33:43 N.Kasai  処理中取消対応（№468）　応答MSGにCENCEL_MODEを追加

                If .strCancelMode <> vbNullString Then
                    Call lrMsg.addString(CPstrCANCEL_MODE, .strCancelMode)          'ｷｬﾝｾﾙﾓｰﾄﾞ
                Else
                    Call lrMsg.addString(CPstrCANCEL_MODE, CPstrMsgNull)
                End If
                
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)               '作業ﾒﾓ
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
        '@↑：2005/02/02 (Wed) 11:33:43 N.Kasai  処理中取消対応（№468）　応答MSGにCENCEL_MODEを追加
                
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)   'LOT最終更新日時
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
            End With
            
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                      'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrlot_cnclwrkstartVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_cnclwrkstartVer)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cnclwrkstart, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
        '@↓2005/04/01 (Fri) 09:12:18 N.Kojima **************************************************
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        '@↑2005/04/01 (Fri) 09:12:18 N.Kojima **************************************************
                
                    '@関数の処理結果(成功)格納
                    pubblnCancelStart_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_cnclwrkstartVer)
                                        
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
