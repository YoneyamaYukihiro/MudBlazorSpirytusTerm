'ﾌｧｲﾙ名：xxMG00Z0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾚﾁｸﾙ管理 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/08/24 (Tue) 11:36:27 Y.Yamagishi
'更新日：2004/08/24 (Tue) 11:36:27
'備　考：2004/09/14 (Tue) 09:35:45 S.Deguchi Error_HandlerのｴﾗｰﾒｯｾｰｼﾞをpubErrMsg_Proc関数へ変更
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00Z0
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnMasRtclCodeList_Sel
    '機　能：ﾚﾁｸﾙ型番取得
    '引　数：lstrmas_rtclcodelistVer：ﾊﾞｰｼﾞｮﾝ
    '　　　：ltypRtclCodeList：取得結果格納構造体
    '　　　：llngRtclCodeListCnt：ｶｳﾝﾄ
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/24 (Tue) 11:36:27 Y.Yamagishi
    '更新日：2004/08/24 (Tue) 11:36:27
    '備　考：
    Public Function pubblnMasRtclCodeList_Sel(ByVal lstrmas_rtclcodelistVer As String, ByRef ltypRtclCodeList As List(Of RtclCodeList), _
                                              ByRef llngRtclCodeListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try

            pstrMessageName = "レチクル型番取得"
            pubblnMasRtclCodeList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                          'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrmas_rtclcodelistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_rtclcodelistVer)        'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_rtclcodelist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@ｱﾚｰ取得
                    Call laMsg.getMsgAry(CPstrRETICLE_CODE_LIST, laAry)
                    '@要素数格納
                    llngRtclCodeListCnt = laAry.Count
                    '@要素数が0以外ならﾃﾞｰﾀ格納
                    If llngRtclCodeListCnt <> 0 Then
                        if ltypRtclCodeList Is Nothing 
                            ltypRtclCodeList = New List(Of RtclCodeList) 
                        Else 
                            ltypRtclCodeList.Clear()
                        End If

                        'NSYS　要素数分構造体配列作成
                        Do While ltypRtclCodeList.Count -1 < llngRtclCodeListCnt -1
                            ltypRtclCodeList.Add(New RtclCodeList)
                        Loop
                        Dim ltypRtclCodeListTmp As RtclCodeList = New RtclCodeList

                        llngCnt = 0
                        For Each ltMsg In laAry
                            With ltypRtclCodeListTmp
                                Call ltMsg.getString(CPstrRETICLE_PD_CODE, ltypRtclCodeListTmp.lstrReticlePdCode)             '機種ｺｰﾄﾞ
                                Call ltMsg.getString(CPstrRETICLE_MASKPATTERN, ltypRtclCodeListTmp.lstrReticleMaskpattern)    'ﾏｽｸﾊﾟﾀｰﾝ
                                Call ltMsg.getString(CPstrRETICLE_NAME, ltypRtclCodeListTmp.lstrReticleName)                  'ﾚﾁｸﾙ型番
                                llngCnt = llngCnt + 1
                                ltypRtclCodeList(llngCnt-1) = ltypRtclCodeListTmp
                            End With
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnMasRtclCodeList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_rtclcodelistVer)
                    
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
            laAry = Nothing
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing

        End Try
    End Function

    '関数名：pubblnReticleID_Ins
    '機　能：ﾚﾁｸﾙ登録
    '引　数：ltypRtclRegist：ﾚﾁｸﾙ登録情報
    '戻り値：：True:成功/False:失敗
    '作成日：2004/08/25 (Wed) 14:53:20 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 14:53:20
    '備　考：
    Public Function pubblnReticleID_Ins(ByRef ltypRtclRegist As RtclRegist) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "レチクル登録"
            pubblnReticleID_Ins = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypRtclRegist
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                  'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)              'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strReticleID <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_ID, .strReticleID)        'ﾚﾁｸﾙID
                Else
                    Call lrMsg.addString(CPstrRETICLE_ID, CPstrMsgNull)
                End If
                If .strArriveTime <> vbNullString Then
                    Call lrMsg.addString(CPstrARRIVE_TIME, .strArriveTime)      '入荷日
                Else
                    Call lrMsg.addString(CPstrARRIVE_TIME, CPstrMsgNull)
                End If
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                If .strReticleName <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_NAME, .strReticleName)    'ﾚﾁｸﾙ型番
                Else
                    Call lrMsg.addString(CPstrRETICLE_NAME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_rtclregist__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnReticleID_Ins = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypRtclRegist.strMsgVer)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '@↓2005/05/30 (Mon) 12:33:54 N.Kasai **************************************************削除
    ''関数名：pubblnrtclchgposition_Upd
    ''機　能：ﾚﾁｸﾙ位置変更
    ''引　数：lstrrtclchgpositionVer：Msgﾊﾞｰｼﾞｮﾝ
    ''　　　：lstrReticleID：ﾚﾁｸﾙID
    ''　　　：lstrSmifID：SMIFID
    ''戻り値：True:成功/False:失敗
    ''作成日：2004/08/26 (Thu) 11:53:08 Y.Yamagishi
    ''更新日：2004/08/26 (Thu) 11:53:08
    ''備　考：
    'Public Function pubblnrtclchgposition_Upd(ByVal lstrrtclchgpositionVer As String, ByVal lstrReticleID As String, _
    '                                            ByVal lstrSmifID As String, ByVal lstrEditTime As String, ByVal lstrClassDivision) As Boolean
    '
    '    Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
    '    Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
    '    Dim lstrRET             As String           '応答取得
    '    Dim lstrErrMsg          As String           'ｴﾗｰ用
    '    Dim lstrMSG             As String           'ﾒｯｾｰｼﾞ内容格納
    '
    '    On Error GoTo Error_Handler
    '
    '    pstrMessageName = "レチクル位置変更"
    '    pubblnrtclchgposition_Upd = False
    '
    '    Set lrMsg = New TfMsg
    '    Set laMsg = New TfMsg
    '
    '    '@送信ﾒｯｾｰｼﾞ作成
    '    If pstrSBID <> vbNullString Then
    '        Call lrMsg.addString(CPstrSB_ID, pstrSBID)                      'SB_ID
    '    Else
    '        Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
    '    End If
    '    If lstrrtclchgpositionVer <> vbNullString Then
    '        Call lrMsg.addString(CPstrMSG_VER, lstrrtclchgpositionVer)      'Msgﾊﾞｰｼﾞｮﾝ
    '    Else
    '        Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
    '    End If
    '    If lstrReticleID <> vbNullString Then
    '        Call lrMsg.addString(CPstrRETICLE_ID, lstrReticleID)            'ﾚﾁｸﾙID
    '    Else
    '        Call lrMsg.addString(CPstrRETICLE_ID, CPstrMsgNull)
    '    End If
    '    If lstrSmifID <> vbNullString Then
    '        Call lrMsg.addString(CPstrSMIF_ID, lstrSmifID)                  'SMIFID
    '    Else
    '        Call lrMsg.addString(CPstrSMIF_ID, CPstrMsgNull)
    '    End If
    '    If pstrUserID <> vbNullString Then
    '        Call lrMsg.addString(CPstrEMP_ID, pstrUserID)                   '作業者ID
    '    Else
    '        Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
    '    End If
    '    If lstrEditTime <> vbNullString Then
    '        Call lrMsg.addString(CPstrEDIT_TIME, lstrEditTime)              '最終更新日
    '    Else
    '        Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
    '    End If
    '    If lstrClassDivision <> vbNullString Then
    '        Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
    '    Else
    '        Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
    '    End If
    '    '@ﾒｯｾｰｼﾞ送信
    '    Call pTerm.sendRequest(CPstrrtclchgposition, lrMsg, laMsg)
    '
    '    '@受信結果取得
    '    Call laMsg.getString(CPstrRET, lstrRET)
    '
    '    '@結果判定
    '    Select Case lstrRET
    '        '@成功の場合(true)
    '        Case CPstrTRUE
    '
    '            '@関数の処理結果(成功)格納
    '            pubblnrtclchgposition_Upd = True
    '
    '        '@失敗の場合(false)
    '        Case CPstrFALSE
    '
    '            '@ﾊﾞｰｼﾞｮﾝ判定
    '            Call pubstrErrMsg_Set(laMsg, lstrrtclchgpositionVer)
    '
    '        '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
    '        Case Else
    '            '@表示ﾒｯｾｰｼﾞ変換
    '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
    '
    '            '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
    '            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
    '    End Select
    '
    '    '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
    '    Set lrMsg = Nothing
    '    Set laMsg = Nothing
    '
    '    Exit Function
    '
    ''@例外処理
    'Error_Handler:
    '
    '    '@表示ﾒｯｾｰｼﾞ変換
    '    Call pubErrMsg_Proc(Err)
    '
    '    '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
    '    Set lrMsg = Nothing
    '    Set laMsg = Nothing
    '
    'End Function
    '@↑2005/05/30 (Mon) 12:33:54 N.Kasai **************************************************削除

    '関数名：pubblnReticleErrSet_Ins
    '機　能：ﾚﾁｸﾙｴﾗｰ設定
    '引　数：ltypRtclErrSet：ﾚﾁｸﾙｴﾗｰ情報
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/26 (Thu) 15:08:53 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 15:08:53
    '備　考：
    Public Function pubblnReticleErrSet_Ins(ByRef ltypRtclErrSet As RtclErrSet) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "レチクルエラー設定"
            pubblnReticleErrSet_Ins = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypRtclErrSet
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                      'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                  'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strClassDivison <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivison)     '処理区分
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                If .strReticleID <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_ID, .strReticleID)            'ﾚﾁｸﾙID
                Else
                    Call lrMsg.addString(CPstrRETICLE_ID, CPstrMsgNull)
                End If
                If .strReasonCode <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_CODE, .strReasonCode)          'ｴﾗｰ理由
                Else
                    Call lrMsg.addString(CPstrREASON_CODE, CPstrMsgNull)
                End If
                If .strReasonComments <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_COMMENTS, .strReasonComments)  'ｴﾗｰｺﾒﾝﾄ
                Else
                    Call lrMsg.addString(CPstrREASON_COMMENTS, CPstrMsgNull)
                End If
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                    '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)              '最終更新日
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrrtclerrset__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnReticleErrSet_Ins = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypRtclErrSet.strMsgVer)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnReticleChgStatus_Ins
    '機　能：ﾚﾁｸﾙ状態変更
    '引　数：ltypRtclChgState：ﾚﾁｸﾙ状態変更情報
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/26 (Thu) 17:33:08 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 17:33:08
    '備　考：
    Public Function pubblnReticleChgStatus_Ins(ByRef ltypRtclChgState As RtclChgState) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "レチクル状態変更"
            pubblnReticleChgStatus_Ins = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypRtclChgState
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                                              'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                                          'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strClassDivison <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivison)                             '処理区分
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                If .strReticleID <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_ID, .strReticleID)                                    'ﾚﾁｸﾙID
                Else
                    Call lrMsg.addString(CPstrRETICLE_ID, CPstrMsgNull)
                End If
                If .strReticleStatusItemName <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_STATUS_ITEM_NAME, .strReticleStatusItemName)          'ﾚﾁｸﾙ状態項目名
                Else
                    Call lrMsg.addString(CPstrRETICLE_STATUS_ITEM_NAME, CPstrMsgNull)
                End If
                If .strGarbageInspection <> vbNullString Then
                    Call lrMsg.addString(CPstrGARBAGE_INSPECTION, .strGarbageInspection)                    'ﾚﾁｸﾙｺﾞﾐ検査
                Else
                    Call lrMsg.addString(CPstrGARBAGE_INSPECTION, CPstrMsgNull)
                End If
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                                            '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)                                      '最終更新日
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrrtclchgstat_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnReticleChgStatus_Ins = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypRtclChgState.strMsgVer)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnReticleDelete_Ins
    '機　能：ﾚﾁｸﾙ削除
    '引　数：ltypRtclChgState：ﾚﾁｸﾙ状態変更情報
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/26 (Thu) 18:07:49 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 18:07:49
    '備　考：
    Public Function pubblnReticleDelete_Ins(ByRef ltypRtclChgState As RtclChgState) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "レチクル削除"
            pubblnReticleDelete_Ins = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypRtclChgState
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                                              'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                                          'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strReticleID <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_ID, .strReticleID)                                    'ﾚﾁｸﾙID
                Else
                    Call lrMsg.addString(CPstrRETICLE_ID, CPstrMsgNull)
                End If
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                                            '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)                                      '最終更新日
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrrtcldelete__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnReticleDelete_Ins = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypRtclChgState.strMsgVer)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnrtclStaterep_Upd
    '機　能：ﾚﾁｸﾙ状態報告
    '引　数：ltypRtclStaterep_Rec：ﾚﾁｸﾙ状態報告要求格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/05/30 (Mon) 10:20:04 N.Kasai
    '更新日：2005/05/30 (Mon) 10:20:04
    '備　考：(rtcl.chgposition、eq__.reticlestat)ﾒｯｾｰｼﾞ統合
    Public Function pubblnrtclStaterep_Upd(ByRef ltypRtclStaterep_Rec As RtclStaterep_Rec) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          '汎用ｶｳﾝﾄ
        
        
        Try

            pstrMessageName = "レチクル状態報告"
            pubblnrtclStaterep_Upd = False
            
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypRtclStaterep_Rec
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@処理区分("01":ｸﾗｲｱﾝﾄ指定、"ZZ":装置(全自動)指定、"FF":搬送（ﾊﾞｰｺｰﾄﾞﾘｰﾀﾞｰ）指定)
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                '@ｵﾝﾗｲﾝﾌﾗｸﾞ(1:装置ｵﾝﾗｲﾝ時、0:装置稼動中／ｸﾗｲｱﾝﾄ　※処理区分:"FF"時はNULL)
                If .strOnlineFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrONLINE_FLAG, .strOnlineFlag)
                Else
                    Call lrMsg.addString(CPstrONLINE_FLAG, CPstrMsgNull)
                End If
                '@WPID(処理区分："ZZ"のみ値を設定※処理区分:"FF"時はNULL)
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
            
                '@装置内ﾚﾁｸﾙﾘｽﾄ
                llngCnt = 0
                If .lngRtclStatereplist > 0 Then
                    Do While .typRtclStatereplist.Count-1 >= llngCnt
                        '@ﾚﾁｸﾙID
                        If .typRtclStatereplist(llngCnt).strReticleID <> vbNullString Then
                            Call ltMsg.addString(CPstrRETICLE_ID, .typRtclStatereplist(llngCnt).strReticleID)
                        Else
                            Call ltMsg.addString(CPstrRETICLE_ID, CPstrMsgNull)
                        End If
                        '@ﾚﾁｸﾙ状態ID
                        If .typRtclStatereplist(llngCnt).strReticleStatusItemID <> vbNullString Then
                            Call ltMsg.addString(CPstrRETICLE_STATUS_ITEM_ID, .typRtclStatereplist(llngCnt).strReticleStatusItemID)
                        Else
                            Call ltMsg.addString(CPstrRETICLE_STATUS_ITEM_ID, CPstrMsgNull)
                        End If
                        '@現在位置ID
                        If .typRtclStatereplist(llngCnt).strCurrentPositionID <> vbNullString Then
                            Call ltMsg.addString(CPstrCURRENT_POSITION_ID, .typRtclStatereplist(llngCnt).strCurrentPositionID)
                        Else
                            Call ltMsg.addString(CPstrCURRENT_POSITION_ID, CPstrMsgNull)
                        End If
                        '@SMIFID
                        If .typRtclStatereplist(llngCnt).strSmifID <> vbNullString Then
                            Call ltMsg.addString(CPstrSMIF_ID, .typRtclStatereplist(llngCnt).strSmifID)
                        Else
                            Call ltMsg.addString(CPstrSMIF_ID, CPstrMsgNull)
                        End If
                        '@最終更新日時
                        If .typRtclStatereplist(llngCnt).strEditTime <> vbNullString Then
                            Call ltMsg.addString(CPstrEDIT_TIME, .typRtclStatereplist(llngCnt).strEditTime)
                        Else
                            Call ltMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                        End If
                        
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                        llngCnt = llngCnt + 1
                    Loop
                Else
                    ltMsg.Clear
                End If
            
                Call lrMsg.addMsgAry(CPstrRETICLE_LIST, lrAry)
                lrAry.Clear
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrrtclstaterep, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
            
                        '@関数の処理結果(成功)格納
                        pubblnrtclStaterep_Upd = True
            
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            ltMsg = Nothing
            lrAry = Nothing
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            ltMsg = Nothing
            lrAry = Nothing
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function


End Module
