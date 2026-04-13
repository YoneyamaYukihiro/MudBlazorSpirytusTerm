'ﾌｧｲﾙ名：xxMG02I0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：区間優先情報設定 標準モジュール
'作成日：2011/09/20 (Tue) 10:36:54 T.Oide
'更新日：2016/02/11 (Thu) 22:59:25 H.Hayashi
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02I0
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
    '未使用機能NSYS ↓
    ''関数名：Main
    ''機　能：ﾒｲﾝ関数
    ''引　数：なし
    ''戻り値：なし
    ''作成日：2011/09/20 (Tue) 10:36:54 T.Oide
    ''更新日：2011/09/20 (Tue) 10:36:54
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
    '    Call pubMenuItemCorrelation_Set(CPstrKeyEN02I0, lstrTitle, , lstrFormName)
    
    '    '@ACT初期化ﾌﾗｸﾞに"True:初期化成功"をｾｯﾄ
    '    pblnActInitFlg = True
    
    '    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '    '@　区間優先設定画面　表示処理
    '    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '    Call frmxxEN02I0.Show(vbModal)
    
    'End Sub
    '未使用機能NSYS ↑

    '関数名：pubblnLotSectionPriority_Sel
    '機　能：区間優先情報取得
    '引　数：lstrSbId：SB_ID
    '　　　：lstrlot_SectionPriorityVer：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrLotList：ﾛｯﾄﾘｽﾄ
    '　　　：ltypSecPriority：区間優先情報
    '戻り値：
    '作成日：2011/09/20 (Tue) 10:42:06 T.Oide
    '更新日：2016/02/11 (Thu) 22:59:10 H.Hayashi
    '備　考：
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Public Function pubblnLotSectionPriority_Sel(ByVal lstrSBID As String, _
                                                 ByVal lstrlot_SectionPriorityVer As String, _
                                                 ByRef lstrLotList As List(Of String), _
                                                 ByRef ltypSecPriority As typSecPriority) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrMsg2              As TfMsg                '送信ﾒｯｾｰｼﾞ2(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry             '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry             '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        Dim llngCnt             As Integer              'ｶｳﾝﾀ
        
        
        Try

            pstrMessageName = "区間優先設定情報取得"
            pubblnLotSectionPriority_Sel = False

            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            If lstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, lstrSBID)                      'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            If lstrlot_SectionPriorityVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_SectionPriorityVer)  'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            For llngCnt = 0 To lstrLotList.Count - 1                               'ﾛｯﾄﾘｽﾄ
                If lstrLotList(llngCnt) <> vbNullString Then
                    Call lrMsg2.addString(CPstrLOT_ID, lstrLotList(llngCnt))
                Else
                    Call lrMsg2.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
            Next
            Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
            lrAry.Clear
                

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_secpriority, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    With ltypSecPriority
                    
                        '@受信結果取得
                        Call laMsg.getString(CPstrSB_ID, .strSbID)                                 'SB_ID
                        
                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrSECPRIORITY_LIST, laAry)   '保留ﾘｽﾄ
            
                        '@ｱﾚｰの数が0じゃなければ処理
                        If laAry.Count <> 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            .lngListCnt = laAry.Count

                            If .SecPriorityList Is Nothing Then 
                                .SecPriorityList = new List(Of typSecPriorityList) 
                            Else 
                                .SecPriorityList.Clear  
                            End If
                            
                            Dim typSecPriorityListRec As typSecPriorityList
                                        
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                typSecPriorityListRec = New typSecPriorityList 
                                With typSecPriorityListRec
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotID)                        'ﾛｯﾄID
        '@↓2016/01/16 (Sat) 15:15:45 H.Hayashi **************************************************
                                    Call ltMsg.getString(CPstrGRB_CLASS, .strGrbClass)                  'GRB区分
        '@↑2016/01/16 (Sat) 15:15:45 H.Hayashi **************************************************
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrier)                  'ｷｬﾘｱID
                                    Call ltMsg.getString(CPstrSTART_OP_ID, .strStartOpId)               '開始大工程
                                    Call ltMsg.getString(CPstrSTART_STEP_ID, .strStartStepId)           '開始小工程
                                    Call ltMsg.getString(CPstrEND_OP_ID, .strEndOpId)                   '終了大工程
                                    Call ltMsg.getString(CPstrEND_STEP_ID, .strEndStepId)               '終了小工程
                                    Call ltMsg.getString(CPstrSECTION_PRIORITY, .strSectionPriority)    '区間優先度
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                    '設定ﾕｰｻﾞ
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)                '登録日時
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                          '大工程
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                      '小工程
                                    Call ltMsg.getString(CPstrLOT_PRIORITY, .strPriority)               '優先度
                                    Call ltMsg.getString(CPstrENTRY_TIME, .strEntryTime)                '設定日時
                                    Call ltMsg.getString(CPstrLOT_HOLD_FLAG, .strLotHoldFlag)           '保留ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrLOT_STOP_FLAG, .strLotStopFlag)           '停止ﾌﾗｸﾞ
                                End With
                                .SecPriorityList.Add(typSecPriorityListRec)
                            Next
                            
                        Else
                            '@ｱﾚｰが0の場合
                            .lngListCnt = laAry.Count
                        End If
            
                        '@関数の処理結果(成功)格納
                        pubblnLotSectionPriority_Sel = True
                    End With

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_SectionPriorityVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
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
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnLotSectionPriority_Reg
    '機　能：区間優先情報を登録する
    '引　数：CMstrlot_SectionPriorityVer：ﾒｯｾｰｼﾞVer
    '　　　：ltypChgSecPriorit：登録する区間優先情報
    '戻り値：True：成功、False：失敗
    '作成日：2011/09/20 (Tue) 15:36:52 T.Oide
    '更新日：2011/09/20 (Tue) 15:36:52
    '備　考：
    Public Function pubblnLotSectionPriority_Reg(ByVal strlot_SectionPriorityVer As String, _
                                                 ByRef ltypChgSecPriority As typChgSecPriority, _
                                                 ByRef lstrMsgCode As String, _
                                                 ByRef lstrMsg As String) As Boolean

        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrMsg2              As TfMsg                '送信ﾒｯｾｰｼﾞ2(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry             '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        Dim llngCnt             As Integer              'ｶｳﾝﾀ
        
        
        Try

            pstrMessageName = "区間優先情報登録"
            pubblnLotSectionPriority_Reg = False

            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg


            With ltypChgSecPriority

            '@送信ﾒｯｾｰｼﾞ作成
            If ltypChgSecPriority.strSbID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, ltypChgSecPriority.strSbID)    'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            If strlot_SectionPriorityVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, strlot_SectionPriorityVer)  'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            For llngCnt = 0 To .lngListCnt - 1                                                  '区間優先ﾘｽﾄ
                If .typChgSecPriority(llngCnt).strLotID <> vbNullString Then
                    Call lrMsg2.addString(CPstrLOT_ID, .typChgSecPriority(llngCnt).strLotID)  'ﾛｯﾄID
                Else
                    Call lrMsg2.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                If .typChgSecPriority(llngCnt).strStartOpId <> vbNullString Then
                    Call lrMsg2.addString(CPstrSTART_OP_ID, .typChgSecPriority(llngCnt).strStartOpId)       '開始大工程
                Else
                    Call lrMsg2.addString(CPstrSTART_OP_ID, CPstrMsgNull)
                End If
                
                If .typChgSecPriority(llngCnt).strStartStepId <> vbNullString Then
                    Call lrMsg2.addString(CPstrSTART_STEP_ID, .typChgSecPriority(llngCnt).strStartStepId)   '開始小工程
                Else
                    Call lrMsg2.addString(CPstrSTART_STEP_ID, CPstrMsgNull)
                End If
                
                If .typChgSecPriority(llngCnt).strEndOpId <> vbNullString Then
                    Call lrMsg2.addString(CPstrEND_OP_ID, .typChgSecPriority(llngCnt).strEndOpId)           '終了大工程
                Else
                    Call lrMsg2.addString(CPstrEND_OP_ID, CPstrMsgNull)
                End If
                
                If .typChgSecPriority(llngCnt).strEndStepId <> vbNullString Then
                    Call lrMsg2.addString(CPstrEND_STEP_ID, .typChgSecPriority(llngCnt).strEndStepId)       '終了小工程
                Else
                    Call lrMsg2.addString(CPstrEND_STEP_ID, CPstrMsgNull)
                End If
                
                If .typChgSecPriority(llngCnt).strSectionPriority <> vbNullString Then
                    Call lrMsg2.addString(CPstrSECTION_PRIORITY, .typChgSecPriority(llngCnt).strSectionPriority)       '区間優先度
                Else
                    Call lrMsg2.addString(CPstrSECTION_PRIORITY, CPstrMsgNull)
                End If
                
                If .typChgSecPriority(llngCnt).strEmpID <> vbNullString Then
                    Call lrMsg2.addString(CPstrEMP_ID, .typChgSecPriority(llngCnt).strEmpID)                '設定ﾕｰｻﾞID
                Else
                    Call lrMsg2.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
            Next
            Call lrMsg.addMsgAry(CPstrSECPRIORITY_LIST, lrAry)
            lrAry.Clear
            
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_chgsecpriority, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
            
                    '@関数の処理結果(成功)格納
                    pubblnLotSectionPriority_Reg = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ｴﾗｰﾒｯｾｰｼﾞ取得
                    Call laMsg.getString(CPstrMSG_CODE, lstrMsgCode)
                    Call laMsg.getString(CPstrMSG, lstrMsg)
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞは空か
                    If lstrMsgCode = vbNullString Then
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, strlot_SectionPriorityVer)
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
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing


            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing


        End Try
    End Function

    '関数名：pubblnLotSecPriorityDetail_Sel
    '機　能：区間設定情報詳細を取
    '引　数：lstrSbId
    '　　　：
    '　　　：lstrLotId()：ﾛｯﾄID
    '　　　：ltypSecPriorityDetail：区間優先詳細情報格納
    '戻り値：True：成功、False：失敗
    '作成日：2011/09/21 (Wed) 14:57:27 T.Oide
    '更新日：2011/09/21 (Wed) 14:57:27
    '備　考：
    Public Function pubblnLotSecPriorityDetail_Sel(ByVal lstrSBID As String, _
                                                   ByVal lstrlot_secPriorityDetailVer As String, _
                                                   ByRef lstrLotID As List(Of String), _
                                                   ByRef ltypSecPriorityDetail As typSecPriorityDetail, _
                                                   ByRef lstrMsgCode As String, _
                                                   ByRef lstrMsg As String)
        
        Dim lrMsg               As TfMsg                '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrMsg2              As TfMsg                '送信ﾒｯｾｰｼﾞ2(ﾘｸｴｽﾄ)
        Dim lrAry               As TfMsgAry             '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg                '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laMsg2              As TfMsg                '送信ﾒｯｾｰｼﾞ2(ｱﾝｻｰ)
        Dim laAry               As TfMsgAry             '送信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim laMsg3              As TfMsg                '送信ﾒｯｾｰｼﾞ3(ｱﾝｻｰ)
        Dim laAry2              As TfMsgAry             '送信ﾒｯｾｰｼﾞｱﾚｲ2(ｱﾝｻｰ)
        Dim lstrRET             As String               '応答取得
        Dim llngCnt             As Integer              'ｶｳﾝﾀ
        Dim llngCnt2            As Integer              'ｶｳﾝﾀ
        
        
        Try

            pstrMessageName = "区間優先情報詳細取得"
            pubblnLotSecPriorityDetail_Sel = False

            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg
            laMsg2 = New TfMsg
            laAry = New TfMsgAry
            laMsg3 = New TfMsg
            laAry2 = New TfMsgAry


            '@送信ﾒｯｾｰｼﾞ作成
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)                          'SB_ID
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            If lstrlot_secPriorityDetailVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_secPriorityDetailVer)    'Msgﾊﾞｰｼﾞｮﾝ
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            For llngCnt = 0 To lstrLotID.Count -1
                If lstrLotID(llngCnt) <> vbNullString Then
                    Call lrMsg2.addString(CPstrLOT_ID, lstrLotID(llngCnt))          'ﾛｯﾄID
                Else
                    Call lrMsg2.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                
                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
            Next
            Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
            lrAry.Clear
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_secprioritydetail, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
            
                    With ltypSecPriorityDetail
                    
                        '@受信結果取得
                        Call laMsg.getString(CPstrSB_ID, .strSbID)                  'SB_ID
                        
                        '@ｱﾚｰ取得
                        Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)                  'LOT_LIST
            
                        '@ｱﾚｰの数が0じゃなければ処理
                        If laAry.Count <> 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            .lngListCnt1 = laAry.Count

                            If .SecPriList Is Nothing Then 
                                .SecPriList = New List(Of typSecPriList)
                            Else 
                                .SecPriList.Clear 
                            End If
                            
                            Dim typSecPriListRec As typSecPriList
                            
                            '@ｱﾚｰの各要素取得
                            For Each laMsg2 In laAry
                                typSecPriListRec = New typSecPriList 
                                With typSecPriListRec
                                    Call laMsg2.getString(CPstrLOT_ID, .strLotID)   'ﾛｯﾄID
                                    Call laMsg2.getMsgAry(CPstrSTEP_LIST, laAry2)
                                    
                                    If laAry2.Count <> 0 Then
                                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                        .lngListCnt2 = laAry2.Count
                                                                                
                                        If .SecPriDetailList Is Nothing Then 
                                            .SecPriDetailList = New List(Of typSecPriDetailList) 
                                        End If

                                        Dim typSecPriDetailListRec As typSecPriDetailList
                                        
                                        llngCnt2 = 1
                                        '@ｱﾚｰの各要素取得
                                        For Each laMsg3 In laAry2
                                            typSecPriDetailListRec = New typSecPriDetailList
                                            With typSecPriDetailListRec
                                                Call laMsg3.getString(CPstrOP_ID, .strOpID)                   '大工程
                                                Call laMsg3.getString(CPstrSTEP_ID, .strStepID)               '小工程
                                                Call laMsg3.getString(CPstrSEQ_NUM, .strSeqNum)               '処理順
                                                Call laMsg3.getString(CPstrSECTION_PRIORITY, .strSecPriority) '区間優先度
                                                Call laMsg3.getString(CPstrEXECED_FLAG, .strExecedFlag)       '流動済みﾌﾗｸﾞ
                                            
                                            End With
                                            .SecPriDetailList.Add(typSecPriDetailListRec)
                                        Next
                                    End If
                                        
                                End With
                                .SecPriList.Add(typSecPriListRec)
                            Next
                        End If
            
                        '@関数の処理結果(成功)格納
                        pubblnLotSecPriorityDetail_Sel = True
                    End With
                    

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ｴﾗｰﾒｯｾｰｼﾞ取得
                    Call laMsg.getString(CPstrMSG_CODE, lstrMsgCode)
                    Call laMsg.getString(CPstrMSG, lstrMsg)
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞは空か
                    If lstrMsgCode = vbNullString Then
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, lstrlot_secPriorityDetailVer)
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
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            laMsg2 = Nothing
            laAry = Nothing
            laMsg3 = Nothing
            laAry2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            lrAry = Nothing
            laMsg = Nothing
            laMsg2 = Nothing
            laAry = Nothing
            laMsg3 = Nothing
            laAry2 = Nothing
            
        End Try
    End Function
End Module
