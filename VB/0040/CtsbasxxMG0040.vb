'ﾌｧｲﾙ名：xxMG0040.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾛｯﾄ投入（基板）通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/02/27 (Fri) 16:16:39 M.Miura
'更新日：2005/04/01 (Fri) 09:09:38 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0040
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnLotThrowin_Sel
    '機　能：ロット編成(保留/払出WF)
    '引　数：lstrlot_throwin_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotThrowin：編成内容格納
    '　　　：llngWFCnt：編成するWFの数格納
    '　　　：lstrGuidMsg：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/04 (Thu) 11:28:08 M.Miura
    '更新日：2007/07/26 (Thu) 14:10:46 N.Kasai
    '備　考：2005/03/14 (Mon) 16:35:58 N.Kojima     投入装置追加に伴い、要求に"WP_ID"追加(改善№577)
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2007/07/26 (Thu) 14:10:46 N.Kasai      ｿｰｽ整備
    Public Function pubblnLotThrowin_Sel(ByRef ltypLotThrowin As LotThrowin, _
                                         ByVal llngWFcnt As Integer, _
                                         ByRef lstrGuidMsg As String, _
                                         ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'カウント
        
        Try

            pstrMessageName = "投入要求"
            pubblnLotThrowin_Sel = False
            
            lrMsg = New TfMsg()
            lrAry = New TfMsgAry()
            ltMsg = New TfMsg()
            laMsg = New TfMsg()
            
            With ltypLotThrowin
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
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
                '@SB_ID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@WFMAP情報ﾒｯｾｰｼﾞ作成
                llngCnt = 0
                Do While llngWFcnt > llngCnt
                
                    '@在庫ﾛｯﾄID
                    If .typWFMapList(llngCnt).strInvLotId <> vbNullString Then
                        Call ltMsg.addString(CPstrINV_LOT_ID, .typWFMapList(llngCnt).strInvLotId)
                    Else
                        Call ltMsg.addString(CPstrINV_LOT_ID, CPstrMsgNull)
                    End If
                
                    Call ltMsg.addString(CPstrSLOT_POSITION, .typWFMapList(llngCnt).strSlotNo)            'ｽﾛｯﾄ№
                    
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear()
                    llngCnt = llngCnt + 1
                Loop
                Call lrMsg.addMsgAry(CPstrWF_MAP_LIST, lrAry)
                lrAry.Clear
                
                '@優先度
                If .strLotPriority <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_PRIORITY, .strLotPriority)
                Else
                    Call lrMsg.addString(CPstrLOT_PRIORITY, CPstrMsgNull)
                End If
                '@ｵﾝﾗｲﾝﾌﾗｸﾞ
                If .strOnlineFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrONLINE_FLAG, .strOnlineFlag)
                Else
                    Call lrMsg.addString(CPstrONLINE_FLAG, CPstrMsgNull)
                End If
                '@装置ID(投入装置)
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_throwin_, lrMsg, laMsg)
            
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
                    pubblnLotThrowin_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypLotThrowin.strMsgVer)
                    
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
