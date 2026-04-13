'ﾌｧｲﾙ名：xxMG0070.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：処理開始用ﾒｯｾｰｼﾞ処理ﾓｼﾞｭｰﾙ
'作成日：2004/03/16 (Tue) 13:40:56 T.Oide
'更新日：2012/02/29 (Wed) 08:36:41 Y.Yoneyama
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG0070
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public==========================================
    '後でbasxxCM0010にマージ
    Public Const CPstrPLC_RECIPE_COMPARE_RESULT     As String = "PLC_RECIPE_COMPARE_RESULT"     'PLCﾚｼﾋﾟ照合結果
    '後でbasxxCM0020にマージ
    Public Const CPstrMsgWar0120    As String = "<TRM120W>$$PLCレシピ照合に失敗しました。$$装置レシピが異なりますので流動表レシピと確認してください｡"

    '関数名：pubblnMasWpPortList_Sel
    '機　能：装置のポート一覧を取得する
    '引　数：lstrmas_wpportlistVer：MSGﾊﾞｰｼﾞｮﾝ
    '      ：ltypLotequipmnt：装置情報を格納する構造体
    '      :lstrWPID：装置(WPID)
    '      :llngWPPortListCnt：ﾎﾟｰﾄﾘｽﾄｶｳﾝﾄ
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/16 (Tue) 18:10:16 T.Oide
    '更新日：2004/09/13 (Mon) 17:39:39 N.Kasai
    '備　考：
    Public Function pubblnMasWpPortList_Sel(ByVal lstrmas_wpportlistVer As String, ByVal lstrWpId As String, ByRef ltypWPPortList As List(Of LotWPPortList), _
                                            Optional ByRef llngWPPortListCnt As Integer = 0) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用(WP)
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用(WP)
        Dim lstrRET             As String           '応答取得
         
        Try
            
            pstrMessageName = "ポートリスト取得"
            pubblnMasWpPortList_Sel = False
            
            '@装置IDがない場合
            If lstrWpId = vbNullString Then Exit Function
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            '@WPID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            '@SBID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_wpportlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_wpportlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_wpportlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得(WP)
                    Call laMsg.getMsgAry(CPstrPORT_LIST, laAry)
                    '@ﾘｽﾄ数を格納(WP)
                    'llngListCnt = laAry.Count NSYS 不要となるため削除
                    llngWPPortListCnt = laAry.Count

                    'NSYS 戻し用構造体の初期化
                    ltypWPPortList = New List(Of LotWPPortList)
                    
                    '@配列を確保
                    If llngWPPortListCnt > 0 Then
                         'ReDim Preserve ltypWPPortList(llngListCnt) NSYS ループ内処理へ移動
                   
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得(WP)
                        'llngCnt = 1 NSYS 不要となるため削除
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体を初期化
                            Dim ltypWPPortListTmp = New LotWPPortList

                            '@受信結果取得(WP)
                            With ltypWPPortListTmp
                                Call ltMsg.getString(CPstrPORT_ID, .strPortID)         'ﾎﾟｰﾄID
                                Call ltMsg.getString(CPstrPORT_NAME, .strPortName)     'ﾎﾟｰﾄ名
                                Call ltMsg.getString(CPstrPORT_TYPE, .strPortType)     'ﾎﾟｰﾄﾀｲﾌﾟ
                            End With

                            'NSYS 編集済構造体を追加
                            ltypWPPortList.Add(ltypWPPortListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If
                    '@関数の処理結果(成功)格納
                    pubblnMasWpPortList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_wpportlistVer)
                    
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
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnLotPrcstart_Ins
    '機　能：ﾛｯﾄ処理開始
    '引　数：lstrlot_prcstartVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分
    '　　　：ltypLotprcstart        ：ﾛｯﾄ処理開始構造体(送信)
    '　　　：lstrToOpID             ：制限時間先大工程
    '　　　：lstrToSteoID           ：制限時間先小工程
    '　　　：lstrLimitTime          ：制限時間
    '　　　：lstrWarnTime           ：警告時間
    '　　　：lstrRecipID            ：ﾚｼﾋﾟID
    '　　　：lstrPolTime            ：研磨時間
    '　　　：lstrPlcResult          ：PLCﾚｼﾋﾟ照合結果
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/17 (Wed) 17:01:58 T.Kitagawa
    '更新日：2012/02/28 (Tue) 17:12:54 Y.Yoneyama
    '備　考：
    '　　　：2004/09/14 (Tue) 15:48:18 N.Kasai      新com対応（CPstrEQ_FLAG不要ﾀｸﾞ削除）
    '　　　：2004/10/05 (Tue) 13:36:52 M.Miura　    送信ﾒｯｾｰｼﾞのﾚｼﾋﾟIDﾀｸﾞを削除（未使用の為）
    '　　　：2005/04/21 (Thu) 17:29:37 N.Kojima     CMP関連追加対応。
    '      ：2012/02/29 (Wed) 15:45:19 Y.Yoneyama   PLCﾚｼﾋﾟ照合機能対応
    Public Function pubblnLotPrcstart_Ins(ByRef lstrlot_prcstartVer As String, _
                                          ByVal lstrClassDivision As String, _
                                          ByRef ltypLotprcstart As Lotprcstart, _
                                          ByRef lstrToOpID As String, _
                                          ByRef lstrToStepID As String, _
                                          ByRef lstrLimitTime As String, _
                                          ByRef lstrWarnTime As String, _
                                          ByRef lstrRecipID As String, _
                                          ByRef lstrPolTime As String, _
                                          ByRef lstrPlcResult As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "ロット処理開始"
            pubblnLotPrcstart_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypLotprcstart
                '@送信ﾒｯｾｰｼﾞ作成
                '@処理区分
                If lstrClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                '@ﾛｯﾄID
                If .strLotID = vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                End If
                '@大工程ID
                If .strOpID = vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                End If
                '@小工程ID
                If .strStepID = vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                End If
                '@WPID
                If .strWpID = vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                End If
                '@ﾎﾟｰﾄID
                If .strPortID = vbNullString Then
                    Call lrMsg.addString(CPstrPORT_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrPORT_ID, .strPortID)
                End If
                '@作業者ID
                If .strEngEmpId = vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, .strEngEmpId)
                End If
                '@LOT最終更新日時
                If .strLotLastUpdate = vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                End If
                '@ｺﾒﾝﾄ
                If .strComment = vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, .strComment)
                End If
                '@ｱﾝﾛｰﾀﾞｰﾎﾟｰﾄID
                If .strToPortID = vbNullString Then
                    Call lrMsg.addString(CPstrTO_PORT_ID, CPstrMsgNull)
                Else
                    Call lrMsg.addString(CPstrTO_PORT_ID, .strToPortID)
                End If
            End With
            
            '@SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_prcstartVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_prcstartVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_prcstart, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    Call laMsg.getString(CPstrTO_OP_ID, lstrToOpID)         '大工程
                    Call laMsg.getString(CPstrTO_STEP_ID, lstrToStepID)     '小工程
                    Call laMsg.getString(CPstrLIMIT_TIME, lstrLimitTime)    '時間制約
                    Call laMsg.getString(CPstrWARN_TIME, lstrWarnTime)      '警告時間
                    Call laMsg.getString(CPstrRECIPE_ID, lstrRecipID)       'ﾚｼﾋﾟID
                    Call laMsg.getString(CPstrPOL_TIME, lstrPolTime)        '研磨時間
        '@↓2012/02/28 (Tue) 17:15:47 Y.Yoneyama **************************************************
                    Call laMsg.getString(CPstrPLC_RECIPE_COMPARE_RESULT, lstrPlcResult)     'PLCﾚｼﾋﾟ照合結果
        '@↑2012/02/28 (Tue) 17:15:47 Y.Yoneyama **************************************************
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotPrcstart_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_prcstartVer)
                    
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


End Module
