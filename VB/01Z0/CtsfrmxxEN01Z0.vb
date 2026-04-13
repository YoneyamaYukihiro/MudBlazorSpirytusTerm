'ﾌｧｲﾙ名：xxEN01Z0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置メンテナンス記録票一覧(旧:故障修理記録一覧)　メインフォーム
'作成日：2007/01/15 (Mon) 11:40:49 N.Kojima
'更新日：2008/08/18 (Mon) 11:46:12 M.Koni
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01Z0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01Z0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01Z0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01Z0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01Z0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                     As String = "03.01"

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01Z0          'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_McGrouplistVer               As String = "01.00"                 '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstrmas_mentecategorylistVer         As String = "01.00"                 'ｶﾃｺﾞﾘ取得
    Private Const CMstreq__areacurlistVer               As String = "02.00"                 'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得
    Private Const CMstreq__schwpmentechgVer             As String = "03.00"                 '装置停止ﾒﾝﾃ計画登録・更新
    Private Const CMstreq__schwpmentelistVer            As String = "05.00"                 '装置停止ﾒﾝﾃ計画ﾘｽﾄ取得
    Private Const CMstrpre_preservelistVer              As String = "01.00"                 '保全記録票一覧取得
    Private Const CMstrpre_chgpreservereportVer         As String = "01.00"                 '保全記録票登録/更新
    Private Const CMstrrep_repairlistVer                As String = "01.01"                 '故障修理記録票一覧取得
    Private Const CMstrrep_chgrepairreportVer           As String = "03.00"                 '故障修理記録票登録/更新
    Private Const CMstrrep_registworkflowVer            As String = "01.00"                 '確認依頼登録

    '@装置停止・ﾒﾝﾃ計画選択時のｸﾞﾘｯﾄﾞ設定用===================================================================================
    '@装置停止・ﾒﾝﾃ計画選択時の列数
    Private Const CMlngvsfMainteCols                    As Integer = 16                        '列数

    '@vsfMainteListの列順
    Private Const CMlngvsfMntColNo                      As Integer = 0                         '№
    Private Const CMlngvsfMntColWPID                    As Integer = 1                         '装置ID(非表示)
    Private Const CMlngvsfMntColWPName                  As Integer = 2                         '装置名
    Private Const CMlngvsfMntColCategoryID              As Integer = 3                         'ｶﾃｺﾞﾘID(非表示)
    Private Const CMlngvsfMntColCategoryName            As Integer = 4                         'ｶﾃｺﾞﾘ名(和名)
    Private Const CMlngvsfMntColStartDate               As Integer = 5                         '開始予定日時
    Private Const CMlngvsfMntColEndDate                 As Integer = 6                         '終了予定日時
    Private Const CMlngvsfMntColDuration                As Integer = 7                         '停止時間
    Private Const CMlngvsfMntColComments                As Integer = 8                         '停止ｺﾒﾝﾄ(一部)
    Private Const CMlngvsfMntColCommentsAll             As Integer = 9                         '停止ｺﾒﾝﾄ(非表示)
    Private Const CMlngvsfMntColStopRule                As Integer = 10                        '停止方法
    Private Const CMlngvsfMntColEmpName                 As Integer = 11                        '最終更新者
    Private Const CMlngvsfMntColEditTime                As Integer = 12                        '最終更新日時
    Private Const CMlngvsfMntColEditTimeV               As Integer = 13                        '最終更新日時(非表示)
    Private Const CMlngvsfMntColEntryTime               As Integer = 14                        '登録日時(非表示)
    Private Const CMlngvsfMntColStartDateMilli          As Integer = 15                        '開始予定日時(秒迄)

    '@vsfMainteListの列幅
    Private Const CMlngvsfMntColWNo                     As Integer = 33                        '№
    Private Const CMlngvsfMntColWWPID                   As Integer = 104                       '装置ID(非表示)
    Private Const CMlngvsfMntColWWPName                 As Integer = 247                       '装置名
    Private Const CMlngvsfMntColWCategoryID             As Integer = 72                        'ｶﾃｺﾞﾘID(非表示)
    Private Const CMlngvsfMntColWCategoryName           As Integer = 167                       'ｶﾃｺﾞﾘ名(和名)
    Private Const CMlngvsfMntColWStartDate              As Integer = 135                       '開始予定日時
    Private Const CMlngvsfMntColWEndDate                As Integer = 135                       '終了予定日時
    Private Const CMlngvsfMntColWDuration               As Integer = 84                        '停止時間
    Private Const CMlngvsfMntColWComments               As Integer = 248                       '停止ｺﾒﾝﾄ(一部)
    Private Const CMlngvsfMntColWCommentsAll            As Integer = 400                       '停止ｺﾒﾝﾄ(非表示)
    Private Const CMlngvsfMntColWStopRule               As Integer = 76                        '停止方法
    Private Const CMlngvsfMntColWEmpName                As Integer = 88                        '最終更新者
    Private Const CMlngvsfMntColWEditTime               As Integer = 135                       '最終更新日時(非表示)
    Private Const CMlngvsfMntColWEditTimeV              As Integer = 200                       '最終更新日時(非表示)
    Private Const CMlngvsfMntColWEntryTime              As Integer = 72                        '登録日時(非表示)
    Private Const CMlngvsfMntColWStartDateMilli         As Integer = 0                         '開始予定日時(秒迄)

    '@vsfMainteListの列名
    Private Const CMstrvsfMntColTNo                     As String = "№"                    '№
    Private Const CMstrvsfMntColTWPID                   As String = "装置ID"                '装置ID(非表示)
    Private Const CMstrvsfMntColTWPName                 As String = "装置名"                '装置名
    Private Const CMstrvsfMntColTCategoryID             As String = "カテゴリID"            'ｶﾃｺﾞﾘID(非表示)
    Private Const CMstrvsfMntColTCategoryName           As String = "カテゴリ"              'ｶﾃｺﾞﾘ名(和名)
    Private Const CMstrvsfMntColTStartDate              As String = "開始(予定)日時"        '開始予定日時
    Private Const CMstrvsfMntColTEndDate                As String = "終了(予定)日時"        '終了予定日時
    Private Const CMstrvsfMntColTDuration               As String = "停止時間"              '停止時間
    Private Const CMstrvsfMntColTCommentsD              As String = "停止コメント(一部)"    '停止ｺﾒﾝﾄ(一部)
    Private Const CMstrvsfMntColTCommentsV              As String = "停止ｺﾒﾝﾄ(非表示)"      '停止ｺﾒﾝﾄ(非表示)
    Private Const CMstrvsfMntColTStopRule               As String = "停止方法"              '停止方法
    Private Const CMstrvsfMntColTEmpName                As String = "最終更新者"            '最終更新者
    Private Const CMstrvsfMntColTEditTimeD              As String = "最終更新日時"          '最終更新日時
    Private Const CMstrvsfMntColTEditTimeV              As String = "最終更新日時(非表示)"  '最終更新日時(非表示)
    Private Const CMstrvsfMntColTEntryTime              As String = "登録日時(非表示)"      '登録日時(非表示)
    Private Const CMstrvsfMntColTStartDateMilli         As String = "開始(予定)日時(秒)"    '開始予定日時(秒迄)
    '@=============================================================================================================

    '@故障修理記録選択時のｸﾞﾘｯﾄﾞ設定用===================================================================================
    '@故障修理記録選択時の列数
    Private Const CMlngvsfRepairCols                    As Integer = 22                        '列数

    '@vsfMainteListの列順
    Private Const CMlngvsfRepColNo                      As Integer = 0                         '№
    Private Const CMlngvsfRepColRepairStatusID          As Integer = 1                         '状態ID(非表示:0,1,2,3)
    Private Const CMlngvsfRepColRepairStatus            As Integer = 2                         '状態名(未,処,済)
    Private Const CMlngvsfRepColRepairNo                As Integer = 3                         '発行№
    Private Const CMlngvsfRepColWPID                    As Integer = 4                         '装置ID(非表示)
    Private Const CMlngvsfRepColWPName                  As Integer = 5                         '装置名
    Private Const CMlngvsfRepColRepairName              As Integer = 6                         '故障現象名(一部)
    Private Const CMlngvsfRepColRepairStartDate         As Integer = 7                         '故障発生日時
    Private Const CMlngvsfRepColRepairEndDate           As Integer = 8                         '修理完了日時
    Private Const CMlngvsfRepColStopTime                As Integer = 9                         '停止時間
    Private Const CMlngvsfRepColToEmpName               As Integer = 10                        '依頼先担当者名
    Private Const CMlngvsfRepColFindEmpName             As Integer = 11                        '起案者名
    Private Const CMlngvsfRepColPreserverEmpName        As Integer = 12                        '保全実施者名
    Private Const CMlngvsfRepColEditTime                As Integer = 13                        '更新日時(非表示)
    Private Const CMlngvsfRepColRepairContents          As Integer = 14                        '故障現象詳細(非表示)
    Private Const CMlngvsfRepColRepairAnalysisContents  As Integer = 15                        '調査/分析詳細(非表示)
    Private Const CMlngvsfRepColRepairCauseContents     As Integer = 16                        '原因詳細(非表示)
    Private Const CMlngvsfRepColRepairMeasureContents   As Integer = 17                        '対策詳細(非表示)
    Private Const CMlngvsfRepColAllRepairName           As Integer = 18                        '故障現象名(全文)(非表示)
    Private Const CMlngvsfRepColCopeDivision            As Integer = 19                        '対応区分
    Private Const CMlngvsfRepColWorkCost                As Integer = 20                        '作業費用
    Private Const CMlngvsfRepColPartCost                As Integer = 21                        '部品費用

    '@vsfMainteListの列幅
    Private Const CMlngvsfRepColWNo                     As Integer = 36                        '№
    Private Const CMlngvsfRepColWRepairStatusID         As Integer = 0                         '状態ID
    Private Const CMlngvsfRepColWRepairStatus           As Integer = 32                        '状態名
    Private Const CMlngvsfRepColWRepairNo               As Integer = 76                        '発行№
    Private Const CMlngvsfRepColWWPID                   As Integer = 0                         '装置ID
    Private Const CMlngvsfRepColWWPName                 As Integer = 216                       '装置名
    Private Const CMlngvsfRepColWRepairName             As Integer = 127                       '故障現象名(一部)
    Private Const CMlngvsfRepColWRepairStartDate        As Integer = 140                       '故障発生日時
    Private Const CMlngvsfRepColWRepairEndDate          As Integer = 140                       '修理完了日時
    Private Const CMlngvsfRepColWStopTime               As Integer = 76                        '停止時間
    Private Const CMlngvsfRepColWToEmpName              As Integer = 100                       '依頼先担当者名
    Private Const CMlngvsfRepColWFindEmpName            As Integer = 100                       '起案者名
    Private Const CMlngvsfRepColWPreserverEmpName       As Integer = 100                       '保全実施者名
    Private Const CMlngvsfRepColWEditTime               As Integer = 0                         '更新日時
    Private Const CMlngvsfRepColWRepairContents         As Integer = 0                         '故障現象詳細
    Private Const CMlngvsfRepColWRepairAnalysisContents As Integer = 0                         '調査/分析詳細
    Private Const CMlngvsfRepColWRepairCauseContents    As Integer = 0                         '原因詳細
    Private Const CMlngvsfRepColWRepairMeasureContents  As Integer = 0                         '対策詳細
    Private Const CMlngvsfRepColWAllRepairName          As Integer = 0                         '故障現象名(全文)
    Private Const CMlngvsfRepColWCopeDivision           As Integer = 0                         '対応区分
    Private Const CMlngvsfRepColWWorkCost               As Integer = 0                         '作業費用
    Private Const CMlngvsfRepColWPartCost               As Integer = 0                         '部品費用

    '@vsfMainteListの列名
    Private Const CMstrvsfRepColTNo                     As String = "№"                    '№
    Private Const CMstrvsfRepColTRepairStatusID         As String = "状態ID"                '状態ID
    Private Const CMstrvsfRepColTRepairStatus           As String = ""                      '状態名
    Private Const CMstrvsfRepColTRepairNo               As String = "発行№"                '発行№
    Private Const CMstrvsfRepColTWPID                   As String = "装置ID"                '装置ID
    Private Const CMstrvsfRepColTWPName                 As String = "装置名"                '装置名
    Private Const CMstrvsfRepColTRepairName             As String = "故障現象名(一部)"      '故障現象名
    Private Const CMstrvsfRepColTRepairStartDate        As String = "故障発生日時"          '故障発生日時
    Private Const CMstrvsfRepColTRepairEndDate          As String = "修理完了日時"          '修理完了日時
    Private Const CMstrvsfRepColTStopTime               As String = "停止時間"              '停止時間
    Private Const CMstrvsfRepColTToEmpName              As String = "担当者"                '依頼先担当者名
    Private Const CMstrvsfRepColTFindEmpName            As String = "起案者"                '起案者名
    Private Const CMstrvsfRepColTPreserverEmpName       As String = "保全実施者"            '保全実施者名
    Private Const CMstrvsfRepColTEditTime               As String = "更新日時"              '更新日時
    Private Const CMstrvsfRepColTRepairContents         As String = "故障現象詳細"          '故障現象詳細
    Private Const CMstrvsfRepColTRepairAnalysisContents As String = "調査/分析詳細"        '調査/分析詳細
    Private Const CMstrvsfRepColTRepairCauseContents    As String = "原因詳細"              '原因詳細
    Private Const CMstrvsfRepColTRepairMeasureContents  As String = "対策詳細"              '対策詳細
    Private Const CMstrvsfRepColTAllRepairName          As String = "故障現象名(全文)"      '故障現象名(全文)
    Private Const CMstrvsfRepColTCopeDivision           As String = "対応区分"              '対応区分
    Private Const CMstrvsfRepColTWorkCost               As String = "作業費用"              '作業費用
    Private Const CMstrvsfRepColTPartCost               As String = "部品費用"              '部品費用
    '@=============================================================================================================

    '@保全記録選択時のｸﾞﾘｯﾄﾞ設定用===================================================================================
    '@保全記録選択時の列数
    Private Const CMlngvsfPreserveCols                  As Integer = 27                        '列数

    '@vsfMainteListの列順
    Private Const CMlngvsfPreColNo                      As Integer = 0                         '№
    Private Const CMlngvsfPreColPreserveStatusID        As Integer = 1                         '状態ID(非表示:0,1,2,3)
    Private Const CMlngvsfPreColPreserveStatusName      As Integer = 2                         '状態名(未,処,済)
    Private Const CMlngvsfPreColPreserveNo              As Integer = 3                         '発行№
    Private Const CMlngvsfPreColWpID                    As Integer = 4                         '装置ID(非表示)
    Private Const CMlngvsfPreColWpName                  As Integer = 5                         '装置名
    Private Const CMlngvsfPreColCategoryID              As Integer = 6                         'ｶﾃｺﾞﾘID(非表示)
    Private Const CMlngvsfPreColCategoryName            As Integer = 7                         'ｶﾃｺﾞﾘ名(非表示)
    Private Const CMlngvsfPreColPreserveCategoryID      As Integer = 8                         '保全ｶﾃｺﾞﾘID(非表示:1=予防保全,2=改良改善保全,3=ﾙｰﾁﾝﾒﾝﾃ)
    Private Const CMlngvsfPreColPreserveCategoryName    As Integer = 9                         '保全ｶﾃｺﾞﾘ名(和名)
    Private Const CMlngvsfPreColPreserveItem            As Integer = 10                        '実施項目(一部)(30byteまで)
    Private Const CMlngvsfPreColPreserveItemAll         As Integer = 11                        '実施項目(非表示:全文)
    Private Const CMlngvsfPreColStartDate               As Integer = 12                        '開始(予定)日時
    Private Const CMlngvsfPreColEndDate                 As Integer = 13                        '終了(予定)日時
    Private Const CMlngvsfPreColStopTime                As Integer = 14                        '停止時間
    Private Const CMlngvsfPreColToEmpName               As Integer = 15                        '依頼先担当者名
    Private Const CMlngvsfPreColPreserverEmpName        As Integer = 16                        '保全実施者名
    Private Const CMlngvsfPreColEmpName                 As Integer = 17                        '更新者
    Private Const CMlngvsfPreColEditTime                As Integer = 18                        '更新日時
    Private Const CMlngvsfPreColPreserveContents        As Integer = 19                        '実施内容(非表示)
    Private Const CMlngvsfPreColPreservePurpose         As Integer = 20                        '実施理由/目的(非表示)
    Private Const CMlngvsfPreColPreserveSignEmpID       As Integer = 21                        '保全担当ｻｲﾝID(非表示)
    Private Const CMlngvsfPreColPreserveLeaderSignEmpID As Integer = 22                        '保全ﾘｰﾀﾞｰｻｲﾝID(非表示)
    Private Const CMlngvsfPreColProductLeaderSignEmpID  As Integer = 23                        '作業長ｻｲﾝID(非表示)
    Private Const CMlngvsfPreColCopeDivision            As Integer = 24                        '対応区分
    Private Const CMlngvsfPreColWorkCost                As Integer = 25                        '作業費用
    Private Const CMlngvsfPreColPartCost                As Integer = 26                        '部品費用

    '@vsfMainteListの列幅
    Private Const CMlngvsfPreColWNo                     As Integer = 36                        '№
    Private Const CMlngvsfPreColWPreserveStatusID       As Integer = 0                         '状態ID(非表示:0,1,2,3)
    Private Const CMlngvsfPreColWPreserveStatusName     As Integer = 32                        '状態名(未,処,済)
    Private Const CMlngvsfPreColWPreserveNo             As Integer = 76                        '発行№
    Private Const CMlngvsfPreColWWpID                   As Integer = 0                         '装置ID(非表示)
    Private Const CMlngvsfPreColWWpName                 As Integer = 216                       '装置名
    Private Const CMlngvsfPreColWCategoryID             As Integer = 0                         'ｶﾃｺﾞﾘID(非表示)
    Private Const CMlngvsfPreColWCategoryName           As Integer = 0                         'ｶﾃｺﾞﾘ名(非表示)
    Private Const CMlngvsfPreColWPreserveCategoryID     As Integer = 0                         '保全ｶﾃｺﾞﾘID(非表示:1=予防保全,2=改良改善保全,3=ﾙｰﾁﾝﾒﾝﾃ)
    Private Const CMlngvsfPreColWPreserveCategoryName   As Integer = 167                       '保全ｶﾃｺﾞﾘ名(和名)
    Private Const CMlngvsfPreColWPreserveItem           As Integer = 127                       '実施項目(一部)(30byteまで)
    Private Const CMlngvsfPreColWPreserveItemAll        As Integer = 0                         '実施項目(非表示:全文)
    Private Const CMlngvsfPreColWStartDate              As Integer = 140                       '開始(予定)日時
    Private Const CMlngvsfPreColWEndDate                As Integer = 140                       '終了(予定)日時
    Private Const CMlngvsfPreColWStopTime               As Integer = 76                        '停止時間
    Private Const CMlngvsfPreColWToEmpName              As Integer = 100                       '依頼先担当者名
    Private Const CMlngvsfPreColWPreserverEmpName       As Integer = 100                       '保全実施者名
    Private Const CMlngvsfPreColWEmpName                As Integer = 100                       '更新者
    Private Const CMlngvsfPreColWEditTime               As Integer = 0                         '更新日時
    Private Const CMlngvsfPreColWPreserveContents       As Integer = 0                         '実施内容(非表示)
    Private Const CMlngvsfPreColWPreservePurpose        As Integer = 0                         '実施理由/目的(非表示)
    Private Const CMlngvsfPreColWPreserveSignEmpID      As Integer = 0                         '保全担当ｻｲﾝID(非表示)
    Private Const CMlngvsfPreColWPreserveLeaderSignEmpID As Integer = 0                        '保全ﾘｰﾀﾞｰｻｲﾝID(非表示)
    Private Const CMlngvsfPreColWProductLeaderSignEmpID As Integer = 0                         '作業長ｻｲﾝID(非表示)
    Private Const CMlngvsfPreColWCopeDivision           As Integer = 0                         '対応区分
    Private Const CMlngvsfPreColWWorkCost               As Integer = 0                         '作業費用
    Private Const CMlngvsfPreColWPartCost               As Integer = 0                         '部品費用

    '@vsfMainteListの列名
    Private Const CMstrvsfPreColTNo                     As String = "№"                    '№
    Private Const CMstrvsfPreColTPreserveStatusID       As String = "状態ID"                '状態ID(非表示:0,1,2,3)
    Private Const CMstrvsfPreColTPreserveStatusName     As String = ""                      '状態名(未,処,済)
    Private Const CMstrvsfPreColTPreserveNo             As String = "発行№"                '発行№
    Private Const CMstrvsfPreColTWpID                   As String = "装置ID"                '装置ID(非表示)
    Private Const CMstrvsfPreColTWpName                 As String = "装置名"                '装置名
    Private Const CMstrvsfPreColTCategoryID             As String = "カテゴリID"            'ｶﾃｺﾞﾘID(非表示)
    Private Const CMstrvsfPreColTCategoryName           As String = "カテゴリ"              'ｶﾃｺﾞﾘ名(非表示)
    Private Const CMstrvsfPreColTPreserveCategoryID     As String = "保全カテゴリID"        '保全ｶﾃｺﾞﾘID(非表示:1=予防保全,2=改良改善保全,3=ﾙｰﾁﾝﾒﾝﾃ)
    Private Const CMstrvsfPreColTPreserveCategoryName   As String = "保全カテゴリ"          '保全ｶﾃｺﾞﾘ名(和名)
    Private Const CMstrvsfPreColTPreserveItem           As String = "実施項目(一部)"        '実施項目(一部)(30byteまで)
    Private Const CMstrvsfPreColTPreserveItemAll        As String = "実施項目(全文)"        '実施項目(非表示:全文)
    Private Const CMstrvsfPreColTStartDate              As String = "開始(予定)日時"        '開始(予定)日時
    Private Const CMstrvsfPreColTEndDate                As String = "終了(予定)日時"        '終了(予定)日時
    Private Const CMstrvsfPreColTStopTime               As String = "停止時間"              '停止時間
    Private Const CMstrvsfPreColTToEmpName              As String = "担当者"                '依頼先担当者名
    Private Const CMstrvsfPreColTPreserverEmpName       As String = "保全実施者"            '保全実施者名
    Private Const CMstrvsfPreColTEmpName                As String = "作業者"                '更新者
    Private Const CMstrvsfPreColTEditTime               As String = "最終更新日時"          '更新日時
    Private Const CMstrvsfPreColTPreserveContents       As String = "実施内容"              '実施内容(非表示)
    Private Const CMstrvsfPreColTPreservePurpose        As String = "実施理由/目的"         '実施理由/目的(非表示)
    Private Const CMstrvsfPreColTPreserveSignEmpID      As String = "保全担当サインID"      '保全担当ｻｲﾝID(非表示)
    Private Const CMstrvsfPreColTPreserveLeaderSignEmpID As String = "保全リーダーサインID" '保全ﾘｰﾀﾞｰｻｲﾝID(非表示)
    Private Const CMstrvsfPreColTProductLeaderSignEmpID As String = "作業長サインID"        '作業長ｻｲﾝID(非表示)
    Private Const CMstrvsfPreColTCopeDivision           As String = "対応区分"              '対応区分
    Private Const CMstrvsfPreColTWorkCost               As String = "作業費用"              '作業費用
    Private Const CMstrvsfPreColTPartCost               As String = "部品費用"              '部品費用
    '@=============================================================================================================

    '@ｸﾞﾘｯﾄﾞ用共通定数
    Private Const CMlngVsfRowTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                     As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFontSize                      As Integer = 11                     'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                        As Integer = 17                     '1ｽﾛｯﾄの高さ計算用

    '@ｺﾝﾎﾞﾎﾞｯｸｽ用共通定数
    Private Const CMlngCmbFontSize                      As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight                     As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                      'ｺﾝﾎﾞ内列数(=0)
    Private Const CMlngCmbDispCols1                     As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol1                     As Integer = 1                      '値取得個数=1
    Private Const CMlngCmbCheck0                        As Integer = 0                      '装置ﾁｪｯｸ数(ﾃﾞﾌｫﾙﾄ)
    Private Const CMlngCmbCheck1                        As Integer = 1                      'ｶﾃｺﾞﾘﾁｪｯｸ数(ﾃﾞﾌｫﾙﾄ)
    Private Const CMlngCmbGroupCols                     As Integer = 1                      '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMstrCmbCheckOn                       As String = "1"                     'ﾁｪｯｸON
    Private Const CMstrCmbCheckOff                      As String = "0"                     'ﾁｪｯｸOFF
    Private Const CMstrCmbSelect                        As String = " 項目選択"             '表示 文字列
    Private Const CMstrCmbNoSelectString                As String = "指定なし"              '装置ｸﾞﾙｰﾌﾟ、装置名指定なし文字
    Private Const CMstrMaintenancePlan                  As String = "メンテ計画"            'ｶﾃｺﾞﾘｺﾝﾎﾞ用

    '@各種文字列
    Private Const CMstrApplyFlag                        As String = "済"                    '承認済
    Private Const CMstrDisposalFlag                     As String = "処"                    '処置済
    Private Const CMstrNoDisposalFlag                   As String = "未"                    '未処置
    Private Const CMstrStartTime                        As String = " 00:00:00"             '故障修理、保全記録用(00:00:00)
    Private Const CMstrEndTime                          As String = " 23:59:59"             '故障修理、保全記録用(23:59:59)
    Private Const CMstrMntStartTime                     As String = "00:00"                 '装置停止・ﾒﾝﾃ計画用(00:00)
    Private Const CMstrMntEndTime                       As String = "23:59"                 '装置停止・ﾒﾝﾃ計画用(23:59:59)
    Private Const CMstrSinnkitouroku                    As String = "新規登録"              'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(新規作成⇔登録)
    Private Const CMstrHennsyuu                         As String = "編　集"                'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(編集⇔登録)
    Private Const CMstrHaki                             As String = "破　棄"                'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(破棄⇔削除)
    Private Const CMstrTouroku                          As String = "登　録"                'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(新規作成⇔登録)
    Private Const CMstrSyuusei                          As String = "修　正"                'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(編集⇔登録)
    Private Const CMstrSakujyo                          As String = "削　除"                'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(破棄⇔削除)
    Private Const CMstrMntInformationTitle              As String = "停止コメント"          '共通ﾃｷｽﾄのﾀｲﾄﾙ(装置停止・ﾒﾝﾃ計画用)
    Private Const CMstrCopeDivision1                    As String = "自主保全"              '対応区分表示用(故障修理記録、保全記録用)
    Private Const CMstrCopeDivision2                    As String = "メーカー保全"          '対応区分表示用(故障修理記録、保全記録用)
    Private Const CMstrPreserveCategoryName1            As String = "予防保全"              '保全ｶﾃｺﾞﾘ表示用(保全記録用)
    Private Const CMstrPreserveCategoryName2            As String = "改良/改善保全"         '保全ｶﾃｺﾞﾘ表示用(保全記録用)
    Private Const CMstrPreserveCategoryName3            As String = "ルーチンメンテ"        '保全ｶﾃｺﾞﾘ表示用(保全記録用)
    Private Const CMstrPreserveItemTitle                As String = "実施項目"              '共通ﾃｷｽﾄﾀｲﾄﾙ用(保全記録用)
    Private Const CMstrRepairNameTitle                  As String = "故障現象名"            '共通ﾃｷｽﾄﾀｲﾄﾙ用(故障修理記録用)

    '@各種ﾎﾞﾀﾝ押下時の引継ぎ用定数
    Private Const CMlngInsertMode                       As Integer = 1                      '新規
    Private Const CMlngCopyInsertMode                   As Integer = 2                      'ｺﾋﾟｰ登録
    Private Const CMlngUpdateMode                       As Integer = 3                      '計画ﾃﾞｰﾀ修正
    Private Const CMlngResultUpdateMode                 As Integer = 5                      '実績ﾃﾞｰﾀ修正

    '@停止方法
    Private Const CMstrStopRule1                        As String = "強制"                  '1:強制
    Private Const CMstrStopRule3                        As String = "ﾛｯﾄ優先"               '3:ﾛｯﾄ優先
    Private Const CMlngStopRule1                        As Integer = 1                      '1:強制
    Private Const CMlngStopRule3                        As Integer = 3                      '3:ﾛｯﾄ優先

    '@停止時間算出用
    Private Const CMstrDatediffMinute                   As String = "n"                     '間隔(分)
    Private Const CMlngMinute60                         As Decimal = 60                     '60分(1時間)
    Private Const CMlng100                              As Decimal = 100                    '100倍用
    Private Const CMstrM                                As String = "M"                     '3ヶ月後計算用

    '@表示ﾒｯｾｰｼﾞ用
    Private Const CMstrApplyMsg                         As String = "承認"                  '承認成功MSG
    Private Const CMstrDisconMsg                        As String = "破棄"                  '破棄成功MSG
    Private Const CMstrDeleteMsg                        As String = "削除"                  '削除成功MSG
    Private Const CMstrRepairTitle                      As String = "故障修理記録票"        '承認or破棄成功MSG(故障修理記録)
    Private Const CMstrMainteTitle                      As String = "装置停止・メンテ"      '承認or破棄成功MSG(装置停止・ﾒﾝﾃ計画)
    Private Const CMstrPreserveTitle                    As String = "保全記録票"            '承認or破棄成功MSG(保全記録)
    Private Const CMstrOneYear                          As String = "1年"                   '表示ﾒｯｾｰｼﾞ(期間指定)
    Private Const CMstrSeachButtonControlMode           As String = "検索ボタン制御"        '検索ﾎﾞﾀﾝ制御判定での表示ﾒｯｾｰｼﾞ有無制御用

    '@担当者列の制御用
    Private Const CMlngEmpNameLenB13                    As Integer = 13                     '担当者の表示ﾊﾞｲﾄ数(13)
    Private Const CMlngEmpNameLenB12                    As Integer = 12                     '担当者の表示ﾊﾞｲﾄ数(12)
    Private Const CMstrEmpNameLenAfter                  As String = ".."                    '担当者の表示

    '@最終更新日時を日時へ変換用
    Private Const CMlngEditTimeChgLen                   As Integer = 16                     '(yyyy/mm/dd hh24:mi:ss.f000)→(YYYY/MM/DD HH:MM)
                                                                                            
    '@故障現象名/保全項目(一部)表示制御用                                                   
    Private Const CMlngDisplayByte30                    As Integer = 30                     '30ﾊﾞｲﾄ
                                                                                            
    '@ﾃｷｽﾄ                                                                                  
    Private Const CMlngMaxDisp3Row                      As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                         As String = "frmxxEN01Z0"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"             'Form_Load処理
    Private Const CMstrCmdSearchClick                   As String = "cmdSearch_Click"       '最新取得ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmbMcGroupValidate               As String = "cmbMcGroup_Validate"   '装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
    Private Const CMstrCmbWpValidate                    As String = "cmbWp_Validate"        '装置名ｺﾝﾎﾞValidate処理
    Private Const CMstrCmdApproveClick                  As String = "cmdApprove_Click"      '承認ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmdDisconClick                   As String = "cmdDiscon_Click"       '破棄ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmdMailSendClick                 As String = "cmdMailSend_Click"     '確認依頼ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmdCopyInsertClick               As String = "cmdCopyInsert_Click"   'ｺﾋﾟｰ登録ﾎﾞﾀﾝClick処理
    Private Const CMstrPrvcmbWpDisp                     As String = "prvCmbWp_Disp"         '装置情報取得＆ｺﾝﾎﾞ設定処理
    Private Const CMstrPrvMainteInfoSel                 As String = "prvMainteInfo_Sel"     '装置停止・ﾒﾝﾃ計画一覧取得処理
    Private Const CMstrPrvRepairInfoSel                 As String = "prvRepairInfo_Sel"     '故障修理記録票一覧取得処理
    Private Const CMstrPrvPreserveInfoSel               As String = "prvPreserveInfo_Sel"   '保全記録票一覧取得処理
    Private Const CMstrPrvCmbCategoryDisp               As String = "prvCmbCategory_Disp"   'ｶﾃｺﾞﾘｺﾝﾎﾞ設定処理

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体/配列
    Private mtypMcGroupList                             As McGroupList                      '装置ｸﾞﾙｰﾌﾟﾘｽﾄ格納
    Private mtypWpList                                  As List(Of AreaEquipmentList)       '装置ﾘｽﾄ格納
    Private mlngWpListCnt                               As Integer                          '装置ﾘｽﾄ数
    Private mtypRepairInfoReq                           As RepairInfoReq                    '故障修理記録一覧取得要求構造体
    Private mtypRepairInfoAns                           As List(Of RepairInfoAns)           '故障修理記録一覧取得応答構造体
    Private mtypChgRepairInfoReq                        As RepairInfo                       '故障修理記録情報登録/更新要求構造体
    Private mlngRepairListCnt                           As Integer                          '故障修理記録一覧ﾘｽﾄ数格納用

    Private mtypPreserveInfoReq                         As PreserveInfoReq                  '保全記録一覧取得要求構造体
    Private mtypPreserveInfoAns                         As List(Of PreserveInfoAns)         '保全記録一覧取得応答構造体
    Private mtypChgPreserveInfoReq                      As PreserveInfo                     '保全記録情報登録/更新要求構造体
    Private mlngPreserveListCnt                         As Integer                          '保全記録一覧ﾘｽﾄ数格納用

    Private mtypCategoryList                            As List(Of MenteCategoryList)       'ｶﾃｺﾞﾘ格納用
    Private mlngCategoryListCnt                         As Integer                          'ｶﾃｺﾞﾘ件数格納用

    Private mtypEqStopMenteListAns                      As EqStopMenteListAns               '装置停止・ﾒﾝﾃ計画一覧取得構造体
    Private mtypEqStopMenteReq                          As EqStopMenteReq                   '装置停止・ﾒﾝﾃ計画登録構造体

    '@退避用ﾓｼﾞｭｰﾙ変数
    Private mstrOldMcGroupID                            As String                           '退避用装置ｸﾞﾙｰﾌﾟID
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mblnFormLoadFlag                            As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:1回目/False:1回目以外)
    Private mblnChkFlag                                 As Boolean                          'ﾁｪｯｸ中判定ﾌﾗｸﾞ(True:ﾁｪｯｸ中、False:ﾁｪｯｸ外)
    Private mblnDitailListFlag                          As Boolean                          '予実表表示判定ﾌﾗｸﾞ(True:予実表表示ﾎﾞﾀﾝからのCALL、False:それ以外)
    Private mlngOptSelectFlag                           As Integer                          '選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝﾌﾗｸﾞ(0:装置停止・ﾒﾝﾃ計画、1:故障修理記録、2:保全記録)

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    '****************************************************************************************
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
    '機　能：ﾌｫｰﾑ　ﾛｰﾄﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/10 (Wed) 16:20:15 N.Kojima
    '更新日：2008/01/18 (Fri) 10:38:01 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 10:38:01 N.Kojima     計画保全対応。追加ｺﾝﾄﾛｰﾙの初期化等を追加。(案件№02332)
    Private Sub Form_Load()
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypMcGroupList         As McGroupList          '装置ｸﾞﾙｰﾌﾟﾘｽﾄ初期化用
        Dim lstrFormTitle           As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim lstrNowDate             As String               '日付一時置換格納
        
        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01Z0, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@=======================
            '@　機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01Z0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@ｿｰﾄ保持構造体初期化
            With mtypChgSort
                .blnChgWidth = False                '列幅変更ﾌﾗｸﾞ(未変更)
                .strKey = vbNullString              'ｶﾚﾝﾄ行検索ｷｰ
                .lngCnt = 0                         '配列ｶｳﾝﾀ
                If .typChgSortList Is Nothing Then  '配列
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear
                End If                
            End With
                
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化
            optSelectMode0.Checked = False          '装置停止・ﾒﾝﾃ計画
            optSelectMode1.Checked = False          '故障修理記録
            optSelectMode2.Checked = False          '保全記録
                
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mstrOldMcGroupID = vbNullString         '装置ｸﾞﾙｰﾌﾟID退避用
            mlngOptSelectFlag = CPlngNumZero        '0:装置停止・ﾒﾝﾃ計画選択
                
            '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体/配列の初期化
            mtypMcGroupList = ltypMcGroupList       '装置ｸﾞﾙｰﾌﾟﾘｽﾄ格納
            '装置名格納用配列
            If mtypWpList  Is Nothing Then
                mtypWpList = New List(Of AreaEquipmentList)
            Else
                mtypWpList.Clear
            End If
            mlngWpListCnt = 0                       '装置名件数
            'ｶﾃｺﾞﾘ格納用配列
            If mtypCategoryList Is Nothing Then
                mtypCategoryList = New List(Of MenteCategoryList)
            Else 
                mtypCategoryList.Clear
            End If
            mlngCategoryListCnt = 0                 'ｶﾃｺﾞﾘ件数
            
            '@ｶﾚﾝﾀﾞｰ設定
            lstrNowDate = Format$(Now, CPstrDateTimeYMD)
            Call pubblnCalendar_Init(calStart, CPlngCalModeTool, lstrNowDate)   '開始日
            Call pubblnCalendar_Init(calEnd, CPlngCalModeTool, lstrNowDate)     '終了日
                
            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=======================
            Call prvFrmxxEN01Z0_Init()
            
            '@=======================
            '@　各ｺﾝﾎﾞの初期化処理
            '@=======================
            Call prvCmbMcGroup_Init                 '装置ｸﾞﾙｰﾌﾟ
            Call prvCmbWp_Init                      '装置名
            Call prvCmbCategory_Init                'ｶﾃｺﾞﾘ
            
            '@=======================
            '@　装置ﾒﾝﾃﾅﾝｽ記録票一覧ｸﾞﾘｯﾄﾞの初期化
            '@　(初期選択状態の装置停止・ﾒﾝﾃ計画ﾊﾞｰｼﾞｮﾝで初期化)
            '@=======================
            Call prvVsfMainteList_Init()
                
            '@【装置ｸﾞﾙｰﾌﾟ取得】ﾒｯｾｰｼﾞ送受信処理(処理区分：全件)
            lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, _
                                               CPstrCD02, _
                                               pstrSBID, _
                                               mtypMcGroupList)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@装置ｸﾞﾙｰﾌﾟが1件か
                If mtypMcGroupList.lngMcGroupListCnt = 1 Then
                    '@1件の場合
                
                    '@【ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得】ﾒｯｾｰｼﾞ送受信処理(CPstrCD20：装置ｸﾞﾙｰﾌﾟ別)
                    lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                                      vbNullString, _
                                                      pstrSBID, _
                                                      mtypWpList, _
                                                      mlngWpListCnt, _
                                                      CPstrCD20, _
                                                      mtypMcGroupList.typMcGroupList(0).strMcGroupID)
                                                      
                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合
                        
                        '@Escﾎﾞﾀﾝを有効
                        Me.CancelButton = cmdClose
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        Exit Sub
                    End If
                End If
            Else
                '@結果：異常の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(Activate処理制御用)
            mblnFormLoadFlag = True
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 17:54:47 N.Kojima
    '更新日：2008/01/17 (Thu) 14:12:19 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 14:12:19 N.Kojima     計画保全対応。ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの処理を追加。(案件№02332)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞがTrueか(Trueは初回起動時のみ)
            If mblnFormLoadFlag = True Then
                
                '@Form_Activate処理は初回の1回のみに制御する為、ﾌﾗｸﾞ変更
                mblnFormLoadFlag = False
                
                '@装置ｸﾞﾙｰﾌﾟが存在するか
                If mtypMcGroupList.lngMcGroupListCnt <> 0 Then
                    '@装置ｸﾞﾙｰﾌﾟが存在する場合
                    
                    '@=======================
                    '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成処理
                    '@=======================
                    cmbMcGroup.Enabled = True
                    Call prvCmbMcGroup_Disp()
                    
                    '@装置ｸﾞﾙｰﾌﾟが1件の場合、ﾃﾞﾌｫﾙﾄ表示
                    If cmbMcGroup.ListCount = 1 Then
                        
                        '@=======================
                        '@　装置名ｺﾝﾎﾞ作成処理
                        '@=======================
                        cmbWp.Enabled = True
                        Call prvcmbWp_Disp()

                    End If
                    
                    '@=======================
                    '@　ｶﾃｺﾞﾘｺﾝﾎﾞ作成処理
                    '@=======================
                    cmbCategory.Enabled = True
                    Call prvcmbCategory_Disp()

                End If
                
                '@初期状態でｵﾌﾟｼｮﾝﾎﾞﾀﾝは「装置停止・ﾒﾝﾃ計画」を選択
                optSelectMode0.Checked = True
                
                '@選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝﾌﾗｸﾞを"0:装置停止・ﾒﾝﾃ計画"にｾｯﾄ
                mlngOptSelectFlag = CPlngNumZero
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
            End If
            
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode    ：ｷｰｺｰﾄﾞ
    '　　　：Shift      ：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 18:24:37 N.Kojima
    '更新日：2008/01/17 (Thu) 14:05:20 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 14:05:20 N.Kojima     計画保全対応。ｶﾃｺﾞﾘｺﾝﾎﾞの処理追加。(案件№02332)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ 〓
                Case cmbMcGroup.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            
                            '@=======================
                            '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
                            '@=======================
                            RemoveHandler cmbMcGroup.Validating, AddressOf cmbMcGroup_Validate
                            Call cmbMcGroup_Validate(cmbMcGroup,New CancelEventArgs(False))
                            AddHandler cmbMcGroup.Validating, AddressOf cmbMcGroup_Validate
                            e.Handled = True
                    End Select
                
                '@〓 装置名ｺﾝﾎﾞ 〓
                Case cmbWp.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=======================
                            '@　装置名ｺﾝﾎﾞValidate処理
                            '@=======================
                            RemoveHandler cmbWp.Validating, AddressOf cmbWp_Validate
                            Call cmbWp_Validate(cmbWp,New CancelEventArgs(False))
                            AddHandler cmbWp.Validating, AddressOf cmbWp_Validate
                            e.Handled = True
                    End Select

                '@〓 ｶﾃｺﾞﾘｺﾝﾎﾞ 〓
                Case cmbWp.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            
                            '@=======================
                            '@　ｶﾃｺﾞﾘｺﾝﾎﾞValidate処理
                            '@=======================
                            RemoveHandler cmbCategory.Validating, AddressOf cmbCategory_Validate
                            Call cmbCategory_Validate(cmbCategory,New CancelEventArgs(False))
                            AddHandler cmbCategory.Validating, AddressOf cmbCategory_Validate
                            e.Handled = True
                    End Select

                '@〓 検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ 〓
                Case calStart.Name
                    
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=======================
                            '@　検索開始日Validate処理
                            '@=======================
                            RemoveHandler calStart.Validating, AddressOf calStart_Validate
                            Call calStart_Validate(calStart,NEw CancelEventArgs(False))
                            AddHandler calStart.Validating, AddressOf calStart_Validate
                            e.Handled = True
                    End Select
                
                '@〓 検索終了日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ 〓
                Case calEnd.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@=======================
                            '@　検索終了日Validate処理
                            '@=======================
                            RemoveHandler calEnd.Validating, AddressOf calEnd_Validate
                            Call calEnd_Validate(calEnd,New CancelEventArgs(False))
                            AddHandler calEnd.Validating, AddressOf calEnd_Validate
                            e.Handled = True
                    End Select
                
                '@〓 その他 〓
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                        
                            '@次項目へｾｯﾄﾌｫｰｶｽ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　ｱﾝﾛｰﾄﾞ時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 18:26:43 N.Kojima
    '更新日：2008/01/17 (Thu) 14:06:05 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 14:06:05 N.Kojima     計画保全対応。装置停止・ﾒﾝﾃ計画格納構造体の初期化処理追加。(案件№02332)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納
        Dim ltypDepartmentList      As DepartmentInfo       '部署/所属格納構造体
        Dim ltypDeptEmpList         As DeptEmpInfo          'ﾕｰｻﾞ格納構造体
        Dim ltypSendMailList        As SendMailList         '宛先人格納構造体
        Dim ltypMailInfo            As MailInfo             'ﾒｰﾙ送信画面引継ぎ構造体
        Dim ltypWorkFlow            As WorkFlow             'ﾜｰｸﾌﾛｰ用初期化構造体
        Dim ltypMcGroupList         As McGroupList          '装置ｸﾞﾙｰﾌﾟﾘｽﾄ初期化用
        Dim ltypRepairInfoReq       As RepairInfoReq        '故障修理記録一覧取得要求構造体初期化用
        Dim ltypChgRepairInfoReq    As RepairInfo           '故障修理記録情報登録/更新要求構造体初期化用
        Dim ltypEqStopMenteListAns  As EqStopMenteListAns   '装置停止・ﾒﾝﾃ計画一覧取得構造体
        Dim ltypPreserveInfoReq     As PreserveInfoReq      '保全記録一覧取得要求構造体初期化用
        Dim ltypChgPreserveInfoReq  As PreserveInfo         '保全記録情報登録/更新要求構造体初期化用

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
                
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
            End If
            mtypChgSort.blnChgWidth = False
            mtypChgSort.strKey = vbNullString
            mtypChgSort.lngCnt = 0
            
            '@ﾒｰﾙ関連一式の構造体をｸﾘｱ
            ptypDepartmentList = ltypDepartmentList
            ptypDeptEmpList = ltypDeptEmpList
            ptypSendMailList = ltypSendMailList
            ptypMailInfo = ltypMailInfo
            If ptypDepartmentList.typDepartmentList Is Nothing Then
                ptypDepartmentList.typDepartmentList = New List(Of DepartmentList)
            Else
                ptypDepartmentList.typDepartmentList.Clear
            End If
            If ptypDeptEmpList.typDeptEmpList Is Nothing Then
                ptypDeptEmpList.typDeptEmpList = New List(Of DeptEmpList)
            Else
                ptypDeptEmpList.typDeptEmpList.Clear
            End If
            If ptypSendMailList.typSendMail Is Nothing Then
                ptypSendMailList.typSendMail = New List(Of SendMail)
            Else
                ptypSendMailList.typSendMail.Clear
            End If
            
            '@装置ﾒﾝﾃﾅﾝｽ記録票(故障修理、保全)確認依頼用情報格納構造体の初期化
            ptypWorkFlow = ltypWorkFlow
            If ptypWorkFlow.typEmpList Is Nothing Then
                ptypWorkFlow.typEmpList= New List(Of ExcpToEmpList)
            Else
                ptypWorkFlow.typEmpList.Clear
            End If
            
            '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体の初期化
            mtypMcGroupList = ltypMcGroupList                   '装置ｸﾞﾙｰﾌﾟﾘｽﾄ格納
            mtypChgRepairInfoReq = ltypChgRepairInfoReq         '故障修理記録情報登録/更新要求構造体
            mtypRepairInfoReq = ltypRepairInfoReq               '故障修理記録一覧取得要求構造体
            mtypChgPreserveInfoReq = ltypChgPreserveInfoReq     '保全記録情報登録/更新要求構造体
            mtypPreserveInfoReq = ltypPreserveInfoReq           '保全記録一覧取得要求構造体
            If mtypWpList Is Nothing THen                       '装置ﾘｽﾄ格納
                mtypWpList = New List(Of AreaEquipmentList)
            Else
                mtypWpList.Clear
            End If
            If mtypRepairInfoAns Is Nothing Then                '故障修理記録一覧取得応答構造体
                mtypRepairInfoAns = New List(Of RepairInfoAns)
            Else
                mtypRepairInfoAns.Clear
            End If                          
            If mtypPreserveInfoAns Is Nothing Then              '保全記録一覧取得応答構造体
                mtypPreserveInfoAns = New List(Of PreserveInfoAns)
            Else
                mtypPreserveInfoAns.Clear
            End If

            mlngWpListCnt = 0                                   '装置ﾘｽﾄ数
            mlngRepairListCnt = 0                               '故障修理記録一覧ﾘｽﾄ数格納用
            mlngPreserveListCnt = 0                             '保全記録一覧ﾘｽﾄ数格納用
            mtypEqStopMenteListAns = ltypEqStopMenteListAns     '装置停止・ﾒﾝﾃ計画一覧取得構造体
            
            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@=======================
                '@　ﾒﾆｭｰを広げる処理
                '@=======================
                Call pubMenuExpand_Disp()
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/15 (Tue) 15:14:24 N.Kojima **************************************************
    '関数名：optSelectMode_Click
    '機　能：機能選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:15:15 N.Kojima
    '更新日：2008/01/17 (Thu) 16:54:55 N.Kojima
    '備　考：
    Private Sub optSelectMode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optSelectMode0.CheckedChanged,
                                                                                          optSelectMode1.CheckedChanged,
                                                                                          optSelectMode2.CheckedChanged

        Dim lblnSearchChk       As Boolean          '検索条件ﾁｪｯｸ結果判定用ﾌﾗｸﾞ(True:ﾁｪｯｸOK、False:ﾁｪｯｸNG)

        Try
            'NSYS チェックが外れた場合処理を抜ける
            If sender.Checked = False Then
                Exit Sub
            End If

            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=======================
            Call prvFrmxxEN01Z0_Init()
            
            '@検索条件ﾁｪｯｸ結果判定ﾌﾗｸﾞの初期化
            lblnSearchChk = False
            
            '@装置停止・ﾒﾝﾃ計画 or 保全記録が選択されているか
            If sender.Name = optSelectMode0.Name Or sender.Name = optSelectMode2.Name Then
                
                '@-----------
                '@　共通処理
                '@-----------
                '@故障修理記録用ｲﾝﾌｫﾒｰｼｮﾝﾗﾍﾞﾙを非表示にする
                lblDisabled.Visible = False
            End If
            
            '@故障修理記録 or 保全記録が選択されているか
            If sender.Name = optSelectMode1.Name Or sender.Name = optSelectMode2.Name Then
            
                '@-----------
                '@　共通処理
                '@-----------
                '@ｶﾃｺﾞﾘｺﾝﾎﾞを使用不可にする
                With cmbCategory
                    .BackColor = SystemColors.ControlLight        'ｸﾞﾚｰ
                    .Text = vbNullString                          'ﾃｷｽﾄ
                    .Enabled = False                              '無効
                End With
                
                '@各種ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを変更する
                '@※殆ど元の表示でも意味は通じるので不要な場合は削除。
        '        cmdNewEntry.Caption = CMstrSinnkitouroku    'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(新規作成⇔登録)
                cmdEdit.Text = CMstrHennsyuu             'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(編集⇔登録)
                cmdDiscon.Text = CMstrHaki               'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(破棄⇔削除)
                
                '@ｺﾋﾟｰ登録ﾎﾞﾀﾝを無効にする
                cmdCopyInsert.Enabled = False
            End If
            
            
            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ※機能毎の個別設定を行なう ★
            Select Case sender.Name
                
                '@〓 装置停止・ﾒﾝﾃ計画 〓
                Case optSelectMode0.Name
                    
                    '@=======================
                    '@ "装置停止・ﾒﾝﾃ計画"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfMainteList_Init()
            
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択ﾌﾗｸﾞを"0:装置停止・ﾒﾝﾃ計画"に設定
                    mlngOptSelectFlag = CPlngNumZero
                    
                    '@ｶﾃｺﾞﾘｺﾝﾎﾞを使用可にする
                    With cmbCategory
                        .BackColor = Color.White        '白
                        .Enabled = True                 '有効
                        .AddedComment = CMstrCmbSelect          '"XX 項目選択"
                        .Text = .ValueCount & CMstrCmbSelect    'XX部に項目数を格納
                    End With
            
                    '@各種ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝを変更する
                    '@※殆ど元の表示でも意味は通じるので不要な場合は削除。
        '            cmdNewEntry.Caption = CMstrTouroku  'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(新規作成⇔登録)
                    cmdEdit.Text = CMstrSyuusei      'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(編集⇔登録)
                    cmdDiscon.Text = CMstrSakujyo    'ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ(破棄⇔削除)
                
                    '@各ﾎﾞﾀﾝを無効にする
                    cmdApprove.Enabled = False          '承認
                    cmdMailSend.Enabled = False         '確認依頼
                    
                    '@共通ﾃｷｽﾄのﾀｲﾄﾙを「停止ｺﾒﾝﾄ」に変更
                    lblInformationTitle.Text = CMstrMntInformationTitle
                    
                    '@起動区分に"0:装置停止・ﾒﾝﾃ計画"をｾｯﾄ
                    plngLoadClass = CPlngNumZero
                
                
                '@〓 故障修理記録 〓
                Case optSelectMode1.Name
                    
                    '@=======================
                    '@　"故障修理記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfRepairList_Init()
                
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択ﾌﾗｸﾞを"1:故障修理記録"に設定
                    mlngOptSelectFlag = CPlngNumOne
                    
                    '@ｲﾝﾌｫﾒｰｼｮﾝﾗﾍﾞﾙを表示する
                    lblDisabled.Visible = True
                    
                    '@共通ﾃｷｽﾄのﾀｲﾄﾙを「故障現象名」に変更
                    lblInformationTitle.Text = CMstrRepairNameTitle
                    
                    '@起動区分に"1:故障修理記録"をｾｯﾄ
                    plngLoadClass = CPlngNumOne
                    

                '@〓 保全記録 〓
                Case optSelectMode2.Name
                    
                    '@=======================
                    '@　"保全記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfPreserveList_Init()
                    
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択ﾌﾗｸﾞを"2:保全記録"に設定
                    mlngOptSelectFlag = CPlngNumTwo
                    
                    '@共通ﾃｷｽﾄのﾀｲﾄﾙを「実施項目」に変更
                    lblInformationTitle.Text = CMstrPreserveItemTitle
                    
                    '@起動区分に"2:保全記録"をｾｯﾄ
                    plngLoadClass = CPlngNumTwo
            
            End Select
            
            '@=======================
            '@　検索条件ﾁｪｯｸ処理
            '@=======================
            lblnSearchChk = prvSearchCondition_Chk(CMstrSeachButtonControlMode)
            
            '@処理結果判定
            If lblnSearchChk = True Then
                '@検索ﾎﾞﾀﾝを有効にする
                cmdSearch.Enabled = True
                
                '@検索ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdSearch)
            Else
                '@検索ﾎﾞﾀﾝ無効にする
                cmdSearch.Enabled = False
                
                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbMcGroup)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optSelectMode_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:14:24 N.Kojima **************************************************

    '関数名：cmbMcGroup_Change
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 18:32:20 N.Kojima
    '更新日：2008/01/17 (Thu) 15:27:00 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 15:27:00 N.Kojima     計画保全対応。ｶﾃｺﾞﾘｺﾝﾎﾞの初期化処理追加。(案件№02332)
    Private Sub cmbMcGroup_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.Change

        Try
            
            '@退避領域と同じ値の場合には初期化しない
            If mstrOldMcGroupID <> cmbMcGroup.Value Then
                
                '@=======================
                '@　ﾒｲﾝﾌｫｰﾑの初期化処理
                '@=======================
                Call prvFrmxxEN01Z0_Init()
                
                '@=======================
                '@　装置名ｺﾝﾎﾞの初期化処理
                '@=======================
                Call prvCmbWp_Init()
                
                '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝによってｸﾞﾘｯﾄﾞの初期化する内容を変える ★
                Select Case mlngOptSelectFlag
                    
                    '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                    Case CPlngNumZero
                        
                        '@=======================
                        '@　"装置停止・ﾒﾝﾃ計画"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                        '@=======================
                        Call prvVsfMainteList_Init()
                    

                    '@〓 "1:故障修理記録" 〓
                    Case CPlngNumOne
                        
                        '@=======================
                        '@　"故障修理記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                        '@=======================
                        Call prvVsfRepairList_Init()
                    
                    
                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo
                        
                        '@=======================
                        '@　"保全記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                        '@=======================
                        Call prvVsfPreserveList_Init()
                        
                End Select
                
                '@装置名ｺﾝﾎﾞの制御
                cmbWp.Enabled = True                            '有効
                '@"0 項目選択"を表示
                cmbWp.AddedComment = CMstrCmbSelect             '"XX 項目選択"
                cmbWp.Text = CPstrZero & CMstrCmbSelect         'XX部に項目数を格納
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroup_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_CloseUp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/26 (Fri) 17:15:45 N.Kojima
    '更新日：2007/01/26 (Fri) 17:15:45
    '備　考：
    Private Sub cmbMcGroup_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.CloseUp

        Try

            '@装置ｸﾞﾙｰﾌﾟが選択されているか
            If cmbMcGroup.Text <> vbNullString Then
                
                '@=======================
                '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbMcGroup.Validating,AddressOf cmbMcGroup_Validate
                Call cmbMcGroup_Validate(cmbMcGroup,New CancelEventArgs(True))
                AddHandler cmbMcGroup.Validating,AddressOf cmbMcGroup_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroup_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_Validate
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 16:58:12 N.Kojima
    '更新日：2007/01/17 (Wed) 16:58:12
    '備　考：
    Private Sub cmbMcGroup_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroup.Validating

        Dim lblnAns             As Boolean              '結果格納
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            With cmbMcGroup
            
                '@前回ID格納と同じ場合は処理しない
                If .Value = mstrOldMcGroupID Then
                
                    '@装置名ｺﾝﾎﾞが有効か
                    If cmbWp.Enabled = True Then
                        '@装置名ｺﾝﾎﾞへﾌｫｰｶｽ設定
                        If ActiveControl.Name = cmbMcGroup.Name Then
                            Call pubSetFocus(cmbWp)
                        End If 
                    Else
                        '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                        '@それ以外の場合は、閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If pblnFormLoad <> False Then
                            If ActiveControl.Name = cmbMcGroup.Name Then
                                Call pubSetFocus(cmdClose)
                            End If
                        End If
                    End If
                    
                    Exit Sub
                End If
            
                '@装置ｸﾞﾙｰﾌﾟがNULLか
                If .Text = vbNullString Then
                    
                    '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                    '@それ以外の場合は、閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If pblnFormLoad <> False Then
                        If ActiveControl.Name = cmbMcGroup.Name Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                    
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmbMcGroupValidate)

                Me.KeyPreview = False

                '@【ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得(装置情報取得)】ﾒｯｾｰｼﾞ送受信処理　※CPstrCD20：装置ｸﾞﾙｰﾌﾟ別
                lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                                  vbNullString, _
                                                  pstrSBID, _
                                                  mtypWpList, _
                                                  mlngWpListCnt, _
                                                  CPstrCD20, _
                                                  .Value)

                Me.KeyPreview = True
                                                  
                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合
                    
                    '@=======================
                    '@　装置名ｺﾝﾎﾞ作成処理
                    '@=======================
                    cmbWp.Enabled = True
                    Call prvcmbWp_Disp()

                    '@=======================
                    '@　検索条件ﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvSearchCondition_Chk(CMstrSeachButtonControlMode)
                    
                    '@処理結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合
                    
                        '@検索ﾎﾞﾀﾝを有効にする
                        cmdSearch.Enabled = True
                    Else
                        '@結果：異常の場合
                    
                        '@検索ﾎﾞﾀﾝを無効にする
                        cmdSearch.Enabled = False
                    End If

                    '@装置名ｺﾝﾎﾞが有効か
                    If cmbWp.Enabled = True Then
                        '@装置名ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbMcGroup.Name Then
                            Call pubSetFocus(cmbWp)
                        End If
                    Else
                        '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                        '@それ以外の場合は、閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If pblnFormLoad <> False Then
                            If ActiveControl.Name = cmbMcGroup.Name Then
                                Call pubSetFocus(cmdClose)
                            End If
                        End If
                    End If
                Else
                    '@結果：異常の場合
                    
                    '@装置名ｺﾝﾎﾞを使用不可にする
                    cmbWp.Enabled = False
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmbMcGroupValidate)
                    
                    '@ﾌｫｰｶｽを保持
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@装置ｸﾞﾙｰﾌﾟを退避
                mstrOldMcGroupID = cmbMcGroup.Value
                
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmbMcGroupValidate)
            
            Exit Sub
            
        Catch ex As Exception

            Me.KeyPreview = True
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmbMcGroupValidate
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_Change
    '機　能：装置名ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 17:11:24 N.Kojima
    '更新日：2008/01/18 (Fri) 10:41:28 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 10:41:28 N.Kojima     計画保全対応。ｸﾞﾘｯﾄﾞの初期化処理を変更。(案件№02332)
    Private Sub cmbWp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.Change

        Try
            
            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=======================
            Call prvFrmxxEN01Z0_Init()
            
            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝによってｸﾞﾘｯﾄﾞの初期化する内容を変える ★
            Select Case mlngOptSelectFlag
                
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero
                    
                    '@=======================
                    '@　"装置停止・ﾒﾝﾃ計画"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfMainteList_Init()
                    
                    
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                    
                    '@=======================
                    '@　"故障修理記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfRepairList_Init()
                
                
                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                    
                    '@=======================
                    '@　"保全記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfPreserveList_Init()
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_CloseUp
    '機　能：装置名ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 17:15:18 N.Kojima
    '更新日：2007/01/17 (Wed) 17:15:18
    '備　考：
    Private Sub cmbWp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.CloseUp

        Try
            
            '@装置名が選択されているか
            If cmbWp.Text <> vbNullString Then

                '@=======================
                '@　装置名ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbWp.Validating,AddressOf cmbWp_Validate
                Call cmbWp_Validate(cmbWp,New CancelEventArgs(True))
                AddHandler cmbWp.Validating,AddressOf cmbWp_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_Validate
    '機　能：装置名ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 17:15:56 N.Kojima
    '更新日：2008/01/17 (Thu) 15:41:48 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 15:41:48 N.Kojima     計画保全対応。ｶﾃｺﾞﾘｺﾝﾎﾞ追加に伴い、ﾌｫｰｶｽｾｯﾄ処理を修正。(案件№02332)
    Private Sub cmbWp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWp.Validating

        Dim lblnAns     As Boolean      '戻り値格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@=======================
            '@　検索条件ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvSearchCondition_Chk(CMstrSeachButtonControlMode)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@検索ﾎﾞﾀﾝを有効にする
                cmdSearch.Enabled = True
            Else
                '@結果：異常の場合
            
                '@検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
                Exit Sub
            End If
            
            '@ｶﾃｺﾞﾘｺﾝﾎﾞが有効か
            If cmbCategory.Enabled = True Then
                '@ｶﾃｺﾞﾘｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbWp.Name Then
                    Call pubSetFocus(cmbCategory)
                End If
            Else
                '@ｶﾃｺﾞﾘｺﾝﾎﾞが無効な場合
                
                '@検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞが有効か
                If calStart.Enabled = True Then
                    '@検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbWp.Name Then
                        Call pubSetFocus(calStart)
                    End If
                Else
                    '@検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞまでもが無効な場合
                    
                    '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                    '@それ以外の場合は、閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If pblnFormLoad <> False Then
                        If ActiveControl.Name = cmbWp.Name Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmbWpValidate
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/15 (Tue) 15:18:08 N.Kojima **************************************************
    '関数名：cmbCategory_Change
    '機　能：ｶﾃｺﾞﾘｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:18:11 N.Kojima
    '更新日：2008/01/15 (Tue) 15:18:11
    '備　考：
    Private Sub cmbCategory_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCategory.Change

        Try
            
            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=======================
            Call prvFrmxxEN01Z0_Init()

            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝによってｸﾞﾘｯﾄﾞの初期化する内容を変える ★
            '@　　※故障修理選択時はｶﾃｺﾞﾘ選択不可な為、下記に処理は無し
            Select Case mlngOptSelectFlag
                
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero
                    
                    '@=======================
                    '@　"装置停止・ﾒﾝﾃ計画"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfMainteList_Init()
                    
                    
                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                    
                    '@=======================
                    '@　"保全記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfPreserveList_Init()
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCategory_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:18:08 N.Kojima **************************************************

    '@↓2008/01/15 (Tue) 15:17:53 N.Kojima **************************************************
    '関数名：cmbCategory_CloseUp
    '機　能：ｶﾃｺﾞﾘｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:17:56 N.Kojima
    '更新日：2008/01/15 (Tue) 15:17:56
    '備　考：
    Private Sub cmbCategory_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCategory.CloseUp

        Try

            '@ｶﾃｺﾞﾘが選択されているか
            If cmbCategory.Text <> vbNullString Then
            
                '@=======================
                '@　ｶﾃｺﾞﾘｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbCategory.Validating,AddressOf cmbCategory_Validate
                Call cmbCategory_Validate(cmbCategory,New CancelEventArgs(True))
                AddHandler cmbCategory.Validating,AddressOf cmbCategory_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCategory_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:17:53 N.Kojima **************************************************

    '@↓2008/01/15 (Tue) 15:17:34 N.Kojima **************************************************
    '関数名：cmbCategory_Validate
    '機　能：ｶﾃｺﾞﾘｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/01/15 (Tue) 15:17:37 N.Kojima
    '更新日：2008/01/15 (Tue) 15:17:37
    '備　考：
    Private Sub cmbCategory_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCategory.Validating

        Dim lblnAns     As Boolean      '戻り値格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@=======================
            '@　検索条件ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvSearchCondition_Chk(CMstrSeachButtonControlMode)
            
            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合
            
                '@検索ﾎﾞﾀﾝを有効にする
                cmdSearch.Enabled = True
            Else
                '@結果：異常の場合
            
                '@検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
                Exit Sub
            End If

            '@検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞが有効か
            If calStart.Enabled = True Then
                '@検索開始日ｶﾚﾝﾀﾞｰｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbCategory.Name Then
                    Call pubSetFocus(calStart)
                End If
            Else
                '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                '@それ以外の場合は、閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                If pblnFormLoad <> False Then
                    If ActiveControl.Name = cmbCategory.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCategory_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/15 (Tue) 15:17:34 N.Kojima **************************************************

    '関数名：calStart_CalendarSelect
    '機　能：検索期間(開始)ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 10:37:30 N.Kojima
    '更新日：2007/01/17 (Wed) 10:37:30
    '備　考：
    Private Sub calStart_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calStart.CalendarSelect

        Try
            
            '@=======================
            '@　検索期間(開始)ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
            '@=======================
            RemoveHandler calStart.Validating,AddressOf calStart_Validate
            Call calStart_Validate(calStart,New CancelEventArgs(False))
            AddHandler calStart.Validating,AddressOf calStart_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStart_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStart_Change
    '機　能：検索期間(開始)ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 10:37:46 N.Kojima
    '更新日：2008/01/18 (Fri) 10:43:19 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 10:43:19 N.Kojima     計画保全対応。ｸﾞﾘｯﾄﾞの初期化処理を変更。(案件№02332)
    Private Sub calStart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calStart.Change

        Try
            
            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=======================
            Call prvFrmxxEN01Z0_Init()

            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case mlngOptSelectFlag
                
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero
                    
                    '@=======================
                    '@　"装置停止・ﾒﾝﾃ計画"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfMainteList_Init()
                
                
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                    
                    '@=======================
                    '@　"故障修理記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfRepairList_Init()
                
                
                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                    
                    '@=======================
                    '@　"保全記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfPreserveList_Init()
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStart_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStart_Validate
    '機　能：検索期間(開始)ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 10:40:04 N.Kojima
    '更新日：2008/01/17 (Thu) 16:08:33 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 16:08:33 N.Kojima     検索期間の縛りを1年に延長。(案件№02504)
    Private Sub calStart_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calStart.Validating

        Dim lstrNowDT           As String       '現在日付取得
        Dim lstrDate            As String       '3ヵ月後の日付格納用
        Dim lblnErrFlag         As Boolean      'ｴﾗｰ判定ﾌﾗｸﾞ
        Dim lblnAns             As Boolean      '戻り値用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｴﾗｰ判定ﾌﾗｸﾞの初期化
            lblnErrFlag = True
                
            '@検索開始日が"____/__/__"以外か
            If calStart.Value <> CPstrNullDate Then
                '@検索開始日が"____/__/__"以外の場合
                
                '@=======================
                '@　検索開始日の有効範囲ﾁｪｯｸ処理
                '@=======================
                If pubblnYearRange_Chk(calStart.Value) = False Then
                    '@無効日付の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
                    lblnErrFlag = False
                Else
                    '@有効日付の場合
                    
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    
        '            '@未来日付の場合
        '            If Format$(calStart.Value, CPstrDateTimeYMD) > lstrNowDT Then
        '
        '                '@表示ﾒｯｾｰｼﾞ変換
        '                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
        '                '@"未来日付は指定できません。"
        '                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01Z0.Caption, True, 16)
        '
        '                '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
        '                lblnErrFlag = False
        '            Else
        '                '@未来日付以外の場合
        '
        '                '@開始日付 > 終了日付か
        '                If Format$(calStart.Value, CPstrDateTimeYMD) > Format$(calEnd.Value, CPstrDateTimeYMD) Then
        '
        '                    '@表示ﾒｯｾｰｼﾞ変換
        '                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
        '                    '@"開始日が終了日より大きくなっています。設定を見直してください。"
        '                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01Z0.Caption, True, 16)
        '
        '                    '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
        '                    lblnErrFlag = False
        '                End If
        '            End If

                    '@開始日付 > 終了日付か
                    If Format$(CDate(calStart.Value), CPstrDateTimeYMD) > Format$(CDate(calEnd.Value), CPstrDateTimeYMD) Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                        '@"開始日が終了日より大きくなっています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
                        lblnErrFlag = False
                    End If

                End If
            Else
                '@入力されていない(NULL：____/__/__)の場合
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002V)
                '@"開始日を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                 '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
                lblnErrFlag = False
            End If
            
            '@終了日が指定されている場合
            If calEnd.Value <> CPstrNullDate Then
            
                '@開始日付の12ヵ月後(1年後)を格納
                lstrDate = Format$(DateAdd(CMstrM, 12, calStart.Value), CPstrDateTimeYMDHM)
                
                '@開始日付が終了日付の12ヶ月後より大きい場合
                If lstrDate < calEnd.Value Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrOneYear)
                    '@"<TRM8WW>$$期間指定について、開始～終了までの間は$1年以内で設定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
                    lblnErrFlag = False
                End If
            End If
            
            '@ｴﾗｰ判定ﾌﾗｸﾞがFalseか
            If lblnErrFlag = False Then
            
                '@検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
                
                e.Cancel = True
                Exit Sub
            Else
                '@=======================
                '@　検索条件ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvSearchCondition_Chk(CMstrSeachButtonControlMode)
                
                '@処理結果判定
                If lblnAns = True Then
                    '@結果：正常の場合
                
                    '@検索ﾎﾞﾀﾝを有効にする
                    cmdSearch.Enabled = True
                Else
                    '@結果：異常の場合
                
                    '@検索ﾎﾞﾀﾝを無効にする
                    cmdSearch.Enabled = False
                End If
            End If
            
            If ActiveControl.Name = calStart.Name Then
                '@検索終了日が有効か
                If calEnd.Enabled = True Then
                    '@検索終了日にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calEnd)
                Else
                    '@閉じるにｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmdClose)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStart_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calEnd_CalendarSelect
    '機　能：検索期間(終了)ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 10:45:06 N.Kojima
    '更新日：2007/01/17 (Wed) 10:45:06
    '備　考：
    Private Sub calEnd_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calEnd.CalendarSelect

        Try
            
            '@=======================
            '@　検索期間(終了)ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
            '@=======================
            RemoveHandler calEnd.Validating,AddressOf calEnd_Validate
            Call calEnd_Validate(calEnd,New CancelEventArgs(False))
            AddHandler calEnd.Validating,AddressOf calEnd_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEnd_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calEnd_Change
    '機　能：検索期間(終了)ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 10:45:22 N.Kojima
    '更新日：2008/01/18 (Fri) 10:44:42 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 10:44:42 N.Kojima     計画保全対応。ｸﾞﾘｯﾄﾞの初期化処理を変更。(案件№02332)
    Private Sub calEnd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calEnd.Change

        Try

            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=======================
            Call prvFrmxxEN01Z0_Init()

            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case mlngOptSelectFlag
                
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero
                    
                    '@=======================
                    '@　"装置停止・ﾒﾝﾃ計画"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfMainteList_Init()


                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                    
                    '@=======================
                    '@　"故障修理記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfRepairList_Init()
             
             
                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                    
                    '@=======================
                    '@　"保全記録"選択時ﾊﾞｰｼﾞｮﾝでｸﾞﾘｯﾄﾞを初期化
                    '@=======================
                    Call prvVsfPreserveList_Init()
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEnd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calEnd_Validate
    '機　能：検索期間(終了)ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 10:45:50 N.Kojima
    '更新日：2008/01/17 (Thu) 16:08:33 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 16:08:33 N.Kojima     検索期間の縛りを1年に延長。(案件№02504)
    Private Sub calEnd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calEnd.Validating

        Dim lstrNowDT           As String       '現在日付取得
        Dim lstrDate            As String       '3ヵ月前の日付格納用
        Dim lblnErrFlag         As Boolean      'ｴﾗｰ判定ﾌﾗｸﾞ
        Dim lblnAns             As Boolean      '戻り値格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｴﾗｰ判定ﾌﾗｸﾞの初期化
            lblnErrFlag = True
            
            '@検索終了日が入力されているか
            If calEnd.Value <> CPstrNullDate Then
                '@検索終了日が入力されている場合
                
                '@=======================
                '@　検索終了日の有効範囲ﾁｪｯｸ処理
                '@=======================
                If pubblnYearRange_Chk(calEnd.Value) = False Then
                    '@日付が無効な場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
                    lblnErrFlag = False
                Else
                    '@日付が有効な場合
                
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    
        '            '@検索終了日が未来日付か
        '            If Format$(calEnd.Value, CPstrDateTimeYMD) > lstrNowDT Then
        '                '@未来日付の場合
        '
        '                '@表示ﾒｯｾｰｼﾞ変換
        '                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
        '                '@"未来日付は指定できません。"
        '                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01Z0.Caption, True, 16)
        '
        '                '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
        '                lblnErrFlag = False
        '            Else
        '                '@未来日付以外の場合
        '
        '                '@開始日付 > 終了日時か
        '                If Format$(calStart.Value, CPstrDateTimeYMD) > Format$(calEnd.Value, CPstrDateTimeYMD) Then
        '                    '@表示ﾒｯｾｰｼﾞ変換
        '                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
        '                    '@"開始日が終了日より大きくなっています。設定を見直してください。"
        '                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01Z0.Caption, True, 16)
        '
        '                    '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
        '                    lblnErrFlag = False
        '                End If
        '            End If


                    If Format$(CDate(calStart.Value), CPstrDateTimeYMD) > Format$(CDate(calEnd.Value), CPstrDateTimeYMD) Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                        '@"開始日が終了日より大きくなっています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
                        lblnErrFlag = False
                    End If

                End If
            Else
                '@入力されていない(NULL：____/__/__)の場合
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002W)
                '@"終了日を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
                lblnErrFlag = False
            End If
            
            '@開始日が指定されている場合
            If calStart.Value <> CPstrNullDate Then
            
                '@開始日付の12ヵ月後を格納
                lstrDate = Format$(DateAdd(CMstrM, 12, calStart.Value), CPstrDateTimeYMDHM)
                
                '@開始日付が終了日付の12ヶ月後より大きい場合
                If lstrDate < calEnd.Value Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrOneYear)
                    '@"<TRM8WW>$$期間指定について、開始～終了までの間は$1年以内で設定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾗｰ判定ﾌﾗｸﾞをFalseに設定
                    lblnErrFlag = False
                End If
            End If

            '@ｴﾗｰ判定ﾌﾗｸﾞがFalseか
            If lblnErrFlag = False Then
            
                '@検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
                
                e.Cancel = True
                Exit Sub
            Else
                '@=======================
                '@　検索条件ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvSearchCondition_Chk(CMstrSeachButtonControlMode)
                
                '@処理結果判定
                If lblnAns = True Then
                    '@結果：正常の場合
                
                    '@検索ﾎﾞﾀﾝを有効にする
                    cmdSearch.Enabled = True
                Else
                    '@結果：異常の場合
                
                    '@検索ﾎﾞﾀﾝを無効にする
                    cmdSearch.Enabled = False
                End If
            End If

            '@検索ﾎﾞﾀﾝが有効か
            If ActiveControl.Name = calEnd.Name Then
                If cmdSearch.Enabled = True Then
                    '@有効な場合は検索ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdSearch)
                Else
                    '@無効な場合は閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calEnd_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSearch_Click
    '機　能：検索ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 11:02:09 N.Kojima
    '更新日：2008/01/18 (Fri) 10:45:23 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 10:45:23 N.Kojima     計画保全対応。選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理を変更する。(案件№02332)
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click

        Dim lblnAns             As Boolean              '結果格納

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is cmdSearch Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　検索条件ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvSearchCondition_Chk(vbNullString)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@共通ﾌｨｰﾙﾄﾞﾃｷｽﾄの初期化
            txtInformation.Text = vbNullString
            
            '@★ 情報取得処理 ※選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case mlngOptSelectFlag
                
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero
                    
                    '@=======================
                    '@　装置停止・ﾒﾝﾃ計画一覧取得(&一覧表示)処理
                    '@=======================
                    Call prvMainteInfo_Sel()
                    
                    '@ｸﾞﾘｯﾄﾞのﾃﾞｰﾀ行が選択されているか
                    If vsfMainteList.Row <= 1 Then
                        '@ｺﾋﾟｰ登録ﾎﾞﾀﾝを無効にする
                        cmdCopyInsert.Enabled = False
                    End If
             
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                    
                    '@=======================
                    '@　故障修理記録票一覧取得(&一覧表示)処理
                    '@=======================
                    Call prvRepairInfo_Sel()
                
                
                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                    
                    '@=======================
                    '@　保全記録票一覧取得(&一覧表示)処理
                    '@=======================
                    Call prvPreserveInfo_Sel()
                    
            End Select

            '@該当件数が0件か
            If lblDataCnt.Text <> CPstrZero Then
                '@件数が1件以上ある場合
                
                '@ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfMainteList)
                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの活性化
                cmdCopy.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSearch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_AfterSort
    '機　能：共通ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ順
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 17:25:04 N.Kojima
    '更新日：2008/01/18 (Fri) 11:09:39 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 11:09:39 N.Kojima     計画保全対応。ｿｰﾄ後のｶﾚﾝﾄ行設定を選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝ毎に変える。(案件№02332)
    Private Sub vsfMainteList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMainteList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If

            AddHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
            AddHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange
            AddHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
            AddHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange
            AddHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
            AddHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange

            '@ｿｰﾄ順を格納
            With mtypChgSort
                
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1

                Dim typChgSortListTmp As New ChgSortList
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(typChgSortListTmp)
            End With

            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐　※ｿｰﾄ後のｶﾚﾝﾄ行設定を変える ★
            Select Case mlngOptSelectFlag
                
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero
                    
                    '@=======================
                    '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
                    '@=======================
                    Call pubVsfAfterSort(vsfMainteList, CMlngvsfMntColStartDate & vbTab & CMlngvsfMntColWPID,Nothing ,Nothing ,False, False, False, False)
                   
                   
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                    
                    '@=======================
                    '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
                    '@=======================
                    Call pubVsfAfterSort(vsfMainteList, CMlngvsfRepColRepairNo & vbTab & CMlngvsfRepColWPID,Nothing ,Nothing ,False, False, False, False)
                
                
                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                    
                    '@=======================
                    '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
                    '@=======================
                    Call pubVsfAfterSort(vsfMainteList, CMlngvsfPreColPreserveNo & vbTab & CMlngvsfPreColWpID,Nothing ,Nothing ,False, False, False, False)
                    
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_AfterUserResize
    '機　能：共通ｸﾞﾘｯﾄﾞ　ｸﾞﾘｯﾄﾞ幅変更時処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2007/02/07 (Wed) 13:55:10 N.Kojima
    '更新日：2007/02/07 (Wed) 13:55:10
    '備　考：
    Private Sub vsfMainteList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfMainteList.AfterResizeColumn, vsfMainteList.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_BeforeRowColChange
    '機　能：共通ｸﾞﾘｯﾄﾞ　ｸﾞﾘｯﾄﾞ変更時処理
    '引　数：OldRow ：旧行
    '　　　：OldCol ：旧列
    '　　　：NewRow ：新行
    '　　　：NewCol ：新列
    '　　　：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 17:50:52 N.Kojima
    '更新日：2008/01/18 (Fri) 11:11:24 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 11:11:24 N.Kojima     計画保全対応。選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝに応じ、ｿｰﾄ後のｶﾚﾝﾄ行設定を変える。(案件№02332)
    Private Sub vsfMainteList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfMainteList.BeforeRowColChange
                                                   
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                
                '@ｶﾚﾝﾄ行検索用のｷｰを格納
                With vsfMainteList
                
                    '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐　※ｿｰﾄ後のｶﾚﾝﾄ行設定を変える ★
                    Select Case mlngOptSelectFlag
                        
                        '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                        Case CPlngNumZero
                            
                            mtypChgSort.strKey = .GetData(e.NewRange.r1, CMlngvsfMntColStartDate) & _
                                                 .GetData(e.NewRange.r1, CMlngvsfMntColWPID)
                        
                        '@〓 "1:故障修理記録" 〓
                        Case CPlngNumOne
                
                            mtypChgSort.strKey = .GetData(e.NewRange.r1, CMlngvsfRepColRepairNo) & _
                                                 .GetData(e.NewRange.r1, CMlngvsfRepColWPID)
                     
                        '@〓 "2:保全記録" 〓
                        Case CPlngNumTwo
                            
                            mtypChgSort.strKey = .GetData(e.NewRange.r1, CMlngvsfPreColPreserveNo) & _
                                                 .GetData(e.NewRange.r1, CMlngvsfPreColWpID)
                            
                    End Select
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_BeforeSort
    '機　能：共通ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ順
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 17:51:57 N.Kojima
    '更新日：2008/01/18 (Fri) 11:13:58 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 11:13:58 N.Kojima     計画保全対応。選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝに応じ、ｿｰﾄ後のｶﾚﾝﾄ行設定を変える。(案件№02332)
    Private Sub vsfMainteList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMainteList.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If
            
            RemoveHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
            RemoveHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange
            RemoveHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
            RemoveHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange
            RemoveHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
            RemoveHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange

            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐　※ｿｰﾄ後のｶﾚﾝﾄ行設定を変える ★
            Select Case mlngOptSelectFlag
                
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero
                    
                    '@=======================
                    '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)処理
                    '@=======================
                    Call pubVsfBeforeSort(vsfMainteList, CMlngvsfMntColStartDate & vbTab & CMlngvsfMntColWPID)
                
                
                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne
                    
                    '@=======================
                    '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)処理
                    '@=======================
                    Call pubVsfBeforeSort(vsfMainteList, CMlngvsfRepColRepairNo & vbTab & CMlngvsfRepColWPID)
                
                
                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo
                    
                    '@=======================
                    '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)処理
                    '@=======================
                    Call pubVsfBeforeSort(vsfMainteList, CMlngvsfPreColPreserveNo & vbTab & CMlngvsfPreColWpID)
                    
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_DblClick
    '機　能：共通ｸﾞﾘｯﾄﾞ　ﾀﾞﾌﾞﾙｸﾘｯｸ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 10:29:53 N.Kojima
    '更新日：2007/03/15 (Thu) 10:29:53
    '備　考：
    Private Sub vsfMainteList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMainteList.DoubleClick

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfMainteList.Rows.Count <= vsfMainteList.Rows.Fixed Then
                Return
            End If
            
            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfMainteList.MouseRow <= 0 Then
                Exit Sub
            End If
                
            '@=======================
            '@　編集(修正)ﾎﾞﾀﾝ押下処理
            '@=======================
            Call cmdEdit_Click(cmdEdit,New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMainteList_RowColChange
    '機　能：共通ｸﾞﾘｯﾄﾞ　ｸﾞﾘｯﾄﾞ選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 17:52:25 N.Kojima
    '更新日：2008/08/08 (Fri) 14:23:57 M.Koni
    '備　考：
    '　　　：2008/01/18 (Fri) 11:51:43 N.Kojima     計画保全対応。選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝに応じ、処理を分岐。(案件№02332)
    '　　　：2008/08/08 (Fri) 14:24:10 M.Koni       処置済みﾃﾞｰﾀの削除対応 <案件No.03114>
    Private Sub vsfMainteList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMainteList.RowColChange

        Try

            With vsfMainteList
                
                '@選択行がﾀｲﾄﾙ行以外の場合には,編集ﾎﾞﾀﾝの活性化処理を行う
                If .Row > CMlngVsfRowTitle Then
                
                    '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐　※ｿｰﾄ後のｶﾚﾝﾄ行設定を変える ★
                    Select Case mlngOptSelectFlag
                        
                        '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                        Case CPlngNumZero
                            
                            '@共通情報表示ﾌｨｰﾙﾄﾞに停止ｺﾒﾝﾄを全文表示
                            txtInformation.Text = .GetData(.Row, CMlngvsfMntColCommentsAll)
                          
                          
                        '@〓 "1:故障修理記録" 〓
                        Case CPlngNumOne
                
                            '@共通情報表示ﾌｨｰﾙﾄﾞに故障現象名を全文表示
                            txtInformation.Text = .GetData(.Row, CMlngvsfRepColAllRepairName)


                        '@〓 "2:保全記録" 〓
                        Case CPlngNumTwo
                            
                            '@共通情報表示ﾌｨｰﾙﾄﾞに実施項目を全文表示
                            txtInformation.Text = .GetData(.Row, CMlngvsfPreColPreserveItemAll)
                            
                    End Select
                    
                    '@編集(修正)ﾎﾞﾀﾝの活性化
                    cmdEdit.Enabled = True
                
                    '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
                    Select Case mlngOptSelectFlag
                    
                        '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                        Case CPlngNumZero
                        
                            '@計画ﾃﾞｰﾀの場合(0:ｶﾃｺﾞﾘがﾒﾝﾃ計画じゃないﾃﾞｰﾀ)
                            If .GetData(.Row, CMlngvsfMntColCategoryID) = CPstrZero Then
                                
                                '@各種ﾎﾞﾀﾝを有効にする
                                cmdDiscon.Enabled = True        '削除
                                cmdEdit.Enabled = True          '修正
                                cmdCopyInsert.Enabled = True    'ｺﾋﾟｰ登録
                            Else
                                '@実績ﾃﾞｰﾀの場合
                                
                                '@各種ﾎﾞﾀﾝを無効にする
                                cmdDiscon.Enabled = False       '削除
                                cmdCopyInsert.Enabled = False   'ｺﾋﾟｰ登録
                                
                                '@修正ﾎﾞﾀﾝは有効にする(実績ﾃﾞｰﾀもｺﾒﾝﾄだけは修正可)
                                cmdEdit.Enabled = True
                            End If
                            
                            '@確認依頼ﾎﾞﾀﾝは無効
                            cmdMailSend.Enabled = False
                    
                    
                        '@〓 "1:故障修理記録" 〓
                        Case CPlngNumOne
                        
                            '@選択行ﾃﾞｰﾀの状態IDにより,ﾎﾞﾀﾝの制御を行う　※Col=1(CPlngNumOne)は状態ID列
                            If .GetData(.Row, CPlngNumOne) = CPstrTwo Then
                                '@選択行ﾃﾞｰﾀが「承認済み(=2)」の場合
                            
                                '@各種ﾎﾞﾀﾝの制御
                                cmdApprove.Enabled = False      '承認ﾎﾞﾀﾝ
                                cmdDiscon.Enabled = False       '破棄ﾎﾞﾀﾝ
                            Else
                                '@「未処置」か
                                If .GetData(.Row, CPlngNumOne) = CPstrZero Then
                                    '@各種ﾎﾞﾀﾝの制御
                                    cmdApprove.Enabled = False  '承認ﾎﾞﾀﾝ
                                    cmdDiscon.Enabled = True    '破棄ﾎﾞﾀﾝ
                                Else
                                    '@「処置済み」の場合
                                    '@各種ﾎﾞﾀﾝの制御
        '@↓2008/08/08 (Fri) 14:22:13 M.Koni **************************************************<案件No.03114>
                                    cmdApprove.Enabled = True   '承認ﾎﾞﾀﾝ
                                    cmdDiscon.Enabled = True    '破棄ﾎﾞﾀﾝ
        '@↑2008/08/08 (Fri) 14:22:13 M.Koni **************************************************<案件No.03114>
                                End If
                            End If
                            
                            '@確認依頼ﾎﾞﾀﾝを有効にする
                            cmdMailSend.Enabled = True
                            
                            
                        '@〓 "2:保全記録" 〓
                        Case CPlngNumTwo
                        
                            '@選択行ﾃﾞｰﾀの状態IDにより,ﾎﾞﾀﾝの制御を行う　※Col=1(CPlngNumOne)は状態ID列
                            If .GetData(.Row, CPlngNumOne) = CPstrTwo Then
                                '@選択行ﾃﾞｰﾀが「承認済み(=2)」の場合
                            
                                '@各種ﾎﾞﾀﾝの制御
                                cmdApprove.Enabled = False      '承認ﾎﾞﾀﾝ
                                cmdDiscon.Enabled = False       '破棄ﾎﾞﾀﾝ
                            Else
                                '@「未処置」か
                                If .GetData(.Row, CPlngNumOne) = CPstrZero Then
                                    '@各種ﾎﾞﾀﾝの制御
                                    cmdApprove.Enabled = False  '承認ﾎﾞﾀﾝ
                                    cmdDiscon.Enabled = True    '破棄ﾎﾞﾀﾝ
                                Else
                                    '@「処置済み」の場合

                                    '@各種ﾎﾞﾀﾝの制御
        '@↓2008/08/08 (Fri) 14:22:36 M.Koni **************************************************<案件No.03114>
                                    cmdApprove.Enabled = True   '承認ﾎﾞﾀﾝ
                                    cmdDiscon.Enabled = True    '破棄ﾎﾞﾀﾝ
        '@↑2008/08/08 (Fri) 14:22:36 M.Koni **************************************************<案件No.03114>
                                End If
                            End If
                            
                            '@確認依頼ﾎﾞﾀﾝを有効にする
                            cmdMailSend.Enabled = True
                            
                    End Select
                Else
                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdEdit.Enabled = False         '編集ﾎﾞﾀﾝ
                    cmdApprove.Enabled = False      '承認ﾎﾞﾀﾝ
                    cmdDiscon.Enabled = False       '破棄ﾎﾞﾀﾝ
                    cmdMailSend.Enabled = False     '確認依頼ﾎﾞﾀﾝ
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMainteList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/03/05 (Wed) 11:24:54 N.Kojima **************************************************
    '関数名：txtInformation_Change
    '機　能：共通ﾃｷｽﾄ欄　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/05 (Wed) 11:24:37 N.Kojima
    '更新日：2008/03/05 (Wed) 11:24:37
    '備　考：
    Private Sub txtInformation_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtInformation.Change

        Try

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtInformation, CMlngMaxDisp3Row, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInformation_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/05 (Wed) 11:24:54 N.Kojima **************************************************

    '@↓2008/03/05 (Wed) 11:26:38 N.Kojima **************************************************
    '関数名：txtInformation_KeyUp
    '機　能：共通ﾃｷｽﾄ欄　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/03/05 (Wed) 11:26:47 N.Kojima
    '更新日：2008/03/05 (Wed) 11:26:47
    '備　考：
    Private Sub txtInformation_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtInformation.KeyUp

        Try

            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtInformation, CMlngMaxDisp3Row, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInformation_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub
    '@↑2008/03/05 (Wed) 11:26:38 N.Kojima **************************************************

    '@↓2008/03/05 (Wed) 11:23:09 N.Kojima **************************************************
    '関数名：txtInformation_MouseUp
    '機　能：共通ﾃｷｽﾄ欄　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/03/05 (Wed) 11:23:23 N.Kojima
    '更新日：2008/03/05 (Wed) 11:23:23
    '備　考：
    Private Sub txtInformation_MouseUp(ByVal sender As Object, ByVal e As EventArgs) Handles txtInformation.MouseUp

        Try

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtInformation, CMlngMaxDisp3Row, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInformation_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/05 (Wed) 11:23:09 N.Kojima **************************************************

    '@↓2008/03/05 (Wed) 11:22:57 N.Kojima **************************************************
    '関数名：cmdUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 12:46:59 N.Kojima
    '更新日：2008/03/05 (Wed) 11:23:01 N.Kojima
    '備　考：
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@=======================
            '@　ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP処理
            '@=======================
            Call pubtxtCmdUp_Proc(txtInformation, CMlngMaxDisp3Row, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/05 (Wed) 11:22:57 N.Kojima **************************************************

    '@↓2008/03/05 (Wed) 11:22:13 N.Kojima **************************************************
    '関数名：cmdDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 12:58:19 N.Kojima
    '更新日：2008/03/05 (Wed) 11:22:19 N.Kojima
    '備　考：
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown処理
            '@=======================
            Call pubtxtCmdDown_Proc(txtInformation, CMlngMaxDisp3Row, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/05 (Wed) 11:22:13 N.Kojima **************************************************

    '関数名：cmdEdit_Click
    '機　能：編集(修正)ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/17 (Wed) 11:35:02 N.Kojima
    '更新日：2008/01/18 (Fri) 11:52:32 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 11:52:32 N.Kojima     計画保全対応。選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝに応じ、処理を分岐。(案件№02332)
    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click

        Dim ltypEqStopMenteRenkeiInfo   As EqStopMenteRenkeiInfo    '装置停止・ﾒﾝﾃ計画引継ぎ構造体初期化用
        Dim ltypRepairInfo              As RepairInfo               '故障修理記録引継ぎ構造体初期化用
        Dim ltypPreserveInfo            As PreserveInfo             '保全記録引継ぎ構造体初期化用

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case mlngOptSelectFlag
                
                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                Case CPlngNumZero

                    '@引継構造体の初期化
                    ptypEqStopMenteRenkeiInfo = ltypEqStopMenteRenkeiInfo
                    
                    '@引継ぎ構造体に情報をｾｯﾄ
                    With vsfMainteList
                        ptypEqStopMenteRenkeiInfo.strWpID = _
                            .GetData(.Row, CMlngvsfMntColWPID)             '装置ID
                        ptypEqStopMenteRenkeiInfo.strWpName = _
                            .GetData(.Row, CMlngvsfMntColWPName)           '装置名
                        ptypEqStopMenteRenkeiInfo.strCategoryID = _
                            .GetData(.Row, CMlngvsfMntColCategoryID)       'ｶﾃｺﾞﾘID
                        ptypEqStopMenteRenkeiInfo.strCategoryName = _
                            .GetData(.Row, CMlngvsfMntColCategoryName)     'ｶﾃｺﾞﾘ名
                        ptypEqStopMenteRenkeiInfo.strWPStopStart = _
                            .GetData(.Row, CMlngvsfMntColStartDate)        '開始(予定)日時
                        ptypEqStopMenteRenkeiInfo.strWPStopEnd = _
                            .GetData(.Row, CMlngvsfMntColEndDate)          '終了(予定)日時
                        ptypEqStopMenteRenkeiInfo.strWPStopStartOld = _
                            .GetData(.Row, CMlngvsfMntColStartDate)        '旧開始(予定)日時
                        ptypEqStopMenteRenkeiInfo.strWPStopEndOld = _
                            .GetData(.Row, CMlngvsfMntColEndDate)          '旧終了(予定)日時
                        ptypEqStopMenteRenkeiInfo.strStopTime = _
                            .GetData(.Row, CMlngvsfMntColDuration)         '停止時間
                        ptypEqStopMenteRenkeiInfo.strComments = _
                            .GetData(.Row, CMlngvsfMntColCommentsAll)      '停止ｺﾒﾝﾄ(全文)
                        ptypEqStopMenteRenkeiInfo.strEditTime = _
                            .GetData(.Row, CMlngvsfMntColEditTimeV)        '最終更新日時
                        ptypEqStopMenteRenkeiInfo.strEntryTime = _
                            .GetData(.Row, CMlngvsfMntColEntryTime)        '登録日時
                        
                            
                        '@計画ﾃﾞｰﾀか(=ｶﾃｺﾞﾘIDが"0:ﾒﾝﾃ計画")
                        If .GetData(.Row, CMlngvsfMntColCategoryID) = CPstrZero Then
                            '@計画ﾃﾞｰﾀの場合
                            ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngUpdateMode           '3:計画ﾃﾞｰﾀ修正ﾓｰﾄﾞ
                        Else
                            '@実績ﾃﾞｰﾀの場合
                            ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngResultUpdateMode     '5:実績ﾃﾞｰﾀ修正ﾓｰﾄﾞ
                        End If
                    End With
                
                
                '@〓 故障修理記録 〓
                Case CPlngNumOne
                
                    '@引継構造体の初期化
                    ptypRepairInfo = ltypRepairInfo
                    
                    '@引継ぎ構造体に情報をｾｯﾄ
                    With vsfMainteList
                        ptypRepairInfo.strRepairNo = .GetData(.Row, CMlngvsfRepColRepairNo)    '故障修理記録№
                        ptypRepairInfo.strWpID = .GetData(.Row, CMlngvsfRepColWPID)            '装置ID
                        ptypRepairInfo.strWpName = .GetData(.Row, CMlngvsfRepColWPName)        '装置名
                        ptypRepairInfo.strSbID = pstrSBID                                      'SBID
                    End With

                
                '@〓 保全記録 〓
                Case CPlngNumTwo
                
                    '@引継構造体の初期化
                    ptypPreserveInfo = ltypPreserveInfo
                    
                    '@引継ぎ構造体に情報をｾｯﾄ
                    With vsfMainteList
                        ptypPreserveInfo.strPreserveNo = .GetData(.Row, CMlngvsfPreColPreserveNo)      '保全記録№
                        ptypPreserveInfo.strWpID = .GetData(.Row, CMlngvsfPreColWpID)                  '装置ID
                        ptypPreserveInfo.strWpName = .GetData(.Row, CMlngvsfPreColWpName)              '装置名
                        ptypPreserveInfo.strCategoryID = .GetData(.Row, CMlngvsfPreColCategoryID)      'ｶﾃｺﾞﾘID
                        ptypPreserveInfo.strCategoryName = .GetData(.Row, CMlngvsfPreColCategoryName)  'ｶﾃｺﾞﾘ名
                        ptypPreserveInfo.strSbID = pstrSBID                                            'SBID
                    End With

                
            End Select
            
            '@選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝが"装置停止・ﾒﾝﾃ計画"か
            If mlngOptSelectFlag = CPlngNumZero Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　装置停止・ﾒﾝﾃ計画修正画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxEN01Z1.Instance = New frmxxEN01Z1()

                '@Form_LoadﾌﾗｸﾞがFalse(起動失敗)か
                If pblnFormLoad = False Then

                    '@∇∇∇∇∇∇∇∇∇
                    '@　ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇
                    frmxxEN01Z1.Instance = Nothing

                    Exit Sub
                End If
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　装置停止・ﾒﾝﾃ計画修画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxEN01Z1.Instance.ShowDialog(Me)
                frmxxEN01Z1.Instance = Nothing
            
                '@引継構造体の初期化
                ptypEqStopMenteRenkeiInfo = ltypEqStopMenteRenkeiInfo
                
            Else
                '@故障修理記録 or 保全記録の場合
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　装置ﾒﾝﾃﾅﾝｽ記録票画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM00Z0.Instance = New frmxxCM00Z0()
                
                '@Form_LoadﾌﾗｸﾞがFalse(起動失敗)か
                If pblnFormLoad = False Then
                
                    '@∇∇∇∇∇∇∇∇∇
                    '@　ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇
                    frmxxCM00Z0.Instance = Nothing
                    
                    Exit Sub
                End If
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　装置ﾒﾝﾃﾅﾝｽ記録票画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM00Z0.Instance.ShowDialog(Me)
                frmxxCM00Z0.Instance = Nothing
            
                '@引継構造体の初期化
                ptypRepairInfo = ltypRepairInfo             '故障修理記録用
                ptypPreserveInfo = ltypPreserveInfo         '保全記録用

            End If
            
            '@=======================
            '@　最新情報取得処理
            '@=======================
            Call cmdSearch_Click(cmdSearch,New EventArgs)
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ選択処理
            '@=======================
            Call vsfMainteList_RowColChange(vsfMainteList,New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEdit_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdApprove_Click
    '機　能：承認ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/05 (Mon) 08:38:45 N.Kojima
    '更新日：2008/01/18 (Fri) 12:01:09 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 12:01:09 N.Kojima     計画保全対応。承認ﾁｪｯｸをFunction化等。(案件№02332)
    Private Sub cmdApprove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdApprove.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEditTime            As String               '更新日時
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　承認ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvApprove_Chk
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN01Z0             '機能ID: EN01Z0
            lstrActionID = CPstrApply                   'ｱｸｼｮﾝID：装置ﾒﾝﾃﾅﾝｽ記録票承認
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdApproveClick)

            Me.KeyPreview = False
            
            '@=======================
            '@　実行権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                       lstrActionID, _
                                       lstrEmpID, _
                                       lstrEmpName, _
                                       lstrSBID)
                                       
            Me.KeyPreview = True
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdApproveClick)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrApply)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If
            
            With vsfMainteList
            
                '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐　※各記録票を更新 ★
                Select Case mlngOptSelectFlag
                    
                    '@〓 "1:故障修理記録" 〓
                    Case CPlngNumOne
                    
                        '@************************************
                        '@　要求ﾃﾞｰﾀ作成(故障修理記録票更新用)
                        '@************************************
                        mtypChgRepairInfoReq.strSbID = pstrSBID                                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                        mtypChgRepairInfoReq.strMsgVer = CMstrrep_chgrepairreportVer                        'ﾒｯｾｰｼﾞVer
                        mtypChgRepairInfoReq.strEmpID = pstrUserID                                          '作業者ID(更新者ID)
                        mtypChgRepairInfoReq.strEmpName = pstrUserName                                      '作業者名(更新者名)
                        mtypChgRepairInfoReq.strActionID = CPstrTwo                                         'ｱｸｼｮﾝID(2:更新)
                        mtypChgRepairInfoReq.strRepairNo = .GetData(.Row, CMlngvsfRepColRepairNo)           '故障修理記録票№
                        mtypChgRepairInfoReq.strWpID = .GetData(.Row, CMlngvsfRepColWPID)                   '装置ID
                        mtypChgRepairInfoReq.strRepairStatus = CPstrTwo                                     '故障修理記録票状態(2:承認済みを送信)
                        mtypChgRepairInfoReq.strRepairName = _
                            .GetData(.Row, CMlngvsfRepColAllRepairName)                                     '故障現象名(全文)
                        mtypChgRepairInfoReq.strRepairContents = _
                            .GetData(.Row, CMlngvsfRepColRepairContents)                                    '故障現象詳細
                        mtypChgRepairInfoReq.strRepairAnalysisContents = _
                            .GetData(.Row, CMlngvsfRepColRepairAnalysisContents)                            '調査/分析詳細
                        mtypChgRepairInfoReq.strRepairCauseContents = _
                            .GetData(.Row, CMlngvsfRepColRepairCauseContents)                               '原因詳細
                        mtypChgRepairInfoReq.strRepairMeasureContents = _
                            .GetData(.Row, CMlngvsfRepColRepairMeasureContents)                             '対策詳細
                        mtypChgRepairInfoReq.strApprovalEmpID = pstrUserID                                  '承認者ID
                        mtypChgRepairInfoReq.strApprovalEmpName = pstrUserName                              '承認者名
                        mtypChgRepairInfoReq.strEditTime = .GetData(.Row, CMlngvsfRepColEditTime)           '更新日時

                        Me.KeyPreview = False
                        
                        '@【故障修理記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                        lblnAns = pubblnRepChgRepairReport_Upd(mtypChgRepairInfoReq, _
                                                               lstrEditTime, _
                                                               vbNullString, _
                                                               CPstrOne)

                        Me.KeyPreview = True
                        
                        '@通信結果判定
                        If lblnAns = False Then
                            '@結果：異常の場合
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmdApproveClick)
                            Exit Sub
                        End If
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdApproveClick)
                    
                        '@ﾒｯｾｰｼﾞを表示する
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrRepairTitle, CMstrApplyMsg, _
                                                        .GetData(.Row, CMlngvsfRepColRepairNo))


                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo
                    
                        '@************************************
                        '@　要求ﾃﾞｰﾀ作成(保全記録票更新用)
                        '@************************************
                        mtypChgPreserveInfoReq.strSbID = pstrSBID                               'ｼｽﾃﾑﾌﾞﾛｯｸID
                        mtypChgPreserveInfoReq.strMsgVer = CMstrpre_chgpreservereportVer        'ﾒｯｾｰｼﾞVer
                        mtypChgPreserveInfoReq.strEmpID = pstrUserID                            '作業者ID(更新者ID)
                        mtypChgPreserveInfoReq.strEmpName = pstrUserName                        '作業者名(更新者名)
                        mtypChgPreserveInfoReq.strActionID = CPstrTwo                           'ｱｸｼｮﾝID(2:更新)
                        mtypChgPreserveInfoReq.strPreserveStatus = CPstrTwo                     '保全記録票状態(2:承認済みを送信)
                        mtypChgPreserveInfoReq.strApprovalEmpID = pstrUserID                    '承認者ID
                        mtypChgPreserveInfoReq.strApprovalEmpName = pstrUserName                '承認者名
                        mtypChgPreserveInfoReq.strPreserveNo = _
                            .GetData(.Row, CMlngvsfPreColPreserveNo)                            '保全記録票№
                        mtypChgPreserveInfoReq.strWpID = _
                            .GetData(.Row, CMlngvsfPreColWpID)                                  '装置ID
                        mtypChgPreserveInfoReq.strCategoryID = _
                            .GetData(.Row, CMlngvsfPreColCategoryID)                            'ｶﾃｺﾞﾘID
                        mtypChgPreserveInfoReq.strUseId = _
                            .GetData(.Row, CMlngvsfPreColCategoryID)                            'ｶﾃｺﾞﾘID(USE_ID)
                        mtypChgPreserveInfoReq.strPreserveCategory = _
                            .GetData(.Row, CMlngvsfPreColPreserveCategoryID)                    '保全ｶﾃｺﾞﾘID
                        mtypChgPreserveInfoReq.strPreserveItem = _
                            .GetData(.Row, CMlngvsfPreColPreserveItemAll)                       '実施項目
                        mtypChgPreserveInfoReq.strPreserveContents = _
                            .GetData(.Row, CMlngvsfPreColPreserveContents)                      '実施内容
                        mtypChgPreserveInfoReq.strPreservePurpose = _
                            .GetData(.Row, CMlngvsfPreColPreservePurpose)                       '実施理由/目的
                        mtypChgPreserveInfoReq.strEditTime = _
                            .GetData(.Row, CMlngvsfPreColEditTime)                              '更新日時

                        Me.KeyPreview = False
                        
                        '@【保全記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                        lblnAns = pubblnPreChgPreserveReport_Upd(mtypChgPreserveInfoReq, _
                                                                 lstrEditTime, _
                                                                 vbNullString, _
                                                                 CPstrOne)

                        Me.KeyPreview = True
                        
                        '@通信結果判定
                        If lblnAns = False Then
                            '@結果：異常の場合
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmdApproveClick)
                            Exit Sub
                        End If
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdApproveClick)
                    
                        '@ﾒｯｾｰｼﾞを表示する
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrPreserveTitle, CMstrApplyMsg, _
                                                        .GetData(.Row, CMlngvsfPreColPreserveNo))
                        
                End Select
            
            End With
                    
            '@成功ﾒｯｾｰｼﾞ表示
            '@pubVsfInfo_Disp("<TRM6QI>$$%1を[%2:承認]しました。%1№[%3]")
            Call pubVsfInfo_Disp(pstrDMsg)

            '@=======================
            '@　最新情報取得処理
            '@=======================
            Call cmdSearch_Click(cmdSearch,New EventArgs)
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ行/列選択処理
            '@=======================
            Call vsfMainteList_RowColChange(vsfMainteList,New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdApprove_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDiscon_Click
    '機　能：破棄(削除)ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/05 (Mon) 10:17:11 N.Kojima
    '更新日：2008/01/18 (Fri) 16:40:10 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 16:40:10 N.Kojima     計画保全対応。選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより破棄Msgの送信内容を変更。(案件№02332)
    Private Sub cmdDiscon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDiscon.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEditTime            As String               '更新日時
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@装置停止・ﾒﾝﾃ計画が選択されているか
            If mlngOptSelectFlag = CPlngNumZero Then
                '@装置停止・ﾒﾝﾃ計画が選択されている場合

                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            
                '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                If pblnCancel = True Then
                    Exit Sub
                End If
            Else
                '@故障修理 or 保全記録が選択されている場合
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
            
                '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                If pblnCancel = True Then
                    Exit Sub
                End If
                
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN01Z0             '機能ID: EN01Z0
                lstrActionID = CPstrDiscon                  'ｱｸｼｮﾝID：装置ﾒﾝﾃﾅﾝｽ記録票破棄
                lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdDisconClick)

                Me.KeyPreview = False
                
                '@=======================
                '@　実行権限ﾁｪｯｸ処理
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           lstrEmpID, _
                                           lstrEmpName, _
                                           lstrSBID)

                Me.KeyPreview = True
                
                '@処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdDisconClick)
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CMstrDisconMsg)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。$処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                    Exit Sub
                End If
            End If
            
            With vsfMainteList

                '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐　※各記録票を更新 ★
                Select Case mlngOptSelectFlag

                    '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                    Case CPlngNumZero
                    
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        Call pubResponseStart(CMstrFormName, CMstrCmdDisconClick)
                    
                        '@************************************
                        '@　要求ﾃﾞｰﾀ作成(装置停止・ﾒﾝﾃ計画用)
                        '@************************************
                        mtypEqStopMenteReq.strSbID = pstrSBID                       'ｼｽﾃﾑﾌﾞﾛｯｸID
                        mtypEqStopMenteReq.strMsgVer = CMstreq__schwpmentechgVer    'ﾒｯｾｰｼﾞVer
                        mtypEqStopMenteReq.strClassDivision = CPstrCD05             '処理区分(05:削除)
                        mtypEqStopMenteReq.strEmpID = pstrUserID                    '作業者ID
                        mtypEqStopMenteReq.strWpID = .GetData(.Row, CMlngvsfMntColWPID)            '装置ID

                        If IsDate(.GetData(.Row, CMlngvsfMntColStartDate)) THen     '旧開始予定日時(秒まで表記)
                            mtypEqStopMenteReq.strWPStopStartOld = _
                                Format$(CDate(.GetData(.Row, CMlngvsfMntColStartDate)), CPstrDateTimeYMDHMS)  
                        Else
                            mtypEqStopMenteReq.strWPStopStartOld = _
                                .GetData(.Row, CMlngvsfMntColStartDate)
                        End If

                        If IsDate(.GetData(.Row, CMlngvsfMntColStartDate)) THen     '開始予定日時(秒まで表記)
                            mtypEqStopMenteReq.strWPStopStart = _
                                Format$(CDate(.GetData(.Row, CMlngvsfMntColStartDate)), CPstrDateTimeYMDHMS)  
                        Else
                            mtypEqStopMenteReq.strWPStopStart = _
                                .GetData(.Row, CMlngvsfMntColStartDate)
                        End If

                        If IsDate(.GetData(.Row, CMlngvsfMntColEndDate)) THen       '終了予定日時(秒まで表記)
                            mtypEqStopMenteReq.strWPStopEnd = _
                                Format$(CDate(.GetData(.Row, CMlngvsfMntColEndDate)), CPstrDateTimeYMDHMS)    
                        Else
                            mtypEqStopMenteReq.strWPStopEnd = _
                                .GetData(.Row, CMlngvsfMntColEndDate)
                        End If
                        '@停止方法
                        Select Case .GetData(.Row, CMlngvsfMntColStopRule)
                            Case CMstrStopRule1
                                mtypEqStopMenteReq.strWPStopRule = CMlngStopRule1   '強制
                            Case CMstrStopRule3
                                mtypEqStopMenteReq.strWPStopRule = CMlngStopRule3   'ﾛｯﾄ優先
                            Case Else
                                mtypEqStopMenteReq.strWPStopRule = 0
                        End Select

                        mtypEqStopMenteReq.strWPStopComments = _
                            .GetData(.Row, CMlngvsfMntColComments)         '停止ｺﾒﾝﾄ
                        mtypEqStopMenteReq.strEditTime = _
                            .GetData(.Row, CMlngvsfMntColEditTimeV)        '最終更新日時
                        
                        '@実績ﾃﾞｰﾀ選択の際には、削除ﾎﾞﾀﾝは無効だが一応処理を追加しておく
                        mtypEqStopMenteReq.strEntryTime = _
                            .GetData(.Row, CMlngvsfMntColEntryTime)        '登録日時
                        mtypEqStopMenteReq.strCategoryID = _
                            .GetData(.Row, CMlngvsfMntColCategoryID)       'ｶﾃｺﾞﾘID

                        Me.KeyPreview = False

                        '@【装置停止・ﾒﾝﾃ計画登録・更新・削除】ﾒｯｾｰｼﾞ送受信処理
                        lblnAns = pubblnEqStopMente_Upd(mtypEqStopMenteReq)

                        Me.KeyPreview = True
                        
                        '@通信結果判定
                        If lblnAns = False Then
                            '@結果：異常の場合
                    
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmdDisconClick)
                            Exit Sub
                        End If
                    
                        '@装置停止・ﾒﾝﾃ計画登録連携情報のｸﾘｱ
                        With ptypEqStopMenteRenkeiInfo
                            .lngInsertMode = 0                      '登録ﾓｰﾄﾞなし
                            .strWpID = vbNullString                 '装置ID
                            .strWPStopStartOld = vbNullString       '旧開始予定日時(計画/実績)
                            .strWPStopStart = vbNullString          '開始予定日時(計画/実績)
                            .strEditTime = vbNullString             '最終更新日時
                        End With
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdDisconClick)
                    
                        '@表示ﾒｯｾｰｼﾞ変換("<TRM5GI>$$メンテ計画を%1しました。装置[%2]、開始予定日時[%3]")
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005G, CMstrDeleteMsg, _
                                                        .GetData(.Row, CMlngvsfMntColWPName), _
                                                        .GetData(.Row, CMlngvsfMntColStartDate))
                    
                    
                    
                    '@〓 "1:故障修理記録" 〓
                    Case CPlngNumOne
                    
                        '@************************************
                        '@　要求ﾃﾞｰﾀ作成(故障修理記録票更新用)
                        '@************************************
                        mtypChgRepairInfoReq.strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                        mtypChgRepairInfoReq.strMsgVer = CMstrrep_chgrepairreportVer        'ﾒｯｾｰｼﾞVer
                        mtypChgRepairInfoReq.strEmpID = pstrUserID                          '作業者ID(更新者ID)
                        mtypChgRepairInfoReq.strEmpName = pstrUserName                      '作業者名(更新者名)
                        mtypChgRepairInfoReq.strActionID = CPstrTwo                         'ｱｸｼｮﾝID(2:更新)
                        mtypChgRepairInfoReq.strRepairStatus = CPstrThree                   '故障修理記録票状態(3:破棄を送信)
                        mtypChgRepairInfoReq.strRepairNo = _
                            .GetData(.Row, CMlngvsfRepColRepairNo)                 '故障修理記録票№
                        mtypChgRepairInfoReq.strWpID = _
                            .GetData(.Row, CMlngvsfRepColWPID)                     '装置ID
                        mtypChgRepairInfoReq.strEditTime = _
                            .GetData(.Row, CMlngvsfRepColEditTime)                 '更新日時

                        Me.KeyPreview = False
                        
                        '@【故障修理記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                        lblnAns = pubblnRepChgRepairReport_Upd(mtypChgRepairInfoReq, lstrEditTime)

                        Me.KeyPreview = True
                        
                        '@通信結果判定
                        If lblnAns = False Then
                            '@結果：異常の場合
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmdDisconClick)
                            Exit Sub
                        End If
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdDisconClick)
                        
                        '@ﾒｯｾｰｼﾞを表示する
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrRepairTitle, CMstrDisconMsg, _
                                                        vsfMainteList.GetData(vsfMainteList.Row, CMlngvsfRepColRepairNo))
                    
                    
                    
                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo
                    
                        '@************************************
                        '@　要求ﾃﾞｰﾀ作成(保全記録票更新用)
                        '@************************************
                        mtypChgPreserveInfoReq.strSbID = pstrSBID                           'ｼｽﾃﾑﾌﾞﾛｯｸID
                        mtypChgPreserveInfoReq.strMsgVer = CMstrpre_chgpreservereportVer    'ﾒｯｾｰｼﾞVer
                        mtypChgPreserveInfoReq.strEmpID = pstrUserID                        '作業者ID(更新者ID)
                        mtypChgPreserveInfoReq.strEmpName = pstrUserName                    '作業者名(更新者名)
                        mtypChgPreserveInfoReq.strActionID = CPstrTwo                       'ｱｸｼｮﾝID(2:更新)
                        mtypChgPreserveInfoReq.strPreserveStatus = CPstrThree               '保全記録票状態(3:破棄を送信)
                        mtypChgPreserveInfoReq.strPreserveNo = _
                            .GetData(.Row, CMlngvsfPreColPreserveNo)               '保全記録票№
                        mtypChgPreserveInfoReq.strWpID = _
                            .GetData(.Row, CMlngvsfPreColWpID)                     '装置ID
                        mtypChgPreserveInfoReq.strUseId = _
                            .GetData(.Row, CMlngvsfPreColCategoryID)               'ｶﾃｺﾞﾘID
                        mtypChgPreserveInfoReq.strEditTime _
                            = .GetData(.Row, CMlngvsfPreColEditTime)               '更新日時
    
                        Me.KeyPreview = False
                        
                        '@【保全記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                        lblnAns = pubblnPreChgPreserveReport_Upd(mtypChgPreserveInfoReq, lstrEditTime)

                        Me.KeyPreview = True
                        
                        '@通信結果判定
                        If lblnAns = False Then
                            '@結果：異常の場合
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmdDisconClick)
                            Exit Sub
                        End If
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdDisconClick)
                        
                        '@ﾒｯｾｰｼﾞを表示する
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrPreserveTitle, CMstrDisconMsg, _
                                                        .GetData(.Row, CMlngvsfPreColPreserveNo))

                End Select
            End With

            '@成功ﾒｯｾｰｼﾞ表示
            '@　①装置停止・ﾒﾝﾃ計画     ："<TRM5GI>$$メンテ計画を%1しました。装置[%2]、開始予定日時[%3]"
            '@　②故障修理 or 保全記録  ："<TRM6QI>$$%1を[%2:破棄]しました。%1№[%3]")
            Call pubVsfInfo_Disp(pstrDMsg)

            '@=======================
            '@　最新情報取得処理
            '@=======================
            Call cmdSearch_Click(cmdSearch,New EventArgs)
            
            '@ﾌｫｰｶｽをﾀｲﾄﾙへ
            vsfMainteList.Row = 0
            
            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDiscon_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMailSend_Click
    '機　能：確認依頼ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/05 (Mon) 10:33:37 N.Kojima
    '更新日：2008/01/18 (Fri) 16:40:10 N.Kojima
    '備　考：
    '　　　：2008/01/18 (Fri) 16:40:10 N.Kojima     計画保全対応。選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより確認依頼Msgの送信内容を変更。(案件№02332)
    Private Sub cmdMailSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMailSend.Click

        Dim ltypWorkFlow            As WorkFlow             '初期化用構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrMsg                 As String               'ﾒｯｾｰｼﾞ内容格納
        Dim lstrMailSendTitle       As String               'ﾒｰﾙﾀｲﾄﾙ
        Dim lstrMailContentsTitle   As String               'ﾒｰﾙ内容ﾀｲﾄﾙ
        Dim lstrMailContents        As String               'ﾒｰﾙ内容(故障現象名or実施項目)
        Dim lstrMailWP              As String               'ﾒｰﾙ内容(装置)

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@故障修理記録票、保全記録票確認依頼用情報格納構造体の初期化
            ptypWorkFlow = ltypWorkFlow
            
            '@確認依頼情報を格納
            With vsfMainteList
                
                '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐　※ｾｯﾄ内容を変える ★
                '@　　※装置停止・ﾒﾝﾃ計画選択時は確認依頼ﾎﾞﾀﾝが無効なので、下記に処理は無し
                Select Case mlngOptSelectFlag
                    
                    '@〓 "1:故障修理記録" 〓
                    Case CPlngNumOne
                        
                        '@故障修理記録№
                        ptypWorkFlow.strReportNo = .GetData(.Row, CMlngvsfRepColRepairNo)
                        '@装置ID
                        ptypWorkFlow.strWpID = .GetData(.Row, CMlngvsfRepColWPID)
                        
                        '@ﾒｰﾙ関連のｾｯﾄ(故障修理記録票)
                        lstrMailSendTitle = CPstrMailSendTitleRepair                            'ﾒｰﾙﾀｲﾄﾙ
                        lstrMailContentsTitle = CPstrMailRepairName                             'ﾒｰﾙ内容ﾀｲﾄﾙ
                        lstrMailContents = .GetData(.Row, CMlngvsfRepColAllRepairName)          'ﾒｰﾙ内容
                        lstrMailWP = .GetData(.Row, CMlngvsfRepColWPName)                       '装置名
                    
                    
                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo
                        
                        '@保全記録№
                        ptypWorkFlow.strReportNo = .GetData(.Row, CMlngvsfPreColPreserveNo)
                        '@装置ID
                        ptypWorkFlow.strWpID = .GetData(.Row, CMlngvsfPreColWpID)
                        
                        '@ﾒｰﾙﾀｲﾄﾙのｾｯﾄ(保全記録票)
                        lstrMailSendTitle = CPstrMailSendTitlePreserve                              'ﾒｰﾙﾀｲﾄﾙ
                        lstrMailContentsTitle = CPstrMailPreserveItemName                           'ﾒｰﾙ内容
                        lstrMailContents = .GetData(.Row, CMlngvsfPreColPreserveItemAll)            'ﾒｰﾙ内容
                        lstrMailWP = .GetData(.Row, CMlngvsfPreColWpName)                           '装置名
                        
                End Select
                
                '@起動SB
                ptypWorkFlow.strSbID = pstrSBID
            End With
            
            '@***********************
            '@　ﾒｰﾙ送信要求ﾃﾞｰﾀ作成
            '@***********************
            With ptypMailInfo
            
                '@初期化
                .strMailContents = vbNullString     'ﾒｰﾙ内容
                .strMailSubject = vbNullString      'ﾒｰﾙｻﾌﾞｼﾞｪｸﾄ
                
                If ptypSendMailList.typSendMail Is Nothing Then
                    ptypSendMailList.typSendMail = New List(Of SendMail)
                Else
                    ptypSendMailList.typSendMail.Clear
                End If
                ptypSendMailList.lngSendMailCnt = 0
                    
                '@ﾒｰﾙ内容格納
                '@件名文字列作成(ﾒｰﾙﾀｲﾄﾙ + 確認依頼 + %1(引数) + 記録票№)
                .strMailSubject = lstrMailSendTitle & _
                                  Replace(CPstrMailSubjectReport, "%1", ptypWorkFlow.strReportNo)
                
                '@##########ﾒｰﾙ本文固定表記##########
                '@送信者        ：XXXXXXXXXX
                '@発行№        ：XXXXXXXXXX
                '@故障現象名    ：XXXXXXXXXX
                '@(実施項目)    ：XXXXXXXXXX
                '@対象装置      ：XXXXXXXXXX
                '@##########ﾒｰﾙ本文固定表記##########
                '@本文文字列作成
                .strMailContents = CPstrMailReportNo & ptypWorkFlow.strReportNo & vbCrLf & _
                                   lstrMailContentsTitle & lstrMailContents & vbCrLf & _
                                   CPstrMailWP & lstrMailWP
            End With
            
            '@引継起動ﾌﾗｸﾞの設定
            pblnfrmxxEN01Z0kbn = True
            pblnfrmxxEN0050kbn = False
            pblnfrmxxEN00V0kbn = False
            pblnfrmxxCM00Z0kbn = False
            
            '@引継処理ﾌﾗｸﾞの初期化
            plngfrmxxCM00S0Kbn = 0
            
            '@起動ﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ﾒｰﾙ送信画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00S0.Instance = New frmxxCM00S0()
            
            '@処理結果判定
            If pblnFormLoad = True Then
                '@結果：正常の場合
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾒｰﾙ送信画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM00S0.Instance.ShowDialog(Me)
                frmxxCM00S0.Instance = Nothing
            Else
                '@結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxCM00S0.Instance = Nothing
                
                '@引継起動ﾌﾗｸﾞの初期化
                pblnfrmxxEN01Z0kbn = False
                pblnfrmxxEN0050kbn = False
                pblnfrmxxEN00V0kbn = False
                pblnfrmxxCM00Z0kbn = False
                
                '@引継処理ﾌﾗｸﾞの初期化
                plngfrmxxCM00S0Kbn = 0
                
                '@起動ﾌﾗｸﾞを戻す
                pblnFormLoad = True
                
                Exit Sub
            End If
            
            '@★ 引継処理ﾌﾗｸﾞの戻り値により処理分岐 ★
            Select Case plngfrmxxCM00S0Kbn
                
                '@〓 起動成功＆ﾒｰﾙ送信成功 〓
                Case CPlngNumTwo
                    
                    '@*********************
                    '@　ﾜｰｸﾌﾛｰ要求ﾃﾞｰﾀ作成
                    '@*********************
                    ptypWorkFlow.strMsgVer = CMstrrep_registworkflowVer     'ﾒｯｾｰｼﾞVer
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdMailSendClick)
                    
                    Me.KeyPreview = False
                    
                    '@【ﾜｰｸﾌﾛｰ登録】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnRepRegistWorkFlow_Ins(ptypWorkFlow)

                    Me.KeyPreview = True
                    
                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdMailSendClick)
                        
                        Exit Sub
                    End If

                    Me.KeyPreview = False
                    
                    '@【ﾒｰﾙ送信】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnGuidSendMessage_Sel(ptypSendMessageList)

                    Me.KeyPreview = True
                    
                    '@通信結果取得
                    If lblnAns = True Then
                        '@結果：正常の場合
                        
                        '@表示ﾒｯｾｰｼﾞ変換("<TRM4SI>$$メールの送信を受け付けました。")
                        lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf004S)
                        '@ﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(lstrMsg)
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdMailSendClick)
                    
                        '@=======================
                        '@　最新情報取得処理
                        '@=======================
                        Call cmdSearch_Click(cmdSearch,New EventArgs)
                    End If

                '@〓 以下の場合 〓
                '@ ①ﾒｰﾙ送信画面起動失敗
                '@ ②画面起動成功だがﾒｰﾙ送信画面で確定せずに閉じた
                '@ ③その他
                Case Else

                    '@処理なし

            End Select

            '@引継起動ﾌﾗｸﾞの初期化
            pblnfrmxxEN01Z0kbn = False
            pblnfrmxxEN0050kbn = False
            pblnfrmxxEN00V0kbn = False
            pblnfrmxxCM00Z0kbn = False
            
            '@引継処理ﾌﾗｸﾞの初期化
            plngfrmxxCM00S0Kbn = 0
            
            '@起動ﾌﾗｸﾞを戻す
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMailSend_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/18 (Fri) 11:46:40 N.Kojima **************************************************
    '関数名：cmdCopyInsert_Click
    '機　能：ｺﾋﾟｰ登録ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/18 (Fri) 11:47:42 N.Kojima
    '更新日：2008/01/18 (Fri) 11:47:42
    '備　考：
    Private Sub cmdCopyInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopyInsert.Click

        Dim llngCnt                     As Integer                  '汎用ｶｳﾝﾀ
        Dim ltypEqStopMenteRenkeiInfo   As EqStopMenteRenkeiInfo    '

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継構造体の初期化
            ptypEqStopMenteRenkeiInfo = ltypEqStopMenteRenkeiInfo
                    
            '@引継ぎ構造体に情報をｾｯﾄ
            With vsfMainteList

                ptypEqStopMenteRenkeiInfo.strMcGroupID = cmbMcGroup.Value       '装置ｸﾞﾙｰﾌﾟID
                ptypEqStopMenteRenkeiInfo.strMcGroupName = cmbMcGroup.Text      '装置ｸﾞﾙｰﾌﾟ名
                ptypEqStopMenteRenkeiInfo.strWpID = _
                    .GetData(.Row, CMlngvsfMntColWPID)                          '装置ID
                ptypEqStopMenteRenkeiInfo.strWpName = _
                    .GetData(.Row, CMlngvsfMntColWPName)                        '装置名
                ptypEqStopMenteRenkeiInfo.strCategoryID = _
                    .GetData(.Row, CMlngvsfMntColCategoryID)                    'ｶﾃｺﾞﾘID
                ptypEqStopMenteRenkeiInfo.strCategoryName = _
                    .GetData(.Row, CMlngvsfMntColCategoryName)                  'ｶﾃｺﾞﾘ名
                ptypEqStopMenteRenkeiInfo.strWPStopStart = _
                    .GetData(.Row, CMlngvsfMntColStartDate)                     '開始(予定)日時
                ptypEqStopMenteRenkeiInfo.strWPStopEnd = _
                    .GetData(.Row, CMlngvsfMntColEndDate)                       '終了(予定)日時
                ptypEqStopMenteRenkeiInfo.strStopTime = _
                    .GetData(.Row, CMlngvsfMntColDuration)                      '停止時間
                ptypEqStopMenteRenkeiInfo.strComments = _
                    .GetData(.Row, CMlngvsfMntColCommentsAll)                   '停止ｺﾒﾝﾄ(全文)
                ptypEqStopMenteRenkeiInfo.strEditTime = _
                    .GetData(.Row, CMlngvsfMntColEditTimeV)                     '最終更新日時
                ptypEqStopMenteRenkeiInfo.strEntryTime = _
                    .GetData(.Row, CMlngvsfMntColEntryTime)                     '登録日時
                    
                ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngCopyInsertMode   'ｺﾋﾟｰ登録ﾓｰﾄﾞ
                
            End With
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　装置ﾒﾝﾃﾅﾝｽｺﾋﾟｰ登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN01Z1.Instance.ShowDialog(Me)
            frmxxEN01Z1.Instance = Nothing

            '@=======================
            '@　装置停止・ﾒﾝﾃ計画情報再取得処理
            '@=======================
            Call prvMainteInfo_Sel()
            
            '@ｸﾞﾘｯﾄﾞが有効な場合
            If vsfMainteList.Enabled = True Then
                '@一覧へﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfMainteList)
            Else
                '@検索ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdSearch)
            End If

            '@一覧、ｺﾒﾝﾄの使用可否
            If vsfMainteList.Rows.Count > 1 Then
                
                '@各種ｺﾝﾄﾛｰﾙを有効にする
                vsfMainteList.Enabled = True        '装置停止・ﾒﾝﾃ計画一覧
                
                '@登録画面から復帰時は一覧の該当ｵｰﾀﾞｰへﾌｫｰｶｽを設定
                If ptypEqStopMenteRenkeiInfo.strWpID <> vbNullString And _
                    ptypEqStopMenteRenkeiInfo.strWPStopStart <> vbNullString Then
                    
                    With vsfMainteList
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            '@ｸﾞﾘｯﾄﾞの装置ID＆開始(予定)日時と、子画面で登録した装置ID＆開始(予定)日時が同じか
                            If .GetData(llngCnt, CMlngvsfMntColWPID) = ptypEqStopMenteRenkeiInfo.strWpID And _
                                .GetData(llngCnt, CMlngvsfMntColStartDate) = ptypEqStopMenteRenkeiInfo.strWPStopStart Then
                                
                                '@同じ場合は、その行を選択
                                .Row = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                    End With
                End If
                
                '@ﾌｫｰｶｽ移動
                vsfMainteList.ShowCell(vsfMainteList.Row, CMlngvsfMntColWPName)
                
                '@=======================
                '@　ｶﾚﾝﾄ行ﾁｪｯｸ処理
                '@=======================
                Call vsfMainteList_RowColChange(vsfMainteList,New EventArgs)
            Else
                '@各種ｺﾝﾄﾛｰﾙの初期化
                vsfMainteList.Enabled = False           '装置停止・ﾒﾝﾃ計画一覧
                txtInformation.Text = vbNullString      '停止ｺﾒﾝﾄ
            End If

            '@装置停止・ﾒﾝﾃ計画登録連携情報のｸﾘｱ
            With ptypEqStopMenteRenkeiInfo
                .lngInsertMode = 0                      '登録ﾓｰﾄﾞなし
                .strWpID = vbNullString                 '装置ID
                .strWPStopStartOld = vbNullString       '旧開始予定日時(計画/実績)
                .strWPStopStart = vbNullString          '開始予定日時(計画/実績)
                .strEditTime = vbNullString             '最終更新日時
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCopyInsert_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/18 (Fri) 11:46:40 N.Kojima **************************************************

    '関数名：cmdNewEntry_Click
    '機　能：新規登録(登録)ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/09 (Fri) 16:44:12 N.Kojima
    '更新日：2008/01/28 (Mon) 08:57:46 N.Kojima
    '備　考：
    '　　　：2008/01/28 (Mon) 08:57:46 N.Kojima     計画保全対応。(案件№02332)
    Private Sub cmdNewEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNewEntry.Click

        Dim ltypEqStopMenteRenkeiInfo   As EqStopMenteRenkeiInfo    '装置停止・ﾒﾝﾃ計画引継ぎ構造体初期化用

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝが"0:装置停止・ﾒﾝﾃ計画"か
            If mlngOptSelectFlag = CPlngNumZero Then
            
                '@引継構造体の初期化
                ptypEqStopMenteRenkeiInfo = ltypEqStopMenteRenkeiInfo
                
                '@ﾓｰﾄﾞに"1:新規"をｾｯﾄする
                ptypEqStopMenteRenkeiInfo.lngInsertMode = CMlngInsertMode
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　新規登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN01Z1.Instance = New frmxxEN01Z1()
            
            '@Form_LoadﾌﾗｸﾞがFalse(起動失敗)か
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxEN01Z1.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　新規登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN01Z1.Instance.ShowDialog(Me)
            frmxxEN01Z1.Instance = Nothing
            
            '@検索ﾎﾞﾀﾝが有効か
            If cmdSearch.Enabled = True Then
            
                '@=======================
                '@　最新情報取得処理
                '@=======================
                Call cmdSearch_Click(cmdSearch,New EventArgs)
                
                '@=======================
                '@　ｸﾞﾘｯﾄﾞ選択処理
                '@=======================
                Call vsfMainteList_RowColChange(vsfMainteList,New EventArgs)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNewEntry_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCopy_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/24 (Thu) 12:51:38 N.Kojima
    '更新日：2008/01/24 (Thu) 12:51:38
    '備　考：EXCELに貼り付ける際に、ｾﾙの先頭の文字列が、
    '　　　：「－」、「＋」の場合は、自動計算されるので、罫線文字に置き換える
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click

        Dim llngRowCnt          As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt          As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRET             As String       'ｺﾋﾟｰ文字列
        Dim lstrWk              As String       '文字列編集
        Dim lstrLen             As Integer      '文字列長格納用
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim llngToEmpName       As Integer      '依頼先担当者名
        Dim llngLastCol         As Integer      '最終列名
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@Clipboardの内容を削除
            Clipboard.Clear
                
            '@一覧をｺﾋﾟｰする
            With vsfMainteList
                    
                '@行分ﾙｰﾌﾟ
                For llngRowCnt = 0 To .Rows.Count - 1
                        
                    '@列分ﾙｰﾌﾟ
                    For llngColCnt = 0 To .Cols.Count - 1
                            
                        '@対象列が非表示でないか
                        If .Cols(llngColCnt).Visible Then
                            
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = .GetDataDisplay(llngRowCnt, llngColCnt)
                                
                            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
                            Select Case mlngOptSelectFlag
                                
                                '@〓 "0:装置停止・ﾒﾝﾃ計画" 〓
                                Case CPlngNumZero
                                        
                                    '@ﾀｲﾄﾙ行じゃなく、停止ｺﾒﾝﾄ列の場合
                                    If llngColCnt = CMlngvsfMntColComments And llngRowCnt <> 0 Then
                                        '@停止ｺﾒﾝﾄ(全文)を格納
                                        lstrWk = Replace$(.GetDataDisplay(llngRowCnt, CMlngvsfMntColCommentsAll), vbCrLf, Space$(1))
                                    End If
                                        
                                    '@装置停止・ﾒﾝﾃ計画選択時の最終列を格納
                                    llngLastCol = CMlngvsfMntColStartDateMilli
                                    
                                    
                                '@〓 "1:故障修理記録" 〓
                                Case CPlngNumOne
                                        
                                    '@ﾀｲﾄﾙ行じゃなく、故障現象名(一部)列の場合
                                    If llngColCnt = CMlngvsfRepColRepairName And llngRowCnt <> 0 Then
                                        '@故障現象名(全文)を格納
                                            lstrWk = Replace$(.GetDataDisplay(llngRowCnt, CMlngvsfRepColAllRepairName), vbCrLf, Space$(1))
                                    End If
                                        
                                    '@故障修理選択時の依頼先担当者名列・最終列を格納
                                    llngToEmpName = CMlngvsfRepColToEmpName
                                    llngLastCol = CMlngvsfRepColAllRepairName
                                        
                                        
                                '@〓 "2:保全記録" 〓
                                Case CPlngNumTwo
                                        
                                    '@ﾀｲﾄﾙ行じゃなく、実施項目(一部)列の場合
                                    If llngColCnt = CMlngvsfPreColPreserveItem And llngRowCnt <> 0 Then
                                        '@実施項目(全文)を格納
                                        lstrWk = Replace$(.GetDataDisplay(llngRowCnt, CMlngvsfPreColPreserveItemAll), vbCrLf, Space$(1))
                                    End If
                                        
                                    '@保全記録選択時の依頼先担当者名列・最終列を格納
                                    llngToEmpName = CMlngvsfPreColToEmpName
                                    llngLastCol = CMlngvsfPreColPartCost
                                        
                            End Select
                                
                            '@依頼先担当者名列の場合
                            If llngRowCnt <> 0 And llngColCnt = llngToEmpName Then
                                    
                                '@文字列長を格納
                                lstrLen = Len(lstrWk)
                                '@格納用変数の初期化
                                lstrWk = vbNullString
                                    
                                For llngCnt = 1 To lstrLen
                                    If Mid$(.GetDataDisplay(llngRowCnt, llngColCnt), llngCnt, 1) = vbCr Then
                                        '@改行ｺｰﾄﾞを「",":ｶﾝﾏ」に編集する
                                        lstrWk = lstrWk & CPstrComma
                                        llngCnt = llngCnt + 1
                                    Else
                                        '@文字列を格納
                                        lstrWk = lstrWk & Mid$(.GetDataDisplay(llngRowCnt, llngColCnt), llngCnt, 1)
                                    End If
                                Next llngCnt
                            End If
                                
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                                
                            '@最終列の場合Tabいらない
                            If llngColCnt = llngLastCol Then
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk
                            Else
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk & vbTab
                            End If
                        End If
                    Next llngColCnt
                        
                    '@ｺﾋﾟｰ文字列作成
                    lstrRET = lstrRET & vbCrLf
                        
                Next llngRowCnt
            
                '@Clipboard にﾃｷｽﾄ文字列を挿入
                Clipboard.SetText(lstrRET)

            End With
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0041)
            '@publngMsgBoxInfo("メッセージコード：C_I41%0$$クリップボードにコピーしました。
            '@(Excel等に Ctrl＋Vキー で貼り付けてください)")
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCopy_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/26 (Fri) 17:06:25 N.Kojima
    '更新日：2007/01/26 (Fri) 17:06:25
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@=======================
            '@　終了処理
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN01Z0, ltypCommonInfo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
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

    '関数名：prvFrmxxEN01Z0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 16:11:53 N.Kojima
    '更新日：2008/01/17 (Thu) 13:31:07 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 13:31:07 N.Kojima     計画保全対応に伴い、処理追加&修正。(案件№02332)
    Private Sub prvFrmxxEN01Z0_Init()

        Dim ltypRepairInfoReq       As RepairInfoReq        '故障修理記録一覧取得要求構造体初期化用
        Dim ltypChgRepairInfoReq    As RepairInfo           '故障修理記録情報登録/更新要求構造体初期化用
        Dim ltypEqStopMenteListAns  As EqStopMenteListAns   '装置停止・ﾒﾝﾃ計画一覧取得構造体

        Try
            
            '@ﾗﾍﾞﾙの初期化
            lblDataCnt.Text = vbNullString               '該当件数
            lblNowDate.Text = vbNullString               '情報取得日時
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtInformation.Text = vbNullString
            txtInformation.Locked = True
            txtInformation.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)    'ﾊﾞｯｸｶﾗｰ
            txtInformation.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor) 'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
            txtInformation.TabStop = False                  'Tabでﾌｫｰｶｽを取得しない
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化
            cmdEdit.Enabled = False                         '編集(修正)ﾎﾞﾀﾝ
            cmdApprove.Enabled = False                      '承認ﾎﾞﾀﾝ
            cmdDiscon.Enabled = False                       '破棄(削除)ﾎﾞﾀﾝ
            cmdMailSend.Enabled = False                     '確認依頼ﾎﾞﾀﾝ
            cmdCopyInsert.Enabled = False                   'ｺﾋﾟｰ登録ﾎﾞﾀﾝ
            cmdCopy.Enabled = False                         'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ
            cmdSearch.Enabled = False                       '検索ﾎﾞﾀﾝ
            
            '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体の初期化
            mtypChgRepairInfoReq = ltypChgRepairInfoReq     '故障修理記録情報登録/更新要求構造体
            mtypRepairInfoReq = ltypRepairInfoReq           '故障修理記録一覧取得要求構造体
            If mtypRepairInfoAns Is Nothing Then            '故障修理記録一覧取得応答構造体
                mtypRepairInfoAns = New List(Of RepairInfoAns)
            Else
                mtypRepairInfoAns.Clear
            End If
            mlngRepairListCnt = 0                           '故障修理記録一覧ﾘｽﾄ数格納用
            mtypChgPreserveInfoReq = mtypChgPreserveInfoReq '保全記録情報登録/更新要求構造体
            mtypPreserveInfoReq = mtypPreserveInfoReq       '保全記録一覧取得要求構造体
            If mtypPreserveInfoAns Is Nothing Then          '保全記録一覧取得応答構造体
                mtypPreserveInfoAns = New List(Of PreserveInfoAns)
            Else
                mtypPreserveInfoAns.Clear
            End If
            mlngPreserveListCnt = 0                         '保全記録一覧ﾘｽﾄ数格納用
            mtypEqStopMenteListAns = ltypEqStopMenteListAns '装置停止・ﾒﾝﾃ計画一覧取得構造体
            
            '@「閉じる」ﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN01Z0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/17 (Thu) 17:23:19 N.Kojima **************************************************
    '関数名：prvVsfMainteList_Init
    '機　能：ｸﾞﾘｯﾄﾞの初期化(装置停止・ﾒﾝﾃ計画選択時)
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 17:23:59 N.Kojima
    '更新日：2008/01/17 (Thu) 17:23:59
    '備　考：
    Private Sub prvVsfMainteList_Init()
        
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        
        Try

            With vsfMainteList
                
                'NSYS 再描画しない
                .Redraw = False

                .Clear(ClearFlags.Content)                                                      'ｸﾘｱ
                .Cols.Count = CMlngvsfMainteCols                                                '列数の設定
                .Rows.Count = .Rows.Fixed                                                       '初期行数設定
                .Font = New Font(.Font.FontFamily, CMlngvsfHFontSize, .Font.Style, .Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ指定(=11)
                .ScrollBars = ScrollBars.Both                                                   'ｽｸﾛｰﾙﾊﾞｰ設定(行/列両方向)
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfMntColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '@表示位置の設定(ﾀｲﾄﾙ:中央寄せ中央揃え)
                cellRange.Style = headerStyle

                '@一時的に非表示解除
                For llngCnt = 0 To CMlngvsfMainteCols - 1
                    '@非表示解除
                    .Cols(llngCnt).Visible = True
                Next llngCnt
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColNo, CMstrvsfMntColTNo)                           '№
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColWPID, CMstrvsfMntColTWPID)                       '装置ID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColWPName, CMstrvsfMntColTWPName)                   '装置名
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColCategoryID, CMstrvsfMntColTCategoryID)           'ｶﾃｺﾞﾘID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColCategoryName, CMstrvsfMntColTCategoryName)       'ｶﾃｺﾞﾘ名
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColStartDate, CMstrvsfMntColTStartDate)             '開始予定日時
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColEndDate, CMstrvsfMntColTEndDate)                 '終了予定日時
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColDuration, CMstrvsfMntColTDuration)               '停止時間
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColComments, CMstrvsfMntColTCommentsD)              '停止ｺﾒﾝﾄ(一部)
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColCommentsAll, CMstrvsfMntColTCommentsV)           '停止ｺﾒﾝﾄ(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColStopRule, CMstrvsfMntColTStopRule)               '停止方法
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColEmpName, CMstrvsfMntColTEmpName)                 '最終更新者
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColEditTime, CMstrvsfMntColTEditTimeD)              '最終更新日時
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColEditTimeV, CMstrvsfMntColTEditTimeV)             '最終更新日時(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColEntryTime, CMstrvsfMntColTEntryTime)             '登録日時(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfMntColStartDateMilli, CMstrvsfMntColTStartDateMilli)   '開始予定日時(秒迄)

                '@列幅設定
                .Cols(CMlngvsfMntColNo).Width = CMlngvsfMntColWNo                             '№
                .Cols(CMlngvsfMntColWPID).Width = CMlngvsfMntColWWPID                         '装置ID(非表示)
                .Cols(CMlngvsfMntColWPName).Width = CMlngvsfMntColWWPName                     '装置名
                .Cols(CMlngvsfMntColCategoryID).Width = CMlngvsfMntColWCategoryID             'ｶﾃｺﾞﾘID(非表示)
                .Cols(CMlngvsfMntColCategoryName).Width = CMlngvsfMntColWCategoryName         'ｶﾃｺﾞﾘ名
                .Cols(CMlngvsfMntColStartDate).Width = CMlngvsfMntColWStartDate               '開始予定日時
                .Cols(CMlngvsfMntColEndDate).Width = CMlngvsfMntColWEndDate                   '終了予定日時
                .Cols(CMlngvsfMntColDuration).Width = CMlngvsfMntColWDuration                 '停止時間
                .Cols(CMlngvsfMntColComments).Width = CMlngvsfMntColWComments                 '停止ｺﾒﾝﾄ(一部)
                .Cols(CMlngvsfMntColCommentsAll).Width = CMlngvsfMntColWCommentsAll           '停止ｺﾒﾝﾄ(非表示)
                .Cols(CMlngvsfMntColStopRule).Width = CMlngvsfMntColWStopRule                 '停止方法
                .Cols(CMlngvsfMntColEmpName).Width = CMlngvsfMntColWEmpName                   '最終更新者
                .Cols(CMlngvsfMntColEditTime).Width = CMlngvsfMntColWEditTime                 '最終更新日時
                .Cols(CMlngvsfMntColEditTimeV).Width = CMlngvsfMntColWEditTimeV               '最終更新日時(非表示)
                .Cols(CMlngvsfMntColEntryTime).Width = CMlngvsfMntColWEntryTime               '登録日時(非表示)
                .Cols(CMlngvsfMntColStartDateMilli).Width = CMlngvsfMntColWStartDateMilli     '開始予定日時(秒迄)
                
                '@非表示設定
                .Cols(CMlngvsfMntColWPID).Visible = False               '装置ID(非表示)
                .Cols(CMlngvsfMntColCategoryID).Visible = False         'ｶﾃｺﾞﾘID(非表示)
                .Cols(CMlngvsfMntColCommentsAll).Visible = False        '停止ｺﾒﾝﾄ(非表示)
                .Cols(CMlngvsfMntColEditTimeV).Visible = False          '最終更新日時(非表示)
                .Cols(CMlngvsfMntColEntryTime).Visible = False          '登録日時(非表示)
                .Cols(CMlngvsfMntColStartDateMilli).Visible = False     '開始予定日時(秒迄)
                               
                'NSYS DataTye設定
                .Cols(CMlngvsfMntColDuration).DataType = GetType(Decimal)
                .Cols(CMlngvsfMntColDuration).Format = CPstrDoubleFormat2String
                .Cols(CMlngvsfRepColStopTime).DataType = GetType(Object)
                .Cols(CMlngvsfRepColStopTime).Format = ""
                .Cols(CMlngvsfPreColStopTime).DataType = GetType(Object)
                .Cols(CMlngvsfPreColStopTime).Format = ""
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight
                
                'NSYS 再描画しない
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@固定列の設定
                .Cols.Frozen = CMlngvsfMntColStartDate + 1
                
                '@ﾗﾍﾞﾙの初期化
                lblDataCnt.Text = vbNullString       '該当件数
                lblNowDate.Text = vbNullString       '情報取得日時
                
                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                cmdCopy.Enabled = False
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfMainteList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 17:23:19 N.Kojima **************************************************

    '関数名：prvVsfRepairList_Init
    '機　能：ｸﾞﾘｯﾄﾞの初期化(故障修理記録選択時)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 16:54:36 N.Kojima
    '更新日：2007/01/16 (Tue) 16:54:36
    '備　考：
    Private Sub prvVsfRepairList_Init()

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            With vsfMainteList
                
                'NSYS 再描画しない
                .Redraw = False

                .Clear(ClearFlags.Content)                                                      'ｸﾘｱ
                .Cols.Count = CMlngvsfRepairCols                                                '列数の設定
                .Rows.Count = .Rows.Fixed                                                       '初期行数設定
                .Font = New Font(.Font.FontFamily, CMlngvsfHFontSize, .Font.Style, .Font.Unit)  'ﾌｫﾝﾄｻｲｽﾞ指定(=11)
                .ScrollBars = ScrollBars.Both                                                   'ｽｸﾛｰﾙﾊﾞｰ設定(行/列両方向)
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfRepColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '@表示位置の設定(ﾀｲﾄﾙ:中央寄せ中央揃え)
                cellRange.Style = headerStyle

                '@一時的に非表示解除
                For llngCnt = 0 To CMlngvsfRepairCols - 1
                    '@非表示解除
                    .Cols(llngCnt).Visible = True
                Next llngCnt

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColNo, CMstrvsfRepColTNo)                                   '№
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairStatusID, CMstrvsfRepColTRepairStatusID)           '状態ID
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairStatus, CMstrvsfRepColTRepairStatus)               '状態名
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairNo, CMstrvsfRepColTRepairNo)                       '発行№
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColWPID, CMstrvsfRepColTWPID)                               '装置ID
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColWPName, CMstrvsfRepColTWPName)                           '装置名
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairName, CMstrvsfRepColTRepairName)                   '故障現象名(一部)
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairStartDate, CMstrvsfRepColTRepairStartDate)         '故障発生日時
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairEndDate, CMstrvsfRepColTRepairEndDate)             '修理完了日時
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColStopTime, CMstrvsfRepColTStopTime)                       '停止時間
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColToEmpName, CMstrvsfRepColTToEmpName)                     '依頼先担当者名
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColFindEmpName, CMstrvsfRepColTFindEmpName)                 '起案者名
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColPreserverEmpName, CMstrvsfRepColTPreserverEmpName)       '保全実施者名
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColEditTime, CMstrvsfRepColTEditTime)                       '更新日時
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairContents, CMstrvsfRepColTRepairContents)           '故障現象詳細
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairAnalysisContents, CMstrvsfRepColTRepairAnalysisContents)   '調査/分析詳細
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairCauseContents, CMstrvsfRepColTRepairCauseContents)         '原因詳細
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColRepairMeasureContents, CMstrvsfRepColTRepairMeasureContents)     '対策詳細
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColAllRepairName, CMstrvsfRepColTAllRepairName)             '故障現象名(全文)
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColCopeDivision, CMstrvsfRepColTCopeDivision)               '対応区分
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColWorkCost, CMstrvsfRepColTWorkCost)                       '作業費用
                .SetData(CMlngVsfRowTitle, CMlngvsfRepColPartCost, CMstrvsfRepColTPartCost)                       '部品費用

                '@列幅設定
                .Cols(CMlngvsfRepColNo).Width = CMlngvsfRepColWNo                                 '№
                .Cols(CMlngvsfRepColRepairStatusID).Width = CMlngvsfRepColWRepairStatusID         '状態ID
                .Cols(CMlngvsfRepColRepairStatus).Width = CMlngvsfRepColWRepairStatus             '状態名
                .Cols(CMlngvsfRepColRepairNo).Width = CMlngvsfRepColWRepairNo                     '発行№
                .Cols(CMlngvsfRepColWPID).Width = CMlngvsfRepColWWPID                             '装置ID
                .Cols(CMlngvsfRepColWPName).Width = CMlngvsfRepColWWPName                         '装置名
                .Cols(CMlngvsfRepColRepairName).Width = CMlngvsfRepColWRepairName                 '故障現象名(一部)
                .Cols(CMlngvsfRepColRepairStartDate).Width = CMlngvsfRepColWRepairStartDate       '故障発生日時
                .Cols(CMlngvsfRepColRepairEndDate).Width = CMlngvsfRepColWRepairEndDate           '修理完了日時
                .Cols(CMlngvsfRepColStopTime).Width = CMlngvsfRepColWStopTime                     '停止時間
                .Cols(CMlngvsfRepColToEmpName).Width = CMlngvsfRepColWToEmpName                   '依頼先担当者名
                .Cols(CMlngvsfRepColFindEmpName).Width = CMlngvsfRepColWFindEmpName               '起案者名
                .Cols(CMlngvsfRepColPreserverEmpName).Width = CMlngvsfRepColWPreserverEmpName     '保全実施者名
                .Cols(CMlngvsfRepColEditTime).Width = CMlngvsfRepColWEditTime                     '更新日時
                .Cols(CMlngvsfRepColRepairContents).Width = CMlngvsfRepColWRepairContents         '故障現象詳細
                .Cols(CMlngvsfRepColRepairAnalysisContents).Width = CMlngvsfRepColWRepairAnalysisContents     '調査/分析詳細
                .Cols(CMlngvsfRepColRepairCauseContents).Width = CMlngvsfRepColWRepairCauseContents           '原因詳細
                .Cols(CMlngvsfRepColRepairMeasureContents).Width = CMlngvsfRepColWRepairMeasureContents       '対策詳細
                .Cols(CMlngvsfRepColAllRepairName).Width = CMlngvsfRepColWAllRepairName           '故障現象名(全文)
                .Cols(CMlngvsfRepColCopeDivision).Width = CMlngvsfRepColWCopeDivision             '対応区分
                .Cols(CMlngvsfRepColWorkCost).Width = CMlngvsfRepColWWorkCost                     '作業費用
                .Cols(CMlngvsfRepColPartCost).Width = CMlngvsfRepColWPartCost                     '部品費用
                
                '@非表示設定
                .Cols(CMlngvsfRepColRepairStatusID).Visible = False             '状態ID
                .Cols(CMlngvsfRepColWPID).Visible = False                       '装置ID
                .Cols(CMlngvsfRepColEditTime).Visible = False                   '更新日時
                .Cols(CMlngvsfRepColRepairContents).Visible = False             '故障現象詳細
                .Cols(CMlngvsfRepColRepairAnalysisContents).Visible = False     '調査/分析詳細
                .Cols(CMlngvsfRepColRepairCauseContents).Visible = False        '原因詳細
                .Cols(CMlngvsfRepColRepairMeasureContents).Visible = False      '対策詳細
                .Cols(CMlngvsfRepColAllRepairName).Visible = False              '故障現象名(全文)
                
                'NSYS DataTye設定
                .Cols(CMlngvsfMntColDuration).DataType = GetType(Object)
                .Cols(CMlngvsfMntColDuration).Format = ""
                .Cols(CMlngvsfRepColStopTime).DataType = GetType(Decimal)
                .Cols(CMlngvsfRepColStopTime).Format = CPstrDoubleFormat2String
                .Cols(CMlngvsfRepColWorkCost).DataType = GetType(Decimal)
                .Cols(CMlngvsfRepColWorkCost).Format = CPstrDateFormatKanma
                .Cols(CMlngvsfRepColPartCost).DataType = GetType(Decimal)
                .Cols(CMlngvsfRepColPartCost).Format = CPstrDateFormatKanma
                .Cols(CMlngvsfPreColStopTime).DataType = GetType(Object)
                .Cols(CMlngvsfPreColStopTime).Format = ""

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight
                
                'NSYS 再描画
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@固定列の設定
                .Cols.Frozen = CMlngvsfRepColWPName + 1
                
                '@ﾗﾍﾞﾙの初期化
                lblDataCnt.Text = vbNullString       '該当件数
                lblNowDate.Text = vbNullString       '情報取得日時
                
                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                cmdCopy.Enabled = False
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfRepairList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/17 (Thu) 17:23:03 N.Kojima **************************************************
    '関数名：prvVsfPreserveList_Init
    '機　能：ｸﾞﾘｯﾄﾞの初期化(保全記録選択時)
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 17:24:59 N.Kojima
    '更新日：2008/01/17 (Thu) 17:24:59
    '備　考：
    Private Sub prvVsfPreserveList_Init()

        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try

            With vsfMainteList
                
                'NSYS 再描画しない
                .Redraw = False

                .Clear(ClearFlags.Content)                                                      'ｸﾘｱ
                .Cols.Count = CMlngvsfPreserveCols                                              '列数の設定
                .Rows.Count = .Rows.Fixed                                                       '初期行数設定
                .Font = New Font(.Font.FontFamily, CMlngvsfFontSize, .Font.Style, .Font.Unit)   'ﾌｫﾝﾄｻｲｽﾞ指定(=11)     
                .ScrollBars = ScrollBars.Both                                                   'ｽｸﾛｰﾙﾊﾞｰ設定(行/列両方向)
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfPreColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '@表示位置の設定(ﾀｲﾄﾙ:中央寄せ中央揃え)
                cellRange.Style = headerStyle

                '@一時的に非表示解除
                For llngCnt = 0 To CMlngvsfPreserveCols - 1
                    '@非表示解除
                    .Cols(llngCnt).Visible = True
                Next llngCnt

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColNo, CMstrvsfPreColTNo)                                       '№
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveStatusID, CMstrvsfPreColTPreserveStatusID)           '状態ID(非表示:0,1,2,3)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveStatusName, CMstrvsfPreColTPreserveStatusName)       '状態名(未,処,済)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveNo, CMstrvsfPreColTPreserveNo)                       '発行№
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColWpID, CMstrvsfPreColTWpID)                                   '装置ID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColWpName, CMstrvsfPreColTWpName)                               '装置名
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColCategoryID, CMstrvsfPreColTCategoryID)                       'ｶﾃｺﾞﾘID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColCategoryName, CMstrvsfPreColTCategoryName)                   'ｶﾃｺﾞﾘ名(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveCategoryID, CMstrvsfPreColTPreserveCategoryID)       '保全ｶﾃｺﾞﾘID(非表示:1=予防保全,2=改良改善保全,3=ﾙｰﾁﾝﾒﾝﾃ)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveCategoryName, CMstrvsfPreColTPreserveCategoryName)   '保全ｶﾃｺﾞﾘ名(和名)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveItem, CMstrvsfPreColTPreserveItem)                   '実施項目(一部)(30byteまで)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveItemAll, CMstrvsfPreColTPreserveItemAll)             '実施項目(全文)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColStartDate, CMstrvsfPreColTStartDate)                         '開始(予定)日時
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColEndDate, CMstrvsfPreColTEndDate)                             '終了(予定)日時
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColStopTime, CMstrvsfPreColTStopTime)                           '停止時間
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColToEmpName, CMstrvsfPreColTToEmpName)                         '依頼先担当者名
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserverEmpName, CMstrvsfPreColTPreserverEmpName)           '保全実施者名
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColEmpName, CMstrvsfPreColTEmpName)                             '更新者
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColEditTime, CMstrvsfPreColTEditTime)                           '更新日時
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveContents, CMstrvsfPreColTPreserveContents)           '実施内容(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreservePurpose, CMstrvsfPreColTPreservePurpose)             '実施理由/目的(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveSignEmpID, CMstrvsfPreColTPreserveSignEmpID)         '保全担当ｻｲﾝID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPreserveLeaderSignEmpID, CMstrvsfPreColTPreserveLeaderSignEmpID)     '保全ﾘｰﾀﾞｰｻｲﾝID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColProductLeaderSignEmpID, CMstrvsfPreColTProductLeaderSignEmpID)       '作業長ｻｲﾝID(非表示)
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColCopeDivision, CMstrvsfPreColTCopeDivision)                   '対応区分
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColWorkCost, CMstrvsfPreColTWorkCost)                           '作業費用
                .SetData(CMlngVsfRowTitle, CMlngvsfPreColPartCost, CMstrvsfPreColTPartCost)                           '部品費用

                '@列幅設定
                .Cols(CMlngvsfPreColNo).Width = CMlngvsfPreColWNo                                     '№
                .Cols(CMlngvsfPreColPreserveStatusID).Width = CMlngvsfPreColWPreserveStatusID         '状態ID(非表示:0,1,2,3)
                .Cols(CMlngvsfPreColPreserveStatusName).Width = CMlngvsfPreColWPreserveStatusName     '状態名(未,処,済)
                .Cols(CMlngvsfPreColPreserveNo).Width = CMlngvsfPreColWPreserveNo                     '発行№
                .Cols(CMlngvsfPreColWpID).Width = CMlngvsfPreColWWpID                                 '装置ID(非表示)
                .Cols(CMlngvsfPreColWpName).Width = CMlngvsfPreColWWpName                             '装置名
                .Cols(CMlngvsfPreColCategoryID).Width = CMlngvsfPreColWCategoryID                     'ｶﾃｺﾞﾘID(非表示)
                .Cols(CMlngvsfPreColCategoryName).Width = CMlngvsfPreColWCategoryName                 'ｶﾃｺﾞﾘ名(非表示)
                .Cols(CMlngvsfPreColPreserveCategoryID).Width = CMlngvsfPreColWPreserveCategoryID     '保全ｶﾃｺﾞﾘID(非表示:1=予防保全,2=改良改善保全,3=ﾙｰﾁﾝﾒﾝﾃ)
                .Cols(CMlngvsfPreColPreserveCategoryName).Width = CMlngvsfPreColWPreserveCategoryName '保全ｶﾃｺﾞﾘ名(和名)
                .Cols(CMlngvsfPreColPreserveItem).Width = CMlngvsfPreColWPreserveItem                 '実施項目(一部)(30byteまで)
                .Cols(CMlngvsfPreColPreserveItemAll).Width = CMlngvsfPreColWPreserveItemAll           '実施項目(全文)
                .Cols(CMlngvsfPreColStartDate).Width = CMlngvsfPreColWStartDate                       '開始(予定)日時
                .Cols(CMlngvsfPreColEndDate).Width = CMlngvsfPreColWEndDate                           '終了(予定)日時
                .Cols(CMlngvsfPreColStopTime).Width = CMlngvsfPreColWStopTime                         '停止時間
                .Cols(CMlngvsfPreColToEmpName).Width = CMlngvsfPreColWToEmpName                       '依頼先担当者名
                .Cols(CMlngvsfPreColPreserverEmpName).Width = CMlngvsfPreColWPreserverEmpName         '保全実施者名
                .Cols(CMlngvsfPreColEmpName).Width = CMlngvsfPreColWEmpName                           '更新者
                .Cols(CMlngvsfPreColEditTime).Width = CMlngvsfPreColWEditTime                         '更新日時
                .Cols(CMlngvsfPreColPreserveContents).Width = CMlngvsfPreColWPreserveContents         '実施内容(非表示)
                .Cols(CMlngvsfPreColPreservePurpose).Width = CMlngvsfPreColWPreservePurpose           '実施理由/目的(非表示)
                .Cols(CMlngvsfPreColPreserveSignEmpID).Width = CMlngvsfPreColWPreserveSignEmpID       '保全担当ｻｲﾝID(非表示)
                .Cols(CMlngvsfPreColPreserveLeaderSignEmpID).Width = CMlngvsfPreColWPreserveLeaderSignEmpID   '保全ﾘｰﾀﾞｰｻｲﾝID(非表示)
                .Cols(CMlngvsfPreColProductLeaderSignEmpID).Width = CMlngvsfPreColWProductLeaderSignEmpID     '作業長ｻｲﾝID(非表示)
                .Cols(CMlngvsfPreColCopeDivision).Width = CMlngvsfPreColWCopeDivision                 '対応区分
                .Cols(CMlngvsfPreColWorkCost).Width = CMlngvsfPreColWWorkCost                         '作業費用
                .Cols(CMlngvsfPreColPartCost).Width = CMlngvsfPreColWPartCost                         '部品費用
                
                '@非表示設定
                .Cols(CMlngvsfPreColPreserveStatusID).Visible = False           '状態ID(非表示:0,1,2,3)
                .Cols(CMlngvsfPreColWpID).Visible = False                       '装置ID(非表示)
                .Cols(CMlngvsfPreColCategoryID).Visible = False                 'ｶﾃｺﾞﾘID(非表示)
                .Cols(CMlngvsfPreColCategoryName).Visible = False               'ｶﾃｺﾞﾘ名(非表示)
                .Cols(CMlngvsfPreColPreserveCategoryID).Visible = False         '保全ｶﾃｺﾞﾘID(非表示)
                .Cols(CMlngvsfPreColEditTime).Visible = False                   '最終更新日時(非表示)
                .Cols(CMlngvsfPreColPreserveItemAll).Visible = False            '実施項目(非表示:全文)
                .Cols(CMlngvsfPreColPreserveContents).Visible = False           '実施内容(非表示)
                .Cols(CMlngvsfPreColPreservePurpose).Visible = False            '実施理由/目的(非表示)
                .Cols(CMlngvsfPreColPreserveSignEmpID).Visible = False          '保全担当ｻｲﾝID(非表示)
                .Cols(CMlngvsfPreColPreserveLeaderSignEmpID).Visible = False    '保全ﾘｰﾀﾞｰｻｲﾝID(非表示)
                .Cols(CMlngvsfPreColProductLeaderSignEmpID).Visible = False     '作業長ｻｲﾝID(非表示)
                
                'NSYS DataTye設定
                .Cols(CMlngvsfMntColDuration).DataType = GetType(Object)
                .Cols(CMlngvsfMntColDuration).Format = ""
                .Cols(CMlngvsfRepColStopTime).DataType = GetType(Object)
                .Cols(CMlngvsfRepColStopTime).Format = ""
                .Cols(CMlngvsfRepColWorkCost).DataType = GetType(Object)
                .Cols(CMlngvsfRepColWorkCost).Format = ""
                .Cols(CMlngvsfRepColPartCost).DataType = GetType(Object)
                .Cols(CMlngvsfRepColPartCost).Format = ""
                .Cols(CMlngvsfPreColStopTime).DataType = GetType(Decimal)
                .Cols(CMlngvsfPreColStopTime).Format = CPstrDoubleFormat2String
                .Cols(CMlngvsfPreColWorkCost).DataType = GetType(Decimal)
                .Cols(CMlngvsfPreColWorkCost).Format = CPstrDateFormatKanma
                .Cols(CMlngvsfPreColPartCost).DataType = GetType(Decimal)
                .Cols(CMlngvsfPreColPartCost).Format = CPstrDateFormatKanma
                
                'NSYS スクロール位置設定
                .LeftCol = 0

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight
                
                'NSYS 再描画
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@ﾗﾍﾞﾙの初期化
                lblDataCnt.Text = vbNullString       '該当件数
                lblNowDate.Text = vbNullString       '情報取得日時
                
                '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝの非活性化
                cmdCopy.Enabled = False
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfPreserveList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 17:23:03 N.Kojima **************************************************

    '@↓2008/01/17 (Thu) 17:19:33 N.Kojima **************************************************
    '関数名：prvVsfMainteList_Disp
    '機　能：装置停止・ﾒﾝﾃ計画一覧の表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 17:19:43 N.Kojima
    '更新日：2008/01/17 (Thu) 17:19:43
    '備　考：
    Private Sub prvVsfMainteList_Disp()

        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngDurationMinute      As Decimal      '時間間隔(分)
        Dim lcurDurationHour        As Decimal      '時間間隔(時間)少数点
        Dim lstrCommentsChgSpace    As String       '停止ｺﾒﾝﾄ(改行ｷｰ→空白変換)
        Dim lstrComments30          As String       '停止ｺﾒﾝﾄ30ﾊﾞｲﾄ表示用
        Dim llngCommentsCnt         As Integer      '停止ｺﾒﾝﾄｶｳﾝﾀ

        Try

            With vsfMainteList
                
                '@格納ﾃﾞｰﾀがあるか
                If mtypEqStopMenteListAns.lngEqStopMenteListCnt > 0 Then
                    '@格納ﾃﾞｰﾀがあるの場合

                    RemoveHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
                    RemoveHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange

                    .Redraw = False    '直接描画しない
                    .Row = -1
                    .Rows.Count = .Rows.Fixed      '行数初期化(ｸﾞﾘｯﾄﾞの初期化)
                    .Rows.Count = mtypEqStopMenteListAns.lngEqStopMenteListCnt + 1    '行数設定

                    '@ｸﾞﾘｯﾄﾞの設定
                    For llngCnt = 1 To mtypEqStopMenteListAns.lngEqStopMenteListCnt
                        
                        .SetData(llngCnt, CMlngvsfMntColNo, llngCnt)                            '№
                        .SetData(llngCnt, CMlngvsfMntColWPID, _
                            mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWpID)      '装置ID
                        .SetData(llngCnt, CMlngvsfMntColWPName, _
                            mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWpName)    '装置名
                                        
                        '@ｶﾃｺﾞﾘIDがNULLか
                        If mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strCategoryID = vbNullString Then
                            
                            '@ｶﾃｺﾞﾘIDがNULLの場合(=計画ﾃﾞｰﾀ)
                            .SetData(llngCnt, CMlngvsfMntColCategoryName, CMstrMaintenancePlan)
                            '@ｶﾃｺﾞﾘID(実績ﾃﾞｰﾀ修正制御用)
                            .SetData(llngCnt, CMlngvsfMntColCategoryID, CPstrZero)
                        Else
                            '@ｶﾃｺﾞﾘIDがNULL以外の場合(=実績ﾃﾞｰﾀ)
                            .SetData(llngCnt, CMlngvsfMntColCategoryName, _
                                mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strCategoryName)
                            '@ｶﾃｺﾞﾘID(実績ﾃﾞｰﾀ修正制御用)
                            .SetData(llngCnt, CMlngvsfMntColCategoryID, _
                                mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strCategoryID)
                        End If
                            
                        '@開始(予定)日時(分迄)
                        If IsDate(mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopStart) Then
                            .SetData(llngCnt, CMlngvsfMntColStartDate, _
                                Format$(CDate(mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopStart), CPstrDateTimeYMDHM))
                        Else
                            .SetData(llngCnt, CMlngvsfMntColStartDate, _
                                mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopStart)
                        End If
                        '@登録日時(秒迄)
                        .SetData(llngCnt, CMlngvsfMntColStartDateMilli, _
                            mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strEntryTime)

                        '@終了(予定)日時(分迄)
                        If IsDate(mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopEnd) Then
                            .SetData(llngCnt, CMlngvsfMntColEndDate, _
                                Format$(CDate(mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopEnd), CPstrDateTimeYMDHM))
                        Else
                            .SetData(llngCnt, CMlngvsfMntColEndDate, _
                                mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopEnd)
                        End If
                        '@停止時間(少数第2位迄)
                        '@開始(予定)日時が日付か
                        If IsDate(.GetData(llngCnt, CMlngvsfMntColStartDate)) = True Then
                            
                            '@終了(予定)日時が日付か
                            If IsDate(.GetData(llngCnt, CMlngvsfMntColEndDate)) = True Then
                            
                                '@開始～終了までの時間間隔(分単位)を算出する
                                llngDurationMinute = DateDiff(CMstrDatediffMinute, .GetData(llngCnt, CMlngvsfMntColStartDate), _
                                                                                    .GetData(llngCnt, CMlngvsfMntColEndDate))
                            Else
                                '@開始～現在までの時間間隔(分単位)を算出する
                                llngDurationMinute = DateDiff(CMstrDatediffMinute, .GetData(llngCnt, CMlngvsfMntColStartDate), _
                                                                                    Format$(Now, CPstrDateTimeYMDHM))
                            End If
                            
                            '@時間へ変換する(少数第2位迄算出する為に100倍し、切捨て後、100で割る)
                            lcurDurationHour = Fix(llngDurationMinute / CMlngMinute60 * 100D) / 100D
                            
                            '@停止時間を設定する(#,##0.00)
                             .SetData(llngCnt, CMlngvsfMntColDuration, _
                                Format$(lcurDurationHour, CPstrDoubleFormat2String))
                        Else
                            '@停止時間を未設定する
                             .SetData(llngCnt, CMlngvsfMntColDuration, vbNullString)
                        End If
                        
                        '@停止ｺﾒﾝﾄ(一部)
                        '@停止ｺﾒﾝﾄの改行ｷｰ変換(→Spaceへ変換)
                        lstrCommentsChgSpace = Replace$(mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopComments, vbCrLf, Space$(1))        '停止ｺﾒﾝﾄ
                        lstrComments30 = vbNullString
                        
                        For llngCommentsCnt = 1 To Len(lstrCommentsChgSpace)
                            
                            '@30ﾊﾞｲﾄﾁｪｯｸ
                            If LenB(lstrComments30 & Mid$(lstrCommentsChgSpace, llngCommentsCnt, 1)) > CMlngDisplayByte30 Then
                                Exit For
                            Else
                                lstrComments30 = lstrComments30 & Mid$(lstrCommentsChgSpace, llngCommentsCnt, 1)
                            End If
                        Next llngCommentsCnt
                        
                        .SetData(llngCnt, CMlngvsfMntColComments, lstrComments30)                                                   '停止ｺﾒﾝﾄ(30byte)
                        .SetData(llngCnt, CMlngvsfMntColCommentsAll, _
                            mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopComments)                                '停止ｺﾒﾝﾄ(全文)

                        '@停止方法
                        '@★ 停止ﾙｰﾙにより処理分岐 ★
                        Select Case mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strWPStopRule
                            
                            '@〓 "1:強制" 〓
                            Case CMlngStopRule1
                                
                                .SetData(llngCnt, CMlngvsfMntColStopRule, CMstrStopRule1)                                           '停止方法：強制
                            
                            '@〓 "3:ﾛｯﾄ優先" 〓
                            Case CMlngStopRule3
                                
                                .SetData(llngCnt, CMlngvsfMntColStopRule, CMstrStopRule3)                                           '停止方法：ﾛｯﾄ優先
                            
                            '@〓 その他 〓
                            Case Else
                                
                                .SetData(llngCnt, CMlngvsfMntColStopRule, vbNullString)                                             '停止方法：その他or設定なし
                                
                        End Select
                        
                        .SetData(llngCnt, CMlngvsfMntColEmpName, _
                            mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strEmpName)                                       '最終更新者

                        .SetData(llngCnt, CMlngvsfMntColEditTime, _
                            Strings.Left$(mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strEditTime, CMlngEditTimeChgLen))  '最終更新日時(分迄)
                            
                        .SetData(llngCnt, CMlngvsfMntColEditTimeV, _
                            mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strEditTime)                                      '最終更新日時(排他制御用)
                        
                        .SetData(llngCnt, CMlngvsfMntColEntryTime, _
                            mtypEqStopMenteListAns.typEqStopMenteList(llngCnt -1).strEntryTime)                                     '登録日時(実績ﾃﾞｰﾀ修正制御用)
                        
                        '@ﾌｫﾝﾄの色変更(黒色)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                        newStyle.ForeColor = Color.Black
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngVsfColTitle, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngCnt).Height = CMlngVsfHeight
                    Next llngCnt

                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfMntColWPName, .Cols.Count - 1, 6)
                    End If

                    '@書式設定
                    .Cols(CMlngvsfMntColNo).TextAlign = TextAlignEnum.RightCenter              '№(右寄せ中央揃え)
                    .Cols(CMlngvsfMntColWPID).TextAlign = TextAlignEnum.LeftCenter             '装置ID(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColWPName).TextAlign = TextAlignEnum.LeftCenter           '装置名(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColCategoryID).TextAlign = TextAlignEnum.LeftCenter       'ｶﾃｺﾞﾘID(和名)(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColCategoryName).TextAlign = TextAlignEnum.LeftCenter     'ｶﾃｺﾞﾘ名(和名)(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColStartDate).TextAlign = TextAlignEnum.LeftCenter        '開始(予定)日時(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColStartDateMilli).TextAlign = TextAlignEnum.LeftCenter   '開始(予定)日時(秒)(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColEndDate).TextAlign = TextAlignEnum.LeftCenter          '終了(予定)日時(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColDuration).TextAlign = TextAlignEnum.RightCenter        '停止時間(右寄せ中央揃え)
                    .Cols(CMlngvsfMntColComments).TextAlign = TextAlignEnum.LeftCenter         '停止ｺﾒﾝﾄ(一部)(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColCommentsAll).TextAlign = TextAlignEnum.LeftCenter      '停止ｺﾒﾝﾄ(全文)(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColStopRule).TextAlign = TextAlignEnum.LeftCenter         '停止方法(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColEmpName).TextAlign = TextAlignEnum.LeftCenter          '最終更新者(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColEditTime).TextAlign = TextAlignEnum.LeftCenter         '最終更新日時(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColEditTimeV).TextAlign = TextAlignEnum.LeftCenter        '最終更新日時(排他用)(左寄せ中央揃え)
                    .Cols(CMlngvsfMntColEntryTime).TextAlign = TextAlignEnum.LeftCenter        '登録日時(左寄せ中央揃え)

                    '@固定列の設定
                    .Cols.Frozen = CMlngvsfMntColStartDate + 1                           '開始(予定)日時

                    '@ﾏｳｽよる列ｻｲｽﾞ変更の可設定
                    .AllowResizing = AllowResizingEnum.Columns

                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    AddHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
                    AddHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange

                    '@ｿｰﾄ検索用ｷｰ(装置名＆開始予定日時)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@装置名＆開始予定日時が同じ場合
                            If .GetData(llngCnt, CMlngvsfMntColWPName) & _
                                .GetData(llngCnt, CMlngvsfMntColStartDate) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                
                                '@=======================
                                '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)処理
                                '@=======================
                                Call pubVsfBeforeSort(vsfMainteList, CMlngVsfRowTitle)
                                
                                '@=======================
                                '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)処理
                                '@=======================
                                Call pubVsfAfterSort(vsfMainteList, CMlngVsfRowTitle,Nothing ,Nothing ,False, False, False, False)

                                Exit For
                            End If
                        Next llngCnt
                    End If

                    .TopRow = 0
                    .Row = 0

                    '@描画
                    .Redraw = True
                Else
                    '@格納ﾃﾞｰﾀが無い場合
                    
                    '@=======================
                    '@　ｸﾞﾘｯﾄﾞの初期化処理
                    '@=======================
                    Call prvVsfMainteList_Init()
                End If
            End With

            '@ﾃﾞｰﾀが1件以上存在するか
            If vsfMainteList.Rows.Count > 1 Then
                '@ﾃﾞｰﾀが存在する場合
            
                vsfMainteList.Enabled = True            'ｸﾞﾘｯﾄﾞ：有効
                txtInformation.Enabled = True           '情報表示ﾌｨｰﾙﾄﾞ：有効
                txtInformation.Text = vbNullString      '情報表示ﾌｨｰﾙﾄﾞ：NULL
                cmdCopy.Enabled = True                  'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ：有効
            Else
                '@ﾃﾞｰﾀが存在しない場合(無効化、初期化)
            
                vsfMainteList.Enabled = False           'ｸﾞﾘｯﾄﾞ：無効
                txtInformation.Enabled = False          '情報表示ﾌｨｰﾙﾄﾞ：無効
                txtInformation.Text = vbNullString      '情報表示ﾌｨｰﾙﾄﾞ：NULL
                cmdCopy.Enabled = False                 'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ：無効
            End If
            
            '@各種ﾗﾍﾞﾙの表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)      '情報取得日時
            lblDataCnt.Text = Format$(mtypEqStopMenteListAns.lngEqStopMenteListCnt, CPstrDateFormatKanma)    '該当件数

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfMainteList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 17:19:33 N.Kojima **************************************************

    '関数名：prvVsfRepairList_Disp
    '機　能：故障修理記録票一覧の表示処理
    '引　数：mtypRepairInfoAns  ：故障修理記録構造体
    '　　　：mlngRepairListCnt  ：故障修理記録ﾘｽﾄ数
    '戻り値：なし
    '作成日：2007/01/18 (Thu) 10:16:25 N.Kojima
    '更新日：2007/01/18 (Thu) 10:16:25
    '備　考：
    Private Sub prvVsfRepairList_Disp()

        Dim lstrProcID              As String       '担当者ID格納
        Dim lstrProcNM              As String       '担当者名格納
        Dim lstrProcNMD             As String       '担当者名格納表示用
        Dim llngDoCnt               As Integer      '描画用ｶｳﾝﾄ
        Dim llngCnt                 As Integer      '担当者用ｶｳﾝﾄ
        Dim llngHeight              As Integer      'ｽﾛｯﾄ高さ
        Dim llngRowCnt              As Integer      '一行に含まれる行数
        Dim llngDurationMinute      As Decimal      '時間間隔(分)
        Dim lcurDurationHour        As Decimal      '時間間隔(時間)少数点
        Dim lstrRepairNameChgSpace  As String       '故障現象名(改行ｷｰ→空白変換)
        Dim lstrRepairName30        As String       '故障現象名30ﾊﾞｲﾄ表示用
        Dim llngRepairNameCnt       As Integer      '故障現象名ｶｳﾝﾀ
        Dim llngRow                 As Integer      'NSYS 選択行格納
        Dim Scrollposition           As Point        'NSYS スクロール位置格納

        Try
            
            With vsfMainteList
                
                If mlngRepairListCnt > 0 Then
                    '@格納ﾃﾞｰﾀがあるの場合
                    
                    RemoveHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
                    RemoveHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange

                    llngRow = .Row
                    Scrollposition = .ScrollPosition

                    .Clear(ClearFlags.UserData)             'ｸﾘｱ
                    .Redraw = False                         '直接描画しない
                    .Row = -1
                    .Rows.Count = mlngRepairListCnt + 1     '行数設定
                    
                    '@故障修理記録情報を表示
                    For llngDoCnt = 1 To mlngRepairListCnt
                        
                        '@№設定
                        .SetData(llngDoCnt, CMlngvsfRepColNo, llngDoCnt)
                        
                        '@状態ID(0:未処置、1:処置済、2:承認済)を設定
                        .SetData(llngDoCnt, CMlngvsfRepColRepairStatusID, _
                            mtypRepairInfoAns(llngDoCnt -1).strRepairStatus)
                        
                        '@状態名(未処置、処置済、承認済)
                        '@★ 状態により処理分岐 ★
                        Select Case mtypRepairInfoAns(llngDoCnt -1).strRepairStatus
                            
                            '@〓 "0:未処置" 〓
                            Case CPstrZero
                                
                                .SetData(llngDoCnt, CMlngvsfRepColRepairStatus, CMstrNoDisposalFlag)   '未処置
                            
                            '@〓 "1:処置済み" 〓
                            Case CPstrOne
                                
                                .SetData(llngDoCnt, CMlngvsfRepColRepairStatus, CMstrDisposalFlag)     '処置済
                            
                            '@〓 "2:承認済み" 〓
                            Case CPstrTwo
                                
                                .SetData(llngDoCnt, CMlngvsfRepColRepairStatus, CMstrApplyFlag)        '承認済
                        End Select
                        
                        '@発行№
                        .SetData(llngDoCnt, CMlngvsfRepColRepairNo, mtypRepairInfoAns(llngDoCnt -1).strRepairNo)
                        '@装置ID
                        .SetData(llngDoCnt, CMlngvsfRepColWPID, mtypRepairInfoAns(llngDoCnt -1).strWpID)
                        '@装置名
                        .SetData(llngDoCnt, CMlngvsfRepColWPName, mtypRepairInfoAns(llngDoCnt -1).strWpName)
                        
                        '@故障現象名の改行ｷｰ変換(→Spaceへ変換)
                        lstrRepairNameChgSpace = Replace$(mtypRepairInfoAns(llngDoCnt -1).strRepairName, vbCrLf, Space$(1))
                        lstrRepairName30 = vbNullString
                        For llngRepairNameCnt = 1 To Len(lstrRepairNameChgSpace)
                            '@30ﾊﾞｲﾄﾁｪｯｸ
                            If LenB(lstrRepairName30 & Mid$(lstrRepairNameChgSpace, llngRepairNameCnt, 1)) > CMlngDisplayByte30 Then
                                Exit For
                            Else
                                lstrRepairName30 = lstrRepairName30 & Mid$(lstrRepairNameChgSpace, llngRepairNameCnt, 1)
                            End If
                        Next llngRepairNameCnt
                        '@故障現象名(一部)
                        .SetData(llngDoCnt, CMlngvsfRepColRepairName, lstrRepairName30)
                        '@故障現象名(全文)
                        .SetData(llngDoCnt, CMlngvsfRepColAllRepairName, mtypRepairInfoAns(llngDoCnt -1).strRepairName)
                        
                        '@故障発生日時
                        If IsDate(mtypRepairInfoAns(llngDoCnt -1).strRepairStartDate) Then
                            .SetData(llngDoCnt, CMlngvsfRepColRepairStartDate, Format$(CDate(mtypRepairInfoAns(llngDoCnt -1).strRepairStartDate), CPstrDateTimeYMDHM))
                        Else
                            .SetData(llngDoCnt, CMlngvsfRepColRepairStartDate, mtypRepairInfoAns(llngDoCnt -1).strRepairStartDate)
                        End If

                        '@修理完了日時
                        If IsDate(mtypRepairInfoAns(llngDoCnt -1).strRepairEndDate) Then
                            .SetData(llngDoCnt, CMlngvsfRepColRepairEndDate, Format$(CDate(mtypRepairInfoAns(llngDoCnt -1).strRepairEndDate), CPstrDateTimeYMDHM))
                        Else
                            .SetData(llngDoCnt, CMlngvsfRepColRepairEndDate, mtypRepairInfoAns(llngDoCnt -1).strRepairEndDate)
                        End If

                        '@停止時間(少数第2位迄)
                        '@故障発生日時が日付か
                        If IsDate(.GetData(llngDoCnt, CMlngvsfRepColRepairStartDate)) = True Then
                            '@修理完了日時が日付か
                            If IsDate(.GetData(llngDoCnt, CMlngvsfRepColRepairEndDate)) = True Then
                                '@開始～終了までの時間間隔(分単位)を算出する
                                llngDurationMinute = DateDiff(CMstrDatediffMinute, .GetData(llngDoCnt, CMlngvsfRepColRepairStartDate), _
                                                                                    .GetData(llngDoCnt, CMlngvsfRepColRepairEndDate))
                            Else
                                '@開始～現在までの時間間隔(分単位)を算出する
                                llngDurationMinute = DateDiff(CMstrDatediffMinute, .GetData(llngDoCnt, CMlngvsfRepColRepairStartDate), _
                                                                                    Format$(Now, CPstrDateTimeYMDHM))
                            End If
                            
                            '@時間へ変換する(少数第2位迄算出する為に100倍し、切捨て後、100で割る)
                            lcurDurationHour = Fix(llngDurationMinute / CMlngMinute60 * 100D) / 100D
                            
                            '@停止時間を設定する(#,##0.00)
                             .SetData(llngDoCnt, CMlngvsfRepColStopTime, Format$(lcurDurationHour, CPstrDoubleFormat2String))
                        Else
                            '@停止時間を未設定する
                             .SetData(llngDoCnt, CMlngvsfRepColStopTime, vbNullString)
                        End If
                        
                        '@未処置で停止時間が24hを超過しているか
                        If .GetData(llngDoCnt, CMlngvsfRepColStopTime) <> vbNullString Then
                            
                            If CLng(lcurDurationHour) >= CLng(CPstrTwentyFourTime) And _
                                .GetData(llngDoCnt, CMlngvsfRepColRepairStatus) = CMstrNoDisposalFlag Then
                                '@停止時間が24hを超過している場合
                                
                                '@背景色をﾋﾟﾝｸ色にする
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngStopLotColor" + llngDoCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngStopLotColor)
                                Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfRowTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            Else
                                '@停止時間が24hを超過していない場合
                                '@背景色を白色にする
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" + llngDoCnt.ToString)
                                newStyle.BackColor = SystemColors.Window
                                Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfRowTitle, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            End If
                        Else
                            '@背景色を白色にする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_Window" + llngDoCnt.ToString)
                            newStyle.BackColor = SystemColors.Window
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfRowTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        
                        '@「承認済」の場合
                        If .GetData(llngDoCnt, CMlngvsfRepColRepairStatus) = CMstrApplyFlag Then
                            '@背景色を灰色にする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray" + llngDoCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfRowTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Else
                            
                        End If
                        
                        '@担当者の格納処理
                        lstrProcID = vbNullString       '退避領域初期化
                        lstrProcNM = vbNullString       '退避領域初期化
                        lstrProcNMD = vbNullString      '退避領域初期化
                        
                        For llngCnt = 0 To mtypRepairInfoAns(llngDoCnt -1).lngEmpListCnt -1
                            If llngCnt = 0 Then
                                '@1件目の場合はそのまま変数へ格納
                                lstrProcID = mtypRepairInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpID
                                
                                '@担当者名が,13バイト以上の場合か否かで追加処理
                                If LenB(mtypRepairInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName) > CMlngEmpNameLenB13 Then
                                    '@13Byte以上
                                    lstrProcNM = LeftB(mtypRepairInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName, CMlngEmpNameLenB12)
                                    lstrProcNM = lstrProcNM & CMstrEmpNameLenAfter
                                Else
                                '@13Btye以下
                                    lstrProcNM = mtypRepairInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName
                                End If
                                
                                lstrProcNMD = lstrProcNM
                            Else
                                '@2件目以降は変数にｷｬﾘｯｼﾞﾘﾀｰﾝを入れて格納
                                lstrProcID = lstrProcID _
                                           & vbCrLf _
                                           & mtypRepairInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpID
                                
                                '@担当者名が,13バイト以上の場合か否かで追加処理
                                If LenB(mtypRepairInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName) > CMlngEmpNameLenB13 Then
                                '@13Byte以上
                                    lstrProcNM = Strings.Left(mtypRepairInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName, CMlngEmpNameLenB12)
                                    lstrProcNM = lstrProcNM & CMstrEmpNameLenAfter
                                Else
                                '@13Btye以下
                                    lstrProcNM = mtypRepairInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName
                                End If
                                
                                lstrProcNMD = lstrProcNMD _
                                            & vbCrLf _
                                            & lstrProcNM
                            End If
                        Next llngCnt
                        
                        '@担当者名
                        .SetData(llngDoCnt, CMlngvsfRepColToEmpName, lstrProcNMD)
                        
                        '@1件の異常処理票に含まれるﾛｯﾄと担当者の数を比較する
                        llngRowCnt = 0                                          '初期化
                        '@担当者数を格納
                        llngRowCnt = mtypRepairInfoAns(llngDoCnt -1).lngEmpListCnt
                        
                        If llngRowCnt <> 0 Then
                            '@ｽﾛｯﾄの高さを設定する
                            llngHeight = CMlngVsfHeight * llngRowCnt
                            .Rows(llngDoCnt).Height = llngHeight
                        Else
                            '@ｽﾛｯﾄの高さを設定する
                            llngHeight = CMlngVsfHeight
                            .Rows(llngDoCnt).Height = llngHeight
                        End If
                        
                        '@起案者名
                        .SetData(llngDoCnt, CMlngvsfRepColFindEmpName, mtypRepairInfoAns(llngDoCnt -1).strFindEmpName)
                        '@保全実施者
                        .SetData(llngDoCnt, CMlngvsfRepColPreserverEmpName, mtypRepairInfoAns(llngDoCnt -1).strPreserveEmpName)
                        '@更新日時
                        .SetData(llngDoCnt, CMlngvsfRepColEditTime, mtypRepairInfoAns(llngDoCnt -1).strEditTime)
                        '@故障現象詳細
                        .SetData(llngDoCnt, CMlngvsfRepColRepairContents, mtypRepairInfoAns(llngDoCnt -1).strRepairContents)
                        '@調査/分析詳細
                        .SetData(llngDoCnt, CMlngvsfRepColRepairAnalysisContents, mtypRepairInfoAns(llngDoCnt -1).strRepairAnalysisContents)
                        '@原因詳細
                        .SetData(llngDoCnt, CMlngvsfRepColRepairCauseContents, mtypRepairInfoAns(llngDoCnt -1).strRepairCauseContents)
                        '@対策詳細
                        .SetData(llngDoCnt, CMlngvsfRepColRepairMeasureContents, mtypRepairInfoAns(llngDoCnt -1).strRepairMeasureContents)
                        
                        '@対応区分
                        '@対応区分が"1" or NULLか
                        If mtypRepairInfoAns(llngDoCnt -1).strCopeDivision = CPstrOne Or _
                            mtypRepairInfoAns(llngDoCnt -1).strCopeDivision = vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfRepColCopeDivision, CMstrCopeDivision1)   '自主保全
                        Else
                            .SetData(llngDoCnt, CMlngvsfRepColCopeDivision, CMstrCopeDivision2)   'ﾒｰｶｰ保全
                        End If
                        
                        '@作業費用
                        If IsNumeric(mtypRepairInfoAns(llngDoCnt -1).strWorkCost) Then
                            .SetData(llngDoCnt, CMlngvsfRepColWorkCost, _
                                Format$(CDec(mtypRepairInfoAns(llngDoCnt -1).strWorkCost), CPstrDateFormatKanma))
                        Else
                            .SetData(llngDoCnt, CMlngvsfRepColWorkCost, _
                                mtypRepairInfoAns(llngDoCnt -1).strWorkCost)
                        End If

                        '@部品費用
                        If IsNumeric(mtypRepairInfoAns(llngDoCnt -1).strWorkCost) Then
                            .SetData(llngDoCnt, CMlngvsfRepColPartCost, _
                                Format$(CDec(mtypRepairInfoAns(llngDoCnt -1).strPartCost), CPstrDateFormatKanma))
                        Else
                            .SetData(llngDoCnt, CMlngvsfRepColPartCost, _
                                mtypRepairInfoAns(llngDoCnt -1).strPartCost)
                        End If
                    Next llngDoCnt
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfRepColNo, .Cols.Count - 1, 6)
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfRepColNo).TextAlign = TextAlignEnum.RightCenter                      '№
                    .Cols(CMlngvsfRepColRepairStatus).TextAlign = TextAlignEnum.LeftCenter             '状態
                    .Cols(CMlngvsfRepColRepairNo).TextAlign = TextAlignEnum.LeftCenter                 '故障修理記録№
                    .Cols(CMlngvsfRepColWPName).TextAlign = TextAlignEnum.LeftCenter                   '装置名
                    .Cols(CMlngvsfRepColRepairName).TextAlign = TextAlignEnum.LeftCenter               '故障現象名(一部)
                    .Cols(CMlngvsfRepColRepairStartDate).TextAlign = TextAlignEnum.LeftCenter          '故障発生日時
                    .Cols(CMlngvsfRepColRepairEndDate).TextAlign = TextAlignEnum.LeftCenter            '修理完了日時
                    .Cols(CMlngvsfRepColStopTime).TextAlign = TextAlignEnum.RightCenter                '停止時間
                    .Cols(CMlngvsfRepColToEmpName).TextAlign = TextAlignEnum.LeftCenter                '担当者
                    .Cols(CMlngvsfRepColFindEmpName).TextAlign = TextAlignEnum.LeftCenter              '起案者
                    .Cols(CMlngvsfRepColPreserverEmpName).TextAlign = TextAlignEnum.LeftCenter         '保全実施者
                    .Cols(CMlngvsfRepColEditTime) .TextAlign = TextAlignEnum.LeftCenter                '更新日時
                    .Cols(CMlngvsfRepColRepairContents).TextAlign = TextAlignEnum.LeftCenter           '故障現象詳細
                    .Cols(CMlngvsfRepColRepairAnalysisContents).TextAlign = TextAlignEnum.LeftCenter   '調査/分析詳細
                    .Cols(CMlngvsfRepColRepairCauseContents).TextAlign = TextAlignEnum.LeftCenter      '原因詳細
                    .Cols(CMlngvsfRepColRepairMeasureContents).TextAlign = TextAlignEnum.LeftCenter    '対策詳細
                    .Cols(CMlngvsfRepColAllRepairName).TextAlign = TextAlignEnum.LeftCenter            '故障現象名(全文)
                    .Cols(CMlngvsfRepColCopeDivision).TextAlign = TextAlignEnum.LeftCenter             '対応区分
                    .Cols(CMlngvsfRepColPartCost).TextAlign = TextAlignEnum.RightCenter                '部品費用
                    .Cols(CMlngvsfRepColWorkCost).TextAlign = TextAlignEnum.RightCenter                '作業費用
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    AddHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
                    AddHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange

                    '@ｿｰﾄ検索用ｷｰがある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                            '@故障発生日時と発行№が同じ場合
                            If .GetData(llngCnt, CMlngvsfRepColRepairNo) & _
                                .GetData(llngCnt, CMlngvsfRepColRepairStartDate) = _
                                mtypChgSort.strKey Then
                                
                                .Row = llngCnt
                                
                                '@=======================
                                '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                '@=======================
                                Call pubVsfBeforeSort(vsfMainteList, CMlngvsfRepColRepairNo & vbTab & CMlngvsfRepColRepairStartDate)
                                
                                '@=======================
                                '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                '@=======================
                                Call pubVsfAfterSort(vsfMainteList, CMlngvsfRepColRepairNo & vbTab & CMlngvsfRepColRepairStartDate,Nothing ,Nothing ,False, False, False, False)
                                
                                Exit For
                            End If
                        Next llngCnt
                    End If
                    
                    If llngRow > 0 And llngRow < .Rows.Count Then
                        .Row = llngRow
                    Else
                        .Row = 0
                    End If
                    .ScrollPosition = Scrollposition

                    '@行列のﾏｳｽでの変更を不可設定にする
                    .AllowResizing = AllowResizingEnum.None
                                
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                                
                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    '@=======================
                    '@　ｸﾞﾘｯﾄﾞの初期化処理
                    '@=======================
                    Call prvVsfRepairList_Init()
                End If
            End With

            '@該当件数
            lblDataCnt.Text = Format$(mlngRepairListCnt, CPstrDateFormatKanma)
            '@現在日時表示
            lblNowDate.Text = Format(Now, CPstrDateFormat)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfRepairList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/17 (Thu) 17:19:06 N.Kojima **************************************************
    '関数名：prvVsfPreserveList_Disp
    '機　能：保全記録票一覧の表示処理
    '引　数：mtypPreserveInfoAns  ：故障修理記録構造体
    '　　　：mlngPreserveListCnt  ：故障修理記録ﾘｽﾄ数
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 17:20:54 N.Kojima
    '更新日：2008/01/17 (Thu) 17:20:54
    '備　考：
    Private Sub prvVsfPreserveList_Disp()

        Dim lstrProcID                  As String       '担当者ID格納
        Dim lstrProcNM                  As String       '担当者名格納
        Dim lstrProcNMD                 As String       '担当者名格納表示用
        Dim llngDoCnt                   As Integer      '描画用ｶｳﾝﾄ
        Dim llngCnt                     As Integer      '担当者用ｶｳﾝﾄ
        Dim llngHeight                  As Integer      'ｽﾛｯﾄ高さ
        Dim llngRowCnt                  As Integer      '一行に含まれる行数
        Dim llngDurationMinute          As Decimal      '時間間隔(分)
        Dim lcurDurationHour            As Decimal      '時間間隔(時間)少数点
        Dim lstrPreserveNameChgSpace    As String       '実施項目(改行ｷｰ→空白変換)
        Dim lstrPreserveItem30          As String       '実施項目30ﾊﾞｲﾄ表示用
        Dim llngPreserveItemCnt         As Integer      '実施項目ｶｳﾝﾀ
        Dim llngRow                     As Integer      'NSYS 選択行格納
        Dim Scrollposition               As Point        'NSYS スクロール位置格納

        Try
            
            With vsfMainteList
                
                If mlngPreserveListCnt > 0 Then
                    '@格納ﾃﾞｰﾀがあるの場合

                    RemoveHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
                    RemoveHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange

                    llngRow = .Row
                    Scrollposition = .ScrollPosition

                    .Redraw = False                            '直接描画しない
                    .Clear(ClearFlags.UserData)             　'ｸﾘｱ
                    .Row = -1
                    .Rows.Count = mlngPreserveListCnt + 1     '行数設定
                    
                    '@故障修理記録情報を表示
                    For llngDoCnt = 1 To mlngPreserveListCnt
                        
                        '@№設定
                        .SetData(llngDoCnt, CMlngvsfPreColNo, llngDoCnt)
                        
                        '@状態ID(0:未処置、1:処置済、2:承認済)を設定
                        .SetData(llngDoCnt, CMlngvsfPreColPreserveStatusID, _
                            mtypPreserveInfoAns(llngDoCnt -1).strPreserveStatus)
                        
                        '@状態名(未処置、処置済、承認済)
                        '@★ 状態により処理分岐 ★
                        Select Case mtypPreserveInfoAns(llngDoCnt -1).strPreserveStatus
                            
                            '@〓 "0:未処置" 〓
                            Case CPstrZero
                            
                                .SetData(llngDoCnt, CMlngvsfPreColPreserveStatusName, CMstrNoDisposalFlag)   '未処置
                            
                            '@〓 "1:処置済み" 〓
                            Case CPstrOne
                                
                                .SetData(llngDoCnt, CMlngvsfPreColPreserveStatusName, CMstrDisposalFlag)     '処置済
                            
                            '@〓 "2:承認済み" 〓
                            Case CPstrTwo
                                
                                .SetData(llngDoCnt, CMlngvsfPreColPreserveStatusName, CMstrApplyFlag)        '承認済
                        End Select
                        
                        '@発行№
                        .SetData(llngDoCnt, CMlngvsfPreColPreserveNo, _
                            mtypPreserveInfoAns(llngDoCnt -1).strPreserveNo)
                        '@装置ID
                        .SetData(llngDoCnt, CMlngvsfPreColWpID, mtypPreserveInfoAns(llngDoCnt -1).strWpID)
                        '@装置名
                        .SetData(llngDoCnt, CMlngvsfPreColWpName, mtypPreserveInfoAns(llngDoCnt -1).strWpName)
                        
                        '@ｶﾃｺﾞﾘID
                        .SetData(llngDoCnt, CMlngvsfPreColCategoryID, mtypPreserveInfoAns(llngDoCnt -1).strCategoryID)
                        '@ｶﾃｺﾞﾘ名
                        .SetData(llngDoCnt, CMlngvsfPreColCategoryName, mtypPreserveInfoAns(llngDoCnt -1).strCategoryName)
                        '@保全ｶﾃｺﾞﾘID
                        .SetData(llngDoCnt, CMlngvsfPreColPreserveCategoryID, mtypPreserveInfoAns(llngDoCnt -1).strPreserveCategory)
                        
                        '@保全ｶﾃｺﾞﾘ名
                        '@★ 保全ｶﾃｺﾞﾘIDにより処理分岐 ★
                        Select Case .GetData(llngDoCnt, CMlngvsfPreColPreserveCategoryID)
                            
                            '@〓 "予防保全" 〓
                            Case CPstrOne

                                .SetData(llngDoCnt, CMlngvsfPreColPreserveCategoryName, CMstrPreserveCategoryName1)       '予防保全
                        
                            '@〓 "改良/改善保全" 〓
                            Case CPstrTwo

                                .SetData(llngDoCnt, CMlngvsfPreColPreserveCategoryName, CMstrPreserveCategoryName2)       '改良/改善保全
                        
                            '@〓 "ﾙｰﾁﾝﾒﾝﾃ" 〓
                            Case CPstrThree

                                .SetData(llngDoCnt, CMlngvsfPreColPreserveCategoryName, CMstrPreserveCategoryName3)       'ﾙｰﾁﾝﾒﾝﾃ
                        
                        End Select
                        
                        '@実施項目の改行ｷｰ変換(→Spaceへ変換)
                        lstrPreserveNameChgSpace = _
                            Replace$(mtypPreserveInfoAns(llngDoCnt -1).strPreserveItem, vbCrLf, Space$(1))
                        lstrPreserveItem30 = vbNullString
                        
                        For llngPreserveItemCnt = 1 To Len(lstrPreserveNameChgSpace)
                            '@30ﾊﾞｲﾄﾁｪｯｸ
                            If LenB(lstrPreserveItem30 & Mid$(lstrPreserveNameChgSpace, llngPreserveItemCnt, 1)) > CMlngDisplayByte30 Then
                                Exit For
                            Else
                                lstrPreserveItem30 = lstrPreserveItem30 & Mid$(lstrPreserveNameChgSpace, llngPreserveItemCnt, 1)
                            End If
                        Next llngPreserveItemCnt
                        '@実施項目(一部)(30byte)
                        .SetData(llngDoCnt, CMlngvsfPreColPreserveItem, lstrPreserveItem30)
                        '@実施項目(全文)
                        .SetData(llngDoCnt, CMlngvsfPreColPreserveItemAll, _
                            mtypPreserveInfoAns(llngDoCnt -1).strPreserveItem)
                        
                        '@(保全)開始(予定)日時
                        If IsDate(mtypPreserveInfoAns(llngDoCnt -1).strPreserveStartDate) Then
                            .SetData(llngDoCnt, CMlngvsfPreColStartDate, Format$(CDate(mtypPreserveInfoAns(llngDoCnt -1).strPreserveStartDate), CPstrDateTimeYMDHM))
                        Else
                            .SetData(llngDoCnt, CMlngvsfPreColStartDate, mtypPreserveInfoAns(llngDoCnt -1).strPreserveStartDate)
                        End If

                        '@(保全)終了(予定)日時
                        If IsDate(mtypPreserveInfoAns(llngDoCnt -1).strPreserveEndDate) Then
                            .SetData(llngDoCnt, CMlngvsfPreColEndDate, Format$(CDate(mtypPreserveInfoAns(llngDoCnt -1).strPreserveEndDate), CPstrDateTimeYMDHM))
                        Else
                            .SetData(llngDoCnt, CMlngvsfPreColEndDate, mtypPreserveInfoAns(llngDoCnt -1).strPreserveEndDate)
                        End If

                        '@停止時間(少数第2位迄)
                        '@(保全)開始(予定)日時が日付か
                        If IsDate(.GetData(llngDoCnt, CMlngvsfPreColStartDate)) = True Then
                            '@(保全)終了(予定)日時が日付か
                            If IsDate(.GetData(llngDoCnt, CMlngvsfPreColEndDate)) = True Then
                            
                                '@開始～終了までの時間間隔(分単位)を算出する
                                llngDurationMinute = DateDiff(CMstrDatediffMinute, .GetData(llngDoCnt, CMlngvsfPreColStartDate), _
                                                                                .GetData(llngDoCnt, CMlngvsfPreColEndDate))
                            Else
                                '@開始～現在までの時間間隔(分単位)を算出する
                                llngDurationMinute = DateDiff(CMstrDatediffMinute, .GetData(llngDoCnt, CMlngvsfPreColStartDate), _
                                                                                Format$(Now, CPstrDateTimeYMDHM))
                            End If
                            
                            '@時間へ変換する(少数第2位迄算出する為に100倍し、切捨て後、100で割る)
                            lcurDurationHour = Fix(llngDurationMinute / CMlngMinute60 * 100D) / 100D
                            
                            '@停止時間を設定する(#,##0.00)
                             .SetData(llngDoCnt, CMlngvsfPreColStopTime, Format$(lcurDurationHour, CPstrDoubleFormat2String))
                        Else
                            '@停止時間を未設定する
                             .SetData(llngDoCnt, CMlngvsfPreColStopTime, vbNullString)
                        End If
                        
                        '@担当者の格納処理
                        lstrProcID = vbNullString                                                       '退避領域初期化
                        lstrProcNM = vbNullString                                                       '退避領域初期化
                        lstrProcNMD = vbNullString                                                      '退避領域初期化
                        
                        For llngCnt = 0 To mtypPreserveInfoAns(llngDoCnt -1).lngEmpListCnt -1
                            If llngCnt = 0 Then
                                '@1件目の場合はそのまま変数へ格納
                                lstrProcID = mtypPreserveInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpID
                                
                                '@担当者名が,13バイト以上の場合か否かで追加処理
                                If LenB(mtypPreserveInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName) > CMlngEmpNameLenB13 Then
                                    '@13Byte以上
                                    lstrProcNM = LeftB(mtypPreserveInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName, CMlngEmpNameLenB12)
                                    lstrProcNM = lstrProcNM & CMstrEmpNameLenAfter
                                Else
                                '@13Btye以下
                                    lstrProcNM = mtypPreserveInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName
                                End If
                                
                                lstrProcNMD = lstrProcNM
                            Else
                                '@2件目以降は変数にｷｬﾘｯｼﾞﾘﾀｰﾝを入れて格納
                                lstrProcID = lstrProcID _
                                           & vbCrLf _
                                           & mtypPreserveInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpID
                                
                                '@担当者名が,13バイト以上の場合か否かで追加処理
                                If LenB(mtypPreserveInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName) > CMlngEmpNameLenB13 Then
                                '@13Byte以上
                                    lstrProcNM = Strings.Left(mtypPreserveInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName, CMlngEmpNameLenB12)
                                    lstrProcNM = lstrProcNM & CMstrEmpNameLenAfter
                                Else
                                '@13Btye以下
                                    lstrProcNM = mtypPreserveInfoAns(llngDoCnt -1).typEmpList(llngCnt).strEmpName
                                End If
                                
                                lstrProcNMD = lstrProcNMD _
                                            & vbCrLf _
                                            & lstrProcNM
                            End If
                        Next llngCnt
                        
                        '@担当者名
                        .SetData(llngDoCnt, CMlngvsfPreColToEmpName, lstrProcNMD)
                        
                        '@1件の保全記録票に含まれるﾛｯﾄと担当者の数を比較する
                        llngRowCnt = 0                                          '初期化
                        '@担当者数を格納
                        llngRowCnt = mtypPreserveInfoAns(llngDoCnt -1).lngEmpListCnt
                        
                        If llngRowCnt <> 0 Then
                            '@ｽﾛｯﾄの高さを設定する
                            llngHeight = CMlngVsfHeight * llngRowCnt
                            .Rows(llngDoCnt).Height = llngHeight
                        Else
                            '@ｽﾛｯﾄの高さを設定する
                            llngHeight = CMlngVsfHeight
                            .Rows(llngDoCnt).Height = llngHeight
                        End If
                        
                        '@保全実施者
                        .SetData(llngDoCnt, CMlngvsfPreColPreserverEmpName, mtypPreserveInfoAns(llngDoCnt -1).strPreserveEmpName)
                        '@更新日時
                        .SetData(llngDoCnt, CMlngvsfPreColEditTime, mtypPreserveInfoAns(llngDoCnt -1).strEditTime)

                        '@実施内容
                        .SetData(llngDoCnt, CMlngvsfPreColPreserveContents, _
                            mtypPreserveInfoAns(llngDoCnt -1).strPreserveContents)
                        '@実施理由/目的
                        .SetData(llngDoCnt, CMlngvsfPreColPreservePurpose, _
                            mtypPreserveInfoAns(llngDoCnt -1).strPreservePurpose)
                        '@保全担当ｻｲﾝID
                        .SetData(llngDoCnt, CMlngvsfPreColPreserveSignEmpID, _
                            mtypPreserveInfoAns(llngDoCnt -1).strPreserveSignEmpID)
                        '@保全ﾘｰﾀﾞｰｻｲﾝID
                        .SetData(llngDoCnt, CMlngvsfPreColPreserveLeaderSignEmpID, _
                            mtypPreserveInfoAns(llngDoCnt -1).strPreserveLeaderSignEmpID)
                        '@作業長ｻｲﾝID
                        .SetData(llngDoCnt, CMlngvsfPreColProductLeaderSignEmpID, _
                            mtypPreserveInfoAns(llngDoCnt -1).strProductLeaderSignEmpID)
                            
                        '@対応区分
                        '@対応区分が"1" or NULLか
                        If mtypPreserveInfoAns(llngDoCnt -1).strCopeDivision = CPstrOne Or _
                            mtypPreserveInfoAns(llngDoCnt -1).strCopeDivision = vbNullString Then
                            .SetData(llngDoCnt, CMlngvsfPreColCopeDivision, CMstrCopeDivision1)   '自主保全
                        Else
                            .SetData(llngDoCnt, CMlngvsfPreColCopeDivision, CMstrCopeDivision2)   'ﾒｰｶｰ保全
                        End If
                        
                        '@部品費用
                        If IsNumeric(mtypPreserveInfoAns(llngDoCnt -1).strPartCost) Then
                            .SetData(llngDoCnt, CMlngvsfPreColPartCost, _
                                Format$(CDec(mtypPreserveInfoAns(llngDoCnt -1).strPartCost), CPstrDateFormatKanma))
                        Else
                            .SetData(llngDoCnt, CMlngvsfPreColPartCost, _
                                mtypPreserveInfoAns(llngDoCnt -1).strPartCost)
                        End If

                        '@作業費用
                        If IsNumeric(mtypPreserveInfoAns(llngDoCnt -1).strWorkCost) Then
                            .SetData(llngDoCnt, CMlngvsfPreColWorkCost, _
                                Format$(CDec(mtypPreserveInfoAns(llngDoCnt -1).strWorkCost), CPstrDateFormatKanma))
                        Else
                            .SetData(llngDoCnt, CMlngvsfPreColWorkCost, _
                                mtypPreserveInfoAns(llngDoCnt -1).strWorkCost)
                        End If

                        '@「承認済」の場合
                        If .GetData(llngDoCnt, CMlngvsfPreColPreserveStatusID) = CPstrTwo Then
                            '@背景色を灰色にする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray" + llngDoCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfRowTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Else
                            '@背景色を白色にする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_Window" + llngDoCnt.ToString)
                            newStyle.BackColor = SystemColors.Window
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfRowTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        
                    Next llngDoCnt
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfPreColNo, .Cols.Count - 1, 6)
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfPreColNo).TextAlign = TextAlignEnum.RightCenter                      '№(右中央寄せ)
                    .Cols(CMlngvsfPreColPreserveStatusID).TextAlign = TextAlignEnum.LeftCenter         '状態ID(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveStatusName).TextAlign = TextAlignEnum.LeftCenter       '状態名(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveNo).TextAlign = TextAlignEnum.LeftCenter               '保全記録票№(左中央寄せ)
                    .Cols(CMlngvsfPreColWpID).TextAlign = TextAlignEnum.LeftCenter                     '装置ID(左中央寄せ)
                    .Cols(CMlngvsfPreColWpName).TextAlign = TextAlignEnum.LeftCenter                   '装置名(左中央寄せ)
                    .Cols(CMlngvsfPreColCategoryID).TextAlign = TextAlignEnum.LeftCenter               'ｶﾃｺﾞﾘID(左中央寄せ)
                    .Cols(CMlngvsfPreColCategoryName).TextAlign = TextAlignEnum.LeftCenter             'ｶﾃｺﾞﾘ名(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveCategoryID).TextAlign = TextAlignEnum.LeftCenter       '保全ｶﾃｺﾞﾘID(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveCategoryName).TextAlign = TextAlignEnum.LeftCenter     '保全ｶﾃｺﾞﾘ名(左中央寄せ)
                    .Cols(CMlngvsfPreColStartDate).TextAlign = TextAlignEnum.LeftCenter                '(保全)開始(予定)日時(左中央寄せ)
                    .Cols(CMlngvsfPreColEndDate).TextAlign = TextAlignEnum.LeftCenter                  '(保全)終了(予定)日時(左中央寄せ)
                    .Cols(CMlngvsfPreColStopTime).TextAlign = TextAlignEnum.RightCenter                '停止時間(右中央寄せ)
                    .Cols(CMlngvsfPreColToEmpName).TextAlign = TextAlignEnum.LeftCenter                '依頼先担当者名(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserverEmpName).TextAlign = TextAlignEnum.LeftCenter         '保全実施者名(左中央寄せ)
                    .Cols(CMlngvsfPreColEmpName).TextAlign = TextAlignEnum.LeftCenter                  '更新者(左中央寄せ)
                    .Cols(CMlngvsfPreColEditTime).TextAlign = TextAlignEnum.LeftCenter                 '更新日時(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveItem).TextAlign = TextAlignEnum.LeftCenter             '実施項目(一部)(30byte)(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveItemAll).TextAlign = TextAlignEnum.LeftCenter          '実施項目(全文)(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveContents).TextAlign = TextAlignEnum.LeftCenter         '実施内容(左中央寄せ)
                    .Cols(CMlngvsfPreColPreservePurpose).TextAlign = TextAlignEnum.LeftCenter          '実施理由/目的(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveSignEmpID).TextAlign = TextAlignEnum.LeftCenter        '保全担当ｻｲﾝID(左中央寄せ)
                    .Cols(CMlngvsfPreColPreserveLeaderSignEmpID).TextAlign = TextAlignEnum.LeftCenter  '保全ﾘｰﾀﾞｰｻｲﾝID(左中央寄せ)
                    .Cols(CMlngvsfPreColProductLeaderSignEmpID).TextAlign = TextAlignEnum.LeftCenter   '作業長ｻｲﾝID(左中央寄せ)
                    .Cols(CMlngvsfPreColCopeDivision).TextAlign = TextAlignEnum.LeftCenter             '対応区分(左中央寄せ)
                    .Cols(CMlngvsfPreColPartCost).TextAlign = TextAlignEnum.RightCenter                '部品費用(右中央寄せ)
                    .Cols(CMlngvsfPreColWorkCost).TextAlign = TextAlignEnum.RightCenter                '作業費用(右中央寄せ)
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    AddHandler vsfMainteList.BeforeRowColChange,AddressOf vsfMainteList_BeforeRowColChange
                    AddHandler vsfMainteList.RowColChange,AddressOf vsfMainteList_RowColChange

                    '@ｿｰﾄ検索用ｷｰがある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@(保全)開始(予定)日時と発行№が同じ場合
                            If .GetData(llngCnt, CMlngvsfPreColPreserveNo) & _
                                .GetData(llngCnt, CMlngvsfPreColStartDate) = mtypChgSort.strKey Then
                                
                                .Row = llngCnt
                                
                                '@=======================
                                '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)処理
                                '@=======================
                                Call pubVsfBeforeSort(vsfMainteList, CMlngvsfPreColPreserveNo & vbTab & CMlngvsfPreColStartDate)
                                
                                '@=======================
                                '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)処理
                                '@=======================
                                Call pubVsfAfterSort(vsfMainteList, CMlngvsfPreColPreserveNo & vbTab & CMlngvsfPreColStartDate,Nothing ,Nothing ,False, False, False, False)
                                
                                Exit For
                            End If
                        Next llngCnt
                    End If
                    
                    If llngRow > 0 And llngRow < .Rows.Count Then
                        .Row = llngRow
                    Else
                        .Row = 0
                    End If
                    .ScrollPosition = Scrollposition

                    '@行列のﾏｳｽでの変更を不可設定にする
                    .AllowResizing = AllowResizingEnum.None

                    '@描画ﾛｯｸ解除
                    .Redraw = True
                                
                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    '@=======================
                    '@　ｸﾞﾘｯﾄﾞの初期化処理
                    '@=======================
                    Call prvVsfPreserveList_Init()
                End If
            End With

            '@該当件数
            lblDataCnt.Text = Format$(mlngPreserveListCnt, CPstrDateFormatKanma)
            '@現在日時表示
            lblNowDate.Text = Format(Now, CPstrDateFormat)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfPreserveList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 17:19:06 N.Kojima **************************************************

    '関数名：prvCmbMcGroup_Init
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 16:19:39 N.Kojima
    '更新日：2007/01/16 (Tue) 16:19:39
    '備　考：
    Private Sub prvCmbMcGroup_Init()

        Try

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ
            With cmbMcGroup
                
                .Enabled = True                                         '有効
                .Clear                                                  'ｸﾘｱ
                .DirectInput = False                                    '直接入力不可
                .Height = CMlngCmbRowHeight                             '高さ
                .RowHeight = CMlngCmbRowHeight                          '高さ(行)
                .DispCols = CMlngCmbDispCols1                           'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ    
                .ValueCol = CMlngCmbValueCol1                           '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter   '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbMcGroup_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbMcGroup_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 16:19:39 N.Kojima
    '更新日：2007/01/16 (Tue) 16:19:39
    '備　考：
    Private Sub prvCmbMcGroup_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbMcGroup
                
                .Clear      'ｸﾘｱ
                
                '@装置ｸﾞﾙｰﾌﾟ情報ｾｯﾄ
                For llngCnt = 0 To mtypMcGroupList.lngMcGroupListCnt -1
                    .AddItem(mtypMcGroupList.typMcGroupList(llngCnt).strMcGroupName _
                           & vbTab _
                           & mtypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)
                Next llngCnt
                    
                '@ｺﾝﾎﾞの表示数を指定
                .GroupRows = mtypMcGroupList.lngMcGroupListCnt
                    
                '@装置ｸﾞﾙｰﾌﾟが1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
                
            End With
            
            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(cmbMcGroup)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbMcGroup_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbWp_Init
    '機　能：装置名ｺﾝﾎﾞ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 18:06:13 N.Kojima
    '更新日：2007/01/16 (Tue) 18:06:13
    '備　考：
    Private Sub prvCmbWp_Init()

        Try

            '@装置名ｺﾝﾎﾞ
            With cmbWp

                .Enabled = False                                        '無効
                .Clear                                                  'ｸﾘｱ
                .DirectInput = False                                    '直接入力不可
                .Height = CMlngCmbRowHeight                             '高さ
                .RowHeight = CMlngCmbRowHeight                          '高さ(行)
                .DispCols = CMlngCmbDispCols1                           'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ValueCol = CMlngCmbValueCol1                           '値取得列
                .SelectMode = 1                                         '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                 '全選択ﾎﾞﾀﾝ表示
                .GroupCols = CMlngCmbGroupCols                          '列方向のﾚｺｰﾄﾞ数
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter   '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbWp_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbWp_Disp
    '機　能：装置名ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/16 (Tue) 16:19:39 N.Kojima
    '更新日：2008/01/17 (Thu) 15:10:40 N.Kojima
    '備　考：
    '　　　：2008/01/17 (Thu) 15:10:40 N.Kojima     装置名ｺﾝﾎﾞの処理に不備があった為、処理修正。(案件№02332)
    Private Sub prvcmbWp_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbWp
                
                .Clear      'ｸﾘｱ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter           '左寄中央揃え
                
                '@装置名件数が1件か
                If mlngWpListCnt = 1 Then
                
                    .AddItem(mtypWpList(mlngWpListCnt -1).strWpName & vbTab & _
                              mtypWpList(mlngWpListCnt -1).strWpID & vbTab & _
                              mlngWpListCnt & vbTab & _
                              mtypWpList(mlngWpListCnt -1).strWpStatusName & vbTab & _
                              CMstrCmbCheckOn)                   '装置名/装置ID/現在のｶｳﾝﾄ数/装置状態/ﾁｪｯｸOFF
                              
                    '@"1 項目選択"を表示
                    .AddedComment = CMstrCmbSelect              '"XX 項目選択"
                    .Text = CPstrOne & CMstrCmbSelect           'XX部に項目数を格納
                Else
                    '@0件 or 複数存在する場合
                    
                    For llngCnt = 0 To mlngWpListCnt -1
                        .AddItem(mtypWpList(llngCnt).strWpName & vbTab & _
                                  mtypWpList(llngCnt).strWpID & vbTab & _
                                  llngCnt & vbTab & _
                                  mtypWpList(llngCnt).strWpStatusName & vbTab & _
                                  CMstrCmbCheckOff)              '装置名/装置ID/現在のｶｳﾝﾄ数/装置状態/ﾁｪｯｸOFF
                    Next llngCnt
                    
                    '@"0 項目選択"を表示
                    .AddedComment = CMstrCmbSelect              '"XX 項目選択"
                    .Text = CPstrZero & CMstrCmbSelect          'XX部に項目数を格納
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbWp_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/01/17 (Thu) 13:38:41 N.Kojima **************************************************
    '関数名：prvCmbCategory_Init
    '機　能：ｶﾃｺﾞﾘｺﾝﾎﾞ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 13:39:18 N.Kojima
    '更新日：2008/01/17 (Thu) 13:39:18
    '備　考：
    Private Sub prvCmbCategory_Init()

        Try

            '@ｶﾃｺﾞﾘｺﾝﾎﾞ
            With cmbCategory

                .Enabled = False                                        '無効
                .Clear                                                  'ｸﾘｱ
                .DirectInput = False                                    '直接入力不可
                .Height = CMlngCmbRowHeight                             '高さ
                .RowHeight = CMlngCmbRowHeight                          '高さ(行)
                .DispCols = CMlngCmbDispCols1                           'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ValueCol = CMlngCmbValueCol1                           '値取得列
                .SelectMode = 1                                         '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                 '全選択ﾎﾞﾀﾝ表示
                .GroupCols = CMlngCmbGroupCols                          '列方向のﾚｺｰﾄﾞ数
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter   '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbCategory_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 13:38:41 N.Kojima **************************************************

    '@↓2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************
    '関数名：prvCmbCategory_Disp
    '機　能：ｶﾃｺﾞﾘｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 15:10:40 N.Kojima
    '更新日：2008/01/17 (Thu) 15:10:40
    '備　考：
    Private Sub prvcmbCategory_Disp()

        Dim lblnAns                     As Boolean                       '結果格納
        Dim llngCnt                     As Integer                       'ﾙｰﾌﾟｶｳﾝﾀｰ
        Dim ltypMenteCategoryList       As List(Of MenteCategoryList)    'ｶﾃｺﾞﾘﾘｽﾄ格納用
        Dim llngMenteCategoryListCnt    As Integer                       'ｶﾃｺﾞﾘ数格納用

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvCmbCategoryDisp)
            
            '@ｶﾃｺﾞﾘ配列の初期化
            If ltypMenteCategoryList Is Nothing Then
                ltypMenteCategoryList = New List(Of MenteCategoryList)
            Else
                ltypMenteCategoryList.Clear
            End If
            llngMenteCategoryListCnt = 0

            
            '@【ｶﾃｺﾞﾘ取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasMenteCategoryList_Sel(CMstrmas_mentecategorylistVer, _
                                                     ltypMenteCategoryList, _
                                                     llngMenteCategoryListCnt)
                                                                                
            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                With cmbCategory
                    
                    '@初期設定
                    llngCnt = 0
                    .Clear          'ｸﾘｱ
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter           '左寄中央揃え
                    
                    '@************************
                    '@　ｶﾃｺﾞﾘｺﾝﾎﾞの内容をｾｯﾄ
                    '@************************
                    '@先頭に"ﾒﾝﾃ計画"を固定でｾｯﾄ
                    .AddItem(CMstrMaintenancePlan & vbTab & _
                             CPstrZero & vbTab & _
                             llngCnt & vbTab & _
                             vbNullString & vbTab & _
                             CMstrCmbCheckOn)                'ﾒﾝﾃ計画/ID=0/ｲﾝﾃﾞｯｸｽ/NULL/ﾁｪｯｸOn
            
                    '@取得ｶﾃｺﾞﾘをｾｯﾄ
                    For llngCnt = 0 To llngMenteCategoryListCnt -1
                        .AddItem(ltypMenteCategoryList(llngCnt).strUseName & vbTab & _
                                 ltypMenteCategoryList(llngCnt).strUseId & vbTab & _
                                 llngCnt + 1 & vbTab & _
                                 vbNullString & vbTab & _
                                 CMstrCmbCheckOff)           'ｶﾃｺﾞﾘ名/ｶﾃｺﾞﾘID/ｲﾝﾃﾞｯｸｽ/NULL/ﾁｪｯｸOFF
                    Next llngCnt
                    
                    .AddedComment = CMstrCmbSelect              '"XX 項目選択"
                    '@ﾃﾞﾌｫﾙﾄで"ﾒﾝﾃ計画"をﾁｪｯｸしておく仕様なので「1項目選択」とする
                    .Text = CPstrOne & CMstrCmbSelect           'XX部に項目数を格納
                End With
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvCmbCategoryDisp)
            Else
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvCmbCategoryDisp)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbCategory_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************

    '@↓2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************
    '関数名：prvMainteInfo_Sel
    '機　能：装置停止・ﾒﾝﾃ計画一覧　情報取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 15:10:40 N.Kojima
    '更新日：2008/01/17 (Thu) 16:44:11 N.Kojima
    '備　考：
    Private Sub prvMainteInfo_Sel()

        Dim lblnAns                 As Boolean              '戻り値格納用
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lvrnTemp                As Object               '一時格納領域
        Dim ltypEqStopMenteListReq  As EqStopMenteListReq   '装置停止・ﾒﾝﾃ計画一覧要求構造体

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvMainteInfoSel)
            
            '@******************
            '@　要求ﾃﾞｰﾀ作成
            '@******************
            With ltypEqStopMenteListReq
                
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstreq__schwpmentelistVer     'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        
                '@-------------------
                '@　ｶﾃｺﾞﾘ構造体作成
                '@-------------------
                .lngCategoryCnt = cmbCategory.ValueCount                'ｶﾃｺﾞﾘ選択数

                If .typCategoryList Is Nothing Then                     '配列再定義
                    .typCategoryList = New List(Of MasCategoryId)
                Else
                    .typCategoryList.Clear
                End If
                Dim typCategoryListTmp As New MasCategoryId

                If cmbCategory.ValueCount <> 0 Then
                    lvrnTemp = Split(cmbCategory.Value, vbTab)
                    For llngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                        typCategoryListTmp.strCategoryID = lvrnTemp(llngCnt)     'ｶﾃｺﾞﾘ
                        .typCategoryList.Add(typCategoryListTmp)
                    Next llngCnt
                Else
                    '@「0 項目選択」の場合
                    typCategoryListTmp.strCategoryID = vbNullString
                    .typCategoryList.Add(typCategoryListTmp)
                End If
                        
                '@-------------------------------------
                '@　処理区分、装置ｸﾞﾙｰﾌﾟ、装置IDの設定
                '@-------------------------------------
                If .typWpList Is Nothing Then               '配列再定義
                    .typWpList = New List(Of WpList)
                Else
                    .typWpList.Clear
                End If
                Dim typWpListTmp As New WpList

                '@装置ｸﾞﾙｰﾌﾟが未選択か
                If cmbMcGroup.Value = vbNullString Then
                    '@処理区分：全て
                    .strClassDivision = CPstrCD02
                    .strMcGroupID = vbNullString

                    '@「0 項目選択」の場合
                    typWpListTmp.strWpID = vbNullString
                    .typWpList.Add(typWpListTmp)
                Else
                    '@装置ｸﾞﾙｰﾌﾟが選択されている場合
                
                    '@装置名が未選択か
                    If cmbWp.Value = vbNullString Then
                        '@処理区分：装置ｸﾞﾙｰﾌﾟ指定
                        .strClassDivision = CPstrCD20               '処理区分=20
                        .strMcGroupID = cmbMcGroup.Value

                        '@「0 項目選択」の場合
                        typWpListTmp.strWpID = vbNullString
                        .typWpList.Add(typWpListTmp)
                    Else
                        '@装置名が選択されている場合
                    
                        '@処理区分：装置ID指定
                        .strClassDivision = CPstrCD26               '処理区分=26
                        .strMcGroupID = cmbMcGroup.Value
                        
                        '@一時格納領域の初期化
                        lvrnTemp = vbNullString
                        
                        '@-----------------
                        '@　装置構造体作成
                        '@-----------------
                        .lngWPCnt = cmbWp.ValueCount                '装置選択数
                                                
                        If cmbWp.ValueCount <> 0 Then
                            
                            lvrnTemp = Split(cmbWp.Value, vbTab)
                            For llngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                                typWpListTmp.strWpID = lvrnTemp(llngCnt)      '装置ID
                                .typWpList.Add(typWpListTmp)
                            Next llngCnt
                        Else
                            '@「0 項目選択」の場合
                            typWpListTmp.strWpID = vbNullString
                            .typWpList.Add(typWpListTmp)
                        End If
                    End If
                End If
                    
                '@------------
                '@　期間指定
                '@------------
                '@処理区分の設定
                .strClassDivision = .strClassDivision & CPstrCD3G      '期間指定する
                
                '@検索開始日の設定
                If IsDate(calStart.Value) = True Then
                    .strStartDate = calStart.Value
                Else
                    .strStartDate = vbNullString
                End If
                .strStartTime = CMstrMntStartTime
                
                '@検索終了日の設定
                If IsDate(calEnd.Value) = True Then
                    .strEndDate = calEnd.Value
                Else
                    .strEndDate = vbNullString
                End If
                .strEndTime = CMstrMntEndTime
            End With

            Me.KeyPreview = False
            
            '@【装置停止・ﾒﾝﾃ計画一覧取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqStopMenteList_Sel(ltypEqStopMenteListReq, mtypEqStopMenteListAns)

            Me.KeyPreview = True
            
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvMainteInfoSel)
                Exit Sub
            Else
                '@結果：正常の場合
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvMainteInfoSel)
                
                '@=======================
                '@　装置停止・ﾒﾝﾃ計画一覧の作成処理
                '@=======================
                Call prvVsfMainteList_Disp()
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMainteInfo_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************

    '@↓2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************
    '関数名：prvRepairInfo_Sel
    '機　能：故障修理記録一覧取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 15:10:40 N.Kojima
    '更新日：2008/01/17 (Thu) 16:44:11 N.Kojima
    '備　考：
    Private Sub prvRepairInfo_Sel()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lvrnTemp    As Object       '一時領域
        Dim lblnAns     As Boolean      '戻り値格納用

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvRepairInfoSel)

            '@******************
            '@　要求ﾃﾞｰﾀ作成
            '@******************
            With mtypRepairInfoReq
                
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrrep_repairlistVer                 'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strStartDate = calStart.Value & CMstrStartTime     '検索開始日
                .strEndDate = calEnd.Value & CMstrEndTime           '検索終了時間

                '@-----------------
                '@　装置構造体作成
                '@-----------------
                '@一時取得用変数の初期化
                lvrnTemp = vbNullString
                .lngWPCnt = cmbWp.ValueCount                        '装置選択数

                If .typWpList Is Nothing Then                       '配列再定義
                    .typWpList = New List(Of WP)
                Else
                    .typWpList.Clear
                End If
                Dim typWpListTmp As New WP

                If cmbWp.ValueCount <> 0 Then

                    lvrnTemp = Split(cmbWp.Value, vbTab)
                    For llngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                        typWpListTmp.strWpID = lvrnTemp(llngCnt)      '装置ID
                        .typWpList.Add(typWpListTmp)
                    Next llngCnt
                Else
                    '@「0 項目選択」の場合        
                    
                    typWpListTmp.strWpID = vbNullString
                    .typWpList.Add(typWpListTmp)
                End If
            End With

            Me.KeyPreview = False
            
            '@【故障修理記録票一覧取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnRepRepairList_Sel(mtypRepairInfoReq, _
                                              mtypRepairInfoAns, _
                                              mlngRepairListCnt)

            Me.KeyPreview = True
            
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvRepairInfoSel)
                Exit Sub
            Else
                '@結果：正常の場合
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvRepairInfoSel)
                
                '@=======================
                '@　故障修理記録一覧の作成処理
                '@=======================
                Call prvVsfRepairList_Disp()
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRepairInfo_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************

    '@↓2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************
    '関数名：prvPreserveInfo_Sel
    '機　能：保全記録一覧取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/17 (Thu) 15:10:40 N.Kojima
    '更新日：2008/01/17 (Thu) 16:44:11 N.Kojima
    '備　考：
    Private Sub prvPreserveInfo_Sel()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lvrnTemp    As Object       '一時格納領域
        Dim lblnAns     As Boolean      '戻り値格納用

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvPreserveInfoSel)

            '@******************
            '@　要求ﾃﾞｰﾀ作成
            '@******************
            With mtypPreserveInfoReq
                
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrpre_preservelistVer               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strStartDate = calStart.Value & CMstrStartTime     '検索開始日
                .strEndDate = calEnd.Value & CMstrEndTime           '検索終了時間
                
                '@-----------------
                '@　装置構造体作成
                '@-----------------
                '@一時取得用変数の初期化
                lvrnTemp = vbNullString
                .lngWPCnt = cmbWp.ValueCount                        '装置選択数
                If cmbWp.ValueCount <> 0 Then
                    '配列再定義
                    If .typWpList Is Nothing Then
                        .typWpList = New List(Of WP)
                    Else
                        .typWpList.Clear
                    End If
                    Dim typWpListTmp As New WP

                    lvrnTemp = Split(cmbWp.Value, vbTab)
                    For llngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                        typWpListTmp.strWpID = lvrnTemp(llngCnt)      '装置ID
                        .typWpList.Add(typWpListTmp)
                    Next llngCnt
                Else
                    '@「0 項目選択」の場合
                    '配列再定義
                    If .typWpList Is Nothing Then
                        .typWpList = New List(Of WP)
                    Else
                        .typWpList.Clear
                    End If
                    Dim typWpListTmp As New WP
                    typWpListTmp.strWpID = vbNullString
                    .typWpList.Add(typWpListTmp)
                End If
                
                '@------------------
                '@　ｶﾃｺﾞﾘ構造体作成
                '@------------------
        '        '@一時取得用変数の初期化
        '        lvrnTemp = vbNullString
        '        .lngCategoryCnt = cmbCategory.ValueCount            'ｶﾃｺﾞﾘ選択数
        '        If cmbCategory.ValueCount <> 0 Then
        '            ReDim Preserve .typCategoryList(.lngCategoryCnt)                        '配列再定義
        '            lvrnTemp = Split(cmbCategory.Value, vbTab)
        '            For llngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
        '                .typCategoryList(llngCnt + 1).strCategoryID = lvrnTemp(llngCnt)     'ｶﾃｺﾞﾘ
        '            Next llngCnt
        '        Else
        '            '@「0 項目選択」の場合
        '            ReDim Preserve .typCategoryList(1)              '配列再定義
        '            .typCategoryList(1).strCategoryID = vbNullString
        '        End If
                '@複数ｶﾃｺﾞﾘ指定で検索したい場合は上記ｺｰﾄﾞを使用。
                '@「MCUSE0005=計画保全」をｾｯﾄ
                .lngCategoryCnt = CPlngNumOne                        'ｶﾃｺﾞﾘ選択数=1
                '配列再定義=1
                If .typCategoryList Is Nothing Then
                    .typCategoryList = New List(Of MasCategoryId)
                Else
                    .typCategoryList.Clear
                End If
                Dim typCategoryListTmp As New MasCategoryId
                typCategoryListTmp.strCategoryID = CPstrMcUseIDPlanMnt
                .typCategoryList.Add(typCategoryListTmp)
            End With

            Me.KeyPreview = False
            
            '@【保全記録票一覧取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnPrePreserveList_Sel(mtypPreserveInfoReq, _
                                                mtypPreserveInfoAns, _
                                                mlngPreserveListCnt)

            Me.KeyPreview = True
            
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvPreserveInfoSel)
                Exit Sub
            Else
                '@結果：正常の場合
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvPreserveInfoSel)
                
                '@=======================
                '@　保全記録一覧の作成処理
                '@=======================
                Call prvVsfPreserveList_Disp()
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPreserveInfo_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************

    '@↓2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************
    '関数名：prvApprove_Chk
    '機　能：承認ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True:ﾁｪｯｸOK、False:ﾁｪｯｸNG
    '作成日：2008/01/18 (Fri) 12:02:44 N.Kojima
    '更新日：2008/01/18 (Fri) 12:02:44
    '備　考：
    Private Function prvApprove_Chk() As Boolean

        Dim lblnErrFlag     As Boolean          'ｴﾗｰ判定ﾌﾗｸﾞ(True:ｴﾗｰあり、False:ｴﾗｰなし)
        Dim lstrErrItem     As String           'ｴﾗｰ項目格納用

        Try

            '@戻り値の初期化
            prvApprove_Chk = False

            '@ｴﾗｰ判定ﾌﾗｸﾞの初期化
            lblnErrFlag = False

            With vsfMainteList
                
                '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
                Select Case mlngOptSelectFlag
                    
                    '@〓 "1:故障修理記録" 〓
                    Case CPlngNumOne

                        '@故障現象名(一部)がNULLか
                        If .GetData(.Row, CMlngvsfRepColRepairName) = vbNullString Then
                            
                            '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                            lstrErrItem = CMstrvsfRepColTRepairName             'ｴﾗｰ項目    ："故障現象名"
                            lblnErrFlag = True                                  'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                        End If
                        
                        '@原因詳細がNULL、かつｴﾗｰ判定ﾌﾗｸﾞが"False:ｴﾗｰなし"か
                        If .GetData(.Row, CMlngvsfRepColRepairCauseContents) = vbNullString And _
                            lblnErrFlag = False Then
                            
                            '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                            lstrErrItem = CMstrvsfRepColTRepairCauseContents    'ｴﾗｰ項目    ："原因詳細"
                            lblnErrFlag = True                                  'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                        End If
                        
                        '@対策詳細がNULLか
                        If .GetData(.Row, CMlngvsfRepColRepairMeasureContents) = vbNullString And _
                            lblnErrFlag = False Then
                            
                            '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                            lstrErrItem = CMstrvsfRepColTRepairMeasureContents  'ｴﾗｰ項目    ："対策詳細"
                            lblnErrFlag = True                                  'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                        End If
                        
                        '@ｴﾗｰ項目があったか
                        If lblnErrFlag = True Then
                        
                            '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009B, lstrErrItem)
                            '@"<TRM9BW>$$[%1]が登録されていません。$[編集]ﾎﾞﾀﾝ押下で[装置メンテナンス記録票]画面を起動し、
                            '@ $[%1]を入力してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@編集ﾎﾞﾀﾝが有効なら編集ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            If cmdEdit.Enabled = True Then
                                Call pubSetFocus(cmdEdit)
                            End If
                            
                            Exit Function
                        End If
                        
                        
                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo
                    
                        '@実施項目(一部)がNULLか
                        If .GetData(.Row, CMlngvsfPreColPreserveItem) = vbNullString Then

                            '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                            lstrErrItem = CMstrvsfPreColTPreserveItem       'ｴﾗｰ項目    ："実施項目"
                            lblnErrFlag = True                              'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                        End If
                        
                        '@********************
                        '@　保全ｶﾃｺﾞﾘ別処理
                        '@********************
                        '@保全ｶﾃｺﾞﾘが"3:ﾙｰﾁﾝﾒﾝﾃ"以外か
                        If .GetData(.Row, CMlngvsfPreColPreserveCategoryID) <> CPstrThree Then
                            
                            '@---------------------
                            '@　ﾙｰﾁﾝﾒﾝﾃ以外の場合
                            '@　(予防保全,改良改善保全)
                            '@---------------------
                    
                            '@実施内容がNULLか
                            If .GetData(.Row, CMlngvsfPreColPreserveContents) = vbNullString And _
                                lblnErrFlag = False Then
                                
                                '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                                lstrErrItem = CMstrvsfPreColTPreserveContents       'ｴﾗｰ項目    ："実施内容"
                                lblnErrFlag = True                                  'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                            End If
                        
                            '@実施目的/理由がNULLか
                            If .GetData(.Row, CMlngvsfPreColPreservePurpose) = vbNullString And _
                                lblnErrFlag = False Then
                                
                                '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                                lstrErrItem = CMstrvsfPreColTPreservePurpose        'ｴﾗｰ項目    ："実施目的/理由"
                                lblnErrFlag = True                                  'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                            End If
                            
                            '@保全担当ｻｲﾝIDがNULLか
                            If .GetData(.Row, CMlngvsfPreColPreserveSignEmpID) = vbNullString And _
                                lblnErrFlag = False Then
                                
                                '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                                lstrErrItem = CMstrvsfPreColTPreserveSignEmpID          'ｴﾗｰ項目    ："保全担当ｻｲﾝ"
                                lblnErrFlag = True                                      'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                            End If
                            
                            '@保全ﾘｰﾀﾞｰｻｲﾝIDがNULLか
                            If .GetData(.Row, CMlngvsfPreColPreserveLeaderSignEmpID) = vbNullString And _
                                lblnErrFlag = False Then
                                
                                '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                                lstrErrItem = CMstrvsfPreColTPreserveLeaderSignEmpID    'ｴﾗｰ項目    ："保全ﾘｰﾀﾞｰｻｲﾝ"
                                lblnErrFlag = True                                      'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                            End If
                            
                            '@作業長ｻｲﾝIDがNULLか
                            If .GetData(.Row, CMlngvsfPreColProductLeaderSignEmpID) = vbNullString And _
                                lblnErrFlag = False Then
                                
                                '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                                lstrErrItem = CMstrvsfPreColTProductLeaderSignEmpID     'ｴﾗｰ項目    ："作業長ｻｲﾝ"
                                lblnErrFlag = True                                      'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                            End If
                        End If
                        
                        '@ｴﾗｰ項目があったか
                        If lblnErrFlag = True Then
                        
                            '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009B, lstrErrItem)
                            '@"<TRM9BW>$$[%1]が登録されていません。$[編集]ﾎﾞﾀﾝ押下で[装置メンテナンス記録票]画面を起動し、
                            '@ $[%1]を入力してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@編集ﾎﾞﾀﾝが有効なら編集ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            If cmdEdit.Enabled = True Then
                                Call pubSetFocus(cmdEdit)
                            End If
                            
                            Exit Function
                        End If
                        
                End Select
            End With
            
            '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄする
            prvApprove_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvApprove_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2008/01/17 (Thu) 15:15:24 N.Kojima **************************************************

    '@↓2008/01/25 (Fri) 12:45:39 N.Kojima **************************************************
    '関数名：prvCmdButtonControl_Proc
    '機　能：各種ﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：True:ﾁｪｯｸOK、False:ﾁｪｯｸNG
    '作成日：2008/01/18 (Fri) 12:02:44 N.Kojima
    '更新日：2008/01/18 (Fri) 12:02:44
    '備　考：
    Private Sub prvCmdButtonControl_Proc()

        Try

            '@各種ﾎﾞﾀﾝの無効化
            cmdSearch.Enabled = False           '検索ﾎﾞﾀﾝ
            cmdEdit.Enabled = False             '編集(修正)ﾎﾞﾀﾝ
            cmdApprove.Enabled = False          '承認ﾎﾞﾀﾝ
            cmdDiscon.Enabled = False           '破棄(削除)ﾎﾞﾀﾝ
            cmdMailSend.Enabled = False         '確認依頼ﾎﾞﾀﾝ
            cmdCopyInsert.Enabled = False       'ｺﾋﾟｰ登録ﾎﾞﾀﾝ
            cmdCopy.Enabled = False             'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdButtonControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/01/25 (Fri) 12:45:39 N.Kojima **************************************************

    '@↓2008/01/25 (Fri) 12:45:39 N.Kojima **************************************************
    '関数名：prvSearchCondition_Chk
    '機　能：検索条件ﾁｪｯｸ処理
    '引　数：lstrControlMode    ：制御ﾓｰﾄﾞ
    '戻り値：True:ﾁｪｯｸOK、False:ﾁｪｯｸNG
    '作成日：2008/01/18 (Fri) 12:02:44 N.Kojima
    '更新日：2008/01/18 (Fri) 12:02:44
    '備　考：
    Private Function prvSearchCondition_Chk(ByVal lstrControlMode As String) As Boolean

        Try

            '@戻り値の初期化
            prvSearchCondition_Chk = False

            '@装置ｸﾞﾙｰﾌﾟが未選択か
            If cmbMcGroup.Value = vbNullString Then
                
                '@制御ﾓｰﾄﾞが"検索ﾎﾞﾀﾝ制御"以外か
                If lstrControlMode <> CMstrSeachButtonControlMode Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblMcGroupTitle.Text)
                    '@"<TRM0WW>$$[装置グループ]が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@装置ｸﾞﾙｰﾌﾟにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbMcGroup)
                End If
                
                Exit Function
            End If
            
            '@装置名が未選択(0 項目選択)か
            If cmbWp.Text = CPstrZero & CMstrCmbSelect Then
                
                '@制御ﾓｰﾄﾞが"検索ﾎﾞﾀﾝ制御"以外か
                If lstrControlMode <> CMstrSeachButtonControlMode Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblWpTitle.Text)
                    '@"<TRM0WW>$$[装置名]が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@装置名にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWp)
                End If
                
                Exit Function
            End If
            
            '@ｶﾃｺﾞﾘが未選択(0 項目選択)か
            If cmbCategory.Text = CPstrZero & CMstrCmbSelect Then
                
                '@制御ﾓｰﾄﾞが"検索ﾎﾞﾀﾝ制御"以外か
                If lstrControlMode <> CMstrSeachButtonControlMode Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblCategoryTitle.Text)
                    '@"<TRM0WW>$$[カテゴリ]が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｶﾃｺﾞﾘにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbCategory)
                End If
                
                Exit Function
            End If
            
            '@検索開始日が未選択か
            If calStart.Value = CPstrNullDate Then

                '@制御ﾓｰﾄﾞが"検索ﾎﾞﾀﾝ制御"以外か
                If lstrControlMode <> CMstrSeachButtonControlMode Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblFromTitle.Text)
                    '@"<TRM0WW>$$[検索開始日]が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@検索開始日にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calStart)
                End If
                
                Exit Function
            End If
            
            '@検索終了日が未選択か
            If calEnd.Value = CPstrNullDate Then

                '@制御ﾓｰﾄﾞが"検索ﾎﾞﾀﾝ制御"以外か
                If lstrControlMode <> CMstrSeachButtonControlMode Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblToTitle.Text)
                    '@"<TRM0WW>$$[検索終了日]が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@検索終了日にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calEnd)
                End If
                
                Exit Function
            End If
            
            '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄする
            prvSearchCondition_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSearchCondition_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2008/01/25 (Fri) 12:45:39 N.Kojima **************************************************


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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfMainteList.BeforeDoubleClick

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

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                        cmdDown.Enter, 
                                                                        cmdUp.Enter, 
                                                                        cmdCopyInsert.Enter, 
                                                                        optSelectMode2.Enter, 
                                                                        cmdSearch.Enter, 
                                                                        optSelectMode1.Enter, 
                                                                        optSelectMode0.Enter, 
                                                                        cmdNewEntry.Enter, 
                                                                        cmdCopy.Enter, 
                                                                        cmdMailSend.Enter, 
                                                                        cmdDiscon.Enter, 
                                                                        vsfMainteList.Enter, 
                                                                        cmdApprove.Enter, 
                                                                        cmdEdit.Enter, 
                                                                        cmdClose.Enter, 
                                                                        txtInformation.Enter, 
                                                                        calStart.Enter, 
                                                                        calEnd.Enter, 
                                                                        cmbMcGroup.Enter, 
                                                                        cmbWP.Enter, 
                                                                        cmbCategory.Enter 
            

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
