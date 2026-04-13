'ﾌｧｲﾙ名：xxMG00B0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CFロット編成 通信メッセージ用標準モジュール
'作成日：2004/06/14 (Mon) 11:16:54 S.Deguchi
'更新日：2008/06/11 (Wed) 11:16:25 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00B0
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

    '関数名：pubblnMasScreenList_Sel
    '機　能：画面ｻｲｽﾞﾏｽﾀ取得
    '引　数：lstrmas_screenlistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCfFlag             ：CFﾌﾗｸﾞ(1：CFの時、0：CF以外)
    '　　　：ltypScreenSizeList     ：画面ｻｲｽﾞ構造体
    '戻り値：True:正常、False:異常
    '作成日：2004/06/14 (Mon) 11:47:03 N.Kasai
    '更新日：2008/06/11 (Wed) 16:24:10 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 16:24:10 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnMasScreenList_Sel(ByVal lstrmas_screenlistVer As String, _
                                            ByVal lstrCfFlag As String, _
                                            ByRef ltypScreenSizeList As ScreenSizeList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "画面サイズマスタ取得"
            pubblnMasScreenList_Sel = False
            
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_screenlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_screenlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@CFﾌﾗｸﾞ
            If lstrCfFlag <> vbNullString Then
                Call lrMsg.addString(CPstrCF_FLAG, lstrCfFlag)
            Else
                Call lrMsg.addString(CPstrCF_FLAG, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_screenlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｰを格納：画面ｻｲｽﾞﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrSCREEN_SIZE_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｰ数：画面ｻｲｽﾞﾘｽﾄﾃﾞｰﾀ数
                    ltypScreenSizeList.lngScreenSizeListCnt = laAry.Count
                
                    '@画面ｻｲｽﾞﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If ltypScreenSizeList.lngScreenSizeListCnt > 0 Then

                        '@配列領域を確保
                        If IsNothing(ltypScreenSizeList.typScreenList) Then
                            ltypScreenSizeList.typScreenList = New List(Of ScreenList)
                        Else
                            ltypScreenSizeList.typScreenList.Clear()
                        End If

                        Dim typScreenListTmp As New ScreenList

                        '@ｶｳﾝﾀの初期化
                        llngCnt = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry
                        
                            With typScreenListTmp
                                
                                Call ltMsg.getString(CPstrSCREEN_SIZE_ID, .strScreenSizeID)     '画面ｻｲｽﾞID
                                Call ltMsg.getString(CPstrCHIP_COUNT, .strChipCount)            '基板取個数(詰数)
                            End With
                            ltypScreenSizeList.typScreenList.Add(typScreenListTmp)
                            '@ｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnMasScreenList_Sel = True
                    
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_screenlistVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄの解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄの解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnLotCfThrowin_Upd
    '機　能：CFﾛｯﾄ編成登録処理
    '引　数：lstrlot_cfthrowinVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotCfThrowin       ：CFﾛｯﾄ編成構造体
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True:正常、False:異常
    '作成日：2004/06/14 (Mon) 13:46:19 N.Kasai
    '更新日：2008/06/11 (Wed) 16:24:37 N.Kojima
    '備　考：
    '　　　：2004/11/24 (Wed) 15:06:01 S.Deguchi    技術担当者ID送信処理を追加
    '　　　：2005/03/14 (Mon) 16:42:21 N.Kojima     投入装置追加に伴い、要求に"WP_ID"追加(改善№577)
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2008/06/11 (Wed) 11:17:15 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/06/11 (Wed) 16:24:37 N.Kojima     ｿｰｽ整備。(案件№02884)
    Public Function pubblnLotCfThrowin_Upd(ByVal lstrlot_cfthrowinVer As String, _
                                           ByRef ltypLotCfThrowin As LotCfThrowin, _
                                           ByRef lstrGuidMsg As String, _
                                           ByRef lstrGuidMsgCode As String) As Boolean
                                           
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "CFロット編成"
            pubblnLotCfThrowin_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotCfThrowin

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
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
                
                '@投入数
                If .strNum <> vbNullString Then
                    Call lrMsg.addString(CPstrNUM, .strNum)
                Else
                    Call lrMsg.addString(CPstrNUM, CPstrMsgNull)
                End If
                
                '@機種ID
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
                
                '@ｴﾝﾄﾘID
                If .strEntryID <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_ID, .strEntryID)
                Else
                    Call lrMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ担当者ID
                If .strTechManID <> vbNullString Then
                    Call lrMsg.addString(CPstrENG_EMP_ID, .strTechManID)
                Else
                    Call lrMsg.addString(CPstrENG_EMP_ID, CPstrMsgNull)
                End If
               
                '@装置ID(投入装置)
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@-----------------------
                '@　ﾊﾟﾚｯﾄﾏｯﾌﾟ
                '@-----------------------
                '@Aryﾒｯｾｰｼﾞ作成
                llngCnt = 0
                Do While .lngPaletteMapListCnt > llngCnt
                
                    '@ﾊﾟﾚｯﾄIDが設定されているﾃﾞｰﾀを対象
                    If .typPaletteMapList(llngCnt).strPaletteID <> vbNullString Then
                        
                        Call ltMsg.addString(CPstrSLOT_POSITION, .typPaletteMapList(llngCnt).strSlotPositon)            'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        Call ltMsg.addString(CPstrPALETTE_ID, .typPaletteMapList(llngCnt).strPaletteID)                 'ﾊﾟﾚｯﾄID
                        Call ltMsg.addString(CPstrCHIP_COUNT, .typPaletteMapList(llngCnt).strChipCount)                 'ﾁｯﾌﾟ数
                        Call ltMsg.addString(CPstrLOT_ID, .typPaletteMapList(llngCnt).strLotID)                         'ﾛｯﾄID

                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    End If
                
                    llngCnt = llngCnt + 1
                Loop
                
                Call lrMsg.addMsgAry(CPstrPALETTE_MAP_LIST, lrAry)
                lrAry.Clear
            End With
           
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_cfthrowinVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_cfthrowinVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cfthrowin, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_ID, ltypLotCfThrowin.strRetrunLotID)  '投入ﾛｯﾄID
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                         'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotCfThrowin_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_cfthrowinVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
            
        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function
End Module
