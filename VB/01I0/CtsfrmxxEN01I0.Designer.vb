<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01I0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01I0))
        Me.txtProLotID = New SETextBoxEx.TextBoxEx()
        Me.cmdWorkMemo = New System.Windows.Forms.Button()
        Me.chkDateSelectKbn = New System.Windows.Forms.CheckBox()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbPart = New SEComboBoxEx.ComboBoxEx()
        Me.cmbPartClass = New SEComboBoxEx.ComboBoxEx()
        Me.calFromDate = New SECalendarEx.CalendarEx()
        Me.calToDate = New SECalendarEx.CalendarEx()
        Me.medFromTime = New System.Windows.Forms.MaskedTextBox()
        Me.medToTime = New System.Windows.Forms.MaskedTextBox()
        Me.vsfStockList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblNowTotal = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblKara = New System.Windows.Forms.Label()
        CType(Me.vsfStockList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'txtProLotID
        '
        Me.txtProLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtProLotID.ChrMaxByte = 12
        Me.txtProLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtProLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
        Me.txtProLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtProLotID.Location = New System.Drawing.Point(108, 68)
        Me.txtProLotID.Name = "txtProLotID"
        Me.txtProLotID.NgChr = "'"
        Me.txtProLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtProLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtProLotID.SelectedText = ""
        Me.txtProLotID.Size = New System.Drawing.Size(176, 22)
        Me.txtProLotID.TabIndex = 3
        '
        'cmdWorkMemo
        '
        Me.cmdWorkMemo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkMemo.Location = New System.Drawing.Point(792, 596)
        Me.cmdWorkMemo.Name = "cmdWorkMemo"
        Me.cmdWorkMemo.Size = New System.Drawing.Size(85, 40)
        Me.cmdWorkMemo.TabIndex = 11
        Me.cmdWorkMemo.Text = "作業メモ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'chkDateSelectKbn
        '
        Me.chkDateSelectKbn.Location = New System.Drawing.Point(15, 70)
        Me.chkDateSelectKbn.Name = "chkDateSelectKbn"
        Me.chkDateSelectKbn.Size = New System.Drawing.Size(91, 22)
        Me.chkDateSelectKbn.TabIndex = 2
        Me.chkDateSelectKbn.Text = "指定する"
        '
        'cmdCopy
        '
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Location = New System.Drawing.Point(888, 596)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopy.TabIndex = 12
        Me.cmdCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Location = New System.Drawing.Point(759, 8)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 10
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 596)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "閉じる"
        '
        'cmbPart
        '
        Me.cmbPart.DirectInput = false
        Me.cmbPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.ForeColor = System.Drawing.Color.Black
        Me.cmbPart.GetCol = 2
        Me.cmbPart.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridForeColor = System.Drawing.Color.Black
        Me.cmbPart.Location = New System.Drawing.Point(187, 24)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(490, 22)
        Me.cmbPart.TabIndex = 1
        Me.cmbPart.Value = Nothing
        '
        'cmbPartClass
        '
        Me.cmbPartClass.DirectInput = false
        Me.cmbPartClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartClass.ForeColor = System.Drawing.Color.Black
        Me.cmbPartClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartClass.GridForeColor = System.Drawing.Color.Black
        Me.cmbPartClass.Location = New System.Drawing.Point(8, 24)
        Me.cmbPartClass.Name = "cmbPartClass"
        Me.cmbPartClass.Size = New System.Drawing.Size(180, 22)
        Me.cmbPartClass.TabIndex = 0
        Me.cmbPartClass.Value = Nothing
        '
        'calFromDate
        '
        Me.calFromDate.DateCheckStatus = 0
        Me.calFromDate.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.Enabled = false
        Me.calFromDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.IsDate = true
        Me.calFromDate.Location = New System.Drawing.Point(287, 69)
        Me.calFromDate.Name = "calFromDate"
        Me.calFromDate.Size = New System.Drawing.Size(117, 22)
        Me.calFromDate.TabIndex = 4
        Me.calFromDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.Value = "____/__/__"
        '
        'calToDate
        '
        Me.calToDate.DateCheckStatus = 0
        Me.calToDate.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.Enabled = false
        Me.calToDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.IsDate = true
        Me.calToDate.Location = New System.Drawing.Point(507, 69)
        Me.calToDate.Name = "calToDate"
        Me.calToDate.Size = New System.Drawing.Size(117, 22)
        Me.calToDate.TabIndex = 6
        Me.calToDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.Value = "____/__/__"
        '
        'medFromTime
        '
        Me.medFromTime.Enabled = false
        Me.medFromTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medFromTime.Location = New System.Drawing.Point(407, 69)
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
        Me.medToTime.Location = New System.Drawing.Point(626, 69)
        Me.medToTime.Mask = "00:00"
        Me.medToTime.Name = "medToTime"
        Me.medToTime.ResetOnSpace = false
        Me.medToTime.Size = New System.Drawing.Size(51, 22)
        Me.medToTime.TabIndex = 7
        Me.medToTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'vsfStockList
        '
        Me.vsfStockList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfStockList.AllowEditing = false
        Me.vsfStockList.AutoSearchDelay = 2R
        Me.vsfStockList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfStockList.ColumnInfo = resources.GetString("vsfStockList.ColumnInfo")
        Me.vsfStockList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfStockList.ExtendLastCol = true
        Me.vsfStockList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfStockList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfStockList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfStockList.Location = New System.Drawing.Point(8, 96)
        Me.vsfStockList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfStockList.Name = "vsfStockList"
        Me.vsfStockList.Rows.Count = 30
        Me.vsfStockList.Rows.DefaultSize = 19
        Me.vsfStockList.Rows.Frozen = 1
        Me.vsfStockList.Rows.GlyphRow = 0
        Me.vsfStockList.Rows.MaxSize = 20
        Me.vsfStockList.Rows.MinSize = 18
        Me.vsfStockList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfStockList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfStockList.Size = New System.Drawing.Size(964, 491)
        Me.vsfStockList.StyleInfo = resources.GetString("vsfStockList.StyleInfo")
        Me.vsfStockList.TabIndex = 8
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(760, 52)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(138, 17)
        Me.lblTitle0.TabIndex = 24
        Me.lblTitle0.Text = "現在数量"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowTotal
        '
        Me.lblNowTotal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowTotal.Location = New System.Drawing.Point(760, 68)
        Me.lblNowTotal.Name = "lblNowTotal"
        Me.lblNowTotal.Size = New System.Drawing.Size(138, 22)
        Me.lblNowTotal.TabIndex = 23
        Me.lblNowTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(8, 52)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(98, 17)
        Me.lblTtl4.TabIndex = 22
        Me.lblTtl4.Text = "絞込み条件"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(108, 52)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(176, 17)
        Me.lblTtl2.TabIndex = 21
        Me.lblTtl2.Text = "製造ロットID"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(287, 52)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(390, 17)
        Me.lblTtl5.TabIndex = 19
        Me.lblTtl5.Text = "期間"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(851, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
        Me.lblNowDate.TabIndex = 18
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(851, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle1.TabIndex = 17
        Me.lblTitle1.Text = "情報取得日時"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(8, 8)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(180, 17)
        Me.lblTtl1.TabIndex = 16
        Me.lblTtl1.Text = "部品種別"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(187, 8)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(490, 17)
        Me.lblTtl0.TabIndex = 15
        Me.lblTtl0.Text = "部品"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(900, 52)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle3.TabIndex = 14
        Me.lblTitle3.Text = "表示件数"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(900, 68)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(73, 22)
        Me.lblLotCnt.TabIndex = 13
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblKara
        '
        Me.lblKara.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblKara.Location = New System.Drawing.Point(468, 69)
        Me.lblKara.Name = "lblKara"
        Me.lblKara.Size = New System.Drawing.Size(37, 21)
        Me.lblKara.TabIndex = 20
        Me.lblKara.Text = "～"
        '
        'frmxxEN01I0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.txtProLotID)
        Me.Controls.Add(Me.cmdWorkMemo)
        Me.Controls.Add(Me.chkDateSelectKbn)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.cmbPartClass)
        Me.Controls.Add(Me.calFromDate)
        Me.Controls.Add(Me.calToDate)
        Me.Controls.Add(Me.medFromTime)
        Me.Controls.Add(Me.medToTime)
        Me.Controls.Add(Me.vsfStockList)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblNowTotal)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblKara)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01I0"
        Me.Text = "部材履歴"
        CType(Me.vsfStockList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtProLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdWorkMemo As Button
    Friend WithEvents chkDateSelectKbn As CheckBox
    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmbPart As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPartClass As SEComboBoxEx.ComboBoxEx
    Friend WithEvents calFromDate As SECalendarEx.CalendarEx
    Friend WithEvents calToDate As SECalendarEx.CalendarEx
    Friend WithEvents medFromTime As MaskedTextBox
    Friend WithEvents medToTime As MaskedTextBox
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblNowTotal As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblKara As Label
    Public WithEvents cmdClose As Button
    Public WithEvents vsfStockList As C1.Win.C1FlexGrid.C1FlexGrid
End Class
