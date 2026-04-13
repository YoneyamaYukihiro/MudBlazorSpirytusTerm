<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00Z1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00Z1))
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.picRightAllow = New System.Windows.Forms.PictureBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.lblTitle01 = New System.Windows.Forms.Label()
        Me.lblTitle02 = New System.Windows.Forms.Label()
        Me.lblSMIFID = New System.Windows.Forms.Label()
        Me.lblTitle00 = New System.Windows.Forms.Label()
        Me.lblReticleID = New System.Windows.Forms.Label()
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.CausesValidation = false
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(308, 169)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdCarrierSelect.TabIndex = 2
        Me.cmdCarrierSelect.Text = "空きSMIF"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(421, 169)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 1
        Me.cmdRegist.Text = "確　定"
        '
        'picRightAllow
        '
        Me.picRightAllow.Image = CType(resources.GetObject("picRightAllow.Image"),System.Drawing.Image)
        Me.picRightAllow.Location = New System.Drawing.Point(253, 98)
        Me.picRightAllow.Name = "picRightAllow"
        Me.picRightAllow.Size = New System.Drawing.Size(32, 32)
        Me.picRightAllow.TabIndex = 9
        Me.picRightAllow.TabStop = false
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 169)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "閉じる"
        '
        'txtCarrierID
        '
        Me.txtCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID.ChrMaxByte = 6
        Me.txtCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID.Location = New System.Drawing.Point(298, 107)
        Me.txtCarrierID.Name = "txtCarrierID"
        Me.txtCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID.SelectedText = ""
        Me.txtCarrierID.Size = New System.Drawing.Size(228, 30)
        Me.txtCarrierID.TabIndex = 0
        '
        'lblTitle01
        '
        Me.lblTitle01.BackColor = System.Drawing.Color.Navy
        Me.lblTitle01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle01.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle01.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle01.Location = New System.Drawing.Point(298, 91)
        Me.lblTitle01.Name = "lblTitle01"
        Me.lblTitle01.Size = New System.Drawing.Size(228, 17)
        Me.lblTitle01.TabIndex = 8
        Me.lblTitle01.Text = "変更後SMIF"
        Me.lblTitle01.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle02
        '
        Me.lblTitle02.BackColor = System.Drawing.Color.Navy
        Me.lblTitle02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle02.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle02.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle02.Location = New System.Drawing.Point(8, 90)
        Me.lblTitle02.Name = "lblTitle02"
        Me.lblTitle02.Size = New System.Drawing.Size(228, 17)
        Me.lblTitle02.TabIndex = 7
        Me.lblTitle02.Text = "変更前SMIF"
        Me.lblTitle02.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSMIFID
        '
        Me.lblSMIFID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSMIFID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSMIFID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSMIFID.Location = New System.Drawing.Point(8, 106)
        Me.lblSMIFID.Name = "lblSMIFID"
        Me.lblSMIFID.Size = New System.Drawing.Size(228, 25)
        Me.lblSMIFID.TabIndex = 6
        '
        'lblTitle00
        '
        Me.lblTitle00.BackColor = System.Drawing.Color.Navy
        Me.lblTitle00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle00.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle00.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle00.Location = New System.Drawing.Point(8, 16)
        Me.lblTitle00.Name = "lblTitle00"
        Me.lblTitle00.Size = New System.Drawing.Size(228, 17)
        Me.lblTitle00.TabIndex = 5
        Me.lblTitle00.Text = "レチクルID"
        Me.lblTitle00.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblReticleID
        '
        Me.lblReticleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReticleID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReticleID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblReticleID.Location = New System.Drawing.Point(8, 32)
        Me.lblReticleID.Name = "lblReticleID"
        Me.lblReticleID.Size = New System.Drawing.Size(228, 25)
        Me.lblReticleID.TabIndex = 4
        Me.lblReticleID.Text = "12345678901234567-1C"
        '
        'frmxxEN00Z1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(533, 233)
        Me.Controls.Add(Me.cmdCarrierSelect)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.picRightAllow)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtCarrierID)
        Me.Controls.Add(Me.lblTitle01)
        Me.Controls.Add(Me.lblTitle02)
        Me.Controls.Add(Me.lblSMIFID)
        Me.Controls.Add(Me.lblTitle00)
        Me.Controls.Add(Me.lblReticleID)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(16, 186)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00Z1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "レチクル情報変更"
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents picRightAllow As PictureBox
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle01 As Label
    Friend WithEvents lblTitle02 As Label
    Friend WithEvents lblSMIFID As Label
    Friend WithEvents lblTitle00 As Label
    Friend WithEvents lblReticleID As Label
End Class
