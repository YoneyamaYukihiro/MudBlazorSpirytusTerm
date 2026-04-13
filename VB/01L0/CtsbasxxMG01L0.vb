'ﾌｧｲﾙ名：xxMG01L0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：搬送ﾓｰﾄﾞ管理　通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2004/12/06 (Mon) 16:10:14 N.Kojima
'更新日：2005/02/23 (Wed) 16:15:32 N.Kasai
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01L0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '@↓：2005/02/23 (Wed) 16:15:32 N.Kasai xxCM0050.basへ移動
    '''関数名：pubblnFtsMode_Sel
    '''機　能：搬送ﾓｰﾄﾞ取得要求
    '''引　数：lstrfts_mode____Ver：Msgﾊﾞｰｼﾞｮﾝ
    '''  　  ：llngMachineStatusListCnt：機器ﾘｽﾄｶｳﾝﾄ
    '''　　　：ltypFtsMode：搬送ﾓｰﾄﾞ構造体
    '''戻り値：True:成功、Flase：失敗
    '''作成日：2004/12/06 (Mon) 16:13:27 N.Kojima
    '''更新日：2004/12/13 (Mon) 14:59:56 N.Kojima
    '''備　考：
    ''Public Function pubblnFtsMode_Sel(ByVal lstrfts_mode____Ver As String, ByRef llngMachineStatusListCnt As Long, _
    ''                                  ByRef ltypFtsMode As FtsMode) As Boolean
    ''
    ''    Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
    ''    Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
    ''    Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp）-送信
    ''    Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ）-送信
    ''    Dim lrAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）-受信
    ''    Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp）-受信
    ''    Dim laAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）-受信
    ''    Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp）-受信
    ''    Dim laAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）-受信
    ''    Dim ltMsg3             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp）-送信
    ''    Dim laAry3             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）-受信
    ''    Dim lstrRET            As String            '応答取得
    ''    Dim lstrErrMsg         As String            'ｴﾗｰ用
    ''    Dim llngCnt1           As Long              'ｱﾚｲｶｳﾝﾄ用1
    ''    Dim llngCnt2           As Long              'ｱﾚｲｶｳﾝﾄ用2
    ''    Dim llngCnt3           As Long              'ｱﾚｲｶｳﾝﾄ用3
    ''    Dim lstrMSG            As String            'ﾒｯｾｰｼﾞ内容格納
    ''
    ''    On Error GoTo Error_Handler
    ''
    ''    Set lrMsg = New TfMsg
    ''    Set laMsg = New TfMsg
    ''    Set ltMsg = New TfMsg
    ''    Set lrAry = New TfMsgAry
    ''    Set lrAry1 = New TfMsgAry
    ''    Set ltMsg1 = New TfMsg
    ''    Set laAry1 = New TfMsgAry
    ''    Set ltMsg2 = New TfMsg
    ''    Set laAry2 = New TfMsgAry
    ''    Set ltMsg3 = New TfMsg
    ''    Set laAry3 = New TfMsgAry
    ''
    ''    '@初期設定
    ''    pstrMessageName = "搬送モード取得"
    ''    pubblnFtsMode_Sel = False
    ''
    ''    '@Msgﾊﾞｰｼﾞｮﾝ
    ''    If lstrfts_mode____Ver <> vbNullString Then
    ''        Call lrMsg.addString(CPstrMSG_VER, lstrfts_mode____Ver)
    ''    Else
    ''        Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
    ''    End If
    ''
    ''    '@ﾒｯｾｰｼﾞ送信
    ''    Call pTerm.sendRequest(CPstrfts_mode____, lrMsg, laMsg)
    ''
    ''    '@受信結果取得
    ''    Call laMsg.getString(CPstrRET, lstrRET)
    ''
    ''    '@結果判定
    ''    Select Case lstrRET
    ''
    ''        '@成功の場合(true)
    ''        Case CPstrTRUE
    ''
    ''            '@構造体のｸﾘｱ
    ''            Erase ltypFtsMode.typFtsStockerLIST()
    ''            Erase ltypFtsMode.typFtsBAYLIST()
    ''            Erase ltypFtsMode.typFtsVehicleLIST()
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
    ''            Call laMsg.getString(CPstrTRANSFER_STATUS, ltypFtsMode.strTransferStatus)           '搬送可能状態ID
    ''            Call laMsg.getString(CPstrTRANSFER_STATUS_NAME, ltypFtsMode.strTransferStatusName)  '搬送可能状態名
    ''            Call laMsg.getString(CPstrSTATUS, ltypFtsMode.strStatus)                            '搬送サーバ状態
    ''            Call laMsg.getString(CPstrSTATUS_NAME, ltypFtsMode.strStatusName)                   '搬送サーバ状態名
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
    ''            Call laMsg.getMsgAry(CPstrFTS_STOCKER_LIST, laAry1)
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
    ''            ltypFtsMode.lngStockerListCnt = laAry1.Count
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
    ''            If ltypFtsMode.lngStockerListCnt > 0 Then
    ''
    ''                ReDim Preserve ltypFtsMode.typFtsStockerLIST(ltypFtsMode.lngStockerListCnt)
    ''
    ''                '@受信ﾒｯｾｰｼﾞｱﾚｲ1から各Msg取得
    ''                llngCnt1 = 1
    ''                For Each ltMsg1 In laAry1
    ''                    With ltypFtsMode.typFtsStockerLIST(llngCnt1)
    ''                        '@ﾃﾞｰﾀ格納
    ''                        Call ltMsg1.getString(CPstrSTOCKER_ID, .strStockerID)                       'ｽﾄｯｶｰID
    ''                        Call ltMsg1.getString(CPstrSTOCKER_NAME, .strStockerName)                   'ｽﾄｯｶｰ名
    ''                        Call ltMsg1.getString(CPstrSTATUS, .strStatus)                              'ｽﾄｯｶｰ状態ID
    ''                        Call ltMsg1.getString(CPstrSTATUS_NAME, .strStatusName)                     'ｽﾄｯｶｰ状態名
    ''                        Call ltMsg1.getString(CPstrSTOCKER_CAPACITY, .strStockerCapacity)           'ｽﾄｯｶｰ収納状況ID
    ''                        Call ltMsg1.getString(CPstrSTOCKER_CAPACITY_NAME, .strStockerCapacityName)  'ｽﾄｯｶｰ収納状況名
    ''                        Call ltMsg1.getString(CPstrALARM_ID, .strAlarmID)                           'ｱﾗｰﾑID
    ''                        Call ltMsg1.getString(CPstrEDIT_TIME, .strEditTime)                         '最終更新日時
    ''
    ''                        '@ｶｳﾝﾄｱｯﾌﾟ
    ''                        llngCnt1 = llngCnt1 + 1
    ''                    End With
    ''                Next
    ''
    ''            End If
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ2取得
    ''            Call laMsg.getMsgAry(CPstrFTS_BAY_LIST, laAry2)
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ2のｶｳﾝﾄ格納
    ''            ltypFtsMode.lngBayListCnt = laAry2.Count
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
    ''            If ltypFtsMode.lngBayListCnt > 0 Then
    ''
    ''                ReDim Preserve ltypFtsMode.typFtsBAYLIST(ltypFtsMode.lngBayListCnt)
    ''
    ''                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
    ''                llngCnt2 = 1
    ''                For Each ltMsg2 In laAry2
    ''                    With ltypFtsMode.typFtsBAYLIST(llngCnt2)
    ''                        '@受信結果取得
    ''                        Call ltMsg2.getString(CPstrBAY_ID, .strBAYID)                   'ﾍﾞｲID
    ''                        Call ltMsg2.getString(CPstrBAY_NAME, .strBAYName)               'ﾍﾞｲ名
    ''                        Call ltMsg2.getString(CPstrSTATUS, .strStatus)                  'ﾍﾞｲ状態ID
    ''                        Call ltMsg2.getString(CPstrSTATUS_NAME, .strStatusName)         'ﾍﾞｲ状態名
    ''                        Call ltMsg2.getString(CPstrALARM_ID, .strAlarmID)               'ｱﾗｰﾑID
    ''                        Call ltMsg2.getString(CPstrEDIT_TIME, .strEditTime)             '最終更新日時
    ''                        llngCnt2 = llngCnt2 + 1
    ''                    End With
    ''                Next
    ''
    ''            End If
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ3取得
    ''            Call laMsg.getMsgAry(CPstrFTS_VEHICLE_LIST, laAry3)
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ3のｶｳﾝﾄ格納
    ''            ltypFtsMode.lngVehicleListCnt = laAry3.Count
    ''
    ''            '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
    ''            If ltypFtsMode.lngVehicleListCnt > 0 Then
    ''
    ''                ReDim Preserve ltypFtsMode.typFtsVehicleLIST(ltypFtsMode.lngVehicleListCnt)
    ''
    ''                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
    ''                llngCnt3 = 1
    ''                For Each ltMsg3 In laAry3
    ''                    With ltypFtsMode.typFtsVehicleLIST(llngCnt3)
    ''                        '@受信結果取得
    ''                        Call ltMsg3.getString(CPstrVEHICLE_ID, .strVehicleID)           'ﾋﾞｰｸﾙID
    ''                        Call ltMsg3.getString(CPstrVEHICLE_NAME, .strVehicleName)       'ﾋﾞｰｸﾙ名
    ''                        Call ltMsg3.getString(CPstrSTATUS, .strStatus)                  'ﾋﾞｰｸﾙ状態ID
    ''                        Call ltMsg3.getString(CPstrSTATUS_NAME, .strStatusName)         'ﾋﾞｰｸﾙ状態名
    ''                        Call ltMsg3.getString(CPstrEDIT_TIME, .strEditTime)             '最終更新日時
    ''                        llngCnt3 = llngCnt3 + 1
    ''                    End With
    ''                Next
    ''
    ''            End If
    ''
    ''            '@"ｽﾄｯｶｰﾘｽﾄｶｳﾝﾄ"+"ﾍﾞｲﾘｽﾄｶｳﾝﾄ"+"ﾋﾞｰｸﾙﾘｽﾄｶｳﾝﾄ"を機器ﾘｽﾄｶｳﾝﾄに格納
    ''            llngMachineStatusListCnt = ltypFtsMode.lngStockerListCnt + ltypFtsMode.lngVehicleListCnt + _
    ''                                       ltypFtsMode.lngBayListCnt
    ''
    ''            '@関数の処理結果(成功)格納
    ''            pubblnFtsMode_Sel = True
    ''
    ''        '@失敗の場合(false)
    ''        Case CPstrFALSE
    ''
    ''            '@ﾊﾞｰｼﾞｮﾝ判定
    ''            Call pubstrErrMsg_Set(laMsg, lstrfts_mode____Ver)
    ''
    ''        '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
    ''        Case Else
    ''            '@表示ﾒｯｾｰｼﾞ変換
    ''            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
    ''            '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
    ''            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
    ''
    ''    End Select
    ''
    ''    Set lrMsg = Nothing
    ''    Set laMsg = Nothing
    ''    Set ltMsg = Nothing
    ''    Set lrAry = Nothing
    ''    Set lrAry1 = Nothing
    ''    Set ltMsg1 = Nothing
    ''    Set laAry1 = Nothing
    ''    Set ltMsg2 = Nothing
    ''    Set laAry2 = Nothing
    ''    Set ltMsg3 = Nothing
    ''    Set laAry3 = Nothing
    ''
    ''    Exit Function
    ''
    '''@例外処理
    ''Error_Handler:
    ''
    ''    '@表示ﾒｯｾｰｼﾞ変換
    ''    Call pubErrMsg_Proc(Err)
    ''
    ''    Set lrMsg = Nothing
    ''    Set laMsg = Nothing
    ''    Set ltMsg = Nothing
    ''    Set lrAry = Nothing
    ''    Set lrAry1 = Nothing
    ''    Set ltMsg1 = Nothing
    ''    Set laAry1 = Nothing
    ''    Set ltMsg2 = Nothing
    ''    Set laAry2 = Nothing
    ''    Set ltMsg3 = Nothing
    ''
    ''End Function
    '@↑：2005/02/23 (Wed) 16:15:32 N.Kasai xxCM0050.basへ移動


    '関数名：pubblnFtsChgModem_Upd
    '機　能：搬送モード変更指示
    '引　数：CMstrfts_chgmodemVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrTransferStatus：搬送可能状態ID
    '　　　：ltypFtsMode：搬送モード変更指示構造体
    '戻り値：True：正常、False：異常
    '作成日：2004/12/07 (Tue) 17:34:40 N.Kojima
    '更新日：2004/12/07 (Tue) 17:34:40
    '備　考：
    Public Function pubblnFtsChgModem_Upd(ByVal lstrfts_chgmodemVer As String, ByVal lstrTransferStatus As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            '@初期設定
            pstrMessageName = "搬送モード変更指示"
            pubblnFtsChgModem_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@搬送可能状態ID
            If lstrTransferStatus <> vbNullString Then
                Call lrMsg.addString(CPstrTRANSFER_STATUS, lstrTransferStatus)
            Else
                Call lrMsg.addString(CPstrTRANSFER_STATUS, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrfts_chgmodemVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrfts_chgmodemVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@作業者ID
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrfts_chgmodem, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@関数の処理結果(成功)格納
                    pubblnFtsChgModem_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrfts_chgmodemVer)
                    
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function


End Module
