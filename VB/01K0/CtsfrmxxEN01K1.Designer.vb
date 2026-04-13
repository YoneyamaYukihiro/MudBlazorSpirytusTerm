<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01K1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01K1))
        Me.fraRireki = New System.Windows.Forms.GroupBox()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblChangeCount = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraRireki.SuspendLayout
        Me.SuspendLayout
        '
        'fraRireki
        '
        Me.fraRireki.Controls.Add(Me.cmdDown)
        Me.fraRireki.Controls.Add(Me.cmdUp)
        Me.fraRireki.Controls.Add(Me.txtComments)
        Me.fraRireki.Controls.Add(Me.lblTtl1)
        Me.fraRireki.Controls.Add(Me.lblChangeCount)
        Me.fraRireki.Controls.Add(Me.lblTitle0)
        Me.fraRireki.Location = New System.Drawing.Point(8, 9)
        Me.fraRireki.Name = "fraRireki"
        Me.fraRireki.Size = New System.Drawing.Size(965, 266)
        Me.fraRireki.TabIndex = 1
        Me.fraRireki.TabStop = false
        Me.fraRireki.Text = "変更履歴"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Location = New System.Drawing.Point(929, 160)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(25, 95)
        Me.cmdDown.TabIndex = 3
        Me.cmdDown.Text = "▼"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Location = New System.Drawing.Point(929, 65)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(25, 95)
        Me.cmdUp.TabIndex = 2
        Me.cmdUp.Text = "▲"
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
        Me.txtComments.Location = New System.Drawing.Point(16, 84)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(913, 170)
        Me.txtComments.TabIndex = 1
        Me.txtComments.TabStop = false
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(16, 66)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(913, 17)
        Me.lblTtl1.TabIndex = 7
        Me.lblTtl1.Text = "コメント"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChangeCount
        '
        Me.lblChangeCount.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblChangeCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChangeCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChangeCount.Location = New System.Drawing.Point(18, 36)
        Me.lblChangeCount.Name = "lblChangeCount"
        Me.lblChangeCount.Size = New System.Drawing.Size(109, 22)
        Me.lblChangeCount.TabIndex = 5
        Me.lblChangeCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(18, 21)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(109, 17)
        Me.lblTitle0.TabIndex = 6
        Me.lblTitle0.Text = "変更回数"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(9, 286)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxEN01K1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 332)
        Me.Controls.Add(Me.fraRireki)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01K1"
        Me.Text = "変更履歴確認"
        Me.fraRireki.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraRireki As GroupBox
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblChangeCount As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents cmdClose As Button
End Class
