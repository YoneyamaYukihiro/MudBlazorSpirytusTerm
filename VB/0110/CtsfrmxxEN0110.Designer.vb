<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0110
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0110))
        Me.cmdExecution = New System.Windows.Forms.Button()
        Me.chkMessage = New System.Windows.Forms.CheckBox()
        Me.picDownAllow = New System.Windows.Forms.PictureBox()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdFix = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfMcGroupEquipment = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.cmbMcGroup = New SECmbIchiran.ComboIchiran()
        Me.cmbUseName = New SECmbIchiran.ComboIchiran()
        Me.cmbALDMode = New SECmbIchiran.ComboIchiran()
        Me.lblALDMode = New System.Windows.Forms.Label()
        Me.lblMesMode = New System.Windows.Forms.Label()
        Me.lblTitleT = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblUseName = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblEquipmentCnt = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        CType(Me.picDownAllow,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfMcGroupEquipment,System.ComponentModel.ISupportInitialize).BeginInit
        Me.lblTtl15.SuspendLayout
        Me.SuspendLayout
        '
        'cmdExecution
        '
        Me.cmdExecution.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdExecution.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdExecution.Location = New System.Drawing.Point(648, 581)
        Me.cmdExecution.Name = "cmdExecution"
        Me.cmdExecution.Size = New System.Drawing.Size(105, 57)
        Me.cmdExecution.TabIndex = 27
        Me.cmdExecution.Text = "強制"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Ｍ１変更"
        '
        'chkMessage
        '
        Me.chkMessage.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkMessage.Location = New System.Drawing.Point(810, 216)
        Me.chkMessage.Name = "chkMessage"
        Me.chkMessage.Size = New System.Drawing.Size(168, 22)
        Me.chkMessage.TabIndex = 25
        Me.chkMessage.Text = "メッセージ表示"
        '
        'picDownAllow
        '
        Me.picDownAllow.Image = CType(resources.GetObject("picDownAllow.Image"),System.Drawing.Image)
        Me.picDownAllow.Location = New System.Drawing.Point(872, 120)
        Me.picDownAllow.Name = "picDownAllow"
        Me.picDownAllow.Size = New System.Drawing.Size(32, 32)
        Me.picDownAllow.TabIndex = 22
        Me.picDownAllow.TabStop = false
        '
        'cmdNowList
        '
        Me.cmdNowList.CausesValidation = false
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(621, 8)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowList.TabIndex = 1
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(751, 489)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoUp.TabIndex = 8
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(751, 533)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 9
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(751, 73)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 204)
        Me.cmdUP.TabIndex = 3
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(751, 280)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 204)
        Me.cmdDown.TabIndex = 4
        Me.cmdDown.Text = "▼"
        '
        'cmdFix
        '
        Me.cmdFix.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFix.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFix.Location = New System.Drawing.Point(872, 581)
        Me.cmdFix.Name = "cmdFix"
        Me.cmdFix.Size = New System.Drawing.Size(105, 57)
        Me.cmdFix.TabIndex = 6
        Me.cmdFix.Text = "確　定"
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
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "閉じる"
        '
        'vsfMcGroupEquipment
        '
        Me.vsfMcGroupEquipment.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMcGroupEquipment.AllowEditing = false
        Me.vsfMcGroupEquipment.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMcGroupEquipment.AutoSearchDelay = 2R
        Me.vsfMcGroupEquipment.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMcGroupEquipment.ColumnInfo = resources.GetString("vsfMcGroupEquipment.ColumnInfo")
        Me.vsfMcGroupEquipment.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMcGroupEquipment.ExtendLastCol = true
        Me.vsfMcGroupEquipment.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMcGroupEquipment.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMcGroupEquipment.Location = New System.Drawing.Point(8, 74)
        Me.vsfMcGroupEquipment.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMcGroupEquipment.Name = "vsfMcGroupEquipment"
        Me.vsfMcGroupEquipment.Rows.Count = 40
        Me.vsfMcGroupEquipment.Rows.DefaultSize = 18
        Me.vsfMcGroupEquipment.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMcGroupEquipment.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMcGroupEquipment.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMcGroupEquipment.Size = New System.Drawing.Size(743, 409)
        Me.vsfMcGroupEquipment.StyleInfo = resources.GetString("vsfMcGroupEquipment.StyleInfo")
        Me.vsfMcGroupEquipment.TabIndex = 2
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 506)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
        Me.txtWorkMemo.TabIndex = 7
        '
        'cmbMcGroup
        '
        Me.cmbMcGroup.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.Location = New System.Drawing.Point(8, 24)
        Me.cmbMcGroup.Name = "cmbMcGroup"
        Me.cmbMcGroup.Size = New System.Drawing.Size(358, 28)
        Me.cmbMcGroup.TabIndex = 0
        Me.cmbMcGroup.Value = Nothing
        '
        'cmbUseName
        '
        Me.cmbUseName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbUseName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbUseName.Location = New System.Drawing.Point(811, 175)
        Me.cmbUseName.Name = "cmbUseName"
        Me.cmbUseName.Size = New System.Drawing.Size(162, 28)
        Me.cmbUseName.TabIndex = 5
        Me.cmbUseName.Value = Nothing
        '
        'cmbALDMode
        '
        Me.cmbALDMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbALDMode.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbALDMode.Location = New System.Drawing.Point(811, 320)
        Me.cmbALDMode.Name = "cmbALDMode"
        Me.cmbALDMode.Size = New System.Drawing.Size(162, 28)
        Me.cmbALDMode.TabIndex = 26
        Me.cmbALDMode.Value = Nothing
        '
        'lblALDMode
        '
        Me.lblALDMode.BackColor = System.Drawing.Color.Navy
        Me.lblALDMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblALDMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblALDMode.ForeColor = System.Drawing.Color.Yellow
        Me.lblALDMode.Location = New System.Drawing.Point(811, 304)
        Me.lblALDMode.Name = "lblALDMode"
        Me.lblALDMode.Size = New System.Drawing.Size(162, 17)
        Me.lblALDMode.TabIndex = 24
        Me.lblALDMode.Text = "防湿ALD処理モード"
        Me.lblALDMode.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMesMode
        '
        Me.lblMesMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMesMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMesMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMesMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMesMode.Location = New System.Drawing.Point(384, 24)
        Me.lblMesMode.Name = "lblMesMode"
        Me.lblMesMode.Size = New System.Drawing.Size(161, 30)
        Me.lblMesMode.TabIndex = 23
        Me.lblMesMode.Text = "M1"
        '
        'lblTitleT
        '
        Me.lblTitleT.AutoSize = true
        Me.lblTitleT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleT.Location = New System.Drawing.Point(572, 47)
        Me.lblTitleT.Name = "lblTitleT"
        Me.lblTitleT.Size = New System.Drawing.Size(42, 18)
        Me.lblTitleT.TabIndex = 21
        Me.lblTitleT.Text = "停止"
        Me.lblTitleT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleT.UseMnemonic = false
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(358, 17)
        Me.lblTitle0.TabIndex = 20
        Me.lblTitle0.Text = "装置グループ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(739, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 25)
        Me.lblNowDate.TabIndex = 19
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(739, 8)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 18
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblUseName
        '
        Me.lblUseName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblUseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUseName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUseName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUseName.Location = New System.Drawing.Point(811, 89)
        Me.lblUseName.Name = "lblUseName"
        Me.lblUseName.Size = New System.Drawing.Size(161, 30)
        Me.lblUseName.TabIndex = 17
        Me.lblUseName.Text = "通常"
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(811, 73)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle2.TabIndex = 16
        Me.lblTitle2.Text = "現在の装置状態"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(487, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 14
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblEquipmentCnt
        '
        Me.lblEquipmentCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEquipmentCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEquipmentCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEquipmentCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEquipmentCnt.Location = New System.Drawing.Point(898, 24)
        Me.lblEquipmentCnt.Name = "lblEquipmentCnt"
        Me.lblEquipmentCnt.Size = New System.Drawing.Size(74, 25)
        Me.lblEquipmentCnt.TabIndex = 13
        Me.lblEquipmentCnt.Text = "0"
        Me.lblEquipmentCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(898, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle1.TabIndex = 12
        Me.lblTitle1.Text = "該当件数"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(811, 159)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(162, 17)
        Me.lblTitle3.TabIndex = 11
        Me.lblTitle3.Text = "変更後"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Controls.Add(Me.lblLengthCount)
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 490)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl15.TabIndex = 15
        Me.lblTtl15.Text = "      作業メモ"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN0110
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdExecution)
        Me.Controls.Add(Me.chkMessage)
        Me.Controls.Add(Me.picDownAllow)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdFix)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfMcGroupEquipment)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.cmbMcGroup)
        Me.Controls.Add(Me.cmbUseName)
        Me.Controls.Add(Me.cmbALDMode)
        Me.Controls.Add(Me.lblALDMode)
        Me.Controls.Add(Me.lblMesMode)
        Me.Controls.Add(Me.lblTitleT)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblUseName)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblEquipmentCnt)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTtl15)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0110"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "装置状態変更"
        CType(Me.picDownAllow,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfMcGroupEquipment,System.ComponentModel.ISupportInitialize).EndInit
        Me.lblTtl15.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmdExecution As Button
    Friend WithEvents chkMessage As CheckBox
    Friend WithEvents picDownAllow As PictureBox
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdFix As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfMcGroupEquipment As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbMcGroup As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbUseName As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbALDMode As SECmbIchiran.ComboIchiran
    Friend WithEvents lblALDMode As Label
    Friend WithEvents lblMesMode As Label
    Friend WithEvents lblTitleT As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblUseName As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblEquipmentCnt As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTtl15 As Label
End Class
