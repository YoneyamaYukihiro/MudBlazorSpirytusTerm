<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00FA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00FA))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraWFInfo = New System.Windows.Forms.GroupBox()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblChipForwardQuantity = New System.Windows.Forms.Label()
        Me.lblChipMarkQuantity = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblChipOutQuantity = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblChipQuantity = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.fraWFInfo.SuspendLayout
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 524)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "閉じる"
        '
        'fraWFInfo
        '
        Me.fraWFInfo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraWFInfo.Controls.Add(Me.vsfSlotMap)
        Me.fraWFInfo.Controls.Add(Me.lblTitle5)
        Me.fraWFInfo.Controls.Add(Me.lblChipForwardQuantity)
        Me.fraWFInfo.Controls.Add(Me.lblChipMarkQuantity)
        Me.fraWFInfo.Controls.Add(Me.lblTitle4)
        Me.fraWFInfo.Controls.Add(Me.lblChipOutQuantity)
        Me.fraWFInfo.Controls.Add(Me.lblTitle3)
        Me.fraWFInfo.Controls.Add(Me.lblChipQuantity)
        Me.fraWFInfo.Controls.Add(Me.lblTitle2)
        Me.fraWFInfo.Controls.Add(Me.lblFlowClass)
        Me.fraWFInfo.Controls.Add(Me.lblLotID)
        Me.fraWFInfo.Controls.Add(Me.lblTitle0)
        Me.fraWFInfo.Controls.Add(Me.lblTitle1)
        Me.fraWFInfo.Controls.Add(Me.lblCarrier)
        Me.fraWFInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraWFInfo.Location = New System.Drawing.Point(8, 8)
        Me.fraWFInfo.Name = "fraWFInfo"
        Me.fraWFInfo.Size = New System.Drawing.Size(796, 505)
        Me.fraWFInfo.TabIndex = 0
        Me.fraWFInfo.TabStop = false
        Me.fraWFInfo.Text = "WF情報"
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
        Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap.Location = New System.Drawing.Point(277, 20)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 26
        Me.vsfSlotMap.Rows.DefaultSize = 18
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap.Size = New System.Drawing.Size(507, 470)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 1
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(12, 124)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(97, 22)
        Me.lblTitle5.TabIndex = 15
        Me.lblTitle5.Text = "払出ﾁｯﾌﾟ計"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipForwardQuantity
        '
        Me.lblChipForwardQuantity.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblChipForwardQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipForwardQuantity.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipForwardQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipForwardQuantity.Location = New System.Drawing.Point(109, 124)
        Me.lblChipForwardQuantity.Name = "lblChipForwardQuantity"
        Me.lblChipForwardQuantity.Size = New System.Drawing.Size(104, 22)
        Me.lblChipForwardQuantity.TabIndex = 14
        Me.lblChipForwardQuantity.Text = "2000"
        Me.lblChipForwardQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblChipMarkQuantity
        '
        Me.lblChipMarkQuantity.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblChipMarkQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipMarkQuantity.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipMarkQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipMarkQuantity.Location = New System.Drawing.Point(109, 148)
        Me.lblChipMarkQuantity.Name = "lblChipMarkQuantity"
        Me.lblChipMarkQuantity.Size = New System.Drawing.Size(104, 22)
        Me.lblChipMarkQuantity.TabIndex = 13
        Me.lblChipMarkQuantity.Text = "2000"
        Me.lblChipMarkQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(12, 148)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(97, 22)
        Me.lblTitle4.TabIndex = 12
        Me.lblTitle4.Text = "傾向ﾁｯﾌﾟ計"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipOutQuantity
        '
        Me.lblChipOutQuantity.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblChipOutQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipOutQuantity.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipOutQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipOutQuantity.Location = New System.Drawing.Point(109, 100)
        Me.lblChipOutQuantity.Name = "lblChipOutQuantity"
        Me.lblChipOutQuantity.Size = New System.Drawing.Size(104, 22)
        Me.lblChipOutQuantity.TabIndex = 11
        Me.lblChipOutQuantity.Text = "2000"
        Me.lblChipOutQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(12, 100)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(97, 22)
        Me.lblTitle3.TabIndex = 10
        Me.lblTitle3.Text = "不良ﾁｯﾌﾟ計"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipQuantity
        '
        Me.lblChipQuantity.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblChipQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChipQuantity.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChipQuantity.Location = New System.Drawing.Point(109, 76)
        Me.lblChipQuantity.Name = "lblChipQuantity"
        Me.lblChipQuantity.Size = New System.Drawing.Size(104, 22)
        Me.lblChipQuantity.TabIndex = 9
        Me.lblChipQuantity.Text = "2000"
        Me.lblChipQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(12, 76)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(97, 22)
        Me.lblTitle2.TabIndex = 8
        Me.lblTitle2.Text = "良品ﾁｯﾌﾟ計"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(214, 36)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(55, 22)
        Me.lblFlowClass.TabIndex = 6
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(110, 36)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(105, 22)
        Me.lblLotID.TabIndex = 5
        Me.lblLotID.Text = "UXHA001S00"
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(12, 20)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(98, 17)
        Me.lblTitle0.TabIndex = 4
        Me.lblTitle0.Text = "キャリアID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(110, 20)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(159, 17)
        Me.lblTitle1.TabIndex = 3
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCarrier
        '
        Me.lblCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrier.Location = New System.Drawing.Point(12, 36)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(99, 22)
        Me.lblCarrier.TabIndex = 2
        Me.lblCarrier.Text = "AKJ001"
        '
        'frmxxEN00FA
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(812, 574)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraWFInfo)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(370, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00FA"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WF情報"
        Me.fraWFInfo.ResumeLayout(false)
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdClose As Button
    Friend WithEvents fraWFInfo As GroupBox
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblChipForwardQuantity As Label
    Friend WithEvents lblChipMarkQuantity As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblChipOutQuantity As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblChipQuantity As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblCarrier As Label
End Class
