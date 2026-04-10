'ﾌｧｲﾙ名：xxCM00X0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：処理中画面
'作成日：2005/10/04 (Tue) 15:34:24 N.Kasai
'更新日：2005/10/04 (Tue) 15:34:24 N.Kasai
'備　考：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00X0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00X0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00X0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00X0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00X0)
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
    '====================================Private============================================

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00X0      'ﾛｰｶﾙ機能ID

    '@ﾌｫｰﾑ関連
    Private Const CMlngHwndTopmost                  As Integer = (-1)                  'API(SetWindowPos)
    Private Const CMStrMsgQuestion                  As String = "Question"          'ﾒｯｾｰｼﾞBOX用ﾀｲﾄﾙ文字
    Private Const CMStrMsgExclamation               As String = "Exclamation"       'ﾒｯｾｰｼﾞBOX用ﾀｲﾄﾙ文字
    Private Const CMStrMsgInformation               As String = "Information"       'ﾒｯｾｰｼﾞBOX用ﾀｲﾄﾙ文字

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
        
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：画面起動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/10/04 (Tue) 15:32:07 N.Kasai
    '更新日：2005/10/04 (Tue) 15:32:07
    '備　考：
    Private Sub Form_Load() Handles MyBase.Activated
        Try
            
            '@ﾌｫｰﾑの初期表示位置を設定（画面の中央）
            '@最前面のAPI関数を使用する場合は記述しないと左上に表示される為
            Me.Top = ((Screen.GetBounds(Me).Height \ 2) - (Me.Height \ 2))
            Me.Left = ((Screen.GetBounds(Me).Width \ 2) - (Me.Width \ 2)) - My.Settings.FormOffset
            
            '@ﾌｫｰﾑの最前面表示
            Call SetWindowPos(Me.Handle, CMlngHwndTopmost, 0&, 0&, 0&, 0&, &H43)
            
            '@ｱｲｺﾝ表示(ｲﾝﾌｫﾒｰｼｮﾝ固定）
            If String.IsNullOrEmpty(CMStrMsgInformation) = False Then
                imgMsg.Image = imlMsg.Images.Item(CMStrMsgInformation)
            Else
                imgMsg.Dispose()
                imgMsg = Nothing
            End If
            
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
    '機　能：画面終了
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：終了ﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2005/10/04 (Tue) 16:14:22 N.Kasai
    '更新日：2005/10/04 (Tue) 16:14:22
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

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

End Class
