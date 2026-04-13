'ﾌｧｲﾙ名：xxMG02E0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：MKロット編成　標準モジュール
'作成日：2009/05/19 (Tue) 17:40:33 T.Oide
'更新日：
'備　考：CFロット編成をベースに作成
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02E0
    '*******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Friend =====================================
    '================================== Private ====================================
'未使用機能NSYS ↓
''関数名：Main
''機　能：メイン関数
''引　数：なし
''戻り値：なし
''作成日：2009/05/19 (Tue) 17:40:33 T.Oide
''更新日：
''備　考：ｺﾏﾝﾄﾞﾗｲﾝの引数内容
''　　　：lstrCommand(0)：ｼｽﾃﾑﾌﾞﾛｯｸ
''　　　：lstrCommand(1)：ﾚｽﾎﾟﾝｽ表示（D：表示、なし：非表示）

'Private Sub Main()
'    Dim llngRet     As Long     '戻り値
'    Dim lblnAns     As Boolean  '戻り値
'    Dim ltypCommonInfoDummy     As CommonInfo   'ﾀﾞﾐｰ構造体
'    Dim lblnAnsInit     As Boolean      '戻り値
'    Dim lstrTitle       As String       'ﾀｲﾄﾙ
'    Dim lstrFormName    As String       'ﾌｫｰﾑ名

'    '@ｺﾏﾝﾄﾞﾗｲﾝ引数確認
'    lblnAns = pubblnCommand_Chk
'    If lblnAns = False Then
'        '@引数なしの場合
'        pstrMessageName = "起動"
'        '@表示ﾒｯｾｰｼﾞ変換
'        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0070)
'        '@メッセージを表示「起動時の情報が不足しています。」
'        Call publngMsgBox(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
'        End
'    End If

'    '@ACT初期化
'    lblnAnsInit = pubblnAct_Init
'    If lblnAnsInit = False Then
'        End
'    End If
    
'    '@定数の取得・初期化
'    Call pubblnFuncInfo_Set

'    '@ACT初期化ﾌﾗｸﾞの設定
'    pblnActInitFlg = True
    
'    '@ﾌｫｰﾑを表示する
'    frmxxEN02E0.Show
    
'End Sub
'未使用機能NSYS ↑

    '関数名：pubblnLotCfChipMove_Upd
    '機　能：
    '引　数：typcfchipmovejigList：
    '戻り値：
    '作成日：2009/06/09 (Tue) 16:02:37 T.Oide
    '更新日：2009/06/09 (Tue) 16:02:37
    '備　考：
    Public Function pubblnLotCfChipMove_Upd(ByRef typcfchipmovejigList As cfchipmovejigList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim lrMsgTmp            As TfMsg            '送信ﾒｯｾｰｼﾞ(ｱﾚｲ作成用Tmp)
        Dim lrAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim lngCnt              As Integer

        Try

            '@初期設定
            pstrMessageName = "CF移載情報登録"
            pubblnLotCfChipMove_Upd = False
            
            lrMsg = New TfMsg
            lrMsgTmp = New TfMsg
            lrAry = New TfMsgAry
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With typcfchipmovejigList
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVersion <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVersion)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
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
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
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
                '@移載前数量
                If .strBeforMoveNum <> vbNullString Then
                    Call lrMsg.addString(CPstrBEFORE_MOVE_NUM, .strBeforMoveNum)
                Else
                    Call lrMsg.addString(CPstrBEFORE_MOVE_NUM, CPstrMsgNull)
                End If
                '@移載数量
                If .strMoveNum <> vbNullString Then
                    Call lrMsg.addString(CPstrMOVE_NUM, .strMoveNum)
                Else
                    Call lrMsg.addString(CPstrMOVE_NUM, CPstrMsgNull)
                End If
                '@不良数量
                If .strScrapNum <> vbNullString Then
                    Call lrMsg.addString(CPstrSCRAP_NUM, .strScrapNum)
                Else
                    Call lrMsg.addString(CPstrSCRAP_NUM, CPstrMsgNull)
                End If
                '@ﾘﾜｰｸ数量
                If .strReworkNum <> vbNullString Then
                    Call lrMsg.addString(CPstrREWORK_NUM, .strReworkNum)
                Else
                    Call lrMsg.addString(CPstrREWORK_NUM, CPstrMsgNull)
                End If
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                For lngCnt = 0 To .lngcfjigListCnt - 1
                
                    With .typcfjigList(lngCnt)
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        If .strSlotNo <> vbNullString Then
                            Call lrMsgTmp.addString(CPstrSLOT_POSITION, .strSlotNo)
                        Else
                            Call lrMsgTmp.addString(CPstrSLOT_POSITION, CPstrMsgNull)
                        End If
                        '@ウェハーID
                        If .strWfId <> vbNullString Then
                            Call lrMsgTmp.addString(CPstrWF_ID, .strWfId)
                        Else
                            Call lrMsgTmp.addString(CPstrWF_ID, CPstrMsgNull)
                        End If
                        '@治具ﾘｽﾄ
                        If .strjigId <> vbNullString Then
                            Call lrMsgTmp.addString(CPstrJIG_ID, .strjigId)
                        Else
                            Call lrMsgTmp.addString(CPstrJIG_ID, CPstrMsgNull)
                        End If
                    
                        'Tmpの内容をｱﾚｰに追加
                        Call lrAry.Add(lrMsgTmp)
                        '@Tmpｸﾘｱ
                        Call lrMsgTmp.Clear
                    End With
                    
                Next lngCnt
                
                '@ｱﾚｰを送信ﾒｯｾｰｼﾞに追加
                Call lrMsg.addMsgAry(CPstrJIG_LIST, lrAry)
                '@ｱﾚｰｸﾘｱ
                Call lrAry.Clear
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_cfchipmove, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)

                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        
                        '@関数の処理結果(成功)格納
                         pubblnLotCfChipMove_Upd = True
                         
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, .strMsgVersion)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
            End With
            
            lrMsg = Nothing
            lrMsgTmp = Nothing
            lrAry = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            lrMsgTmp = Nothing
            lrAry = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnCfChipMoveInfo_Sel
    '機　能：CF移載情報を取得する
    '引　数：typcfchipmovejigList：
    '戻り値：
    '作成日：2009/06/09 (Tue) 18:52:45 T.Oide
    '更新日：2009/06/09 (Tue) 18:52:45
    '備　考：
    Public Function pubblnCfChipMoveInfo_Sel(ByRef typcfchipmovejigList As cfchipmovejigList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim laMsgTmp            As TfMsg            '送信ﾒｯｾｰｼﾞ(ｱﾚｲTmp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngAryCnt          As Integer

        Try

            '@初期設定
            pstrMessageName = "CF移載情報参照"
            pubblnCfChipMoveInfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laMsgTmp = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With typcfchipmovejigList
                '@Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVersion <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVersion)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                '@ﾛｯﾄID
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
                '@ｷｬﾘｱID
                If .strCarrierId <> vbNullString Then
                    Call lrMsg.addString(CPstrCARRIER_ID, .strCarrierId)
                Else
                    Call lrMsg.addString(CPstrCARRIER_ID, CPstrMsgNull)
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
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrlot_cfchipmoveinfo, lrMsg, laMsg)
                
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)

                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                    
                        Call laMsg.getString(CPstrLOT_ID, .strLotID)                        'ﾛｯﾄID
                        Call laMsg.getString(CPstrCARRIER_ID, .strCarrierId)                'ｷｬﾘｱID
                        Call laMsg.getString(CPstrOP_ID, .strOpID)                          '大工程
                        Call laMsg.getString(CPstrSTEP_ID, .strStepID)                      '小工程
                        Call laMsg.getString(CPstrBEFORE_MOVE_NUM, .strBeforMoveNum)  '移載前数量
                        Call laMsg.getString(CPstrMOVE_NUM, .strMoveNum)              '移載数量
                        Call laMsg.getString(CPstrSCRAP_NUM, .strScrapNum)            '不良数量
                        Call laMsg.getString(CPstrREWORK_NUM, .strReworkNum)          'ﾘﾜｰｸ数量
                        Call laMsg.getString(CPstrEMP_ID, .strEmpID)                        '作業者ID
                        
                        Call laMsg.getMsgAry(CPstrJIG_LIST, laAry)                          '治具ﾘｽﾄ
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        llngAryCnt = laAry.Count
                        .lngcfjigListCnt = laAry.Count
                        .typcfjigList = New List(Of cfjigList)
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If llngAryCnt > 0 Then
                            'ReDim Preserve .typcfjigList(llngAryCnt) NSYS ループ処理内へ移動
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            'llngCnt = 1 NSYS 不要となるため削除
                            For Each laMsgTmp In laAry

                                'NSYS 編集用構造体初期化
                                Dim typcfjigListTmp As cfjigList = New cfjigList

                                '@受信結果取得
                                With typcfjigListTmp
                                    Call laMsgTmp.getString(CPstrSLOT_POSITION, .strSlotNo)     'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                                    Call laMsgTmp.getString(CPstrWF_ID, .strWfId)               'ｳｪﾊｰID
                                    Call laMsgTmp.getString(CPstrJIG_ID, .strjigId)             '治具ID
                                End With

                                'NSYS 編集済み構造体を追加
                                .typcfjigList.Add(typcfjigListTmp)
                                'llngCnt = llngCnt + 1 NSYS 不要となるため削除
                            Next
                        End If
                        
                        '@関数の処理結果(成功)格納
                         pubblnCfChipMoveInfo_Sel = True
                         
                    '@失敗の場合(false)
                    Case CPstrFALSE
                        
                        '@ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, .strMsgVersion)
                        
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
            laMsgTmp = Nothing
            laAry = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
            lrMsg = Nothing
            laMsg = Nothing
            laMsgTmp = Nothing
            laAry = Nothing
            
        End Try
    End Function
End Module
