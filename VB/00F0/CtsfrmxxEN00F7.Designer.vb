<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00F7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00F7))
        Me.optKubun1 = New System.Windows.Forms.RadioButton()
        Me.optKubun0 = New System.Windows.Forms.RadioButton()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraFrame = New System.Windows.Forms.GroupBox()
        Me.txtScrapNum = New SETextBoxEx.TextBoxEx()
        Me.cmbMasPut = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblNowNum = New System.Windows.Forms.Label()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.fraFrame.SuspendLayout
        Me.SuspendLayout
        '
        'optKubun1
        '
        Me.optKubun1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun1.Location = New System.Drawing.Point(92, 8)
        Me.optKubun1.Name = "optKubun1"
        Me.optKubun1.Size = New System.Drawing.Size(57, 21)
        Me.optKubun1.TabIndex = 1
        Me.optKubun1.Text = "払出"
        '
        'optKubun0
        '
        Me.optKubun0.Checked = true
        Me.optKubun0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun0.Location = New System.Drawing.Point(20, 8)
        Me.optKubun0.Name = "optKubun0"
        Me.optKubun0.Size = New System.Drawing.Size(77, 21)
        Me.optKubun0.TabIndex = 0
        Me.optKubun0.TabStop = true
        Me.optKubun0.Text = "不良"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 196)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(228, 196)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 4
        Me.cmdRegist.Text = "確　定"
        '
        'fraFrame
        '
        Me.fraFrame.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraFrame.Controls.Add(Me.txtScrapNum)
        Me.fraFrame.Controls.Add(Me.cmbMasPut)
        Me.fraFrame.Controls.Add(Me.lblTitle4)
        Me.fraFrame.Controls.Add(Me.lblTitle3)
        Me.fraFrame.Controls.Add(Me.lblNowNum)
        Me.fraFrame.Controls.Add(Me.lblCarrier)
        Me.fraFrame.Controls.Add(Me.lblTitle2)
        Me.fraFrame.Controls.Add(Me.lblTitle1)
        Me.fraFrame.Controls.Add(Me.lblTitle0)
        Me.fraFrame.Controls.Add(Me.lblLotID)
        Me.fraFrame.Controls.Add(Me.lblFlowClass)
        Me.fraFrame.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraFrame.Location = New System.Drawing.Point(8, 8)
        Me.fraFrame.Name = "fraFrame"
        Me.fraFrame.Size = New System.Drawing.Size(305, 177)
        Me.fraFrame.TabIndex = 2
        Me.fraFrame.TabStop = false
        '
        'txtScrapNum
        '
        Me.txtScrapNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtScrapNum.ChrMaxByte = 6
        Me.txtScrapNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtScrapNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtScrapNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtScrapNum.Location = New System.Drawing.Point(12, 144)
        Me.txtScrapNum.MultiLineEx = true
        Me.txtScrapNum.Name = "txtScrapNum"
        Me.txtScrapNum.NgChr = "'"
        Me.txtScrapNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtScrapNum.NumFormat = "#,##0"
        Me.txtScrapNum.NumMax = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.txtScrapNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtScrapNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtScrapNum.SelectedText = ""
        Me.txtScrapNum.Size = New System.Drawing.Size(97, 22)
        Me.txtScrapNum.TabIndex = 3
        Me.txtScrapNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbMasPut
        '
        Me.cmbMasPut.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMasPut.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMasPut.Location = New System.Drawing.Point(12, 92)
        Me.cmbMasPut.Name = "cmbMasPut"
        Me.cmbMasPut.Size = New System.Drawing.Size(281, 22)
        Me.cmbMasPut.TabIndex = 2
        Me.cmbMasPut.Value = Nothing
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(196, 128)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle4.TabIndex = 14
        Me.lblTitle4.Text = "現在数量"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(12, 128)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle3.TabIndex = 13
        Me.lblTitle3.Text = "処置数量"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowNum
        '
        Me.lblNowNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowNum.Location = New System.Drawing.Point(196, 144)
        Me.lblNowNum.Name = "lblNowNum"
        Me.lblNowNum.Size = New System.Drawing.Size(97, 22)
        Me.lblNowNum.TabIndex = 9
        Me.lblNowNum.Text = "999,999"
        Me.lblNowNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCarrier
        '
        Me.lblCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrier.Location = New System.Drawing.Point(12, 40)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(97, 22)
        Me.lblCarrier.TabIndex = 6
        Me.lblCarrier.Text = "GTA1234-00"
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(12, 76)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(281, 17)
        Me.lblTitle2.TabIndex = 12
        Me.lblTitle2.Text = "処置理由"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(108, 24)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle1.TabIndex = 11
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(12, 24)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle0.TabIndex = 10
        Me.lblTitle0.Text = "キャリアID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(108, 40)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 22)
        Me.lblLotID.TabIndex = 7
        Me.lblLotID.Text = "GTA1234-00"
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(228, 40)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 22)
        Me.lblFlowClass.TabIndex = 8
        Me.lblFlowClass.Text = "ZZ"
        '
        'frmxxEN00F7
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(323, 246)
        Me.Controls.Add(Me.optKubun1)
        Me.Controls.Add(Me.optKubun0)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.fraFrame)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(370, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00F7"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CF在庫処置"
        Me.fraFrame.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents optKubun1 As RadioButton
    Friend WithEvents optKubun0 As RadioButton
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraFrame As GroupBox
    Friend WithEvents txtScrapNum As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbMasPut As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblNowNum As Label
    Friend WithEvents lblCarrier As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblFlowClass As Label
End Class
