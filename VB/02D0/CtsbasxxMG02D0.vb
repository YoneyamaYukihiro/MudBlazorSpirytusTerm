'ﾌｧｲﾙ名：xxMG02D0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：蒸着治具管理　通信メッセージ用 標準モジュール
'作成日：2009/05/27 (Wed) 11:26:21 K.Nishizawa
'更新日：
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02D0
    '=========================================Public=========================================
    '関数名：pubblnJycJigList_Sel
    '機　能：平置き治具情報一覧取得
    '引　数：lstrjigClass       : 治具識別(J:蒸着治具 H:平置き治具)
    '      ：lstrpanelKind      ：ﾊﾟﾈﾙ識別(T:TFT C:CF)
    '      ：ltypJycJigListAns  ：蒸着治具一覧取得結果(from Svr)
    '      ：lstrJigStatus      :治具ｽﾃｰﾀｽ
    '      ：lstrScreenSizeID   ：ｽｸﾘｰﾝｻｲｽﾞ
    '      ：lstrCategoryID     ：ｶﾃｺﾞﾘ
    '戻り値：True:成功/Flase：失敗
    '作成日：2009/05/27 (Wed) 17:05:04 K.Nishizawa
    '更新日：2009/07/21 (Tue) 16:58:25 T.Oide
    '備　考：
    Public Function pubblnJycJigList_Sel(ByVal lstrjig_jyclist__Ver As String, _
                                         ByVal lstrjigClass As String, _
                                         ByVal lstrpanelKind As String, _
                                         ByRef ltypJycJigListAns As pubtypJycJigList, _
                                         Optional ByVal lstrJigStatus As String = vbNullString, _
                                         Optional ByVal lstrScreenSizeID As String = vbNullString, _
                                         Optional ByVal lstrCategoryId As String = vbNullString) _
                                         As Boolean
                                        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngJigCnt          As Integer          'ｼﾞｸﾞﾘｽﾄ件数

        Try
            
            pstrMessageName = "無機治具情報一覧取得"
            
            '戻り値初期化
            pubblnJycJigList_Sel = False
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            
            'Msgの作成
            With lrMsg
                '@MsgVerｾｯﾄ
                Call .addString(CPstrMSG_VER, lstrjig_jyclist__Ver)
                '@治具ｸﾗｽｾｯﾄ
                If lstrjigClass <> vbNullString Then
                    Call .addString(CPstrJIG_CLASS, lstrjigClass)
                Else
                    Call .addString(CPstrJIG_CLASS, CPstrMsgNull)
                End If
                '@ﾊﾟﾈﾙｶｲﾝﾄﾞｾｯﾄ
                If lstrpanelKind <> vbNullString Then
                    Call .addString(CPstrPANEL_KIND, lstrpanelKind)
                Else
                    Call .addString(CPstrPANEL_KIND, CPstrMsgNull)
                End If
                '@治具ｽﾃｰﾀｽｾｯﾄ
                If lstrJigStatus <> vbNullString Then
                    Call .addString(CPstrJIG_STATUS, lstrJigStatus)
                Else
                    Call .addString(CPstrJIG_STATUS, CPstrMsgNull)
                End If
                '@ｽｸﾘｰﾝｻｲｽﾞIDｾｯﾄ
                If lstrScreenSizeID <> vbNullString Then
                    Call .addString(CPstrSCREEN_SIZE_ID, lstrScreenSizeID)
                Else
                    Call .addString(CPstrSCREEN_SIZE_ID, CPstrMsgNull)
                End If
                '@ｶﾃｺﾞﾘ
                If lstrCategoryId <> vbNullString Then
                    Call .addString(CPstrCARRIER_CATEGORY_ID, lstrCategoryId)
                Else
                    Call .addString(CPstrCARRIER_CATEGORY_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjig_jyclist_, lrMsg, laMsg)
            
            '@ﾒｯｾｰｼﾞ受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '結果によって処理分岐
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@ｱﾚｰを取得
                    Call laMsg.getMsgAry(CPstrJIG_LIST, laAry)
                    
                    'ﾘｽﾄ件数は0以上か
                    llngJigCnt = laAry.Count
                    If llngJigCnt > 0 Then
                    
                        'ﾘｽﾄｾｯﾄ準備
                        If IsNothing(ltypJycJigListAns.pubJycJigList) Then
                            ltypJycJigListAns.pubJycJigList = New List(Of JycJigList)
                        Else
                            ltypJycJigListAns.pubJycJigList.Clear()
                        End If
                        ltypJycJigListAns.llngJigListCnt = llngJigCnt
                        
                        '@ｱﾚｰ内の各要素を変数に取得
                        For Each ltMsg In laAry
                            Dim tmpJycJigList As JycJigList = New JycJigList()
                        
                            With tmpJycJigList
                            
                                Call ltMsg.getString(CPstrJIG_ID, .strjigId)                               'ｼﾞｸﾞID
                                Call ltMsg.getString(CPstrJIG_STATUS, .strjigStatus)                       'ｼﾞｸﾞ状態
                                Call ltMsg.getString(CPstrJIG_STATUS_NAME, .strjigStatusNm)                'ｼﾞｸﾞ状態名
                                Call ltMsg.getString(CPstrJIG_CLASS, .strjigClass)                         'ｼﾞｸﾞ識別
                                Call ltMsg.getString(CPstrPANEL_KIND, .strPanelKind)                       'ﾊﾟﾈﾙ種類
                                Call ltMsg.getString(CPstrSCREEN_SIZE_ID, .strScreenSize)                  'ﾊﾟﾈﾙｻｲｽﾞ
                                Call ltMsg.getString(CPstrCARRIER_CATEGORY_ID, .strCarrierCategoryId)      'ｷｬﾘｱｶﾃｺﾞﾘID
                                Call ltMsg.getString(CPstrCARRIER_CATEGORY_NAME, .strcarrierCategoryNm)    'ｷｬﾘｱｶﾃｺﾞﾘ名
                                Call ltMsg.getString(CPstrSTART_TIME, .strStartTime)                       '使用開始日時
                                Call ltMsg.getString(CPstrCLEAN_TIME, .strCleanTime)                       '最終洗浄日時
                                Call ltMsg.getString(CPstrUSE_NUM, .strUseNum)                             '使用回数
                                Call ltMsg.getString(CPstrUSE_LIMIT, .strUseLimit)                         '使用可能回数
                                Call ltMsg.getString(CPstrEMP_ID, .strEmpID)                               '最終使用者(氏名ｺｰﾄﾞ)
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                           '最終使用者名
                                Call ltMsg.getString(CPstrCOMMENTS, .strComments)                          'コメント
        '@↓2010/04/26 (Mon) 13:17:35 T.Oide **************************************************
                                Call ltMsg.getString(CPstrWASH_USE_NUM, .strWashUseNum)                    '洗浄後使用回数
                                Call ltMsg.getString(CPstrWASH_USE_LIMIT, .strWashUseLimit)                '洗浄後上限回数
        '@↑2010/04/26 (Mon) 13:17:35 T.Oide **************************************************
                                
                            End With

                            ltypJycJigListAns.pubJycJigList.Add(tmpJycJigList)
                            
                        Next
                        '処理完了
                    End If
                    
                    '@結果OK
                    pubblnJycJigList_Sel = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrjig_jyclist__Ver)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
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

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laAry = Nothing

        End Try
    End Function

	'=========================================Public=========================================
    '関数名：pubblnJJigList_Sel
    '機　能：蒸着治具情報一覧取得
    '引　数：
    '      ：ltypJJigListAns  ：蒸着治具一覧取得結果(from Svr)
    '      ：lstrJigStatus      :治具ｽﾃｰﾀｽ

    '戻り値：True:成功/Flase：失敗
    '作成日：
    '更新日：
    '備　考：
    Public Function pubblnJJigList_Sel(ByVal lstrjig_jjiglistVer As String, _
                                         ByVal lstrJJigStatus As String, _
                                         ByVal lstrJJigCategory As String, _
										 ByVal lstrPdId As String, _
                                         ByRef ltypJJigListAns As pubtypJJigList) _
                                         As Boolean
                                        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngJJigCnt         As Integer          'ｼﾞｸﾞﾘｽﾄ件数

        Try
            
            pstrMessageName = "蒸着治具情報一覧取得"
            
            '戻り値初期化
            pubblnJJigList_Sel = False
            lrMsg = New TfMsg
            laMsg = New TfMsg
            laAry = New TfMsgAry
            
            'Msgの作成
            With lrMsg
                '@MsgVerｾｯﾄ
                Call .addString(CPstrMSG_VER, lstrjig_jjiglistVer)
                '@治具ｽﾃｰﾀｽｾｯﾄ
                If lstrJJigStatus <> vbNullString Then
                    Call .addString(CPstrJIG_Status, lstrJJigStatus)
                Else
                    Call .addString(CPstrJIG_Status, CPstrMsgNull)
                End If
                '@蒸着治具ｶﾃｺﾞﾘｾｯﾄ
                If lstrJJigCategory <> vbNullString Then
                    Call .addString(CPstrJ_JIG_CATEGORY, lstrJJigCategory)
                Else
                    Call .addString(CPstrJ_JIG_CATEGORY, CPstrMsgNull)
                End If
                '@機種ｾｯﾄ
                If lstrPdId <> vbNullString Then
                    Call .addString(CPstrPD_ID, lstrPdId)
                Else
                    Call .addString(CPstrPD_ID, CPstrMsgNull)
                End If

            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjig_jjiglist, lrMsg, laMsg)
            
            '@ﾒｯｾｰｼﾞ受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '結果によって処理分岐
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                
                    '@ｱﾚｰを取得
                    Call laMsg.getMsgAry(CPstrJ_JIG_LIST, laAry)
                    
                    'ﾘｽﾄ件数は0以上か
                    llngJJigCnt = laAry.Count
                    If llngJJigCnt > 0 Then
                    
                        'ﾘｽﾄｾｯﾄ準備
                        If IsNothing(ltypJJigListAns.pubJJigList) Then
                            ltypJJigListAns.pubJJigList = New List(Of JJigList)
                        Else
                            ltypJJigListAns.pubJJigList.Clear()
                        End If
                        ltypJJigListAns.llngJJigListCnt = llngJJigCnt
                        
                        '@ｱﾚｰ内の各要素を変数に取得
                        For Each ltMsg In laAry
                            Dim tmpJJigList As JJigList = New JJigList()
                        
                            With tmpJJigList
                            
                                Call ltMsg.getString(CPstrJIG_ID, .strJJigId)                               'ｼﾞｸﾞID
                                Call ltMsg.getString(CPstrJIG_STATUS, .strJJigStatusId)                     'ｼﾞｸﾞ状態
                                Call ltMsg.getString(CPstrJIG_STATUS_NAME, .strJJigStatusNm)                'ｼﾞｸﾞ状態名
                                Call ltMsg.getString(CPstrJ_JIG_PD_ID_LIST, .strJJigPdId)				'機種ﾘｽﾄ(カンマ区切り済み)
                                Call ltMsg.getString(CPstrJ_JIG_CATEGORY, .strJJigCategoryId)				'蒸着治具ｶﾃｺﾞﾘ
                                Call ltMsg.getString(CPstrSET_GUIDE_ID, .strSetGuideId)						'組立ｶﾞｲﾄﾞﾘﾝｸﾞID
                                Call ltMsg.getString(CPstrSET_MASK_ID, .strSetMaskId)						'組立ﾏｽｸID
                                Call ltMsg.getString(CPstrSET_HOLDER_ID, .strSetHolderId)					'紐付けホルダID			
                                Call ltMsg.getString(CPstrSET_EMP_ID, .strSetEmpID)							'組立担当者Id
                                Call ltMsg.getString(CPstrSET_EMP_NAME, .strSetEmpName)						'組立担当者名
                                Call ltMsg.getString(CPstrSTART_TIME, .strStartTime)                       '使用開始日時
                                Call ltMsg.getString(CPstrCLEAN_TIME, .strCleanTime)                       '最終洗浄日時
                                Call ltMsg.getString(CPstrUSE_NUM, .strUseNum)                             '使用回数
								Call ltMsg.getString(CPstrUSE_LIMIT, .strUseLimit)                         '使用上限回数
                                Call ltMsg.getString(CPstrNEXT_STOCK_READY_FLAG, .strNextStockReadyFlag)   '次回在庫準備フラグ   
                                Call ltMsg.getString(CPstrEMP_ID, .strEmpID)                               '最終使用者(氏名ｺｰﾄﾞ)
                                Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                           '最終使用者名
                                Call ltMsg.getString(CPstrCOMMENTS, .strComments)                          'コメント
                                Call ltMsg.getString(CPstrWASH_USE_NUM, .strWashUseNum)                    '洗浄後使用回数
                                Call ltMsg.getString(CPstrWASH_USE_LIMIT, .strWashUseLimit)                '洗浄後上限回数
                                
                            End With

                            ltypJJigListAns.pubJJigList.Add(tmpJJigList)
                            
                        Next
                        '処理完了
                    End If
                    
                    '@結果OK
                    pubblnJJigList_Sel = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, CPstrjig_jjiglist)


                '@〓 その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり) 〓
                Case Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
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

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnJycJigData_Add
    '機　能：蒸着治具情報登録
    '引　数：pstrJigId : 治具ID
    '戻り値：True:成功/Flase：失敗
    '作成日：2009/05/27 (Wed) 17:05:04 K.Nishizawa
    '更新日：2009/07/23 (Thu) 09:10:04 T.Oide
    '備　考：
    Public Function pubblnJycJigData_Add(ByVal lstrjig_jycadd___Ver As String, byVal lstrJJigCategory As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "蒸着治具情報登録"
            
            '戻り値初期化
            pubblnJycJigData_Add = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With lrMsg
            
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                Call .addString(CPstrMSG_VER, lstrjig_jycadd___Ver)
                
                '@治具ID
                If pstrJigID <> vbNullString Then
                    Call .addString(CPstrJIG_ID, pstrJigID)
                Else
                    Call .addString(CPstrJIG_ID, CPstrMsgNull)
                End If
                
                '@ﾕｰｻﾞID
                If pstrUserID <> vbNullString Then
                    Call .addString(CPstrEMP_ID, pstrUserID)
                Else
                    Call .addString(CPstrEMP_ID, CPstrMsgNull)
                End If

				'@蒸着治具ｶﾃｺﾞﾘ
                If lstrJJigCategory <> vbNullString Then
                    Call .addString(CPstrJ_JIG_CATEGORY, lstrJJigCategory)
                Else
                    Call .addString(CPstrJ_JIG_CATEGORY, CPstrMsgNull)
                End If
            
            End With
            
            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjig_jycadd__, lrMsg, laMsg)
            
            '@ﾒｯｾｰｼﾞ受信
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果によって処理分岐
            Select Case lstrRET
            
                '@正常の場合
                Case CPstrTRUE
                    
                    '正常終了
                    pubblnJycJigData_Add = True
                    
                '@失敗の場合
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrjig_jycadd___Ver)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

	'関数名：pubblnJJigData_Add
    '機　能：蒸着治具情報登録
    '引　数：pstrJigId : 治具ID
    '戻り値：True:成功/Flase：失敗
    '作成日：2009/05/27 (Wed) 17:05:04 K.Nishizawa
    '更新日：2009/07/23 (Thu) 09:10:04 T.Oide
    '備　考：
    Public Function pubblnJJigData_Add(ByVal lstrjig_jjigaddVer As String, ByVal lstrJJigCategory As String _ 
									   ) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim lstrRET             As String           '応答取得

        Try
            
            pstrMessageName = "蒸着治具情報登録"
            
            '戻り値初期化
            pubblnJJigData_Add = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With lrMsg
            
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                Call .addString(CPstrMSG_VER, lstrjig_jjigaddVer)
                
                '@治具ID
                If pstrJigID <> vbNullString Then
                    Call .addString(CPstrJIG_ID, pstrJigID)
                Else
                    Call .addString(CPstrJIG_ID, CPstrMsgNull)
                End If
                
				'@蒸着治具ｶﾃｺﾞﾘ
                If pstrUserID <> vbNullString Then
                    Call .addString(CPstrJ_JIG_CATEGORY, lstrJJigCategory)
                Else
                    Call .addString(CPstrJ_JIG_CATEGORY, CPstrMsgNull)
                End If

                '@ﾕｰｻﾞID
                If pstrUserID <> vbNullString Then
                    Call .addString(CPstrEMP_ID, pstrUserID)
                Else
                    Call .addString(CPstrEMP_ID, CPstrMsgNull)
                End If


            
            End With
            
            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjig_jycadd__, lrMsg, laMsg)
            
            '@ﾒｯｾｰｼﾞ受信
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果によって処理分岐
            Select Case lstrRET
            
                '@正常の場合
                Case CPstrTRUE
                    
                    '正常終了
                    pubblnJJigData_Add = True
                    
                '@失敗の場合
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrjig_jjigaddVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
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

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            
        End Try
    End Function

    '関数名：pubblnJycJigData_Upd
    '機　能：蒸着治具情報変更
    '引　数：pstrJigId : 治具ID
    '戻り値：True:成功/Flase：失敗
    '作成日：2009/05/27 (Wed) 17:05:04 K.Nishizawa
    '更新日：2010/04/26 (Mon) 13:44:37 T.Oide
    '備　考：
    '　　　：2010/01/22 (Fri) 16:39:50 T.Oide       №03910対応(ｽｸﾘｰﾝｻｲｽﾞの手動変更対応)
    '　　　：2010/04/26 (Mon) 13:35:24 T.Oide       №04023対応(洗浄後使用回数管理追加)&ｿｰｽ整備
    Public Function pubblnJycJigData_Upd(ByVal lstrjig_chgjyc___Ver As String, _
                                         ByRef prvtypJycJigListReq As pubtypJycJigList) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrMsg2              As TfMsg            '送信ﾒｯｾｰｼﾞ2
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer
        
        Try
            
            pstrMessageName = "蒸着治具情報変更"
            
            pubblnJycJigData_Upd = False
            
            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@ﾒｯｾｰｼﾞVer設定
            Call lrMsg.addString(CPstrMSG_VER, lstrjig_chgjyc___Ver)
            
            '@ﾕｰｻﾞID設定
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '更新する治具情報の要素を設定
            For llngCnt = 0 To prvtypJycJigListReq.llngJigListCnt - 1
            
                With prvtypJycJigListReq.pubJycJigList(llngCnt)
                
                    '@治具ID
                    If .strjigId <> vbNullString Then
                        Call lrMsg2.addString(CPstrJIG_ID, .strjigId)
                    Else
                        Call lrMsg2.addString(CPstrJIG_ID, CPstrMsgNull)
                    End If
                    
                    '@ｽｸﾘｰﾝｻｲｽﾞ
                    If .strScreenSize <> vbNullString Then
                        Call lrMsg2.addString(CPstrSCREEN_SIZE_ID, .strScreenSize)
                    Else
                        Call lrMsg2.addString(CPstrSCREEN_SIZE_ID, CPstrMsgNull)
                    End If
                    
        '@↓2010/04/26 (Mon) 13:45:13 T.Oide **************************************************
                    '@洗浄後上限回数
                    If .strWashUseLimit <> vbNullString Then
                        Call lrMsg2.addString(CPstrWASH_USE_LIMIT, .strWashUseLimit)
                    Else
                        Call lrMsg2.addString(CPstrWASH_USE_LIMIT, CPstrMsgNull)
                    End If
        '@↑2010/04/26 (Mon) 13:45:13 T.Oide **************************************************
                    
                    '@ｶﾃｺﾞﾘID
                    If .strCarrierCategoryId <> vbNullString Then
                        Call lrMsg2.addString(CPstrCARRIER_CATEGORY_ID, .strCarrierCategoryId)
                    Else
                        Call lrMsg2.addString(CPstrCARRIER_CATEGORY_ID, CPstrMsgNull)
                    End If

                    '@最終洗浄日時
                    If .strCleanTime <> vbNullString Then
                        Call lrMsg2.addString(CPstrCLEAN_TIME, .strCleanTime)
                    Else
                        Call lrMsg2.addString(CPstrCLEAN_TIME, CPstrMsgNull)
                    End If
                                
                    '@コメント
                    If .strComments <> vbNullString Then
                        Call lrMsg2.addString(CPstrCOMMENTS, .strComments)
                    Else
                        Call lrMsg2.addString(CPstrCOMMENTS, CPstrMsgNull)
                    End If
                    
                    '@累積上限回数
                    If .strUseLimit <> vbNullString Then
                        Call lrMsg2.addString(CPstrUSE_LIMIT, .strUseLimit)
                    Else
                        Call lrMsg2.addString(CPstrUSE_LIMIT, CPstrMsgNull)
                    End If
                    
        '@↓2010/04/27 (Tue) 15:09:57 T.Oide **************************************************
                    '@洗浄後使用回数
                    If .strWashUseNum <> vbNullString Then
                        Call lrMsg2.addString(CPstrWASH_USE_NUM, .strWashUseNum)
                    Else
                        Call lrMsg2.addString(CPstrWASH_USE_NUM, CPstrMsgNull)
                    End If
                    
                    '@ｽﾃｰﾀｽ
                    If .strjigStatus <> vbNullString Then
                        Call lrMsg2.addString(CPstrJIG_STATUS, .strjigStatus)
                    Else
                        Call lrMsg2.addString(CPstrJIG_STATUS, CPstrMsgNull)
                    End If
        '@↑2010/04/27 (Tue) 15:09:57 T.Oide **************************************************
                    
                    
                End With
                
                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
                
            Next
            
            Call lrMsg.addMsgAry(CPstrJIG_LIST, lrAry)
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjig_chgjyc__, lrMsg, laMsg)
            
            '@結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
            
                '@取得成功の場合
                Case CPstrTRUE
                    pubblnJycJigData_Upd = True
                                
                '@取得失敗の場合
                Case CPstrFALSE
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                     Call pubstrErrMsg_Set(laMsg, lstrjig_chgjyc___Ver)
                
                '@その他
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
            End Select

            lrMsg = Nothing
            lrMsg2 = Nothing
            laMsg = Nothing
            lrAry = Nothing

            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            laMsg = Nothing
            lrAry = Nothing

        End Try
    End Function



    '関数名：pubblnJJigData_Upd
    '機　能：蒸着治具情報変更
    '引　数：pstrJigId : 治具ID
    '戻り値：True:成功/Flase：失敗
    '作成日：
    '更新日：
    '備　考：

    Public Function pubblnJJigData_Upd(ByVal lstrjig_chgjjigVer As String, _
                                         ByRef prvtypJJigListReq As pubtypJJigList) As Boolean
        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrMsg2              As TfMsg            '送信ﾒｯｾｰｼﾞ2
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer
        
        Try
            
            pstrMessageName = "蒸着治具情報変更"
            
            pubblnJJigData_Upd = False
            
            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@ﾒｯｾｰｼﾞVer設定
            Call lrMsg.addString(CPstrMSG_VER, lstrjig_chgjjigVer)
            
            '@ﾕｰｻﾞID設定
            If pstrUserID <> vbNullString Then
                Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
            Else
                Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
            End If
            
            '更新する治具情報の要素を設定
            For llngCnt = 0 To prvtypJJigListReq.llngJJigListCnt - 1
            
                With prvtypJJigListReq.pubJJigList(llngCnt)
                
                    '@治具ID
                    If .strjjigId <> vbNullString Then
                        Call lrMsg2.addString(CPstrJIG_ID, .strjjigId)
                    Else
                        Call lrMsg2.addString(CPstrJIG_ID, CPstrMsgNull)
                    End If

					'@治具ステータス
                    If .strJJigStatusId <> vbNullString Then
                        Call lrMsg2.addString(CPstrJIG_STATUS, .strJJigStatusId)
                    Else
                        Call lrMsg2.addString(CPstrJIG_STATUS, CPstrMsgNull)
                    End If

					'@蒸着治具カテゴリ
                    If .strJJigCategoryId <> vbNullString Then
                        Call lrMsg2.addString(CPstrJ_JIG_CATEGORY, .strJJigCategoryId)
                    Else
                        Call lrMsg2.addString(CPstrJ_JIG_CATEGORY, CPstrMsgNull)
                    End If

					'組立ガイドリングID
					If .strSetGuideId <> vbNullString Then
                        Call lrMsg2.addString(CPstrSET_GUIDE_ID, .strSetGuideId)
                    Else
                        Call lrMsg2.addString(CPstrSET_GUIDE_ID, CPstrMsgNull)
                    End If

					'組立マスクID
					If .strSetMaskId <> vbNullString Then
                        Call lrMsg2.addString(CPstrSET_MASK_ID, .strSetMaskId)
                    Else
                        Call lrMsg2.addString(CPstrSET_MASK_ID, CPstrMsgNull)
                    End If

					'組立作業者ID
					If .strSetEmpId <> vbNullString Then
                        Call lrMsg2.addString(CPstrSET_EMP_ID, .strSetEmpId)
                    Else
                        Call lrMsg2.addString(CPstrSET_EMP_ID, CPstrMsgNull)
                    End If
                    
					'@累積上限回数
                    If .strUseLimit <> vbNullString Then
                        Call lrMsg2.addString(CPstrUSE_LIMIT, .strUseLimit)
                    Else
                        Call lrMsg2.addString(CPstrUSE_LIMIT, CPstrMsgNull)
                    End If

                    '@洗浄後上限回数
                    If .strWashUseLimit <> vbNullString Then
                        Call lrMsg2.addString(CPstrWASH_USE_LIMIT, .strWashUseLimit)
                    Else
                        Call lrMsg2.addString(CPstrWASH_USE_LIMIT, CPstrMsgNull)
                    End If
                    

                    '@最終洗浄日時
                    If .strCleanTime <> vbNullString Then
                        Call lrMsg2.addString(CPstrCLEAN_TIME, .strCleanTime)
                    Else
                        Call lrMsg2.addString(CPstrCLEAN_TIME, CPstrMsgNull)
                    End If
                                
                    '@コメント
                    If .strComments <> vbNullString Then
                        Call lrMsg2.addString(CPstrCOMMENTS, .strComments)
                    Else
                        Call lrMsg2.addString(CPstrCOMMENTS, CPstrMsgNull)
                    End If
                    
                    
                    '@洗浄後使用回数
                    If .strWashUseNum <> vbNullString Then
                        Call lrMsg2.addString(CPstrWASH_USE_NUM, .strWashUseNum)
                    Else
                        Call lrMsg2.addString(CPstrWASH_USE_NUM, CPstrMsgNull)
                    End If

                    '@次回在庫準備ﾌﾗｸﾞ
                    If .strNextStockReadyFlag <> vbNullString Then
                        Call lrMsg2.addString(CPstrNEXT_STOCK_READY_FLAG, .strNextStockReadyFlag)
                    Else
                        Call lrMsg2.addString(CPstrNEXT_STOCK_READY_FLAG, CPstrMsgNull)
                    End If

					'@治具イベントID
                    If .strJigEventId <> vbNullString Then
                        Call lrMsg2.addString(CPstrJIG_EVENT_ID, .strJigEventId)
                    Else
                        Call lrMsg2.addString(CPstrJIG_EVENT_ID, CPstrMsgNull)
                    End If

                    
                End With
                
                Call lrAry.Add(lrMsg2)
                lrMsg2.Clear
                
            Next
            
            Call lrMsg.addMsgAry(CPstrJ_JIG_LIST, lrAry)
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrjig_chgjjig, lrMsg, laMsg)
            
            '@結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
            
                '@取得成功の場合
                Case CPstrTRUE
                    pubblnJJigData_Upd = True
                                
                '@取得失敗の場合
                Case CPstrFALSE
                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                     Call pubstrErrMsg_Set(laMsg, lstrjig_chgjjigVer)
                
                '@その他
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
            End Select

            lrMsg = Nothing
            lrMsg2 = Nothing
            laMsg = Nothing
            lrAry = Nothing

            Exit Function
            
        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            lrMsg2 = Nothing
            laMsg = Nothing
            lrAry = Nothing

        End Try
    End Function

End Module
