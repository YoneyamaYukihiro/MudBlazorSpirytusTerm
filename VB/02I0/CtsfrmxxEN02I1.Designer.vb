<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02I1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02I1))
        Me.fraLot2 = New System.Windows.Forms.GroupBox()
        Me.vsfLot2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraLot1 = New System.Windows.Forms.GroupBox()
        Me.vsfLot1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdPrev = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.fraLot0 = New System.Windows.Forms.GroupBox()
        Me.vsfLot0 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbLotList = New SECmbIchiran.ComboIchiran()
        Me.lblSecPriority = New System.Windows.Forms.Label()
        Me.lblPastStep = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.fraLot2.SuspendLayout
        CType(Me.vsfLot2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraLot1.SuspendLayout
        CType(Me.vsfLot1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraLot0.SuspendLayout
        CType(Me.vsfLot0,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraLot2
        '
        Me.fraLot2.Controls.Add(Me.vsfLot2)
        Me.fraLot2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot2.Location = New System.Drawing.Point(656, 52)
        Me.fraLot2.Name = "fraLot2"
        Me.fraLot2.Size = New System.Drawing.Size(315, 537)
        Me.fraLot2.TabIndex = 3
        Me.fraLot2.TabStop = false
        Me.fraLot2.Text = "ロット№1235467890　優先度：5"
        '
        'vsfLot2
        '
        Me.vsfLot2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLot2.AllowEditing = false
        Me.vsfLot2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLot2.AutoResize = true
        Me.vsfLot2.AutoSearchDelay = 2R
        Me.vsfLot2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLot2.ColumnInfo = resources.GetString("vsfLot2.ColumnInfo")
        Me.vsfLot2.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLot2.ExtendLastCol = true
        Me.vsfLot2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLot2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLot2.Location = New System.Drawing.Point(8, 20)
        Me.vsfLot2.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLot2.Name = "vsfLot2"
        Me.vsfLot2.Rows.Count = 30
        Me.vsfLot2.Rows.DefaultSize = 18
        Me.vsfLot2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfLot2.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLot2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLot2.Size = New System.Drawing.Size(299, 509)
        Me.vsfLot2.StyleInfo = resources.GetString("vsfLot2.StyleInfo")
        Me.vsfLot2.TabIndex = 3
        '
        'fraLot1
        '
        Me.fraLot1.Controls.Add(Me.vsfLot1)
        Me.fraLot1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot1.Location = New System.Drawing.Point(332, 52)
        Me.fraLot1.Name = "fraLot1"
        Me.fraLot1.Size = New System.Drawing.Size(315, 537)
        Me.fraLot1.TabIndex = 2
        Me.fraLot1.TabStop = false
        Me.fraLot1.Text = "ロット№1235467890　優先度：5"
        '
        'vsfLot1
        '
        Me.vsfLot1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLot1.AllowEditing = false
        Me.vsfLot1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLot1.AutoResize = true
        Me.vsfLot1.AutoSearchDelay = 2R
        Me.vsfLot1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLot1.ColumnInfo = resources.GetString("vsfLot1.ColumnInfo")
        Me.vsfLot1.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLot1.ExtendLastCol = true
        Me.vsfLot1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLot1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLot1.Location = New System.Drawing.Point(8, 20)
        Me.vsfLot1.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLot1.Name = "vsfLot1"
        Me.vsfLot1.Rows.Count = 30
        Me.vsfLot1.Rows.DefaultSize = 18
        Me.vsfLot1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfLot1.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLot1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLot1.Size = New System.Drawing.Size(299, 509)
        Me.vsfLot1.StyleInfo = resources.GetString("vsfLot1.StyleInfo")
        Me.vsfLot1.TabIndex = 2
        '
        'cmdPrev
        '
        Me.cmdPrev.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPrev.Location = New System.Drawing.Point(792, 597)
        Me.cmdPrev.Name = "cmdPrev"
        Me.cmdPrev.Size = New System.Drawing.Size(85, 40)
        Me.cmdPrev.TabIndex = 5
        Me.cmdPrev.Text = "前へ"
        '
        'cmdNext
        '
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNext.Location = New System.Drawing.Point(888, 597)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(85, 40)
        Me.cmdNext.TabIndex = 6
        Me.cmdNext.Text = "次へ"
        '
        'fraLot0
        '
        Me.fraLot0.Controls.Add(Me.vsfLot0)
        Me.fraLot0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot0.Location = New System.Drawing.Point(8, 52)
        Me.fraLot0.Name = "fraLot0"
        Me.fraLot0.Size = New System.Drawing.Size(315, 537)
        Me.fraLot0.TabIndex = 1
        Me.fraLot0.TabStop = false
        Me.fraLot0.Text = "ロット№1235467890　優先度：5"
        '
        'vsfLot0
        '
        Me.vsfLot0.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLot0.AllowEditing = false
        Me.vsfLot0.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLot0.AutoResize = true
        Me.vsfLot0.AutoSearchDelay = 2R
        Me.vsfLot0.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLot0.ColumnInfo = resources.GetString("vsfLot0.ColumnInfo")
        Me.vsfLot0.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLot0.ExtendLastCol = true
        Me.vsfLot0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLot0.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLot0.Location = New System.Drawing.Point(8, 20)
        Me.vsfLot0.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLot0.Name = "vsfLot0"
        Me.vsfLot0.Rows.Count = 30
        Me.vsfLot0.Rows.DefaultSize = 18
        Me.vsfLot0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfLot0.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLot0.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLot0.Size = New System.Drawing.Size(299, 509)
        Me.vsfLot0.StyleInfo = resources.GetString("vsfLot0.StyleInfo")
        Me.vsfLot0.TabIndex = 1
        '
        'cmdClose
        '
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "閉じる"
        '
        'cmbLotList
        '
        Me.cmbLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotList.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotList.GridForeColor = System.Drawing.Color.Black
        Me.cmbLotList.Location = New System.Drawing.Point(8, 20)
        Me.cmbLotList.Name = "cmbLotList"
        Me.cmbLotList.Size = New System.Drawing.Size(209, 22)
        Me.cmbLotList.TabIndex = 0
        Me.cmbLotList.TabStop = false
        Me.cmbLotList.Value = Nothing
        '
        'lblSecPriority
        '
        Me.lblSecPriority.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblSecPriority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSecPriority.ForeColor = System.Drawing.Color.Black
        Me.lblSecPriority.Location = New System.Drawing.Point(868, 24)
        Me.lblSecPriority.Name = "lblSecPriority"
        Me.lblSecPriority.Size = New System.Drawing.Size(105, 17)
        Me.lblSecPriority.TabIndex = 12
        Me.lblSecPriority.Text = "区間優先工程"
        Me.lblSecPriority.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblSecPriority.UseMnemonic = false
        '
        'lblPastStep
        '
        Me.lblPastStep.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPastStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPastStep.ForeColor = System.Drawing.Color.Black
        Me.lblPastStep.Location = New System.Drawing.Point(868, 8)
        Me.lblPastStep.Name = "lblPastStep"
        Me.lblPastStep.Size = New System.Drawing.Size(105, 17)
        Me.lblPastStep.TabIndex = 11
        Me.lblPastStep.Text = "流動済み工程"
        Me.lblPastStep.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 4)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(209, 17)
        Me.lblTitle0.TabIndex = 7
        Me.lblTitle0.Text = "表示ロット選択"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02I1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.fraLot2)
        Me.Controls.Add(Me.fraLot1)
        Me.Controls.Add(Me.cmdPrev)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.fraLot0)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmbLotList)
        Me.Controls.Add(Me.lblSecPriority)
        Me.Controls.Add(Me.lblPastStep)
        Me.Controls.Add(Me.lblTitle0)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(341, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02I1"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "区間優先設定詳細"
        Me.fraLot2.ResumeLayout(false)
        CType(Me.vsfLot2,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraLot1.ResumeLayout(false)
        CType(Me.vsfLot1,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraLot0.ResumeLayout(false)
        CType(Me.vsfLot0,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraLot2 As GroupBox
    Friend WithEvents vsfLot2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraLot1 As GroupBox
    Friend WithEvents vsfLot1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdPrev As Button
    Friend WithEvents cmdNext As Button
    Friend WithEvents fraLot0 As GroupBox
    Friend WithEvents vsfLot0 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmbLotList As SECmbIchiran.ComboIchiran
    Friend WithEvents lblSecPriority As Label
    Friend WithEvents lblPastStep As Label
    Friend WithEvents lblTitle0 As Label
End Class
