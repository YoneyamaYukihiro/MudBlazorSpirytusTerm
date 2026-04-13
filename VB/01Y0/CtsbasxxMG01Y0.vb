'ﾌｧｲﾙ名：xxMG01Y0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：在庫スナップショット一覧 通信ﾒｯｾｰｼﾞ用標準ﾓｼﾞｭｰﾙ
'作成日：2006/07/24 (Mon) 16:25:35 N.Kojima
'更新日：2014/01/16 (Thu) 11:07:59 T.Oide
'備　考：
'　　　：一部、将来の"ATLAS"の文言を削除(変換)する対応用にｺﾒﾝﾄｱｳﾄしたｺｰﾄﾞがあります。
'　　　：2014/01/16 (Thu) 11:07:59 T.Oide       GNS対応(Bacchus→Gnsに変更したところは一括置換のため履歴なし)
'Copyright(C)SEIKO EPSON CORPORATION 2014. All rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG01Y0
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

    '関数名：pubblnLotCurPositionList_Sel
    '機　能：ｷｬﾘｱ位置取得
    '引　数：lstrlot_curpositionlistVer ：MsgVer
    '　　　：ltypCurrentPositionList()  ：ｷｬﾘｱ位置格納用配列
    '　　　：llngCurrentPositionListCnt ：ｷｬﾘｱ位置格納数
    '戻り値：True:成功/Flase：失敗
    '作成日：2006/09/05 (Tue) 17:08:47 N.Kojima
    '更新日：2006/09/05 (Tue) 17:08:47
    '備　考：
    Public Function pubblnLotCurPositionList_Sel(ByVal lstrlot_curpositionlistVer As String, _
                                                 ByRef ltypCurrentPositionList As List(of CurrentPositionList), _
                                                 ByRef llngCurrentPositionListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "ロット位置取得"
            pubblnLotCurPositionList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrlot_curpositionlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrlot_curpositionlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_curpositionlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrCURRENT_POSITION_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    llngCurrentPositionListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngCurrentPositionListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        ltypCurrentPositionList = New List(Of CurrentPositionList) 
                        
                        Dim ltypCurrentPositionListtmp As CurrentPositionList = New CurrentPositionList 

                        '@ｶｳﾝﾄ初期化
                        llngCnt = 0
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With ltypCurrentPositionListtmp
                                Call ltMsg.getString(CPstrCURRENT_POSITION_ID, .strCurrentPositionID)       'ｷｬﾘｱ位置ID
                                Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   'ｷｬﾘｱ位置名
                            End With
                            ltypCurrentPositionList.Add(ltypCurrentPositionListtmp)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnLotCurPositionList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrlot_curpositionlistVer)

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

    '関数名：pubblnAtlasPointList_Sel
    '機　能：ﾎﾟｲﾝﾄ一覧取得
    '引　数：lstratlspointlistVer   ：MsgVer
    '　　　：ltypPointList()        ：ﾎﾟｲﾝﾄ格納用配列
    '　　　：llngPointListCnt       ：ﾎﾟｲﾝﾄ格納数
    '戻り値：True:成功/Flase：失敗
    '作成日：2006/08/01 (Tue) 15:48:46 N.Kojima
    '更新日：2006/08/01 (Tue) 15:48:46
    '備　考：
    Public Function pubblnAtlasPointList_Sel(ByVal lstratlspointlistVer As String, _
                                        ByRef ltypPointList As List(of PointList), _
                                        ByRef llngPointListCnt As Integer) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "ポイント一覧取得"
            pubblnAtlasPointList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstratlspointlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstratlspointlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@SB_ID
            If pstrSBID <> vbNullString Then
                Call lrMsg.addString(CPstrSB_ID, pstrSBID)
            Else
                Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
            End If
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstratlspointlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrATLAS_POINT_LIST, laAry)
        '            Call laMsg.getMsgAry(CPstrPOINT_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    llngPointListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If llngPointListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        ltypPointList = New List(Of PointList) 
                        Dim ltypPointListtmp As PointList = New PointList 

                        '@ｶｳﾝﾄ初期化
                        llngCnt = 0
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With ltypPointListtmp
                                Call ltMsg.getString(CPstrATLAS_POINT, .strPoint)      'Atlasﾎﾟｲﾝﾄ
        '                        Call ltMsg.getString(CPstrPOINT, .strPoint)                 'ﾎﾟｲﾝﾄ
                            End With
                            ltypPointList.Add(ltypPointListtmp)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnAtlasPointList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstratlspointlistVer)

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

    '関数名：pubblnLotSnapShotList_Sel
    '機　能：在庫ｽﾅｯﾌﾟｼｮｯﾄ一覧取得
    '引　数：ltypSnapShotReqList    ：在庫ｽﾅｯﾌﾟｼｮｯﾄ一覧要求構造体
    '　　　：ltypSnapShotAnsList    ：在庫ｽﾅｯﾌﾟｼｮｯﾄ一覧応答構造体
    '戻り値：True:成功/Flase：失敗
    '作成日：2006/08/01 (Tue) 15:48:33 N.Kojima
    '更新日：2007/11/15 (Thu) 15:11:33 N.Kasai
    '備　考：
    '　　　：2006/09/28 (Thu) 16:44:04 N.Kojima     応答に"WF_LIST","ROW_NUM_LIST"追加。(案件№01517)
    '　　　：2007/11/15 (Thu) 15:11:33 N.Kasai      №02294
    '　　　：2008/02/27 (Tue) 12:50:00 S.Ochiai     応答にKETTEN_CHIP_QUANTITY追加(案件№02847)
    Public Function pubblnLotSnapShotList_Sel(ByRef ltypSnapShotReqList As SnapShotReqList, _
                                              ByRef ltypSnapShotAnsList As SnapShotAnsList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用2
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ2
        Dim llngCnt2            As Integer          'ｶｳﾝﾄ用2

        Try

            pstrMessageName = "在庫ｽﾅｯﾌﾟｼｮｯﾄ一覧取得"
            pubblnLotSnapShotList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laAry = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            
            With ltypSnapShotReqList
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
                
                '@検索日時
                If .strSearchDate <> vbNullString Then
                    Call lrMsg.addString(CPstrSEARCH_DATE, .strSearchDate)
                Else
                    Call lrMsg.addString(CPstrSEARCH_DATE, CPstrMsgNull)
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
                
                '@ｷｬﾘｱ位置(ID)
                If .strCurrentPositionID <> vbNullString Then
                    Call lrMsg.addString(CPstrCURRENT_POSITION_ID, .strCurrentPositionID)
                Else
                    Call lrMsg.addString(CPstrCURRENT_POSITION_ID, CPstrMsgNull)
                End If
                
                '@機種ﾘｽﾄ
                For llngCnt = 0 To .lngPdCnt-1
                    If .typPdList(llngCnt).strPdId <> vbNullString Then
                        Call ltMsg.addString(CPstrPD_ID, .typPdList(llngCnt).strPdId)
                    Else
                        Call ltMsg.addString(CPstrPD_ID, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt
                
                Call lrMsg.addMsgAry(CPstrPD_LIST, lrAry)
                lrAry.Clear
                
                '@種別ﾘｽﾄ
                For llngCnt = 0 To .lngFlowClassCnt-1
                    If .typFlowClassList(llngCnt).strFlowClass <> vbNullString Then
                        Call ltMsg.addString(CPstrFLOW_CLASS, .typFlowClassList(llngCnt).strFlowClass)
                    Else
                        Call ltMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt
                
                Call lrMsg.addMsgAry(CPstrFLOW_CLASS_LIST, lrAry)
                lrAry.Clear
                
        '@↓2014/01/16 (Thu) 19:45:27 T.Oide **************************************************
        '@        '@ﾎﾟｲﾝﾄﾘｽﾄ
        '@        For llngCnt = 1 To .lngPointCnt
        '@            If .typPointList(llngCnt).strPoint <> vbNullString Then
        '@                Call ltMsg.addString(CPstrATLAS_POINT, .typPointList(llngCnt).strPoint)
        '@            Else
        '@                Call ltMsg.addString(CPstrATLAS_POINT, CPstrMsgNull)
        '@            End If
        '@            Call lrAry.Add(ltMsg)
        '@            ltMsg.Clear
        '@        Next llngCnt
        '@
        '@        Call lrMsg.addMsgAry(CPstrATLAS_POINT_LIST, lrAry)
        '@
                '@実績報告ﾎﾟｲﾝﾄﾘｽﾄ
                For llngCnt = 0 To .lngPointCnt-1
                    If .typPointList(llngCnt).strPoint <> vbNullString Then
                        Call ltMsg.addString(CPstrPART_CODE, .typPointList(llngCnt).strPoint)
                    Else
                        Call ltMsg.addString(CPstrPART_CODE, CPstrMsgNull)
                    End If
                    Call lrAry.Add(ltMsg)
                    ltMsg.Clear
                Next llngCnt
                
                Call lrMsg.addMsgAry(CPstrPART_LIST, lrAry)
        '@↑2014/01/16 (Thu) 19:45:27 T.Oide **************************************************

                lrAry.Clear
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrlot_snapshotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrSNAPSHOT_LIST, laAry)
                    
                    With ltypSnapShotAnsList
                        
                        '@★★　SNAPSHOT_LIST ★★
                        '@ｱﾚｲｶｳﾝﾄ取得
                        .lngSnapShotListCnt = laAry.Count
            
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngSnapShotListCnt > 0 Then
                            '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            
                            '@配列の要素数を設定
                            .typSnapShotList = New List(Of SnapShotAns) 
                            Dim typSnapShotListtmp As SnapShotAns = New SnapShotAns 

                            '@ｶｳﾝﾄ初期化
                            llngCnt = 0
                            
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                With typSnapShotListtmp
                                    Call ltMsg.getString(CPstrPD_ID, .strPdId)                                  '機種
                                    Call ltMsg.getString(CPstrCURRENT_POSITION_NAME, .strCurrentPositionName)   'ｷｬﾘｱ位置
                                    Call ltMsg.getString(CPstrOP_ID, .strOpID)                                  '大工程
                                    Call ltMsg.getString(CPstrSTEP_ID, .strStepID)                              '小工程
                                    Call ltMsg.getString(CPstrGNS_WF_QUANTITY, .strGnsWFNum)                    'Gns報告WF枚数
                                    Call ltMsg.getString(CPstrGNS_CHIP_QUANTITY, .strGnsChipQuantity)           'Gns報告ﾁｯﾌﾟ数
                                    Call ltMsg.getString(CPstrWF_NUM, .strWfNum)                                'WF枚数
                                    Call ltMsg.getString(CPstrCHIP_QUANTITY, .strChipQuantity)                  '良品Chip数
                                    Call ltMsg.getString(CPstrFLOW_CLASS, .strFlowClass)                        '種別
                                    Call ltMsg.getString(CPstrLOT_ID, .strLotID)                                'ﾛｯﾄID
                                    Call ltMsg.getString(CPstrCARRIER_ID, .strCarrierId)                        'ｷｬﾘｱID
                                    Call ltMsg.getString(CPstrATLAS_ORDER_NO, .strMPROrder)                     '量産ｵｰﾀﾞｰ
                                    Call ltMsg.getString(CPstrPART_CODE, .strPartCode)                          '部品ｺｰﾄﾞ
                                    Call ltMsg.getString(CPstrATLAS_POINT, .strPoint)                           'ﾎﾟｲﾝﾄ
                                    Call ltMsg.getString(CPstrPR_ORDER_ID, .strPROrder)                         'PRｵｰﾀﾞｰ
                                    Call ltMsg.getString(CPstrCF_FLAG, .strCfFlag)                              'CFﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrLP_FLAG, .strLpFlag)                              '大判ﾌﾗｸﾞ
                                    Call ltMsg.getString(CPstrCHIP_OUT_QUANTITY, .strChipOutQuantity)           '不良Chip
                                    Call ltMsg.getString(CPstrCHIP_FORWARD_QUANTITY, .strChipForwardQuantity)   '払出Chip
                                    Call ltMsg.getString(CPstrCF_WF_NUM, .strCfWfNum)                           'WF枚数(対向)
                                    Call ltMsg.getString(CPstrCF_PART_CODE, .strCfPartCode)                     '部品コード(対向)

                                    '@★★　WF_LIST ★★
                                    Call ltMsg.getMsgAry(CPstrWF_LIST, laAry2)      'WFﾘｽﾄ

                                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                    .lngWfListCnt = laAry2.Count
                                    '@WFがあればﾃﾞｰﾀ格納
                                    If .lngWfListCnt > 0 Then
                                        '@構造体初期化
                                        .typWfList = New List(Of SnapWfList)
                                        Dim typWfListtmp As SnapWfList = New SnapWfList
                                        llngCnt2 = 0
                                        For Each ltMsg2 In laAry2
                                            '@受信結果取得
                                            With typWfListtmp
                                                Call ltMsg2.getString(CPstrWF_ID, .strWfId)                                 'WF_ID
                                                Call ltMsg2.getString(CPstrCHIP_GOOD_QUANTITY, .strChipGoodQuantity)        '良品ﾁｯﾌﾟ
                                                Call ltMsg2.getString(CPstrCHIP_OUT_QUANTITY, .strChipOutQuantity)          '不良ﾁｯﾌﾟ
                                                Call ltMsg2.getString(CPstrKETTEN_CHIP_QUANTITY, .strKettenChipQuantity)    '欠点チップ
                                                Call ltMsg2.getString(CPstrCHIP_FORWARD_QUANTITY, .strChipForwardQuantity)  '払出チップ
                                            End With
                                            .typWfList.Add(typWfListtmp)
                                            llngCnt2 = llngCnt2 + 1
                                        Next
                                    End If
                                End With
                                
                                .typSnapShotList.Add(typSnapShotListtmp)
                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnLotSnapShotList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypSnapShotReqList.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@「C_ERR0001　閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(CPstrMsgErr0001, vbExclamation, pstrMessageName, True, 16)
            End Select

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            lrAry = Nothing
            laAry = Nothing
            ltMsg2 = Nothing
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
            lrAry = Nothing
            laAry = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing

        End Try
    End Function

    '関数名：pubblnWfChipSnapShotList_Sel
    '機　能：星取表ﾏｯﾌﾟ情報取得
    '引　数：lstrwf__chipsnapshotlistVer    ：MsgVer
    '　　　：lstrLotID                      ：ﾛｯﾄID
    '　　　：lstrWFID                       ：WFID
    '　　　：lstrSearchDate                 ：検索日時
    '　　　：ltypWFMapInfo()                 ：ﾁｯﾌﾟｽﾅｯﾌﾟｼｮｯﾄ情報格納用配列
    '戻り値：True:成功/Flase：失敗
    '作成日：2006/10/04 (Wed) 18:38:58 N.Kojima
    '更新日：2006/10/04 (Wed) 18:38:58
    '備　考：
    Public Function pubblnWfChipSnapShotList_Sel(ByVal lstrwf__chipsnapshotlistVer As String, _
                                                 ByVal lstrLotID As String, _
                                                 ByVal lstrWFID As String, _
                                                 ByVal lstrSearchDate As String, _
                                                 ByRef ltypWFMapInfo As WFMapInfo) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "星取表取得"
            pubblnWfChipSnapShotList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成

            '@Msgﾊﾞｰｼﾞｮﾝ
            If lstrwf__chipsnapshotlistVer <> vbNullString Then
                Call lrMsg.addString(CPstrMSG_VER, lstrwf__chipsnapshotlistVer)
            Else
                Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
            End If
            
            '@SB_ID
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
            
            '@WFID
            If lstrWFID <> vbNullString Then
                Call lrMsg.addString(CPstrWF_ID, lstrWFID)
            Else
                Call lrMsg.addString(CPstrWF_ID, CPstrMsgNull)
            End If
            
            '@検索日時
            If lstrSearchDate <> vbNullString Then
                Call lrMsg.addString(CPstrSEARCH_DATE, lstrSearchDate)
            Else
                Call lrMsg.addString(CPstrSEARCH_DATE, CPstrMsgNull)
            End If
            
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrwf__chipsnapshotlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)


            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    
                    '@ｱﾚｰを格納
                    Call laMsg.getMsgAry(CPstrCHIP_LIST, laAry)

                    '@ｱﾚｲｶｳﾝﾄ取得
                    ltypWFMapInfo.lngListCnt = laAry.Count

                    '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                    If ltypWFMapInfo.lngListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                        
                        '@配列の要素数を設定
                        ltypWFMapInfo.typChipList = New List(Of ChipList) 
                        Dim typChipListtmp As ChipList = New ChipList 
                        
                        '@ｶｳﾝﾄ初期化
                        llngCnt = 0
                        
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            With typChipListtmp
                                Call ltMsg.getString(CPstrCHIP_ID, .strChipId)        'ﾁｯﾌﾟID
                                Call ltMsg.getString(CPstrCLASS, .strClass)          '区分
                                Call ltMsg.getString(CPstrCLASS_ID, .strClassID)     'ｸﾗｽID
                            End With
                            ltypWFMapInfo.typChipList.Add(typChipListtmp)
                            '@ｶｳﾝﾄｱｯﾌﾟ
                            llngCnt = llngCnt + 1
                        Next
                    End If

                    '@関数の処理結果(成功)格納
                    pubblnWfChipSnapShotList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, lstrwf__chipsnapshotlistVer)

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
End Module
