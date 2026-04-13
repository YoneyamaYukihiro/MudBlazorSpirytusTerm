<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01U1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01U1))
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtRecipeID = New SETextBoxEx.TextBoxEx()
        Me.vsfRecipeList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblBg = New System.Windows.Forms.Label()
        CType(Me.vsfRecipeList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(402, 16)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(105, 57)
        Me.cmdSearch.TabIndex = 5
        Me.cmdSearch.Text = "検　索"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(514, 327)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 242)
        Me.cmdDown.TabIndex = 2
        Me.cmdDown.TabStop = false
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(514, 85)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 242)
        Me.cmdUP.TabIndex = 1
        Me.cmdUP.TabStop = false
        Me.cmdUP.Text = "▲"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(458, 578)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 3
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 578)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "閉じる"
        '
        'txtRecipeID
        '
        Me.txtRecipeID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtRecipeID.ChrMaxByte = 40
        Me.txtRecipeID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtRecipeID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtRecipeID.Location = New System.Drawing.Point(18, 36)
        Me.txtRecipeID.Name = "txtRecipeID"
        Me.txtRecipeID.NgChr = "'"
        Me.txtRecipeID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtRecipeID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRecipeID.SelectedText = ""
        Me.txtRecipeID.Size = New System.Drawing.Size(344, 29)
        Me.txtRecipeID.TabIndex = 4
        '
        'vsfRecipeList
        '
        Me.vsfRecipeList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfRecipeList.AllowEditing = false
        Me.vsfRecipeList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfRecipeList.AutoResize = true
        Me.vsfRecipeList.AutoSearchDelay = 2R
        Me.vsfRecipeList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfRecipeList.ColumnInfo = resources.GetString("vsfRecipeList.ColumnInfo")
        Me.vsfRecipeList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfRecipeList.ExtendLastCol = true
        Me.vsfRecipeList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfRecipeList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfRecipeList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfRecipeList.Location = New System.Drawing.Point(8, 86)
        Me.vsfRecipeList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfRecipeList.Name = "vsfRecipeList"
        Me.vsfRecipeList.Rows.Count = 20
        Me.vsfRecipeList.Rows.DefaultSize = 18
        Me.vsfRecipeList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfRecipeList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfRecipeList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfRecipeList.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None
        Me.vsfRecipeList.Size = New System.Drawing.Size(506, 482)
        Me.vsfRecipeList.StyleInfo = resources.GetString("vsfRecipeList.StyleInfo")
        Me.vsfRecipeList.TabIndex = 0
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(18, 20)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(344, 17)
        Me.lblTtl0.TabIndex = 7
        Me.lblTtl0.Text = "レシピ"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBg
        '
        Me.lblBg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBg.Location = New System.Drawing.Point(8, 8)
        Me.lblBg.Name = "lblBg"
        Me.lblBg.Size = New System.Drawing.Size(505, 71)
        Me.lblBg.TabIndex = 8
        '
        'frmxxEN01U1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(571, 642)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtRecipeID)
        Me.Controls.Add(Me.vsfRecipeList)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblBg)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01U1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "レシピ一覧"
        CType(Me.vsfRecipeList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtRecipeID As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfRecipeList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblBg As Label
End Class
