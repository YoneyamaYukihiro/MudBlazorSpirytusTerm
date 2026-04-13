'ﾌｧｲﾙ名：xxMG0160.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾛｯﾄ分割通信Msg
'作成日：2004/03/29 (Mon) 15:49:32 N.Kasai
'更新日：2016/02/11 (Thu) 22:49:09 H.Hayashi
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0160
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

    '関数名：pubblnLotDivide_Upd
    '機　能：ﾛｯﾄ分割
    '引　数：ltyplotdivide：分割内容格納
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/04/14 (Wed) 13:46:36 Y.Yamagishi
    '更新日：2016/02/11 (Thu) 22:48:20 H.Hayashi
    '備　考：
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnLotDivide_Upd(ByRef ltyplotdivide As Lotdivide, _
                                        ByRef lstrGuidMsg As String, _
                                        ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "ロット分割"
            pubblnLotDivide_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltyplotdivide
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@分割元ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
        '@↓2016/01/26 (Tue) 11:13:21 H.Hayashi **************************************************
                '@分割元GRB区分
                If .strGrbClass <> vbNullString Then
                    Call lrMsg.addString(CPstrGRB_CLASS, .strGrbClass)
                Else
                    Call lrMsg.addString(CPstrGRB_CLASS, CPstrMsgNull)
                End If
        '@↑2016/01/26 (Tue) 11:13:21 H.Hayashi **************************************************
                '@分割先ﾛｯﾄID
                If .strDivideLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrDIVIDE_LOT_ID, .strDivideLotID)
                Else
                    Call lrMsg.addString(CPstrDIVIDE_LOT_ID, CPstrMsgNull)
                End If
        '@↓2016/01/26 (Tue) 11:13:21 H.Hayashi **************************************************
                '@分割先GRB区分
                If .strDivideGrbClass <> vbNullString Then
                    Call lrMsg.addString(CPstrDIVIDE_GRB_CLASS, .strDivideGrbClass)
                Else
                    Call lrMsg.addString(CPstrDIVIDE_GRB_CLASS, CPstrMsgNull)
                End If
        '@↑2016/01/26 (Tue) 11:13:21 H.Hayashi **************************************************
                
                
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
            
                '@Aryﾒｯｾｰｼﾞ作成
                llngCnt = 0
                 Do While .typWFMap.Count -1 >= llngCnt
                    If .typWFMap(llngCnt).strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, .typWFMap(llngCnt).strWfId)                    'WFID
                        Call ltMsg.addString(CPstrSLOT_POSITION, .typWFMap(llngCnt).strSlotPosition)    'ｽﾛｯﾄ№
                        Call lrAry.Add(ltMsg)
                    End If
                    ltMsg.Clear
                    llngCnt = llngCnt + 1
                Loop
                Call lrMsg.addMsgAry(CPstrDIVIDE_WF_MAP_LIST, lrAry)
                lrAry.Clear
            
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@Lot最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
            End With
            '@SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_divide__, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                
                    '@関数の処理結果(成功)格納
                    pubblnLotDivide_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltyplotdivide.strMsgVer)
                    
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

    '関数名：pubblnLotCombine_Upd
    '機　能：ﾛｯﾄ統合
    '引　数：ltyplotcombine     ：統合内容格納
    '　　　：lstrGuidMsg        ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode    ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/04/15 (Thu) 09:10:24 Y.Yamagishi
    '更新日：2005/04/01 (Fri) 10:35:13 N.Kojima
    '備　考：
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    Public Function pubblnLotCombine_Upd(ByRef ltyplotcombine As Lotcombine, _
                                         ByRef lstrGuidMsg As String, _
                                         ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "ロット統合"
            pubblnLotCombine_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltyplotcombine
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@統合対象ﾛｯﾄID1
                If .strLotID1 <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID1, .strLotID1)
                Else
                    Call lrMsg.addString(CPstrLOT_ID1, CPstrMsgNull)
                End If
                '@統合対象ﾛｯﾄID2
                If .strLotID2 <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID2, .strLotID2)
                Else
                    Call lrMsg.addString(CPstrLOT_ID2, CPstrMsgNull)
                End If
                '@ﾛｯﾄ1最終更新日時
                If .strLotLastUpdate1 <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE1, .strLotLastUpdate1)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE1, CPstrMsgNull)
                End If
                '@ﾛｯﾄ2最終更新日時
                If .strLotLastUpdate2 <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE2, .strLotLastUpdate2)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE2, CPstrMsgNull)
                End If
                '@統合ﾒﾓ
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
            End With
            '@SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_combine_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
            
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrCOMBINE_LOT_ID, ltyplotcombine.strCombineLotID)   '統合先ﾛｯﾄID
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                                 'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                        'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotCombine_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltyplotcombine.strMsgVer)
                                  
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

    '関数名：pubblnLotDivideDirect_Upd
    '機　能：ﾛｯﾄ分割(一括移載)
    '引　数：ltyplotdivide：要求格納構造体
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2007/07/23 (Mon) 16:50:01 N.Kasai
    '更新日：2016/02/11 (Thu) 22:48:44 H.Hayashi
    '備　考：
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnLotDivideDirect_Upd(ByRef ltyplotdivide As Lotdivide, _
                                            ByRef lstrGuidMsg As String, _
                                            ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "ロット分割(一括移載)"
            pubblnLotDivideDirect_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltyplotdivide
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@分割元ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@↓2016/01/26 (Tue) 11:13:21 H.Hayashi **************************************************
                '@分割元GRB区分
                If .strGrbClass <> vbNullString Then
                    Call lrMsg.addString(CPstrGRB_CLASS, .strGrbClass)
                Else
                    Call lrMsg.addString(CPstrGRB_CLASS, CPstrMsgNull)
                End If
                '@↑2016/01/26 (Tue) 11:13:21 H.Hayashi **************************************************
                '@分割先ﾛｯﾄID
                If .strDivideLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrDIVIDE_LOT_ID, .strDivideLotID)
                Else
                    Call lrMsg.addString(CPstrDIVIDE_LOT_ID, CPstrMsgNull)
                End If
                '@↓2016/01/26 (Tue) 11:13:21 H.Hayashi **************************************************
                '@分割先GRB区分
                If .strDivideGrbClass <> vbNullString Then
                    Call lrMsg.addString(CPstrDIVIDE_GRB_CLASS, .strDivideGrbClass)
                Else
                    Call lrMsg.addString(CPstrDIVIDE_GRB_CLASS, CPstrMsgNull)
                End If
                '@↑2016/01/26 (Tue) 11:13:21 H.Hayashi **************************************************
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
            
                '@Aryﾒｯｾｰｼﾞ作成
                llngCnt = 0
                Do While .typWFMap.Count -1 >= llngCnt
                    If .typWFMap(llngCnt).strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, .typWFMap(llngCnt).strWfId)                    'WFID
                        Call ltMsg.addString(CPstrSLOT_POSITION, .typWFMap(llngCnt).strSlotPosition)    'ｽﾛｯﾄ№
                        Call lrAry.Add(ltMsg)
                    End If
                    ltMsg.Clear
                    llngCnt = llngCnt + 1
                Loop
                Call lrMsg.addMsgAry(CPstrDIVIDE_WF_MAP_LIST, lrAry)
                lrAry.Clear
                
                '@分割先ｷｬﾘｱ
                If .strToCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrTO_CARRIER_ID, .strToCarrierId)
                Else
                    Call lrMsg.addString(CPstrTO_CARRIER_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@Lot最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
            End With
            '@SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_dividedirect, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                
                    '@関数の処理結果(成功)格納
                    pubblnLotDivideDirect_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltyplotdivide.strMsgVer)
                    
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

    '関数名：pubblnLotCombineDirect_Upd
    '機　能：ﾛｯﾄ統合(一括移載)
    '引　数：ltyplotcombine：要求構造体
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2007/07/24 (Tue) 10:11:20 N.Kasai
    '更新日：2007/07/24 (Tue) 10:11:20
    '備　考：
    Public Function pubblnLotCombineDirect_Upd(ByRef ltyplotcombine As Lotcombine, _
                                         ByRef lstrGuidMsg As String, _
                                         ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "ロット統合(一括移載)"
            
            pubblnLotCombineDirect_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltyplotcombine
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

				'@CLASS_DIVISION
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@統合対象ﾛｯﾄID1
                If .strLotID1 <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID1, .strLotID1)
                Else
                    Call lrMsg.addString(CPstrLOT_ID1, CPstrMsgNull)
                End If
                '@統合対象ﾛｯﾄID2
                If .strLotID2 <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID2, .strLotID2)
                Else
                    Call lrMsg.addString(CPstrLOT_ID2, CPstrMsgNull)
                End If
                '@ﾛｯﾄ1最終更新日時
                If .strLotLastUpdate1 <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE1, .strLotLastUpdate1)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE1, CPstrMsgNull)
                End If
                '@ﾛｯﾄ2最終更新日時
                If .strLotLastUpdate2 <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE2, .strLotLastUpdate2)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE2, CPstrMsgNull)
                End If
                '@作業ﾒﾓ
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
            End With
            '@SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_combinedirect, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
            
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrCOMBINE_LOT_ID, ltyplotcombine.strCombineLotID)   '統合先ﾛｯﾄID
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                                 'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                        'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotCombineDirect_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltyplotcombine.strMsgVer)
                                  
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

    '関数名：prvblnDivideWfRecipeNull_Chk
    '機　能：ﾛｯﾄ分割ﾚｼﾋﾟﾁｪｯｸ
    '引　数：CMstrlot_dividerecipeVer：ﾒｯｾｰｼﾞVer
    '　　　：ltypChkDivderRecipe：ﾒｯｾｰｼﾞ送受信構造体
    '戻り値：True：成功、False：失敗
    '作成日：2010/06/21 (Mon) 16:30:20 T.Oide
    '更新日：2010/06/21 (Mon) 16:30:20
    '備　考：
    Public Function prvblnDivideWfRecipeNull_Chk(ByVal CMstrlot_dividerecipeVer As String, _
                                                 ByRef ltypChkDivderRecipe As typChkDivderRecipe) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim lrMsgAry            As TfMsgAry         '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄｱﾚｰ）
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄﾃﾝﾌﾟ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "ロット分割レシピ状態チェック"
            
            prvblnDivideWfRecipeNull_Chk = False
            
            lrMsg = New TfMsg
            lrMsgAry = New TfMsgAry
            ltMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypChkDivderRecipe
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If CMstrlot_dividerecipeVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, CMstrlot_dividerecipeVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@分割元WFﾏｯﾌﾟ
                llngCnt = 0
                Do While .strWfList.Count-1 >= llngCnt
                    Call ltMsg.addString(CPstrWF_ID, .strWfList(llngCnt))
                    llngCnt = llngCnt + 1
                    Call lrMsgAry.Add(ltMsg)
                    ltMsg.Clear
                Loop
                Call lrMsg.addMsgAry(CPstrWF_MAP_LIST, lrMsgAry)
                lrMsgAry.Clear
                
                '@分割ﾛｯﾄID
                If .strDivLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrDIVIDE_LOT_ID, .strDivLotID)
                Else
                    Call lrMsg.addString(CPstrDIVIDE_LOT_ID, CPstrMsgNull)
                End If
                '@分割先WFﾏｯﾌﾟ
                llngCnt = 0
                Do While .strDiveWFList.Count-1>= llngCnt
                    Call ltMsg.addString(CPstrWF_ID, .strDiveWFList(llngCnt))
                    llngCnt = llngCnt + 1
                    Call lrMsgAry.Add(ltMsg)
                    ltMsg.Clear
                Loop
                Call lrMsg.addMsgAry(CPstrDIVIDE_WF_MAP_LIST, lrMsgAry)
                lrMsgAry.Clear
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkdividerecipe, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
            
                '@成功の場合(true)
                Case CPstrTRUE
                        
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG_CODE, ltypChkDivderRecipe.strMsgCode) 'ﾒｯｾｰｼﾞｺｰﾄﾞ
                    Call laMsg.getString(CPstrMSG, ltypChkDivderRecipe.strMsg)          'ﾒｯｾｰｼﾞ
                    
                    '@関数の処理結果(成功)格納
                    prvblnDivideWfRecipeNull_Chk = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, CMstrlot_dividerecipeVer)
                                  
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            lrMsgAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
            '@例外処理
        Catch ex As Exception
            
            lrMsg = Nothing
            lrMsgAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：prvblnCombineRecipeNull_Chk
    '機　能：ﾛｯﾄ分割ﾚｼﾋﾟﾁｪｯｸ
    '引　数：CMstrlot_combinerecipeVer：ﾒｯｾｰｼﾞVer
    '　　　：ltypChkDivderRecipe：ﾒｯｾｰｼﾞ送受信構造体
    '戻り値：True：成功、False：失敗
    '作成日：2010/06/21 (Mon) 16:30:20 T.Oide
    '更新日：2010/06/21 (Mon) 16:30:20
    '備　考：
    Public Function prvblnCombineRecipeNull_Chk(ByVal CMstrlot_combinerecipeVer As String, _
                                                ByRef ltypChkCombineRecipe As typChkCombineRecipe) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ））
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "ロット統合レシピ状態チェック"
            
            prvblnCombineRecipeNull_Chk = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypChkCombineRecipe
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If CMstrlot_combinerecipeVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, CMstrlot_combinerecipeVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@統合ﾛｯﾄID
                If .strDivLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrDIVIDE_LOT_ID, .strDivLotID)
                Else
                    Call lrMsg.addString(CPstrDIVIDE_LOT_ID, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkcombinerecipe, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
            
                '@成功の場合(true)
                Case CPstrTRUE
                        
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG_CODE, ltypChkCombineRecipe.strMsgCode) 'ﾒｯｾｰｼﾞｺｰﾄﾞ
                    Call laMsg.getString(CPstrMSG, ltypChkCombineRecipe.strMsg)          'ﾒｯｾｰｼﾞ
                    
                    '@関数の処理結果(成功)格納
                    prvblnCombineRecipeNull_Chk = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, CMstrlot_combinerecipeVer)
                                  
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

    '関数名：prvblnLotSectionPriority_Chk
    '機　能：ﾛｯﾄ区間優先度ﾁｪｯｸ
    '引　数：lstrMsgVer：ﾒｯｾｰｼﾞVer
    '　　　：lstrLotID：ﾛｯﾄID
    '　　　：lsrtResult：判定結果
    '戻り値：True：成功、False：失敗
    '作成日：2011/09/28 (Wed) 10:35:50 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function prvblnLotSectionPriority_Chk(ByVal lstrMsgVer As String, _
                                                 ByVal lstrLotID As String, _
                                                 ByRef lsrtResult As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "区間優先度設定チェック"
            
            prvblnLotSectionPriority_Chk = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@LotId
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chksecpriority, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrRESULT, lsrtResult)
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    prvblnLotSectionPriority_Chk = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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

    '関数名：prvblnCombineInLot_Chk
    '機　能：ﾛｯﾄ統合時の元ﾛｯﾄﾁｪｯｸ
    '引　数：CMstrlot_combinerecipeVer：ﾒｯｾｰｼﾞVer
    '　　　：typChkCombineLotIn：ﾒｯｾｰｼﾞ送受信構造体
    '戻り値：True：成功、False：失敗
    '作成日：2017/06/06 (Tue) 10:30:17 T.Oide
    '更新日：
    '備　考：
    Public Function prvblnCombineInLot_Chk(ByVal lstrMsgVer As String, _
                                           ByRef ltypChkCombineLotIn As typChkCombineLotIn) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ））
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ組立用一時ﾒｯｾｰｼﾞ
        Dim lrMsgAry            As TfMsgAry         '送信ﾒｯｾｰｼﾞ組立用一時ﾒｯｾｰｼｱﾚｲﾞ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            '@初期設定
            pstrMessageName = "ロット統合元ロットチェック"
            
            prvblnCombineInLot_Chk = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrMsgAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypChkCombineLotIn
            
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ｳｪﾊｰﾘｽﾄ
                llngCnt = 0
                Do While .lngWfListCnt-1 >= llngCnt
                    Call ltMsg.addString(CPstrWF_ID, .strWfList(llngCnt))
                    llngCnt = llngCnt + 1
                    Call lrMsgAry.Add(ltMsg)
                    ltMsg.Clear
                Loop
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrMsgAry)
                lrMsgAry.Clear
                
                '@Wf再利用ﾌﾗｸﾞ
                If .strRecyclFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrWF_RECYCL_FLAG, .strRecyclFlag)
                Else
                    Call lrMsg.addString(CPstrWF_RECYCL_FLAG, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkcombineLotIn, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
            
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrRESULT, ltypChkCombineLotIn.strResult) '結果取得
                    
                    '@関数の処理結果(成功)格納
                    prvblnCombineInLot_Chk = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                            
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
            lrMsgAry = Nothing
            
            Exit Function
            
            '@例外処理
        Catch ex As Exception
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrMsgAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

End Module
