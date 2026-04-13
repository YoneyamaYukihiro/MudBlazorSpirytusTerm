'ﾌｧｲﾙ名：LotExamInfoData.vb
'説　明：在庫管理　送品伝票　送品伝票データクラス定義
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2019-, all rights reserved.
Imports C1.Win.FlexReport
Public Class LotExamInfoData
    Implements IC1FlexReportRecordset
    Public Structure LotExamInfoField
        Dim strLotID                 As String     'ﾛｯﾄID
        Dim strBoxNo                 As String     '箱№
        Dim strFlowClass             As String     '種別
        Dim intWFQuantity            As Integer    '送品WF数
        Dim intChipQuantity          As Integer    '送品ﾁｯﾌﾟ数
        Dim strPDID                  As String     '機種
        Dim strSendDate              As String     '送品日
        Dim strSendSBName            As String     '送品先SB名
    
        Dim strWFThrowinDate         As String     'WF投入日
        Dim intWFThrowinQuantity     As Integer    '投入WF数
        Dim strWFFinishDate          As String     'WF完成日
        Dim intWFFinishQuantity      As Integer    '完成WF数
        Dim intWFOutQuantity         As Integer    '不良WF数
        Dim intWFIssueQuantity       As Integer    '払出WF数
        Dim intChipIssueQuantity     As Integer    '払出ﾁｯﾌﾟ数
    
        Dim strNo                    As String     '№
        Dim strWFID                  As String     'WFID
        Dim strWFChipQuantity        As String     'ﾁｯﾌﾟ数
    
        Dim intChipThrowinQuantity   As Integer    '投入ﾁｯﾌﾟ数
        Dim intChipOutQuantity       As Integer    '不良ﾁｯﾌﾟ数
        Dim dblGoodChipRatio         As Double     '組立歩留率
        Dim strInvComments           As String     '次SB連絡ｺﾒﾝﾄ
    End Structure

    Private _row As Integer ' カーソル位置
    Private _list As List(Of LotExamInfoField) ' データ

    ' 共有で利用する変数（フィールド名、タイプ）を定義します。
    Private Shared _names() As String = { "LotID", "BoxNo", "FlowClass", "WFQuantity", "ChipQuantity", "PDID", _
                                          "SendDate", "SendSBName", "WFThrowinDate", "WFThrowinQuantity", "WFFinishDate", "WFFinishQuantity", "WFOutQuantity", "WFIssueQuantity", _
                                          "ChipIssueQuantity", "No", "WFID", "WFChipQuantity", "ChipThrowinQuantity", "ChipOutQuantity", "GoodChipRatio", "InvComments" }
    Private Shared _types() As Type = { "a".GetType(), "a".GetType(), "a".GetType(), 0.GetType(), 0.GetType(), "a".GetType(), _
                                        "a".GetType(), "a".GetType(), "a".GetType(), 0.GetType(), "a".GetType(), 0.GetType(), 0.GetType(), 0.GetType(), _
                                        0.GetType(), "a".GetType(), "a".GetType(), "a".GetType(), 0.GetType(), 0.GetType(), CDbl(0).GetType(), "a".GetType() }

    ' コンストラクタを定義します。
    Public Sub New()

        _row = 0
        ' リスト格納用変数を定義します。
        _list = New List(Of LotExamInfoField)
        ' 初期ダミーデータ追加
            Dim tmp As LotExamInfoField  = New LotExamInfoField()
            With tmp
                .strLotID = "0123456789"
                .strBoxNo = "999"
                .strFlowClass = "XX"
                .intWFQuantity = 17
                .intChipQuantity = 9999
                .strPDID = "XXX"
                .strSendDate = "2019/10/25"
                .strSendSBName = "諏訪南組立"
                .strWFThrowinDate = "2019/10/01"
                .intWFThrowinQuantity = 19
                .strWFFinishDate = "2019/10/11"
                .intWFFinishQuantity = 17
                .intWFOutQuantity = 2
                .intWFIssueQuantity = 1
                .intChipIssueQuantity = 49
                .strNo = 1
                .strWFID = "XXX9999#01"
                .strWFChipQuantity = 400
                .intChipThrowinQuantity = 20
                .intChipOutQuantity = 30
                .dblGoodChipRatio = 90.25/100
                .strInvComments = "コメントコメント"
            End With
            _list.Add(tmp)

    End Sub

    Public Sub Clear()
        _list.Clear()
         _row = 0
    End Sub
    Public Sub Add(ByRef elem As LotExamInfoField)
        _list.Add(elem)
    End Sub

    Public ReadOnly Property Count As Integer Implements IC1FlexReportRecordset.Count
        Get
            Count = _list.Count()
        End Get
    End Property

    Public Function GetFieldNames() As String() Implements IC1FlexReportRecordset.GetFieldNames
        GetFieldNames = _names
    End Function

    Public Function GetFieldTypes() As Type() Implements IC1FlexReportRecordset.GetFieldTypes
        GetFieldTypes = _types
    End Function

    Public Function GetFieldValue(fieldIndex As Integer) As Object Implements IC1FlexReportRecordset.GetFieldValue
        ' リスト中の現在選択されている位置を取得します。
        Dim tmp As LotExamInfoField = _list(_row)
        '{ "LotID", "BoxNo", "FlowClass", "WFQuantity", "ChipQuantity", "PDID", "SendDate", "SendSBName", _
        '  "WFThrowinDate", "WFThrowinQuantity", "WFFinishDate", "WFFinishQuantity", "WFOutQuantity", "WFIssueQuantity", "ChipIssueQuantity", _
        '  "No", "WFID", "WFChipQuantity", "ChipThrowinQuantity", "ChipOutQuantity", "GoodChipRatio", "InvComments" }
        Select Case fieldIndex
            Case 0 'LotID
                GetFieldValue = tmp.strLotID
            Case 1 'BoxNo
                GetFieldValue = tmp.strBoxNo
            Case 2 'FlowClass
                GetFieldValue = tmp.strFlowClass
            Case 3 'WFQuantity
                GetFieldValue = tmp.intWFQuantity
            Case 4 'ChipQuantity
                GetFieldValue = tmp.intChipQuantity
            Case 5 'PDID
                GetFieldValue = tmp.strPDID
            Case 6 'SendDate
                GetFieldValue = tmp.strSendDate
            Case 7 'SendSBName
                GetFieldValue = tmp.strSendSBName
            Case 8 'WFThrowinDate
                GetFieldValue = tmp.strWFThrowinDate
            Case 9 'WFThrowinQuantity
                GetFieldValue = tmp.intWFThrowinQuantity
            Case 10 'WFFinishDate
                GetFieldValue = tmp.strWFFinishDate
            Case 11 'WFFinishQuantity
                GetFieldValue = tmp.intWFFinishQuantity
            Case 12 'WFOutQuantity
                GetFieldValue = tmp.intWFOutQuantity
            Case 13 'WFIssueQuantity
                GetFieldValue = tmp.intWFIssueQuantity
            Case 14 'ChipIssueQuantity
                GetFieldValue = tmp.intChipIssueQuantity
            Case 15 'No
                GetFieldValue = tmp.strNo
            Case 16 'WFID
                GetFieldValue = tmp.strWFID
            Case 17 'WFChipQuantity
                GetFieldValue = tmp.strWFChipQuantity
            Case 18 'ChipThrowinQuantity
                GetFieldValue = tmp.intChipThrowinQuantity
            Case 19 'ChipOutQuantity
                GetFieldValue = tmp.intChipOutQuantity
            Case 20 'GoodChipRatio
                GetFieldValue = tmp.dblGoodChipRatio
            Case 21 'InvComments
                GetFieldValue = tmp.strInvComments
            Case Else
                GetFieldValue = ""
        End Select

    End Function

    Public Function BOF() As Boolean Implements IC1FlexReportRecordset.BOF
        If _row = 0 Then
            BOF = True
        Else
            BOF = False
        End If
    End Function

    Public Function EOF() As Boolean Implements IC1FlexReportRecordset.EOF
        If _row >= _list.Count() Then
            EOF = True
        Else
            EOF = False
        End If
    End Function

    Public Sub MoveFirst() Implements IC1FlexReportRecordset.MoveFirst
        _row = 0
    End Sub

    Public Sub MoveLast() Implements IC1FlexReportRecordset.MoveLast
        _row = _list.Count - 1
    End Sub

    Public Sub MovePrevious() Implements IC1FlexReportRecordset.MovePrevious
        If _row > 0 Then
            _row = _row - 1 
        End If
    End Sub

    Public Sub MoveNext() Implements IC1FlexReportRecordset.MoveNext
        If _row < _list.Count Then
            _row = _row + 1
        End If
    End Sub

    Public Function GetBookmark() As Integer Implements IC1FlexReportRecordset.GetBookmark
        GetBookmark = _row
    End Function

    Public Sub SetBookmark(ByVal bkmk As Integer) Implements IC1FlexReportRecordset.SetBookmark
        _row = bkmk
    End Sub

End Class

Public Class ExtLotExamInfoData
    Implements IC1FlexReportExternalRecordset

    Private _data As LotExamInfoData = New LotExamInfoData()

    Public ReadOnly Property Caption As String Implements IC1FlexReportExternalRecordset.Caption
        Get
            Caption = "ExtLotExamInfoData"
        End Get
    End Property

    Public Property Params As String Implements IC1FlexReportExternalRecordset.Params
        Get
            Params = ""
        End Get
        Set(value As String)
        End Set
    End Property

    Public Sub EditParams() Implements IC1FlexReportExternalRecordset.EditParams
    End Sub

    Public Function GetRecordset() As IC1FlexReportRecordset Implements IC1FlexReportExternalRecordset.GetRecordset
        GetRecordset = _data
    End Function
End Class