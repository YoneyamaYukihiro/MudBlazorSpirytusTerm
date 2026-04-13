'ﾌｧｲﾙ名：xxMG02L0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：GRB属性設定 標準モジュール
'作成日：2016/02/11 (Thu) 23:11:27 H.Hayashi
'更新日：
'備　考：
'ﾃｷｽﾄ&ｽｸﾛｰﾙﾎﾞﾀﾝ制御
'親画面連携
'ｶﾞｲﾀﾞﾝｽ表示
'Copyright(C) SEIKO EPSON CORPORATION 2016-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02L0
    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '======================================Public===========================================

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '=========================================Public=========================================
    '****************************************************************************************
    '                                      *ＡＰＩの記述*
    '****************************************************************************************
    '=========================================Public=========================================

    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
        
    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '=========================================Public=========================================

    '関数名：pubblnwfGrp_Set
    '機　能：GRB属性設定
    '引　数：lstrwf__grbset_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltyprWfGrbSet     ：不良保留払出傾向登録構造体
    '　　　：lstrResult         ：結果
    '戻り値：True：成功、False：失敗
    '作成日：2016/02/07 (Sun) 20:35:08 H.Hayashi
    '更新日：
    '備　考：
    Public Function pubblnwfGrp_Set(ByVal lstrwf__grbset_Ver As String, _
                                         ByRef ltyprWfGrbSet As LotInsprst, _
                                         ByRef lstrResult As String) As Boolean

        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry           As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg           As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET         As String           '応答取得
        Dim llngCnt         As Integer          'ｶｳﾝﾄ
            
        Try

            pstrMessageName = "GRB属性設定"
            pubblnwfGrp_Set = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾒｯｾｰｼﾞ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrwf__grbset_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrwf__grbset_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            With ltyprWfGrbSet
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@-----------------------
                '@ WF毎の不良情報ｾｯﾄ
                '@-----------------------
                llngCnt = 1
                
                Do While ltyprWfGrbSet.lngListCnt >= llngCnt
                    
                    With .typWfList(llngCnt - 1)
                        
                        If .strWfId <> vbNullString Then
                            Call ltMsg.addString(CPstrWF_ID, .strWfId)                      'WFID
                        Else
                            Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                        End If

                        If .strClassID <> vbNullString Then
                            Call ltMsg.addString(CPstrGRB_CLASS, .strClassID)               'GRB区分
                        Else
                            Call ltMsg.addString(CPstrGRB_CLASS, CPstrMsgNull)
                        End If

                        llngCnt = llngCnt + 1
                        
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    End With
                Loop
                
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)                                   'WFﾘｽﾄ追加
                lrAry.Clear
                
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEngEmpId)                         '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           'LOT最終更新日時
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrwf__grbset__, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@結果
                    Call laMsg.getString(CPstrRESULT, lstrResult)
                    '@最終更新日時書き換え(連続して登録する場合の対策)
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, ptypLotprestate.strLotLastUpdate)
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnwfGrp_Set = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrwf__grbset_Ver)


                '@〓 その他 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
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

            '@=======================
            '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
            '@=======================
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

End Module
