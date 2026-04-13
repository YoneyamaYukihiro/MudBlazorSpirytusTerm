<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00B0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00B0))
        Me.cmdScrap = New System.Windows.Forms.Button()
        Me.fraThrowinWP = New System.Windows.Forms.GroupBox()
        Me.cmbThrowinWP = New SEComboBoxEx.ComboBoxEx()
        Me.lblThrowinWPTitle = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdPdChange = New System.Windows.Forms.Button()
        Me.cmdAllClear = New System.Windows.Forms.Button()
        Me.fraThrow = New System.Windows.Forms.GroupBox()
        Me.lblEntryID = New System.Windows.Forms.Label()
        Me.cmdEntry = New System.Windows.Forms.Button()
        Me.cmbScreenSize = New SEComboBoxEx.ComboBoxEx()
        Me.cmbPd = New SEComboBoxEx.ComboBoxEx()
        Me.lblEntryIDTitle = New System.Windows.Forms.Label()
        Me.lblPdTitle = New System.Windows.Forms.Label()
        Me.lblScreenSizeTitle = New System.Windows.Forms.Label()
        Me.fraCF = New System.Windows.Forms.GroupBox()
        Me.lblMaxNum = New System.Windows.Forms.Label()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.txtNumber = New SETextBoxEx.TextBoxEx()
        Me.vsfPaletteList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtPalette00 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette01 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette02 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette03 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette04 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette05 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette06 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette07 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette08 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette09 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette10 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette11 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette12 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette13 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette14 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette15 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette16 = New SETextBoxEx.TextBoxEx()
        Me.txtPalette17 = New SETextBoxEx.TextBoxEx()
        Me.cmbLotManager = New SEComboBoxEx.ComboBoxEx()
        Me.lblLotManagerTitle = New System.Windows.Forms.Label()
        Me.lblPaletteIDTitle = New System.Windows.Forms.Label()
        Me.lblNumberTitle = New System.Windows.Forms.Label()
        Me.lblThrowNum = New System.Windows.Forms.Label()
        Me.lblThrowNumTitle = New System.Windows.Forms.Label()
        Me.lblLotIDTitle = New System.Windows.Forms.Label()
        Me.lblCFLotID = New System.Windows.Forms.Label()
        Me.lblCarrierIDTitle = New System.Windows.Forms.Label()
        Me.fraPart = New System.Windows.Forms.GroupBox()
        Me.cmbPart = New SECmbIchiran.ComboIchiran()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmbBoardThickness = New SEComboBoxEx.ComboBoxEx()
        Me.cmbRework = New SEComboBoxEx.ComboBoxEx()
        Me.vsfPartLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblNowDateTitle = New System.Windows.Forms.Label()
        Me.lblLotCntTitle = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblBoardThicknessTitle = New System.Windows.Forms.Label()
        Me.lblReworkTitle = New System.Windows.Forms.Label()
        Me.lblVenderName = New System.Windows.Forms.Label()
        Me.lblVenderNameTitle = New System.Windows.Forms.Label()
        Me.lblPartTitle = New System.Windows.Forms.Label()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraThrowinWP.SuspendLayout
        Me.fraThrow.SuspendLayout
        Me.fraCF.SuspendLayout
        CType(Me.vsfPaletteList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraPart.SuspendLayout
        CType(Me.vsfPartLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdScrap
        '
        Me.cmdScrap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScrap.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScrap.Location = New System.Drawing.Point(200, 598)
        Me.cmdScrap.Name = "cmdScrap"
        Me.cmdScrap.Size = New System.Drawing.Size(85, 40)
        Me.cmdScrap.TabIndex = 65
        Me.cmdScrap.Text = "在庫不良入力"
        '
        'fraThrowinWP
        '
        Me.fraThrowinWP.Controls.Add(Me.cmbThrowinWP)
        Me.fraThrowinWP.Controls.Add(Me.lblThrowinWPTitle)
        Me.fraThrowinWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraThrowinWP.Location = New System.Drawing.Point(8, 530)
        Me.fraThrowinWP.Name = "fraThrowinWP"
        Me.fraThrowinWP.Size = New System.Drawing.Size(465, 65)
        Me.fraThrowinWP.TabIndex = 8
        Me.fraThrowinWP.TabStop = false
        Me.fraThrowinWP.Text = "投入装置"
        '
        'cmbThrowinWP
        '
        Me.cmbThrowinWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbThrowinWP.ForeColor = System.Drawing.Color.Black
        Me.cmbThrowinWP.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbThrowinWP.GridForeColor = System.Drawing.Color.Black
        Me.cmbThrowinWP.Location = New System.Drawing.Point(8, 36)
        Me.cmbThrowinWP.Name = "cmbThrowinWP"
        Me.cmbThrowinWP.Size = New System.Drawing.Size(267, 22)
        Me.cmbThrowinWP.TabIndex = 8
        Me.cmbThrowinWP.Value = Nothing
        '
        'lblThrowinWPTitle
        '
        Me.lblThrowinWPTitle.BackColor = System.Drawing.Color.Navy
        Me.lblThrowinWPTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowinWPTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowinWPTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblThrowinWPTitle.Location = New System.Drawing.Point(8, 20)
        Me.lblThrowinWPTitle.Name = "lblThrowinWPTitle"
        Me.lblThrowinWPTitle.Size = New System.Drawing.Size(267, 17)
        Me.lblThrowinWPTitle.TabIndex = 64
        Me.lblThrowinWPTitle.Text = "装置"
        Me.lblThrowinWPTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(600, 598)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdClear.TabIndex = 33
        Me.cmdClear.Text = "取　消"
        Me.cmdClear.Visible = false
        '
        'cmdPdChange
        '
        Me.cmdPdChange.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPdChange.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdPdChange.Location = New System.Drawing.Point(696, 598)
        Me.cmdPdChange.Name = "cmdPdChange"
        Me.cmdPdChange.Size = New System.Drawing.Size(85, 40)
        Me.cmdPdChange.TabIndex = 34
        Me.cmdPdChange.Text = "機種変更"
        Me.cmdPdChange.Visible = false
        '
        'cmdAllClear
        '
        Me.cmdAllClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAllClear.Location = New System.Drawing.Point(792, 598)
        Me.cmdAllClear.Name = "cmdAllClear"
        Me.cmdAllClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdAllClear.TabIndex = 35
        Me.cmdAllClear.Text = "全部取消"
        '
        'fraThrow
        '
        Me.fraThrow.Controls.Add(Me.lblPdTitle)
        Me.fraThrow.Controls.Add(Me.lblScreenSizeTitle)
        Me.fraThrow.Controls.Add(Me.lblEntryID)
        Me.fraThrow.Controls.Add(Me.cmdEntry)
        Me.fraThrow.Controls.Add(Me.cmbScreenSize)
        Me.fraThrow.Controls.Add(Me.cmbPd)
        Me.fraThrow.Controls.Add(Me.lblEntryIDTitle)
        Me.fraThrow.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraThrow.Location = New System.Drawing.Point(8, 8)
        Me.fraThrow.Name = "fraThrow"
        Me.fraThrow.Size = New System.Drawing.Size(465, 69)
        Me.fraThrow.TabIndex = 0
        Me.fraThrow.TabStop = false
        Me.fraThrow.Text = "投入予定"
        '
        'lblEntryID
        '
        Me.lblEntryID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEntryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEntryID.Location = New System.Drawing.Point(216, 36)
        Me.lblEntryID.Name = "lblEntryID"
        Me.lblEntryID.Size = New System.Drawing.Size(145, 22)
        Me.lblEntryID.TabIndex = 61
        '
        'cmdEntry
        '
        Me.cmdEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEntry.Location = New System.Drawing.Point(368, 20)
        Me.cmdEntry.Name = "cmdEntry"
        Me.cmdEntry.Size = New System.Drawing.Size(85, 40)
        Me.cmdEntry.TabIndex = 2
        Me.cmdEntry.Text = "エントリ"
        '
        'cmbScreenSize
        '
        Me.cmbScreenSize.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbScreenSize.ForeColor = System.Drawing.Color.Black
        Me.cmbScreenSize.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbScreenSize.GridForeColor = System.Drawing.Color.Black
        Me.cmbScreenSize.Location = New System.Drawing.Point(8, 36)
        Me.cmbScreenSize.Name = "cmbScreenSize"
        Me.cmbScreenSize.Size = New System.Drawing.Size(105, 22)
        Me.cmbScreenSize.TabIndex = 0
        Me.cmbScreenSize.Value = Nothing
        '
        'cmbPd
        '
        Me.cmbPd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPd.ForeColor = System.Drawing.Color.Black
        Me.cmbPd.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPd.GridForeColor = System.Drawing.Color.Black
        Me.cmbPd.Location = New System.Drawing.Point(112, 36)
        Me.cmbPd.Name = "cmbPd"
        Me.cmbPd.Size = New System.Drawing.Size(105, 22)
        Me.cmbPd.TabIndex = 1
        Me.cmbPd.Value = Nothing
        '
        'lblEntryIDTitle
        '
        Me.lblEntryIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEntryIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEntryIDTitle.Location = New System.Drawing.Point(216, 20)
        Me.lblEntryIDTitle.Name = "lblEntryIDTitle"
        Me.lblEntryIDTitle.Size = New System.Drawing.Size(145, 17)
        Me.lblEntryIDTitle.TabIndex = 42
        Me.lblEntryIDTitle.Text = "エントリ"
        Me.lblEntryIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdTitle
        '
        Me.lblPdTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPdTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPdTitle.Location = New System.Drawing.Point(112, 20)
        Me.lblPdTitle.Name = "lblPdTitle"
        Me.lblPdTitle.Size = New System.Drawing.Size(105, 17)
        Me.lblPdTitle.TabIndex = 41
        Me.lblPdTitle.Text = "機種"
        Me.lblPdTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblScreenSizeTitle
        '
        Me.lblScreenSizeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblScreenSizeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScreenSizeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblScreenSizeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblScreenSizeTitle.Location = New System.Drawing.Point(8, 20)
        Me.lblScreenSizeTitle.Name = "lblScreenSizeTitle"
        Me.lblScreenSizeTitle.Size = New System.Drawing.Size(105, 17)
        Me.lblScreenSizeTitle.TabIndex = 40
        Me.lblScreenSizeTitle.Text = "画面サイズ"
        Me.lblScreenSizeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraCF
        '
        Me.fraCF.Controls.Add(Me.lblMaxNum)
        Me.fraCF.Controls.Add(Me.lblTtl13)
        Me.fraCF.Controls.Add(Me.cmdCarrierSelect)
        Me.fraCF.Controls.Add(Me.txtCarrierID)
        Me.fraCF.Controls.Add(Me.txtNumber)
        Me.fraCF.Controls.Add(Me.vsfPaletteList)
        Me.fraCF.Controls.Add(Me.txtPalette00)
        Me.fraCF.Controls.Add(Me.txtPalette01)
        Me.fraCF.Controls.Add(Me.txtPalette02)
        Me.fraCF.Controls.Add(Me.txtPalette03)
        Me.fraCF.Controls.Add(Me.txtPalette04)
        Me.fraCF.Controls.Add(Me.txtPalette05)
        Me.fraCF.Controls.Add(Me.txtPalette06)
        Me.fraCF.Controls.Add(Me.txtPalette07)
        Me.fraCF.Controls.Add(Me.txtPalette08)
        Me.fraCF.Controls.Add(Me.txtPalette09)
        Me.fraCF.Controls.Add(Me.txtPalette10)
        Me.fraCF.Controls.Add(Me.txtPalette11)
        Me.fraCF.Controls.Add(Me.txtPalette12)
        Me.fraCF.Controls.Add(Me.txtPalette13)
        Me.fraCF.Controls.Add(Me.txtPalette14)
        Me.fraCF.Controls.Add(Me.txtPalette15)
        Me.fraCF.Controls.Add(Me.txtPalette16)
        Me.fraCF.Controls.Add(Me.txtPalette17)
        Me.fraCF.Controls.Add(Me.cmbLotManager)
        Me.fraCF.Controls.Add(Me.lblLotManagerTitle)
        Me.fraCF.Controls.Add(Me.lblPaletteIDTitle)
        Me.fraCF.Controls.Add(Me.lblNumberTitle)
        Me.fraCF.Controls.Add(Me.lblThrowNum)
        Me.fraCF.Controls.Add(Me.lblThrowNumTitle)
        Me.fraCF.Controls.Add(Me.lblLotIDTitle)
        Me.fraCF.Controls.Add(Me.lblCFLotID)
        Me.fraCF.Controls.Add(Me.lblCarrierIDTitle)
        Me.fraCF.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCF.Location = New System.Drawing.Point(482, 8)
        Me.fraCF.Name = "fraCF"
        Me.fraCF.Size = New System.Drawing.Size(489, 587)
        Me.fraCF.TabIndex = 9
        Me.fraCF.TabStop = false
        Me.fraCF.Text = "CFロット編成"
        '
        'lblMaxNum
        '
        Me.lblMaxNum.BackColor = System.Drawing.Color.Transparent
        Me.lblMaxNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMaxNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMaxNum.Location = New System.Drawing.Point(345, 39)
        Me.lblMaxNum.Name = "lblMaxNum"
        Me.lblMaxNum.Size = New System.Drawing.Size(37, 16)
        Me.lblMaxNum.TabIndex = 54
        Me.lblMaxNum.Text = "0"
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl13.ForeColor = System.Drawing.Color.White
        Me.lblTtl13.Location = New System.Drawing.Point(344, 36)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(41, 22)
        Me.lblTtl13.TabIndex = 57
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(392, 20)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect.TabIndex = 12
        Me.cmdCarrierSelect.Text = "空ｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'txtCarrierID
        '
        Me.txtCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID.ChrMaxByte = 6
        Me.txtCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID.Location = New System.Drawing.Point(204, 36)
        Me.txtCarrierID.Name = "txtCarrierID"
        Me.txtCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID.SelectedText = ""
        Me.txtCarrierID.Size = New System.Drawing.Size(89, 22)
        Me.txtCarrierID.TabIndex = 10
        '
        'txtNumber
        '
        Me.txtNumber.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtNumber.ChrMaxByte = 3
        Me.txtNumber.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtNumber.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtNumber.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtNumber.Location = New System.Drawing.Point(292, 36)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtNumber.NumMax = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtNumber.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtNumber.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNumber.SelectedText = ""
        Me.txtNumber.Size = New System.Drawing.Size(53, 22)
        Me.txtNumber.TabIndex = 11
        Me.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'vsfPaletteList
        '
        Me.vsfPaletteList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfPaletteList.AllowEditing = false
        Me.vsfPaletteList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfPaletteList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfPaletteList.AutoSearchDelay = 2R
        Me.vsfPaletteList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfPaletteList.ColumnInfo = resources.GetString("vsfPaletteList.ColumnInfo")
        Me.vsfPaletteList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfPaletteList.ExtendLastCol = true
        Me.vsfPaletteList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfPaletteList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfPaletteList.Location = New System.Drawing.Point(8, 72)
        Me.vsfPaletteList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfPaletteList.Name = "vsfPaletteList"
        Me.vsfPaletteList.Rows.Count = 40
        Me.vsfPaletteList.Rows.DefaultSize = 18
        Me.vsfPaletteList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfPaletteList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfPaletteList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfPaletteList.Size = New System.Drawing.Size(381, 454)
        Me.vsfPaletteList.StyleInfo = resources.GetString("vsfPaletteList.StyleInfo")
        Me.vsfPaletteList.TabIndex = 13
        '
        'txtPalette00
        '
        Me.txtPalette00.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette00.ChrMaxByte = 8
        Me.txtPalette00.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette00.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette00.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette00.Location = New System.Drawing.Point(392, 92)
        Me.txtPalette00.Name = "txtPalette00"
        Me.txtPalette00.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette00.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette00.SelectedText = ""
        Me.txtPalette00.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette00.TabIndex = 14
        '
        'txtPalette01
        '
        Me.txtPalette01.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette01.ChrMaxByte = 8
        Me.txtPalette01.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette01.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette01.Location = New System.Drawing.Point(392, 116)
        Me.txtPalette01.Name = "txtPalette01"
        Me.txtPalette01.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette01.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette01.SelectedText = ""
        Me.txtPalette01.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette01.TabIndex = 15
        '
        'txtPalette02
        '
        Me.txtPalette02.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette02.ChrMaxByte = 8
        Me.txtPalette02.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette02.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette02.Location = New System.Drawing.Point(392, 140)
        Me.txtPalette02.Name = "txtPalette02"
        Me.txtPalette02.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette02.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette02.SelectedText = ""
        Me.txtPalette02.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette02.TabIndex = 16
        '
        'txtPalette03
        '
        Me.txtPalette03.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette03.ChrMaxByte = 8
        Me.txtPalette03.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette03.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette03.Location = New System.Drawing.Point(392, 164)
        Me.txtPalette03.Name = "txtPalette03"
        Me.txtPalette03.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette03.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette03.SelectedText = ""
        Me.txtPalette03.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette03.TabIndex = 17
        '
        'txtPalette04
        '
        Me.txtPalette04.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette04.ChrMaxByte = 8
        Me.txtPalette04.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette04.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette04.Location = New System.Drawing.Point(392, 188)
        Me.txtPalette04.Name = "txtPalette04"
        Me.txtPalette04.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette04.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette04.SelectedText = ""
        Me.txtPalette04.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette04.TabIndex = 18
        '
        'txtPalette05
        '
        Me.txtPalette05.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette05.ChrMaxByte = 8
        Me.txtPalette05.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette05.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette05.Location = New System.Drawing.Point(392, 212)
        Me.txtPalette05.Name = "txtPalette05"
        Me.txtPalette05.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette05.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette05.SelectedText = ""
        Me.txtPalette05.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette05.TabIndex = 19
        '
        'txtPalette06
        '
        Me.txtPalette06.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette06.ChrMaxByte = 8
        Me.txtPalette06.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette06.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette06.Location = New System.Drawing.Point(392, 236)
        Me.txtPalette06.Name = "txtPalette06"
        Me.txtPalette06.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette06.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette06.SelectedText = ""
        Me.txtPalette06.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette06.TabIndex = 20
        '
        'txtPalette07
        '
        Me.txtPalette07.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette07.ChrMaxByte = 8
        Me.txtPalette07.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette07.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette07.Location = New System.Drawing.Point(392, 260)
        Me.txtPalette07.Name = "txtPalette07"
        Me.txtPalette07.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette07.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette07.SelectedText = ""
        Me.txtPalette07.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette07.TabIndex = 21
        '
        'txtPalette08
        '
        Me.txtPalette08.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette08.ChrMaxByte = 8
        Me.txtPalette08.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette08.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette08.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette08.Location = New System.Drawing.Point(392, 284)
        Me.txtPalette08.Name = "txtPalette08"
        Me.txtPalette08.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette08.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette08.SelectedText = ""
        Me.txtPalette08.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette08.TabIndex = 22
        '
        'txtPalette09
        '
        Me.txtPalette09.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette09.ChrMaxByte = 8
        Me.txtPalette09.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette09.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette09.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette09.Location = New System.Drawing.Point(392, 308)
        Me.txtPalette09.Name = "txtPalette09"
        Me.txtPalette09.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette09.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette09.SelectedText = ""
        Me.txtPalette09.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette09.TabIndex = 23
        '
        'txtPalette10
        '
        Me.txtPalette10.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette10.ChrMaxByte = 8
        Me.txtPalette10.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette10.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette10.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette10.Location = New System.Drawing.Point(392, 332)
        Me.txtPalette10.Name = "txtPalette10"
        Me.txtPalette10.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette10.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette10.SelectedText = ""
        Me.txtPalette10.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette10.TabIndex = 24
        '
        'txtPalette11
        '
        Me.txtPalette11.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette11.ChrMaxByte = 8
        Me.txtPalette11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette11.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette11.Location = New System.Drawing.Point(392, 356)
        Me.txtPalette11.Name = "txtPalette11"
        Me.txtPalette11.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette11.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette11.SelectedText = ""
        Me.txtPalette11.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette11.TabIndex = 25
        '
        'txtPalette12
        '
        Me.txtPalette12.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette12.ChrMaxByte = 8
        Me.txtPalette12.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette12.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette12.Location = New System.Drawing.Point(392, 380)
        Me.txtPalette12.Name = "txtPalette12"
        Me.txtPalette12.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette12.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette12.SelectedText = ""
        Me.txtPalette12.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette12.TabIndex = 26
        '
        'txtPalette13
        '
        Me.txtPalette13.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette13.ChrMaxByte = 8
        Me.txtPalette13.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette13.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette13.Location = New System.Drawing.Point(392, 404)
        Me.txtPalette13.Name = "txtPalette13"
        Me.txtPalette13.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette13.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette13.SelectedText = ""
        Me.txtPalette13.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette13.TabIndex = 27
        '
        'txtPalette14
        '
        Me.txtPalette14.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette14.ChrMaxByte = 8
        Me.txtPalette14.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette14.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette14.Location = New System.Drawing.Point(392, 428)
        Me.txtPalette14.Name = "txtPalette14"
        Me.txtPalette14.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette14.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette14.SelectedText = ""
        Me.txtPalette14.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette14.TabIndex = 28
        '
        'txtPalette15
        '
        Me.txtPalette15.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette15.ChrMaxByte = 8
        Me.txtPalette15.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette15.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette15.Location = New System.Drawing.Point(392, 452)
        Me.txtPalette15.Name = "txtPalette15"
        Me.txtPalette15.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette15.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette15.SelectedText = ""
        Me.txtPalette15.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette15.TabIndex = 29
        '
        'txtPalette16
        '
        Me.txtPalette16.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette16.ChrMaxByte = 8
        Me.txtPalette16.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette16.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette16.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette16.Location = New System.Drawing.Point(392, 476)
        Me.txtPalette16.Name = "txtPalette16"
        Me.txtPalette16.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette16.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette16.SelectedText = ""
        Me.txtPalette16.Size = New System.Drawing.Size(89, 24)
        Me.txtPalette16.TabIndex = 30
        '
        'txtPalette17
        '
        Me.txtPalette17.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPalette17.ChrMaxByte = 8
        Me.txtPalette17.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPalette17.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtPalette17.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPalette17.Location = New System.Drawing.Point(392, 500)
        Me.txtPalette17.Name = "txtPalette17"
        Me.txtPalette17.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPalette17.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPalette17.SelectedText = ""
        Me.txtPalette17.Size = New System.Drawing.Size(89, 26)
        Me.txtPalette17.TabIndex = 31
        '
        'cmbLotManager
        '
        Me.cmbLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.GridForeColor = System.Drawing.Color.Black
        Me.cmbLotManager.Location = New System.Drawing.Point(8, 36)
        Me.cmbLotManager.Name = "cmbLotManager"
        Me.cmbLotManager.Size = New System.Drawing.Size(189, 22)
        Me.cmbLotManager.TabIndex = 9
        Me.cmbLotManager.Value = Nothing
        '
        'lblLotManagerTitle
        '
        Me.lblLotManagerTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotManagerTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManagerTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManagerTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotManagerTitle.Location = New System.Drawing.Point(8, 20)
        Me.lblLotManagerTitle.Name = "lblLotManagerTitle"
        Me.lblLotManagerTitle.Size = New System.Drawing.Size(189, 17)
        Me.lblLotManagerTitle.TabIndex = 62
        Me.lblLotManagerTitle.Text = "ロット担当"
        Me.lblLotManagerTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPaletteIDTitle
        '
        Me.lblPaletteIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPaletteIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPaletteIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPaletteIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPaletteIDTitle.Location = New System.Drawing.Point(392, 74)
        Me.lblPaletteIDTitle.Name = "lblPaletteIDTitle"
        Me.lblPaletteIDTitle.Size = New System.Drawing.Size(89, 18)
        Me.lblPaletteIDTitle.TabIndex = 60
        Me.lblPaletteIDTitle.Text = "パレットID"
        Me.lblPaletteIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNumberTitle
        '
        Me.lblNumberTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNumberTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumberTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNumberTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNumberTitle.Location = New System.Drawing.Point(292, 20)
        Me.lblNumberTitle.Name = "lblNumberTitle"
        Me.lblNumberTitle.Size = New System.Drawing.Size(93, 17)
        Me.lblNumberTitle.TabIndex = 49
        Me.lblNumberTitle.Text = "詰数"
        Me.lblNumberTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblThrowNum
        '
        Me.lblThrowNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblThrowNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblThrowNum.Location = New System.Drawing.Point(300, 552)
        Me.lblThrowNum.Name = "lblThrowNum"
        Me.lblThrowNum.Size = New System.Drawing.Size(85, 22)
        Me.lblThrowNum.TabIndex = 56
        Me.lblThrowNum.Text = "0"
        Me.lblThrowNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblThrowNumTitle
        '
        Me.lblThrowNumTitle.BackColor = System.Drawing.Color.Navy
        Me.lblThrowNumTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowNumTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowNumTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblThrowNumTitle.Location = New System.Drawing.Point(300, 536)
        Me.lblThrowNumTitle.Name = "lblThrowNumTitle"
        Me.lblThrowNumTitle.Size = New System.Drawing.Size(85, 17)
        Me.lblThrowNumTitle.TabIndex = 55
        Me.lblThrowNumTitle.Text = "投入数"
        Me.lblThrowNumTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotIDTitle
        '
        Me.lblLotIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotIDTitle.Location = New System.Drawing.Point(126, 536)
        Me.lblLotIDTitle.Name = "lblLotIDTitle"
        Me.lblLotIDTitle.Size = New System.Drawing.Size(165, 17)
        Me.lblLotIDTitle.TabIndex = 51
        Me.lblLotIDTitle.Text = "ロットID"
        Me.lblLotIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCFLotID
        '
        Me.lblCFLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCFLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCFLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCFLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCFLotID.Location = New System.Drawing.Point(126, 552)
        Me.lblCFLotID.Name = "lblCFLotID"
        Me.lblCFLotID.Size = New System.Drawing.Size(165, 21)
        Me.lblCFLotID.TabIndex = 50
        Me.lblCFLotID.Text = "ろっとあいでぃ"
        '
        'lblCarrierIDTitle
        '
        Me.lblCarrierIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCarrierIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCarrierIDTitle.Location = New System.Drawing.Point(204, 20)
        Me.lblCarrierIDTitle.Name = "lblCarrierIDTitle"
        Me.lblCarrierIDTitle.Size = New System.Drawing.Size(89, 17)
        Me.lblCarrierIDTitle.TabIndex = 48
        Me.lblCarrierIDTitle.Text = "キャリアID"
        Me.lblCarrierIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraPart
        '
        Me.fraPart.Controls.Add(Me.cmbPart)
        Me.fraPart.Controls.Add(Me.cmdSearch)
        Me.fraPart.Controls.Add(Me.cmbBoardThickness)
        Me.fraPart.Controls.Add(Me.cmbRework)
        Me.fraPart.Controls.Add(Me.vsfPartLotList)
        Me.fraPart.Controls.Add(Me.lblNowDate)
        Me.fraPart.Controls.Add(Me.lblNowDateTitle)
        Me.fraPart.Controls.Add(Me.lblLotCntTitle)
        Me.fraPart.Controls.Add(Me.lblLotCnt)
        Me.fraPart.Controls.Add(Me.lblBoardThicknessTitle)
        Me.fraPart.Controls.Add(Me.lblReworkTitle)
        Me.fraPart.Controls.Add(Me.lblVenderName)
        Me.fraPart.Controls.Add(Me.lblVenderNameTitle)
        Me.fraPart.Controls.Add(Me.lblPartTitle)
        Me.fraPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraPart.Location = New System.Drawing.Point(8, 84)
        Me.fraPart.Name = "fraPart"
        Me.fraPart.Size = New System.Drawing.Size(465, 440)
        Me.fraPart.TabIndex = 3
        Me.fraPart.TabStop = false
        Me.fraPart.Text = "利用部材"
        '
        'cmbPart
        '
        Me.cmbPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridForeColor = System.Drawing.Color.Black
        Me.cmbPart.Location = New System.Drawing.Point(8, 34)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(449, 22)
        Me.cmbPart.TabIndex = 3
        Me.cmbPart.Value = Nothing
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(252, 102)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.Text = "検　索"
        '
        'cmbBoardThickness
        '
        Me.cmbBoardThickness.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbBoardThickness.ForeColor = System.Drawing.Color.Black
        Me.cmbBoardThickness.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbBoardThickness.GridForeColor = System.Drawing.Color.Black
        Me.cmbBoardThickness.Location = New System.Drawing.Point(8, 118)
        Me.cmbBoardThickness.Name = "cmbBoardThickness"
        Me.cmbBoardThickness.Size = New System.Drawing.Size(105, 22)
        Me.cmbBoardThickness.TabIndex = 4
        Me.cmbBoardThickness.Value = Nothing
        '
        'cmbRework
        '
        Me.cmbRework.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRework.ForeColor = System.Drawing.Color.Black
        Me.cmbRework.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRework.GridForeColor = System.Drawing.Color.Black
        Me.cmbRework.Location = New System.Drawing.Point(124, 118)
        Me.cmbRework.Name = "cmbRework"
        Me.cmbRework.Size = New System.Drawing.Size(105, 22)
        Me.cmbRework.TabIndex = 5
        Me.cmbRework.Value = Nothing
        '
        'vsfPartLotList
        '
        Me.vsfPartLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfPartLotList.AllowEditing = false
        Me.vsfPartLotList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfPartLotList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfPartLotList.AutoSearchDelay = 2R
        Me.vsfPartLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfPartLotList.ColumnInfo = resources.GetString("vsfPartLotList.ColumnInfo")
        Me.vsfPartLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfPartLotList.ExtendLastCol = true
        Me.vsfPartLotList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfPartLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfPartLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfPartLotList.Location = New System.Drawing.Point(8, 189)
        Me.vsfPartLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfPartLotList.Name = "vsfPartLotList"
        Me.vsfPartLotList.Rows.Count = 40
        Me.vsfPartLotList.Rows.DefaultSize = 18
        Me.vsfPartLotList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfPartLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfPartLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfPartLotList.Size = New System.Drawing.Size(451, 239)
        Me.vsfPartLotList.StyleInfo = resources.GetString("vsfPartLotList.StyleInfo")
        Me.vsfPartLotList.TabIndex = 7
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(252, 163)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 59
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblNowDateTitle
        '
        Me.lblNowDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNowDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNowDateTitle.Location = New System.Drawing.Point(252, 147)
        Me.lblNowDateTitle.Name = "lblNowDateTitle"
        Me.lblNowDateTitle.Size = New System.Drawing.Size(122, 17)
        Me.lblNowDateTitle.TabIndex = 58
        Me.lblNowDateTitle.Text = "情報取得日時"
        Me.lblNowDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCntTitle
        '
        Me.lblLotCntTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotCntTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCntTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotCntTitle.Location = New System.Drawing.Point(385, 147)
        Me.lblLotCntTitle.Name = "lblLotCntTitle"
        Me.lblLotCntTitle.Size = New System.Drawing.Size(73, 17)
        Me.lblLotCntTitle.TabIndex = 53
        Me.lblLotCntTitle.Text = "該当件数"
        Me.lblLotCntTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(385, 163)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(73, 21)
        Me.lblLotCnt.TabIndex = 52
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBoardThicknessTitle
        '
        Me.lblBoardThicknessTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBoardThicknessTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBoardThicknessTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBoardThicknessTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBoardThicknessTitle.Location = New System.Drawing.Point(8, 102)
        Me.lblBoardThicknessTitle.Name = "lblBoardThicknessTitle"
        Me.lblBoardThicknessTitle.Size = New System.Drawing.Size(105, 17)
        Me.lblBoardThicknessTitle.TabIndex = 47
        Me.lblBoardThicknessTitle.Text = "板厚"
        Me.lblBoardThicknessTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblReworkTitle
        '
        Me.lblReworkTitle.BackColor = System.Drawing.Color.Navy
        Me.lblReworkTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReworkTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReworkTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblReworkTitle.Location = New System.Drawing.Point(124, 102)
        Me.lblReworkTitle.Name = "lblReworkTitle"
        Me.lblReworkTitle.Size = New System.Drawing.Size(105, 17)
        Me.lblReworkTitle.TabIndex = 46
        Me.lblReworkTitle.Text = "リワーク回数"
        Me.lblReworkTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblVenderName
        '
        Me.lblVenderName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblVenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVenderName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVenderName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVenderName.Location = New System.Drawing.Point(8, 76)
        Me.lblVenderName.Name = "lblVenderName"
        Me.lblVenderName.Size = New System.Drawing.Size(449, 21)
        Me.lblVenderName.TabIndex = 45
        Me.lblVenderName.Text = "べんだー"
        '
        'lblVenderNameTitle
        '
        Me.lblVenderNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblVenderNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVenderNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVenderNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblVenderNameTitle.Location = New System.Drawing.Point(8, 60)
        Me.lblVenderNameTitle.Name = "lblVenderNameTitle"
        Me.lblVenderNameTitle.Size = New System.Drawing.Size(449, 17)
        Me.lblVenderNameTitle.TabIndex = 44
        Me.lblVenderNameTitle.Text = "ベンダー"
        Me.lblVenderNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPartTitle
        '
        Me.lblPartTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPartTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPartTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPartTitle.Location = New System.Drawing.Point(8, 18)
        Me.lblPartTitle.Name = "lblPartTitle"
        Me.lblPartTitle.Size = New System.Drawing.Size(449, 17)
        Me.lblPartTitle.TabIndex = 43
        Me.lblPartTitle.Text = "部品"
        Me.lblPartTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 598)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 32
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 598)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 36
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxEN00B0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdScrap)
        Me.Controls.Add(Me.fraThrowinWP)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdPdChange)
        Me.Controls.Add(Me.cmdAllClear)
        Me.Controls.Add(Me.fraThrow)
        Me.Controls.Add(Me.fraCF)
        Me.Controls.Add(Me.fraPart)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00B0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CFロット編成"
        Me.fraThrowinWP.ResumeLayout(false)
        Me.fraThrow.ResumeLayout(false)
        Me.fraCF.ResumeLayout(false)
        CType(Me.vsfPaletteList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraPart.ResumeLayout(false)
        CType(Me.vsfPartLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdScrap As Button
    Friend WithEvents fraThrowinWP As GroupBox
    Friend WithEvents cmbThrowinWP As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblThrowinWPTitle As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdPdChange As Button
    Friend WithEvents cmdAllClear As Button
    Friend WithEvents fraThrow As GroupBox
    Friend WithEvents cmdEntry As Button
    Friend WithEvents cmbScreenSize As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPd As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblEntryID As Label
    Friend WithEvents lblEntryIDTitle As Label
    Friend WithEvents lblPdTitle As Label
    Friend WithEvents lblScreenSizeTitle As Label
    Friend WithEvents fraCF As GroupBox
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtNumber As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfPaletteList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtPalette00 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette01 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette02 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette03 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette04 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette05 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette06 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette07 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette08 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette09 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette10 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette11 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette12 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette13 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette14 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette15 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette16 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPalette17 As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbLotManager As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblLotManagerTitle As Label
    Friend WithEvents lblPaletteIDTitle As Label
    Friend WithEvents lblMaxNum As Label
    Friend WithEvents lblNumberTitle As Label
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblThrowNum As Label
    Friend WithEvents lblThrowNumTitle As Label
    Friend WithEvents lblLotIDTitle As Label
    Friend WithEvents lblCFLotID As Label
    Friend WithEvents lblCarrierIDTitle As Label
    Friend WithEvents fraPart As GroupBox
    Friend WithEvents cmbPart As SECmbIchiran.ComboIchiran
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmbBoardThickness As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbRework As SEComboBoxEx.ComboBoxEx
    Friend WithEvents vsfPartLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblNowDateTitle As Label
    Friend WithEvents lblLotCntTitle As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblBoardThicknessTitle As Label
    Friend WithEvents lblReworkTitle As Label
    Friend WithEvents lblVenderName As Label
    Friend WithEvents lblVenderNameTitle As Label
    Friend WithEvents lblPartTitle As Label
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
End Class
