<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02E0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02E0))
        Me.cmdAllClear = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdTreatCF = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraSlotMap1 = New System.Windows.Forms.GroupBox()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.cmdDown1 = New System.Windows.Forms.Button()
        Me.cmdUp1 = New System.Windows.Forms.Button()
        Me.vsfSlotMap1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtCarrierID1 = New SETextBoxEx.TextBoxEx()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.fraSlotMap2 = New System.Windows.Forms.GroupBox()
        Me.txtMoveNum = New SETextBoxEx.TextBoxEx()
        Me.Title1 = New System.Windows.Forms.Label()
        Me.labSum = New System.Windows.Forms.Label()
        Me.Title3 = New System.Windows.Forms.Label()
        Me.labScrapNum = New System.Windows.Forms.Label()
        Me.Title2 = New System.Windows.Forms.Label()
        Me.labReworkNum = New System.Windows.Forms.Label()
        Me.Title0 = New System.Windows.Forms.Label()
        Me.cmdJigSelect = New System.Windows.Forms.Button()
        Me.cmdDown2 = New System.Windows.Forms.Button()
        Me.cmdUp2 = New System.Windows.Forms.Button()
        Me.vsfSlotMap2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.txtCarrierID2 = New SETextBoxEx.TextBoxEx()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        CType(Me.vsfSlotMap1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfSlotMap2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdAllClear
        '
        Me.cmdAllClear.CausesValidation = false
        Me.cmdAllClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAllClear.Location = New System.Drawing.Point(440, 579)
        Me.cmdAllClear.Name = "cmdAllClear"
        Me.cmdAllClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdAllClear.TabIndex = 9
        Me.cmdAllClear.Text = "全部取消"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 579)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "閉じる"
        '
        'cmdTreatCF
        '
        Me.cmdTreatCF.CausesValidation = false
        Me.cmdTreatCF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTreatCF.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTreatCF.Location = New System.Drawing.Point(764, 579)
        Me.cmdTreatCF.Name = "cmdTreatCF"
        Me.cmdTreatCF.Size = New System.Drawing.Size(105, 57)
        Me.cmdTreatCF.TabIndex = 8
        Me.cmdTreatCF.Text = "対向基板"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"処置登録"
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 579)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 7
        Me.cmdRegist.Text = "確　定"
        '
        'fraSlotMap1
        '
        Me.fraSlotMap1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotMap1.Location = New System.Drawing.Point(104, 64)
        Me.fraSlotMap1.Name = "fraSlotMap1"
        Me.fraSlotMap1.Size = New System.Drawing.Size(384, 504)
        Me.fraSlotMap1.TabIndex = 36
        Me.fraSlotMap1.TabStop = false
        Me.fraSlotMap1.Text = "移載前"
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(360, 512)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle2.TabIndex = 30
        Me.lblTitle2.Text = "数　量"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNum
        '
        Me.lblNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNum.Location = New System.Drawing.Point(360, 528)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(97, 25)
        Me.lblNum.TabIndex = 20
        Me.lblNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdDown1
        '
        Me.cmdDown1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown1.Location = New System.Drawing.Point(297, 347)
        Me.cmdDown1.Name = "cmdDown1"
        Me.cmdDown1.Size = New System.Drawing.Size(49, 206)
        Me.cmdDown1.TabIndex = 33
        Me.cmdDown1.Text = "▼"
        '
        'cmdUp1
        '
        Me.cmdUp1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp1.Location = New System.Drawing.Point(297, 143)
        Me.cmdUp1.Name = "cmdUp1"
        Me.cmdUp1.Size = New System.Drawing.Size(49, 206)
        Me.cmdUp1.TabIndex = 32
        Me.cmdUp1.Text = "▲"
        '
        'vsfSlotMap1
        '
        Me.vsfSlotMap1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap1.AllowEditing = false
        Me.vsfSlotMap1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap1.AutoResize = true
        Me.vsfSlotMap1.AutoSearchDelay = 2R
        Me.vsfSlotMap1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap1.ColumnInfo = resources.GetString("vsfSlotMap1.ColumnInfo")
        Me.vsfSlotMap1.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap1.ExtendLastCol = true
        Me.vsfSlotMap1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!)
        Me.vsfSlotMap1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap1.Location = New System.Drawing.Point(120, 144)
        Me.vsfSlotMap1.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap1.Name = "vsfSlotMap1"
        Me.vsfSlotMap1.Rows.Count = 25
        Me.vsfSlotMap1.Rows.DefaultSize = 20
        Me.vsfSlotMap1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap1.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap1.Size = New System.Drawing.Size(177, 408)
        Me.vsfSlotMap1.StyleInfo = resources.GetString("vsfSlotMap1.StyleInfo")
        Me.vsfSlotMap1.TabIndex = 31
        '
        'txtCarrierID1
        '
        Me.txtCarrierID1.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID1.ChrMaxByte = 6
        Me.txtCarrierID1.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID1.Location = New System.Drawing.Point(120, 104)
        Me.txtCarrierID1.Name = "txtCarrierID1"
        Me.txtCarrierID1.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID1.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID1.SelectedText = ""
        Me.txtCarrierID1.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrierID1.TabIndex = 1
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(120, 88)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle5.TabIndex = 37
        Me.lblTitle5.Text = "キャリアID"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraSlotMap2
        '
        Me.fraSlotMap2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotMap2.Location = New System.Drawing.Point(528, 64)
        Me.fraSlotMap2.Name = "fraSlotMap2"
        Me.fraSlotMap2.Size = New System.Drawing.Size(376, 504)
        Me.fraSlotMap2.TabIndex = 0
        Me.fraSlotMap2.TabStop = false
        Me.fraSlotMap2.Text = "移載後"
        '
        'txtMoveNum
        '
        Me.txtMoveNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtMoveNum.ChrMaxByte = 5
        Me.txtMoveNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtMoveNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMoveNum.Location = New System.Drawing.Point(776, 528)
        Me.txtMoveNum.Name = "txtMoveNum"
        Me.txtMoveNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtMoveNum.NumFormat = "###,###"
        Me.txtMoveNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtMoveNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMoveNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMoveNum.SelectedText = ""
        Me.txtMoveNum.Size = New System.Drawing.Size(121, 30)
        Me.txtMoveNum.TabIndex = 6
        Me.txtMoveNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Title1
        '
        Me.Title1.BackColor = System.Drawing.Color.Navy
        Me.Title1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Title1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Title1.ForeColor = System.Drawing.Color.Yellow
        Me.Title1.Location = New System.Drawing.Point(776, 512)
        Me.Title1.Name = "Title1"
        Me.Title1.Size = New System.Drawing.Size(121, 17)
        Me.Title1.TabIndex = 29
        Me.Title1.Text = "移載数量"
        Me.Title1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labSum
        '
        Me.labSum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labSum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labSum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labSum.Location = New System.Drawing.Point(776, 480)
        Me.labSum.Name = "labSum"
        Me.labSum.Size = New System.Drawing.Size(85, 22)
        Me.labSum.TabIndex = 19
        Me.labSum.Text = "0"
        Me.labSum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Title3
        '
        Me.Title3.BackColor = System.Drawing.Color.Navy
        Me.Title3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Title3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Title3.ForeColor = System.Drawing.Color.Yellow
        Me.Title3.Location = New System.Drawing.Point(776, 464)
        Me.Title3.Name = "Title3"
        Me.Title3.Size = New System.Drawing.Size(85, 17)
        Me.Title3.TabIndex = 28
        Me.Title3.Text = "合　計"
        Me.Title3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labScrapNum
        '
        Me.labScrapNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labScrapNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labScrapNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labScrapNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labScrapNum.Location = New System.Drawing.Point(776, 432)
        Me.labScrapNum.Name = "labScrapNum"
        Me.labScrapNum.Size = New System.Drawing.Size(85, 22)
        Me.labScrapNum.TabIndex = 18
        Me.labScrapNum.Text = "0"
        Me.labScrapNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Title2
        '
        Me.Title2.BackColor = System.Drawing.Color.Navy
        Me.Title2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Title2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Title2.ForeColor = System.Drawing.Color.Yellow
        Me.Title2.Location = New System.Drawing.Point(776, 416)
        Me.Title2.Name = "Title2"
        Me.Title2.Size = New System.Drawing.Size(85, 17)
        Me.Title2.TabIndex = 27
        Me.Title2.Text = "不　良"
        Me.Title2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labReworkNum
        '
        Me.labReworkNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labReworkNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labReworkNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labReworkNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labReworkNum.Location = New System.Drawing.Point(776, 384)
        Me.labReworkNum.Name = "labReworkNum"
        Me.labReworkNum.Size = New System.Drawing.Size(85, 22)
        Me.labReworkNum.TabIndex = 17
        Me.labReworkNum.Text = "0"
        Me.labReworkNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Title0
        '
        Me.Title0.BackColor = System.Drawing.Color.Navy
        Me.Title0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Title0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Title0.ForeColor = System.Drawing.Color.Yellow
        Me.Title0.Location = New System.Drawing.Point(776, 368)
        Me.Title0.Name = "Title0"
        Me.Title0.Size = New System.Drawing.Size(85, 17)
        Me.Title0.TabIndex = 26
        Me.Title0.Text = "リワーク"
        Me.Title0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdJigSelect
        '
        Me.cmdJigSelect.CausesValidation = false
        Me.cmdJigSelect.Enabled = false
        Me.cmdJigSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdJigSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdJigSelect.Location = New System.Drawing.Point(776, 304)
        Me.cmdJigSelect.Name = "cmdJigSelect"
        Me.cmdJigSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdJigSelect.TabIndex = 5
        Me.cmdJigSelect.Text = "空き冶具"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdDown2
        '
        Me.cmdDown2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown2.Location = New System.Drawing.Point(715, 347)
        Me.cmdDown2.Name = "cmdDown2"
        Me.cmdDown2.Size = New System.Drawing.Size(49, 206)
        Me.cmdDown2.TabIndex = 35
        Me.cmdDown2.Text = "▼"
        '
        'cmdUp2
        '
        Me.cmdUp2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp2.Location = New System.Drawing.Point(715, 143)
        Me.cmdUp2.Name = "cmdUp2"
        Me.cmdUp2.Size = New System.Drawing.Size(49, 206)
        Me.cmdUp2.TabIndex = 34
        Me.cmdUp2.Text = "▲"
        '
        'vsfSlotMap2
        '
        Me.vsfSlotMap2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap2.AllowEditing = false
        Me.vsfSlotMap2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap2.AutoResize = true
        Me.vsfSlotMap2.AutoSearchDelay = 2R
        Me.vsfSlotMap2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap2.ColumnInfo = resources.GetString("vsfSlotMap2.ColumnInfo")
        Me.vsfSlotMap2.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap2.ExtendLastCol = true
        Me.vsfSlotMap2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!)
        Me.vsfSlotMap2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap2.Location = New System.Drawing.Point(538, 144)
        Me.vsfSlotMap2.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap2.Name = "vsfSlotMap2"
        Me.vsfSlotMap2.Rows.Count = 25
        Me.vsfSlotMap2.Rows.DefaultSize = 20
        Me.vsfSlotMap2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap2.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap2.Size = New System.Drawing.Size(177, 408)
        Me.vsfSlotMap2.StyleInfo = resources.GetString("vsfSlotMap2.StyleInfo")
        Me.vsfSlotMap2.TabIndex = 4
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.CausesValidation = false
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(728, 80)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdCarrierSelect.TabIndex = 3
        Me.cmdCarrierSelect.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'txtCarrierID2
        '
        Me.txtCarrierID2.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID2.ChrMaxByte = 6
        Me.txtCarrierID2.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID2.Location = New System.Drawing.Point(536, 104)
        Me.txtCarrierID2.Name = "txtCarrierID2"
        Me.txtCarrierID2.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID2.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID2.SelectedText = ""
        Me.txtCarrierID2.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrierID2.TabIndex = 2
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(536, 88)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle0.TabIndex = 21
        Me.lblTitle0.Text = "キャリアID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(704, 24)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(265, 25)
        Me.lblStepID.TabIndex = 16
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(704, 8)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(265, 17)
        Me.lblTtl8.TabIndex = 25
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(448, 8)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(249, 17)
        Me.lblTtl2.TabIndex = 24
        Me.lblTtl2.Text = "大工程"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(448, 24)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(249, 25)
        Me.lblOpID.TabIndex = 15
        '
        'lblPdID
        '
        Me.lblPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(344, 24)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblPdID.TabIndex = 14
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(344, 8)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl3.TabIndex = 23
        Me.lblTtl3.Text = "機種"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(200, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(137, 25)
        Me.lblStatus.TabIndex = 13
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(200, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(137, 17)
        Me.lblTitle1.TabIndex = 22
        Me.lblTitle1.Text = "状態"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(8, 24)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 11
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(128, 24)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 12
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(8, 8)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 21
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02E0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.txtMoveNum)
        Me.Controls.Add(Me.Title1)
        Me.Controls.Add(Me.labSum)
        Me.Controls.Add(Me.Title3)
        Me.Controls.Add(Me.labScrapNum)
        Me.Controls.Add(Me.Title2)
        Me.Controls.Add(Me.labReworkNum)
        Me.Controls.Add(Me.Title0)
        Me.Controls.Add(Me.cmdJigSelect)
        Me.Controls.Add(Me.cmdDown2)
        Me.Controls.Add(Me.cmdUp2)
        Me.Controls.Add(Me.vsfSlotMap2)
        Me.Controls.Add(Me.cmdCarrierSelect)
        Me.Controls.Add(Me.txtCarrierID2)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblNum)
        Me.Controls.Add(Me.cmdDown1)
        Me.Controls.Add(Me.cmdUp1)
        Me.Controls.Add(Me.vsfSlotMap1)
        Me.Controls.Add(Me.txtCarrierID1)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.cmdAllClear)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdTreatCF)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.fraSlotMap1)
        Me.Controls.Add(Me.fraSlotMap2)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02E0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CF移載情報登録"
        CType(Me.vsfSlotMap1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfSlotMap2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdAllClear As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdTreatCF As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraSlotMap1 As GroupBox
    Friend WithEvents cmdUp1 As Button
    Friend WithEvents cmdDown1 As Button
    Friend WithEvents vsfSlotMap1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtCarrierID1 As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblNum As Label
    Friend WithEvents fraSlotMap2 As GroupBox
    Friend WithEvents cmdJigSelect As Button
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents cmdUp2 As Button
    Friend WithEvents cmdDown2 As Button
    Friend WithEvents vsfSlotMap2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtCarrierID2 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtMoveNum As SETextBoxEx.TextBoxEx
    Friend WithEvents Title1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents labSum As Label
    Friend WithEvents Title3 As Label
    Friend WithEvents labReworkNum As Label
    Friend WithEvents Title0 As Label
    Friend WithEvents labScrapNum As Label
    Friend WithEvents Title2 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
End Class
