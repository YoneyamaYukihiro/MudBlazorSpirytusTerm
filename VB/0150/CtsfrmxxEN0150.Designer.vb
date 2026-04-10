<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0150
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0150))
        Me.cmdLotConnectedInfoDisp = New System.Windows.Forms.Button()
        Me.cmdDummyDisCharge = New System.Windows.Forms.Button()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.cmdLotDetail = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmbWpID = New SECmbIchiran.ComboIchiran()
        Me.cmbMcGroupName = New SECmbIchiran.ComboIchiran()
        Me.cmdChgSeqNum = New System.Windows.Forms.Button()
        Me.cmdLotList = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfAreaEquipment = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbStockerName = New SECmbIchiran.ComboIchiran()
        Me.txtBCRCarrier = New SETextBoxEx.TextBoxEx()
        Me.labFrLimit = New System.Windows.Forms.Label()
        Me.lblTitleExecRestrictLot = New System.Windows.Forms.Label()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.lblBeforeRecipeFlowTitle = New System.Windows.Forms.Label()
        Me.lblRecipeRule = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblWpStatusName = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblYouto = New System.Windows.Forms.Label()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblTitleD = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        CType(Me.vsfAreaEquipment,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdLotConnectedInfoDisp
        '
        Me.cmdLotConnectedInfoDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotConnectedInfoDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotConnectedInfoDisp.Location = New System.Drawing.Point(224, 580)
        Me.cmdLotConnectedInfoDisp.Name = "cmdLotConnectedInfoDisp"
        Me.cmdLotConnectedInfoDisp.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotConnectedInfoDisp.TabIndex = 36
        Me.cmdLotConnectedInfoDisp.Text = "TFT/CF紐付"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"情報表示"
        '
        'cmdDummyDisCharge
        '
        Me.cmdDummyDisCharge.CausesValidation = false
        Me.cmdDummyDisCharge.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDummyDisCharge.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDummyDisCharge.Location = New System.Drawing.Point(440, 580)
        Me.cmdDummyDisCharge.Name = "cmdDummyDisCharge"
        Me.cmdDummyDisCharge.Size = New System.Drawing.Size(105, 57)
        Me.cmdDummyDisCharge.TabIndex = 30
        Me.cmdDummyDisCharge.Text = "ﾀﾞﾐｰｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"払出"
        '
        'cmdShip
        '
        Me.cmdShip.CausesValidation = false
        Me.cmdShip.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdShip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdShip.Location = New System.Drawing.Point(548, 580)
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.Size = New System.Drawing.Size(105, 57)
        Me.cmdShip.TabIndex = 5
        Me.cmdShip.Text = "出庫指示"
        '
        'cmdLotDetail
        '
        Me.cmdLotDetail.CausesValidation = false
        Me.cmdLotDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotDetail.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotDetail.Location = New System.Drawing.Point(116, 580)
        Me.cmdLotDetail.Name = "cmdLotDetail"
        Me.cmdLotDetail.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotDetail.TabIndex = 4
        Me.cmdLotDetail.Text = "ロット情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"詳細表示"
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(656, 580)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 6
        Me.cmdRegist.Text = "号機設定"
        '
        'cmbWpID
        '
        Me.cmbWpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpID.Location = New System.Drawing.Point(358, 22)
        Me.cmbWpID.Name = "cmbWpID"
        Me.cmbWpID.Size = New System.Drawing.Size(350, 28)
        Me.cmbWpID.TabIndex = 2
        Me.cmbWpID.Value = Nothing
        '
        'cmbMcGroupName
        '
        Me.cmbMcGroupName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.Location = New System.Drawing.Point(8, 22)
        Me.cmbMcGroupName.Name = "cmbMcGroupName"
        Me.cmbMcGroupName.Size = New System.Drawing.Size(350, 28)
        Me.cmbMcGroupName.TabIndex = 1
        Me.cmbMcGroupName.Value = Nothing
        '
        'cmdChgSeqNum
        '
        Me.cmdChgSeqNum.CausesValidation = false
        Me.cmdChgSeqNum.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChgSeqNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChgSeqNum.Location = New System.Drawing.Point(764, 580)
        Me.cmdChgSeqNum.Name = "cmdChgSeqNum"
        Me.cmdChgSeqNum.Size = New System.Drawing.Size(105, 57)
        Me.cmdChgSeqNum.TabIndex = 7
        Me.cmdChgSeqNum.Text = "処理順変更"
        '
        'cmdLotList
        '
        Me.cmdLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotList.Location = New System.Drawing.Point(711, 6)
        Me.cmdLotList.Name = "cmdLotList"
        Me.cmdLotList.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotList.TabIndex = 8
        Me.cmdLotList.Text = "最新取得"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 527)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(456, 49)
        Me.cmdLeft.TabIndex = 12
        Me.cmdLeft.Text = "<<"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(464, 527)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(457, 49)
        Me.cmdRight.TabIndex = 13
        Me.cmdRight.Text = ">>"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(920, 118)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 206)
        Me.cmdUP.TabIndex = 10
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(920, 323)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 205)
        Me.cmdDown.TabIndex = 11
        Me.cmdDown.Text = "▼"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 580)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.Text = "閉じる"
        '
        'vsfAreaEquipment
        '
        Me.vsfAreaEquipment.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfAreaEquipment.AllowEditing = false
        Me.vsfAreaEquipment.AutoSearchDelay = 2R
        Me.vsfAreaEquipment.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfAreaEquipment.ColumnInfo = resources.GetString("vsfAreaEquipment.ColumnInfo")
        Me.vsfAreaEquipment.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfAreaEquipment.ExtendLastCol = true
        Me.vsfAreaEquipment.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfAreaEquipment.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfAreaEquipment.Location = New System.Drawing.Point(8, 119)
        Me.vsfAreaEquipment.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfAreaEquipment.Name = "vsfAreaEquipment"
        Me.vsfAreaEquipment.Rows.Count = 40
        Me.vsfAreaEquipment.Rows.DefaultSize = 18
        Me.vsfAreaEquipment.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfAreaEquipment.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfAreaEquipment.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfAreaEquipment.Size = New System.Drawing.Size(912, 408)
        Me.vsfAreaEquipment.StyleInfo = resources.GetString("vsfAreaEquipment.StyleInfo")
        Me.vsfAreaEquipment.TabIndex = 3
        '
        'cmbStockerName
        '
        Me.cmbStockerName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStockerName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStockerName.Location = New System.Drawing.Point(485, 81)
        Me.cmbStockerName.Name = "cmbStockerName"
        Me.cmbStockerName.Size = New System.Drawing.Size(78, 28)
        Me.cmbStockerName.TabIndex = 9
        Me.cmbStockerName.Value = Nothing
        '
        'txtBCRCarrier
        '
        Me.txtBCRCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtBCRCarrier.ChrMaxByte = 6
        Me.txtBCRCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtBCRCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtBCRCarrier.Location = New System.Drawing.Point(562, 81)
        Me.txtBCRCarrier.Name = "txtBCRCarrier"
        Me.txtBCRCarrier.NgChr = "'"
        Me.txtBCRCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtBCRCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBCRCarrier.SelectedText = ""
        Me.txtBCRCarrier.Size = New System.Drawing.Size(57, 29)
        Me.txtBCRCarrier.TabIndex = 0
        '
        'labFrLimit
        '
        Me.labFrLimit.BackColor = System.Drawing.Color.LightGreen
        Me.labFrLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labFrLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labFrLimit.ForeColor = System.Drawing.Color.Black
        Me.labFrLimit.Location = New System.Drawing.Point(627, 73)
        Me.labFrLimit.Name = "labFrLimit"
        Me.labFrLimit.Size = New System.Drawing.Size(66, 19)
        Me.labFrLimit.TabIndex = 38
        Me.labFrLimit.Text = "FR時間"
        Me.labFrLimit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleExecRestrictLot
        '
        Me.lblTitleExecRestrictLot.BackColor = System.Drawing.Color.Silver
        Me.lblTitleExecRestrictLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleExecRestrictLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleExecRestrictLot.ForeColor = System.Drawing.Color.Black
        Me.lblTitleExecRestrictLot.Location = New System.Drawing.Point(627, 91)
        Me.lblTitleExecRestrictLot.Name = "lblTitleExecRestrictLot"
        Me.lblTitleExecRestrictLot.Size = New System.Drawing.Size(86, 19)
        Me.lblTitleExecRestrictLot.TabIndex = 37
        Me.lblTitleExecRestrictLot.Text = "処理限定"
        Me.lblTitleExecRestrictLot.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleChip
        '
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(712, 73)
        Me.lblTitleChip.Name = "lblTitleChip"
        Me.lblTitleChip.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleChip.TabIndex = 35
        Me.lblTitleChip.Text = "青字：Chip品"
        Me.lblTitleChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleChip.UseMnemonic = false
        '
        'lblBeforeRecipeFlowTitle
        '
        Me.lblBeforeRecipeFlowTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBeforeRecipeFlowTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBeforeRecipeFlowTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBeforeRecipeFlowTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBeforeRecipeFlowTitle.Location = New System.Drawing.Point(329, 65)
        Me.lblBeforeRecipeFlowTitle.Name = "lblBeforeRecipeFlowTitle"
        Me.lblBeforeRecipeFlowTitle.Size = New System.Drawing.Size(157, 17)
        Me.lblBeforeRecipeFlowTitle.TabIndex = 34
        Me.lblBeforeRecipeFlowTitle.Text = "処理順ルール"
        Me.lblBeforeRecipeFlowTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRecipeRule
        '
        Me.lblRecipeRule.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblRecipeRule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecipeRule.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRecipeRule.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRecipeRule.Location = New System.Drawing.Point(329, 81)
        Me.lblRecipeRule.Name = "lblRecipeRule"
        Me.lblRecipeRule.Size = New System.Drawing.Size(157, 29)
        Me.lblRecipeRule.TabIndex = 33
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(855, 73)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(34, 19)
        Me.lblTitleR.TabIndex = 32
        Me.lblTitleR.Text = "R"
        Me.lblTitleR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleR.UseMnemonic = false
        '
        'lblTitleL
        '
        Me.lblTitleL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleL.ForeColor = System.Drawing.Color.Black
        Me.lblTitleL.Location = New System.Drawing.Point(823, 73)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(33, 19)
        Me.lblTitleL.TabIndex = 31
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(485, 65)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(134, 17)
        Me.lblTitle10.TabIndex = 29
        Me.lblTitle10.Text = "ストッカー/BCR"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(213, 65)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(117, 17)
        Me.lblTitle3.TabIndex = 28
        Me.lblTitle3.Text = "処理状態"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWpStatusName
        '
        Me.lblWpStatusName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWpStatusName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpStatusName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpStatusName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWpStatusName.Location = New System.Drawing.Point(213, 81)
        Me.lblWpStatusName.Name = "lblWpStatusName"
        Me.lblWpStatusName.Size = New System.Drawing.Size(117, 29)
        Me.lblWpStatusName.TabIndex = 27
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(819, 22)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 30)
        Me.lblNowDate.TabIndex = 26
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(819, 6)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 25
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(8, 65)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(129, 17)
        Me.lblTitle8.TabIndex = 24
        Me.lblTitle8.Text = "装置状態"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(136, 65)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(78, 17)
        Me.lblTitle7.TabIndex = 23
        Me.lblTitle7.Text = "モード"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(896, 80)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(74, 30)
        Me.lblLotCnt.TabIndex = 22
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(896, 64)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle2.TabIndex = 21
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblYouto
        '
        Me.lblYouto.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblYouto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYouto.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblYouto.ForeColor = System.Drawing.Color.Black
        Me.lblYouto.Location = New System.Drawing.Point(8, 81)
        Me.lblYouto.Name = "lblYouto"
        Me.lblYouto.Size = New System.Drawing.Size(129, 29)
        Me.lblYouto.TabIndex = 20
        '
        'lblMode
        '
        Me.lblMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMode.ForeColor = System.Drawing.Color.Black
        Me.lblMode.Location = New System.Drawing.Point(136, 81)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(78, 29)
        Me.lblMode.TabIndex = 19
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(712, 91)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleHT.TabIndex = 18
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleD
        '
        Me.lblTitleD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblTitleD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleD.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleD.ForeColor = System.Drawing.Color.Black
        Me.lblTitleD.Location = New System.Drawing.Point(823, 91)
        Me.lblTitleD.Name = "lblTitleD"
        Me.lblTitleD.Size = New System.Drawing.Size(66, 19)
        Me.lblTitleD.TabIndex = 17
        Me.lblTitleD.Text = "ダミー"
        Me.lblTitleD.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleD.UseMnemonic = false
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(358, 6)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(350, 17)
        Me.lblTitle1.TabIndex = 16
        Me.lblTitle1.Text = "装置名"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 6)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(350, 17)
        Me.lblTitle0.TabIndex = 15
        Me.lblTitle0.Text = "装置グループ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN0150
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle10)
        Me.Controls.Add(Me.cmdLotConnectedInfoDisp)
        Me.Controls.Add(Me.cmdDummyDisCharge)
        Me.Controls.Add(Me.cmdShip)
        Me.Controls.Add(Me.cmdLotDetail)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmbWpID)
        Me.Controls.Add(Me.cmbMcGroupName)
        Me.Controls.Add(Me.cmdChgSeqNum)
        Me.Controls.Add(Me.cmdLotList)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfAreaEquipment)
        Me.Controls.Add(Me.cmbStockerName)
        Me.Controls.Add(Me.txtBCRCarrier)
        Me.Controls.Add(Me.labFrLimit)
        Me.Controls.Add(Me.lblTitleExecRestrictLot)
        Me.Controls.Add(Me.lblTitleChip)
        Me.Controls.Add(Me.lblBeforeRecipeFlowTitle)
        Me.Controls.Add(Me.lblRecipeRule)
        Me.Controls.Add(Me.lblTitleR)
        Me.Controls.Add(Me.lblTitleL)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblWpStatusName)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblYouto)
        Me.Controls.Add(Me.lblMode)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Controls.Add(Me.lblTitleD)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0150"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "装置処理待ちロット一覧"
        CType(Me.vsfAreaEquipment,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdLotConnectedInfoDisp As Button
    Friend WithEvents cmdDummyDisCharge As Button
    Friend WithEvents cmdShip As Button
    Friend WithEvents cmdLotDetail As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmbWpID As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbMcGroupName As SECmbIchiran.ComboIchiran
    Friend WithEvents cmdChgSeqNum As Button
    Friend WithEvents cmdLotList As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfAreaEquipment As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbStockerName As SECmbIchiran.ComboIchiran
    Friend WithEvents txtBCRCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents labFrLimit As Label
    Friend WithEvents lblTitleExecRestrictLot As Label
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents lblBeforeRecipeFlowTitle As Label
    Friend WithEvents lblRecipeRule As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblWpStatusName As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblYouto As Label
    Friend WithEvents lblMode As Label
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblTitleD As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
End Class
