'ﾌｧｲﾙ名：xxMG02C0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：MKロット編成　標準モジュール
'作成日：2009/05/19 (Tue) 17:40:33 T.Oide
'更新日：2015/12/15 (Tue) 09:58:27 Y.Tanaka
'備　考：CFロット編成をベースに作成
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02C0
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
    '@CFﾛｯﾄﾘｽﾄ(MKﾛｯﾄ編成画面情報受け渡し用)
    Public ptypeCfInvInfo               As CfInvInfo
    Public ptypeKonseiPartList          As KonseiPartList

    '@EN02C1の設定結果を格納(親画面EN02C0に戻す用)
    Public ptypKonsei()                 As Konsei       'ｲﾝﾃﾞｯｸｽは1～5でｽﾛｯﾄ№に対応する

    'ｸﾞﾘｯﾄﾞの編集中の行退避用
    Public plngvsfJigListRow            As Integer

    'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ(JigIDのﾁｪﾝｼﾞ)
    Public pbinJigchg                   As Boolean

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
    '    frmxxEN02C0.Show
    
    'End Sub
    '未使用機能NSYS ↑

    '関数名：pubblnMasMKtoCFPartList_Sel
    '機　能：
    '引　数：ltypMasPartlist：
    '　　　：llngPartListCnt：
    '　　　：mtyppartlist()：
    '戻り値：
    '作成日：2009/05/26 (Tue) 15:27:08 T.Oide
    '更新日：2009/05/26 (Tue) 15:27:08
    '備　考：
    Public Function pubblnMasMKtoCFPartList_Sel(ByRef ltypMasPartlist As MasPartlist, _
                                                ByRef llngPartListCnt As Integer, _
                                                ByRef mtyppartlist As List (Of PartClassList)) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "部材コードリスト取得2"
            pubblnMasMKtoCFPartList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypMasPartlist
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
                '@機種ID
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
            
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrmas_MKtoCFpartlist, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)

                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                        Call laMsg.getMsgAry(CPstrPART_LIST, laAry)
                    
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数格納
                        llngPartListCnt = laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If llngPartListCnt > 0 Then

                            If mtyppartlist Is Nothing Then 
                                mtyppartlist = New List(Of PartClassList)
                            Else
                                mtyppartlist.Clear()
                            End If

                            Dim mtyppartlistTmp As New PartClassList

                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            llngCnt = 0
                            For Each ltMsg In laAry
                                '@受信結果取得
                                With mtyppartlistTmp
                                    Call ltMsg.getString(CPstrPART_CODE, .strPartCode)
                                    Call ltMsg.getString(CPstrPART_NAME, .strPartName)
                                    Call ltMsg.getString(CPstrREGENERATION_COUNT, .strRegenerationCount)
                                    Call ltMsg.getString(CPstrTHICKNESS_CLASS, .strThicknessClass)
                                    Call ltMsg.getString(CPstrVENDER_NAME, .strVenderName)
                                End With
                                mtyppartlist.Add(mtyppartlistTmp)
                                llngCnt = llngCnt + 1
                            Next
                        End If
                        
                        '@関数の処理結果(成功)格納
                         pubblnMasMKtoCFPartList_Sel = True
                         
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


    '関数名：pubblnInvMKToCFPartList_Sel
    '機　能：
    '引　数：lstrinv_partlistVer：
    '　　　：lstrPdID：
    '　　　：lstrPartCode：
    '　　　：lstrThicknessCode：
    '　　　：lstrReworkCount：
    '　　　：ltypPartLotList()：
    '戻り値：
    '作成日：2009/05/27 (Wed) 09:28:58 T.Oide
    '更新日：2012/01/16 (Mon) 15:51:55 T.Oide
    '備　考：
    Public Function pubblnInvMKToCFPartList_Sel(ByVal lstrinv_mktocfpartlistVer As String, _
                                                ByVal lstrPdID As String, _
                                                ByVal lstrPartCode As String, _
                                                ByVal lstrThicknessCode As String, _
                                                ByVal lstrReworkCount As String, _
                                                ByRef ltypPartLotList As List(Of PartLotList), _
                                                ByRef llngPartLotListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "MK用部材一覧取得"
            pubblnInvMKToCFPartList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrinv_mktocfpartlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrinv_mktocfpartlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            '@機種ID
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            '@部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
            If lstrPartCode <> vbNullString Then
                Call lrMsg.addString(CPstrPART_CODE, lstrPartCode)
            Else
                Call lrMsg.addString(CPstrPART_CODE, CPstrMsgNull)
            End If
            '@CF板厚
            If lstrThicknessCode <> vbNullString Then
                Call lrMsg.addString(CPstrTHICKNESS_CODE, lstrThicknessCode)
            Else
                Call lrMsg.addString(CPstrTHICKNESS_CODE, CPstrMsgNull)
            End If
            '@CFﾘﾜｰｸ数
            If lstrReworkCount <> vbNullString Then
                Call lrMsg.addString(CPstrREWORK_COUNT, lstrReworkCount)
            Else
                Call lrMsg.addString(CPstrREWORK_COUNT, CPstrMsgNull)
            End If
            

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrinv_mktocfpartlist, lrMsg, laMsg)

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

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngPartLotListCnt > 0 Then
                        '@構造体初期化
                        ltypPartLotList = New List(Of PartLotList)

                        Dim ltypPartLotListTmp As New PartLotList

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            '@受信結果取得
                            With ltypPartLotListTmp
        '@↓2012/01/16 (Mon) 15:52:33 T.Oide **************************************************
                                Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                    'ｷｬﾘｱID
                                Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                    '流動区分
        '@↑2012/01/16 (Mon) 15:52:33 T.Oide **************************************************
                                Call ltMsg.getString(CPstrLOT_ID, .strLotID)                            '在庫ﾛｯﾄID
                                Call ltMsg.getString(CPstrLIMIT_TIME, .strLimitTime)                    '在庫制限時間
                                Call ltMsg.getString(CPstrCREATE_TIME, .strCreateTime)                  'ﾃﾞｰﾀ作成時間
                                Call ltMsg.getString(CPstrPART_CODE, .strPartCode)                      '部品ｺｰﾄﾞ(部材ｺｰﾄﾞ)
                                Call ltMsg.getString(CPstrBODY_THICKNESS_CODE, .strThicknessCode)       'CF板厚
                                Call ltMsg.getString(CPstrREWORK_COUNT, .strReworkCount)                'CFﾘﾜｰｸ数
                                Call ltMsg.getString(CPstrCHIP_QUANTITY, .strNum)                       'CHIP数
                                Call ltMsg.getString(CPstrLOT_LAST_UPDATE, .strLotLastUpdate)           'LOT最終更新日時
                            End With
                            ltypPartLotList.Add(ltypPartLotListTmp)
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnInvMKToCFPartList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrinv_mktocfpartlistVer)
                    
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


    '関数名：pubblnJJigFillNum_Sel
    '機　能：
    '引　数：lstrmas_JJigFillNumVer：
    '　　　：lstrPdID：
    '戻り値：
    '作成日：2009/05/27 (Wed) 13:52:19 T.Oide
    '更新日：2009/05/27 (Wed) 13:52:19
    '備　考：
    Public Function pubblnJJigFillNum_Sel(ByVal lstrmas_JJigFillNumVer As String, _
                                          ByVal lstrPdID As String, _
                                          ByVal lstrClassDivision As String, _
                                          ByRef ltypJigFillNum As List(Of JigFillNum)) As Boolean
                                          

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "治具の詰数取得"
            pubblnJJigFillNum_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrmas_JJigFillNumVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrmas_JJigFillNumVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            '@機種ID
            If lstrPdID <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, lstrPdID)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If
            '@CLASS_DIVISION
            If lstrClassDivision <> vbNullString Then
                Call lrMsg.addString(CPstrCLASS_DIVISION, lstrClassDivision)
            Else
                Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
            End If


            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_jigufillum, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ取得
                    Call laMsg.getMsgAry(CPstrJIG_TYPE_LIST, laAry)

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    llngCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngCnt > 0 Then
                        '@構造体初期化
                        ltypJigFillNum = New List(Of JigFillNum)

                        Dim ltypJigFillNumTmp As New JigFillNum

                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        llngCnt = 0
                        For Each ltMsg In laAry
                            '@受信結果取得
                            With ltypJigFillNumTmp
                                Call ltMsg.getString(CPstrPD_ID, .strPdId)                  '機種ID
                                Call ltMsg.getString(CPstrJIG_CLASS, .strjigClass)          'JIG_CLASS
                                Call ltMsg.getString(CPstrPANEL_KIND, .strPanelKind)        'PANEL_KIND
                                Call ltMsg.getString(CPstrSTUFF_COUNT, .lngStuffCount)      '詰数
                            End With
                            ltypJigFillNum.Add(ltypJigFillNumTmp)
                            llngCnt = llngCnt + 1
                        Next
                    Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000Q, lstrPdID)
                        '@｢<TRM0OQ>$$機種[%1]の治具タイプマスターの登録がありません。$システム担当に連絡してください。"」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                        
                        pubblnJJigFillNum_Sel = False
                        Exit Function
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnJJigFillNum_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrmas_JJigFillNumVer)

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


    '関数名：pubblnLotMkThrowin_Upd
    '機　能：
    '引　数：lstrlot_mkthrowinVer：
    '　　　：ltypLotMkThrowin：
    '　　　：lstrGuidMsg：
    '　　　：lstrGuidMsgCode：
    '戻り値：
    '作成日：2009/05/28 (Thu) 11:15:45 T.Oide
    '更新日：2009/05/28 (Thu) 11:15:45
    '備　考：
    Public Function pubblnLotMkThrowin_Upd(ByVal lstrlot_mkthrowinVer As String, _
                                           ByRef ltypLotMkThrowin As LotMkThrowin, _
                                           ByRef lstrGuidMsg As String, _
                                           ByRef lstrGuidMsgCode As String) As Boolean
                                           
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim lt2Msg              As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)
        Dim lrAryKonsei         As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｱﾚｲｶｳﾝﾄ用
        Dim llngCnt2            As Integer          'ｱﾚｲｶｳﾝﾄ用
         
        Try

            '@初期設定
            pstrMessageName = "MKロット編成"
            pubblnLotMkThrowin_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            lt2Msg = New TfMsg
            lrAryKonsei = New TfMsgAry
            
            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotMkThrowin

                '@ｼｽﾃﾑﾌﾞﾛｯｸID
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
                
                '@作業者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@投入数
                If .strNum <> vbNullString Then
                    Call lrMsg.addString(CPstrNUM, .strNum)
                Else
                    Call lrMsg.addString(CPstrNUM, CPstrMsgNull)
                End If
                
                '@機種ID
                If .strPdId <> vbNullString Then
                    Call lrMsg.addString(CPstrPD_ID, .strPdId)
                Else
                    Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
                End If
                
                '@↓2009/07/21 (Tue) 11:41:27 T.Oide **************************************************
                '@流動区分
                If .strFlowClass <> vbNullString Then
                    Call lrMsg.addString(CPstrFLOW_CLASS, .strFlowClass)
                Else
                    Call lrMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                End If
                '@↑2009/07/21 (Tue) 11:41:27 T.Oide **************************************************
                
                '@ｴﾝﾄﾘID
                If .strEntryID <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_ID, .strEntryID)
                Else
                    Call lrMsg.addString(CPstrENTRY_ID, CPstrMsgNull)
                End If
                
                '@ﾛｯﾄ担当者ID
                If .strTechManID <> vbNullString Then
                    Call lrMsg.addString(CPstrENG_EMP_ID, .strTechManID)
                Else
                    Call lrMsg.addString(CPstrENG_EMP_ID, CPstrMsgNull)
                End If
               
                '@装置ID(投入装置)
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@-----------------------
                '@　ﾊﾟﾚｯﾄﾏｯﾌﾟ
                '@-----------------------
                '@Aryﾒｯｾｰｼﾞ作成
                llngCnt = 0
                Do While .lngJigMapListCnt -1 >= llngCnt
                
                    '@ﾊﾟﾚｯﾄIDが設定されているﾃﾞｰﾀを対象
                    If .typJigMapList(llngCnt).strjigId <> vbNullString Then
                        
                        Call ltMsg.addString(CPstrSLOT_POSITION, .typJigMapList(llngCnt).strSlotPositon)            'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                        Call ltMsg.addString(CPstrPALETTE_ID, .typJigMapList(llngCnt).strjigId)                     '冶具ID
                        Call ltMsg.addString(CPstrCHIP_COUNT, .typJigMapList(llngCnt).strChipCount)                 'ﾁｯﾌﾟ数
                        Call ltMsg.addString(CPstrLOT_ID, .typJigMapList(llngCnt).strLotID)                         'ﾛｯﾄID
                        Call ltMsg.addString(CPstrBODY_THICKNESS_CODE, .typJigMapList(llngCnt).strBodyThickness)    '厚
                        Call ltMsg.addString(CPstrREWORK_COUNT, .typJigMapList(llngCnt).strReworkCount)             'ﾘﾜｰｸｶｳﾝﾄ
                        
                        If .typJigMapList(llngCnt).strLotID = CPstrKonsei Then
                        
                            llngCnt2 = 0
                            Do While .typJigMapList(llngCnt).typKonseiList.Count -1 >= llngCnt2
                                'KONSEIの場合は下の要素を付ける
                                Call lt2Msg.addString(CPstrLOT_ID, .typJigMapList(llngCnt).typKonseiList(llngCnt2).strLotID)
                                Call lt2Msg.addString(CPstrBODY_THICKNESS_CODE, .typJigMapList(llngCnt).typKonseiList(llngCnt2).strBodyThickness)
                                Call lt2Msg.addString(CPstrREWORK_COUNT, .typJigMapList(llngCnt).typKonseiList(llngCnt2).strReworkCount)
                                Call lt2Msg.addString(CPstrCHIP_COUNT, .typJigMapList(llngCnt).typKonseiList(llngCnt2).strChipCount)
                                Call lt2Msg.addString(CPstrLOT_LAST_UPDATE, .typJigMapList(llngCnt).typKonseiList(llngCnt2).strLotLastUpdate)
                                Call lrAryKonsei.Add(lt2Msg)
                                lt2Msg.Clear
                                Call ltMsg.addMsgAry(CPstrLOT_LIST, lrAryKonsei)
                                llngCnt2 = llngCnt2 + 1
                            Loop
                            lrAryKonsei.Clear
                        End If
                        
                        Call lrAry.Add(ltMsg)
                        ltMsg.Clear
                    End If
                
                    llngCnt = llngCnt + 1
                Loop
                
                Call lrMsg.addMsgAry(CPstrPALETTE_MAP_LIST, lrAry)
                lrAry.Clear
            End With
           
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_mkthrowinVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_mkthrowinVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_mkthrowin, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            
            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@受信結果取得
                    Call laMsg.getString(CPstrLOT_ID, ltypLotMkThrowin.strRetrunLotID)  '投入ﾛｯﾄID
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                         'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    
                    '@戻り値に"True：成功"をｾｯﾄ
                    pubblnLotMkThrowin_Upd = True
                
                
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE
                    
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrlot_mkthrowinVer)
                    
                    
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
            ltMsg = Nothing
            laMsg = Nothing
            
            Exit Function
            
            
        '@例外処理
        Catch ex As Exception
            
            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            lrAry = Nothing
            ltMsg = Nothing
            laMsg = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)
            
        End Try
    End Function

End Module
