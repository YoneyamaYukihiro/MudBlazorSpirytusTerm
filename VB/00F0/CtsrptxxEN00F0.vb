'ﾌｧｲﾙ名：xxEN00F0.Dsr ＜2019/12/25 マイグレ依頼ソース＞
'説　明：在庫管理　送品伝票 印刷ﾌｫｰﾑ
'作成日：2004/11/24 (Wed) 09:00:04 H.Wajima
'更新日：2013/11/19 (Tue) 15:16:16 T.Inafune
'備　考：
'　　　：2005/03/22 (Tue) 08:40:34 S.Deguchi    不具合№637対応で改ﾍﾟｰｼﾞ区切り処理から機種区切りをｺﾒﾝﾄｱｳﾄ
'　　　：2011/08/25 (Thu) 13:38:18 Y.Yoneyama   確認印欄を承認に統一
'　　　：2013/11/19 (Tue) 15:16:48 T.Inafune    仕掛品ｺｰﾄﾞ,Bacchusｵｰﾀﾞ削除（GNS対応）
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit
Imports System.ComponentModel
Imports System.Security.Permissions
Imports C1.Win.FlexViewer
Public Class rptxxEN00F0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As rptxxEN00F0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As rptxxEN00F0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New rptxxEN00F0
            End If
            Return _instance
        End Get
        Set(ByVal value As rptxxEN00F0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

	    ' NSYS 追加
    '関数名：IsInstance
    '機　能：単一インスタンスがインスタンス化されているかどうか確認
    '引　数：なし
    '戻り値：True：インスタンス化されている場合
    '作成日：2019/11/27 (Wed)
    '更新日：2019/11/27 (Wed)
    '備　考：
    Public Shared Function IsInstance() As Boolean
        Return _instance IsNot Nothing
    End Function

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
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyRPTEN00F0 'ﾛｰｶﾙ機能ID

    Private Const CMstrLocalFactoryName         As String = "千歳"				'工場名
	Private Const CMstrAM                       As String = "AM"
	Private Const CMstrPM                       As String = "PM"
	Private Const CMstrA                        As String = "A"
	Private Const CMstrP                        As String = "P"
	Private Const CMstrBrank                    As String = " "
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    Private mtypSendOrderList                   As List(Of SendOrderListData.SendOrderListField) '明細格納構造体
    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean              'NSYS WindowCloseフラグ

    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================

    '*******************************************************************************
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
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/10/31 (Thu) NSYS
    '備　考：
    Private Sub Form_Load()

        Dim lintCnt As Integer  '汎用ｶｳﾝﾀ
        Dim lhMenu  As IntPtr   'ﾒﾆｭｰﾊﾝﾄﾞﾙ

        Try

            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@ｼｽﾃﾑﾒﾆｭｰの設定
            lhMenu = GetSystemMenu(Me.Handle, 0)
            For lintCnt = 0 To 6
                '@ｼｽﾃﾑﾒﾆｭｰの上から項目を削除
                Call DeleteMenu(lhMenu, 0, MF_BYPOSITION)
            Next

            'レポートデータ設定
            prvReport_DataInitialize()

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
    
    '関数名：Form_Shown
    '機　能：ﾌｫｰﾑの表示完了処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/11/01 (Fri) NSYS
    '備　考：
    Private Sub Form_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        Try
            'Viewerのリボン最小化
            viwSendOrderList.ExecuteAction(FlexViewerAction.MinimizeRibbon)

            Exit Sub
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Shown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ ｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/11/29 (Mon) 14:04:07 H.Wajima
    '更新日：2004/12/27 (Mon) 09:48:02 H.Wajima
    '備　考：2004/12/27 (Mon) 09:48:02 H.Wajima  ﾌﾟﾚﾋﾞｭｰ画面のLoad中にｷｬﾝｾﾙﾎﾞﾀﾝを押した場合の不具合対応
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '================================== Public =====================================
    '関数名：pubPrintReport
    '機　能：レポートデータ印刷
    '引　数：なし
    '戻り値：なし
    '作成日：2019/10/31 (Thu) NSYS
    '備　考：
    Public Sub pubPrintReport()
        Try
            If viwSendOrderList.ActionIsEnabled(FlexViewerAction.Print) Then
                ' 印刷実行（ダイアログ非表示）
                viwSendOrderList.DocumentSource.Print()
            End If

            Exit Sub

        Catch ex As Exception
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "pubPrintReport"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
 
    '========================================Private=========================================

    '関数名：prvReport_DataInitialize
    '機　能：レポートデータ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2019/10/31 (Thu) NSYS
    '備　考：
    Private Sub prvReport_DataInitialize()

        Dim llngCnt                                     As Integer              '汎用ｶｳﾝﾀ
        Dim llngCnt2                                    As Integer              '汎用ｶｳﾝﾀ
        Dim llngDataCount                               As Integer              'ﾃﾞｰﾀｶｳﾝﾀ
        Dim llngMaxCount                                As Integer              'ﾙｰﾌﾟ上限
        Dim llngSendDateLen                             As Integer              '日付
        Dim lstrSendDate                                As String               '日付
		Dim lstrSendAMPM								As String				'日付(AMPM)
        Dim lblnPageFlag                                As Boolean              'ﾍﾟｰｼﾞﾌﾗｸﾞ(True:ｶｳﾝﾄｱｯﾌﾟ/False:そのまま)
        Dim llngPageTotal                               As Integer              'ﾍﾟｰｼﾞﾄｰﾀﾙ
        Dim ltypSendOrderList                           As List(Of SendOrderListData.SendOrderListField)
        Dim record                                      As SendOrderListData    'NSYS DataSource RecordSet

        Try
            '@ﾚﾎﾟｰﾄ構造体初期化
            ltypSendOrderList = New List(Of SendOrderListData.SendOrderListField)()
            If IsNothing(mtypSendOrderList) Then
                mtypSendOrderList = New List(Of SendOrderListData.SendOrderListField)()
            Else
                mtypSendOrderList.Clear()
            End If
            record = New SendOrderListData()
            record.Clear()
    
            '@ﾃﾞｰﾀｶｳﾝﾀ初期化
            llngDataCount = 0
            llngPageTotal = 0

            '@印刷ﾃﾞｰﾀを処理する
            '@第1段階：ﾍﾟｰｼﾞ/ﾍﾟｰｼﾞﾄｰﾀﾙを設定する
            With ptypGetSendOrderList
                For llngCnt = 0 To ptypGetSendOrderList.lngLotListCount - 1
                    Dim tmpElem As SendOrderListData.SendOrderListField = New SendOrderListData.SendOrderListField()
                    
                    '@初期化
                    lblnPageFlag = False
            

                    '@日付表記
                    llngSendDateLen = Len(.typLotList(llngCnt).strSendDate)                                     '長さ取得
                    lstrSendDate = Strings.Left(.typLotList(llngCnt).strSendDate, llngSendDateLen - 1)          '日付だけ抽出
                    If IsDate(lstrSendDate) Then
                        lstrSendDate = Format(CDate(lstrSendDate), CPstrDateTimeYMD)                            'ﾌｫｰﾏｯﾄ変更
                    End If
					lstrSendAMPM = Strings.Right(.typLotList(llngCnt).strSendDate, 1)                           'A/Pだけ抽出
					If lstrSendAMPM = CMstrA Then                                                               '文字列選択(AM/PM)
						lstrSendAMPM = CMstrBrank & CMstrAM
					Else
						lstrSendAMPM = CMstrBrank & CMstrPM
					End If
					lstrSendDate = lstrSendDate & lstrSendAMPM

                    '@ﾍｯﾀﾞ情報
                    tmpElem.strSBName = .typLotList(llngCnt).strSBName                 '送品元
                    tmpElem.strSendSBName = .typLotList(llngCnt).strSendSBName         '送品先
					tmpElem.strEmpName = .typLotList(llngCnt).strEmpName			   '送品担当
                    tmpElem.strSendDate = lstrSendDate                                 '送品日
                    'tmpElem.strAtlasPoint = .typLotList(llngCnt).strAtlasPoint         '送品元ERPﾎﾟｲﾝﾄ
                    'tmpElem.strSendAtlasPoint = .typLotList(llngCnt).strSendAtlasPoint '送品先ERPﾎﾟｲﾝﾄ
            
                    '@明細情報
                    tmpElem.strLotId = .typLotList(llngCnt).strLotId                   'ﾛｯﾄID
                    tmpElem.strBoxNo = .typLotList(llngCnt).strBoxNo                   '箱№
                    tmpElem.strFlowClass = .typLotList(llngCnt).strFlowClass           '種別
                    tmpElem.strWFQuantity = .typLotList(llngCnt).strWFQuantity         'WF
                    tmpElem.strChipQuantity = .typLotList(llngCnt).strChipQuantity     'Chip
                    tmpElem.strPdId = .typLotList(llngCnt).strPdId                     '機種
                    'tmpElem.strExtPartCode = .typLotList(llngCnt).strExtPartCode       '仕掛品ｺｰﾄﾞ
                    'tmpElem.strAtlasOrderNo = .typLotList(llngCnt).strAtlasOrderNo     'ERPｵｰﾀﾞｰ№
                    tmpElem.strInvComments = .typLotList(llngCnt).strInvComments       '次SB連絡
            
                    '@最初の1件目の場合
                    If llngCnt = 0 Then
                        '@No.ｾｯﾄ
                        tmpElem.intNo = llngDataCount + 1
                        '@ﾍﾟｰｼﾞｶｳﾝﾄ
                        tmpElem.intPageCount = 1
                        '@ﾍﾟｰｼﾞﾄｰﾀﾙ
                        tmpElem.intPageTotal = 1
                        '@ﾍﾟｰｼﾞﾄｰﾀﾙｶｳﾝﾄｱｯﾌﾟ
                        llngPageTotal = 1
                    Else
                        '@改ﾍﾟｰｼﾞ設定@**************************************************
                        '@送品先
                        If ltypSendOrderList(llngDataCount - 1).strSendSBName <> tmpElem.strSendSBName Then
                            '@ﾍﾟｰｼﾞｶｳﾝﾄﾌﾗｸﾞ
                            lblnPageFlag = True
                        Else
							'@担当者
							If ltypSendOrderList(llngDataCount - 1).strEmpName <> tmpElem.strEmpName Then
								'@担当者が異なる場合ﾍﾟｰｼﾞｶｳﾝﾄｱｯﾌﾟ
								lblnPageFlag = True
							Else
								'@日付が同じか否かで処理分岐
								If tmpElem.strSendDate = ltypSendOrderList(llngDataCount - 1).strSendDate Then
								'@同じ場合
									'@ﾍﾟｰｼﾞｶｳﾝﾄﾌﾗｸﾞ
									lblnPageFlag = False
								Else
									'@ﾍﾟｰｼﾞｶｳﾝﾄﾌﾗｸﾞ
									lblnPageFlag = True
								End If
							End If
                        End If
                        '@改ﾍﾟｰｼﾞ設定@**************************************************
                
                        '@ﾍﾟｰｼﾞｶｳﾝﾄﾌﾗｸﾞによるﾍﾟｰｼﾞ設定
                        If lblnPageFlag = True Then
                        '@ﾌﾗｸﾞが立っている場合
                            '@ﾍﾟｰｼﾞｶｳﾝﾄｱｯﾌﾟ
                            tmpElem.intPageCount = ltypSendOrderList(llngDataCount - 1).intPageCount + 1
                        
                            '@ﾍﾟｰｼﾞｶｳﾝﾄｱｯﾌﾟにより№を初期化
                            tmpElem.intNo = (tmpElem.intPageCount - 1) * 10 + 1
                    
                            '@ﾍﾟｰｼﾞﾄｰﾀﾙｶｳﾝﾄｱｯﾌﾟ
                            llngPageTotal = llngPageTotal + 1
                        Else
                        '@ﾌﾗｸﾞが立っていない場合
                            '@ﾍﾟｰｼﾞｶｳﾝﾄそのままで№をｶｳﾝﾄｱｯﾌﾟ
                            tmpElem.intNo = ltypSendOrderList(llngDataCount - 1).intNo + 1
                    
                            '@№を10件区切りで表示する為の処理
                            Select Case tmpElem.intNo Mod 10
                                Case 0
                                '@10件区切りで余が"0"の場合
                                    '@ﾍﾟｰｼﾞｶｳﾝﾄそのまま
                                    tmpElem.intPageCount = ltypSendOrderList(llngDataCount - 1).intPageCount
                            
                                    '@ﾍﾟｰｼﾞﾄｰﾀﾙｶｳﾝﾄそのまま
                                    llngPageTotal = llngPageTotal
                        
                                Case 1
                                '@10件区切りで余が"1"の場合
                                    '@ﾍﾟｰｼﾞｶｳﾝﾄｱｯﾌﾟ
                                    tmpElem.intPageCount = ltypSendOrderList(llngDataCount - 1).intPageCount + 1
                    
                                    '@ﾍﾟｰｼﾞﾄｰﾀﾙｶｳﾝﾄｱｯﾌﾟ
                                    llngPageTotal = llngPageTotal + 1
                        
                                Case Else
                                '@上記以外
                                    '@ﾍﾟｰｼﾞｶｳﾝﾄそのまま
                                    tmpElem.intPageCount = ltypSendOrderList(llngDataCount - 1).intPageCount
                            
                                    '@ﾍﾟｰｼﾞﾄｰﾀﾙｶｳﾝﾄそのまま
                                    llngPageTotal = llngPageTotal
                            End Select
                        End If
                    End If
                    '@ｶｳﾝﾄｱｯﾌﾟ
                    llngDataCount = llngDataCount + 1
                    '@ﾘｽﾄに追加
                    ltypSendOrderList.Add(tmpElem)
                Next llngCnt
            End With
    
            '@ﾓｼﾞｭｰﾙ変数へ格納
            '@最終的なMaxﾘｽﾄｶｳﾝﾄ
            llngMaxCount = llngPageTotal * 10
    
            '@№の設定
            For llngCnt = 0 To llngMaxCount - 1
                Dim tmpElem As SendOrderListData.SendOrderListField = New SendOrderListData.SendOrderListField()
                tmpElem.intNo = llngCnt + 1
                tmpElem.intPageTotal = llngPageTotal
                mtypSendOrderList.Add(tmpElem)
            Next llngCnt
    
            '@空行の設定も含めて構造体を作成する
            For llngCnt = 0 To llngMaxCount - 1
                Dim tmpElem As SendOrderListData.SendOrderListField = mtypSendOrderList(llngCnt)
                For llngCnt2 = 0 To llngDataCount - 1
                    '@ﾓｼﾞｭｰﾙ構造体とﾛｰｶﾙ構造体で同じ番号のﾃﾞｰﾀを検索
                    If mtypSendOrderList(llngCnt).intNo = ltypSendOrderList(llngCnt2).intNo Then
                    '@ﾛｰｶﾙ情報をﾓｼﾞｭｰﾙ構造体へｾｯﾄする
                        '@ﾍｯﾀﾞの情報
                        tmpElem.strSBName = CMstrLocalFactoryName & ltypSendOrderList(llngCnt2).strSBName         '送品元
                        tmpElem.strSendSBName = ltypSendOrderList(llngCnt2).strSendSBName '送品先
                        tmpElem.strEmpName = ltypSendOrderList(llngCnt2).strEmpName                  '送品担当者
                        tmpElem.strSendDate = ltypSendOrderList(llngCnt2).strSendDate                '送品日
                        'tmpElem.strAtlasPoint = ltypSendOrderList(llngCnt2).strAtlasPoint            '送品元ATLASﾎﾟｲﾝﾄ
                        'tmpElem.strSendAtlasPoint = ltypSendOrderList(llngCnt2).strSendAtlasPoint    '送品先ATLASﾎﾟｲﾝﾄ
                
                        '@明細部
                        tmpElem.strLotId = ltypSendOrderList(llngCnt2).strLotId                      'ﾛｯﾄID
                        tmpElem.strBoxNo = ltypSendOrderList(llngCnt2).strBoxNo                      '箱№
        '@↓2006/03/27 (Mon) 12:43:53 N.Kojima **************************************************
                        tmpElem.strFlowClass = ltypSendOrderList(llngCnt2).strFlowClass              '種別
        '@↑2006/03/27 (Mon) 12:43:53 N.Kojima **************************************************
                        tmpElem.strWFQuantity = ltypSendOrderList(llngCnt2).strWFQuantity            'WF
                        tmpElem.strChipQuantity = ltypSendOrderList(llngCnt2).strChipQuantity        'Chip
                        tmpElem.strPDID = ltypSendOrderList(llngCnt2).strPDID                        '機種
                        tmpElem.strPDIDd = ltypSendOrderList(llngCnt2).strPDID                       '機種表示用
                        'tmpElem.strExtPartCode = ltypSendOrderList(llngCnt2).strExtPartCode          '仕掛品ｺｰﾄﾞ
                        'tmpElem.strAtlasOrderNo = ltypSendOrderList(llngCnt2).strAtlasOrderNo        'ATLASｵｰﾀﾞｰ№
                        If ltypSendOrderList(llngCnt2).strInvComments <> vbNullString Then          '次SB連絡
                            tmpElem.strInvComments = CPstrAriFlg
                        Else
                            tmpElem.strInvComments = vbNullString
                        End If
                        tmpElem.intPageCount = ltypSendOrderList(llngCnt2).intPageCount              'ﾍﾟｰｼﾞｶｳﾝﾄ
                
                        '@ﾛｰｶﾙ側ﾙｰﾌﾟを抜ける
                        Exit For
                    End If
                Next llngCnt2
        
                '@ﾛｰｶﾙ側ﾙｰﾌﾟが終了して送品元名称が空欄の場合,前情報を引継いでﾛｯﾄIDには空欄をｾｯﾄする
                If tmpElem.strSBName = vbNullString Then
                    '@ﾍｯﾀﾞの情報
                    tmpElem.strSBName = mtypSendOrderList(llngCnt - 1).strSBName                     '送品元
                    tmpElem.strSendSBName = mtypSendOrderList(llngCnt - 1).strSendSBName             '送品先
                    tmpElem.strEmpName = mtypSendOrderList(llngCnt - 1).strEmpName                   '送品担当者
                    tmpElem.strSendDate = mtypSendOrderList(llngCnt - 1).strSendDate                 '送品日
                    'tmpElem.strAtlasPoint = mtypSendOrderList(llngCnt - 1).strAtlasPoint             '送品元ATLASﾎﾟｲﾝﾄ
                    'tmpElem.strSendAtlasPoint = mtypSendOrderList(llngCnt - 1).strSendAtlasPoint     '送品先ATLASﾎﾟｲﾝﾄ
                    tmpElem.strPDID = mtypSendOrderList(llngCnt - 1).strPDID                         '機種
            
                    '@明細部
                    tmpElem.strLotId = vbNullString                                                  'ﾛｯﾄID
                    tmpElem.strBoxNo = vbNullString                                                  '箱№
        '@↓2006/03/27 (Mon) 12:44:33 N.Kojima **************************************************
                    tmpElem.strFlowClass = vbNullString                                              '種別
        '@↑2006/03/27 (Mon) 12:44:33 N.Kojima **************************************************
                    tmpElem.strWFQuantity = vbNullString                                             'WF
                    tmpElem.strChipQuantity = vbNullString                                           'Chip
                    tmpElem.strPdIdd = vbNullString                                                  '機種表示用
                    'tmpElem.strExtPartCode = vbNullString                                            '仕掛品ｺｰﾄﾞ
                    'tmpElem.strAtlasOrderNo = vbNullString                                           'ATLASｵｰﾀﾞｰ№
                    tmpElem.strInvComments = vbNullString                                            '次SB連絡
                    tmpElem.intPageCount = mtypSendOrderList(llngCnt - 1).intPageCount               'ﾍﾟｰｼﾞｶｳﾝﾄ
                End If
                mtypSendOrderList(llngCnt) = tmpElem
            Next llngCnt

            'ﾚﾎﾟｰﾄ表示ﾃﾞｰﾀをRecordSetに設定
            For Each elm As SendOrderListData.SendOrderListField In mtypSendOrderList
                record.Add(elm)
            Next

            'ﾚﾎﾟｰﾄにRecordSetを設定
            rptSendOrderList.DataSource.Recordset = record

            'ViewerにReportを設定
            viwSendOrderList.DocumentSource = rptSendOrderList

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvReport_DataInitialize"
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
        Dim lblnSysCommandScClose   As Boolean = False  'NSYS コントロールメニュー SC_CLOSE処理時 True

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

                    Case SC_MOVE
                        'フォームの移動を無効化する
                        m.Result = IntPtr.Zero
                        Return
                End Select

            Case WM_CLOSE
                'Application.Exit以外で閉じられようとしている場合
                mblnWindowClose = True

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
    End Sub

End Class