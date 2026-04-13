<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00C0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00C0))
        Me.cmdCarrierUnload = New System.Windows.Forms.Button()
        Me.cmdChangeChamber = New System.Windows.Forms.Button()
        Me.cmdChamberDown = New System.Windows.Forms.Button()
        Me.cmdChamberUP = New System.Windows.Forms.Button()
        Me.cmdChangeProcOrder = New System.Windows.Forms.Button()
        Me.picDownAllowRecipeFlow = New System.Windows.Forms.PictureBox()
        Me.cmdChangeTrnst = New System.Windows.Forms.Button()
        Me.chkMessage = New System.Windows.Forms.CheckBox()
        Me.cmdUseChange = New System.Windows.Forms.Button()
        Me.picDownAllow = New System.Windows.Forms.PictureBox()
        Me.cmdWorkMemoUp = New System.Windows.Forms.Button()
        Me.cmdWorkMemoDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdExecution = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfModeList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbMcGroup = New SECmbIchiran.ComboIchiran()
        Me.cmbWp = New SECmbIchiran.ComboIchiran()
        Me.vsfPortNoList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.cmbUseName = New SECmbIchiran.ComboIchiran()
        Me.cmbRecipeFlow = New SECmbIchiran.ComboIchiran()
        Me.txtRecipeFlowNum = New SETextBoxEx.TextBoxEx()
        Me.vsfChamberList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbRecipeGroup = New SECmbIchiran.ComboIchiran()
        Me.lblBeforeRecipeFlowNum = New System.Windows.Forms.Label()
        Me.lblBeforeRecipeFlow = New System.Windows.Forms.Label()
        Me.lblBeforeRecipeFlowTitle = New System.Windows.Forms.Label()
        Me.lblAfterRecipeFlowTitle = New System.Windows.Forms.Label()
        Me.lblUseNameTitle = New System.Windows.Forms.Label()
        Me.lblUseName = New System.Windows.Forms.Label()
        Me.lblCmbUseNameTitle = New System.Windows.Forms.Label()
        Me.lblBeforeModeTitle = New System.Windows.Forms.Label()
        Me.lblBeforeMode = New System.Windows.Forms.Label()
        Me.lblReleaseLengthCount = New System.Windows.Forms.Label()
        Me.lblWpIDTitle = New System.Windows.Forms.Label()
        Me.lblMcGroupNameTitle = New System.Windows.Forms.Label()
        Me.lblNowDateTitle = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblM1AfterMode = New System.Windows.Forms.Label()
        Me.lblM1AfterModeTitle = New System.Windows.Forms.Label()
        Me.lblWpStatusName = New System.Windows.Forms.Label()
        Me.lblWpStatusNameTitle = New System.Windows.Forms.Label()
        Me.lblWorkMemoTitle = New System.Windows.Forms.Label()
        CType(Me.picDownAllowRecipeFlow,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picDownAllow,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfModeList,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfPortNoList,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfChamberList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.lblWorkMemoTitle.SuspendLayout
        Me.SuspendLayout
        '
        'cmdCarrierUnload
        '
        Me.cmdCarrierUnload.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierUnload.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierUnload.Location = New System.Drawing.Point(224, 581)
        Me.cmdCarrierUnload.Name = "cmdCarrierUnload"
        Me.cmdCarrierUnload.Size = New System.Drawing.Size(105, 57)
        Me.cmdCarrierUnload.TabIndex = 24
        Me.cmdCarrierUnload.Text = "キャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"強制搬出"
        '
        'cmdChangeChamber
        '
        Me.cmdChangeChamber.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChangeChamber.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChangeChamber.Location = New System.Drawing.Point(440, 581)
        Me.cmdChangeChamber.Name = "cmdChangeChamber"
        Me.cmdChangeChamber.Size = New System.Drawing.Size(105, 57)
        Me.cmdChangeChamber.TabIndex = 22
        Me.cmdChangeChamber.Text = "処理部用途"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"／状態変更"
        '
        'cmdChamberDown
        '
        Me.cmdChamberDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChamberDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChamberDown.Location = New System.Drawing.Point(739, 372)
        Me.cmdChamberDown.Name = "cmdChamberDown"
        Me.cmdChamberDown.Size = New System.Drawing.Size(49, 91)
        Me.cmdChamberDown.TabIndex = 9
        Me.cmdChamberDown.Text = "▼"
        '
        'cmdChamberUP
        '
        Me.cmdChamberUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChamberUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChamberUP.Location = New System.Drawing.Point(739, 280)
        Me.cmdChamberUP.Name = "cmdChamberUP"
        Me.cmdChamberUP.Size = New System.Drawing.Size(49, 91)
        Me.cmdChamberUP.TabIndex = 8
        Me.cmdChamberUP.Text = "▲"
        '
        'cmdChangeProcOrder
        '
        Me.cmdChangeProcOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChangeProcOrder.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChangeProcOrder.Location = New System.Drawing.Point(332, 581)
        Me.cmdChangeProcOrder.Name = "cmdChangeProcOrder"
        Me.cmdChangeProcOrder.Size = New System.Drawing.Size(105, 57)
        Me.cmdChangeProcOrder.TabIndex = 23
        Me.cmdChangeProcOrder.Text = "処理順指定"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"変更"
        '
        'picDownAllowRecipeFlow
        '
        Me.picDownAllowRecipeFlow.Image = CType(resources.GetObject("picDownAllowRecipeFlow.Image"),System.Drawing.Image)
        Me.picDownAllowRecipeFlow.InitialImage = CType(resources.GetObject("picDownAllowRecipeFlow.InitialImage"),System.Drawing.Image)
        Me.picDownAllowRecipeFlow.Location = New System.Drawing.Point(868, 460)
        Me.picDownAllowRecipeFlow.Name = "picDownAllowRecipeFlow"
        Me.picDownAllowRecipeFlow.Size = New System.Drawing.Size(32, 32)
        Me.picDownAllowRecipeFlow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDownAllowRecipeFlow.TabIndex = 45
        Me.picDownAllowRecipeFlow.TabStop = false
        '
        'cmdChangeTrnst
        '
        Me.cmdChangeTrnst.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChangeTrnst.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChangeTrnst.Location = New System.Drawing.Point(548, 581)
        Me.cmdChangeTrnst.Name = "cmdChangeTrnst"
        Me.cmdChangeTrnst.Size = New System.Drawing.Size(105, 57)
        Me.cmdChangeTrnst.TabIndex = 21
        Me.cmdChangeTrnst.Text = "搬送ポート"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"変更"
        '
        'chkMessage
        '
        Me.chkMessage.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkMessage.Location = New System.Drawing.Point(795, 365)
        Me.chkMessage.Name = "chkMessage"
        Me.chkMessage.Size = New System.Drawing.Size(183, 41)
        Me.chkMessage.TabIndex = 14
        Me.chkMessage.Text = "メッセージ表示"
        '
        'cmdUseChange
        '
        Me.cmdUseChange.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUseChange.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUseChange.Location = New System.Drawing.Point(764, 581)
        Me.cmdUseChange.Name = "cmdUseChange"
        Me.cmdUseChange.Size = New System.Drawing.Size(105, 57)
        Me.cmdUseChange.TabIndex = 19
        Me.cmdUseChange.Text = "装置状態"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"変更"
        '
        'picDownAllow
        '
        Me.picDownAllow.Image = CType(resources.GetObject("picDownAllow.Image"),System.Drawing.Image)
        Me.picDownAllow.InitialImage = CType(resources.GetObject("picDownAllow.InitialImage"),System.Drawing.Image)
        Me.picDownAllow.Location = New System.Drawing.Point(868, 279)
        Me.picDownAllow.Name = "picDownAllow"
        Me.picDownAllow.Size = New System.Drawing.Size(32, 32)
        Me.picDownAllow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDownAllow.TabIndex = 39
        Me.picDownAllow.TabStop = false
        '
        'cmdWorkMemoUp
        '
        Me.cmdWorkMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWorkMemoUp.Location = New System.Drawing.Point(739, 487)
        Me.cmdWorkMemoUp.Name = "cmdWorkMemoUp"
        Me.cmdWorkMemoUp.Size = New System.Drawing.Size(49, 42)
        Me.cmdWorkMemoUp.TabIndex = 11
        Me.cmdWorkMemoUp.Text = "▲"
        '
        'cmdWorkMemoDown
        '
        Me.cmdWorkMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWorkMemoDown.Location = New System.Drawing.Point(739, 531)
        Me.cmdWorkMemoDown.Name = "cmdWorkMemoDown"
        Me.cmdWorkMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdWorkMemoDown.TabIndex = 12
        Me.cmdWorkMemoDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(739, 71)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 91)
        Me.cmdUP.TabIndex = 4
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(739, 162)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 92)
        Me.cmdDown.TabIndex = 5
        Me.cmdDown.Text = "▼"
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(705, 8)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(105, 57)
        Me.cmdSearch.TabIndex = 2
        Me.cmdSearch.Text = "最新取得"
        '
        'cmdExecution
        '
        Me.cmdExecution.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdExecution.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdExecution.Location = New System.Drawing.Point(656, 581)
        Me.cmdExecution.Name = "cmdExecution"
        Me.cmdExecution.Size = New System.Drawing.Size(105, 57)
        Me.cmdExecution.TabIndex = 20
        Me.cmdExecution.Text = "強制"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Ｍ１変更"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 581)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 18
        Me.cmdRegist.Text = "モード移行"
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
        'vsfModeList
        '
        Me.vsfModeList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfModeList.AllowEditing = false
        Me.vsfModeList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfModeList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfModeList.AutoSearchDelay = 2R
        Me.vsfModeList.BackColor = System.Drawing.Color.White
        Me.vsfModeList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfModeList.ColumnInfo = resources.GetString("vsfModeList.ColumnInfo")
        Me.vsfModeList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfModeList.ExtendLastCol = true
        Me.vsfModeList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfModeList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfModeList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfModeList.Location = New System.Drawing.Point(8, 281)
        Me.vsfModeList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfModeList.Name = "vsfModeList"
        Me.vsfModeList.Rows.Count = 5
        Me.vsfModeList.Rows.DefaultSize = 18
        Me.vsfModeList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfModeList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfModeList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfModeList.Size = New System.Drawing.Size(227, 181)
        Me.vsfModeList.StyleInfo = resources.GetString("vsfModeList.StyleInfo")
        Me.vsfModeList.TabIndex = 6
        '
        'cmbMcGroup
        '
        Me.cmbMcGroup.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.Location = New System.Drawing.Point(8, 24)
        Me.cmbMcGroup.Name = "cmbMcGroup"
        Me.cmbMcGroup.Size = New System.Drawing.Size(332, 28)
        Me.cmbMcGroup.TabIndex = 0
        Me.cmbMcGroup.Value = Nothing
        '
        'cmbWp
        '
        Me.cmbWp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWp.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWp.Location = New System.Drawing.Point(340, 24)
        Me.cmbWp.Name = "cmbWp"
        Me.cmbWp.Size = New System.Drawing.Size(360, 28)
        Me.cmbWp.TabIndex = 1
        Me.cmbWp.Value = Nothing
        '
        'vsfPortNoList
        '
        Me.vsfPortNoList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfPortNoList.AllowEditing = false
        Me.vsfPortNoList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfPortNoList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfPortNoList.AutoSearchDelay = 2R
        Me.vsfPortNoList.BackColor = System.Drawing.Color.White
        Me.vsfPortNoList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfPortNoList.ColumnInfo = resources.GetString("vsfPortNoList.ColumnInfo")
        Me.vsfPortNoList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfPortNoList.ExtendLastCol = true
        Me.vsfPortNoList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfPortNoList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfPortNoList.Location = New System.Drawing.Point(8, 72)
        Me.vsfPortNoList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfPortNoList.Name = "vsfPortNoList"
        Me.vsfPortNoList.Rows.Count = 5
        Me.vsfPortNoList.Rows.DefaultSize = 19
        Me.vsfPortNoList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfPortNoList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfPortNoList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfPortNoList.Size = New System.Drawing.Size(731, 181)
        Me.vsfPortNoList.StyleInfo = resources.GetString("vsfPortNoList.StyleInfo")
        Me.vsfPortNoList.TabIndex = 3
        Me.vsfPortNoList.TabStop = false
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 504)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(731, 69)
        Me.txtWorkMemo.TabIndex = 10
        '
        'cmbUseName
        '
        Me.cmbUseName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbUseName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbUseName.GroupCols = 1
        Me.cmbUseName.Location = New System.Drawing.Point(794, 331)
        Me.cmbUseName.Name = "cmbUseName"
        Me.cmbUseName.Size = New System.Drawing.Size(183, 28)
        Me.cmbUseName.TabIndex = 13
        Me.cmbUseName.Value = Nothing
        '
        'cmbRecipeFlow
        '
        Me.cmbRecipeFlow.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRecipeFlow.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRecipeFlow.GroupCols = 2
        Me.cmbRecipeFlow.Location = New System.Drawing.Point(793, 513)
        Me.cmbRecipeFlow.Name = "cmbRecipeFlow"
        Me.cmbRecipeFlow.Size = New System.Drawing.Size(184, 28)
        Me.cmbRecipeFlow.TabIndex = 15
        Me.cmbRecipeFlow.Value = Nothing
        '
        'txtRecipeFlowNum
        '
        Me.txtRecipeFlowNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtRecipeFlowNum.ChrMaxByte = 2
        Me.txtRecipeFlowNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtRecipeFlowNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtRecipeFlowNum.Location = New System.Drawing.Point(945, 543)
        Me.txtRecipeFlowNum.Name = "txtRecipeFlowNum"
        Me.txtRecipeFlowNum.NgChr = "'"
        Me.txtRecipeFlowNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtRecipeFlowNum.NumMax = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtRecipeFlowNum.NumMin = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtRecipeFlowNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRecipeFlowNum.SelectedText = ""
        Me.txtRecipeFlowNum.Size = New System.Drawing.Size(32, 28)
        Me.txtRecipeFlowNum.TabIndex = 17
        Me.txtRecipeFlowNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'vsfChamberList
        '
        Me.vsfChamberList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfChamberList.AllowEditing = false
        Me.vsfChamberList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfChamberList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfChamberList.AutoSearchDelay = 2R
        Me.vsfChamberList.BackColor = System.Drawing.Color.White
        Me.vsfChamberList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfChamberList.ColumnInfo = resources.GetString("vsfChamberList.ColumnInfo")
        Me.vsfChamberList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfChamberList.ExtendLastCol = true
        Me.vsfChamberList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfChamberList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfChamberList.Location = New System.Drawing.Point(242, 281)
        Me.vsfChamberList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfChamberList.Name = "vsfChamberList"
        Me.vsfChamberList.Rows.Count = 5
        Me.vsfChamberList.Rows.DefaultSize = 19
        Me.vsfChamberList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfChamberList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfChamberList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfChamberList.Size = New System.Drawing.Size(497, 181)
        Me.vsfChamberList.StyleInfo = resources.GetString("vsfChamberList.StyleInfo")
        Me.vsfChamberList.TabIndex = 7
        '
        'cmbRecipeGroup
        '
        Me.cmbRecipeGroup.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRecipeGroup.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRecipeGroup.Location = New System.Drawing.Point(793, 543)
        Me.cmbRecipeGroup.Name = "cmbRecipeGroup"
        Me.cmbRecipeGroup.Size = New System.Drawing.Size(154, 28)
        Me.cmbRecipeGroup.TabIndex = 16
        Me.cmbRecipeGroup.Value = Nothing
        '
        'lblBeforeRecipeFlowNum
        '
        Me.lblBeforeRecipeFlowNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBeforeRecipeFlowNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBeforeRecipeFlowNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBeforeRecipeFlowNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBeforeRecipeFlowNum.Location = New System.Drawing.Point(940, 428)
        Me.lblBeforeRecipeFlowNum.Name = "lblBeforeRecipeFlowNum"
        Me.lblBeforeRecipeFlowNum.Size = New System.Drawing.Size(37, 30)
        Me.lblBeforeRecipeFlowNum.TabIndex = 46
        Me.lblBeforeRecipeFlowNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBeforeRecipeFlow
        '
        Me.lblBeforeRecipeFlow.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBeforeRecipeFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBeforeRecipeFlow.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBeforeRecipeFlow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBeforeRecipeFlow.Location = New System.Drawing.Point(794, 428)
        Me.lblBeforeRecipeFlow.Name = "lblBeforeRecipeFlow"
        Me.lblBeforeRecipeFlow.Size = New System.Drawing.Size(151, 30)
        Me.lblBeforeRecipeFlow.TabIndex = 44
        '
        'lblBeforeRecipeFlowTitle
        '
        Me.lblBeforeRecipeFlowTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBeforeRecipeFlowTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBeforeRecipeFlowTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBeforeRecipeFlowTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBeforeRecipeFlowTitle.Location = New System.Drawing.Point(794, 412)
        Me.lblBeforeRecipeFlowTitle.Name = "lblBeforeRecipeFlowTitle"
        Me.lblBeforeRecipeFlowTitle.Size = New System.Drawing.Size(183, 17)
        Me.lblBeforeRecipeFlowTitle.TabIndex = 43
        Me.lblBeforeRecipeFlowTitle.Text = "現在の処理順指定"
        Me.lblBeforeRecipeFlowTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAfterRecipeFlowTitle
        '
        Me.lblAfterRecipeFlowTitle.BackColor = System.Drawing.Color.Navy
        Me.lblAfterRecipeFlowTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAfterRecipeFlowTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblAfterRecipeFlowTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblAfterRecipeFlowTitle.Location = New System.Drawing.Point(793, 496)
        Me.lblAfterRecipeFlowTitle.Name = "lblAfterRecipeFlowTitle"
        Me.lblAfterRecipeFlowTitle.Size = New System.Drawing.Size(183, 17)
        Me.lblAfterRecipeFlowTitle.TabIndex = 42
        Me.lblAfterRecipeFlowTitle.Text = "変更後処理順指定"
        Me.lblAfterRecipeFlowTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblUseNameTitle
        '
        Me.lblUseNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblUseNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUseNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUseNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblUseNameTitle.Location = New System.Drawing.Point(794, 232)
        Me.lblUseNameTitle.Name = "lblUseNameTitle"
        Me.lblUseNameTitle.Size = New System.Drawing.Size(183, 17)
        Me.lblUseNameTitle.TabIndex = 41
        Me.lblUseNameTitle.Text = "現在の装置状態"
        Me.lblUseNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblUseName
        '
        Me.lblUseName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblUseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUseName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUseName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUseName.Location = New System.Drawing.Point(794, 248)
        Me.lblUseName.Name = "lblUseName"
        Me.lblUseName.Size = New System.Drawing.Size(183, 30)
        Me.lblUseName.TabIndex = 40
        '
        'lblCmbUseNameTitle
        '
        Me.lblCmbUseNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCmbUseNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCmbUseNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCmbUseNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCmbUseNameTitle.Location = New System.Drawing.Point(794, 314)
        Me.lblCmbUseNameTitle.Name = "lblCmbUseNameTitle"
        Me.lblCmbUseNameTitle.Size = New System.Drawing.Size(183, 17)
        Me.lblCmbUseNameTitle.TabIndex = 38
        Me.lblCmbUseNameTitle.Text = "変更後"
        Me.lblCmbUseNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBeforeModeTitle
        '
        Me.lblBeforeModeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBeforeModeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBeforeModeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBeforeModeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBeforeModeTitle.Location = New System.Drawing.Point(794, 176)
        Me.lblBeforeModeTitle.Name = "lblBeforeModeTitle"
        Me.lblBeforeModeTitle.Size = New System.Drawing.Size(183, 17)
        Me.lblBeforeModeTitle.TabIndex = 37
        Me.lblBeforeModeTitle.Text = "現在の運用モード"
        Me.lblBeforeModeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBeforeMode
        '
        Me.lblBeforeMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBeforeMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBeforeMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBeforeMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBeforeMode.Location = New System.Drawing.Point(794, 192)
        Me.lblBeforeMode.Name = "lblBeforeMode"
        Me.lblBeforeMode.Size = New System.Drawing.Size(183, 30)
        Me.lblBeforeMode.TabIndex = 36
        '
        'lblReleaseLengthCount
        '
        Me.lblReleaseLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblReleaseLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReleaseLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblReleaseLengthCount.Location = New System.Drawing.Point(477, 0)
        Me.lblReleaseLengthCount.Name = "lblReleaseLengthCount"
        Me.lblReleaseLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblReleaseLengthCount.TabIndex = 34
        Me.lblReleaseLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblReleaseLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblWpIDTitle
        '
        Me.lblWpIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWpIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWpIDTitle.Location = New System.Drawing.Point(340, 8)
        Me.lblWpIDTitle.Name = "lblWpIDTitle"
        Me.lblWpIDTitle.Size = New System.Drawing.Size(360, 17)
        Me.lblWpIDTitle.TabIndex = 33
        Me.lblWpIDTitle.Text = "装置名"
        Me.lblWpIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMcGroupNameTitle
        '
        Me.lblMcGroupNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblMcGroupNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMcGroupNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMcGroupNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblMcGroupNameTitle.Location = New System.Drawing.Point(8, 8)
        Me.lblMcGroupNameTitle.Name = "lblMcGroupNameTitle"
        Me.lblMcGroupNameTitle.Size = New System.Drawing.Size(332, 17)
        Me.lblMcGroupNameTitle.TabIndex = 32
        Me.lblMcGroupNameTitle.Text = "装置グループ"
        Me.lblMcGroupNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDateTitle
        '
        Me.lblNowDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNowDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNowDateTitle.Location = New System.Drawing.Point(816, 8)
        Me.lblNowDateTitle.Name = "lblNowDateTitle"
        Me.lblNowDateTitle.Size = New System.Drawing.Size(161, 17)
        Me.lblNowDateTitle.TabIndex = 31
        Me.lblNowDateTitle.Text = "情報取得日時"
        Me.lblNowDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(816, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(161, 30)
        Me.lblNowDate.TabIndex = 30
        '
        'lblM1AfterMode
        '
        Me.lblM1AfterMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblM1AfterMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblM1AfterMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblM1AfterMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblM1AfterMode.Location = New System.Drawing.Point(794, 140)
        Me.lblM1AfterMode.Name = "lblM1AfterMode"
        Me.lblM1AfterMode.Size = New System.Drawing.Size(183, 30)
        Me.lblM1AfterMode.TabIndex = 29
        '
        'lblM1AfterModeTitle
        '
        Me.lblM1AfterModeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblM1AfterModeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblM1AfterModeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblM1AfterModeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblM1AfterModeTitle.Location = New System.Drawing.Point(794, 124)
        Me.lblM1AfterModeTitle.Name = "lblM1AfterModeTitle"
        Me.lblM1AfterModeTitle.Size = New System.Drawing.Size(183, 17)
        Me.lblM1AfterModeTitle.TabIndex = 28
        Me.lblM1AfterModeTitle.Text = "運用状態"
        Me.lblM1AfterModeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWpStatusName
        '
        Me.lblWpStatusName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWpStatusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpStatusName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpStatusName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWpStatusName.Location = New System.Drawing.Point(794, 88)
        Me.lblWpStatusName.Name = "lblWpStatusName"
        Me.lblWpStatusName.Size = New System.Drawing.Size(183, 30)
        Me.lblWpStatusName.TabIndex = 27
        '
        'lblWpStatusNameTitle
        '
        Me.lblWpStatusNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWpStatusNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpStatusNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpStatusNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWpStatusNameTitle.Location = New System.Drawing.Point(794, 72)
        Me.lblWpStatusNameTitle.Name = "lblWpStatusNameTitle"
        Me.lblWpStatusNameTitle.Size = New System.Drawing.Size(183, 17)
        Me.lblWpStatusNameTitle.TabIndex = 26
        Me.lblWpStatusNameTitle.Text = "処理状態"
        Me.lblWpStatusNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWorkMemoTitle
        '
        Me.lblWorkMemoTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWorkMemoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWorkMemoTitle.Controls.Add(Me.lblReleaseLengthCount)
        Me.lblWorkMemoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWorkMemoTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWorkMemoTitle.Location = New System.Drawing.Point(8, 488)
        Me.lblWorkMemoTitle.Name = "lblWorkMemoTitle"
        Me.lblWorkMemoTitle.Size = New System.Drawing.Size(731, 17)
        Me.lblWorkMemoTitle.TabIndex = 35
        Me.lblWorkMemoTitle.Text = "      作業メモ"
        Me.lblWorkMemoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00C0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdCarrierUnload)
        Me.Controls.Add(Me.cmdChangeChamber)
        Me.Controls.Add(Me.cmdChamberDown)
        Me.Controls.Add(Me.cmdChamberUP)
        Me.Controls.Add(Me.cmdChangeProcOrder)
        Me.Controls.Add(Me.picDownAllowRecipeFlow)
        Me.Controls.Add(Me.cmdChangeTrnst)
        Me.Controls.Add(Me.chkMessage)
        Me.Controls.Add(Me.cmdUseChange)
        Me.Controls.Add(Me.picDownAllow)
        Me.Controls.Add(Me.cmdWorkMemoUp)
        Me.Controls.Add(Me.cmdWorkMemoDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdExecution)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfModeList)
        Me.Controls.Add(Me.cmbMcGroup)
        Me.Controls.Add(Me.cmbWp)
        Me.Controls.Add(Me.vsfPortNoList)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.cmbUseName)
        Me.Controls.Add(Me.cmbRecipeFlow)
        Me.Controls.Add(Me.txtRecipeFlowNum)
        Me.Controls.Add(Me.vsfChamberList)
        Me.Controls.Add(Me.cmbRecipeGroup)
        Me.Controls.Add(Me.lblBeforeRecipeFlowNum)
        Me.Controls.Add(Me.lblBeforeRecipeFlow)
        Me.Controls.Add(Me.lblBeforeRecipeFlowTitle)
        Me.Controls.Add(Me.lblAfterRecipeFlowTitle)
        Me.Controls.Add(Me.lblUseNameTitle)
        Me.Controls.Add(Me.lblUseName)
        Me.Controls.Add(Me.lblCmbUseNameTitle)
        Me.Controls.Add(Me.lblBeforeModeTitle)
        Me.Controls.Add(Me.lblBeforeMode)
        Me.Controls.Add(Me.lblWpIDTitle)
        Me.Controls.Add(Me.lblMcGroupNameTitle)
        Me.Controls.Add(Me.lblNowDateTitle)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblM1AfterMode)
        Me.Controls.Add(Me.lblM1AfterModeTitle)
        Me.Controls.Add(Me.lblWpStatusName)
        Me.Controls.Add(Me.lblWpStatusNameTitle)
        Me.Controls.Add(Me.lblWorkMemoTitle)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00C0"
        Me.Text = "運用モード変更/装置状態変更"
        CType(Me.picDownAllowRecipeFlow,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picDownAllow,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfModeList,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfPortNoList,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfChamberList,System.ComponentModel.ISupportInitialize).EndInit
        Me.lblWorkMemoTitle.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCarrierUnload As Button
    Friend WithEvents cmdChangeChamber As Button
    Friend WithEvents cmdChamberDown As Button
    Friend WithEvents cmdChamberUP As Button
    Friend WithEvents cmdChangeProcOrder As Button
    Friend WithEvents picDownAllowRecipeFlow As PictureBox
    Friend WithEvents cmdChangeTrnst As Button
    Friend WithEvents chkMessage As CheckBox
    Friend WithEvents cmdUseChange As Button
    Friend WithEvents picDownAllow As PictureBox
    Friend WithEvents cmdWorkMemoUp As Button
    Friend WithEvents cmdWorkMemoDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdExecution As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfModeList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbMcGroup As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbWp As SECmbIchiran.ComboIchiran
    Friend WithEvents vsfPortNoList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbUseName As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbRecipeFlow As SECmbIchiran.ComboIchiran
    Friend WithEvents txtRecipeFlowNum As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfChamberList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbRecipeGroup As SECmbIchiran.ComboIchiran
    Friend WithEvents lblBeforeRecipeFlowNum As Label
    Friend WithEvents lblBeforeRecipeFlow As Label
    Friend WithEvents lblBeforeRecipeFlowTitle As Label
    Friend WithEvents lblAfterRecipeFlowTitle As Label
    Friend WithEvents lblUseNameTitle As Label
    Friend WithEvents lblUseName As Label
    Friend WithEvents lblCmbUseNameTitle As Label
    Friend WithEvents lblBeforeModeTitle As Label
    Friend WithEvents lblBeforeMode As Label
    Friend WithEvents lblReleaseLengthCount As Label
    Friend WithEvents lblWpIDTitle As Label
    Friend WithEvents lblMcGroupNameTitle As Label
    Friend WithEvents lblNowDateTitle As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblM1AfterMode As Label
    Friend WithEvents lblM1AfterModeTitle As Label
    Friend WithEvents lblWpStatusName As Label
    Friend WithEvents lblWpStatusNameTitle As Label
    Friend WithEvents lblWorkMemoTitle As Label
End Class
