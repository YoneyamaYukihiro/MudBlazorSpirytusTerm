'ﾌｧｲﾙ名：xxMG02V0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Wafer治具セット機能共通ﾓｼﾞｭｰﾙ
'作成日：2009/06/09 (Tue) 13:05:10 K.Nishizawa
'更新日：2009/06/09 (Tue) 13:05:10
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02V0
    Public Const CPstrjigusecheck                 As String = "jig_.jusechk"
    Public Const CPstrjigjmaskset                 As String = "jig_.jmaskset"

    '@判定可否用Msg
    Public Structure jJigCheck
        Dim strSbID             As String                                   'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim strjigId            As String                                   '治具ID
        Dim strJJigCategory     As String                                   '蒸着治具カテゴリ
    End Structure




    '関数名：pubblnJycJigList_Sel
    '機　能：蒸着治具使用可否判定
    '引　数：lstrClassDivision  : 処理区分(CLASS_DIVISION)
    '      ：lstrJigUseChk_ver : Msgﾊﾞｰｼﾞｮﾝ(jig_.usecheck)
    '      ：lypJigChk : Msg送信用ｵﾌﾞｼﾞｪｸﾄ(JigCheck)
    '      ：lstrGudMsgCode : ﾒｯｾｰｼﾞ№
    '      ：lstrGuidMsg    : 返信ﾒｯｾｰｼﾞ
    '戻り値：True:成功/Flase：失敗
    '作成日：
    '更新日：
    '備　考：
    Public Function pubblnJJigUse_Check(ByVal lstrClassDivision As String, _
                                            ByVal lstrJJigUseChk_ver As String, _
                                            ByRef ltypJJigChk As jJigCheck, _
                                            ByRef lstrGuidMsgCode As String, _
                                            ByRef lstrGuidMsg As String _
                                            ) As Boolean

        Dim lrMsg           As TfMsg
        Dim laMsg           As TfMsg
        Dim lstrRET         As String

        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            

            pstrMessageName = "蒸着治具使用可否判断"
            
            pubblnJJigUse_Check = False
            
            With ltypJJigChk
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                If .strjigId <> vbNullString Then
                    Call lrMsg.addString(CPstrJIG_ID, .strjigId)
                Else
                    Call lrMsg.addString(CPstrJIG_ID, CPstrMsgNull)
                End If
                
                If .strJJigCategory <> vbNullString Then
                    Call lrMsg.addString(CPstrJ_JIG_CATEGORY, .strJJigCategory)
                Else
                    Call lrMsg.addString(CPstrJ_JIG_CATEGORY, CPstrMsgNull)
                End If
                
                If lstrClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                

            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjigusecheck, lrMsg, laMsg)
            
            '@結果受信
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                Case CPstrTRUE
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)
                    
                    pubblnJJigUse_Check = True
                    
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrJJigUseChk_ver)
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnJMaskSet_Ins
    '機　能：蒸着マスク組立
    '引　数：
    '戻り値：True:成功/Flase：失敗
    '作成日：
    '更新日：
    '備　考：
    Public Function pubblnJMaskSet_Ins(ByVal lstrJMaskSetMsg_Ver As String, _
                                    ByVal lstrJigStatus As String, _
									ByVal lstrJigEventId	As String , _
                                    ByRef ltypJMaskSetList As JMaskSetList) As Boolean

        Dim lrMsg               As TfMsg
        Dim lrMsg2              As TfMsg
        Dim lrAry               As TfMsgAry
        Dim laMsg               As TfMsg
        Dim lstrRET             As String
        Dim llngCnt             As Integer

        Try
            
            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            pstrMessageName = "蒸着マスク組立"
            
            pubblnJMaskSet_Ins = False
            
            With ltypJMaskSetList
                '@Msg_Ver取得
                If lstrJMaskSetMsg_Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrJMaskSetMsg_Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@治具ステータスは[使用可(組後)]をセット
                If lstrJigStatus <> vbNullString Then
                    Call lrMsg.addString(CPstrJIG_STATUS, lstrJigStatus)
                Else
                    Call lrMsg.addString(CPstrJIG_STATUS, CPstrMsgNull)
                End If
                '@治具イベントID（3:蒸着マスク組立）
                If lstrJigEventId <> vbNullString Then
                    Call lrMsg.addString(CPstrJIG_EVENT_ID, lstrJigEventId)
                Else
                    Call lrMsg.addString(CPstrJIG_EVENT_ID, CPstrMsgNull)
                End If
                '@作業者ID取得
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                For llngCnt = 0 To .lngtypJMaskSetCnt - 1
                    If .typJMaskSet(llngCnt).strGuideId <> vbNullString Then
                        Call lrMsg2.addString(CPstrGUIDE_ID, .typJMaskSet(llngCnt).strGuideId)
                    Else
                        Call lrMsg2.addString(CPstrGUIDE_ID, CPstrMsgNull)
                    End If
                    If .typJMaskSet(llngCnt).strMaskId <> vbNullString Then
                        Call lrMsg2.addString(CPstrMASK_ID, .typJMaskSet(llngCnt).strMaskId)
                    Else
                        Call lrMsg2.addString(CPstrMASK_ID, CPstrMsgNull)
                    End If
 
                    Call lrAry.Add(lrMsg2)
                    lrMsg2.Clear
                Next
                Call lrMsg.addMsgAry(CPstrJ_MASK_SET_LIST, lrAry)
                lrAry.Clear
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjigjmaskset, lrMsg, laMsg)
            
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                Case CPstrTRUE
                    pubblnJMaskSet_Ins = True
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrJMaskSetMsg_Ver)

                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)

                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing

            Exit Function
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
        End Try
    End Function
End Module
