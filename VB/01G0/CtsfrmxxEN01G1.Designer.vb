<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01G1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01G1))
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfWPRecipeList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitleSelectConditionID = New System.Windows.Forms.Label()
        Me.lblSelectConditionID = New System.Windows.Forms.Label()
        Me.lblCarrierID = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        CType(Me.vsfWPRecipeList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 497)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(459, 49)
        Me.cmdLeft.TabIndex = 3
        Me.cmdLeft.Text = "<<"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(467, 497)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(459, 49)
        Me.cmdRight.TabIndex = 4
        Me.cmdRight.Text = ">>"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(925, 123)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 188)
        Me.cmdUP.TabIndex = 1
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(925, 310)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 188)
        Me.cmdDown.TabIndex = 2
        Me.cmdDown.Text = "▼"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 579)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "閉じる"
        '
        'vsfWPRecipeList
        '
        Me.vsfWPRecipeList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWPRecipeList.AllowEditing = false
        Me.vsfWPRecipeList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWPRecipeList.AutoSearchDelay = 2R
        Me.vsfWPRecipeList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWPRecipeList.ColumnInfo = resources.GetString("vsfWPRecipeList.ColumnInfo")
        Me.vsfWPRecipeList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWPRecipeList.ExtendLastCol = true
        Me.vsfWPRecipeList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWPRecipeList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWPRecipeList.Location = New System.Drawing.Point(8, 124)
        Me.vsfWPRecipeList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWPRecipeList.Name = "vsfWPRecipeList"
        Me.vsfWPRecipeList.Rows.Count = 40
        Me.vsfWPRecipeList.Rows.DefaultSize = 18
        Me.vsfWPRecipeList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfWPRecipeList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWPRecipeList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfWPRecipeList.Size = New System.Drawing.Size(917, 373)
        Me.vsfWPRecipeList.StyleInfo = resources.GetString("vsfWPRecipeList.StyleInfo")
        Me.vsfWPRecipeList.TabIndex = 0
        Me.vsfWPRecipeList.TabStop = false
        '
        'lblTitleSelectConditionID
        '
        Me.lblTitleSelectConditionID.BackColor = System.Drawing.Color.Navy
        Me.lblTitleSelectConditionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleSelectConditionID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleSelectConditionID.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleSelectConditionID.Location = New System.Drawing.Point(510, 64)
        Me.lblTitleSelectConditionID.Name = "lblTitleSelectConditionID"
        Me.lblTitleSelectConditionID.Size = New System.Drawing.Size(281, 17)
        Me.lblTitleSelectConditionID.TabIndex = 7
        Me.lblTitleSelectConditionID.Text = "WF選択条件"
        Me.lblTitleSelectConditionID.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSelectConditionID
        '
        Me.lblSelectConditionID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblSelectConditionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSelectConditionID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSelectConditionID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSelectConditionID.Location = New System.Drawing.Point(510, 80)
        Me.lblSelectConditionID.Name = "lblSelectConditionID"
        Me.lblSelectConditionID.Size = New System.Drawing.Size(281, 25)
        Me.lblSelectConditionID.TabIndex = 16
        '
        'lblCarrierID
        '
        Me.lblCarrierID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrierID.Location = New System.Drawing.Point(16, 32)
        Me.lblCarrierID.Name = "lblCarrierID"
        Me.lblCarrierID.Size = New System.Drawing.Size(185, 25)
        Me.lblCarrierID.TabIndex = 15
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(16, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle0.TabIndex = 13
        Me.lblTitle0.Text = "キャリアID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(16, 80)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(185, 25)
        Me.lblLotID.TabIndex = 12
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(16, 64)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle1.TabIndex = 11
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(216, 16)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(281, 17)
        Me.lblTitle2.TabIndex = 10
        Me.lblTitle2.Text = "大工程"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(216, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID.TabIndex = 9
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(216, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 8
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(216, 64)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(281, 17)
        Me.lblTitle3.TabIndex = 6
        Me.lblTitle3.Text = "小工程"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 105)
        Me.lblBack.TabIndex = 14
        '
        'frmxxEN01G1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfWPRecipeList)
        Me.Controls.Add(Me.lblTitleSelectConditionID)
        Me.Controls.Add(Me.lblSelectConditionID)
        Me.Controls.Add(Me.lblCarrierID)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01G1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "装置レシピ表示"
        CType(Me.vsfWPRecipeList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfWPRecipeList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleSelectConditionID As Label
    Friend WithEvents lblSelectConditionID As Label
    Friend WithEvents lblCarrierID As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblBack As Label
End Class
