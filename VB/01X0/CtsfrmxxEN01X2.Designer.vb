<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01X2
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01X2))
        Me.serchSetting = New System.Windows.Forms.Button()
        Me.cmdSpcSkipChkOn = New System.Windows.Forms.Button()
        Me.cmdEditStart = New System.Windows.Forms.Button()
        Me.cmdEntryDisp = New System.Windows.Forms.Button()
        Me.cmdMstEntry = New System.Windows.Forms.Button()
        Me.cmdLotEntry = New System.Windows.Forms.Button()
        Me.cmdApcSet = New System.Windows.Forms.Button()
        Me.cmdSave1 = New System.Windows.Forms.Button()
        Me.cmdTimeLimitSet = New System.Windows.Forms.Button()
        Me.fraHeader = New System.Windows.Forms.Panel()
        Me.cmdCommentDown = New System.Windows.Forms.Button()
        Me.cmdCommentUp = New System.Windows.Forms.Button()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblCurrentStatus = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.cmdSetPanel = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdSave2 = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.stbSetPanel = New System.Windows.Forms.TabControl()
        Me.Tab0 = New System.Windows.Forms.TabPage()
        Me.fraOp = New System.Windows.Forms.GroupBox()
        Me.chkValidOpID = New System.Windows.Forms.CheckBox()
        Me.vsfOpList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbOpCategory = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.fraStep = New System.Windows.Forms.GroupBox()
        Me.chkValidStepID = New System.Windows.Forms.CheckBox()
        Me.cmbStepCategory = New SEComboBoxEx.ComboBoxEx()
        Me.vsfStepList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.fraCondition1 = New System.Windows.Forms.GroupBox()
        Me.chkMaxVer = New System.Windows.Forms.CheckBox()
        Me.chkValidCondition = New System.Windows.Forms.CheckBox()
        Me.vsfConditionList1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbConditionCategory = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.fraCondition2 = New System.Windows.Forms.GroupBox()
        Me.cmdParCondition = New System.Windows.Forms.Button()
        Me.fraRecipe = New System.Windows.Forms.Panel()
        Me.vsfConditionList2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraRecipeAll = New System.Windows.Forms.Panel()
        Me.vsfConditionList3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfConditionWP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Tab3 = New System.Windows.Forms.TabPage()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.fraSelectCondition = New System.Windows.Forms.GroupBox()
        Me.vsfSelectCondition = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraSelectConItem = New System.Windows.Forms.Panel()
        Me.fraSlotNo = New System.Windows.Forms.GroupBox()
        Me.chkSlotNo1 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo6 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo11 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo16 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo21 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo2 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo7 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo12 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo17 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo22 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo3 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo8 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo13 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo18 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo23 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo4 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo9 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo14 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo19 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo24 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo5 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo10 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo15 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo20 = New System.Windows.Forms.CheckBox()
        Me.chkSlotNo25 = New System.Windows.Forms.CheckBox()
        Me.fraWFNo = New System.Windows.Forms.GroupBox()
        Me.lblWFMiddle = New System.Windows.Forms.Label()
        Me.lblWFNo2 = New System.Windows.Forms.Label()
        Me.lblWFNoMiddle = New System.Windows.Forms.Label()
        Me.lblWFDown = New System.Windows.Forms.Label()
        Me.lblWFUp = New System.Windows.Forms.Label()
        Me.lblWFNoUp = New System.Windows.Forms.Label()
        Me.lblWFNoDown = New System.Windows.Forms.Label()
        Me.lblWFNo1 = New System.Windows.Forms.Label()
        Me.lblWFNo0 = New System.Windows.Forms.Label()
        Me.fraUserSelect = New System.Windows.Forms.GroupBox()
        Me.chkUserSelect = New System.Windows.Forms.CheckBox()
        Me.lblUserSelect = New System.Windows.Forms.Label()
        Me.lblSelectRule = New System.Windows.Forms.Label()
        Me.Tab4 = New System.Windows.Forms.TabPage()
        Me.fraCollection2 = New System.Windows.Forms.GroupBox()
        Me.vsfCollectionPara = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraCollection1 = New System.Windows.Forms.GroupBox()
        Me.chkValidCollection = New System.Windows.Forms.CheckBox()
        Me.vsfCollectionList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbCollectionCategory = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.Tab5 = New System.Windows.Forms.TabPage()
        Me.fraScrap1 = New System.Windows.Forms.GroupBox()
        Me.vsfScrapList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraScrap0 = New System.Windows.Forms.GroupBox()
        Me.vsfLotScrapSetID = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfFlowList0 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfFlowList1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbResize = New SECmbIchiran.ComboIchiran()
        Me.lblFlowList1 = New System.Windows.Forms.Label()
        Me.lblFlowList0 = New System.Windows.Forms.Label()
        Me.mnu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnu11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu21 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu22 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu23 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu31 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu32 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu3b = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu33 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu41 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu42 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu51 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu61 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu71 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu7b = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu72 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu8A = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu81 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu82 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu83 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu8B = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu84 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu85 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu8C = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu87 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu8D = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu86 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnu3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnu4 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnu5 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnu6 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnu7 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnu8 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.fraHeader.SuspendLayout
        Me.stbSetPanel.SuspendLayout
        Me.Tab0.SuspendLayout
        Me.fraOp.SuspendLayout
        CType(Me.vsfOpList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab1.SuspendLayout
        Me.fraStep.SuspendLayout
        CType(Me.vsfStepList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab2.SuspendLayout
        Me.fraCondition1.SuspendLayout
        CType(Me.vsfConditionList1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCondition2.SuspendLayout
        Me.fraRecipe.SuspendLayout
        CType(Me.vsfConditionList2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraRecipeAll.SuspendLayout
        CType(Me.vsfConditionList3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfConditionWP,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab3.SuspendLayout
        Me.fraSelectCondition.SuspendLayout
        CType(Me.vsfSelectCondition,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraSelectConItem.SuspendLayout
        Me.fraSlotNo.SuspendLayout
        Me.fraWFNo.SuspendLayout
        Me.fraUserSelect.SuspendLayout
        Me.Tab4.SuspendLayout
        Me.fraCollection2.SuspendLayout
        CType(Me.vsfCollectionPara,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCollection1.SuspendLayout
        CType(Me.vsfCollectionList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab5.SuspendLayout
        Me.fraScrap1.SuspendLayout
        CType(Me.vsfScrapList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraScrap0.SuspendLayout
        CType(Me.vsfLotScrapSetID,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfFlowList0,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfFlowList1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.mnu1.SuspendLayout
        Me.mnu2.SuspendLayout
        Me.mnu3.SuspendLayout
        Me.mnu4.SuspendLayout
        Me.mnu5.SuspendLayout
        Me.mnu6.SuspendLayout
        Me.mnu7.SuspendLayout
        Me.mnu8.SuspendLayout
        Me.SuspendLayout
        '
        'serchSetting
        '
        Me.serchSetting.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.serchSetting.Location = New System.Drawing.Point(104, 597)
        Me.serchSetting.Name = "serchSetting"
        Me.serchSetting.Size = New System.Drawing.Size(85, 40)
        Me.serchSetting.TabIndex = 115
        Me.serchSetting.Text = "設定値"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"検索"
        '
        'cmdSpcSkipChkOn
        '
        Me.cmdSpcSkipChkOn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSpcSkipChkOn.Location = New System.Drawing.Point(512, 597)
        Me.cmdSpcSkipChkOn.Name = "cmdSpcSkipChkOn"
        Me.cmdSpcSkipChkOn.Size = New System.Drawing.Size(85, 40)
        Me.cmdSpcSkipChkOn.TabIndex = 114
        Me.cmdSpcSkipChkOn.Text = "SPCｽｷｯﾌﾟ全On"
        '
        'cmdEditStart
        '
        Me.cmdEditStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEditStart.Location = New System.Drawing.Point(700, 597)
        Me.cmdEditStart.Name = "cmdEditStart"
        Me.cmdEditStart.Size = New System.Drawing.Size(85, 40)
        Me.cmdEditStart.TabIndex = 33
        Me.cmdEditStart.Text = "編集開始"
        '
        'cmdEntryDisp
        '
        Me.cmdEntryDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEntryDisp.Location = New System.Drawing.Point(888, 512)
        Me.cmdEntryDisp.Name = "cmdEntryDisp"
        Me.cmdEntryDisp.Size = New System.Drawing.Size(85, 40)
        Me.cmdEntryDisp.TabIndex = 12
        Me.cmdEntryDisp.Text = "ｺﾋﾟｰ工順"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"非表示"
        '
        'cmdMstEntry
        '
        Me.cmdMstEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMstEntry.Location = New System.Drawing.Point(888, 470)
        Me.cmdMstEntry.Name = "cmdMstEntry"
        Me.cmdMstEntry.Size = New System.Drawing.Size(85, 40)
        Me.cmdMstEntry.TabIndex = 11
        Me.cmdMstEntry.Text = "ﾏｽﾀ工順ｺﾋﾟｰ"
        '
        'cmdLotEntry
        '
        Me.cmdLotEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotEntry.Location = New System.Drawing.Point(888, 428)
        Me.cmdLotEntry.Name = "cmdLotEntry"
        Me.cmdLotEntry.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotEntry.TabIndex = 10
        Me.cmdLotEntry.Text = "ﾛｯﾄ工順ｺﾋﾟｰ"
        '
        'cmdApcSet
        '
        Me.cmdApcSet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdApcSet.Location = New System.Drawing.Point(888, 332)
        Me.cmdApcSet.Name = "cmdApcSet"
        Me.cmdApcSet.Size = New System.Drawing.Size(85, 40)
        Me.cmdApcSet.TabIndex = 8
        Me.cmdApcSet.Text = "APC設定"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認"
        '
        'cmdSave1
        '
        Me.cmdSave1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave1.Location = New System.Drawing.Point(793, 597)
        Me.cmdSave1.Name = "cmdSave1"
        Me.cmdSave1.Size = New System.Drawing.Size(85, 40)
        Me.cmdSave1.TabIndex = 32
        Me.cmdSave1.Text = "一時保存"
        '
        'cmdTimeLimitSet
        '
        Me.cmdTimeLimitSet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTimeLimitSet.Location = New System.Drawing.Point(888, 290)
        Me.cmdTimeLimitSet.Name = "cmdTimeLimitSet"
        Me.cmdTimeLimitSet.Size = New System.Drawing.Size(85, 40)
        Me.cmdTimeLimitSet.TabIndex = 7
        Me.cmdTimeLimitSet.Text = "時間制限"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"設定"
        '
        'fraHeader
        '
        Me.fraHeader.Controls.Add(Me.cmdCommentDown)
        Me.fraHeader.Controls.Add(Me.cmdCommentUp)
        Me.fraHeader.Controls.Add(Me.txtComments)
        Me.fraHeader.Controls.Add(Me.lblTitle3)
        Me.fraHeader.Controls.Add(Me.lblStepID)
        Me.fraHeader.Controls.Add(Me.lblTitle9)
        Me.fraHeader.Controls.Add(Me.lblOpID)
        Me.fraHeader.Controls.Add(Me.lblFlowClass)
        Me.fraHeader.Controls.Add(Me.lblTitle2)
        Me.fraHeader.Controls.Add(Me.lblCurrentStatus)
        Me.fraHeader.Controls.Add(Me.lblLotID)
        Me.fraHeader.Controls.Add(Me.lblLengthCount)
        Me.fraHeader.Controls.Add(Me.lblTitle1)
        Me.fraHeader.Controls.Add(Me.lblTitle4)
        Me.fraHeader.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraHeader.Location = New System.Drawing.Point(8, 4)
        Me.fraHeader.Name = "fraHeader"
        Me.fraHeader.Size = New System.Drawing.Size(967, 57)
        Me.fraHeader.TabIndex = 34
        Me.fraHeader.Text = "Frame1"
        '
        'cmdCommentDown
        '
        Me.cmdCommentDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentDown.Location = New System.Drawing.Point(942, 29)
        Me.cmdCommentDown.Name = "cmdCommentDown"
        Me.cmdCommentDown.Size = New System.Drawing.Size(25, 28)
        Me.cmdCommentDown.TabIndex = 36
        Me.cmdCommentDown.Text = "▼"
        '
        'cmdCommentUp
        '
        Me.cmdCommentUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentUp.Location = New System.Drawing.Point(942, 0)
        Me.cmdCommentUp.Name = "cmdCommentUp"
        Me.cmdCommentUp.Size = New System.Drawing.Size(25, 28)
        Me.cmdCommentUp.TabIndex = 35
        Me.cmdCommentUp.Text = "▲"
        '
        'txtComments
        '
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 2048
        Me.txtComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtComments.GotHighLight = false
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtComments.Location = New System.Drawing.Point(533, 17)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NgChr = "'"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(410, 39)
        Me.txtComments.TabIndex = 34
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(278, 0)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(167, 17)
        Me.lblTitle3.TabIndex = 110
        Me.lblTitle3.Text = "現在小工程"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepID
        '
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(278, 16)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(167, 22)
        Me.lblStepID.TabIndex = 109
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(112, 0)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(167, 17)
        Me.lblTitle9.TabIndex = 108
        Me.lblTitle9.Text = "現在大工程"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(112, 16)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(167, 22)
        Me.lblOpID.TabIndex = 107
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(84, 16)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(25, 22)
        Me.lblFlowClass.TabIndex = 96
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(444, 0)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(85, 17)
        Me.lblTitle2.TabIndex = 95
        Me.lblTitle2.Text = "状態"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCurrentStatus
        '
        Me.lblCurrentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCurrentStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCurrentStatus.Location = New System.Drawing.Point(444, 16)
        Me.lblCurrentStatus.Name = "lblCurrentStatus"
        Me.lblCurrentStatus.Size = New System.Drawing.Size(85, 22)
        Me.lblCurrentStatus.TabIndex = 94
        '
        'lblLotID
        '
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(0, 16)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(89, 22)
        Me.lblLotID.TabIndex = 90
        '
        'lblLengthCount
        '
        Me.lblLengthCount.AutoSize = true
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.Color.White
        Me.lblLengthCount.Location = New System.Drawing.Point(705, 2)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(255, 15)
        Me.lblLengthCount.TabIndex = 73
        Me.lblLengthCount.Text = "（ 半角9999文字/半角2048文字 ）"
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(109, 17)
        Me.lblTitle1.TabIndex = 72
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(533, 1)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(430, 17)
        Me.lblTitle4.TabIndex = 71
        Me.lblTitle4.Text = "         コメント"
        '
        'cmdSetPanel
        '
        Me.cmdSetPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSetPanel.Location = New System.Drawing.Point(888, 374)
        Me.cmdSetPanel.Name = "cmdSetPanel"
        Me.cmdSetPanel.Size = New System.Drawing.Size(85, 40)
        Me.cmdSetPanel.TabIndex = 9
        Me.cmdSetPanel.Text = "設定画面"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"非表示"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Location = New System.Drawing.Point(888, 249)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(85, 40)
        Me.cmdDown.TabIndex = 6
        Me.cmdDown.Text = "行移動"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&" (↓)"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Location = New System.Drawing.Point(888, 207)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(85, 40)
        Me.cmdUp.TabIndex = 5
        Me.cmdUp.Text = "行移動"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&" (↑)"
        '
        'cmdDel
        '
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Location = New System.Drawing.Point(888, 165)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(85, 40)
        Me.cmdDel.TabIndex = 4
        Me.cmdDel.Text = "行削除"
        '
        'cmdEdit
        '
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEdit.Location = New System.Drawing.Point(888, 124)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(85, 40)
        Me.cmdEdit.TabIndex = 3
        Me.cmdEdit.Text = "行編集"
        '
        'cmdAdd
        '
        Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAdd.Location = New System.Drawing.Point(888, 82)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(85, 40)
        Me.cmdAdd.TabIndex = 2
        Me.cmdAdd.Text = "行追加"
        '
        'cmdSave2
        '
        Me.cmdSave2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave2.Location = New System.Drawing.Point(888, 597)
        Me.cmdSave2.Name = "cmdSave2"
        Me.cmdSave2.Size = New System.Drawing.Size(85, 40)
        Me.cmdSave2.TabIndex = 31
        Me.cmdSave2.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 37
        Me.cmdClose.Text = "閉じる"
        '
        'stbSetPanel
        '
        Me.stbSetPanel.Controls.Add(Me.Tab0)
        Me.stbSetPanel.Controls.Add(Me.Tab1)
        Me.stbSetPanel.Controls.Add(Me.Tab2)
        Me.stbSetPanel.Controls.Add(Me.Tab3)
        Me.stbSetPanel.Controls.Add(Me.Tab4)
        Me.stbSetPanel.Controls.Add(Me.Tab5)
        Me.stbSetPanel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.stbSetPanel.ItemSize = New System.Drawing.Size(143, 21)
        Me.stbSetPanel.Location = New System.Drawing.Point(8, 297)
        Me.stbSetPanel.Name = "stbSetPanel"
        Me.stbSetPanel.SelectedIndex = 0
        Me.stbSetPanel.Size = New System.Drawing.Size(870, 300)
        Me.stbSetPanel.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.stbSetPanel.TabIndex = 30
        Me.stbSetPanel.Visible = false
        '
        'Tab0
        '
        Me.Tab0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab0.Controls.Add(Me.fraOp)
        Me.Tab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab0.ForeColor = System.Drawing.Color.Black
        Me.Tab0.Location = New System.Drawing.Point(4, 25)
        Me.Tab0.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab0.Name = "Tab0"
        Me.Tab0.Size = New System.Drawing.Size(862, 271)
        Me.Tab0.TabIndex = 0
        Me.Tab0.Text = "大工程"
        '
        'fraOp
        '
        Me.fraOp.Controls.Add(Me.chkValidOpID)
        Me.fraOp.Controls.Add(Me.vsfOpList)
        Me.fraOp.Controls.Add(Me.cmbOpCategory)
        Me.fraOp.Controls.Add(Me.lblTitle5)
        Me.fraOp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraOp.Location = New System.Drawing.Point(5, 12)
        Me.fraOp.Name = "fraOp"
        Me.fraOp.Size = New System.Drawing.Size(486, 250)
        Me.fraOp.TabIndex = 13
        Me.fraOp.TabStop = false
        '
        'chkValidOpID
        '
        Me.chkValidOpID.Checked = true
        Me.chkValidOpID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkValidOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkValidOpID.Location = New System.Drawing.Point(284, 13)
        Me.chkValidOpID.Name = "chkValidOpID"
        Me.chkValidOpID.Size = New System.Drawing.Size(65, 41)
        Me.chkValidOpID.TabIndex = 14
        Me.chkValidOpID.Text = "有効のみ"
        '
        'vsfOpList
        '
        Me.vsfOpList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfOpList.AllowEditing = false
        Me.vsfOpList.AutoResize = true
        Me.vsfOpList.AutoSearchDelay = 2R
        Me.vsfOpList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfOpList.ColumnInfo = resources.GetString("vsfOpList.ColumnInfo")
        Me.vsfOpList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfOpList.ExtendLastCol = true
        Me.vsfOpList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfOpList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfOpList.Location = New System.Drawing.Point(8, 57)
        Me.vsfOpList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfOpList.Name = "vsfOpList"
        Me.vsfOpList.Rows.Count = 15
        Me.vsfOpList.Rows.DefaultSize = 18
        Me.vsfOpList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfOpList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfOpList.Size = New System.Drawing.Size(470, 182)
        Me.vsfOpList.StyleInfo = resources.GetString("vsfOpList.StyleInfo")
        Me.vsfOpList.TabIndex = 15
        '
        'cmbOpCategory
        '
        Me.cmbOpCategory.DirectInput = false
        Me.cmbOpCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOpCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOpCategory.Location = New System.Drawing.Point(8, 29)
        Me.cmbOpCategory.Name = "cmbOpCategory"
        Me.cmbOpCategory.Size = New System.Drawing.Size(264, 22)
        Me.cmbOpCategory.TabIndex = 13
        Me.cmbOpCategory.Value = Nothing
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(8, 13)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(264, 17)
        Me.lblTitle5.TabIndex = 66
        Me.lblTitle5.Text = "カテゴリ"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab1.Controls.Add(Me.fraStep)
        Me.Tab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab1.ForeColor = System.Drawing.Color.Black
        Me.Tab1.Location = New System.Drawing.Point(4, 25)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(862, 271)
        Me.Tab1.TabIndex = 1
        Me.Tab1.Text = "小工程"
        '
        'fraStep
        '
        Me.fraStep.Controls.Add(Me.chkValidStepID)
        Me.fraStep.Controls.Add(Me.cmbStepCategory)
        Me.fraStep.Controls.Add(Me.vsfStepList)
        Me.fraStep.Controls.Add(Me.lblTitle6)
        Me.fraStep.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraStep.Location = New System.Drawing.Point(5, 12)
        Me.fraStep.Name = "fraStep"
        Me.fraStep.Size = New System.Drawing.Size(486, 250)
        Me.fraStep.TabIndex = 16
        Me.fraStep.TabStop = false
        '
        'chkValidStepID
        '
        Me.chkValidStepID.Checked = true
        Me.chkValidStepID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkValidStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkValidStepID.Location = New System.Drawing.Point(284, 13)
        Me.chkValidStepID.Name = "chkValidStepID"
        Me.chkValidStepID.Size = New System.Drawing.Size(65, 41)
        Me.chkValidStepID.TabIndex = 17
        Me.chkValidStepID.Text = "有効のみ"
        '
        'cmbStepCategory
        '
        Me.cmbStepCategory.DirectInput = false
        Me.cmbStepCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStepCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStepCategory.Location = New System.Drawing.Point(8, 29)
        Me.cmbStepCategory.Name = "cmbStepCategory"
        Me.cmbStepCategory.Size = New System.Drawing.Size(264, 22)
        Me.cmbStepCategory.TabIndex = 16
        Me.cmbStepCategory.Value = Nothing
        '
        'vsfStepList
        '
        Me.vsfStepList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfStepList.AllowEditing = false
        Me.vsfStepList.AutoResize = true
        Me.vsfStepList.AutoSearchDelay = 2R
        Me.vsfStepList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfStepList.ColumnInfo = resources.GetString("vsfStepList.ColumnInfo")
        Me.vsfStepList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfStepList.ExtendLastCol = true
        Me.vsfStepList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfStepList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfStepList.Location = New System.Drawing.Point(8, 57)
        Me.vsfStepList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfStepList.Name = "vsfStepList"
        Me.vsfStepList.Rows.Count = 15
        Me.vsfStepList.Rows.DefaultSize = 18
        Me.vsfStepList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfStepList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfStepList.Size = New System.Drawing.Size(470, 182)
        Me.vsfStepList.StyleInfo = resources.GetString("vsfStepList.StyleInfo")
        Me.vsfStepList.TabIndex = 18
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(8, 13)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(264, 17)
        Me.lblTitle6.TabIndex = 68
        Me.lblTitle6.Text = "カテゴリ"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Tab2
        '
        Me.Tab2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab2.Controls.Add(Me.fraCondition1)
        Me.Tab2.Controls.Add(Me.fraCondition2)
        Me.Tab2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab2.ForeColor = System.Drawing.Color.Black
        Me.Tab2.Location = New System.Drawing.Point(4, 25)
        Me.Tab2.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Size = New System.Drawing.Size(862, 271)
        Me.Tab2.TabIndex = 2
        Me.Tab2.Text = "処理条件"
        '
        'fraCondition1
        '
        Me.fraCondition1.Controls.Add(Me.chkMaxVer)
        Me.fraCondition1.Controls.Add(Me.chkValidCondition)
        Me.fraCondition1.Controls.Add(Me.vsfConditionList1)
        Me.fraCondition1.Controls.Add(Me.cmbConditionCategory)
        Me.fraCondition1.Controls.Add(Me.lblTitle8)
        Me.fraCondition1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCondition1.Location = New System.Drawing.Point(5, 12)
        Me.fraCondition1.Name = "fraCondition1"
        Me.fraCondition1.Size = New System.Drawing.Size(355, 250)
        Me.fraCondition1.TabIndex = 19
        Me.fraCondition1.TabStop = false
        '
        'chkMaxVer
        '
        Me.chkMaxVer.Checked = true
        Me.chkMaxVer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMaxVer.Location = New System.Drawing.Point(260, 32)
        Me.chkMaxVer.Name = "chkMaxVer"
        Me.chkMaxVer.Size = New System.Drawing.Size(90, 25)
        Me.chkMaxVer.TabIndex = 21
        Me.chkMaxVer.Text = "最新のみ"
        '
        'chkValidCondition
        '
        Me.chkValidCondition.Checked = true
        Me.chkValidCondition.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkValidCondition.Enabled = false
        Me.chkValidCondition.Location = New System.Drawing.Point(260, 13)
        Me.chkValidCondition.Name = "chkValidCondition"
        Me.chkValidCondition.Size = New System.Drawing.Size(90, 25)
        Me.chkValidCondition.TabIndex = 20
        Me.chkValidCondition.Text = "有効のみ"
        '
        'vsfConditionList1
        '
        Me.vsfConditionList1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfConditionList1.AllowEditing = false
        Me.vsfConditionList1.AutoResize = true
        Me.vsfConditionList1.AutoSearchDelay = 2R
        Me.vsfConditionList1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfConditionList1.ColumnInfo = resources.GetString("vsfConditionList1.ColumnInfo")
        Me.vsfConditionList1.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfConditionList1.ExtendLastCol = true
        Me.vsfConditionList1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfConditionList1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfConditionList1.Location = New System.Drawing.Point(8, 57)
        Me.vsfConditionList1.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfConditionList1.Name = "vsfConditionList1"
        Me.vsfConditionList1.Rows.Count = 15
        Me.vsfConditionList1.Rows.DefaultSize = 18
        Me.vsfConditionList1.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfConditionList1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfConditionList1.Size = New System.Drawing.Size(342, 182)
        Me.vsfConditionList1.StyleInfo = resources.GetString("vsfConditionList1.StyleInfo")
        Me.vsfConditionList1.TabIndex = 22
        '
        'cmbConditionCategory
        '
        Me.cmbConditionCategory.DirectInput = false
        Me.cmbConditionCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbConditionCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbConditionCategory.Location = New System.Drawing.Point(8, 29)
        Me.cmbConditionCategory.Name = "cmbConditionCategory"
        Me.cmbConditionCategory.Size = New System.Drawing.Size(240, 22)
        Me.cmbConditionCategory.TabIndex = 19
        Me.cmbConditionCategory.Value = Nothing
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(8, 13)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(240, 17)
        Me.lblTitle8.TabIndex = 69
        Me.lblTitle8.Text = "カテゴリ"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraCondition2
        '
        Me.fraCondition2.Controls.Add(Me.cmdParCondition)
        Me.fraCondition2.Controls.Add(Me.fraRecipe)
        Me.fraCondition2.Controls.Add(Me.fraRecipeAll)
        Me.fraCondition2.Location = New System.Drawing.Point(368, 13)
        Me.fraCondition2.Name = "fraCondition2"
        Me.fraCondition2.Size = New System.Drawing.Size(493, 250)
        Me.fraCondition2.TabIndex = 100
        Me.fraCondition2.TabStop = false
        Me.fraCondition2.Text = "処理条件セットID　詳細"
        '
        'cmdParCondition
        '
        Me.cmdParCondition.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdParCondition.Location = New System.Drawing.Point(399, 11)
        Me.cmdParCondition.Name = "cmdParCondition"
        Me.cmdParCondition.Size = New System.Drawing.Size(86, 43)
        Me.cmdParCondition.TabIndex = 106
        Me.cmdParCondition.Text = "個別処理"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"条件設定"
        '
        'fraRecipe
        '
        Me.fraRecipe.Controls.Add(Me.vsfConditionList2)
        Me.fraRecipe.Location = New System.Drawing.Point(4, 56)
        Me.fraRecipe.Name = "fraRecipe"
        Me.fraRecipe.Size = New System.Drawing.Size(482, 184)
        Me.fraRecipe.TabIndex = 104
        Me.fraRecipe.Text = "装置個別"
        '
        'vsfConditionList2
        '
        Me.vsfConditionList2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfConditionList2.AllowEditing = false
        Me.vsfConditionList2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfConditionList2.AutoResize = true
        Me.vsfConditionList2.AutoSearchDelay = 2R
        Me.vsfConditionList2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.vsfConditionList2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfConditionList2.ColumnInfo = resources.GetString("vsfConditionList2.ColumnInfo")
        Me.vsfConditionList2.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfConditionList2.ExtendLastCol = true
        Me.vsfConditionList2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfConditionList2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfConditionList2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfConditionList2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfConditionList2.Location = New System.Drawing.Point(0, 0)
        Me.vsfConditionList2.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfConditionList2.Name = "vsfConditionList2"
        Me.vsfConditionList2.Rows.Count = 15
        Me.vsfConditionList2.Rows.DefaultSize = 18
        Me.vsfConditionList2.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfConditionList2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfConditionList2.Size = New System.Drawing.Size(480, 182)
        Me.vsfConditionList2.StyleInfo = resources.GetString("vsfConditionList2.StyleInfo")
        Me.vsfConditionList2.TabIndex = 105
        '
        'fraRecipeAll
        '
        Me.fraRecipeAll.Controls.Add(Me.vsfConditionList3)
        Me.fraRecipeAll.Controls.Add(Me.vsfConditionWP)
        Me.fraRecipeAll.Location = New System.Drawing.Point(6, 56)
        Me.fraRecipeAll.Name = "fraRecipeAll"
        Me.fraRecipeAll.Size = New System.Drawing.Size(480, 186)
        Me.fraRecipeAll.TabIndex = 101
        Me.fraRecipeAll.Text = "装置共通"
        '
        'vsfConditionList3
        '
        Me.vsfConditionList3.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfConditionList3.AllowEditing = false
        Me.vsfConditionList3.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfConditionList3.AutoResize = true
        Me.vsfConditionList3.AutoSearchDelay = 2R
        Me.vsfConditionList3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.vsfConditionList3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfConditionList3.ColumnInfo = resources.GetString("vsfConditionList3.ColumnInfo")
        Me.vsfConditionList3.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfConditionList3.ExtendLastCol = true
        Me.vsfConditionList3.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfConditionList3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfConditionList3.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfConditionList3.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfConditionList3.Location = New System.Drawing.Point(244, 0)
        Me.vsfConditionList3.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfConditionList3.Name = "vsfConditionList3"
        Me.vsfConditionList3.Rows.Count = 15
        Me.vsfConditionList3.Rows.DefaultSize = 18
        Me.vsfConditionList3.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfConditionList3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
        Me.vsfConditionList3.Size = New System.Drawing.Size(236, 184)
        Me.vsfConditionList3.StyleInfo = resources.GetString("vsfConditionList3.StyleInfo")
        Me.vsfConditionList3.TabIndex = 102
        '
        'vsfConditionWP
        '
        Me.vsfConditionWP.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfConditionWP.AllowEditing = false
        Me.vsfConditionWP.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfConditionWP.AutoResize = true
        Me.vsfConditionWP.AutoSearchDelay = 2R
        Me.vsfConditionWP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.vsfConditionWP.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfConditionWP.ColumnInfo = resources.GetString("vsfConditionWP.ColumnInfo")
        Me.vsfConditionWP.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfConditionWP.ExtendLastCol = true
        Me.vsfConditionWP.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfConditionWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfConditionWP.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfConditionWP.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfConditionWP.Location = New System.Drawing.Point(0, 0)
        Me.vsfConditionWP.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfConditionWP.Name = "vsfConditionWP"
        Me.vsfConditionWP.Rows.Count = 15
        Me.vsfConditionWP.Rows.DefaultSize = 18
        Me.vsfConditionWP.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfConditionWP.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfConditionWP.Size = New System.Drawing.Size(242, 184)
        Me.vsfConditionWP.StyleInfo = resources.GetString("vsfConditionWP.StyleInfo")
        Me.vsfConditionWP.TabIndex = 103
        '
        'Tab3
        '
        Me.Tab3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab3.Controls.Add(Me.lblTitle0)
        Me.Tab3.Controls.Add(Me.fraSelectCondition)
        Me.Tab3.Controls.Add(Me.fraSelectConItem)
        Me.Tab3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab3.ForeColor = System.Drawing.Color.Black
        Me.Tab3.Location = New System.Drawing.Point(4, 25)
        Me.Tab3.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Size = New System.Drawing.Size(862, 271)
        Me.Tab3.TabIndex = 3
        Me.Tab3.Text = "WF選択条件"
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(348, 18)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle0.TabIndex = 89
        Me.lblTitle0.Text = "選択ルール"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraSelectCondition
        '
        Me.fraSelectCondition.Controls.Add(Me.vsfSelectCondition)
        Me.fraSelectCondition.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSelectCondition.Location = New System.Drawing.Point(5, 12)
        Me.fraSelectCondition.Name = "fraSelectCondition"
        Me.fraSelectCondition.Size = New System.Drawing.Size(333, 250)
        Me.fraSelectCondition.TabIndex = 23
        Me.fraSelectCondition.TabStop = false
        '
        'vsfSelectCondition
        '
        Me.vsfSelectCondition.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSelectCondition.AllowEditing = false
        Me.vsfSelectCondition.AutoResize = true
        Me.vsfSelectCondition.AutoSearchDelay = 2R
        Me.vsfSelectCondition.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSelectCondition.ColumnInfo = resources.GetString("vsfSelectCondition.ColumnInfo")
        Me.vsfSelectCondition.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSelectCondition.ExtendLastCol = true
        Me.vsfSelectCondition.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSelectCondition.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSelectCondition.Location = New System.Drawing.Point(8, 18)
        Me.vsfSelectCondition.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSelectCondition.Name = "vsfSelectCondition"
        Me.vsfSelectCondition.Rows.Count = 15
        Me.vsfSelectCondition.Rows.DefaultSize = 18
        Me.vsfSelectCondition.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSelectCondition.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSelectCondition.Size = New System.Drawing.Size(313, 218)
        Me.vsfSelectCondition.StyleInfo = resources.GetString("vsfSelectCondition.StyleInfo")
        Me.vsfSelectCondition.TabIndex = 23
        '
        'fraSelectConItem
        '
        Me.fraSelectConItem.Controls.Add(Me.fraSlotNo)
        Me.fraSelectConItem.Controls.Add(Me.fraWFNo)
        Me.fraSelectConItem.Controls.Add(Me.fraUserSelect)
        Me.fraSelectConItem.Controls.Add(Me.lblSelectRule)
        Me.fraSelectConItem.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSelectConItem.Location = New System.Drawing.Point(348, 10)
        Me.fraSelectConItem.Name = "fraSelectConItem"
        Me.fraSelectConItem.Size = New System.Drawing.Size(462, 256)
        Me.fraSelectConItem.TabIndex = 38
        Me.fraSelectConItem.Text = "Frame2"
        '
        'fraSlotNo
        '
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo1)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo6)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo11)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo16)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo21)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo2)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo7)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo12)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo17)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo22)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo3)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo8)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo13)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo18)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo23)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo4)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo9)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo14)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo19)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo24)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo5)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo10)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo15)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo20)
        Me.fraSlotNo.Controls.Add(Me.chkSlotNo25)
        Me.fraSlotNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotNo.Location = New System.Drawing.Point(0, 92)
        Me.fraSlotNo.Name = "fraSlotNo"
        Me.fraSlotNo.Size = New System.Drawing.Size(377, 105)
        Me.fraSlotNo.TabIndex = 38
        Me.fraSlotNo.TabStop = false
        Me.fraSlotNo.Text = "スロットNo"
        '
        'chkSlotNo1
        '
        Me.chkSlotNo1.Location = New System.Drawing.Point(44, 16)
        Me.chkSlotNo1.Name = "chkSlotNo1"
        Me.chkSlotNo1.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo1.TabIndex = 38
        Me.chkSlotNo1.Text = "01"
        '
        'chkSlotNo6
        '
        Me.chkSlotNo6.Location = New System.Drawing.Point(108, 16)
        Me.chkSlotNo6.Name = "chkSlotNo6"
        Me.chkSlotNo6.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo6.TabIndex = 43
        Me.chkSlotNo6.Text = "06"
        '
        'chkSlotNo11
        '
        Me.chkSlotNo11.Location = New System.Drawing.Point(172, 16)
        Me.chkSlotNo11.Name = "chkSlotNo11"
        Me.chkSlotNo11.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo11.TabIndex = 48
        Me.chkSlotNo11.Text = "11"
        '
        'chkSlotNo16
        '
        Me.chkSlotNo16.Location = New System.Drawing.Point(236, 16)
        Me.chkSlotNo16.Name = "chkSlotNo16"
        Me.chkSlotNo16.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo16.TabIndex = 53
        Me.chkSlotNo16.Text = "16"
        '
        'chkSlotNo21
        '
        Me.chkSlotNo21.Location = New System.Drawing.Point(300, 16)
        Me.chkSlotNo21.Name = "chkSlotNo21"
        Me.chkSlotNo21.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo21.TabIndex = 58
        Me.chkSlotNo21.Text = "21"
        '
        'chkSlotNo2
        '
        Me.chkSlotNo2.Location = New System.Drawing.Point(44, 32)
        Me.chkSlotNo2.Name = "chkSlotNo2"
        Me.chkSlotNo2.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo2.TabIndex = 39
        Me.chkSlotNo2.Text = "02"
        '
        'chkSlotNo7
        '
        Me.chkSlotNo7.Location = New System.Drawing.Point(108, 32)
        Me.chkSlotNo7.Name = "chkSlotNo7"
        Me.chkSlotNo7.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo7.TabIndex = 44
        Me.chkSlotNo7.Text = "07"
        '
        'chkSlotNo12
        '
        Me.chkSlotNo12.Location = New System.Drawing.Point(172, 32)
        Me.chkSlotNo12.Name = "chkSlotNo12"
        Me.chkSlotNo12.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo12.TabIndex = 49
        Me.chkSlotNo12.Text = "12"
        '
        'chkSlotNo17
        '
        Me.chkSlotNo17.Location = New System.Drawing.Point(236, 32)
        Me.chkSlotNo17.Name = "chkSlotNo17"
        Me.chkSlotNo17.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo17.TabIndex = 54
        Me.chkSlotNo17.Text = "17"
        '
        'chkSlotNo22
        '
        Me.chkSlotNo22.Location = New System.Drawing.Point(300, 32)
        Me.chkSlotNo22.Name = "chkSlotNo22"
        Me.chkSlotNo22.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo22.TabIndex = 59
        Me.chkSlotNo22.Text = "22"
        '
        'chkSlotNo3
        '
        Me.chkSlotNo3.Location = New System.Drawing.Point(44, 48)
        Me.chkSlotNo3.Name = "chkSlotNo3"
        Me.chkSlotNo3.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo3.TabIndex = 40
        Me.chkSlotNo3.Text = "03"
        '
        'chkSlotNo8
        '
        Me.chkSlotNo8.Location = New System.Drawing.Point(108, 48)
        Me.chkSlotNo8.Name = "chkSlotNo8"
        Me.chkSlotNo8.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo8.TabIndex = 45
        Me.chkSlotNo8.Text = "08"
        '
        'chkSlotNo13
        '
        Me.chkSlotNo13.Location = New System.Drawing.Point(172, 48)
        Me.chkSlotNo13.Name = "chkSlotNo13"
        Me.chkSlotNo13.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo13.TabIndex = 50
        Me.chkSlotNo13.Text = "13"
        '
        'chkSlotNo18
        '
        Me.chkSlotNo18.Location = New System.Drawing.Point(236, 48)
        Me.chkSlotNo18.Name = "chkSlotNo18"
        Me.chkSlotNo18.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo18.TabIndex = 55
        Me.chkSlotNo18.Text = "18"
        '
        'chkSlotNo23
        '
        Me.chkSlotNo23.Location = New System.Drawing.Point(300, 48)
        Me.chkSlotNo23.Name = "chkSlotNo23"
        Me.chkSlotNo23.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo23.TabIndex = 60
        Me.chkSlotNo23.Text = "23"
        '
        'chkSlotNo4
        '
        Me.chkSlotNo4.Location = New System.Drawing.Point(44, 64)
        Me.chkSlotNo4.Name = "chkSlotNo4"
        Me.chkSlotNo4.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo4.TabIndex = 41
        Me.chkSlotNo4.Text = "04"
        '
        'chkSlotNo9
        '
        Me.chkSlotNo9.Location = New System.Drawing.Point(108, 64)
        Me.chkSlotNo9.Name = "chkSlotNo9"
        Me.chkSlotNo9.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo9.TabIndex = 46
        Me.chkSlotNo9.Text = "09"
        '
        'chkSlotNo14
        '
        Me.chkSlotNo14.Location = New System.Drawing.Point(172, 64)
        Me.chkSlotNo14.Name = "chkSlotNo14"
        Me.chkSlotNo14.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo14.TabIndex = 51
        Me.chkSlotNo14.Text = "14"
        '
        'chkSlotNo19
        '
        Me.chkSlotNo19.Location = New System.Drawing.Point(236, 64)
        Me.chkSlotNo19.Name = "chkSlotNo19"
        Me.chkSlotNo19.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo19.TabIndex = 56
        Me.chkSlotNo19.Text = "19"
        '
        'chkSlotNo24
        '
        Me.chkSlotNo24.Location = New System.Drawing.Point(300, 64)
        Me.chkSlotNo24.Name = "chkSlotNo24"
        Me.chkSlotNo24.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo24.TabIndex = 61
        Me.chkSlotNo24.Text = "24"
        '
        'chkSlotNo5
        '
        Me.chkSlotNo5.Location = New System.Drawing.Point(44, 80)
        Me.chkSlotNo5.Name = "chkSlotNo5"
        Me.chkSlotNo5.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo5.TabIndex = 42
        Me.chkSlotNo5.Text = "05"
        '
        'chkSlotNo10
        '
        Me.chkSlotNo10.Location = New System.Drawing.Point(108, 80)
        Me.chkSlotNo10.Name = "chkSlotNo10"
        Me.chkSlotNo10.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo10.TabIndex = 47
        Me.chkSlotNo10.Text = "10"
        '
        'chkSlotNo15
        '
        Me.chkSlotNo15.Location = New System.Drawing.Point(172, 80)
        Me.chkSlotNo15.Name = "chkSlotNo15"
        Me.chkSlotNo15.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo15.TabIndex = 52
        Me.chkSlotNo15.Text = "15"
        '
        'chkSlotNo20
        '
        Me.chkSlotNo20.Location = New System.Drawing.Point(236, 80)
        Me.chkSlotNo20.Name = "chkSlotNo20"
        Me.chkSlotNo20.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo20.TabIndex = 57
        Me.chkSlotNo20.Text = "20"
        '
        'chkSlotNo25
        '
        Me.chkSlotNo25.Location = New System.Drawing.Point(300, 80)
        Me.chkSlotNo25.Name = "chkSlotNo25"
        Me.chkSlotNo25.Size = New System.Drawing.Size(42, 17)
        Me.chkSlotNo25.TabIndex = 62
        Me.chkSlotNo25.Text = "25"
        '
        'fraWFNo
        '
        Me.fraWFNo.Controls.Add(Me.lblWFMiddle)
        Me.fraWFNo.Controls.Add(Me.lblWFNo2)
        Me.fraWFNo.Controls.Add(Me.lblWFNoMiddle)
        Me.fraWFNo.Controls.Add(Me.lblWFDown)
        Me.fraWFNo.Controls.Add(Me.lblWFUp)
        Me.fraWFNo.Controls.Add(Me.lblWFNoUp)
        Me.fraWFNo.Controls.Add(Me.lblWFNoDown)
        Me.fraWFNo.Controls.Add(Me.lblWFNo1)
        Me.fraWFNo.Controls.Add(Me.lblWFNo0)
        Me.fraWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraWFNo.Location = New System.Drawing.Point(0, 47)
        Me.fraWFNo.Name = "fraWFNo"
        Me.fraWFNo.Size = New System.Drawing.Size(377, 43)
        Me.fraWFNo.TabIndex = 83
        Me.fraWFNo.TabStop = false
        Me.fraWFNo.Text = "WF枚数"
        '
        'lblWFMiddle
        '
        Me.lblWFMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFMiddle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFMiddle.Location = New System.Drawing.Point(196, 17)
        Me.lblWFMiddle.Name = "lblWFMiddle"
        Me.lblWFMiddle.Size = New System.Drawing.Size(26, 22)
        Me.lblWFMiddle.TabIndex = 111
        Me.lblWFMiddle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo2
        '
        Me.lblWFNo2.Location = New System.Drawing.Point(226, 19)
        Me.lblWFNo2.Name = "lblWFNo2"
        Me.lblWFNo2.Size = New System.Drawing.Size(25, 17)
        Me.lblWFNo2.TabIndex = 113
        Me.lblWFNo2.Text = "枚"
        '
        'lblWFNoMiddle
        '
        Me.lblWFNoMiddle.Location = New System.Drawing.Point(128, 19)
        Me.lblWFNoMiddle.Name = "lblWFNoMiddle"
        Me.lblWFNoMiddle.Size = New System.Drawing.Size(71, 17)
        Me.lblWFNoMiddle.TabIndex = 112
        Me.lblWFNoMiddle.Text = "真中から"
        '
        'lblWFDown
        '
        Me.lblWFDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFDown.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFDown.Location = New System.Drawing.Point(316, 17)
        Me.lblWFDown.Name = "lblWFDown"
        Me.lblWFDown.Size = New System.Drawing.Size(26, 22)
        Me.lblWFDown.TabIndex = 93
        Me.lblWFDown.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFUp
        '
        Me.lblWFUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFUp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFUp.Location = New System.Drawing.Point(60, 17)
        Me.lblWFUp.Name = "lblWFUp"
        Me.lblWFUp.Size = New System.Drawing.Size(26, 22)
        Me.lblWFUp.TabIndex = 92
        Me.lblWFUp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNoUp
        '
        Me.lblWFNoUp.Location = New System.Drawing.Point(8, 19)
        Me.lblWFNoUp.Name = "lblWFNoUp"
        Me.lblWFNoUp.Size = New System.Drawing.Size(57, 17)
        Me.lblWFNoUp.TabIndex = 87
        Me.lblWFNoUp.Text = "上から"
        '
        'lblWFNoDown
        '
        Me.lblWFNoDown.Location = New System.Drawing.Point(264, 19)
        Me.lblWFNoDown.Name = "lblWFNoDown"
        Me.lblWFNoDown.Size = New System.Drawing.Size(57, 17)
        Me.lblWFNoDown.TabIndex = 86
        Me.lblWFNoDown.Text = "下から"
        '
        'lblWFNo1
        '
        Me.lblWFNo1.Location = New System.Drawing.Point(346, 19)
        Me.lblWFNo1.Name = "lblWFNo1"
        Me.lblWFNo1.Size = New System.Drawing.Size(25, 17)
        Me.lblWFNo1.TabIndex = 85
        Me.lblWFNo1.Text = "枚"
        '
        'lblWFNo0
        '
        Me.lblWFNo0.Location = New System.Drawing.Point(88, 19)
        Me.lblWFNo0.Name = "lblWFNo0"
        Me.lblWFNo0.Size = New System.Drawing.Size(25, 17)
        Me.lblWFNo0.TabIndex = 84
        Me.lblWFNo0.Text = "枚"
        '
        'fraUserSelect
        '
        Me.fraUserSelect.Controls.Add(Me.chkUserSelect)
        Me.fraUserSelect.Controls.Add(Me.lblUserSelect)
        Me.fraUserSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraUserSelect.Location = New System.Drawing.Point(0, 198)
        Me.fraUserSelect.Name = "fraUserSelect"
        Me.fraUserSelect.Size = New System.Drawing.Size(377, 55)
        Me.fraUserSelect.TabIndex = 63
        Me.fraUserSelect.TabStop = false
        Me.fraUserSelect.Text = "ユーザー選択"
        '
        'chkUserSelect
        '
        Me.chkUserSelect.Location = New System.Drawing.Point(16, 20)
        Me.chkUserSelect.Name = "chkUserSelect"
        Me.chkUserSelect.Size = New System.Drawing.Size(65, 18)
        Me.chkUserSelect.TabIndex = 63
        Me.chkUserSelect.Text = "可能"
        '
        'lblUserSelect
        '
        Me.lblUserSelect.Location = New System.Drawing.Point(80, 15)
        Me.lblUserSelect.Name = "lblUserSelect"
        Me.lblUserSelect.Size = New System.Drawing.Size(291, 37)
        Me.lblUserSelect.TabIndex = 82
        Me.lblUserSelect.Text = "～処理WFのレシピをスペースに"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"   変更することが可能になります。"
        '
        'lblSelectRule
        '
        Me.lblSelectRule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSelectRule.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSelectRule.Location = New System.Drawing.Point(0, 24)
        Me.lblSelectRule.Name = "lblSelectRule"
        Me.lblSelectRule.Size = New System.Drawing.Size(256, 22)
        Me.lblSelectRule.TabIndex = 91
        '
        'Tab4
        '
        Me.Tab4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab4.Controls.Add(Me.fraCollection2)
        Me.Tab4.Controls.Add(Me.fraCollection1)
        Me.Tab4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab4.ForeColor = System.Drawing.Color.Black
        Me.Tab4.Location = New System.Drawing.Point(4, 25)
        Me.Tab4.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab4.Name = "Tab4"
        Me.Tab4.Size = New System.Drawing.Size(862, 271)
        Me.Tab4.TabIndex = 4
        Me.Tab4.Text = "作業記録"
        '
        'fraCollection2
        '
        Me.fraCollection2.Controls.Add(Me.vsfCollectionPara)
        Me.fraCollection2.Location = New System.Drawing.Point(473, 13)
        Me.fraCollection2.Name = "fraCollection2"
        Me.fraCollection2.Size = New System.Drawing.Size(385, 250)
        Me.fraCollection2.TabIndex = 27
        Me.fraCollection2.TabStop = false
        Me.fraCollection2.Text = "作業記録セットID　詳細"
        '
        'vsfCollectionPara
        '
        Me.vsfCollectionPara.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCollectionPara.AllowEditing = false
        Me.vsfCollectionPara.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfCollectionPara.AutoResize = true
        Me.vsfCollectionPara.AutoSearchDelay = 2R
        Me.vsfCollectionPara.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.vsfCollectionPara.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCollectionPara.ColumnInfo = resources.GetString("vsfCollectionPara.ColumnInfo")
        Me.vsfCollectionPara.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCollectionPara.ExtendLastCol = true
        Me.vsfCollectionPara.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfCollectionPara.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCollectionPara.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfCollectionPara.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCollectionPara.Location = New System.Drawing.Point(9, 56)
        Me.vsfCollectionPara.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCollectionPara.Name = "vsfCollectionPara"
        Me.vsfCollectionPara.Rows.Count = 5
        Me.vsfCollectionPara.Rows.DefaultSize = 18
        Me.vsfCollectionPara.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCollectionPara.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfCollectionPara.Size = New System.Drawing.Size(367, 182)
        Me.vsfCollectionPara.StyleInfo = resources.GetString("vsfCollectionPara.StyleInfo")
        Me.vsfCollectionPara.TabIndex = 27
        '
        'fraCollection1
        '
        Me.fraCollection1.Controls.Add(Me.chkValidCollection)
        Me.fraCollection1.Controls.Add(Me.vsfCollectionList)
        Me.fraCollection1.Controls.Add(Me.cmbCollectionCategory)
        Me.fraCollection1.Controls.Add(Me.lblTitle7)
        Me.fraCollection1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCollection1.Location = New System.Drawing.Point(5, 12)
        Me.fraCollection1.Name = "fraCollection1"
        Me.fraCollection1.Size = New System.Drawing.Size(461, 250)
        Me.fraCollection1.TabIndex = 24
        Me.fraCollection1.TabStop = false
        '
        'chkValidCollection
        '
        Me.chkValidCollection.Checked = true
        Me.chkValidCollection.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkValidCollection.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkValidCollection.Location = New System.Drawing.Point(284, 13)
        Me.chkValidCollection.Name = "chkValidCollection"
        Me.chkValidCollection.Size = New System.Drawing.Size(65, 41)
        Me.chkValidCollection.TabIndex = 25
        Me.chkValidCollection.Text = "有効のみ"
        '
        'vsfCollectionList
        '
        Me.vsfCollectionList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCollectionList.AllowEditing = false
        Me.vsfCollectionList.AutoResize = true
        Me.vsfCollectionList.AutoSearchDelay = 2R
        Me.vsfCollectionList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCollectionList.ColumnInfo = resources.GetString("vsfCollectionList.ColumnInfo")
        Me.vsfCollectionList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCollectionList.ExtendLastCol = true
        Me.vsfCollectionList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCollectionList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCollectionList.Location = New System.Drawing.Point(8, 57)
        Me.vsfCollectionList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCollectionList.Name = "vsfCollectionList"
        Me.vsfCollectionList.Rows.Count = 4
        Me.vsfCollectionList.Rows.DefaultSize = 18
        Me.vsfCollectionList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCollectionList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCollectionList.Size = New System.Drawing.Size(444, 182)
        Me.vsfCollectionList.StyleInfo = resources.GetString("vsfCollectionList.StyleInfo")
        Me.vsfCollectionList.TabIndex = 26
        '
        'cmbCollectionCategory
        '
        Me.cmbCollectionCategory.DirectInput = false
        Me.cmbCollectionCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCollectionCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCollectionCategory.Location = New System.Drawing.Point(8, 29)
        Me.cmbCollectionCategory.Name = "cmbCollectionCategory"
        Me.cmbCollectionCategory.Size = New System.Drawing.Size(264, 22)
        Me.cmbCollectionCategory.TabIndex = 24
        Me.cmbCollectionCategory.Value = Nothing
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(8, 13)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(264, 17)
        Me.lblTitle7.TabIndex = 78
        Me.lblTitle7.Text = "カテゴリ"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Tab5
        '
        Me.Tab5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab5.Controls.Add(Me.fraScrap1)
        Me.Tab5.Controls.Add(Me.fraScrap0)
        Me.Tab5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab5.ForeColor = System.Drawing.Color.Black
        Me.Tab5.Location = New System.Drawing.Point(4, 25)
        Me.Tab5.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab5.Name = "Tab5"
        Me.Tab5.Size = New System.Drawing.Size(862, 271)
        Me.Tab5.TabIndex = 5
        Me.Tab5.Text = "不良項目"
        '
        'fraScrap1
        '
        Me.fraScrap1.Controls.Add(Me.vsfScrapList)
        Me.fraScrap1.Location = New System.Drawing.Point(267, 13)
        Me.fraScrap1.Name = "fraScrap1"
        Me.fraScrap1.Size = New System.Drawing.Size(368, 250)
        Me.fraScrap1.TabIndex = 29
        Me.fraScrap1.TabStop = false
        Me.fraScrap1.Text = "不良セットID　詳細"
        '
        'vsfScrapList
        '
        Me.vsfScrapList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfScrapList.AllowEditing = false
        Me.vsfScrapList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfScrapList.AutoResize = true
        Me.vsfScrapList.AutoSearchDelay = 2R
        Me.vsfScrapList.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.vsfScrapList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfScrapList.ColumnInfo = resources.GetString("vsfScrapList.ColumnInfo")
        Me.vsfScrapList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfScrapList.ExtendLastCol = true
        Me.vsfScrapList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfScrapList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfScrapList.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfScrapList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfScrapList.Location = New System.Drawing.Point(15, 17)
        Me.vsfScrapList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfScrapList.Name = "vsfScrapList"
        Me.vsfScrapList.Rows.Count = 3
        Me.vsfScrapList.Rows.DefaultSize = 18
        Me.vsfScrapList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfScrapList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfScrapList.Size = New System.Drawing.Size(337, 218)
        Me.vsfScrapList.StyleInfo = resources.GetString("vsfScrapList.StyleInfo")
        Me.vsfScrapList.TabIndex = 29
        '
        'fraScrap0
        '
        Me.fraScrap0.Controls.Add(Me.vsfLotScrapSetID)
        Me.fraScrap0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraScrap0.Location = New System.Drawing.Point(5, 12)
        Me.fraScrap0.Name = "fraScrap0"
        Me.fraScrap0.Size = New System.Drawing.Size(253, 250)
        Me.fraScrap0.TabIndex = 28
        Me.fraScrap0.TabStop = false
        '
        'vsfLotScrapSetID
        '
        Me.vsfLotScrapSetID.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotScrapSetID.AllowEditing = false
        Me.vsfLotScrapSetID.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotScrapSetID.AutoResize = true
        Me.vsfLotScrapSetID.AutoSearchDelay = 2R
        Me.vsfLotScrapSetID.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotScrapSetID.ColumnInfo = "2,0,0,0,0,105,Columns:0{Width:33;Caption:""№"";StyleFixed:""TextAlign:CenterCenter;"""& _ 
    ";}"&Global.Microsoft.VisualBasic.ChrW(9)&"1{Width:133;Caption:""不良項目セットID"";Style:""TextAlign:LeftCenter;"";StyleFixed:""Tex"& _ 
    "tAlign:CenterCenter;"";}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfLotScrapSetID.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotScrapSetID.ExtendLastCol = true
        Me.vsfLotScrapSetID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotScrapSetID.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotScrapSetID.Location = New System.Drawing.Point(18, 18)
        Me.vsfLotScrapSetID.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotScrapSetID.Name = "vsfLotScrapSetID"
        Me.vsfLotScrapSetID.Rows.Count = 3
        Me.vsfLotScrapSetID.Rows.DefaultSize = 18
        Me.vsfLotScrapSetID.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotScrapSetID.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotScrapSetID.Size = New System.Drawing.Size(217, 218)
        Me.vsfLotScrapSetID.StyleInfo = resources.GetString("vsfLotScrapSetID.StyleInfo")
        Me.vsfLotScrapSetID.TabIndex = 28
        '
        'vsfFlowList0
        '
        Me.vsfFlowList0.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfFlowList0.AllowEditing = false
        Me.vsfFlowList0.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfFlowList0.AutoResize = true
        Me.vsfFlowList0.AutoSearchDelay = 2R
        Me.vsfFlowList0.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfFlowList0.ColumnInfo = resources.GetString("vsfFlowList0.ColumnInfo")
        Me.vsfFlowList0.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfFlowList0.ExtendLastCol = true
        Me.vsfFlowList0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfFlowList0.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfFlowList0.Location = New System.Drawing.Point(8, 80)
        Me.vsfFlowList0.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFlowList0.Name = "vsfFlowList0"
        Me.vsfFlowList0.Rows.Count = 30
        Me.vsfFlowList0.Rows.DefaultSize = 18
        Me.vsfFlowList0.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFlowList0.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
        Me.vsfFlowList0.Size = New System.Drawing.Size(428, 216)
        Me.vsfFlowList0.StyleInfo = resources.GetString("vsfFlowList0.StyleInfo")
        Me.vsfFlowList0.TabIndex = 0
        '
        'vsfFlowList1
        '
        Me.vsfFlowList1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfFlowList1.AllowEditing = false
        Me.vsfFlowList1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfFlowList1.AutoResize = true
        Me.vsfFlowList1.AutoSearchDelay = 2R
        Me.vsfFlowList1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfFlowList1.ColumnInfo = resources.GetString("vsfFlowList1.ColumnInfo")
        Me.vsfFlowList1.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfFlowList1.ExtendLastCol = true
        Me.vsfFlowList1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfFlowList1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfFlowList1.Location = New System.Drawing.Point(448, 80)
        Me.vsfFlowList1.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFlowList1.Name = "vsfFlowList1"
        Me.vsfFlowList1.Rows.Count = 30
        Me.vsfFlowList1.Rows.DefaultSize = 18
        Me.vsfFlowList1.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFlowList1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
        Me.vsfFlowList1.Size = New System.Drawing.Size(428, 216)
        Me.vsfFlowList1.StyleInfo = resources.GetString("vsfFlowList1.StyleInfo")
        Me.vsfFlowList1.TabIndex = 1
        Me.vsfFlowList1.Visible = false
        '
        'cmbResize
        '
        Me.cmbResize.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbResize.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbResize.Location = New System.Drawing.Point(886, 556)
        Me.cmbResize.Name = "cmbResize"
        Me.cmbResize.Size = New System.Drawing.Size(87, 22)
        Me.cmbResize.TabIndex = 99
        Me.cmbResize.Value = Nothing
        '
        'lblFlowList1
        '
        Me.lblFlowList1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowList1.Location = New System.Drawing.Point(448, 64)
        Me.lblFlowList1.Name = "lblFlowList1"
        Me.lblFlowList1.Size = New System.Drawing.Size(527, 15)
        Me.lblFlowList1.TabIndex = 98
        Me.lblFlowList1.Text = "【コピー元工順 】"
        '
        'lblFlowList0
        '
        Me.lblFlowList0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowList0.Location = New System.Drawing.Point(8, 64)
        Me.lblFlowList0.Name = "lblFlowList0"
        Me.lblFlowList0.Size = New System.Drawing.Size(427, 15)
        Me.lblFlowList0.TabIndex = 97
        Me.lblFlowList0.Text = "【変更中工順】"
        '
        'mnu1
        '
        Me.mnu1.AutoSize = false
        Me.mnu1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mnu1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.mnu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu11, Me.mnu12, Me.mnu13})
        Me.mnu1.Name = "mnu1"
        Me.mnu1.ShowImageMargin = false
        Me.mnu1.Size = New System.Drawing.Size(152, 55)
        Me.mnu1.Text = "行コピー"
        '
        'mnu11
        '
        Me.mnu11.AutoSize = false
        Me.mnu11.Name = "mnu11"
        Me.mnu11.Size = New System.Drawing.Size(151, 17)
        Me.mnu11.Text = "コピー"
        '
        'mnu12
        '
        Me.mnu12.AutoSize = false
        Me.mnu12.Name = "mnu12"
        Me.mnu12.Size = New System.Drawing.Size(151, 17)
        Me.mnu12.Text = "コピーした行を上へ挿入"
        '
        'mnu13
        '
        Me.mnu13.AutoSize = false
        Me.mnu13.Name = "mnu13"
        Me.mnu13.Size = New System.Drawing.Size(151, 17)
        Me.mnu13.Text = "コピーした行を下へ挿入"
        '
        'mnu21
        '
        Me.mnu21.AutoSize = false
        Me.mnu21.Name = "mnu21"
        Me.mnu21.ShortcutKeyDisplayString = "Ctrl+C"
        Me.mnu21.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C),System.Windows.Forms.Keys)
        Me.mnu21.Size = New System.Drawing.Size(122, 17)
        Me.mnu21.Text = "コピー "
        '
        'mnu22
        '
        Me.mnu22.AutoSize = false
        Me.mnu22.Name = "mnu22"
        Me.mnu22.ShortcutKeyDisplayString = "Ctrl+V"
        Me.mnu22.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V),System.Windows.Forms.Keys)
        Me.mnu22.Size = New System.Drawing.Size(122, 17)
        Me.mnu22.Text = "貼り付け"
        '
        'mnu23
        '
        Me.mnu23.AutoSize = false
        Me.mnu23.Name = "mnu23"
        Me.mnu23.ShortcutKeyDisplayString = "Del"
        Me.mnu23.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.mnu23.Size = New System.Drawing.Size(122, 17)
        Me.mnu23.Text = "削除"
        '
        'mnu31
        '
        Me.mnu31.AutoSize = false
        Me.mnu31.Name = "mnu31"
        Me.mnu31.Size = New System.Drawing.Size(127, 17)
        Me.mnu31.Text = "時間制限開始"
        '
        'mnu32
        '
        Me.mnu32.AutoSize = false
        Me.mnu32.Name = "mnu32"
        Me.mnu32.Size = New System.Drawing.Size(127, 17)
        Me.mnu32.Text = "時間制限終了"
        '
        'mnu3b
        '
        Me.mnu3b.AutoSize = false
        Me.mnu3b.Name = "mnu3b"
        Me.mnu3b.Size = New System.Drawing.Size(127, 15)
        Me.mnu3b.Text = "---------------"
        '
        'mnu33
        '
        Me.mnu33.AutoSize = false
        Me.mnu33.Name = "mnu33"
        Me.mnu33.Size = New System.Drawing.Size(127, 17)
        Me.mnu33.Text = "処理時間制限"
        '
        'mnu41
        '
        Me.mnu41.AutoSize = false
        Me.mnu41.Name = "mnu41"
        Me.mnu41.Size = New System.Drawing.Size(59, 17)
        Me.mnu41.Text = "設定"
        '
        'mnu42
        '
        Me.mnu42.AutoSize = false
        Me.mnu42.Name = "mnu42"
        Me.mnu42.Size = New System.Drawing.Size(59, 17)
        Me.mnu42.Text = "削除"
        '
        'mnu51
        '
        Me.mnu51.AutoSize = false
        Me.mnu51.Name = "mnu51"
        Me.mnu51.Size = New System.Drawing.Size(62, 17)
        Me.mnu51.Text = "コピー"
        '
        'mnu61
        '
        Me.mnu61.AutoSize = false
        Me.mnu61.Name = "mnu61"
        Me.mnu61.Size = New System.Drawing.Size(118, 17)
        Me.mnu61.Text = "コピー     Ctrl+C"
        '
        'mnu71
        '
        Me.mnu71.AutoSize = false
        Me.mnu71.Name = "mnu71"
        Me.mnu71.Size = New System.Drawing.Size(107, 17)
        Me.mnu71.Text = "号機記憶"
        '
        'mnu7b
        '
        Me.mnu7b.AutoSize = false
        Me.mnu7b.Enabled = false
        Me.mnu7b.Name = "mnu7b"
        Me.mnu7b.Size = New System.Drawing.Size(107, 15)
        Me.mnu7b.Text = "------------"
        '
        'mnu72
        '
        Me.mnu72.AutoSize = false
        Me.mnu72.Name = "mnu72"
        Me.mnu72.Size = New System.Drawing.Size(107, 17)
        Me.mnu72.Text = "号機限定"
        '
        'mnu8A
        '
        Me.mnu8A.AutoSize = false
        Me.mnu8A.Enabled = false
        Me.mnu8A.Name = "mnu8A"
        Me.mnu8A.Size = New System.Drawing.Size(137, 16)
        Me.mnu8A.Text = "----蒸着処理----"
        '
        'mnu81
        '
        Me.mnu81.AutoSize = false
        Me.mnu81.Name = "mnu81"
        Me.mnu81.Size = New System.Drawing.Size(137, 17)
        Me.mnu81.Text = "[蒸]ﾊﾞｯﾁ貼合"
        '
        'mnu82
        '
        Me.mnu82.AutoSize = false
        Me.mnu82.Name = "mnu82"
        Me.mnu82.Size = New System.Drawing.Size(137, 17)
        Me.mnu82.Text = "[蒸]左貼合"
        '
        'mnu83
        '
        Me.mnu83.AutoSize = false
        Me.mnu83.Name = "mnu83"
        Me.mnu83.Size = New System.Drawing.Size(141, 17)
        Me.mnu83.Text = "[蒸]右貼合"
        '
        'mnu8B
        '
        Me.mnu8B.AutoSize = false
        Me.mnu8B.Enabled = false
        Me.mnu8B.Name = "mnu8B"
        Me.mnu8B.Size = New System.Drawing.Size(137, 16)
        Me.mnu8B.Text = "----蒸着処理----"
        '
        'mnu84
        '
        Me.mnu84.AutoSize = false
        Me.mnu84.Name = "mnu84"
        Me.mnu84.Size = New System.Drawing.Size(137, 17)
        Me.mnu84.Text = "[蒸](ﾊﾞｯﾁ＋左)貼合"
        '
        'mnu85
        '
        Me.mnu85.AutoSize = false
        Me.mnu85.Name = "mnu85"
        Me.mnu85.Size = New System.Drawing.Size(137, 17)
        Me.mnu85.Text = "[蒸](ﾊﾞｯﾁ＋右)貼合"
        '
        'mnu8C
        '
        Me.mnu8C.AutoSize = false
        Me.mnu8C.Enabled = false
        Me.mnu8C.Name = "mnu8C"
        Me.mnu8C.Size = New System.Drawing.Size(137, 16)
        Me.mnu8C.Text = "----表面処理----"
        '
        'mnu87
        '
        Me.mnu87.AutoSize = false
        Me.mnu87.Name = "mnu87"
        Me.mnu87.Size = New System.Drawing.Size(137, 17)
        Me.mnu87.Text = "[表]ﾊﾞｯﾁ貼合"
        '
        'mnu8D
        '
        Me.mnu8D.AutoSize = false
        Me.mnu8D.Enabled = false
        Me.mnu8D.Name = "mnu8D"
        Me.mnu8D.Size = New System.Drawing.Size(137, 15)
        Me.mnu8D.Text = "----------------"
        '
        'mnu86
        '
        Me.mnu86.AutoSize = false
        Me.mnu86.Name = "mnu86"
        Me.mnu86.Size = New System.Drawing.Size(137, 17)
        Me.mnu86.Text = "設定なし"
        '
        'mnu2
        '
        Me.mnu2.AutoSize = false
        Me.mnu2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mnu2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.mnu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu21, Me.mnu22, Me.mnu23})
        Me.mnu2.Name = "mnu2"
        Me.mnu2.ShowImageMargin = false
        Me.mnu2.Size = New System.Drawing.Size(123, 55)
        Me.mnu2.Text = "単コピー"
        '
        'mnu3
        '
        Me.mnu3.AutoSize = false
        Me.mnu3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mnu3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.mnu3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu31, Me.mnu32, Me.mnu3b, Me.mnu33})
        Me.mnu3.Name = "mnu3"
        Me.mnu3.ShowImageMargin = false
        Me.mnu3.Size = New System.Drawing.Size(128, 70)
        Me.mnu3.Text = "時間制限"
        '
        'mnu4
        '
        Me.mnu4.AutoSize = false
        Me.mnu4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mnu4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.mnu4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu41, Me.mnu42})
        Me.mnu4.Name = "mnu4"
        Me.mnu4.ShowImageMargin = false
        Me.mnu4.Size = New System.Drawing.Size(60, 38)
        Me.mnu4.Text = "入替可能工程"
        '
        'mnu5
        '
        Me.mnu5.AutoSize = false
        Me.mnu5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mnu5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.mnu5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu51})
        Me.mnu5.Name = "mnu5"
        Me.mnu5.ShowImageMargin = false
        Me.mnu5.Size = New System.Drawing.Size(64, 21)
        Me.mnu5.Text = "ロット間行コピー"
        '
        'mnu6
        '
        Me.mnu6.AutoSize = false
        Me.mnu6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mnu6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.mnu6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu61})
        Me.mnu6.Name = "mnu6"
        Me.mnu6.ShowImageMargin = false
        Me.mnu6.Size = New System.Drawing.Size(120, 21)
        Me.mnu6.Text = "ロット間単コピー"
        '
        'mnu7
        '
        Me.mnu7.AutoSize = false
        Me.mnu7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mnu7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.mnu7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu71, Me.mnu7b, Me.mnu72})
        Me.mnu7.Name = "mnu7"
        Me.mnu7.ShowImageMargin = false
        Me.mnu7.Size = New System.Drawing.Size(108, 53)
        Me.mnu7.Text = "処理号機"
        '
        'mnu8
        '
        Me.mnu8.AutoSize = false
        Me.mnu8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mnu8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.mnu8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu8A, Me.mnu81, Me.mnu82, Me.mnu83, Me.mnu8B, Me.mnu84, Me.mnu85, Me.mnu8C, Me.mnu87, Me.mnu8D, Me.mnu86})
        Me.mnu8.Name = "mnu8"
        Me.mnu8.ShowImageMargin = false
        Me.mnu8.Size = New System.Drawing.Size(138, 186)
        Me.mnu8.Text = "TPAL設定(無機用)"
        '
        'frmxxEN01X2
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.serchSetting)
        Me.Controls.Add(Me.cmdSpcSkipChkOn)
        Me.Controls.Add(Me.cmdEditStart)
        Me.Controls.Add(Me.cmdEntryDisp)
        Me.Controls.Add(Me.cmdMstEntry)
        Me.Controls.Add(Me.cmdLotEntry)
        Me.Controls.Add(Me.cmdApcSet)
        Me.Controls.Add(Me.cmdSave1)
        Me.Controls.Add(Me.cmdTimeLimitSet)
        Me.Controls.Add(Me.fraHeader)
        Me.Controls.Add(Me.cmdSetPanel)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdSave2)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.stbSetPanel)
        Me.Controls.Add(Me.vsfFlowList0)
        Me.Controls.Add(Me.vsfFlowList1)
        Me.Controls.Add(Me.cmbResize)
        Me.Controls.Add(Me.lblFlowList1)
        Me.Controls.Add(Me.lblFlowList0)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01X2"
        Me.Text = "ロット工順変更"
        Me.fraHeader.ResumeLayout(false)
        Me.fraHeader.PerformLayout
        Me.stbSetPanel.ResumeLayout(false)
        Me.Tab0.ResumeLayout(false)
        Me.fraOp.ResumeLayout(false)
        CType(Me.vsfOpList,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab1.ResumeLayout(false)
        Me.fraStep.ResumeLayout(false)
        CType(Me.vsfStepList,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab2.ResumeLayout(false)
        Me.fraCondition1.ResumeLayout(false)
        CType(Me.vsfConditionList1,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCondition2.ResumeLayout(false)
        Me.fraRecipe.ResumeLayout(false)
        CType(Me.vsfConditionList2,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraRecipeAll.ResumeLayout(false)
        CType(Me.vsfConditionList3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfConditionWP,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab3.ResumeLayout(false)
        Me.fraSelectCondition.ResumeLayout(false)
        CType(Me.vsfSelectCondition,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraSelectConItem.ResumeLayout(false)
        Me.fraSlotNo.ResumeLayout(false)
        Me.fraWFNo.ResumeLayout(false)
        Me.fraUserSelect.ResumeLayout(false)
        Me.Tab4.ResumeLayout(false)
        Me.fraCollection2.ResumeLayout(false)
        CType(Me.vsfCollectionPara,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCollection1.ResumeLayout(false)
        CType(Me.vsfCollectionList,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab5.ResumeLayout(false)
        Me.fraScrap1.ResumeLayout(false)
        CType(Me.vsfScrapList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraScrap0.ResumeLayout(false)
        CType(Me.vsfLotScrapSetID,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfFlowList0,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfFlowList1,System.ComponentModel.ISupportInitialize).EndInit
        Me.mnu1.ResumeLayout(false)
        Me.mnu2.ResumeLayout(false)
        Me.mnu3.ResumeLayout(false)
        Me.mnu4.ResumeLayout(false)
        Me.mnu5.ResumeLayout(false)
        Me.mnu6.ResumeLayout(false)
        Me.mnu7.ResumeLayout(false)
        Me.mnu8.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents serchSetting As Button
    Friend WithEvents cmdSpcSkipChkOn As Button
    Friend WithEvents cmdEditStart As Button
    Friend WithEvents cmdEntryDisp As Button
    Friend WithEvents cmdMstEntry As Button
    Friend WithEvents cmdLotEntry As Button
    Friend WithEvents cmdApcSet As Button
    Friend WithEvents cmdSave1 As Button
    Friend WithEvents cmdTimeLimitSet As Button
    Friend WithEvents fraHeader As Panel
    Friend WithEvents cmdCommentDown As Button
    Friend WithEvents cmdCommentUp As Button
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblCurrentStatus As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents cmdSetPanel As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdDel As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents cmdSave2 As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents stbSetPanel As TabControl
    Friend WithEvents Tab0 As TabPage
    Friend WithEvents fraOp As GroupBox
    Friend WithEvents chkValidOpID As CheckBox
    Friend WithEvents vsfOpList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbOpCategory As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents Tab1 As TabPage
    Friend WithEvents fraStep As GroupBox
    Friend WithEvents chkValidStepID As CheckBox
    Friend WithEvents cmbStepCategory As SEComboBoxEx.ComboBoxEx
    Friend WithEvents vsfStepList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents Tab2 As TabPage
    Friend WithEvents fraCondition1 As GroupBox
    Friend WithEvents chkMaxVer As CheckBox
    Friend WithEvents chkValidCondition As CheckBox
    Friend WithEvents vsfConditionList1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbConditionCategory As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents fraCondition2 As GroupBox
    Friend WithEvents cmdParCondition As Button
    Friend WithEvents fraRecipe As Panel
    Friend WithEvents vsfConditionList2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraRecipeAll As Panel
    Friend WithEvents vsfConditionList3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfConditionWP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Tab3 As TabPage
    Friend WithEvents fraSelectCondition As GroupBox
    Friend WithEvents vsfSelectCondition As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraSelectConItem As Panel
    Friend WithEvents fraSlotNo As GroupBox
    Friend WithEvents chkSlotNo1 As CheckBox
    Friend WithEvents chkSlotNo6 As CheckBox
    Friend WithEvents chkSlotNo11 As CheckBox
    Friend WithEvents chkSlotNo16 As CheckBox
    Friend WithEvents chkSlotNo21 As CheckBox
    Friend WithEvents chkSlotNo2 As CheckBox
    Friend WithEvents chkSlotNo7 As CheckBox
    Friend WithEvents chkSlotNo12 As CheckBox
    Friend WithEvents chkSlotNo17 As CheckBox
    Friend WithEvents chkSlotNo22 As CheckBox
    Friend WithEvents chkSlotNo3 As CheckBox
    Friend WithEvents chkSlotNo8 As CheckBox
    Friend WithEvents chkSlotNo13 As CheckBox
    Friend WithEvents chkSlotNo18 As CheckBox
    Friend WithEvents chkSlotNo23 As CheckBox
    Friend WithEvents chkSlotNo4 As CheckBox
    Friend WithEvents chkSlotNo9 As CheckBox
    Friend WithEvents chkSlotNo14 As CheckBox
    Friend WithEvents chkSlotNo19 As CheckBox
    Friend WithEvents chkSlotNo24 As CheckBox
    Friend WithEvents chkSlotNo5 As CheckBox
    Friend WithEvents chkSlotNo10 As CheckBox
    Friend WithEvents chkSlotNo15 As CheckBox
    Friend WithEvents chkSlotNo20 As CheckBox
    Friend WithEvents chkSlotNo25 As CheckBox
    Friend WithEvents fraWFNo As GroupBox
    Friend WithEvents lblWFMiddle As Label
    Friend WithEvents lblWFNo2 As Label
    Friend WithEvents lblWFNoMiddle As Label
    Friend WithEvents lblWFDown As Label
    Friend WithEvents lblWFUp As Label
    Friend WithEvents lblWFNoUp As Label
    Friend WithEvents lblWFNoDown As Label
    Friend WithEvents lblWFNo1 As Label
    Friend WithEvents lblWFNo0 As Label
    Friend WithEvents fraUserSelect As GroupBox
    Friend WithEvents chkUserSelect As CheckBox
    Friend WithEvents lblUserSelect As Label
    Friend WithEvents lblSelectRule As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents Tab4 As TabPage
    Friend WithEvents fraCollection2 As GroupBox
    Friend WithEvents vsfCollectionPara As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraCollection1 As GroupBox
    Friend WithEvents chkValidCollection As CheckBox
    Friend WithEvents vsfCollectionList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbCollectionCategory As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents Tab5 As TabPage
    Friend WithEvents fraScrap1 As GroupBox
    Friend WithEvents vsfScrapList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraScrap0 As GroupBox
    Friend WithEvents vsfLotScrapSetID As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfFlowList1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbResize As SECmbIchiran.ComboIchiran
    Friend WithEvents lblFlowList1 As Label
    Friend WithEvents lblFlowList0 As Label
    Friend WithEvents mnu1 As ContextMenuStrip
    Friend WithEvents mnu11 As ToolStripMenuItem
    Friend WithEvents mnu12 As ToolStripMenuItem
    Friend WithEvents mnu13 As ToolStripMenuItem
    Friend WithEvents mnu2 As ContextMenuStrip
    Friend WithEvents mnu21 As ToolStripMenuItem
    Friend WithEvents mnu22 As ToolStripMenuItem
    Friend WithEvents mnu23 As ToolStripMenuItem
    Friend WithEvents mnu3 As ContextMenuStrip
    Friend WithEvents mnu31 As ToolStripMenuItem
    Friend WithEvents mnu32 As ToolStripMenuItem
    Friend WithEvents mnu3b As ToolStripMenuItem
    Friend WithEvents mnu33 As ToolStripMenuItem
    Friend WithEvents mnu4 As ContextMenuStrip
    Friend WithEvents mnu41 As ToolStripMenuItem
    Friend WithEvents mnu42 As ToolStripMenuItem
    Friend WithEvents mnu5 As ContextMenuStrip
    Friend WithEvents mnu51 As ToolStripMenuItem
    Friend WithEvents mnu6 As ContextMenuStrip
    Friend WithEvents mnu61 As ToolStripMenuItem
    Friend WithEvents mnu7 As ContextMenuStrip
    Friend WithEvents mnu71 As ToolStripMenuItem
    Friend WithEvents mnu7b As ToolStripMenuItem
    Friend WithEvents mnu72 As ToolStripMenuItem
    Friend WithEvents mnu8 As ContextMenuStrip
    Friend WithEvents mnu8A As ToolStripMenuItem
    Friend WithEvents mnu81 As ToolStripMenuItem
    Friend WithEvents mnu82 As ToolStripMenuItem
    Friend WithEvents mnu83 As ToolStripMenuItem
    Friend WithEvents mnu8B As ToolStripMenuItem
    Friend WithEvents mnu84 As ToolStripMenuItem
    Friend WithEvents mnu85 As ToolStripMenuItem
    Friend WithEvents mnu8C As ToolStripMenuItem
    Friend WithEvents mnu87 As ToolStripMenuItem
    Friend WithEvents mnu8D As ToolStripMenuItem
    Friend WithEvents mnu86 As ToolStripMenuItem
    Public WithEvents vsfFlowList0 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
