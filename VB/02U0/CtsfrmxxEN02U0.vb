Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02U0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    Private Shared _instance As frmxxEN02U0

    '***************************************************************************************
    '                              * Sharedプロパティの記述 *
    '***************************************************************************************
    '======================================Public===========================================
    ''' <summary>
    ''' ただ一つのフォームにアクセスするためのプロパティ
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property Instance() As frmxxEN02U0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02U0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02U0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '機能バージョン
	'kkw 投入方法変更
    Private Const CMstrLocalVersion                         As String = "02.00"  '"01.01"
    
    'ローカル機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN02U0

    'メッセージバージョン
    Private Const CPstrasm_odftftcflistVer                  As String = "01.00"         'ODF予約可能なTFT機種とその対向基板機種の一覧を取得
    Private Const CPstrasm_odfreservelistVer                As String = "01.00"         'ODF予約可能一覧
    Private Const CPstrasm_odfreserveregistVer              As String = "01.00"         'ODF予約登録
    Private Const CPstrasm_odfreservereinfoVer              As String = "01.00"         'ODF予約情報
    Private Const CPstrasm_hreserveinfoVer                  As String = "01.00"         '表面処理予約情報
    Private Const CPstrasm_hreserveregistVer                As String = "01.00"         '表面処理予約登録
	Private Const CMstrlot_curstateVer						As String = "04.00"         'ﾛｯﾄ現在状態取得
	Private Const CMstrlot_waferlistVer						As String = "02.05"         'ﾛｯﾄWF情報取得(新)
	Private Const CMstrlot_afterjrsvdetailVer				As String = "01.00"         '蒸着後流動予約情報詳細取得
	Private Const CMstrlot_afterjrsvlistVer					As String = "01.00"         '蒸着後流動予約情報一覧取得
	Private Const CMstrlot_afterjrsvregistVer				As String = "01.00"         '蒸着後流動予約情報登録
	Private Const CMstrcarrcurstateVer						As String = "05.02"         'ｷｬﾘｱ状態確認

    'コンボ配列(PdId/PdVer/CfPdId/CfPdVer/ForeColor/BackColor)
    Private Const CMintCmbPdId                              As Integer = 1
    Private Const CMintCmbPdVer                             As Integer = 2
    Private Const CMintCmbCfPdId                            As Integer = 3
    Private Const CMintCmbCfPdVer                           As Integer = 4
    Private Const CMintCmbBackColor                         As Integer = 5

    'ODF予約(ロット一覧)
    Private Const CMlngvsfReserveNo                         As Integer = 0
    Private Const CMlngvsfReserveStat                       As Integer = 1               
    Private Const CMlngvsfReserveStatName                   As Integer = 2            
    Private Const CMlngvsfReservePdId                       As Integer = 3               
    Private Const CMlngvsfReserveLotId                      As Integer = 4              
    Private Const CMlngvsfReserveWfId                       As Integer = 5               
    Private Const CMlngvsfReserveCarrierId                  As Integer = 6          
    Private Const CMlngvsfReserveFlowClass                  As Integer = 7          
    Private Const CMlngvsfReserveSlotPos                    As Integer = 8            
    Private Const CMlngvsfReserveFlag                       As Integer = 9               
    Private Const CMlngvsfReserveWfes                       As Integer = 10               

    Private Const CMstrvsfReserveNoT                        As String = "№" 
    Private Const CMstrvsfReserveStatT                      As String = "CurrentStatus"       
    Private Const CMstrvsfReserveStatNameT                  As String = "状態"        
    Private Const CMstrvsfReservePdIdT                      As String = "機種"         
    Private Const CMstrvsfReserveLotIdT                     As String = "ﾛｯﾄID"        
    Private Const CMstrvsfReserveWfIdT                      As String = "WFID"     
    Private Const CMstrvsfReserveCarrierIdT                 As String = "ｷｬﾘｱID"        
    Private Const CMstrvsfReserveFlowClassT                 As String = "種別"        
    Private Const CMstrvsfReserveSlotPosT                   As String = "SlotPosition"          
    Private Const CMstrvsfReserveFlagT                      As String = "ReserveFlag"          
    Private Const CMstrvsfReserveWfesT                      As String = "WaferesStr"          

    Private Const CMlngvsfReserveNoW                        As Integer = 30
    Private Const CMlngvsfReserveStatW                      As Integer = 30               
    Private Const CMlngvsfReserveStatNameW                  As Integer = 75            
    Private Const CMlngvsfReservePdIdW                      As Integer = 60               
    Private Const CMlngvsfReserveLotIdW                     As Integer = 90              
    Private Const CMlngvsfReserveWfIdW                      As Integer = 150               
    Private Const CMlngvsfReserveCarrierIdW                 As Integer = 70          
    Private Const CMlngvsfReserveFlowClassW                 As Integer = 30          
    Private Const CMlngvsfReserveSlotPosW                   As Integer = 100            
    Private Const CMlngvsfReserveFlagW                      As Integer = 30  
    Private Const CMlngvsfReserveWfesW                      As Integer = 30  

    'ODF予約(WF一覧)
    Private Const CMlngvsfWfReserveSlot                     As Integer = 0
    Private Const CMlngvsfWfReserveId                       As Integer = 1               
    Private Const CMlngvsfWfReserveId2                      As Integer = 2                          

    Private Const CMstrvsfWfReserveTSlot                    As String = ""        
    Private Const CMstrvsfWfReserveTId                      As String = "WFID"     
    Private Const CMstrvsfWfReserveTId2                     As String = ""           

    Private Const CMlngvsfWfReserveWSlot                    As Integer = 20            
    Private Const CMlngvsfWfReserveWId                      As Integer = 100               
    Private Const CMlngvsfWfReserveWId2                     As Integer = 30               

    '予約状態
    Private Const CMstrReserveDone                          As String = "登録済"
    Private Const CMstrReserveSelect                        As String = "選択中"

    'ODF予約一覧
    Private Const CMlngvsfInfoNo                            As Integer = 0
    Private Const CMlngvsfInfoUpdateTime                    As Integer = 1  
    Private Const CMlngvsfInfoTFTLotId                      As Integer = 2               
    Private Const CMlngvsfInfoTFTCarrier                    As Integer = 3               
    Private Const CMlngvsfInfoTFTSlot                       As Integer = 4               
    Private Const CMlngvsfInfoTFTWfId                       As Integer = 5               
    Private Const CMlngvsfInfoCFWfId                        As Integer = 6               
    Private Const CMlngvsfInfoCFSlot                        As Integer = 7               
    Private Const CMlngvsfInfoCFCarrier                     As Integer = 8               
    Private Const CMlngvsfInfoCFLotId                       As Integer = 9               
    Private Const CMlngvsfInfoEmpName                       As Integer = 10               
             
    Private Const CMstrvsfInfoNoT                           As String = "№"
    Private Const CMstrvsfInfoUpdateTimeT                   As String = "予約日" 
    Private Const CMstrvsfInfoTFTLotIdT                     As String = "ﾛｯﾄID"       
    Private Const CMstrvsfInfoTFTCarrierT                   As String = "ｷｬﾘｱID"        
    Private Const CMstrvsfInfoTFTSlotT                      As String = "SL"         
    Private Const CMstrvsfInfoTFTWfIdT                      As String = "WFID"        
    Private Const CMstrvsfInfoCFWfIdT                       As String = "WFID"     
    Private Const CMstrvsfInfoCFSlotT                       As String = "SL"     
    Private Const CMstrvsfInfoCFCarrierT                    As String = "ｷｬﾘｱID"     
    Private Const CMstrvsfInfoCFLotIdT                      As String = "ﾛｯﾄID"     
    Private Const CMstrvsfInfoEmpNameT                      As String = "予約者"     
    
    Private Const CMlngvsfInfoNoW                           As Integer = 30
    Private Const CMlngvsfinfoUpdateTimeW                   As Integer = 60   
    Private Const CMlngvsfInfoTFTLotIdW                     As Integer = 30               
    Private Const CMlngvsfInfoTFTCarrierW                   As Integer = 30                             
    Private Const CMlngvsfInfoTFTSlotW                      As Integer = 30               
    Private Const CMlngvsfInfoTFTWfIdW                      As Integer = 30
    Private Const CMlngvsfInfoCFWfIdW                       As Integer = 30    
    Private Const CMlngvsfInfoCFSlotW                       As Integer = 30               
    Private Const CMlngvsfInfoCFCarrierW                    As Integer = 30                             
    Private Const CMlngvsfInfoCFLotIdW                      As Integer = 30               
    Private Const CMlngvsfInfoEmpNameW                      As Integer = 60            
            
    '表面処理群予約
    Private Const CMlngvsfHInfoNo                           As Integer = 0
    Private Const CMlngvsfHInfoCheckBox                     As Integer = 1
    Private Const CMlngvsfHInfoReserveTime                  As Integer = 2
    Private Const CMlngvsfHInfoCurTFTCarrierId              As Integer = 3
    Private Const CMlngvsfHInfoTFTLotId                     As Integer = 4
    Private Const CMlngvsfHInfoCurTFTLotId                  As Integer = 5
    Private Const CMlngvsfHInfoTFTWfId                      As Integer = 6
    Private Const CMlngvsfHInfoTFTWfQty                     As Integer = 7
    Private Const CMlngvsfHInfoTFTWfes                      As Integer = 8
    Private Const CMlngvsfHInfoCurCFCarrierId               As Integer = 9
    Private Const CMlngvsfHInfoCFLotId                      As Integer = 10
    Private Const CMlngvsfHInfoCurCFLotId                   As Integer = 11
    Private Const CMlngvsfHInfoCFWfId                       As Integer = 12
    Private Const CMlngvsfHInfoCfWfQty                      As Integer = 13
    Private Const CMlngvsfHInfoCFWfes                       As Integer = 14
    Private Const CMlngvsfHInfoTotalWfQty                   As Integer = 15
    Private Const CMlngvsfHInfoRecipeId                     As Integer = 16
    Private Const CMlngvsfHInfoEditTime                     As Integer = 17
    Private Const CMlngvsfHInfoReserveEmpName               As Integer = 18
    
    Private Const CMstrvsfHInfoNoT                          As String = "№"
    Private Const CMstrvsfHInfoCheckBoxT                    As String = "" 
    Private Const CMstrvsfHInfoTFTWfIdT                     As String = "WFID"   
    Private Const CMstrvsfHInfoTFTLotIdT                    As String = "ODF予約ﾛｯﾄID"   
    Private Const CMstrvsfHInfoCurTFTLotIdT                 As String = "ﾛｯﾄID"      
    Private Const CMstrvsfHInfoCFWfIdT                      As String = "WFID"        
    Private Const CMstrvsfHInfoCFLotIdT                     As String = "ODF予約ﾛｯﾄID"        
    Private Const CMstrvsfHInfoCurCfLotIdT                  As String = "ﾛｯﾄID"           
    Private Const CMstrvsfHInfoEditTimeT                    As String = "更新日" 
    Private Const CMstrvsfHInfoReserveTimeT                 As String = "予約日" 
    Private Const CMstrvsfHInfoReserveEmpNameT              As String = "予約者"  
    Private Const CMstrvsfHInfoRecipeIdT                    As String = "表面処理" + vbCrLf + "ﾚｼﾋﾟ"  
    Private Const CMstrvsfHInfoTFTWfQtyT                    As String = "数"  
    Private Const CMstrvsfHInfoCFWfQtyT                     As String = "数"  
    Private Const CMstrvsfHInfoTotalWfQtyT                  As String = "合計" + vbCrLf + "WF数"
    Private Const CMstrvsfHInfoCurTFTCarrierIdT             As String = "ｷｬﾘｱID"
    Private Const CMstrvsfHInfoCurCFCarrierIdT              As String = "ｷｬﾘｱID"
    Private Const CMstrvsfHInfoTFTWfesT                     As String = "TFTWaferesStr"
    Private Const CMstrvsfHInfoCFWfesT                      As String = "CFWaferesStr"

    Private Const CMlngvsfHInfoNoW                          As Integer = 30
    Private Const CMlngvsfHInfoCheckBoxW                    As Integer = 30
    Private Const CMlngvsfHInfoTFTWfIdW                     As Integer = 60    
    Private Const CMlngvsfHInfoTFTLotIdW                    As Integer = 60
    Private Const CMlngvsfHInfoCurTFTLotIdW                 As Integer = 60
    Private Const CMlngvsfHInfoCFWfIdW                      As Integer = 60  
    Private Const CMlngvsfHInfoCFLotIdW                     As Integer = 60       
    Private Const CMlngvsfHInfoCurCFLotIdW                  As Integer = 60
    Private Const CMlngvsfHInfoEditTimeW                    As Integer = 60
    Private Const CMlngvsfHInfoReserveTimeW                 As Integer = 60           
    Private Const CMlngvsfHInfoReserveEmpNameW              As Integer = 60  
    Private Const CMlngvsfHInfoRecipeW                      As Integer = 60  
    Private Const CMlngvsfHInfoTFTWfQtyW                    As Integer = 60  
    Private Const CMlngvsfHInfoCFWfQtyW                     As Integer = 60
    Private Const CMlngvsfHInfoTotalWfQtyW                  As Integer = 60
    Private Const CMlngvsfHInfoCurTFTCarrierIdW             As Integer = 60
    Private Const CMlngvsfHInfoCurCFCarrierIdW              As Integer = 60
    Private Const CMlngvsfHInfoTFTWfesW                     As Integer = 60
    Private Const CMlngvsfHInfoCFWfesW                      As Integer = 60

	
	'蒸着後流動予約(元WFスロットマップ)
    Private Const CMlngvsfSlotMapSlotNo                     As Integer = 0	'スロットNo
    Private Const CMlngvsfSlotMapWfId                       As Integer = 1	'ウェハID
	Private Const CMlngvsfSlotMapBNo						As Integer = 2  '通し番号
    Private Const CMlngvsfSlotMapResId						As Integer = 3  '予約ID   
    Private Const CMlngvsfSlotMapGroup                      As Integer = 4  '予約グループ       
    Private Const CMlngvsfSlotMapSlotPosition				As Integer = 5  '予約スロットポジション        
    Private Const CMlngvsfSlotMapCarrierId                  As Integer = 6  '予約キャリアID

    Private Const CMstrvsfSlotMapSlotNoT                    As String = vbNullString 
    Private Const CMstrvsfSlotMapWfIdT                      As String = "WF_ID"       
    Private Const CMstrvsfSlotMapResIdT						As String = "予約ID"        
    Private Const CMstrvsfSlotMapGroupT                     As String = "グループ"         
    Private Const CMstrvsfSlotMapSlotPositionT              As String = "スロット"        
    Private Const CMstrvsfSlotMapCarrierIdT                 As String = "キャリアID"     
    Private Const CMstrvsfSlotMapBNoT						As String = "通し番号"      

    Private Const CMlngvsfSlotMapSlotNoW                    As Integer = 19
    Private Const CMlngvsfSlotMapWfIdW                      As Integer = 88               
    Private Const CMlngvsfSlotMapResIdW						As Integer = 45            
    Private Const CMlngvsfSlotMapGroupW                     As Integer = 30               
    Private Const CMlngvsfSlotMapSlotPositionW              As Integer = 30              
    Private Const CMlngvsfSlotMapCarrierIdW                 As Integer = 30
	Private Const CMlngvsfSlotMapBNoW						As Integer = 19   
	
	'蒸着後流動予約(予約グループA)
    Private Const CMlngvsfToSlotMap1SlotNo                     As Integer = 0
    Private Const CMlngvsfToSlotMap1WfId                       As Integer = 1
	Private Const CMlngvsfToSlotMap1BNo						   As Integer = 2 '通し番号
                   
    Private Const CMstrvsfToSlotMap1SlotNoT                    As String = vbNullString
    Private Const CMstrvsfToSlotMap1WfIdT                      As String = "WF_ID"       
	Private Const CMstrvsfToSlotMap1BNoT					   As String = "通し番号"

    Private Const CMlngvsfToSlotMap1SlotNoW                    As Integer = 19
    Private Const CMlngvsfToSlotMap1WfIdW                      As Integer = 88
	Private Const CMlngvsfToSlotMap1BNoW					   As Integer = 19

   '蒸着後流動予約(予約グループB)
	Private Const CMlngvsfToSlotMap2SlotNo                     As Integer = 0
    Private Const CMlngvsfToSlotMap2WfId                       As Integer = 1               
    Private Const CMlngvsfToSlotMap2BNo						   As Integer = 2 '通し番号
																			  '
    Private Const CMstrvsfToSlotMap2SlotNoT                    As String = vbNullString 
    Private Const CMstrvsfToSlotMap2WfIdT                      As String = "WF_ID"       
	Private Const CMstrvsfToSlotMap2BNoT					   As String = "通し番号"

    Private Const CMlngvsfToSlotMap2SlotNoW					   As Integer = 19
    Private Const CMlngvsfToSlotMap2WfIdW                      As Integer = 88
	Private Const CMlngvsfToSlotMap2BNoW					   As Integer = 19

	'蒸着後流動予約(予約グループC)
	Private Const CMlngvsfToSlotMap3SlotNo                     As Integer = 0
    Private Const CMlngvsfToSlotMap3WfId                       As Integer = 1               
    Private Const CMlngvsfToSlotMap3BNo						   As Integer = 2 '通し番号
																			  '
    Private Const CMstrvsfToSlotMap3SlotNoT                    As String = vbNullString
    Private Const CMstrvsfToSlotMap3WfIdT                      As String = "WF_ID"       
	Private Const CMstrvsfToSlotMap3BNoT					   As String = "通し番号"

    Private Const CMlngvsfToSlotMap3SlotNoW                    As Integer = 19
    Private Const CMlngvsfToSlotMap3WfIdW                      As Integer = 88
	Private Const CMlngvsfToSlotMap3BNoW					   As Integer = 19

	'蒸着後流動予約(予約グループD)
	Private Const CMlngvsfToSlotMap4SlotNo                     As Integer = 0
    Private Const CMlngvsfToSlotMap4WfId                       As Integer = 1               
    Private Const CMlngvsfToSlotMap4BNo						   As Integer = 2 '通し番号
																			  '
    Private Const CMstrvsfToSlotMap4SlotNoT                    As String = vbNullString 
    Private Const CMstrvsfToSlotMap4WfIdT                      As String = "WF_ID"       
	Private Const CMstrvsfToSlotMap4BNoT					   As String = "通し番号"

    Private Const CMlngvsfToSlotMap4SlotNoW                    As Integer = 19
    Private Const CMlngvsfToSlotMap4WfIdW                      As Integer = 88
	Private Const CMlngvsfToSlotMap4BNoW					   As Integer = 19

	'@vsfSlotMapの定数宣言(その他)
    Private Const CMlngSlotMapRowTitle          As Integer = 0              'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMlngSlotHMaCellFontSize      As Integer = 9             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngSlotMapRowS              As Integer = 26             '行数
    Private Const CMlngSlotMapHHeight           As Integer = 17              'ﾍｯﾀﾞｰの高さ
    Private Const CMlngSlotMapHeight            As Integer = 17             '1ｽﾛｯﾄの高さ
    Private Const CMlngSlotMapSTopRow           As Integer = 16             '初期表示行番号
    Private Const CMlngSlotMapPageRows          As Integer = 10             '1ﾍﾟｰｼﾞ表示行数

	Private Const CMstrGroupA					As String  = "A"			'予約グループA
	Private Const CMstrGroupB					As String  = "B"			'予約グループB
	Private Const CMstrGroupC					As String  = "C"			'予約グループC
	Private Const CMstrGroupD					As String  = "D"			'予約グループD

	Private Const CMstrWpId2MUMASKSET01			As String = "2MUMASKSET01"	'無機マスクセット装置

		
    Private Const CMlngSlotMapSlotNo10Row       As Integer = 16             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
	Private Const CMlngSlotMapSlotNo11Row       As Integer = 15             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№11の行番号
	Private Const CMlngSlotMapSlotNo15Row       As Integer = 11             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№15の行番号
	Private Const CMlngSlotMapSlotNo20Row       As Integer = 6              '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№20の行番号

	'@内部構造体(ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ格納)
    Private Structure SlotPosition
        Dim lngSlotNo                                   As Integer                          'ｽﾛｯﾄ№
        Dim strWfId                                     As String                           'WF_ID
    End Structure

	Private mtypTransfer                            As SlotPosition                          '手動移動時元ｷｬﾘｱ情報格納


    'データ登録種別
    Private Const CMstrRegistTypeIns                        As String = "INSERT"        '登録
    Private Const CMstrRegistTypeDel                        As String = "DELETE"        '削除
    '表面処理検索オプション
    Private Const CMstrSelOptAll                            As String = "ALL"           '全て
    Private Const CMstrSelOptNone                           As String = "NONE"          '予約未
    Private Const CMstrSelOptDone                           As String = "DONE"          '予約済

    '各定数
    Private Const CMlngvsfSlotRows                          As Integer = 26             'SLOT行数
    Private Const CMlngHyoumenMaxCnt                        As Integer = 62             '表面処理の最大枚数

    'TabIndex
    Private Const CMintTab0 As Integer = 0
    Private Const CMintTab1 As Integer = 1
    Private Const CMintTab2 As Integer = 2
	Private Const CMintTab3 As Integer = 3

    'グリッドのタイトル行
    Private Const CMlngvsfGridTitleRow As Integer = 0           'グリッドタイトル行
    Private Const CMlngvsfGridTitleRow2 As Integer = 1          'グリッドタイトル行(2行ある場合)

    '色宣言
    Private Const CMlngEnableFalseForeColor As Integer = &H80000016     '灰色(使用不可)
    Private Const CMlngEnableTrueForeColor As Integer = &H0&            '黒色



    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private ReadOnly vbButtonFace As Color = SystemColors.ControlLight
    Private buttonProcessing As Boolean 'NSYS ボタン2度押し対策
	Private mblnTxtCarrierChange                As Boolean                  '編成元ｷｬﾘｱID変更ﾌﾗｸﾞ
    Private mblnCloseFromControlMenu As Boolean  'NSYS システムコマンドでの画面クローズ
	Private ReadOnly vbWhite                    As Color = Color.White      'NSYS vbWhite定義
    Private ReadOnly vbYellow                   As Color = Color.Yellow     'NSYS vbYellow定義
	Private mstrEventName                       As String                   'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
	Private mstrCurrentWfId						As String
	Private mstrPrevWfId						As String
	Private mstrToCarrier1                    As String                               'ｷｬﾘｱID1退避
    Private mstrToCarrier2                    As String                               'ｷｬﾘｱID2退避
	Private mstrToCarrier3                    As String                               'ｷｬﾘｱID1退避
    Private mstrToCarrier4                    As String                               'ｷｬﾘｱID2退避
	Private mblnTabCarrierMntSelect           As Boolean                  'NSYS タブ切替フラグ
	Private mblnWindowClose                   As Boolean				'NSYS キャリアメンテナンスタブ切替フラグ
	


    '****************************************************************************************
    '                              * コンストラクタの記述 *
    '***************************************************************************************
    '======================================Public===========================================
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
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
    ''' <summary>
    ''' フォーム初期化
    ''' </summary>
    Private Sub Form_Load()

        Dim lblnAns As Boolean
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02U0, CMstrLocalVersion)

            '結果NG
            If lblnAns = False Then
                '@異常終了の場合

                '@=======================
                '@ ﾒﾆｭｰｻｲｽﾞ変更処理
                '@=======================
                Call pubMenuExpand_Disp()

                '@=======================
                '@ ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing,  False))

                Exit Sub
            End If

            'Formタイトルの取得
            Dim lstrFormTitle As String = vbNullString
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02U0, lstrFormTitle)
            Me.Text = lstrFormTitle
            
            '画面表示位置
            Me.Top = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            'TAB初期化
            Call prvTab0_Init       '予約
            Call prvTab1_Init       '予約一覧
            Call prvTab2_Init       '表面処理群予約
			Call prvTab3_Init       '蒸着後流動予約

            '機種コンボ表示
            Call prvcmbTftPdList_Disp()

            fraODF0.Enabled = True
            fraODF1.Enabled = True
            fraODF2.Enabled = True

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()
            
        End Try
    End Sub

    ''' <summary>
    ''' フォームUnload
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm As Boolean
        Dim lintAns As Integer
        
        Try
            
            '登録/解除ボタンが有効の場合
            'ODF予約の解除は参照しているだけと思われるので、判定から外す
            '編集中と判断して閉じる前にユーザー確認
            If cmdRegist.Enabled = True Or _
                cmdHyoumenRegist.Enabled = True Or cmdHyoumenDel.Enabled = True Or cmdReserveJRegist.Enabled = True Then

                '"編集中です。 内容を破棄してよろしいですか？"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                lintAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                'NO
                If lintAns = vbNo Then
                    '編集中のTABを表示
                    If cmdRegist.Enabled = True Or cmdDel.Enabled Then
                        tabODF.SelectedIndex = CMintTab0
                    ElseIf cmdHyoumenRegist.Enabled = True Or cmdHyoumenDel.Enabled = True Then
                        tabODF.SelectedIndex = CMintTab2
					Else If cmdReserveJRegist.Enabled = True
						tabODF.SelectedIndex = CMintTab3
                    End If

                    Call pubSetFocus(cmdClose)
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            '@Windowの"×"にて閉じたか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload

            End If

            '@Act初期化ﾌﾗｸﾞが"True：成功"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合

                '@=======================
                '@ ACTｵﾌﾞｼﾞｪｸﾄの開放
                '@=======================
                lblnAnsTerm = pubblnAct_Term

                '@ACTｵﾌﾞｼﾞｪｸﾄ開放処理が正常に行われたか
                If lblnAnsTerm = True Then

                    '@処理なし(ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了)
                End If
            Else
                '@Actを自前で初期化していない場合

                '@=======================
                '@ ﾒﾆｭｰｻｲｽﾞ変更処理
                '@=======================
                Call pubMenuExpand_Disp()

            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()
            
        End Try
    End Sub

    ''' <summary>
    ''' 終了処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim lintRet As Integer
        Dim ltypCommonInfo  As New CommonInfo

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '共通終了処理
            lintRet = publngEnd_Proc(CPstrKeyEN02U0, ltypCommonInfo)
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()

        End Try
    End Sub


	Private Sub tabOdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabODF.SelectedIndexChanged
		'mblnTabCarrierMntSelect = True


	End Sub


    ''' <summary>
    ''' 機種選択の変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbTFTandCF_CloseUp(sender As Object, e As EventArgs) Handles cmbTFTandCF.CloseUp

        Try
            'コンボ選択後、選択エリアの色を変更
            '何もしないと背景は白になる
            'コンボ配列(PdId/PdVer/CfPdId/CfPdVer/ForeColor/BackColor)
            With cmbTFTandCF
                .ValueCol = CMintCmbBackColor
                If .Value <> vbNullString Then
                    .BackColor = ColorTranslator.FromWin32(Convert.ToInt32(.Value))
                Else
                    .BackColor = Color.White
                End If
                .ValueCol = CMintCmbPdId
            End With

            '最新取得
            Call cmdReserveLotList_Click(sender, e)
            pubSetFocus(cmdReserveLotList)

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbTFTandCF_CloseUp"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' ODF貼り合せ予約(TFTロットリスト選択)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vsfTFTList_Click(sender As Object, e As EventArgs) Handles vsfTFTList.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfTFTList
                'NSYS データ行がない場合は処理を抜ける
                If .Rows.Count <= .Rows.Fixed Then
                    Return
                End If

                'ヘッダー行は処理なし
                If .Row = CMlngvsfGridTitleRow Then
                    Return
                End If

                '[>]無効
                cmdTFTMove.Enabled = False
                cmdCFMove.Enabled = False

                'CFはタイトル行
                vsfCFList.Row = CMlngvsfGridTitleRow

                '予約済み
                If .GetData(.Row, CMlngvsfReserveFlag) = CPstrFlagOn Then
                    
                    '選択中の場合は何もしない
                    If lblReserveStatus.Text = CMstrReserveSelect Then
                        .Row = CMlngvsfGridTitleRow     'タイトル行に行設定
                        Exit Sub
                    End If

                    '予約済の情報取得
                    '引数(TFT,CF)
                    Call prvOdfReserveInfo(.GetData(.Row, CMlngvsfReserveLotId), vbNullString)
                    Exit Sub

                Else
                    '予約済の場合
                    If lblReserveStatus.Text = CMstrReserveDone Then
                        'WFリストclear
                        Call prvOdfReserveInfoClear()
                    End If
                End If

                'TFTロット選択済み
                If lblTFTLotId.Text <> vbNullString Then
                    Exit Sub
                End If

                '[>]有効
                cmdTFTMove.Enabled = True

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfTFTList_Click"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' ODF貼り合せ予約(CFロットリスト選択)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vsfCFList_Click(sender As Object, e As EventArgs) Handles vsfCFList.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfCFList
                'NSYS データ行がない場合は処理を抜ける
                If .Rows.Count <= .Rows.Fixed Then
                    Return
                End If

                'ヘッダー行は処理なし
                If .Row = CMlngvsfGridTitleRow Then
                    Return
                End If

                '[>]無効
                cmdCFMove.Enabled = False
                cmdTFTMove.Enabled = False

                'TFTはタイトル行
                vsfTFTList.Row = CMlngvsfGridTitleRow
                
                '予約済み
                If .GetData(.Row, CMlngvsfReserveFlag) = CPstrFlagOn Then

                    '選択中の場合は何もしない
                    If lblReserveStatus.Text = CMstrReserveSelect Then
                        .Row = CMlngvsfGridTitleRow
                        Exit Sub
                    End If

                    '予約済の情報取得
                    '引数(TFT,CF)
                    Call prvOdfReserveInfo(vbNullString, .GetData(.Row, CMlngvsfReserveLotId))
                    Exit Sub

                Else
                    '予約済の場合
                    If lblReserveStatus.Text = CMstrReserveDone Then
                        'WFリストclear
                        Call prvOdfReserveInfoClear()
                    End If
                End If

                'CFロット選択済み
                If lblCFLotId.Text <> vbNullString Then
                    Return
                End If

                '[>]有効
                cmdCFMove.Enabled = True

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCFList_Click"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' TFT[＞]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdTFTMove_Click(sender As Object, e As EventArgs) Handles cmdTFTMove.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfTFTList
                'ヘッダー行は処理なし
                If .Row = CMlngvsfGridTitleRow Then
                    Return
                End If

                '予約済み
                If .GetData(.Row, CMlngvsfReserveFlag) = CPstrFlagOn Then
                    Return
                End If

                lblTFTLotId.Text = .GetData(.Row, CMlngvsfReserveLotId)
                lblTFTCarrierId.Text = .GetData(.Row, CMlngvsfReserveCarrierId)
                '予約選択中
                lblReserveStatus.Text = CMstrReserveSelect

                'WFリスト表示
                Call prvvsfTFTandCfReserveWfList_Disp(vsfTFTList, vsfTFTWfList, lblTFTLotId.Text)

                '予約ボタン有効チェック
                Call prvReserveRegistButtonCheck()

                '選択ロットを灰色
                Dim styleSelect As CellStyle = .Styles.Add("CustomStyle_" + .Row.ToString)
                styleSelect.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
                Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfReserveNo, .Row, .Cols.Count-1)
                cellRange.Style = styleSelect

                'タイトル行に行設定
                .Row = CMlngvsfGridTitleRow

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTFTMove_Click"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' CF[＞]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdCFMove_Click(sender As Object, e As EventArgs) Handles cmdCFMove.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfCFList
                'ヘッダー行は処理なし
                If .Row = CMlngvsfGridTitleRow Then
                    Return
                End If

                '予約済み
                If .GetData(.Row, CMlngvsfReserveFlag) = CPstrFlagOn Then
                    Return
                End If

                lblCFLotId.Text = .GetData(.Row, CMlngvsfReserveLotId)
                lblCFCarrierId.Text = .GetData(.Row, CMlngvsfReserveCarrierId)
                '予約選択中
                lblReserveStatus.Text = CMstrReserveSelect

                'WFリスト表示
                Call prvvsfTFTandCfReserveWfList_Disp(vsfCFList, vsfCFWfList, lblCFLotId.Text)

                '予約ボタン有効チェック
                Call prvReserveRegistButtonCheck()

                '選択ロット色(灰色)
                Dim styleSelect As CellStyle = .Styles.Add("CustomStyle_" + .Row.ToString)
                styleSelect.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
                Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfReserveNo, .Row, .Cols.Count-1)
                cellRange.Style = styleSelect

                'タイトル行に行設定
                .Row = CMlngvsfGridTitleRow

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCFMove_Click"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' TFT[＜]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdTFTMoveCancel_Click(sender As Object, e As EventArgs) Handles cmdTFTMoveCancel.Click

        Dim lintRow As Integer

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfTFTList

                '選択ロット色解除
                For lintRow = 1 To .Rows.Count - 1
                    If lblTFTLotId.Text = .GetData(lintRow, CMlngvsfReserveLotId) Then
                        Dim styleSelect As CellStyle = .Styles.Add("CustomStyle_" + .Row.ToString)
                        styleSelect.ForeColor = ColorTranslator.FromWin32(CMlngEnableTrueForeColor)
                        Dim cellRange As CellRange = .GetCellRange(lintRow, CMlngvsfReserveNo, lintRow, .Cols.Count-1)
                        cellRange.Style = styleSelect
                        Exit For
                    End If
                Next

                lblTFTLotId.Text = vbNullString
                lblTFTCarrierId.Text = vbNullString

                'LOT/CARRIERが全て空の場合
                If lblTFTLotId.Text = vbNullString And  lblTFTCarrierId.Text = vbNullString And _
                    lblCFLotId.Text = vbNullString And  lblCFCarrierId.Text = vbNullString Then

                    lblReserveStatus.Text = vbNullString
                End If

                'WFリスト初期化
                Call prvvsfReserveWfList_Init(vsfTFTWfList)

                '予約ボタン有効チェック
                Call prvReserveRegistButtonCheck()

                'タイトル行に行設定
                .Row = CMlngvsfGridTitleRow

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTFTMoveCancel_Click"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' CF[＜]
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdCFMoveCancel_Click(sender As Object, e As EventArgs) Handles cmdCFMoveCancel.Click

        Dim lintRow As Integer

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfCFList

                '選択ロット色解除
                For lintRow = 1 To .Rows.Count - 1
                    If lblCFLotId.Text = .GetData(lintRow, CMlngvsfReserveLotId) Then
                        Dim styleSelect As CellStyle = .Styles.Add("CustomStyle_" + .Row.ToString)
                        styleSelect.ForeColor = ColorTranslator.FromWin32(CMlngEnableTrueForeColor)
                        Dim cellRange As CellRange = .GetCellRange(lintRow, CMlngvsfReserveNo, lintRow, .Cols.Count-1)
                        cellRange.Style = styleSelect
                        Exit For
                    End If
                Next

                lblCFLotId.Text = vbNullString
                lblCFCarrierId.Text = vbNullString

                'LOT/CARRIERが全て空の場合
                If lblTFTLotId.Text = vbNullString And  lblTFTCarrierId.Text = vbNullString And _
                    lblCFLotId.Text = vbNullString And  lblCFCarrierId.Text = vbNullString Then

                    lblReserveStatus.Text = vbNullString
                End If

                'WFリスト
                Call prvvsfReserveWfList_Init(vsfCFWfList)

                '予約ボタン有効チェック
                Call prvReserveRegistButtonCheck()

                'タイトル行に行設定
                .Row = CMlngvsfGridTitleRow

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCFMoveCancel_Click"
                .strErrMessage = ""
            End With

            Call pubOnError_Proc()

        End Try

    End Sub

    ''' <summary>
    ''' ODF貼り合せ予約の登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns As Boolean
        Dim lintRow As Integer
        Dim ltyptypOdfReserveRegist As List(Of typOdfReserveRegist)
        Dim lstrHReserveFlag As String = vbNullString
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '作業者コード入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '中止の場合
            If pblnCancel = True Then
                Exit Sub
            End If

            'TFT/CF WFリストは同じ数のデータがあることを想定
            ltyptypOdfReserveRegist = New List(Of typOdfReserveRegist)
            For lintRow = 1 To vsfTFTWFList.Rows.Count - 1
                
                'WFIDがある場合
                If vsfTFTWFList.GetData(lintRow, CMlngvsfWfReserveId) <> vbNullString And _
                    vsfCFWFList.GetData(lintRow, CMlngvsfWfReserveId) <> vbNullString Then

                    Dim tmp As typOdfReserveRegist
                    tmp.strWfId = vsfTFTWFList.GetData(lintRow, CMlngvsfWfReserveId)
                    tmp.strCFWfId = vsfCFWFList.GetData(lintRow, CMlngvsfWfReserveId)
                    tmp.strLotId = lblTFTLotId.Text
                    tmp.strCfLotId = lblCFLotId.Text
                    tmp.strCarrierId = lblTFTCarrierId.Text
                    tmp.strCfCarrierId = lblCFCarrierId.Text
                    tmp.strSlotPosition = vsfTFTWFList.GetData(lintRow, CMlngvsfWfReserveSlot)
                    ltyptypOdfReserveRegist.Add(tmp)
                End If
            Next

            IF ltyptypOdfReserveRegist.Count = 0 Then
                'Public Const CPstrMsgInf0082        As String = "<TRM82I>$$登録データがありませんでした。$設定を確認してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0082)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If
            
            'レスポンス開始
            Dim lstrEventName As String = "cmdRegist_Click"
            Call pubResponseStart(Me.Name, lstrEventName)

            'ODF貼り合せ登録
            lblnAns = pubblnOdfReserveRegist_Upd(CPstrasm_odfreserveregistVer, CMstrRegistTypeIns, ltyptypOdfReserveRegist, lstrHReserveFlag)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)

                Call pubSetFocus(cmbTFTandCF)
                Exit Sub
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '端末メッセージ表示
            'Public Const CPstrMsgInf007Z        As String = "<TRM7ZI>$$ロット[%1/%2]のODF貼り合せ予約を[%3]しました。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007Z, lblTFTLotId.Text, lblCFLotId.Text, "登録")
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '最新取得
            Call cmdReserveLotList_Click(sender, e)
    
            Call pubSetFocus(cmbTFTandCF)
   
            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRegist_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            Call pubOnError_Proc()
            
        End Try
    End Sub

    ''' <summary>
    ''' ODF貼り合せ予約の削除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDel.Click

        Dim lblnAns As Boolean
        Dim lintRow As Integer
        Dim ltyptypOdfReserveRegist As List(Of typOdfReserveRegist)
        Dim lstrHReserveFlag As String = vbNullString
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '作業者コード入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '中止の場合
            If pblnCancel = True Then
                Exit Sub
            End If

            'TFT/CF WFリストは同じ数のデータがあることを想定
            ltyptypOdfReserveRegist = New List(Of typOdfReserveRegist)
            For lintRow = 1 To vsfTFTWFList.Rows.Count - 1
                
                'WFIDがある場合
                If vsfTFTWFList.GetData(lintRow, CMlngvsfWfReserveId) <> vbNullString And _
                    vsfCFWFList.GetData(lintRow, CMlngvsfWfReserveId) <> vbNullString Then

                    Dim tmp As typOdfReserveRegist
                    tmp.strWfId = vsfTFTWFList.GetData(lintRow, CMlngvsfWfReserveId)
                    tmp.strCFWfId = vsfCFWFList.GetData(lintRow, CMlngvsfWfReserveId)
                    tmp.strLotId = lblTFTLotId.Text
                    tmp.strCfLotId = lblCFLotId.Text
                    tmp.strCarrierId = lblTFTCarrierId.Text
                    tmp.strCfCarrierId = lblCFCarrierId.Text
                    tmp.strSlotPosition = vsfTFTWFList.GetData(lintRow, CMlngvsfWfReserveSlot)
                    ltyptypOdfReserveRegist.Add(tmp)
                End If
            Next

            IF ltyptypOdfReserveRegist.Count = 0 Then
                'Public Const CPstrMsgInf0082        As String = "<TRM82I>$$登録データがありませんでした。$設定を確認してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0082)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If

            'レスポンス開始
            Dim lstrEventName As String = "cmdDel_Click"
            Call pubResponseStart(Me.Name, lstrEventName)

            '予約解除
            lblnAns = pubblnOdfReserveRegist_Upd(CPstrasm_odfreserveregistVer, CMstrRegistTypeDel, ltyptypOdfReserveRegist, lstrHReserveFlag)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)

                Call pubSetFocus(cmbTFTandCF)
                Exit Sub
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '表面処理の予約も解除された場合
            If lstrHReserveFlag = 1 Then
                'Public Const CPstrMsgInf0081        As String = "<TRM81I>$$表面処理バッチ予約情報も解除されました。$確認してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0081)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If

            '端末メッセージ表示
            'Public Const CPstrMsgInf007Z        As String = "<TRM7ZI>$$ロット[%1/%2]のODF貼り合せ予約を[%3]しました。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007Z, lblTFTLotId.Text, lblCFLotId.Text, "解除")
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '最新取得
            Call cmdReserveLotList_Click(sender, e)
                
            Call pubSetFocus(cmbTFTandCF)
            
            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey      
                .strProcName = "cmdDel_Click"         
                .strErrMessage = ""                     
            End With

            Call pubOnError_Proc()
            
        End Try
    End Sub

    ''' <summary>
    ''' 最新取得(予約設定)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdReserveLotList_Click(sender As Object, e As EventArgs) Handles cmdReserveLotList.Click

        Dim lblnAns As Boolean
        Dim ltypOdfReserveList As New List(Of typOdfReserveRep)
        Dim lstrTFTPdId As String
        Dim lstrCFPdId As String

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
                        
            '空白の場合抜ける
            If cmbTFTandCF.Text = vbNullString Then
                Exit Sub
            End If
            
            '情報クリア
            'ラベル
            lblNowDate0.Text = vbNullString
            lblTFTLotId.Text = vbNullString
            lblCFLotId.Text = vbNullString
            lblTFTCarrierId.Text = vbNullString
            lblCFCarrierId.Text = vbNullString
            lblReserveStatus.Text = vbNullString

            'ボタン無効
            cmdTFTMove.Enabled = False              '[>]
            cmdTFTMoveCancel.Enabled = False        '[<]
            cmdCFMove.Enabled = False               '[>]
            cmdCFMoveCancel.Enabled = False         '[<]

            '*******************
            'グリッド初期化
            '*******************
            'WFリスト
            Call prvvsfReserveWfList_Init(vsfTFTWfList)
            Call prvvsfReserveWfList_Init(vsfCFWfList)

            'レスポンス開始
            Dim lstrEventName As String = "cmdReserveLotList_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            With cmbTFTandCF
                .ValueCol = 0
                lstrTFTPdId = cmbTFTandCF.Value
                .ValueCol = 2
                lstrCFPdId = cmbTFTandCF.Value
            End With
                
            'ODF貼り合せ一覧の表示
            lblnAns = pubblnOdfReserveList_Sel(CPstrasm_odfreservelistVer, lstrTFTPdId, lstrCFPdId, ltypOdfReserveList)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)                
                Exit Sub   
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '結果表示
            Call prvvsfTFTandCfReserveList_Disp(ltypOdfReserveList)

            '予約ボタン有効チェック
            Call prvReserveRegistButtonCheck()

            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey        
                .strProcName = "cmdReserveLotList_Click" 
                .strErrMessage = ""                  
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 最新取得(予約一覧)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdReserveInfo_Click(sender As Object, e As EventArgs) Handles cmdReserveInfo.Click

        Dim lblnAns As Boolean
        Dim ltypOdfReserveInfo As New List(Of typOdfReserveInfo)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '検索条件
            If lblLotId.Text = vbNullString And lblWfId.Text = vbNullString Then
                Exit Sub
            End If
            
            '情報クリア
            'ラベル
            lblNowDate1.Text = vbNullString

            '*******************
            'グリッド初期化
            '*******************
            Call prvvsfReserveInfo_Init()

            'レスポンス開始
            Dim lstrEventName As String = "cmdReserveInfo_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
                            
            '引数(LOTID,WFID)
            lblnAns = pubblnOdfReserveInfo_Sel(CPstrasm_odfreservereinfoVer, lblLotId.Text , lblWfId.Text, ltypOdfReserveInfo)

            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)                
                Exit Sub   
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '表示
            Call prvvsReserveInfo_Disp(ltypOdfReserveInfo)

            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdReserveInfo_Click" 
                .strErrMessage = ""         
            End With

            Call pubOnError_Proc()

        End Try

    End Sub

    ''' <summary>
    ''' TXT入力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lblLotId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lblLotId.KeyPress
        Try
            'LOT/WFはどちらかでの検索
            'LOTIDを入力時、WFIDがある場合はNULL
            If lblWfId.Text <> vbNullString Then
                lblWfId.Text = vbNullString
            End If

            '@全角の入力を制御(記号可)
            Select Case Asc(e.KeyChar)
                '@0～9、A～Z、ﾊﾞｯｸｽﾍﾟｰｽ　入力可
                Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, _
                     CPlngKeyAsciiUppA To CPlngKeyAsciiUppZ, _
                     CPlngKeyAsciiLowA To CPlngKeyAsciiLowZ, _
                     CPlngKeyBackSpace

                Case CPlngKeyReturn
                    '最新情報取得
                    Call cmdReserveInfo_Click(sender, e)

                '@それ以外は入力不可
                Case Else
                    e.Handled = True 'ｷｰ無効
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey   
                .strProcName = "lblLotId_KeyPress" 
                .strErrMessage = ""                 
            End With

            Call pubOnError_Proc()
        End Try
    End Sub

    ''' <summary>
    ''' TXT入力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub lblWfId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lblWfId.KeyPress
        Try
            'LOT/WFはどちらかでの検索
            'WFIDを入力時、LOTIDがある場合はNULL
            If lblLotId.Text <> vbNullString Then
                lblLotId.Text = vbNullString
            End If

            '@全角の入力を制御(記号可)
            Select Case Asc(e.KeyChar)
                '@0～9、A～Z、ﾊﾞｯｸｽﾍﾟｰｽ,、#　入力可
                Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, _
                     CPlngKeyAsciiUppA To CPlngKeyAsciiUppZ, _
                     CPlngKeyAsciiLowA To CPlngKeyAsciiLowZ, _
                     CPlngKeyBackSpace, CPlngKeyAscHash

                Case CPlngKeyReturn
                    '最新情報取得
                    Call cmdReserveInfo_Click(sender, e)

                '@それ以外は入力不可
                Case Else
                    e.Handled = True 'ｷｰ無効
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         
                .strProcName = "lblWfId_KeyPress" 
                .strErrMessage = ""                     
            End With

            Call pubOnError_Proc()
        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約の情報最新情報取得
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdHyoumenReserveInfo_Click(sender As Object, e As EventArgs) Handles cmdHyoumenReserveInfo.Click
        
        Dim lblnAns As Boolean
        Dim ltypHyounenReserveInfo As New List(Of typHyoumenReserveInfo)
        Dim lstrSelectOpstion As String

        Try
            
            '表面処理予約Tabが選択時のみ有効
            'Tabの初期化でのOptionを初期化した際に呼ばれるのを防止する
            If tabODF.SelectedIndex <> CMintTab2 Then
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
                        
            '情報クリア
            'ラベル
            lblNowDate2.Text = vbNullString
            lblSelectWfCnt.Text = vbNullString

            '検索Option
            If optNone.Checked = True Then
                lstrSelectOpstion = CMstrSelOptNone
            ElseIf optDone.Checked = True Then
                lstrSelectOpstion = CMstrSelOptDone
            Else
                lstrSelectOpstion = CMstrSelOptAll
            End If

            '*******************
            'グリッド初期化
            '*******************
            Call prvvsfHyoumenReserve_Init()

            'レスポンス開始
            Dim lstrEventName As String = "cmdReserveLotList_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '表示情報の取得(引数：選択Option)
            lblnAns = pubblnHReserveInfo_Sel(CPstrasm_hreserveinfoVer, lstrSelectOpstion, ltypHyounenReserveInfo)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)                
                Exit Sub   
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '結果表示
            Call prvvsHyoumenReserveInfo_Disp(ltypHyounenReserveInfo)

            '表面処理予約のボタンチェック
            Call prvHyoumenReserveButtonCheck()

            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey      
                .strProcName = "cmdReserveLotList_Click" 
                .strErrMessage = ""                    
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約情報のグリッド選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vsfHyoumenReserveInfo_Click(sender As Object, e As EventArgs) Handles vsfHyoumenReserveInfo.Click
        Try
            With vsfHyoumenReserveInfo

                Select Case .Col
                        
                    'CheckBox
                    Case CMlngvsfHInfoCheckBox
                        
                        '予約未(予約登録操作中の場合)
                        '予約なしの場合(予約時間がNULL)
                        If optNone.Checked = True And _
                            .GetData(.Row, CMlngvsfHInfoReserveTime) = vbNullString Then
                            '編集可
                            .StartEditing()

                        '予約済(予約解除の場合)
                        '予約なしの場合(予約時間がNULL)
                        ElseIf optDone.Checked = True And _
                            .GetData(.Row, CMlngvsfHInfoReserveTime) <> vbNullString Then
                            '編集可
                            .StartEditing()

                        Else
                            '編集不可
                            .AllowEditing = False
                        End If
                                                            
                    Case Else
                        '編集不可
                        .AllowEditing = False
                End Select

                '表面処理予約のボタンチェック
                Call prvHyoumenReserveButtonCheck()

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfHyoumenReserveInfo_Click"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約オプション(全て)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub optAll_CheckedChanged(sender As Object, e As EventArgs) Handles optAll.CheckedChanged
        Try

            If optAll.Checked = False Then
                Exit Sub
            End If

            '最新情報の取得
            Call cmdHyoumenReserveInfo_Click(sender, e)

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optAll_CheckedChanged"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約オプション(予約済)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub optDone_CheckedChanged(sender As Object, e As EventArgs) Handles optDone.CheckedChanged
        Try
            
            If optDone.Checked = False Then
                Exit Sub
            End If
            
            '最新情報の取得
            Call cmdHyoumenReserveInfo_Click(sender, e)

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optDone_CheckedChanged"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約オプション(予約未)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub optNone_CheckedChanged(sender As Object, e As EventArgs) Handles optNone.CheckedChanged
        Try

            If optNone.Checked = False Then
                Exit Sub
            End If

            '最新情報の取得
            Call cmdHyoumenReserveInfo_Click(sender, e)

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optNone_CheckedChanged"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約の登録
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdHyoumenRegist_Click(sender As Object, e As EventArgs) Handles cmdHyoumenRegist.Click

        Dim lblnAns As Boolean
        Dim lintRow As Integer
        Dim ltypHyounenReserveRegist As New List(Of typHyoumenReserveRegist)()
        Dim lstrLotsMeg As String = vbNullString
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '作業者コード入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '中止の場合
            If pblnCancel = True Then
                Exit Sub
            End If

            With vsfHyoumenReserveInfo
                For lintRow = 1 To .Rows.Count - 1

                    'CheckBoxチェック済が登録対象
                    'WF数等の登録可能のチェックはここではしない
                    If .GetCellCheck(lintRow, CMlngvsfHInfoCheckBox) = CheckEnum.Checked Then

                        'WFID(TFT)
                        Dim lstrWfIdList As New List(Of String)()
                        Call prvMakeWfIdList(.GetData(lintRow, CMlngvsfHInfoTFTWfes), lstrWfIdList)

                        'WFID(CF)
                        Dim lstrCfWfIdList As New List(Of String)()
                        Call prvMakeWfIdList(.GetData(lintRow, CMlngvsfHInfoCFWfes), lstrCfWfIdList)

                        '登録数が異なる場合
                        If lstrWfIdList.Count <> lstrCfWfIdList.Count Then
                            'Public Const CPstrMsgInf0083        As String = "<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "TFT/CF WF枚数の不一致")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            Exit Sub
                        End If

                        'TFT/CFのリストを同時に回すのでForEachはやめた
                        Dim lintCnt As Integer
                        For lintCnt = 0 To lstrWfIdList.Count - 1
                            Dim tmp As typHyoumenReserveRegist
                            tmp.strWfId = lstrWfIdList(lintCnt)
                            tmp.strCfWfId = lstrCfWfIdList(lintCnt)
                            tmp.strLotId = .GetData(lintRow, CMlngvsfHInfoTFTLotId)
                            tmp.strCfLotId = .GetData(lintRow, CMlngvsfHInfoCFLotId)
                            tmp.strEditTime = .GetData(lintRow, CMlngvsfHInfoEditTime)
                            ltypHyounenReserveRegist.Add(tmp)

                            '端末表示用のメッセージ、ロット群を作成
                            If lintCnt = 0 Then
                                If lstrLotsMeg = vbNullString Then
                                    lstrLotsMeg = tmp.strLotId + "/" + tmp.strCfLotId
                                Else
                                    lstrLotsMeg = lstrLotsMeg + "/" + tmp.strLotId + "/" + tmp.strCfLotId
                                End If
                            End If
                        Next                   
                    End If
                Next
            End With

            IF ltypHyounenReserveRegist.Count = 0 Then
                'Public Const CPstrMsgInf0082        As String = "<TRM82I>$$登録データがありませんでした。$設定を確認してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0082)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If
            
            'レスポンス開始
            Dim lstrEventName As String = "cmdHyoumenRegist_Click"
            Call pubResponseStart(Me.Name, lstrEventName)

            '登録
            lblnAns = pubblnHyoumenReserveRegist_Upd(CPstrasm_hreserveregistVer, CMstrRegistTypeIns, ltypHyounenReserveRegist)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '端末メッセージ表示
            'Public Const CPstrMsgInf0080        As String = "<TRM80I>$$ロット[%1]の表面処理の予約を[%3]しました。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0080, lstrLotsMeg, "登録")
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '最新取得
            Call cmdHyoumenReserveInfo_Click(sender, e)
    
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHyoumenRegist_Click"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約の解除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdHyoumenDel_Click(sender As Object, e As EventArgs) Handles cmdHyoumenDel.Click

        Dim lblnAns As Boolean
        Dim lintRow As Integer
        Dim ltypHyounenReserveRegist As New List(Of typHyoumenReserveRegist)
        Dim lstrLotsMeg As String = vbNullString
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '作業者コード入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '中止の場合
            If pblnCancel = True Then
                Exit Sub
            End If

            With vsfHyoumenReserveInfo
                For lintRow = 1 To .Rows.Count - 1

                    'CheckBoxチェック済が登録対象
                    'WF数等の登録可能のチェックはここではしない
                    If .GetCellCheck(lintRow, CMlngvsfHInfoCheckBox) = CheckEnum.Checked Then

                        'WFID(TFT)
                        Dim lstrWfIdList As New List(Of String)()
                        Call prvMakeWfIdList(.GetData(lintRow, CMlngvsfHInfoTFTWfes), lstrWfIdList)

                        'WFID(CF)
                        Dim lstrCfWfIdList As New List(Of String)()
                        Call prvMakeWfIdList(.GetData(lintRow, CMlngvsfHInfoCFWfes), lstrCfWfIdList)

                        '登録数の異常
                        If lstrWfIdList.Count <> lstrCfWfIdList.Count Then
                            'Public Const CPstrMsgInf0083        As String = "<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "TFT/CF WF枚数の不一致")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            Exit Sub
                        End If

                        'TFT/CFのリストを同時に回すのでForEachはやめた
                        Dim lintCnt As Integer
                        For lintCnt = 0 To lstrWfIdList.Count - 1
                            Dim tmp As typHyoumenReserveRegist
                            tmp.strWfId = lstrWfIdList(lintCnt)
                            tmp.strCfWfId = lstrCfWfIdList(lintCnt)
                            tmp.strLotId = .GetData(lintRow, CMlngvsfHInfoTFTLotId)
                            tmp.strCfLotId = .GetData(lintRow, CMlngvsfHInfoCFLotId)
                            tmp.strEditTime = .GetData(lintRow, CMlngvsfHInfoEditTime)
                            ltypHyounenReserveRegist.Add(tmp)

                            '端末表示用のメッセージ、ロット群を作成
                            If lintCnt = 0 Then
                                If lstrLotsMeg = vbNullString Then
                                    lstrLotsMeg = tmp.strLotId + "/" + tmp.strCfLotId
                                Else
                                    lstrLotsMeg = lstrLotsMeg + "/" + tmp.strLotId + "/" + tmp.strCfLotId
                                End If
                            End If
                        Next
                    End If
                Next
            End With

            IF ltypHyounenReserveRegist.Count = 0 Then
                'Public Const CPstrMsgInf0082        As String = "<TRM82I>$$登録データがありませんでした。$設定を確認してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0082)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If
            
            'レスポンス開始
            Dim lstrEventName As String = "cmdHyoumenDel_Click"
            Call pubResponseStart(Me.Name, lstrEventName)

            '登録
            lblnAns = pubblnHyoumenReserveRegist_Upd(CPstrasm_hreserveregistVer, CMstrRegistTypeDel, ltypHyounenReserveRegist)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '端末メッセージ表示
            'Public Const CPstrMsgInf0080        As String = "<TRM80I>$$ロット[%1]の表面処理の予約を[%3]しました。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0080, lstrLotsMeg, "解除")
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '最新取得
            Call cmdHyoumenReserveInfo_Click(sender, e)
    
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHyoumenDel_Click"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' マージセルがスクロール後に表示されない箇所があるので
    ''' スクロール後にリフレッシュを入れる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vsfHyoumenReserveInfo_AfterScroll(sender As Object, e As RangeEventArgs) Handles vsfHyoumenReserveInfo.AfterScroll
        Try
            With vsfHyoumenReserveInfo
                .Refresh
            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfHyoumenReserveInfo_AfterScroll"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' マージセルがスクロール後に表示されない箇所があるので
    ''' スクロール後にリフレッシュを入れる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vsfReserveInfo_AfterScroll(sender As Object, e As RangeEventArgs) Handles vsfReserveInfo.AfterScroll
        Try
            With vsfReserveInfo
                .Refresh
            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfReserveInfo_AfterScroll"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case tabODF.SelectedIndex
                        '@蒸着後流動予約タブ
                        Case CMintTab3
                      
                            Select Case ActiveControl.Name
                                Case txtCarrier.Name
									'@Validate処理へ
									RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
									Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
									AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
									e.Handled = True
									Exit Sub
								Case txtToCarrier1.Name
									'@Validate処理へ
									RemoveHandler txtToCarrier1.Validating, AddressOf txtToCarrier1_Validate
									Call txtToCarrier1_Validate(txtToCarrier1, New CancelEventArgs(True))
									AddHandler txtToCarrier1.Validating, AddressOf txtToCarrier1_Validate
									e.Handled = True
									Exit Sub
								Case txtToCarrier2.Name
									'@Validate処理へ
									RemoveHandler txtToCarrier2.Validating, AddressOf txtToCarrier2_Validate
									Call txtToCarrier2_Validate(txtToCarrier2, New CancelEventArgs(True))
									AddHandler txtToCarrier2.Validating, AddressOf txtToCarrier2_Validate
									e.Handled = True
									Exit Sub
								Case txtToCarrier3.Name
									'@Validate処理へ
									RemoveHandler txtToCarrier3.Validating, AddressOf txtToCarrier3_Validate
									Call txtToCarrier3_Validate(txtToCarrier3, New CancelEventArgs(True))
									AddHandler txtToCarrier3.Validating, AddressOf txtToCarrier3_Validate
									e.Handled = True
									Exit Sub
								Case txtToCarrier4.Name
									'@Validate処理へ
									RemoveHandler txtToCarrier4.Validating, AddressOf txtToCarrier4_Validate
									Call txtToCarrier4_Validate(txtToCarrier4, New CancelEventArgs(True))
									AddHandler txtToCarrier4.Validating, AddressOf txtToCarrier4_Validate
									e.Handled = True
									Exit Sub
							End Select
					
               
					End Select
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_KeyDown"           '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

			'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If


            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If LenB(txtCarrier.Text) < CPlngCarrierMaxLength And _
               txtCarrier.Text <> vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"C_WAR0007　ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽそのまま
                e.Cancel = True
                
                '@ｷｬﾘｱIDのﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                
                Exit Sub
            End If

            '@ｷｬﾘｱIDが無変更の場合
            If mblnTxtCarrierChange = False Then

                If ActiveControl.Name = txtCarrier.Name Then
                    '@統合ﾛｯﾄ2のｷｬﾘｱIDが有効の場合
                    If vsfSlotMap.Enabled = True Then
                        '@移載工程ｽｷｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSlotMap)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If

			'最新情報取得
			If Not prvUpdateAfterJReserveInfo() Then
				Exit sub
			End If
            

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


	'関数名：txtToCarrier1_Validate
    '機　能：予約1ｷｬﾘｱ　Valiadte処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub txtToCarrier1_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrier1.Validating

        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lblnAns             As Boolean          '戻り値
        Dim lstrSlotSize        As String           'ｽﾛｯﾄｻｲｽﾞ格納

        Try

			'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の場合は空きｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄし、処理抜け
            '@　①空白の場合
            '@　②前回入力ｷｬﾘｱIDと同じ
            If txtToCarrier1.Text = vbNullString Or mstrToCarrier1 = txtToCarrier1.Text Then
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier1.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtToCarrier1.NowByte < txtToCarrier1.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
			Dim lstrEventName As String = "txtToCarrier1_Validate"
            Call pubResponseStart(Me.Name, lstrEventName)

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtToCarrier1.Text        'ｷｬﾘｱID
                .strClassDivision = CPstrCD4W               '空ｷｬﾘｱﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
				Select Case Strings.Left$(txtToCarrier1.Text, 1)
					'@1文字目が"B"
					Case "B"
						.strCarrierTypeID = CPstrCarrTypeFOUP					'ｷｬﾘｱﾀｲﾌﾟ(FOUP)

					'@1文字目が"J"
					Case "J"
					   .strCarrierTypeID = CPstrCarrTypeHotOP					'ｷｬﾘｱﾀｲﾌﾟ(耐熱オープンカセット)

					Case Else
						.strCarrierTypeID = CPstrCarrTypeFOUP

				End Select
                .strLotID = vbNullString                    'ﾛｯﾄID
            End With

            '@【ｷｬﾘｱ状態確認】】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, _
                                             True, _
                                             lstrSlotSize)

            '@通信結果確認
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ｷｬﾘｱIDの退避
                mstrToCarrier1 = txtToCarrier1.Text
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)

				'@=======================
				'@　確定ﾎﾞﾀﾝ制御処理
				'@=======================
				Call prvcmdReserveJRegistEnabled_Chk()

                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier1.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If

            Else
                '@結果：異常の場合
                
                '@ｷｬﾘｱIDの退避ｸﾘｱ
                mstrToCarrier1 = vbNullString
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier1_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：txtToCarrier2_Validate
    '機　能：予約1ｷｬﾘｱ　Valiadte処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub txtToCarrier2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrier2.Validating

        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lblnAns             As Boolean          '戻り値
        Dim lstrSlotSize        As String           'ｽﾛｯﾄｻｲｽﾞ格納

        Try

			'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の場合は空きｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄし、処理抜け
            '@　①空白の場合
            '@　②前回入力ｷｬﾘｱIDと同じ
            If txtToCarrier2.Text = vbNullString Or mstrToCarrier2 = txtToCarrier2.Text Then
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier2.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtToCarrier2.NowByte < txtToCarrier2.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
			Dim lstrEventName As String = "txtToCarrier2_Validate"
            Call pubResponseStart(Me.Name, lstrEventName)

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtToCarrier2.Text        'ｷｬﾘｱID
                .strClassDivision = CPstrCD4W               '空ｷｬﾘｱﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                Select Case Strings.Left$(txtToCarrier2.Text, 1)
					'@1文字目が"B"
					Case "B"
						.strCarrierTypeID = CPstrCarrTypeFOUP					'ｷｬﾘｱﾀｲﾌﾟ(FOUP)
					'@1文字目が"J"
					Case "J"
					   .strCarrierTypeID = CPstrCarrTypeHotOP					'ｷｬﾘｱﾀｲﾌﾟ(耐熱オープンカセット)
					Case Else
						.strCarrierTypeID = CPstrCarrTypeFOUP
				End Select
                .strLotID = vbNullString                    'ﾛｯﾄID
            End With

            '@【ｷｬﾘｱ状態確認】】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, _
                                             True, _
                                             lstrSlotSize)

            '@通信結果確認
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ｷｬﾘｱIDの退避
                mstrToCarrier2 = txtToCarrier2.Text
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
            
				'@=======================
				'@　確定ﾎﾞﾀﾝ制御処理
				'@=======================
				Call prvcmdReserveJRegistEnabled_Chk()

                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier2.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
            Else
                '@結果：異常の場合
                
                '@ｷｬﾘｱIDの退避ｸﾘｱ
                mstrToCarrier2 = vbNullString
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier2_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：txtToCarrier3_Validate
    '機　能：予約1ｷｬﾘｱ　Valiadte処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub txtToCarrier3_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrier3.Validating

        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lblnAns             As Boolean          '戻り値
        Dim lstrSlotSize        As String           'ｽﾛｯﾄｻｲｽﾞ格納

        Try

			'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の場合は空きｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄし、処理抜け
            '@　①空白の場合
            '@　②前回入力ｷｬﾘｱIDと同じ
            If txtToCarrier3.Text = vbNullString Or mstrToCarrier3 = txtToCarrier3.Text Then
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier3.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtToCarrier3.NowByte < txtToCarrier3.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
			Dim lstrEventName As String = "txtToCarrier3_Validate"
            Call pubResponseStart(Me.Name, lstrEventName)

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtToCarrier3.Text        'ｷｬﾘｱID
                .strClassDivision = CPstrCD4W               '空ｷｬﾘｱﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                Select Case Strings.Left$(txtToCarrier3.Text, 1)
					'@1文字目が"B"
					Case "B"
						.strCarrierTypeID = CPstrCarrTypeFOUP					'ｷｬﾘｱﾀｲﾌﾟ(FOUP)
					'@1文字目が"J"
					Case "J"
					   .strCarrierTypeID = CPstrCarrTypeHotOP					'ｷｬﾘｱﾀｲﾌﾟ(耐熱オープンカセット)
					Case Else
						.strCarrierTypeID = CPstrCarrTypeFOUP
				End Select
                .strLotID = vbNullString                    'ﾛｯﾄID
            End With

            '@【ｷｬﾘｱ状態確認】】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, _
                                             True, _
                                             lstrSlotSize)

            '@通信結果確認
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ｷｬﾘｱIDの退避
                mstrToCarrier3 = txtToCarrier3.Text
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)

				'@=======================
				'@　確定ﾎﾞﾀﾝ制御処理
				'@=======================
				Call prvcmdReserveJRegistEnabled_Chk()
            
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier3.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
            Else
                '@結果：異常の場合
                
                '@ｷｬﾘｱIDの退避ｸﾘｱ
                mstrToCarrier3 = vbNullString
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier3_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


		'関数名：txtToCarrier4_Validate
    '機　能：予約1ｷｬﾘｱ　Valiadte処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub txtToCarrier4_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrier4.Validating

        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lblnAns             As Boolean          '戻り値
        Dim lstrSlotSize        As String           'ｽﾛｯﾄｻｲｽﾞ格納

        Try

			'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl.Name = cmdClose.Name OrElse mblnWindowClose Then
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の場合は空きｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄし、処理抜け
            '@　①空白の場合
            '@　②前回入力ｷｬﾘｱIDと同じ
            If txtToCarrier4.Text = vbNullString Or mstrToCarrier4 = txtToCarrier4.Text Then
                
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier4.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtToCarrier4.NowByte < txtToCarrier4.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
			Dim lstrEventName As String = "txtToCarrier4_Validate"
            Call pubResponseStart(Me.Name, lstrEventName)

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtToCarrier4.Text        'ｷｬﾘｱID
                .strClassDivision = CPstrCD4W               '空ｷｬﾘｱﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                Select Case Strings.Left$(txtToCarrier4.Text, 1)
					'@1文字目が"B"
					Case "B"
						.strCarrierTypeID = CPstrCarrTypeFOUP					'ｷｬﾘｱﾀｲﾌﾟ(FOUP)
					'@1文字目が"J"
					Case "J"
					   .strCarrierTypeID = CPstrCarrTypeHotOP					'ｷｬﾘｱﾀｲﾌﾟ(耐熱オープンカセット)
					Case Else
						.strCarrierTypeID = CPstrCarrTypeFOUP
				End Select
                .strLotID = vbNullString                    'ﾛｯﾄID
            End With

            '@【ｷｬﾘｱ状態確認】】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, _
                                             True, _
                                             lstrSlotSize)

            '@通信結果確認
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ｷｬﾘｱIDの退避
                mstrToCarrier4 = txtToCarrier4.Text
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, lstrEventName)
            
				'@=======================
				'@　確定ﾎﾞﾀﾝ制御処理
				'@=======================
				Call prvcmdReserveJRegistEnabled_Chk()

                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier4.Name Then
                    Call pubSetFocus(cmdCarrierSelect1)
                End If
            Else
                '@結果：異常の場合
                
                '@ｷｬﾘｱIDの退避ｸﾘｱ
                mstrToCarrier4 = vbNullString
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@ﾌｫｰｶｽは保持
                e.Cancel = True
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier4_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	Private Sub cmdReserveJRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReserveJRegist.Click
        
        Dim lblnAns As Boolean
        Dim lintRow As Integer
		Dim lstrReserveId As String
		Dim ltypAfterJReserveDetailList As List(Of typAfterJReserveDetail)
        
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
			ltypAfterJReserveDetailList = New List(Of typAfterJReserveDetail)
			'@=======================
            '@ 確定前ﾁｪｯｸ処理&情報格納
            '@=======================
            lblnAns = prvblnReserveJRegist_Chk(ltypAfterJReserveDetailList)
			
			'@確定前ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If

            '作業者コード入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '中止の場合
            If pblnCancel = True Then
                Exit Sub
            End If


            IF ltypAfterJReserveDetailList.Count = 0 Then
                'Public Const CPstrMsgInf0082        As String = "<TRM82I>$$登録データがありませんでした。$設定を確認してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0082)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If
            
            'レスポンス開始
            Dim lstrEventName As String = "cmdReserveJRegist_Click"
            Call pubResponseStart(Me.Name, lstrEventName)

            '蒸着後流動予約登録
            lblnAns = pubblnAfterJReserveRegist_Ins(CMstrlot_afterjrsvregistVer, CMstrRegistTypeIns, lblLotID1.Text ,ltypAfterJReserveDetailList, lstrReserveId)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)

                Call pubSetFocus(txtCarrier)
                Exit Sub
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '端末メッセージ表示
            '"<TRM89I>$$蒸着後流動予約[ID:%1]を[%2]しました。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0089, lstrReserveId, "登録")
            Call pubVsfInfo_Disp(pstrDMsg)
            
			'画面初期化
			Call prvTab3_Init()

            Call pubSetFocus(txtCarrier)
   
            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRegist_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            Call pubOnError_Proc()
            
        End Try
    End Sub


	Private Sub cmdReserveJDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReserveJDel.Click
        
        Dim lblnAns As Boolean
        Dim lintRow As Integer
		Dim lstrReserveId As String
		Dim ltypAfterJReserveDetailList As List(Of typAfterJReserveDetail)
        
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

			ltypAfterJReserveDetailList = New List(Of typAfterJReserveDetail)
			'@=======================
            '@ 削除前ﾁｪｯｸ処理&情報格納
            '@=======================
            lblnAns = prvblnReserveJDel_Chk(ltypAfterJReserveDetailList, lstrReserveId)
			
			'@確定前ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If

            '作業者コード入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '中止の場合
            If pblnCancel = True Then
                Exit Sub
            End If

            IF lstrReserveId = "" Then
                'Public Const CPstrMsgInf0082        As String = "<TRM82I>$$登録データがありませんでした。$設定を確認してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0082)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If
            
            'レスポンス開始
            Dim lstrEventName As String = "cmdReserveJDel_Click"
            Call pubResponseStart(Me.Name, lstrEventName)

            '蒸着後流動予約削除
            lblnAns = pubblnAfterJReserveRegist_Ins(CMstrlot_afterjrsvregistVer, CMstrRegistTypeDel, lblLotID1.Text ,ltypAfterJReserveDetailList, lstrReserveId)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)

                Call pubSetFocus(vsfSlotMap)
                Exit Sub
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '端末メッセージ表示
            '"<TRM89I>$$蒸着後流動予約[ID:%1]を[%2]しました。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0089, lstrReserveId, "削除")
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '最新取得
            '最新情報取得
			'If Not prvUpdateAfterJReserveInfo() Then
			'	Exit sub
			'End If 
    
			'画面初期化
			Call prvTab3_Init

            Call pubSetFocus(txtCarrier)
   
            Exit Sub
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdReserveJDel_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            Call pubOnError_Proc()
            
        End Try
    End Sub

	'関数名：vsfSlotMap_Click
    '機　能：元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub vsfSlotMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.Click
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If

            With vsfSlotMap
                
                '@ﾀｲﾄﾙ以外か
                If .Row > 0 Then
                    
                    '@選択行のWFIDがNULL以外か
                    If .GetData(.Row, CMlngvsfSlotMapWfId) <> vbNullString Then
                        
                        '@選択行のWFIDの文字色が黒色か
                        If .GetCellRange(.Row, CMlngvsfSlotMapWfId).StyleDisplay.ForeColor = SystemColors.WindowText Then
                        
                            '@退避構造体へ選択行の情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapWfId)          'WFID
							mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapBNo)			'通し番号

                        Else
                            '@文字色がｸﾞﾚｰの場合
                            
                            '@退避：移載元№と同じ場合
                            If mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapBNo) Then
                                
                                '@=======================
                                '@　ｸﾞﾘｯﾄﾞ反映処理
                                '@=======================
                                Call prvVsfSlotMapCell_Proc(vsfSlotMap, .Row)
                            End If
                        End If
                    End If
                End If
            End With
            

            
            '@=======================
            '@　ﾃｷｽﾄﾎﾞｯｸｽ、ｷｬﾘｱ選択ﾎﾞﾀﾝ制御処理
            '@=======================
            'Call prvCarrierControl_Proc(vsfToSlotMap1, txtToCarrier1, cmdCarrierSelect1)    'グループA
            'Call prvCarrierControl_Proc(vsfToSlotMap2, txtToCarrier2, cmdCarrierSelect2)    'グループB
            'Call prvCarrierControl_Proc(vsfToSlotMap3, txtToCarrier3, cmdCarrierSelect3)    'グループC
            'Call prvCarrierControl_Proc(vsfToSlotMap4, txtToCarrier4, cmdCarrierSelect4)    'グループD

            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvcmdReserveJRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfSlotMap_LostFocus
    '機　能：元ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　LostFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub vsfSlotMap_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.Leave
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            'NSYS ヘッダー選択時処理を抜ける
            If vsfSlotMap.Row < vsfSlotMap.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽが抜ける段階で退避構造体と選択ｾﾙの内容が異なる場合、
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfSlotMap
                
                '@選択行のWFIDがNULL以外か
                If .GetData(.Row, CMlngvsfSlotMapWfID) <> vbNullString Then
                    
                    '@選択行のWFIDの文字色が黒色か
                    If .GetCellRange(.Row, CMlngvsfSlotMapWfID).StyleDisplay.ForeColor = SystemColors.WindowText Then
                        
                        '@退避構造体のWFIDと選択行のWFIDが異なるか
                        If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfSlotMapWfID) Then
                        
                            '@退避構造体へ情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfSlotMapWfID)          'WFID
							mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfSlotMapBNo)          '通し番号
                        End If
                    Else
                        '@選択行のWFIDの文字色が黒色以外の場合
                        
                        '@退避構造体のWFIDと選択行のWFIDが異なるか
                        If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfSlotMapWfID) Then
                            
                            '@退避構造体の情報をｸﾘｱ
                            mtypTransfer.strWfId = vbNullString         'WFID
							mtypTransfer.lngSlotNo = 0          '通し番号

                        End If
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSlotMap_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap1_Click
    '機　能：グループAｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap1.Rows.Count <= vsfToSlotMap1.Rows.Fixed Then
                Return
            End If

            '@選択処理
            With vsfToSlotMap1
                
                '@ﾀｲﾄﾙ以外
                If .Row > 0 Then
                    
                    '@背景色が白の場合
                    If .GetCellRange(.Row, CMlngvsfToSlotMap1WfId).Style.BackColor = vbWhite Then
                        
                        '@空欄の場合
                        If .GetData(.Row, CMlngvsfToSlotMap1WfId) = vbNullString Then
                            
                            '@=======================
                            '@　ｸﾞﾘｯﾄﾞ反映処理
                            '@=======================
                            Call prvVsfSlotMapCell_Proc(vsfToSlotMap1, .Row)
                        Else
                            '@退避構造体へ情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap1WfId)                  'WF_ID
							mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap1BNo)          '通し番号
                        End If
                    End If
                End If
            End With
            
            
            '@=======================
            '@　ﾃｷｽﾄﾎﾞｯｸｽ活性化処理
            '@=======================
           ' Call prvCarrierControl_Proc(vsfToSlotMap1, txtToCarrier1, cmdCarrierSelect1)    'グループA
           ' Call prvCarrierControl_Proc(vsfToSlotMap2, txtToCarrier2, cmdCarrierSelect2)    'グループB
           ' Call prvCarrierControl_Proc(vsfToSlotMap3, txtToCarrier3, cmdCarrierSelect3)    'グループC
           ' Call prvCarrierControl_Proc(vsfToSlotMap4, txtToCarrier4, cmdCarrierSelect4)    'グループD
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvcmdReserveJRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap1_GotFocus
    '機　能：
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap1_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap1.Enter

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap1.Rows.Count <= vsfToSlotMap1.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfToSlotMap1.Row < vsfToSlotMap1.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽがあたった段階で,退避構造体がNullの場合には,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfToSlotMap1
                
                '@退避構造体がNullの場合
                If mtypTransfer.strWfId = vbNullString Then
                    
                    '@選択行が空欄でない場合
                    If .GetData(.Row, CMlngvsfToSlotMap1WfID) <> vbNullString Then
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap1WfID)                  'WF_ID
						mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap1BNo)          '通し番号
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap1_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap1_LostFocus
    '機　能：分割予約1ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　LostFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap1.Leave

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap1.Rows.Count <= vsfToSlotMap1.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfToSlotMap1.Row < vsfToSlotMap1.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽが抜ける段階で,退避構造体と選択ｾﾙの内容が異なる場合,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfToSlotMap1
                
                '@選択行が空欄でない場合
                If .GetData(.Row, CMlngvsfToSlotMap1WfID) <> vbNullString Then
                    
                    '@退避構造体と選択行の内容が異なる場合
                    If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfToSlotMap1WfID) Then
                        
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap1WfID)                  'WF_ID
						mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap1BNo)          '通し番号
                    End If
                Else
                    '@退避構造体の情報をｸﾘｱ
                    mtypTransfer.strWfId = vbNullString                                                         'WF_ID
					mtypTransfer.lngSlotNo = 0          '通し番号
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap1_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfToSlotMap2_Click
    '機　能：グループAｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap2.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap2.Rows.Count <= vsfToSlotMap2.Rows.Fixed Then
                Return
            End If

            '@選択処理
            With vsfToSlotMap2
                
                '@ﾀｲﾄﾙ以外
                If .Row > 0 Then
                    
                    '@背景色が白の場合
                    If .GetCellRange(.Row, CMlngvsfToSlotMap2WfId).Style.BackColor = vbWhite Then
                        
                        '@空欄の場合
                        If .GetData(.Row, CMlngvsfToSlotMap2WfId) = vbNullString Then
                            
                            '@=======================
                            '@　ｸﾞﾘｯﾄﾞ反映処理
                            '@=======================
                            Call prvVsfSlotMapCell_Proc(vsfToSlotMap2, .Row)
                        Else
                            '@退避構造体へ情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap2WfId)                  'WF_ID
							mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap2BNo)          '通し番号
                        End If
                    End If
                End If
            End With
            
            
            '@=======================
            '@　ﾃｷｽﾄﾎﾞｯｸｽ活性化処理
            '@=======================
           ' Call prvCarrierControl_Proc(vsfToSlotMap1, txtToCarrier1, cmdCarrierSelect1)    'グループA
           ' Call prvCarrierControl_Proc(vsfToSlotMap2, txtToCarrier2, cmdCarrierSelect2)    'グループB
           ' Call prvCarrierControl_Proc(vsfToSlotMap3, txtToCarrier3, cmdCarrierSelect3)    'グループC
           ' Call prvCarrierControl_Proc(vsfToSlotMap4, txtToCarrier4, cmdCarrierSelect4)    'グループD
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvcmdReserveJRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap2_GotFocus
    '機　能：
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap2_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap2.Enter

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap2.Rows.Count <= vsfToSlotMap2.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfToSlotMap2.Row < vsfToSlotMap2.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽがあたった段階で,退避構造体がNullの場合には,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfToSlotMap2
                
                '@退避構造体がNullの場合
                If mtypTransfer.strWfId = vbNullString Then
                    
                    '@選択行が空欄でない場合
                    If .GetData(.Row, CMlngvsfToSlotMap2WfID) <> vbNullString Then
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap2WfID)                  'WF_ID
						mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap2BNo)          '通し番号
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap2_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap2_LostFocus
    '機　能：分割予約1ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　LostFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap2.Leave

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap2.Rows.Count <= vsfToSlotMap2.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfToSlotMap2.Row < vsfToSlotMap2.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽが抜ける段階で,退避構造体と選択ｾﾙの内容が異なる場合,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfToSlotMap2
                
                '@選択行が空欄でない場合
                If .GetData(.Row, CMlngvsfToSlotMap2WfID) <> vbNullString Then
                    
                    '@退避構造体と選択行の内容が異なる場合
                    If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfToSlotMap2WfID) Then
                        
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap2WfID)                  'WF_ID
						mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap2BNo)          '通し番号

                    End If
                Else
                    '@退避構造体の情報をｸﾘｱ
                    mtypTransfer.strWfId = vbNullString                                                         'WF_ID
					mtypTransfer.lngSlotNo = 0         '通し番号
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap2_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfToSlotMap3_Click
    '機　能：グループAｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap3.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap3.Rows.Count <= vsfToSlotMap3.Rows.Fixed Then
                Return
            End If

            '@選択処理
            With vsfToSlotMap3
                
                '@ﾀｲﾄﾙ以外
                If .Row > 0 Then
                    
                    '@背景色が白の場合
                    If .GetCellRange(.Row, CMlngvsfToSlotMap3WfId).Style.BackColor = vbWhite Then
                        
                        '@空欄の場合
                        If .GetData(.Row, CMlngvsfToSlotMap3WfId) = vbNullString Then
                            
                            '@=======================
                            '@　ｸﾞﾘｯﾄﾞ反映処理
                            '@=======================
                            Call prvVsfSlotMapCell_Proc(vsfToSlotMap3, .Row)
                        Else
                            '@退避構造体へ情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap3WfId)                  'WF_ID
							mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap3BNo)          '通し番号
                        End If
                    End If
                End If
            End With
            
            
            '@=======================
            '@　ﾃｷｽﾄﾎﾞｯｸｽ活性化処理
            '@=======================
            ' Call prvCarrierControl_Proc(vsfToSlotMap1, txtToCarrier1, cmdCarrierSelect1)    'グループA
           ' Call prvCarrierControl_Proc(vsfToSlotMap2, txtToCarrier2, cmdCarrierSelect2)    'グループB
           ' Call prvCarrierControl_Proc(vsfToSlotMap3, txtToCarrier3, cmdCarrierSelect3)    'グループC
           ' Call prvCarrierControl_Proc(vsfToSlotMap4, txtToCarrier4, cmdCarrierSelect4)    'グループD
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvcmdReserveJRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap3_GotFocus
    '機　能：
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap3_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap3.Enter

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap3.Rows.Count <= vsfToSlotMap3.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfToSlotMap3.Row < vsfToSlotMap3.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽがあたった段階で,退避構造体がNullの場合には,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfToSlotMap3
                
                '@退避構造体がNullの場合
                If mtypTransfer.strWfId = vbNullString Then
                    
                    '@選択行が空欄でない場合
                    If .GetData(.Row, CMlngvsfToSlotMap3WfID) <> vbNullString Then
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap3WfID)                  'WF_ID
						mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap3BNo)          '通し番号
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap3_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap3_LostFocus
    '機　能：分割予約1ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　LostFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap3_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap3.Leave

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap3.Rows.Count <= vsfToSlotMap3.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfToSlotMap3.Row < vsfToSlotMap3.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽが抜ける段階で,退避構造体と選択ｾﾙの内容が異なる場合,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfToSlotMap3
                
                '@選択行が空欄でない場合
                If .GetData(.Row, CMlngvsfToSlotMap3WfID) <> vbNullString Then
                    
                    '@退避構造体と選択行の内容が異なる場合
                    If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfToSlotMap3WfID) Then
                        
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap3WfID)                  'WF_ID
						mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap3BNo)          '通し番号
                    End If
                Else
                    '@退避構造体の情報をｸﾘｱ
                    mtypTransfer.strWfId = vbNullString                                                         'WF_ID
					mtypTransfer.lngSlotNo = 0          '通し番号
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap3_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：vsfToSlotMap4_Click
    '機　能：グループAｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap4.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap4.Rows.Count <= vsfToSlotMap4.Rows.Fixed Then
                Return
            End If

            '@選択処理
            With vsfToSlotMap4
                
                '@ﾀｲﾄﾙ以外
                If .Row > 0 Then
                    
                    '@背景色が白の場合
                    If .GetCellRange(.Row, CMlngvsfToSlotMap4WfId).Style.BackColor = vbWhite Then
                        
                        '@空欄の場合
                        If .GetData(.Row, CMlngvsfToSlotMap4WfId) = vbNullString Then
                            
                            '@=======================
                            '@　ｸﾞﾘｯﾄﾞ反映処理
                            '@=======================
                            Call prvVsfSlotMapCell_Proc(vsfToSlotMap4, .Row)
                        Else
                            '@退避構造体へ情報をｾｯﾄ
                            mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap4WfId)                  'WF_ID
							mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap4BNo)          '通し番号
                        End If
                    End If
                End If
            End With
            
            
            '@=======================
            '@　ﾃｷｽﾄﾎﾞｯｸｽ活性化処理
            '@=======================
            'Call prvCarrierControl_Proc(vsfToSlotMap1, txtToCarrier1, cmdCarrierSelect1)    'グループA
            'Call prvCarrierControl_Proc(vsfToSlotMap2, txtToCarrier2, cmdCarrierSelect2)    'グループB
            'Call prvCarrierControl_Proc(vsfToSlotMap3, txtToCarrier3, cmdCarrierSelect3)    'グループC
            'Call prvCarrierControl_Proc(vsfToSlotMap4, txtToCarrier4, cmdCarrierSelect4)    'グループD
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvcmdReserveJRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap4_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap4_GotFocus
    '機　能：
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap4_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap4.Enter

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap4.Rows.Count <= vsfToSlotMap4.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfToSlotMap4.Row < vsfToSlotMap4.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽがあたった段階で,退避構造体がNullの場合には,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfToSlotMap4
                
                '@退避構造体がNullの場合
                If mtypTransfer.strWfId = vbNullString Then
                    
                    '@選択行が空欄でない場合
                    If .GetData(.Row, CMlngvsfToSlotMap4WfID) <> vbNullString Then
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap4WfID)                  'WF_ID
						mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap4BNo)          '通し番号
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap4_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfToSlotMap4_LostFocus
    '機　能：分割予約1ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　LostFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub vsfToSlotMap4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles vsfToSlotMap4.Leave

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfToSlotMap4.Rows.Count <= vsfToSlotMap4.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダー選択時処理を抜ける
            If vsfToSlotMap4.Row < vsfToSlotMap4.Rows.Fixed Then
                Return
            End If

            '@ﾌｫｰｶｽが抜ける段階で,退避構造体と選択ｾﾙの内容が異なる場合,
            '@現在選択されているｽﾛｯﾄの情報を退避する
            With vsfToSlotMap4
                
                '@選択行が空欄でない場合
                If .GetData(.Row, CMlngvsfToSlotMap4WfID) <> vbNullString Then
                    
                    '@退避構造体と選択行の内容が異なる場合
                    If mtypTransfer.strWfId <> .GetData(.Row, CMlngvsfToSlotMap4WfID) Then
                        
                        '@退避構造体へ情報をｾｯﾄ
                        mtypTransfer.strWfId = .GetData(.Row, CMlngvsfToSlotMap4WfID)                  'WF_ID
						mtypTransfer.lngSlotNo = .GetData(.Row, CMlngvsfToSlotMap4BNo)          '通し番号

                    End If
                Else
                    '@退避構造体の情報をｸﾘｱ
                    mtypTransfer.strWfId = vbNullString                                                         'WF_ID
					mtypTransfer.lngSlotNo = 0          '通し番号
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfToSlotMap4_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


	'関数名：cmdCarrierSelect1_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ(分割予約1)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub cmdCarrierSelect1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect1.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　空きｷｬﾘｱ選択画面起動処理
            '@=======================
            Call prvLoadCarrierSelect_Proc(cmdCarrierSelect1)
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	
	'関数名：cmdCarrierSelect2_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ(分割予約1)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub cmdCarrierSelect2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect2.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　空きｷｬﾘｱ選択画面起動処理
            '@=======================
            Call prvLoadCarrierSelect_Proc(cmdCarrierSelect2)
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect2_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	
	'関数名：cmdCarrierSelect3_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ(分割予約1)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub cmdCarrierSelect3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect3.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　空きｷｬﾘｱ選択画面起動処理
            '@=======================
            Call prvLoadCarrierSelect_Proc(cmdCarrierSelect3)
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect3_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	
	'関数名：cmdCarrierSelect4_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ(分割予約1)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub cmdCarrierSelect4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect4.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　空きｷｬﾘｱ選択画面起動処理
            '@=======================
            Call prvLoadCarrierSelect_Proc(cmdCarrierSelect4)
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect4_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmd5wf_Click
    '機　能：一括5wfﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmd5wf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd5wf.Click

        Dim llngCnt             As Integer      'ｶｳﾝﾀ
		Dim llngWfCnt			As Integer
        Dim lblnNGWfFlag		As Boolean      'WF_ID21~25判定ﾌﾗｸﾞ
		Dim ltypWfList			As List(Of SlotPosition)

		

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfSlotMap
				lblnNGWfFlag = False
				llngWfCnt = 0
				ltypWfList	= New List(Of SlotPosition)

                '@分割元ｽﾛｯﾄﾏｯﾌﾟを上から
                For llngCnt = 1 To 25
					
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄ№#21_25のWFIDが存在するか

					Dim last2 As Integer
                    If .GetData(llngCnt, CMlngvsfSlotMapWfId) <> vbNullString Then

						Dim tmp As SlotPosition
						tmp.strWfId = .GetData(llngCnt, CMlngvsfSlotMapWfId)
						tmp.lngSlotNo = .GetData(llngCnt, CMlngvsfSlotMapBNo)
						ltypWfList.Add(tmp)
						llngWfCnt = llngWfCnt + 1

					End If
                Next llngCnt

				'WFが21枚以上ある場合は4分割できないため手動分割を促すメッセージを表示
				If 	llngWfCnt >= 21	 Then			
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0191)
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					Exit Sub
				End If
                
				'WFが0件の場合は終了
				If llngWfCnt < 1 Then
					Exit Sub
				End If

				'WFID順に昇順ｿｰﾄ
				'ltypWfList = ltypWfList.OrderBy(Function(x) x.strWFID).ToList()

				'スロットマップクリア
				'Call prvvsfSlotMap1_4_Clear()
				For row As Integer = 1 To vsfToSlotMap1.Rows.Count - 1

					vsfToSlotMap1.SetData(row, CMlngvsfToSlotMap1WfId, "")
					vsfToSlotMap2.SetData(row, CMlngvsfToSlotMap2WfId, "")
					vsfToSlotMap3.SetData(row, CMlngvsfToSlotMap3WfId, "")
					vsfToSlotMap4.SetData(row, CMlngvsfToSlotMap4WfId, "")
					vsfToSlotMap1.SetData(row, CMlngvsfToSlotMap1BNo, 0)
					vsfToSlotMap2.SetData(row, CMlngvsfToSlotMap2BNo, 0)
					vsfToSlotMap3.SetData(row, CMlngvsfToSlotMap3BNo, 0)
					vsfToSlotMap4.SetData(row, CMlngvsfToSlotMap4BNo, 0)
				Next

                '@Aグループへの設定ｽﾛｯﾄ№05-01分ﾙｰﾌﾟ
				llngCnt = 0


				' スロット番号の定義（順番が意味を持つ）
				Dim slotList() As Integer = {16, 18, 20, 22, 24}

				For llngCnt = 0 To llngWfCnt - 1

					Dim wfId As String = ltypWfList(llngCnt).strWfId
					Dim BNo As Integer = ltypWfList(llngCnt).lngSlotNo
					' 末尾2桁 → 数値
					Dim wfNo As Integer
					If wfId.Length < 2 OrElse
					   Not Integer.TryParse(wfId.Substring(wfId.Length - 2), wfNo) Then
						Continue For
					End If

					If wfNo < 1 OrElse wfNo > 20 Then Continue For

					' Map番号（0～3）
					Dim mapIndex As Integer = (wfNo - 1) \ 5

					' Slot番号
					Dim slotNo As Integer = slotList((wfNo - 1) Mod 5)

					' 対象Map取得
					Dim targetMap As Object
					Dim WfIdCol As Integer
					Dim BNoCol As Integer
					Select Case mapIndex
						Case 0
							targetMap = vsfToSlotMap1
							WfIdCol = CMlngvsfToSlotMap1WfId
							BNoCol = CMlngvsfToSlotMap1BNo
						Case 1
							targetMap = vsfToSlotMap2
							WfIdCol = CMlngvsfToSlotMap2WfId
							BNoCol = CMlngvsfToSlotMap2BNo
						Case 2
							targetMap = vsfToSlotMap3
							WfIdCol = CMlngvsfToSlotMap3WfId
							BNoCol = CMlngvsfToSlotMap3BNo
						Case 3
							targetMap = vsfToSlotMap4
							WfIdCol = CMlngvsfToSlotMap4WfId
							BNoCol = CMlngvsfToSlotMap4BNo
						Case Else
							Continue For
					End Select

					'指定の箇所が埋まっている場合
					If targetMap.GetData(slotNo, WfIdCol) <> vbNullString And targetMap.GetData(slotNo, WfIdCol) <> "" Then
						pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0192)
						Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
						For row As Integer = 1 To vsfToSlotMap1.Rows.Count - 1
							vsfToSlotMap1.SetData(row, CMlngvsfToSlotMap1WfId, "")
							vsfToSlotMap2.SetData(row, CMlngvsfToSlotMap2WfId, "")
							vsfToSlotMap3.SetData(row, CMlngvsfToSlotMap3WfId, "")
							vsfToSlotMap4.SetData(row, CMlngvsfToSlotMap4WfId, "")
							vsfToSlotMap1.SetData(row, CMlngvsfToSlotMap1BNo, 0)
							vsfToSlotMap2.SetData(row, CMlngvsfToSlotMap2BNo, 0)
							vsfToSlotMap3.SetData(row, CMlngvsfToSlotMap3BNo, 0)
							vsfToSlotMap4.SetData(row, CMlngvsfToSlotMap4BNo, 0)
						Next
						Exit Sub
					End If

					targetMap.SetData(slotNo, WfIdCol, wfId)
					targetMap.SetData(slotNo, BNoCol, BNo)

				Next

     
            End With

            With vsfSlotMap
            
                For llngCnt = 1 To .Rows.Count - 1
					If .GetData(llngCnt,CMlngvsfSlotMapWfID) <> vbNullString And  .GetData(llngCnt,CMlngvsfSlotMapWfID) <> "" Then
						Dim newStyle    As CellStyle    
						Dim cellRange   As CellRange    

						'@元ｽﾛｯﾄﾏｯﾌﾟの対象行の文字色をｸﾞﾚｰにする
						newStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor")
						newStyle.BackColor = vbWhite
						newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
						cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapWfID, llngCnt, CMlngvsfSlotMapCarrierId)
						cellRange.Style = newStyle
					End if

                Next llngCnt
            End With

				

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd5wf_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：cmd10wf_Click
    '機　能：一括10wfﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub cmd10wf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmd10wf.Click

        Dim llngCnt             As Integer      'ｶｳﾝﾀ
		Dim llngWfCnt			As Integer
        Dim lblnNGWfFlag		As Boolean      'WF_ID21~25判定ﾌﾗｸﾞ
		Dim ltypWfList			As List(Of SlotPosition)

		

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfSlotMap
				lblnNGWfFlag = False
				llngWfCnt = 0
				ltypWfList	= New List(Of SlotPosition)

                '@分割元ｽﾛｯﾄﾏｯﾌﾟを上から
                For llngCnt = 1 To 25
					
                    '@分割元ｽﾛｯﾄﾏｯﾌﾟにて、ｽﾛｯﾄ№#21_25のWFIDが存在するか
					Dim last2 As Integer
                    If .GetData(llngCnt, CMlngvsfSlotMapWfId) <> vbNullString Then

						Dim tmp As SlotPosition
						tmp.strWfId = .GetData(llngCnt, CMlngvsfSlotMapWfId)
						tmp.lngSlotNo = .GetData(llngCnt, CMlngvsfSlotMapBNo)
						ltypWfList.Add(tmp)
						llngWfCnt = llngWfCnt + 1

					End If
                Next llngCnt

				'WFが21枚以上ある場合は4分割できないため手動分割を促すメッセージを表示
				If 	llngWfCnt >= 21	 Then			
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0191)
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					Exit Sub
				End If
                
				'WFが0件の場合は終了
				If llngWfCnt < 1 Then
					Exit Sub
				End If

				'WFID順に昇順ｿｰﾄ
				ltypWfList = ltypWfList.OrderBy(Function(x) x.strWFID).ToList()

				'スロットマップクリア
				'Call prvvsfSlotMap1_4_Clear()
				For row As Integer = 1 To vsfToSlotMap1.Rows.Count - 1

					vsfToSlotMap1.SetData(row, CMlngvsfToSlotMap1WfId, "")
					vsfToSlotMap2.SetData(row, CMlngvsfToSlotMap2WfId, "")
					vsfToSlotMap3.SetData(row, CMlngvsfToSlotMap3WfId, "")
					vsfToSlotMap4.SetData(row, CMlngvsfToSlotMap4WfId, "")
					vsfToSlotMap1.SetData(row, CMlngvsfToSlotMap1BNo, 0)
					vsfToSlotMap2.SetData(row, CMlngvsfToSlotMap2BNo, 0)
					vsfToSlotMap3.SetData(row, CMlngvsfToSlotMap3BNo, 0)
					vsfToSlotMap4.SetData(row, CMlngvsfToSlotMap4BNo, 0)
				Next

                '@Aグループへの設定ｽﾛｯﾄ№05-01分ﾙｰﾌﾟ
				llngCnt = 0


				' スロット番号の定義（順番が意味を持つ）
				Dim slotList() As Integer = {6, 8, 10, 12, 14, 16, 18, 20, 22, 24}

				For llngCnt = 0 To llngWfCnt - 1

					Dim wfId As String = ltypWfList(llngCnt).strWfId
					Dim BNo As Integer = ltypWfList(llngCnt).lngSlotNo

					' 末尾2桁 → 数値
					Dim wfNo As Integer
					If wfId.Length < 2 OrElse
					   Not Integer.TryParse(wfId.Substring(wfId.Length - 2), wfNo) Then
						Continue For
					End If

					If wfNo < 1 OrElse wfNo > 20 Then Continue For

					' Map番号（0～3）
					Dim mapIndex As Integer = (wfNo - 1) \ 10

					' Slot番号
					Dim slotNo As Integer = slotList((wfNo - 1) Mod 10)

					' 対象Map取得
					Dim targetMap As Object
					Dim WfIdCol As Integer
					Dim BNoCol As Integer
					Select Case mapIndex
						Case 0
							targetMap = vsfToSlotMap1
							WfIdCol = CMlngvsfToSlotMap1WfId
							BNoCol = CMlngvsfToSlotMap1BNo
						Case 1
							targetMap = vsfToSlotMap2
							WfIdCol = CMlngvsfToSlotMap2WfId
							BNoCol = CMlngvsfToSlotMap2BNo
						Case 2
							targetMap = vsfToSlotMap3
							WfIdCol = CMlngvsfToSlotMap3WfId
							BNoCol = CMlngvsfToSlotMap3BNo
						Case 3
							targetMap = vsfToSlotMap4
							WfIdCol = CMlngvsfToSlotMap4WfId
							BNoCol = CMlngvsfToSlotMap4BNo
						Case Else
							Continue For
					End Select

					'指定の箇所が埋まっている場合
					If targetMap.GetData(slotNo, WfIdCol) <> vbNullString And targetMap.GetData(slotNo, WfIdCol) <> "" Then
						pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0192)
						Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
						'スロットマップクリア
						For row As Integer = 1 To vsfToSlotMap1.Rows.Count - 1

							vsfToSlotMap1.SetData(row, CMlngvsfToSlotMap1WfId, "")
							vsfToSlotMap2.SetData(row, CMlngvsfToSlotMap2WfId, "")
							vsfToSlotMap3.SetData(row, CMlngvsfToSlotMap3WfId, "")
							vsfToSlotMap4.SetData(row, CMlngvsfToSlotMap4WfId, "")
							vsfToSlotMap1.SetData(row, CMlngvsfToSlotMap1BNo, 0)
							vsfToSlotMap2.SetData(row, CMlngvsfToSlotMap2BNo, 0)
							vsfToSlotMap3.SetData(row, CMlngvsfToSlotMap3BNo, 0)
							vsfToSlotMap4.SetData(row, CMlngvsfToSlotMap4BNo, 0)
						Next
						Exit Sub
					End If

					targetMap.SetData(slotNo, WfIdCol, wfId)
					targetMap.SetData(slotNo, BNoCol, BNo)
				Next
			End With

            With vsfSlotMap
            
                For llngCnt = 1 To .Rows.Count - 1
					If .GetData(llngCnt,CMlngvsfSlotMapWfID) <> vbNullString And  .GetData(llngCnt,CMlngvsfSlotMapWfID) <> "" Then
						Dim newStyle    As CellStyle    
						Dim cellRange   As CellRange    

						'@元ｽﾛｯﾄﾏｯﾌﾟの対象行の文字色をｸﾞﾚｰにする
						newStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor")
						newStyle.BackColor = vbWhite
						newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
						cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapWfID, llngCnt, CMlngvsfSlotMapCarrierId)
						cellRange.Style = newStyle
					End if

                Next llngCnt
            End With

				
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmd10wf_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：cmdAfterJReserveList_Click
    '機　能：　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub cmdAfterJReserveList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAfterJReserveList.Click

		Dim lblnAns  As Boolean
		Dim ltypAfterJReserveDetailList     As AfterJReserveDetailList '蒸着後流動予約情報詳細格納用構造体
		Dim ltypLotCurState                 As Lotprestate					'ﾛｯﾄ現在状態格納構造体

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@引渡し用予約ID初期化
            pstrReserveId = vbNullString
			pstrLotId = vbNullString

            pblnfrmxxEN02U0Kbn = True
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　蒸着後流動予約一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN02U1.Instance = New frmxxEN02U1()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxEN02U1.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　蒸着後流動予約一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN02U1.Instance.ShowDialog(Me)
            frmxxEN02U1.Instance = Nothing
            
			pblnfrmxxEN02U0Kbn = False

            '@予約IDが選択されている場合
            If pstrReserveId <> vbNullString Then

                '@予約IDｾｯﾄ
				lblReserveStatus2.Text = pstrReserveId
				'ロットIDセット
				lblLotId1.Text = pstrLotId
 
				'空リストを渡す
				Dim ltypWaferList As New WaferList
				ltypWaferList.typWfList = New List(Of WfList)
                    
                '@取得OKなら既に蒸着後流動予約があるか確認
				lblnAns = pubblnGetAfterJReserveDetail(CMstrlot_afterjrsvdetailVer, "", "", lblReserveStatus2.Text, "", CPstrCD4W, _
													ltypWaferList.typWfList, ltypAfterJReserveDetailList)
  				'@結果確認
				If lblnAns = True Then
					
			
					 '@画面初期化
					Call prvTab3_Init()
					
					'@予約IDｾｯﾄ
					lblReserveStatus2.Text = pstrReserveId
					'ロットIDセット
					lblLotId1.Text = pstrLotId


					pstrLotId = vbNullString
					pstrReserveId = vbNullString

					If ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt > 0　 Then
						'1件以上取得できた場合は予約済みとする
						'@取得OKなら結果表示
						Call prvVsfSlotMap_Disp(ltypWaferList, vsfSlotMap, ltypAfterJReserveDetailList, True)
						Call prvcmdReserveJRegistEnabled_Chk
					Else
						'エラー
						'@"<TRM196W>$$予約情報が見つかりませんでした。データを確認してください。"
						pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0196)
						Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
						pubSetFocus(txtCarrier)
						Exit Sub
					End If


					'@変更ﾌﾗｸﾞｾｯﾄ
					mblnTxtCarrierChange = False    '無変更

					'@ﾚｽﾎﾟﾝｽ測定終了
					Call publngResponseEnd(Me.Name, mstrEventName)

					If ActiveControl.Name = txtCarrier.Name Then
						If vsfSlotMap.Enabled = True Then
							'@スロットマップにﾌｫｰｶｽｾｯﾄ
							Call pubSetFocus(txtCarrier)
						Else
							'@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
							Call pubSetFocus(cmdClose)
						End If
					End If

				Else

					'エラーメッセージ?
					Exit Sub
			
				End If
			Else

			End If
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
   

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect1_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


	'関数名：prvLoadCarrierSelect_Proc
    '機　能：空きｷｬﾘｱ選択画面起動処理
    '引　数：lctlcmdcontrol：ｺﾏﾝﾄﾞﾎﾞﾀﾝｺﾝﾄﾛｰﾙ
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvLoadCarrierSelect_Proc(ByRef lctlcmdcontrol As Button)

        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　空きｷｬﾘｱ選択画面の起動処理を行う。また、処理が戻された際は引継ぎｺﾝﾄﾛｰﾙを
            '@　判定し、対象ｷｬﾘｱIDの処理を行う
            '@****************************************************************************

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し(FOUP限定)
            pstrCarrierTypeID = CPstrCarrTypeFOUP
            
            '@ｷｬﾘｱの洗浄条件：未洗浄不可
            pstrCleanCondition = CPstrCarrierClean2


            
            '@初期化
            pstrCarrierID = vbNullString
            pblnfrmxxEN02U0Kbn = True
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　空きｷｬﾘｱ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00K0.Instance = New frmxxCM00K0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
            
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxCM00K0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　空きｷｬﾘｱ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing
            
			pblnfrmxxEN02U0Kbn = False

            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                
                '@呼び元が予約1か
                If lctlcmdcontrol.Name = cmdCarrierSelect1.Name Then
                
                    '@予約1ｷｬﾘｱIDにｾｯﾄ
                    txtToCarrier1.Text = pstrCarrierID
                    
                    '@=======================
                    '@　分割予約1ｷｬﾘｱのValidate処理
                    '@=======================
                    RemoveHandler txtToCarrier1.Validating, AddressOf txtToCarrier1_Validate
                    Call txtToCarrier1_Validate(txtToCarrier1,New CancelEventArgs(True))
                    AddHandler txtToCarrier1.Validating, AddressOf txtToCarrier1_Validate

                    '@予約1ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier1)
                Else If lctlcmdcontrol.Name = cmdCarrierSelect2.Name
                    '@予約2ｷｬﾘｱIDにｾｯﾄ
                    txtToCarrier2.Text = pstrCarrierID
                    
                    '@=======================
                    '@　分割予約2ｷｬﾘｱのValidate処理
                    '@=======================
                    RemoveHandler txtToCarrier2.Validating, AddressOf txtToCarrier2_Validate
                    Call txtToCarrier2_Validate(txtToCarrier2,New CancelEventArgs(True))
                    AddHandler txtToCarrier2.Validating, AddressOf txtToCarrier2_Validate

                    '@分割予約2ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier2)

				Else If lctlcmdcontrol.Name = cmdCarrierSelect3.Name
					'@予約CｷｬﾘｱIDにｾｯﾄ
                    txtToCarrier3.Text = pstrCarrierID
                    
                    '@=======================
                    '@　予約CｷｬﾘｱのValidate処理
                    '@=======================
                    RemoveHandler txtToCarrier3.Validating, AddressOf txtToCarrier3_Validate
                    Call txtToCarrier3_Validate(txtToCarrier3,New CancelEventArgs(True))
                    AddHandler txtToCarrier3.Validating, AddressOf txtToCarrier3_Validate

                    '@予約CｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier3)
				Else
					'@予約CｷｬﾘｱIDにｾｯﾄ
                    txtToCarrier4.Text = pstrCarrierID
                    
                    '@=======================
                    '@　予約CｷｬﾘｱのValidate処理
                    '@=======================
                    RemoveHandler txtToCarrier4.Validating, AddressOf txtToCarrier4_Validate
                    Call txtToCarrier4_Validate(txtToCarrier4,New CancelEventArgs(True))
                    AddHandler txtToCarrier4.Validating, AddressOf txtToCarrier4_Validate

                    '@予約CｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtToCarrier4)

                End If

            End If

            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLoadCarrierSelect_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    ''' <summary>
    ''' アイドル時に呼び出される
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Application_Idle(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.buttonProcessing = False
    End Sub

    ''' <summary>
    ''' 初期化(予約設定)
    ''' </summary>
    Private Sub prvTab0_Init()

        Try
            'ラベル
            lblNowDate0.Text = vbNullString
            lblTFTLotId.Text = vbNullString
            lblCFLotId.Text = vbNullString
            lblTFTCarrierId.Text = vbNullString
            lblCFCarrierId.Text = vbNullString
            lblReserveStatus.Text = vbNullString
            lblTFTLotList.Text = "TFTロット一覧(無機マスクセット装置・作業待ちロットが対象)"
            lblCFLotList.Text = "CFロット一覧(無機マスクセット装置・作業待ちロットが対象)"

            lblTFTLotList.AutoSize = True
            lblCFLotList.AutoSize = True

            'ボタン            
            cmdDel.Enabled = False
            cmdRegist.Enabled = False

            cmdTFTMove.Enabled = False
            cmdTFTMoveCancel.Enabled = False
            cmdCFMove.Enabled = False
            cmdCFMoveCancel.Enabled = False
            
            '*******************
            'グリッド初期化
            '*******************
            'ロットリスト
            Call prvvsfReserveLotList_Init(vsfTFTList)
            Call prvvsfReserveLotList_Init(vsfCFList)
            'WFリスト
            Call prvvsfReserveWfList_Init(vsfTFTWfList)
            Call prvvsfReserveWfList_Init(vsfCFWfList)
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTab0_Init"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' ODF予約のロットTFT/CFロットリスト初期化
    ''' </summary>
    ''' <param name="lobjGrid"></param>
    Private Sub prvvsfReserveLotList_Init(ByRef lobjGrid As C1.Win.C1FlexGrid.C1FlexGrid)

        Try
            'TFT/CF共通(vsfTFTList/vsfCFList)
            With lobjGrid
                
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear(ClearFlags.Content)
                .Redraw = False
                .Cols.Count = 11
                .Rows.Count = .Rows.Fixed
                .SelectionMode = SelectionModeEnum.Row
                .FocusRect = FocusRectEnum.Light
                .HighLight = HighLightEnum.Always
                .Font = New Font(.Font.FontFamily, 12, .Font.Style, .Font.Unit)
                .Rows.DefaultSize = 24  'Row高さ
                .ScrollBars = ScrollBars.Vertical
                .AllowDragging = AllowDraggingEnum.None
                .AllowSorting = AllowSortingEnum.SingleColumn
                .Cols.Frozen = CMlngvsfReserveNo + 1
                
                'ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                '.Styles.Normal.Trimming = StringTrimming.EllipsisCharacter

                '表示位置の設定
                .Cols(CMlngvsfReserveNo).TextAlign = TextAlignEnum.RightCenter          
                .Cols(CMlngvsfReserveStat).TextAlign = TextAlignEnum.LeftCenter            
                .Cols(CMlngvsfReserveStatName).TextAlign = TextAlignEnum.LeftCenter        
                .Cols(CMlngvsfReservePdId).TextAlign = TextAlignEnum.LeftCenter              
                .Cols(CMlngvsfReserveLotId).TextAlign = TextAlignEnum.LeftCenter          
                .Cols(CMlngvsfReserveWfId).TextAlign = TextAlignEnum.LeftCenter            
                .Cols(CMlngvsfReserveCarrierId).TextAlign = TextAlignEnum.LeftCenter              
                .Cols(CMlngvsfReserveFlowClass).TextAlign = TextAlignEnum.LeftCenter            
                .Cols(CMlngvsfReserveSlotPos).TextAlign = TextAlignEnum.LeftCenter                
                .Cols(CMlngvsfReserveFlag).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfReserveWfes).TextAlign = TextAlignEnum.LeftCenter

                'タイトル設定
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveNo, CMstrvsfReserveNoT) 
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveStat, CMstrvsfReserveStatT)  
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveStatName, CMstrvsfReserveStatNameT) 
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReservePdId, CMstrvsfReservePdIdT) 
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveLotId, CMstrvsfReserveLotIdT)
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveWfId, CMstrvsfReserveWfIdT)
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveCarrierId, CMstrvsfReserveCarrierIdT)
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveFlowClass, CMstrvsfReserveFlowClassT)
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveSlotPos, CMstrvsfReserveSlotPosT)
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveFlag, CMstrvsfReserveFlagT)
                .SetData(CMlngvsfGridTitleRow, CMlngvsfReserveWfes, CMstrvsfReserveWfesT)

                '列幅の設定
                .Cols(CMlngvsfReserveNo).Width = CMlngvsfReserveNoW                              
                .Cols(CMlngvsfReserveStat).Width = CMlngvsfReserveStatW              
                .Cols(CMlngvsfReserveStatName).Width = CMlngvsfReserveStatNameW                      
                .Cols(CMlngvsfReservePdId).Width = CMlngvsfReservePdIdW                
                .Cols(CMlngvsfReserveLotId).Width = CMlngvsfReserveLotIdW        
                .Cols(CMlngvsfReserveWfId).Width = CMlngvsfReserveWfIdW            
                .Cols(CMlngvsfReserveCarrierId).Width = CMlngvsfReserveCarrierIdW               
                .Cols(CMlngvsfReserveFlowClass).Width = CMlngvsfReserveFlowClassW            
                .Cols(CMlngvsfReserveSlotPos).Width = CMlngvsfReserveSlotPosW                    
                .Cols(CMlngvsfReserveFlag).Width = CMlngvsfReserveFlagW
                .Cols(CMlngvsfReserveWfes).Width = CMlngvsfReserveWfesW
                
                '隠しCol設定
                .Cols(CMlngvsfReserveNo).Visible = True                             
                .Cols(CMlngvsfReserveStat).Visible = False         
                .Cols(CMlngvsfReserveStatName).Visible = True                    
                .Cols(CMlngvsfReservePdId).Visible = True          
                .Cols(CMlngvsfReserveLotId).Visible = True     
                .Cols(CMlngvsfReserveWfId).Visible = True     
                .Cols(CMlngvsfReserveCarrierId).Visible = True            
                .Cols(CMlngvsfReserveFlowClass).Visible = True           
                .Cols(CMlngvsfReserveSlotPos).Visible = False              
                .Cols(CMlngvsfReserveFlag).Visible = False
                .Cols(CMlngvsfReserveWfes).Visible = False
                
                'タイトルの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfWp_HeaderStyle")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfGridTitleRow, CMlngvsfReserveNo, CMlngvsfGridTitleRow, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                cellRange.Style = newStyle

                '最終colを自動幅設定
                .ExtendLastCol = True
                          
                .LeftCol = 0
                .Redraw = True
                .Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfReserveLotList_Init"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub
    
    ''' <summary>
    ''' ODF予約のWFリスト初期化
    ''' </summary>
    ''' <param name="lobjGrid"></param>
    Private Sub prvvsfReserveWfList_Init(ByRef lobjGrid As C1.Win.C1FlexGrid.C1FlexGrid)

        Try

            'TFT/CF共通(vsfTFTWfList/vsfCFWfList)
            With lobjGrid

                '初期化
                .Clear(ClearFlags.Content)     
                .Styles.Focus.Clear()

                '行数、列数の初期設定
                .Rows.Fixed = 1
                .Rows.Count = 26
                .Cols.Count = 3
                .AllowMerging = AllowMergingEnum.FixedOnly

                .SelectionMode = SelectionModeEnum.ListBox
                .FocusRect = FocusRectEnum.Light
                .HighLight = HighLightEnum.WithFocus
                .Font = New Font(.Font.FontFamily, 9, .Font.Style, .Font.Unit)
                .ScrollBars = ScrollBars.None
                .FocusRect = FocusRectEnum.None

                'タイトル設定
                '1行目
                '--COLマージ
                .Rows(CMlngvsfGridTitleRow).AllowMerging = True
                .SetData(CMlngvsfGridTitleRow, CMlngvsfWfReserveId, "WFID")
                .SetData(CMlngvsfGridTitleRow, CMlngvsfWfReserveId2, "WFID")

                '列幅の設定
                .Cols(CMlngvsfWfReserveSlot).Width = CMlngvsfWfReserveWSlot   
                .Cols(CMlngvsfWfReserveId).Width = CMlngvsfWfReserveWId   
                .Cols(CMlngvsfWfReserveId2).Width = CMlngvsfWfReserveWId2     

                'タイトルの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfWp_HeaderStyle")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfGridTitleRow, CMlngvsfWfReserveSlot, CMlngvsfGridTitleRow, CMlngvsfWfReserveId2)
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                cellRange.Style = newStyle

                'スロット作成
                Dim lintCnt As Integer
                For lintCnt = .Rows.Fixed To .Rows.Count - 1
                    .SetData(lintCnt, CMlngvsfWfReserveSlot, Format$(CMlngvsfSlotRows - lintCnt, CPstrSlotNoFormat))
                Next lintCnt

                Dim styleDefault As CellStyle = .Styles.Add("CustomStyle_styleDefault")
                styleDefault.ForeColor = ColorTranslator.FromWin32(CMlngEnableTrueForeColor)
                styleDefault.BackColor = Color.White
                Dim cellRangeAll As CellRange = .GetCellRange(CMlngvsfGridTitleRow+1, CMlngvsfWfReserveId, .Rows.Count-1, .Cols.Count-1)
                cellRangeAll.Style = styleDefault

                '表示位置の設定
                .Cols(CMlngvsfWfReserveSlot).TextAlign = TextAlignEnum.RightCenter 
                .Cols(CMlngvsfWfReserveId).TextAlign = TextAlignEnum.CenterCenter 
                .Cols(CMlngvsfWfReserveId2).TextAlign = TextAlignEnum.CenterCenter

                '最終colを自動幅設定
                .ExtendLastCol = True

                .Redraw = True
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfReserveWfList_Init"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 初期化(予約一覧)
    ''' </summary>
    Private Sub prvTab1_Init()

        Try
            'ラベル
            lblNowDate1.Text = vbNullString
            lblLotId.Text = vbNullString
            lblWfId.Text = vbNullString

            '*******************
            'グリッド初期化
            '*******************
            Call prvvsfReserveInfo_Init()
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTab1_Init"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' ODF予約一覧のグリッド初期化
    ''' </summary>
    Private Sub prvvsfReserveInfo_Init()

        Try

            With vsfReserveInfo

                '初期化
                .Clear(ClearFlags.Content)
                .Styles.Focus.Clear()
                .MergedRanges.Clear

                '行数、列数の初期設定
                .Rows.Fixed = 2
                .Rows.Count = 2
                .Cols.Count = 11
                .Rows.DefaultSize = 24  'Row高さ
                .SelectionMode = SelectionModeEnum.Row
                
                '1行目
                '--ROWマージ
                .SetData(0, CMlngvsfInfoNo, CMstrvsfHInfoNoT)
                '--COLマージ
                .SetData(0, CMlngvsfInfoTFTLotId, "TFT")
                .SetData(0, CMlngvsfInfoTFTCarrier, "TFT")
                .SetData(0, CMlngvsfInfoTFTSlot, "TFT")
                .SetData(0, CMlngvsfInfoTFTWfId, "TFT")
                '--COLマージ
                .SetData(0, CMlngvsfInfoCFWfId, "CF")
                .SetData(0, CMlngvsfInfoCFSlot, "CF")
                .SetData(0, CMlngvsfInfoCFCarrier, "CF")
                .SetData(0, CMlngvsfInfoCFLotId, "CF")
                '--ROWマージ
                .SetData(0, CMlngvsfInfoUpdateTime, CMstrvsfInfoUpdateTimeT)
                .SetData(0, CMlngvsfInfoEmpName, CMstrvsfInfoEmpNameT)

                '2行目
                '--ROWマージ
                .SetData(1, CMlngvsfInfoNo, CMstrvsfHInfoNoT)
                '--COLそのまま
                .SetData(1, CMlngvsfInfoTFTLotId, CMstrvsfInfoTFTLotIdT)
                .SetData(1, CMlngvsfInfoTFTCarrier, CMstrvsfInfoTFTCarrierT)
                .SetData(1, CMlngvsfInfoTFTSlot, CMstrvsfInfoTFTSlotT)
                .SetData(1, CMlngvsfInfoTFTWfId, CMstrvsfInfoTFTWfIdT)
                '--COLそのまま
                .SetData(1, CMlngvsfInfoCFWfId, CMstrvsfInfoCFWfIdT)
                .SetData(1, CMlngvsfInfoCFSlot, CMstrvsfInfoCFSlotT)
                .SetData(1, CMlngvsfInfoCFCarrier, CMstrvsfInfoCFCarrierT)
                .SetData(1, CMlngvsfInfoCFLotId, CMstrvsfInfoCFLotIdT)
                '--ROWマージ
                .SetData(1, CMlngvsfInfoUpdateTime, CMstrvsfInfoUpdateTimeT)
                .SetData(1, CMlngvsfInfoEmpName, CMstrvsfInfoEmpNameT)

                'マージ
                .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom   '各指定でマージ
                '--ROWマージ
                .MergedRanges.Add(0, CMlngvsfInfoNo, 1, CMlngvsfInfoNo)
                '--COLマージ
                .MergedRanges.Add(0, CMlngvsfInfoTFTLotId, 0, CMlngvsfInfoTFTWfId)
                .MergedRanges.Add(0, CMlngvsfInfoCFWfId, 0, CMlngvsfInfoCFLotId)
                '--ROWマージ
                .MergedRanges.Add(0, CMlngvsfInfoUpdateTime, 1, CMlngvsfInfoUpdateTime)
                .MergedRanges.Add(0, CMlngvsfInfoEmpName, 1, CMlngvsfInfoEmpName)

                '列幅の設定
                .Cols(CMlngvsfInfoNo).Width = CMlngvsfInfoNoW
                .Cols(CMlngvsfInfoTFTLotId).Width = CMlngvsfInfoTFTLotIdW
                .Cols(CMlngvsfInfoTFTCarrier).Width = CMlngvsfInfoTFTCarrierW
                .Cols(CMlngvsfInfoTFTSlot).Width = CMlngvsfInfoTFTSlotW
                .Cols(CMlngvsfInfoTFTWfId).Width = CMlngvsfInfoTFTWfIdW
                .Cols(CMlngvsfInfoCFWfId).Width = CMlngvsfInfoCFWfIdW
                .Cols(CMlngvsfInfoCFSlot).Width = CMlngvsfInfoCFSlotW
                .Cols(CMlngvsfInfoCFCarrier).Width = CMlngvsfInfoCFCarrierW
                .Cols(CMlngvsfInfoCFLotId).Width = CMlngvsfInfoCFLotIdW
                .Cols(CMlngvsfInfoEmpName).Width = CMlngvsfInfoEmpNameW
                .Cols(CMlngvsfInfoUpdateTime).Width = CMlngvsfinfoUpdateTimeW

                '非表示列の設定
                .Cols(CMlngvsfInfoTFTSlot).Visible = False
                .Cols(CMlngvsfInfoCFSlot).Visible = False
                
                'タイトルの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfWp_HeaderStyle")
                Dim cellRange As CellRange = .GetCellRange(0, 0, 1, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                cellRange.Style = newStyle

                '自動列幅設定=自動調整する
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfInfoNo, .Cols.Count - 1, 6)

                .Enabled = False
                .Refresh

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfReserveInfo_Init"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub





    ''' <summary>
    ''' 初期化(表面処理群予約)
    ''' </summary>
    Private Sub prvTab2_Init()

        Try
            'ラベル
            lblNowDate2.Text = vbNullString
            lblSelectWfCnt.Text = vbNullString
            lblSelectWfCntTitle.Text = "選択WF枚数(最大" + cstr(CMlngHyoumenMaxCnt) + "枚)"
            lblCaution.Text = "・ODF予約済のロットが対象" + vbCrLf + _
                                "・表面処理のバッチ編成すると設定できません"
            lblCaution.AutoSize = True

            'ボタン            
            cmdHyoumenDel.Enabled = False
            cmdHyoumenRegist.Enabled = False

            'Option
            optAll.Checked = False      '全て
            optDone.Checked = False     '予約済
            optNone.Checked = True      '予約未

            '*******************
            'グリッド初期化
            '*******************
            Call prvvsfHyoumenReserve_Init()
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTab2_Init"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約のグリッド初期化
    ''' </summary>
    Private Sub prvvsfHyoumenReserve_Init()

        Try

            With vsfHyoumenReserveInfo

                '初期化
                .Clear(ClearFlags.Content)
                .Styles.Focus.Clear()
                .MergedRanges.Clear
                .Font = New Font(.Font.FontFamily, 10, .Font.Style, .Font.Unit)
                .SelectionMode = SelectionMode.None  '= SelectionModeEnum.Row

                '行数、列数の初期設定
                .Rows.Fixed = 2
                .Rows.Count = 2
                .Cols.Count = 19
                .Rows.DefaultSize = 24  'Row高さ
                .Cols.Frozen = CMlngvsfHInfoCheckBox + 1

                '1行目
                '--ROWマージ
                .SetData(0, CMlngvsfHInfoNo, CMstrvsfHInfoNoT)
                .SetData(0, CMlngvsfHInfoCheckBox, CMstrvsfHInfoCheckBoxT)
                '--COLマージ
                .SetData(0, CMlngvsfHInfoCurTFTCarrierId, "TFT")
                .SetData(0, CMlngvsfHInfoTFTLotId, "TFT")
                .SetData(0, CMlngvsfHInfoCurTFTLotId, "TFT")
                .SetData(0, CMlngvsfHInfoTFTWfId, "TFT")
                .SetData(0, CMlngvsfHInfoTFTWfQty, "TFT")
                .SetData(0, CMlngvsfHInfoTFTWfes, "TFT")
                '--COLマージ
                .SetData(0, CMlngvsfHInfoCurCFCarrierId, "CF")
                .SetData(0, CMlngvsfHInfoCFLotId, "CF")
                .SetData(0, CMlngvsfHInfoCurCFLotId, "CF")
                .SetData(0, CMlngvsfHInfoCFWfId, "CF")
                .SetData(0, CMlngvsfHInfoCfWfQty, "CF")
                .SetData(0, CMlngvsfHInfoCFWfes, "CF")
                '--ROWマージ
                .SetData(0, CMlngvsfHInfoEditTime, CMstrvsfHInfoEditTimeT)
                .SetData(0, CMlngvsfHInfoReserveTime, CMstrvsfHInfoReserveTimeT)
                .SetData(0, CMlngvsfHInfoReserveEmpName, CMstrvsfHInfoReserveEmpNameT)
                .SetData(0, CMlngvsfHInfoTotalWfQty, CMstrvsfHInfoTotalWfQtyT)
                .SetData(0, CMlngvsfHInfoRecipeId, CMstrvsfHInfoRecipeIdT)

                '2行目
                '--ROWマージ
                .SetData(1, CMlngvsfHInfoNo, CMstrvsfHInfoNoT)
                .SetData(1, CMlngvsfHInfoCheckBox, CMstrvsfHInfoCheckBoxT)
                '--COLそのまま
                .SetData(1, CMlngvsfHInfoCurTFTCarrierId, CMstrvsfHInfoCurTFTCarrierIdT)
                .SetData(1, CMlngvsfHInfoTFTLotId, CMstrvsfHInfoTFTLotIdT)
                .SetData(1, CMlngvsfHInfoCurTFTLotId, CMstrvsfHInfoCurTFTLotIdT)
                .SetData(1, CMlngvsfHInfoTFTWfId, CMstrvsfHInfoTFTWfIdT)
                .SetData(1, CMlngvsfHInfoTFTWfQty, CMstrvsfHInfoTFTWfQtyT)
                .SetData(1, CMlngvsfHInfoTFTWfes, CMstrvsfHInfoTFTWfesT)
                '--COLそのまま
                .SetData(1, CMlngvsfHInfoCurCFCarrierId, CMstrvsfHInfoCurCFCarrierIdT)
                .SetData(1, CMlngvsfHInfoCFLotId, CMstrvsfHInfoCfLotIdT)
                .SetData(1, CMlngvsfHInfoCurCFLotId, CMstrvsfHInfoCurCfLotIdT)
                .SetData(1, CMlngvsfHInfoCFWfId, CMstrvsfHInfoCFWfIdT)
                .SetData(1, CMlngvsfHInfoCfWfQty, CMstrvsfHInfoCFWfQtyT)
                .SetData(1, CMlngvsfHInfoCFWfes, CMstrvsfHInfoCFWfesT)
                ''--ROWマージ
                .SetData(1, CMlngvsfHInfoEditTime, CMstrvsfHInfoEditTimeT)
                .SetData(1, CMlngvsfHInfoReserveTime, CMstrvsfHInfoReserveTimeT)
                .SetData(1, CMlngvsfHInfoReserveEmpName, CMstrvsfHInfoReserveEmpNameT)
                .SetData(1, CMlngvsfHInfoTotalWfQty, CMstrvsfHInfoTotalWfQtyT)
                .SetData(1, CMlngvsfHInfoRecipeId, CMstrvsfHInfoRecipeIdT)

                'マージ
                .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom   '各指定でマージ
                '--ROWマージ
                .MergedRanges.Add(0, CMlngvsfHInfoNo, 1, CMlngvsfHInfoNo)
                .MergedRanges.Add(0, CMlngvsfHInfoCheckBox, 1, CMlngvsfHInfoCheckBox)
                '--COLマージ
                .MergedRanges.Add(0, CMlngvsfHInfoCurTFTCarrierId, 0, CMlngvsfHInfoTFTWfQty)
                .MergedRanges.Add(0, CMlngvsfHInfoCurCFCarrierId, 0, CMlngvsfHInfoCfWfQty)
                '--ROWマージ
                .MergedRanges.Add(0, CMlngvsfHInfoEditTime, 1, CMlngvsfHInfoEditTime)
                .MergedRanges.Add(0, CMlngvsfHInfoReserveTime, 1, CMlngvsfHInfoReserveTime)
                .MergedRanges.Add(0, CMlngvsfHInfoReserveEmpName, 1, CMlngvsfHInfoReserveEmpName)
                .MergedRanges.Add(0, CMlngvsfHInfoTotalWfQty, 1, CMlngvsfHInfoTotalWfQty)
                .MergedRanges.Add(0, CMlngvsfHInfoRecipeId, 1, CMlngvsfHInfoRecipeId)

                '列幅の設定
                .Cols(CMlngvsfHInfoNo).Width = CMlngvsfHInfoNoW
                .Cols(CMlngvsfHInfoCheckBox).Width = CMlngvsfHInfoCheckBoxW
                .Cols(CMlngvsfHInfoTFTWfId).Width = CMlngvsfHInfoTFTWfIdW
                .Cols(CMlngvsfHInfoTFTLotId).Width = CMlngvsfHInfoTFTLotIdW
                .Cols(CMlngvsfHInfoCurTFTLotId).Width = CMlngvsfHInfoCurTFTLotIdW
                .Cols(CMlngvsfHInfoCFWfId).Width = CMlngvsfHInfoCFWfIdW
                .Cols(CMlngvsfHInfoCFLotId).Width = CMlngvsfHInfoCFLotIdW
                .Cols(CMlngvsfHInfoCurCFLotId).Width = CMlngvsfHInfoCurCFLotIdW
                .Cols(CMlngvsfHInfoEditTime).Width = CMlngvsfHInfoEditTimeW
                .Cols(CMlngvsfHInfoReserveTime).Width = CMlngvsfHInfoReserveTimeW
                .Cols(CMlngvsfHInfoReserveEmpName).Width = CMlngvsfHInfoReserveEmpNameW
                .Cols(CMlngvsfHInfoRecipeId).Width = CMlngvsfHInfoRecipeW
                .Cols(CMlngvsfHInfoTFTWfQty).Width = CMlngvsfHInfoTFTWfQtyW
                .Cols(CMlngvsfHInfoCfWfQty).Width = CMlngvsfHInfoCFWfQtyW
                .Cols(CMlngvsfHInfoTotalWfQty).Width = CMlngvsfHInfoTotalWfQtyW
                .Cols(CMlngvsfHInfoCurTFTCarrierId).Width = CMlngvsfHInfoCurTFTCarrierIdW
                .Cols(CMlngvsfHInfoCurCFCarrierId).Width = CMlngvsfHInfoCurCFCarrierIdW
                .Cols(CMlngvsfHInfoTFTWfes).Width = CMlngvsfHInfoTFTWfesW
                .Cols(CMlngvsfHInfoCFWfes).Width = CMlngvsfHInfoCFWfesW

                '表示位置の設定
                .Cols(CMlngvsfHInfoNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfHInfoCheckBox).TextAlign = TextAlignEnum.CenterCenter
                .Cols(CMlngvsfHInfoTFTWfQty).TextAlign = TextAlignEnum.RightCenter 
                .Cols(CMlngvsfHInfoCfWfQty).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfHInfoTotalWfQty).TextAlign = TextAlignEnum.RightCenter

                '表示可否の設定
                .Cols(CMlngvsfHInfoNo).Visible = True
                .Cols(CMlngvsfHInfoCheckBox).Visible = True
                .Cols(CMlngvsfHInfoTFTLotId).Visible = False
                .Cols(CMlngvsfHInfoCurTFTLotId).Visible = True
                .Cols(CMlngvsfHInfoTFTWfId).Visible = True
                .Cols(CMlngvsfHInfoTFTWfQty).Visible = True
                .Cols(CMlngvsfHInfoCFLotId).Visible = False
                .Cols(CMlngvsfHInfoCurCFLotId).Visible = True
                .Cols(CMlngvsfHInfoCFWfId).Visible = True
                .Cols(CMlngvsfHInfoCfWfQty).Visible = True
                .Cols(CMlngvsfHInfoRecipeId).Visible = True
                .Cols(CMlngvsfHInfoEditTime).Visible = False
                .Cols(CMlngvsfHInfoReserveTime).Visible = True
                .Cols(CMlngvsfHInfoReserveEmpName).Visible = True
                .Cols(CMlngvsfHInfoTotalWfQty).Visible = True
                .Cols(CMlngvsfHInfoCurTFTCarrierId).Visible = True
                .Cols(CMlngvsfHInfoCurCFCarrierId).Visible = True
                .Cols(CMlngvsfHInfoTFTWfes).Visible = False
                .Cols(CMlngvsfHInfoCFWfes).Visible = False

                'タイトル設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfWp_HeaderStyle")
                Dim cellRange As CellRange = .GetCellRange(0, 0, 1, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                cellRange.Style = newStyle

                '最終colを自動幅設定
                .ExtendLastCol = True

                '自動調整する
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfHInfoTFTLotId, .Cols.Count - 1, 6)

                .Enabled = False
                .Refresh

            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfHyoumenReserve_Init"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

	''' <summary>
    ''' 初期化(表面処理群予約)
    ''' </summary>
    Private Sub prvTab3_Init()

        Try


            'ラベル
            lblLotID1.Text = vbNullString
            lblReserveStatus2.Text = vbNullString

			txtToCarrier1.Text = vbNullString
			txtToCarrier2.Text = vbNullString
			txtToCarrier3.Text = vbNullString
			txtToCarrier4.Text = vbNullString

            'ボタン            
            cmd5wf.Enabled = False
            cmd10wf.Enabled = False
			cmdCarrierSelect1.Enabled = False
			cmdCarrierSelect2.Enabled = False
			cmdCarrierSelect3.Enabled = False
			cmdCarrierSelect4.Enabled = False
			cmdReserveJDel.Enabled = False
			cmdReserveJRegist.Enabled = False

			'テキストボックス
			txtToCarrier1.Enabled = False
			txtToCarrier2.Enabled = False
			txtToCarrier3.Enabled = False
			txtToCarrier4.Enabled = False

			mstrToCarrier1 = vbNullString                 '予約1ｷｬﾘｱID退避用
            mstrToCarrier2 = vbNullString                 '予約2ｷｬﾘｱID退避用
			mstrToCarrier3 = vbNullString                 '予約1ｷｬﾘｱID退避用
            mstrToCarrier4 = vbNullString                 '予約2ｷｬﾘｱID退避用
            '*******************
            'グリッド初期化
            '*******************
            Call prvvsfSlotMap_init(vsfSlotMap)
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTab3_Init"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvupdateAfterJReserveInfo
    '機　能：最新情報取得
    '引　数：lobjControl：VSFlexGridｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
	Private Function prvupdateAfterJReserveInfo()
		Dim lblnAns                         As Boolean						'結果取得(True:正常,False:異常)
		Dim lstrCarriaName                  As String						'ｷｬﾘｱID欄名
		Dim ltypLotCurState                 As Lotprestate					'ﾛｯﾄ現在状態格納構造体
		Dim ltypWaferList                   As Waferlist					'WF情報格納用構造体
		Dim ltypAfterJReserveDetail			As AfterJReserveDetailList		'蒸着後流動予約情報格納用構造体
		Dim lblnIsReserved					As Boolean						'予約済みﾌﾗｸﾞ
		Dim lstrReserveId					As String						'再建策用予約ID

		lstrCarriaName = txtCarrier.Text

        '@ｽﾛｯﾄﾏｯﾌﾟの初期化
        Call prvvsfSlotMap_init(vsfSlotMap)     'VSFlexGrid(1)

        '@ｷｬﾘｱID情報の取得
        If Trim(lstrCarriaName) <> vbNullString And _
            Len(Trim(lstrCarriaName)) = txtCarrier.ChrMaxByte Then
            '@ﾚｽﾎﾟﾝｽ測定開始
            mstrEventName = "txtCarrier_Validate"
            Call pubResponseStart(Me.Name, mstrEventName)

            '@DBからﾛｯﾄ情報の取得
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD4W, lstrCarriaName, ltypLotCurState) 'CPstrCD4H
            '@結果判定
            If lblnAns = True Then
                '@画面表示処理(1)
                With ltypLotCurState
                    lblLotID1.Text = .strLotID               'ﾛｯﾄID
                End With

                '@ﾛｯﾄWF情報取得
                lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, txtCarrier.Text, CPstrCD0T, ltypWaferList)

                '@結果確認
                If lblnAns = True Then

					'@取得OKなら既に蒸着後流動予約があるか確認
					lblnAns = pubblnGetAfterJReserveDetail(CMstrlot_afterjrsvdetailVer, txtCarrier.Text, lblLotID1.Text, "", "", CPstrCD4W, _
														ltypWaferList.typWfList, ltypAfterJReserveDetail)
					'@結果確認
					If lblnAns = True Then

						If ltypAfterJReserveDetail.lngAfterJReserveDetailListCnt > 0 Then
							
							If ltypAfterJReserveDetail.strNGFlag = CPstrFlagOn Then
								lblReserveStatus2.Text = "混在"
								'@「"<TRM197W>$$ロット[%1]は複数の予約IDが混在しているため[%2]できません。"」のﾒｯｾｰｼﾞを表示
								pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0197,lblLotID1.Text , "蒸着後流動予約")
								Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
								pubSetFocus(txtToCarrier1)
								Return False
							End If
							
							'1件以上取得できた場合は予約済みとする
							lblnIsReserved = True
							'予約済みの場合は予約情報全体を取得したいため再度予約IDで取得を行う
							lstrReserveId = ltypAfterJReserveDetail.typAfterJReserveDetailList(0).strReserveId
							If lstrReserveId <> vbNullString Then
								lblnAns = pubblnGetAfterJReserveDetail(CMstrlot_afterjrsvdetailVer, txtCarrier.Text, lblLotID1.Text, lstrReserveId, "", CPstrCD4W, _
														ltypWaferList.typWfList, ltypAfterJReserveDetail)
							End If
						Else
							'未予約状態
							lblnIsReserved = False
						End If

						'@取得OKなら結果表示
						Call prvVsfSlotMap_Disp(ltypWaferList, vsfSlotMap, ltypAfterJReserveDetail, lblnIsReserved)

						If lblnIsReserved = True Then
							If ltypAfterJReserveDetail.strNGFlag = CPstrFlagOn Then
								lblReserveStatus2.Text = "混在"
								'@「"<TRM197W>$$ロット[%1]は複数の予約IDが混在しているため[%2]できません。"」のﾒｯｾｰｼﾞを表示
								pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0197,lblLotID1.Text , "蒸着後流動予約")
								Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
								pubSetFocus(txtToCarrier1)
								Return False
							Else
								lblReserveStatus2.Text = ltypAfterJReserveDetail.typAfterJReserveDetailList(0).strReserveId

							End If
						Else

							'未予約(新規登録)状態の場合
							lblReserveStatus2.Text = "未"

						End If

						'@変更ﾌﾗｸﾞｾｯﾄ
						mblnTxtCarrierChange = False    '無変更

						'@ﾚｽﾎﾟﾝｽ測定終了
						Call publngResponseEnd(Me.Name, mstrEventName)

						If ActiveControl.Name = txtCarrier.Name Then
							If vsfSlotMap.Enabled = True Then
								'@スロットマップにﾌｫｰｶｽｾｯﾄ
								Call pubSetFocus(txtCarrier)
							Else
								'@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
								Call pubSetFocus(cmdClose)
							End If
						End If

					Else

						Return False
					End If

				Else

					Return False
                End If

            Else
                '@ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(Me.Name, mstrEventName)
                    

				Return False
            End If
        Else
               
            '@画面初期化
            Call prvVsfSlotMap_Init(vsfSlotMap)
                
            If ActiveControl.Name = txtCarrier.Name Then
                '@統合ﾛｯﾄ2のｷｬﾘｱIDが有効の場合
                If txtCarrier.Enabled = True Then
                    '@移載工程ｽｷｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrier)
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If
                
        End If

		'@=======================
		'@　確定ﾎﾞﾀﾝ制御処理
		'@=======================
		Call prvcmdReserveJRegistEnabled_Chk()

		Return True
	End Function

	'関数名：prvvsfSlotMap_init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期化
    '引　数：lobjControl：VSFlexGridｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvvsfSlotMap_init(ByRef lobjControl As C1FlexGrid)

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Dim cellRange   As CellRange            'NSYS 追加Sytle設定範囲
        Dim headerStyle As CellStyle            'NSYS ヘッダー用追加Style
        Dim slotNoStyle As CellStyle            'NSYS スロットNo.用追加Style

        Try
            
            '@VSFlexGridの場合にのみ初期化
            If TypeOf lobjControl Is C1FlexGrid Then

                '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
                With lobjControl
    
                    'NSYS @設定中の画面描画はしない
                    .Redraw = False

                    '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                    .Clear

                    '@一覧表設定
                    .Rows.Count = CMlngSlotMapRowS                                                      '行数
                    .BackColor = vbWhite
                    .Select(CMlngSlotMapRowTitle, CMlngvsfSlotMapSlotNo, CMlngSlotMapRowTitle, CMlngvsfSlotMapCarrierId)      '表題
                    .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHeight                             '高さ
                    headerStyle = .Styles.Add("headerStyle")
                    headerStyle.ForeColor = Color.Yellow                                                '文字色
                    headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))  '背景色
                    '@WFIDのｾﾝﾀﾘﾝｸﾞ
                    headerStyle.TextAlign = TextAlignEnum.CenterCenter
                    With .Styles.Normal.Font
                        headerStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)    'ﾌｫﾝﾄｻｲｽﾞ
                    End With
                    cellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngvsfSlotMapSlotNo, CMlngSlotMapRowTitle, CMlngvsfSlotMapCarrierId)
                    cellRange.Style = headerStyle

                    
                    '@一覧表のSlot№設定
                    slotNoStyle = .Styles.Add("slotNoStyle")
                    For llngCnt = 1 To CMlngSlotMapRowS - 1
                        .Col = CMlngvsfSlotMapSlotNo
                        .Row = llngCnt
                        .SetData(llngCnt, CMlngvsfSlotMapSlotNo, CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat))) 'スロットNo 25→1
						.SetData(llngCnt, CMlngvsfSlotMapBNo, CStr(Format$(llngCnt, CPstrSlotNoFormat))) '通し番号 1→25
                        .Rows(llngCnt).Height = CMlngSlotMapHeight
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapSlotNo, llngCnt, CMlngvsfSlotMapSlotNo)
                        cellRange.Style = slotNoStyle
                    Next llngCnt

                    '@列幅、ﾀｲﾄﾙ設定
                    '@ｽﾛｯﾄID
                    .Cols(CMlngvsfSlotMapSlotNo).Width = CMlngvsfSlotMapSlotNoW
                    .SetData(CMlngSlotMapRowTitle, CMlngvsfSlotMapSlotNo, CMstrvsfSlotMapSlotNoT)
                    '@WFID
                    .Cols(CMlngvsfSlotMapWfId).Width = CMlngvsfSlotMapWfIdW
                    .SetData(CMlngSlotMapRowTitle, CMlngvsfSlotMapWfId, CMstrvsfSlotMapWfIdT)
                    '@予約ID
                    .Cols(CMlngvsfSlotMapResId).Width = CMlngvsfSlotMapResIdW
                    .SetData(CMlngSlotMapRowTitle, CMlngvsfSlotMapResId, CMstrvsfSlotMapResIdT)
					'@グループ
                    .Cols(CMlngvsfSlotMapGroup).Width = CMlngvsfSlotMapGroupW
                    .SetData(CMlngSlotMapRowTitle, CMlngvsfSlotMapGroup, CMstrvsfSlotMapGroupT)
					'@スロット
                    .Cols(CMlngvsfSlotMapSlotPosition).Width = CMlngvsfSlotMapSlotPositionW
                    .SetData(CMlngSlotMapRowTitle, CMlngvsfSlotMapSlotPosition, CMstrvsfSlotMapSlotPositionT)
					'@キャリアID
                    .Cols(CMlngvsfSlotMapCarrierId).Width = CMlngvsfSlotMapCarrierIdW
                    .SetData(CMlngSlotMapRowTitle, CMlngvsfSlotMapCarrierId, CMstrvsfSlotMapCarrierIdT)
					'@通し番号
                    .Cols(CMlngvsfSlotMapBNo).Width = CMlngvsfSlotMapBNoW
                    .SetData(CMlngSlotMapRowTitle, CMlngvsfSlotMapBNo, CMstrvsfSlotMapBNoT)

					'非表示列
					.Cols(CMlngvsfSlotMapResId).Visible = False
					.Cols(CMlngvsfSlotMapGroup).Visible = False
					.Cols(CMlngvsfSlotMapSlotPosition).Visible = False
					.Cols(CMlngvsfSlotMapCarrierId).Visible = False
					.Cols(CMlngvsfSlotMapBNo).Visible = False

                    '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                    .Cols(CMlngvsfSlotMapSlotNo).TextAlign = TextAlignEnum.RightCenter

					.SelectionMode = SelectionMode.None

                    '@ﾛｯｸ
                    .Enabled = False

                    .Redraw = True

                End With

				'スロットマップ1~4初期化
				Call prvvsfSlotMap1_4_init()

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvvsfSlotMap1_4init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期化
    '引　数：lobjControl：VSFlexGridｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvvsfSlotMap1_4_init()

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Dim cellRange   As CellRange            'NSYS 追加Sytle設定範囲
        Dim headerStyle As CellStyle            'NSYS ヘッダー用追加Style
        Dim slotNoStyle As CellStyle            'NSYS スロットNo.用追加Style

        Try
            

			'@予約先スロットマップ全グループ各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfToSlotMap1
    
                'NSYS @設定中の画面描画はしない
                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear

                '@一覧表設定
                .Rows.Count = CMlngSlotMapRowS                                                      '行数
                .BackColor = vbWhite
                .Select(CMlngSlotMapRowTitle, CMlngvsfToSlotMap1SlotNo, CMlngSlotMapRowTitle, CMlngvsfToSlotMap1BNo)      '表題
                .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHeight                             '高さ
                headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))  '背景色
                '@WFIDのｾﾝﾀﾘﾝｸﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                With .Styles.Normal.Font
                    headerStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)    'ﾌｫﾝﾄｻｲｽﾞ
                End With
                cellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngvsfToSlotMap1SlotNo, CMlngSlotMapRowTitle, CMlngvsfToSlotMap1BNo)
                cellRange.Style = headerStyle

                    
                '@一覧表のSlot№設定
                slotNoStyle = .Styles.Add("slotNoStyle")
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    .Col = CMlngvsfToSlotMap1SlotNo
                    .Row = llngCnt
                    .SetData(llngCnt, CMlngvsfToSlotMap1SlotNo, CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                    .Rows(llngCnt).Height = CMlngSlotMapHeight
                    cellRange = .GetCellRange(llngCnt, CMlngvsfToSlotMap1SlotNo, llngCnt, CMlngvsfToSlotMap1SlotNo)
                    cellRange.Style = slotNoStyle
                Next llngCnt

                '@列幅、ﾀｲﾄﾙ設定
                '@ｽﾛｯﾄID
                .Cols(CMlngvsfToSlotMap1SlotNo).Width = CMlngvsfToSlotMap1SlotNoW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap1SlotNo, CMstrvsfToSlotMap1SlotNoT)
                '@WFID
                .Cols(CMlngvsfToSlotMap1WfId).Width = CMlngvsfToSlotMap1WfIdW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap1WfId, CMstrvsfToSlotMap1WfIdT)
					'@通し番号
                .Cols(CMlngvsfToSlotMap1BNo).Width = CMlngvsfToSlotMap1BNoW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap1BNo, CMstrvsfToSlotMap1BNoT)

                '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                .Cols(CMlngvsfToSlotMap1SlotNo).TextAlign = TextAlignEnum.RightCenter
				.SelectionMode = SelectionMode.None
					
				'@非表示列
				.Cols(CMlngvsfToSlotMap1BNo).Visible = False

                '@ﾛｯｸ
                .Enabled = False

                .Redraw = True

            End With

			'@予約先スロットマップ全グループ各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfToSlotMap2
    
                'NSYS @設定中の画面描画はしない
                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear

                '@一覧表設定
                .Rows.Count = CMlngSlotMapRowS                                                      '行数
                .BackColor = vbWhite
                .Select(CMlngSlotMapRowTitle, CMlngvsfToSlotMap2SlotNo, CMlngSlotMapRowTitle, CMlngvsfToSlotMap2WfId)      '表題
                .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHeight                             '高さ
                headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))  '背景色
                '@WFIDのｾﾝﾀﾘﾝｸﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                With .Styles.Normal.Font
                    headerStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)    'ﾌｫﾝﾄｻｲｽﾞ
                End With
                cellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngvsfToSlotMap2SlotNo, CMlngSlotMapRowTitle, CMlngvsfToSlotMap2WfId)
                cellRange.Style = headerStyle

                    
                '@一覧表のSlot№設定
                slotNoStyle = .Styles.Add("slotNoStyle")
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    .Col = CMlngvsfToSlotMap2SlotNo
                    .Row = llngCnt
                    .SetData(llngCnt, CMlngvsfToSlotMap2SlotNo, CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                    .Rows(llngCnt).Height = CMlngSlotMapHeight
                    cellRange = .GetCellRange(llngCnt, CMlngvsfToSlotMap2SlotNo, llngCnt, CMlngvsfToSlotMap2SlotNo)
                    cellRange.Style = slotNoStyle
                Next llngCnt

                '@列幅、ﾀｲﾄﾙ設定
                '@ｽﾛｯﾄID
                .Cols(CMlngvsfToSlotMap2SlotNo).Width = CMlngvsfToSlotMap2SlotNoW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap2SlotNo, CMstrvsfToSlotMap2SlotNoT)
                '@WFID
                .Cols(CMlngvsfToSlotMap2WfId).Width = CMlngvsfToSlotMap2WfIdW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap2WfId, CMstrvsfToSlotMap2WfIdT)
				'@通し番号
                .Cols(CMlngvsfToSlotMap2BNo).Width = CMlngvsfToSlotMap2BNoW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap2BNo, CMstrvsfToSlotMap2BNoT)

                '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                .Cols(CMlngvsfToSlotMap2SlotNo).TextAlign = TextAlignEnum.RightCenter
				.SelectionMode = SelectionMode.None

				'@非表示列
				.Cols(CMlngvsfToSlotMap2BNo).Visible = False

                '@ﾛｯｸ
                .Enabled = False

                .Redraw = True

            End With

			'@予約先スロットマップ全グループ各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfToSlotMap3
    
                'NSYS @設定中の画面描画はしない
                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear

                '@一覧表設定
                .Rows.Count = CMlngSlotMapRowS                                                      '行数
                .BackColor = vbWhite
                .Select(CMlngSlotMapRowTitle, CMlngvsfToSlotMap3SlotNo, CMlngSlotMapRowTitle, CMlngvsfToSlotMap3WfId)      '表題
                .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHeight                             '高さ
                headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))  '背景色
                '@WFIDのｾﾝﾀﾘﾝｸﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                With .Styles.Normal.Font
                    headerStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)    'ﾌｫﾝﾄｻｲｽﾞ
                End With
                cellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngvsfToSlotMap3SlotNo, CMlngSlotMapRowTitle, CMlngvsfToSlotMap3WfId)
                cellRange.Style = headerStyle

                    
                '@一覧表のSlot№設定
                slotNoStyle = .Styles.Add("slotNoStyle")
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    .Col = CMlngvsfToSlotMap3SlotNo
                    .Row = llngCnt
                    .SetData(llngCnt, CMlngvsfToSlotMap3SlotNo, CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                    .Rows(llngCnt).Height = CMlngSlotMapHeight
                    cellRange = .GetCellRange(llngCnt, CMlngvsfToSlotMap3SlotNo, llngCnt, CMlngvsfToSlotMap3SlotNo)
                    cellRange.Style = slotNoStyle
                Next llngCnt

                '@列幅、ﾀｲﾄﾙ設定
                '@ｽﾛｯﾄID
                .Cols(CMlngvsfToSlotMap3SlotNo).Width = CMlngvsfToSlotMap3SlotNoW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap3SlotNo, CMstrvsfToSlotMap3SlotNoT)
                '@WFID
                .Cols(CMlngvsfToSlotMap3WfId).Width = CMlngvsfToSlotMap3WfIdW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap3WfId, CMstrvsfToSlotMap3WfIdT)
				'@通し番号
                .Cols(CMlngvsfToSlotMap3BNo).Width = CMlngvsfToSlotMap3BNoW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap3BNo, CMstrvsfToSlotMap3BNoT)

                '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                .Cols(CMlngvsfToSlotMap3SlotNo).TextAlign = TextAlignEnum.RightCenter
				.SelectionMode = SelectionMode.None

				'@非表示列
				.Cols(CMlngvsfToSlotMap3BNo).Visible = False

                '@ﾛｯｸ
                .Enabled = False

                .Redraw = True

            End With

			'@予約先スロットマップ全グループ各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfToSlotMap4
    
                'NSYS @設定中の画面描画はしない
                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear

                '@一覧表設定
                .Rows.Count = CMlngSlotMapRowS                                                      '行数
                .BackColor = vbWhite
                .Select(CMlngSlotMapRowTitle, CMlngvsfToSlotMap4SlotNo, CMlngSlotMapRowTitle, CMlngvsfToSlotMap4WfId)      '表題
                .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHeight                             '高さ
                headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))  '背景色
                '@WFIDのｾﾝﾀﾘﾝｸﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                With .Styles.Normal.Font
                    headerStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)    'ﾌｫﾝﾄｻｲｽﾞ
                End With
                cellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngvsfToSlotMap4SlotNo, CMlngSlotMapRowTitle, CMlngvsfToSlotMap4WfId)
                cellRange.Style = headerStyle

                    
                '@一覧表のSlot№設定
                slotNoStyle = .Styles.Add("slotNoStyle")
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    .Col = CMlngvsfToSlotMap4SlotNo
                    .Row = llngCnt
                    .SetData(llngCnt, CMlngvsfToSlotMap4SlotNo, CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                    .Rows(llngCnt).Height = CMlngSlotMapHeight
                    cellRange = .GetCellRange(llngCnt, CMlngvsfToSlotMap4SlotNo, llngCnt, CMlngvsfToSlotMap4SlotNo)
                    cellRange.Style = slotNoStyle
                Next llngCnt

                '@列幅、ﾀｲﾄﾙ設定
                '@ｽﾛｯﾄID
                .Cols(CMlngvsfToSlotMap4SlotNo).Width = CMlngvsfToSlotMap4SlotNoW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap4SlotNo, CMstrvsfToSlotMap4SlotNoT)
                '@WFID
                .Cols(CMlngvsfToSlotMap4WfId).Width = CMlngvsfToSlotMap4WfIdW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap4WfId, CMstrvsfToSlotMap4WfIdT)
				'@通し番号
                .Cols(CMlngvsfToSlotMap4BNo).Width = CMlngvsfToSlotMap4BNoW
                .SetData(CMlngSlotMapRowTitle, CMlngvsfToSlotMap4BNo, CMstrvsfToSlotMap4BNoT)

				'@非表示列
				.Cols(CMlngvsfToSlotMap4BNo).Visible = False

                '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                .Cols(CMlngvsfToSlotMap4SlotNo).TextAlign = TextAlignEnum.RightCenter
				.SelectionMode = SelectionMode.None

                '@ﾛｯｸ
                .Enabled = False

                .Redraw = True

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap1_4_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvvsfSlotMap1_4_clear
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期化
    '引　数：lobjControl：VSFlexGridｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    Private Sub prvvsfSlotMap1_4_clear()

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Dim cellRange   As CellRange            'NSYS 追加Sytle設定範囲
        Dim headerStyle As CellStyle            'NSYS ヘッダー用追加Style
        Dim slotNoStyle As CellStyle            'NSYS スロットNo.用追加Style

        Try
            

			vsfToSlotMap1.Redraw = False
			vsfToSlotMap2.Redraw = False
			vsfToSlotMap3.Redraw = False
			vsfToSlotMap4.Redraw = False

			vsfToSlotMap1.Clear
			vsfToSlotMap2.Clear
			vsfToSlotMap3.Clear
			vsfToSlotMap4.Clear

			'@全てのｽﾛｯﾄ背景色を灰色に変更、スロットマップA～Dの偶数スロットを白色に変更
			Dim maps = {
				Tuple.Create(vsfToSlotMap1, CMlngvsfToSlotMap1WfId),
				Tuple.Create(vsfToSlotMap2, CMlngvsfToSlotMap2WfId),
				Tuple.Create(vsfToSlotMap3, CMlngvsfToSlotMap3WfId),
				Tuple.Create(vsfToSlotMap4, CMlngvsfToSlotMap4WfId)
			}

			' ===== Styleは一度だけ作成 =====
			Dim grayStyle As CellStyle =
				vsfToSlotMap1.Styles.Add("Style_Gray")
			grayStyle.BackColor =
				ColorTranslator.FromWin32(CPlngGridDarkGray)

			Dim whiteStyle As CellStyle =
				vsfToSlotMap1.Styles.Add("Style_White")
			whiteStyle.BackColor = Color.White

			' ===== 行ループは1本 =====
			For row As Integer = 1 To CMlngSlotMapRowS - 1

				Dim style As CellStyle =
					If(row Mod 2 = 0, whiteStyle, grayStyle)

				For Each m In maps
					Dim cell As CellRange =
						m.Item1.GetCellRange(row, m.Item2)
					cell.Style = style
				Next

			Next
			
			vsfToSlotMap1.Redraw = True
			vsfToSlotMap2.Redraw = True
			vsfToSlotMap3.Redraw = True
			vsfToSlotMap4.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap1_4_clear"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap_Disp
    '機　能：WFﾏｯﾌﾟ表示
    '引　数：ltypWaferList：ﾛｯﾄ現在状態取得構造体
    '　　　：lobjControl  ：VSFlexGridｵﾌﾞｼﾞｪｸﾄ名
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 09:34:27 K.Takano
    '更新日：2004/07/29 (Thu) 09:44:24 Y.Yamagishi
    '備　考：
    Private Sub prvVsfSlotMap_Disp(ByRef ltypWaferList As WaferList, ByRef lobjControl As C1FlexGrid, ByRef ltypAfterJReserveDetailList As AfterJReserveDetailList, ByVal lblnIsReserved As Boolean)

        Dim llngCnt         As Integer      'ｷｬﾘｱのｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行

        Try
            
            '@ｵﾌﾞｼﾞｪｸﾄがVSFlexGridの場合にのみ設定
			If TypeOf lobjControl Is C1FlexGrid Then
                '@全てのｽﾛｯﾄ背景色を灰色に変更(初期化)
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    Dim newStyle As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                    Dim cellRange As CellRange = lobjControl.GetCellRange(llngCnt, CMlngvsfSlotMapWfId)
                    cellRange.Style = newStyle
                Next
                
                '@WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If ltypWaferList.strSlotSize < CMlngSlotMapRowS - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        lobjControl.SetData(llngCnt, CMlngvsfSlotMapSlotNo, vbNullString)
                        
                        '@ｽﾛｯﾄにｷｬﾘｱが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        Dim newStyle As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                        newStyle.BackColor = vbButtonFace
                        Dim cellRange As CellRange = lobjControl.GetCellRange(llngCnt, CMlngvsfSlotMapSlotNo)
                        cellRange.Style = newStyle

                    End If
                Next
                
                '@WF枚数分ﾙｰﾌﾟ
                llngCnt = 0
                Do While ltypWaferList.lngListCnt -1 >= llngCnt
                    With ltypWaferList.typWfList(llngCnt)
                        '@書き込み行設定
                        llngWriteRow = CMlngSlotMapRowS - CLng(.strSlotPosition)

                        '@WFID表示設定
                        lobjControl.SetData(llngWriteRow, CMlngvsfSlotMapWfId, .strWfId)
                        Dim newStyle As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = vbWhite
                        Dim cellRange As CellRange = lobjControl.GetCellRange(llngWriteRow, CMlngvsfSlotMapWfId)
                        cellRange.Style = newStyle

                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngCnt = llngCnt + 1
                    End With
                Loop

				'@全てのｽﾛｯﾄ背景色を灰色に変更(初期化)
				For llngCnt = 1 To CMlngSlotMapRowS - 1
					Dim newStyle As CellStyle = vsfToSlotMap1.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
					newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
					Dim cellRange As CellRange = vsfToSlotMap1.GetCellRange(llngCnt, CMlngvsfToSlotMap1WfId)
					cellRange.Style = newStyle
						
					cellRange = vsfToSlotMap2.GetCellRange(llngCnt, CMlngvsfToSlotMap2WfId)
					cellRange.Style = newStyle

					cellRange = vsfToSlotMap3.GetCellRange(llngCnt, CMlngvsfToSlotMap3WfId)
					cellRange.Style = newStyle

					cellRange = vsfToSlotMap4.GetCellRange(llngCnt, CMlngvsfToSlotMap4WfId)
					cellRange.Style = newStyle
				Next

				'予約済みの場合はスロットマップA~Dも反映
				If lblnIsReserved Then
					'@予約済みWF枚数分ﾙｰﾌﾟ
					llngCnt = 0
					Do While ltypAfterJReserveDetailList.lngAfterJReserveDetailListCnt -1 >= llngCnt
						With ltypAfterJReserveDetailList.typAfterJReserveDetailList(llngCnt)
							'@書き込み行設定
							llngWriteRow = CMlngSlotMapRowS - CLng(.strSlotPosition)

							Dim lvsfSlotMap As C1FlexGrid
							Select Case .strReserveGroup

								Case "A"
									lvsfSlotMap = vsfToSlotMap1
									txtToCarrier1.Text = .strCarrierId
								Case "B"
									lvsfSlotMap = vsfToSlotMap2
									txtToCarrier2.Text = .strCarrierId
								Case "C"
									lvsfSlotMap = vsfToSlotMap3
									txtToCarrier3.Text = .strCarrierId
								Case "D"
									lvsfSlotMap = vsfToSlotMap4
									txtToCarrier4.Text = .strCarrierId
								Case Else

							End Select

							'@WFID表示設定
							lvsfSlotMap.SetData(llngWriteRow, CMlngvsfSlotMapWfId, .strWfId)
							Dim newStyle1 As CellStyle = lvsfSlotMap.Styles.Add("CustomStyle_BackColor_vbWhite")
							newStyle1.BackColor = vbWhite
							Dim cellRange1 As CellRange = lvsfSlotMap.GetCellRange(llngWriteRow, CMlngvsfSlotMapWfId)
							cellRange1.Style = newStyle1            

						End With

						'@ｶｳﾝﾄｱｯﾌﾟ
						llngCnt = llngCnt + 1
					Loop

					With vsfSlotMap
						For llngCnt = 1 To CMlngSlotMapRowS - 1
							'@元ｽﾛｯﾄﾏｯﾌﾟの対象行の文字色をｸﾞﾚｰにする
							If .GetData(llngCnt,CMlngvsfSlotMapWfId) <> vbNullString Then
								Dim newStyle2  As CellStyle  = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor")
								newStyle2.BackColor = vbWhite
								newStyle2.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
								Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapWfID, llngCnt, CMlngvsfSlotMapCarrierId)
								cellRange2.Style = newStyle2
							End If
						Next
					End With

					'編集不可に変更
					vsfSlotMap.Enabled = False
					vsfToSlotMap1.Enabled = False
					vsfToSlotMap2.Enabled = False
					vsfToSlotMap3.Enabled = False
					vsfToSlotMap4.Enabled = False
					txtToCarrier1.Enabled = False
					txtToCarrier2.Enabled = False
					txtToCarrier3.Enabled = False
					txtToCarrier4.Enabled = False
					cmdCarrierSelect1.Enabled = False
					cmdCarrierSelect2.Enabled = False
					cmdCarrierSelect3.Enabled = False
					cmdCarrierSelect4.Enabled = False
					cmd5wf.Enabled = False
					cmd10wf.Enabled = False

				Else
					'予約済みでない場合はスロットマップA～Dの偶数スロットを白色に変更
					For llngCnt = 1 To CMlngSlotMapRowS - 1
	
						If llngCnt Mod 2 = 0 Then

							Dim newStyle As CellStyle = vsfToSlotMap1.Styles.Add("CustomStyle_BackColor_vbWhite")
							newStyle.BackColor = vbWhite
							Dim cellRange As CellRange = vsfToSlotMap1.GetCellRange(llngCnt, CMlngvsfToSlotMap1WfId)
							cellRange.Style = newStyle   
							
							cellRange = vsfToSlotMap2.GetCellRange(llngCnt, CMlngvsfToSlotMap2WfId)
							cellRange.Style = newStyle

							cellRange = vsfToSlotMap3.GetCellRange(llngCnt, CMlngvsfToSlotMap3WfId)
							cellRange.Style = newStyle

							cellRange = vsfToSlotMap4.GetCellRange(llngCnt, CMlngvsfToSlotMap4WfId)
							cellRange.Style = newStyle
						End If

					Next

					'編集可に変更
					vsfSlotMap.Enabled = True
					vsfToSlotMap1.Enabled = True
					vsfToSlotMap2.Enabled = True
					vsfToSlotMap3.Enabled = True
					vsfToSlotMap4.Enabled = True
					txtToCarrier1.Enabled = True
					txtToCarrier2.Enabled = True
					txtToCarrier3.Enabled = True
					txtToCarrier4.Enabled = True
					cmdCarrierSelect1.Enabled = True
					cmdCarrierSelect2.Enabled = True
					cmdCarrierSelect3.Enabled = True
					cmdCarrierSelect4.Enabled = True
					cmd5wf.Enabled = True
					cmd10wf.Enabled = True

				End If

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvcmdReserveJRegistEnabled_Chk
    '機　能：確定ﾎﾞﾀﾝ有効確認
    '引　数：なし
    '戻り値：TRUE:OK FALSE:NG
    '作成日：
    '更新日：
    '備　考：

    Private Function prvcmdReserveJRegistEnabled_Chk() As Boolean
        
        Dim lstrStatus1         As String           '予約状態
        Dim lstrLot             As String           'ﾛｯﾄID(1)
		Dim llngCnt             As Integer          'カウント
		Dim lblnNgFlag			As Boolean			'NGフラグ

        Try
            
            '@初期化
            prvcmdReserveJRegistEnabled_Chk = False
			lblnNgFlag = False
            
			'予約状態
            If lblReserveStatus2.Text <> "未" Then
				'@確定ﾎﾞﾀﾝ無効変更
                cmdReserveJRegist.Enabled = False
				cmdReserveJDel.Enabled = True
				Exit Function

            End If
            
			’キャリアIDが選択されている場合は「登録」ボタンを有効にし、スロットとの照合はボタン押下時に行う
            If txtToCarrier1.Text = vbNullString And txtToCarrier2.Text = vbNullString And txtToCarrier3.Text = vbNullString And txtToCarrier4.Text = vbNullString Then
				'@確定ﾎﾞﾀﾝ無効変更
                cmdReserveJRegist.Enabled = False
				Exit Function
			
			End If

		
			Dim carrierIdList As String()
			 carrierIdList = {
				txtToCarrier1.Text,
				txtToCarrier2.Text,
				txtToCarrier3.Text,
				txtToCarrier4.Text
			}
			Dim seen As New HashSet(Of String)

			For i As Integer = 0 To carrierIdList.Length - 1
				Dim value As String = carrierIdList(i).Trim()

				' 空は無視
				If value = "" Then Continue For

				' Add が False → すでに存在＝重複の2個目
				If Not seen.Add(value) Then
					Dim duplicateOrder As Integer = i + 1   ' 1～4 の順番

					'@"<TRM0CW>$$キャリアIDが重複しています。設定を見直してください。"
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000C)
					'@警告ﾒｯｾｰｼﾞ
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

					Select Case duplicateOrder
						Case 1
							pubSetFocus(txtToCarrier1)
						Case 2
							pubSetFocus(txtToCarrier2)
						Case 3
							pubSetFocus(txtToCarrier3)
						Case 4
							pubSetFocus(txtToCarrier4)
					End Select

					Return False

					Exit For
				End If
			Next
                
            
            '@確定ﾎﾞﾀﾝ有効変更
            cmdReserveJRegist.Enabled = True
            '@ﾁｪｯｸOK
            prvcmdReserveJRegistEnabled_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdReserveJRegistEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

	'関数名：prvblnReserveJRegist_Chk
    '機　能：確定前ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：
    '更新日：
    '備　考：
    Private Function prvblnReserveJRegist_Chk(ByRef ltypAfterJReserveDetailList As List(Of typAfterJReserveDetail)) As Boolean

        Dim llngCnt         As Integer      'ｶｳﾝﾄ
		Dim lblnWfFlag		As Boolean		'WF存在判定用フラグ


        Try
            
            '@戻り値の初期化
            prvblnReserveJRegist_Chk = False
            
            '@予約済みではないか(あり得ないが念のため）
            If lblReserveStatus2.Text <> "未" Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM193W>$$予約済みのため登録できません。上書きする場合は解除してください。。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0193)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Function
            End If

			'wfList = New list(Of SlotPosition)
            
            '@グループAチェック
            With vsfToSlotMap1
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@1行でもWFが存在していれば
                    If .GetData(llngCnt, CMlngvsfToSlotMap1WfID) <> vbNullString   Then
						lblnWfFlag = true
						Dim tmp As typAfterJReserveDetail
						tmp.strWfId = .GetData(llngCnt, CMlngvsfToSlotMap1WfID)
						tmp.strSlotPosition = .GetData(llngCnt, CMlngvsfToSlotMap1SlotNo)
						tmp.strReserveGroup = CMstrGroupA
						tmp.strCarrierId = txtToCarrier1.Text
						ltypAfterJReserveDetailList.Add(tmp)
                    End If
                Next llngCnt

				'WF_ID もしくは キャリアIDのどちらかのみが入力されている場合はエラー
				If lblnWfFlag Xor txtToCarrier1.Text <> vbNullString Then
					'@"<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "キャリアIDまたはウェハ未設定")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtToCarrier1)
					Exit Function
				End If

            End With

			'フラグリセット
			lblnWfFlag = False
			'@グループBチェック
            With vsfToSlotMap2
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@1行でもWFが存在していれば
                    If .GetData(llngCnt, CMlngvsfToSlotMap2WfID) <> vbNullString   Then
						lblnWfFlag = true
						Dim tmp As typAfterJReserveDetail
						tmp.strWfId = .GetData(llngCnt, CMlngvsfToSlotMap2WfID)
						tmp.strSlotPosition = .GetData(llngCnt, CMlngvsfToSlotMap2SlotNo)
						tmp.strReserveGroup = CMstrGroupB
						tmp.strCarrierId = txtToCarrier2.Text
						ltypAfterJReserveDetailList.Add(tmp)
                    End If
                Next llngCnt

				'WF_ID もしくは キャリアIDのどちらかのみが入力されている場合はエラー
				If lblnWfFlag Xor txtToCarrier2.Text <> vbNullString Then
					'@"<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "キャリアIDまたはウェハ未設定")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtToCarrier2)
					Exit Function
				End If

            End With
            
			'フラグリセット
			lblnWfFlag = False
			'@グループBチェック
            With vsfToSlotMap3
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@1行でもWFが存在していれば
                    If .GetData(llngCnt, CMlngvsfToSlotMap3WfID) <> vbNullString   Then
						lblnWfFlag = true
						Dim tmp As typAfterJReserveDetail
						tmp.strWfId = .GetData(llngCnt, CMlngvsfToSlotMap3WfID)
						tmp.strSlotPosition = .GetData(llngCnt, CMlngvsfToSlotMap3SlotNo)
						tmp.strReserveGroup = CMstrGroupC
						tmp.strCarrierId = txtToCarrier3.Text
						ltypAfterJReserveDetailList.Add(tmp)
                    End If
                Next llngCnt

				'WF_ID もしくは キャリアIDのどちらかのみが入力されている場合はエラー
				If lblnWfFlag Xor txtToCarrier3.Text <> vbNullString Then
					'@"<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "キャリアIDまたはウェハ未設定")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtToCarrier3)
					Exit Function
				End If

            End With

			'フラグリセット
			lblnWfFlag = False
			'@グループDチェック
            With vsfToSlotMap4
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@1行でもWFが存在していれば
                    If .GetData(llngCnt, CMlngvsfToSlotMap4WfID) <> vbNullString   Then
						lblnWfFlag = true
						Dim tmp As typAfterJReserveDetail
						tmp.strWfId = .GetData(llngCnt, CMlngvsfToSlotMap4WfID)
						tmp.strSlotPosition = .GetData(llngCnt, CMlngvsfToSlotMap4SlotNo)
						tmp.strReserveGroup = CMstrGroupD
						tmp.strCarrierId = txtToCarrier4.Text
						ltypAfterJReserveDetailList.Add(tmp)
                    End If
                Next llngCnt

				'WF_ID もしくは キャリアIDのどちらかのみが入力されている場合はエラー
				If lblnWfFlag Xor txtToCarrier4.Text <> vbNullString Then
					'@"<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "キャリアIDまたはウェハ未設定")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtToCarrier4)
					Exit Function
				End If

            End With



			'WF格納したWF_IDの中に重複がないか確認
			'同じ値を2つ入れられないHashSetを用いる
			Dim wfSet As New HashSet(Of String)

			For Each item In ltypAfterJReserveDetailList

				If wfSet.Contains(item.strWfId) Then
					' 重複あり
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009W)
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					prvblnReserveJRegist_Chk = False
					Exit Function
				End If

				wfSet.Add(item.strWfId)

			Next

			
			Dim carrierIdList As String()
			 carrierIdList = {
				txtToCarrier1.Text,
				txtToCarrier2.Text,
				txtToCarrier3.Text,
				txtToCarrier4.Text
			}
			Dim seen As New HashSet(Of String)

			For i As Integer = 0 To carrierIdList.Length - 1
				Dim value As String = carrierIdList(i).Trim()

				' 空は無視
				If value = "" Then Continue For

				' Add が False → すでに存在＝重複の2個目
				If Not seen.Add(value) Then
					Dim duplicateOrder As Integer = i + 1   ' 1～4 の順番

					'@"<TRM0CW>$$キャリアIDが重複しています。設定を見直してください。"
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000C)
					'@警告ﾒｯｾｰｼﾞ
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

					Select Case duplicateOrder
						Case 1
							pubSetFocus(txtToCarrier1)
						Case 2
							pubSetFocus(txtToCarrier2)
						Case 3
							pubSetFocus(txtToCarrier3)
						Case 4
							pubSetFocus(txtToCarrier4)
					End Select

					Return False

					Exit For
				End If
			Next


            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnReserveJRegist_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnReserveJRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

	'関数名：prvblnReserveJRegist_Chk
    '機　能：確定前ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：
    '更新日：
    '備　考：
    Private Function prvblnReserveJDel_Chk(ByRef ltypAfterJReserveDetailList As List(Of typAfterJReserveDetail), ByRef lstrReserveId As String) As Boolean

        Dim llngCnt         As Integer      'ｶｳﾝﾄ
		Dim lblnWfFlag		As Boolean		'WF存在判定用フラグ


        Try
            
            '@戻り値の初期化
            prvblnReserveJDel_Chk = False
            
			'@予約済みか確認(あり得ないが念のため）
            If lblReserveStatus2.Text = "未" Or lblReserveStatus2.Text = "" Then  
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM194W>$$未予約のため削除できません。データを確認してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0194)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                prvblnReserveJDel_Chk = False
                Exit Function
				
			Else

				' 数値以外NG
				For Each ch As Char In lblReserveStatus2.Text
					 If Not Char.IsDigit(ch) Then
						'@「"<TRM194W>$$未予約のため削除できません。データを確認してください。"」のﾒｯｾｰｼﾞ表示
						pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0194)
						Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
						prvblnReserveJDel_Chk = False
						Exit Function
					End If
				Next

				lstrReserveId = lblReserveStatus2.Text

            End If

			'wfList = New list(Of SlotPosition)
            
            '@グループAチェック
            With vsfToSlotMap1
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@1行でもWFが存在していれば
                    If .GetData(llngCnt, CMlngvsfToSlotMap1WfID) <> vbNullString   Then
						lblnWfFlag = true
						Dim tmp As typAfterJReserveDetail
						tmp.strWfId = .GetData(llngCnt, CMlngvsfToSlotMap1WfID)
						tmp.strSlotPosition = .GetData(llngCnt, CMlngvsfToSlotMap1SlotNo)
						tmp.strReserveGroup = CMstrGroupA
						tmp.strCarrierId = txtToCarrier1.Text
						ltypAfterJReserveDetailList.Add(tmp)
                    End If
                Next llngCnt

				'WF_ID もしくは キャリアIDのどちらかのみが入力されている場合はエラー
				If lblnWfFlag Xor txtToCarrier1.Text <> vbNullString Then
					'@"<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "キャリアIDまたはウェハ未設定")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtToCarrier1)
					Exit Function
				End If

            End With

			'フラグリセット
			lblnWfFlag = False
			'@グループBチェック
            With vsfToSlotMap2
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@1行でもWFが存在していれば
                    If .GetData(llngCnt, CMlngvsfToSlotMap2WfID) <> vbNullString   Then
						lblnWfFlag = true
						Dim tmp As typAfterJReserveDetail
						tmp.strWfId = .GetData(llngCnt, CMlngvsfToSlotMap2WfID)
						tmp.strSlotPosition = .GetData(llngCnt, CMlngvsfToSlotMap2SlotNo)
						tmp.strReserveGroup = CMstrGroupB
						tmp.strCarrierId = txtToCarrier2.Text
						ltypAfterJReserveDetailList.Add(tmp)
                    End If
                Next llngCnt

				'WF_ID もしくは キャリアIDのどちらかのみが入力されている場合はエラー
				If lblnWfFlag Xor txtToCarrier2.Text <> vbNullString Then
					'@"<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "キャリアIDまたはウェハ未設定")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtToCarrier2)
					Exit Function
				End If

            End With
            
			'フラグリセット
			lblnWfFlag = False
			'@グループBチェック
            With vsfToSlotMap3
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@1行でもWFが存在していれば
                    If .GetData(llngCnt, CMlngvsfToSlotMap3WfID) <> vbNullString   Then
						lblnWfFlag = true
						Dim tmp As typAfterJReserveDetail
						tmp.strWfId = .GetData(llngCnt, CMlngvsfToSlotMap3WfID)
						tmp.strSlotPosition = .GetData(llngCnt, CMlngvsfToSlotMap3SlotNo)
						tmp.strReserveGroup = CMstrGroupC
						tmp.strCarrierId = txtToCarrier3.Text
						ltypAfterJReserveDetailList.Add(tmp)
                    End If
                Next llngCnt

				'WF_ID もしくは キャリアIDのどちらかのみが入力されている場合はエラー
				If lblnWfFlag Xor txtToCarrier3.Text <> vbNullString Then
					'@"<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "キャリアIDまたはウェハ未設定")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtToCarrier3)
					Exit Function
				End If

            End With

			'フラグリセット
			lblnWfFlag = False
			'@グループDチェック
            With vsfToSlotMap4
                
                For llngCnt = 1 To .Rows.Count - 1
                    '@1行でもWFが存在していれば
                    If .GetData(llngCnt, CMlngvsfToSlotMap4WfID) <> vbNullString   Then
						lblnWfFlag = true
						Dim tmp As typAfterJReserveDetail
						tmp.strWfId = .GetData(llngCnt, CMlngvsfToSlotMap4WfID)
						tmp.strSlotPosition = .GetData(llngCnt, CMlngvsfToSlotMap4SlotNo)
						tmp.strReserveGroup = CMstrGroupD
						tmp.strCarrierId = txtToCarrier4.Text
						ltypAfterJReserveDetailList.Add(tmp)
                    End If
                Next llngCnt

				'WF_ID もしくは キャリアIDのどちらかのみが入力されている場合はエラー
				If lblnWfFlag Xor txtToCarrier4.Text <> vbNullString Then
					'@"<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "キャリアIDまたはウェハ未設定")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					pubSetFocus(txtToCarrier4)
					Exit Function
				End If

            End With



	
			'同じ値を2つ入れられないHashSetを用いる
			Dim wfSet As New HashSet(Of String)

			For Each item In ltypAfterJReserveDetailList

				If wfSet.Contains(item.strWfId) Then
					' 重複あり
					pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009W)
					Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
					prvblnReserveJDel_Chk = False
					Exit Function
				End If

				wfSet.Add(item.strWfId)

			Next


            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnReserveJDel_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnReserveJDel_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCarrierControl_Proc
    '機　能：ﾃｷｽﾄﾎﾞｯｸｽ、ｷｬﾘｱ選択ﾎﾞﾀﾝ制御処理
    '引　数：lctlvsfcontrol：ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ
    '　　　：lctltxtcontrol：ﾃｷｽﾄﾎﾞｯｸｽｺﾝﾄﾛｰﾙ
    '　　　：lctlcmdcontrol：ｺﾏﾝﾄﾞﾎﾞﾀﾝｺﾝﾄﾛｰﾙ
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：

    Private Sub prvCarrierControl_Proc(ByRef lctlVsfControl As C1FlexGrid, _
                                       ByRef lctltxtcontrol As SETextBoxEx.TextBoxEx, _
                                       ByRef lctlcmdcontrol As Button)

        Dim llngCnt             As Integer          'ｶｳﾝﾄ
        Dim lblnEnabledFlag     As Boolean          '制御ﾌﾗｸﾞ(True:有効、False:無効)

        Try

            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　引継ぎ情報のｸﾞﾘｯﾄﾞのWFIDの存在有無を判定し、ﾃｷｽﾄﾎﾞｯｸｽ、ｷｬﾘｱ選択ﾎﾞﾀﾝ制御処理を行なう
            '@****************************************************************************

            '@初期化
            lblnEnabledFlag = False
            
            '@対象ｸﾞﾘｯﾄﾞｺﾝﾄﾛｰﾙ
            With lctlVsfControl
            
                '@ﾀｲﾄﾙ以外か
                If .Row <> 0 Then
                
                    For llngCnt = 1 To .Rows.Count - 1
                        
                        '@WFIDがNULL以外か
                        If .GetData(llngCnt, CMlngvsfSlotMapWfId) <> vbNullString Then
                            
                            '@制御ﾌﾗｸﾞに"True:有効"をｾｯﾄする
                            lblnEnabledFlag = True
                            Exit For
                        End If
                    Next llngCnt
                End If
            End With
                
            '@制御ﾌﾗｸﾞが"True:有効"か
            If lblnEnabledFlag = True Then
                
                '@各種ｺﾝﾄﾛｰﾙを有効にする
                lctltxtcontrol.Enabled = True       'ｷｬﾘｱIDﾃｷｽﾄ
                lctlcmdcontrol.Enabled = True       '空きｷｬﾘｱ選択ﾎﾞﾀﾝ

            Else
                '@制御ﾌﾗｸﾞが"False:無効"の場合
                
                '@各種ｺﾝﾄﾛｰﾙを無効にする
                lctltxtcontrol.Enabled = False      'ｷｬﾘｱIDﾃｷｽﾄ
                lctltxtcontrol.Text = vbNullString
                lctlcmdcontrol.Enabled = False      '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapFormat_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：prvVsfSlotMapCell_Proc
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ選択行以外の情報をｸﾘｱし情報を反映
    '引　数：lctlvsfcontrol ：選択ｸﾞﾘｯﾄﾞ名
    '　　　：llngRow        ：選択行
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    '
    Private Sub prvVsfSlotMapCell_Proc(ByRef lctlVsfControl As C1FlexGrid, _
                                       ByVal llngRow As Integer)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        
        Try
            
            '@****************************************************************************
            '@★当Functionの処理概要★
            '@　各種ｸﾞﾘｯﾄﾞのWFIDが退避構造体のWFIDと同じか判定し、各種ｸﾞﾘｯﾄﾞの表示制御を行なう
            '@****************************************************************************
            
            '@分割元ｽﾛｯﾄﾏｯﾌﾟ
            With vsfSlotMap
            
                For llngCnt = 1 To .Rows.Count - 1
                    '@背景色が白の場合
                    'If .GetCellRange(llngCnt, CMlngvsfSlotMapWfId).Style.BackColor = vbWhite Then
						'@退避構造体のWFIDと分割元ｽﾛｯﾄﾏｯﾌﾟに同じWFIDが存在するか
						If .GetData(llngCnt, CMlngvsfSlotMapWfID) = mtypTransfer.strWfId And .GetData(llngCnt, CMlngvsfSlotMapWfID) <> vbNullString  Then
							Dim newStyle    As CellStyle    
							Dim cellRange   As CellRange    

							'@分割元ｽﾛｯﾄﾏｯﾌﾟの対象行の文字色をｸﾞﾚｰにする
							newStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor")
							newStyle.BackColor = vbWhite
							newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
							cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapWfID, llngCnt, CMlngvsfSlotMapCarrierId)
							cellRange.Style = newStyle

						End If
					'End If
                Next llngCnt
            End With
            
            
            '@ｽﾛｯﾄﾏｯﾌﾟA
            With vsfToSlotMap1
            
                For llngCnt = 1 To .Rows.Count - 1
                    '@背景色が白の場合
                   ' If .GetCellRange(.Row, CMlngvsfToSlotMap1WfId).Style.BackColor = vbWhite Then
						'@退避構造体のWFIDと分割予約1ｽﾛｯﾄﾏｯﾌﾟに同じWFIDが存在するか
						If .GetData(llngCnt, CMlngvsfToSlotMap1WfID) = mtypTransfer.strWfId Then
                        
							'@分割予約1ｽﾛｯﾄﾏｯﾌﾟの対象行をNULLにする
							.SetData(llngCnt, CMlngvsfToSlotMap1WfID, vbNullString)                   'WFID
							.SetData(llngCnt, CMlngvsfToSlotMap1BNo, 0)                    '移載元№

						End If
					'End If
                Next llngCnt
            End With
            
            
            '@ｽﾛｯﾄﾏｯﾌﾟB
            With vsfToSlotMap2
            
                For llngCnt = 1 To .Rows.Count - 1
                     '@背景色が白の場合
                  '  If .GetCellRange(.Row, CMlngvsfToSlotMap1WfId).Style.BackColor = vbWhite Then
						'@退避構造体のWFIDと分割予約2ｽﾛｯﾄﾏｯﾌﾟに同じWFIDが存在するか
						If .GetData(llngCnt, CMlngvsfToSlotMap2WfID) = mtypTransfer.strWfId Then
                        
							'@分割予約2ｽﾛｯﾄﾏｯﾌﾟの対象行をNULLにする
							.SetData(llngCnt, CMlngvsfToSlotMap2WfID, vbNullString)                   'WFID
							.SetData(llngCnt, CMlngvsfToSlotMap2BNo, 0)                    '移載元№

						End If
					'End If
                Next llngCnt
            End With

			'@ｽﾛｯﾄﾏｯﾌﾟC
            With vsfToSlotMap3
            
                For llngCnt = 1 To .Rows.Count - 1
                    '@背景色が白の場合
                    'If .GetCellRange(.Row, CMlngvsfToSlotMap1WfId).Style.BackColor = vbWhite Then
						'@退避構造体のWFIDと分割予約2ｽﾛｯﾄﾏｯﾌﾟに同じWFIDが存在するか
						If .GetData(llngCnt, CMlngvsfToSlotMap3WfID) = mtypTransfer.strWfId Then
                        
							'@分割予約2ｽﾛｯﾄﾏｯﾌﾟの対象行をNULLにする
							.SetData(llngCnt, CMlngvsfToSlotMap3WfID, vbNullString)                   'WFID
							.SetData(llngCnt, CMlngvsfToSlotMap3BNo, 0)                    '移載元№
						End If
                    'End If
                Next llngCnt
            End With

			'@ｽﾛｯﾄﾏｯﾌﾟD
            With vsfToSlotMap4
            
                For llngCnt = 1 To .Rows.Count - 1
                    '@背景色が白の場合
                    'If .GetCellRange(.Row, CMlngvsfToSlotMap1WfId).Style.BackColor = vbWhite Then
						'@退避構造体のWFIDと分割予約2ｽﾛｯﾄﾏｯﾌﾟに同じWFIDが存在するか
						If .GetData(llngCnt, CMlngvsfToSlotMap4WfID) = mtypTransfer.strWfId Then
                        
							'@分割予約2ｽﾛｯﾄﾏｯﾌﾟの対象行をNULLにする
							.SetData(llngCnt, CMlngvsfToSlotMap4WfID, vbNullString)                   'WFID
							.SetData(llngCnt, CMlngvsfToSlotMap4BNo, 0)                    '移載元№

						End If
					'End If
                Next llngCnt
            End With
            
            
            '@退避した情報をｽﾛｯﾄﾏｯﾌﾟへ反映
            With lctlVsfControl
            
                .SetData(llngRow, CMlngvsfSlotMapWfID, mtypTransfer.strWfId)                   'WFID
				.SetData(llngRow, CMlngvsfSlotMapBNo, mtypTransfer.lngSlotNo)                  '移載元№

            
                '@設定文字色は黒で表示する
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                Dim cellRange As CellRange
                newStyle.ForeColor = SystemColors.WindowText
				newStyle.backColor = vbWhite
                cellRange = .GetCellRange(llngRow, CMlngvsfSlotMapWFID, llngRow, CMlngvsfSlotMapBNo)
                cellRange.Style = newStyle

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfSlotMapCell_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    ''' <summary>
    ''' TFT/CF機種コンボ設定
    ''' </summary>
    Private Sub prvcmbTftPdList_Disp()

        Dim lblnAns As Boolean                                   
        Dim ltypTFTandCFList As New List(Of typTFTandCF)

        Try
            
            'レスポンス開始
            Dim lstrEventName As String = "prvcmbTftPdList_Disp"
            Call pubResponseStart(Me.Name, lstrEventName)

            'TFT/CFのODF貼り合せリスト取得
            lblnAns = pubblnOdfTftCfList_Sel(CPstrasm_odftftcflistVer, ltypTFTandCFList)

            '結果OK
            If lblnAns = True Then
                With cmbTFTandCF

                    '初期化
                    .Clear()
                    .Enabled = True                                                 
                    .DirectInput = False    '直接入力(False)
                    .DispCols = 1           '表示列数
                    .BackColor = Color.White
                    .Font = New Font(.Font.FontFamily, 12, .Font.Style, .Font.Unit)
                    .GridFont = New Font(.GridFont.FontFamily, 12, .GridFont.Style, .GridFont.Unit)
                    .RowHeight = 18                              
                    .ColAlignment(CMintCmbPdId) = TextAlignEnum.LeftCenter  

                    'コンボ配列(PdId/PdVer/CfPdId/CfPdVer/ForeColor/BackColor)
                    '空欄ありの為,最初の1行は空欄をセット
                    .AddItem(CPstrSpace & vbTab & CPstrSpace)
                    For Each tmp As typTFTandCF In ltypTFTandCFList
                        .AddItem(tmp.strPdId & vbTab & _
                                 tmp.strPdVersion & vbTab & _
                                 tmp.strCfPdId & vbTab & _
                                 tmp.strCfPdVersion & vbTab & _
                                 tmp.strForeColor & vbTab & _
                                 tmp.strBackColor)
                    Next                    
                           
                    .ValueCol = CMintCmbPdId
                    .ListIndex = 0
                    .Enabled = True
                    
                    'レスポンス終了
                    Call publngResponseEnd(Me.Name, lstrEventName)
                End With
            Else
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)
            End If
            
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbTftPdList_Disp"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' TFT/CFのロットリスト表示
    ''' TFT/CF共に同じロジックなのでグリッドObjを渡してロジック共通化
    ''' </summary>
    ''' <param name="ltypOdfReserveList"></param>
    Private Sub prvvsfTFTandCfReserveList_Disp(ByRef ltypOdfReserveList As List(Of typOdfReserveRep))

        Dim lintRow As Integer
        Dim lblnNewRow As Boolean
        Dim lobjGrid As C1.Win.C1FlexGrid.C1FlexGrid 

        Try

            '取得日時
            lblNowDate0.Text = Format$(Now(), CPstrDateFormat)
            
            With vsfTFTList
                .Redraw =  False
                .Rows.Count = .Rows.Fixed
                .Enabled = False
            End With            
            
            With vsfCFList
                .Redraw =  False
                .Rows.Count = .Rows.Fixed
                .Enabled = False
            End With
            
            For Each tmp As typOdfReserveRep In ltypOdfReserveList

                'CF
                If tmp.strCfFlag = CPstrCF Then
                    lobjGrid = vsfCFList
                'TFT
                Else
                    lobjGrid = vsfTFTList
                End If

                With lobjGrid
                    '先頭行の場合は行追加
                    If .Rows.Count - 1 = CMlngvsfGridTitleRow Then
                        lblnNewRow = True

                    Else
                        '現在の行とLOTが同じ場合は行追加しないで
                        'WF情報を追加する
                        If .GetData(.Rows.Count-1, CMlngvsfReserveLotId) = tmp.strLotId Then
                            lblnNewRow = False
                        Else
                            lblnNewRow = True
                        End If
                    End If

                    '行追加
                    If lblnNewRow = True Then
                        .AddItem(.Rows.Count)       '行追加
                        lintRow = .Rows.Count - 1
                        .SetData(lintRow, CMlngvsfReserveNo, lintRow)
                        .SetData(lintRow, CMlngvsfReserveStat, tmp.strCurrentStatus)
                        .SetData(lintRow, CMlngvsfReserveStatName, tmp.strCurrentStatusName)
                        .SetData(lintRow, CMlngvsfReservePdId, tmp.strPdId)
                        .SetData(lintRow, CMlngvsfReserveLotId, tmp.strLotId)
                        .SetData(lintRow, CMlngvsfReserveWfId, tmp.strWfId.Substring(7,3))  '#以降を表示
                        .SetData(lintRow, CMlngvsfReserveCarrierId, tmp.strCarrierId)
                        .SetData(lintRow, CMlngvsfReserveFlowClass, tmp.strFlowClass)
                        .SetData(lintRow, CMlngvsfReserveSlotPos, tmp.strSlotPosition)
                        .SetData(lintRow, CMlngvsfReserveFlag, tmp.strReserveFlag)
                        .SetData(lintRow, CMlngvsfReserveWfes, tmp.strWfId)

                    Else
                        lintRow = .Rows.Count - 1
                        Dim lstrTmpWfId As String
                        Dim lstrTmpSlotPos As String
                        Dim lstrTmpWfes As String

                        'WFIDとSLOTを「,」で追加
                        lstrTmpWfId = .GetData(.Rows.Count-1, CMlngvsfReserveWfId)
                        lstrTmpSlotPos = .GetData(.Rows.Count-1, CMlngvsfReserveSlotPos)
                        lstrTmpWfes = .GetData(.Rows.Count-1, CMlngvsfReserveWfes)

                        .SetData(lintRow, CMlngvsfReserveWfId, lstrTmpWfId + "," + tmp.strWfId.Substring(8,2))  ’#は除く
                        .SetData(lintRow, CMlngvsfReserveSlotPos, lstrTmpSlotPos + "," + tmp.strSlotPosition)
                        .SetData(lintRow, CMlngvsfReserveWfes, lstrTmpWfes + "," + tmp.strWfId) 'WFIDをカンマ区切りで繋げる
                    End If

                    '予約済みの場合は背景色変更
                    If tmp.strReserveFlag = CPstrFlagOn Then
                        Dim newStyle_BackColor_CPlngGridDarkGray As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                        newStyle_BackColor_CPlngGridDarkGray.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngGridDarkGray))
                        Dim cellRange As CellRange = .GetCellRange(lintRow, CMlngvsfReserveNo, lintRow, .Cols.Count-1)
                        cellRange.Style = newStyle_BackColor_CPlngGridDarkGray
                    End If

                End With
            Next

            With vsfTFTList
                .Redraw =  True
                .Enabled = True
                .Row = CMlngvsfGridTitleRow     'タイトル行に行設定
            End With            
            
            With vsfCFList
                .Redraw =  True
                .Enabled = True
                .Row = CMlngvsfGridTitleRow     'タイトル行に行設定
            End With
                    
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierList_Disp"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 選択ロットのWF情報表示(予約)
    ''' </summary>
    ''' <param name="lobjLotGrid"></param>
    ''' <param name="lobjWfGrid"></param>
    ''' <param name="lstrLotId"></param>
    Private Sub prvvsfTFTandCfReserveWfList_Disp(ByRef lobjLotGrid As C1.Win.C1FlexGrid.C1FlexGrid, _
                ByRef lobjWfGrid As C1.Win.C1FlexGrid.C1FlexGrid, ByVal lstrLotId As String)

        Try
            With lobjLotGrid

                .Enabled = False

                Dim lstrAllWf As String = .GetData(.Row, CMlngvsfReserveWfId)
                '先頭#除去
                Dim lIntTargetIndex As Integer = lstrAllWf.IndexOf("#")
                If lIntTargetIndex >= 0 Then
                    lstrAllWf = lstrAllWf.Substring(lIntTargetIndex+1)
                End If
                Dim lstrAllSlot As String = .GetData(.Row, CMlngvsfReserveSlotPos)

                'WFIDの#以降とSLOTの長さは同じ
                If lstrAllWf.Length <> lstrAllSlot.Length Then
                    'Public Const CPstrMsgInf0083        As String = "<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "TFT/CF SLOT情報の不一致")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Sub
                End If

                '中間WF在庫から作成したロットはロットID/WFIDの先頭部分が異なる時があるので
                'WFIDから作成する
                lstrAllWf = .GetData(.Row, CMlngvsfReserveWfes)

                'カンマ区切りでつながった文字なので分解する
                'NULLで終わり
                While lstrAllWf <> vbNullString
                    '文字列をカンマで検索
                    Dim lintTargetIndexWf = lstrAllWf.IndexOf(",")
                    Dim lintTargetIndexSlot = lstrAllSlot.IndexOf(",")

                    '検索結果なし
                    If lintTargetIndexWf < 0 Then
                        'WFリストへ表示
                        Call prvvsfTFTandCfReserveWfSlotSet(lobjWfGrid, lstrLotId, lstrAllWf, lstrAllSlot)
                        Exit While

                    '検索結果あり
                    Else
                        'WF/SLOTを抜き出す
                        Dim lstrWf As String = lstrAllWf.Substring(0,lintTargetIndexWf)
                        Dim lstrSlot As String = lstrAllSlot.Substring(0,lintTargetIndexSlot)

                        'WFリストへ表示
                        Call prvvsfTFTandCfReserveWfSlotSet(lobjWfGrid, lstrLotId, lstrWf, lstrSlot)

                        '文字列の更新
                        lstrAllWf = lstrAllWf.Substring(lintTargetIndexWf+1)
                        lstrAllSlot = lstrAllSlot.Substring(lintTargetIndexSlot+1)
                    End If
                End While

                .Enabled = True
            End With
                    
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierList_Disp"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 選択ロットのWF情報表示(予約)グリッド表示
    ''' </summary>
    ''' <param name="lobjWfGrid"></param>
    ''' <param name="lstrLotId"></param>
    ''' <param name="lstrWfId"></param>
    ''' <param name="lstrSlot"></param>
    Private Sub prvvsfTFTandCfReserveWfSlotSet(ByRef lobjWfGrid As C1.Win.C1FlexGrid.C1FlexGrid, _
            ByVal lstrLotId As String, ByVal lstrWfId As String, ByVal lstrSlot As String)

        Dim lintRow As Integer

        Try
            With lobjWfGrid
                For lintRow = 1 To .Rows.Count - 1
                    If .GetData(lintRow, CMlngvsfWfReserveSlot) = lstrSlot Then
                        .SetData(lintRow, CMlngvsfWfReserveId, lstrWfId)
                        Exit For
                    End If
                Next
            End With
                    
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCarrierList_Disp"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 予約確定ボタンの有効チェック
    ''' </summary>
    Private Sub prvReserveRegistButtonCheck()

        Dim lintRow As Integer
        Dim lintRow2 As Integer
        Dim lblnDuplication As Boolean
        Dim lintTFTWfCnt As Integer
        Dim lintCfWfCnt As Integer
        Dim lstrTFTSlot As String = vbNullString
        Dim lstrCfSlot As String = vbNullString

        Try
            '[>][<]ボタン制御
            '予約選択中
            If lblReserveStatus.Text = CMstrReserveSelect Then
                If lblTFTLotId.Text = vbNullString Then
                    'cmdTFTMove.Enabled = True              '[>]
                    cmdTFTMoveCancel.Enabled = False        '[<]
                Else
                    cmdTFTMove.Enabled = False              '[>]
                    cmdTFTMoveCancel.Enabled = True         '[<]
                End If

                If lblCFLotId.Text = vbNullString Then
                    'cmdCFMove.Enabled = True               '[>]
                    cmdCFMoveCancel.Enabled = False         '[<]
                Else
                    cmdCFMove.Enabled = False               '[>]
                    cmdCFMoveCancel.Enabled = True          '[<]
                End If
            Else
                cmdTFTMove.Enabled = False                  '[>]
                cmdTFTMoveCancel.Enabled = False            '[<]
                cmdCFMove.Enabled = False                   '[>]
                cmdCFMoveCancel.Enabled = False             '[<]
            End If

            'ボタン無効
            cmdRegist.Enabled = False
            cmdDel.Enabled = False

            '予約状況に何もない場合はチェックなし
            '画面起動等の初期化時を想定
            IF lblReserveStatus.Text = vbNullString Then
                Exit Sub
            End If

            '***************************
            'TFT WFListの重複チェック
            '***************************
            With vsfTFTWfList
                lintTFTWfCnt = 0
                lblnDuplication = False

                For lintRow = 1 To .Rows.Count - 1
                    
                    'WFID
                    Dim lstrWfId As String = .GetData(lintRow, CMlngvsfWfReserveId)

                    If lstrWfId <> vbNullString Then
                        lintTFTWfCnt = lintTFTWfCnt + 1
                        For lintRow2 = 1 To .Rows.Count - 1
                            
                            If lintRow <> lintRow2 Then
                                'WFID
                                Dim lstrWfId2 As String = .GetData(lintRow2, CMlngvsfWfReserveId)

                                If lstrWfId = lstrWfId2 Then
                                    lblnDuplication = True
                                    Exit For
                                End If
                            End If
                        Next

                        'SLOT文字を追記
                        lstrTFTSlot = lstrTFTSlot + .GetData(lintRow, CMlngvsfWfReserveSlot)
                    End If

                    'TFT重複チェックエラー
                    If lblnDuplication = True Then
                        'Public Const CPstrMsgInf0083        As String = "<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "TFT WF重複")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Sub
                    End If
                Next
            End With
                    
            '***************************
            'CF WFListの重複チェック
            '***************************
            With vsfCFWfList
                lintCFWfCnt = 0
                lblnDuplication = False

                For lintRow = 1 To .Rows.Count - 1
                    
                    'WFID
                    Dim lstrWfId As String = .GetData(lintRow, CMlngvsfWfReserveId)

                    If lstrWfId <> vbNullString Then
                        lintCFWfCnt = lintCFWfCnt + 1
                        For lintRow2 = 1 To .Rows.Count - 1
                            
                            If lintRow <> lintRow2 Then
                                'WFID
                                Dim lstrWfId2 As String = .GetData(lintRow2, CMlngvsfWfReserveId)

                                If lstrWfId = lstrWfId2 Then
                                    lblnDuplication = True
                                    Exit For
                                End If
                            End If
                        Next

                        'SLOT文字を追記
                        lstrCfSlot = lstrCfSlot + .GetData(lintRow, CMlngvsfWfReserveSlot)
                    End If

                    'CF重複チェックエラー
                    If lblnDuplication = True Then
                        'Public Const CPstrMsgInf0083        As String = "<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "CF WF重複")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Sub
                    End If
                Next
            End With

            'TFT/CFのWF枚数確認
            '0チェック
            If lintTFTWfCnt = 0 Or lintCFWfCnt = 0 Then
                '選択途中ではTFT/CFのどちらかは0なのでエラー表示はしない
                Exit Sub
            End If

            '同じ枚数チェック
            IF lintTFTWfCnt <> lintCFWfCnt Then
                'Public Const CPstrMsgInf0083        As String = "<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "TFT/CF WF枚数の不一致")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If

            '同一スロット
            IF lstrTFTSlot <> lstrCfSlot Then
                'Public Const CPstrMsgInf0083        As String = "<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "TFT/CF SLOT位置の不一致")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If

            '***************************
            'ボタン有効判定
            '***************************
            '予約選択中
            If lblReserveStatus.Text = CMstrReserveSelect Then
                cmdRegist.Enabled = True

            '予約済み
            ElseIf lblReserveStatus.Text = CMstrReserveDone Then            
                cmdDel.Enabled = True
            
            'その他
            Else
                'Public Const CPstrMsgInf0083        As String = "<TRM83I>$$登録データに異常値が見つかりました。$設定を確認してください。$[%1]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0083, "想定外のシステムエラー")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Exit Sub
            End If

            'PR/ES/ZZ等のODF貼り合わせ対象の属性は
            '予約確定時のMES側の処理で実施する為、CLではしない

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvReserveButtonCheck"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' WFリストの予約エリアのclear処理
    ''' </summary>
    Private Sub prvOdfReserveInfoClear()

        Try            
            '*************
            '表示
            '*************
            lblTFTLotId.Text = vbNullString
            lblCFLotId.Text = vbNullString
            lblTFTCarrierId.Text = vbNullString
            lblCFCarrierId.Text = vbNullString
            lblReserveStatus.Text = vbNullString

            'WFリスト初期化
            Call prvvsfReserveWfList_Init(vsfTFTWfList)
            Call prvvsfReserveWfList_Init(vsfCFWfList)

            '予約ボタン有効チェック
            Call prvReserveRegistButtonCheck()

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvOdfReserveInfoClear"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' ODF予約情報の取得
    ''' </summary>
    ''' <param name="lstrLotId"></param>
    ''' <param name="lstrCfLotId"></param>
    Private Sub prvOdfReserveInfo(ByVal lstrLotId As String, ByVal lstrCfLotId As String)

        Dim lblnAns             As Boolean                                     
        Dim ltypOdfReserveInfo  As List(Of typOdfReserveInfo)

        Try
            '同じ検索はしない
            If lstrLotId <> vbNullString Then
                If lstrLotId = lblTFTLotId.Text Then
                    Exit Sub
                End If
            End If    

            If lstrCfLotId <> vbNullString Then
                If lstrCfLotId = lblCFLotId.Text Then
                    Exit Sub
                End If
            End If

            '*************
            '情報取得
            '*************
            'レスポンス開始
            Dim lstrEventName As String = "prvOdfReserveInfo"
            Call pubResponseStart(Me.Name, lstrEventName)

            ltypOdfReserveInfo = New List(Of typOdfReserveInfo)
            'TFT/CFのどちらで検索するか決定
            If lstrLotId <> vbNullString Then
                '引数(LOTID(TFT/CFのどちらでも可),WFID(ここでは指定なし))
                lblnAns = pubblnOdfReserveInfo_Sel(CPstrasm_odfreservereinfoVer, lstrLotId, vbNullString, ltypOdfReserveInfo)
            Else
                '引数(LOTID(TFT/CFのどちらでも可),WFID(ここでは指定なし))
                lblnAns = pubblnOdfReserveInfo_Sel(CPstrasm_odfreservereinfoVer, lstrCfLotId, vbNullString, ltypOdfReserveInfo)
            End If

            'Msg判定
            If lblnAns = True Then
                'レスポンス終了
                Call publngResponseEnd(Me.Name, lstrEventName)
            Else
                'レスポンス中止
                Call pubResponseCancel(Me.Name, lstrEventName)
                Exit Sub
            End If
            
            'WFリストclear
            '表示内容はここで初期化済
            Call prvOdfReserveInfoClear()

            '予約済みの場合は背景色変更
            Dim newStyle_BackColor_CPlngGridDarkGray As CellStyle = vsfTFTWfList.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
            newStyle_BackColor_CPlngGridDarkGray.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngGridDarkGray))

            'TFTとCFは同じデータ数なのでリストはTFTを回す
            Dim lintRow As Integer
            For lintRow = 1 To vsfTFTWfList.Rows.Count - 1
                
                'ラベル更新用
                For Each tmp As typOdfReserveInfo In ltypOdfReserveInfo
                    '検索ロットIDを現在のロットIDが同じ場合
                    'ODF貼り合せ予約時のロットIDが、その後、分割されてロットIDが異なることを想定
                    '分割しても予約DBはWFで登録しているのでロットIDの整合性は見ていない
                    If lstrLotId = tmp.strCurrentLotId Or lstrCfLotId = tmp.strCurrentCfLotId Then
                        'LOT/CARRIER情報更新
                        If lblTFTLotId.Text = vbNullString Then
                            lblTFTLotId.Text = tmp.strCurrentLotId
                            lblCFLotId.Text = tmp.strCurrentCfLotId
                            lblTFTCarrierId.Text = tmp.strCurrentCarrierId
                            lblCFCarrierId.Text = tmp.strCurrentCfCarrierId
                            '予約済表示
                            lblReserveStatus.Text = CMstrReserveDone
                            Exit For
                        End If
                    End If
                Next

                For Each tmp As typOdfReserveInfo In ltypOdfReserveInfo
                    'SLOTが同じ場合
                    If vsfTFTWfList.GetData(lintRow, CMlngvsfWfReserveSlot) = tmp.strSlotPosition Then
                        'TFT
                        vsfTFTWfList.SetData(lintRow, CMlngvsfWfReserveId, tmp.strWfId)
                        'CF
                        vsfCFWfList.SetData(lintRow, CMlngvsfWfReserveId, tmp.strCfWfId)

                        '予約色
                        Dim cellRangeTft As CellRange = vsfTFTWfList.GetCellRange(lintRow, CMlngvsfWfReserveId, lintRow, vsfTFTWfList.Cols.Count-1)
                        cellRangeTft.Style = newStyle_BackColor_CPlngGridDarkGray
                        Dim cellRangeCf As CellRange = vsfCFWfList.GetCellRange(lintRow, CMlngvsfWfReserveId, lintRow, vsfCFWfList.Cols.Count-1)
                        cellRangeCf.Style = newStyle_BackColor_CPlngGridDarkGray

                        '選択したロットIDと現在のロットIDが異なる場合
                        If lblTFTLotId.Text <> tmp.strCurrentLotId Then
                            vsfTFTWfList.SetData(lintRow, CMlngvsfWfReserveId2, "×")
                        End If
                        If lblCFLotId.Text <> tmp.strCurrentCfLotId Then
                            vsfCFWfList.SetData(lintRow, CMlngvsfWfReserveId2, "×")
                        End If

                        Exit For                    
                    End If
                Next
            Next  

            '予約ボタン有効チェック
            Call prvReserveRegistButtonCheck()

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnOdfReserveInfo"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' ODF予約表示
    ''' </summary>
    ''' <param name="ltypOdfReserveInfo"></param>
    Private Sub prvvsReserveInfo_Disp(ByRef ltypOdfReserveInfo As List(Of typOdfReserveInfo))

        Dim lintRow As Integer

        Try

            '取得日時
            lblNowDate1.Text = Format$(Now(), CPstrDateFormat)
            
            With vsfReserveInfo
                .Redraw =  False
                .Rows.Count = .Rows.Fixed
                .Enabled = False

                Dim lintMergeRowS1 As Integer = CMlngvsfGridTitleRow2 + 1
                Dim lintMergeRowS2 As Integer = CMlngvsfGridTitleRow2 + 1
                Dim lintMergeRowS3 As Integer = CMlngvsfGridTitleRow2 + 1

                For Each tmp As typOdfReserveInfo In ltypOdfReserveInfo
                    .AddItem(.Rows.Count)       '行追加
                    lintRow = .Rows.Count - 1
                    .SetData(lintRow, CMlngvsfInfoNo, lintRow - 1)
                    '.SetData(lintRow, CMlngvsfInfoTFTLotId, tmp.strLotId)
                    .SetData(lintRow, CMlngvsfInfoTFTLotId, tmp.strCurrentLotId)
                    '.SetData(lintRow, CMlngvsfInfoTFTCarrier, tmp.strCarrierId)
                    .SetData(lintRow, CMlngvsfInfoTFTCarrier, tmp.strCurrentCarrierId)
                    .SetData(lintRow, CMlngvsfInfoTFTSlot, tmp.strSlotPosition)
                    .SetData(lintRow, CMlngvsfInfoTFTWfId, tmp.strWfId)
                    .SetData(lintRow, CMlngvsfInfoCFWfId, tmp.strCfWfId)
                    .SetData(lintRow, CMlngvsfInfoCFSlot, tmp.strSlotPosition)
                    '.SetData(lintRow, CMlngvsfInfoCFCarrier, tmp.strCfCarrierId)
                    .SetData(lintRow, CMlngvsfInfoCFCarrier, tmp.strCurrentCfCarrierId)
                    '.SetData(lintRow, CMlngvsfInfoCFLotId, tmp.strCfLotId)
                    .SetData(lintRow, CMlngvsfInfoCFLotId, tmp.strCurrentCfLotId)
                    .SetData(lintRow, CMlngvsfInfoEmpName, tmp.strEmpName)
                    .SetData(lintRow, CMlngvsfInfoUpdateTime, tmp.strEditTime)

                    'データ行の2行目から
                    If lintRow > CMlngvsfGridTitleRow2 + 1 Then
                        '日時
                        '一つ上の行と比較
                        If .GetData(lintRow, CMlngvsfInfoUpdateTime) = .GetData(lintRow - 1, CMlngvsfInfoUpdateTime) Then
                            'mergeの実施(merge開始Rowと現在Rowでmerge)
                            'merge行を一行単位で更新している
                            .MergedRanges.Add(lintMergeRowS1, CMlngvsfInfoUpdateTime, lintRow, CMlngvsfInfoUpdateTime)
                            .MergedRanges.Add(lintMergeRowS1, CMlngvsfInfoEmpName, lintRow, CMlngvsfInfoEmpName)
                        Else
                            'merge開始Row更新
                            lintMergeRowS1 = lintRow
                        End If

                        'TFTロット
                        '一つ上の行と比較
                        If .GetData(lintRow, CMlngvsfInfoTFTLotId) = .GetData(lintRow - 1, CMlngvsfInfoTFTLotId) Then
                            'mergeの実施(merge開始Rowと現在Rowでmerge)
                            'merge行を一行単位で更新している
                            .MergedRanges.Add(lintMergeRowS2, CMlngvsfInfoTFTLotId, lintRow, CMlngvsfInfoTFTLotId)
                            .MergedRanges.Add(lintMergeRowS2, CMlngvsfInfoTFTCarrier, lintRow, CMlngvsfInfoTFTCarrier)
                        Else
                            'merge開始Row更新
                            lintMergeRowS2 = lintRow
                        End If

                        'CFロット
                        '一つ上の行と比較
                        If .GetData(lintRow, CMlngvsfInfoCFLotId) = .GetData(lintRow - 1, CMlngvsfInfoCFLotId) Then
                            'mergeの実施(merge開始Rowと現在Rowでmerge)
                            'merge行を一行単位で更新している
                            .MergedRanges.Add(lintMergeRowS3, CMlngvsfInfoCFLotId, lintRow, CMlngvsfInfoCFLotId)
                            .MergedRanges.Add(lintMergeRowS3, CMlngvsfInfoCFCarrier, lintRow, CMlngvsfInfoCFCarrier)
                        Else
                            'merge開始Row更新
                            lintMergeRowS3 = lintRow
                        End If
                    End If
                Next

                '自動調整
                .AutoSizeCols(CMlngvsfInfoNo, .Cols.Count - 1, 6)

                .Redraw =  True
                .Enabled = True
                .Row = CMlngvsfGridTitleRow2
                .Refresh

            End With            
                
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsReserveInfo_Disp"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約情報の表示
    ''' </summary>
    ''' <param name="ltypHyoumenReserveInfo"></param>
    Private Sub prvvsHyoumenReserveInfo_Disp(ByRef ltypHyoumenReserveInfo As List(Of typHyoumenReserveInfo))

        Dim lintRow As Integer
        Dim lblnNewRow As Boolean
        Dim lstrReferenceWfId As String = vbNullString
        Dim lstrReferenceRecipeId As String = vbNullString

        Try

            '取得日時
            lblNowDate2.Text = Format$(Now(), CPstrDateFormat)
            
            With vsfHyoumenReserveInfo
                .Redraw =  False
                .Rows.Count = .Rows.Fixed
                .Enabled = False

                For Each tmp As typHyoumenReserveInfo In ltypHyoumenReserveInfo

                    '先頭行の場合は行追加
                    If .Rows.Count - 1 = CMlngvsfGridTitleRow2 Then
                        lblnNewRow = True

                    Else
                        '行追加前の行とLOTが同じ場合は行追加しないで
                        'WF情報を追加する
                        If .GetData(.Rows.Count - 1, CMlngvsfHInfoCurTFTLotId) = tmp.strCurrentLotId And _
                            .GetData(.Rows.Count - 1, CMlngvsfHInfoCurCFLotId) = tmp.strCurrentCfLotId Then

                            lblnNewRow = False
                        Else
                            lblnNewRow = True
                        End If
                    End If

                    '行追加
                    If lblnNewRow = True Then
                        .AddItem(.Rows.Count)       '行追加
                        lintRow = .Rows.Count - 1

                        .SetData(lintRow, CMlngvsfHInfoNo, lintRow - 1)
                        '選択Optionでチェックボックスを表示
                        '予約参照
                        If optAll.Checked = True Then
                            .SetCellCheck(lintRow, CMlngvsfHInfoCheckBox, vbNullString)
                        '予約未/済
                        Else
                            .SetCellCheck(lintRow, CMlngvsfHInfoCheckBox, CheckEnum.Unchecked)  'チェックボックス
                        End If
                        .SetData(lintRow, CMlngvsfHInfoTFTWfId, tmp.strWfId.Substring(7,3))     '#以降を表示
                        .SetData(lintRow, CMlngvsfHInfoCurTFTCarrierId, tmp.strCurrentCarrierId)
                        .SetData(lintRow, CMlngvsfHInfoTFTLotId, tmp.strLotId)
                        .SetData(lintRow, CMlngvsfHInfoCurTFTLotId, tmp.strCurrentLotId)
                        .SetData(lintRow, CMlngvsfHInfoCFWfId, tmp.strCfWfId.Substring(7,3))    '#以降を表示
                        .SetData(lintRow, CMlngvsfHInfoCurCFCarrierId, tmp.strCurrentCFCarrierId)
                        .SetData(lintRow, CMlngvsfHInfoCFLotId, tmp.strCfLotId)
                        .SetData(lintRow, CMlngvsfHInfoCurCFLotId, tmp.strCurrentCfLotId)
                        .SetData(lintRow, CMlngvsfHInfoEditTime, tmp.strEditTime)
                        .SetData(lintRow, CMlngvsfHInfoReserveTime, tmp.strHReserveTime)
                        .SetData(lintRow, CMlngvsfHInfoReserveEmpName, tmp.strHReserveEmpName)
                        .SetData(lintRow, CMlngvsfHInfoRecipeId, tmp.strHRecipeId)
                        .SetData(lintRow, CMlngvsfHInfoTFTWfQty, "1")
                        .SetData(lintRow, CMlngvsfHInfoCfWfQty, "1")
                        .SetData(lintRow, CMlngvsfHInfoTFTWfes, tmp.strWfId)                    'WFIDをカンマ区切りで繋げる
                        .SetData(lintRow, CMlngvsfHInfoCFWfes, tmp.strCfWfId)                   'WFIDをカンマ区切りで繋げる

                        '表面処理のデフォルトレシピが異なる場合
                        'メッセージではWFIDが同じでレシピが異なるメッセージとして送られてくる
                        '表示側でまとめて表示する為、最初のWFIDとレシピを保存
                        lstrReferenceWfId = tmp.strWfId
                        lstrReferenceRecipeId = tmp.strHRecipeId

                    Else
                        lintRow = .Rows.Count - 1
                        '基準WFと異なる場合はWFを追記
                        If lstrReferenceWfId <> tmp.strWfId Then
                            
                            Dim lstrTmpTFTWfId As String
                            Dim lstrTmpCFWfId As String
                            Dim lintTFTWfQty As Integer
                            Dim lintCFWfQty As Integer
                            Dim lstrTmpTFTWfes As String
                            Dim lstrTmpCFWfes As String

                            'WFIDを「,」で追加
                            lstrTmpTFTWfId = .GetData(lintRow, CMlngvsfHInfoTFTWfId)
                            .SetData(lintRow, CMlngvsfHInfoTFTWfId, lstrTmpTFTWfId + "," + tmp.strWfId.Substring(8, 2))  ’#は除く
                            lstrTmpCFWfId = .GetData(lintRow, CMlngvsfHInfoCFWfId)
                            .SetData(lintRow, CMlngvsfHInfoCFWfId, lstrTmpCFWfId + "," + tmp.strCfWfId.Substring(8, 2))  ’#は除く

                            'WF数のCountUp
                            lintTFTWfQty = CInt(.GetData(lintRow, CMlngvsfHInfoTFTWfQty)) + 1
                            lintCFWfQty = CInt(.GetData(lintRow, CMlngvsfHInfoCfWfQty)) + 1

                            .SetData(lintRow, CMlngvsfHInfoTFTWfQty, lintTFTWfQty)
                            .SetData(lintRow, CMlngvsfHInfoCfWfQty, lintCFWfQty)

                            'WFIDをカンマ区切りで繋げる
                            lstrTmpTFTWfes = .GetData(lintRow, CMlngvsfHInfoTFTWfes)
                            .SetData(lintRow, CMlngvsfHInfoTFTWfes, lstrTmpTFTWfes + "," + tmp.strWfId)                            
                            lstrTmpCFWfes = .GetData(lintRow, CMlngvsfHInfoCFWfes)
                            .SetData(lintRow, CMlngvsfHInfoCFWfes, lstrTmpCFWfes + "," + tmp.strCfWfId)

                        End If

                        '基準レシピと異なる場合はレシピを追記
                        If lstrReferenceRecipeId <> tmp.strHRecipeId Then
                            .SetData(lintRow, CMlngvsfHInfoRecipeId, lstrReferenceRecipeId + "/" + tmp.strHRecipeId)
                        End If

                        '基準更新
                        lstrReferenceWfId = tmp.strWfId
                        lstrReferenceRecipeId = tmp.strHRecipeId

                    End If
                Next

                '予約済のWF合計数を算出
                For lintRow = CMlngvsfGridTitleRow2 + 1 To .Rows.Count - 1
                    '予約済判定は日時で実施
                    If .GetData(lintRow, CMlngvsfHInfoReserveTime) <> vbNullString Then
                        Dim lintTotalWfQty As Integer = 0
                        For Each tmp As typHyoumenReserveInfo In ltypHyoumenReserveInfo
                            If tmp.strHReserveTime = .GetData(lintRow, CMlngvsfHInfoReserveTime) Then
                                lintTotalWfQty = lintTotalWfQty + 2 '1レコードTFT/CFなので2枚
                            End If
                        Next
                        .SetData(lintRow, CMlngvsfHInfoTotalWfQty, lintTotalWfQty)
                    End If
                Next

                '予約済の場合はマージを実施
                Dim lintMergeRowS As Integer = CMlngvsfGridTitleRow2 + 1
                For lintRow = CMlngvsfGridTitleRow2 + 1 To .Rows.Count - 1
                    '予約済判定は日時で実施
                    If .GetData(lintRow, CMlngvsfHInfoReserveTime) <> vbNullString Then
                        'データ1行目
                        If lintRow = CMlngvsfGridTitleRow2 + 1 Then
                            lintMergeRowS = lintRow
                        ElseIf lintRow > CMlngvsfGridTitleRow2 + 1 Then
                            '一つ上の行の予約日時と比較
                            If .GetData(lintRow, CMlngvsfHInfoReserveTime) = .GetData(lintRow - 1, CMlngvsfHInfoReserveTime) Then
                                'mergeの実施(merge開始Rowと現在Rowでmerge)
                                'merge行を一行単位で更新している
                                .MergedRanges.Add(lintMergeRowS, CMlngvsfHInfoCheckBox, lintRow, CMlngvsfHInfoCheckBox)
                                .MergedRanges.Add(lintMergeRowS, CMlngvsfHInfoReserveTime, lintRow, CMlngvsfHInfoReserveTime)
                                .MergedRanges.Add(lintMergeRowS, CMlngvsfHInfoTotalWfQty, lintRow, CMlngvsfHInfoTotalWfQty)
                                .MergedRanges.Add(lintMergeRowS, CMlngvsfHInfoRecipeId, lintRow, CMlngvsfHInfoRecipeId)
                                .MergedRanges.Add(lintMergeRowS, CMlngvsfHInfoReserveEmpName, lintRow, CMlngvsfHInfoReserveEmpName)
                            Else
                                'merge開始Row更新
                                lintMergeRowS = lintRow
                            End If
                        End If

                        '予約済みの場合は背景色変更
                        Dim newStyle_BackColor_CPlngGridDarkGray As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                        newStyle_BackColor_CPlngGridDarkGray.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngGridDarkGray))
                        Dim cellRange As CellRange = .GetCellRange(lintRow, CMlngvsfHInfoNo, lintRow, .Cols.Count - 1)
                        cellRange.Style = newStyle_BackColor_CPlngGridDarkGray
                    End If
                Next

                '自動調整
                .AutoSizeCols(CMlngvsfHInfoNo, .Cols.Count - 1, 6)

                .Redraw =  True
                .Enabled = True
                .Refresh
                .Row = CMlngvsfGridTitleRow2

            End With            
                
            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsReserveInfo_Disp"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 表面処理予約画面のボタン有効無効チェック
    ''' 予約登録では選択WF枚数のチェック、レシピのチェックもしている
    ''' 予約解除では予約時間の有無をチェックしている
    ''' </summary>
    Private Sub prvHyoumenReserveButtonCheck()

        Dim lintRow As Integer

        Try
            'ボタン初期化
            cmdHyoumenRegist.Enabled = False
            cmdHyoumenDel.Enabled = False

            '全ての場合は参照のみ
            'ボタンは全て無効
            If optAll.Checked = True Then
                Exit Sub
            End If

            With vsfHyoumenReserveInfo
                '********************
                '予約未(予約操作の場合)
                '********************
                If optNone.Checked = True Then
     
                    '選択WF数計算            
                    Dim lintWfCnt As Integer = 0
                    Dim lstrRecipeId As String = vbNullString
                    Dim lblnRecipeCheck As Boolean = True
                    For lintRow = 1 To .Rows.Count - 1
                        If .GetCellCheck(lintRow, CMlngvsfHInfoCheckBox) = CheckEnum.Checked Then
                            'WF数
                            lintWfCnt = lintWfCnt + CInt(.GetData(lintRow, CMlngvsfHInfoTFTWfQty)) + CInt(.GetData(lintRow, CMlngvsfHInfoCfWfQty))
                            '基準レシピ取得
                            If lstrRecipeId = vbNullString Then
                                lstrRecipeId = .GetData(lintRow, CMlngvsfHInfoRecipeId)
                            Else
                                '基準レシピと比較
                                If lstrRecipeId <> .GetData(lintRow, CMlngvsfHInfoRecipeId) Then
                                    lblnRecipeCheck = False
                                End If
                            End If

                        End If
                    Next
                    
                    '選択WF数表示(0以下はNULLで表示)
                    If lintWfCnt <= 0 Then
                        lblSelectWfCnt.Text = vbNullString
                    Else
                        lblSelectWfCnt.Text = lintWfCnt
                    End If

                    '表面処理予約制限(62枚)
                    'レシピが同一(lblnRecipeChaeck=True)
                    '予約可
                    If lintWfCnt >= 1 And lintWfCnt <= CMlngHyoumenMaxCnt And lblnRecipeCheck = True Then
                        cmdHyoumenRegist.Enabled = True
                    End If

                '********************
                '予約済(予約解除の場合)
                '********************
                ElseIf optDone.Checked = True Then
                    Dim lblnHyoumenTimeCheck As Boolean = False
                    For lintRow = 1 To .Rows.Count - 1
                        If .GetCellCheck(lintRow, CMlngvsfHInfoCheckBox) = CheckEnum.Checked Then
                            If .GetData(lintRow, CMlngvsfHInfoReserveTime) = vbNullString Then
                                lblnHyoumenTimeCheck = False
                                Exit For
                            Else
                                lblnHyoumenTimeCheck = True
                            End If
                        End If
                    Next

                    '全てのチェック項目に表面処理の予約時間があること
                    If lblnHyoumenTimeCheck = True Then
                        cmdHyoumenDel.Enabled = True
                    End If

                End If
            End With

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvReserveButtonCheck"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' カンマ区切りのWFIDの文字列をWFIDリストに展開する
    ''' 例：(ABCD001#12,ABCD001#13,ABCD001#14,ABCD001#15,ABCD001#16)　→　文字リストに入れる(ABCD001#12/ABCD001#13/ABCD001#14/ABCD001#15/ABCD001#16)
    ''' ロット内に異なるWFIDが混在しても対応可能のバージョン
    ''' </summary>
    ''' <param name="lstrAllWf"></param>
    ''' <param name="lstrWfList"></param>
    Private Sub prvMakeWfIdList(ByVal lstrAllWf As String, ByRef lstrWfList As List(Of String))

        Try            
            'カンマ区切りでつながった文字なので分解する
            'NULLで終わり
            While lstrAllWf <> vbNullString
                '文字列をカンマで検索
                Dim lintTargetIndex As Integer = lstrAllWf.IndexOf(",")

                '検索結果なし
                If lintTargetIndex < 0 Then
                    'List追加
                    lstrWfList.Add(lstrAllWf)
                    Exit While

                '検索結果あり
                Else
                    'WF/SLOTを抜き出す
                    Dim lstrWf As String = lstrAllWf.Substring(0,lintTargetIndex)
                        
                    'List追加
                    lstrWfList.Add(lstrWf)

                    '文字列の更新
                    lstrAllWf = lstrAllWf.Substring(lintTargetIndex + 1)
                        
                End If
            End While

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMakeWfIdList"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Sub

	'関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱ変更時処理(1)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 18:32:45 K.Takano
    '更新日：2004/04/14 (Wed) 18:32:45
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@画面初期化
            Call prvTab3_Init()
            
            '@変更ﾌﾗｸﾞｾｯﾄ
            mblnTxtCarrierChange = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
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

                    Case SC_MOVE
                        'フォームの移動を無効化する
                        m.Result = IntPtr.Zero
                        Return
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

End Class
