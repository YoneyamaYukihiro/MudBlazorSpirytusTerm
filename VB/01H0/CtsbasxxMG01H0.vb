'ﾌｧｲﾙ名：xxMG01H0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：投入移載一覧　標準ﾓｼﾞｭｰﾙ
'作成日：2004/10/22 (Fri) 10:44:30 N.Kasai
'更新日：2005/04/01 (Fri) 09:03:00 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01H0
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

    '関数名：pubblnUnCarryList_Sel
    '機　能：投入移載ﾛｯﾄﾘｽﾄ取得
    '引　数：lstrlot_uncarrylistVer：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID：処理区分
    '　　　：ltypUnCarryList：投入移載ﾛｯﾄﾘｽﾄ応答格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2004/10/22 (Fri) 15:46:41 N.Kasai
    '更新日：2004/10/22 (Fri) 15:46:41
    '備　考：
    Public Function pubblnUnCarryList_Sel(ByVal lstrlot_uncarrylistVer As String, ByVal lstrSBID As String, _
                                            ByRef ltypUnCarryList As UnCarryList) As Boolean

        Dim lrMsg              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg1             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry1             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim ltMsg2             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry2             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET            As String           '応答取得
        Dim llngCnt1           As Integer          'ｶｳﾝﾄ用
        Dim llngCnt2           As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "投入移載ロットリスト取得"
            pubblnUnCarryList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_uncarrylistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_uncarrylistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@処理区分
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_uncarrylist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry1)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                    ltypUnCarryList.llngUnCarryListcnt = laAry1.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypUnCarryList.llngUnCarryListcnt > 0 Then
                        If IsNothing(ltypUnCarryList.typUnCarry) Then
                            ltypUnCarryList.typUnCarry = New list(Of UnCarry)
                        Else
                            ltypUnCarryList.typUnCarry.Clear()
                        End If
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ１から各Msg取得
                        llngCnt1 = 1
                        For Each ltMsg1 In laAry1
                            '@受信結果取得
                            Dim item1 As UnCarry
                            With item1
                                '@ﾃﾞｰﾀ(板厚区分)を取得
                                Call ltMsg1.getString(CPstrTHROWIN_DATE, .strThowinDate)        '投入確定日
                                Call ltMsg1.getString(CPstrPD_ID, .strPdId)                     '機種ID
                                Call ltMsg1.getString(CPstrPD_NAME, .strPdName)                 '機種（和名）
                                Call ltMsg1.getString(CPstrLOT_ID, .strLotID)                   'ﾛｯﾄID
                                Call ltMsg1.getString(CPstrFLOW_CLASS, .strFlowClass)           '種別ID
                                Call ltMsg1.getString(CPstrFLOW_CLASS_NAME, .strFlowClassName)  '種別（和名）
                                Call ltMsg1.getString(CPstrCARRIER_ID, .strCarrierId)           'ｷｬﾘｱID
                                Call ltMsg1.getString(CPstrWF_NUM, .strWfNum)                   'WF枚数
                                Call ltMsg1.getString(CPstrENG_EMP_ID, .strEngEmpId)            '作業者ID
                                Call ltMsg1.getString(CPstrENG_EMP_NAME, .strEngEmpName)        '作業者名
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2取得
                                Call ltMsg1.getMsgAry(CPstrPART_LIST, laAry2)
                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2のｶｳﾝﾄ格納
                                .llngCarryPartListcnt = laAry2.Count
                            
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                If .llngCarryPartListcnt > 0 Then
                                    .typUnCarryPartList = New list(Of UnCarryPartList)
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                    llngCnt2 = 1
                                    For Each ltMsg2 In laAry2
                                        Dim item2 As UnCarryPartList
                                        '@受信結果取得
                                        Call ltMsg2.getString(CPstrPRODUCTION_LOT_ID, item2.strProductionLotID) '製造ﾛｯﾄID
                                        llngCnt2 = llngCnt2 + 1
                                        .typUnCarryPartList.Add(item2)
                                    Next
                                End If
                            End With
                            ltypUnCarryList.typUnCarry.Add(item1)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnUnCarryList_Sel = True
                                            
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_uncarrylistVer)
                    
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
            ltMsg2 = Nothing
            laAry2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing

        End Try
    End Function

    '関数名：pubblnForcedMove_Upd
    '機　能：投入移載
    '引　数：ltypForcedMove：投入移載要求構造体
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：正常、False：異常
    '作成日：2004/10/22 (Fri) 17:47:29 N.Kasai
    '更新日：2005/04/01 (Fri) 09:03:35 N.Kojima
    '備　考：2005/03/16 (Wed) 17:01:52 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    'Public Function pubblnForcedMove_Upd(ByRef ltypForcedMove As ForcedMove) As Boolean
    Public Function pubblnForcedMove_Upd(ByRef ltypForcedMove As Forcedmove, _
                                         ByRef lstrGuidMsg As String, _
                                         ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
         
        Try
            
            pstrMessageName = "投入移載"
            pubblnForcedMove_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypForcedMove
                '@送信ﾒｯｾｰｼﾞ作成
                
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                  'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                      'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                    '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
        '@↓2005/03/16 (Wed) 17:02:50 N.Kojima **************************************************
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)                      'WPID
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
        '@↑2005/03/16 (Wed) 17:02:50 N.Kojima **************************************************
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_forcedmove, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信結果取得
                        Call laMsg.getString(CPstrCARRIER_ID, .strCarrierId)            'ｷｬﾘｱID
        '@↓2005/03/31 (Thu) 14:07:45 N.Kojima **************************************************
                        Call laMsg.getString(CPstrMSG, lstrGuidMsg)                     'ｶﾞｲﾀﾞﾝｽMsg
                        Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)            'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        '@↑2005/03/31 (Thu) 14:07:45 N.Kojima **************************************************
                        
                        '@関数の処理結果(成功)格納
                        pubblnForcedMove_Upd = True
                        
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
