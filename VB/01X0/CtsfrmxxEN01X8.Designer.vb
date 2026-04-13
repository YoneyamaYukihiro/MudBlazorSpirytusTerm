<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01X8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01X8))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraFrame = New System.Windows.Forms.GroupBox()
        Me.vsfWpRestrict = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraFrame.SuspendLayout
        CType(Me.vsfWpRestrict,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 264)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(332, 264)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 1
        Me.cmdRegist.Text = "確　定"
        '
        'fraFrame
        '
        Me.fraFrame.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraFrame.Controls.Add(Me.vsfWpRestrict)
        Me.fraFrame.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraFrame.Location = New System.Drawing.Point(8, 8)
        Me.fraFrame.Name = "fraFrame"
        Me.fraFrame.Size = New System.Drawing.Size(411, 247)
        Me.fraFrame.TabIndex = 0
        Me.fraFrame.TabStop = false
        '
        'vsfWpRestrict
        '
        Me.vsfWpRestrict.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWpRestrict.AllowEditing = false
        Me.vsfWpRestrict.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWpRestrict.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfWpRestrict.AutoSearchDelay = 2R
        Me.vsfWpRestrict.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWpRestrict.ColumnInfo = resources.GetString("vsfWpRestrict.ColumnInfo")
        Me.vsfWpRestrict.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWpRestrict.ExtendLastCol = true
        Me.vsfWpRestrict.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWpRestrict.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWpRestrict.Location = New System.Drawing.Point(6, 14)
        Me.vsfWpRestrict.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWpRestrict.Name = "vsfWpRestrict"
        Me.vsfWpRestrict.Rows.Count = 11
        Me.vsfWpRestrict.Rows.DefaultSize = 18
        Me.vsfWpRestrict.Rows.MaxSize = 27
        Me.vsfWpRestrict.Rows.MinSize = 20
        Me.vsfWpRestrict.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWpRestrict.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfWpRestrict.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None
        Me.vsfWpRestrict.Size = New System.Drawing.Size(400, 221)
        Me.vsfWpRestrict.StyleInfo = resources.GetString("vsfWpRestrict.StyleInfo")
        Me.vsfWpRestrict.TabIndex = 0
        '
        'frmxxEN01X8
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(428, 310)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.fraFrame)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(370, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01X8"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "号機記憶工程一覧"
        Me.fraFrame.ResumeLayout(false)
        CType(Me.vsfWpRestrict,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraFrame As GroupBox
    Friend WithEvents vsfWpRestrict As C1.Win.C1FlexGrid.C1FlexGrid
End Class
