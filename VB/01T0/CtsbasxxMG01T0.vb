'ﾌｧｲﾙ名：xxMG01T0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾌｫﾄF/Bﾊﾟﾗﾒｰﾀ変更　標準ﾓｼﾞｭｰﾙ
'作成日：2006/03/14 (Tue) 17:58:39 N.Kasai
'更新日：2006/03/14 (Tue) 17:58:39
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01T0
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

    '関数名：pubblnPhotoFbEqParameter_Sel
    '機　能：ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ取得
    '引　数：ltypPhotoFbEqPrmListReq：要求格納構造体
    '　　　：ltypPhotoFbEqPrmListAns：応答格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2006/03/01 (Wed) 15:17:37 N.Kasai
    '更新日：2007/05/21 (Mon) 11:13:22 N.Kasai
    '備　考：
    '　　　：2007/05/21 (Mon) 11:13:22 N.Kasai  応答ﾀｸﾞ追加（DATA_KIND）№01935
    Public Function pubblnPhotoFbEqParameter_Sel(ByRef ltypPhotoFbEqPrmListReq As PhotoFbEqPrmListReq, _
                                                        ByRef ltypPhotoFbEqPrmListAns As PhotoFbEqPrmListAns) As Boolean

        Dim lrMsg              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg1             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry1             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET            As String           '応答取得
        Dim llngCnt1           As Integer          'ｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "フォトF/B装置パラメータ取得"
            '@戻り値初期化
            pubblnPhotoFbEqParameter_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypPhotoFbEqPrmListReq
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@処理区分
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
        '@↓2007/05/21 (Mon) 11:13:18 N.Kasai **************************************************
                '@ﾃﾞｰﾀ種別（1:F/Bﾊﾟﾗﾒｰﾀ、2:F/B初期値）
                If .strDataKind <> vbNullString Then
                    Call lrMsg.addString(CPstrDATA_KIND, .strDataKind)
                Else
                    Call lrMsg.addString(CPstrDATA_KIND, CPstrMsgNull)
                End If
        '@↑2007/05/21 (Mon) 11:13:18 N.Kasai **************************************************
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__photofbeqprmlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrEQ_PARAMETER_LIST, laAry1)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                    ltypPhotoFbEqPrmListAns.lngEqPrmListCnt = laAry1.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypPhotoFbEqPrmListAns.lngEqPrmListCnt > 0 Then
                        ltypPhotoFbEqPrmListAns.typEqPrmList = New List(Of EqPrmList)
                        Dim tmpEqPrmList As EqPrmList = New EqPrmList

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ１から各Msg取得
                        llngCnt1 = 1
                        For Each ltMsg1 In laAry1
                            '@受信結果取得
                            With tmpEqPrmList
                                '@ﾊﾟﾗﾒｰﾀﾃﾞｰﾀを取得
                                Call ltMsg1.getString(CPstrITEM_NAME, .strItemName)                 '装置ﾊﾟﾗﾒｰﾀ
                                Call ltMsg1.getString(CPstrITEM_VALUE, .strItemValue)               '現在値
                                Call ltMsg1.getString(CPstrITEM_UNIT, .strItemUnit)                 '単位
                                Call ltMsg1.getString(CPstrITEM_VALID_DIGIT, .strItemValidDigit)    '小数点以下有効桁
                                Call ltMsg1.getString(CPstrLOWER_LIMIT, .strLowerLimit)             '下限値
                                Call ltMsg1.getString(CPstrUPPER_LIMIT, .strUpperLimit)             '上限値
                                Call ltMsg1.getString(CPstrEMP_NAME, .strEmpName)                   '最終更新者
                                Call ltMsg1.getString(CPstrENTRY_TIME, .strEntryTime)               '最終更新日時
                            End With
                            ltypPhotoFbEqPrmListAns.typEqPrmList.Add(tmpEqPrmList)

                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnPhotoFbEqParameter_Sel = True
                                            
                '@失敗の場合(False)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypPhotoFbEqPrmListReq.strMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

        End Try
    End Function

    '関数名：pubblnPhotoFbEqParameter_Upd
    '機　能：ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ変更
    '引　数：ltypPhotoFbEqPrmchgReq：要求格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2006/03/01 (Wed) 15:37:13 N.Kasai
    '更新日：2007/05/21 (Mon) 11:14:49 N.Kasai
    '備　考：
    '　　　：2007/05/21 (Mon) 11:14:49 N.Kasai  応答ﾀｸﾞ追加（DATA_KIND）№01935
    Public Function pubblnPhotoFbEqParameter_Upd(ByRef ltypPhotoFbEqPrmchgReq As PhotoFbEqPrmchgReq) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim lrAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾀ
        
        Try
            
            '@初期設定
            pstrMessageName = "フォトF/B装置パラメータ変更"
            '@戻り値の初期化
            pubblnPhotoFbEqParameter_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypPhotoFbEqPrmchgReq
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
        '@↓2007/05/21 (Mon) 11:17:15 N.Kasai **************************************************
                '@ﾃﾞｰﾀ種別（1:F/Bﾊﾟﾗﾒｰﾀ、2:F/B初期値）
                If .strDataKind <> vbNullString Then
                    Call lrMsg.addString(CPstrDATA_KIND, .strDataKind)
                Else
                    Call lrMsg.addString(CPstrDATA_KIND, CPstrMsgNull)
                End If
        '@↑2007/05/21 (Mon) 11:17:15 N.Kasai **************************************************
                
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                '@Aryﾒｯｾｰｼﾞ作成
                For llngCnt = 0 To .lngFbItemListCnt - 1
                    '@装置ﾊﾟﾗﾒｰﾀ名
                    If .typFbItemList(llngCnt).strItemName <> vbNullString Then
                        Call ltMsg.addString(CPstrITEM_NAME, .typFbItemList(llngCnt).strItemName)
                    Else
                        Call ltMsg.addString(CPstrITEM_NAME, CPstrMsgNull)
                    End If
                    '@装置ﾊﾟﾗﾒｰﾀ値
                    If .typFbItemList(llngCnt).strItemValue <> vbNullString Then
                        Call ltMsg.addString(CPstrITEM_VALUE, .typFbItemList(llngCnt).strItemValue)
                    Else
                        Call ltMsg.addString(CPstrITEM_VALUE, CPstrMsgNull)
                    End If
                    '@ｱﾚｲに格納
                    Call lrAry.Add(ltMsg)
                Next
                
                '@ｱﾚｲ追加
                Call lrMsg.addMsgAry(CPstrITEM_LIST, lrAry)
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__photofbeqprmchg, lrMsg, laMsg)
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信結果取得
                        '@応答なし
                        
                        '@関数の処理結果(成功)格納
                        pubblnPhotoFbEqParameter_Upd = True
                        
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

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            Exit Function
            
        '@例外処理
        Catch ex As Exception

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMasDfineList_Sel
    '機　能：DEFINE情報取得
    '引　数：ltypMasDefineReq：要求
    '　　　：ltypMasDefineAns：応答
    '戻り値：True：正常、False：異常
    '作成日：2007/05/21 (Mon) 17:17:00 N.Kasai
    '更新日：2007/05/21 (Mon) 17:17:00
    '備　考：
    Public Function pubblnMasDfineList_Sel(ByRef ltypMasDefineReq As MasDefineReq, _
                                            ByRef ltypMasDefineAns As MasDefineAns) As Boolean

        Dim lrMsg              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg1             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry1             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET            As String           '応答取得
        Dim llngCnt1           As Integer          'ｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "DEFINE情報取得"
            
            '@戻り値初期化
            pubblnMasDfineList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypMasDefineReq
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@ﾃｰﾌﾞﾙ名
                If .strTableName <> vbNullString Then
                    Call lrMsg.addString(CPstrTABLE_NAME, .strTableName)
                Else
                    Call lrMsg.addString(CPstrTABLE_NAME, CPstrMsgNull)
                End If
                '@ｶﾗﾑ名
                If .strColumnName <> vbNullString Then
                    Call lrMsg.addString(CPstrCOLUMN_NAME, .strColumnName)
                Else
                    Call lrMsg.addString(CPstrCOLUMN_NAME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_definelist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrDEFINE_LIST, laAry1)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                    ltypMasDefineAns.lngMasDefineListCnt = laAry1.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypMasDefineAns.lngMasDefineListCnt > 0 Then
                        ltypMasDefineAns.typMasDefineList = New List(Of MasDefineList)
                        Dim tmpMasDefineList As MasDefineList = New MasDefineList

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ１から各Msg取得
                        llngCnt1 = 1
                        For Each ltMsg1 In laAry1
                            '@受信結果取得
                            With tmpMasDefineList
                                Call ltMsg1.getString(CPstrID, .strId)              'ID
                                Call ltMsg1.getString(CPstrNAME, .strName)          'ID名称
                            End With

                            ltypMasDefineAns.typMasDefineList.Add(tmpMasDefineList)

                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasDfineList_Sel = True
                                            
                '@失敗の場合(False)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypMasDefineReq.strMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

        End Try
    End Function


End Module
