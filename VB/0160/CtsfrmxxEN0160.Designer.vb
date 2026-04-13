<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0160
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0160))
        Me.fraToLot = New System.Windows.Forms.GroupBox()
        Me.cmbDivideGrbSel = New SEComboBoxEx.ComboBoxEx()
        Me.lblGRBSel = New System.Windows.Forms.Label()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblDivideLotID = New System.Windows.Forms.Label()
        Me.lblDivideFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.fraFromLot = New System.Windows.Forms.GroupBox()
        Me.lblLotGRB = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.chkMoveSkip = New System.Windows.Forms.CheckBox()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.vsfSlotMapStck = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtToCarrier = New SETextBoxEx.TextBoxEx()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdLotSelect = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.cmdMoveGRB = New System.Windows.Forms.Button()
        Me.cmdDelGRB = New System.Windows.Forms.Button()
        Me.fraToLot.SuspendLayout
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraFromLot.SuspendLayout
        CType(Me.vsfSlotMapStck,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraToLot
        '
        Me.fraToLot.Controls.Add(Me.cmbDivideGrbSel)
        Me.fraToLot.Controls.Add(Me.lblGRBSel)
        Me.fraToLot.Controls.Add(Me.vsfSlotMap)
        Me.fraToLot.Controls.Add(Me.lblDivideLotID)
        Me.fraToLot.Controls.Add(Me.lblDivideFlowClass)
        Me.fraToLot.Controls.Add(Me.lblTtl5)
        Me.fraToLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraToLot.Location = New System.Drawing.Point(690, 8)
        Me.fraToLot.Name = "fraToLot"
        Me.fraToLot.Size = New System.Drawing.Size(289, 481)
        Me.fraToLot.TabIndex = 10
        Me.fraToLot.TabStop = false
        Me.fraToLot.Text = "分割先ロット"
        '
        'cmbDivideGrbSel
        '
        Me.cmbDivideGrbSel.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivideGrbSel.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivideGrbSel.Location = New System.Drawing.Point(199, 40)
        Me.cmbDivideGrbSel.Name = "cmbDivideGrbSel"
        Me.cmbDivideGrbSel.Size = New System.Drawing.Size(87, 28)
        Me.cmbDivideGrbSel.TabIndex = 37
        Me.cmbDivideGrbSel.Value = Nothing
        '
        'lblGRBSel
        '
        Me.lblGRBSel.BackColor = System.Drawing.Color.Navy
        Me.lblGRBSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRBSel.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRBSel.ForeColor = System.Drawing.Color.Yellow
        Me.lblGRBSel.Location = New System.Drawing.Point(199, 24)
        Me.lblGRBSel.Name = "lblGRBSel"
        Me.lblGRBSel.Size = New System.Drawing.Size(87, 18)
        Me.lblGRBSel.TabIndex = 36
        Me.lblGRBSel.Text = "GRB指定"
        Me.lblGRBSel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'vsfSlotMap
        '
        Me.vsfSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap.AllowEditing = false
        Me.vsfSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap.AutoSearchDelay = 2R
        Me.vsfSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap.ColumnInfo = "3,1,0,0,0,135,Columns:"
        Me.vsfSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap.ExtendLastCol = true
        Me.vsfSlotMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap.Location = New System.Drawing.Point(8, 70)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 25
        Me.vsfSlotMap.Rows.DefaultSize = 38
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfSlotMap.Size = New System.Drawing.Size(278, 402)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 10
        '
        'lblDivideLotID
        '
        Me.lblDivideLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDivideLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDivideLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDivideLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDivideLotID.Location = New System.Drawing.Point(8, 40)
        Me.lblDivideLotID.Name = "lblDivideLotID"
        Me.lblDivideLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblDivideLotID.TabIndex = 33
        '
        'lblDivideFlowClass
        '
        Me.lblDivideFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDivideFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDivideFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDivideFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDivideFlowClass.Location = New System.Drawing.Point(128, 40)
        Me.lblDivideFlowClass.Name = "lblDivideFlowClass"
        Me.lblDivideFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblDivideFlowClass.TabIndex = 32
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(8, 24)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl5.TabIndex = 31
        Me.lblTtl5.Text = "分割先ロットID"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraFromLot
        '
        Me.fraFromLot.Controls.Add(Me.lblLotGRB)
        Me.fraFromLot.Controls.Add(Me.lblTtl8)
        Me.fraFromLot.Controls.Add(Me.cmdCarrierSelect)
        Me.fraFromLot.Controls.Add(Me.chkMoveSkip)
        Me.fraFromLot.Controls.Add(Me.txtCarrier)
        Me.fraFromLot.Controls.Add(Me.vsfSlotMapStck)
        Me.fraFromLot.Controls.Add(Me.txtToCarrier)
        Me.fraFromLot.Controls.Add(Me.lblTtl6)
        Me.fraFromLot.Controls.Add(Me.lblTtl4)
        Me.fraFromLot.Controls.Add(Me.lblStatus)
        Me.fraFromLot.Controls.Add(Me.lblTtl3)
        Me.fraFromLot.Controls.Add(Me.lblStepID)
        Me.fraFromLot.Controls.Add(Me.lblOpID)
        Me.fraFromLot.Controls.Add(Me.lblTtl2)
        Me.fraFromLot.Controls.Add(Me.lblLotID)
        Me.fraFromLot.Controls.Add(Me.lblTtl0)
        Me.fraFromLot.Controls.Add(Me.lblFlowClass)
        Me.fraFromLot.Controls.Add(Me.lblTtl1)
        Me.fraFromLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraFromLot.Location = New System.Drawing.Point(10, 8)
        Me.fraFromLot.Name = "fraFromLot"
        Me.fraFromLot.Size = New System.Drawing.Size(555, 481)
        Me.fraFromLot.TabIndex = 0
        Me.fraFromLot.TabStop = false
        Me.fraFromLot.Text = "分割元ロット"
        '
        'lblLotGRB
        '
        Me.lblLotGRB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotGRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotGRB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotGRB.Location = New System.Drawing.Point(192, 96)
        Me.lblLotGRB.Name = "lblLotGRB"
        Me.lblLotGRB.Size = New System.Drawing.Size(65, 25)
        Me.lblLotGRB.TabIndex = 36
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(192, 79)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(65, 18)
        Me.lblTtl8.TabIndex = 35
        Me.lblTtl8.Text = "GRB"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.CausesValidation = false
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(8, 416)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdCarrierSelect.TabIndex = 3
        Me.cmdCarrierSelect.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'chkMoveSkip
        '
        Me.chkMoveSkip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkMoveSkip.Location = New System.Drawing.Point(8, 342)
        Me.chkMoveSkip.Name = "chkMoveSkip"
        Me.chkMoveSkip.Size = New System.Drawing.Size(163, 25)
        Me.chkMoveSkip.TabIndex = 1
        Me.chkMoveSkip.Text = "移載工程スキップ"
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(8, 40)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'vsfSlotMapStck
        '
        Me.vsfSlotMapStck.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMapStck.AllowEditing = false
        Me.vsfSlotMapStck.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMapStck.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMapStck.AutoSearchDelay = 2R
        Me.vsfSlotMapStck.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMapStck.ColumnInfo = "3,1,0,0,0,135,Columns:0{Width:29;}"&Global.Microsoft.VisualBasic.ChrW(9)&"1{Width:141;}"&Global.Microsoft.VisualBasic.ChrW(9)&"2{Width:70;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfSlotMapStck.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMapStck.ExtendLastCol = true
        Me.vsfSlotMapStck.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMapStck.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMapStck.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.vsfSlotMapStck.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMapStck.Location = New System.Drawing.Point(271, 70)
        Me.vsfSlotMapStck.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMapStck.Name = "vsfSlotMapStck"
        Me.vsfSlotMapStck.Rows.Count = 25
        Me.vsfSlotMapStck.Rows.DefaultSize = 38
        Me.vsfSlotMapStck.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMapStck.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMapStck.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfSlotMapStck.Size = New System.Drawing.Size(277, 402)
        Me.vsfSlotMapStck.StyleInfo = resources.GetString("vsfSlotMapStck.StyleInfo")
        Me.vsfSlotMapStck.TabIndex = 5
        '
        'txtToCarrier
        '
        Me.txtToCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtToCarrier.ChrMaxByte = 6
        Me.txtToCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtToCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtToCarrier.Location = New System.Drawing.Point(8, 382)
        Me.txtToCarrier.Name = "txtToCarrier"
        Me.txtToCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtToCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtToCarrier.SelectedText = ""
        Me.txtToCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtToCarrier.TabIndex = 2
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(8, 366)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(185, 18)
        Me.lblTtl6.TabIndex = 34
        Me.lblTtl6.Text = "UnloaderキャリアID"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(8, 229)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(185, 18)
        Me.lblTtl4.TabIndex = 29
        Me.lblTtl4.Text = "状態"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(8, 246)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(185, 25)
        Me.lblStatus.TabIndex = 28
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(8, 179)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(249, 18)
        Me.lblTtl3.TabIndex = 27
        Me.lblTtl3.Text = "小工程"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(8, 196)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(249, 25)
        Me.lblStepID.TabIndex = 26
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(8, 146)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(249, 25)
        Me.lblOpID.TabIndex = 25
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(8, 129)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(249, 18)
        Me.lblTtl2.TabIndex = 24
        Me.lblTtl2.Text = "大工程"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(8, 96)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 23
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 24)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl0.TabIndex = 22
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(128, 96)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 21
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(8, 79)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 18)
        Me.lblTtl1.TabIndex = 20
        Me.lblTtl1.Text = "分割元ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(752, 490)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 44)
        Me.cmdMemoUp.TabIndex = 14
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(752, 535)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 15
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(766, 582)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "取　消"
        '
        'cmdLotSelect
        '
        Me.cmdLotSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotSelect.Location = New System.Drawing.Point(578, 8)
        Me.cmdLotSelect.Name = "cmdLotSelect"
        Me.cmdLotSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotSelect.TabIndex = 4
        Me.cmdLotSelect.Text = "投入予定"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ロット選択"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp.Location = New System.Drawing.Point(578, 78)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(105, 57)
        Me.cmdUp.TabIndex = 6
        Me.cmdUp.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(578, 420)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(105, 57)
        Me.cmdDown.TabIndex = 7
        Me.cmdDown.Text = "▼"
        '
        'cmdMove
        '
        Me.cmdMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 24!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMove.Location = New System.Drawing.Point(578, 198)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.Size = New System.Drawing.Size(105, 57)
        Me.cmdMove.TabIndex = 8
        Me.cmdMove.Text = ">"
        '
        'cmdDel
        '
        Me.cmdDel.Enabled = false
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ ゴシック", 24!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDel.Location = New System.Drawing.Point(578, 296)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(105, 57)
        Me.cmdDel.TabIndex = 9
        Me.cmdDel.Text = "<"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(9, 582)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 16
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(874, 582)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 11
        Me.cmdRegist.Text = "確　定"
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(10, 508)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
        Me.txtWorkMemo.TabIndex = 13
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(496, 492)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 17
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(10, 491)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(791, 18)
        Me.lblTtl15.TabIndex = 18
        Me.lblTtl15.Text = "作業メモ"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdMoveGRB
        '
        Me.cmdMoveGRB.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMoveGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 24!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMoveGRB.Location = New System.Drawing.Point(578, 137)
        Me.cmdMoveGRB.Name = "cmdMoveGRB"
        Me.cmdMoveGRB.Size = New System.Drawing.Size(105, 57)
        Me.cmdMoveGRB.TabIndex = 19
        Me.cmdMoveGRB.Text = ">>"
        '
        'cmdDelGRB
        '
        Me.cmdDelGRB.Enabled = false
        Me.cmdDelGRB.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDelGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 24!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDelGRB.Location = New System.Drawing.Point(577, 357)
        Me.cmdDelGRB.Name = "cmdDelGRB"
        Me.cmdDelGRB.Size = New System.Drawing.Size(105, 57)
        Me.cmdDelGRB.TabIndex = 20
        Me.cmdDelGRB.Text = "<<"
        '
        'frmxxEN0160
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdDelGRB)
        Me.Controls.Add(Me.cmdMoveGRB)
        Me.Controls.Add(Me.fraToLot)
        Me.Controls.Add(Me.fraFromLot)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdLotSelect)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdMove)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblTtl15)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0160"
        Me.Text = "ロット分割"
        Me.fraToLot.ResumeLayout(false)
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraFromLot.ResumeLayout(false)
        CType(Me.vsfSlotMapStck,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraToLot As GroupBox
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblDivideLotID As Label
    Friend WithEvents lblDivideFlowClass As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents fraFromLot As GroupBox
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents chkMoveSkip As CheckBox
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfSlotMapStck As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtToCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdLotSelect As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdMove As Button
    Friend WithEvents cmdDel As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblLotGRB As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents cmdMoveGRB As Button
    Friend WithEvents cmdDelGRB As Button
    Friend WithEvents lblGRBSel As Label
    Friend WithEvents cmbDivideGrbSel As SEComboBoxEx.ComboBoxEx
End Class
