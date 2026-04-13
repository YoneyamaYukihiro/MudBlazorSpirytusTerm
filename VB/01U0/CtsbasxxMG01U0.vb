'ﾌｧｲﾙ名：xxMG01U0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾌｫﾄF/Bﾊﾟﾗﾒｰﾀ変更　標準ﾓｼﾞｭｰﾙ
'作成日：2006/03/02 (Thu) 16:17:58 N.Kasai
'更新日：2017/01/19 (Thu) 18:33:01 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2017, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01U0
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubblnPhotoFbDataList_Sel
    '機　能：ﾌｫﾄF/Bﾃﾞｰﾀ取得
    '引　数：ltypPhotoFbDataListReq：要求構造体
    '　　　：ltypPhotoFbDataListAns：応答構造体
    '戻り値：True：正常、False：異常
    '作成日：2006/03/10 (Fri) 17:20:50 N.Kasai
    '更新日：2017/01/19 (Thu) 18:30:59 T.Oide
    '備　考：
    '　　　：2006/04/04 (Tue) 15:44:33 N.Kasai  要求ﾀｸﾞ追加（RECIPE_ID)
    '　　　：2007/08/31 (Fri) 13:35:06 N.Kasai  要求、応答ﾀｸﾞ変更（№02129）
    Public Function pubblnPhotoFbDataList_Sel( _
                ByRef ltypPhotoFbDataListReq As PhotoFbDataListReq, _
                ByRef ltypPhotoFbDataListAns As PhotoFbDataListAns _
            ) As Boolean

        Dim lrMsg                   As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg                   As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg1                  As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry1                  As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim ltMsg2                  As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry2                  As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET                 As String           '応答取得
        Dim llngCnt1                As Integer          'ｶｳﾝﾄ用
        Dim llngCnt                 As Integer
        Dim llngPatchNum            As String             'Patch分割数
        Dim lstrTmpShiftXValue      As String
        Dim lstrTmpShiftYValue      As String
        Dim lstrTmpWaferMagXValue   As String
        Dim lstrTmpWaferMagYValue   As String
        Dim lstrTmpWaferRotXValue   As String
        Dim lstrTmpWaferRotYValue   As String
        Dim lstrTmpShotRotValue     As String
        Dim lstrTmpShotMagValue     As String
        Dim lstrTmpShotRotXValue     As String
        Dim lstrTmpShotRotYValue     As String
        Dim lstrTmpShotMagXValue     As String
        Dim lstrTmpShotMagYValue     As String

        Try

            '@初期設定
            pstrMessageName = "フォトF/Bデータ取得"
            '@戻り値の初期化
            pubblnPhotoFbDataList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypPhotoFbDataListReq
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
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@ﾚｼﾋﾟID
                If .strRecipeId <> vbNullString Then
                    Call lrMsg.addString(CPstrRECIPE_ID, .strRecipeId)
                Else
                    Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
                End If

                '基準ﾌｫﾄ号機ID
                If .strReferencePhotoWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrREFERENCE_PHOTO_WP_ID, .strReferencePhotoWpID)
                Else
                    Call lrMsg.addString(CPstrREFERENCE_PHOTO_WP_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__photofbdatalist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrFB_DATA_ITEM_LIST, laAry1)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                    ltypPhotoFbDataListAns.lngFbDataItemListCnt = laAry1.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypPhotoFbDataListAns.lngFbDataItemListCnt > 0 Then
                        If IsNothing(ltypPhotoFbDataListAns.typFbDataItemList) Then
                            ltypPhotoFbDataListAns.typFbDataItemList = New List(Of FbDataItemList)
                        Else
                            ltypPhotoFbDataListAns.typFbDataItemList.Clear()
                        End If
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ１から各Msg取得
                        llngCnt1 = 0
                        For Each ltMsg1 In laAry1
                            Dim typFbDataItemListTmp As New FbDataItemList
                            '@受信結果取得
                            With typFbDataItemListTmp
                                Call ltMsg1.getString(CPstrFB_CALC_LOTS, .strFbCalcLots)            'F/B計算対象ﾛｯﾄ
                                Call ltMsg1.getString(CPstrEMP_NAME, .strEmpName)                   '最終更新者
                                Call ltMsg1.getString(CPstrENTRY_TIME, .strEntryTime)               '最終更新日時
                                Call ltMsg1.getString(CPstrCOMMENTS, .strComments)                  'ｺﾒﾝﾄ
                                Call laMsg.getString(CPstrPATCH_NUM, llngPatchNum)                  'ﾊﾟｯﾁ分割数取得
                                '@F/Bﾊﾟﾗﾒｰﾀを取得
                                For llngCnt = 1 To llngPatchNum
                                    Call ltMsg1.getString(CPstrSHIFTX_VALUE & "_" & llngCnt, lstrTmpShiftXValue)           'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrSHIFTY_VALUE & "_" & llngCnt, lstrTmpShiftYValue)           'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrWAFERMAGX_VALUE & "_" & llngCnt, lstrTmpWaferMagXValue)     'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrWAFERMAGY_VALUE & "_" & llngCnt, lstrTmpWaferMagYValue)     'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrWAFERROTX_VALUE & "_" & llngCnt, lstrTmpWaferRotXValue)     'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrWAFERROTY_VALUE & "_" & llngCnt, lstrTmpWaferRotYValue)     'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrSHOTROT_VALUE & "_" & llngCnt, lstrTmpShotRotValue)         'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrSHOTMAG_VALUE & "_" & llngCnt, lstrTmpShotMagValue)         'F/Bﾊﾟﾗﾒｰﾀ
                                    'Shot分離
                                    Call ltMsg1.getString(CPstrSHOTROTX_VALUE & "_" & llngCnt, lstrTmpShotRotXValue)        'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrSHOTROTY_VALUE & "_" & llngCnt, lstrTmpShotRotYValue)        'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrSHOTMAGX_VALUE & "_" & llngCnt, lstrTmpShotMagXValue)        'F/Bﾊﾟﾗﾒｰﾀ
                                    Call ltMsg1.getString(CPstrSHOTMAGY_VALUE & "_" & llngCnt, lstrTmpShotMagYValue)        'F/Bﾊﾟﾗﾒｰﾀ
                                
                                    '@カウントで分岐
                                    Select Case llngCnt
                                    
                                        Case CPlngPatchNo1
                                            .strShiftXValue = lstrTmpShiftXValue
                                            .strShiftYValue = lstrTmpShiftYValue
                                            .strWaferMagXValue = lstrTmpWaferMagXValue
                                            .strWaferMagYValue = lstrTmpWaferMagYValue
                                            .strWaferRotXValue = lstrTmpWaferRotXValue
                                            .strWaferRotYValue = lstrTmpWaferRotYValue
                                            .strShotRotValue = lstrTmpShotRotValue
                                            .strShotMagValue = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue = lstrTmpShotRotXValue
                                            .strShotRotYValue = lstrTmpShotRotYValue
                                            .strShotMagXValue = lstrTmpShotMagXValue
                                            .strShotMagYValue = lstrTmpShotMagYValue
                                
                                        Case CPlngPatchNo2
                                            .strShiftXValue_2 = lstrTmpShiftXValue
                                            .strShiftYValue_2 = lstrTmpShiftYValue
                                            .strWaferMagXValue_2 = lstrTmpWaferMagXValue
                                            .strWaferMagYValue_2 = lstrTmpWaferMagYValue
                                            .strWaferRotXValue_2 = lstrTmpWaferRotXValue
                                            .strWaferRotYValue_2 = lstrTmpWaferRotYValue
                                            .strShotRotValue_2 = lstrTmpShotRotValue
                                            .strShotMagValue_2 = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue_2 = lstrTmpShotRotXValue
                                            .strShotRotYValue_2 = lstrTmpShotRotYValue
                                            .strShotMagXValue_2 = lstrTmpShotMagXValue
                                            .strShotMagYValue_2 = lstrTmpShotMagYValue

                                        Case CPlngPatchNo3
                                            .strShiftXValue_3 = lstrTmpShiftXValue
                                            .strShiftYValue_3 = lstrTmpShiftYValue
                                            .strWaferMagXValue_3 = lstrTmpWaferMagXValue
                                            .strWaferMagYValue_3 = lstrTmpWaferMagYValue
                                            .strWaferRotXValue_3 = lstrTmpWaferRotXValue
                                            .strWaferRotYValue_3 = lstrTmpWaferRotYValue
                                            .strShotRotValue_3 = lstrTmpShotRotValue
                                            .strShotMagValue_3 = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue_3 = lstrTmpShotRotXValue
                                            .strShotRotYValue_3 = lstrTmpShotRotYValue
                                            .strShotMagXValue_3 = lstrTmpShotMagXValue
                                            .strShotMagYValue_3 = lstrTmpShotMagYValue

                                            
                                        Case CPlngPatchNo4
                                            .strShiftXValue_4 = lstrTmpShiftXValue
                                            .strShiftYValue_4 = lstrTmpShiftYValue
                                            .strWaferMagXValue_4 = lstrTmpWaferMagXValue
                                            .strWaferMagYValue_4 = lstrTmpWaferMagYValue
                                            .strWaferRotXValue_4 = lstrTmpWaferRotXValue
                                            .strWaferRotYValue_4 = lstrTmpWaferRotYValue
                                            .strShotRotValue_4 = lstrTmpShotRotValue
                                            .strShotMagValue_4 = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue_4 = lstrTmpShotRotXValue
                                            .strShotRotYValue_4 = lstrTmpShotRotYValue
                                            .strShotMagXValue_4 = lstrTmpShotMagXValue
                                            .strShotMagYValue_4 = lstrTmpShotMagYValue

                                            
                                        Case CPlngPatchNo5
                                            .strShiftXValue_5 = lstrTmpShiftXValue
                                            .strShiftYValue_5 = lstrTmpShiftYValue
                                            .strWaferMagXValue_5 = lstrTmpWaferMagXValue
                                            .strWaferMagYValue_5 = lstrTmpWaferMagYValue
                                            .strWaferRotXValue_5 = lstrTmpWaferRotXValue
                                            .strWaferRotYValue_5 = lstrTmpWaferRotYValue
                                            .strShotRotValue_5 = lstrTmpShotRotValue
                                            .strShotMagValue_5 = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue_5 = lstrTmpShotRotXValue
                                            .strShotRotYValue_5 = lstrTmpShotRotYValue
                                            .strShotMagXValue_5 = lstrTmpShotMagXValue
                                            .strShotMagYValue_5 = lstrTmpShotMagYValue

                                            
                                        Case CPlngPatchNo6
                                            .strShiftXValue_6 = lstrTmpShiftXValue
                                            .strShiftYValue_6 = lstrTmpShiftYValue
                                            .strWaferMagXValue_6 = lstrTmpWaferMagXValue
                                            .strWaferMagYValue_6 = lstrTmpWaferMagYValue
                                            .strWaferRotXValue_6 = lstrTmpWaferRotXValue
                                            .strWaferRotYValue_6 = lstrTmpWaferRotYValue
                                            .strShotRotValue_6 = lstrTmpShotRotValue
                                            .strShotMagValue_6 = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue_6 = lstrTmpShotRotXValue
                                            .strShotRotYValue_6 = lstrTmpShotRotYValue
                                            .strShotMagXValue_6 = lstrTmpShotMagXValue
                                            .strShotMagYValue_6 = lstrTmpShotMagYValue

                                            
                                        Case CPlngPatchNo7
                                            .strShiftXValue_7 = lstrTmpShiftXValue
                                            .strShiftYValue_7 = lstrTmpShiftYValue
                                            .strWaferMagXValue_7 = lstrTmpWaferMagXValue
                                            .strWaferMagYValue_7 = lstrTmpWaferMagYValue
                                            .strWaferRotXValue_7 = lstrTmpWaferRotXValue
                                            .strWaferRotYValue_7 = lstrTmpWaferRotYValue
                                            .strShotRotValue_7 = lstrTmpShotRotValue
                                            .strShotMagValue_7 = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue_7 = lstrTmpShotRotXValue
                                            .strShotRotYValue_7 = lstrTmpShotRotYValue
                                            .strShotMagXValue_7 = lstrTmpShotMagXValue
                                            .strShotMagYValue_7 = lstrTmpShotMagYValue

                                            
                                        Case CPlngPatchNo8
                                            .strShiftXValue_8 = lstrTmpShiftXValue
                                            .strShiftYValue_8 = lstrTmpShiftYValue
                                            .strWaferMagXValue_8 = lstrTmpWaferMagXValue
                                            .strWaferMagYValue_8 = lstrTmpWaferMagYValue
                                            .strWaferRotXValue_8 = lstrTmpWaferRotXValue
                                            .strWaferRotYValue_8 = lstrTmpWaferRotYValue
                                            .strShotRotValue_8 = lstrTmpShotRotValue
                                            .strShotMagValue_8 = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue_8 = lstrTmpShotRotXValue
                                            .strShotRotYValue_8 = lstrTmpShotRotYValue
                                            .strShotMagXValue_8 = lstrTmpShotMagXValue
                                            .strShotMagYValue_8 = lstrTmpShotMagYValue

                                            
                                        Case CPlngPatchNo9
                                            .strShiftXValue_9 = lstrTmpShiftXValue
                                            .strShiftYValue_9 = lstrTmpShiftYValue
                                            .strWaferMagXValue_9 = lstrTmpWaferMagXValue
                                            .strWaferMagYValue_9 = lstrTmpWaferMagYValue
                                            .strWaferRotXValue_9 = lstrTmpWaferRotXValue
                                            .strWaferRotYValue_9 = lstrTmpWaferRotYValue
                                            .strShotRotValue_9 = lstrTmpShotRotValue
                                            .strShotMagValue_9 = lstrTmpShotMagValue
                                            'Shot分離
                                            .strShotRotXValue_9 = lstrTmpShotRotXValue
                                            .strShotRotYValue_9 = lstrTmpShotRotYValue
                                            .strShotMagXValue_9 = lstrTmpShotMagXValue
                                            .strShotMagYValue_9 = lstrTmpShotMagYValue

                                            
                                    End Select
                                Next
                                
                            End With

                            ltypPhotoFbDataListAns.typFbDataItemList.Add(typFbDataItemListTmp)

                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If
                    
                    With ltypPhotoFbDataListAns
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrSHIFTX_ITEM_NAME, .strShiftXItemName)
                        Call laMsg.getString(CPstrSHIFTX_VALID_DIGIT, .strShiftXValidDigit)
                        Call laMsg.getString(CPstrSHIFTX_UNIT, .strShiftXUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrSHIFTY_ITEM_NAME, .strShiftYItemName)
                        Call laMsg.getString(CPstrSHIFTY_VALID_DIGIT, .strShiftYValidDigit)
                        Call laMsg.getString(CPstrSHIFTY_UNIT, .strShiftYUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrWAFERMAGX_ITEM_NAME, .strWaferMagXItemName)
                        Call laMsg.getString(CPstrWAFERMAGX_VALID_DIGIT, .strWaferMagXValidDigit)
                        Call laMsg.getString(CPstrWAFERMAGX_UNIT, .strWaferMagXUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrWAFERMAGY_ITEM_NAME, .strWaferMagYItemName)
                        Call laMsg.getString(CPstrWAFERMAGY_VALID_DIGIT, .strWaferMagYValidDigit)
                        Call laMsg.getString(CPstrWAFERMAGY_UNIT, .strWaferMagYUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrWAFERROTX_ITEM_NAME, .strWaferRotXItemName)
                        Call laMsg.getString(CPstrWAFERROTX_VALID_DIGIT, .strWaferRotXValidDigit)
                        Call laMsg.getString(CPstrWAFERROTX_UNIT, .strWaferRotXUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrWAFERROTY_ITEM_NAME, .strWaferRotYItemName)
                        Call laMsg.getString(CPstrWAFERROTY_VALID_DIGIT, .strWaferRotYValidDigit)
                        Call laMsg.getString(CPstrWAFERROTY_UNIT, .strWaferRotYUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrSHOTROT_ITEM_NAME, .strShotRotItemName)
                        Call laMsg.getString(CPstrSHOTROT_VALID_DIGIT, .strShotRotValidDigit)
                        Call laMsg.getString(CPstrSHOTROT_UNIT, .strShotRotUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrSHOTMAG_ITEM_NAME, .strShotMagItemName)
                        Call laMsg.getString(CPstrSHOTMAG_VALID_DIGIT, .strShotMagValidDigit)
                        Call laMsg.getString(CPstrSHOTMAG_UNIT, .strShotMagUnit)
                        'Shot分離
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrSHOTROTX_ITEM_NAME, .strShotRotXItemName)
                        Call laMsg.getString(CPstrSHOTROTX_VALID_DIGIT, .strShotRotXValidDigit)
                        Call laMsg.getString(CPstrSHOTROTX_UNIT, .strShotRotXUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrSHOTROTY_ITEM_NAME, .strShotRotYItemName)
                        Call laMsg.getString(CPstrSHOTROTY_VALID_DIGIT, .strShotRotYValidDigit)
                        Call laMsg.getString(CPstrSHOTROTY_UNIT, .strShotRotYUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrSHOTMAGX_ITEM_NAME, .strShotMagXItemName)
                        Call laMsg.getString(CPstrSHOTMAGX_VALID_DIGIT, .strShotMagXValidDigit)
                        Call laMsg.getString(CPstrSHOTMAGX_UNIT, .strShotMagXUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrSHOTMAGY_ITEM_NAME, .strShotMagYItemName)
                        Call laMsg.getString(CPstrSHOTMAGY_VALID_DIGIT, .strShotMagYValidDigit)
                        Call laMsg.getString(CPstrSHOTMAGY_UNIT, .strShotMagYUnit)

                        '@ﾊﾟｯﾁ分割ﾌﾗｸﾞ(RECIPEに登録されているPATCH_DIVIDE_NUM)
                        Call laMsg.getString(CPstrPATCH_DIVIDE_NUM, .strPatchDivideNumRecipe)       'ﾊﾟｯﾁ分割数
                        '@ﾊﾟｯﾁ分割数取得(PHOTO_FB_DATAに登録されているPATCH_DIVIDE_NUM)
                        If llngPatchNum = vbNullString Then
                            llngPatchNum = 0
                        End If
                        .lngPatchDivideNum = CStr(llngPatchNum)
                        Call laMsg.getString(CPstrSHOT_SEPARATE_FLAG, .strShotSeparateFlag)
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnPhotoFbDataList_Sel = True
                                            
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypPhotoFbDataListReq.strMsgVer)
                    
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

    '関数名：pubblnPhotoFbDataChg_Upd
    '機　能：ﾌｫﾄF/Bﾃﾞｰﾀ変更
    '引　数：ptypPhotoFbDataChgReq：要求格納構造体
    '戻り値：True：正常、False：異常
    '作成日：2006/03/02 (Thu) 16:45:05 N.Kasai
    '更新日：2017/01/25 (Wed) 15:37:25 T.Oide
    '備　考：
    '　　　：2006/04/04 (Tue) 15:45:56 N.Kasai      要求ﾀｸﾞ追加（RECIPE_ID)
    '　　　：2007/08/31 (Fri) 13:36:01 N.Kasai      要求、応答ﾀﾌﾞ変更（№02129）
    '　　　：2007/10/15 (Mon) 19:55:03 N.Kasai      №02228
    Public Function pubblnPhotoFbDataChg_Upd(ByRef ptypPhotoFbDataChgReq As PhotoFbDataChgReq) As Boolean

        Dim lrMsg                   As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg                   As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET                 As String           '応答取得
        Dim lstrPatchString         As String           'patchNoに応じて「_N」を格納
        Dim llngCnt                 As Integer
        Dim lstrTmpShiftX           As String
        Dim lstrTmpShiftY           As String
        Dim lstrTmpWaferMagX        As String
        Dim lstrTmpWaferMagY        As String
        Dim lstrTmpWaferRotX        As String
        Dim lstrTmpWaferRotY        As String
        Dim lstrTmpShotRot          As String
        Dim lstrTmpShotMag          As String
        Dim lstrTmpShotRotX          As String
        Dim lstrTmpShotRotY          As String
        Dim lstrTmpShotMagX          As String
        Dim lstrTmpShotMagY          As String

        Try
            
            pstrMessageName = "フォトF/Bデータ変更"
            
            '@戻り値初期化
            pubblnPhotoFbDataChg_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ptypPhotoFbDataChgReq
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
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                
                '@ﾚｼﾋﾟID
                If .strRecipeId <> vbNullString Then
                    Call lrMsg.addString(CPstrRECIPE_ID, .strRecipeId)
                Else
                    Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
                End If

                '@1stﾌｫﾄ号機WPID
                If .strReferencePhotoWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrREFERENCE_PHOTO_WP_ID, .strReferencePhotoWpID)
                Else
                    Call lrMsg.addString(CPstrREFERENCE_PHOTO_WP_ID, CPstrMsgNull)
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
                '@更新日時（排他用）
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
                                
                '@'ﾊﾟｯﾁ分割数
                If IsNumeric(.lngPatchDivideNum) = True Then
                    Call lrMsg.addString(CPstrPATCH_NUM, .lngPatchDivideNum)
                Else
                    Call lrMsg.addString(CPstrPATCH_NUM, CPstrMsgNull)
                End If
                                
                '@ﾊﾟﾗﾒｰﾀ1～9を設定
                For llngCnt = 1 To .lngPatchDivideNum
                
                    '@カウントで分岐
                    Select Case llngCnt
                    
                        Case CPlngPatchNo1
                            lstrTmpShiftX = .strShiftX
                            lstrTmpShiftY = .strShiftY
                            lstrTmpWaferMagX = .strWaferMagX
                            lstrTmpWaferMagY = .strWaferMagY
                            lstrTmpWaferRotX = .strWaferRotX
                            lstrTmpWaferRotY = .strWaferRotY
                            lstrTmpShotRot = .strShotRot
                            lstrTmpShotMag = .strShotMag
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX
                            lstrTmpShotRotY = .strShotRotY
                            lstrTmpShotMagX = .strShotMagX
                            lstrTmpShotMagY = .strShotMagY
                
                        Case CPlngPatchNo2
                            lstrTmpShiftX = .strShiftX_2
                            lstrTmpShiftY = .strShiftY_2
                            lstrTmpWaferMagX = .strWaferMagX_2
                            lstrTmpWaferMagY = .strWaferMagY_2
                            lstrTmpWaferRotX = .strWaferRotX_2
                            lstrTmpWaferRotY = .strWaferRotY_2
                            lstrTmpShotRot = .strShotRot_2
                            lstrTmpShotMag = .strShotMag_2
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX_2
                            lstrTmpShotRotY = .strShotRotY_2
                            lstrTmpShotMagX = .strShotMagX_2
                            lstrTmpShotMagY = .strShotMagY_2
                            
                        Case CPlngPatchNo3
                            lstrTmpShiftX = .strShiftX_3
                            lstrTmpShiftY = .strShiftY_3
                            lstrTmpWaferMagX = .strWaferMagX_3
                            lstrTmpWaferMagY = .strWaferMagY_3
                            lstrTmpWaferRotX = .strWaferRotX_3
                            lstrTmpWaferRotY = .strWaferRotY_3
                            lstrTmpShotRot = .strShotRot_3
                            lstrTmpShotMag = .strShotMag_3
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX_3
                            lstrTmpShotRotY = .strShotRotY_3
                            lstrTmpShotMagX = .strShotMagX_3
                            lstrTmpShotMagY = .strShotMagY_3
                            
                        Case CPlngPatchNo4
                            lstrTmpShiftX = .strShiftX_4
                            lstrTmpShiftY = .strShiftY_4
                            lstrTmpWaferMagX = .strWaferMagX_4
                            lstrTmpWaferMagY = .strWaferMagY_4
                            lstrTmpWaferRotX = .strWaferRotX_4
                            lstrTmpWaferRotY = .strWaferRotY_4
                            lstrTmpShotRot = .strShotRot_4
                            lstrTmpShotMag = .strShotMag_4
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX_4
                            lstrTmpShotRotY = .strShotRotY_4
                            lstrTmpShotMagX = .strShotMagX_4
                            lstrTmpShotMagY = .strShotMagY_4
                            
                        Case CPlngPatchNo5
                            lstrTmpShiftX = .strShiftX_5
                            lstrTmpShiftY = .strShiftY_5
                            lstrTmpWaferMagX = .strWaferMagX_5
                            lstrTmpWaferMagY = .strWaferMagY_5
                            lstrTmpWaferRotX = .strWaferRotX_5
                            lstrTmpWaferRotY = .strWaferRotY_5
                            lstrTmpShotRot = .strShotRot_5
                            lstrTmpShotMag = .strShotMag_5
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX_5
                            lstrTmpShotRotY = .strShotRotY_5
                            lstrTmpShotMagX = .strShotMagX_5
                            lstrTmpShotMagY = .strShotMagY_5
                            
                        Case CPlngPatchNo6
                            lstrTmpShiftX = .strShiftX_6
                            lstrTmpShiftY = .strShiftY_6
                            lstrTmpWaferMagX = .strWaferMagX_6
                            lstrTmpWaferMagY = .strWaferMagY_6
                            lstrTmpWaferRotX = .strWaferRotX_6
                            lstrTmpWaferRotY = .strWaferRotY_6
                            lstrTmpShotRot = .strShotRot_6
                            lstrTmpShotMag = .strShotMag_6
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX_6
                            lstrTmpShotRotY = .strShotRotY_6
                            lstrTmpShotMagX = .strShotMagX_6
                            lstrTmpShotMagY = .strShotMagY_6
                            
                        Case CPlngPatchNo7
                            lstrTmpShiftX = .strShiftX_7
                            lstrTmpShiftY = .strShiftY_7
                            lstrTmpWaferMagX = .strWaferMagX_7
                            lstrTmpWaferMagY = .strWaferMagY_7
                            lstrTmpWaferRotX = .strWaferRotX_7
                            lstrTmpWaferRotY = .strWaferRotY_7
                            lstrTmpShotRot = .strShotRot_7
                            lstrTmpShotMag = .strShotMag_7
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX_7
                            lstrTmpShotRotY = .strShotRotY_7
                            lstrTmpShotMagX = .strShotMagX_7
                            lstrTmpShotMagY = .strShotMagY_7
                            
                        Case CPlngPatchNo8
                            lstrTmpShiftX = .strShiftX_8
                            lstrTmpShiftY = .strShiftY_8
                            lstrTmpWaferMagX = .strWaferMagX_8
                            lstrTmpWaferMagY = .strWaferMagY_8
                            lstrTmpWaferRotX = .strWaferRotX_8
                            lstrTmpWaferRotY = .strWaferRotY_8
                            lstrTmpShotRot = .strShotRot_8
                            lstrTmpShotMag = .strShotMag_8
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX_8
                            lstrTmpShotRotY = .strShotRotY_8
                            lstrTmpShotMagX = .strShotMagX_8
                            lstrTmpShotMagY = .strShotMagY_8
                            
                        Case CPlngPatchNo9
                            lstrTmpShiftX = .strShiftX_9
                            lstrTmpShiftY = .strShiftY_9
                            lstrTmpWaferMagX = .strWaferMagX_9
                            lstrTmpWaferMagY = .strWaferMagY_9
                            lstrTmpWaferRotX = .strWaferRotX_9
                            lstrTmpWaferRotY = .strWaferRotY_9
                            lstrTmpShotRot = .strShotRot_9
                            lstrTmpShotMag = .strShotMag_9
                            'Shot分離
                            lstrTmpShotRotX = .strShotRotX_9
                            lstrTmpShotRotY = .strShotRotY_9
                            lstrTmpShotMagX = .strShotMagX_9
                            lstrTmpShotMagY = .strShotMagY_9
                    End Select
                    
                    '@1回目のﾙｰﾌﾟか
                    If llngCnt <> 1 Then
                        '@ﾊﾟﾗﾒｰﾀの末尾の文字を設定
                        lstrPatchString = "_" & llngCnt
                    Else
                        '@ﾊﾟﾗﾒｰﾀ末尾の文字はなし
                        lstrPatchString = vbNullString
                    End If
                
                    '@FBﾊﾟﾗﾒｰﾀ
                    If lstrTmpShiftX <> vbNullString Then
                        Call lrMsg.addString(CPstrSHIFTX & lstrPatchString, lstrTmpShiftX)
                    Else
                        Call lrMsg.addString(CPstrSHIFTX & lstrPatchString, CPstrMsgNull)
                    End If
                    '@FBﾊﾟﾗﾒｰﾀ
                    If lstrTmpShiftY <> vbNullString Then
                        Call lrMsg.addString(CPstrSHIFTY & lstrPatchString, lstrTmpShiftY)
                    Else
                        Call lrMsg.addString(CPstrSHIFTY & lstrPatchString, CPstrMsgNull)
                    End If
                    '@FBﾊﾟﾗﾒｰﾀ
                    If lstrTmpWaferMagX <> vbNullString Then
                        Call lrMsg.addString(CPstrWAFERMAGX & lstrPatchString, lstrTmpWaferMagX)
                    Else
                        Call lrMsg.addString(CPstrWAFERMAGX & lstrPatchString, CPstrMsgNull)
                    End If
                    '@FBﾊﾟﾗﾒｰﾀ
                    If lstrTmpWaferMagY <> vbNullString Then
                        Call lrMsg.addString(CPstrWAFERMAGY & lstrPatchString, lstrTmpWaferMagY)
                    Else
                        Call lrMsg.addString(CPstrWAFERMAGY & lstrPatchString, CPstrMsgNull)
                    End If
                    '@FBﾊﾟﾗﾒｰﾀ
                    If lstrTmpWaferRotX <> vbNullString Then
                        Call lrMsg.addString(CPstrWAFERROTX & lstrPatchString, lstrTmpWaferRotX)
                    Else
                        Call lrMsg.addString(CPstrWAFERROTX & lstrPatchString, CPstrMsgNull)
                    End If
                    '@FBﾊﾟﾗﾒｰﾀ
                    If lstrTmpWaferRotY <> vbNullString Then
                        Call lrMsg.addString(CPstrWAFERROTY & lstrPatchString, lstrTmpWaferRotY)
                    Else
                        Call lrMsg.addString(CPstrWAFERROTY & lstrPatchString, CPstrMsgNull)
                    End If
                    '@FBﾊﾟﾗﾒｰﾀ
                    If lstrTmpShotRot <> vbNullString Then
                        Call lrMsg.addString(CPstrSHOTROT & lstrPatchString, lstrTmpShotRot)
                    Else
                        Call lrMsg.addString(CPstrSHOTROT & lstrPatchString, CPstrMsgNull)
                    End If
                    '@FBﾊﾟﾗﾒｰﾀ
                    If lstrTmpShotMag <> vbNullString Then
                        Call lrMsg.addString(CPstrSHOTMAG & lstrPatchString, lstrTmpShotMag)
                    Else
                        Call lrMsg.addString(CPstrSHOTMAG & lstrPatchString, CPstrMsgNull)
                    End If

                    'Shot分離
                    If lstrTmpShotRotX <> vbNullString Then
                        Call lrMsg.addString(CPstrSHOTROTX & lstrPatchString, lstrTmpShotRotX)
                    Else
                        Call lrMsg.addString(CPstrSHOTROTX & lstrPatchString, CPstrMsgNull)
                    End If

                    If lstrTmpShotRotY <> vbNullString Then
                        Call lrMsg.addString(CPstrSHOTROTY & lstrPatchString, lstrTmpShotRotY)
                    Else
                        Call lrMsg.addString(CPstrSHOTROTY & lstrPatchString, CPstrMsgNull)
                    End If

                    If lstrTmpShotMagX <> vbNullString Then
                        Call lrMsg.addString(CPstrSHOTMAGX & lstrPatchString, lstrTmpShotMagX)
                    Else
                        Call lrMsg.addString(CPstrSHOTMAGX & lstrPatchString, CPstrMsgNull)
                    End If
                    
                    If lstrTmpShotMagY <> vbNullString Then
                        Call lrMsg.addString(CPstrSHOTMAGY & lstrPatchString, lstrTmpShotMagY)
                    Else
                        Call lrMsg.addString(CPstrSHOTMAGY & lstrPatchString, CPstrMsgNull)
                    End If

                Next
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__photofbdatachg, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@応答なし
                        
                        '@関数の処理結果(成功)格納
                        pubblnPhotoFbDataChg_Upd = True
                        
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

    '関数名：pubblnPhotoFbDataList2_Sel
    '機　能：ﾌｫﾄF/Bﾃﾞｰﾀ取得（露光ﾊﾟﾗﾒｰﾀ）
    '引　数：ltypPhotoFbDataList2Req：要求構造体
    '　　　：ltypPhotoFbDataList2Ans：応答構造体
    '戻り値：True：正常、False：異常
    '作成日：2007/09/14 (Fri) 09:24:27 N.Kasai
    '更新日：2007/09/14 (Fri) 09:24:27
    '備　考：
    Public Function pubblnPhotoFbDataList2_Sel(ByRef ltypPhotoFbDataList2Req As PhotoFbDataList2Req, _
                                ByRef ltypPhotoFbDataList2Ans As PhotoFbDataList2Ans) As Boolean

        Dim lrMsg              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg1             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry1             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim ltMsg2             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry2             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET            As String           '応答取得
        Dim llngCnt1           As Integer          'ｶｳﾝﾄ用

        Try

            '@初期設定
            pstrMessageName = "フォトF/Bデータ取得(露光パラメータ)"
            '@戻り値の初期化
            pubblnPhotoFbDataList2_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            With ltypPhotoFbDataList2Req
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
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@ﾚｼﾋﾟID
                If .strRecipeId <> vbNullString Then
                    Call lrMsg.addString(CPstrRECIPE_ID, .strRecipeId)
                Else
                    Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__photofbdatalist2, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrFB_DATA_ITEM_LIST, laAry1)
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ1のｶｳﾝﾄ格納
                    ltypPhotoFbDataList2Ans.lngFbDataItemList2Cnt = laAry1.Count
                    
                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypPhotoFbDataList2Ans.lngFbDataItemList2Cnt > 0 Then
                        If IsNothing(ltypPhotoFbDataList2Ans.typFbDataItemList2) Then
                            ltypPhotoFbDataList2Ans.typFbDataItemList2 = New List(Of FbDataItemList2)
                        Else
                            ltypPhotoFbDataList2Ans.typFbDataItemList2.Clear()
                        End If
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ１から各Msg取得
                        llngCnt1 = 0
                        For Each ltMsg1 In laAry1
                            Dim typFbDataItemList2Tmp As New FbDataItemList2
                            '@受信結果取得
                            With typFbDataItemList2Tmp
                                '@F/Bﾊﾟﾗﾒｰﾀを取得
                                Call ltMsg1.getString(CPstrEXPOSURE_VALUE, .strExposureValue)                       'F/Bﾊﾟﾗﾒｰﾀ
                                Call ltMsg1.getString(CPstrEXPOSURE_LOWER_LIMIT_VALUE, .strExposureLowerLimitValue) 'F/Bﾊﾟﾗﾒｰﾀ
                                Call ltMsg1.getString(CPstrEXPOSURE_UPPER_LIMIT_VALUE, .strExposureUpperLimitValue) 'F/Bﾊﾟﾗﾒｰﾀ
                                Call ltMsg1.getString(CPstrFOCUSOFFSET_VALUE, .strFocusOffsetValue)                 'F/Bﾊﾟﾗﾒｰﾀ
                                Call ltMsg1.getString(CPstrEMP_NAME, .strEmpName)                                   '最終更新者
                                Call ltMsg1.getString(CPstrENTRY_TIME, .strEntryTime)                               '最終更新日時
                                Call ltMsg1.getString(CPstrCOMMENTS, .strComments)                                  'ｺﾒﾝﾄ
                            End With

                            ltypPhotoFbDataList2Ans.typFbDataItemList2.Add(typFbDataItemList2Tmp)

                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt1 = llngCnt1 + 1
                        Next
                    End If
                    
                    With ltypPhotoFbDataList2Ans
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrEXPOSURE_ITEM_NAME, .strExposureItemName)
                        Call laMsg.getString(CPstrEXPOSURE_VALID_DIGIT, .strExposureValidDigit)
                        Call laMsg.getString(CPstrEXPOSURE_UNIT, .strExposureUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrEXPOSURE_LOWER_LIMIT_ITEM_NAME, .strExposureLowerLimitItemName)
                        Call laMsg.getString(CPstrEXPOSURE_LOWER_LIMIT_VALID_DIGIT, .strExposureLowerLimitValidDigit)
                        Call laMsg.getString(CPstrEXPOSURE_LOWER_LIMIT_UNIT, .strExposureLowerLimitUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrEXPOSURE_UPPER_LIMIT_ITEM_NAME, .strExposureUpperLimitItemName)
                        Call laMsg.getString(CPstrEXPOSURE_UPPER_LIMIT_VALID_DIGIT, .strExposureUpperLimitValidDigit)
                        Call laMsg.getString(CPstrEXPOSURE_UPPER_LIMIT_UNIT, .strExposureUpperLimitUnit)
                        '@ﾊﾟﾗﾒｰﾀ見出し取得
                        Call laMsg.getString(CPstrFOCUSOFFSET_ITEM_NAME, .strFocusOffsetItemName)
                        Call laMsg.getString(CPstrFOCUSOFFSET_VALID_DIGIT, .strFocusOffsetValidDigit)
                        Call laMsg.getString(CPstrFOCUSOFFSET_UNIT, .strFocusOffsetUnit)
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnPhotoFbDataList2_Sel = True
                                            
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypPhotoFbDataList2Req.strMsgVer)
                    
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

    '関数名：pubblnPhotoFbDataChg2_Upd
    '機　能：ﾌｫﾄF/Bﾃﾞｰﾀ変更（露光ﾊﾟﾗﾒｰﾀ）
    '引　数：ltypPhotoFbDataChg2Req：要求
    '戻り値：True：正常、False：異常
    '作成日：2007/09/14 (Fri) 11:26:25 N.Kasai
    '更新日：2007/10/15 (Mon) 19:55:59 N.Kasai
    '備　考：
    '　　　：2007/10/15 (Mon) 19:55:59 N.Kasai  №02228
    Public Function pubblnPhotoFbDataChg2_Upd(ByRef ltypPhotoFbDataChg2Req As PhotoFbDataChg2Req) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String           '応答取得
         
        Try
            
            pstrMessageName = "フォトF/Bデータ変更(露光パラメータ)"
            
            '@戻り値初期化
            pubblnPhotoFbDataChg2_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypPhotoFbDataChg2Req
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
                '@WPID
                If .strWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrWP_ID, .strWpID)
                Else
                    Call lrMsg.addString(CPstrWP_ID, CPstrMsgNull)
                End If
                '@ﾚｼﾋﾟID
                If .strRecipeId <> vbNullString Then
                    Call lrMsg.addString(CPstrRECIPE_ID, .strRecipeId)
                Else
                    Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
                End If
                '@F/Bﾊﾟﾗﾒｰﾀ（EXPOSURE）計算値
                If .strExposureValue <> vbNullString Then
                    Call lrMsg.addString(CPstrEXPOSURE_VALUE, .strExposureValue)
                Else
                    Call lrMsg.addString(CPstrEXPOSURE_VALUE, CPstrMsgNull)
                End If
                '@F/Bﾊﾟﾗﾒｰﾀ（EXPOSURE_LOWER_LIMIT）計算値
                If .strExposureLowerLimitValue <> vbNullString Then
                    Call lrMsg.addString(CPstrEXPOSURE_LOWER_LIMIT_VALUE, .strExposureLowerLimitValue)
                Else
                    Call lrMsg.addString(CPstrEXPOSURE_LOWER_LIMIT_VALUE, CPstrMsgNull)
                End If
                '@F/Bﾊﾟﾗﾒｰﾀ（EXPOSURE_UPPER_LIMIT）計算値
                If .strExposureUpperLimitValue <> vbNullString Then
                    Call lrMsg.addString(CPstrEXPOSURE_UPPER_LIMIT_VALUE, .strExposureUpperLimitValue)
                Else
                    Call lrMsg.addString(CPstrEXPOSURE_UPPER_LIMIT_VALUE, CPstrMsgNull)
                End If
                '@F/Bﾊﾟﾗﾒｰﾀ（FOCUSOFFSET）計算値
                If .strFocusOffsetValue <> vbNullString Then
                    Call lrMsg.addString(CPstrFOCUSOFFSET_VALUE, .strFocusOffsetValue)
                Else
                    Call lrMsg.addString(CPstrFOCUSOFFSET_VALUE, CPstrMsgNull)
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
                '@更新日時（排他用）
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
                
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstreq__photofbdatachg2, lrMsg, laMsg)
            
                '@受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
                    '@成功の場合(true)
                    Case CPstrTRUE
                        '@応答なし
                        
                        '@関数の処理結果(成功)格納
                        pubblnPhotoFbDataChg2_Upd = True
                        
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

    '関数名：pubblnEqtypeRecplist__Sel
    '機　能：装置ﾀｲﾌﾟ別ﾚｼﾋﾟﾘｽﾄ取得
    '引　数：streq__eqtypeRecplistVer	：ﾒｯｾｰｼﾞVer
    '　　　：typEqTypeRecpList			：応答構造体
	'　　　：strEqType					：装置ﾀｲﾌﾟ
	'　　　：strRecip					：ﾚｼﾋﾟ絞込み条件
    '戻り値：True：正常、False：異常
    '作成日：2024/02/16 (Fri) 09:14:27 T.Oide
    '更新日：2024/02/16 (Fri) 09:14:27
    '備　考：
	Public Function pubblnEqtypeRecplist__Sel(ByVal	streq__eqtypeRecplistVer As String, _
											  ByVal strEqType As String, ByVal strRecip As String, _
											  ByRef typEqTypeRecpList As List(Of eqtyperecplist))

        Dim lrMsg              As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg              As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim ltMsg1             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry1             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim ltMsg2             As TfMsg            '受信ﾒｯｾｰｼﾞ(temp）
        Dim laAry2             As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｲ(ｱﾝｻｰ）
        Dim lstrRET            As String = vbNullString          '応答取得

		'戻り値の初期化
		pubblnEqtypeRecplist__Sel = false
		pstrMessageName = "装置ﾀｲﾌﾟ別ﾚｼﾋﾟﾘｽﾄ取得"

        Try
			'結果格納用構造体初期化
			If IsNothing(typEqTypeRecpList) Then
                typEqTypeRecpList = New List(Of eqtyperecplist)
            Else
                typEqTypeRecpList.Clear()
            End If
			
			'ﾒｯｾｰｼﾞｵﾌﾞｼﾞｪｸﾄ初期化
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry

            '送信ﾒｯｾｰｼﾞﾃﾞｰﾀ部の作成
            'Msgﾊﾞｰｼﾞｮﾝ
            If streq__eqtypeRecplistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, streq__eqtypeRecplistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
				
			'Eqﾀｲﾌﾟ
            If strEqType <> vbNullString Then
                Call lrMsg.addString(CPstrEQ_TYPE, strEqType)
            Else
                Call lrMsg.addString(CPstrEQ_TYPE, CPstrMsgNull)
            End If

            'ﾚｼﾋﾟ
            If strRecip <> vbNullString Then
                Call lrMsg.addString(CPstrRECIPE_ID, strRecip)
            Else
                Call lrMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
            End If
            
            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstreq__eqtyperecplist, lrMsg, laMsg)

            '受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '結果判定
            Select Case lstrRET

                '成功の場合(true)
                Case CPstrTRUE

                    '受信ﾒｯｾｰｼﾞｱﾚｲ1取得
                    Call laMsg.getMsgAry(CPstrRECIPE_LIST, laAry1)
                    
                    '受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If laAry1.Count > 0 Then
						
                        '受信ﾒｯｾｰｼﾞｱﾚｲ１から各Msg取得
                        For Each ltMsg1 In laAry1
							
							'@受信結果取得
							Dim tmpEqTypeRecpList = New eqtyperecplist
							tmpEqTypeRecpList.typWpList = New List(Of typWp)

							With tmpEqTypeRecpList

                                'ﾚｼﾋﾟと装置List取得
                                Call ltMsg1.getString(CPstrRECIPE_ID, .strRecipeID)	'ﾚｼﾋﾟID
								Call ltMsg1.getMsgAry(CPstrWP_LIST, laAry2)

								'装置のAry取出
								For Each ltMsg2 In laAry2
									Dim tmpWp = New typWp
									With tmpWp
										Call ltMsg2.getString(CPstrWP_ID, .strWpId)		'WP_ID
										Call ltMsg2.getString(CPstrWP_NAME, .strWpName)	'WP_NAME
									End With
									.typWpList.Add(tmpWp)
								Next
                                
                            End With

                            typEqTypeRecpList.Add(tmpEqTypeRecpList)
							
                        Next
                    End If
                    
                    '関数の処理結果(成功)格納
                    pubblnEqtypeRecplist__Sel = True

					Exit Function
                                            
                '失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, streq__eqtypeRecplistVer)
                    
                'その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else

                    '「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)

            End Select
            
			'ﾒｯｾｰｼﾞｵﾌﾞｼﾞｪｸﾄ破棄
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing

            Exit Function

        '例外処理
        Catch ex As Exception

            'ｴﾗｰ表示
            Call pubErrMsg_Proc(Err)
            
			'ﾒｯｾｰｼﾞｵﾌﾞｼﾞｪｸﾄ破棄
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing

        End Try

    End Function

    '関数名：pubblnPhotoParaCopy
    '機　能：ﾊﾟﾗﾒｰﾀｺﾋﾟｰ実行
    '引　数：typRecpParaCopy	：ｺﾋﾟｰﾚｼﾋﾟ情報が格納されている
	'      ：strMsgVer			：ﾒｯｾｰｼﾞVer
    '戻り値：True：正常、False：異常
    '作成日：2024/02/21 (Wed) 17:14:25 T.Oide
    '更新日：2024/02/21 (Wed) 17:14:25
    '備　考：
    Public Function pubblnPhotoParaCopy( _
						ByRef typRecpParaCopy As photofbdatacopy _
					) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
        Dim lstrRET             As String = Nothing	'応答取得
		Dim lrTmpMsg			As TfMsg
		Dim lrTmpMsgAry			As TfMsgAry
     
		
        '戻り値初期化、機能名設定
        pubblnPhotoParaCopy = False
		pstrMessageName = "フォトF/Bデータ変更(パラメータコピー)"

        Try    
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With typRecpParaCopy

                'Msgﾊﾞｰｼﾞｮﾝ
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

				'登録者
                If .strEmpId <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpId)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If

				lrTmpMsg = New TfMsg
				lrTmpMsgAry	= New TfMsgAry

				'ﾚｼﾋﾟ数繰返し
				For lintCnt = 0 To .typRecpList.Count - 1

					'ｺﾋﾟｰ元ﾚｼﾋﾟID
					If .typRecpList(lintCnt).strMotoRecipeID <> vbNullString Then
						Call lrTmpMsg.addString(CPstrRECIPE_ID, .typRecpList(lintCnt).strMotoRecipeID)
					Else
						Call lrTmpMsg.addString(CPstrRECIPE_ID, CPstrMsgNull)
					End If
					
					'ｺﾋﾟｰ先ﾚｼﾋﾟID
					If .typRecpList(lintCnt).strSakiRecipeID <> vbNullString Then
						Call lrTmpMsg.addString(CPstrCOPY_RECIPE_ID, .typRecpList(lintCnt).strSakiRecipeID)
					Else
						Call lrTmpMsg.addString(CPstrCOPY_RECIPE_ID, CPstrMsgNull)
					End If

					'ｺﾋﾟｰ先装置ﾘｽﾄ
					If .typRecpList(lintCnt).strWpList <> vbNullString Then
						Call lrTmpMsg.addString(CPstrWP_LIST, .typRecpList(lintCnt).strWpList)
					Else
						Call lrTmpMsg.addString(CPstrWP_LIST, CPstrMsgNull)
					End If

					lrTmpMsgAry.add(lrTmpMsg)
					lrTmpMsg.clear
				Next

                lrMsg.addMsgAry(CPstrRECIPE_LIST, lrTmpMsgAry)
				lrTmpMsgAry.clear

                'ﾒｯｾｰｼﾞ送信(ﾌｫﾄFBﾃﾞｰﾀｺﾋﾟｰ)
                Call pTerm.sendRequest(CPstreq__photofbdatacopy, lrMsg, laMsg)
            
                '受信結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '結果判定
                Select Case lstrRET

                    '成功の場合(true)
                    Case CPstrTRUE
                        '応答なし
                        
                        '関数の処理結果(成功)格納
                        pubblnPhotoParaCopy = True
                        
                    '@失敗の場合(false)
                    Case CPstrFALSE
                    
                        'ﾊﾞｰｼﾞｮﾝ判定
                        Call pubstrErrMsg_Set(laMsg, .strMsgVer)
                        
                    '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                    Case Else
                        '表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
                End Select
            
            End With

            lrMsg = Nothing
            laMsg = Nothing
            lrTmpMsg = Nothing
			lrTmpMsgAry	= Nothing

            Exit Function
            
        '例外処理
        Catch ex As Exception

            lrMsg = Nothing
            laMsg = Nothing
			lrTmpMsg = Nothing
			lrTmpMsgAry	= Nothing
            
            '表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try

    End Function


End Module
