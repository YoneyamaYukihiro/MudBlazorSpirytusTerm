<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02D1
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02D1))
		Me.cmdSet = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.txtJigID = New SETextBoxEx.TextBoxEx()
		Me.lblTtl0 = New System.Windows.Forms.Label()
		Me.cmbJJigCategory = New SEComboBoxEx.ComboBoxEx()
		Me.lblTitle12 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'cmdSet
		'
		Me.cmdSet.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdSet.Location = New System.Drawing.Point(201, 128)
		Me.cmdSet.Name = "cmdSet"
		Me.cmdSet.Size = New System.Drawing.Size(129, 57)
		Me.cmdSet.TabIndex = 1
		Me.cmdSet.Text = "確　定"
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(31, 128)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(129, 57)
		Me.cmdClose.TabIndex = 2
		Me.cmdClose.Text = "閉じる"
		'
		'txtJigID
		'
		Me.txtJigID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtJigID.ChrMaxByte = 10
		Me.txtJigID.Font = New System.Drawing.Font("ＭＳ ゴシック", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtJigID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtJigID.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtJigID.Location = New System.Drawing.Point(86, 77)
		Me.txtJigID.Name = "txtJigID"
		Me.txtJigID.NgChr = "'"
		Me.txtJigID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtJigID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtJigID.SelectedText = ""
		Me.txtJigID.Size = New System.Drawing.Size(185, 36)
		Me.txtJigID.TabIndex = 0
		'
		'lblTtl0
		'
		Me.lblTtl0.BackColor = System.Drawing.Color.Navy
		Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl0.Location = New System.Drawing.Point(86, 61)
		Me.lblTtl0.Name = "lblTtl0"
		Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
		Me.lblTtl0.TabIndex = 3
		Me.lblTtl0.Text = "治具ID"
		Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmbJJigCategory
		'
		Me.cmbJJigCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJJigCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJJigCategory.Location = New System.Drawing.Point(12, 25)
		Me.cmbJJigCategory.Name = "cmbJJigCategory"
		Me.cmbJJigCategory.Size = New System.Drawing.Size(139, 22)
		Me.cmbJJigCategory.TabIndex = 54
		Me.cmbJJigCategory.Value = Nothing
		'
		'lblTitle12
		'
		Me.lblTitle12.BackColor = System.Drawing.Color.Navy
		Me.lblTitle12.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle12.Location = New System.Drawing.Point(12, 9)
		Me.lblTitle12.Name = "lblTitle12"
		Me.lblTitle12.Size = New System.Drawing.Size(139, 17)
		Me.lblTitle12.TabIndex = 53
		Me.lblTitle12.Text = "蒸着治具カテゴリ"
		Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'frmxxEN02D1
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(363, 197)
		Me.Controls.Add(Me.cmbJJigCategory)
		Me.Controls.Add(Me.lblTitle12)
		Me.Controls.Add(Me.lblTtl0)
		Me.Controls.Add(Me.cmdSet)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.txtJigID)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(16, 186)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN02D1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "治具ID登録"
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdSet As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtJigID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl0 As Label
	Friend WithEvents cmbJJigCategory As SEComboBoxEx.ComboBoxEx
	Friend WithEvents lblTitle12 As Label
End Class
