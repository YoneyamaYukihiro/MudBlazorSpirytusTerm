'ﾌｧｲﾙ名：xxMN0000.bas ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾒﾆｭｰ画面標準ﾓｼﾞｭｰﾙ
'作成日：2004/05/06 (Thu) 17:10:21 H.Wajima
'更新日：2019/07/03 (Wed) 16:03:14 T.Oide
'　　　："★★★ ﾒﾆｭｰ項目追加時変更対象処理 ★★★"の記述があるものに適宜修正が必要です。
'　　　：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports TFLib
Imports C1.Win.C1FlexGrid
Imports System.Windows.Forms
Public Module basxxMN0000
    '******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '******************************************************************************
    '================================== Public ====================================

    '******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '******************************************************************************
    '================================== Public ====================================
    Public Const CPlngMenuGridPageRows          As Integer = 14                     'ｸﾞﾘｯﾄﾞのﾍﾟｰｼﾞあたりの行数
    Public Const CPlngMenuGridRowHeight         As Integer = 38                     'ｸﾞﾘｯﾄﾞの行高さ
    Public Const CPlngMenuGridCols              As Integer = 4                      'ｸﾞﾘｯﾄﾞのCols

    Public Const CPlngMenuKeyColWidth           As Integer = 38                     'ｷｰ列の幅
    Public Const CPlngMenuGridButtonSize        As Integer = 40                     'ﾎﾞﾀﾝの1辺の長さ

    Public Const CPlngMenuVSFlexGridUnChoosing  As Integer = -1                     'VSFlexGrid非選択状態

    Public Const CPlngMenuTitleColWidth         As Integer = 367                    'ﾀｲﾄﾙ列の幅

    Public Const CPlngFavoritesEditCaptionSpace As String = "　〓〓〓空白行〓〓〓"    'お気に入り編集用空白行

    '******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '******************************************************************************
    '================================== Private ===================================
    '@装置別ﾛｯﾄ一覧用
    Private Const CMlngxxEN0150Index            As Integer = 2                      'ﾛｯﾄ一覧(工程別)起動ｲﾝﾃﾞｯｸｽ

    '@保留・保留解除用
    Private Const CMlngClassDivisionHold        As Integer = 0                      '起動区分
    Private Const CMlngClassDivisionHoldRelease As Integer = 1                      '起動区分

    '@投入予定ﾛｯﾄ登録、分割予定ﾛｯﾄ登録用
    Private Const CMlngLotThrow                 As Integer = 0                      '投入予定ﾛｯﾄ登録
    Private Const CMlngLotDivide                As Integer = 1                      '分割予定ﾛｯﾄ登録

    '******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '******************************************************************************
    '================================== Public ====================================
    '@ｸﾞﾘｯﾄﾞのToolTip用
    Public plngMenuLastMouseRow                 As Integer                          '前回ﾏｳｽ行
    Public plngMenuLastMouseCol                 As Integer                          '前回ﾏｳｽ列
    '******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '******************************************************************************
    '================================== Public ====================================

    '******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
    '******************************************************************************
    '================================== Public ====================================
    '関数名：publngStart_Proc
    '機　能：共通起動関数
    '引　数：lstrMenuKey        ：ﾒﾆｭｰｷｰ(機能ID)
    '　　　：lblnSingleStartFlg ：単体起動ﾌﾗｸﾞ／True:単体起動、False:ﾒﾆｭｰ起動
    '　　　：ltypcommoninfo     ：引継ぎ情報構造体
    '戻り値：正常時：CPlngNormalStatusCD(0：ﾌﾟﾛｸﾞﾗﾑ正常終了ｺｰﾄﾞ)
    '　　　：異常時：CPlngErrorStatusCD(vbObjectError + 513：ﾌﾟﾛｸﾞﾗﾑ異常終了ｺｰﾄﾞ)
    '作成日：2004/04/20 (Tue) 10:40:13 H.Wajima
    '更新日：2019/07/03 (Wed) 16:02:13 T.Oide
    '備　考：★★★ ﾒﾆｭｰ項目追加時変更対象処理 ★★★
    Public Function publngStart_Proc(ByVal lstrMenuKey As String, _
                                     ByVal lblnSingleStartFlg As Boolean, _
                                     ByRef ltypCommonInfo As CommonInfo, _
                                     ByVal lfrmOwner As Form) As Integer

        Dim lstrFormTitle           As String       'ﾌｫｰﾑﾀｲﾄﾙ
        Dim llngCarrTakeOver        As Integer      '引継ぎﾌﾗｸﾞ
        Dim lstrFormName            As String       'ﾌｫｰﾑ名
        Dim ltypOnErrorInfo         As OnErrorInfo  '初期化用構造体
        Dim lfrmStartForm           As Form         'NSYS 起動するフォームのオブジェクト
        
        '@ｴﾗｰ情報設定格納構造体の初期化
        ptypOnErrorInfo = ltypOnErrorInfo

        '@関数の戻り値にｴﾗｰ定数を設定(vbObjectError + 513：ﾌﾟﾛｸﾞﾗﾑ異常終了ｺｰﾄﾞ)
        publngStart_Proc = CPlngErrorStatusCD

        '@ACT起動ﾌﾗｸﾞの退避
        pblnActInitFlg = lblnSingleStartFlg

        '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
        pblnFormLoad = False

        '@★ 引数のﾒﾆｭｰｷｰにより処理分岐(Loadﾌｫｰﾑを選択) ★
        Select Case lstrMenuKey

            '@〓 お知らせ 〓
            Case CPstrKeyMN0002

                frmxxMN0002.Instance = New frmxxMN0002
                lfrmStartForm = frmxxMN0002.Instance

            '@〓 投入予定ﾛｯﾄ登録 〓
            Case CPstrKeyEN0020

                '@起動区分設定(0：投入予定ﾛｯﾄ登録)
                plngfrmxxCM00M0Kbn = CMlngLotThrow
                frmxxCM00M0.Instance = New frmxxCM00M0
                lfrmStartForm = frmxxCM00M0.Instance

            '@〓 作業開始 〓
            Case CPstrKeyEN0030

                frmxxEN0030.Instance = New frmxxEN0030
                lfrmStartForm = frmxxEN0030.Instance

            '@〓 ﾛｯﾄ投入(基板) 〓
            Case CPstrKeyEN0040

                frmxxEN0040.Instance = New frmxxEN0040
                lfrmStartForm = frmxxEN0040.Instance

            '@〓 ﾛｯﾄ保留 〓
            Case CPstrKeyEN0050

                '@起動区分設定(0：ﾛｯﾄ保留)
                plngfrmxxCM0120Kbn = CMlngClassDivisionHold
                frmxxCM0120.Instance = New frmxxCM0120
                lfrmStartForm = frmxxCM0120.Instance

            '@〓 作業終了 〓
            Case CPstrKeyEN0060

                frmxxEN0060.Instance = New frmxxEN0060
                lfrmStartForm = frmxxEN0060.Instance

            '@〓 処理開始 〓
            Case CPstrKeyEN0070

                frmxxEN0070.Instance = New frmxxEN0070
                lfrmStartForm = frmxxEN0070.Instance

            '@〓 処理終了 〓
            Case CPstrKeyEN0080

                frmxxEN0080.Instance = New frmxxEN0080
                lfrmStartForm = frmxxEN0080.Instance

            '@〓 ﾛｯﾄ保留解除 〓
            Case CPstrKeyEN00A0

                '@起動区分設定(1：ﾛｯﾄ保留解除)
                plngfrmxxCM0120Kbn = CMlngClassDivisionHoldRelease
                frmxxCM0120.Instance = New frmxxCM0120
                lfrmStartForm = frmxxCM0120.Instance

            '@〓 CFﾛｯﾄ編成 〓
            Case CPstrKeyEN00B0

                frmxxEN00B0.Instance = New frmxxEN00B0
                lfrmStartForm = frmxxEN00B0.Instance

            '@〓 運用ﾓｰﾄﾞ変更/装置状態変更 〓
            Case CPstrKeyEN00C0

                frmxxEN00C0.Instance = New frmxxEN00C0
                lfrmStartForm = frmxxEN00C0.Instance

    '@↓2019/07/03 (Wed) 16:01:55 T.Oide **************************************************
    '@        '@〓 ﾗﾋﾞﾝｸﾞﾛｰﾙ管理 〓
    '@        Case CPstrKeyEN00D0
    '@
    '@            Load frmxxEN00D0
    '@↑2019/07/03 (Wed) 16:01:55 T.Oide **************************************************

            '@〓 CFKI作業終了 〓
            Case CPstrKeyEN00E0

                frmxxCM00A0.Instance = New frmxxCM00A0
                lfrmStartForm = frmxxCM00A0.Instance

            '@〓 在庫管理 〓
            Case CPstrKeyEN00F0

                frmxxEN00F0.Instance = New frmxxEN00F0
                lfrmStartForm = frmxxEN00F0.Instance

            '@〓 ｷｬﾘｱ管理 〓
            Case CPstrKeyEN00G0

                frmxxCM00C0.Instance = New frmxxCM00C0
                lfrmStartForm = frmxxCM00C0.Instance

            '@〓 対向基板処置登録 〓
            Case CPstrKeyEN00H0

                frmxxCM00B0.Instance = New frmxxCM00B0
                lfrmStartForm = frmxxCM00B0.Instance

            '@〓 ﾊﾞｯﾁ作業開始 〓
            Case CPstrKeyEN00I0

                frmxxEN00I0.Instance = New frmxxEN00I0
                lfrmStartForm = frmxxEN00I0.Instance

            '@〓 装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧 〓
            Case CPstrKeyEN00J0

                frmxxEN00J0.Instance = New frmxxEN00J0
                lfrmStartForm = frmxxEN00J0.Instance

            '@〓 ﾊﾞｯﾁ作業終了 〓
            Case CPstrKeyEN00K0

                frmxxEN00K0.Instance = New frmxxEN00K0
                lfrmStartForm = frmxxEN00K0.Instance

            '@〓 ﾊﾞｯﾁ処理開始 〓
            Case CPstrKeyEN00L0

                frmxxEN00L0.Instance = New frmxxEN00L0
                lfrmStartForm = frmxxEN00L0.Instance

            '@〓 ﾊﾞｯﾁ管理 〓
            Case CPstrKeyEN00M0

                frmxxEN00M0.Instance = New frmxxEN00M0
                lfrmStartForm = frmxxEN00M0.Instance

            '@〓 ﾊﾞｯﾁ処理終了 〓
            Case CPstrKeyEN00N0

                frmxxEN00N0.Instance = New frmxxEN00N0
                lfrmStartForm = frmxxEN00N0.Instance

            '@〓 投入予定登録(品確･ﾓﾆﾀｰ･ﾀﾞﾐｰ) 〓
            Case CPstrKeyEN00O0

                frmxxEN00O0.Instance = New frmxxEN00O0
                lfrmStartForm = frmxxEN00O0.Instance

            '@〓 投入予定ﾛｯﾄ一覧 〓
            Case CPstrKeyEN00P0

                frmxxCM0090.Instance = New frmxxCM0090
                lfrmStartForm = frmxxCM0090.Instance

            '@〓 ﾛｯﾄ投入(組立) 〓
            Case CPstrKeyEN00Q0

                frmxxEN00Q0.Instance = New frmxxEN00Q0
                lfrmStartForm = frmxxEN00Q0.Instance

            '@〓 ﾀﾞﾐｰ Load/Unload/再投入 〓
            Case CPstrKeyEN00R0

                frmxxEN00R0.Instance = New frmxxEN00R0
                lfrmStartForm = frmxxEN00R0.Instance

            '@〓 ﾚｼﾋﾟ設定変更 〓
            Case CPstrKeyEN00S0

                frmxxCM0050.Instance = New frmxxCM0050
                lfrmStartForm = frmxxCM0050.Instance

            '@〓 装置ﾃﾞｰﾀ参照/登録 〓
            Case CPstrKeyEN00T0

                frmxxCM00G0.Instance = New frmxxCM00G0
                lfrmStartForm = frmxxCM00G0.Instance

            '@〓 工程異常/不適合品処理票登録 〓
            Case CPstrKeyEN00U0

                frmxxCM00I0.Instance = New frmxxCM00I0
                lfrmStartForm = frmxxCM00I0.Instance

            '@〓 工程異常/不適合品処理票一覧 〓
            Case CPstrKeyEN00V0

                frmxxEN00V0.Instance = New frmxxEN00V0
                lfrmStartForm = frmxxEN00V0.Instance

            '@〓 投入予定工順登録(組立) 〓
            Case CPstrKeyEN00X0

                frmxxEN00X0.Instance = New frmxxEN00X0
                lfrmStartForm = frmxxEN00X0.Instance

            '@〓 特殊流動(ﾘﾜｰｸ・追加・先行) 〓
            Case CPstrKeyEN00Y0

                frmxxEN00Y0.Instance = New frmxxEN00Y0
                lfrmStartForm = frmxxEN00Y0.Instance

            '@〓 ﾚﾁｸﾙ管理 〓
            Case CPstrKeyEN00Z0

                frmxxEN00Z0.Instance = New frmxxEN00Z0
                lfrmStartForm = frmxxEN00Z0.Instance

            '@〓 次工程送出 〓
            Case CPstrKeyEN0100

                frmxxEN0100.Instance = New frmxxEN0100
                lfrmStartForm = frmxxEN0100.Instance

            '@〓 装置状態変更 〓
            Case CPstrKeyEN0110

                frmxxEN0110.Instance = New frmxxEN0110
                lfrmStartForm = frmxxEN0110.Instance

            '@〓 ﾛｯﾄ編成(保留/払出WF) 〓
            Case CPstrKeyEN0120

                frmxxEN0120.Instance = New frmxxEN0120
                lfrmStartForm = frmxxEN0120.Instance

            '@〓 作業開始取消/処理開始取消 〓
            Case CPstrKeyEN0130

                frmxxEN0130.Instance = New frmxxEN0130
                lfrmStartForm = frmxxEN0130.Instance

            '@〓 ﾛｯﾄｺﾒﾝﾄ 〓
            Case CPstrKeyEN0140

                frmxxCM0030.Instance = New frmxxCM0030
                lfrmStartForm = frmxxCM0030.Instance

            '@〓 装置別ﾛｯﾄ一覧 〓
            Case CPstrKeyEN0150

                frmxxEN0150.Instance = New frmxxEN0150
                lfrmStartForm = frmxxEN0150.Instance
            
    '@↓2018/08/09 (Thu) 11:03:49 Y.Yoneyama **************************************************
            '@〓 装置別ﾛｯﾄ一覧(防湿ALD) 〓
            Case CPstrKeyEN0151

                frmxxEN0151.Instance = New frmxxEN0151
                lfrmStartForm = frmxxEN0151.Instance
    '@↑2018/08/09 (Thu) 11:03:49 Y.Yoneyama **************************************************

            '@〓 ﾛｯﾄ分割 〓
            Case CPstrKeyEN0160

                frmxxEN0160.Instance = New frmxxEN0160
                lfrmStartForm = frmxxEN0160.Instance

            '@〓 ﾛｯﾄ終了(ﾛｯﾄｱｳﾄ) 〓
            Case CPstrKeyEN0170

                frmxxEN0170.Instance = New frmxxEN0170
                lfrmStartForm = frmxxEN0170.Instance

            '@〓 WF状態変更登録 〓
            Case CPstrKeyEN0180

                frmxxCM0070.Instance = New frmxxCM0070
                lfrmStartForm = frmxxCM0070.Instance

            '@〓 ﾁｯﾌﾟ状態変更登録 〓
            Case CPstrKeyEN0190

                frmxxCM0080.Instance = New frmxxCM0080
                lfrmStartForm = frmxxCM0080.Instance

            '@〓 TPAL貼り合わせ登録 〓
            Case CPstrKeyEN01A0

                frmxxEN01A0.Instance = New frmxxEN01A0
                lfrmStartForm = frmxxEN01A0.Instance

            '@〓 ﾛｯﾄ再測定 〓
            Case CPstrKeyEN01B0

                frmxxEN01B0.Instance = New frmxxEN01B0
                lfrmStartForm = frmxxEN01B0.Instance

            '@〓 ﾛｯﾄ情報詳細 〓
            Case CPstrKeyEN01C0

                frmxxCM00R0.Instance = New frmxxCM00R0
                lfrmStartForm = frmxxCM00R0.Instance

            '@〓 ｶﾞｲﾀﾞﾝｽ 〓
            Case CPstrKeyEN01D0

                frmxxEN01D0.Instance = New frmxxEN01D0
                lfrmStartForm = frmxxEN01D0.Instance

            '@〓 在庫移載 〓
            Case CPstrKeyEN01E0

                frmxxEN01E0.Instance = New frmxxEN01E0
                lfrmStartForm = frmxxEN01E0.Instance

            '@〓 分割予定ﾛｯﾄ登録 〓
            Case CPstrKeyEN01F0

                '@起動区分設定(1：分割予定ﾛｯﾄ登録)
                plngfrmxxCM00M0Kbn = CMlngLotDivide
                frmxxCM00M0.Instance = New frmxxCM00M0
                lfrmStartForm = frmxxCM00M0.Instance

            '@〓 ﾛｯﾄ流動票 〓
            Case CPstrKeyEN01G0

                frmxxEN01G0.Instance = New frmxxEN01G0
                lfrmStartForm = frmxxEN01G0.Instance

            '@〓 投入移載一覧 〓
            Case CPstrKeyEN01H0

                frmxxEN01H0.Instance = New frmxxEN01H0
                lfrmStartForm = frmxxEN01H0.Instance

            '@〓 部材履歴 〓
            Case CPstrKeyEN01I0

                frmxxEN01I0.Instance = New frmxxEN01I0
                lfrmStartForm = frmxxEN01I0.Instance

            '@〓 流動票ﾊﾞｰｼﾞｮﾝｱｯﾌﾟ 〓
            Case CPstrKeyEN01K0

                frmxxEN01K0.Instance = New frmxxEN01K0
                lfrmStartForm = frmxxEN01K0.Instance

            '@〓 搬送ﾓｰﾄﾞ管理 〓
            Case CPstrKeyEN01L0

                frmxxEN01L0.Instance = New frmxxEN01L0
                lfrmStartForm = frmxxEN01L0.Instance

            '@〓 ﾚﾁｸﾙﾏﾆｭｱﾙ搬送 〓
            Case CPstrKeyEN01M0

                frmxxEN01M0.Instance = New frmxxEN01M0
                lfrmStartForm = frmxxEN01M0.Instance

            '@〓 CMPﾒﾝﾃﾅﾝｽ 〓
            Case CPstrKeyEN01N0

                frmxxEN01N0.Instance = New frmxxEN01N0
                lfrmStartForm = frmxxEN01N0.Instance

            '@〓 ﾒｰﾙ送信 〓
            Case CPstrKeyEN01O0

                frmxxCM00S0.Instance = New frmxxCM00S0
                lfrmStartForm = frmxxCM00S0.Instance

    '@↓2019/07/03 (Wed) 16:01:24 T.Oide **************************************************
    '@        '@〓 量産計画ﾘﾘｰｽ 〓
    '@        Case CPstrKeyEN01P0
    '@
    '@            Load frmxxEN01P0
    '@↑2019/07/03 (Wed) 16:01:24 T.Oide **************************************************

            '@〓 ﾁｯﾌﾟ状態変更登録(上書き) 〓
            Case CPstrKeyEN01Q0

                frmxxCM0080.Instance = New frmxxCM0080
                lfrmStartForm = frmxxCM0080.Instance

            '@〓 P/Rｵｰﾀﾞｰ管理 〓
            Case CPstrKeyEN01S0

                frmxxEN01S0.Instance = New frmxxEN01S0
                lfrmStartForm = frmxxEN01S0.Instance

            '@〓 ﾌｫﾄF/B装置ﾊﾟﾗﾒｰﾀ変更 〓
            Case CPstrKeyEN01T0

                frmxxEN01T0.Instance = New frmxxEN01T0
                lfrmStartForm = frmxxEN01T0.Instance

            '@〓 ﾌｫﾄF/Bﾃﾞｰﾀ変更 〓
            Case CPstrKeyEN01U0

                frmxxEN01U0.Instance = New frmxxEN01U0
                lfrmStartForm = frmxxEN01U0.Instance

            '@〓 装置使用部材管理 〓
            Case CPstrKeyEN01V0

                frmxxEN01V0.Instance = New frmxxEN01V0
                lfrmStartForm = frmxxEN01V0.Instance

            '@〓 ﾛｯﾄ工順変更 〓
            Case CPstrKeyEN01X0

                frmxxEN01X0.Instance = New frmxxEN01X0
                lfrmStartForm = frmxxEN01X0.Instance

            '@〓 ﾛｯﾄ一覧ｽﾅｯﾌﾟｼｮｯﾄ 〓
            Case CPstrKeyEN01Y0

                frmxxEN01Y0.Instance = New frmxxEN01Y0
                lfrmStartForm = frmxxEN01Y0.Instance

            '@〓 装置ﾒﾝﾃﾅﾝｽ記録票一覧 〓
            Case CPstrKeyEN01Z0

                frmxxEN01Z0.Instance = New frmxxEN01Z0
                lfrmStartForm = frmxxEN01Z0.Instance

            '@〓 工程別ﾛｯﾄ一覧 〓
            Case CPstrKeyEN0200

                frmxxEN0200.Instance = New frmxxEN0200
                lfrmStartForm = frmxxEN0200.Instance

            '@〓 部材受入 〓
            Case CPstrKeyEN0210

                frmxxEN0210.Instance = New frmxxEN0210
                lfrmStartForm = frmxxEN0210.Instance

            '@〓 ﾛｯﾄ統合 〓
            Case CPstrKeyEN0220

                frmxxEN0161.Instance = New frmxxEN0161
                lfrmStartForm = frmxxEN0161.Instance

            '@〓 部材管理 〓
            Case CPstrKeyEN0230

                frmxxEN0230.Instance = New frmxxEN0230
                lfrmStartForm = frmxxEN0230.Instance

            '@〓 工程ｽｷｯﾌﾟ 〓
            Case CPstrKeyEN0250

                frmxxEN0250.Instance = New frmxxEN0250
                lfrmStartForm = frmxxEN0250.Instance

            '@〓 ﾛｯﾄ処理順変更 〓
            Case CPstrKeyEN0260

                frmxxCM0110.Instance = New frmxxCM0110
                lfrmStartForm = frmxxCM0110.Instance

            '@〓 ｱｸｼｮﾝ予約 〓
            Case CPstrKeyEN0270

                frmxxEN0270.Instance = New frmxxEN0270
                lfrmStartForm = frmxxEN0270.Instance

            '@〓 移載(ｿｰﾀｰ) 〓
            Case CPstrKeyEN0280

                frmxxEN0280.Instance = New frmxxEN0280
                lfrmStartForm = frmxxEN0280.Instance

            '@〓 ﾛｯﾄ情報変更・削除 〓
            Case CPstrKeyEN0290

                frmxxCM01A0.Instance = New frmxxCM01A0
                lfrmStartForm = frmxxCM01A0.Instance

            '@〓 工程戻し 〓
            Case CPstrKeyEN02A0

                frmxxEN02A0.Instance = New frmxxEN02A0
                lfrmStartForm = frmxxEN02A0.Instance

            '@〓 ﾛｯﾄ情報一括変更 〓
            Case CPstrKeyEN02B0

                frmxxEN02B0.Instance = New frmxxEN02B0
                lfrmStartForm = frmxxEN02B0.Instance

            '@〓 MKﾛｯﾄ編成 〓
            Case CPstrKeyEN02C0

                frmxxEN02C0.Instance = New frmxxEN02C0
                lfrmStartForm = frmxxEN02C0.Instance

            '@〓 治具管理 〓
            Case CPstrKeyEN02D0

                frmxxEN02D0.Instance = New frmxxEN02D0
                lfrmStartForm = frmxxEN02D0.Instance

            '@〓 CF移載情報登録 〓
            Case CPstrKeyEN02E0

                frmxxEN02E0.Instance = New frmxxEN02E0
                lfrmStartForm = frmxxEN02E0.Instance

            '@〓 治具 Wafer紐付け 〓
            Case CPstrKeyEN02F0

                frmxxEN02F0.Instance = New frmxxEN02F0
                lfrmStartForm = frmxxEN02F0.Instance

            '@〓 不良ﾁｯﾌﾟ情報(№表示) 〓
            Case CPstrKeyEN02G0

                '@起動区分設定(1：不良ﾁｯﾌﾟ情報(№表示))
                plngfrmxxCM0080Kbn = CPlngNumOne
                frmxxCM0080.Instance = New frmxxCM0080
                lfrmStartForm = frmxxCM0080.Instance

            '@〓 無機対向基板紐付/蒸着ﾊﾞｯﾁ情報 〓
            Case CPstrKeyEN02H0

                frmxxEN02H0.Instance = New frmxxEN02H0
                lfrmStartForm = frmxxEN02H0.Instance

            '@〓 区間優先設定 〓
            Case CPstrKeyEN02I0

                frmxxEN02I0.Instance = New frmxxEN02I0
                lfrmStartForm = frmxxEN02I0.Instance

            '@〓 DEPO補正値参照/変更 〓
            Case CPstrKeyEN02J0

                frmxxEN02J0.Instance = New frmxxEN02J0
                lfrmStartForm = frmxxEN02J0.Instance

            '@〓 CONTｴｯﾁｬｰFR使用履歴 〓
            Case CPstrKeyEN02K0

                frmxxEN02K0.Instance = New frmxxEN02K0
                lfrmStartForm = frmxxEN02K0.Instance
            
            '@〓 GRB属性設定 〓
            Case CPstrKeyEN02L0

                frmxxEN02L0.Instance = New frmxxEN02L0
                lfrmStartForm = frmxxEN02L0.Instance

            '@〓 ﾛｯﾄGRB分割 〓
            Case CPstrKeyEN02M0

                frmxxEN02M0.Instance = New frmxxEN02M0
                lfrmStartForm = frmxxEN02M0.Instance
                
            '@〓 ﾊﾞｯﾁ装置管理 〓
            Case CPstrKeyEN02N0

                frmxxEN02N0.Instance = New frmxxEN02N0
                lfrmStartForm = frmxxEN02N0.Instance

            '@〓 時間制限流動管理 〓
            Case CPstrKeyEN02O0

                frmxxEN02O0.Instance = New frmxxEN02O0
                lfrmStartForm = frmxxEN02O0.Instance
                
            '@〓 ﾊﾞｯﾁ_受入在庫 〓
            Case CPstrKeyEN02P0

                frmxxEN02P0.Instance = New frmxxEN02P0
                lfrmStartForm = frmxxEN02P0.Instance

            '@〓 作業開始(防湿ALD) 〓
            Case CPstrKeyEN02Q1
                
                pstrfrmxxEN2Q0Div = CPstrCD10
                frmxxEN02Q0.Instance = New frmxxEN02Q0
                lfrmStartForm = frmxxEN02Q0.Instance
                
            '@〓 作業開始(防湿ALD) 〓
            Case CPstrKeyEN02Q2

                pstrfrmxxEN2Q0Div = CPstrCD11
                frmxxEN02Q0.Instance = New frmxxEN02Q0
                lfrmStartForm = frmxxEN02Q0.Instance

            '@〓 作業開始(防湿ALD) 〓
            Case CPstrKeyEN02Q3

                pstrfrmxxEN2Q0Div = CPstrCD12
                frmxxEN02Q0.Instance = New frmxxEN02Q0
                lfrmStartForm = frmxxEN02Q0.Instance

            '@〓 作業開始(防湿ALD) 〓
            Case CPstrKeyEN02Q4

                pstrfrmxxEN2Q0Div = CPstrCD13
                frmxxEN02Q0.Instance = New frmxxEN02Q0
                lfrmStartForm = frmxxEN02Q0.Instance

            '@〓 ﾊﾞｯﾁ_受入在庫 〓
            Case CPstrKeyEN02R0

                frmxxEN02R0.Instance = New frmxxEN02R0
                lfrmStartForm = frmxxEN02R0.Instance

            '@〓 Aﾄﾚｰ管理 〓
            Case CPstrKeyEN02S0

                frmxxEN02S0.Instance = New frmxxEN02S0
                lfrmStartForm = frmxxEN02S0.Instance

            '@〓 Aｷｬﾘｱ管理 〓
            Case CPstrKeyEN02T0
            
                frmxxEN02T0.Instance = New frmxxEN02T0
                lfrmStartForm = frmxxEN02T0.Instance

            '@〓 ODF貼り合わせ予約 〓
            Case CPstrKeyEN02U0

                frmxxEN02U0.Instance = New frmxxEN02U0
                lfrmStartForm = frmxxEN02U0.Instance

			 '@〓 蒸着マスク組立 〓
            Case CPstrKeyEN02V0

                frmxxEN02V0.Instance = New frmxxEN02V0
                lfrmStartForm = frmxxEN02V0.Instance

            '@〓 その他 〓
            Case Else

                Exit Function

        End Select

        '@=======================
        '@ 機能関連情報取得
        '@=======================
        Call pubMenuItemCorrelation_Set(lstrMenuKey, _
                                        lstrFormTitle, _
                                        llngCarrTakeOver, _
                                        lstrFormName)

        '@***********************
        '@ ﾌｫｰﾑのｵﾌﾞｼﾞｪｸﾄを取得
        '@***********************
        If lfrmStartForm IsNot Nothing Then

            '@取得した機能情報のﾌｫｰﾑ名と同じか

            '@ﾌｫｰﾑが中途半端に表示されるのを回避する処理
            With lfrmStartForm

                '@ﾌｫｰﾑの名称、表示位置を設定
                .Text = lstrFormTitle                       'ﾀｲﾄﾙ
                .StartPosition = FormStartPosition.Manual
                .Top = 0                                    '表示位置(最上Y座標)
                .Left = 0 - My.Settings.FormOffset          '表示位置(最左X座標)

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗"か
                If pblnFormLoad = False Then
                    Exit Function
                End If

                '@★ 機能に設定されている引継ぎﾌﾗｸﾞにより処理分岐 ★
                Select Case llngCarrTakeOver

                    '@〓 1：次機能へ引継ぎあり、前機能から引継ぎなし 〓
                    Case CPlngMenuCarrTakeOver1

                        '@★★ 引継ぎ元(呼び元)ﾌｫｰﾑIDにより処理分岐 ★★
                        Select Case ltypCommonInfo.strFromMenuKey

                            '@〓〓 装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧、装置別ﾛｯﾄ一覧、工程別ﾛｯﾄ一覧 〓〓
'@↓2018/11/16 (Fri) 14:15:56 Y.Yoneyama **************************************************
                            Case CPstrKeyEN00J0, CPstrKeyEN0150, CPstrKeyEN0151, CPstrKeyEN0200
'@↑2018/11/16 (Fri) 14:15:56 Y.Yoneyama **************************************************

                                '@引継ぎ情報初期化
                                With ltypCommonInfo

                                    .strCarrierId = vbNullString
                                    .strDivision = vbNullString
                                    .strLotID = vbNullString
                                    .strOpID = vbNullString
                                    .strStepID = vbNullString
                                    .strWpID = vbNullString
                                    .strWpName = vbNullString
                                    .strToCarrierId = vbNullString
                                End With

                                '@初期化した引継構造体を共通変数に格納
                                ptypCommonInfo = ltypCommonInfo

                            '@〓〓 その他 〓〓
                            Case Else

                                '@引継ぎ情報を共通変数に格納
                                ptypCommonInfo = ltypCommonInfo

                        End Select


                    '@〓 2：次機能へ引継ぎなし、前機能から引継ぎあり 〓
                    Case CPlngMenuCarrTakeOver2

                        '@引継ぎ情報を共通変数に格納
                        ptypCommonInfo = ltypCommonInfo


                    '@〓 3：次機能へ引継ぎあり、前機能から引継ぎあり 〓
                    Case CPlngMenuCarrTakeOver3

                        '@引継ぎ情報を共通変数に格納
                        ptypCommonInfo = ltypCommonInfo


                    '@〓 その他 〓
                    Case Else

                        '@引継ぎ情報初期化
                        With ltypCommonInfo

                            .strCarrierId = vbNullString
                            .strDivision = vbNullString
                            .strLotID = vbNullString
                            .strOpID = vbNullString
                            .strStepID = vbNullString
                            .strWpID = vbNullString
                            .strWpName = vbNullString
                            .strToCarrierId = vbNullString
                        End With

                End Select
                '@起動ﾌｫｰﾑが未表示か
                If .Visible = False Then
                    '@未表示の場合表示する
                    'NSYS VB6互換動作のため、遅延で表示する。ラムダ式使用
                    'NSYS →のコードを実行しているのと同じ： .Show(lfrmOwner)
                    Dim lfuncShow As Action(Of Form) = Sub(frm As Form)
                                                            .Show(frm)
                                                       End Sub
                    lfrmOwner.BeginInvoke(lfuncShow, lfrmOwner)
                End If
            End With

        End If

        '@戻り値に"0：正常終了"をｾｯﾄ
        publngStart_Proc = CPlngNormalStatusCD

    End Function

    '関数名：pubMenuFavoritesCount_proc
    '機　能：お気に入りｸﾞﾘｯﾄﾞの実際のﾃﾞｰﾀ件数を取得する
    '引　数：llngListCount：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 15:35:08 H.Wajima
    '更新日：2004/04/26 (Mon) 15:35:08
    '備　考：
    Public Sub pubMenuFavoritesCount_proc(ByVal lvsfFavorites As C1FlexGrid, _
                                          ByRef llngListCount As Integer)

        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ
        
        With lvsfFavorites
            '@ﾒﾆｭｰ行ｶｳﾝﾀの初期化
            llngListCount = .Rows.Count
            '@ﾃﾞｰﾀの件数を数える
            For llngCnt = 0 To .Rows.Count - 1
                '@ｸﾞﾘｯﾄﾞのﾒﾆｭｰｷｰが空白かどうかを確認する
                If .GetData(llngCnt, CPlngMenuKeyCol) = vbNullString Then
                '@ﾒﾆｭｰｷｰが空白の場合
                    '@ｶｳﾝﾀの値を引数のﾃﾞｰﾀ件数に格納する
                    llngListCount = llngCnt
                    
                    '@ﾙｰﾌﾟを抜ける
                    Exit For
                End If
            Next llngCnt
        End With
        
        '@ｺﾝﾄﾛｰﾙを解放する
        lvsfFavorites = Nothing

    End Sub

    '関数名：pubMenuGridMouseMove_Proc
    '機　能：各ｸﾞﾘｯﾄﾞのMouseMove処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/30 (Fri) 14:34:35 H.Wajima
    '更新日：2004/04/30 (Fri) 14:34:35
    '備　考：
    Public Sub pubMenuGridMouseMove_Proc(ByVal lvsfControl As C1FlexGrid, ByRef ltoolTipControl As ToolTip)

        Dim llngMouseRow        As Integer
        Dim llngMouseCol        As Integer
            
        With lvsfControl
            '@座標の退避
            llngMouseRow = .MouseRow
            llngMouseCol = .MouseCol
            
            '@ﾏｳｽ座標が拾えているかどうかを判断する
            If llngMouseRow = CPlngMenuVSFlexGridUnChoosing Or _
               llngMouseCol = CPlngMenuVSFlexGridUnChoosing Then
                '@ｺﾝﾄﾛｰﾙの解放
                lvsfControl = Nothing
                
                '@ﾏｳｽ座標が拾えない場合は処理を抜ける
                Exit Sub
            End If
            
            '@ﾂｰﾙﾁｯﾌﾟﾃｷｽﾄの更新
            If plngMenuLastMouseCol <> llngMouseCol Or plngMenuLastMouseRow <> llngMouseRow Then
            '@前回のﾏｳｽ行・ﾏｳｽ列からｾﾙが移動した場合
                '@前回ﾏｳｽ行の退避
                plngMenuLastMouseRow = llngMouseRow
                
                '@前回ﾏｳｽ列の退避
                plngMenuLastMouseCol = llngMouseCol
                
                '@ﾂｰﾙﾁｯﾌﾟﾃｷｽﾄにｾﾙの値をを表示する
                ltoolTipControl.SetToolTip(lvsfControl, .GetData(llngMouseRow, llngMouseCol))
            End If
        End With
        
        '@ｺﾝﾄﾛｰﾙの解放
        lvsfControl = Nothing

    End Sub

End Module
