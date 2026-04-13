<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01H0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01H0))
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdLotSearch = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdProcEnd = New System.Windows.Forms.Button()
        Me.vsfUnCarryList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbThrowinWP = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        CType(Me.vsfUnCarryList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(467, 531)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(459, 49)
        Me.cmdRight.TabIndex = 6
        Me.cmdRight.Text = ">>"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 531)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(459, 49)
        Me.cmdLeft.TabIndex = 5
        Me.cmdLeft.Text = "<<"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(925, 303)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 229)
        Me.cmdDown.TabIndex = 4
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(925, 72)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 229)
        Me.cmdUP.TabIndex = 3
        Me.cmdUP.Text = "▲"
        '
        'cmdLotSearch
        '
        Me.cmdLotSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotSearch.Location = New System.Drawing.Point(637, 8)
        Me.cmdLotSearch.Name = "cmdLotSearch"
        Me.cmdLotSearch.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotSearch.TabIndex = 1
        Me.cmdLotSearch.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 582)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.Text = "閉じる"
        '
        'cmdProcEnd
        '
        Me.cmdProcEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdProcEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdProcEnd.Location = New System.Drawing.Point(764, 582)
        Me.cmdProcEnd.Name = "cmdProcEnd"
        Me.cmdProcEnd.Size = New System.Drawing.Size(105, 57)
        Me.cmdProcEnd.TabIndex = 7
        Me.cmdProcEnd.Text = "強制移載"
        '
        'vsfUnCarryList
        '
        Me.vsfUnCarryList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfUnCarryList.AllowEditing = false
        Me.vsfUnCarryList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfUnCarryList.AutoSearchDelay = 2R
        Me.vsfUnCarryList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfUnCarryList.ColumnInfo = resources.GetString("vsfUnCarryList.ColumnInfo")
        Me.vsfUnCarryList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfUnCarryList.ExtendLastCol = true
        Me.vsfUnCarryList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfUnCarryList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfUnCarryList.Location = New System.Drawing.Point(8, 73)
        Me.vsfUnCarryList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfUnCarryList.Name = "vsfUnCarryList"
        Me.vsfUnCarryList.Rows.Count = 40
        Me.vsfUnCarryList.Rows.DefaultSize = 18
        Me.vsfUnCarryList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfUnCarryList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfUnCarryList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfUnCarryList.Size = New System.Drawing.Size(917, 458)
        Me.vsfUnCarryList.StyleInfo = resources.GetString("vsfUnCarryList.StyleInfo")
        Me.vsfUnCarryList.TabIndex = 2
        '
        'cmbThrowinWP
        '
        Me.cmbThrowinWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbThrowinWP.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbThrowinWP.Location = New System.Drawing.Point(8, 24)
        Me.cmbThrowinWP.Name = "cmbThrowinWP"
        Me.cmbThrowinWP.Size = New System.Drawing.Size(419, 28)
        Me.cmbThrowinWP.TabIndex = 0
        Me.cmbThrowinWP.Value = Nothing
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(419, 17)
        Me.lblTitle7.TabIndex = 13
        Me.lblTitle7.Text = "投入装置"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(745, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 25)
        Me.lblNowDate.TabIndex = 12
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(745, 8)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 11
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(900, 24)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(74, 25)
        Me.lblLotCnt.TabIndex = 10
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(900, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle1.TabIndex = 9
        Me.lblTitle1.Text = "該当件数"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01H0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdLotSearch)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdProcEnd)
        Me.Controls.Add(Me.vsfUnCarryList)
        Me.Controls.Add(Me.cmbThrowinWP)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01H0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "投入移載一覧"
        CType(Me.vsfUnCarryList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdLotSearch As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdProcEnd As Button
    Friend WithEvents vsfUnCarryList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbThrowinWP As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle1 As Label
End Class
