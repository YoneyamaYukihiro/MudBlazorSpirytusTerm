'ﾌｧｲﾙ名：xxMG01N0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CMPﾒﾝﾃﾅﾝｽ 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2005/03/16 (Wed) 11:11:31 N.Kasai
'更新日：2005/05/07 (Sat) 16:52:39 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01N0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubblnEqChgCmpRate_Upd
    '機　能：研磨ﾚｰﾄ変更
    '引　数：typEqchgcmprate：研磨ﾚｰﾄ変更要求構造体
    '戻り値：Ture:正常、False:異常
    '作成日：2005/03/14 (Mon) 17:01:20 N.Kasai
    '更新日：2005/03/14 (Mon) 17:01:20
    '備　考：
    Public Function pubblnEqChgCmpRate_Upd(ByRef typEqchgcmprate As Eqchgcmprate) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "研磨レート変更"
            
            pubblnEqChgCmpRate_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With typEqchgcmprate
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@ﾍｯﾄﾞ
                If .strHead <> vbNullString Then
                    Call lrMsg.addString(CPstrHEAD, .strHead)
                Else
                    Call lrMsg.addString(CPstrHEAD, CPstrMsgNull)
                End If
                '@ﾌﾟﾗﾃﾝ
                If .strPlaten <> vbNullString Then
                    Call lrMsg.addString(CPstrPLATEN, .strPlaten)
                Else
                    Call lrMsg.addString(CPstrPLATEN, CPstrMsgNull)
                End If
                '@変更後研磨ﾚｰﾄ
                If .strPolRate <> vbNullString Then
                    Call lrMsg.addString(CPstrPOL_RATE, .strPolRate)
                Else
                    Call lrMsg.addString(CPstrPOL_RATE, CPstrMsgNull)
                End If
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@応答ﾒｯｾｰｼﾞ生成日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__chgcmprate, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信ﾒｯｾｰｼﾞﾃﾞｰﾀ無し
                        '@関数の処理結果(成功)格納
                        pubblnEqChgCmpRate_Upd = True
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

    '関数名：pubblnEqChgCmpStat_Upd
    '機　能：CMP状態変更
    '引　数：typEqchgcmpstat：CMP状態変更要求構造体
    '戻り値：Ture:正常、False:異常
    '作成日：2005/03/14 (Mon) 17:01:20 N.Kasai
    '更新日：2005/03/14 (Mon) 17:01:20
    '備　考：
    Public Function pubblnEqChgCmpStat_Upd(ByRef typEqchgcmpstat As Eqchgcmpstat) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "ＣＭＰ状態変更"
            
            pubblnEqChgCmpStat_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With typEqchgcmpstat
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@ﾍｯﾄﾞ
                If .strHead <> vbNullString Then
                    Call lrMsg.addString(CPstrHEAD, .strHead)
                Else
                    Call lrMsg.addString(CPstrHEAD, CPstrMsgNull)
                End If
                '@ﾌﾟﾗﾃﾝ
                If .strPlaten <> vbNullString Then
                    Call lrMsg.addString(CPstrPLATEN, .strPlaten)
                Else
                    Call lrMsg.addString(CPstrPLATEN, CPstrMsgNull)
                End If
                '@研磨ﾚｰﾄ使用可否(0：使用不可　1:使用可）
                If .strAvailFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrAVAIL_FLAG, .strAvailFlag)
                Else
                    Call lrMsg.addString(CPstrAVAIL_FLAG, CPstrMsgNull)
                End If
                '@ﾒﾝﾃﾅﾝｽｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@応答ﾒｯｾｰｼﾞ生成日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__chgcmpstat, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信ﾒｯｾｰｼﾞﾃﾞｰﾀ無し
                        '@関数の処理結果(成功)格納
                        pubblnEqChgCmpStat_Upd = True
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

    '関数名：pubblnEqCmpEventList_Sel
    '機　能：CMPﾒﾝﾃﾅﾝｽｲﾍﾞﾝﾄ履歴取得
    '引　数：ltypEqCmpEventListRec：CMPﾒﾝﾃﾅﾝｽｲﾍﾞﾝﾄ履歴要求構造体
    '　　　：ltypEqCmpEventListAns：CMPﾒﾝﾃﾅﾝｽｲﾍﾞﾝﾄ履歴応答構造体
    '戻り値：Ture:正常、False:異常
    '作成日：2005/03/15 (Tue) 09:16:20 N.Kasai
    '更新日：2005/03/15 (Tue) 09:16:20
    '備　考：
    Public Function pubblnEqCmpEventList_Sel(ByRef ltypEqCmpEventListRec As EqcmpeventlistRec, _
                    ByRef ltypEqCmpEventListAns As EqcmpeventlistAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ＣＭＰメンテナンス履歴取得"
            pubblnEqCmpEventList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypEqCmpEventListRec
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@ﾍｯﾄﾞ
                If .strHead <> vbNullString Then
                    Call lrMsg.addString(CPstrHEAD, .strHead)
                Else
                    Call lrMsg.addString(CPstrHEAD, CPstrMsgNull)
                End If
                '@ﾌﾟﾗﾃﾝ
                If .strPlaten <> vbNullString Then
                    Call lrMsg.addString(CPstrPLATEN, .strPlaten)
                Else
                    Call lrMsg.addString(CPstrPLATEN, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__cmpeventlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypEqCmpEventListAns
                        '@受信結果取得
                        Call laMsg.getMsgAry(CPstrEVENT_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngEqcmpeventlistCnt = laAry.Count
                        If .lngEqcmpeventlistCnt > 0 Then

                            If .typEqcmpeventlist Is Nothing Then 
                                .typEqcmpeventlist = New List(Of Eqcmpeventlist) 
                            Else 
                                .typEqcmpeventlist.Clear 
                            End If

                            Dim EqcmpeventlistRec As Eqcmpeventlist 
                            EqcmpeventlistRec = New Eqcmpeventlist 
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With EqcmpeventlistRec
                                    Call ltMsg.getString(CPstrEVENT_NAME, .strEventName)        'ｲﾍﾞﾝﾄ名
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)            '作業者
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)        'ｲﾍﾞﾝﾄ日時
                                    Call ltMsg.getString(CPstrOLD_POL_RATE, .strOldPolRate)     '変更前研磨ﾚｰﾄ
                                    Call ltMsg.getString(CPstrNEW_POL_RATE, .strNewPolRate)     '変更後研磨ﾚｰﾄ
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)           'ｺﾒﾝﾄ
                                End With
                                .typEqcmpeventlist.Add(EqcmpeventlistRec)
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnEqCmpEventList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypEqCmpEventListRec.strMsgVer)
                    
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
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnEqCmpList_Sel
    '機　能：CMP情報一覧取得
    '引　数：ltypEqcmplistRec：CMPﾘｽﾄ要求構造体
    '　　　：ltypEqcmplistAns：CMPﾘｽﾄ応答構造体
    '戻り値：Ture:正常、False:異常
    '作成日：2005/03/15 (Tue) 10:02:12 N.Kasai
    '更新日：2005/05/07 (Sat) 16:57:06 N.Kojima
    '備　考：
    '　　　：2005/05/07 (Sat) 16:57:06 N.Kojima     応答に"EMP_NAME"追加(不具合№731)
    Public Function pubblnEqCmpList_Sel(ByRef ltypEqcmplistRec As EqcmplistRec, _
                                              ByRef ltypEqcmplistAns As EqcmplistAns) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        Dim llngMaxCnt          As String           '総ﾃﾞｰﾀ件数
        
        Try
            
            pstrMessageName = "ＣＭＰ情報一覧取得"
            
            pubblnEqCmpList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            
            '@総ﾃﾞｰﾀ件数初期化
            llngMaxCnt = 0
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypEqcmplistRec
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__cmplist_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@ﾃﾞｰﾀを取得
                    With ltypEqcmplistAns
                    
                        Call laMsg.getString(CPstrEDIT_TIME, .strEditTime)                      '応答ﾒｯｾｰｼﾞ生成日時
                        Call laMsg.getMsgAry(CPstrCMP_LIST, laAry)                              'CMPﾘｽﾄ
                        
                        '@CMPﾘｽﾄｶｳﾝﾄ取得
                        .lngCmpListCnt = laAry.Count
                    
                        '@@CMPﾘｽﾄｶｳﾝﾄ判定
                        If .lngCmpListCnt > 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            
                            '@配列の要素数を設定
                            If .typCmpList Is Nothing Then 
                                .typCmpList = New List(Of CmpList) 
                            Else 
                                .typCmpList.Clear 
                            End If

                            Dim cmpListRec As CmpList  

                            llngCnt = 1
                            '@ｱﾚｰの各要素取得（CMPﾘｽﾄ）
                            For Each ltMsg In laAry
                                cmpListRec = New CmpList
                                With cmpListRec
                                
                                    Call ltMsg.getString(CPstrWP_ID, .strWpID)                  'WPID
                                    Call ltMsg.getString(CPstrWP_NAME, .strWpName)              '装置名
                                    Call ltMsg.getMsgAry(CPstrHEAD_PLATEN_LIST, laAry2)         'ﾍｯﾄﾞﾌﾟﾗﾃﾝﾘｽﾄ
                                    
                                    '@ﾍｯﾄﾞﾌﾟﾗﾃﾝﾘｽﾄｶｳﾝﾄ取得
                                    .lngHeadPlatenListCnt = laAry2.Count
                                    
                                    '@ﾍｯﾄﾞﾌﾟﾗﾃﾝﾘｽﾄｶｳﾝﾄ判定
                                    If .lngHeadPlatenListCnt > 0 Then
                                        
                                        If .typHeadPlatenList Is Nothing Then 
                                            .typHeadPlatenList = New List(Of HeadPlatenList)                                       
                                        End If

                                        '@配列の要素数を設定
                                        Dim HeadPlatenListRec As HeadPlatenList
                                        HeadPlatenListRec = New HeadPlatenList

                                        For Each ltMsg2 In laAry2
                                            '@ｱﾚｰの各要素取得
                                            With HeadPlatenListRec
                                                Call ltMsg2.getString(CPstrHEAD, .strHead)                      'ﾍｯﾄﾞ
                                                Call ltMsg2.getString(CPstrPLATEN, .strPlaten)                  'ﾌﾟﾗﾃﾝ
                                                Call ltMsg2.getString(CPstrPOL_RATE, .strPolRate)               '研磨ﾚｰﾄ
                                                Call ltMsg2.getString(CPstrRATE_CALC_TIME, .strRateCalcTime)    'ﾚｰﾄ計算日時
                                                Call ltMsg2.getString(CPstrLOT_ID, .strLotID)                   'ﾚｰﾄ計算ﾛｯﾄID
                                                Call ltMsg2.getString(CPstrCMP_OP_ID, .strCmpOpID)              'CMP大工程
                                                Call ltMsg2.getString(CPstrPOL_TIME, .strPolTime)               '研磨時間
                                                Call ltMsg2.getString(CPstrCMP_1ST, .strCmp1st)                 '1st膜厚
                                                Call ltMsg2.getString(CPstrCMP_2ND, .strCmp2nd)                 '2nd膜厚
                                                Call ltMsg2.getString(CPstrAVAIL_FLAG, .strAvailFlag)           '研磨ﾚｰﾄ使用可否
                                                Call ltMsg2.getString(CPstrEVENT_NAME, .strEventName)           'ｲﾍﾞﾝﾄ名
                                                Call ltMsg2.getString(CPstrCOMMENTS, .strComments)              'ｺﾒﾝﾄ
        '@↓2005/05/07 (Sat) 16:55:43 N.Kojima **************************************************
                                                Call ltMsg2.getString(CPstrEMP_NAME, .strEmpName)               '作業者名
        '@↑2005/05/07 (Sat) 16:55:43 N.Kojima **************************************************
                                            End With
                                            .typHeadPlatenList.Add(HeadPlatenListRec)
                                            llngMaxCnt = llngMaxCnt + 1
                                        Next
                                    End If
                                End With
                                .typCmpList.Add(cmpListRec)
                            Next
                        End If
                    
                    '@総件数をｾｯﾄ
                    .lngCmpListAnsCnt = llngMaxCnt
                    
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnEqCmpList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypEqcmplistRec.strMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing
            
        End Try
    End Function

End Module
