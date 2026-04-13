<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02V0
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02V0))
		Me.cmdJigSelect = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.cmdRegist = New System.Windows.Forms.Button()
		Me.fraJMaskSet = New System.Windows.Forms.GroupBox()
		Me.vsfJMaskSetList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.fraJMaskSet.SuspendLayout
		CType(Me.vsfJMaskSetList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'cmdJigSelect
		'
		Me.cmdJigSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJigSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJigSelect.Location = New System.Drawing.Point(735, 562)
		Me.cmdJigSelect.Name = "cmdJigSelect"
		Me.cmdJigSelect.Size = New System.Drawing.Size(105, 57)
		Me.cmdJigSelect.TabIndex = 2
		Me.cmdJigSelect.Text = "空治具"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(12, 562)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(105, 57)
		Me.cmdClose.TabIndex = 4
		Me.cmdClose.Text = "閉じる"
		'
		'cmdRegist
		'
		Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdRegist.Location = New System.Drawing.Point(868, 562)
		Me.cmdRegist.Name = "cmdRegist"
		Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
		Me.cmdRegist.TabIndex = 3
		Me.cmdRegist.Text = "確　定"
		'
		'fraJMaskSet
		'
		Me.fraJMaskSet.Controls.Add(Me.vsfJMaskSetList)
		Me.fraJMaskSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraJMaskSet.Location = New System.Drawing.Point(12, 12)
		Me.fraJMaskSet.Name = "fraJMaskSet"
		Me.fraJMaskSet.Size = New System.Drawing.Size(961, 474)
		Me.fraJMaskSet.TabIndex = 0
		Me.fraJMaskSet.TabStop = false
		Me.fraJMaskSet.Text = "組立対象"
		'
		'vsfJMaskSetList
		'
		Me.vsfJMaskSetList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfJMaskSetList.AllowEditing = false
		Me.vsfJMaskSetList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfJMaskSetList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfJMaskSetList.AutoSearchDelay = 2R
		Me.vsfJMaskSetList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfJMaskSetList.ColumnInfo = resources.GetString("vsfJMaskSetList.ColumnInfo")
		Me.vsfJMaskSetList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfJMaskSetList.ExtendLastCol = true
		Me.vsfJMaskSetList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfJMaskSetList.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.vsfJMaskSetList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfJMaskSetList.Location = New System.Drawing.Point(15, 41)
		Me.vsfJMaskSetList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfJMaskSetList.Name = "vsfJMaskSetList"
		Me.vsfJMaskSetList.Rows.Count = 11
		Me.vsfJMaskSetList.Rows.DefaultSize = 38
		Me.vsfJMaskSetList.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfJMaskSetList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfJMaskSetList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
		Me.vsfJMaskSetList.Size = New System.Drawing.Size(937, 420)
		Me.vsfJMaskSetList.StyleInfo = resources.GetString("vsfJMaskSetList.StyleInfo")
		Me.vsfJMaskSetList.TabIndex = 1
		'
		'frmxxEN02V0
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(985, 642)
		Me.Controls.Add(Me.cmdJigSelect)
		Me.Controls.Add(Me.fraJMaskSet)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.cmdRegist)
		Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN02V0"
		Me.Text = "蒸着マスク組立"
		Me.fraJMaskSet.ResumeLayout(false)
		CType(Me.vsfJMaskSetList,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdJigSelect As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
	Friend WithEvents fraJMaskSet As GroupBox
	Friend WithEvents vsfJMaskSetList As C1.Win.C1FlexGrid.C1FlexGrid
End Class
