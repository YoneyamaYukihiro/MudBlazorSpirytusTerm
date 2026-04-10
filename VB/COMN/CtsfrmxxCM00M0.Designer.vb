<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00M0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00M0))
        Me.cmdCommentDown = New System.Windows.Forms.Button()
        Me.cmdCommentUp = New System.Windows.Forms.Button()
        Me.fraMster = New System.Windows.Forms.GroupBox()
        Me.cmdEntry = New System.Windows.Forms.Button()
        Me.lblEntryID = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblEntryName = New System.Windows.Forms.Label()
        Me.cmdWorkMemoUp = New System.Windows.Forms.Button()
        Me.cmdWorkMemoDown = New System.Windows.Forms.Button()
        Me.fraLotCreate = New System.Windows.Forms.Panel()
        Me.optNew = New System.Windows.Forms.RadioButton()
        Me.optDivide = New System.Windows.Forms.RadioButton()
        Me.fraCopy = New System.Windows.Forms.GroupBox()
        Me.cmdCopyLotID = New System.Windows.Forms.Button()
        Me.txtCopyLotID = New SETextBoxEx.TextBoxEx()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.cmdPlanList = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraNew = New System.Windows.Forms.GroupBox()
        Me.picPrClass = New System.Windows.Forms.PictureBox()
        Me.fraPrClass = New System.Windows.Forms.Panel()
        Me.optPrClass1 = New System.Windows.Forms.RadioButton()
        Me.optPrClass0 = New System.Windows.Forms.RadioButton()
        Me.calStartDate = New SECalendarEx.CalendarEx()
        Me.txtWFNum = New SETextBoxEx.TextBoxEx()
        Me.cmbLotManager = New SEComboBoxEx.ComboBoxEx()
        Me.cmbDivision = New SEComboBoxEx.ComboBoxEx()
        Me.cmbPd = New SEComboBoxEx.ComboBoxEx()
        Me.cmbPrOrder = New SEComboBoxEx.ComboBoxEx()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblTtl14 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.fraDivide = New System.Windows.Forms.GroupBox()
        Me.cmdDivideLotID = New System.Windows.Forms.Button()
        Me.txtDivideLotID = New SETextBoxEx.TextBoxEx()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.fraPDCreate = New System.Windows.Forms.Panel()
        Me.optCopy = New System.Windows.Forms.RadioButton()
        Me.optMster = New System.Windows.Forms.RadioButton()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.txtOrderComment = New SETextBoxEx.TextBoxEx()
        Me.cmbLotSend = New SEComboBoxEx.ComboBoxEx()
        Me.cmbLotThrowinNum = New SEComboBoxEx.ComboBoxEx()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblBackGround0 = New System.Windows.Forms.Label()
        Me.lblBackGround1 = New System.Windows.Forms.Label()
        Me.fraMster.SuspendLayout
        Me.fraLotCreate.SuspendLayout
        Me.fraCopy.SuspendLayout
        Me.fraNew.SuspendLayout
        CType(Me.picPrClass,System.ComponentModel.ISupportInitialize).BeginInit
        Me.picPrClass.SuspendLayout
        Me.fraPrClass.SuspendLayout
        Me.fraDivide.SuspendLayout
        Me.fraPDCreate.SuspendLayout
        Me.SuspendLayout
        '
        'cmdCommentDown
        '
        Me.cmdCommentDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentDown.Location = New System.Drawing.Point(805, 182)
        Me.cmdCommentDown.Name = "cmdCommentDown"
        Me.cmdCommentDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdCommentDown.TabIndex = 14
        Me.cmdCommentDown.Text = "▼"
        '
        'cmdCommentUp
        '
        Me.cmdCommentUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentUp.Location = New System.Drawing.Point(805, 137)
        Me.cmdCommentUp.Name = "cmdCommentUp"
        Me.cmdCommentUp.Size = New System.Drawing.Size(49, 44)
        Me.cmdCommentUp.TabIndex = 13
        Me.cmdCommentUp.Text = "▲"
        '
        'fraMster
        '
        Me.fraMster.Controls.Add(Me.cmdEntry)
        Me.fraMster.Controls.Add(Me.lblEntryID)
        Me.fraMster.Controls.Add(Me.lblTitle10)
        Me.fraMster.Controls.Add(Me.lblTitle8)
        Me.fraMster.Controls.Add(Me.lblEntryName)
        Me.fraMster.Location = New System.Drawing.Point(50, 272)
        Me.fraMster.Name = "fraMster"
        Me.fraMster.Size = New System.Drawing.Size(335, 141)
        Me.fraMster.TabIndex = 17
        Me.fraMster.TabStop = false
        Me.fraMster.Text = "マスタ工順"
        '
        'cmdEntry
        '
        Me.cmdEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEntry.Location = New System.Drawing.Point(212, 20)
        Me.cmdEntry.Name = "cmdEntry"
        Me.cmdEntry.Size = New System.Drawing.Size(105, 57)
        Me.cmdEntry.TabIndex = 17
        Me.cmdEntry.Text = "エントリ"
        '
        'lblEntryID
        '
        Me.lblEntryID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEntryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEntryID.Location = New System.Drawing.Point(16, 36)
        Me.lblEntryID.Name = "lblEntryID"
        Me.lblEntryID.Size = New System.Drawing.Size(177, 29)
        Me.lblEntryID.TabIndex = 52
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(16, 20)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(177, 17)
        Me.lblTitle10.TabIndex = 51
        Me.lblTitle10.Text = "エントリ"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(16, 84)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(301, 17)
        Me.lblTitle8.TabIndex = 50
        Me.lblTitle8.Text = "エントリ名"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEntryName
        '
        Me.lblEntryName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEntryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEntryName.Location = New System.Drawing.Point(16, 100)
        Me.lblEntryName.Name = "lblEntryName"
        Me.lblEntryName.Size = New System.Drawing.Size(301, 29)
        Me.lblEntryName.TabIndex = 49
        '
        'cmdWorkMemoUp
        '
        Me.cmdWorkMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWorkMemoUp.Location = New System.Drawing.Point(751, 473)
        Me.cmdWorkMemoUp.Name = "cmdWorkMemoUp"
        Me.cmdWorkMemoUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdWorkMemoUp.TabIndex = 25
        Me.cmdWorkMemoUp.Text = "▲"
        '
        'cmdWorkMemoDown
        '
        Me.cmdWorkMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWorkMemoDown.Location = New System.Drawing.Point(751, 517)
        Me.cmdWorkMemoDown.Name = "cmdWorkMemoDown"
        Me.cmdWorkMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdWorkMemoDown.TabIndex = 26
        Me.cmdWorkMemoDown.Text = "▼"
        '
        'fraLotCreate
        '
        Me.fraLotCreate.Controls.Add(Me.optNew)
        Me.fraLotCreate.Controls.Add(Me.optDivide)
        Me.fraLotCreate.Location = New System.Drawing.Point(22, 56)
        Me.fraLotCreate.Name = "fraLotCreate"
        Me.fraLotCreate.Size = New System.Drawing.Size(15, 161)
        Me.fraLotCreate.TabIndex = 0
        Me.fraLotCreate.Text = "ロット作成"
        '
        'optNew
        '
        Me.optNew.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optNew.Location = New System.Drawing.Point(0, 12)
        Me.optNew.Name = "optNew"
        Me.optNew.Size = New System.Drawing.Size(19, 25)
        Me.optNew.TabIndex = 0
        '
        'optDivide
        '
        Me.optDivide.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optDivide.Location = New System.Drawing.Point(0, 108)
        Me.optDivide.Name = "optDivide"
        Me.optDivide.Size = New System.Drawing.Size(19, 25)
        Me.optDivide.TabIndex = 1
        '
        'fraCopy
        '
        Me.fraCopy.Controls.Add(Me.cmdCopyLotID)
        Me.fraCopy.Controls.Add(Me.txtCopyLotID)
        Me.fraCopy.Controls.Add(Me.lblTtl5)
        Me.fraCopy.Location = New System.Drawing.Point(446, 272)
        Me.fraCopy.Name = "fraCopy"
        Me.fraCopy.Size = New System.Drawing.Size(329, 141)
        Me.fraCopy.TabIndex = 19
        Me.fraCopy.TabStop = false
        Me.fraCopy.Text = "工順コピー"
        '
        'cmdCopyLotID
        '
        Me.cmdCopyLotID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopyLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCopyLotID.Location = New System.Drawing.Point(198, 20)
        Me.cmdCopyLotID.Name = "cmdCopyLotID"
        Me.cmdCopyLotID.Size = New System.Drawing.Size(105, 57)
        Me.cmdCopyLotID.TabIndex = 20
        Me.cmdCopyLotID.Text = "工順コピー"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ロットID"
        '
        'txtCopyLotID
        '
        Me.txtCopyLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCopyLotID.ChrMaxByte = 10
        Me.txtCopyLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCopyLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCopyLotID.Location = New System.Drawing.Point(18, 36)
        Me.txtCopyLotID.Name = "txtCopyLotID"
        Me.txtCopyLotID.NgChr = "'"
        Me.txtCopyLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCopyLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCopyLotID.SelectedText = ""
        Me.txtCopyLotID.Size = New System.Drawing.Size(161, 30)
        Me.txtCopyLotID.TabIndex = 19
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(18, 20)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(161, 17)
        Me.lblTtl5.TabIndex = 45
        Me.lblTtl5.Text = "ロットID"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdPlanList
        '
        Me.cmdPlanList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPlanList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdPlanList.Location = New System.Drawing.Point(764, 581)
        Me.cmdPlanList.Name = "cmdPlanList"
        Me.cmdPlanList.Size = New System.Drawing.Size(105, 57)
        Me.cmdPlanList.TabIndex = 23
        Me.cmdPlanList.Text = "投入予定"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"一覧"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 581)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 22
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 581)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 27
        Me.cmdClose.Text = "閉じる"
        '
        'fraNew
        '
        Me.fraNew.Controls.Add(Me.picPrClass)
        Me.fraNew.Controls.Add(Me.calStartDate)
        Me.fraNew.Controls.Add(Me.txtWFNum)
        Me.fraNew.Controls.Add(Me.cmbPd)
        Me.fraNew.Controls.Add(Me.cmbPrOrder)
        Me.fraNew.Controls.Add(Me.lblTtl11)
        Me.fraNew.Controls.Add(Me.lblTtl14)
        Me.fraNew.Controls.Add(Me.lblTtl2)
        Me.fraNew.Controls.Add(Me.lblTtl1)
        Me.fraNew.Controls.Add(Me.lblTtl0)
        Me.fraNew.Controls.Add(Me.lblTtl3)
        Me.fraNew.Controls.Add(Me.lblTtl4)
        Me.fraNew.Controls.Add(Me.cmbDivision)
        Me.fraNew.Controls.Add(Me.cmbLotManager)
        Me.fraNew.Location = New System.Drawing.Point(50, 36)
        Me.fraNew.Name = "fraNew"
        Me.fraNew.Size = New System.Drawing.Size(919, 85)
        Me.fraNew.TabIndex = 2
        Me.fraNew.TabStop = false
        Me.fraNew.Text = "新規ロットID採番"
        '
        'picPrClass
        '
        Me.picPrClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPrClass.Controls.Add(Me.fraPrClass)
        Me.picPrClass.Location = New System.Drawing.Point(626, 37)
        Me.picPrClass.Name = "picPrClass"
        Me.picPrClass.Size = New System.Drawing.Size(131, 29)
        Me.picPrClass.TabIndex = 7
        Me.picPrClass.TabStop = false
        '
        'fraPrClass
        '
        Me.fraPrClass.Controls.Add(Me.optPrClass1)
        Me.fraPrClass.Controls.Add(Me.optPrClass0)
        Me.fraPrClass.Location = New System.Drawing.Point(7, 3)
        Me.fraPrClass.Name = "fraPrClass"
        Me.fraPrClass.Size = New System.Drawing.Size(171, 30)
        Me.fraPrClass.TabIndex = 7
        '
        'optPrClass1
        '
        Me.optPrClass1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optPrClass1.Location = New System.Drawing.Point(69, 0)
        Me.optPrClass1.Name = "optPrClass1"
        Me.optPrClass1.Size = New System.Drawing.Size(39, 21)
        Me.optPrClass1.TabIndex = 8
        Me.optPrClass1.Text = "R"
        '
        'optPrClass0
        '
        Me.optPrClass0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optPrClass0.Location = New System.Drawing.Point(17, 0)
        Me.optPrClass0.Name = "optPrClass0"
        Me.optPrClass0.Size = New System.Drawing.Size(36, 21)
        Me.optPrClass0.TabIndex = 7
        Me.optPrClass0.Text = "P"
        '
        'calStartDate
        '
        Me.calStartDate.DateCheckStatus = 0
        Me.calStartDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.IsDate = true
        Me.calStartDate.Location = New System.Drawing.Point(295, 38)
        Me.calStartDate.Name = "calStartDate"
        Me.calStartDate.Size = New System.Drawing.Size(162, 28)
        Me.calStartDate.TabIndex = 5
        Me.calStartDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.Value = "____/__/__"
        '
        'txtWFNum
        '
        Me.txtWFNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWFNum.ChrMaxByte = 0
        Me.txtWFNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtWFNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWFNum.Location = New System.Drawing.Point(228, 38)
        Me.txtWFNum.Name = "txtWFNum"
        Me.txtWFNum.NgChr = "."
        Me.txtWFNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWFNum.NumMax = New Decimal(New Integer() {25, 0, 0, 0})
        Me.txtWFNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWFNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWFNum.SelectedText = ""
        Me.txtWFNum.Size = New System.Drawing.Size(68, 28)
        Me.txtWFNum.TabIndex = 4
        Me.txtWFNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbLotManager
        '
        Me.cmbLotManager.DirectInput = false
        Me.cmbLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.Location = New System.Drawing.Point(456, 37)
        Me.cmbLotManager.Name = "cmbLotManager"
        Me.cmbLotManager.Size = New System.Drawing.Size(171, 28)
        Me.cmbLotManager.TabIndex = 6
        Me.cmbLotManager.Value = Nothing
        Me.cmbLotManager.ValueCol = 1
        '
        'cmbDivision
        '
        Me.cmbDivision.DirectInput = false
        Me.cmbDivision.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivision.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivision.Location = New System.Drawing.Point(144, 37)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.Size = New System.Drawing.Size(85, 28)
        Me.cmbDivision.TabIndex = 3
        Me.cmbDivision.Value = Nothing
        '
        'cmbPd
        '
        Me.cmbPd.DirectInput = false
        Me.cmbPd.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPd.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPd.Location = New System.Drawing.Point(16, 37)
        Me.cmbPd.Name = "cmbPd"
        Me.cmbPd.Size = New System.Drawing.Size(130, 28)
        Me.cmbPd.TabIndex = 2
        Me.cmbPd.Value = Nothing
        '
        'cmbPrOrder
        '
        Me.cmbPrOrder.DirectInput = false
        Me.cmbPrOrder.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPrOrder.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPrOrder.Location = New System.Drawing.Point(756, 37)
        Me.cmbPrOrder.Name = "cmbPrOrder"
        Me.cmbPrOrder.Size = New System.Drawing.Size(151, 28)
        Me.cmbPrOrder.TabIndex = 9
        Me.cmbPrOrder.Value = Nothing
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(626, 20)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(131, 19)
        Me.lblTtl11.TabIndex = 53
        Me.lblTtl11.Text = "P/R区分"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl14
        '
        Me.lblTtl14.BackColor = System.Drawing.Color.Navy
        Me.lblTtl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl14.Location = New System.Drawing.Point(756, 20)
        Me.lblTtl14.Name = "lblTtl14"
        Me.lblTtl14.Size = New System.Drawing.Size(151, 20)
        Me.lblTtl14.TabIndex = 54
        Me.lblTtl14.Text = "P/Rオーダー"
        Me.lblTtl14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(228, 20)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(68, 19)
        Me.lblTtl2.TabIndex = 43
        Me.lblTtl2.Text = "WF枚数"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(145, 20)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(84, 18)
        Me.lblTtl1.TabIndex = 42
        Me.lblTtl1.Text = "種　別"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(16, 20)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(130, 19)
        Me.lblTtl0.TabIndex = 41
        Me.lblTtl0.Text = "機　種"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(295, 20)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(162, 19)
        Me.lblTtl3.TabIndex = 40
        Me.lblTtl3.Text = "投入予定日"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(456, 20)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(171, 18)
        Me.lblTtl4.TabIndex = 39
        Me.lblTtl4.Text = "ロット担当"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraDivide
        '
        Me.fraDivide.Controls.Add(Me.cmdDivideLotID)
        Me.fraDivide.Controls.Add(Me.txtDivideLotID)
        Me.fraDivide.Controls.Add(Me.lblTtl10)
        Me.fraDivide.Location = New System.Drawing.Point(50, 132)
        Me.fraDivide.Name = "fraDivide"
        Me.fraDivide.Size = New System.Drawing.Size(335, 92)
        Me.fraDivide.TabIndex = 10
        Me.fraDivide.TabStop = false
        Me.fraDivide.Text = "分割ロットID採番"
        '
        'cmdDivideLotID
        '
        Me.cmdDivideLotID.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDivideLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDivideLotID.Location = New System.Drawing.Point(212, 20)
        Me.cmdDivideLotID.Name = "cmdDivideLotID"
        Me.cmdDivideLotID.Size = New System.Drawing.Size(105, 57)
        Me.cmdDivideLotID.TabIndex = 11
        Me.cmdDivideLotID.Text = "分割元"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ロットID"
        '
        'txtDivideLotID
        '
        Me.txtDivideLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtDivideLotID.ChrMaxByte = 10
        Me.txtDivideLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtDivideLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtDivideLotID.Location = New System.Drawing.Point(16, 37)
        Me.txtDivideLotID.Name = "txtDivideLotID"
        Me.txtDivideLotID.NgChr = "'"
        Me.txtDivideLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtDivideLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDivideLotID.SelectedText = ""
        Me.txtDivideLotID.Size = New System.Drawing.Size(161, 30)
        Me.txtDivideLotID.TabIndex = 10
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(16, 21)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(161, 17)
        Me.lblTtl10.TabIndex = 37
        Me.lblTtl10.Text = "分割元ロットID"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraPDCreate
        '
        Me.fraPDCreate.Controls.Add(Me.optCopy)
        Me.fraPDCreate.Controls.Add(Me.optMster)
        Me.fraPDCreate.Location = New System.Drawing.Point(16, 288)
        Me.fraPDCreate.Name = "fraPDCreate"
        Me.fraPDCreate.Size = New System.Drawing.Size(765, 171)
        Me.fraPDCreate.TabIndex = 16
        Me.fraPDCreate.Text = "工順作成"
        '
        'optCopy
        '
        Me.optCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optCopy.Location = New System.Drawing.Point(408, 4)
        Me.optCopy.Name = "optCopy"
        Me.optCopy.Size = New System.Drawing.Size(21, 45)
        Me.optCopy.TabIndex = 18
        '
        'optMster
        '
        Me.optMster.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optMster.Location = New System.Drawing.Point(12, 4)
        Me.optMster.Name = "optMster"
        Me.optMster.Size = New System.Drawing.Size(21, 45)
        Me.optMster.TabIndex = 16
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 490)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
        Me.txtWorkMemo.TabIndex = 24
        '
        'txtOrderComment
        '
        Me.txtOrderComment.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtOrderComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtOrderComment.ChrMaxByte = 0
        Me.txtOrderComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtOrderComment.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtOrderComment.GotHighLight = false
        Me.txtOrderComment.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtOrderComment.Location = New System.Drawing.Point(409, 154)
        Me.txtOrderComment.MultiLineEx = true
        Me.txtOrderComment.Name = "txtOrderComment"
        Me.txtOrderComment.NgChr = "'"
        Me.txtOrderComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtOrderComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOrderComment.SelectedText = ""
        Me.txtOrderComment.Size = New System.Drawing.Size(396, 70)
        Me.txtOrderComment.TabIndex = 12
        Me.txtOrderComment.TabStop = false
        '
        'cmbLotSend
        '
        Me.cmbLotSend.DirectInput = false
        Me.cmbLotSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotSend.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotSend.Location = New System.Drawing.Point(863, 154)
        Me.cmbLotSend.Name = "cmbLotSend"
        Me.cmbLotSend.Size = New System.Drawing.Size(105, 28)
        Me.cmbLotSend.TabIndex = 15
        Me.cmbLotSend.Value = Nothing
        '
        'cmbLotThrowinNum
        '
        Me.cmbLotThrowinNum.DirectInput = false
        Me.cmbLotThrowinNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotThrowinNum.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotThrowinNum.Location = New System.Drawing.Point(816, 297)
        Me.cmbLotThrowinNum.Name = "cmbLotThrowinNum"
        Me.cmbLotThrowinNum.Size = New System.Drawing.Size(129, 28)
        Me.cmbLotThrowinNum.TabIndex = 21
        Me.cmbLotThrowinNum.Value = Nothing
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.Color.Navy
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl13.Location = New System.Drawing.Point(816, 281)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(129, 17)
        Me.lblTtl13.TabIndex = 59
        Me.lblTtl13.Text = "投入ロット数"
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(863, 138)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(105, 17)
        Me.lblTtl12.TabIndex = 58
        Me.lblTtl12.Text = "送品"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(409, 138)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(396, 17)
        Me.lblTtl7.TabIndex = 57
        Me.lblTtl7.Text = "      P/Rオーダーコメント"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(494, 475)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 46
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 474)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl15.TabIndex = 47
        Me.lblTtl15.Text = "      作業メモ"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(8, 244)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(969, 17)
        Me.lblTtl9.TabIndex = 33
        Me.lblTtl9.Text = "ロット工順情報"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(8, 8)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(969, 17)
        Me.lblTtl6.TabIndex = 32
        Me.lblTtl6.Text = "ロット作成基礎情報"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(828, 528)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(149, 30)
        Me.lblLotID.TabIndex = 30
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(828, 512)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(149, 17)
        Me.lblTtl8.TabIndex = 31
        Me.lblTtl8.Text = "ロットID"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBackGround0
        '
        Me.lblBackGround0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackGround0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBackGround0.Location = New System.Drawing.Point(8, 25)
        Me.lblBackGround0.Name = "lblBackGround0"
        Me.lblBackGround0.Size = New System.Drawing.Size(969, 209)
        Me.lblBackGround0.TabIndex = 34
        '
        'lblBackGround1
        '
        Me.lblBackGround1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackGround1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBackGround1.Location = New System.Drawing.Point(8, 261)
        Me.lblBackGround1.Name = "lblBackGround1"
        Me.lblBackGround1.Size = New System.Drawing.Size(969, 205)
        Me.lblBackGround1.TabIndex = 21
        '
        'frmxxCM00M0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdCommentDown)
        Me.Controls.Add(Me.cmdCommentUp)
        Me.Controls.Add(Me.fraMster)
        Me.Controls.Add(Me.cmdWorkMemoUp)
        Me.Controls.Add(Me.cmdWorkMemoDown)
        Me.Controls.Add(Me.fraLotCreate)
        Me.Controls.Add(Me.fraCopy)
        Me.Controls.Add(Me.cmdPlanList)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraNew)
        Me.Controls.Add(Me.fraDivide)
        Me.Controls.Add(Me.fraPDCreate)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.txtOrderComment)
        Me.Controls.Add(Me.cmbLotSend)
        Me.Controls.Add(Me.cmbLotThrowinNum)
        Me.Controls.Add(Me.lblTtl13)
        Me.Controls.Add(Me.lblTtl12)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblBackGround0)
        Me.Controls.Add(Me.lblBackGround1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00M0"
        Me.Text = "投入予定ロット登録"
        Me.fraMster.ResumeLayout(false)
        Me.fraLotCreate.ResumeLayout(false)
        Me.fraCopy.ResumeLayout(false)
        Me.fraNew.ResumeLayout(false)
        CType(Me.picPrClass,System.ComponentModel.ISupportInitialize).EndInit
        Me.picPrClass.ResumeLayout(false)
        Me.fraPrClass.ResumeLayout(false)
        Me.fraDivide.ResumeLayout(false)
        Me.fraPDCreate.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCommentDown As Button
    Friend WithEvents cmdCommentUp As Button
    Friend WithEvents fraMster As GroupBox
    Friend WithEvents cmdEntry As Button
    Friend WithEvents lblEntryID As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblEntryName As Label
    Friend WithEvents cmdWorkMemoUp As Button
    Friend WithEvents cmdWorkMemoDown As Button
    Friend WithEvents fraLotCreate As Panel
    Friend WithEvents optNew As RadioButton
    Friend WithEvents optDivide As RadioButton
    Friend WithEvents fraCopy As GroupBox
    Friend WithEvents cmdCopyLotID As Button
    Friend WithEvents txtCopyLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents cmdPlanList As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraNew As GroupBox
    Friend WithEvents picPrClass As PictureBox
    Friend WithEvents fraPrClass As Panel
    Friend WithEvents optPrClass1 As RadioButton
    Friend WithEvents optPrClass0 As RadioButton
    Friend WithEvents calStartDate As SECalendarEx.CalendarEx
    Friend WithEvents txtWFNum As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbLotManager As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbDivision As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPd As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPrOrder As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblTtl14 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents fraDivide As GroupBox
    Friend WithEvents cmdDivideLotID As Button
    Friend WithEvents txtDivideLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents fraPDCreate As Panel
    Friend WithEvents optCopy As RadioButton
    Friend WithEvents optMster As RadioButton
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents txtOrderComment As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbLotSend As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbLotThrowinNum As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblBackGround0 As Label
    Friend WithEvents lblBackGround1 As Label
End Class
