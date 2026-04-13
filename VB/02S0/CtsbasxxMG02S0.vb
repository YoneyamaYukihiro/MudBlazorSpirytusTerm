'ﾌｧｲﾙ名：xxMG02S0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：Aトレー管理　通信メッセージ用 標準モジュール
'作成日：2018/10/02 (Tue) 17:39:19 T.Oide
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2018-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG02S0
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

    '関数名：pubblnAtrayList_Sel
    '機　能：Aﾄﾚｰ一覧取得
    '引　数：lstrAtraylistVer：ﾒｯｾｰｼﾞVer
    '　　　：ltypAtrayList：Aﾄﾚｰﾘｽﾄ格納用(結果)
    '　　　：lstrAtrayClass()：Aﾄﾚｰ区分(検索条件)
    '　　　：lstrTapeStickGr()：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ(検索条件)
    '　　　：lstrAtrayId：AﾄﾚｰID(検索条件)
    '戻り値：
    '作成日：2018/10/31 (Wed) 16:45:53 T.Oide
    '更新日：2018/10/31 (Wed) 16:45:53
    '備　考：
    Public Function pubblnAtrayList_Sel(ByVal lstrAtraylistVer As String, _
                                        ByRef ltypAtrayList As typeAtrayList, _
                                        ByRef lstrAtrayClassList As List(Of String), _
                                        ByRef lstrTapeStickGrList As List(Of String), _
                                        ByVal lstrAtrayId As String _
                                        ) As Boolean
                                        
        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim llngCnt1            As Integer

        Try
            
            pstrMessageName = "Aトレー一覧取得"
            
            '戻り値初期化
            pubblnAtrayList_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            laAry = New TfMsgAry
            
            '@MsgVer
            Call lrMsg.addString(CPstrMSG_VER, lstrAtraylistVer)
            
            '@Aﾄﾚｰ区分配列の要素1はvbNullString以外か
            'If lstrAtrayClass(1) <> vbNullString Thens            
            If Not IsNothing(lstrAtrayClassList(0)) then            
                '@Aﾄﾚｰｸﾗｽ
                For llngCnt1 = 0 To lstrAtrayClassList.Count - 1 
                    '@Aﾄﾚｰ区分
                    If lstrAtrayClassList(llngCnt1) <> vbNullString Then
                        Call ltMsg.addString(CPstrA_TRAY_CLASS, lstrAtrayClassList(llngCnt1))
                    Else
                        Call ltMsg.addString(CPstrA_TRAY_CLASS, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    Call ltMsg.Clear
                Next
            
            End If
            
            Call lrMsg.addMsgAry(CPstrA_TRAY_CLASS_LIST, lrAry)
            Call lrAry.Clear
            
            '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ配列の要素1はvbNullString以外か
            'If lstrTapeStickGr(1) <> vbNullString Then
            If Not isNothing(lstrTapeStickGrList(0)) then          
                '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                For llngCnt1 = 0 To lstrTapeStickGrList.Count - 1
                    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                    If lstrTapeStickGrList(llngCnt1) <> vbNullString Then
                        Call ltMsg.addString(CPstrTAPE_STICK_GROUP, lstrTapeStickGrList(llngCnt1))
                    Else
                        Call ltMsg.addString(CPstrTAPE_STICK_GROUP, CPstrMsgNull)
                    End If
                    
                    Call lrAry.Add(ltMsg)
                    Call ltMsg.Clear
                Next
            
            End If
            
            Call lrMsg.addMsgAry(CPstrTAPE_STICK_GROUP_LIST, lrAry)
            Call lrAry.Clear
            
            '@AﾄﾚｰID
            If lstrAtrayId <> vbNullString Then
                Call lrMsg.addString(CPstrA_TRAY_ID, lstrAtrayId)
            Else
                Call lrMsg.addString(CPstrA_TRAY_ID, CPstrMsgNull)
            End If

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrAtraylist, lrMsg, laMsg)
            
            '@ﾒｯｾｰｼﾞ受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '結果によって処理分岐
            Select Case lstrRET
            
                '@〓 0：TRUE(成功) 〓
                Case CPstrTRUE
                            
                    With ltypAtrayList
                    
                        '@ｱﾚｰを取得
                        Call laMsg.getMsgAry(CPstrA_TRAY_LIST, laAry)
                        
                        'ﾘｽﾄ件数は0以上か
                        If laAry.Count > 0 Then
                        
                            '配列準備
                            .lngAtraytListCnt = laAry.Count
                            'ReDim .typAtraytList(.lngAtraytListCnt)
                            If IsNothing(.typAtraytList) Then
                                .typAtraytList = New List(Of typeAtray)
                            Else
                                .typAtraytList.Clear()
                            End If                            

                            '@ｱﾚｰ内の各要素を変数に取得
                            llngCnt = 1
                            For Each ltMsg In laAry
                                Dim tmpTypeAtray As typeAtray
                                With tmpTypeAtray
                                
                                    Call ltMsg.getString(CPstrA_TRAY_ID, .strAtrayId)               'AトレーID
                                    Call ltMsg.getString(CPstrA_TRAY_STATUS, .strAtrayStatus)       'ステータス
                                    Call ltMsg.getString(CPstrA_TRAY_CLASS, .strAtrayClass)         'Aトレー区分
                                    Call ltMsg.getString(CPstrTAPE_STICK_GROUP, .strTapeStickGr)    'テープ貼りグループ
                                    Call ltMsg.getString(CPstrSTART_TIME, .strStartTime)            '使用開始日時
                                    Call ltMsg.getString(CPstrCLEAN_TIME, .strCleanTime)            '最終洗浄日時
                                    Call ltMsg.getString(CPstrWASH_USE_NUM, .strWashUseNum)         '洗浄後使用回数
                                    Call ltMsg.getString(CPstrWASH_USE_LIMIT, .strWashUseLimit)     '洗浄後使用回数上限
                                    Call ltMsg.getString(CPstrUSE_NUM, .strUseNum)                  '累積使用回数
                                    Call ltMsg.getString(CPstrUSE_LIMIT, .strUseLimit)              '累積使用回数上限
                                    Call ltMsg.getString(CPstrA_CARRIER_ID, .strACarrierId)         'AキャリアID
                                    Call ltMsg.getString(CPstrSLOT_POSITION, .strSlotPosition)      'スロットポジション
                                    Call ltMsg.getString(CPstrEMP_NAME, .strEmpName)                'ユーザ名
                                    Call ltMsg.getString(CPstrEDIT_TIME, .strEditTime)              '更新日時
                                    Call ltMsg.getString(CPstrCOMMENTS, .strComments)               'コメント
                                    
                                    llngCnt = llngCnt + 1
                                End With
                                .typAtraytList.add(tmpTypeAtray)
                            Next
                        
                        End If
                    
                    End With
                    
                    '@結果OK
                    pubblnAtrayList_Sel = True
                    
                '@〓 1：FALSE(失敗) 〓
                Case CPstrFALSE

                    '@=======================
                    '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                    '@=======================
                    Call pubstrErrMsg_Set(laMsg, lstrAtraylistVer)


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

    '関数名：pubblnAtrayRegist
    '機　能：Aﾄﾚｰ情報登録・更新
    '引　数：stratray_Regist__Ver：ﾒｯｾｰｼﾞVer
    '　　　：prvtypJycJigListReq：登録内容格納
    '戻り値：True:成功/Flase：失敗
    '作成日：2018/10/23 (Tue) 17:16:24 T.Oide
    '更新日：2018/10/23 (Tue) 17:16:24
    '備　考：
    Public Function pubblnAtrayRegist(ByVal stratray_Regist__Ver As String, _
                                      ByRef atrayRegist As typAtrayRegist) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ
        Dim lrMsg2              As TfMsg            '送信ﾒｯｾｰｼﾞ2
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer

        Try

            pstrMessageName = "Aﾄﾚｰ情報登録・更新"

            pubblnAtrayRegist = False

            lrMsg = New TfMsg
            lrMsg2 = New TfMsg
            laMsg = New TfMsg
            lrAry = New TfMsgAry

            With atrayRegist
            
                '@ﾒｯｾｰｼﾞVer設定
                Call lrMsg.addString(CPstrMSG_VER, stratray_Regist__Ver)
            
                '@ﾕｰｻﾞID設定
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
            
                '@CLASS_DIVISION
                If .strClassDiv <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDiv)
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If
            
                '登録・更新するAﾄﾚｰ情報の要素を設定
                For llngCnt = 0 To .lngAtraytListCnt - 1
            
                    With .typAtraytList(llngCnt)
            
                        '@AﾄﾚｰID
                        If .strAtrayId <> vbNullString Then
                            Call lrMsg2.addString(CPstrA_TRAY_ID, .strAtrayId)
                        Else
                            Call lrMsg2.addString(CPstrA_TRAY_ID, CPstrMsgNull)
                        End If
            
                        '@Aﾄﾚｰｸﾗｽ
                        If .strAtrayClass <> vbNullString Then
                            Call lrMsg2.addString(CPstrA_TRAY_CLASS, .strAtrayClass)
                        Else
                            Call lrMsg2.addString(CPstrA_TRAY_CLASS, CPstrMsgNull)
                        End If
            
                        '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                        If .strTapeStickGr <> vbNullString Then
                            Call lrMsg2.addString(CPstrTAPE_STICK_GROUP, .strTapeStickGr)
                        Else
                            Call lrMsg2.addString(CPstrTAPE_STICK_GROUP, CPstrMsgNull)
                        End If
            
                        '@洗浄後使用回数上限
                        If .strWashUseLimit <> vbNullString Then
                            Call lrMsg2.addString(CPstrWASH_USE_LIMIT, .strWashUseLimit)
                        Else
                            Call lrMsg2.addString(CPstrWASH_USE_LIMIT, CPstrMsgNull)
                        End If
            
                        '@累積使用回数上限
                        If .strUseLimit <> vbNullString Then
                            Call lrMsg2.addString(CPstrUSE_LIMIT, .strUseLimit)
                        Else
                            Call lrMsg2.addString(CPstrUSE_LIMIT, CPstrMsgNull)
                        End If
            
                        '@コメント
                        If .strComments <> vbNullString Then
                            Call lrMsg2.addString(CPstrCOMMENTS, .strComments)
                        Else
                            Call lrMsg2.addString(CPstrCOMMENTS, CPstrMsgNull)
                        End If
                        
                    End With
            
                    Call lrAry.Add(lrMsg2)
                    lrMsg2.Clear
            
                Next
            
                Call lrMsg.addMsgAry(CPstrA_TRAY_LIST, lrAry)
            
                '@ﾒｯｾｰｼﾞ送信
                Call pTerm.sendRequest(CPstrAtrayRegist, lrMsg, laMsg)
            
                '@結果取得
                Call laMsg.getString(CPstrRET, lstrRET)
            
                '@結果判定
                Select Case lstrRET
            
                    '@取得成功の場合
                    Case CPstrTRUE
                        pubblnAtrayRegist = True
            
                    '@取得失敗の場合
                    Case CPstrFALSE
                        '@=======================
                        '@　ｴﾗｰﾒｯｾｰｼﾞ表示処理
                        '@=======================
                         Call pubstrErrMsg_Set(laMsg, stratray_Regist__Ver)
            
                    '@その他
                    Case Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                        '@ﾒｯｾｰｼﾞ："<TRM01E>$$閉じるボタンを押してメニューを選択して下さい。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
                End Select

            End With

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
