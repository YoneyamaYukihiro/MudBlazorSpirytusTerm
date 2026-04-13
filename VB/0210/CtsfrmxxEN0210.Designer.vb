<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0210
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0210))
        Me.fraCFInfo = New System.Windows.Forms.GroupBox()
        Me.txtCFLotID = New SETextBoxEx.TextBoxEx()
        Me.cmbBoardThickness = New SEComboBoxEx.ComboBoxEx()
        Me.cmbRework = New SEComboBoxEx.ComboBoxEx()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.fraCommPart = New System.Windows.Forms.GroupBox()
        Me.cmdNowDate = New System.Windows.Forms.Button()
        Me.medTime = New System.Windows.Forms.MaskedTextBox()
        Me.calDate = New SECalendarEx.CalendarEx()
        Me.txtInvLotID = New SETextBoxEx.TextBoxEx()
        Me.txtPartNum = New SETextBoxEx.TextBoxEx()
        Me.txtCaseNum = New SETextBoxEx.TextBoxEx()
        Me.txtUser = New SETextBoxEx.TextBoxEx()
        Me.lblEmpName = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbPartClass = New SEComboBoxEx.ComboBoxEx()
        Me.cmbPart = New SEComboBoxEx.ComboBoxEx()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.fraCFInfo.SuspendLayout
        Me.fraCommPart.SuspendLayout
        Me.SuspendLayout
        '
        'fraCFInfo
        '
        Me.fraCFInfo.Controls.Add(Me.txtCFLotID)
        Me.fraCFInfo.Controls.Add(Me.cmbBoardThickness)
        Me.fraCFInfo.Controls.Add(Me.cmbRework)
        Me.fraCFInfo.Controls.Add(Me.lblTtl9)
        Me.fraCFInfo.Controls.Add(Me.lblTtl8)
        Me.fraCFInfo.Controls.Add(Me.lblTtl7)
        Me.fraCFInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCFInfo.Location = New System.Drawing.Point(8, 296)
        Me.fraCFInfo.Name = "fraCFInfo"
        Me.fraCFInfo.Size = New System.Drawing.Size(553, 101)
        Me.fraCFInfo.TabIndex = 5
        Me.fraCFInfo.TabStop = false
        Me.fraCFInfo.Text = "CF受入時追加入力"
        '
        'txtCFLotID
        '
        Me.txtCFLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCFLotID.ChrMaxByte = 10
        Me.txtCFLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
        Me.txtCFLotID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCFLotID.Location = New System.Drawing.Point(8, 48)
        Me.txtCFLotID.Name = "txtCFLotID"
        Me.txtCFLotID.NgChr = "'"
        Me.txtCFLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCFLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCFLotID.SelectedText = ""
        Me.txtCFLotID.Size = New System.Drawing.Size(125, 30)
        Me.txtCFLotID.TabIndex = 9
        '
        'cmbBoardThickness
        '
        Me.cmbBoardThickness.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbBoardThickness.ForeColor = System.Drawing.Color.Black
        Me.cmbBoardThickness.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbBoardThickness.GridForeColor = System.Drawing.Color.Black
        Me.cmbBoardThickness.Location = New System.Drawing.Point(148, 48)
        Me.cmbBoardThickness.Name = "cmbBoardThickness"
        Me.cmbBoardThickness.Size = New System.Drawing.Size(101, 28)
        Me.cmbBoardThickness.TabIndex = 10
        Me.cmbBoardThickness.Value = Nothing
        '
        'cmbRework
        '
        Me.cmbRework.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRework.ForeColor = System.Drawing.Color.Black
        Me.cmbRework.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRework.GridForeColor = System.Drawing.Color.Black
        Me.cmbRework.Location = New System.Drawing.Point(264, 48)
        Me.cmbRework.Name = "cmbRework"
        Me.cmbRework.Size = New System.Drawing.Size(106, 28)
        Me.cmbRework.TabIndex = 11
        Me.cmbRework.Value = Nothing
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(264, 32)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(106, 17)
        Me.lblTtl9.TabIndex = 25
        Me.lblTtl9.Text = "リワーク回数"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(148, 32)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(101, 17)
        Me.lblTtl8.TabIndex = 24
        Me.lblTtl8.Text = "板厚"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(8, 32)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(125, 17)
        Me.lblTtl7.TabIndex = 23
        Me.lblTtl7.Text = "出荷ロットID"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraCommPart
        '
        Me.fraCommPart.Controls.Add(Me.cmdNowDate)
        Me.fraCommPart.Controls.Add(Me.medTime)
        Me.fraCommPart.Controls.Add(Me.calDate)
        Me.fraCommPart.Controls.Add(Me.txtInvLotID)
        Me.fraCommPart.Controls.Add(Me.txtPartNum)
        Me.fraCommPart.Controls.Add(Me.txtCaseNum)
        Me.fraCommPart.Controls.Add(Me.txtUser)
        Me.fraCommPart.Controls.Add(Me.lblEmpName)
        Me.fraCommPart.Controls.Add(Me.lblTtl10)
        Me.fraCommPart.Controls.Add(Me.lblTtl6)
        Me.fraCommPart.Controls.Add(Me.lblTtl5)
        Me.fraCommPart.Controls.Add(Me.lblTtl4)
        Me.fraCommPart.Controls.Add(Me.lblTtl3)
        Me.fraCommPart.Controls.Add(Me.lblTtl2)
        Me.fraCommPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCommPart.Location = New System.Drawing.Point(9, 69)
        Me.fraCommPart.Name = "fraCommPart"
        Me.fraCommPart.Size = New System.Drawing.Size(553, 213)
        Me.fraCommPart.TabIndex = 4
        Me.fraCommPart.TabStop = false
        Me.fraCommPart.Text = "共通部分"
        '
        'cmdNowDate
        '
        Me.cmdNowDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowDate.Location = New System.Drawing.Point(437, 87)
        Me.cmdNowDate.Name = "cmdNowDate"
        Me.cmdNowDate.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowDate.TabIndex = 7
        Me.cmdNowDate.TabStop = false
        Me.cmdNowDate.Text = "現在日時"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"取得"
        '
        'medTime
        '
        Me.medTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medTime.Location = New System.Drawing.Point(368, 104)
        Me.medTime.Mask = "##:##"
        Me.medTime.Name = "medTime"
        Me.medTime.Size = New System.Drawing.Size(69, 28)
        Me.medTime.TabIndex = 6
        '
        'calDate
        '
        Me.calDate.DateCheckStatus = 0
        Me.calDate.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calDate.IsDate = true
        Me.calDate.Location = New System.Drawing.Point(216, 104)
        Me.calDate.Name = "calDate"
        Me.calDate.Size = New System.Drawing.Size(153, 28)
        Me.calDate.TabIndex = 5
        Me.calDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calDate.Value = "____/__/__"
        '
        'txtInvLotID
        '
        Me.txtInvLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtInvLotID.ChrMaxByte = 12
        Me.txtInvLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
        Me.txtInvLotID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtInvLotID.Location = New System.Drawing.Point(8, 44)
        Me.txtInvLotID.Name = "txtInvLotID"
        Me.txtInvLotID.NgChr = "'"
        Me.txtInvLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtInvLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtInvLotID.SelectedText = ""
        Me.txtInvLotID.Size = New System.Drawing.Size(193, 30)
        Me.txtInvLotID.TabIndex = 2
        '
        'txtPartNum
        '
        Me.txtPartNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtPartNum.ChrMaxByte = 8
        Me.txtPartNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtPartNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPartNum.Location = New System.Drawing.Point(8, 104)
        Me.txtPartNum.Name = "txtPartNum"
        Me.txtPartNum.NgChr = "'"
        Me.txtPartNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPartNum.NumMax = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtPartNum.NumMin = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPartNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPartNum.SelectedText = ""
        Me.txtPartNum.Size = New System.Drawing.Size(125, 30)
        Me.txtPartNum.TabIndex = 3
        Me.txtPartNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCaseNum
        '
        Me.txtCaseNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCaseNum.ChrMaxByte = 8
        Me.txtCaseNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtCaseNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCaseNum.Location = New System.Drawing.Point(132, 104)
        Me.txtCaseNum.Name = "txtCaseNum"
        Me.txtCaseNum.NgChr = "'"
        Me.txtCaseNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCaseNum.NumMax = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtCaseNum.NumMin = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCaseNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCaseNum.SelectedText = ""
        Me.txtCaseNum.Size = New System.Drawing.Size(69, 30)
        Me.txtCaseNum.TabIndex = 4
        Me.txtCaseNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUser
        '
        Me.txtUser.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtUser.ChrMaxByte = 0
        Me.txtUser.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtUser.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtUser.Location = New System.Drawing.Point(9, 163)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.NgChr = "'"
        Me.txtUser.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtUser.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUser.SelectedText = ""
        Me.txtUser.Size = New System.Drawing.Size(193, 30)
        Me.txtUser.TabIndex = 8
        '
        'lblEmpName
        '
        Me.lblEmpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEmpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEmpName.Location = New System.Drawing.Point(216, 163)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(221, 30)
        Me.lblEmpName.TabIndex = 27
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(216, 147)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(221, 17)
        Me.lblTtl10.TabIndex = 26
        Me.lblTtl10.Text = "受入担当者名"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(9, 147)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(193, 17)
        Me.lblTtl6.TabIndex = 21
        Me.lblTtl6.Text = "受入担当者ID"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(216, 88)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(222, 17)
        Me.lblTtl5.TabIndex = 20
        Me.lblTtl5.Text = "受入日時"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(132, 88)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(69, 17)
        Me.lblTtl4.TabIndex = 19
        Me.lblTtl4.Text = "ケース数"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(8, 88)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(125, 17)
        Me.lblTtl3.TabIndex = 18
        Me.lblTtl3.Text = "受入数"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(8, 28)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(193, 17)
        Me.lblTtl2.TabIndex = 17
        Me.lblTtl2.Text = "製造ロットID"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 579)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 6
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 579)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "閉じる"
        '
        'cmbPartClass
        '
        Me.cmbPartClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartClass.ForeColor = System.Drawing.Color.Black
        Me.cmbPartClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartClass.GridForeColor = System.Drawing.Color.Black
        Me.cmbPartClass.Location = New System.Drawing.Point(8, 24)
        Me.cmbPartClass.Name = "cmbPartClass"
        Me.cmbPartClass.Size = New System.Drawing.Size(261, 28)
        Me.cmbPartClass.TabIndex = 0
        Me.cmbPartClass.Value = Nothing
        '
        'cmbPart
        '
        Me.cmbPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.ForeColor = System.Drawing.Color.Black
        Me.cmbPart.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridForeColor = System.Drawing.Color.Black
        Me.cmbPart.Location = New System.Drawing.Point(268, 24)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(661, 28)
        Me.cmbPart.TabIndex = 1
        Me.cmbPart.Value = Nothing
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(268, 8)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(661, 17)
        Me.lblTtl1.TabIndex = 3
        Me.lblTtl1.Text = "部品"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 8)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(261, 17)
        Me.lblTtl0.TabIndex = 2
        Me.lblTtl0.Text = "部品種別"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN0210
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.fraCFInfo)
        Me.Controls.Add(Me.fraCommPart)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmbPartClass)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl0)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0210"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "部材受入"
        Me.fraCFInfo.ResumeLayout(false)
        Me.fraCommPart.ResumeLayout(false)
        Me.fraCommPart.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraCFInfo As GroupBox
    Friend WithEvents txtCFLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbBoardThickness As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbRework As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents fraCommPart As GroupBox
    Friend WithEvents cmdNowDate As Button
    Friend WithEvents medTime As MaskedTextBox
    Friend WithEvents calDate As SECalendarEx.CalendarEx
    Friend WithEvents txtInvLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPartNum As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCaseNum As SETextBoxEx.TextBoxEx
    Friend WithEvents txtUser As SETextBoxEx.TextBoxEx
    Friend WithEvents lblEmpName As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmbPartClass As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPart As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl0 As Label
End Class
