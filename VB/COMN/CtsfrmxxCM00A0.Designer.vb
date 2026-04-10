<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00A0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00A0))
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.cmdLotCommentInput = New System.Windows.Forms.Button()
        Me.cmdReworkScrap = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdEnter = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraResin = New System.Windows.Forms.GroupBox()
        Me.vsfResinPalette = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdResinUp = New System.Windows.Forms.Button()
        Me.cmdResinDown = New System.Windows.Forms.Button()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.txtResinLotComment = New SETextBoxEx.TextBoxEx()
        Me.cmbCfArea = New SEComboBoxEx.ComboBoxEx()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.txtResinCarrierID = New SETextBoxEx.TextBoxEx()
        Me.txtResinCarryingCount = New SETextBoxEx.TextBoxEx()
        Me.lblTtl16 = New System.Windows.Forms.Label()
        Me.lblTtl14 = New System.Windows.Forms.Label()
        Me.lblResinCarryingCountDenominator = New System.Windows.Forms.Label()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblMetalLotID = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblMetalProduct = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblMetalRework = New System.Windows.Forms.Label()
        Me.lblMetalPartCode = New System.Windows.Forms.Label()
        Me.lblMetalPartName = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblVenderName = New System.Windows.Forms.Label()
        Me.vsfMetalPalette = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraChip = New System.Windows.Forms.GroupBox()
        Me.lblChipScrapCount = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblChipRemainCount = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblChipReworkCount = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblChipCarryingCount = New System.Windows.Forms.Label()
        Me.lblChipExpenditureCount = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblChipQuantity = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.cmdMetalUp = New System.Windows.Forms.Button()
        Me.cmdMetalDown = New System.Windows.Forms.Button()
        Me.fraMetal = New System.Windows.Forms.GroupBox()
        Me.txtMetalLotComment = New SETextBoxEx.TextBoxEx()
        Me.txtMetalCarrierID = New SETextBoxEx.TextBoxEx()
        CType(Me.vsfResinPalette,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfMetalPalette,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(216, 597)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect.TabIndex = 8
        Me.cmdCarrierSelect.Text = "空ｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdLotCommentInput
        '
        Me.cmdLotCommentInput.Enabled = false
        Me.cmdLotCommentInput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotCommentInput.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotCommentInput.Location = New System.Drawing.Point(312, 597)
        Me.cmdLotCommentInput.Name = "cmdLotCommentInput"
        Me.cmdLotCommentInput.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotCommentInput.TabIndex = 9
        Me.cmdLotCommentInput.Text = "TPAL"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdReworkScrap
        '
        Me.cmdReworkScrap.Enabled = false
        Me.cmdReworkScrap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReworkScrap.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdReworkScrap.Location = New System.Drawing.Point(696, 597)
        Me.cmdReworkScrap.Name = "cmdReworkScrap"
        Me.cmdReworkScrap.Size = New System.Drawing.Size(85, 40)
        Me.cmdReworkScrap.TabIndex = 10
        Me.cmdReworkScrap.Text = "対向基板"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"処置登録"
        '
        'cmdClear
        '
        Me.cmdClear.CausesValidation = false
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(792, 597)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdClear.TabIndex = 11
        Me.cmdClear.Text = "取　消"
        '
        'cmdEnter
        '
        Me.cmdEnter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEnter.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEnter.Location = New System.Drawing.Point(888, 597)
        Me.cmdEnter.Name = "cmdEnter"
        Me.cmdEnter.Size = New System.Drawing.Size(85, 40)
        Me.cmdEnter.TabIndex = 7
        Me.cmdEnter.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 16
        Me.cmdClose.Text = "閉じる"
        '
        'fraResin
        '
        Me.fraResin.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraResin.Location = New System.Drawing.Point(8, 400)
        Me.fraResin.Name = "fraResin"
        Me.fraResin.Size = New System.Drawing.Size(965, 193)
        Me.fraResin.TabIndex = 21
        Me.fraResin.TabStop = false
        Me.fraResin.Text = "樹脂パレット（TPAL用カセット）"
        '
        'vsfResinPalette
        '
        Me.vsfResinPalette.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfResinPalette.AllowEditing = false
        Me.vsfResinPalette.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfResinPalette.AutoResize = true
        Me.vsfResinPalette.AutoSearchDelay = 2R
        Me.vsfResinPalette.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfResinPalette.ColumnInfo = resources.GetString("vsfResinPalette.ColumnInfo")
        Me.vsfResinPalette.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfResinPalette.ExtendLastCol = true
        Me.vsfResinPalette.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfResinPalette.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfResinPalette.Location = New System.Drawing.Point(516, 416)
        Me.vsfResinPalette.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfResinPalette.Name = "vsfResinPalette"
        Me.vsfResinPalette.Rows.DefaultSize = 18
        Me.vsfResinPalette.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfResinPalette.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfResinPalette.Size = New System.Drawing.Size(452, 164)
        Me.vsfResinPalette.StyleInfo = resources.GetString("vsfResinPalette.StyleInfo")
        Me.vsfResinPalette.TabIndex = 6
        Me.vsfResinPalette.TabStop = false
        '
        'cmdResinUp
        '
        Me.cmdResinUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdResinUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdResinUp.Location = New System.Drawing.Point(369, 467)
        Me.cmdResinUp.Name = "cmdResinUp"
        Me.cmdResinUp.Size = New System.Drawing.Size(25, 59)
        Me.cmdResinUp.TabIndex = 14
        Me.cmdResinUp.Text = "▲"
        '
        'cmdResinDown
        '
        Me.cmdResinDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdResinDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdResinDown.Location = New System.Drawing.Point(369, 528)
        Me.cmdResinDown.Name = "cmdResinDown"
        Me.cmdResinDown.Size = New System.Drawing.Size(25, 58)
        Me.cmdResinDown.TabIndex = 15
        Me.cmdResinDown.Text = "▼"
        '
        'cmdRemove
        '
        Me.cmdRemove.Enabled = false
        Me.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRemove.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRemove.Location = New System.Drawing.Point(412, 512)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(85, 40)
        Me.cmdRemove.TabIndex = 5
        Me.cmdRemove.Text = "<"
        '
        'cmdMove
        '
        Me.cmdMove.Enabled = false
        Me.cmdMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMove.Location = New System.Drawing.Point(412, 448)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.Size = New System.Drawing.Size(85, 40)
        Me.cmdMove.TabIndex = 4
        Me.cmdMove.Text = ">"
        '
        'txtResinLotComment
        '
        Me.txtResinLotComment.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtResinLotComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtResinLotComment.ChrMaxByte = 0
        Me.txtResinLotComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtResinLotComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtResinLotComment.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtResinLotComment.GotHighLight = false
        Me.txtResinLotComment.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtResinLotComment.Location = New System.Drawing.Point(16, 484)
        Me.txtResinLotComment.MultiLineEx = true
        Me.txtResinLotComment.Name = "txtResinLotComment"
        Me.txtResinLotComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtResinLotComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtResinLotComment.SelectedText = ""
        Me.txtResinLotComment.Size = New System.Drawing.Size(353, 101)
        Me.txtResinLotComment.TabIndex = 49
        '
        'cmbCfArea
        '
        Me.cmbCfArea.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid
        Me.cmbCfArea.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCfArea.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCfArea.Location = New System.Drawing.Point(272, 440)
        Me.cmbCfArea.Name = "cmbCfArea"
        Me.cmbCfArea.Size = New System.Drawing.Size(121, 22)
        Me.cmbCfArea.TabIndex = 3
        Me.cmbCfArea.Value = Nothing
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(16, 468)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(353, 17)
        Me.lblTtl15.TabIndex = 53
        Me.lblTtl15.Text = "ロットコメント"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtResinCarrierID
        '
        Me.txtResinCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtResinCarrierID.ChrMaxByte = 10
        Me.txtResinCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtResinCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtResinCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtResinCarrierID.Location = New System.Drawing.Point(16, 440)
        Me.txtResinCarrierID.Name = "txtResinCarrierID"
        Me.txtResinCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtResinCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtResinCarrierID.SelectedText = ""
        Me.txtResinCarrierID.Size = New System.Drawing.Size(121, 22)
        Me.txtResinCarrierID.TabIndex = 1
        '
        'txtResinCarryingCount
        '
        Me.txtResinCarryingCount.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtResinCarryingCount.ChrMaxByte = 5
        Me.txtResinCarryingCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtResinCarryingCount.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtResinCarryingCount.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtResinCarryingCount.Location = New System.Drawing.Point(144, 440)
        Me.txtResinCarryingCount.Name = "txtResinCarryingCount"
        Me.txtResinCarryingCount.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtResinCarryingCount.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtResinCarryingCount.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtResinCarryingCount.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtResinCarryingCount.SelectedText = ""
        Me.txtResinCarryingCount.Size = New System.Drawing.Size(60, 22)
        Me.txtResinCarryingCount.TabIndex = 2
        Me.txtResinCarryingCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTtl16
        '
        Me.lblTtl16.BackColor = System.Drawing.Color.Navy
        Me.lblTtl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl16.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl16.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl16.Location = New System.Drawing.Point(272, 424)
        Me.lblTtl16.Name = "lblTtl16"
        Me.lblTtl16.Size = New System.Drawing.Size(121, 17)
        Me.lblTtl16.TabIndex = 54
        Me.lblTtl16.Text = "左右区別"
        Me.lblTtl16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl14
        '
        Me.lblTtl14.BackColor = System.Drawing.Color.Navy
        Me.lblTtl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl14.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl14.Location = New System.Drawing.Point(144, 424)
        Me.lblTtl14.Name = "lblTtl14"
        Me.lblTtl14.Size = New System.Drawing.Size(120, 17)
        Me.lblTtl14.TabIndex = 51
        Me.lblTtl14.Text = "詰め数"
        Me.lblTtl14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblResinCarryingCountDenominator
        '
        Me.lblResinCarryingCountDenominator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblResinCarryingCountDenominator.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblResinCarryingCountDenominator.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblResinCarryingCountDenominator.Location = New System.Drawing.Point(204, 440)
        Me.lblResinCarryingCountDenominator.Name = "lblResinCarryingCountDenominator"
        Me.lblResinCarryingCountDenominator.Size = New System.Drawing.Size(60, 22)
        Me.lblResinCarryingCountDenominator.TabIndex = 50
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.Color.Navy
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl13.Location = New System.Drawing.Point(16, 424)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(121, 17)
        Me.lblTtl13.TabIndex = 52
        Me.lblTtl13.Text = "キャリアID"
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(16, 176)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(748, 17)
        Me.lblTtl6.TabIndex = 32
        Me.lblTtl6.Text = "ロットコメント"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(16, 32)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(186, 17)
        Me.lblTtl0.TabIndex = 19
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(16, 80)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(768, 17)
        Me.lblTtl4.TabIndex = 20
        Me.lblTtl4.Text = "部品"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(210, 32)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(186, 17)
        Me.lblTtl1.TabIndex = 22
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMetalLotID
        '
        Me.lblMetalLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMetalLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMetalLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMetalLotID.Location = New System.Drawing.Point(210, 48)
        Me.lblMetalLotID.Name = "lblMetalLotID"
        Me.lblMetalLotID.Size = New System.Drawing.Size(186, 22)
        Me.lblMetalLotID.TabIndex = 23
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(404, 32)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(186, 17)
        Me.lblTtl2.TabIndex = 24
        Me.lblTtl2.Text = "機種"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMetalProduct
        '
        Me.lblMetalProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMetalProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMetalProduct.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMetalProduct.Location = New System.Drawing.Point(404, 47)
        Me.lblMetalProduct.Name = "lblMetalProduct"
        Me.lblMetalProduct.Size = New System.Drawing.Size(186, 22)
        Me.lblMetalProduct.TabIndex = 25
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(598, 32)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(186, 17)
        Me.lblTtl3.TabIndex = 26
        Me.lblTtl3.Text = "リワーク回数"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMetalRework
        '
        Me.lblMetalRework.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMetalRework.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMetalRework.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMetalRework.Location = New System.Drawing.Point(598, 48)
        Me.lblMetalRework.Name = "lblMetalRework"
        Me.lblMetalRework.Size = New System.Drawing.Size(186, 22)
        Me.lblMetalRework.TabIndex = 27
        Me.lblMetalRework.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMetalPartCode
        '
        Me.lblMetalPartCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMetalPartCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMetalPartCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMetalPartCode.Location = New System.Drawing.Point(16, 96)
        Me.lblMetalPartCode.Name = "lblMetalPartCode"
        Me.lblMetalPartCode.Size = New System.Drawing.Size(185, 22)
        Me.lblMetalPartCode.TabIndex = 28
        '
        'lblMetalPartName
        '
        Me.lblMetalPartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMetalPartName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMetalPartName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMetalPartName.Location = New System.Drawing.Point(200, 96)
        Me.lblMetalPartName.Name = "lblMetalPartName"
        Me.lblMetalPartName.Size = New System.Drawing.Size(584, 22)
        Me.lblMetalPartName.TabIndex = 29
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(16, 128)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(768, 17)
        Me.lblTtl5.TabIndex = 30
        Me.lblTtl5.Text = "ベンダー"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblVenderName
        '
        Me.lblVenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVenderName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVenderName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVenderName.Location = New System.Drawing.Point(16, 144)
        Me.lblVenderName.Name = "lblVenderName"
        Me.lblVenderName.Size = New System.Drawing.Size(768, 22)
        Me.lblVenderName.TabIndex = 31
        '
        'vsfMetalPalette
        '
        Me.vsfMetalPalette.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMetalPalette.AllowEditing = false
        Me.vsfMetalPalette.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMetalPalette.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMetalPalette.AutoResize = true
        Me.vsfMetalPalette.AutoSearchDelay = 2R
        Me.vsfMetalPalette.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMetalPalette.ColumnInfo = resources.GetString("vsfMetalPalette.ColumnInfo")
        Me.vsfMetalPalette.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMetalPalette.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMetalPalette.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMetalPalette.Location = New System.Drawing.Point(792, 32)
        Me.vsfMetalPalette.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMetalPalette.Name = "vsfMetalPalette"
        Me.vsfMetalPalette.Rows.DefaultSize = 18
        Me.vsfMetalPalette.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMetalPalette.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMetalPalette.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMetalPalette.Size = New System.Drawing.Size(169, 348)
        Me.vsfMetalPalette.StyleInfo = resources.GetString("vsfMetalPalette.StyleInfo")
        Me.vsfMetalPalette.TabIndex = 17
        Me.vsfMetalPalette.TabStop = false
        '
        'fraChip
        '
        Me.fraChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraChip.Location = New System.Drawing.Point(16, 296)
        Me.fraChip.Name = "fraChip"
        Me.fraChip.Size = New System.Drawing.Size(769, 81)
        Me.fraChip.TabIndex = 33
        Me.fraChip.TabStop = false
        Me.fraChip.Text = "チップ情報"
        '
        'lblChipScrapCount
        '
        Me.lblChipScrapCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipScrapCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipScrapCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipScrapCount.Location = New System.Drawing.Point(360, 336)
        Me.lblChipScrapCount.Name = "lblChipScrapCount"
        Me.lblChipScrapCount.Size = New System.Drawing.Size(93, 22)
        Me.lblChipScrapCount.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label13.Location = New System.Drawing.Point(552, 328)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 33)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = ")="
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(600, 320)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(93, 17)
        Me.lblTtl12.TabIndex = 45
        Me.lblTtl12.Text = "残数"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipRemainCount
        '
        Me.lblChipRemainCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipRemainCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipRemainCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipRemainCount.Location = New System.Drawing.Point(600, 336)
        Me.lblChipRemainCount.Name = "lblChipRemainCount"
        Me.lblChipRemainCount.Size = New System.Drawing.Size(93, 22)
        Me.lblChipRemainCount.TabIndex = 44
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(452, 320)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(93, 17)
        Me.lblTtl11.TabIndex = 43
        Me.lblTtl11.Text = "リワーク数"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipReworkCount
        '
        Me.lblChipReworkCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipReworkCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipReworkCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipReworkCount.Location = New System.Drawing.Point(452, 336)
        Me.lblChipReworkCount.Name = "lblChipReworkCount"
        Me.lblChipReworkCount.Size = New System.Drawing.Size(93, 22)
        Me.lblChipReworkCount.TabIndex = 42
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(360, 320)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(93, 17)
        Me.lblTtl10.TabIndex = 41
        Me.lblTtl10.Text = "不良数"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(268, 320)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(93, 17)
        Me.lblTtl9.TabIndex = 39
        Me.lblTtl9.Text = "払出数"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipCarryingCount
        '
        Me.lblChipCarryingCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipCarryingCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipCarryingCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipCarryingCount.Location = New System.Drawing.Point(176, 336)
        Me.lblChipCarryingCount.Name = "lblChipCarryingCount"
        Me.lblChipCarryingCount.Size = New System.Drawing.Size(93, 22)
        Me.lblChipCarryingCount.TabIndex = 36
        '
        'lblChipExpenditureCount
        '
        Me.lblChipExpenditureCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipExpenditureCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipExpenditureCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipExpenditureCount.Location = New System.Drawing.Point(268, 336)
        Me.lblChipExpenditureCount.Name = "lblChipExpenditureCount"
        Me.lblChipExpenditureCount.Size = New System.Drawing.Size(93, 22)
        Me.lblChipExpenditureCount.TabIndex = 38
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(176, 320)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(93, 17)
        Me.lblTtl8.TabIndex = 37
        Me.lblTtl8.Text = "既詰数"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label12.Location = New System.Drawing.Point(128, 328)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 33)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "-("
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipQuantity
        '
        Me.lblChipQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipQuantity.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipQuantity.Location = New System.Drawing.Point(24, 336)
        Me.lblChipQuantity.Name = "lblChipQuantity"
        Me.lblChipQuantity.Size = New System.Drawing.Size(93, 22)
        Me.lblChipQuantity.TabIndex = 34
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(24, 320)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(93, 17)
        Me.lblTtl7.TabIndex = 35
        Me.lblTtl7.Text = "受入数"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdMetalUp
        '
        Me.cmdMetalUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMetalUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMetalUp.Location = New System.Drawing.Point(764, 175)
        Me.cmdMetalUp.Name = "cmdMetalUp"
        Me.cmdMetalUp.Size = New System.Drawing.Size(20, 59)
        Me.cmdMetalUp.TabIndex = 12
        Me.cmdMetalUp.Text = "▲"
        '
        'cmdMetalDown
        '
        Me.cmdMetalDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMetalDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMetalDown.Location = New System.Drawing.Point(764, 236)
        Me.cmdMetalDown.Name = "cmdMetalDown"
        Me.cmdMetalDown.Size = New System.Drawing.Size(20, 58)
        Me.cmdMetalDown.TabIndex = 13
        Me.cmdMetalDown.Text = "▼"
        '
        'fraMetal
        '
        Me.fraMetal.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraMetal.Location = New System.Drawing.Point(8, 8)
        Me.fraMetal.Name = "fraMetal"
        Me.fraMetal.Size = New System.Drawing.Size(965, 385)
        Me.fraMetal.TabIndex = 18
        Me.fraMetal.TabStop = false
        Me.fraMetal.Text = "金属パレット"
        '
        'txtMetalLotComment
        '
        Me.txtMetalLotComment.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtMetalLotComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtMetalLotComment.ChrMaxByte = 0
        Me.txtMetalLotComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtMetalLotComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtMetalLotComment.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtMetalLotComment.GotHighLight = false
        Me.txtMetalLotComment.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMetalLotComment.Location = New System.Drawing.Point(16, 192)
        Me.txtMetalLotComment.MultiLineEx = true
        Me.txtMetalLotComment.Name = "txtMetalLotComment"
        Me.txtMetalLotComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtMetalLotComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMetalLotComment.SelectedText = ""
        Me.txtMetalLotComment.Size = New System.Drawing.Size(748, 101)
        Me.txtMetalLotComment.TabIndex = 48
        '
        'txtMetalCarrierID
        '
        Me.txtMetalCarrierID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtMetalCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtMetalCarrierID.ChrMaxByte = 10
        Me.txtMetalCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtMetalCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
        Me.txtMetalCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMetalCarrierID.Location = New System.Drawing.Point(16, 48)
        Me.txtMetalCarrierID.Name = "txtMetalCarrierID"
        Me.txtMetalCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtMetalCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMetalCarrierID.SelectedText = ""
        Me.txtMetalCarrierID.Size = New System.Drawing.Size(186, 22)
        Me.txtMetalCarrierID.TabIndex = 0
        '
        'frmxxCM00A0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.vsfResinPalette)
        Me.Controls.Add(Me.cmdResinUp)
        Me.Controls.Add(Me.cmdResinDown)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdMove)
        Me.Controls.Add(Me.txtResinLotComment)
        Me.Controls.Add(Me.cmbCfArea)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.txtResinCarrierID)
        Me.Controls.Add(Me.txtResinCarryingCount)
        Me.Controls.Add(Me.lblTtl16)
        Me.Controls.Add(Me.lblTtl14)
        Me.Controls.Add(Me.lblResinCarryingCountDenominator)
        Me.Controls.Add(Me.lblTtl13)
        Me.Controls.Add(Me.lblChipScrapCount)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblTtl12)
        Me.Controls.Add(Me.lblChipRemainCount)
        Me.Controls.Add(Me.lblTtl11)
        Me.Controls.Add(Me.lblChipReworkCount)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblChipCarryingCount)
        Me.Controls.Add(Me.lblChipExpenditureCount)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblChipQuantity)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.fraChip)
        Me.Controls.Add(Me.cmdMetalDown)
        Me.Controls.Add(Me.cmdMetalUp)
        Me.Controls.Add(Me.vsfMetalPalette)
        Me.Controls.Add(Me.lblMetalPartName)
        Me.Controls.Add(Me.lblMetalPartCode)
        Me.Controls.Add(Me.txtMetalLotComment)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblVenderName)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblMetalRework)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblMetalProduct)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblMetalLotID)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.txtMetalCarrierID)
        Me.Controls.Add(Me.cmdCarrierSelect)
        Me.Controls.Add(Me.cmdLotCommentInput)
        Me.Controls.Add(Me.cmdReworkScrap)
        Me.Controls.Add(Me.fraMetal)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdEnter)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraResin)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00A0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CFKI作業終了"
        CType(Me.vsfResinPalette,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfMetalPalette,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents cmdLotCommentInput As Button
    Friend WithEvents cmdReworkScrap As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdEnter As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraResin As GroupBox
    Friend WithEvents cmbCfArea As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmdResinUp As Button
    Friend WithEvents cmdResinDown As Button
    Friend WithEvents cmdRemove As Button
    Friend WithEvents cmdMove As Button
    Friend WithEvents vsfResinPalette As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtResinLotComment As SETextBoxEx.TextBoxEx
    Friend WithEvents txtResinCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtResinCarryingCount As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl16 As Label
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblTtl14 As Label
    Friend WithEvents lblResinCarryingCountDenominator As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblMetalLotID As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblMetalProduct As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblMetalRework As Label
    Friend WithEvents lblMetalPartCode As Label
    Friend WithEvents lblMetalPartName As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblVenderName As Label
    Friend WithEvents vsfMetalPalette As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraChip As GroupBox
    Friend WithEvents lblChipCarryingCount As Label
    Friend WithEvents lblChipExpenditureCount As Label
    Friend WithEvents lblChipScrapCount As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblChipRemainCount As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblChipReworkCount As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblChipQuantity As Label
    Friend WithEvents cmdMetalUp As Button
    Friend WithEvents cmdMetalDown As Button
    Friend WithEvents fraMetal As GroupBox
    Friend WithEvents txtMetalCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtMetalLotComment As SETextBoxEx.TextBoxEx
End Class
