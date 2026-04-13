<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01N0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01N0))
        Me.cmdLDown = New System.Windows.Forms.Button()
        Me.cmdLUp = New System.Windows.Forms.Button()
        Me.cmdMDown = New System.Windows.Forms.Button()
        Me.cmdMUp = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdKaijyo = New System.Windows.Forms.Button()
        Me.cmdKinshi = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.picDownAllow = New System.Windows.Forms.PictureBox()
        Me.cmdRireki = New System.Windows.Forms.Button()
        Me.cmdHenkou = New System.Windows.Forms.Button()
        Me.vsfCmpList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.txtNewPolRate = New SETextBoxEx.TextBoxEx()
        Me.txtLastComments = New SETextBoxEx.TextBoxEx()
        Me.cmbWplist = New SECmbIchiran.ComboIchiran()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblOldPolRate = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblListCnt = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblGetInfoDate = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblLastComments = New System.Windows.Forms.Label()
        CType(Me.picDownAllow,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfCmpList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdLDown
        '
        Me.cmdLDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLDown.Location = New System.Drawing.Point(804, 467)
        Me.cmdLDown.Name = "cmdLDown"
        Me.cmdLDown.Size = New System.Drawing.Size(25, 38)
        Me.cmdLDown.TabIndex = 13
        Me.cmdLDown.Text = "▼"
        '
        'cmdLUp
        '
        Me.cmdLUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLUp.Location = New System.Drawing.Point(804, 427)
        Me.cmdLUp.Name = "cmdLUp"
        Me.cmdLUp.Size = New System.Drawing.Size(25, 38)
        Me.cmdLUp.TabIndex = 12
        Me.cmdLUp.Text = "▲"
        '
        'cmdMDown
        '
        Me.cmdMDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMDown.Location = New System.Drawing.Point(804, 555)
        Me.cmdMDown.Name = "cmdMDown"
        Me.cmdMDown.Size = New System.Drawing.Size(25, 38)
        Me.cmdMDown.TabIndex = 5
        Me.cmdMDown.Text = "▼"
        '
        'cmdMUp
        '
        Me.cmdMUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMUp.Location = New System.Drawing.Point(804, 516)
        Me.cmdMUp.Name = "cmdMUp"
        Me.cmdMUp.Size = New System.Drawing.Size(25, 38)
        Me.cmdMUp.TabIndex = 4
        Me.cmdMUp.Text = "▲"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(670, 15)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 10
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdKaijyo
        '
        Me.cmdKaijyo.CausesValidation = false
        Me.cmdKaijyo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKaijyo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKaijyo.Location = New System.Drawing.Point(792, 596)
        Me.cmdKaijyo.Name = "cmdKaijyo"
        Me.cmdKaijyo.Size = New System.Drawing.Size(85, 40)
        Me.cmdKaijyo.TabIndex = 7
        Me.cmdKaijyo.Text = "使用禁止"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"解除"
        '
        'cmdKinshi
        '
        Me.cmdKinshi.CausesValidation = false
        Me.cmdKinshi.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKinshi.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKinshi.Location = New System.Drawing.Point(696, 596)
        Me.cmdKinshi.Name = "cmdKinshi"
        Me.cmdKinshi.Size = New System.Drawing.Size(85, 40)
        Me.cmdKinshi.TabIndex = 8
        Me.cmdKinshi.Text = "使用禁止"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"設定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 596)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.Text = "閉じる"
        '
        'picDownAllow
        '
        Me.picDownAllow.Image = CType(resources.GetObject("picDownAllow.Image"),System.Drawing.Image)
        Me.picDownAllow.Location = New System.Drawing.Point(904, 472)
        Me.picDownAllow.Name = "picDownAllow"
        Me.picDownAllow.Size = New System.Drawing.Size(32, 32)
        Me.picDownAllow.TabIndex = 15
        Me.picDownAllow.TabStop = false
        '
        'cmdRireki
        '
        Me.cmdRireki.CausesValidation = false
        Me.cmdRireki.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRireki.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRireki.Location = New System.Drawing.Point(598, 596)
        Me.cmdRireki.Name = "cmdRireki"
        Me.cmdRireki.Size = New System.Drawing.Size(85, 40)
        Me.cmdRireki.TabIndex = 9
        Me.cmdRireki.Text = "ﾒﾝﾃﾅﾝｽ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"履歴"
        '
        'cmdHenkou
        '
        Me.cmdHenkou.CausesValidation = false
        Me.cmdHenkou.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHenkou.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHenkou.Location = New System.Drawing.Point(888, 596)
        Me.cmdHenkou.Name = "cmdHenkou"
        Me.cmdHenkou.Size = New System.Drawing.Size(85, 40)
        Me.cmdHenkou.TabIndex = 6
        Me.cmdHenkou.Text = "研磨ﾚｰﾄ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"変更"
        '
        'vsfCmpList
        '
        Me.vsfCmpList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCmpList.AllowEditing = false
        Me.vsfCmpList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfCmpList.AutoSearchDelay = 2R
        Me.vsfCmpList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCmpList.ColumnInfo = resources.GetString("vsfCmpList.ColumnInfo")
        Me.vsfCmpList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCmpList.ExtendLastCol = true
        Me.vsfCmpList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCmpList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCmpList.Location = New System.Drawing.Point(8, 68)
        Me.vsfCmpList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCmpList.Name = "vsfCmpList"
        Me.vsfCmpList.Rows.Count = 4
        Me.vsfCmpList.Rows.DefaultSize = 18
        Me.vsfCmpList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCmpList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfCmpList.Size = New System.Drawing.Size(965, 351)
        Me.vsfCmpList.StyleInfo = resources.GetString("vsfCmpList.StyleInfo")
        Me.vsfCmpList.TabIndex = 1
        '
        'txtComments
        '
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 2048
        Me.txtComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtComments.GotHighLight = false
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtComments.Location = New System.Drawing.Point(8, 533)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NgChr = "'"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(797, 59)
        Me.txtComments.TabIndex = 3
        '
        'txtNewPolRate
        '
        Me.txtNewPolRate.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtNewPolRate.ChrMaxByte = 10
        Me.txtNewPolRate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtNewPolRate.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtNewPolRate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtNewPolRate.Location = New System.Drawing.Point(865, 532)
        Me.txtNewPolRate.Name = "txtNewPolRate"
        Me.txtNewPolRate.NgChr = "'"
        Me.txtNewPolRate.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_2_Decimal
        Me.txtNewPolRate.NumFormat = "0.00"
        Me.txtNewPolRate.NumMax = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.txtNewPolRate.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtNewPolRate.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNewPolRate.SelectedText = ""
        Me.txtNewPolRate.Size = New System.Drawing.Size(108, 22)
        Me.txtNewPolRate.TabIndex = 2
        Me.txtNewPolRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLastComments
        '
        Me.txtLastComments.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtLastComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtLastComments.ChrMaxByte = 2048
        Me.txtLastComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLastComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtLastComments.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtLastComments.GotHighLight = false
        Me.txtLastComments.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLastComments.Location = New System.Drawing.Point(8, 445)
        Me.txtLastComments.MultiLineEx = true
        Me.txtLastComments.Name = "txtLastComments"
        Me.txtLastComments.NgChr = "'"
        Me.txtLastComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLastComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLastComments.SelectedText = ""
        Me.txtLastComments.Size = New System.Drawing.Size(797, 59)
        Me.txtLastComments.TabIndex = 11
        Me.txtLastComments.TabStop = false
        '
        'cmbWplist
        '
        Me.cmbWplist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWplist.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWplist.GridForeColor = System.Drawing.Color.Black
        Me.cmbWplist.Location = New System.Drawing.Point(10, 32)
        Me.cmbWplist.Name = "cmbWplist"
        Me.cmbWplist.Size = New System.Drawing.Size(376, 22)
        Me.cmbWplist.TabIndex = 0
        Me.cmbWplist.Value = Nothing
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(865, 516)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(108, 17)
        Me.lblTitle2.TabIndex = 25
        Me.lblTitle2.Text = "変更後レート"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOldPolRate
        '
        Me.lblOldPolRate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOldPolRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOldPolRate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOldPolRate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOldPolRate.Location = New System.Drawing.Point(865, 442)
        Me.lblOldPolRate.Name = "lblOldPolRate"
        Me.lblOldPolRate.Size = New System.Drawing.Size(108, 22)
        Me.lblOldPolRate.TabIndex = 24
        Me.lblOldPolRate.Text = "999999.99"
        Me.lblOldPolRate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(865, 426)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(108, 17)
        Me.lblTitle8.TabIndex = 23
        Me.lblTitle8.Text = "変更前レート"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(528, 517)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(247, 17)
        Me.lblLengthCount.TabIndex = 21
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(10, 16)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(375, 17)
        Me.lblTitle1.TabIndex = 20
        Me.lblTitle1.Text = "CMP装置"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(899, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle0.TabIndex = 19
        Me.lblTitle0.Text = "該当件数"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblListCnt
        '
        Me.lblListCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblListCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblListCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblListCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblListCnt.Location = New System.Drawing.Point(899, 32)
        Me.lblListCnt.Name = "lblListCnt"
        Me.lblListCnt.Size = New System.Drawing.Size(74, 22)
        Me.lblListCnt.TabIndex = 18
        Me.lblListCnt.Text = "0"
        Me.lblListCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(765, 17)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(129, 17)
        Me.lblTitle4.TabIndex = 17
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGetInfoDate
        '
        Me.lblGetInfoDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGetInfoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGetInfoDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGetInfoDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGetInfoDate.Location = New System.Drawing.Point(765, 32)
        Me.lblGetInfoDate.Name = "lblGetInfoDate"
        Me.lblGetInfoDate.Size = New System.Drawing.Size(129, 22)
        Me.lblGetInfoDate.TabIndex = 16
        Me.lblGetInfoDate.Text = "08/17 10:46:25"
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(8, 517)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(797, 17)
        Me.lblTitle7.TabIndex = 22
        Me.lblTitle7.Text = "メンテナンスコメント"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLastComments
        '
        Me.lblLastComments.BackColor = System.Drawing.Color.Navy
        Me.lblLastComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLastComments.ForeColor = System.Drawing.Color.Yellow
        Me.lblLastComments.Location = New System.Drawing.Point(8, 428)
        Me.lblLastComments.Name = "lblLastComments"
        Me.lblLastComments.Size = New System.Drawing.Size(797, 17)
        Me.lblLastComments.TabIndex = 26
        Me.lblLastComments.Text = "最終コメント（""最終ｲﾍﾞﾝﾄ名""）"
        Me.lblLastComments.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01N0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdLDown)
        Me.Controls.Add(Me.cmdLUp)
        Me.Controls.Add(Me.cmdMDown)
        Me.Controls.Add(Me.cmdMUp)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdKaijyo)
        Me.Controls.Add(Me.cmdKinshi)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.picDownAllow)
        Me.Controls.Add(Me.cmdRireki)
        Me.Controls.Add(Me.cmdHenkou)
        Me.Controls.Add(Me.vsfCmpList)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.txtNewPolRate)
        Me.Controls.Add(Me.txtLastComments)
        Me.Controls.Add(Me.cmbWplist)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblOldPolRate)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblListCnt)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblGetInfoDate)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblLastComments)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01N0"
        Me.Text = "ＣＭＰメンテナンス"
        CType(Me.picDownAllow,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfCmpList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdLDown As Button
    Friend WithEvents cmdLUp As Button
    Friend WithEvents cmdMDown As Button
    Friend WithEvents cmdMUp As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdKaijyo As Button
    Friend WithEvents cmdKinshi As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents picDownAllow As PictureBox
    Friend WithEvents cmdRireki As Button
    Friend WithEvents cmdHenkou As Button
    Friend WithEvents vsfCmpList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents txtNewPolRate As SETextBoxEx.TextBoxEx
    Friend WithEvents txtLastComments As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbWplist As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblOldPolRate As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblListCnt As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblGetInfoDate As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblLastComments As Label
End Class
