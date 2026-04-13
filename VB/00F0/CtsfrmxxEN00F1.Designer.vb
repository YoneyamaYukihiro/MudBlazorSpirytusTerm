<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00F1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00F1))
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraHold = New System.Windows.Forms.GroupBox()
        Me.fraHoldSet = New System.Windows.Forms.GroupBox()
        Me.cmdHoldTxtDown = New System.Windows.Forms.Button()
        Me.cmdHoldTxtUp = New System.Windows.Forms.Button()
        Me.txtHoldComment = New SETextBoxEx.TextBoxEx()
        Me.dtpHoldTermDate = New SECalendarEx.CalendarEx()
        Me.cmbMasHold = New SEComboBoxEx.ComboBoxEx()
        Me.cmbHoldEmpName = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitleHoldComment = New System.Windows.Forms.Label()
        Me.fraHoldList = New System.Windows.Forms.GroupBox()
        Me.cmdTxtUp = New System.Windows.Forms.Button()
        Me.cmdTxtDown = New System.Windows.Forms.Button()
        Me.vsfLotHoldList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtHoldCommentView = New SETextBoxEx.TextBoxEx()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.fraHold.SuspendLayout
        Me.fraHoldSet.SuspendLayout
        Me.fraHoldList.SuspendLayout
        CType(Me.vsfLotHoldList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Location = New System.Drawing.Point(718, 500)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 4
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 500)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "閉じる"
        '
        'fraHold
        '
        Me.fraHold.Controls.Add(Me.fraHoldSet)
        Me.fraHold.Controls.Add(Me.fraHoldList)
        Me.fraHold.Controls.Add(Me.lblCarrier)
        Me.fraHold.Controls.Add(Me.lblFlowClass)
        Me.fraHold.Controls.Add(Me.lblLotID)
        Me.fraHold.Controls.Add(Me.lblTitle1)
        Me.fraHold.Controls.Add(Me.lblTitle2)
        Me.fraHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraHold.Location = New System.Drawing.Point(8, 8)
        Me.fraHold.Name = "fraHold"
        Me.fraHold.Size = New System.Drawing.Size(795, 481)
        Me.fraHold.TabIndex = 11
        Me.fraHold.TabStop = false
        Me.fraHold.Text = "保留/保留解除"
        '
        'fraHoldSet
        '
        Me.fraHoldSet.Controls.Add(Me.cmdHoldTxtDown)
        Me.fraHoldSet.Controls.Add(Me.cmdHoldTxtUp)
        Me.fraHoldSet.Controls.Add(Me.txtHoldComment)
        Me.fraHoldSet.Controls.Add(Me.dtpHoldTermDate)
        Me.fraHoldSet.Controls.Add(Me.cmbMasHold)
        Me.fraHoldSet.Controls.Add(Me.cmbHoldEmpName)
        Me.fraHoldSet.Controls.Add(Me.lblTitle5)
        Me.fraHoldSet.Controls.Add(Me.lblLengthCount)
        Me.fraHoldSet.Controls.Add(Me.lblTitle4)
        Me.fraHoldSet.Controls.Add(Me.lblTitle3)
        Me.fraHoldSet.Controls.Add(Me.lblTitleHoldComment)
        Me.fraHoldSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraHoldSet.Location = New System.Drawing.Point(12, 312)
        Me.fraHoldSet.Name = "fraHoldSet"
        Me.fraHoldSet.Size = New System.Drawing.Size(769, 157)
        Me.fraHoldSet.TabIndex = 20
        Me.fraHoldSet.TabStop = false
        Me.fraHoldSet.Text = "保留設定"
        '
        'cmdHoldTxtDown
        '
        Me.cmdHoldTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldTxtDown.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHoldTxtDown.Location = New System.Drawing.Point(729, 106)
        Me.cmdHoldTxtDown.Name = "cmdHoldTxtDown"
        Me.cmdHoldTxtDown.Size = New System.Drawing.Size(25, 38)
        Me.cmdHoldTxtDown.TabIndex = 10
        Me.cmdHoldTxtDown.Text = "▼"
        '
        'cmdHoldTxtUp
        '
        Me.cmdHoldTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldTxtUp.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHoldTxtUp.Location = New System.Drawing.Point(729, 68)
        Me.cmdHoldTxtUp.Name = "cmdHoldTxtUp"
        Me.cmdHoldTxtUp.Size = New System.Drawing.Size(25, 38)
        Me.cmdHoldTxtUp.TabIndex = 9
        Me.cmdHoldTxtUp.Text = "▲"
        '
        'txtHoldComment
        '
        Me.txtHoldComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtHoldComment.ChrMaxByte = 2048
        Me.txtHoldComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtHoldComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtHoldComment.GotHighLight = false
        Me.txtHoldComment.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtHoldComment.Location = New System.Drawing.Point(12, 84)
        Me.txtHoldComment.MultiLineEx = true
        Me.txtHoldComment.Name = "txtHoldComment"
        Me.txtHoldComment.NgChr = "'"
        Me.txtHoldComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtHoldComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHoldComment.SelectedText = ""
        Me.txtHoldComment.Size = New System.Drawing.Size(717, 59)
        Me.txtHoldComment.TabIndex = 5
        '
        'dtpHoldTermDate
        '
        Me.dtpHoldTermDate.DateCheckStatus = 0
        Me.dtpHoldTermDate.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpHoldTermDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpHoldTermDate.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpHoldTermDate.IsDate = true
        Me.dtpHoldTermDate.Location = New System.Drawing.Point(292, 36)
        Me.dtpHoldTermDate.Name = "dtpHoldTermDate"
        Me.dtpHoldTermDate.Size = New System.Drawing.Size(153, 22)
        Me.dtpHoldTermDate.TabIndex = 2
        Me.dtpHoldTermDate.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpHoldTermDate.Value = "____/__/__"
        '
        'cmbMasHold
        '
        Me.cmbMasHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMasHold.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMasHold.Location = New System.Drawing.Point(12, 36)
        Me.cmbMasHold.Name = "cmbMasHold"
        Me.cmbMasHold.Size = New System.Drawing.Size(281, 22)
        Me.cmbMasHold.TabIndex = 1
        Me.cmbMasHold.Value = Nothing
        '
        'cmbHoldEmpName
        '
        Me.cmbHoldEmpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbHoldEmpName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbHoldEmpName.Location = New System.Drawing.Point(444, 36)
        Me.cmbHoldEmpName.Name = "cmbHoldEmpName"
        Me.cmbHoldEmpName.Size = New System.Drawing.Size(285, 22)
        Me.cmbHoldEmpName.TabIndex = 3
        Me.cmbHoldEmpName.Value = Nothing
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(444, 20)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(285, 17)
        Me.lblTitle5.TabIndex = 25
        Me.lblTitle5.Text = "保留責任者"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(474, 69)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 15)
        Me.lblLengthCount.TabIndex = 23
        Me.lblLengthCount.Text = "（ 半角0文字/半角2048文字 ）"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(292, 20)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(153, 17)
        Me.lblTitle4.TabIndex = 22
        Me.lblTitle4.Text = "保留期限"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(12, 20)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(281, 17)
        Me.lblTitle3.TabIndex = 21
        Me.lblTitle3.Text = "保留理由"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleHoldComment
        '
        Me.lblTitleHoldComment.BackColor = System.Drawing.Color.Navy
        Me.lblTitleHoldComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHoldComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitleHoldComment.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleHoldComment.Location = New System.Drawing.Point(12, 68)
        Me.lblTitleHoldComment.Name = "lblTitleHoldComment"
        Me.lblTitleHoldComment.Size = New System.Drawing.Size(717, 17)
        Me.lblTitleHoldComment.TabIndex = 24
        Me.lblTitleHoldComment.Text = "保留コメント"
        Me.lblTitleHoldComment.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraHoldList
        '
        Me.fraHoldList.Controls.Add(Me.cmdTxtUp)
        Me.fraHoldList.Controls.Add(Me.cmdTxtDown)
        Me.fraHoldList.Controls.Add(Me.vsfLotHoldList)
        Me.fraHoldList.Controls.Add(Me.txtHoldCommentView)
        Me.fraHoldList.Controls.Add(Me.lblTitle0)
        Me.fraHoldList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraHoldList.Location = New System.Drawing.Point(12, 64)
        Me.fraHoldList.Name = "fraHoldList"
        Me.fraHoldList.Size = New System.Drawing.Size(767, 241)
        Me.fraHoldList.TabIndex = 17
        Me.fraHoldList.TabStop = false
        Me.fraHoldList.Text = "保留情報"
        '
        'cmdTxtUp
        '
        Me.cmdTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUp.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtUp.Location = New System.Drawing.Point(729, 152)
        Me.cmdTxtUp.Name = "cmdTxtUp"
        Me.cmdTxtUp.Size = New System.Drawing.Size(25, 38)
        Me.cmdTxtUp.TabIndex = 7
        Me.cmdTxtUp.Text = "▲"
        '
        'cmdTxtDown
        '
        Me.cmdTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDown.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtDown.Location = New System.Drawing.Point(729, 190)
        Me.cmdTxtDown.Name = "cmdTxtDown"
        Me.cmdTxtDown.Size = New System.Drawing.Size(25, 38)
        Me.cmdTxtDown.TabIndex = 8
        Me.cmdTxtDown.Text = "▼"
        '
        'vsfLotHoldList
        '
        Me.vsfLotHoldList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotHoldList.AllowEditing = false
        Me.vsfLotHoldList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotHoldList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLotHoldList.AutoResize = true
        Me.vsfLotHoldList.AutoSearchDelay = 2R
        Me.vsfLotHoldList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotHoldList.ColumnInfo = resources.GetString("vsfLotHoldList.ColumnInfo")
        Me.vsfLotHoldList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotHoldList.ExtendLastCol = true
        Me.vsfLotHoldList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotHoldList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotHoldList.Location = New System.Drawing.Point(12, 20)
        Me.vsfLotHoldList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotHoldList.Name = "vsfLotHoldList"
        Me.vsfLotHoldList.Rows.Count = 5
        Me.vsfLotHoldList.Rows.DefaultSize = 18
        Me.vsfLotHoldList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotHoldList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotHoldList.Size = New System.Drawing.Size(745, 121)
        Me.vsfLotHoldList.StyleInfo = resources.GetString("vsfLotHoldList.StyleInfo")
        Me.vsfLotHoldList.TabIndex = 0
        '
        'txtHoldCommentView
        '
        Me.txtHoldCommentView.BackColor = System.Drawing.SystemColors.Control
        Me.txtHoldCommentView.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtHoldCommentView.ChrMaxByte = 2048
        Me.txtHoldCommentView.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtHoldCommentView.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtHoldCommentView.GotHighLight = false
        Me.txtHoldCommentView.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtHoldCommentView.Location = New System.Drawing.Point(12, 168)
        Me.txtHoldCommentView.MultiLineEx = true
        Me.txtHoldCommentView.Name = "txtHoldCommentView"
        Me.txtHoldCommentView.NgChr = "'"
        Me.txtHoldCommentView.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtHoldCommentView.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHoldCommentView.SelectedText = ""
        Me.txtHoldCommentView.Size = New System.Drawing.Size(717, 59)
        Me.txtHoldCommentView.TabIndex = 18
        Me.txtHoldCommentView.TabStop = false
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(12, 152)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(717, 17)
        Me.lblTitle0.TabIndex = 19
        Me.lblTitle0.Text = "保留コメント"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCarrier
        '
        Me.lblCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblCarrier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrier.Location = New System.Drawing.Point(12, 36)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(97, 22)
        Me.lblCarrier.TabIndex = 16
        Me.lblCarrier.Text = "GTA1234-00"
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(228, 36)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 22)
        Me.lblFlowClass.TabIndex = 15
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(108, 36)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 22)
        Me.lblLotID.TabIndex = 14
        Me.lblLotID.Text = "GTA1234-00"
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(12, 20)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle1.TabIndex = 13
        Me.lblTitle1.Text = "キャリアID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(108, 20)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle2.TabIndex = 12
        Me.lblTitle2.Text = "ロットID"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00F1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(813, 548)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraHold)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(341, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00F1"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "在庫保留/保留解除"
        Me.fraHold.ResumeLayout(false)
        Me.fraHoldSet.ResumeLayout(false)
        Me.fraHoldList.ResumeLayout(false)
        CType(Me.vsfLotHoldList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraHold As GroupBox
    Friend WithEvents fraHoldSet As GroupBox
    Friend WithEvents cmdHoldTxtDown As Button
    Friend WithEvents cmdHoldTxtUp As Button
    Friend WithEvents txtHoldComment As SETextBoxEx.TextBoxEx
    Friend WithEvents dtpHoldTermDate As SECalendarEx.CalendarEx
    Friend WithEvents cmbMasHold As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbHoldEmpName As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitleHoldComment As Label
    Friend WithEvents fraHoldList As GroupBox
    Friend WithEvents cmdTxtUp As Button
    Friend WithEvents cmdTxtDown As Button
    Friend WithEvents vsfLotHoldList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtHoldCommentView As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblCarrier As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle2 As Label
End Class
