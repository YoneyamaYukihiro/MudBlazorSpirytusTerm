<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00Z1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00Z1))
        Me.cmdField1Up = New System.Windows.Forms.Button()
        Me.cmdField1Down = New System.Windows.Forms.Button()
        Me.cmdNewEntry = New System.Windows.Forms.Button()
        Me.cmdField2Down = New System.Windows.Forms.Button()
        Me.cmdField2Up = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.vsfMainteList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.calStart = New SECalendarEx.CalendarEx()
        Me.calEnd = New SECalendarEx.CalendarEx()
        Me.txtCommonField1 = New SETextBoxEx.TextBoxEx()
        Me.txtCommonField2 = New SETextBoxEx.TextBoxEx()
        Me.lblLengthCount2 = New System.Windows.Forms.Label()
        Me.lblLengthCount1 = New System.Windows.Forms.Label()
        Me.lblCommonField2Title = New System.Windows.Forms.Label()
        Me.lblCommonField1Title = New System.Windows.Forms.Label()
        Me.lblFromTitle = New System.Windows.Forms.Label()
        Me.lblWave = New System.Windows.Forms.Label()
        Me.lblToTitle = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblNowDateTitle = New System.Windows.Forms.Label()
        Me.lblDataCnt = New System.Windows.Forms.Label()
        Me.lblDataCntTitle = New System.Windows.Forms.Label()
        Me.lblWpName = New System.Windows.Forms.Label()
        Me.lblWpNameTitle = New System.Windows.Forms.Label()
        Me.lblHeaderInfo = New System.Windows.Forms.Label()
        CType(Me.vsfMainteList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdField1Up
        '
        Me.cmdField1Up.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdField1Up.Location = New System.Drawing.Point(825, 356)
        Me.cmdField1Up.Name = "cmdField1Up"
        Me.cmdField1Up.Size = New System.Drawing.Size(25, 41)
        Me.cmdField1Up.TabIndex = 5
        Me.cmdField1Up.Text = "▲"
        '
        'cmdField1Down
        '
        Me.cmdField1Down.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdField1Down.Location = New System.Drawing.Point(825, 398)
        Me.cmdField1Down.Name = "cmdField1Down"
        Me.cmdField1Down.Size = New System.Drawing.Size(25, 41)
        Me.cmdField1Down.TabIndex = 6
        Me.cmdField1Down.Text = "▼"
        '
        'cmdNewEntry
        '
        Me.cmdNewEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNewEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNewEntry.Location = New System.Drawing.Point(502, 542)
        Me.cmdNewEntry.Name = "cmdNewEntry"
        Me.cmdNewEntry.Size = New System.Drawing.Size(86, 43)
        Me.cmdNewEntry.TabIndex = 11
        Me.cmdNewEntry.Text = "新規登録"
        '
        'cmdField2Down
        '
        Me.cmdField2Down.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdField2Down.Location = New System.Drawing.Point(825, 492)
        Me.cmdField2Down.Name = "cmdField2Down"
        Me.cmdField2Down.Size = New System.Drawing.Size(25, 41)
        Me.cmdField2Down.TabIndex = 9
        Me.cmdField2Down.Text = "▼"
        '
        'cmdField2Up
        '
        Me.cmdField2Up.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdField2Up.Location = New System.Drawing.Point(825, 449)
        Me.cmdField2Up.Name = "cmdField2Up"
        Me.cmdField2Up.Size = New System.Drawing.Size(25, 41)
        Me.cmdField2Up.TabIndex = 8
        Me.cmdField2Up.Text = "▲"
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(556, 15)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(86, 43)
        Me.cmdSearch.TabIndex = 2
        Me.cmdSearch.Text = "検　索"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(6, 542)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(86, 43)
        Me.cmdClose.TabIndex = 12
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(765, 542)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(86, 43)
        Me.cmdRegist.TabIndex = 10
        Me.cmdRegist.Text = "確　定"
        '
        'vsfMainteList
        '
        Me.vsfMainteList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMainteList.AllowEditing = false
        Me.vsfMainteList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMainteList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMainteList.AutoResize = true
        Me.vsfMainteList.AutoSearchDelay = 2R
        Me.vsfMainteList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMainteList.ColumnInfo = resources.GetString("vsfMainteList.ColumnInfo")
        Me.vsfMainteList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMainteList.ExtendLastCol = true
        Me.vsfMainteList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMainteList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMainteList.Location = New System.Drawing.Point(7, 73)
        Me.vsfMainteList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMainteList.Name = "vsfMainteList"
        Me.vsfMainteList.Rows.Count = 40
        Me.vsfMainteList.Rows.DefaultSize = 18
        Me.vsfMainteList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMainteList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMainteList.Size = New System.Drawing.Size(843, 274)
        Me.vsfMainteList.StyleInfo = resources.GetString("vsfMainteList.StyleInfo")
        Me.vsfMainteList.TabIndex = 3
        '
        'calStart
        '
        Me.calStart.DateCheckStatus = 0
        Me.calStart.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStart.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStart.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStart.IsDate = true
        Me.calStart.Location = New System.Drawing.Point(246, 31)
        Me.calStart.Name = "calStart"
        Me.calStart.Size = New System.Drawing.Size(137, 22)
        Me.calStart.TabIndex = 0
        Me.calStart.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStart.Value = "____/__/__"
        '
        'calEnd
        '
        Me.calEnd.DateCheckStatus = 0
        Me.calEnd.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEnd.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEnd.IsDate = true
        Me.calEnd.Location = New System.Drawing.Point(415, 31)
        Me.calEnd.Name = "calEnd"
        Me.calEnd.Size = New System.Drawing.Size(137, 22)
        Me.calEnd.TabIndex = 1
        Me.calEnd.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEnd.Value = "____/__/__"
        '
        'txtCommonField1
        '
        Me.txtCommonField1.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtCommonField1.ChrMaxByte = 0
        Me.txtCommonField1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCommonField1.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtCommonField1.GotHighLight = false
        Me.txtCommonField1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCommonField1.Location = New System.Drawing.Point(7, 372)
        Me.txtCommonField1.MultiLineEx = true
        Me.txtCommonField1.Name = "txtCommonField1"
        Me.txtCommonField1.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCommonField1.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCommonField1.SelectedText = ""
        Me.txtCommonField1.Size = New System.Drawing.Size(818, 66)
        Me.txtCommonField1.TabIndex = 4
        Me.txtCommonField1.TabStop = false
        '
        'txtCommonField2
        '
        Me.txtCommonField2.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtCommonField2.ChrMaxByte = 2048
        Me.txtCommonField2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCommonField2.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtCommonField2.GotHighLight = false
        Me.txtCommonField2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCommonField2.Location = New System.Drawing.Point(7, 466)
        Me.txtCommonField2.MultiLineEx = true
        Me.txtCommonField2.Name = "txtCommonField2"
        Me.txtCommonField2.NgChr = "'"
        Me.txtCommonField2.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCommonField2.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCommonField2.SelectedText = ""
        Me.txtCommonField2.Size = New System.Drawing.Size(818, 66)
        Me.txtCommonField2.TabIndex = 7
        Me.txtCommonField2.TabStop = false
        '
        'lblLengthCount2
        '
        Me.lblLengthCount2.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount2.Location = New System.Drawing.Point(580, 451)
        Me.lblLengthCount2.Name = "lblLengthCount2"
        Me.lblLengthCount2.Size = New System.Drawing.Size(239, 16)
        Me.lblLengthCount2.TabIndex = 26
        Me.lblLengthCount2.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount1
        '
        Me.lblLengthCount1.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount1.Location = New System.Drawing.Point(587, 358)
        Me.lblLengthCount1.Name = "lblLengthCount1"
        Me.lblLengthCount1.Size = New System.Drawing.Size(233, 17)
        Me.lblLengthCount1.TabIndex = 25
        Me.lblLengthCount1.Text = "( 半角128文字/半角128文字 )"
        Me.lblLengthCount1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCommonField2Title
        '
        Me.lblCommonField2Title.BackColor = System.Drawing.Color.Navy
        Me.lblCommonField2Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCommonField2Title.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCommonField2Title.ForeColor = System.Drawing.Color.Yellow
        Me.lblCommonField2Title.Location = New System.Drawing.Point(7, 450)
        Me.lblCommonField2Title.Name = "lblCommonField2Title"
        Me.lblCommonField2Title.Size = New System.Drawing.Size(818, 17)
        Me.lblCommonField2Title.TabIndex = 24
        Me.lblCommonField2Title.Text = "故障現象詳細"
        Me.lblCommonField2Title.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCommonField1Title
        '
        Me.lblCommonField1Title.BackColor = System.Drawing.Color.Navy
        Me.lblCommonField1Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCommonField1Title.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCommonField1Title.ForeColor = System.Drawing.Color.Yellow
        Me.lblCommonField1Title.Location = New System.Drawing.Point(7, 357)
        Me.lblCommonField1Title.Name = "lblCommonField1Title"
        Me.lblCommonField1Title.Size = New System.Drawing.Size(818, 17)
        Me.lblCommonField1Title.TabIndex = 23
        Me.lblCommonField1Title.Text = "故障現象名"
        Me.lblCommonField1Title.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFromTitle
        '
        Me.lblFromTitle.BackColor = System.Drawing.Color.Navy
        Me.lblFromTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFromTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblFromTitle.Location = New System.Drawing.Point(246, 15)
        Me.lblFromTitle.Name = "lblFromTitle"
        Me.lblFromTitle.Size = New System.Drawing.Size(137, 17)
        Me.lblFromTitle.TabIndex = 22
        Me.lblFromTitle.Text = "検索開始日"
        Me.lblFromTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWave
        '
        Me.lblWave.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWave.Location = New System.Drawing.Point(382, 31)
        Me.lblWave.Name = "lblWave"
        Me.lblWave.Size = New System.Drawing.Size(32, 19)
        Me.lblWave.TabIndex = 21
        Me.lblWave.Text = "～"
        '
        'lblToTitle
        '
        Me.lblToTitle.BackColor = System.Drawing.Color.Navy
        Me.lblToTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblToTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblToTitle.Location = New System.Drawing.Point(415, 15)
        Me.lblToTitle.Name = "lblToTitle"
        Me.lblToTitle.Size = New System.Drawing.Size(137, 17)
        Me.lblToTitle.TabIndex = 20
        Me.lblToTitle.Text = "検索終了日"
        Me.lblToTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(647, 31)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
        Me.lblNowDate.TabIndex = 19
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblNowDateTitle
        '
        Me.lblNowDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNowDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNowDateTitle.Location = New System.Drawing.Point(647, 15)
        Me.lblNowDateTitle.Name = "lblNowDateTitle"
        Me.lblNowDateTitle.Size = New System.Drawing.Size(122, 17)
        Me.lblNowDateTitle.TabIndex = 18
        Me.lblNowDateTitle.Text = "情報取得日時"
        Me.lblNowDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDataCnt
        '
        Me.lblDataCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDataCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDataCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDataCnt.Location = New System.Drawing.Point(773, 31)
        Me.lblDataCnt.Name = "lblDataCnt"
        Me.lblDataCnt.Size = New System.Drawing.Size(74, 22)
        Me.lblDataCnt.TabIndex = 17
        Me.lblDataCnt.Text = "0"
        Me.lblDataCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDataCntTitle
        '
        Me.lblDataCntTitle.BackColor = System.Drawing.Color.Navy
        Me.lblDataCntTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataCntTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDataCntTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblDataCntTitle.Location = New System.Drawing.Point(773, 15)
        Me.lblDataCntTitle.Name = "lblDataCntTitle"
        Me.lblDataCntTitle.Size = New System.Drawing.Size(74, 17)
        Me.lblDataCntTitle.TabIndex = 16
        Me.lblDataCntTitle.Text = "該当件数"
        Me.lblDataCntTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWpName
        '
        Me.lblWpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWpName.Location = New System.Drawing.Point(15, 31)
        Me.lblWpName.Name = "lblWpName"
        Me.lblWpName.Size = New System.Drawing.Size(226, 22)
        Me.lblWpName.TabIndex = 15
        Me.lblWpName.Text = "マニュアルスクラバー＃1"
        '
        'lblWpNameTitle
        '
        Me.lblWpNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWpNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWpNameTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblWpNameTitle.Name = "lblWpNameTitle"
        Me.lblWpNameTitle.Size = New System.Drawing.Size(226, 17)
        Me.lblWpNameTitle.TabIndex = 14
        Me.lblWpNameTitle.Text = "装置名"
        Me.lblWpNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHeaderInfo
        '
        Me.lblHeaderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeaderInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblHeaderInfo.Location = New System.Drawing.Point(8, 8)
        Me.lblHeaderInfo.Name = "lblHeaderInfo"
        Me.lblHeaderInfo.Size = New System.Drawing.Size(843, 56)
        Me.lblHeaderInfo.TabIndex = 0
        '
        'frmxxCM00Z1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(857, 590)
        Me.Controls.Add(Me.cmdField1Up)
        Me.Controls.Add(Me.cmdField1Down)
        Me.Controls.Add(Me.cmdNewEntry)
        Me.Controls.Add(Me.cmdField2Down)
        Me.Controls.Add(Me.cmdField2Up)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.vsfMainteList)
        Me.Controls.Add(Me.calStart)
        Me.Controls.Add(Me.calEnd)
        Me.Controls.Add(Me.txtCommonField1)
        Me.Controls.Add(Me.txtCommonField2)
        Me.Controls.Add(Me.lblLengthCount2)
        Me.Controls.Add(Me.lblLengthCount1)
        Me.Controls.Add(Me.lblCommonField2Title)
        Me.Controls.Add(Me.lblCommonField1Title)
        Me.Controls.Add(Me.lblFromTitle)
        Me.Controls.Add(Me.lblWave)
        Me.Controls.Add(Me.lblToTitle)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblNowDateTitle)
        Me.Controls.Add(Me.lblDataCnt)
        Me.Controls.Add(Me.lblDataCntTitle)
        Me.Controls.Add(Me.lblWpName)
        Me.Controls.Add(Me.lblWpNameTitle)
        Me.Controls.Add(Me.lblHeaderInfo)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00Z1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "故障現象名選択/保全記録票選択"
        CType(Me.vsfMainteList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdField1Up As Button
    Friend WithEvents cmdField1Down As Button
    Friend WithEvents cmdNewEntry As Button
    Friend WithEvents cmdField2Down As Button
    Friend WithEvents cmdField2Up As Button
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents vsfMainteList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents calStart As SECalendarEx.CalendarEx
    Friend WithEvents calEnd As SECalendarEx.CalendarEx
    Friend WithEvents txtCommonField1 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCommonField2 As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLengthCount2 As Label
    Friend WithEvents lblLengthCount1 As Label
    Friend WithEvents lblCommonField2Title As Label
    Friend WithEvents lblCommonField1Title As Label
    Friend WithEvents lblFromTitle As Label
    Friend WithEvents lblWave As Label
    Friend WithEvents lblToTitle As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblNowDateTitle As Label
    Friend WithEvents lblDataCnt As Label
    Friend WithEvents lblDataCntTitle As Label
    Friend WithEvents lblWpName As Label
    Friend WithEvents lblWpNameTitle As Label
    Friend WithEvents lblHeaderInfo As Label
End Class
