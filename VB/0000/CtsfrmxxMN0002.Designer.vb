<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxMN0002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxMN0002))
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.txtInfo = New SETextBoxEx.TextBoxEx()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTtl = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(922, 375)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(51, 257)
        Me.cmdDown.TabIndex = 2
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(922, 119)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(51, 257)
        Me.cmdUP.TabIndex = 1
        Me.cmdUP.Text = "▲"
        '
        'txtInfo
        '
        Me.txtInfo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtInfo.ChrMaxByte = 0
        Me.txtInfo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtInfo.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtInfo.GotHighLight = false
        Me.txtInfo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtInfo.Location = New System.Drawing.Point(22, 131)
        Me.txtInfo.MultiLineEx = true
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtInfo.Padding = New System.Windows.Forms.Padding(5)
        Me.txtInfo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtInfo.SelectedText = ""
        Me.txtInfo.Size = New System.Drawing.Size(906, 505)
        Me.txtInfo.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Impact", 50.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Navy
        Me.lblTitle.Location = New System.Drawing.Point(-1, -2)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(298, 73)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "SPIRYTUS"
        '
        'lblTitle2
        '
        Me.lblTitle2.Font = New System.Drawing.Font("Impact", 50.25!, System.Drawing.FontStyle.Italic)
        Me.lblTitle2.ForeColor = System.Drawing.Color.White
        Me.lblTitle2.Location = New System.Drawing.Point(7, 12)
        Me.lblTitle2.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(298, 73)
        Me.lblTitle2.TabIndex = 7
        Me.lblTitle2.Text = "SPIRYTUS"
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Navy
        Me.lblVersion.Location = New System.Drawing.Point(290, 60)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(129, 17)
        Me.lblVersion.TabIndex = 6
        Me.lblVersion.Text = "Ver.x.xx.xxxx"
        '
        'lblTitle3
        '
        Me.lblTitle3.Font = New System.Drawing.Font("Arial", 12!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTitle3.Location = New System.Drawing.Point(22, 82)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(329, 25)
        Me.lblTitle3.TabIndex = 5
        Me.lblTitle3.Text = "Feel our spirit... SPIRYTUS from Chitose."
        '
        'lblTtl
        '
        Me.lblTtl.BackColor = System.Drawing.Color.Navy
        Me.lblTtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl.Location = New System.Drawing.Point(27, 120)
        Me.lblTtl.Name = "lblTtl"
        Me.lblTtl.Size = New System.Drawing.Size(945, 17)
        Me.lblTtl.TabIndex = 4
        Me.lblTtl.Text = " お知らせ"
        '
        'frmxxMN0002
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.ControlBox = false
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTtl)
        Me.Controls.Add(Me.txtInfo)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxMN0002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "お知らせ"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents txtInfo As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTtl As Label
End Class
