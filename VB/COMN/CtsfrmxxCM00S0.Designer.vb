<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00S0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00S0))
        Me.cmdMailChoice = New System.Windows.Forms.Button()
        Me.cmdMailDel = New System.Windows.Forms.Button()
        Me.cmdTxtDown = New System.Windows.Forms.Button()
        Me.cmdTxtUp = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdSendMail = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfMailList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtMailContents = New SETextBoxEx.TextBoxEx()
        Me.fraMail = New System.Windows.Forms.GroupBox()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.txtsubject = New SETextBoxEx.TextBoxEx()
        Me.lblLengthCount0 = New System.Windows.Forms.Label()
        Me.lblLengthCount1 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        CType(Me.vsfMailList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraMail.SuspendLayout
        Me.SuspendLayout
        '
        'cmdMailChoice
        '
        Me.cmdMailChoice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMailChoice.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMailChoice.Location = New System.Drawing.Point(14, 44)
        Me.cmdMailChoice.Name = "cmdMailChoice"
        Me.cmdMailChoice.Size = New System.Drawing.Size(105, 57)
        Me.cmdMailChoice.TabIndex = 0
        Me.cmdMailChoice.Text = "宛　先"
        '
        'cmdMailDel
        '
        Me.cmdMailDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMailDel.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMailDel.Location = New System.Drawing.Point(14, 118)
        Me.cmdMailDel.Name = "cmdMailDel"
        Me.cmdMailDel.Size = New System.Drawing.Size(105, 57)
        Me.cmdMailDel.TabIndex = 1
        Me.cmdMailDel.Text = "削　除"
        '
        'cmdTxtDown
        '
        Me.cmdTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtDown.Location = New System.Drawing.Point(927, 418)
        Me.cmdTxtDown.Name = "cmdTxtDown"
        Me.cmdTxtDown.Size = New System.Drawing.Size(49, 153)
        Me.cmdTxtDown.TabIndex = 8
        Me.cmdTxtDown.Text = "▼"
        '
        'cmdTxtUp
        '
        Me.cmdTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtUp.Location = New System.Drawing.Point(927, 263)
        Me.cmdTxtUp.Name = "cmdTxtUp"
        Me.cmdTxtUp.Size = New System.Drawing.Size(49, 153)
        Me.cmdTxtUp.TabIndex = 7
        Me.cmdTxtUp.Text = "▲"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(926, 27)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 75)
        Me.cmdUP.TabIndex = 3
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(926, 102)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 75)
        Me.cmdDown.TabIndex = 4
        Me.cmdDown.Text = "▼"
        '
        'cmdSendMail
        '
        Me.cmdSendMail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSendMail.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSendMail.Location = New System.Drawing.Point(872, 579)
        Me.cmdSendMail.Name = "cmdSendMail"
        Me.cmdSendMail.Size = New System.Drawing.Size(105, 57)
        Me.cmdSendMail.TabIndex = 9
        Me.cmdSendMail.Text = "送　信"
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
        'vsfMailList
        '
        Me.vsfMailList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMailList.AllowEditing = false
        Me.vsfMailList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMailList.AutoSearchDelay = 2R
        Me.vsfMailList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMailList.ColumnInfo = resources.GetString("vsfMailList.ColumnInfo")
        Me.vsfMailList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMailList.ExtendLastCol = true
        Me.vsfMailList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfMailList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMailList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMailList.Location = New System.Drawing.Point(124, 45)
        Me.vsfMailList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMailList.Name = "vsfMailList"
        Me.vsfMailList.Rows.Count = 10
        Me.vsfMailList.Rows.DefaultSize = 18
        Me.vsfMailList.Rows.Fixed = 0
        Me.vsfMailList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMailList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMailList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfMailList.Size = New System.Drawing.Size(802, 131)
        Me.vsfMailList.StyleInfo = resources.GetString("vsfMailList.StyleInfo")
        Me.vsfMailList.TabIndex = 2
        '
        'txtMailContents
        '
        Me.txtMailContents.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtMailContents.ChrMaxByte = 0
        Me.txtMailContents.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtMailContents.GotHighLight = false
        Me.txtMailContents.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMailContents.Location = New System.Drawing.Point(8, 281)
        Me.txtMailContents.MultiLineEx = true
        Me.txtMailContents.Name = "txtMailContents"
        Me.txtMailContents.NgChr = "'"
        Me.txtMailContents.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtMailContents.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMailContents.SelectedText = ""
        Me.txtMailContents.Size = New System.Drawing.Size(919, 289)
        Me.txtMailContents.TabIndex = 6
        '
        'fraMail
        '
        Me.fraMail.Controls.Add(Me.lblTtl2)
        Me.fraMail.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraMail.Location = New System.Drawing.Point(8, 8)
        Me.fraMail.Name = "fraMail"
        Me.fraMail.Size = New System.Drawing.Size(969, 183)
        Me.fraMail.TabIndex = 13
        Me.fraMail.TabStop = false
        Me.fraMail.Text = "宛先指定"
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(116, 20)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(802, 17)
        Me.lblTtl2.TabIndex = 16
        Me.lblTtl2.Text = "宛先一覧"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtsubject
        '
        Me.txtsubject.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtsubject.ChrMaxByte = 0
        Me.txtsubject.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtsubject.GotHighLight = false
        Me.txtsubject.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtsubject.Location = New System.Drawing.Point(8, 219)
        Me.txtsubject.MultiLineEx = true
        Me.txtsubject.Name = "txtsubject"
        Me.txtsubject.NgChr = "'"
        Me.txtsubject.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtsubject.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtsubject.SelectedText = ""
        Me.txtsubject.Size = New System.Drawing.Size(919, 34)
        Me.txtsubject.TabIndex = 5
        '
        'lblLengthCount0
        '
        Me.lblLengthCount0.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount0.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount0.Location = New System.Drawing.Point(672, 203)
        Me.lblLengthCount0.Name = "lblLengthCount0"
        Me.lblLengthCount0.Size = New System.Drawing.Size(249, 15)
        Me.lblLengthCount0.TabIndex = 15
        Me.lblLengthCount0.Text = "（ 半角80文字/半角80文字 ）"
        Me.lblLengthCount0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount1
        '
        Me.lblLengthCount1.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount1.Location = New System.Drawing.Point(665, 265)
        Me.lblLengthCount1.Name = "lblLengthCount1"
        Me.lblLengthCount1.Size = New System.Drawing.Size(256, 15)
        Me.lblLengthCount1.TabIndex = 11
        Me.lblLengthCount1.Text = "（ 半角2000文字/半角2000文字 ）"
        Me.lblLengthCount1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(8, 264)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(919, 17)
        Me.lblTtl1.TabIndex = 12
        Me.lblTtl1.Text = "本　文"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 202)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(919, 17)
        Me.lblTtl0.TabIndex = 14
        Me.lblTtl0.Text = "件　名"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxCM00S0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdMailChoice)
        Me.Controls.Add(Me.cmdMailDel)
        Me.Controls.Add(Me.cmdTxtDown)
        Me.Controls.Add(Me.cmdTxtUp)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdSendMail)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfMailList)
        Me.Controls.Add(Me.txtMailContents)
        Me.Controls.Add(Me.fraMail)
        Me.Controls.Add(Me.txtsubject)
        Me.Controls.Add(Me.lblLengthCount0)
        Me.Controls.Add(Me.lblLengthCount1)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl0)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00S0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "メール送信"
        CType(Me.vsfMailList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraMail.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdMailChoice As Button
    Friend WithEvents cmdMailDel As Button
    Friend WithEvents cmdTxtDown As Button
    Friend WithEvents cmdTxtUp As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdSendMail As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfMailList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtMailContents As SETextBoxEx.TextBoxEx
    Friend WithEvents fraMail As GroupBox
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents txtsubject As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLengthCount0 As Label
    Friend WithEvents lblLengthCount1 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl0 As Label
End Class
