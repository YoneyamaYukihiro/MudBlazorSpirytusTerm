<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01E0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01E0))
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.fraLot2 = New System.Windows.Forms.GroupBox()
        Me.vsfSlotMapMove = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblCarrierMove2 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblFlowClassMove2 = New System.Windows.Forms.Label()
        Me.lblLotIDMove2 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.fraLot = New System.Windows.Forms.GroupBox()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblLotIDMove1 = New System.Windows.Forms.Label()
        Me.lblFlowClassMove1 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblCarrierMove1 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblMoveClass = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout
        Me.fraLot2.SuspendLayout
        CType(Me.vsfSlotMapMove,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraLot.SuspendLayout
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.txtCarrier)
        Me.Frame1.Controls.Add(Me.lblLotID)
        Me.Frame1.Controls.Add(Me.lblTtl4)
        Me.Frame1.Controls.Add(Me.lblFlowClass)
        Me.Frame1.Controls.Add(Me.lblTtl0)
        Me.Frame1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Frame1.Location = New System.Drawing.Point(8, 14)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(189, 131)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = false
        Me.Frame1.Text = "移載元"
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(8, 38)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(172, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(8, 90)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(115, 25)
        Me.lblLotID.TabIndex = 18
        Me.lblLotID.Text = "GTA1234-00"
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(8, 74)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(172, 17)
        Me.lblTtl4.TabIndex = 17
        Me.lblTtl4.Text = "ロットID"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(122, 90)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(58, 25)
        Me.lblFlowClass.TabIndex = 16
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 22)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(172, 17)
        Me.lblTtl0.TabIndex = 15
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraLot2
        '
        Me.fraLot2.Controls.Add(Me.vsfSlotMapMove)
        Me.fraLot2.Controls.Add(Me.lblCarrierMove2)
        Me.fraLot2.Controls.Add(Me.lblTtl2)
        Me.fraLot2.Controls.Add(Me.lblFlowClassMove2)
        Me.fraLot2.Controls.Add(Me.lblLotIDMove2)
        Me.fraLot2.Controls.Add(Me.lblTtl1)
        Me.fraLot2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot2.Location = New System.Drawing.Point(595, 14)
        Me.fraLot2.Name = "fraLot2"
        Me.fraLot2.Size = New System.Drawing.Size(381, 559)
        Me.fraLot2.TabIndex = 7
        Me.fraLot2.TabStop = false
        Me.fraLot2.Text = "移載先２"
        '
        'vsfSlotMapMove
        '
        Me.vsfSlotMapMove.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMapMove.AllowEditing = false
        Me.vsfSlotMapMove.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMapMove.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMapMove.AutoSearchDelay = 2R
        Me.vsfSlotMapMove.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMapMove.ColumnInfo = "2,1,0,0,0,125,Columns:0{Width:26;Style:""TextAlign:CenterCenter;"";StyleFixed:""Text"& _ 
    "Align:CenterCenter;"";}"&Global.Microsoft.VisualBasic.ChrW(9)&"1{Width:96;Caption:""WF_ID"";Style:""TextAlign:LeftCenter;"";"& _ 
    "StyleFixed:""TextAlign:CenterCenter;"";}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfSlotMapMove.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMapMove.ExtendLastCol = true
        Me.vsfSlotMapMove.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMapMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMapMove.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMapMove.Location = New System.Drawing.Point(10, 22)
        Me.vsfSlotMapMove.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMapMove.Name = "vsfSlotMapMove"
        Me.vsfSlotMapMove.Rows.Count = 26
        Me.vsfSlotMapMove.Rows.DefaultSize = 18
        Me.vsfSlotMapMove.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMapMove.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMapMove.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMapMove.Size = New System.Drawing.Size(183, 520)
        Me.vsfSlotMapMove.StyleInfo = resources.GetString("vsfSlotMapMove.StyleInfo")
        Me.vsfSlotMapMove.TabIndex = 8
        Me.vsfSlotMapMove.TabStop = false
        '
        'lblCarrierMove2
        '
        Me.lblCarrierMove2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrierMove2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierMove2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierMove2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrierMove2.Location = New System.Drawing.Point(200, 38)
        Me.lblCarrierMove2.Name = "lblCarrierMove2"
        Me.lblCarrierMove2.Size = New System.Drawing.Size(172, 25)
        Me.lblCarrierMove2.TabIndex = 13
        Me.lblCarrierMove2.Text = "A23456"
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(200, 22)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(172, 17)
        Me.lblTtl2.TabIndex = 12
        Me.lblTtl2.Text = "キャリアID"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClassMove2
        '
        Me.lblFlowClassMove2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClassMove2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClassMove2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClassMove2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClassMove2.Location = New System.Drawing.Point(314, 90)
        Me.lblFlowClassMove2.Name = "lblFlowClassMove2"
        Me.lblFlowClassMove2.Size = New System.Drawing.Size(58, 25)
        Me.lblFlowClassMove2.TabIndex = 11
        Me.lblFlowClassMove2.Text = "ZZ"
        '
        'lblLotIDMove2
        '
        Me.lblLotIDMove2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotIDMove2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotIDMove2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotIDMove2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotIDMove2.Location = New System.Drawing.Point(200, 90)
        Me.lblLotIDMove2.Name = "lblLotIDMove2"
        Me.lblLotIDMove2.Size = New System.Drawing.Size(115, 25)
        Me.lblLotIDMove2.TabIndex = 10
        Me.lblLotIDMove2.Text = "GTA1234-00"
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(200, 74)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(172, 17)
        Me.lblTtl1.TabIndex = 9
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraLot
        '
        Me.fraLot.Controls.Add(Me.vsfSlotMap)
        Me.fraLot.Controls.Add(Me.lblTtl6)
        Me.fraLot.Controls.Add(Me.lblLotIDMove1)
        Me.fraLot.Controls.Add(Me.lblFlowClassMove1)
        Me.fraLot.Controls.Add(Me.lblTtl5)
        Me.fraLot.Controls.Add(Me.lblCarrierMove1)
        Me.fraLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot.Location = New System.Drawing.Point(206, 14)
        Me.fraLot.Name = "fraLot"
        Me.fraLot.Size = New System.Drawing.Size(381, 559)
        Me.fraLot.TabIndex = 3
        Me.fraLot.TabStop = false
        Me.fraLot.Text = "移載先１"
        '
        'vsfSlotMap
        '
        Me.vsfSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap.AllowEditing = false
        Me.vsfSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap.AutoSearchDelay = 2R
        Me.vsfSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap.ColumnInfo = resources.GetString("vsfSlotMap.ColumnInfo")
        Me.vsfSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap.ExtendLastCol = true
        Me.vsfSlotMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap.Location = New System.Drawing.Point(10, 22)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 26
        Me.vsfSlotMap.Rows.DefaultSize = 18
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap.Size = New System.Drawing.Size(183, 520)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 6
        Me.vsfSlotMap.TabStop = false
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(200, 74)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(172, 17)
        Me.lblTtl6.TabIndex = 23
        Me.lblTtl6.Text = "ロットID"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotIDMove1
        '
        Me.lblLotIDMove1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotIDMove1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotIDMove1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotIDMove1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotIDMove1.Location = New System.Drawing.Point(200, 90)
        Me.lblLotIDMove1.Name = "lblLotIDMove1"
        Me.lblLotIDMove1.Size = New System.Drawing.Size(115, 25)
        Me.lblLotIDMove1.TabIndex = 22
        Me.lblLotIDMove1.Text = "GTA1234-00"
        '
        'lblFlowClassMove1
        '
        Me.lblFlowClassMove1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClassMove1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClassMove1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClassMove1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClassMove1.Location = New System.Drawing.Point(314, 90)
        Me.lblFlowClassMove1.Name = "lblFlowClassMove1"
        Me.lblFlowClassMove1.Size = New System.Drawing.Size(58, 25)
        Me.lblFlowClassMove1.TabIndex = 21
        Me.lblFlowClassMove1.Text = "ZZ"
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(200, 22)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(172, 17)
        Me.lblTtl5.TabIndex = 20
        Me.lblTtl5.Text = "キャリアID"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCarrierMove1
        '
        Me.lblCarrierMove1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrierMove1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierMove1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierMove1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrierMove1.Location = New System.Drawing.Point(200, 38)
        Me.lblCarrierMove1.Name = "lblCarrierMove1"
        Me.lblCarrierMove1.Size = New System.Drawing.Size(172, 25)
        Me.lblCarrierMove1.TabIndex = 19
        Me.lblCarrierMove1.Text = "A23456"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 580)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 580)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 1
        Me.cmdRegist.Text = "確　定"
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(640, 589)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(129, 17)
        Me.lblTtl3.TabIndex = 5
        Me.lblTtl3.Text = "移載区分"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTtl3.Visible = false
        '
        'lblMoveClass
        '
        Me.lblMoveClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMoveClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMoveClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMoveClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMoveClass.Location = New System.Drawing.Point(640, 605)
        Me.lblMoveClass.Name = "lblMoveClass"
        Me.lblMoveClass.Size = New System.Drawing.Size(129, 25)
        Me.lblMoveClass.TabIndex = 4
        Me.lblMoveClass.Text = "分割"
        Me.lblMoveClass.Visible = false
        '
        'frmxxEN01E0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.fraLot2)
        Me.Controls.Add(Me.fraLot)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblMoveClass)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01E0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "在庫移載"
        Me.Frame1.ResumeLayout(false)
        Me.fraLot2.ResumeLayout(false)
        CType(Me.vsfSlotMapMove,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraLot.ResumeLayout(false)
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents Frame1 As GroupBox
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents fraLot2 As GroupBox
    Friend WithEvents vsfSlotMapMove As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblCarrierMove2 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblFlowClassMove2 As Label
    Friend WithEvents lblLotIDMove2 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents fraLot As GroupBox
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblLotIDMove1 As Label
    Friend WithEvents lblFlowClassMove1 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblCarrierMove1 As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblMoveClass As Label
End Class
