<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00H3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00H3))
        Me.vsfExcpList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.vsfExcpList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'vsfExcpList
        '
        Me.vsfExcpList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfExcpList.AllowEditing = false
        Me.vsfExcpList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfExcpList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfExcpList.AutoResize = true
        Me.vsfExcpList.AutoSearchDelay = 2R
        Me.vsfExcpList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfExcpList.ColumnInfo = "1,0,0,0,0,105,Columns:0{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfExcpList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfExcpList.ExtendLastCol = true
        Me.vsfExcpList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfExcpList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfExcpList.Location = New System.Drawing.Point(8, 30)
        Me.vsfExcpList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfExcpList.Name = "vsfExcpList"
        Me.vsfExcpList.Rows.DefaultSize = 18
        Me.vsfExcpList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfExcpList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfExcpList.Size = New System.Drawing.Size(367, 553)
        Me.vsfExcpList.StyleInfo = resources.GetString("vsfExcpList.StyleInfo")
        Me.vsfExcpList.TabIndex = 0
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Location = New System.Drawing.Point(290, 595)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 1
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 595)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = true
        Me.lblTitle.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(103, 15)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "<工程異常名>"
        '
        'frmxxCM00H3
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(384, 642)
        Me.Controls.Add(Me.vsfExcpList)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00H3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "工程異常名変更"
        CType(Me.vsfExcpList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents vsfExcpList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents lblTitle As Label
End Class
