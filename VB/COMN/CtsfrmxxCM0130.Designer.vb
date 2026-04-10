<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM0130
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM0130))
		Me.cmdChoice = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.cmdJigList = New System.Windows.Forms.Button()
		Me.vsfJigList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.cmbJigClass = New SEComboBoxEx.ComboBoxEx()
		Me.cmbPanelKind = New SEComboBoxEx.ComboBoxEx()
		Me.lblTitle5 = New System.Windows.Forms.Label()
		Me.lblTitle6 = New System.Windows.Forms.Label()
		Me.lblLotCnt = New System.Windows.Forms.Label()
		Me.lblNowDate = New System.Windows.Forms.Label()
		Me.lblTitle3 = New System.Windows.Forms.Label()
		Me.lblTitle2 = New System.Windows.Forms.Label()
		Me.lblBg = New System.Windows.Forms.Label()
		Me.lblTitle7 = New System.Windows.Forms.Label()
		Me.cmbJJigCategory = New SEComboBoxEx.ComboBoxEx()
		CType(Me.vsfJigList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'cmdChoice
		'
		Me.cmdChoice.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdChoice.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdChoice.Location = New System.Drawing.Point(605, 403)
		Me.cmdChoice.Name = "cmdChoice"
		Me.cmdChoice.Size = New System.Drawing.Size(86, 43)
		Me.cmdChoice.TabIndex = 1
		Me.cmdChoice.Text = "確　定"
		'
		'cmdClose
		'
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(8, 403)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(86, 43)
		Me.cmdClose.TabIndex = 3
		Me.cmdClose.Text = "閉じる"
		'
		'cmdJigList
		'
		Me.cmdJigList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJigList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJigList.Location = New System.Drawing.Point(383, 17)
		Me.cmdJigList.Name = "cmdJigList"
		Me.cmdJigList.Size = New System.Drawing.Size(86, 43)
		Me.cmdJigList.TabIndex = 0
		Me.cmdJigList.Text = "最新取得"
		'
		'vsfJigList
		'
		Me.vsfJigList.AllowEditing = false
		Me.vsfJigList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfJigList.AutoResize = true
		Me.vsfJigList.AutoSearchDelay = 2R
		Me.vsfJigList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfJigList.ColumnInfo = resources.GetString("vsfJigList.ColumnInfo")
		Me.vsfJigList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfJigList.ExtendLastCol = true
		Me.vsfJigList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfJigList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfJigList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfJigList.Location = New System.Drawing.Point(8, 80)
		Me.vsfJigList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfJigList.Name = "vsfJigList"
		Me.vsfJigList.Rows.Count = 40
		Me.vsfJigList.Rows.DefaultSize = 18
		Me.vsfJigList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfJigList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfJigList.Size = New System.Drawing.Size(683, 310)
		Me.vsfJigList.StyleInfo = resources.GetString("vsfJigList.StyleInfo")
		Me.vsfJigList.TabIndex = 2
		'
		'cmbJigClass
		'
		Me.cmbJigClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJigClass.GetCol = 1
		Me.cmbJigClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJigClass.Location = New System.Drawing.Point(14, 39)
		Me.cmbJigClass.Name = "cmbJigClass"
		Me.cmbJigClass.Size = New System.Drawing.Size(107, 22)
		Me.cmbJigClass.TabIndex = 9
		Me.cmbJigClass.Value = Nothing
		'
		'cmbPanelKind
		'
		Me.cmbPanelKind.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbPanelKind.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbPanelKind.Location = New System.Drawing.Point(125, 39)
		Me.cmbPanelKind.Name = "cmbPanelKind"
		Me.cmbPanelKind.Size = New System.Drawing.Size(106, 22)
		Me.cmbPanelKind.TabIndex = 10
		Me.cmbPanelKind.Value = Nothing
		'
		'lblTitle5
		'
		Me.lblTitle5.BackColor = System.Drawing.Color.Navy
		Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle5.Location = New System.Drawing.Point(14, 22)
		Me.lblTitle5.Name = "lblTitle5"
		Me.lblTitle5.Size = New System.Drawing.Size(107, 17)
		Me.lblTitle5.TabIndex = 12
		Me.lblTitle5.Text = "治具識別"
		Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle6
		'
		Me.lblTitle6.BackColor = System.Drawing.Color.Navy
		Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle6.Location = New System.Drawing.Point(125, 22)
		Me.lblTitle6.Name = "lblTitle6"
		Me.lblTitle6.Size = New System.Drawing.Size(106, 17)
		Me.lblTitle6.TabIndex = 11
		Me.lblTitle6.Text = "パネル識別"
		Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblLotCnt
		'
		Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblLotCnt.Location = New System.Drawing.Point(598, 36)
		Me.lblLotCnt.Name = "lblLotCnt"
		Me.lblLotCnt.Size = New System.Drawing.Size(81, 22)
		Me.lblLotCnt.TabIndex = 7
		Me.lblLotCnt.Text = "0"
		Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblNowDate
		'
		Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate.Location = New System.Drawing.Point(472, 36)
		Me.lblNowDate.Name = "lblNowDate"
		Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
		Me.lblNowDate.TabIndex = 6
		Me.lblNowDate.Text = "07/15 13:11:25"
		'
		'lblTitle3
		'
		Me.lblTitle3.BackColor = System.Drawing.Color.Navy
		Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle3.Location = New System.Drawing.Point(598, 20)
		Me.lblTitle3.Name = "lblTitle3"
		Me.lblTitle3.Size = New System.Drawing.Size(81, 17)
		Me.lblTitle3.TabIndex = 5
		Me.lblTitle3.Text = "該当件数"
		Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle2
		'
		Me.lblTitle2.BackColor = System.Drawing.Color.Navy
		Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle2.Location = New System.Drawing.Point(472, 20)
		Me.lblTitle2.Name = "lblTitle2"
		Me.lblTitle2.Size = New System.Drawing.Size(122, 17)
		Me.lblTitle2.TabIndex = 4
		Me.lblTitle2.Text = "情報取得日時"
		Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblBg
		'
		Me.lblBg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblBg.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblBg.Location = New System.Drawing.Point(8, 8)
		Me.lblBg.Name = "lblBg"
		Me.lblBg.Size = New System.Drawing.Size(683, 65)
		Me.lblBg.TabIndex = 8
		'
		'lblTitle7
		'
		Me.lblTitle7.BackColor = System.Drawing.Color.Navy
		Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle7.Location = New System.Drawing.Point(237, 22)
		Me.lblTitle7.Name = "lblTitle7"
		Me.lblTitle7.Size = New System.Drawing.Size(140, 17)
		Me.lblTitle7.TabIndex = 11
		Me.lblTitle7.Text = "蒸着治具カテゴリ"
		Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmbJJigCategory
		'
		Me.cmbJJigCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJJigCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJJigCategory.Location = New System.Drawing.Point(237, 38)
		Me.cmbJJigCategory.Name = "cmbJJigCategory"
		Me.cmbJJigCategory.Size = New System.Drawing.Size(140, 22)
		Me.cmbJJigCategory.TabIndex = 10
		Me.cmbJJigCategory.Value = Nothing
		'
		'frmxxCM0130
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(699, 458)
		Me.Controls.Add(Me.lblTitle7)
		Me.Controls.Add(Me.lblTitle6)
		Me.Controls.Add(Me.lblTitle5)
		Me.Controls.Add(Me.cmdChoice)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.cmdJigList)
		Me.Controls.Add(Me.vsfJigList)
		Me.Controls.Add(Me.cmbJigClass)
		Me.Controls.Add(Me.cmbJJigCategory)
		Me.Controls.Add(Me.cmbPanelKind)
		Me.Controls.Add(Me.lblLotCnt)
		Me.Controls.Add(Me.lblNowDate)
		Me.Controls.Add(Me.lblTitle3)
		Me.Controls.Add(Me.lblTitle2)
		Me.Controls.Add(Me.lblBg)
		Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxCM0130"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "空治具一覧"
		CType(Me.vsfJigList,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdChoice As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdJigList As Button
    Friend WithEvents vsfJigList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbJigClass As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPanelKind As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblBg As Label
	Friend WithEvents lblTitle7 As Label
	Friend WithEvents cmbJJigCategory As SEComboBoxEx.ComboBoxEx
End Class
