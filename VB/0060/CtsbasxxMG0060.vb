'ﾌｧｲﾙ名：xxMG0060.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：「作業終了」機能ﾒｯｾｰｼﾞ処理
'作成日：2004/02/26 (Thu) 13:52:09 T.Oide
'更新日：2008/02/29 (Fri) 14:57:32 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0060
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnLotRecitemList_Sel
    '機　能：品質記録情報入力項目取得
    '　　　：lstrlot_recitemlistVer ：Msgﾊﾞｰｼﾞｮﾝ
    '引　数：lstrClassDivision      ：処理区分
    '　　　：ltypMasInputQty        ：記録情報格納
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/10 (Wed) 15:36:00 T.Oide
    '更新日：2004/06/10 (Thu) 08:54:16 S.Deguchi
    '備　考：
    Public Function pubblnLotRecitemList_Sel(ByVal lstrlot_recitemlistVer As String, _
                                             ByRef lstrClassDivision As String, _
                                             ByRef ltypMasInputQty As MasInputQty) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "品質記録情報入力項目取得"
            pubblnLotRecitemList_Sel = False
            
            '@記録必須ﾌﾗｸﾞ初期化
            pblnHisuInputAri = False    '必須項目あり/なし
            pblnHisuInput = False       '必須項目入力/未入力
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg

            lstrRET = ""

            'NSYS リストの初期化
            If ltypMasInputQty.typQuarityData Is Nothing Then
                ltypMasInputQty.typQuarityData = New List(Of QuarityData)()
            Else
                ltypMasInputQty.typQuarityData.Clear()
            End If
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypMasInputQty
                '@処理区分
                If lstrClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@大工程ID
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                '@小工程ID
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                '@SB_ID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrlot_recitemlistVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_recitemlistVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_recitemlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@最終更新日時を取得
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, ltypMasInputQty.strLstUpDate)
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrQUALITY_LIST, laAry)
                    
                    ltypMasInputQty.lngListCnt = laAry.Count
                    
                   '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypMasInputQty.lngListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim tmp As QuarityData  = New QuarityData()
                             With tmp 
                                Call ltMsg.getString(CPstrPARAMETER_ID, .strParameterCode)          '品質記録入力項目ID
                                Call ltMsg.getString(CPstrPARAMETER_NAME, .strParameterName)        '品質記録入力項目名
                                Call ltMsg.getString(CPstrDATA_TYPE_ID, .strDataTypeID)             '品質記録入力項目ﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrDATA, .strData)                           'データ
                                Call ltMsg.getString(CPstrUNIT, .strUnit)                           '単位
                                Call ltMsg.getString(CPstrSTD_UPPER, .strSTDUpper)                  '規格上限
                                Call ltMsg.getString(CPstrSTD_MIDDLE, .strSTDMiddle)                '規格中央
                                Call ltMsg.getString(CPstrSTD_LOWER, .strSTDLower)                  '規格下限
                                Call ltMsg.getString(CPstrREQUIRE_FLAG, .strRequirefFG)             '必須ﾌﾗｸﾞ
                                '@必須項目がある場合は、必須項目が入力されないと作業終了できない
                                If .strRequirefFG = 1 Then
                                    pblnHisuInputAri = True     '必須項目あり
                                    pblnHisuInput = False       '必須項目がまだ入力されていない
                                End If
                            End With
                            'NSYS リストに追加
                            ltypMasInputQty.typQuarityData.Add(tmp)
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotRecitemList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_recitemlistVer)
                    
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
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnLotWrkend_Upd
    '機　能：ロット作業終了
    '引　数：lstrlot_wrkendVer      ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotwrkend          ：作業終了情報格納
    '　　　：lstrActionFlag         ：ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
    '　　　：lstrResultReworkState  ：特殊状態(3桁で制御
    '　　　　　　　　　　　　　　　　　　　　　　　百の位；0特殊無し　1；部分特殊　2;全数特殊
    '　　　　　　　　　　　　　　　　　　　　　　　十の位；0；分割元の次工程無し　1；分割元の次工程あり
    '　　　　　　　　　　　　　　　　　　　　　　　一の位；0；分割先の次工程無し　1；分割先の次工程あり)
    '　　　：lstrClassDivision      ：処理区分
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '　　　：lstrMoveResul          ：移載状態(0：移載なし、1：移載前、2：移載完了)
    '　　　：ltypLotCfkiMoveAns     ：CFKI作業終了入力応答ﾃﾞｰﾀ構造体
    '　　　：lstrToCarrierID        ：特殊分割元ｷｬﾘｱID
    '　　　：lstrTftHoldFlag        ：TFT
    '戻り値：
    '作成日：2004/09/20 (Mon) 09:29:34 M.Miura
    '更新日：2007/06/19 (Tue) 13:47:27 N.Kasai
    '備　考：
    '　　　：2004/09/01 (Wed) 09:09:33 M.Miura　    特殊状態を引数と受信に追加
    '　　　：2004/09/16 (Thu) 14:07:34 Y.Yamagishi　処理区分追加
    '　　　：2004/09/20 (Mon) 09:31:33 M.Miura　    引数と受信結果に移載状態を追加
    '　　　：2004/10/19 (Tue) 10:45:41 S.Deguchi    「追加流動」処理追加対応
    '　　　：2004/10/20 (Wed) 11:26:06 M.Miura　    引数と受信結果に移載機先ｷｬﾘｱIDを追加
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/05/30 (Mon) 09:47:37 N.Kojima     応答にFTP_RESULT追加(改善№625対応漏れ)
    '　　　：2005/09/07 (Wed) 10:34:21 N.Kasai      応答ﾀｸﾞ追加(TFT_HOLD_FLAG)
    '　　　：2006/11/07 (Tue) 10:56:48 M.Miura      引数と応答ﾀｸﾞ追加(EXCP/NORMAL_HOLD_FLAG)(案件№01437)
    '　　　：2007/06/19 (Tue) 13:47:27 N.Kasai      応答ﾀｸﾞFTP_RESULT削除(№01975)
    Public Function pubblnLotWrkend_Upd(ByVal lstrlot_wrkendVer As String, _
                                        ByRef ltypLotwrkend As LotwrkEnd, _
                                        ByRef lstrActionFlag As String, _
                                        ByRef lstrFoldFlag As String, _
                                        ByRef lstrResultReworkState As String, _
                                        ByVal lstrClassDivision As String, _
                                        ByRef lstrGuidMsg As String, _
                                        ByRef lstrGuidMsgCode As String, _
                                        ByRef lstrTftHoldFlag As String, _
                                        ByRef lstrExcpHoldFlag As String, _
                                        ByRef lstrNormalHoldFlag As String, _
                                        ByRef ltypLotCfkiMoveAns As LotCfkiMoveAns, _
                                        Optional ByRef lstrMoveResult As String= vbNullString, _
                                        Optional ByRef lstrToCarrierID As String= vbNullString) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        
        Try
            
            pstrMessageName = "ロット作業終了"
            pubblnLotWrkend_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            lstrRET = ""

            
            'NSYS リストの初期化
            If ltypLotCfkiMoveAns.typTPLotList Is Nothing Then
                ltypLotCfkiMoveAns.typTPLotList = New List(Of TpLotList)
            Else
                ltypLotCfkiMoveAns.typTPLotList.Clear()
            End If 
            
            With ltypLotwrkend
                '@送信ﾒｯｾｰｼﾞ作成
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@大工程ID
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                '@小工程ID
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEngEmpId)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@ｺﾒﾝﾄ
                If .strComment <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComment)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
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
                If lstrlot_wrkendVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_wrkendVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@処理区分
                If lstrClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
            End With
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_wrkend, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, ltypLotwrkend.strLotLastUpdate)  '最終更新時間(連続して次工程送出ﾒｯｾｰｼﾞを投げるため)
                    Call laMsg.getString(CPstrACTION_FLAG, lstrActionFlag)                      'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ
                    Call laMsg.getString(CPstrRESULT_REWORK_STATE, lstrResultReworkState)       '特殊状態
                    Call laMsg.getString(CPstrLOT_ID, ltypLotwrkend.strLotID)                   'ﾛｯﾄID(通常は要求時と同じ、特殊最終時にﾛｯﾄIDが変わる)
                    Call laMsg.getString(CPstrELECT_HOLD_FLAG, lstrFoldFlag)                    '保留ﾌﾗｸﾞ
                    Call laMsg.getString(CPstrMOVE_RESULT, lstrMoveResult)                      '移載状態
                    Call laMsg.getString(CPstrTO_CARRIER_ID, lstrToCarrierID)                   '移載機先ｷｬﾘｱID
                    Call laMsg.getString(CPstrTFT_HOLD_FLAG, lstrTftHoldFlag)                   'TFT保留ﾌﾗｸﾞ
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                                 'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                        'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    Call laMsg.getString(CPstrEXCP_HOLD_FLAG, lstrExcpHoldFlag)                 '異常処理票保留ﾌﾗｸﾞ
                    Call laMsg.getString(CPstrNORMAL_HOLD_FLAG, lstrNormalHoldFlag)             '保留ﾌﾗｸﾞ

        '@↓2009/07/27 (Mon) 15:39:22 Y.Yoneyama **************************************************
                    '@受信結果取得
                    With ltypLotCfkiMoveAns
                        Call laMsg.getMsgAry(CPstrTP_LOT_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngTpLotListCnt = laAry.Count
                        If .lngTpLotListCnt > 0 Then
                            For Each ltMsg In laAry
                              Dim tmp As TpLotList = New TpLotList()
                                '@受信結果取得
                                With tmp
                                    Call ltMsg.getString(CPstrTP_LOT_ID, .strTpLotID)       'TPALﾛｯﾄID
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)    '移載先ｷｬﾘｱID
                                End With
                                ltypLotCfkiMoveAns.typTPLotList.Add(tmp)
                            Next
                        End If
                    End With
        '@↑2009/07/27 (Mon) 15:39:22 Y.Yoneyama **************************************************
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotWrkend_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_wrkendVer)
                    
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
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnFtpRegCollect_Sel
    '機　能：FTP収集要求
    '引　数：lstrftp_regcollectVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypFtpRegcollect      ：送信ﾃﾞｰﾀ格納構造体
    '戻り値：True：成功、False：失敗
    '作成日：2005/12/22 (Thu) 11:56:52 N.Kojima
    '更新日：2005/12/22 (Thu) 11:56:52
    '備　考：
    Public Function pubblnFtpRegCollect_Sel(ByVal lstrftp_regcollectVer As String, _
                                            ByRef ltypFtpRegcollect As FtpRegCollect) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "FTP収集要求"
            pubblnFtpRegCollect_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            lstrRET = ""

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypFtpRegcollect
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrftp_regcollectVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrftp_regcollectVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@SB_ID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
                '@WP_ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If

                'WF_ID
                If .strWfId <> vbNullString Then
                    Call lrMsg.addString(CPstrWF_ID, .strWfId)
                Else
                    Call lrMsg.addString(CPstrWF_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrftp_regcollect, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnFtpRegCollect_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrftp_regcollectVer)
                    
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
                
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
                
        End Try
    End Function

    '関数名：pubblnEqftSyncRegist_Upd
    '機　能：ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録
    '引　数：ltypEqftSyncregistReq  ：要求ﾃﾞｰﾀ格納
    '　　　：lstrFTPResult          ：FTP送信結果
    '戻り値：True：成功、False：失敗
    '作成日：2007/06/19 (Tue) 14:26:00 N.Kasai
    '更新日：2008/02/25 (Mon) 16:55:52 M.Koni
    '備　考：
    '　　　：2008/02/25 (Mon) 16:56:04 M.Koni       Environ関数の型変換対応(不具合No.02510)
    Public Function pubblnEqftSyncRegist_Upd(ByRef ltypEqftSyncregistReq As EqftSyncregistReq, ByRef lstrFTPResult As String) As Boolean

        Dim lrMsg                   As TfMsg                    '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg                   As TfMsg                    '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg                   As TfMsg                    '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET                 As String                   '応答取得
        Dim llngCnt                 As Integer                  'ｶｳﾝﾄ用
        Dim lrAry                   As TfMsgAry                 '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltypOnErrorInfoLog      As CommonOnErrorInfoLog     'ｴﾗｰﾛｸﾞ情報

        
        Try
            
            pstrMessageName = "ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録"
            
            pubblnEqftSyncRegist_Upd = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypEqftSyncregistReq
                '@送信ﾒｯｾｰｼﾞ作成
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                              'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)                                  '装置ID
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                                  'ｼｽﾃﾑﾌﾞﾛｯｸ
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                If .strWorkStartTime <> vbNullString Then
                    Call lrMsg.addString(CPstrWORK_START_TIME, .strWorkStartTime)               '作業開始日時
                Else
                    Call lrMsg.addString(CPstrWORK_START_TIME, CPstrMsgNull)
                End If
                
                '@WFﾘｽﾄ
                For llngCnt = 0 To ltypEqftSyncregistReq.lngEqftWfListCnt-1 
                    If .typEqftWfList(llngCnt).strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, .typEqftWfList(llngCnt).strWfId)       'WFID
                    Else
                        Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                    End If
                    If .typEqftWfList(llngCnt).strSlotNo <> vbNullString Then
                        Call ltMsg.addString(CPstrSLOT_NO, .typEqftWfList(llngCnt).strSlotNo)   'ｽﾛｯﾄ№
                    Else
                        Call ltMsg.addString(CPstrSLOT_NO, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt
                
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
                lrAry.Clear
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreqftsyncregist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@結果
                    Call laMsg.getString(CPstrRESULT, lstrFTPResult)   'FTP送信結果

                    '@関数の処理結果(成功)格納
                    pubblnEqftSyncRegist_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypEqftSyncregistReq.strMsgVer)
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

            
            '@ﾛｸﾞ出力
            With ltypOnErrorInfoLog
                '@ｴﾗｰﾛｸﾞ情報を設定する
                .strDate = Format$(Today(), CPstrDateTimeYMD)                                         '日付
                .strTime = Format$(Now(), CPstrDateFormatHMS)                                         '時刻
                .strComputerName = pstrComputerName                                                   '端末名
                .strIPaddress = pstrIpAddress                                                         'IPｱﾄﾞﾚｽ
                .strUserID = StrConv(Environ(CPstrEnvironUserName), vbLowerCase + vbNarrow)           'ﾕｰｻﾞｰID
                .strSbID = pstrSBID                                                                   'SBID
                .strTestStatus = pstrTestStatus                                                       'ﾃｽﾄｽﾃｰﾀｽ
                .strTerminalMode = pstrTerminalMode                                                   '端末区分
                .lngErrNumber = Hex(Err.Number)                                                       'ｴﾗｰ№(16進に変換)
                .strErrDescription = Err.Description                                                  'ｴﾗｰ説明
                .strMenuKey = "EN0060"                                                                '機能ID
                .strProcName = "pubblnEqftSyncRegist_Upd"                                             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrDetail = "pubblnEqftSyncRegist_Upd"                                            'ｴﾗｰ発生箇所
                .strErrMessage = "ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録【通信エラー】"                                 'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ﾛｸﾞ出力
            Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
            
        End Try
    End Function

End Module
