<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00V0
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00V0))
		Me.cmdApplyCancel = New System.Windows.Forms.Button()
		Me.cmdCopy = New System.Windows.Forms.Button()
		Me.cmdMailSend = New System.Windows.Forms.Button()
		Me.cmdDiscon = New System.Windows.Forms.Button()
		Me.cmbSearch = New SECmbIchiran.ComboIchiran()
		Me.vsfExcpList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.cmdNowList = New System.Windows.Forms.Button()
		Me.cmdApply = New System.Windows.Forms.Button()
		Me.cmdRegist = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.calStart = New SECalendarEx.CalendarEx()
		Me.calEnd = New SECalendarEx.CalendarEx()
		Me.txtEmpID = New SETextBoxEx.TextBoxEx()
		Me.txtProcEmpID = New SETextBoxEx.TextBoxEx()
		Me.cmbSBID = New SEComboBoxEx.ComboBoxEx()
		Me.lblTitle10 = New System.Windows.Forms.Label()
		Me.lblTitle9 = New System.Windows.Forms.Label()
		Me.lblTitle8 = New System.Windows.Forms.Label()
		Me.lblProcEmpName = New System.Windows.Forms.Label()
		Me.lblEmpName = New System.Windows.Forms.Label()
		Me.lblTitle6 = New System.Windows.Forms.Label()
		Me.lblTitle5 = New System.Windows.Forms.Label()
		Me.lblTitle1 = New System.Windows.Forms.Label()
		Me.lblTitle2 = New System.Windows.Forms.Label()
		Me.lblLotCnt = New System.Windows.Forms.Label()
		Me.lblTitle4 = New System.Windows.Forms.Label()
		Me.lblNowDate = New System.Windows.Forms.Label()
		Me.lblTitle0 = New System.Windows.Forms.Label()
		Me.lblTitle7 = New System.Windows.Forms.Label()
		Me.lblTitle3 = New System.Windows.Forms.Label()
		CType(Me.vsfExcpList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'cmdApplyCancel
		'
		Me.cmdApplyCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdApplyCancel.Location = New System.Drawing.Point(696, 596)
		Me.cmdApplyCancel.Name = "cmdApplyCancel"
		Me.cmdApplyCancel.Size = New System.Drawing.Size(85, 40)
		Me.cmdApplyCancel.TabIndex = 10
		Me.cmdApplyCancel.Text = "承認取消"
		'
		'cmdCopy
		'
		Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCopy.Location = New System.Drawing.Point(200, 596)
		Me.cmdCopy.Name = "cmdCopy"
		Me.cmdCopy.Size = New System.Drawing.Size(85, 40)
		Me.cmdCopy.TabIndex = 13
		Me.cmdCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
		'
		'cmdMailSend
		'
		Me.cmdMailSend.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdMailSend.Location = New System.Drawing.Point(504, 596)
		Me.cmdMailSend.Name = "cmdMailSend"
		Me.cmdMailSend.Size = New System.Drawing.Size(85, 40)
		Me.cmdMailSend.TabIndex = 8
		Me.cmdMailSend.Text = "確認依頼"
		'
		'cmdDiscon
		'
		Me.cmdDiscon.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdDiscon.Location = New System.Drawing.Point(600, 596)
		Me.cmdDiscon.Name = "cmdDiscon"
		Me.cmdDiscon.Size = New System.Drawing.Size(85, 40)
		Me.cmdDiscon.TabIndex = 9
		Me.cmdDiscon.Text = "破　棄"
		'
		'cmbSearch
		'
		Me.cmbSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbSearch.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbSearch.Location = New System.Drawing.Point(292, 24)
		Me.cmbSearch.Name = "cmbSearch"
		Me.cmbSearch.Size = New System.Drawing.Size(119, 22)
		Me.cmbSearch.TabIndex = 2
		Me.cmbSearch.Value = Nothing
		'
		'vsfExcpList
		'
		Me.vsfExcpList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfExcpList.AllowEditing = false
		Me.vsfExcpList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfExcpList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfExcpList.AutoResize = true
		Me.vsfExcpList.AutoSearchDelay = 2R
		Me.vsfExcpList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfExcpList.ColumnInfo = resources.GetString("vsfExcpList.ColumnInfo")
		Me.vsfExcpList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfExcpList.ExtendLastCol = true
		Me.vsfExcpList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfExcpList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfExcpList.Location = New System.Drawing.Point(8, 102)
		Me.vsfExcpList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfExcpList.Name = "vsfExcpList"
		Me.vsfExcpList.Rows.DefaultSize = 19
		Me.vsfExcpList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfExcpList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfExcpList.Size = New System.Drawing.Size(961, 488)
		Me.vsfExcpList.StyleInfo = resources.GetString("vsfExcpList.StyleInfo")
		Me.vsfExcpList.TabIndex = 6
		'
		'cmdNowList
		'
		Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdNowList.Location = New System.Drawing.Point(672, 8)
		Me.cmdNowList.Name = "cmdNowList"
		Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
		Me.cmdNowList.TabIndex = 12
		Me.cmdNowList.Text = "最新取得"
		'
		'cmdApply
		'
		Me.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdApply.Location = New System.Drawing.Point(792, 596)
		Me.cmdApply.Name = "cmdApply"
		Me.cmdApply.Size = New System.Drawing.Size(85, 40)
		Me.cmdApply.TabIndex = 11
		Me.cmdApply.Text = "承　認"
		Me.cmdApply.Visible = false
		'
		'cmdRegist
		'
		Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRegist.Location = New System.Drawing.Point(888, 596)
		Me.cmdRegist.Name = "cmdRegist"
		Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
		Me.cmdRegist.TabIndex = 7
		Me.cmdRegist.Text = "編　集"
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Location = New System.Drawing.Point(8, 596)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(85, 40)
		Me.cmdClose.TabIndex = 14
		Me.cmdClose.Text = "閉じる"
		'
		'calStart
		'
		Me.calStart.DateCheckStatus = 0
		Me.calStart.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calStart.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calStart.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calStart.IsDate = true
		Me.calStart.Location = New System.Drawing.Point(8, 24)
		Me.calStart.Name = "calStart"
		Me.calStart.Size = New System.Drawing.Size(119, 22)
		Me.calStart.TabIndex = 0
		Me.calStart.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calStart.Value = "____/__/__"
		'
		'calEnd
		'
		Me.calEnd.DateCheckStatus = 0
		Me.calEnd.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calEnd.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calEnd.IsDate = true
		Me.calEnd.Location = New System.Drawing.Point(164, 24)
		Me.calEnd.Name = "calEnd"
		Me.calEnd.Size = New System.Drawing.Size(119, 22)
		Me.calEnd.TabIndex = 1
		Me.calEnd.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calEnd.Value = "____/__/__"
		'
		'txtEmpID
		'
		Me.txtEmpID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtEmpID.ChrMaxByte = 7
		Me.txtEmpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtEmpID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtEmpID.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtEmpID.Location = New System.Drawing.Point(292, 72)
		Me.txtEmpID.Name = "txtEmpID"
		Me.txtEmpID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtEmpID.NumMax = New Decimal(New Integer() {9999999, 0, 0, 0})
		Me.txtEmpID.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
		Me.txtEmpID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtEmpID.SelectedText = ""
		Me.txtEmpID.Size = New System.Drawing.Size(119, 22)
		Me.txtEmpID.TabIndex = 5
		'
		'txtProcEmpID
		'
		Me.txtProcEmpID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtProcEmpID.ChrMaxByte = 7
		Me.txtProcEmpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtProcEmpID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtProcEmpID.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtProcEmpID.Location = New System.Drawing.Point(8, 72)
		Me.txtProcEmpID.Name = "txtProcEmpID"
		Me.txtProcEmpID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtProcEmpID.NumMax = New Decimal(New Integer() {9999999, 0, 0, 0})
		Me.txtProcEmpID.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
		Me.txtProcEmpID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtProcEmpID.SelectedText = ""
		Me.txtProcEmpID.Size = New System.Drawing.Size(119, 22)
		Me.txtProcEmpID.TabIndex = 4
		'
		'cmbSBID
		'
		Me.cmbSBID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbSBID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbSBID.Location = New System.Drawing.Point(420, 24)
		Me.cmbSBID.Name = "cmbSBID"
		Me.cmbSBID.Size = New System.Drawing.Size(119, 22)
		Me.cmbSBID.TabIndex = 3
		Me.cmbSBID.Value = Nothing
		'
		'lblTitle10
		'
		Me.lblTitle10.BackColor = System.Drawing.Color.Navy
		Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle10.Location = New System.Drawing.Point(420, 8)
		Me.lblTitle10.Name = "lblTitle10"
		Me.lblTitle10.Size = New System.Drawing.Size(119, 17)
		Me.lblTitle10.TabIndex = 29
		Me.lblTitle10.Text = "起票SB"
		Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle9
		'
		Me.lblTitle9.BackColor = System.Drawing.Color.Navy
		Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle9.Location = New System.Drawing.Point(8, 56)
		Me.lblTitle9.Name = "lblTitle9"
		Me.lblTitle9.Size = New System.Drawing.Size(119, 17)
		Me.lblTitle9.TabIndex = 28
		Me.lblTitle9.Text = "担当者ID"
		Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle8
		'
		Me.lblTitle8.BackColor = System.Drawing.Color.Navy
		Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle8.Location = New System.Drawing.Point(126, 56)
		Me.lblTitle8.Name = "lblTitle8"
		Me.lblTitle8.Size = New System.Drawing.Size(155, 17)
		Me.lblTitle8.TabIndex = 27
		Me.lblTitle8.Text = "担当者名"
		Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblProcEmpName
		'
		Me.lblProcEmpName.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblProcEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblProcEmpName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblProcEmpName.Location = New System.Drawing.Point(126, 72)
		Me.lblProcEmpName.Name = "lblProcEmpName"
		Me.lblProcEmpName.Size = New System.Drawing.Size(155, 22)
		Me.lblProcEmpName.TabIndex = 26
		'
		'lblEmpName
		'
		Me.lblEmpName.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblEmpName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblEmpName.Location = New System.Drawing.Point(410, 72)
		Me.lblEmpName.Name = "lblEmpName"
		Me.lblEmpName.Size = New System.Drawing.Size(155, 22)
		Me.lblEmpName.TabIndex = 25
		'
		'lblTitle6
		'
		Me.lblTitle6.BackColor = System.Drawing.Color.Navy
		Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle6.Location = New System.Drawing.Point(410, 56)
		Me.lblTitle6.Name = "lblTitle6"
		Me.lblTitle6.Size = New System.Drawing.Size(155, 17)
		Me.lblTitle6.TabIndex = 24
		Me.lblTitle6.Text = "起案者名"
		Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle5
		'
		Me.lblTitle5.BackColor = System.Drawing.Color.Navy
		Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle5.Location = New System.Drawing.Point(292, 56)
		Me.lblTitle5.Name = "lblTitle5"
		Me.lblTitle5.Size = New System.Drawing.Size(119, 17)
		Me.lblTitle5.TabIndex = 23
		Me.lblTitle5.Text = "起案者ID"
		Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle1
		'
		Me.lblTitle1.BackColor = System.Drawing.Color.Navy
		Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle1.Location = New System.Drawing.Point(292, 8)
		Me.lblTitle1.Name = "lblTitle1"
		Me.lblTitle1.Size = New System.Drawing.Size(119, 17)
		Me.lblTitle1.TabIndex = 22
		Me.lblTitle1.Text = "検索条件"
		Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle2
		'
		Me.lblTitle2.BackColor = System.Drawing.Color.Navy
		Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle2.Location = New System.Drawing.Point(896, 8)
		Me.lblTitle2.Name = "lblTitle2"
		Me.lblTitle2.Size = New System.Drawing.Size(73, 17)
		Me.lblTitle2.TabIndex = 21
		Me.lblTitle2.Text = "該当件数"
		Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblLotCnt
		'
		Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblLotCnt.Location = New System.Drawing.Point(896, 24)
		Me.lblLotCnt.Name = "lblLotCnt"
		Me.lblLotCnt.Size = New System.Drawing.Size(73, 21)
		Me.lblLotCnt.TabIndex = 20
		Me.lblLotCnt.Text = "0"
		Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle4
		'
		Me.lblTitle4.BackColor = System.Drawing.Color.Navy
		Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle4.Location = New System.Drawing.Point(766, 8)
		Me.lblTitle4.Name = "lblTitle4"
		Me.lblTitle4.Size = New System.Drawing.Size(122, 17)
		Me.lblTitle4.TabIndex = 19
		Me.lblTitle4.Text = "情報取得日時"
		Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNowDate
		'
		Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate.Location = New System.Drawing.Point(766, 24)
		Me.lblNowDate.Name = "lblNowDate"
		Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
		Me.lblNowDate.TabIndex = 18
		'
		'lblTitle0
		'
		Me.lblTitle0.BackColor = System.Drawing.Color.Navy
		Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle0.Location = New System.Drawing.Point(164, 8)
		Me.lblTitle0.Name = "lblTitle0"
		Me.lblTitle0.Size = New System.Drawing.Size(119, 17)
		Me.lblTitle0.TabIndex = 17
		Me.lblTitle0.Text = "終了日"
		Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle7
		'
		Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle7.Location = New System.Drawing.Point(130, 24)
		Me.lblTitle7.Name = "lblTitle7"
		Me.lblTitle7.Size = New System.Drawing.Size(32, 19)
		Me.lblTitle7.TabIndex = 16
		Me.lblTitle7.Text = "～"
		'
		'lblTitle3
		'
		Me.lblTitle3.BackColor = System.Drawing.Color.Navy
		Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle3.Location = New System.Drawing.Point(8, 8)
		Me.lblTitle3.Name = "lblTitle3"
		Me.lblTitle3.Size = New System.Drawing.Size(119, 17)
		Me.lblTitle3.TabIndex = 15
		Me.lblTitle3.Text = "開始日"
		Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'frmxxEN00V0
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(985, 642)
		Me.Controls.Add(Me.cmdApplyCancel)
		Me.Controls.Add(Me.cmdCopy)
		Me.Controls.Add(Me.cmdMailSend)
		Me.Controls.Add(Me.cmdDiscon)
		Me.Controls.Add(Me.cmbSearch)
		Me.Controls.Add(Me.vsfExcpList)
		Me.Controls.Add(Me.cmdNowList)
		Me.Controls.Add(Me.cmdApply)
		Me.Controls.Add(Me.cmdRegist)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.calStart)
		Me.Controls.Add(Me.calEnd)
		Me.Controls.Add(Me.txtEmpID)
		Me.Controls.Add(Me.txtProcEmpID)
		Me.Controls.Add(Me.cmbSBID)
		Me.Controls.Add(Me.lblTitle10)
		Me.Controls.Add(Me.lblTitle9)
		Me.Controls.Add(Me.lblTitle8)
		Me.Controls.Add(Me.lblProcEmpName)
		Me.Controls.Add(Me.lblEmpName)
		Me.Controls.Add(Me.lblTitle6)
		Me.Controls.Add(Me.lblTitle5)
		Me.Controls.Add(Me.lblTitle1)
		Me.Controls.Add(Me.lblTitle2)
		Me.Controls.Add(Me.lblLotCnt)
		Me.Controls.Add(Me.lblTitle4)
		Me.Controls.Add(Me.lblNowDate)
		Me.Controls.Add(Me.lblTitle0)
		Me.Controls.Add(Me.lblTitle7)
		Me.Controls.Add(Me.lblTitle3)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(18, 25)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN00V0"
		Me.Text = "工程異常/不適合品処理票一覧"
		CType(Me.vsfExcpList,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdApplyCancel As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdMailSend As Button
    Friend WithEvents cmdDiscon As Button
    Friend WithEvents cmbSearch As SECmbIchiran.ComboIchiran
    Friend WithEvents vsfExcpList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdApply As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents calStart As SECalendarEx.CalendarEx
    Friend WithEvents calEnd As SECalendarEx.CalendarEx
    Friend WithEvents txtEmpID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtProcEmpID As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbSBID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblProcEmpName As Label
    Friend WithEvents lblEmpName As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle3 As Label
End Class
