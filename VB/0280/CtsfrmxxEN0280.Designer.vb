<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0280
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0280))
        Me.picRightAllow = New System.Windows.Forms.PictureBox()
        Me.fraLot2 = New System.Windows.Forms.GroupBox()
        Me.vsfSlotMapMove = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblCarrierMove = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblFlowClassMove = New System.Windows.Forms.Label()
        Me.lblLotIDMove = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.fraLot = New System.Windows.Forms.GroupBox()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.picLeftAllow = New System.Windows.Forms.PictureBox()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblDivideLotID = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblMoveClass = New System.Windows.Forms.Label()
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraLot2.SuspendLayout
        CType(Me.vsfSlotMapMove,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraLot.SuspendLayout
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picLeftAllow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'picRightAllow
        '
        Me.picRightAllow.Image = CType(resources.GetObject("picRightAllow.Image"),System.Drawing.Image)
        Me.picRightAllow.Location = New System.Drawing.Point(472, 288)
        Me.picRightAllow.Name = "picRightAllow"
        Me.picRightAllow.Size = New System.Drawing.Size(32, 32)
        Me.picRightAllow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRightAllow.TabIndex = 20
        Me.picRightAllow.TabStop = false
        '
        'fraLot2
        '
        Me.fraLot2.Controls.Add(Me.vsfSlotMapMove)
        Me.fraLot2.Controls.Add(Me.lblCarrierMove)
        Me.fraLot2.Controls.Add(Me.lblTtl2)
        Me.fraLot2.Controls.Add(Me.lblFlowClassMove)
        Me.fraLot2.Controls.Add(Me.lblLotIDMove)
        Me.fraLot2.Controls.Add(Me.lblTtl1)
        Me.fraLot2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot2.Location = New System.Drawing.Point(577, 8)
        Me.fraLot2.Name = "fraLot2"
        Me.fraLot2.Size = New System.Drawing.Size(397, 561)
        Me.fraLot2.TabIndex = 13
        Me.fraLot2.TabStop = false
        Me.fraLot2.Text = "移載先"
        '
        'vsfSlotMapMove
        '
        Me.vsfSlotMapMove.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMapMove.AllowEditing = false
        Me.vsfSlotMapMove.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMapMove.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMapMove.AutoSearchDelay = 2R
        Me.vsfSlotMapMove.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMapMove.ColumnInfo = resources.GetString("vsfSlotMapMove.ColumnInfo")
        Me.vsfSlotMapMove.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMapMove.ExtendLastCol = true
        Me.vsfSlotMapMove.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMapMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMapMove.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMapMove.Location = New System.Drawing.Point(10, 24)
        Me.vsfSlotMapMove.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMapMove.Name = "vsfSlotMapMove"
        Me.vsfSlotMapMove.Rows.Count = 26
        Me.vsfSlotMapMove.Rows.DefaultSize = 18
        Me.vsfSlotMapMove.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMapMove.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMapMove.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMapMove.Size = New System.Drawing.Size(183, 520)
        Me.vsfSlotMapMove.StyleInfo = resources.GetString("vsfSlotMapMove.StyleInfo")
        Me.vsfSlotMapMove.TabIndex = 14
        '
        'lblCarrierMove
        '
        Me.lblCarrierMove.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrierMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierMove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrierMove.Location = New System.Drawing.Point(200, 38)
        Me.lblCarrierMove.Name = "lblCarrierMove"
        Me.lblCarrierMove.Size = New System.Drawing.Size(185, 25)
        Me.lblCarrierMove.TabIndex = 19
        Me.lblCarrierMove.Text = "A23456"
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(200, 22)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl2.TabIndex = 18
        Me.lblTtl2.Text = "キャリアID"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClassMove
        '
        Me.lblFlowClassMove.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClassMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClassMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClassMove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClassMove.Location = New System.Drawing.Point(320, 90)
        Me.lblFlowClassMove.Name = "lblFlowClassMove"
        Me.lblFlowClassMove.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClassMove.TabIndex = 17
        Me.lblFlowClassMove.Text = "ZZ"
        '
        'lblLotIDMove
        '
        Me.lblLotIDMove.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotIDMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotIDMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotIDMove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotIDMove.Location = New System.Drawing.Point(200, 90)
        Me.lblLotIDMove.Name = "lblLotIDMove"
        Me.lblLotIDMove.Size = New System.Drawing.Size(122, 25)
        Me.lblLotIDMove.TabIndex = 16
        Me.lblLotIDMove.Text = "GTA1234-00"
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(200, 74)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 15
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraLot
        '
        Me.fraLot.Controls.Add(Me.vsfSlotMap)
        Me.fraLot.Controls.Add(Me.txtCarrier)
        Me.fraLot.Controls.Add(Me.lblTtl0)
        Me.fraLot.Controls.Add(Me.lblFlowClass)
        Me.fraLot.Controls.Add(Me.lblTtl4)
        Me.fraLot.Controls.Add(Me.lblLotID)
        Me.fraLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot.Location = New System.Drawing.Point(8, 8)
        Me.fraLot.Name = "fraLot"
        Me.fraLot.Size = New System.Drawing.Size(396, 561)
        Me.fraLot.TabIndex = 0
        Me.fraLot.TabStop = false
        Me.fraLot.Text = "移載元"
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
        Me.vsfSlotMap.Location = New System.Drawing.Point(202, 24)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 26
        Me.vsfSlotMap.Rows.DefaultSize = 18
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap.Size = New System.Drawing.Size(183, 520)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 11
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(8, 41)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
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
        Me.lblTtl0.TabIndex = 12
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
        Me.lblFlowClass.TabIndex = 10
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(8, 79)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl4.TabIndex = 5
        Me.lblTtl4.Text = "ロットID"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(8, 95)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(122, 25)
        Me.lblLotID.TabIndex = 4
        Me.lblLotID.Text = "GTA1234-00"
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
        'picLeftAllow
        '
        Me.picLeftAllow.Image = CType(resources.GetObject("picLeftAllow.Image"),System.Drawing.Image)
        Me.picLeftAllow.Location = New System.Drawing.Point(472, 288)
        Me.picLeftAllow.Name = "picLeftAllow"
        Me.picLeftAllow.Size = New System.Drawing.Size(32, 32)
        Me.picLeftAllow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLeftAllow.TabIndex = 21
        Me.picLeftAllow.TabStop = false
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(412, 512)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(157, 17)
        Me.lblTtl5.TabIndex = 9
        Me.lblTtl5.Text = "移載後ロットID"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTtl5.Visible = false
        '
        'lblDivideLotID
        '
        Me.lblDivideLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDivideLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDivideLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDivideLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDivideLotID.Location = New System.Drawing.Point(412, 528)
        Me.lblDivideLotID.Name = "lblDivideLotID"
        Me.lblDivideLotID.Size = New System.Drawing.Size(157, 25)
        Me.lblDivideLotID.TabIndex = 8
        Me.lblDivideLotID.Text = "GTA4321-00 ZZ"
        Me.lblDivideLotID.Visible = false
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(412, 32)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(157, 17)
        Me.lblTtl3.TabIndex = 7
        Me.lblTtl3.Text = "移載区分"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMoveClass
        '
        Me.lblMoveClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMoveClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMoveClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMoveClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMoveClass.Location = New System.Drawing.Point(412, 49)
        Me.lblMoveClass.Name = "lblMoveClass"
        Me.lblMoveClass.Size = New System.Drawing.Size(157, 25)
        Me.lblMoveClass.TabIndex = 6
        Me.lblMoveClass.Text = "不良/払出/保留"
        '
        'frmxxEN0280
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.picRightAllow)
        Me.Controls.Add(Me.fraLot2)
        Me.Controls.Add(Me.fraLot)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.picLeftAllow)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblDivideLotID)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblMoveClass)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0280"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "移載(ソーター)"
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraLot2.ResumeLayout(false)
        CType(Me.vsfSlotMapMove,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraLot.ResumeLayout(false)
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picLeftAllow,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents picRightAllow As PictureBox
    Friend WithEvents fraLot2 As GroupBox
    Friend WithEvents vsfSlotMapMove As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblCarrierMove As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblFlowClassMove As Label
    Friend WithEvents lblLotIDMove As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents fraLot As GroupBox
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents picLeftAllow As PictureBox
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblDivideLotID As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblMoveClass As Label
End Class
