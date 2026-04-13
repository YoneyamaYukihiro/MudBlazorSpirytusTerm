<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02L0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02L0))
        Me.cmdClipCopy = New System.Windows.Forms.Button()
        Me.fraWFInfo = New System.Windows.Forms.GroupBox()
        Me.vsfWFList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdDown2 = New System.Windows.Forms.Button()
        Me.cmdUp2 = New System.Windows.Forms.Button()
        Me.fraCodeList = New System.Windows.Forms.GroupBox()
        Me.vsfCodeList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdUp1 = New System.Windows.Forms.Button()
        Me.cmdDown1 = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdConfirm = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.lblGrbClass = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
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
        Me.lblTtlEqType = New System.Windows.Forms.Label()
        Me.lblEqType = New System.Windows.Forms.Label()
        Me.fraWFInfo.SuspendLayout
        CType(Me.vsfWFList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCodeList.SuspendLayout
        CType(Me.vsfCodeList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdClipCopy
        '
        Me.cmdClipCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClipCopy.Location = New System.Drawing.Point(115, 580)
        Me.cmdClipCopy.Name = "cmdClipCopy"
        Me.cmdClipCopy.Size = New System.Drawing.Size(105, 57)
        Me.cmdClipCopy.TabIndex = 25
        Me.cmdClipCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'fraWFInfo
        '
        Me.fraWFInfo.Controls.Add(Me.vsfWFList)
        Me.fraWFInfo.Controls.Add(Me.cmdDown2)
        Me.fraWFInfo.Controls.Add(Me.cmdUp2)
        Me.fraWFInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraWFInfo.Location = New System.Drawing.Point(547, 120)
        Me.fraWFInfo.Name = "fraWFInfo"
        Me.fraWFInfo.Size = New System.Drawing.Size(425, 453)
        Me.fraWFInfo.TabIndex = 4
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
        Me.vsfWFList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWFList.ExtendLastCol = true
        Me.vsfWFList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfWFList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWFList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWFList.Location = New System.Drawing.Point(16, 20)
        Me.vsfWFList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWFList.Name = "vsfWFList"
        Me.vsfWFList.Rows.Count = 26
        Me.vsfWFList.Rows.DefaultSize = 38
        Me.vsfWFList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfWFList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWFList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfWFList.Size = New System.Drawing.Size(327, 420)
        Me.vsfWFList.StyleInfo = resources.GetString("vsfWFList.StyleInfo")
        Me.vsfWFList.TabIndex = 4
        '
        'cmdDown2
        '
        Me.cmdDown2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown2.Location = New System.Drawing.Point(352, 230)
        Me.cmdDown2.Name = "cmdDown2"
        Me.cmdDown2.Size = New System.Drawing.Size(49, 211)
        Me.cmdDown2.TabIndex = 6
        Me.cmdDown2.Text = "▼"
        '
        'cmdUp2
        '
        Me.cmdUp2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp2.Location = New System.Drawing.Point(352, 19)
        Me.cmdUp2.Name = "cmdUp2"
        Me.cmdUp2.Size = New System.Drawing.Size(49, 211)
        Me.cmdUp2.TabIndex = 5
        Me.cmdUp2.Text = "▲"
        '
        'fraCodeList
        '
        Me.fraCodeList.Controls.Add(Me.vsfCodeList)
        Me.fraCodeList.Controls.Add(Me.cmdUp1)
        Me.fraCodeList.Controls.Add(Me.cmdDown1)
        Me.fraCodeList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCodeList.Location = New System.Drawing.Point(8, 120)
        Me.fraCodeList.Name = "fraCodeList"
        Me.fraCodeList.Size = New System.Drawing.Size(408, 453)
        Me.fraCodeList.TabIndex = 1
        Me.fraCodeList.TabStop = false
        Me.fraCodeList.Text = "GRB属性一覧"
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
        Me.vsfCodeList.Location = New System.Drawing.Point(104, 20)
        Me.vsfCodeList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCodeList.Name = "vsfCodeList"
        Me.vsfCodeList.Rows.Count = 30
        Me.vsfCodeList.Rows.DefaultSize = 38
        Me.vsfCodeList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfCodeList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCodeList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCodeList.Size = New System.Drawing.Size(220, 420)
        Me.vsfCodeList.StyleInfo = resources.GetString("vsfCodeList.StyleInfo")
        Me.vsfCodeList.TabIndex = 1
        '
        'cmdUp1
        '
        Me.cmdUp1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp1.Location = New System.Drawing.Point(336, 19)
        Me.cmdUp1.Name = "cmdUp1"
        Me.cmdUp1.Size = New System.Drawing.Size(49, 211)
        Me.cmdUp1.TabIndex = 2
        Me.cmdUp1.Text = "▲"
        '
        'cmdDown1
        '
        Me.cmdDown1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown1.Location = New System.Drawing.Point(336, 230)
        Me.cmdDown1.Name = "cmdDown1"
        Me.cmdDown1.Size = New System.Drawing.Size(49, 211)
        Me.cmdDown1.TabIndex = 3
        Me.cmdDown1.Text = "▼"
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(764, 580)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "取　消"
        '
        'cmdConfirm
        '
        Me.cmdConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdConfirm.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdConfirm.Location = New System.Drawing.Point(872, 580)
        Me.cmdConfirm.Name = "cmdConfirm"
        Me.cmdConfirm.Size = New System.Drawing.Size(105, 57)
        Me.cmdConfirm.TabIndex = 7
        Me.cmdConfirm.Text = "確　定"
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
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "閉じる"
        '
        'txtCarrier
        '
        Me.txtCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.GotBackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'lblGrbClass
        '
        Me.lblGrbClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGrbClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGrbClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGrbClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGrbClass.Location = New System.Drawing.Point(216, 32)
        Me.lblGrbClass.Name = "lblGrbClass"
        Me.lblGrbClass.Size = New System.Drawing.Size(97, 25)
        Me.lblGrbClass.TabIndex = 27
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl4.TabIndex = 26
        Me.lblTtl4.Text = "GRB"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl1.TabIndex = 24
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
        Me.lblFlowClass.TabIndex = 23
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
        Me.lblLotID.TabIndex = 22
        '
        'lblStepName
        '
        Me.lblStepName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepName.Location = New System.Drawing.Point(640, 32)
        Me.lblStepName.Name = "lblStepName"
        Me.lblStepName.Size = New System.Drawing.Size(329, 25)
        Me.lblStepName.TabIndex = 21
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(640, 16)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(329, 17)
        Me.lblTtl8.TabIndex = 20
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(312, 80)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblStatus.TabIndex = 19
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(312, 64)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl7.TabIndex = 18
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(216, 80)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
        Me.lblWFNo.TabIndex = 17
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(216, 64)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl2.TabIndex = 16
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
        Me.lblTtl3.Size = New System.Drawing.Size(329, 17)
        Me.lblTtl3.TabIndex = 15
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
        Me.lblOpName.Size = New System.Drawing.Size(329, 25)
        Me.lblOpName.TabIndex = 14
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
        Me.lblTtl0.TabIndex = 13
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
        Me.lblBack.TabIndex = 12
        '
        'lblTtlEqType
        '
        Me.lblTtlEqType.BackColor = System.Drawing.Color.Navy
        Me.lblTtlEqType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtlEqType.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtlEqType.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtlEqType.Location = New System.Drawing.Point(415, 64)
        Me.lblTtlEqType.Name = "lblTtlEqType"
        Me.lblTtlEqType.Size = New System.Drawing.Size(97, 17)
        Me.lblTtlEqType.TabIndex = 28
        Me.lblTtlEqType.Text = "EQ_TYPE"
        Me.lblTtlEqType.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEqType
        '
        Me.lblEqType.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEqType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEqType.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEqType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEqType.Location = New System.Drawing.Point(415, 80)
        Me.lblEqType.Name = "lblEqType"
        Me.lblEqType.Size = New System.Drawing.Size(97, 25)
        Me.lblEqType.TabIndex = 29
        '
        'frmxxEN02L0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblEqType)
        Me.Controls.Add(Me.lblTtlEqType)
        Me.Controls.Add(Me.cmdClipCopy)
        Me.Controls.Add(Me.fraWFInfo)
        Me.Controls.Add(Me.fraCodeList)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdConfirm)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.lblGrbClass)
        Me.Controls.Add(Me.lblTtl4)
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
        Me.Name = "frmxxEN02L0"
        Me.Text = "GRB属性設定"
        Me.fraWFInfo.ResumeLayout(false)
        CType(Me.vsfWFList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCodeList.ResumeLayout(false)
        CType(Me.vsfCodeList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdClipCopy As Button
    Friend WithEvents fraWFInfo As GroupBox
    Friend WithEvents vsfWFList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdDown2 As Button
    Friend WithEvents cmdUp2 As Button
    Friend WithEvents fraCodeList As GroupBox
    Friend WithEvents vsfCodeList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdUp1 As Button
    Friend WithEvents cmdDown1 As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdConfirm As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblGrbClass As Label
    Friend WithEvents lblTtl4 As Label
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
    Friend WithEvents lblTtlEqType As Label
    Friend WithEvents lblEqType As Label
End Class
