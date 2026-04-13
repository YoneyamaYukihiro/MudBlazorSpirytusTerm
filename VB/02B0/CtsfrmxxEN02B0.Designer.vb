<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02B0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02B0))
        Me.chkPlanShipDate = New System.Windows.Forms.CheckBox()
        Me.chkNextMonth = New System.Windows.Forms.CheckBox()
        Me.chkThisMonth = New System.Windows.Forms.CheckBox()
        Me.chkProcess = New System.Windows.Forms.CheckBox()
        Me.fraAfterAttributes = New System.Windows.Forms.GroupBox()
        Me.lblMemo1A0 = New System.Windows.Forms.Label()
        Me.calPlanFinishDate = New SECalendarEx.CalendarEx()
        Me.lblPlanFinishDate = New System.Windows.Forms.Label()
        Me.calPlanAssThrowDate = New SECalendarEx.CalendarEx()
        Me.calPlanShipDate = New SECalendarEx.CalendarEx()
        Me.cmbPriority = New SEComboBoxEx.ComboBoxEx()
        Me.lblSecPriority = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.lblTitle11 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.cmdSDown = New System.Windows.Forms.Button()
        Me.cmdSUp = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmbFlowClass = New SECmbIchiran.ComboIchiran()
        Me.cmbPD = New SECmbIchiran.ComboIchiran()
        Me.vsfLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.calFromDate = New SECalendarEx.CalendarEx()
        Me.calToDate = New SECalendarEx.CalendarEx()
        Me.cmbOpID = New SEComboBoxEx.ComboBoxEx()
        Me.cmbStepID = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblKara = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.optWork = New System.Windows.Forms.RadioButton()
        Me.optInventory = New System.Windows.Forms.RadioButton()
        Me.fraAfterAttributes.SuspendLayout
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'chkPlanShipDate
        '
        Me.chkPlanShipDate.Checked = true
        Me.chkPlanShipDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPlanShipDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkPlanShipDate.Location = New System.Drawing.Point(180, 70)
        Me.chkPlanShipDate.Name = "chkPlanShipDate"
        Me.chkPlanShipDate.Size = New System.Drawing.Size(89, 21)
        Me.chkPlanShipDate.TabIndex = 7
        Me.chkPlanShipDate.Text = "指定する"
        Me.chkPlanShipDate.UseCompatibleTextRendering = true
        '
        'chkNextMonth
        '
        Me.chkNextMonth.Checked = true
        Me.chkNextMonth.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNextMonth.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkNextMonth.Location = New System.Drawing.Point(84, 70)
        Me.chkNextMonth.Name = "chkNextMonth"
        Me.chkNextMonth.Size = New System.Drawing.Size(71, 21)
        Me.chkNextMonth.TabIndex = 6
        Me.chkNextMonth.Text = "次月分"
        Me.chkNextMonth.UseCompatibleTextRendering = true
        '
        'chkThisMonth
        '
        Me.chkThisMonth.Checked = true
        Me.chkThisMonth.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkThisMonth.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkThisMonth.Location = New System.Drawing.Point(8, 70)
        Me.chkThisMonth.Name = "chkThisMonth"
        Me.chkThisMonth.Size = New System.Drawing.Size(71, 21)
        Me.chkThisMonth.TabIndex = 5
        Me.chkThisMonth.Text = "当月分"
        Me.chkThisMonth.UseCompatibleTextRendering = true
        '
        'chkProcess
        '
        Me.chkProcess.Checked = true
        Me.chkProcess.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProcess.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkProcess.Location = New System.Drawing.Point(270, 26)
        Me.chkProcess.Name = "chkProcess"
        Me.chkProcess.Size = New System.Drawing.Size(89, 21)
        Me.chkProcess.TabIndex = 2
        Me.chkProcess.Text = "指定する"
        Me.chkProcess.UseCompatibleTextRendering = true
        '
        'fraAfterAttributes
        '
        Me.fraAfterAttributes.Controls.Add(Me.lblMemo1A0)
        Me.fraAfterAttributes.Controls.Add(Me.calPlanFinishDate)
        Me.fraAfterAttributes.Controls.Add(Me.lblPlanFinishDate)
        Me.fraAfterAttributes.Controls.Add(Me.calPlanAssThrowDate)
        Me.fraAfterAttributes.Controls.Add(Me.calPlanShipDate)
        Me.fraAfterAttributes.Controls.Add(Me.cmbPriority)
        Me.fraAfterAttributes.Controls.Add(Me.lblSecPriority)
        Me.fraAfterAttributes.Controls.Add(Me.lblTitle9)
        Me.fraAfterAttributes.Controls.Add(Me.lblTitle11)
        Me.fraAfterAttributes.Controls.Add(Me.lblTitle4)
        Me.fraAfterAttributes.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraAfterAttributes.Location = New System.Drawing.Point(8, 448)
        Me.fraAfterAttributes.Name = "fraAfterAttributes"
        Me.fraAfterAttributes.Size = New System.Drawing.Size(961, 66)
        Me.fraAfterAttributes.TabIndex = 12
        Me.fraAfterAttributes.TabStop = false
        Me.fraAfterAttributes.Text = "一括変更(チェックロットのみ対象)"
        '
        'lblMemo1A0
        '
        Me.lblMemo1A0.AutoSize = true
        Me.lblMemo1A0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMemo1A0.ForeColor = System.Drawing.Color.Black
        Me.lblMemo1A0.Location = New System.Drawing.Point(705, 14)
        Me.lblMemo1A0.Name = "lblMemo1A0"
        Me.lblMemo1A0.Size = New System.Drawing.Size(252, 29)
        Me.lblMemo1A0.TabIndex = 43
        Me.lblMemo1A0.Text = "※量産品は「組立投入日」に従い自動送品"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"※進捗度は「送品日」を基準に算出"
        Me.lblMemo1A0.UseCompatibleTextRendering = true
        '
        'calPlanFinishDate
        '
        Me.calPlanFinishDate.DateCheckStatus = 0
        Me.calPlanFinishDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanFinishDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanFinishDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanFinishDate.IsDate = true
        Me.calPlanFinishDate.Location = New System.Drawing.Point(498, 37)
        Me.calPlanFinishDate.Name = "calPlanFinishDate"
        Me.calPlanFinishDate.Size = New System.Drawing.Size(125, 22)
        Me.calPlanFinishDate.TabIndex = 42
        Me.calPlanFinishDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanFinishDate.Value = "____/__/__"
        '
        'lblPlanFinishDate
        '
        Me.lblPlanFinishDate.BackColor = System.Drawing.Color.Navy
        Me.lblPlanFinishDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPlanFinishDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPlanFinishDate.ForeColor = System.Drawing.Color.Yellow
        Me.lblPlanFinishDate.Location = New System.Drawing.Point(498, 20)
        Me.lblPlanFinishDate.Name = "lblPlanFinishDate"
        Me.lblPlanFinishDate.Size = New System.Drawing.Size(125, 17)
        Me.lblPlanFinishDate.TabIndex = 41
        Me.lblPlanFinishDate.Text = "完成日"
        Me.lblPlanFinishDate.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'calPlanAssThrowDate
        '
        Me.calPlanAssThrowDate.DateCheckStatus = 0
        Me.calPlanAssThrowDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanAssThrowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanAssThrowDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanAssThrowDate.IsDate = true
        Me.calPlanAssThrowDate.Location = New System.Drawing.Point(142, 37)
        Me.calPlanAssThrowDate.Name = "calPlanAssThrowDate"
        Me.calPlanAssThrowDate.Size = New System.Drawing.Size(125, 22)
        Me.calPlanAssThrowDate.TabIndex = 37
        Me.calPlanAssThrowDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanAssThrowDate.Value = "____/__/__"
        '
        'calPlanShipDate
        '
        Me.calPlanShipDate.DateCheckStatus = 0
        Me.calPlanShipDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanShipDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanShipDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanShipDate.IsDate = true
        Me.calPlanShipDate.Location = New System.Drawing.Point(6, 37)
        Me.calPlanShipDate.Name = "calPlanShipDate"
        Me.calPlanShipDate.Size = New System.Drawing.Size(125, 22)
        Me.calPlanShipDate.TabIndex = 12
        Me.calPlanShipDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPlanShipDate.Value = "____/__/__"
        '
        'cmbPriority
        '
        Me.cmbPriority.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPriority.ForeColor = System.Drawing.Color.Black
        Me.cmbPriority.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPriority.GridForeColor = System.Drawing.Color.Black
        Me.cmbPriority.Location = New System.Drawing.Point(278, 37)
        Me.cmbPriority.Name = "cmbPriority"
        Me.cmbPriority.Size = New System.Drawing.Size(126, 22)
        Me.cmbPriority.TabIndex = 39
        Me.cmbPriority.Value = Nothing
        '
        'lblSecPriority
        '
        Me.lblSecPriority.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSecPriority.ForeColor = System.Drawing.Color.Red
        Me.lblSecPriority.Location = New System.Drawing.Point(410, 21)
        Me.lblSecPriority.Name = "lblSecPriority"
        Me.lblSecPriority.Size = New System.Drawing.Size(81, 35)
        Me.lblSecPriority.TabIndex = 40
        Me.lblSecPriority.Text = "区間優先設定あり"
        Me.lblSecPriority.UseCompatibleTextRendering = true
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(278, 20)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(126, 17)
        Me.lblTitle9.TabIndex = 38
        Me.lblTitle9.Text = "優先度"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle11
        '
        Me.lblTitle11.BackColor = System.Drawing.Color.Navy
        Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle11.Location = New System.Drawing.Point(142, 20)
        Me.lblTitle11.Name = "lblTitle11"
        Me.lblTitle11.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle11.TabIndex = 36
        Me.lblTitle11.Text = "組立投入日"
        Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(6, 20)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle4.TabIndex = 29
        Me.lblTitle4.Text = "送品日"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdSDown
        '
        Me.cmdSDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSDown.Location = New System.Drawing.Point(947, 557)
        Me.cmdSDown.Name = "cmdSDown"
        Me.cmdSDown.Size = New System.Drawing.Size(25, 38)
        Me.cmdSDown.TabIndex = 15
        Me.cmdSDown.Text = "▼"
        '
        'cmdSUp
        '
        Me.cmdSUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSUp.Location = New System.Drawing.Point(947, 519)
        Me.cmdSUp.Name = "cmdSUp"
        Me.cmdSUp.Size = New System.Drawing.Size(25, 39)
        Me.cmdSUp.TabIndex = 14
        Me.cmdSUp.Text = "▲"
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(889, 599)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 16
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 599)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 17
        Me.cmdClose.Text = "閉じる"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(672, 53)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 10
        Me.cmdNowList.Text = "最新取得"
        '
        'cmbFlowClass
        '
        Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.Location = New System.Drawing.Point(133, 25)
        Me.cmbFlowClass.Name = "cmbFlowClass"
        Me.cmbFlowClass.Size = New System.Drawing.Size(125, 22)
        Me.cmbFlowClass.TabIndex = 1
        Me.cmbFlowClass.Value = Nothing
        '
        'cmbPD
        '
        Me.cmbPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridForeColor = System.Drawing.Color.Black
        Me.cmbPD.Location = New System.Drawing.Point(8, 25)
        Me.cmbPD.Name = "cmbPD"
        Me.cmbPD.Size = New System.Drawing.Size(126, 22)
        Me.cmbPD.TabIndex = 0
        Me.cmbPD.Value = Nothing
        '
        'vsfLotList
        '
        Me.vsfLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotList.AllowEditing = false
        Me.vsfLotList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotList.AutoSearchDelay = 2R
        Me.vsfLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotList.ColumnInfo = resources.GetString("vsfLotList.ColumnInfo")
        Me.vsfLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotList.ExtendLastCol = true
        Me.vsfLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotList.Location = New System.Drawing.Point(8, 97)
        Me.vsfLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotList.Name = "vsfLotList"
        Me.vsfLotList.Rows.Count = 20
        Me.vsfLotList.Rows.DefaultSize = 18
        Me.vsfLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotList.Size = New System.Drawing.Size(962, 344)
        Me.vsfLotList.StyleInfo = resources.GetString("vsfLotList.StyleInfo")
        Me.vsfLotList.TabIndex = 11
        '
        'txtComments
        '
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 2048
        Me.txtComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtComments.GotHighLight = false
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtComments.Location = New System.Drawing.Point(8, 536)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NgChr = "'"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(940, 58)
        Me.txtComments.TabIndex = 13
        '
        'calFromDate
        '
        Me.calFromDate.DateCheckStatus = 0
        Me.calFromDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.IsDate = true
        Me.calFromDate.Location = New System.Drawing.Point(269, 70)
        Me.calFromDate.Name = "calFromDate"
        Me.calFromDate.Size = New System.Drawing.Size(125, 22)
        Me.calFromDate.TabIndex = 8
        Me.calFromDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.Value = "____/__/__"
        '
        'calToDate
        '
        Me.calToDate.DateCheckStatus = 0
        Me.calToDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.IsDate = true
        Me.calToDate.Location = New System.Drawing.Point(433, 70)
        Me.calToDate.Name = "calToDate"
        Me.calToDate.Size = New System.Drawing.Size(125, 22)
        Me.calToDate.TabIndex = 9
        Me.calToDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.Value = "____/__/__"
        '
        'cmbOpID
        '
        Me.cmbOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOpID.ForeColor = System.Drawing.Color.Black
        Me.cmbOpID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOpID.GridForeColor = System.Drawing.Color.Black
        Me.cmbOpID.Location = New System.Drawing.Point(360, 25)
        Me.cmbOpID.Name = "cmbOpID"
        Me.cmbOpID.Size = New System.Drawing.Size(198, 22)
        Me.cmbOpID.TabIndex = 3
        Me.cmbOpID.Value = Nothing
        '
        'cmbStepID
        '
        Me.cmbStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStepID.ForeColor = System.Drawing.Color.Black
        Me.cmbStepID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStepID.GridForeColor = System.Drawing.Color.Black
        Me.cmbStepID.Location = New System.Drawing.Point(558, 25)
        Me.cmbStepID.Name = "cmbStepID"
        Me.cmbStepID.Size = New System.Drawing.Size(198, 22)
        Me.cmbStepID.TabIndex = 4
        Me.cmbStepID.Value = Nothing
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(887, 71)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(82, 19)
        Me.lblTitleHT.TabIndex = 35
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblKara
        '
        Me.lblKara.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblKara.Location = New System.Drawing.Point(398, 70)
        Me.lblKara.Name = "lblKara"
        Me.lblKara.Size = New System.Drawing.Size(33, 21)
        Me.lblKara.TabIndex = 34
        Me.lblKara.Text = "～"
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(557, 8)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(199, 17)
        Me.lblTitle8.TabIndex = 33
        Me.lblTitle8.Text = "小工程"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(270, 8)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(287, 17)
        Me.lblTitle7.TabIndex = 32
        Me.lblTitle7.Text = "大工程"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(8, 53)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(550, 17)
        Me.lblTitle1.TabIndex = 31
        Me.lblTitle1.Text = "送品日"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleChip
        '
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(776, 53)
        Me.lblTitleChip.Name = "lblTitleChip"
        Me.lblTitleChip.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleChip.TabIndex = 30
        Me.lblTitleChip.Text = "青字：Chip品"
        Me.lblTitleChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleChip.UseMnemonic = false
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(691, 521)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(247, 17)
        Me.lblLengthCount.TabIndex = 27
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(8, 520)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(940, 17)
        Me.lblTitle3.TabIndex = 26
        Me.lblTitle3.Text = "作業メモ"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(897, 8)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle2.TabIndex = 25
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(897, 24)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(73, 22)
        Me.lblLotCnt.TabIndex = 24
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(772, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle0.TabIndex = 23
        Me.lblTitle0.Text = "情報取得日時"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(772, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(121, 22)
        Me.lblNowDate.TabIndex = 22
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(928, 53)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(41, 19)
        Me.lblTitleR.TabIndex = 21
        Me.lblTitleR.Text = "R"
        Me.lblTitleR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleR.UseMnemonic = false
        '
        'lblTitleL
        '
        Me.lblTitleL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleL.ForeColor = System.Drawing.Color.Black
        Me.lblTitleL.Location = New System.Drawing.Point(887, 53)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(45, 19)
        Me.lblTitleL.TabIndex = 20
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(133, 8)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle6.TabIndex = 19
        Me.lblTitle6.Text = "種別"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle5.TabIndex = 18
        Me.lblTitle5.Text = "機種"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'optWork
        '
        Me.optWork.AutoSize = true
        Me.optWork.Location = New System.Drawing.Point(565, 55)
        Me.optWork.Name = "optWork"
        Me.optWork.Size = New System.Drawing.Size(59, 16)
        Me.optWork.TabIndex = 36
        Me.optWork.TabStop = true
        Me.optWork.Text = "流動中"
        Me.optWork.UseVisualStyleBackColor = true
        '
        'optInventory
        '
        Me.optInventory.AutoSize = true
        Me.optInventory.Location = New System.Drawing.Point(565, 73)
        Me.optInventory.Name = "optInventory"
        Me.optInventory.Size = New System.Drawing.Size(101, 16)
        Me.optInventory.TabIndex = 37
        Me.optInventory.TabStop = true
        Me.optInventory.Text = "完成(送品待ち)"
        Me.optInventory.UseVisualStyleBackColor = true
        '
        'frmxxEN02B0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.optInventory)
        Me.Controls.Add(Me.optWork)
        Me.Controls.Add(Me.chkPlanShipDate)
        Me.Controls.Add(Me.chkNextMonth)
        Me.Controls.Add(Me.chkThisMonth)
        Me.Controls.Add(Me.chkProcess)
        Me.Controls.Add(Me.fraAfterAttributes)
        Me.Controls.Add(Me.cmdSDown)
        Me.Controls.Add(Me.cmdSUp)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmbFlowClass)
        Me.Controls.Add(Me.cmbPD)
        Me.Controls.Add(Me.vsfLotList)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.calFromDate)
        Me.Controls.Add(Me.calToDate)
        Me.Controls.Add(Me.cmbOpID)
        Me.Controls.Add(Me.cmbStepID)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Controls.Add(Me.lblKara)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitleChip)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitleR)
        Me.Controls.Add(Me.lblTitleL)
        Me.Controls.Add(Me.lblTitle6)
        Me.Controls.Add(Me.lblTitle5)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02B0"
        Me.Text = "ロット情報一括変更"
        Me.fraAfterAttributes.ResumeLayout(false)
        Me.fraAfterAttributes.PerformLayout
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents chkPlanShipDate As CheckBox
    Friend WithEvents chkNextMonth As CheckBox
    Friend WithEvents chkThisMonth As CheckBox
    Friend WithEvents chkProcess As CheckBox
    Friend WithEvents fraAfterAttributes As GroupBox
    Friend WithEvents calPlanAssThrowDate As SECalendarEx.CalendarEx
    Friend WithEvents calPlanShipDate As SECalendarEx.CalendarEx
    Friend WithEvents cmbPriority As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblSecPriority As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents cmdSDown As Button
    Friend WithEvents cmdSUp As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmbFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbPD As SECmbIchiran.ComboIchiran
    Friend WithEvents vsfLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents calFromDate As SECalendarEx.CalendarEx
    Friend WithEvents calToDate As SECalendarEx.CalendarEx
    Friend WithEvents cmbOpID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbStepID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblKara As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents optWork As RadioButton
    Friend WithEvents optInventory As RadioButton
    Friend WithEvents calPlanFinishDate As SECalendarEx.CalendarEx
    Friend WithEvents lblPlanFinishDate As Label
    Friend WithEvents lblMemo1A0 As Label
End Class
