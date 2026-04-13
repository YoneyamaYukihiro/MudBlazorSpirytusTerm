<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00Z2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00Z2))
        Me.cmdErrreleseCommentsDown = New System.Windows.Forms.Button()
        Me.cmdErrreleseCommentsUp = New System.Windows.Forms.Button()
        Me.cmdErrCommentsDown = New System.Windows.Forms.Button()
        Me.cmdErrCommentsUp = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbReason = New SEComboBoxEx.ComboBoxEx()
        Me.txtErrComments = New SETextBoxEx.TextBoxEx()
        Me.txtErrReleseComments = New SETextBoxEx.TextBoxEx()
        Me.lblReleaseLengthCount = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTitle04 = New System.Windows.Forms.Label()
        Me.lblTitle00 = New System.Windows.Forms.Label()
        Me.lblReticleID = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'cmdErrreleseCommentsDown
        '
        Me.cmdErrreleseCommentsDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdErrreleseCommentsDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdErrreleseCommentsDown.Location = New System.Drawing.Point(751, 313)
        Me.cmdErrreleseCommentsDown.Name = "cmdErrreleseCommentsDown"
        Me.cmdErrreleseCommentsDown.Size = New System.Drawing.Size(49, 59)
        Me.cmdErrreleseCommentsDown.TabIndex = 8
        Me.cmdErrreleseCommentsDown.Text = "▼"
        '
        'cmdErrreleseCommentsUp
        '
        Me.cmdErrreleseCommentsUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdErrreleseCommentsUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdErrreleseCommentsUp.Location = New System.Drawing.Point(751, 253)
        Me.cmdErrreleseCommentsUp.Name = "cmdErrreleseCommentsUp"
        Me.cmdErrreleseCommentsUp.Size = New System.Drawing.Size(49, 59)
        Me.cmdErrreleseCommentsUp.TabIndex = 7
        Me.cmdErrreleseCommentsUp.Text = "▲"
        '
        'cmdErrCommentsDown
        '
        Me.cmdErrCommentsDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdErrCommentsDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdErrCommentsDown.Location = New System.Drawing.Point(751, 184)
        Me.cmdErrCommentsDown.Name = "cmdErrCommentsDown"
        Me.cmdErrCommentsDown.Size = New System.Drawing.Size(49, 59)
        Me.cmdErrCommentsDown.TabIndex = 6
        Me.cmdErrCommentsDown.Text = "▼"
        '
        'cmdErrCommentsUp
        '
        Me.cmdErrCommentsUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdErrCommentsUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdErrCommentsUp.Location = New System.Drawing.Point(751, 124)
        Me.cmdErrCommentsUp.Name = "cmdErrCommentsUp"
        Me.cmdErrCommentsUp.Size = New System.Drawing.Size(49, 59)
        Me.cmdErrCommentsUp.TabIndex = 5
        Me.cmdErrCommentsUp.Text = "▲"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(695, 381)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 3
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 381)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "閉じる"
        '
        'cmbReason
        '
        Me.cmbReason.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbReason.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbReason.Location = New System.Drawing.Point(8, 84)
        Me.cmbReason.Name = "cmbReason"
        Me.cmbReason.Size = New System.Drawing.Size(229, 28)
        Me.cmbReason.TabIndex = 0
        Me.cmbReason.Value = Nothing
        '
        'txtErrComments
        '
        Me.txtErrComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtErrComments.ChrMaxByte = 0
        Me.txtErrComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtErrComments.GotHighLight = false
        Me.txtErrComments.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtErrComments.Location = New System.Drawing.Point(8, 141)
        Me.txtErrComments.MultiLineEx = true
        Me.txtErrComments.Name = "txtErrComments"
        Me.txtErrComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtErrComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtErrComments.SelectedText = ""
        Me.txtErrComments.Size = New System.Drawing.Size(743, 101)
        Me.txtErrComments.TabIndex = 1
        '
        'txtErrReleseComments
        '
        Me.txtErrReleseComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtErrReleseComments.ChrMaxByte = 0
        Me.txtErrReleseComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtErrReleseComments.GotHighLight = false
        Me.txtErrReleseComments.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtErrReleseComments.Location = New System.Drawing.Point(8, 270)
        Me.txtErrReleseComments.MultiLineEx = true
        Me.txtErrReleseComments.Name = "txtErrReleseComments"
        Me.txtErrReleseComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtErrReleseComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtErrReleseComments.SelectedText = ""
        Me.txtErrReleseComments.Size = New System.Drawing.Size(743, 101)
        Me.txtErrReleseComments.TabIndex = 2
        '
        'lblReleaseLengthCount
        '
        Me.lblReleaseLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblReleaseLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReleaseLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblReleaseLengthCount.Location = New System.Drawing.Point(486, 0)
        Me.lblReleaseLengthCount.Name = "lblReleaseLengthCount"
        Me.lblReleaseLengthCount.Size = New System.Drawing.Size(229, 17)
        Me.lblReleaseLengthCount.TabIndex = 15
        Me.lblReleaseLengthCount.Text = "(半角0文字/半角2048文字)"
        Me.lblReleaseLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(484, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(231, 17)
        Me.lblLengthCount.TabIndex = 14
        Me.lblLengthCount.Text = "(半角0文字/半角2048文字)"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Controls.Add(Me.lblReleaseLengthCount)
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 254)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl0.TabIndex = 13
        Me.lblTtl0.Text = "エラー解除コメント"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle      
        Me.lblTtl15.Controls.Add(Me.lblLengthCount)
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 125)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl15.TabIndex = 12
        Me.lblTtl15.Text = "エラーコメント"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle04
        '
        Me.lblTitle04.BackColor = System.Drawing.Color.Navy
        Me.lblTitle04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle04.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle04.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle04.Location = New System.Drawing.Point(8, 68)
        Me.lblTitle04.Name = "lblTitle04"
        Me.lblTitle04.Size = New System.Drawing.Size(229, 17)
        Me.lblTitle04.TabIndex = 11
        Me.lblTitle04.Text = "エラー理由"
        Me.lblTitle04.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTitle00.TabIndex = 10
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
        Me.lblReticleID.TabIndex = 9
        '
        'frmxxEN00Z2
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(808, 445)
        Me.Controls.Add(Me.cmdErrreleseCommentsDown)
        Me.Controls.Add(Me.cmdErrreleseCommentsUp)
        Me.Controls.Add(Me.cmdErrCommentsDown)
        Me.Controls.Add(Me.cmdErrCommentsUp)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmbReason)
        Me.Controls.Add(Me.txtErrComments)
        Me.Controls.Add(Me.txtErrReleseComments)        
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.lblTitle04)
        Me.Controls.Add(Me.lblTitle00)
        Me.Controls.Add(Me.lblReticleID)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(16, 186)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00Z2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "エラー設定"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdErrreleseCommentsDown As Button
    Friend WithEvents cmdErrreleseCommentsUp As Button
    Friend WithEvents cmdErrCommentsDown As Button
    Friend WithEvents cmdErrCommentsUp As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmbReason As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtErrComments As SETextBoxEx.TextBoxEx
    Friend WithEvents txtErrReleseComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblReleaseLengthCount As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTitle04 As Label
    Friend WithEvents lblTitle00 As Label
    Friend WithEvents lblReticleID As Label
End Class
