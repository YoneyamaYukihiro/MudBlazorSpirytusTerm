'ﾌｧｲﾙ名：xxMG02P0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：バッチ_受入在庫　通信メッセージ用標準モジュール
'作成日：2018/08/02 (Thu) 16:39:08 T.Oide
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2018-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02P0
    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '=========================================Public=========================================
    Public Structure DivLotInfo
        Dim strLotID            As String
        Dim lngRow              As Integer
        Dim lngChipNum          As Integer
        Dim strPosition         As String
        Dim strA_CrrierGr       As String
    End Structure

    Public Structure typeDivLot
        Dim typeDivLotInfo      As List(Of DivLotInfo)
        Dim lngDivLotInfoCnt    As Integer
    End Structure

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '=========================================Public=========================================

    '関数名：pubblnMasAldbatchrecipe_Sel
    '機　能：防湿膜ALDの「ﾃｰﾌﾟ貼り」「ｵｰﾌﾞﾝ」「ALD」ﾚｼﾋﾟを取得する
    '引　数：strMsgVer          ：ﾒｯｾｰｼﾞVer
    '　　　：ltypeAldBatchRecipe：防湿膜ALDﾊﾞｯﾁﾚｼﾋﾟ
    '　　　：strSbID            ：ｼｽﾃﾑﾌﾞﾛｯｸID
    '　　　：strParentPdId      ：親機種ID(2A0)
    '　　　：strPdId            ：機種ID(3A0)
    '戻り値：
    '作成日：2018/08/20 (Mon) 14:07:38 T.Oide
    '更新日：2018/08/20 (Mon) 14:07:38
    '備　考：
    Public Function pubblnMasAldbatchrecipe_Sel( _
                                ByVal strMsgVer As String, _
                                ByRef ltypeAldBatchRecipe As typAldBatchRecipeList, _
                                ByVal strSbID As String, _
                                ByVal strParentPdId As String, _
                                ByVal strPdId As String)

        Dim lrMsg               As TfMsg             '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg             '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String            '応答取得

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@初期設定
            pstrMessageName = "防湿膜ALDﾊﾞｯﾁﾚｼﾋﾟ取得"
            pubblnMasAldbatchrecipe_Sel = False

            '@***********************
            '@　送信ﾒｯｾｰｼﾞの作成
            '@***********************
            '@ｼｽﾃﾑﾌﾞﾛｯｸID
            If strSbID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, strSbID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If

            '@機種ID
            If strPdId <> vbNullString Then
                Call lrMsg.addString(CPstrPD_ID, strPdId)
            Else
                Call lrMsg.addString(CPstrPD_ID, CPstrMsgNull)
            End If

            '@Msgﾊﾞｰｼﾞｮﾝ
            If strMsgVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, strMsgVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrmas_aldbatchrecipe, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    With ltypeAldBatchRecipe
                        '@要素追加
                        .lngAldBatchRecipeCnt = .lngAldBatchRecipeCnt + 1
                        'ReDim Preserve .typeAldBatchRecipe(.lngAldBatchRecipeCnt)
                        If .typeAldBatchRecipe Is Nothing then
                            .typeAldBatchRecipe = New List(Of AldBatchRecipe)
                        End if

                        Dim tmpAldBatchRecipe As AldBatchRecipe
                        tmpAldBatchRecipe = New AldBatchRecipe

                        '@情報格納
                        With tmpAldBatchRecipe
                            .strParentPdId = strParentPdId                                          '親機種
                            Call laMsg.getString(CPstrPD_ID, .strPdId)                              '機種
                            Call laMsg.getString(CPstrTAPE_STICK_RECIPE_ID, .strTapeStickRecipe)    'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
                            Call laMsg.getString(CPstrOVEN_RESCIPE_ID, .strOvenRecipe)              'ｵｰﾌﾞﾝﾚｼﾋﾟ
                            Call laMsg.getString(CPstrALD_RECIPE_ID, .strAldRecipe)                 'ALDﾚｼﾋﾟ
                        End With

                        .typeAldBatchRecipe.Add(tmpAldBatchRecipe)
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnMasAldbatchrecipe_Sel = True

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

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            lrMsg = Nothing
            laMsg = Nothing

        End Try
    End Function

    '関数名：prvblnAldBatchRegist
    '機　能：ALDﾊﾞｯﾁ情報登録
    '引　数：lstrVer        ：ﾒｯｾｰｼﾞVer
    '　　　：ltypAldBatch   ：登録ﾊﾞｯﾁ情報
    '戻り値：True：成功、False：失敗
    '作成日：2018/08/23 (Thu) 15:40:28 T.Oide
    '更新日：2018/08/23 (Thu) 15:40:28
    '備　考：
    Public Function prvblnAldBatchRegist(ByVal lstrVER As String, _
                                         ByRef ltypAldBatch As typAldBatchList) As Boolean

        Dim lrMsg       As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg       As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim ltMsg       As TfMsg            '受信ﾒｯｾｰｼﾞ(temp)-送信
        Dim lrAry       As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ﾘｸｴｽﾄ)-送信
        Dim lstrRET     As String           '応答取得
        Dim llngCnt     As Integer          'ｱﾚｲｶｳﾝﾄ用

        Try

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry

            '@初期設定
            pstrMessageName = "ALDバッチ登録"
            prvblnAldBatchRegist = False

            '@***********************
            '@　送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypAldBatch
                '@CLASS_DIVISION
                If .strClassDiv <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDiv)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                '@SB_ID
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                '@ﾊﾞｯﾁは1つしか登録しないので1固定
                With .typAldBatchList(0)
                    '@ﾊﾞｯﾁID
                    If .strBatchId <> vbNullString Then
                        Call lrMsg.addString(CPstrBATCH_ID, .strBatchId)
                    Else
                        Call lrMsg.addString(CPstrBATCH_ID, CPstrMsgNull)
                    End If

                    '@投入予定日
                    If .strPlanThrowinDate <> vbNullString Then
                        Call lrMsg.addString(CPstrPLAN_THROWIN_DATE, .strPlanThrowinDate)
                    Else
                        Call lrMsg.addString(CPstrPLAN_THROWIN_DATE, CPstrMsgNull)
                    End If

                    '@ﾊﾞｯﾁ流動区分
                    If .strBatchFlowClass <> vbNullString Then
                        Call lrMsg.addString(CPstrBATCH_FLOW_CLASS, .strBatchFlowClass)
                    Else
                        Call lrMsg.addString(CPstrBATCH_FLOW_CLASS, CPstrMsgNull)
                    End If

                    '@ﾓﾆﾀ-使用ﾌﾗｸﾞ
                    If .steMonitorUseFlag <> vbNullString Then
                        Call lrMsg.addString(CPstrMONITOR_USE_FLAG, .steMonitorUseFlag)
                    Else
                        Call lrMsg.addString(CPstrMONITOR_USE_FLAG, CPstrMsgNull)
                    End If

                    '@ﾕｰｻﾞID
                    If pstrUserID <> vbNullString Then
                        Call lrMsg.addString(CPstrEMP_ID, pstrUserID)
                    Else
                        Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                    End If

                    '@ﾛｯﾄﾘｽﾄ
                    For llngCnt = 0 To .lngBatchDetailCnt-1
                        With .typBatchDetail(llngCnt)
                            If .strLotID <> vbNullString Then
                                Call ltMsg.addString(CPstrLOT_ID, .strLotID)                            'ロットID
                            Else
                                Call ltMsg.addString(CPstrLOT_ID, CPstrMsgNull)                         'ロットID
                            End If
                            If .strPdId <> vbNullString Then
                                Call ltMsg.addString(CPstrPD_ID, .strPdId)                              '機種
                            Else
                                Call ltMsg.addString(CPstrPD_ID, CPstrMsgNull)                          '機種
                            End If
                            If .strWfQty <> vbNullString Then
                                Call ltMsg.addString(CPstrWF_QUANTITY, .strWfQty)                       'WF数
                            Else
                                Call ltMsg.addString(CPstrWF_QUANTITY, CPstrMsgNull)                    'WF数
                            End If
                            If .strChipQty <> vbNullString Then
                                Call ltMsg.addString(CPstrCHIP_QUANTITY, .strChipQty)                   'CHIP数
                            Else
                                Call ltMsg.addString(CPstrCHIP_QUANTITY, CPstrMsgNull)                  'CHIP数
                            End If
                            If .strACrrierGroup <> vbNullString Then
                                Call ltMsg.addString(CPstrA_CARRIER_GROUP, .strACrrierGroup)            'Aキャリアグループ
                            Else
                                Call ltMsg.addString(CPstrA_CARRIER_GROUP, CPstrMsgNull)                'Aキャリアグループ
                            End If
                            If .strTapeStickGr <> vbNullString Then
                                Call ltMsg.addString(CPstrTAPE_STICK_GROUP, .strTapeStickGr)            'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                            Else
                                Call ltMsg.addString(CPstrTAPE_STICK_GROUP, CPstrMsgNull)               'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                            End If
                            If .strAtrayChipNum <> vbNullString Then
                                Call ltMsg.addString(CPstrA_TRAY_CHIP_NUM, .strAtrayChipNum)            'Aトレーチップ収容数
                            Else
                                Call ltMsg.addString(CPstrA_TRAY_CHIP_NUM, CPstrMsgNull)                'Aトレーチップ収容数
                            End If
                            If .strFlowClass <> vbNullString Then
                                Call ltMsg.addString(CPstrFLOW_CLASS, .strFlowClass)                    '種別
                            Else
                                Call ltMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)                     '種別
                            End If
                            If .strTapeStickRrecipeId <> vbNullString Then
                                Call ltMsg.addString(CPstrTAPE_STICK_RECIPE_ID, .strTapeStickRrecipeId) 'テープ貼りレシピ
                            Else
                                Call ltMsg.addString(CPstrTAPE_STICK_RECIPE_ID, CPstrMsgNull)           'テープ貼りレシピ
                            End If
                            If .strOvenRecipeId <> vbNullString Then
                                Call ltMsg.addString(CPstrOVEN_RECIPE_ID, .strOvenRecipeId)             'オーブンレシピ
                            Else
                                Call ltMsg.addString(CPstrOVEN_RECIPE_ID, CPstrMsgNull)                 'オーブンレシピ
                            End If
                            If .strAldRecipeId <> vbNullString Then
                                Call ltMsg.addString(CPstrALD_RECIPE_ID, .strAldRecipeId)               'ALDレシピ
                            Else
                                Call ltMsg.addString(CPstrALD_RECIPE_ID, CPstrMsgNull)                  'ALDレシピ
                            End If

                            Call lrAry.Add(ltMsg)
                            ltMsg.Clear
                        End With
                    Next

                    Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
                    lrAry.Clear
                End With
            End With

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrVER <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrVER)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrbat_aldbatchregist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@★ 通信結果(SVからの応答)により処理分岐 ★
            Select Case lstrRET

                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE

                    '@戻り値に"True：成功"をｾｯﾄ
                    prvblnAldBatchRegist = True

                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrVER)

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

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄ変数の解放
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function
End Module
