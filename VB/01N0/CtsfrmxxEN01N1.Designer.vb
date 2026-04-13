<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01N1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01N1))
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.vsfCmpEventList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.lblListCnt = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.fraRireki = New System.Windows.Forms.GroupBox()
        Me.vsfCmpNowList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Frame1.SuspendLayout
        CType(Me.vsfCmpEventList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraRireki.SuspendLayout
        CType(Me.vsfCmpNowList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.cmdUp)
        Me.Frame1.Controls.Add(Me.cmdDown)
        Me.Frame1.Controls.Add(Me.vsfCmpEventList)
        Me.Frame1.Controls.Add(Me.txtComments)
        Me.Frame1.Controls.Add(Me.lblListCnt)
        Me.Frame1.Controls.Add(Me.lblTitle0)
        Me.Frame1.Controls.Add(Me.lblTtl1)
        Me.Frame1.Location = New System.Drawing.Point(8, 124)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(885, 470)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = false
        Me.Frame1.Text = "メンテナンス履歴"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Location = New System.Drawing.Point(849, 350)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(25, 55)
        Me.cmdUp.TabIndex = 3
        Me.cmdUp.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Location = New System.Drawing.Point(849, 405)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(25, 55)
        Me.cmdDown.TabIndex = 4
        Me.cmdDown.Text = "▼"
        '
        'vsfCmpEventList
        '
        Me.vsfCmpEventList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCmpEventList.AllowEditing = false
        Me.vsfCmpEventList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfCmpEventList.AutoSearchDelay = 2R
        Me.vsfCmpEventList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCmpEventList.ColumnInfo = resources.GetString("vsfCmpEventList.ColumnInfo")
        Me.vsfCmpEventList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCmpEventList.ExtendLastCol = true
        Me.vsfCmpEventList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCmpEventList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCmpEventList.Location = New System.Drawing.Point(12, 66)
        Me.vsfCmpEventList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCmpEventList.Name = "vsfCmpEventList"
        Me.vsfCmpEventList.Rows.Count = 4
        Me.vsfCmpEventList.Rows.DefaultSize = 18
        Me.vsfCmpEventList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCmpEventList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfCmpEventList.Size = New System.Drawing.Size(861, 274)
        Me.vsfCmpEventList.StyleInfo = resources.GetString("vsfCmpEventList.StyleInfo")
        Me.vsfCmpEventList.TabIndex = 0
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 0
        Me.txtComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtComments.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtComments.GotHighLight = false
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtComments.Location = New System.Drawing.Point(12, 367)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(837, 93)
        Me.txtComments.TabIndex = 2
        Me.txtComments.TabStop = false
        '
        'lblListCnt
        '
        Me.lblListCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblListCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblListCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblListCnt.Location = New System.Drawing.Point(800, 36)
        Me.lblListCnt.Name = "lblListCnt"
        Me.lblListCnt.Size = New System.Drawing.Size(74, 22)
        Me.lblListCnt.TabIndex = 10
        Me.lblListCnt.Text = "0"
        Me.lblListCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(800, 21)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle0.TabIndex = 9
        Me.lblTitle0.Text = "該当件数"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(12, 350)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(837, 17)
        Me.lblTtl1.TabIndex = 8
        Me.lblTtl1.Text = "メンテナンスコメント"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraRireki
        '
        Me.fraRireki.Controls.Add(Me.vsfCmpNowList)
        Me.fraRireki.Location = New System.Drawing.Point(8, 6)
        Me.fraRireki.Name = "fraRireki"
        Me.fraRireki.Size = New System.Drawing.Size(885, 106)
        Me.fraRireki.TabIndex = 1
        Me.fraRireki.TabStop = false
        Me.fraRireki.Text = "現在状態"
        '
        'vsfCmpNowList
        '
        Me.vsfCmpNowList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCmpNowList.AllowEditing = false
        Me.vsfCmpNowList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfCmpNowList.AutoSearchDelay = 2R
        Me.vsfCmpNowList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCmpNowList.ColumnInfo = resources.GetString("vsfCmpNowList.ColumnInfo")
        Me.vsfCmpNowList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCmpNowList.ExtendLastCol = true
        Me.vsfCmpNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCmpNowList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCmpNowList.Location = New System.Drawing.Point(10, 22)
        Me.vsfCmpNowList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCmpNowList.Name = "vsfCmpNowList"
        Me.vsfCmpNowList.Rows.Count = 4
        Me.vsfCmpNowList.Rows.DefaultSize = 18
        Me.vsfCmpNowList.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.vsfCmpNowList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCmpNowList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfCmpNowList.Size = New System.Drawing.Size(863, 59)
        Me.vsfCmpNowList.StyleInfo = resources.GetString("vsfCmpNowList.StyleInfo")
        Me.vsfCmpNowList.TabIndex = 1
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 598)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxEN01N1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(902, 642)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.fraRireki)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01N1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "メンテナンス履歴確認"
        Me.Frame1.ResumeLayout(false)
        CType(Me.vsfCmpEventList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraRireki.ResumeLayout(false)
        CType(Me.vsfCmpNowList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents Frame1 As GroupBox
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents vsfCmpEventList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblListCnt As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents fraRireki As GroupBox
    Friend WithEvents vsfCmpNowList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdClose As Button
End Class
