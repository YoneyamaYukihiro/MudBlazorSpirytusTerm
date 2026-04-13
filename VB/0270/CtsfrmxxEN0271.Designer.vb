<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0271
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0271))
        Me.cmdAddRow = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraFrame = New System.Windows.Forms.GroupBox()
        Me.vsfWfAction = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraFrame.SuspendLayout
        CType(Me.vsfWfAction,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdAddRow
        '
        Me.cmdAddRow.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAddRow.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAddRow.Location = New System.Drawing.Point(236, 264)
        Me.cmdAddRow.Name = "cmdAddRow"
        Me.cmdAddRow.Size = New System.Drawing.Size(85, 40)
        Me.cmdAddRow.TabIndex = 4
        Me.cmdAddRow.Text = "行追加"
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
        Me.fraFrame.Controls.Add(Me.vsfWfAction)
        Me.fraFrame.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraFrame.Location = New System.Drawing.Point(8, 8)
        Me.fraFrame.Name = "fraFrame"
        Me.fraFrame.Size = New System.Drawing.Size(411, 247)
        Me.fraFrame.TabIndex = 0
        Me.fraFrame.TabStop = false
        '
        'vsfWfAction
        '
        Me.vsfWfAction.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWfAction.AllowEditing = false
        Me.vsfWfAction.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWfAction.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfWfAction.AutoSearchDelay = 2R
        Me.vsfWfAction.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWfAction.ColumnInfo = resources.GetString("vsfWfAction.ColumnInfo")
        Me.vsfWfAction.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWfAction.ExtendLastCol = true
        Me.vsfWfAction.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWfAction.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.vsfWfAction.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWfAction.Location = New System.Drawing.Point(6, 14)
        Me.vsfWfAction.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWfAction.Name = "vsfWfAction"
        Me.vsfWfAction.Rows.Count = 11
        Me.vsfWfAction.Rows.DefaultSize = 18
        Me.vsfWfAction.Rows.MaxSize = 27
        Me.vsfWfAction.Rows.MinSize = 20
        Me.vsfWfAction.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWfAction.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfWfAction.Size = New System.Drawing.Size(400, 222)
        Me.vsfWfAction.StyleInfo = resources.GetString("vsfWfAction.StyleInfo")
        Me.vsfWfAction.TabIndex = 0
        '
        'frmxxEN0271
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(428, 310)
        Me.Controls.Add(Me.cmdAddRow)
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
        Me.Name = "frmxxEN0271"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WF指定アクション予約"
        Me.fraFrame.ResumeLayout(false)
        CType(Me.vsfWfAction,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdAddRow As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraFrame As GroupBox
    Friend WithEvents vsfWfAction As C1.Win.C1FlexGrid.C1FlexGrid
End Class
