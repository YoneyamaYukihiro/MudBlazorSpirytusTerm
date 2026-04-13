<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01Y0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01Y0))
        Me.cmdCopyWF = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdAllCancel = New System.Windows.Forms.Button()
        Me.cmdLotPrintDisp = New System.Windows.Forms.Button()
        Me.cmdWFMapDisp = New System.Windows.Forms.Button()
        Me.chkProcess = New System.Windows.Forms.CheckBox()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.calSearchDate = New SECalendarEx.CalendarEx()
        Me.cmbFlowClass = New SECmbIchiran.ComboIchiran()
        Me.cmbPD = New SECmbIchiran.ComboIchiran()
        Me.vsfSnapShotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbPartCode = New SECmbIchiran.ComboIchiran()
        Me.cmbOp = New SECmbIchiran.ComboIchiran()
        Me.cmbStep = New SECmbIchiran.ComboIchiran()
        Me.cmbSearchTime = New SECmbIchiran.ComboIchiran()
        Me.chkCarrierPosition = New System.Windows.Forms.CheckBox()
        Me.cmbCurrentPosition = New SECmbIchiran.ComboIchiran()
        Me.lblCurrentPositionTitle = New System.Windows.Forms.Label()
        Me.lblOpTitle = New System.Windows.Forms.Label()
        Me.lblStepTitle = New System.Windows.Forms.Label()
        Me.lblPartCodeTitle = New System.Windows.Forms.Label()
        Me.lblSnapShotCntTitle = New System.Windows.Forms.Label()
        Me.lblSnapShotCntSend = New System.Windows.Forms.Label()
        Me.lblNowListTitle = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblFlowClassTitle = New System.Windows.Forms.Label()
        Me.lblPDTitle = New System.Windows.Forms.Label()
        Me.lblSearchDateTitle = New System.Windows.Forms.Label()
        CType(Me.vsfSnapShotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCopyWF
        '
        Me.cmdCopyWF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopyWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCopyWF.Location = New System.Drawing.Point(310, 593)
        Me.cmdCopyWF.Name = "cmdCopyWF"
        Me.cmdCopyWF.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopyWF.TabIndex = 13
        Me.cmdCopyWF.Text = "ｸﾘｯﾌﾟﾎﾞｰﾄﾞ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ｺﾋﾟｰ(WF)"
        '
        'cmdCopy
        '
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Location = New System.Drawing.Point(406, 593)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopy.TabIndex = 14
        Me.cmdCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'cmdAllCancel
        '
        Me.cmdAllCancel.CausesValidation = false
        Me.cmdAllCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllCancel.Location = New System.Drawing.Point(104, 593)
        Me.cmdAllCancel.Name = "cmdAllCancel"
        Me.cmdAllCancel.Size = New System.Drawing.Size(85, 40)
        Me.cmdAllCancel.TabIndex = 12
        Me.cmdAllCancel.Text = "全取消"
        '
        'cmdLotPrintDisp
        '
        Me.cmdLotPrintDisp.CausesValidation = false
        Me.cmdLotPrintDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotPrintDisp.Location = New System.Drawing.Point(502, 593)
        Me.cmdLotPrintDisp.Name = "cmdLotPrintDisp"
        Me.cmdLotPrintDisp.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotPrintDisp.TabIndex = 15
        Me.cmdLotPrintDisp.Text = "ﾛｯﾄ一覧"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"帳票表示"
        Me.cmdLotPrintDisp.Visible = false
        '
        'cmdWFMapDisp
        '
        Me.cmdWFMapDisp.CausesValidation = false
        Me.cmdWFMapDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFMapDisp.Location = New System.Drawing.Point(598, 593)
        Me.cmdWFMapDisp.Name = "cmdWFMapDisp"
        Me.cmdWFMapDisp.Size = New System.Drawing.Size(85, 40)
        Me.cmdWFMapDisp.TabIndex = 16
        Me.cmdWFMapDisp.Text = "星取表"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'chkProcess
        '
        Me.chkProcess.Checked = true
        Me.chkProcess.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProcess.Location = New System.Drawing.Point(288, 24)
        Me.chkProcess.Name = "chkProcess"
        Me.chkProcess.Size = New System.Drawing.Size(90, 21)
        Me.chkProcess.TabIndex = 4
        Me.chkProcess.Text = "指定する"
        '
        'cmdPrint
        '
        Me.cmdPrint.CausesValidation = false
        Me.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPrint.Location = New System.Drawing.Point(885, 593)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(85, 40)
        Me.cmdPrint.TabIndex = 17
        Me.cmdPrint.Text = "星取表"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"印刷"
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Location = New System.Drawing.Point(808, 54)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSearch.TabIndex = 10
        Me.cmdSearch.Text = "検　索"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 593)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 18
        Me.cmdClose.Text = "閉じる"
        '
        'calSearchDate
        '
        Me.calSearchDate.DateCheckStatus = 0
        Me.calSearchDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calSearchDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calSearchDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calSearchDate.IsDate = true
        Me.calSearchDate.Location = New System.Drawing.Point(8, 23)
        Me.calSearchDate.Name = "calSearchDate"
        Me.calSearchDate.Size = New System.Drawing.Size(117, 22)
        Me.calSearchDate.TabIndex = 0
        Me.calSearchDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calSearchDate.Value = "____/__/__"
        '
        'cmbFlowClass
        '
        Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridForeColor = System.Drawing.Color.Black
        Me.cmbFlowClass.Location = New System.Drawing.Point(139, 71)
        Me.cmbFlowClass.Name = "cmbFlowClass"
        Me.cmbFlowClass.Size = New System.Drawing.Size(131, 22)
        Me.cmbFlowClass.TabIndex = 3
        Me.cmbFlowClass.Value = Nothing
        '
        'cmbPD
        '
        Me.cmbPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridForeColor = System.Drawing.Color.Black
        Me.cmbPD.Location = New System.Drawing.Point(8, 71)
        Me.cmbPD.Name = "cmbPD"
        Me.cmbPD.Size = New System.Drawing.Size(132, 22)
        Me.cmbPD.TabIndex = 2
        Me.cmbPD.Value = Nothing
        '
        'vsfSnapShotList
        '
        Me.vsfSnapShotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSnapShotList.AllowEditing = false
        Me.vsfSnapShotList.AutoSearchDelay = 2R
        Me.vsfSnapShotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSnapShotList.ColumnInfo = resources.GetString("vsfSnapShotList.ColumnInfo")
        Me.vsfSnapShotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSnapShotList.ExtendLastCol = true
        Me.vsfSnapShotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSnapShotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSnapShotList.Location = New System.Drawing.Point(8, 99)
        Me.vsfSnapShotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSnapShotList.Name = "vsfSnapShotList"
        Me.vsfSnapShotList.Rows.Count = 40
        Me.vsfSnapShotList.Rows.DefaultSize = 18
        Me.vsfSnapShotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSnapShotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSnapShotList.Size = New System.Drawing.Size(962, 489)
        Me.vsfSnapShotList.StyleInfo = resources.GetString("vsfSnapShotList.StyleInfo")
        Me.vsfSnapShotList.TabIndex = 11
        '
        'cmbPartCode
        '
        Me.cmbPartCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartCode.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartCode.GridForeColor = System.Drawing.Color.Black
        Me.cmbPartCode.Location = New System.Drawing.Point(587, 71)
        Me.cmbPartCode.Name = "cmbPartCode"
        Me.cmbPartCode.Size = New System.Drawing.Size(216, 22)
        Me.cmbPartCode.TabIndex = 9
        Me.cmbPartCode.Value = Nothing
        '
        'cmbOp
        '
        Me.cmbOp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOp.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOp.GridForeColor = System.Drawing.Color.Black
        Me.cmbOp.Location = New System.Drawing.Point(378, 23)
        Me.cmbOp.Name = "cmbOp"
        Me.cmbOp.Size = New System.Drawing.Size(198, 22)
        Me.cmbOp.TabIndex = 5
        Me.cmbOp.Value = Nothing
        '
        'cmbStep
        '
        Me.cmbStep.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStep.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStep.GridForeColor = System.Drawing.Color.Black
        Me.cmbStep.Location = New System.Drawing.Point(575, 23)
        Me.cmbStep.Name = "cmbStep"
        Me.cmbStep.Size = New System.Drawing.Size(227, 22)
        Me.cmbStep.TabIndex = 6
        Me.cmbStep.Value = Nothing
        '
        'cmbSearchTime
        '
        Me.cmbSearchTime.DirectInput = false
        Me.cmbSearchTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbSearchTime.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbSearchTime.GridForeColor = System.Drawing.Color.Black
        Me.cmbSearchTime.Location = New System.Drawing.Point(124, 23)
        Me.cmbSearchTime.Name = "cmbSearchTime"
        Me.cmbSearchTime.Size = New System.Drawing.Size(146, 22)
        Me.cmbSearchTime.TabIndex = 1
        Me.cmbSearchTime.Value = Nothing
        Me.cmbSearchTime.ValueCol = 1
        '
        'chkCarrierPosition
        '
        Me.chkCarrierPosition.Checked = true
        Me.chkCarrierPosition.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCarrierPosition.Location = New System.Drawing.Point(288, 72)
        Me.chkCarrierPosition.Name = "chkCarrierPosition"
        Me.chkCarrierPosition.Size = New System.Drawing.Size(90, 21)
        Me.chkCarrierPosition.TabIndex = 7
        Me.chkCarrierPosition.Text = "指定する"
        '
        'cmbCurrentPosition
        '
        Me.cmbCurrentPosition.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCurrentPosition.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCurrentPosition.GridForeColor = System.Drawing.Color.Black
        Me.cmbCurrentPosition.Location = New System.Drawing.Point(378, 71)
        Me.cmbCurrentPosition.Name = "cmbCurrentPosition"
        Me.cmbCurrentPosition.Size = New System.Drawing.Size(198, 22)
        Me.cmbCurrentPosition.TabIndex = 8
        Me.cmbCurrentPosition.Value = Nothing
        '
        'lblCurrentPositionTitle
        '
        Me.lblCurrentPositionTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCurrentPositionTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentPositionTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCurrentPositionTitle.Location = New System.Drawing.Point(288, 55)
        Me.lblCurrentPositionTitle.Name = "lblCurrentPositionTitle"
        Me.lblCurrentPositionTitle.Size = New System.Drawing.Size(288, 17)
        Me.lblCurrentPositionTitle.TabIndex = 29
        Me.lblCurrentPositionTitle.Text = "キャリア位置"
        Me.lblCurrentPositionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpTitle
        '
        Me.lblOpTitle.BackColor = System.Drawing.Color.Navy
        Me.lblOpTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblOpTitle.Location = New System.Drawing.Point(288, 7)
        Me.lblOpTitle.Name = "lblOpTitle"
        Me.lblOpTitle.Size = New System.Drawing.Size(288, 17)
        Me.lblOpTitle.TabIndex = 28
        Me.lblOpTitle.Text = "大工程"
        Me.lblOpTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepTitle
        '
        Me.lblStepTitle.BackColor = System.Drawing.Color.Navy
        Me.lblStepTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblStepTitle.Location = New System.Drawing.Point(575, 7)
        Me.lblStepTitle.Name = "lblStepTitle"
        Me.lblStepTitle.Size = New System.Drawing.Size(227, 17)
        Me.lblStepTitle.TabIndex = 27
        Me.lblStepTitle.Text = "小工程"
        Me.lblStepTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPartCodeTitle
        '
        Me.lblPartCodeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPartCodeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartCodeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPartCodeTitle.Location = New System.Drawing.Point(587, 55)
        Me.lblPartCodeTitle.Name = "lblPartCodeTitle"
        Me.lblPartCodeTitle.Size = New System.Drawing.Size(216, 17)
        Me.lblPartCodeTitle.TabIndex = 26
        Me.lblPartCodeTitle.Text = "部品コード"
        Me.lblPartCodeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSnapShotCntTitle
        '
        Me.lblSnapShotCntTitle.BackColor = System.Drawing.Color.Navy
        Me.lblSnapShotCntTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSnapShotCntTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblSnapShotCntTitle.Location = New System.Drawing.Point(898, 54)
        Me.lblSnapShotCntTitle.Name = "lblSnapShotCntTitle"
        Me.lblSnapShotCntTitle.Size = New System.Drawing.Size(72, 17)
        Me.lblSnapShotCntTitle.TabIndex = 25
        Me.lblSnapShotCntTitle.Text = "該当件数"
        Me.lblSnapShotCntTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblSnapShotCntTitle.UseCompatibleTextRendering = true
        '
        'lblSnapShotCntSend
        '
        Me.lblSnapShotCntSend.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblSnapShotCntSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSnapShotCntSend.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSnapShotCntSend.Location = New System.Drawing.Point(898, 70)
        Me.lblSnapShotCntSend.Name = "lblSnapShotCntSend"
        Me.lblSnapShotCntSend.Size = New System.Drawing.Size(72, 24)
        Me.lblSnapShotCntSend.TabIndex = 24
        Me.lblSnapShotCntSend.Text = "99999"
        Me.lblSnapShotCntSend.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowListTitle
        '
        Me.lblNowListTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNowListTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowListTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNowListTitle.Location = New System.Drawing.Point(834, 6)
        Me.lblNowListTitle.Name = "lblNowListTitle"
        Me.lblNowListTitle.Size = New System.Drawing.Size(136, 17)
        Me.lblNowListTitle.TabIndex = 23
        Me.lblNowListTitle.Text = "情報取得日時"
        Me.lblNowListTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(834, 22)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(136, 24)
        Me.lblNowDate.TabIndex = 22
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblFlowClassTitle
        '
        Me.lblFlowClassTitle.BackColor = System.Drawing.Color.Navy
        Me.lblFlowClassTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClassTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblFlowClassTitle.Location = New System.Drawing.Point(139, 55)
        Me.lblFlowClassTitle.Name = "lblFlowClassTitle"
        Me.lblFlowClassTitle.Size = New System.Drawing.Size(131, 17)
        Me.lblFlowClassTitle.TabIndex = 21
        Me.lblFlowClassTitle.Text = "種別"
        Me.lblFlowClassTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPDTitle
        '
        Me.lblPDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPDTitle.Location = New System.Drawing.Point(8, 55)
        Me.lblPDTitle.Name = "lblPDTitle"
        Me.lblPDTitle.Size = New System.Drawing.Size(132, 17)
        Me.lblPDTitle.TabIndex = 20
        Me.lblPDTitle.Text = "機種"
        Me.lblPDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSearchDateTitle
        '
        Me.lblSearchDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblSearchDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSearchDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblSearchDateTitle.Location = New System.Drawing.Point(8, 7)
        Me.lblSearchDateTitle.Name = "lblSearchDateTitle"
        Me.lblSearchDateTitle.Size = New System.Drawing.Size(262, 17)
        Me.lblSearchDateTitle.TabIndex = 19
        Me.lblSearchDateTitle.Text = "検索日時"
        Me.lblSearchDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01Y0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblCurrentPositionTitle)
        Me.Controls.Add(Me.lblOpTitle)
        Me.Controls.Add(Me.cmdCopyWF)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdAllCancel)
        Me.Controls.Add(Me.cmdLotPrintDisp)
        Me.Controls.Add(Me.cmdWFMapDisp)
        Me.Controls.Add(Me.chkProcess)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.calSearchDate)
        Me.Controls.Add(Me.cmbFlowClass)
        Me.Controls.Add(Me.cmbPD)
        Me.Controls.Add(Me.vsfSnapShotList)
        Me.Controls.Add(Me.cmbPartCode)
        Me.Controls.Add(Me.cmbOp)
        Me.Controls.Add(Me.cmbStep)
        Me.Controls.Add(Me.cmbSearchTime)
        Me.Controls.Add(Me.chkCarrierPosition)
        Me.Controls.Add(Me.cmbCurrentPosition)
        Me.Controls.Add(Me.lblStepTitle)
        Me.Controls.Add(Me.lblPartCodeTitle)
        Me.Controls.Add(Me.lblSnapShotCntTitle)
        Me.Controls.Add(Me.lblSnapShotCntSend)
        Me.Controls.Add(Me.lblNowListTitle)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblFlowClassTitle)
        Me.Controls.Add(Me.lblPDTitle)
        Me.Controls.Add(Me.lblSearchDateTitle)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01Y0"
        Me.Text = "在庫スナップショット一覧"
        CType(Me.vsfSnapShotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCopyWF As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdAllCancel As Button
    Friend WithEvents cmdLotPrintDisp As Button
    Friend WithEvents cmdWFMapDisp As Button
    Friend WithEvents chkProcess As CheckBox
    Friend WithEvents cmdPrint As Button
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents calSearchDate As SECalendarEx.CalendarEx
    Friend WithEvents cmbFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbPD As SECmbIchiran.ComboIchiran
    Friend WithEvents vsfSnapShotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbPartCode As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbOp As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbStep As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbSearchTime As SECmbIchiran.ComboIchiran
    Friend WithEvents chkCarrierPosition As CheckBox
    Friend WithEvents cmbCurrentPosition As SECmbIchiran.ComboIchiran
    Friend WithEvents lblCurrentPositionTitle As Label
    Friend WithEvents lblOpTitle As Label
    Friend WithEvents lblStepTitle As Label
    Friend WithEvents lblPartCodeTitle As Label
    Friend WithEvents lblSnapShotCntTitle As Label
    Friend WithEvents lblSnapShotCntSend As Label
    Friend WithEvents lblNowListTitle As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblFlowClassTitle As Label
    Friend WithEvents lblPDTitle As Label
    Friend WithEvents lblSearchDateTitle As Label
End Class
