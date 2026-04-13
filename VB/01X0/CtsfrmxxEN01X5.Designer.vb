<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01X5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01X5))
        Me.fraTitle1 = New System.Windows.Forms.GroupBox()
        Me.fraLimitTime = New System.Windows.Forms.Panel()
        Me.txtWarning = New SETextBoxEx.TextBoxEx()
        Me.txtLimit = New SETextBoxEx.TextBoxEx()
        Me.lblMinute1 = New System.Windows.Forms.Label()
        Me.lblMinute0 = New System.Windows.Forms.Label()
        Me.lblLimit = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.fraTitle0 = New System.Windows.Forms.GroupBox()
        Me.fraLimitType = New System.Windows.Forms.Panel()
        Me.OptTimeLimit2 = New System.Windows.Forms.RadioButton()
        Me.OptTimeLimit1 = New System.Windows.Forms.RadioButton()
        Me.OptTimeLimit3 = New System.Windows.Forms.RadioButton()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.fraTimeLimit = New System.Windows.Forms.Panel()
        Me.cmbNo = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.fraLimitProcess = New System.Windows.Forms.GroupBox()
        Me.picVector = New System.Windows.Forms.PictureBox()
        Me.lblFromOpId = New System.Windows.Forms.Label()
        Me.lblFromStepId = New System.Windows.Forms.Label()
        Me.lblToOpId = New System.Windows.Forms.Label()
        Me.lblToStepId = New System.Windows.Forms.Label()
        Me.lblToOp = New System.Windows.Forms.Label()
        Me.lblFromOp = New System.Windows.Forms.Label()
        Me.lblFromStep = New System.Windows.Forms.Label()
        Me.lblToStep = New System.Windows.Forms.Label()
        Me.cmdSet = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraTitle1.SuspendLayout
        Me.fraLimitTime.SuspendLayout
        Me.fraTitle0.SuspendLayout
        Me.fraLimitType.SuspendLayout
        Me.fraTimeLimit.SuspendLayout
        Me.fraLimitProcess.SuspendLayout
        CType(Me.picVector,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraTitle1
        '
        Me.fraTitle1.Controls.Add(Me.fraLimitTime)
        Me.fraTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraTitle1.Location = New System.Drawing.Point(298, 172)
        Me.fraTitle1.Name = "fraTitle1"
        Me.fraTitle1.Size = New System.Drawing.Size(280, 117)
        Me.fraTitle1.TabIndex = 2
        Me.fraTitle1.TabStop = false
        Me.fraTitle1.Text = "制限内容"
        '
        'fraLimitTime
        '
        Me.fraLimitTime.Controls.Add(Me.txtWarning)
        Me.fraLimitTime.Controls.Add(Me.txtLimit)
        Me.fraLimitTime.Controls.Add(Me.lblMinute1)
        Me.fraLimitTime.Controls.Add(Me.lblMinute0)
        Me.fraLimitTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLimitTime.Location = New System.Drawing.Point(30, 26)
        Me.fraLimitTime.Name = "fraLimitTime"
        Me.fraLimitTime.Size = New System.Drawing.Size(234, 65)
        Me.fraLimitTime.TabIndex = 24
        '
        'txtWarning
        '
        Me.txtWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWarning.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWarning.ChrMaxByte = 4
        Me.txtWarning.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtWarning.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtWarning.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWarning.Location = New System.Drawing.Point(2, 24)
        Me.txtWarning.Name = "txtWarning"
        Me.txtWarning.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWarning.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtWarning.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWarning.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWarning.SelectedText = ""
        Me.txtWarning.Size = New System.Drawing.Size(89, 25)
        Me.txtWarning.TabIndex = 4
        Me.txtWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLimit
        '
        Me.txtLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLimit.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtLimit.ChrMaxByte = 4
        Me.txtLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLimit.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtLimit.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLimit.Location = New System.Drawing.Point(120, 24)
        Me.txtLimit.Name = "txtLimit"
        Me.txtLimit.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLimit.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtLimit.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtLimit.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLimit.SelectedText = ""
        Me.txtLimit.Size = New System.Drawing.Size(89, 25)
        Me.txtLimit.TabIndex = 5
        Me.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMinute1
        '
        Me.lblMinute1.AutoSize = true
        Me.lblMinute1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMinute1.Location = New System.Drawing.Point(210, 28)
        Me.lblMinute1.Name = "lblMinute1"
        Me.lblMinute1.Size = New System.Drawing.Size(23, 15)
        Me.lblMinute1.TabIndex = 28
        Me.lblMinute1.Text = "分"
        '
        'lblMinute0
        '
        Me.lblMinute0.AutoSize = true
        Me.lblMinute0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMinute0.Location = New System.Drawing.Point(92, 28)
        Me.lblMinute0.Name = "lblMinute0"
        Me.lblMinute0.Size = New System.Drawing.Size(23, 15)
        Me.lblMinute0.TabIndex = 27
        Me.lblMinute0.Text = "分"
        '
        'lblLimit
        '
        Me.lblLimit.BackColor = System.Drawing.Color.Navy
        Me.lblLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLimit.ForeColor = System.Drawing.Color.Yellow
        Me.lblLimit.Location = New System.Drawing.Point(448, 206)
        Me.lblLimit.Name = "lblLimit"
        Me.lblLimit.Size = New System.Drawing.Size(89, 17)
        Me.lblLimit.TabIndex = 26
        Me.lblLimit.Text = "制限時間"
        Me.lblLimit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.Color.Navy
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWarning.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Yellow
        Me.lblWarning.Location = New System.Drawing.Point(330, 206)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(89, 17)
        Me.lblWarning.TabIndex = 25
        Me.lblWarning.Text = "警告時間"
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraTitle0
        '
        Me.fraTitle0.Controls.Add(Me.fraLimitType)
        Me.fraTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraTitle0.Location = New System.Drawing.Point(10, 172)
        Me.fraTitle0.Name = "fraTitle0"
        Me.fraTitle0.Size = New System.Drawing.Size(280, 117)
        Me.fraTitle0.TabIndex = 1
        Me.fraTitle0.TabStop = false
        Me.fraTitle0.Text = "制限タイプ"
        '
        'fraLimitType
        '
        Me.fraLimitType.Controls.Add(Me.OptTimeLimit2)
        Me.fraLimitType.Controls.Add(Me.OptTimeLimit1)
        Me.fraLimitType.Controls.Add(Me.OptTimeLimit3)
        Me.fraLimitType.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLimitType.Location = New System.Drawing.Point(42, 20)
        Me.fraLimitType.Name = "fraLimitType"
        Me.fraLimitType.Size = New System.Drawing.Size(222, 84)
        Me.fraLimitType.TabIndex = 22
        '
        'OptTimeLimit2
        '
        Me.OptTimeLimit2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.OptTimeLimit2.Location = New System.Drawing.Point(10, 32)
        Me.OptTimeLimit2.Name = "OptTimeLimit2"
        Me.OptTimeLimit2.Size = New System.Drawing.Size(193, 18)
        Me.OptTimeLimit2.TabIndex = 2
        Me.OptTimeLimit2.Text = "2:制限時間以上"
        '
        'OptTimeLimit1
        '
        Me.OptTimeLimit1.Checked = true
        Me.OptTimeLimit1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.OptTimeLimit1.Location = New System.Drawing.Point(10, 5)
        Me.OptTimeLimit1.Name = "OptTimeLimit1"
        Me.OptTimeLimit1.Size = New System.Drawing.Size(193, 18)
        Me.OptTimeLimit1.TabIndex = 1
        Me.OptTimeLimit1.TabStop = true
        Me.OptTimeLimit1.Text = "1:制限時間以下"
        '
        'OptTimeLimit3
        '
        Me.OptTimeLimit3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.OptTimeLimit3.Location = New System.Drawing.Point(10, 60)
        Me.OptTimeLimit3.Name = "OptTimeLimit3"
        Me.OptTimeLimit3.Size = New System.Drawing.Size(193, 18)
        Me.OptTimeLimit3.TabIndex = 3
        Me.OptTimeLimit3.Text = "3:処理時間制限以下"
        '
        'cmdDel
        '
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Location = New System.Drawing.Point(402, 298)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(85, 40)
        Me.cmdDel.TabIndex = 7
        Me.cmdDel.Text = "削　除"
        '
        'fraTimeLimit
        '
        Me.fraTimeLimit.Controls.Add(Me.cmbNo)
        Me.fraTimeLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraTimeLimit.Location = New System.Drawing.Point(16, 8)
        Me.fraTimeLimit.Name = "fraTimeLimit"
        Me.fraTimeLimit.Size = New System.Drawing.Size(177, 41)
        Me.fraTimeLimit.TabIndex = 0
        '
        'cmbNo
        '
        Me.cmbNo.DirectInput = false
        Me.cmbNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbNo.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbNo.Location = New System.Drawing.Point(0, 16)
        Me.cmbNo.Name = "cmbNo"
        Me.cmbNo.Size = New System.Drawing.Size(153, 22)
        Me.cmbNo.TabIndex = 0
        Me.cmbNo.Value = Nothing
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Navy
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(16, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(153, 17)
        Me.lblTitle.TabIndex = 19
        Me.lblTitle.Text = "時間制限番号"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraLimitProcess
        '
        Me.fraLimitProcess.Controls.Add(Me.picVector)
        Me.fraLimitProcess.Controls.Add(Me.lblFromOpId)
        Me.fraLimitProcess.Controls.Add(Me.lblFromStepId)
        Me.fraLimitProcess.Controls.Add(Me.lblToOpId)
        Me.fraLimitProcess.Controls.Add(Me.lblToStepId)
        Me.fraLimitProcess.Controls.Add(Me.lblToOp)
        Me.fraLimitProcess.Controls.Add(Me.lblFromOp)
        Me.fraLimitProcess.Controls.Add(Me.lblFromStep)
        Me.fraLimitProcess.Controls.Add(Me.lblToStep)
        Me.fraLimitProcess.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLimitProcess.Location = New System.Drawing.Point(8, 52)
        Me.fraLimitProcess.Name = "fraLimitProcess"
        Me.fraLimitProcess.Size = New System.Drawing.Size(569, 113)
        Me.fraLimitProcess.TabIndex = 13
        Me.fraLimitProcess.TabStop = false
        Me.fraLimitProcess.Text = "制限工程"
        '
        'picVector
        '
        Me.picVector.Image = CType(resources.GetObject("picVector.Image"),System.Drawing.Image)
        Me.picVector.Location = New System.Drawing.Point(266, 44)
        Me.picVector.Name = "picVector"
        Me.picVector.Size = New System.Drawing.Size(32, 32)
        Me.picVector.TabIndex = 20
        Me.picVector.TabStop = false
        '
        'lblFromOpId
        '
        Me.lblFromOpId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFromOpId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromOpId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFromOpId.Location = New System.Drawing.Point(8, 36)
        Me.lblFromOpId.Name = "lblFromOpId"
        Me.lblFromOpId.Size = New System.Drawing.Size(256, 17)
        Me.lblFromOpId.TabIndex = 9
        '
        'lblFromStepId
        '
        Me.lblFromStepId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFromStepId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromStepId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFromStepId.Location = New System.Drawing.Point(8, 84)
        Me.lblFromStepId.Name = "lblFromStepId"
        Me.lblFromStepId.Size = New System.Drawing.Size(256, 17)
        Me.lblFromStepId.TabIndex = 10
        '
        'lblToOpId
        '
        Me.lblToOpId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToOpId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblToOpId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblToOpId.Location = New System.Drawing.Point(302, 36)
        Me.lblToOpId.Name = "lblToOpId"
        Me.lblToOpId.Size = New System.Drawing.Size(256, 17)
        Me.lblToOpId.TabIndex = 11
        '
        'lblToStepId
        '
        Me.lblToStepId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToStepId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblToStepId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblToStepId.Location = New System.Drawing.Point(302, 84)
        Me.lblToStepId.Name = "lblToStepId"
        Me.lblToStepId.Size = New System.Drawing.Size(256, 17)
        Me.lblToStepId.TabIndex = 12
        '
        'lblToOp
        '
        Me.lblToOp.BackColor = System.Drawing.Color.Navy
        Me.lblToOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToOp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblToOp.ForeColor = System.Drawing.Color.Yellow
        Me.lblToOp.Location = New System.Drawing.Point(302, 20)
        Me.lblToOp.Name = "lblToOp"
        Me.lblToOp.Size = New System.Drawing.Size(256, 17)
        Me.lblToOp.TabIndex = 17
        Me.lblToOp.Text = "先大工程"
        Me.lblToOp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFromOp
        '
        Me.lblFromOp.BackColor = System.Drawing.Color.Navy
        Me.lblFromOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFromOp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromOp.ForeColor = System.Drawing.Color.Yellow
        Me.lblFromOp.Location = New System.Drawing.Point(8, 20)
        Me.lblFromOp.Name = "lblFromOp"
        Me.lblFromOp.Size = New System.Drawing.Size(256, 17)
        Me.lblFromOp.TabIndex = 16
        Me.lblFromOp.Text = "元大工程"
        Me.lblFromOp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFromStep
        '
        Me.lblFromStep.BackColor = System.Drawing.Color.Navy
        Me.lblFromStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFromStep.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromStep.ForeColor = System.Drawing.Color.Yellow
        Me.lblFromStep.Location = New System.Drawing.Point(8, 68)
        Me.lblFromStep.Name = "lblFromStep"
        Me.lblFromStep.Size = New System.Drawing.Size(256, 17)
        Me.lblFromStep.TabIndex = 15
        Me.lblFromStep.Text = "元小工程"
        Me.lblFromStep.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblToStep
        '
        Me.lblToStep.BackColor = System.Drawing.Color.Navy
        Me.lblToStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToStep.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblToStep.ForeColor = System.Drawing.Color.Yellow
        Me.lblToStep.Location = New System.Drawing.Point(302, 68)
        Me.lblToStep.Name = "lblToStep"
        Me.lblToStep.Size = New System.Drawing.Size(256, 17)
        Me.lblToStep.TabIndex = 14
        Me.lblToStep.Text = "先小工程"
        Me.lblToStep.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdSet
        '
        Me.cmdSet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSet.Location = New System.Drawing.Point(494, 298)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(85, 40)
        Me.cmdSet.TabIndex = 6
        Me.cmdSet.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 298)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxEN01X5
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(587, 345)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblLimit)
        Me.Controls.Add(Me.fraTitle1)
        Me.Controls.Add(Me.fraTitle0)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.fraTimeLimit)
        Me.Controls.Add(Me.fraLimitProcess)
        Me.Controls.Add(Me.cmdSet)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(16, 186)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01X5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "時間制限設定"
        Me.fraTitle1.ResumeLayout(false)
        Me.fraLimitTime.ResumeLayout(false)
        Me.fraLimitTime.PerformLayout
        Me.fraTitle0.ResumeLayout(false)
        Me.fraLimitType.ResumeLayout(false)
        Me.fraTimeLimit.ResumeLayout(false)
        Me.fraLimitProcess.ResumeLayout(false)
        CType(Me.picVector,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraTitle1 As GroupBox
    Friend WithEvents fraLimitTime As Panel
    Friend WithEvents txtWarning As SETextBoxEx.TextBoxEx
    Friend WithEvents txtLimit As SETextBoxEx.TextBoxEx
    Friend WithEvents lblMinute1 As Label
    Friend WithEvents lblMinute0 As Label
    Friend WithEvents lblLimit As Label
    Friend WithEvents lblWarning As Label
    Friend WithEvents fraTitle0 As GroupBox
    Friend WithEvents fraLimitType As Panel
    Friend WithEvents OptTimeLimit2 As RadioButton
    Friend WithEvents OptTimeLimit1 As RadioButton
    Friend WithEvents OptTimeLimit3 As RadioButton
    Friend WithEvents cmdDel As Button
    Friend WithEvents fraTimeLimit As Panel
    Friend WithEvents cmbNo As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle As Label
    Friend WithEvents fraLimitProcess As GroupBox
    Friend WithEvents picVector As PictureBox
    Friend WithEvents lblFromOpId As Label
    Friend WithEvents lblFromStepId As Label
    Friend WithEvents lblToOpId As Label
    Friend WithEvents lblToStepId As Label
    Friend WithEvents lblToOp As Label
    Friend WithEvents lblFromOp As Label
    Friend WithEvents lblFromStep As Label
    Friend WithEvents lblToStep As Label
    Friend WithEvents cmdSet As Button
    Friend WithEvents cmdClose As Button
End Class
