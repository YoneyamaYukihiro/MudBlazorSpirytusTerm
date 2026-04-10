<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM0070
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM0070))
        Me.fraWFInfo = New System.Windows.Forms.GroupBox()
        Me.vsfWFList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdDown2 = New System.Windows.Forms.Button()
        Me.cmdUp2 = New System.Windows.Forms.Button()
        Me.fraCodeList = New System.Windows.Forms.GroupBox()
        Me.vsfCodeList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdUp1 = New System.Windows.Forms.Button()
        Me.cmdDown1 = New System.Windows.Forms.Button()
        Me.cmdHoldReason = New System.Windows.Forms.Button()
        Me.cmdTakeReason = New System.Windows.Forms.Button()
        Me.cmdScrapCode = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdConfirm = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdScrap = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.txtEmpID = New SETextBoxEx.TextBoxEx()
        Me.lblTitle15 = New System.Windows.Forms.Label()
        Me.lblEmpName = New System.Windows.Forms.Label()
        Me.lblTitle13 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblStepName = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblOpName = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.fraWFInfo.SuspendLayout
        CType(Me.vsfWFList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCodeList.SuspendLayout
        CType(Me.vsfCodeList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraWFInfo
        '
        Me.fraWFInfo.Controls.Add(Me.vsfWFList)
        Me.fraWFInfo.Controls.Add(Me.cmdDown2)
        Me.fraWFInfo.Controls.Add(Me.cmdUp2)
        Me.fraWFInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraWFInfo.Location = New System.Drawing.Point(667, 120)
        Me.fraWFInfo.Name = "fraWFInfo"
        Me.fraWFInfo.Size = New System.Drawing.Size(305, 453)
        Me.fraWFInfo.TabIndex = 3
        Me.fraWFInfo.TabStop = false
        Me.fraWFInfo.Text = "WF情報"
        '
        'vsfWFList
        '
        Me.vsfWFList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWFList.AllowEditing = false
        Me.vsfWFList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWFList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfWFList.AutoResize = true
        Me.vsfWFList.AutoSearchDelay = 2R
        Me.vsfWFList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWFList.ColumnInfo = resources.GetString("vsfWFList.ColumnInfo")
        Me.vsfWFList.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.vsfWFList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWFList.ExtendLastCol = true
        Me.vsfWFList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfWFList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWFList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWFList.Location = New System.Drawing.Point(12, 20)
        Me.vsfWFList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWFList.Name = "vsfWFList"
        Me.vsfWFList.Rows.Count = 26
        Me.vsfWFList.Rows.DefaultSize = 38
        Me.vsfWFList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfWFList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWFList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfWFList.Size = New System.Drawing.Size(231, 420)
        Me.vsfWFList.StyleInfo = resources.GetString("vsfWFList.StyleInfo")
        Me.vsfWFList.TabIndex = 8
        '
        'cmdDown2
        '
        Me.cmdDown2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown2.Location = New System.Drawing.Point(243, 230)
        Me.cmdDown2.Name = "cmdDown2"
        Me.cmdDown2.Size = New System.Drawing.Size(49, 211)
        Me.cmdDown2.TabIndex = 10
        Me.cmdDown2.Text = "▼"
        '
        'cmdUp2
        '
        Me.cmdUp2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp2.Location = New System.Drawing.Point(243, 19)
        Me.cmdUp2.Name = "cmdUp2"
        Me.cmdUp2.Size = New System.Drawing.Size(49, 211)
        Me.cmdUp2.TabIndex = 9
        Me.cmdUp2.Text = "▲"
        '
        'fraCodeList
        '
        Me.fraCodeList.Controls.Add(Me.vsfCodeList)
        Me.fraCodeList.Controls.Add(Me.cmdUp1)
        Me.fraCodeList.Controls.Add(Me.cmdDown1)
        Me.fraCodeList.Controls.Add(Me.cmdHoldReason)
        Me.fraCodeList.Controls.Add(Me.cmdTakeReason)
        Me.fraCodeList.Controls.Add(Me.cmdScrapCode)
        Me.fraCodeList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCodeList.Location = New System.Drawing.Point(8, 120)
        Me.fraCodeList.Name = "fraCodeList"
        Me.fraCodeList.Size = New System.Drawing.Size(648, 453)
        Me.fraCodeList.TabIndex = 2
        Me.fraCodeList.TabStop = false
        Me.fraCodeList.Text = "コード一覧"
        '
        'vsfCodeList
        '
        Me.vsfCodeList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCodeList.AllowEditing = false
        Me.vsfCodeList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfCodeList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfCodeList.AutoResize = true
        Me.vsfCodeList.AutoSearchDelay = 2R
        Me.vsfCodeList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCodeList.ColumnInfo = resources.GetString("vsfCodeList.ColumnInfo")
        Me.vsfCodeList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCodeList.ExtendLastCol = true
        Me.vsfCodeList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCodeList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCodeList.Location = New System.Drawing.Point(136, 20)
        Me.vsfCodeList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCodeList.Name = "vsfCodeList"
        Me.vsfCodeList.Rows.Count = 30
        Me.vsfCodeList.Rows.DefaultSize = 38
        Me.vsfCodeList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfCodeList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCodeList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCodeList.Size = New System.Drawing.Size(452, 420)
        Me.vsfCodeList.StyleInfo = resources.GetString("vsfCodeList.StyleInfo")
        Me.vsfCodeList.TabIndex = 5
        '
        'cmdUp1
        '
        Me.cmdUp1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp1.Location = New System.Drawing.Point(588, 19)
        Me.cmdUp1.Name = "cmdUp1"
        Me.cmdUp1.Size = New System.Drawing.Size(49, 211)
        Me.cmdUp1.TabIndex = 6
        Me.cmdUp1.Text = "▲"
        '
        'cmdDown1
        '
        Me.cmdDown1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown1.Location = New System.Drawing.Point(588, 230)
        Me.cmdDown1.Name = "cmdDown1"
        Me.cmdDown1.Size = New System.Drawing.Size(49, 211)
        Me.cmdDown1.TabIndex = 7
        Me.cmdDown1.Text = "▼"
        '
        'cmdHoldReason
        '
        Me.cmdHoldReason.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldReason.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHoldReason.Location = New System.Drawing.Point(16, 296)
        Me.cmdHoldReason.Name = "cmdHoldReason"
        Me.cmdHoldReason.Size = New System.Drawing.Size(105, 57)
        Me.cmdHoldReason.TabIndex = 4
        Me.cmdHoldReason.Text = "保留理由"
        '
        'cmdTakeReason
        '
        Me.cmdTakeReason.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTakeReason.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTakeReason.Location = New System.Drawing.Point(16, 216)
        Me.cmdTakeReason.Name = "cmdTakeReason"
        Me.cmdTakeReason.Size = New System.Drawing.Size(105, 57)
        Me.cmdTakeReason.TabIndex = 3
        Me.cmdTakeReason.Text = "払出理由"
        '
        'cmdScrapCode
        '
        Me.cmdScrapCode.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScrapCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScrapCode.Location = New System.Drawing.Point(16, 136)
        Me.cmdScrapCode.Name = "cmdScrapCode"
        Me.cmdScrapCode.Size = New System.Drawing.Size(105, 57)
        Me.cmdScrapCode.TabIndex = 2
        Me.cmdScrapCode.Text = "不良コード"
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(764, 579)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "取　消"
        '
        'cmdConfirm
        '
        Me.cmdConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdConfirm.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdConfirm.Location = New System.Drawing.Point(872, 579)
        Me.cmdConfirm.Name = "cmdConfirm"
        Me.cmdConfirm.Size = New System.Drawing.Size(105, 57)
        Me.cmdConfirm.TabIndex = 11
        Me.cmdConfirm.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 579)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.Text = "閉じる"
        '
        'cmdScrap
        '
        Me.cmdScrap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScrap.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScrap.Location = New System.Drawing.Point(656, 579)
        Me.cmdScrap.Name = "cmdScrap"
        Me.cmdScrap.Size = New System.Drawing.Size(105, 57)
        Me.cmdScrap.TabIndex = 12
        Me.cmdScrap.Text = "廃　棄"
        '
        'txtCarrier
        '
        Me.txtCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'txtEmpID
        '
        Me.txtEmpID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtEmpID.ChrMaxByte = 0
        Me.txtEmpID.Enabled = false
        Me.txtEmpID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtEmpID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEmpID.Location = New System.Drawing.Point(608, 32)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtEmpID.NumMax = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.txtEmpID.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmpID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmpID.SelectedText = ""
        Me.txtEmpID.Size = New System.Drawing.Size(143, 30)
        Me.txtEmpID.TabIndex = 1
        '
        'lblTitle15
        '
        Me.lblTitle15.BackColor = System.Drawing.Color.Navy
        Me.lblTitle15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle15.Location = New System.Drawing.Point(750, 16)
        Me.lblTitle15.Name = "lblTitle15"
        Me.lblTitle15.Size = New System.Drawing.Size(201, 17)
        Me.lblTitle15.TabIndex = 32
        Me.lblTitle15.Text = "責任者名"
        Me.lblTitle15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEmpName
        '
        Me.lblEmpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEmpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEmpName.Location = New System.Drawing.Point(750, 32)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(201, 30)
        Me.lblEmpName.TabIndex = 31
        '
        'lblTitle13
        '
        Me.lblTitle13.BackColor = System.Drawing.Color.Navy
        Me.lblTitle13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle13.Location = New System.Drawing.Point(608, 16)
        Me.lblTitle13.Name = "lblTitle13"
        Me.lblTitle13.Size = New System.Drawing.Size(143, 17)
        Me.lblTitle13.TabIndex = 30
        Me.lblTitle13.Text = "責任者ID"
        Me.lblTitle13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(16, 64)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 29
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 28
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(16, 80)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 27
        '
        'lblStepName
        '
        Me.lblStepName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepName.Location = New System.Drawing.Point(312, 80)
        Me.lblStepName.Name = "lblStepName"
        Me.lblStepName.Size = New System.Drawing.Size(281, 25)
        Me.lblStepName.TabIndex = 26
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(312, 64)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 25
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(216, 80)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblStatus.TabIndex = 24
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(216, 64)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl7.TabIndex = 23
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(216, 32)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
        Me.lblWFNo.TabIndex = 22
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl2.TabIndex = 21
        Me.lblTtl2.Text = "数量"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(312, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl3.TabIndex = 20
        Me.lblTtl3.Text = "大工程"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpName
        '
        Me.lblOpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpName.Location = New System.Drawing.Point(312, 32)
        Me.lblOpName.Name = "lblOpName"
        Me.lblOpName.Size = New System.Drawing.Size(281, 25)
        Me.lblOpName.TabIndex = 19
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(16, 16)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl0.TabIndex = 18
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 105)
        Me.lblBack.TabIndex = 17
        '
        'frmxxCM0070
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblTitle13)
        Me.Controls.Add(Me.fraWFInfo)
        Me.Controls.Add(Me.fraCodeList)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdConfirm)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdScrap)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.txtEmpID)
        Me.Controls.Add(Me.lblTitle15)
        Me.Controls.Add(Me.lblEmpName)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblStepName)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblOpName)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM0070"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "WF　不良／保留／払出／傾向登録"
        Me.fraWFInfo.ResumeLayout(false)
        CType(Me.vsfWFList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCodeList.ResumeLayout(false)
        CType(Me.vsfCodeList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraWFInfo As GroupBox
    Friend WithEvents vsfWFList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdDown2 As Button
    Friend WithEvents cmdUp2 As Button
    Friend WithEvents fraCodeList As GroupBox
    Friend WithEvents vsfCodeList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdUp1 As Button
    Friend WithEvents cmdDown1 As Button
    Friend WithEvents cmdHoldReason As Button
    Friend WithEvents cmdTakeReason As Button
    Friend WithEvents cmdScrapCode As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdConfirm As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdScrap As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents txtEmpID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle15 As Label
    Friend WithEvents lblEmpName As Label
    Friend WithEvents lblTitle13 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblStepName As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblOpName As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblBack As Label
End Class
