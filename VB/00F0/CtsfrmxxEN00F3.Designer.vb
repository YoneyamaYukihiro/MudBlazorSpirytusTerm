<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00F3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00F3))
        Me.cmdLumpDivideWF2 = New System.Windows.Forms.Button()
        Me.cmdLumpDivideWF1 = New System.Windows.Forms.Button()
        Me.cmdManual = New System.Windows.Forms.Button()
        Me.fraPartition2 = New System.Windows.Forms.GroupBox()
        Me.cmdCarrierSelect2 = New System.Windows.Forms.Button()
        Me.cmdDown2 = New System.Windows.Forms.Button()
        Me.cmdUP2 = New System.Windows.Forms.Button()
        Me.vsfSlotMap2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtToCarrierID2 = New SETextBoxEx.TextBoxEx()
        Me.lblTitle31 = New System.Windows.Forms.Label()
        Me.lblLabel6 = New System.Windows.Forms.Label()
        Me.lblWFNum2 = New System.Windows.Forms.Label()
        Me.cmdLump = New System.Windows.Forms.Button()
        Me.fraPartition1 = New System.Windows.Forms.GroupBox()
        Me.cmdCarrierSelect1 = New System.Windows.Forms.Button()
        Me.cmdDown1 = New System.Windows.Forms.Button()
        Me.cmdUP1 = New System.Windows.Forms.Button()
        Me.vsfSlotMap1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtToCarrierID1 = New SETextBoxEx.TextBoxEx()
        Me.lblTitle30 = New System.Windows.Forms.Label()
        Me.lblLabel5 = New System.Windows.Forms.Label()
        Me.lblWFNum1 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraOrigin = New System.Windows.Forms.GroupBox()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.lblLabel4 = New System.Windows.Forms.Label()
        Me.lblWFNum = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblLabel1 = New System.Windows.Forms.Label()
        Me.lblLabel0 = New System.Windows.Forms.Label()
        Me.fraPartition2.SuspendLayout
        CType(Me.vsfSlotMap2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraPartition1.SuspendLayout
        CType(Me.vsfSlotMap1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraOrigin.SuspendLayout
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdLumpDivideWF2
        '
        Me.cmdLumpDivideWF2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLumpDivideWF2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLumpDivideWF2.Location = New System.Drawing.Point(302, 240)
        Me.cmdLumpDivideWF2.Name = "cmdLumpDivideWF2"
        Me.cmdLumpDivideWF2.Size = New System.Drawing.Size(85, 40)
        Me.cmdLumpDivideWF2.TabIndex = 4
        Me.cmdLumpDivideWF2.Text = "一括分割"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"＃11－20"
        '
        'cmdLumpDivideWF1
        '
        Me.cmdLumpDivideWF1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLumpDivideWF1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLumpDivideWF1.Location = New System.Drawing.Point(302, 185)
        Me.cmdLumpDivideWF1.Name = "cmdLumpDivideWF1"
        Me.cmdLumpDivideWF1.Size = New System.Drawing.Size(85, 40)
        Me.cmdLumpDivideWF1.TabIndex = 3
        Me.cmdLumpDivideWF1.Text = "一括分割"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"＃01－10"
        '
        'cmdManual
        '
        Me.cmdManual.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdManual.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdManual.Location = New System.Drawing.Point(302, 296)
        Me.cmdManual.Name = "cmdManual"
        Me.cmdManual.Size = New System.Drawing.Size(85, 40)
        Me.cmdManual.TabIndex = 5
        Me.cmdManual.Text = "編成用"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"手動分割"
        '
        'fraPartition2
        '
        Me.fraPartition2.Controls.Add(Me.cmdCarrierSelect2)
        Me.fraPartition2.Controls.Add(Me.cmdDown2)
        Me.fraPartition2.Controls.Add(Me.cmdUP2)
        Me.fraPartition2.Controls.Add(Me.vsfSlotMap2)
        Me.fraPartition2.Controls.Add(Me.txtToCarrierID2)
        Me.fraPartition2.Controls.Add(Me.lblTitle31)
        Me.fraPartition2.Controls.Add(Me.lblLabel6)
        Me.fraPartition2.Controls.Add(Me.lblWFNum2)
        Me.fraPartition2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraPartition2.Location = New System.Drawing.Point(686, 8)
        Me.fraPartition2.Name = "fraPartition2"
        Me.fraPartition2.Size = New System.Drawing.Size(287, 583)
        Me.fraPartition2.TabIndex = 10
        Me.fraPartition2.TabStop = false
        Me.fraPartition2.Text = "分割予約２"
        '
        'cmdCarrierSelect2
        '
        Me.cmdCarrierSelect2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect2.Location = New System.Drawing.Point(144, 20)
        Me.cmdCarrierSelect2.Name = "cmdCarrierSelect2"
        Me.cmdCarrierSelect2.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect2.TabIndex = 18
        Me.cmdCarrierSelect2.TabStop = false
        Me.cmdCarrierSelect2.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdDown2
        '
        Me.cmdDown2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown2.Location = New System.Drawing.Point(228, 344)
        Me.cmdDown2.Name = "cmdDown2"
        Me.cmdDown2.Size = New System.Drawing.Size(49, 227)
        Me.cmdDown2.TabIndex = 12
        Me.cmdDown2.Text = "▼"
        '
        'cmdUP2
        '
        Me.cmdUP2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP2.Location = New System.Drawing.Point(228, 115)
        Me.cmdUP2.Name = "cmdUP2"
        Me.cmdUP2.Size = New System.Drawing.Size(49, 227)
        Me.cmdUP2.TabIndex = 11
        Me.cmdUP2.Text = "▲"
        '
        'vsfSlotMap2
        '
        Me.vsfSlotMap2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap2.AllowEditing = false
        Me.vsfSlotMap2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap2.AutoSearchDelay = 2R
        Me.vsfSlotMap2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap2.ColumnInfo = resources.GetString("vsfSlotMap2.ColumnInfo")
        Me.vsfSlotMap2.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap2.ExtendLastCol = true
        Me.vsfSlotMap2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfSlotMap2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap2.Location = New System.Drawing.Point(8, 116)
        Me.vsfSlotMap2.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap2.Name = "vsfSlotMap2"
        Me.vsfSlotMap2.Rows.Count = 11
        Me.vsfSlotMap2.Rows.DefaultSize = 18
        Me.vsfSlotMap2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap2.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap2.Size = New System.Drawing.Size(221, 454)
        Me.vsfSlotMap2.StyleInfo = resources.GetString("vsfSlotMap2.StyleInfo")
        Me.vsfSlotMap2.TabIndex = 19
        '
        'txtToCarrierID2
        '
        Me.txtToCarrierID2.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtToCarrierID2.ChrMaxByte = 6
        Me.txtToCarrierID2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtToCarrierID2.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtToCarrierID2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtToCarrierID2.Location = New System.Drawing.Point(8, 36)
        Me.txtToCarrierID2.Name = "txtToCarrierID2"
        Me.txtToCarrierID2.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtToCarrierID2.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtToCarrierID2.SelectedText = ""
        Me.txtToCarrierID2.Size = New System.Drawing.Size(125, 22)
        Me.txtToCarrierID2.TabIndex = 10
        '
        'lblTitle31
        '
        Me.lblTitle31.BackColor = System.Drawing.Color.Navy
        Me.lblTitle31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle31.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle31.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle31.Location = New System.Drawing.Point(8, 20)
        Me.lblTitle31.Name = "lblTitle31"
        Me.lblTitle31.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle31.TabIndex = 35
        Me.lblTitle31.Text = "キャリアID"
        Me.lblTitle31.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLabel6
        '
        Me.lblLabel6.BackColor = System.Drawing.Color.Navy
        Me.lblLabel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabel6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLabel6.ForeColor = System.Drawing.Color.Yellow
        Me.lblLabel6.Location = New System.Drawing.Point(194, 68)
        Me.lblLabel6.Name = "lblLabel6"
        Me.lblLabel6.Size = New System.Drawing.Size(85, 17)
        Me.lblLabel6.TabIndex = 32
        Me.lblLabel6.Text = "WF枚数"
        Me.lblLabel6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNum2
        '
        Me.lblWFNum2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNum2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNum2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNum2.Location = New System.Drawing.Point(194, 84)
        Me.lblWFNum2.Name = "lblWFNum2"
        Me.lblWFNum2.Size = New System.Drawing.Size(85, 22)
        Me.lblWFNum2.TabIndex = 31
        Me.lblWFNum2.Text = "0"
        Me.lblWFNum2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdLump
        '
        Me.cmdLump.Enabled = false
        Me.cmdLump.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLump.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLump.Location = New System.Drawing.Point(302, 350)
        Me.cmdLump.Name = "cmdLump"
        Me.cmdLump.Size = New System.Drawing.Size(85, 40)
        Me.cmdLump.TabIndex = 6
        Me.cmdLump.Text = "編成用"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"一括分割"
        Me.cmdLump.Visible = false
        '
        'fraPartition1
        '
        Me.fraPartition1.Controls.Add(Me.cmdCarrierSelect1)
        Me.fraPartition1.Controls.Add(Me.cmdDown1)
        Me.fraPartition1.Controls.Add(Me.cmdUP1)
        Me.fraPartition1.Controls.Add(Me.vsfSlotMap1)
        Me.fraPartition1.Controls.Add(Me.txtToCarrierID1)
        Me.fraPartition1.Controls.Add(Me.lblTitle30)
        Me.fraPartition1.Controls.Add(Me.lblLabel5)
        Me.fraPartition1.Controls.Add(Me.lblWFNum1)
        Me.fraPartition1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraPartition1.Location = New System.Drawing.Point(394, 8)
        Me.fraPartition1.Name = "fraPartition1"
        Me.fraPartition1.Size = New System.Drawing.Size(287, 583)
        Me.fraPartition1.TabIndex = 7
        Me.fraPartition1.TabStop = false
        Me.fraPartition1.Text = "分割予約１"
        '
        'cmdCarrierSelect1
        '
        Me.cmdCarrierSelect1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect1.Location = New System.Drawing.Point(144, 20)
        Me.cmdCarrierSelect1.Name = "cmdCarrierSelect1"
        Me.cmdCarrierSelect1.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect1.TabIndex = 16
        Me.cmdCarrierSelect1.TabStop = false
        Me.cmdCarrierSelect1.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdDown1
        '
        Me.cmdDown1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown1.Location = New System.Drawing.Point(228, 344)
        Me.cmdDown1.Name = "cmdDown1"
        Me.cmdDown1.Size = New System.Drawing.Size(49, 227)
        Me.cmdDown1.TabIndex = 9
        Me.cmdDown1.Text = "▼"
        '
        'cmdUP1
        '
        Me.cmdUP1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP1.Location = New System.Drawing.Point(228, 115)
        Me.cmdUP1.Name = "cmdUP1"
        Me.cmdUP1.Size = New System.Drawing.Size(49, 227)
        Me.cmdUP1.TabIndex = 8
        Me.cmdUP1.Text = "▲"
        '
        'vsfSlotMap1
        '
        Me.vsfSlotMap1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap1.AllowEditing = false
        Me.vsfSlotMap1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap1.AutoSearchDelay = 2R
        Me.vsfSlotMap1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap1.ColumnInfo = resources.GetString("vsfSlotMap1.ColumnInfo")
        Me.vsfSlotMap1.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap1.ExtendLastCol = true
        Me.vsfSlotMap1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfSlotMap1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap1.Location = New System.Drawing.Point(8, 116)
        Me.vsfSlotMap1.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap1.Name = "vsfSlotMap1"
        Me.vsfSlotMap1.Rows.Count = 11
        Me.vsfSlotMap1.Rows.DefaultSize = 18
        Me.vsfSlotMap1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap1.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap1.Size = New System.Drawing.Size(221, 454)
        Me.vsfSlotMap1.StyleInfo = resources.GetString("vsfSlotMap1.StyleInfo")
        Me.vsfSlotMap1.TabIndex = 17
        '
        'txtToCarrierID1
        '
        Me.txtToCarrierID1.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtToCarrierID1.ChrMaxByte = 6
        Me.txtToCarrierID1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtToCarrierID1.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtToCarrierID1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtToCarrierID1.Location = New System.Drawing.Point(8, 36)
        Me.txtToCarrierID1.Name = "txtToCarrierID1"
        Me.txtToCarrierID1.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtToCarrierID1.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtToCarrierID1.SelectedText = ""
        Me.txtToCarrierID1.Size = New System.Drawing.Size(125, 22)
        Me.txtToCarrierID1.TabIndex = 7
        '
        'lblTitle30
        '
        Me.lblTitle30.BackColor = System.Drawing.Color.Navy
        Me.lblTitle30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle30.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle30.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle30.Location = New System.Drawing.Point(8, 20)
        Me.lblTitle30.Name = "lblTitle30"
        Me.lblTitle30.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle30.TabIndex = 34
        Me.lblTitle30.Text = "キャリアID"
        Me.lblTitle30.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLabel5
        '
        Me.lblLabel5.BackColor = System.Drawing.Color.Navy
        Me.lblLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLabel5.ForeColor = System.Drawing.Color.Yellow
        Me.lblLabel5.Location = New System.Drawing.Point(194, 68)
        Me.lblLabel5.Name = "lblLabel5"
        Me.lblLabel5.Size = New System.Drawing.Size(85, 17)
        Me.lblLabel5.TabIndex = 30
        Me.lblLabel5.Text = "WF枚数"
        Me.lblLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNum1
        '
        Me.lblWFNum1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNum1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNum1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNum1.Location = New System.Drawing.Point(194, 84)
        Me.lblWFNum1.Name = "lblWFNum1"
        Me.lblWFNum1.Size = New System.Drawing.Size(85, 22)
        Me.lblWFNum1.TabIndex = 29
        Me.lblWFNum1.Text = "0"
        Me.lblWFNum1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(792, 595)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "取　消"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 595)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 13
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 595)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "閉じる"
        '
        'fraOrigin
        '
        Me.fraOrigin.Controls.Add(Me.cmdDown)
        Me.fraOrigin.Controls.Add(Me.cmdUP)
        Me.fraOrigin.Controls.Add(Me.vsfSlotMap)
        Me.fraOrigin.Controls.Add(Me.lblCarrier)
        Me.fraOrigin.Controls.Add(Me.lblLabel4)
        Me.fraOrigin.Controls.Add(Me.lblWFNum)
        Me.fraOrigin.Controls.Add(Me.lblFlowClass)
        Me.fraOrigin.Controls.Add(Me.lblLotID)
        Me.fraOrigin.Controls.Add(Me.lblLabel1)
        Me.fraOrigin.Controls.Add(Me.lblLabel0)
        Me.fraOrigin.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraOrigin.Location = New System.Drawing.Point(8, 8)
        Me.fraOrigin.Name = "fraOrigin"
        Me.fraOrigin.Size = New System.Drawing.Size(287, 583)
        Me.fraOrigin.TabIndex = 0
        Me.fraOrigin.TabStop = false
        Me.fraOrigin.Text = "元キャリア"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(228, 344)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 227)
        Me.cmdDown.TabIndex = 2
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(228, 115)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 227)
        Me.cmdUP.TabIndex = 1
        Me.cmdUP.Text = "▲"
        '
        'vsfSlotMap
        '
        Me.vsfSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap.AllowEditing = false
        Me.vsfSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap.AutoSearchDelay = 2R
        Me.vsfSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap.ColumnInfo = "6,1,0,0,0,135,Columns:0{Width:30;}"&Global.Microsoft.VisualBasic.ChrW(9)&"1{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"2{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"3{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"4{Width"& _ 
    ":88;Caption:""WF_ID"";}"&Global.Microsoft.VisualBasic.ChrW(9)&"5{Width:88;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap.ExtendLastCol = true
        Me.vsfSlotMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap.Location = New System.Drawing.Point(8, 116)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 11
        Me.vsfSlotMap.Rows.DefaultSize = 18
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap.Size = New System.Drawing.Size(221, 454)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 0
        Me.vsfSlotMap.UseCompatibleTextRendering = true
        '
        'lblCarrier
        '
        Me.lblCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrier.Location = New System.Drawing.Point(8, 36)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(125, 22)
        Me.lblCarrier.TabIndex = 33
        Me.lblCarrier.Text = "GTA1234-00"
        '
        'lblLabel4
        '
        Me.lblLabel4.BackColor = System.Drawing.Color.Navy
        Me.lblLabel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLabel4.ForeColor = System.Drawing.Color.Yellow
        Me.lblLabel4.Location = New System.Drawing.Point(194, 68)
        Me.lblLabel4.Name = "lblLabel4"
        Me.lblLabel4.Size = New System.Drawing.Size(85, 17)
        Me.lblLabel4.TabIndex = 28
        Me.lblLabel4.Text = "WF枚数"
        Me.lblLabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNum
        '
        Me.lblWFNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNum.Location = New System.Drawing.Point(194, 84)
        Me.lblWFNum.Name = "lblWFNum"
        Me.lblWFNum.Size = New System.Drawing.Size(85, 22)
        Me.lblWFNum.TabIndex = 27
        Me.lblWFNum.Text = "0"
        Me.lblWFNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(94, 84)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(39, 22)
        Me.lblFlowClass.TabIndex = 25
        Me.lblFlowClass.Text = "ZZZZ"
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(8, 84)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(89, 22)
        Me.lblLotID.TabIndex = 24
        Me.lblLotID.Text = "1230567890"
        '
        'lblLabel1
        '
        Me.lblLabel1.BackColor = System.Drawing.Color.Navy
        Me.lblLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLabel1.ForeColor = System.Drawing.Color.Yellow
        Me.lblLabel1.Location = New System.Drawing.Point(8, 68)
        Me.lblLabel1.Name = "lblLabel1"
        Me.lblLabel1.Size = New System.Drawing.Size(125, 17)
        Me.lblLabel1.TabIndex = 23
        Me.lblLabel1.Text = "ロットID"
        Me.lblLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLabel0
        '
        Me.lblLabel0.BackColor = System.Drawing.Color.Navy
        Me.lblLabel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLabel0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLabel0.ForeColor = System.Drawing.Color.Yellow
        Me.lblLabel0.Location = New System.Drawing.Point(8, 20)
        Me.lblLabel0.Name = "lblLabel0"
        Me.lblLabel0.Size = New System.Drawing.Size(125, 17)
        Me.lblLabel0.TabIndex = 22
        Me.lblLabel0.Text = "キャリアID"
        Me.lblLabel0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00F3
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdLumpDivideWF2)
        Me.Controls.Add(Me.cmdLumpDivideWF1)
        Me.Controls.Add(Me.cmdManual)
        Me.Controls.Add(Me.fraPartition2)
        Me.Controls.Add(Me.cmdLump)
        Me.Controls.Add(Me.fraPartition1)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraOrigin)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(2, 62)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00F3"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "組立在庫分割予約"
        Me.fraPartition2.ResumeLayout(false)
        CType(Me.vsfSlotMap2,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraPartition1.ResumeLayout(false)
        CType(Me.vsfSlotMap1,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraOrigin.ResumeLayout(false)
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdLumpDivideWF2 As Button
    Friend WithEvents cmdLumpDivideWF1 As Button
    Friend WithEvents cmdManual As Button
    Friend WithEvents fraPartition2 As GroupBox
    Friend WithEvents cmdCarrierSelect2 As Button
    Friend WithEvents cmdDown2 As Button
    Friend WithEvents cmdUP2 As Button
    Friend WithEvents vsfSlotMap2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtToCarrierID2 As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle31 As Label
    Friend WithEvents lblLabel6 As Label
    Friend WithEvents lblWFNum2 As Label
    Friend WithEvents cmdLump As Button
    Friend WithEvents fraPartition1 As GroupBox
    Friend WithEvents cmdCarrierSelect1 As Button
    Friend WithEvents cmdDown1 As Button
    Friend WithEvents cmdUP1 As Button
    Friend WithEvents vsfSlotMap1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtToCarrierID1 As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle30 As Label
    Friend WithEvents lblLabel5 As Label
    Friend WithEvents lblWFNum1 As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraOrigin As GroupBox
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblCarrier As Label
    Friend WithEvents lblLabel4 As Label
    Friend WithEvents lblWFNum As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblLabel1 As Label
    Friend WithEvents lblLabel0 As Label
End Class
