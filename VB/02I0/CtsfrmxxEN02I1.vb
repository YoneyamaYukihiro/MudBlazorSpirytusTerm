'ﾌｧｲﾙ名：xxEN02I1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：区間優先設定詳細
'作成日：2011/09/14 (Wed) 14:09:23 T.Oide
'更新日：2011/09/14 (Wed) 14:09:23
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02I1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02I1    ' ただ一つのフォームのインスタンスを保持する変数

    '***************************************************************************************
    '                              * Sharedプロパティの記述 *
    '***************************************************************************************
    '======================================Public===========================================
    ' NSYS 追加
    '関数名：Instance
    '機　能：ただ一つのフォームにアクセスするためのプロパティ
    '作成日：2018/12/05 (Wed)
    '更新日：2018/12/05 (Wed)
    '備　考：
    Public Shared Property Instance() As frmxxEN02I1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02I1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02I1)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02I0      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_secPriorityDetailVer     As String = "01.00"             '区間優先情報詳細取得

    '@vsfLotTravelerの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfLotTravelerNo             As Integer = 0                  'No
    Private Const CMlngvsfLotTravelerOpId           As Integer = 1                  '大工程
    Private Const CMlngvsfLotTravelerStepId         As Integer = 2                  '小工程
    Private Const CMlngvsfLotTravelerPriority       As Integer = 3                  '優先度

    '@vsfLotTravelerの定数宣言(表示幅)
    Private Const CMlngvsfLotTravelerNoW            As Integer = 32                 'No
    Private Const CMlngvsfLotTravelerOpIdW          As Integer = 120                '大工程
    Private Const CMlngvsfLotTravelerStepIdW        As Integer = 120                '小工程
    Private Const CMlngvsfLotTravelerPriorityW      As Integer = 72                 '優先度

    '@vsfLotTravelerの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfLotTravelerNoN            As String = "No"
    Private Const CMstrvsfLotTravelerOpIdN          As String = "大工程"
    Private Const CMstrvsfLotTravelerStepIdN        As String = "小工程"
    Private Const CMstrvsfLotTravelerPriorityN      As String = "優先度"

    Private Const CmstrNameLotID                    As String = "ロットID："
    Private Const CmstrNameNamePriority             As String = "区間優先："
    Private Const CmstrSpace                        As String = "　"
    Private Const CmstrNoLotPriority                As String = "なし"

    Private Const CMlngZero                         As Integer = 0                  '0(数値)
    Private Const CMlngOne                          As Integer = 1                  '1(数値)
    Private Const CMlngTwo                          As Integer = 2                  '2(数値)
    Private Const CMlngThree                        As Integer = 3                  '3(数値)
    Private Const CMlngFour                         As Integer = 4                  '4(数値)
    Private Const CMlngFive                         As Integer = 5                  '5(数値)
    Private Const CMlngSix                          As Integer = 6                  '6(数値)
    Private Const CMlngSeven                        As Integer = 7                  '7(数値)

    '@vsfLotTravelerのその他定数宣言
    Private Const CMlngvsfLotTravelerRowTitle       As Integer = 0                  '行ﾀｲﾄﾙ
    Private Const CMlngvsfLotTravelerColTitle       As Integer = 0                  '列ﾀｲﾄﾙ
    Private Const CMlngvsfLotTravelerHHeight        As Integer = 20                 'ﾍｯﾀﾞｰ高さ
    Private Const CMlngvsfLotTravelerHFontSize      As Single = 11.25               'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ：11

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMstrCmbFontName                  As String = "ＭＳ ゴシック"     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄ名
    Private Const CMlngCmbFontSize                  As Single = 11.25               'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Single = 11.25               'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName               As Integer = 0                  '名称列番
    Private Const CMlngCmbGridColID                 As Integer = 1                  'ID列番(非表示項目：PD_ID)
    Private Const CMlngCmbGridColID2                As Integer = 2                  'ID列番2(非表示項目：USE_ID)
    Private Const CMlngCmbSortAsc                   As Integer = 1                  '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                  As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 18                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbClearListIndex            As Integer = -1                 'ﾃｷｽﾄ値初期化
    Private Const CMlngCMbSelectMode                As Integer = 1                  '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbFirstListIndex            As Integer = 0                  'ｺﾝﾎﾞLISTの表示位置
    Private Const CMlngCmbGetCol5                   As Integer = 5                  'ﾊﾞｯｸｶﾗｰ格納Col
    Private Const CMstrAddedComment                 As String = "項目選択"          'ｺﾝﾎﾞ一覧選択時の追加コメント
    Private Const CMstrCmbCheckOn                   As String = "1"                 'ｺﾝﾎﾞﾁｪｯｸON

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mblnFormLoadFlag                        As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)
    Private mtypSecPriorityDetail                   As typSecPriorityDetail         '区間優先詳細情報格納(ｺﾝﾎﾞで選択された分だけ格納)
    Private mtypSecPriorityDetailAll                As typSecPriorityDetail         '区間優先詳細情報格納(親画面で選択されたﾛｯﾄ全部格納)
    Private mlngDispNum                             As Integer                      '表示中のﾛｯﾄ番号
    Private mblnEvantCancelFlag                     As Boolean                      'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ


    '***************************************************************************************
    '                              * コンストラクタの記述 *
    '***************************************************************************************
    '======================================Public===========================================
    ' NSYS 追加
    '関数名：New
    '機　能：コンストラクタ
    '引　数：なし
    '戻り値：なし
    '作成日：2018/12/03 (Mon)
    '更新日：2018/12/03 (Mon)
    '備　考：
    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Form_Load()
        
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：画面起動
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/08 (Mon) 13:04:32 T.Oide
    '更新日：2010/03/08 (Mon) 13:04:32
    '備　考：
    Private Sub Form_Load()
        
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              'ﾛｯﾄ保留理由取得戻り値(True/False)
        Dim lstrMsgCode             As String
        Dim lstrMsg                 As String
        Dim llngCnt                 As Integer
        Dim lngSetObj               As Integer
        
        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面初期化
            Call prvfrmxxEN02I1_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            
            '@ﾛｯﾄｺﾝﾎﾞ設定
            With cmbLotList
                llngCnt = 0
                Do While pstrLotList.Count - 1 >= llngCnt
                    
                    '@ｺﾝﾎﾞﾎﾞｯｸｽにﾘｽﾄ設定
                    .AddItem(pstrLotList(llngCnt) & vbTab & _
                             vbNullString & vbTab & _
                             llngCnt & vbTab & _
                             vbNullString & vbTab & _
                             CMstrCmbCheckOn)                   '@初期選択状態として全選択の状態にする
                    
                    llngCnt = llngCnt + 1
                Loop
                
                mblnEvantCancelFlag = True
                .Text = llngCnt & CMstrAddedComment             '@選択ﾛｯﾄ数表示
                mblnEvantCancelFlag = False
            End With
            
            
            '@区間優先詳細情報取得
            lblnAns = pubblnLotSecPriorityDetail_Sel(pstrSBID, _
                                                     CMstrlot_secPriorityDetailVer, _
                                                     pstrLotList, _
                                                     mtypSecPriorityDetail, _
                                                     lstrMsgCode, _
                                                     lstrMsg)

            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
            
            '@変数初期化
            mlngDispNum = 0
            
            '@全部を退避しておく(後でｺﾝﾎﾞの選択が変更された場合にここから一部をmtypSecPriorityDetailに戻して使用する)
            mtypSecPriorityDetailAll = mtypSecPriorityDetail
            
            '@取得したﾃﾞｰﾀを表示
            For lngSetObj = 0 To 2
                
                '@初期表示は、1番目のデータから表示
                Call pDispDetail(lngSetObj, lngSetObj + 1)

            Next lngSetObj
            
            '@ﾎﾞﾀﾝの有効/無効
            Call pButtonControl()
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑの終了
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2010/03/24 (Wed) 20:08:57 T.Oide
    '更新日：2010/03/24 (Wed) 20:08:57
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '変数初期化
            pstrCFLotID = vbNullString
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/24 (Wed) 20:09:26 T.Oide
    '更新日：2010/03/24 (Wed) 20:09:26
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
            Me.Close()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNext_Click
    '機　能：次の詳細情報を表示する
    '引　数：なし
    '戻り値：
    '作成日：2011/09/26 (Mon) 15:31:32 T.Oide
    '更新日：2011/09/26 (Mon) 15:31:32
    '備　考：
    Private Sub cmdNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNext.Click

        Dim lngSetObj       As Integer

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           
           '@ｸﾞﾘｯﾄﾞを一旦初期化
            Call prvvsfLotTraveler_Init(CMlngZero)
            Call prvvsfLotTraveler_Init(CMlngOne)
            Call prvvsfLotTraveler_Init(CMlngTwo)
           
            '@次の詳細情報を表示する(mlngDispNum に現在表示中のデータ番号が格納されている)
            For lngSetObj = 0 To 2
                
                '@初期表示は、1番目のデータから表示
                Call pDispDetail(lngSetObj, mlngDispNum + 1)

            Next lngSetObj
            
            '@ﾎﾞﾀﾝの有効/無効
            Call pButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNext_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdPrev_Click
    '機　能：前の詳細情報を表示する
    '引　数：なし
    '戻り値：
    '作成日：2011/09/26 (Mon) 15:31:48 T.Oide
    '更新日：2011/09/26 (Mon) 15:31:48
    '備　考：
    Private Sub cmdPrev_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPrev.Click

        Dim lngSetObj       As Integer

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@現在表示中の情報からどこまで戻すか計算
            ' 考え方、3ｸﾞﾘｯﾄﾞ共に表示中なら6戻す
            '         2ｸﾞﾘｯﾄﾞ表示中なら5戻す
            '         1ｸﾞﾘｯﾄﾞ表示中なら4戻す
            If vsfLot0.Rows.Count > CMlngOne And _
               vsfLot1.Rows.Count > CMlngOne And _
               vsfLot2.Rows.Count > CMlngOne Then
                mlngDispNum = mlngDispNum - CMlngSix
            Else
                If vsfLot0.Rows.Count > CMlngOne And _
                   vsfLot1.Rows.Count > CMlngOne Then
                    mlngDispNum = mlngDispNum - CMlngFive
                Else
                    If vsfLot0.Rows.Count > CMlngOne Then
                        mlngDispNum = mlngDispNum - CMlngFour
                    End If
                End If
            End If
            
            '@ｸﾞﾘｯﾄﾞを一旦初期化
            Call prvvsfLotTraveler_Init(CMlngZero)
            Call prvvsfLotTraveler_Init(CMlngOne)
            Call prvvsfLotTraveler_Init(CMlngTwo)
           
            '@前の詳細情報を表示する(mlngDispNum に現在表示中のデータ番号が格納されている)
            For lngSetObj = 0 To 2
                
                '@初期表示は、1番目のデータから表示
                Call pDispDetail(lngSetObj, mlngDispNum + 1)

            Next lngSetObj
            
            '@ﾎﾞﾀﾝの有効/無効
            Call pButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPrev_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbLotList_Change
    '機　能：表示ﾛｯﾄを変更した場合の処理
    '引　数：なし
    '戻り値：
    '作成日：2011/09/26 (Mon) 16:29:26 T.Oide
    '更新日：2011/09/26 (Mon) 16:29:26
    '備　考：
    Private Sub cmbLotList_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotList.Change

        Dim lstrLotList()               As String
        Dim lstrTmpLotId                As Object
        Dim llngCnt                     As Integer
        Dim ltypSecPriorityDetailTmp    As typSecPriorityDetail     '削除用
        Dim llngCnt2                    As Integer
        Dim llngDataCnt                 As Integer
        Dim lngSetObj                   As Integer
        
        '@起動時にはｷｬﾝｾﾙする
        If mblnEvantCancelFlag = True Then
            Exit Sub
        End If
        
        Try
            '@ｸﾞﾘｯﾄﾞを初期化
            Call prvvsfLotTraveler_Init(CMlngZero)
            Call prvvsfLotTraveler_Init(CMlngOne)
            Call prvvsfLotTraveler_Init(CMlngTwo)
            
            '@構造体初期化
            mtypSecPriorityDetail = ltypSecPriorityDetailTmp
            
            '@選択数0の場合終了
            If cmbLotList.Text = CMlngZero & CMstrAddedComment Then
                
                '@表示中のﾃﾞｰﾀ番号初期化
                mlngDispNum = 0
                
                '@ﾎﾞﾀﾝの有効/無効
                Call pButtonControl()
                
                Exit Sub
            End If
            
            '@ｺﾝﾎﾞの選択件数は0より多いか
            If cmbLotList.ValueCount > 0 Then
                
                '@要素数設定
                ReDim Preserve lstrLotList(cmbLotList.ValueCount)
                '@ﾃﾞｰﾀをｺﾝﾎﾞから変数に取得
                lstrTmpLotId = Split(cmbLotList.Value, vbTab)

                'NSYS リスト初期化
                If IsNothing(mtypSecPriorityDetail.SecPriList) Then
                    mtypSecPriorityDetail.SecPriList = New List(Of typSecPriList)
                Else
                    mtypSecPriorityDetail.SecPriList.Clear
                End If
                
                '@取得ﾃﾞｰﾀから個々のﾛｯﾄIDを取得
                llngDataCnt = 1
                For llngCnt = LBound(lstrTmpLotId) To UBound(lstrTmpLotId)
                    
                    lstrLotList(llngCnt + 1) = lstrTmpLotId(llngCnt)
                    
                    '@mtypSecPriorityDetailAllの中から該当ﾛｯﾄを見つける
                    For llngCnt2 = 0 To mtypSecPriorityDetailAll.lngListCnt1 - 1
            
                        If lstrTmpLotId(llngCnt) = mtypSecPriorityDetailAll.SecPriList(llngCnt2).strLotID Then
                            
                            mtypSecPriorityDetail.lngListCnt1 = llngDataCnt
                            mtypSecPriorityDetail.strMsg = mtypSecPriorityDetailAll.strMsg          '多分使わないけど念のためｺﾋﾟｰ
                            mtypSecPriorityDetail.strMsgCode = mtypSecPriorityDetailAll.strMsgCode  '多分使わないけど念のためｺﾋﾟｰ
                            mtypSecPriorityDetail.strSbID = mtypSecPriorityDetailAll.strSbID        '多分使わないけど念のためｺﾋﾟｰ

                            Dim SecPriListTmp As typSecPriList
                            SecPriListTmp = mtypSecPriorityDetailAll.SecPriList(llngCnt2)
                            mtypSecPriorityDetail.SecPriList.Add(SecPriListTmp)

                            llngDataCnt = llngDataCnt + 1
                            Exit For
                        End If
            
                    Next llngCnt2
            
                Next llngCnt
            
            End If
            
            '@移し変えたﾃﾞｰﾀを使ってﾃﾞｰﾀを表示
            mlngDispNum = 0             '初期化
            For lngSetObj = 0 To 2
                
                '@初期表示は、1番目のデータから表示
                Call pDispDetail(lngSetObj, mlngDispNum + 1)

            Next lngSetObj
            

            '@ﾎﾞﾀﾝの有効/無効
            Call pButtonControl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPrev_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvfrmxxEN02I1_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/08 (Mon) 13:06:44 T.Oide
    '更新日：2010/03/08 (Mon) 13:06:44
    '備　考：
    Private Sub prvfrmxxEN02I1_Init()

        Try
            
            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@各ｺﾝﾄﾛｰﾙ初期化
            '@表示ﾛｯﾄ選択ｺﾝﾎﾞ
            With cmbLotList
                .Clear
                .Enabled = True
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                .GridFont =  New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)
                .SelectMode = CMlngOne                          '複数選択モード
                .AddedComment = CMstrAddedComment               '項目選択を付加する
                .AllSelectButton = True                         '全数選択ﾎﾞﾀﾝ表示
            End With
            
            'ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfLotTraveler_Init(CMlngZero)
            Call prvvsfLotTraveler_Init(CMlngOne)
            Call prvvsfLotTraveler_Init(CMlngTwo)
            
            '@閉じるﾎﾞﾀﾝのValidateｲﾍﾞﾝﾄを解除
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02I1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotTraveler_Init
    '機　能：画面の初期化
    '引　数：lngCnt：
    '戻り値：
    '作成日：2011/09/16 (Fri) 13:05:55 T.Oide
    '更新日：2011/09/16 (Fri) 13:05:55
    '備　考：
    Private Sub prvvsfLotTraveler_Init(ByVal lngCnt As Integer)

        Dim gridObj     As C1FlexGrid
        Dim groupBoxObj As GroupBox
        
        Try
            If lngCnt = CMlngZero Then
                gridObj = vsfLot0
                groupBoxObj = fraLot0
            Else If lngCnt = CMlngOne
                gridObj = vsfLot1
                groupBoxObj = fraLot1
            Else
                gridObj = vsfLot2
                groupBoxObj = fraLot2
            End If

            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With gridObj

                .Redraw = False
            
                '@ｸﾘｱ
                .Clear
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                
                '@ﾏｳｽでｾﾙ範囲選択可
                '.AllowSelection = True
                
                '@行数設定
                .Rows.Count = CMlngOne
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                .SelectionMode = SelectionModeEnum.Cell
                .HighLight = HighLightEnum.Never
                .ScrollBars = ScrollBars.Both
                
                '@一覧表ﾀｲﾄﾙの設定
                .Select(CMlngvsfLotTravelerRowTitle, CMlngvsfLotTravelerColTitle, .Rows.Count - 1, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                  '中央表示
                lFixedStyle.ForeColor = Color.Yellow                                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                   '背景色
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngvsfLotTravelerHFontSize, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)          'ﾌｫﾝﾄｻｲｽﾞ
                lFixedStyle.Trimming = StringTrimming.None                                          'NSYS ヘッダー文字列を省略表示しない
                .Rows(CMlngvsfLotTravelerRowTitle).Height = CMlngvsfLotTravelerHHeight              '高さ
                
                'ﾀｲﾄﾙ,列幅,ｱﾗｲﾒﾝﾄ設定
                .SetData(CMlngvsfLotTravelerRowTitle, CMlngvsfLotTravelerNo, CMstrvsfLotTravelerNoN)                  'No(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotTravelerNo).Width = CMlngvsfLotTravelerNoW                                           'No(幅)
                .Cols(CMlngvsfLotTravelerNo).TextAlign = TextAlignEnum.GeneralCenter                                  'No(ｱﾗｲﾒﾝﾄ)
                
                .SetData(CMlngvsfLotTravelerRowTitle, CMlngvsfLotTravelerOpId, CMstrvsfLotTravelerOpIdN)              '大工程(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotTravelerOpId).Width = CMlngvsfLotTravelerOpIdW                                       '大工程(幅)
                .Cols(CMlngvsfLotTravelerOpId).TextAlign = TextAlignEnum.GeneralCenter                                '大工程(ｱﾗｲﾒﾝﾄ)
                
                .SetData(CMlngvsfLotTravelerRowTitle, CMlngvsfLotTravelerStepId, CMstrvsfLotTravelerStepIdN)          '小工程(ﾀｲﾄﾙ)
                .Cols(CMlngvsfLotTravelerStepId).Width = CMlngvsfLotTravelerStepIdW                                   '小工程(幅)
                .Cols(CMlngvsfLotTravelerStepId).TextAlign = TextAlignEnum.GeneralCenter                              '小工程(ｱﾗｲﾒﾝﾄ)
                
        '@        .Cell(flexcpText, CMlngvsfLotTravelerRowTitle, CMlngvsfLotTravelerPriority) = CMstrvsfLotTravelerPriorityN      '優先度(ﾀｲﾄﾙ)
        '@        .ColWidth(CMlngvsfLotTravelerPriority) = CMlngvsfLotTravelerPriorityW                                           '優先度(幅)
        '@        .ColAlignment(CMlngvsfLotTravelerPriority) = flexAlignGeneralCenter                                             '優先度(ｱﾗｲﾒﾝﾄ)
                
                'NSYS フォーカスの背景色なし
                .Styles.Focus.Clear()
                .Styles.Highlight.Clear()

                .Redraw = True

                '@ﾛｯｸ
                .Enabled = True
                
            End With
            
            '@ﾛｯﾄID表示(ロットID:    優先度：)
            groupBoxObj.Text = CmstrNameLotID & _
                                     CmstrSpace & _
                                     CmstrNameNamePriority
                                     
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfLotTraveler_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：pDispDetail
    '機　能：区間優先情報の詳細を表示
    '引　数：lngObjNum：3つあるｸﾞﾘｯﾄﾞのIndexが渡される
    '　　　：lngDispNum：何番目のﾃﾞｰﾀから表示するか渡される
    '　　　：lngMode：True：次へから起動、False：前へから起動
    '戻り値：
    '作成日：2011/09/26 (Mon) 13:43:01 T.Oide
    '更新日：2011/09/26 (Mon) 13:43:01
    '備　考：
    Private Sub pDispDetail(ByVal lngObjNum As Integer, ByVal lngDispNum As Integer)

        Dim llngCnt             As Integer  'ｶｳﾝﾀ
        Dim llngSecPriority     As Integer
        Dim llngDispRow         As Integer
        Dim gridObj             As C1FlexGrid
        Dim groupBoxObj         As GroupBox

        Try
            If lngObjNum = CMlngZero Then
                gridObj = vsfLot0
                groupBoxObj = fraLot0
            Else If lngObjNum = CMlngOne
                gridObj = vsfLot1
                groupBoxObj = fraLot1
            Else
                gridObj = vsfLot2
                groupBoxObj = fraLot2
            End If

            '@表示データはあるか
            If lngDispNum > mtypSecPriorityDetail.SecPriList.Count Then
                Exit Sub
            End If
            
            '@区間優先詳細表示
            With gridObj

                .Redraw = False
                
                llngSecPriority = 0
                llngCnt = 0
                lngDispNum = lngDispNum - 1
                .Rows.Count = mtypSecPriorityDetail.SecPriList(lngDispNum).lngListCnt2 + 1
                Do While mtypSecPriorityDetail.SecPriList(lngDispNum).lngListCnt2 - 1 >= llngCnt
                    
                    gridObj.SetData(llngCnt + 1, CMlngvsfLotTravelerNo, llngCnt + 1)                        'No
                    
                    gridObj.SetData(llngCnt + 1, CMlngvsfLotTravelerOpId, _
                        mtypSecPriorityDetail.SecPriList(lngDispNum).SecPriDetailList(llngCnt).strOpID)     '大工程
                    
                    gridObj.SetData(llngCnt + 1, CMlngvsfLotTravelerStepId, _
                        mtypSecPriorityDetail.SecPriList(lngDispNum).SecPriDetailList(llngCnt).strStepID)   '小工程
                    
                    '@優先区間はﾋﾟﾝｸ色表示
                    If mtypSecPriorityDetail.SecPriList(lngDispNum).SecPriDetailList(llngCnt).strSecPriority <> vbNullString Then
                        Dim newStyle As CellStyle = gridObj.Styles.Add("CustomStyle_BackColor_CPlngStopLotColor")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngStopLotColor)
                        Dim cellRange As CellRange = gridObj.GetCellRange(llngCnt + 1, CMlngvsfLotTravelerNo, _
                                                                llngCnt + 1, CMlngvsfLotTravelerStepId)
                        cellRange.Style = newStyle                                                          'ﾋﾟﾝｸ表示
                    End If
                    
                    
                    '@流動済み工程は灰色表示
                    If CLng(mtypSecPriorityDetail.SecPriList(lngDispNum).SecPriDetailList(llngCnt).strExecedFlag) = CMlngOne Then
                        Dim newStyle2 As CellStyle = gridObj.Styles.Add("CustomStyle_BackColor_CPlngEnableFalseColor")
                        newStyle2.BackColor = SystemColors.ControlLight
                        Dim cellRange2 As CellRange = gridObj.GetCellRange(llngCnt + 1, CMlngvsfLotTravelerNo, _
                                                                llngCnt + 1, CMlngvsfLotTravelerStepId)
                        cellRange2.Style = newStyle2                                                        '灰色表示
                                                                
                        '@流動済みで優先区間はﾋﾟﾝｸ色表示
                        If mtypSecPriorityDetail.SecPriList(lngDispNum).SecPriDetailList(llngCnt).strSecPriority <> vbNullString Then
                            Dim newStyle As CellStyle = gridObj.Styles.Add("CustomStyle_BackColor_CPlngStopLotColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngStopLotColor)
                            Dim cellRange As CellRange = gridObj.GetCellRange(llngCnt + 1, CMlngvsfLotTravelerNo, _
                                                                    llngCnt + 1, CMlngvsfLotTravelerNo)
                            cellRange.Style = newStyle                                                      'ﾋﾟﾝｸ表示
                        End If
                    End If
                    '※流動済みで区間優先の工程は工程№がピンクで工程は灰色表示となる
                    
                    
                    '@区間優先の値の大きいものを退避(ﾀｲﾄﾙ表示用)
                    If mtypSecPriorityDetail.SecPriList(lngDispNum).SecPriDetailList(llngCnt).strSecPriority <> vbNullString Then
                        If llngSecPriority < CLng(mtypSecPriorityDetail.SecPriList(lngDispNum).SecPriDetailList(llngCnt).strSecPriority) Then
                            llngSecPriority = CLng(mtypSecPriorityDetail.SecPriList(lngDispNum).SecPriDetailList(llngCnt).strSecPriority)
                        
                            '@優先度の高い行を退避(最後に表示させるため)
                            llngDispRow = llngCnt + 1
                        End If
                    End If
                    
                    llngCnt = llngCnt + 1
                    
                Loop
                
                '@区間優先の設定があったか
                If llngSecPriority = 0 Then
                    
                    '@ﾛｯﾄID表示(ロットID:xxxxxxx    優先度：なし)
                    groupBoxObj.Text = CmstrNameLotID & mtypSecPriorityDetail.SecPriList(lngDispNum).strLotID & _
                                                CmstrSpace & _
                                                CmstrNameNamePriority & CmstrNoLotPriority
                    
                Else
                
                    '@ﾛｯﾄID表示(ロットID:xxxxxxx    優先度：x)
                    groupBoxObj.Text = CmstrNameLotID & mtypSecPriorityDetail.SecPriList(lngDispNum).strLotID & _
                                                CmstrSpace & _
                                                CmstrNameNamePriority & llngSecPriority
                End If

                'NSYS ヘッダー行を選択
                .Row = 0
                
                .Redraw = True

                '@有効化
                .Enabled = True
                
                '@優先行表示
                .ShowCell(llngDispRow, CMlngvsfLotTravelerOpId)
                
            End With
            
            '@表示したﾃﾞｰﾀ数を退避
            mlngDispNum = mlngDispNum + 1
           
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "pDispDetail"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：pButtonControl
    '機　能：ﾎﾞﾀﾝの有効/無効をｺﾝﾄﾛｰﾙ
    '引　数：なし
    '戻り値：
    '作成日：2011/09/26 (Mon) 16:25:18 T.Oide
    '更新日：2011/09/26 (Mon) 16:25:18
    '備　考：
    Private Sub pButtonControl()

        Try

            '@次へﾎﾞﾀﾝ
            '@現在表示中のﾃﾞｰﾀ№より構造体のﾃﾞｰﾀが数多くあるか
            If mtypSecPriorityDetail.lngListCnt1 > mlngDispNum Then
                
                cmdNext.Enabled = True
            Else
            
                cmdNext.Enabled = False
            End If


            '@前へﾎﾞﾀﾝ
            '@現在表示中のﾃﾞｰﾀ№より戻せるﾃﾞｰﾀが構造体にあるか
            ' 表示中のﾃﾞｰﾀが4以上なら戻せる
            If mlngDispNum >= CMlngFour Then
                
                cmdPrev.Enabled = True
            Else
            
                cmdPrev.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "pButtonControl"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub



    '***************************************************************************************
    '                              * NSYS 追加　関数 *
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Application_Idle
    '機　能：アイドル時に呼び出される
    '引　数：sender：未使用
    '　　　：e  ：未使用
    '戻り値：なし
    '作成日：2018/12/03 (Mon)
    '更新日：2018/12/03 (Mon)
    '備　考：
    Private Sub Application_Idle(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.buttonProcessing = False
    End Sub

    '関数名：WndProc
    '機　能：Windowsメッセージを処理する
    '引　数：m：Windowsメッセージ
    '戻り値：なし
    '作成日：2019/05/29 (Mon) 12:00:00 NSYS
    '更新日：
    '備　考：
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND         As Integer  = &H0112
        Const WM_CLOSE              As Integer  = &H0010
        Const WM_ENDSESSION         As Integer  = &H0016
        Const SC_MOVE               As Long     = &HF010L
        Const SC_CLOSE              As Long     = &HF060L
        Dim lblnSysCommandScClose   As Boolean  = False  'NSYS コントロールメニュー SC_CLOSE処理時 True
        Dim lblnWMClose             As Boolean  = False  'NSYS WM_CLOSE処理時 True
        
        Select Case m.Msg
            Case WM_ENDSESSION
                'OSのシャットダウンで閉じられようとしている場合
                mblnCloseFromControlMenu = True

            Case WM_SYSCOMMAND
                Select Case (m.WParam.ToInt64() And &HFFF0L)
                    Case SC_CLOSE
                        '[×]ボタン、コントロールメニューの「閉じる」、
                        'コントロールボックスのダブルクリック、
                        'Atl+F4などにより閉じられようとしている場合
                        mblnCloseFromControlMenu = True
                        lblnSysCommandScClose = True
                        
                End Select

            Case WM_CLOSE
                'Application.Exit以外で閉じられようとしている場合
                mblnWindowClose = True
                lblnWMClose = True

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
        If lblnWMClose = True Then
            'NSYS WM_CLOSE 処理後 終了がキャンセルされることもあるため、フラグを戻す
            'NSYS 終了処理されれば、すでにこの時点では画面は閉じている
            mblnWindowClose = False
        End If
    End Sub


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLot0.Paint, fraLot1.Paint, fraLot2.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLot0.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        Dim colindex As Integer 'ダブルクリックした列番号

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

            'ダブルクリックした列番号を格納
            colindex = gridObj.HitTest(e.X,e.Y).Column

            'サイズを自動調整
            gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub

    '関数名：cmbLotList_CloseUp
    '機　能：表示ﾛｯﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2020/05/22 (Fri) 21:30:00 NSYS
    '更新日：
    '備　考：
    Private Sub cmbLotList_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotList.CloseUp

        Try
            
            'NSYS 次の項目へﾌｫｰｶｽ移動
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotList_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    
End Class
