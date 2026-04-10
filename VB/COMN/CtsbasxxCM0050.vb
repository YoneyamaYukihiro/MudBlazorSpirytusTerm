'ﾌｧｲﾙ名：xxCM0050.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：共通ﾒｯｾｰｼﾞ処理
'作成日：2004/02/13 (Fri) 11:28:44 K.Takano
'更新日：2019/12/09 (Mon) 15:58:13 T.Oide
'備　考：
''Copyright(C)SEIKO EPSON CORPORATION 2004－2019. All rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxCM0050
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private===========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：pubblnAct_Init
    '機　能：ACTの初期化
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/02/13 (Fri) 10:05:17 K.Takano
    '更新日：2008/06/23 (Mon) 15:32:50 N.Kojima
    '備　考：2004/03/16 内作MsgBoxに変更
    '　　　：2008/06/23 (Mon) 15:32:50 N.Kojima     ｿｰｽ整備。(案件№03004)
    Public Function pubblnAct_Init() As Boolean
        
        Try
            
            '@ﾒｯｾｰｼﾞ名を設定
            pstrMessageName = "ACT初期化"
            
            '@戻り値に"False：初期化失敗"をｾｯﾄ
            pubblnAct_Init = False
            
            '@ｵﾌﾞｼﾞｪｸﾄの生成
            pTerm = New TfBase
            
            '@ｵﾌﾞｼﾞｪｸﾄの作成
            Call pTerm.init

            '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰが非表示か
            If frmxxCM0100.Instance.Visible = False Then
            
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰ　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                Call frmxxCM0100.Instance.Show
            End If
            
            '@戻り値に"True：初期化成功"をｾｯﾄ
            pubblnAct_Init = True
            
            Exit Function


        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄの解放
            pTerm = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnAct_Term
    '機　能：プログラムを終了する
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/02/13 (Fri) 10:07:09 K.Takano
    '更新日：2004/02/18 (Wed) 12:54:27 K.Takano
    '備　考：
    Public Function pubblnAct_Term() As Boolean

        '@ｽﾃｰﾀｽ画面終了
        frmxxCM0100.Instance = Nothing
        
        pubblnAct_Term = False
        
        '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
        pTerm = Nothing
        
        pubblnAct_Term = True
        
    End Function

    '関数名：pubblnResponse_Ins
    '機　能：ﾚｽﾎﾟﾝｽ測定送信
    '引　数：lstrutiltmresponseVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypTmResponse：ﾚｽﾎﾟﾝｽ測定送信構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/09 (Tue) 14:27:19 T.Kitagawa
    '更新日：2004/05/07 (Fri) 14:08:11 T.Kitagawa
    '備　考：
    Public Function pubblnResponse_Ins(ByVal lstrutiltmresponseVer As String, ByRef ltypTmResponse As TmResponse) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET            As String            '応答取得
        
        Try
            
            pstrMessageName = "レスポンス測定送信"
            pubblnResponse_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypTmResponse
                If .strHostName <> vbNullString Then
                    Call lrMsg.addString(CPstrHOST_NAME, .strHostName)          'ﾎｽﾄ名
                Else
                    Call lrMsg.addString(CPstrHOST_NAME, CPstrMsgNull)
                End If
                If .strIPaddress <> vbNullString Then
                    Call lrMsg.addString(CPstrIP_ADDRESS, .strIPaddress)        'IPｱﾄﾞﾚｽ
                Else
                    Call lrMsg.addString(CPstrIP_ADDRESS, CPstrMsgNull)
                End If
                If .strExeName <> vbNullString Then
                    Call lrMsg.addString(CPstrEXE_NAME, .strExeName)            'EXEﾌｧｲﾙ名
                Else
                    Call lrMsg.addString(CPstrEXE_NAME, CPstrMsgNull)
                End If
                If .strFormName <> vbNullString Then
                    Call lrMsg.addString(CPstrFORM_NAME, .strFormName)          '画面識別名
                Else
                    Call lrMsg.addString(CPstrFORM_NAME, CPstrMsgNull)
                End If
                If .strEventName <> vbNullString Then
                    Call lrMsg.addString(CPstrEVENT_NAME, .strEventName)        'ｲﾍﾞﾝﾄ(処理)名
                Else
                    Call lrMsg.addString(CPstrEVENT_NAME, CPstrMsgNull)
                End If
                If .strExeTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEXE_TIME, .strExeTime)            '処理時間(msecで10mｓec)
                Else
                    Call lrMsg.addString(CPstrEXE_TIME, CPstrMsgNull)
                End If
            End With
            
            If lstrutiltmresponseVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrutiltmresponseVer)      'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrutiltmresponse, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnResponse_Ins = True
                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrutiltmresponseVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@ﾒｯｾｰｼﾞBOX等は表示しない
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            'NSYS .Netで不要のため削除
            'Resume Next
            
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotCurstate_Sel
    '機　能：ﾛｯﾄ現在状態取得
    '引　数：lstrlot_curstateVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision  ：処理区分
    '　　　：lstrCarrierID      ：ｷｬﾘｱID
    '　　　：ltypLotCurState    ：ﾛｯﾄ現在状態格納構造他
    '　　　：lstrLotID          ：ﾛｯﾄID(装置ﾃﾞｰﾀ/参照登録のみ使用)
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/05/18 (Tue) 15:18:12 N.Kasai
    '更新日：2016/02/11 (Thu) 22:44:22 H.Hayashi
    '備　考：特殊特性変換処理あり
    '　　　：2004/08/24 CFﾌﾗｸﾞ追加
    '　　　：2004/09/03 (Fri) 11:15:45 T.Kitagawa　TPAL貼り合せ状態ﾌﾗｸﾞ、不良項目ｾｯﾄID　を追加
    '　　　：2004/09/09 (Thu) 17:21:08 Y.Yamagishi　応答ﾀｸﾞに警告時間を追加
    '　　　：2004/09/22 (Wed) 20:24:42 H.Wajima     流動ﾀｲﾌﾟ追加
    '　　　：2004/09/23 (Thu) 17:06:18 Y.Yamagishi　制限ﾀｲﾌﾟを追加
    '　　　：2004/09/29 (Wed) 16:01:23 N.Kasai　    応答ﾀｸﾞに保留期限追加
    '　　　：2004/10/20 (Wed) 15:02:04 S.Deguchi    追加ﾙｰﾄIDを追加
    '　　　：2004/11/22 (Mon) 16:11:49 N.Kasai      応答ﾀｸﾞにENTRY_IDを追加(ﾛｯﾄ分割統合時の判定に使用)
    '　　　：2005/02/01 (Tue) 15:33:08 H.Wajima     作業指示ﾌﾗｸﾞ削除(ｺﾒﾝﾄ化)
    '　　　：2005/05/19 (Thu) 17:22:13 N.Kasai      応答ﾀｸﾞにCF_CARRIER_ID、LP_FLAG追加
    '　　　：2005/08/29 (Mon) 10:49:28 N.Kojima     応答ﾀｸﾞにUNLOADER_CARRIER_ID追加
    '　　　：2005/09/02 (Fri) 16:08:25 N.Kasai      応答ﾀｸﾞにCHIP_CURRENT_OUT_QUANTITY追加
    '　　　：2005/11/24 (Thu) 10:30:56 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で技術担当者ID,不具合№3248の対応でｵﾌﾗｲﾝFTPﾌﾗｸﾞを追加
    '　　　：2006/03/17 (Fri) 14:30:06 N.Kasai      応答ﾒｯｾｰｼﾞにPR_ORDER_IDを追加(児島さんより依頼)
    '　　　：2006/09/08 (Fri) 14:45:15 N.Kojima     応答に"SEND_SB_ID","SEND_SB_NAME"追加。(案件№01452)
    '　　　：2006/10/31 (Tue) 15:32:44 N.Kasai      応答ﾀｸﾞ追加(LOT_SEND_FLAG 案件№01500)
    '　　　：2008/06/16 (Mon) 16:29:12 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/09 (Wed) 11:15:30 T.Inafune    応答ﾀｸﾞ削除(TO_PORT_ID/TO_PORT_NAME 案件No.01193)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    '　　　：2009/07/21 (Tue) 13:23:08 N.Kojima     無機対応Phase2、応答に"USE_ID","BATCH_SEQ_NUM","MES_MODE_ID"追加。(案件№03661)
    '　　　：2014/11/05 (Wed) 09:39:46 H.Hayashi    組立無機ODFのシステム環境整備
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnLotCurstate_Sel(ByVal lstrlot_curstateVer As String, _
                                          ByVal lstrClassDivision As String, _
                                          ByVal lstrCarrierID As String, _
                                          ByRef ltypLotCurState As Lotprestate, _
                                          Optional ByVal lstrLotID As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        'Dim llngCnt             As String          'ｶｳﾝﾄ用 NSYS 不要カウンタのため削除
        'Dim llngCnt2            As String          'ｶｳﾝﾄ用 NSYS 不要カウンタのため削除
        'Dim ltypInitLotCurState As Lotprestate     'ﾛｯﾄ現在状態構造体初期化用 NSYS 明示的にNewで初期化するため削除
        
        Try
            
            '@各種初期設定
            pstrMessageName = "ロット現在状態取得"
            pubblnLotCurstate_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry
            
            '@ﾛｯﾄ現在状態構造体初期化
            ltypLotCurState = New Lotprestate
            ltypLotCurState.strSteplist = New List(Of StepList)
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_curstateVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_curstateVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_curstate, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信結果取得
                    With ltypLotCurState

                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                                        'ﾛｯﾄID
                        Call laMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                                '流動区分
                        Call laMsg.getString(CPstrGRB_CLASS, .strGrbClass)                                  'GRB区分
                        Call laMsg.getString(CPstrPD_ID, .strPdId)                                          '機種ID
                        Call laMsg.getString(CPstrPD_NAME, .strPdName)                                      '機種名
                        Call laMsg.getString(CPstrNOW_ST, .strNowST)                                        'LOT状態
                        Call laMsg.getString(CPstrDISPATCH_START_TIME, .strDispatchStartTime)               '投入予定時刻
                        Call laMsg.getString(CPstrDISPATCH_END_TIME, .strDispatchEndTime)                   '終了予定時刻
                        Call laMsg.getString(CPstrENG_EMP_ID, .strEngEmpId)                                 'ﾛｯﾄ担当者ID
                        Call laMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                             'ﾛｯﾄ担当者名
                        Call laMsg.getString(CPstrWORK_CONDITION, .strWorkCondition)                        '作業条件
                        Call laMsg.getString(CPstrSPECIAL_FLG, .strSpecialFlg)                              '特殊特性
                        Call laMsg.getString(CPstrWF_NUM, .strWfNum)                                        'WF枚数
                        Call laMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                                '制限時間(時間制約)
                        Call laMsg.getString(CPstrCOMMENTS, .strComments)                                   'ｺﾒﾝﾄ
                        Call laMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                           '保留ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)                       'ﾛｯﾄ最終更新日時
                        Call laMsg.getString(CPstrSTART_TIME, .strStartTime)                                '作業開始時刻
                        Call laMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                          '良品ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrCHIP_OUT_QUANTITY, .strChipOutQuantity)                   '総不良品ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrCHIP_CURRENT_OUT_QUANTITY, .strChipCurrentOutQuantity)    '現不良品ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrCHIP_FORWARD_QUANTITY, .strChipForwardQuantity)                 '総払出品ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrCHIP_CURRENT_FORWARD_QUANTITY, .strChipCurrentForwardQuantity)  '現払出品ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrMAS_PD_VERSION, .strMasPdVersion)                         '機種ﾊﾞｰｼﾞｮﾝ
                        Call laMsg.getString(CPstrWP_TYPE_FLAG, .strWpTypeFlag)                             'WPﾀｲﾌﾟﾌﾗｸﾞ
                        Call laMsg.getString(CPstrEQ_TYPE, .strEqType)                                      '装置ﾀｲﾌﾟ
                        Call laMsg.getString(CPstrCOLLECTION_ID, .strCollectionID)                          '収集項目ID
                        Call laMsg.getString(CPstrCOLLECTION_VERSION, .strCollectionVersion)                '収集項目ﾊﾞｰｼﾞｮﾝ
                        Call laMsg.getString(CPstrBATCH_ID, .strBatchId)                                    'ﾊﾞｯﾁID
                        Call laMsg.getString(CPstrCARRIER_ID, .strCarrierId)                                'ｷｬﾘｱID
                        Call laMsg.getString(CPstrREWORK_ROUTE_ID, .strReworkRouteID)                       'ﾘﾜｰｸﾙｰﾄID
                        Call laMsg.getString(CPstrCF_FLAG, .strCfFlag)                                      'CFﾌﾗｸﾞ(0；CFﾛｯﾄ以外　1；CFﾛｯﾄ)
                        Call laMsg.getString(CPstrLP_FLAG, .strLpFlag)                                      'LPﾌﾗｸﾞ(0；小判(TPAL) 1；大判(ODF))
                        Call laMsg.getString(CPstrCF_MOVEDATA_FLAG, .strCFMoveDataFlag)                     'CF移載ﾃﾞｰﾀﾌﾗｸﾞ(0:CF移載情報登録なし　1:CF移載情報登録あり)
                        Call laMsg.getString(CPstrCF_COMP_FLAG, .strCfCompFlag)                             'CFﾛｯﾄ確定可能ﾌﾗｸﾞ(0；CFﾛｯﾄ確定不可　1；CFﾛｯﾄ確定可能)
                        Call laMsg.getString(CPstrCARRIER_TYPE_ID, .strCarrierTypeID)                       'ｷｬﾘｱﾀｲﾌﾟID
                        Call laMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                              'ﾘﾜｰｸﾌﾗｸﾞ
                        Call laMsg.getString(CPstrCOVER_FLAG, .strCoverFlag)                                'TPAL貼り合せ状態ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLOT_SCRAP_SET_ID, .strLotScrapSetID)                      '不良項目ｾｯﾄID
                        Call laMsg.getString(CPstrWARN_TIME, .strWarnTime)                                  '警告時間
                        Call laMsg.getString(CPstrFLOW_TYPE, .strFlowType)                                  '流動ﾀｲﾌﾟ
                        Call laMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)                     '制限ﾀｲﾌﾟ
                        Call laMsg.getString(CPstrHOLD_TERM_DATE, .strHoldTermDate)                         '保留期限
                        Call laMsg.getString(CPstrSPECIAL_ROUTE_ID, .strSpecialRouteID)                     '追加ﾙｰﾄID
                        Call laMsg.getString(CPstrENTRY_ID, .strEntryID)                                    'ｴﾝﾄﾘID
                        Call laMsg.getString(CPstrCF_CARRIER_ID, .strCFCarrierID)                           'CFｷｬﾘｱID
                        Call laMsg.getString(CPstrLP_FLAG, .strLpFlag)                                      '大板ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrUNLOADER_CARRIER_ID, .strUnloaderCarrierID)               'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                        Call laMsg.getString(CPstrFTP_DATA_FLAG, .strFtpDataFlag)                           'FTPﾃﾞｰﾀﾌﾗｸﾞ
                        Call laMsg.getString(CPstrPR_ORDER_ID, .strPROrderID)                               'P/RｵｰﾀﾞｰID
                        Call laMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                                 '送品先ID
                        Call laMsg.getString(CPstrSEND_SB_NAME, .strSendSBName)                             '送品先名(和名)
                        Call laMsg.getString(CPstrLOT_SEND_FLAG, .strLotSendFlag)                           '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
                        Call laMsg.getString(CPstrVA_FLAG, .strVaFlag)                                      '無機ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrTPAL_CLASS, .strTpalClass)                                'TPAL設定
                        Call laMsg.getString(CPstrTPAL_CHIP_QUANTITY, .strTpalChipQuantity)                 'TPAL貼合数
                        Call laMsg.getString(CPstrCARRIER_CATEGORY_ID, .strCarrierCategoryId)               'ｷｬﾘｱｶﾃｺﾞﾘID(現工程)
                        Call laMsg.getString(CPstrNEXT_CARRIER_CATEGORY_ID, .strNextCarrierCategoryId)      'ｷｬﾘｱｶﾃｺﾞﾘID(次工程)
                        Call laMsg.getString(CPstrUSE_ID, .strUseId)                                        '機種区分
                        Call laMsg.getString(CPstrBATCH_SEQ_NUM, .strBatchSeqNum)                           'ﾊﾞｯﾁ処理順
                        Call laMsg.getString(CPstrMES_MODE_ID, .strMesModeId)                               '運用ﾓｰﾄﾞ
                        Call laMsg.getString(CPstrSCREEN_SIZE_ID, .strScreenSize)                           'ｽｸﾘｰﾝｻｲｽﾞ
                        Call laMsg.getString(CPstrTOKUSYU, .strTokusyu)                                     '(パ検)特殊表示
                        Call laMsg.getString(CPstrCOLOR_CD, .strColorCd)                                    '指定色
                        '@↓2020/01/15 (Wed) 13:52:46 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        Call laMsg.getString(CPstrTRV_GRB_CLASS, .strTrvGRBClass)                           '流動票GRB
                        '@↑2020/01/15 (Wed) 13:52:46 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                        
                        '@★ 特殊特性ﾌﾗｸﾞにより処理分岐 ★
                        Select Case .strSpecialFlg
                            
                            '@〓 0：非表示 〓
                            Case CPstrSpNull

                                .strSpecialFlg = vbNullString
                            
                            '@〓 1、2、その他(その他はありえない)： 〓
                            Case Else
                            
                                '@処理なし
                        
                        End Select
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：工程ﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrSTEP_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：工程ﾘｽﾄﾃﾞｰﾀ数
                        ltypLotCurState.lngStepListCnt = laAry.Count
                        
                        '@工程ﾘｽﾄﾃﾞｰﾀ数が1件以上存在するか
                        If ltypLotCurState.lngStepListCnt > 0 Then
                            
                            '@配列領域の確保
                            'ReDim ltypLotCurState.strSteplist(laAry.Count) NSYS ループ処理内へ移動
                            
                            '@ｶｳﾝﾀの初期化
                            'llngCnt = 1 NSYS 不要カウンタのため削除
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry

                                'NSYS 編集用構造体初期化
                                Dim stepListTmp = New stepList
                                stepListTmp.strWPList = New List(Of WP)
                            
                                With stepListTmp

                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                  '大工程ID
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)              '次小工程ID
                                    Call ltMsg.getString(CPstrSTEP_DIVISION, .strStepDivision)  '工程ﾌﾗｸﾞ(1:ﾃﾞﾌｫﾙﾄ、0:代替)
                                    Call ltMsg.getString(CPstrALT_NUMBER, .strAltNumber)        '代替番号

                                    '@工程区分が"1:ﾃﾞﾌｫﾙﾄ"か
                                    If .strStepDivision = "1" Then
                                    
                                        '@大工程IDがNULLか
                                        If ltypLotCurState.strOpID = vbNullString Then
                                            '@ﾃﾞﾌｫﾙﾄとして設定
                                            ltypLotCurState.strOpID = .strOpID                  '大工程ID(ﾃﾞﾌｫﾙﾄ)
                                            ltypLotCurState.strStepID = .strStepID              '小工程ID(ﾃﾞﾌｫﾙﾄ)
                                            ltypLotCurState.strAltNumber = .strAltNumber        '代替番号(ﾃﾞﾌｫﾙﾄ)
                                        End If
                                    Else
                                        '@工程区分が"1:ﾃﾞﾌｫﾙﾄ"以外の場合
                                        
                                        '@工程ﾘｽﾄが1件か
                                        If ltypLotCurState.lngStepListCnt = 1 Then
                                            '@1件のﾃﾞｰﾀをﾃﾞﾌｫﾙﾄとして設定
                                            ltypLotCurState.strOpID = .strOpID                  '大工程ID(ﾃﾞﾌｫﾙﾄ)
                                            ltypLotCurState.strStepID = .strStepID              '小工程ID(ﾃﾞﾌｫﾙﾄ)
                                            ltypLotCurState.strAltNumber = .strAltNumber        '代替番号(ﾃﾞﾌｫﾙﾄ)
                                        End If
                                    End If
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：装置ﾘｽﾄ
                                    Call ltMsg.getMsgAry(CPstrWP_LIST, laAry2)
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2数：装置ﾘｽﾄﾃﾞｰﾀ数
                                    .lngWpListCnt = laAry2.Count
                                    
                                    '@装置ﾘｽﾄﾃﾞｰﾀ数が1件以上存在するか
                                    If .lngWpListCnt > 0 Then
                                    
                                        '@配列領域の確保
                                        'ReDim ltypLotCurState.strSteplist(llngCnt).strWPList(laAry2.Count) NSYS ループ処理内へ移動
                                        
                                        '@ｶｳﾝﾀの初期化 NSYS 不要カウンタのため削除
                                        'llngCnt2 = 1
                                        
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                                        For Each ltMsg2 In laAry2

                                            'NSYS 編集用構造体初期化
                                            Dim typWPTmp = New WP
                                        
                                            With typWPTmp
                                                
                                                '@受信ﾃﾞｰﾀ格納
                                                Call ltMsg2.getString(CPstrWP_ID, .strWpID)         '装置ID
                                                Call ltMsg2.getString(CPstrWP_NAME, .strWpName)     '装置名
                                                
                                                '@工程と装置が1件、かつ装置ﾘｽﾄが1件か
                                                If ltypLotCurState.lngStepListCnt = 1 _
                                                    And stepListTmp.lngWpListCnt = 1 Then
                                                    
                                                    '@受信ﾃﾞｰﾀ格納
                                                    ltypLotCurState.strWpID = .strWpID              '装置ID
                                                    ltypLotCurState.strWpName = .strWpName          '装置名
                                                End If
                                            End With

                                            'NSYS 編集済み構造体を追加
                                            stepListTmp.strWPList.Add(typWPTmp)
                                            
                                            '@ｶｳﾝﾀ2を+1する  NSYS 不要カウンタのため削除
                                            'llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                End With

                                'NSYS 編集済み構造体を追加
                                ltypLotCurState.strSteplist.Add(stepListTmp)
                                
                                '@ｶｳﾝﾀを+1する NSYS 不要カウンタのため削除
                                'llngCnt = llngCnt + 1
                            Next
                        Else
                            '@工程ﾘｽﾄﾃﾞｰﾀ数が0件の場合
                            
                            '@工程ﾘｽﾄﾃﾞｰﾀｶｳﾝﾄに0を格納
                            ltypLotCurState.lngStepListCnt = 0
                        End If
                        
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotCurstate_Sel = True
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_curstateVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            laAry = Nothing
            laAry2 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            laAry = Nothing
            laAry2 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnLotrecplist_Sel
    '機　能：WF別ﾚｼﾋﾟ情報の取得
    '引　数：lstrlot_recplistVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID：ﾛｯﾄID
    '　　　：lstrOpID：大工程ID
    '　　　：lstrStepID：小工程ID
    '　　　：lstrWPID：装置ID
    '　　　：llngLotRecpListCnt：ﾚｼﾋﾟﾘｽﾄ件数
    '　　　：lstrOriginalRecpFlag：個別ﾚｼﾋﾟﾌﾗｸﾞ(0：設定なし、1：個別ﾚｼﾋﾟ)
    '　　　：lstrProcChangeRecipeFlag：工順変更ﾚｼﾋﾟﾌﾗｸﾞ(0：ﾚｼﾋﾟ変更可、1:ﾚｼﾋﾟ変更不可)
    '　　　：lstrUserSelectFlag：ﾕｰｻﾞｰ選択ﾌﾗｸﾞ(0：ﾚｼﾋﾟ変更不可、1:ﾚｼﾋﾟ変更可)
    '　　　：lstrVariableResult：ﾚｼﾋﾟ値ﾃﾞｰﾀ有無(0:なし、1:あり) 入力可能なレシピパラメータがあるかどうか
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/04 (Thu) 16:33:15 T.Kitagawa
    '更新日：2006/03/16 (Thu) 14:01:19 N.Kasai
    '備　考：WF別ﾚｼﾋﾟﾘｽﾄ構造体(ptypLotrecpList)へｾｯﾄ
    '　　　：2004/09/03 (Fri) 16:30:01 M.Miura　個別ﾚｼﾋﾟﾌﾗｸﾞ、工順変更ﾌﾗｸﾞ追加(不具合№270)
    '　　　：2004/09/20 (Mon) 14:54:44 Y.Yamagishi　処理区分"23"の時,ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄを返してもらうように修正(不具合№722)
    '　　　：2004/09/28 (Tue) 14:14:36 M.Miura　引数と受信結果にﾕｰｻﾞｰ選択ﾌﾗｸﾞを追加(不具合№963)
    '　　　：2005/01/31 (Mon) 12:39:06 N.Kasai  応答msgにVARIABLE_FLAG、VALUE_TYPE追加(不具合№304)
    '　　　：2006/03/16 (Thu) 14:01:19 N.Kasai  応答に小数点以下制御追加
    Public Function pubblnLotrecplist_Sel(ByVal lstrlot_recplistVer As String, ByRef lstrLotID As String, _
                                          ByVal lstrOpID As String, ByVal lstrStepID As String, _
                                          ByVal lstrWpId As String, ByVal lstrClassDivision As String, _
                                          ByVal llngEqFlag As Integer, ByVal lstrAltNumber As String, _
                                          Optional ByRef llngLotRecpListCnt As Integer = 0, _
                                          Optional ByRef lstrOriginalRecpFlag As String = vbNullString, _
                                          Optional ByRef lstrProcChangeRecipeFlag As String = vbNullString, _
                                          Optional ByRef lstrUserSelectFlag As String = vbNullString, _
                                          Optional ByRef lstrVariableResult As String = vbNullString, _
                                          Optional ByRef lstrCmpRecipeBodyFlag As String = vbNullString) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用(ﾚｼﾋﾟ)
        Dim laAry2              As TfMsgAry         'ｱﾚｰ取得用(ﾚｼﾋﾟ)
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用(ﾚｼﾋﾟ)
        Dim ltMsg2              As TfMsg            'ｱﾚｰの各要素取得用(ﾚｼﾋﾟ)
        Dim llngListCnt         As Integer          'ﾘｽﾄｶｳﾝﾄ(ﾚｼﾋﾟ)
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "ロットレシピリスト取得"
            pubblnLotrecplist_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg
            
            '@ﾚｼﾋﾟﾘｽﾄ構造体のｸﾘｱ
            ptypLotrecpList = New List(Of Lotrecplist)
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)                  '大工程ID
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)              '小工程ID
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)                  '装置ID
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            '@処理区分(02:ﾏｽﾀ　23:ﾄﾗﾝｻﾞｸｼｮﾝ)
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If

        '@処理区分ZZができてからは未使用とのことｺﾒﾝﾄｱｳﾄ(SV確認済み)
        '''''    '@装置ﾌﾗｸﾞ:Long型なのでNULLﾁｪｯｸをはずす
        '''''    Call lrMsg.addString(CPstrEQ_FLAG, llngEqFlag)
            
            If lstrAltNumber <> vbNullString Then
                Call lrMsg.addString(CPstrALT_NUMBER, lstrAltNumber)        '代替番号
            Else
                Call lrMsg.addString(CPstrALT_NUMBER, CPstrMsgNull)
            End If
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                  'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrlot_recplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_recplistVer)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_recplist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    Call laMsg.getString(CPstrORIGINAL_RECIPE_FLAG, lstrOriginalRecpFlag)                   '個別ﾚｼﾋﾟﾌﾗｸﾞ
                    '@↓2020/07/01 (Wed) 11:36:41 T.Oide 「.Netへ反映未」 **************************************************
                    Call laMsg.getString(CPstrCMP_RECIPE_BODY_FLAG, lstrCmpRecipeBodyFlag)                  'CMPﾚｼﾋﾟﾎﾞﾃﾞｨｰ設定済ﾌﾗｸﾞ
                    '@↑2020/07/01 (Wed) 11:36:41 T.Oide 「.Netへ反映未」 **************************************************

                    Call laMsg.getString(CPstrPROC_CHANGE_RECIPE_FLAG, lstrProcChangeRecipeFlag)            '工順変更ﾚｼﾋﾟﾌﾗｸﾞ(ﾚｼﾋﾟ変更禁止)
                    Call laMsg.getString(CPstrUSER_SELECT_FLAG, lstrUserSelectFlag)                         'ﾕｰｻﾞｰ選択ﾌﾗｸﾞ
                    Call laMsg.getString(CPstrVARIABLE_RESULT, lstrVariableResult)                          'ﾚｼﾋﾟ値ﾃﾞｰﾀ有無(入力可能なレシピパラメータがあるかどうか)0:なし、1:あり

                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得(ﾚｼﾋﾟ)
                    Call laMsg.getMsgAry(CPstrRECIPE_LIST, laAry)

                    '@ﾘｽﾄ数を格納(ﾚｼﾋﾟ)
                    llngListCnt = laAry.Count
                    llngLotRecpListCnt = llngListCnt
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認 NSYS 初期化はループ処理内へ移動
                    'If llngListCnt > 0 Then
                    '    ReDim Preserve ptypLotrecpList(llngListCnt)
                    'End If
                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得(ﾚｼﾋﾟ)
                    'llngCnt = 1 NSYS 不要カウンタのため削除
                    For Each ltMsg In laAry

                        'NSYS 編集用構造体初期化
                        Dim typLotrecplistTmp = New Lotrecplist

                        '@受信結果取得(ﾚｼﾋﾟ)
                        With typLotrecplistTmp
                            Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)      'ｽﾛｯﾄ№
                            Call ltMsg.getString(CPstrWF_ID, .strWfId)                      'WFID
                            Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)              'ﾚｼﾋﾟID
                            Call ltMsg.getString(CPstrRECIPE_COMMENTS, .strRecipeComment)   'ﾚｼﾋﾟｺﾒﾝﾄ
                            Call ltMsg.getString(CPstrDEFAULT_FLAG, .strDefaultFlag)        'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                            Call ltMsg.getMsgAry(CPstrRECIPE_BODY_LIST, laAry2)             'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ
                            '@ｱﾚｰの数が0じゃなければ処理
                            If laAry2.Count <> 0 Then
                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                'llngCnt2 = laAry2.Count
                                .lngRecipeBodyList = laAry2.Count
                                '@配列の要素数を設定
                                'ReDim Preserve .typRecipeBodyList(llngCnt2)
                                .typRecipeBodyList = New List(Of RecipeBodyList)
                                '@ｱﾚｰの各要素取得
                                'lngCnt2 = 1
                                For Each ltMsg2 In laAry2

                                    'NSYS 編集用構造体初期化
                                    Dim typRecipeBodyListTmp = New RecipeBodyList

                                    Call ltMsg2.getString(CPstrRECIPE_ITEM, typRecipeBodyListTmp.strRecipeItem)             'ﾚｼﾋﾟｱｲﾃﾑ名
                                    Call ltMsg2.getString(CPstrRECIPE_VALUE, typRecipeBodyListTmp.strRecipeValue)           '値
                                    Call ltMsg2.getString(CPstrVARIABLE_FLAG, typRecipeBodyListTmp.strVariableFlag)         'ﾚｼﾋﾟ値変更可否(0:不可　1:可)
                                    Call ltMsg2.getString(CPstrVALUE_TYPE, typRecipeBodyListTmp.strValueType)               'A:文字ﾀｲﾌﾟ N:数字ﾀｲﾌﾟ
                                    Call ltMsg2.getString(CPstrITEM_VALID_DIGIT, typRecipeBodyListTmp.strItemValidDigit)    '小数点以下有効桁

                                    'NSYS 編集後構造体追加
                                    .typRecipeBodyList.Add(typRecipeBodyListTmp)
                                    
                                    'llngCnt2 = llngCnt2 + 1 NSYS 不要カウンタのため削除
                                Next
                            End If

                        End With

                        'NSYS 編集後構造体追加
                        ptypLotrecpList.Add(typLotrecplistTmp)

                        'llngCnt = llngCnt + 1  NSYS 不要カウンタのため削除
                    Next
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotrecplist_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_recplistVer)
                    
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

    '関数名：pubblnLotChgRecp_Upd
    '機　能：WF毎のﾚｼﾋﾟ変更ﾒｯｾｰｼﾞ送信
    '引　数：lstrlot_recpchngVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotRecpChng：WF毎のﾚｼﾋﾟ変更ﾃﾞｰﾀ格納
    '戻り値：True:成功、False：失敗
    '作成日：2004/03/05 (Fri) 11:17:11 T.Oide
    '更新日：2005/01/27 (Thu) 12:50:46 N.Kasai
    '備　考：
    '　　　：2004/10/01 (Fri) 12:59:24 M.Miura      ﾚｼﾋﾟIDに半角ｽﾍﾟｰｽが入っている場合は""に変換
    '　　　：2005/01/27 (Thu) 12:50:46 N.Kasai      CMP対応(要求MSGに　RECIPE_BODY_LISTを追加)　不具合№304
    Public Function pubblnLotChgRecp_Upd(ByVal lstrlot_recpchngVer As String, ByRef ltypLotRecpChng As LotRecpChng) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得        
        Dim llngCnt2            As Integer
        Dim lrAry2              As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg2              As TfMsg            'ｱﾚｰの各要素作成用
        
        Try
            
            pstrMessageName = "レシピ変更"
            pubblnLotChgRecp_Upd = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            
            lrAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypLotRecpChng
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@処理区分
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
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
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrlot_recpchngVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_recpchngVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                '@代替番号
                If .strAltNumber <> vbNullString Then
                    Call lrMsg.addString(CPstrALT_NUMBER, .strAltNumber)
                Else
                    Call lrMsg.addString(CPstrALT_NUMBER, CPstrMsgNull)
                End If
                
                '@WF毎のﾚｼﾋﾟｾｯﾄ
                'llngCnt = 1 不要カウンタのため削除
                For Each lstRecpList In .typRecpList
                    '@WF№
                    If lstRecpList.strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, lstRecpList.strWfId)
                    Else
                        Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                    End If
                    '@ﾚｼﾋﾟID
                    If lstRecpList.strRecpID <> vbNullString And _
                       lstRecpList.strRecpID <> CPstrSpace Then
                        Call ltMsg.addString(CPstrRECIPE_ID, lstRecpList.strRecpID)
                    Else
                        Call ltMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
                    End If
                    
                    If lstRecpList.lngRecipeBodyList > 0 Then
                        '@ﾎﾞﾃﾞｨﾘｽﾄｾｯﾄ
                        llngCnt2 = 0
                        Do While lstRecpList.lngRecipeBodyList > llngCnt2
                            With lstRecpList.typRecipeBodyList(llngCnt2)
                                If .strRecipeItem <> vbNullString Then
                                    Call ltMsg2.addString(CPstrRECIPE_ITEM, .strRecipeItem)     'ﾚｼﾋﾟｱｲﾃﾑ
                                Else
                                    Call ltMsg2.addString(CPstrRECIPE_ITEM, CPstrMsgNull)
                                End If
                                
                                If .strRecipeValue <> vbNullString Then
                                    Call ltMsg2.addString(CPstrRECIPE_VALUE, .strRecipeValue)   'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                Else
                                    Call ltMsg2.addString(CPstrRECIPE_VALUE, CPstrMsgNull)
                                End If
                            
                                Call lrAry2.Add(ltMsg2)
                                ltMsg2.Clear
                                llngCnt2 = llngCnt2 + 1
                            End With
                        Loop
                    End If
                    
                    Call ltMsg.addMsgAry(CPstrRECIPE_BODY_LIST, lrAry2)                    'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ
                    lrAry2.Clear
                                
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                    'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                Next
                
                Call lrMsg.addMsgAry(CPstrRECIPE_LIST, lrAry)
                lrAry.Clear
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chgrecp_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@最終更新日時書き換え(連続して登録する場合の対策)
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, ptypLotprestate.strLotLastUpdate)
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotChgRecp_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_recpchngVer)
                    
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
            lrAry = Nothing
            laMsg = Nothing
            
            lrAry2 = Nothing
            ltMsg2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
            lrAry2 = Nothing
            ltMsg2 = Nothing

            
        End Try
    End Function

    '関数名：pubblnMasScpList_Sel
    '機　能：不良ｺｰﾄﾞ一覧取得
    '引　数：lstrSBID：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrmas_scplist_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision：処理区分(3H:WAIST指定、3I:不良項目ｾｯﾄID指定)
    '　　　：lstrLotScrapSetID：不良項目ｾｯﾄID
    '　　　：ltypeMasScrapList：取得結果格納構造体(不良ｺｰﾄﾞ一覧)
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/24 (Wed) 11:40:24 T.Oide
    '更新日：2004/10/20 (Wed) 14:42:54 T.Kitagawa
    '備　考：
    '　　　：2004/08/25 (Wed) 14:39:43 T.Kitagawa　 ﾛｯﾄ工順変更画面用に lstrLotScrapSetID、SeqNum を追加
    '　　　：2004/09/03 (Fri) 10:49:32 T.Kitagawa　 不良項目ｾｯﾄID(ﾛｯﾄ現在状態取得Msgから取得)にて不良ｺｰﾄﾞ一覧を取得するように修正
    '　　　：2004/10/20 (Wed) 14:42:54 T.Kitagawa　 処理区分追加(3H:WAIST指定、3I:不良項目ｾｯﾄID指定)
    Public Function pubblnMasScpList_Sel(ByVal lstrSBID As String, ByVal lstrmas_scplist_Ver As String, ByVal lstrClassDivision As String, _
                                            ByVal lstrLotScrapSetID As String, ByRef ltypeMasScrapList As MasItemList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "不良入力項目取得"
            pubblnMasScpList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                      'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrmas_scplist_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_scplist_Ver)         'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            If lstrLotScrapSetID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_SCRAP_SET_ID, lstrLotScrapSetID)  '不良項目ｾｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_SCRAP_SET_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_scplist_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@ｱﾚｰ取得
                    Call laMsg.getMsgAry(CPstrSCRAP_LIST, laAry)
                    With ltypeMasScrapList
                        '@要素数格納
                        .lngListCnt = laAry.Count

                        'NSYS 構造体格納用リスト初期化
                        .typeMasItem = New List(Of MasItem)
                        '@要素数が0以外ならﾃﾞｰﾀ格納
                        If .lngListCnt <> 0 Then
                            'ReDim Preserve .typeMasItem(.lngListCnt) NSYS ループ処理内へ移動
                            'llngCnt = 1 NSYS 不要カウンタのため削除
                            For Each ltMsg In laAry
                                'NSYS 編集用構造体初期化
                                Dim typMasItemTmp = New MasItem

                                Call ltMsg.getString(CPstrSCRAP_ITEM_ID, typMasItemTmp.strItemID)       '不良ID
                                Call ltMsg.getString(CPstrSCRAP_ITEM_NAME, typMasItemTmp.strItemName)   '不良名
                                Call ltMsg.getString(CPstrSEQ_NUM, typMasItemTmp.strSeqNum)             '表示順番

                                'NSyS 編集済み構造体を追加
                                .typeMasItem.Add(typMasItemTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnMasScpList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_scplist_Ver)
                    
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

    '関数名：pubblnMasMapInfo_Sel
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ情報取得
    '引　数：lstrmas_mapinfo_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrPDID           ：機種ID
    '　　　：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：ltypMasPdMap       ：ｽﾛｯﾄﾏｯﾌﾟ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/24 (Wed) 13:46:54 T.Kitagawa
    '更新日：2006/09/25 (Mon) 13:33:47 T.Kitagawa
    '備　考：
    '　　　：2005/06/29 (Wed) 15:22:31 N.Kasai      lstrSBID引数追加(pstrSBID→lstrSBID変更)
    '　　　：2006/09/25 (Mon) 13:33:47 T.Kitagawa   欠損ﾁｯﾌﾟ№ﾀｸﾞ(LOST_CHIP_NO)を追加(案件№01084)
    Public Function pubblnMasMapInfo_Sel(ByVal lstrmas_mapinfo_Ver As String, _
                                         ByVal lstrPdID As String, _
                                         ByVal lstrSBID As String, _
                                         ByRef ltypMasPdMap As MasPdMapList) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
            
        Try
            
            pstrMessageName = "機種チップマップ取得"
            pubblnMasMapInfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)                  '機種ID
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            
            '@受入在庫のﾏｯﾌﾟ情報を表示する際はSBID=1A0で取得する必要あり
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                  'SBID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            If lstrmas_mapinfo_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_mapinfo_Ver)     'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_mapinfo_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrROW_NUM_LIST, laAry)
                    '@ﾘｽﾄ数を格納
                    'llngListCnt = laAry.Count NSYS 不要となるため削除
                    ltypMasPdMap.lngListCnt = laAry.Count
                    ltypMasPdMap.typRowNumList = New List(Of MasPdMap)
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認 NSYS 初期化はループ処理内へ移動
                    'If llngListCnt > 0 Then
                    '    ReDim Preserve ltypMasPdMap.typRowNumList(llngListCnt)
                    'End If
                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    'llngCnt = 1 NSYS 不要カウンタのため削除
                    For Each ltMsg In laAry

                        'NSYS 編集用構造体を初期化
                        Dim typMasPdMapTmp = New MasPdMap

                        '@受信結果取得
                        With typMasPdMapTmp
                            Call ltMsg.getString(CPstrROW_NUM, .strRowNum)              'WF行番号
                            Call ltMsg.getString(CPstrSTART_COLUMN, .strStartColumn)    '開始列番号
                            Call ltMsg.getString(CPstrCHIP_COUNT, .strChipCount)        'ﾁｯﾌﾟ数
                        End With

                        'NSYS 編集済み構造体を追加
                        ltypMasPdMap.typRowNumList.Add(typMasPdMapTmp)
                        'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                    Next
                    
                    Call laMsg.getString(CPstrLOST_CHIP_NO, ltypMasPdMap.strLostChipNo) '欠損ﾁｯﾌﾟ№
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasMapInfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_mapinfo_Ver)
                    
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

    '関数名：pubblnMasEmplist_Sel
    '機　能：作業者ﾘｽﾄ取得
    '引　数：lstrmas_emplistVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypEmpList        ：作業者ﾘｽﾄ
    '　　　：llngEmpListCnt     ：作業者ﾘｽﾄﾃﾞｰﾀ数
    '　　　：lstrGroupID        ：部門ID
    '戻り値：True：成功、False：失敗
    '作成日：2004/02/17 (Tue) 13:47:07 M.Miura
    '更新日：2008/06/12 (Thu) 18:55:38 N.Kojima
    '備　考：
    '　　　：2008/06/12 (Thu) 18:55:38 N.Kojima     要求に"GROUP_ID"、"SB_ID"追加。(案件№02884)
    Public Function pubblnMasEmplist_Sel(ByVal lstrmas_emplistVer As String, _
                                         ByRef ltypEmpList As List(Of TechManList), _
                                         ByRef llngEmpListCnt As Integer, _
                                         Optional ByRef lstrGroupID As String = CPstrDeptIDStaff) As Boolean

        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry           As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET         As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "作業者リスト取得"
            pubblnMasEmplist_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_emplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_emplistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@部門ID
            If lstrGroupID <> vbNullString Then
                Call lrMsg.addString(CPstrGROUP_ID, lstrGroupID)
            Else
                Call lrMsg.addString(CPstrGROUP_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_emplist_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：作業者ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrENG_EMP_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納：作業者ﾘｽﾄﾃﾞｰﾀ数
                    llngEmpListCnt = laAry.Count
                    
                    '@作業者ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngEmpListCnt <> 0 Then
                    
                        '@受信結果取得
                        'ReDim ltypEmpList(llngEmpListCnt)
                        ltypEmpList = New List(Of TechManList)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim typTechManListTmp = New TechManList
                        
                            With typTechManListTmp
                                
                                Call ltMsg.getString(CPstrENG_EMP_ID, .strTechManID)            '作業者ID
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strTechManName)        '作業者名
                            End With

                            'NSYS 編集済み構造体を追加
                            ltypEmpList.Add(typTechManListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                     pubblnMasEmplist_Sel = True
                     
                     
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_emplistVer)
                
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnLotWaferList_Sel
    '機　能：ﾛｯﾄWF情報取得
    '引　数：lstrlot_waferinfoVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCarrierID          ：ｷｬﾘｱID
    '　　　：lstrClassDivision      ：処理区分(02:全て(履歴含む)、0T：有効ｳｪﾊ(現在のｷｬﾘｱ状態))
    '　　　：ltypWaferList          ：ﾛｯﾄWF情報格納用構造体
    '　　　：llngWFcnt              ：WFListのｶｳﾝﾀ
    '　　　：lstrSbID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '戻り値：True:成功、False：失敗
    '作成日：2004/03/25 (Thu) 17:57:09 T.Oide
    '更新日：2016/02/11 (Thu) 22:45:00 H.Hayashi
    '備　考：
    '　　　：2004/09/06 (Mon) 19:47:52 T.Kitagawa　 ﾛｯﾄ指定(処理区分：0L)追加
    '　　　：2004/10/07 (Thu) 14:40:38 T.Kitagawa　 受信Msgにﾃﾞｰﾀ収集完了ﾌﾗｸﾞを追加
    '　　　：2005/02/03 (Thu) 17:28:40 S.Deguchi    ﾃﾞｰﾀ収集完了ﾌﾗｸﾞのｶﾗﾑ名変更(DATA_COLL_COMP_FLAG⇒WF_DATA_COLL_COMP_FLAG)
    '　　　：2005/06/03 (Fri) 11:37:25 S.Deguchi    不具合№760の対応で搭載ﾛｯﾄ状態のTagを追加
    '　　　：2006/02/03 (Fri) 12:51:14 N.Kasai      応答ﾒｯｾｰｼﾞにCF_WF_IDを追加
    '　　　：2007/02/05 (Mon) 13:21:09 N.Kasai      応答ﾀｸﾞ RECIPE_ID、WF_RECIPE_FLAG追加(№01120)
    '　　　：2007/04/18 (Wed) 10:11:27 N.Kasai      応答ﾀｸﾞ追加 WP_TYPE_FLAG(№01846)
    '　　　：2010/06/16 (Wed) 15:38:17 Y.Yoneyama   応答ﾀｸﾞ追加 EQ_TYPE
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnLotWaferList_Sel(ByVal lstrlot_waferinfoVer As String, _
                                           ByVal lstrCarrierID As String, _
                                           ByVal lstrClassDivision As String, _
                                           ByRef ltypWaferList As Waferlist, _
                                           Optional ByRef llngWFcnt As Integer = 0, _
                                           Optional ByVal lstrSBID As String = vbNullString, _
                                           Optional ByVal lstrLotID As String = vbNullString) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim llngListCnt         As Integer          'ﾘｽﾄｶｳﾝﾄ
        Dim lstrRET             As String           '応答取得
            
        Try
            
            pstrMessageName = "ロットＷＦ情報取得"
            pubblnLotWaferList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                    'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)            'ｷｬﾘｱID
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                      '指定SB_ID
            Else
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)                  '起動時SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
            End If
            If lstrlot_waferinfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_waferinfoVer)        'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_waferlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@受信結果取得
                    With ltypWaferList
                        Call laMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   '現在位置名
                        Call laMsg.getString(CPstrWF_CARRY_FLAG, .strWfCarryFlag)                   'WF移載ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrSLOT_SIZE, .strSlotSize)                          'ｽﾛｯﾄ数
                        Call laMsg.getString(CPstrRELATED_LOT_STATUS, .strState)                    'ﾛｯﾄ状態
                        Call laMsg.getString(CPstrWF_RECIPE_FLAG, .strWfRecipeFlag)                 'WFﾚｼﾋﾟﾌﾗｸﾞ(0:ﾛｯﾄﾚｼﾋﾟ、1:枚葉ﾚｼﾋﾟ)
                        Call laMsg.getString(CPstrWP_TYPE_FLAG, .strWpTypeFlag)                     '装置種別 H/W=0, NORMAL=1, 装置未確定=""
                        Call laMsg.getString(CPstrTPAL_CLASS, .strTpalClass)                        'TPAL設定
                        Call laMsg.getString(CPstrEQ_TYPE, .strEqType)                              'EQﾀｲﾌﾟ
                        Call laMsg.getString(CPstrCARRIER_CATEGORY_ID, .strCarrierCategoryId)       'ｷｬﾘｱｶﾃｺﾞﾘID
                        Call laMsg.getString(CPstrCF_FLAG, .strCfFlag)                              'CFﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLP_FLAG, .strLpFlag)                              'LPﾌﾗｸﾞ
                        Call laMsg.getString(CPstrSB_ID, .strSbID)                                  'ｼｽﾃﾑﾌﾞﾛｯｸ
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                        Call laMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程
                        Call laMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程
                    End With

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                    
                    '@ﾘｽﾄ数を格納
                    llngListCnt = laAry.Count
                    ltypWaferList.lngListCnt = llngListCnt
                    llngWFcnt = llngListCnt
                    ltypWaferList.typWfList = New List(Of WfList)
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngListCnt > 0 Then
                        '@配列数を設定
                        'ReDim Preserve ltypWaferList.typWfList(llngListCnt) NSYS ループ処理内へ移動
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim typWFListTmp = New WFList

                            '@受信結果取得
                            With typWFListTmp
                                Call ltMsg.getString(CPstrWF_ID, .strWfId)                                  'ｳｪﾊID
                                Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)                  'ｳｪﾊｽﾛｯﾄ№
                                Call ltMsg.getString(CPstrGRB_CLASS, .strGrbClass)                          'GRB区分
                                Call ltMsg.getString(CPstrCLASS, .strClass)                                 '区分
                                Call ltMsg.getString(CPstrCLASS_ID, .strClassID)                            '区分ID
                                Call ltMsg.getString(CPstrWF_STATUS_NAME, .strWFStatusName)                 'WFｽﾃｰﾀｽ
                                Call ltMsg.getString(CPstrTO_CARRY_SLOT_POSITION, .strToCarrySlotPosition)  '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                                Call ltMsg.getString(CPstrMOVE_STATUS, .strMoveStatus)                      '移載予約状態
                                Call ltMsg.getString(CPstrMOVE_DEST_ID, .strMoveDestID)                     '移載先ﾛｯﾄ/ｷｬﾘｱID
                                Call ltMsg.getString(CPstrRESULT, .strResult)                               '測定結果
                                Call ltMsg.getString(CPstrWF_DATA_COLL_COMP_FLAG, .strDataCollCompFlag)     'ﾃﾞｰﾀ収集完了ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrCF_WF_ID, .strCfWfID)                             'CF側の貼り合せたWFID(ODFの場合)
                                Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)                          'ﾚｼﾋﾟID(0T:のみ使用、WF選択条件、工順変更でWFﾚｼﾋﾟがない場合はNULL)
                                Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrREWORK_MODE, .strReworkMode)                      'ﾘﾜｰｸﾓｰﾄﾞ(0:全数/1:部分(移載有)/2:部分(移載無)/3:部分(分割無))
                                Call ltMsg.getString(CPstrJIG_ID, .strjigId)                                '蒸着治具ID
                                '@↓2020/01/07 (Tue) 14:42:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                Call ltMsg.getString(CPstrGRB_CLASS, .strGRBClass)                          'GRB
                                '@↑2020/01/07 (Tue) 14:42:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            End With

                            'NSYS 編集済構造体を追加
                            ltypWaferList.typWfList.Add(typWFListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                        Next
                    End If
                    '@関数の処理結果(成功)格納
                    pubblnLotWaferList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_waferinfoVer)
                    
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

    '関数名：pubblnWFMapInfo_Sel
    '機　能：WFのﾁｯﾌﾟ情報の取得
    '引　数：lstrwf__mapinfo_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：lstrWFID           ：WFID
    '　　　：lstrVaFlag         ：無機ﾌﾗｸﾞ(0：有機　1：無機)
    '　　　：lstrTpalClass      ：TPAL設定
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/26 (Fri) 09:44:50 T.Oide
    '更新日：2010/06/10 (Thu) 17:01:29 T.Oide
    '備　考：
    '　　　：2004/10/20 (Wed) 17:30:44 T.Kitagawa　 受信TagにWAIST状態、WAIST状態ｺｰﾄﾞを追加
    '　　　：2004/12/03 (Fri) 14:17:18 S.Deguchi    WFの良品と不良のﾁｯﾌﾟ数量を取得する処理を追加
    '　　　：2005/01/14 (Fri) 14:24:39 H.Wajima     自工程更新ﾌﾗｸﾞを追加
    '　　　：2005/08/09 (Tue) 11:51:24 N.Kasai      応答ﾒｯｾｰｼﾞ追加(BEFORE_CLASS、BEFORE_CLASS_ID)
    '　　　：2005/09/02 (Fri) 16:22:50 N.Kasai      応答ﾒｯｾｰｼﾞ追加(CHIP_CURRENT_OUT_QUANTITY)
    '　　　：2006/08/09 (Wed) 16:11:12 N.Kojima     要求ﾒｯｾｰｼﾞ追加(CLASS_DIVISION,SEARCH_DATE)
    '　　　：2006/10/26 (Thu) 14:11:52 N.Kasai      要求ﾒｯｾｰｼﾞ追加(CLASS_DIVISION,SEARCH_DATE)削除
    '　　　：2010/06/10 (Thu) 16:36:08 T.Oide       案件№04059 左右別不良数表示機能追加
    Public Function pubblnWFMapInfo_Sel(ByVal lstrwf__mapinfo_Ver As String, _
                                        ByVal lstrLotID As String, _
                                        ByVal lstrWFID As String, _
                                        ByVal lstrVaFlag As String, _
                                        ByVal lstrTpalClass As String, _
                                        ByRef ltypWFMapInfo As WFMapInfo) As Boolean


        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
            
        Try

            pstrMessageName = "WFマップ情報取得"
            pubblnWFMapInfo_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾒｯｾｰｼﾞ作成
            '@***********************
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            If lstrWFID <> vbNullString Then
                Call lrMsg.addString(CPstrWF_ID, lstrWFID)                  'WFID
            Else
                Call lrMsg.addString(CPstrWF_ID, CPstrMsgNull)
            End If
            
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                  'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrVaFlag <> vbNullString Then
                Call lrMsg.addString(CPstrVA_FLAG, lstrVaFlag)              '無機ﾌﾗｸﾞ
            Else
                Call lrMsg.addString(CPstrVA_FLAG, CPstrMsgNull)
            End If

            If lstrTpalClass <> vbNullString Then
                Call lrMsg.addString(CPstrTPAL_CLASS, lstrTpalClass)        'TPAL設定
            Else
                Call lrMsg.addString(CPstrTPAL_CLASS, CPstrMsgNull)
            End If
            
            If lstrwf__mapinfo_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrwf__mapinfo_Ver)     'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrwf__mapinfo_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
                
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    Call laMsg.getString(CPstrCHIP_QUANTITY, ltypWFMapInfo.strChipQuantity)                                 '良品のﾁｯﾌﾟ数量
                    Call laMsg.getString(CPstrCHIP_OUT_QUANTITY, ltypWFMapInfo.strChipOutQuantity)                          '総不良のﾁｯﾌﾟ数量
                    Call laMsg.getString(CPstrCHIP_CURRENT_OUT_QUANTITY, ltypWFMapInfo.strChipCurrentOutQuantity)           '現不良のﾁｯﾌﾟ数量
                    Call laMsg.getString(CPstrCHIP_FORWARD_QUANTITY, ltypWFMapInfo.strChipForwardQuantity)                  '総払出のﾁｯﾌﾟ数量
                    Call laMsg.getString(CPstrCHIP_CURRENT_FORWARD_QUANTITY, ltypWFMapInfo.strChipCurrentForwardQuantity)   '現払出のﾁｯﾌﾟ数量
                    Call laMsg.getString(CPstrCHIP_QUANTITY_LOT_L, ltypWFMapInfo.strChipQuantityLotL)                       '良品ﾁｯﾌﾟ数LOT-左
                    Call laMsg.getString(CPstrCHIP_QUANTITY_LOT_R, ltypWFMapInfo.strChipQuantityLotR)                       '良品ﾁｯﾌﾟ数LOT-右
                    Call laMsg.getString(CPstrCHIP_QUANTITY_WF_L, ltypWFMapInfo.strChipQuantityWfL)                         '良品ﾁｯﾌﾟ数WF-左
                    Call laMsg.getString(CPstrCHIP_QUANTITY_WF_R, ltypWFMapInfo.strChipQuantityWfR)                         '良品ﾁｯﾌﾟ数WF-右
                    Call laMsg.getString(CPstrCHIP_OUT_QUANTITY_LOT_L, ltypWFMapInfo.strChipOutQuantityLotL)                '不良数LOT-左
                    Call laMsg.getString(CPstrCHIP_OUT_QUANTITY_LOT_R, ltypWFMapInfo.strChipOutQuantityLotR)                '不良数LOT-右
                    Call laMsg.getString(CPstrCHIP_OUT_QUANTITY_WF_L, ltypWFMapInfo.strChipOutQuantityWfL)                  '不良数WF-左
                    Call laMsg.getString(CPstrCHIP_OUT_QUANTITY_WF_R, ltypWFMapInfo.strChipOutQuantityWfR)                  '不良数WF-右
                    Call laMsg.getString(CPstrCHIP_CURRENT_OUT_QUANTITY_LOT_L, ltypWFMapInfo.strChipCurrentOutQuantityLotL) '現工程不良数LOT-左
                    Call laMsg.getString(CPstrCHIP_CURRENT_OUT_QUANTITY_LOT_R, ltypWFMapInfo.strChipCurrentOutQuantityLotR) '現工程不良数LOT-右
                    Call laMsg.getString(CPstrCHIP_CURRENT_OUT_QUANTITY_WF_L, ltypWFMapInfo.strChipCurrentOutQuantityWfL)   '現工程不良数Wf-左
                    Call laMsg.getString(CPstrCHIP_CURRENT_OUT_QUANTITY_WF_R, ltypWFMapInfo.strChipCurrentOutQuantityWfR)   '現工程不良数Wf-右
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrCHIP_LIST, laAry)
                    
                    '@ﾘｽﾄ数を格納
                    ltypWFMapInfo.lngListCnt = laAry.Count
                    ltypWFMapInfo.typChipList = New List(Of ChipList)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypWFMapInfo.lngListCnt > 0 Then
                        
                        '@配列の再定義
                        'ReDim Preserve ltypWFMapInfo.typChipList(laAry.Count) NSYS ループ処理内へ移動
                        
                        '@ｶｳﾝﾀの初期化
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim typChipListTmp = New ChipList
                            
                            '@受信結果取得
                            With typChipListTmp
                                Call ltMsg.getString(CPstrCHIP_ID, .strChipId)                      'ﾁｯﾌﾟID
                                Call ltMsg.getString(CPstrCLASS, .strClass)                         '区分
                                Call ltMsg.getString(CPstrCLASS_ID, .strClassID)                    '区分ID
                                Call ltMsg.getString(CPstrELECTRIC_CODE, .strElectricCode)          '電特ｺｰﾄﾞ
                                Call ltMsg.getString(CPstrELECTRIC_GRADE, .strElectricGrade)        '電特ｸﾞﾚｰﾄﾞ
                                Call ltMsg.getString(CPstrWAIST_STATUS, .strWaistStatus)            'WAIST状態
                                Call ltMsg.getString(CPstrWAIST_CODE, .strWaistCode)                'WAISTｺｰﾄﾞ
                                Call ltMsg.getString(CPstrNOWSTEP_EDIT_FLAG, .strNowstepEditFlag)   '自工程更新ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrBEFORE_CLASS, .strBeforeClass)            '自工程以前の最新の区分
                                Call ltMsg.getString(CPstrBEFORE_CLASS_ID, .strBeforeClassID)       '自工程以前の最新の区分ID
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            ltypWFMapInfo.typChipList.Add(typChipListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnWFMapInfo_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrwf__mapinfo_Ver)
                    
                
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
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

    '関数名：pubblnLotRsvlist__Sel
    '機　能：投入予定ﾛｯﾄ一覧を返す
    '引　数：lstrlot_reqstwpidVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotRlst()          ：戻り取得情報
    '　　　：llngClassCnt           ：流動区分ﾃﾞｰﾀ数
    '　　　：ltypLotresvlist        ：送信用情報格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2004/03/01 (Mon) 15:59:26 M.Miura
    '更新日：2009/12/02 (Wed) 21:45:19 H.Hayashi
    '備　考：
    '　　　：2004/09/13 (Mon) 18:37:42 S.Deguchi    ｺﾒﾝﾄﾀｸﾞを削除
    '　　　：2005/08/01 (Mon) 12:59:23 N.Kasai      L/R表示追加
    '　　　：2008/06/16 (Mon) 16:52:05 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 15:33:04 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/12/02 (Wed) 21:45:19 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    Public Function pubblnLotRsvlist__Sel(ByVal lstrlot_reqstwpidVer As String, _
                                          ByRef ltypLotRlst As List(Of typLotRlst), _
                                          ByRef llngClassCnt As Integer, _
                                          ByRef ltypLotresvlist As Lotresvlist) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
            
        Try
            
            '@各種初期設定
            pstrMessageName = "投入予定一覧取得"
            pubblnLotRsvlist__Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotresvlist
            
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
               
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrlot_reqstwpidVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_reqstwpidVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@流動区分ﾘｽﾄ
                For llngCnt = 0 To llngClassCnt - 1
                
                    '@流動区分
                    If .typFlowClassList(llngCnt).strFlowClass <> vbNullString Then
                        Call ltMsg.addString(CPstrFLOW_CLASS, .typFlowClassList(llngCnt).strFlowClass)
                    Else
                        Call ltMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                    End If

                    Call lrAry.Add(ltMsg)
                Next
                
                Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry)
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_rsvlist_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, lrAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    llngClassCnt = lrAry.Count
                    ltypLotRlst = New List(Of typLotRlst)
                    
                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngClassCnt > 0 Then
                        
                        '@配列領域の確保
                        'ReDim ltypLotRlst(lrAry.Count) NSYS ループ処理内へ移動
                    
                        '@ｶｳﾝﾀの初期化
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In lrAry

                            'NSYS 編集前構造体初期化
                            Dim typLotRlstTmp = New typLotRlst
                        
                            '@受信結果取得
                            With typLotRlstTmp
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                            'ﾛｯﾄID
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                              '機種ID
                                Call ltMsg.getString(CPstrPD_NAME, .strPdName)                          '機種名
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                    '流動区分(種別ID)
                                Call ltMsg.getString(CPstrFLOW_CLASS_NAME, .strFlowClassName)           '流動区分(種別名)
                                Call ltMsg.getString(CPstrWF_NUM, .strWfNum)                            'WF枚数
                                Call ltMsg.getString(CPstrPLAN_THROWIN_DATE, .strPlanThrowinDate)       '投入予定日
                                Call ltMsg.getString(CPstrMAS_PD_VERSION, .strMasVer)                   '工順Version
                                Call ltMsg.getString(CPstrENG_EMP_ID, .strEngEmpId)                     'ﾛｯﾄ担当者ID
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                 'ﾛｯﾄ担当者名
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                '液晶方向(L/R/Null)
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                     '送品先
                                Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                          'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
                                Call ltMsg.getString(CPstrGRB_CLASS, .strGRBClass)                      'GRB
                                Call ltMsg.getString(CPstrLASER_MARKER_SKIP_FLAG, .strLaserMarkerSkipFlag)  'ﾚｰｻﾞｰﾏｰｶｽｷｯﾌﾟﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLP_FLAG, .strLPFlag)                          'LPﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrCF_FLAG, .strCFFlag)                          'CFﾌﾗｸﾞ
                            End With
                            
                            'NSYS編集済み構造体を追加
                            ltypLotRlst.Add(typLotRlstTmp)
                            '@ｶｳﾝﾀを+1する
                            'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotRsvlist__Sel = True

                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_reqstwpidVer)

                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnLotInsprst_Ins
    '機　能：不良保留払出傾向登録
    '引　数：lstrlot_insprst_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotInsprst     ：不良保留払出傾向登録構造体
    '　　　：lstrResult         ：結果
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/24 (Wed) 16:15:33 T.Kitagawa
    '更新日：2009/03/31 (Tue) 14:37:53 N.Kojima
    '備　考：
    '　　　：2005/03/01 (Tue) 12:33:27 S.Deguchi    不具合№352/561対応で応答にResult Tagを追加
    '　　　：2007/02/13 (Tue) 16:34:29 N.Kasai      要求ﾀｸﾞに処理区分追加(№01739)
    '　　　：2009/03/31 (Tue) 14:37:53 N.Kojima     ﾁｯﾌﾟ払出対応に伴い処理追加/変更。(案件№03434)
    Public Function pubblnLotInsprst_Ins(ByVal lstrlot_insprst_Ver As String, _
                                         ByRef ltypLotInsprst As LotInsprst, _
                                         ByRef lstrResult As String) As Boolean

        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry           As TfMsgAry         'ｱﾚｰ作成用
        Dim lrAry2          As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg           As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg2          As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET         As String           '応答取得
        Dim llngCnt         As Integer          'ｶｳﾝﾄ
        Dim llngCnt2        As Integer          'ｶｳﾝﾄ
            
        Try

            pstrMessageName = "不良/保留/払出/傾向登録"
            pubblnLotInsprst_Ins = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            lrAry2 = New TfMsgAry
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
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
            If lstrlot_insprst_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_insprst_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            With ltypLotInsprst
                
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@処理区分(17:WF処置登録、1T:ﾁｯﾌﾟ処置登録)
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@-----------------------
                '@ WF毎の不良情報ｾｯﾄ
                '@-----------------------
                llngCnt = 0
                
                Do While ltypLotInsprst.lngListCnt > llngCnt
                    
                    With .typWfList(llngCnt)
                        
                        If .strWfId <> vbNullString Then
                            Call ltMsg.addString(CPstrWF_ID, .strWfId)                      'WFID
                        Else
                            Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                        End If
                        
                        If .strSlotPosition <> vbNullString Then
                            Call ltMsg.addString(CPstrSLOT_POSITION, .strSlotPosition)      'ｽﾛｯﾄ№
                        Else
                            Call ltMsg.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                        End If
                        
                        If .strClass <> vbNullString Then
                            Call ltMsg.addString(CPstrCLASS, .strClass)                     '区分
                        Else
                            Call ltMsg.addString(CPstrCLASS, CPstrMsgNull)
                        End If
                        
                        If .strClassID <> vbNullString Then
                            Call ltMsg.addString(CPstrCLASS_ID, .strClassID)                '項目ID
                        Else
                            Call ltMsg.addString(CPstrCLASS_ID, CPstrMsgNull)
                        End If
                        
                        If .strRegistChipOutNum <> vbNullString Then
                            Call ltMsg.addString(CPstrCHIP_OUT_QUANTITY, .strRegistChipOutNum)          '登録不良ﾁｯﾌﾟ数
                        Else
                            Call ltMsg.addString(CPstrCHIP_OUT_QUANTITY, CPstrZero)
                        End If
                        
                        If .strRegistChipForwardNum <> vbNullString Then
                            Call ltMsg.addString(CPstrCHIP_FORWARD_QUANTITY, .strRegistChipForwardNum)  '登録払出ﾁｯﾌﾟ数
                        Else
                            Call ltMsg.addString(CPstrCHIP_FORWARD_QUANTITY, CPstrZero)
                        End If
                        
                        '@ﾁｯﾌﾟ数はｻｰﾊﾞで未使用の為、「0」で送る
                        Call ltMsg.addString(CPstrNUM, 0)
                        
                        '@WF状態が良品ｸﾗｽのみﾁｯﾌﾟ情報を送信する
                        If .strClass = CPstrClass1 Then
                            
                            '@ﾁｯﾌﾟ毎の不良情報ｾｯﾄ
                            llngCnt2 = 0
                            
                            Do While .lngListCnt > llngCnt2
                                With .typChipList(llngCnt2)
                                    If .strChipId <> vbNullString Then
                                        Call ltMsg2.addString(CPstrCHIP_ID, .strChipId)     'ﾁｯﾌﾟID
                                    Else
                                        Call ltMsg2.addString(CPstrCHIP_ID, CPstrMsgNull)
                                    End If
                                    If .strClass <> vbNullString Then
                                        Call ltMsg2.addString(CPstrCLASS, .strClass)        '区分
                                    Else
                                        Call ltMsg2.addString(CPstrCLASS, CPstrMsgNull)
                                    End If
                                    If .strClassID <> vbNullString Then
                                        Call ltMsg2.addString(CPstrCLASS_ID, .strClassID)   '項目ID
                                    Else
                                        Call ltMsg2.addString(CPstrCLASS_ID, CPstrMsgNull)
                                    End If
                                    
                                    Call lrAry2.Add(ltMsg2)
                                    ltMsg2.Clear
                                    llngCnt2 = llngCnt2 + 1
                                End With
                            Loop
                            
                            Call ltMsg.addMsgAry(CPstrCHIP_LIST, lrAry2)                    'ﾁｯﾌﾟﾘｽﾄ
                            lrAry2.Clear
                        
                        Else
                            '@WFが良品でなかった場合空ｱﾚｲをｾｯﾄ
                            
                            Call ltMsg.addMsgAry(CPstrCHIP_LIST, lrAry2)                    'ﾁｯﾌﾟﾘｽﾄ
                            lrAry2.Clear
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
                If .strResponsble_Emp_ID <> vbNullString Then
                    Call lrMsg.addString(CPstrRESPONSIBLE_EMP_ID, .strResponsble_Emp_ID)    '責任者ID
                Else
                    Call lrMsg.addString(CPstrRESPONSIBLE_EMP_ID, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_insprst_, lrMsg, laMsg)
            
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
                    pubblnLotInsprst_Ins = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_insprst_Ver)


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
            lrAry2 = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
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
            lrAry2 = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotChgComm_Upd
    '機　能：ﾛｯﾄｺﾒﾝﾄ登録
    '引　数：lstrlot_chgcmmentVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：lstrEmpID              ：作業者ID
    '　　　：lstrComments           ：ﾛｯﾄｺﾒﾝﾄ
    '　　　：lstrLotLastUpdate      ：ﾛｯﾄ最終更新日
    '戻り値：True：成功、False：失敗
    '作成日：2004/04/08 (Thu) 13:50:35 K.Takano
    '更新日：2004/06/01 (Tue) 10:37:38 N.Kasai
    '備　考：
    Public Function pubblnLotChgComm_Upd(ByVal lstrlot_chgcmmentVer As String, _
                                         ByVal lstrLotID As String, _
                                         ByVal lstrEmpID As String, _
                                         ByVal lstrComments As String, _
                                         ByRef lstrLotLastUpdate As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
            
        Try

            pstrMessageName = "ロットコメント登録"
            pubblnLotChgComm_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            '@作業者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            '@ﾛｯﾄｺﾒﾝﾄ
            If lstrComments <> vbNullString Then
                Call lrMsg.addString(CPstrCOMMENTS, lstrComments)
            Else
                Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
            End If
            '@ﾛｯﾄ最終更新日時
            If lstrLotLastUpdate <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)
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
            If lstrlot_chgcmmentVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_chgcmmentVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chgcomm_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)   'ﾛｯﾄ最終更新日時
                    '@関数の処理結果(成功)格納
                    pubblnLotChgComm_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_chgcmmentVer)
                    
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

    '関数名：pubblnEqAreaCurList_Sel
    '機　能：ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報取得
    '引　数：lstreq__areacurlistVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrAreaID             ：ｴﾘｱID
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：ltypAreaEquipmentList  ：格納ﾃﾞｰﾀ
    '　　　：llngAreaprestateCnt    ：ﾃﾞｰﾀ件数
    '戻り値：True：正常、False：異常
    '作成日：2004/04/13 (Tue) 12:23:33 S.Deguchi
    '更新日：2018/07/19 (Thu) 16:04:28 Y.Yoneyama
    '備　考：旧名称：pubblnEqAreaprestate_Sel
    '　　　：2004/09/13 (Mon) 20:18:16 S.Deguchi    Tag:CPstrWP_STATUS_NAME/CPstrWP_TYPE_FLAGを追加
    '　　　：2004/11/05 (Fri) 18:39:36 N.Kojima　   応答にｽﾄｯｶIDとｽﾄｯｶ名を追加(出庫指示)
    '　　　：2005/06/09 (Thu) 13:19:19 N.Kojima     応答に"EQ_TYPE"追加(不具合№829)
    '　　　：2018/07/19 (Thu) 16:04:28 Y.Yoneyama   防湿ALD対応
    Public Function pubblnEqAreaCurList_Sel(ByVal lstreq__areacurlistVer As String, _
                                            ByVal lstrAreaID As String, _
                                            ByVal lstrSBID As String, _
                                            ByRef ltypAreaEquipmentList As List(Of AreaEquipmentList), _
                                            ByRef llngAreaprestateCnt As Integer, _
                                            Optional ByVal lstrClassDivision As String = vbNullString, _
                                            Optional ByVal lstrMcGroupID As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "エリア装置用途情報取得"
            pubblnEqAreaCurList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '戻り値構造体初期化
            ltypAreaEquipmentList = New List(Of AreaEquipmentList)

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrAreaID <> vbNullString Then
                Call lrMsg.addString(CPstrAREA_ID, lstrAreaID)                  'ｴﾘｱID
            Else
                Call lrMsg.addString(CPstrAREA_ID, CPstrMsgNull)
            End If
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                      'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstreq__areacurlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstreq__areacurlistVer)      'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrMcGroupID <> vbNullString Then
                Call lrMsg.addString(CPstrMC_GROUP_ID, lstrMcGroupID)           '装置ｸﾞﾙｰﾌﾟID
            Else
                Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__areacurlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrAREA_EQUIPMENT_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    llngAreaprestateCnt = laAry.Count
                    If llngAreaprestateCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        For Each ltMsg In laAry
                            '@受信結果取得
                            'ReDim Preserve ltypAreaEquipmentList(llngCnt)
                            Dim ltypAreaEquipment = New AreaEquipmentList

                            With ltypAreaEquipment
                                Call ltMsg.getString(CPstrWP_ID, .strWpID)                      '装置ID
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)                  '装置名
                                Call ltMsg.getString(CPstrUSE_ID, .strUseId)                    '用途ID
                                Call ltMsg.getString(CPstrUSE_NAME, .strUseName)                '用途名
                                Call ltMsg.getString(CPstrMES_MODE_ID, .strMesModeId)           '運用ﾓｰﾄﾞ
                                Call ltMsg.getString(CPstrWP_STOP_FLAG, .strWpStopFlag)         'WP停止ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrWP_STATUS_NAME, .strWpStatusName)     '装置状態名
                                Call ltMsg.getString(CPstrWP_TYPE_FLAG, .strWpTypeFlag)         'WPﾀｲﾌﾟﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrPLACE_ID, .strPlaceID)                'ｽﾄｯｶID
                                Call ltMsg.getString(CPstrPLACE_NAME, .strPlaceName)            'ｽﾄｯｶ名
                                Call ltMsg.getString(CPstrEQ_TYPE, .strEqType)                  'EQﾀｲﾌﾟ
        '@↓2018/07/19 (Thu) 16:03:55 Y.Yoneyama **************************************************
                                Call ltMsg.getString(CPstrALD_PROCESS_MODE_ID, .strALDProcessModeId) 'ALD処理ﾓｰﾄﾞ
                                Call ltMsg.getString(CPstrALD_PROCESS_NAME, .strALDProcessName) 'ALD処理名
        '@↑2018/07/19 (Thu) 16:03:55 Y.Yoneyama **************************************************
                            End With

                            'NSYS 編集済み構造体を追加
                            ltypAreaEquipmentList.Add(ltypAreaEquipment)
                            'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnEqAreaCurList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstreq__areacurlistVer)
                    
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
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnCommand_Chk
    '機　能：引数のﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：OK、False:NG
    '作成日：2004/04/07 (Wed) 19:04:24 T.Oide
    '更新日：2008/06/23 (Mon) 14:46:17 N.Kojima
    '備　考：
    '　　　：第1引数(Command(0))／ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：第2引数(Command(1))／起動ﾓｰﾄﾞ　D：開発、R：ﾘﾘｰｽ、T：ﾏｽﾀ、E：装置
    '　　　：第3引数(Command(2))／端末区分　M：工程内、S：ｽﾀｯﾌ
    '　　　：工程管理CLの動作／起動ﾓｰﾄﾞがDの時はﾚｽﾎﾟﾝｽﾒｯｾｰｼﾞ表示。
    '　　　：その他はRと同じ動作。(ﾏｽﾀﾒﾆｭｰにｽﾙｰ)(2004/08/09現在)
    '　　　：
    '　　　：2004/10/08 (Fri) 13:29:51 N.Kojima     起動ﾓｰﾄﾞ格納処理追加(不具合№1059)
    '　　　：2008/06/23 (Mon) 14:46:17 N.Kojima     ｿｰｽ整備。(案件№03004)
    Public Function pubblnCommand_Chk() As Boolean
        
        Dim lstrCommand()       As String       'ｺﾏﾝﾄﾞﾗｲﾝ引数格納用配列
        
        '@処理結果に"Flase：失敗(初期値)"を格納
        pubblnCommand_Chk = False
        
        '@ｺﾏﾝﾝﾄﾞﾗｲﾝ引数を","毎に分解して、順に配列に格納
        lstrCommand = Split(Command$(), ",")

        '@引数が2つか
        If UBound(lstrCommand) = 2 Then
            '@引数が2つ設定されている場合
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸを設定(配列の0番目)
            pstrSBID = lstrCommand(0)
            
            '@★ 起動ﾓｰﾄﾞ(配列の1番目)により処理分岐 ★
            Select Case lstrCommand(1)
            
                '@〓 D：開発 〓
                Case CPstrDeveStatus

                    pstrTestStatus = CPstrDeveStatus        'ﾃｽﾄｽﾃｰﾀｽに"D"を格納
                    pstrCommand = CPstrDeveStatus           '起動ﾓｰﾄﾞに"D"を格納
                    pubblnCommand_Chk = True                '引数ﾁｪｯｸ"True：OK"をｾｯﾄ
                
                '@〓 T：ﾃｽﾄ(Patch) 〓
                Case CPstrTestStatus

                    pstrTestStatus = CPstrTestStatus        'ﾃｽﾄｽﾃｰﾀｽに"T"を格納
                    pstrCommand = CPstrTestStatus           '起動ﾓｰﾄﾞに"T"を格納
                    pubblnCommand_Chk = True                '引数ﾁｪｯｸ"True：OK"をｾｯﾄ
                
                '@〓 R：運用 〓
                Case CPstrReleStatus

                    pstrTestStatus = CPstrReleStatus        'ﾃｽﾄｽﾃｰﾀｽに"R"を格納
                    pstrCommand = CPstrReleStatus           '起動ﾓｰﾄﾞに"R"を格納
                    pubblnCommand_Chk = True                '引数ﾁｪｯｸ"True：OK"をｾｯﾄ
                
                '@〓 E：装置検収(立ち上げ当初に使用。08/06/23現在は未使用) 〓
                Case CPstrEQStatus
                
                    pstrTestStatus = CPstrEQStatus          'ﾃｽﾄｽﾃｰﾀｽに"E"を格納
                    pstrCommand = CPstrEQStatus             '起動ﾓｰﾄﾞに"E"を格納
                    pubblnCommand_Chk = True                '引数ﾁｪｯｸ"True：OK"をｾｯﾄ
                
                '@〓 その他 〓
                Case Else

                    pstrTestStatus = vbNullString           'ﾃｽﾄｽﾃｰﾀｽにNULLを格納
                    pstrCommand = vbNullString              '起動ﾓｰﾄﾞにNULLを格納
                    
                    Exit Function
            End Select
        
            '@★ 端末区分(配列の2番目)により処理分岐 ★
            Select Case lstrCommand(2)
            
                '@〓 M：工程端末 〓
                Case CPstrManufactureStatus

                    pstrTerminalMode = CPstrManufactureStatus   '端末区分に"M"をｾｯﾄ
                    pubblnCommand_Chk = True                    '引数ﾁｪｯｸ"True：OK"をｾｯﾄ
                
                '@〓 S：ｽﾀｯﾌ端末 〓
                Case CPstrStaffStatus

                    pstrTerminalMode = CPstrStaffStatus         '端末区分に"S"をｾｯﾄ
                    pubblnCommand_Chk = True                    '引数ﾁｪｯｸ"True：OK"をｾｯﾄ
                
                '@〓 A：管理者用端末 〓
                Case CPstrAdminStatus

                    pstrTerminalMode = CPstrAdminStatus         '端末区分に"A"をｾｯﾄ
                    pubblnCommand_Chk = True                    '引数ﾁｪｯｸ"True：OK"をｾｯﾄ
                    
                '@〓 その他 〓
                Case Else

                    pstrTerminalMode = vbNullString             '端末区分にNULLをｾｯﾄ
            End Select
        Else
            '@引数が2つ以外の場合
            
            '@処理終了
            Exit Function
        End If
        
    End Function

    '関数名：pubblnMasPriolist_Sel(変更前 pubblnMasPriortycode_Sel)
    '機　能：ﾛｯﾄ優先順位項目取得
    '引　数：lstrmas_priolistVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：llngPriortycodeListCnt ：データ数
    '　　　：mtypPriorityReasonList ：優先度構造体
    '戻り値：True：正常、False：異常
    '作成日：2004/03/16 (Tue) 12:26:45 T.Sawaguchi
    '更新日：2004/06/09 (Wed) 14:52:01 M.Miura
    '備　考：
    Public Function pubblnMasPriolist_Sel(ByVal lstrmas_priolistVer As String, _
                                          ByRef llngPriortycodeListCnt As Integer, _
                                          ByRef mtypPriorityReasonList As List(Of typPriorityReasonList)) As Boolean

        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim laAry           As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET         As String           '応答取得
            
        Try

            '@初期設定
            pstrMessageName = "優先度マスタリスト取得"
            pubblnMasPriolist_Sel = False
            mtypPriorityReasonList = New List(Of typPriorityReasonList)
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrmas_priolistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_priolistVer)           'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_priolist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrLOT_PRIORITY_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                    llngPriortycodeListCnt = laAry.Count
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngPriortycodeListCnt > 0 Then
                        'NSYS ループ処理内へ移動
                        'ReDim Preserve mtypPriorityReasonList(llngPriortycodeListCnt)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim typPriorityReasonListTmp = New typPriorityReasonList

                            '@受信結果取得
                            With typPriorityReasonListTmp
                                Call ltMsg.getString(CPstrLOT_PRIORITY_ID, .strMasPriorityId)
                                Call ltMsg.getString(CPstrLOT_PRIORITY_NAME, .strMasPriorityName)
                            End With
                            'NSYS 編集済み構造体を追加
                            mtypPriorityReasonList.Add(typPriorityReasonListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                        Next
                    End If
                    '@関数の処理結果(成功)格納
                    pubblnMasPriolist_Sel = True
                     
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_priolistVer)
                    
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnLotStart_Ins
    '機　能：ﾛｯﾄ作業開始
    '引　数：typLotStartIns     ：ﾛｯﾄ作業開始構造体(送信)
    '　　　：lstrlot_wrkstartVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrActionFlag     ：ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
    '　　　：lstrToOpID         ：制限時間先大工程
    '　　　：lstrToSteoID       ：制限時間先小工程
    '　　　：lstrLimitTime      ：制限時間
    '　　　：lstrWarnTime       ：警告時間
    '　　　：lstrLotLastUpdate  ：ﾛｯﾄ最終更新日時
    '　　　：lstrClassDivision  ：処理区分(02:時間制限ﾁｪｯｸなし、3B:時間制限ﾁｪｯｸあり)
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/04 (Thu) 19:14:32 T.Kitagawa
    '更新日：2006/12/20 (Wed) 13:30:36 N.Kasai
    '備　考：2004/08/31 (Tue) 17:27:33 M.Miura　    送信ﾒｯｾｰｼﾞにｱﾝﾛｰﾀﾞｰﾎﾟｰﾄIDを追加(不具合改善№525)
    '備　考：2004/09/02 (Thu) 15:17:52 M.Miura　    送信ﾒｯｾｰｼﾞにｱﾝﾛｰﾀﾞｰﾎﾟｰﾄIDを削除(不具合改善№525)
    '　　　：2004/09/17 (Fri) 10:44:57 Y.Yamagishi　制限時間を超過している場合はﾒｯｾｰｼﾞを表示する。(不具合改善№701)
    '　　　：2004/09/22 (Wed) 10:30:29 N.Kasai　    ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ応答MSGより削除
    '　　　：2005/03/17 (Thu) 11:40:57 N.Kojima     ﾛｰﾀﾞ/ｱﾝﾛｰﾀﾞﾌﾗｸﾞ追加(運用障害№265) ※現在ｺﾒﾝﾄｱｳﾄ。ｺｰﾄﾞは残しておく
    '　　　：2005/05/19 (Thu) 16:30:05 N.Kasai      CFｷｬﾘｱID追加
    '　　　：2006/12/20 (Wed) 13:30:36 N.Kasai      応答ﾀｸﾞ追加(LOT_LAST_UPDATE)№01515
    Public Function pubblnLotStart_Ins(ByVal lstrlot_wrkstartVer As String, _
                                       ByRef ltypLotStartIns As Lotwrkstart, _
                                       ByRef lstrActionFlag As String, _
                                       ByRef lstrToOpID As String, _
                                       ByRef lstrToStepID As String, _
                                       ByRef lstrLimitTime As String, _
                                       ByRef lstrWarnTime As String, _
                                       ByRef lstrLotLastUpdate As String, _
                                       Optional ByVal lstrClassDivision As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '@送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '@受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '@応答取得
        
        Try
            
            pstrMessageName = "ロット作業開始登録"          'ロット作業開始要求
            pubblnLotStart_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypLotStartIns
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
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEngEmpId)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@LOT最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                '@ｺﾒﾝﾄ(作業ﾒﾓ)
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                '@代替番号
                If .strAltNumber <> vbNullString Then
                    Call lrMsg.addString(CPstrALT_NUMBER, .strAltNumber)
                Else
                    Call lrMsg.addString(CPstrALT_NUMBER, CPstrMsgNull)
                End If
                '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                If .strToCarriaID <> vbNullString Then
                    Call lrMsg.addString(CPstrTO_CARRIER_ID, .strToCarriaID)
                Else
                    Call lrMsg.addString(CPstrTO_CARRIER_ID, CPstrMsgNull)
                End If
                
                '@CFｷｬﾘｱID
                If .strCFCarrierID <> vbNullString Then
                    Call lrMsg.addString(CPstrCF_CARRIER_ID, .strCFCarrierID)
                Else
                    Call lrMsg.addString(CPstrCF_CARRIER_ID, CPstrMsgNull)
                End If

            End With
            '@SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_wrkstartVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_wrkstartVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_wrkstart, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    Call laMsg.getString(CPstrTO_OP_ID, lstrToOpID)                     '制限時間先大工程
                    Call laMsg.getString(CPstrTO_STEP_ID, lstrToStepID)                 '制限時間先小工程
                    Call laMsg.getString(CPstrLIMIT_TIME, lstrLimitTime)                '制限時間
                    Call laMsg.getString(CPstrWARN_TIME, lstrWarnTime)                  '警告時間
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)       'ﾛｯﾄ最終更新日時
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotStart_Ins = True
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_wrkstartVer)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotActList_Sel
    '機　能：ｱｸｼｮﾝ予約ﾘｽﾄ取得
    '引　数：lstrlot_actlist_Ver：MSGﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：lstrOpID           ：大工程ID
    '　　　：lstrStepID         ：小工程ID
    '　　　：lstrPDID           ：機種ID
    '　　　：lstrMasPDVersion   ：工順ﾊﾞｰｼﾞｮﾝ(未使用)
    '　　　：lstrWP_ID          ：装置ID
    '　　　：ltypLotActList     ：ｱｸｼｮﾝ予約ﾘｽﾄ格納
    '戻り値：True:正常、False:失敗
    '作成日：2004/03/05 (Fri) 13:00:53 T.Oide
    '更新日：2007/02/16 (Fri) 14:05:51 N.Kasai
    '備　考：
    '　　　：2007/02/16 (Fri) 14:05:51 N.Kasai  応答ﾀｸﾞ追加(№01759)
    Public Function pubblnLotActList_Sel(ByVal lstrlot_actlist_Ver As String, _
                                         ByVal lstrLotID As String, _
                                         ByVal lstrOpID As String, _
                                         ByVal lstrStepID As String, _
                                         ByVal lstrPdID As String, _
                                         ByVal lstrMasPDVersion As String, _
                                         ByVal lstrWpId As String, _
                                         ByRef ltypLotAction As LotAction) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "アクション予約リスト取得"
            pubblnLotActList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
             
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)                  '大工程ID
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)              '小工程ID
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)                  '機種ID;ﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)                  '装置ID
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)                 'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrlot_actlist_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_actlist_Ver)     'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_actlist_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrLOT_ACTION_LIST, laAry)
                    '@ﾘｽﾄ数を格納
                    ltypLotAction.lnglstCnt = laAry.Count
                    ltypLotAction.typLotActList = New List(Of LotActList)
                    '@ｱｸｼｮﾝ予約実行ﾌﾗｸﾞを初期化(ここでは未使用の為初期化。作業開始、作業終了確定時に使用)
                    ltypLotAction.strActionFlag = vbNullString
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypLotAction.lnglstCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        '@配列の要素数を設定
                        'ReDim Preserve ltypLotAction.typLotActList(ltypLotAction.lnglstCnt) NSYS ループ処理内へ移動
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry

                            'NSYS 編集前構造体初期化
                            Dim typActionLotListTmp = New LotActList

                            With typActionLotListTmp
                                Call ltMsg.getString(CPstrLOT_ACTION_ID, .strLotActionID)           'ｱｸｼｮﾝ予約ID
                                Call ltMsg.getString(CPstrLOT_ACTION_TYPE_ID, .strLotActionTypeID)  'ｱｸｼｮﾝ予約ﾀｲﾌﾟID
                                Call ltMsg.getString(CPstrMESSAGE, .strMessage)                     '表示ﾒｯｾｰｼﾞ
                                Call ltMsg.getString(CPstrWORK_DIRECTION_ID, .strWorkDirectionID)   '作業指示書№
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)             '技術担当者名
                                Call ltMsg.getString(CPstrSTOP_HOLD_FLAG, .strStopHoldFlag)         '停止/保留ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrEMP_ID, .strEmpID)                        '作業者ID
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                    '作業者名
                                Call ltMsg.getString(CPstrACTION_TRIGGER, .strActionTrigger)        'ｱｸｼｮﾝﾄﾘｶﾞｰ(0:作業開始、1:作業終了)
                            End With

                            'NSYS 編集済み構造体を追加
                            ltypLotAction.typLotActList.Add(typActionLotListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotActList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_actlist_Ver)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotNextSend_Upd
    '機　能：次工程送出ﾒｯｾｰｼﾞを送信する
    '引　数：lstrlot_nextsendVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：lstrLastUpDate         ：最終更新日時
    '　　　：lstrEmpID              ：作業者ID
    '　　　：lstrDividedCheckFlag   ：ﾛｯﾄ分割確認要求ﾌﾗｸﾞ(0:確認なし、1:確認あり)
    '　　　：lstrClassDivision      ：処理区分(最終工程：「24」、通常は空)
    '　　　：llngBatchFlag          ：ﾊﾞｯﾁ作業終了ﾌﾗｸﾞ(0:ﾊﾞｯﾁ以外,1:ﾊﾞｯﾁ作業終了の場合,2:通信ｴﾗｰ(返信),3:送信失敗)
    '　　　：lstrErrorMsg           ：ﾊﾞｯﾁ作業終了のｴﾗｰﾒｯｾｰｼﾞを格納する
    '　　　：lstrErrorCode          ：ﾊﾞｯﾁ作業終了のｴﾗｰｺｰﾄﾞを格納する
    '　　　：lstrActionFlag         ：ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
    '　　　：lstrHoldFlag           ：電特保留ﾌﾗｸﾞ
    '　　　：lstrSendResult         ：送品結果(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
    '　　　：lstrTftHoldFlag        ：TFT保留ﾌﾗｸﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/11 (Thu) 11:09:07 T.Oide
    '更新日：2018/03/02 (Fri) 16:30:40 T.Oide
    '備　考：
    Public Function pubblnLotNextSend_Upd(ByVal lstrlot_nextsendVer As String, _
                                          ByVal lstrLotID As String, _
                                          ByVal lstrLastUpDate As String, _
                                          ByVal lstrEmpID As String, _
                                          ByVal lstrDividedCheckFlag As String, _
                                          Optional ByVal lstrClassDivision As String = vbNullString, _
                                          Optional ByRef llngBatchFlag As Integer = 0, _
                                          Optional ByRef lstrErrorMsg As String = vbNullString, _
                                          Optional ByRef lstrErrorCode As String = vbNullString, _
                                          Optional ByRef lstrActionFlag As String = vbNullString, _
                                          Optional ByRef lstrHoldFlag As String = vbNullString, _
                                          Optional ByRef lstrSendResult As String = vbNullString, _
                                          Optional ByRef lstrTftHoldFlag As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ロット次工程送出"
            pubblnLotNextSend_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            If lstrLastUpDate <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, lstrLastUpDate)  '最終更新日時
            Else
                Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
            End If
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)                '作業者ID
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                  'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrlot_nextsendVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_nextsendVer)     'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision) '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If

            If lstrDividedCheckFlag <> vbNullString Then
                Call lrMsg.addString(CPstrDIVIDED_CHECK_FLAG, lstrDividedCheckFlag) 'ﾛｯﾄ分割確認ﾌﾗｸﾞ
            Else
                Call lrMsg.addString(CPstrDIVIDED_CHECK_FLAG, CPstrEnableFlagFalse)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_nextsend, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    Call laMsg.getString(CPstrACTION_FLAG, lstrActionFlag)  'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ
                    Call laMsg.getString(CPstrSEND_RESULT, lstrSendResult)  '(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
                    '@ｺﾒﾝﾄのﾒｯｾｰｼﾞを格納
                    Call laMsg.getString(CPstrCOMMENTS, lstrErrorMsg)
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotNextSend_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@電特保留ﾌﾗｸﾞ又は、TFT保留ﾌﾗｸﾞが1の場合
                    If lstrHoldFlag = "1" Or lstrTftHoldFlag = "1" Then

                    Else
                    
                        '@ﾊﾞｯﾁ作業終了の場合
                        If llngBatchFlag = 1 Then
                            '@ﾊﾞｯﾁ作業終了ﾌﾗｸﾞを変更
                            llngBatchFlag = 3
                            
                            '@ﾊﾞｯﾁ作業終了のｴﾗｰﾒｯｾｰｼﾞを変数へ格納
                            Call laMsg.getString(CPstrMSG, lstrErrorMsg)
                            
                            '@ﾊﾞｯﾁ作業終了のｴﾗｰｺｰﾄﾞを変数へ格納
                            Call laMsg.getString(CPstrMSGCODE, lstrErrorCode)
                        Else
                            '@ﾊﾞｰｼﾞｮﾝ判定
                            Call pubstrErrMsg_Set(laMsg, lstrlot_nextsendVer)
                        End If
                    End If
                    
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
            '@通信ｴﾗｰの場合,通信ｴﾗｰﾌﾗｸﾞを２へ変更する
            llngBatchFlag = 2

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
                
        End Try
    End Function

    '関数名：pubblnLotNextStepList_Sel
    '機　能：次工程取得
    '引　数：strLotID               ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrlot_nextsteplistVer：ﾛｯﾄID
    '　　　：strOpeID               ：大工程ID
    '　　　：strStepID              ：小工程ID
    '　　　：ltypLotNextStep        ：次工程格納用構造体
    '　　　：lstrClassDivision      ：処理区分
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/10 (Wed) 19:42:50 T.Oide
    '更新日：2004/06/01 (Tue) 11:01:37 N.Kasai
    '備　考：
    '　　　：2008/04/01 (Tue) 13:12:00 S.Ochiai     No.02541対応(ﾘﾜｰｸ/追加流動ﾙｰﾄID選択)
    Public Function pubblnLotNextStepList_Sel(ByVal lstrlot_nextsteplistVer As String, _
                                              ByVal lstrLotID As String, _
                                              ByVal lstrOpeID As String, _
                                              ByVal lstrStepID As String, _
                                              ByRef ltypLotNextStep As LotNextStep, _
                                              Optional ByVal lstrClassDivision As String = vbNullString, _
                                              Optional ByVal lstrRouteID As String = vbNullString) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ロット次工程取得"
            pubblnLotNextStepList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                    'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            If lstrOpeID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpeID)                     '大工程ID
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)                  '小工程ID
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)                     'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrlot_nextsteplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_nextsteplistVer)     'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            If lstrRouteID <> vbNullString Then
                Call lrMsg.addString(CPstrROUTE_ID, lstrRouteID)                'ﾙｰﾄID
            Else
                Call lrMsg.addString(CPstrROUTE_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_nextsteplist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@ﾃﾞｰﾀを取得
                    Call laMsg.getMsgAry(CPstrNEXT_STEP_LIST, laAry)
                    
                    'llngCnt = laAry.Count NSYS 不要カウンタのため削除
                    ltypLotNextStep.lngNextStepListCnt = laAry.Count
                    ltypLotNextStep.strNextStepList = New List(Of NextStep)
                    
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        'ReDim Preserve ltypLotNextStep.strNextStepList(llngCnt) NSYS ループ処理内へ移動
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim typNextStepTmp = New NextStep

                            With typNextStepTmp
                            
                                Call ltMsg.getString(CPstrNEXT_OP_ID, .strNextOpId)             '大工程ID
                                Call ltMsg.getString(CPstrNEXT_STEP_ID, .strNextStepId)         '次小工程ID
                                Call ltMsg.getString(CPstrSTEP_DIVISION, .strStepDivision)      '工程ﾌﾗｸﾞ(1:ﾃﾞﾌｫﾙﾄ、0:代替)
                                
                                Call ltMsg.getMsgAry(CPstrWP_LIST, laAry2)                      'WPﾘｽﾄ
                                '@ｱﾚｰの数が0じゃなければ処理
                                If laAry2.Count <> 0 Then
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                    'llngCnt2 = laAry2.Count NSYS 不要カウンタのため削除
                                    typNextStepTmp.lngWpListCnt = laAry2.Count
                                    typNextStepTmp.strWPList = New List(Of WP)
                                    '@配列の要素数を設定
                                    'ReDim Preserve ltypLotNextStep.strNextStepList(llngCnt).strWPList(llngCnt2) NSYS ループ処理内へ移動
                                    '@ｱﾚｰの各要素取得
                                    'llngCnt2 = 1 NSYS 不要カウンタのため削除
                                    For Each ltMsg2 In laAry2

                                        'NSYS 編集用構造体初期化
                                        Dim typWPTmp = New WP

                                        With typWPTmp
                                            Call ltMsg2.getString(CPstrWP_ID, .strWpID)         'WPID
                                            Call ltMsg2.getString(CPstrWP_NAME, .strWpName)     'WP名
                                        End With

                                        'NSYS 編集済み構造体を追加
                                        typNextStepTmp.strWPList.Add(typWPTmp)
                                        'llngCnt2 = llngCnt2 + 1 NSYS 不要カウンタのため削除
                                    Next
                                End If
                            End With

                            'NSYS 編集済み構造体を追加
                            ltypLotNextStep.strNextStepList.Add(typNextStepTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要カウンタのため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotNextStepList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_nextsteplistVer)
                    
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
            laAry2 = Nothing
            ltMsg2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotList_Sel
    '機　能：新・ﾛｯﾄ一覧情報取得
    '引　数：ltypLotListReq ：要求ﾃﾞｰﾀ格納構造体
    '　　　：ltypLotList()  ：格納ﾃﾞｰﾀ
    '　　　：llngLotListCnt ：ﾃﾞｰﾀ件数
    '戻り値：True：正常、False：異常
    '作成日：2005/07/15 (Fri) 09:56:39 S.Deguchi
    '更新日：2018/01/17 (Wed) 11:07:25 Y.Yoneyama
    '備　考：lot_.list____を作り直し：CM0050へ移動予定
    '　　　：2004/09/02 (Thu) 16:20:11 T.Kitagawa   機種ID、装置名、ﾛｯﾄ最終更新日時を削除
    '　　　　2004/09/09 (Thu) 13:31:46 Y.Yamagishi  応答ﾀｸﾞに警告時間追加
    '　　　：2004/09/22 (Wed) 11:02:18 N.Kasai      応答ﾀｸﾞ追加
    '　　　：2004/09/26 (Sun) 12:06:37 Y.Yamagishi  応答ﾀｸﾞに制限ﾀｲﾌﾟ追加
    '　　　：2004/09/27 (Mon) 10:16:24 N.Kasai      応答ﾀｸﾞにALT_NUMBERを追加
    '　　　：2004/10/07 (Thu) 10:13:03 N.Kasai      応答ﾀｸﾞにLOT_LAST_UPDATEを追加
    '　　　：2004/10/18 (Mon) 11:16:24 N.Kasai      応答ﾀｸﾞにREWORK_FLAGを追加
    '　　　：2004/10/19 (Tue) 17:18:01 N.Kasai      応答ﾀｸﾞにTEMPLATE_SEQ_NUMを追加
    '　　　：2004/11/02 (Tue) 15:21:12 N.Kojima     応答ﾀｸﾞ(LOT_LIST)にｷｬﾘｱ位置ID、ｷｬﾘｱ位置名、ｷｬﾘｱ状態、搬送先を追加
    '　　　：2005/01/20 (Thu) 17:29:01 N.Kasai      応答ﾀｸﾞにｷｬﾘｱ目的位置名追加
    '　　　：2005/02/28 (Mon) 10:00:24 N.Kojima     応答ﾀｸﾞ"DEST"を"DEST_POSITION_ID"に変更(改善№512)
    '　　　：2005/06/20 (Mon) 11:12:04 N.Kojima     応答ﾀｸﾞ"MC_TYPE"を追加。(改善№706)
    '　　　：2005/07/21 (Thu) 16:17:48 N.Kasai      応答ﾀｸﾞ"LC_DIRECTION"を追加
    '　　　：2005/07/21 (Thu) 16:17:48 S.Deguchi    要求を構造体へ変更(種別をﾘｽﾄへ変更)
    '　　　：2006/07/04 (Tue) 14:21:32 T.Kitagawa   応答ﾀｸﾞ"WF_LIST"を追加
    '　　　：2008/06/16 (Mon) 16:59:36 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/06/26 (Wed) 08:30:00 S.Ochiai     部分ﾚｼﾋﾟ対応(案件№03008)、及びﾒｯｾｰｼﾞ構造を抜本的に変更
    '　　　：2009/02/24 (Tue) 15:40:53 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/08/26 (Wed) 16:01:39 N.Kojima     応答ﾀｸﾞに"PD_ID","PD_VERSION"追加。(案件№03611)
    '　　　：2009/10/05 (Mon) 12:45:48 N.Kojima     応答ﾀｸﾞに"J_BATCH_ID","CF_FLAG","LP_FLAG","VA_FLAG","TPAL_CLASS"追加。(案件№03791)
    '　　　：2009/12/02 (Wed) 17:08:46 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    '　　　：2010/03/03 (Wed) 17:16:38 N.Kojima     応答ﾀｸﾞに"AVAILABLE_RECIPE_FLAG"追加。(案件№03897)
    '　　　：2013/01/29 (Tue) 17:14:14 Y.Yoneyama   ﾛｯﾄ進捗度対応
    '      ：2015/11/20 (Fri) 16:29:27 H.Hayashi    千歳Spirytus_Prism処理チャンバー選択機能(H31096937)
    '      ：2018/01/17 (Wed) 11:07:25 Y.Yoneyama   時間制限開始待ち保留ﾀｸﾞ追加
    Public Function pubblnLotList_Sel(ByRef ltypLotListReq As LotListReq, _
                                      ByRef ltypLotListAns As LotListAns, _
                                      ByRef llngLotListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@各種初期設定
            pstrMessageName = "ロット一覧情報取得"
            pubblnLotList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            lrAry = New TfMsgAry
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotListReq
                
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
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                     Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_list____, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    With ltypLotListAns
                        
                        Call laMsg.getString(CPstrWP_TYPE_FLAG, .strWpTypeFlag)                     'WPﾀｲﾌﾟﾌﾗｸﾞ
                        Call laMsg.getString(CPstrUSE_ID, .strUseId)                                '用途ID
                        Call laMsg.getString(CPstrUSE_NAME, .strUseName)                            '用途名
                        Call laMsg.getString(CPstrMES_MODE_ID, .strMesModeId)                       '運用ﾓｰﾄﾞ
                        Call laMsg.getString(CPstrWP_STOP_FLAG, .strWpStopFlag)                     'WP停止ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrWP_STATUS_NAME, .strWpStatusName)                 '装置状態名
                        Call laMsg.getString(CPstrMC_TYPE, .strMcType)                              '装置ﾀｲﾌﾟ(Normal,Batch,Exdummy)
                    End With
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    llngLotListCnt = laAry.Count
                    ltypLotListAns.typLotList = New List(Of LotListLotList)
                    
                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngLotListCnt > 0 Then
                    
                        '@配列領域の確保
                        'ReDim ltypLotListAns.typLotList(llngLotListCnt) NSYS ループ処理内へ移動
                        
                        '@ｶｳﾝﾀの初期化
                        'llngCnt = 1 NSYS 不要カウンタのため削除
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        For Each ltMsg In laAry
                        
                            'NSYS 編集用構造体初期化
                            Dim typLotListListTmp = New LotListLotList
                            
                            '@受信結果取得
                            With typLotListListTmp
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                                Call ltMsg.getString(CPstrALT_NUMBER, .strAltNumber)                        '代替番号
                                Call ltMsg.getString(CPstrNOW_ST, .strNowST)                                'ﾛｯﾄ状態
                                Call ltMsg.getString(CPstrDISPATCH_START_TIME, .strDispatchStartTime)       '投入予定時刻
                                Call ltMsg.getString(CPstrDISPATCH_END_TIME, .strDispatchEndTime)           '終了予定時刻
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                     'ﾛｯﾄ担当者名
                                Call ltMsg.getString(CPstrWF_NUM, .strWfNum)                                'WF枚数
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                  'ﾁｯﾌﾟ
                                Call ltMsg.getString(CPstrLOT_COMMENTS_FLAG, .strLotCommentsFlg)            'ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                   'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)                   'ﾛｯﾄ停止ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)                      'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸ中　0:ﾘﾜｰｸなし)
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                                Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)                          'ﾚｼﾋﾟID
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)                    '液晶方向
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               'LOT最終更新日時
                                Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)                              '処理順番号
                                Call ltMsg.getString(CPstrCOMMIT_FLAG, .strCommitFlag)                      '号機指定(1：指定　0：指定なし)
                                Call ltMsg.getString(CPstrWF_PARTIAL_RECIPE_FLAG, .strWfPartialRecipeFlag)  '部分ﾚｼﾋﾟﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)             '制限ﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                        '制限時間(時間制約)
                                Call ltMsg.getString(CPstrWARN_TIME, .strWarnTime)                          '警告時間
                                Call ltMsg.getString(CPstrTO_OP_ID, .strToOpId)                             '制限時間先大工程
                                Call ltMsg.getString(CPstrTO_STEP_ID, .strToStepId)                         '制限時間先小工程
                                Call ltMsg.getString(CPstrTIME_RESTRICT_START_HOLD, .strTimeRestrictStartHold) '時間制限開始待ち保留
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrCURRENT_POSITION_ID, .strCurrentPositionID)       'ﾛｯﾄ位置
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   'ﾛｯﾄ位置(和名)
                                Call ltMsg.getString(CPstrTO_CARRIER_ID, .strToCarrierId)                   'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                                Call ltMsg.getString(CPstrCARRIER_STAT_ID, .strCarrierStatID)               'ｷｬﾘｱ状態ID
                                Call ltMsg.getString(CPstrCARRIER_STAT_NAME, .strCarrierStatName)           'ｷｬﾘｱ状態名
                                Call ltMsg.getString(CPstrDEST_POSITION_ID, .strDestPositionID)             'ｷｬﾘｱ目的位置ID(搬送先)
                                Call ltMsg.getString(CPstrDEST_NAME, .strDestName)                          'ｷｬﾘｱ目的位置名(搬送先)
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                         '送品先
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種ID
                                Call ltMsg.getString(CPstrPD_VERSION, .strPdVersion)                        '機種Ver
                                Call ltMsg.getString(CPstrJ_BATCH_ID, .strJBatchId)                         '蒸着ﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)                              'CFﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLP_FLAG, .strLpFlag)                              'LPﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrVA_FLAG, .strVaFlag)                              '無機ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrTPAL_CLASS, .strTpalClass)                        'TPAL区分
                                Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                              'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
                                Call ltMsg.getString(CPstrAVAILABLE_RECIPE_FLAG, .strAvailableRecipeFlag)   '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理不可ﾚｼﾋﾟ)
                                Call ltMsg.getString(CPstrH_BATCH_ID, .strHBatchId)                         '表面ﾊﾞｯﾁID
                                Call ltMsg.getString(CPstrSHIP_DIFF_DAY, .strShipDiffDay)                   '進捗度
                                Call ltMsg.getString(CPstrFR_RECIPE_FLAG, .strFrFlag)                       'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrGRB_CLASS, .strGrbClass)                          'GRB区分
                                Call ltMsg.getString(CPstrCOLOR_CD, .strColorCd)                            '指定色
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：WFﾘｽﾄ
                                Call ltMsg.getMsgAry(CPstrWF_LIST, laAry2)
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2数：WFﾘｽﾄﾃﾞｰﾀ数
                                .lngWfListCnt = laAry2.Count
                                .typWfList = New List(Of LotListWfList)
                                
                                '@WFﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                If .lngWfListCnt > 0 Then
                                
                                    '@配列領域の確保 NSYS ループ処理内へ移動
                                    'ReDim .typWfList(.lngWfListCnt)
                                    
                                    '@ｶｳﾝﾀの初期化 NSYS 不要カウンタのため削除
                                    'llngCnt2 = 1
                                    
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                                    For Each ltMsg2 In laAry2
                                    
                                        'NSYS 編集用構造体初期化
                                        Dim typWfListTmp As LotListWfList = New LotListWfList
                                        
                                        '@WFIDを格納
                                        Call ltMsg2.getString(CPstrWF_ID, typWfListTmp.strWfId)
                                        
                                        'NSYS 編集済み構造体を追加
                                        .typWfList.Add(typWfListTmp)
                                        
                                        '@ｶｳﾝﾀ2を+1する NSYS 不要カウンタのため削除
                                        'llngCnt2 = llngCnt2 + 1
                                    Next
                                End If
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            ltypLotListAns.typLotList.Add(typLotListListTmp)
                            
                            '@ｶｳﾝﾀを+1する
                            'llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotList_Sel = True
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypLotListReq.strMsgVer)
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrAry = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrAry = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnUtilRegTmInfo_Upd
    '機　能：端末設定情報登録
    '引　数：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrutilregtminfoVer   ：Msgﾊﾞｰｼﾞｮﾝ(必須)
    '　　　：lstrClassDivision      ：処理区分(26：WP、27工程別、20：装置ｸﾞﾙｰﾌﾟ)(必須)
    '　　　：lstrHostName           ：ﾎｽﾄ名(必須)
    '　　　：ltypUtilRegTmInfo      ：格納ﾃﾞｰﾀ
    '　　　：lstrWPID               ：装置ID(WPID)  ※26：WP場合のは必須
    '　　　：lstrOpID               ：大工程        ※27：工程別の場合は必須
    '　　　：lstrStepId             ：小工程        ※27：工程別の場合は必須
    '　　　：lstrMcGroupID          ：装置ｸﾞﾙｰﾌﾟID  ※20：装置ｸﾞﾙｰﾌﾟの場合は必須
    '戻り値：True：正常、False：異常
    '作成日：2004/05/07 (Fri) 11:45:09 T.Kitagawa
    '更新日：2008/06/27 (Fri) 16:21:19 M.Koni
    '備　考：装置処理待ちロット一覧(ＷＰ別)、ロット一覧(小工程別)、運用ﾓｰﾄﾞ変更、ﾛｯﾄ処理順変更、装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧にて併用
    '　　　：2004/12/10 (Fri) 16:19:48 N.Kasai      ｷｬﾘｱﾀｲﾌﾟIDを追加
    '　　　：2006/06/28 (Wed) 11:29:13 N.Kojima     応答に"TERMINAL_FLAG"追加。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2008/06/27 (Fri) 16:21:38 M.Koni       "TERMINAL_FLAG"削除，"util.regtminfo"応答ﾀｸﾞ変更<案件No.03006>
    '
    Public Function pubblnUtilRegTmInfo_Upd(ByVal lstrSBID As String, _
                                            ByVal lstrutilregtminfoVer As String, _
                                            ByVal lstrClassDivision As String, _
                                            ByVal lstrHostName As String, _
                                            ByRef ltypUtilRegTmInfo As UtilRegTmInfo, _
                                            Optional ByVal lstrWpId As String = vbNullString, _
                                            Optional ByVal lstrOpID As String = vbNullString, _
                                            Optional ByVal lstrStepID As String = vbNullString, _
                                            Optional ByVal lstrMcGroupID As String = vbNullString, _
                                            Optional ByVal lstrCarrierTypeID As String = vbNullString) As Boolean


        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "端末設定情報登録"
            pubblnUtilRegTmInfo_Upd = False
            
            '@端末状態ﾌﾗｸﾞ
            pstrTerminalFlag = vbNullString
            pblnTerminalBCR = False
            
            '@端末情報構造体初期化
            ltypUtilRegTmInfo = New UtilRegTmInfo
            ltypUtilRegTmInfo.typWpList = New List(Of DefaultWpList)
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, lstrSBID)                     'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            If lstrHostName <> vbNullString Then
                Call lrMsg.addString(CPstrHOST_NAME, lstrHostName)              'ﾎｽﾄ名
            Else
                Call lrMsg.addString(CPstrHOST_NAME, CPstrMsgNull)
            End If
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)                      '装置ID
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)                      '大工程
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)                  '小工程
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            If lstrMcGroupID <> vbNullString Then
                Call lrMsg.addString(CPstrMC_GROUP_ID, lstrMcGroupID)           '装置ｸﾞﾙｰﾌﾟID
            Else
                Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
            End If
            If lstrutilregtminfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrutilregtminfoVer)        'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrCarrierTypeID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_TYPE_ID, lstrCarrierTypeID)   'ｷｬﾘｱﾀｲﾌﾟID
            Else
                Call lrMsg.addString(CPstrCARRIER_TYPE_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrutilregtminfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾃﾞﾌｫﾙﾄ装置ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrWP_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾃﾞﾌｫﾙﾄ装置数
                    ltypUtilRegTmInfo.lngWpListCount = laAry.Count
                    
                    '@ﾃﾞﾌｫﾙﾄ装置数が1件以上存在するか
                    If ltypUtilRegTmInfo.lngWpListCount > 0 Then
                    
                        '@ﾃﾞﾌｫﾙﾄ装置配列領域の確保 NSYS ループ処理内へ移動
                        'ReDim ltypUtilRegTmInfo.typWpList(laAry.Count)
                        
                        '@ｶｳﾝﾀの初期化 NSYS 不要となるため削除
                        'llngCnt = 1
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry
                        
                            'NSYS 編集用構造体初期化
                            Dim typWpListTmp As DefaultWpList = New DefaultWpList
                            
                            Call ltMsg.getString(CPstrDEFAULT_WP_ID,typWpListTmp.strDefaultWpID)
                            Call ltMsg.getString(CPstrBCR_FLAG,typWpListTmp.strBCRFlag)
                            
                            '現設定が自端末が含まれるなら，pstrTerminalFlag = 0(自端末) にする。
                            If StrComp(lstrWpId, typWpListTmp.strDefaultWpID, 1) = 0 Then
                                pstrTerminalFlag = 0
                            End If
                            
                            '@端末にBCRが付属しているか確認
                            If typWpListTmp.strBCRFlag = CPstrOne Then
                                pblnTerminalBCR = True
                            End If
                            
                            'NSYS 編集済み構造体を追加
                            ltypUtilRegTmInfo.typWpList.Add(typWpListTmp)
                            
                            '@ｶｳﾝﾀを+1する NSYS 不要となるため削除
                            'llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnUtilRegTmInfo_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrutilregtminfoVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnUtilRefTmInfo_Sel
    '機　能：端末設定情報取得
    '引　数：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrutilreftminfoVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrHostName           ：ﾎｽﾄ名
    '　　　：ltypUtilRefTmInfo      ：格納ﾃﾞｰﾀ
    '戻り値：True：正常、False：異常
    '作成日：2004/04/26 (Mon) 14:59:28 T.Kitagawa
    '更新日：2006/06/28 (Wed) 11:30:09 N.Kojima
    '備　考：
    '　　　：2004/09/24 (Fri) 09:02:19 S.Deguchi    ｼｽﾃﾑﾌﾞﾛｯｸ対応
    '　　　：2004/12/10 (Fri) 16:27:30 N.Kasai      ｷｬﾘｱﾀｲﾌﾟIDを追加
    '　　　：2006/06/28 (Wed) 11:30:09 N.Kojima     応答に"TERMINAL_FLAG"追加。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2006/07/01 (Tue) 11:30:09 M.Koni       "TERMINAL_FLAG"廃止，応答にﾃﾞﾌｫﾙﾄ装置ﾘｽﾄ追加。<案件№.03006>
    Public Function pubblnUtilRefTmInfo_Sel(ByVal lstrSBID As String, _
                                            ByVal lstrutilreftminfoVer As String, _
                                            ByVal lstrHostName As String, _
                                            ByRef ltypUtilRefTmInfo As UtilRefTmInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列確認用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "端末設定情報取得"
            pubblnUtilRefTmInfo_Sel = False

            '@端末状態ﾌﾗｸﾞ
            pstrTerminalFlag = "1"          '非自端末へ
            pblnTerminalBCR = False

            '@端末情報構造体初期化
            ltypUtilRefTmInfo = New UtilRefTmInfo
            ltypUtilRefTmInfo.typWpList = New List(Of DefaultWpList)

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrHostName <> vbNullString Then
                Call lrMsg.addString(CPstrHOST_NAME, lstrHostName)          'ﾎｽﾄ名
            Else
                Call lrMsg.addString(CPstrHOST_NAME, CPstrMsgNull)
            End If
            If lstrutilreftminfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrutilreftminfoVer)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, lstrSBID)                 'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrutilreftminfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@受信結果取得
                    With ltypUtilRefTmInfo
                        Call laMsg.getString(CPstrCURRENT_WP_ID, .strWpID)
                        Call laMsg.getString(CPstrOP_ID, .strOpID)
                        Call laMsg.getString(CPstrSTEP_ID, .strStepID)
                        Call laMsg.getString(CPstrMC_GROUP_ID, .strMcGroupID)
                        Call laMsg.getString(CPstrCARRIER_TYPE_ID, .strCarrierTypeID)
                    End With

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾃﾞﾌｫﾙﾄ装置ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrWP_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾃﾞﾌｫﾙﾄ装置数
                    ltypUtilRefTmInfo.lngWpListCount = laAry.Count

                    '@ﾃﾞﾌｫﾙﾄ装置数が1件以上存在するか
                    If ltypUtilRefTmInfo.lngWpListCount > 0 Then

                        '@ﾃﾞﾌｫﾙﾄ装置配列領域の確保 NSYS ループ処理内へ移動
                        'ReDim ltypUtilRefTmInfo.typWpList(laAry.Count)

                        '@ｶｳﾝﾀの初期化 NSYS 不要となるため削除
                        'llngCnt = 1

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg In laAry
                        
                            'NSYS 編集用構造体を初期化
                            Dim typWpListTmp As DefaultWpList = New DefaultWpList
                            
                            Call ltMsg.getString(CPstrDEFAULT_WP_ID,typWpListTmp.strDefaultWpID)
                                                
                            Call ltMsg.getString(CPstrBCR_FLAG,typWpListTmp.strBCRFlag)
                            
                            '@現設定が自端末が含まれるなら，pstrTerminalFlag = 0(自端末) にする。
                            If StrComp(ltypUtilRefTmInfo.strWpID, typWpListTmp.strDefaultWpID, 1) = 0 Then
                                pstrTerminalFlag = 0
                            End If
                            
                            '@端末にBCRが付属しているか確認
                            If typWpListTmp.strBCRFlag = CPstrOne Then
                                pblnTerminalBCR = True
                            End If
                            
                            'NSYS 編集済み構造体を初期化
                            ltypUtilRefTmInfo.typWpList.Add(typWpListTmp)
                            
                            '@ｶｳﾝﾀを+1する NSYS 不要となるため削除
                            'llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnUtilRefTmInfo_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrutilreftminfoVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnMasPdlist_Sel
    '機　能：機種区分一覧取得
    '引　数：lstrmas_pdlistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision  ：処理区分
    '　　　：ltypPdList()       ：機種ﾘｽﾄ
    '　　　：llngPdListCnt      ：機種のｶｳﾝﾄ
    '　　　：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrScreesSizeID   ：画面ｻｲｽﾞID
    '戻り値：True：成功、False：失敗
    '作成日：2004/02/17 (Tue) 13:33:32 M.Miura
    '更新日：2016/02/11 (Thu) 22:45:37 H.Hayashi
    '備　考：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ：01.01で「親機種IDを追加」2004/07/28
    '　　　：2004/09/06 (Mon) 19:36:10 N.Kasai      MAS_PD_VERSION追加　Ver01.02
    '　　　：2005/07/21 (Thu) 10:51:45 N.Kasai      応答msgにLC_DIRECTION追加
    '　　　：2005/08/08 (Mon) 16:25:54 N.Kojima     応答に"USE_ID"追加
    '　　　：2007/12/25 (Tue) 15:45:02 N.Kojima     ﾁｯﾌﾟ電特対応。応答に"CF_FLAG"、"LP_FLAG"追加。(案件№02263)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnMasPdlist_Sel(ByVal lstrmas_pdlistVer As String, _
                                        ByVal lstrClassDivision As String, _
                                        ByRef ltypPdList As List(Of ProductList), _
                                        ByRef llngPdListCnt As Integer, _
                                        ByVal lstrSBID As String, _
                                        Optional ByVal lstrScreenSizeID As String = vbNullString) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET            As String            '応答取得

        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@初期設定
            pstrMessageName = "機種区分一覧取得"
            pubblnMasPdlist_Sel = False
            
            '@***********************
            '@　送信ﾒｯｾｰｼﾞの作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@画面ｻｲｽﾞID
            If lstrScreenSizeID <> vbNullString Then
                Call lrMsg.addString(CPstrSCREEN_SIZE_ID, lstrScreenSizeID)
            Else
                Call lrMsg.addString(CPstrSCREEN_SIZE_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_pdlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_pdlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_pdlist__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
                
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：機種ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrPD_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認：機種数
                    llngPdListCnt = laAry.Count
                    ltypPdList = New List(Of ProductList)
                    
                    '@機種が1件以上あるか
                    If llngPdListCnt > 0 Then
                        
                        '@配列の定義 NSYS ループ処理内へ移動
                        'ReDim ltypPdList(llngPdListCnt)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要となるため削除
                        For Each ltMsg In laAry
                        
                            'NSYS 編集用構造体初期化
                            Dim ltypPdListTmp As ProductList = New ProductList
                            
                            '@受信結果取得
                            With ltypPdListTmp
                            
                                Call ltMsg.getString(CPstrPD_ID, .strProductID)                 '機種ID
                                Call ltMsg.getString(CPstrPD_NAME, .strProductName)             '機種名
                                Call ltMsg.getString(CPstrMAX_WF_COUNT, .strMaxWFCount)         '最大WF枚数
                                Call ltMsg.getString(CPstrPARENT_PD_ID, .strParentPdId)         '親機種ID
                                Call ltMsg.getString(CPstrMAS_PD_VERSION, .strMasPdVersion)     '機種Ver
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)        '液晶方向
                                Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)                  'CFﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLP_FLAG, .strLpFlag)                  '大判ﾌﾗｸﾞ
                                
                                '@★ L/Rにより処理分岐 ※背景色を格納する(組立工程の機種ｺﾝﾎﾞで使用する) ★
                                Select Case .strLcDirection
                                    
                                    '@〓 L 〓
                                    Case CPstrPDIDL
                                    
                                        .strBackColor = CPlngLColor     '水色
                                        .strForeColor = vbNullString    'NULL
                                        
                                    '@〓 R 〓
                                    Case CPstrPDIDR
                                        
                                        .strBackColor = CPlngRColor     'ﾋﾟﾝｸ
                                        .strForeColor = vbNullString    'NULL
                                        
                                    '@〓 その他 〓
                                    Case Else
                                        
                                        .strBackColor = vbNullString    'NULL
                                        .strForeColor = vbNullString    'NULL
                                End Select
                                
                                Call ltMsg.getString(CPstrUSE_ID, .strUseId)                    '用途ID
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            ltypPdList.Add(ltypPdListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasPdlist_Sel = True
                    
                    
                '@〓 1：FALSE(失敗、異常) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_pdlistVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnMasFlowlist_Sel
    '機　能：流動区分一覧取得
    '引　数：lstrmas_flowlistVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：mtypDivisionList()     ：種別のﾘｽﾄ
    '　　　：llngDivisionCnt        ：種別のｶｳﾝﾄ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrClassDivision      ：処理区分(02:全て/04:機種指定)
    '　　　：lstrPDID               ：PD_ID(処理区分で04指定の場合のみ記載)
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/09 (Wed) 13:11:30 S.Deguchi
    '更新日：2004/09/09 (Thu) 10:18:30 N.Kasai
    '備　考：
    '　　　：2004/09/09 (Thu) 10:18:30 N.Kasai      応答MSGにSBIDを追加
    '　　　：2009/07/24 (Thu) 10:18:30 T.Oide       要求MSGにPDIDを追加
    Public Function pubblnMasFlowlist_Sel(ByVal lstrmas_flowlistVer As String, _
                                          ByRef mtypDivisionList As List(Of DivisionList), _
                                          ByRef llngDivisionCnt As Integer, _
                                          ByVal lstrSBID As String, _
                                          ByVal lstrClassDivision As String, _
                                          Optional ByVal lstrPdID As String = vbNullString) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET            As String            '応答取得

        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@初期設定
            pstrMessageName = "流動区分一覧取得"
            pubblnMasFlowlist_Sel = False

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                      'SBID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrmas_flowlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_flowlistVer)         'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)                      '機種ID
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_flowlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@種別を取得
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrFLOW_CLASS_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    llngDivisionCnt = laAry.Count
                    mtypDivisionList = New List(Of DivisionList)
                    
                    '@配列があればﾃﾞｰﾀ格納
                    If llngDivisionCnt > 0 Then
                        'ReDim Preserve mtypDivisionList(llngDivisionCnt) NSYS ループ処理内へ移動
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要となるため削除
                        For Each ltMsg In laAry
                        
                            'NSYS 編集用構造体初期化
                            Dim mtypDivisionListTmp As DivisionList = New DivisionList
                            
                            '@受信結果取得
                            With mtypDivisionListTmp
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strDivisionID)
                                Call ltMsg.getString(CPstrFLOW_CLASS_NAME, .strDivisionName)
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            mtypDivisionList.Add(mtypDivisionListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasFlowlist_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_flowlistVer)
                    
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
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotChgSeqNum_Chg
    '機　能：ﾛｯﾄ処理順変更
    '引　数：lstrlot_chgseqnumVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：lstrWPID               ：WPID(装置ID)
    '　　　：ltypLotChgSeqNumList() ：格納ﾃﾞｰﾀ
    '　　　：llngLotChgSeqNumListCnt：ﾃﾞｰﾀ件数
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：正常、False：異常
    '作成日：2004/05/24 (Mon) 15:04:28 T.Kitagawa
    '更新日：2019/10/31 (Thu) 13:25:42 T.Oide
    '備　考：
    Public Function pubblnLotChgSeqNum_Chg(ByVal lstrlot_chgseqnumVer As String, _
                                           ByVal lstrSBID As String, _
                                           ByVal lstrWpId As String, _
                                           ByRef ltypLotChgSeqNumList As List(Of LotChgSeqNumList), _
                                           ByVal llngLotChgSeqNumListCnt As Integer, _
                                           ByRef lstrGuidMsg As String, _
                                           ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "ロット処理順変更"
            pubblnLotChgSeqNum_Chg = False

            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg
            laMsg = New TfMsg

            '@***********************
            '@ 送信ﾒｯｾｰｼﾞﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@↓2019/10/31 (Thu) 13:25:22 T.Oide **************************************************
            '@ﾕｰｻﾞID
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            '@↑2019/10/31 (Thu) 13:25:22 T.Oide **************************************************

            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If

            llngCnt = 0
            Do While llngLotChgSeqNumListCnt > llngCnt

                '@ﾛｯﾄ処理順変更ﾒｯｾｰｼﾞ作成
                With ltypLotChgSeqNumList(llngCnt)

                    '@ﾛｯﾄID
                    If .strLotID <> vbNullString Then
                        Call ltMsg.addString(CPstrLOT_ID, .strLotID)
                    Else
                        Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                    End If

                    '@処理順
                    If .strSeqNum <> vbNullString Then
                        Call ltMsg.addString(CPstrSEQ_NUM, .strSeqNum)
                    Else
                        Call lrMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)
                    End If

                    '@大工程
                    If .strOpID <> vbNullString Then
                        Call ltMsg.addString(CPstrOP_ID, .strOpID)
                    Else
                        Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                    End If

                    '@小工程
                    If .strStepID <> vbNullString Then
                        Call ltMsg.addString(CPstrSTEP_ID, .strStepID)
                    Else
                        Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                    End If

                    '@最終更新日時
                    If .strLotLastUpdate <> vbNullString Then
                        Call ltMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                    Else
                        Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                    End If

                    '@処理可能ﾚｼﾋﾟﾌﾗｸﾞ
                    If .strAvailableRecipeFlag <> vbNullString Then
                        Call ltMsg.addString(CPstrAVAILABLE_RECIPE_FLAG, .strAvailableRecipeFlag)
                    Else
                        Call lrMsg.addString(CPstrAVAILABLE_RECIPE_FLAG, CPstrMsgNull)
                    End If

                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                    llngCnt = llngCnt + 1
                End With
            Loop

            Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
            lrAry.Clear

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_chgseqnumVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_chgseqnumVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chgseqnum, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@戻り値に"True：更新成功"をｾｯﾄ
                    pubblnLotChgSeqNum_Chg = True

                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_chgseqnumVer)

                '@〓 その他のｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMasResonCode_Sel
    '機　能：理由ｺｰﾄﾞ取得
    '引　数：lstrmas_reasoncodeVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分
    '　　　：ltypMasItemList        ：取得ﾘｽﾄ
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/09 (Wed) 11:27:47 K.Takano
    '更新日：2005/08/08 (Mon) 20:10:47 N.Kojima
    '備　考：
    '　　　：2005/08/08 (Mon) 20:10:47 N.Kojima     応答に"DEFAULT_HOLD_PERIOD"を追加
    '　　　：2005/11/29 (Tue) 09:12:51 S.Deguchi    応答の"DEFAULT_HOLD_PERIOD"を削除
    Public Function pubblnMasResonCode_Sel(ByVal lstrmas_reasoncodeVer As String, _
                                           ByVal lstrClassDivision As String, _
                                           ByRef ltypMasItemList As MasItemList) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "理由コード取得"
            pubblnMasResonCode_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrmas_reasoncodeVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_reasoncodeVer)           'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)        '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_reasoncode, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    With ltypMasItemList
                        '@ﾃﾞｰﾀを変数に格納
                        Call laMsg.getString(CPstrLOT_EVENT_ID, .strLotEventId)                                 'ﾛｯﾄｲﾍﾞﾝﾄID
                        
                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrLOT_REASON_CODE_LIST, laAry)
                        
                        '@要素数格納
                        .lngListCnt = laAry.Count
                        .typeMasItem = New List(Of MasItem)
                        
                        '@要素数が0以外ならﾃﾞｰﾀ格納
                        If .lngListCnt <> 0 Then
                            'ReDim Preserve .typeMasItem(.lngListCnt) NSYS ループ処理内へ移動
                            'llngCnt = 1 NSYS 不要となるため削除
                            For Each ltMsg In laAry
                            
                                'NSYS 編集用構造体初期化
                                Dim typeMasItemTmp As MasItem = New MasItem
                                
                                Call ltMsg.getString(CPstrREASON_CODE, typeMasItemTmp.strItemID)         '保留理由ｺｰﾄﾞ
                                Call ltMsg.getString(CPstrREASON_NAME, typeMasItemTmp.strItemName)       '保留理由名
                                
                                'NSYS 編集済み構造体を追加
                                .typeMasItem.Add(typeMasItemTmp)
                                
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasResonCode_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_reasoncodeVer)
                    
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

    '関数名：pubblnCarrMasList_Sel
    '機　能：ｷｬﾘｱﾀｲﾌﾟ一覧取得
    '引　数：lstrcarrmaslist_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision  ：処理区分(02:全て、38:ﾏｽﾀｷｬﾘｱﾀｲﾌﾟ)
    '　　　：llngCarrierCnt     ：ｷｬﾘｱﾘｽﾄのｶｳﾝﾄ
    '　　　：ltypCarrierMaster()：ｷｬﾘｱ一覧格納
    '　　　：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/09 (Wed) 10:23:06 K.Takano
    '更新日：2005/11/04 (Fri) 11:12:26 N.Kojima
    '備　考：
    '　　　：2004/06/09 (Wed) 10:23:06 K.Takano     改善対応にて、"mas_.carrinfo"から統合
    '　　　：2004/08/02 (Mon) 10:30:55 N.Kasai      RESTRICTED_SB_ID(ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID)を追加
    '　　　：2004/08/24 (Fri) 08:50:55 N.Kasai      RESTRICTED_SB_IDを削除、処理区分を追加
    '　　　：2004/12/10 (Fri) 16:37:55 N.Kasai      SBIDを追加
    '　　　：2005/11/04 (Fri) 11:12:26 N.Kojima     応答に"TYPE_FLAG"追加。(ﾕｰｻﾞｰ要望№0104)
    Public Function pubblnCarrMasList_Sel(ByVal lstrcarrmaslist_Ver As String, _
                                          ByVal lstrClassDivision As String, _
                                          ByRef llngCarrierCnt As Integer, _
                                          ByRef ltypCarrierMaster As List(Of CarrierMaster), _
                                          ByVal lstrSBID As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "キャリアタイプ一覧取得"
            pubblnCarrMasList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrcarrmaslist_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrcarrmaslist_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
         
            '@SB_ID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrmaslist_, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrCARRTYP_LIST, laAry)
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ件数設定
                    llngCarrierCnt = laAry.Count
                    ltypCarrierMaster = New List(Of CarrierMaster)
                    If llngCarrierCnt > 0 Then
                        'ReDim Preserve ltypCarrierMaster(llngCarrierCnt) NSYS ループ処理内へ移動
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要となるため削除
                        For Each ltMsg In laAry
                        
                            'NSYS 編集用構造体初期化
                            Dim ltypCarrierMasterTmp As CarrierMaster = New CarrierMaster
                            
                            '@受信結果取得
                            With ltypCarrierMasterTmp
                                Call ltMsg.getString(CPstrCARRIER_DISC_ID, .strCarrierDiscID)       'ｷｬﾘｱ識別ID
                                Call ltMsg.getString(CPstrVENDER_ID, .strVendorID)                  'ﾍﾞﾝﾀﾞｰID
                                Call ltMsg.getString(CPstrVENDER_NAME, .strVendorName)              'ﾍﾞﾝﾀﾞｰ名
                                Call ltMsg.getString(CPstrCARRIER_TYPE_ID, .strCarrierTypeID)       'ｷｬﾘｱﾀｲﾌﾟID
                                Call ltMsg.getString(CPstrCARRIER_TYPE_NAME, .strCarrierTypeName)   'ｷｬﾘｱﾀｲﾌﾟ名
                                Call ltMsg.getString(CPstrSLOT_SIZE, .strSlotSize)                  'ｽﾛｯﾄ数
                                Call ltMsg.getString(CPstrMAX_CLEAN_COUNT, .strMaxCleanCount)       '洗浄耐用回数
                                Call ltMsg.getString(CPstrMAX_USE_COUNT, .strMaxUseCount)           '使用耐用回数
                                Call ltMsg.getString(CPstrTYPE_FLAG, .strTypeFlag)                  'ｷｬﾘｱﾀｲﾌﾟﾌﾗｸﾞ(1or0)
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            ltypCarrierMaster.Add(ltypCarrierMasterTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnCarrMasList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrcarrmaslist_Ver)
                    
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnCarrList_Sel
    '機　能：新・ｷｬﾘｱ一覧取得
    '引　数：ltypCarrierListReq ：要求構造体
    '　　　：ltypCarrierList    ：応答構造体
    '戻り値：True:成功/Flase：失敗
    '作成日：2004/06/09 (Wed) 11:41:47 Y.Yamagishi
    '更新日：2006/02/21 (Tue) 11:22:20 N.Kojima
    '備　考：
    '　　　：2004/09/26 (Sun) 14:56:41 S.Deguchi    ｼｽﾃﾑﾌﾞﾛｯｸ追加
    '　　　：2004/09/28 (Tue) 09:41:49 N.Kasai　    要求MSGにｷｬﾘｱID追加
    '　　　：2004/10/22 (Fri) 16:59:09 Y.Yamagishi　要求MSGに洗浄条件追加
    '　　　：2004/12/15 (Wed) 14:59:48 N.Kasai      応答MSGに搬送先を追加
    '　　　：2005/01/20 (Thu) 17:22:59 N.Kasai      応答MSGにｷｬﾘｱ目的位置名(搬送名)を追加
    '　　　：2005/02/24 (Thu) 09:35:03 N.Kasai      応答MSGにSMIF格納ﾚﾁｸﾙIDを追加
    '　　　：2005/02/28 (Mon) 10:26:56 N.Kojima     応答ﾀｸﾞ"DEST"を"DEST_POSITION_ID"に変更(改善№512)
    '　　　：2005/03/07 (Mon) 17:37:06 N.Kasai      応答ﾀｸﾞ追加"RETICLE_STATUS_ITEM_ID","RETICLE_STATUS_ITEM_NAME"(改善№602)
    '　　　：2005/08/11 (Thu) 10:35:39 N.Kasai      応答ﾀｸﾞ追加(CARRIER_MOVE_STAT)
    '　　　：2005/10/06 (Thu) 14:21:28 S.Deguchi    不具合№2995の対応で要求Tagを構造体とする処理に修正。
    '　　　：2006/02/21 (Tue) 11:22:20 N.Kojima     要求ﾀｸﾞに"CATEGORY_ID",応答ﾀｸﾞに追加→"CATEGORY_ID","CATEGORY_NAME","COMMENTS","EDIT_TIME"(ﾕｰｻﾞｰ要望№0141)
    Public Function pubblnCarrList_Sel(ByRef ltypCarrierListReq As CarrierListReq, _
                                       ByRef ltypCarrierList As CarrList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得

        Try

            pstrMessageName = "キャリア一覧取得"
            pubblnCarrList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypCarrierListReq
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strRestrictedSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrRESTRICTED_SB_ID, .strRestrictedSBID)
                Else
                    Call lrMsg.addString(CPstrRESTRICTED_SB_ID, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱﾀｲﾌﾟID
                If .strCarrierTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_TYPE_ID, .strCarrierTypeID)
                Else
                    Call lrMsg.addString(CPstrCARRIER_TYPE_ID, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱID(ｷｬﾘｱ指定の場合)
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
                '@洗浄条件
                If .strCleanCondition <> vbNullString Then
                    Call lrMsg.addString(CPstrCLEAN_CONDITION, .strCleanCondition)
                Else
                    Call lrMsg.addString(CPstrCLEAN_CONDITION, CPstrMsgNull)
                End If
                
                '@ｶﾃｺﾞﾘID
                If .strCategoryID <> vbNullString Then
                    Call lrMsg.addString(CPstrCATEGORY_ID, .strCategoryID)
                Else
                    Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
                End If

            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrlist____, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                '@受信結果取得
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrCARRIER_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    ltypCarrierList.lngCarrierListCnt = laAry.Count
                    ltypCarrierList.typCarrierList = New List(Of CarrierIDList)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypCarrierList.lngCarrierListCnt > 0 Then
                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        '@配列の要素数を設定 NSYS ループ処理内へ移動
                        'ReDim Preserve ltypCarrierList.typCarrierList(ltypCarrierList.lngCarrierListCnt)
                        
                        '@ｶｳﾝﾄ初期化
                        'llngCnt = 1 NSYS 不要となるため削除
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                        
                            'NSYS 編集用構造体初期化
                            Dim typCarrierListTmp As CarrierIDList = New CarrierIDList
                            
                            With typCarrierListTmp
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                            'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrEMPTY_FLAG, .strEmptyFlag)                            'ｷｬﾘｱ状態
                                Call ltMsg.getString(CPstrSTART_TIME, .strStartTime)                            '利用開始日
                                Call ltMsg.getString(CPstrCLEAN_FLAG, .strCleanFlag)                            '洗浄必要ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrCLEAN_TIME, .strCreanTime)                            '最終洗浄日時
                                Call ltMsg.getString(CPstrTOTAL_USE_COUNT, .strTotalUseCount)                   '総使用回数
                                Call ltMsg.getString(CPstrCLEAN_COUNT, .strCleanCount)                          '洗浄回数
                                Call ltMsg.getString(CPstrAFTER_CLEAN_USE_COUNT, .strAfterCleanUseCount)        '洗浄後使用回数
                                Call ltMsg.getString(CPstrCARRIER_STAT_ID, .strCarrierStatID)                   'ｷｬﾘｱ状態
                                Call ltMsg.getString(CPstrCARRIER_STAT_NAME, .strCarrierStatName)               'ｷｬﾘｱ状態(和名)
                                Call ltMsg.getString(CPstrVENDER_NAME, .strVendorName)                          'ﾍﾞﾝﾀﾞｰ名
                                Call ltMsg.getString(CPstrPRODUCTION_DATE, .strProductionDate)                  '製造年月日
                                Call ltMsg.getString(CPstrCURRENT_POSITION_ID, .strCurrentPositionID)           '現在位置
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)       '現在位置名
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                    'ﾛｯﾄID
                                Call ltMsg.getString(CPstrLOADER_UNLOADER_KIND, .strLdrUndrKind)                'Loader/Unloader種別
                                Call ltMsg.getString(CPstrDEST_POSITION_ID, .strDestPositionID)                 'ｷｬﾘｱ目的位置ID(搬送先)
                                Call ltMsg.getString(CPstrDEST_NAME, .strDestName)                              'ｷｬﾘｱ目的位置名(搬送先)
                                Call ltMsg.getString(CPstrRETICLE_ID, .strReticleID)                            'SMIF格納ﾚﾁｸﾙID
                                Call ltMsg.getString(CPstrRETICLE_STATUS_ITEM_ID, .strReticleStatusItemID)      'ﾚﾁｸﾙ状態項目ID
                                Call ltMsg.getString(CPstrRETICLE_STATUS_ITEM_NAME, .strReticleStatusItemName)  'ﾚﾁｸﾙ状態項目名
                                Call ltMsg.getString(CPstrCARRIER_MOVE_STAT, .strCarrierMoveStat)               'ｷｬﾘｱ移載状態(0:移載外(不可)、1:移載中(可))
                                Call ltMsg.getString(CPstrCATEGORY_ID, .strCategoryID)                          'ｶﾃｺﾞﾘID
                                Call ltMsg.getString(CPstrCATEGORY_NAME, .strCategoryName)                      'ｶﾃｺﾞﾘ名
                                Call ltMsg.getString(CPstrCOMMENTS, .strComments)                               'ｺﾒﾝﾄ
                                Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)                              '最終更新日時
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            ltypCarrierList.typCarrierList.Add(typCarrierListTmp)
                            
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnCarrList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypCarrierListReq.strMsgVer)

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

    '関数名：pubblnLotWplist_Sel
    '機　能：ﾛｯﾄ装置情報取得
    '引　数：CPstrlot_wplist__Ver   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分
    '　　　：lstrLotID              ：ﾛｯﾄID
    '　　　：lstrOpID               ：大工程ID
    '　　　：lstrStepID             ：小工程ID
    '　　　：lstrAltNumber          ：代替工程№
    '　　　：ltypWpList             ：装置情報格納用構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/09 (Wed) 10:01:55 M.Miura
    '更新日：2004/10/22 (Fri) 17:04:40 Y.Yamagishi
    '備　考：2004/08/31 (Tue) 15:50:22 M.Miura　    受信にﾎﾟｰﾄﾀｲﾌﾟを追加(不具合改善№525)
    '　　　：2004/09/17 (Fri) 19:33:51 N.Kasai　    応答にUNLOADERｷｬﾘｱﾀｲﾌﾟIDを追加
    '　　　：2004/09/28 (Tue) 08:40:21 S.Deguchi    "WP_STATUS_NAME"追加
    '　　　：2004/06/09 (Wed) 10:01:55 M.Miura      受信結果にPORT_STATUSを追加
    '　　　：2004/10/22 (Fri) 17:04:40 Y.Yamagishi  受信結果にCLEAN_CONDITION(洗浄条件)を追加
    '　　　：2005/06/29 (Wed) 16:12:15 S.Deguchi    不具合№212の対応で,Tag：LOT_RECIPE_FLAGを追加
    Public Function pubblnLotWplist_Sel(ByVal CPstrlot_wplist__Ver As String, _
                                        ByVal lstrClassDivision As String, _
                                        ByVal lstrLotID As String, _
                                        ByVal lstrOpID As String, _
                                        ByVal lstrStepID As String, _
                                        ByVal lstrAltNumber As String, _
                                        ByRef ltypLotWpList As LotWpList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ロット装置情報取得"
            pubblnLotWplist_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg2 = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                    'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)                      '大工程ID
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, lstrStepID)                  '小工程ID
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)                     'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If CPstrlot_wplist__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, CPstrlot_wplist__Ver)        'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrAltNumber <> vbNullString Then
                Call lrMsg.addString(CPstrALT_NUMBER, lstrAltNumber)            '代替番号
            Else
                Call lrMsg.addString(CPstrALT_NUMBER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_wplist__, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@ﾃﾞｰﾀを取得
                    Call laMsg.getMsgAry(CPstrWP_LIST, laAry)   '装置ﾘｽﾄ
                    
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypLotWpList.lngWPCnt = laAry.Count
                        ltypLotWpList.typWpList = New List(Of WpList)
                        
                        '@配列の要素数を設定 NSYS ループ処理内へ移動
                        'ReDim Preserve ltypLotWpList.typWpList(ltypLotWpList.lngWPCnt)
                        'llngCnt = 1 NSYS 不要となるため削除
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                        
                            'NSYS 編集前構造体初期化
                            Dim typWpListTmp As WpList = New WpList
                            
                            With typWpListTmp
                            
                                Call ltMsg.getString(CPstrWP_ID, .strWpID)                                  '装置ID
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)                              '装置名
                                Call ltMsg.getString(CPstrWP_STATUS_NAME, .strWpStatusName)                 '装置状態名
                                Call ltMsg.getString(CPstrEQ_TYPE, .strEqType)                              'EQﾀｲﾌﾟﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrLOADER_UNLOADER_FLAG, .strLoaderUnloaderFlag)     'ﾛｰﾀﾞｰｱﾝﾛｰﾀﾞｰﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrAFTER_CARRIER_TYPE_ID, .strAfterCarrierTypeId)    'UNLOADERｷｬﾘｱﾀｲﾌﾟID
                                Call ltMsg.getString(CPstrCLEAN_CONDITION, .strCleanCondition)              '洗浄条件
                                Call ltMsg.getString(CPstrLOT_RECIPE_FLAG, .strLotRecipeFlag)               'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ
                                
                                Call ltMsg.getMsgAry(CPstrPORT_LIST, laAry2)                                'ﾎﾟｰﾄﾘｽﾄ
                                '@ｱﾚｰの数が0じゃなければ処理
                                If laAry2.Count <> 0 Then
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                    'llngCnt2 = laAry2.Count NSYS 不要となるため削除
                                    typWpListTmp.lngPortCnt = laAry2.Count
                                    typWpListTmp.typPortList = New List(Of PortList)
                                    '@配列の要素数を設定 NSYS ループ処理内へ移動
                                    'ReDim Preserve ltypLotWpList.typWpList(llngCnt).typPortList(llngCnt2)
                                    '@ｱﾚｰの各要素取得
                                    'llngCnt2 = 1 NSYS 不要となるため削除
                                    For Each ltMsg2 In laAry2
                                    
                                        'NSYS 編集前構造体初期化
                                        Dim typPortListTmp As PortList = New PortList
                                        
                                        With typPortListTmp
                                            Call ltMsg2.getString(CPstrPORT_ID, .strPortID)         'ﾎﾟｰﾄID
                                            Call ltMsg2.getString(CPstrPORT_NAME, .strPortName)     'ﾎﾟｰﾄ名
                                            Call ltMsg2.getString(CPstrPORT_TYPE, .strPortType)     'ﾎﾟｰﾄﾀｲﾌﾟ
                                            Call ltMsg2.getString(CPstrPORT_STATUS, .strPortStatus) 'ﾎﾟｰﾄ状態
                                        End With
                                        
                                        'NSYS 編集後構造体を追加
                                        typWpListTmp.typPortList.Add(typPortListTmp)
                                        'llngCnt2 = llngCnt2 + 1 NSYS 不要となるため削除
                                    Next
                                End If
                            End With
                            
                            'NSYS 編集後構造体を追加
                            ltypLotWpList.typWpList.Add(typWpListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotWplist_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, CPstrlot_wplist__Ver)
                    
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
            laAry2 = Nothing
            ltMsg2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            laAry2 = Nothing
            ltMsg2 = Nothing
            
        End Try
    End Function

    '関数名：pubblnVendClassList_Sel
    '機　能：ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ取得
    '引　数：lstrmas_vendclasslistVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision          ：処理区分
    '　　　：ltypVenderList             ：ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/09 (Wed) 14:58:23 N.Kasai
    '更新日：2004/09/09 (Thu) 09:03:00 Y.Yamagishi
    '備　考：
    '　　　：2004/09/09 (Thu) 09:03:00 Y.Yamagishi  要求ﾀｸﾞにSBID追加
    Public Function pubblnVendClassList_Sel(ByVal lstrmas_vendclasslistVer As String, _
                                            ByVal lstrClassDivision As String, _
                                            ByRef ltypVenderlist As VenderList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        
        Try
            
            pstrMessageName = "ベンダークラスリスト取得"
            pubblnVendClassList_Sel = False
            
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)                     'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrmas_vendclasslistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_vendclasslistVer)   'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_vendclasslist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrVENDER_CLASS_LIST, laAry)

                    ltypVenderlist.lngVenderClassListCnt = laAry.Count
                    ltypVenderlist.typVenderClassList = New List(Of VenderClassList)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypVenderlist.lngVenderClassListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        '@配列の要素数を設定 NSYS ループ処理内へ移動
                        'ReDim Preserve ltypVenderlist.typVenderClassList(ltypVenderlist.lngVenderClassListCnt)
                        'llngCnt = 1 NSYS 不要となるため削除
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                        
                            'NSYS 編集前構造体初期化
                            Dim typVenderClassListTmp As VenderClassList = New VenderClassList
                            
                            With typVenderClassListTmp
                                Call ltMsg.getString(CPstrVENDER_CLASS_ID, .strVenderClassId)       '部品ID
                                Call ltMsg.getString(CPstrVENDER_CLASS_NAME, .strVenderClassName)   '部品名
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            ltypVenderlist.typVenderClassList.Add(typVenderClassListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnVendClassList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_vendclasslistVer)
                    
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

    '関数名：pubblnMasPartList_Sel
    '機　能：部材ｺｰﾄﾞﾘｽﾄ取得
    '引　数：ltypMasPartlist    ：部材ｺｰﾄﾞﾘｽﾄ取得要求構造体
    '　　　：llngPartListCnt    ：ﾃﾞｰﾀ数
    '　　　：mtyppartlist()     ：部材ﾘｽﾄ
    '戻り値：True：正常、False：異常
    '作成日：2004/09/06 (Mon) 17:48:35 N.Kasai
    '更新日：2004/09/06 (Mon) 17:48:35
    '備　考：
    Public Function pubblnMasPartList_Sel(ByRef ltypMasPartlist As MasPartlist, _
                                          ByRef llngPartListCnt As Integer, _
                                          ByRef mtyppartlist As List(Of PartClassList)) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "部材コードリスト取得"
            pubblnMasPartList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypMasPartlist
            
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
                '@機種ID
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
                '@PDﾊﾞｰｼﾞｮﾝ
                If .strMasPdVersion <> vbNullString Then
                    Call lrMsg.addString(CPstrMAS_PD_VERSION, .strMasPdVersion)
                Else
                    Call lrMsg.addString(CPstrMAS_PD_VERSION, CPstrMsgNull)
                End If
                '@部品ID(部材ID)
                If .strVenderClassId <> vbNullString Then
                    Call lrMsg.addString(CPstrVENDER_CLASS_ID, .strVenderClassId)
                Else
                    Call lrMsg.addString(CPstrVENDER_CLASS_ID, CPstrMsgNull)
                End If
            
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrmas_partlist, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)

                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                        Call laMsg.getMsgAry(CPstrPART_LIST, laAry)
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        'llngCnt = llngPartListCnt + 1 NSYS 不要となるため削除

                        'NSYS 引数カウンタが0の場合のみ初期化する
                        If llngPartListCnt = 0 Then
                            mtyppartlist = New List(Of PartClassList)
                        End If

                        'NSYS 引数カウンタへ検索結果件数を加算
                        llngPartListCnt = llngPartListCnt + laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If llngPartListCnt > 0 Then
                            'ReDim Preserve mtyppartlist(llngPartListCnt) NSYS ループ処理内へ移動
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            'llngCnt = 1 NSYS 不要となるため削除
                            For Each ltMsg In laAry
                            
                                'NSYS 編集前構造体初期化
                                Dim mtyppartlistTmp As PartClassList = New PartClassList
                                
                                '@受信結果取得
                                With mtyppartlistTmp
                                    Call ltMsg.getString(CPstrPART_CODE, .strPartCode)
                                    Call ltMsg.getString(CPstrPART_NAME, .strPartName)
                                    Call ltMsg.getString(CPstrREGENERATION_COUNT, .strRegenerationCount)
                                    Call ltMsg.getString(CPstrTHICKNESS_CLASS, .strThicknessClass)
                                    Call ltMsg.getString(CPstrVENDER_NAME, .strVenderName)
                                End With
                                
                                'NSYS 編集済み構造体を追加
                                mtyppartlist.Add(mtyppartlistTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                        
                        '@関数の処理結果(成功)格納
                         pubblnMasPartList_Sel = True
                         
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
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnInvPartList_Sel
    '機　能：部材一覧情報取得
    '引　数：lstrinv_partlistVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分
    '　　　：lstrPartCode           ：部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
    '　　　：lstrVenderClassID      ：部品ID(部材ID)
    '　　　：lstrPdID               ：機種ID
    '　　　：ltypPartLotList()      ：格納ﾃﾞｰﾀ
    '　　　：llngPartLotListCnt     ：ﾃﾞｰﾀ件数
    '　　　：lstrThicknessCode      ：CF板厚　(CF以外は空)
    '　　　：lstrReworkCount        ：CFﾘﾜｰｸ数　(CF以外は空)
    '戻り値：True：正常、False：異常
    '作成日：2004/06/09 (Wed) 11:36:41 N.Kasai
    '更新日：2004/06/11 (Fri) 14:55:11 H.Wajima
    '備　考：部材ﾘｽﾄと統合(CF板厚,CFﾘﾜｰｸ数はCF以外は空)
    Public Function pubblnInvPartList_Sel(ByVal lstrinv_partlistVer As String, _
                                          ByVal lstrClassDivision As String, _
                                          ByVal lstrPartCode As String, _
                                          ByVal lstrVenderClassID As String, _
                                          ByRef ltypPartLotList As List(Of PartLotList), _
                                          ByRef llngPartLotListCnt As Integer, _
                                          Optional ByVal lstrThicknessCode As String = vbNullString, _
                                          Optional ByVal lstrReworkCount As String = vbNullString, _
                                          Optional ByVal lstrPdID As String = vbNullString) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "部材一覧取得"
            pubblnInvPartList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            '@部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
            If lstrPartCode <> vbNullString Then
                Call lrMsg.addString(CPstrPART_CODE, lstrPartCode)
            Else
                Call lrMsg.addString(CPstrPART_CODE, CPstrMsgNull)
            End If
            '@部品ID(部材ID)
            If lstrVenderClassID <> vbNullString Then
                Call lrMsg.addString(CPstrVENDER_CLASS_ID, lstrVenderClassID)
            Else
                Call lrMsg.addString(CPstrVENDER_CLASS_ID, CPstrMsgNull)
            End If
            '@機種ID
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            '@CF板厚　(CF以外は空)
            If lstrThicknessCode <> vbNullString Then
                Call lrMsg.addString(CPstrTHICKNESS_CODE, lstrThicknessCode)
            Else
                Call lrMsg.addString(CPstrTHICKNESS_CODE, CPstrMsgNull)
            End If
            '@CFﾘﾜｰｸ数　(CF以外は空)
            If lstrReworkCount <> vbNullString Then
                Call lrMsg.addString(CPstrREWORK_COUNT, lstrReworkCount)
            Else
                Call lrMsg.addString(CPstrREWORK_COUNT, CPstrMsgNull)
            End If
            '@SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_partlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_partlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_partlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrPART_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    llngPartLotListCnt = laAry.Count
                    ltypPartLotList = New List(Of PartLotList)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngPartLotListCnt > 0 Then
                        '@構造体初期化 NSYS ループ処理内へ移動
                        'ReDim ltypPartLotList(llngPartLotListCnt)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要となるため削除
                        For Each ltMsg In laAry
                        
                            'NSYS 編集前構造体初期化
                            Dim ltypPartLotListTmp As PartLotList = New PartLotList
                            
                            '@受信結果取得
                            With ltypPartLotListTmp
                                Call ltMsg.getString(CPstrPART_CODE, .strPartCode)                      '部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
                                Call ltMsg.getString(CPstrSB_ID, .strSbID)                              'ｼｽﾃﾑﾌﾞﾛｯｸ
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                            '在庫ﾛｯﾄID
                                Call ltMsg.getString(CPstrPRODUCTION_LOT_ID, .strProductionLotId)       '製造ﾛｯﾄID
                                Call ltMsg.getString(CPstrNUM, .strNum)                                 '受入数
                                Call ltMsg.getString(CPstrDATE, .strDate)                               '受入日時
                                Call ltMsg.getString(CPstrEMP_ID, .strEmpID)                            '作業者ID(受入担当者)
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                        '作業者名(受入担当者)
                                Call ltMsg.getString(CPstrSHIPPING_LOT_ID, .strShippingLotID)           'CFﾒｰｶ出荷ﾛｯﾄID
                                Call ltMsg.getString(CPstrTHICKNESS_CODE, .strThicknessCode)            'CF板厚
                                Call ltMsg.getString(CPstrCURRENT_STATUS, .strCurrentStatus)            '現在状態
                                Call ltMsg.getString(CPstrREWORK_COUNT, .strReworkCount)                'CFﾘﾜｰｸ数
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           'LOT最終更新日時
                                Call ltMsg.getString(CPstrREASON_CODE, .strReasonCode)                  '理由ｺｰﾄﾞ(停止ｺｰﾄﾞ、解除ｺｰﾄﾞ、受入ｺｰﾄﾞ、払出ｺｰﾄﾞ)
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            ltypPartLotList.Add(ltypPartLotListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnInvPartList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrinv_partlistVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotStepList_Sel
    '機　能：小工程取得
    '引　数：lstrSbID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrmas_steplistVer：MSGﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision  ：処理区分(28:大工程ID指定)
    '　　　：ltypLotList        ：ﾛｯﾄﾘｽﾄ(現在、処理区分"4E"の時のみ使用)
    '　　　：ltypMasStepList    ：格納ﾃﾞｰﾀ
    '　　　：lstrOpID           ：大工程ID
    '　　　：llngLotCnt         ：ﾛｯﾄｶｳﾝﾄ(現在、処理区分"4E"の時のみ使用)
    '戻り値：True：正常、False：異常
    '作成日：2004/08/24 (Tue) 16:41:33 T.Kitagawa
    '更新日：2008/01/22 (Tue) 09:56:51 N.Kojima
    '備　考：
    '　　　：2004/09/01 (Wed) 11:07:04 T.Kitagawa　 ﾚﾁｸﾙ使用ﾌﾗｸﾞ削除
    '　　　：2004/09/02 (Thu) 16:37:01 T.Kitagawa　 CPstrSTEP_ID_LIST　→　CPstrSTEP_LIST　へ変更
    '　　　：2004/09/09 (Thu) 21:00:23 T.Kitagawa　 処理区分から　02:全て、2M:ｶﾃｺﾞﾘID指定、29:小工程ID指定　を削除
    '　　　：2005/04/26 (Tue) 15:55:28 S.Deguchi    応答に,Action_Flagを追加
    '　　　：2008/01/22 (Tue) 09:56:51 N.Kojima     要求に"LOT_LIST"追加。(案件№02405)
    Public Function pubblnLotStepList_Sel(ByVal lstrSBID As String, _
                                          ByVal lstrmas_steplistVer As String, _
                                          ByVal lstrClassDivision As String, _
                                          ByRef ltypLotList As List(Of LotIdList), _
                                          ByRef ltypMasStepList As MasStepList, _
                                          Optional ByVal lstrOpID As String = vbNullString, _
                                          Optional ByVal llngLotCnt As Integer = 0) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "小工程取得"
            pubblnLotStepList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_steplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_steplistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@大工程ID
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄﾘｽﾄ情報ｾｯﾄ
            llngCnt = 0
            Do While llngLotCnt > llngCnt
                With ltypLotList(llngCnt)
                    '@ﾛｯﾄID
                    If .strLotID <> vbNullString Then
                        Call ltMsg.addString(CPstrLOT_ID, .strLotID)
                    Else
                        Call ltMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                    End If
                    
                    llngCnt = llngCnt + 1
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                End With
            Loop
            
            Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
            lrAry.Clear
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_steplist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypMasStepList
                        '@受信結果取得
                        Call laMsg.getMsgAry(CPstrSTEP_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngMasStepCnt = laAry.Count
                        .typMasStepId = New List(Of MasStepId)
                        '@配列があればﾃﾞｰﾀ格納
                        If .lngMasStepCnt > 0 Then
                            '@構造体初期化 NSYS ループ処理内へ移動
                            'ReDim .typMasStepId(.lngMasStepCnt)
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            'llngCnt = 1 NSYS 不要となるため削除
                            For Each ltMsg In laAry
                            
                                'NSYS 編集前構造体初期化
                                Dim typMasStepIdTmp As MasStepId = New MasStepId
                                
                                '@受信結果取得
                                With typMasStepIdTmp
                                    '@小工程ID
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)

                                    '@ｱｸｼｮﾝﾌﾗｸﾞ
                                    If lstrClassDivision = CPstrCD28 Then
                                        Call ltMsg.getString(CPstrACTION_FLAG, .strActionFlag)
                                    Else
                                        .strActionFlag = vbNullString                                   '(Null)
                                    End If
                                End With
                                
                                'NSYS 編集後構造体を追加
                                .typMasStepId.Add(typMasStepIdTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotStepList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_steplistVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
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

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnThicknessClass_Sel
    '機　能：板厚区分ﾘｽﾄ取得
    '引　数：lstrmas_thicklistVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypthicknesslist()    ：格納ﾃﾞｰﾀ
    '　　　：llngthicknessCnt       ：ﾃﾞｰﾀ数
    '戻り値：True：正常、False：異常
    '作成日：2004/05/07 (Fri) 12:59:32 S.Deguchi
    '更新日：2004/06/01 (Tue) 15:46:59 N.Kasai
    '備　考：
    Public Function pubblnThicknessClass_Sel(ByVal lstrmas_thicklistVer As String, _
                                             ByRef mtypThicknessClassList As List(Of ThicknessClassList), _
                                             ByRef llngthicknessCnt As Integer) As Boolean

        Dim lrMsg              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry1             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg2             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry2             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET            As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "板厚リスト情報取得"
            pubblnThicknessClass_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_thicklistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_thicklistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_thicklist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrTHICKNESS_CLASS_LIST, laAry1)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                    llngthicknessCnt = laAry1.Count
                    mtypThicknessClassList = New List(Of ThicknessClassList)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngthicknessCnt > 0 Then
                        'ReDim Preserve mtypThicknessClassList(llngthicknessCnt) NSYS ループ処理内へ移動
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ１から各Msg取得
                        'llngCnt1 = 1 NSYS 不要となるため削除
                        For Each ltMsg1 In laAry1

                            'NSYS 編集用構造体初期化
                            Dim mtypThicknessClassListTmp As ThicknessClassList = New ThicknessClassList

                            '@受信結果取得
                            With mtypThicknessClassListTmp
                                '@ﾃﾞｰﾀ(板厚区分)を取得
                                Call ltMsg1.getString(CPstrTHICKNESS_CLASS, .strThicknessClass)               '板厚区分
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2取得
                                Call ltMsg1.getMsgAry(CPstrTHICKNESS_LIST, laAry2)
                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2のｶｳﾝﾄ格納
                                .strThicknessCount = laAry2.Count
                                .typThicknessList = New List(Of ThicknessList)
                            
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                If .strThicknessCount > 0 Then
                                    'ReDim Preserve .typThicknessList(.strThicknessCount) NSYS ループ処理内へ移動
                                    .typThicknessList = New List(Of ThicknessList)
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                    'llngCnt2 = 1 NSYS 不要となるため削除
                                    For Each ltMsg2 In laAry2

                                        'NSYS 編集用構造体初期化
                                        Dim typThicknessListTmp As ThicknessList = New ThicknessList

                                        '@受信結果取得
                                        Call ltMsg2.getString(CPstrTHICKNESS_CODE, typThicknessListTmp.strThicknessCode)

                                        'NSYS 編集済み構造体を追加
                                        .typThicknessList.Add(typThicknessListTmp)
                                        'llngCnt2 = llngCnt2 + 1 NSYS 不要となるため削除
                                    Next
                                End If
                            End With
                            
                            'NSYS 編集済み構造体を追加
                            mtypThicknessClassList.Add(mtypThicknessClassListTmp)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            'llngCnt1 = llngCnt1 + 1 NSYS 不要となるため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnThicknessClass_Sel = True
                                            
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_thicklistVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing

        End Try
    End Function

    '関数名：pubblnmasPdEntryList_Sel
    '機　能：ﾏｽﾀ工順一覧取得
    '引　数：lstrmas_pdentrylistVer ：MSGﾊﾞｰｼﾞｮﾝ
    '　　　：lstrPdID               ：機種ID
    '　　　：mtypOrderList()        ：種別ﾘｽﾄ
    '　　　：llngOrderListCnt       ：種別ｶｳﾝﾄ
    '　　　：lstrSBID               ：SBID
    '　　　：lstrClassDivision      ：処理区分　02：全て、07：最新のｴﾝﾄﾘ一件
    '戻り値：True：成功、False：失敗
    '作成日：2004/02/23 (Mon) 09:53:05 M.Miura
    '更新日：2009/02/23 (Mon) 14:14:23 N.Kojima
    '備　考：
    '　　　：2004/06/14にMG0020から共通ﾒｯｾｰｼﾞに移動
    '　　　：pubblnmasSeqList_Sel→pubblnmasPdEntryList_Selに変更しました
    '　　　：2007/12/25 (Tue) 15:55:09 N.Kojima     ﾁｯﾌﾟ電特対応。応答に"CDEN_FLAG"追加。(案件№02263)
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    Public Function pubblnmasPdEntryList_Sel(ByVal lstrmas_pdentrylistVer As String, _
                                             ByVal lstrPdID As String, _
                                             ByRef ltypEntryList As List(Of EntryList), _
                                             ByRef llngEntryListCnt As Integer, _
                                             ByVal lstrSBID As String, _
                                             Optional ByVal lstrClassDivision As String = CPstrCD02) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "マスタ工順一覧取得"
            pubblnmasPdEntryList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            ltypEntryList = New List(Of EntryList)
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@機種ID
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_pdentrylistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_pdentrylistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_pdentrylist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：ｴﾝﾄﾘﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrENTRY_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ｴﾝﾄﾘﾃﾞｰﾀ数
                    llngEntryListCnt = laAry.Count
                    
                    '@取得ｴﾝﾄﾘﾃﾞｰﾀ数が1件以上存在するか
                    If llngEntryListCnt > 0 Then
                        
                        '@格納領域の設定
                        'ReDim ltypEntryList(llngEntryListCnt) NSYS ループ処理内へ移動
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        'llngCnt = 1 NSYS 不要となるため削除
                        For Each ltMsg In laAry

                            'NSYS 編集用構造体初期化
                            Dim ltypEntryListTmp As EntryList = New EntryList

                            '@受信結果取得
                            With ltypEntryListTmp
                                Call ltMsg.getString(CPstrENTRY_ID, .strEntryID)                'ｴﾝﾄﾘID
                                Call ltMsg.getString(CPstrENTRY_NAME, .strEntryName)            'ｴﾝﾄﾘ名
                                Call ltMsg.getString(CPstrENTRY_COMMENTS, .strEntryComments)    'ｴﾝﾄﾘ時ｺﾒﾝﾄ
                                Call ltMsg.getString(CPstrAPPLY_TIME, .strEntryApplyTime)       '適用日時
                                Call ltMsg.getString(CPstrMAX_WF_COUNT, .strMaxWFCount)         '最大WF枚数
                            End With

                            'NSYS 編集済み構造体を追加
                            ltypEntryList.Add(ltypEntryListTmp)
                            'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnmasPdEntryList_Sel = True
                    
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrmas_pdentrylistVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnMasEmpName_Sel
    '機　能：作業者名取得
    '引　数：lstrmas_empnameVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrEmpID          ：作業者ID
    '　　　：lstrEmpName        ：作業者名
    '　　　：lstrDeptID         ：部署ID
    '　　　：lstrDeptName       ：部署名
    '　　　：lstrGroupID        ：ｸﾞﾙｰﾌﾟID
    '　　　：lstrFunctionID     ：機能ID
    '　　　：lstrActionID       ：ｱｸｼｮﾝID
    '　　　：lstrAuthrityFlag   ：権限ﾌﾗｸﾞ
    '　　　：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '戻り値：True：成功、False：失敗
    '作成日：2005/03/14 (Mon) 14:47:36 S.Deguchi
    '更新日：2008/04/22 (Tue) 20:55:45 N.Kojima
    '備　考：
    '　　　：2004/08/18 (Wed) 11:27:07 S.Deguchi    部署IDと名称を追加
    '　　　：2005/03/11 (Fri) 10:59:15 S.Deguchi    不具合№5925の対応で機能IDとｱｸｼｮﾝIDと権限ﾌﾗｸﾞを追加
    '　　　：2005/11/24 (Thu) 16:27:28 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で,応答に"ﾒｰﾙｱﾄﾞﾚｽ"を追加
    '　　　：2006/11/29 (Wed) 14:29:08 T.Kitagawa   ﾊﾟｽﾜｰﾄﾞﾁｪｯｸ機能対応(案件№01581)
    '　　　：2008/04/22 (Tue) 20:55:45 N.Kojima     応答に所属ｸﾞﾙｰﾌﾟID追加。(案件№02786)
    Public Function pubblnMasEmpName_Sel(ByVal lstrmas_empnameVer As String, _
                                         ByVal lstrEmpID As String, _
                                         ByRef lstrEmpName As String, _
                                         Optional ByRef lstrDeptID As String = CPstrMsgNull, _
                                         Optional ByRef lstrDeptName As String = CPstrMsgNull, _
                                         Optional ByRef lstrGroupID As String = CPstrMsgNull, _
                                         Optional ByRef lstrFunctionID As String = CPstrMsgNull, _
                                         Optional ByRef lstrActionID As String = CPstrMsgNull, _
                                         Optional ByRef lstrAuthrityFlag As String = CPstrMsgNull, _
                                         Optional ByRef lstrSBID As String = CPstrMsgNull, _
                                         Optional ByRef lstrMailAddress As String = CPstrMsgNull, _
                                         Optional ByRef lstrPasswd As String = CPstrMsgNull, _
                                         Optional ByRef lstrPasswdErrorFlag As String = CPstrMsgNull) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "作業者名取得"
            pubblnMasEmpName_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@作業者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_empnameVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_empnameVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@機能ID
            If lstrFunctionID <> vbNullString Then
                Call lrMsg.addString(CPstrFUNCTION_ID, lstrFunctionID)
            Else
                Call lrMsg.addString(CPstrFUNCTION_ID, CPstrMsgNull)
            End If
            
            '@ｱｸｼｮﾝID
            If lstrActionID <> vbNullString Then
                Call lrMsg.addString(CPstrACTION_ID, lstrActionID)
            Else
                Call lrMsg.addString(CPstrACTION_ID, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾊﾟｽﾜｰﾄﾞ
            If lstrPasswd <> vbNullString Then
                Call lrMsg.addString(CPstrPASSWD, lstrPasswd)
            Else
                Call lrMsg.addString(CPstrPASSWD, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_empname_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
            
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrEMP_NAME, lstrEmpName)                    '作業者名
                    Call laMsg.getString(CPstrDEPT_CODE, lstrDeptID)                    '部署ID
                    Call laMsg.getString(CPstrDEPT_NAME, lstrDeptName)                  '部署名
                    Call laMsg.getString(CPstrGROUP_ID, lstrGroupID)                    '所属ｸﾞﾙｰﾌﾟID
                    Call laMsg.getString(CPstrAUTHORITY_FLAG, lstrAuthrityFlag)         '権限ﾌﾗｸﾞ
                    Call laMsg.getString(CPstrMAIL_ADDRESS, lstrMailAddress)            'ﾒｰﾙｱﾄﾞﾚｽ
                    Call laMsg.getString(CPstrPASSWD_ERROR_FLAG, lstrPasswdErrorFlag)   'ﾊﾟｽﾜｰﾄﾞｴﾗｰﾌﾗｸﾞ
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasEmpName_Sel = True
                                        
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_empnameVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotCfkilotinfo_Sel
    '機　能：CFKIﾛｯﾄ情報取得
    '引　数：lstrlot_cfkilotinfoVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCarrierID          ：ｷｬﾘｱID
    '　　　：ltypLotCfkiLotinfo     ：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/06/25 (Fri) 16:13:30 T.Kitagawa
    '更新日：2004/10/22 (Fri) 18:02:24 N.Kojima
    '備　考：2004/09/03 (Fri) 14:26:12 T.Kitagawa   不良項目ｾｯﾄID　を追加
    '　　　：2004/09/28 (Tue) 19:40:15 T.Kitagawa   ﾒｯｾｰｼﾞ名ﾀｲﾄﾙ変更(不具合№978)
    '　　　：2004/10/22 (Fri) 18:02:24 N.Kojima　   応答に製造ﾛｯﾄID、出荷ﾛｯﾄID追加(不具合№43)
    Public Function pubblnLotCfkilotinfo_Sel(ByVal lstrlot_cfkilotinfoVer As String, _
                                             ByVal lstrCarrierID As String, _
                                             ByRef ltypLotCfkiLotInfo As LotCfkiLotinfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ＣＦロット情報取得"
            pubblnLotCfkilotinfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrlot_cfkilotinfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_cfkilotinfoVer)       'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                      'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)            'ｷｬﾘｱID
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cfkilotinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    With ltypLotCfkiLotInfo
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                            'ﾛｯﾄID
                        Call laMsg.getString(CPstrPD_ID, .strPdId)                              '機種ID
                        Call laMsg.getString(CPstrPART_CODE, .strPartCode)                      '部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
                        Call laMsg.getString(CPstrPART_NAME, .strPartName)                      '部品名
                        Call laMsg.getString(CPstrREWORK_COUNT, .strReworkCount)                'CFﾘﾜｰｸ数
                        Call laMsg.getString(CPstrVENDER_NAME, .strVenderName)                  'ﾍﾞﾝﾀﾞｰ名
                        Call laMsg.getString(CPstrCOMMENTS, .strComments)                       'LOTｺﾒﾝﾄ
                        Call laMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)              'ﾁｯﾌﾟ現在数
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           '最終更新日時
                        Call laMsg.getString(CPstrLOT_SCRAP_SET_ID, .strLotScrapSetID)          '不良項目ｾｯﾄID
                        
                        Call laMsg.getMsgAry(CPstrPALETTE_MAP_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngMetalPaletteMapListCnt = laAry.Count
                        .typMetalPaletteMapList = New List(Of MetalPaletteMapList)
                        If .lngMetalPaletteMapListCnt > 0 Then
                            'ReDim Preserve .typMetalPaletteMapList(.lngMetalPaletteMapListCnt) NSYS ループ処理内へ移動
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            'llngCnt = 1 NSYS 不要となるため削除
                            For Each ltMsg In laAry

                                'NSYS 編集前構造体初期化
                                Dim typMetalPaletteMapListTmp As MetalPaletteMapList = New MetalPaletteMapList

                                '@受信結果取得
                                With typMetalPaletteMapListTmp
                                    Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)          'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                                    Call ltMsg.getString(CPstrPALETTE_ID, .strPaletteID)                'ﾊﾟﾚｯﾄID
                                    Call ltMsg.getString(CPstrTHICKNESS_CODE, .strThicknessCode)        'CF板厚
                                    Call ltMsg.getString(CPstrCHIP_COUNT, .strChipCount)                'ﾁｯﾌﾟ数
                                    Call ltMsg.getString(CPstrPRODUCTION_LOT_ID, .strProductionLotId)   '製造ﾛｯﾄID
                                    Call ltMsg.getString(CPstrSHIPPING_LOT_ID, .strShippingLotID)       '出荷ﾛｯﾄID
                                End With

                                'NSYS 編集済み構造体を追加
                                .typMetalPaletteMapList.Add(typMetalPaletteMapListTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotCfkilotinfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_cfkilotinfoVer)
                    
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
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnMasChipCount_Sel
    '機　能：ﾊﾟﾚｯﾄﾁｯﾌﾟ合計数取得
    '引　数：lstrmas_chipcountVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分(2R:金属ﾊﾟﾚｯﾄ、2S:樹脂ﾊﾟﾚｯﾄ)
    '　　　：lstrPdID               ：機種ID
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrPaletteNum         ：ﾊﾟﾚｯﾄﾁｯﾌﾟ数合計
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/25 (Fri) 16:48:11 T.Kitagawa
    '更新日：2004/06/25 (Fri) 16:48:11
    '備　考：
    '　　　：2004/10/27 (Wed) 15:04:24 S.Deguchi    不具合改善№167 送信ﾒｯｾｰｼﾞにｼｽﾃﾑﾌﾞﾛｯｸを追加(検索ｷｰとして必要な為)
    Public Function pubblnMasChipCount_Sel(ByVal lstrmas_chipcountVer As String, _
                                           ByVal lstrClassDivision As String, _
                                           ByVal lstrPdID As String, _
                                           ByVal lstrSBID As String, _
                                           ByRef lstrPaletteNum As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "パレットチップ合計数取得"
            pubblnMasChipCount_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrmas_chipcountVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_chipcountVer)       'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)    '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)                      '機種ID
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                      'ｼｽﾃﾑﾌﾞﾛｯｸ
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_chipcount, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrPALETTE_NUM, lstrPaletteNum)      'ﾊﾟﾚｯﾄﾁｯﾌﾟ数合計
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasChipCount_Sel = True
                                        
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_chipcountVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotCfkiMove_Ins
    '機　能：CFKI作業終了入力
    '引　数：lstrlot_cfkimoveVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotCfkiMove        ：CFKI作業終了入力ﾃﾞｰﾀ構造体
    '　　　：ltypLotCfkiMoveAns     ：CFKI作業終了入力応答ﾃﾞｰﾀ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/25 (Fri) 17:36:09 T.Kitagawa
    '更新日：2004/06/25 (Fri) 17:36:09
    '備　考：
    Public Function pubblnLotCfkiMove_Ins(ByVal lstrlot_cfkimoveVer As String, _
                                          ByRef ltypLotCfkiMove As LotCfkiMove, _
                                          ByRef ltypLotCfkiMoveAns As LotCfkiMoveAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            pstrMessageName = "ＣＦＫＩ作業終了入力"
            pubblnLotCfkiMove_Ins = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypLotCfkiMove
                If lstrlot_cfkimoveVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_cfkimoveVer)                 'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)                              'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strCarrierID1 <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID1, .strCarrierID1)                  '移載元ｷｬﾘｱID
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID1, CPstrMsgNull)
                End If
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           '移載元ﾛｯﾄ最終更新日時
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                '@移載先ｷｬﾘｱ情報ｾｯﾄ
                llngCnt = 0
                Do While .lngCfkiCarrierListCnt > llngCnt
                    With .typCfkiCarrierList(llngCnt)
                        If .strCarrierID2 <> vbNullString Then
                            Call ltMsg.addString(CPstrCARRIER_ID2, .strCarrierID2)          '移載先ｷｬﾘｱID
                        Else
                            Call ltMsg.addString(CPstrCARRIER_ID2, CPstrMsgNull)
                        End If
                        If .strNum <> vbNullString Then
                            Call ltMsg.addString(CPstrNUM, .strNum)                         '搭載数
                        Else
                            Call ltMsg.addString(CPstrNUM, CPstrMsgNull)
                        End If
                        
                        If .strCfArea <> vbNullString Then
                            Call ltMsg.addString(CPstrCF_AREA, .strCfArea)                  'CF区分
                        Else
                            Call ltMsg.addString(CPstrCF_AREA, CPstrMsgNull)
                        End If
                        
                        If .strComments <> vbNullString Then
                            Call ltMsg.addString(CPstrCOMMENTS, .strComments)               'LOTｺﾒﾝﾄ
                        Else
                            Call ltMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                        End If
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                        llngCnt = llngCnt + 1
                    End With
                Loop
                Call lrMsg.addMsgAry(CPstrCFKI_CARRIER_LIST, lrAry)
                lrAry.Clear
                
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                            '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cfkimove, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    With ltypLotCfkiMoveAns
                        Call laMsg.getMsgAry(CPstrTP_LOT_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngTpLotListCnt = laAry.Count
                        .typTPLotList = New List(Of TpLotList)
                        If .lngTpLotListCnt > 0 Then
                            'ReDim Preserve .typTPLotList(.lngTpLotListCnt) NSYS ループ処理内へ移動
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            'llngCnt = 1 NSYS 不要となるため削除
                            For Each ltMsg In laAry

                                'NSYS 編集前構造体初期化
                                Dim typTPLotListTmp As TpLotList = New TpLotList

                                '@受信結果取得
                                With typTPLotListTmp
                                    Call ltMsg.getString(CPstrTP_LOT_ID, .strTpLotID)       'TPALﾛｯﾄID
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)    '移載先ｷｬﾘｱID
                                End With

                                'NSYS 編集済み構造体を追加
                                .typTPLotList.Add(typTPLotListTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotCfkiMove_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_cfkimoveVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
                                
        End Try
    End Function

    '関数名：pubblnLotCfkiRework_Upd
    '機　能：CFKIﾘﾜｰｸ変更
    '引　数：lstrlot_cfkireworkVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotCfkiRework      ：CFKIﾘﾜｰｸ変更ﾃﾞｰﾀ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/25 (Fri) 18:24:31 T.Kitagawa
    '更新日：2004/06/25 (Fri) 18:24:31
    '備　考：
    '　　　：2004/10/29 (Fri) 17:23:08 S.Deguchi    ﾊﾟﾚｯﾄﾘｽﾄを送信ﾒｯｾｰｼﾞに追加
    Public Function pubblnLotCfkiRework_Upd(ByVal lstrlot_cfkireworkVer As String, _
                                            ByRef ltypLotCfkiRework As LotCfkiRework) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            pstrMessageName = "ＣＦリワーク変更"
            pubblnLotCfkiRework_Upd = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypLotCfkiRework
                If lstrlot_cfkireworkVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_cfkireworkVer)      'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)                      'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@CF板厚ﾘｽﾄ情報ｾｯﾄ
                llngCnt = 0
                Do While .lngThicknessReworkListCnt > llngCnt
                    With .typThicknessReworkList(llngCnt)
                        If .strThicknessCode <> vbNullString Then
                            Call ltMsg.addString(CPstrTHICKNESS_CODE, .strThicknessCode)    'CF板厚
                        Else
                            Call ltMsg.addString(CPstrTHICKNESS_CODE, CPstrMsgNull)
                        End If
                        If .strChipNum <> vbNullString Then
                            Call ltMsg.addString(CPstrCHIP_NUM, .strChipNum)                'CFﾘﾜｰｸ数量
                        Else
                            Call ltMsg.addString(CPstrCHIP_NUM, CPstrMsgNull)
                        End If
                        llngCnt = llngCnt + 1
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    End With
                Loop
                Call lrMsg.addMsgAry(CPstrTHICKNESS_LIST, lrAry)
                lrAry.Clear
                
                '@ﾊﾟﾚｯﾄﾘｽﾄｾｯﾄ
                llngCnt = 0
                Do While .lngPaletteListCnt > llngCnt
                    With .typPaletteList(llngCnt)
                        If .strPaletteID <> vbNullString Then
                            Call ltMsg.addString(CPstrPALETTE_ID, .strPaletteID)            'ﾊﾟﾚｯﾄID
                        Else
                            Call ltMsg.addString(CPstrPALETTE_ID, CPstrMsgNull)
                        End If
                        llngCnt = llngCnt + 1
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    End With
                Loop
                Call lrMsg.addMsgAry(CPstrPALETTE_LIST, lrAry)
                lrAry.Clear
                
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                            '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cfkirework, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnLotCfkiRework_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_cfkireworkVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
                                
        End Try
    End Function

    '関数名：pubblnLotCfinsprst_Ins
    '機　能：CF不良登録
    '引　数：lstrlot_cfinsprstVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotCfinsprst       ：CFKIﾘﾜｰｸ不良登録ﾃﾞｰﾀ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/25 (Fri) 18:41:47 T.Kitagawa
    '更新日：2004/06/25 (Fri) 18:41:47
    '備　考：
    '　　　：2004/10/29 (Fri) 17:23:08 S.Deguchi    ﾊﾟﾚｯﾄﾘｽﾄを送信ﾒｯｾｰｼﾞに追加
    Public Function pubblnLotCfinsprst_Ins(ByVal lstrlot_cfinsprstVer As String, _
                                           ByRef ltypLotCfinsprst As LotCfinsprst) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            pstrMessageName = "ＣＦ不良登録"
            pubblnLotCfinsprst_Ins = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypLotCfinsprst
                If lstrlot_cfinsprstVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_cfinsprstVer)        'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)                      'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                    'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@CF不良ﾘｽﾄ情報ｾｯﾄ
                llngCnt = 0
                Do While .lngScrapListCnt > llngCnt
                    With .typScrapList(llngCnt)
                        If .strClass <> vbNullString Then
                            Call ltMsg.addString(CPstrCLASS, .strClass)             '区分
                        Else
                            Call ltMsg.addString(CPstrCLASS, CPstrMsgNull)
                        End If
                        If .strClassID <> vbNullString Then
                            Call ltMsg.addString(CPstrCLASS_ID, .strClassID)        '項目ID
                        Else
                            Call ltMsg.addString(CPstrCLASS_ID, CPstrMsgNull)
                        End If
                        If .strNum <> vbNullString Then
                            Call ltMsg.addString(CPstrNUM, .strNum)                 'ﾁｯﾌﾟ数
                        Else
                            Call ltMsg.addString(CPstrNUM, CPstrMsgNull)
                        End If
                        llngCnt = llngCnt + 1
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    End With
                Loop
                Call lrMsg.addMsgAry(CPstrSCRAP_LIST, lrAry)
                lrAry.Clear
                
                '@ﾊﾟﾚｯﾄﾘｽﾄｾｯﾄ
                llngCnt = 0
                Do While .lngPaletteListCnt > llngCnt
                    With .typPaletteList(llngCnt)
                        If .strPaletteID <> vbNullString Then
                            Call ltMsg.addString(CPstrPALETTE_ID, .strPaletteID)            'ﾊﾟﾚｯﾄID
                        Else
                            Call ltMsg.addString(CPstrPALETTE_ID, CPstrMsgNull)
                        End If
                        llngCnt = llngCnt + 1
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    End With
                Loop
                Call lrMsg.addMsgAry(CPstrPALETTE_LIST, lrAry)
                lrAry.Clear
                
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                            '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cfinsprst, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnLotCfinsprst_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_cfinsprstVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
                                
        End Try
    End Function

    '関数名：pubblnLotCfkinuminfo_Sel
    '機　能：CFKI数量取得
    '引　数：lstrlot_cfkinuminfoVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCarrierID          ：ｷｬﾘｱID
    '　　　：ltypLotCfkinuminfo     ：格納ﾃﾞｰﾀ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/25 (Fri) 18:53:28 T.Kitagawa
    '更新日：2008/06/16 (Mon) 17:19:14 N.Kojima
    '備　考：
    '　　　：2005/02/01 (Tue) 15:33:53 H.Wajima     作業指示ﾌﾗｸﾞ削除(ｺﾒﾝﾄ化)
    '　　　：2005/03/04 (Fri) 08:10:01 S.Deguchi    WP_TYPE追加
    '　　　：2008/06/16 (Mon) 17:19:14 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Public Function pubblnLotCfkinuminfo_Sel(ByVal lstrlot_cfkinuminfoVer As String, _
                                             ByVal lstrCarrierID As String, _
                                             ByRef ltypLotCfkinuminfo As LotCfkinuminfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@各種初期設定
            pstrMessageName = "ＣＦＫＩ数量取得"
            pubblnLotCfkinuminfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_cfkinuminfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_cfkinuminfoVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_cfkinuminfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信結果取得
                    With ltypLotCfkinuminfo
                        
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                            'ﾛｯﾄID
                        Call laMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                    '流動区分
                        Call laMsg.getString(CPstrOP_ID, .strOpID)                              '大工程
                        Call laMsg.getString(CPstrSTEP_ID, .strStepID)                          '小工程
                        Call laMsg.getString(CPstrNOW_ST, .strNowST)                            'LOT状態
                        Call laMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                 'ﾛｯﾄ担当者名
                        Call laMsg.getString(CPstrWORK_CONDITION, .strWorkCondition)            '作業条件
                        Call laMsg.getString(CPstrSPECIAL_FLG, .strSpecialFlg)                  '特殊特性
                        Call laMsg.getString(CPstrPALLET_NUM, .strPalletNum)                    'WF枚数
                        Call laMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                    '制限時間(時間制約)
                        Call laMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)               '保留ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrSTART_TIME, .strStartTime)                    '作業開始時刻
                        Call laMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)              'ﾁｯﾌﾟ現在数
                        Call laMsg.getString(CPstrCHIP_OUT_QUANTITY, .strChipOutQuantity)       'ﾁｯﾌﾟ不良数
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           'LOT最終更新日時
                        Call laMsg.getString(CPstrREGENERATION_COUNT, .strRegenerationCount)    '再生可能回数
                        Call laMsg.getString(CPstrWARN_TIME, .strWarnTime)                      '警告時間
                        Call laMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)         '制限ﾀｲﾌﾟ
                        Call laMsg.getString(CPstrWP_TYPE_FLAG, .strWPType)                     'WP_TYPE
                        
                        '@★ 特殊特性ﾌﾗｸﾞにより処理分岐 ★
                        Select Case .strSpecialFlg
                        
                            '@〓 0：非表示 〓
                            Case CPstrSpNull
                            
                                .strSpecialFlg = vbNullString
                                
                            '@〓 1、2、その他(その他はありえない) 〓
                            Case Else
                            
                                '@処理なし
                                
                        End Select
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotCfkinuminfo_Sel = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_cfkinuminfoVer)

                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnLotTpallotinfo_Sel
    '機　能：CFKIﾛｯﾄ情報取得
    '引　数：lstrlot_TpallotinfoVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCarrierID          ：ｷｬﾘｱID
    '　　　：ltypLotTpalLotInfo     ：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/07/14 (Wed) 12:08:18 H.Wajima
    '更新日：2004/07/14 (Wed) 12:08:18
    '備　考：
    Public Function pubblnLotTpalLotInfo_Sel(ByVal lstrlot_TpalLotInfoVer As String, _
                                            ByVal lstrCarrierID As String, _
                                            ByRef ltypLotTpalLotInfo As LotTpalLotInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ＴＰＡＬ編成ロット情報取得"
            pubblnLotTpalLotInfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrlot_TpalLotInfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_TpalLotInfoVer)      'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                      'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)            'ｷｬﾘｱID
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_tpallotinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    With ltypLotTpalLotInfo
                        Call laMsg.getMsgAry(CPstrTPAL_LOT_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngLotTpalLotListCnt = laAry.Count
                        .typLotTpalLotList = New List(Of LotTpalLotList)
                        If .lngLotTpalLotListCnt > 0 Then
                            'ReDim Preserve .typLotTpalLotList(.lngLotTpalLotListCnt) NSYS ループ処理内へ移動
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            'llngCnt = 1 NSYS 不要となるため削除
                            For Each ltMsg In laAry

                                'NSYS 編集前構造体初期化
                                Dim typLotTpalLotListTmp As LotTpalLotList = New LotTpalLotList

                                '@受信結果取得
                                With typLotTpalLotListTmp
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                    'ｷｬﾘｱID
                                    Call ltMsg.getString(CPstrTP_LOT_ID, .strTpLotID)                       'TPALﾛｯﾄID
                                    Call ltMsg.getString(CPstrNUM, .strNum)                                 '詰数
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)                       'ﾛｯﾄｺﾒﾝﾄ
                                    Call ltMsg.getString(CPstrREWORK_COUNT, .strReworkCount)                'ﾘﾜｰｸ回数
                                End With

                                'NSYS 編集済み構造体を追加
                                .typLotTpalLotList.Add(typLotTpalLotListTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotTpalLotInfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_TpalLotInfoVer)
                    
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
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
                                
        End Try
    End Function

    '関数名：pubblnInvWaferlist_Sel
    '機　能：在庫WF情報取得
    '引　数：lstrinv_waferlistVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCarrierID          ：ｷｬﾘｱID
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ(空白の場合は指定なし)
    '　　　：ltypInvWaferList       ：受信ﾒｯｾｰｼﾞ格納
    '戻り値：True：正常、False：異常
    '作成日：2004/03/05 (Fri) 14:57:54 M.Miura
    '更新日：2009/04/15 (Wed) 10:08:44 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 15:03:30 N.Kasai      ﾛｯﾄ最終更新日時追加
    '　　　：2004/10/13 (Wed) 15:09:55 S.Deguchi    不具合№775の対応でLot情報取得(Inv_.Lotlist_)と分離
    '　　　：2005/02/04 (Fri) 13:00:05 S.Deguchi    不具合№471対応(ﾒｯｾｰｼﾞ 元ﾛｯﾄID追加)
    '　　　：2005/09/05 (Mon) 12:15:00 N.Kojima     応答に"CPstrCHIP_QUANTITY","CPstrCHIP_OUT_QUANTITY","CPstrCHIP_MARK_QUANTITY"追加。(不具合№3047)
    '　　　：2009/04/15 (Wed) 10:08:44 N.Kojima     応答に"CHIP_FORWARD_QUANTITY"追加。(案件№3434)
    Public Function pubblnInvWaferlist_Sel(ByVal lstrinv_waferlistVer As String, _
                                           ByVal lstrCarrierID As String, _
                                           ByVal lstrSBID As String, _
                                           ByRef ltypInvWaferList As InvWaferList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "在庫WFリスト取得"

            pubblnInvWaferlist_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_waferlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_waferlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@SB_ID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_waferlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypInvWaferList
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                        Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
            
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        .lngInvWaferListCnt = laAry.Count
                        .typInvWaferList = New List(Of InvWafer)
            
                        '@配列があればﾃﾞｰﾀ格納
                        If .lngInvWaferListCnt > 0 Then
                            '@構造体初期化
                            'llngCnt = 1 NSYS 不要となるため削除
                            'ReDim Preserve .typInvWaferList(.lngInvWaferListCnt) NSYS ループ処理内へ移動
                            For Each ltMsg In laAry

                                'NSYS 編集前構造体初期化
                                Dim typInvWaferListTmp As InvWafer = New InvWafer

                                With typInvWaferListTmp
                                    Call ltMsg.getString(CPstrWF_ID, .strWfId)                                 'ｳｪﾊID
                                    Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)                 'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                                    Call ltMsg.getString(CPstrWF_STATUS, .strWFStatus)                         'ｳｪﾊｽﾃｰﾀｽ
                                    Call ltMsg.getString(CPstrWF_STATUS_ID, .strWFStatusID)                    'ｳｪﾊｽﾃｰﾀｽID
                                    Call ltMsg.getString(CPstrLOT_ID, .strBFLotID)                             '元ﾛｯﾄID
                                    Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                 '良品ﾁｯﾌﾟ数
                                    Call ltMsg.getString(CPstrCHIP_OUT_QUANTITY, .strChipOutQuantity)          '不良ﾁｯﾌﾟ数
                                    Call ltMsg.getString(CPstrCHIP_FORWARD_QUANTITY, .strChipForwardQuantity)  '払出ﾁｯﾌﾟ数
                                    Call ltMsg.getString(CPstrCHIP_MARK_QUANTITY, .strChipMarkQuantity)        '傾向ﾁｯﾌﾟ数
                                    '@↓2019/09/30 (Mon) 18:20:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    Call ltMsg.getString(CPstrGRB_CLASS, .strGRBClass)                         'GRBﾗﾝｸ
                                    '@↑2019/09/30 (Mon) 18:20:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                End With
                                
                                'NSYS 編集済み構造体を追加
                                .typInvWaferList.Add(typInvWaferListTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnInvWaferlist_Sel = True
                          
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrinv_waferlistVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@初期化
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@初期化
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnInvLotList_Sel
    '機　能：在庫ﾛｯﾄﾘｽﾄ取得
    '引　数：ltypinvlotlistreq：要求構造体
    '　　　：ltypinvlotlistnas：応答構造体
    '戻り値：True：正常、False：異常
    '作成日：2005/02/04 (Fri) 11:28:39 S.Deguchi
    '更新日：2006/11/01 (Wed) 11:25:07 N.Kasai
    '備　考：
    '　　　：2005/02/04 (Fri) 10:59:38 S.Deguchi    不具合改善№471対応でﾒｯｾｰｼﾞ変更
    '　　　：2006/11/01 (Wed) 11:25:07 N.Kasai      応答ﾀｸﾞ追加(CARRIER_EMP_NAME,CARRIER_COMMENTS) №01500
    Public Function pubblnInvLotList_Sel(ByRef ltypInvLotListReq As InvLotListReq, _
                                         ByRef ltypinvlotlistAns As InvLotListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry1              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim lstrRET             As String           '応答取得
        
        Try

            '@初期設定
            pstrMessageName = "在庫ロットリスト取得"

            pubblnInvLotList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypInvLotListReq
                '@SBID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
                '@元ﾛｯﾄ
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_lotlist_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypinvlotlistAns
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                        Call laMsg.getMsgAry(CPstrCARRIER_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        .lngLotListAnsCnt = laAry.Count
                        .typLotListAns = New List(Of InvLotlistLotList)
                        
                        '@配列があればﾃﾞｰﾀ格納
                        If .lngLotListAnsCnt > 0 Then
                            '@構造体初期化
                            'llngCnt = 1 NSYS 不要となるため削除
                            'ReDim Preserve .typLotListAns(.lngLotListAnsCnt) NSYS ループ処理内へ移動
                            For Each ltMsg In laAry

                                'NSYS 編集前構造体初期化
                                Dim typLotListAnsTmp As InvLotlistLotList = New InvLotlistLotList

                                With typLotListAnsTmp
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                         'ｷｬﾘｱID
                                    Call ltMsg.getString(CPstrCURRENT_POSITION_ID, .strCurrentPosition)          'ｷｬﾘｱ位置
                                    Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)    'ｷｬﾘｱ位置(日本語名)
                                    Call ltMsg.getString(CPstrSLOT_SIZE, .strSlotSize)                           'ｽﾛｯﾄ数
                                    Call ltMsg.getString(CPstrWF_QUANTITY, .strWFQuantity)                       'WF枚数
                                    Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                   'ﾁｯﾌﾟ数
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)                         '受入日,保留開始日
                                    Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)                           '最終更新日時
                                    Call ltMsg.getString(CPstrCARRIER_EMP_NAME, .strCarrierEmpName)              '責任者
                                    Call ltMsg.getString(CPstrCARRIER_COMMENTS, .strCarrierComments)             'ｺﾒﾝﾄ
                                
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                                    Call ltMsg.getMsgAry(CPstrLOT_LIST, laAry1)
                                
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1数格納
                                    .lngBFLotListCnt = laAry1.Count
                                    .typBFLotList = New List(Of BFLotList)

                                    If .lngBFLotListCnt > 0 Then
                                        '@構造体初期化
                                        'llngCnt1 = 1 NSYS 不要となるため削除
                                        'ReDim Preserve .typLotListAns(llngCnt).typBFLotList(laAry1.Count) NSYS ループ処理内へ移動
                                        For Each ltMsg1 In laAry1

                                            'NSYS 編集前構造体初期化
                                            Dim typBFLotListTmp As BFLotList = New BFLotList

                                            '@ﾛｯﾄID格納
                                            Call ltMsg1.getString(CPstrLOT_ID,typBFLotListTmp.strLotID)

                                            'NSYS 編集済み構造体を追加
                                            .typBFLotList.Add(typBFLotListTmp)
                                            'llngCnt1 = llngCnt1 + 1 NSYS 不要となるため削除
                                        Next
                                    End If

                                End With
                                
                                'NSYS 編集済み構造体を追加
                                .typLotListAns.Add(typLotListAnsTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnInvLotList_Sel = True
                          
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypInvLotListReq.strMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@初期化
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@初期化
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnCarrierID_Ins
    '機　能：ｷｬﾘｱ新規追加ﾒｯｾｰｼﾞ送信
    '　　　：lstrcarradditionVer ：Msgﾊﾞｰｼﾞｮﾝ
    '引　数：ltypCarrierAdd      ：送信するCarrierAdd型構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/02/16 (Mon) 10:08:10 Y.Tomiya
    '更新日：2004/06/01 (Tue) 11:26:20 N.Kasai
    '備　考：
    Public Function pubblnCarrierID_Ins(ByVal lstrcarradditionVer As String, _
                                        ByRef ltypCarrierAdd As CarrierAdd) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            pstrMessageName = "キャリア新規追加"
            pubblnCarrierID_Ins = False

            With ltypCarrierAdd
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                '@ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrRESTRICTED_SB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrRESTRICTED_SB_ID, CPstrMsgNull)
                End If
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                '@ｷｬﾘｱﾀｲﾌﾟ
                If .strCarrierTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_TYPE_ID, .strCarrierTypeID)
                Else
                    Call lrMsg.addString(CPstrCARRIER_TYPE_ID, CPstrMsgNull)
                End If
                '@ﾍﾞﾝﾀﾞｰID
                If .strVenderId <> vbNullString Then
                    Call lrMsg.addString(CPstrVENDER_ID, .strVenderId)
                Else
                    Call lrMsg.addString(CPstrVENDER_ID, CPstrMsgNull)
                End If
                '@利用開始日
                If .strStartTime <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_TIME, .strStartTime)
                Else
                    Call lrMsg.addString(CPstrSTART_TIME, CPstrMsgNull)
                End If
                '@製造年月日
                If .strProductionDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCTION_DATE, .strProductionDate)
                Else
                    Call lrMsg.addString(CPstrPRODUCTION_DATE, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrcarradditionVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrcarradditionVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarradd_____, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnCarrierID_Ins = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrcarradditionVer)
                    
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnCarrierID_Del
    '機　能：ｷｬﾘｱ削除送信
    '　　　：lstrcarrdelete__Ver：Msgﾊﾞｰｼﾞｮﾝ
    '引　数：lstrDelCarrierID   ：ｷｬﾘｱID
    '戻り値：True：成功、False：失敗
    '作成日：2004/02/16 (Mon) 11:03:07 Y.Tomiya
    '更新日：2004/06/01 (Tue) 11:27:03 N.Kasai
    '備　考：
    Public Function pubblnCarrierID_Del(ByVal lstrcarrdelete__Ver As String, _
                                        ByVal lstrDelCarrierID As String, _
                                        ByVal lstrUserID As String) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET            As String            '応答取得

        Try
            
            pstrMessageName = "キャリア削除"
            pubblnCarrierID_Del = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｷｬﾘｱID
            If lstrDelCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrDelCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            '@作業者ID
            If lstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrcarrdelete__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrcarrdelete__Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrdelete__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnCarrierID_Del = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrcarrdelete__Ver)
                    
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnMasPlaceList_Sel
    '機　能：保管場所ﾏｽﾀ取得を返す
    '引　数：lstrmas_placelistVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypPlaceList()        ：保管場所構造体
    '　　　：llngPlaceCnt           ：ｶｳﾝﾄ
    '戻り値：True：正常、False：異常
    '作成日：2004/06/29 (Tue) 16:03:16 N.Kojima
    '更新日：2004/08/27 (Fri) 09:23:27 Y.Yamagishi
    '備　考：2004/08/27 (Fri) 09:23:27 Y.Yamagishi  ﾀｸﾞ「CARRIER_ID」「SB_ID」追加
    Public Function pubblnMasPlaceList_Sel(ByVal lstrmas_placelistVer As String, _
                                           ByRef ltypPlaceList As List(Of PlaceList), _
                                           ByRef llngPlaceCnt As Integer, _
                                           Optional ByVal lstrCarrierID As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'カウント
            
        Try

            pstrMessageName = "保管場所マスタ取得"
            pubblnMasPlaceList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_placelistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_placelistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_placelist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrPLACE_LIST, lrAry)
                    
                    '@リスト数を格納
                    llngPlaceCnt = lrAry.Count
                    ltypPlaceList = New List(Of PlaceList)
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If lrAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In lrAry
                            '@受信結果取得
                            Dim typPlaceListTmp As PlaceList = New PlaceList
                            With typPlaceListTmp
                                Call ltMsg.getString(CPstrPLACE_ID, .strPlaceID)                        'ｽﾄｯｶｰ№
                                Call ltMsg.getString(CPstrPLACE_NAME, .strPlaceName)                    'ｽﾄｯｶｰ名
                            End With
                            ltypPlaceList.Add(typPlaceListTmp)
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasPlaceList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_placelistVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnCarrChgStocker_Upd
    '機　能：ｷｬﾘｱ位置変更ﾒｯｾｰｼﾞ送信
    '引　数：lstrcarrchgstockerVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCarrier          ：ｷｬﾘｱID
    '　　　：lstrChangePosition   ：変更後位置
    '　　　：lstrEmpID            ：作業者ID
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/29 (Tue) 16:32:15 N.Kojima
    '更新日：2004/06/29 (Tue) 16:32:15
    '備　考：
    Public Function pubblnCarrChgStocker_Upd(ByVal lstrcarrchgstockerVer As String, _
                                             ByVal lstrCarrierID As String, _
                                             ByVal lstrChangePositionID As String, _
                                             ByVal lstrEmpID As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            pstrMessageName = "キャリア位置変更"
            pubblnCarrChgStocker_Upd = False

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            '@変更後位置
            If lstrChangePositionID <> vbNullString Then
                Call lrMsg.addString(CPstrCHANGE_POSITION_ID, lstrChangePositionID)
            Else
                Call lrMsg.addString(CPstrCHANGE_POSITION_ID, CPstrMsgNull)
            End If
            '@作業者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrcarrchgstockerVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrcarrchgstockerVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrchgstocker, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnCarrChgStocker_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrcarrchgstockerVer)
                    
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
                    
            lrMsg = Nothing
            laMsg = Nothing
                    
        End Try
    End Function

    '関数名：pubblnInvCompLotList_Sel
    '機　能：種別別在庫ﾛｯﾄ一覧取得
    '引　数：lstrinv_completelotVer :Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypClassCompList      :種別別在庫ﾛｯﾄ取得要求構造体
    '　　　：ltypstocklotlist       :種別別在庫ﾛｯﾄ取得構造体
    '　　　：llngStockListCnt       :種別別在庫ﾛｯﾄ取得数
    '戻り値：True：成功、False：失敗
    '作成日：2004/05/07 (Fri) 17:07:06 S.Deguchi
    '更新日：2016/02/11 (Thu) 22:46:16 H.Hayashi
    '備　考：処理区分によって分岐あり注意！
    '　　　：2004/08/31 (Tue) 11:55:52 N.Kojima　   処理区分:1N、在庫ﾌﾗｸﾞ:09、保留ﾌﾗｸﾞ:Nullで要求
    '　　　：2004/09/07 (Tue) 13:59:23 N.Kojima　   処理区分:OL、在庫ﾌﾗｸﾞ:09、Lot_ID:TFT基板ﾛｯﾄID、保留ﾌﾗｸﾞ:Nullで要求
    '　　　：2004/09/15 (Wed) 13:26:56 N.Kasai　    pubblnInvCompLotList2_Selと統合
    '　　　：2004/10/14 (Thu) 13:10:59 N.Kasai      応答ﾀｸﾞにｽﾛｯﾄｻｲｽﾞ追加
    '　　　：2004/11/02 (Tue) 15:11:44 N.Kasai      ﾀｸﾞ追加(WF_CARRY_FLAG)
    '　　　：2004/11/26 (Fri) 17:47:07 H.Wajima     送品済み在庫ﾛｯﾄ取得対応(MsgVer.01.05)
    '　　　：2005/03/23 (Wed) 14:12:26 S.Deguchi    送品取消機能追加によりTag追加
    '　　　：2005/05/10 (Tue) 11:13:00 S.Deguchi    不具合№770の対応でﾘﾜｰｸ回数/最大ﾘﾜｰｸ回数をTagに追加
    '　　　：2005/08/01 (Mon) 12:08:40 N.Kasai      応答ﾒｯｾｰｼﾞにLC_DIRECTION追加
    '　　　：2006/09/11 (Mon) 10:37:29 N.Kojima     応答に"SEND_SB_ID","SEND_SB_NAME"追加。(案件№01452)
    '　　　：2006/11/01 (Wed) 15:16:43 N.Kasai      応答にLOT_SEND_FLAG追加(№01500)
    '　　　：2007/03/05 (Mon) 18:37:41 N.Kojima     応答のSEND_SB_LISTを削除。(案件№01549)
    '　　　：2008/06/16 (Mon) 17:31:59 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/12/03 (Thu) 13:40:19 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnInvCompLotList_Sel(ByVal lstrinv_completelotVer As String, _
                                             ByRef ltypClassCompList As ClassCompleteList, _
                                             ByRef ltypstocklotlist As List(Of StockLotList), _
                                             ByRef llngStockListCnt As Integer) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim lrAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim ltMsg3             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lstrRET            As String            '応答取得
        Dim llngCnt1           As Integer           'ｱﾚｲｶｳﾝﾄ用

        Try

            '@各種初期設定
            pstrMessageName = "完成在庫リスト"
            pubblnInvCompLotList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            lrAry1 = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg3 = New TfMsg
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypClassCompList
            
                '@処理区分
                Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivison)
                
                '@★ 処理区分により処理分岐 ★
                Select Case .strClassDivison
                    
                    '@〓 02：全て 〓
                    Case CPstrCD02

                        Call lrMsg.addString(CPstrPD_LIST, CPstrMsgNull)            '機種区分
                        Call lrMsg.addString(CPstrFLOW_CLASS_LIST, CPstrMsgNull)    '流動区分(種別ID)
                    
                    '@〓 0H：流動区分別 〓
                    Case CPstrCD0H

                        Call lrMsg.addString(CPstrPD_LIST, CPstrMsgNull)            '機種区分
                        For llngCnt1 = 0 To .lngFlowClassCnt -1
                            Call ltMsg.addString(CPstrFLOW_CLASS, .typFlowClassList(llngCnt1).strFlowClass)
                            Call lrAry.Add(ltMsg)
                        Next
                        Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry)           '流動区分(種別ID)
                        Call lrMsg.addString(CPstrPD_LIST, CPstrMsgNull)            '機種区分
                    
                    '@〓 04：機種別 〓
                    Case CPstrCD04

                        For llngCnt1 = 0 To .lngPdCnt -1
                            Call ltMsg.addString(CPstrPD_ID, .typPdList(llngCnt1).strPdId)
                            Call lrAry.Add(ltMsg)
                        Next
                        Call lrMsg.addMsgAry(CPstrPD_LIST, lrAry)                   '機種区分
                        Call lrMsg.addString(CPstrFLOW_CLASS_LIST, CPstrMsgNull)    '流動区分(種別ID)
                    
                    '@〓 その他：完成在庫の場合(機種、流動区分共に選択) 〓
                    Case Else

                        For llngCnt1 = 0 To .lngPdCnt -1
                            Call ltMsg.addString(CPstrPD_ID, .typPdList(llngCnt1).strPdId)
                            Call lrAry.Add(ltMsg)
                        Next
                        Call lrMsg.addMsgAry(CPstrPD_LIST, lrAry)                   '機種区分
                        
                        '@ｶｳﾝﾀの初期化
                        llngCnt1 = 0
                        
                        For llngCnt1 = 0 To .lngFlowClassCnt -1
                            Call ltMsg3.addString(CPstrFLOW_CLASS, .typFlowClassList(llngCnt1).strFlowClass)
                            Call lrAry1.Add(ltMsg3)
                        Next
                        Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry1)           '流動区分(種別ID)
                        
                        '@処理区分が"0L：TPAL"か(TPAL専用ﾛｼﾞｯｸ)
                        If .strClassDivison = CPstrCD0L Then
                            '@ﾛｯﾄID
                            If .strLotID <> vbNullString Then
                                Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                            Else
                                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                            End If
                        End If
                        
                        '@開始日付
                        If .strRefStartDate <> vbNullString Then
                            Call lrMsg.addString(CPstrREF_START_DATE, .strRefStartDate)
                        Else
                            Call lrMsg.addString(CPstrREF_START_DATE, CPstrMsgNull)
                        End If
                        
                        '@終了日付
                        If .strRefEndDate <> vbNullString Then
                            Call lrMsg.addString(CPstrREF_END_DATE, .strRefEndDate)
                        Else
                            Call lrMsg.addString(CPstrREF_END_DATE, CPstrMsgNull)
                        End If

                End Select
            
                '@在庫ﾌﾗｸﾞ
                If .strInventoryFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrINVENTORY_FLAG, .strInventoryFlag)
                Else
                    Call lrMsg.addString(CPstrINVENTORY_FLAG, CPstrMsgNull)
                End If
                
                '@保留区分ﾌﾗｸﾞ
                If .strHoldFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_FLAG, .strHoldFlag)
                Else
                    Call lrMsg.addString(CPstrHOLD_FLAG, CPstrMsgNull)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
            End With
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_completelotVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_completelotVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_complotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry1)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    llngStockListCnt = laAry1.Count
                    
                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngStockListCnt > 0 Then
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg1 In laAry1
                            Dim typStockLotListTmp As StockLotList = New StockLotList
                            With typStockLotListTmp

                                Call ltMsg1.getString(CPstrDATE, .strDate)                              '受入日
                                Call ltMsg1.getString(CPstrSEND_DATE, .strSendDate)                     '送品日
                                Call ltMsg1.getString(CPstrCARRIER_ID, .strCarrierId)                   'ｷｬﾘｱID
                                Call ltMsg1.getString(CPstrLOT_ID, .strLotID)                           'ﾛｯﾄID
                                Call ltMsg1.getString(CPstrFLOW_CLASS, .strFlowClass)                   '流動区分
                                Call ltMsg1.getString(CPstrGRB_CLASS, .strGrbClass)                     'GRB区分
                                Call ltMsg1.getString(CPstrPD_ID, .strPdId)                             '機種名
                                Call ltMsg1.getString(CPstrWF_QUANTITY, .strWFQuantity)                 'WF枚数
                                Call ltMsg1.getString(CPstrCHIP_QUANTITY, .strChipQuantity)             'ﾁｯﾌﾟ枚数
                                Call ltMsg1.getString(CPstrSTAY_TIME, .strStayTime)                     '停滞時間
                                Call ltMsg1.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)              'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrRECORD_TIME, .strRecordTime)                 '保留開始日時
                                Call ltMsg1.getString(CPstrEMP_ID, .strEmpID)                           '作業者ID
                                Call ltMsg1.getString(CPstrEMP_NAME, .strEmpName)                       '作業者名
                                Call ltMsg1.getString(CPstrREASON_CODE, .strReasonCodeID)               '保留理由ID
                                Call ltMsg1.getString(CPstrREASON_NAME, .strReasonName)                 '保留理由
                                Call ltMsg1.getString(CPstrCOMMENTS, .strLotComments)                   'ﾛｯﾄｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrENTRY_TIME, .strEntryTime)                   '最終更新日
                                Call ltMsg1.getString(CPstrLOT_PRIORITY, .strLotPriority)               '優先度
                                Call ltMsg1.getString(CPstrOP_ID, .strOpID)                             '大工程
                                Call ltMsg1.getString(CPstrSTEP_ID, .strStepID)                         '小工程
                                Call ltMsg1.getString(CPstrWP_ID, .strWpID)                             'WPID
                                Call ltMsg1.getString(CPstrHOLD_STAY_DATE, .strHoldStayDate)            '保留期間
                                Call ltMsg1.getString(CPstrHOLD_EMP_ID, .strHoldEmpID)                  '保留責任者ID
                                Call ltMsg1.getString(CPstrHOLD_EMP_NAME, .strHoldEmpName)              '保留責任者
                                Call ltMsg1.getString(CPstrENTRY_ID, .strEntryID)                       'ｴﾝﾄﾘID
                                Call ltMsg1.getString(CPstrCURRENT_STATUS, .strCurrentStatus)           'Lot状態
                                Call ltMsg1.getString(CPstrENG_EMP_ID, .strEngEmpId)                    'ﾛｯﾄ担当者ID
                                Call ltMsg1.getString(CPstrENG_EMP_NAME, .strEngEmpName)                'ﾛｯﾄ担当者名
                                Call ltMsg1.getString(CPstrHOLD_TERM_DATE, .strHoldTermDate)            '保留期限
                                Call ltMsg1.getString(CPstrLIMIT_TIME, .strLimitTime)                   '有効期限
                                Call ltMsg1.getString(CPstrTHICKNESS_CODE, .strThicknessCode)           '板厚
                                Call ltMsg1.getString(CPstrINV_COMMENTS, .strInvComments)               '送品時ｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrINV_HOLD_COMMENTS, .strInvHoldComments)      '保留ｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrSEND_ABLE_FLAG, .strSendAbleFlag)            '送品可能ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrSLOT_SIZE, .strSlotSize)                     'ｽﾛｯﾄｻｲｽﾞ
                                Call ltMsg1.getString(CPstrWF_CARRY_FLAG, .strWfCarryFlag)              'WF移載ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrWAIT_RECEIVE_FLAG, .strWaitReceiveFlag)      '送品受入待ちﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrATLAS_ORDER_NO, .strAtlasOrderNo)            'ATLASｵｰﾀﾞｰ№
                                Call ltMsg1.getString(CPstrBOX_NO, .strBoxNo)                           '箱№
                                Call ltMsg1.getString(CPstrTITAN_ACCEPT_DATE, .strTitanAcceptDate)      'TITAN受入日
                                Call ltMsg1.getString(CPstrTITAN_LOT_ID, .strTitanLotID)                'TITANﾛｯﾄID
                                Call ltMsg1.getString(CPstrCARRIER_TYPE_ID, .strCarrierType)            'ｷｬﾘｱﾀｲﾌﾟ
                                Call ltMsg1.getString(CPstrWAIT_TRANS_FLAG, .strWaitTransFlag)          '送品ﾌｧｲﾙ転送待ちﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrREWORK_COUNT, .strReworkCount)               'ﾘﾜｰｸ回数
                                Call ltMsg1.getString(CPstrMAX_REWORK_COUNT, .strMaxReworkCount)        '最大ﾘﾜｰｸ回数
                                Call ltMsg1.getString(CPstrLC_DIRECTION, .strLcDirection)               '液晶方向(L/RNull)
                                Call ltMsg1.getString(CPstrSEND_SB_ID, .strSendSBID)                    '送品先ID
                                Call ltMsg1.getString(CPstrSEND_SB_NAME, .strSendSBName)                '送品先名(和名)
                                Call ltMsg1.getString(CPstrSB_SYSTEM_FLAG, .strSBSystemFlag)            'ｼｽﾃﾑﾌﾞﾛｯｸﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrFOREIGN_COUNTRY_FLAG, .strForeignCountryFlag)    '海外ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrLOT_SEND_FLAG, .strLotSendFlag)              '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)
                                Call ltMsg1.getString(CPstrVA_FLAG, .strVaFlag)                         '無機ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrCF_AREA, .strCfArea)                         'CF区分
                                Call ltMsg1.getString(CPstrSB_AREA, .strSbArea)                         'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
                            End With

                            ltypstocklotlist.Add(typStockLotListTmp)

                        Next
                    End If
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnInvCompLotList_Sel = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrinv_completelotVer)

                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            lrAry1 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing
            ltMsg3 = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            lrAry1 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing
            ltMsg3 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnCarrClean_Upd
    '機　能：ｷｬﾘｱ洗浄ﾒｯｾｰｼﾞ送信
    '引　数：lstrcarrclean___Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCarrier        ：ｷｬﾘｱID
    '　　　：lstrEmpID          ：作業者ID
    '戻り値：True：成功、False：失敗
    '作成日：2004/06/29 (Tue) 16:32:15 N.Kojima
    '更新日：2004/06/29 (Tue) 16:32:15
    '備　考：
    Public Function pubblnCarrClean_Upd(ByVal lstrcarrclean___Ver As String, _
                                        ByVal lstrCarrierID As String, _
                                        ByVal lstrEmpID As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            pstrMessageName = "キャリア洗浄"
            pubblnCarrClean_Upd = False

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            '@作業者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrcarrclean___Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrcarrclean___Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrclean___, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnCarrClean_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrcarrclean___Ver)
                    
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
                    
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
                    
            lrMsg = Nothing
            laMsg = Nothing
                    
        End Try
    End Function

    '関数名：pubblnInvChangState_Upd
    '機　能：在庫状態変更(部材の状態を変更する)
    '引　数：lstrinv_changstateVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypChangeStateList    ：格納ﾃﾞｰﾀ
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：正常、False：異常
    '作成日：2004/07/07 (Wed) 12:01:50 N.Kasai
    '更新日：2005/03/31 (Thu) 13:57:29 N.Kojima
    '備　考：2004/07/07 (Wed) 12:01:50 N.Kasai      部材管理、在庫管理にて使用する。処理区分によって判定あり注意
    '　　　：2004/10/20 (Wed) 12:13:12 K.Takano     空Ary対応
    '　　　：2005/03/31 (Thu) 13:57:29 N.Kojima     応答に"GUID_MSG_CODE"、"GUID_MSG"を追加(ｶﾞｲﾀﾞﾝｽ対応)
    '　　　：2005/04/18 (Mon) 10:29:07 S.Deguchi    送信ﾒｯｾｰｼﾞに登録日時を追加
    '　　　：2005/11/21 (Mon) 17:12:43 S.Deguchi    応答に"HOLD_TIME"追加
    Public Function pubblnInvChangState_Upd(ByVal lstrinv_changstateVer As String, _
                                            ByRef ltypChangeStateList As ChangeStateList, _
                                            ByRef lstrGuidMsg As String, _
                                            ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          '汎用ｶｳﾝﾀ
        
        Try

            '@初期設定
            pstrMessageName = "在庫状態変更"
            pubblnInvChangState_Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypChangeStateList
                '@処理区分(33：部材払出処理 34：組立在庫払出処理 なし：保留、保留解除設定)
                If .strClassDivison <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivison)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@部品ID(ﾍﾞﾝﾀﾞ取扱分類ID)
                If .strVenderClassId <> vbNullString Then
                    Call lrMsg.addString(CPstrVENDER_CLASS_ID, .strVenderClassId)
                Else
                    Call lrMsg.addString(CPstrVENDER_CLASS_ID, CPstrMsgNull)
                End If
                '@在庫ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@ﾛｯﾄｲﾍﾞﾝﾄID
                If .strLotEventId <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_EVENT_ID, .strLotEventId)
                Else
                    Call lrMsg.addString(CPstrLOT_EVENT_ID, CPstrMsgNull)
                End If
                '@変更ｺｰﾄﾞ(保留ｺｰﾄﾞ、解除ｺｰﾄﾞ、受入ｺｰﾄﾞ、払出ｺｰﾄﾞ)
                If .strReasonCode <> vbNullString Then
                    Call lrMsg.addString(CPstrREASON_CODE, .strReasonCode)
                Else
                    Call lrMsg.addString(CPstrREASON_CODE, CPstrMsgNull)
                End If
                '@数量
                If .strNum <> vbNullString Then
                    Call lrMsg.addString(CPstrNUM, .strNum)
                Else
                    Call lrMsg.addString(CPstrNUM, CPstrMsgNull)
                End If
                '@ｺﾒﾝﾄ(作業ﾒﾓ)
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                '@作業者ID(受入担当者)
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@LOT最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                '@保留期限
                If .strHoldTermDate <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_TERM_DATE, .strHoldTermDate)
                Else
                    Call lrMsg.addString(CPstrHOLD_TERM_DATE, CPstrMsgNull)
                End If
                '@保留担当者
                If .strHoldEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_EMP_ID, .strHoldEmpID)
                Else
                    Call lrMsg.addString(CPstrHOLD_EMP_ID, CPstrMsgNull)
                End If
                '@登録日時
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
                
                '@処理区分34：組立在庫払出処理のみﾃﾞｰﾀ作成
                If .strClassDivison = CPstrCD34 Then
                    '@WFﾘｽﾄ情報ｾｯﾄ
                    llngCnt = 0
                    Do While .lngWfListCnt -1 >= llngCnt
                        With .typWfList(llngCnt)
                            If .strSlotPosition <> vbNullString Then
                                Call ltMsg.addString(CPstrSLOT_POSITION, .strSlotPosition)
                            Else
                                Call ltMsg.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                            End If
                            If .strWfId <> vbNullString Then
                                Call ltMsg.addString(CPstrWF_ID, .strWfId)
                            Else
                                Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                            End If
                            If .strClass <> vbNullString Then
                                Call ltMsg.addString(CPstrCLASS, .strClass)
                            Else
                                Call ltMsg.addString(CPstrCLASS, CPstrMsgNull)
                            End If
                            If .strClassID <> vbNullString Then
                                Call ltMsg.addString(CPstrCLASS_ID, .strClassID)
                            Else
                                Call ltMsg.addString(CPstrCLASS_ID, CPstrMsgNull)
                            End If
                            llngCnt = llngCnt + 1
                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear
                        End With
                    Loop
                End If
            
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
                lrAry.Clear
            End With
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_changstateVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_changstateVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_chgstate, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                                 'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                        'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    Call laMsg.getString(CPstrHOLD_TIME, ltypChangeStateList.strHoldDate)       '保留日時
                    
                    '@関数の処理結果(成功)格納
                    pubblnInvChangState_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrinv_changstateVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing

        End Try
    End Function

    '関数名：pubblnLotHoldinfo_Sel
    '機　能：ロット保留情報取得
    '引　数：lstrlot_holdinfoVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：ltypLotHoldInfoList：取得結果格納構造体
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/03/08 (Mon) 16:39:58 M.Miura
    '更新日：2004/06/01 (Tue) 13:04:26 N.Kasai
    '備　考：
    '　　　：2005/03/29 (Tue) 08:52:14 S.Deguchi    保留情報取得のﾒｯｾｰｼﾞのTAG追加
    '　　　：2005/04/14 (Thu) 09:46:57 S.Deguchi    不具合№688対応で応答ﾒｯｾｰｼﾞのﾘｽﾄ化対応
    Public Function pubblnLotHoldinfo_Sel(ByVal lstrlot_holdinfoVer As String, _
                                          ByVal lstrLotID As String, _
                                          ByRef ltypLotHoldInfoList As LotHoldInfoList) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry             '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得

        Try

            pstrMessageName = "ロット保留情報取得"
            pubblnLotHoldinfo_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)                 'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            If lstrlot_holdinfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_holdinfoVer)     'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_holdinfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getMsgAry(CPstrHOLD_LIST, laAry)   '保留ﾘｽﾄ

                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypLotHoldInfoList.lngHoldInfoListCnt = laAry.Count

                        '@配列の要素数を設定
                        ltypLotHoldInfoList.typHoldInfoList = New List(Of LotHoldinfo)

                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim typLotHoldinfoTmp = New LotHoldinfo
                            With typLotHoldinfoTmp
                                Call ltMsg.getString(CPstrHOLD_REASON_ID, .strHoldReasonID)             '停止保留発生時理由ID
                                Call ltMsg.getString(CPstrHOLD_TIME, .strHoldTime)                      '停止保留発生時刻
                                Call ltMsg.getString(CPstrHOLD_COMMENTS, .strHoldComment)               '保留ｺﾒﾝﾄ
                                Call ltMsg.getString(CPstrHOLD_EMP_ID, .strHoldEmpID)                   '保留責任者
                                Call ltMsg.getString(CPstrHOLD_EMP_NAME, .strHoldEmpName)               '保留責任者名
                                Call ltMsg.getString(CPstrHOLD_TERM_DATE, .strHoldTermDate)             '保留期限
                                Call ltMsg.getString(CPstrHOLD_REASON_NAME, .strHoldReasonName)         '停止保留発生時理由名
                                Call ltMsg.getString(CPstrRESTRICT_FLAG, .strRestrictFlag)              '制限ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrHOLD_STAY_DATE, .strHoldStayDate)             '保留期間
                                Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)                    '登録日時
                            End With
                            ltypLotHoldInfoList.typHoldInfoList.Add(typLotHoldinfoTmp)
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnLotHoldinfo_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_holdinfoVer)

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

    '関数名：pubblnLotHoldset_Ins
    '機　能：ﾛｯﾄ保留設定
    '引　数：lstrlot_holdset_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotHoldset     ：編成内容格納
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/11 (Thu) 12:23:26 M.Miura
    '更新日：2004/06/01 (Tue) 13:05:22 N.Kasai
    '備　考：
    '　　　：2005/11/21 (Mon) 16:56:16 S.Deguchi    応答に保留日時を追加
    Public Function pubblnLotHold_Ins(ByRef lstrlot_holdset_Ver As String, _
                                      ByRef ltypLotHoldset As LotHoldset) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            pstrMessageName = "ロット保留設定登録"      'ﾛｯﾄ保留設定要求
            pubblnLotHold_Ins = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypLotHoldset
            
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@保留理由ID
                If .strHoldReasonID <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_REASON_ID, .strHoldReasonID)
                Else
                    Call lrMsg.addString(CPstrHOLD_REASON_ID, CPstrMsgNull)
                End If
                '@保留ｺﾒﾝﾄ
                If .strHoldComment <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_COMMENTS, .strHoldComment)
                Else
                    Call lrMsg.addString(CPstrHOLD_COMMENTS, CPstrMsgNull)
                End If
                '@保留期限
                If .strHoldTermDate <> vbNullString And .strHoldTermDate <> CPstrNullDate Then
                    Call lrMsg.addString(CPstrHOLD_TERM_DATE, .strHoldTermDate)
                Else
                    Call lrMsg.addString(CPstrHOLD_TERM_DATE, CPstrMsgNull)
                End If
                '@保留責任者
                If .strHoldEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_EMP_ID, .strHoldEmpID)
                Else
                    Call lrMsg.addString(CPstrHOLD_EMP_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@ﾛｯﾄ最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
            End With
            '@SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_holdset_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_holdset_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_hold____, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypLotHoldset
                        Call laMsg.getString(CPstrHOLD_TIME, .strHoldEditTime)              '保留日時
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotHold_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_holdset_Ver)
                    
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnLotReleaseHold_Upd
    '機　能：ﾛｯﾄ保留解除
    '引　数：lstrlot_holdreleaseVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotRelesset        ：編集内容格納
    '　　　：lstrGuidMsg            ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode        ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/11 (Thu) 12:48:09 M.Miura
    '更新日：2005/03/31 (Thu) 13:57:29 N.Kojima
    '備　考：
    '　　　：2005/03/31 (Thu) 13:57:29 N.Kojima     応答に"GUID_MSG_CODE"、"GUID_MSG"を追加(ｶﾞｲﾀﾞﾝｽ対応)
    '　　　：2005/04/15 (Fri) 11:38:31 S.Deguchi    送信ﾒｯｾｰｼﾞに登録日時を追加
    Public Function pubblnLotReleaseHold_Upd(ByVal lstrlot_holdreleaseVer As String, _
                                             ByRef ltypLotHoldRelesset As LotHoldRelesset, _
                                             ByRef lstrGuidMsg As String, _
                                             ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            pstrMessageName = "ロット保留解除登録"  'ﾛｯﾄ保留解除要求
            pubblnLotReleaseHold_Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            With ltypLotHoldRelesset

                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@保留ｺﾒﾝﾄ
                If .strHoldReleseComment <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_COMMENTS, .strHoldReleseComment)
                Else
                    Call lrMsg.addString(CPstrHOLD_COMMENTS, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@ﾛｯﾄ最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
                '@(保留)登録日時
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
            End With
            '@SB_ID
            If pstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_holdreleaseVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_holdreleaseVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_releasehold, lrMsg, laMsg)

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
                    pubblnLotReleaseHold_Upd = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_holdreleaseVer)

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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMasSbList_Sel
    '機　能：ｼｽﾃﾑﾌﾞﾛｯｸ取得
    '引　数：lstrmas_sblist__Ver：Msgﾊﾞｰｼﾞｮﾝ
    '引　数：ltypSbList         ：ｼｽﾃﾑﾌﾞﾛｯｸﾘｽﾄ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/07/05 (Mon) 08:58:09 M.Miura
    '更新日：2004/07/05 (Mon) 08:58:09
    '備　考：
    Public Function pubblnMasSbList_Sel(ByVal lstrmas_sblist__Ver As String, _
                                        ByRef ltypMasSbList As MasSbList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "システムブロック取得"
            pubblnMasSbList_Sel = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laMsg = New TfMsg
            
            'NSYS リスト初期化
            ltypMasSbList = New MasSbList
            If ltypMasSbList.typSbList Is Nothing Then
                ltypMasSbList.typSbList = New List(Of SbList)
            End If
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrmas_sblist__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_sblist__Ver)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_sblist__, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@ﾃﾞｰﾀを取得
                    Call laMsg.getMsgAry(CPstrSB_LIST, laAry)   'ｼｽﾃﾑﾌﾞﾛｯｸﾘｽﾄ
                    
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypMasSbList.lngSbListCnt = laAry.Count
                        
                        '@配列の要素数を設定
                        Dim typSbListTmp As SbList = New SbList
                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With typSbListTmp
                            
                                Call ltMsg.getString(CPstrSB_ID, .strSbID)                      'ｼｽﾃﾑﾌﾞﾛｯｸID
                                Call ltMsg.getString(CPstrSB_NAME, .strSBName)                  'ｼｽﾃﾑﾌﾞﾛｯｸ名
                                
                            End With
                            ltypMasSbList.typSbList.Add(typSbListTmp)
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasSbList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_sblist__Ver)
                    
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnWfScrap_Del
    '機　能：WF廃棄
    '引　数：lstrwf__scrap___Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypWfScrap        ：WF廃棄構造体
    '戻り値：True:成功、False：失敗
    '作成日：2004/07/07 (Wed) 09:55:44 M.Miura
    '更新日：2004/07/07 (Wed) 09:55:44
    '備　考：
    Public Function pubblnWfScrap_Del(ByVal lstrwf__scrap___Ver As String, _
                                      ByRef ltypWfScrap As WfScrap) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        
        Try
            
            pstrMessageName = "WF廃棄"
            pubblnWfScrap_Del = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypWfScrap
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrwf__scrap___Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrwf__scrap___Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@ｷｬﾘｱ1ID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@廃棄WFﾘｽﾄ
                For llngCnt = 0 To ltypWfScrap.typWfList.Count -1
                    If .typWfList(llngCnt).strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, .typWfList(llngCnt).strWfId)      'ｽﾛｯﾄ№
                    Else
                        Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt
                
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
                lrAry.Clear
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrwf__scrap___, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnWfScrap_Del = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrwf__scrap___Ver)
                    
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnCarrMove_Upd
    '機　能：ｷｬﾘｱ統合送信
    '引　数：lstrcarrmove____Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypCarrMove       ：ｷｬﾘｱ統合構造体
    '　　　：llngWFCnt1         ：統合元WF枚数
    '　　　：llngWFCnt2         ：統合先WF枚数
    '戻り値：True:成功、False：失敗
    '作成日：2004/07/05 (Mon) 14:40:42 N.Kojima
    '更新日：2005/03/22 (Tue) 13:32:02 N.Kasai
    '備　考：
    '　　　：2004/10/19 (Tue) 10:55:29 K.Takano     空Ary処理削除対応
    '　　　：2005/03/22 (Tue) 13:32:02 N.Kasai      ﾒｯｾｰｼﾞﾎﾞｯｸｽのﾀｲﾄﾙ名を固定表示からﾃﾞｰﾀ表示へ変更
    '　　　：2005/07/26 (Tue) 11:37:22 S.Deguchi    要求Tagにｵﾝﾗｲﾝﾌﾗｸﾞを追加
    Public Function pubblnCarrMove_Upd(ByVal lstrcarrmove____Ver As String, _
                                       ByRef ltypCarrMove As CarrMove, _
                                       ByVal llngWFCnt1 As Integer, _
                                       ByVal llngWFCnt2 As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        
        Try
            
            '@初期化
            pubblnCarrMove_Upd = False
            
            lrMsg = New TfMsg
            ltMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypCarrMove
                '@ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ設定
                If .strMessageName <> vbNullString Then
                    pstrMessageName = .strMessageName
                Else
                    pstrMessageName = "キャリア統合"
                End If

                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@対象ｷｬﾘｱ1ID
                If .strCarrierID1 <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID1, .strCarrierID1)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID1, CPstrMsgNull)
                End If
                
                '@対象ｷｬﾘｱ2ID
                If .strCarrierID2 <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID2, .strCarrierID2)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID2, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrcarrmove____Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrcarrmove____Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｵﾝﾗｲﾝﾌﾗｸﾞ
                If .strOnlineFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrONLINE_FLAG, .strOnlineFlag)
                Else
                    Call lrMsg.addString(CPstrONLINE_FLAG, CPstrMsgNull)
                End If

                '@統合元のｷｬﾘｱ1ｽﾛｯﾄﾏｯﾌﾟ
                llngCnt = 0
                Do While llngWFCnt1 -1 >= llngCnt
                    If .typWFMapList1(llngCnt).strSlotPosition <> vbNullString Then
                        Call ltMsg.addString(CPstrSLOT_POSITION, .typWFMapList1(llngCnt).strSlotPosition)      'ｽﾛｯﾄ№
                    Else
                        Call ltMsg.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                    End If
                    If .typWFMapList1(llngCnt).strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, .typWFMapList1(llngCnt).strWfId)                      'WFID
                    Else
                        Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                    End If
                    
                    If .typWFMapList1(llngCnt).strjigId <> vbNullString Then
                        Call ltMsg.addString(CPstrJIG_ID, .typWFMapList1(llngCnt).strjigId)                    '治具ID
                    Else
                        Call ltMsg.addString(CPstrJIG_ID, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                    llngCnt = llngCnt + 1
                Loop
                Call lrMsg.addMsgAry(CPstrWF_MAP_LIST1, lrAry)
                lrAry.Clear

                '@統合先のｷｬﾘｱ2ｽﾛｯﾄﾏｯﾌﾟ
                llngCnt = 0
                Do While llngWFCnt2 -1 >= llngCnt
                    If .typWFMapList2(llngCnt).strSlotPosition <> vbNullString Then
                        Call ltMsg.addString(CPstrSLOT_POSITION, .typWFMapList2(llngCnt).strSlotPosition)      'ｽﾛｯﾄ№
                    Else
                        Call ltMsg.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                    End If
                    If .typWFMapList2(llngCnt).strWfId <> vbNullString Then
                        Call ltMsg.addString(CPstrWF_ID, .typWFMapList2(llngCnt).strWfId)                      'WFID
                    Else
                        Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                    End If

                    If .typWFMapList2(llngCnt).strjigId <> vbNullString Then
                        Call ltMsg.addString(CPstrJIG_ID, .typWFMapList2(llngCnt).strjigId)                    '治具ID
                    Else
                        Call ltMsg.addString(CPstrJIG_ID, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                    llngCnt = llngCnt + 1
                Loop
                Call lrMsg.addMsgAry(CPstrWF_MAP_LIST2, lrAry)
                lrAry.Clear
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrmove____, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnCarrMove_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrcarrmove____Ver)
                    
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
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
                
        End Try
    End Function

    '関数名：pubblnFuncinfo_Sel
    '機　能：機能ﾊﾞｰｼﾞｮﾝ取得処理(ﾒﾆｭｰ用定数取得)
    '引　数：lstrutilfuncinfoVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypFunctionList   ：関数情報取得
    '戻り値：Ture:正常、False:異常
    '作成日：2004/06/08 (Tue) 10:18:56 N.Kasai
    '更新日：2004/09/29 (Wed) 17:06:29 H.Wajima
    '備　考：
    '　　　：2004/09/29 (Wed) 17:06:29 H.Wajima     機能ﾊﾞｰｼﾞｮﾝ削除
    Public Function pubblnFuncinfo_Sel(ByVal lstrutilfuncinfoVer As String, _
                                       ByRef ltypFuncInfo As UtilFuncInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        
        Try

            '@初期設定
            pstrMessageName = "機能バージョン取得"
            pubblnFuncinfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrutilfuncinfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrutilfuncinfoVer)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrutilfuncinfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ﾃﾞｰﾀを取得
                    Call laMsg.getMsgAry(CPstrFUNCTION_LIST, laAry)   'ｼｽﾃﾑﾌﾞﾛｯｸﾘｽﾄ
                    
                    '@ｱﾚｰの数が0じゃなければ処理
                    If laAry.Count <> 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        ltypFuncInfo.lngListCnt = laAry.Count
                        
                        '@配列の要素数を設定
                        ltypFuncInfo.typFunctionList = New List(Of FunctionList)(ltypFuncInfo.lngListCnt)

                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Dim typFunctionListTmp = New FunctionList
                            With typFunctionListTmp
                            
                                Call ltMsg.getString(CPstrFUNCTION_ID, .strFunctionID)              '機能ID
                                Call ltMsg.getString(CPstrFUNCTION_NAME, .strFunctionName)          '機能名
                                Call ltMsg.getString(CPstrFORM_NAME, .strFormName)                  'ﾌｫｰﾑ名
        '                        Call ltMsg.getString(CPstrFUNCTION_VERSION, .strFunctionVersion)    '機能ﾊﾞｰｼﾞｮﾝ
                                Call ltMsg.getString(CPstrTAKING_OVER_FLAG, .strTakingOverFlag)     '引継ぎﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrENABLE_FLAG, .strEnableFlag)              '有効/無効ﾌﾗｸﾞ
                                
                            End With
                            ltypFuncInfo.typFunctionList.Add(typFunctionListTmp)
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnFuncinfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrutilfuncinfoVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000B)
                    '@「プログラムの起動に必要な基本情報が取得できませんでした。システム担当者に連絡して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnBatLotList_Sel
    '機　能：ﾊﾞｯﾁ組ﾛｯﾄ情報取得
    '引　数：ltypBatRequestList ：情報要求構造体
    '　　　：ltypBatLotList     ：ﾊﾞｯﾁ組ﾛｯﾄ情報構造体
    '戻り値：True：通信成功、False：通信失敗
    '作成日：2004/07/13 (Tue) 14:51:15 S.Deguchi
    '更新日：2009/11/17 (Tue) 15:53:42 N.Kojima
    '備　考：特殊特性変換処理あり
    '　　　：2004/09/26 (Sun) 12:14:02 Y.Yamagishi　応答ﾀｸﾞに制限ﾀｲﾌﾟ追加
    '　　　：2008/06/16 (Mon) 17:38:50 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/06/30 (Tue) 17:55:06 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/21 (Tue) 15:11:58 N.Kojima     無機対応Phase2、応答に"USE_ID","MES_MODE_ID"等追加。(案件№03661)
    '　　　：2009/11/17 (Tue) 15:53:42 N.Kojima     応答ﾀｸﾞに"VA_CONDITION_ID"、"VA_CONDITION_FLAG"追加。(案件№03790)
    Public Function pubblnBatLotList_Sel(ByRef ltypBatRequestList As BatRequestList, _
                                         ByRef ltypBatLotList As BatLotList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim laAry1              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt1            As Integer          'ｱﾚｲｶｳﾝﾄ用
        Dim llngCnt2            As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@各種初期設定
            pstrMessageName = "バッチ組ロット情報取得"
            pubblnBatLotList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            ltMsg2 = New TfMsg
            laAry1 = New TfMsgAry
            laAry2 = New TfMsgAry

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypBatRequestList

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If

                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If

                '@装置ｸﾞﾙｰﾌﾟID
                If .strMcGroupID <> vbNullString Then
                    Call lrMsg.addString(CPstrMC_GROUP_ID, .strMcGroupID)
                Else
                    Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
                End If

                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_lotlist_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾊﾞｯﾁ組ﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrBATCH_LIST, laAry1)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾊﾞｯﾁ組ﾘｽﾄﾃﾞｰﾀ数
                    ltypBatLotList.lngBatLotCnt = laAry1.Count

                    '@：ﾊﾞｯﾁ組ﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If ltypBatLotList.lngBatLotCnt > 0 Then

                        '@配列領域の確保
                        ltypBatLotList.typBatLot = New List(Of BatLot)
                        '@ｶｳﾝﾀの初期化
                        llngCnt1 = 0

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg1 In laAry1
                            Dim typBatLotTmp As BatLot = New BatLot

                            With typBatLotTmp

                                Call ltMsg1.getString(CPstrBATCH_ID, .strBatchId)                   'ﾊﾞｯﾁID
                                Call ltMsg1.getString(CPstrWP_ID, .strWpID)                         'WPID
                                Call ltMsg1.getString(CPstrWP_NAME, .strWpName)                     'WPID名称
                                Call ltMsg1.getString(CPstrRECIPE_ID, .strRecipeId)                 'ﾚｼﾋﾟID
                                Call ltMsg1.getString(CPstrVA_CONDITION_ID, .strVaConditionID)      '蒸着処理条件ID
                                Call ltMsg1.getString(CPstrVA_CONDITION_FLAG, .strVaConditionFlag)  '蒸着処理条件制限ﾌﾗｸﾞ(1：有効、0：無効)
                                Call ltMsg1.getString(CPstrEQ_TYPE, .strEqType)                     '装置ﾀｲﾌﾟ
                                Call ltMsg1.getString(CPstrMES_MODE_ID, .strMesModeId)              '運用ﾓｰﾄﾞ

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2格納：ﾛｯﾄﾘｽﾄ
                                Call ltMsg1.getMsgAry(CPstrLOT_LIST, laAry2)

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ2数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                                .lngBatLotListCnt = laAry2.Count

                                '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                                If .lngBatLotListCnt > 0 Then

                                    '@配列領域の確保
                                    If .typBatList Is Nothing Then
                                        .typBatList = New List(Of BatList)
                                    End If

                                    Do While (.typBatList.Count < .lngBatLotListCnt)
                                        .typBatList.Add(New BatList)
                                    Loop

                                    Dim typBatListTmp As BatList = New BatList

                                    '@ｶｳﾝﾀ2の初期化
                                    llngCnt2 = 0

                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各ﾃﾞｰﾀ取得
                                    For Each ltMsg2 In laAry2

                                        With typBatListTmp

                                            Call ltMsg2.getString(CPstrLOT_ID, .strLotID)                           'ﾛｯﾄID
                                            Call ltMsg2.getString(CPstrSEQ_NUM, .strSeqNum)                         'ﾊﾞｯﾁ順序
                                            Call ltMsg2.getString(CPstrCARRIER_ID, .strCarrierId)                   'ｷｬﾘｱID
                                            Call ltMsg2.getString(CPstrJIG_ID, .strjigId)                           '冶具ID
                                            Call ltMsg2.getString(CPstrWF_ID, .strWfId)                             'WFID
                                            Call ltMsg2.getString(CPstrUNLOADER_CARRIER_ID, .strUldCarrierID)       'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                                            Call ltMsg2.getString(CPstrCF_FLAG, .strCfFlag)                         'CFﾌﾗｸﾞ
                                            Call ltMsg2.getString(CPstrLP_FLAG, .strLpFlag)                         'LPﾌﾗｸﾞ
                                            Call ltMsg2.getString(CPstrFLOW_CLASS, .strFlowClass)                   '流動区分
                                            Call ltMsg2.getString(CPstrLOT_PRIORITY, .strLotPriority)               '優先度
                                            Call ltMsg2.getString(CPstrSPECIAL_FLG, .strSpecialFlag)                '特殊特性
                                            Call ltMsg2.getString(CPstrLIMIT_TIME, .strLimitTime)                   '時間制約
                                            Call ltMsg2.getString(CPstrWF_QUANTITY, .strWFQuantity)                 'WF枚数
                                            Call ltMsg2.getString(CPstrOPTION_TEXT, .strOptionText)                 '作業条件
                                            Call ltMsg2.getString(CPstrENG_EMP_NAME, .strEngEmpName)                'ﾛｯﾄ担当者名
                                            Call ltMsg2.getString(CPstrSTART_TIME, .strStartTime)                   '処理開始予定日時
                                            Call ltMsg2.getString(CPstrCURRENT_STATUS_NAME, .strCurrentStatusName)  'Lot状態
                                            Call ltMsg2.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)          '最終更新日時
                                            Call ltMsg2.getString(CPstrOP_ID, .strOpID)                             '大工程
                                            Call ltMsg2.getString(CPstrSTEP_ID, .strStepID)                         '小工程
                                            Call ltMsg2.getString(CPstrPD_ID, .strPdId)                             '機種ID+ﾊﾞｰｼﾞｮﾝ
                                            Call ltMsg2.getString(CPstrTO_OP_ID, .strToOpId)                        '制限時間先大工程
                                            Call ltMsg2.getString(CPstrTO_STEP_ID, .strToStepId)                    '制限時間先小工程
                                            Call ltMsg2.getString(CPstrWARN_TIME, .strWarnTime)                     '警告時間
                                            Call ltMsg2.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)        '制限ﾀｲﾌﾟ
                                            Call ltMsg2.getString(CPstrUSE_ID, .strUseId)                           '機種区分
                                            Call ltMsg2.getString(CPstrCURRENT_STATUS, .strCurrentStatusID)         'Lot状態ID
                                            Call ltMsg2.getString(CPstrFLOW_CLASS_NAME, .strFlowClassName)          '流動区分名
                                            Call ltMsg2.getString(CPstrREWORK_FLAG, .strReworkFlag)                 'ﾘﾜｰｸﾌﾗｸﾞ
        '@↓2019/05/17 (Fri) 16:56:37 Y.Yoneyama **************************************************
                                            Call ltMsg2.getString(CPstrVA_FLAG, .strVaFlag)                         '無機ﾌﾗｸﾞ
                                            Call ltMsg2.getString(CPstrJ_BATCH_ID, .strJBatchId)                    '蒸着ﾊﾞｯﾁID
                                            Call ltMsg2.getString(CPstrH_BATCH_ID, .strHBatchId)                    '表面処理ﾊﾞｯﾁID
                                            Call ltMsg2.getString(CPstrINSPECT_ONLINE_FLAG, .strInspectFlag)        '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                                            Call ltMsg2.getString(CPstrJ_BATCH_PAIR_CARRIER, .strPairCarrier)       '対ｷｬﾘｱ
        '@↑2019/05/17 (Fri) 16:56:37 Y.Yoneyama **************************************************
                                            
                                            '@★ 特殊特性ﾌﾗｸﾞにより処理分岐 ★
                                            Select Case .strSpecialFlag

                                                '@〓 0：非表示 〓
                                                Case CPstrSpNull

                                                    .strSpecialFlag = vbNullString

                                                '@〓 1、2、その他(その他はありえない) 〓
                                                Case Else

                                                    '@処理なし

                                            End Select
                                        End With

                                        .typBatList(llngCnt2) = typBatListTmp

                                        '@ｶｳﾝﾀ2を+1する
                                        llngCnt2 = llngCnt2 + 1
                                    Next
                                End If
                            End With

                            ltypBatLotList.typBatLot.Add(typBatLotTmp)

                            '@ｶｳﾝﾀを+1する
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnBatLotList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypBatRequestList.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            laAry1 = Nothing
            laAry2 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            laAry1 = Nothing
            laAry2 = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnlotComntInfo_Sel
    '機　能：ﾛｯﾄｺﾒﾝﾄ取得
    '引　数：lstrCarrierID      ：ｷｬﾘｱID
    '　　　：lstrMsgVer         ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotComntInfo   ：取得構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/07/13 (Tue) 19:31:59 S.Deguchi
    '更新日：2004/07/16 (Fri) 09:08:02 S.Deguchi
    '備　考：他画面で使用する為,CM0050へ後ほど移動
    Public Function pubblnlotComntInfo_Sel(ByVal lstrCarrierID As String, _
                                           ByVal lstrMsgVer As String, _
                                           ByRef ltypLotComntInfo As LotComntInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@初期設定
            pstrMessageName = "ロットコメント取得"
            pubblnlotComntInfo_Sel = False
            
            '@応答構造体初期化
            ltypLotComntInfo.strComments = vbNullString
            ltypLotComntInfo.strLotLastUpdate = vbNullString
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_comntinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞ取得
                    With ltypLotComntInfo
                        Call laMsg.getString(CPstrCOMMENTS, .strComments)                   'ﾛｯﾄｺﾒﾝﾄ
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)       'ﾛｯﾄ最終更新日時
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnlotComntInfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
            End Select
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnMasMcGroupList_Sel
    '機　能：装置ｸﾞﾙｰﾌﾟ取得
    '引　数：lstrmas_mcgrouplistVer ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分(02:全て 2G:ﾊﾞｯﾁｸﾞﾙｰﾌﾟ指定 2H:ﾛｯﾄｸﾞﾙｰﾌﾟ指定)
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：typMcGroupList         ：装置ｸﾞﾙｰﾌﾟ構造体
    '戻り値：True:正常　False:異常
    '作成日：2004/07/13 (Tue) 17:04:39 N.Kasai
    '更新日：2004/07/14 (Wed) 19:16:48 N.Kasai
    '備　考：
    Public Function pubblnMasMcGroupList_Sel(ByVal lstrmas_mcgrouplistVer As String, _
                                             ByVal lstrClassDivision As String, _
                                             ByVal lstrSBID As String, _
                                             ByRef typMcGroupList As McGroupList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "装置グループ取得"
            
            pubblnMasMcGroupList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_mcgrouplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_mcgrouplistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@SBID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_mcgrouplist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrMC_GROUP_LIST, laAry)
                    
                    With typMcGroupList
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    .lngMcGroupListCnt = laAry.Count

                    '@配列があればﾃﾞｰﾀ格納
                    If .lngMcGroupListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        .typMcGroupList = New List(Of McList)
                        llngCnt = 0
                        For Each ltMsg In laAry
                            '@受信結果取得
                            Dim typMcGroupListTmp As McList = New McList
                            With typMcGroupListTmp
                                Call ltMsg.getString(CPstrMC_GROUP_ID, .strMcGroupID)           '装置ｸﾞﾙｰﾌﾟID
                                Call ltMsg.getString(CPstrMC_GROUP_NAME, .strMcGroupName)       '装置ｸﾞﾙｰﾌﾟ名
                                Call ltMsg.getString(CPstrBATCH_FLAG, .strBatchFlag)            'ﾊﾞｯﾁﾌﾗｸﾞ
                            End With
                            .typMcGroupList.Add(typMcGroupListTmp)
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasMcGroupList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_mcgrouplistVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnWpList_Sel
    '機　能：装置一覧取得
    '引　数：lstrmas_wplist__Ver    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：llngWpCnt              ：ﾘｽﾄｶｳﾝﾄ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrClassDivision      ：処理区分
    '　　　：lstrMcGroupId          ：装置ｸﾞﾙｰﾌﾟID
    '　　　：lstrCategoryId         ：ｶﾃｺﾞﾘID
    '　　　：lstrConditionID        ：処理条件ID
    '　　　：lstrConditionVer       ：処理条件Ver
    '　　　：lstrEqtype             ：装置ﾀｲﾌﾟ
    '戻り値：True：成功、False：失敗
    '作成日：2004/05/24 (Mon) 15:06:49 N.Kasai
    '更新日：2005/06/29 (Wed) 17:02:26 N.Kasai
    '備　考：
    '　　　：2004/09/01 (Wed) 11:25:00 T.Kitagawa　 要求ﾒｯｾｰｼﾞにｶﾃｺﾞﾘID追加
    '　　　：2004/09/15 (Wed) 11:02:19 N.Kasai      新COM対応不要ﾀｸﾞの削除(lstrOpID、lstrStepID)
    '　　　：2004/09/28 (Tue) 10:59:41 T.Kitagawa   装置ﾀｲﾌﾟ追加(不具合№938)
    '　　　：2004/11/05 (Fri) 14:34:04 Y.Yamagishi  処理条件ID、処理条件Ver追加(不具合№188)
    '　　　：2005/02/17 (Thu) 14:08:07 S.Deguchi    ﾚﾁｸﾙﾏﾆｭｱﾙ搬送対応で"MES_MODE_ID"を応答Msgへ追加
    '　　　：2004/05/24 (Mon) 15:06:49 N.Kasai      ﾚﾁｸﾙﾏﾆｭｱﾙ搬送対応で"PORT_STATUS"、"PORT_STATUS_ID"、"CARRIER_ID"
    '　　　：2005/03/14 (Mon) 16:31:47 N.Kojima     投入装置表示対応で要求に"EQ_TYPE"を追加：処理区分=3U時のみｾｯﾄ(改善№577)
    '　　　：2005/06/29 (Wed) 17:02:26 N.Kasai      応答MSG追加(LOT_RECIPE_FLAG)
    Public Function pubblnWpList_Sel(ByVal lstrmas_wplist__Ver As String, _
                                     ByRef llngWpCnt As Integer, _
                                     ByVal lstrSBID As String, _
                                     ByVal lstrClassDivision As String, _
                                     Optional ByVal lstrMcGroupID As String = CPstrMsgNull, _
                                     Optional ByVal lstrCategoryId As String = CPstrMsgNull, _
                                     Optional ByVal lstrConditionID As String = CPstrMsgNull, _
                                     Optional ByVal lstrConditionVer As String = CPstrMsgNull, _
                                     Optional ByVal lstrEqType As String = CPstrMsgNull) As Boolean

        Dim lrMsg                       As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg                       As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry                       As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET                     As String           '応答取得
        Dim llngCnt                     As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            '@初期設定
            pstrMessageName = "装置一覧取得"
            pubblnWpList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
                        
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                          'SBID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrmas_wplist__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_wplist__Ver)             'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)        '処理区分
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            If lstrMcGroupID <> vbNullString Then
                Call lrMsg.addString(CPstrMC_GROUP_ID, lstrMcGroupID)               '装置ｸﾞﾙｰﾌﾟID
            Else
                Call lrMsg.addString(CPstrMC_GROUP_ID, CPstrMsgNull)
            End If
            If lstrCategoryId <> vbNullString Then
                Call lrMsg.addString(CPstrCATEGORY_ID, lstrCategoryId)              'ｶﾃｺﾞﾘID
            Else
                Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
            End If
            If lstrConditionID <> vbNullString Then
                Call lrMsg.addString(CPstrCONDITION_ID, lstrConditionID)            '処理条件ID
            Else
                Call lrMsg.addString(CPstrCONDITION_ID, CPstrMsgNull)
            End If
            If lstrConditionVer <> vbNullString Then
                Call lrMsg.addString(CPstrCONDITION_VERSION, lstrConditionVer)      '処理条件ﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrCONDITION_VERSION, CPstrMsgNull)
            End If
            If lstrEqType <> vbNullString Then
                Call lrMsg.addString(CPstrEQ_TYPE, lstrEqType)                      '装置ﾀｲﾌﾟ
            Else
                Call lrMsg.addString(CPstrEQ_TYPE, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_wplist__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrWP_LIST, laAry)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                    llngWpCnt = laAry.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngWpCnt > 0 Then
                        'NSYS リスト初期化
                        If ptypWPList Is Nothing Then
                            ptypWPList = New List(Of WpList)
                        Else
                            ptypWPList.Clear()
                        End If

                        Do While (ptypWPList.Count < llngWpCnt)
                            ptypWPList.Add(New WpList)
                        Loop
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            '@受信結果取得
                            Dim ptypWPListTmp As WpList = New WpList

                            With ptypWPListTmp
                                Call ltMsg.getString(CPstrWP_ID, .strWpID)
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)
                                Call ltMsg.getString(CPstrMAX_PROCESS_BOX, .strMaxProcessBox)
                                Call ltMsg.getString(CPstrEQ_TYPE, .strEqType)
                                Call ltMsg.getString(CPstrMES_MODE_ID, .strMesModeId)
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)
                                Call ltMsg.getString(CPstrPORT_STATUS_ID, .strPortStatusID)
                                Call ltMsg.getString(CPstrPORT_STATUS, .strPortStatus)
                                Call ltMsg.getString(CPstrLOT_RECIPE_FLAG, .strLotRecipeFlag)
                                Call ltMsg.getString(CPstrBATCH_COMPOSE_TYPE, .strBatchComposeType)
                                
                            End With

                            ptypWPList(llngCnt) = ptypWPListTmp

                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnWpList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_wplist__Ver)
                    
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnInvAcptlotList_Sel
    '機　能：在庫ﾛｯﾄﾘｽﾄ取得
    '引　数：ltypInvAcptLotListReq  ：要求格納構造体
    '　　　：ltypInvAcptLotListAns  ：応答格納構造体
    '　　　：ltypInvAcptLotListCnt  ：応答ﾃﾞｰﾀ数
    '戻り値：True:成功/False:失敗
    '作成日：2004/06/28 (Mon) 16:28:54 S.Deguchi
    '更新日：2016/02/11 (Thu) 22:38:22 H.Hayashi
    '備　考：
    '　　　：2004/10/06 (Wed) 15:02:10 S.Deguchi    "DIVIDE_STATUS"を追加
    '　　　：2004/10/14 (Thu) 10:03:27 N.Kasai      ENTRY_TIME→EDIT_TIMEへ変更
    '　　　：2004/10/21 (Thu) 15:09:54 K.Takano     空Ary対応
    '　　　：2004/11/02 (Tue) 15:10:36 N.Kasai      ﾀｸﾞ追加(WF_CARRY_FLAG)
    '　　　：2004/11/15 (Mon) 09:36:17 H.Wajima     ﾀｸﾞ追加(TO_CARRYERID1,TO_CARRYERID2) 不具合№128(ｺﾒﾝﾄｱｳﾄ)
    '　　　：2005/01/17 (Mon) 08:38:42 S.Deguchi    上記ｺﾒﾝﾄｱｳﾄ解除
    '　　　：2006/09/11 (Mon) 10:28:06 N.Kojima     応答に"SEND_SB_ID","SEND_SB_NAME"追加。(案件№01452)
    '　　　：2008/06/16 (Mon) 17:45:38 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     欠損ﾁｯﾌﾟ表示対応(No.03046)及びSource整備
    '　　　：2009/12/03 (Thu) 13:05:50 H.Hayashi    応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnInvAcptlotList_Sel(ByRef ltypInvAcptLotListReq As invAcptLotListReq, _
                                             ByRef ltypInvAcptLotListAns As InvAcptLotListAns, _
                                             ByRef llngInvAcptLotListCnt As Integer) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim lstrRET            As String            '応答取得
        Dim llngCnt1           As Integer           'ｱﾚｲｶｳﾝﾄ用

        Try

            '@各種初期設定
            pstrMessageName = "受入在庫ロット一覧"
            pubblnInvAcptlotList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg2 = New TfMsg
            lrAry2 = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry

            'NSYS　初期化
            If IsNothing(ltypInvAcptLotListAns.typLotList) Then
                ltypInvAcptLotListAns.typLotList = New List(Of InvAcptLotListLotList)
            Else
                ltypInvAcptLotListAns.typLotList.Clear()
            End If

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypInvAcptLotListReq
            
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

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@投入機種
                If .strAssemblePdId <> vbNullString Then
                    Call lrMsg.addString(CPstrASSEMBLE_PD_ID, .strAssemblePdId)
                Else
                    Call lrMsg.addString(CPstrASSEMBLE_PD_ID, CPstrMsgNull)
                End If

                '@機種ﾘｽﾄ
                For llngCnt1 = 0 To .lngPdCnt -1
                    '@機種ID
                    If .typPdList(llngCnt1).strPdId <> vbNullString Then
                        Call ltMsg.addString(CPstrPD_ID, .typPdList(llngCnt1).strPdId)
                    Else
                        Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    Call ltMsg.Clear
                Next
                
                Call lrMsg.addMsgAry(CPstrPD_LIST, lrAry)
                Call lrAry.Clear
                
                '@種別ﾘｽﾄ
                For llngCnt1 = 0 To .lngFlowClassCnt -1
                    
                    '@種別
                    If .typFlowClassList(llngCnt1).strFlowClass <> vbNullString Then
                        Call ltMsg2.addString(CPstrFLOW_CLASS_ID, .typFlowClassList(llngCnt1).strFlowClass)
                    Else
                        Call ltMsg2.addString(CPstrFLOW_CLASS_ID, CPstrMsgNull)
                    End If
                    
                    Call lrAry2.Add(ltMsg2)
                    Call ltMsg2.Clear
                Next
                
                Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry2)
                Call lrAry2.Clear

            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_acptlotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：ﾛｯﾄﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry1)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数：ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                    llngInvAcptLotListCnt = laAry1.Count

                    '@ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                    If llngInvAcptLotListCnt > 0 Then
                        
                        '@配列領域の確保
                        Do While (ltypInvAcptLotListAns.typLotList.Count < llngInvAcptLotListCnt)
                            ltypInvAcptLotListAns.typLotList.Add(New InvAcptLotListLotList)
                        Loop

                        Dim typLotListTmp As InvAcptLotListLotList = New InvAcptLotListLotList

                        '@ｶｳﾝﾀの初期化
                        llngCnt1 = 0
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                        For Each ltMsg1 In laAry1

                            With typLotListTmp
                                
                                Call ltMsg1.getString(CPstrLOT_ID, .strLotID)                           'ﾛｯﾄID
                                Call ltMsg1.getString(CPstrENTRY_TIME, .strEntryTime)                   '受入日時
                                Call ltMsg1.getString(CPstrCARRIER_ID, .strCarrierId)                   'ｷｬﾘｱID
                                Call ltMsg1.getString(CPstrPD_ID, .strPdId)                             '機種
                                Call ltMsg1.getString(CPstrFLOW_CLASS, .strFlowClass)                   '流動区分
                                Call ltMsg1.getString(CPstrLOT_PRIORITY, .strLotPriority)               '優先度
                                Call ltMsg1.getString(CPstrWF_QUANTITY, .strWFQuantity)                 'WF枚数
                                Call ltMsg1.getString(CPstrCHIP_QUANTITY, .strChipQuantity)             'Chip枚数
                                Call ltMsg1.getString(CPstrSTAY_TIME, .strStayTime)                     '停滞期間
                                Call ltMsg1.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)              'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrREASON_CODE, .strReasonCode)                 '保留理由ｺｰﾄﾞ
                                Call ltMsg1.getString(CPstrREASON_NAME, .strReasonName)                 '保留理由名
                                Call ltMsg1.getString(CPstrCOMMENTS, .strLotComments)                   'ﾛｯﾄｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrEDIT_TIME, .strEditTime)                     '最終更新日時
                                Call ltMsg1.getString(CPstrHOLD_TIME, .strHoldTime)                     '保留発生日時
                                Call ltMsg1.getString(CPstrHOLD_STAY_DATE, .strHoldStayDate)            '保留期間
                                Call ltMsg1.getString(CPstrHOLD_TERM_DATE, .strHoldTermDate)            '保留期限
                                Call ltMsg1.getString(CPstrHOLD_EMP_ID, .strHoldEmpID)                  '保留担当者ID
                                Call ltMsg1.getString(CPstrHOLD_EMP_NAME, .strHoldEmpName)              '保留担当者名
                                Call ltMsg1.getString(CPstrENG_EMP_ID, .strEngEmpId)                    'ﾛｯﾄ担当者ID
                                Call ltMsg1.getString(CPstrENG_EMP_NAME, .strEngEmpName)                'ﾛｯﾄ担当者名
                                Call ltMsg1.getString(CPstrINV_COMMENTS, .strInvComments)               'SB連絡ｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrTO_CARRIER_ID1, .strToCarrierID1)            '分割/移載先ｷｬﾘｱID1
                                Call ltMsg1.getString(CPstrTO_CARRIER_ID2, .strToCarrierID2)            '分割/移載先ｷｬﾘｱID2
                                Call ltMsg1.getString(CPstrSEND_SB_ID, .strSendSBID)                    '送品先ｼｽﾃﾑﾌﾞﾛｯｸID
                                Call ltMsg1.getString(CPstrSEND_SB_NAME, .strSendSBName)                '送品先ｼｽﾃﾑﾌﾞﾛｯｸ名
                                Call ltMsg1.getString(CPstrLOST_CHIP_INFO, .strLostChipInfo)            '欠損ﾁｯﾌﾟ情報
                                Call ltMsg1.getString(CPstrDIVIDE_STATUS, .strDivideStatus)             '分割予約状態(0:未分割-移載/1:分割-移載中/2:分割-移載済)
                                Call ltMsg1.getString(CPstrWF_CARRY_FLAG, .strWfCarryFlag)              'WF移載ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrSLOT_SIZE, .strSlotSize)                     'ｽﾛｯﾄｻｲｽﾞ
                                Call ltMsg1.getString(CPstrSB_AREA, .strSbArea)                         'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
                                Call ltMsg1.getString(CPstrGRB_CLASS, .strGrbClass)                     'GRB区分
                            End With
                            
                            ltypInvAcptLotListAns.typLotList(llngCnt1) = typLotListTmp
                            '@ｶｳﾝﾀを+1する
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnInvAcptlotList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypInvAcptLotListReq.strMsgVer)

                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMasSppdentrylistSel
    '機　能：特殊工順取得処理
    '引　数：CMstrlot_sppdentrylistVer  ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：ltypEntryList()            ：種別ﾘｽﾄ
    '　　　：llngEntryListCnt           ：種別ｶｳﾝﾄ
    '戻り値：True:成功/False:失敗
    '作成日：2004/07/27 (Tue) 16:39:08 S.Deguchi
    '更新日：2004/07/27 (Tue) 16:39:08
    '備　考：
    Public Function pubblnLotSppdentrylist_Sel(ByVal CMstrlot_sppdentrylistVer As String, _
                                               ByVal lstrSBID As String, _
                                               ByRef ltypEntryList As List(Of EntryList), _
                                               ByRef llngEntryListCnt As Integer) As Boolean
                                         
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim laAry1              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt1            As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry

            If ltypEntryList Is Nothing Then
                ltypEntryList = New List (Of EntryList)
            End If

            '@初期設定
            pstrMessageName = "特殊工順情報取得"
            pubblnLotSppdentrylist_Sel = False
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@Msgﾊﾞｰｼﾞｮﾝ
            If CMstrlot_sppdentrylistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, CMstrlot_sppdentrylistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_sppdentrylist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrENTRY_LIST, laAry1)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    llngEntryListCnt = laAry1.Count
                    If llngEntryListCnt > 0 Then
                        Do While (ltypEntryList.Count < llngEntryListCnt)
                            ltypEntryList.Add(New EntryList)
                        Loop

                        Dim ltypEntryListTmp As EntryList = New EntryList

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt1 = 0
                        For Each ltMsg1 In laAry1
                            '@受信結果取得
                            With ltypEntryListTmp
                                Call ltMsg1.getString(CPstrENTRY_ID, .strEntryID)                'ｴﾝﾄﾘｰID
                                Call ltMsg1.getString(CPstrENTRY_NAME, .strEntryName)            'ｴﾝﾄﾘｰ名
                                Call ltMsg1.getString(CPstrENTRY_COMMENTS, .strEntryComments)    'ｴﾝﾄﾘｰ時ｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrAPPLY_TIME, .strEntryApplyTime)       '適用日時
                            End With

                            ltypEntryList(llngCnt1) = ltypEntryListTmp

                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnLotSppdentrylist_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, CMstrlot_sppdentrylistVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing

        End Try
    End Function

    '関数名：pubblnLotThrowrsv_Ins
    '機　能：ﾛｯﾄ投入予約
    '引　数：lstrlot_throwrsvVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotReserveIns  ：戻り取得情報
    '戻り値：True：成功、False：失敗
    '作成日：2004/07/29 (Thu) 14:41:10 N.Kojima
    '更新日：2008/06/10 (Tue) 11:04:01 N.Kojima
    '備　考：処理区分が「0M2Z」は品確/ﾀﾞﾐｰ/ﾓﾆﾀｰ品
    '　　　：2005/12/21 (Wed) 12:07:55 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(ﾕｰｻﾞｰ要望№0134)
    '　　　：2006/10/31 (Tue) 15:13:55 N.Kasai      応答ﾀｸﾞ追加(LOT_SEND_FLAG)
    '　　　：2008/06/10 (Tue) 11:04:01 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Public Function pubblnLotThrowrsv_Ins(ByVal lstrlot_throwrsvVer As String, _
                                          ByRef ltypLotReserveIns As LotReserve) As Boolean

        Dim lrMsg           As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg           As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET         As String           '応答取得

        Try

            pstrMessageName = "ロット投入予約"
            'pubblnL
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotReserveIns
                
                '@機種ID
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
                
                '@流動区分
                If .strFlowClass <> vbNullString Then
                    Call lrMsg.addString(CPstrFLOW_CLASS, .strFlowClass)
                Else
                    Call lrMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                End If
                
                '@WF枚数
                If .strWfNum <> vbNullString Then
                    Call lrMsg.addString(CPstrWF_NUM, .strWfNum)
                Else
                    Call lrMsg.addString(CPstrWF_NUM, CPstrMsgNull)
                End If
                
                '@投入予定日
                If .strPlanThrowinDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPLAN_THROWIN_DATE, .strPlanThrowinDate)
                Else
                    Call lrMsg.addString(CPstrPLAN_THROWIN_DATE, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ担当者ID
                If .strEngEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrENG_EMP_ID, .strEngEmpId)
                Else
                    Call lrMsg.addString(CPstrENG_EMP_ID, CPstrMsgNull)
                End If
                
                '@ｺﾋﾟｰ元LOTID
                If .strCopySeqLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrCOPY_SEQ_LOT_ID, .strCopySeqLotID)
                Else
                    Call lrMsg.addString(CPstrCOPY_SEQ_LOT_ID, CPstrMsgNull)
                End If
                
                '@工順ﾊﾞｰｼﾞｮﾝ
                If .strMasVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMAS_PD_VERSION, .strMasVer)
                Else
                    Call lrMsg.addString(CPstrMAS_PD_VERSION, CPstrMsgNull)
                End If
                
                '@分割元ﾛｯﾄID
                If .strDivideLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strDivideLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@ｺﾒﾝﾄ
                If .strComment <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComment)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@SBID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@P/Rｵｰﾀﾞｰ
                If .strPROrderID <> vbNullString Then
                    Call lrMsg.addString(CPstrPR_ORDER_ID, .strPROrderID)
                Else
                    Call lrMsg.addString(CPstrPR_ORDER_ID, CPstrMsgNull)
                End If
                
                '@送品ﾌﾗｸﾞ
                If .strLotSendFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_SEND_FLAG, .strLotSendFlag)
                Else
                    Call lrMsg.addString(CPstrLOT_SEND_FLAG, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrlot_throwrsvVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_throwrsvVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            End With

            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_throwrsv, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾃﾞｰﾀ格納
                    Call laMsg.getString(CPstrLOT_ID, ltypLotReserveIns.strLotID)   'ﾛｯﾄID
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotThrowrsv_Ins = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_throwrsvVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ型変数の初期化
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function


        Catch ex As Exception
            '@例外処理
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄ型変数の初期化
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotApprove_Ins
    '機　能：ﾛｯﾄ予約承認
    '引　数：lstrmas_pdlistVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypLotReserveIns：戻り取得情報
    '戻り値：True：正常、False：異常
    '作成日：2004/07/29 (Thu) 19:57:12 N.Kojima
    '更新日：2004/07/29 (Thu) 19:57:12
    '備　考：
    Public Function pubblnLotApprove_Ins(ByVal lstrlot_approve_Ver As String, _
                                         ByRef ltypLotReserveIns As LotReserve) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "ロット予約承認"
            pubblnLotApprove_Ins = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotReserveIns
            
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@SBID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrlot_approve_Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_approve_Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            End With
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_approve_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotApprove_Ins = True

                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_approve_Ver)
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ型変数の初期化
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function


        Catch ex As Exception
            '@例外処理
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄ型変数の初期化
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnCarrcurstate_Sel
    '機　能：ｷｬﾘｱ状態確認
    '引　数：ltypCarrCurstate   ：ｷｬﾘｱ状態確認構造体
    '　　　：lblnChkMode        ：True:空きｷｬﾘｱﾁｪｯｸ、False:空きｷｬﾘｱ以外ﾁｪｯｸ
    '　　　：lstrSlotSize       ：応答されたｽﾛｯﾄｻｲｽﾞを格納
    '戻り値：True：成功、False：失敗
    '作成日：2004/08/06 (Fri) 15:10:54 N.Kasai
    '更新日：2005/05/19 (Thu) 15:50:56 N.Kojima
    '備　考：
    '　　　：2004/08/27 (Fri) 14:18:08 N.Kasai      ｷｬﾘｱﾀｲﾌﾟ追加
    '　　　：2004/08/06 (Fri) 15:10:54 N.Kasai      ﾛｯﾄID追加
    '　　　：2005/05/19 (Thu) 15:50:56 N.Kojima     大工程ID、小工程ID、代替番号追加(作業開始時のみ指定)
    Public Function pubblnCarrcurstate_Sel(ByRef ltypCarrCurstate As CarrCurstate, _
                                           ByVal lblnChkMode As Boolean, _
                                           Optional ByRef lstrSlotSize As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "キャリア状態確認"
            pubblnCarrcurstate_Sel = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            
            With ltypCarrCurstate
                '@処理区分
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
            
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                
                '@ｷｬﾘｱﾀｲﾌﾟ
                If .strCarrierTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_TYPE_ID, .strCarrierTypeID)
                Else
                    Call lrMsg.addString(CPstrCARRIER_TYPE_ID, CPstrMsgNull)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
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
                
                '@代替番号
                If .strAltNumber <> vbNullString Then
                    Call lrMsg.addString(CPstrALT_NUMBER, .strAltNumber)
                Else
                    Call lrMsg.addString(CPstrALT_NUMBER, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrcarrcurstate, lrMsg, laMsg)
                
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
                
                '@ﾁｪｯｸﾓｰﾄﾞの判定
                If lblnChkMode = True Then
                    '@空きｷｬﾘｱﾁｪｯｸの場合(分割、不良/保留)
                    '@結果判定
                    Select Case lstrRET
                        '@成功の場合(true)
                        Case CPstrTRUE
                        
                            Call laMsg.getString(CPstrSLOT_SIZE, lstrSlotSize)             'ｽﾛｯﾄｻｲｽﾞ
                        
                            '@関数の処理結果(成功)格納
                            pubblnCarrcurstate_Sel = True
                            
                        '@失敗の場合(false)
                        Case CPstrFALSE
                            
                            '@ﾊﾞｰｼﾞｮﾝ判定
                            Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                                            
                        '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                        Case Else
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                            '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    End Select
                Else
                    '@空きｷｬﾘｱ以外ﾁｪｯｸの場合(統合)
                    '@結果判定
                    Select Case lstrRET
                        '@成功の場合(true)
                        Case CPstrTRUE
                            '@関数の処理結果(空きｷｬﾘｱ)格納
                            pubblnCarrcurstate_Sel = False
                            
                        '@失敗の場合(false)
                        Case CPstrFALSE
                            '@関数の処理結果(空きｷｬﾘｱ以外)格納
                            pubblnCarrcurstate_Sel = True
                            
                        '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                        Case Else
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                            '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    End Select
                End If
            
            End With

            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnEqState_Sel
    '機　能：装置状態取得
    '引　数：lstreq__state___Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrWP_ID          ：装置ID
    '　　　：ltypEqstate        ：装置状態取得構造体
    '戻り値：Ture:正常、False:異常
    '作成日：2004/06/21 (Mon) 15:53:38 N.Kasai
    '更新日：2018/07/30 (Mon) 18:40:06 Y.Yoneyama
    '備　考：
    '　　　：2004/08/30 (Mon) 14:31:19 N.Kojima　   応答に"用途(USAGE)"を追加(11454行目)。
    '　　　：2004/09/24 (Fri) 11:31:14 S.Deguchi    応答に装置状態のTagを追加
    '　　　：2004/10/15 (Fri) 12:05:36 K.Takano     応答にﾎﾟｰﾄ状態IDを追加
    '　　　：2004/12/15 (Wed) 15:30:29 S.Deguchi    自動搬送対応
    '　　　：2006/08/28 (Mon) 10:41:36 T.Kitagawa   応答に"COLLECT_TYPE_FLAG"(条件毎連続ﾀｲﾌﾟﾌﾗｸﾞ)を追加する(案件№01097)
    '　　　：2006/08/28 (Mon) 10:41:36 T.Kitagawa   応答に"RECIPE_FLOW_NUM"(条件毎連続処理数)を追加する(案件№01097)
    '　　　：2007/10/15 (Mon) 18:43:40 N.Kojima     応答に"COLLECT_TYPE_LIST"(ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾘｽﾄ)を追加。(案件№02152)
    '　　　：2018/07/30 (Mon) 18:40:06 Y.Yoneyama   防湿ALD対応
    Public Function pubblnEqState_Sel(ByVal lstreq__state___Ver As String, _
                                      ByVal lstrWP_ID As String, _
                                      ByRef ltypEqstate As Eqstate) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "装置状態取得"
            pubblnEqState_Sel = False
            
            'NSYS リスト初期化
            ltypEqstate = New Eqstate
            If ltypEqstate.typPortList Is Nothing Then
                ltypEqstate.typPortList = New List(Of eqPortList)
            End If
            If ltypEqstate.typCollectTypeList Is Nothing Then
                ltypEqstate.typCollectTypeList = New List(Of CollectTypeList)
            End If

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstreq__state___Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstreq__state___Ver)     'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrWP_ID <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWP_ID)                 '装置ID
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__state___, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            With ltypEqstate
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信結果取得
                        Call laMsg.getString(CPstrMES_MODE_ID, .strMesModeId)                       '運用ﾓｰﾄﾞ
                        Call laMsg.getString(CPstrRESEERVE_MES_MODE_ID, .strReseerveMesModeID)      '運用ﾓｰﾄﾞ予約状態
                        Call laMsg.getString(CPstrMODE_STATUS, .strModeStatus)                      'ﾓｰﾄﾞ状態
                        '@追加Tag
                        Call laMsg.getString(CPstrUSE_ID, .strUseId)                                '用途ID
                        Call laMsg.getString(CPstrUSE_NAME, .strUseName)                            '用途名
                        Call laMsg.getString(CPstrWP_TYPE_FLAG, .strWpTypeFlag)                     'WPﾀｲﾌﾟﾌﾗｸﾞ
                        Call laMsg.getString(CPstrWP_STOP_FLAG, .strWpStopFlag)                     'WP停止ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrWP_STATUS_NAME, .strWpStatusName)                 '装置状態名
                        Call laMsg.getString(CPstrMES_MODE_TYPE, .strMesModeType)                   '運用ﾓｰﾄﾞﾀｲﾌﾟ
                        Call laMsg.getString(CPstrCOLLECT_TYPE_FLAG, .strCollectTypeFlag)           '条件毎連続ﾀｲﾌﾟﾌﾗｸﾞ(0：指定不可装置、1：条件毎指定可能装置)
                        Call laMsg.getString(CPstrRECIPE_FLOW_NUM, .strRecipeFlowNum)               '条件毎連続処理数
                        Call laMsg.getString(CPstrWP_CANCEL_CARRIER_FLAG, .strWPCancelCarrierFlag)  'WPｷｬﾝｾﾙｷｬﾘｱﾌﾗｸﾞ
        '@↓2018/07/30 (Mon) 18:41:14 Y.Yoneyama **************************************************
                        Call laMsg.getString(CPstrMC_TYPE, .strMcType)                              '装置ﾀｲﾌﾟ
                        Call laMsg.getString(CPstrALD_PROCESS_MODE_ID, .strALDPorcessModeId)        '防湿ALD処理ﾓｰﾄﾞID
                        Call laMsg.getString(CPstrALD_PROCESS_NUM, .strALDProcessNum)               '防湿ALD処理番号
                        Call laMsg.getString(CPstrALD_PROCESS_NAME, .strALDProcessName)             '防湿ALD処理名
        '@↑2018/07/30 (Mon) 18:41:14 Y.Yoneyama **************************************************
                        
                        '@ｱﾚｰを格納
                        Call laMsg.getMsgAry(CPstrPORT_LIST, laAry)
                        
                        '@ﾘｽﾄｶｳﾝﾄ格納
                        .lngPortListCnt = laAry.Count
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngPortListCnt > 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            
                            '@配列の要素数を設定
                            Do While (.typPortList.Count < .lngPortListCnt)
                                .typPortList.Add(New eqPortList)
                            Loop
                            llngCnt = 0
                            
                            Dim typPortListTmp As eqPortList = New eqPortList

                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Call ltMsg.getString(CPstrPORT_ID, typPortListTmp.strPortID)                 'ﾎﾟｰﾄID
                                Call ltMsg.getString(CPstrPORT_STATUS, typPortListTmp.strPortStatus)         'ﾎﾟｰﾄ状態
                                Call ltMsg.getString(CPstrPORT_STATUS_ID, typPortListTmp.strPortStatusID)    'ﾎﾟｰﾄ状態ID
                                Call ltMsg.getString(CPstrCARRIER_ID, typPortListTmp.strCarrierId)           'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrLOT_ID, typPortListTmp.strLotID)                   'ﾛｯﾄID
                                Call ltMsg.getString(CPstrUSAGE, typPortListTmp.strUsage)                    '用途(ﾎﾟｰﾄ)
                                Call ltMsg.getString(CPstrTRANS_CARRIER, typPortListTmp.strTransCarrier)                         '搬送予定ｷｬﾘｱID
                                Call ltMsg.getString(CPstrTRANS_SERVICE_STATUS, typPortListTmp.strTransServiceStatus)            '自動搬送ｻｰﾋﾞｽ状態
                                Call ltMsg.getString(CPstrTRANS_SERVICE_STATUS_NAME, typPortListTmp.strTransServiceStatusName)   '自動搬送ｻｰﾋﾞｽ状態(和名)
                                
                                .typPortList(llngCnt) = typPortListTmp

                                llngCnt = llngCnt + 1
                            Next
                        End If
                        
                        '@ｱﾚｰを格納
                        Call laMsg.getMsgAry(CPstrCOLLECT_TYPE_LIST, laAry2)
                        
                        '@ﾘｽﾄｶｳﾝﾄ格納
                        .lngCollectTypeListCnt = laAry2.Count
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngCollectTypeListCnt > 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            
                            '@配列の要素数を設定
                            Do While (.typCollectTypeList.Count < .lngCollectTypeListCnt)
                                .typCollectTypeList.Add(New CollectTypeList)
                            Loop
                            llngCnt = 0
                            
                            Dim typCollectTypeListTmp As CollectTypeList = New CollectTypeList
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry2
                                Call ltMsg.getString(CPstrCOLLECT_TYPE_NAME, typCollectTypeListTmp.strCollectTypeName)       'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ名
                                Call ltMsg.getString(CPstrCOLLECT_TYPE_NUM, typCollectTypeListTmp.strCollectTypeNum)         'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ番号(ID)
                                Call ltMsg.getString(CPstrUSER_SELECT_FLAG, typCollectTypeListTmp.strUserSelectFlag)         '選択ﾚｼﾋﾟｸﾞﾙｰﾌﾟ

                                .typCollectTypeList(llngCnt) = typCollectTypeListTmp

                                llngCnt = llngCnt + 1
                            Next
                        End If
                        
                        '@関数の処理結果(成功)格納
                        pubblnEqState_Sel = True
                        
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, lstreq__state___Ver)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
            
                        '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
            End With
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
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
            laAry = Nothing
            laAry2 = Nothing

        End Try
    End Function

    '関数名：pubblnLotTravlist_Sel
    '機　能：工順元LOT一覧取得
    '引　数：lstrClassDivision  ：処理区分(02:全て、24：流動終了以外)
    '　　　：lstrlot_travlistVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrProductID      ：機種ID
    '　　　：lstrDivisionID     ：種別ID
    '　　　：lstrStartDate      ：開始日
    '　　　：lstrEndDate        ：終了日
    '　　　：ltypTypOpLotLst    ：ﾘｽﾄ構造体
    '　　　：llngOpLotLstCnt    ：データ数
    '戻り値：True：正常、False：異常
    '作成日：2004/02/23 (Mon) 10:22:46 M.Miura
    '更新日：2009/12/03 (Thu) 11:36:17 H.Hayashi
    '備　考：
    '　　　：2005/08/01 (Mon) 13:19:47 N.Kasai      応答ﾒｯｾｰｼﾞにLC_DIRECTION追加(L/R表示)
    '　　　：2009/03/02 (Mon) 09:15:53 N.Kojima     ﾁｯﾌﾟ品を判別する為、応答に"SEND_SB_ID"を追加。(案件№03402)
    '　　　：2009/12/03 (Thu) 11:36:17 H.Hayashi　  応答ﾀｸﾞに"SB_AREA"追加。(案件№03810)
    Public Function pubblnLotTravlist_Sel(ByVal lstrClassDivision As String, _
                                          ByVal lstrlot_travlistVer As String, _
                                          ByVal lstrProductID As String, _
                                          ByVal lstrDivisionID As String, _
                                          ByVal lstrStartDate As String, _
                                          ByVal lstrEndDate As String, _
                                          ByRef ltypTypOpLotLst As List(Of typOpLotLst), _
                                          ByRef llngOpLotLstCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用        

        Try

            '@初期設定
            pstrMessageName = "工順元Lot一覧取得"
            pubblnLotTravlist_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            'NSYS リスト初期化
            If ltypTypOpLotLst Is Nothing Then
                ltypTypOpLotLst = New List(Of typOpLotLst)
            End If

            '@***********************
            '@ 送信ﾒｯｾｰｼﾞ作成
            '@***********************
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@機種ID
            If lstrProductID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrProductID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            
            '@種別ID
            If lstrDivisionID <> vbNullString Then
                Call lrMsg.addString(CPstrFLOW_CLASS, lstrDivisionID)
            Else
                Call lrMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)
            End If
            
            '@開始日
            If lstrStartDate <> vbNullString Then
                Call lrMsg.addString(CPstrREF_START_DATE, lstrStartDate)
            Else
                Call lrMsg.addString(CPstrREF_START_DATE, CPstrMsgNull)
            End If
            
            '@終了日
            If lstrEndDate <> vbNullString Then
                Call lrMsg.addString(CPstrREF_END_DATE, lstrEndDate)
            Else
                Call lrMsg.addString(CPstrREF_END_DATE, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_travlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_travlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_travlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 結果判定 ★
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    llngOpLotLstCnt = laAry.Count
                    
                    If llngOpLotLstCnt > 0 Then
                        
                        Do While (ltypTypOpLotLst.Count < llngOpLotLstCnt)
                            ltypTypOpLotLst.Add(New typOpLotLst)
                        Loop

                        Dim ltypTypOpLotLstTmp As typOpLotLst = New typOpLotLst

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        
                        For Each ltMsg In laAry
                            '@受信結果取得
                            With ltypTypOpLotLstTmp
                                
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)
                                Call ltMsg.getString(CPstrLOT_FLOW_STATUS_ID, .strLotStatusFLG)
                                Call ltMsg.getString(CPstrPD_ID, .strProductID)
                                Call ltMsg.getString(CPstrPD_NAME, .strProduct)
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strDivisionID)
                                Call ltMsg.getString(CPstrFLOW_CLASS_NAME, .strDivision)
                                Call ltMsg.getString(CPstrTHROWIN_DATE, .strEntryDate)
                                Call ltMsg.getString(CPstrENTRY_ID, .strEntryID)
                                Call ltMsg.getString(CPstrENTRY_NAME, .strEntryName)
                                Call ltMsg.getString(CPstrENG_EMP_ID, .strEmpID)
                                Call ltMsg.getString(CPstrENG_EMP_NAME, .strTexhManNmae)
                                Call ltMsg.getString(CPstrLC_DIRECTION, .strLcDirection)
                                Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)                 '送品先
                                Call ltMsg.getString(CPstrSB_AREA, .strSbArea)                      'ｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱ(7：ﾁｯﾌﾟ品、NULL・7以外：ﾓｼﾞｭｰﾙ品)
                            End With

                            ltypTypOpLotLst(llngCnt) = ltypTypOpLotLstTmp

                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotTravlist_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_travlistVer)
                    
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnMasDeptEmpList_Sel
    '機　能：社員名取得
    '引　数：lstrMsgVer         ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrDeptID         ：部署ID
    '　　　：ltypDeptEmpList()  ：名格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/12 (Thu) 10:11:14 S.Deguchi
    '更新日：2005/05/07 (Sat) 10:49:41 N.Kasai
    '備　考：
    '　　　：2005/05/07 (Sat) 10:49:41 N.Kasai      応答msgにﾒｰﾙｱﾄﾞﾚｽ追加
    Public Function pubblnMasDeptEmpList_Sel(ByVal lstrMsgVer As String, _
                                             ByVal lstrDeptID As String, _
                                             ByRef ltypDeptEmpList As DeptEmpInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "社員名称取得"
            pubblnMasDeptEmpList_Sel = False
            
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            'NSYS リスト初期化
            ltypDeptEmpList = New DeptEmpInfo
            If ltypDeptEmpList.typDeptEmpList Is Nothing Then
                ltypDeptEmpList.typDeptEmpList = New List(Of DeptEmpList)
            End If

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)      'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrDeptID <> vbNullString Then
                Call lrMsg.addString(CPstrDEPT_CODE, lstrDeptID)       '部署
            Else
                Call lrMsg.addString(CPstrDEPT_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_deptemplist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrEMP_LIST, laAry)
                    
                    '@ﾘｽﾄｶｳﾝﾄ格納
                    ltypDeptEmpList.lngDeptEmpListCnt = laAry.Count
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypDeptEmpList.lngDeptEmpListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        Do While (ltypDeptEmpList.typDeptEmpList.Count < ltypDeptEmpList.lngDeptEmpListCnt)
                            ltypDeptEmpList.typDeptEmpList.Add(New DeptEmpList)
                        Loop

                        Dim typDeptEmpListTmp As DeptEmpList = New DeptEmpList

                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With typDeptEmpListTmp
                                Call ltMsg.getString(CPstrEMP_ID, .strEmpID)                '作業者ID
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)            '作業者名
                                Call ltMsg.getString(CPstrMAIL_ADDRESS, .strMailAddress)    'ﾒｰﾙｱﾄﾞﾚｽ
                            End With

                            ltypDeptEmpList.typDeptEmpList(llngCnt) = typDeptEmpListTmp

                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasDeptEmpList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnMasDepartmentList_Sel
    '機　能：部署名取得
    '引　数：lstrMsgVer             ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：ltypDepartmentlist()   ：部署名格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/12 (Thu) 10:11:14 S.Deguchi
    '更新日：2004/08/12 (Thu) 10:11:14
    '備　考：
    Public Function pubblnMasDepartmentList_Sel(ByVal lstrMsgVer As String, _
                                                ByRef ltypDepartmentList As DepartmentInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "部署名取得"
            pubblnMasDepartmentList_Sel = False
            
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            'NSYS リスト初期化
            ltypDepartmentList = New DepartmentInfo
            If ltypDepartmentList.typDepartmentList Is Nothing Then
                ltypDepartmentList.typDepartmentList = New List(Of DepartmentList)
            End If

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)      'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_departmentlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrDEPARTMENT_LIST, laAry)
                    
                    '@ﾘｽﾄｶｳﾝﾄ格納
                    ltypDepartmentList.lngDepartmentListCnt = laAry.Count
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypDepartmentList.lngDepartmentListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        Do While (ltypDepartmentList.typDepartmentList.Count < ltypDepartmentList.lngDepartmentListCnt)
                            ltypDepartmentList.typDepartmentList.Add(New DepartmentList)
                        Loop

                        Dim typDepartmentListTmp As DepartmentList = New DepartmentList

                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With typDepartmentListTmp
                                Call ltMsg.getString(CPstrDEPT_CODE, .strDeptCode)          '部署ID
                                Call ltMsg.getString(CPstrDEPT_NAME, .strDeptName)          '部署名
                            End With

                            ltypDepartmentList.typDepartmentList(llngCnt) = typDepartmentListTmp

                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasDepartmentList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnMasTroubleItemList_Sel
    '機　能：異常処理項目名取得
    '引　数：lstrMsgVer         ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrItemtype       ：取得ﾀｲﾌﾟ
    '　　　：ltypTroubleItemList：異常処置項目名取得ﾘｽﾄ
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/17 (Tue) 10:01:59 S.Deguchi
    '更新日：2004/08/17 (Tue) 10:01:59
    '備　考：
    Public Function pubblnMasTroubleItemList_Sel(ByVal lstrMsgVer As String, _
                                                 ByVal lstrItemType As String, _
                                                 ByRef ltypTroubleItemList As TroubleItemInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "異常処理項目名取得"
            pubblnMasTroubleItemList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            'NSYS リスト初期化
            ltypTroubleItemList = New TroubleItemInfo
            If ltypTroubleItemList.typTroubleItemList Is Nothing Then
                ltypTroubleItemList.typTroubleItemList = New List(Of TroubleItemList)
            End If

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrItemType <> vbNullString Then
                Call lrMsg.addString(CPstrITEM_TYPE, lstrItemType)      '項目ﾀｲﾌﾟ
            Else
                Call lrMsg.addString(CPstrITEM_TYPE, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_troubleitemlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrITEM_LIST, laAry)
                    
                    '@ﾘｽﾄｶｳﾝﾄ格納
                    ltypTroubleItemList.lngTroubleItemListCnt = laAry.Count
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypTroubleItemList.lngTroubleItemListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        Do While (ltypTroubleItemList.typTroubleItemList.Count < ltypTroubleItemList.lngTroubleItemListCnt)
                            ltypTroubleItemList.typTroubleItemList.Add(New TroubleItemList)
                        Loop

                        Dim typTroubleItemListTmp As TroubleItemList = New TroubleItemList

                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With typTroubleItemListTmp
                                Call ltMsg.getString(CPstrITEM_NAME, .strItemName)           '項目名
                            End With

                            ltypTroubleItemList.typTroubleItemList(llngCnt) = typTroubleItemListTmp

                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasTroubleItemList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnLotSimpliTrvlList_Sel
    '機　能：簡易ﾛｯﾄ流動履歴取得
    '引　数：pstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrMsgVer         ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：ltypSimpliTrvlList ：流動履歴構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/19 (Thu) 18:17:23 S.Deguchi
    '更新日：2004/08/19 (Thu) 18:17:23
    '備　考：
    Public Function pubblnLotSimpliTrvlList_Sel(ByVal pstrSBID As String, _
                                                ByVal lstrMsgVer As String, _
                                                ByVal lstrLotID As String, _
                                                ByRef ltypSimpliTrvlList As SimpliTrvlList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As String           'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "ロット流動履歴取得"
            pubblnLotSimpliTrvlList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            'NSYS リスト初期化
            If ltypSimpliTrvlList.typSimpliTrvlList Is Nothing Then
                ltypSimpliTrvlList.typSimpliTrvlList = New List(Of FlowRecord)
            End If

            '@送信ﾒｯｾｰｼﾞ作成
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)              'ｼｽﾃﾑﾌﾞﾛｯｸ
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)            'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_simplitrvllist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrTRAVELER_LIST, laAry)
                    
                    '@ﾘｽﾄｶｳﾝﾄ格納
                    ltypSimpliTrvlList.lngSimpliTrvlListCnt = laAry.Count
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypSimpliTrvlList.lngSimpliTrvlListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        Do While (ltypSimpliTrvlList.typSimpliTrvlList.Count < ltypSimpliTrvlList.lngSimpliTrvlListCnt)
                            ltypSimpliTrvlList.typSimpliTrvlList.Add(New FlowRecord)
                        Loop

                        Dim typSimpliTrvlListTmp As FlowRecord = New FlowRecord

                        llngCnt = 0
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With typSimpliTrvlListTmp
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程
                                Call ltMsg.getString(CPstrWP_ID, .strWpID)                                  'WP_ID
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)                              '装置名
                                Call ltMsg.getString(CPstrAREA_NAME, .strCauseSeriesName)                   '原因系列
                                Call ltMsg.getString(CPstrSTART_DEPT_NAME, .strStartWorkTeamName)           '開始作業者ﾁｰﾑ
                                Call ltMsg.getString(CPstrSTART_EMP_NAME, .strStartWorkEmpName)             '開始作業者
                                Call ltMsg.getString(CPstrEND_DEPT_NAME, .strEndWorkTeamName)               '終了作業者ﾁｰﾑ
                                Call ltMsg.getString(CPstrEND_EMP_NAME, .strEndWorkEmpName)                 '終了作業者
                            End With

                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt) = typSimpliTrvlListTmp

                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotSimpliTrvlList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '未使用機能NSYS↓
    ''関数名：pubblnExcpTroubleSheetInfo_Sel
    ''機　能：異常処理登録内容取得
    ''引　数：pstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    ''　　　：lstrMsgVer         ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    ''　　　：lstrExcpNo         ：異常処理№
    ''　　　：mtypChgTroubleList ：異常処理票内容構造体
    ''戻り値：True:成功/False:失敗
    ''作成日：2004/08/24 (Tue) 13:48:41 S.Deguchi
    ''更新日：2005/04/19 (Tue) 16:42:58 N.Kasai
    ''備　考：
    ''　　　：2005/03/14 (Mon) 10:28:27 S.Deguchi    更新者情報取得処理追加
    ''　　　：2005/04/19 (Tue) 16:42:58 N.Kasai      ﾕｰｻﾞ要望№39　項目の見直し
    'Public Function pubblnExcpTroubleSheetInfo_Sel(ByVal pstrSBID As String, _
    '                                               ByVal lstrMsgVer As String, _
    '                                               ByVal lstrExcpNo As String, _
    '                                               ByRef mtypChgTroubleList As ChgTroubleList) As Boolean

    '    Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
    '    Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
    '    Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
    '    Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
    '    Dim laAry1              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
    '    Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
    '    Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
    '    Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
    '    Dim lstrRET             As String           '応答取得
    '    Dim lstrErrMsg          As String           'ｴﾗｰ用
    '    Dim lstrMsg             As String           'ﾒｯｾｰｼﾞ内容格納
    '    Dim llngCnt             As Long             'ｶｳﾝﾄ用
    '    Dim llngCnt1            As Long             'ｶｳﾝﾄ用
    '    Dim llngCnt2            As Long             'ｶｳﾝﾄ用
    
    '    On Error GoTo Error_Handler
    
    '    pstrMessageName = "異常処理登録内容取得"
    '    pubblnExcpTroubleSheetInfo_Sel = False
    
    '    Set lrMsg = New TfMsg
    '    Set laMsg = New TfMsg
    '    Set ltMsg = New TfMsg
    '    Set laAry = New TfMsgAry
    '    Set ltMsg1 = New TfMsg
    '    Set laAry1 = New TfMsgAry
    '    Set ltMsg2 = New TfMsg
    '    Set laAry2 = New TfMsgAry
    
    '    '@送信ﾒｯｾｰｼﾞ作成
    '    If pstrSBID <> vbNullString Then
    '        Call lrMsg.addString(CPstrSB_ID, pstrSBID)              'ｼｽﾃﾑﾌﾞﾛｯｸ
    '    Else
    '        Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
    '    End If
    
    '    If lstrMsgVer <> vbNullString Then
    '        Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
    '    Else
    '        Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
    '    End If
    
    '    If lstrExcpNo <> vbNullString Then
    '        Call lrMsg.addString(CPstrEXCP_NO, lstrExcpNo)          '異常処理№
    '    Else
    '        Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
    '    End If
    
    '    '@ﾒｯｾｰｼﾞ送信
    '    Call pTerm.sendRequest(CPstrexcptroublesheetinfo, lrMsg, laMsg)
    
    '    '@受信結果取得
    '    Call laMsg.getString(CPstrRET, lstrRET)
    
    '    '@結果判定
    '    Select Case lstrRET
    '        '@成功の場合(true)
    '        Case CPstrTRUE
    '            '@受信結果格納
    '            With mtypChgTroubleList
    '                .strExcpNo = lstrExcpNo                                             '異常処理№
    '                Call laMsg.getString(CPstrFIND_DATE, .strFindDate)                  '発見日時
    '                Call laMsg.getString(CPstrFIND_DEPT_ID, .strFindDeptID)             '発見職場ID
    '                Call laMsg.getString(CPstrFIND_DEPT_NAME, .strFindDeptName)         '発見職場
    '                Call laMsg.getString(CPstrFIND_EMP_ID, .strFindEmpID)               '発見者ID
    '                Call laMsg.getString(CPstrFIND_EMP_NAME, .strFindEmpName)           '発見者
    '                Call laMsg.getString(CPstrFIND_TEL_NO, .strFindTelNo)               '発見者TelNo
    '                Call laMsg.getString(CPstrREWORK_FLAG, .strReworkFlag)              'ﾘﾜｰｸﾌﾗｸﾞ
    '                Call laMsg.getString(CPstrPRO_EXCP_NAME, .strProExcpName)           '工程異常項目名
    '                Call laMsg.getString(CPstrEXCP_SEQ_FLAG, .strExcpSeqFlag)           '工程異常ﾌﾗｸﾞ
    '                Call laMsg.getString(CPstrEXCP_SEQ_OTHR, .strExcpSeqOthr)           '工程異常その他内容
                
    '                '@ｱﾚｲを初期化
    '                laAry.Clear
                
    '                '@ｱﾚｲを格納
    '                Call laMsg.getMsgAry(CPstrPD_ID_LIST, laAry)                        '機種
                
    '                '@ﾘｽﾄｶｳﾝﾄ格納
    '                .lngPDIDListCnt = laAry.Count
            
    '                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
    '                If .lngPDIDListCnt > 0 Then
    '                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    
    '                    '@配列の要素数を設定
    '                    ReDim Preserve .typPdList(.lngPDIDListCnt)
    '                    llngCnt = 1
    '                    '@ｱﾚｰの各要素取得
    '                    For Each ltMsg In laAry
    '                        With .typPdList(llngCnt)
    '                            Call ltMsg.getString(CPstrPD_ID, .strPdId)              '機種ID
    '                        End With
    '                        llngCnt = llngCnt + 1
    '                    Next
    '                End If
                
    '                '@ｱﾚｲを初期化
    '                laAry1.Clear
                
    '                '@ｱﾚｲを格納
    '                Call laMsg.getMsgAry(CPstrLOT_LIST, laAry1)                         'ﾛｯﾄﾘｽﾄ(原因)
                
    '                '@ﾘｽﾄｶｳﾝﾄ格納
    '                .lngCauseLotListCnt = laAry1.Count
            
    '                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
    '                If .lngCauseLotListCnt > 0 Then
    '                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    
    '                    '@配列の要素数を設定
    '                    ReDim Preserve .typCauseLotList(.lngCauseLotListCnt)
    '                    llngCnt1 = 1
    '                    '@ｱﾚｰの各要素取得
    '                    For Each ltMsg1 In laAry1
    '                        With .typCauseLotList(llngCnt1)
    '                            Call ltMsg1.getString(CPstrLOT_ID, .strLotID)                                   'ﾛｯﾄID
    '                            Call ltMsg1.getString(CPstrOBJ_WAFER, .strObjWafer)                             '対象ｳｪﾊ
    '                            Call ltMsg1.getString(CPstrWF_RESERVE_QUANTITY, .strWFReserveQuantity)          '保留枚数
    '                            Call ltMsg1.getString(CPstrWF_ABANDON_QUANTITY, .strWFAbandonQuantity)          '廃却枚数
    '                            Call ltMsg1.getString(CPstrWF_AMEND_QUANTITY, .strWFAmendQuantity)              '手直し流動枚数
    '                            Call ltMsg1.getString(CPstrWF_CORRECT_QUANTITY, .strWFCorrectQuantity)          '矯正流動枚数
    '                            Call ltMsg1.getString(CPstrWF_USUAL_QUANTITY, .strWFUsualQuantity)              '通常流動枚数
    '                            Call ltMsg1.getString(CPstrWF_EVAL_QUANTITY, .strWFEvalQuantity)                '評価流動枚数
    '                            Call ltMsg1.getString(CPstrWF_TAKE_QUANTITY, .strWFTakeQuantity)                '特採流動枚数
    '                            Call ltMsg1.getString(CPstrDISPOSAL_FLAG, .strDisposalFlag)                     '処置ﾌﾗｸﾞ
    '                            Call ltMsg1.getString(CPstrCAUSE_OP_ID_NAME, .strCauseOpIDName)                 '原因大工程
    '                            Call ltMsg1.getString(CPstrCAUSE_STEP_ID_NAME, .strCauseStepIDName)             '原因小工程
    '                            Call ltMsg1.getString(CPstrCAUSE_WP_NAME, .strCauseWpName)                      '原因装置名
    '                            Call ltMsg1.getString(CPstrCAUSE_SERIES_NAME, .strCauseSeriesName)              '原因系列名
    '                            Call ltMsg1.getString(CPstrCAUSE_CLASS_NAME, .strCauseClassName)                '原因区分名
    '                            Call ltMsg1.getString(CPstrCAUSE_COMMENTS, .strCauseComments)                   '原因ｺﾒﾝﾄ
    '                            Call ltMsg1.getString(CPstrSTART_WORK_EMP_NAME, .strStartWorkEmpName)           '作業開始名
    '                            Call ltMsg1.getString(CPstrSTART_WORK_TEAM_NAME, .strStartWorkTeamName)         '作業開始ﾁｰﾑ
    '                            Call ltMsg1.getString(CPstrEND_WORK_EMP_NAME, .strEndWorkEmpName)               '作業終了名
    '                            Call ltMsg1.getString(CPstrEND_WORK_TEAM_NAME, .strEndWorkTeamName)             '作業終了ﾁｰﾑ
                            
    '                            '@ｱﾚｲを初期化
    '                            laAry2.Clear
                            
    '                            '@ｱﾚｲを格納
    '                            Call ltMsg1.getMsgAry(CPstrWF_LIST, laAry2)
                            
    '                            '@ﾘｽﾄｶｳﾝﾄ格納
    '                            .lngWfListCnt = laAry2.Count
                            
    '                            If .lngWfListCnt > 0 Then
    '                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                
    '                                '@配列の要素数を設定
    '                                ReDim Preserve .typWFCauseList(.lngWfListCnt)
    '                                llngCnt2 = 1
    '                                '@ｱﾚｰの各要素取得
    '                                For Each ltMsg2 In laAry2
    '                                    Call ltMsg2.getString(CPstrSLOT_POSITION, .typWFCauseList(llngCnt2).strSlotPosition)    'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
    '                                    Call ltMsg2.getString(CPstrWF_ID, .typWFCauseList(llngCnt2).strWfId)                    'WFID
    '                                    Call ltMsg2.getString(CPstrEXCP_ITEM_NAME, .typWFCauseList(llngCnt2).strExcpItemName)   '異常特性
    '                                    Call ltMsg2.getString(CPstrWF_DISPO_NAME, .typWFCauseList(llngCnt2).strWFDispoName)     'WF処置名
                                    
    '                                    llngCnt2 = llngCnt2 + 1
    '                                Next
    '                            End If
    '                        End With
    '                        llngCnt1 = llngCnt1 + 1
    '                    Next
    '                End If

    '                Call laMsg.getString(CPstrNUM, .strNum)                                         '数量
    '                Call laMsg.getString(CPstrUNIT, .strUnit)                                       '単位
    '                Call laMsg.getString(CPstrFIND_OP_ID_NAME, .strFindOpIDName)                    '発見大工程
    '                Call laMsg.getString(CPstrFIND_STEP_ID_NAME, .strFindStepIDName)                '発見小工程
    '                Call laMsg.getString(CPstrFIND_WP_ID, .strFindWpID)                             '発見装置ID
    '                Call laMsg.getString(CPstrFIND_WP_NAME, .strFindWpName)                         '発見装置名
    '                Call laMsg.getString(CPstrSITUATION_COMMENTS, .strSituationComments)            '工程異常発生状況ｺﾒﾝﾄ
    '                Call laMsg.getString(CPstrINCONGRUENT_FLAG, .strInconguentFlag)                 '不適合品発生有無
    '                Call laMsg.getString(CPstrEVALUATION_COMMENTS, .strEvalutionComments)           '異常内容評価ｺﾒﾝﾝﾄ
    '                Call laMsg.getString(CPstrREQUEST_DEPT_ID, .strRequestDeptID)                   '依頼者所属ID
    '                Call laMsg.getString(CPstrREQUEST_DEPT_NAME, .strRequestDeptName)               '依頼者所属名
    '                Call laMsg.getString(CPstrREQUEST_EMP_ID, .strRequestEmpID)                     '依頼者氏名ID
    '                Call laMsg.getString(CPstrREQUEST_EMP_NAME, .strRequestEmpName)                 '依頼者氏名
    '                Call laMsg.getString(CPstrREQUEST_TEL_NO, .strRequestTelNo)                     '依頼者電話番号
    '                Call laMsg.getString(CPstrTRUST_OP_ID, .strTrustOpID)                           '依頼先大工程
    '                Call laMsg.getString(CPstrTRUST_STEP_ID, .strTrustStepID)                       '依頼先小工程
    '                Call laMsg.getString(CPstrTRUST_DEPT_ID, .strTrustDeptID)                       '依頼先所属ID
    '                Call laMsg.getString(CPstrTRUST_DEPT_NAME, .strTrustDeptName)                   '依頼先所属名
    '                Call laMsg.getString(CPstrTRUST_EMP_ID, .strTrustEmpID)                         '依頼先氏名ID
    '                Call laMsg.getString(CPstrTRUST_EMP_NAME, .strTrustEmpName)                     '依頼先氏名
    '                Call laMsg.getString(CPstrPROC_INFL_FLAG, .strProcInflFlag)                     '後工程影響
    '                Call laMsg.getString(CPstrRELI_INFL_FLAG, .strReliInflFlag)                     '信頼性影響
    '                Call laMsg.getString(CPstrDISPO_DIRCT_DEPT_NAME, .strDispoDirectDeptName)       '処置指示部署名
    '                Call laMsg.getString(CPstrINFL_CHCK_DEPT_NAME, .strInflChckDeptName)            '影響度確認部署名
    '                Call laMsg.getString(CPstrDIRCT_CONTENTS, .strDirctContents)                    '指示内容
    '                Call laMsg.getString(CPstrDIRCT_INPUT_DATE, .strDirctInputDate)                 '指示内容入力日時
    '                Call laMsg.getString(CPstrDIRCT_INPUT_EMP_NAME, .strDirctInputEmpName)          '指示内容入力者名
            
    '                Call laMsg.getString(CPstrTECH_INVEST_DATE, .strTechInvestDate)                 '技術部門調査日時
    '                Call laMsg.getString(CPstrTECH_INVEST_EMP_NAME, .strTechInvestEmpName)          '技術部門調査氏名
    '                Call laMsg.getString(CPstrMANU_INVEST_CAUSE, .strManuInvestCause)               '製造部門調査原因
    '                Call laMsg.getString(CPstrMANU_INVEST_DATE, .strManuInvestDate)                 '製造部門調査日時
    '                Call laMsg.getString(CPstrMANU_INVEST_EMP_NAME, .strManuInvestEmpName)          '製造部門調査氏名
    '                Call laMsg.getString(CPstrOTER_INVEST_CAUSE, .strOthrInvestCause)               'その他部門調査原因
    '                Call laMsg.getString(CPstrOTER_INVEST_DATE, .strOthrInvestDate)                 'その他部門調査日時
    '                Call laMsg.getString(CPstrOTER_INVEST_EMP_NAME, .strOthrInvestEmpName)          'その他部門調査氏名
    '                Call laMsg.getString(CPstrPROV_DIRCT_CONTENTS, .strProvDirctContets)            '暫定対策指示内容
    '                Call laMsg.getString(CPstrPROV_DIRCT_LIST_NAME, .strProvDirctListName)          '指示帳票名
    '                Call laMsg.getString(CPstrPROV_DIRCT_DEPT_NAME, .strProvDirctDeptName)          '指示部署名
    '                Call laMsg.getString(CPstrPROV_DIRCT_INPUT_DATE, .strProvDirctInputDate)        '指示内容入力日時
    '                Call laMsg.getString(CPstrPROV_DIRCT_INPUT_EMP_NAME, .strProvDirctInputEmpName) '指示内容入力者名
    '                Call laMsg.getString(CPstrAPPLY_FLAG, .strApplyFlag)                            '適用ﾌﾗｸﾞ
    
    '                Call laMsg.getString(CPstrEMP_ID, .strEmpID)                                    '更新者ID
    '                Call laMsg.getString(CPstrEMP_NAME, .strEmpName)                                '更新者名
    '                Call laMsg.getString(CPstrEDIT_TIME, .strEditTime)                              '更新日時
    '            End With
            
    '            '@関数の処理結果(成功)格納
    '            pubblnExcpTroubleSheetInfo_Sel = True
            
    '        '@失敗の場合(false)
    '        Case CPstrFALSE
            
    '            '@ﾊﾞｰｼﾞｮﾝ判定
    '            Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
            
    '        '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
    '        Case Else
    '            '@表示ﾒｯｾｰｼﾞ変換
    '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)

    '            '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
    '            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
    
    '    End Select

    '    '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
    '    Set lrMsg = Nothing
    '    Set laMsg = Nothing
    '    Set ltMsg = Nothing
    '    Set laAry = Nothing
    '    Set ltMsg1 = Nothing
    '    Set laAry1 = Nothing
    '    Set ltMsg2 = Nothing
    '    Set laAry2 = Nothing

    '    Exit Function
                                              
    ''@例外処理
    'Error_Handler:

    '    '@表示ﾒｯｾｰｼﾞ変換
    '    Call pubErrMsg_Proc(Err)
    
    '    '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
    '    Set lrMsg = Nothing
    '    Set laMsg = Nothing
    '    Set ltMsg = Nothing
    '    Set laAry = Nothing
    '    Set ltMsg1 = Nothing
    '    Set laAry1 = Nothing
    '    Set ltMsg2 = Nothing
    '    Set laAry2 = Nothing

    'End Function
    '未使用機能NSYS↑

    '関数名：pubblnExcpWKReportInfo_Sel
    '機　能：作業ﾐｽ報告書内容取得
    '引　数：lstrMsgVer             ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrExcpNo             ：異常処理№
    '　　　：mtypExcpWKReportList   ：作業ﾐｽ報告書格納構造体
    '　　　：lstrResultFlag         ：結果格納
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/26 (Thu) 09:43:41 S.Deguchi
    '更新日：2004/08/26 (Thu) 09:43:41
    '備　考：
    '　　　：2004/11/04 (Thu) 17:12:48 S.Deguchi    結果格納ﾌﾗｸﾞを追加して受信結果を格納する処理を追加
    Public Function pubblnExcpWKReportInfo_Sel(ByVal lstrMsgVer As String, _
                                               ByVal lstrSBID As String, _
                                               ByVal lstrExcpNo As String, _
                                               ByRef mtypExcpWKReportList As ExcpWKReportList, _
                                               ByRef lstrResultFlag As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim lstrResult          As String           '結果判定
        
        Try
            
            pstrMessageName = "作業ﾐｽ報告書取得"
            pubblnExcpWKReportInfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)              'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
                    
            If lstrExcpNo <> vbNullString Then
                Call lrMsg.addString(CPstrEXCP_NO, lstrExcpNo)          '異常処理№
            Else
                Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
            End If
                    
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpwkreportinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@結果判定
                    Call laMsg.getString(CPstrRESULT, lstrResult)                           '結果格納
                    If lstrResult <> "1" Then
                        lstrResultFlag = vbNullString         '結果判定ﾌﾗｸﾞ
                    
                        '@受信結果格納
                        With mtypExcpWKReportList
                            '@異常処理№を格納
                            .strExcpNo = lstrExcpNo
                            
                            Call laMsg.getString(CPstrGEN_DATE, .strGenDate)                    '発生日時
                            Call laMsg.getString(CPstrGEN_EMP_NAME, .strGenEmpName)             '発生者
                            Call laMsg.getString(CPstrGEN_DEPT_NAME, .strGenDeptName)           '発生職場
                            Call laMsg.getString(CPstrFIND_EMP_NAME, .strFindEmpName)           '発見者
                            Call laMsg.getString(CPstrMANU_EXP_YEAR, .strManuExpYear)           '製造経験年数
                            Call laMsg.getString(CPstrMANU_EXP_MON, .strManuExpMon)             '製造経験月数
                            Call laMsg.getString(CPstrEMP_FLAG, .strEmpFlag)                    '社員区分
                            Call laMsg.getString(CPstrPROC_EXP_YEAR, .strProcExpYear)           '該当工程経験年数
                            Call laMsg.getString(CPstrPROC_EXP_MON, .strProcExpMon)             '該当工程経験月数
                            Call laMsg.getString(CPstrWF_NO_COMMENTS, .strWfNoComments)         'wfNoｺﾒﾝﾄ
                            Call laMsg.getString(CPstrGEN_COMMENTS, .strGenComments)            '発生状況ｺﾒﾝﾄ
                            Call laMsg.getString(CPstrCLASS, .strClass)                         '区分
                            
                            Call laMsg.getString(CPstrSTRD_FLAG, .strStrdFlag)                  '標準麺関連ﾌﾗｸﾞ
                            Call laMsg.getString(CPstrSTRD_CAUSE, .strStrdCause)                '標準麺関連原因
                            Call laMsg.getString(CPstrSTRD_MEASURE, .strStrdMeasure)            '標準麺関連対策
                            Call laMsg.getString(CPstrSTRD_INPUT_DATE, .strStrdInputDate)       '標準麺関連日付
                            
                            Call laMsg.getString(CPstrEDU_FLAG, .strEduFlag)                    '教育麺関連ﾌﾗｸﾞ
                            Call laMsg.getString(CPstrEDU_CAUSE, .strEduCause)                  '教育麺関連原因
                            Call laMsg.getString(CPstrEDU_MEASURE, .strEduMeasure)              '教育麺関連対策
                            Call laMsg.getString(CPstrEDU_INPUT_DATE, .strEduInputDate)         '教育麺関連日付
                            
                            Call laMsg.getString(CPstrHIM_FLAG, .strHimFlag)                    '人麺関連ﾌﾗｸﾞ
                            Call laMsg.getString(CPstrHIM_CAUSE, .strHimCause)                  '人麺関連原因
                            Call laMsg.getString(CPstrHIM_MEASURE, .strHimMeasure)              '人麺関連対策
                            Call laMsg.getString(CPstrHIM_INPUT_DATE, .strHimInputDate)         '人麺関連日付
                            
                            Call laMsg.getString(CPstrEQP_FLAG, .strEqpFlag)                    '装置麺関連ﾌﾗｸﾞ
                            Call laMsg.getString(CPstrEQP_CAUSE, .strEqpCause)                  '装置麺関連原因
                            Call laMsg.getString(CPstrEQP_MEASURE, .strEqpMeasure)              '装置麺関連対策
                            Call laMsg.getString(CPstrEQP_INPUT_DATE, .strEqpInputDate)         '装置麺関連日付
                            
                            Call laMsg.getString(CPstrREPRO_PRICE, .strReproPrice)              '再生金額単価
                            Call laMsg.getString(CPstrREPRO_QUANTITY, .strReproQuantity)        '再生金額数量
                            
                            Call laMsg.getString(CPstrDEFECT_PRICE, .strDefectPrice)            '不良金額単価
                            Call laMsg.getString(CPstrDEFECT_QUANTITY, .strDefectQuantity)      '不良金額数量
                            
                            Call laMsg.getString(CPstrFOREMAN_COMMENTS, .strForemanComments)    '作業長ｺﾒﾝﾄ
                            Call laMsg.getString(CPstrCHIEF_COMMENTS, .strChiefComments)        '課長ｺﾒﾝﾄ
                            
                        End With
                    Else
                        lstrResultFlag = lstrResult         '結果判定ﾌﾗｸﾞ
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnExcpWKReportInfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnExcpChgWKReport_Ins
    '機　能：作業ﾐｽ報告書内容登録/更新
    '引　数：lstrMsgVer             ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：mtypExcpWKReportList   ：作業ﾐｽ報告書格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/26 (Thu) 10:02:51 S.Deguchi
    '更新日：2004/08/26 (Thu) 10:02:51
    '備　考：
    Public Function pubblnExcpChgWKReport_Ins(ByVal lstrMsgVer As String, _
                                              ByVal lstrSBID As String, _
                                              ByRef mtypExcpWKReportList As ExcpWKReportList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "作業ﾐｽ報告書登録"
            pubblnExcpChgWKReport_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)              'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            With mtypExcpWKReportList
                If .strExcpNo <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_NO, .strExcpNo)                      '異常処理№
                Else
                    Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
                End If
                
                If .strGenDate <> vbNullString Then
                    Call lrMsg.addString(CPstrGEN_DATE, .strGenDate)                    '発生日時
                Else
                    Call lrMsg.addString(CPstrGEN_DATE, CPstrMsgNull)
                End If
                      
                If .strGenEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrGEN_EMP_NAME, .strGenEmpName)             '発生者
                Else
                    Call lrMsg.addString(CPstrGEN_EMP_NAME, CPstrMsgNull)
                End If
                      
                If .strGenDeptName <> vbNullString Then
                    Call lrMsg.addString(CPstrGEN_DEPT_NAME, .strGenDeptName)           '発生職場
                Else
                    Call lrMsg.addString(CPstrGEN_DEPT_NAME, CPstrMsgNull)
                End If
                      
                If .strFindEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_EMP_NAME, .strFindEmpName)           '発見者
                Else
                    Call lrMsg.addString(CPstrFIND_EMP_NAME, CPstrMsgNull)
                End If
            
                If .strManuExpYear <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_EXP_YEAR, .strManuExpYear)           '製造経験年数
                Else
                    Call lrMsg.addString(CPstrMANU_EXP_YEAR, CPstrMsgNull)
                End If
            
                If .strManuExpMon <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_EXP_MON, .strManuExpMon)             '製造経験月数
                Else
                    Call lrMsg.addString(CPstrMANU_EXP_MON, CPstrMsgNull)
                End If
            
                If .strEmpFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_FLAG, .strEmpFlag)                    '社員区分
                Else
                    Call lrMsg.addString(CPstrEMP_FLAG, CPstrMsgNull)
                End If
            
                If .strProcExpYear <> vbNullString Then
                    Call lrMsg.addString(CPstrPROC_EXP_YEAR, .strProcExpYear)           '該当工程経験年数
                Else
                    Call lrMsg.addString(CPstrPROC_EXP_YEAR, CPstrMsgNull)
                End If
            
                If .strProcExpMon <> vbNullString Then
                    Call lrMsg.addString(CPstrPROC_EXP_MON, .strProcExpMon)             '該当工程経験月数
                Else
                    Call lrMsg.addString(CPstrPROC_EXP_MON, CPstrMsgNull)
                End If
            
                If .strWfNoComments <> vbNullString Then
                    Call lrMsg.addString(CPstrWF_NO_COMMENTS, .strWfNoComments)         'wfNoｺﾒﾝﾄ
                Else
                    Call lrMsg.addString(CPstrWF_NO_COMMENTS, CPstrMsgNull)
                End If
            
                If .strGenComments <> vbNullString Then
                    Call lrMsg.addString(CPstrGEN_COMMENTS, .strGenComments)            '発生ｺﾒﾝﾄ
                Else
                    Call lrMsg.addString(CPstrGEN_COMMENTS, CPstrMsgNull)
                End If
            
                If .strClass <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS, .strClass)                         '区分
                Else
                    Call lrMsg.addString(CPstrCLASS, CPstrMsgNull)
                End If
            
                If .strStrdFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrSTRD_FLAG, .strStrdFlag)                  '標準面関連ﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrSTRD_FLAG, CPstrMsgNull)
                End If
            
                If .strStrdCause <> vbNullString Then
                    Call lrMsg.addString(CPstrSTRD_CAUSE, .strStrdCause)                '標準面原因
                Else
                    Call lrMsg.addString(CPstrSTRD_CAUSE, CPstrMsgNull)
                End If
            
                If .strStrdMeasure <> vbNullString Then
                    Call lrMsg.addString(CPstrSTRD_MEASURE, .strStrdMeasure)            '標準面対策
                Else
                    Call lrMsg.addString(CPstrSTRD_MEASURE, CPstrMsgNull)
                End If
            
                If .strStrdInputDate <> vbNullString Then
                    Call lrMsg.addString(CPstrSTRD_INPUT_DATE, .strStrdInputDate)       '標準面日付
                Else
                    Call lrMsg.addString(CPstrSTRD_INPUT_DATE, CPstrMsgNull)
                End If
            
                If .strEduFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrEDU_FLAG, .strEduFlag)                    '教育面関連ﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrEDU_FLAG, CPstrMsgNull)
                End If
            
                If .strEduCause <> vbNullString Then
                    Call lrMsg.addString(CPstrEDU_CAUSE, .strEduCause)                  '教育面原因
                Else
                    Call lrMsg.addString(CPstrEDU_CAUSE, CPstrMsgNull)
                End If
            
                If .strEduMeasure <> vbNullString Then
                    Call lrMsg.addString(CPstrEDU_MEASURE, .strEduMeasure)              '教育面対策
                Else
                    Call lrMsg.addString(CPstrEDU_MEASURE, CPstrMsgNull)
                End If
            
                If .strEduInputDate <> vbNullString Then
                    Call lrMsg.addString(CPstrEDU_INPUT_DATE, .strEduInputDate)         '教育面日付
                Else
                    Call lrMsg.addString(CPstrEDU_INPUT_DATE, CPstrMsgNull)
                End If
            
                If .strHimFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrHIM_FLAG, .strHimFlag)                    '人面関連ﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrHIM_FLAG, CPstrMsgNull)
                End If
            
                If .strHimCause <> vbNullString Then
                    Call lrMsg.addString(CPstrHIM_CAUSE, .strHimCause)                  '人面原因
                Else
                    Call lrMsg.addString(CPstrHIM_CAUSE, CPstrMsgNull)
                End If
            
                If .strHimMeasure <> vbNullString Then
                    Call lrMsg.addString(CPstrHIM_MEASURE, .strHimMeasure)              '人面対策
                Else
                    Call lrMsg.addString(CPstrHIM_MEASURE, CPstrMsgNull)
                End If
            
                If .strHimInputDate <> vbNullString Then
                    Call lrMsg.addString(CPstrHIM_INPUT_DATE, .strHimInputDate)         '人面日付
                Else
                    Call lrMsg.addString(CPstrHIM_INPUT_DATE, CPstrMsgNull)
                End If
            
                If .strEqpFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrEQP_FLAG, .strEqpFlag)                    '装置面関連ﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrEQP_FLAG, CPstrMsgNull)
                End If
            
                If .strEqpCause <> vbNullString Then
                    Call lrMsg.addString(CPstrEQP_CAUSE, .strEqpCause)                  '装置面原因
                Else
                    Call lrMsg.addString(CPstrEQP_CAUSE, CPstrMsgNull)
                End If
            
                If .strEqpMeasure <> vbNullString Then
                    Call lrMsg.addString(CPstrEQP_MEASURE, .strEqpMeasure)              '装置面対策
                Else
                    Call lrMsg.addString(CPstrEQP_MEASURE, CPstrMsgNull)
                End If
            
                If .strEqpInputDate <> vbNullString Then
                    Call lrMsg.addString(CPstrEQP_INPUT_DATE, .strEqpInputDate)         '装置面日付
                Else
                    Call lrMsg.addString(CPstrEQP_INPUT_DATE, CPstrMsgNull)
                End If
            
                If .strReproPrice <> vbNullString Then
                    Call lrMsg.addString(CPstrREPRO_PRICE, .strReproPrice)              '再生単価
                Else
                    Call lrMsg.addString(CPstrREPRO_PRICE, CPstrMsgNull)
                End If
            
                If .strReproQuantity <> vbNullString Then
                    Call lrMsg.addString(CPstrREPRO_QUANTITY, .strReproQuantity)        '再生数量
                Else
                    Call lrMsg.addString(CPstrREPRO_QUANTITY, CPstrMsgNull)
                End If
            
                If .strDefectPrice <> vbNullString Then
                    Call lrMsg.addString(CPstrDEFECT_PRICE, .strDefectPrice)            '不良単価
                Else
                    Call lrMsg.addString(CPstrDEFECT_PRICE, CPstrMsgNull)
                End If
            
                If .strDefectQuantity <> vbNullString Then
                    Call lrMsg.addString(CPstrDEFECT_QUANTITY, .strDefectQuantity)      '不良数量
                Else
                    Call lrMsg.addString(CPstrDEFECT_QUANTITY, CPstrMsgNull)
                End If
            
                If .strForemanComments <> vbNullString Then
                    Call lrMsg.addString(CPstrFOREMAN_COMMENTS, .strForemanComments)    '作業長ｺﾒﾝﾄ
                Else
                    Call lrMsg.addString(CPstrFOREMAN_COMMENTS, CPstrMsgNull)
                End If
            
                If .strChiefComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCHIEF_COMMENTS, .strChiefComments)        '課長ｺﾒﾝﾄ
                Else
                    Call lrMsg.addString(CPstrCHIEF_COMMENTS, CPstrMsgNull)
                End If
            
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpchgwkreport, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnExcpChgWKReport_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnMasUseOpList_Sel
    '機　能：大工程ﾏｽﾀ取得
    '引　数：lstrSBID：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrmas_useoplistVer   ：MSGﾊﾞｰｼﾞｮﾝ
    '　　　：lstrClassDivision      ：処理区分(02:全て、2M:ｶﾃｺﾞﾘID指定、28:大工程ID指定)
    '　　　：ltypMasOpList          ：格納ﾃﾞｰﾀ
    '　　　：lstrOpID               ：大工程ID
    '　　　：lstrCategoryId         ：ｶﾃｺﾞﾘID
    '戻り値：True：正常、False：異常
    '作成日：2004/09/09 (Thu) 20:15:33 T.Kitagawa
    '更新日：2004/09/09 (Thu) 20:15:33
    '備　考：2004/09/22 (Wed) 18:13:10 S.Deguchi    不具合改善対応№875でMG00W0から移動
    '　　　：2005/07/20 (Wed) 13:48:40 S.Deguchi    有効ﾌﾗｸﾞを追加
    Public Function pubblnMasUseOpList_Sel(ByVal lstrSBID As String, _
                                           ByVal lstrmas_useoplistVer As String, _
                                           ByVal lstrClassDivision As String, _
                                           ByRef ltypMasOpList As MasOpList, _
                                           Optional ByVal lstrOpID As String = vbNullString, _
                                           Optional ByVal lstrCategoryId As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "大工程マスタ取得"
            pubblnMasUseOpList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            'NSYS リスト初期化
            If ltypMasOpList.typMasOpId Is Nothing Then
                ltypMasOpList.typMasOpId = New List(Of MasOpId)
            End If

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_useoplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_useoplistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            '@大工程ID
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, lstrOpID)
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            '@ｶﾃｺﾞﾘID
            If lstrCategoryId <> vbNullString Then
                Call lrMsg.addString(CPstrCATEGORY_ID, lstrCategoryId)
            Else
                Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_useoplist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypMasOpList
                        '@受信結果取得
                        Call laMsg.getString(CPstrCATEGORY_ID, .strCategoryID)                          'ｶﾃｺﾞﾘID
                        
                        '@ｱﾚｲ取得
                        Call laMsg.getMsgAry(CPstrOP_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngMasOpCnt = laAry.Count
                        
                        '@配列があればﾃﾞｰﾀ格納
                        If .lngMasOpCnt > 0 Then
                            '@構造体初期化
                            Do While (.typMasOpId.Count < .lngMasOpCnt)
                                .typMasOpId.Add(New MasOpId)
                            Loop

                            Dim typMasOpIdTmp = New MasOpId
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typMasOpIdTmp
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                          '大工程ID
                                    Call ltMsg.getString(CPstrVALID_FLAG, .strValidFlag)                '有効ﾌﾗｸﾞ
                                End With

                                .typMasOpId(llngCnt) = typMasOpIdTmp

                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasUseOpList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_useoplistVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnChkFunc_Sel
    '機　能：機能ﾊﾞｰｼﾞｮﾝﾁｪｯｸ処理
    '引　数：lstrUtilChkFunc_Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrFunctionID     ：機能ID
    '　　　：lstrFunctionVersion：機能ﾊﾞｰｼﾞｮﾝ
    '戻り値：Ture:正常、False:異常
    '作成日：2004/09/29 (Wed) 16:49:09 H.Wajima
    '更新日：2004/09/29 (Wed) 16:49:09
    '備　考：
    Public Function pubblnChkFunc_Sel(ByVal lstrUtilChkFunc_Ver As String, _
                                      ByVal lstrFunctionID As String, _
                                      ByVal lstrFunctionVersion As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            '@初期設定
            pstrMessageName = "機能バージョンチェック"
            pubblnChkFunc_Sel = False                  '当関数の戻り値

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrUtilChkFunc_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrUtilChkFunc_Ver)             'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrFunctionID <> vbNullString Then
                Call lrMsg.addString(CPstrFUNCTION_ID, lstrFunctionID)              '機能ID
            Else
                Call lrMsg.addString(CPstrFUNCTION_ID, CPstrMsgNull)
            End If
            If lstrFunctionVersion <> vbNullString Then
                Call lrMsg.addString(CPstrFUNCTION_VERSION, lstrFunctionVersion)    '機能ﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrFUNCTION_VERSION, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrutilchkfunc_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnChkFunc_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrUtilChkFunc_Ver, lstrFunctionVersion)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000B)
                    '@「プログラムの起動に必要な基本情報が取得できませんでした。システム担当者に連絡して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@解放
            lrMsg = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnLotChkWaist_Sel
    '機　能：WAISTﾃﾞｰﾀ状態確認
    '引　数：lstrMsgVer     ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID       ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrLotID      ：ﾛｯﾄID
    '　　　：lstrWaistStatus：WAISTﾃﾞｰﾀ状態
    '戻り値：True:成功/False:失敗
    '作成日：2004/10/20 (Wed) 18:29:12 T.Kitagawa
    '更新日：2004/10/20 (Wed) 18:29:12
    '備　考：
    Public Function pubblnLotChkWaist_Sel(ByVal lstrMsgVer As String, _
                                          ByVal lstrSBID As String, _
                                          ByVal lstrLotID As String, _
                                          ByRef lstrWaistStatus As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ＷＡＩＳＴデータ状態確認"
            pubblnLotChkWaist_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)              'ｼｽﾃﾑﾌﾞﾛｯｸ
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)            'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkwaist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrWAIST_STATUS, lstrWaistStatus)    'WAISTﾃﾞｰﾀ状態
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotChkWaist_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnLotCfEnd_Upd
    '機　能：CFﾛｯﾄ終了処理
    '引　数：ltypLotCfEnd       ：CFﾛｯﾄ終了要求格納構造体
    '　　　：lstrGuidMsg        ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode    ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True：成功、False  ：失敗
    '作成日：2004/08/26 (Thu) 13:20:40 N.Kasai
    '更新日：2005/03/31 (Thu) 16:41:51 N.Kojima
    '備　考：このﾒｯｾｰｼﾞでCFLOTを終了させてTPALﾛｯﾄを流動できるようにします。
    '　　　：2004/10/21 (Thu) 15:00:40 S.Deguchi    MG0060からCM0050へ移動
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    Public Function pubblnLotCfEnd_Upd(ByRef ltypLotCfEnd As LotCfEnd, _
                                       ByRef lstrGuidMsg As String, _
                                       ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            pstrMessageName = "ＣＦロット終了"
            pubblnLotCfEnd_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypLotCfEnd
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
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
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@ﾛｯﾄ最終更新日時
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If
            
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_cfend___, lrMsg, laMsg)
                
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
                        pubblnLotCfEnd_Upd = True
                        
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

    '関数名：pubblnLotTpalCombStart_Upd
    '機　能：TPAL貼り合わせ登録
    '引　数：lstrlot_tpalcombstartVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypTpalCombStart          ：TPAL貼り合わせ登録送信ﾃﾞｰﾀ格納構造体
    '　　　：lstrLotLastUpdate          ：TFT基板ﾛｯﾄ最終更新日時
    '戻り値：True：登録成功、False：登録失敗
    '作成日：2004/08/31 (Tue) 11:58:17 N.Kojima
    '更新日：2005/07/25 (Mon) 18:11:46 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 15:00:40 S.Deguchi    MG0060からCM0050へ移動
    '　　　：2004/11/22 (Mon) 17:03:03 S.Deguchi    不良ﾁｯﾌﾟ数量のﾀｸﾞを追加
    '　　　：2005/07/25 (Mon) 18:11:46 N.Kojima     要求と応答に"LOT_LAST_UPDATE"を追加。ﾕｰｻﾞ要望№0061
    Public Function pubblnLotTpalCombStart_Upd(ByVal lstrlot_tpalcombstartVer As String, _
                                               ByRef ltypTpalCombStart As TpalCombStart, _
                                               ByRef lstrLotLastUpdate As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "TPAL貼り合わせ登録"
            pubblnLotTpalCombStart_Upd = False

            '@ｵﾌﾞｼﾞｪｸﾄの作成
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@***********************
            '@ 要求TAG作成
            '@***********************
            With ltypTpalCombStart

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrlot_tpalcombstartVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrlot_tpalcombstartVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ﾛｯﾄID(TFT基板ﾛｯﾄID(親ﾛｯﾄ))
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If

                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If

                '@ﾛｯﾄ最終更新日時(TFT基板ﾛｯﾄ)
                If .strLotLastUpdate <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)
                Else
                    Call lrMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                End If

                '@-----------------------
                '@ TPALﾛｯﾄﾘｽﾄ作成
                '@-----------------------
                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngCnt = 0
                Do While .typTpalLotList.Count -1 >= llngCnt

                    '@TPALﾛｯﾄID
                    If .typTpalLotList(llngCnt).strTpalLotId <> vbNullString Then
                        Call ltMsg.addString(CPstrTPAL_LOT_ID, .typTpalLotList(llngCnt).strTpalLotId)
                    Else
                        Call ltMsg.addString(CPstrTPAL_LOT_ID, CPstrMsgNull)
                    End If

                    '@貼数
                    If .typTpalLotList(llngCnt).strChipQuantity <> vbNullString Then
                        Call ltMsg.addString(CPstrCHIP_QUANTITY, .typTpalLotList(llngCnt).strChipQuantity)
                    Else
                        Call ltMsg.addString(CPstrCHIP_QUANTITY, CPstrMsgNull)
                    End If

                    '@不良数
                    If .typTpalLotList(llngCnt).strChipOutQuantity <> vbNullString Then
                        Call ltMsg.addString(CPstrCHIP_OUT_QUANTITY, .typTpalLotList(llngCnt).strChipOutQuantity)
                    Else
                        Call ltMsg.addString(CPstrCHIP_OUT_QUANTITY, CPstrMsgNull)
                    End If

                    '@ﾛｯﾄ最終更新日時(TPALﾛｯﾄ)
                    If .typTpalLotList(llngCnt).strLotLastUpdate <> vbNullString Then
                        Call ltMsg.addString(CPstrLOT_LAST_UPDATE, .typTpalLotList(llngCnt).strLotLastUpdate)
                    Else
                        Call ltMsg.addString(CPstrLOT_LAST_UPDATE, CPstrMsgNull)
                    End If

                    '@TPALﾛｯﾄﾘｽﾄ作成、TEMP領域初期化、ﾙｰﾌﾟｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                    llngCnt = llngCnt + 1
                Loop

                '@要求TAGのTPALﾛｯﾄﾘｽﾄに追加
                Call lrMsg.addMsgAry(CPstrTPAL_LOT_LIST, lrAry)

                '@配列をｸﾘｱ
                lrAry.Clear

            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_tpalcombstart, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞ取得：ﾛｯﾄ最終更新日時
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdate)                    'TFTﾛｯﾄ最終更新日時

                    '@戻り値に"True：登録成功"をｾｯﾄ
                    pubblnLotTpalCombStart_Upd = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_tpalcombstartVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
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

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnElt_Mapget_Sel
    '機　能：電特結果要求
    '引　数：lstrelctmapget__Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrWFID           ：WFID
    '　　　：ltypWFMapInfo      ：ﾁｯﾌﾟﾘｽﾄ格納構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/09/13 (Mon) 12:57:47 Y.Yamagishi
    '更新日：2004/10/21 (Thu) 14:31:55 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:19:51 M.Miura      受信結果にﾛｯﾄ最終更新日時を追加
    '　　　：2004/10/21 (Thu) 14:31:55 N.Kojima     空ﾀｸﾞ挿入処理削除
    '　　　：2004/10/21 (Thu) 15:00:40 S.Deguchi    MG0060からCM0050へ移動
    Public Function pubblnElt_Mapget_Sel(ByVal CMstrelt_mapget__Ver As String, _
                                         ByVal lstrWFID As String, _
                                         ByRef ltypEltMapget As EltMapget) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg1              As TfMsg            '送信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞ(ｱﾚｰ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         'ｱﾚｰ取得用
        Dim llngCnt             As Integer          'ｶｳﾝﾄ
        Dim ltMsg               As TfMsg            'ｱﾚｰの各要素取得用
        Dim lstrRET             As String           '応答取得
            
        Try

            pstrMessageName = "電特結果要求"
            pubblnElt_Mapget_Sel = False

            lrMsg = New TfMsg
            ltMsg1 = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg

            'NSYS リスト初期化
            If ltypEltMapget.typEltMapgetWFList Is Nothing Then
                ltypEltMapget.typEltMapgetWFList = New List(Of EltMapgetWFList)
            End If

            '@送信ﾒｯｾｰｼﾞ作成
            If CMstrelt_mapget__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, CMstrelt_mapget__Ver)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                  'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)               '作業者ID
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@WFIDﾘｽﾄ
            If lstrWFID <> vbNullString Then
                Call ltMsg1.addString(CPstrWF_ID, lstrWFID)                 'WFID
                Call lrAry.Add(ltMsg1)
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
            Else
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
                lrAry.Clear
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrelt_mapget__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                    
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, ptypLotprestate.strLotLastUpdate)    'ﾛｯﾄ最終更新日時
                    
                    '@ｱﾚｲ数格納
                    ltypEltMapget.lngCnt = laAry.Count
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypEltMapget.lngCnt > 0 Then
                        '@配列数を設定
                        Do While (ltypEltMapget.typEltMapgetWFList.Count < laAry.count)
                            ltypEltMapget.typEltMapgetWFList.Add(New EltMapgetWFList)
                        Loop

                        Dim typEltMapgetWFListTmp = New EltMapgetWFList

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            '@受信結果取得
                            With typEltMapgetWFListTmp
                                Call ltMsg.getString(CPstrWF_ID, .strWfId)                      'WFID
                                Call ltMsg.getString(CPstrRESULT, .strResult)                   '測定結果
                                Call ltMsg.getString(CPstrCOMMENTS, .strComments)               '測定結果ｺﾒﾝﾄ
                            End With

                            ltypEltMapget.typEltMapgetWFList(llngCnt) = typEltMapgetWFListTmp

                            llngCnt = llngCnt + 1
                        Next
                    End If
                    '@関数の処理結果(成功)格納
                    pubblnElt_Mapget_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, CMstrelt_mapget__Ver)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)

                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg1 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg1 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            laAry = Nothing
            ltMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnCarrManuOutPort_Ins
    '機　能：ｷｬﾘｱ手動出庫要求
    '引　数：lstrCarrierID          ：ｷｬﾘｱID
    '　　　：lstrcarrmanuoutportVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrStockerID          ：ｽﾄｯｶID
    '　　　：lstrEmpID              ：作業者ID
    '戻り値：True：処理成功、False：処理失敗
    '作成日：2004/11/02 (Tue) 15:42:11 N.Kojima
    '更新日：2004/11/02 (Tue) 15:42:11
    '備　考：
    Public Function pubblnCarrManuOutPort_Ins(ByVal lstrCarrierID As String, _
                                              ByVal lstrcarrmanuoutportVer As String, _
                                              ByVal lstrStockerID As String, _
                                              ByVal lstrEmpID As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            pstrMessageName = "キャリア手動出庫要求"
            pubblnCarrManuOutPort_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@SBID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrcarrmanuoutportVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrcarrmanuoutportVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If

            '@出庫先ｽﾄｯｶｰNo
            If lstrStockerID <> vbNullString Then
                Call lrMsg.addString(CPstrSTOCKER_ID, lstrStockerID)
            Else
                Call lrMsg.addString(CPstrSTOCKER_ID, CPstrMsgNull)
            End If
            
            '@作業者ID
            If lstrEmpID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, lstrEmpID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrmanuoutport, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnCarrManuOutPort_Ins = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrcarrmanuoutportVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnMasStockerList_Sel
    '機　能：ｽﾄｯｶﾏｽﾀ取得
    '引　数：ltypStockerList        ：ｽﾄｯｶﾏｽﾀﾘｽﾄ
    '　　　：lstrmas_stockerlistVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：llngStockerCnt         ：ﾘｽﾄｶｳﾝﾄ数
    '　　　：lstrClassDivision      ：処理区分
    '戻り値：True：成功、False：失敗
    '作成日：2004/11/04 (Thu) 20:14:05 N.Kojima
    '更新日：2004/11/04 (Thu) 20:14:05
    '備　考：
    Public Function pubblnMasStockerList_Sel(ByRef ltypStockerList As List(Of StockerList), _
                                             ByVal lstrmas_stockerlistVer As String, _
                                             ByRef llngStockerCnt As Integer, _
                                             ByVal lstrClassDivision As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            pstrMessageName = "ストッカマスタ取得"
            pubblnMasStockerList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@SBID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_stockerlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_stockerlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_stockerlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrSTOCKER_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                    llngStockerCnt = laAry.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngStockerCnt > 0 Then
                        
                        If IsNothing(ltypStockerList) Then
                            ltypStockerList = New List(Of StockerList)()
                        Else
                            ltypStockerList.Clear()
                        End If

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            
                            Dim ltypStockerListTmp As StockerList = New StockerList()

                            '@受信結果取得
                            With ltypStockerListTmp
                                Call ltMsg.getString(CPstrSTOCKER_ID, .strStockerId)        'ｽﾄｯｶID
                                Call ltMsg.getString(CPstrSTOCKER_NAME, .strStockerName)    'ｽﾄｯｶ名
                            End With
                            
                            ltypStockerList.Add(ltypStockerListTmp)

                            llngCnt = llngCnt + 1
                        
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasStockerList_Sel = True
                     
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_stockerlistVer)
                    
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
            laAry = Nothing

            Exit Function
            
        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnLotEventList_Sel
    '機　能：ﾛｯﾄｲﾍﾞﾝﾄ履歴取得
    '引　数：lstrSbID               ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrlot_eventlistVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrlotID              ：ﾛｯﾄID
    '　　　：ltypLotEventList       ：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/09/03 (Fri) 18:55:54 T.Kitagawa
    '更新日：2004/11/18 (Thu) 10:19:15 N.Kasai
    '備　考：
    '　　　：2004/11/18 (Thu) 10:19:15 N.Kasai      個別ﾓｼﾞｭｰﾙ(basxxMG00W0から共通ﾓｼﾞｭｰﾙへ移動)
    '　　　：2005/06/01 (Wed) 10:24:30 S.Deguchi    不具合№832の対応でﾕｰｻﾞｰID/名をｶﾗﾑ追加
    Public Function pubblnLotEventList_Sel(ByVal lstrSBID As String, _
                                           ByVal lstrlot_eventlistVer As String, _
                                           ByVal lstrLotID As String, _
                                           ByRef ltypLotEventList As LotEventList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "ロットイベント履歴取得"
            pubblnLotEventList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            'NSYS リスト初期化
            If ltypLotEventList.typLotEvent Is Nothing Then
                ltypLotEventList.typLotEvent = New List(Of LotEvent)
            End If

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                              'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrlot_eventlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_eventlistVer)                'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)                            'ﾛｯﾄID
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_eventlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypLotEventList
                        '@受信結果取得
                        Call laMsg.getMsgAry(CPstrEVENT_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngLotEventCnt = laAry.Count
                        If .lngLotEventCnt > 0 Then
                            Do While (.typLotEvent.Count < .lngLotEventCnt)
                                .typLotEvent.Add(New LotEvent)
                            Loop

                            Dim typLotEventTmp As LotEvent = New LotEvent

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typLotEventTmp
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)    'ｲﾍﾞﾝﾄ日時
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)       'ｺﾒﾝﾄ
                                    Call ltMsg.getString(CPstrEMP_ID, .strEmpID)            'ﾕｰｻﾞｰID
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)        'ﾕｰｻﾞｰ名
                                End With

                                .typLotEvent(llngCnt) = typLotEventTmp

                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotEventList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_eventlistVer)
                    
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
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnCtlUpdWaitingLot_Upd
    '機　能：処理待ちﾛｯﾄ更新処理
    '引　数：ltypCtlUpdWaitingLotList：送信ﾒｯｾｰｼﾞ構造体
    '戻り値：True：成功、False：失敗
    '作成日：2004/12/10 (Fri) 11:38:54 S.Deguchi
    '更新日：2004/12/10 (Fri) 11:38:54
    '備　考：
    Public Function pubblnCtlUpdWaitingLot_Upd(ByRef ltypCtlUpdWaitingLotList As CtlUpWaitingLot) As Boolean

        Dim lrMsg               As TfMsg           '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg           '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg           '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry        '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "処理待ちロット更新"
            pubblnCtlUpdWaitingLot_Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypCtlUpdWaitingLotList
                '@ClassDivision
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@Aryﾒｯｾｰｼﾞ作成
                For llngCnt = 0 To .lngWaitingLotListCnt -1
                    '@ﾛｯﾄID
                    If .typWaitingLotList(llngCnt).strLotID <> vbNullString Then
                        Call ltMsg.addString(CPstrLOT_ID, .typWaitingLotList(llngCnt).strLotID)
                    Else
                        Call ltMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                    End If
                    '@大工程
                    If .typWaitingLotList(llngCnt).strOpID <> vbNullString Then
                        Call ltMsg.addString(CPstrOP_ID, .typWaitingLotList(llngCnt).strOpID)
                    Else
                        Call ltMsg.addString(CPstrOP_ID, CPstrMsgNull)
                    End If
                    '@小工程
                    If .typWaitingLotList(llngCnt).strStepID <> vbNullString Then
                        Call ltMsg.addString(CPstrSTEP_ID, .typWaitingLotList(llngCnt).strStepID)
                    Else
                        Call ltMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                    End If
                    '@処理順
                    If .typWaitingLotList(llngCnt).strSeqNum <> vbNullString Then
                        Call ltMsg.addString(CPstrSEQ_NUM, .typWaitingLotList(llngCnt).strSeqNum)
                    Else
                        Call ltMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next
                Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
                lrAry.Clear
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrctl_updwaitinglot, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnCtlUpdWaitingLot_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypCtlUpdWaitingLotList.strMsgVer)
                    
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

    '関数名：pubblnLotDetail_Sel
    '機　能：ﾛｯﾄ詳細情報取得
    '引　数：lstrlot_Detail__Ver：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrClassDivision  ：処理区分(0K:ｷｬﾘｱID指定、0L:ﾛｯﾄID指定)
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：lstrCarrierID      ：ｷｬﾘｱID
    '　　　：ltypLotDetailInfo  ：格納ﾃﾞｰﾀ
    '戻り値：True：正常、False：異常
    '作成日：2004/09/15 (Wed) 16:49:57 T.Kitagawa
    '更新日：2016/02/11 (Thu) 22:38:59 H.Hayashi
    '備　考：
    '　　　：2004/09/26 (Sun) 14:30:20 Y.Yamagishi　応答ﾀｸﾞに制限ﾀｲﾌﾟ追加
    '　　　：2004/10/13 (Wed) 14:46:41 N.Kojima　   応答にCF_FLAG追加(不具合№792)
    '　　　：2005/01/31 (Mon) 15:10:02 N.Kasai      応答にKRF_FILE_NAMEを追加　& basxxMG01C0より移動
    '　　　：2005/05/19 (Thu) 16:53:34 N.Kasai      応答にODF_CARRIER_ID、ODF_LOT_ID追加
    '　　　：2006/10/31 (Tue) 16:14:58 N.Kasai      応答ﾀｸﾞ追加(LOT_SEND_FLAG №01500)
    '　　　：2008/06/16 (Mon) 17:52:48 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2010/03/10 (Wed) 11:32:51 T.Oide       VAﾌﾗｸﾞ追加(№03929)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnLotDetail_Sel(ByVal lstrlot_Detail__Ver As String, _
                                        ByVal lstrSBID As String, _
                                        ByVal lstrClassDivision As String, _
                                        ByVal lstrLotID As String, _
                                        ByVal lstrCarrierID As String, _
                                        ByRef ltypLotDetailInfo As LotDetailInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@各種初期設定
            pstrMessageName = "ロット詳細情報取得"
            pubblnLotDetail_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_Detail__Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_Detail__Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                 Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@処理区分
            If lstrClassDivision <> vbNullString Then
                 Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                 Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ｷｬﾘｱID
            If lstrCarrierID <> vbNullString Then
                 Call lrMsg.addString(CPstrCARRIER_ID, lstrCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_detail__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    With ltypLotDetailInfo

                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                        Call laMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                        Call laMsg.getString(CPstrPD_ID, .strPdId)                                  '機種ID
                        Call laMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '流動区分
                        Call laMsg.getString(CPstrGRB_CLASS, .strGrbClass)                          'GRB区分
                        Call laMsg.getString(CPstrLOT_PRIORITY, .strLotPriority)                    '優先度
                        Call laMsg.getString(CPstrLOT_PRIORITY_NAME, .strLotPriorityName)           '優先度名
                        Call laMsg.getString(CPstrWF_NUM, .strWfNum)                                'WF枚数
                        Call laMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                  '良品ﾁｯﾌﾟ数
                        Call laMsg.getString(CPstrENG_EMP_NAME, .strEngEmpName)                     'ﾛｯﾄ担当者名
                        Call laMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   'ﾛｯﾄ位置(和名)
                        Call laMsg.getString(CPstrLAST_EVENT_NAME, .strLastEventName)               '最終ｲﾍﾞﾝﾄ名
                        Call laMsg.getString(CPstrENTRY_TIME, .strEntryTime)                        '最終ｲﾍﾞﾝﾄ日時
                        Call laMsg.getString(CPstrEMP_NAME, .strEmpName)                            '最終更新者名
                        Call laMsg.getString(CPstrCOMMENTS, .strComments)                           'ｺﾒﾝﾄ
                        Call laMsg.getString(CPstrSPECIAL_FLG, .strSpecialFlg)                      '特殊特性
                        Call laMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)                   'ﾛｯﾄ保留ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)                   'ﾛｯﾄ停止ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrNOW_ST, .strNowST)                                'ﾛｯﾄ状態
                        Call laMsg.getString(CPstrDISPATCH_START_TIME, .strDispatchStartTime)       '投入予定時刻
                        Call laMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程ID
                        Call laMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程ID
                        Call laMsg.getString(CPstrALT_FLAG, .strAltFlag)                            '代替工程有無ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrSWAP_FLAG, .strSwapFlag)                          '入替工程有無ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrREWORK_STATUS, .strReworkFlag)                    'ﾘﾜｰｸ状態
                        Call laMsg.getString(CPstrBATCH_ID, .strBatchId)                            'ﾊﾞｯﾁID
                        Call laMsg.getString(CPstrWP_NAME, .strWpName)                              'WP名
                        Call laMsg.getString(CPstrPORT_NAME, .strPortName)                          'ﾎﾟｰﾄ名
                        Call laMsg.getString(CPstrRECIPE_ID, .strRecipeId)                          'ﾚｼﾋﾟID
                        Call laMsg.getString(CPstrLOADER_CARRIER_ID, .strLoaderCarrierID)           'ﾛｰﾀﾞｰｷｬﾘｱID
                        Call laMsg.getString(CPstrUNLOADER_CARRIER_ID, .strUnloaderCarrierID)       'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                        Call laMsg.getString(CPstrNEXT_OP_ID, .strNextOpId)                         '次大工程
                        Call laMsg.getString(CPstrNEXT_STEP_ID, .strNextStepId)                     '次小工程
                        Call laMsg.getString(CPstrNEXT_ALT_FLAG, .strNextAltFlag)                   '代替次工程有無ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrNEXT_SWAP_FLAG, .strNextSwapFlag)                 '入替次工程有無ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrDIVIDE_LOT_ID, .strDivideLotID)                   '分割親ﾛｯﾄID
                       
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ格納：分割ﾛｯﾄﾘｽﾄ
                        Call laMsg.getMsgAry(CPstrDIVIDE_LOT_LIST, laAry)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数：分割ﾛｯﾄﾘｽﾄﾃﾞｰﾀ数
                        .lngDivideLot2Cnt = laAry.Count
                        .typDivideLot2 = New List(Of DivideLot2)
                        Do While (.typDivideLot2.Count < .lngDivideLot2Cnt)
                            .typDivideLot2.Add(New DivideLot2)
                        Loop

                        '@分割ﾛｯﾄﾘｽﾄﾃﾞｰﾀが1件以上存在するか
                        If .lngDivideLot2Cnt > 0 Then
                        
                            '@配列領域の確保
                            Dim typDivideLot2Tmp = New DivideLot2
                            
                            '@ｶｳﾝﾀの初期化
                            llngCnt = 0
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各ﾃﾞｰﾀ取得
                            For Each ltMsg In laAry
                                
                                '@受信結果取得
                                With typDivideLot2Tmp
                                    Call ltMsg.getString(CPstrDIVIDE_LOT_ID2, .strDivideLotID2)     '分割子ﾛｯﾄID
                                End With
                                
                                .typDivideLot2(llngCnt) = typDivideLot2Tmp

                                '@ｶｳﾝﾀを+1する
                                llngCnt = llngCnt + 1
                            Next
                        End If
                        Call laMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                        '制限時間(時間制約)
                        Call laMsg.getString(CPstrTO_OP_ID, .strToOpId)                             '制限時間先大工程
                        Call laMsg.getString(CPstrTO_STEP_ID, .strToStepId)                         '制限時間先小工程
                        Call laMsg.getString(CPstrWARN_TIME, .strWarnTime)                          '警告時間
                        Call laMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)               'ﾛｯﾄ最終更新日時
                        Call laMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)             '制限ﾀｲﾌﾟ
                        Call laMsg.getString(CPstrCF_FLAG, .strCfFlag)                              'CFﾌﾗｸﾞ
                        Call laMsg.getString(CPstrVA_FLAG, .strVaFlag)                              'VAﾌﾗｸﾞ
                        Call laMsg.getString(CPstrKRF_FILENAME, .strKrfFileName)                    'KRFﾌｧｲﾙ名
                        Call laMsg.getString(CPstrODF_CARRIER_ID, .strODFCarrierID)                 'ODFｷｬﾘｱID
                        Call laMsg.getString(CPstrODF_LOT_ID, .strODFLotID)                         'ODFﾛｯﾄID
                        Call laMsg.getString(CPstrLP_FLAG, .strLpFlag)                              '大板ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrLOT_SEND_FLAG, .strLotSendFlag)                   '送品ﾌﾗｸﾞ(0:送品なし、1:送品あり)

                        '@★ 特殊特性ﾌﾗｸﾞにより処理分岐 ★
                        Select Case .strSpecialFlg
                        
                            '@〓 0：非表示 〓
                            Case CPstrSpNull

                                .strSpecialFlg = vbNullString
                                
                            '@〓 1、2、その他(その他はありえない) 〓
                            Case Else
                            
                                '@処理なし

                        End Select
                    End With
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotDetail_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_Detail__Ver)

                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnSpcJudge_Sel
    '機　能：規格値判定
    '引　数：ltypSpcJudge：規格値判定Msg送受信構造体
    '戻り値：True:正常終了、False:異常終了
    '作成日：2005/02/01 (Tue) 16:10:59 H.Wajima
    '更新日：2005/05/31 (Tue) 11:11:00 H.Wajima
    '備　考：
    '　　　：2005/03/24 (Thu) 09:06:54 H.Wajima     保留解除に伴う修正
    '　　　：2005/05/31 (Tue) 11:11:00 H.Wajima     HOLD_COMPLETE_FLAG廃止
    Public Function pubblnSpcJudge_Sel(ByRef ltypSpcJudge As SpcJudge) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "規格値判定"
            pubblnSpcJudge_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypSpcJudge
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@ｼｽﾃﾑﾌﾞﾛｯｸ
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@大工程
                If .strOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOP_ID, .strOpID)
                Else
                    Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
                End If
                '@小工程
                If .strStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrSTEP_ID, .strStepID)
                Else
                    Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@作業終了後ﾛｯﾄID
                If .strNextLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrNEXT_LOT_ID, .strNextLotID)
                Else
                    Call lrMsg.addString(CPstrNEXT_LOT_ID, CPstrMsgNull)
                End If
            End With
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrspc_judge___, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    With ltypSpcJudge
                        Call laMsg.getString(CPstrSPEC_CHECK, .strSpecCheck)                        '基準値判定結果
                        Call laMsg.getString(CPstrSPEC_MSG_CODE, .strSpecMsgCode)                   '基準値判定結果ﾒｯｾｰｼﾞｺｰﾄﾞ
                        Call laMsg.getString(CPstrSPEC_MSG, .strSpecMsg)                            '基準値判定結果ﾒｯｾｰｼﾞ
                    
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnSpcJudge_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypSpcJudge.strMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
            End Select
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnFtsMode_Sel
    '機　能：搬送ﾓｰﾄﾞ取得要求
    '引　数：lstrfts_mode____Ver        ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：llngMachineStatusListCnt   ：機器ﾘｽﾄｶｳﾝﾄ
    '　　　：ltypFtsMode                ：搬送ﾓｰﾄﾞ構造体
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/12/06 (Mon) 16:13:27 N.Kojima
    '更新日：2004/12/13 (Mon) 14:59:56 N.Kojima
    '備　考：
    Public Function pubblnFtsMode_Sel(ByVal lstrfts_mode____Ver As String, _
                                      ByRef llngMachineStatusListCnt As Integer, _
                                      ByRef ltypFtsMode As FtsMode) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim lrAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry1             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim laAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim ltMsg3             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim laAry3             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)-受信
        Dim lstrRET            As String            '応答取得
        Dim llngCnt1           As Integer           'ｱﾚｲｶｳﾝﾄ用1
        Dim llngCnt2           As Integer           'ｱﾚｲｶｳﾝﾄ用2
        Dim llngCnt3           As Integer           'ｱﾚｲｶｳﾝﾄ用3

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            lrAry1 = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry
            ltMsg3 = New TfMsg
            laAry3 = New TfMsgAry

            '@初期設定
            pstrMessageName = "搬送モード取得"
            pubblnFtsMode_Sel = False
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrfts_mode____Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrfts_mode____Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrfts_mode____, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@構造体のｸﾘｱ
                    If ltypFtsMode.typFtsStockerLIST Is Nothing Then
                        ltypFtsMode.typFtsStockerLIST = New List(Of FtsStockerLIST)
                    Else
                        ltypFtsMode.typFtsStockerLIST.Clear()
                    End If
                    If ltypFtsMode.typFtsBAYLIST Is Nothing Then
                        ltypFtsMode.typFtsBAYLIST = New List(Of FtsBAYLIST)
                    Else
                        ltypFtsMode.typFtsBAYLIST.Clear()
                    End If
                    If ltypFtsMode.typFtsVehicleLIST Is Nothing Then
                        ltypFtsMode.typFtsVehicleLIST = New List(Of FtsVehicleLIST)
                    Else
                        ltypFtsMode.typFtsVehicleLIST.Clear()
                    End If

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getString(CPstrTRANSFER_STATUS, ltypFtsMode.strTransferStatus)           '搬送可能状態ID
                    Call laMsg.getString(CPstrTRANSFER_STATUS_NAME, ltypFtsMode.strTransferStatusName)  '搬送可能状態名
                    Call laMsg.getString(CPstrSTATUS, ltypFtsMode.strStatus)                            '搬送サーバ状態
                    Call laMsg.getString(CPstrSTATUS_NAME, ltypFtsMode.strStatusName)                   '搬送サーバ状態名
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrFTS_STOCKER_LIST, laAry1)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                    ltypFtsMode.lngStockerListCnt = laAry1.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypFtsMode.lngStockerListCnt > 0 Then
                        
                        Do While (ltypFtsMode.typFtsStockerLIST.Count < ltypFtsMode.lngStockerListCnt)
                            ltypFtsMode.typFtsStockerLIST.Add(New FtsStockerLIST)
                        Loop

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1から各Msg取得
                        llngCnt1 = 0
                        For Each ltMsg1 In laAry1
                            Dim typFtsStockerLISTTmp As FtsStockerLIST = New FtsStockerLIST
                            With typFtsStockerLISTTmp
                                '@ﾃﾞｰﾀ格納
                                Call ltMsg1.getString(CPstrSTOCKER_ID, .strStockerId)                       'ｽﾄｯｶｰID
                                Call ltMsg1.getString(CPstrSTOCKER_NAME, .strStockerName)                   'ｽﾄｯｶｰ名
                                Call ltMsg1.getString(CPstrSTATUS, .strStatus)                              'ｽﾄｯｶｰ状態ID
                                Call ltMsg1.getString(CPstrSTATUS_NAME, .strStatusName)                     'ｽﾄｯｶｰ状態名
                                Call ltMsg1.getString(CPstrSTOCKER_CAPACITY, .strStockerCapacity)           'ｽﾄｯｶｰ収納状況ID
                                Call ltMsg1.getString(CPstrSTOCKER_CAPACITY_NAME, .strStockerCapacityName)  'ｽﾄｯｶｰ収納状況名
                                Call ltMsg1.getString(CPstrALARM_ID, .strAlarmID)                           'ｱﾗｰﾑID
                                Call ltMsg1.getString(CPstrEDIT_TIME, .strEditTime)                         '最終更新日時
                                
                                ltypFtsMode.typFtsStockerLIST(llngCnt1) = typFtsStockerLISTTmp

                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngCnt1 = llngCnt1 + 1
                            End With
                        Next
                        
                    End If
                        
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2取得
                    Call laMsg.getMsgAry(CPstrFTS_BAY_LIST, laAry2)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2のｶｳﾝﾄ格納
                    ltypFtsMode.lngBayListCnt = laAry2.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypFtsMode.lngBayListCnt > 0 Then
                        
                        Do While (ltypFtsMode.typFtsBAYLIST.Count < ltypFtsMode.lngBayListCnt)
                            ltypFtsMode.typFtsBAYLIST.Add(New FtsBAYLIST)
                        Loop

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt2 = 0
                        For Each ltMsg2 In laAry2
                            Dim typFtsBAYLISTTmp As FtsBAYLIST = New FtsBAYLIST
                            With typFtsBAYLISTTmp
                                '@受信結果取得
                                Call ltMsg2.getString(CPstrBAY_ID, .strBAYID)                   'ﾍﾞｲID
                                Call ltMsg2.getString(CPstrBAY_NAME, .strBAYName)               'ﾍﾞｲ名
                                Call ltMsg2.getString(CPstrSTATUS, .strStatus)                  'ﾍﾞｲ状態ID
                                Call ltMsg2.getString(CPstrSTATUS_NAME, .strStatusName)         'ﾍﾞｲ状態名
                                Call ltMsg2.getString(CPstrALARM_ID, .strAlarmID)               'ｱﾗｰﾑID
                                Call ltMsg2.getString(CPstrEDIT_TIME, .strEditTime)             '最終更新日時

                                ltypFtsMode.typFtsBAYLIST(llngCnt2) = typFtsBAYLISTTmp

                                llngCnt2 = llngCnt2 + 1
                            End With
                        Next
                        
                    End If
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3取得
                    Call laMsg.getMsgAry(CPstrFTS_VEHICLE_LIST, laAry3)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ3のｶｳﾝﾄ格納
                    ltypFtsMode.lngVehicleListCnt = laAry3.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypFtsMode.lngVehicleListCnt > 0 Then
                        
                        Do While (ltypFtsMode.typFtsVehicleLIST.Count < ltypFtsMode.lngVehicleListCnt)
                            ltypFtsMode.typFtsVehicleLIST.Add(New FtsVehicleLIST)
                        Loop

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt3 = 0
                        For Each ltMsg3 In laAry3
                            Dim typFtsVehicleLISTTmp As FtsVehicleLIST = New FtsVehicleLIST
                            With typFtsVehicleLISTTmp
                                '@受信結果取得
                                Call ltMsg3.getString(CPstrVEHICLE_ID, .strVehicleID)           'ﾋﾞｰｸﾙID
                                Call ltMsg3.getString(CPstrVEHICLE_NAME, .strVehicleName)       'ﾋﾞｰｸﾙ名
                                Call ltMsg3.getString(CPstrSTATUS, .strStatus)                  'ﾋﾞｰｸﾙ状態ID
                                Call ltMsg3.getString(CPstrSTATUS_NAME, .strStatusName)         'ﾋﾞｰｸﾙ状態名
                                Call ltMsg3.getString(CPstrEDIT_TIME, .strEditTime)             '最終更新日時

                                ltypFtsMode.typFtsVehicleLIST(llngCnt3) = typFtsVehicleLISTTmp

                                llngCnt3 = llngCnt3 + 1
                            End With
                        Next
                        
                    End If
                    
                    '@"ｽﾄｯｶｰﾘｽﾄｶｳﾝﾄ"+"ﾍﾞｲﾘｽﾄｶｳﾝﾄ"+"ﾋﾞｰｸﾙﾘｽﾄｶｳﾝﾄ"を機器ﾘｽﾄｶｳﾝﾄに格納
                    llngMachineStatusListCnt = ltypFtsMode.lngStockerListCnt + ltypFtsMode.lngVehicleListCnt + _
                                               ltypFtsMode.lngBayListCnt
                    
                    '@関数の処理結果(成功)格納
                    pubblnFtsMode_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrfts_mode____Ver)
                    
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
            lrAry = Nothing
            lrAry1 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing
            ltMsg3 = Nothing
            laAry3 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            lrAry1 = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing
            ltMsg3 = Nothing

        End Try
    End Function

    '関数名：pubblnRtclList____Sel
    '機　能：ﾚﾁｸﾙ情報取得
    '引　数：ltypRtclList2()    ：要求内容格納構造体
    '　　　：ltypRtclList()     ：取得結果格納構造体
    '　　　：llngRtclListCnt    ：ｶｳﾝﾄ
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/25 (Wed) 12:12:01 Y.Yamagishi
    '更新日：2005/02/28 (Mon) 10:41:44 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 14:24:08 N.Kojima　   空ﾀｸﾞ挿入処理削除
    '　　　：2004/11/02 (Tue) 14:54:45 Y.Yamagishi  不具合No.69対応(RETICLE_STATUS_FLAG,ERROR_FLAG,GARBAGE_INSPECTION削除)
    '　　　：2005/01/21 (Fri) 09:09:26 N.Kasai      ｷｬﾘｱ目的位置ID、ｷｬﾘｱ目的位置名を追加　不具合№327
    '　　　：2005/02/17 (Thu) 15:28:08 N.Kasai      応答MSG追加(ﾚﾁｸﾙﾏﾆｭｱﾙ搬送)
    '　　　：2005/02/28 (Mon) 10:41:44 N.Kojima     応答ﾀｸﾞ"DEST"を"DEST_POSITION_ID"に変更(改善№512)
    Public Function pubblnRtclList____Sel(ByRef ltypRtclList2 As RtclList2, _
                                          ByRef ltypRtclList As List(Of RtclList), _
                                          ByRef llngRtclListCnt As Integer) As Boolean
                                         
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ
        
        Try

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry = New TfMsgAry
            
            '@初期設定
            pstrMessageName = "レチクル情報取得"
            pubblnRtclList____Sel = False
            
            With ltypRtclList2
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
                If .strClassDivison <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivison)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                '@機種ｺｰﾄﾞ
                If .strReticlePdCode <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_PD_CODE, .strReticlePdCode)
                Else
                    Call lrMsg.addString(CPstrRETICLE_PD_CODE, CPstrMsgNull)
                End If
                '@ﾏｽｸﾊﾟﾀｰﾝ
                If .strReticleMaskPattern <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_MASKPATTERN, .strReticleMaskPattern)
                Else
                    Call lrMsg.addString(CPstrRETICLE_MASKPATTERN, CPstrMsgNull)
                End If
                
                '@装置ﾘｽﾄ
                llngCnt = 0
                If .lngWpListCnt > 0 Then
                    Do While .typWpList.Count -1 >= llngCnt
                        If .typWpList(llngCnt).strWpID <> vbNullString Then
                            Call ltMsg.addString(CPstrWP_ID, .typWpList(llngCnt).strWpID)
                        Else
                            Call ltMsg.addString(CPstrWP_ID, CPstrMsgNull)
                        End If
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                        llngCnt = llngCnt + 1
                    Loop
                Else
                    ltMsg.Clear
                End If
                
                Call lrMsg.addMsgAry(CPstrWP_LIST, lrAry)
                lrAry.Clear
                
                '@ﾚﾁｸﾙ型番
                If .strReticleName <> vbNullString Then
                    Call lrMsg.addString(CPstrRETICLE_NAME, .strReticleName)
                Else
                    Call lrMsg.addString(CPstrRETICLE_NAME, CPstrMsgNull)
                End If
            
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrrtcllist____, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@ｱﾚｰ取得
                    Call laMsg.getMsgAry(CPstrRETICLE_LIST, laAry)
                    '@要素数格納
                    llngRtclListCnt = laAry.Count
                    '@要素数が0以外ならﾃﾞｰﾀ格納
                    If llngRtclListCnt <> 0 Then
                        If ltypRtclList Is Nothing Then
                            ltypRtclList = New List(Of RtclList)
                        End If
                        Do While (ltypRtclList.Count < llngRtclListCnt)
                            ltypRtclList.Add(New RtclList)
                        Loop

                        Dim ltypRtclListTmp As RtclList = New RtclList

                        llngCnt = 0
                        For Each ltMsg1 In laAry
                            With ltypRtclListTmp
                                Call ltMsg1.getString(CPstrRETICLE_ID, .lstrReticleID)                              'ﾚﾁｸﾙID
                                Call ltMsg1.getString(CPstrRETICLE_STATUS_ITEM_ID, .lstrReticleStatusItemID)        'ﾚﾁｸﾙ状態項目ID
                                Call ltMsg1.getString(CPstrRETICLE_STATUS_ITEM_NAME, .lstrReticleStatusItemName)    'ﾚﾁｸﾙ状態項目名
                                Call ltMsg1.getString(CPstrCURRENT_POSITION_ID, .lstrCurrentPositionID)             'ﾚﾁｸﾙ現在位置ID
                                Call ltMsg1.getString(CPstrCURRENT_POSITION_NAME, .lstrCurrentPositionName)         'ﾚﾁｸﾙ現在位置名
                                Call ltMsg1.getString(CPstrWP_IN_FLAG, .lstrWPInFlag)                               '装置内ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrARRIVE_TIME, .lstrArriveTime)                            'ﾚﾁｸﾙ入荷日
                                Call ltMsg1.getString(CPstrREASON_CODE, .lstrReasonCode)                            'ｴﾗｰ理由
                                Call ltMsg1.getString(CPstrREASON_COMMENTS, .lstrReasonComment)                     'ｴﾗｰｺﾒﾝﾄ
                                Call ltMsg1.getString(CPstrSMIF_ID, .lstrSmifID)                                    'SMIFID
                                Call ltMsg1.getString(CPstrEDIT_TIME, .lstrEditTime)                                '最終更新日
                                Call ltMsg1.getString(CPstrSTOCKER_IN_FLAG, .lstrStockerInFlag)                     'ｽﾄｯｶｰ内ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrCARRIER_STAT_ID, .strCarrierStatID)                      'ｷｬﾘｱ状態
                                Call ltMsg1.getString(CPstrDEST_POSITION_ID, .strDestPositionID)                    'ｷｬﾘｱ目的位置ID(搬送先)
                                Call ltMsg1.getString(CPstrDEST_NAME, .strDestName)                                 'ｷｬﾘｱ目的位置名(搬送先)
                                Call ltMsg1.getString(CPstrTRANSFER_STATUS, .strTransferStatus)                     '搬送ｽﾃｰﾀｽ(1:搬入予定、2:搬入可能、3:搬入済、4:搬出可能)
                                Call ltMsg1.getString(CPstrTRANSFER_STATUS_NAME, .strTransferStatusName)            '搬送ｽﾃｰﾀｽ名(搬送先)
                                
                                ltypRtclList(llngCnt) = ltypRtclListTmp

                                llngCnt = llngCnt + 1
                                
                            End With
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnRtclList____Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypRtclList2.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@解放
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnGuidSendMessage_Sel
    '機　能：ﾒｰﾙ送信
    '引　数：ltypSendMessageList：ﾒｰﾙ送信要求構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/05/06 (Fri) 09:21:23 N.Kasai
    '更新日：2005/05/06 (Fri) 09:21:23
    '備　考：
    Public Function pubblnGuidSendMessage_Sel(ByRef ltypSendMessageList As SendMessageList) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg2             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry2             As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim ltMsg1             As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)-受信
        Dim lstrRET            As String            '応答取得
        Dim llngCnt           As Integer            'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            ltMsg2 = New TfMsg
            lrAry2 = New TfMsgAry
            ltMsg1 = New TfMsg

            '@初期設定
            pstrMessageName = "メール送信"
            
            pubblnGuidSendMessage_Sel = False
            

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypSendMessageList
            
                '@APOﾘｽﾄ
                For llngCnt = 0 To .lngMessageListCnt -1
                    If .typMessageList(llngCnt).strApoCode <> vbNullString Then
                        Call ltMsg.addString(CPstrAPO_CODE, .typMessageList(llngCnt).strApoCode)
                    Else
                        Call ltMsg.addString(CPstrAPO_CODE, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    Call ltMsg.Clear
                Next
                Call lrMsg.addMsgAry(CPstrMESSAGE_LIST, lrAry)
                Call lrAry.Clear
                
                '@宛先ﾘｽﾄ
                For llngCnt = 0 To .lngMailListCnt -1
                    If .typMailList(llngCnt).strMailAddress <> vbNullString Then
                        Call ltMsg2.addString(CPstrMAIL_ADDRESS, .typMailList(llngCnt).strMailAddress)
                    Else
                        Call ltMsg2.addString(CPstrMAIL_ADDRESS, CPstrMsgNull)
                    End If
                    Call lrAry2.Add(ltMsg2)
                    Call ltMsg2.Clear
                Next
                Call lrMsg.addMsgAry(CPstrMAIL_LIST, lrAry2)
                Call lrAry2.Clear
                
                '@ﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ内容
                If .strMessage <> vbNullString Then
                    Call lrMsg.addString(CPstrMESSAGE, .strMessage)
                Else
                    Call lrMsg.addString(CPstrMESSAGE, CPstrMsgNull)
                End If
                
                '@ﾒｰﾙｻﾌﾞｼﾞｪｸﾄ
                If .strMailSubject <> vbNullString Then
                    Call lrMsg.addString(CPstrMAIL_SUBJECT, .strMailSubject)
                Else
                    Call lrMsg.addString(CPstrMAIL_SUBJECT, CPstrMsgNull)
                End If
                
                '@ﾒｰﾙ本文
                If .strMailContents <> vbNullString Then
                    Call lrMsg.addString(CPstrMAIL_CONTENTS, .strMailContents)
                Else
                    Call lrMsg.addString(CPstrMAIL_CONTENTS, CPstrMsgNull)
                End If
                
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrguidsendmessage, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnGuidSendMessage_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypSendMessageList.strMsgVer)

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
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            ltMsg2 = Nothing
            lrAry2 = Nothing
            ltMsg1 = Nothing

        End Try
    End Function

    '関数名：pubblnLotGetRestrict_Sel
    '機　能：時間制限取得
    '引　数：lstrSBID           ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrMsgVer         ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID          ：ﾛｯﾄID
    '　　　：ltypLotGetRestrict ：時間制限格納構造体
    '戻り値：True：成功/False：失敗
    '作成日：2005/05/17 (Tue) 16:40:58 S.Deguchi
    '更新日：2005/05/17 (Tue) 16:40:58
    '備　考：
    Public Function pubblnLotGetRestrict_Sel(ByVal lstrSBID As String, _
                                             ByVal lstrMsgVer As String, _
                                             ByVal lstrLotID As String, _
                                             ByRef ltypLotGetRestrict As LotGetRestrict) As Boolean

        Dim lrMsg              As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg              As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET            As String            '応答取得
            
        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@初期設定
            pstrMessageName = "時間制限取得"
            pubblnLotGetRestrict_Sel = False
                
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_getrestrict, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypLotGetRestrict
                        '@受信ﾒｯｾｰｼﾞ取得
                        Call laMsg.getString(CPstrRESTRICT_TYPE_ID, .strRestrictTypeID)             '時間制限種別
                        Call laMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                        '制限時間
                        Call laMsg.getString(CPstrWARN_TIME, .strWarnTime)                          '警告時間
                        Call laMsg.getString(CPstrFROM_OP_ID, .strFromOpId)                         '開始大工程ID
                        Call laMsg.getString(CPstrFROM_STEP_ID, .strFromStepId)                     '開始小工程ID
                        Call laMsg.getString(CPstrTO_OP_ID, .strToOpId)                             '終了大工程ID
                        Call laMsg.getString(CPstrTO_STEP_ID, .strToStepId)                         '終了小工程ID
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnLotGetRestrict_Sel = True
                
                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            lrMsg = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnCarrCFList_Sel
    '機　能：CFｷｬﾘｱ一覧取得
    '引　数：ltypCFListRec  ：要求構造体
    '　　　：ltypCFListAns  ：応答構造体
    '戻り値：True：成功、False：失敗
    '作成日：2005/05/19 (Thu) 15:41:21 N.Kasai
    '更新日：2009/10/05 (Mon) 17:22:19 N.Kojima
    '備　考：
    '　　　：2005/06/06 (Mon) 09:04:04 N.Kasai      不要ﾀｸﾞの削除
    '　　　：2009/10/05 (Mon) 17:22:19 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Public Function pubblnCarrCFList_Sel(ByRef ltypCFListRec As CFListRec, _
                                         ByRef ltypCFListAns As CFListAns, _
                                         ByVal lstrVaFlag As String, _
                                         ByVal lstrTpalClass As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "CFキャリア一覧取得"
            pubblnCarrCFList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry

            'NSYS リスト初期化
            If ltypCFListAns.typCFList Is Nothing Then
                ltypCFListAns.typCFList = New List(Of CFList)
            End If

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypCFListRec

                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@TFTﾛｯﾄID
                If .strTFTLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrTFT_LOT_ID, .strTFTLotID)
                Else
                    Call lrMsg.addString(CPstrTFT_LOT_ID, CPstrMsgNull)
                End If

                '@WF枚数
                If .strWfNum <> vbNullString Then
                    Call lrMsg.addString(CPstrWF_QUANTITY, .strWfNum)
                Else
                    Call lrMsg.addString(CPstrWF_QUANTITY, CPstrMsgNull)
                End If

                '@無機ﾌﾗｸﾞ
                If lstrVaFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrVA_FLAG, lstrVaFlag)
                Else
                    Call lrMsg.addString(CPstrVA_FLAG, CPstrMsgNull)
                End If
            
                '@TPAL設定
                If lstrTpalClass <> vbNullString Then
                    Call lrMsg.addString(CPstrTPAL_CLASS, lstrTpalClass)
                Else
                    Call lrMsg.addString(CPstrTPAL_CLASS, CPstrMsgNull)
                End If
            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrcflist__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrCARRIER_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数をﾘｽﾄ件数として格納
                    ltypCFListAns.llngCFListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypCFListAns.llngCFListCnt > 0 Then

                        '@構造体定義
                        Do While (ltypCFListAns.typCFList.Count < ltypCFListAns.llngCFListCnt)
                            ltypCFListAns.typCFList.Add(New CFList)
                        Loop

                        Dim typCFListTmp As CFList = New CFList

                        '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                        llngCnt = 0

                        For Each ltMsg In laAry

                            '@受信結果取得
                            With typCFListTmp

                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)    'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)            'ﾛｯﾄID
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)              '機種
                                Call ltMsg.getString(CPstrWF_QUANTITY, .strWfNum)       '数量(WF)
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipNum)   '数量(CHIP)
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)    '種別
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strPriority)   '優先度
                            End With

                            ltypCFListAns.typCFList(llngCnt) = typCFListTmp

                            '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnCarrCFList_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypCFListRec.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnCarrCfCurstate_Sel
    '機　能：CFｷｬﾘｱ状態確認
    '引　数：ltypCFListRec：要求構造体
    '戻り値：True：成功/False：失敗
    '作成日：2005/05/19 (Thu) 15:50:55 N.Kasai
    '更新日：2005/06/06 (Mon) 09:01:45 N.Kasai
    '備　考：
    '　　　：2005/06/06 (Mon) 09:01:45 N.Kasai      不要ﾀｸﾞの整理
    Public Function pubblnCarrCfCurstate_Sel(ByRef ltypCFListRec As CFListRec) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ＣＦキャリア状態確認"
            pubblnCarrCfCurstate_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypCFListRec
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@TFTﾛｯﾄID
                If .strTFTLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrTFT_LOT_ID, .strTFTLotID)
                Else
                    Call lrMsg.addString(CPstrTFT_LOT_ID, CPstrMsgNull)
                End If
                '@ｷｬﾘｱID
                If .strCFCarrierID <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCFCarrierID)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                '@WF枚数
                If .strWfNum <> vbNullString Then
                    Call lrMsg.addString(CPstrWF_QUANTITY, .strWfNum)
                Else
                    Call lrMsg.addString(CPstrWF_QUANTITY, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrcarrcfcurstate, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnCarrCfCurstate_Sel = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypCFListRec.strMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
                    
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnWfCngOdf_Upd
    '機　能：ODFｳｪﾊ登録
    '引　数：ltypWfChgOdfRec：ODF要求格納構造体
    '戻り値：True：成功/False：失敗
    '作成日：2005/05/20 (Fri) 12:52:06 N.Kasai
    '更新日：2006/01/17 (Tue) 17:43:03 N.Kasai
    '備　考：
    '　　　：2006/01/17 (Tue) 17:43:03 N.Kasai      応答ﾒｯｾｰｼﾞ追加(COVER
    Public Function pubblnWfCngOdf_Upd(ByRef ltypWfChgOdfRec As WfChgOdfRec, _
                                             ByRef lstrCoverFlag As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try
            
            pstrMessageName = "ODFウェハ登録"
            pubblnWfCngOdf_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypWfChgOdfRec
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ODFﾘｽﾄ
                For llngCnt = 0 To .lngOdfListCnt -1
                    If .typOdfList(llngCnt).strSlotPosition <> vbNullString Then
                        Call ltMsg.addString(CPstrSLOT_POSITION, .typOdfList(llngCnt).strSlotPosition)
                    Else
                        Call ltMsg.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                    End If
                    If .typOdfList(llngCnt).strTftWfID <> vbNullString Then
                        Call ltMsg.addString(CPstrTFT_WF_ID, .typOdfList(llngCnt).strTftWfID)
                    Else
                        Call ltMsg.addString(CPstrTFT_WF_ID, CPstrMsgNull)
                    End If
                    If .typOdfList(llngCnt).strCfWfID <> vbNullString Then
                        Call ltMsg.addString(CPstrCF_WF_ID, .typOdfList(llngCnt).strCfWfID)
                    Else
                        Call ltMsg.addString(CPstrCF_WF_ID, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    Call ltMsg.Clear
                Next
                Call lrMsg.addMsgAry(CPstrODF_LIST, lrAry)
                Call lrAry.Clear
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrwf__chgodf__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrCOVER_FLAG, lstrCoverFlag)        '貼り合せ完了ﾌﾗｸﾞ
                    '@関数の処理結果(成功)格納
                    pubblnWfCngOdf_Upd = True

                '@失敗の場合(false)
                Case CPstrFALSE
                
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypWfChgOdfRec.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

        End Try
    End Function

    '関数名：pubblnWfOdfList_Sel
    '機　能：ODFｳｪﾊ結果取得
    '引　数：ltypWfOdfListRec：要求格納構造体
    '　　　：ltypWfOdfListAns：応答格納構造体
    '戻り値：True：成功/False：失敗
    '作成日：2005/05/20 (Fri) 13:00:07 N.Kasai
    '更新日：2006/01/17 (Tue) 14:21:00 N.Kasai
    '備　考：
    '　　　：2006/01/17 (Tue) 14:21:00 N.Kasai      ODF部分貼り合せ機能追加(仕様変更)
    Public Function pubblnWfOdfList_Sel(ByRef ltypWfOdfListRec As WfOdfListRec, ByRef ltypWfOdfListAns As WfOdfListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ(Temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ

        Try

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry = New TfMsgAry

            '@初期設定
            pstrMessageName = "ODFウェハ結果取得"
            pubblnWfOdfList_Sel = False

            With ltypWfOdfListRec
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
                End If
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@ﾃﾞｰﾀ取得先(0:DB、1:WP)
                If .strFromType <> vbNullString Then
                    Call lrMsg.addString(CPstrFROM_TYPE, .strFromType)
                Else
                    Call lrMsg.addString(CPstrFROM_TYPE, CPstrMsgNull)
                End If
                
                '@TFTWFﾘｽﾄ
                llngCnt = 0
                If .lngTftWfListCnt > 0 Then
                    Do While .typTftWfList.Count -1 >= llngCnt
                        If .typTftWfList(llngCnt).strWfId <> vbNullString Then
                            Call ltMsg.addString(CPstrWF_ID, .typTftWfList(llngCnt).strWfId)
                        Else
                            Call ltMsg.addString(CPstrWF_ID, CPstrMsgNull)
                        End If
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                        llngCnt = llngCnt + 1
                    Loop
                Else
                    ltMsg.Clear
                End If

                Call lrMsg.addMsgAry(CPstrTFT_WFLIST, lrAry)
                lrAry.Clear
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrwf__odflist_, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@要素数格納
                    With ltypWfOdfListAns

                        Call laMsg.getString(CPstrSLOT_SIZE, .strSlotSize)                      'Unloaderｷｬﾘｱのｽﾛｯﾄ数

                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrODF_LIST, laAry)

                        .lngOdfListCnt = laAry.Count
                        '@要素数が0以外ならﾃﾞｰﾀ格納
                        If .lngOdfListCnt > 0 Then
                            If .typOdfList Is Nothing Then
                                .typOdfList = New List(Of OdfList)
                            End If
                            Do While (.typOdfList.Count < .lngOdfListCnt)
                                .typOdfList.Add(New OdfList)
                            Loop

                            Dim typOdfListTmp As OdfList = New OdfList

                            llngCnt = 0
                            For Each ltMsg1 In laAry
                                With typOdfListTmp
                                    Call ltMsg1.getString(CPstrSLOT_POSITION, .strSlotPosition)             'ｽﾛｯﾄ番号
                                    Call ltMsg1.getString(CPstrTFT_WF_ID, .strTftWfID)                      'TFTWFID
                                    Call ltMsg1.getString(CPstrCF_WF_ID, .strCfWfID)                        'CFWFID
                                    Call ltMsg1.getString(CPstrODF_COVER_FIX_FLAG, .strOdfCoverFixFlag)     'ODF貼り合せ済みﾌﾗｸﾞ(0:未、1:済)
                                End With
                                .typOdfList(llngCnt) = typOdfListTmp

                                llngCnt = llngCnt + 1
                            Next
                        End If

                    End With

                    '@関数の処理結果(成功)格納
                    pubblnWfOdfList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypWfOdfListRec.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@解放
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnLotTpalCombResult_Sel
    '機　能：TPALﾛｯﾄ貼り合わせ実績取得
    '引　数：lstrlot_tpalcombresultVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID                  ：ﾛｯﾄID(TFT基板側)
    '　　　：lstrVaFlag                 ：ﾛｯﾄID(TFT基板側)無機ﾌﾗｸﾞ(有機：0/無機：1)
    '　　　：lstrLotID                  ：ﾛｯﾄID(TFT基板側)TPAL設定(ﾊﾞｯﾁ/左右貼合情報)
    '　　　：ltypCoverCompLot           ：TPAL貼り合わせ実績構造体
    '戻り値：True：正常、False：異常
    '作成日：2005/07/22 (Fri) 12:01:56 N.Kojima
    '更新日：2005/07/22 (Fri) 12:01:56
    '備　考：
    Public Function pubblnLotTpalCombResult_Sel(ByVal lstrlot_tpalcombresultVer As String, _
                                                ByVal lstrLotID As String, _
                                                ByVal lstrVaFlag As String, _
                                                ByVal lstrTpalClass As String, _
                                                ByRef ltypCoverCompLot As CoverCompLot) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "TPALロット貼り合わせ実績取得"
            pubblnLotTpalCombResult_Sel = False

            '@ｵﾌﾞｼﾞｪｸﾄの作成
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            lrAry = New TfMsgAry

            'NSYS リスト初期化
            If ltypCoverCompLot.typCoverCompLotList Is Nothing Then
                ltypCoverCompLot.typCoverCompLotList = New List(Of CoverCompLotList)
            Else
                ltypCoverCompLot.typCoverCompLotList.Clear()
            End If

            '@=======================
            '@ 要求TAG作成
            '@=======================
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_tpalcombresultVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_tpalcombresultVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾛｯﾄID(TFT基板ﾛｯﾄID(親ﾛｯﾄ))
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            '@無機ﾌﾗｸﾞ
            If lstrVaFlag <> vbNullString Then
                Call lrMsg.addString(CPstrVA_FLAG, lstrVaFlag)
            Else
                Call lrMsg.addString(CPstrVA_FLAG, CPstrMsgNull)
            End If

            '@TPAL設定
            If lstrTpalClass <> vbNullString Then
                Call lrMsg.addString(CPstrTPAL_CLASS, lstrTpalClass)
            Else
                Call lrMsg.addString(CPstrTPAL_CLASS, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_tpalcombresult, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    With ltypCoverCompLot

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ取得(貼り合わせ済みTPALﾛｯﾄﾘｽﾄ)
                        Call laMsg.getMsgAry(CPstrCOVER_COMP_LOT_LIST, laAry)

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数をﾃﾞｰﾀ件数として格納
                        .lngCoverCompLotListCnt = laAry.Count

                        '@貼り合わせ済みTPALﾛｯﾄが1件以上存在するか
                        If .lngCoverCompLotListCnt > 0 Then

                            '@配列定義
                            Dim typCoverCompLotListTmp As CoverCompLotList = New CoverCompLotList

                            '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                            llngCnt = 0

                            For Each ltMsg In laAry

                                '@受信結果取得
                                With typCoverCompLotListTmp

                                    Call ltMsg.getString(CPstrTPAL_CARRIER_ID, .strTpalCarrierID)                '使用TPALｷｬﾘｱID
                                    Call ltMsg.getString(CPstrTPAL_LOT_ID, .strTpalLotId)                        '使用TPALﾛｯﾄID
                                    Call ltMsg.getString(CPstrCHIP_COMB_QUANTITY, .strChipCombQuantity)          '貼数
                                    Call ltMsg.getString(CPstrCHIP_OUT_QUANTITY, .strChipOutQuantity)            '不良数
                                    Call ltMsg.getString(CPstrCHIP_REST_QUANTITY, .strChipRestQuantity)          '残数
                                End With

                                .typCoverCompLotList.Add(typCoverCompLotListTmp)

                                '@ﾙｰﾌﾟｶｳﾝﾀをｲﾝｸﾘﾒﾝﾄ
                                llngCnt = llngCnt + 1
                            Next
                        End If

                        '@戻り値に"True：取得成功"をｾｯﾄ
                        pubblnLotTpalCombResult_Sel = True

                    End With


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_tpalcombresultVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            lrAry = Nothing

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnInvCombAbleTpal_Sel
    '機　能：TPAL貼り合わせ可能数取得
    '引　数：lstrinv_combabletpalVer：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotID              ：ﾛｯﾄID(TFT基板側)
    '　　　：lstrTotalLotNum        ：合計ﾛｯﾄ数
    '　　　：lstrTotalChipNum       ：合計ﾁｯﾌﾟ数
    '戻り値：True：正常、False：異常
    '作成日：2005/07/22 (Fri) 13:46:22 N.Kojima
    '更新日：2005/07/22 (Fri) 13:46:22
    '備　考：
    Public Function pubblnInvCombAbleTpal_Sel(ByVal lstrinv_combabletpalVer As String, _
                                              ByVal lstrLotID As String, _
                                              ByRef lstrTotalLotNum As String, _
                                              ByRef lstrTotalChipNum As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            '@初期設定
            pstrMessageName = "TPAL貼り合わせ可能数取得"
            pubblnInvCombAbleTpal_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_combabletpalVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_combabletpalVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID(TFT基板ﾛｯﾄID(親ﾛｯﾄ))
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_combabletpal, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞ取得
                    Call laMsg.getString(CPstrTOTAL_LOT_NUM, lstrTotalLotNum)           '貼合せ可能総ﾛｯﾄ数(TPAL)
                    Call laMsg.getString(CPstrTOTAL_CHIP_NUM, lstrTotalChipNum)         '貼合せ可能総ﾁｯﾌﾟ数(TPAL)
                 
                    '@関数の処理結果(成功)格納
                    pubblnInvCombAbleTpal_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrinv_combabletpalVer)
                    
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

    '関数名：pubblnLotTpalInfo_Sel
    '機　能：TPALロット情報取得
    '引　数：lstrlot_tpalinfoVer    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrTpalCarrierID      ：ｷｬﾘｱID(TPALﾛｯﾄ)
    '　　　：lstrTFTLotID           ：ﾛｯﾄID(TFT基板側)
    '　　　：lstrTpalLotID          ：TPALﾛｯﾄID
    '　　　：lstrChipQuantity       ：TPALﾛｯﾄﾁｯﾌﾟ数
    '　　　：lstrLimitTime          ：有効期限
    '　　　：lstrLotLastUpdeta      ：最終更新日
    '戻り値：True：正常、False：異常
    '作成日：2005/07/22 (Fri) 13:56:34 N.Kojima
    '更新日：2005/07/22 (Fri) 13:56:34
    '備　考：
    Public Function pubblnLotTpalInfo_Sel(ByVal lstrlot_tpalinfoVer As String, _
                                          ByVal lstrTpalCarrierID As String, _
                                          ByVal lstrTFTLotID As String, _
                                          ByRef lstrTpalLotID As String, _
                                          ByRef lstrChipQuantity As String, _
                                          ByRef lstrLimitTime As String, _
                                          ByRef lstrLotLastUpdeta As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        
        Try
            
            '@初期設定
            pstrMessageName = "TPALロット情報取得"
            pubblnLotTpalInfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_tpalinfoVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_tpalinfoVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｷｬﾘｱID(TPALﾛｯﾄ)
            If lstrTpalCarrierID <> vbNullString Then
                Call lrMsg.addString(CPstrCARRIER_ID, lstrTpalCarrierID)
            Else
                Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID(TFT基板側)
            If lstrTFTLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrTFTLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_tpalinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞ取得
                    Call laMsg.getString(CPstrLOT_ID, lstrTpalLotID)                    'TPALﾛｯﾄID
                    Call laMsg.getString(CPstrCHIP_QUANTITY, lstrChipQuantity)          'TPALﾛｯﾄﾁｯﾌﾟ数
                    Call laMsg.getString(CPstrLIMIT_TIME, lstrLimitTime)                '有効期限
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, lstrLotLastUpdeta)       '最終更新日
                 
                    '@関数の処理結果(成功)格納
                    pubblnLotTpalInfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_tpalinfoVer)
                    
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

    '関数名：pubblnCarrExchange_Upd
    '機　能：強制ｷｬﾘｱ交換
    '引　数：ltypPONTA：ｷｬﾘｱ強制交換格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2005/08/10 (Wed) 14:59:48 N.Kasai
    '更新日：2005/08/10 (Wed) 14:59:48
    '備　考：
    Public Function pubblnCarrForcedmove_Upd(ByRef ltypCarrierForcedmove As CarrierForcedmove) As Boolean


        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try

            pstrMessageName = "強制キャリア交換"

            pubblnCarrForcedmove_Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成

            With ltypCarrierForcedmove
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@交換元ｷｬﾘｱID
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

                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrcarrforcedmove, lrMsg, laMsg)

                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE

                        '@受信ﾒｯｾｰｼﾞ取得
                        Call laMsg.getString(CPstrTO_CARRIER_ID, .strToCarrierId)   '交換先ｷｬﾘｱID

                        '@関数の処理結果(成功)格納
                        pubblnCarrForcedmove_Upd = True

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

                '@解放
                lrMsg = Nothing
                laMsg = Nothing
                ltMsg = Nothing
                laAry = Nothing
            End With

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnMasRoleEmpList_Sel
    '機　能：職制社員ﾘｽﾄ取得
    '引　数：ltypMasRoleEmpListReq：要求ﾒｯｾｰｼﾞ
    '　　　：ltypMasRoleEmpListAns：応答ﾒｯｾｰｼﾞ
    '戻り値：True:成功/False:失敗
    '作成日：2005/11/21 (Mon) 11:18:09 S.Deguchi
    '更新日：2005/11/21 (Mon) 11:18:09
    '備　考：
    Public Function pubblnMasRoleEmpList_Sel(ByRef ltypMasRoleEmpListReq As MasRoleEmpListReq, _
                                             ByRef ltypMasRoleEmpListAns As MasRoleEmpListAns) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "職制社員リスト取得"
            pubblnMasRoleEmpList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypMasRoleEmpListReq
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                                                      'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                                                  'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                If .strRole <> vbNullString Then
                    Call lrMsg.addString(CPstrROLE, .strRole)                                                       '職制
                Else
                    Call lrMsg.addString(CPstrROLE, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_roleemplist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果格納
                    '@ｱﾚｲを格納
                    Call laMsg.getMsgAry(CPstrEMP_LIST, laAry)                                                      '職制ﾘｽﾄ

                    '@職制社員一覧内容
                    With ltypMasRoleEmpListAns
                        '@ﾘｽﾄｶｳﾝﾄ格納
                        .lngRoleEmpListCnt = laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngRoleEmpListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            '@配列の要素数を設定
                            .typRoleEmpList = New List(Of DeptEmpList)

                            '@配列の要素数を設定
                            Do While (.typRoleEmpList.Count < .lngRoleEmpListCnt)
                                .typRoleEmpList.Add(New DeptEmpList)
                            Loop

                            Dim typRoleEmpListTmp As DeptEmpList = New DeptEmpList
                            

                            llngCnt = 0

                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Call ltMsg.getString(CPstrEMP_ID, typRoleEmpListTmp.strEmpID)                '作業者ID
                                Call ltMsg.getString(CPstrEMP_NAME, typRoleEmpListTmp.strEmpName)            '作業者名
                                Call ltMsg.getString(CPstrMAIL_ADDRESS, typRoleEmpListTmp.strMailAddress)    'ﾒｰﾙｱﾄﾞﾚｽ
                                .typRoleEmpList(llngCnt) = typRoleEmpListTmp
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnMasRoleEmpList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypMasRoleEmpListReq.strMsgVer)

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

    '関数名：pubblnEqWpMsgList_Sel
    '機　能：装置状態ﾒｯｾｰｼﾞ取得
    '引　数：ltypEqWpMsgListReq：要求格納構造体
    '　　　：ltypEqWpMsgListAns：応答格納構造体
    '戻り値：Ture:正常、False:異常
    '作成日：2005/12/16 (Fri) 15:59:09 N.Kasai
    '更新日：2005/12/16 (Fri) 15:59:09
    '備　考：
    Public Function pubblnEqWpMsgList_Sel(ByRef ltypEqWpMsgListReq As EqWpMsgListReq, _
                                          ByRef ltypEqWpMsgListAns As EqWpMsgListAns) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾀ
        
        Try

            '@初期設定
            pstrMessageName = "装置状態メッセージ取得"
            pubblnEqWpMsgList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypEqWpMsgListReq
            
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)          'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)              'WPID
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If

                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__wpmsglist, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    
                    Case CPstrTRUE
                        '@受信結果取得
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                        Call laMsg.getMsgAry(CPstrMSG_LIST, laAry)
                        
                         With ltypEqWpMsgListAns
                            '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                            .llngMsgListCnt = laAry.Count
                            
                            '@配列があればﾃﾞｰﾀ格納
                            If .llngMsgListCnt > 0 Then
                                .typMsgList = New List(Of MsgList)

                                Do While (.typMsgList.Count < .llngMsgListCnt)
                                    .typMsgList.Add(New MsgList)
                                Loop

                                Dim typMsgListTmp As MsgList = New MsgList

                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                llngCnt = 0
                                For Each ltMsg In laAry
                                    '@受信結果取得
                                    Call ltMsg.getString(CPstrMESSAGE_ID, typMsgListTmp.strMessageID)    'ﾒｯｾｰｼﾞID
                                    Call ltMsg.getString(CPstrMESSAGE, typMsgListTmp.strMessage)         'ﾒｯｾｰｼﾞ
                                    .typMsgList(llngCnt) = typMsgListTmp
                                    llngCnt = llngCnt + 1
                                Next
                            End If
                        End With
                        
                        '@関数の処理結果(成功)格納
                        pubblnEqWpMsgList_Sel = True
                        
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, ltypEqWpMsgListReq.strMsgVer)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@「TRM01E　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
                
            End With
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMasWpUseList_Sel
    '機　能：装置状態ﾏｽﾀ取得
    '引　数：lstrmas_wpuselistVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypUseList()          ：格納ﾃﾞｰﾀ
    '　　　：llngUseListCnt         ：ﾃﾞｰﾀｶｳﾝﾄ
    '戻り値：True：正常、False：異常
    '作成日：2004/03/23 (Tue) 17:01:19 M.Miura
    '更新日：2005/12/16 (Fri) 13:10:12 N.Kasai
    '備　考：旧名称：pubblnMasEqUse_Sel
    '　　　：2005/02/23 (Wed) 13:39:54 N.Kojima　   応答ﾀｸﾞに「装置状態ﾓｰﾄﾞ」「停止ﾌﾗｸﾞ」追加(改善№524、525)
    '　　　：2005/12/16 (Fri) 13:10:12 N.Kasai      応答ﾀｸﾞにMESSAGE_ID,MESSAGEを追加
    Public Function pubblnMasWpUseList_Sel(ByVal lstrmas_wpuselistVer As String, _
                                           ByRef ltypUseList As List(Of UseList), _
                                           ByRef llngUseListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "装置状態マスタ取得"
            pubblnMasWpUseList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrmas_wpuselistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_wpuselistVer)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_wpuselist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrUSE_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                    llngUseListCnt = laAry.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngUseListCnt > 0 Then

                        ltypUseList = New List(Of UseList)

                        Do While (ltypUseList.Count < llngUseListCnt)
                            ltypUseList.Add(New UseList)
                        Loop

                        Dim ltypUseListTmp As UseList = New UseList

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            '@受信結果取得
                            With ltypUseListTmp
                                Call ltMsg.getString(CPstrUSE_ID, .strUseId)                        '装置状態ID
                                Call ltMsg.getString(CPstrUSE_NAME, .strUseName)                    '装置状態名
                                Call ltMsg.getString(CPstrUSE_ENABLE_MODE, .strUseEnableMode)       '装置状態ﾓｰﾄﾞ
                                Call ltMsg.getString(CPstrUSE_STOP_FLAG, .strUseStopFlag)           '停止ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrMESSAGE_ID, .strMessageID)                'ﾒｯｾｰｼﾞID
                                Call ltMsg.getString(CPstrMESSAGE, .strMessage)                     'ﾒｯｾｰｼﾞ
                                Call ltMsg.getString(CPstrNORMAL_STATE_FLAG, .strNormalStateFlag)   '装置状態ﾌﾗｸﾞ(0：通常以外、1:通常)
                                ltypUseList(llngCnt) = ltypUseListTmp
                            End With
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasWpUseList_Sel = True
                     
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_wpuselistVer)
                                
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnEqChguse_Ins
    '機　能：装置状態変更
    '引　数：lstreq__chguse__Ver    ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrEntryTime          ：登録日時(WP_EVENT_HISTORYの)
    '　　　：ltypUsechange          ：装置状態変更構造体
    '　　　：lstrClassDivision      ：処理区分
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/24 (Wed) 13:53:30 M.Miura
    '更新日：2007/03/23 (Fri) 08:44:33 N.Kojima
    '備　考：旧名称：pubblnUseChange_Ins
    '　　　：2005/12/16 (Fri) 15:04:11 N.Kasai      要求MSGにMESSAGE_IDを追加
    '　　　：2005/12/22 (Thu) 14:27:42 N.Kasai      要求ﾒｯｾｰｼﾞにPORT_LISTを追加
    '　　　：2006/01/13 (Fri) 12:28:29 N.Kasai      仕様変更↑PORT_LISTを削除
    '　　　：2007/03/23 (Fri) 08:44:33 N.Kojima     応答ﾀｸﾞに"ENTRY_TIME"を追加。(案件№01830)
    Public Function pubblnEqChguse_Ins(ByVal lstreq__chguse__Ver As String, _
                                        ByRef lstrEntryTime As String, _
                                        ByRef ltypUsechange As Usechange, _
                                        Optional ByVal lstrClassDivision As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "装置状態変更登録"
            pubblnEqChguse_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypUsechange
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@変更後装置状態ID
                If .strUseId <> vbNullString Then
                    Call lrMsg.addString(CPstrUSE_ID, .strUseId)
                Else
                    Call lrMsg.addString(CPstrUSE_ID, CPstrMsgNull)
                End If
                '@作業者ID
                If pstrUserID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                '@ｺﾒﾝﾄ
                If .strComments <> vbNullString Then
                    Call lrMsg.addString(CPstrCOMMENTS, .strComments)
                Else
                    Call lrMsg.addString(CPstrCOMMENTS, CPstrMsgNull)
                End If
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstreq__chguse__Ver <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstreq__chguse__Ver)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@WP停止ﾌﾗｸﾞ
                If .strWpStopFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_STOP_FLAG, .strWpStopFlag)
                Else
                    Call lrMsg.addString(CPstrWP_STOP_FLAG, CPstrMsgNull)
                End If
                '@変更前装置状態ID
                If .strOldUseID <> vbNullString Then
                    Call lrMsg.addString(CPstrOLD_USE_ID, .strOldUseID)
                Else
                    Call lrMsg.addString(CPstrOLD_USE_ID, CPstrMsgNull)
                End If
                '@ﾒｯｾｰｼﾞID
                If .strMessageID <> vbNullString Then
                    Call lrMsg.addString(CPstrMESSAGE_ID, .strMessageID)
                Else
                    Call lrMsg.addString(CPstrMESSAGE_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__chguse__, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrENTRY_TIME, lstrEntryTime)        '登録日時(WP_EVENT_HISTORY)
                
                    '@関数の処理結果(成功)格納
                    pubblnEqChguse_Ins = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstreq__chguse__Ver)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnPrOrderList_Sel
    '機　能：P/Rｵｰﾀﾞｰ一覧取得
    '引　数：lstrpr__orderlistVer   ：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：ltypPrOrderListAns     ：P/Rｵｰﾀﾞｰ格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2005/12/19 (Mon) 17:41:27 T.Kitagawa
    '更新日：2005/12/19 (Mon) 17:41:27
    '備　考：
    Public Function pubblnPrOrderList_Sel(ByVal lstrpr__orderlistVer As String, _
                                          ByRef ltypPrOrderListAns As PrOrderListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            '@初期設定
            pstrMessageName = "P/Rオーダー一覧取得"
            pubblnPrOrderList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrpr__orderlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrpr__orderlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrpr__orderlist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得：P/Rｵｰﾀﾞｰﾘｽﾄ
                    Call laMsg.getMsgAry(CPstrPR_ORDER_LIST, laAry)
                
                    With ltypPrOrderListAns
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納：P/Rｵｰﾀﾞｰﾃﾞｰﾀ数
                        .lngPrOrderListCnt = laAry.Count
                        
                        '@P/Rｵｰﾀﾞｰﾃﾞｰﾀ数が1件以上存在するか
                        If .lngPrOrderListCnt > 0 Then
                            
                            '@格納配列の領域確保
                            .typPrOrderList = New List(Of PrOrderList)

                            Do While (.typPrOrderList.Count < .lngPrOrderListCnt)
                                .typPrOrderList.Add(New PrOrderList)
                            Loop

                            Dim typPrOrderListTmp As PrOrderList = New PrOrderList
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                
                                '@受信結果取得
                                With typPrOrderListTmp
                                    
                                    Call ltMsg.getString(CPstrPR_ORDER_ID, .strPROrderID)               'P/RｵｰﾀﾞｰID
                                    Call ltMsg.getString(CPstrORDER_COMMENTS, .strOrderComments)        'ｵｰﾀﾞｰｺﾒﾝﾄ
                                    Call ltMsg.getString(CPstrGLOBAL_DEPT, .strGlobalDept)              '部門
                                    Call ltMsg.getString(CPstrCOST_CODE, .strCostCode)                  '原価ｺｰﾄﾞ
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)                '登録日時
                                    Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)                  '更新日時
                                    Call ltMsg.getString(CPstrEMP_ID, .strEmpID)                        '作業者ID
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                    '作業者名
                                End With
                                .typPrOrderList(llngCnt) = typPrOrderListTmp
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnPrOrderList_Sel = True
                     
                     
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrpr__orderlistVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnMasRecipeNameList_Sel
    '機　能：ﾚｼﾋﾟ一覧取得
    '引　数：lstrSbID                   ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrmas_recipenamelistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCategoryID             ：ｶﾃｺﾞﾘID
    '　　　：lstrWpID                   ：WPID
    '　　　：lstrRecipeID               ：ﾚｼﾋﾟID
    '　　　：ltypMasRecipeNameList：格納ﾃﾞｰﾀ
    '戻り値：True:成功、Flase：失敗
    '作成日：2004/08/26 (Thu) 13:17:02 T.Kitagawa
    '更新日：2005/07/06 (Wed) 12:10:40 N.Kasai
    '備　考：2004/11/09 (Tue) 15:45:18 Y.Yamagishi  装置IDを退避する処理(.strWPID = lstrWPID)を追加(不具合№188)
    '　　　：2005/07/06 (Wed) 12:10:40 N.Kasai      応答MSGにCOMMENTS追加
    Public Function pubblnMasRecipeNameList_Sel(ByVal lstrSBID As String, _
                                                ByVal lstrmas_recipenamelistVer As String, _
                                                ByVal lstrCategoryId As String, _
                                                ByVal lstrWpId As String, _
                                                ByVal lstrRecipeID As String, _
                                                ByRef ltypMasRecipeNameList As MasRecipeNameList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "レシピ一覧取得"
            pubblnMasRecipeNameList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                              'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            If lstrmas_recipenamelistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_recipenamelistVer)           'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            If lstrCategoryId <> vbNullString Then
                Call lrMsg.addString(CPstrCATEGORY_ID, lstrCategoryId)                  'ｶﾃｺﾞﾘID
            Else
                Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
            End If
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)                              'WPID
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            If lstrRecipeID <> vbNullString Then
                Call lrMsg.addString(CPstrRECIPE_ID, lstrRecipeID)                      'ﾚｼﾋﾟID
            Else
                Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_recipenamelist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypMasRecipeNameList
                        '@受信結果取得
                        Call laMsg.getMsgAry(CPstrRECIPE_LIST, laAry)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        .lngMasRecipeNameCnt = laAry.Count
                        .strWpID = lstrWpId                                                         '装置ID
                        If .lngMasRecipeNameCnt > 0 Then
                            .typMasRecipeName = New List(Of MasRecipeName)

                            Do While (.typMasRecipeName.Count < .lngMasRecipeNameCnt) 
                                .typMasRecipeName.Add(New MasRecipeName)
                            Loop

                            Dim typMasRecipeNameTmp As MasRecipeName = New MasRecipeName

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typMasRecipeNameTmp
                                    Call ltMsg.getString(CPstrRECIPE_ID, .strRecipeId)              'ﾚｼﾋﾟID
                                    Call ltMsg.getString(CPstrRECIPE_VERSION, .strRecipeVersion)    'ﾚｼﾋﾟﾊﾞｰｼﾞｮﾝ
                                    Call ltMsg.getString(CPstrDEFAULT_FLAG, .strDefaultFlag)        'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)               'ｺﾒﾝﾄ
                                End With
                                .typMasRecipeName(llngCnt) = typMasRecipeNameTmp
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasRecipeNameList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_recipenamelistVer)
                    
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
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnMatChkWPMaterial_Chk
    '機　能：装置使用部材判定
    '引　数：ltypChkMaterial        ：装置使用部材判定用構造体
    '　　　：lstrPdErrMsg           ：機種限定ｴﾗｰMsg格納用
    '　　　：lstrLimitErrMsg        ：部材期限判定ｴﾗｰMsg格納用
    '戻り値：True：成功、False：失敗
    '作成日：2006/04/13 (Thu) 16:48:58 N.Kojima
    '更新日：2006/10/03 (Tue) 15:13:00 N.Kojima
    '備　考：
    '　　　：2006/06/26 (Mon) 17:25:09 N.Kojima     機種限定機能追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/03 (Tue) 15:13:00 N.Kojima     応答ﾀｸﾞを"PD_ERR_MESS","LIMIT_ERR_MESS"に変更。(案件№01472)
    Public Function pubblnMatChkWPMaterial_Chk(ByRef ltypChkMaterial As ChkMaterial, _
                                               ByRef lstrPdErrMsg As String, _
                                               ByRef lstrLimitErrMsg As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用1
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ用2
        Dim llngCnt3            As Integer          'ｶｳﾝﾄ用3
        
        Dim lrAry1              As TfMsgAry         'ｱﾚｰ作成用
        Dim lrAry2              As TfMsgAry         'ｱﾚｰ作成用
        Dim lrAry3              As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg1              As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg2              As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg3              As TfMsg            'ｱﾚｰの各要素作成用
        
        Try
            
            pstrMessageName = "装置使用部材判定"
            pubblnMatChkWPMaterial_Chk = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg1 = New TfMsg
            ltMsg2 = New TfMsg
            ltMsg3 = New TfMsg
            lrAry1 = New TfMsgAry
            lrAry2 = New TfMsgAry
            lrAry3 = New TfMsgAry
                
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypChkMaterial
                
                'SB_ID
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
                
                '@処理区分(10:作業開始、46:装置使用開始、47:使用開始)
                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
                
                '@部材種別ID
                If .strMaterialTypeID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
                End If
                
                '@部材ID
                If .strMaterialID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_ID, .strMaterialID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_ID, CPstrMsgNull)
                End If
                
                '@部材管理ID
                If .strMaterialLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, .strMaterialLotID)
                Else
                    Call lrMsg.addString(CPstrMATERIAL_LOT_ID, CPstrMsgNull)
                End If
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                        
                '@作業開始(=CLASS_DIVISION:10)
                If .strClassDivision = CPstrCD10 Then
                
                    '@ﾛｯﾄID
                    If .strLotID <> vbNullString Then
                        Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                    Else
                        Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                    End If
                    
                    '@★★★★★★★★★★
                    '@　　部材ﾘｽﾄ作成
                    '@★★★★★★★★★★
                    
                    '@部材種別IDﾘｽﾄ分ﾙｰﾌﾟ
                    For llngCnt = 0 To .lngMaterialTypeCnt -1
                        With .typMaterialTypeList(llngCnt)
                            '@部材種別ID
                            If .strMaterialTypeID <> vbNullString Then
                                Call ltMsg1.addString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)
                            Else
                                Call ltMsg1.addString(CPstrMATERIAL_TYPE_ID, CPstrMsgNull)
                            End If
                                
                            '@部材IDﾘｽﾄ分ﾙｰﾌﾟ
                            For llngCnt2 = 0 To .lngMaterialCnt -1
                                With .typMaterialIDList(llngCnt2)
            
                                    '@部材ID
                                    If .strMaterialID <> vbNullString Then
                                        Call ltMsg2.addString(CPstrMATERIAL_ID, .strMaterialID)
                                    Else
                                        Call ltMsg2.addString(CPstrMATERIAL_ID, CPstrMsgNull)
                                    End If
                                        
                                    '@部材管理IDﾘｽﾄ分ﾙｰﾌﾟ
                                    For llngCnt3 = 0 To .lngMaterialLotCnt -1
                                        With .typMaterialLotIDList(llngCnt3)
                                        
                                            '@部材管理ID
                                            If .strMaterialLotID <> vbNullString Then
                                                Call ltMsg3.addString(CPstrMATERIAL_LOT_ID, .strMaterialLotID)
                                            Else
                                                Call ltMsg3.addString(CPstrMATERIAL_LOT_ID, CPstrMsgNull)
                                            End If
                                            
                                            Call lrAry3.Add(ltMsg3)
                                            ltMsg3.Clear
                                        End With
                                    Next
                                    Call ltMsg2.addMsgAry(CPstrMATERIAL_LOT_ID_LIST, lrAry3)
                                    lrAry3.Clear
                                    
                                    Call lrAry2.Add(ltMsg2)
                                    ltMsg2.Clear
                                End With
                            Next
                            Call ltMsg1.addMsgAry(CPstrMATERIAL_ID_LIST, lrAry2)
                            lrAry2.Clear
                                            
                            Call lrAry1.Add(ltMsg1)
                            ltMsg1.Clear
                        End With
                    Next
                            
                    Call lrMsg.addMsgAry(CPstrMATERIAL_LIST, lrAry1)
                    lrAry1.Clear
                Else
                    '@作業開始以外
                    
                    '@ﾛｯﾄID
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                    '@空ﾘｽﾄ
                    Call lrMsg.addMsgAry(CPstrMATERIAL_LIST, lrAry1)
                    lrAry1.Clear
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_chkwpmaterial, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrPD_ERR_MESS, lstrPdErrMsg)            '機種限定ｴﾗｰMsg
                    Call laMsg.getString(CPstrLIMIT_ERR_MESS, lstrLimitErrMsg)      '部材期限ｴﾗｰMsg
                    
                    '@関数の処理結果(成功)格納
                    pubblnMatChkWPMaterial_Chk = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypChkMaterial.strMsgVer)
                    
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
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            lrAry1 = Nothing
            lrAry2 = Nothing
            lrAry3 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            lrAry1 = Nothing
            lrAry2 = Nothing
            lrAry3 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnMatMaterialList_Sel
    '機　能：装置使用部材取得
    '引　数：lstrMsgVer         ：MsgVer
    '　　　：lstrWpId           ：装置ID
    '　　　：ltypMaterialList   ：装置部材情報格納用
    '戻り値：True：成功、False：失敗
    '作成日：2006/06/27 (Tue) 11:38:03 N.Kojima
    '更新日：2010/06/18 (Fri) 13:18:24 T.Oide
    '備　考：
    '　　　：2006/11/28 (Tue) 18:10:43 N.Kojima     応答に"VENDER_WARRANT_DAYS_JUDGE","ACCEPT_WARRANT_DAYS_JUDGE",
    '　　　：                                       "USE_VALID_PERIOD_JUDGE","WARNING_PERIOD_JUDGE",
    '　　　：                                       "VENDER_WARRANT_WARNING_DAYS_JUDGE","ACCEPT_WARRANT_WARNING_DAYS_JUDGE"を追加。(案件№01586)
    '　　　：2006/12/19 (Tue) 16:50:37 N.Kasai      応答ﾀｸﾞ追加(PARAMETER_ID)№01515
    '　　　：2010/06/18 (Fri) 13:18:52 T.Oide       VB異常終了(終了しない)の対応として修正
    Public Function pubblnMatMaterialList_Sel(ByVal lstrMsgVer As String, _
                                              ByVal lstrWpId As String, _
                                              ByRef ltypMaterialList As MaterialWPList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt1            As String           'ｶｳﾝﾄ用1
        Dim llngCnt2            As String           'ｶｳﾝﾄ用2
        Dim llngCnt3            As String           'ｶｳﾝﾄ用3
        Dim llngCnt4            As String           'ｶｳﾝﾄ用3
        Dim laAry1              As TfMsgAry         'ｱﾚｰ作成用
        Dim laAry2              As TfMsgAry         'ｱﾚｰ作成用
        Dim laAry3              As TfMsgAry         'ｱﾚｰ作成用
        Dim laAry4              As TfMsgAry         'ｱﾚｰ作成用
        Dim ltMsg1              As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg2              As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg3              As TfMsg            'ｱﾚｰの各要素作成用
        Dim ltMsg4              As TfMsg            'ｱﾚｰの各要素作成用
        
        Try
            
            pstrMessageName = "装置使用部材取得"
            pubblnMatMaterialList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            ltMsg2 = New TfMsg
            ltMsg3 = New TfMsg
            ltMsg4 = New TfMsg
            laAry1 = New TfMsgAry
            laAry2 = New TfMsgAry
            laAry3 = New TfMsgAry
            laAry4 = New TfMsgAry
                
            '@送信ﾒｯｾｰｼﾞ作成
            'SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmat_materiallist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    With ltypMaterialList
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ3取得
                        Call laMsg.getMsgAry(CPstrMATERIAL_LIST, laAry1)
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                        .lngMaterialTypeCnt = laAry1.Count
            
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngMaterialTypeCnt > 0 Then
                            '@領域確保
                            .typMaterialTypeList = New List(Of MaterialTypeList)
                            Do While (.typMaterialTypeList.Count < .lngMaterialTypeCnt)
                                .typMaterialTypeList.Add(New MaterialTypeList)
                            Loop
                            Dim typMaterialTypeTmp As MaterialTypeList = New MaterialTypeList

                            '@受信ﾒｯｾｰｼﾞｱﾚｲ1から各Msg取得
                            llngCnt1 = 0
                            
                            For Each ltMsg1 In laAry1
                                With typMaterialTypeTmp
                                    '@ﾃﾞｰﾀ格納
                                    Call ltMsg1.getString(CPstrMATERIAL_TYPE_ID, .strMaterialTypeID)    '部材種別ID
                                    Call ltMsg1.getString(CPstrPD_LIMIT_FLAG, .strPdLimitFlag)          '機種限定
                                    Call ltMsg1.getString(CPstrPARAMETER_ID, .strParameterID)           'ﾊﾟﾗﾒｰﾀ
              
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2取得
                                    Call ltMsg1.getMsgAry(CPstrMATERIAL_ID_LIST, laAry2)
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ2のｶｳﾝﾄ数
                                    .lngMaterialCnt = laAry2.Count
                
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                    If .lngMaterialCnt > 0 Then
                                        '@領域確保
                                        .typMaterialIDList = New List(Of MaterialIDList)
                                        Do While (.typMaterialIDList.Count < typMaterialTypeTmp.lngMaterialCnt)
                                            .typMaterialIDList.Add(New MaterialIDList)
                                        Loop
                                        Dim typMaterialIDLTmp As MaterialIDList = New MaterialIDList

                                        '@受信ﾒｯｾｰｼﾞｱﾚｲ2から各Msg取得
                                        llngCnt2 = 0
                                        
                                        For Each ltMsg2 In laAry2
                                            With typMaterialIDLTmp
                                                '@ﾃﾞｰﾀ格納
                                                Call ltMsg2.getString(CPstrMATERIAL_ID, .strMaterialID)      '部材ID
                    
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ3取得
                                                Call ltMsg2.getMsgAry(CPstrMATERIAL_LOT_ID_LIST, laAry3)
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ3のｶｳﾝﾄ格納
                                                .lngMaterialLotCnt = laAry3.Count
                                                
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ4取得
                                                Call ltMsg2.getMsgAry(CPstrPD_LIST, laAry4)
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ4のｶｳﾝﾄ格納
                                                .lngPdListCnt = laAry4.Count
                                                
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                                If .lngMaterialLotCnt > 0 Then
                                                    '@領域確保
                                                    If .typMaterialLotIDList Is Nothing Then
                                                        .typMaterialLotIDList = New List(Of MaterialLotIDList)
                                                    End If
                                                    .typMaterialLotIDList = New List(Of MaterialLotIDList)
                                                    Do While(.typMaterialLotIDList.Count < .lngMaterialLotCnt)
                                                        .typMaterialLotIDList.Add(New MaterialLotIDList)
                                                    Loop

                                                    Dim typMaterialLotIDListTmp As MaterialLotIDList = New MaterialLotIDList
                                                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                                    llngCnt3 = 0
                                                
                                                    For Each ltMsg3 In laAry3
                                                    
                                                        With typMaterialLotIDListTmp
                                                            '@ﾃﾞｰﾀ格納
                                                            Call ltMsg3.getString(CPstrMATERIAL_LOT_ID, .strMaterialLotID)      '部材管理ID
                                                            Call ltMsg3.getString(CPstrVENDER_WARRANT_DAYS_JUDGE, .strVenderWarrantDaysJudge)                   'ﾒｰｶｰ保証期間判定ﾌﾗｸﾞ(0:OK、1:NG)
                                                            Call ltMsg3.getString(CPstrACCEPT_WARRANT_DAYS_JUDGE, .strAcceptWarrantDaysJudge)                   '受入制限時間判定ﾌﾗｸﾞ(0:OK、1:NG)
                                                            Call ltMsg3.getString(CPstrUSE_VALID_PERIOD_JUDGE, .strUseValidPeriodJudge)                         '使用可能時間判定ﾌﾗｸﾞ(0:OK、1:NG)
                                                            Call ltMsg3.getString(CPstrWARNING_PERIOD_JUDGE, .strWarningPeriodJudge)                            'ﾜｰﾆﾝｸﾞ表示時間判定ﾌﾗｸﾞ(0:OK、1:NG)
                                                            Call ltMsg3.getString(CPstrVENDER_WARRANT_WARNING_DAYS_JUDGE, .strVenderWarrantWarningDaysJudge)    'ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間判定ﾌﾗｸﾞ(0:OK、1:NG)
                                                            Call ltMsg3.getString(CPstrACCEPT_WARRANT_WARNING_DAYS_JUDGE, .strAcceptWarrantWarningDaysJudge)    '受入制限ﾜｰﾆﾝｸﾞ時間判定ﾌﾗｸﾞ(0:OK、1:NG)
                                                        End With
                                                        .typMaterialLotIDList(llngCnt3) = typMaterialLotIDListTmp
                                                        '@ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
                                                        llngCnt3 = llngCnt3 + 1
                                                    Next
                                                End If
                                                
                                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                                If .lngPdListCnt > 0 Then
                                                    '@領域確保
                                                    .typPdList = New List(Of PDList)
                                                    Do While (.typPdList.Count < typMaterialIDLTmp.lngPdListCnt)
                                                        .typPdList.Add(New PDList)
                                                    Loop

                                                    Dim typPdListTmp As PDList = New PDList

                                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ4から各Msg取得
                                                    llngCnt4 = 0
                                                
                                                    For Each ltMsg4 In laAry4
                                                    
                                                        With typPdListTmp
                                                            '@ﾃﾞｰﾀ格納
                                                            Call ltMsg4.getString(CPstrPD_ID, .strPdId)      '機種ID
                                                        End With
                                                        .typPdList(llngCnt4) = typPdListTmp
                                                        '@ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
                                                        llngCnt4 = llngCnt4 + 1
                                                    Next
                                                End If
                                    
                                            End With
                                            .typMaterialIDList(llngCnt2) = typMaterialIDLTmp
                                            '@ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                    
                                End With
                                .typMaterialTypeList(llngCnt1) = typMaterialTypeTmp
                                '@ｶｳﾝﾀｲﾝｸﾘﾒﾝﾄ
                                llngCnt1 = llngCnt1 + 1
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMatMaterialList_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            ltMsg4 = Nothing
            laAry1 = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            laAry4 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            ltMsg4 = Nothing
            laAry1 = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            laAry4 = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnMasSendSBList_Sel
    '機　能：送品先一覧取得(在庫-完成在庫送品Tab用)
    '引　数：lstrmas_sendsblistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '引　数：lstrPdId               ：機種ID
    '　　　：ltypSendSBListAns      ：格納ﾃﾞｰﾀ用
    '戻り値：True：正常、False：異常
    '作成日：2006/09/08 (Fri) 14:35:11 N.Kojima
    '更新日：2006/09/08 (Fri) 14:35:11
    '備　考：
    Public Function pubblnMasSendSBList_Sel(ByVal lstrmas_sendsblistVer As String, _
                                            ByVal lstrPdID As String, _
                                            ByRef ltypSendSBListAns As SendSBListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            '@初期設定
            pstrMessageName = "送品先一覧取得"
            pubblnMasSendSBList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrmas_sendsblistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_sendsblistVer)       'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)                      '機種
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_sendsblist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrSEND_SB_LIST, laAry)
                
                    With ltypSendSBListAns
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        .lngSendSBListCnt = laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngSendSBListCnt > 0 Then
                            
                            If .typSendSBList Is Nothing Then
                                .typSendSBList = New List(Of SendSBList)
                            End If
                            Do While (.typSendSBList.Count < .lngSendSBListCnt)
                                .typSendSBList.Add(New SendSBList)
                            Loop
                            
                            Dim typSendSBListTmp As SendSBList = New SendSBList

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typSendSBListTmp
                                    Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)         '送品先ID
                                    Call ltMsg.getString(CPstrSEND_SB_NAME, .strSendSBName)     '送品先名(和名)
                                    Call ltMsg.getString(CPstrSB_SYSTEM_FLAG, .strSBSystemFlag) 'SBｼｽﾃﾑﾌﾗｸﾞ
                                End With
                                .typSendSBList(llngCnt) = typSendSBListTmp
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasSendSBList_Sel = True
                     
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_sendsblistVer)
                    
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnMasSendRouteList_Sel
    '機　能：送品先一覧取得(ｼｽﾃﾑﾌﾞﾛｯｸ経路ﾘｽﾄ-変更画面用)
    '引　数：lstrmas_sbroutelistVer      ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypSBRouteListAns          ：格納ﾃﾞｰﾀ用
    '戻り値：True：正常、False：異常
    '作成日：2006/09/08 (Fri) 14:35:11 N.Kojima
    '更新日：2006/09/08 (Fri) 14:35:11
    '備　考：
    Public Function pubblnMasSendRouteList_Sel(ByVal lstrmas_sbroutelistVer As String, _
                                               ByRef ltypSBRouteListAns As SendSBListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            '@初期設定
            pstrMessageName = "システムブロック経路リスト取得"
            pubblnMasSendRouteList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrmas_sbroutelistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_sbroutelistVer)            'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_sbroutelist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrSEND_SB_LIST, laAry)
                
                    With ltypSBRouteListAns
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        .lngSendSBListCnt = laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngSendSBListCnt > 0 Then
                            
                            .typSendSBList = New List(Of SendSBList) 

                            Do While (.typSendSBList.Count < .lngSendSBListCnt)
                                .typSendSBList.Add(New SendSBList)
                            Loop
                            
                            Dim typSendSBListTmp As SendSBList = New SendSBList

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typSendSBListTmp
                                    Call ltMsg.getString(CPstrSEND_SB_ID, .strSendSBID)         '送品先ID
                                    Call ltMsg.getString(CPstrSEND_SB_NAME, .strSendSBName)     '送品先名(和名)
                                    Call ltMsg.getString(CPstrSB_SYSTEM_FLAG, .strSBSystemFlag) 'SBｼｽﾃﾑﾌﾗｸﾞ
                                End With
                                .typSendSBList(llngCnt) = typSendSBListTmp
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasSendRouteList_Sel = True
                     
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_sbroutelistVer)
                    
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnPreChgPreserveReport_Upd
    '機　能：保全記録票登録/更新
    '引　数：ltypPreserveInfoReq    ：保全記録票情報格納用構造体(要求用)
    '　　　：lstrEditTime           ：更新日時
    '　　　：lstrPreserveNo         ：保全記録票№
    '　　　：lstrRequestFunction    ：要求元機能(1:装置ﾒﾝﾃﾅﾝｽ記録票一覧、2:装置ﾒﾝﾃﾅﾝｽ記録票、3:保全記録票選択)
    '戻り値：True:成功/Flase：失敗
    '作成日：2008/01/23 (Wed) 16:41:13 N.Kojima
    '更新日：2008/01/23 (Wed) 16:41:13
    '備　考：
    Public Function pubblnPreChgPreserveReport_Upd(ByRef ltypPreserveInfoReq As PreserveInfo, _
                                                   ByRef lstrEditTime As String, _
                                                   Optional ByRef lstrPreserveNo As String = vbNullString, _
                                                   Optional ByVal lstrRequestFunction As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得

        Try

            pstrMessageName = "保全記録票登録/更新"
            pubblnPreChgPreserveReport_Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypPreserveInfoReq
            
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
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@装置名
                If .strWpName <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_NAME, .strWpName)
                Else
                    Call lrMsg.addString(CPstrWP_NAME, CPstrMsgNull)
                End If
                
                '@ｶﾃｺﾞﾘID
                If .strUseId <> vbNullString Then
                    Call lrMsg.addString(CPstrCATEGORY_ID, .strUseId)
                Else
                    Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
                End If
                
                '@ｶﾃｺﾞﾘ名
                If .strCategoryName <> vbNullString Then
                    Call lrMsg.addString(CPstrCATEGORY_NAME, .strCategoryName)
                Else
                    Call lrMsg.addString(CPstrCATEGORY_NAME, CPstrMsgNull)
                End If
                
                '@保全ｶﾃｺﾞﾘ
                If .strPreserveCategory <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_CATEGORY, .strPreserveCategory)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_CATEGORY, CPstrMsgNull)
                End If
                
                '@変更前装置状態ID
                If .strOldUseID <> vbNullString Then
                    Call lrMsg.addString(CPstrOLD_USE_ID, .strOldUseID)
                Else
                    Call lrMsg.addString(CPstrOLD_USE_ID, CPstrMsgNull)
                End If
                
                '@変更後装置状態ID
                If .strUseId <> vbNullString Then
                    Call lrMsg.addString(CPstrUSE_ID, .strUseId)
                Else
                    Call lrMsg.addString(CPstrUSE_ID, CPstrMsgNull)
                End If
                
                '@ｱｸｼｮﾝID
                If .strActionID <> vbNullString Then
                    Call lrMsg.addString(CPstrACTION_ID, .strActionID)
                Else
                    Call lrMsg.addString(CPstrACTION_ID, CPstrMsgNull)
                End If
                
                '@保全記録票№
                If .strPreserveNo <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_NO, .strPreserveNo)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_NO, CPstrMsgNull)
                End If
                
                '@保全実施者ID
                If .strPreserveEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVER_EMP_ID, .strPreserveEmpID)
                Else
                    Call lrMsg.addString(CPstrPRESERVER_EMP_ID, CPstrMsgNull)
                End If
                
                '@保全実施者名
                If .strPreserveEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVER_EMP_NAME, .strPreserveEmpName)
                Else
                    Call lrMsg.addString(CPstrPRESERVER_EMP_NAME, CPstrMsgNull)
                End If
                        
                '@停止ｺﾒﾝﾄ
                If .strPreserveComments <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_COMMENTS, .strPreserveComments)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_COMMENTS, CPstrMsgNull)
                End If
                
                '@(保全)実施項目
                If .strPreserveItem <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_ITEM, .strPreserveItem)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_ITEM, CPstrMsgNull)
                End If
                
                '@(保全)実施内容
                If .strPreserveContents <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_CONTENTS, .strPreserveContents)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_CONTENTS, CPstrMsgNull)
                End If
                
                '@(保全)実施理由/目的
                If .strPreservePurpose <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_PURPOSE, .strPreservePurpose)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_PURPOSE, CPstrMsgNull)
                End If
                
                '@(保全)対応区分
                If .strCopeDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_COPE_DIVISION, .strCopeDivision)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_COPE_DIVISION, CPstrMsgNull)
                End If
                
                '@(保全)作業費用
                If .strWorkCost <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_WORK_COST, .strWorkCost)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_WORK_COST, CPstrMsgNull)
                End If
                
                '@(保全)部品費用
                If .strPartCost <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_PART_COST, .strPartCost)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_PART_COST, CPstrMsgNull)
                End If
                
                '@保全担当ｻｲﾝ者ID
                If .strPreserveSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_EMP_ID, .strPreserveSignEmpID)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@保全担当ｻｲﾝ者氏名
                If .strPreserveSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_EMP_NAME, .strPreserveSignEmpName)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@保全担当ｻｲﾝ日
                If .strPreserveSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_DATE, .strPreserveSignDate)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@保全ﾘｰﾀﾞｰｻｲﾝ者ID
                If .strPreserveLeaderSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_EMP_ID, .strPreserveLeaderSignEmpID)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                If .strPreserveLeaderSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_EMP_NAME, .strPreserveLeaderSignEmpName)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@保全ﾘｰﾀﾞｰｻｲﾝ日
                If .strPreserveLeaderSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_DATE, .strPreserveLeaderSignDate)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@作業長ｻｲﾝ者ID
                If .strProductLeaderSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_EMP_ID, .strProductLeaderSignEmpID)
                Else
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@作業長ｻｲﾝ者氏名
                If .strProductLeaderSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_EMP_NAME, .strProductLeaderSignEmpName)
                Else
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@作業長ｻｲﾝ日
                If .strProductLeaderSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_DATE, .strProductLeaderSignDate)
                Else
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@開始(予定)日時
                If .strPreserveStartDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_START_DATE, .strPreserveStartDate)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_START_DATE, CPstrMsgNull)
                End If
                
                '@終了(予定)日時
                If .strPreserveEndDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_END_DATE, .strPreserveEndDate)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_END_DATE, CPstrMsgNull)
                End If
                
                '@起票区分
                If .strEntryClass <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_CLASS, .strEntryClass)
                Else
                    Call lrMsg.addString(CPstrENTRY_CLASS, CPstrMsgNull)
                End If
                
                '@保全記録票状態
                If .strPreserveStatus <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_STATUS, .strPreserveStatus)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_STATUS, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@作業者名
                If .strEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_NAME, .strEmpName)
                Else
                    Call lrMsg.addString(CPstrEMP_NAME, CPstrMsgNull)
                End If
                
                '@承認者ID
                If .strApprovalEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_ID, .strApprovalEmpID)
                Else
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_ID, CPstrMsgNull)
                End If
                
                '@承認者名
                If .strApprovalEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_NAME, .strApprovalEmpName)
                Else
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_NAME, CPstrMsgNull)
                End If
                        
                '@更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@登録日時(装置停止・ﾒﾝﾃ計画からの連携時に使用)
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
                
                '@要求元機能(1:装置ﾒﾝﾃﾅﾝｽ記録票一覧、2:装置ﾒﾝﾃﾅﾝｽ記録票)
                '@　※承認、破棄の際にどの画面からの要求か判断するのに使用。
                If lstrRequestFunction <> vbNullString Then
                    Call lrMsg.addString(CPstrREQUEST_FUNCTION, lstrRequestFunction)
                Else
                    Call lrMsg.addString(CPstrREQUEST_FUNCTION, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrpre_chgpreservereport, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrPRESERVE_NO, lstrPreserveNo)      '保全記録票№
                    Call laMsg.getString(CPstrEDIT_TIME, lstrEditTime)          '更新日時

                    '@関数の処理結果(成功)格納
                    pubblnPreChgPreserveReport_Upd = True

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

    '関数名：pubblnPrePreserveInfo_Sel
    '機　能：保全記録票情報取得
    '引　数：ltypPreserveInfoReq    ：保全記録票情報格納用構造体(要求用)
    '　　　：ltypPreserveInfoAns    ：保全記録票情報格納用構造体(応答用)
    '戻り値：True:成功/Flase：失敗
    '作成日：2008/01/23 (Wed) 16:53:57 N.Kojima
    '更新日：2008/01/23 (Wed) 16:53:57
    '備　考：
    Public Function pubblnPrePreserveInfo_Sel(ByRef ltypPreserveInfoReq As PreserveInfoReq, _
                                              ByRef ltypPreserveInfoAns As PreserveInfoAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ用2

        Try

            pstrMessageName = "保全記録票情報取得"
            pubblnPrePreserveInfo_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            
            With ltypPreserveInfoReq
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@保全記録票№
                If .strPreserveNo <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_NO, .strPreserveNo)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_NO, CPstrMsgNull)
                End If
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@装置名(ErrMsg用)
                If .strWpName <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_NAME, .strWpName)
                Else
                    Call lrMsg.addString(CPstrWP_NAME, CPstrMsgNull)
                End If
                
                '@ｶﾃｺﾞﾘID
                If .strCategoryID <> vbNullString Then
                    Call lrMsg.addString(CPstrCATEGORY_ID, .strCategoryID)
                Else
                    Call lrMsg.addString(CPstrCATEGORY_ID, CPstrMsgNull)
                End If

                '@ｶﾃｺﾞﾘ名(ErrMsg用)
                If .strCategoryName <> vbNullString Then
                    Call lrMsg.addString(CPstrCATEGORY_NAME, .strCategoryName)
                Else
                    Call lrMsg.addString(CPstrCATEGORY_NAME, CPstrMsgNull)
                End If

                '@登録日時
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrpre_preserveinfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    With ltypPreserveInfoAns
                        Call laMsg.getString(CPstrPRESERVE_NO, .strPreserveNo)                          '保全記録№
                        Call laMsg.getString(CPstrEMP_NAME, .strEmpName)                                '作業者名(更新者名)
                        Call laMsg.getString(CPstrEDIT_TIME, .strEditTime)                              '更新日時
                        Call laMsg.getString(CPstrENTRY_TIME, .strEntryTime)                            '確認依頼日(登録日)
                        Call laMsg.getString(CPstrFROM_EMP_NAME, .strFromEmpName)                       '依頼元作業者名
                        Call laMsg.getString(CPstrPRESERVER_EMP_NAME, .strPreserveEmpName)              '保全実施者名
                        Call laMsg.getString(CPstrWP_ID, .strWpID)                                      '装置ID
                        Call laMsg.getString(CPstrWP_NAME, .strWpName)                                  '装置名
                        Call laMsg.getString(CPstrCATEGORY_ID, .strCategoryID)                          'ｶﾃｺﾞﾘID
                        Call laMsg.getString(CPstrCATEGORY_NAME, .strCategoryName)                      'ｶﾃｺﾞﾘ名
                        Call laMsg.getString(CPstrPRESERVE_CATEGORY, .strPreserveCategory)              '保全ｶﾃｺﾞﾘ
                        Call laMsg.getString(CPstrPRESERVE_START_DATE, .strPreserveStartDate)           '開始(予定)日時
                        Call laMsg.getString(CPstrPRESERVE_END_DATE, .strPreserveEndDate)               '終了(予定)日時
                        Call laMsg.getString(CPstrPRESERVE_COMMENTS, .strPreserveComments)              '停止ｺﾒﾝﾄ
                        Call laMsg.getString(CPstrPRESERVE_ITEM, .strPreserveItem)                      '(保全)実施項目
                        Call laMsg.getString(CPstrPRESERVE_CONTENTS, .strPreserveContents)              '(保全)実施内容
                        Call laMsg.getString(CPstrPRESERVE_PURPOSE, .strPreservePurpose)                '(保全)実施理由/目的
                        Call laMsg.getString(CPstrPRESERVE_COPE_DIVISION, .strCopeDivision)             '(保全)対応区分(0:自主保全、1:ﾒｰｶｰ保全)
                        Call laMsg.getString(CPstrPRESERVE_WORK_COST, .strWorkCost)                     '(保全)作業費用
                        Call laMsg.getString(CPstrPRESERVE_PART_COST, .strPartCost)                     '(保全)部品費用
                        Call laMsg.getString(CPstrPRESERVE_STATUS, .strPreserveStatus)                  '保全記録票状態(0：未処置、1：処置済、2：承認済、3：無効)
                        Call laMsg.getString(CPstrPRESERVE_SIGN_EMP_ID, .strPreserveSignEmpID)                  '保全担当ｻｲﾝ者ID
                        Call laMsg.getString(CPstrPRESERVE_SIGN_EMP_NAME, .strPreserveSignEmpName)              '保全担当ｻｲﾝ者氏名
                        Call laMsg.getString(CPstrPRESERVE_SIGN_DATE, .strPreserveSignDate)                     '保全担当ｻｲﾝ日
                        Call laMsg.getString(CPstrPRESERVE_LEADER_SIGN_EMP_ID, .strPreserveLeaderSignEmpID)     '保全ﾘｰﾀﾞｰｻｲﾝ者ID
                        Call laMsg.getString(CPstrPRESERVE_LEADER_SIGN_EMP_NAME, .strPreserveLeaderSignEmpName) '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                        Call laMsg.getString(CPstrPRESERVE_LEADER_SIGN_DATE, .strPreserveLeaderSignDate)        '保全ﾘｰﾀﾞｰｻｲﾝ日
                        Call laMsg.getString(CPstrPRODUCT_LEADER_SIGN_EMP_ID, .strProductLeaderSignEmpID)       '作業長ｻｲﾝ者ID
                        Call laMsg.getString(CPstrPRODUCT_LEADER_SIGN_EMP_NAME, .strProductLeaderSignEmpName)   '作業長ｻｲﾝ者氏名
                        Call laMsg.getString(CPstrPRODUCT_LEADER_SIGN_DATE, .strProductLeaderSignDate)          '作業長ｻｲﾝ日
                        Call laMsg.getString(CPstrENTRY_CLASS, .strEntryClass)                          '起票区分(0:手動、1:自動)

                        '@ｱﾚｲを格納(確認依頼先)
                        Call laMsg.getMsgAry(CPstrTO_EMP_LIST, laAry2)      '担当者名(依頼先作業者)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If laAry2.Count > 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            
                            '@ｱﾚｲｶｳﾝﾄ取得
                            .lngEmpListCnt = laAry2.Count
                            
                            '@配列の要素数を設定
                            .typEmpList = New List(Of EmpList)
                            Do While (.typEmpList.Count < laAry2.count)
                                .typEmpList.Add(New EmpList)
                            Loop

                            Dim typEmpListTmp As EmpList = New EmpList

                            llngCnt2 = 0
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg2 In laAry2
                                Call ltMsg2.getString(CPstrEMP_ID, typEmpListTmp.strEmpID)      '確認依頼先担当者ID
                                Call ltMsg2.getString(CPstrEMP_NAME, typEmpListTmp.strEmpName)  '確認依頼先担当者名
                                .typEmpList(llngCnt2) = typEmpListTmp
                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngCnt2 = llngCnt2 + 1
                            Next
                        End If
                    
                    End With
                        
                    '@関数の処理結果(成功)格納
                    pubblnPrePreserveInfo_Sel = True

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
            laAry = Nothing
            laAry2 = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            laAry2 = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing

        End Try
    End Function

    '関数名：pubblnRepChgRepairReport_Upd
    '機　能：故障修理記録票登録/更新
    '引　数：ltypRepairInfoReq      ：故障修理記録票情報格納用構造体(要求用)
    '　　　：lstrEditTime           ：更新日時
    '　　　：lstrRepairNo           ：故障修理記録票№
    '　　　：lstrRequestFunction    ：要求元機能(1:装置ﾒﾝﾃﾅﾝｽ記録票一覧、2:装置ﾒﾝﾃﾅﾝｽ記録票)
    '戻り値：True:成功/Flase：失敗
    '作成日：2007/01/15 (Mon) 16:05:04 N.Kojima
    '更新日：2008/02/18 (Mon) 14:44:48 N.Kojima
    '備　考：
    '　　　：2007/03/20 (Tue) 17:14:50 N.Kojima     要求ﾀｸﾞに各種ｻｲﾝ関連ﾀｸﾞ、起票区分、登録日時を追加。(案件№01830)
    '　　　：2008/02/18 (Mon) 14:44:48 N.Kojima     要求ﾀｸﾞ追加(対応区分、作業費用、部品費用)。(案件№02332)
    Public Function pubblnRepChgRepairReport_Upd(ByRef ltypRepairInfoReq As RepairInfo, _
                                                 ByRef lstrEditTime As String, _
                                                 Optional ByRef lstrRepairNo As String = vbNullString, _
                                                 Optional ByVal lstrRequestFunction As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得

        Try

            pstrMessageName = "故障修理記録票登録/更新"
            pubblnRepChgRepairReport_Upd = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypRepairInfoReq
            
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
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@装置名
                If .strWpName <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_NAME, .strWpName)
                Else
                    Call lrMsg.addString(CPstrWP_NAME, CPstrMsgNull)
                End If
                
                '@変更前装置状態ID
                If .strOldUseID <> vbNullString Then
                    Call lrMsg.addString(CPstrOLD_USE_ID, .strOldUseID)
                Else
                    Call lrMsg.addString(CPstrOLD_USE_ID, CPstrMsgNull)
                End If
                
                '@変更後装置状態ID
                If .strUseId <> vbNullString Then
                    Call lrMsg.addString(CPstrUSE_ID, .strUseId)
                Else
                    Call lrMsg.addString(CPstrUSE_ID, CPstrMsgNull)
                End If
                
                '@ｱｸｼｮﾝID
                If .strActionID <> vbNullString Then
                    Call lrMsg.addString(CPstrACTION_ID, .strActionID)
                Else
                    Call lrMsg.addString(CPstrACTION_ID, CPstrMsgNull)
                End If
                
                '@故障修理記録票№
                If .strRepairNo <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_NO, .strRepairNo)
                Else
                    Call lrMsg.addString(CPstrREPAIR_NO, CPstrMsgNull)
                End If
                
                '@保全実施者ID
                If .strPreserveEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVER_EMP_ID, .strPreserveEmpID)
                Else
                    Call lrMsg.addString(CPstrPRESERVER_EMP_ID, CPstrMsgNull)
                End If
                
                '@保全実施者名
                If .strPreserveEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVER_EMP_NAME, .strPreserveEmpName)
                Else
                    Call lrMsg.addString(CPstrPRESERVER_EMP_NAME, CPstrMsgNull)
                End If
                        
                '@故障現象名
                If .strRepairName <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_NAME, .strRepairName)
                Else
                    Call lrMsg.addString(CPstrREPAIR_NAME, CPstrMsgNull)
                End If
                
                '@故障現象ｻｲﾝ者ID
                If .strRepairNameSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_NAME_SIGN_EMP_ID, .strRepairNameSignEmpID)
                Else
                    Call lrMsg.addString(CPstrREPAIR_NAME_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@故障現象ｻｲﾝ者氏名
                If .strRepairNameSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_NAME_SIGN_EMP_NAME, .strRepairNameSignEmpName)
                Else
                    Call lrMsg.addString(CPstrREPAIR_NAME_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@故障現象ｻｲﾝ日
                If .strRepairNameSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_NAME_SIGN_DATE, .strRepairNameSignDate)
                Else
                    Call lrMsg.addString(CPstrREPAIR_NAME_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@故障現象詳細
                If .strRepairContents <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_CONTENTS, .strRepairContents)
                Else
                    Call lrMsg.addString(CPstrREPAIR_CONTENTS, CPstrMsgNull)
                End If
                
                '@原因詳細
                If .strRepairCauseContents <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_CAUSE_CONTENTS, .strRepairCauseContents)
                Else
                    Call lrMsg.addString(CPstrREPAIR_CAUSE_CONTENTS, CPstrMsgNull)
                End If
                
                '@故障原因ｻｲﾝ者ID
                If .strRepairCauseSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_CAUSE_SIGN_EMP_ID, .strRepairCauseSignEmpID)
                Else
                    Call lrMsg.addString(CPstrREPAIR_CAUSE_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@故障原因ｻｲﾝ者氏名
                If .strRepairCauseSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_CAUSE_SIGN_EMP_NAME, .strRepairCauseSignEmpName)
                Else
                    Call lrMsg.addString(CPstrREPAIR_CAUSE_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@故障原因ｻｲﾝ日
                If .strRepairCauseSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_CAUSE_SIGN_DATE, .strRepairCauseSignDate)
                Else
                    Call lrMsg.addString(CPstrREPAIR_CAUSE_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@調査/分析詳細
                If .strRepairAnalysisContents <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_ANALYSIS_CONTENTS, .strRepairAnalysisContents)
                Else
                    Call lrMsg.addString(CPstrREPAIR_ANALYSIS_CONTENTS, CPstrMsgNull)
                End If
                
                '@故障原因調査/分析ｻｲﾝ者ID
                If .strRepairAnalysisSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_ANALYSIS_SIGN_EMP_ID, .strRepairAnalysisSignEmpID)
                Else
                    Call lrMsg.addString(CPstrREPAIR_ANALYSIS_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@故障原因調査/分析ｻｲﾝ者氏名
                If .strRepairAnalysisSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_ANALYSIS_SIGN_EMP_NAME, .strRepairAnalysisSignEmpName)
                Else
                    Call lrMsg.addString(CPstrREPAIR_ANALYSIS_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@故障原因調査/分析ｻｲﾝ日
                If .strRepairAnalysisSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_ANALYSIS_SIGN_DATE, .strRepairAnalysisSignDate)
                Else
                    Call lrMsg.addString(CPstrREPAIR_ANALYSIS_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@対策詳細
                If .strRepairMeasureContents <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_MEASURE_CONTENTS, .strRepairMeasureContents)
                Else
                    Call lrMsg.addString(CPstrREPAIR_MEASURE_CONTENTS, CPstrMsgNull)
                End If
                
                '@故障対策ｻｲﾝ者ID
                If .strRepairMeasureSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_MEASURE_SIGN_EMP_ID, .strRepairMeasureSignEmpID)
                Else
                    Call lrMsg.addString(CPstrREPAIR_MEASURE_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@故障対策ｻｲﾝ者氏名
                If .strRepairMeasureSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_MEASURE_SIGN_EMP_NAME, .strRepairMeasureSignEmpName)
                Else
                    Call lrMsg.addString(CPstrREPAIR_MEASURE_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@故障対策ｻｲﾝ日
                If .strRepairMeasureSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_MEASURE_SIGN_DATE, .strRepairMeasureSignDate)
                Else
                    Call lrMsg.addString(CPstrREPAIR_MEASURE_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@(故障修理)対応区分
                If .strCopeDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_COPE_DIVISION, .strCopeDivision)
                Else
                    Call lrMsg.addString(CPstrREPAIR_COPE_DIVISION, CPstrMsgNull)
                End If
                
                '@(故障修理)作業費用
                If .strWorkCost <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_WORK_COST, .strWorkCost)
                Else
                    Call lrMsg.addString(CPstrREPAIR_WORK_COST, CPstrMsgNull)
                End If
                
                '@(故障修理)部品費用
                If .strPartCost <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_PART_COST, .strPartCost)
                Else
                    Call lrMsg.addString(CPstrREPAIR_PART_COST, CPstrMsgNull)
                End If
                
                '@保全担当ｻｲﾝ者ID
                If .strPreserveSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_EMP_ID, .strPreserveSignEmpID)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@保全担当ｻｲﾝ者氏名
                If .strPreserveSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_EMP_NAME, .strPreserveSignEmpName)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@保全担当ｻｲﾝ日
                If .strPreserveSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_DATE, .strPreserveSignDate)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@保全ﾘｰﾀﾞｰｻｲﾝ者ID
                If .strPreserveLeaderSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_EMP_ID, .strPreserveLeaderSignEmpID)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                If .strPreserveLeaderSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_EMP_NAME, .strPreserveLeaderSignEmpName)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@保全ﾘｰﾀﾞｰｻｲﾝ日
                If .strPreserveLeaderSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_DATE, .strPreserveLeaderSignDate)
                Else
                    Call lrMsg.addString(CPstrPRESERVE_LEADER_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@作業長ｻｲﾝ者ID
                If .strProductLeaderSignEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_EMP_ID, .strProductLeaderSignEmpID)
                Else
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_EMP_ID, CPstrMsgNull)
                End If
                
                '@作業長ｻｲﾝ者氏名
                If .strProductLeaderSignEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_EMP_NAME, .strProductLeaderSignEmpName)
                Else
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_EMP_NAME, CPstrMsgNull)
                End If
                
                '@作業長ｻｲﾝ日
                If .strProductLeaderSignDate <> vbNullString Then
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_DATE, .strProductLeaderSignDate)
                Else
                    Call lrMsg.addString(CPstrPRODUCT_LEADER_SIGN_DATE, CPstrMsgNull)
                End If
                
                '@故障発生日時
                If .strRepairStartDate <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_START_DATE, .strRepairStartDate)
                Else
                    Call lrMsg.addString(CPstrREPAIR_START_DATE, CPstrMsgNull)
                End If
                
                '@修理完了日時
                If .strRepairEndDate <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_END_DATE, .strRepairEndDate)
                Else
                    Call lrMsg.addString(CPstrREPAIR_END_DATE, CPstrMsgNull)
                End If
                
                '@起票区分
                If .strEntryClass <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_CLASS, .strEntryClass)
                Else
                    Call lrMsg.addString(CPstrENTRY_CLASS, CPstrMsgNull)
                End If
                
                '@故障修理記録票状態
                If .strRepairStatus <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_STATUS, .strRepairStatus)
                Else
                    Call lrMsg.addString(CPstrREPAIR_STATUS, CPstrMsgNull)
                End If
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@作業者名
                If .strEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_NAME, .strEmpName)
                Else
                    Call lrMsg.addString(CPstrEMP_NAME, CPstrMsgNull)
                End If
                
                '@承認者ID
                If .strApprovalEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_ID, .strApprovalEmpID)
                Else
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_ID, CPstrMsgNull)
                End If
                
                '@承認者名
                If .strApprovalEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_NAME, .strApprovalEmpName)
                Else
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_NAME, CPstrMsgNull)
                End If
                        
                '@更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
                '@登録日時(装置停止・ﾒﾝﾃ計画からの連携時に使用)
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
                
                '@要求元機能(1:装置ﾒﾝﾃﾅﾝｽ記録票一覧、2:装置ﾒﾝﾃﾅﾝｽ記録票)
                '@　※承認、破棄の際にどの画面からの要求か判断するのに使用。
                If lstrRequestFunction <> vbNullString Then
                    Call lrMsg.addString(CPstrREQUEST_FUNCTION, lstrRequestFunction)
                Else
                    Call lrMsg.addString(CPstrREQUEST_FUNCTION, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrrep_chgrepairreport, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrREPAIR_NO, lstrRepairNo)      '故障修理記録票№
                    Call laMsg.getString(CPstrEDIT_TIME, lstrEditTime)      '更新日時

                    '@関数の処理結果(成功)格納
                    pubblnRepChgRepairReport_Upd = True

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

    '関数名：pubblnRepRepairInfo_Sel
    '機　能：故障修理記録票情報取得
    '引　数：ltypRepairInfoReq      ：故障修理記録票情報格納用構造体(要求用)
    '　　　：ltypRepairInfoAns      ：故障修理記録票情報格納用構造体(応答用)
    '戻り値：True:成功/Flase：失敗
    '作成日：2007/01/15 (Mon) 16:05:04 N.Kojima
    '更新日：2008/02/18 (Mon) 14:44:48 N.Kojima
    '備　考：
    '　　　：2007/03/16 (Fri) 18:32:42 N.Kojima     要求ﾀｸﾞ、応答ﾀｸﾞ追加(装置名、登録日時、ｻｲﾝ関連、起票区分)。(案件№01830)
    '　　　：2008/02/18 (Mon) 14:44:48 N.Kojima     応答ﾀｸﾞ追加(対応区分、作業費用、部品費用)。(案件№02332)
    Public Function pubblnRepRepairInfo_Sel(ByRef ltypRepairInfoReq As RepairInfoReq, _
                                            ByRef ltypRepairInfoAns As RepairInfoAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ用2

        Try

            pstrMessageName = "故障修理記録票情報取得"
            pubblnRepRepairInfo_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            
            With ltypRepairInfoReq
            
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@故障修理記録票№
                If .strRepairNo <> vbNullString Then
                    Call lrMsg.addString(CPstrREPAIR_NO, .strRepairNo)
                Else
                    Call lrMsg.addString(CPstrREPAIR_NO, CPstrMsgNull)
                End If
                
                '@装置ID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@装置名(ErrMsg用)
                If .strWpName <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_NAME, .strWpName)
                Else
                    Call lrMsg.addString(CPstrWP_NAME, CPstrMsgNull)
                End If

                '@登録日時
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrrep_repairinfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    
                    '@受信結果取得
                    With ltypRepairInfoAns
                        Call laMsg.getString(CPstrREPAIR_NO, .strRepairNo)                              '故障修理記録№
                        Call laMsg.getString(CPstrEMP_NAME, .strEmpName)                                '作業者名(更新者名)
                        Call laMsg.getString(CPstrEDIT_TIME, .strEditTime)                              '更新日時
                        Call laMsg.getString(CPstrENTRY_TIME, .strEntryTime)                            '確認依頼日(登録日)
                        Call laMsg.getString(CPstrFROM_EMP_NAME, .strFromEmpName)                       '依頼元作業者名
                        Call laMsg.getString(CPstrFIND_EMP_NAME, .strFindEmpName)                       '発見者名
                        Call laMsg.getString(CPstrFIND_DEPT_NAME, .strFindDeptName)                     '発見職場名
                        Call laMsg.getString(CPstrPRESERVER_EMP_NAME, .strPreserveEmpName)              '保全実施者名
                        Call laMsg.getString(CPstrWP_ID, .strWpID)                                      '装置ID
                        Call laMsg.getString(CPstrWP_NAME, .strWpName)                                  '装置名
                        Call laMsg.getString(CPstrREPAIR_START_DATE, .strRepairStartDate)               '故障発生日時
                        Call laMsg.getString(CPstrREPAIR_END_DATE, .strRepairEndDate)                   '修理完了日時
                        Call laMsg.getString(CPstrREPAIR_NAME, .strRepairName)                          '故障現象名
                        Call laMsg.getString(CPstrREPAIR_CONTENTS, .strRepairContents)                  '故障現象詳細
                        Call laMsg.getString(CPstrREPAIR_CAUSE_CONTENTS, .strRepairCauseContents)       '原因詳細
                        Call laMsg.getString(CPstrREPAIR_ANALYSIS_CONTENTS, .strRepairAnalysisContents) '調査/分析詳細
                        Call laMsg.getString(CPstrREPAIR_MEASURE_CONTENTS, .strRepairMeasureContents)   '対策詳細
                        Call laMsg.getString(CPstrREPAIR_COPE_DIVISION, .strCopeDivision)               '(故障修理)対応区分(0:自主保全、1:ﾒｰｶｰ保全)
                        Call laMsg.getString(CPstrREPAIR_WORK_COST, .strWorkCost)                       '(故障修理)作業費用
                        Call laMsg.getString(CPstrREPAIR_PART_COST, .strPartCost)                       '(故障修理)部品費用
                        Call laMsg.getString(CPstrREPAIR_STATUS, .strRepairStatus)                      '故障修理記録票状態(0：未処置、1：処置済、2：承認済、3：無効)
                        Call laMsg.getString(CPstrREPAIR_NAME_SIGN_EMP_ID, .strRepairNameSignEmpID)             '故障現象ｻｲﾝ者ID
                        Call laMsg.getString(CPstrREPAIR_NAME_SIGN_EMP_NAME, .strRepairNameSignEmpName)         '故障現象ｻｲﾝ者氏名
                        Call laMsg.getString(CPstrREPAIR_NAME_SIGN_DATE, .strRepairNameSignDate)                '故障現象ｻｲﾝ日
                        Call laMsg.getString(CPstrREPAIR_CAUSE_SIGN_EMP_ID, .strRepairCauseSignEmpID)           '故障原因ｻｲﾝ者ID
                        Call laMsg.getString(CPstrREPAIR_CAUSE_SIGN_EMP_NAME, .strRepairCauseSignEmpName)       '故障原因ｻｲﾝ者氏名
                        Call laMsg.getString(CPstrREPAIR_CAUSE_SIGN_DATE, .strRepairCauseSignDate)              '故障原因ｻｲﾝ日
                        Call laMsg.getString(CPstrREPAIR_ANALYSIS_SIGN_EMP_ID, .strRepairAnalysisSignEmpID)     '故障原因調査/分析ｻｲﾝ者ID
                        Call laMsg.getString(CPstrREPAIR_ANALYSIS_SIGN_EMP_NAME, .strRepairAnalysisSignEmpName) '故障原因調査/分析ｻｲﾝ者氏名
                        Call laMsg.getString(CPstrREPAIR_ANALYSIS_SIGN_DATE, .strRepairAnalysisSignDate)        '故障原因調査/分析ｻｲﾝ日
                        Call laMsg.getString(CPstrREPAIR_MEASURE_SIGN_EMP_ID, .strRepairMeasureSignEmpID)       '故障対策ｻｲﾝ者ID
                        Call laMsg.getString(CPstrREPAIR_MEASURE_SIGN_EMP_NAME, .strRepairMeasureSignEmpName)   '故障対策ｻｲﾝ者氏名
                        Call laMsg.getString(CPstrREPAIR_MEASURE_SIGN_DATE, .strRepairMeasureSignDate)          '故障対策ｻｲﾝ日
                        Call laMsg.getString(CPstrPRESERVE_SIGN_EMP_ID, .strPreserveSignEmpID)                  '保全担当ｻｲﾝ者ID
                        Call laMsg.getString(CPstrPRESERVE_SIGN_EMP_NAME, .strPreserveSignEmpName)              '保全担当ｻｲﾝ者氏名
                        Call laMsg.getString(CPstrPRESERVE_SIGN_DATE, .strPreserveSignDate)                     '保全担当ｻｲﾝ日
                        Call laMsg.getString(CPstrPRESERVE_LEADER_SIGN_EMP_ID, .strPreserveLeaderSignEmpID)     '保全ﾘｰﾀﾞｰｻｲﾝ者ID
                        Call laMsg.getString(CPstrPRESERVE_LEADER_SIGN_EMP_NAME, .strPreserveLeaderSignEmpName) '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                        Call laMsg.getString(CPstrPRESERVE_LEADER_SIGN_DATE, .strPreserveLeaderSignDate)        '保全ﾘｰﾀﾞｰｻｲﾝ日
                        Call laMsg.getString(CPstrPRODUCT_LEADER_SIGN_EMP_ID, .strProductLeaderSignEmpID)       '作業長ｻｲﾝ者ID
                        Call laMsg.getString(CPstrPRODUCT_LEADER_SIGN_EMP_NAME, .strProductLeaderSignEmpName)   '作業長ｻｲﾝ者氏名
                        Call laMsg.getString(CPstrPRODUCT_LEADER_SIGN_DATE, .strProductLeaderSignDate)          '作業長ｻｲﾝ日
                        Call laMsg.getString(CPstrENTRY_CLASS, .strEntryClass)                          '起票区分(0:手動、1:自動)
                    
                        '@ｱﾚｲを格納(確認依頼先)
                        Call laMsg.getMsgAry(CPstrTO_EMP_LIST, laAry2)          '担当者名(依頼先作業者)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If laAry2.Count > 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            
                            '@ｱﾚｲｶｳﾝﾄ取得
                            .lngEmpListCnt = laAry2.Count
                            
                            '@配列の要素数を設定
                            .typEmpList = New List(Of EmpList)
                            Do While (.typEmpList.Count < laAry2.count)
                                .typEmpList.Add(New EmpList)
                            Loop

                            Dim typEmpListTmp As EmpList = New EmpList

                            llngCnt2 = 0
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg2 In laAry2
                                Call ltMsg2.getString(CPstrEMP_ID, typEmpListTmp.strEmpID)      '確認依頼先担当者ID
                                Call ltMsg2.getString(CPstrEMP_NAME, typEmpListTmp.strEmpName)  '確認依頼先担当者名
                                .typEmpList(llngCnt2) = typEmpListTmp
                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngCnt2 = llngCnt2 + 1
                            Next
                        End If
                    
                    End With
                        
                    '@関数の処理結果(成功)格納
                    pubblnRepRepairInfo_Sel = True

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
            laAry = Nothing
            laAry2 = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing
            laAry2 = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing

        End Try
    End Function

    '関数名：pubblnRepRegistWorkFlow_Ins
    '機　能：ﾜｰｸﾌﾛｰ登録
    '引　数：ltypWorkFlow   ：要求構造体
    '戻り値：True:成功/False:失敗
    '作成日：2007/02/02 (Fri) 11:11:56 N.Kojima
    '更新日：2007/02/02 (Fri) 11:11:56
    '備　考：
    Public Function pubblnRepRegistWorkFlow_Ins(ByRef ltypWorkFlow As WorkFlow) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "ワークフロー登録"
            pubblnRepRegistWorkFlow_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypWorkFlow
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                                          'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                                      'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)                                          '装置ID
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                If .strReportNo <> vbNullString Then
                    Call lrMsg.addString(CPstrREPORT_NO, .strReportNo)                                  '処理票№
                Else
                    Call lrMsg.addString(CPstrREPORT_NO, CPstrMsgNull)
                End If

                If .strFromEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrFROM_EMP_ID, .strFromEmpID)                               '依頼元ID
                Else
                    Call lrMsg.addString(CPstrFROM_EMP_ID, CPstrMsgNull)
                End If
                
                If .strFromEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrFROM_EMP_NAME, .strFromEmpName)                           '依頼元名
                Else
                    Call lrMsg.addString(CPstrFROM_EMP_NAME, CPstrMsgNull)
                End If

                '@依頼先ﾘｽﾄ
                If .lngEmpListCnt > 0 Then
                    For llngCnt = 0 To .lngEmpListCnt -1
                        If .typEmpList(llngCnt).strToEmpID <> vbNullString Then
                            Call ltMsg.addString(CPstrTO_EMP_ID, .typEmpList(llngCnt).strToEmpID)       '依頼先ID
                        Else
                            Call ltMsg.addString(CPstrTO_EMP_ID, CPstrMsgNull)
                        End If
                        
                        If .typEmpList(llngCnt).strToEmpName <> vbNullString Then
                            Call ltMsg.addString(CPstrTO_EMP_NAME, .typEmpList(llngCnt).strToEmpName)   '依頼先名
                        Else
                            Call ltMsg.addString(CPstrTO_EMP_NAME, CPstrMsgNull)
                        End If
                    
                        '@ｱﾚｲ1に格納
                        Call lrAry.Add(ltMsg)
                        Call ltMsg.Clear
                    Next llngCnt
                End If
            
                '@Temp1にｱﾚｲ1の内容を格納
                Call lrMsg.addMsgAry(CPstrTO_EMP_LIST, lrAry)
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrrep_registworkflow, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnRepRegistWorkFlow_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypWorkFlow.strMsgVer)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

        End Try
    End Function

    '関数名：pubblnMasAltRouteList_Sel
    '機　能：代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)一覧取得
    '引　数：lstrmas_altroutelistVer  ：Msgﾊﾞｰｼﾞｮﾝ
    '引　数：ltypAltRouteListReq      ：ｼｽﾃﾑ
    '　　　：ltypAltRouteListRep      ：格納ﾃﾞｰﾀ用
    '戻り値：True：正常、False：異常
    '作成日：2008/03/31 (Mon) 13:03:00 S.Ochiai
    '更新日：2006/03/31 (Mon) 13:03:00 S.Ochiai     No.02541対応(ﾘﾜｰｸ/追加流動ﾙｰﾄID選択)
    '備　考：
    Public Function pubblnMasAltRouteList_Sel(ByVal lstrmas_altroutelistVer As String, _
                                              ByRef ltypAltRouteListReq As MasAltRouteListReq, _
                                              ByRef ltypAltRouteListAns As MasAltRouteListAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
    '    Dim lstrErrMsg          As String           'ｴﾗｰ用
    '    Dim lstrMSG             As String           'ﾒｯｾｰｼﾞ内容格納
        
        Try

            '@初期設定
            pstrMessageName = "代替ルート一覧取得"
            pubblnMasAltRouteList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrmas_altroutelistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_altroutelistVer)             'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            If ltypAltRouteListReq.strSbID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, ltypAltRouteListReq.strSbID)          'ｼｽﾃﾑﾌﾞﾛｯｸID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            If ltypAltRouteListReq.strFlowType <> vbNullString Then
                Call lrMsg.addString(CPstrFLOW_TYPE, ltypAltRouteListReq.strFlowType)  '区分(1:ﾘﾜｰｸ/4:追加流動)
            Else
                Call lrMsg.addString(CPstrFLOW_TYPE, CPstrMsgNull)
            End If
            
            If ltypAltRouteListReq.strRouteID <> vbNullString Then
                Call lrMsg.addString(CPstrROUTE_ID, ltypAltRouteListReq.strRouteID)    'ﾙｰﾄID(ﾘﾜｰｸ/追加流動)
            Else
                Call lrMsg.addString(CPstrROUTE_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_altroutelist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrALT_ROUTE_LIST, laAry)
                
                    With ltypAltRouteListAns
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        .lngAltRouteListCnt = laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngAltRouteListCnt > 0 Then
                            If .typAltRouteList Is Nothing Then
                                .typAltRouteList = New List(Of AltRouteList)
                            End If
                            Do While (.typAltRouteList.Count < .lngAltRouteListCnt)
                                .typAltRouteList.Add(New AltRouteList)
                            Loop 

                            Dim typAltRouteListTmp As AltRouteList = New AltRouteList

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With typAltRouteListTmp
                                    Call ltMsg.getString(CPstrROUTE_ID, .strRouteID)    '代替ﾙｰﾄID
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)   'ｺﾒﾝﾄ
                                End With
                                .typAltRouteList(llngCnt) = typAltRouteListTmp
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasAltRouteList_Sel = True
                     
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_altroutelistVer)
                    
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubEqWarning_Chk
    '機　能：装置の処理間隔ﾜｰﾆﾝｸﾞ時間をﾁｪｯｸする
    '引　数：lstrWP_ID                ：WP_ID
    '引　数：lstrRrrMessage           ：ｴﾗｰﾒｯｾｰｼﾞ
    '　　　：lblnEqchk_Flg            ：ﾁｪｯｸした結果(0：ｵｰﾊﾞなし、1：ｵｰﾊﾞあり)
    '戻り値：True：正常、False：異常
    '作成日：2008/10/31 (Fri) 16:05:00 T.Oide
    '更新日：2008/10/31 (Fri) 16:05:00 T.Oide   <No.03231対応>
    '備　考：
    Public Sub pubEqWarning_Chk(ByVal streqchkintervalVer As String, _
                                        ByRef strWpID As String, _
                                        ByRef lstrRrrMessage As String, _
                                        ByRef strEqchk_Result As String)


        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try
            
            '@初期設定
            pstrMessageName = "装置の処理間隔ワーニングチェック"
            
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            '@Msgﾊﾞｰｼﾞｮﾝ
            Call lrMsg.addString(CPstrMSG_VER, streqchkintervalVer)
            '@装置ID
            Call lrMsg.addString(CPstrWP_ID, strWpID)
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__chkinterval, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            If lstrRET = CPstrTRUE Then
            
                '@成功の場合(true)
                '@受信結果取得
                Call laMsg.getString(CPstrRESULT, strEqchk_Result)      'ﾁｪｯｸ結果
                Call laMsg.getString(CPstrMSG, lstrRrrMessage)          'ｴﾗｰﾒｯｾｰｼﾞ
                
            End If
               
            
            '-----------------------------------
            
            
            lrMsg = Nothing
            laMsg = Nothing

            Exit Sub
            
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Sub

    '関数名：pubblnLotChkChgOrder_Chk
    '機　能：量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
    '引　数：lstrlot_chkchangeorderVer  ：ﾒｯｾｰｼﾞVer
    '　　　：lstrLotID                  ：ﾛｯﾄID
    '　　　：lstrGuidMsg                ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode            ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：Ture：ﾁｪｯｸ処理成功、False：ﾁｪｯｸ処理失敗
    '作成日：2009/03/05 (Thu) 09:54:03 N.Kojima
    '更新日：2009/03/05 (Thu) 09:54:03
    '備　考：
    Public Function pubblnLotChkChgOrder_Chk(ByVal lstrlot_chkchangeorderVer As String, _
                                             ByVal lstrLotID As String, _
                                             ByRef lstrGuidMsg As String, _
                                             ByRef lstrGuidMsgCode As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)  
        Dim lstrRET             As String           '応答取得
            
        Try

            '@各種初期化
            pstrMessageName = "量産オーダー振替チェック"
            pubblnLotChkChgOrder_Chk = False
            
            '@ｵﾌﾞｼﾞｪｸﾄの設定
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_chkchangeorderVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_chkchangeorderVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@=======================
            '@ ﾒｯｾｰｼﾞ送信＆受信結果取得
            '@=======================
            Call pTerm.sendRequest(CPstrlot_chkchangeorder, lrMsg, laMsg)
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果結果により処理分岐 ★
            Select Case lstrRET
                
                '@〓 True：通信成功 〓
                Case CPstrTRUE
                    
                    '@受信結果格納
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    
                    '@戻り値に"True：ﾁｪｯｸ処理成功"をｾｯﾄ
                    pubblnLotChkChgOrder_Chk = True
                
                
                '@〓 False：通信失敗 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ﾒｯｾｰｼﾞVer判定処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_chkchangeorderVer)
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄの解放
            lrMsg = Nothing
            laMsg = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄの解放
            lrMsg = Nothing
            laMsg = Nothing
            
            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnLotExclusionProcess_Chk
    '機　能：抜取検査ﾁｪｯｸ
    '引　数：lstrlot_excprocessVer      ：ﾒｯｾｰｼﾞVer
    '　　　：lstrLotID                  ：ﾛｯﾄID
    '　　　：lstrGuidMsg                ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode            ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：Ture：ﾁｪｯｸ処理成功、False：ﾁｪｯｸ処理失敗
    '作成日：2009/08/18 (Tue) 12:39:10  T.Inafune
    '更新日：2009/08/18 (Tue) 12:52:13
    '備　考：
    Public Function pubblnLotExclusionProcess_Chk(ByVal lstrlot_excprocessVer As String, _
                                            ByVal lstrLotID As String, _
                                            ByRef lstrGuidMsg As String, _
                                            ByRef lstrGuidMsgCode As String, _
                                            ByRef lstrPanelInspectType As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
            
        Try

            '@各種初期化
            pstrMessageName = "抜取・全数検査チェック"
            pubblnLotExclusionProcess_Chk = False
            
            '@ｵﾌﾞｼﾞｪｸﾄの設定
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_excprocessVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_excprocessVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@=======================
            '@ ﾒｯｾｰｼﾞ送信＆受信結果取得
            '@=======================
            Call pTerm.sendRequest(CPstrlot_chkexclusionprocess, lrMsg, laMsg)
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果結果により処理分岐 ★
            Select Case lstrRET
                
                '@〓 True：通信成功 〓
                Case CPstrTRUE
                    
                    '@受信結果格納
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                         'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    '@↓2020/03/19 (Thu) 15:16:44 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    Call laMsg.getString(CPstrPANEL_INSPECT_TYPE, lstrPanelInspectType) 'ﾊﾟﾈﾙ検査種類
                    '@↑2020/03/19 (Thu) 15:16:44 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    
                    '@戻り値に"True：ﾁｪｯｸ処理成功"をｾｯﾄ
                    pubblnLotExclusionProcess_Chk = True
                
                
                '@〓 False：通信失敗 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ﾒｯｾｰｼﾞVer判定処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_excprocessVer)
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄの解放
            lrMsg = Nothing
            laMsg = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄの解放
            lrMsg = Nothing
            laMsg = Nothing
            
            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnCarrierCategoryList_Sel
    '機　能：ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ取得要求
    '引　数：lstrmas_carriercategorylistVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID                       ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：ltypCarrierCategory            ：ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ格納構造体
    '戻り値：Ture:正常、False:異常
    '作成日：2006/02/21 (Tue) 13:22:33 N.Kojima
    '更新日：
    '備　考：
    Public Function pubblnCarrierCategoryList_Sel(ByVal lstrmas_carriercategorylistVer As String, _
                                                  ByVal lstrSBID As String, _
                                                  ByRef ltypCarrierCategory As CarrierCategoryList) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "キャリアカテゴリリスト取得"
            pubblnCarrierCategoryList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            
            'Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_carriercategorylistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_carriercategorylistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
                
            'SB_ID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_carriercategorylist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果格納
                    
                    '@ｱﾚｲを格納
                    Call laMsg.getMsgAry(CPstrCATEGORY_LIST, laAry)     'ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ

                    '@ｷｬﾘｱｶﾃｺﾞﾘﾘｽﾄ構造体へ格納
                    With ltypCarrierCategory
                        
                        '@ﾘｽﾄｶｳﾝﾄ格納
                        .lngCarrierCategoryCnt = laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngCarrierCategoryCnt > 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            
                            '@配列の要素数を設定
                            If IsNothing(.typCarrierCategory) Then
                                .typCarrierCategory = New List(Of CarrierCategory)()
                            Else
                                .typCarrierCategory.Clear()
                            End If

                            Dim typCarrierCategoryTmp As CarrierCategory = New CarrierCategory()
                            llngCnt = 0
                            
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Call ltMsg.getString(CPstrSB_ID, typCarrierCategoryTmp.strSbID)                      'SBID
                                Call ltMsg.getString(CPstrCATEGORY_ID, typCarrierCategoryTmp.strCategoryID)          'ｶﾃｺﾞﾘID
                                Call ltMsg.getString(CPstrCATEGORY_NAME, typCarrierCategoryTmp.strCategoryName)      'ｶﾃｺﾞﾘ名

                                .typCarrierCategory.Add(typCarrierCategoryTmp)
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnCarrierCategoryList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_carriercategorylistVer)

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

    '関数名：pubblnLotChkJBatchList_Sel
    '機　能：蒸着ﾊﾞｯﾁ組ﾁｪｯｸ一覧取得要求
    '引　数：lstrlot_chkjbatchlistVer ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrSBID                       ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '　　　：lstrLotID                      ：ﾛｯﾄID
    '      ：ltypLotChkJBatchList           ：蒸着ﾊﾞｯﾁ組ﾁｪｯｸ構造体(応答Msg)
    '戻り値：Ture:正常、False:異常
    '作成日：2009/06/29 (Tue) 13:22:33 K.Nishizawa
    '更新日：2012/03/15 (Thu) 15:03:29 T.Oide
    '備　考：
    Public Function pubblnLotChkJBatchList_Sel(ByVal lstrlot_chkjbatchlistVer As String, _
                                               ByVal lstrSBID As String, _
                                               ByVal lstrLotID As String, _
                                               ByRef ltypLotChkJBatchList As JBatchFromLotList, _
                                               ByVal lstrTpalClass As String) As Boolean

        Dim lrMsg       As TfMsg            '要求Msg
        Dim laMsg       As TfMsg            '応答Msg
        Dim ltMsg       As TfMsg            '要求Msg2
        Dim laAry       As TfMsgAry         '要求Msgﾘｽﾄ
        Dim lstrRET     As String
        Dim llngCnt     As Integer
        
        Try
            
            '@初期化
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            pstrMessageName = "蒸着バッチ組実施有無"
            pubblnLotChkJBatchList_Sel = False
            
            '@MsgVer取得
            If lstrlot_chkjbatchlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_chkjbatchlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@SBID取得
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@LOTID取得
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            '@TPAL_CLASS
            If lstrTpalClass <> vbNullString Then
                Call lrMsg.addString(CPstrTPAL_CLASS, lstrTpalClass)
            Else
                Call lrMsg.addString(CPstrTPAL_CLASS, CPstrMsgNull)
            End If
            
            '@Msg送信
            Call pTerm.sendRequest(CPstrlot_chkjbatch, lrMsg, laMsg)
            
            Call laMsg.getString(CPstrRET, lstrRET)
            
            Select Case lstrRET
                Case CPstrTRUE
                    Call laMsg.getMsgAry(CPstrWF_LIST, laAry)
                    
                    ltypLotChkJBatchList.lngJBatchLotListCnt = laAry.Count
                    If ltypLotChkJBatchList.typJBatchLotList Is Nothing Then
                        ltypLotChkJBatchList.typJBatchLotList = New List(Of JBatchFromLot)
                    Else
                        ltypLotChkJBatchList.typJBatchLotList.Clear
                    End If

                    Dim typJBatchLotListTmp As JBatchFromLot = New JBatchFromLot

                    If ltypLotChkJBatchList.lngJBatchLotListCnt <> CPlngNumZero Then
                        
                        '@ｶｳﾝﾀ初期化
                        llngCnt = 0
                        
                        For Each ltMsg In laAry
                            With typJBatchLotListTmp
                                Call ltMsg.getString(CPstrWF_ID, .strWfId)
                                Call ltMsg.getString(CPstrBATCH_ID, .strBatchId)
                                Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)
                            End With
                            ltypLotChkJBatchList.typJBatchLotList.Add(typJBatchLotListTmp)
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    pubblnLotChkJBatchList_Sel = True
                    
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_chkjbatchlistVer)
                
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)

                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
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

    '関数名：pubblnLotChkEasyCombine_sel
    '機　能：簡易統合実施可否ﾁｪｯｸ
    '引　数：lstrLotChkeasycombine_Ver:MSG_VER
    '      ：lstrSBID:ｼｽﾃﾑﾌﾞﾛｯｸ
    '      ：lstrLotID:LOTID
    '      ：lstrOpID:大工程ID
    '      ：lstrStepID:小工程ID
    '      ：lstrResult:結果(0:実施不可 1:実施可)
    '戻り値：True：成功、False：失敗
    '作成日：2009/06/23 (Tue) 14:26:00 K.Nishizawa
    '
    Public Function pubblnLotChkEasyCombine_sel(ByVal lstrLotChkeasycombine_Ver As String, _
                                                ByVal lstrSBID As String, _
                                                ByVal lstrLotID As String, _
                                                ByRef lstrResult As String, _
                                                ByRef lstrDivCarrier As String, _
                                                ByRef lstrDivLotID As String) As Boolean
        Dim lrMsg       As TfMsg
        Dim laMsg       As TfMsg
        Dim lstrRET     As String
        

        Try
            
            pubblnLotChkEasyCombine_sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            pstrMessageName = "簡易統合実施可否チェック"
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrLotChkeasycombine_Ver <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrLotChkeasycombine_Ver)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@LOT_ID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkeasycombine, lrMsg, laMsg)
            
            Call laMsg.getString(CPstrRET, lstrRET)
            Select Case lstrRET
                Case CPstrTRUE
                    Call laMsg.getString(CPstrRESULT, lstrResult)
                    Call laMsg.getString(CPstrDIVIDE_LOT_ID, lstrDivLotID)
                    Call laMsg.getString(CPstrTO_CARRIER_ID, lstrDivCarrier)
                    
                    pubblnLotChkEasyCombine_sel = True
                    
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrLotChkeasycombine_Ver)
                Case Else
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select
            
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

    '関数名：pubblnWpIdBatchMoveIn_Ntf
    '機　能：ﾊﾞｯﾁ投入順通知
    '引　数：ltypEqBatchMoveIn      ：ﾊﾞｯﾁ投入順通知要求構造体
    '戻り値：True：成功、False：失敗
    '作成日：2009/07/16 (Thu) 11:22:02 N.Kojima
    '更新日：2009/07/16 (Thu) 11:22:02
    '備　考：
    Public Function pubblnWpIdBatchMoveIn_Ntf(ByRef ltypEqBatchMoveIn As EqBatchMoveIn) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         'ｱﾚｰ作成用
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lstrRET             As String           '通信結果格納用
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        
        Try

            pstrMessageName = "バッチ投入順通知"
            pubblnWpIdBatchMoveIn_Ntf = False
            
            lrMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypEqBatchMoveIn
            
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@ﾊﾞｯﾁID
                If .strBatchId <> vbNullString Then
                    Call lrMsg.addString(CPstrBATCH_ID, .strBatchId)
                Else
                    Call lrMsg.addString(CPstrBATCH_ID, CPstrMsgNull)
                End If
                
                '@ﾚｼﾋﾟID
                If .strRecipeId <> vbNullString Then
                    Call lrMsg.addString(CPstrRECIPE_ID, .strRecipeId)
                Else
                    Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
                End If
                
                '@投入順ｷｬﾘｱ情報ｾｯﾄ
                If .lngCarrierListCnt > 0 Then
                    
                    llngCnt = 0
                    
                    Do While .lngCarrierListCnt -1 >= llngCnt
                        
                        With .typCarrierList(llngCnt)
                            
                            '@投入順
                            If .strSeqNum <> vbNullString Then
                                Call ltMsg.addString(CPstrSEQ_NUM, .strSeqNum)
                            Else
                                Call ltMsg.addString(CPstrSEQ_NUM, CPstrMsgNull)
                            End If
                            
                            '@LDｷｬﾘｱID
                            If .strLoaderCarrierID <> vbNullString Then
                                Call ltMsg.addString(CPstrLOADER_CARRIER_ID, .strLoaderCarrierID)
                            Else
                                Call ltMsg.addString(CPstrLOADER_CARRIER_ID, CPstrMsgNull)
                            End If
                            
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱID
                            If .strUnloaderCarrierID <> vbNullString Then
                                Call ltMsg.addString(CPstrUNLOADER_CARRIER_ID, .strUnloaderCarrierID)
                            Else
                                Call ltMsg.addString(CPstrUNLOADER_CARRIER_ID, CPstrMsgNull)
                            End If
                            
                            '@機種区分
                            If .strUseId <> vbNullString Then
                                Call ltMsg.addString(CPstrUSE_ID, .strUseId)
                            Else
                                Call ltMsg.addString(CPstrUSE_ID, CPstrMsgNull)
                            End If
                            
                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear

                            llngCnt = llngCnt + 1
                        End With
                    Loop
                Else
                    ltMsg.Clear
                End If
                
                Call lrMsg.addMsgAry(CPstrCARRIER_LIST, lrAry)
                lrAry.Clear

            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(ltypEqBatchMoveIn.strMsgSubject, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
                
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnWpIdBatchMoveIn_Ntf = True
                    
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypEqBatchMoveIn.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
                                
        End Try
    End Function

    '関数名：pubblnLotJBatchConnectedInfo_Sel
    '機　能：TFT/CFﾛｯﾄ紐付き情報取得
    '引　数：ltypJBatchConnectedInfoRec  ：要求構造体
    '　　　：ltypJBatchConnectedInfoAns  ：応答構造体
    '戻り値：True：成功、False：失敗
    '作成日：2009/10/06 (Tue) 18:00:44 N.Kojima
    '更新日：2009/10/06 (Tue) 18:00:44 N.Kojima
    '備　考：
    Public Function pubblnLotJBatchConnectedInfo_Sel(ByRef ltypJBatchConnectedInfoRec As JBatchConnectedInfoRec, _
                                                     ByRef ltypJBatchConnectedInfoAns As JBatchConnectedInfoAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "TFT/CFロット紐付き情報取得"
            pubblnLotJBatchConnectedInfo_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypJBatchConnectedInfoRec

                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If

                '@CFﾌﾗｸﾞ
                If .strCfFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrCF_FLAG, .strCfFlag)
                Else
                    Call lrMsg.addString(CPstrCF_FLAG, CPstrMsgNull)
                End If

            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_jbatchconnectedinfo, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数をﾘｽﾄ件数として格納
                    ltypJBatchConnectedInfoAns.llngJBatchLotListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypJBatchConnectedInfoAns.llngJBatchLotListCnt > 0 Then

                        '@構造体定義
                        If ltypJBatchConnectedInfoAns.typJBatchLotList Is Nothing Then
                            ltypJBatchConnectedInfoAns.typJBatchLotList = New List(Of JBatchLotList)
                        End If
                        Do While (ltypJBatchConnectedInfoAns.typJBatchLotList.Count < ltypJBatchConnectedInfoAns.llngJBatchLotListCnt)
                            ltypJBatchConnectedInfoAns.typJBatchLotList.Add(New JBatchLotList)
                        Loop

                        Dim typJBatchLotListTmp As JBatchLotList = New JBatchLotList
                        '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                        llngCnt = 0

                        For Each ltMsg In laAry

                            '@受信結果取得
                            With typJBatchLotListTmp

                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)        'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                'ﾛｯﾄID
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                  '機種
                                Call ltMsg.getString(CPstrWF_QUANTITY, .strWfNum)           '数量(WF)
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipNum)       '数量(CHIP)
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)        '種別
                                Call ltMsg.getString(CPstrLOT_PRIORITY, .strPriority)       '優先度
                                Call ltMsg.getString(CPstrOP_ID, .strOpID)                  '大工程
                                Call ltMsg.getString(CPstrSTEP_ID, .strStepID)              '小工程
                                Call ltMsg.getString(CPstrCURRENT_STATUS_NAME, .strCurrentStatusName)   'ﾛｯﾄ現在状態
                            End With
                            ltypJBatchConnectedInfoAns.typJBatchLotList(llngCnt) = typJBatchLotListTmp
                            '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotJBatchConnectedInfo_Sel = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypJBatchConnectedInfoRec.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnLotJBatchConnectedInfo_Sel2
    '機　能：TFT/CFﾛｯﾄ紐付き情報取得
    '引　数：ltypJBatchConnectedInfoRec  ：要求構造体
    '　　　：ltypJBatchConnectedInfoAns2 ：応答構造体
    '戻り値：True：成功、False：失敗
    '作成日：2013/03/14 (Thu) 13:24:03 T.Oide
    '更新日：2014/11/05 (Wed) 09:59:18 H.Hayashi
    '備　考：
    '　　　：2014/11/05 (Wed) 09:39:46 H.Hayashi    組立無機ODFのシステム環境整備
    Public Function pubblnLotJBatchConnectedInfo_Sel2( _
            ByRef ltypJBatchConnectedInfoRec As JBatchConnectedInfoRec, _
            ByRef ltypJBatchConnectedInfoAns2 As JBatchConnectedInfoAns2) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg3              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry3              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ用
        Dim llngCnt3            As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "TFT/CFロット紐付き情報取得2"
            pubblnLotJBatchConnectedInfo_Sel2 = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
            ltMsg3 = New TfMsg
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry
            laAry3 = New TfMsgAry

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypJBatchConnectedInfoRec

                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If

            End With


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_jbatchconnectedinfo2, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrBATCH_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数をﾘｽﾄ件数として格納
                    ltypJBatchConnectedInfoAns2.lngJHBatchListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                    '@配列があればﾃﾞｰﾀ格納
                    If ltypJBatchConnectedInfoAns2.lngJHBatchListCnt > 0 Then

                        '@構造体定義
                        If ltypJBatchConnectedInfoAns2.typeJHBatchList Is Nothing Then
                            ltypJBatchConnectedInfoAns2.typeJHBatchList = New List(Of JHBatchList)
                        End If
                        Do While (ltypJBatchConnectedInfoAns2.typeJHBatchList.Count < ltypJBatchConnectedInfoAns2.lngJHBatchListCnt)
                            ltypJBatchConnectedInfoAns2.typeJHBatchList.Add(New JHBatchList)
                        Loop

                        Dim typeJHBatchListTmp As JHBatchList = New JHBatchList

                        '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                        llngCnt = 0

                        For Each ltMsg In laAry

                            '@受信結果取得
                            With typeJHBatchListTmp

                                Call ltMsg.getString(CPstrEQ_TYPE, .strEqType)                  'EQﾀｲﾌﾟ
                                Call ltMsg.getString(CPstrWP_NAME, .strWpName)                  '装置名
                                Call ltMsg.getString(CPstrBATCH_ID, .strJHBatchID)              'ﾊﾞｯﾁID

                                '@LOT_LIST
                                Call ltMsg.getMsgAry(CPstrLOT_LIST, laAry2)
                                
                                '@ﾛｯﾄﾘｽﾄ数格納
                                .llngLotListCnt = laAry2.Count
                                
                                '@ﾛｯﾄﾘｽﾄは0以上か
                                If .llngLotListCnt > 0 Then
                                
                                    '@構造体定義
                                    .typLotList = New List(Of TftCfLotList)
                                    Do While (.typLotList.Count < .llngLotListCnt)
                                        .typLotList.Add(New TftCfLotList)
                                    Loop

                                    Dim typLotListTmp As TftCfLotList = New TftCfLotList

                                    '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                                    llngCnt2 = 0
                            
                                    '@ﾛｯﾄﾘｽﾄの要素取得
                                    For Each ltMsg2 In laAry2
                                    
                                         With typLotListTmp
                                    
                                            Call ltMsg2.getString(CPstrLOT_ID, .strLotID)           'ﾛｯﾄID
                                            Call ltMsg2.getString(CPstrCARRIER_ID, .strCarrierId)   'ｷｬﾘｱID
                                            Call ltMsg2.getString(CPstrFLOW_CLASS, .strFlowClass)   '流動区分
                                            Call ltMsg2.getString(CPstrPD_ID, .strPdId)             '機種
                                            Call ltMsg2.getString(CPstrCF_FLAG, .strCfFlag)         'CFﾌﾗｸﾞ
        '@↓2014/11/05 (Wed) 09:58:40 H.Hayashi **************************************************
                                            Call ltMsg2.getString(CPstrLP_FLAG, .strLpFlag)         'LPﾌﾗｸﾞ
        '@↑2014/11/05 (Wed) 09:58:40 H.Hayashi **************************************************
                                            Call ltMsg2.getString(CPstrCHIP_QUANTITY, .strChipQuantity)   'ﾁｯﾌﾟ数
                                            Call ltMsg2.getString(CPstrOP_ID, .strOpID)             '大工程
                                            Call ltMsg2.getString(CPstrSTEP_ID, .strStepID)         '小工程
                                            Call ltMsg2.getString(CPstrCURRENT_STATUS_NAME, .strCurrentStatusName)   'ﾛｯﾄ現在状態
                                            Call ltMsg2.getString(CPstrTPAL_CLASS, .strTpalClass)   'TPAL制限
                                            
                                            '@WF_LIST-----------------------------------------------------------
                                            Call ltMsg2.getMsgAry(CPstrWF_LIST, laAry3)
                                            
                                            '@ﾛｯﾄﾘｽﾄ数格納
                                            .lngWfListCnt = laAry3.Count

                                            '@ﾛｯﾄﾘｽﾄは0以上か
                                            If .lngWfListCnt > 0 Then
                                            
                                                '@構造体定義
                                                .strWfList = New List(Of String)

                                                Do While (.strWfList.Count < .lngWfListCnt)
                                                    .strWfList.Add("")
                                                Loop
                                                
                                                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                                                llngCnt3 = 0

                                                '@ﾛｯﾄﾘｽﾄの要素取得
                                                For Each ltMsg3 In laAry3
                                                    Call ltMsg3.getString(CPstrWF_ID, .strWfList(llngCnt3))           'WF_ID
                                                    llngCnt3 = llngCnt3 + 1
                                                Next
                                                
                                                '@ｸﾘｱ
                                                ltMsg3 = Nothing
                                            End If
                                            
                                            '@ｸﾘｱ
                                            laAry3 = Nothing


                                            '@TPAL_LOT_LIST-----------------------------------------------------------
                                            Call ltMsg2.getMsgAry(CPstrTPAL_LOT_LIST, laAry3)
                                            
                                            '@ﾛｯﾄﾘｽﾄ数格納
                                            .lngTpalLotListCnt = laAry3.Count
                                            
                                            '@ﾛｯﾄﾘｽﾄは0以上か
                                            If .lngTpalLotListCnt > 0 Then
                                            
                                                '@構造体定義
                                                .typeTpalLotList = New List(Of TpalList)
                                                Do While (.typeTpalLotList.Count < .lngTpalLotListCnt)
                                                    .typeTpalLotList.Add(New TpalList)
                                                Loop

                                                Dim typeTpalLotListTmp As TpalList = New TpalList

                                                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                                                llngCnt3 = 0
                                            
                                                '@ﾛｯﾄﾘｽﾄの要素取得
                                                For Each ltMsg3 In laAry3
                                                
                                                    With typeTpalLotListTmp
                                                    
                                                        Call ltMsg3.getString(CPstrLOT_ID, .strTpalLotId)            'ﾛｯﾄID
                                                        Call ltMsg3.getString(CPstrCARRIER_ID, .strCarrierId)        'ｷｬﾘｱID
                                                        Call ltMsg3.getString(CPstrCHIP_QUANTITY, .strChipQuantity)  'ﾁｯﾌﾟ数
                                                        Call ltMsg3.getString(CPstrOP_ID, .strOpID)                  '大工程
                                                        Call ltMsg3.getString(CPstrSTEP_ID, .strStepID)              '小工程
                                                        Call ltMsg3.getString(CPstrLOT_EVENT_ID, .strLotEventId)     'ﾛｯﾄｲﾍﾞﾝﾄID
                                                        Call ltMsg3.getString(CPstrCURRENT_STATUS_NAME, .strCurrentStatusName) 'ﾛｯﾄ現在状態
                                                       
                                                    End With
                                                    .typeTpalLotList(llngCnt3) = typeTpalLotListTmp
                                                    llngCnt3 = llngCnt3 + 1
                                                    
                                                Next
                                                
                                                '@ｸﾘｱ
                                                ltMsg3 = Nothing
                                            End If
                                            
                                            '@ｸﾘｱ
                                            laAry3 = Nothing
                                            '----------------------------------------------------------------------
                                            
                                        End With
                                        .typLotList(llngCnt2) = typLotListTmp

                                        '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                                        llngCnt2 = llngCnt2 + 1
                                    Next
                                    
                                    '@ｸﾘｱ
                                    ltMsg2 = Nothing
                                End If
                                
                                '@ｸﾘｱ
                                laAry2 = Nothing
                            End With
                            ltypJBatchConnectedInfoAns2.typeJHBatchList(llngCnt) = typeJHBatchListTmp
                            '@ﾙｰﾌﾟｶｳﾝﾀを+1する
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotJBatchConnectedInfo_Sel2 = True


                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@ ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, ltypJBatchConnectedInfoRec.strMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            ltMsg3 = Nothing
            laAry = Nothing
            laAry2 = Nothing
            laAry3 = Nothing

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
            ltMsg3 = Nothing
            laAry = Nothing
            laAry2 = Nothing
            laAry3 = Nothing
            
        End Try
    End Function

    '関数名：pubblnElt_VFIMapget_Sel
    '機　能：無機異物Map要求
    '引　数：lstrelt_vifmapgetVer   ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：lstrWFID               ：WFID
    '　　　：ltypWFMapInfo          ：ﾁｯﾌﾟﾘｽﾄ格納構造体
    '戻り値：True：成功、False：失敗
    '作成日：2011/08/26 (Fri) 09:11:37 T.Oide
    '更新日：2011/08/26 (Fri) 09:11:37
    '備　考：
    '　　　：2011/08/26 (Fri) 09:11:37 T.Oide   R8-3無機異物Map登録の対応
    Public Function pubblnElt_VFIMapget_Sel( _
                    ByVal lstrelt_vifmapgetVer As String, _
                    ByVal lstrClassDivision As String, _
                    ByVal lstrWFID As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄtemp)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄｱﾚｰ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
            
        Try

            
            pstrMessageName = "無機異物Map要求"
            
            '@初期値設定
            pubblnElt_VFIMapget_Sel = False

            lrMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg


            '@送信ﾒｯｾｰｼﾞ作成
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrelt_vifmapgetVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrelt_vifmapgetVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@CLASS_DIVISION
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If
            
            
            '@SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@作業者ID
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '@WP_ID
            If ptypLotprestate.strWpID <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, ptypLotprestate.strWpID)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            
            '@WFIDﾘｽﾄ
            If lstrWFID <> vbNullString Then
                Call ltMsg.addString(CPstrWF_ID, lstrWFID)
                Call lrAry.Add(ltMsg)
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
            Else
                Call lrMsg.addMsgAry(CPstrWF_LIST, lrAry)
                lrAry.Clear
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrelt_vfimapget, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
            
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@処理成功
                    pubblnElt_VFIMapget_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrelt_vifmapgetVer)
                    
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
            lrAry = Nothing
            laMsg = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

    '関数名：pubblnReportPoint_Sel
    '機　能：実績報告工程取得
    '引　数：lstrmas_reportpointVer：ﾒｯｾｰｼﾞVer
    '　　　：lstrSBID：SB_ID
    '　　　：lstrPdID：PD_ID
    '　　　：ltypeReportPoint：取得ﾃﾞｰﾀ格納
    '戻り値：True：成功、False：失敗
    '作成日：2014/01/14 (Tue) 11:47:17 T.Oide
    '更新日：2014/01/14 (Tue) 11:47:17
    '備　考：
    Public Function pubblnReportPoint_Sel(ByVal lstrmas_reportpointVer As String, _
                                          ByVal lstrSBID As String, _
                                          ByVal lstrPdID As String, _
                                          ByRef ltypeReportPoint As ReportPoint _
                                          ) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt1            As Integer          '機種ｶｳﾝﾄ用
        Dim llngCnt2            As Integer          '1機種の実績報告ﾏｽﾀｰｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "実績報告ポイント取得"
            pubblnReportPoint_Sel = False               '結果の初期化
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            
            'Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_reportpointVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_reportpointVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
                
            'SB_ID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            'PD_ID
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_reportpoint, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果格納
                    
                    With ltypeReportPoint
                    
                        '@SB_ID格納
                        Call laMsg.getString(CPstrSB_ID, ltypeReportPoint.strSbID)
                        
                        '@ｱﾚｲを格納(機種ﾘｽﾄ)
                        Call laMsg.getMsgAry(CPstrPD_LIST, laAry)

                        '@ﾘｽﾄｶｳﾝﾄ格納
                         .lngPdListCnt = laAry.Count

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認(機種ﾘｽﾄ)
                        If laAry.Count > 0 Then
                        
                            '@配列の要素数を設定(機種ﾘｽﾄ)
                            If .typePdList Is Nothing Then
                                .typePdList = New List(Of PdReportPointList)
                            End If
                        
                            Do While (.typePdList.Count < laAry.Count)
                                .typePdList.Add(New PdReportPointList)
                            Loop

                            Dim typePdListTmp As PdReportPointList = New PdReportPointList

                            '@ｱﾚｰの各要素取得(機種ﾘｽﾄ)
                            llngCnt1 = 0
                            For Each ltMsg In laAry
                                
                                Call ltMsg.getString(CPstrPD_ID, typePdListTmp.strPdId)     'PD_ID
                                Call ltMsg.getMsgAry(CPstrREPORT_POINT_LIST, laAry2)                '実績報告ﾘｽﾄ取得
                                typePdListTmp.lngPdReportPointCnt = laAry2.Count
                                
                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認(1機種の実績報告ﾘｽﾄ)
                                If laAry2.Count > 0 Then
            
                                    '@配列の要素数を設定(1機種の実績報告ﾘｽﾄ)
                                        typePdListTmp.typeReportPointList = New List(Of ReportPointList)


                                    Dim typeReportPointListTmp As ReportPointList = New ReportPointList
                                    llngCnt2 = 0
                                    '@ｱﾚｰ2の各要素取得(1機種の実績報告ﾘｽﾄ)
                                    For Each ltMsg2 In laAry2
                                        
                                        With typeReportPointListTmp
                                        
                                            Call ltMsg2.getString(CPstrSEQ_NUM, .strSeqNum)              'SEQ_NUM
                                            Call ltMsg2.getString(CPstrPRTS_TYPE, .strPrtsType)          'ﾊﾟｰﾂﾀｲﾌﾟ
                                            Call ltMsg2.getString(CPstrOP_ID, .strOpID)                  '大工程
                                            Call ltMsg2.getString(CPstrSTEP_ID, .strStepID)              '小工程
                                            Call ltMsg2.getString(CPstrCOLLECT_TYPE, .strCollectType)    '集計ﾀｲﾌﾟ
                                            Call ltMsg2.getString(CPstrPART_CODE, .strPartCode)          '部品ｺｰﾄﾞ
                                            Call ltMsg2.getString(CPstrPART_NAME, .strPartName)          '部品名
                                            
                                        End With
                                        typePdListTmp.typeReportPointList.Add(typeReportPointListTmp)
                                        llngCnt2 = llngCnt2 + 1

                                    Next
                                    .typePdList(llngCnt1) = typePdListTmp
                                    llngCnt1 = llngCnt1 + 1
                                    
                                End If
                                
                            Next
                            
                        End If
                        
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnReportPoint_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_reportpointVer)

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
            ltMsg2 = Nothing
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
            laAry = Nothing
            laAry2 = Nothing
            
        End Try
    End Function

    '関数名：chkOdfCover
    '機　能：無機ODF貼り合せ結果
    '引　数：lstrMsgVer：ﾒｯｾｰｼﾞVer
    '　　　：lstrSBID：SB_ID
    '　　　：lstrLotID：LOT_ID
    '　　　：lstrOdfJBatchStatus：無機ODF貼り合せ蒸着ﾊﾞｯﾁ状態
    '　　　：lstrHoldTermDate：保留期間
    '戻り値：True:正常終了、False:異常終了
    '作成日：2014/11/17 (Mon) 17:06:45 H.Hayashi
    '更新日：2014/12/18 (Thu) 15:40:02 T.Oide
    '備　考：
    Public Function chkOdfCover(ByVal lstrMsgVer As String, _
                                ByVal lstrSBID As String, _
                                ByVal lstrLotID As String, _
                                ByRef lstrOdfJBatchStatus As String, _
                                ByRef lstrHoldTermDate As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "無機ODF貼り合せ結果"
            chkOdfCover = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
                
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
                
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkodfcover, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                   '@受信結果取得
                    
                    'エラー対応
                    If InStr(laMsg.toString, CPstrODF_J_BATCH_STATUS) = 0 Then
                        '@タグがない場合
                        lstrOdfJBatchStatus = 0
                    Else
                        '@タグがある場合
                        Call laMsg.getString(CPstrODF_J_BATCH_STATUS, lstrOdfJBatchStatus) '無機ODF貼り合せ蒸着ﾊﾞｯﾁ状態
                    End If

                    Call laMsg.getString(CPstrHOLD_TERM_DATE, lstrHoldTermDate)        '保留期間
                                
                    '@関数の処理結果(成功)格納
                    chkOdfCover = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
            End Select
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            
        End Try
    End Function

    '関数名：odfholdlastupdate
    '機　能：無機ODF貼り合せﾛｯﾄ保時の最新時間取得
    '引　数：lstrMsgVer：ﾒｯｾｰｼﾞVer
    '　　　：lstrSBID：SB_ID
    '　　　：lstrLotID：LOT_ID
    '　　　：lstrOdfConverLastUpdate：最新更新時間
    '引　数：
    '戻り値：True:正常終了、False:異常終了
    '作成日：2014/11/17 (Mon) 17:06:45 H.Hayashi
    '更新日：2014/11/17 (Mon) 17:06:45 H.Hayashi
    '備　考：
    Public Function odfholdlastupdate(ByVal lstrMsgVer As String, _
                                ByVal lstrSBID As String, _
                                ByVal lstrLotID As String, _
                                ByRef lstrOdfConverLastUpdate As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "無機ODF貼り合せ結果"
            odfholdlastupdate = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
                
            '@ｼｽﾃﾑﾌﾞﾛｯｸ
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
                
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_odfholdlastupdate, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                   '@受信結果取得
                    Call laMsg.getString(CPstrLOT_LAST_UPDATE, lstrOdfConverLastUpdate) '最新更新時間
                    
                    '@関数の処理結果(成功)格納
                    odfholdlastupdate = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
            End Select
            
            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            
            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@解放
            lrMsg = Nothing
            laMsg = Nothing
            lrAry = Nothing
            
        End Try
    End Function

    '関数名：pubblnOvertake_Sel
    '機　能：無機ODF追越制限状態取得
    '引　数：lstrMsgVer         ：MsgVer
    '      ：lstrLotID　　　　　：ﾛｯﾄID
    '　　　：lstrWpId           ：装置ID
    '　　　：lstrOvertakeLotId  ：追越制限違反ﾛｯﾄ
    '　　　：lstrOvertakeStatus ：追越制限違反状態(0:追越違反無、1:追越違反有)
    '戻り値：True：成功、False：失敗
    '作成日：2014/11/26 (Wed) 17:02:42 H.Hayashi
    '更新日：
    '備　考：
    '　　　：
    Public Function pubblnOvertake_Sel(ByVal lstrMsgVer As String, _
                                        ByVal lstrLotID As String, _
                                        ByVal lstrWpId As String, _
                                        ByRef lstrOvertakeLotId As String, _
                                        ByRef lstrOvertakeStatus As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "無機ODF追越制限状態取得"
            pubblnOvertake_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
                
            '@送信ﾒｯｾｰｼﾞ作成
            'SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
                
            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkovertake, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                   '@受信結果取得
                    Call laMsg.getString(CPstrOVERTAKE_STATUS, lstrOvertakeStatus) '追越制限違反状態(0:追越違反無、1:追越違反有)
                    Call laMsg.getString(CPstrOVERTAKE_LOT_ID, lstrOvertakeLotId) '追越制限違反ﾛｯﾄ
                    
                    '@関数の処理結果(成功)格納
                    pubblnOvertake_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnOvertakeCancel_Sel
    '機　能：無機ODF追越制限取消状態取得
    '引　数：lstrMsgVer         ：MsgVer
    '      ：lstrLotID　　　　　：ﾛｯﾄID
    '　　　：lstrWpId           ：装置ID
    '　　　：lstrOvertakeLotId  ：追越制限違反ﾛｯﾄ
    '　　　：lstrOvertakeStatus ：追越制限違反状態(0:追越違反無、1:追越違反有)
    '戻り値：True：成功、False：失敗
    '作成日：2014/11/26 (Wed) 17:03:21 H.Hayashi
    '更新日：
    '備　考：
    '　　　：
    Public Function pubblnOvertakeCancel_Sel(ByVal lstrMsgVer As String, _
                                        ByVal lstrLotID As String, _
                                        ByVal lstrWpId As String, _
                                        ByRef lstrOvertakeLotId As String, _
                                        ByRef lstrOvertakeStatus As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "無機ODF追越制限取消状態取得"
            pubblnOvertakeCancel_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
                
            '@送信ﾒｯｾｰｼﾞ作成
            'SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
                
            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkovertakecancel, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                   '@受信結果取得
                    Call laMsg.getString(CPstrOVERTAKE_STATUS, lstrOvertakeStatus) '追越制限違反状態(0:追越違反無、1:追越違反有)
                    Call laMsg.getString(CPstrOVERTAKE_LOT_ID, lstrOvertakeLotId) '追越制限違反ﾛｯﾄ
                    
                    '@関数の処理結果(成功)格納
                    pubblnOvertakeCancel_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnLotChkFrTimeRecipe_Chk
    '機　能：FR処理可能範囲ﾚｼﾋﾟ確認
    '引　数：lstrlot_chkchangeorderVer  ：ﾒｯｾｰｼﾞVer
    '　　　：lstrSbId                   ：SBID
    '　　　：lstrLotID                  ：ﾛｯﾄID
    '　　　：lstrGuidMsg                ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode            ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：Ture：ﾁｪｯｸ処理成功、False：ﾁｪｯｸ処理失敗
    '作成日：2015/11/15 (Sun) 18:11:12 H.Hayashi
    '更新日：
    '備　考：
    Public Function pubblnLotChkFrTimeRecipe_Chk(ByVal lstrlot_chkchangeorderVer As String, _
                                                ByVal lstrSBID As String, _
                                                ByVal lstrLotID As String, _
                                                ByVal lstrOpID As String, _
                                                ByVal lstrStepID As String, _
                                                ByVal lstrWpId As String, _
                                                ByVal lstrRecipeID As String, _
                                                ByVal lstrJobName As String, _
                                                ByRef lstrFrRecipeStatus As String, _
                                                ByRef lstrNgChamberId As String, _
                                                ByRef lstrNgProcessTime As String, _
                                                ByRef lstrNgRecipeId As String, _
                                                ByRef lstrGuidMsg As String, _
                                                ByRef lstrGuidMsgCode As String) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)   
        Dim lstrRET             As String           '応答取得
            
        Try

            '@各種初期化
            pstrMessageName = "FR処理可能範囲レシピ確認"

            pubblnLotChkFrTimeRecipe_Chk = False
            
            '@ｵﾌﾞｼﾞｪｸﾄの設定
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_chkchangeorderVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_chkchangeorderVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, Replace(lstrLotID, vbCrLf, vbNullString))
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

            '@大工程
            If lstrOpID <> vbNullString Then
                Call lrMsg.addString(CPstrOP_ID, Replace(lstrOpID, vbCrLf, vbNullString))
            Else
                Call lrMsg.addString(CPstrOP_ID, CPstrMsgNull)
            End If
            
            '@小工程
            If lstrStepID <> vbNullString Then
                Call lrMsg.addString(CPstrSTEP_ID, Replace(lstrStepID, vbCrLf, vbNullString))
            Else
                Call lrMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
            End If
                
            '@装置ID
            If lstrWpId <> vbNullString Then
                Call lrMsg.addString(CPstrWP_ID, lstrWpId)
            Else
                Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
            End If
            
            '@ﾚｼﾋﾟID
            If lstrRecipeID <> vbNullString Then
                Call lrMsg.addString(CPstrRECIPE_ID, Replace(lstrRecipeID, vbCrLf, vbNullString))
            Else
                Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
            End If
                
            '@要求機能名称
            If lstrJobName <> vbNullString Then
                Call lrMsg.addString(CPstrJOB_NAME, lstrJobName)
            Else
                Call lrMsg.addString(CPstrJOB_NAME, CPstrMsgNull)
            End If
            
            '@=======================
            '@ ﾒｯｾｰｼﾞ送信＆受信結果取得
            '@=======================
            Call pTerm.sendRequest(CPstrlot_chkfrtimerecipe, lrMsg, laMsg)
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果結果により処理分岐 ★
            Select Case lstrRET
                
                '@〓 True：通信成功 〓
                Case CPstrTRUE
                    
                    '@受信結果格納
                    Call laMsg.getString(CPstrFR_RECIPE_STATUS, lstrFrRecipeStatus)  'FR処理可能範囲ﾚｼﾋﾟ確認結果
                    Call laMsg.getString(CPstrNG_CHAMBER_ID, lstrNgChamberId)        'FrNG処理部
                    Call laMsg.getString(CPstrNG_PROCESS_TIME, lstrNgProcessTime)    'FrNGFR累積時間
                    Call laMsg.getString(CPstrNG_RECIPE_ID, lstrNgRecipeId)          'FrNGﾚｼﾋﾟ
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                      'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)             'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    
                    '@戻り値に"True：ﾁｪｯｸ処理成功"をｾｯﾄ
                    pubblnLotChkFrTimeRecipe_Chk = True
                
                
                '@〓 False：通信失敗 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@ ﾒｯｾｰｼﾞVer判定処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_chkchangeorderVer)
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
            '@ｵﾌﾞｼﾞｪｸﾄの解放
            lrMsg = Nothing
            laMsg = Nothing

            Exit Function


        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄの解放
            lrMsg = Nothing
            laMsg = Nothing
            
            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換
            '@=======================
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '関数名：pubblnGrbChk_Sel
    '機　能：GRB状態確認
    '引　数：lstrMsgVer         ：MsgVer
    '      ：lstrLotID　　　　　：ﾛｯﾄID
    '　　　：lstrWpId           ：装置ID
    '　　　：lstrGrbStatus　　　：GRB確認結果
    '戻り値：True：成功、False：失敗
    '作成日：2016/02/11 (Thu) 22:39:28 H.Hayashi
    '更新日：
    '備　考：
    '　　　：
    Public Function pubblnGrbChk_Sel(ByVal lstrMsgVer As String, _
                                     ByVal lstrLotID As String, _
                                     ByRef lstrGrbStatus As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "GRB状態取得"
            pubblnGrbChk_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
                
            '@送信ﾒｯｾｰｼﾞ作成
            'SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾛｯﾄID
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If
                       
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkgrb__, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                   '@受信結果取得
                    Call laMsg.getString(CPstrGRB_STATUS, lstrGrbStatus) 'GRB状態
                    
                    '@関数の処理結果(成功)格納
                    pubblnGrbChk_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

    '関数名：pubblnMasALDProcessList_Sel
    '機　能：防湿ALD処理ﾏｽﾀ取得
    '引　数：lstrMsgVer             ：Msgﾊﾞｰｼﾞｮﾝ
    '　　　：ltypALDProcessList()   ：格納ﾃﾞｰﾀ
    '　　　：llngALDProcessListCnt  ：ﾃﾞｰﾀｶｳﾝﾄ
    '戻り値：True：正常、False：異常
    '作成日：2018/08/03 (Fri) 16:22:14 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnMasALDProcessList_Sel(ByVal lstrMsgVer As String, _
                                                ByRef ltypALDProcessList As List(Of ALDProcessList), _
                                                ByRef llngALDProcessListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "ALD処理マスタ取得"
            pubblnMasALDProcessList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_aldprocesslist, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrALD_PROCESS_LIST, laAry)
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                    llngALDProcessListCnt = laAry.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngALDProcessListCnt > 0 Then
                        If ltypALDProcessList Is Nothing Then
                            ltypALDProcessList = New List(Of ALDProcessList)
                        End If
                        Do While (ltypALDProcessList.Count < llngALDProcessListCnt)
                            ltypALDProcessList.Add(New ALDProcessList)
                        Loop

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            Dim ltypALDProcessListTmp As ALDProcessList = New ALDProcessList   
                            '@受信結果取得
                            With ltypALDProcessListTmp
                                Call ltMsg.getString(CPstrALD_PROCESS_NUM, .strProcessNum)
                                Call ltMsg.getString(CPstrALD_PROCESS_NAME, .strProcessName)
                                Call ltMsg.getString(CPstrEQ_TYPE, .strEqType)
                                Call ltMsg.getString(CPstrALD_PROCESS_MODE_ID, .strModeId)
                                
                            End With
                            ltypALDProcessList(llngCnt) = ltypALDProcessListTmp
                            llngCnt = llngCnt + 1
                        Next
                    End If
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasALDProcessList_Sel = True
                     
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                                
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
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnEqALDProcessChange_Upd
    '機　能：装置状態変更
    '引　数：lstrMsgVer
    '　　　：ltypALDProcessChange
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/06 (Mon) 19:13:03 Y.Yoneyama
    '更新日：
    '備　考：
    Public Function pubblnEqALDProcessChange_Upd(ByVal lstrMsgVer As String, _
                                                 ByRef ltypALDProcessChange As ALDProcessChange) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        
        Try

            pstrMessageName = "防湿ALD処理変更"
            pubblnEqALDProcessChange_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            With ltypALDProcessChange
                '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If lstrMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@SBID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
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
                
                '@変更後ID
                If .strALDProcessModeId <> vbNullString Then
                    Call lrMsg.addString(CPstrALD_PROCESS_MODE_ID, .strALDProcessModeId)
                Else
                    Call lrMsg.addString(CPstrALD_PROCESS_MODE_ID, CPstrMsgNull)
                End If
                
                '@作業者ID
                If pstrUserID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                        
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__aldprocesschange, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                
                '@成功の場合(true)
                Case CPstrTRUE
                        
                    '@関数の処理結果(成功)格納
                    pubblnEqALDProcessChange_Upd = True
                
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)
                    
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：pubblnMasTapeStickGrList_Sel
    '機　能：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ取得
    '引　数：CMstrmas_tapeStickGrListVer    ：機能Ver
    '　　　：mtypTapeStickList()            ：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ格納
    '　　　：pstrSBID                       ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/06 (Mon) 15:37:35 T.Oide
    '更新日：2018/08/06 (Mon) 15:37:35
    '備　考：
    Public Function pubblnMasTapeStickGrList_Sel(ByVal strMsgVer As String, _
                                                 ByRef typTapeStickList As TapeStickGrList, _
                                                 ByVal strSbID As String) As Boolean
                                                   
        Dim lrMsg               As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)
        Dim ltMsg2              As TfMsg             '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim laAry2              As TfMsgAry          '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String            '応答取得
        Dim llngCnt             As Integer           'ｱﾚｲｶｳﾝﾄ用
        Dim llngCnt2            As Integer
        Dim lstrSBID            As String
        
        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg2 = New TfMsg
            laAry = New TfMsgAry
            laAry2 = New TfMsgAry
            
            '@初期設定
            pstrMessageName = "ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ取得"
            pubblnMasTapeStickGrList_Sel = False
            
            '@***********************
            '@　送信ﾒｯｾｰｼﾞの作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If strSbID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, strSbID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If strMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, strMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_tapestickGrlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
                
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@SB_ID取得
                    Call laMsg.getString(CPstrSB_ID, lstrSBID)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得ﾄ
                    Call laMsg.getMsgAry(CPstrTAPE_STICK_GROUP_LIST, laAry)
                    
                    With typTapeStickList
                        
                        .strSbID = lstrSBID                                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認：機種数
                        .lngTapeStickGrCnt = laAry.Count
                        
                        '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟが1件以上あるか
                        If .lngTapeStickGrCnt > 0 Then
                            
                            '@配列の定義
                            .typTapeStickGr = New List(Of TapeStickGr)
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                Dim typTapeStickGrTmp As TapeStickGr = New TapeStickGr
                                '@受信結果取得
                                With typTapeStickGrTmp
                                
                                    Call ltMsg.getString(CPstrTAPE_STICK_GROUP, .strTapeStickGr)    'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                                    Call ltMsg.getString(CPstrA_TRAY_CHIP_NUM, .strAtrayChipNum)    'Aﾄﾚｰ収容数
            
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得ﾄ
                                    Call ltMsg.getMsgAry(CPstrPD_LIST, laAry2)
                                
                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認：機種数
                                    .lngPdListCnt = laAry2.Count
                                
                                    '@機種が1件以上あるか
                                    If .lngPdListCnt > 0 Then
                                        
                                        '@配列の定義
                                        .typPdList = New List(Of typTapeStickPdList)
 
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                        llngCnt2 = 0
                                        For Each ltMsg2 In laAry2
                                            Dim typPdListTmp As typTapeStickPdList = New typTapeStickPdList
                                            '@受信結果取得
                                            With typPdListTmp
                                            
                                                Call ltMsg2.getString(CPstrPD_ID, .strPdId)              '機種
                                                Call ltMsg2.getString(CPstrPARENT_PD_ID, .strParentPdId) '親機種
                        
                                            End With
                                            .typPdList.Add(typPdListTmp)
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                        
                                    End If
                                
                                
                                End With
                                .typTapeStickGr.Add(typTapeStickGrTmp)
                                llngCnt = llngCnt + 1
                            Next
                            
                        End If
                    
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnMasTapeStickGrList_Sel = True
                    
                    
                '@〓 1：FALSE(失敗、異常) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, strMsgVer)
                    
                    
                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                    
            End Select
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            laAry = Nothing
            laAry2 = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            ltMsg2 = Nothing
            laAry = Nothing
            laAry2 = Nothing
            
        End Try
    End Function

    '関数名：pubblnAldBatchList_Sel
    '機　能：ALDﾊﾞｯﾁﾘｽﾄ取得
    '引　数：strMsgVer          ：機能Ver
    '　　　：typAldBatchList    ：ALDﾊﾞｯﾁﾘｽﾄ
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/06 (Mon) 15:37:35 T.Oide
    '更新日：2019/08/06 (Tue) 14:45:24 T.Oide
    '備　考：
    Public Function pubblnAldBatchList_Sel(ByVal strMsgVer As String, _
                                           ByRef typAldBatchList As typAldBatchList) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim lstrBatchID         As String
        Dim lstrBefBatchId      As String           'ﾙｰﾌﾟ内の前回値退避用
        Dim llngBatchCnt        As Integer
        Dim llngLotCnt          As Integer
        
        Try
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            
            '@初期設定
            pstrMessageName = "ALDﾊﾞｯﾁﾘｽﾄ取得"
            pubblnAldBatchList_Sel = False
            
            With typAldBatchList
                
                '@情報ｸﾘｱ
                .lngAldBatchListCnt = 0
                If .typAldBatchList Is Nothing Then
                    .typAldBatchList = New List(Of typAldBatch)
                Else
                    .typAldBatchList.Clear()
                End If
                
                '@***********************
                '@　送信ﾒｯｾｰｼﾞの作成
                '@***********************
                '@ｼｽﾃﾑﾌﾞﾛｯｸID
                If pstrSBID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, pstrSBID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                '@Msgﾊﾞｰｼﾞｮﾝ
                If strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrbat_aldbatchlist, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@★ 通信結果(SVからの応答)により処理分岐 ★
                Select Case lstrRET
                    
                    '@〓 0：TRUE(成功) 〓
                    Case CPstrTRUE
                        
                        '@SB_ID取得
                        Call laMsg.getString(CPstrSB_ID, .strSbID)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ取得ﾄ
                        Call laMsg.getMsgAry(CPstrBATCH_LIST, laAry)
                        
                        Dim typAldBatchListTmp As typAldBatch

                        '@1件以上あるか
                        If laAry.Count > 0 Then
                            
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            For Each ltMsg In laAry
                                
                                '@ﾊﾞｯﾁID取得
                                Call ltMsg.getString(CPstrBATCH_ID, lstrBatchID)

                                '@ﾊﾞｯﾁIDは前回と異なるか
                                If lstrBatchID <> lstrBefBatchId Then
                                
                                     typAldBatchListTmp = New typAldBatch

                                    '@違うﾊﾞｯﾁIDの場合、新規要素に格納
                                    llngBatchCnt = llngBatchCnt + 1  
                                    Do While (.typAldBatchList.Count < llngBatchCnt )
                                        .typAldBatchList.Add(New typAldBatch)
                                    Loop

                                    With typAldBatchListTmp
                                        Call ltMsg.getString(CPstrBATCH_ID, .strBatchId)                    'ﾊﾞｯﾁID
                                        Call ltMsg.getString(CPstrBATCH_STATUS, .strBatchStatus)            'ｽﾃｰﾀｽ
                                        '@↓2019/08/06 (Tue) 14:35:49 T.Oide  **************************************************
                                        Call ltMsg.getString(CPstrEDITABLE, .strEditable)                   '編集可否
                                        '@↑2019/08/06 (Tue) 14:35:49 T.Oide  **************************************************
                                        Call ltMsg.getString(CPstrPLAN_THROWIN_DATE, .strPlanThrowinDate)   '投入予定日
                                        Call ltMsg.getString(CPstrBATCH_FLOW_CLASS, .strBatchFlowClass)     'ﾊﾞｯﾁ流動区分
                                        Call ltMsg.getString(CPstrMONITOR_USE_FLAG, .steMonitorUseFlag)     'モニター使用フラグ
                                    End With
                                              
                                    '@ﾛｯﾄ数初期化
                                    llngLotCnt = 0
                                    If typAldBatchListTmp.typBatchDetail Is Nothing
                                        typAldBatchListTmp.typBatchDetail = New List(Of typBatchDetail)
                                    Else
                                        typAldBatchListTmp.typBatchDetail.Clear
                                    End If
                                    
                                End If
                                
                                '@ﾊﾞｯﾁのﾛｯﾄ詳細情報を格納
                                Dim typBatchDetailTmp As typBatchDetail = New typBatchDetail

                                llngLotCnt = llngLotCnt + 1

                                typAldBatchListTmp.lngBatchDetailCnt = llngLotCnt
                                
                                With typBatchDetailTmp
                                
                                    Call ltMsg.getString(CPstrSEQ_NUM, .strSeqNum)                          '順序
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotID)                            'ﾛｯﾄID
                                    Call ltMsg.getString(CPstrLOT_EVENT_ID, .strLotEventId)                 'ﾛｯﾄｲﾍﾞﾝﾄID
                                    Call ltMsg.getString(CPstrPD_ID, .strPdId)                              '機種
                                    Call ltMsg.getString(CPstrWF_QUANTITY, .strWfQty)                       'WF数
                                    Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQty)                   'CHIP数
                                    Call ltMsg.getString(CPstrA_CARRIER_GROUP, .strACrrierGroup)            'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
                                    Call ltMsg.getString(CPstrA_TRAY_CHIP_NUM, .strAtrayChipNum)            'Aトレーチップ収容数
                                    Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                    '種別
                                    Call ltMsg.getString(CPstrTAPE_STICK_BATCH_ID, .strTapeStickBatchId)    'テープ貼りバッチID
                                    Call ltMsg.getString(CPstrTAPE_STICK_RECIPE_ID, .strTapeStickRrecipeId) 'テープ貼りレシピ
                                    Call ltMsg.getString(CPstrOVEN_BATCH_ID, .strOvenBatchId)               'オーブンバッチID
                                    Call ltMsg.getString(CPstrOVEN_RECIPE_ID, .strOvenRecipeId)             'オーブンレシピ
                                    Call ltMsg.getString(CPstrALD_BATCH_ID, .strAldBatchId)                 'ALDバッチID
                                    Call ltMsg.getString(CPstrALD_RECIPE_ID, .strAldRecipeId)               'ALDレシピ
            
                                End With
                                
                                '@ﾊﾞｯﾁID前回値退避
                                lstrBefBatchId = lstrBatchID
                                
                                typAldBatchListTmp.typBatchDetail.Add(typBatchDetailTmp)

                                .typAldBatchList(llngBatchCnt -1) = typAldBatchListTmp
                            Next
                            
                            '@ﾊﾞｯﾁｶｳﾝﾄ格納
                            .lngAldBatchListCnt = llngBatchCnt
                            
                        End If
                        
                        '@関数の処理結果(成功)格納
                        pubblnAldBatchList_Sel = True
                        
                        
                    '@〓 1：FALSE(失敗、異常) 〓
                    Case CPstrFALSE
                        
                        '@=======================
                        '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                        '@=======================
                        Call pubstrErrMsg_Set(laMsg, strMsgVer)
                        
                        
                    '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                    Case Else
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                        
                End Select
            
            End With
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            
        End Try
    End Function



    '関数名：pubblnDoubleJPd_Chk
    '機　能：蒸着2回対応機種チェック
    '引　数：strMsgVer          ：機能Ver
    '　　　：lotId				  ：ﾛｯﾄID
	'　　　：pdId				  ：機種
    '戻り値：True：成功、False：失敗
    '作成日：2025/01/29 (Wed) 16:30:00 M.Kikawa
    '更新日：2025/01/29 (Wed) 16:30:00 M.Kikawa
    '備　考：
    Public Function pubblnDoubleJPd_Chk(ByVal lstrMsgVer As String, _
                                                 ByVal lstrLotID As String, _
												 ByVal lstrPdID As String, _
                                                 ByRef lstrResult As String, _
										Optional ByVal lstrClassDivision As String = vbNullString) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try

            '@初期設定
            pstrMessageName = "蒸着2回対応機種チェック"
            
            pubblnDoubleJPd_Chk = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

			'@処理区分
			If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrCD4V)
            End If
			
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@LotId
            If lstrLotID <> vbNullString Then
                Call lrMsg.addString(CPstrLOT_ID, lstrLotID)
            Else
                Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
            End If

			'@PdId
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chkdoublejpd, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                    
                    '@受信結果取得
                    Call laMsg.getString(CPstrRESULT, lstrResult)
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnDoubleJPd_Chk = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrMsgVer)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
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
