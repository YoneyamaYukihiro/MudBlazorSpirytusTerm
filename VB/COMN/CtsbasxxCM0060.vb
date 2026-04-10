'ﾌｧｲﾙ名：xxCM0060.bas
'説　明：共通関数
'作成日：2004/03/01 (Mon) 17:36:35 T.Kitagawa
'更新日：2023/06/23 (Fri) 16:21:00 T.Oide
'備　考：
'Copyright(C)2003-2019, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.Net
Imports System.Net.Sockets
Imports TFLib
Imports System.ComponentModel
Imports System.Security.Permissions
Public Module basxxCM0060
    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrutilfuncinfoVer          As String = "01.00"             '機能ﾊﾞｰｼﾞｮﾝ取得
    Private Const CMstrutilchkfunc_             As String = "01.00"             '機能ﾊﾞｰｼﾞｮﾝﾁｪｯｸ

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrutiltmresponseVer        As String = "01.00"             'ﾚｽﾎﾟﾝｽ測定送信
    Private Const CMstrmas_empname_Ver          As String = "02.01"             '作業者権限ﾁｪｯｸ

    Private Const CMlngMaxTimer                 As Integer = 86399990           'Timer関数の最大値(msec単位)
    Private Const CmstrResponseStartMessage     As String = "レスポンス取得開始" 'ｴﾗｰﾒｯｾｰｼﾞBOX表示用ﾀｲﾄﾙ
    Private Const CmstrResponseEndMessage       As String = "レスポンス取得終了" 'ｴﾗｰﾒｯｾｰｼﾞBOX表示用ﾀｲﾄﾙ
    Private Const CMstrDainari                  As String = " > "               'ｽﾃｰﾀｽ表示用
    Private Const CMlngLenB                     As Integer = 98                 'ｽﾃｰﾀｽ1行最大ﾊﾞｲﾄ数
    Private Const CMstrSpace8                   As String = "        "          'ｽﾍﾟｰｽ×8
    Private Const CMlngInfoRows                 As Integer = 20                 'ｽﾃｰﾀｽ最大行数
    Private Const CMstrNothing                  As String = "Nothing"           'Nothing
    '@ｽﾃｰﾀｽ画面色設定用
    Private Const CMlngStErrForeColor           As Integer = &HFF               'ｴﾗｰ時文字色(赤)

    '@日付範囲ﾁｪｯｸ用
    Private Const CMstrStartYear                As String = "1900/01/01"        '開始正常年月日
    Private Const CMstrEndYear                  As String = "2100/12/31"        '終了正常年月日

    '@特殊流動定数宣言
    Private Const CMstrRouteFlag0               As String = "0"                 '特殊流動：ﾘﾜｰｸ
    Private Const CMstrRouteFlag1               As String = "1"                 '特殊流動：追加流動
    Private Const CMstrRouteFlag2               As String = "2"                 '特殊流動：先行流動
    Private Const CMlngoptValue2                As Integer = 2                  'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ値：ﾘﾜｰｸ
    Private Const CMlngoptValue3                As Integer = 3                  'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ値：追加流動

    '@実行権限の処理結果
    Private Const CMstrAuthority0               As String = "0"                 '0:実行不可能
    Private Const CMstrAuthority1               As String = "1"                 '1:実行可能

    '@frmxxEN0150のvsfAreaEquipmentのｶﾗﾑ定数格納(基板と組立で変わる)
    Private mlngvsfAreaEqColNowSt               As Integer                      'ﾛｯﾄ状態
    Private mlngvsfAreaEqColLotID               As Integer                      'ﾛｯﾄID
    Private mlngvsfAreaEqColOpID                As Integer                      '大工程
    Private mlngvsfAreaEqColStepID              As Integer                      '小工程
    Private mlngvsfAreaEqColLCarrierID          As Integer                      'ﾛｰﾀﾞｷｬﾘｱID
    Private mlngvsfAreaEqColUCarrierID          As Integer                      'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private mlngvsfAreaEqColAltNumber           As Integer                      '代替番号

    '@frmxxEN00J0のvsfMcAllLotlistの定数宣言(ｶﾗﾑ)
    Private Const CMlngColOpId                  As Integer = 2                  '大工程(col変更時はfrmxxEN00J0も同じく修正する必要あり)
    Private Const CMlngColStepId                As Integer = 3                  '小工程(col変更時はfrmxxEN00J0も同じく修正する必要あり)
    Private Const CMlngColCarrierID             As Integer = 5                  'ﾛｰﾀﾞｷｬﾘｱID(col変更時はfrmxxEN00J0も同じく修正する必要あり)
    Private Const CMlngColLotID                 As Integer = 6                  'ﾛｯﾄID(col変更時はfrmxxEN00J0も同じく修正する必要あり)
    Private Const CMlngColUnLoaderCarrierID     As Integer = 15                 'ｱﾝﾛｰﾀﾞｷｬﾘｱID(col変更時はfrmxxEN00J0も同じく修正する必要あり)
    Private Const CMlngColAltNumber             As Integer = 16                 '代替番号(col変更時はfrmxxEN00J0も同じく修正する必要あり)

    '@frmxxEN0200のvsfStepLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfStepLLColOpID         As Integer = 2                  '大工程(col変更時はfrmxxEN0200も同じく修正する必要あり)
    Private Const CMlngvsfStepLLColStepID       As Integer = 3                  '小工程(col変更時はfrmxxEN0200も同じく修正する必要あり)
    Private Const CMlngvsfStepLLColCarrierID    As Integer = 5                  'ﾛｰﾀﾞｷｬﾘｱID(col変更時はfrmxxEN0200も同じく修正する必要あり)
    Private Const CMlngvsfStepLLColLotID        As Integer = 6                  'ﾛｯﾄID(col変更時はfrmxxEN0200も同じく修正する必要あり)
    Private Const CMlngvsfStepLLColUnLoaderCarrierID    As Integer = 16         'ｱﾝﾛｰﾀﾞｷｬﾘｱID(col変更時はfrmxxEN0200も同じく修正する必要あり)
    Private Const CMlngvsfStepLLColAltNumber    As Integer = 17                 '代替番号(col変更時はfrmxxEN0200も同じく修正する必要あり)

    '@frmxxCM0090のvsfResvLotListの定数宣言(ｶﾗﾑ)
    Private Const CMvsfResvLotListColLotID      As Integer = 3                  'ﾛｯﾄID(col変更時はfrmxxCM0090も同じく修正する必要あり)

    '@制限時間変換用(分 → #,##0時間 #0分)
    Private Const CMlngMinute60                 As Integer = 60                 '60分(１時間)

    '@ﾌﾟﾛｾｽ関連API用
    Private Const PROCESS_QUERY_INFORMATION = &H400&
    Private Const STILL_ACTIVE = &H103&

    '@ﾌｧｲﾙﾊﾟｽ関連
    Private Const CMstrFilePathBackSlash        As String = "\"
    Private Const CMstrFilePathSpace            As String = " "

    '@↓2018/06/14 (Thu) 10:01:35 T.Oide「.Net反映未」 **************************************************xxGC0040.basに移動
    '@'@SetWindowPos API用
    '@Public Const CPlngHwndTopmost               As Long = (-1)                  'API(SetWindowPos)
    '@Public Const CPlngHwndTop                   As Long = (0)                   'API(SetWindowPos)
    '@Public Const CPlngSwpNosize                 As Long = &H1&                  'API(SetWindowPos)
    '@Public Const CPlngSwpNomove                 As Long = &H2&                  'API(SetWindowPos)
    '@Public Const CPlngZero                      As Long = 0&                    'API(SetWindowPos)
    '@↑2018/06/14 (Thu) 10:01:35 T.Oide「.Net反映未」 **************************************************

    '@ErrorCode用
    Private Const CMstrErrCode80040221          As String = "80040221"          'TfBase.init:初期化ﾌｧｲﾙが見つかりません
    Private Const CMstrErrCode80040222          As String = "80040222"          'TfBase.init:ORBの初期化に失敗しました
    Private Const CMstrErrCode80040223          As String = "80040223"          'TfBase.init:ｲﾆｼｬﾙｵﾌﾞｼﾞｪｸﾄﾘﾌｧﾚﾝｽが取得できません
    Private Const CMstrErrCode80040224          As String = "80040224"          'TfBase.init:ﾛｸﾞﾌｧｲﾙをｵｰﾌﾟﾝできません
    Private Const CMstrErrCode80040225          As String = "80040225"          'TfBase.initFileRead:初期化ﾌｧｲﾙ[xxx]は存在しません
    Private Const CMstrErrCode8004022A          As String = "8004022A"          'TfBase.sendRequest:ﾒｯｾｰｼﾞID[xxx]に該当するｻｰﾊﾞはありません
    Private Const CMstrErrCode8004022B          As String = "8004022B"          'TfBase.sendRequest:ﾒｯｾｰｼﾞID[xxx]が登録されていません
    Private Const CMstrErrCode8004022C          As String = "8004022C"          'TfBase.sendRequest:ﾒｯｾｰｼﾞID[xxx]の通信中にﾀｲﾑｱｳﾄが発生しました
    Private Const CMstrErrCode8004022D          As String = "8004022D"          'TfBase.sendRequest:CORBA Exception[xxx]
    Private Const CMstrErrCode8004022E          As String = "8004022E"          'TfBase.sendRequest:予期せぬ例外が発生しました
    Private Const CMstrErrCode8004022F          As String = "8004022F"          'TfBase.sendRequest:reqMsgにNullが設定されました
    Private Const CMstrErrCode80040230          As String = "80040230"          'TfBase.sendRequest:msgIdにNullもしくは空文字が指定されました
    Private Const CMstrErrCode80040231          As String = "80040231"          'TfMsg.addMsgAry:nameにNullもしくは空文字が指定されました
    Private Const CMstrErrCode80040232          As String = "80040232"          'TfMsg.addMsgAry:msgArrayにNullが設定されました
    Private Const CMstrErrCode80040233          As String = "80040233"          'TfMsg.addString:nameにNullもしくは空文字が指定されました
    Private Const CMstrErrCode80040234          As String = "80040234"          'TfMsg.addString:valueにNullが設定されました
    Private Const CMstrErrCode80040235          As String = "80040235"          'TfMsg.getMsgAry:nameにNullもしくは空文字が指定されました
    Private Const CMstrErrCode80040236          As String = "80040236"          'TfMsg.getMsgAry:nameに指定したﾀｸﾞのｱﾚｲが取得できませんでした
    Private Const CMstrErrCode80040237          As String = "80040237"          'TfMsg.getString:nameにNullもしくは空文字が指定されました
    Private Const CMstrErrCode80040238          As String = "80040238"          'TfMsg.getString:nameに指定したﾀｸﾞの値が取得できませんでした
    Private Const CMstrErrCode80040240          As String = "80040240"          'TfMsgAry.add:msgにNullが設定されました

    '@その他
    Private Const CMstrTen                      As String = "･"                 '区切り表示

    '======================================Public===========================================
    '@GetWindiowLong/SetWindowLong用
    Public Const GWL_STYLE = -16                'ウィンドウスタイルの書き換え
    Public Const WS_SYSMENU = &H80000           '最大化／最小化／消去ボタンなど全て
    Public Const WS_MINIMIZEBOX = &H20000       '最小化ボタン
    Public Const WS_MAXIMIZEBOX = &H10000       '最大化ボタン
    Public Const MF_BYPOSITION = &H400&

    '@keybd_event用
    Public Const VK_SNAPSHOT = &H2C             'PrintScreenｷｰ
    Public Const VK_LMENU = &HA4                'Altｷｰ
    Public Const KEYEVENTF_KEYUP = &H2          'ｷｰｱｯﾌﾟ状態
    Public Const KEYEVENTF_EXTENDEDKEY = &H1    'ｽｷｬﾝは拡張ｺｰﾄﾞ

    '@↓2019/12/13 (Fri) 16:28:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@GRB色宣言
    Public Const CPlngG_BackColor               As Integer = &HCCFFCC           '緑系色(G区分ﾊﾞｯｸｶﾗｰ)
    Public Const CPlngR_BackColor               As Integer = &HCC99FF           '赤系色(R区分ﾊﾞｯｸｶﾗｰ)
    Public Const CPlngB_BackColor               As Integer = &HFFCC99           '青系色(B区分ﾊﾞｯｸｶﾗｰ)
    Public Const CPlngGR_BackColor              As Integer = &H99FFFF           '緑赤系色(GR区分ﾊﾞｯｸｶﾗｰ)
    Public Const CPlngGB_BackColor              As Integer = &H669933           '緑青系色(GB区分ﾊﾞｯｸｶﾗｰ)
    Public Const CPlngRB_BackColor              As Integer = &HFF99CC           '赤青系色(RB区分ﾊﾞｯｸｶﾗｰ)

    '@GRB区分
    Public Const CPstrGRB_G                     As String = "G"                 'G属性
    Public Const CPstrGRB_R                     As String = "R"                 'R属性
    Public Const CPstrGRB_B                     As String = "B"                 'B属性
    Public Const CPstrGRB_GR                    As String = "GR"                'GR属性
    Public Const CPstrGRB_GB                    As String = "GB"                'GB性
    Public Const CPstrGRB_RB                    As String = "RB"                'RB属性
    Public Const CPstrGRB_MIX                   As String = "MX"                'GRB混在
    '@↑2019/12/13 (Fri) 16:28:01 Y.Yoneyama 「.Netへ反映未」 **************************************************


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    
    '***************************************************************************************
    '                                    *APIの記述*
    '***************************************************************************************
    '======================================Public===========================================
    '@指定されたｳｲﾝﾄﾞｳﾊﾝﾄﾞﾙを持つｳｨﾝﾄﾞｳが存在するかどうか判断する関数の宣言
    Public Declare Function IsWindow Lib "User32.dll" (ByVal hwnd As IntPtr) As Boolean

    '@ｳｨﾝﾄﾞｳの属性を取得するAPI
    Public Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer) As Integer

    '@ｳｨﾝﾄﾞｳの属性を変更するAPI
    Public Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
            
    Public Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As IntPtr, ByVal bRevert As Integer) As IntPtr
    Public Declare Function DeleteMenu Lib "user32" (ByVal hMenu As IntPtr, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer

    '@画面の位置をｺﾝﾄﾛｰﾙする関数
    Public Declare Function SetWindowPos Lib "user32" (ByVal hwnd As IntPtr, _
                                                       ByVal hWndInsertAfter As Integer, _
                                                       ByVal X As Integer, ByVal Y As Integer, _
                                                       ByVal cx As Integer, ByVal cy As Integer, _
                                                       ByVal wFlags As Integer) As Boolean
                                                       
    '@ｷｰｽﾄﾛｰｸをｼｭﾐﾚｰﾄする
    Public Declare Sub keybd_event Lib "User32.dll" _
                                        (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)

    '======================================Private==========================================
    '@ﾌﾟﾛｾｽﾊﾝﾄﾞﾙ関連
    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As UInteger, ByVal bInheritHandle As Boolean, ByVal dwProcessId As UInteger) As IntPtr
    Private Declare Function GetExitCodeProcess Lib "kernel32" (ByVal hProcess As IntPtr, ByRef lpExitCode As UInteger) As Boolean
    Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As IntPtr) As Boolean
    'MoveWindow関数の宣言
    Private Declare Function MoveWindow Lib "user32" Alias "MoveWindow" (ByVal hwnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Integer) As Integer

    '***************************************************************************************
    '                                    *関数の記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：pubResponseStart
    '機　能：ﾚｽﾎﾟﾝｽ取得開始
    '引　数：lstrFromName：ﾌｫｰﾑ名
    '　　　：lstrEventName：ｲﾍﾞﾝﾄ名
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 18:26:53 T.Kitagawa
    '更新日：2019/10/25 (Fri) 14:44:52 T.Oide
    '備　考：
    Public Sub pubResponseStart(Optional ByVal lstrFromName As String = vbNullString, _
                                Optional ByVal lstrEventName As String = vbNullString)
        
        Dim lstrCommandLine()       As String                   'ｺﾏﾝﾄﾞﾗｲﾝ
        Dim lkey                    As Tuple(Of String, String) '複合キー
        Dim ltypTmResponseList      As typTmResponseList        'ﾚｽﾎﾟﾝｽ測定送信用構造体
        Dim lstrErrStartDateTime    As String                   'ｴﾗｰﾒｯｾｰｼﾞ表示用測定開始日時（yyyy/mm/dd hh:mm:ss)

        '@↓2019/10/25 (Fri) 14:41:09 T.Oide *************************************************
            Exit Sub
        '@↑2019/10/25 (Fri) 14:41:09 T.Oide *************************************************
        
        '@ﾏｳｽｱｲｺﾝ(砂時計)
        Cursor.Current = Cursors.WaitCursor
        
        '@ﾃｽﾄﾓｰﾄﾞの設定(ｺﾏﾝﾄﾞﾊﾟﾗﾒｰﾀの第２引数が"D"の場合はﾃｽﾄﾓｰﾄﾞ、それ以外は本場と認識する
        If pstrTestStatus = vbNullString Then
            '@ｺﾏﾝﾄﾞﾗｲﾝより取得
            lstrCommandLine = Split(Command, ",")
            If UBound(lstrCommandLine) >= 1 Then
                pstrTestStatus = lstrCommandLine(1)
            End If
            If pstrTestStatus = vbNullString Then
                '@本番ﾓｰﾄﾞ設定(指定されていない場合ほもう１度取得しないように空白を設定する)
                pstrTestStatus = " "
            End If
        End If
        
        '@初期化
        If ptypTmResponseList Is Nothing Then
            ptypTmResponseList = New Dictionary(Of Tuple(Of String, String), typTmResponseList)
        End If

        '@複合キー生成
        lkey = Tuple.Create(lstrFromName, lstrEventName)
        
        '@同一ｲﾍﾞﾝﾄの検索
        If ptypTmResponseList.TryGetValue(lkey, ltypTmResponseList) = True Then
            '@ﾚｽﾎﾟﾝｽ測定中止以外はﾒｯｾｰｼﾞ表示する
            If ltypTmResponseList.lngStartCancelStatus <> 1 Then
                lstrErrStartDateTime = Format$(ltypTmResponseList.tmStartDateTime, CPstrDateTimeYMD & " " & CPstrDateFormatHMS)
                '@ｴﾗｰﾒｯｾｰｼﾞBOXの表示（ﾚｽﾎﾟﾝｽ測定終了なし）
                Call prvResponseErrMsgBox(7, lstrFromName, lstrEventName, lstrErrStartDateTime, _
                                             vbNullString, 0)
            End If
        End If
        
        '@ﾚｽﾎﾟﾝｽ測定送信用構造体へのｾｯﾄ
        ltypTmResponseList.strFormName = lstrFromName                                'ﾌｫｰﾑ名(画面識別名)設定
        ltypTmResponseList.strEventName = lstrEventName                              'ｲﾍﾞﾝﾄ(処理名)設定
        ltypTmResponseList.tmStartDateTime = DateTime.Now
        ltypTmResponseList.lngStartCancelStatus = 0                                  '測定開始中止ｽﾃｰﾀｽ(0:通常)
        
        ptypTmResponseList(lkey) = ltypTmResponseList
        
        Exit Sub

    End Sub

    '関数名：publngResponseEnd
    '機　能：ﾚｽﾎﾟﾝｽ取得終了
    '引　数：lstrFromName：ﾌｫｰﾑ名
    '　　　：lstrEventName：ｲﾍﾞﾝﾄ名
    '戻り値：測定時間(-1:異常、0以上：正常→処理時間ms単位)
    '作成日：2004/03/10 (Wed) 18:28:00 T.Kitagawa
    '更新日：2019/10/25 (Fri) 14:44:12 T.Oide
    '備　考：例：処理時間が1秒120ミリ秒の場合は「1120」が戻り値となる
    '　　　：2004/11/02 (Tue) 15:33:39 T.Kitagawa　ﾌｫｰﾑ名とｲﾍﾞﾝﾄ名がNullの場合は測定しないように修正
    Public Function publngResponseEnd(Optional ByVal lstrFromName As String = vbNullString, _
                                      Optional ByVal lstrEventName As String = vbNullString) As Integer
        
        Dim ltypTmResponse          As TmResponse               'ﾚｽﾎﾟﾝｽ測定送信構造体
        Dim lblnAns                 As Boolean                  '結果取得(True:正常,False:異常)
        Dim lblnAnsInit             As Boolean                  '初期化結果格納
        Dim lstrExeName             As String                   'EXEﾌｧｲﾙ名
        Dim llngExeTime             As Int64                    '処理時間(10msec単位) NSYS: Int32では24日でオーバーフローするのでInt64化
        Dim llngErrFlg              As Integer                  'ｴﾗｰﾌﾗｸﾞ（0:正常、1:測定開始なし、2:２秒以上経過、3:３秒以上経過、7:測定終了なし、8:開始と終了が前後、9:測定送信ｴﾗｰ)
        Dim lstrErrStartDateTime    As String                   'ｴﾗｰﾒｯｾｰｼﾞ表示用測定開始日時（yyyy/mm/dd hh:mm:ss)
        Dim lstrErrEndDateTime      As String                   'ｴﾗｰﾒｯｾｰｼﾞ表示用測定終了日時（yyyy/mm/dd hh:mm:ss)
        Dim lstrCommandLine()       As String                   'ｺﾏﾝﾄﾞﾗｲﾝ
        Dim lkey                    As Tuple(Of String, String) '複合キー
        Dim ltypTmResponseList      As typTmResponseList        'ﾚｽﾎﾟﾝｽ測定送信用構造体

        '@↓2019/10/25 (Fri) 14:41:09 T.Oide *************************************************
            Exit Function
        '@↑2019/10/25 (Fri) 14:41:09 T.Oide *************************************************
        
        '@戻り値の初期値設定
        publngResponseEnd = -1
        
        '@ｴﾗｰﾌﾗｸﾞの初期値設定
        llngErrFlg = 0
        
        '@ｴﾗｰﾒｯｾｰｼﾞ表示用測定終了日時の設定
        lstrErrEndDateTime = Format$(Today, CPstrDateTimeYMD) & " " & Format$(TimeOfDay, CPstrDateFormatHMS)
        
        '@ﾃｽﾄﾓｰﾄﾞの設定（ｺﾏﾝﾄﾞﾊﾟﾗﾒｰﾀの第２引数が"D"の場合はﾃｽﾄﾓｰﾄﾞ、それ以外は本場と認識する
        If pstrTestStatus = vbNullString Then
            '@ｺﾏﾝﾄﾞﾗｲﾝより取得
            lstrCommandLine = Split(Command, ",")
            If UBound(lstrCommandLine) >= 1 Then
                pstrTestStatus = lstrCommandLine(1)
            End If
            If pstrTestStatus = vbNullString Then
                '@本番ﾓｰﾄﾞ設定（指定されていない場合ほもう１度取得しないように空白を設定する）
                pstrTestStatus = " "
            End If
        End If
        
        '@ｺﾝﾋﾟｭｰﾀ名(META実行時はWBTのｸﾗｲｱﾝﾄ名)の設定
        Call pubGetWbtComputerName()
        
        '@IPｱﾄﾞﾚｽ(META実行時はMETAｻｰﾊﾞのIPｱﾄﾞﾚｽ、META実行時以外は自ｸﾗｲｱﾝﾄのIPｱﾄﾞﾚｽ)の設定
        If Trim(pstrIpAddress) = vbNullString Then
            '@IPｱﾄﾞﾚｽ(API)取得
            pstrIpAddress = pubstrGetIpAddress()
        End If
        
        '@EXEﾌｧｲﾙ名の設定
        lstrExeName = My.Application.Info.AssemblyName
        
        '@複合キー生成
        lkey = Tuple.Create(lstrFromName, lstrEventName)

        '@ﾚｽﾎﾟﾝｽ測定送信用構造体の決定
        If (lstrFromName = vbNullString OrElse lstrEventName = vbNullString) OrElse _
            ptypTmResponseList Is Nothing OrElse _
            ptypTmResponseList.TryGetValue(lkey, ltypTmResponseList) = False Then

            '@開始情報が無い場合は処理をｽｷｯﾌﾟする
            '@ｴﾗｰﾒｯｾｰｼﾞBOXの表示（ﾚｽﾎﾟﾝｽ測定開始なし）
            Call prvResponseErrMsgBox(1, lstrFromName, lstrEventName, vbNullString, lstrErrEndDateTime, 0)
            '@ﾏｳｽｱｲｺﾝ（ﾃﾞﾌｫﾙﾄ）
            Cursor.Current = Cursors.Default
            Exit Function
        End If
        
        '@処理中止ｽﾃｰﾀｽの場合は該当配列の初期化後、処理をｽｷｯﾌﾟする
        If ltypTmResponseList.lngStartCancelStatus = 1 Then
            '@該当配列の初期化
            '@ﾚｽﾎﾟﾝｽ測定送信用構造体の削除
            ptypTmResponseList.Remove(lkey)
            '@ﾏｳｽｱｲｺﾝ（ﾃﾞﾌｫﾙﾄ）
            Cursor.Current = Cursors.Default
            Exit Function
        End If
        
        '@ｴﾗｰﾒｯｾｰｼﾞ表示用測定開始日時の設定
        lstrErrStartDateTime = Format$(ltypTmResponseList.tmStartDateTime, CPstrDateTimeYMD & " " & CPstrDateFormatHMS)
        
        '@処理時間(msec)の計算
        llngExeTime = CType((DateTime.Now - ltypTmResponseList.tmStartDateTime).TotalMilliseconds, Int64)

        '@最大処理時間の判定
        If llngExeTime > CMlngMaxTimer Then
            '@最大処理時間を超えた場合はのTimer関数の最大値を設定する
            llngExeTime = CMlngMaxTimer
        End If
        
        If llngExeTime < 0 Then
            '@現在の日付がｲﾍﾞﾝﾄ開始日以前の場合は何もしない（測定時間を送信しない）で処理を終わらせる
            '@ｴﾗｰﾒｯｾｰｼﾞBOXの表示（開始と終了が前後している）
            Call prvResponseErrMsgBox(8, lstrFromName, lstrEventName, lstrErrStartDateTime, lstrErrEndDateTime, 0)
            '@ﾏｳｽｱｲｺﾝ（ﾃﾞﾌｫﾙﾄ）
            Cursor.Current = Cursors.Default
            Exit Function
        End If
        
        '@ﾚｽﾎﾟﾝｽ測定送信ﾃﾞｰﾀ格納
        With ltypTmResponse
            .strHostName = pstrComputerName                     'ﾎｽﾄ名
            .strIPaddress = pstrIpAddress                       'IPｱﾄﾞﾚｽ
            .strExeName = lstrExeName                           'EXEﾌｧｲﾙ名
            .strFormName = lstrFromName                         '画面識別名
            .strEventName = lstrEventName                       'ｲﾍﾞﾝﾄ(処理)名
            .strExeTime = Format$(llngExeTime, "0")             '処理時間(msec)
        End With

        '@ACTの初期化済の確認
        If pTerm Is Nothing = True Then
            '@ACT初期化
            lblnAnsInit = pubblnAct_Init()
            If lblnAnsInit = False Then
                '@ﾏｳｽｱｲｺﾝ(ﾃﾞﾌｫﾙﾄ)
                Cursor.Current = Cursors.Default
                '@ｱﾌﾟﾘｹｰｼｮﾝ終了
                Application.Exit    'Endステートメント
                Exit Function
            End If
        End If
        
        '@ﾒｯｾｰｼﾞ送信処理呼び出し
        lblnAns = pubblnResponse_Ins(CMstrutiltmresponseVer, ltypTmResponse)
        If lblnAns = True Then
            '@戻り値の設定
            publngResponseEnd = llngExeTime
        Else
            '@ｴﾗｰﾒｯｾｰｼﾞBOXの表示(測定送信ｴﾗｰ)
            Call prvResponseErrMsgBox(9, lstrFromName, lstrEventName, lstrErrStartDateTime, lstrErrEndDateTime, llngExeTime)
        End If

        '@該当配列の初期化
        '@ﾚｽﾎﾟﾝｽ測定送信用構造体の削除
        ptypTmResponseList.Remove(lkey)

        '@処理経過時間の判定
        Select Case llngExeTime
            Case 2000 To 2999
                '@ｴﾗｰﾒｯｾｰｼﾞBOXの表示(２秒以上経過)
                Call prvResponseErrMsgBox(2, lstrFromName, lstrEventName, lstrErrStartDateTime, lstrErrEndDateTime, llngExeTime)
            Case Is >= 3000
                '@ｴﾗｰﾒｯｾｰｼﾞBOXの表示(３秒ﾙｰﾙ違反)
                Call prvResponseErrMsgBox(3, lstrFromName, lstrEventName, lstrErrStartDateTime, lstrErrEndDateTime, llngExeTime)
        End Select

        '@ﾏｳｽｱｲｺﾝ(ﾃﾞﾌｫﾙﾄ)
        Cursor.Current = Cursors.Default
        
        Exit Function
        
    End Function

    '関数名：pubResponseCancel
    '機　能：ﾚｽﾎﾟﾝｽ取得開始のｷｬﾝｾﾙ
    '引　数：lstrFromName：ﾌｫｰﾑ名
    '　　　：lstrEventName：ｲﾍﾞﾝﾄ名
    '戻り値：なし
    '作成日：2004/03/12 (Fri) 19:13:06 T.Kitagawa
    '更新日：2019/10/25 (Fri) 14:40:39 T.Oide
    '備　考：
    Public Sub pubResponseCancel(Optional ByVal lstrFromName As String = vbNullString, _
                                Optional ByVal lstrEventName As String = vbNullString)
        
        Dim lkey                As Tuple(Of String, String) '複合キー
        Dim ltypTmResponseList  As typTmResponseList        'ﾚｽﾎﾟﾝｽ測定送信用構造体

        '@↓2019/10/25 (Fri) 14:41:09 T.Oide **************************************************
            Exit Sub
        '@↑2019/10/25 (Fri) 14:41:09 T.Oide *************************************************

        '@複合キー生成
        lkey = Tuple.Create(lstrFromName, lstrEventName)

        '@ﾚｽﾎﾟﾝｽ測定送信用構造体の決定
        If ptypTmResponseList Is Nothing OrElse _
            ptypTmResponseList.TryGetValue(lkey, ltypTmResponseList) = False Then

            '@開始情報が無い場合は処理をｽｷｯﾌﾟする
            '@ﾏｳｽｱｲｺﾝ(ﾃﾞﾌｫﾙﾄ)
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        
        '@ﾚｽﾎﾟﾝｽ測定送信用構造体へ測定開始中止ｽﾃｰﾀｽを設定
        ltypTmResponseList.lngStartCancelStatus = 1      '測定開始中止ｽﾃｰﾀｽ(1:中止)

        ptypTmResponseList(lkey) = ltypTmResponseList
        
        '@ﾏｳｽｱｲｺﾝ(ﾃﾞﾌｫﾙﾄ)
        Cursor.Current = Cursors.Default
        
        Exit Sub
        
    End Sub

    '関数名：prvResponseErrMsgBox
    '機　能：ﾚｽﾎﾟﾝｽ測定用ｴﾗｰﾒｯｾｰｼﾞ表示
    '引　数：llngErrFlg：ｴﾗｰﾌﾗｸﾞ(0:正常、1:測定開始なし、2:２秒以上経過、3:３秒以上経過、7:測定終了なし、8:開始と終了が前後、9:測定送信ｴﾗｰ)
    '　　　：lstrFromName：ﾌｫｰﾑ名
    '　　　：lstrEventName：ｲﾍﾞﾝﾄ名
    '　　　：lstrStartDateTime：測定開始日時
    '　　　：lstrEndDateTime：測定終了日時
    '　　　：llngExeTime：測定時間(msec)
    '戻り値：なし
    '作成日：2004/03/12 (Fri) 20:32:59 T.Kitagawa
    '更新日：2004/03/12 (Fri) 20:32:59
    '備　考：
    Private Sub prvResponseErrMsgBox(ByVal llngErrFlg As Integer, _
                                     ByVal lstrFromName As String, _
                                     ByVal lstrEventName As String, _
                                     ByVal lstrStartDateTime As String, _
                                     ByRef lstrEndDateTime As String, _
                                     Optional ByVal llngExeTime As Integer = 0)
        
        Dim lstrErrMsg              As String               'ｴﾗｰﾒｯｾｰｼﾞ
        Dim lstrResponseMessage     As String               'ｴﾗｰﾒｯｾｰｼﾞBOX表示用ﾀｲﾄﾙ
        
        '@ﾃｽﾄﾓｰﾄﾞの判定(ﾃｽﾄﾓｰﾄﾞのみﾒｯｾｰｼﾞBOXを表示する)
        If pstrTestStatus <> CPstrDeveStatus Then
           Exit Sub
        End If
        
        '@ｴﾗｰﾒｯｾｰｼﾞの作成
        Select Case llngErrFlg
            Case 1
                '@測定開始なし
    '            "メッセージコード：C_W71%0$$このイベントは測定開始されていません。処理を必ず見直して下さい。$" & _
    '                                                         "フォーム名：%1 イベント名：%2$開始日時：%3$終了日時：%4$測定時間：%5 秒です。"
                '@表示ﾒｯｾｰｼﾞ変換
                lstrErrMsg = pubstrMsgReplace_Set(CPstrMsgWar0071, lstrFromName, lstrEventName, lstrStartDateTime, lstrEndDateTime, StrConv(Format(llngExeTime / 1000, "#,##0.000"), vbWide))
            Case 2
                '@２秒以上経過
    '            "メッセージコード：C_W72%0$$処理時間が２秒以上経過しています！処理を必ず見直して下さい。$" & _
    '                                                         "フォーム名：%1 イベント名：%2$開始日時：%3$終了日時：%4$測定時間：%5 秒です。"            '@表示ﾒｯｾｰｼﾞ変換
                lstrErrMsg = pubstrMsgReplace_Set(CPstrMsgWar0072, lstrFromName, lstrEventName, lstrStartDateTime, lstrEndDateTime, StrConv(Format(llngExeTime / 1000, "#,##0.000"), vbWide))
            Case 3
                '@３秒以上経過
    '            "メッセージコード：C_W73%0$$３秒ルール違反です！！処理を必ず見直して下さい。$" & _
    '                                                         "フォーム名：%1 イベント名：%2$開始日時：%3$終了日時：%4$測定時間：%5 秒です。"
                '@表示ﾒｯｾｰｼﾞ変換
                lstrErrMsg = pubstrMsgReplace_Set(CPstrMsgWar0073, lstrFromName, lstrEventName, lstrStartDateTime, lstrEndDateTime, StrConv(Format(llngExeTime / 1000, "#,##0.000"), vbWide))
            Case 7
                '@測定終了なし
    '            "メッセージコード：C_W74%0$$このイベントは前回の測定終了を完了していません。処理を必ず見直して下さい。$" & _
    '                                                         "フォーム名：%1 イベント名：%2$開始日時：%3$終了日時：%4$測定時間：%5 秒です。"            '@表示ﾒｯｾｰｼﾞ変換
                lstrErrMsg = pubstrMsgReplace_Set(CPstrMsgWar0074, lstrFromName, lstrEventName, lstrStartDateTime, lstrEndDateTime, StrConv(Format(llngExeTime / 1000, "#,##0.000"), vbWide))
            Case 8
                '@開始と終了が逆転
    '            "メッセージコード：C_W75%0$$測定開始日時と測定終了日時が逆転しています。処理を必ず見直して下さい。$" & _
    '                                                         "フォーム名：%1 イベント名：%2$開始日時：%3$終了日時：%4$測定時間：%5 秒です。"
                '@表示ﾒｯｾｰｼﾞ変換
                lstrErrMsg = pubstrMsgReplace_Set(CPstrMsgWar0075, lstrFromName, lstrEventName, lstrStartDateTime, lstrEndDateTime, StrConv(Format(llngExeTime / 1000, "#,##0.000"), vbWide))
            Case 9
                '@測定送信時エラー
                '@表示ﾒｯｾｰｼﾞ変換
    '            "メッセージコード：C_W76%0$$測定結果送信時にエラーが発生しました。$" & _
    '                                                         "フォーム名：%1 イベント名：%2$開始日時：%3$終了日時：%4$測定時間：%5 秒です。"
                lstrErrMsg = pubstrMsgReplace_Set(CPstrMsgWar0076, lstrFromName, lstrEventName, lstrStartDateTime, lstrEndDateTime, StrConv(Format(llngExeTime / 1000, "#,##0.000"), vbWide))
            Case Else
                lstrErrMsg = vbNullString
        End Select
        
        '@ｴﾗｰﾒｯｾｰｼﾞBOX表示用ﾀｲﾄﾙの設定
        If llngErrFlg = 7 Then
            lstrResponseMessage = CmstrResponseStartMessage         'ﾚｽﾎﾟﾝｽ測定開始時のｴﾗｰ
        Else
            lstrResponseMessage = CmstrResponseEndMessage           'ﾚｽﾎﾟﾝｽ測定終了時のｴﾗｰ
        End If
        
        '@ｴﾗｰﾒｯｾｰｼﾞ集をﾒｯｾｰｼﾞBOX表示する
        Call publngMsgBoxInfo(lstrErrMsg, vbExclamation, lstrResponseMessage, True, 12)

    End Sub

    '関数名：pubstrGetComputerName
    '機　能：ｺﾝﾋﾟｭｰﾀ名の取得
    '引　数：なし
    '戻り値：ｺﾝﾋﾟｭｰﾀ名
    '作成日：2004/03/09 (Tue) 19:14:04 T.Kitagawa
    '更新日：2004/04/14 (Wed) 10:34:58 T.Kitagawa
    '備　考：
    Public Function pubstrGetComputerName() As String
        
        '@ｺﾝﾋﾟｭｰﾀ名の取得
        pubstrGetComputerName = SystemInformation.ComputerName

    End Function

    '関数名：pubstrGetIpAddress
    '機　能：IPｱﾄﾞﾚｽの取得
    '引　数：なし
    '戻り値：IPｱﾄﾞﾚｽ
    '作成日：2004/03/10 (Wed) 11:39:33 T.Kitagawa
    '更新日：2004/04/14 (Wed) 10:35:03 T.Kitagawa
    '備　考：
    Public Function pubstrGetIpAddress() As String
        
        Dim lstrName        As String
        Dim laryAddressList As IPAddress()

        '@IPｱﾄﾞﾚｽのの初期化
        pubstrGetIpAddress = vbNullString
        
        '@IPｱﾄﾞﾚｽの取得
        'NSYS ホスト名を取得する
        lstrName = Dns.GetHostName()

        'NSYS ホスト名からIPアドレスを取得する
        laryAddressList = Dns.GetHostAddresses(lstrName)
        For Each ipAddr In laryAddressList
            If ipAddr.AddressFamily = AddressFamily.InterNetwork Then
                pubstrGetIpAddress = ipAddr.ToString()
            End If
        Next

    End Function

    '関数名：pubVsfInfo_Disp
    '機　能：ｽﾃｰﾀｽ画面にﾒｯｾｰｼﾞ表示
    '引　数：lstrInfo：ﾒｯｾｰｼﾞ
    '　　　：lblnErr：文字色設定(True：赤、False：黒)
    '戻り値：なし
    '作成日：2004/04/23 (Fri) 09:16:42 M.Miura
    '更新日：2004/04/23 (Fri) 09:16:42
    '備　考：
    Public Sub pubVsfInfo_Disp(ByVal lstrInfo As String, Optional ByVal lblnErr As Boolean = False)
        
        Dim lstrMsg     As String   'ﾒｯｾｰｼﾞ
        Dim lstrMsgWk   As String   'ﾒｯｾｰｼﾞﾜｰｸ
        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim llngRCnt    As Integer  '行ｶｳﾝﾄ
        Dim llngMLen    As Integer  'ﾒｯｾｰｼﾞの文字数

        '@ﾒｯｾｰｼﾞがない場合は抜ける
        If Trim(lstrInfo) = vbNullString Then Exit Sub

        With frmxxCM0100.Instance.vsfInfo
            
            '@vbCrLfは削除
            lstrInfo = Replace(lstrInfo, vbCrLf, CPstrSpace)
            
            '@ﾒｯｾｰｼﾞが1行に表示できない場合
            If LenB(lstrInfo) > CMlngLenB Then
                llngRCnt = 0
                '@ﾒｯｾｰｼﾞの文字数格納
                llngMLen = Len(lstrInfo)
                For llngCnt = 1 To llngMLen
                    '@１文字格納
                    lstrMsgWk = Mid$(lstrInfo, llngCnt, 1)
                    '@ﾒｯｾｰｼﾞが1行に表示できない場合
                    If LenB(lstrMsg & lstrMsgWk) > CMlngLenB Then
                        '@ﾒｯｾｰｼﾞの１行目の場合
                        If llngRCnt = 0 Then
                            '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ追加　「99:99:99 > ﾒｯｾｰｼﾞ」
                            .AddItem(Format$(TimeOfDay, CPstrDateFormatHMS) & CMstrDainari & lstrMsg)
                            '@新しいﾒｯｾｰｼﾞを最上段に移動
                            .Rows(.Rows.Count - 1).Move(.Rows.Fixed)
                        Else
                            '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ追加　「      > ﾒｯｾｰｼﾞ」
                            .AddItem(CMstrSpace8 & CMstrDainari & lstrMsg)
                            '@新しいﾒｯｾｰｼﾞを上段に移動
                            .Rows(.Rows.Count - 1).Move(.Rows.Fixed + llngRCnt)
                        End If
                        
                        '@ｴﾗｰｽﾃｰﾀｽの場合
                        If lblnErr = True Then
                            '@背景色設定
                            Call .Select(.Rows.Fixed + llngRCnt, .Cols.Fixed)
                            '@文字色設定(赤)
                            Dim newStyle As CellStyle
                            newStyle = .Styles.Add("CustomStyle_ForeColor_CMlngStErrForeColor")
                            newStyle.ForeColor = ColorTranslator.FromWin32(CMlngStErrForeColor)
                            Dim cellRange As CellRange
                            cellRange = .Selection
                            cellRange.Style = newStyle
                        End If
                        
                        '@行ｶｳﾝﾄ追加
                        llngRCnt = llngRCnt + 1
                        '@ﾒｯｾｰｼﾞ初期化
                        lstrMsg = vbNullString
                    End If
                    
                    '@ﾒｯｾｰｼﾞ格納
                    lstrMsg = lstrMsg & lstrMsgWk
                    
                Next llngCnt
                
                '@ﾒｯｾｰｼﾞがある場合
                If lstrMsg <> vbNullString Then
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ追加　「      > ﾒｯｾｰｼﾞ」
                    .AddItem(CMstrSpace8 & CMstrDainari & lstrMsg)
                    '@新しいﾒｯｾｰｼﾞを上段に移動
                    .Rows(.Rows.Count - 1).Move(.Rows.Fixed + llngRCnt)
                    '@ｴﾗｰｽﾃｰﾀｽの場合
                    If lblnErr = True Then
                        '@文字色設定(赤)
                        Call .Select(.Rows.Fixed + llngRCnt, .Cols.Fixed)
                        Dim newStyle As CellStyle
                        newStyle = .Styles.Add("CustomStyle_ForeColor_CMlngStErrForeColor")
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngStErrForeColor)
                        Dim cellRange As CellRange
                        cellRange = .Selection
                        cellRange.Style = newStyle
                    End If
                End If
            Else
                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ追加　「99:99:99 > ﾒｯｾｰｼﾞ」
                .AddItem(Format$(TimeOfDay, CPstrDateFormatHMS) & CMstrDainari & lstrInfo)
                '@新しいﾒｯｾｰｼﾞを最上段に移動
                .Rows(.Rows.Count - 1).Move(.Rows.Fixed)
                '@ｴﾗｰｽﾃｰﾀｽの場合
                If lblnErr = True Then
                    '@文字色設定(赤)
                    Call .Select(.Rows.Fixed, .Cols.Fixed)
                    Dim newStyle As CellStyle
                    newStyle = .Styles.Add("CustomStyle_ForeColor_CMlngStErrForeColor")
                    newStyle.ForeColor = ColorTranslator.FromWin32(CMlngStErrForeColor)
                    Dim cellRange As CellRange
                    cellRange = .Selection
                    cellRange.Style = newStyle
                End If
            End If
        
            '@20件を超えたら20行に設定
            If .Rows.Count > CMlngInfoRows Then
                .Redraw = False
                .Rows.Count = CMlngInfoRows
                .Redraw = True
            End If
            
            With frmxxCM0100.Instance
                '@ﾎﾞﾀﾝﾛｯｸ制御
                Call pubVsfDisp(.vsfInfo, .cmdUP, .cmdDown)
            End With
        
        End With
        
    End Sub

    '関数名：publngMsgBoxInfo
    '機　能：ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示とｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
    '引　数：lstrPrompt：表示ﾒｯｾｰｼﾞ
    '　　　：lintType：ﾒｯｾｰｼﾞﾀｲﾌﾟ
    '　　　：lstrTitle：ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ
    '　　　：lblnBold：強調表示(任意) True = 強調する
    '　　　：lintFontSize：ﾌｫﾝﾄｻｲｽﾞ
    '　　　：lblnNormalButtonSize：ﾎﾞﾀﾝｻｲｽﾞ (False:工程端末ｻｲｽﾞ用大 , True:ﾏｽﾀ用標準ｻｲｽﾞ)
    '戻り値：選択されたﾎﾞﾀﾝ値(vbYes, vbNo)
    '作成日：2004/04/23 (Fri) 17:09:08 M.Miura
    '更新日：2004/04/23 (Fri) 17:09:08
    '備　考：用意されているﾀｲﾌﾟ
    '　　　：vbQuestion   (値 =32)　→ ? 問い合わせ("はい(&Y)", "いいえ(&N)")
    '　　　：vbExclamation(値 =48)　→ ! 注意("OK")
    '　　　：vbInformation(値 =64)  → i 情報("OK")
    '　　　：vbRetry      (値 = 4)  → ? 再試行("再試行(&R)", "ｷｬﾝｾﾙ")
    '　　　：vbYesNoCancel(値 = 3)  → ! 確認("はい(&Y), いいえ(&N)", "ｷｬﾝｾﾙ")
    '　　　：vbOKCancel   (値 = 1)  → i 情報("OK", "ｷｬﾝｾﾙ")
    '　　　：vbNo         (値 = 7)  → ! 注意("はい(&Y)", "いいえ(&N)")
    Public Function publngMsgBoxInfo(ByVal lstrPrompt As String, ByVal lintType As Short, ByVal lstrTitle As String, _
                                     Optional ByVal lblnBold As Boolean = False, Optional ByVal lintFontSize As Short   = 11, _
                                     Optional ByVal lblnNormalButtonSize As Boolean = False) As Integer
                                     
        '@ﾒｯｾｰｼﾞﾎﾞｯｸｽ
        publngMsgBoxInfo = publngMsgBox(lstrPrompt, lintType, lstrTitle, lblnBold, lintFontSize, lblnNormalButtonSize)
        
        '@ﾒｯｾｰｼﾞが「注意(！)」の場合
        If lintType = vbExclamation Then
            '@ｽﾃｰﾀｽ画面に表示(文字色：赤)
            Call pubVsfInfo_Disp(lstrPrompt, True)
        End If
        
    End Function

    '関数名：pubstrErrMsg_Set
    '機　能：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ判定,機能ﾊﾞｰｼﾞｮﾝ判定,ｴﾗｰﾒｯｾｰｼﾞ表示処理
    '引　数：laMsg：ｻｰﾊﾞｰから受信したｴﾗｰ文字列
    '　　　：lstrClientVer：ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '　　　：lstrCLFuncVer：
    '戻り値：なし
    '作成日：2004/06/04 (Fri) 13:30:36 N.Kasai
    '更新日：2004/09/29 (Wed) 20:46:06 H.Wajima
    '備　考：ｻｰﾊﾞｰとｸﾗｲｱﾝﾄのVersionを判定してｴﾗｰﾒｯｾｰｼﾞを設定する。
    '　　　：2004/09/29 (Wed) 20:46:06 H.Wajima 機能ﾊﾞｰｼﾞｮﾝﾒｯｾｰｼﾞ対応
    Public Sub pubstrErrMsg_Set(ByVal laMsg As TfMsg, ByVal lstrClientVer As String, Optional ByVal lstrCLFuncVer As String = vbNullString)

        Dim lstrMsg         As String               '表示ﾒｯｾｰｼﾞ格納
        Dim lstrMsgCode     As String               'ｺｰﾄﾞ格納
        Dim lstrCategory    As String               'ﾒｯｾｰｼﾞ識別子格納
        Dim lstrErrMsg      As String               '表示用ｴﾗｰﾒｯｾｰｼﾞ
                                      
        '@表示ﾒｯｾｰｼﾞ取得
        Call laMsg.getString(CPstrMSG, lstrMsg)
        
        '@ｺｰﾄﾞ取得
        Call laMsg.getString(CPstrMSGCODE, lstrMsgCode)
        
        '@ﾒｯｾｰｼﾞ識別子取得
        Call laMsg.getString(CPstrCATEGPRY, lstrCategory)
        
        '@ｻｰﾊﾞｰとｸﾗｲｱﾝﾄのﾊﾞｰｼﾞｮﾝ(ﾒｯｾｰｼﾞ識別子で判定)を判定
        Select Case lstrCategory
            Case CPstrVersion
                '@Msgﾊﾞｰｼﾞｮﾝ不一致
                '@表示ﾒｯｾｰｼﾞ変換
                '@"メッセージコード：<TRM07E>$$システムが更新されています。$再起動してください。$(C：%1 S：%2)"
                lstrErrMsg = pubstrMsgReplace_Set(CPstrMsgErr0007, lstrClientVer, lstrMsg)
            Case CPstrFunction
                '@機能ﾊﾞｰｼﾞｮﾝ不一致
                '@表示ﾒｯｾｰｼﾞ変換
                '@"メッセージコード：<TRM0FE>$$システムが更新されています。$再起動してください。$(C：%1 S：%2)"
                lstrErrMsg = pubstrMsgReplace_Set(CPstrMsgErr000F, lstrCLFuncVer, lstrMsg)
            Case Else
                '@表示するｴﾗｰﾒｯｾｰｼﾞの作成
                lstrErrMsg = CPstrStartMsgCode & lstrMsgCode & CPstrEndMsgCode & "$$" & lstrMsg
        End Select
        
        '@表示ﾒｯｾｰｼﾞ変換
        pstrDMsg = pubstrMsgReplace_Set(lstrErrMsg)
            
        '@ｺｰﾄﾞがある場合
        If lstrMsgCode <> vbNullString Then
            '@ﾒｯｾｰｼﾞ識別子の判定
            If lstrCategory = CPstrInf Then
                '@INFの場合
                    '@ｽﾃｰﾀｽ画面にﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
            Else
                '@ﾒｯｾｰｼﾞ表示
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
            End If
        Else
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000C)
            '@ﾒｯｾｰｼﾞ表示("<TRM0CE>$$システムエラーです。エラーメッセージは取得できませんでした。$システム担当者に連絡して下さい。")
            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
        End If
        
    End Sub

    '関数名：pubblnYearRange_Chk
    '機　能：日付範囲ﾁｪｯｸ(1900/01/01～2100/12/31)
    '引　数：lstrYear：年月日
    '戻り値：True：正常(1900/01/01～2100/12/31)、False：その他
    '作成日：2004/06/22 (Tue) 12:50:22 M.Miura
    '更新日：2004/06/22 (Tue) 12:50:22
    '備　考：
    Public Function pubblnYearRange_Chk(ByVal lstrYear As String) As Boolean
        Dim lstrYearWk  As String   '日付
        
        '@日付の場合
        If IsDate(lstrYear) = True Then
            '@比較用ﾌｫｰﾏｯﾄに変更
            lstrYearWk = Format$(CDate(lstrYear), CPstrDateTimeYMD)
            If CMstrStartYear <= lstrYearWk And CMstrEndYear >= lstrYearWk Then
                '@正常(1900/01/01～2100/12/31の範囲内)
                pubblnYearRange_Chk = True
            End If
        End If
        
    End Function

    '関数名：pubMenuExpand_Disp
    '機　能：ﾒﾆｭｰｻｲｽﾞ変更処理
    '引　数：lblnExpandOnly：メニューを広げたいだけの場合 True、縮小もさせたい場合 False
    '戻り値：なし
    '作成日：2004/05/25 (Tue) 11:13:47 M.Miura
    '更新日：2019/01/30 (Wed) 13:47:32 T.Oide
    '備　考：
    Public Sub pubMenuExpand_Disp(Optional ByVal lblnExpandOnly As Boolean = True)
        
        Dim objfrmMenu              As frmxxMN0000      'ﾒｲﾝﾒﾆｭｰ画面
        Dim objfrmMenuInfo          As frmxxMN0002      'おしらせ画面
        Dim objfrmxxCM0100          As frmxxCM0100      'ｽﾃｰﾀｽ画面
        Dim llngCnt                 As Integer          'ｶｳﾝﾝﾄ
        Dim lstrVersion             As String           'ｼｽﾃﾑﾊﾞｰｼﾞｮﾝ
        Dim lstrSBIDName            As String           'SB和名
        Dim lstrTerminalModeName    As String           '端末区分和名
        
        '@ﾌｫｰﾑ設定
        For llngCnt = 0 To Application.OpenForms.Count - 1
            Select Case Application.OpenForms(llngCnt).Name
                '@ﾒｲﾝﾒﾆｭｰ画面の場合
                Case CPstrFrmMenu
                    objfrmMenu = Application.OpenForms(llngCnt)
                '@お知らせ画面の場合
                Case CPstrFrmMenuInfo
                    objfrmMenuInfo = Application.OpenForms(llngCnt)
                '@ｽﾃｰﾀｽ画面の場合
                Case CPstrFrmxxCM0100
                    objfrmxxCM0100 = Application.OpenForms(llngCnt)
            End Select
        Next llngCnt
        
        '@ﾌｫｰﾑがない場合は中止
        If TypeName(objfrmMenu) = CMstrNothing Or _
           TypeName(objfrmxxCM0100) = CMstrNothing Then
                    
            '@ﾌｫｰﾑの解放
            objfrmMenu = Nothing
            objfrmMenuInfo = Nothing
            objfrmxxCM0100 = Nothing
            
            Exit Sub
        End If

        'NSYS メニューを広げたいだけの場合で、メニューの幅がすでに広い場合、処理を抜ける
        If lblnExpandOnly = True AndAlso objfrmMenu.Left <= CPlngAppliNarrowWidth Then
            Exit Sub
        End If
        
        '@Versionの表記方法変更　X.XX.XXXX→X.XXX.XXに変更
        '@ﾊﾞｰｼﾞｮﾝ番号の取得
        lstrVersion = CPstrAppVer & CStr(My.Application.Info.Version.Major) & _
                      CPstrAppVerPeriod & Format$(My.Application.Info.Version.Minor, "000") & _
                      CPstrAppVerPeriod & Format$(My.Application.Info.Version.MinorRevision, "00")
        
        '@ｼｽﾃﾑﾌﾞﾛｯｸ判定
        Select Case pstrSBID
            Case CPstrSBID1A0
                '@基板工程の場合
                '@基板工程の和名をｾｯﾄ
                lstrSBIDName = CPstrSBID1A0Name
            Case CPstrSBID2A0
                '@組立工程の場合
                '@組立工程の和名をｾｯﾄ
                lstrSBIDName = CPstrSBID2A0Name
    '@↓2019/01/30 (Wed) 13:44:01 T.Oide **************************************************
            Case CPstrSBID3A0
                '@ALD工程の場合
                '@ALD工程の和名をｾｯﾄ
                lstrSBIDName = CPstrSBID3A0Name
    '@↑2019/01/30 (Wed) 13:44:01 T.Oide **************************************************
            Case Else
                '@上記以外の場合
                '@空白をｾｯﾄ
                lstrSBIDName = vbNullString
        End Select
        
        '@端末区分判定
        Select Case pstrTerminalMode
            Case CPstrManufactureStatus
                '@工程内端末
                lstrTerminalModeName = CPstrManufactureStatusName
            Case CPstrStaffStatus
                '@ｽﾀｯﾌ端末
                lstrTerminalModeName = CPstrStaffStatusName
            Case CPstrAdminStatus
                '@管理用(全項目表示)
                lstrTerminalModeName = CPstrAdminStatusName
            Case Else
                '@上記以外
                lstrTerminalModeName = vbNullString
        End Select
            
        With objfrmMenu
            '@メニュー画面(frmMenu)の設定
            '@フォームの左端の位置を判定する
            If .Left > CPlngAppliNarrowWidth Then
                '@メニューの幅が狭いとき
                '@メニューの幅を広げる
                'NSYS ToolWindowは両側 8px( = My.Settings.FormOffset + 1) 透過領域となる
                .Left = CPlngMenuWideLeft - (My.Settings.FormOffset + 1)
                .Width = CPlngMenuWideWidth + ((My.Settings.FormOffset + 1) * 2)
                .Text = CPstrMenuFormCaption & " - " & _
                            lstrSBIDName & lstrTerminalModeName & _
                            " - " & lstrVersion
                .tabMenu.Visible = True
                .fraCarrier.Visible = True
            Else
                '@メニューの幅が広いとき
                '@メニューの幅を狭める
                'NSYS ToolWindowは両側 8px( = My.Settings.FormOffset + 1) 透過領域となる
                .Left = CPlngAppliWideWidth - (My.Settings.FormOffset * 3) - 1
                .Width = CPlngMenuNarrowWidth + ((My.Settings.FormOffset + 1) * 2)
    '            .Caption = vbNullString
                .tabMenu.Visible = False
                .fraCarrier.Visible = False
            End If

            'NSYS VB6では [無効化]→[タブコントロール非表示]→[有効化] 後で、
            '     残っているcmdExpandボタンに暗黙的にフォーカスが設定されるので、
            '     .NETでも明示的に再現する
            If .Left > CPlngAppliNarrowWidth Then
                pubSetFocus(.cmdExpand)
            End If
        End With
        
        '@メッセージ部分の▲▼ボタンの間のラベルの位置・サイズを設定
        With objfrmxxCM0100
            .lblSpace.Top = .cmdUP.Top
            .lblSpace.Left = .cmdUP.Left
            .lblSpace.Height = .cmdDown.Top + .cmdDown.Height - 11
            .lblSpace.Width = .cmdUP.Width
        End With
        
        '@メニューを最前面表示
        objfrmMenu.Activate()
        
        '@お知らせ画面がない場合は中止
        If TypeName(objfrmMenuInfo) = CMstrNothing Then
            '@ﾌｫｰﾑの解放
            objfrmMenu = Nothing
            objfrmMenuInfo = Nothing
            objfrmxxCM0100 = Nothing
            
            Exit Sub
        End If
        
        With objfrmMenuInfo
            '@お知らせ画面
            If .Visible = True Then
                '@お知らせ画面が表示されている場合
                .Width = objfrmMenu.Left + (My.Settings.FormOffset * 3) + 1
            End If
        End With
        
        '@ﾌｫｰﾑの解放
        objfrmMenu = Nothing
        objfrmMenuInfo = Nothing
        objfrmxxCM0100 = Nothing
        
    End Sub

    '関数名：pubMenuItemCorrelation_Set
    '機　能：メニュー関連付け処理
    '引　数：lstrKey            ：メニューキー(機能ID)
    '　　　：lstrTitle          ：メニュータイトル
    '　　　：llngCarrTakeOver   ：キャリアＩＤ引継ぎフラグ
    '　　　：lstrForm           ：フォーム名
    '　　　：lstrEnableFlag     ：有効/無効ﾌﾗｸﾞ
    '戻り値：なし
    '作成日：2004/04/28 (Wed) 10:58:41 H.Wajima
    '更新日：2004/09/29 (Wed) 21:11:21 H.Wajima
    '備　考：メニューキーと、メニュータイトル・引継ぎフラグの関連付けを行う
    '更新日：2004/09/29 (Wed) 21:11:21 H.Wajima 機能ﾊﾞｰｼﾞｮﾝ削除
    Public Sub pubMenuItemCorrelation_Set(ByVal lstrKey As String, _
                                          ByRef lstrTitle As String, _
                                          Optional ByRef llngCarrTakeOver As Integer = 0, _
                                          Optional ByRef lstrForm As String = vbNullString, _
                                          Optional ByRef lstrEnableFlag As String = vbNullString)
        
        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
        
        '@引数の初期化
        lstrTitle = vbNullString
        llngCarrTakeOver = 0
        lstrForm = vbNullString
        lstrEnableFlag = vbNullString
        
        '@構造体が空の時は処理を抜ける
        If ptypFuncInfo.lngListCnt = 0 OrElse ptypFuncInfo.typFunctionList Is Nothing Then
            Exit Sub
        End If
        
        '@関数情報構造体のﾙｰﾌﾟ
        For llngCnt = 0 To ptypFuncInfo.typFunctionList.Count - 1
            With ptypFuncInfo.typFunctionList(llngCnt)
                '@機能IDの判定
                If lstrKey = .strFunctionID Then
                    '@機能IDが一致した場合
                    '@ﾀｲﾄﾙ(機能名)
                    lstrTitle = .strFunctionName
                    '@引継ぎﾌﾗｸﾞ
                    If IsNumeric(.strTakingOverFlag) = True Then
                        '@数値の場合
                        llngCarrTakeOver = CLng(.strTakingOverFlag)
                    Else
                        '@数値以外の場合
                        llngCarrTakeOver = 0
                    End If
                    '@ﾌｫｰﾑ名
                    lstrForm = .strFormName
                    '@有効/無効ﾌﾗｸﾞ
                    lstrEnableFlag = .strEnableFlag
                    
                    Exit For
                End If
            End With
        Next llngCnt
        
    End Sub

    '関数名：publngEnd_Proc
    '機　能：共通終了関数
    '引　数：lstrMenuKey    ：終了する機能ID
    '　　　：ltypCommonInfo ：次のﾌﾟﾛｸﾞﾗﾑに引き継ぐ情報
    '　　　：lstrNextMenuKey：次に起動する機能ID
    '戻り値：正常終了：CPlngNormalStatusCD、異常終了：CPlngErrorStatusCD
    '作成日：2004/04/20 (Tue) 10:42:12 H.Wajima
    '更新日：2018/09/25 (Tue) 19:36:07 Y.Yoneyama
    '備　考：FormがLoadされていないときに当関数を実行しても正常終了コードを返します。/引数変更(ｷｬﾘｱID⇒情報構造体)
    '　　　：2004/09/26 (Sun) 13:19:31 N.Kasai　    引き渡し構造体にｱﾝﾛｰﾀﾞｷｬﾘｱID追加
    '　　　：2004/09/29 (Wed) 21:08:59 H.Wajima     pubMenuItemCorrelation_Setの引数から機能ﾊﾞｰｼﾞｮﾝを削除
    '　　　：2004/10/19 (Tue) 14:59:56 S.Deguchi    CommonInfoに変数追加でその対応
    '　　　：2005/01/08 (Sat) 08:38:47 H.Wajima     次に起動する機能IDの判定を追加
    '　　　：2005/01/08 (Sat) 13:03:34 H.Wajima     ﾛｯﾄ処理順変更の例外処理が不要になったみたいなので削除
    '　　　：2005/01/31 (Mon) 16:03:48 H.Wajima     作業終了→特殊流動起動時に、自動起動以外はｷｬﾘｱIDを引き継がないよう判定を追加
    '　　　：2005/02/15 (Tue) 10:26:53 N.Kojima　   ﾛｯﾄ一覧(EN0200)、装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧(EN00J0)からも情報を引き継ぐように改善(改善№512)
    '　　　：2005/06/06 (Mon) 10:12:27 N.Kojima     Loader/Unloader対応(不具合№829)
    '　　　：2005/08/12 (Fri) 15:04:57 N.Kojima     投入予定ﾛｯﾄ一覧からの引継ぎ処理を追加。ｺﾒﾝﾄの削除(不具合№2946)
    '　　　：2005/09/20 (Tue) 15:39:47 N.Kasai      子画面ON ERR終了対応追加
    '　　　：2005/10/31 (Mon) 09:57:00 S.Deguchi    不具合№3219の対応で,起動区分,引継処理を修正
    '　　　：2018/09/25 (Tue) 19:36:07 Y.Yoneyama   防湿ALD対応
    Public Function publngEnd_Proc(ByVal lstrMenuKey As String, _
                                   ByRef ltypCommonInfo As CommonInfo, _
                                   Optional ByVal lstrNextMenuKey As String = vbNullString) As Integer
                                   
        Dim lstrTitle                       As String       'ﾀｲﾄﾙ
        Dim llngCarrTakeOver                As Integer      '引継ぎﾌﾗｸﾞ
        Dim lstrFormName                    As String       'ﾌｫｰﾑ名
        Dim lfrmForm                        As Form         'ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄ
        
        '@関数の戻り値にｴﾗｰ定数を設定する
        publngEnd_Proc = CPlngErrorStatusCD
        
        '@ｷｬﾘｱ情報引継ぎ構造体の初期化
        '@Else処理で都度初期化をしなくて良いように、最初に初期化しておく
        With ltypCommonInfo
            .strCarrierId = vbNullString            'ｷｬﾘｱID
            .strLotID = vbNullString                'ﾛｯﾄID
            .strOpID = vbNullString                 '大工程
            .strStepID = vbNullString               '小工程
            .strWpID = vbNullString                 '装置ID
            .strWpName = vbNullString               '装置ID名称
            .strDivision = vbNullString             '起動区分
            .strToCarrierId = vbNullString          'ｱﾝﾛｰﾀﾞｷｬﾘｱID
            .strAltPointer = vbNullString           '代替番号
            .strSPSelectFlag = vbNullString         '特殊流動
            .strNowST = vbNullString                'ﾛｯﾄ状態
            .strWpTypeFlag = vbNullString           'WPﾀｲﾌﾟﾌﾗｸﾞ
            .strLoaderUnloaderFlag = vbNullString   'L/Uﾌﾗｸﾞ
        End With
        
        '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
        Call pubMenuItemCorrelation_Set(lstrMenuKey, _
                                        lstrTitle, _
                                        llngCarrTakeOver, _
                                        lstrFormName)
        '@機能毎の個別の処理を行う
        Select Case lstrMenuKey
            '@作業終了の場合
            Case CPstrKeyEN0060
                '@引数で渡されたﾒﾆｭｰｷｰに一致するﾌｫｰﾑを終了
                lfrmForm = Application.OpenForms(lstrFormName)
                
                If lfrmForm IsNot Nothing Then
                    '@次起動機能IDの判定
                    Select Case lstrNextMenuKey
                        '@EN00Y0(特殊流動)の場合
                        Case CPstrKeyEN00Y0
                            '@特殊流動ﾌﾗｸﾞの判定
                            If pblnfrmxxEN0060SPStartFlag = True Then
                                Dim lfrmxxEN0060 As frmxxEN0060 = CType(lfrmForm, frmxxEN0060)
                            '@作業終了から特殊流動が自動起動された場合
                            '@引き継ぐｷｬﾘｱID/特殊流動状態を設定
                                '@ｷｬﾘｱ情報引継ぎ構造体へ格納
                                With ltypCommonInfo
                                    .strCarrierId = lfrmxxEN0060.txtCarrier.Text    'ｷｬﾘｱID
                                    .strLotID = vbNullString                        'ﾛｯﾄID
                                    .strOpID = vbNullString                         '大工程
                                    .strStepID = vbNullString                       '小工程
                                    .strWpID = vbNullString                         '装置ID
                                    .strWpName = vbNullString                       '装置ID名称
                                    .strDivision = vbNullString                     '起動区分
                                    .strToCarrierId = vbNullString                  'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                                    .strAltPointer = vbNullString                   '代替番号
                                    '@特殊流動
                                    If lfrmxxEN0060.optLotNextSend2.Checked = True Then     'ﾘﾜｰｸ
                                        .strSPSelectFlag = CMstrRouteFlag0
                                    End If
                                    If lfrmxxEN0060.optLotNextSend3.Checked = True Then     '追加流動
                                        .strSPSelectFlag = CMstrRouteFlag1
                                    End If
                                End With
                            End If
                    End Select
                    
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
                    Call lfrmForm.Close()
                End If
            
            '@EN0150(装置別ﾛｯﾄ一覧)の場合
            Case CPstrKeyEN0150
            
                '@基板組立でｶﾗﾑの並び順を設定
                If pstrSBID = CPstrSBID1A0 Then
                    '@基板
                    mlngvsfAreaEqColNowSt = CPlngvsfAreaEqCol_1A0_NowSt            'ﾛｯﾄ状態
                    mlngvsfAreaEqColLotID = CPlngvsfAreaEqCol_1A0_LotID            'ﾛｯﾄID
                    mlngvsfAreaEqColOpID = CPlngvsfAreaEqCol_1A0_OpID              '大工程
                    mlngvsfAreaEqColStepID = CPlngvsfAreaEqCol_1A0_StepID          '小工程
                    mlngvsfAreaEqColLCarrierID = CPlngvsfAreaEqCol_1A0_LCarrierID  'ﾛｰﾀﾞｷｬﾘｱID
                    mlngvsfAreaEqColUCarrierID = CPlngvsfAreaEqCol_1A0_UCarrierID  'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                    mlngvsfAreaEqColAltNumber = CPlngvsfAreaEqCol_1A0_AltNumber    '代替番号
                Else
                    '@組立
                    mlngvsfAreaEqColNowSt = CPlngvsfAreaEqCol_2A0_NowSt            'ﾛｯﾄ状態
                    mlngvsfAreaEqColLotID = CPlngvsfAreaEqCol_2A0_LotID            'ﾛｯﾄID
                    mlngvsfAreaEqColOpID = CPlngvsfAreaEqCol_2A0_OpID              '大工程
                    mlngvsfAreaEqColStepID = CPlngvsfAreaEqCol_2A0_StepID          '小工程
                    mlngvsfAreaEqColLCarrierID = CPlngvsfAreaEqCol_2A0_LCarrierID  'ﾛｰﾀﾞｷｬﾘｱID
                    mlngvsfAreaEqColUCarrierID = CPlngvsfAreaEqCol_2A0_UCarrierID  'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                    mlngvsfAreaEqColAltNumber = CPlngvsfAreaEqCol_2A0_AltNumber    '代替番号
                End If
            
                '@引数で渡されたﾒﾆｭｰｷｰに一致するﾌｫｰﾑを終了
                lfrmForm = Application.OpenForms(lstrFormName)
                If lfrmForm IsNot Nothing Then
                    Dim lfrmxxEN0150 As frmxxEN0150 = CType(lfrmForm, frmxxEN0150)
                
                    '@引き継ぐｷｬﾘｱIDを設定
                    '@有効なﾚｺｰﾄﾞが選択されていたらｷｬﾘｱIDを格納
                    '@または、次にﾛｯﾄ処理順変更を起動する場合(ｷｬﾘｱIDではなく、装置名を引き継ぐ)
                
                    If lfrmxxEN0150.vsfAreaEquipment.Row > 0 Or lstrNextMenuKey = CPstrKeyEN0260 Then
                    '@ｶﾚﾝﾄ行のｷｬﾘｱIDを格納
                    '@ｷｬﾘｱ情報引継ぎ構造体へ格納
                        With ltypCommonInfo
                            '@ｷｬﾘｱID
                            .strCarrierId = lfrmxxEN0150.vsfAreaEquipment.GetData( _
                                                                            lfrmxxEN0150.vsfAreaEquipment.Row, _
                                                                            mlngvsfAreaEqColLCarrierID)
                                                                       
                            '@ﾛｯﾄID
                            .strLotID = lfrmxxEN0150.vsfAreaEquipment.GetData( _
                                                                        lfrmxxEN0150.vsfAreaEquipment.Row, _
                                                                        mlngvsfAreaEqColLotID)
                                                                   
                            '@大工程
                            .strOpID = lfrmxxEN0150.vsfAreaEquipment.GetData( _
                                                                        lfrmxxEN0150.vsfAreaEquipment.Row, _
                                                                        mlngvsfAreaEqColOpID)
                                                                  
                            '@小工程
                            .strStepID = lfrmxxEN0150.vsfAreaEquipment.GetData( _
                                                                        lfrmxxEN0150.vsfAreaEquipment.Row, _
                                                                        mlngvsfAreaEqColStepID)
                                                                    
                            '@装置ID
                            lfrmxxEN0150.cmbWpID.ValueCol = 1
                            .strWpID = lfrmxxEN0150.cmbWpID.Value
                        
                            '@装置ID名称
                            lfrmxxEN0150.cmbWpID.ValueCol = 0
                            .strWpName = lfrmxxEN0150.cmbWpID.Value
                        
                            '@起動区分
                            .strDivision = vbNullString
                        
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱID
                            .strToCarrierId = lfrmxxEN0150.vsfAreaEquipment.GetData( _
                                                                                lfrmxxEN0150.vsfAreaEquipment.Row, _
                                                                                mlngvsfAreaEqColUCarrierID)
                        
                            '@代替番号
                            .strAltPointer = lfrmxxEN0150.vsfAreaEquipment.GetData( _
                                                                            lfrmxxEN0150.vsfAreaEquipment.Row, _
                                                                            mlngvsfAreaEqColAltNumber)
                        
                            '@特殊流動
                            .strSPSelectFlag = vbNullString
                        
                            '@ﾛｯﾄ状態
                            .strNowST = lfrmxxEN0150.vsfAreaEquipment.GetData( _
                                                                        lfrmxxEN0150.vsfAreaEquipment.Row, _
                                                                        mlngvsfAreaEqColNowSt)
                        
                            '@EQﾀｲﾌﾟ
                            lfrmxxEN0150.cmbWpID.ValueCol = 2
                            .strEqType = lfrmxxEN0150.cmbWpID.Value
                        End With
                    End If
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
                    Call lfrmForm.Close()
                
                    '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの開放
                    lfrmForm = Nothing
                End If
                
                '@起動区分の設定
                If lstrNextMenuKey = vbNullString Then
                '@次機能名が取得できない場合には,起動区分のﾌﾗｸﾞを初期化
                    pblnfrmxxCM00P0Kbn = False
                    pblnfrmxxEN00J0Kbn = False
                    pblnfrmxxEN0150Kbn = False
    '@↓2018/08/09 (Thu) 17:53:24 Y.Yoneyama **************************************************
                    pblnfrmxxEN0151Kbn = False
    '@↑2018/08/09 (Thu) 17:53:24 Y.Yoneyama **************************************************
                    pblnfrmxxEN0200Kbn = False
                Else
                    pblnfrmxxCM00P0Kbn = False
                    pblnfrmxxEN00J0Kbn = False
                    pblnfrmxxEN0150Kbn = True
    '@↓2018/08/09 (Thu) 17:53:38 Y.Yoneyama **************************************************
                    pblnfrmxxEN0151Kbn = False
    '@↑2018/08/09 (Thu) 17:53:38 Y.Yoneyama **************************************************
                    pblnfrmxxEN0200Kbn = False
                End If                
                
    '@↓2018/09/14 (Fri) 16:21:17 Y.Yoneyama **************************************************
            '@EN0150(装置別ﾛｯﾄ一覧)の場合
            Case CPstrKeyEN0151
                
                '@引数で渡されたﾒﾆｭｰｷｰに一致するﾌｫｰﾑを終了
                lfrmForm = Application.OpenForms(lstrFormName)
                If lfrmForm IsNot Nothing Then
                    Dim lfrmxxEN0151 As frmxxEN0151 = CType(lfrmForm, frmxxEN0151)
                            
                    If lfrmxxEN0151.vsfAreaEquipment.Row > 0 Then
                        With ltypCommonInfo
                            .strCarrierId = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColCarrierID)
                            .strLotID = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColLotID)
                            .strFlowClass = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColFlowClass)
                            .strNowST = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColNowSt)
                            .strACarrierId = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColACarrierID)
                            .strAldBatchId = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColALDBatchID)
                            .strTapeBatchId = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColTapeBatchID)
                            .strOvenBatchId = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColOvenBatchID)
                            .strOpID = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColOpID)
                            .strStepID = lfrmxxEN0151.vsfAreaEquipment.GetData(lfrmxxEN0151.vsfAreaEquipment.Row, CMlngvsfAreaEqColStepID)
                            .strWpID = lfrmxxEN0151.cmbWpID.Value
                            .strSPSelectFlag = vbNullString
                            .strToCarrierId = vbNullString
                            .strDivision = vbNullString
                        End With
                    End If
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
                    Call lfrmForm.Close()
                
                    '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの開放
                    lfrmForm = Nothing
                End If
                '@起動区分の設定
                If lstrNextMenuKey = vbNullString Then
                '@次機能名が取得できない場合には,起動区分のﾌﾗｸﾞを初期化
                    pblnfrmxxCM00P0Kbn = False
                    pblnfrmxxEN00J0Kbn = False
                    pblnfrmxxEN0150Kbn = False
                    pblnfrmxxEN0151Kbn = False
                    pblnfrmxxEN0200Kbn = False
                Else
                    pblnfrmxxCM00P0Kbn = False
                    pblnfrmxxEN00J0Kbn = False
                    pblnfrmxxEN0150Kbn = False
                    pblnfrmxxEN0151Kbn = True
                    pblnfrmxxEN0200Kbn = False
                End If
                
    '@↑2018/09/14 (Fri) 16:21:17 Y.Yoneyama **************************************************
                
            '@EN00J0(装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧)の場合
            Case CPstrKeyEN00J0
                '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの取得
                lfrmForm = Application.OpenForms(lstrFormName)
                If lfrmForm IsNot Nothing Then
                    Dim lfrmxxEN00J0 As frmxxEN00J0 = CType(lfrmForm, frmxxEN00J0)
                
                    '@ｷｬﾘｱ情報の引き継ぎ設定
                    If lfrmxxEN00J0.vsfMcAllLotlist.Row > 0 Then
                        '@ｷｬﾘｱID
                        ltypCommonInfo.strCarrierId = lfrmxxEN00J0.vsfMcAllLotlist.GetData( _
                                                                                    lfrmxxEN00J0.vsfMcAllLotlist.Row, _
                                                                                    CMlngColCarrierID)

                        '@ﾛｯﾄID
                        ltypCommonInfo.strLotID = lfrmxxEN00J0.vsfMcAllLotlist.GetData( _
                                                                                lfrmxxEN00J0.vsfMcAllLotlist.Row, _
                                                                                CMlngColLotID)
                    
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱID
                        ltypCommonInfo.strToCarrierId = lfrmxxEN00J0.vsfMcAllLotlist.GetData( _
                                                                                      lfrmxxEN00J0.vsfMcAllLotlist.Row, _
                                                                                      CMlngColUnLoaderCarrierID)
                                                                                  
                        '@代替番号
                        ltypCommonInfo.strAltPointer = lfrmxxEN00J0.vsfMcAllLotlist.GetData( _
                                                                                     lfrmxxEN00J0.vsfMcAllLotlist.Row, _
                                                                                     CMlngColAltNumber)
                    Else
                        '@各変数にNULLを格納
                        ltypCommonInfo.strCarrierId = vbNullString                  'ｷｬﾘｱID
                        ltypCommonInfo.strLotID = vbNullString                      'ﾛｯﾄID
                        ltypCommonInfo.strToCarrierId = vbNullString                'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                        ltypCommonInfo.strAltPointer = vbNullString                 '代替番号
                    End If
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
                    Call lfrmForm.Close()
                    '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの開放
                    lfrmForm = Nothing
                End If
                '@起動区分の設定
                If lstrNextMenuKey = vbNullString Then
                '@次機能名が取得できない場合には,起動区分のﾌﾗｸﾞを初期化
                    pblnfrmxxCM00P0Kbn = False
                    pblnfrmxxEN00J0Kbn = False
                    pblnfrmxxEN0150Kbn = False
    '@↓2018/08/09 (Thu) 17:54:01 Y.Yoneyama **************************************************
                    pblnfrmxxEN0151Kbn = False
    '@↑2018/08/09 (Thu) 17:54:01 Y.Yoneyama **************************************************
                    pblnfrmxxEN0200Kbn = False
                Else
                    pblnfrmxxCM00P0Kbn = False
                    pblnfrmxxEN00J0Kbn = True
                    pblnfrmxxEN0150Kbn = False
    '@↓2018/08/09 (Thu) 17:54:12 Y.Yoneyama **************************************************
                    pblnfrmxxEN0151Kbn = False
    '@↑2018/08/09 (Thu) 17:54:12 Y.Yoneyama **************************************************
                    pblnfrmxxEN0200Kbn = False
                End If
            
            '@EN0200(工程別ﾛｯﾄ一覧)の場合
            Case CPstrKeyEN0200
                '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの取得
                lfrmForm = Application.OpenForms(lstrFormName)
                If lfrmForm IsNot Nothing Then
                    Dim lfrmxxEN0200 As frmxxEN0200 = CType(lfrmForm, frmxxEN0200)
                
                    '@ｷｬﾘｱ情報の引き継ぎ設定
                    If lfrmxxEN0200.vsfStepLotList.Row > 0 Then
                        '@ｷｬﾘｱID
                        ltypCommonInfo.strCarrierId = lfrmxxEN0200.vsfStepLotList.GetData( _
                                                                                   lfrmxxEN0200.vsfStepLotList.Row, _
                                                                                   CMlngvsfStepLLColCarrierID)
                    
                        '@ﾛｯﾄID
                        ltypCommonInfo.strLotID = lfrmxxEN0200.vsfStepLotList.GetData( _
                                                                               lfrmxxEN0200.vsfStepLotList.Row, _
                                                                               CMlngvsfStepLLColLotID)
                    
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱID
                        ltypCommonInfo.strToCarrierId = lfrmxxEN0200.vsfStepLotList.GetData( _
                                                                                     lfrmxxEN0200.vsfStepLotList.Row, _
                                                                                     CMlngvsfStepLLColUnLoaderCarrierID)
                    
                        '@代替番号
                        ltypCommonInfo.strAltPointer = lfrmxxEN0200.vsfStepLotList.GetData( _
                                                                                    lfrmxxEN0200.vsfStepLotList.Row, _
                                                                                    CMlngvsfStepLLColAltNumber)
                    Else
                        '@各変数にNULLを格納
                        ltypCommonInfo.strCarrierId = vbNullString                  'ｷｬﾘｱID
                        ltypCommonInfo.strLotID = vbNullString                      'ﾛｯﾄID
                        ltypCommonInfo.strToCarrierId = vbNullString                'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                        ltypCommonInfo.strAltPointer = vbNullString                 '代替番号
                    End If
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
                    Call lfrmForm.Close()
                    '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの開放
                    lfrmForm = Nothing
                End If
                '@起動区分の設定
                If lstrNextMenuKey = vbNullString Then
                '@次機能名が取得できない場合には,起動区分のﾌﾗｸﾞを初期化
                    pblnfrmxxCM00P0Kbn = False
                    pblnfrmxxEN00J0Kbn = False
                    pblnfrmxxEN0150Kbn = False
    '@↓2018/08/09 (Thu) 17:54:29 Y.Yoneyama **************************************************
                    pblnfrmxxEN0151Kbn = False
    '@↑2018/08/09 (Thu) 17:54:29 Y.Yoneyama **************************************************
                    pblnfrmxxEN0200Kbn = False
                Else
                    pblnfrmxxCM00P0Kbn = False
                    pblnfrmxxEN00J0Kbn = False
                    pblnfrmxxEN0150Kbn = False
    '@↓2018/08/09 (Thu) 17:54:39 Y.Yoneyama **************************************************
                    pblnfrmxxEN0151Kbn = False
    '@↑2018/08/09 (Thu) 17:54:39 Y.Yoneyama **************************************************
                    pblnfrmxxEN0200Kbn = True
                End If
                
            '@EN00P0(投入予定ﾛｯﾄ一覧)の場合
            Case CPstrKeyEN00P0
                '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの取得
                lfrmForm = Application.OpenForms(lstrFormName)
                If lfrmForm IsNot Nothing
                    Dim lfrmxxCM0090 As frmxxCM0090 = CType(lfrmForm, frmxxCM0090)
                
                    '@または、次に投入予定ﾛｯﾄ変更/削除を起動する場合
                    If lfrmxxCM0090.vsfResvLotList.Row > 0 Then

                        '@ｷｬﾘｱ情報の引き継ぎ設定
                        If lfrmxxCM0090.vsfResvLotList.Row > 0 Then
                            '@ﾛｯﾄID
                            ltypCommonInfo.strLotID = lfrmxxCM0090.vsfResvLotList.GetData( _
                                                                                   lfrmxxCM0090.vsfResvLotList.Row, _
                                                                                   CMvsfResvLotListColLotID)
                        Else
                            '@各変数にNULLを格納
                            ltypCommonInfo.strLotID = vbNullString                  'ﾛｯﾄID
                        End If
                    End If
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
                    Call lfrmForm.Close()
                
                    '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの開放
                    lfrmForm = Nothing
                End If
                '@起動区分の設定
                pblnfrmxxCM00P0Kbn = True
                pblnfrmxxEN00J0Kbn = False
                pblnfrmxxEN0150Kbn = False
    '@↓2018/08/09 (Thu) 17:54:54 Y.Yoneyama **************************************************
                pblnfrmxxEN0151Kbn = False
    '@↑2018/08/09 (Thu) 17:54:54 Y.Yoneyama **************************************************
                pblnfrmxxEN0200Kbn = False
            
            '@その他処理
            Case Else
                '@本来子画面はEnd_Procを走行していないがON ERR処理で子画面が強制終了する場合がある。
                '@しかし、FUNCTIONﾃｰﾌﾞﾙにﾌｫｰﾑ名が登録されていない為、ﾌｫｰﾑを終了することが出来ない。
                '@文字結合にてﾌｫｰﾑ名を設定する。
                '@今後、全てのﾌｫｰﾑに対してFUNCTIONに登録するかは要相談
                If lstrFormName = vbNullString Then
                    lstrFormName = "frmxx" & lstrMenuKey
                End If
                
                '@起動区分の設定
                pblnfrmxxCM00P0Kbn = False
                pblnfrmxxEN00J0Kbn = False
                pblnfrmxxEN0150Kbn = False
    '@↓2018/08/09 (Thu) 17:55:07 Y.Yoneyama **************************************************
                pblnfrmxxEN0151Kbn = False
    '@↑2018/08/09 (Thu) 17:55:07 Y.Yoneyama **************************************************
                pblnfrmxxEN0200Kbn = False
                
                '@通常の機能の場合(上記以外)
                '@引数で渡されたﾒﾆｭｰｷｰに一致するﾌｫｰﾑを終了
                lfrmForm = Application.OpenForms(lstrFormName)
                If lfrmForm IsNot Nothing Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
                    lfrmForm.Close()
                End If
        End Select
        
        '@当関数の戻り値に正常終了定数を設定する
        publngEnd_Proc = CPlngNormalStatusCD
        
    End Function

    '関数名：pubblnFuncInfo_Set
    '機　能：機能情報取得処理
    '引　数：なし
    '戻り値：Ture:正常終了、False:異常終了
    '作成日：2004/06/08 (Tue) 09:59:26 N.Kasai
    '更新日：2004/07/30 (Fri) 11:59:34 H.Wajima
    '備　考：
    Public Function pubblnFuncInfo_Set() As Boolean
        
        Dim lblnAns         As Boolean  '汎用変数
        Dim lstrFormName    As String   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName   As String   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        
        '@戻り値にFalseを設定
        pubblnFuncInfo_Set = False
        
        '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの表題設定
        pstrMessageName = "機能バージョン設定処理"
        
        '@ﾚｽﾎﾟﾝｽ取得開始
        lstrFormName = CPstrFrmMenu
        lstrEventName = "pubstrFuncVer_Set"
        Call pubResponseStart(lstrFormName, lstrEventName)
        
        '@関数情報構造体の配列を解放する
        ptypFuncInfo.typFunctionList = Nothing
        
        '@機能情報取得
        lblnAns = pubblnFuncinfo_Sel(CMstrutilfuncinfoVer, ptypFuncInfo)
        
        '@戻り値の判定
        If lblnAns = True Then
            '@正常終了の場合
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@戻り値にTrueを設定
            pubblnFuncInfo_Set = True
        Else
            '@異常終了の場合
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)
        End If
        
    End Function

    '関数名：pubblnFuncVer_Chk
    '機　能：機能ﾊﾞｰｼﾞｮﾝ判定処理
    '引　数：lstrFunctionID ：機能ID
    '　　　：lstrClientVer  ：ｸﾗｲｱﾝﾄの機能ﾊﾞｰｼﾞｮﾝ
    '戻り値：Ture:ﾊﾞｰｼﾞｮﾝ一致、False:ﾊﾞｰｼﾞｮﾝ不一致
    '作成日：2004/07/21 (Wed) 10:59:07 H.Wajima
    '更新日：2004/09/29 (Wed) 21:03:24 H.Wajima
    '備　考：ｻｰﾊﾞｰとｸﾗｲｱﾝﾄの機能ﾊﾞｰｼﾞｮﾝを判定しﾒｯｾｰｼﾞﾎﾞｯｸｽを表示する。
    '　　　：2004/09/02 (Thu) 13:33:24 H.Wajima     ﾒｯｾｰｼﾞに機能名が入るように変更。／pstrMessageNameに機能名を設定。
    '　　　：2004/09/29 (Wed) 21:03:24 H.Wajima     機能ﾊﾞｰｼﾞｮﾝﾁｪｯｸMsg対応
    Public Function pubblnFuncVer_Chk(ByVal lstrFunctionID As String, _
                                      ByVal lstrClientVer As String) As Boolean
        
        Dim lblnRet         As Boolean  '戻り値
        
        '@関数の戻り値にFalseを設定
        pubblnFuncVer_Chk = False
        
        '@機能ﾊﾞｰｼﾞｮﾝﾁｪｯｸ
        lblnRet = pubblnChkFunc_Sel(CMstrutilchkfunc_, lstrFunctionID, lstrClientVer)
        
        '@戻り値の判定
        If lblnRet = True Then
            '@機能ﾊﾞｰｼﾞｮﾝが一致する場合
            '@関数の戻り値にTrueを設定
            pubblnFuncVer_Chk = True
        
        End If
        
    End Function

    '関数名：pubMenuSelect_Proc
    '機　能：ﾒﾆｭｰから機能選択処理
    '引　数：strMenuKey：ﾒﾆｭｰｷｰ(機能ID)
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 13:02:17 H.Wajima
    '更新日：2004/07/27 (Tue) 13:02:17
    '備　考：各機能をﾒﾆｭｰから選択した状態で起動します
    Public Sub pubMenuSelect_Proc(ByVal strMenuKey As String)
        
        Dim lctlControl         As Control          'コントロール
        Dim llngTabNo           As Integer          'タブ番号
        Dim llngCnt             As Integer          '汎用カウンタ
        Dim lfrmForm            As frmxxMN0000      'ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄ
        Dim lcmdUp              As Button           '▲ﾎﾞﾀﾝｵﾌﾞｼﾞｪｸﾄ
        Dim lcmdDown            As Button           '▼ﾎﾞﾀﾝｵﾌﾞｼﾞｪｸﾄ
        Dim lvsfGrid            As C1FlexGrid       'NSYS
        
        '@ﾒﾆｭｰ画面のﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄを探す
        '@(機能を単体起動するときのために、frmxxMN0000を直接指定できない為)
        lfrmForm = Application.OpenForms(CPstrFormMN0000)
        
        '@フォーム上のコントロールの検索
        For Each lctlControl In GetAllControls(lfrmForm)
            
            If TypeOf lctlControl Is C1FlexGrid Then
                lvsfGrid = CType(lctlcontrol, C1FlexGrid)
                
                '@コントロールがVSFlexGridの場合
                Select Case lctlControl.Name
                    
                    '@流動系のグリッドの場合
                    Case lfrmForm.vsfFlow.Name
                        '@流動系のタブ番号を使用する
                        llngTabNo = CPlngMenuTabFlow
                        '@流動系ﾀﾌﾞの▲ﾎﾞﾀﾝ
                        lcmdUp = lfrmForm.cmdFlowUp
                        '@流動系ﾀﾌﾞの▼ﾎﾞﾀﾝ
                        lcmdUp = lfrmForm.cmdFlowDown
                        
                    '@ツール系グリッドの場合
                    Case lfrmForm.vsfTool.Name
                        '@ツール系のタブ番号を使用する
                        llngTabNo = CPlngMenuTabTool
                        '@ﾂｰﾙ系ﾀﾌﾞの▲ﾎﾞﾀﾝ
                        lcmdUp = lfrmForm.cmdToolUp
                        '@ﾂｰﾙ系ﾀﾌﾞの▼ﾎﾞﾀﾝ
                        lcmdUp = lfrmForm.cmdToolDown
                        
                    '@お気に入りグリッドの場合
                    Case lfrmForm.vsfFavorites.Name
                        '@お気に入りのタブ番号を使用する
                        llngTabNo = CPlngMenuTabFavorites
                        '@お気に入りﾀﾌﾞの▲ﾎﾞﾀﾝ
                        lcmdUp = lfrmForm.cmdFavoritesUp
                        '@お気に入りﾀﾌﾞの▼ﾎﾞﾀﾝ
                        lcmdUp = lfrmForm.cmdFavoritesDown
                End Select
                            
                '@ｸﾞﾘｯﾄﾞ行のﾙｰﾌﾟ
                For llngCnt = 0 To lvsfGrid.Rows.Count - 1
                    If lvsfGrid.GetData(llngCnt, CPlngMenuKeyCol) = strMenuKey Then
                        '@ﾀﾌﾞを有効にする
                        lfrmForm.tabMenu.Visible = True
                        '@ﾀﾌﾞを選択する
                        lfrmForm.tabMenu.SelectedIndex = llngTabNo
                        '@ｸﾞﾘｯﾄﾞの行を指定
                        lvsfGrid.Row = llngCnt
                        '@選択行を表示する
                        Call pubVsfBeforeSort(lctlControl, CPlngMenuTitleCol)
                        Call pubVsfAfterSort(lctlControl, CPlngMenuTitleCol, lcmdUp, lcmdDown, False, False)
                        '@ﾒﾆｭｰのｺﾏﾝﾄﾞﾎﾞﾀﾝ押下処理を実行する
                        Call lfrmForm.prvGridMenuButtonPush_Proc()
                        '@ｵﾌﾞｼﾞｪｸﾄを開放する
                        lfrmForm = Nothing
                        lcmdUp = Nothing
                        lcmdUp = Nothing
                        Exit Sub
                    End If
                Next llngCnt
                
            End If
        Next
        
        '@ｵﾌﾞｼﾞｪｸﾄを開放する
        lfrmForm = Nothing
        lcmdUp = Nothing
        lcmdUp = Nothing
        
    End Sub

    '関数名：publngExeFile_Exec
    '機　能：EXEﾌｧｲﾙ起動処理
    '引　数：lstrMenuKey    ：機能ID
    '戻り値：正常終了：CPlngNormalStatusCD、異常終了：CPlngErrorStatusCD
    '作成日：2004/08/18 (Wed) 22:34:29 H.Wajima
    '更新日：2008/07/01 (Tue) 10:34:27 N.Kojima
    '備　考：
    '　　　：2008/07/01 (Tue) 10:34:27 N.Kojima     ｿｰｽ整備(処理は修正していません)。(案件№03004)
    Public Function publngExeFile_Exec(ByVal lstrMenuKey As String) As Integer
        
        Dim lstrTitle               As String       'ﾒﾆｭｰﾀｲﾄﾙ
        Dim llngCarrTakeOver        As Integer      '引継ぎﾌﾗｸﾞ
        Dim lstrFormName            As String       'ﾌｫｰﾑ名
        Dim lblnExecuteFlg          As Boolean      '起動済みﾌﾗｸﾞ
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngExitCode            As Integer      '終了ｺｰﾄﾞ
        Dim llngApiReturn           As Integer      '戻り値
        Dim llngTaskID              As Integer      'ﾀｽｸID
        Dim lstrMyPath              As String       '自EXEのﾊﾟｽ
        Dim llnghProcess            As Integer      'ﾌﾟﾛｾｽﾊﾝﾄﾞﾙ
        Dim lblnAgreementFlg        As Boolean      'ﾒﾆｭｰ一致ﾌﾗｸﾞ(True：一致あり、False：一致なし)
        
        '@戻り値を初期化する
        publngExeFile_Exec = CPlngErrorStatusCD

        '@=======================
        '@　機能毎関連情報取得処理
        '@=======================
        Call pubMenuItemCorrelation_Set(lstrMenuKey, lstrTitle, llngCarrTakeOver, lstrFormName)
        
        '@***********************
        '@　起動対象EXEが起動済みか判定する
        '@***********************
        
        '@起動判定ﾌﾗｸﾞの初期化
        lblnExecuteFlg = False
        
        '@ﾌﾟﾛｾｽ退避用配列が初期化されているか
        If Not IsNothing(ptypExeInfo) Then
            '@初期化されている場合
            
            For llngCnt = 0 To ptypExeInfo.Count - 1
                
                '@同じﾒﾆｭｰ(EXE)が起動されているか(退避変数のﾒﾆｭｰｷｰと引数のﾒﾆｭｰｷｰが同じか)
                If ptypExeInfo(llngCnt).strMenuKey = lstrMenuKey Then
                    '@同じ場合
                    
                    '@=======================
                    '@　起動ﾌﾟﾛｾｽの存在判定処理
                    '@=======================
                    llngApiReturn = GetExitCodeProcess(ptypExeInfo(llngCnt).lnghProcess, llngExitCode)
                    
                    '@起動ﾌﾟﾛｾｽがｱｸﾃｨﾌﾞか
                    If llngExitCode = STILL_ACTIVE Then
                        '@起動ﾌﾟﾛｾｽがｱｸﾃｨﾌﾞな場合
                        
                        '@起動EXEをｱｸﾃｨﾌﾞにする
                        AppActivate(ptypExeInfo(llngCnt).lngTaskID)
                        
                        '@起動済みﾌﾗｸﾞに"True：起動済"をｾｯﾄする
                        lblnExecuteFlg = True
                    Else
                        '@起動ﾌﾟﾛｾｽが非ｱｸﾃｨﾌﾞな場合
                    
                        '@起動済みﾌﾗｸﾞに"False：未起動"をｾｯﾄする
                        lblnExecuteFlg = False
                        Exit For
                    End If
                End If
            Next llngCnt
        End If
        
        '@起動済みﾌﾗｸﾞが"False：未起動"か
        If lblnExecuteFlg = False Then
            '@EXEが未起動の場合
            
            '@自EXEが起動したﾊﾟｽを取得
            lstrMyPath = My.Application.Info.DirectoryPath
            
            '@ﾙｰﾄﾃﾞｨﾚｸﾄﾘｰかの判断
            If Right$(lstrMyPath, 1&) <> CMstrFilePathBackSlash Then
                lstrMyPath = lstrMyPath & CMstrFilePathBackSlash
            End If
            
            '@★ ｷｬﾘｱ引継ぎﾌﾗｸﾞにより処理分岐 ★
            Select Case llngCarrTakeOver
                
                '@〓 5：EXEﾂｰﾙにｺﾏﾝﾄﾞﾗｲﾝ引数を引き継がない 〓
                Case CPlngMenuCarrTakeOver5
                
                   '@ｺﾏﾝﾄﾞﾗｲﾝ引数なしでEXEを起動する
                   llngTaskID = Shell(lstrMyPath & lstrFormName, vbNormalFocus)
                
                
                '@〓 6：EXEﾂｰﾙにｺﾏﾝﾄﾞﾗｲﾝ引数を引き継ぐ 〓
                Case CPlngMenuCarrTakeOver6

                   '@ｺﾏﾝﾄﾞﾗｲﾝ引数付きでEXEを起動する
                   llngTaskID = Shell(lstrMyPath & lstrFormName & CMstrFilePathSpace & Command$, vbNormalFocus)
                
                
                '@〓 その他 〓
                Case Else

                   '@ｺﾏﾝﾄﾞﾗｲﾝ引数なしでEXEを起動する
                   llngTaskID = Shell(lstrMyPath & lstrFormName, vbNormalFocus)
            
            End Select
            
            '@=======================
            '@　起動EXEのﾌﾟﾛｾｽﾊﾝﾄﾞﾙ取得処理
            '@=======================
            llnghProcess = OpenProcess(PROCESS_QUERY_INFORMATION, 1, llngTaskID)
            
            '@EXE情報退避用配列が初期化されているかどうかを判定
            If IsNothing(ptypExeInfo) Then
                '@初期化されていない場合
                'NSYS Listを初期化
                ptypExeInfo = New List(Of ExeInfo)

                Dim tmpExeInfo As ExeInfo

                '@配列領域を確保
                ptypExeInfoCnt = 1
                
                '@配列にﾒﾆｭｰｷｰ、ﾀｽｸID、ﾌﾟﾛｾｽﾊﾝﾄﾞﾙを格納する
                With tmpExeInfo
                    .strMenuKey = lstrMenuKey       '機能ID
                    .lngTaskID = llngTaskID         'ﾀｽｸID
                    .lnghProcess = llnghProcess     'ﾌﾟﾛｾｽﾊﾝﾄﾞﾙ
                End With

                ptypExeInfo.Add(tmpExeInfo)
            Else
                '@初期化されている場合
                
                '@ﾒﾆｭｰ一致ﾌﾗｸﾞの初期化
                lblnAgreementFlg = False
                
                For llngCnt = 0 To ptypExeInfo.Count - 1
                    
                    '@起動EXE情報格納配列のﾒﾆｭｰｷｰと引数のﾒﾆｭｰｷｰが同じか
                    If ptypExeInfo(llngCnt).strMenuKey = lstrMenuKey Then
                        '@同じ場合
                        
                        '@ﾒﾆｭｰ一致ﾌﾗｸﾞに"True：一致あり"をｾｯﾄ
                        lblnAgreementFlg = True
                        Exit For
                    End If
                Next llngCnt
                
                '@ﾒﾆｭｰ一致ﾌﾗｸﾞが"True：一致あり"か
                If lblnAgreementFlg = True Then
                    '@一致ありの場合
                    Dim tmpExeInfo As ExeInfo = ptypExeInfo(llngCnt)
                    
                    '@ﾀｽｸID、ﾌﾟﾛｾｽﾊﾝﾄﾞﾙを上書きする
                    With tmpExeInfo
                        .lngTaskID = llngTaskID
                        .lnghProcess = llnghProcess
                    End With

                    ptypExeInfo(llngCnt) = tmpExeInfo
                Else
                    '@一致なしの場合
                    
                    '@配列を拡張する
                    Dim tmpExeInfo As ExeInfo
                    
                    '@拡張した配列にﾒﾆｭｰｷｰ、ﾀｽｸID、ﾌﾟﾛｾｽﾊﾝﾄﾞﾙを格納する
                    With tmpExeInfo
                        .strMenuKey = lstrMenuKey
                        .lngTaskID = llngTaskID
                        .lnghProcess = llnghProcess
                    End With

                    ptypExeInfo.Add(tmpExeInfo)
                    ptypExeInfoCnt = ptypExeInfoCnt + 1
                End If
            End If
            
            '@Shellの戻り値の判定
            If llngTaskID <> 0 Then
                
                '@戻り値に"0：正常終了"をｾｯﾄする
                publngExeFile_Exec = CPlngNormalStatusCD
                
            End If
        Else
            '@起動対象EXEが起動済みの場合
            
            '@戻り値に"0：正常終了"をｾｯﾄする
            publngExeFile_Exec = CPlngNormalStatusCD
            
        End If

    End Function

    '関数名：publngWebBrowser_Exec
    '機　能：WEBﾌﾞﾗｳｻﾞ起動処理
    '引　数：lstrMenuKey：機能ID
    '戻り値：正常終了：CPlngNormalStatusCD、異常終了：CPlngErrorStatusCD
    '作成日：2004/08/19 (Thu) 09:16:05 H.Wajima
    '更新日：2023/06/23 (Fri) 16:20:01 T.Oide
    '備　考：
    Public Function publngWebBrowser_Exec(ByVal lstrMenuKey As String) As Integer
        
        Dim lstrTitle               As String = Nothing     'ﾒﾆｭｰﾀｲﾄﾙ
        Dim llngCarrTakeOver        As Integer              '引継ぎﾌﾗｸﾞ
        Dim lstrFormName            As String = Nothing     'ﾌｫｰﾑ名
        Dim lstrOption              As String               'Chrome起動ｵﾌﾟｼｮﾝ
        
        '@機能の関連情報を取得する
        Call pubMenuItemCorrelation_Set(lstrMenuKey, lstrTitle, llngCarrTakeOver, lstrFormName)

        '@WScript Shellｵﾌﾞｼﾞｪｸﾄを生成
        pobjWsh = CreateObject("WScript.Shell")

        '@ｳｨﾝﾄﾞｳ位置ｵﾌﾟｼｮﾝの設定
        lstrOption = " --window-position=" & -My.Settings.FormOffset & ",0"

        '@ｳｨﾝﾄﾞｳｻｲｽﾞｵﾌﾟｼｮﾝの設定(通常)
		lstrOption = lstrOption & " --window-size=" & CPlngAppliWebWidth & "," & CPlngAppliWebHeight

		'ポップアップガイダンスの場合ユーザIDとオプションを追加
		If InStr(lstrFormName, "web_PopUp_Guidance") > 0 Then
			'ポップアップガイダンス専用処理

			'APOコード取得
			Call pubstrGetUserName
			'MsgBox("APOコード：" & pstrApoCode)
			lstrOption = lstrOption & " --disable-popup-blocking"			'ポップアップブロック解除
			lstrFormName = lstrFormName & "?in_user_id=" & pstrApoCode		'ユーザIDの引数追加

		End If

        '@Chrome起動
		pobjWsh.Run("chrome.exe --app=" & lstrFormName & lstrOption)

        '@戻り値に正常終了コードを代入する
        publngWebBrowser_Exec = CPlngNormalStatusCD
        
    End Function

    '関数名：pubErrMsg_Proc
    '機　能：例外ｴﾗｰﾒｯｾｰｼﾞ表示処理
    '引　数：lerrError：ｴﾗｰｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2004/09/13 (Mon) 09:23:41 K.Takano
    '更新日：2004/09/21 (Tue) 15:36:05 K.Takano
    '備　考：
    Public Sub pubErrMsg_Proc(ByRef lobjError As ErrObject)
        
        Dim lstrErrorCode       As String       'ｴﾗｰｺｰﾄﾞ
        Dim lstrMsg             As String       'ｴﾗｰﾒｯｾｰｼﾞ

        '@ｴﾗｰｺｰﾄﾞを16進に変換
        lstrErrorCode = Hex(lobjError.Number)

        '@ｴﾗｰｺｰﾄﾞ判断処理
        Select Case lstrErrorCode

            Case CMstrErrCode80040221
                '@ﾒｯｾｰｼﾞ("<TRM92E>$$システムを起動出来ませんでした。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0092
            Case CMstrErrCode80040222
                '@ﾒｯｾｰｼﾞ("<TRM93E> システムを起動出来ませんでした。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0093
            Case CMstrErrCode80040223
                '@ﾒｯｾｰｼﾞ("<TRM94E> システムを起動出来ませんでした。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0094
            Case CMstrErrCode80040224
                '@ﾒｯｾｰｼﾞ("<TRM95E> システムを起動出来ませんでした。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0095
            Case CMstrErrCode80040225
                '@ﾒｯｾｰｼﾞ("<TRM91E> システムを起動出来ませんでした。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0091
            Case CMstrErrCode8004022A
                '@ﾒｯｾｰｼﾞ("<TRM96E> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0096
            Case CMstrErrCode8004022B
                '@ﾒｯｾｰｼﾞ("<TRM97E> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0097
            Case CMstrErrCode8004022C
                '@ﾒｯｾｰｼﾞ("<TRM98E> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0098
            Case CMstrErrCode8004022D
                '@ﾒｯｾｰｼﾞ("<TRM99E> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0099
            Case CMstrErrCode8004022E
                '@ﾒｯｾｰｼﾞ("<TRM9AE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009A
            Case CMstrErrCode8004022F
                '@ﾒｯｾｰｼﾞ("<TRM9BE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009B
            Case CMstrErrCode80040230
                '@ﾒｯｾｰｼﾞ("<TRM9CE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009C
            Case CMstrErrCode80040231
                '@ﾒｯｾｰｼﾞ("<TRM9DE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009D
            Case CMstrErrCode80040232
                '@ﾒｯｾｰｼﾞ("<TRM9EE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009E
            Case CMstrErrCode80040233
                '@ﾒｯｾｰｼﾞ("<TRM9FE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009F
            Case CMstrErrCode80040234
                '@ﾒｯｾｰｼﾞ("<TRM9GE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009G
            Case CMstrErrCode80040235
                '@ﾒｯｾｰｼﾞ("<TRM9HE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009H
            Case CMstrErrCode80040236
                '@ﾒｯｾｰｼﾞ("<TRM9IE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009I
            Case CMstrErrCode80040237
                '@ﾒｯｾｰｼﾞ("<TRM9JE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009J
            Case CMstrErrCode80040238
                '@ﾒｯｾｰｼﾞ("<TRM9KE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009K
            Case CMstrErrCode80040240
                '@ﾒｯｾｰｼﾞ("<TRM9LE> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr009L
            Case Else
                '@ﾒｯｾｰｼﾞ("<TRM03E> 通信エラーが発生しました。システム担当者に連絡して下さい。")
                lstrMsg = CPstrMsgErr0003

        End Select

        '@表示ﾒｯｾｰｼﾞの生成(Deve起動ではDiscriptionを表示する)
        If pstrTestStatus = CPstrDeveStatus Then
            '@開発起動ではDiscriptionを表示する
            lstrMsg = lstrMsg & CPstrDeveErrMsg
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(lstrMsg, lstrErrorCode, lobjError.Description)
        Else
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(lstrMsg)
        End If
        
        '@ﾒｯｾｰｼﾞ表示
        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, pstrMessageName, True, 16)
        
    End Sub

    '関数名：pubDoEventsBefoer
    '機　能：DoEvents前処理
    '引　数：lobjForm：ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 16:08:02 N.Kojima
    '更新日：2004/10/25 (Mon) 16:08:02
    '備　考：DoEventsにより、通信中に終了ｺﾏﾝﾄﾞで落ちてしまう件の対応(不具合№97)
    Public Sub pubDoEventsBefoer(ByVal lobjForm As Object)

        '@DoEventsﾌﾗｸﾞを立てる
        pblnTrnFlag = True
        '@ﾌｫｰﾑを無効に
        lobjForm.Enabled = False

    End Sub

    '関数名：pubDoEventsAfter
    '機　能：DoEvents後処理
    '引　数：lobjForm：ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 16:08:07 N.Kojima
    '更新日：2004/10/25 (Mon) 16:08:07
    '備　考：DoEventsにより、通信中に終了ｺﾏﾝﾄﾞで落ちてしまう件の対応(不具合№97)
    Public Sub pubDoEventsAfter(ByVal lobjForm As Object)

        '@DoEventsﾌﾗｸﾞを下ろす
        pblnTrnFlag = False
        '@ﾌｫｰﾑを有効に
        lobjForm.Enabled = True

    End Sub

    '関数名：pubblnIsLoaded
    '機　能：ﾌｫｰﾑがLoadされているか判定する
    '引　数：TargetForm：判定するﾌｫｰﾑのｵﾌﾞｼﾞｪｸﾄ
    '戻り値：True:Loadされている、False:Loadされていない
    '作成日：2004/11/29 (Mon) 14:44:52 H.Wajima
    '更新日：2004/11/29 (Mon) 14:44:52
    '備　考：
    Public Function pubblnIsLoaded(ByVal TargetForm As Form) As Boolean

        Dim frmForm As Form     'ﾌｫｰﾑのｵﾌﾞｼﾞｪｸﾄ
        
        '@Formsｺﾚｸｼｮﾝのﾙｰﾌﾟ
        For Each frmForm In Application.OpenForms
            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄの判定
            If frmForm Is TargetForm Then
                '@引数のﾌｫｰﾑに一致するﾌｫｰﾑがあった場合
                '@戻り値にTrueを設定する
                pubblnIsLoaded = True
                '@処理を抜ける
                Exit Function
            End If
        Next frmForm
        
        '@戻り値にFalseを設定する
        pubblnIsLoaded = False
        
    End Function

    '関数名：pubblnCalendar_Init
    '機　能：ｶﾚﾝﾀﾞｰｻｲｽﾞ初期化処理
    '引　数：lcalCalendar：ｶﾚﾝﾀﾞｰｺﾝﾄﾛｰﾙのｵﾌﾞｼﾞｪｸﾄ
    '　　　：llngMode：画面ｻｲｽﾞﾓｰﾄﾞ(0:工程管理ｻｲｽﾞ/1:ﾂｰﾙ系)
    '　　　：lstrDateValue：日付
    '戻り値：True:正常終了、False:異常終了
    '作成日：2005/02/09 (Wed) 09:18:29 H.Wajima
    '更新日：2005/02/09 (Wed) 09:18:29
    '備　考：
    Public Function pubblnCalendar_Init(ByVal lcalCalendar As SECalendarEx.CalendarEx, _
                                        ByVal llngMode As Integer, _
                                        Optional ByVal lstrDateValue As String = CPstrNullDate) As Boolean
        
        '@関数の戻り値にFalseを設定
        pubblnCalendar_Init = False
        
        '@引数で与えられたｶﾚﾝﾀﾞｰｺﾝﾄﾛｰﾙの判定
        If TypeOf lcalCalendar Is SECalendarEx.CalendarEx Then
            '@CalendarEXの場合
            '@ｶﾚﾝﾀﾞｰ表示ﾓｰﾄﾞの判定
            Select Case llngMode
                Case CPlngCalModeFlow
                    '@工程管理画面ｻｲｽﾞの場合
                    With lcalCalendar
                        .CalendarHeight = CPlngClHeight             '高さ
                        .CalendarWidth = CPlngClWidth               '幅
                        With .Font                                  'ﾌｫﾝﾄ(16)
                            lcalCalendar.Font = _
                                New Font(.FontFamily, CPlngClGridFontSize, .Style, _
                                         .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .DayFont                               '日付ﾌｫﾝﾄ(12)
                            lcalCalendar.DayFont = _
                                New Font(.FontFamily, CPlngClFontSize, .Style, _
                                         .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .TitleFont                             'ﾀｲﾄﾙﾌｫﾝﾄ(18)
                            lcalCalendar.TitleFont = _
                                New Font(.FontFamily, CPlngClTlFontSize, .Style, _
                                         .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .GridFont                              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄ(16)
                            lcalCalendar.GridFont = _
                                New Font(.FontFamily, CPlngClGridFontSize, .Style, _
                                         .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        '@日付の設定
                        If lstrDateValue <> CPstrNullDate Then
                            '@初期値以外の値が設定された場合
                            .Value = lstrDateValue
                        End If
                    End With
                    
                    '@戻り値にTrueを設定
                    pubblnCalendar_Init = True
                
                Case CPlngCalModeTool
                    '@ﾂｰﾙ系画面ｻｲｽﾞの場合
                    With lcalCalendar
                        .CalendarHeight = CPlngMClHeight            '高さ
                        .CalendarWidth = CPlngMClWidth              '幅
                        With .Font                                  'ﾌｫﾝﾄ(12)
                            lcalCalendar.Font = _
                                New Font(.FontFamily, CPlngMClGridFontSize, .Style, _
                                         .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .DayFont                               '日付ﾌｫﾝﾄ(11)
                            lcalCalendar.DayFont = _
                                New Font(.FontFamily, CPlngMClFontSize, .Style, _
                                         .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .TitleFont                             'ﾀｲﾄﾙﾌｫﾝﾄ(14)
                            lcalCalendar.TitleFont = _
                                New Font(.FontFamily, CPlngMClTlFontSize, .Style, _
                                         .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .GridFont                              'ｸﾞﾘｯﾄﾞﾌｫﾝﾄ(12)
                            lcalCalendar.GridFont = _
                                New Font(.FontFamily, CPlngMClGridFontSize, .Style, _
                                         .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        '@日付の設定
                        If lstrDateValue <> CPstrNullDate Then
                            '@初期値以外の値が設定された場合
                            .Value = lstrDateValue
                        End If
                    End With
                    '@戻り値にTrueを設定
                    pubblnCalendar_Init = True
            End Select
        End If
        
    End Function

    '関数名：pubOnError_Proc
    '機　能：共通OnError処理
    '引　数：ltypOnErrorInfo：ｴﾗｰ情報構造体
    '戻り値：True:正常判定、False:異常判定
    '作成日：2005/02/02 (Wed) 11:32:21 H.Wajima
    '更新日：2008/02/25 (Mon) 17:02:39 M.Koni
    '備　考：
    '　　　：2005/04/07 (Thu) 11:06:06 N.Kasai  実行時ｴﾗｰ情報初期化を追加
    '　　　：2005/09/26 (Mon) 14:30:23 N.Kasai  Functionﾃｰﾌﾞﾙよりﾒﾆｭｰkeyが取得できない場合の処理を追加
    '　　　：2008/02/25 (Mon) 17:02:51 M.Koni   Environ関数の型変換対応(不具合No.02510)
    Public Sub pubOnError_Proc()
        
        Dim lstrTitle               As String                   'ﾀｲﾄﾙ
        Dim llngRet                 As Integer                  '戻り値
        Dim ltypCommonInfo          As CommonInfo               '引継ぎ情報
        Dim ltypOnErrorInfoLog      As CommonOnErrorInfoLog     'ｴﾗｰﾛｸﾞ情報
        Dim ltypOnErrorInfo         As OnErrorInfo              '実行時ｴﾗｰ情報
        Dim llngCnt                 As Integer                  'ﾙｰﾌﾟｶｳﾝﾀ
        
        With ltypOnErrorInfoLog
            '@ｴﾗｰﾛｸﾞ情報を設定する
            .strDate = Format$(Today, CPstrDateTimeYMD)         '日付
            .strTime = Format$(TimeOfDay, CPstrDateFormatHMS)   '時刻
            .strComputerName = pstrComputerName                 '端末名
            .strIPaddress = pstrIpAddress                       'IPｱﾄﾞﾚｽ
            .strUserID = StrConv(Environ(CPstrEnvironUserName), vbLowerCase + vbNarrow)     'ﾕｰｻﾞｰID
            .strSbID = pstrSBID                                 'SBID
            .strTestStatus = pstrTestStatus                     'ﾃｽﾄｽﾃｰﾀｽ
            .strTerminalMode = pstrTerminalMode                 '端末区分
            .lngErrNumber = Err.Number                          'ｴﾗｰ№
            .strErrDescription = Err.Description                'ｴﾗｰ説明
            .strMenuKey = ptypOnErrorInfo.strMenuKey            '機能ID
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(.strMenuKey, _
                                            lstrTitle, _
                                            , _
                                            .strFormName)           'ﾌｫｰﾑ名
            .strProcName = ptypOnErrorInfo.strProcName              'ﾌﾟﾛｼｰｼﾞｬ名
            .strErrDetail = ptypOnErrorInfo.strErrPositionDetail    'ｴﾗｰ発生箇所
            .strErrMessage = ptypOnErrorInfo.strErrMessage          'ｴﾗｰﾒｯｾｰｼﾞ
            
            '@Functionﾃｰﾌﾞﾙより値が取得できない場合の対応
            '@子画面でON ERRとなった場合にﾌｫｰﾑを終了させる為、記述する。
            '@今後、全ﾌｫｰﾑをFUNCTIONﾃｰﾌﾞﾙに登録を行えば当記述は必要なし。
            If .strFormName = vbNullString Then
                '@引数で渡されたﾒﾆｭｰｷｰに一致するﾌｫｰﾑを終了
                For llngCnt = 0 To Application.OpenForms.Count - 1
                    If Application.OpenForms(llngCnt).Name = "frmxx" & .strMenuKey Then
                        '@ﾀｲﾄﾙ名設定
                        lstrTitle = Application.OpenForms(llngCnt).Text
                        '@ﾌｫｰﾑ名設定
                        .strFormName = "frmxx" & .strMenuKey
                        Exit For
                    End If
                Next llngCnt
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(.strFormName, .strProcName)
                    
            '@ｴﾗｰ番号の判定
            Select Case .lngErrNumber
                Case CPlngSetFoucusErrStatusCD
                    '@SetFocusｴﾗｰの場合
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞの判定
                    If .strErrMessage = vbNullString Then
                        '@ｴﾗｰﾒｯｾｰｼﾞが設定されていない場合
                        '@SetFocus警告ﾒｯｾｰｼﾞを設定する
                        '@「<TRMY1W>$$軽微なシステムエラーが発生しましたが処理は続行可能です。」
                        .strErrMessage = CPstrMsgWar00Y1
                    End If
                    
                    '@ｴﾗｰﾛｸﾞ出力
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@ﾃｽﾄｽﾃｰﾀｽの判定
                    Select Case .strTestStatus
                        Case CPstrDeveStatus, CPstrTestStatus, CPstrEQStatus
                            '@"D"(開発),"T"(ﾃｽﾄ),"E"(EQ)の場合
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(.strErrMessage)
                            '@ﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lstrTitle, True, 16)
                    End Select
                    
                Case Else
                    '@上記以外の場合
                    
                    '@ｴﾗｰﾒｯｾｰｼﾞの判定
                    If .strErrMessage = vbNullString Then
                        '@ｴﾗｰﾒｯｾｰｼﾞが設定されていない場合(ｴﾗｰﾒｯｾｰｼﾞが設定済みの場合は、設定済みのﾒｯｾｰｼﾞを表示する)
                        '@ｴﾗｰ番号により再度振り分け
                        Select Case .lngErrNumber
                            Case CPlngAryIndexErrStatusCD
                                '@配列のｲﾝﾃﾞｯｸｽｴﾗｰの場合
                                '@配列ｲﾝﾃﾞｯｸｽｴﾗｰｴﾗｰﾒｯｾｰｼﾞを設定する
                                '@「<TRMY2E>$$システムエラーが発生しました。システム担当者に連絡してください。」
                                .strErrMessage = CPstrMsgErr00Y2
                            Case CPlngPropertyIndexErrStatusCD
                                '@ﾌﾟﾛﾊﾟﾃｨのｲﾝﾃﾞｯｸｽｴﾗｰ(VSFlexで範囲外のｾﾙを選択した場合など)の場合
                                '@ﾌﾟﾛﾊﾟﾃｨｲﾝﾃﾞｯｸｽｴﾗｰﾒｯｾｰｼﾞを設定する
                                '@「<TRMY3E>$$システムエラーが発生しました。システム担当者に連絡してください。」
                                .strErrMessage = CPstrMsgErr00Y3
                            Case Else
                                '@上記以外の場合
                                '@汎用ｴﾗｰﾒｯｾｰｼﾞを設定する
                                '@「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」
                                .strErrMessage = CPstrMsgErr00Y0
                        End Select
                    End If
                    
                    '@ｴﾗｰﾛｸﾞ出力
                    Call pubErrorLogOutput(ltypOnErrorInfoLog, CPlngCommonErrLogClientModeTrm)
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(.strErrMessage)
                    '@ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lstrTitle, True, 16)
                    
                    '@機能終了
                    '@処理名がFormLoadの場合は、終了するとｴﾗｰになるので終了させない
                    If .strProcName = CPstrProcNameFormLoad Then
                        '@処理名がForm_Loadの場合
                        '@FormLoadﾌﾗｸﾞにFalseを設定し、ﾒﾆｭｰのStart処理を終了させる
                        '@Form_Loadﾌﾗｸﾞ(異常)
                        pblnFormLoad = False
                    Else
                        '@処理名がForm_Load以外の場合
                        '@終了関数を実行する
                        llngRet = publngEnd_Proc(.strMenuKey, ltypCommonInfo)
                    End If
            End Select
        End With

        '@実行時ｴﾗｰ情報の初期化
        ptypOnErrorInfo = ltypOnErrorInfo
        
      
    End Sub

    '関数名：pubAuthority_Chk
    '機　能：実行権限ﾁｪｯｸ
    '引　数：lstrFunctionID ：機能ID
    '　　　：lstrActionID   ：処理ID
    '　　　：lstrEmpID      ：作業者ID
    '　　　：lstrEmpName    ：作業者名
    '　　　：lstrSBID       ：ｼｽﾃﾑﾌﾞﾛｯｸ
    '戻り値：True:OK、False:NG
    '作成日：2007/02/05 (Mon) 08:46:22 N.Kojima
    '更新日：2008/04/24 (Thu) 09:26:48 N.Kojima
    '備　考：ﾚｽﾎﾟﾝｽ処理の中に入れてね
    '　　　：2008/04/24 (Thu) 09:26:48 N.Kojima     mas_.empname_の応答にｸﾞﾙｰﾌﾟIDが追加されたことに伴う修正。(案件№02786)
    Public Function pubAuthority_Chk(ByVal lstrFunctionID As String, _
                                     ByVal lstrActionID As String, _
                                     ByVal lstrEmpID As String, _
                                     ByRef lstrEmpName As String, _
                                     ByVal lstrSBID As String) As Boolean

        Dim lblnAns             As Boolean      '結果格納
        Dim lstrAuthority       As String       '権限ﾌﾗｸﾞ
        Dim lstrDeptID          As String       '部署ID
        Dim lstrDeptName        As String       '部署名
        Dim lstrGroupID         As String       '所属ｸﾞﾙｰﾌﾟID
        Dim lstrMailAddress     As String       'ﾒｰﾙｱﾄﾞﾚｽ

        '@各種初期化
        pubAuthority_Chk = False                '戻り値
        lstrDeptID = vbNullString               '部署ID(Null：初期設定)
        lstrDeptName = vbNullString             '部署名(Null：初期設定)
        lstrGroupID = vbNullString              '所属ｸﾞﾙｰﾌﾟID(Null：初期設定)
        lstrMailAddress = vbNullString          'ﾒｰﾙｱﾄﾞﾚｽ(Null：初期設定)
        
        '@【作業者名取得】ﾒｯｾｰｼﾞ送受信処理
        lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, _
                                       lstrEmpID, _
                                       lstrEmpName, _
                                       lstrDeptID, _
                                       lstrDeptName, _
                                       lstrGroupID, _
                                       lstrFunctionID, _
                                       lstrActionID, _
                                       lstrAuthority, _
                                       lstrSBID, _
                                       lstrMailAddress)

        '@通信結果判定
        If lblnAns = True Then
            '@結果：正常の場合
        
            '@実行権限ﾁｪｯｸの処理結果が(1:実行可能)か
            If lstrAuthority = CMstrAuthority1 Then
                '@戻り値に"True：実行権限有り"をｾｯﾄ
                pubAuthority_Chk = True
            Else
                '@戻り値に"False：実行権限なし"をｾｯﾄ
                pubAuthority_Chk = False
            End If
        Else
            '@結果：異常の場合
        
            '@戻り値に"False：実行権限なし"をｾｯﾄ
            pubAuthority_Chk = False
        End If

    End Function

    '関数名：pubstrMailAddress_Sel
    '機　能：ﾒｰﾙｱﾄﾞﾚｽ取得
    '引　数：lstrEmpID：作業者ID
    '戻り値：ﾒｰﾙｱﾄﾞﾚｽ/Null
    '作成日：2005/11/24 (Thu) 16:38:19 S.Deguchi
    '更新日：2005/11/24 (Thu) 16:38:19
    '備　考：
    Public Function pubstrMailAddress_Sel(ByVal lstrEmpID As String) As String


        Dim lblnAns         As Boolean      '結果格納
        Dim lstrEmpName     As String       '作業者名
        Dim lstrDeptID      As String       '部署ID
        Dim lstrDeptName    As String       '部署名
        Dim lstrFunctionID  As String       '機能ID
        Dim lstrActionID    As String       'ｱｸｼｮﾝID
        Dim lstrAuthority   As String       '権限ﾌﾗｸﾞ
        Dim lstrMailAddress As String       'ﾒｰﾙｱﾄﾞﾚｽ

        '@初期化
        pubstrMailAddress_Sel = vbNullString
        lstrEmpName = vbNullString          '作業者名(Null：初期設定)
        lstrDeptID = vbNullString           '部署ID(Null：初期設定)
        lstrDeptName = vbNullString         '部署名(Null：初期設定)
        lstrFunctionID = vbNullString       '機能ID(Null：初期設定)
        lstrActionID = vbNullString         'ｱｸｼｮﾝID(Null：初期設定)
        lstrAuthority = vbNullString        '実行権限ﾌﾗｸﾞ(Null：初期設定)
        lstrMailAddress = vbNullString      'ﾒｰﾙｱﾄﾞﾚｽ(Null：初期設定)
        
        '@作業者名取得
        lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, _
                                       lstrEmpID, _
                                       lstrEmpName, _
                                       lstrDeptID, _
                                       lstrDeptName, _
                                       vbNullString, _
                                       lstrFunctionID, _
                                       lstrActionID, _
                                       lstrAuthority, _
                                       pstrSBID, _
                                       lstrMailAddress)

        '@成功の場合
        If lblnAns = True Then
            If lstrMailAddress = vbNullString Then
                '@ｱﾄﾞﾚｽ無
                pubstrMailAddress_Sel = vbNullString
            Else
                '@ｱﾄﾞﾚｽ有
                pubstrMailAddress_Sel = lstrMailAddress
            End If
        Else
            '@ｱﾄﾞﾚｽ無
            pubstrMailAddress_Sel = vbNullString
        End If

    End Function

    '関数名：pubstrLimitTime_Set
    '機　能：制限時間を分合計から、時間と分に分割する
    '引　数：lstrLimitTime：制限時間(分合計)
    '戻り値：制限時間(時間と分へ分割)
    '作成日：2006/05/11 (Thu) 14:32:26 T.Kitagawa
    '更新日：2006/05/11 (Thu) 14:32:26
    '備　考：
    Public Function pubstrLimitTime_Set(ByVal lstrLimitTime As String) As String

        Dim llngHour        As Integer  '制限時間(時間)
        Dim llngMinute      As Integer  '制限時間(分)
        
        '@初期化
        pubstrLimitTime_Set = vbNullString
        
        '@数字確認(念の為)
        If IsNumeric(lstrLimitTime) = False Then
            Exit Function
        End If
            
        '@制限時間(時間)の算出
        llngHour = Fix(lstrLimitTime / CMlngMinute60)
        
        '@制限時間(分)の算出(余りが分になる)
        llngMinute = lstrLimitTime Mod CMlngMinute60
        
        '@時間を表示するか判定
        If llngHour = 0 Then
            '@0時間の場合は時間は表示しない
            '@時間制限(#0分)の生成
            pubstrLimitTime_Set = Format$(llngMinute, CPstrDateFormatKanma) & CPstrh
        Else
            '@0時間以外の場合は時間を表示する
            '@制限時間(分)の設定(絶対値を取得し、符号を省きます。)
            llngMinute = Math.Abs(llngMinute)
            '@時間制限(#,##0時間 #0分)の生成
            pubstrLimitTime_Set = Format$(llngHour, CPstrDateFormatKanma) & CPstrHour & _
                                Space(1) & Format$(llngMinute, CPstrDateFormatKanma) & CPstrh
        End If
        
        Exit Function
        
    End Function

    '関数名：pubstrColKbn_Set
    '機　能：保/停項目設定値返却
    '引　数：lstrColKbn：保/停項目の値
    '　　　：lstrKbn：保/停項目の追加分の値
    '戻り値：保/停項目の値(「号・リ・追・保・停」等)
    '作成日：2006/10/18 (Wed) 13:17:53 M.Miura
    '更新日：2006/10/18 (Wed) 13:17:53
    '備　考：
    Public Function pubstrColKbn_Set(ByVal lstrColKbn As String, ByVal lstrKbn As String) As String
        
        If Trim$(lstrColKbn) = vbNullString Then
            '@保/停項目がNULLの場合
            '@保/停追加分の値を設定
            pubstrColKbn_Set = lstrKbn
        Else
            '@保/停項目が既に設定されている場合
            '@既存の保/停項目に追加設定
            pubstrColKbn_Set = lstrKbn & CMstrTen & lstrColKbn
        End If
        
        Exit Function
        
    End Function

    '関数名：pubStrFormatValue_Set
    '機　能：ﾌｫｰﾏｯﾄ変換
    '引　数：lstrValue：小数点以下制御値
    '戻り値：ﾌｫｰﾏｯﾄ
    '作成日：2006/03/13 (Mon) 10:28:52 N.Kasai
    '更新日：2006/03/29 (Wed) 10:20:46 N.Kasai
    '備　考：
    '　　　：2006/03/29 (Wed) 10:20:46 N.Kasai  桁拡張
    Public Function pubStrFormatValue_Set(ByVal lstrValue As String) As String
        
        pubStrFormatValue_Set = vbNullString
                    
        '@小数点以下が設定済みの場合
        If lstrValue <> vbNullString Then
        
            '@ﾌｫｰﾏｯﾄ設定
            Select Case lstrValue
                Case "1"
                    pubStrFormatValue_Set = CPstrDoubleFormat1String
                Case "2"
                    pubStrFormatValue_Set = CPstrDoubleFormat2String
                Case "3"
                    pubStrFormatValue_Set = CPstrDoubleFormat3String
                Case "4"
                    pubStrFormatValue_Set = CPstrDoubleFormat4String
                Case "5"
                    pubStrFormatValue_Set = CPstrDoubleFormat5String
                Case "6"
                    pubStrFormatValue_Set = CPstrDoubleFormat6String
                Case "7"
                    pubStrFormatValue_Set = CPstrDoubleFormat7String
                Case "8"
                    pubStrFormatValue_Set = CPstrDoubleFormat8String
                Case "9"
                    pubStrFormatValue_Set = CPstrDoubleFormat9String
            End Select
            
        End If

    End Function

    '関数名：pubSetPatchNoItems
    '機　能：patchNoに応じたItem値を返す
    '引　数：llngPatchNum：ﾊﾟｯﾁ№
    '戻り値：
    '作成日：2017/01/20 (Fri) 11:26:54 T.Oide
    '更新日：2017/01/20 (Fri) 11:26:54
    '備　考：
    Public Sub pubSetPatchNoItems(ByVal llngPatchNum As Integer, ByVal llngIndex As Integer, _
                                  ByRef lstrTmpShiftX As String, ByRef lstrTmpShiftY As String, _
                                  ByRef lstrTmpWaferMagX As String, ByRef lstrTmpWaferMagY As String, _
                                  ByRef lstrTmpaferRotX As String, ByRef lstrTmpWaferRotY As String, _
                                  ByRef lstrTmpShotRot As String, ByRef lstrTmpShotMag As String, _
                                  ByRef lstrTmpShotRotX As String, ByRef lstrTmpShotRotY As String, _
                                  ByRef lstrTmpShotMagX As String, ByRef lstrTmpShotMagY As String)

        With ptypPhotoFbDataListAns.typFbDataItemList(llngIndex)
            
            '@選択中のﾊﾟｯﾁ№で分岐
            Select Case llngPatchNum
            
                Case CPlngPatchNo2
                    'patchNo2の場合
                    lstrTmpShiftX = .strShiftXValue_2       'ShiftX
                    lstrTmpShiftY = .strShiftYValue_2       'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue_2 'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue_2 'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue_2  'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue_2 'WaferRotY
                    lstrTmpShotRot = .strShotRotValue_2     'ShotRot
                    lstrTmpShotMag = .strShotMagValue_2     'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue_2   
                    lstrTmpShotRotY = .strShotRotYValue_2     
                    lstrTmpShotMagX = .strShotMagXValue_2     
                    lstrTmpShotMagY = .strShotMagYValue_2     

                Case CPlngPatchNo3
                    'patchNo3の場合
                    lstrTmpShiftX = .strShiftXValue_3       'ShiftX
                    lstrTmpShiftY = .strShiftYValue_3       'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue_3 'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue_3 'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue_3  'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue_3 'WaferRotY
                    lstrTmpShotRot = .strShotRotValue_3     'ShotRot
                    lstrTmpShotMag = .strShotMagValue_3     'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue_3   
                    lstrTmpShotRotY = .strShotRotYValue_3     
                    lstrTmpShotMagX = .strShotMagXValue_3     
                    lstrTmpShotMagY = .strShotMagYValue_3 
                    
                Case CPlngPatchNo4
                    'patchNo4の場合
                    lstrTmpShiftX = .strShiftXValue_4       'ShiftX
                    lstrTmpShiftY = .strShiftYValue_4       'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue_4 'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue_4 'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue_4  'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue_4 'WaferRotY
                    lstrTmpShotRot = .strShotRotValue_4     'ShotRot
                    lstrTmpShotMag = .strShotMagValue_4     'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue_4   
                    lstrTmpShotRotY = .strShotRotYValue_4     
                    lstrTmpShotMagX = .strShotMagXValue_4     
                    lstrTmpShotMagY = .strShotMagYValue_4 

                    
                Case CPlngPatchNo5
                    'patchNo5の場合
                    lstrTmpShiftX = .strShiftXValue_5       'ShiftX
                    lstrTmpShiftY = .strShiftYValue_5       'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue_5 'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue_5 'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue_5  'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue_5 'WaferRotY
                    lstrTmpShotRot = .strShotRotValue_5     'ShotRot
                    lstrTmpShotMag = .strShotMagValue_5     'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue_5   
                    lstrTmpShotRotY = .strShotRotYValue_5     
                    lstrTmpShotMagX = .strShotMagXValue_5     
                    lstrTmpShotMagY = .strShotMagYValue_5 
                    
                Case CPlngPatchNo6
                    'patchNo6の場合
                    lstrTmpShiftX = .strShiftXValue_6       'ShiftX
                    lstrTmpShiftY = .strShiftYValue_6       'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue_6 'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue_6 'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue_6  'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue_6 'WaferRotY
                    lstrTmpShotRot = .strShotRotValue_6     'ShotRot
                    lstrTmpShotMag = .strShotMagValue_6     'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue_6   
                    lstrTmpShotRotY = .strShotRotYValue_6     
                    lstrTmpShotMagX = .strShotMagXValue_6     
                    lstrTmpShotMagY = .strShotMagYValue_6 
                    
                Case CPlngPatchNo7
                    'patchNo7の場合
                    lstrTmpShiftX = .strShiftXValue_7       'ShiftX
                    lstrTmpShiftY = .strShiftYValue_7       'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue_7 'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue_7 'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue_7  'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue_7 'WaferRotY
                    lstrTmpShotRot = .strShotRotValue_7     'ShotRot
                    lstrTmpShotMag = .strShotMagValue_7     'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue_7   
                    lstrTmpShotRotY = .strShotRotYValue_7     
                    lstrTmpShotMagX = .strShotMagXValue_7     
                    lstrTmpShotMagY = .strShotMagYValue_7 
                    
                Case CPlngPatchNo8
                    'patchNo8の場合
                    lstrTmpShiftX = .strShiftXValue_8       'ShiftX
                    lstrTmpShiftY = .strShiftYValue_8       'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue_8 'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue_8 'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue_8  'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue_8 'WaferRotY
                    lstrTmpShotRot = .strShotRotValue_8     'ShotRot
                    lstrTmpShotMag = .strShotMagValue_8     'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue_8   
                    lstrTmpShotRotY = .strShotRotYValue_8     
                    lstrTmpShotMagX = .strShotMagXValue_8     
                    lstrTmpShotMagY = .strShotMagYValue_8 
                    
                Case CPlngPatchNo9
                    'patchNo9の場合
                    lstrTmpShiftX = .strShiftXValue_9       'ShiftX
                    lstrTmpShiftY = .strShiftYValue_9       'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue_9 'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue_9 'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue_9  'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue_9 'WaferRotY
                    lstrTmpShotRot = .strShotRotValue_9     'ShotRot
                    lstrTmpShotMag = .strShotMagValue_9     'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue_9   
                    lstrTmpShotRotY = .strShotRotYValue_9     
                    lstrTmpShotMagX = .strShotMagXValue_9     
                    lstrTmpShotMagY = .strShotMagYValue_9 
                    
                Case Else
                    'patchNo1か「分割なし」の場合
                    lstrTmpShiftX = .strShiftXValue         'ShiftX
                    lstrTmpShiftY = .strShiftYValue         'ShiftY
                    lstrTmpWaferMagX = .strWaferMagXValue   'WaferMagX
                    lstrTmpWaferMagY = .strWaferMagYValue   'WaferMagY
                    lstrTmpaferRotX = .strWaferRotXValue    'WaferRotX
                    lstrTmpWaferRotY = .strWaferRotYValue   'WaferRotY
                    lstrTmpShotRot = .strShotRotValue       'ShotRot
                    lstrTmpShotMag = .strShotMagValue       'ShotMag
                    'Shot分離 
                    lstrTmpShotRotX = .strShotRotXValue   
                    lstrTmpShotRotY = .strShotRotYValue     
                    lstrTmpShotMagX = .strShotMagXValue     
                    lstrTmpShotMagY = .strShotMagYValue 

            End Select
            
        End With

    End Sub

    '関数名：setPtypApcOpStepListMesureVal
    '機　能：「ﾌｫﾄF/B(合せ)」patch分割ありの場合に測定行程の値をｾｯﾄする
    '引　数：lngIndex：配列番号
    '　　　：lngMesNum：測定行程1～9の番号
    '戻り値：なし
    '作成日：2017/01/12 (Thu) 08:38:26 T.Oide
    '更新日：2017/01/12 (Thu) 08:38:26
    '備　考：
    Public Sub setPtypApcOpStepListMesureVal( _
            ByVal lngIndex As Integer, ByVal lngMesNum As Integer, _
            ByVal strOpID As String, ByVal strStepID As String)
        
        Dim tmpApcOpStepList As ApcOpStepList = ptypApcOpStepInfo.typApcTypeList(0).typApcOpStepList(lngIndex)

        With tmpApcOpStepList
        
            '@測定行程1の場合
            If lngMesNum = CPlngNumOne Then
                .strToOpId = strOpID
                .strToStepId = strStepID
                
            '@測定行程2の場合
            ElseIf lngMesNum = CPlngNumTwo Then
                .strToOpId_2 = strOpID
                .strToStepId_2 = strStepID
                .lngPatchDivNum = 2
                
            '@測定行程3の場合
            ElseIf lngMesNum = CPlngNumThree Then
                .strToOpId_3 = strOpID
                .strToStepId_3 = strStepID
                .lngPatchDivNum = 3
                
            '@測定行程4の場合
            ElseIf lngMesNum = CPlngNumFour Then
                .strToOpId_4 = strOpID
                .strToStepId_4 = strStepID
                .lngPatchDivNum = 4
                
            '@測定行程5の場合
            ElseIf lngMesNum = CPlngNumFive Then
                .strToOpId_5 = strOpID
                .strToStepId_5 = strStepID
                .lngPatchDivNum = 5
                
            '@測定行程6の場合
            ElseIf lngMesNum = CPlngNumSix Then
                .strToOpId_6 = strOpID
                .strToStepId_6 = strStepID
                .lngPatchDivNum = 6
                
            '@測定行程7の場合
            ElseIf lngMesNum = CPlngNumSeven Then
                .strToOpId_7 = strOpID
                .strToStepId_7 = strStepID
                .lngPatchDivNum = 7
                
            '@測定行程8の場合
            ElseIf lngMesNum = CPlngNumEight Then
                .strToOpId_8 = strOpID
                .strToStepId_8 = strStepID
                .lngPatchDivNum = 8
                
            '@測定行程9の場合
            ElseIf lngMesNum = CPlngNumNine Then
                .strToOpId_9 = strOpID
                .strToStepId_9 = strStepID
                .lngPatchDivNum = 9
                
            End If

            ptypApcOpStepInfo.typApcTypeList(0).typApcOpStepList(lngIndex) = tmpApcOpStepList
                
        End With

    End Sub

    '関数名：getPtypApcOpStepListMesureVal
    '機　能：「ﾌｫﾄF/B(合せ)」patch分割ありの場合に測定行程の値を取得する
    '引　数：lngIndex：配列番号
    '　　　：lngMesNum：測定行程1～9の番号
    '戻り値：なし
    '作成日：2017/01/12 (Thu) 08:38:26 T.Oide
    '更新日：2017/01/12 (Thu) 08:38:26
    '備　考：
    Public Sub getPtypApcOpStepListMesureVal( _
            ByVal lngIndex As Integer, ByVal lngMesNum As Integer, _
            ByRef strOpID As String, ByRef strStepID As String)
        
        With ptypApcOpStepInfo.typApcTypeList(0).typApcOpStepList(lngIndex)
        
            '@測定行程1の場合
            If lngMesNum = CPlngNumOne Then
                strOpID = .strToOpId
                strStepID = .strToStepId
                
            '@測定行程2の場合
            ElseIf lngMesNum = CPlngNumTwo Then
                strOpID = .strToOpId_2
                strStepID = .strToStepId_2
                
            '@測定行程3の場合
            ElseIf lngMesNum = CPlngNumThree Then
                strOpID = .strToOpId_3
                strStepID = .strToStepId_3
                
            '@測定行程4の場合
            ElseIf lngMesNum = CPlngNumFour Then
                strOpID = .strToOpId_4
                strStepID = .strToStepId_4
                
            '@測定行程5の場合
            ElseIf lngMesNum = CPlngNumFive Then
                strOpID = .strToOpId_5
                strStepID = .strToStepId_5
                
            '@測定行程6の場合
            ElseIf lngMesNum = CPlngNumSix Then
                strOpID = .strToOpId_6
                strStepID = .strToStepId_6
                
            '@測定行程7の場合
            ElseIf lngMesNum = CPlngNumSeven Then
                strOpID = .strToOpId_7
                strStepID = .strToStepId_7
                
            '@測定行程8の場合
            ElseIf lngMesNum = CPlngNumEight Then
                strOpID = .strToOpId_8
                strStepID = .strToStepId_8
                
            '@測定行程9の場合
            ElseIf lngMesNum = CPlngNumNine Then
                strOpID = .strToOpId_9
                strStepID = .strToStepId_9
                
            End If
                
        End With

    End Sub

    '関数名：pubParentPdToAldPd
    '機　能：2A0機種から3A0機種を返す(存在しない場合はそのまま返す）
    '引　数：strParentPdId：2A0機種
    '戻り値：3A0機種
    '作成日：2018/08/14 (Tue) 10:35:21 T.Oide
    '更新日：2018/08/14 (Tue) 10:35:21
    '備　考：
    Public Function pubParentPdToAldPd(ByVal strParentPdId As String, ByRef typTapeStickList As TapeStickGrList) As String

        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer
        Dim lblnFindFlag    As Boolean
        
        '@結果を初期化
        pubParentPdToAldPd = strParentPdId
        lblnFindFlag = False
        
        With typTapeStickList
            
            '@typTapeStickListで回す
            For llngCnt = 0 To .lngTapeStickGrCnt - 1
            
                '@.lngPdListCntで回す
                For llngCnt2 = 0 To .typTapeStickGr(llngCnt).lngPdListCnt - 1
                
                    With .typTapeStickGr(llngCnt)
                    
                        '@親機種は一致したか
                        If strParentPdId = .typPdList(llngCnt2).strParentPdId Then
                            
                            '@(3A0)機種格納
                            pubParentPdToAldPd = .typPdList(llngCnt2).strPdId
                            lblnFindFlag = True
                            Exit For
                        End If
                        
                    End With
                Next
                
                '@見つかったらﾙｰﾌﾟ終了
                If lblnFindFlag = True Then
                    Exit For
                End If
            Next
        
        End With
        
    End Function
    
    '関数名：pubGRBBackColor
    '機　能：GRB設定での背景色を返信
    '引　数：strGRBClass：GRB設定
    '　　　：lstrDefaultColor：選択可能な色ｺｰﾄﾞが無い場合の指定値
    '戻り値：背景色ｺｰﾄﾞ
    '作成日：2019/12/17 (Tue) 11:37:28 Y.Yoneyama 「.Netへ反映未」
    '更新日：2019/12/17 (Tue) 11:37:28 Y.Yoneyama 「.Netへ反映未」
    '備　考：
    'Public Function pubGRBBackColor(ByVal strGRBClass As String, _
    '                            Optional ByVal lstrDefaultColor As String = vbNullString) As String    
    Public Function pubGRBBackColor(ByVal strGRBClass As String, _
                                Optional ByRef defaultColor As Color = Nothing) As Color

        '@GRB背景色
        Select Case strGRBClass
                    
            '@G
            Case CPstrGRB_G
                pubGRBBackColor = ColorTranslator.FromWin32(CPlngG_BackColor)

            '@R
            Case CPstrGRB_R
                pubGRBBackColor = ColorTranslator.FromWin32(CPlngR_BackColor)
                
            '@B
            Case CPstrGRB_B
                pubGRBBackColor = ColorTranslator.FromWin32(CPlngB_BackColor)
                
            '@GR
            Case CPstrGRB_GR
                pubGRBBackColor = ColorTranslator.FromWin32(CPlngGR_BackColor)
                    
            '@GB
            Case CPstrGRB_GB
                pubGRBBackColor = ColorTranslator.FromWin32(CPlngGB_BackColor)
                    
            '@RB
            Case CPstrGRB_RB
                pubGRBBackColor = ColorTranslator.FromWin32(CPlngRB_BackColor)
                    
            '@MX[GRB混在]
            Case CPstrGRB_MIX
                pubGRBBackColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                     
            '@上記以外
            Case Else
                If defaultColor = Nothing Then
                    pubGRBBackColor = Color.White   '白
                Else
                    pubGRBBackColor = defaultColor  '指定色
                End If
        End Select
    
    End Function

End Module
