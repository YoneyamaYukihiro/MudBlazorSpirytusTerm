<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02T0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02T0))
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.fraClass = New System.Windows.Forms.GroupBox()
        Me.optClass4 = New System.Windows.Forms.RadioButton()
        Me.optClass3 = New System.Windows.Forms.RadioButton()
        Me.optClass2 = New System.Windows.Forms.RadioButton()
        Me.optClass1 = New System.Windows.Forms.RadioButton()
        Me.optClass0 = New System.Windows.Forms.RadioButton()
        Me.cmdCarrierClean = New System.Windows.Forms.Button()
        Me.cmdScanClear = New System.Windows.Forms.Button()
        Me.cmdATrayClear = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.vsfSlot = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtACarrierId = New SETextBoxEx.TextBoxEx()
        Me.txtATrayId = New SETextBoxEx.TextBoxEx()
        Me.vsfInvList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblCleanFlag = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblEmptyFlag = New System.Windows.Forms.Label()
        Me.lblLot = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblCleanCount = New System.Windows.Forms.Label()
        Me.lblALDLimit = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblALDCount = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.fraClass.SuspendLayout
        CType(Me.vsfSlot,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfInvList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(800, 16)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdCarrierSelect.TabIndex = 1
        Me.cmdCarrierSelect.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'fraClass
        '
        Me.fraClass.Controls.Add(Me.optClass4)
        Me.fraClass.Controls.Add(Me.optClass3)
        Me.fraClass.Controls.Add(Me.optClass2)
        Me.fraClass.Controls.Add(Me.optClass1)
        Me.fraClass.Controls.Add(Me.optClass0)
        Me.fraClass.Location = New System.Drawing.Point(16, 64)
        Me.fraClass.Name = "fraClass"
        Me.fraClass.Size = New System.Drawing.Size(561, 65)
        Me.fraClass.TabIndex = 2
        Me.fraClass.TabStop = false
        '
        'optClass4
        '
        Me.optClass4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optClass4.Location = New System.Drawing.Point(392, 10)
        Me.optClass4.Name = "optClass4"
        Me.optClass4.Size = New System.Drawing.Size(153, 25)
        Me.optClass4.TabIndex = 7
        Me.optClass4.Text = "品確、モニター"
        '
        'optClass3
        '
        Me.optClass3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optClass3.Location = New System.Drawing.Point(200, 36)
        Me.optClass3.Name = "optClass3"
        Me.optClass3.Size = New System.Drawing.Size(177, 25)
        Me.optClass3.TabIndex = 6
        Me.optClass3.Text = "ダミー(モニター有)"
        '
        'optClass2
        '
        Me.optClass2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optClass2.Location = New System.Drawing.Point(200, 10)
        Me.optClass2.Name = "optClass2"
        Me.optClass2.Size = New System.Drawing.Size(177, 25)
        Me.optClass2.TabIndex = 5
        Me.optClass2.Text = "ダミー(モニター無)"
        '
        'optClass1
        '
        Me.optClass1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optClass1.Location = New System.Drawing.Point(16, 36)
        Me.optClass1.Name = "optClass1"
        Me.optClass1.Size = New System.Drawing.Size(169, 25)
        Me.optClass1.TabIndex = 4
        Me.optClass1.Text = "製品(モニター有)"
        '
        'optClass0
        '
        Me.optClass0.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optClass0.Location = New System.Drawing.Point(16, 10)
        Me.optClass0.Name = "optClass0"
        Me.optClass0.Size = New System.Drawing.Size(169, 25)
        Me.optClass0.TabIndex = 3
        Me.optClass0.Text = "製品(モニター無)"
        '
        'cmdCarrierClean
        '
        Me.cmdCarrierClean.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierClean.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierClean.Location = New System.Drawing.Point(232, 582)
        Me.cmdCarrierClean.Name = "cmdCarrierClean"
        Me.cmdCarrierClean.Size = New System.Drawing.Size(105, 57)
        Me.cmdCarrierClean.TabIndex = 12
        Me.cmdCarrierClean.Text = "Aキャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"洗浄"
        '
        'cmdScanClear
        '
        Me.cmdScanClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScanClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScanClear.Location = New System.Drawing.Point(800, 76)
        Me.cmdScanClear.Name = "cmdScanClear"
        Me.cmdScanClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdScanClear.TabIndex = 14
        Me.cmdScanClear.Text = "SCAN"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"全取消"
        '
        'cmdATrayClear
        '
        Me.cmdATrayClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdATrayClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdATrayClear.Location = New System.Drawing.Point(760, 582)
        Me.cmdATrayClear.Name = "cmdATrayClear"
        Me.cmdATrayClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdATrayClear.TabIndex = 13
        Me.cmdATrayClear.Text = "Aトレイ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"セット解除"
        '
        'cmdClose
        '
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 582)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 11
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 582)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 10
        Me.cmdRegist.Text = "Aトレイ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"セット確定"
        '
        'vsfSlot
        '
        Me.vsfSlot.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlot.AllowEditing = false
        Me.vsfSlot.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlot.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlot.AutoSearchDelay = 2R
        Me.vsfSlot.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlot.ColumnInfo = resources.GetString("vsfSlot.ColumnInfo")
        Me.vsfSlot.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlot.ExtendLastCol = true
        Me.vsfSlot.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlot.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlot.Location = New System.Drawing.Point(8, 148)
        Me.vsfSlot.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlot.Name = "vsfSlot"
        Me.vsfSlot.Rows.Count = 16
        Me.vsfSlot.Rows.DefaultSize = 18
        Me.vsfSlot.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlot.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlot.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlot.Size = New System.Drawing.Size(965, 183)
        Me.vsfSlot.StyleInfo = resources.GetString("vsfSlot.StyleInfo")
        Me.vsfSlot.TabIndex = 9
        '
        'txtACarrierId
        '
        Me.txtACarrierId.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtACarrierId.ChrMaxByte = 6
        Me.txtACarrierId.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtACarrierId.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtACarrierId.Location = New System.Drawing.Point(16, 32)
        Me.txtACarrierId.Name = "txtACarrierId"
        Me.txtACarrierId.NgChr = "'"
        Me.txtACarrierId.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtACarrierId.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtACarrierId.SelectedText = ""
        Me.txtACarrierId.Size = New System.Drawing.Size(185, 30)
        Me.txtACarrierId.TabIndex = 0
        '
        'txtATrayId
        '
        Me.txtATrayId.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtATrayId.ChrMaxByte = 10
        Me.txtATrayId.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtATrayId.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtATrayId.Location = New System.Drawing.Point(592, 92)
        Me.txtATrayId.Name = "txtATrayId"
        Me.txtATrayId.NgChr = "'"
        Me.txtATrayId.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtATrayId.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtATrayId.SelectedText = ""
        Me.txtATrayId.Size = New System.Drawing.Size(201, 30)
        Me.txtATrayId.TabIndex = 8
        '
        'vsfInvList
        '
        Me.vsfInvList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfInvList.AllowEditing = false
        Me.vsfInvList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfInvList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfInvList.AutoSearchDelay = 2R
        Me.vsfInvList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfInvList.ColumnInfo = resources.GetString("vsfInvList.ColumnInfo")
        Me.vsfInvList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfInvList.ExtendLastCol = true
        Me.vsfInvList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfInvList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfInvList.Location = New System.Drawing.Point(8, 344)
        Me.vsfInvList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfInvList.Name = "vsfInvList"
        Me.vsfInvList.Rows.Count = 10
        Me.vsfInvList.Rows.DefaultSize = 18
        Me.vsfInvList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfInvList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfInvList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfInvList.Size = New System.Drawing.Size(965, 231)
        Me.vsfInvList.StyleInfo = resources.GetString("vsfInvList.StyleInfo")
        Me.vsfInvList.TabIndex = 30
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(592, 76)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(201, 17)
        Me.lblTtl7.TabIndex = 29
        Me.lblTtl7.Text = "AトレイID　SCAN"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCleanFlag
        '
        Me.lblCleanFlag.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCleanFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCleanFlag.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCleanFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCleanFlag.Location = New System.Drawing.Point(504, 32)
        Me.lblCleanFlag.Name = "lblCleanFlag"
        Me.lblCleanFlag.Size = New System.Drawing.Size(97, 25)
        Me.lblCleanFlag.TabIndex = 24
        Me.lblCleanFlag.Text = "不要"
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(504, 16)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl6.TabIndex = 23
        Me.lblTtl6.Text = "洗浄"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEmptyFlag
        '
        Me.lblEmptyFlag.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEmptyFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmptyFlag.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEmptyFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEmptyFlag.Location = New System.Drawing.Point(216, 32)
        Me.lblEmptyFlag.Name = "lblEmptyFlag"
        Me.lblEmptyFlag.Size = New System.Drawing.Size(97, 25)
        Me.lblEmptyFlag.TabIndex = 18
        Me.lblEmptyFlag.Text = "空"
        '
        'lblLot
        '
        Me.lblLot.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLot.Location = New System.Drawing.Point(696, 32)
        Me.lblLot.Name = "lblLot"
        Me.lblLot.Size = New System.Drawing.Size(97, 25)
        Me.lblLot.TabIndex = 28
        Me.lblLot.Text = "なし"
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(696, 16)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl5.TabIndex = 27
        Me.lblTtl5.Text = "ロット割当"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCleanCount
        '
        Me.lblCleanCount.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCleanCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCleanCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCleanCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCleanCount.Location = New System.Drawing.Point(600, 32)
        Me.lblCleanCount.Name = "lblCleanCount"
        Me.lblCleanCount.Size = New System.Drawing.Size(97, 25)
        Me.lblCleanCount.TabIndex = 26
        Me.lblCleanCount.Text = "2"
        Me.lblCleanCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblALDLimit
        '
        Me.lblALDLimit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblALDLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblALDLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblALDLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblALDLimit.Location = New System.Drawing.Point(408, 32)
        Me.lblALDLimit.Name = "lblALDLimit"
        Me.lblALDLimit.Size = New System.Drawing.Size(97, 25)
        Me.lblALDLimit.TabIndex = 22
        Me.lblALDLimit.Text = "2"
        Me.lblALDLimit.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(600, 16)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl4.TabIndex = 25
        Me.lblTtl4.Text = "洗浄回数"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(408, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl3.TabIndex = 21
        Me.lblTtl3.Text = "上限回数"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl0.TabIndex = 16
        Me.lblTtl0.Text = "AキャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl1.TabIndex = 17
        Me.lblTtl1.Text = "積載"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl2.TabIndex = 19
        Me.lblTtl2.Text = "使用回数"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblALDCount
        '
        Me.lblALDCount.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblALDCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblALDCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblALDCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblALDCount.Location = New System.Drawing.Point(312, 32)
        Me.lblALDCount.Name = "lblALDCount"
        Me.lblALDCount.Size = New System.Drawing.Size(97, 25)
        Me.lblALDCount.TabIndex = 20
        Me.lblALDCount.Text = "2"
        Me.lblALDCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 129)
        Me.lblBack.TabIndex = 15
        '
        'frmxxEN02T0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdRegist
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.cmdCarrierSelect)
        Me.Controls.Add(Me.fraClass)
        Me.Controls.Add(Me.cmdCarrierClean)
        Me.Controls.Add(Me.cmdScanClear)
        Me.Controls.Add(Me.cmdATrayClear)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.vsfSlot)
        Me.Controls.Add(Me.txtACarrierId)
        Me.Controls.Add(Me.txtATrayId)
        Me.Controls.Add(Me.vsfInvList)
        Me.Controls.Add(Me.lblCleanFlag)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblEmptyFlag)
        Me.Controls.Add(Me.lblLot)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblCleanCount)
        Me.Controls.Add(Me.lblALDLimit)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblALDCount)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02T0"
        Me.Text = "Ａキャリア管理"
        Me.fraClass.ResumeLayout(false)
        CType(Me.vsfSlot,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfInvList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents fraClass As GroupBox
    Friend WithEvents optClass4 As RadioButton
    Friend WithEvents optClass3 As RadioButton
    Friend WithEvents optClass2 As RadioButton
    Friend WithEvents optClass1 As RadioButton
    Friend WithEvents optClass0 As RadioButton
    Friend WithEvents cmdCarrierClean As Button
    Friend WithEvents cmdScanClear As Button
    Friend WithEvents cmdATrayClear As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents vsfSlot As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtACarrierId As SETextBoxEx.TextBoxEx
    Friend WithEvents txtATrayId As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfInvList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblCleanFlag As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblEmptyFlag As Label
    Friend WithEvents lblLot As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblCleanCount As Label
    Friend WithEvents lblALDLimit As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblALDCount As Label
    Friend WithEvents lblBack As Label
End Class
