<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00O0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00O0))
        Me.fraParetteInfo = New System.Windows.Forms.GroupBox()
        Me.vsfCfParetteList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraParetteInfo.SuspendLayout
        CType(Me.vsfCfParetteList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraParetteInfo
        '
        Me.fraParetteInfo.Controls.Add(Me.vsfCfParetteList)
        Me.fraParetteInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraParetteInfo.Location = New System.Drawing.Point(8, 8)
        Me.fraParetteInfo.Name = "fraParetteInfo"
        Me.fraParetteInfo.Size = New System.Drawing.Size(680, 497)
        Me.fraParetteInfo.TabIndex = 1
        Me.fraParetteInfo.TabStop = false
        Me.fraParetteInfo.Text = "パレット情報"
        '
        'vsfCfParetteList
        '
        Me.vsfCfParetteList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCfParetteList.AllowEditing = false
        Me.vsfCfParetteList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfCfParetteList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfCfParetteList.AutoSearchDelay = 2R
        Me.vsfCfParetteList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCfParetteList.ColumnInfo = resources.GetString("vsfCfParetteList.ColumnInfo")
        Me.vsfCfParetteList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCfParetteList.Enabled = false
        Me.vsfCfParetteList.ExtendLastCol = true
        Me.vsfCfParetteList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCfParetteList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCfParetteList.Location = New System.Drawing.Point(8, 24)
        Me.vsfCfParetteList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCfParetteList.Name = "vsfCfParetteList"
        Me.vsfCfParetteList.Rows.Count = 19
        Me.vsfCfParetteList.Rows.DefaultSize = 18
        Me.vsfCfParetteList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfCfParetteList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCfParetteList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfCfParetteList.Size = New System.Drawing.Size(663, 460)
        Me.vsfCfParetteList.StyleInfo = resources.GetString("vsfCfParetteList.StyleInfo")
        Me.vsfCfParetteList.TabIndex = 2
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 516)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxCM00O0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(698, 582)
        Me.Controls.Add(Me.fraParetteInfo)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00O0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "パレット情報"
        Me.fraParetteInfo.ResumeLayout(false)
        CType(Me.vsfCfParetteList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraParetteInfo As GroupBox
    Friend WithEvents vsfCfParetteList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdClose As Button
End Class
