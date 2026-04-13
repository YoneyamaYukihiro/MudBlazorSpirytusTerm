<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01A0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01A0))
        Me.cmdCFCarrierSelect = New System.Windows.Forms.Button()
        Me.cmdTreatChip = New System.Windows.Forms.Button()
        Me.frCoverInfo = New System.Windows.Forms.GroupBox()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.vsfUseTpalList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTtl24 = New System.Windows.Forms.Label()
        Me.lblTotalRestNum = New System.Windows.Forms.Label()
        Me.lblScroll2 = New System.Windows.Forms.Label()
        Me.lblCoverRestQuantity = New System.Windows.Forms.Label()
        Me.lblTtl20 = New System.Windows.Forms.Label()
        Me.lblTotalUseNum = New System.Windows.Forms.Label()
        Me.lblTtl21 = New System.Windows.Forms.Label()
        Me.lblTotalCoverNum = New System.Windows.Forms.Label()
        Me.lblTtl22 = New System.Windows.Forms.Label()
        Me.lblTotalOutNum = New System.Windows.Forms.Label()
        Me.lblTtl23 = New System.Windows.Forms.Label()
        Me.frInvTPALInfo = New System.Windows.Forms.GroupBox()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.txtTPALCarrier = New SETextBoxEx.TextBoxEx()
        Me.txtChipOutQuantity = New SETextBoxEx.TextBoxEx()
        Me.txtChipRestQuantity = New SETextBoxEx.TextBoxEx()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTtl17 = New System.Windows.Forms.Label()
        Me.lblTtl18 = New System.Windows.Forms.Label()
        Me.lblInvTPALLotCnt = New System.Windows.Forms.Label()
        Me.lblInvTPALChipCnt = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblTPALLotID = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.lblTPALChipQuantity = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTtl16 = New System.Windows.Forms.Label()
        Me.lblTtl14 = New System.Windows.Forms.Label()
        Me.lblLimitTime = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdMoveCancel = New System.Windows.Forms.Button()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.lblCoverCnt = New System.Windows.Forms.Label()
        Me.lblTtl19 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblStartDayTime = New System.Windows.Forms.Label()
        Me.lblS = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblTimeLimit = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblChipNum = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.frCoverInfo.SuspendLayout
        CType(Me.vsfUseTpalList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.frInvTPALInfo.SuspendLayout
        Me.SuspendLayout
        '
        'cmdCFCarrierSelect
        '
        Me.cmdCFCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCFCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCFCarrierSelect.Location = New System.Drawing.Point(548, 579)
        Me.cmdCFCarrierSelect.Name = "cmdCFCarrierSelect"
        Me.cmdCFCarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdCFCarrierSelect.TabIndex = 66
        Me.cmdCFCarrierSelect.Text = "CFｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdTreatChip
        '
        Me.cmdTreatChip.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTreatChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTreatChip.Location = New System.Drawing.Point(656, 579)
        Me.cmdTreatChip.Name = "cmdTreatChip"
        Me.cmdTreatChip.Size = New System.Drawing.Size(105, 57)
        Me.cmdTreatChip.TabIndex = 12
        Me.cmdTreatChip.Text = "チップ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"状態変更"
        '
        'frCoverInfo
        '
        Me.frCoverInfo.Controls.Add(Me.cmdDown)
        Me.frCoverInfo.Controls.Add(Me.cmdUP)
        Me.frCoverInfo.Controls.Add(Me.vsfUseTpalList)
        Me.frCoverInfo.Controls.Add(Me.lblTtl24)
        Me.frCoverInfo.Controls.Add(Me.lblTotalRestNum)
        Me.frCoverInfo.Controls.Add(Me.lblScroll2)
        Me.frCoverInfo.Controls.Add(Me.lblCoverRestQuantity)
        Me.frCoverInfo.Controls.Add(Me.lblTtl20)
        Me.frCoverInfo.Controls.Add(Me.lblTotalUseNum)
        Me.frCoverInfo.Controls.Add(Me.lblTtl21)
        Me.frCoverInfo.Controls.Add(Me.lblTotalCoverNum)
        Me.frCoverInfo.Controls.Add(Me.lblTtl22)
        Me.frCoverInfo.Controls.Add(Me.lblTotalOutNum)
        Me.frCoverInfo.Controls.Add(Me.lblTtl23)
        Me.frCoverInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.frCoverInfo.Location = New System.Drawing.Point(357, 117)
        Me.frCoverInfo.Name = "frCoverInfo"
        Me.frCoverInfo.Size = New System.Drawing.Size(617, 448)
        Me.frCoverInfo.TabIndex = 7
        Me.frCoverInfo.TabStop = false
        Me.frCoverInfo.Text = "登録済カセット"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(556, 193)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 168)
        Me.cmdDown.TabIndex = 9
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(556, 26)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 168)
        Me.cmdUP.TabIndex = 8
        Me.cmdUP.Text = "▲"
        '
        'vsfUseTpalList
        '
        Me.vsfUseTpalList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfUseTpalList.AllowEditing = false
        Me.vsfUseTpalList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfUseTpalList.AutoSearchDelay = 2R
        Me.vsfUseTpalList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfUseTpalList.ColumnInfo = resources.GetString("vsfUseTpalList.ColumnInfo")
        Me.vsfUseTpalList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfUseTpalList.ExtendLastCol = true
        Me.vsfUseTpalList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfUseTpalList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfUseTpalList.Location = New System.Drawing.Point(10, 27)
        Me.vsfUseTpalList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfUseTpalList.Name = "vsfUseTpalList"
        Me.vsfUseTpalList.Rows.Count = 10
        Me.vsfUseTpalList.Rows.DefaultSize = 18
        Me.vsfUseTpalList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfUseTpalList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfUseTpalList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfUseTpalList.Size = New System.Drawing.Size(546, 333)
        Me.vsfUseTpalList.StyleInfo = resources.GetString("vsfUseTpalList.StyleInfo")
        Me.vsfUseTpalList.TabIndex = 7
        '
        'lblTtl24
        '
        Me.lblTtl24.BackColor = System.Drawing.Color.Navy
        Me.lblTtl24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl24.Enabled = false
        Me.lblTtl24.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl24.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl24.Location = New System.Drawing.Point(471, 381)
        Me.lblTtl24.Name = "lblTtl24"
        Me.lblTtl24.Size = New System.Drawing.Size(85, 17)
        Me.lblTtl24.TabIndex = 64
        Me.lblTtl24.Text = "残計"
        Me.lblTtl24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTtl24.Visible = false
        '
        'lblTotalRestNum
        '
        Me.lblTotalRestNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalRestNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalRestNum.Enabled = false
        Me.lblTotalRestNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTotalRestNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalRestNum.Location = New System.Drawing.Point(471, 397)
        Me.lblTotalRestNum.Name = "lblTotalRestNum"
        Me.lblTotalRestNum.Size = New System.Drawing.Size(85, 30)
        Me.lblTotalRestNum.TabIndex = 37
        Me.lblTotalRestNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblTotalRestNum.Visible = false
        '
        'lblScroll2
        '
        Me.lblScroll2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScroll2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblScroll2.Location = New System.Drawing.Point(556, 27)
        Me.lblScroll2.Name = "lblScroll2"
        Me.lblScroll2.Size = New System.Drawing.Size(49, 333)
        Me.lblScroll2.TabIndex = 39
        '
        'lblCoverRestQuantity
        '
        Me.lblCoverRestQuantity.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCoverRestQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCoverRestQuantity.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCoverRestQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCoverRestQuantity.Location = New System.Drawing.Point(10, 397)
        Me.lblCoverRestQuantity.Name = "lblCoverRestQuantity"
        Me.lblCoverRestQuantity.Size = New System.Drawing.Size(85, 30)
        Me.lblCoverRestQuantity.TabIndex = 33
        Me.lblCoverRestQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl20
        '
        Me.lblTtl20.BackColor = System.Drawing.Color.Navy
        Me.lblTtl20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl20.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl20.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl20.Location = New System.Drawing.Point(10, 381)
        Me.lblTtl20.Name = "lblTtl20"
        Me.lblTtl20.Size = New System.Drawing.Size(85, 17)
        Me.lblTtl20.TabIndex = 60
        Me.lblTtl20.Text = "貼残数"
        Me.lblTtl20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotalUseNum
        '
        Me.lblTotalUseNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalUseNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalUseNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTotalUseNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalUseNum.Location = New System.Drawing.Point(170, 397)
        Me.lblTotalUseNum.Name = "lblTotalUseNum"
        Me.lblTotalUseNum.Size = New System.Drawing.Size(85, 30)
        Me.lblTotalUseNum.TabIndex = 34
        Me.lblTotalUseNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl21
        '
        Me.lblTtl21.BackColor = System.Drawing.Color.Navy
        Me.lblTtl21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl21.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl21.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl21.Location = New System.Drawing.Point(170, 381)
        Me.lblTtl21.Name = "lblTtl21"
        Me.lblTtl21.Size = New System.Drawing.Size(85, 17)
        Me.lblTtl21.TabIndex = 61
        Me.lblTtl21.Text = "使用計"
        Me.lblTtl21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotalCoverNum
        '
        Me.lblTotalCoverNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalCoverNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCoverNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTotalCoverNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalCoverNum.Location = New System.Drawing.Point(303, 397)
        Me.lblTotalCoverNum.Name = "lblTotalCoverNum"
        Me.lblTotalCoverNum.Size = New System.Drawing.Size(85, 30)
        Me.lblTotalCoverNum.TabIndex = 35
        Me.lblTotalCoverNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl22
        '
        Me.lblTtl22.BackColor = System.Drawing.Color.Navy
        Me.lblTtl22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl22.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl22.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl22.Location = New System.Drawing.Point(303, 381)
        Me.lblTtl22.Name = "lblTtl22"
        Me.lblTtl22.Size = New System.Drawing.Size(85, 17)
        Me.lblTtl22.TabIndex = 62
        Me.lblTtl22.Text = "貼計"
        Me.lblTtl22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotalOutNum
        '
        Me.lblTotalOutNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTotalOutNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalOutNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTotalOutNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalOutNum.Location = New System.Drawing.Point(387, 397)
        Me.lblTotalOutNum.Name = "lblTotalOutNum"
        Me.lblTotalOutNum.Size = New System.Drawing.Size(85, 30)
        Me.lblTotalOutNum.TabIndex = 36
        Me.lblTotalOutNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl23
        '
        Me.lblTtl23.BackColor = System.Drawing.Color.Navy
        Me.lblTtl23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl23.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl23.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl23.Location = New System.Drawing.Point(387, 381)
        Me.lblTtl23.Name = "lblTtl23"
        Me.lblTtl23.Size = New System.Drawing.Size(85, 17)
        Me.lblTtl23.TabIndex = 63
        Me.lblTtl23.Text = "不良計"
        Me.lblTtl23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frInvTPALInfo
        '
        Me.frInvTPALInfo.Controls.Add(Me.cmdNowList)
        Me.frInvTPALInfo.Controls.Add(Me.txtTPALCarrier)
        Me.frInvTPALInfo.Controls.Add(Me.txtChipOutQuantity)
        Me.frInvTPALInfo.Controls.Add(Me.txtChipRestQuantity)
        Me.frInvTPALInfo.Controls.Add(Me.lblNowDate)
        Me.frInvTPALInfo.Controls.Add(Me.lblTtl17)
        Me.frInvTPALInfo.Controls.Add(Me.lblTtl18)
        Me.frInvTPALInfo.Controls.Add(Me.lblInvTPALLotCnt)
        Me.frInvTPALInfo.Controls.Add(Me.lblInvTPALChipCnt)
        Me.frInvTPALInfo.Controls.Add(Me.lblTtl11)
        Me.frInvTPALInfo.Controls.Add(Me.lblTPALLotID)
        Me.frInvTPALInfo.Controls.Add(Me.lblTtl12)
        Me.frInvTPALInfo.Controls.Add(Me.lblTtl13)
        Me.frInvTPALInfo.Controls.Add(Me.lblTPALChipQuantity)
        Me.frInvTPALInfo.Controls.Add(Me.lblTtl15)
        Me.frInvTPALInfo.Controls.Add(Me.lblTtl16)
        Me.frInvTPALInfo.Controls.Add(Me.lblTtl14)
        Me.frInvTPALInfo.Controls.Add(Me.lblLimitTime)
        Me.frInvTPALInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.frInvTPALInfo.Location = New System.Drawing.Point(8, 117)
        Me.frInvTPALInfo.Name = "frInvTPALInfo"
        Me.frInvTPALInfo.Size = New System.Drawing.Size(220, 447)
        Me.frInvTPALInfo.TabIndex = 1
        Me.frInvTPALInfo.TabStop = false
        Me.frInvTPALInfo.Text = "仕掛前カセット"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(10, 257)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowList.TabIndex = 1
        Me.cmdNowList.Text = "最新取得"
        '
        'txtTPALCarrier
        '
        Me.txtTPALCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtTPALCarrier.ChrMaxByte = 6
        Me.txtTPALCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtTPALCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtTPALCarrier.Location = New System.Drawing.Point(10, 43)
        Me.txtTPALCarrier.Name = "txtTPALCarrier"
        Me.txtTPALCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtTPALCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTPALCarrier.SelectedText = ""
        Me.txtTPALCarrier.Size = New System.Drawing.Size(199, 30)
        Me.txtTPALCarrier.TabIndex = 2
        '
        'txtChipOutQuantity
        '
        Me.txtChipOutQuantity.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtChipOutQuantity.ChrMaxByte = 6
        Me.txtChipOutQuantity.ForeColor = System.Drawing.Color.Black
        Me.txtChipOutQuantity.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtChipOutQuantity.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtChipOutQuantity.Location = New System.Drawing.Point(10, 208)
        Me.txtChipOutQuantity.Name = "txtChipOutQuantity"
        Me.txtChipOutQuantity.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtChipOutQuantity.NumFormat = "#,##0"
        Me.txtChipOutQuantity.NumMax = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.txtChipOutQuantity.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtChipOutQuantity.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChipOutQuantity.SelectedText = ""
        Me.txtChipOutQuantity.Size = New System.Drawing.Size(94, 30)
        Me.txtChipOutQuantity.TabIndex = 3
        Me.txtChipOutQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtChipRestQuantity
        '
        Me.txtChipRestQuantity.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtChipRestQuantity.ChrMaxByte = 6
        Me.txtChipRestQuantity.ForeColor = System.Drawing.Color.Black
        Me.txtChipRestQuantity.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtChipRestQuantity.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtChipRestQuantity.Location = New System.Drawing.Point(115, 208)
        Me.txtChipRestQuantity.Name = "txtChipRestQuantity"
        Me.txtChipRestQuantity.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtChipRestQuantity.NumFormat = "#,##0"
        Me.txtChipRestQuantity.NumMax = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.txtChipRestQuantity.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtChipRestQuantity.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtChipRestQuantity.SelectedText = ""
        Me.txtChipRestQuantity.Size = New System.Drawing.Size(94, 30)
        Me.txtChipRestQuantity.TabIndex = 4
        Me.txtChipRestQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(10, 343)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(199, 30)
        Me.lblNowDate.TabIndex = 28
        '
        'lblTtl17
        '
        Me.lblTtl17.BackColor = System.Drawing.Color.Navy
        Me.lblTtl17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl17.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl17.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl17.Location = New System.Drawing.Point(10, 327)
        Me.lblTtl17.Name = "lblTtl17"
        Me.lblTtl17.Size = New System.Drawing.Size(199, 17)
        Me.lblTtl17.TabIndex = 57
        Me.lblTtl17.Text = "情報取得日時"
        Me.lblTtl17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl18
        '
        Me.lblTtl18.BackColor = System.Drawing.Color.Navy
        Me.lblTtl18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl18.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl18.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl18.Location = New System.Drawing.Point(10, 381)
        Me.lblTtl18.Name = "lblTtl18"
        Me.lblTtl18.Size = New System.Drawing.Size(199, 17)
        Me.lblTtl18.TabIndex = 58
        Me.lblTtl18.Text = "TPAL前在庫数"
        Me.lblTtl18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblInvTPALLotCnt
        '
        Me.lblInvTPALLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblInvTPALLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvTPALLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInvTPALLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInvTPALLotCnt.Location = New System.Drawing.Point(10, 397)
        Me.lblInvTPALLotCnt.Name = "lblInvTPALLotCnt"
        Me.lblInvTPALLotCnt.Size = New System.Drawing.Size(126, 30)
        Me.lblInvTPALLotCnt.TabIndex = 29
        Me.lblInvTPALLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblInvTPALChipCnt
        '
        Me.lblInvTPALChipCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblInvTPALChipCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvTPALChipCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInvTPALChipCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInvTPALChipCnt.Location = New System.Drawing.Point(135, 397)
        Me.lblInvTPALChipCnt.Name = "lblInvTPALChipCnt"
        Me.lblInvTPALChipCnt.Size = New System.Drawing.Size(74, 30)
        Me.lblInvTPALChipCnt.TabIndex = 30
        Me.lblInvTPALChipCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(10, 27)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(199, 17)
        Me.lblTtl11.TabIndex = 51
        Me.lblTtl11.Text = "キャリアID"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTPALLotID
        '
        Me.lblTPALLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTPALLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTPALLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTPALLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTPALLotID.Location = New System.Drawing.Point(10, 98)
        Me.lblTPALLotID.Name = "lblTPALLotID"
        Me.lblTPALLotID.Size = New System.Drawing.Size(126, 30)
        Me.lblTPALLotID.TabIndex = 25
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(10, 82)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(126, 17)
        Me.lblTtl12.TabIndex = 52
        Me.lblTtl12.Text = "TPALロットID"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.Color.Navy
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl13.Location = New System.Drawing.Point(135, 82)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(74, 17)
        Me.lblTtl13.TabIndex = 53
        Me.lblTtl13.Text = "数量"
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTPALChipQuantity
        '
        Me.lblTPALChipQuantity.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTPALChipQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTPALChipQuantity.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTPALChipQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTPALChipQuantity.Location = New System.Drawing.Point(135, 98)
        Me.lblTPALChipQuantity.Name = "lblTPALChipQuantity"
        Me.lblTPALChipQuantity.Size = New System.Drawing.Size(74, 30)
        Me.lblTPALChipQuantity.TabIndex = 26
        Me.lblTPALChipQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(10, 192)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(94, 17)
        Me.lblTtl15.TabIndex = 55
        Me.lblTtl15.Text = "不良数"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl16
        '
        Me.lblTtl16.BackColor = System.Drawing.Color.Navy
        Me.lblTtl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl16.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl16.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl16.Location = New System.Drawing.Point(115, 192)
        Me.lblTtl16.Name = "lblTtl16"
        Me.lblTtl16.Size = New System.Drawing.Size(94, 17)
        Me.lblTtl16.TabIndex = 56
        Me.lblTtl16.Text = "残数"
        Me.lblTtl16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl14
        '
        Me.lblTtl14.BackColor = System.Drawing.Color.Navy
        Me.lblTtl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl14.Location = New System.Drawing.Point(10, 137)
        Me.lblTtl14.Name = "lblTtl14"
        Me.lblTtl14.Size = New System.Drawing.Size(199, 17)
        Me.lblTtl14.TabIndex = 54
        Me.lblTtl14.Text = "有効期限"
        Me.lblTtl14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLimitTime
        '
        Me.lblLimitTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLimitTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLimitTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLimitTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLimitTime.Location = New System.Drawing.Point(10, 153)
        Me.lblLimitTime.Name = "lblLimitTime"
        Me.lblLimitTime.Size = New System.Drawing.Size(199, 30)
        Me.lblLimitTime.TabIndex = 27
        '
        'cmdClear
        '
        Me.cmdClear.CausesValidation = false
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(764, 579)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "取　消"
        '
        'cmdMoveCancel
        '
        Me.cmdMoveCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMoveCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 24!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMoveCancel.Location = New System.Drawing.Point(241, 341)
        Me.cmdMoveCancel.Name = "cmdMoveCancel"
        Me.cmdMoveCancel.Size = New System.Drawing.Size(105, 57)
        Me.cmdMoveCancel.TabIndex = 6
        Me.cmdMoveCancel.Text = "<"
        '
        'cmdMove
        '
        Me.cmdMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 24!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMove.Location = New System.Drawing.Point(241, 258)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.Size = New System.Drawing.Size(105, 57)
        Me.cmdMove.TabIndex = 5
        Me.cmdMove.Text = ">"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 579)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 10
        Me.cmdRegist.Text = "確　定"
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
        Me.cmdClose.TabIndex = 65
        Me.cmdClose.Text = "閉じる"
        '
        'txtCarrier
        '
        Me.txtCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'lblCoverCnt
        '
        Me.lblCoverCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCoverCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCoverCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCoverCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCoverCnt.Location = New System.Drawing.Point(241, 514)
        Me.lblCoverCnt.Name = "lblCoverCnt"
        Me.lblCoverCnt.Size = New System.Drawing.Size(105, 30)
        Me.lblCoverCnt.TabIndex = 32
        Me.lblCoverCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl19
        '
        Me.lblTtl19.BackColor = System.Drawing.Color.Navy
        Me.lblTtl19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl19.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl19.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl19.Location = New System.Drawing.Point(241, 498)
        Me.lblTtl19.Name = "lblTtl19"
        Me.lblTtl19.Size = New System.Drawing.Size(105, 17)
        Me.lblTtl19.TabIndex = 59
        Me.lblTtl19.Text = "貼り合わせ"
        Me.lblTtl19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(16, 80)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 30)
        Me.lblLotID.TabIndex = 18
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
        Me.lblTtl0.TabIndex = 40
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 30)
        Me.lblFlowClass.TabIndex = 19
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
        Me.lblTtl1.TabIndex = 46
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl7.TabIndex = 47
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(216, 80)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 30)
        Me.lblStatus.TabIndex = 20
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(408, 64)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 49
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(408, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 30)
        Me.lblStepID.TabIndex = 22
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(408, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 30)
        Me.lblOpID.TabIndex = 15
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(408, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl3.TabIndex = 43
        Me.lblTtl3.Text = "大工程"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(868, 16)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl6.TabIndex = 45
        Me.lblTtl6.Text = "特殊特性"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(688, 16)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl4.TabIndex = 44
        Me.lblTtl4.Text = "処理開始日時"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStartDayTime
        '
        Me.lblStartDayTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStartDayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDayTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDayTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStartDayTime.Location = New System.Drawing.Point(688, 32)
        Me.lblStartDayTime.Name = "lblStartDayTime"
        Me.lblStartDayTime.Size = New System.Drawing.Size(181, 30)
        Me.lblStartDayTime.TabIndex = 16
        '
        'lblS
        '
        Me.lblS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblS.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblS.Location = New System.Drawing.Point(868, 32)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(97, 30)
        Me.lblS.TabIndex = 17
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(312, 16)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl5.TabIndex = 42
        Me.lblTtl5.Text = "数量"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl2.TabIndex = 41
        Me.lblTtl2.Text = "機種"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdID
        '
        Me.lblPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(216, 32)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(97, 30)
        Me.lblPdID.TabIndex = 13
        '
        'lblLotManager
        '
        Me.lblLotManager.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(688, 80)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(181, 30)
        Me.lblLotManager.TabIndex = 23
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(688, 64)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl9.TabIndex = 50
        Me.lblTtl9.Text = "ロット担当"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTimeLimit
        '
        Me.lblTimeLimit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTimeLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTimeLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTimeLimit.Location = New System.Drawing.Point(312, 80)
        Me.lblTimeLimit.Name = "lblTimeLimit"
        Me.lblTimeLimit.Size = New System.Drawing.Size(97, 30)
        Me.lblTimeLimit.TabIndex = 21
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(312, 64)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl10.TabIndex = 48
        Me.lblTtl10.Text = "時間制限"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipNum
        '
        Me.lblChipNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblChipNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipNum.Location = New System.Drawing.Point(312, 32)
        Me.lblChipNum.Name = "lblChipNum"
        Me.lblChipNum.Size = New System.Drawing.Size(97, 30)
        Me.lblChipNum.TabIndex = 14
        Me.lblChipNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 105)
        Me.lblBack.TabIndex = 24
        '
        'frmxxEN01A0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdCFCarrierSelect)
        Me.Controls.Add(Me.cmdTreatChip)
        Me.Controls.Add(Me.frCoverInfo)
        Me.Controls.Add(Me.frInvTPALInfo)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdMoveCancel)
        Me.Controls.Add(Me.cmdMove)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.lblCoverCnt)
        Me.Controls.Add(Me.lblTtl19)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblStartDayTime)
        Me.Controls.Add(Me.lblS)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblTimeLimit)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblChipNum)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01A0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TPAL貼り合せ登録"
        Me.frCoverInfo.ResumeLayout(false)
        CType(Me.vsfUseTpalList,System.ComponentModel.ISupportInitialize).EndInit
        Me.frInvTPALInfo.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCFCarrierSelect As Button
    Friend WithEvents cmdTreatChip As Button
    Friend WithEvents frCoverInfo As GroupBox
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents vsfUseTpalList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTtl24 As Label
    Friend WithEvents lblTotalRestNum As Label
    Friend WithEvents lblScroll2 As Label
    Friend WithEvents lblCoverRestQuantity As Label
    Friend WithEvents lblTtl20 As Label
    Friend WithEvents lblTotalUseNum As Label
    Friend WithEvents lblTtl21 As Label
    Friend WithEvents lblTotalCoverNum As Label
    Friend WithEvents lblTtl22 As Label
    Friend WithEvents lblTotalOutNum As Label
    Friend WithEvents lblTtl23 As Label
    Friend WithEvents frInvTPALInfo As GroupBox
    Friend WithEvents cmdNowList As Button
    Friend WithEvents txtTPALCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents txtChipOutQuantity As SETextBoxEx.TextBoxEx
    Friend WithEvents txtChipRestQuantity As SETextBoxEx.TextBoxEx
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTtl17 As Label
    Friend WithEvents lblTtl18 As Label
    Friend WithEvents lblInvTPALLotCnt As Label
    Friend WithEvents lblInvTPALChipCnt As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblTPALLotID As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblTPALChipQuantity As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTtl16 As Label
    Friend WithEvents lblTtl14 As Label
    Friend WithEvents lblLimitTime As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdMoveCancel As Button
    Friend WithEvents cmdMove As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblCoverCnt As Label
    Friend WithEvents lblTtl19 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblStartDayTime As Label
    Friend WithEvents lblS As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTimeLimit As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblChipNum As Label
    Friend WithEvents lblBack As Label
End Class
