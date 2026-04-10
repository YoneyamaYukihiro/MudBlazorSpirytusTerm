<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00S1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00S1))
        Me.fraMail = New System.Windows.Forms.GroupBox()
        Me.vsfMailList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdEmpDown = New System.Windows.Forms.Button()
        Me.cmdEmpUp = New System.Windows.Forms.Button()
        Me.cmdDeptUp = New System.Windows.Forms.Button()
        Me.cmdDeptDown = New System.Windows.Forms.Button()
        Me.cmdChoice = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfDeptList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfEmpList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraMail.SuspendLayout
        CType(Me.vsfMailList,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfDeptList,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfEmpList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraMail
        '
        Me.fraMail.Controls.Add(Me.vsfMailList)
        Me.fraMail.Location = New System.Drawing.Point(122, 586)
        Me.fraMail.Name = "fraMail"
        Me.fraMail.Size = New System.Drawing.Size(255, 55)
        Me.fraMail.TabIndex = 8
        Me.fraMail.TabStop = false
        Me.fraMail.Text = "内部で使用しています。削除しないで下さい。"
        Me.fraMail.Visible = false
        '
        'vsfMailList
        '
        Me.vsfMailList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMailList.AllowEditing = false
        Me.vsfMailList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMailList.AutoSearchDelay = 2R
        Me.vsfMailList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMailList.ColumnInfo = resources.GetString("vsfMailList.ColumnInfo")
        Me.vsfMailList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMailList.ExtendLastCol = true
        Me.vsfMailList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfMailList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMailList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMailList.Location = New System.Drawing.Point(4, 14)
        Me.vsfMailList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMailList.Name = "vsfMailList"
        Me.vsfMailList.Rows.Count = 1
        Me.vsfMailList.Rows.DefaultSize = 18
        Me.vsfMailList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMailList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMailList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfMailList.Size = New System.Drawing.Size(117, 37)
        Me.vsfMailList.StyleInfo = resources.GetString("vsfMailList.StyleInfo")
        Me.vsfMailList.TabIndex = 9
        '
        'cmdEmpDown
        '
        Me.cmdEmpDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEmpDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEmpDown.Location = New System.Drawing.Point(923, 280)
        Me.cmdEmpDown.Name = "cmdEmpDown"
        Me.cmdEmpDown.Size = New System.Drawing.Size(49, 274)
        Me.cmdEmpDown.TabIndex = 5
        Me.cmdEmpDown.Text = "▼"
        '
        'cmdEmpUp
        '
        Me.cmdEmpUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEmpUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEmpUp.Location = New System.Drawing.Point(923, 7)
        Me.cmdEmpUp.Name = "cmdEmpUp"
        Me.cmdEmpUp.Size = New System.Drawing.Size(49, 274)
        Me.cmdEmpUp.TabIndex = 4
        Me.cmdEmpUp.Text = "▲"
        '
        'cmdDeptUp
        '
        Me.cmdDeptUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDeptUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDeptUp.Location = New System.Drawing.Point(329, 7)
        Me.cmdDeptUp.Name = "cmdDeptUp"
        Me.cmdDeptUp.Size = New System.Drawing.Size(49, 274)
        Me.cmdDeptUp.TabIndex = 1
        Me.cmdDeptUp.Text = "▲"
        '
        'cmdDeptDown
        '
        Me.cmdDeptDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDeptDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDeptDown.Location = New System.Drawing.Point(329, 280)
        Me.cmdDeptDown.Name = "cmdDeptDown"
        Me.cmdDeptDown.Size = New System.Drawing.Size(49, 274)
        Me.cmdDeptDown.TabIndex = 2
        Me.cmdDeptDown.Text = "▼"
        '
        'cmdChoice
        '
        Me.cmdChoice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChoice.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChoice.Location = New System.Drawing.Point(871, 575)
        Me.cmdChoice.Name = "cmdChoice"
        Me.cmdChoice.Size = New System.Drawing.Size(105, 57)
        Me.cmdChoice.TabIndex = 6
        Me.cmdChoice.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 575)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "閉じる"
        '
        'vsfDeptList
        '
        Me.vsfDeptList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfDeptList.AllowEditing = false
        Me.vsfDeptList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfDeptList.AutoSearchDelay = 2R
        Me.vsfDeptList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfDeptList.ColumnInfo = resources.GetString("vsfDeptList.ColumnInfo")
        Me.vsfDeptList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfDeptList.ExtendLastCol = true
        Me.vsfDeptList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfDeptList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfDeptList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfDeptList.Location = New System.Drawing.Point(8, 8)
        Me.vsfDeptList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfDeptList.Name = "vsfDeptList"
        Me.vsfDeptList.Rows.Count = 40
        Me.vsfDeptList.Rows.DefaultSize = 18
        Me.vsfDeptList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfDeptList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfDeptList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfDeptList.Size = New System.Drawing.Size(321, 545)
        Me.vsfDeptList.StyleInfo = resources.GetString("vsfDeptList.StyleInfo")
        Me.vsfDeptList.TabIndex = 0
        '
        'vsfEmpList
        '
        Me.vsfEmpList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfEmpList.AllowEditing = false
        Me.vsfEmpList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfEmpList.AutoSearchDelay = 2R
        Me.vsfEmpList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfEmpList.ColumnInfo = resources.GetString("vsfEmpList.ColumnInfo")
        Me.vsfEmpList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfEmpList.ExtendLastCol = true
        Me.vsfEmpList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfEmpList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfEmpList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfEmpList.Location = New System.Drawing.Point(394, 8)
        Me.vsfEmpList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfEmpList.Name = "vsfEmpList"
        Me.vsfEmpList.Rows.Count = 40
        Me.vsfEmpList.Rows.DefaultSize = 18
        Me.vsfEmpList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfEmpList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfEmpList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfEmpList.Size = New System.Drawing.Size(529, 545)
        Me.vsfEmpList.StyleInfo = resources.GetString("vsfEmpList.StyleInfo")
        Me.vsfEmpList.TabIndex = 3
        '
        'frmxxCM00S1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.fraMail)
        Me.Controls.Add(Me.cmdEmpDown)
        Me.Controls.Add(Me.cmdEmpUp)
        Me.Controls.Add(Me.cmdDeptUp)
        Me.Controls.Add(Me.cmdDeptDown)
        Me.Controls.Add(Me.cmdChoice)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfDeptList)
        Me.Controls.Add(Me.vsfEmpList)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00S1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "宛先選択"
        Me.fraMail.ResumeLayout(false)
        CType(Me.vsfMailList,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfDeptList,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfEmpList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraMail As GroupBox
    Friend WithEvents vsfMailList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdEmpDown As Button
    Friend WithEvents cmdEmpUp As Button
    Friend WithEvents cmdDeptUp As Button
    Friend WithEvents cmdDeptDown As Button
    Friend WithEvents cmdChoice As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfDeptList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfEmpList As C1.Win.C1FlexGrid.C1FlexGrid
End Class
