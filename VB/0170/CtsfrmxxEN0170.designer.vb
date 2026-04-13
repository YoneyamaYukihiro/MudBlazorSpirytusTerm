<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0170
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0170))
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.fraEndClass = New System.Windows.Forms.Panel()
        Me.optScrapHoldTake0 = New System.Windows.Forms.RadioButton()
        Me.optScrapHoldTake1 = New System.Windows.Forms.RadioButton()
        Me.optScrapHoldTake2 = New System.Windows.Forms.RadioButton()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.cmbEndReason = New SEComboBoxEx.ComboBoxEx()
        Me.txtEmpID = New SETextBoxEx.TextBoxEx()
        Me.lblEmpIDTitle = New System.Windows.Forms.Label()
        Me.lblEmpName = New System.Windows.Forms.Label()
        Me.lblEmpNameTitle = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblTimeLimit = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblS = New System.Windows.Forms.Label()
        Me.lblStartDayTime = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblOpName = New System.Windows.Forms.Label()
        Me.lblStepName = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblWorkMemoTitle = New System.Windows.Forms.Label()
        Me.lblBackReason = New System.Windows.Forms.Label()
        Me.lblEndClassTitle = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.lblEndReasonTitle = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblGRB = New System.Windows.Forms.Label()
        Me.fraEndClass.SuspendLayout
        Me.SuspendLayout
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp.Location = New System.Drawing.Point(750, 487)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(49, 45)
        Me.cmdUp.TabIndex = 8
        Me.cmdUp.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(750, 530)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 45)
        Me.cmdDown.TabIndex = 9
        Me.cmdDown.Text = "▼"
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
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "閉じる"
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'fraEndClass
        '
        Me.fraEndClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraEndClass.Controls.Add(Me.optScrapHoldTake0)
        Me.fraEndClass.Controls.Add(Me.optScrapHoldTake1)
        Me.fraEndClass.Controls.Add(Me.optScrapHoldTake2)
        Me.fraEndClass.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraEndClass.Location = New System.Drawing.Point(16, 143)
        Me.fraEndClass.Name = "fraEndClass"
        Me.fraEndClass.Size = New System.Drawing.Size(313, 24)
        Me.fraEndClass.TabIndex = 1
        '
        'optScrapHoldTake0
        '
        Me.optScrapHoldTake0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optScrapHoldTake0.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optScrapHoldTake0.Location = New System.Drawing.Point(24, 0)
        Me.optScrapHoldTake0.Name = "optScrapHoldTake0"
        Me.optScrapHoldTake0.Size = New System.Drawing.Size(73, 25)
        Me.optScrapHoldTake0.TabIndex = 1
        Me.optScrapHoldTake0.Text = "不良"
        Me.optScrapHoldTake0.UseVisualStyleBackColor = false
        '
        'optScrapHoldTake1
        '
        Me.optScrapHoldTake1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optScrapHoldTake1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optScrapHoldTake1.Location = New System.Drawing.Point(128, 0)
        Me.optScrapHoldTake1.Name = "optScrapHoldTake1"
        Me.optScrapHoldTake1.Size = New System.Drawing.Size(73, 25)
        Me.optScrapHoldTake1.TabIndex = 2
        Me.optScrapHoldTake1.Text = "保留"
        Me.optScrapHoldTake1.UseVisualStyleBackColor = false
        '
        'optScrapHoldTake2
        '
        Me.optScrapHoldTake2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optScrapHoldTake2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optScrapHoldTake2.Location = New System.Drawing.Point(232, 0)
        Me.optScrapHoldTake2.Name = "optScrapHoldTake2"
        Me.optScrapHoldTake2.Size = New System.Drawing.Size(73, 25)
        Me.optScrapHoldTake2.TabIndex = 3
        Me.optScrapHoldTake2.Text = "払出"
        Me.optScrapHoldTake2.UseVisualStyleBackColor = false
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 505)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
        Me.txtWorkMemo.TabIndex = 7
        '
        'cmbEndReason
        '
        Me.cmbEndReason.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbEndReason.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbEndReason.Location = New System.Drawing.Point(348, 141)
        Me.cmbEndReason.Name = "cmbEndReason"
        Me.cmbEndReason.Size = New System.Drawing.Size(266, 28)
        Me.cmbEndReason.TabIndex = 4
        Me.cmbEndReason.Value = Nothing
        '
        'txtEmpID
        '
        Me.txtEmpID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtEmpID.ChrMaxByte = 0
        Me.txtEmpID.Enabled = false
        Me.txtEmpID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtEmpID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEmpID.Location = New System.Drawing.Point(624, 141)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtEmpID.NumMax = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.txtEmpID.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtEmpID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmpID.SelectedText = ""
        Me.txtEmpID.Size = New System.Drawing.Size(142, 28)
        Me.txtEmpID.TabIndex = 5
        '
        'lblEmpIDTitle
        '
        Me.lblEmpIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEmpIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEmpIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEmpIDTitle.Location = New System.Drawing.Point(624, 124)
        Me.lblEmpIDTitle.Name = "lblEmpIDTitle"
        Me.lblEmpIDTitle.Size = New System.Drawing.Size(142, 17)
        Me.lblEmpIDTitle.TabIndex = 42
        Me.lblEmpIDTitle.Text = "終了責任者ID"
        Me.lblEmpIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEmpName
        '
        Me.lblEmpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEmpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEmpName.Location = New System.Drawing.Point(766, 140)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(201, 29)
        Me.lblEmpName.TabIndex = 41
        Me.lblEmpName.Text = "笹谷　伸司"
        '
        'lblEmpNameTitle
        '
        Me.lblEmpNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEmpNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmpNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEmpNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEmpNameTitle.Location = New System.Drawing.Point(766, 124)
        Me.lblEmpNameTitle.Name = "lblEmpNameTitle"
        Me.lblEmpNameTitle.Size = New System.Drawing.Size(201, 17)
        Me.lblEmpNameTitle.TabIndex = 40
        Me.lblEmpNameTitle.Text = "終了責任者名"
        Me.lblEmpNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(312, 32)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
        Me.lblWFNo.TabIndex = 39
        Me.lblWFNo.Text = "8"
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(312, 64)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl10.TabIndex = 38
        Me.lblTtl10.Text = "時間制限"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTimeLimit
        '
        Me.lblTimeLimit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTimeLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTimeLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTimeLimit.Location = New System.Drawing.Point(312, 80)
        Me.lblTimeLimit.Name = "lblTimeLimit"
        Me.lblTimeLimit.Size = New System.Drawing.Size(97, 25)
        Me.lblTimeLimit.TabIndex = 37
        Me.lblTimeLimit.Text = "無し"
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(688, 64)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl9.TabIndex = 36
        Me.lblTtl9.Text = "ロット担当"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotManager
        '
        Me.lblLotManager.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(688, 80)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(181, 25)
        Me.lblLotManager.TabIndex = 35
        Me.lblLotManager.Text = "笹谷　伸司"
        '
        'lblPdID
        '
        Me.lblPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(216, 32)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblPdID.TabIndex = 34
        Me.lblPdID.Text = "GTA"
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl3.TabIndex = 33
        Me.lblTtl3.Text = "機種"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(312, 16)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl5.TabIndex = 32
        Me.lblTtl5.Text = "数量"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblS
        '
        Me.lblS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblS.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblS.Location = New System.Drawing.Point(868, 32)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(97, 25)
        Me.lblS.TabIndex = 31
        Me.lblS.Text = "なし"
        '
        'lblStartDayTime
        '
        Me.lblStartDayTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStartDayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDayTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDayTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStartDayTime.Location = New System.Drawing.Point(688, 32)
        Me.lblStartDayTime.Name = "lblStartDayTime"
        Me.lblStartDayTime.Size = New System.Drawing.Size(181, 25)
        Me.lblStartDayTime.TabIndex = 30
        Me.lblStartDayTime.Text = "2004/12/04 13:30"
        '
        'lblStartTime
        '
        Me.lblStartTime.BackColor = System.Drawing.Color.Navy
        Me.lblStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartTime.ForeColor = System.Drawing.Color.Yellow
        Me.lblStartTime.Location = New System.Drawing.Point(688, 16)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(181, 17)
        Me.lblStartTime.TabIndex = 29
        Me.lblStartTime.Text = "処理開始日時"
        Me.lblStartTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(868, 16)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl6.TabIndex = 28
        Me.lblTtl6.Text = "特殊特性"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(408, 16)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl2.TabIndex = 27
        Me.lblTtl2.Text = "大工程"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpName
        '
        Me.lblOpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpName.Location = New System.Drawing.Point(408, 32)
        Me.lblOpName.Name = "lblOpName"
        Me.lblOpName.Size = New System.Drawing.Size(281, 25)
        Me.lblOpName.TabIndex = 26
        Me.lblOpName.Text = "投入"
        '
        'lblStepName
        '
        Me.lblStepName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepName.Location = New System.Drawing.Point(408, 80)
        Me.lblStepName.Name = "lblStepName"
        Me.lblStepName.Size = New System.Drawing.Size(281, 25)
        Me.lblStepName.TabIndex = 25
        Me.lblStepName.Text = "ﾅﾝﾊﾞﾘﾝｸﾞ"
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(408, 64)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 24
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!)
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(497, 489)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 22
        Me.lblLengthCount.Text = "　（半角2048文字/半角2048文字）"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblWorkMemoTitle
        '
        Me.lblWorkMemoTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWorkMemoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWorkMemoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWorkMemoTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWorkMemoTitle.Location = New System.Drawing.Point(8, 488)
        Me.lblWorkMemoTitle.Name = "lblWorkMemoTitle"
        Me.lblWorkMemoTitle.Size = New System.Drawing.Size(743, 17)
        Me.lblWorkMemoTitle.TabIndex = 23
        Me.lblWorkMemoTitle.Text = "      作業メモ"
        Me.lblWorkMemoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBackReason
        '
        Me.lblBackReason.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBackReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackReason.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBackReason.Location = New System.Drawing.Point(8, 141)
        Me.lblBackReason.Name = "lblBackReason"
        Me.lblBackReason.Size = New System.Drawing.Size(329, 28)
        Me.lblBackReason.TabIndex = 21
        '
        'lblEndClassTitle
        '
        Me.lblEndClassTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEndClassTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEndClassTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEndClassTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEndClassTitle.Location = New System.Drawing.Point(8, 124)
        Me.lblEndClassTitle.Name = "lblEndClassTitle"
        Me.lblEndClassTitle.Size = New System.Drawing.Size(329, 17)
        Me.lblEndClassTitle.TabIndex = 12
        Me.lblEndClassTitle.Text = "終了区分"
        Me.lblEndClassTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(216, 64)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl7.TabIndex = 20
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblStatus.TabIndex = 19
        Me.lblStatus.Text = "待機中"
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
        Me.lblLotID.TabIndex = 18
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
        Me.lblTtl0.TabIndex = 17
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
        Me.lblFlowClass.TabIndex = 16
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
        Me.lblTtl1.TabIndex = 15
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 105)
        Me.lblBack.TabIndex = 14
        '
        'lblEndReasonTitle
        '
        Me.lblEndReasonTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEndReasonTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEndReasonTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEndReasonTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEndReasonTitle.Location = New System.Drawing.Point(348, 124)
        Me.lblEndReasonTitle.Name = "lblEndReasonTitle"
        Me.lblEndReasonTitle.Size = New System.Drawing.Size(266, 17)
        Me.lblEndReasonTitle.TabIndex = 13
        Me.lblEndReasonTitle.Text = "終了理由"
        Me.lblEndReasonTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(868, 64)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl4.TabIndex = 43
        Me.lblTtl4.Text = "GRB"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGRB
        '
        Me.lblGRB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGRB.Location = New System.Drawing.Point(868, 80)
        Me.lblGRB.Name = "lblGRB"
        Me.lblGRB.Size = New System.Drawing.Size(97, 25)
        Me.lblGRB.TabIndex = 44
        '
        'frmxxEN0170
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblGRB)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.fraEndClass)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.cmbEndReason)
        Me.Controls.Add(Me.txtEmpID)
        Me.Controls.Add(Me.lblEmpIDTitle)
        Me.Controls.Add(Me.lblEmpName)
        Me.Controls.Add(Me.lblEmpNameTitle)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblTimeLimit)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblS)
        Me.Controls.Add(Me.lblStartDayTime)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblOpName)
        Me.Controls.Add(Me.lblStepName)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblWorkMemoTitle)
        Me.Controls.Add(Me.lblBackReason)
        Me.Controls.Add(Me.lblEndClassTitle)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblBack)
        Me.Controls.Add(Me.lblEndReasonTitle)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0170"
        Me.Text = "ロット終了"
        Me.fraEndClass.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents fraEndClass As Panel
    Friend WithEvents optScrapHoldTake0 As RadioButton
    Friend WithEvents optScrapHoldTake1 As RadioButton
    Friend WithEvents optScrapHoldTake2 As RadioButton
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbEndReason As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtEmpID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblEmpIDTitle As Label
    Friend WithEvents lblEmpName As Label
    Friend WithEvents lblEmpNameTitle As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblTimeLimit As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblS As Label
    Friend WithEvents lblStartDayTime As Label
    Friend WithEvents lblStartTime As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblOpName As Label
    Friend WithEvents lblStepName As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblWorkMemoTitle As Label
    Friend WithEvents lblBackReason As Label
    Friend WithEvents lblEndClassTitle As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents lblEndReasonTitle As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblGRB As Label
End Class
