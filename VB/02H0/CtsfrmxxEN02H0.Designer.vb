<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02H0
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02H0))
        Me.cmdCFHistry = New System.Windows.Forms.Button()
        Me.fraFrame6 = New System.Windows.Forms.GroupBox()
        Me.cmdTxtDownBatch = New System.Windows.Forms.Button()
        Me.cmdTxtUpBatch = New System.Windows.Forms.Button()
        Me.vsfShelf = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfBatch = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraFrame5 = New System.Windows.Forms.GroupBox()
        Me.cmdTxtUptft = New System.Windows.Forms.Button()
        Me.cmdTxtDowntft = New System.Windows.Forms.Button()
        Me.vsfTFT = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraFrame1 = New System.Windows.Forms.GroupBox()
        Me.fraFrame4 = New System.Windows.Forms.GroupBox()
        Me.vsfTP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraFrame3 = New System.Windows.Forms.GroupBox()
        Me.vsfMK = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraFrame2 = New System.Windows.Forms.GroupBox()
        Me.cmdTxtDowncf = New System.Windows.Forms.Button()
        Me.cmdTxtUpcf = New System.Windows.Forms.Button()
        Me.vsfCF = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.txtLot = New SETextBoxEx.TextBoxEx()
        Me.cmbMKLot = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraFrame6.SuspendLayout
        CType(Me.vsfShelf,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfBatch,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraFrame5.SuspendLayout
        CType(Me.vsfTFT,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraFrame1.SuspendLayout
        Me.fraFrame4.SuspendLayout
        CType(Me.vsfTP,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraFrame3.SuspendLayout
        CType(Me.vsfMK,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraFrame2.SuspendLayout
        CType(Me.vsfCF,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCFHistry
        '
        Me.cmdCFHistry.CausesValidation = false
        Me.cmdCFHistry.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCFHistry.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCFHistry.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCFHistry.Location = New System.Drawing.Point(104, 596)
        Me.cmdCFHistry.Name = "cmdCFHistry"
        Me.cmdCFHistry.Size = New System.Drawing.Size(85, 40)
        Me.cmdCFHistry.TabIndex = 7
        Me.cmdCFHistry.Text = "CFロット払出履歴"
        '
        'fraFrame6
        '
        Me.fraFrame6.Controls.Add(Me.cmdTxtDownBatch)
        Me.fraFrame6.Controls.Add(Me.cmdTxtUpBatch)
        Me.fraFrame6.Controls.Add(Me.vsfShelf)
        Me.fraFrame6.Controls.Add(Me.vsfBatch)
        Me.fraFrame6.Location = New System.Drawing.Point(8, 452)
        Me.fraFrame6.Name = "fraFrame6"
        Me.fraFrame6.Size = New System.Drawing.Size(965, 137)
        Me.fraFrame6.TabIndex = 23
        Me.fraFrame6.TabStop = false
        Me.fraFrame6.Text = "バッチ情報"
        '
        'cmdTxtDownBatch
        '
        Me.cmdTxtDownBatch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDownBatch.Location = New System.Drawing.Point(924, 72)
        Me.cmdTxtDownBatch.Name = "cmdTxtDownBatch"
        Me.cmdTxtDownBatch.Size = New System.Drawing.Size(25, 57)
        Me.cmdTxtDownBatch.TabIndex = 27
        Me.cmdTxtDownBatch.Text = "▼"
        '
        'cmdTxtUpBatch
        '
        Me.cmdTxtUpBatch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUpBatch.Location = New System.Drawing.Point(924, 15)
        Me.cmdTxtUpBatch.Name = "cmdTxtUpBatch"
        Me.cmdTxtUpBatch.Size = New System.Drawing.Size(25, 57)
        Me.cmdTxtUpBatch.TabIndex = 26
        Me.cmdTxtUpBatch.Text = "▲"
        '
        'vsfShelf
        '
        Me.vsfShelf.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfShelf.AllowEditing = false
        Me.vsfShelf.AutoResize = true
        Me.vsfShelf.AutoSearchDelay = 2R
        Me.vsfShelf.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfShelf.ColumnInfo = resources.GetString("vsfShelf.ColumnInfo")
        Me.vsfShelf.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfShelf.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfShelf.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfShelf.Location = New System.Drawing.Point(576, 16)
        Me.vsfShelf.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfShelf.Name = "vsfShelf"
        Me.vsfShelf.Rows.Count = 6
        Me.vsfShelf.Rows.DefaultSize = 18
        Me.vsfShelf.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfShelf.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfShelf.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfShelf.Size = New System.Drawing.Size(351, 112)
        Me.vsfShelf.StyleInfo = resources.GetString("vsfShelf.StyleInfo")
        Me.vsfShelf.TabIndex = 25
        '
        'vsfBatch
        '
        Me.vsfBatch.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfBatch.AllowEditing = false
        Me.vsfBatch.AutoResize = true
        Me.vsfBatch.AutoSearchDelay = 2R
        Me.vsfBatch.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfBatch.ColumnInfo = resources.GetString("vsfBatch.ColumnInfo")
        Me.vsfBatch.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfBatch.ExtendLastCol = true
        Me.vsfBatch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfBatch.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfBatch.Location = New System.Drawing.Point(20, 16)
        Me.vsfBatch.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfBatch.Name = "vsfBatch"
        Me.vsfBatch.Rows.Count = 2
        Me.vsfBatch.Rows.DefaultSize = 18
        Me.vsfBatch.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfBatch.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfBatch.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfBatch.Size = New System.Drawing.Size(512, 40)
        Me.vsfBatch.StyleInfo = resources.GetString("vsfBatch.StyleInfo")
        Me.vsfBatch.TabIndex = 24
        '
        'fraFrame5
        '
        Me.fraFrame5.Controls.Add(Me.cmdTxtUptft)
        Me.fraFrame5.Controls.Add(Me.cmdTxtDowntft)
        Me.fraFrame5.Controls.Add(Me.vsfTFT)
        Me.fraFrame5.Location = New System.Drawing.Point(8, 364)
        Me.fraFrame5.Name = "fraFrame5"
        Me.fraFrame5.Size = New System.Drawing.Size(965, 73)
        Me.fraFrame5.TabIndex = 5
        Me.fraFrame5.TabStop = false
        Me.fraFrame5.Text = "TFTロット情報"
        '
        'cmdTxtUptft
        '
        Me.cmdTxtUptft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUptft.Location = New System.Drawing.Point(926, 10)
        Me.cmdTxtUptft.Name = "cmdTxtUptft"
        Me.cmdTxtUptft.Size = New System.Drawing.Size(25, 29)
        Me.cmdTxtUptft.TabIndex = 5
        Me.cmdTxtUptft.Text = "▲"
        '
        'cmdTxtDowntft
        '
        Me.cmdTxtDowntft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDowntft.Location = New System.Drawing.Point(926, 39)
        Me.cmdTxtDowntft.Name = "cmdTxtDowntft"
        Me.cmdTxtDowntft.Size = New System.Drawing.Size(25, 29)
        Me.cmdTxtDowntft.TabIndex = 6
        Me.cmdTxtDowntft.Text = "▼"
        '
        'vsfTFT
        '
        Me.vsfTFT.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfTFT.AllowEditing = false
        Me.vsfTFT.AutoResize = true
        Me.vsfTFT.AutoSearchDelay = 2R
        Me.vsfTFT.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfTFT.ColumnInfo = resources.GetString("vsfTFT.ColumnInfo")
        Me.vsfTFT.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfTFT.ExtendLastCol = true
        Me.vsfTFT.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfTFT.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfTFT.Location = New System.Drawing.Point(20, 16)
        Me.vsfTFT.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfTFT.Name = "vsfTFT"
        Me.vsfTFT.Rows.Count = 2
        Me.vsfTFT.Rows.DefaultSize = 18
        Me.vsfTFT.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfTFT.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfTFT.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfTFT.Size = New System.Drawing.Size(907, 40)
        Me.vsfTFT.StyleInfo = resources.GetString("vsfTFT.StyleInfo")
        Me.vsfTFT.TabIndex = 22
        '
        'fraFrame1
        '
        Me.fraFrame1.Controls.Add(Me.fraFrame4)
        Me.fraFrame1.Controls.Add(Me.fraFrame3)
        Me.fraFrame1.Controls.Add(Me.fraFrame2)
        Me.fraFrame1.Location = New System.Drawing.Point(8, 76)
        Me.fraFrame1.Name = "fraFrame1"
        Me.fraFrame1.Size = New System.Drawing.Size(965, 277)
        Me.fraFrame1.TabIndex = 3
        Me.fraFrame1.TabStop = false
        Me.fraFrame1.Text = "無機対向基板情報"
        '
        'fraFrame4
        '
        Me.fraFrame4.Controls.Add(Me.vsfTP)
        Me.fraFrame4.Location = New System.Drawing.Point(12, 184)
        Me.fraFrame4.Name = "fraFrame4"
        Me.fraFrame4.Size = New System.Drawing.Size(945, 85)
        Me.fraFrame4.TabIndex = 17
        Me.fraFrame4.TabStop = false
        Me.fraFrame4.Text = "TPロット情報"
        '
        'vsfTP
        '
        Me.vsfTP.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfTP.AllowEditing = false
        Me.vsfTP.AutoResize = true
        Me.vsfTP.AutoSearchDelay = 2R
        Me.vsfTP.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfTP.ColumnInfo = resources.GetString("vsfTP.ColumnInfo")
        Me.vsfTP.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfTP.ExtendLastCol = true
        Me.vsfTP.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfTP.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfTP.Location = New System.Drawing.Point(8, 16)
        Me.vsfTP.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfTP.Name = "vsfTP"
        Me.vsfTP.Rows.Count = 3
        Me.vsfTP.Rows.DefaultSize = 18
        Me.vsfTP.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfTP.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfTP.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfTP.Size = New System.Drawing.Size(928, 58)
        Me.vsfTP.StyleInfo = resources.GetString("vsfTP.StyleInfo")
        Me.vsfTP.TabIndex = 20
        '
        'fraFrame3
        '
        Me.fraFrame3.Controls.Add(Me.vsfMK)
        Me.fraFrame3.Location = New System.Drawing.Point(12, 112)
        Me.fraFrame3.Name = "fraFrame3"
        Me.fraFrame3.Size = New System.Drawing.Size(945, 65)
        Me.fraFrame3.TabIndex = 16
        Me.fraFrame3.TabStop = false
        Me.fraFrame3.Text = "MKロット情報"
        '
        'vsfMK
        '
        Me.vsfMK.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMK.AllowEditing = false
        Me.vsfMK.AutoResize = true
        Me.vsfMK.AutoSearchDelay = 2R
        Me.vsfMK.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMK.ColumnInfo = resources.GetString("vsfMK.ColumnInfo")
        Me.vsfMK.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMK.ExtendLastCol = true
        Me.vsfMK.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMK.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMK.Location = New System.Drawing.Point(8, 16)
        Me.vsfMK.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMK.Name = "vsfMK"
        Me.vsfMK.Rows.Count = 2
        Me.vsfMK.Rows.DefaultSize = 18
        Me.vsfMK.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMK.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMK.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMK.Size = New System.Drawing.Size(928, 40)
        Me.vsfMK.StyleInfo = resources.GetString("vsfMK.StyleInfo")
        Me.vsfMK.TabIndex = 19
        '
        'fraFrame2
        '
        Me.fraFrame2.Controls.Add(Me.cmdTxtDowncf)
        Me.fraFrame2.Controls.Add(Me.cmdTxtUpcf)
        Me.fraFrame2.Controls.Add(Me.vsfCF)
        Me.fraFrame2.Location = New System.Drawing.Point(12, 20)
        Me.fraFrame2.Name = "fraFrame2"
        Me.fraFrame2.Size = New System.Drawing.Size(945, 85)
        Me.fraFrame2.TabIndex = 3
        Me.fraFrame2.TabStop = false
        Me.fraFrame2.Text = "CFロット情報"
        '
        'cmdTxtDowncf
        '
        Me.cmdTxtDowncf.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDowncf.Location = New System.Drawing.Point(914, 45)
        Me.cmdTxtDowncf.Name = "cmdTxtDowncf"
        Me.cmdTxtDowncf.Size = New System.Drawing.Size(25, 30)
        Me.cmdTxtDowncf.TabIndex = 4
        Me.cmdTxtDowncf.Text = "▼"
        '
        'cmdTxtUpcf
        '
        Me.cmdTxtUpcf.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUpcf.Location = New System.Drawing.Point(914, 15)
        Me.cmdTxtUpcf.Name = "cmdTxtUpcf"
        Me.cmdTxtUpcf.Size = New System.Drawing.Size(25, 31)
        Me.cmdTxtUpcf.TabIndex = 3
        Me.cmdTxtUpcf.Text = "▲"
        '
        'vsfCF
        '
        Me.vsfCF.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCF.AllowEditing = false
        Me.vsfCF.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfCF.AutoResize = true
        Me.vsfCF.AutoSearchDelay = 2R
        Me.vsfCF.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCF.ColumnInfo = resources.GetString("vsfCF.ColumnInfo")
        Me.vsfCF.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCF.ExtendLastCol = true
        Me.vsfCF.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCF.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCF.Location = New System.Drawing.Point(8, 16)
        Me.vsfCF.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCF.Name = "vsfCF"
        Me.vsfCF.Rows.Count = 3
        Me.vsfCF.Rows.DefaultSize = 18
        Me.vsfCF.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfCF.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCF.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCF.Size = New System.Drawing.Size(907, 58)
        Me.vsfCF.StyleInfo = resources.GetString("vsfCF.StyleInfo")
        Me.vsfCF.TabIndex = 18
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 596)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.Text = "閉じる"
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(125, 22)
        Me.txtCarrier.TabIndex = 0
        '
        'txtLot
        '
        Me.txtLot.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLot.ChrMaxByte = 10
        Me.txtLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLot.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtLot.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLot.Location = New System.Drawing.Point(148, 32)
        Me.txtLot.Name = "txtLot"
        Me.txtLot.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLot.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLot.SelectedText = ""
        Me.txtLot.Size = New System.Drawing.Size(113, 22)
        Me.txtLot.TabIndex = 1
        '
        'cmbMKLot
        '
        Me.cmbMKLot.DirectInput = false
        Me.cmbMKLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMKLot.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMKLot.Location = New System.Drawing.Point(340, 32)
        Me.cmbMKLot.Name = "cmbMKLot"
        Me.cmbMKLot.Size = New System.Drawing.Size(125, 22)
        Me.cmbMKLot.TabIndex = 2
        Me.cmbMKLot.Value = Nothing
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(148, 16)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(173, 17)
        Me.lblTitle1.TabIndex = 12
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblTitle1, "キャリアIDを入力、ﾊﾞｰｺｰﾄﾞ読取または、一覧から取得")
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(16, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle0.TabIndex = 11
        Me.lblTitle0.Text = "キャリアID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.lblTitle0, "キャリアIDを入力、ﾊﾞｰｺｰﾄﾞ読取または、一覧から取得")
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(340, 16)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle2.TabIndex = 13
        Me.lblTitle2.Text = "MKロット"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(261, 32)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(60, 22)
        Me.lblFlowClass.TabIndex = 9
        Me.lblFlowClass.Text = "PR"
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(465, 56)
        Me.lblBack.TabIndex = 10
        '
        'frmxxEN02H0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdCFHistry
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdCFHistry)
        Me.Controls.Add(Me.fraFrame6)
        Me.Controls.Add(Me.fraFrame5)
        Me.Controls.Add(Me.fraFrame1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.txtLot)
        Me.Controls.Add(Me.cmbMKLot)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02H0"
        Me.Text = "無機対向基板紐付/蒸着バッチ情報"
        Me.fraFrame6.ResumeLayout(false)
        CType(Me.vsfShelf,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfBatch,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraFrame5.ResumeLayout(false)
        CType(Me.vsfTFT,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraFrame1.ResumeLayout(false)
        Me.fraFrame4.ResumeLayout(false)
        CType(Me.vsfTP,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraFrame3.ResumeLayout(false)
        CType(Me.vsfMK,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraFrame2.ResumeLayout(false)
        CType(Me.vsfCF,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCFHistry As Button
    Friend WithEvents fraFrame6 As GroupBox
    Friend WithEvents cmdTxtDownBatch As Button
    Friend WithEvents cmdTxtUpBatch As Button
    Friend WithEvents vsfShelf As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfBatch As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraFrame5 As GroupBox
    Friend WithEvents cmdTxtUptft As Button
    Friend WithEvents cmdTxtDowntft As Button
    Friend WithEvents vsfTFT As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraFrame1 As GroupBox
    Friend WithEvents fraFrame4 As GroupBox
    Friend WithEvents vsfTP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraFrame3 As GroupBox
    Friend WithEvents vsfMK As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraFrame2 As GroupBox
    Friend WithEvents cmdTxtDowncf As Button
    Friend WithEvents cmdTxtUpcf As Button
    Friend WithEvents vsfCF As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents txtLot As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbMKLot As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
