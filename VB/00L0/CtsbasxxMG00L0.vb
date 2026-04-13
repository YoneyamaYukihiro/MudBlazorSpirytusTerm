'ﾌｧｲﾙ名：xxMG00L0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：「バッチ処理開始」機能ﾒｯｾｰｼﾞ処理
'作成日：2004/07/20 (Tue) 17:26:07 N.Kasai
'更新日：2009/06/26 (Fri) 15:21:21 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00L0
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

    '関数名：pubblnbatPrcStart_Ins
    '機　能：ﾊﾞｯﾁ処理開始
    '引　数：ltypBatPrcStart    ：ﾊﾞｯﾁ処理開始格納構造体
    '　　　：ltypRestrictInfo   ：制限時間情報格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/07/20 (Tue) 17:24:23 N.Kasai
    '更新日：2009/06/26 (Fri) 12:11:32 N.Kojima
    '備　考：
    '　　　：2006/03/06 (Mon) 15:37:03 N.Kojima     応答に"TO_OP_ID","TO_STEP_ID","LIMIT_TIME","WARN_TIME"追加。(不具合№3444)
    '　　　：2009/06/26 (Fri) 12:11:32 N.Kojima     無機対応。(案件№03560)
    Public Function pubblnbatPrcStart_Ins(ByRef ltypBatPrcStart As BatPrcStartEnd, _
                                          ByRef ltypRestrictInfo As RestrictInfo) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim lrAry1              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt1            As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            lrAry1 = New TfMsgAry

            '@初期設定
            pstrMessageName = "バッチ処理開始"
            pubblnbatPrcStart_Ins = False

            '@***********************
            '@ 送信ﾒｯｾｰｼﾞﾃﾞｰﾀ作成
            '@***********************
            With ltypBatPrcStart
                
                '@ﾊﾞｯﾁID
                If .strBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrBATCH_ID, .strBatchId)
                Else
                    Call lrMsg.addString(CPstrBATCH_ID, CPstrMsgNull)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@ｺﾒﾝﾄ(作業ﾒﾓ)
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If

                '@-----------------------
                '@ ﾛｯﾄﾘｽﾄ
                '@-----------------------
                If .lngBLotListCnt <> 0 Then
                    
                    For llngCnt1 = 0 To .lngBLotListCnt - 1
                        
                        Call ltMsg1.addString(CPstrLOT_ID, .typBLotList(llngCnt1).strLotID)                     'ﾛｯﾄID
                        Call ltMsg1.addString(CPstrLOT_LAST_UPDATE, .typBLotList(llngCnt1).strLotLastUpdate)    '最終更新日時
                        Call lrAry1.Add(ltMsg1)
                    Next llngCnt1
                    
                    Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry1)
                Else
                    Call lrMsg.addString(CPstrLOT_LIST, CPstrMsgNull)
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
                
        '@↓2009/06/26 (Fri) 17:30:20 N.Kojima **************************************************

                '@装置ﾀｲﾌﾟ
                If .strEqType <> vbNullString Then
                    Call lrMsg.addString(CPstrEQ_TYPE, .strEqType)
                Else
                    Call lrMsg.addString(CPstrEQ_TYPE, CPstrMsgNull)
                End If

        '@↑2009/06/26 (Fri) 17:30:20 N.Kojima **************************************************
                
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_prcstart, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果により処理分岐 ★
            Select Case lstrRET
                
                '@〓 True：通信成功 〓
                Case CPstrTRUE
                
                    With ltypRestrictInfo
                        Call laMsg.getString(CPstrTO_OP_ID, .strToOpId)              '制限時間先大工程
                        Call laMsg.getString(CPstrTO_STEP_ID, .strToStepId)          '制限時間先小工程
                        Call laMsg.getString(CPstrLIMIT_TIME, .strLimitTime)         '制限時間
                        Call laMsg.getString(CPstrWARN_TIME, .strWarnTime)           '警告時間
                    End With
                
                    '@戻り値に"True：通信成功"をｾｯﾄ
                    pubblnbatPrcStart_Ins = True


                '@〓 False：通信失敗 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypBatPrcStart.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            lrAry1 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            lrAry1 = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換処理
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function
End Module
