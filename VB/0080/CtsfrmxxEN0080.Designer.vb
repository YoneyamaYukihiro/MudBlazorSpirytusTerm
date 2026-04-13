<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0080
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0080))
        Me.cmdWorkRecord = New System.Windows.Forms.Button()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdTxtDown = New System.Windows.Forms.Button()
        Me.cmdTxtUp = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.cmdCommntInput = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.txtLotCommnt = New SETextBoxEx.TextBoxEx()
        Me.lblTtl16 = New System.Windows.Forms.Label()
        Me.lblWpStatusName = New System.Windows.Forms.Label()
        Me.lblLoaderPort = New System.Windows.Forms.Label()
        Me.lblLoaderCarrier = New System.Windows.Forms.Label()
        Me.lblTtl14 = New System.Windows.Forms.Label()
        Me.lblTtl18 = New System.Windows.Forms.Label()
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
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.lblWP = New System.Windows.Forms.Label()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblGRB = New System.Windows.Forms.Label()
        Me.lblTtl15.SuspendLayout
        Me.SuspendLayout
        '
        'cmdWorkRecord
        '
        Me.cmdWorkRecord.Enabled = false
        Me.cmdWorkRecord.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkRecord.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWorkRecord.Location = New System.Drawing.Point(548, 579)
        Me.cmdWorkRecord.Name = "cmdWorkRecord"
        Me.cmdWorkRecord.Size = New System.Drawing.Size(105, 57)
        Me.cmdWorkRecord.TabIndex = 32
        Me.cmdWorkRecord.Text = "作業記録"
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(750, 367)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoUp.TabIndex = 35
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(750, 411)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 36
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdTxtDown
        '
        Me.cmdTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtDown.Location = New System.Drawing.Point(750, 519)
        Me.cmdTxtDown.Name = "cmdTxtDown"
        Me.cmdTxtDown.Size = New System.Drawing.Size(49, 55)
        Me.cmdTxtDown.TabIndex = 40
        Me.cmdTxtDown.Text = "▼"
        '
        'cmdTxtUp
        '
        Me.cmdTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtUp.Location = New System.Drawing.Point(750, 463)
        Me.cmdTxtUp.Name = "cmdTxtUp"
        Me.cmdTxtUp.Size = New System.Drawing.Size(49, 55)
        Me.cmdTxtUp.TabIndex = 39
        Me.cmdTxtUp.Text = "▲"
        '
        'txtCarrier
        '
        Me.txtCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtCarrier.TabIndex = 2
        '
        'cmdCommntInput
        '
        Me.cmdCommntInput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommntInput.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommntInput.Location = New System.Drawing.Point(332, 579)
        Me.cmdCommntInput.Name = "cmdCommntInput"
        Me.cmdCommntInput.Size = New System.Drawing.Size(105, 57)
        Me.cmdCommntInput.TabIndex = 31
        Me.cmdCommntInput.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 579)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 41
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 579)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 30
        Me.cmdRegist.Text = "確　定"
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtWorkMemo.TabIndex = 34
        '
        'txtLotCommnt
        '
        Me.txtLotCommnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.txtLotCommnt.Size = New System.Drawing.Size(743, 93)
        Me.txtLotCommnt.TabIndex = 38
        Me.txtLotCommnt.TabStop = false
        '
        'lblTtl16
        '
        Me.lblTtl16.BackColor = System.Drawing.Color.Navy
        Me.lblTtl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl16.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl16.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl16.Location = New System.Drawing.Point(312, 124)
        Me.lblTtl16.Name = "lblTtl16"
        Me.lblTtl16.Size = New System.Drawing.Size(189, 17)
        Me.lblTtl16.TabIndex = 26
        Me.lblTtl16.Text = "処理状態"
        Me.lblTtl16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWpStatusName
        '
        Me.lblWpStatusName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWpStatusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpStatusName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpStatusName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWpStatusName.Location = New System.Drawing.Point(312, 140)
        Me.lblWpStatusName.Name = "lblWpStatusName"
        Me.lblWpStatusName.Size = New System.Drawing.Size(189, 30)
        Me.lblWpStatusName.TabIndex = 27
        '
        'lblLoaderPort
        '
        Me.lblLoaderPort.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLoaderPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLoaderPort.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLoaderPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLoaderPort.Location = New System.Drawing.Point(804, 434)
        Me.lblLoaderPort.Name = "lblLoaderPort"
        Me.lblLoaderPort.Size = New System.Drawing.Size(163, 30)
        Me.lblLoaderPort.TabIndex = 41
        '
        'lblLoaderCarrier
        '
        Me.lblLoaderCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLoaderCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLoaderCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLoaderCarrier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLoaderCarrier.Location = New System.Drawing.Point(804, 384)
        Me.lblLoaderCarrier.Name = "lblLoaderCarrier"
        Me.lblLoaderCarrier.Size = New System.Drawing.Size(163, 30)
        Me.lblLoaderCarrier.TabIndex = 39
        '
        'lblTtl14
        '
        Me.lblTtl14.BackColor = System.Drawing.Color.Navy
        Me.lblTtl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl14.Location = New System.Drawing.Point(804, 368)
        Me.lblTtl14.Name = "lblTtl14"
        Me.lblTtl14.Size = New System.Drawing.Size(163, 17)
        Me.lblTtl14.TabIndex = 38
        Me.lblTtl14.Text = "LoaderキャリアID"
        Me.lblTtl14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl18
        '
        Me.lblTtl18.BackColor = System.Drawing.Color.Navy
        Me.lblTtl18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl18.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl18.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl18.Location = New System.Drawing.Point(804, 418)
        Me.lblTtl18.Name = "lblTtl18"
        Me.lblTtl18.Size = New System.Drawing.Size(163, 17)
        Me.lblTtl18.TabIndex = 40
        Me.lblTtl18.Text = "Loaderポート№"
        Me.lblTtl18.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblWFNo.TabIndex = 11
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
        Me.lblTtl10.TabIndex = 12
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
        Me.lblTimeLimit.TabIndex = 13
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
        Me.lblTtl9.TabIndex = 20
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
        Me.lblLotManager.TabIndex = 21
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
        Me.lblPdID.TabIndex = 7
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
        Me.lblTtl3.TabIndex = 6
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
        Me.lblTtl5.TabIndex = 10
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
        Me.lblS.TabIndex = 23
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
        Me.lblStartDayTime.TabIndex = 19
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(688, 16)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl4.TabIndex = 18
        Me.lblTtl4.Text = "処理開始日時"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl6.TabIndex = 22
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
        Me.lblTtl2.TabIndex = 14
        Me.lblTtl2.Text = "大工程"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(408, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID.TabIndex = 15
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(408, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 17
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
        Me.lblTtl8.TabIndex = 16
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(484, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 0
        Me.lblLengthCount.Text = "（ 半角2048文字/半角2048文字 ）"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.lblTtl7.TabIndex = 8
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
        Me.lblStatus.TabIndex = 9
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
        Me.lblLotID.TabIndex = 4
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
        Me.lblTtl0.TabIndex = 1
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
        Me.lblFlowClass.TabIndex = 5
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
        Me.lblTtl1.TabIndex = 3
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPort
        '
        Me.lblPort.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPort.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPort.Location = New System.Drawing.Point(500, 140)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(189, 30)
        Me.lblPort.TabIndex = 29
        '
        'lblWP
        '
        Me.lblWP.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWP.Location = New System.Drawing.Point(8, 140)
        Me.lblWP.Name = "lblWP"
        Me.lblWP.Size = New System.Drawing.Size(305, 30)
        Me.lblWP.TabIndex = 25
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.Color.Navy
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl13.Location = New System.Drawing.Point(500, 124)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(189, 17)
        Me.lblTtl13.TabIndex = 28
        Me.lblTtl13.Text = "ポート№"
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(8, 124)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(305, 17)
        Me.lblTtl12.TabIndex = 24
        Me.lblTtl12.Text = "装置名"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(8, 464)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl11.TabIndex = 37
        Me.lblTtl11.Text = "      コメント"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 105)
        Me.lblBack.TabIndex = 0
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Controls.Add(Me.lblLengthCount)
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 368)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl15.TabIndex = 33
        Me.lblTtl15.Text = "      作業メモ"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Navy
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(868, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 17)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "GRB"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblGRB.TabIndex = 43
        '
        'frmxxEN0080
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblGRB)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmdWorkRecord)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdTxtDown)
        Me.Controls.Add(Me.cmdTxtUp)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.cmdCommntInput)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.txtLotCommnt)
        Me.Controls.Add(Me.lblTtl16)
        Me.Controls.Add(Me.lblWpStatusName)
        Me.Controls.Add(Me.lblLoaderPort)
        Me.Controls.Add(Me.lblLoaderCarrier)
        Me.Controls.Add(Me.lblTtl14)
        Me.Controls.Add(Me.lblTtl18)
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
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.lblWP)
        Me.Controls.Add(Me.lblTtl13)
        Me.Controls.Add(Me.lblTtl12)
        Me.Controls.Add(Me.lblTtl11)
        Me.Controls.Add(Me.lblBack)
        Me.Controls.Add(Me.lblTtl15)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0080"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "処理終了　（運用モード：OffLine）"
        Me.lblTtl15.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdWorkRecord As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdTxtDown As Button
    Friend WithEvents cmdTxtUp As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdCommntInput As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents txtLotCommnt As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl16 As Label
    Friend WithEvents lblWpStatusName As Label
    Friend WithEvents lblLoaderPort As Label
    Friend WithEvents lblLoaderCarrier As Label
    Friend WithEvents lblTtl14 As Label
    Friend WithEvents lblTtl18 As Label
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
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblPort As Label
    Friend WithEvents lblWP As Label
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblGRB As Label
End Class
