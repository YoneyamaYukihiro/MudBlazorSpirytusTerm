<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01X1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01X1))
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.fraSearch = New System.Windows.Forms.Panel()
        Me.optSearch2 = New System.Windows.Forms.RadioButton()
        Me.cmbFlowClass = New SECmbIchiran.ComboIchiran()
        Me.fraKisyu = New System.Windows.Forms.Panel()
        Me.optFlowClass1 = New System.Windows.Forms.RadioButton()
        Me.optFlowClass0 = New System.Windows.Forms.RadioButton()
        Me.optSearch0 = New System.Windows.Forms.RadioButton()
        Me.optSearch1 = New System.Windows.Forms.RadioButton()
        Me.txtLotID = New SETextBoxEx.TextBoxEx()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.cmbPD = New SECmbIchiran.ComboIchiran()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblGetInfoDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblListCnt = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.fraSearch.SuspendLayout
        Me.fraKisyu.SuspendLayout
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(910, 538)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(25, 57)
        Me.cmdDown.TabIndex = 14
        Me.cmdDown.Text = "▼"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp.Location = New System.Drawing.Point(910, 479)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(25, 57)
        Me.cmdUp.TabIndex = 13
        Me.cmdUp.Text = "▲"
        '
        'fraSearch
        '
        Me.fraSearch.Controls.Add(Me.optSearch2)
        Me.fraSearch.Controls.Add(Me.cmbFlowClass)
        Me.fraSearch.Controls.Add(Me.fraKisyu)
        Me.fraSearch.Controls.Add(Me.optSearch0)
        Me.fraSearch.Controls.Add(Me.optSearch1)
        Me.fraSearch.Controls.Add(Me.txtLotID)
        Me.fraSearch.Controls.Add(Me.txtCarrierID)
        Me.fraSearch.Controls.Add(Me.cmbPD)
        Me.fraSearch.Controls.Add(Me.lblTitle3)
        Me.fraSearch.Controls.Add(Me.lblTitle0)
        Me.fraSearch.Controls.Add(Me.lblTitle1)
        Me.fraSearch.Controls.Add(Me.lblTitle8)
        Me.fraSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSearch.Location = New System.Drawing.Point(8, 8)
        Me.fraSearch.Name = "fraSearch"
        Me.fraSearch.Size = New System.Drawing.Size(769, 53)
        Me.fraSearch.TabIndex = 0
        '
        'optSearch2
        '
        Me.optSearch2.Checked = true
        Me.optSearch2.Location = New System.Drawing.Point(592, 16)
        Me.optSearch2.Name = "optSearch2"
        Me.optSearch2.Size = New System.Drawing.Size(17, 25)
        Me.optSearch2.TabIndex = 7
        Me.optSearch2.TabStop = true
        '
        'cmbFlowClass
        '
        Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.Location = New System.Drawing.Point(167, 24)
        Me.cmbFlowClass.Name = "cmbFlowClass"
        Me.cmbFlowClass.Size = New System.Drawing.Size(125, 22)
        Me.cmbFlowClass.TabIndex = 3
        Me.cmbFlowClass.Value = Nothing
        '
        'fraKisyu
        '
        Me.fraKisyu.Controls.Add(Me.optFlowClass1)
        Me.fraKisyu.Controls.Add(Me.optFlowClass0)
        Me.fraKisyu.Location = New System.Drawing.Point(303, 0)
        Me.fraKisyu.Name = "fraKisyu"
        Me.fraKisyu.Size = New System.Drawing.Size(94, 57)
        Me.fraKisyu.TabIndex = 23
        '
        'optFlowClass1
        '
        Me.optFlowClass1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optFlowClass1.Location = New System.Drawing.Point(6, 32)
        Me.optFlowClass1.Name = "optFlowClass1"
        Me.optFlowClass1.Size = New System.Drawing.Size(78, 18)
        Me.optFlowClass1.TabIndex = 5
        Me.optFlowClass1.Text = "流動中"
        '
        'optFlowClass0
        '
        Me.optFlowClass0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optFlowClass0.Location = New System.Drawing.Point(6, 8)
        Me.optFlowClass0.Name = "optFlowClass0"
        Me.optFlowClass0.Size = New System.Drawing.Size(78, 18)
        Me.optFlowClass0.TabIndex = 4
        Me.optFlowClass0.Text = "流動前"
        '
        'optSearch0
        '
        Me.optSearch0.Location = New System.Drawing.Point(15, 16)
        Me.optSearch0.Name = "optSearch0"
        Me.optSearch0.Size = New System.Drawing.Size(17, 25)
        Me.optSearch0.TabIndex = 0
        '
        'optSearch1
        '
        Me.optSearch1.Location = New System.Drawing.Point(397, 16)
        Me.optSearch1.Name = "optSearch1"
        Me.optSearch1.Size = New System.Drawing.Size(19, 25)
        Me.optSearch1.TabIndex = 1
        '
        'txtLotID
        '
        Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLotID.ChrMaxByte = 10
        Me.txtLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotID.Location = New System.Drawing.Point(422, 24)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotID.SelectedText = ""
        Me.txtLotID.Size = New System.Drawing.Size(155, 22)
        Me.txtLotID.TabIndex = 6
        '
        'txtCarrierID
        '
        Me.txtCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID.ChrMaxByte = 6
        Me.txtCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID.Location = New System.Drawing.Point(614, 24)
        Me.txtCarrierID.Name = "txtCarrierID"
        Me.txtCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID.SelectedText = ""
        Me.txtCarrierID.Size = New System.Drawing.Size(152, 22)
        Me.txtCarrierID.TabIndex = 8
        '
        'cmbPD
        '
        Me.cmbPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridForeColor = System.Drawing.Color.Black
        Me.cmbPD.Location = New System.Drawing.Point(39, 24)
        Me.cmbPD.Name = "cmbPD"
        Me.cmbPD.Size = New System.Drawing.Size(126, 22)
        Me.cmbPD.TabIndex = 2
        Me.cmbPD.Value = Nothing
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(614, 8)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(152, 17)
        Me.lblTitle3.TabIndex = 28
        Me.lblTitle3.Text = "キャリアID"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(39, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(126, 17)
        Me.lblTitle0.TabIndex = 25
        Me.lblTitle0.Text = "機種"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(167, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle1.TabIndex = 24
        Me.lblTitle1.Text = "種別"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(422, 8)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(155, 17)
        Me.lblTitle8.TabIndex = 22
        Me.lblTitle8.Text = "ロットID(前方一致)"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 597)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 11
        Me.cmdRegist.Text = "確　定"
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(688, 65)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSearch.TabIndex = 9
        Me.cmdSearch.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(7, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "閉じる"
        '
        'vsfLotList
        '
        Me.vsfLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotList.AllowEditing = false
        Me.vsfLotList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotList.AutoSearchDelay = 2R
        Me.vsfLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotList.ColumnInfo = resources.GetString("vsfLotList.ColumnInfo")
        Me.vsfLotList.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.vsfLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotList.ExtendLastCol = true
        Me.vsfLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotList.Location = New System.Drawing.Point(8, 110)
        Me.vsfLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotList.Name = "vsfLotList"
        Me.vsfLotList.Rows.Count = 4
        Me.vsfLotList.Rows.DefaultSize = 18
        Me.vsfLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfLotList.Size = New System.Drawing.Size(963, 363)
        Me.vsfLotList.StyleInfo = resources.GetString("vsfLotList.StyleInfo")
        Me.vsfLotList.TabIndex = 10
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 0
        Me.txtComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtComments.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtComments.GotHighLight = false
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtComments.Location = New System.Drawing.Point(8, 496)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(902, 98)
        Me.txtComments.TabIndex = 12
        Me.txtComments.TabStop = false
        '
        'lblTitleChip
        '
        Me.lblTitleChip.AutoSize = true
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(412, 86)
        Me.lblTitleChip.Name = "lblTitleChip"
        Me.lblTitleChip.Size = New System.Drawing.Size(106, 18)
        Me.lblTitleChip.TabIndex = 30
        Me.lblTitleChip.Text = "青字：Chip品"
        Me.lblTitleChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleChip.UseMnemonic = false
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 480)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(902, 17)
        Me.lblTtl15.TabIndex = 29
        Me.lblTtl15.Text = "コメント"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleL
        '
        Me.lblTitleL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleL.ForeColor = System.Drawing.Color.Black
        Me.lblTitleL.Location = New System.Drawing.Point(516, 86)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(43, 18)
        Me.lblTitleL.TabIndex = 27
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(558, 86)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(43, 18)
        Me.lblTitleR.TabIndex = 26
        Me.lblTitleR.Text = "R"
        Me.lblTitleR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleR.UseMnemonic = false
        '
        'lblGetInfoDate
        '
        Me.lblGetInfoDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGetInfoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGetInfoDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGetInfoDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGetInfoDate.Location = New System.Drawing.Point(777, 82)
        Me.lblGetInfoDate.Name = "lblGetInfoDate"
        Me.lblGetInfoDate.Size = New System.Drawing.Size(121, 22)
        Me.lblGetInfoDate.TabIndex = 20
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(777, 67)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle4.TabIndex = 19
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblListCnt
        '
        Me.lblListCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblListCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblListCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblListCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblListCnt.Location = New System.Drawing.Point(899, 82)
        Me.lblListCnt.Name = "lblListCnt"
        Me.lblListCnt.Size = New System.Drawing.Size(75, 22)
        Me.lblListCnt.TabIndex = 18
        Me.lblListCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(899, 67)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(75, 17)
        Me.lblTitle2.TabIndex = 17
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(598, 86)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(81, 18)
        Me.lblTitleHT.TabIndex = 16
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01X1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.fraSearch)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfLotList)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.lblTitleChip)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.lblTitleL)
        Me.Controls.Add(Me.lblTitleR)
        Me.Controls.Add(Me.lblGetInfoDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblListCnt)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01X1"
        Me.Text = "ロット一覧"
        Me.fraSearch.ResumeLayout(false)
        Me.fraKisyu.ResumeLayout(false)
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents fraSearch As Panel
    Friend WithEvents optSearch2 As RadioButton
    Friend WithEvents cmbFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents fraKisyu As Panel
    Friend WithEvents optFlowClass1 As RadioButton
    Friend WithEvents optFlowClass0 As RadioButton
    Friend WithEvents optSearch0 As RadioButton
    Friend WithEvents optSearch1 As RadioButton
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbPD As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblGetInfoDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblListCnt As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitleHT As Label
End Class
