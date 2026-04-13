<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00O0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00O0))
        Me.fraNew = New System.Windows.Forms.GroupBox()
        Me.calStartDate = New SECalendarEx.CalendarEx()
        Me.txtWFNum = New SETextBoxEx.TextBoxEx()
        Me.cmbDivision = New SEComboBoxEx.ComboBoxEx()
        Me.cmbPD = New SEComboBoxEx.ComboBoxEx()
        Me.cmbLotManager = New SEComboBoxEx.ComboBoxEx()
        Me.cmbGroup = New SEComboBoxEx.ComboBoxEx()
        Me.cmbLotSend = New SEComboBoxEx.ComboBoxEx()
        Me.lblLotSend = New System.Windows.Forms.Label()
        Me.lblLotManagerTitle = New System.Windows.Forms.Label()
        Me.lblGroupTitle = New System.Windows.Forms.Label()
        Me.lblStartDateTitle = New System.Windows.Forms.Label()
        Me.lblPdTitle = New System.Windows.Forms.Label()
        Me.lblDivisionTitle = New System.Windows.Forms.Label()
        Me.lblWFNumTitle = New System.Windows.Forms.Label()
        Me.fraMster = New System.Windows.Forms.GroupBox()
        Me.cmdEntry = New System.Windows.Forms.Button()
        Me.lblEntryName = New System.Windows.Forms.Label()
        Me.lblEntryNameTitle = New System.Windows.Forms.Label()
        Me.lblEntryIDTitle = New System.Windows.Forms.Label()
        Me.lblEntryID = New System.Windows.Forms.Label()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdPlanList = New System.Windows.Forms.Button()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.lblBackGround = New System.Windows.Forms.Label()
        Me.lblNewTitle = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblLotIDTitle = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblWorkMemoTitle = New System.Windows.Forms.Label()
        Me.fraNew.SuspendLayout
        Me.fraMster.SuspendLayout
        Me.SuspendLayout
        '
        'fraNew
        '
        Me.fraNew.Controls.Add(Me.calStartDate)
        Me.fraNew.Controls.Add(Me.txtWFNum)
        Me.fraNew.Controls.Add(Me.cmbDivision)
        Me.fraNew.Controls.Add(Me.cmbPD)
        Me.fraNew.Controls.Add(Me.cmbLotManager)
        Me.fraNew.Controls.Add(Me.cmbGroup)
        Me.fraNew.Controls.Add(Me.cmbLotSend)
        Me.fraNew.Controls.Add(Me.lblLotSend)
        Me.fraNew.Controls.Add(Me.lblLotManagerTitle)
        Me.fraNew.Controls.Add(Me.lblGroupTitle)
        Me.fraNew.Controls.Add(Me.lblStartDateTitle)
        Me.fraNew.Controls.Add(Me.lblPdTitle)
        Me.fraNew.Controls.Add(Me.lblDivisionTitle)
        Me.fraNew.Controls.Add(Me.lblWFNumTitle)
        Me.fraNew.Location = New System.Drawing.Point(24, 39)
        Me.fraNew.Name = "fraNew"
        Me.fraNew.Size = New System.Drawing.Size(946, 85)
        Me.fraNew.TabIndex = 16
        Me.fraNew.TabStop = false
        Me.fraNew.Text = "新規ロットID採番"
        '
        'calStartDate
        '
        Me.calStartDate.DateCheckStatus = 0
        Me.calStartDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.IsDate = true
        Me.calStartDate.Location = New System.Drawing.Point(340, 36)
        Me.calStartDate.Name = "calStartDate"
        Me.calStartDate.Size = New System.Drawing.Size(163, 28)
        Me.calStartDate.TabIndex = 3
        Me.calStartDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.Value = "____/__/__"
        '
        'txtWFNum
        '
        Me.txtWFNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWFNum.ChrMaxByte = 2
        Me.txtWFNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtWFNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWFNum.Location = New System.Drawing.Point(275, 36)
        Me.txtWFNum.Name = "txtWFNum"
        Me.txtWFNum.NgChr = "."
        Me.txtWFNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWFNum.NumMax = New Decimal(New Integer() {25, 0, 0, 0})
        Me.txtWFNum.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWFNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWFNum.SelectedText = ""
        Me.txtWFNum.Size = New System.Drawing.Size(66, 28)
        Me.txtWFNum.TabIndex = 2
        Me.txtWFNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbDivision
        '
        Me.cmbDivision.DirectInput = false
        Me.cmbDivision.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivision.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivision.Location = New System.Drawing.Point(145, 36)
        Me.cmbDivision.Name = "cmbDivision"
        Me.cmbDivision.RowHeight = 43
        Me.cmbDivision.Size = New System.Drawing.Size(131, 28)
        Me.cmbDivision.TabIndex = 1
        Me.cmbDivision.Value = Nothing
        '
        'cmbPD
        '
        Me.cmbPD.DirectInput = false
        Me.cmbPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.Location = New System.Drawing.Point(16, 36)
        Me.cmbPD.Name = "cmbPD"
        Me.cmbPD.RowHeight = 43
        Me.cmbPD.Size = New System.Drawing.Size(130, 28)
        Me.cmbPD.TabIndex = 0
        Me.cmbPD.Value = Nothing
        '
        'cmbLotManager
        '
        Me.cmbLotManager.DirectInput = false
        Me.cmbLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.Location = New System.Drawing.Point(588, 36)
        Me.cmbLotManager.Name = "cmbLotManager"
        Me.cmbLotManager.RowHeight = 43
        Me.cmbLotManager.Size = New System.Drawing.Size(169, 28)
        Me.cmbLotManager.TabIndex = 5
        Me.cmbLotManager.Value = Nothing
        Me.cmbLotManager.ValueCol = 1
        '
        'cmbGroup
        '
        Me.cmbGroup.DirectInput = false
        Me.cmbGroup.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbGroup.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbGroup.Location = New System.Drawing.Point(502, 36)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.RowHeight = 43
        Me.cmbGroup.Size = New System.Drawing.Size(87, 28)
        Me.cmbGroup.TabIndex = 4
        Me.cmbGroup.Value = Nothing
        Me.cmbGroup.ValueCol = 1
        '
        'cmbLotSend
        '
        Me.cmbLotSend.DirectInput = false
        Me.cmbLotSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotSend.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotSend.Location = New System.Drawing.Point(756, 36)
        Me.cmbLotSend.Name = "cmbLotSend"
        Me.cmbLotSend.RowHeight = 43
        Me.cmbLotSend.Size = New System.Drawing.Size(106, 28)
        Me.cmbLotSend.TabIndex = 6
        Me.cmbLotSend.Value = Nothing
        '
        'lblLotSend
        '
        Me.lblLotSend.BackColor = System.Drawing.Color.Navy
        Me.lblLotSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotSend.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotSend.Location = New System.Drawing.Point(756, 20)
        Me.lblLotSend.Name = "lblLotSend"
        Me.lblLotSend.Size = New System.Drawing.Size(106, 17)
        Me.lblLotSend.TabIndex = 23
        Me.lblLotSend.Text = "送品"
        Me.lblLotSend.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotManagerTitle
        '
        Me.lblLotManagerTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotManagerTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManagerTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManagerTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotManagerTitle.Location = New System.Drawing.Point(588, 20)
        Me.lblLotManagerTitle.Name = "lblLotManagerTitle"
        Me.lblLotManagerTitle.Size = New System.Drawing.Size(169, 17)
        Me.lblLotManagerTitle.TabIndex = 22
        Me.lblLotManagerTitle.Text = "ロット担当"
        Me.lblLotManagerTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGroupTitle
        '
        Me.lblGroupTitle.BackColor = System.Drawing.Color.Navy
        Me.lblGroupTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGroupTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGroupTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblGroupTitle.Location = New System.Drawing.Point(502, 20)
        Me.lblGroupTitle.Name = "lblGroupTitle"
        Me.lblGroupTitle.Size = New System.Drawing.Size(87, 17)
        Me.lblGroupTitle.TabIndex = 21
        Me.lblGroupTitle.Text = "部門"
        Me.lblGroupTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStartDateTitle
        '
        Me.lblStartDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblStartDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblStartDateTitle.Location = New System.Drawing.Point(340, 20)
        Me.lblStartDateTitle.Name = "lblStartDateTitle"
        Me.lblStartDateTitle.Size = New System.Drawing.Size(163, 17)
        Me.lblStartDateTitle.TabIndex = 20
        Me.lblStartDateTitle.Text = "投入予定日"
        Me.lblStartDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdTitle
        '
        Me.lblPdTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPdTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPdTitle.Location = New System.Drawing.Point(16, 20)
        Me.lblPdTitle.Name = "lblPdTitle"
        Me.lblPdTitle.Size = New System.Drawing.Size(130, 17)
        Me.lblPdTitle.TabIndex = 17
        Me.lblPdTitle.Text = "機　種"
        Me.lblPdTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDivisionTitle
        '
        Me.lblDivisionTitle.BackColor = System.Drawing.Color.Navy
        Me.lblDivisionTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDivisionTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDivisionTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblDivisionTitle.Location = New System.Drawing.Point(145, 20)
        Me.lblDivisionTitle.Name = "lblDivisionTitle"
        Me.lblDivisionTitle.Size = New System.Drawing.Size(131, 17)
        Me.lblDivisionTitle.TabIndex = 18
        Me.lblDivisionTitle.Text = "種　別"
        Me.lblDivisionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNumTitle
        '
        Me.lblWFNumTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWFNumTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNumTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNumTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWFNumTitle.Location = New System.Drawing.Point(275, 20)
        Me.lblWFNumTitle.Name = "lblWFNumTitle"
        Me.lblWFNumTitle.Size = New System.Drawing.Size(66, 17)
        Me.lblWFNumTitle.TabIndex = 19
        Me.lblWFNumTitle.Text = "数量"
        Me.lblWFNumTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraMster
        '
        Me.fraMster.Controls.Add(Me.cmdEntry)
        Me.fraMster.Controls.Add(Me.lblEntryName)
        Me.fraMster.Controls.Add(Me.lblEntryNameTitle)
        Me.fraMster.Controls.Add(Me.lblEntryIDTitle)
        Me.fraMster.Controls.Add(Me.lblEntryID)
        Me.fraMster.Location = New System.Drawing.Point(24, 135)
        Me.fraMster.Name = "fraMster"
        Me.fraMster.Size = New System.Drawing.Size(335, 145)
        Me.fraMster.TabIndex = 24
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
        Me.cmdEntry.TabIndex = 7
        Me.cmdEntry.Text = "エントリ"
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
        Me.lblEntryName.TabIndex = 28
        Me.lblEntryName.Text = "あいうえおあいうえおあいうえお"
        '
        'lblEntryNameTitle
        '
        Me.lblEntryNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEntryNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEntryNameTitle.Location = New System.Drawing.Point(16, 84)
        Me.lblEntryNameTitle.Name = "lblEntryNameTitle"
        Me.lblEntryNameTitle.Size = New System.Drawing.Size(301, 17)
        Me.lblEntryNameTitle.TabIndex = 27
        Me.lblEntryNameTitle.Text = "エントリ名"
        Me.lblEntryNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEntryIDTitle
        '
        Me.lblEntryIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEntryIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEntryIDTitle.Location = New System.Drawing.Point(16, 20)
        Me.lblEntryIDTitle.Name = "lblEntryIDTitle"
        Me.lblEntryIDTitle.Size = New System.Drawing.Size(177, 17)
        Me.lblEntryIDTitle.TabIndex = 25
        Me.lblEntryIDTitle.Text = "エントリ"
        Me.lblEntryIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblEntryID.TabIndex = 26
        Me.lblEntryID.Text = "0123456789012"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.Enabled = false
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(927, 432)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 12
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.Enabled = false
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(927, 387)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoUp.TabIndex = 11
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 574)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 13
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 574)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 8
        Me.cmdRegist.Text = "確　定"
        '
        'cmdPlanList
        '
        Me.cmdPlanList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPlanList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdPlanList.Location = New System.Drawing.Point(764, 574)
        Me.cmdPlanList.Name = "cmdPlanList"
        Me.cmdPlanList.Size = New System.Drawing.Size(105, 57)
        Me.cmdPlanList.TabIndex = 9
        Me.cmdPlanList.Text = "投入予定"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"一覧"
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 405)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(920, 69)
        Me.txtWorkMemo.TabIndex = 10
        '
        'lblBackGround
        '
        Me.lblBackGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackGround.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBackGround.Location = New System.Drawing.Point(8, 24)
        Me.lblBackGround.Name = "lblBackGround"
        Me.lblBackGround.Size = New System.Drawing.Size(969, 271)
        Me.lblBackGround.TabIndex = 14
        '
        'lblNewTitle
        '
        Me.lblNewTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNewTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNewTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNewTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNewTitle.Location = New System.Drawing.Point(8, 8)
        Me.lblNewTitle.Name = "lblNewTitle"
        Me.lblNewTitle.Size = New System.Drawing.Size(969, 17)
        Me.lblNewTitle.TabIndex = 15
        Me.lblNewTitle.Text = "品確、モニター・ダミー　ロット作成基礎情報"
        Me.lblNewTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(524, 389)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 16)
        Me.lblLengthCount.TabIndex = 30
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLotIDTitle
        '
        Me.lblLotIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotIDTitle.Location = New System.Drawing.Point(828, 486)
        Me.lblLotIDTitle.Name = "lblLotIDTitle"
        Me.lblLotIDTitle.Size = New System.Drawing.Size(149, 17)
        Me.lblLotIDTitle.TabIndex = 31
        Me.lblLotIDTitle.Text = "ロットID"
        Me.lblLotIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.Location = New System.Drawing.Point(828, 502)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(149, 30)
        Me.lblLotID.TabIndex = 32
        Me.lblLotID.Text = "GTA0123-00"
        '
        'lblWorkMemoTitle
        '
        Me.lblWorkMemoTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWorkMemoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWorkMemoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWorkMemoTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWorkMemoTitle.Location = New System.Drawing.Point(8, 388)
        Me.lblWorkMemoTitle.Name = "lblWorkMemoTitle"
        Me.lblWorkMemoTitle.Size = New System.Drawing.Size(920, 18)
        Me.lblWorkMemoTitle.TabIndex = 29
        Me.lblWorkMemoTitle.Text = "      作業メモ"
        Me.lblWorkMemoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00O0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.fraNew)
        Me.Controls.Add(Me.fraMster)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdPlanList)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.lblBackGround)
        Me.Controls.Add(Me.lblNewTitle)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblLotIDTitle)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblWorkMemoTitle)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00O0"
        Me.Text = "投入予定登録（品確、モニター・ダミー）"
        Me.fraNew.ResumeLayout(false)
        Me.fraMster.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraNew As GroupBox
    Friend WithEvents calStartDate As SECalendarEx.CalendarEx
    Friend WithEvents txtWFNum As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbDivision As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPD As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbLotManager As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbGroup As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbLotSend As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblLotSend As Label
    Friend WithEvents lblLotManagerTitle As Label
    Friend WithEvents lblGroupTitle As Label
    Friend WithEvents lblStartDateTitle As Label
    Friend WithEvents lblPdTitle As Label
    Friend WithEvents lblDivisionTitle As Label
    Friend WithEvents lblWFNumTitle As Label
    Friend WithEvents fraMster As GroupBox
    Friend WithEvents cmdEntry As Button
    Friend WithEvents lblEntryName As Label
    Friend WithEvents lblEntryNameTitle As Label
    Friend WithEvents lblEntryIDTitle As Label
    Friend WithEvents lblEntryID As Label
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdPlanList As Button
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents lblBackGround As Label
    Friend WithEvents lblNewTitle As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblLotIDTitle As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblWorkMemoTitle As Label
End Class
