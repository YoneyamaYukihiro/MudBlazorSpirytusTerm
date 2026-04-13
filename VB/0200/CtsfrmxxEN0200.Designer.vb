<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0200
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0200))
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdLotConnectedInfoDisp = New System.Windows.Forms.Button()
        Me.cmdLotDetail = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfStepLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbOpID = New SEComboBoxEx.ComboBoxEx()
        Me.cmbOutKbn = New SEComboBoxEx.ComboBoxEx()
        Me.cmbFlowClass = New SECmbIchiran.ComboIchiran()
        Me.cmbPD = New SECmbIchiran.ComboIchiran()
        Me.cmbStepID = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblTitleD = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        CType(Me.vsfStepLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCopy
        '
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(332, 580)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(105, 57)
        Me.cmdCopy.TabIndex = 24
        Me.cmdCopy.Text = "ｸﾘｯﾌﾟﾎﾞｰﾄﾞ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ｺﾋﾟｰ"
        '
        'cmdLotConnectedInfoDisp
        '
        Me.cmdLotConnectedInfoDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotConnectedInfoDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotConnectedInfoDisp.Location = New System.Drawing.Point(224, 580)
        Me.cmdLotConnectedInfoDisp.Name = "cmdLotConnectedInfoDisp"
        Me.cmdLotConnectedInfoDisp.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotConnectedInfoDisp.TabIndex = 23
        Me.cmdLotConnectedInfoDisp.Text = "TFT/CF紐付"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"情報表示"
        '
        'cmdLotDetail
        '
        Me.cmdLotDetail.CausesValidation = false
        Me.cmdLotDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotDetail.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotDetail.Location = New System.Drawing.Point(116, 580)
        Me.cmdLotDetail.Name = "cmdLotDetail"
        Me.cmdLotDetail.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotDetail.TabIndex = 7
        Me.cmdLotDetail.Text = "ロット情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"詳細表示"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(868, 57)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowList.TabIndex = 5
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 580)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.Text = "閉じる"
        '
        'vsfStepLotList
        '
        Me.vsfStepLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfStepLotList.AllowEditing = false
        Me.vsfStepLotList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfStepLotList.AutoSearchDelay = 2R
        Me.vsfStepLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfStepLotList.ColumnInfo = resources.GetString("vsfStepLotList.ColumnInfo")
        Me.vsfStepLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfStepLotList.ExtendLastCol = true
        Me.vsfStepLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfStepLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfStepLotList.Location = New System.Drawing.Point(6, 120)
        Me.vsfStepLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfStepLotList.Name = "vsfStepLotList"
        Me.vsfStepLotList.Rows.Count = 40
        Me.vsfStepLotList.Rows.DefaultSize = 18
        Me.vsfStepLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfStepLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfStepLotList.Size = New System.Drawing.Size(967, 456)
        Me.vsfStepLotList.StyleInfo = resources.GetString("vsfStepLotList.StyleInfo")
        Me.vsfStepLotList.TabIndex = 6
        '
        'cmbOpID
        '
        Me.cmbOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOpID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOpID.Location = New System.Drawing.Point(180, 24)
        Me.cmbOpID.Name = "cmbOpID"
        Me.cmbOpID.Size = New System.Drawing.Size(256, 26)
        Me.cmbOpID.TabIndex = 1
        Me.cmbOpID.Value = Nothing
        '
        'cmbOutKbn
        '
        Me.cmbOutKbn.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOutKbn.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOutKbn.Location = New System.Drawing.Point(8, 24)
        Me.cmbOutKbn.Name = "cmbOutKbn"
        Me.cmbOutKbn.Size = New System.Drawing.Size(173, 26)
        Me.cmbOutKbn.TabIndex = 0
        Me.cmbOutKbn.Value = Nothing
        '
        'cmbFlowClass
        '
        Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridForeColor = System.Drawing.Color.Black
        Me.cmbFlowClass.Location = New System.Drawing.Point(180, 72)
        Me.cmbFlowClass.Name = "cmbFlowClass"
        Me.cmbFlowClass.Size = New System.Drawing.Size(171, 26)
        Me.cmbFlowClass.TabIndex = 4
        Me.cmbFlowClass.Value = Nothing
        '
        'cmbPD
        '
        Me.cmbPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridForeColor = System.Drawing.Color.Black
        Me.cmbPD.Location = New System.Drawing.Point(8, 72)
        Me.cmbPD.Name = "cmbPD"
        Me.cmbPD.Size = New System.Drawing.Size(173, 26)
        Me.cmbPD.TabIndex = 3
        Me.cmbPD.Value = Nothing
        '
        'cmbStepID
        '
        Me.cmbStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStepID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStepID.Location = New System.Drawing.Point(435, 24)
        Me.cmbStepID.Name = "cmbStepID"
        Me.cmbStepID.Size = New System.Drawing.Size(256, 26)
        Me.cmbStepID.TabIndex = 2
        Me.cmbStepID.Value = Nothing
        '
        'lblTitleChip
        '
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(683, 76)
        Me.lblTitleChip.Name = "lblTitleChip"
        Me.lblTitleChip.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleChip.TabIndex = 9
        Me.lblTitleChip.Text = "青字：Chip品"
        Me.lblTitleChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleChip.UseMnemonic = false
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(826, 76)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(33, 19)
        Me.lblTitleR.TabIndex = 22
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
        Me.lblTitleL.Location = New System.Drawing.Point(794, 76)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(33, 19)
        Me.lblTitleL.TabIndex = 21
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblTitleD
        '
        Me.lblTitleD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblTitleD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleD.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleD.ForeColor = System.Drawing.Color.Black
        Me.lblTitleD.Location = New System.Drawing.Point(794, 94)
        Me.lblTitleD.Name = "lblTitleD"
        Me.lblTitleD.Size = New System.Drawing.Size(65, 19)
        Me.lblTitleD.TabIndex = 20
        Me.lblTitleD.Text = "ダミー"
        Me.lblTitleD.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleD.UseMnemonic = false
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(180, 56)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(171, 17)
        Me.lblTitle8.TabIndex = 19
        Me.lblTitle8.Text = "種別"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(8, 56)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(173, 17)
        Me.lblTitle7.TabIndex = 18
        Me.lblTitle7.Text = "機種"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(742, 8)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 17
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(742, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 25)
        Me.lblNowDate.TabIndex = 16
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(683, 94)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleHT.TabIndex = 15
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(898, 8)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle3.TabIndex = 14
        Me.lblTitle3.Text = "該当件数"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(898, 24)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(74, 25)
        Me.lblLotCnt.TabIndex = 13
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(173, 17)
        Me.lblTitle2.TabIndex = 12
        Me.lblTitle2.Text = "表示区分"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(180, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle0.TabIndex = 11
        Me.lblTitle0.Text = "大工程"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(435, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle1.TabIndex = 10
        Me.lblTitle1.Text = "小工程"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN0200
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdLotConnectedInfoDisp)
        Me.Controls.Add(Me.cmdLotDetail)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfStepLotList)
        Me.Controls.Add(Me.cmbOpID)
        Me.Controls.Add(Me.cmbOutKbn)
        Me.Controls.Add(Me.cmbFlowClass)
        Me.Controls.Add(Me.cmbPD)
        Me.Controls.Add(Me.cmbStepID)
        Me.Controls.Add(Me.lblTitleChip)
        Me.Controls.Add(Me.lblTitleR)
        Me.Controls.Add(Me.lblTitleL)
        Me.Controls.Add(Me.lblTitleD)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0200"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ロット一覧（小工程別）"
        CType(Me.vsfStepLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdLotConnectedInfoDisp As Button
    Friend WithEvents cmdLotDetail As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfStepLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbOpID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbOutKbn As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbPD As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbStepID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblTitleD As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle1 As Label
End Class
