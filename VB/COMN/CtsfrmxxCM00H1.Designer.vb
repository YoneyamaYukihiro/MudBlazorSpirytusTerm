<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00H1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00H1))
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.fraWk = New System.Windows.Forms.GroupBox()
        Me.txtEvalNum = New SETextBoxEx.TextBoxEx()
        Me.lblTotalNum = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.txtTakeNum = New SETextBoxEx.TextBoxEx()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.txtUsualNum = New SETextBoxEx.TextBoxEx()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.txtCorrectNum = New SETextBoxEx.TextBoxEx()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.txtAmendNum = New SETextBoxEx.TextBoxEx()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.txtAbandonNum = New SETextBoxEx.TextBoxEx()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.txtHoldNum = New SETextBoxEx.TextBoxEx()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtLotID = New SETextBoxEx.TextBoxEx()
        Me.txtTotalNum = New SETextBoxEx.TextBoxEx()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Location = New System.Drawing.Point(248, 196)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(85, 40)
        Me.cmdSave.TabIndex = 10
        Me.cmdSave.Text = "入力確定"
        '
        'fraWk
        '
        Me.fraWk.Location = New System.Drawing.Point(8, 56)
        Me.fraWk.Name = "fraWk"
        Me.fraWk.Size = New System.Drawing.Size(413, 121)
        Me.fraWk.TabIndex = 14
        Me.fraWk.TabStop = false
        Me.fraWk.Text = "ロット処置"
        '
        'txtEvalNum
        '
        Me.txtEvalNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtEvalNum.ChrMaxByte = 10
        Me.txtEvalNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtEvalNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtEvalNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEvalNum.Location = New System.Drawing.Point(116, 140)
        Me.txtEvalNum.Name = "txtEvalNum"
        Me.txtEvalNum.NgChr = "'"
        Me.txtEvalNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtEvalNum.NumFormat = "#,##0"
        Me.txtEvalNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtEvalNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEvalNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEvalNum.SelectedText = ""
        Me.txtEvalNum.Size = New System.Drawing.Size(97, 22)
        Me.txtEvalNum.TabIndex = 7
        Me.txtEvalNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalNum
        '
        Me.lblTotalNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalNum.Location = New System.Drawing.Point(308, 140)
        Me.lblTotalNum.Name = "lblTotalNum"
        Me.lblTotalNum.Size = New System.Drawing.Size(97, 22)
        Me.lblTotalNum.TabIndex = 25
        Me.lblTotalNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(308, 123)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle9.TabIndex = 15
        Me.lblTitle9.Text = "合計"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTakeNum
        '
        Me.txtTakeNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtTakeNum.ChrMaxByte = 10
        Me.txtTakeNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtTakeNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtTakeNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtTakeNum.Location = New System.Drawing.Point(212, 140)
        Me.txtTakeNum.Name = "txtTakeNum"
        Me.txtTakeNum.NgChr = "'"
        Me.txtTakeNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtTakeNum.NumFormat = "#,##0"
        Me.txtTakeNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtTakeNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtTakeNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTakeNum.SelectedText = ""
        Me.txtTakeNum.Size = New System.Drawing.Size(97, 22)
        Me.txtTakeNum.TabIndex = 8
        Me.txtTakeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(212, 123)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle8.TabIndex = 16
        Me.lblTitle8.Text = "特採"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(116, 123)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle7.TabIndex = 17
        Me.lblTitle7.Text = "評価"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtUsualNum
        '
        Me.txtUsualNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtUsualNum.ChrMaxByte = 10
        Me.txtUsualNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtUsualNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtUsualNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtUsualNum.Location = New System.Drawing.Point(20, 140)
        Me.txtUsualNum.Name = "txtUsualNum"
        Me.txtUsualNum.NgChr = "'"
        Me.txtUsualNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtUsualNum.NumFormat = "#,##0"
        Me.txtUsualNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtUsualNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtUsualNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUsualNum.SelectedText = ""
        Me.txtUsualNum.Size = New System.Drawing.Size(97, 22)
        Me.txtUsualNum.TabIndex = 6
        Me.txtUsualNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(20, 123)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle6.TabIndex = 18
        Me.lblTitle6.Text = "通常"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCorrectNum
        '
        Me.txtCorrectNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCorrectNum.ChrMaxByte = 10
        Me.txtCorrectNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCorrectNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtCorrectNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCorrectNum.Location = New System.Drawing.Point(308, 92)
        Me.txtCorrectNum.Name = "txtCorrectNum"
        Me.txtCorrectNum.NgChr = "'"
        Me.txtCorrectNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCorrectNum.NumFormat = "#,##0"
        Me.txtCorrectNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtCorrectNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtCorrectNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCorrectNum.SelectedText = ""
        Me.txtCorrectNum.Size = New System.Drawing.Size(97, 22)
        Me.txtCorrectNum.TabIndex = 5
        Me.txtCorrectNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(308, 75)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle5.TabIndex = 19
        Me.lblTitle5.Text = "修正"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtAmendNum
        '
        Me.txtAmendNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtAmendNum.ChrMaxByte = 10
        Me.txtAmendNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtAmendNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtAmendNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtAmendNum.Location = New System.Drawing.Point(212, 92)
        Me.txtAmendNum.Name = "txtAmendNum"
        Me.txtAmendNum.NgChr = "'"
        Me.txtAmendNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtAmendNum.NumFormat = "#,##0"
        Me.txtAmendNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtAmendNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAmendNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAmendNum.SelectedText = ""
        Me.txtAmendNum.Size = New System.Drawing.Size(97, 22)
        Me.txtAmendNum.TabIndex = 4
        Me.txtAmendNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(211, 75)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle4.TabIndex = 20
        Me.lblTitle4.Text = "手直し"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtAbandonNum
        '
        Me.txtAbandonNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtAbandonNum.ChrMaxByte = 10
        Me.txtAbandonNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtAbandonNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtAbandonNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtAbandonNum.Location = New System.Drawing.Point(116, 92)
        Me.txtAbandonNum.Name = "txtAbandonNum"
        Me.txtAbandonNum.NgChr = "'"
        Me.txtAbandonNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtAbandonNum.NumFormat = "#,##0"
        Me.txtAbandonNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtAbandonNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAbandonNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAbandonNum.SelectedText = ""
        Me.txtAbandonNum.Size = New System.Drawing.Size(97, 22)
        Me.txtAbandonNum.TabIndex = 3
        Me.txtAbandonNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(115, 75)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle3.TabIndex = 21
        Me.lblTitle3.Text = "廃却"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtHoldNum
        '
        Me.txtHoldNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtHoldNum.ChrMaxByte = 10
        Me.txtHoldNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtHoldNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtHoldNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtHoldNum.Location = New System.Drawing.Point(20, 92)
        Me.txtHoldNum.Name = "txtHoldNum"
        Me.txtHoldNum.NgChr = "'"
        Me.txtHoldNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtHoldNum.NumFormat = "#,##0"
        Me.txtHoldNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtHoldNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtHoldNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHoldNum.SelectedText = ""
        Me.txtHoldNum.Size = New System.Drawing.Size(97, 22)
        Me.txtHoldNum.TabIndex = 2
        Me.txtHoldNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(20, 75)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle2.TabIndex = 22
        Me.lblTitle2.Text = "保留"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Location = New System.Drawing.Point(340, 196)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 9
        Me.cmdRegist.Text = "処置決定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 196)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 11
        Me.cmdClose.Text = "閉じる"
        '
        'txtLotID
        '
        Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLotID.ChrMaxByte = 10
        Me.txtLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotID.Location = New System.Drawing.Point(8, 25)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.NgChr = "'"
        Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotID.NumMax = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.txtLotID.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotID.SelectedText = ""
        Me.txtLotID.Size = New System.Drawing.Size(125, 22)
        Me.txtLotID.TabIndex = 0
        '
        'txtTotalNum
        '
        Me.txtTotalNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtTotalNum.ChrMaxByte = 10
        Me.txtTotalNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtTotalNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtTotalNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtTotalNum.Location = New System.Drawing.Point(140, 25)
        Me.txtTotalNum.Name = "txtTotalNum"
        Me.txtTotalNum.NgChr = "'"
        Me.txtTotalNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtTotalNum.NumFormat = "#,##0"
        Me.txtTotalNum.NumMax = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.txtTotalNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtTotalNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTotalNum.SelectedText = ""
        Me.txtTotalNum.Size = New System.Drawing.Size(97, 22)
        Me.txtTotalNum.TabIndex = 1
        Me.txtTotalNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(244, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 21)
        Me.lblStatus.TabIndex = 24
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(244, 8)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle10.TabIndex = 23
        Me.lblTitle10.Text = "状態"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(140, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle1.TabIndex = 13
        Me.lblTitle1.Text = "数量"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle0.TabIndex = 12
        Me.lblTitle0.Text = "ロットID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxCM00H1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(434, 244)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.txtEvalNum)
        Me.Controls.Add(Me.lblTotalNum)
        Me.Controls.Add(Me.lblTitle9)
        Me.Controls.Add(Me.txtTakeNum)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.txtUsualNum)
        Me.Controls.Add(Me.lblTitle6)
        Me.Controls.Add(Me.txtCorrectNum)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.txtAmendNum)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.txtAbandonNum)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.txtHoldNum)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.fraWk)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtLotID)
        Me.Controls.Add(Me.txtTotalNum)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTitle10)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00H1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "対象ロット処理"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdSave As Button
    Friend WithEvents fraWk As GroupBox
    Friend WithEvents txtHoldNum As SETextBoxEx.TextBoxEx
    Friend WithEvents txtAbandonNum As SETextBoxEx.TextBoxEx
    Friend WithEvents txtAmendNum As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCorrectNum As SETextBoxEx.TextBoxEx
    Friend WithEvents txtUsualNum As SETextBoxEx.TextBoxEx
    Friend WithEvents txtEvalNum As SETextBoxEx.TextBoxEx
    Friend WithEvents txtTakeNum As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTotalNum As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtTotalNum As SETextBoxEx.TextBoxEx
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
End Class
