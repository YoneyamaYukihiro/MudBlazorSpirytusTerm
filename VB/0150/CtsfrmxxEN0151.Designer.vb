<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0151
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0151))
        Me.cmdACarrierMoQuFdSelect = New System.Windows.Forms.Button()
        Me.cmdLotDetail = New System.Windows.Forms.Button()
        Me.cmbWpID = New SECmbIchiran.ComboIchiran()
        Me.cmbMcGroupName = New SECmbIchiran.ComboIchiran()
        Me.cmdLotList = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfAreaEquipment = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitleMonitorUseBatch = New System.Windows.Forms.Label()
        Me.lblTitleWpNotUseLot = New System.Windows.Forms.Label()
        Me.lblProcessUnit = New System.Windows.Forms.Label()
        Me.lblEqModeTitle = New System.Windows.Forms.Label()
        Me.lblALDProcessName = New System.Windows.Forms.Label()
        Me.lblProcessUnitTitle = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblWpStatusName = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblEqUseName = New System.Windows.Forms.Label()
        Me.lblMesMode = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblTitleD = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        CType(Me.vsfAreaEquipment,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdACarrierMoQuFdSelect
        '
        Me.cmdACarrierMoQuFdSelect.Enabled = false
        Me.cmdACarrierMoQuFdSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdACarrierMoQuFdSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdACarrierMoQuFdSelect.Location = New System.Drawing.Point(336, 582)
        Me.cmdACarrierMoQuFdSelect.Name = "cmdACarrierMoQuFdSelect"
        Me.cmdACarrierMoQuFdSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdACarrierMoQuFdSelect.TabIndex = 30
        Me.cmdACarrierMoQuFdSelect.Text = "Aキャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択(MO/QU/FD)"
        '
        'cmdLotDetail
        '
        Me.cmdLotDetail.CausesValidation = false
        Me.cmdLotDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotDetail.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotDetail.Location = New System.Drawing.Point(116, 582)
        Me.cmdLotDetail.Name = "cmdLotDetail"
        Me.cmdLotDetail.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotDetail.TabIndex = 3
        Me.cmdLotDetail.Text = "ロット情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"詳細表示"
        '
        'cmbWpID
        '
        Me.cmbWpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpID.Location = New System.Drawing.Point(357, 22)
        Me.cmbWpID.Name = "cmbWpID"
        Me.cmbWpID.Size = New System.Drawing.Size(350, 28)
        Me.cmbWpID.TabIndex = 1
        Me.cmbWpID.Value = Nothing
        '
        'cmbMcGroupName
        '
        Me.cmbMcGroupName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.Location = New System.Drawing.Point(8, 22)
        Me.cmbMcGroupName.Name = "cmbMcGroupName"
        Me.cmbMcGroupName.Size = New System.Drawing.Size(350, 28)
        Me.cmbMcGroupName.TabIndex = 0
        Me.cmbMcGroupName.Value = Nothing
        '
        'cmdLotList
        '
        Me.cmdLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotList.Location = New System.Drawing.Point(712, 6)
        Me.cmdLotList.Name = "cmdLotList"
        Me.cmdLotList.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotList.TabIndex = 4
        Me.cmdLotList.Text = "最新取得"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 529)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(456, 49)
        Me.cmdLeft.TabIndex = 7
        Me.cmdLeft.Text = "<<"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(464, 529)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(457, 49)
        Me.cmdRight.TabIndex = 8
        Me.cmdRight.Text = ">>"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(920, 118)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 206)
        Me.cmdUP.TabIndex = 5
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(920, 324)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 205)
        Me.cmdDown.TabIndex = 6
        Me.cmdDown.Text = "▼"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(7, 582)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "閉じる"
        '
        'vsfAreaEquipment
        '
        Me.vsfAreaEquipment.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfAreaEquipment.AllowEditing = false
        Me.vsfAreaEquipment.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
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
        Me.vsfAreaEquipment.Size = New System.Drawing.Size(912, 409)
        Me.vsfAreaEquipment.StyleInfo = resources.GetString("vsfAreaEquipment.StyleInfo")
        Me.vsfAreaEquipment.TabIndex = 2
        '
        'lblTitleMonitorUseBatch
        '
        Me.lblTitleMonitorUseBatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblTitleMonitorUseBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleMonitorUseBatch.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleMonitorUseBatch.ForeColor = System.Drawing.Color.Black
        Me.lblTitleMonitorUseBatch.Location = New System.Drawing.Point(823, 72)
        Me.lblTitleMonitorUseBatch.Name = "lblTitleMonitorUseBatch"
        Me.lblTitleMonitorUseBatch.Size = New System.Drawing.Size(65, 18)
        Me.lblTitleMonitorUseBatch.TabIndex = 29
        Me.lblTitleMonitorUseBatch.Text = "M有ﾊﾞｯﾁ"
        Me.lblTitleMonitorUseBatch.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleMonitorUseBatch.UseMnemonic = false
        '
        'lblTitleWpNotUseLot
        '
        Me.lblTitleWpNotUseLot.BackColor = System.Drawing.Color.Silver
        Me.lblTitleWpNotUseLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleWpNotUseLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleWpNotUseLot.ForeColor = System.Drawing.Color.Black
        Me.lblTitleWpNotUseLot.Location = New System.Drawing.Point(712, 72)
        Me.lblTitleWpNotUseLot.Name = "lblTitleWpNotUseLot"
        Me.lblTitleWpNotUseLot.Size = New System.Drawing.Size(112, 18)
        Me.lblTitleWpNotUseLot.TabIndex = 28
        Me.lblTitleWpNotUseLot.Text = "装置処理不可"
        Me.lblTitleWpNotUseLot.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblProcessUnit
        '
        Me.lblProcessUnit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProcessUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcessUnit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProcessUnit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProcessUnit.Location = New System.Drawing.Point(485, 81)
        Me.lblProcessUnit.Name = "lblProcessUnit"
        Me.lblProcessUnit.Size = New System.Drawing.Size(107, 30)
        Me.lblProcessUnit.TabIndex = 27
        '
        'lblEqModeTitle
        '
        Me.lblEqModeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEqModeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEqModeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEqModeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEqModeTitle.Location = New System.Drawing.Point(329, 65)
        Me.lblEqModeTitle.Name = "lblEqModeTitle"
        Me.lblEqModeTitle.Size = New System.Drawing.Size(157, 17)
        Me.lblEqModeTitle.TabIndex = 26
        Me.lblEqModeTitle.Text = "装置処理名"
        Me.lblEqModeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblALDProcessName
        '
        Me.lblALDProcessName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblALDProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblALDProcessName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblALDProcessName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblALDProcessName.Location = New System.Drawing.Point(329, 81)
        Me.lblALDProcessName.Name = "lblALDProcessName"
        Me.lblALDProcessName.Size = New System.Drawing.Size(157, 30)
        Me.lblALDProcessName.TabIndex = 25
        '
        'lblProcessUnitTitle
        '
        Me.lblProcessUnitTitle.BackColor = System.Drawing.Color.Navy
        Me.lblProcessUnitTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcessUnitTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProcessUnitTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblProcessUnitTitle.Location = New System.Drawing.Point(485, 65)
        Me.lblProcessUnitTitle.Name = "lblProcessUnitTitle"
        Me.lblProcessUnitTitle.Size = New System.Drawing.Size(107, 17)
        Me.lblProcessUnitTitle.TabIndex = 24
        Me.lblProcessUnitTitle.Text = "装置処理単位"
        Me.lblProcessUnitTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTitle3.TabIndex = 23
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
        Me.lblWpStatusName.Size = New System.Drawing.Size(117, 30)
        Me.lblWpStatusName.TabIndex = 22
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(822, 22)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 30)
        Me.lblNowDate.TabIndex = 21
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(822, 6)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 20
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
        Me.lblTitle8.TabIndex = 19
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
        Me.lblTitle7.TabIndex = 18
        Me.lblTitle7.Text = "モード"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(898, 81)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(75, 30)
        Me.lblLotCnt.TabIndex = 17
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(898, 65)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(75, 17)
        Me.lblTitle2.TabIndex = 16
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEqUseName
        '
        Me.lblEqUseName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEqUseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEqUseName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEqUseName.ForeColor = System.Drawing.Color.Black
        Me.lblEqUseName.Location = New System.Drawing.Point(8, 81)
        Me.lblEqUseName.Name = "lblEqUseName"
        Me.lblEqUseName.Size = New System.Drawing.Size(129, 30)
        Me.lblEqUseName.TabIndex = 15
        '
        'lblMesMode
        '
        Me.lblMesMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMesMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMesMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMesMode.ForeColor = System.Drawing.Color.Black
        Me.lblMesMode.Location = New System.Drawing.Point(136, 81)
        Me.lblMesMode.Name = "lblMesMode"
        Me.lblMesMode.Size = New System.Drawing.Size(78, 30)
        Me.lblMesMode.TabIndex = 14
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(712, 92)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleHT.TabIndex = 13
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleD
        '
        Me.lblTitleD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblTitleD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleD.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleD.ForeColor = System.Drawing.Color.Black
        Me.lblTitleD.Location = New System.Drawing.Point(823, 92)
        Me.lblTitleD.Name = "lblTitleD"
        Me.lblTitleD.Size = New System.Drawing.Size(65, 19)
        Me.lblTitleD.TabIndex = 12
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
        Me.lblTitle1.Location = New System.Drawing.Point(357, 6)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(350, 17)
        Me.lblTitle1.TabIndex = 11
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
        Me.lblTitle0.TabIndex = 10
        Me.lblTitle0.Text = "装置グループ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN0151
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmbMcGroupName)
        Me.Controls.Add(Me.cmdACarrierMoQuFdSelect)
        Me.Controls.Add(Me.cmdLotDetail)
        Me.Controls.Add(Me.cmbWpID)
        Me.Controls.Add(Me.cmdLotList)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfAreaEquipment)
        Me.Controls.Add(Me.lblTitleMonitorUseBatch)
        Me.Controls.Add(Me.lblTitleWpNotUseLot)
        Me.Controls.Add(Me.lblProcessUnit)
        Me.Controls.Add(Me.lblEqModeTitle)
        Me.Controls.Add(Me.lblALDProcessName)
        Me.Controls.Add(Me.lblProcessUnitTitle)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblWpStatusName)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblEqUseName)
        Me.Controls.Add(Me.lblMesMode)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Controls.Add(Me.lblTitleD)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0151"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "装置別ロット一覧(防湿ALD)"
        CType(Me.vsfAreaEquipment,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdACarrierMoQuFdSelect As Button
    Friend WithEvents cmdLotDetail As Button
    Friend WithEvents cmbWpID As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbMcGroupName As SECmbIchiran.ComboIchiran
    Friend WithEvents cmdLotList As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfAreaEquipment As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleMonitorUseBatch As Label
    Friend WithEvents lblTitleWpNotUseLot As Label
    Friend WithEvents lblProcessUnit As Label
    Friend WithEvents lblEqModeTitle As Label
    Friend WithEvents lblALDProcessName As Label
    Friend WithEvents lblProcessUnitTitle As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblWpStatusName As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblEqUseName As Label
    Friend WithEvents lblMesMode As Label
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblTitleD As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
End Class
