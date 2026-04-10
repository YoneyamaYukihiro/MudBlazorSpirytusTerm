<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00B0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00B0))
        Me.cmdScrapDown = New System.Windows.Forms.Button()
        Me.cmdReworkDown = New System.Windows.Forms.Button()
        Me.cmdSlotDown = New System.Windows.Forms.Button()
        Me.cmdSlotUp = New System.Windows.Forms.Button()
        Me.cmdScrapUp = New System.Windows.Forms.Button()
        Me.cmdReworkUP = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.vsfPaletteSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfRework = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfScrap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.txtScrap = New SETextBoxEx.TextBoxEx()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblScrapNum = New System.Windows.Forms.Label()
        Me.lblTtl17 = New System.Windows.Forms.Label()
        Me.lblReworkNum = New System.Windows.Forms.Label()
        Me.lblTtl16 = New System.Windows.Forms.Label()
        Me.lblChipNormalNum = New System.Windows.Forms.Label()
        Me.lblTtl14 = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblStartDayTime = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblReworkCount = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTimeLimit = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblS = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        CType(Me.vsfPaletteSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfRework,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfScrap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdScrapDown
        '
        Me.cmdScrapDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScrapDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScrapDown.Location = New System.Drawing.Point(926, 342)
        Me.cmdScrapDown.Name = "cmdScrapDown"
        Me.cmdScrapDown.Size = New System.Drawing.Size(49, 206)
        Me.cmdScrapDown.TabIndex = 13
        Me.cmdScrapDown.Text = "▼"
        '
        'cmdReworkDown
        '
        Me.cmdReworkDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReworkDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdReworkDown.Location = New System.Drawing.Point(413, 371)
        Me.cmdReworkDown.Name = "cmdReworkDown"
        Me.cmdReworkDown.Size = New System.Drawing.Size(49, 177)
        Me.cmdReworkDown.TabIndex = 11
        Me.cmdReworkDown.Text = "▼"
        '
        'cmdSlotDown
        '
        Me.cmdSlotDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSlotDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSlotDown.Location = New System.Drawing.Point(256, 342)
        Me.cmdSlotDown.Name = "cmdSlotDown"
        Me.cmdSlotDown.Size = New System.Drawing.Size(49, 206)
        Me.cmdSlotDown.TabIndex = 9
        Me.cmdSlotDown.Text = "▼"
        '
        'cmdSlotUp
        '
        Me.cmdSlotUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSlotUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSlotUp.Location = New System.Drawing.Point(256, 136)
        Me.cmdSlotUp.Name = "cmdSlotUp"
        Me.cmdSlotUp.Size = New System.Drawing.Size(49, 207)
        Me.cmdSlotUp.TabIndex = 8
        Me.cmdSlotUp.Text = "▲"
        '
        'cmdScrapUp
        '
        Me.cmdScrapUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScrapUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScrapUp.Location = New System.Drawing.Point(926, 136)
        Me.cmdScrapUp.Name = "cmdScrapUp"
        Me.cmdScrapUp.Size = New System.Drawing.Size(49, 207)
        Me.cmdScrapUp.TabIndex = 12
        Me.cmdScrapUp.Text = "▲"
        '
        'cmdReworkUP
        '
        Me.cmdReworkUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReworkUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdReworkUP.Location = New System.Drawing.Point(413, 194)
        Me.cmdReworkUP.Name = "cmdReworkUP"
        Me.cmdReworkUP.Size = New System.Drawing.Size(49, 178)
        Me.cmdReworkUP.TabIndex = 10
        Me.cmdReworkUP.Text = "▲"
        '
        'cmdClear
        '
        Me.cmdClear.CausesValidation = false
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(764, 580)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "取　消"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 580)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 580)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 5
        Me.cmdRegist.Text = "確　定"
        '
        'vsfPaletteSlotMap
        '
        Me.vsfPaletteSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfPaletteSlotMap.AllowEditing = false
        Me.vsfPaletteSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfPaletteSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfPaletteSlotMap.AutoResize = true
        Me.vsfPaletteSlotMap.AutoSearchDelay = 2R
        Me.vsfPaletteSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfPaletteSlotMap.ColumnInfo = resources.GetString("vsfPaletteSlotMap.ColumnInfo")
        Me.vsfPaletteSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfPaletteSlotMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfPaletteSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfPaletteSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfPaletteSlotMap.Location = New System.Drawing.Point(8, 137)
        Me.vsfPaletteSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfPaletteSlotMap.Name = "vsfPaletteSlotMap"
        Me.vsfPaletteSlotMap.Rows.Count = 19
        Me.vsfPaletteSlotMap.Rows.DefaultSize = 18
        Me.vsfPaletteSlotMap.Rows.MaxSize = 43
        Me.vsfPaletteSlotMap.Rows.MinSize = 21
        Me.vsfPaletteSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfPaletteSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfPaletteSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfPaletteSlotMap.Size = New System.Drawing.Size(249, 410)
        Me.vsfPaletteSlotMap.StyleInfo = resources.GetString("vsfPaletteSlotMap.StyleInfo")
        Me.vsfPaletteSlotMap.TabIndex = 1
        '
        'vsfRework
        '
        Me.vsfRework.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfRework.AllowEditing = false
        Me.vsfRework.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfRework.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfRework.AutoSearchDelay = 2R
        Me.vsfRework.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfRework.ColumnInfo = resources.GetString("vsfRework.ColumnInfo")
        Me.vsfRework.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfRework.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfRework.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfRework.Location = New System.Drawing.Point(313, 195)
        Me.vsfRework.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfRework.Name = "vsfRework"
        Me.vsfRework.Rows.Count = 24
        Me.vsfRework.Rows.DefaultSize = 18
        Me.vsfRework.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfRework.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfRework.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfRework.Size = New System.Drawing.Size(101, 353)
        Me.vsfRework.StyleInfo = resources.GetString("vsfRework.StyleInfo")
        Me.vsfRework.TabIndex = 3
        '
        'vsfScrap
        '
        Me.vsfScrap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfScrap.AllowEditing = false
        Me.vsfScrap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfScrap.AutoSearchDelay = 2R
        Me.vsfScrap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfScrap.ColumnInfo = resources.GetString("vsfScrap.ColumnInfo")
        Me.vsfScrap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfScrap.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfScrap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfScrap.Location = New System.Drawing.Point(469, 137)
        Me.vsfScrap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfScrap.Name = "vsfScrap"
        Me.vsfScrap.Rows.Count = 24
        Me.vsfScrap.Rows.DefaultSize = 18
        Me.vsfScrap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfScrap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfScrap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfScrap.Size = New System.Drawing.Size(457, 410)
        Me.vsfScrap.StyleInfo = resources.GetString("vsfScrap.StyleInfo")
        Me.vsfScrap.TabIndex = 4
        '
        'txtCarrier
        '
        Me.txtCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 33)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'txtScrap
        '
        Me.txtScrap.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtScrap.ChrMaxByte = 8
        Me.txtScrap.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtScrap.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtScrap.Location = New System.Drawing.Point(312, 138)
        Me.txtScrap.Name = "txtScrap"
        Me.txtScrap.NgChr = "'"
        Me.txtScrap.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtScrap.NumFormat = "##,###,###"
        Me.txtScrap.NumMax = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtScrap.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtScrap.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtScrap.SelectedText = ""
        Me.txtScrap.Size = New System.Drawing.Size(149, 30)
        Me.txtScrap.TabIndex = 2
        Me.txtScrap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(312, 177)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(149, 17)
        Me.lblTtl4.TabIndex = 48
        Me.lblTtl4.Text = "リワーク"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblScrapNum
        '
        Me.lblScrapNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblScrapNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScrapNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblScrapNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblScrapNum.Location = New System.Drawing.Point(860, 556)
        Me.lblScrapNum.Name = "lblScrapNum"
        Me.lblScrapNum.Size = New System.Drawing.Size(65, 17)
        Me.lblScrapNum.TabIndex = 47
        Me.lblScrapNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl17
        '
        Me.lblTtl17.BackColor = System.Drawing.Color.Navy
        Me.lblTtl17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl17.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl17.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl17.Location = New System.Drawing.Point(764, 556)
        Me.lblTtl17.Name = "lblTtl17"
        Me.lblTtl17.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl17.TabIndex = 46
        Me.lblTtl17.Text = "要因合計"
        Me.lblTtl17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblReworkNum
        '
        Me.lblReworkNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblReworkNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReworkNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReworkNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblReworkNum.Location = New System.Drawing.Point(348, 556)
        Me.lblReworkNum.Name = "lblReworkNum"
        Me.lblReworkNum.Size = New System.Drawing.Size(65, 17)
        Me.lblReworkNum.TabIndex = 45
        Me.lblReworkNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl16
        '
        Me.lblTtl16.BackColor = System.Drawing.Color.Navy
        Me.lblTtl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl16.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl16.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl16.Location = New System.Drawing.Point(252, 556)
        Me.lblTtl16.Name = "lblTtl16"
        Me.lblTtl16.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl16.TabIndex = 44
        Me.lblTtl16.Text = "リワーク数"
        Me.lblTtl16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipNormalNum
        '
        Me.lblChipNormalNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblChipNormalNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipNormalNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipNormalNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipNormalNum.Location = New System.Drawing.Point(104, 556)
        Me.lblChipNormalNum.Name = "lblChipNormalNum"
        Me.lblChipNormalNum.Size = New System.Drawing.Size(65, 17)
        Me.lblChipNormalNum.TabIndex = 43
        Me.lblChipNormalNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl14
        '
        Me.lblTtl14.BackColor = System.Drawing.Color.Navy
        Me.lblTtl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl14.Location = New System.Drawing.Point(8, 556)
        Me.lblTtl14.Name = "lblTtl14"
        Me.lblTtl14.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl14.TabIndex = 42
        Me.lblTtl14.Text = "良品数"
        Me.lblTtl14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(688, 66)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl9.TabIndex = 41
        Me.lblTtl9.Text = "ロット担当"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotManager
        '
        Me.lblLotManager.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(688, 82)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(181, 25)
        Me.lblLotManager.TabIndex = 40
        '
        'lblStartDayTime
        '
        Me.lblStartDayTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStartDayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDayTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDayTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStartDayTime.Location = New System.Drawing.Point(688, 32)
        Me.lblStartDayTime.Name = "lblStartDayTime"
        Me.lblStartDayTime.Size = New System.Drawing.Size(181, 25)
        Me.lblStartDayTime.TabIndex = 39
        '
        'lblStartTime
        '
        Me.lblStartTime.BackColor = System.Drawing.Color.Navy
        Me.lblStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartTime.ForeColor = System.Drawing.Color.Yellow
        Me.lblStartTime.Location = New System.Drawing.Point(688, 16)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(181, 17)
        Me.lblStartTime.TabIndex = 38
        Me.lblStartTime.Text = "処理開始日時"
        Me.lblStartTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl3.TabIndex = 37
        Me.lblTtl3.Text = "大工程"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(408, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID.TabIndex = 36
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(408, 82)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 35
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(408, 66)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 34
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblReworkCount
        '
        Me.lblReworkCount.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblReworkCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReworkCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReworkCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblReworkCount.Location = New System.Drawing.Point(868, 82)
        Me.lblReworkCount.Name = "lblReworkCount"
        Me.lblReworkCount.Size = New System.Drawing.Size(97, 25)
        Me.lblReworkCount.TabIndex = 33
        Me.lblReworkCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(868, 66)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl15.TabIndex = 32
        Me.lblTtl15.Text = "ﾘﾜｰｸ回数"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.Color.Navy
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl13.Location = New System.Drawing.Point(8, 121)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(297, 17)
        Me.lblTtl13.TabIndex = 31
        Me.lblTtl13.Text = "スロット（削除パレット選択）"
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(469, 121)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(505, 17)
        Me.lblTtl12.TabIndex = 30
        Me.lblTtl12.Text = "要因"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(313, 121)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(149, 17)
        Me.lblTtl11.TabIndex = 29
        Me.lblTtl11.Text = "不良"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(216, 66)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl7.TabIndex = 28
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(216, 82)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblStatus.TabIndex = 27
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(217, 16)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl6.TabIndex = 26
        Me.lblTtl6.Text = "機種"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdID
        '
        Me.lblPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(217, 32)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblPdID.TabIndex = 25
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(868, 16)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl5.TabIndex = 24
        Me.lblTtl5.Text = "特殊特性"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(312, 16)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl2.TabIndex = 23
        Me.lblTtl2.Text = "数量"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(312, 32)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
        Me.lblWFNo.TabIndex = 22
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(16, 82)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 21
        '
        'lblTimeLimit
        '
        Me.lblTimeLimit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTimeLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTimeLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTimeLimit.Location = New System.Drawing.Point(312, 82)
        Me.lblTimeLimit.Name = "lblTimeLimit"
        Me.lblTimeLimit.Size = New System.Drawing.Size(97, 25)
        Me.lblTimeLimit.TabIndex = 20
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(312, 66)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl10.TabIndex = 19
        Me.lblTtl10.Text = "時間制限"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblS
        '
        Me.lblS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblS.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblS.Location = New System.Drawing.Point(868, 32)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(97, 25)
        Me.lblS.TabIndex = 18
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
        Me.lblTtl0.TabIndex = 17
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 82)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 16
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(16, 66)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 15
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 105)
        Me.lblBack.TabIndex = 14
        '
        'frmxxCM00B0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdScrapDown)
        Me.Controls.Add(Me.cmdReworkDown)
        Me.Controls.Add(Me.cmdSlotDown)
        Me.Controls.Add(Me.cmdSlotUp)
        Me.Controls.Add(Me.cmdScrapUp)
        Me.Controls.Add(Me.cmdReworkUP)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.vsfPaletteSlotMap)
        Me.Controls.Add(Me.vsfRework)
        Me.Controls.Add(Me.vsfScrap)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.txtScrap)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblScrapNum)
        Me.Controls.Add(Me.lblTtl17)
        Me.Controls.Add(Me.lblReworkNum)
        Me.Controls.Add(Me.lblTtl16)
        Me.Controls.Add(Me.lblChipNormalNum)
        Me.Controls.Add(Me.lblTtl14)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblStartDayTime)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblReworkCount)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.lblTtl13)
        Me.Controls.Add(Me.lblTtl12)
        Me.Controls.Add(Me.lblTtl11)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTimeLimit)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblS)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00B0"
        Me.Text = "対向基板処置登録"
        CType(Me.vsfPaletteSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfRework,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfScrap,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdScrapDown As Button
    Friend WithEvents cmdReworkDown As Button
    Friend WithEvents cmdSlotDown As Button
    Friend WithEvents cmdSlotUp As Button
    Friend WithEvents cmdScrapUp As Button
    Friend WithEvents cmdReworkUP As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents vsfPaletteSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfRework As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfScrap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents txtScrap As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblScrapNum As Label
    Friend WithEvents lblTtl17 As Label
    Friend WithEvents lblReworkNum As Label
    Friend WithEvents lblTtl16 As Label
    Friend WithEvents lblChipNormalNum As Label
    Friend WithEvents lblTtl14 As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblStartDayTime As Label
    Friend WithEvents lblStartTime As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblReworkCount As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTimeLimit As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblS As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblBack As Label
End Class
