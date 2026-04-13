<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02U0
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02U0))
		Me.tabODF = New System.Windows.Forms.TabControl()
		Me.fraTab0 = New System.Windows.Forms.TabPage()
		Me.fraODF0 = New System.Windows.Forms.Panel()
		Me.lblReserveStatus = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.lblCFCarrierId = New System.Windows.Forms.Label()
		Me.lblTFTCarrierId = New System.Windows.Forms.Label()
		Me.cmdCFMoveCancel = New System.Windows.Forms.Button()
		Me.cmdCFMove = New System.Windows.Forms.Button()
		Me.cmdTFTMoveCancel = New System.Windows.Forms.Button()
		Me.cmdTFTMove = New System.Windows.Forms.Button()
		Me.vsfCFWfList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.vsfTFTWfList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.lblCFLotList = New System.Windows.Forms.Label()
		Me.lblTFTLotList = New System.Windows.Forms.Label()
		Me.cmbTFTandCF = New SEComboBoxEx.ComboBoxEx()
		Me.vsfCFList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.vsfTFTList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.cmdReserveLotList = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblNowDate0 = New System.Windows.Forms.Label()
		Me.cmdDel = New System.Windows.Forms.Button()
		Me.cmdRegist = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblTitle03 = New System.Windows.Forms.Label()
		Me.lblTFTLotId = New System.Windows.Forms.Label()
		Me.lblTitle06 = New System.Windows.Forms.Label()
		Me.lblCFLotId = New System.Windows.Forms.Label()
		Me.lblTitle0 = New System.Windows.Forms.Label()
		Me.txtDummy0 = New System.Windows.Forms.TextBox()
		Me.fraTab1 = New System.Windows.Forms.TabPage()
		Me.fraODF1 = New System.Windows.Forms.Panel()
		Me.vsfReserveInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.lblWfId = New SETextBoxEx.TextBoxEx()
		Me.lblLotId = New SETextBoxEx.TextBoxEx()
		Me.cmdReserveInfo = New System.Windows.Forms.Button()
		Me.lblTitle5 = New System.Windows.Forms.Label()
		Me.lblTitle7 = New System.Windows.Forms.Label()
		Me.lblNowDate1 = New System.Windows.Forms.Label()
		Me.lblTitle1 = New System.Windows.Forms.Label()
		Me.fraTab2 = New System.Windows.Forms.TabPage()
		Me.fraODF2 = New System.Windows.Forms.Panel()
		Me.lblCaution = New System.Windows.Forms.Label()
		Me.lblSelectWfCntTitle = New System.Windows.Forms.Label()
		Me.lblSelectWfCnt = New System.Windows.Forms.Label()
		Me.vsfHyoumenReserveInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.cmdHyoumenDel = New System.Windows.Forms.Button()
		Me.cmdHyoumenRegist = New System.Windows.Forms.Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.optAll = New System.Windows.Forms.RadioButton()
		Me.optDone = New System.Windows.Forms.RadioButton()
		Me.optNone = New System.Windows.Forms.RadioButton()
		Me.lblTitle8 = New System.Windows.Forms.Label()
		Me.lblBackReason = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.lblNowDate2 = New System.Windows.Forms.Label()
		Me.cmdHyoumenReserveInfo = New System.Windows.Forms.Button()
		Me.fraTab3 = New System.Windows.Forms.TabPage()
		Me.fraODF3 = New System.Windows.Forms.Panel()
		Me.cmdAfterJReserveList = New System.Windows.Forms.Button()
		Me.cmd5wf = New System.Windows.Forms.Button()
		Me.cmd10wf = New System.Windows.Forms.Button()
		Me.lblReserveStatus2 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.cmdReserveJRegist = New System.Windows.Forms.Button()
		Me.cmdReserveJDel = New System.Windows.Forms.Button()
		Me.fraGroupD = New System.Windows.Forms.GroupBox()
		Me.txtToCarrier4 = New SETextBoxEx.TextBoxEx()
		Me.cmdCarrierSelect4 = New System.Windows.Forms.Button()
		Me.lblToCarrierID4 = New System.Windows.Forms.Label()
		Me.vsfToSlotMap4 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.fraGroupC = New System.Windows.Forms.GroupBox()
		Me.txtToCarrier3 = New SETextBoxEx.TextBoxEx()
		Me.cmdCarrierSelect3 = New System.Windows.Forms.Button()
		Me.lblToCarrierID3 = New System.Windows.Forms.Label()
		Me.vsfToSlotMap3 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.fraGroupB = New System.Windows.Forms.GroupBox()
		Me.txtToCarrier2 = New SETextBoxEx.TextBoxEx()
		Me.cmdCarrierSelect2 = New System.Windows.Forms.Button()
		Me.lblToCarrierID2 = New System.Windows.Forms.Label()
		Me.vsfToSlotMap2 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.fraGroupA = New System.Windows.Forms.GroupBox()
		Me.txtToCarrier1 = New SETextBoxEx.TextBoxEx()
		Me.cmdCarrierSelect1 = New System.Windows.Forms.Button()
		Me.lblToCarrierID1 = New System.Windows.Forms.Label()
		Me.vsfToSlotMap1 = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.fraSlotMap = New System.Windows.Forms.GroupBox()
		Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.lblLotID1 = New System.Windows.Forms.Label()
		Me.lbTitleLotID = New System.Windows.Forms.Label()
		Me.txtCarrier = New SETextBoxEx.TextBoxEx()
		Me.lblTitle = New System.Windows.Forms.Label()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.tabODF.SuspendLayout
		Me.fraTab0.SuspendLayout
		Me.fraODF0.SuspendLayout
		CType(Me.vsfCFWfList,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.vsfTFTWfList,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.vsfCFList,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.vsfTFTList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.fraTab1.SuspendLayout
		Me.fraODF1.SuspendLayout
		CType(Me.vsfReserveInfo,System.ComponentModel.ISupportInitialize).BeginInit
		Me.fraTab2.SuspendLayout
		Me.fraODF2.SuspendLayout
		CType(Me.vsfHyoumenReserveInfo,System.ComponentModel.ISupportInitialize).BeginInit
		Me.Panel1.SuspendLayout
		Me.fraTab3.SuspendLayout
		Me.fraODF3.SuspendLayout
		Me.fraGroupD.SuspendLayout
		CType(Me.vsfToSlotMap4,System.ComponentModel.ISupportInitialize).BeginInit
		Me.fraGroupC.SuspendLayout
		CType(Me.vsfToSlotMap3,System.ComponentModel.ISupportInitialize).BeginInit
		Me.fraGroupB.SuspendLayout
		CType(Me.vsfToSlotMap2,System.ComponentModel.ISupportInitialize).BeginInit
		Me.fraGroupA.SuspendLayout
		CType(Me.vsfToSlotMap1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.fraSlotMap.SuspendLayout
		CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'tabODF
		'
		Me.tabODF.Controls.Add(Me.fraTab0)
		Me.tabODF.Controls.Add(Me.fraTab1)
		Me.tabODF.Controls.Add(Me.fraTab2)
		Me.tabODF.Controls.Add(Me.fraTab3)
		Me.tabODF.ItemSize = New System.Drawing.Size(240, 21)
		Me.tabODF.Location = New System.Drawing.Point(8, 10)
		Me.tabODF.Name = "tabODF"
		Me.tabODF.SelectedIndex = 0
		Me.tabODF.Size = New System.Drawing.Size(965, 581)
		Me.tabODF.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
		Me.tabODF.TabIndex = 50
		'
		'fraTab0
		'
		Me.fraTab0.BackColor = System.Drawing.SystemColors.ControlLight
		Me.fraTab0.Controls.Add(Me.fraODF0)
		Me.fraTab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraTab0.ForeColor = System.Drawing.Color.Black
		Me.fraTab0.Location = New System.Drawing.Point(4, 25)
		Me.fraTab0.Margin = New System.Windows.Forms.Padding(0)
		Me.fraTab0.Name = "fraTab0"
		Me.fraTab0.Size = New System.Drawing.Size(957, 552)
		Me.fraTab0.TabIndex = 0
		Me.fraTab0.Text = "ODF予約"
		'
		'fraODF0
		'
		Me.fraODF0.Controls.Add(Me.lblReserveStatus)
		Me.fraODF0.Controls.Add(Me.Label5)
		Me.fraODF0.Controls.Add(Me.lblCFCarrierId)
		Me.fraODF0.Controls.Add(Me.lblTFTCarrierId)
		Me.fraODF0.Controls.Add(Me.cmdCFMoveCancel)
		Me.fraODF0.Controls.Add(Me.cmdCFMove)
		Me.fraODF0.Controls.Add(Me.cmdTFTMoveCancel)
		Me.fraODF0.Controls.Add(Me.cmdTFTMove)
		Me.fraODF0.Controls.Add(Me.vsfCFWfList)
		Me.fraODF0.Controls.Add(Me.vsfTFTWfList)
		Me.fraODF0.Controls.Add(Me.lblCFLotList)
		Me.fraODF0.Controls.Add(Me.lblTFTLotList)
		Me.fraODF0.Controls.Add(Me.cmbTFTandCF)
		Me.fraODF0.Controls.Add(Me.vsfCFList)
		Me.fraODF0.Controls.Add(Me.vsfTFTList)
		Me.fraODF0.Controls.Add(Me.cmdReserveLotList)
		Me.fraODF0.Controls.Add(Me.Label2)
		Me.fraODF0.Controls.Add(Me.lblNowDate0)
		Me.fraODF0.Controls.Add(Me.cmdDel)
		Me.fraODF0.Controls.Add(Me.cmdRegist)
		Me.fraODF0.Controls.Add(Me.Label1)
		Me.fraODF0.Controls.Add(Me.lblTitle03)
		Me.fraODF0.Controls.Add(Me.lblTFTLotId)
		Me.fraODF0.Controls.Add(Me.lblTitle06)
		Me.fraODF0.Controls.Add(Me.lblCFLotId)
		Me.fraODF0.Controls.Add(Me.lblTitle0)
		Me.fraODF0.Controls.Add(Me.txtDummy0)
		Me.fraODF0.Location = New System.Drawing.Point(0, 0)
		Me.fraODF0.Name = "fraODF0"
		Me.fraODF0.Size = New System.Drawing.Size(959, 555)
		Me.fraODF0.TabIndex = 54
		'
		'lblReserveStatus
		'
		Me.lblReserveStatus.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblReserveStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblReserveStatus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblReserveStatus.Location = New System.Drawing.Point(541, 30)
		Me.lblReserveStatus.Name = "lblReserveStatus"
		Me.lblReserveStatus.Size = New System.Drawing.Size(85, 22)
		Me.lblReserveStatus.TabIndex = 114
		Me.lblReserveStatus.Text = "未/済"
		'
		'Label5
		'
		Me.Label5.BackColor = System.Drawing.Color.Navy
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label5.ForeColor = System.Drawing.Color.Yellow
		Me.Label5.Location = New System.Drawing.Point(541, 13)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(85, 17)
		Me.Label5.TabIndex = 113
		Me.Label5.Text = "予約状態"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblCFCarrierId
		'
		Me.lblCFCarrierId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblCFCarrierId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCFCarrierId.Location = New System.Drawing.Point(883, 30)
		Me.lblCFCarrierId.Name = "lblCFCarrierId"
		Me.lblCFCarrierId.Size = New System.Drawing.Size(66, 22)
		Me.lblCFCarrierId.TabIndex = 112
		'
		'lblTFTCarrierId
		'
		Me.lblTFTCarrierId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTFTCarrierId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblTFTCarrierId.Location = New System.Drawing.Point(721, 30)
		Me.lblTFTCarrierId.Name = "lblTFTCarrierId"
		Me.lblTFTCarrierId.Size = New System.Drawing.Size(66, 22)
		Me.lblTFTCarrierId.TabIndex = 111
		'
		'cmdCFMoveCancel
		'
		Me.cmdCFMoveCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCFMoveCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdCFMoveCancel.Location = New System.Drawing.Point(541, 429)
		Me.cmdCFMoveCancel.Name = "cmdCFMoveCancel"
		Me.cmdCFMoveCancel.Size = New System.Drawing.Size(85, 40)
		Me.cmdCFMoveCancel.TabIndex = 110
		Me.cmdCFMoveCancel.Text = "<"
		'
		'cmdCFMove
		'
		Me.cmdCFMove.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCFMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdCFMove.Location = New System.Drawing.Point(541, 374)
		Me.cmdCFMove.Name = "cmdCFMove"
		Me.cmdCFMove.Size = New System.Drawing.Size(85, 40)
		Me.cmdCFMove.TabIndex = 109
		Me.cmdCFMove.Text = ">"
		'
		'cmdTFTMoveCancel
		'
		Me.cmdTFTMoveCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdTFTMoveCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdTFTMoveCancel.Location = New System.Drawing.Point(541, 194)
		Me.cmdTFTMoveCancel.Name = "cmdTFTMoveCancel"
		Me.cmdTFTMoveCancel.Size = New System.Drawing.Size(85, 40)
		Me.cmdTFTMoveCancel.TabIndex = 108
		Me.cmdTFTMoveCancel.Text = "<"
		'
		'cmdTFTMove
		'
		Me.cmdTFTMove.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdTFTMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdTFTMove.Location = New System.Drawing.Point(541, 138)
		Me.cmdTFTMove.Name = "cmdTFTMove"
		Me.cmdTFTMove.Size = New System.Drawing.Size(85, 40)
		Me.cmdTFTMove.TabIndex = 107
		Me.cmdTFTMove.Text = ">"
		'
		'vsfCFWfList
		'
		Me.vsfCFWfList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfCFWfList.AllowEditing = false
		Me.vsfCFWfList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfCFWfList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfCFWfList.AutoResize = true
		Me.vsfCFWfList.AutoSearchDelay = 2R
		Me.vsfCFWfList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfCFWfList.ColumnInfo = resources.GetString("vsfCFWfList.ColumnInfo")
		Me.vsfCFWfList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfCFWfList.ExtendLastCol = true
		Me.vsfCFWfList.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfCFWfList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfCFWfList.Location = New System.Drawing.Point(793, 52)
		Me.vsfCFWfList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfCFWfList.Name = "vsfCFWfList"
		Me.vsfCFWfList.Rows.Count = 26
		Me.vsfCFWfList.Rows.DefaultSize = 17
		Me.vsfCFWfList.Rows.MinSize = 17
		Me.vsfCFWfList.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfCFWfList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfCFWfList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfCFWfList.Size = New System.Drawing.Size(156, 444)
		Me.vsfCFWfList.StyleInfo = resources.GetString("vsfCFWfList.StyleInfo")
		Me.vsfCFWfList.TabIndex = 106
		'
		'vsfTFTWfList
		'
		Me.vsfTFTWfList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfTFTWfList.AllowEditing = false
		Me.vsfTFTWfList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfTFTWfList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfTFTWfList.AutoResize = true
		Me.vsfTFTWfList.AutoSearchDelay = 2R
		Me.vsfTFTWfList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfTFTWfList.ColumnInfo = resources.GetString("vsfTFTWfList.ColumnInfo")
		Me.vsfTFTWfList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfTFTWfList.ExtendLastCol = true
		Me.vsfTFTWfList.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfTFTWfList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfTFTWfList.Location = New System.Drawing.Point(631, 52)
		Me.vsfTFTWfList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfTFTWfList.Name = "vsfTFTWfList"
		Me.vsfTFTWfList.Rows.Count = 26
		Me.vsfTFTWfList.Rows.DefaultSize = 17
		Me.vsfTFTWfList.Rows.MinSize = 17
		Me.vsfTFTWfList.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfTFTWfList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfTFTWfList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfTFTWfList.Size = New System.Drawing.Size(156, 444)
		Me.vsfTFTWfList.StyleInfo = resources.GetString("vsfTFTWfList.StyleInfo")
		Me.vsfTFTWfList.TabIndex = 105
		'
		'lblCFLotList
		'
		Me.lblCFLotList.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCFLotList.Location = New System.Drawing.Point(3, 307)
		Me.lblCFLotList.Name = "lblCFLotList"
		Me.lblCFLotList.Size = New System.Drawing.Size(117, 19)
		Me.lblCFLotList.TabIndex = 104
		Me.lblCFLotList.Text = "CFロット一覧"
		'
		'lblTFTLotList
		'
		Me.lblTFTLotList.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblTFTLotList.Location = New System.Drawing.Point(3, 60)
		Me.lblTFTLotList.Name = "lblTFTLotList"
		Me.lblTFTLotList.Size = New System.Drawing.Size(129, 19)
		Me.lblTFTLotList.TabIndex = 103
		Me.lblTFTLotList.Text = "TFTロット一覧"
		'
		'cmbTFTandCF
		'
		Me.cmbTFTandCF.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbTFTandCF.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbTFTandCF.Location = New System.Drawing.Point(6, 29)
		Me.cmbTFTandCF.Name = "cmbTFTandCF"
		Me.cmbTFTandCF.Size = New System.Drawing.Size(172, 28)
		Me.cmbTFTandCF.TabIndex = 102
		Me.cmbTFTandCF.Value = Nothing
		'
		'vsfCFList
		'
		Me.vsfCFList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfCFList.AllowEditing = false
		Me.vsfCFList.AutoSearchDelay = 2R
		Me.vsfCFList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfCFList.ColumnInfo = resources.GetString("vsfCFList.ColumnInfo")
		Me.vsfCFList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfCFList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
		Me.vsfCFList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfCFList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfCFList.Location = New System.Drawing.Point(6, 326)
		Me.vsfCFList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfCFList.Name = "vsfCFList"
		Me.vsfCFList.Rows.Count = 40
		Me.vsfCFList.Rows.DefaultSize = 20
		Me.vsfCFList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfCFList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfCFList.Size = New System.Drawing.Size(530, 218)
		Me.vsfCFList.StyleInfo = resources.GetString("vsfCFList.StyleInfo")
		Me.vsfCFList.TabIndex = 101
		'
		'vsfTFTList
		'
		Me.vsfTFTList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfTFTList.AllowEditing = false
		Me.vsfTFTList.AutoSearchDelay = 2R
		Me.vsfTFTList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfTFTList.ColumnInfo = resources.GetString("vsfTFTList.ColumnInfo")
		Me.vsfTFTList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfTFTList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
		Me.vsfTFTList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfTFTList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfTFTList.Location = New System.Drawing.Point(6, 79)
		Me.vsfTFTList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfTFTList.Name = "vsfTFTList"
		Me.vsfTFTList.Rows.Count = 40
		Me.vsfTFTList.Rows.DefaultSize = 20
		Me.vsfTFTList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfTFTList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfTFTList.Size = New System.Drawing.Size(530, 218)
		Me.vsfTFTList.StyleInfo = resources.GetString("vsfTFTList.StyleInfo")
		Me.vsfTFTList.TabIndex = 100
		'
		'cmdReserveLotList
		'
		Me.cmdReserveLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdReserveLotList.Location = New System.Drawing.Point(196, 13)
		Me.cmdReserveLotList.Name = "cmdReserveLotList"
		Me.cmdReserveLotList.Size = New System.Drawing.Size(85, 40)
		Me.cmdReserveLotList.TabIndex = 99
		Me.cmdReserveLotList.Text = "最新取得"
		'
		'Label2
		'
		Me.Label2.BackColor = System.Drawing.Color.Navy
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label2.ForeColor = System.Drawing.Color.Yellow
		Me.Label2.Location = New System.Drawing.Point(299, 13)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(136, 17)
		Me.Label2.TabIndex = 98
		Me.Label2.Text = "情報取得日時"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNowDate0
		'
		Me.lblNowDate0.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate0.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate0.Location = New System.Drawing.Point(299, 29)
		Me.lblNowDate0.Name = "lblNowDate0"
		Me.lblNowDate0.Size = New System.Drawing.Size(136, 22)
		Me.lblNowDate0.TabIndex = 97
		Me.lblNowDate0.Text = "07/15 13:11:25"
		'
		'cmdDel
		'
		Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdDel.Location = New System.Drawing.Point(771, 504)
		Me.cmdDel.Name = "cmdDel"
		Me.cmdDel.Size = New System.Drawing.Size(85, 40)
		Me.cmdDel.TabIndex = 6
		Me.cmdDel.TabStop = false
		Me.cmdDel.Text = "解　除"
		'
		'cmdRegist
		'
		Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRegist.Location = New System.Drawing.Point(866, 504)
		Me.cmdRegist.Name = "cmdRegist"
		Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
		Me.cmdRegist.TabIndex = 5
		Me.cmdRegist.Text = "登　録"
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Red
		Me.Label1.Location = New System.Drawing.Point(476, 512)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(257, 21)
		Me.Label1.TabIndex = 96
		Me.Label1.Text = "このタブを選んだままチェックインして下さい！！不具合№887"
		Me.Label1.Visible = false
		'
		'lblTitle03
		'
		Me.lblTitle03.BackColor = System.Drawing.Color.Navy
		Me.lblTitle03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle03.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle03.Location = New System.Drawing.Point(631, 13)
		Me.lblTitle03.Name = "lblTitle03"
		Me.lblTitle03.Size = New System.Drawing.Size(156, 17)
		Me.lblTitle03.TabIndex = 66
		Me.lblTitle03.Text = "TFTロットID"
		Me.lblTitle03.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTFTLotId
		'
		Me.lblTFTLotId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTFTLotId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblTFTLotId.Location = New System.Drawing.Point(631, 30)
		Me.lblTFTLotId.Name = "lblTFTLotId"
		Me.lblTFTLotId.Size = New System.Drawing.Size(91, 22)
		Me.lblTFTLotId.TabIndex = 62
		'
		'lblTitle06
		'
		Me.lblTitle06.BackColor = System.Drawing.Color.Navy
		Me.lblTitle06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle06.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle06.Location = New System.Drawing.Point(793, 13)
		Me.lblTitle06.Name = "lblTitle06"
		Me.lblTitle06.Size = New System.Drawing.Size(156, 17)
		Me.lblTitle06.TabIndex = 59
		Me.lblTitle06.Text = "CFロットID"
		Me.lblTitle06.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblCFLotId
		'
		Me.lblCFLotId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblCFLotId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCFLotId.Location = New System.Drawing.Point(793, 30)
		Me.lblCFLotId.Name = "lblCFLotId"
		Me.lblCFLotId.Size = New System.Drawing.Size(91, 22)
		Me.lblCFLotId.TabIndex = 58
		'
		'lblTitle0
		'
		Me.lblTitle0.BackColor = System.Drawing.Color.Navy
		Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle0.Location = New System.Drawing.Point(6, 13)
		Me.lblTitle0.Name = "lblTitle0"
		Me.lblTitle0.Size = New System.Drawing.Size(172, 17)
		Me.lblTitle0.TabIndex = 55
		Me.lblTitle0.Text = "機種(TFT)"
		Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'txtDummy0
		'
		Me.txtDummy0.BackColor = System.Drawing.SystemColors.ControlLight
		Me.txtDummy0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtDummy0.Cursor = System.Windows.Forms.Cursors.Default
		Me.txtDummy0.ForeColor = System.Drawing.SystemColors.ControlLight
		Me.txtDummy0.Location = New System.Drawing.Point(160, 259)
		Me.txtDummy0.Name = "txtDummy0"
		Me.txtDummy0.ReadOnly = true
		Me.txtDummy0.Size = New System.Drawing.Size(15, 16)
		Me.txtDummy0.TabIndex = 4
		'
		'fraTab1
		'
		Me.fraTab1.BackColor = System.Drawing.SystemColors.ControlLight
		Me.fraTab1.Controls.Add(Me.fraODF1)
		Me.fraTab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraTab1.ForeColor = System.Drawing.Color.Black
		Me.fraTab1.Location = New System.Drawing.Point(4, 25)
		Me.fraTab1.Margin = New System.Windows.Forms.Padding(0)
		Me.fraTab1.Name = "fraTab1"
		Me.fraTab1.Size = New System.Drawing.Size(957, 552)
		Me.fraTab1.TabIndex = 1
		Me.fraTab1.Text = "ODF予約一覧"
		'
		'fraODF1
		'
		Me.fraODF1.Controls.Add(Me.vsfReserveInfo)
		Me.fraODF1.Controls.Add(Me.lblWfId)
		Me.fraODF1.Controls.Add(Me.lblLotId)
		Me.fraODF1.Controls.Add(Me.cmdReserveInfo)
		Me.fraODF1.Controls.Add(Me.lblTitle5)
		Me.fraODF1.Controls.Add(Me.lblTitle7)
		Me.fraODF1.Controls.Add(Me.lblNowDate1)
		Me.fraODF1.Controls.Add(Me.lblTitle1)
		Me.fraODF1.Location = New System.Drawing.Point(0, 0)
		Me.fraODF1.Name = "fraODF1"
		Me.fraODF1.Size = New System.Drawing.Size(959, 555)
		Me.fraODF1.TabIndex = 69
		Me.fraODF1.Text = "Frame1"
		'
		'vsfReserveInfo
		'
		Me.vsfReserveInfo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfReserveInfo.AllowEditing = false
		Me.vsfReserveInfo.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfReserveInfo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfReserveInfo.AutoSearchDelay = 2R
		Me.vsfReserveInfo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfReserveInfo.ColumnInfo = resources.GetString("vsfReserveInfo.ColumnInfo")
		Me.vsfReserveInfo.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfReserveInfo.ExtendLastCol = true
		Me.vsfReserveInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfReserveInfo.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
		Me.vsfReserveInfo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfReserveInfo.Location = New System.Drawing.Point(6, 63)
		Me.vsfReserveInfo.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfReserveInfo.Name = "vsfReserveInfo"
		Me.vsfReserveInfo.Rows.Count = 40
		Me.vsfReserveInfo.Rows.DefaultSize = 18
		Me.vsfReserveInfo.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfReserveInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
		Me.vsfReserveInfo.Size = New System.Drawing.Size(945, 482)
		Me.vsfReserveInfo.StyleInfo = resources.GetString("vsfReserveInfo.StyleInfo")
		Me.vsfReserveInfo.TabIndex = 100
		Me.vsfReserveInfo.TabStop = false
		'
		'lblWfId
		'
		Me.lblWfId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblWfId.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.lblWfId.ChrMaxByte = 10
		Me.lblWfId.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblWfId.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
		Me.lblWfId.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.lblWfId.Location = New System.Drawing.Point(188, 28)
		Me.lblWfId.Name = "lblWfId"
		Me.lblWfId.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.lblWfId.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.lblWfId.SelectedText = ""
		Me.lblWfId.Size = New System.Drawing.Size(168, 22)
		Me.lblWfId.TabIndex = 99
		'
		'lblLotId
		'
		Me.lblLotId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblLotId.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.lblLotId.ChrMaxByte = 10
		Me.lblLotId.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLotId.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
		Me.lblLotId.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.lblLotId.Location = New System.Drawing.Point(6, 28)
		Me.lblLotId.Name = "lblLotId"
		Me.lblLotId.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.lblLotId.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.lblLotId.SelectedText = ""
		Me.lblLotId.Size = New System.Drawing.Size(176, 22)
		Me.lblLotId.TabIndex = 98
		'
		'cmdReserveInfo
		'
		Me.cmdReserveInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdReserveInfo.Location = New System.Drawing.Point(371, 10)
		Me.cmdReserveInfo.Name = "cmdReserveInfo"
		Me.cmdReserveInfo.Size = New System.Drawing.Size(85, 40)
		Me.cmdReserveInfo.TabIndex = 19
		Me.cmdReserveInfo.Text = "最新取得"
		'
		'lblTitle5
		'
		Me.lblTitle5.BackColor = System.Drawing.Color.Navy
		Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle5.Location = New System.Drawing.Point(188, 11)
		Me.lblTitle5.Name = "lblTitle5"
		Me.lblTitle5.Size = New System.Drawing.Size(168, 18)
		Me.lblTitle5.TabIndex = 97
		Me.lblTitle5.Text = "WFID(部分検索可)"
		Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle7
		'
		Me.lblTitle7.BackColor = System.Drawing.Color.Navy
		Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle7.Location = New System.Drawing.Point(475, 12)
		Me.lblTitle7.Name = "lblTitle7"
		Me.lblTitle7.Size = New System.Drawing.Size(136, 17)
		Me.lblTitle7.TabIndex = 90
		Me.lblTitle7.Text = "情報取得日時"
		Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNowDate1
		'
		Me.lblNowDate1.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate1.Location = New System.Drawing.Point(475, 28)
		Me.lblNowDate1.Name = "lblNowDate1"
		Me.lblNowDate1.Size = New System.Drawing.Size(136, 22)
		Me.lblNowDate1.TabIndex = 89
		Me.lblNowDate1.Text = "07/15 13:11:25"
		'
		'lblTitle1
		'
		Me.lblTitle1.BackColor = System.Drawing.Color.Navy
		Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle1.Location = New System.Drawing.Point(6, 11)
		Me.lblTitle1.Name = "lblTitle1"
		Me.lblTitle1.Size = New System.Drawing.Size(176, 17)
		Me.lblTitle1.TabIndex = 71
		Me.lblTitle1.Text = "ロットID(部分検索可)"
		Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'fraTab2
		'
		Me.fraTab2.BackColor = System.Drawing.SystemColors.ControlLight
		Me.fraTab2.Controls.Add(Me.fraODF2)
		Me.fraTab2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraTab2.ForeColor = System.Drawing.Color.Black
		Me.fraTab2.Location = New System.Drawing.Point(4, 25)
		Me.fraTab2.Margin = New System.Windows.Forms.Padding(0)
		Me.fraTab2.Name = "fraTab2"
		Me.fraTab2.Size = New System.Drawing.Size(957, 552)
		Me.fraTab2.TabIndex = 2
		Me.fraTab2.Text = "表面処理予約"
		'
		'fraODF2
		'
		Me.fraODF2.Controls.Add(Me.lblCaution)
		Me.fraODF2.Controls.Add(Me.lblSelectWfCntTitle)
		Me.fraODF2.Controls.Add(Me.lblSelectWfCnt)
		Me.fraODF2.Controls.Add(Me.vsfHyoumenReserveInfo)
		Me.fraODF2.Controls.Add(Me.cmdHyoumenDel)
		Me.fraODF2.Controls.Add(Me.cmdHyoumenRegist)
		Me.fraODF2.Controls.Add(Me.Panel1)
		Me.fraODF2.Controls.Add(Me.lblTitle8)
		Me.fraODF2.Controls.Add(Me.lblBackReason)
		Me.fraODF2.Controls.Add(Me.Label7)
		Me.fraODF2.Controls.Add(Me.lblNowDate2)
		Me.fraODF2.Controls.Add(Me.cmdHyoumenReserveInfo)
		Me.fraODF2.Location = New System.Drawing.Point(0, 0)
		Me.fraODF2.Name = "fraODF2"
		Me.fraODF2.Size = New System.Drawing.Size(959, 555)
		Me.fraODF2.TabIndex = 74
		Me.fraODF2.Text = "Frame1"
		'
		'lblCaution
		'
		Me.lblCaution.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblCaution.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblCaution.Location = New System.Drawing.Point(642, 9)
		Me.lblCaution.Name = "lblCaution"
		Me.lblCaution.Size = New System.Drawing.Size(309, 37)
		Me.lblCaution.TabIndex = 118
		Me.lblCaution.Text = "注意事項"
		'
		'lblSelectWfCntTitle
		'
		Me.lblSelectWfCntTitle.BackColor = System.Drawing.Color.Navy
		Me.lblSelectWfCntTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblSelectWfCntTitle.ForeColor = System.Drawing.Color.Yellow
		Me.lblSelectWfCntTitle.Location = New System.Drawing.Point(541, 503)
		Me.lblSelectWfCntTitle.Name = "lblSelectWfCntTitle"
		Me.lblSelectWfCntTitle.Size = New System.Drawing.Size(180, 22)
		Me.lblSelectWfCntTitle.TabIndex = 117
		Me.lblSelectWfCntTitle.Text = "選択WF枚数"
		Me.lblSelectWfCntTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblSelectWfCnt
		'
		Me.lblSelectWfCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblSelectWfCnt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblSelectWfCnt.Location = New System.Drawing.Point(541, 525)
		Me.lblSelectWfCnt.Name = "lblSelectWfCnt"
		Me.lblSelectWfCnt.Size = New System.Drawing.Size(180, 22)
		Me.lblSelectWfCnt.TabIndex = 116
		Me.lblSelectWfCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'vsfHyoumenReserveInfo
		'
		Me.vsfHyoumenReserveInfo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfHyoumenReserveInfo.AllowEditing = false
		Me.vsfHyoumenReserveInfo.AutoSearchDelay = 2R
		Me.vsfHyoumenReserveInfo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfHyoumenReserveInfo.ColumnInfo = resources.GetString("vsfHyoumenReserveInfo.ColumnInfo")
		Me.vsfHyoumenReserveInfo.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfHyoumenReserveInfo.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
		Me.vsfHyoumenReserveInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfHyoumenReserveInfo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfHyoumenReserveInfo.Location = New System.Drawing.Point(6, 58)
		Me.vsfHyoumenReserveInfo.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfHyoumenReserveInfo.Name = "vsfHyoumenReserveInfo"
		Me.vsfHyoumenReserveInfo.Rows.Count = 40
		Me.vsfHyoumenReserveInfo.Rows.DefaultSize = 18
		Me.vsfHyoumenReserveInfo.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfHyoumenReserveInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfHyoumenReserveInfo.Size = New System.Drawing.Size(945, 440)
		Me.vsfHyoumenReserveInfo.StyleInfo = resources.GetString("vsfHyoumenReserveInfo.StyleInfo")
		Me.vsfHyoumenReserveInfo.TabIndex = 114
		'
		'cmdHyoumenDel
		'
		Me.cmdHyoumenDel.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdHyoumenDel.Location = New System.Drawing.Point(771, 504)
		Me.cmdHyoumenDel.Name = "cmdHyoumenDel"
		Me.cmdHyoumenDel.Size = New System.Drawing.Size(85, 40)
		Me.cmdHyoumenDel.TabIndex = 112
		Me.cmdHyoumenDel.TabStop = false
		Me.cmdHyoumenDel.Text = "解　除"
		'
		'cmdHyoumenRegist
		'
		Me.cmdHyoumenRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdHyoumenRegist.Location = New System.Drawing.Point(866, 504)
		Me.cmdHyoumenRegist.Name = "cmdHyoumenRegist"
		Me.cmdHyoumenRegist.Size = New System.Drawing.Size(85, 40)
		Me.cmdHyoumenRegist.TabIndex = 111
		Me.cmdHyoumenRegist.Text = "登　録"
		'
		'Panel1
		'
		Me.Panel1.AutoSize = true
		Me.Panel1.Controls.Add(Me.optAll)
		Me.Panel1.Controls.Add(Me.optDone)
		Me.Panel1.Controls.Add(Me.optNone)
		Me.Panel1.Location = New System.Drawing.Point(59, 10)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(311, 34)
		Me.Panel1.TabIndex = 108
		'
		'optAll
		'
		Me.optAll.AutoSize = true
		Me.optAll.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optAll.Location = New System.Drawing.Point(170, 8)
		Me.optAll.Name = "optAll"
		Me.optAll.Size = New System.Drawing.Size(137, 20)
		Me.optAll.TabIndex = 107
		Me.optAll.Text = "全て(参照のみ)"
		'
		'optDone
		'
		Me.optDone.AutoSize = true
		Me.optDone.BackColor = System.Drawing.SystemColors.ControlLight
		Me.optDone.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optDone.Location = New System.Drawing.Point(86, 9)
		Me.optDone.Name = "optDone"
		Me.optDone.Size = New System.Drawing.Size(73, 20)
		Me.optDone.TabIndex = 106
		Me.optDone.Text = "予約済"
		Me.optDone.UseVisualStyleBackColor = false
		'
		'optNone
		'
		Me.optNone.AutoSize = true
		Me.optNone.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optNone.Location = New System.Drawing.Point(4, 9)
		Me.optNone.Name = "optNone"
		Me.optNone.Size = New System.Drawing.Size(73, 20)
		Me.optNone.TabIndex = 105
		Me.optNone.Text = "予約未"
		'
		'lblTitle8
		'
		Me.lblTitle8.BackColor = System.Drawing.Color.Navy
		Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle8.Location = New System.Drawing.Point(10, 8)
		Me.lblTitle8.Name = "lblTitle8"
		Me.lblTitle8.Size = New System.Drawing.Size(43, 38)
		Me.lblTitle8.TabIndex = 107
		Me.lblTitle8.Text = "表示"
		Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblBackReason
		'
		Me.lblBackReason.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblBackReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblBackReason.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblBackReason.Location = New System.Drawing.Point(50, 8)
		Me.lblBackReason.Name = "lblBackReason"
		Me.lblBackReason.Size = New System.Drawing.Size(322, 38)
		Me.lblBackReason.TabIndex = 102
		'
		'Label7
		'
		Me.Label7.BackColor = System.Drawing.Color.Navy
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label7.ForeColor = System.Drawing.Color.Yellow
		Me.Label7.Location = New System.Drawing.Point(489, 8)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(136, 17)
		Me.Label7.TabIndex = 92
		Me.Label7.Text = "情報取得日時"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNowDate2
		'
		Me.lblNowDate2.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate2.Location = New System.Drawing.Point(489, 25)
		Me.lblNowDate2.Name = "lblNowDate2"
		Me.lblNowDate2.Size = New System.Drawing.Size(136, 22)
		Me.lblNowDate2.TabIndex = 91
		Me.lblNowDate2.Text = "07/15 13:11:25"
		'
		'cmdHyoumenReserveInfo
		'
		Me.cmdHyoumenReserveInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdHyoumenReserveInfo.Location = New System.Drawing.Point(387, 7)
		Me.cmdHyoumenReserveInfo.Name = "cmdHyoumenReserveInfo"
		Me.cmdHyoumenReserveInfo.Size = New System.Drawing.Size(85, 40)
		Me.cmdHyoumenReserveInfo.TabIndex = 20
		Me.cmdHyoumenReserveInfo.Text = "最新取得"
		'
		'fraTab3
		'
		Me.fraTab3.Controls.Add(Me.fraODF3)
		Me.fraTab3.Location = New System.Drawing.Point(4, 25)
		Me.fraTab3.Name = "fraTab3"
		Me.fraTab3.Padding = New System.Windows.Forms.Padding(3)
		Me.fraTab3.Size = New System.Drawing.Size(957, 552)
		Me.fraTab3.TabIndex = 3
		Me.fraTab3.Text = "蒸着後流動予約"
		Me.fraTab3.UseVisualStyleBackColor = true
		'
		'fraODF3
		'
		Me.fraODF3.BackColor = System.Drawing.SystemColors.ControlLight
		Me.fraODF3.Controls.Add(Me.cmdAfterJReserveList)
		Me.fraODF3.Controls.Add(Me.cmd5wf)
		Me.fraODF3.Controls.Add(Me.cmd10wf)
		Me.fraODF3.Controls.Add(Me.lblReserveStatus2)
		Me.fraODF3.Controls.Add(Me.Label4)
		Me.fraODF3.Controls.Add(Me.cmdReserveJRegist)
		Me.fraODF3.Controls.Add(Me.cmdReserveJDel)
		Me.fraODF3.Controls.Add(Me.fraGroupD)
		Me.fraODF3.Controls.Add(Me.fraGroupC)
		Me.fraODF3.Controls.Add(Me.fraGroupB)
		Me.fraODF3.Controls.Add(Me.fraGroupA)
		Me.fraODF3.Controls.Add(Me.fraSlotMap)
		Me.fraODF3.Controls.Add(Me.lblLotID1)
		Me.fraODF3.Controls.Add(Me.lbTitleLotID)
		Me.fraODF3.Controls.Add(Me.txtCarrier)
		Me.fraODF3.Controls.Add(Me.lblTitle)
		Me.fraODF3.Location = New System.Drawing.Point(-1, -1)
		Me.fraODF3.Name = "fraODF3"
		Me.fraODF3.Size = New System.Drawing.Size(959, 555)
		Me.fraODF3.TabIndex = 75
		Me.fraODF3.Text = "Frame1"
		'
		'cmdAfterJReserveList
		'
		Me.cmdAfterJReserveList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdAfterJReserveList.Location = New System.Drawing.Point(627, 513)
		Me.cmdAfterJReserveList.Name = "cmdAfterJReserveList"
		Me.cmdAfterJReserveList.Size = New System.Drawing.Size(85, 39)
		Me.cmdAfterJReserveList.TabIndex = 61
		Me.cmdAfterJReserveList.TabStop = false
		Me.cmdAfterJReserveList.Text = "予約一覧"
		'
		'cmd5wf
		'
		Me.cmd5wf.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmd5wf.Location = New System.Drawing.Point(237, 193)
		Me.cmd5wf.Name = "cmd5wf"
		Me.cmd5wf.Size = New System.Drawing.Size(64, 39)
		Me.cmd5wf.TabIndex = 136
		Me.cmd5wf.TabStop = false
		Me.cmd5wf.Text = "一括"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"5WF"
		'
		'cmd10wf
		'
		Me.cmd10wf.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmd10wf.Location = New System.Drawing.Point(237, 251)
		Me.cmd10wf.Name = "cmd10wf"
		Me.cmd10wf.Size = New System.Drawing.Size(64, 39)
		Me.cmd10wf.TabIndex = 136
		Me.cmd10wf.TabStop = false
		Me.cmd10wf.Text = "一括"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"10WF"
		'
		'lblReserveStatus2
		'
		Me.lblReserveStatus2.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblReserveStatus2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblReserveStatus2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblReserveStatus2.Location = New System.Drawing.Point(245, 24)
		Me.lblReserveStatus2.Name = "lblReserveStatus2"
		Me.lblReserveStatus2.Size = New System.Drawing.Size(56, 22)
		Me.lblReserveStatus2.TabIndex = 117
		Me.lblReserveStatus2.Text = "未/済"
		Me.lblReserveStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label4
		'
		Me.Label4.BackColor = System.Drawing.Color.Navy
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label4.ForeColor = System.Drawing.Color.Yellow
		Me.Label4.Location = New System.Drawing.Point(245, 7)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(56, 17)
		Me.Label4.TabIndex = 116
		Me.Label4.Text = "予約"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmdReserveJRegist
		'
		Me.cmdReserveJRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdReserveJRegist.Location = New System.Drawing.Point(862, 513)
		Me.cmdReserveJRegist.Name = "cmdReserveJRegist"
		Me.cmdReserveJRegist.Size = New System.Drawing.Size(90, 39)
		Me.cmdReserveJRegist.TabIndex = 63
		Me.cmdReserveJRegist.Text = "登　録"
		'
		'cmdReserveJDel
		'
		Me.cmdReserveJDel.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdReserveJDel.Location = New System.Drawing.Point(771, 513)
		Me.cmdReserveJDel.Name = "cmdReserveJDel"
		Me.cmdReserveJDel.Size = New System.Drawing.Size(85, 39)
		Me.cmdReserveJDel.TabIndex = 62
		Me.cmdReserveJDel.TabStop = false
		Me.cmdReserveJDel.Text = "解　除"
		'
		'fraGroupD
		'
		Me.fraGroupD.Controls.Add(Me.txtToCarrier4)
		Me.fraGroupD.Controls.Add(Me.cmdCarrierSelect4)
		Me.fraGroupD.Controls.Add(Me.lblToCarrierID4)
		Me.fraGroupD.Controls.Add(Me.vsfToSlotMap4)
		Me.fraGroupD.Location = New System.Drawing.Point(787, 7)
		Me.fraGroupD.Name = "fraGroupD"
		Me.fraGroupD.Size = New System.Drawing.Size(154, 511)
		Me.fraGroupD.TabIndex = 135
		Me.fraGroupD.TabStop = false
		Me.fraGroupD.Text = "グループD"
		'
		'txtToCarrier4
		'
		Me.txtToCarrier4.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtToCarrier4.ChrMaxByte = 6
		Me.txtToCarrier4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtToCarrier4.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtToCarrier4.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtToCarrier4.Location = New System.Drawing.Point(3, 32)
		Me.txtToCarrier4.Name = "txtToCarrier4"
		Me.txtToCarrier4.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtToCarrier4.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtToCarrier4.SelectedText = ""
		Me.txtToCarrier4.Size = New System.Drawing.Size(83, 24)
		Me.txtToCarrier4.TabIndex = 59
		'
		'cmdCarrierSelect4
		'
		Me.cmdCarrierSelect4.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCarrierSelect4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdCarrierSelect4.Location = New System.Drawing.Point(86, 19)
		Me.cmdCarrierSelect4.Name = "cmdCarrierSelect4"
		Me.cmdCarrierSelect4.Size = New System.Drawing.Size(68, 37)
		Me.cmdCarrierSelect4.TabIndex = 60
		Me.cmdCarrierSelect4.TabStop = false
		Me.cmdCarrierSelect4.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
		'
		'lblToCarrierID4
		'
		Me.lblToCarrierID4.BackColor = System.Drawing.Color.Navy
		Me.lblToCarrierID4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblToCarrierID4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblToCarrierID4.ForeColor = System.Drawing.Color.Yellow
		Me.lblToCarrierID4.Location = New System.Drawing.Point(3, 19)
		Me.lblToCarrierID4.Name = "lblToCarrierID4"
		Me.lblToCarrierID4.Size = New System.Drawing.Size(83, 18)
		Me.lblToCarrierID4.TabIndex = 119
		Me.lblToCarrierID4.Text = "キャリアID"
		Me.lblToCarrierID4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'vsfToSlotMap4
		'
		Me.vsfToSlotMap4.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfToSlotMap4.AllowEditing = false
		Me.vsfToSlotMap4.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfToSlotMap4.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfToSlotMap4.AutoResize = true
		Me.vsfToSlotMap4.AutoSearchDelay = 2R
		Me.vsfToSlotMap4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfToSlotMap4.ColumnInfo = resources.GetString("vsfToSlotMap4.ColumnInfo")
		Me.vsfToSlotMap4.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfToSlotMap4.ExtendLastCol = true
		Me.vsfToSlotMap4.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfToSlotMap4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfToSlotMap4.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
		Me.vsfToSlotMap4.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfToSlotMap4.Location = New System.Drawing.Point(3, 59)
		Me.vsfToSlotMap4.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfToSlotMap4.Name = "vsfToSlotMap4"
		Me.vsfToSlotMap4.Rows.Count = 26
		Me.vsfToSlotMap4.Rows.DefaultSize = 17
		Me.vsfToSlotMap4.Rows.MinSize = 17
		Me.vsfToSlotMap4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfToSlotMap4.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfToSlotMap4.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfToSlotMap4.Size = New System.Drawing.Size(144, 444)
		Me.vsfToSlotMap4.StyleInfo = resources.GetString("vsfToSlotMap4.StyleInfo")
		Me.vsfToSlotMap4.TabIndex = 67
		'
		'fraGroupC
		'
		Me.fraGroupC.Controls.Add(Me.txtToCarrier3)
		Me.fraGroupC.Controls.Add(Me.cmdCarrierSelect3)
		Me.fraGroupC.Controls.Add(Me.lblToCarrierID3)
		Me.fraGroupC.Controls.Add(Me.vsfToSlotMap3)
		Me.fraGroupC.Location = New System.Drawing.Point(627, 7)
		Me.fraGroupC.Name = "fraGroupC"
		Me.fraGroupC.Size = New System.Drawing.Size(154, 511)
		Me.fraGroupC.TabIndex = 134
		Me.fraGroupC.TabStop = false
		Me.fraGroupC.Text = "グループC"
		'
		'txtToCarrier3
		'
		Me.txtToCarrier3.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtToCarrier3.ChrMaxByte = 6
		Me.txtToCarrier3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtToCarrier3.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtToCarrier3.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtToCarrier3.Location = New System.Drawing.Point(6, 32)
		Me.txtToCarrier3.Name = "txtToCarrier3"
		Me.txtToCarrier3.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtToCarrier3.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtToCarrier3.SelectedText = ""
		Me.txtToCarrier3.Size = New System.Drawing.Size(83, 24)
		Me.txtToCarrier3.TabIndex = 57
		'
		'cmdCarrierSelect3
		'
		Me.cmdCarrierSelect3.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCarrierSelect3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdCarrierSelect3.Location = New System.Drawing.Point(89, 19)
		Me.cmdCarrierSelect3.Name = "cmdCarrierSelect3"
		Me.cmdCarrierSelect3.Size = New System.Drawing.Size(68, 37)
		Me.cmdCarrierSelect3.TabIndex = 58
		Me.cmdCarrierSelect3.TabStop = false
		Me.cmdCarrierSelect3.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
		'
		'lblToCarrierID3
		'
		Me.lblToCarrierID3.BackColor = System.Drawing.Color.Navy
		Me.lblToCarrierID3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblToCarrierID3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblToCarrierID3.ForeColor = System.Drawing.Color.Yellow
		Me.lblToCarrierID3.Location = New System.Drawing.Point(6, 19)
		Me.lblToCarrierID3.Name = "lblToCarrierID3"
		Me.lblToCarrierID3.Size = New System.Drawing.Size(83, 18)
		Me.lblToCarrierID3.TabIndex = 119
		Me.lblToCarrierID3.Text = "キャリアID"
		Me.lblToCarrierID3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'vsfToSlotMap3
		'
		Me.vsfToSlotMap3.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfToSlotMap3.AllowEditing = false
		Me.vsfToSlotMap3.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfToSlotMap3.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfToSlotMap3.AutoResize = true
		Me.vsfToSlotMap3.AutoSearchDelay = 2R
		Me.vsfToSlotMap3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfToSlotMap3.ColumnInfo = resources.GetString("vsfToSlotMap3.ColumnInfo")
		Me.vsfToSlotMap3.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfToSlotMap3.ExtendLastCol = true
		Me.vsfToSlotMap3.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfToSlotMap3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfToSlotMap3.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
		Me.vsfToSlotMap3.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfToSlotMap3.Location = New System.Drawing.Point(6, 59)
		Me.vsfToSlotMap3.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfToSlotMap3.Name = "vsfToSlotMap3"
		Me.vsfToSlotMap3.Rows.Count = 26
		Me.vsfToSlotMap3.Rows.DefaultSize = 17
		Me.vsfToSlotMap3.Rows.MinSize = 17
		Me.vsfToSlotMap3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfToSlotMap3.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfToSlotMap3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfToSlotMap3.Size = New System.Drawing.Size(144, 444)
		Me.vsfToSlotMap3.StyleInfo = resources.GetString("vsfToSlotMap3.StyleInfo")
		Me.vsfToSlotMap3.TabIndex = 66
		'
		'fraGroupB
		'
		Me.fraGroupB.Controls.Add(Me.txtToCarrier2)
		Me.fraGroupB.Controls.Add(Me.cmdCarrierSelect2)
		Me.fraGroupB.Controls.Add(Me.lblToCarrierID2)
		Me.fraGroupB.Controls.Add(Me.vsfToSlotMap2)
		Me.fraGroupB.Location = New System.Drawing.Point(467, 7)
		Me.fraGroupB.Name = "fraGroupB"
		Me.fraGroupB.Size = New System.Drawing.Size(154, 511)
		Me.fraGroupB.TabIndex = 133
		Me.fraGroupB.TabStop = false
		Me.fraGroupB.Text = "グループB"
		'
		'txtToCarrier2
		'
		Me.txtToCarrier2.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtToCarrier2.ChrMaxByte = 6
		Me.txtToCarrier2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtToCarrier2.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtToCarrier2.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtToCarrier2.Location = New System.Drawing.Point(3, 32)
		Me.txtToCarrier2.Name = "txtToCarrier2"
		Me.txtToCarrier2.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtToCarrier2.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtToCarrier2.SelectedText = ""
		Me.txtToCarrier2.Size = New System.Drawing.Size(83, 24)
		Me.txtToCarrier2.TabIndex = 55
		'
		'cmdCarrierSelect2
		'
		Me.cmdCarrierSelect2.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCarrierSelect2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdCarrierSelect2.Location = New System.Drawing.Point(86, 19)
		Me.cmdCarrierSelect2.Name = "cmdCarrierSelect2"
		Me.cmdCarrierSelect2.Size = New System.Drawing.Size(68, 37)
		Me.cmdCarrierSelect2.TabIndex = 56
		Me.cmdCarrierSelect2.TabStop = false
		Me.cmdCarrierSelect2.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
		'
		'lblToCarrierID2
		'
		Me.lblToCarrierID2.BackColor = System.Drawing.Color.Navy
		Me.lblToCarrierID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblToCarrierID2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblToCarrierID2.ForeColor = System.Drawing.Color.Yellow
		Me.lblToCarrierID2.Location = New System.Drawing.Point(3, 19)
		Me.lblToCarrierID2.Name = "lblToCarrierID2"
		Me.lblToCarrierID2.Size = New System.Drawing.Size(83, 18)
		Me.lblToCarrierID2.TabIndex = 119
		Me.lblToCarrierID2.Text = "キャリアID"
		Me.lblToCarrierID2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'vsfToSlotMap2
		'
		Me.vsfToSlotMap2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfToSlotMap2.AllowEditing = false
		Me.vsfToSlotMap2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfToSlotMap2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfToSlotMap2.AutoResize = true
		Me.vsfToSlotMap2.AutoSearchDelay = 2R
		Me.vsfToSlotMap2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfToSlotMap2.ColumnInfo = resources.GetString("vsfToSlotMap2.ColumnInfo")
		Me.vsfToSlotMap2.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfToSlotMap2.ExtendLastCol = true
		Me.vsfToSlotMap2.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfToSlotMap2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfToSlotMap2.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
		Me.vsfToSlotMap2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfToSlotMap2.Location = New System.Drawing.Point(3, 59)
		Me.vsfToSlotMap2.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfToSlotMap2.Name = "vsfToSlotMap2"
		Me.vsfToSlotMap2.Rows.Count = 26
		Me.vsfToSlotMap2.Rows.DefaultSize = 17
		Me.vsfToSlotMap2.Rows.MinSize = 17
		Me.vsfToSlotMap2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfToSlotMap2.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfToSlotMap2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfToSlotMap2.Size = New System.Drawing.Size(144, 444)
		Me.vsfToSlotMap2.StyleInfo = resources.GetString("vsfToSlotMap2.StyleInfo")
		Me.vsfToSlotMap2.TabIndex = 65
		'
		'fraGroupA
		'
		Me.fraGroupA.Controls.Add(Me.txtToCarrier1)
		Me.fraGroupA.Controls.Add(Me.cmdCarrierSelect1)
		Me.fraGroupA.Controls.Add(Me.lblToCarrierID1)
		Me.fraGroupA.Controls.Add(Me.vsfToSlotMap1)
		Me.fraGroupA.Location = New System.Drawing.Point(307, 7)
		Me.fraGroupA.Name = "fraGroupA"
		Me.fraGroupA.Size = New System.Drawing.Size(154, 511)
		Me.fraGroupA.TabIndex = 132
		Me.fraGroupA.TabStop = false
		Me.fraGroupA.Text = "グループA"
		'
		'txtToCarrier1
		'
		Me.txtToCarrier1.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtToCarrier1.ChrMaxByte = 6
		Me.txtToCarrier1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtToCarrier1.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtToCarrier1.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtToCarrier1.Location = New System.Drawing.Point(6, 32)
		Me.txtToCarrier1.Name = "txtToCarrier1"
		Me.txtToCarrier1.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtToCarrier1.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtToCarrier1.SelectedText = ""
		Me.txtToCarrier1.Size = New System.Drawing.Size(83, 24)
		Me.txtToCarrier1.TabIndex = 53
		'
		'cmdCarrierSelect1
		'
		Me.cmdCarrierSelect1.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCarrierSelect1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdCarrierSelect1.Location = New System.Drawing.Point(89, 19)
		Me.cmdCarrierSelect1.Name = "cmdCarrierSelect1"
		Me.cmdCarrierSelect1.Size = New System.Drawing.Size(65, 37)
		Me.cmdCarrierSelect1.TabIndex = 54
		Me.cmdCarrierSelect1.TabStop = false
		Me.cmdCarrierSelect1.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
		'
		'lblToCarrierID1
		'
		Me.lblToCarrierID1.BackColor = System.Drawing.Color.Navy
		Me.lblToCarrierID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblToCarrierID1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblToCarrierID1.ForeColor = System.Drawing.Color.Yellow
		Me.lblToCarrierID1.Location = New System.Drawing.Point(6, 19)
		Me.lblToCarrierID1.Name = "lblToCarrierID1"
		Me.lblToCarrierID1.Size = New System.Drawing.Size(83, 18)
		Me.lblToCarrierID1.TabIndex = 119
		Me.lblToCarrierID1.Text = "キャリアID"
		Me.lblToCarrierID1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'vsfToSlotMap1
		'
		Me.vsfToSlotMap1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfToSlotMap1.AllowEditing = false
		Me.vsfToSlotMap1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfToSlotMap1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfToSlotMap1.AutoResize = true
		Me.vsfToSlotMap1.AutoSearchDelay = 2R
		Me.vsfToSlotMap1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfToSlotMap1.ColumnInfo = resources.GetString("vsfToSlotMap1.ColumnInfo")
		Me.vsfToSlotMap1.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfToSlotMap1.ExtendLastCol = true
		Me.vsfToSlotMap1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfToSlotMap1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfToSlotMap1.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
		Me.vsfToSlotMap1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfToSlotMap1.Location = New System.Drawing.Point(6, 59)
		Me.vsfToSlotMap1.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfToSlotMap1.Name = "vsfToSlotMap1"
		Me.vsfToSlotMap1.Rows.Count = 26
		Me.vsfToSlotMap1.Rows.DefaultSize = 17
		Me.vsfToSlotMap1.Rows.MinSize = 17
		Me.vsfToSlotMap1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfToSlotMap1.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfToSlotMap1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfToSlotMap1.Size = New System.Drawing.Size(144, 444)
		Me.vsfToSlotMap1.StyleInfo = resources.GetString("vsfToSlotMap1.StyleInfo")
		Me.vsfToSlotMap1.TabIndex = 64
		'
		'fraSlotMap
		'
		Me.fraSlotMap.Controls.Add(Me.vsfSlotMap)
		Me.fraSlotMap.Location = New System.Drawing.Point(24, 49)
		Me.fraSlotMap.Name = "fraSlotMap"
		Me.fraSlotMap.Size = New System.Drawing.Size(203, 469)
		Me.fraSlotMap.TabIndex = 116
		Me.fraSlotMap.TabStop = false
		Me.fraSlotMap.Text = "予約元"
		'
		'vsfSlotMap
		'
		Me.vsfSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfSlotMap.AllowEditing = false
		Me.vsfSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfSlotMap.AutoResize = true
		Me.vsfSlotMap.AutoSearchDelay = 2R
		Me.vsfSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfSlotMap.ColumnInfo = resources.GetString("vsfSlotMap.ColumnInfo")
		Me.vsfSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfSlotMap.ExtendLastCol = true
		Me.vsfSlotMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfSlotMap.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
		Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfSlotMap.Location = New System.Drawing.Point(28, 19)
		Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfSlotMap.Name = "vsfSlotMap"
		Me.vsfSlotMap.Rows.Count = 26
		Me.vsfSlotMap.Rows.DefaultSize = 17
		Me.vsfSlotMap.Rows.MinSize = 17
		Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfSlotMap.Size = New System.Drawing.Size(151, 444)
		Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
		Me.vsfSlotMap.TabIndex = 52
		'
		'lblLotID1
		'
		Me.lblLotID1.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblLotID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblLotID1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLotID1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblLotID1.Location = New System.Drawing.Point(122, 24)
		Me.lblLotID1.Name = "lblLotID1"
		Me.lblLotID1.Size = New System.Drawing.Size(117, 22)
		Me.lblLotID1.TabIndex = 131
		Me.lblLotID1.Text = "GTA1234-00"
		'
		'lbTitleLotID
		'
		Me.lbTitleLotID.BackColor = System.Drawing.Color.Navy
		Me.lbTitleLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lbTitleLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lbTitleLotID.ForeColor = System.Drawing.Color.Yellow
		Me.lbTitleLotID.Location = New System.Drawing.Point(122, 7)
		Me.lbTitleLotID.Name = "lbTitleLotID"
		Me.lbTitleLotID.Size = New System.Drawing.Size(117, 18)
		Me.lbTitleLotID.TabIndex = 130
		Me.lbTitleLotID.Text = "ロットID"
		Me.lbTitleLotID.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'txtCarrier
		'
		Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtCarrier.ChrMaxByte = 6
		Me.txtCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
		Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtCarrier.Location = New System.Drawing.Point(24, 25)
		Me.txtCarrier.Name = "txtCarrier"
		Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtCarrier.SelectedText = ""
		Me.txtCarrier.Size = New System.Drawing.Size(92, 21)
		Me.txtCarrier.TabIndex = 51
		'
		'lblTitle
		'
		Me.lblTitle.BackColor = System.Drawing.Color.Navy
		Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle.Location = New System.Drawing.Point(24, 7)
		Me.lblTitle.Name = "lblTitle"
		Me.lblTitle.Size = New System.Drawing.Size(92, 18)
		Me.lblTitle.TabIndex = 121
		Me.lblTitle.Text = "キャリアID"
		Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(8, 597)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(85, 40)
		Me.cmdClose.TabIndex = 52
		Me.cmdClose.Text = "閉じる"
		'
		'frmxxEN02U0
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(985, 642)
		Me.Controls.Add(Me.tabODF)
		Me.Controls.Add(Me.cmdClose)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.ForeColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN02U0"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "バッチ予約(ODF/表面処理)"
		Me.tabODF.ResumeLayout(false)
		Me.fraTab0.ResumeLayout(false)
		Me.fraODF0.ResumeLayout(false)
		Me.fraODF0.PerformLayout
		CType(Me.vsfCFWfList,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.vsfTFTWfList,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.vsfCFList,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.vsfTFTList,System.ComponentModel.ISupportInitialize).EndInit
		Me.fraTab1.ResumeLayout(false)
		Me.fraODF1.ResumeLayout(false)
		CType(Me.vsfReserveInfo,System.ComponentModel.ISupportInitialize).EndInit
		Me.fraTab2.ResumeLayout(false)
		Me.fraODF2.ResumeLayout(false)
		Me.fraODF2.PerformLayout
		CType(Me.vsfHyoumenReserveInfo,System.ComponentModel.ISupportInitialize).EndInit
		Me.Panel1.ResumeLayout(false)
		Me.Panel1.PerformLayout
		Me.fraTab3.ResumeLayout(false)
		Me.fraODF3.ResumeLayout(false)
		Me.fraGroupD.ResumeLayout(false)
		CType(Me.vsfToSlotMap4,System.ComponentModel.ISupportInitialize).EndInit
		Me.fraGroupC.ResumeLayout(false)
		CType(Me.vsfToSlotMap3,System.ComponentModel.ISupportInitialize).EndInit
		Me.fraGroupB.ResumeLayout(false)
		CType(Me.vsfToSlotMap2,System.ComponentModel.ISupportInitialize).EndInit
		Me.fraGroupA.ResumeLayout(false)
		CType(Me.vsfToSlotMap1,System.ComponentModel.ISupportInitialize).EndInit
		Me.fraSlotMap.ResumeLayout(false)
		CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub
    Friend WithEvents tabODF As TabControl
    Friend WithEvents fraTab0 As TabPage
    Friend WithEvents fraODF0 As Panel
    Friend WithEvents cmdDel As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTitle03 As Label
    Friend WithEvents lblTFTLotId As Label
    Friend WithEvents lblTitle06 As Label
    Friend WithEvents lblCFLotId As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents fraTab1 As TabPage
    Friend WithEvents fraODF1 As Panel
    Friend WithEvents cmdReserveInfo As Button
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblNowDate1 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents fraTab2 As TabPage
    Friend WithEvents fraODF2 As Panel
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtDummy0 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNowDate0 As Label
    Friend WithEvents vsfCFList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfTFTList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdReserveLotList As Button
    Friend WithEvents cmbTFTandCF As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblCFLotList As Label
    Friend WithEvents lblTFTLotList As Label
    Friend WithEvents vsfTFTWfList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfCFWfList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdTFTMove As Button
    Friend WithEvents cmdTFTMoveCancel As Button
    Friend WithEvents cmdCFMoveCancel As Button
    Friend WithEvents cmdCFMove As Button
    Friend WithEvents lblCFCarrierId As Label
    Friend WithEvents lblTFTCarrierId As Label
    Friend WithEvents lblWfId As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLotId As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfReserveInfo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblReserveStatus As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblNowDate2 As Label
    Friend WithEvents cmdHyoumenReserveInfo As Button
    Friend WithEvents lblBackReason As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents optAll As RadioButton
    Friend WithEvents optDone As RadioButton
    Friend WithEvents optNone As RadioButton
    Friend WithEvents cmdHyoumenDel As Button
    Friend WithEvents cmdHyoumenRegist As Button
    Friend WithEvents vsfHyoumenReserveInfo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblSelectWfCntTitle As Label
    Friend WithEvents lblSelectWfCnt As Label
    Friend WithEvents lblCaution As Label
	Friend WithEvents fraTab3 As TabPage
	Friend WithEvents fraODF3 As Panel
	Friend WithEvents cmdReserveJDel As Button
	Friend WithEvents cmdReserveJRegist As Button
	Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
	Friend WithEvents lblTitle As Label
	Friend WithEvents lblLotID1 As Label
	Friend WithEvents lbTitleLotID As Label
	Friend WithEvents fraSlotMap As GroupBox
	Friend WithEvents cmdCarrierSelect1 As Button
	Friend WithEvents lblToCarrierID1 As Label
	Friend WithEvents vsfToSlotMap1 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents fraGroupA As GroupBox
	Friend WithEvents txtToCarrier1 As SETextBoxEx.TextBoxEx
	Friend WithEvents fraGroupD As GroupBox
	Friend WithEvents txtToCarrier4 As SETextBoxEx.TextBoxEx
	Friend WithEvents cmdCarrierSelect4 As Button
	Friend WithEvents lblToCarrierID4 As Label
	Friend WithEvents vsfToSlotMap4 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents fraGroupC As GroupBox
	Friend WithEvents txtToCarrier3 As SETextBoxEx.TextBoxEx
	Friend WithEvents cmdCarrierSelect3 As Button
	Friend WithEvents lblToCarrierID3 As Label
	Friend WithEvents vsfToSlotMap3 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents fraGroupB As GroupBox
	Friend WithEvents txtToCarrier2 As SETextBoxEx.TextBoxEx
	Friend WithEvents cmdCarrierSelect2 As Button
	Friend WithEvents lblToCarrierID2 As Label
	Friend WithEvents vsfToSlotMap2 As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents lblReserveStatus2 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents cmd5wf As Button
	Friend WithEvents cmd10wf As Button
	Friend WithEvents cmdAfterJReserveList As Button
End Class
