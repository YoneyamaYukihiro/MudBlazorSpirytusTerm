<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00R0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00R0))
        Me.cmdRethrowin = New System.Windows.Forms.Button()
        Me.cmdLoad1 = New System.Windows.Forms.Button()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdTxtDown = New System.Windows.Forms.Button()
        Me.cmdTxtUp = New System.Windows.Forms.Button()
        Me.txtLotCommnt = New SETextBoxEx.TextBoxEx()
        Me.txtOpeCond = New SETextBoxEx.TextBoxEx()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.cmbPort = New SEComboBoxEx.ComboBoxEx()
        Me.cmdCommntInput = New System.Windows.Forms.Button()
        Me.cmdLoad0 = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.lblTtl14 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblWP = New System.Windows.Forms.Label()
        Me.lblTtl16 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTtl17 = New System.Windows.Forms.Label()
        Me.lblTtl17.SuspendLayout
        Me.SuspendLayout
        '
        'cmdRethrowin
        '
        Me.cmdRethrowin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRethrowin.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRethrowin.Location = New System.Drawing.Point(656, 579)
        Me.cmdRethrowin.Name = "cmdRethrowin"
        Me.cmdRethrowin.Size = New System.Drawing.Size(105, 57)
        Me.cmdRethrowin.TabIndex = 4
        Me.cmdRethrowin.Text = "再投入"
        '
        'cmdLoad1
        '
        Me.cmdLoad1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLoad1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLoad1.Location = New System.Drawing.Point(764, 579)
        Me.cmdLoad1.Name = "cmdLoad1"
        Me.cmdLoad1.Size = New System.Drawing.Size(105, 57)
        Me.cmdLoad1.TabIndex = 3
        Me.cmdLoad1.Text = "Unload"
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(751, 367)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoUp.TabIndex = 8
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(751, 411)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 9
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdTxtDown
        '
        Me.cmdTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtDown.Location = New System.Drawing.Point(751, 518)
        Me.cmdTxtDown.Name = "cmdTxtDown"
        Me.cmdTxtDown.Size = New System.Drawing.Size(49, 55)
        Me.cmdTxtDown.TabIndex = 12
        Me.cmdTxtDown.Text = "▼"
        '
        'cmdTxtUp
        '
        Me.cmdTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtUp.Location = New System.Drawing.Point(751, 463)
        Me.cmdTxtUp.Name = "cmdTxtUp"
        Me.cmdTxtUp.Size = New System.Drawing.Size(49, 55)
        Me.cmdTxtUp.TabIndex = 11
        Me.cmdTxtUp.Text = "▲"
        '
        'txtLotCommnt
        '
        Me.txtLotCommnt.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtLotCommnt.ChrMaxByte = 0
        Me.txtLotCommnt.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtLotCommnt.GotHighLight = false
        Me.txtLotCommnt.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotCommnt.Location = New System.Drawing.Point(8, 480)
        Me.txtLotCommnt.MultiLineEx = true
        Me.txtLotCommnt.Name = "txtLotCommnt"
        Me.txtLotCommnt.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotCommnt.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotCommnt.SelectedText = ""
        Me.txtLotCommnt.Size = New System.Drawing.Size(743, 92)
        Me.txtLotCommnt.TabIndex = 10
        Me.txtLotCommnt.TabStop = false
        '
        'txtOpeCond
        '
        Me.txtOpeCond.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtOpeCond.ChrMaxByte = 128
        Me.txtOpeCond.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtOpeCond.GotHighLight = false
        Me.txtOpeCond.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtOpeCond.Location = New System.Drawing.Point(8, 308)
        Me.txtOpeCond.MultiLineEx = true
        Me.txtOpeCond.Name = "txtOpeCond"
        Me.txtOpeCond.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtOpeCond.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOpeCond.SelectedText = ""
        Me.txtOpeCond.Size = New System.Drawing.Size(743, 49)
        Me.txtOpeCond.TabIndex = 6
        Me.txtOpeCond.TabStop = false
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'cmbPort
        '
        Me.cmbPort.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPort.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPort.Location = New System.Drawing.Point(312, 140)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(161, 28)
        Me.cmbPort.TabIndex = 1
        Me.cmbPort.Value = Nothing
        Me.cmbPort.ValueCol = 1
        '
        'cmdCommntInput
        '
        Me.cmdCommntInput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommntInput.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommntInput.Location = New System.Drawing.Point(332, 579)
        Me.cmdCommntInput.Name = "cmdCommntInput"
        Me.cmdCommntInput.Size = New System.Drawing.Size(105, 57)
        Me.cmdCommntInput.TabIndex = 5
        Me.cmdCommntInput.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdLoad0
        '
        Me.cmdLoad0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLoad0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLoad0.Location = New System.Drawing.Point(872, 579)
        Me.cmdLoad0.Name = "cmdLoad0"
        Me.cmdLoad0.Size = New System.Drawing.Size(105, 57)
        Me.cmdLoad0.TabIndex = 2
        Me.cmdLoad0.Text = "Load"
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
        Me.cmdClose.TabIndex = 13
        Me.cmdClose.Text = "閉じる"
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 384)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
        Me.txtWorkMemo.TabIndex = 7
        '
        'lblTtl14
        '
        Me.lblTtl14.BackColor = System.Drawing.Color.Navy
        Me.lblTtl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl14.Location = New System.Drawing.Point(216, 64)
        Me.lblTtl14.Name = "lblTtl14"
        Me.lblTtl14.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl14.TabIndex = 33
        Me.lblTtl14.Text = "状態"
        Me.lblTtl14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(216, 80)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblStatus.TabIndex = 32
        Me.lblStatus.Text = "前処理"
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(312, 64)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 31
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(312, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 30
        Me.lblStepID.Text = "ﾅﾝﾊﾞﾘﾝｸﾞ"
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(312, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID.TabIndex = 29
        Me.lblOpID.Text = "投入"
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(312, 16)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl7.TabIndex = 28
        Me.lblTtl7.Text = "大工程"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl5.TabIndex = 27
        Me.lblTtl5.Text = "数量"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(216, 32)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
        Me.lblWFNo.TabIndex = 26
        Me.lblWFNo.Text = "8"
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(479, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(256, 17)
        Me.lblLengthCount.TabIndex = 24
        Me.lblLengthCount.Text = "（ 半角2048文字/半角2048文字 ）"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblWP
        '
        Me.lblWP.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWP.Location = New System.Drawing.Point(8, 140)
        Me.lblWP.Name = "lblWP"
        Me.lblWP.Size = New System.Drawing.Size(305, 28)
        Me.lblWP.TabIndex = 23
        Me.lblWP.Text = "移載機＃２１"
        '
        'lblTtl16
        '
        Me.lblTtl16.BackColor = System.Drawing.Color.Navy
        Me.lblTtl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl16.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl16.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl16.Location = New System.Drawing.Point(8, 464)
        Me.lblTtl16.Name = "lblTtl16"
        Me.lblTtl16.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl16.TabIndex = 22
        Me.lblTtl16.Text = "      コメント"
        Me.lblTtl16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(16, 80)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 21
        Me.lblLotID.Text = "GTA1234-00"
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(16, 16)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl0.TabIndex = 20
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 19
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(16, 64)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 18
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 105)
        Me.lblBack.TabIndex = 17
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(312, 124)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(161, 17)
        Me.lblTtl12.TabIndex = 16
        Me.lblTtl12.Text = "ポート№"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(8, 124)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(305, 17)
        Me.lblTtl11.TabIndex = 15
        Me.lblTtl11.Text = "装置名"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 292)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl15.TabIndex = 14
        Me.lblTtl15.Text = "      作業条件"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl17
        '
        Me.lblTtl17.BackColor = System.Drawing.Color.Navy
        Me.lblTtl17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl17.Controls.Add(Me.lblLengthCount)
        Me.lblTtl17.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl17.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl17.Location = New System.Drawing.Point(8, 368)
        Me.lblTtl17.Name = "lblTtl17"
        Me.lblTtl17.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl17.TabIndex = 25
        Me.lblTtl17.Text = "      作業メモ"
        Me.lblTtl17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00R0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblTtl12)
        Me.Controls.Add(Me.cmdRethrowin)
        Me.Controls.Add(Me.cmdLoad1)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdTxtDown)
        Me.Controls.Add(Me.cmdTxtUp)
        Me.Controls.Add(Me.txtLotCommnt)
        Me.Controls.Add(Me.txtOpeCond)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.cmbPort)
        Me.Controls.Add(Me.cmdCommntInput)
        Me.Controls.Add(Me.cmdLoad0)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.lblTtl14)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblWP)
        Me.Controls.Add(Me.lblTtl16)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblBack)
        Me.Controls.Add(Me.lblTtl11)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.lblTtl17)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00R0"
        Me.Text = "ダミー管理（ヒート）"
        Me.lblTtl17.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdRethrowin As Button
    Friend WithEvents cmdLoad1 As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdTxtDown As Button
    Friend WithEvents cmdTxtUp As Button
    Friend WithEvents txtLotCommnt As SETextBoxEx.TextBoxEx
    Friend WithEvents txtOpeCond As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbPort As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmdCommntInput As Button
    Friend WithEvents cmdLoad0 As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl14 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblWP As Label
    Friend WithEvents lblTtl16 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTtl17 As Label
End Class
