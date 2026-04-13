<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0030
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0030))
        Me.cmdEasyDivide = New System.Windows.Forms.Button()
        Me.cmdSelectMaterial = New System.Windows.Forms.Button()
        Me.cmdCFCarrierSelect = New System.Windows.Forms.Button()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.cmdCommntInput = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdTxtUp = New System.Windows.Forms.Button()
        Me.cmdTxtDown = New System.Windows.Forms.Button()
        Me.txtOpeCond = New SETextBoxEx.TextBoxEx()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.cmdWFRecp = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdLotStart = New System.Windows.Forms.Button()
        Me.cmdActionDisp = New System.Windows.Forms.Button()
        Me.txtLotCommnt = New SETextBoxEx.TextBoxEx()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.vsfWP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtLoaderCarrier = New SETextBoxEx.TextBoxEx()
        Me.txtCFCarrier = New SETextBoxEx.TextBoxEx()
        Me.lblCFTtl = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblTimeLimit = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblS = New System.Windows.Forms.Label()
        Me.lblStartDayTime = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblWpCnt = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl14 = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.lblRecp = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTtl16 = New System.Windows.Forms.Label()
        Me.lblGRB = New System.Windows.Forms.Label()
        CType(Me.vsfWP,System.ComponentModel.ISupportInitialize).BeginInit
        Me.lblTtl15.SuspendLayout
        Me.SuspendLayout
        '
        'cmdEasyDivide
        '
        Me.cmdEasyDivide.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEasyDivide.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEasyDivide.Location = New System.Drawing.Point(656, 579)
        Me.cmdEasyDivide.Name = "cmdEasyDivide"
        Me.cmdEasyDivide.Size = New System.Drawing.Size(105, 57)
        Me.cmdEasyDivide.TabIndex = 11
        Me.cmdEasyDivide.Text = "簡易分割"
        '
        'cmdSelectMaterial
        '
        Me.cmdSelectMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSelectMaterial.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSelectMaterial.Location = New System.Drawing.Point(764, 579)
        Me.cmdSelectMaterial.Name = "cmdSelectMaterial"
        Me.cmdSelectMaterial.Size = New System.Drawing.Size(105, 57)
        Me.cmdSelectMaterial.TabIndex = 10
        Me.cmdSelectMaterial.Text = "使用部材"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdCFCarrierSelect
        '
        Me.cmdCFCarrierSelect.CausesValidation = false
        Me.cmdCFCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCFCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCFCarrierSelect.Location = New System.Drawing.Point(869, 478)
        Me.cmdCFCarrierSelect.Name = "cmdCFCarrierSelect"
        Me.cmdCFCarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdCFCarrierSelect.TabIndex = 8
        Me.cmdCFCarrierSelect.Text = "CFｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.Enabled = false
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(870, 364)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdCarrierSelect.TabIndex = 6
        Me.cmdCarrierSelect.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdCommntInput
        '
        Me.cmdCommntInput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommntInput.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommntInput.Location = New System.Drawing.Point(332, 579)
        Me.cmdCommntInput.Name = "cmdCommntInput"
        Me.cmdCommntInput.Size = New System.Drawing.Size(105, 57)
        Me.cmdCommntInput.TabIndex = 12
        Me.cmdCommntInput.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(750, 200)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 77)
        Me.cmdDown.TabIndex = 3
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(750, 123)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 77)
        Me.cmdUP.TabIndex = 2
        Me.cmdUP.Text = "▲"
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(750, 367)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoUp.TabIndex = 16
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(750, 411)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 17
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdTxtUp
        '
        Me.cmdTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtUp.Location = New System.Drawing.Point(750, 463)
        Me.cmdTxtUp.Name = "cmdTxtUp"
        Me.cmdTxtUp.Size = New System.Drawing.Size(49, 55)
        Me.cmdTxtUp.TabIndex = 19
        Me.cmdTxtUp.Text = "▲"
        '
        'cmdTxtDown
        '
        Me.cmdTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtDown.Location = New System.Drawing.Point(750, 519)
        Me.cmdTxtDown.Name = "cmdTxtDown"
        Me.cmdTxtDown.Size = New System.Drawing.Size(49, 55)
        Me.cmdTxtDown.TabIndex = 20
        Me.cmdTxtDown.Text = "▼"
        '
        'txtOpeCond
        '
        Me.txtOpeCond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOpeCond.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtOpeCond.ChrMaxByte = 128
        Me.txtOpeCond.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtOpeCond.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtOpeCond.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtOpeCond.Location = New System.Drawing.Point(8, 308)
        Me.txtOpeCond.Name = "txtOpeCond"
        Me.txtOpeCond.NgChr = "'"
        Me.txtOpeCond.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtOpeCond.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOpeCond.SelectedText = ""
        Me.txtOpeCond.Size = New System.Drawing.Size(743, 49)
        Me.txtOpeCond.TabIndex = 14
        Me.txtOpeCond.TabStop = false
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
        Me.txtCarrier.NgChr = "'"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'cmdWFRecp
        '
        Me.cmdWFRecp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFRecp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWFRecp.Location = New System.Drawing.Point(870, 250)
        Me.cmdWFRecp.Name = "cmdWFRecp"
        Me.cmdWFRecp.Size = New System.Drawing.Size(105, 57)
        Me.cmdWFRecp.TabIndex = 4
        Me.cmdWFRecp.Text = "レシピ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"設定変更"
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
        Me.cmdClose.TabIndex = 21
        Me.cmdClose.Text = "閉じる"
        '
        'cmdLotStart
        '
        Me.cmdLotStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotStart.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotStart.Location = New System.Drawing.Point(872, 579)
        Me.cmdLotStart.Name = "cmdLotStart"
        Me.cmdLotStart.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotStart.TabIndex = 9
        Me.cmdLotStart.Text = "確　定"
        '
        'cmdActionDisp
        '
        Me.cmdActionDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdActionDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdActionDisp.Location = New System.Drawing.Point(116, 579)
        Me.cmdActionDisp.Name = "cmdActionDisp"
        Me.cmdActionDisp.Size = New System.Drawing.Size(105, 57)
        Me.cmdActionDisp.TabIndex = 13
        Me.cmdActionDisp.Text = "アクション"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"予約確認"
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
        Me.txtLotCommnt.NgChr = "'"
        Me.txtLotCommnt.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotCommnt.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotCommnt.SelectedText = ""
        Me.txtLotCommnt.Size = New System.Drawing.Size(743, 93)
        Me.txtLotCommnt.TabIndex = 18
        Me.txtLotCommnt.TabStop = false
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
        Me.txtWorkMemo.TabIndex = 15
        '
        'vsfWP
        '
        Me.vsfWP.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWP.AllowEditing = false
        Me.vsfWP.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWP.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfWP.AutoResize = true
        Me.vsfWP.AutoSearchDelay = 2R
        Me.vsfWP.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWP.ColumnInfo = resources.GetString("vsfWP.ColumnInfo")
        Me.vsfWP.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWP.ExtendLastCol = true
        Me.vsfWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWP.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWP.Location = New System.Drawing.Point(8, 124)
        Me.vsfWP.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWP.Name = "vsfWP"
        Me.vsfWP.Rows.DefaultSize = 18
        Me.vsfWP.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfWP.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWP.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfWP.Size = New System.Drawing.Size(743, 152)
        Me.vsfWP.StyleInfo = resources.GetString("vsfWP.StyleInfo")
        Me.vsfWP.TabIndex = 1
        '
        'txtLoaderCarrier
        '
        Me.txtLoaderCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoaderCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLoaderCarrier.ChrMaxByte = 6
        Me.txtLoaderCarrier.Enabled = false
        Me.txtLoaderCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtLoaderCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLoaderCarrier.Location = New System.Drawing.Point(805, 332)
        Me.txtLoaderCarrier.Name = "txtLoaderCarrier"
        Me.txtLoaderCarrier.NgChr = "'"
        Me.txtLoaderCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLoaderCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLoaderCarrier.SelectedText = ""
        Me.txtLoaderCarrier.Size = New System.Drawing.Size(169, 30)
        Me.txtLoaderCarrier.TabIndex = 5
        '
        'txtCFCarrier
        '
        Me.txtCFCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCFCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCFCarrier.ChrMaxByte = 6
        Me.txtCFCarrier.Enabled = false
        Me.txtCFCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCFCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCFCarrier.Location = New System.Drawing.Point(804, 446)
        Me.txtCFCarrier.Name = "txtCFCarrier"
        Me.txtCFCarrier.NgChr = "'"
        Me.txtCFCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCFCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCFCarrier.SelectedText = ""
        Me.txtCFCarrier.Size = New System.Drawing.Size(169, 30)
        Me.txtCFCarrier.TabIndex = 7
        '
        'lblCFTtl
        '
        Me.lblCFTtl.BackColor = System.Drawing.Color.Navy
        Me.lblCFTtl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCFTtl.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCFTtl.ForeColor = System.Drawing.Color.Yellow
        Me.lblCFTtl.Location = New System.Drawing.Point(804, 430)
        Me.lblCFTtl.Name = "lblCFTtl"
        Me.lblCFTtl.Size = New System.Drawing.Size(169, 17)
        Me.lblCFTtl.TabIndex = 54
        Me.lblCFTtl.Text = "CFキャリアID"
        Me.lblCFTtl.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(805, 316)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(169, 17)
        Me.lblTtl11.TabIndex = 53
        Me.lblTtl11.Text = "UnloaderキャリアID"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(312, 32)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
        Me.lblWFNo.TabIndex = 52
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
        Me.lblTtl10.TabIndex = 51
        Me.lblTtl10.Text = "時間制限"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTimeLimit
        '
        Me.lblTimeLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTimeLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTimeLimit.Location = New System.Drawing.Point(312, 80)
        Me.lblTimeLimit.Name = "lblTimeLimit"
        Me.lblTimeLimit.Size = New System.Drawing.Size(97, 25)
        Me.lblTimeLimit.TabIndex = 50
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
        Me.lblTtl9.TabIndex = 49
        Me.lblTtl9.Text = "ロット担当"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotManager
        '
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(688, 80)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(181, 25)
        Me.lblLotManager.TabIndex = 48
        '
        'lblPdID
        '
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(216, 32)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblPdID.TabIndex = 47
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl2.TabIndex = 46
        Me.lblTtl2.Text = "機種"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl5.TabIndex = 45
        Me.lblTtl5.Text = "数量"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblS
        '
        Me.lblS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblS.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblS.Location = New System.Drawing.Point(868, 32)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(97, 25)
        Me.lblS.TabIndex = 44
        '
        'lblStartDayTime
        '
        Me.lblStartDayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDayTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDayTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStartDayTime.Location = New System.Drawing.Point(688, 32)
        Me.lblStartDayTime.Name = "lblStartDayTime"
        Me.lblStartDayTime.Size = New System.Drawing.Size(181, 25)
        Me.lblStartDayTime.TabIndex = 43
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
        Me.lblTtl4.TabIndex = 42
        Me.lblTtl4.Text = "処理開始予定"
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
        Me.lblTtl6.TabIndex = 41
        Me.lblTtl6.Text = "特殊特性"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(408, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl3.TabIndex = 40
        Me.lblTtl3.Text = "大工程"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(408, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID.TabIndex = 39
        '
        'lblStepID
        '
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(408, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 38
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
        Me.lblTtl8.TabIndex = 37
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(216, 80)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblStatus.TabIndex = 36
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
        Me.lblTtl7.TabIndex = 35
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWpCnt
        '
        Me.lblWpCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWpCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWpCnt.Location = New System.Drawing.Point(803, 140)
        Me.lblWpCnt.Name = "lblWpCnt"
        Me.lblWpCnt.Size = New System.Drawing.Size(171, 25)
        Me.lblWpCnt.TabIndex = 34
        Me.lblWpCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(803, 124)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(171, 17)
        Me.lblTitle1.TabIndex = 33
        Me.lblTitle1.Text = "装置件数"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(484, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 31
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl14
        '
        Me.lblTtl14.BackColor = System.Drawing.Color.Navy
        Me.lblTtl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl14.Location = New System.Drawing.Point(8, 464)
        Me.lblTtl14.Name = "lblTtl14"
        Me.lblTtl14.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl14.TabIndex = 30
        Me.lblTtl14.Text = "      コメント"
        Me.lblTtl14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(803, 168)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(171, 17)
        Me.lblTtl12.TabIndex = 29
        Me.lblTtl12.Text = "レシピID"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl1.TabIndex = 27
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 25
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
        Me.lblTtl0.TabIndex = 28
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(16, 80)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 26
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.Color.Navy
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl13.Location = New System.Drawing.Point(8, 292)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl13.TabIndex = 24
        Me.lblTtl13.Text = "      作業条件"
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRecp
        '
        Me.lblRecp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblRecp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecp.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRecp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRecp.Location = New System.Drawing.Point(803, 184)
        Me.lblRecp.Name = "lblRecp"
        Me.lblRecp.Size = New System.Drawing.Size(171, 63)
        Me.lblRecp.TabIndex = 23
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(966, 105)
        Me.lblBack.TabIndex = 22
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
        Me.lblTtl15.TabIndex = 32
        Me.lblTtl15.Text = "      作業メモ"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl16
        '
        Me.lblTtl16.BackColor = System.Drawing.Color.Navy
        Me.lblTtl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl16.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl16.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl16.Location = New System.Drawing.Point(868, 64)
        Me.lblTtl16.Name = "lblTtl16"
        Me.lblTtl16.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl16.TabIndex = 55
        Me.lblTtl16.Text = "GRB"
        Me.lblTtl16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGRB
        '
        Me.lblGRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGRB.Location = New System.Drawing.Point(868, 80)
        Me.lblGRB.Name = "lblGRB"
        Me.lblGRB.Size = New System.Drawing.Size(97, 25)
        Me.lblGRB.TabIndex = 56
        '
        'frmxxEN0030
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblGRB)
        Me.Controls.Add(Me.lblTtl16)
        Me.Controls.Add(Me.cmdEasyDivide)
        Me.Controls.Add(Me.cmdSelectMaterial)
        Me.Controls.Add(Me.cmdCFCarrierSelect)
        Me.Controls.Add(Me.cmdCarrierSelect)
        Me.Controls.Add(Me.cmdCommntInput)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdTxtUp)
        Me.Controls.Add(Me.cmdTxtDown)
        Me.Controls.Add(Me.txtOpeCond)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.cmdWFRecp)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdLotStart)
        Me.Controls.Add(Me.cmdActionDisp)
        Me.Controls.Add(Me.txtLotCommnt)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.vsfWP)
        Me.Controls.Add(Me.txtLoaderCarrier)
        Me.Controls.Add(Me.txtCFCarrier)
        Me.Controls.Add(Me.lblCFTtl)
        Me.Controls.Add(Me.lblTtl11)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblTimeLimit)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblS)
        Me.Controls.Add(Me.lblStartDayTime)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblWpCnt)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTtl14)
        Me.Controls.Add(Me.lblTtl12)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTtl13)
        Me.Controls.Add(Me.lblRecp)
        Me.Controls.Add(Me.lblBack)
        Me.Controls.Add(Me.lblTtl15)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0030"
        Me.Text = "作業開始　（運用モード：OffLine,M1,M2,S1）"
        CType(Me.vsfWP,System.ComponentModel.ISupportInitialize).EndInit
        Me.lblTtl15.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdEasyDivide As Button
    Friend WithEvents cmdSelectMaterial As Button
    Friend WithEvents cmdCFCarrierSelect As Button
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents cmdCommntInput As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdTxtUp As Button
    Friend WithEvents cmdTxtDown As Button
    Friend WithEvents txtOpeCond As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdWFRecp As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdLotStart As Button
    Friend WithEvents cmdActionDisp As Button
    Friend WithEvents txtLotCommnt As SETextBoxEx.TextBoxEx
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfWP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtLoaderCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCFCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblCFTtl As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblTimeLimit As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblS As Label
    Friend WithEvents lblStartDayTime As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblWpCnt As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl14 As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblRecp As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTtl16 As Label
    Friend WithEvents lblGRB As Label
End Class
