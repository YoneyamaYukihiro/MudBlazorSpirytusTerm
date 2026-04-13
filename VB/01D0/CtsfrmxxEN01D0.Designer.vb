<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01D0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01D0))
        Me.chkDateSelectKbn = New System.Windows.Forms.CheckBox()
        Me.cmdGuidList = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdMessegeUp = New System.Windows.Forms.Button()
        Me.cmdMessegeDown = New System.Windows.Forms.Button()
        Me.txtMessege = New SETextBoxEx.TextBoxEx()
        Me.calFromDate = New SECalendarEx.CalendarEx()
        Me.calToDate = New SECalendarEx.CalendarEx()
        Me.cmbGuidLevel = New SECmbIchiran.ComboIchiran()
        Me.vsfGuidList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.medFromTime = New System.Windows.Forms.MaskedTextBox()
        Me.medToTime = New System.Windows.Forms.MaskedTextBox()
        Me.cmbMcGroupName = New SECmbIchiran.ComboIchiran()
        Me.cmbWpName = New SECmbIchiran.ComboIchiran()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblGaidanceCnt = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblKara = New System.Windows.Forms.Label()
        Me.lblWpStatusName = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        CType(Me.vsfGuidList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'chkDateSelectKbn
        '
        Me.chkDateSelectKbn.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkDateSelectKbn.Location = New System.Drawing.Point(246, 69)
        Me.chkDateSelectKbn.Name = "chkDateSelectKbn"
        Me.chkDateSelectKbn.Size = New System.Drawing.Size(90, 22)
        Me.chkDateSelectKbn.TabIndex = 3
        Me.chkDateSelectKbn.Text = "指定する"
        '
        'cmdGuidList
        '
        Me.cmdGuidList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdGuidList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdGuidList.Location = New System.Drawing.Point(735, 6)
        Me.cmdGuidList.Name = "cmdGuidList"
        Me.cmdGuidList.Size = New System.Drawing.Size(105, 57)
        Me.cmdGuidList.TabIndex = 8
        Me.cmdGuidList.Text = "最新取得"
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
        Me.cmdClose.TabIndex = 13
        Me.cmdClose.Text = "閉じる"
        '
        'cmdMessegeUp
        '
        Me.cmdMessegeUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMessegeUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMessegeUp.Location = New System.Drawing.Point(751, 491)
        Me.cmdMessegeUp.Name = "cmdMessegeUp"
        Me.cmdMessegeUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdMessegeUp.TabIndex = 11
        Me.cmdMessegeUp.Text = "▲"
        '
        'cmdMessegeDown
        '
        Me.cmdMessegeDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMessegeDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMessegeDown.Location = New System.Drawing.Point(751, 535)
        Me.cmdMessegeDown.Name = "cmdMessegeDown"
        Me.cmdMessegeDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMessegeDown.TabIndex = 12
        Me.cmdMessegeDown.Text = "▼"
        '
        'txtMessege
        '
        Me.txtMessege.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtMessege.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtMessege.ChrMaxByte = 0
        Me.txtMessege.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtMessege.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtMessege.GotHighLight = false
        Me.txtMessege.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMessege.Location = New System.Drawing.Point(8, 508)
        Me.txtMessege.MultiLineEx = true
        Me.txtMessege.Name = "txtMessege"
        Me.txtMessege.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtMessege.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMessege.SelectedText = ""
        Me.txtMessege.Size = New System.Drawing.Size(743, 69)
        Me.txtMessege.TabIndex = 10
        Me.txtMessege.TabStop = false
        '
        'calFromDate
        '
        Me.calFromDate.DateCheckStatus = 0
        Me.calFromDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.Enabled = false
        Me.calFromDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.IsDate = true
        Me.calFromDate.Location = New System.Drawing.Point(341, 68)
        Me.calFromDate.Name = "calFromDate"
        Me.calFromDate.Size = New System.Drawing.Size(113, 22)
        Me.calFromDate.TabIndex = 4
        Me.calFromDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.Value = "____/__/__"
        '
        'calToDate
        '
        Me.calToDate.DateCheckStatus = 0
        Me.calToDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.Enabled = false
        Me.calToDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.IsDate = true
        Me.calToDate.Location = New System.Drawing.Point(543, 68)
        Me.calToDate.Name = "calToDate"
        Me.calToDate.Size = New System.Drawing.Size(113, 22)
        Me.calToDate.TabIndex = 6
        Me.calToDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.Value = "____/__/__"
        '
        'cmbGuidLevel
        '
        Me.cmbGuidLevel.AddedComment = "　項目選択"
        Me.cmbGuidLevel.AllSelectButton = true
        Me.cmbGuidLevel.DirectInput = false
        Me.cmbGuidLevel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbGuidLevel.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbGuidLevel.GridForeColor = System.Drawing.Color.Black
        Me.cmbGuidLevel.ListIndex = 0
        Me.cmbGuidLevel.Location = New System.Drawing.Point(9, 67)
        Me.cmbGuidLevel.Name = "cmbGuidLevel"
        Me.cmbGuidLevel.SelectMode = 1
        Me.cmbGuidLevel.Size = New System.Drawing.Size(213, 22)
        Me.cmbGuidLevel.TabIndex = 2
        Me.cmbGuidLevel.Value = ""
        Me.cmbGuidLevel.ValueCol = 1
        '
        'vsfGuidList
        '
        Me.vsfGuidList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfGuidList.AllowEditing = false
        Me.vsfGuidList.AutoResize = true
        Me.vsfGuidList.AutoSearchDelay = 2R
        Me.vsfGuidList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfGuidList.ColumnInfo = resources.GetString("vsfGuidList.ColumnInfo")
        Me.vsfGuidList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfGuidList.ExtendLastCol = true
        Me.vsfGuidList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfGuidList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfGuidList.Location = New System.Drawing.Point(9, 99)
        Me.vsfGuidList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfGuidList.Name = "vsfGuidList"
        Me.vsfGuidList.Rows.Count = 21
        Me.vsfGuidList.Rows.DefaultSize = 18
        Me.vsfGuidList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfGuidList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfGuidList.Size = New System.Drawing.Size(964, 382)
        Me.vsfGuidList.StyleInfo = resources.GetString("vsfGuidList.StyleInfo")
        Me.vsfGuidList.TabIndex = 9
        '
        'medFromTime
        '
        Me.medFromTime.Enabled = false
        Me.medFromTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medFromTime.Location = New System.Drawing.Point(459, 68)
        Me.medFromTime.Mask = "00:00"
        Me.medFromTime.Name = "medFromTime"
        Me.medFromTime.ResetOnSpace = false
        Me.medFromTime.Size = New System.Drawing.Size(51, 22)
        Me.medFromTime.TabIndex = 5
        Me.medFromTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'medToTime
        '
        Me.medToTime.Enabled = false
        Me.medToTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medToTime.Location = New System.Drawing.Point(660, 68)
        Me.medToTime.Mask = "00:00"
        Me.medToTime.Name = "medToTime"
        Me.medToTime.ResetOnSpace = false
        Me.medToTime.Size = New System.Drawing.Size(51, 22)
        Me.medToTime.TabIndex = 7
        Me.medToTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'cmbMcGroupName
        '
        Me.cmbMcGroupName.DirectInput = false
        Me.cmbMcGroupName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.Location = New System.Drawing.Point(8, 22)
        Me.cmbMcGroupName.Name = "cmbMcGroupName"
        Me.cmbMcGroupName.Size = New System.Drawing.Size(267, 22)
        Me.cmbMcGroupName.TabIndex = 0
        Me.cmbMcGroupName.Value = Nothing
        Me.cmbMcGroupName.ValueCol = 1
        '
        'cmbWpName
        '
        Me.cmbWpName.DirectInput = false
        Me.cmbWpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpName.Location = New System.Drawing.Point(275, 22)
        Me.cmbWpName.Name = "cmbWpName"
        Me.cmbWpName.Size = New System.Drawing.Size(267, 22)
        Me.cmbWpName.TabIndex = 1
        Me.cmbWpName.Value = Nothing
        Me.cmbWpName.ValueCol = 1
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(244, 51)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(467, 17)
        Me.lblTtl5.TabIndex = 17
        Me.lblTtl5.Text = "期間"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGaidanceCnt
        '
        Me.lblGaidanceCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGaidanceCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGaidanceCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGaidanceCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGaidanceCnt.Location = New System.Drawing.Point(900, 67)
        Me.lblGaidanceCnt.Name = "lblGaidanceCnt"
        Me.lblGaidanceCnt.Size = New System.Drawing.Size(73, 21)
        Me.lblGaidanceCnt.TabIndex = 25
        Me.lblGaidanceCnt.Text = "0"
        Me.lblGaidanceCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(900, 51)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle6.TabIndex = 24
        Me.lblTitle6.Text = "表示件数"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(851, 6)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle7.TabIndex = 23
        Me.lblTitle7.Text = "情報取得日時"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(851, 22)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 22
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblKara
        '
        Me.lblKara.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblKara.Location = New System.Drawing.Point(511, 68)
        Me.lblKara.Name = "lblKara"
        Me.lblKara.Size = New System.Drawing.Size(33, 21)
        Me.lblKara.TabIndex = 18
        Me.lblKara.Text = "～"
        '
        'lblWpStatusName
        '
        Me.lblWpStatusName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWpStatusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpStatusName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpStatusName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWpStatusName.Location = New System.Drawing.Point(542, 22)
        Me.lblWpStatusName.Name = "lblWpStatusName"
        Me.lblWpStatusName.Size = New System.Drawing.Size(169, 21)
        Me.lblWpStatusName.TabIndex = 21
        Me.lblWpStatusName.Text = "正常"
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(542, 6)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(169, 17)
        Me.lblTitle5.TabIndex = 20
        Me.lblTitle5.Text = "処理状態"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(9, 51)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(213, 17)
        Me.lblTitle3.TabIndex = 19
        Me.lblTitle3.Text = "ガイダンスレベル"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 492)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl15.TabIndex = 16
        Me.lblTtl15.Text = "      メッセージ"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(275, 6)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(267, 17)
        Me.lblTitle1.TabIndex = 15
        Me.lblTitle1.Text = "装置名"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 6)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(267, 17)
        Me.lblTitle0.TabIndex = 14
        Me.lblTitle0.Text = "装置グループ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01D0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.chkDateSelectKbn)
        Me.Controls.Add(Me.cmdGuidList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdMessegeUp)
        Me.Controls.Add(Me.cmdMessegeDown)
        Me.Controls.Add(Me.txtMessege)
        Me.Controls.Add(Me.calFromDate)
        Me.Controls.Add(Me.calToDate)
        Me.Controls.Add(Me.cmbGuidLevel)
        Me.Controls.Add(Me.vsfGuidList)
        Me.Controls.Add(Me.medFromTime)
        Me.Controls.Add(Me.medToTime)
        Me.Controls.Add(Me.cmbMcGroupName)
        Me.Controls.Add(Me.cmbWpName)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblGaidanceCnt)
        Me.Controls.Add(Me.lblTitle6)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblKara)
        Me.Controls.Add(Me.lblWpStatusName)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01D0"
        Me.Text = "SPIRYTUSガイダンス"
        CType(Me.vsfGuidList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents chkDateSelectKbn As CheckBox
    Friend WithEvents cmdGuidList As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdMessegeUp As Button
    Friend WithEvents cmdMessegeDown As Button
    Friend WithEvents txtMessege As SETextBoxEx.TextBoxEx
    Friend WithEvents calFromDate As SECalendarEx.CalendarEx
    Friend WithEvents calToDate As SECalendarEx.CalendarEx
    Friend WithEvents cmbGuidLevel As SECmbIchiran.ComboIchiran
    Friend WithEvents vsfGuidList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents medFromTime As MaskedTextBox
    Friend WithEvents medToTime As MaskedTextBox
    Friend WithEvents cmbMcGroupName As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbWpName As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblGaidanceCnt As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblKara As Label
    Friend WithEvents lblWpStatusName As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
End Class
