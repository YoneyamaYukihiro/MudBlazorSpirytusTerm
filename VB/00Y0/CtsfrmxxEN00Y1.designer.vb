<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00Y1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00Y1))
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraExcp = New System.Windows.Forms.GroupBox()
        Me.fraExcpIn = New System.Windows.Forms.Panel()
        Me.optExcpReport1 = New System.Windows.Forms.RadioButton()
        Me.optExcpReport0 = New System.Windows.Forms.RadioButton()
        Me.fraHold = New System.Windows.Forms.GroupBox()
        Me.fraHoldIn = New System.Windows.Forms.Panel()
        Me.optHold1 = New System.Windows.Forms.RadioButton()
        Me.optHold0 = New System.Windows.Forms.RadioButton()
        Me.fraReworkReason = New System.Windows.Forms.GroupBox()
        Me.cmbReasonCode = New SEComboBoxEx.ComboBoxEx()
        Me.cmbReasonSubCode = New SEComboBoxEx.ComboBoxEx()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.fraExcp.SuspendLayout
        Me.fraExcpIn.SuspendLayout
        Me.fraHold.SuspendLayout
        Me.fraHoldIn.SuspendLayout
        Me.fraReworkReason.SuspendLayout
        Me.SuspendLayout
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Location = New System.Drawing.Point(488, 280)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 2
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 280)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "閉じる"
        '
        'fraExcp
        '
        Me.fraExcp.Controls.Add(Me.fraExcpIn)
        Me.fraExcp.Location = New System.Drawing.Point(248, 156)
        Me.fraExcp.Name = "fraExcp"
        Me.fraExcp.Size = New System.Drawing.Size(345, 113)
        Me.fraExcp.TabIndex = 7
        Me.fraExcp.TabStop = false
        Me.fraExcp.Text = "工程異常処理票発行設定"
        '
        'fraExcpIn
        '
        Me.fraExcpIn.Controls.Add(Me.optExcpReport1)
        Me.fraExcpIn.Controls.Add(Me.optExcpReport0)
        Me.fraExcpIn.Location = New System.Drawing.Point(4, 18)
        Me.fraExcpIn.Name = "fraExcpIn"
        Me.fraExcpIn.Size = New System.Drawing.Size(337, 91)
        Me.fraExcpIn.TabIndex = 11
        Me.fraExcpIn.Text = "Frame1"
        '
        'optExcpReport1
        '
        Me.optExcpReport1.Checked = true
        Me.optExcpReport1.Location = New System.Drawing.Point(2, 54)
        Me.optExcpReport1.Name = "optExcpReport1"
        Me.optExcpReport1.Size = New System.Drawing.Size(329, 30)
        Me.optExcpReport1.TabIndex = 13
        Me.optExcpReport1.TabStop = true
        Me.optExcpReport1.Text = "工程異常処理票発行無し"
        '
        'optExcpReport0
        '
        Me.optExcpReport0.Location = New System.Drawing.Point(2, 8)
        Me.optExcpReport0.Name = "optExcpReport0"
        Me.optExcpReport0.Size = New System.Drawing.Size(329, 30)
        Me.optExcpReport0.TabIndex = 12
        Me.optExcpReport0.Text = "工程異常処理票発行有り"
        '
        'fraHold
        '
        Me.fraHold.Controls.Add(Me.fraHoldIn)
        Me.fraHold.Location = New System.Drawing.Point(8, 156)
        Me.fraHold.Name = "fraHold"
        Me.fraHold.Size = New System.Drawing.Size(233, 113)
        Me.fraHold.TabIndex = 6
        Me.fraHold.TabStop = false
        Me.fraHold.Text = "保留設定"
        '
        'fraHoldIn
        '
        Me.fraHoldIn.Controls.Add(Me.optHold1)
        Me.fraHoldIn.Controls.Add(Me.optHold0)
        Me.fraHoldIn.Location = New System.Drawing.Point(4, 18)
        Me.fraHoldIn.Name = "fraHoldIn"
        Me.fraHoldIn.Size = New System.Drawing.Size(225, 91)
        Me.fraHoldIn.TabIndex = 8
        '
        'optHold1
        '
        Me.optHold1.Location = New System.Drawing.Point(2, 54)
        Me.optHold1.Name = "optHold1"
        Me.optHold1.Size = New System.Drawing.Size(217, 30)
        Me.optHold1.TabIndex = 10
        Me.optHold1.Text = "保留無し"
        '
        'optHold0
        '
        Me.optHold0.Checked = true
        Me.optHold0.Location = New System.Drawing.Point(2, 8)
        Me.optHold0.Name = "optHold0"
        Me.optHold0.Size = New System.Drawing.Size(217, 30)
        Me.optHold0.TabIndex = 9
        Me.optHold0.TabStop = true
        Me.optHold0.Text = "保留有り"
        '
        'fraReworkReason
        '
        Me.fraReworkReason.Controls.Add(Me.cmbReasonCode)
        Me.fraReworkReason.Controls.Add(Me.cmbReasonSubCode)
        Me.fraReworkReason.Controls.Add(Me.lblTtl0)
        Me.fraReworkReason.Controls.Add(Me.lblTtl13)
        Me.fraReworkReason.Location = New System.Drawing.Point(8, 8)
        Me.fraReworkReason.Name = "fraReworkReason"
        Me.fraReworkReason.Size = New System.Drawing.Size(585, 137)
        Me.fraReworkReason.TabIndex = 4
        Me.fraReworkReason.TabStop = false
        Me.fraReworkReason.Text = "リワーク原因"
        '
        'cmbReasonCode
        '
        Me.cmbReasonCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbReasonCode.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbReasonCode.Location = New System.Drawing.Point(8, 41)
        Me.cmbReasonCode.Name = "cmbReasonCode"
        Me.cmbReasonCode.Size = New System.Drawing.Size(339, 28)
        Me.cmbReasonCode.TabIndex = 0
        Me.cmbReasonCode.Value = Nothing
        '
        'cmbReasonSubCode
        '
        Me.cmbReasonSubCode.BackColor = System.Drawing.Color.White
        Me.cmbReasonSubCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbReasonSubCode.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbReasonSubCode.Location = New System.Drawing.Point(8, 95)
        Me.cmbReasonSubCode.Name = "cmbReasonSubCode"
        Me.cmbReasonSubCode.Size = New System.Drawing.Size(565, 28)
        Me.cmbReasonSubCode.TabIndex = 1
        Me.cmbReasonSubCode.Value = Nothing
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 78)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(565, 17)
        Me.lblTtl0.TabIndex = 14
        Me.lblTtl0.Text = "リワーク原因(小分類)"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.Color.Navy
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl13.Location = New System.Drawing.Point(8, 24)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(339, 17)
        Me.lblTtl13.TabIndex = 5
        Me.lblTtl13.Text = "リワーク原因(大分類)"
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00Y1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(603, 346)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraExcp)
        Me.Controls.Add(Me.fraHold)
        Me.Controls.Add(Me.fraReworkReason)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00Y1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "リワーク原因設定"
        Me.fraExcp.ResumeLayout(false)
        Me.fraExcpIn.ResumeLayout(false)
        Me.fraHold.ResumeLayout(false)
        Me.fraHoldIn.ResumeLayout(false)
        Me.fraReworkReason.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraExcp As GroupBox
    Friend WithEvents fraExcpIn As Panel
    Friend WithEvents optExcpReport1 As RadioButton
    Friend WithEvents optExcpReport0 As RadioButton
    Friend WithEvents fraHold As GroupBox
    Friend WithEvents fraHoldIn As Panel
    Friend WithEvents optHold1 As RadioButton
    Friend WithEvents optHold0 As RadioButton
    Friend WithEvents fraReworkReason As GroupBox
    Friend WithEvents cmbReasonCode As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbReasonSubCode As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTtl13 As Label
End Class
