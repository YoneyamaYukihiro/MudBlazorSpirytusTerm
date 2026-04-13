
	'ﾌｧｲﾙ名：SendOrderListData.vb
'説　明：在庫管理　送品伝票　送品伝票データクラス定義
'作成日：2019/11/22 (Fri) NSYS
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2019-, all rights reserved.
Imports C1.Win.FlexReport
Public Class SendOrderListData
    Implements IC1FlexReportRecordset
    Public Structure SendOrderListField
        Dim strSBName           As String  '送品元
        Dim strSendSBName       As String  '送品先
        Dim strEmpName          As String  '送品担当
        Dim strSendDate         As String  '送品日
        Dim strAtlasPoint       As String  '送品元ATLASﾎﾟｲﾝﾄ
        Dim strSendAtlasPoint   As String  '送品先ATLASﾎﾟｲﾝﾄ
        Dim strPDID             As String  '機種
        Dim strPDIDd            As String  '機種表示用
        Dim strExtPartCode      As String  '仕掛品ｺｰﾄﾞ
    
        Dim intNo               As Integer '№
        Dim strLotID            As String  'LotID
        Dim strBoxNo            As String  '箱№
        Dim strFlowClass        As String  '種別
        Dim strWFQuantity       As String  'WF数
        Dim strChipQuantity     As String  'ﾁｯﾌﾟ数
        Dim strAtlasOrderNo     As String  'ATLASｵｰﾀﾞｰ№
        Dim strInvComments      As String  '次SBｺﾒﾝﾄ
        Dim intPageCount        As Integer 'ﾍﾟｰｼﾞ番号
        Dim intPageTotal        As Integer '総ﾍﾟｰｼﾞ数
    End Structure

    Private _row As Integer ' カーソル位置
    Private _list As List(Of SendOrderListField) ' データ

    ' 共有で利用する変数（フィールド名、タイプ）を定義します。
    Private Shared _names() As String = {"SBName", "SendSBName", "EmpName", "SendDate", "AtlasPoint", "SendAtlasPoint", "PDID", "PDIDd", "ExtPartCode", _
                                         "No", "LotID", "BoxNo", "FlowClass", "WFQuantity", "ChipQuantity", "AtlasOrderNo", "InvComments", "PageCount", "PageTotal" }
    Private Shared _types() As Type = {"a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), 0.GetType(), _
                                       "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), "a".GetType(), 0.GetType(), 0.GetType() }

    ' コンストラクタを定義します。
    Public Sub New()

        _row = 0
        ' リスト格納用変数を定義します。
        _list = New List(Of SendOrderListField)
        ' 初期ダミーデータ追加
        For i As Integer = 0 To 21
            Dim tmp As SendOrderListField = New SendOrderListField()
            With tmp
                .strSBName = "千歳基板"
                .strSendSBName = "千歳組立"
                .strSendDate = "2020/10/30"
                .strEmpName = "エプソン三郎"
                .strAtlasPoint = "AtlasPoint"
                .strSendAtlasPoint = "strSendAtlasPoint"
                .strPDID = "XXX"
                .strPDIDd = "XXX"
                .strExtPartCode = "ExtPartCode0123456789"
                .strLotID = "01234567890"
                .strBoxNo = "555"
                .strFlowClass = "PR"
                .strWFQuantity = "99"
                .strChipQuantity = "9,999"
                .strAtlasOrderNo = "OrderNo123"
                .strInvComments = "あり"
                .intNo = (i + 1)
                .intPageCount = ((i \ 10) + 1)
                .intPageTotal = (3)
            End With
            _list.Add(tmp)
        Next

    End Sub

    Public Sub Clear()
        _list.Clear()
         _row = 0
    End Sub
    Public Sub Add(ByRef elem As SendOrderListField)
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

    Public Function GetFieldValue(ByVal fieldIndex As Integer) As Object Implements IC1FlexReportRecordset.GetFieldValue
        
        ' リスト中の現在選択されている位置を取得します。
        Dim tmp As SendOrderListField = _list(_row)
        '{"SBName", "SendSBName", "EmpName", "SendDate", "AtlasPoint", "SendAtlasPoint", "PDID", "ExtPartCode", _
        ' "No", "LotID", "BoxNo", "FlowClass", "WFQuantity", "ChipQuantity", "AtlasOrderNo", "InvComments", "PageCount", "PageTotal" }
        Select Case fieldIndex
            Case 0 'SBName
                GetFieldValue = tmp.strSBName
            Case 1 'SendSBName
                GetFieldValue = tmp.strSendSBName
            Case 2 'EmpName
                GetFieldValue = tmp.strEmpName
            Case 3 'SendDate
                GetFieldValue = tmp.strSendDate
            Case 4 'AtlasPoint
                GetFieldValue = tmp.strAtlasPoint
            Case 5 'SendAtlasPoint
                GetFieldValue = tmp.strSendAtlasPoint
            Case 6 'PDID
                GetFieldValue = tmp.strPDID
            Case 7 'PDIDd
                GetFieldValue = tmp.strPDIDd
            Case 8 'ExtPartCode
                GetFieldValue = tmp.strExtPartCode
            Case 9 'No
                GetFieldValue = tmp.intNo
            Case 10 'LotID
                GetFieldValue = tmp.strLotID
            Case 11 'BoxNo
                GetFieldValue = tmp.strBoxNo
            Case 12 'FlowClass
                GetFieldValue = tmp.strFlowClass
            Case 13 'WFQuantity
                GetFieldValue = tmp.strWFQuantity
            Case 14 'ChipQuantity
                GetFieldValue = tmp.strChipQuantity
            Case 15 'AtlasOrderNo
                GetFieldValue = tmp.strAtlasOrderNo
            Case 16 'InvComments
                GetFieldValue = tmp.strInvComments
            Case 17 'PageCount
                GetFieldValue = tmp.intPageCount
            Case 18 'PageTotal
                GetFieldValue = tmp.intPageTotal
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

Public Class ExtSendOrderListData
    Implements IC1FlexReportExternalRecordset

    Private _data As SendOrderListData = New SendOrderListData()

    Public ReadOnly Property Caption As String Implements IC1FlexReportExternalRecordset.Caption
        Get
            Caption = "ExtSendOrderListData"
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

