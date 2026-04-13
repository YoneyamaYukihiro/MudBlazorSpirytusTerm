<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01S1
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01S1))
		Me.cmdCancel = New System.Windows.Forms.Button()
		Me.cmdRegist = New System.Windows.Forms.Button()
		Me.cmdCommentUp = New System.Windows.Forms.Button()
		Me.cmdCommentDown = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.txtComment = New SETextBoxEx.TextBoxEx()
		Me.txtGlobalDept = New SETextBoxEx.TextBoxEx()
		Me.txtPrOrderID = New SETextBoxEx.TextBoxEx()
		Me.txtCostCode = New SETextBoxEx.TextBoxEx()
		Me.lblTitle2 = New System.Windows.Forms.Label()
		Me.lblTitle5 = New System.Windows.Forms.Label()
		Me.lblTitle6 = New System.Windows.Forms.Label()
		Me.lblPrOrderName = New System.Windows.Forms.Label()
		Me.lblBack = New System.Windows.Forms.Label()
		Me.lblTitle1 = New System.Windows.Forms.Label()
		Me.lblLengthCount = New System.Windows.Forms.Label()
		Me.lblTitle0 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'cmdCancel
		'
		Me.cmdCancel.CausesValidation = false
		Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdCancel.Location = New System.Drawing.Point(474, 350)
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdCancel.Size = New System.Drawing.Size(85, 40)
		Me.cmdCancel.TabIndex = 5
		Me.cmdCancel.Text = "全部取消"
		'
		'cmdRegist
		'
		Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdRegist.Location = New System.Drawing.Point(666, 350)
		Me.cmdRegist.Name = "cmdRegist"
		Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
		Me.cmdRegist.TabIndex = 4
		Me.cmdRegist.Text = "確　定"
		'
		'cmdCommentUp
		'
		Me.cmdCommentUp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCommentUp.Location = New System.Drawing.Point(726, 130)
		Me.cmdCommentUp.Name = "cmdCommentUp"
		Me.cmdCommentUp.Size = New System.Drawing.Size(25, 103)
		Me.cmdCommentUp.TabIndex = 6
		Me.cmdCommentUp.Text = "▲"
		'
		'cmdCommentDown
		'
		Me.cmdCommentDown.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCommentDown.Location = New System.Drawing.Point(726, 233)
		Me.cmdCommentDown.Name = "cmdCommentDown"
		Me.cmdCommentDown.Size = New System.Drawing.Size(25, 103)
		Me.cmdCommentDown.TabIndex = 7
		Me.cmdCommentDown.Text = "▼"
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(8, 350)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(85, 40)
		Me.cmdClose.TabIndex = 8
		Me.cmdClose.Text = "閉じる"
		'
		'txtComment
		'
		Me.txtComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtComment.ChrMaxByte = 2048
		Me.txtComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
		Me.txtComment.GotHighLight = false
		Me.txtComment.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtComment.Location = New System.Drawing.Point(8, 148)
		Me.txtComment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
		Me.txtComment.MultiLineEx = true
		Me.txtComment.Name = "txtComment"
		Me.txtComment.NgChr = "'"
		Me.txtComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtComment.SelectedText = ""
		Me.txtComment.Size = New System.Drawing.Size(718, 187)
		Me.txtComment.TabIndex = 3
		'
		'txtGlobalDept
		'
		Me.txtGlobalDept.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtGlobalDept.ChrMaxByte = 30
		Me.txtGlobalDept.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtGlobalDept.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
		Me.txtGlobalDept.ImeMode = System.Windows.Forms.ImeMode.[On]
		Me.txtGlobalDept.Location = New System.Drawing.Point(8, 98)
		Me.txtGlobalDept.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
		Me.txtGlobalDept.Name = "txtGlobalDept"
		Me.txtGlobalDept.NgChr = "'"
		Me.txtGlobalDept.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtGlobalDept.NumMax = New Decimal(New Integer() {9999999, 0, 0, 0})
		Me.txtGlobalDept.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
		Me.txtGlobalDept.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtGlobalDept.SelectedText = ""
		Me.txtGlobalDept.Size = New System.Drawing.Size(254, 22)
		Me.txtGlobalDept.TabIndex = 1
		'
		'txtPrOrderID
		'
		Me.txtPrOrderID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtPrOrderID.ChrMaxByte = 10
		Me.txtPrOrderID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtPrOrderID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtPrOrderID.ImeMode = System.Windows.Forms.ImeMode.[On]
		Me.txtPrOrderID.Location = New System.Drawing.Point(21, 38)
		Me.txtPrOrderID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
		Me.txtPrOrderID.Name = "txtPrOrderID"
		Me.txtPrOrderID.NgChr = "'"
		Me.txtPrOrderID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_1_Decimal
		Me.txtPrOrderID.NumMax = New Decimal(New Integer() {9999999, 0, 0, 0})
		Me.txtPrOrderID.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
		Me.txtPrOrderID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtPrOrderID.SelectedText = ""
		Me.txtPrOrderID.Size = New System.Drawing.Size(119, 22)
		Me.txtPrOrderID.TabIndex = 0
		'
		'txtCostCode
		'
		Me.txtCostCode.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtCostCode.ChrMaxByte = 8
		Me.txtCostCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtCostCode.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtCostCode.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.txtCostCode.Location = New System.Drawing.Point(282, 98)
		Me.txtCostCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
		Me.txtCostCode.Name = "txtCostCode"
		Me.txtCostCode.NgChr = "'"
		Me.txtCostCode.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_1_Decimal
		Me.txtCostCode.NumMax = New Decimal(New Integer() {9999999, 0, 0, 0})
		Me.txtCostCode.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
		Me.txtCostCode.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtCostCode.SelectedText = ""
		Me.txtCostCode.Size = New System.Drawing.Size(101, 22)
		Me.txtCostCode.TabIndex = 2
		'
		'lblTitle2
		'
		Me.lblTitle2.BackColor = System.Drawing.Color.Navy
		Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle2.Location = New System.Drawing.Point(282, 81)
		Me.lblTitle2.Name = "lblTitle2"
		Me.lblTitle2.Size = New System.Drawing.Size(101, 17)
		Me.lblTitle2.TabIndex = 16
		Me.lblTitle2.Text = "原価コード"
		Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle5
		'
		Me.lblTitle5.BackColor = System.Drawing.Color.Navy
		Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle5.Location = New System.Drawing.Point(21, 21)
		Me.lblTitle5.Name = "lblTitle5"
		Me.lblTitle5.Size = New System.Drawing.Size(119, 17)
		Me.lblTitle5.TabIndex = 15
		Me.lblTitle5.Text = "P/Rオーダー"
		Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle6
		'
		Me.lblTitle6.BackColor = System.Drawing.Color.Navy
		Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle6.Location = New System.Drawing.Point(140, 21)
		Me.lblTitle6.Name = "lblTitle6"
		Me.lblTitle6.Size = New System.Drawing.Size(124, 17)
		Me.lblTitle6.TabIndex = 14
		Me.lblTitle6.Text = "P/R区分"
		Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblPrOrderName
		'
		Me.lblPrOrderName.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblPrOrderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblPrOrderName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblPrOrderName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblPrOrderName.Location = New System.Drawing.Point(140, 38)
		Me.lblPrOrderName.Name = "lblPrOrderName"
		Me.lblPrOrderName.Size = New System.Drawing.Size(124, 22)
		Me.lblPrOrderName.TabIndex = 13
		Me.lblPrOrderName.Text = "Pオーダー"
		'
		'lblBack
		'
		Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblBack.Location = New System.Drawing.Point(8, 12)
		Me.lblBack.Name = "lblBack"
		Me.lblBack.Size = New System.Drawing.Size(745, 57)
		Me.lblBack.TabIndex = 12
		'
		'lblTitle1
		'
		Me.lblTitle1.BackColor = System.Drawing.Color.Navy
		Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle1.Location = New System.Drawing.Point(8, 81)
		Me.lblTitle1.Name = "lblTitle1"
		Me.lblTitle1.Size = New System.Drawing.Size(254, 17)
		Me.lblTitle1.TabIndex = 11
		Me.lblTitle1.Text = "設定部門"
		Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblLengthCount
		'
		Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
		Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
		Me.lblLengthCount.Location = New System.Drawing.Point(460, 132)
		Me.lblLengthCount.Name = "lblLengthCount"
		Me.lblLengthCount.Size = New System.Drawing.Size(249, 15)
		Me.lblLengthCount.TabIndex = 10
		Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
		Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle0
		'
		Me.lblTitle0.BackColor = System.Drawing.Color.Navy
		Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle0.Location = New System.Drawing.Point(8, 131)
		Me.lblTitle0.Name = "lblTitle0"
		Me.lblTitle0.Size = New System.Drawing.Size(718, 17)
		Me.lblTitle0.TabIndex = 9
		Me.lblTitle0.Text = "オーダーコメント"
		Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'frmxxEN01S1
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(762, 397)
		Me.Controls.Add(Me.cmdCancel)
		Me.Controls.Add(Me.cmdRegist)
		Me.Controls.Add(Me.cmdCommentUp)
		Me.Controls.Add(Me.cmdCommentDown)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.txtComment)
		Me.Controls.Add(Me.txtGlobalDept)
		Me.Controls.Add(Me.txtPrOrderID)
		Me.Controls.Add(Me.txtCostCode)
		Me.Controls.Add(Me.lblTitle2)
		Me.Controls.Add(Me.lblTitle5)
		Me.Controls.Add(Me.lblTitle6)
		Me.Controls.Add(Me.lblPrOrderName)
		Me.Controls.Add(Me.lblBack)
		Me.Controls.Add(Me.lblTitle1)
		Me.Controls.Add(Me.lblLengthCount)
		Me.Controls.Add(Me.lblTitle0)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN01S1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "P/Rオーダー登録"
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdCommentUp As Button
    Friend WithEvents cmdCommentDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtComment As SETextBoxEx.TextBoxEx
    Friend WithEvents txtGlobalDept As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPrOrderID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCostCode As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblPrOrderName As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle0 As Label
End Class
