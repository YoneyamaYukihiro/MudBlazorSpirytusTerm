'ﾌｧｲﾙ名：xxMG02K0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CONTｴｯﾁｬｰFR使用履歴 標準モジュール
'作成日：2014/11/11 (Tue) 17:29:51 T.Oide
'更新日：2016/06/13 (Mon) 16:45:20 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2014-2016, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02K0
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
    '関数名：Main
    '機　能：ﾒｲﾝ関数
    '引　数：なし
    '戻り値：なし
    '作成日：2014/11/11 (Tue) 17:29:51 T.Oide
    '更新日：2014/11/11 (Tue) 17:29:51
    '備　考：
    '　　　：ｺﾏﾝﾄﾞﾗｲﾝの引数内容
    '　　　：lstrCommand(0)：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrCommand(1)：ﾚｽﾎﾟﾝｽ表示（D:表示、なし:非表示）
    Private Sub Main()
        
        Dim lblnAns                 As Boolean      '戻り値
        Dim lblnAnsInit             As Boolean      '戻り値
        Dim lstrTitle               As String       'ﾀｲﾄﾙ
        Dim lstrFormName            As String       'ﾌｫｰﾑ名
        
        '@=======================
        '@　起動引数確認処理
        '@=======================
        lblnAns = pubblnCommand_Chk
        
        '@起動引数確認処理結果が"False:確認結果NG"か
        If lblnAns = False Then
            '@起動引数確認処理結果：NGの場合

            '@ﾒｯｾｰｼﾞ名(ｴﾗｰMsgBox用)の設定
            pstrMessageName = "起動"
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0070)
            '@ﾒｯｾｰｼﾞ表示:"<TRM70W>$$起動時の情報が不足しています。システム担当者に連絡してください。"
            Call publngMsgBox(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
            End
        End If
        
        '@=======================
        '@　ACT初期化処理
        '@=======================
        lblnAnsInit = pubblnAct_Init
        
        '@ACT初期化処理結果が"False:初期化失敗"か
        If lblnAnsInit = False Then
            '@ACT初期化処理結果：初期化失敗の場合
            End
        End If
        
        '@=======================
        '@　機能関連情報取得処理
        '@=======================
        Call pubblnFuncInfo_Set
        
        '@=======================
        '@　機能ID照合、ﾌｫｰﾑ名称取得処理
        '@=======================
        Call pubMenuItemCorrelation_Set(CPstrKeyEN02K0, lstrTitle, , lstrFormName)
        
        '@ACT初期化ﾌﾗｸﾞに"True:初期化成功"をｾｯﾄ
        pblnActInitFlg = True
        
        '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@　区間優先設定画面　表示処理
        '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        frmxxEN02K0.Instance.ShowDialog()
        frmxxEN02K0.Instance = Nothing
        
    End Sub

    '関数名：pubblnFrHistry_Sel
    '機　能：FR使用履歴取得
    '引　数：strlot_SectionPriorityVer：ﾒｯｾｰｼﾞVer
    '　　　：strWpId：装置ID
    '　　　：strChanber：処理部
    '　　　：typeFbContFrHist:取得結果格納
    '戻り値：
    '作成日：2014/11/10 (Mon) 14:27:15 T.Oide
    '更新日：2016/06/13 (Mon) 16:43:54 T.Oide
    '備　考：
    Public Function pubblnFrHistry_Sel(ByVal strMsgVer As String, _
                                       ByVal strWpID As String, _
                                       ByVal strChanber As String, _
                                       ByRef typeFbContFrHist As pubTypFbContFrHist) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry             '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        Dim llngCnt             As Integer              'ｶｳﾝﾀ
        
        
        Try

            pstrMessageName = "FR使用履歴取得"
            pubblnFrHistry_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            
            If strMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, strMsgVer)                   'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If strWpID <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, strWpID)                      'WP_ID
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If

            If strChanber <> vbNullString Then
                Call lrMsg.addString(CPstrPROCESSING_ID, strChanber)           'PROCESSING_ID
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
                

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrfb__contetfrhist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    With typeFbContFrHist

                        '@受信結果取得
        '@↓2016/06/13 (Mon) 16:45:03 T.Oide **************************************************
                        Call laMsg.getString(CPstrFR_REFVAL, .strRfRefValueTime) 'FR累積使用時間異常値差異
        '@↑2016/06/13 (Mon) 16:45:03 T.Oide **************************************************
                        Call laMsg.getString(CPstrWAR_MSG_TIME, .strWarMsgTime)     'ﾜｰﾆﾝｸﾞﾒｯｾｰｼﾞ時間
                        Call laMsg.getString(CPstrERR_MSG_TIME, .strErrMsgTime)     'ｴﾗｰﾒｯｾｰｼﾞ時間
                        Call laMsg.getString(CPstrWP_ID, .strWpID)                  '装置
                        Call laMsg.getString(CPstrPROCESSING_ID, .strProcessingId)  '処理部

                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrFR_HIST_LIST, laAry)      'FR使用履歴ﾘｽﾄ

                        '@ｱﾚｰの数が0じゃなければ処理
                        If laAry.Count <> 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            .lngFbConstFrHistCnt = laAry.Count

                            '@配列の要素数を設定
                            If IsNothing(.fbConstFrHistList) Then
                                .fbConstFrHistList = New list(Of typFbConstFrHistList)
                            Else
                                .fbConstFrHistList.Clear()
                            End If
                            llngCnt = 1
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Dim item As typFbConstFrHistList
                                With item
                                    Call ltMsg.getString(CPstrFR_ID, .strFrId)                                  'FR_ID
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                    Call ltMsg.getString(CPstrRECIPE_ID, .strRrecipId)                          'ﾚｼﾋﾟID
                                    Call ltMsg.getString(CPstrACCELE_FACTER, .strAcceleFacter)                  '加速係数
                                    Call ltMsg.getString(CPstrCUMULATIVE_PROCESS_TIME, .strCumProcTime)         'FR累積使用時間
                                    Call ltMsg.getString(CPstrPROCESS_TIME, .strProcTime)                       '処理時間
                                    Call ltMsg.getString(CPstrCALC_CUMULATIVE_PROCESS_TIME, .strCalcCumProcTime) 'FR(計算)累積使用時間
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)                        '登録日時
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                            '登録者
                                End With
                                .fbConstFrHistList.Add(item)
                                llngCnt = llngCnt + 1
                            Next

                        Else
                            '@ｱﾚｰが0の場合
                            .lngFbConstFrHistCnt = laAry.Count
                        End If

                        '@関数の処理結果(成功)格納
                        pubblnFrHistry_Sel = True
                    End With

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, strMsgVer)

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

    '関数名：pubblnContFrHist_Reg
    '機　能：FR使用履歴を手動登録する
    '引　数：strlMsgVer：ﾒｯｾｰｼﾞVer
    '　　　：lTypeFbContFrHistReg：登録データ
    '戻り値：True：成功、False：失敗
    '作成日：2014/11/11 (Tue) 17:29:51 T.Oide
    '更新日：2014/11/11 (Tue) 17:29:51
    '備　考：
    Public Function pubblnContFrHist_Reg(ByVal strlMsgVer As String, _
                                         ByRef lTypeFbContFrHistReg As typFbConstFrHistReg) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        
        
        Try

            pstrMessageName = "CONTｴｯﾁｬｰFR使用履歴登録"
            pubblnContFrHist_Reg = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            With lTypeFbContFrHistReg

                '@送信ﾒｯｾｰｼﾞ作成
                
                'Msgﾊﾞｰｼﾞｮﾝ
                If strlMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, strlMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '処理部ID
                If .strProcessingId <> vbNullString Then
                    Call lrMsg.addString(CPstrPROCESSING_ID, .strProcessingId)
                Else
                    Call lrMsg.addString(CPstrPROCESSING_ID, CPstrMsgNull)
                End If
                
                'ロットID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                'ﾚｼﾋﾟID
                If .strRcipId <> vbNullString Then
                    Call lrMsg.addString(CPstrRECIPE_ID, .strRcipId)
                Else
                    Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
                End If
                
                'FR消耗度加速係数
                If .strAcceleFacter <> vbNullString Then
                    Call lrMsg.addString(CPstrACCELE_FACTER, .strAcceleFacter)
                Else
                    Call lrMsg.addString(CPstrACCELE_FACTER, CPstrMsgNull)
                End If
            
                'FR累積使用時間
                If .strCumProcTime <> vbNullString Then
                    Call lrMsg.addString(CPstrCUMULATIVE_PROCESS_TIME, .strCumProcTime)
                Else
                    Call lrMsg.addString(CPstrCUMULATIVE_PROCESS_TIME, CPstrMsgNull)
                End If
            
                '処理時間
                If .strProcTime <> vbNullString Then
                    Call lrMsg.addString(CPstrPROCESS_TIME, .strProcTime)
                Else
                    Call lrMsg.addString(CPstrPROCESS_TIME, CPstrMsgNull)
                End If
                
                'FR(計算)累積使用時間
                If .strCalcCumProcTime <> vbNullString Then
                    Call lrMsg.addString(CPstrCALC_CUMULATIVE_PROCESS_TIME, .strCalcCumProcTime)
                Else
                    Call lrMsg.addString(CPstrCALC_CUMULATIVE_PROCESS_TIME, CPstrMsgNull)
                End If

                '登録者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrfb__contetfrhistreg, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
            
                    '@関数の処理結果(成功)格納
                    pubblnContFrHist_Reg = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, strlMsgVer)
                    
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
End Module
