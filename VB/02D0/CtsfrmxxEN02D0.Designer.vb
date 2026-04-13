<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02D0
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02D0))
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.fraJig1 = New System.Windows.Forms.Panel()
		Me.txtBcrRead = New SETextBoxEx.TextBoxEx()
		Me.txtPdId = New SETextBoxEx.TextBoxEx()
		Me.cmdNextStockRdy = New System.Windows.Forms.Button()
		Me.cmdJMaskSet = New System.Windows.Forms.Button()
		Me.cmdJJigRegist = New System.Windows.Forms.Button()
		Me.cmdNotUse = New System.Windows.Forms.Button()
		Me.cmdScrap = New System.Windows.Forms.Button()
		Me.cmdJJigWash = New System.Windows.Forms.Button()
		Me.cmdJJigUpdate = New System.Windows.Forms.Button()
		Me.cmdJJigWashComp = New System.Windows.Forms.Button()
		Me.cmdJJigSDown = New System.Windows.Forms.Button()
		Me.cmdJJigSUp = New System.Windows.Forms.Button()
		Me.txtJJigComments = New SETextBoxEx.TextBoxEx()
		Me.lblJJigLengthCount = New System.Windows.Forms.Label()
		Me.lblTitle10 = New System.Windows.Forms.Label()
		Me.vsfJJigList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.cmbJJigStatus = New SEComboBoxEx.ComboBoxEx()
		Me.lblTitle11 = New System.Windows.Forms.Label()
		Me.cmbJJigCategory = New SEComboBoxEx.ComboBoxEx()
		Me.cmdJJigNowList = New System.Windows.Forms.Button()
		Me.lblTitle14 = New System.Windows.Forms.Label()
		Me.lblTitle13 = New System.Windows.Forms.Label()
		Me.lblTitle9 = New System.Windows.Forms.Label()
		Me.lblJJigCnt = New System.Windows.Forms.Label()
		Me.lblTitle8 = New System.Windows.Forms.Label()
		Me.lblJJigNowDate = New System.Windows.Forms.Label()
		Me.lblTitle12 = New System.Windows.Forms.Label()
		Me.tabJIG = New System.Windows.Forms.TabControl()
		Me.fraTab0 = New System.Windows.Forms.TabPage()
		Me.fraJig0 = New System.Windows.Forms.Panel()
		Me.cmdRegist = New System.Windows.Forms.Button()
		Me.cmdJigWash = New System.Windows.Forms.Button()
		Me.cmdUpdate = New System.Windows.Forms.Button()
		Me.cmdJigWashComp = New System.Windows.Forms.Button()
		Me.cmdSDown = New System.Windows.Forms.Button()
		Me.cmdSUp = New System.Windows.Forms.Button()
		Me.txtComments = New SETextBoxEx.TextBoxEx()
		Me.lblLengthCount = New System.Windows.Forms.Label()
		Me.lblTitle3 = New System.Windows.Forms.Label()
		Me.vsfJycJigList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.cmbJigClass = New SEComboBoxEx.ComboBoxEx()
		Me.lblTitle5 = New System.Windows.Forms.Label()
		Me.cmbPanelKind = New SEComboBoxEx.ComboBoxEx()
		Me.cmdNowList = New System.Windows.Forms.Button()
		Me.cmbScreenSize = New SEComboBoxEx.ComboBoxEx()
		Me.lblTitle7 = New System.Windows.Forms.Label()
		Me.lblTitle2 = New System.Windows.Forms.Label()
		Me.lblJigCnt = New System.Windows.Forms.Label()
		Me.lblTitle0 = New System.Windows.Forms.Label()
		Me.lblNowDate = New System.Windows.Forms.Label()
		Me.lblTitle6 = New System.Windows.Forms.Label()
		Me.fraTab1 = New System.Windows.Forms.TabPage()
		Me.fraJig1.SuspendLayout
		CType(Me.vsfJJigList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.tabJIG.SuspendLayout
		Me.fraTab0.SuspendLayout
		Me.fraJig0.SuspendLayout
		CType(Me.vsfJycJigList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.fraTab1.SuspendLayout
		Me.SuspendLayout
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(15, 594)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(85, 40)
		Me.cmdClose.TabIndex = 30
		Me.cmdClose.Text = "閉じる"
		'
		'fraJig1
		'
		Me.fraJig1.Controls.Add(Me.txtBcrRead)
		Me.fraJig1.Controls.Add(Me.txtPdId)
		Me.fraJig1.Controls.Add(Me.cmdNextStockRdy)
		Me.fraJig1.Controls.Add(Me.cmdJMaskSet)
		Me.fraJig1.Controls.Add(Me.cmdJJigRegist)
		Me.fraJig1.Controls.Add(Me.cmdNotUse)
		Me.fraJig1.Controls.Add(Me.cmdScrap)
		Me.fraJig1.Controls.Add(Me.cmdJJigWash)
		Me.fraJig1.Controls.Add(Me.cmdJJigUpdate)
		Me.fraJig1.Controls.Add(Me.cmdJJigWashComp)
		Me.fraJig1.Controls.Add(Me.cmdJJigSDown)
		Me.fraJig1.Controls.Add(Me.cmdJJigSUp)
		Me.fraJig1.Controls.Add(Me.txtJJigComments)
		Me.fraJig1.Controls.Add(Me.lblJJigLengthCount)
		Me.fraJig1.Controls.Add(Me.lblTitle10)
		Me.fraJig1.Controls.Add(Me.vsfJJigList)
		Me.fraJig1.Controls.Add(Me.cmbJJigStatus)
		Me.fraJig1.Controls.Add(Me.lblTitle11)
		Me.fraJig1.Controls.Add(Me.cmbJJigCategory)
		Me.fraJig1.Controls.Add(Me.cmdJJigNowList)
		Me.fraJig1.Controls.Add(Me.lblTitle14)
		Me.fraJig1.Controls.Add(Me.lblTitle13)
		Me.fraJig1.Controls.Add(Me.lblTitle9)
		Me.fraJig1.Controls.Add(Me.lblJJigCnt)
		Me.fraJig1.Controls.Add(Me.lblTitle8)
		Me.fraJig1.Controls.Add(Me.lblJJigNowDate)
		Me.fraJig1.Controls.Add(Me.lblTitle12)
		Me.fraJig1.Location = New System.Drawing.Point(0, 0)
		Me.fraJig1.Name = "fraJig1"
		Me.fraJig1.Size = New System.Drawing.Size(959, 555)
		Me.fraJig1.TabIndex = 69
		Me.fraJig1.Text = "Frame1"
		'
		'txtBcrRead
		'
		Me.txtBcrRead.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtBcrRead.ChrMaxByte = 10
		Me.txtBcrRead.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtBcrRead.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtBcrRead.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtBcrRead.Location = New System.Drawing.Point(459, 22)
		Me.txtBcrRead.Name = "txtBcrRead"
		Me.txtBcrRead.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtBcrRead.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtBcrRead.SelectedText = ""
		Me.txtBcrRead.Size = New System.Drawing.Size(153, 22)
		Me.txtBcrRead.TabIndex = 16
		'
		'txtPdId
		'
		Me.txtPdId.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtPdId.ChrMaxByte = 4
		Me.txtPdId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtPdId.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtPdId.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtPdId.Location = New System.Drawing.Point(273, 22)
		Me.txtPdId.Name = "txtPdId"
		Me.txtPdId.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtPdId.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtPdId.SelectedText = ""
		Me.txtPdId.Size = New System.Drawing.Size(131, 22)
		Me.txtPdId.TabIndex = 15
		'
		'cmdNextStockRdy
		'
		Me.cmdNextStockRdy.CausesValidation = false
		Me.cmdNextStockRdy.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdNextStockRdy.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdNextStockRdy.Location = New System.Drawing.Point(838, 509)
		Me.cmdNextStockRdy.Name = "cmdNextStockRdy"
		Me.cmdNextStockRdy.Size = New System.Drawing.Size(97, 40)
		Me.cmdNextStockRdy.TabIndex = 29
		Me.cmdNextStockRdy.Text = "次回在庫"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"準備完了"
		'
		'cmdJMaskSet
		'
		Me.cmdJMaskSet.CausesValidation = false
		Me.cmdJMaskSet.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJMaskSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJMaskSet.Location = New System.Drawing.Point(735, 509)
		Me.cmdJMaskSet.Name = "cmdJMaskSet"
		Me.cmdJMaskSet.Size = New System.Drawing.Size(97, 40)
		Me.cmdJMaskSet.TabIndex = 28
		Me.cmdJMaskSet.Text = "蒸着マスク組立"
		'
		'cmdJJigRegist
		'
		Me.cmdJJigRegist.CausesValidation = false
		Me.cmdJJigRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJJigRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJJigRegist.Location = New System.Drawing.Point(368, 509)
		Me.cmdJJigRegist.Name = "cmdJJigRegist"
		Me.cmdJJigRegist.Size = New System.Drawing.Size(85, 40)
		Me.cmdJJigRegist.TabIndex = 25
		Me.cmdJJigRegist.Text = "蒸着治具新規登録"
		'
		'cmdNotUse
		'
		Me.cmdNotUse.CausesValidation = false
		Me.cmdNotUse.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdNotUse.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdNotUse.Location = New System.Drawing.Point(459, 509)
		Me.cmdNotUse.Name = "cmdNotUse"
		Me.cmdNotUse.Size = New System.Drawing.Size(85, 40)
		Me.cmdNotUse.TabIndex = 26
		Me.cmdNotUse.Text = "使用不可"
		'
		'cmdScrap
		'
		Me.cmdScrap.CausesValidation = false
		Me.cmdScrap.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdScrap.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdScrap.Location = New System.Drawing.Point(550, 509)
		Me.cmdScrap.Name = "cmdScrap"
		Me.cmdScrap.Size = New System.Drawing.Size(85, 40)
		Me.cmdScrap.TabIndex = 27
		Me.cmdScrap.Text = "廃却"
		'
		'cmdJJigWash
		'
		Me.cmdJJigWash.CausesValidation = false
		Me.cmdJJigWash.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJJigWash.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJJigWash.Location = New System.Drawing.Point(186, 509)
		Me.cmdJJigWash.Name = "cmdJJigWash"
		Me.cmdJJigWash.Size = New System.Drawing.Size(85, 40)
		Me.cmdJJigWash.TabIndex = 23
		Me.cmdJJigWash.Text = "洗浄"
		'
		'cmdJJigUpdate
		'
		Me.cmdJJigUpdate.CausesValidation = false
		Me.cmdJJigUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJJigUpdate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJJigUpdate.Location = New System.Drawing.Point(95, 509)
		Me.cmdJJigUpdate.Name = "cmdJJigUpdate"
		Me.cmdJJigUpdate.Size = New System.Drawing.Size(85, 40)
		Me.cmdJJigUpdate.TabIndex = 22
		Me.cmdJJigUpdate.Text = "治具ﾃﾞｰﾀ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"変更"
		'
		'cmdJJigWashComp
		'
		Me.cmdJJigWashComp.CausesValidation = false
		Me.cmdJJigWashComp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJJigWashComp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJJigWashComp.Location = New System.Drawing.Point(277, 509)
		Me.cmdJJigWashComp.Name = "cmdJJigWashComp"
		Me.cmdJJigWashComp.Size = New System.Drawing.Size(85, 40)
		Me.cmdJJigWashComp.TabIndex = 24
		Me.cmdJJigWashComp.Text = "受入"
		'
		'cmdJJigSDown
		'
		Me.cmdJJigSDown.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJJigSDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJJigSDown.Location = New System.Drawing.Point(934, 467)
		Me.cmdJJigSDown.Name = "cmdJJigSDown"
		Me.cmdJJigSDown.Size = New System.Drawing.Size(25, 37)
		Me.cmdJJigSDown.TabIndex = 21
		Me.cmdJJigSDown.Text = "▼"
		'
		'cmdJJigSUp
		'
		Me.cmdJJigSUp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJJigSUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJJigSUp.Location = New System.Drawing.Point(934, 430)
		Me.cmdJJigSUp.Name = "cmdJJigSUp"
		Me.cmdJJigSUp.Size = New System.Drawing.Size(25, 37)
		Me.cmdJJigSUp.TabIndex = 20
		Me.cmdJJigSUp.Text = "▲"
		'
		'txtJJigComments
		'
		Me.txtJJigComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtJJigComments.ChrMaxByte = 0
		Me.txtJJigComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
		Me.txtJJigComments.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtJJigComments.Location = New System.Drawing.Point(3, 448)
		Me.txtJJigComments.Name = "txtJJigComments"
		Me.txtJJigComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtJJigComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtJJigComments.SelectedText = ""
		Me.txtJJigComments.Size = New System.Drawing.Size(932, 55)
		Me.txtJJigComments.TabIndex = 19
		'
		'lblJJigLengthCount
		'
		Me.lblJJigLengthCount.BackColor = System.Drawing.Color.Navy
		Me.lblJJigLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblJJigLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
		Me.lblJJigLengthCount.Location = New System.Drawing.Point(688, 433)
		Me.lblJJigLengthCount.Name = "lblJJigLengthCount"
		Me.lblJJigLengthCount.Size = New System.Drawing.Size(247, 17)
		Me.lblJJigLengthCount.TabIndex = 50
		Me.lblJJigLengthCount.Text = "( 半角2048文字/半角2048文字 )"
		Me.lblJJigLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle10
		'
		Me.lblTitle10.BackColor = System.Drawing.Color.Navy
		Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle10.Location = New System.Drawing.Point(3, 432)
		Me.lblTitle10.Name = "lblTitle10"
		Me.lblTitle10.Size = New System.Drawing.Size(934, 18)
		Me.lblTitle10.TabIndex = 49
		Me.lblTitle10.Text = "コメント"
		Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'vsfJJigList
		'
		Me.vsfJJigList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfJJigList.AllowEditing = false
		Me.vsfJJigList.AutoSearchDelay = 2R
		Me.vsfJJigList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfJJigList.ColumnInfo = resources.GetString("vsfJJigList.ColumnInfo")
		Me.vsfJJigList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfJJigList.ExtendLastCol = true
		Me.vsfJJigList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfJJigList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfJJigList.Location = New System.Drawing.Point(3, 48)
		Me.vsfJJigList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfJJigList.Name = "vsfJJigList"
		Me.vsfJJigList.Rows.Count = 23
		Me.vsfJJigList.Rows.DefaultSize = 18
		Me.vsfJJigList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfJJigList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfJJigList.Size = New System.Drawing.Size(954, 378)
		Me.vsfJJigList.StyleInfo = resources.GetString("vsfJJigList.StyleInfo")
		Me.vsfJJigList.TabIndex = 18
		'
		'cmbJJigStatus
		'
		Me.cmbJJigStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJJigStatus.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJJigStatus.Location = New System.Drawing.Point(3, 22)
		Me.cmbJJigStatus.Name = "cmbJJigStatus"
		Me.cmbJJigStatus.Size = New System.Drawing.Size(125, 22)
		Me.cmbJJigStatus.TabIndex = 13
		Me.cmbJJigStatus.Value = Nothing
		'
		'lblTitle11
		'
		Me.lblTitle11.BackColor = System.Drawing.Color.Navy
		Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle11.Location = New System.Drawing.Point(3, 6)
		Me.lblTitle11.Name = "lblTitle11"
		Me.lblTitle11.Size = New System.Drawing.Size(125, 17)
		Me.lblTitle11.TabIndex = 40
		Me.lblTitle11.Text = "ステータス"
		Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmbJJigCategory
		'
		Me.cmbJJigCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJJigCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJJigCategory.Location = New System.Drawing.Point(132, 22)
		Me.cmbJJigCategory.Name = "cmbJJigCategory"
		Me.cmbJJigCategory.Size = New System.Drawing.Size(139, 22)
		Me.cmbJJigCategory.TabIndex = 14
		Me.cmbJJigCategory.Value = Nothing
		'
		'cmdJJigNowList
		'
		Me.cmdJJigNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJJigNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJJigNowList.Location = New System.Drawing.Point(656, 5)
		Me.cmdJJigNowList.Name = "cmdJJigNowList"
		Me.cmdJJigNowList.Size = New System.Drawing.Size(85, 40)
		Me.cmdJJigNowList.TabIndex = 17
		Me.cmdJJigNowList.Text = "最新取得"
		'
		'lblTitle14
		'
		Me.lblTitle14.BackColor = System.Drawing.Color.Navy
		Me.lblTitle14.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle14.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle14.Location = New System.Drawing.Point(459, 5)
		Me.lblTitle14.Name = "lblTitle14"
		Me.lblTitle14.Size = New System.Drawing.Size(153, 18)
		Me.lblTitle14.TabIndex = 44
		Me.lblTitle14.Text = "BCR読み取り"
		Me.lblTitle14.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle13
		'
		Me.lblTitle13.BackColor = System.Drawing.Color.Navy
		Me.lblTitle13.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle13.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle13.Location = New System.Drawing.Point(274, 5)
		Me.lblTitle13.Name = "lblTitle13"
		Me.lblTitle13.Size = New System.Drawing.Size(130, 18)
		Me.lblTitle13.TabIndex = 42
		Me.lblTitle13.Text = "機種(部分一致)"
		Me.lblTitle13.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle9
		'
		Me.lblTitle9.BackColor = System.Drawing.Color.Navy
		Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle9.Location = New System.Drawing.Point(875, 6)
		Me.lblTitle9.Name = "lblTitle9"
		Me.lblTitle9.Size = New System.Drawing.Size(74, 17)
		Me.lblTitle9.TabIndex = 46
		Me.lblTitle9.Text = "該当件数"
		Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblJJigCnt
		'
		Me.lblJJigCnt.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblJJigCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblJJigCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblJJigCnt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblJJigCnt.Location = New System.Drawing.Point(875, 22)
		Me.lblJJigCnt.Name = "lblJJigCnt"
		Me.lblJJigCnt.Size = New System.Drawing.Size(74, 22)
		Me.lblJJigCnt.TabIndex = 48
		Me.lblJJigCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle8
		'
		Me.lblTitle8.BackColor = System.Drawing.Color.Navy
		Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle8.Location = New System.Drawing.Point(748, 6)
		Me.lblTitle8.Name = "lblTitle8"
		Me.lblTitle8.Size = New System.Drawing.Size(122, 17)
		Me.lblTitle8.TabIndex = 45
		Me.lblTitle8.Text = "情報取得日時"
		Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblJJigNowDate
		'
		Me.lblJJigNowDate.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblJJigNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblJJigNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblJJigNowDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblJJigNowDate.Location = New System.Drawing.Point(748, 22)
		Me.lblJJigNowDate.Name = "lblJJigNowDate"
		Me.lblJJigNowDate.Size = New System.Drawing.Size(122, 22)
		Me.lblJJigNowDate.TabIndex = 47
		'
		'lblTitle12
		'
		Me.lblTitle12.BackColor = System.Drawing.Color.Navy
		Me.lblTitle12.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle12.Location = New System.Drawing.Point(132, 6)
		Me.lblTitle12.Name = "lblTitle12"
		Me.lblTitle12.Size = New System.Drawing.Size(139, 17)
		Me.lblTitle12.TabIndex = 41
		Me.lblTitle12.Text = "蒸着治具カテゴリ"
		Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'tabJIG
		'
		Me.tabJIG.Controls.Add(Me.fraTab0)
		Me.tabJIG.Controls.Add(Me.fraTab1)
		Me.tabJIG.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.tabJIG.ItemSize = New System.Drawing.Size(320, 21)
		Me.tabJIG.Location = New System.Drawing.Point(10, 8)
		Me.tabJIG.Name = "tabJIG"
		Me.tabJIG.SelectedIndex = 0
		Me.tabJIG.Size = New System.Drawing.Size(965, 581)
		Me.tabJIG.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
		Me.tabJIG.TabIndex = 31
		'
		'fraTab0
		'
		Me.fraTab0.BackColor = System.Drawing.SystemColors.ControlLight
		Me.fraTab0.Controls.Add(Me.fraJig0)
		Me.fraTab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraTab0.ForeColor = System.Drawing.Color.Black
		Me.fraTab0.Location = New System.Drawing.Point(4, 25)
		Me.fraTab0.Margin = New System.Windows.Forms.Padding(0)
		Me.fraTab0.Name = "fraTab0"
		Me.fraTab0.Size = New System.Drawing.Size(957, 552)
		Me.fraTab0.TabIndex = 0
		Me.fraTab0.Text = "平置治具"
		'
		'fraJig0
		'
		Me.fraJig0.Controls.Add(Me.cmdRegist)
		Me.fraJig0.Controls.Add(Me.cmdJigWash)
		Me.fraJig0.Controls.Add(Me.cmdUpdate)
		Me.fraJig0.Controls.Add(Me.cmdJigWashComp)
		Me.fraJig0.Controls.Add(Me.cmdSDown)
		Me.fraJig0.Controls.Add(Me.cmdSUp)
		Me.fraJig0.Controls.Add(Me.txtComments)
		Me.fraJig0.Controls.Add(Me.lblLengthCount)
		Me.fraJig0.Controls.Add(Me.lblTitle3)
		Me.fraJig0.Controls.Add(Me.vsfJycJigList)
		Me.fraJig0.Controls.Add(Me.cmbJigClass)
		Me.fraJig0.Controls.Add(Me.lblTitle5)
		Me.fraJig0.Controls.Add(Me.cmbPanelKind)
		Me.fraJig0.Controls.Add(Me.cmdNowList)
		Me.fraJig0.Controls.Add(Me.cmbScreenSize)
		Me.fraJig0.Controls.Add(Me.lblTitle7)
		Me.fraJig0.Controls.Add(Me.lblTitle2)
		Me.fraJig0.Controls.Add(Me.lblJigCnt)
		Me.fraJig0.Controls.Add(Me.lblTitle0)
		Me.fraJig0.Controls.Add(Me.lblNowDate)
		Me.fraJig0.Controls.Add(Me.lblTitle6)
		Me.fraJig0.Location = New System.Drawing.Point(0, 0)
		Me.fraJig0.Name = "fraJig0"
		Me.fraJig0.Size = New System.Drawing.Size(959, 556)
		Me.fraJig0.TabIndex = 54
		'
		'cmdRegist
		'
		Me.cmdRegist.CausesValidation = false
		Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdRegist.Location = New System.Drawing.Point(381, 509)
		Me.cmdRegist.Name = "cmdRegist"
		Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
		Me.cmdRegist.TabIndex = 11
		Me.cmdRegist.Text = "新規治具"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"登録"
		'
		'cmdJigWash
		'
		Me.cmdJigWash.CausesValidation = false
		Me.cmdJigWash.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJigWash.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJigWash.Location = New System.Drawing.Point(202, 509)
		Me.cmdJigWash.Name = "cmdJigWash"
		Me.cmdJigWash.Size = New System.Drawing.Size(85, 40)
		Me.cmdJigWash.TabIndex = 9
		Me.cmdJigWash.Text = "治具"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"洗浄"
		'
		'cmdUpdate
		'
		Me.cmdUpdate.CausesValidation = false
		Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdUpdate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdUpdate.Location = New System.Drawing.Point(113, 509)
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.cmdUpdate.Size = New System.Drawing.Size(85, 40)
		Me.cmdUpdate.TabIndex = 8
		Me.cmdUpdate.Text = "治具ﾃﾞｰﾀ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"変更"
		'
		'cmdJigWashComp
		'
		Me.cmdJigWashComp.CausesValidation = false
		Me.cmdJigWashComp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJigWashComp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJigWashComp.Location = New System.Drawing.Point(292, 509)
		Me.cmdJigWashComp.Name = "cmdJigWashComp"
		Me.cmdJigWashComp.Size = New System.Drawing.Size(85, 40)
		Me.cmdJigWashComp.TabIndex = 10
		Me.cmdJigWashComp.Text = "治具洗浄完了"
		'
		'cmdSDown
		'
		Me.cmdSDown.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdSDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdSDown.Location = New System.Drawing.Point(925, 467)
		Me.cmdSDown.Name = "cmdSDown"
		Me.cmdSDown.Size = New System.Drawing.Size(25, 37)
		Me.cmdSDown.TabIndex = 7
		Me.cmdSDown.Text = "▼"
		'
		'cmdSUp
		'
		Me.cmdSUp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdSUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdSUp.Location = New System.Drawing.Point(925, 431)
		Me.cmdSUp.Name = "cmdSUp"
		Me.cmdSUp.Size = New System.Drawing.Size(25, 37)
		Me.cmdSUp.TabIndex = 6
		Me.cmdSUp.Text = "▲"
		'
		'txtComments
		'
		Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtComments.ChrMaxByte = 0
		Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
		Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtComments.Location = New System.Drawing.Point(3, 448)
		Me.txtComments.Name = "txtComments"
		Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtComments.SelectedText = ""
		Me.txtComments.Size = New System.Drawing.Size(923, 55)
		Me.txtComments.TabIndex = 5
		'
		'lblLengthCount
		'
		Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
		Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
		Me.lblLengthCount.Location = New System.Drawing.Point(679, 433)
		Me.lblLengthCount.Name = "lblLengthCount"
		Me.lblLengthCount.Size = New System.Drawing.Size(247, 17)
		Me.lblLengthCount.TabIndex = 39
		Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
		Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle3
		'
		Me.lblTitle3.BackColor = System.Drawing.Color.Navy
		Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle3.Location = New System.Drawing.Point(5, 432)
		Me.lblTitle3.Name = "lblTitle3"
		Me.lblTitle3.Size = New System.Drawing.Size(923, 17)
		Me.lblTitle3.TabIndex = 38
		Me.lblTitle3.Text = "コメント"
		Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'vsfJycJigList
		'
		Me.vsfJycJigList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfJycJigList.AllowEditing = false
		Me.vsfJycJigList.AutoSearchDelay = 2R
		Me.vsfJycJigList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfJycJigList.ColumnInfo = resources.GetString("vsfJycJigList.ColumnInfo")
		Me.vsfJycJigList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfJycJigList.ExtendLastCol = true
		Me.vsfJycJigList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfJycJigList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfJycJigList.Location = New System.Drawing.Point(3, 48)
		Me.vsfJycJigList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfJycJigList.Name = "vsfJycJigList"
		Me.vsfJycJigList.Rows.Count = 23
		Me.vsfJycJigList.Rows.DefaultSize = 18
		Me.vsfJycJigList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfJycJigList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfJycJigList.Size = New System.Drawing.Size(954, 378)
		Me.vsfJycJigList.StyleInfo = resources.GetString("vsfJycJigList.StyleInfo")
		Me.vsfJycJigList.TabIndex = 4
		'
		'cmbJigClass
		'
		Me.cmbJigClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJigClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbJigClass.Location = New System.Drawing.Point(3, 22)
		Me.cmbJigClass.Name = "cmbJigClass"
		Me.cmbJigClass.Size = New System.Drawing.Size(125, 22)
		Me.cmbJigClass.TabIndex = 1
		Me.cmbJigClass.Value = Nothing
		'
		'lblTitle5
		'
		Me.lblTitle5.BackColor = System.Drawing.Color.Navy
		Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle5.Location = New System.Drawing.Point(3, 6)
		Me.lblTitle5.Name = "lblTitle5"
		Me.lblTitle5.Size = New System.Drawing.Size(125, 17)
		Me.lblTitle5.TabIndex = 31
		Me.lblTitle5.Text = "治具識別"
		Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmbPanelKind
		'
		Me.cmbPanelKind.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbPanelKind.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbPanelKind.Location = New System.Drawing.Point(132, 22)
		Me.cmbPanelKind.Name = "cmbPanelKind"
		Me.cmbPanelKind.Size = New System.Drawing.Size(125, 22)
		Me.cmbPanelKind.TabIndex = 2
		Me.cmbPanelKind.Value = Nothing
		'
		'cmdNowList
		'
		Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdNowList.Location = New System.Drawing.Point(656, 5)
		Me.cmdNowList.Name = "cmdNowList"
		Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
		Me.cmdNowList.TabIndex = 0
		Me.cmdNowList.Text = "最新取得"
		'
		'cmbScreenSize
		'
		Me.cmbScreenSize.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbScreenSize.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbScreenSize.Location = New System.Drawing.Point(259, 22)
		Me.cmbScreenSize.Name = "cmbScreenSize"
		Me.cmbScreenSize.Size = New System.Drawing.Size(145, 22)
		Me.cmbScreenSize.TabIndex = 3
		Me.cmbScreenSize.Value = Nothing
		'
		'lblTitle7
		'
		Me.lblTitle7.BackColor = System.Drawing.Color.Navy
		Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle7.Location = New System.Drawing.Point(259, 6)
		Me.lblTitle7.Name = "lblTitle7"
		Me.lblTitle7.Size = New System.Drawing.Size(145, 17)
		Me.lblTitle7.TabIndex = 33
		Me.lblTitle7.Text = "スクリーンサイズ"
		Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle2
		'
		Me.lblTitle2.BackColor = System.Drawing.Color.Navy
		Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle2.Location = New System.Drawing.Point(875, 6)
		Me.lblTitle2.Name = "lblTitle2"
		Me.lblTitle2.Size = New System.Drawing.Size(74, 17)
		Me.lblTitle2.TabIndex = 35
		Me.lblTitle2.Text = "該当件数"
		Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblJigCnt
		'
		Me.lblJigCnt.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblJigCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblJigCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblJigCnt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblJigCnt.Location = New System.Drawing.Point(875, 22)
		Me.lblJigCnt.Name = "lblJigCnt"
		Me.lblJigCnt.Size = New System.Drawing.Size(74, 22)
		Me.lblJigCnt.TabIndex = 37
		Me.lblJigCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle0
		'
		Me.lblTitle0.BackColor = System.Drawing.Color.Navy
		Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle0.Location = New System.Drawing.Point(748, 6)
		Me.lblTitle0.Name = "lblTitle0"
		Me.lblTitle0.Size = New System.Drawing.Size(122, 17)
		Me.lblTitle0.TabIndex = 34
		Me.lblTitle0.Text = "情報取得日時"
		Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNowDate
		'
		Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate.Location = New System.Drawing.Point(748, 22)
		Me.lblNowDate.Name = "lblNowDate"
		Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
		Me.lblNowDate.TabIndex = 36
		'
		'lblTitle6
		'
		Me.lblTitle6.BackColor = System.Drawing.Color.Navy
		Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle6.Location = New System.Drawing.Point(132, 6)
		Me.lblTitle6.Name = "lblTitle6"
		Me.lblTitle6.Size = New System.Drawing.Size(125, 17)
		Me.lblTitle6.TabIndex = 32
		Me.lblTitle6.Text = "パネル識別"
		Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'fraTab1
		'
		Me.fraTab1.BackColor = System.Drawing.SystemColors.ControlLight
		Me.fraTab1.Controls.Add(Me.fraJig1)
		Me.fraTab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraTab1.ForeColor = System.Drawing.Color.Black
		Me.fraTab1.Location = New System.Drawing.Point(4, 25)
		Me.fraTab1.Margin = New System.Windows.Forms.Padding(0)
		Me.fraTab1.Name = "fraTab1"
		Me.fraTab1.Size = New System.Drawing.Size(957, 552)
		Me.fraTab1.TabIndex = 1
		Me.fraTab1.Text = "蒸着治具"
		'
		'frmxxEN02D0
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.ClientSize = New System.Drawing.Size(985, 642)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.tabJIG)
		Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN02D0"
		Me.Text = "蒸着治具管理"
		Me.fraJig1.ResumeLayout(false)
		CType(Me.vsfJJigList,System.ComponentModel.ISupportInitialize).EndInit
		Me.tabJIG.ResumeLayout(false)
		Me.fraTab0.ResumeLayout(false)
		Me.fraJig0.ResumeLayout(false)
		CType(Me.vsfJycJigList,System.ComponentModel.ISupportInitialize).EndInit
		Me.fraTab1.ResumeLayout(false)
		Me.ResumeLayout(false)

End Sub
	Friend WithEvents cmdClose As Button
	Friend WithEvents fraJig1 As Panel
	Friend WithEvents tabJIG As TabControl
	Friend WithEvents fraTab0 As TabPage
	Friend WithEvents fraJig0 As Panel
	Friend WithEvents fraTab1 As TabPage
	Friend WithEvents cmbJigClass As SEComboBoxEx.ComboBoxEx
	Friend WithEvents lblTitle5 As Label
	Friend WithEvents cmbPanelKind As SEComboBoxEx.ComboBoxEx
	Friend WithEvents cmdNowList As Button
	Friend WithEvents cmbScreenSize As SEComboBoxEx.ComboBoxEx
	Friend WithEvents lblTitle7 As Label
	Friend WithEvents lblTitle2 As Label
	Friend WithEvents lblJigCnt As Label
	Friend WithEvents lblTitle0 As Label
	Friend WithEvents lblNowDate As Label
	Friend WithEvents lblTitle6 As Label
	Friend WithEvents vsfJycJigList As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents cmdSDown As Button
	Friend WithEvents cmdSUp As Button
	Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
	Friend WithEvents lblLengthCount As Label
	Friend WithEvents lblTitle3 As Label
	Friend WithEvents cmdJJigRegist As Button
	Friend WithEvents cmdJJigWash As Button
	Friend WithEvents cmdJJigUpdate As Button
	Friend WithEvents cmdJJigWashComp As Button
	Friend WithEvents cmdJJigSDown As Button
	Friend WithEvents cmdJJigSUp As Button
	Friend WithEvents txtJJigComments As SETextBoxEx.TextBoxEx
	Friend WithEvents lblJJigLengthCount As Label
	Friend WithEvents lblTitle10 As Label
	Friend WithEvents vsfJJigList As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents cmbJJigStatus As SEComboBoxEx.ComboBoxEx
	Friend WithEvents lblTitle11 As Label
	Friend WithEvents cmbJJigCategory As SEComboBoxEx.ComboBoxEx
	Friend WithEvents cmdJJigNowList As Button
	Friend WithEvents lblTitle13 As Label
	Friend WithEvents lblTitle9 As Label
	Friend WithEvents lblJJigCnt As Label
	Friend WithEvents lblTitle8 As Label
	Friend WithEvents lblJJigNowDate As Label
	Friend WithEvents lblTitle12 As Label
	Friend WithEvents cmdRegist As Button
	Friend WithEvents cmdJigWash As Button
	Friend WithEvents cmdUpdate As Button
	Friend WithEvents cmdJigWashComp As Button
	Friend WithEvents cmdNotUse As Button
	Friend WithEvents cmdScrap As Button
	Friend WithEvents cmdNextStockRdy As Button
	Friend WithEvents cmdJMaskSet As Button
	Friend WithEvents txtPdId As SETextBoxEx.TextBoxEx
	Friend WithEvents txtBcrRead As SETextBoxEx.TextBoxEx
	Friend WithEvents lblTitle14 As Label
End Class
