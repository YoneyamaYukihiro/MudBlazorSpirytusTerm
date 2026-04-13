<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01Y1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01Y1))
        Me.cmdAllSelect = New System.Windows.Forms.Button()
        Me.cmdAllCancel = New System.Windows.Forms.Button()
        Me.vsfWFMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdPrintCancel = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfChipMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblCarrierID = New System.Windows.Forms.Label()
        Me.lblPartCodeTitle = New System.Windows.Forms.Label()
        Me.lblPartCode = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblWFNoTitle = New System.Windows.Forms.Label()
        Me.lblLotIDTitle = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblCarrierIDTitle = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblOpNameTitle = New System.Windows.Forms.Label()
        Me.lblOpName = New System.Windows.Forms.Label()
        Me.lblStepName = New System.Windows.Forms.Label()
        Me.lblStepNameTitle = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.lblWFPicture2 = New System.Windows.Forms.Label()
        Me.lblWFPicture = New System.Windows.Forms.Label()
        CType(Me.vsfWFMap,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfChipMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdAllSelect
        '
        Me.cmdAllSelect.CausesValidation = false
        Me.cmdAllSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllSelect.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAllSelect.Location = New System.Drawing.Point(105, 585)
        Me.cmdAllSelect.Name = "cmdAllSelect"
        Me.cmdAllSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdAllSelect.TabIndex = 2
        Me.cmdAllSelect.Text = "全選択"
        '
        'cmdAllCancel
        '
        Me.cmdAllCancel.CausesValidation = false
        Me.cmdAllCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAllCancel.Location = New System.Drawing.Point(201, 585)
        Me.cmdAllCancel.Name = "cmdAllCancel"
        Me.cmdAllCancel.Size = New System.Drawing.Size(85, 40)
        Me.cmdAllCancel.TabIndex = 3
        Me.cmdAllCancel.Text = "全取消"
        '
        'vsfWFMap
        '
        Me.vsfWFMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWFMap.AllowEditing = false
        Me.vsfWFMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWFMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfWFMap.AutoResize = true
        Me.vsfWFMap.AutoSearchDelay = 2R
        Me.vsfWFMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWFMap.ColumnInfo = resources.GetString("vsfWFMap.ColumnInfo")
        Me.vsfWFMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWFMap.ExtendLastCol = true
        Me.vsfWFMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfWFMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWFMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWFMap.Location = New System.Drawing.Point(8, 50)
        Me.vsfWFMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWFMap.Name = "vsfWFMap"
        Me.vsfWFMap.Rows.Count = 26
        Me.vsfWFMap.Rows.DefaultSize = 18
        Me.vsfWFMap.Rows.MinSize = 20
        Me.vsfWFMap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfWFMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWFMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfWFMap.Size = New System.Drawing.Size(144, 522)
        Me.vsfWFMap.StyleInfo = resources.GetString("vsfWFMap.StyleInfo")
        Me.vsfWFMap.TabIndex = 0
        '
        'cmdPrintCancel
        '
        Me.cmdPrintCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPrintCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdPrintCancel.Location = New System.Drawing.Point(778, 585)
        Me.cmdPrintCancel.Name = "cmdPrintCancel"
        Me.cmdPrintCancel.Size = New System.Drawing.Size(85, 40)
        Me.cmdPrintCancel.TabIndex = 4
        Me.cmdPrintCancel.Text = "星取表"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"印刷中止"
        '
        'cmdPrint
        '
        Me.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPrint.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(885, 585)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(85, 40)
        Me.cmdPrint.TabIndex = 5
        Me.cmdPrint.Text = "星取表"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"印刷"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 585)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "閉じる"
        '
        'vsfChipMap
        '
        Me.vsfChipMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfChipMap.AllowEditing = false
        Me.vsfChipMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfChipMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfChipMap.AutoSearchDelay = 2R
        Me.vsfChipMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfChipMap.ColumnInfo = resources.GetString("vsfChipMap.ColumnInfo")
        Me.vsfChipMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfChipMap.ExtendLastCol = true
        Me.vsfChipMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfChipMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfChipMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfChipMap.Location = New System.Drawing.Point(159, 101)
        Me.vsfChipMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfChipMap.Name = "vsfChipMap"
        Me.vsfChipMap.Rows.Count = 20
        Me.vsfChipMap.Rows.DefaultSize = 18
        Me.vsfChipMap.Rows.MinSize = 24
        Me.vsfChipMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfChipMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfChipMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfChipMap.Size = New System.Drawing.Size(796, 482)
        Me.vsfChipMap.StyleInfo = resources.GetString("vsfChipMap.StyleInfo")
        Me.vsfChipMap.TabIndex = 1
        '
        'lblCarrierID
        '
        Me.lblCarrierID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrierID.Location = New System.Drawing.Point(93, 11)
        Me.lblCarrierID.Name = "lblCarrierID"
        Me.lblCarrierID.Size = New System.Drawing.Size(73, 28)
        Me.lblCarrierID.TabIndex = 22
        Me.lblCarrierID.Text = "A12345"
        '
        'lblPartCodeTitle
        '
        Me.lblPartCodeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPartCodeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartCodeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPartCodeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPartCodeTitle.Location = New System.Drawing.Point(291, 50)
        Me.lblPartCodeTitle.Name = "lblPartCodeTitle"
        Me.lblPartCodeTitle.Size = New System.Drawing.Size(202, 17)
        Me.lblPartCodeTitle.TabIndex = 19
        Me.lblPartCodeTitle.Text = "部品コード"
        Me.lblPartCodeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPartCode
        '
        Me.lblPartCode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPartCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPartCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPartCode.Location = New System.Drawing.Point(291, 66)
        Me.lblPartCode.Name = "lblPartCode"
        Me.lblPartCode.Size = New System.Drawing.Size(202, 28)
        Me.lblPartCode.TabIndex = 18
        Me.lblPartCode.Text = "L3P14Y-50G00T002A"
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(159, 66)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(133, 28)
        Me.lblWFNo.TabIndex = 17
        Me.lblWFNo.Text = "NQHX006#01"
        '
        'lblWFNoTitle
        '
        Me.lblWFNoTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWFNoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNoTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWFNoTitle.Location = New System.Drawing.Point(159, 50)
        Me.lblWFNoTitle.Name = "lblWFNoTitle"
        Me.lblWFNoTitle.Size = New System.Drawing.Size(133, 17)
        Me.lblWFNoTitle.TabIndex = 16
        Me.lblWFNoTitle.Text = "ウェハ№"
        Me.lblWFNoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotIDTitle
        '
        Me.lblLotIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotIDTitle.Location = New System.Drawing.Point(162, 11)
        Me.lblLotIDTitle.Name = "lblLotIDTitle"
        Me.lblLotIDTitle.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.lblLotIDTitle.Size = New System.Drawing.Size(71, 28)
        Me.lblLotIDTitle.TabIndex = 15
        Me.lblLotIDTitle.Text = "ロットID"
        Me.lblLotIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblLotIDTitle.UseCompatibleTextRendering = true
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(339, 11)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(31, 28)
        Me.lblFlowClass.TabIndex = 14
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblCarrierIDTitle
        '
        Me.lblCarrierIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCarrierIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCarrierIDTitle.Location = New System.Drawing.Point(11, 11)
        Me.lblCarrierIDTitle.Name = "lblCarrierIDTitle"
        Me.lblCarrierIDTitle.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.lblCarrierIDTitle.Size = New System.Drawing.Size(85, 28)
        Me.lblCarrierIDTitle.TabIndex = 13
        Me.lblCarrierIDTitle.Text = "キャリアID"
        Me.lblCarrierIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblCarrierIDTitle.UseCompatibleTextRendering = true
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(232, 11)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(112, 28)
        Me.lblLotID.TabIndex = 12
        Me.lblLotID.Text = "GTA1234-00"
        '
        'lblOpNameTitle
        '
        Me.lblOpNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblOpNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblOpNameTitle.Location = New System.Drawing.Point(366, 11)
        Me.lblOpNameTitle.Name = "lblOpNameTitle"
        Me.lblOpNameTitle.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.lblOpNameTitle.Size = New System.Drawing.Size(58, 28)
        Me.lblOpNameTitle.TabIndex = 11
        Me.lblOpNameTitle.Text = "大工程"
        Me.lblOpNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpName
        '
        Me.lblOpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpName.Location = New System.Drawing.Point(423, 11)
        Me.lblOpName.Name = "lblOpName"
        Me.lblOpName.Size = New System.Drawing.Size(239, 28)
        Me.lblOpName.TabIndex = 10
        Me.lblOpName.Text = "投入"
        '
        'lblStepName
        '
        Me.lblStepName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepName.Location = New System.Drawing.Point(718, 11)
        Me.lblStepName.Name = "lblStepName"
        Me.lblStepName.Size = New System.Drawing.Size(245, 28)
        Me.lblStepName.TabIndex = 9
        Me.lblStepName.Text = "ﾅﾝﾊﾞﾘﾝｸﾞ"
        '
        'lblStepNameTitle
        '
        Me.lblStepNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblStepNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblStepNameTitle.Location = New System.Drawing.Point(661, 11)
        Me.lblStepNameTitle.Name = "lblStepNameTitle"
        Me.lblStepNameTitle.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.lblStepNameTitle.Size = New System.Drawing.Size(58, 28)
        Me.lblStepNameTitle.TabIndex = 8
        Me.lblStepNameTitle.Text = "小工程"
        Me.lblStepNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Location = New System.Drawing.Point(5, 6)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(960, 38)
        Me.lblBack.TabIndex = 7
        '
        'lblWFPicture2
        '
        Me.lblWFPicture2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFPicture2.Location = New System.Drawing.Point(780, 80)
        Me.lblWFPicture2.Name = "lblWFPicture2"
        Me.lblWFPicture2.Size = New System.Drawing.Size(10, 8)
        Me.lblWFPicture2.TabIndex = 23
        Me.lblWFPicture2.Text = "△"
        Me.lblWFPicture2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFPicture
        '
        Me.lblWFPicture.Font = New System.Drawing.Font("ＭＳ ゴシック", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFPicture.Location = New System.Drawing.Point(760, 60)
        Me.lblWFPicture.Name = "lblWFPicture"
        Me.lblWFPicture.Size = New System.Drawing.Size(49, 34)
        Me.lblWFPicture.TabIndex = 24
        Me.lblWFPicture.Text = "○"
        '
        'frmxxEN01Y1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(984, 641)
        Me.Controls.Add(Me.lblWFPicture2)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.cmdAllSelect)
        Me.Controls.Add(Me.cmdAllCancel)
        Me.Controls.Add(Me.vsfWFMap)
        Me.Controls.Add(Me.cmdPrintCancel)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfChipMap)
        Me.Controls.Add(Me.lblCarrierID)
        Me.Controls.Add(Me.lblPartCodeTitle)
        Me.Controls.Add(Me.lblPartCode)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblWFNoTitle)
        Me.Controls.Add(Me.lblLotIDTitle)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblCarrierIDTitle)
        Me.Controls.Add(Me.lblOpNameTitle)
        Me.Controls.Add(Me.lblOpName)
        Me.Controls.Add(Me.lblStepName)
        Me.Controls.Add(Me.lblStepNameTitle)
        Me.Controls.Add(Me.lblBack)
        Me.Controls.Add(Me.lblWFPicture)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01Y1"
        Me.Text = "星取表表示"
        CType(Me.vsfWFMap,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfChipMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdAllSelect As Button
    Friend WithEvents cmdAllCancel As Button
    Friend WithEvents vsfWFMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdPrintCancel As Button
    Friend WithEvents cmdPrint As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfChipMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblCarrierID As Label
    Friend WithEvents lblPartCodeTitle As Label
    Friend WithEvents lblPartCode As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblWFNoTitle As Label
    Friend WithEvents lblLotIDTitle As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblCarrierIDTitle As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblOpNameTitle As Label
    Friend WithEvents lblOpName As Label
    Friend WithEvents lblStepName As Label
    Friend WithEvents lblStepNameTitle As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents lblWFPicture2 As Label
    Friend WithEvents lblWFPicture As Label
End Class
