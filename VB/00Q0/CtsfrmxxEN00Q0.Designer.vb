<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00Q0
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00Q0))
		Me.cmdChangeSendSB = New System.Windows.Forms.Button()
		Me.tabSelect = New System.Windows.Forms.TabControl()
		Me.Tab0 = New System.Windows.Forms.TabPage()
		Me.fraTftThrowIn = New System.Windows.Forms.GroupBox()
		Me.Frame3 = New System.Windows.Forms.Panel()
		Me.cmbTftFlowClass = New SECmbIchiran.ComboIchiran()
		Me.cmbTftProduct = New SEComboBoxEx.ComboBoxEx()
		Me.lblTitle13 = New System.Windows.Forms.Label()
		Me.lblTitle12 = New System.Windows.Forms.Label()
		Me.lblTitleR = New System.Windows.Forms.Label()
		Me.lblTitleL = New System.Windows.Forms.Label()
		Me.Tab1 = New System.Windows.Forms.TabPage()
		Me.fraOdfThrowIn = New System.Windows.Forms.GroupBox()
		Me.Frame2 = New System.Windows.Forms.Panel()
		Me.cmbOdfFlowClass = New SECmbIchiran.ComboIchiran()
		Me.cmbOdfProduct = New SEComboBoxEx.ComboBoxEx()
		Me.lblTitle18 = New System.Windows.Forms.Label()
		Me.lblTitle17 = New System.Windows.Forms.Label()
		Me.Tab2 = New System.Windows.Forms.TabPage()
		Me.fraThrowIn = New System.Windows.Forms.GroupBox()
		Me.fraOption = New System.Windows.Forms.Panel()
		Me.optThrowUser1 = New System.Windows.Forms.RadioButton()
		Me.optThrowUser0 = New System.Windows.Forms.RadioButton()
		Me.fraPDEntry = New System.Windows.Forms.GroupBox()
		Me.cmdEntry = New System.Windows.Forms.Button()
		Me.lblEntryID = New System.Windows.Forms.Label()
		Me.lblTitle10 = New System.Windows.Forms.Label()
		Me.lblTitle8 = New System.Windows.Forms.Label()
		Me.lblEntry = New System.Windows.Forms.Label()
		Me.fraUserEntry = New System.Windows.Forms.GroupBox()
		Me.cmdUserEntry = New System.Windows.Forms.Button()
		Me.txtUserEntry = New SETextBoxEx.TextBoxEx()
		Me.lblUserEntry = New System.Windows.Forms.Label()
		Me.lblTitle11 = New System.Windows.Forms.Label()
		Me.lblTitle1 = New System.Windows.Forms.Label()
		Me.cmbFlowClass = New SECmbIchiran.ComboIchiran()
		Me.cmbProduct = New SEComboBoxEx.ComboBoxEx()
		Me.cmbChipElectric = New SECmbIchiran.ComboIchiran()
		Me.lblTitle14 = New System.Windows.Forms.Label()
		Me.lblTitle9 = New System.Windows.Forms.Label()
		Me.lblTitle7 = New System.Windows.Forms.Label()
		Me.lblTitle0 = New System.Windows.Forms.Label()
		Me.lblEntryBack = New System.Windows.Forms.Label()
		Me.cmdComments = New System.Windows.Forms.Button()
		Me.fraTFT = New System.Windows.Forms.GroupBox()
		Me.txtCarrier = New SETextBoxEx.TextBoxEx()
		Me.lblTtl0 = New System.Windows.Forms.Label()
		Me.cmdDown = New System.Windows.Forms.Button()
		Me.cmdUp = New System.Windows.Forms.Button()
		Me.cmdLotList = New System.Windows.Forms.Button()
		Me.vsfLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.lblTitleLotChip = New System.Windows.Forms.Label()
		Me.lblTFTProduct = New System.Windows.Forms.Label()
		Me.lblTitle3 = New System.Windows.Forms.Label()
		Me.lblNowDate = New System.Windows.Forms.Label()
		Me.lblTitle4 = New System.Windows.Forms.Label()
		Me.lblLotCnt = New System.Windows.Forms.Label()
		Me.lblTitle5 = New System.Windows.Forms.Label()
		Me.cmdMemoDown = New System.Windows.Forms.Button()
		Me.cmdMemoUp = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.cmdLotMake = New System.Windows.Forms.Button()
		Me.cmdClear = New System.Windows.Forms.Button()
		Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
		Me.cmbPrioSel = New SECmbIchiran.ComboIchiran()
		Me.cmbLotManager = New SECmbIchiran.ComboIchiran()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblTtl4 = New System.Windows.Forms.Label()
		Me.lblTitle2 = New System.Windows.Forms.Label()
		Me.lblLengthCount = New System.Windows.Forms.Label()
		Me.lblTitle6 = New System.Windows.Forms.Label()
		Me.tabSelect.SuspendLayout
		Me.Tab0.SuspendLayout
		Me.fraTftThrowIn.SuspendLayout
		Me.Tab1.SuspendLayout
		Me.fraOdfThrowIn.SuspendLayout
		Me.Tab2.SuspendLayout
		Me.fraThrowIn.SuspendLayout
		Me.fraOption.SuspendLayout
		Me.fraPDEntry.SuspendLayout
		Me.fraUserEntry.SuspendLayout
		Me.fraTFT.SuspendLayout
		CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'cmdChangeSendSB
		'
		Me.cmdChangeSendSB.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdChangeSendSB.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdChangeSendSB.Location = New System.Drawing.Point(548, 581)
		Me.cmdChangeSendSB.Name = "cmdChangeSendSB"
		Me.cmdChangeSendSB.Size = New System.Drawing.Size(105, 57)
		Me.cmdChangeSendSB.TabIndex = 65
		Me.cmdChangeSendSB.Text = "送品先"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"変更"
		'
		'tabSelect
		'
		Me.tabSelect.Controls.Add(Me.Tab0)
		Me.tabSelect.Controls.Add(Me.Tab1)
		Me.tabSelect.Controls.Add(Me.Tab2)
		Me.tabSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.tabSelect.ItemSize = New System.Drawing.Size(154, 34)
		Me.tabSelect.Location = New System.Drawing.Point(8, 8)
		Me.tabSelect.Name = "tabSelect"
		Me.tabSelect.SelectedIndex = 0
		Me.tabSelect.Size = New System.Drawing.Size(467, 469)
		Me.tabSelect.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
		Me.tabSelect.TabIndex = 0
		'
		'Tab0
		'
		Me.Tab0.BackColor = System.Drawing.SystemColors.ControlLight
		Me.Tab0.Controls.Add(Me.fraTftThrowIn)
		Me.Tab0.Controls.Add(Me.lblTitleR)
		Me.Tab0.Controls.Add(Me.lblTitleL)
		Me.Tab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.Tab0.ForeColor = System.Drawing.Color.Black
		Me.Tab0.Location = New System.Drawing.Point(4, 38)
		Me.Tab0.Margin = New System.Windows.Forms.Padding(0)
		Me.Tab0.Name = "Tab0"
		Me.Tab0.Size = New System.Drawing.Size(459, 427)
		Me.Tab0.TabIndex = 0
		Me.Tab0.Text = "量産/ES(TFT)"
		'
		'fraTftThrowIn
		'
		Me.fraTftThrowIn.Controls.Add(Me.Frame3)
		Me.fraTftThrowIn.Controls.Add(Me.cmbTftFlowClass)
		Me.fraTftThrowIn.Controls.Add(Me.cmbTftProduct)
		Me.fraTftThrowIn.Controls.Add(Me.lblTitle13)
		Me.fraTftThrowIn.Controls.Add(Me.lblTitle12)
		Me.fraTftThrowIn.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraTftThrowIn.Location = New System.Drawing.Point(8, 4)
		Me.fraTftThrowIn.Name = "fraTftThrowIn"
		Me.fraTftThrowIn.Size = New System.Drawing.Size(441, 76)
		Me.fraTftThrowIn.TabIndex = 59
		Me.fraTftThrowIn.TabStop = false
		Me.fraTftThrowIn.Text = "投入ロット情報"
		'
		'Frame3
		'
		Me.Frame3.Location = New System.Drawing.Point(16, 104)
		Me.Frame3.Name = "Frame3"
		Me.Frame3.Size = New System.Drawing.Size(17, 285)
		Me.Frame3.TabIndex = 60
		'
		'cmbTftFlowClass
		'
		Me.cmbTftFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbTftFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbTftFlowClass.GridForeColor = System.Drawing.Color.Black
		Me.cmbTftFlowClass.Location = New System.Drawing.Point(196, 36)
		Me.cmbTftFlowClass.Name = "cmbTftFlowClass"
		Me.cmbTftFlowClass.Size = New System.Drawing.Size(169, 28)
		Me.cmbTftFlowClass.TabIndex = 2
		Me.cmbTftFlowClass.Value = Nothing
		'
		'cmbTftProduct
		'
		Me.cmbTftProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbTftProduct.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbTftProduct.Location = New System.Drawing.Point(12, 36)
		Me.cmbTftProduct.Name = "cmbTftProduct"
		Me.cmbTftProduct.Size = New System.Drawing.Size(169, 28)
		Me.cmbTftProduct.TabIndex = 1
		Me.cmbTftProduct.Value = Nothing
		'
		'lblTitle13
		'
		Me.lblTitle13.BackColor = System.Drawing.Color.Navy
		Me.lblTitle13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle13.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle13.Location = New System.Drawing.Point(196, 20)
		Me.lblTitle13.Name = "lblTitle13"
		Me.lblTitle13.Size = New System.Drawing.Size(169, 17)
		Me.lblTitle13.TabIndex = 62
		Me.lblTitle13.Text = "投入種別"
		Me.lblTitle13.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle12
		'
		Me.lblTitle12.BackColor = System.Drawing.Color.Navy
		Me.lblTitle12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle12.Location = New System.Drawing.Point(12, 20)
		Me.lblTitle12.Name = "lblTitle12"
		Me.lblTitle12.Size = New System.Drawing.Size(169, 17)
		Me.lblTitle12.TabIndex = 61
		Me.lblTitle12.Text = "投入機種"
		Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitleR
		'
		Me.lblTitleR.AutoSize = true
		Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
		Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitleR.ForeColor = System.Drawing.Color.Black
		Me.lblTitleR.Location = New System.Drawing.Point(-4638, 48)
		Me.lblTitleR.Name = "lblTitleR"
		Me.lblTitleR.Size = New System.Drawing.Size(17, 18)
		Me.lblTitleR.TabIndex = 39
		Me.lblTitleR.Text = "R"
		Me.lblTitleR.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblTitleR.UseMnemonic = false
		'
		'lblTitleL
		'
		Me.lblTitleL.AutoSize = true
		Me.lblTitleL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
		Me.lblTitleL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitleL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitleL.ForeColor = System.Drawing.Color.Black
		Me.lblTitleL.Location = New System.Drawing.Point(-4682, 48)
		Me.lblTitleL.Name = "lblTitleL"
		Me.lblTitleL.Size = New System.Drawing.Size(17, 18)
		Me.lblTitleL.TabIndex = 38
		Me.lblTitleL.Text = "L"
		Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblTitleL.UseMnemonic = false
		'
		'Tab1
		'
		Me.Tab1.BackColor = System.Drawing.SystemColors.ControlLight
		Me.Tab1.Controls.Add(Me.fraOdfThrowIn)
		Me.Tab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.Tab1.ForeColor = System.Drawing.Color.Black
		Me.Tab1.Location = New System.Drawing.Point(4, 38)
		Me.Tab1.Margin = New System.Windows.Forms.Padding(0)
		Me.Tab1.Name = "Tab1"
		Me.Tab1.Size = New System.Drawing.Size(459, 427)
		Me.Tab1.TabIndex = 1
		Me.Tab1.Text = "量産/ES(ODF)"
		'
		'fraOdfThrowIn
		'
		Me.fraOdfThrowIn.Controls.Add(Me.Frame2)
		Me.fraOdfThrowIn.Controls.Add(Me.cmbOdfFlowClass)
		Me.fraOdfThrowIn.Controls.Add(Me.cmbOdfProduct)
		Me.fraOdfThrowIn.Controls.Add(Me.lblTitle18)
		Me.fraOdfThrowIn.Controls.Add(Me.lblTitle17)
		Me.fraOdfThrowIn.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraOdfThrowIn.Location = New System.Drawing.Point(8, 4)
		Me.fraOdfThrowIn.Name = "fraOdfThrowIn"
		Me.fraOdfThrowIn.Size = New System.Drawing.Size(441, 76)
		Me.fraOdfThrowIn.TabIndex = 55
		Me.fraOdfThrowIn.TabStop = false
		Me.fraOdfThrowIn.Text = "投入ロット情報"
		'
		'Frame2
		'
		Me.Frame2.Location = New System.Drawing.Point(16, 104)
		Me.Frame2.Name = "Frame2"
		Me.Frame2.Size = New System.Drawing.Size(17, 285)
		Me.Frame2.TabIndex = 56
		'
		'cmbOdfFlowClass
		'
		Me.cmbOdfFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbOdfFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbOdfFlowClass.GridForeColor = System.Drawing.Color.Black
		Me.cmbOdfFlowClass.Location = New System.Drawing.Point(196, 36)
		Me.cmbOdfFlowClass.Name = "cmbOdfFlowClass"
		Me.cmbOdfFlowClass.Size = New System.Drawing.Size(169, 28)
		Me.cmbOdfFlowClass.TabIndex = 4
		Me.cmbOdfFlowClass.Value = Nothing
		'
		'cmbOdfProduct
		'
		Me.cmbOdfProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbOdfProduct.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbOdfProduct.Location = New System.Drawing.Point(12, 36)
		Me.cmbOdfProduct.Name = "cmbOdfProduct"
		Me.cmbOdfProduct.Size = New System.Drawing.Size(169, 28)
		Me.cmbOdfProduct.TabIndex = 3
		Me.cmbOdfProduct.Value = Nothing
		'
		'lblTitle18
		'
		Me.lblTitle18.BackColor = System.Drawing.Color.Navy
		Me.lblTitle18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle18.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle18.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle18.Location = New System.Drawing.Point(12, 20)
		Me.lblTitle18.Name = "lblTitle18"
		Me.lblTitle18.Size = New System.Drawing.Size(169, 17)
		Me.lblTitle18.TabIndex = 58
		Me.lblTitle18.Text = "投入機種"
		Me.lblTitle18.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle17
		'
		Me.lblTitle17.BackColor = System.Drawing.Color.Navy
		Me.lblTitle17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle17.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle17.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle17.Location = New System.Drawing.Point(196, 20)
		Me.lblTitle17.Name = "lblTitle17"
		Me.lblTitle17.Size = New System.Drawing.Size(169, 17)
		Me.lblTitle17.TabIndex = 57
		Me.lblTitle17.Text = "投入種別"
		Me.lblTitle17.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Tab2
		'
		Me.Tab2.BackColor = System.Drawing.SystemColors.ControlLight
		Me.Tab2.Controls.Add(Me.fraThrowIn)
		Me.Tab2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.Tab2.ForeColor = System.Drawing.Color.Black
		Me.Tab2.Location = New System.Drawing.Point(4, 38)
		Me.Tab2.Margin = New System.Windows.Forms.Padding(0)
		Me.Tab2.Name = "Tab2"
		Me.Tab2.Size = New System.Drawing.Size(459, 427)
		Me.Tab2.TabIndex = 2
		Me.Tab2.Text = "試作／実験"
		'
		'fraThrowIn
		'
		Me.fraThrowIn.Controls.Add(Me.fraOption)
		Me.fraThrowIn.Controls.Add(Me.fraPDEntry)
		Me.fraThrowIn.Controls.Add(Me.fraUserEntry)
		Me.fraThrowIn.Controls.Add(Me.cmbFlowClass)
		Me.fraThrowIn.Controls.Add(Me.cmbProduct)
		Me.fraThrowIn.Controls.Add(Me.cmbChipElectric)
		Me.fraThrowIn.Controls.Add(Me.lblTitle14)
		Me.fraThrowIn.Controls.Add(Me.lblTitle9)
		Me.fraThrowIn.Controls.Add(Me.lblTitle7)
		Me.fraThrowIn.Controls.Add(Me.lblTitle0)
		Me.fraThrowIn.Controls.Add(Me.lblEntryBack)
		Me.fraThrowIn.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraThrowIn.Location = New System.Drawing.Point(8, 4)
		Me.fraThrowIn.Name = "fraThrowIn"
		Me.fraThrowIn.Size = New System.Drawing.Size(441, 409)
		Me.fraThrowIn.TabIndex = 40
		Me.fraThrowIn.TabStop = false
		Me.fraThrowIn.Text = "投入ロット情報"
		'
		'fraOption
		'
		Me.fraOption.Controls.Add(Me.optThrowUser1)
		Me.fraOption.Controls.Add(Me.optThrowUser0)
		Me.fraOption.Location = New System.Drawing.Point(16, 104)
		Me.fraOption.Name = "fraOption"
		Me.fraOption.Size = New System.Drawing.Size(17, 285)
		Me.fraOption.TabIndex = 8
		'
		'optThrowUser1
		'
		Me.optThrowUser1.Location = New System.Drawing.Point(4, 156)
		Me.optThrowUser1.Name = "optThrowUser1"
		Me.optThrowUser1.Size = New System.Drawing.Size(21, 121)
		Me.optThrowUser1.TabIndex = 10
		'
		'optThrowUser0
		'
		Me.optThrowUser0.Location = New System.Drawing.Point(4, 12)
		Me.optThrowUser0.Name = "optThrowUser0"
		Me.optThrowUser0.Size = New System.Drawing.Size(21, 117)
		Me.optThrowUser0.TabIndex = 8
		'
		'fraPDEntry
		'
		Me.fraPDEntry.Controls.Add(Me.cmdEntry)
		Me.fraPDEntry.Controls.Add(Me.lblEntryID)
		Me.fraPDEntry.Controls.Add(Me.lblTitle10)
		Me.fraPDEntry.Controls.Add(Me.lblTitle8)
		Me.fraPDEntry.Controls.Add(Me.lblEntry)
		Me.fraPDEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraPDEntry.Location = New System.Drawing.Point(40, 100)
		Me.fraPDEntry.Name = "fraPDEntry"
		Me.fraPDEntry.Size = New System.Drawing.Size(381, 141)
		Me.fraPDEntry.TabIndex = 9
		Me.fraPDEntry.TabStop = false
		Me.fraPDEntry.Text = "マスタ工順"
		'
		'cmdEntry
		'
		Me.cmdEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdEntry.Location = New System.Drawing.Point(268, 20)
		Me.cmdEntry.Name = "cmdEntry"
		Me.cmdEntry.Size = New System.Drawing.Size(105, 57)
		Me.cmdEntry.TabIndex = 9
		Me.cmdEntry.Text = "エントリ"
		'
		'lblEntryID
		'
		Me.lblEntryID.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblEntryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblEntryID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblEntryID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblEntryID.Location = New System.Drawing.Point(8, 36)
		Me.lblEntryID.Name = "lblEntryID"
		Me.lblEntryID.Size = New System.Drawing.Size(253, 29)
		Me.lblEntryID.TabIndex = 49
		'
		'lblTitle10
		'
		Me.lblTitle10.BackColor = System.Drawing.Color.Navy
		Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle10.Location = New System.Drawing.Point(8, 20)
		Me.lblTitle10.Name = "lblTitle10"
		Me.lblTitle10.Size = New System.Drawing.Size(253, 17)
		Me.lblTitle10.TabIndex = 48
		Me.lblTitle10.Text = "エントリ"
		Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle8
		'
		Me.lblTitle8.BackColor = System.Drawing.Color.Navy
		Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle8.Location = New System.Drawing.Point(8, 84)
		Me.lblTitle8.Name = "lblTitle8"
		Me.lblTitle8.Size = New System.Drawing.Size(365, 17)
		Me.lblTitle8.TabIndex = 47
		Me.lblTitle8.Text = "エントリ名"
		Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblEntry
		'
		Me.lblEntry.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblEntry.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblEntry.Location = New System.Drawing.Point(8, 100)
		Me.lblEntry.Name = "lblEntry"
		Me.lblEntry.Size = New System.Drawing.Size(365, 29)
		Me.lblEntry.TabIndex = 46
		'
		'fraUserEntry
		'
		Me.fraUserEntry.Controls.Add(Me.cmdUserEntry)
		Me.fraUserEntry.Controls.Add(Me.txtUserEntry)
		Me.fraUserEntry.Controls.Add(Me.lblUserEntry)
		Me.fraUserEntry.Controls.Add(Me.lblTitle11)
		Me.fraUserEntry.Controls.Add(Me.lblTitle1)
		Me.fraUserEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraUserEntry.Location = New System.Drawing.Point(40, 248)
		Me.fraUserEntry.Name = "fraUserEntry"
		Me.fraUserEntry.Size = New System.Drawing.Size(381, 141)
		Me.fraUserEntry.TabIndex = 11
		Me.fraUserEntry.TabStop = false
		Me.fraUserEntry.Text = "ユーザーエントリ"
		'
		'cmdUserEntry
		'
		Me.cmdUserEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdUserEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdUserEntry.Location = New System.Drawing.Point(268, 20)
		Me.cmdUserEntry.Name = "cmdUserEntry"
		Me.cmdUserEntry.Size = New System.Drawing.Size(105, 57)
		Me.cmdUserEntry.TabIndex = 12
		Me.cmdUserEntry.Text = "ユーザー"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"プロセス"
		'
		'txtUserEntry
		'
		Me.txtUserEntry.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtUserEntry.ChrMaxByte = 0
		Me.txtUserEntry.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
		Me.txtUserEntry.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtUserEntry.Location = New System.Drawing.Point(8, 36)
		Me.txtUserEntry.Name = "txtUserEntry"
		Me.txtUserEntry.NgChr = "'"
		Me.txtUserEntry.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtUserEntry.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtUserEntry.SelectedText = ""
		Me.txtUserEntry.Size = New System.Drawing.Size(253, 30)
		Me.txtUserEntry.TabIndex = 11
		'
		'lblUserEntry
		'
		Me.lblUserEntry.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblUserEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblUserEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblUserEntry.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblUserEntry.Location = New System.Drawing.Point(8, 100)
		Me.lblUserEntry.Name = "lblUserEntry"
		Me.lblUserEntry.Size = New System.Drawing.Size(365, 29)
		Me.lblUserEntry.TabIndex = 44
		'
		'lblTitle11
		'
		Me.lblTitle11.BackColor = System.Drawing.Color.Navy
		Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle11.Location = New System.Drawing.Point(8, 20)
		Me.lblTitle11.Name = "lblTitle11"
		Me.lblTitle11.Size = New System.Drawing.Size(253, 17)
		Me.lblTitle11.TabIndex = 43
		Me.lblTitle11.Text = "ユーザープロセスID"
		Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle1
		'
		Me.lblTitle1.BackColor = System.Drawing.Color.Navy
		Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle1.Location = New System.Drawing.Point(8, 84)
		Me.lblTitle1.Name = "lblTitle1"
		Me.lblTitle1.Size = New System.Drawing.Size(365, 17)
		Me.lblTitle1.TabIndex = 42
		Me.lblTitle1.Text = "ユーザープロセス名"
		Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmbFlowClass
		'
		Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbFlowClass.GridForeColor = System.Drawing.Color.Black
		Me.cmbFlowClass.Location = New System.Drawing.Point(154, 36)
		Me.cmbFlowClass.Name = "cmbFlowClass"
		Me.cmbFlowClass.Size = New System.Drawing.Size(133, 28)
		Me.cmbFlowClass.TabIndex = 6
		Me.cmbFlowClass.Value = Nothing
		'
		'cmbProduct
		'
		Me.cmbProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbProduct.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbProduct.Location = New System.Drawing.Point(12, 36)
		Me.cmbProduct.Name = "cmbProduct"
		Me.cmbProduct.Size = New System.Drawing.Size(133, 28)
		Me.cmbProduct.TabIndex = 5
		Me.cmbProduct.Value = Nothing
		'
		'cmbChipElectric
		'
		Me.cmbChipElectric.Enabled = false
		Me.cmbChipElectric.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbChipElectric.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbChipElectric.GridForeColor = System.Drawing.Color.Black
		Me.cmbChipElectric.Location = New System.Drawing.Point(297, 36)
		Me.cmbChipElectric.Name = "cmbChipElectric"
		Me.cmbChipElectric.Size = New System.Drawing.Size(133, 28)
		Me.cmbChipElectric.TabIndex = 7
		Me.cmbChipElectric.Value = Nothing
		Me.cmbChipElectric.Visible = false
		'
		'lblTitle14
		'
		Me.lblTitle14.BackColor = System.Drawing.Color.Navy
		Me.lblTitle14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle14.Enabled = false
		Me.lblTitle14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle14.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle14.Location = New System.Drawing.Point(297, 20)
		Me.lblTitle14.Name = "lblTitle14"
		Me.lblTitle14.Size = New System.Drawing.Size(133, 17)
		Me.lblTitle14.TabIndex = 63
		Me.lblTitle14.Text = "チップ電特"
		Me.lblTitle14.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblTitle14.Visible = false
		'
		'lblTitle9
		'
		Me.lblTitle9.BackColor = System.Drawing.Color.Navy
		Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle9.Location = New System.Drawing.Point(12, 76)
		Me.lblTitle9.Name = "lblTitle9"
		Me.lblTitle9.Size = New System.Drawing.Size(417, 17)
		Me.lblTitle9.TabIndex = 54
		Me.lblTitle9.Text = "エントリ情報"
		Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblTitle9.UseMnemonic = false
		'
		'lblTitle7
		'
		Me.lblTitle7.BackColor = System.Drawing.Color.Navy
		Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle7.Location = New System.Drawing.Point(154, 20)
		Me.lblTitle7.Name = "lblTitle7"
		Me.lblTitle7.Size = New System.Drawing.Size(133, 17)
		Me.lblTitle7.TabIndex = 53
		Me.lblTitle7.Text = "投入種別"
		Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle0
		'
		Me.lblTitle0.BackColor = System.Drawing.Color.Navy
		Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle0.Location = New System.Drawing.Point(12, 20)
		Me.lblTitle0.Name = "lblTitle0"
		Me.lblTitle0.Size = New System.Drawing.Size(133, 17)
		Me.lblTitle0.TabIndex = 52
		Me.lblTitle0.Text = "投入機種"
		Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblEntryBack
		'
		Me.lblEntryBack.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblEntryBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblEntryBack.Location = New System.Drawing.Point(12, 92)
		Me.lblEntryBack.Name = "lblEntryBack"
		Me.lblEntryBack.Size = New System.Drawing.Size(417, 305)
		Me.lblEntryBack.TabIndex = 51
		'
		'cmdComments
		'
		Me.cmdComments.CausesValidation = false
		Me.cmdComments.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdComments.Location = New System.Drawing.Point(656, 581)
		Me.cmdComments.Name = "cmdComments"
		Me.cmdComments.Size = New System.Drawing.Size(105, 57)
		Me.cmdComments.TabIndex = 19
		Me.cmdComments.Text = "コメント"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
		'
		'fraTFT
		'
		Me.fraTFT.Controls.Add(Me.txtCarrier)
		Me.fraTFT.Controls.Add(Me.lblTtl0)
		Me.fraTFT.Controls.Add(Me.cmdDown)
		Me.fraTFT.Controls.Add(Me.cmdUp)
		Me.fraTFT.Controls.Add(Me.cmdLotList)
		Me.fraTFT.Controls.Add(Me.vsfLotList)
		Me.fraTFT.Controls.Add(Me.lblTitleLotChip)
		Me.fraTFT.Controls.Add(Me.lblTFTProduct)
		Me.fraTFT.Controls.Add(Me.lblTitle3)
		Me.fraTFT.Controls.Add(Me.lblNowDate)
		Me.fraTFT.Controls.Add(Me.lblTitle4)
		Me.fraTFT.Controls.Add(Me.lblLotCnt)
		Me.fraTFT.Controls.Add(Me.lblTitle5)
		Me.fraTFT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraTFT.Location = New System.Drawing.Point(480, 8)
		Me.fraTFT.Name = "fraTFT"
		Me.fraTFT.Size = New System.Drawing.Size(497, 430)
		Me.fraTFT.TabIndex = 13
		Me.fraTFT.TabStop = false
		Me.fraTFT.Text = "在庫情報"
		'
		'txtCarrier
		'
		Me.txtCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtCarrier.ChrMaxByte = 6
		Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtCarrier.Location = New System.Drawing.Point(12, 90)
		Me.txtCarrier.Name = "txtCarrier"
		Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtCarrier.SelectedText = ""
		Me.txtCarrier.Size = New System.Drawing.Size(143, 30)
		Me.txtCarrier.TabIndex = 65
		'
		'lblTtl0
		'
		Me.lblTtl0.BackColor = System.Drawing.Color.Navy
		Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl0.Location = New System.Drawing.Point(12, 75)
		Me.lblTtl0.Name = "lblTtl0"
		Me.lblTtl0.Size = New System.Drawing.Size(143, 17)
		Me.lblTtl0.TabIndex = 66
		Me.lblTtl0.Text = "キャリアID"
		Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmdDown
		'
		Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdDown.Location = New System.Drawing.Point(436, 275)
		Me.cmdDown.Name = "cmdDown"
		Me.cmdDown.Size = New System.Drawing.Size(49, 153)
		Me.cmdDown.TabIndex = 15
		Me.cmdDown.Text = "▼"
		'
		'cmdUp
		'
		Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdUp.Location = New System.Drawing.Point(436, 123)
		Me.cmdUp.Name = "cmdUp"
		Me.cmdUp.Size = New System.Drawing.Size(49, 153)
		Me.cmdUp.TabIndex = 14
		Me.cmdUp.Text = "▲"
		'
		'cmdLotList
		'
		Me.cmdLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdLotList.Location = New System.Drawing.Point(176, 22)
		Me.cmdLotList.Name = "cmdLotList"
		Me.cmdLotList.Size = New System.Drawing.Size(105, 57)
		Me.cmdLotList.TabIndex = 21
		Me.cmdLotList.Text = "最新取得"
		'
		'vsfLotList
		'
		Me.vsfLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfLotList.AllowEditing = false
		Me.vsfLotList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfLotList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfLotList.AutoResize = true
		Me.vsfLotList.AutoSearchDelay = 2R
		Me.vsfLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfLotList.ColumnInfo = resources.GetString("vsfLotList.ColumnInfo")
		Me.vsfLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfLotList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfLotList.Location = New System.Drawing.Point(12, 124)
		Me.vsfLotList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfLotList.Name = "vsfLotList"
		Me.vsfLotList.Rows.Count = 25
		Me.vsfLotList.Rows.DefaultSize = 18
		Me.vsfLotList.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfLotList.Size = New System.Drawing.Size(422, 303)
		Me.vsfLotList.StyleInfo = resources.GetString("vsfLotList.StyleInfo")
		Me.vsfLotList.TabIndex = 13
		'
		'lblTitleLotChip
		'
		Me.lblTitleLotChip.AutoSize = true
		Me.lblTitleLotChip.BackColor = System.Drawing.Color.White
		Me.lblTitleLotChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitleLotChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitleLotChip.ForeColor = System.Drawing.Color.Blue
		Me.lblTitleLotChip.Location = New System.Drawing.Point(380, 101)
		Me.lblTitleLotChip.Name = "lblTitleLotChip"
		Me.lblTitleLotChip.Size = New System.Drawing.Size(105, 18)
		Me.lblTitleLotChip.TabIndex = 64
		Me.lblTitleLotChip.Text = "青字：Chip品"
		Me.lblTitleLotChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.lblTitleLotChip.UseMnemonic = false
		'
		'lblTFTProduct
		'
		Me.lblTFTProduct.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblTFTProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTFTProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTFTProduct.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblTFTProduct.Location = New System.Drawing.Point(12, 39)
		Me.lblTFTProduct.Name = "lblTFTProduct"
		Me.lblTFTProduct.Size = New System.Drawing.Size(143, 29)
		Me.lblTFTProduct.TabIndex = 34
		'
		'lblTitle3
		'
		Me.lblTitle3.BackColor = System.Drawing.Color.Navy
		Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle3.Location = New System.Drawing.Point(12, 23)
		Me.lblTitle3.Name = "lblTitle3"
		Me.lblTitle3.Size = New System.Drawing.Size(143, 17)
		Me.lblTitle3.TabIndex = 33
		Me.lblTitle3.Text = "親機種"
		Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNowDate
		'
		Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate.Location = New System.Drawing.Point(299, 38)
		Me.lblNowDate.Name = "lblNowDate"
		Me.lblNowDate.Size = New System.Drawing.Size(186, 30)
		Me.lblNowDate.TabIndex = 32
		'
		'lblTitle4
		'
		Me.lblTitle4.BackColor = System.Drawing.Color.Navy
		Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle4.Location = New System.Drawing.Point(299, 22)
		Me.lblTitle4.Name = "lblTitle4"
		Me.lblTitle4.Size = New System.Drawing.Size(186, 18)
		Me.lblTitle4.TabIndex = 31
		Me.lblTitle4.Text = "情報取得日時"
		Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblLotCnt
		'
		Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblLotCnt.Location = New System.Drawing.Point(299, 94)
		Me.lblLotCnt.Name = "lblLotCnt"
		Me.lblLotCnt.Size = New System.Drawing.Size(74, 25)
		Me.lblLotCnt.TabIndex = 30
		Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle5
		'
		Me.lblTitle5.BackColor = System.Drawing.Color.Navy
		Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle5.Location = New System.Drawing.Point(299, 78)
		Me.lblTitle5.Name = "lblTitle5"
		Me.lblTitle5.Size = New System.Drawing.Size(74, 17)
		Me.lblTitle5.TabIndex = 29
		Me.lblTitle5.Text = "該当件数"
		Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmdMemoDown
		'
		Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdMemoDown.Location = New System.Drawing.Point(751, 535)
		Me.cmdMemoDown.Name = "cmdMemoDown"
		Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
		Me.cmdMemoDown.TabIndex = 24
		Me.cmdMemoDown.Text = "▼"
		'
		'cmdMemoUp
		'
		Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdMemoUp.Location = New System.Drawing.Point(751, 491)
		Me.cmdMemoUp.Name = "cmdMemoUp"
		Me.cmdMemoUp.Size = New System.Drawing.Size(49, 43)
		Me.cmdMemoUp.TabIndex = 23
		Me.cmdMemoUp.Text = "▲"
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
		Me.cmdClose.TabIndex = 25
		Me.cmdClose.Text = "閉じる"
		'
		'cmdLotMake
		'
		Me.cmdLotMake.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdLotMake.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdLotMake.Location = New System.Drawing.Point(872, 581)
		Me.cmdLotMake.Name = "cmdLotMake"
		Me.cmdLotMake.Size = New System.Drawing.Size(105, 57)
		Me.cmdLotMake.TabIndex = 18
		Me.cmdLotMake.Text = "確　定"
		'
		'cmdClear
		'
		Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClear.Location = New System.Drawing.Point(764, 581)
		Me.cmdClear.Name = "cmdClear"
		Me.cmdClear.Size = New System.Drawing.Size(105, 57)
		Me.cmdClear.TabIndex = 20
		Me.cmdClear.Text = "全部取消"
		'
		'txtWorkMemo
		'
		Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtWorkMemo.ChrMaxByte = 0
		Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
		Me.txtWorkMemo.GotHighLight = false
		Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtWorkMemo.Location = New System.Drawing.Point(8, 508)
		Me.txtWorkMemo.MultiLineEx = true
		Me.txtWorkMemo.Name = "txtWorkMemo"
		Me.txtWorkMemo.NgChr = "'"
		Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtWorkMemo.SelectedText = ""
		Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
		Me.txtWorkMemo.TabIndex = 22
		'
		'cmbPrioSel
		'
		Me.cmbPrioSel.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbPrioSel.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbPrioSel.GridForeColor = System.Drawing.Color.Black
		Me.cmbPrioSel.Location = New System.Drawing.Point(480, 457)
		Me.cmbPrioSel.Name = "cmbPrioSel"
		Me.cmbPrioSel.Size = New System.Drawing.Size(169, 28)
		Me.cmbPrioSel.TabIndex = 16
		Me.cmbPrioSel.Value = Nothing
		'
		'cmbLotManager
		'
		Me.cmbLotManager.DirectInput = false
		Me.cmbLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbLotManager.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbLotManager.Location = New System.Drawing.Point(656, 457)
		Me.cmbLotManager.Name = "cmbLotManager"
		Me.cmbLotManager.Size = New System.Drawing.Size(197, 28)
		Me.cmbLotManager.TabIndex = 17
		Me.cmbLotManager.Value = Nothing
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Red
		Me.Label1.Location = New System.Drawing.Point(128, 589)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(243, 43)
		Me.Label1.TabIndex = 37
		Me.Label1.Text = """量産ES(TFT)""タブを表示してチェックインしてください"
		Me.Label1.Visible = false
		'
		'lblTtl4
		'
		Me.lblTtl4.BackColor = System.Drawing.Color.Navy
		Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl4.Location = New System.Drawing.Point(656, 441)
		Me.lblTtl4.Name = "lblTtl4"
		Me.lblTtl4.Size = New System.Drawing.Size(197, 17)
		Me.lblTtl4.TabIndex = 36
		Me.lblTtl4.Text = "ロット担当"
		Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle2
		'
		Me.lblTitle2.BackColor = System.Drawing.Color.Navy
		Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle2.Location = New System.Drawing.Point(480, 441)
		Me.lblTitle2.Name = "lblTitle2"
		Me.lblTitle2.Size = New System.Drawing.Size(169, 17)
		Me.lblTitle2.TabIndex = 35
		Me.lblTitle2.Text = "優先度"
		Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblLengthCount
		'
		Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
		Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
		Me.lblLengthCount.Location = New System.Drawing.Point(485, 493)
		Me.lblLengthCount.Name = "lblLengthCount"
		Me.lblLengthCount.Size = New System.Drawing.Size(263, 15)
		Me.lblLengthCount.TabIndex = 26
		Me.lblLengthCount.Text = "　（半角2048文字/半角2048文字）"
		Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle6
		'
		Me.lblTitle6.BackColor = System.Drawing.Color.Navy
		Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle6.Location = New System.Drawing.Point(8, 492)
		Me.lblTitle6.Name = "lblTitle6"
		Me.lblTitle6.Size = New System.Drawing.Size(743, 17)
		Me.lblTitle6.TabIndex = 27
		Me.lblTitle6.Text = "      作業メモ"
		Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'frmxxEN00Q0
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(985, 642)
		Me.Controls.Add(Me.cmdChangeSendSB)
		Me.Controls.Add(Me.tabSelect)
		Me.Controls.Add(Me.cmdComments)
		Me.Controls.Add(Me.fraTFT)
		Me.Controls.Add(Me.cmdMemoDown)
		Me.Controls.Add(Me.cmdMemoUp)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.cmdLotMake)
		Me.Controls.Add(Me.cmdClear)
		Me.Controls.Add(Me.txtWorkMemo)
		Me.Controls.Add(Me.cmbPrioSel)
		Me.Controls.Add(Me.cmbLotManager)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.lblTtl4)
		Me.Controls.Add(Me.lblTitle2)
		Me.Controls.Add(Me.lblLengthCount)
		Me.Controls.Add(Me.lblTitle6)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN00Q0"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "ロット投入（組立）"
		Me.tabSelect.ResumeLayout(false)
		Me.Tab0.ResumeLayout(false)
		Me.Tab0.PerformLayout
		Me.fraTftThrowIn.ResumeLayout(false)
		Me.Tab1.ResumeLayout(false)
		Me.fraOdfThrowIn.ResumeLayout(false)
		Me.Tab2.ResumeLayout(false)
		Me.fraThrowIn.ResumeLayout(false)
		Me.fraOption.ResumeLayout(false)
		Me.fraPDEntry.ResumeLayout(false)
		Me.fraUserEntry.ResumeLayout(false)
		Me.fraTFT.ResumeLayout(false)
		Me.fraTFT.PerformLayout
		CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdChangeSendSB As Button
    Friend WithEvents tabSelect As TabControl
    Friend WithEvents Tab0 As TabPage
    Friend WithEvents fraTftThrowIn As GroupBox
    Friend WithEvents Frame3 As Panel
    Friend WithEvents cmbTftFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbTftProduct As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle13 As Label
    Friend WithEvents lblTitle12 As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents Tab1 As TabPage
    Friend WithEvents fraOdfThrowIn As GroupBox
    Friend WithEvents Frame2 As Panel
    Friend WithEvents cmbOdfFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbOdfProduct As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle18 As Label
    Friend WithEvents lblTitle17 As Label
    Friend WithEvents Tab2 As TabPage
    Friend WithEvents fraThrowIn As GroupBox
    Friend WithEvents fraOption As Panel
    Friend WithEvents optThrowUser1 As RadioButton
    Friend WithEvents optThrowUser0 As RadioButton
    Friend WithEvents fraPDEntry As GroupBox
    Friend WithEvents cmdEntry As Button
    Friend WithEvents lblEntryID As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblEntry As Label
    Friend WithEvents fraUserEntry As GroupBox
    Friend WithEvents cmdUserEntry As Button
    Friend WithEvents txtUserEntry As SETextBoxEx.TextBoxEx
    Friend WithEvents lblUserEntry As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents cmbFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbProduct As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbChipElectric As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTitle14 As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblEntryBack As Label
    Friend WithEvents cmdComments As Button
    Friend WithEvents fraTFT As GroupBox
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdLotList As Button
    Friend WithEvents vsfLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleLotChip As Label
    Friend WithEvents lblTFTProduct As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdLotMake As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbPrioSel As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbLotManager As SECmbIchiran.ComboIchiran
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle6 As Label
	Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
	Friend WithEvents lblTtl0 As Label
End Class
