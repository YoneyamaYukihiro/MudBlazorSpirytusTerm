'ﾌｧｲﾙ名：xxMG01Z0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置メンテナンス 通信メッセージ用標準モジュール
'作成日：2007/01/10 (Wed) 15:04:41 N.Kojima
'更新日：2008/01/23 (Wed) 14:00:50 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01Z0
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

    '関数名：pubblnRepRepairList_Sel
    '機　能：故障修理記録票一覧取得
    '引　数：ltypRepairInfoReq      ：故障修理記録ﾘｽﾄ格納用構造体(要求用)
    '　　　：ltypRepairInfoAns()    ：故障修理記録ﾘｽﾄ格納用構造体(応答用)
    '　　　：llngRepairListCnt      ：故障修理記録ﾘｽﾄ格納数
    '戻り値：True:成功/Flase：失敗
    '作成日：2007/01/15 (Mon) 16:05:04 N.Kojima
    '更新日：2008/03/17 (Mon) 09:53:43 N.Kojima
    '備　考：
    '　　　：2008/03/17 (Mon) 09:53:43 N.Kojima     応答ﾀｸﾞ追加(対応区分、作業費用、部品費用)。(案件№02332)
    Public Function pubblnRepRepairList_Sel(ByRef ltypRepairInfoReq As RepairInfoReq, _
                                            ByRef ltypRepairInfoAns As List(Of RepairInfoAns), _
                                            ByRef llngRepairListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ用2

        Try

            pstrMessageName = "故障修理記録票一覧取得"
            pubblnRepRepairList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
            lrAry = New TfMsgAry
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            
            With ltypRepairInfoReq
            
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@検索開始日
                If .strStartDate <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_DATE, .strStartDate)
                Else
                    Call lrMsg.addString(CPstrSTART_DATE, CPstrMsgNull)
                End If
                
                '@検索終了日
                If .strEndDate <> vbNullString Then
                    Call lrMsg.addString(CPstrEND_DATE, .strEndDate)
                Else
                    Call lrMsg.addString(CPstrEND_DATE, CPstrMsgNull)
                End If
                
                '@装置ﾘｽﾄ
                For llngCnt = 0 To .lngWPCnt -1
                    If .typWpList(llngCnt).strWpID <> vbNullString Then
                        Call ltMsg.addString(CPstrWP_ID, .typWpList(llngCnt).strWpID)
                    Else
                        Call ltMsg.addString(CPstrWP_ID, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt
            
                Call lrMsg.addMsgAry(CPstrWP_LIST, lrAry)
                lrAry.Clear
            
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrrep_repairlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrREPORT_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    llngRepairListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngRepairListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        If ltypRepairInfoAns Is Nothing Then
                            ltypRepairInfoAns = New List(Of RepairInfoAns)
                        Else
                            ltypRepairInfoAns.Clear
                        End If
                        
                        '@ｶｳﾝﾄ初期化
                        llngCnt = 0
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypRepairInfoAnsTmp As New RepairInfoAns
                            With ltypRepairInfoAnsTmp
                                Call ltMsg.getString(CPstrREPAIR_NO, .strRepairNo)                      '故障修理記録№
                                Call ltMsg.getString(CPstrREPAIR_STATUS, .strRepairStatus)              '故障修理記録票状態(0：未処置、1：処置済、2：承認済、3：無効)
                                Call ltMsg.getString(CPstrWP_ID, .strWpID)                              '装置ID
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)                          '装置名
                                Call ltMsg.getString(CPstrREPAIR_NAME, .strRepairName)                  '故障現象名
                                Call ltMsg.getString(CPstrREPAIR_START_DATE, .strRepairStartDate)       '故障発生日時
                                Call ltMsg.getString(CPstrREPAIR_END_DATE, .strRepairEndDate)           '修理完了日時
                                
                                '@ｱﾚｲを格納(確認依頼先)
                                Call ltMsg.getMsgAry(CPstrTO_EMP_LIST, laAry2)          '担当者名(依頼先作業者)
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                If laAry2.Count > 0 Then
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                    
                                    '@ｱﾚｲｶｳﾝﾄ取得
                                    .lngEmpListCnt = laAry2.Count
                                    
                                    '@配列の要素数を設定
                                    If .typEmpList Is Nothing Then
                                        .typEmpList = New List(Of EmpList)
                                    Else
                                        .typEmpList.Clear
                                    End If
                                    Dim typEmpListTmp As New EmpList
                                    llngCnt2 = 0
                                    '@ｱﾚｰの各要素取得
                                    For Each ltMsg2 In laAry2
                                        Call ltMsg2.getString(CPstrEMP_ID, typEmpListTmp.strEmpID)      '確認依頼先担当者ID
                                        Call ltMsg2.getString(CPstrEMP_NAME, typEmpListTmp.strEmpName)  '確認依頼先担当者名
                                        .typEmpList.Add(typEmpListTmp)
                                        '@ｶｳﾝﾄｱｯﾌﾟ
                                        llngCnt2 = llngCnt2 + 1
                                    Next
                                End If
                
                                Call ltMsg.getString(CPstrFIND_EMP_NAME, .strFindEmpName)                       '発見者名
                                Call ltMsg.getString(CPstrPRESERVER_EMP_NAME, .strPreserveEmpName)              '保全実施者名
                                Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)                              '更新日時
                                Call ltMsg.getString(CPstrREPAIR_CONTENTS, .strRepairContents)                  '故障現象詳細
                                Call ltMsg.getString(CPstrREPAIR_ANALYSIS_CONTENTS, .strRepairAnalysisContents) '調査/分析詳細
                                Call ltMsg.getString(CPstrREPAIR_CAUSE_CONTENTS, .strRepairCauseContents)       '原因詳細
                                Call ltMsg.getString(CPstrREPAIR_MEASURE_CONTENTS, .strRepairMeasureContents)   '対策詳細
                                Call ltMsg.getString(CPstrREPAIR_COPE_DIVISION, .strCopeDivision)               '(故障修理)対応区分(1:自主保全、2:ﾒｰｶｰ保全)
                                Call ltMsg.getString(CPstrREPAIR_WORK_COST, .strWorkCost)                       '(故障修理)作業費用
                                Call ltMsg.getString(CPstrREPAIR_PART_COST, .strPartCost)                       '(故障修理)部品費用
                            End With
                            
                            ltypRepairInfoAns.Add(ltypRepairInfoAnsTmp)

                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnRepRepairList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypRepairInfoReq.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
                    
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            lrAry = Nothing
            laAry = Nothing
            laAry2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            lrAry = Nothing
            laAry = Nothing
            laAry2 = Nothing

        End Try
    End Function

    '@↓2008/01/23 (Wed) 14:02:02 N.Kojima **************************************************
    '関数名：pubblnPrePreserveList_Sel
    '機　能：保全記録票一覧取得
    '引　数：ltypPreserveInfoReq    ：保全記録ﾘｽﾄ格納用構造体(要求用)
    '　　　：ltypPreserveInfoAns()  ：保全記録ﾘｽﾄ格納用構造体(応答用)
    '　　　：llngPreserveListCnt    ：保全記録ﾘｽﾄ格納数
    '　　　：lstrClassDivision      ：処理区分(NULL:全て、4G:手動起票記録票のみ)
    '戻り値：True:成功/Flase：失敗
    '作成日：2007/01/15 (Mon) 16:05:04 N.Kojima
    '更新日：2007/01/15 (Mon) 16:05:04
    '備　考：
    Public Function pubblnPrePreserveList_Sel(ByRef ltypPreserveInfoReq As PreserveInfoReq, _
                                              ByRef ltypPreserveInfoAns As List(Of PreserveInfoAns), _
                                              ByRef llngPreserveListCnt As Integer, _
                                              Optional ByVal lstrClassDivision As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ用2

        Try

            pstrMessageName = "保全記録票一覧取得"
            pubblnPrePreserveList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
            lrAry = New TfMsgAry
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypPreserveInfoReq
            
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@検索開始日
                If .strStartDate <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_DATE, .strStartDate)
                Else
                    Call lrMsg.addString(CPstrSTART_DATE, CPstrMsgNull)
                End If
                
                '@検索終了日
                If .strEndDate <> vbNullString Then
                    Call lrMsg.addString(CPstrEND_DATE, .strEndDate)
                Else
                    Call lrMsg.addString(CPstrEND_DATE, CPstrMsgNull)
                End If
                
                '@処理区分
                If lstrClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@装置ﾘｽﾄ
                For llngCnt = 0 To .lngWPCnt -1
                    If .typWpList(llngCnt).strWpID <> vbNullString Then
                        Call ltMsg.addString(CPstrWP_ID, .typWpList(llngCnt).strWpID)
                    Else
                        Call ltMsg.addString(CPstrWP_ID, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt
            
                Call lrMsg.addMsgAry(CPstrWP_LIST, lrAry)
                lrAry.Clear
                
                '@ｶﾃｺﾞﾘﾘｽﾄ
                For llngCnt = 0 To .lngCategoryCnt -1
                    If .typCategoryList(llngCnt).strCategoryID <> vbNullString Then
                        Call ltMsg.addString(CPstrCATEGORY_ID, .typCategoryList(llngCnt).strCategoryID)
                    Else
                        Call ltMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt
            
                Call lrMsg.addMsgAry(CPstrCATEGORY_LIST, lrAry)
                lrAry.Clear
            
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrpre_preservelist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
            
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrREPORT_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    llngPreserveListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngPreserveListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        If ltypPreserveInfoAns Is Nothing Then
                            ltypPreserveInfoAns = New List(Of PreserveInfoAns)
                        Else
                            ltypPreserveInfoAns.Clear
                        End If

                        '@ｶｳﾝﾄ初期化
                        llngCnt = 0
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypPreserveInfoAnsTmp As New PreserveInfoAns
                            With ltypPreserveInfoAnsTmp
                                Call ltMsg.getString(CPstrPRESERVE_STATUS, .strPreserveStatus)          '保全記録票状態(0：未処置、1：処置済、2：承認済、3：無効)
                                Call ltMsg.getString(CPstrPRESERVE_NO, .strPreserveNo)                  '保全記録票№
                                Call ltMsg.getString(CPstrWP_ID, .strWpID)                              '装置ID
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)                          '装置名
                                Call ltMsg.getString(CPstrCATEGORY_ID, .strCategoryID)                  'ｶﾃｺﾞﾘID
                                Call ltMsg.getString(CPstrCATEGORY_NAME, .strCategoryName)              'ｶﾃｺﾞﾘ名
                                Call ltMsg.getString(CPstrPRESERVE_CATEGORY, .strPreserveCategory)      '保全ｶﾃｺﾞﾘ
                                Call ltMsg.getString(CPstrPRESERVE_START_DATE, .strPreserveStartDate)   '開始(予定)日時
                                Call ltMsg.getString(CPstrPRESERVE_END_DATE, .strPreserveEndDate)       '終了(予定)日時
                                
                                '@ｱﾚｲを格納(確認依頼先)
                                Call ltMsg.getMsgAry(CPstrTO_EMP_LIST, laAry2)          '担当者名(依頼先作業者)
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                If laAry2.Count > 0 Then
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                    
                                    '@ｱﾚｲｶｳﾝﾄ取得
                                    .lngEmpListCnt = laAry2.Count
                                    
                                    '@配列の要素数を設定
                                    If .typEmpList Is Nothing Then
                                        .typEmpList = New List(Of EmpList)
                                    Else
                                        .typEmpList.Clear
                                    End If
                                    Dim typEmpListTmp As New EmpList
                                    llngCnt2 = 0
                                    '@ｱﾚｰの各要素取得
                                    For Each ltMsg2 In laAry2
                                        Call ltMsg2.getString(CPstrEMP_ID, typEmpListTmp.strEmpID)      '確認依頼先担当者ID
                                        Call ltMsg2.getString(CPstrEMP_NAME, typEmpListTmp.strEmpName)  '確認依頼先担当者名
                                        .typEmpList.Add(typEmpListTmp)
                                        '@ｶｳﾝﾄｱｯﾌﾟ
                                        llngCnt2 = llngCnt2 + 1
                                    Next
                                End If
                
                                Call ltMsg.getString(CPstrPRESERVER_EMP_NAME, .strPreserveEmpName)                  '保全実施者名
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                                    '作業者名
                                Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)                                  '更新日時
                                Call ltMsg.getString(CPstrPRESERVE_COMMENTS, .strPreserveComments)                  '停止ｺﾒﾝﾄ
                                Call ltMsg.getString(CPstrPRESERVE_ITEM, .strPreserveItem)                          '(保全)実施項目
                                Call ltMsg.getString(CPstrPRESERVE_CONTENTS, .strPreserveContents)                  '(保全)実施内容
                                Call ltMsg.getString(CPstrPRESERVE_PURPOSE, .strPreservePurpose)                    '(保全)実施理由/目的
                                Call ltMsg.getString(CPstrPRESERVE_COPE_DIVISION, .strCopeDivision)                 '(保全)対応区分(1:自主保全、2:ﾒｰｶｰ保全)
                                Call ltMsg.getString(CPstrPRESERVE_WORK_COST, .strWorkCost)                         '(保全)作業費用
                                Call ltMsg.getString(CPstrPRESERVE_PART_COST, .strPartCost)                         '(保全)部品費用
                                Call ltMsg.getString(CPstrPRESERVE_SIGN_EMP_ID, .strPreserveSignEmpID)              '保全担当ｻｲﾝID
                                Call ltMsg.getString(CPstrPRESERVE_LEADER_SIGN_EMP_ID, .strPreserveLeaderSignEmpID) '保全ﾘｰﾀﾞｰｻｲﾝID
                                Call ltMsg.getString(CPstrPRODUCT_LEADER_SIGN_EMP_ID, .strProductLeaderSignEmpID)   '作業長ｻｲﾝID

                                ltypPreserveInfoAns.Add(ltypPreserveInfoAnsTmp)
                            End With
                            
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnPrePreserveList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypPreserveInfoReq.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
                    
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            lrAry = Nothing
            laAry = Nothing
            laAry2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            lrAry = Nothing
            laAry = Nothing
            laAry2 = Nothing

        End Try
    End Function
    '@↑2008/01/23 (Wed) 14:02:02 N.Kojima **************************************************

    '関数名：pubblnEqStopMenteList_Sel
    '機　能：装置停止・メンテ計画一覧取得
    '引　数：ltypEqStopMenteListReq：要求ﾃﾞｰﾀ構造体
    '　　　：ltypEqStopMenteListAns：応答ﾃﾞｰﾀ構造体
    '戻り値：True：正常、False：異常
    '作成日：2006/04/19 (Wed) 16:58:07 T.Kitagawa
    '更新日：2006/11/30 (Thu) 15:21:06 N.Kojima
    '備　考：
    '　　　：2006/08/03 (Thu) 16:10:42 T.Kitagawa　 期間指定機能を追加（案件№01365）
    '　　　：2006/10/18 (Wed) 18:07:18 N.Kojima     要求に"CATEGORY_ID",応答に"CATEGORY_NAME","PLAN_WP_STOP_START","PLAN_WP_STOP_END",
    '　　　：                                       "RESULT_WP_STOP_START","RESULT_WP_STOP_END"を追加。(案件№01497)
    '　　　：2006/11/07 (Tue) 09:19:54 N.Kojima     要求に"JUDGE_FLAG"、応答に"ENTRY_TIME"・"CATEGORY_ID"追加。(案件№01601)
    '　　　：2006/11/30 (Thu) 15:21:06 N.Kojima     要求の"JUDGE_FLAG"を削除、応答の"PLAN_WP_STOP_START","PLAN_WP_STOP_END",
    '　　　：                                       "RESULT_WP_STOP_START","RESULT_WP_STOP_END"を削除し、"WP_STOP_START","WP_STOP_END"を追加。(案件№01625)
    Public Function pubblnEqStopMenteList_Sel(ByRef ltypEqStopMenteListReq As EqStopMenteListReq, _
                                              ByRef ltypEqStopMenteListAns As EqStopMenteListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "装置停止・メンテ計画一覧取得"
            pubblnEqStopMenteList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypEqStopMenteListReq
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
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

                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@装置ｸﾞﾙｰﾌﾟID
                If .strMcGroupID <> vbNullString Then
                    Call lrMsg.addString(CPstrMC_GROUP_ID, .strMcGroupID)
                Else
                    Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
                End If

                '@検索開始日
                If .strStartDate <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_DATE, .strStartDate)
                Else
                    Call lrMsg.addString(CPstrSTART_DATE, CPstrMsgNull)
                End If

                '@検索開始時刻
                If .strStartTime <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_TIME, .strStartTime)
                Else
                    Call lrMsg.addString(CPstrSTART_TIME, CPstrMsgNull)
                End If

                '@検索終了日
                If .strEndDate <> vbNullString Then
                    Call lrMsg.addString(CPstrEND_DATE, .strEndDate)
                Else
                    Call lrMsg.addString(CPstrEND_DATE, CPstrMsgNull)
                End If

                '@検索終了時刻
                If .strEndTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEND_TIME, .strEndTime)
                Else
                    Call lrMsg.addString(CPstrEND_TIME, CPstrMsgNull)
                End If

        '@↓2006/11/29 (Wed) 18:49:58 N.Kojima **************************************************
        '        '@予実表表示用判定ﾌﾗｸﾞ
        '        If .strJudgeFlag <> vbNullString Then
        '            Call lrMsg.addString(CPstrJUDGE_FLAG, .strJudgeFlag)
        '        Else
        '            Call lrMsg.addString(CPstrJUDGE_FLAG, CPstrMsgNull)
        '        End If
        '@↑2006/11/29 (Wed) 18:49:58 N.Kojima **************************************************

                '@装置ﾘｽﾄ
                For llngCnt = 0 To .lngWPCnt -1
                    If .typWpList(llngCnt).strWpID <> vbNullString Then
                        Call ltMsg.addString(CPstrWP_ID, .typWpList(llngCnt).strWpID)
                    Else
                        Call ltMsg.addString(CPstrWP_ID, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt

                Call lrMsg.addMsgAry(CPstrWP_LIST, lrAry)
                lrAry.Clear

                '@ｶﾃｺﾞﾘﾘｽﾄ
                For llngCnt = 0 To .lngCategoryCnt -1
                    If .typCategoryList(llngCnt).strCategoryID <> vbNullString Then
                        Call ltMsg.addString(CPstrCATEGORY_ID, .typCategoryList(llngCnt).strCategoryID)
                    Else
                        Call ltMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt

                Call lrMsg.addMsgAry(CPstrCATEGORY_LIST, lrAry)
                lrAry.Clear
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__schwpmentelist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrSCH_WP_MENTE_LIST, laAry)

                    With ltypEqStopMenteListAns
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        .lngEqStopMenteListCnt = laAry.Count
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngEqStopMenteListCnt > 0 Then
                            If .typEqStopMenteList Is Nothing Then
                                .typEqStopMenteList = New List(Of EqStopMenteList)
                            Else
                                .typEqStopMenteList.Clear
                            End If
                            Dim typEqStopMenteListTmp As New EqStopMenteList

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typEqStopMenteListTmp
                                    Call ltMsg.getString(CPstrWP_ID, .strWpID)                          '装置ID
                                    Call ltMsg.getString(CPstrWP_NAME, .strWpName)                      '装置名
        '@↓2006/11/29 (Wed) 18:50:31 N.Kojima **************************************************
        '                            Call ltMsg.getString(CPstrPLAN_WP_STOP_START, .strPlanWPStopStart)      '計画停止開始日時
        '                            Call ltMsg.getString(CPstrPLAN_WP_STOP_END, .strPlanWPStopEnd)          '計画停止終了日時
        '                            Call ltMsg.getString(CPstrRESULT_WP_STOP_START, .strResultWPStopStart)  '実績停止開始日時
        '                            Call ltMsg.getString(CPstrRESULT_WP_STOP_END, .strResultWPStopEnd)      '実績停止終了日時
                                    Call ltMsg.getString(CPstrWP_STOP_START, .strWPStopStart)           '停止開始日時
                                    Call ltMsg.getString(CPstrWP_STOP_END, .strWPStopEnd)               '停止終了日時
        '@↑2006/11/29 (Wed) 18:50:31 N.Kojima **************************************************
                                    Call ltMsg.getString(CPstrCATEGORY_NAME, .strCategoryName)          'ｶﾃｺﾞﾘ名
                                    Call ltMsg.getString(CPstrWP_STOP_RULE, .strWPStopRule)             '停止ﾙｰﾙ
                                    Call ltMsg.getString(CPstrWP_STOP_COMMENTS, .strWPStopComments)     '停止ｺﾒﾝﾄ
                                    Call ltMsg.getString(CPstrEMP_ID, .strEmpID)                        '作業者ID
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                    '作業者名
                                    Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)                  '更新日時
                                    Call ltMsg.getString(CPstrCATEGORY_ID, .strCategoryID)              'ｶﾃｺﾞﾘID
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)                '登録日時
                                End With
                                .typEqStopMenteList.Add(typEqStopMenteListTmp)
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnEqStopMenteList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypEqStopMenteListReq.strMsgVer)

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
            lrAry = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnEqStopMente_Upd
    '機　能：装置停止・メンテ計画登録・更新・削除
    '引　数：ltypEqStopMenteReq：装置停止・ﾒﾝﾃ計画登録構造体
    '戻り値：True:成功/False:失敗
    '作成日：2006/04/19 (Wed) 16:34:08 T.Kitagawa
    '更新日：2006/11/07 (Tue) 09:18:40 N.Kojima
    '備　考：
    '　　　：2006/08/03 (Thu) 16:10:42 T.Kitagawa　 旧停止開始日時ﾀｸﾞ（WP_STOP_START_OLD）追加（案件№01365）
    '　　　：2006/10/26 (Thu) 15:15:10 N.Kojima     要求構造体ﾒﾝﾊﾞの名称を変更。(案件№01497)
    '　　　：2006/11/07 (Tue) 09:18:40 N.Kojima     要求に"ENTRY_TIME"追加。(案件№01601)
    Public Function pubblnEqStopMente_Upd(ByRef ltypEqStopMenteReq As EqStopMenteReq) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp）-送信
        Dim lstrRET            As String            '応答取得

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg

            '@初期設定
            pstrMessageName = "装置停止・メンテ計画 登録/更新/削除"
            pubblnEqStopMente_Upd = False

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypEqStopMenteReq
                '@ｼkｽﾃﾑﾌﾞﾛｯｸ
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

                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If

        '@↓2006/11/08 (Wed) 16:27:06 N.Kojima **************************************************
        '        '@旧停止開始日時
        '        If .strWPPlanStopStartOld <> vbNullString Then
        '            Call lrMsg.addString(CPstrWP_STOP_START_OLD, .strWPPlanStopStartOld)
        '        Else
        '            Call lrMsg.addString(CPstrWP_STOP_START_OLD, CPstrMsgNull)
        '        End If
        '        '@停止開始日時
        '        If .strWPPlanStopStart <> vbNullString Then
        '            Call lrMsg.addString(CPstrWP_STOP_START, .strWPPlanStopStart)
        '        Else
        '            Call lrMsg.addString(CPstrWP_STOP_START, CPstrMsgNull)
        '        End If
        '        '@停止終了日時
        '        If .strWPPlanStopEnd <> vbNullString Then
        '            Call lrMsg.addString(CPstrWP_STOP_END, .strWPPlanStopEnd)
        '        Else
        '            Call lrMsg.addString(CPstrWP_STOP_END, CPstrMsgNull)
        '        End If

                '@旧停止開始日時
                If .strWPStopStartOld <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_STOP_START_OLD, .strWPStopStartOld)
                Else
                    Call lrMsg.addString(CPstrWP_STOP_START_OLD, CPstrMsgNull)
                End If

                '@停止開始日時
                If .strWPStopStart <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_STOP_START, .strWPStopStart)
                Else
                    Call lrMsg.addString(CPstrWP_STOP_START, CPstrMsgNull)
                End If

                '@停止終了日時
                If .strWPStopEnd <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_STOP_END, .strWPStopEnd)
                Else
                    Call lrMsg.addString(CPstrWP_STOP_END, CPstrMsgNull)
                End If
        '@↑2006/11/08 (Wed) 16:27:06 N.Kojima **************************************************

                '@停止ﾙｰﾙ
                If .strWPStopRule <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_STOP_RULE, .strWPStopRule)
                Else
                    Call lrMsg.addString(CPstrWP_STOP_RULE, CPstrMsgNull)
                End If

                '@停止ｺﾒﾝﾄ
                If .strWPStopComments <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_STOP_COMMENTS, .strWPStopComments)
                Else
                    Call lrMsg.addString(CPstrWP_STOP_COMMENTS, CPstrMsgNull)
                End If

                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If

                '@最終更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If

        '@↓2006/11/07 (Tue) 09:16:54 N.Kojima **************************************************

                '@登録日時
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If

                '@ｶﾃｺﾞﾘID
                If .strCategoryID <> vbNullString Then
                    Call lrMsg.addString(CPstrCATEGORY_ID, .strCategoryID)
                Else
                    Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
                End If

        '@↑2006/11/07 (Tue) 09:16:54 N.Kojima **************************************************

            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__schwpmentechg, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnEqStopMente_Upd = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypEqStopMenteReq.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMasMenteCategoryList_Sel
    '機　能：ｶﾃｺﾞﾘ取得
    '引　数：lstrmas_mentecategorylistVer   ：MsgVer
    '　　　：ltypMenteCategoryList()        ：ﾎﾟｲﾝﾄ格納用配列
    '　　　：llngMenteCategoryListCnt       ：ﾎﾟｲﾝﾄ格納数
    '戻り値：True:成功/Flase：失敗
    '作成日：2006/08/01 (Tue) 15:48:46 N.Kojima
    '更新日：2006/08/01 (Tue) 15:48:46
    '備　考：
    Public Function pubblnMasMenteCategoryList_Sel(ByVal lstrmas_mentecategorylistVer As String, _
                                                   ByRef ltypMenteCategoryList As List(Of MenteCategoryList), _
                                                   ByRef llngMenteCategoryListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "カテゴリ取得"
            pubblnMasMenteCategoryList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_mentecategorylistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_mentecategorylistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_mentecategorylist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得

                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrCATEGORY_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    llngMenteCategoryListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngMenteCategoryListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得

                        '@配列の要素数を設定
                        If ltypMenteCategoryList Is Nothing Then
                            ltypMenteCategoryList = New List(Of MenteCategoryList)
                        Else
                            ltypMenteCategoryList.Clear
                        End If
                        Dim ltypMenteCategoryListTmp As New MenteCategoryList

                        '@ｶｳﾝﾄ初期化
                        llngCnt = 0

                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With ltypMenteCategoryListTmp
                                Call ltMsg.getString(CPstrUSE_ID, .strUseId)            '用途ID
                                Call ltMsg.getString(CPstrUSE_NAME, .strUseName)        '用途名
                            End With
                            ltypMenteCategoryList.Add(ltypMenteCategoryListTmp)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnMasMenteCategoryList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_mentecategorylistVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
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

    '@↓2006/11/29 (Wed) 15:05:47 N.Kojima **************************************************
    '@RX-XXで復活？。一応消さないでね。

    ''関数名：pubblnEqWpplanresultinfo_Sel
    ''機　能：装置停止予実情報取得
    ''引　数：ltypEqStopMenteListReq   ：装置停止予実情報格納用
    ''戻り値：True：成功、False：失敗
    ''作成日：2006/11/29 (Wed) 15:07:38 N.Kojima
    ''更新日：2006/11/29 (Wed) 15:07:38
    ''備　考：
    'Public Function pubblnEqWpplanresultinfo_Sel(ByRef ltypEqStopMenteListReq As EqStopMenteListReq) As Boolean
    '
    '    Dim lrMsg                   As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
    '    Dim laMsg                   As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
    '    Dim ltMsg                   As TfMsg            '受信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ&ｱﾝｻｰ）
    '    Dim lstrRET                 As String           '応答取得
    '    Dim llngCnt                 As Long             '汎用ｶｳﾝﾀ
    '    Dim llngCnt1                As Long             'ｶｳﾝﾄ用1
    '    Dim llngCnt2                As Long             'ｶｳﾝﾄ用2
    '    Dim llngCnt3                As Long             'ｶｳﾝﾄ用3
    '    Dim lrAry                   As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
    '    Dim laAry1                  As TfMsgAry         '受信ｱﾚｰ用1
    '    Dim laAry2                  As TfMsgAry         '受信ｱﾚｰ用2
    '    Dim laAry3                  As TfMsgAry         '受信ｱﾚｰ用3
    '    Dim ltMsg1                  As TfMsg            'ｱﾚｰの各要素作成用
    '    Dim ltMsg2                  As TfMsg            'ｱﾚｰの各要素作成用
    '    Dim ltMsg3                  As TfMsg            'ｱﾚｰの各要素作成用
    '
    '    Dim llngPlanResultInfoCnt   As Long             '装置停止予実ﾘｽﾄｶｳﾝﾀ
    '
    '    On Error GoTo Error_Handler
    '
    '    pstrMessageName = "装置停止予実情報取得"
    '    pubblnEqWpplanresultinfo_Sel = False
    '
    '    Set lrMsg = New TfMsg
    '    Set laMsg = New TfMsg
    '    Set ltMsg = New TfMsg
    '    Set ltMsg1 = New TfMsg
    '    Set ltMsg2 = New TfMsg
    '    Set ltMsg3 = New TfMsg
    '    Set lrAry = New TfMsgAry
    '    Set laAry1 = New TfMsgAry
    '    Set laAry2 = New TfMsgAry
    '    Set laAry3 = New TfMsgAry
    '
    '    '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
    '    With ltypEqStopMenteListReq
    '        '@ｼｽﾃﾑﾌﾞﾛｯｸ
    '        If .strSBID <> vbNullString Then
    '            Call lrMsg.addString(CPstrSB_ID, .strSBID)
    '        Else
    '            Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
    '        End If
    '
    '        '@Msgﾊﾞｰｼﾞｮﾝ
    '        If .strMsgVer <> vbNullString Then
    '            Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
    '        Else
    '            Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
    '        End If
    '
    '        '@処理区分
    '        If .strClassDivision <> vbNullString Then
    '            Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
    '        Else
    '            Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
    '        End If
    '
    '        '@装置ｸﾞﾙ^ﾌﾟID
    '        If .strMcGroupID <> vbNullString Then
    '            Call lrMsg.addString(CPstrMC_GROUP_ID, .strMcGroupID)
    '        Else
    '            Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
    '        End If
    '
    '        '@検索開始日
    '        If .strStartDate <> vbNullString Then
    '            Call lrMsg.addString(CPstrSTART_DATE, .strStartDate)
    '        Else
    '            Call lrMsg.addString(CPstrSTART_DATE, CPstrMsgNull)
    '        End If
    '
    '        '@検索開始時刻
    '        If .strStartTime <> vbNullString Then
    '            Call lrMsg.addString(CPstrSTART_TIME, .strStartTime)
    '        Else
    '            Call lrMsg.addString(CPstrSTART_TIME, CPstrMsgNull)
    '        End If
    '
    '        '@検索終了日
    '        If .strEndDate <> vbNullString Then
    '            Call lrMsg.addString(CPstrEND_DATE, .strEndDate)
    '        Else
    '            Call lrMsg.addString(CPstrEND_DATE, CPstrMsgNull)
    '        End If
    '
    '        '@検索終了時刻
    '        If .strEndTime <> vbNullString Then
    '            Call lrMsg.addString(CPstrEND_TIME, .strEndTime)
    '        Else
    '            Call lrMsg.addString(CPstrEND_TIME, CPstrMsgNull)
    '        End If
    '
    '        '@装置ﾘｽﾄ
    '        For llngCnt = 1 To .lngWPCnt
    '            If .typWPList(llngCnt).strWpID <> vbNullString Then
    '                Call ltMsg.addString(CPstrWP_ID, .typWPList(llngCnt).strWpID)
    '            Else
    '                Call ltMsg.addString(CPstrWP_ID, CPstrMsgNull)
    '            End If
    '            Call lrAry.Add(ltMsg)
    '            ltMsg.Clear
    '        Next llngCnt
    '
    '        Call lrMsg.addMsgAry(CPstrWP_LIST, lrAry)
    '        lrAry.Clear
    '
    '        '@ｶﾃｺﾞﾘﾘｽﾄ
    '        For llngCnt = 1 To .lngCategoryCnt
    '            If .typCategoryList(llngCnt).strCategoryID <> vbNullString Then
    '                Call ltMsg.addString(CPstrCATEGORY_ID, .typCategoryList(llngCnt).strCategoryID)
    '            Else
    '                Call ltMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
    '            End If
    '            Call lrAry.Add(ltMsg)
    '            ltMsg.Clear
    '        Next llngCnt
    '
    '        Call lrMsg.addMsgAry(CPstrCATEGORY_LIST, lrAry)
    '        lrAry.Clear
    '    End With
    '
    '    '@ﾒｯｾｰｼﾞ送信
    '    Call pTerm.sendRequest(CPstreq__wpplanresultinfo, lrMsg, laMsg)
    '
    '    '@受信結果取得
    '    Call laMsg.getString(CPstrRET, lstrRET)
    '
    '    '@結果判定
    '    Select Case lstrRET
    '        '@成功の場合(true)
    '        Case CPstrTRUE
    '
    '            With ptypEqStopMenteDetailList
    '
    '                '@受信ﾒｯｾｰｼﾞｱﾚｲ3取得
    '                Call laMsg.getMsgAry(CPstrPLAN_RESULT_INFO_LIST, laAry1)
    '                '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
    '                .lngDateCnt = laAry1.Count
    '
    '                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
    '                If .lngDateCnt > 0 Then
    '
    '                    '@領域確保
    '                    ReDim Preserve .typDateList(.lngDateCnt)
    '                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1から各Msg取得
    '                    llngCnt1 = 1
    '
    '                    For Each ltMsg1 In laAry1
    '                        With .typDateList(llngCnt1)
    '
    '                            '@ﾃﾞｰﾀ格納
    '                            Call ltMsg2.getString(CPstrDATE, .strDate)              '日付
    '                            Call ltMsg2.getString(CPstrDATE_CLASS, .strDateClass)   '日付種別
    '
    '                            '@受信ﾒｯｾｰｼﾞｱﾚｲ2取得
    '                            Call ltMsg1.getMsgAry(CPstrWP_LIST, laAry2)
    '                            '@受信ﾒｯｾｰｼﾞｱﾚｲ2のｶｳﾝﾄ数
    '                            .lngWPNameCnt = laAry2.Count
    '
    '                            '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
    '                            If .lngWPNameCnt > 0 Then
    '
    '                                '@領域確保
    '                                ReDim Preserve .typWPNameList(.lngWPNameCnt)
    '                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各Msg取得
    '                                llngCnt2 = 1
    '
    '                                For Each ltMsg2 In laAry2
    '                                    With .typWPNameList(llngCnt2)
    '                                        '@ﾃﾞｰﾀ格納
    '                                        Call ltMsg2.getString(CPstrWP_NAME, .strWPName)     '装置名
    '
    '                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ3取得
    '                                        Call ltMsg2.getMsgAry(CPstrPLAN_RESULT_LIST, laAry3)
    '                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ3のｶｳﾝﾄ格納
    '                                        .lngEqStopMenteListCnt = laAry3.Count
    '
    '                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
    '                                        If .lngEqStopMenteListCnt > 0 Then
    '
    '                                            '@領域確保
    '                                            ReDim Preserve .typEqStopMenteList(.lngEqStopMenteListCnt)
    '                                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
    '                                            llngCnt3 = 1
    '
    '                                            For Each ltMsg3 In laAry3
    '
    '                                                With .typEqStopMenteList(llngCnt3)
    '                                                    '@ﾃﾞｰﾀ格納
    '                                                    Call ltMsg3.getString(CPstrWP_STOP_START, .strWPStopStart)          '停止開始時間
    '                                                    Call ltMsg3.getString(CPstrWP_STOP_END, .strWPStopEnd)              '停止終了時間
    '                                                    Call ltMsg3.getString(CPstrWP_STOP_COMMENTS, .strWPStopComments)    '停止ｺﾒﾝﾄ
    '                                                End With
    '
    '                                                '@ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
    '                                                llngCnt3 = llngCnt3 + 1
    '                                            Next
    '                                        End If
    '
    '                                        '@ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
    '                                        llngCnt2 = llngCnt2 + 1
    '                                    End With
    '                                Next
    '                            End If
    '
    '                            '@ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
    '                            llngCnt1 = llngCnt1 + 1
    '                        End With
    '                    Next
    '                End If
    '            End With
    '
    '            '@関数の処理結果(成功)格納
    '            pubblnEqWpplanresultinfo_Sel = True
    '
    '        '@失敗の場合(false)
    '        Case CPstrFALSE
    '
    '            '@ﾊﾞｰｼﾞｮﾝ判定
    '            Call pubstrErrMsg_Set(laMsg, ltypEqStopMenteListReq.strMsgVer)
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
    '    Set ltMsg = Nothing
    '    Set ltMsg1 = Nothing
    '    Set ltMsg2 = Nothing
    '    Set ltMsg3 = Nothing
    '    Set lrAry = Nothing
    '    Set laAry1 = Nothing
    '    Set laAry2 = Nothing
    '    Set laAry3 = Nothing
    '
    '    Exit Function
    '
    ''@例外処理
    'Error_Handler:
    '
    '    '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
    '    Set lrMsg = Nothing
    '    Set laMsg = Nothing
    '    Set ltMsg = Nothing
    '    Set ltMsg1 = Nothing
    '    Set ltMsg2 = Nothing
    '    Set ltMsg3 = Nothing
    '    Set lrAry = Nothing
    '    Set laAry1 = Nothing
    '    Set laAry2 = Nothing
    '    Set laAry3 = Nothing
    '
    '    '@表示ﾒｯｾｰｼﾞ変換
    '    Call pubErrMsg_Proc(Err)
    '
    'End Function
    '@↑2006/11/29 (Wed) 15:05:47 N.Kojima **************************************************
End Module
