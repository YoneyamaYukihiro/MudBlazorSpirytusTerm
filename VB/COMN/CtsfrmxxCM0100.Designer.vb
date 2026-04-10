<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM0100
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM0100))
        Me.vsfInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdSize = New System.Windows.Forms.Button()
        Me.picMax = New System.Windows.Forms.PictureBox()
        Me.picMin = New System.Windows.Forms.PictureBox()
        Me.lblSpace = New System.Windows.Forms.Label()
        CType(Me.vsfInfo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picMax,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picMin,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'vsfInfo
        '
        Me.vsfInfo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfInfo.AllowEditing = false
        Me.vsfInfo.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfInfo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfInfo.AutoResize = true
        Me.vsfInfo.AutoSearchDelay = 2R
        Me.vsfInfo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.vsfInfo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfInfo.ColumnInfo = "1,0,0,0,0,110,Columns:"
        Me.vsfInfo.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfInfo.ExtendLastCol = true
        Me.vsfInfo.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfInfo.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.vsfInfo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfInfo.Location = New System.Drawing.Point(3, 3)
        Me.vsfInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfInfo.Name = "vsfInfo"
        Me.vsfInfo.Rows.DefaultSize = 19
        Me.vsfInfo.Rows.Fixed = 0
        Me.vsfInfo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfInfo.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfInfo.Size = New System.Drawing.Size(891, 59)
        Me.vsfInfo.StyleInfo = resources.GetString("vsfInfo.StyleInfo")
        Me.vsfInfo.TabIndex = 0
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp.Location = New System.Drawing.Point(893, 2)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(49, 25)
        Me.cmdUp.TabIndex = 1
        Me.cmdUp.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(893, 38)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 25)
        Me.cmdDown.TabIndex = 2
        Me.cmdDown.Text = "▼"
        '
        'cmdSize
        '
        Me.cmdSize.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSize.Image = CType(resources.GetObject("cmdSize.Image"),System.Drawing.Image)
        Me.cmdSize.Location = New System.Drawing.Point(945, 14)
        Me.cmdSize.Name = "cmdSize"
        Me.cmdSize.Size = New System.Drawing.Size(32, 32)
        Me.cmdSize.TabIndex = 3
        '
        'picMax
        '
        Me.picMax.BackColor = System.Drawing.SystemColors.Window
        Me.picMax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picMax.Image = CType(resources.GetObject("picMax.Image"),System.Drawing.Image)
        Me.picMax.Location = New System.Drawing.Point(448, 8)
        Me.picMax.Name = "picMax"
        Me.picMax.Size = New System.Drawing.Size(32, 32)
        Me.picMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMax.TabIndex = 5
        Me.picMax.TabStop = false
        Me.picMax.Visible = false
        '
        'picMin
        '
        Me.picMin.BackColor = System.Drawing.SystemColors.Window
        Me.picMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picMin.Image = CType(resources.GetObject("picMin.Image"),System.Drawing.Image)
        Me.picMin.Location = New System.Drawing.Point(496, 8)
        Me.picMin.Name = "picMin"
        Me.picMin.Size = New System.Drawing.Size(32, 32)
        Me.picMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMin.TabIndex = 4
        Me.picMin.TabStop = false
        Me.picMin.Visible = false
        '
        'lblSpace
        '
        Me.lblSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSpace.Location = New System.Drawing.Point(892, 3)
        Me.lblSpace.Name = "lblSpace"
        Me.lblSpace.Size = New System.Drawing.Size(49, 49)
        Me.lblSpace.TabIndex = 6
        '
        'frmxxCM0100
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 93)
        Me.ControlBox = false
        Me.Controls.Add(Me.vsfInfo)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdSize)
        Me.Controls.Add(Me.picMax)
        Me.Controls.Add(Me.picMin)
        Me.Controls.Add(Me.lblSpace)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(0, 673)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM0100"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.vsfInfo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picMax,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picMin,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents vsfInfo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdSize As Button
    Friend WithEvents picMax As PictureBox
    Friend WithEvents picMin As PictureBox
    Friend WithEvents lblSpace As Label
End Class
