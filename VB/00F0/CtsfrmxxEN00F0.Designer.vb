<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00F0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00F0))
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.Tab0 = New System.Windows.Forms.TabPage()
        Me.fraPut = New System.Windows.Forms.Panel()
        Me.lblTitle11 = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.cmdPutWFInfo = New System.Windows.Forms.Button()
        Me.cmdPreCommentSend = New System.Windows.Forms.Button()
        Me.cmdCommentPut = New System.Windows.Forms.Button()
        Me.cmdHoldPut = New System.Windows.Forms.Button()
        Me.cmdWFPut = New System.Windows.Forms.Button()
        Me.cmdPartition = New System.Windows.Forms.Button()
        Me.cmdCancelPut = New System.Windows.Forms.Button()
        Me.cmdNowListPut = New System.Windows.Forms.Button()
        Me.cmbDivisionPut = New SECmbIchiran.ComboIchiran()
        Me.cmbProductPut = New SECmbIchiran.ComboIchiran()
        Me.vsfLotListPut = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitle18 = New System.Windows.Forms.Label()
        Me.lblNowDatePut = New System.Windows.Forms.Label()
        Me.lblTitle14 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblLotCntPut = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.fraHold = New System.Windows.Forms.Panel()
        Me.cmdHoldWFInfo = New System.Windows.Forms.Button()
        Me.cmdHoldHold = New System.Windows.Forms.Button()
        Me.cmdCommentHold = New System.Windows.Forms.Button()
        Me.cmdCancelHold = New System.Windows.Forms.Button()
        Me.cmdWFHold = New System.Windows.Forms.Button()
        Me.cmdNowListHold = New System.Windows.Forms.Button()
        Me.cmbDivisionHold = New SECmbIchiran.ComboIchiran()
        Me.vsfLotListHold = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitleHoldChip = New System.Windows.Forms.Label()
        Me.lblTitleHoldL = New System.Windows.Forms.Label()
        Me.lblTitleHoldR = New System.Windows.Forms.Label()
        Me.lblTitle17 = New System.Windows.Forms.Label()
        Me.lblNowDateHold = New System.Windows.Forms.Label()
        Me.lblTitle15 = New System.Windows.Forms.Label()
        Me.lblLotCntHold = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.fraWF = New System.Windows.Forms.Panel()
        Me.lblTitle20 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.cmdMiddleWFInfo = New System.Windows.Forms.Button()
        Me.cmdCarrierDetail = New System.Windows.Forms.Button()
        Me.cmdNowListWF = New System.Windows.Forms.Button()
        Me.FraCarrierInfo = New System.Windows.Forms.GroupBox()
        Me.vsfCarrierInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdCarrierM = New System.Windows.Forms.Button()
        Me.vsfLotListWF = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbSBID0 = New SEComboBoxEx.ComboBoxEx()
        Me.txtLotID = New SETextBoxEx.TextBoxEx()
        Me.lblNowDateWF = New System.Windows.Forms.Label()
        Me.lblTitle13 = New System.Windows.Forms.Label()
        Me.lblTitle12 = New System.Windows.Forms.Label()
        Me.lblLotCntWF = New System.Windows.Forms.Label()
        Me.Tab3 = New System.Windows.Forms.TabPage()
        Me.fraSend = New System.Windows.Forms.Panel()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.chkForign1 = New System.Windows.Forms.CheckBox()
        Me.chkForign0 = New System.Windows.Forms.CheckBox()
        Me.cmdSendWFInfo = New System.Windows.Forms.Button()
        Me.optLotSendStatus1 = New System.Windows.Forms.RadioButton()
        Me.optLotSendStatus0 = New System.Windows.Forms.RadioButton()
        Me.cmdSendOrderList = New System.Windows.Forms.Button()
        Me.cmdLotExamInfo = New System.Windows.Forms.Button()
        Me.cmdSendRegist = New System.Windows.Forms.Button()
        Me.cmdNextCommentSend = New System.Windows.Forms.Button()
        Me.cmdCommentSend = New System.Windows.Forms.Button()
        Me.cmdNowListSend = New System.Windows.Forms.Button()
        Me.cmdHoldSend = New System.Windows.Forms.Button()
        Me.cmdWFSend = New System.Windows.Forms.Button()
        Me.cmdCancelSend = New System.Windows.Forms.Button()
        Me.vsfLotListSend = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbDivisionSend = New SECmbIchiran.ComboIchiran()
        Me.cmbProductSend = New SECmbIchiran.ComboIchiran()
        Me.calFromDate = New SECalendarEx.CalendarEx()
        Me.calToDate = New SECalendarEx.CalendarEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTitleSendChip = New System.Windows.Forms.Label()
        Me.lblTitleSendR = New System.Windows.Forms.Label()
        Me.lblTitleSendL = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblKara = New System.Windows.Forms.Label()
        Me.lblNowDateSend = New System.Windows.Forms.Label()
        Me.lblTitle16 = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblLotCntSend = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.Tab4 = New System.Windows.Forms.TabPage()
        Me.fraCFEnd = New System.Windows.Forms.Panel()
        Me.lblTitle19 = New System.Windows.Forms.Label()
        Me.cmdCFEndWFInfo = New System.Windows.Forms.Button()
        Me.cmdCommentCFEnd = New System.Windows.Forms.Button()
        Me.cmdCancelCFEnd = New System.Windows.Forms.Button()
        Me.cmdCFEnd = New System.Windows.Forms.Button()
        Me.cmdHoldCFEnd = New System.Windows.Forms.Button()
        Me.cmdNowListCFEnd = New System.Windows.Forms.Button()
        Me.cmdRework = New System.Windows.Forms.Button()
        Me.vsfLotListCFEnd = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbProductCFEnd = New SECmbIchiran.ComboIchiran()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.lblTitle24 = New System.Windows.Forms.Label()
        Me.lblTitleCfEndL = New System.Windows.Forms.Label()
        Me.lblTitleCfEndR = New System.Windows.Forms.Label()
        Me.lblTitle23 = New System.Windows.Forms.Label()
        Me.lblLotCntCFEnd = New System.Windows.Forms.Label()
        Me.lblTitle22 = New System.Windows.Forms.Label()
        Me.lblTitle21 = New System.Windows.Forms.Label()
        Me.lblNowDateCFEnd = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.tabControl.SuspendLayout
        Me.Tab0.SuspendLayout
        Me.fraPut.SuspendLayout
        CType(Me.vsfLotListPut,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab1.SuspendLayout
        Me.fraHold.SuspendLayout
        CType(Me.vsfLotListHold,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab2.SuspendLayout
        Me.fraWF.SuspendLayout
        Me.FraCarrierInfo.SuspendLayout
        CType(Me.vsfCarrierInfo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfLotListWF,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab3.SuspendLayout
        Me.fraSend.SuspendLayout
        CType(Me.vsfLotListSend,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab4.SuspendLayout
        Me.fraCFEnd.SuspendLayout
        CType(Me.vsfLotListCFEnd,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCopy
        '
        Me.cmdCopy.CausesValidation = false
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Location = New System.Drawing.Point(120, 595)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopy.TabIndex = 55
        Me.cmdCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.Tab0)
        Me.tabControl.Controls.Add(Me.Tab1)
        Me.tabControl.Controls.Add(Me.Tab2)
        Me.tabControl.Controls.Add(Me.Tab3)
        Me.tabControl.Controls.Add(Me.Tab4)
        Me.tabControl.ItemSize = New System.Drawing.Size(190, 21)
        Me.tabControl.Location = New System.Drawing.Point(8, 8)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(965, 581)
        Me.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabControl.TabIndex = 0
        '
        'Tab0
        '
        Me.Tab0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab0.Controls.Add(Me.fraPut)
        Me.Tab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab0.ForeColor = System.Drawing.Color.Black
        Me.Tab0.Location = New System.Drawing.Point(4, 25)
        Me.Tab0.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab0.Name = "Tab0"
        Me.Tab0.Size = New System.Drawing.Size(957, 552)
        Me.Tab0.TabIndex = 0
        Me.Tab0.Text = "ロット受入在庫"
        '
        'fraPut
        '
        Me.fraPut.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraPut.Controls.Add(Me.lblTitle11)
        Me.fraPut.Controls.Add(Me.lblTitle10)
        Me.fraPut.Controls.Add(Me.cmdPutWFInfo)
        Me.fraPut.Controls.Add(Me.cmdPreCommentSend)
        Me.fraPut.Controls.Add(Me.cmdCommentPut)
        Me.fraPut.Controls.Add(Me.cmdHoldPut)
        Me.fraPut.Controls.Add(Me.cmdWFPut)
        Me.fraPut.Controls.Add(Me.cmdPartition)
        Me.fraPut.Controls.Add(Me.cmdCancelPut)
        Me.fraPut.Controls.Add(Me.cmdNowListPut)
        Me.fraPut.Controls.Add(Me.cmbDivisionPut)
        Me.fraPut.Controls.Add(Me.cmbProductPut)
        Me.fraPut.Controls.Add(Me.vsfLotListPut)
        Me.fraPut.Controls.Add(Me.lblTitle18)
        Me.fraPut.Controls.Add(Me.lblNowDatePut)
        Me.fraPut.Controls.Add(Me.lblTitle14)
        Me.fraPut.Controls.Add(Me.lblTitle8)
        Me.fraPut.Controls.Add(Me.lblLotCntPut)
        Me.fraPut.Controls.Add(Me.lblTitle9)
        Me.fraPut.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fraPut.Location = New System.Drawing.Point(0, 0)
        Me.fraPut.Name = "fraPut"
        Me.fraPut.Size = New System.Drawing.Size(957, 553)
        Me.fraPut.TabIndex = 58
        Me.fraPut.Text = "Frame1"
        '
        'lblTitle11
        '
        Me.lblTitle11.BackColor = System.Drawing.Color.Navy
        Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle11.Location = New System.Drawing.Point(8, 16)
        Me.lblTitle11.Name = "lblTitle11"
        Me.lblTitle11.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle11.TabIndex = 59
        Me.lblTitle11.Text = "機種"
        Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(168, 16)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle10.TabIndex = 60
        Me.lblTitle10.Text = "種別"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdPutWFInfo
        '
        Me.cmdPutWFInfo.CausesValidation = false
        Me.cmdPutWFInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPutWFInfo.Location = New System.Drawing.Point(608, 504)
        Me.cmdPutWFInfo.Name = "cmdPutWFInfo"
        Me.cmdPutWFInfo.Size = New System.Drawing.Size(85, 40)
        Me.cmdPutWFInfo.TabIndex = 9
        Me.cmdPutWFInfo.Text = "WF情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'cmdPreCommentSend
        '
        Me.cmdPreCommentSend.CausesValidation = false
        Me.cmdPreCommentSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPreCommentSend.Location = New System.Drawing.Point(508, 504)
        Me.cmdPreCommentSend.Name = "cmdPreCommentSend"
        Me.cmdPreCommentSend.Size = New System.Drawing.Size(85, 40)
        Me.cmdPreCommentSend.TabIndex = 8
        Me.cmdPreCommentSend.Text = "前SB連絡"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'cmdCommentPut
        '
        Me.cmdCommentPut.CausesValidation = false
        Me.cmdCommentPut.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentPut.Location = New System.Drawing.Point(408, 504)
        Me.cmdCommentPut.Name = "cmdCommentPut"
        Me.cmdCommentPut.Size = New System.Drawing.Size(85, 40)
        Me.cmdCommentPut.TabIndex = 7
        Me.cmdCommentPut.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdHoldPut
        '
        Me.cmdHoldPut.CausesValidation = false
        Me.cmdHoldPut.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldPut.Location = New System.Drawing.Point(108, 504)
        Me.cmdHoldPut.Name = "cmdHoldPut"
        Me.cmdHoldPut.Size = New System.Drawing.Size(85, 40)
        Me.cmdHoldPut.TabIndex = 4
        Me.cmdHoldPut.Text = "保　留"
        '
        'cmdWFPut
        '
        Me.cmdWFPut.CausesValidation = false
        Me.cmdWFPut.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFPut.Location = New System.Drawing.Point(308, 504)
        Me.cmdWFPut.Name = "cmdWFPut"
        Me.cmdWFPut.Size = New System.Drawing.Size(85, 40)
        Me.cmdWFPut.TabIndex = 6
        Me.cmdWFPut.Text = "在庫払出"
        '
        'cmdPartition
        '
        Me.cmdPartition.CausesValidation = false
        Me.cmdPartition.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPartition.Location = New System.Drawing.Point(8, 504)
        Me.cmdPartition.Name = "cmdPartition"
        Me.cmdPartition.Size = New System.Drawing.Size(85, 40)
        Me.cmdPartition.TabIndex = 3
        Me.cmdPartition.Text = "分割/移載"
        '
        'cmdCancelPut
        '
        Me.cmdCancelPut.CausesValidation = false
        Me.cmdCancelPut.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancelPut.Location = New System.Drawing.Point(208, 504)
        Me.cmdCancelPut.Name = "cmdCancelPut"
        Me.cmdCancelPut.Size = New System.Drawing.Size(85, 40)
        Me.cmdCancelPut.TabIndex = 5
        Me.cmdCancelPut.Text = "保留解除"
        '
        'cmdNowListPut
        '
        Me.cmdNowListPut.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowListPut.Location = New System.Drawing.Point(646, 15)
        Me.cmdNowListPut.Name = "cmdNowListPut"
        Me.cmdNowListPut.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowListPut.TabIndex = 10
        Me.cmdNowListPut.Text = "最新取得"
        '
        'cmbDivisionPut
        '
        Me.cmbDivisionPut.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivisionPut.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivisionPut.GridForeColor = System.Drawing.Color.Black
        Me.cmbDivisionPut.Location = New System.Drawing.Point(168, 32)
        Me.cmbDivisionPut.Name = "cmbDivisionPut"
        Me.cmbDivisionPut.Size = New System.Drawing.Size(161, 22)
        Me.cmbDivisionPut.TabIndex = 1
        Me.cmbDivisionPut.Value = Nothing
        '
        'cmbProductPut
        '
        Me.cmbProductPut.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbProductPut.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbProductPut.GridForeColor = System.Drawing.Color.Black
        Me.cmbProductPut.Location = New System.Drawing.Point(8, 32)
        Me.cmbProductPut.Name = "cmbProductPut"
        Me.cmbProductPut.Size = New System.Drawing.Size(161, 22)
        Me.cmbProductPut.TabIndex = 0
        Me.cmbProductPut.Value = Nothing
        '
        'vsfLotListPut
        '
        Me.vsfLotListPut.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotListPut.AllowEditing = false
        Me.vsfLotListPut.AutoSearchDelay = 2R
        Me.vsfLotListPut.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotListPut.ColumnInfo = resources.GetString("vsfLotListPut.ColumnInfo")
        Me.vsfLotListPut.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotListPut.ExtendLastCol = true
        Me.vsfLotListPut.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfLotListPut.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotListPut.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotListPut.Location = New System.Drawing.Point(8, 88)
        Me.vsfLotListPut.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotListPut.Name = "vsfLotListPut"
        Me.vsfLotListPut.Rows.Count = 40
        Me.vsfLotListPut.Rows.DefaultSize = 18
        Me.vsfLotListPut.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotListPut.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotListPut.Size = New System.Drawing.Size(939, 401)
        Me.vsfLotListPut.StyleInfo = resources.GetString("vsfLotListPut.StyleInfo")
        Me.vsfLotListPut.TabIndex = 2
        '
        'lblTitle18
        '
        Me.lblTitle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(204,Byte),Integer), CType(CType(236,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitle18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle18.ForeColor = System.Drawing.Color.Black
        Me.lblTitle18.Location = New System.Drawing.Point(850, 62)
        Me.lblTitle18.Name = "lblTitle18"
        Me.lblTitle18.Size = New System.Drawing.Size(57, 18)
        Me.lblTitle18.TabIndex = 86
        Me.lblTitle18.Text = "移載未"
        Me.lblTitle18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDatePut
        '
        Me.lblNowDatePut.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDatePut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDatePut.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDatePut.Location = New System.Drawing.Point(742, 32)
        Me.lblNowDatePut.Name = "lblNowDatePut"
        Me.lblNowDatePut.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDatePut.TabIndex = 80
        Me.lblNowDatePut.Text = "07/15 13:11:25"
        '
        'lblTitle14
        '
        Me.lblTitle14.BackColor = System.Drawing.Color.Navy
        Me.lblTitle14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle14.Location = New System.Drawing.Point(742, 16)
        Me.lblTitle14.Name = "lblTitle14"
        Me.lblTitle14.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle14.TabIndex = 79
        Me.lblTitle14.Text = "情報取得日時"
        Me.lblTitle14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Yellow
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.ForeColor = System.Drawing.Color.Black
        Me.lblTitle8.Location = New System.Drawing.Point(906, 62)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(41, 18)
        Me.lblTitle8.TabIndex = 63
        Me.lblTitle8.Text = "保留"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCntPut
        '
        Me.lblLotCntPut.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCntPut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntPut.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCntPut.Location = New System.Drawing.Point(874, 32)
        Me.lblLotCntPut.Name = "lblLotCntPut"
        Me.lblLotCntPut.Size = New System.Drawing.Size(73, 21)
        Me.lblLotCntPut.TabIndex = 62
        Me.lblLotCntPut.Text = "0"
        Me.lblLotCntPut.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(874, 16)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle9.TabIndex = 61
        Me.lblTitle9.Text = "該当件数"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab1.Controls.Add(Me.fraHold)
        Me.Tab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab1.ForeColor = System.Drawing.Color.Black
        Me.Tab1.Location = New System.Drawing.Point(4, 25)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(957, 552)
        Me.Tab1.TabIndex = 1
        Me.Tab1.Text = "保留ロット"
        '
        'fraHold
        '
        Me.fraHold.Controls.Add(Me.cmdHoldWFInfo)
        Me.fraHold.Controls.Add(Me.cmdHoldHold)
        Me.fraHold.Controls.Add(Me.cmdCommentHold)
        Me.fraHold.Controls.Add(Me.cmdCancelHold)
        Me.fraHold.Controls.Add(Me.cmdWFHold)
        Me.fraHold.Controls.Add(Me.cmdNowListHold)
        Me.fraHold.Controls.Add(Me.cmbDivisionHold)
        Me.fraHold.Controls.Add(Me.vsfLotListHold)
        Me.fraHold.Controls.Add(Me.lblTitleHoldChip)
        Me.fraHold.Controls.Add(Me.lblTitleHoldL)
        Me.fraHold.Controls.Add(Me.lblTitleHoldR)
        Me.fraHold.Controls.Add(Me.lblTitle17)
        Me.fraHold.Controls.Add(Me.lblNowDateHold)
        Me.fraHold.Controls.Add(Me.lblTitle15)
        Me.fraHold.Controls.Add(Me.lblLotCntHold)
        Me.fraHold.Controls.Add(Me.lblTitle4)
        Me.fraHold.Controls.Add(Me.lblTitle6)
        Me.fraHold.Location = New System.Drawing.Point(0, 0)
        Me.fraHold.Name = "fraHold"
        Me.fraHold.Size = New System.Drawing.Size(957, 553)
        Me.fraHold.TabIndex = 66
        Me.fraHold.Text = "Frame1"
        '
        'cmdHoldWFInfo
        '
        Me.cmdHoldWFInfo.CausesValidation = false
        Me.cmdHoldWFInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldWFInfo.Location = New System.Drawing.Point(508, 504)
        Me.cmdHoldWFInfo.Name = "cmdHoldWFInfo"
        Me.cmdHoldWFInfo.Size = New System.Drawing.Size(85, 40)
        Me.cmdHoldWFInfo.TabIndex = 17
        Me.cmdHoldWFInfo.Text = "WF情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'cmdHoldHold
        '
        Me.cmdHoldHold.CausesValidation = false
        Me.cmdHoldHold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldHold.Location = New System.Drawing.Point(108, 504)
        Me.cmdHoldHold.Name = "cmdHoldHold"
        Me.cmdHoldHold.Size = New System.Drawing.Size(85, 40)
        Me.cmdHoldHold.TabIndex = 13
        Me.cmdHoldHold.Text = "保　留"
        '
        'cmdCommentHold
        '
        Me.cmdCommentHold.CausesValidation = false
        Me.cmdCommentHold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentHold.Location = New System.Drawing.Point(408, 504)
        Me.cmdCommentHold.Name = "cmdCommentHold"
        Me.cmdCommentHold.Size = New System.Drawing.Size(85, 40)
        Me.cmdCommentHold.TabIndex = 16
        Me.cmdCommentHold.Text = "ﾛｯﾄｺﾒﾝﾄ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'cmdCancelHold
        '
        Me.cmdCancelHold.CausesValidation = false
        Me.cmdCancelHold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancelHold.Location = New System.Drawing.Point(208, 504)
        Me.cmdCancelHold.Name = "cmdCancelHold"
        Me.cmdCancelHold.Size = New System.Drawing.Size(85, 40)
        Me.cmdCancelHold.TabIndex = 14
        Me.cmdCancelHold.Text = "保留解除"
        '
        'cmdWFHold
        '
        Me.cmdWFHold.CausesValidation = false
        Me.cmdWFHold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFHold.Location = New System.Drawing.Point(308, 504)
        Me.cmdWFHold.Name = "cmdWFHold"
        Me.cmdWFHold.Size = New System.Drawing.Size(85, 40)
        Me.cmdWFHold.TabIndex = 15
        Me.cmdWFHold.Text = "在庫払出"
        Me.cmdWFHold.Visible = false
        '
        'cmdNowListHold
        '
        Me.cmdNowListHold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowListHold.Location = New System.Drawing.Point(646, 15)
        Me.cmdNowListHold.Name = "cmdNowListHold"
        Me.cmdNowListHold.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowListHold.TabIndex = 18
        Me.cmdNowListHold.Text = "最新取得"
        '
        'cmbDivisionHold
        '
        Me.cmbDivisionHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivisionHold.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivisionHold.GridForeColor = System.Drawing.Color.Black
        Me.cmbDivisionHold.Location = New System.Drawing.Point(8, 32)
        Me.cmbDivisionHold.Name = "cmbDivisionHold"
        Me.cmbDivisionHold.Size = New System.Drawing.Size(161, 22)
        Me.cmbDivisionHold.TabIndex = 11
        Me.cmbDivisionHold.Value = Nothing
        '
        'vsfLotListHold
        '
        Me.vsfLotListHold.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotListHold.AllowEditing = false
        Me.vsfLotListHold.AutoSearchDelay = 2R
        Me.vsfLotListHold.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotListHold.ColumnInfo = resources.GetString("vsfLotListHold.ColumnInfo")
        Me.vsfLotListHold.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotListHold.ExtendLastCol = true
        Me.vsfLotListHold.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfLotListHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotListHold.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotListHold.Location = New System.Drawing.Point(8, 88)
        Me.vsfLotListHold.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotListHold.Name = "vsfLotListHold"
        Me.vsfLotListHold.Rows.Count = 40
        Me.vsfLotListHold.Rows.DefaultSize = 18
        Me.vsfLotListHold.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotListHold.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotListHold.Size = New System.Drawing.Size(939, 401)
        Me.vsfLotListHold.StyleInfo = resources.GetString("vsfLotListHold.StyleInfo")
        Me.vsfLotListHold.TabIndex = 12
        '
        'lblTitleHoldChip
        '
        Me.lblTitleHoldChip.BackColor = System.Drawing.Color.White
        Me.lblTitleHoldChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHoldChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleHoldChip.Location = New System.Drawing.Point(731, 62)
        Me.lblTitleHoldChip.Name = "lblTitleHoldChip"
        Me.lblTitleHoldChip.Size = New System.Drawing.Size(112, 18)
        Me.lblTitleHoldChip.TabIndex = 109
        Me.lblTitleHoldChip.Text = "青字：Chip品"
        Me.lblTitleHoldChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleHoldChip.UseMnemonic = false
        '
        'lblTitleHoldL
        '
        Me.lblTitleHoldL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleHoldL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHoldL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHoldL.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHoldL.Location = New System.Drawing.Point(639, 62)
        Me.lblTitleHoldL.Name = "lblTitleHoldL"
        Me.lblTitleHoldL.Size = New System.Drawing.Size(47, 18)
        Me.lblTitleHoldL.TabIndex = 102
        Me.lblTitleHoldL.Text = "L"
        Me.lblTitleHoldL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleHoldL.UseMnemonic = false
        '
        'lblTitleHoldR
        '
        Me.lblTitleHoldR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleHoldR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHoldR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHoldR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHoldR.Location = New System.Drawing.Point(685, 62)
        Me.lblTitleHoldR.Name = "lblTitleHoldR"
        Me.lblTitleHoldR.Size = New System.Drawing.Size(47, 18)
        Me.lblTitleHoldR.TabIndex = 101
        Me.lblTitleHoldR.Text = "R"
        Me.lblTitleHoldR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleHoldR.UseMnemonic = false
        '
        'lblTitle17
        '
        Me.lblTitle17.BackColor = System.Drawing.Color.Yellow
        Me.lblTitle17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle17.ForeColor = System.Drawing.Color.Black
        Me.lblTitle17.Location = New System.Drawing.Point(842, 62)
        Me.lblTitle17.Name = "lblTitle17"
        Me.lblTitle17.Size = New System.Drawing.Size(105, 18)
        Me.lblTitle17.TabIndex = 85
        Me.lblTitle17.Text = "保留期限超過"
        Me.lblTitle17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDateHold
        '
        Me.lblNowDateHold.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDateHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateHold.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDateHold.Location = New System.Drawing.Point(742, 32)
        Me.lblNowDateHold.Name = "lblNowDateHold"
        Me.lblNowDateHold.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDateHold.TabIndex = 82
        Me.lblNowDateHold.Text = "07/15 13:11:25"
        '
        'lblTitle15
        '
        Me.lblTitle15.BackColor = System.Drawing.Color.Navy
        Me.lblTitle15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle15.Location = New System.Drawing.Point(742, 16)
        Me.lblTitle15.Name = "lblTitle15"
        Me.lblTitle15.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle15.TabIndex = 81
        Me.lblTitle15.Text = "情報取得日時"
        Me.lblTitle15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCntHold
        '
        Me.lblLotCntHold.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCntHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntHold.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCntHold.Location = New System.Drawing.Point(874, 32)
        Me.lblLotCntHold.Name = "lblLotCntHold"
        Me.lblLotCntHold.Size = New System.Drawing.Size(73, 21)
        Me.lblLotCntHold.TabIndex = 69
        Me.lblLotCntHold.Text = "0"
        Me.lblLotCntHold.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(874, 16)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle4.TabIndex = 68
        Me.lblTitle4.Text = "該当件数"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(8, 16)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle6.TabIndex = 67
        Me.lblTitle6.Text = "種別"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Tab2
        '
        Me.Tab2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab2.Controls.Add(Me.fraWF)
        Me.Tab2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab2.ForeColor = System.Drawing.Color.Black
        Me.Tab2.Location = New System.Drawing.Point(4, 25)
        Me.Tab2.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Size = New System.Drawing.Size(957, 552)
        Me.Tab2.TabIndex = 2
        Me.Tab2.Text = "中間WF在庫"
        '
        'fraWF
        '
        Me.fraWF.Controls.Add(Me.lblTitle20)
        Me.fraWF.Controls.Add(Me.lblTitle3)
        Me.fraWF.Controls.Add(Me.cmdMiddleWFInfo)
        Me.fraWF.Controls.Add(Me.cmdCarrierDetail)
        Me.fraWF.Controls.Add(Me.cmdNowListWF)
        Me.fraWF.Controls.Add(Me.FraCarrierInfo)
        Me.fraWF.Controls.Add(Me.cmdCarrierM)
        Me.fraWF.Controls.Add(Me.vsfLotListWF)
        Me.fraWF.Controls.Add(Me.cmbSBID0)
        Me.fraWF.Controls.Add(Me.txtLotID)
        Me.fraWF.Controls.Add(Me.lblNowDateWF)
        Me.fraWF.Controls.Add(Me.lblTitle13)
        Me.fraWF.Controls.Add(Me.lblTitle12)
        Me.fraWF.Controls.Add(Me.lblLotCntWF)
        Me.fraWF.Location = New System.Drawing.Point(0, 0)
        Me.fraWF.Name = "fraWF"
        Me.fraWF.Size = New System.Drawing.Size(957, 553)
        Me.fraWF.TabIndex = 64
        Me.fraWF.Text = "Frame1"
        '
        'lblTitle20
        '
        Me.lblTitle20.BackColor = System.Drawing.Color.Navy
        Me.lblTitle20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle20.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle20.Location = New System.Drawing.Point(164, 16)
        Me.lblTitle20.Name = "lblTitle20"
        Me.lblTitle20.Size = New System.Drawing.Size(183, 17)
        Me.lblTitle20.TabIndex = 100
        Me.lblTitle20.Text = "元ロットID(前方一致)"
        Me.lblTitle20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(12, 16)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(143, 17)
        Me.lblTitle3.TabIndex = 76
        Me.lblTitle3.Text = "利用SB"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdMiddleWFInfo
        '
        Me.cmdMiddleWFInfo.CausesValidation = false
        Me.cmdMiddleWFInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMiddleWFInfo.Location = New System.Drawing.Point(108, 504)
        Me.cmdMiddleWFInfo.Name = "cmdMiddleWFInfo"
        Me.cmdMiddleWFInfo.Size = New System.Drawing.Size(85, 40)
        Me.cmdMiddleWFInfo.TabIndex = 23
        Me.cmdMiddleWFInfo.Text = "WF情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'cmdCarrierDetail
        '
        Me.cmdCarrierDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierDetail.Location = New System.Drawing.Point(608, 504)
        Me.cmdCarrierDetail.Name = "cmdCarrierDetail"
        Me.cmdCarrierDetail.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierDetail.TabIndex = 24
        Me.cmdCarrierDetail.TabStop = false
        Me.cmdCarrierDetail.Text = "キャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"詳細参照"
        Me.cmdCarrierDetail.Visible = false
        '
        'cmdNowListWF
        '
        Me.cmdNowListWF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowListWF.Location = New System.Drawing.Point(392, 14)
        Me.cmdNowListWF.Name = "cmdNowListWF"
        Me.cmdNowListWF.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowListWF.TabIndex = 25
        Me.cmdNowListWF.Text = "最新取得"
        '
        'FraCarrierInfo
        '
        Me.FraCarrierInfo.Controls.Add(Me.vsfCarrierInfo)
        Me.FraCarrierInfo.Location = New System.Drawing.Point(704, 8)
        Me.FraCarrierInfo.Name = "FraCarrierInfo"
        Me.FraCarrierInfo.Size = New System.Drawing.Size(245, 517)
        Me.FraCarrierInfo.TabIndex = 26
        Me.FraCarrierInfo.TabStop = false
        Me.FraCarrierInfo.Text = "キャリア情報"
        '
        'vsfCarrierInfo
        '
        Me.vsfCarrierInfo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCarrierInfo.AllowEditing = false
        Me.vsfCarrierInfo.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfCarrierInfo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfCarrierInfo.AutoSearchDelay = 2R
        Me.vsfCarrierInfo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCarrierInfo.ColumnInfo = resources.GetString("vsfCarrierInfo.ColumnInfo")
        Me.vsfCarrierInfo.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCarrierInfo.ExtendLastCol = true
        Me.vsfCarrierInfo.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfCarrierInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCarrierInfo.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfCarrierInfo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCarrierInfo.Location = New System.Drawing.Point(16, 28)
        Me.vsfCarrierInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCarrierInfo.Name = "vsfCarrierInfo"
        Me.vsfCarrierInfo.Rows.Count = 26
        Me.vsfCarrierInfo.Rows.DefaultSize = 18
        Me.vsfCarrierInfo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfCarrierInfo.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCarrierInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCarrierInfo.Size = New System.Drawing.Size(213, 472)
        Me.vsfCarrierInfo.StyleInfo = resources.GetString("vsfCarrierInfo.StyleInfo")
        Me.vsfCarrierInfo.TabIndex = 26
        Me.vsfCarrierInfo.TabStop = false
        '
        'cmdCarrierM
        '
        Me.cmdCarrierM.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierM.Location = New System.Drawing.Point(8, 504)
        Me.cmdCarrierM.Name = "cmdCarrierM"
        Me.cmdCarrierM.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierM.TabIndex = 22
        Me.cmdCarrierM.Text = "メンテ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ナンス"
        '
        'vsfLotListWF
        '
        Me.vsfLotListWF.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotListWF.AllowEditing = false
        Me.vsfLotListWF.AutoResize = true
        Me.vsfLotListWF.AutoSearchDelay = 2R
        Me.vsfLotListWF.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotListWF.ColumnInfo = "12,0,0,0,0,105,Columns:0{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"5{Style:""DataType:System.Int32;TextAlign:Gene"& _ 
    "ralCenter;"";}"&Global.Microsoft.VisualBasic.ChrW(9)&"6{Style:""Format:""""#,##0"""";DataType:System.Int32;TextAlign:GeneralC"& _ 
    "enter;"";}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfLotListWF.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotListWF.ExtendLastCol = true
        Me.vsfLotListWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotListWF.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotListWF.Location = New System.Drawing.Point(8, 88)
        Me.vsfLotListWF.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotListWF.Name = "vsfLotListWF"
        Me.vsfLotListWF.Rows.Count = 40
        Me.vsfLotListWF.Rows.DefaultSize = 18
        Me.vsfLotListWF.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotListWF.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotListWF.Size = New System.Drawing.Size(685, 401)
        Me.vsfLotListWF.StyleInfo = resources.GetString("vsfLotListWF.StyleInfo")
        Me.vsfLotListWF.TabIndex = 21
        '
        'cmbSBID0
        '
        Me.cmbSBID0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbSBID0.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbSBID0.Location = New System.Drawing.Point(12, 32)
        Me.cmbSBID0.Name = "cmbSBID0"
        Me.cmbSBID0.Size = New System.Drawing.Size(143, 22)
        Me.cmbSBID0.TabIndex = 19
        Me.cmbSBID0.Value = Nothing
        '
        'txtLotID
        '
        Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLotID.ChrMaxByte = 10
        Me.txtLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotID.Location = New System.Drawing.Point(164, 32)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.NgChr = "'"
        Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotID.NumMax = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.txtLotID.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotID.SelectedText = ""
        Me.txtLotID.Size = New System.Drawing.Size(183, 22)
        Me.txtLotID.TabIndex = 20
        '
        'lblNowDateWF
        '
        Me.lblNowDateWF.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDateWF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateWF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDateWF.Location = New System.Drawing.Point(488, 32)
        Me.lblNowDateWF.Name = "lblNowDateWF"
        Me.lblNowDateWF.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDateWF.TabIndex = 78
        Me.lblNowDateWF.Text = "07/15 13:11:25"
        '
        'lblTitle13
        '
        Me.lblTitle13.BackColor = System.Drawing.Color.Navy
        Me.lblTitle13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle13.Location = New System.Drawing.Point(488, 16)
        Me.lblTitle13.Name = "lblTitle13"
        Me.lblTitle13.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle13.TabIndex = 77
        Me.lblTitle13.Text = "情報取得日時"
        Me.lblTitle13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle12
        '
        Me.lblTitle12.BackColor = System.Drawing.Color.Navy
        Me.lblTitle12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle12.Location = New System.Drawing.Point(619, 16)
        Me.lblTitle12.Name = "lblTitle12"
        Me.lblTitle12.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle12.TabIndex = 72
        Me.lblTitle12.Text = "該当件数"
        Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCntWF
        '
        Me.lblLotCntWF.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCntWF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntWF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCntWF.Location = New System.Drawing.Point(619, 32)
        Me.lblLotCntWF.Name = "lblLotCntWF"
        Me.lblLotCntWF.Size = New System.Drawing.Size(73, 21)
        Me.lblLotCntWF.TabIndex = 71
        Me.lblLotCntWF.Text = "0"
        Me.lblLotCntWF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Tab3
        '
        Me.Tab3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab3.Controls.Add(Me.fraSend)
        Me.Tab3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab3.ForeColor = System.Drawing.Color.Black
        Me.Tab3.Location = New System.Drawing.Point(4, 25)
        Me.Tab3.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Size = New System.Drawing.Size(957, 552)
        Me.Tab3.TabIndex = 3
        Me.Tab3.Text = "完成在庫（送品）"
        '
        'fraSend
        '
        Me.fraSend.Controls.Add(Me.lblTitle1)
        Me.fraSend.Controls.Add(Me.lblTtl5)
        Me.fraSend.Controls.Add(Me.lblTitle0)
        Me.fraSend.Controls.Add(Me.chkForign1)
        Me.fraSend.Controls.Add(Me.chkForign0)
        Me.fraSend.Controls.Add(Me.cmdSendWFInfo)
        Me.fraSend.Controls.Add(Me.optLotSendStatus1)
        Me.fraSend.Controls.Add(Me.optLotSendStatus0)
        Me.fraSend.Controls.Add(Me.cmdSendOrderList)
        Me.fraSend.Controls.Add(Me.cmdLotExamInfo)
        Me.fraSend.Controls.Add(Me.cmdSendRegist)
        Me.fraSend.Controls.Add(Me.cmdNextCommentSend)
        Me.fraSend.Controls.Add(Me.cmdCommentSend)
        Me.fraSend.Controls.Add(Me.cmdNowListSend)
        Me.fraSend.Controls.Add(Me.cmdHoldSend)
        Me.fraSend.Controls.Add(Me.cmdWFSend)
        Me.fraSend.Controls.Add(Me.cmdCancelSend)
        Me.fraSend.Controls.Add(Me.vsfLotListSend)
        Me.fraSend.Controls.Add(Me.cmbDivisionSend)
        Me.fraSend.Controls.Add(Me.cmbProductSend)
        Me.fraSend.Controls.Add(Me.calFromDate)
        Me.fraSend.Controls.Add(Me.calToDate)
        Me.fraSend.Controls.Add(Me.Label2)
        Me.fraSend.Controls.Add(Me.lblTitleSendChip)
        Me.fraSend.Controls.Add(Me.lblTitleSendR)
        Me.fraSend.Controls.Add(Me.lblTitleSendL)
        Me.fraSend.Controls.Add(Me.Label1)
        Me.fraSend.Controls.Add(Me.lblKara)
        Me.fraSend.Controls.Add(Me.lblNowDateSend)
        Me.fraSend.Controls.Add(Me.lblTitle16)
        Me.fraSend.Controls.Add(Me.lblTitle5)
        Me.fraSend.Controls.Add(Me.lblLotCntSend)
        Me.fraSend.Controls.Add(Me.lblTitle2)
        Me.fraSend.Location = New System.Drawing.Point(0, 0)
        Me.fraSend.Name = "fraSend"
        Me.fraSend.Size = New System.Drawing.Size(957, 553)
        Me.fraSend.TabIndex = 65
        Me.fraSend.Text = "Frame1"
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(8, 40)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle1.TabIndex = 90
        Me.lblTitle1.Text = "機種"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(336, 40)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(257, 17)
        Me.lblTtl5.TabIndex = 88
        Me.lblTtl5.Text = "期間"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(168, 40)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle0.TabIndex = 89
        Me.lblTitle0.Text = "種別"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkForign1
        '
        Me.chkForign1.Location = New System.Drawing.Point(356, 16)
        Me.chkForign1.Name = "chkForign1"
        Me.chkForign1.Size = New System.Drawing.Size(58, 18)
        Me.chkForign1.TabIndex = 30
        Me.chkForign1.Text = "海外"
        '
        'chkForign0
        '
        Me.chkForign0.Checked = true
        Me.chkForign0.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkForign0.Location = New System.Drawing.Point(288, 16)
        Me.chkForign0.Name = "chkForign0"
        Me.chkForign0.Size = New System.Drawing.Size(58, 18)
        Me.chkForign0.TabIndex = 29
        Me.chkForign0.Text = "国内"
        '
        'cmdSendWFInfo
        '
        Me.cmdSendWFInfo.CausesValidation = false
        Me.cmdSendWFInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSendWFInfo.Location = New System.Drawing.Point(8, 504)
        Me.cmdSendWFInfo.Name = "cmdSendWFInfo"
        Me.cmdSendWFInfo.Size = New System.Drawing.Size(85, 40)
        Me.cmdSendWFInfo.TabIndex = 37
        Me.cmdSendWFInfo.Text = "WF情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'optLotSendStatus1
        '
        Me.optLotSendStatus1.Enabled = false
        Me.optLotSendStatus1.Location = New System.Drawing.Point(152, 12)
        Me.optLotSendStatus1.Name = "optLotSendStatus1"
        Me.optLotSendStatus1.Size = New System.Drawing.Size(105, 24)
        Me.optLotSendStatus1.TabIndex = 28
        Me.optLotSendStatus1.Text = "送品済み"
        '
        'optLotSendStatus0
        '
        Me.optLotSendStatus0.Checked = true
        Me.optLotSendStatus0.Enabled = false
        Me.optLotSendStatus0.Location = New System.Drawing.Point(24, 12)
        Me.optLotSendStatus0.Name = "optLotSendStatus0"
        Me.optLotSendStatus0.Size = New System.Drawing.Size(105, 24)
        Me.optLotSendStatus0.TabIndex = 27
        Me.optLotSendStatus0.TabStop = true
        Me.optLotSendStatus0.Text = "送品待ち"
        '
        'cmdSendOrderList
        '
        Me.cmdSendOrderList.CausesValidation = false
        Me.cmdSendOrderList.Enabled = false
        Me.cmdSendOrderList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSendOrderList.Location = New System.Drawing.Point(660, 504)
        Me.cmdSendOrderList.Name = "cmdSendOrderList"
        Me.cmdSendOrderList.Size = New System.Drawing.Size(85, 40)
        Me.cmdSendOrderList.TabIndex = 43
        Me.cmdSendOrderList.Text = "送品伝票"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"印刷"
        '
        'cmdLotExamInfo
        '
        Me.cmdLotExamInfo.CausesValidation = false
        Me.cmdLotExamInfo.Enabled = false
        Me.cmdLotExamInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotExamInfo.Location = New System.Drawing.Point(760, 504)
        Me.cmdLotExamInfo.Name = "cmdLotExamInfo"
        Me.cmdLotExamInfo.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotExamInfo.TabIndex = 44
        Me.cmdLotExamInfo.Text = "ﾛｯﾄ検定表"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"印刷"
        '
        'cmdSendRegist
        '
        Me.cmdSendRegist.CausesValidation = false
        Me.cmdSendRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSendRegist.Location = New System.Drawing.Point(860, 504)
        Me.cmdSendRegist.Name = "cmdSendRegist"
        Me.cmdSendRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdSendRegist.TabIndex = 36
        Me.cmdSendRegist.Text = "送　品"
        '
        'cmdNextCommentSend
        '
        Me.cmdNextCommentSend.CausesValidation = false
        Me.cmdNextCommentSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNextCommentSend.Location = New System.Drawing.Point(508, 504)
        Me.cmdNextCommentSend.Name = "cmdNextCommentSend"
        Me.cmdNextCommentSend.Size = New System.Drawing.Size(85, 40)
        Me.cmdNextCommentSend.TabIndex = 42
        Me.cmdNextCommentSend.Text = "次SB連絡"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"登録"
        '
        'cmdCommentSend
        '
        Me.cmdCommentSend.CausesValidation = false
        Me.cmdCommentSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentSend.Location = New System.Drawing.Point(408, 504)
        Me.cmdCommentSend.Name = "cmdCommentSend"
        Me.cmdCommentSend.Size = New System.Drawing.Size(85, 40)
        Me.cmdCommentSend.TabIndex = 41
        Me.cmdCommentSend.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdNowListSend
        '
        Me.cmdNowListSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowListSend.Location = New System.Drawing.Point(646, 15)
        Me.cmdNowListSend.Name = "cmdNowListSend"
        Me.cmdNowListSend.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowListSend.TabIndex = 45
        Me.cmdNowListSend.Text = "最新取得"
        '
        'cmdHoldSend
        '
        Me.cmdHoldSend.CausesValidation = false
        Me.cmdHoldSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldSend.Location = New System.Drawing.Point(108, 504)
        Me.cmdHoldSend.Name = "cmdHoldSend"
        Me.cmdHoldSend.Size = New System.Drawing.Size(85, 40)
        Me.cmdHoldSend.TabIndex = 38
        Me.cmdHoldSend.Text = "保　留"
        '
        'cmdWFSend
        '
        Me.cmdWFSend.CausesValidation = false
        Me.cmdWFSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFSend.Location = New System.Drawing.Point(308, 504)
        Me.cmdWFSend.Name = "cmdWFSend"
        Me.cmdWFSend.Size = New System.Drawing.Size(85, 40)
        Me.cmdWFSend.TabIndex = 40
        Me.cmdWFSend.Text = "在庫払出"
        '
        'cmdCancelSend
        '
        Me.cmdCancelSend.CausesValidation = false
        Me.cmdCancelSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancelSend.Location = New System.Drawing.Point(208, 504)
        Me.cmdCancelSend.Name = "cmdCancelSend"
        Me.cmdCancelSend.Size = New System.Drawing.Size(85, 40)
        Me.cmdCancelSend.TabIndex = 39
        Me.cmdCancelSend.Text = "保留解除"
        '
        'vsfLotListSend
        '
        Me.vsfLotListSend.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotListSend.AllowEditing = false
        Me.vsfLotListSend.AutoSearchDelay = 2R
        Me.vsfLotListSend.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotListSend.ColumnInfo = resources.GetString("vsfLotListSend.ColumnInfo")
        Me.vsfLotListSend.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotListSend.ExtendLastCol = true
        Me.vsfLotListSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotListSend.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotListSend.Location = New System.Drawing.Point(8, 88)
        Me.vsfLotListSend.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotListSend.Name = "vsfLotListSend"
        Me.vsfLotListSend.Rows.Count = 40
        Me.vsfLotListSend.Rows.DefaultSize = 18
        Me.vsfLotListSend.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotListSend.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotListSend.Size = New System.Drawing.Size(939, 401)
        Me.vsfLotListSend.StyleInfo = resources.GetString("vsfLotListSend.StyleInfo")
        Me.vsfLotListSend.TabIndex = 35
        '
        'cmbDivisionSend
        '
        Me.cmbDivisionSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivisionSend.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDivisionSend.GridForeColor = System.Drawing.Color.Black
        Me.cmbDivisionSend.Location = New System.Drawing.Point(168, 56)
        Me.cmbDivisionSend.Name = "cmbDivisionSend"
        Me.cmbDivisionSend.Size = New System.Drawing.Size(161, 22)
        Me.cmbDivisionSend.TabIndex = 32
        Me.cmbDivisionSend.Value = Nothing
        '
        'cmbProductSend
        '
        Me.cmbProductSend.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbProductSend.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbProductSend.GridForeColor = System.Drawing.Color.Black
        Me.cmbProductSend.Location = New System.Drawing.Point(8, 56)
        Me.cmbProductSend.Name = "cmbProductSend"
        Me.cmbProductSend.Size = New System.Drawing.Size(161, 22)
        Me.cmbProductSend.TabIndex = 31
        Me.cmbProductSend.Value = Nothing
        '
        'calFromDate
        '
        Me.calFromDate.DateCheckStatus = 0
        Me.calFromDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.Enabled = false
        Me.calFromDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.IsDate = true
        Me.calFromDate.Location = New System.Drawing.Point(336, 56)
        Me.calFromDate.Name = "calFromDate"
        Me.calFromDate.Size = New System.Drawing.Size(109, 22)
        Me.calFromDate.TabIndex = 33
        Me.calFromDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calFromDate.Value = "____/__/__"
        '
        'calToDate
        '
        Me.calToDate.DateCheckStatus = 0
        Me.calToDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.Enabled = false
        Me.calToDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.IsDate = true
        Me.calToDate.Location = New System.Drawing.Point(481, 56)
        Me.calToDate.Name = "calToDate"
        Me.calToDate.Size = New System.Drawing.Size(112, 22)
        Me.calToDate.TabIndex = 34
        Me.calToDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calToDate.Value = "____/__/__"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(272, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 29)
        Me.Label2.TabIndex = 29
        '
        'lblTitleSendChip
        '
        Me.lblTitleSendChip.BackColor = System.Drawing.Color.White
        Me.lblTitleSendChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleSendChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleSendChip.Location = New System.Drawing.Point(786, 62)
        Me.lblTitleSendChip.Name = "lblTitleSendChip"
        Me.lblTitleSendChip.Size = New System.Drawing.Size(112, 18)
        Me.lblTitleSendChip.TabIndex = 110
        Me.lblTitleSendChip.Text = "青字：Chip品"
        Me.lblTitleSendChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleSendChip.UseMnemonic = false
        '
        'lblTitleSendR
        '
        Me.lblTitleSendR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleSendR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleSendR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleSendR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleSendR.Location = New System.Drawing.Point(740, 62)
        Me.lblTitleSendR.Name = "lblTitleSendR"
        Me.lblTitleSendR.Size = New System.Drawing.Size(47, 18)
        Me.lblTitleSendR.TabIndex = 104
        Me.lblTitleSendR.Text = "R"
        Me.lblTitleSendR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleSendR.UseMnemonic = false
        '
        'lblTitleSendL
        '
        Me.lblTitleSendL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleSendL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleSendL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleSendL.ForeColor = System.Drawing.Color.Black
        Me.lblTitleSendL.Location = New System.Drawing.Point(694, 62)
        Me.lblTitleSendL.Name = "lblTitleSendL"
        Me.lblTitleSendL.Size = New System.Drawing.Size(47, 18)
        Me.lblTitleSendL.TabIndex = 103
        Me.lblTitleSendL.Text = "L"
        Me.lblTitleSendL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleSendL.UseMnemonic = false
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(257, 29)
        Me.Label1.TabIndex = 27
        '
        'lblKara
        '
        Me.lblKara.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblKara.Location = New System.Drawing.Point(448, 56)
        Me.lblKara.Name = "lblKara"
        Me.lblKara.Size = New System.Drawing.Size(37, 21)
        Me.lblKara.TabIndex = 87
        Me.lblKara.Text = "～"
        '
        'lblNowDateSend
        '
        Me.lblNowDateSend.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDateSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateSend.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDateSend.Location = New System.Drawing.Point(742, 32)
        Me.lblNowDateSend.Name = "lblNowDateSend"
        Me.lblNowDateSend.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDateSend.TabIndex = 84
        Me.lblNowDateSend.Text = "07/15 13:11:25"
        '
        'lblTitle16
        '
        Me.lblTitle16.BackColor = System.Drawing.Color.Navy
        Me.lblTitle16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle16.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle16.Location = New System.Drawing.Point(742, 16)
        Me.lblTitle16.Name = "lblTitle16"
        Me.lblTitle16.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle16.TabIndex = 83
        Me.lblTitle16.Text = "情報取得日時"
        Me.lblTitle16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Yellow
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.ForeColor = System.Drawing.Color.Black
        Me.lblTitle5.Location = New System.Drawing.Point(897, 62)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(49, 18)
        Me.lblTitle5.TabIndex = 75
        Me.lblTitle5.Text = "保留"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCntSend
        '
        Me.lblLotCntSend.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCntSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntSend.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCntSend.Location = New System.Drawing.Point(873, 32)
        Me.lblLotCntSend.Name = "lblLotCntSend"
        Me.lblLotCntSend.Size = New System.Drawing.Size(73, 21)
        Me.lblLotCntSend.TabIndex = 74
        Me.lblLotCntSend.Text = "0"
        Me.lblLotCntSend.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(873, 16)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle2.TabIndex = 73
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Tab4
        '
        Me.Tab4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab4.Controls.Add(Me.fraCFEnd)
        Me.Tab4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab4.ForeColor = System.Drawing.Color.Black
        Me.Tab4.Location = New System.Drawing.Point(4, 25)
        Me.Tab4.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab4.Name = "Tab4"
        Me.Tab4.Size = New System.Drawing.Size(957, 552)
        Me.Tab4.TabIndex = 4
        Me.Tab4.Text = "完成在庫（CF）"
        '
        'fraCFEnd
        '
        Me.fraCFEnd.Controls.Add(Me.lblTitle19)
        Me.fraCFEnd.Controls.Add(Me.cmdCFEndWFInfo)
        Me.fraCFEnd.Controls.Add(Me.cmdCommentCFEnd)
        Me.fraCFEnd.Controls.Add(Me.cmdCancelCFEnd)
        Me.fraCFEnd.Controls.Add(Me.cmdCFEnd)
        Me.fraCFEnd.Controls.Add(Me.cmdHoldCFEnd)
        Me.fraCFEnd.Controls.Add(Me.cmdNowListCFEnd)
        Me.fraCFEnd.Controls.Add(Me.cmdRework)
        Me.fraCFEnd.Controls.Add(Me.vsfLotListCFEnd)
        Me.fraCFEnd.Controls.Add(Me.cmbProductCFEnd)
        Me.fraCFEnd.Controls.Add(Me.lblNum)
        Me.fraCFEnd.Controls.Add(Me.lblTitle24)
        Me.fraCFEnd.Controls.Add(Me.lblTitleCfEndL)
        Me.fraCFEnd.Controls.Add(Me.lblTitleCfEndR)
        Me.fraCFEnd.Controls.Add(Me.lblTitle23)
        Me.fraCFEnd.Controls.Add(Me.lblLotCntCFEnd)
        Me.fraCFEnd.Controls.Add(Me.lblTitle22)
        Me.fraCFEnd.Controls.Add(Me.lblTitle21)
        Me.fraCFEnd.Controls.Add(Me.lblNowDateCFEnd)
        Me.fraCFEnd.Location = New System.Drawing.Point(0, 0)
        Me.fraCFEnd.Name = "fraCFEnd"
        Me.fraCFEnd.Size = New System.Drawing.Size(957, 553)
        Me.fraCFEnd.TabIndex = 93
        Me.fraCFEnd.Text = "Frame1"
        '
        'lblTitle19
        '
        Me.lblTitle19.BackColor = System.Drawing.Color.Navy
        Me.lblTitle19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle19.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle19.Location = New System.Drawing.Point(8, 16)
        Me.lblTitle19.Name = "lblTitle19"
        Me.lblTitle19.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle19.TabIndex = 94
        Me.lblTitle19.Text = "機種"
        Me.lblTitle19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCFEndWFInfo
        '
        Me.cmdCFEndWFInfo.CausesValidation = false
        Me.cmdCFEndWFInfo.Enabled = false
        Me.cmdCFEndWFInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCFEndWFInfo.Location = New System.Drawing.Point(608, 504)
        Me.cmdCFEndWFInfo.Name = "cmdCFEndWFInfo"
        Me.cmdCFEndWFInfo.Size = New System.Drawing.Size(85, 40)
        Me.cmdCFEndWFInfo.TabIndex = 53
        Me.cmdCFEndWFInfo.Text = "WF情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        Me.cmdCFEndWFInfo.Visible = false
        '
        'cmdCommentCFEnd
        '
        Me.cmdCommentCFEnd.CausesValidation = false
        Me.cmdCommentCFEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentCFEnd.Location = New System.Drawing.Point(408, 504)
        Me.cmdCommentCFEnd.Name = "cmdCommentCFEnd"
        Me.cmdCommentCFEnd.Size = New System.Drawing.Size(85, 40)
        Me.cmdCommentCFEnd.TabIndex = 51
        Me.cmdCommentCFEnd.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdCancelCFEnd
        '
        Me.cmdCancelCFEnd.CausesValidation = false
        Me.cmdCancelCFEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancelCFEnd.Location = New System.Drawing.Point(208, 504)
        Me.cmdCancelCFEnd.Name = "cmdCancelCFEnd"
        Me.cmdCancelCFEnd.Size = New System.Drawing.Size(85, 40)
        Me.cmdCancelCFEnd.TabIndex = 49
        Me.cmdCancelCFEnd.Text = "保留解除"
        '
        'cmdCFEnd
        '
        Me.cmdCFEnd.CausesValidation = false
        Me.cmdCFEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCFEnd.Location = New System.Drawing.Point(308, 504)
        Me.cmdCFEnd.Name = "cmdCFEnd"
        Me.cmdCFEnd.Size = New System.Drawing.Size(85, 40)
        Me.cmdCFEnd.TabIndex = 50
        Me.cmdCFEnd.Text = "在庫処置"
        '
        'cmdHoldCFEnd
        '
        Me.cmdHoldCFEnd.CausesValidation = false
        Me.cmdHoldCFEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldCFEnd.Location = New System.Drawing.Point(108, 504)
        Me.cmdHoldCFEnd.Name = "cmdHoldCFEnd"
        Me.cmdHoldCFEnd.Size = New System.Drawing.Size(85, 40)
        Me.cmdHoldCFEnd.TabIndex = 48
        Me.cmdHoldCFEnd.Text = "保　留"
        '
        'cmdNowListCFEnd
        '
        Me.cmdNowListCFEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowListCFEnd.Location = New System.Drawing.Point(646, 15)
        Me.cmdNowListCFEnd.Name = "cmdNowListCFEnd"
        Me.cmdNowListCFEnd.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowListCFEnd.TabIndex = 54
        Me.cmdNowListCFEnd.Text = "最新取得"
        '
        'cmdRework
        '
        Me.cmdRework.CausesValidation = false
        Me.cmdRework.Enabled = false
        Me.cmdRework.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRework.Location = New System.Drawing.Point(508, 504)
        Me.cmdRework.Name = "cmdRework"
        Me.cmdRework.Size = New System.Drawing.Size(85, 40)
        Me.cmdRework.TabIndex = 52
        Me.cmdRework.Text = "リワーク"
        '
        'vsfLotListCFEnd
        '
        Me.vsfLotListCFEnd.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotListCFEnd.AllowEditing = false
        Me.vsfLotListCFEnd.AutoSearchDelay = 2R
        Me.vsfLotListCFEnd.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotListCFEnd.ColumnInfo = resources.GetString("vsfLotListCFEnd.ColumnInfo")
        Me.vsfLotListCFEnd.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotListCFEnd.ExtendLastCol = true
        Me.vsfLotListCFEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotListCFEnd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotListCFEnd.Location = New System.Drawing.Point(8, 88)
        Me.vsfLotListCFEnd.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotListCFEnd.Name = "vsfLotListCFEnd"
        Me.vsfLotListCFEnd.Rows.Count = 40
        Me.vsfLotListCFEnd.Rows.DefaultSize = 18
        Me.vsfLotListCFEnd.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotListCFEnd.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotListCFEnd.Size = New System.Drawing.Size(939, 375)
        Me.vsfLotListCFEnd.StyleInfo = resources.GetString("vsfLotListCFEnd.StyleInfo")
        Me.vsfLotListCFEnd.TabIndex = 47
        '
        'cmbProductCFEnd
        '
        Me.cmbProductCFEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbProductCFEnd.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbProductCFEnd.GridForeColor = System.Drawing.Color.Black
        Me.cmbProductCFEnd.Location = New System.Drawing.Point(8, 32)
        Me.cmbProductCFEnd.Name = "cmbProductCFEnd"
        Me.cmbProductCFEnd.Size = New System.Drawing.Size(161, 22)
        Me.cmbProductCFEnd.TabIndex = 46
        Me.cmbProductCFEnd.Value = Nothing
        '
        'lblNum
        '
        Me.lblNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNum.Location = New System.Drawing.Point(263, 476)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(114, 17)
        Me.lblNum.TabIndex = 108
        Me.lblNum.Text = "0"
        Me.lblNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle24
        '
        Me.lblTitle24.BackColor = System.Drawing.Color.Navy
        Me.lblTitle24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle24.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle24.Location = New System.Drawing.Point(8, 476)
        Me.lblTitle24.Name = "lblTitle24"
        Me.lblTitle24.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle24.TabIndex = 107
        Me.lblTitle24.Text = "合計チップ数量"
        Me.lblTitle24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleCfEndL
        '
        Me.lblTitleCfEndL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleCfEndL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleCfEndL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleCfEndL.ForeColor = System.Drawing.Color.Black
        Me.lblTitleCfEndL.Location = New System.Drawing.Point(802, 62)
        Me.lblTitleCfEndL.Name = "lblTitleCfEndL"
        Me.lblTitleCfEndL.Size = New System.Drawing.Size(49, 18)
        Me.lblTitleCfEndL.TabIndex = 106
        Me.lblTitleCfEndL.Text = "L"
        Me.lblTitleCfEndL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleCfEndL.UseMnemonic = false
        '
        'lblTitleCfEndR
        '
        Me.lblTitleCfEndR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleCfEndR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleCfEndR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleCfEndR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleCfEndR.Location = New System.Drawing.Point(850, 62)
        Me.lblTitleCfEndR.Name = "lblTitleCfEndR"
        Me.lblTitleCfEndR.Size = New System.Drawing.Size(49, 18)
        Me.lblTitleCfEndR.TabIndex = 105
        Me.lblTitleCfEndR.Text = "R"
        Me.lblTitleCfEndR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleCfEndR.UseMnemonic = false
        '
        'lblTitle23
        '
        Me.lblTitle23.BackColor = System.Drawing.Color.Navy
        Me.lblTitle23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle23.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle23.Location = New System.Drawing.Point(874, 16)
        Me.lblTitle23.Name = "lblTitle23"
        Me.lblTitle23.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle23.TabIndex = 99
        Me.lblTitle23.Text = "該当件数"
        Me.lblTitle23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCntCFEnd
        '
        Me.lblLotCntCFEnd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCntCFEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntCFEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCntCFEnd.Location = New System.Drawing.Point(874, 32)
        Me.lblLotCntCFEnd.Name = "lblLotCntCFEnd"
        Me.lblLotCntCFEnd.Size = New System.Drawing.Size(73, 21)
        Me.lblLotCntCFEnd.TabIndex = 98
        Me.lblLotCntCFEnd.Text = "0"
        Me.lblLotCntCFEnd.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle22
        '
        Me.lblTitle22.BackColor = System.Drawing.Color.Yellow
        Me.lblTitle22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle22.ForeColor = System.Drawing.Color.Black
        Me.lblTitle22.Location = New System.Drawing.Point(898, 62)
        Me.lblTitle22.Name = "lblTitle22"
        Me.lblTitle22.Size = New System.Drawing.Size(49, 18)
        Me.lblTitle22.TabIndex = 97
        Me.lblTitle22.Text = "保留"
        Me.lblTitle22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle21
        '
        Me.lblTitle21.BackColor = System.Drawing.Color.Navy
        Me.lblTitle21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle21.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle21.Location = New System.Drawing.Point(742, 16)
        Me.lblTitle21.Name = "lblTitle21"
        Me.lblTitle21.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle21.TabIndex = 96
        Me.lblTitle21.Text = "情報取得日時"
        Me.lblTitle21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDateCFEnd
        '
        Me.lblNowDateCFEnd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDateCFEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateCFEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDateCFEnd.Location = New System.Drawing.Point(742, 32)
        Me.lblNowDateCFEnd.Name = "lblNowDateCFEnd"
        Me.lblNowDateCFEnd.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDateCFEnd.TabIndex = 95
        Me.lblNowDateCFEnd.Text = "07/15 13:11:25"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 595)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 57
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxEN00F0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00F0"
        Me.Text = "在庫管理"
        Me.tabControl.ResumeLayout(false)
        Me.Tab0.ResumeLayout(false)
        Me.fraPut.ResumeLayout(false)
        CType(Me.vsfLotListPut,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab1.ResumeLayout(false)
        Me.fraHold.ResumeLayout(false)
        CType(Me.vsfLotListHold,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab2.ResumeLayout(false)
        Me.fraWF.ResumeLayout(false)
        Me.FraCarrierInfo.ResumeLayout(false)
        CType(Me.vsfCarrierInfo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfLotListWF,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab3.ResumeLayout(false)
        Me.fraSend.ResumeLayout(false)
        CType(Me.vsfLotListSend,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab4.ResumeLayout(false)
        Me.fraCFEnd.ResumeLayout(false)
        CType(Me.vsfLotListCFEnd,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCopy As Button
    Friend WithEvents tabControl As TabControl
    Friend WithEvents Tab0 As TabPage
    Friend WithEvents fraPut As Panel
    Friend WithEvents cmdPutWFInfo As Button
    Friend WithEvents cmdPreCommentSend As Button
    Friend WithEvents cmdCommentPut As Button
    Friend WithEvents cmdHoldPut As Button
    Friend WithEvents cmdWFPut As Button
    Friend WithEvents cmdPartition As Button
    Friend WithEvents cmdCancelPut As Button
    Friend WithEvents cmdNowListPut As Button
    Friend WithEvents cmbDivisionPut As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbProductPut As SECmbIchiran.ComboIchiran
    Friend WithEvents vsfLotListPut As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitle18 As Label
    Friend WithEvents lblNowDatePut As Label
    Friend WithEvents lblTitle14 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblLotCntPut As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents Tab1 As TabPage
    Friend WithEvents fraHold As Panel
    Friend WithEvents cmdHoldWFInfo As Button
    Friend WithEvents cmdHoldHold As Button
    Friend WithEvents cmdCommentHold As Button
    Friend WithEvents cmdCancelHold As Button
    Friend WithEvents cmdWFHold As Button
    Friend WithEvents cmdNowListHold As Button
    Friend WithEvents cmbDivisionHold As SECmbIchiran.ComboIchiran
    Friend WithEvents vsfLotListHold As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleHoldChip As Label
    Friend WithEvents lblTitleHoldL As Label
    Friend WithEvents lblTitleHoldR As Label
    Friend WithEvents lblTitle17 As Label
    Friend WithEvents lblNowDateHold As Label
    Friend WithEvents lblTitle15 As Label
    Friend WithEvents lblLotCntHold As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents Tab2 As TabPage
    Friend WithEvents fraWF As Panel
    Friend WithEvents cmdMiddleWFInfo As Button
    Friend WithEvents cmdCarrierDetail As Button
    Friend WithEvents cmdNowListWF As Button
    Friend WithEvents FraCarrierInfo As GroupBox
    Friend WithEvents vsfCarrierInfo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdCarrierM As Button
    Friend WithEvents vsfLotListWF As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbSBID0 As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle20 As Label
    Friend WithEvents lblNowDateWF As Label
    Friend WithEvents lblTitle13 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle12 As Label
    Friend WithEvents lblLotCntWF As Label
    Friend WithEvents Tab3 As TabPage
    Friend WithEvents fraSend As Panel
    Friend WithEvents chkForign1 As CheckBox
    Friend WithEvents chkForign0 As CheckBox
    Friend WithEvents cmdSendWFInfo As Button
    Friend WithEvents optLotSendStatus1 As RadioButton
    Friend WithEvents optLotSendStatus0 As RadioButton
    Friend WithEvents cmdSendOrderList As Button
    Friend WithEvents cmdLotExamInfo As Button
    Friend WithEvents cmdSendRegist As Button
    Friend WithEvents cmdNextCommentSend As Button
    Friend WithEvents cmdCommentSend As Button
    Friend WithEvents cmdNowListSend As Button
    Friend WithEvents cmdHoldSend As Button
    Friend WithEvents cmdWFSend As Button
    Friend WithEvents cmdCancelSend As Button
    Friend WithEvents vsfLotListSend As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbDivisionSend As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbProductSend As SECmbIchiran.ComboIchiran
    Friend WithEvents calFromDate As SECalendarEx.CalendarEx
    Friend WithEvents calToDate As SECalendarEx.CalendarEx
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTitleSendChip As Label
    Friend WithEvents lblTitleSendR As Label
    Friend WithEvents lblTitleSendL As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblKara As Label
    Friend WithEvents lblNowDateSend As Label
    Friend WithEvents lblTitle16 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblLotCntSend As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents Tab4 As TabPage
    Friend WithEvents fraCFEnd As Panel
    Friend WithEvents cmdCFEndWFInfo As Button
    Friend WithEvents cmdCommentCFEnd As Button
    Friend WithEvents cmdCancelCFEnd As Button
    Friend WithEvents cmdCFEnd As Button
    Friend WithEvents cmdHoldCFEnd As Button
    Friend WithEvents cmdNowListCFEnd As Button
    Friend WithEvents cmdRework As Button
    Friend WithEvents vsfLotListCFEnd As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbProductCFEnd As SECmbIchiran.ComboIchiran
    Friend WithEvents lblNum As Label
    Friend WithEvents lblTitle24 As Label
    Friend WithEvents lblTitleCfEndL As Label
    Friend WithEvents lblTitleCfEndR As Label
    Friend WithEvents lblTitle23 As Label
    Friend WithEvents lblLotCntCFEnd As Label
    Friend WithEvents lblTitle22 As Label
    Friend WithEvents lblTitle21 As Label
    Friend WithEvents lblNowDateCFEnd As Label
    Friend WithEvents lblTitle19 As Label
    Friend WithEvents cmdClose As Button
End Class
