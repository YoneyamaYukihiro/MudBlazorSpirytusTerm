<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02R0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02R0))
        Me.cmbPriority = New SECmbIchiran.ComboIchiran()
        Me.cmdThrowin = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfAldBatch = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbAldBatch = New SEComboBoxEx.ComboBoxEx()
        Me.cmbLotManager = New SECmbIchiran.ComboIchiran()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.labThrowInDate = New System.Windows.Forms.Label()
        Me.labStatus = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.labBatchFlowClass = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.labMoniter = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        CType(Me.vsfAldBatch,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmbPriority
        '
        Me.cmbPriority.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPriority.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPriority.Location = New System.Drawing.Point(514, 18)
        Me.cmbPriority.Name = "cmbPriority"
        Me.cmbPriority.Size = New System.Drawing.Size(89, 22)
        Me.cmbPriority.TabIndex = 1
        Me.cmbPriority.Value = Nothing
        '
        'cmdThrowin
        '
        Me.cmdThrowin.CausesValidation = false
        Me.cmdThrowin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdThrowin.Location = New System.Drawing.Point(888, 600)
        Me.cmdThrowin.Name = "cmdThrowin"
        Me.cmdThrowin.Size = New System.Drawing.Size(85, 40)
        Me.cmdThrowin.TabIndex = 6
        Me.cmdThrowin.Text = "投入"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Location = New System.Drawing.Point(760, 1)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 3
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 600)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "閉じる"
        '
        'vsfAldBatch
        '
        Me.vsfAldBatch.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfAldBatch.AllowEditing = false
        Me.vsfAldBatch.AutoSearchDelay = 2R
        Me.vsfAldBatch.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfAldBatch.ColumnInfo = resources.GetString("vsfAldBatch.ColumnInfo")
        Me.vsfAldBatch.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfAldBatch.ExtendLastCol = true
        Me.vsfAldBatch.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfAldBatch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfAldBatch.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfAldBatch.Location = New System.Drawing.Point(8, 44)
        Me.vsfAldBatch.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfAldBatch.Name = "vsfAldBatch"
        Me.vsfAldBatch.Rows.Count = 12
        Me.vsfAldBatch.Rows.DefaultSize = 18
        Me.vsfAldBatch.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfAldBatch.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfAldBatch.Size = New System.Drawing.Size(963, 554)
        Me.vsfAldBatch.StyleInfo = resources.GetString("vsfAldBatch.StyleInfo")
        Me.vsfAldBatch.TabIndex = 4
        '
        'cmbAldBatch
        '
        Me.cmbAldBatch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbAldBatch.ForeColor = System.Drawing.Color.Black
        Me.cmbAldBatch.GetCol = 2
        Me.cmbAldBatch.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbAldBatch.GridForeColor = System.Drawing.Color.Black
        Me.cmbAldBatch.Location = New System.Drawing.Point(8, 18)
        Me.cmbAldBatch.Name = "cmbAldBatch"
        Me.cmbAldBatch.Size = New System.Drawing.Size(137, 22)
        Me.cmbAldBatch.TabIndex = 0
        Me.cmbAldBatch.Value = Nothing
        '
        'cmbLotManager
        '
        Me.cmbLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.Location = New System.Drawing.Point(604, 18)
        Me.cmbLotManager.Name = "cmbLotManager"
        Me.cmbLotManager.Size = New System.Drawing.Size(137, 22)
        Me.cmbLotManager.TabIndex = 2
        Me.cmbLotManager.Value = Nothing
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(604, 2)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(137, 17)
        Me.lblTitle6.TabIndex = 17
        Me.lblTitle6.Text = "ロット担当"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(514, 2)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(89, 17)
        Me.lblTitle5.TabIndex = 16
        Me.lblTitle5.Text = "優先度"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labThrowInDate
        '
        Me.labThrowInDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labThrowInDate.Location = New System.Drawing.Point(146, 18)
        Me.labThrowInDate.Name = "labThrowInDate"
        Me.labThrowInDate.Size = New System.Drawing.Size(105, 22)
        Me.labThrowInDate.TabIndex = 9
        Me.labThrowInDate.Text = "2018/08/01"
        '
        'labStatus
        '
        Me.labStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labStatus.Location = New System.Drawing.Point(424, 18)
        Me.labStatus.Name = "labStatus"
        Me.labStatus.Size = New System.Drawing.Size(89, 22)
        Me.labStatus.TabIndex = 15
        Me.labStatus.Text = "投入待ち"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(424, 2)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(89, 17)
        Me.lblTitle4.TabIndex = 14
        Me.lblTitle4.Text = "状　態"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labBatchFlowClass
        '
        Me.labBatchFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labBatchFlowClass.Location = New System.Drawing.Point(310, 18)
        Me.labBatchFlowClass.Name = "labBatchFlowClass"
        Me.labBatchFlowClass.Size = New System.Drawing.Size(113, 22)
        Me.labBatchFlowClass.TabIndex = 13
        Me.labBatchFlowClass.Text = "製品"
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(310, 2)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(113, 17)
        Me.lblTitle3.TabIndex = 12
        Me.lblTitle3.Text = "バッチ流動区分"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(252, 2)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(57, 17)
        Me.lblTitle2.TabIndex = 10
        Me.lblTitle2.Text = "モニタ"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(146, 2)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(105, 17)
        Me.lblTitle1.TabIndex = 8
        Me.lblTitle1.Text = "投入予定日"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 2)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(137, 17)
        Me.lblTitle0.TabIndex = 7
        Me.lblTitle0.Text = "バッチ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labMoniter
        '
        Me.labMoniter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labMoniter.Location = New System.Drawing.Point(252, 18)
        Me.labMoniter.Name = "labMoniter"
        Me.labMoniter.Size = New System.Drawing.Size(57, 22)
        Me.labMoniter.TabIndex = 11
        Me.labMoniter.Text = "有"
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(846, 2)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle7.TabIndex = 18
        Me.lblTitle7.Text = "情報取得日時"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(846, 18)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 19
        Me.lblNowDate.Text = "08/01 16:30:25"
        '
        'frmxxEN02R0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblTitle6)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.cmbPriority)
        Me.Controls.Add(Me.cmdThrowin)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfAldBatch)
        Me.Controls.Add(Me.cmbAldBatch)
        Me.Controls.Add(Me.cmbLotManager)
        Me.Controls.Add(Me.labThrowInDate)
        Me.Controls.Add(Me.labStatus)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.labBatchFlowClass)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.labMoniter)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblNowDate)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02R0"
        Me.Text = "ロット投入(ALD)"
        CType(Me.vsfAldBatch,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmbPriority As SECmbIchiran.ComboIchiran
    Friend WithEvents cmdThrowin As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfAldBatch As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbAldBatch As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbLotManager As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents labThrowInDate As Label
    Friend WithEvents labStatus As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents labBatchFlowClass As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents labMoniter As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblNowDate As Label
End Class
