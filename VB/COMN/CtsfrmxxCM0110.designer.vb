<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM0110
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM0110))
        Me.cmdTimeRestrictDisp = New System.Windows.Forms.Button()
        Me.cmbWpID = New SECmbIchiran.ComboIchiran()
        Me.cmbMcGroupName = New SECmbIchiran.ComboIchiran()
        Me.cmdAllCancel = New System.Windows.Forms.Button()
        Me.cmdLotList = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfLotWaitingList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitleExecRestrictLot = New System.Windows.Forms.Label()
        Me.lblRecipeRule = New System.Windows.Forms.Label()
        Me.lblBeforeRecipeFlowTitle = New System.Windows.Forms.Label()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.lblTitleD = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.lblWpStatus = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblWpTrnStatus = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblNowSeqNum = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        CType(Me.vsfLotWaitingList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdTimeRestrictDisp
        '
        Me.cmdTimeRestrictDisp.CausesValidation = false
        Me.cmdTimeRestrictDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTimeRestrictDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTimeRestrictDisp.Location = New System.Drawing.Point(224, 582)
        Me.cmdTimeRestrictDisp.Name = "cmdTimeRestrictDisp"
        Me.cmdTimeRestrictDisp.Size = New System.Drawing.Size(105, 57)
        Me.cmdTimeRestrictDisp.TabIndex = 33
        Me.cmdTimeRestrictDisp.Text = "時間制限"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'cmbWpID
        '
        Me.cmbWpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpID.Location = New System.Drawing.Point(358, 23)
        Me.cmbWpID.Name = "cmbWpID"
        Me.cmbWpID.Size = New System.Drawing.Size(350, 28)
        Me.cmbWpID.TabIndex = 1
        Me.cmbWpID.Value = Nothing
        '
        'cmbMcGroupName
        '
        Me.cmbMcGroupName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.Location = New System.Drawing.Point(8, 23)
        Me.cmbMcGroupName.Name = "cmbMcGroupName"
        Me.cmbMcGroupName.Size = New System.Drawing.Size(350, 28)
        Me.cmbMcGroupName.TabIndex = 0
        Me.cmbMcGroupName.Value = Nothing
        '
        'cmdAllCancel
        '
        Me.cmdAllCancel.CausesValidation = false
        Me.cmdAllCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAllCancel.Location = New System.Drawing.Point(116, 582)
        Me.cmdAllCancel.Name = "cmdAllCancel"
        Me.cmdAllCancel.Size = New System.Drawing.Size(105, 57)
        Me.cmdAllCancel.TabIndex = 26
        Me.cmdAllCancel.Text = "処理順"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"全解除"
        '
        'cmdLotList
        '
        Me.cmdLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotList.Location = New System.Drawing.Point(712, 5)
        Me.cmdLotList.Name = "cmdLotList"
        Me.cmdLotList.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotList.TabIndex = 9
        Me.cmdLotList.Text = "最新取得"
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(866, 582)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 7
        Me.cmdRegist.Text = "確　定"
        '
        'cmdBack
        '
        Me.cmdBack.CausesValidation = false
        Me.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdBack.Location = New System.Drawing.Point(758, 582)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(105, 57)
        Me.cmdBack.TabIndex = 8
        Me.cmdBack.Text = "1つ前に戻る"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 529)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(456, 49)
        Me.cmdLeft.TabIndex = 5
        Me.cmdLeft.Text = "<<"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(464, 529)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(456, 49)
        Me.cmdRight.TabIndex = 6
        Me.cmdRight.Text = ">>"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(919, 118)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 205)
        Me.cmdUP.TabIndex = 3
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(919, 324)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 205)
        Me.cmdDown.TabIndex = 4
        Me.cmdDown.Text = "▼"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 582)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "閉じる"
        '
        'vsfLotWaitingList
        '
        Me.vsfLotWaitingList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotWaitingList.AllowEditing = false
        Me.vsfLotWaitingList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotWaitingList.AutoSearchDelay = 2R
        Me.vsfLotWaitingList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotWaitingList.ColumnInfo = resources.GetString("vsfLotWaitingList.ColumnInfo")
        Me.vsfLotWaitingList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotWaitingList.ExtendLastCol = true
        Me.vsfLotWaitingList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfLotWaitingList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotWaitingList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotWaitingList.Location = New System.Drawing.Point(8, 119)
        Me.vsfLotWaitingList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotWaitingList.Name = "vsfLotWaitingList"
        Me.vsfLotWaitingList.Rows.Count = 40
        Me.vsfLotWaitingList.Rows.DefaultSize = 18
        Me.vsfLotWaitingList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfLotWaitingList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotWaitingList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotWaitingList.Size = New System.Drawing.Size(911, 409)
        Me.vsfLotWaitingList.StyleInfo = resources.GetString("vsfLotWaitingList.StyleInfo")
        Me.vsfLotWaitingList.TabIndex = 2
        '
        'lblTitleExecRestrictLot
        '
        Me.lblTitleExecRestrictLot.BackColor = System.Drawing.Color.Silver
        Me.lblTitleExecRestrictLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleExecRestrictLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleExecRestrictLot.ForeColor = System.Drawing.Color.Black
        Me.lblTitleExecRestrictLot.Location = New System.Drawing.Point(802, 74)
        Me.lblTitleExecRestrictLot.Name = "lblTitleExecRestrictLot"
        Me.lblTitleExecRestrictLot.Size = New System.Drawing.Size(86, 19)
        Me.lblTitleExecRestrictLot.TabIndex = 34
        Me.lblTitleExecRestrictLot.Text = "処理限定"
        Me.lblTitleExecRestrictLot.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRecipeRule
        '
        Me.lblRecipeRule.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblRecipeRule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecipeRule.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRecipeRule.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRecipeRule.Location = New System.Drawing.Point(329, 81)
        Me.lblRecipeRule.Name = "lblRecipeRule"
        Me.lblRecipeRule.Size = New System.Drawing.Size(157, 30)
        Me.lblRecipeRule.TabIndex = 32
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
        Me.lblBeforeRecipeFlowTitle.TabIndex = 31
        Me.lblBeforeRecipeFlowTitle.Text = "処理順ルール"
        Me.lblBeforeRecipeFlowTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleChip
        '
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(691, 74)
        Me.lblTitleChip.Name = "lblTitleChip"
        Me.lblTitleChip.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleChip.TabIndex = 30
        Me.lblTitleChip.Text = "青字：Chip品"
        Me.lblTitleChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleChip.UseMnemonic = false
        '
        'lblTitleD
        '
        Me.lblTitleD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblTitleD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleD.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleD.ForeColor = System.Drawing.Color.Black
        Me.lblTitleD.Location = New System.Drawing.Point(830, 92)
        Me.lblTitleD.Name = "lblTitleD"
        Me.lblTitleD.Size = New System.Drawing.Size(58, 19)
        Me.lblTitleD.TabIndex = 29
        Me.lblTitleD.Text = "ダミー"
        Me.lblTitleD.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleD.UseMnemonic = false
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(717, 92)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(26, 19)
        Me.lblTitleR.TabIndex = 28
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
        Me.lblTitleL.Location = New System.Drawing.Point(691, 92)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(27, 19)
        Me.lblTitleL.TabIndex = 27
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblMode
        '
        Me.lblMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMode.ForeColor = System.Drawing.Color.Black
        Me.lblMode.Location = New System.Drawing.Point(136, 81)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(78, 30)
        Me.lblMode.TabIndex = 25
        '
        'lblWpStatus
        '
        Me.lblWpStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpStatus.ForeColor = System.Drawing.Color.Black
        Me.lblWpStatus.Location = New System.Drawing.Point(8, 81)
        Me.lblWpStatus.Name = "lblWpStatus"
        Me.lblWpStatus.Size = New System.Drawing.Size(129, 30)
        Me.lblWpStatus.TabIndex = 24
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(136, 65)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(78, 17)
        Me.lblTitle10.TabIndex = 23
        Me.lblTitle10.Text = "モード"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTitle8.TabIndex = 22
        Me.lblTitle8.Text = "装置状態"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWpTrnStatus
        '
        Me.lblWpTrnStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWpTrnStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpTrnStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpTrnStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWpTrnStatus.Location = New System.Drawing.Point(213, 81)
        Me.lblWpTrnStatus.Name = "lblWpTrnStatus"
        Me.lblWpTrnStatus.Size = New System.Drawing.Size(117, 30)
        Me.lblWpTrnStatus.TabIndex = 21
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(213, 65)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(117, 17)
        Me.lblTitle7.TabIndex = 20
        Me.lblTitle7.Text = "処理状態"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTitle0.TabIndex = 19
        Me.lblTitle0.Text = "装置グループ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTitle1.TabIndex = 18
        Me.lblTitle1.Text = "装置名"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(742, 92)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(89, 19)
        Me.lblTitleHT.TabIndex = 17
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(898, 65)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle2.TabIndex = 16
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(898, 81)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(74, 30)
        Me.lblLotCnt.TabIndex = 15
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(821, 6)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 14
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(821, 22)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 30)
        Me.lblNowDate.TabIndex = 13
        '
        'lblNowSeqNum
        '
        Me.lblNowSeqNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowSeqNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowSeqNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowSeqNum.ForeColor = System.Drawing.Color.Black
        Me.lblNowSeqNum.Location = New System.Drawing.Point(495, 81)
        Me.lblNowSeqNum.Name = "lblNowSeqNum"
        Me.lblNowSeqNum.Size = New System.Drawing.Size(127, 30)
        Me.lblNowSeqNum.TabIndex = 12
        Me.lblNowSeqNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(495, 65)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(127, 17)
        Me.lblTitle3.TabIndex = 11
        Me.lblTitle3.Text = "現在処理順№"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxCM0110
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdTimeRestrictDisp)
        Me.Controls.Add(Me.cmbWpID)
        Me.Controls.Add(Me.cmbMcGroupName)
        Me.Controls.Add(Me.cmdAllCancel)
        Me.Controls.Add(Me.cmdLotList)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfLotWaitingList)
        Me.Controls.Add(Me.lblTitleExecRestrictLot)
        Me.Controls.Add(Me.lblRecipeRule)
        Me.Controls.Add(Me.lblBeforeRecipeFlowTitle)
        Me.Controls.Add(Me.lblTitleChip)
        Me.Controls.Add(Me.lblTitleD)
        Me.Controls.Add(Me.lblTitleR)
        Me.Controls.Add(Me.lblTitleL)
        Me.Controls.Add(Me.lblMode)
        Me.Controls.Add(Me.lblWpStatus)
        Me.Controls.Add(Me.lblTitle10)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblWpTrnStatus)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblNowSeqNum)
        Me.Controls.Add(Me.lblTitle3)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM0110"
        Me.Text = "ロット処理順変更"
        CType(Me.vsfLotWaitingList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdTimeRestrictDisp As Button
    Friend WithEvents cmbWpID As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbMcGroupName As SECmbIchiran.ComboIchiran
    Friend WithEvents cmdAllCancel As Button
    Friend WithEvents cmdLotList As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdBack As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfLotWaitingList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleExecRestrictLot As Label
    Friend WithEvents lblRecipeRule As Label
    Friend WithEvents lblBeforeRecipeFlowTitle As Label
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents lblTitleD As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblMode As Label
    Friend WithEvents lblWpStatus As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblWpTrnStatus As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblNowSeqNum As Label
    Friend WithEvents lblTitle3 As Label
End Class
