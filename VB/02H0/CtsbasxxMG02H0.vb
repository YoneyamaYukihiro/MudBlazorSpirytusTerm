'ﾌｧｲﾙ名：xxEN02H0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：無機対向基板紐付/蒸着バッチ情報 標準モジュール
'作成日：2010/03/05 (Fri) 10:20:17 T.Oide
'更新日：2010/03/05 (Fri) 10:20:17
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02H0
    '*******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Private ====================================
    '@Nothing

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Private ====================================
    '@Nothing

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Private ====================================
    '@Nothing

    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Private ====================================
    Private lstrDummy                 As String             'ﾀﾞﾐｰ変数(処理内で使用はなし。ﾍｯﾀﾞｰ宣言との境界線作成の為)

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '@Nothing
    '================================== Friend =====================================
    '@Nothing

    '================================== Private ====================================
    ''関数名：Main
    ''機　能：ﾒｲﾝ関数
    ''引　数：なし
    ''戻り値：なし
    ''作成日：2010/03/05 (Fri) 10:20:17 T.Oide
    ''更新日：2010/03/05 (Fri) 10:20:17
    ''備　考：
    ''　　　：ｺﾏﾝﾄﾞﾗｲﾝの引数内容
    ''　　　：lstrCommand(0)：ｼｽﾃﾑﾌﾞﾛｯｸ
    ''　　　：lstrCommand(1)：ﾚｽﾎﾟﾝｽ表示（D:表示、なし:非表示）

    'Private Sub Main()
    
    '    Dim llngRet                 As Long         '戻り値
    '    Dim lblnAns                 As Boolean      '戻り値
    '    Dim ltypCommonInfoDummy     As CommonInfo   'ﾀﾞﾐｰ構造体
    '    Dim lblnAnsInit             As Boolean      '戻り値
    '    Dim lstrTitle               As String       'ﾀｲﾄﾙ
    '    Dim lstrFormName            As String       'ﾌｫｰﾑ名
    
    '    '@=======================
    '    '@　起動引数確認処理
    '    '@=======================
    '    lblnAns = pubblnCommand_Chk
    
    '    '@起動引数確認処理結果が"False:確認結果NG"か
    '    If lblnAns = False Then
    '        '@起動引数確認処理結果：NGの場合

    '        '@ﾒｯｾｰｼﾞ名(ｴﾗｰMsgBox用)の設定
    '        pstrMessageName = "起動"
        
    '        '@表示ﾒｯｾｰｼﾞ変換
    '        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0070)
    '        '@ﾒｯｾｰｼﾞ表示:"<TRM70W>$$起動時の情報が不足しています。システム担当者に連絡してください。"
    '        Call publngMsgBox(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
        
    '        End
    '    End If
    
    '    '@=======================
    '    '@　ACT初期化処理
    '    '@=======================
    '    lblnAnsInit = pubblnAct_Init
    
    '    '@ACT初期化処理結果が"False:初期化失敗"か
    '    If lblnAnsInit = False Then
    '        '@ACT初期化処理結果：初期化失敗の場合
    '        End
    '    End If
    
    '    '@=======================
    '    '@　機能関連情報取得処理
    '    '@=======================
    '    Call pubblnFuncInfo_Set
    
    '    '@=======================
    '    '@　機能ID照合、ﾌｫｰﾑ名称取得処理
    '    '@=======================
    '    Call pubMenuItemCorrelation_Set(CPstrKeyEN02H0, lstrTitle, , lstrFormName)
    
    '    '@ACT初期化ﾌﾗｸﾞに"True:初期化成功"をｾｯﾄ
    '    pblnActInitFlg = True
    
    '    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '    '@　無機対向基板紐付/蒸着バッチ情報画面　表示処理
    '    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '    Call frmxxEN02H0.Show(vbModal)
    
    'End Sub

    '関数名：pubblnRelationMKLotList_Sel
    '機　能：引数のﾛｯﾄ(TFTとCFﾛｯﾄの可能性あり)から、緋付くMKﾛｯﾄのﾘｽﾄを返却する
    '引　数：strLotID：ﾛｯﾄID
    '　　　：CMstrCF_FLAG：0：TFT、1：CF
    '戻り値：
    '作成日：2010/03/10 (Wed) 13:20:30 T.Oide
    '更新日：2010/03/10 (Wed) 13:20:30
    '備　考：
    Public Function pubblnRelationMKLotList_Sel(ByVal lstrlot_relationmklotlistVer As String, _
                                                ByVal lstrLotID As String, _
                                                ByVal lstrCF_FLAG As String, _
                                                ByRef ltypRelationMKLotList As typRelationMKLotList) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry             '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        Dim llngCnt             As Integer              'ｶｳﾝﾀ

        Try

            pstrMessageName = "紐付きMKロットリスト取得"
            pubblnRelationMKLotList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)                 'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            If lstrCF_FLAG <> vbNullString Then
                 Call lrMsg.addString(CPstrCF_FLAG, lstrCF_FLAG)            'CFﾌﾗｸﾞ
            Else
                Call lrMsg.addString(CPstrCF_FLAG, CPstrMsgNull)
            End If

            If lstrlot_relationmklotlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_relationmklotlistVer)        'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_relationmklotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getMsgAry(CPstrMK_LOT_LIST, laAry)                        'MKﾛｯﾄﾘｽﾄ

                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypRelationMKLotList.lngCnt = laAry.Count

                        '@配列の要素数を設定
                        ltypRelationMKLotList.typRelationMKLot = New List(Of typRelationMKLot)(ltypRelationMKLotList.lngCnt)
                        llngCnt = 1
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypRelationMKLotTmp As New typRelationMKLot
                            With ltypRelationMKLotTmp
                                Call ltMsg.getString(CPstrMK_LOT_ID, .strMKLot)          'MKﾛｯﾄID
                            End With
                            llngCnt = llngCnt + 1
                            ltypRelationMKLotList.typRelationMKLot.Add(ltypRelationMKLotTmp)
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnRelationMKLotList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_relationmklotlistVer)

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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnVACFHistory_Sel
    '機　能：無機CFの払出履歴取得
    '引　数：lstrlot_holdinfoVer：
    '　　　：lstrLotID：
    '　　　：ltypLotHoldInfoList：
    '戻り値：
    '作成日：2010/03/08 (Mon) 15:03:10 T.Oide
    '更新日：2010/03/08 (Mon) 15:03:10
    '備　考：
    Public Function pubblnVaCFIsueHistory_Sel(ByVal lstrinv_mkissuehistoryVer As String, _
                                              ByVal pstrCFLotID As String, _
                                              ByRef ltypeCFIssueHistory As typeCFIssueHistory) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry             '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        Dim llngCnt             As Integer              'ｶｳﾝﾀ
        
        
        Try

            pstrMessageName = "CF払出履歴情報取得"
            pubblnVaCFIsueHistory_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            If pstrCFLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, pstrCFLotID)                      'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            If lstrinv_mkissuehistoryVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_mkissuehistoryVer)     'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_mkissuehistory, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    With ltypeCFIssueHistory
                    
                        '@受信結果取得
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                        'ﾛｯﾄID
                        Call laMsg.getString(CPstrPART_CODE, .strPartCode)                  '部品
                        Call laMsg.getString(CPstrPRODUCTION_LOT_ID, .strProductionLotId)   '製造ﾛｯﾄID
                        
                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrHISTORY_LIST, laAry)   '保留ﾘｽﾄ
            
                        '@ｱﾚｰの数が0じゃなければ処理
                        If laAry.Count <> 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            .lngtypeHistoryListCnt = laAry.Count
            
                            '@配列の要素数を設定
                            .typeHistoryList = New List(Of typeHistoryList)(laAry.Count)
                            llngCnt = 1
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Dim ltypeHistoryListTmp As New typeHistoryList
                                With ltypeHistoryListTmp
                                    Call ltMsg.getString(CPstrEVENT_CLASS, .strEventClass)              'ｲﾍﾞﾝﾄ区分
                                    Call ltMsg.getString(CPstrLOT_EVENT_NAME, .strEventName)            'ｲﾍﾞﾝﾄ区分名称
                                    Call ltMsg.getString(CPstrRECORD_TIME, .strRecordTime)              '登録日時
                                    Call ltMsg.getString(CPstrCHIP_QUANTITY, .strQuantity)                   '数量
                                    Call ltMsg.getString(CPstrISSUE_QUANTITY, .strIssueQuantity)        '払出数量
                                    Call ltMsg.getString(CPstrISSUE_LOT_ID, .strIssueLotID)             '払出先
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                    '作業者
                                End With
                                llngCnt = llngCnt + 1
                                .typeHistoryList.Add(ltypeHistoryListTmp)
                            Next
                        End If
            
                        '@関数の処理結果(成功)格納
                        pubblnVaCFIsueHistory_Sel = True
                    End With

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrinv_mkissuehistoryVer)

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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubMKLotRelationInfo_Sel
    '機　能：無機対向基板紐付/蒸着ﾊﾞｯﾁ情報取得
    '引　数：ltypeMKRelationBatchInfo：無機対向基板紐付/蒸着ﾊﾞｯﾁ情報格納
    '戻り値：
    '作成日：2010/03/10 (Wed) 17:10:29 T.Oide
    '更新日：2010/03/10 (Wed) 17:10:29
    '備　考：
    Public Function pubMKLotRelationInfo_Sel(ByVal lstrMKLotID As String, _
                                             ByVal lstrLotClass As String, _
                                             ByVal lstrlot_cfrelationjbatchinfVer As String, _
                                             ByRef ltypeMKRelationBatchInfo As typeMKRelationBatchInfo _
                                             ) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry             '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        Dim llngCnt             As Integer              'ｶｳﾝﾀ

        Try

            pstrMessageName = "無機対向基板紐付/蒸着ﾊﾞｯﾁ情報取得"
            pubMKLotRelationInfo_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            
            '@ﾛｯﾄID
            If lstrMKLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrMKLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄｸﾗｽ
            If lstrLotClass <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_CLASS, lstrLotClass)
            Else
                Call lrMsg.addString(CPstrLOT_CLASS, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_cfrelationjbatchinfVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_cfrelationjbatchinfVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cfrelationjbatchinf, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getMsgAry(CPstrCF_LOT_LIST, laAry)     'CFﾛｯﾄﾘｽﾄ

                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypeMKRelationBatchInfo.lngCFLotListcnt = laAry.Count

                        '@配列の要素数を設定
                        ltypeMKRelationBatchInfo.typCFLotList = New List(Of MKLotRelation)(laAry.Count)
                        llngCnt = 1
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypMKLotRelationTmp As New MKLotRelation
                            With ltypMKLotRelationTmp
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                      '機種
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)            '種別
                                Call ltMsg.getString(CPstrTHROWIN_DATE, .strTrowinTime)         '投入日
                                Call ltMsg.getString(CPstrTHROWIN_QUANTITY, .strTrowinNum)      '投入数量
                                Call ltMsg.getString(CPstrCHIP_ISSUE_QUANTITY, .strMKIsuueNum)  'MKﾛｯﾄ払出数
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                '作業者
                                Call ltMsg.getString(CPstrSTATUS, .strStatus)                   '現在状態
                            End With
                            llngCnt = llngCnt + 1
                            ltypeMKRelationBatchInfo.typCFLotList.Add(ltypMKLotRelationTmp)
                        Next
                    End If
                    
                    
                    Call laMsg.getMsgAry(CPstrMK_LOT_LIST, laAry)       'MKﾛｯﾄﾘｽﾄ

                    '@ｱﾚｰの各要素取得(mkﾛｯﾄは必ず1ｱﾚｰしかない)
                    For Each ltMsg In laAry
                        With ltypeMKRelationBatchInfo.typMKLot
                            Call ltMsg.getString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                            Call ltMsg.getString(CPstrPD_ID, .strPdId)                      '機種
                            Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)            '種別
                            Call ltMsg.getString(CPstrTHROWIN_DATE, .strTrowinTime)         '投入日
                            Call ltMsg.getString(CPstrTHROWIN_QUANTITY, .strTrowinNum)      '投入数量
                            Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)            'ｷｬﾘｱID
                            Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                '作業者
                            Call ltMsg.getString(CPstrSTATUS, .strStatus)                   '現在状態
                        End With
                    Next


                    Call laMsg.getMsgAry(CPstrTP_LOT_LIST, laAry)       'TPﾛｯﾄﾘｽﾄ

                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypeMKRelationBatchInfo.lngTpLotListCnt = laAry.Count
                        
                        '@配列の要素数を設定
                        ltypeMKRelationBatchInfo.typTPLotList = New List(Of MKLotRelation)(laAry.Count)
                        llngCnt = 1
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypMKLotRelation As New MKLotRelation
                            With ltypMKLotRelation
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                      '機種
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)            '種別
                                Call ltMsg.getString(CPstrTHROWIN_DATE, .strTrowinTime)         '投入日
                                Call ltMsg.getString(CPstrTHROWIN_QUANTITY, .strTrowinNum)      '投入数量
                                Call ltMsg.getString(CPstrCF_AREA, .strLR)                      '左/右
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                '作業者
                                Call ltMsg.getString(CPstrSTATUS, .strStatus)                   '現在状態
                            End With
                            llngCnt = llngCnt + 1
                            ltypeMKRelationBatchInfo.typTPLotList.Add(ltypMKLotRelation)
                        Next
                    
                    End If
                    
                    
                    Call laMsg.getMsgAry(CPstrTFT_LOT_LIST, laAry)      'TFTﾛｯﾄﾘｽﾄ
                    
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypeMKRelationBatchInfo.lngTFTLotListCnt = laAry.Count
                        
                        '@配列の要素数を設定
                        ltypeMKRelationBatchInfo.typTFTLotList = New List(Of MKLotRelation)(laAry.Count)
                        llngCnt = 1
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypMKLotRelationTmp As New MKLotRelation
                            With ltypMKLotRelationTmp
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                      '機種
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)            '種別
                                Call ltMsg.getString(CPstrTHROWIN_DATE, .strTrowinTime)         '投入日
                                Call ltMsg.getString(CPstrTHROWIN_QUANTITY, .strTrowinNum)      '投入数量
                                Call ltMsg.getString(CPstrTPAL_CLASS, .strTpalClass)            'TPAL_CLASS
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                '作業者
                                Call ltMsg.getString(CPstrSTATUS, .strStatus)                   '現在状態
                            End With
                            llngCnt = llngCnt + 1
                            ltypeMKRelationBatchInfo.typTFTLotList.Add(ltypMKLotRelationTmp)
                        Next
                    End If
                    
                    
                    Call laMsg.getMsgAry(CPstrSHELF_INFO_LIST, laAry)   '蒸着バッチ棚情報
                    
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypeMKRelationBatchInfo.lngShelfInfoListcnt = laAry.Count
                    
                        '@配列の要素数を設定
                        ltypeMKRelationBatchInfo.typeShelfInfoList = New List(Of typeShelfInfo)(laAry.Count)
                        llngCnt = 1
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim ltypeShelfInfoTmp As New typeShelfInfo
                            With ltypeShelfInfoTmp
                                Call ltMsg.getString(CPstrSEQ_NUM, .strSeq)                     '順
                                Call ltMsg.getString(CPstrJIG_ID, .strjigId)                    '治具ID
                                Call ltMsg.getString(CPstrWF_ID, .strWfId)                      'ｳｪﾊｰID
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                            End With
                            llngCnt = llngCnt + 1
                            ltypeMKRelationBatchInfo.typeShelfInfoList.Add(ltypeShelfInfoTmp)
                        Next
                    
                        '@蒸着バッチ情報(上記のｱﾚｰが取得できない時はﾊﾞｯﾁ情報もない)
                        With ltypeMKRelationBatchInfo
                            Call laMsg.getString(CPstrBATCH_ID, .strBatchId)                    'ﾊﾞｯﾁID
                            Call laMsg.getString(CPstrENTRY_TIME, .strBatchTime)                'ﾊﾞｯﾁ登録日時
                            Call laMsg.getString(CPstrBATCH_WF_COUNT, .strBatchNum)             'ﾊﾞｯﾁｳｪﾊｰ数
                            Call laMsg.getString(CPstrEMP_NAME, .strEmpName)                    '作業者
                        End With
                    End If

                    '@関数の処理結果(成功)格納
                    pubMKLotRelationInfo_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_cfrelationjbatchinfVer)

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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

End Module
