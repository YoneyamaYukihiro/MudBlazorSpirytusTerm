<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0161
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0161))
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.fraLot = New System.Windows.Forms.GroupBox()
        Me.lblGRB = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkMoveSkip = New System.Windows.Forms.CheckBox()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.fraLot2 = New System.Windows.Forms.GroupBox()
        Me.lblGRB2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.vsfSlotMap2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtCarrier2 = New SETextBoxEx.TextBoxEx()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblFlowClass2 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblLotID2 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblOpID2 = New System.Windows.Forms.Label()
        Me.lblStepID2 = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblStatus2 = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.fraLot.SuspendLayout
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraLot2.SuspendLayout
        CType(Me.vsfSlotMap2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(750, 490)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 44)
        Me.cmdMemoUp.TabIndex = 5
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(750, 535)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 6
        Me.cmdMemoDown.Text = "▼"
        '
        'fraLot
        '
        Me.fraLot.Controls.Add(Me.lblGRB)
        Me.fraLot.Controls.Add(Me.Label1)
        Me.fraLot.Controls.Add(Me.chkMoveSkip)
        Me.fraLot.Controls.Add(Me.vsfSlotMap)
        Me.fraLot.Controls.Add(Me.txtCarrier)
        Me.fraLot.Controls.Add(Me.lblStatus)
        Me.fraLot.Controls.Add(Me.lblTtl8)
        Me.fraLot.Controls.Add(Me.lblStepID)
        Me.fraLot.Controls.Add(Me.lblOpID)
        Me.fraLot.Controls.Add(Me.lblTtl3)
        Me.fraLot.Controls.Add(Me.lblLotID)
        Me.fraLot.Controls.Add(Me.lblTtl0)
        Me.fraLot.Controls.Add(Me.lblFlowClass)
        Me.fraLot.Controls.Add(Me.lblTtl1)
        Me.fraLot.Controls.Add(Me.lblTtl7)
        Me.fraLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot.Location = New System.Drawing.Point(8, 8)
        Me.fraLot.Name = "fraLot"
        Me.fraLot.Size = New System.Drawing.Size(481, 475)
        Me.fraLot.TabIndex = 0
        Me.fraLot.TabStop = false
        Me.fraLot.Text = "統合ロット1"
        '
        'lblGRB
        '
        Me.lblGRB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGRB.Location = New System.Drawing.Point(192, 95)
        Me.lblGRB.Name = "lblGRB"
        Me.lblGRB.Size = New System.Drawing.Size(65, 25)
        Me.lblGRB.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(192, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 25)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "GRB"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        'vsfSlotMap
        '
        Me.vsfSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap.AllowEditing = false
        Me.vsfSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap.AutoResize = true
        Me.vsfSlotMap.AutoSearchDelay = 2R
        Me.vsfSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap.ColumnInfo = resources.GetString("vsfSlotMap.ColumnInfo")
        Me.vsfSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap.ExtendLastCol = true
        Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap.Location = New System.Drawing.Point(296, 24)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 26
        Me.vsfSlotMap.Rows.DefaultSize = 16
        Me.vsfSlotMap.Rows.MinSize = 17
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap.Size = New System.Drawing.Size(177, 444)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 21
        Me.vsfSlotMap.TabStop = false
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
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(8, 245)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(185, 25)
        Me.lblStatus.TabIndex = 31
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(8, 179)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 30
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(8, 195)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 29
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(8, 145)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID.TabIndex = 28
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(8, 129)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl3.TabIndex = 27
        Me.lblTtl3.Text = "大工程"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(8, 95)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 26
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
        Me.lblTtl0.TabIndex = 25
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(128, 95)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 24
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(8, 79)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 23
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(8, 229)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl7.TabIndex = 22
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraLot2
        '
        Me.fraLot2.Controls.Add(Me.lblGRB2)
        Me.fraLot2.Controls.Add(Me.Label3)
        Me.fraLot2.Controls.Add(Me.vsfSlotMap2)
        Me.fraLot2.Controls.Add(Me.txtCarrier2)
        Me.fraLot2.Controls.Add(Me.lblTtl2)
        Me.fraLot2.Controls.Add(Me.lblFlowClass2)
        Me.fraLot2.Controls.Add(Me.lblTtl5)
        Me.fraLot2.Controls.Add(Me.lblLotID2)
        Me.fraLot2.Controls.Add(Me.lblTtl6)
        Me.fraLot2.Controls.Add(Me.lblOpID2)
        Me.fraLot2.Controls.Add(Me.lblStepID2)
        Me.fraLot2.Controls.Add(Me.lblTtl9)
        Me.fraLot2.Controls.Add(Me.lblStatus2)
        Me.fraLot2.Controls.Add(Me.lblTtl10)
        Me.fraLot2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot2.Location = New System.Drawing.Point(496, 8)
        Me.fraLot2.Name = "fraLot2"
        Me.fraLot2.Size = New System.Drawing.Size(481, 475)
        Me.fraLot2.TabIndex = 1
        Me.fraLot2.TabStop = false
        Me.fraLot2.Text = "統合ロット2"
        '
        'lblGRB2
        '
        Me.lblGRB2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGRB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRB2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRB2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGRB2.Location = New System.Drawing.Point(376, 95)
        Me.lblGRB2.Name = "lblGRB2"
        Me.lblGRB2.Size = New System.Drawing.Size(65, 25)
        Me.lblGRB2.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Navy
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(376, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 25)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "GRB"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.vsfSlotMap2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfSlotMap2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap2.Location = New System.Drawing.Point(8, 24)
        Me.vsfSlotMap2.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap2.Name = "vsfSlotMap2"
        Me.vsfSlotMap2.Rows.Count = 26
        Me.vsfSlotMap2.Rows.DefaultSize = 16
        Me.vsfSlotMap2.Rows.MinSize = 17
        Me.vsfSlotMap2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap2.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap2.Size = New System.Drawing.Size(177, 444)
        Me.vsfSlotMap2.StyleInfo = resources.GetString("vsfSlotMap2.StyleInfo")
        Me.vsfSlotMap2.TabIndex = 9
        Me.vsfSlotMap2.TabStop = false
        '
        'txtCarrier2
        '
        Me.txtCarrier2.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier2.ChrMaxByte = 6
        Me.txtCarrier2.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier2.Location = New System.Drawing.Point(192, 40)
        Me.txtCarrier2.Name = "txtCarrier2"
        Me.txtCarrier2.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier2.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier2.SelectedText = ""
        Me.txtCarrier2.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier2.TabIndex = 2
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(192, 79)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl2.TabIndex = 19
        Me.lblTtl2.Text = "ロットID"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass2
        '
        Me.lblFlowClass2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass2.Location = New System.Drawing.Point(312, 95)
        Me.lblFlowClass2.Name = "lblFlowClass2"
        Me.lblFlowClass2.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass2.TabIndex = 18
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(192, 24)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl5.TabIndex = 17
        Me.lblTtl5.Text = "キャリアID"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID2
        '
        Me.lblLotID2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID2.Location = New System.Drawing.Point(192, 95)
        Me.lblLotID2.Name = "lblLotID2"
        Me.lblLotID2.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID2.TabIndex = 16
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(192, 129)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl6.TabIndex = 15
        Me.lblTtl6.Text = "大工程"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID2
        '
        Me.lblOpID2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID2.Location = New System.Drawing.Point(192, 145)
        Me.lblOpID2.Name = "lblOpID2"
        Me.lblOpID2.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID2.TabIndex = 14
        '
        'lblStepID2
        '
        Me.lblStepID2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID2.Location = New System.Drawing.Point(192, 195)
        Me.lblStepID2.Name = "lblStepID2"
        Me.lblStepID2.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID2.TabIndex = 13
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(192, 179)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl9.TabIndex = 12
        Me.lblTtl9.Text = "小工程"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus2
        '
        Me.lblStatus2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus2.Location = New System.Drawing.Point(192, 245)
        Me.lblStatus2.Name = "lblStatus2"
        Me.lblStatus2.Size = New System.Drawing.Size(185, 25)
        Me.lblStatus2.TabIndex = 11
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(192, 229)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl10.TabIndex = 10
        Me.lblTtl10.Text = "状態"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 584)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 584)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 3
        Me.cmdRegist.Text = "確　定"
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 508)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
        Me.txtWorkMemo.TabIndex = 4
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(494, 491)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 32
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 491)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(743, 18)
        Me.lblTtl15.TabIndex = 33
        Me.lblTtl15.Text = "      作業メモ"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN0161
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.fraLot)
        Me.Controls.Add(Me.fraLot2)
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
        Me.Name = "frmxxEN0161"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ロット統合 予約"
        Me.fraLot.ResumeLayout(false)
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraLot2.ResumeLayout(false)
        CType(Me.vsfSlotMap2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents fraLot As GroupBox
    Friend WithEvents chkMoveSkip As CheckBox
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents fraLot2 As GroupBox
    Friend WithEvents vsfSlotMap2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtCarrier2 As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblFlowClass2 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblLotID2 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblOpID2 As Label
    Friend WithEvents lblStepID2 As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblStatus2 As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblGRB As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblGRB2 As Label
    Friend WithEvents Label3 As Label
End Class
