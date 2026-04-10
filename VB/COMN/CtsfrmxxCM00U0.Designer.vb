<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00U0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00U0))
        Me.picRightAllow = New System.Windows.Forms.PictureBox()
        Me.cmdBDown = New System.Windows.Forms.Button()
        Me.cmdADown = New System.Windows.Forms.Button()
        Me.cmdBUp = New System.Windows.Forms.Button()
        Me.cmdAUp = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdMapDownLoad = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfBeforSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfAfterSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblCfChipNum = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblCfWfNum = New System.Windows.Forms.Label()
        Me.lblCfCarrierID = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblCfPdID = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblCfStatus = New System.Windows.Forms.Label()
        Me.lblCfLotID = New System.Windows.Forms.Label()
        Me.lblCfFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTftChipNum = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTftWfNum = New System.Windows.Forms.Label()
        Me.lblTftCarrierID = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTftPdID = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblTftStatus = New System.Windows.Forms.Label()
        Me.lblTftLotID = New System.Windows.Forms.Label()
        Me.lblTftFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfBeforSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfAfterSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'picRightAllow
        '
        Me.picRightAllow.Image = CType(resources.GetObject("picRightAllow.Image"),System.Drawing.Image)
        Me.picRightAllow.Location = New System.Drawing.Point(450, 338)
        Me.picRightAllow.Name = "picRightAllow"
        Me.picRightAllow.Size = New System.Drawing.Size(32, 32)
        Me.picRightAllow.TabIndex = 37
        Me.picRightAllow.TabStop = false
        '
        'cmdBDown
        '
        Me.cmdBDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdBDown.Location = New System.Drawing.Point(320, 349)
        Me.cmdBDown.Name = "cmdBDown"
        Me.cmdBDown.Size = New System.Drawing.Size(49, 229)
        Me.cmdBDown.TabIndex = 2
        Me.cmdBDown.TabStop = false
        Me.cmdBDown.Text = "▼"
        '
        'cmdADown
        '
        Me.cmdADown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdADown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdADown.Location = New System.Drawing.Point(860, 349)
        Me.cmdADown.Name = "cmdADown"
        Me.cmdADown.Size = New System.Drawing.Size(49, 229)
        Me.cmdADown.TabIndex = 5
        Me.cmdADown.TabStop = false
        Me.cmdADown.Text = "▼"
        '
        'cmdBUp
        '
        Me.cmdBUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdBUp.Location = New System.Drawing.Point(320, 117)
        Me.cmdBUp.Name = "cmdBUp"
        Me.cmdBUp.Size = New System.Drawing.Size(49, 231)
        Me.cmdBUp.TabIndex = 1
        Me.cmdBUp.TabStop = false
        Me.cmdBUp.Text = "▲"
        '
        'cmdAUp
        '
        Me.cmdAUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAUp.Location = New System.Drawing.Point(860, 117)
        Me.cmdAUp.Name = "cmdAUp"
        Me.cmdAUp.Size = New System.Drawing.Size(49, 231)
        Me.cmdAUp.TabIndex = 4
        Me.cmdAUp.TabStop = false
        Me.cmdAUp.Text = "▲"
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(656, 584)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "取　消"
        '
        'cmdMapDownLoad
        '
        Me.cmdMapDownLoad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMapDownLoad.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMapDownLoad.Location = New System.Drawing.Point(764, 584)
        Me.cmdMapDownLoad.Name = "cmdMapDownLoad"
        Me.cmdMapDownLoad.Size = New System.Drawing.Size(105, 57)
        Me.cmdMapDownLoad.TabIndex = 7
        Me.cmdMapDownLoad.Text = "貼り合せ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"実績取得"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 584)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 6
        Me.cmdRegist.Text = "確　定"
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
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "閉じる"
        '
        'vsfBeforSlotMap
        '
        Me.vsfBeforSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfBeforSlotMap.AllowEditing = false
        Me.vsfBeforSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfBeforSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfBeforSlotMap.AutoSearchDelay = 2R
        Me.vsfBeforSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfBeforSlotMap.ColumnInfo = resources.GetString("vsfBeforSlotMap.ColumnInfo")
        Me.vsfBeforSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfBeforSlotMap.ExtendLastCol = true
        Me.vsfBeforSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfBeforSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfBeforSlotMap.Location = New System.Drawing.Point(18, 118)
        Me.vsfBeforSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfBeforSlotMap.Name = "vsfBeforSlotMap"
        Me.vsfBeforSlotMap.Rows.Count = 26
        Me.vsfBeforSlotMap.Rows.DefaultSize = 18
        Me.vsfBeforSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfBeforSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfBeforSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfBeforSlotMap.Size = New System.Drawing.Size(302, 459)
        Me.vsfBeforSlotMap.StyleInfo = resources.GetString("vsfBeforSlotMap.StyleInfo")
        Me.vsfBeforSlotMap.TabIndex = 0
        '
        'vsfAfterSlotMap
        '
        Me.vsfAfterSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfAfterSlotMap.AllowEditing = false
        Me.vsfAfterSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfAfterSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfAfterSlotMap.AutoSearchDelay = 2R
        Me.vsfAfterSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfAfterSlotMap.ColumnInfo = resources.GetString("vsfAfterSlotMap.ColumnInfo")
        Me.vsfAfterSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfAfterSlotMap.ExtendLastCol = true
        Me.vsfAfterSlotMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfAfterSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfAfterSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfAfterSlotMap.Location = New System.Drawing.Point(558, 118)
        Me.vsfAfterSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfAfterSlotMap.Name = "vsfAfterSlotMap"
        Me.vsfAfterSlotMap.Rows.Count = 26
        Me.vsfAfterSlotMap.Rows.DefaultSize = 18
        Me.vsfAfterSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfAfterSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfAfterSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfAfterSlotMap.Size = New System.Drawing.Size(302, 459)
        Me.vsfAfterSlotMap.StyleInfo = resources.GetString("vsfAfterSlotMap.StyleInfo")
        Me.vsfAfterSlotMap.TabIndex = 3
        '
        'Frame1
        '
        Me.Frame1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Frame1.Location = New System.Drawing.Point(8, 102)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(371, 481)
        Me.Frame1.TabIndex = 38
        Me.Frame1.TabStop = false
        Me.Frame1.Text = "貼り合せ前WFID"
        '
        'Frame2
        '
        Me.Frame2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Frame2.Location = New System.Drawing.Point(548, 102)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(371, 481)
        Me.Frame2.TabIndex = 39
        Me.Frame2.TabStop = false
        Me.Frame2.Text = "貼り合せ後WFID"
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(844, 54)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl11.TabIndex = 36
        Me.lblTtl11.Text = "数量(Chip)"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCfChipNum
        '
        Me.lblCfChipNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCfChipNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCfChipNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCfChipNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCfChipNum.Location = New System.Drawing.Point(844, 70)
        Me.lblCfChipNum.Name = "lblCfChipNum"
        Me.lblCfChipNum.Size = New System.Drawing.Size(97, 25)
        Me.lblCfChipNum.TabIndex = 35
        Me.lblCfChipNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(748, 54)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl10.TabIndex = 34
        Me.lblTtl10.Text = "数量(WF)"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCfWfNum
        '
        Me.lblCfWfNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCfWfNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCfWfNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCfWfNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCfWfNum.Location = New System.Drawing.Point(748, 70)
        Me.lblCfWfNum.Name = "lblCfWfNum"
        Me.lblCfWfNum.Size = New System.Drawing.Size(97, 25)
        Me.lblCfWfNum.TabIndex = 33
        Me.lblCfWfNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCfCarrierID
        '
        Me.lblCfCarrierID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCfCarrierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCfCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCfCarrierID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCfCarrierID.Location = New System.Drawing.Point(548, 30)
        Me.lblCfCarrierID.Name = "lblCfCarrierID"
        Me.lblCfCarrierID.Size = New System.Drawing.Size(185, 25)
        Me.lblCfCarrierID.TabIndex = 32
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(548, 14)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl9.TabIndex = 31
        Me.lblTtl9.Text = "CFキャリアID"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(748, 14)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl8.TabIndex = 30
        Me.lblTtl8.Text = "機種"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCfPdID
        '
        Me.lblCfPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCfPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCfPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCfPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCfPdID.Location = New System.Drawing.Point(748, 30)
        Me.lblCfPdID.Name = "lblCfPdID"
        Me.lblCfPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblCfPdID.TabIndex = 29
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(844, 14)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl6.TabIndex = 28
        Me.lblTtl6.Text = "状態"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCfStatus
        '
        Me.lblCfStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCfStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCfStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCfStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCfStatus.Location = New System.Drawing.Point(844, 30)
        Me.lblCfStatus.Name = "lblCfStatus"
        Me.lblCfStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblCfStatus.TabIndex = 27
        '
        'lblCfLotID
        '
        Me.lblCfLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCfLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCfLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCfLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCfLotID.Location = New System.Drawing.Point(548, 70)
        Me.lblCfLotID.Name = "lblCfLotID"
        Me.lblCfLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblCfLotID.TabIndex = 26
        '
        'lblCfFlowClass
        '
        Me.lblCfFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCfFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCfFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCfFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCfFlowClass.Location = New System.Drawing.Point(668, 70)
        Me.lblCfFlowClass.Name = "lblCfFlowClass"
        Me.lblCfFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblCfFlowClass.TabIndex = 25
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(548, 54)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl5.TabIndex = 24
        Me.lblTtl5.Text = "CFロットID"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(312, 54)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl4.TabIndex = 23
        Me.lblTtl4.Text = "数量(Chip)"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTftChipNum
        '
        Me.lblTftChipNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTftChipNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTftChipNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTftChipNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTftChipNum.Location = New System.Drawing.Point(312, 70)
        Me.lblTftChipNum.Name = "lblTftChipNum"
        Me.lblTftChipNum.Size = New System.Drawing.Size(97, 25)
        Me.lblTftChipNum.TabIndex = 22
        Me.lblTftChipNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(216, 54)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl3.TabIndex = 21
        Me.lblTtl3.Text = "数量(WF)"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTftWfNum
        '
        Me.lblTftWfNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTftWfNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTftWfNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTftWfNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTftWfNum.Location = New System.Drawing.Point(216, 70)
        Me.lblTftWfNum.Name = "lblTftWfNum"
        Me.lblTftWfNum.Size = New System.Drawing.Size(97, 25)
        Me.lblTftWfNum.TabIndex = 20
        Me.lblTftWfNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTftCarrierID
        '
        Me.lblTftCarrierID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTftCarrierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTftCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTftCarrierID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTftCarrierID.Location = New System.Drawing.Point(16, 30)
        Me.lblTftCarrierID.Name = "lblTftCarrierID"
        Me.lblTftCarrierID.Size = New System.Drawing.Size(185, 25)
        Me.lblTftCarrierID.TabIndex = 19
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(16, 14)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl0.TabIndex = 18
        Me.lblTtl0.Text = "TFTキャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(216, 14)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl2.TabIndex = 17
        Me.lblTtl2.Text = "機種"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTftPdID
        '
        Me.lblTftPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTftPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTftPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTftPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTftPdID.Location = New System.Drawing.Point(216, 30)
        Me.lblTftPdID.Name = "lblTftPdID"
        Me.lblTftPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblTftPdID.TabIndex = 16
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(312, 14)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl7.TabIndex = 15
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTftStatus
        '
        Me.lblTftStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTftStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTftStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTftStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTftStatus.Location = New System.Drawing.Point(312, 30)
        Me.lblTftStatus.Name = "lblTftStatus"
        Me.lblTftStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblTftStatus.TabIndex = 14
        '
        'lblTftLotID
        '
        Me.lblTftLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTftLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTftLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTftLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTftLotID.Location = New System.Drawing.Point(16, 70)
        Me.lblTftLotID.Name = "lblTftLotID"
        Me.lblTftLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblTftLotID.TabIndex = 13
        '
        'lblTftFlowClass
        '
        Me.lblTftFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTftFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTftFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTftFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTftFlowClass.Location = New System.Drawing.Point(136, 70)
        Me.lblTftFlowClass.Name = "lblTftFlowClass"
        Me.lblTftFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblTftFlowClass.TabIndex = 12
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(16, 54)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 11
        Me.lblTtl1.Text = "TFTロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 91)
        Me.lblBack.TabIndex = 10
        '
        'frmxxCM00U0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.picRightAllow)
        Me.Controls.Add(Me.cmdBDown)
        Me.Controls.Add(Me.cmdADown)
        Me.Controls.Add(Me.cmdBUp)
        Me.Controls.Add(Me.cmdAUp)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdMapDownLoad)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfBeforSlotMap)
        Me.Controls.Add(Me.vsfAfterSlotMap)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.lblTtl11)
        Me.Controls.Add(Me.lblCfChipNum)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblCfWfNum)
        Me.Controls.Add(Me.lblCfCarrierID)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblCfPdID)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblCfStatus)
        Me.Controls.Add(Me.lblCfLotID)
        Me.Controls.Add(Me.lblCfFlowClass)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblTftChipNum)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblTftWfNum)
        Me.Controls.Add(Me.lblTftCarrierID)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblTftPdID)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblTftStatus)
        Me.Controls.Add(Me.lblTftLotID)
        Me.Controls.Add(Me.lblTftFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00U0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ODF貼り合せ登録"
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfBeforSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfAfterSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents picRightAllow As PictureBox
    Friend WithEvents cmdBDown As Button
    Friend WithEvents cmdADown As Button
    Friend WithEvents cmdBUp As Button
    Friend WithEvents cmdAUp As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdMapDownLoad As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfBeforSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfAfterSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Frame1 As GroupBox
    Friend WithEvents Frame2 As GroupBox
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblCfChipNum As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblCfWfNum As Label
    Friend WithEvents lblCfCarrierID As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblCfPdID As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblCfStatus As Label
    Friend WithEvents lblCfLotID As Label
    Friend WithEvents lblCfFlowClass As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTftChipNum As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTftWfNum As Label
    Friend WithEvents lblTftCarrierID As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTftPdID As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblTftStatus As Label
    Friend WithEvents lblTftLotID As Label
    Friend WithEvents lblTftFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblBack As Label
End Class
