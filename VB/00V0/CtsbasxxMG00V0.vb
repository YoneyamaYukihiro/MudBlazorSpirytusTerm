'ﾌｧｲﾙ名：xxMG00V0.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：異常処理票表示　機能ﾒｯｾｰｼﾞ処理
'作成日：2004/08/25 (Wed) 11:33:44 S.Deguchi
'更新日：2007/02/20 (Tue) 09:22:31 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports TFLib
Public Module basxxMG00V0
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

    '関数名：pubblnExcpApply_Ins
    '機　能：処理票適用
    '引　数：ltypExcpApply：処理票確定要求構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/27 (Fri) 16:49:34 S.Deguchi
    '更新日：2007/12/13 (Thu) 14:48:52 N.Kasai
    '備　考：
    '　　　：2007/12/13 (Thu) 14:48:52 N.Kasai  不要ﾀｸﾞ削除（LIST_CLASS）更新日時追加（EDIT_TIME)
    Public Function pubblnExcpApply_Ins(ByRef ltypExcpApply As ExcpApply) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "工程異常/不適合品処理確定"
            pubblnExcpApply_Ins = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypExcpApply
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                      'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                          'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
            
                If .strExcpNo <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_NO, .strExcpNo)                      '異常処理№
                Else
                    Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
                End If
            
        '@↓2007/12/13 (Thu) 14:49:34 N.Kasai **************************************************
        '        If .strListClass <> vbNullString Then
        '            Call lrMsg.addString(CPstrLIST_CLASS, .strListClass)                '帳票種別
        '        Else
        '            Call lrMsg.addString(CPstrLIST_CLASS, CPstrMsgNull)
        '        End If
        '@↑2007/12/13 (Thu) 14:49:34 N.Kasai **************************************************
            
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                        '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)                  '更新日時
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpapply___, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnExcpApply_Ins = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypExcpApply.strMsgVer)
                    
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

    '関数名：pubblnExcpCancelApply_Upd
    '機　能：工程異常/不適合品承認取消
    '引　数：ltypExcpApply：ﾃﾞｰﾀ格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2007/12/13 (Thu) 14:31:26 N.Kasai
    '更新日：2007/12/13 (Thu) 14:31:26
    '備　考：
    Public Function pubblnExcpCancelApply_Upd(ByRef ltypExcpApply As ExcpApply) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "工程異常/不適合品承認取消"
            pubblnExcpCancelApply_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypExcpApply
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                      'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                          'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                If .strExcpNo <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_NO, .strExcpNo)                      '異常処理№
                Else
                    Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
                End If
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                        '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)                  '更新日時
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpcancelapply, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE

                    '@関数の処理結果(成功)格納
                    pubblnExcpCancelApply_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypExcpApply.strMsgVer)
                    
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


    '関数名：pubblnExcpDelete_Upd
    '機　能：処理票破棄
    '引　数：ltypExcpDiscon：処理票破棄要求構造体
    '戻り値：True:成功/False:失敗
    '作成日：2004/08/27 (Fri) 16:49:34 S.Deguchi
    '更新日：2007/12/13 (Thu) 14:52:47 N.Kasai
    '備　考：
    '　　　：2007/12/13 (Thu) 14:52:47 N.Kasai  不要ﾀｸﾞ削除（LIST_CLASS）ﾀｸﾞ追加(EDIT_TIME)
    Public Function pubblnExcpDelete_Upd(ByRef ltypExcpDiscon As ExcpApply) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "工程異常/不適合品処理票破棄"
            pubblnExcpDelete_Upd = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypExcpDiscon
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                      'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                          'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
            
                If .strExcpNo <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_NO, .strExcpNo)                      '異常処理№
                Else
                    Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
                End If
            
        '@↓2007/12/13 (Thu) 14:52:44 N.Kasai **************************************************
        '        If .strListClass <> vbNullString Then
        '            Call lrMsg.addString(CPstrLIST_CLASS, .strListClass)                '帳票種別
        '        Else
        '            Call lrMsg.addString(CPstrLIST_CLASS, CPstrMsgNull)
        '        End If
        '@↑2007/12/13 (Thu) 14:52:44 N.Kasai **************************************************
            
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                        '作業者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)                  '更新日時
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If

                
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpdelete__, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@関数の処理結果(成功)格納
                    pubblnExcpDelete_Upd = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypExcpDiscon.strMsgVer)
                    
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

    '関数名：pubblnExcpLotCheck_Sel
    '機　能：ﾛｯﾄ状態確認
    '引　数：ltypExcpLotCheckReq：要求構造体
    '　　　：ltypExcpLotCheckAns：応答構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/08/05 (Fri) 09:06:13 S.Deguchi
    '更新日：2005/08/05 (Fri) 09:06:13
    '備　考：
    Public Function pubblnExcpLotCheck_Sel(ByRef ltypExcpLotCheckReq As ExcpCheckLotReq, _
                                           ByRef ltypExcpLotCheckAns As ExcpCheckLotAns) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lstrRET             As String           '応答取得
        
        Try
            
            pstrMessageName = "ロット状態確認"
            pubblnExcpLotCheck_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypExcpLotCheckReq
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                      'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
            
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                          'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
            
                If .strLotID <> vbNullString Then
                    Call lrMsg.addString(CPstrLOT_ID, .strLotID)                        'ﾛｯﾄID
                Else
                    Call lrMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpchecklot, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    With ltypExcpLotCheckAns
                        '@受信結果格納
                        Call laMsg.getString(CPstrWF_GOOD_QUANTITY, .strWfNum)          'WF良品数
                        Call laMsg.getString(CPstrCHIP_GOOD_QUANTITY, .strChipNum)      'ﾁｯﾌﾟ良品数
                        Call laMsg.getString(CPstrPD_ID, .strPdId)                      '機種
                        Call laMsg.getString(CPstrCF_LOT_FLAG, .strCFLotFlag)           'CFﾛｯﾄﾌﾗｸﾞ
                        Call laMsg.getString(CPstrOP_ID, .strOpID)                      '大工程
                        Call laMsg.getString(CPstrSTEP_ID, .strStepID)                  '小工程
                        Call laMsg.getString(CPstrWP_ID, .strWpID)                      '装置ID
                        Call laMsg.getString(CPstrWP_NAME, .strWpName)                  '装置名
                    End With
                    
                    '@関数の処理結果(成功)格納
                    pubblnExcpLotCheck_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypExcpLotCheckReq.strMsgVer)
                    
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

    '関数名：pubblnExcpChgReport_Upd_Old
    '機　能：工程異常/不適合品処理票登録/更新処理
    '引　数：ltypExcpReport  ：工程異常不適合品登録・更新構造体
    '　　　：lstrGuidMsg     ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True:成功/False:失敗
    '作成日：2005/08/08 (Mon) 10:00:32 S.Deguchi
    '更新日：2008/04/08 (Tue) 15:49:59 M.Koni
    '備　考：
    '　　　：【注意】
    '　　　：　本関数は，未使用です。<案件No.02755>の対応の為，ﾒｯｾｰｼﾞ生成順番を変更した
    '　　　：　ため，_Old を付けて，別関数として，そのまま残してあります。
    '　　　：　使用している関数は，この後にある，pubblnExcpChgReport_Upd() です。
    '　　　：
    Public Function pubblnExcpChgReport_Upd_Old(ByRef ltypExcpReport As ExcpReport, _
                                                ByRef lstrGuidMsg As String, _
                                                ByRef lstrGuidMsgCode As String) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "工程異常/不適合品処理票登録"
            pubblnExcpChgReport_Upd_Old = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            lrAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypExcpReport
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                                      'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                                  'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                If .strHoldFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrHOLD_FLAG, .strHoldFlag)                              '保留ﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrHOLD_FLAG, CPstrMsgNull)
                End If
                
                If .strExcpNo <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_NO, .strExcpNo)                                  '異常処理№
                Else
                    Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
                End If
                
                If .strFindDate <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_DATE, .strFindDate)                              '発見日時
                Else
                    Call lrMsg.addString(CPstrFIND_DATE, CPstrMsgNull)
                End If
                
                If .strFindDeptID <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_DEPT_ID, .strFindDeptID)                         '発見所属ID
                Else
                    Call lrMsg.addString(CPstrFIND_DEPT_ID, CPstrMsgNull)
                End If
                
                If .strFindDeptName <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_DEPT_NAME, .strFindDeptName)                     '発見所属名
                Else
                    Call lrMsg.addString(CPstrFIND_DEPT_NAME, CPstrMsgNull)
                End If
                
                If .strFindEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_EMP_ID, .strFindEmpID)                           '発見者ID
                Else
                    Call lrMsg.addString(CPstrFIND_EMP_ID, CPstrMsgNull)
                End If
                
                If .strFindEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_EMP_NAME, .strFindEmpName)                       '発見者名
                Else
                    Call lrMsg.addString(CPstrFIND_EMP_NAME, CPstrMsgNull)
                End If
                
                If .strFindTelNo <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_TEL_NO, .strFindTelNo)                           '発見者Tel
                Else
                    Call lrMsg.addString(CPstrFIND_TEL_NO, CPstrMsgNull)
                End If
                
                If .strDocClass <> vbNullString Then
                    Call lrMsg.addString(CPstrDOC_CLASS, .strDocClass)                              '帳票種別
                Else
                    Call lrMsg.addString(CPstrDOC_CLASS, CPstrMsgNull)
                End If
                
                If .strExcpItemName <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_ITEM_NAME, .strExcpItemName)                     '工程異常名
                Else
                    Call lrMsg.addString(CPstrEXCP_ITEM_NAME, CPstrMsgNull)
                End If
                
                If .strExcpItemNo <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_ITEM_NO, .strExcpItemNo)                         '工程異常項目ﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrEXCP_ITEM_NO, CPstrMsgNull)
                End If
                
                If .strExcpItemOthr <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_ITEM_OTHR, .strExcpItemOthr)                     '工程異常項目その他内容
                Else
                    Call lrMsg.addString(CPstrEXCP_ITEM_OTHR, CPstrMsgNull)
                End If

                If .strTargetPDID <> vbNullString Then
                    Call lrMsg.addString(CPstrTARGET_PD_ID, .strTargetPDID)                         '機種ID
                Else
                    Call lrMsg.addString(CPstrTARGET_PD_ID, CPstrMsgNull)
                End If

                If .strTargetQuantity <> vbNullString Then
                    Call lrMsg.addString(CPstrTARGET_QUANTITY, .strTargetQuantity)                  '対象数量数
                Else
                    Call lrMsg.addString(CPstrTARGET_QUANTITY, CPstrMsgNull)
                End If
                
                If .strTargetUnit <> vbNullString Then
                    Call lrMsg.addString(CPstrTARGET_UNIT, .strTargetUnit)                          '単位
                Else
                    Call lrMsg.addString(CPstrTARGET_UNIT, CPstrMsgNull)
                End If
                
                If .strFindOpID <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_OP_ID, .strFindOpID)                             '発見大工程
                Else
                    Call lrMsg.addString(CPstrFIND_OP_ID, CPstrMsgNull)
                End If
                
                If .strFindStepID <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_STEP_ID, .strFindStepID)                         '発見小工程
                Else
                    Call lrMsg.addString(CPstrFIND_STEP_ID, CPstrMsgNull)
                End If

                If .strFindWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_WP_ID, .strFindWpID)                             '発見装置ID
                Else
                    Call lrMsg.addString(CPstrFIND_WP_ID, CPstrMsgNull)
                End If

                If .strFindWpName <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_WP_NAME, .strFindWpName)                         '発見装置名
                Else
                    Call lrMsg.addString(CPstrFIND_WP_NAME, CPstrMsgNull)
                End If

                If .strExcpSituation <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_SITUATION, .strExcpSituation)                    '工程異常発生状況ｺﾒﾝﾄ
                Else
                    Call lrMsg.addString(CPstrEXCP_SITUATION, CPstrMsgNull)
                End If

                If .strIncongFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrINCONG_FLAG, .strIncongFlag)                          '不適合品発生有無
                Else
                    Call lrMsg.addString(CPstrINCONG_FLAG, CPstrMsgNull)
                End If

                If .strExcpDetailComments <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_DETAIL_COMMENTS, .strExcpDetailComments)         '異常内容評価ｺﾒﾝﾝﾄ
                Else
                    Call lrMsg.addString(CPstrEXCP_DETAIL_COMMENTS, CPstrMsgNull)
                End If

                If .strInflFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrINFL_FLAG, .strInflFlag)                              '後工程/信頼性影響
                Else
                    Call lrMsg.addString(CPstrINFL_FLAG, CPstrMsgNull)
                End If

                If .strTechInflContents <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INFL_CONTENTS, .strTechInflContents)             '技術部門処置内容
                Else
                    Call lrMsg.addString(CPstrTECH_INFL_CONTENTS, CPstrMsgNull)
                End If

                If .strTechInflEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INFL_EMP_ID, .strTechInflEmpID)                  '技術部門処置者ID
                Else
                    Call lrMsg.addString(CPstrTECH_INFL_EMP_ID, CPstrMsgNull)
                End If

                If .strTechInflEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INFL_EMP_NAME, .strTechInflEmpName)              '技術部門処置者名
                Else
                    Call lrMsg.addString(CPstrTECH_INFL_EMP_NAME, CPstrMsgNull)
                End If

                If .strTechInflDate <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INFL_DATE, .strTechInflDate)                     '技術部門処置日時
                Else
                    Call lrMsg.addString(CPstrTECH_INFL_DATE, CPstrMsgNull)
                End If

                If .strManuInflContents <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INFL_CONTENTS, .strManuInflContents)             '製造部門処置内容
                Else
                    Call lrMsg.addString(CPstrMANU_INFL_CONTENTS, CPstrMsgNull)
                End If

                If .strManuInflEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INFL_EMP_ID, .strManuInflEmpID)                  '製造部門処置者ID
                Else
                    Call lrMsg.addString(CPstrMANU_INFL_EMP_ID, CPstrMsgNull)
                End If

                If .strManuInflEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INFL_EMP_NAME, .strManuInflEmpName)              '製造部門処置者名
                Else
                    Call lrMsg.addString(CPstrMANU_INFL_EMP_NAME, CPstrMsgNull)
                End If

                If .strManuInflDate <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INFL_DATE, .strManuInflDate)                     '製造部門処置日時
                Else
                    Call lrMsg.addString(CPstrMANU_INFL_DATE, CPstrMsgNull)
                End If

                If .strOthrInflContents <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INFL_CONTENTS, .strOthrInflContents)             'その他部門処置内容
                Else
                    Call lrMsg.addString(CPstrOTHR_INFL_CONTENTS, CPstrMsgNull)
                End If

                If .strOthrInflEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INFL_EMP_ID, .strOthrInflEmpID)                  'その他部門処置者ID
                Else
                    Call lrMsg.addString(CPstrOTHR_INFL_EMP_ID, CPstrMsgNull)
                End If

                If .strOthrInflEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INFL_EMP_NAME, .strOthrInflEmpName)              'その他部門処置者名
                Else
                    Call lrMsg.addString(CPstrOTHR_INFL_EMP_NAME, CPstrMsgNull)
                End If

                If .strOthrInflDate <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INFL_DATE, .strOthrInflDate)                     'その他部門処置日時
                Else
                    Call lrMsg.addString(CPstrOTHR_INFL_DATE, CPstrMsgNull)
                End If

                If .strTechInvestContents <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INVEST_CONTENTS, .strTechInvestContents)         '技術部門調査内容
                Else
                    Call lrMsg.addString(CPstrTECH_INVEST_CONTENTS, CPstrMsgNull)
                End If

                If .strTechInvestEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INVEST_EMP_ID, .strTechInvestEmpID)              '技術部門調査者ID
                Else
                    Call lrMsg.addString(CPstrTECH_INVEST_EMP_ID, CPstrMsgNull)
                End If

                If .strTechInvestEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INVEST_EMP_NAME, .strTechInvestEmpName)          '技術部門調査者名
                Else
                    Call lrMsg.addString(CPstrTECH_INVEST_EMP_NAME, CPstrMsgNull)
                End If

                If .strTechInvestDate <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INVEST_DATE, .strTechInvestDate)                 '技術部門調査日時
                Else
                    Call lrMsg.addString(CPstrTECH_INVEST_DATE, CPstrMsgNull)
                End If

                If .strManuInvestContents <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INVEST_CONTENTS, .strManuInvestContents)         '製造部門調査内容
                Else
                    Call lrMsg.addString(CPstrMANU_INVEST_CONTENTS, CPstrMsgNull)
                End If

                If .strManuInvestEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INVEST_EMP_ID, .strManuInvestEmpID)              '製造部門調査者ID
                Else
                    Call lrMsg.addString(CPstrMANU_INVEST_EMP_ID, CPstrMsgNull)
                End If

                If .strManuInvestEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INVEST_EMP_NAME, .strManuInvestEmpName)          '製造部門調査者名
                Else
                    Call lrMsg.addString(CPstrMANU_INVEST_EMP_NAME, CPstrMsgNull)
                End If

                If .strManuInvestDate <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INVEST_DATE, .strManuInvestDate)                 '製造部門調査日時
                Else
                    Call lrMsg.addString(CPstrMANU_INVEST_DATE, CPstrMsgNull)
                End If

                If .strOthrInvestContents <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INVEST_CONTENTS, .strOthrInvestContents)         'その他部門調査内容
                Else
                    Call lrMsg.addString(CPstrOTHR_INVEST_CONTENTS, CPstrMsgNull)
                End If

                If .strOthrInvestEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INVEST_EMP_ID, .strOthrInvestEmpID)              'その他部門調査者ID
                Else
                    Call lrMsg.addString(CPstrOTHR_INVEST_EMP_ID, CPstrMsgNull)
                End If

                If .strOthrInvestEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INVEST_EMP_NAME, .strOthrInvestEmpName)          'その他部門調査者名
                Else
                    Call lrMsg.addString(CPstrOTHR_INVEST_EMP_NAME, CPstrMsgNull)
                End If

                If .strOthrInvestDate <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INVEST_DATE, .strOthrInvestDate)                 'その他部門調査日時
                Else
                    Call lrMsg.addString(CPstrOTHR_INVEST_DATE, CPstrMsgNull)
                End If

                If .strTechIndicateContents <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INDICATE_CONTENTS, .strTechIndicateContents)     '技術部門指示内容
                Else
                    Call lrMsg.addString(CPstrTECH_INDICATE_CONTENTS, CPstrMsgNull)
                End If

                If .strTechIndicateEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INDICATE_EMP_ID, .strTechIndicateEmpID)          '技術部門指示者ID
                Else
                    Call lrMsg.addString(CPstrTECH_INDICATE_EMP_ID, CPstrMsgNull)
                End If

                If .strTechIndicateEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INDICATE_EMP_NAME, .strTechIndicateEmpName)      '技術部門指示者名
                Else
                    Call lrMsg.addString(CPstrTECH_INDICATE_EMP_NAME, CPstrMsgNull)
                End If

                If .strTechIndicateDate <> vbNullString Then
                    Call lrMsg.addString(CPstrTECH_INDICATE_DATE, .strTechIndicateDate)             '技術部門指示日時
                Else
                    Call lrMsg.addString(CPstrTECH_INDICATE_DATE, CPstrMsgNull)
                End If

                If .strManuIndicateContents <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INDICATE_CONTENTS, .strManuIndicateContents)     '製造部門指示内容
                Else
                    Call lrMsg.addString(CPstrMANU_INDICATE_CONTENTS, CPstrMsgNull)
                End If

                If .strManuIndicateEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INDICATE_EMP_ID, .strManuIndicateEmpID)          '製造部門指示者ID
                Else
                    Call lrMsg.addString(CPstrMANU_INDICATE_EMP_ID, CPstrMsgNull)
                End If

                If .strManuIndicateEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INDICATE_EMP_NAME, .strManuIndicateEmpName)      '製造部門指示者名
                Else
                    Call lrMsg.addString(CPstrMANU_INDICATE_EMP_NAME, CPstrMsgNull)
                End If

                If .strManuIndicateDate <> vbNullString Then
                    Call lrMsg.addString(CPstrMANU_INDICATE_DATE, .strManuIndicateDate)             '製造部門指示日時
                Else
                    Call lrMsg.addString(CPstrMANU_INDICATE_DATE, CPstrMsgNull)
                End If

                If .strOthrIndicateContents <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INDICATE_CONTENTS, .strOthrIndicateContents)     'その他部門指示内容
                Else
                    Call lrMsg.addString(CPstrOTHR_INDICATE_CONTENTS, CPstrMsgNull)
                End If

                If .strOthrIndicateEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INDICATE_EMP_ID, .strOthrIndicateEmpID)          'その他部門指示者ID
                Else
                    Call lrMsg.addString(CPstrOTHR_INDICATE_EMP_ID, CPstrMsgNull)
                End If

                If .strOthrIndicateEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INDICATE_EMP_NAME, .strOthrIndicateEmpName)      'その他部門指示者名
                Else
                    Call lrMsg.addString(CPstrOTHR_INDICATE_EMP_NAME, CPstrMsgNull)
                End If

                If .strOthrIndicateDate <> vbNullString Then
                    Call lrMsg.addString(CPstrOTHR_INDICATE_DATE, .strOthrIndicateDate)             'その他部門指示日時
                Else
                    Call lrMsg.addString(CPstrOTHR_INDICATE_DATE, CPstrMsgNull)
                End If

                '@********************************************************************************
                '@不適合品部分のﾒｯｾｰｼﾞをﾘｽﾄ形式にして送信：理由⇒TAGは同一階層に100以上設定できない為。
                '@********************************************************************************
                    If .strIncongItemName <> vbNullString Then
                        Call ltMsg.addString(CPstrINCONG_ITEM_NAME, .strIncongItemName)                 '不良特性名
                    Else
                        Call ltMsg.addString(CPstrINCONG_ITEM_NAME, CPstrMsgNull)
                    End If
            
                    If .strTechCheckContents <> vbNullString Then
                        Call ltMsg.addString(CPstrTECH_CHECK_CONTENTS, .strTechCheckContents)           '技術部門確認内容
                    Else
                        Call ltMsg.addString(CPstrTECH_CHECK_CONTENTS, CPstrMsgNull)
                    End If
            
                    If .strTechCheckEmpID <> vbNullString Then
                        Call ltMsg.addString(CPstrTECH_CHECK_EMP_ID, .strTechCheckEmpID)                '技術部門確認者ID
                    Else
                        Call ltMsg.addString(CPstrTECH_CHECK_EMP_ID, CPstrMsgNull)
                    End If
            
                    If .strTechCheckEmpName <> vbNullString Then
                        Call ltMsg.addString(CPstrTECH_CHECK_EMP_NAME, .strTechCheckEmpName)            '技術部門確認者名
                    Else
                        Call ltMsg.addString(CPstrTECH_CHECK_EMP_NAME, CPstrMsgNull)
                    End If
            
                    If .strTechCheckDate <> vbNullString Then
                        Call ltMsg.addString(CPstrTECH_CHECK_DATE, .strTechCheckDate)                   '技術部門確認日時
                    Else
                        Call ltMsg.addString(CPstrTECH_CHECK_DATE, CPstrMsgNull)
                    End If
            
                    If .strManuCheckContents <> vbNullString Then
                        Call ltMsg.addString(CPstrMANU_CHECK_CONTENTS, .strManuCheckContents)           '製造部門確認内容
                    Else
                        Call ltMsg.addString(CPstrMANU_CHECK_CONTENTS, CPstrMsgNull)
                    End If
            
                    If .strManuCheckEmpID <> vbNullString Then
                        Call ltMsg.addString(CPstrMANU_CHECK_EMP_ID, .strManuCheckEmpID)                '製造部門確認者ID
                    Else
                        Call ltMsg.addString(CPstrMANU_CHECK_EMP_ID, CPstrMsgNull)
                    End If
            
                    If .strManuCheckEmpName <> vbNullString Then
                        Call ltMsg.addString(CPstrMANU_CHECK_EMP_NAME, .strManuCheckEmpName)            '製造部門確認者名
                    Else
                        Call ltMsg.addString(CPstrMANU_CHECK_EMP_NAME, CPstrMsgNull)
                    End If
            
                    If .strManuCheckDate <> vbNullString Then
                        Call ltMsg.addString(CPstrMANU_CHECK_DATE, .strManuCheckDate)                   '製造部門確認日時
                    Else
                        Call ltMsg.addString(CPstrMANU_CHECK_DATE, CPstrMsgNull)
                    End If
            
                    If .strOthrCheckContents <> vbNullString Then
                        Call ltMsg.addString(CPstrOTHR_CHECK_CONTENTS, .strOthrCheckContents)           'その他部門確認内容
                    Else
                        Call ltMsg.addString(CPstrOTHR_CHECK_CONTENTS, CPstrMsgNull)
                    End If
            
                    If .strOthrCheckEmpID <> vbNullString Then
                        Call ltMsg.addString(CPstrOTHR_CHECK_EMP_ID, .strOthrCheckEmpID)                'その他部門確認者ID
                    Else
                        Call ltMsg.addString(CPstrOTHR_CHECK_EMP_ID, CPstrMsgNull)
                    End If
            
                    If .strOthrCheckEmpName <> vbNullString Then
                        Call ltMsg.addString(CPstrOTHR_CHECK_EMP_NAME, .strOthrCheckEmpName)            'その他部門確認者名
                    Else
                        Call ltMsg.addString(CPstrOTHR_CHECK_EMP_NAME, CPstrMsgNull)
                    End If
            
                    If .strOthrCheckDate <> vbNullString Then
                        Call ltMsg.addString(CPstrOTHR_CHECK_DATE, .strOthrCheckDate)                   'その他部門確認日時
                    Else
                        Call ltMsg.addString(CPstrOTHR_CHECK_DATE, CPstrMsgNull)
                    End If
            
                    If .strIncongJudgeVolume <> vbNullString Then
                        Call ltMsg.addString(CPstrINCONG_JUDGE_VOLUME, .strIncongJudgeVolume)           '不適合品発生量ﾌﾗｸﾞ
                    Else
                        Call ltMsg.addString(CPstrINCONG_JUDGE_VOLUME, CPstrMsgNull)
                    End If
            
                    If .strIncongJudgeEmpID <> vbNullString Then
                        Call ltMsg.addString(CPstrINCONG_JUDGE_EMP_ID, .strIncongJudgeEmpID)            '不適合品発生判定者ID
                    Else
                        Call ltMsg.addString(CPstrINCONG_JUDGE_EMP_ID, CPstrMsgNull)
                    End If
                    
                    If .strIncongJudgeEmpName <> vbNullString Then
                        Call ltMsg.addString(CPstrINCONG_JUDGE_EMP_NAME, .strIncongJudgeEmpName)        '不適合品発生判定者名
                    Else
                        Call ltMsg.addString(CPstrINCONG_JUDGE_EMP_NAME, CPstrMsgNull)
                    End If
                    
                    If .strIncongJudgeDate <> vbNullString Then
                        Call ltMsg.addString(CPstrINCONG_JUDGE_DATE, .strIncongJudgeDate)               '不適合品発生判定日時
                    Else
                        Call ltMsg.addString(CPstrINCONG_JUDGE_DATE, CPstrMsgNull)
                    End If
            
                    If .strDispoScrapFlag <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_SCRAP_FLAG, .strDispoScrapFlag)                 '現品廃却ﾌﾗｸﾞ
                    Else
                        Call ltMsg.addString(CPstrDISPO_SCRAP_FLAG, CPstrMsgNull)
                    End If
            
                    If .strDispoMdifyFlag <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_MODIFY_FLAG, .strDispoMdifyFlag)                '現品手直しﾌﾗｸﾞ
                    Else
                        Call ltMsg.addString(CPstrDISPO_MODIFY_FLAG, CPstrMsgNull)
                    End If
            
                    If .strDispoPickFlag <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_PICK_FLAG, .strDispoPickFlag)                   '現品特採ﾌﾗｸﾞ
                    Else
                        Call ltMsg.addString(CPstrDISPO_PICK_FLAG, CPstrMsgNull)
                    End If
            
                    If .strDispoRegularFlag <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_REGULAR_FLAG, .strDispoRegularFlag)             '現品通常ﾌﾗｸﾞ
                    Else
                        Call ltMsg.addString(CPstrDISPO_REGULAR_FLAG, CPstrMsgNull)
                    End If
            
                    If .strDispoAmendFlag <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_AMEND_FLAG, .strDispoAmendFlag)                 '現品修正ﾌﾗｸﾞ
                    Else
                        Call ltMsg.addString(CPstrDISPO_AMEND_FLAG, CPstrMsgNull)
                    End If
            
                    If .strDispoRatingFlag <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_RATING_FLAG, .strDispoRatingFlag)               '現品評価ﾌﾗｸﾞ
                    Else
                        Call ltMsg.addString(CPstrDISPO_RATING_FLAG, CPstrMsgNull)
                    End If
            
                    If .strDispoContents <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_CONTENTS, .strDispoContents)                    '現品処理内容
                    Else
                        Call ltMsg.addString(CPstrDISPO_CONTENTS, CPstrMsgNull)
                    End If
            
                    If .strDispoIndicateEmpID <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_INDICATE_EMP_ID, .strDispoIndicateEmpID)        '現品処理指示者ID
                    Else
                        Call ltMsg.addString(CPstrDISPO_INDICATE_EMP_ID, CPstrMsgNull)
                    End If
            
                    If .strDispoIndicateEmpName <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_INDICATE_EMP_NAME, .strDispoIndicateEmpName)    '現品処理指示者名
                    Else
                        Call ltMsg.addString(CPstrDISPO_INDICATE_EMP_NAME, CPstrMsgNull)
                    End If
            
                    If .strDispoIndicateDate <> vbNullString Then
                        Call ltMsg.addString(CPstrDISPO_INDICATE_DATE, .strDispoIndicateDate)           '現品処理指示日時
                    Else
                        Call ltMsg.addString(CPstrDISPO_INDICATE_DATE, CPstrMsgNull)
                    End If
            
                    If .strImproKind <> vbNullString Then
                        Call ltMsg.addString(CPstrIMPRO_KIND, .strImproKind)                            '改善取り組み
                    Else
                        Call ltMsg.addString(CPstrIMPRO_KIND, CPstrMsgNull)
                    End If
            
                    If .strImproContents <> vbNullString Then
                        Call ltMsg.addString(CPstrIMPRO_CONTENTS, .strImproContents)                    '改善取り組み内容
                    Else
                        Call ltMsg.addString(CPstrIMPRO_CONTENTS, CPstrMsgNull)
                    End If
            
                    If .strImproEmpID <> vbNullString Then
                        Call ltMsg.addString(CPstrIMPRO_EMP_ID, .strImproEmpID)                         '改善取り組み者ID
                    Else
                        Call ltMsg.addString(CPstrIMPRO_EMP_ID, CPstrMsgNull)
                    End If
            
                    If .strImproEmpName <> vbNullString Then
                        Call ltMsg.addString(CPstrIMPRO_EMP_NAME, .strImproEmpName)                     '改善取り組み者名
                    Else
                        Call ltMsg.addString(CPstrIMPRO_EMP_NAME, CPstrMsgNull)
                    End If
            
                    If .strImproDate <> vbNullString Then
                        Call ltMsg.addString(CPstrIMPRO_DATE, .strImproDate)                            '改善取り組み日時
                    Else
                        Call ltMsg.addString(CPstrIMPRO_DATE, CPstrMsgNull)
                    End If
                    
                    '@ｱﾚｲに格納
                    Call lrAry.Add(ltMsg)
                    '@ｸﾘｱ処理
                    Call ltMsg.Clear
                
                '@Tempにｱﾚｲの内容を格納
                Call lrMsg.addMsgAry(CPstrINCONG_LIST, lrAry)
                
                '@ｸﾘｱ処理
                Call lrAry.Clear

                If .strCauseWpID <> vbNullString Then
                    Call lrMsg.addString(CPstrCAUSE_WP_ID, .strCauseWpID)                           '原因装置ID
                Else
                    Call lrMsg.addString(CPstrCAUSE_WP_ID, CPstrMsgNull)
                End If

                If .strCauseWpName <> vbNullString Then
                    Call lrMsg.addString(CPstrCAUSE_WP_NAME, .strCauseWpName)                       '原因装置名
                Else
                    Call lrMsg.addString(CPstrCAUSE_WP_NAME, CPstrMsgNull)
                End If

                If .strCauseSeriesName <> vbNullString Then
                    Call lrMsg.addString(CPstrCAUSE_SERIES_NAME, .strCauseSeriesName)               '原因系列名
                Else
                    Call lrMsg.addString(CPstrCAUSE_SERIES_NAME, CPstrMsgNull)
                End If

                If .strCauseClassName <> vbNullString Then
                    Call lrMsg.addString(CPstrCAUSE_CLASS_NAME, .strCauseClassName)                 '原因区分名
                Else
                    Call lrMsg.addString(CPstrCAUSE_CLASS_NAME, CPstrMsgNull)
                End If

                '@ﾛｯﾄﾘｽﾄ
                If .lngExcpReportLotListCnt > 0 Then
                    For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                        If .typExcpLotList(llngCnt).strLotID <> vbNullString Then
                            Call ltMsg.addString(CPstrLOT_ID, .typExcpLotList(llngCnt).strLotID)                            'ﾛｯﾄID
                        Else
                            Call ltMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strTargetQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrTARGET_QUANTITY, .typExcpLotList(llngCnt).strTargetQuantity)          '対象数量
                        Else
                            Call ltMsg.addString(CPstrTARGET_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strTotalQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrTOTAL_QUANTITY, .typExcpLotList(llngCnt).strTotalQuantity)            '合計数量
                        Else
                            Call ltMsg.addString(CPstrTOTAL_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strReserveQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrRESERVE_QUANTITY, .typExcpLotList(llngCnt).strReserveQuantity)        '保留
                        Else
                            Call ltMsg.addString(CPstrRESERVE_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strAbandonQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrABANDON_QUANTITY, .typExcpLotList(llngCnt).strAbandonQuantity)        '廃却
                        Else
                            Call ltMsg.addString(CPstrABANDON_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strAmendQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrAMEND_QUANTITY, .typExcpLotList(llngCnt).strAmendQuantity)            '手直し
                        Else
                            Call ltMsg.addString(CPstrAMEND_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strCorrectQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrCORRECT_QUANTITY, .typExcpLotList(llngCnt).strCorrectQuantity)        '修正
                        Else
                            Call ltMsg.addString(CPstrCORRECT_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strUsualQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrUSUAL_QUANTITY, .typExcpLotList(llngCnt).strUsualQuantity)            '通常
                        Else
                            Call ltMsg.addString(CPstrUSUAL_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strEvalQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrEVAL_QUANTITY, .typExcpLotList(llngCnt).strEvalQuantity)              '評価
                        Else
                            Call ltMsg.addString(CPstrEVAL_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strTakeQuantity <> vbNullString Then
                            Call ltMsg.addString(CPstrTAKE_QUANTITY, .typExcpLotList(llngCnt).strTakeQuantity)              '特採
                        Else
                            Call ltMsg.addString(CPstrTAKE_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strDisposalFlag <> vbNullString Then
                            Call ltMsg.addString(CPstrDISPOSAL_FLAG, .typExcpLotList(llngCnt).strDisposalFlag)              '処置ﾌﾗｸﾞ
                        Else
                            Call ltMsg.addString(CPstrDISPOSAL_FLAG, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strAppendFlag <> vbNullString Then
                            Call ltMsg.addString(CPstrAPPEND_FLAG, .typExcpLotList(llngCnt).strAppendFlag)                  'ﾛｯﾄ追加ﾌﾗｸﾞ
                        Else
                            Call ltMsg.addString(CPstrAPPEND_FLAG, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strEditTime <> vbNullString Then
                            Call ltMsg.addString(CPstrEDIT_TIME, .typExcpLotList(llngCnt).strEditTime)                      '最終更新日時
                        Else
                            Call ltMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                        End If
                        
                        '@ｱﾚｲ1に格納
                        Call lrAry.Add(ltMsg)
                        Call ltMsg.Clear
                    Next llngCnt
                End If
                
                '@Temp1にｱﾚｲ1の内容を格納
                Call lrMsg.addMsgAry(CPstrLOT_LIST, lrAry)
                        
                '@全処置ﾌﾗｸﾞ
                If .strAllDisposalFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrALL_DISPOSAL_FLAG, .strAllDisposalFlag)           '全処置ﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrALL_DISPOSAL_FLAG, CPstrMsgNull)
                End If
                        
                '@承認ﾌﾗｸﾞ
                If .strApprovalFlag <> vbNullString Then
                    Call lrMsg.addString(CPstrAPPROVAL_FLAG, .strApprovalFlag)                  '承認ﾌﾗｸﾞ
                Else
                    Call lrMsg.addString(CPstrAPPROVAL_FLAG, CPstrMsgNull)
                End If
                
                '@承認者ID
                If .strApprovalEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_ID, .strApprovalEmpID)               '承認者ID
                Else
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_ID, CPstrMsgNull)
                End If
                
                '@承認者名
                If .strApprovalEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_NAME, .strApprovalEmpName)           '承認者名
                Else
                    Call lrMsg.addString(CPstrAPPROVAL_EMP_NAME, CPstrMsgNull)
                End If
                        
                '@更新者ID
                If .strEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_ID, .strEmpID)                                '更新者ID
                Else
                    Call lrMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If
                
                '@更新者名
                If .strEmpName <> vbNullString Then
                    Call lrMsg.addString(CPstrEMP_NAME, .strEmpName)                            '更新者名
                Else
                    Call lrMsg.addString(CPstrEMP_NAME, CPstrMsgNull)
                End If
                
                '@更新日時
                If .strEditTime <> vbNullString Then
                    Call lrMsg.addString(CPstrEDIT_TIME, .strEditTime)                          '更新日時
                Else
                    Call lrMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If
            
                '@登録日時
                If .strEntryTime <> vbNullString Then
                    Call lrMsg.addString(CPstrENTRY_TIME, .strEntryTime)                        '登録日時
                Else
                    Call lrMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If
            End With
            
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpchgreport, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrEDIT_TIME, ltypExcpReport.strEditTime)        '最終更新日時
                    Call laMsg.getString(CPstrEXCP_NO, ltypExcpReport.strExcpNo)            '異常処理№
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                             'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                    'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
                    
                    '@関数の処理結果(成功)格納
                    pubblnExcpChgReport_Upd_Old = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypExcpReport.strMsgVer)
                    
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



    '関数名：pubblnExcpChgReport_Upd
    '機　能：工程異常/不適合品処理票登録/更新処理
    '引　数：ltypExcpReport  ：工程異常不適合品登録・更新構造体
    '　　　：lstrGuidMsg     ：ｶﾞｲﾀﾞﾝｽMsg
    '　　　：lstrGuidMsgCode ：ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
    '戻り値：True:成功/False:失敗
    '作成日：2005/08/08 (Mon) 10:00:32 S.Deguchi
    '更新日：2008/04/04 (Fri) 11:39:03 M.Koni
    '備　考：
    '　　　：2008/04/04 (Fri) 11:39:08 M.Koni       TARGET_QUANTITY計算方法変更に伴い全面改良<案件No.02755>
    Public Function pubblnExcpChgReport_Upd(ByRef ltypExcpReport As ExcpReport, _
                                            ByRef lstrGuidMsg As String, _
                                            ByRef lstrGuidMsgCode As String) As Boolean

        Dim lMainMsg            As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim lLotlistMsg         As TfMsg            'LOT_LIST用送信ﾒｯｾｰｼﾞ配列用
        Dim lLotlistArray       As TfMsgAry         'LOT_LIST用送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lIncongMsg          As TfMsg            'INCONG_LIST用送信ﾒｯｾｰｼﾞ配列用
        Dim lIncongArray        As TfMsgAry         'INCONG_LIST用送信ﾒｯｾｰｼﾞｱﾚｰ
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim lintTotalTargetQuantity     As Short    '対象ﾛｯﾄの対象総数量

        Try

            pstrMessageName = "工程異常/不適合品処理票登録"
            pubblnExcpChgReport_Upd = False

            '@ﾒｯｾｰｼﾞ構造体の定義
            lMainMsg = New TfMsg
            lIncongMsg = New TfMsg
            lIncongArray = New TfMsgAry
            lLotlistMsg = New TfMsg
            lLotlistArray = New TfMsgAry

            '@ 送信ﾒｯｾｰｼﾞ作成 *************************************************************************
            '@ ﾒｲﾝﾘｽﾄ部の生成
            With ltypExcpReport

                '<INCONG_LIST> 不適合品ﾘｽﾄの生成
                '@*************************************************************************************
                '@不適合品部分のﾒｯｾｰｼﾞをﾘｽﾄ形式にして送信
                '@  ﾘｽﾄ化の理由 ⇒ TAGは同一階層に100以上設定できない為。
                '@
                '@    lIncongArray
                '@          |- lIncongMsg
                '@
                '@*************************************************************************************
                If .strIncongItemName <> vbNullString Then
                    Call lIncongMsg.addString(CPstrINCONG_ITEM_NAME, .strIncongItemName)                 '不良特性名
                Else
                    Call lIncongMsg.addString(CPstrINCONG_ITEM_NAME, CPstrMsgNull)
                End If

                If .strTechCheckContents <> vbNullString Then
                    Call lIncongMsg.addString(CPstrTECH_CHECK_CONTENTS, .strTechCheckContents)           '技術部門確認内容
                Else
                    Call lIncongMsg.addString(CPstrTECH_CHECK_CONTENTS, CPstrMsgNull)
                End If

                If .strTechCheckEmpID <> vbNullString Then
                    Call lIncongMsg.addString(CPstrTECH_CHECK_EMP_ID, .strTechCheckEmpID)                '技術部門確認者ID
                Else
                    Call lIncongMsg.addString(CPstrTECH_CHECK_EMP_ID, CPstrMsgNull)
                End If

                If .strTechCheckEmpName <> vbNullString Then
                    Call lIncongMsg.addString(CPstrTECH_CHECK_EMP_NAME, .strTechCheckEmpName)            '技術部門確認者名
                Else
                    Call lIncongMsg.addString(CPstrTECH_CHECK_EMP_NAME, CPstrMsgNull)
                End If

                If .strTechCheckDate <> vbNullString Then
                    Call lIncongMsg.addString(CPstrTECH_CHECK_DATE, .strTechCheckDate)                   '技術部門確認日時
                Else
                    Call lIncongMsg.addString(CPstrTECH_CHECK_DATE, CPstrMsgNull)
                End If

                If .strManuCheckContents <> vbNullString Then
                    Call lIncongMsg.addString(CPstrMANU_CHECK_CONTENTS, .strManuCheckContents)           '製造部門確認内容
                Else
                    Call lIncongMsg.addString(CPstrMANU_CHECK_CONTENTS, CPstrMsgNull)
                End If

                If .strManuCheckEmpID <> vbNullString Then
                    Call lIncongMsg.addString(CPstrMANU_CHECK_EMP_ID, .strManuCheckEmpID)                '製造部門確認者ID
                Else
                    Call lIncongMsg.addString(CPstrMANU_CHECK_EMP_ID, CPstrMsgNull)
                End If

                If .strManuCheckEmpName <> vbNullString Then
                    Call lIncongMsg.addString(CPstrMANU_CHECK_EMP_NAME, .strManuCheckEmpName)            '製造部門確認者名
                Else
                    Call lIncongMsg.addString(CPstrMANU_CHECK_EMP_NAME, CPstrMsgNull)
                End If

                If .strManuCheckDate <> vbNullString Then
                    Call lIncongMsg.addString(CPstrMANU_CHECK_DATE, .strManuCheckDate)                   '製造部門確認日時
                Else
                    Call lIncongMsg.addString(CPstrMANU_CHECK_DATE, CPstrMsgNull)
                End If

                If .strOthrCheckContents <> vbNullString Then
                    Call lIncongMsg.addString(CPstrOTHR_CHECK_CONTENTS, .strOthrCheckContents)           'その他部門確認内容
                Else
                    Call lIncongMsg.addString(CPstrOTHR_CHECK_CONTENTS, CPstrMsgNull)
                End If

                If .strOthrCheckEmpID <> vbNullString Then
                    Call lIncongMsg.addString(CPstrOTHR_CHECK_EMP_ID, .strOthrCheckEmpID)                'その他部門確認者ID
                Else
                    Call lIncongMsg.addString(CPstrOTHR_CHECK_EMP_ID, CPstrMsgNull)
                End If

                If .strOthrCheckEmpName <> vbNullString Then
                    Call lIncongMsg.addString(CPstrOTHR_CHECK_EMP_NAME, .strOthrCheckEmpName)            'その他部門確認者名
                Else
                    Call lIncongMsg.addString(CPstrOTHR_CHECK_EMP_NAME, CPstrMsgNull)
                End If

                If .strOthrCheckDate <> vbNullString Then
                    Call lIncongMsg.addString(CPstrOTHR_CHECK_DATE, .strOthrCheckDate)                   'その他部門確認日時
                Else
                    Call lIncongMsg.addString(CPstrOTHR_CHECK_DATE, CPstrMsgNull)
                End If

                If .strIncongJudgeVolume <> vbNullString Then
                    Call lIncongMsg.addString(CPstrINCONG_JUDGE_VOLUME, .strIncongJudgeVolume)           '不適合品発生量ﾌﾗｸﾞ
                Else
                    Call lIncongMsg.addString(CPstrINCONG_JUDGE_VOLUME, CPstrMsgNull)
                End If

                If .strIncongJudgeEmpID <> vbNullString Then
                    Call lIncongMsg.addString(CPstrINCONG_JUDGE_EMP_ID, .strIncongJudgeEmpID)            '不適合品発生判定者ID
                Else
                    Call lIncongMsg.addString(CPstrINCONG_JUDGE_EMP_ID, CPstrMsgNull)
                End If
                
                If .strIncongJudgeEmpName <> vbNullString Then
                    Call lIncongMsg.addString(CPstrINCONG_JUDGE_EMP_NAME, .strIncongJudgeEmpName)        '不適合品発生判定者名
                Else
                    Call lIncongMsg.addString(CPstrINCONG_JUDGE_EMP_NAME, CPstrMsgNull)
                End If
                
                If .strIncongJudgeDate <> vbNullString Then
                    Call lIncongMsg.addString(CPstrINCONG_JUDGE_DATE, .strIncongJudgeDate)               '不適合品発生判定日時
                Else
                    Call lIncongMsg.addString(CPstrINCONG_JUDGE_DATE, CPstrMsgNull)
                End If

                If .strDispoScrapFlag <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_SCRAP_FLAG, .strDispoScrapFlag)                 '現品廃却ﾌﾗｸﾞ
                Else
                    Call lIncongMsg.addString(CPstrDISPO_SCRAP_FLAG, CPstrMsgNull)
                End If

                If .strDispoMdifyFlag <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_MODIFY_FLAG, .strDispoMdifyFlag)                '現品手直しﾌﾗｸﾞ
                Else
                    Call lIncongMsg.addString(CPstrDISPO_MODIFY_FLAG, CPstrMsgNull)
                End If

                If .strDispoPickFlag <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_PICK_FLAG, .strDispoPickFlag)                   '現品特採ﾌﾗｸﾞ
                Else
                    Call lIncongMsg.addString(CPstrDISPO_PICK_FLAG, CPstrMsgNull)
                End If

                If .strDispoRegularFlag <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_REGULAR_FLAG, .strDispoRegularFlag)             '現品通常ﾌﾗｸﾞ
                Else
                    Call lIncongMsg.addString(CPstrDISPO_REGULAR_FLAG, CPstrMsgNull)
                End If

                If .strDispoAmendFlag <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_AMEND_FLAG, .strDispoAmendFlag)                 '現品修正ﾌﾗｸﾞ
                Else
                    Call lIncongMsg.addString(CPstrDISPO_AMEND_FLAG, CPstrMsgNull)
                End If

                If .strDispoRatingFlag <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_RATING_FLAG, .strDispoRatingFlag)               '現品評価ﾌﾗｸﾞ
                Else
                    Call lIncongMsg.addString(CPstrDISPO_RATING_FLAG, CPstrMsgNull)
                End If

                If .strDispoContents <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_CONTENTS, .strDispoContents)                    '現品処理内容
                Else
                    Call lIncongMsg.addString(CPstrDISPO_CONTENTS, CPstrMsgNull)
                End If

                If .strDispoIndicateEmpID <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_INDICATE_EMP_ID, .strDispoIndicateEmpID)        '現品処理指示者ID
                Else
                    Call lIncongMsg.addString(CPstrDISPO_INDICATE_EMP_ID, CPstrMsgNull)
                End If

                If .strDispoIndicateEmpName <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_INDICATE_EMP_NAME, .strDispoIndicateEmpName)    '現品処理指示者名
                Else
                    Call lIncongMsg.addString(CPstrDISPO_INDICATE_EMP_NAME, CPstrMsgNull)
                End If

                If .strDispoIndicateDate <> vbNullString Then
                    Call lIncongMsg.addString(CPstrDISPO_INDICATE_DATE, .strDispoIndicateDate)           '現品処理指示日時
                Else
                    Call lIncongMsg.addString(CPstrDISPO_INDICATE_DATE, CPstrMsgNull)
                End If

                If .strImproKind <> vbNullString Then
                    Call lIncongMsg.addString(CPstrIMPRO_KIND, .strImproKind)                            '改善取り組み
                Else
                    Call lIncongMsg.addString(CPstrIMPRO_KIND, CPstrMsgNull)
                End If

                If .strImproContents <> vbNullString Then
                    Call lIncongMsg.addString(CPstrIMPRO_CONTENTS, .strImproContents)                    '改善取り組み内容
                Else
                    Call lIncongMsg.addString(CPstrIMPRO_CONTENTS, CPstrMsgNull)
                End If

                If .strImproEmpID <> vbNullString Then
                    Call lIncongMsg.addString(CPstrIMPRO_EMP_ID, .strImproEmpID)                         '改善取り組み者ID
                Else
                    Call lIncongMsg.addString(CPstrIMPRO_EMP_ID, CPstrMsgNull)
                End If

                If .strImproEmpName <> vbNullString Then
                    Call lIncongMsg.addString(CPstrIMPRO_EMP_NAME, .strImproEmpName)                     '改善取り組み者名
                Else
                    Call lIncongMsg.addString(CPstrIMPRO_EMP_NAME, CPstrMsgNull)
                End If

                If .strImproDate <> vbNullString Then
                    Call lIncongMsg.addString(CPstrIMPRO_DATE, .strImproDate)                            '改善取り組み日時
                Else
                    Call lIncongMsg.addString(CPstrIMPRO_DATE, CPstrMsgNull)
                End If
                
                '@不適合品用 ｱﾚｲに格納
                Call lIncongArray.Add(lIncongMsg)
                '@使用構造体のｸﾘｱ処理
                Call lIncongMsg.Clear


                '<LOT_LIST> 対象ﾛｯﾄﾘｽﾄの生成
                '@*************************************************************************************
                '@　対象ﾛｯﾄの情報を一括りにして，存在するﾛｯﾄ数分をｱﾚｰ構造に押し込む。
                '@
                '@  lLotlistArray
                '@        |--------- lLotlistMsg   ﾛｯﾄ 1
                '@        |--------- lLotlistMsg   ﾛｯﾄ 2
                '@        |      :
                '@        |--------- lLotlistMsg   ﾛｯﾄ n
                '@
                '@*************************************************************************************
                '@ 対象総数量反映用変数の初期化
                lintTotalTargetQuantity = 0

                '対象ﾛｯﾄが存在するならば，GO
                If .lngExcpReportLotListCnt > 0 Then

                    '存在するﾛｯﾄ数分を繰り返す
                    For llngCnt = 0 To .lngExcpReportLotListCnt - 1

                        ' strTargetQuantity値の積算
                        lintTotalTargetQuantity = lintTotalTargetQuantity + CInt(.typExcpLotList(llngCnt).strTargetQuantity)

                        If .typExcpLotList(llngCnt).strLotID <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrLOT_ID, .typExcpLotList(llngCnt).strLotID)                            'ﾛｯﾄID
                        Else
                            Call lLotlistMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strTargetQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrTARGET_QUANTITY, .typExcpLotList(llngCnt).strTargetQuantity)          '対象数量
                        Else
                            Call lLotlistMsg.addString(CPstrTARGET_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strTotalQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrTOTAL_QUANTITY, .typExcpLotList(llngCnt).strTotalQuantity)            '合計数量
                        Else
                            Call lLotlistMsg.addString(CPstrTOTAL_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strReserveQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrRESERVE_QUANTITY, .typExcpLotList(llngCnt).strReserveQuantity)        '保留
                        Else
                            Call lLotlistMsg.addString(CPstrRESERVE_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strAbandonQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrABANDON_QUANTITY, .typExcpLotList(llngCnt).strAbandonQuantity)        '廃却
                        Else
                            Call lLotlistMsg.addString(CPstrABANDON_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strAmendQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrAMEND_QUANTITY, .typExcpLotList(llngCnt).strAmendQuantity)            '手直し
                        Else
                            Call lLotlistMsg.addString(CPstrAMEND_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strCorrectQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrCORRECT_QUANTITY, .typExcpLotList(llngCnt).strCorrectQuantity)        '修正
                        Else
                            Call lLotlistMsg.addString(CPstrCORRECT_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strUsualQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrUSUAL_QUANTITY, .typExcpLotList(llngCnt).strUsualQuantity)            '通常
                        Else
                            Call lLotlistMsg.addString(CPstrUSUAL_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strEvalQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrEVAL_QUANTITY, .typExcpLotList(llngCnt).strEvalQuantity)              '評価
                        Else
                            Call lLotlistMsg.addString(CPstrEVAL_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strTakeQuantity <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrTAKE_QUANTITY, .typExcpLotList(llngCnt).strTakeQuantity)              '特採
                        Else
                            Call lLotlistMsg.addString(CPstrTAKE_QUANTITY, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strDisposalFlag <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrDISPOSAL_FLAG, .typExcpLotList(llngCnt).strDisposalFlag)              '処置ﾌﾗｸﾞ
                        Else
                            Call lLotlistMsg.addString(CPstrDISPOSAL_FLAG, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strAppendFlag <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrAPPEND_FLAG, .typExcpLotList(llngCnt).strAppendFlag)                  'ﾛｯﾄ追加ﾌﾗｸﾞ
                        Else
                            Call lLotlistMsg.addString(CPstrAPPEND_FLAG, CPstrMsgNull)
                        End If
                        
                        If .typExcpLotList(llngCnt).strEditTime <> vbNullString Then
                            Call lLotlistMsg.addString(CPstrEDIT_TIME, .typExcpLotList(llngCnt).strEditTime)                      '最終更新日時
                        Else
                            Call lLotlistMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                        End If
                        
                        '@LOT_LIST ｱﾚｲに格納
                        Call lLotlistArray.Add(lLotlistMsg)
                        '使用領域解放
                        Call lLotlistMsg.Clear
                    Next llngCnt
                End If


                '<excp.chgreport> 工程異常・不適合品処理票 登録／更新ﾒｯｾｰｼﾞの生成
                '@*************************************************************************************
                '@ 工程異常・不適合品処理票 登録／更新ﾒｯｾｰｼﾞ
                '@
                '@   excp.chgreport
                '@         |
                '@         |---lMainMsg --- lIncongArray --- lLotlistArray
                '@
                '@*************************************************************************************
                '
                If .strSbID <> vbNullString Then
                    Call lMainMsg.addString(CPstrSB_ID, .strSbID)                          'SB_ID
                Else
                    Call lMainMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                If .strMsgVer <> vbNullString Then
                    Call lMainMsg.addString(CPstrMSG_VER, .strMsgVer)                      'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lMainMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                If .strHoldFlag <> vbNullString Then
                    Call lMainMsg.addString(CPstrHOLD_FLAG, .strHoldFlag)                  '保留ﾌﾗｸﾞ
                Else
                    Call lMainMsg.addString(CPstrHOLD_FLAG, CPstrMsgNull)
                End If

                If .strExcpNo <> vbNullString Then
                    Call lMainMsg.addString(CPstrEXCP_NO, .strExcpNo)                      '異常処理№
                Else
                    Call lMainMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
                End If

                If .strFindDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_DATE, .strFindDate)                  '発見日時
                Else
                    Call lMainMsg.addString(CPstrFIND_DATE, CPstrMsgNull)
                End If

                If .strFindDeptID <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_DEPT_ID, .strFindDeptID)             '発見所属ID
                Else
                    Call lMainMsg.addString(CPstrFIND_DEPT_ID, CPstrMsgNull)
                End If

                If .strFindDeptName <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_DEPT_NAME, .strFindDeptName)         '発見所属名
                Else
                    Call lMainMsg.addString(CPstrFIND_DEPT_NAME, CPstrMsgNull)
                End If

                If .strFindEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_EMP_ID, .strFindEmpID)                    '発見者ID
                Else
                    Call lMainMsg.addString(CPstrFIND_EMP_ID, CPstrMsgNull)
                End If

                If .strFindEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_EMP_NAME, .strFindEmpName)                '発見者名
                Else
                    Call lMainMsg.addString(CPstrFIND_EMP_NAME, CPstrMsgNull)
                End If

                If .strFindTelNo <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_TEL_NO, .strFindTelNo)                    '発見者Tel
                Else
                    Call lMainMsg.addString(CPstrFIND_TEL_NO, CPstrMsgNull)
                End If

                If .strDocClass <> vbNullString Then
                    Call lMainMsg.addString(CPstrDOC_CLASS, .strDocClass)                       '帳票種別
                Else
                    Call lMainMsg.addString(CPstrDOC_CLASS, CPstrMsgNull)
                End If

                If .strExcpItemName <> vbNullString Then
                    Call lMainMsg.addString(CPstrEXCP_ITEM_NAME, .strExcpItemName)              '工程異常名
                Else
                    Call lMainMsg.addString(CPstrEXCP_ITEM_NAME, CPstrMsgNull)
                End If

                If .strExcpItemNo <> vbNullString Then
                    Call lMainMsg.addString(CPstrEXCP_ITEM_NO, .strExcpItemNo)                  '工程異常項目ﾌﾗｸﾞ
                Else
                    Call lMainMsg.addString(CPstrEXCP_ITEM_NO, CPstrMsgNull)
                End If

                If .strExcpItemOthr <> vbNullString Then
                    Call lMainMsg.addString(CPstrEXCP_ITEM_OTHR, .strExcpItemOthr)              '工程異常項目その他内容
                Else
                    Call lMainMsg.addString(CPstrEXCP_ITEM_OTHR, CPstrMsgNull)
                End If

                If .strTargetPDID <> vbNullString Then
                    Call lMainMsg.addString(CPstrTARGET_PD_ID, .strTargetPDID)                  '機種ID
                Else
                    Call lMainMsg.addString(CPstrTARGET_PD_ID, CPstrMsgNull)
                End If


                ' LOT_LIST 内，strTargetQuantity の総数を反映 <案件No.02755>
                If lintTotalTargetQuantity <> 0 Then
                    Call lMainMsg.addString(CPstrTARGET_QUANTITY, CStr(lintTotalTargetQuantity))      '対象総数量数
                Else
                    Call lMainMsg.addString(CPstrTARGET_QUANTITY, CPstrMsgNull)
                End If

                If .strTargetUnit <> vbNullString Then
                    Call lMainMsg.addString(CPstrTARGET_UNIT, .strTargetUnit)                   '単位
                Else
                    Call lMainMsg.addString(CPstrTARGET_UNIT, CPstrMsgNull)
                End If

                If .strFindOpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_OP_ID, .strFindOpID)                      '発見大工程
                Else
                    Call lMainMsg.addString(CPstrFIND_OP_ID, CPstrMsgNull)
                End If

                If .strFindStepID <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_STEP_ID, .strFindStepID)                  '発見小工程
                Else
                    Call lMainMsg.addString(CPstrFIND_STEP_ID, CPstrMsgNull)
                End If

                If .strFindWpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_WP_ID, .strFindWpID)                      '発見装置ID
                Else
                    Call lMainMsg.addString(CPstrFIND_WP_ID, CPstrMsgNull)
                End If

                If .strFindWpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrFIND_WP_NAME, .strFindWpName)                  '発見装置名
                Else
                    Call lMainMsg.addString(CPstrFIND_WP_NAME, CPstrMsgNull)
                End If

                If .strExcpSituation <> vbNullString Then
                    Call lMainMsg.addString(CPstrEXCP_SITUATION, .strExcpSituation)             '工程異常発生状況ｺﾒﾝﾄ
                Else
                    Call lMainMsg.addString(CPstrEXCP_SITUATION, CPstrMsgNull)
                End If

                If .strIncongFlag <> vbNullString Then
                    Call lMainMsg.addString(CPstrINCONG_FLAG, .strIncongFlag)                   '不適合品発生有無
                Else
                    Call lMainMsg.addString(CPstrINCONG_FLAG, CPstrMsgNull)
                End If

                If .strExcpDetailComments <> vbNullString Then
                    Call lMainMsg.addString(CPstrEXCP_DETAIL_COMMENTS, .strExcpDetailComments)          '異常内容評価ｺﾒﾝﾝﾄ
                Else
                    Call lMainMsg.addString(CPstrEXCP_DETAIL_COMMENTS, CPstrMsgNull)
                End If

                If .strInflFlag <> vbNullString Then
                    Call lMainMsg.addString(CPstrINFL_FLAG, .strInflFlag)                               '後工程/信頼性影響
                Else
                    Call lMainMsg.addString(CPstrINFL_FLAG, CPstrMsgNull)
                End If

                If .strTechInflContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INFL_CONTENTS, .strTechInflContents)              '技術部門処置内容
                Else
                    Call lMainMsg.addString(CPstrTECH_INFL_CONTENTS, CPstrMsgNull)
                End If

                If .strTechInflEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INFL_EMP_ID, .strTechInflEmpID)                   '技術部門処置者ID
                Else
                    Call lMainMsg.addString(CPstrTECH_INFL_EMP_ID, CPstrMsgNull)
                End If

                If .strTechInflEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INFL_EMP_NAME, .strTechInflEmpName)               '技術部門処置者名
                Else
                    Call lMainMsg.addString(CPstrTECH_INFL_EMP_NAME, CPstrMsgNull)
                End If

                If .strTechInflDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INFL_DATE, .strTechInflDate)                      '技術部門処置日時
                Else
                    Call lMainMsg.addString(CPstrTECH_INFL_DATE, CPstrMsgNull)
                End If

                If .strManuInflContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INFL_CONTENTS, .strManuInflContents)              '製造部門処置内容
                Else
                    Call lMainMsg.addString(CPstrMANU_INFL_CONTENTS, CPstrMsgNull)
                End If

                If .strManuInflEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INFL_EMP_ID, .strManuInflEmpID)                   '製造部門処置者ID
                Else
                    Call lMainMsg.addString(CPstrMANU_INFL_EMP_ID, CPstrMsgNull)
                End If

                If .strManuInflEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INFL_EMP_NAME, .strManuInflEmpName)               '製造部門処置者名
                Else
                    Call lMainMsg.addString(CPstrMANU_INFL_EMP_NAME, CPstrMsgNull)
                End If

                If .strManuInflDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INFL_DATE, .strManuInflDate)                      '製造部門処置日時
                Else
                    Call lMainMsg.addString(CPstrMANU_INFL_DATE, CPstrMsgNull)
                End If

                If .strOthrInflContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INFL_CONTENTS, .strOthrInflContents)              'その他部門処置内容
                Else
                    Call lMainMsg.addString(CPstrOTHR_INFL_CONTENTS, CPstrMsgNull)
                End If

                If .strOthrInflEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INFL_EMP_ID, .strOthrInflEmpID)                   'その他部門処置者ID
                Else
                    Call lMainMsg.addString(CPstrOTHR_INFL_EMP_ID, CPstrMsgNull)
                End If

                If .strOthrInflEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INFL_EMP_NAME, .strOthrInflEmpName)               'その他部門処置者名
                Else
                    Call lMainMsg.addString(CPstrOTHR_INFL_EMP_NAME, CPstrMsgNull)
                End If

                If .strOthrInflDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INFL_DATE, .strOthrInflDate)                      'その他部門処置日時
                Else
                    Call lMainMsg.addString(CPstrOTHR_INFL_DATE, CPstrMsgNull)
                End If

                If .strTechInvestContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INVEST_CONTENTS, .strTechInvestContents)          '技術部門調査内容
                Else
                    Call lMainMsg.addString(CPstrTECH_INVEST_CONTENTS, CPstrMsgNull)
                End If

                If .strTechInvestEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INVEST_EMP_ID, .strTechInvestEmpID)               '技術部門調査者ID
                Else
                    Call lMainMsg.addString(CPstrTECH_INVEST_EMP_ID, CPstrMsgNull)
                End If

                If .strTechInvestEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INVEST_EMP_NAME, .strTechInvestEmpName)           '技術部門調査者名
                Else
                    Call lMainMsg.addString(CPstrTECH_INVEST_EMP_NAME, CPstrMsgNull)
                End If

                If .strTechInvestDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INVEST_DATE, .strTechInvestDate)                  '技術部門調査日時
                Else
                    Call lMainMsg.addString(CPstrTECH_INVEST_DATE, CPstrMsgNull)
                End If

                If .strManuInvestContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INVEST_CONTENTS, .strManuInvestContents)          '製造部門調査内容
                Else
                    Call lMainMsg.addString(CPstrMANU_INVEST_CONTENTS, CPstrMsgNull)
                End If

                If .strManuInvestEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INVEST_EMP_ID, .strManuInvestEmpID)               '製造部門調査者ID
                Else
                    Call lMainMsg.addString(CPstrMANU_INVEST_EMP_ID, CPstrMsgNull)
                End If

                If .strManuInvestEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INVEST_EMP_NAME, .strManuInvestEmpName)           '製造部門調査者名
                Else
                    Call lMainMsg.addString(CPstrMANU_INVEST_EMP_NAME, CPstrMsgNull)
                End If

                If .strManuInvestDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INVEST_DATE, .strManuInvestDate)                  '製造部門調査日時
                Else
                    Call lMainMsg.addString(CPstrMANU_INVEST_DATE, CPstrMsgNull)
                End If

                If .strOthrInvestContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INVEST_CONTENTS, .strOthrInvestContents)          'その他部門調査内容
                Else
                    Call lMainMsg.addString(CPstrOTHR_INVEST_CONTENTS, CPstrMsgNull)
                End If

                If .strOthrInvestEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INVEST_EMP_ID, .strOthrInvestEmpID)               'その他部門調査者ID
                Else
                    Call lMainMsg.addString(CPstrOTHR_INVEST_EMP_ID, CPstrMsgNull)
                End If

                If .strOthrInvestEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INVEST_EMP_NAME, .strOthrInvestEmpName)           'その他部門調査者名
                Else
                    Call lMainMsg.addString(CPstrOTHR_INVEST_EMP_NAME, CPstrMsgNull)
                End If

                If .strOthrInvestDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INVEST_DATE, .strOthrInvestDate)                  'その他部門調査日時
                Else
                    Call lMainMsg.addString(CPstrOTHR_INVEST_DATE, CPstrMsgNull)
                End If

                If .strTechIndicateContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INDICATE_CONTENTS, .strTechIndicateContents)      '技術部門指示内容
                Else
                    Call lMainMsg.addString(CPstrTECH_INDICATE_CONTENTS, CPstrMsgNull)
                End If

                If .strTechIndicateEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INDICATE_EMP_ID, .strTechIndicateEmpID)           '技術部門指示者ID
                Else
                    Call lMainMsg.addString(CPstrTECH_INDICATE_EMP_ID, CPstrMsgNull)
                End If

                If .strTechIndicateEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INDICATE_EMP_NAME, .strTechIndicateEmpName)       '技術部門指示者名
                Else
                    Call lMainMsg.addString(CPstrTECH_INDICATE_EMP_NAME, CPstrMsgNull)
                End If

                If .strTechIndicateDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrTECH_INDICATE_DATE, .strTechIndicateDate)              '技術部門指示日時
                Else
                    Call lMainMsg.addString(CPstrTECH_INDICATE_DATE, CPstrMsgNull)
                End If

                If .strManuIndicateContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INDICATE_CONTENTS, .strManuIndicateContents)      '製造部門指示内容
                Else
                    Call lMainMsg.addString(CPstrMANU_INDICATE_CONTENTS, CPstrMsgNull)
                End If

                If .strManuIndicateEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INDICATE_EMP_ID, .strManuIndicateEmpID)           '製造部門指示者ID
                Else
                    Call lMainMsg.addString(CPstrMANU_INDICATE_EMP_ID, CPstrMsgNull)
                End If

                If .strManuIndicateEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INDICATE_EMP_NAME, .strManuIndicateEmpName)       '製造部門指示者名
                Else
                    Call lMainMsg.addString(CPstrMANU_INDICATE_EMP_NAME, CPstrMsgNull)
                End If

                If .strManuIndicateDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrMANU_INDICATE_DATE, .strManuIndicateDate)              '製造部門指示日時
                Else
                    Call lMainMsg.addString(CPstrMANU_INDICATE_DATE, CPstrMsgNull)
                End If

                If .strOthrIndicateContents <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INDICATE_CONTENTS, .strOthrIndicateContents)      'その他部門指示内容
                Else
                    Call lMainMsg.addString(CPstrOTHR_INDICATE_CONTENTS, CPstrMsgNull)
                End If

                If .strOthrIndicateEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INDICATE_EMP_ID, .strOthrIndicateEmpID)           'その他部門指示者ID
                Else
                    Call lMainMsg.addString(CPstrOTHR_INDICATE_EMP_ID, CPstrMsgNull)
                End If

                If .strOthrIndicateEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INDICATE_EMP_NAME, .strOthrIndicateEmpName)       'その他部門指示者名
                Else
                    Call lMainMsg.addString(CPstrOTHR_INDICATE_EMP_NAME, CPstrMsgNull)
                End If

                If .strOthrIndicateDate <> vbNullString Then
                    Call lMainMsg.addString(CPstrOTHR_INDICATE_DATE, .strOthrIndicateDate)              'その他部門指示日時
                Else
                    Call lMainMsg.addString(CPstrOTHR_INDICATE_DATE, CPstrMsgNull)
                End If

                If .strCauseWpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrCAUSE_WP_ID, .strCauseWpID)                           '原因装置ID
                Else
                    Call lMainMsg.addString(CPstrCAUSE_WP_ID, CPstrMsgNull)
                End If

                If .strCauseWpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrCAUSE_WP_NAME, .strCauseWpName)                       '原因装置名
                Else
                    Call lMainMsg.addString(CPstrCAUSE_WP_NAME, CPstrMsgNull)
                End If

                If .strCauseSeriesName <> vbNullString Then
                    Call lMainMsg.addString(CPstrCAUSE_SERIES_NAME, .strCauseSeriesName)               '原因系列名
                Else
                    Call lMainMsg.addString(CPstrCAUSE_SERIES_NAME, CPstrMsgNull)
                End If

                If .strCauseClassName <> vbNullString Then
                    Call lMainMsg.addString(CPstrCAUSE_CLASS_NAME, .strCauseClassName)                 '原因区分名
                Else
                    Call lMainMsg.addString(CPstrCAUSE_CLASS_NAME, CPstrMsgNull)
                End If


                '@*************************************************************************************
                '@ 承認情報の追加処理
                '@*************************************************************************************
                '@全処置ﾌﾗｸﾞ
                If .strAllDisposalFlag <> vbNullString Then
                    Call lMainMsg.addString(CPstrALL_DISPOSAL_FLAG, .strAllDisposalFlag)           '全処置ﾌﾗｸﾞ
                Else
                    Call lMainMsg.addString(CPstrALL_DISPOSAL_FLAG, CPstrMsgNull)
                End If

                '@承認ﾌﾗｸﾞ
                If .strApprovalFlag <> vbNullString Then
                    Call lMainMsg.addString(CPstrAPPROVAL_FLAG, .strApprovalFlag)                  '承認ﾌﾗｸﾞ
                Else
                    Call lMainMsg.addString(CPstrAPPROVAL_FLAG, CPstrMsgNull)
                End If

                '@承認者ID
                If .strApprovalEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrAPPROVAL_EMP_ID, .strApprovalEmpID)               '承認者ID
                Else
                    Call lMainMsg.addString(CPstrAPPROVAL_EMP_ID, CPstrMsgNull)
                End If

                '@承認者名
                If .strApprovalEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrAPPROVAL_EMP_NAME, .strApprovalEmpName)           '承認者名
                Else
                    Call lMainMsg.addString(CPstrAPPROVAL_EMP_NAME, CPstrMsgNull)
                End If

                '@更新者ID
                If .strEmpID <> vbNullString Then
                    Call lMainMsg.addString(CPstrEMP_ID, .strEmpID)                                '更新者ID
                Else
                    Call lMainMsg.addString(CPstrEMP_ID, CPstrMsgNull)
                End If

                '@更新者名
                If .strEmpName <> vbNullString Then
                    Call lMainMsg.addString(CPstrEMP_NAME, .strEmpName)                            '更新者名
                Else
                    Call lMainMsg.addString(CPstrEMP_NAME, CPstrMsgNull)
                End If

                '@更新日時
                If .strEditTime <> vbNullString Then
                    Call lMainMsg.addString(CPstrEDIT_TIME, .strEditTime)                          '更新日時
                Else
                    Call lMainMsg.addString(CPstrEDIT_TIME, CPstrMsgNull)
                End If

                '@登録日時
                If .strEntryTime <> vbNullString Then
                    Call lMainMsg.addString(CPstrENTRY_TIME, .strEntryTime)                        '登録日時
                Else
                    Call lMainMsg.addString(CPstrENTRY_TIME, CPstrMsgNull)
                End If


                '@*************************************************************************************
                '@ excp.chgreport の完成処理
                '@*************************************************************************************
                '@MainMsg に INCONG_LIST ｱﾚｲの内容を格納
                Call lMainMsg.addMsgAry(CPstrINCONG_LIST, lIncongArray)

                '@MainMsg に LOT_LIST ｱﾚｲの内容を格納
                Call lMainMsg.addMsgAry(CPstrLOT_LIST, lLotlistArray)

                '使用領域の開放
                Call lIncongArray.Clear
                Call lLotlistArray.Clear

            End With


            '@*************************************************************************************
            '@ excp.chgreport ﾒｯｾｰｼﾞ送信
            '@*************************************************************************************
            Call pTerm.sendRequest(CPstrexcpchgreport, lMainMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    Call laMsg.getString(CPstrEDIT_TIME, ltypExcpReport.strEditTime)        '最終更新日時
                    Call laMsg.getString(CPstrEXCP_NO, ltypExcpReport.strExcpNo)            '異常処理№
                    Call laMsg.getString(CPstrMSG, lstrGuidMsg)                             'ｶﾞｲﾀﾞﾝｽMsg
                    Call laMsg.getString(CPstrMSG_CODE, lstrGuidMsgCode)                    'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ

                    '@関数の処理結果(成功)格納
                    pubblnExcpChgReport_Upd = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypExcpReport.strMsgVer)

                '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
                    '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            
            End Select

            '@ﾒｯｾｰｼﾞ構造体のｸﾘｱ
            lMainMsg = Nothing
            lIncongMsg = Nothing
            lIncongArray = Nothing
            lLotlistMsg = Nothing
            lLotlistArray = Nothing
            laMsg = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

            '@ﾒｯｾｰｼﾞ構造体のｸﾘｱ
            lMainMsg = Nothing
            lIncongMsg = Nothing
            lIncongArray = Nothing
            lLotlistMsg = Nothing
            lLotlistArray = Nothing
            laMsg = Nothing

        End Try
    End Function


    '関数名：pubblnExcpReportInfo_Sel
    '機　能：工程異常/不適合品処理票取得処理
    '引　数：ltypExcpReport  ：工程異常不適合品登録・更新構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/08/08 (Mon) 10:00:32 S.Deguchi
    '更新日：2005/08/08 (Mon) 10:00:32
    '備　考：
    Public Function pubblnExcpReportInfo_Sel(ByRef ltypExcpReport As ExcpReport) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        
        Try
            
            pstrMessageName = "工程異常/不適合品処理票取得"
            pubblnExcpReportInfo_Sel = False
            
            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            ltMsg1 = New TfMsg
            laAry = New TfMsgAry
            
            '@送信ﾒｯｾｰｼﾞ作成
            With ltypExcpReport
                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                                      'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If
                
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                                  'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If
                
                If .strExcpNo <> vbNullString Then
                    Call lrMsg.addString(CPstrEXCP_NO, .strExcpNo)                                  '異常処理№
                Else
                    Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
                End If
            End With
                
            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpreportinfo, lrMsg, laMsg)
            
            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)
            
            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果取得
                    With ltypExcpReport
                        Call laMsg.getString(CPstrFIND_DATE, .strFindDate)                              '発見日時
                        Call laMsg.getString(CPstrFIND_DEPT_ID, .strFindDeptID)                         '発見所属ID
                        Call laMsg.getString(CPstrFIND_DEPT_NAME, .strFindDeptName)                     '発見所属名
                        Call laMsg.getString(CPstrFIND_EMP_ID, .strFindEmpID)                           '発見者ID
                        Call laMsg.getString(CPstrFIND_EMP_NAME, .strFindEmpName)                       '発見者名
                        Call laMsg.getString(CPstrFIND_TEL_NO, .strFindTelNo)                           '発見者Tel
                        Call laMsg.getString(CPstrDOC_CLASS, .strDocClass)                              '帳票種別
                        Call laMsg.getString(CPstrEXCP_ITEM_NAME, .strExcpItemName)                     '工程異常名
                        Call laMsg.getString(CPstrEXCP_ITEM_NO, .strExcpItemNo)                         '工程異常項目ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrEXCP_ITEM_OTHR, .strExcpItemOthr)                     '工程異常項目その他内容
                        Call laMsg.getString(CPstrTARGET_PD_ID, .strTargetPDID)                         '機種ID
                        Call laMsg.getString(CPstrTARGET_QUANTITY, .strTargetQuantity)                  '対象数量数
                        Call laMsg.getString(CPstrTARGET_UNIT, .strTargetUnit)                          '単位
                        Call laMsg.getString(CPstrFIND_OP_ID, .strFindOpID)                             '発見大工程
                        Call laMsg.getString(CPstrFIND_STEP_ID, .strFindStepID)                         '発見小工程
                        Call laMsg.getString(CPstrFIND_WP_ID, .strFindWpID)                             '発見装置ID
                        Call laMsg.getString(CPstrFIND_WP_NAME, .strFindWpName)                         '発見装置名
                        Call laMsg.getString(CPstrEXCP_SITUATION, .strExcpSituation)                    '工程異常発生状況ｺﾒﾝﾄ
                        Call laMsg.getString(CPstrINCONG_FLAG, .strIncongFlag)                          '不適合品発生有無
                        Call laMsg.getString(CPstrEXCP_DETAIL_COMMENTS, .strExcpDetailComments)         '異常内容評価ｺﾒﾝﾝﾄ
                        Call laMsg.getString(CPstrINFL_FLAG, .strInflFlag)                              '後工程/信頼性影響
                        Call laMsg.getString(CPstrTECH_INFL_CONTENTS, .strTechInflContents)             '技術部門処置内容
                        Call laMsg.getString(CPstrTECH_INFL_EMP_ID, .strTechInflEmpID)                  '技術部門処置者ID
                        Call laMsg.getString(CPstrTECH_INFL_EMP_NAME, .strTechInflEmpName)              '技術部門処置者名
                        Call laMsg.getString(CPstrTECH_INFL_DATE, .strTechInflDate)                     '技術部門処置日時
                        Call laMsg.getString(CPstrMANU_INFL_CONTENTS, .strManuInflContents)             '製造部門処置内容
                        Call laMsg.getString(CPstrMANU_INFL_EMP_ID, .strManuInflEmpID)                  '製造部門処置者ID
                        Call laMsg.getString(CPstrMANU_INFL_EMP_NAME, .strManuInflEmpName)              '製造部門処置者名
                        Call laMsg.getString(CPstrMANU_INFL_DATE, .strManuInflDate)                     '製造部門処置日時
                        Call laMsg.getString(CPstrOTHR_INFL_CONTENTS, .strOthrInflContents)             'その他部門処置内容
                        Call laMsg.getString(CPstrOTHR_INFL_EMP_ID, .strOthrInflEmpID)                  'その他部門処置者ID
                        Call laMsg.getString(CPstrOTHR_INFL_EMP_NAME, .strOthrInflEmpName)              'その他部門処置者名
                        Call laMsg.getString(CPstrOTHR_INFL_DATE, .strOthrInflDate)                     'その他部門処置日時
                        Call laMsg.getString(CPstrTECH_INVEST_CONTENTS, .strTechInvestContents)         '技術部門調査内容
                        Call laMsg.getString(CPstrTECH_INVEST_EMP_ID, .strTechInvestEmpID)              '技術部門調査者ID
                        Call laMsg.getString(CPstrTECH_INVEST_EMP_NAME, .strTechInvestEmpName)          '技術部門調査者名
                        Call laMsg.getString(CPstrTECH_INVEST_DATE, .strTechInvestDate)                 '技術部門調査日時
                        Call laMsg.getString(CPstrMANU_INVEST_CONTENTS, .strManuInvestContents)         '製造部門調査内容
                        Call laMsg.getString(CPstrMANU_INVEST_EMP_ID, .strManuInvestEmpID)              '製造部門調査者ID
                        Call laMsg.getString(CPstrMANU_INVEST_EMP_NAME, .strManuInvestEmpName)          '製造部門調査者名
                        Call laMsg.getString(CPstrMANU_INVEST_DATE, .strManuInvestDate)                 '製造部門調査日時
                        Call laMsg.getString(CPstrOTHR_INVEST_CONTENTS, .strOthrInvestContents)         'その他部門調査内容
                        Call laMsg.getString(CPstrOTHR_INVEST_EMP_ID, .strOthrInvestEmpID)              'その他部門調査者ID
                        Call laMsg.getString(CPstrOTHR_INVEST_EMP_NAME, .strOthrInvestEmpName)          'その他部門調査者名
                        Call laMsg.getString(CPstrOTHR_INVEST_DATE, .strOthrInvestDate)                 'その他部門調査日時
                        Call laMsg.getString(CPstrTECH_INDICATE_CONTENTS, .strTechIndicateContents)     '技術部門指示内容
                        Call laMsg.getString(CPstrTECH_INDICATE_EMP_ID, .strTechIndicateEmpID)          '技術部門指示者ID
                        Call laMsg.getString(CPstrTECH_INDICATE_EMP_NAME, .strTechIndicateEmpName)      '技術部門指示者名
                        Call laMsg.getString(CPstrTECH_INDICATE_DATE, .strTechIndicateDate)             '技術部門指示日時
                        Call laMsg.getString(CPstrMANU_INDICATE_CONTENTS, .strManuIndicateContents)     '製造部門指示内容
                        Call laMsg.getString(CPstrMANU_INDICATE_EMP_ID, .strManuIndicateEmpID)          '製造部門指示者ID
                        Call laMsg.getString(CPstrMANU_INDICATE_EMP_NAME, .strManuIndicateEmpName)      '製造部門指示者名
                        Call laMsg.getString(CPstrMANU_INDICATE_DATE, .strManuIndicateDate)             '製造部門指示日時
                        Call laMsg.getString(CPstrOTHR_INDICATE_CONTENTS, .strOthrIndicateContents)     'その他部門指示内容
                        Call laMsg.getString(CPstrOTHR_INDICATE_EMP_ID, .strOthrIndicateEmpID)          'その他部門指示者ID
                        Call laMsg.getString(CPstrOTHR_INDICATE_EMP_NAME, .strOthrIndicateEmpName)      'その他部門指示者名
                        Call laMsg.getString(CPstrOTHR_INDICATE_DATE, .strOthrIndicateDate)             'その他部門指示日時
                        
                        '@ｱﾚｲを格納
                        Call laMsg.getMsgAry(CPstrINCONG_LIST, laAry)                                   '不適合品ﾘｽﾄ
                        '@ｱﾚｰの各要素取得
                        For Each ltMsg In laAry
                            Call ltMsg.getString(CPstrINCONG_ITEM_NAME, .strIncongItemName)                 '不良特性名
                            Call ltMsg.getString(CPstrTECH_CHECK_CONTENTS, .strTechCheckContents)           '技術部門確認内容
                            Call ltMsg.getString(CPstrTECH_CHECK_EMP_ID, .strTechCheckEmpID)                '技術部門確認者ID
                            Call ltMsg.getString(CPstrTECH_CHECK_EMP_NAME, .strTechCheckEmpName)            '技術部門確認者名
                            Call ltMsg.getString(CPstrTECH_CHECK_DATE, .strTechCheckDate)                   '技術部門確認日時
                            Call ltMsg.getString(CPstrMANU_CHECK_CONTENTS, .strManuCheckContents)           '製造部門確認内容
                            Call ltMsg.getString(CPstrMANU_CHECK_EMP_ID, .strManuCheckEmpID)                '製造部門確認者ID
                            Call ltMsg.getString(CPstrMANU_CHECK_EMP_NAME, .strManuCheckEmpName)            '製造部門確認者名
                            Call ltMsg.getString(CPstrMANU_CHECK_DATE, .strManuCheckDate)                   '製造部門確認日時
                            Call ltMsg.getString(CPstrOTHR_CHECK_CONTENTS, .strOthrCheckContents)           'その他部門確認内容
                            Call ltMsg.getString(CPstrOTHR_CHECK_EMP_ID, .strOthrCheckEmpID)                'その他部門確認者ID
                            Call ltMsg.getString(CPstrOTHR_CHECK_EMP_NAME, .strOthrCheckEmpName)            'その他部門確認者名
                            Call ltMsg.getString(CPstrOTHR_CHECK_DATE, .strOthrCheckDate)                   'その他部門確認日時
                            Call ltMsg.getString(CPstrINCONG_JUDGE_VOLUME, .strIncongJudgeVolume)           '不適合品発生量ﾌﾗｸﾞ
                            Call ltMsg.getString(CPstrINCONG_JUDGE_EMP_ID, .strIncongJudgeEmpID)            '不適合品発生判定者ID
                            Call ltMsg.getString(CPstrINCONG_JUDGE_EMP_NAME, .strIncongJudgeEmpName)        '不適合品発生判定者名
                            Call ltMsg.getString(CPstrINCONG_JUDGE_DATE, .strIncongJudgeDate)               '不適合品発生判定日時
                            Call ltMsg.getString(CPstrDISPO_SCRAP_FLAG, .strDispoScrapFlag)                 '現品廃却ﾌﾗｸﾞ
                            Call ltMsg.getString(CPstrDISPO_MODIFY_FLAG, .strDispoMdifyFlag)                '現品手直しﾌﾗｸﾞ
                            Call ltMsg.getString(CPstrDISPO_PICK_FLAG, .strDispoPickFlag)                   '現品特採ﾌﾗｸﾞ
                            Call ltMsg.getString(CPstrDISPO_REGULAR_FLAG, .strDispoRegularFlag)             '現品通常ﾌﾗｸﾞ
                            Call ltMsg.getString(CPstrDISPO_AMEND_FLAG, .strDispoAmendFlag)                 '現品修正ﾌﾗｸﾞ
                            Call ltMsg.getString(CPstrDISPO_RATING_FLAG, .strDispoRatingFlag)               '現品評価ﾌﾗｸﾞ
                            Call ltMsg.getString(CPstrDISPO_CONTENTS, .strDispoContents)                    '現品処理内容
                            Call ltMsg.getString(CPstrDISPO_INDICATE_EMP_ID, .strDispoIndicateEmpID)        '現品処理指示者ID
                            Call ltMsg.getString(CPstrDISPO_INDICATE_EMP_NAME, .strDispoIndicateEmpName)    '現品処理指示者名
                            Call ltMsg.getString(CPstrDISPO_INDICATE_DATE, .strDispoIndicateDate)           '現品処理指示日時
                            Call ltMsg.getString(CPstrIMPRO_KIND, .strImproKind)                            '改善取り組み
                            Call ltMsg.getString(CPstrIMPRO_CONTENTS, .strImproContents)                    '改善取り組み内容
                            Call ltMsg.getString(CPstrIMPRO_EMP_ID, .strImproEmpID)                         '改善取り組み者ID
                            Call ltMsg.getString(CPstrIMPRO_EMP_NAME, .strImproEmpName)                     '改善取り組み者名
                            Call ltMsg.getString(CPstrIMPRO_DATE, .strImproDate)                            '改善取り組み日時
                        Next
            
                        '@取得ｱﾚｲ,Tempをｸﾘｱ
                        Call laAry.Clear
                        
                        Call laMsg.getString(CPstrCAUSE_WP_ID, .strCauseWpID)                           '原因装置ID
                        Call laMsg.getString(CPstrCAUSE_WP_NAME, .strCauseWpName)                       '原因装置名
                        Call laMsg.getString(CPstrCAUSE_SERIES_NAME, .strCauseSeriesName)               '原因系列名
                        Call laMsg.getString(CPstrCAUSE_CLASS_NAME, .strCauseClassName)                 '原因区分名
                        Call laMsg.getString(CPstrAPPROVAL_FLAG, .strApprovalFlag)                      '承認ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrALL_DISPOSAL_FLAG, .strAllDisposalFlag)               '全処置ﾌﾗｸﾞ
                        Call laMsg.getString(CPstrAPPROVAL_EMP_ID, .strApprovalEmpID)                   '承認者ID
                        Call laMsg.getString(CPstrAPPROVAL_EMP_NAME, .strApprovalEmpName)               '承認者名
                        Call laMsg.getString(CPstrEMP_ID, .strEmpID)                                    '更新者ID
                        Call laMsg.getString(CPstrEMP_NAME, .strEmpName)                                '更新者名
                        Call laMsg.getString(CPstrEDIT_TIME, .strEditTime)                              '更新日時
                        Call laMsg.getString(CPstrENTRY_TIME, .strEntryTime)                            '登録日時
            
                        '@ｱﾚｲを格納
                        Call laMsg.getMsgAry(CPstrLOT_LIST, laAry)                                      'ﾛｯﾄﾘｽﾄ
                    
                        '@ﾘｽﾄｶｳﾝﾄ格納
                        .lngExcpReportLotListCnt = laAry.Count

                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngExcpReportLotListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            '@配列の要素数を設定
                            'ReDim Preserve .typExcpLotList(.lngExcpReportLotListCnt)
                            If IsNothing(.typExcpLotList) Then
                                .typExcpLotList = New List(Of ExcpLot)()
                            Else
                                .typExcpLotList.Clear()
                            End If

                            llngCnt = 0
                            
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg1 In laAry
                                Dim tmpExcpLot As ExcpLot = New ExcpLot()
                                Call ltMsg1.getString(CPstrLOT_ID, tmpExcpLot.strLotID)                            'ﾛｯﾄID
                                Call ltMsg1.getString(CPstrTARGET_QUANTITY, tmpExcpLot.strTargetQuantity)          '対象数量
                                Call ltMsg1.getString(CPstrTOTAL_QUANTITY, tmpExcpLot.strTotalQuantity)            '合計数量
                                Call ltMsg1.getString(CPstrRESERVE_QUANTITY, tmpExcpLot.strReserveQuantity)        '保留
                                Call ltMsg1.getString(CPstrABANDON_QUANTITY, tmpExcpLot.strAbandonQuantity)        '廃却
                                Call ltMsg1.getString(CPstrAMEND_QUANTITY, tmpExcpLot.strAmendQuantity)            '手直し
                                Call ltMsg1.getString(CPstrCORRECT_QUANTITY, tmpExcpLot.strCorrectQuantity)        '修正
                                Call ltMsg1.getString(CPstrUSUAL_QUANTITY, tmpExcpLot.strUsualQuantity)            '通常
                                Call ltMsg1.getString(CPstrEVAL_QUANTITY, tmpExcpLot.strEvalQuantity)              '評価
                                Call ltMsg1.getString(CPstrTAKE_QUANTITY, tmpExcpLot.strTakeQuantity)              '特採
                                Call ltMsg1.getString(CPstrDISPOSAL_FLAG, tmpExcpLot.strDisposalFlag)              '処置ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrAPPEND_FLAG, tmpExcpLot.strAppendFlag)                  'ﾛｯﾄ追加ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrHOLD_FLAG, tmpExcpLot.strHoldFlag)                      'ﾛｯﾄ保留ﾌﾗｸﾞ
                                Call ltMsg1.getString(CPstrEDIT_TIME, tmpExcpLot.strEditTime)                      '最終更新日時
                                
                                .typExcpLotList.Add(tmpExcpLot)
                                '@ｶｳﾝﾄｱｯﾌﾟ
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With
            
                    '@関数の処理結果(成功)格納
                    pubblnExcpReportInfo_Sel = True
                    
                '@失敗の場合(false)
                Case CPstrFALSE
                    
                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypExcpReport.strMsgVer)
                    
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
            ltMsg1 = Nothing
            laAry = Nothing

        End Try
    End Function

    '関数名：pubblnExcpReportList_Sel
    '機　能：工程異常/不適合品処理票一覧取得
    '引　数：ltypReportListReq  ：要求格納構造体
    '　　　：ltypReportList     ：応答格納構造体
    '戻り値：True:成功/False:失敗
    '作成日：2005/08/08 (Mon) 13:51:25 S.Deguchi
    '更新日：2008/09/19 (Fri) 14:42:40 T.Inafune
    '備　考：
    '　　　：2005/09/22 (Thu) 09:48:15 S.Deguchi    簡易ﾜｰｸﾌﾛｰ対応
    '　　　：2007/09/04 (Tue) 14:31:14 N.Kojima     検索条件にSB_IDを使用するように対応。(案件№02158)
    '　　　：2007/12/13 (Thu) 15:16:15 N.Kasai      応答ﾀｸﾞ追加（EDIT_TIME)
    '　　　：2008/09/19 (Fri) 14:38:13 T.Inafune    応答ﾀｸﾞ追加 (案件No.03121)

    Public Function pubblnExcpReportList_Sel(ByRef ltypReportListReq As ReportListReq, _
                                             ByRef ltypReportList As ExcpReportList) As Boolean

        Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
        Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
        Dim laAry               As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry1              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg1              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim laAry2              As TfMsgAry         '受信ﾒｯｾｰｼﾞｱﾚｰ
        Dim ltMsg2              As TfMsg            '受信ﾒｯｾｰｼﾞ配列用
        Dim lstrRET             As String           '応答取得
        Dim llngCnt             As Integer          'ｶｳﾝﾄ用
        Dim llngCnt1            As Integer          'ｶｳﾝﾄ用

        Try

            pstrMessageName = "工程異常/不適合品処理票一覧取得"
            pubblnExcpReportList_Sel = False

            lrMsg = New TfMsg
            laMsg = New TfMsg
            ltMsg = New TfMsg
            laAry = New TfMsgAry
            ltMsg1 = New TfMsg
            laAry1 = New TfMsgAry
            ltMsg2 = New TfMsg
            laAry2 = New TfMsgAry

            '@送信ﾒｯｾｰｼﾞ作成
            With ltypReportListReq
                If .strMsgVer <> vbNullString Then
                    Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                      'Msgﾊﾞｰｼﾞｮﾝ
                Else
                    Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                End If

                If .strSbID <> vbNullString Then
                    Call lrMsg.addString(CPstrSB_ID, .strSbID)                          'SB_ID
                Else
                    Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
                End If

                If .strClassDivision <> vbNullString Then
                    Call lrMsg.addString(CPstrCLASS_DIVISION, .strClassDivision)        'ClassDivision
                Else
                    Call lrMsg.addString(CPstrCLASS_DIVISION, CPstrMsgNull)
                End If

                If .strStartDate <> vbNullString Then
                    Call lrMsg.addString(CPstrSTART_DATE, .strStartDate)                '検索開始日
                Else
                    Call lrMsg.addString(CPstrSTART_DATE, CPstrMsgNull)
                End If

                If .strEndDate <> vbNullString Then
                    Call lrMsg.addString(CPstrEND_DATE, .strEndDate)                    '検索終了日
                Else
                    Call lrMsg.addString(CPstrEND_DATE, CPstrMsgNull)
                End If
                
                If .strFindEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_EMP_ID, .strFindEmpID)               '更新者
                Else
                    Call lrMsg.addString(CPstrFIND_EMP_ID, CPstrMsgNull)
                End If
                
                If .strToEmpID <> vbNullString Then
                    Call lrMsg.addString(CPstrFIND_TO_EMP_ID, .strToEmpID)              '担当者
                Else
                    Call lrMsg.addString(CPstrFIND_TO_EMP_ID, CPstrMsgNull)
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrexcpreportlist, lrMsg, laMsg)

            '@受信結果取得
            Call laMsg.getString(CPstrRET, lstrRET)

            '@結果判定
            Select Case lstrRET
                '@成功の場合(true)
                Case CPstrTRUE
                    '@受信結果格納
                    '@ｱﾚｲを格納
                    Call laMsg.getMsgAry(CPstrREPORT_LIST, laAry)                       '工程異常/不適合品処理票一覧

                    '@異常処理票一覧内容
                    With ltypReportList
                        '@ﾘｽﾄｶｳﾝﾄ格納
                        .lngReportListCnt = laAry.Count
                        
                        '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                        If .lngReportListCnt > 0 Then
                        '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                            '@配列の要素数を設定
                            'ReDim Preserve .typReportList(.lngReportListCnt)
                            If IsNothing(.typReportList) Then
                                .typReportList = New List(Of ReportListAns)()
                            Else
                                .typReportList.Clear()
                            End If
                            llngCnt = 0
                            '@ｱﾚｰの各要素取得
                            For Each ltMsg In laAry
                                Dim tmpReportListAns As ReportListAns = New ReportListAns()
                                Call ltMsg.getString(CPstrDOC_CLASS, tmpReportListAns.strDocClass)                   '帳票種別
                                Call ltMsg.getString(CPstrFIND_DATE, tmpReportListAns.strFindDate)                   '発見日時
                                Call ltMsg.getString(CPstrFIND_EMP_ID, tmpReportListAns.strFindEmpID)                '起案者ID
                                Call ltMsg.getString(CPstrFIND_EMP_NAME, tmpReportListAns.strFindEmpName)            '起案者名
                                Call ltMsg.getString(CPstrEXCP_ITEM_NAME, tmpReportListAns.strExcpItemName)          '工程異常名
                                Call ltMsg.getString(CPstrEXCP_NO, tmpReportListAns.strExcpNo)                       '工程異常№
                                Call ltMsg.getString(CPstrAPPROVAL_FLAG, tmpReportListAns.strApprovalFlag)           '適用ﾌﾗｸﾞ
                                Call ltMsg.getString(CPstrALL_DISPOSAL_FLAG, tmpReportListAns.strAllDisposalFlag)    '全処置ﾌﾗｸﾞ
                                
                                Call ltMsg.getString(CPstrFIND_WP_ID, tmpReportListAns.strFindWpID)                  '装置ID
                                Call ltMsg.getString(CPstrFIND_WP_NAME, tmpReportListAns.strFindWpName)              '装置名
                                Call ltMsg.getString(CPstrWORKFLOW_ENTRY_TIME, tmpReportListAns.strFromEntryTime)    '確認依頼日
                                Call ltMsg.getString(CPstrFROM_EMP_ID, tmpReportListAns.strFromEmpID)                '確認依頼元ID
                                Call ltMsg.getString(CPstrFROM_EMP_NAME, tmpReportListAns.strFromEmpName)            '確認依頼元名
                                Call ltMsg.getString(CPstrEDIT_TIME, tmpReportListAns.strEditTime)                   '更新日時
                            '@↓2008/09/17 (Wed) T.Inafune No:03121 **************************************************
                                Call ltMsg.getString(CPstrFIND_OP_ID, tmpReportListAns.strFindOpID)                  '大工程
                                Call ltMsg.getString(CPstrFIND_STEP_ID, tmpReportListAns.strFindStepID)              '小工程
                                Call ltMsg.getString(CPstrDISPO_NAME, tmpReportListAns.strDispoName)                 '処置名
                                Call ltMsg.getString(CPstrDISPO_WF_NUM, tmpReportListAns.strDispoWfNum)              '処置WF数
                                Call ltMsg.getString(CPstrEXCP_SITUATION, tmpReportListAns.strExcpSitu)              '工程異常発生状況
                            '@↑2008/09/17 (Wed) T.Inafune No:03121 **************************************************
            
                                '@ｱﾚｲを格納(ﾛｯﾄID)
                                Call ltMsg.getMsgAry(CPstrLOT_LIST, laAry1)         'ﾛｯﾄID

                                '@ﾘｽﾄｶｳﾝﾄ格納
                                tmpReportListAns.lngLotListCnt = laAry1.Count

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                If laAry1.Count > 0 Then
                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                    '@配列の要素数を設定
                                    'ReDim Preserve .typReportList(llngCnt).typExcpLotList(laAry1.Count)
                                    If IsNothing(tmpReportListAns.typExcpLotList) Then
                                        tmpReportListAns.typExcpLotList = New List(Of ExcpLotList)()
                                    Else
                                        tmpReportListAns.typExcpLotList.Clear()
                                    End If
                                    llngCnt1 = 0
                                    '@ｱﾚｰの各要素取得
                                    For Each ltMsg1 In laAry1
                                        Dim tmpExcpLotList As ExcpLotList = New ExcpLotList()
                                        '@ﾛｯﾄIDの取得
                                        Call ltMsg1.getString(CPstrLOT_ID, _
                                                              tmpExcpLotList.strLotID)
                                        '@ｶｳﾝﾄｱｯﾌﾟ
                                        tmpReportListAns.typExcpLotList.Add(tmpExcpLotList)
                                        llngCnt1 = llngCnt1 + 1
                                    Next
                                End If
                                
                                '@ｱﾚｲを格納(確認依頼先)
                                Call ltMsg.getMsgAry(CPstrTO_EMP_LIST, laAry2)          '確認依頼先

                                '@ﾘｽﾄｶｳﾝﾄ格納
                                tmpReportListAns.lnEmpListCnt = laAry2.Count

                                '@受信ﾒｯｾｰｼﾞｱﾚｲ数確認
                                If laAry2.Count > 0 Then
                                '@受信ﾒｯｾｰｼﾞｱﾚｲから各Msg取得
                                    '@配列の要素数を設定
                                    'ReDim Preserve .typReportList(llngCnt).typExcpEmpList(laAry2.Count)
                                    If IsNothing(tmpReportListAns.typExcpEmpList) Then
                                        tmpReportListAns.typExcpEmpList = New List(Of ExcpEmpList)()
                                    Else
                                        tmpReportListAns.typExcpEmpList.Clear()
                                    End If
                                    llngCnt1 = 0
                                    '@ｱﾚｰの各要素取得
                                    For Each ltMsg2 In laAry2
                                        Dim tmpExcpEmpList As ExcpEmpList = New ExcpEmpList()
                                        '@確認依頼先IDの取得
                                        Call ltMsg2.getString(CPstrEMP_ID, _
                                                              tmpExcpEmpList.strEmpID)

                                        '@確認依頼先名の取得
                                        Call ltMsg2.getString(CPstrEMP_NAME, _
                                                              tmpExcpEmpList.strEmpName)
                                        
                                        '@ｶｳﾝﾄｱｯﾌﾟ
                                        tmpReportListAns.typExcpEmpList.Add(tmpExcpEmpList)
                                        llngCnt1 = llngCnt1 + 1
                                    Next
                                End If
                                
                                .typReportList.Add(tmpReportListAns)
                                llngCnt = llngCnt + 1
                            Next
                        End If
                    End With

                    '@関数の処理結果(成功)格納
                    pubblnExcpReportList_Sel = True

                '@失敗の場合(false)
                Case CPstrFALSE

                    '@ﾊﾞｰｼﾞｮﾝ判定
                    Call pubstrErrMsg_Set(laMsg, ltypReportListReq.strMsgVer)

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
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing

            Exit Function

        '@例外処理
        Catch ex As Exception

            '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            lrMsg = Nothing
            laMsg = Nothing
            ltMsg = Nothing
            laAry = Nothing
            ltMsg1 = Nothing
            laAry1 = Nothing
            ltMsg2 = Nothing
            laAry2 = Nothing
            
            '@表示ﾒｯｾｰｼﾞ変換
            Call pubErrMsg_Proc(Err)

        End Try
    End Function

    '@↓2007/02/19 (Mon) 13:41:14 N.Kojima **************************************************
    '@故障修理記録票機能追加に伴い、ﾜｰｸﾌﾛｰ登録処理を統合。(案件№01774)
    ''関数名：pubblnExcpRegistWorkFlow_Ins
    ''機　能：ﾜｰｸﾌﾛｰ登録
    ''引　数：ltypExcpWorkFlow：要求構造体
    ''戻り値：True:成功/False:失敗
    ''作成日：2005/09/20 (Tue) 16:25:34 S.Deguchi
    ''更新日：2005/09/20 (Tue) 16:25:34
    ''備　考：
    'Public Function pubblnExcpRegistWorkFlow_Ins(ByRef ltypExcpWorkFlow As ExcpWorkFlow) As Boolean
    '
    '    Dim lrMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ）
    '    Dim laMsg               As TfMsg            '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ）
    '    Dim lrAry               As TfMsgAry         '送信ﾒｯｾｰｼﾞｱﾚｰ
    '    Dim ltMsg               As TfMsg            '送信ﾒｯｾｰｼﾞ配列用
    '    Dim lstrRET             As String           '応答取得
    '    Dim lstrErrMsg          As String           'ｴﾗｰ用
    '    Dim lstrMSG             As String           'ﾒｯｾｰｼﾞ内容格納
    '    Dim llngCnt             As Long             'ｶｳﾝﾄ用
    '
    '    On Error GoTo Error_Handler
    '
    '    pstrMessageName = "ワークフロー登録"
    '    pubblnExcpRegistWorkFlow_Ins = False
    '
    '    Set lrMsg = New TfMsg
    '    Set laMsg = New TfMsg
    '    Set ltMsg = New TfMsg
    '    Set lrAry = New TfMsgAry
    '
    '    '@送信ﾒｯｾｰｼﾞ作成
    '    With ltypExcpWorkFlow
    '        If .strSBID <> vbNullString Then
    '            Call lrMsg.addString(CPstrSB_ID, .strSBID)                                          'SB_ID
    '        Else
    '            Call lrMsg.addString(CPstrSB_ID, CPstrMsgNull)
    '        End If
    '
    '        If .strMsgVer <> vbNullString Then
    '            Call lrMsg.addString(CPstrMSG_VER, .strMsgVer)                                      'Msgﾊﾞｰｼﾞｮﾝ
    '        Else
    '            Call lrMsg.addString(CPstrMSG_VER, CPstrMsgNull)
    '        End If
    '
    '        If .strExcpNo <> vbNullString Then
    '            Call lrMsg.addString(CPstrEXCP_NO, .strExcpNo)                                      '異常処理№
    '        Else
    '            Call lrMsg.addString(CPstrEXCP_NO, CPstrMsgNull)
    '        End If
    '
    '        If .strFromEmpID <> vbNullString Then
    '            Call lrMsg.addString(CPstrFROM_EMP_ID, .strFromEmpID)                               '依頼元ID
    '        Else
    '            Call lrMsg.addString(CPstrFROM_EMP_ID, CPstrMsgNull)
    '        End If
    '
    '        If .strFromEmpName <> vbNullString Then
    '            Call lrMsg.addString(CPstrFROM_EMP_NAME, .strFromEmpName)                           '依頼元名
    '        Else
    '            Call lrMsg.addString(CPstrFROM_EMP_NAME, CPstrMsgNull)
    '        End If
    '
    '        '@依頼先ﾘｽﾄ
    '        If .lngEmpListCnt > 0 Then
    '            For llngCnt = 1 To .lngEmpListCnt
    '                If .typEmpList(llngCnt).strToEmpID <> vbNullString Then
    '                    Call ltMsg.addString(CPstrTO_EMP_ID, .typEmpList(llngCnt).strToEmpID)       '依頼先ID
    '                Else
    '                    Call ltMsg.addString(CPstrTO_EMP_ID, CPstrMsgNull)
    '                End If
    '
    '                If .typEmpList(llngCnt).strToEmpName <> vbNullString Then
    '                    Call ltMsg.addString(CPstrTO_EMP_NAME, .typEmpList(llngCnt).strToEmpName)   '依頼先名
    '                Else
    '                    Call ltMsg.addString(CPstrTO_EMP_NAME, CPstrMsgNull)
    '                End If
    '
    '                '@ｱﾚｲ1に格納
    '                Call lrAry.Add(ltMsg)
    '                Call ltMsg.Clear
    '            Next llngCnt
    '        End If
    '
    '        '@Temp1にｱﾚｲ1の内容を格納
    '        Call lrMsg.addMsgAry(CPstrTO_EMP_LIST, lrAry)
    '    End With
    '
    '    '@ﾒｯｾｰｼﾞ送信
    '    Call pTerm.sendRequest(CPstrexcpregistworkflow, lrMsg, laMsg)
    '
    '    '@受信結果取得
    '    Call laMsg.getString(CPstrRET, lstrRET)
    '
    '    '@結果判定
    '    Select Case lstrRET
    '        '@成功の場合(true)
    '        Case CPstrTRUE
    '            '@関数の処理結果(成功)格納
    '            pubblnExcpRegistWorkFlow_Ins = True
    '
    '        '@失敗の場合(false)
    '        Case CPstrFALSE
    '
    '            '@ﾊﾞｰｼﾞｮﾝ判定
    '            Call pubstrErrMsg_Set(laMsg, ltypExcpWorkFlow.strMsgVer)
    '
    '        '@その他ｴﾗｰ(応答者がいない場合結果がNULLでくる場合あり)
    '        Case Else
    '            '@表示ﾒｯｾｰｼﾞ変換
    '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr0001)
    '
    '            '@「閉じるボタンを押してメニューを選択して下さい。」ﾒｯｾｰｼﾞ表示
    '            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
    '
    '    End Select
    '
    '    '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
    '    Set lrMsg = Nothing
    '    Set laMsg = Nothing
    '    Set ltMsg = Nothing
    '    Set lrAry = Nothing
    '
    '    Exit Function
    '
    ''@例外処理
    'Error_Handler:
    '
    '    '@表示ﾒｯｾｰｼﾞ変換
    '    Call pubErrMsg_Proc(Err)
    '
    '    '@ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
    '    Set lrMsg = Nothing
    '    Set laMsg = Nothing
    '    Set ltMsg = Nothing
    '    Set lrAry = Nothing
    '
    'End Function
    '@↑2007/02/19 (Mon) 13:41:14 N.Kojima **************************************************

End Module
