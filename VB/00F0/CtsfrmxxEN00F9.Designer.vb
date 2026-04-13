<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00F9
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00F9))
        Me.fraCarrier = New System.Windows.Forms.GroupBox()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraFrame = New System.Windows.Forms.GroupBox()
        Me.lblChip = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblWF = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblPDID = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblSendDate = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblToSend = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblBoxNo = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.fraCarrier.SuspendLayout
        Me.fraFrame.SuspendLayout
        Me.SuspendLayout
        '
        'fraCarrier
        '
        Me.fraCarrier.Controls.Add(Me.cmdCarrierSelect)
        Me.fraCarrier.Controls.Add(Me.txtCarrierID)
        Me.fraCarrier.Controls.Add(Me.lblTtl0)
        Me.fraCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrier.Location = New System.Drawing.Point(8, 144)
        Me.fraCarrier.Name = "fraCarrier"
        Me.fraCarrier.Size = New System.Drawing.Size(221, 77)
        Me.fraCarrier.TabIndex = 0
        Me.fraCarrier.TabStop = false
        Me.fraCarrier.Text = "キャリア選択"
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(120, 24)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect.TabIndex = 1
        Me.cmdCarrierSelect.Text = "空ｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'txtCarrierID
        '
        Me.txtCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID.ChrMaxByte = 6
        Me.txtCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID.Location = New System.Drawing.Point(12, 40)
        Me.txtCarrierID.Name = "txtCarrierID"
        Me.txtCarrierID.NgChr = "'"
        Me.txtCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID.SelectedText = ""
        Me.txtCarrierID.Size = New System.Drawing.Size(97, 22)
        Me.txtCarrierID.TabIndex = 0
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(12, 24)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl0.TabIndex = 20
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 232)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.Enabled = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(372, 232)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 2
        Me.cmdRegist.Text = "確　定"
        '
        'fraFrame
        '
        Me.fraFrame.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraFrame.Controls.Add(Me.lblChip)
        Me.fraFrame.Controls.Add(Me.lblTitle8)
        Me.fraFrame.Controls.Add(Me.lblWF)
        Me.fraFrame.Controls.Add(Me.lblTitle7)
        Me.fraFrame.Controls.Add(Me.lblPDID)
        Me.fraFrame.Controls.Add(Me.lblTitle4)
        Me.fraFrame.Controls.Add(Me.lblSendDate)
        Me.fraFrame.Controls.Add(Me.lblTitle3)
        Me.fraFrame.Controls.Add(Me.lblToSend)
        Me.fraFrame.Controls.Add(Me.lblTitle2)
        Me.fraFrame.Controls.Add(Me.lblBoxNo)
        Me.fraFrame.Controls.Add(Me.lblTitle0)
        Me.fraFrame.Controls.Add(Me.lblTitle1)
        Me.fraFrame.Controls.Add(Me.lblLotID)
        Me.fraFrame.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraFrame.Location = New System.Drawing.Point(8, 8)
        Me.fraFrame.Name = "fraFrame"
        Me.fraFrame.Size = New System.Drawing.Size(445, 125)
        Me.fraFrame.TabIndex = 4
        Me.fraFrame.TabStop = false
        Me.fraFrame.Text = "送品取消ロット"
        '
        'lblChip
        '
        Me.lblChip.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChip.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblChip.Location = New System.Drawing.Point(304, 88)
        Me.lblChip.Name = "lblChip"
        Me.lblChip.Size = New System.Drawing.Size(129, 22)
        Me.lblChip.TabIndex = 18
        Me.lblChip.Text = "780"
        Me.lblChip.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(304, 72)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(129, 17)
        Me.lblTitle8.TabIndex = 17
        Me.lblTitle8.Text = "送品チップ数"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWF
        '
        Me.lblWF.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWF.Location = New System.Drawing.Point(188, 88)
        Me.lblWF.Name = "lblWF"
        Me.lblWF.Size = New System.Drawing.Size(117, 22)
        Me.lblWF.TabIndex = 16
        Me.lblWF.Text = "5"
        Me.lblWF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(188, 72)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(117, 17)
        Me.lblTitle7.TabIndex = 15
        Me.lblTitle7.Text = "送品WF数"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPDID
        '
        Me.lblPDID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPDID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPDID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPDID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPDID.Location = New System.Drawing.Point(124, 88)
        Me.lblPDID.Name = "lblPDID"
        Me.lblPDID.Size = New System.Drawing.Size(65, 22)
        Me.lblPDID.TabIndex = 14
        Me.lblPDID.Text = "DGT"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(124, 72)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(65, 17)
        Me.lblTitle4.TabIndex = 13
        Me.lblTitle4.Text = "機種"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSendDate
        '
        Me.lblSendDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblSendDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSendDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSendDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSendDate.Location = New System.Drawing.Point(184, 40)
        Me.lblSendDate.Name = "lblSendDate"
        Me.lblSendDate.Size = New System.Drawing.Size(173, 22)
        Me.lblSendDate.TabIndex = 12
        Me.lblSendDate.Text = "2005/03/18"
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(184, 24)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(173, 17)
        Me.lblTitle3.TabIndex = 11
        Me.lblTitle3.Text = "送品日"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblToSend
        '
        Me.lblToSend.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblToSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblToSend.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblToSend.Location = New System.Drawing.Point(12, 40)
        Me.lblToSend.Name = "lblToSend"
        Me.lblToSend.Size = New System.Drawing.Size(173, 22)
        Me.lblToSend.TabIndex = 10
        Me.lblToSend.Text = "イングス電特"
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(12, 24)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(173, 17)
        Me.lblTitle2.TabIndex = 9
        Me.lblTitle2.Text = "送品先"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBoxNo
        '
        Me.lblBoxNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBoxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBoxNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBoxNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBoxNo.Location = New System.Drawing.Point(356, 40)
        Me.lblBoxNo.Name = "lblBoxNo"
        Me.lblBoxNo.Size = New System.Drawing.Size(77, 22)
        Me.lblBoxNo.TabIndex = 8
        Me.lblBoxNo.Text = "XXX"
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(356, 24)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(77, 17)
        Me.lblTitle0.TabIndex = 7
        Me.lblTitle0.Text = "箱№"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(12, 72)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(113, 17)
        Me.lblTitle1.TabIndex = 6
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(12, 88)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(113, 22)
        Me.lblLotID.TabIndex = 5
        Me.lblLotID.Text = "DGTP001S00"
        '
        'frmxxEN00F9
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(468, 281)
        Me.Controls.Add(Me.fraCarrier)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.fraFrame)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(370, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00F9"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "送品取消"
        Me.fraCarrier.ResumeLayout(false)
        Me.fraFrame.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraCarrier As GroupBox
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraFrame As GroupBox
    Friend WithEvents lblChip As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblWF As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblPDID As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblSendDate As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblToSend As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblBoxNo As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblLotID As Label
End Class
