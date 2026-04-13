<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0270
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0270))
		Me.cmdWFAction = New System.Windows.Forms.Button()
		Me.fraActionReserve = New System.Windows.Forms.Panel()
		Me.cmbWpID = New SECmbIchiran.ComboIchiran()
		Me.cmbProcessinfo = New SECmbIchiran.ComboIchiran()
		Me.cmbProduct = New SEComboBoxEx.ComboBoxEx()
		Me.txtLotID = New SETextBoxEx.TextBoxEx()
		Me.optYoyaku3 = New System.Windows.Forms.RadioButton()
		Me.optYoyaku0 = New System.Windows.Forms.RadioButton()
		Me.optYoyaku2 = New System.Windows.Forms.RadioButton()
		Me.optYoyaku1 = New System.Windows.Forms.RadioButton()
		Me.ltypWFMapInfo0 = New System.Windows.Forms.GroupBox()
		Me.cmdSpecial = New System.Windows.Forms.Button()
		Me.cmdDefult = New System.Windows.Forms.Button()
		Me.cmdRework = New System.Windows.Forms.Button()
		Me.cmdAlt = New System.Windows.Forms.Button()
		Me.cmdNowList = New System.Windows.Forms.Button()
		Me.fraFrame3 = New System.Windows.Forms.Panel()
		Me.optTrigger1 = New System.Windows.Forms.RadioButton()
		Me.optTrigger0 = New System.Windows.Forms.RadioButton()
		Me.vsfUseInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.calFromDate = New SECalendarEx.CalendarEx()
		Me.calToDate = New SECalendarEx.CalendarEx()
		Me.lblStepType = New System.Windows.Forms.Label()
		Me.lblTitle0 = New System.Windows.Forms.Label()
		Me.lblTtl5 = New System.Windows.Forms.Label()
		Me.lblKara = New System.Windows.Forms.Label()
		Me.lblTitle1 = New System.Windows.Forms.Label()
		Me.lblNowDate = New System.Windows.Forms.Label()
		Me.lblStepCnt = New System.Windows.Forms.Label()
		Me.lblTitle6 = New System.Windows.Forms.Label()
		Me.lblFrame1 = New System.Windows.Forms.Label()
		Me.lblTtl2 = New System.Windows.Forms.Label()
		Me.lblFrame0 = New System.Windows.Forms.Label()
		Me.lblTtl1 = New System.Windows.Forms.Label()
		Me.lblFrame3 = New System.Windows.Forms.Label()
		Me.cmdDelete = New System.Windows.Forms.Button()
		Me.cmdClear = New System.Windows.Forms.Button()
		Me.cmdRegist = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.fraFrame2 = New System.Windows.Forms.GroupBox()
		Me.cmdHoldUp = New System.Windows.Forms.Button()
		Me.cmdHoldDown = New System.Windows.Forms.Button()
		Me.cmdWorkMemoDown = New System.Windows.Forms.Button()
		Me.cmdWorkMemoUp = New System.Windows.Forms.Button()
		Me.fraBunrui = New System.Windows.Forms.Panel()
		Me.optBunrui0 = New System.Windows.Forms.RadioButton()
		Me.optBunrui2 = New System.Windows.Forms.RadioButton()
		Me.optBunrui1 = New System.Windows.Forms.RadioButton()
		Me.txtWorkDirect = New SETextBoxEx.TextBoxEx()
		Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
		Me.txtHoldComments = New SETextBoxEx.TextBoxEx()
		Me.cmbTechMan = New SEComboBoxEx.ComboBoxEx()
		Me.calHoldTermDate = New SECalendarEx.CalendarEx()
		Me.cmbMasHold = New SEComboBoxEx.ComboBoxEx()
		Me.txtHoldPeriod = New SETextBoxEx.TextBoxEx()
		Me.lblTtl6 = New System.Windows.Forms.Label()
		Me.lblTtl0 = New System.Windows.Forms.Label()
		Me.lblTtl9 = New System.Windows.Forms.Label()
		Me.lblTtl7 = New System.Windows.Forms.Label()
		Me.lblTtl4 = New System.Windows.Forms.Label()
		Me.lblTtl13 = New System.Windows.Forms.Label()
		Me.lblLengthCount = New System.Windows.Forms.Label()
		Me.lblTtl3 = New System.Windows.Forms.Label()
		Me.lblTtl8 = New System.Windows.Forms.Label()
		Me.lblHoldLengthCount = New System.Windows.Forms.Label()
		Me.lblFrame4 = New System.Windows.Forms.Label()
		Me.fraActionReserve.SuspendLayout
		Me.ltypWFMapInfo0.SuspendLayout
		Me.fraFrame3.SuspendLayout
		CType(Me.vsfUseInfo,System.ComponentModel.ISupportInitialize).BeginInit
		Me.fraFrame2.SuspendLayout
		Me.fraBunrui.SuspendLayout
		Me.lblTtl13.SuspendLayout
		Me.lblTtl8.SuspendLayout
		Me.SuspendLayout
		'
		'cmdWFAction
		'
		Me.cmdWFAction.Enabled = false
		Me.cmdWFAction.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdWFAction.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdWFAction.Location = New System.Drawing.Point(508, 595)
		Me.cmdWFAction.Name = "cmdWFAction"
		Me.cmdWFAction.Size = New System.Drawing.Size(85, 40)
		Me.cmdWFAction.TabIndex = 35
		Me.cmdWFAction.Text = "ＷＦ指定設定"
		'
		'fraActionReserve
		'
		Me.fraActionReserve.Controls.Add(Me.cmbWpID)
		Me.fraActionReserve.Controls.Add(Me.cmbProcessinfo)
		Me.fraActionReserve.Controls.Add(Me.cmbProduct)
		Me.fraActionReserve.Controls.Add(Me.txtLotID)
		Me.fraActionReserve.Controls.Add(Me.optYoyaku3)
		Me.fraActionReserve.Controls.Add(Me.optYoyaku0)
		Me.fraActionReserve.Controls.Add(Me.optYoyaku2)
		Me.fraActionReserve.Controls.Add(Me.optYoyaku1)
		Me.fraActionReserve.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraActionReserve.Location = New System.Drawing.Point(12, 41)
		Me.fraActionReserve.Name = "fraActionReserve"
		Me.fraActionReserve.Size = New System.Drawing.Size(297, 165)
		Me.fraActionReserve.TabIndex = 0
		'
		'cmbWpID
		'
		Me.cmbWpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbWpID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbWpID.GridForeColor = System.Drawing.Color.Black
		Me.cmbWpID.Location = New System.Drawing.Point(88, 88)
		Me.cmbWpID.Name = "cmbWpID"
		Me.cmbWpID.Size = New System.Drawing.Size(209, 22)
		Me.cmbWpID.TabIndex = 6
		Me.cmbWpID.Value = Nothing
		'
		'cmbProcessinfo
		'
		Me.cmbProcessinfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbProcessinfo.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbProcessinfo.GridForeColor = System.Drawing.Color.Black
		Me.cmbProcessinfo.Location = New System.Drawing.Point(88, 128)
		Me.cmbProcessinfo.Name = "cmbProcessinfo"
		Me.cmbProcessinfo.Size = New System.Drawing.Size(209, 22)
		Me.cmbProcessinfo.TabIndex = 7
		Me.cmbProcessinfo.Value = Nothing
		'
		'cmbProduct
		'
		Me.cmbProduct.DirectInput = false
		Me.cmbProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbProduct.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbProduct.GridForeColor = System.Drawing.Color.Black
		Me.cmbProduct.Location = New System.Drawing.Point(88, 48)
		Me.cmbProduct.Name = "cmbProduct"
		Me.cmbProduct.Size = New System.Drawing.Size(209, 22)
		Me.cmbProduct.TabIndex = 5
		Me.cmbProduct.Value = Nothing
		'
		'txtLotID
		'
		Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtLotID.ChrMaxByte = 10
		Me.txtLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
		Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtLotID.Location = New System.Drawing.Point(88, 8)
		Me.txtLotID.Name = "txtLotID"
		Me.txtLotID.NgChr = "'"
		Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtLotID.SelectedText = ""
		Me.txtLotID.Size = New System.Drawing.Size(209, 22)
		Me.txtLotID.TabIndex = 4
		'
		'optYoyaku3
		'
		Me.optYoyaku3.CausesValidation = false
		Me.optYoyaku3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optYoyaku3.Location = New System.Drawing.Point(0, 120)
		Me.optYoyaku3.Name = "optYoyaku3"
		Me.optYoyaku3.Size = New System.Drawing.Size(89, 40)
		Me.optYoyaku3.TabIndex = 3
		Me.optYoyaku3.Text = "特定工程"
		'
		'optYoyaku0
		'
		Me.optYoyaku0.CausesValidation = false
		Me.optYoyaku0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optYoyaku0.Location = New System.Drawing.Point(0, 0)
		Me.optYoyaku0.Name = "optYoyaku0"
		Me.optYoyaku0.Size = New System.Drawing.Size(89, 40)
		Me.optYoyaku0.TabIndex = 0
		Me.optYoyaku0.Text = "ロット"
		'
		'optYoyaku2
		'
		Me.optYoyaku2.CausesValidation = false
		Me.optYoyaku2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optYoyaku2.Location = New System.Drawing.Point(0, 80)
		Me.optYoyaku2.Name = "optYoyaku2"
		Me.optYoyaku2.Size = New System.Drawing.Size(89, 40)
		Me.optYoyaku2.TabIndex = 2
		Me.optYoyaku2.Text = "装置名"
		'
		'optYoyaku1
		'
		Me.optYoyaku1.CausesValidation = false
		Me.optYoyaku1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optYoyaku1.Location = New System.Drawing.Point(0, 40)
		Me.optYoyaku1.Name = "optYoyaku1"
		Me.optYoyaku1.Size = New System.Drawing.Size(89, 40)
		Me.optYoyaku1.TabIndex = 1
		Me.optYoyaku1.Text = "機種"
		'
		'ltypWFMapInfo0
		'
		Me.ltypWFMapInfo0.Controls.Add(Me.fraActionReserve)
		Me.ltypWFMapInfo0.Controls.Add(Me.cmdSpecial)
		Me.ltypWFMapInfo0.Controls.Add(Me.cmdDefult)
		Me.ltypWFMapInfo0.Controls.Add(Me.cmdRework)
		Me.ltypWFMapInfo0.Controls.Add(Me.cmdAlt)
		Me.ltypWFMapInfo0.Controls.Add(Me.cmdNowList)
		Me.ltypWFMapInfo0.Controls.Add(Me.fraFrame3)
		Me.ltypWFMapInfo0.Controls.Add(Me.vsfUseInfo)
		Me.ltypWFMapInfo0.Controls.Add(Me.calFromDate)
		Me.ltypWFMapInfo0.Controls.Add(Me.calToDate)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblStepType)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblTitle0)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblTtl5)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblKara)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblTitle1)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblNowDate)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblStepCnt)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblTitle6)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblFrame1)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblTtl2)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblFrame0)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblTtl1)
		Me.ltypWFMapInfo0.Controls.Add(Me.lblFrame3)
		Me.ltypWFMapInfo0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.ltypWFMapInfo0.Location = New System.Drawing.Point(8, 8)
		Me.ltypWFMapInfo0.Name = "ltypWFMapInfo0"
		Me.ltypWFMapInfo0.Size = New System.Drawing.Size(965, 321)
		Me.ltypWFMapInfo0.TabIndex = 0
		Me.ltypWFMapInfo0.TabStop = false
		Me.ltypWFMapInfo0.Text = "アクション予約対象"
		'
		'cmdSpecial
		'
		Me.cmdSpecial.Enabled = false
		Me.cmdSpecial.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdSpecial.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdSpecial.Location = New System.Drawing.Point(870, 274)
		Me.cmdSpecial.Name = "cmdSpecial"
		Me.cmdSpecial.Size = New System.Drawing.Size(85, 40)
		Me.cmdSpecial.TabIndex = 13
		Me.cmdSpecial.Text = "特殊工程"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
		'
		'cmdDefult
		'
		Me.cmdDefult.Enabled = false
		Me.cmdDefult.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdDefult.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdDefult.Location = New System.Drawing.Point(582, 274)
		Me.cmdDefult.Name = "cmdDefult"
		Me.cmdDefult.Size = New System.Drawing.Size(85, 40)
		Me.cmdDefult.TabIndex = 10
		Me.cmdDefult.Text = "ﾃﾞﾌｫﾙﾄ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
		'
		'cmdRework
		'
		Me.cmdRework.Enabled = false
		Me.cmdRework.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRework.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdRework.Location = New System.Drawing.Point(774, 274)
		Me.cmdRework.Name = "cmdRework"
		Me.cmdRework.Size = New System.Drawing.Size(85, 40)
		Me.cmdRework.TabIndex = 12
		Me.cmdRework.Text = "ﾘﾜｰｸ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
		'
		'cmdAlt
		'
		Me.cmdAlt.Enabled = false
		Me.cmdAlt.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdAlt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdAlt.Location = New System.Drawing.Point(678, 274)
		Me.cmdAlt.Name = "cmdAlt"
		Me.cmdAlt.Size = New System.Drawing.Size(85, 40)
		Me.cmdAlt.TabIndex = 11
		Me.cmdAlt.Text = "代替表示"
		'
		'cmdNowList
		'
		Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdNowList.Location = New System.Drawing.Point(652, 20)
		Me.cmdNowList.Name = "cmdNowList"
		Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
		Me.cmdNowList.TabIndex = 9
		Me.cmdNowList.Text = "最新取得"
		'
		'fraFrame3
		'
		Me.fraFrame3.Controls.Add(Me.optTrigger1)
		Me.fraFrame3.Controls.Add(Me.optTrigger0)
		Me.fraFrame3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraFrame3.Location = New System.Drawing.Point(14, 236)
		Me.fraFrame3.Name = "fraFrame3"
		Me.fraFrame3.Size = New System.Drawing.Size(293, 20)
		Me.fraFrame3.TabIndex = 14
		'
		'optTrigger1
		'
		Me.optTrigger1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optTrigger1.Location = New System.Drawing.Point(150, 2)
		Me.optTrigger1.Name = "optTrigger1"
		Me.optTrigger1.Size = New System.Drawing.Size(105, 19)
		Me.optTrigger1.TabIndex = 15
		Me.optTrigger1.Text = "作業終了時"
		'
		'optTrigger0
		'
		Me.optTrigger0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optTrigger0.Location = New System.Drawing.Point(2, 2)
		Me.optTrigger0.Name = "optTrigger0"
		Me.optTrigger0.Size = New System.Drawing.Size(113, 19)
		Me.optTrigger0.TabIndex = 14
		Me.optTrigger0.Text = "作業開始時"
		'
		'vsfUseInfo
		'
		Me.vsfUseInfo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfUseInfo.AllowEditing = false
		Me.vsfUseInfo.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfUseInfo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfUseInfo.AutoResize = true
		Me.vsfUseInfo.AutoSearchDelay = 2R
		Me.vsfUseInfo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfUseInfo.ColumnInfo = "12,0,0,0,0,105,Columns:0{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"1{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"2{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"3{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"4{Widt"& _ 
    "h:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"5{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"6{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"7{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"8{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"9{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"10{Width"& _ 
    ":72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"11{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)
		Me.vsfUseInfo.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfUseInfo.ExtendLastCol = true
		Me.vsfUseInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfUseInfo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfUseInfo.Location = New System.Drawing.Point(322, 64)
		Me.vsfUseInfo.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfUseInfo.Name = "vsfUseInfo"
		Me.vsfUseInfo.Rows.Count = 11
		Me.vsfUseInfo.Rows.DefaultSize = 18
		Me.vsfUseInfo.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfUseInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
		Me.vsfUseInfo.Size = New System.Drawing.Size(633, 203)
		Me.vsfUseInfo.StyleInfo = resources.GetString("vsfUseInfo.StyleInfo")
		Me.vsfUseInfo.TabIndex = 8
		'
		'calFromDate
		'
		Me.calFromDate.DateCheckStatus = 0
		Me.calFromDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calFromDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calFromDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calFromDate.IsDate = true
		Me.calFromDate.Location = New System.Drawing.Point(14, 288)
		Me.calFromDate.Name = "calFromDate"
		Me.calFromDate.Size = New System.Drawing.Size(121, 22)
		Me.calFromDate.TabIndex = 16
		Me.calFromDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calFromDate.Value = "____/__/__"
		'
		'calToDate
		'
		Me.calToDate.DateCheckStatus = 0
		Me.calToDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calToDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calToDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calToDate.IsDate = true
		Me.calToDate.Location = New System.Drawing.Point(186, 288)
		Me.calToDate.Name = "calToDate"
		Me.calToDate.Size = New System.Drawing.Size(121, 22)
		Me.calToDate.TabIndex = 17
		Me.calToDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calToDate.Value = "____/__/__"
		'
		'lblStepType
		'
		Me.lblStepType.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblStepType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblStepType.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblStepType.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblStepType.Location = New System.Drawing.Point(322, 36)
		Me.lblStepType.Name = "lblStepType"
		Me.lblStepType.Size = New System.Drawing.Size(132, 21)
		Me.lblStepType.TabIndex = 61
		'
		'lblTitle0
		'
		Me.lblTitle0.BackColor = System.Drawing.Color.Navy
		Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle0.Location = New System.Drawing.Point(322, 20)
		Me.lblTitle0.Name = "lblTitle0"
		Me.lblTitle0.Size = New System.Drawing.Size(132, 17)
		Me.lblTitle0.TabIndex = 60
		Me.lblTitle0.Text = "表示工程"
		Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTtl5
		'
		Me.lblTtl5.BackColor = System.Drawing.Color.Navy
		Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl5.Location = New System.Drawing.Point(8, 268)
		Me.lblTtl5.Name = "lblTtl5"
		Me.lblTtl5.Size = New System.Drawing.Size(305, 17)
		Me.lblTtl5.TabIndex = 57
		Me.lblTtl5.Text = "有効期間"
		Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblKara
		'
		Me.lblKara.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblKara.Location = New System.Drawing.Point(148, 288)
		Me.lblKara.Name = "lblKara"
		Me.lblKara.Size = New System.Drawing.Size(33, 21)
		Me.lblKara.TabIndex = 55
		Me.lblKara.Text = "～"
		'
		'lblTitle1
		'
		Me.lblTitle1.BackColor = System.Drawing.Color.Navy
		Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle1.Location = New System.Drawing.Point(744, 20)
		Me.lblTitle1.Name = "lblTitle1"
		Me.lblTitle1.Size = New System.Drawing.Size(122, 17)
		Me.lblTitle1.TabIndex = 54
		Me.lblTitle1.Text = "情報取得日時"
		Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNowDate
		'
		Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate.Location = New System.Drawing.Point(744, 36)
		Me.lblNowDate.Name = "lblNowDate"
		Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
		Me.lblNowDate.TabIndex = 53
		'
		'lblStepCnt
		'
		Me.lblStepCnt.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblStepCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblStepCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblStepCnt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblStepCnt.Location = New System.Drawing.Point(874, 36)
		Me.lblStepCnt.Name = "lblStepCnt"
		Me.lblStepCnt.Size = New System.Drawing.Size(81, 21)
		Me.lblStepCnt.TabIndex = 52
		Me.lblStepCnt.Text = "0"
		Me.lblStepCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTitle6
		'
		Me.lblTitle6.BackColor = System.Drawing.Color.Navy
		Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle6.Location = New System.Drawing.Point(874, 20)
		Me.lblTitle6.Name = "lblTitle6"
		Me.lblTitle6.Size = New System.Drawing.Size(81, 17)
		Me.lblTitle6.TabIndex = 51
		Me.lblTitle6.Text = "該当件数"
		Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblFrame1
		'
		Me.lblFrame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblFrame1.Location = New System.Drawing.Point(8, 232)
		Me.lblFrame1.Name = "lblFrame1"
		Me.lblFrame1.Size = New System.Drawing.Size(305, 29)
		Me.lblFrame1.TabIndex = 43
		'
		'lblTtl2
		'
		Me.lblTtl2.BackColor = System.Drawing.Color.Navy
		Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl2.Location = New System.Drawing.Point(8, 216)
		Me.lblTtl2.Name = "lblTtl2"
		Me.lblTtl2.Size = New System.Drawing.Size(305, 17)
		Me.lblTtl2.TabIndex = 42
		Me.lblTtl2.Text = "アクショントリガー"
		Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblFrame0
		'
		Me.lblFrame0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblFrame0.Location = New System.Drawing.Point(8, 36)
		Me.lblFrame0.Name = "lblFrame0"
		Me.lblFrame0.Size = New System.Drawing.Size(305, 173)
		Me.lblFrame0.TabIndex = 39
		'
		'lblTtl1
		'
		Me.lblTtl1.BackColor = System.Drawing.Color.Navy
		Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl1.Location = New System.Drawing.Point(8, 20)
		Me.lblTtl1.Name = "lblTtl1"
		Me.lblTtl1.Size = New System.Drawing.Size(305, 17)
		Me.lblTtl1.TabIndex = 38
		Me.lblTtl1.Text = "アクション予約タイプ"
		Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblFrame3
		'
		Me.lblFrame3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblFrame3.Location = New System.Drawing.Point(8, 284)
		Me.lblFrame3.Name = "lblFrame3"
		Me.lblFrame3.Size = New System.Drawing.Size(305, 29)
		Me.lblFrame3.TabIndex = 56
		'
		'cmdDelete
		'
		Me.cmdDelete.Enabled = false
		Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdDelete.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdDelete.Location = New System.Drawing.Point(604, 595)
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdDelete.Size = New System.Drawing.Size(85, 40)
		Me.cmdDelete.TabIndex = 34
		Me.cmdDelete.Text = "削　除"
		'
		'cmdClear
		'
		Me.cmdClear.CausesValidation = false
		Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClear.Location = New System.Drawing.Point(792, 595)
		Me.cmdClear.Name = "cmdClear"
		Me.cmdClear.Size = New System.Drawing.Size(85, 40)
		Me.cmdClear.TabIndex = 33
		Me.cmdClear.Text = "全部取消"
		'
		'cmdRegist
		'
		Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdRegist.Location = New System.Drawing.Point(888, 595)
		Me.cmdRegist.Name = "cmdRegist"
		Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
		Me.cmdRegist.TabIndex = 32
		Me.cmdRegist.Text = "確　定"
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(8, 595)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(85, 40)
		Me.cmdClose.TabIndex = 36
		Me.cmdClose.Text = "閉じる"
		'
		'fraFrame2
		'
		Me.fraFrame2.Controls.Add(Me.cmdHoldUp)
		Me.fraFrame2.Controls.Add(Me.cmdHoldDown)
		Me.fraFrame2.Controls.Add(Me.cmdWorkMemoDown)
		Me.fraFrame2.Controls.Add(Me.cmdWorkMemoUp)
		Me.fraFrame2.Controls.Add(Me.fraBunrui)
		Me.fraFrame2.Controls.Add(Me.txtWorkDirect)
		Me.fraFrame2.Controls.Add(Me.txtWorkMemo)
		Me.fraFrame2.Controls.Add(Me.txtHoldComments)
		Me.fraFrame2.Controls.Add(Me.cmbTechMan)
		Me.fraFrame2.Controls.Add(Me.calHoldTermDate)
		Me.fraFrame2.Controls.Add(Me.cmbMasHold)
		Me.fraFrame2.Controls.Add(Me.txtHoldPeriod)
		Me.fraFrame2.Controls.Add(Me.lblTtl6)
		Me.fraFrame2.Controls.Add(Me.lblTtl0)
		Me.fraFrame2.Controls.Add(Me.lblTtl9)
		Me.fraFrame2.Controls.Add(Me.lblTtl7)
		Me.fraFrame2.Controls.Add(Me.lblTtl4)
		Me.fraFrame2.Controls.Add(Me.lblTtl13)
		Me.fraFrame2.Controls.Add(Me.lblTtl3)
		Me.fraFrame2.Controls.Add(Me.lblTtl8)
		Me.fraFrame2.Controls.Add(Me.lblFrame4)
		Me.fraFrame2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraFrame2.Location = New System.Drawing.Point(8, 336)
		Me.fraFrame2.Name = "fraFrame2"
		Me.fraFrame2.Size = New System.Drawing.Size(965, 249)
		Me.fraFrame2.TabIndex = 1
		Me.fraFrame2.TabStop = false
		Me.fraFrame2.Text = "アクション予約登録内容"
		'
		'cmdHoldUp
		'
		Me.cmdHoldUp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdHoldUp.Location = New System.Drawing.Point(726, 163)
		Me.cmdHoldUp.Name = "cmdHoldUp"
		Me.cmdHoldUp.Size = New System.Drawing.Size(25, 37)
		Me.cmdHoldUp.TabIndex = 28
		Me.cmdHoldUp.Text = "▲"
		'
		'cmdHoldDown
		'
		Me.cmdHoldDown.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdHoldDown.Location = New System.Drawing.Point(726, 202)
		Me.cmdHoldDown.Name = "cmdHoldDown"
		Me.cmdHoldDown.Size = New System.Drawing.Size(25, 37)
		Me.cmdHoldDown.TabIndex = 29
		Me.cmdHoldDown.Text = "▼"
		'
		'cmdWorkMemoDown
		'
		Me.cmdWorkMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdWorkMemoDown.Location = New System.Drawing.Point(726, 57)
		Me.cmdWorkMemoDown.Name = "cmdWorkMemoDown"
		Me.cmdWorkMemoDown.Size = New System.Drawing.Size(25, 37)
		Me.cmdWorkMemoDown.TabIndex = 20
		Me.cmdWorkMemoDown.Text = "▼"
		'
		'cmdWorkMemoUp
		'
		Me.cmdWorkMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdWorkMemoUp.Location = New System.Drawing.Point(726, 17)
		Me.cmdWorkMemoUp.Name = "cmdWorkMemoUp"
		Me.cmdWorkMemoUp.Size = New System.Drawing.Size(25, 37)
		Me.cmdWorkMemoUp.TabIndex = 19
		Me.cmdWorkMemoUp.Text = "▲"
		'
		'fraBunrui
		'
		Me.fraBunrui.Controls.Add(Me.optBunrui0)
		Me.fraBunrui.Controls.Add(Me.optBunrui2)
		Me.fraBunrui.Controls.Add(Me.optBunrui1)
		Me.fraBunrui.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraBunrui.Location = New System.Drawing.Point(12, 118)
		Me.fraBunrui.Name = "fraBunrui"
		Me.fraBunrui.Size = New System.Drawing.Size(739, 45)
		Me.fraBunrui.TabIndex = 23
		'
		'optBunrui0
		'
		Me.optBunrui0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optBunrui0.Location = New System.Drawing.Point(4, 6)
		Me.optBunrui0.Name = "optBunrui0"
		Me.optBunrui0.Size = New System.Drawing.Size(239, 33)
		Me.optBunrui0.TabIndex = 23
		Me.optBunrui0.Text = "ロット停止/保留なし"
		'
		'optBunrui2
		'
		Me.optBunrui2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optBunrui2.Location = New System.Drawing.Point(492, 6)
		Me.optBunrui2.Name = "optBunrui2"
		Me.optBunrui2.Size = New System.Drawing.Size(239, 33)
		Me.optBunrui2.TabIndex = 25
		Me.optBunrui2.Text = "ロット保留"
		'
		'optBunrui1
		'
		Me.optBunrui1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.optBunrui1.Location = New System.Drawing.Point(248, 6)
		Me.optBunrui1.Name = "optBunrui1"
		Me.optBunrui1.Size = New System.Drawing.Size(239, 33)
		Me.optBunrui1.TabIndex = 24
		Me.optBunrui1.Text = "ロット停止"
		'
		'txtWorkDirect
		'
		Me.txtWorkDirect.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtWorkDirect.ChrMaxByte = 13
		Me.txtWorkDirect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtWorkDirect.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
		Me.txtWorkDirect.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtWorkDirect.Location = New System.Drawing.Point(758, 34)
		Me.txtWorkDirect.Name = "txtWorkDirect"
		Me.txtWorkDirect.NgChr = "'"
		Me.txtWorkDirect.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtWorkDirect.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtWorkDirect.SelectedText = ""
		Me.txtWorkDirect.Size = New System.Drawing.Size(189, 22)
		Me.txtWorkDirect.TabIndex = 21
		'
		'txtWorkMemo
		'
		Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtWorkMemo.ChrMaxByte = 256
		Me.txtWorkMemo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
		Me.txtWorkMemo.GotHighLight = false
		Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtWorkMemo.Location = New System.Drawing.Point(8, 34)
		Me.txtWorkMemo.MultiLineEx = true
		Me.txtWorkMemo.Name = "txtWorkMemo"
		Me.txtWorkMemo.NgChr = "'"
		Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtWorkMemo.SelectedText = ""
		Me.txtWorkMemo.Size = New System.Drawing.Size(718, 59)
		Me.txtWorkMemo.TabIndex = 18
		'
		'txtHoldComments
		'
		Me.txtHoldComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtHoldComments.ChrMaxByte = 256
		Me.txtHoldComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtHoldComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
		Me.txtHoldComments.GotHighLight = false
		Me.txtHoldComments.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtHoldComments.Location = New System.Drawing.Point(8, 180)
		Me.txtHoldComments.MultiLineEx = true
		Me.txtHoldComments.Name = "txtHoldComments"
		Me.txtHoldComments.NgChr = "'"
		Me.txtHoldComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtHoldComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtHoldComments.SelectedText = ""
		Me.txtHoldComments.Size = New System.Drawing.Size(718, 59)
		Me.txtHoldComments.TabIndex = 27
		'
		'cmbTechMan
		'
		Me.cmbTechMan.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbTechMan.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbTechMan.GridForeColor = System.Drawing.Color.Black
		Me.cmbTechMan.Location = New System.Drawing.Point(758, 73)
		Me.cmbTechMan.Name = "cmbTechMan"
		Me.cmbTechMan.Size = New System.Drawing.Size(189, 22)
		Me.cmbTechMan.TabIndex = 22
		Me.cmbTechMan.Value = Nothing
		'
		'calHoldTermDate
		'
		Me.calHoldTermDate.DateCheckStatus = 0
		Me.calHoldTermDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calHoldTermDate.Enabled = false
		Me.calHoldTermDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calHoldTermDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calHoldTermDate.IsDate = true
		Me.calHoldTermDate.Location = New System.Drawing.Point(758, 208)
		Me.calHoldTermDate.Name = "calHoldTermDate"
		Me.calHoldTermDate.Size = New System.Drawing.Size(189, 22)
		Me.calHoldTermDate.TabIndex = 31
		Me.calHoldTermDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.calHoldTermDate.Value = "____/__/__"
		Me.calHoldTermDate.Visible = false
		'
		'cmbMasHold
		'
		Me.cmbMasHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbMasHold.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmbMasHold.GridForeColor = System.Drawing.Color.Black
		Me.cmbMasHold.Location = New System.Drawing.Point(758, 136)
		Me.cmbMasHold.Name = "cmbMasHold"
		Me.cmbMasHold.Size = New System.Drawing.Size(189, 22)
		Me.cmbMasHold.TabIndex = 26
		Me.cmbMasHold.Value = Nothing
		'
		'txtHoldPeriod
		'
		Me.txtHoldPeriod.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtHoldPeriod.ChrMaxByte = 4
		Me.txtHoldPeriod.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.txtHoldPeriod.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
		Me.txtHoldPeriod.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtHoldPeriod.Location = New System.Drawing.Point(758, 180)
		Me.txtHoldPeriod.Name = "txtHoldPeriod"
		Me.txtHoldPeriod.NgChr = "'"
		Me.txtHoldPeriod.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtHoldPeriod.NumMax = New Decimal(New Integer() {9999, 0, 0, 0})
		Me.txtHoldPeriod.NumMin = New Decimal(New Integer() {1, 0, 0, 0})
		Me.txtHoldPeriod.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtHoldPeriod.SelectedText = ""
		Me.txtHoldPeriod.Size = New System.Drawing.Size(148, 22)
		Me.txtHoldPeriod.TabIndex = 30
		Me.txtHoldPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblTtl6
		'
		Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl6.Location = New System.Drawing.Point(906, 184)
		Me.lblTtl6.Name = "lblTtl6"
		Me.lblTtl6.Size = New System.Drawing.Size(40, 20)
		Me.lblTtl6.TabIndex = 65
		Me.lblTtl6.Text = "日間"
		Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTtl0
		'
		Me.lblTtl0.BackColor = System.Drawing.Color.Navy
		Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl0.Location = New System.Drawing.Point(758, 120)
		Me.lblTtl0.Name = "lblTtl0"
		Me.lblTtl0.Size = New System.Drawing.Size(189, 17)
		Me.lblTtl0.TabIndex = 64
		Me.lblTtl0.Text = "保留理由"
		Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTtl9
		'
		Me.lblTtl9.BackColor = System.Drawing.Color.Navy
		Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl9.Location = New System.Drawing.Point(758, 164)
		Me.lblTtl9.Name = "lblTtl9"
		Me.lblTtl9.Size = New System.Drawing.Size(189, 17)
		Me.lblTtl9.TabIndex = 63
		Me.lblTtl9.Text = "保留期限"
		Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTtl7
		'
		Me.lblTtl7.BackColor = System.Drawing.Color.Navy
		Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl7.Location = New System.Drawing.Point(758, 57)
		Me.lblTtl7.Name = "lblTtl7"
		Me.lblTtl7.Size = New System.Drawing.Size(189, 17)
		Me.lblTtl7.TabIndex = 62
		Me.lblTtl7.Text = "技術担当者"
		Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTtl4
		'
		Me.lblTtl4.BackColor = System.Drawing.Color.Navy
		Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl4.Location = New System.Drawing.Point(8, 98)
		Me.lblTtl4.Name = "lblTtl4"
		Me.lblTtl4.Size = New System.Drawing.Size(945, 17)
		Me.lblTtl4.TabIndex = 50
		Me.lblTtl4.Text = "ロット停止／保留"
		Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTtl13
		'
		Me.lblTtl13.BackColor = System.Drawing.Color.Navy
		Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl13.Controls.Add(Me.lblLengthCount)
		Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl13.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl13.Location = New System.Drawing.Point(8, 18)
		Me.lblTtl13.Name = "lblTtl13"
		Me.lblTtl13.Size = New System.Drawing.Size(718, 17)
		Me.lblTtl13.TabIndex = 47
		Me.lblTtl13.Text = "メッセージ表示"
		Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblLengthCount
		'
		Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
		Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
		Me.lblLengthCount.Location = New System.Drawing.Point(484, 0)
		Me.lblLengthCount.Name = "lblLengthCount"
		Me.lblLengthCount.Size = New System.Drawing.Size(225, 23)
		Me.lblLengthCount.TabIndex = 46
		Me.lblLengthCount.Text = "　（半角0文字/半角256文字）"
		Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTtl3
		'
		Me.lblTtl3.BackColor = System.Drawing.Color.Navy
		Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl3.Location = New System.Drawing.Point(758, 18)
		Me.lblTtl3.Name = "lblTtl3"
		Me.lblTtl3.Size = New System.Drawing.Size(189, 17)
		Me.lblTtl3.TabIndex = 45
		Me.lblTtl3.Text = "作業指示書№"
		Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTtl8
		'
		Me.lblTtl8.BackColor = System.Drawing.Color.Navy
		Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl8.Controls.Add(Me.lblHoldLengthCount)
		Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl8.Location = New System.Drawing.Point(8, 164)
		Me.lblTtl8.Name = "lblTtl8"
		Me.lblTtl8.Size = New System.Drawing.Size(718, 17)
		Me.lblTtl8.TabIndex = 59
		Me.lblTtl8.Text = "保留コメント"
		Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblHoldLengthCount
		'
		Me.lblHoldLengthCount.BackColor = System.Drawing.Color.Transparent
		Me.lblHoldLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblHoldLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
		Me.lblHoldLengthCount.Location = New System.Drawing.Point(484, 0)
		Me.lblHoldLengthCount.Name = "lblHoldLengthCount"
		Me.lblHoldLengthCount.Size = New System.Drawing.Size(225, 23)
		Me.lblHoldLengthCount.TabIndex = 58
		Me.lblHoldLengthCount.Text = "　（半角0文字/半角256文字）"
		Me.lblHoldLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblFrame4
		'
		Me.lblFrame4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblFrame4.Location = New System.Drawing.Point(8, 114)
		Me.lblFrame4.Name = "lblFrame4"
		Me.lblFrame4.Size = New System.Drawing.Size(945, 126)
		Me.lblFrame4.TabIndex = 49
		'
		'frmxxEN0270
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(985, 642)
		Me.Controls.Add(Me.cmdWFAction)
		Me.Controls.Add(Me.ltypWFMapInfo0)
		Me.Controls.Add(Me.cmdDelete)
		Me.Controls.Add(Me.cmdClear)
		Me.Controls.Add(Me.cmdRegist)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.fraFrame2)
		Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN0270"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "アクション予約"
		Me.fraActionReserve.ResumeLayout(false)
		Me.ltypWFMapInfo0.ResumeLayout(false)
		Me.fraFrame3.ResumeLayout(false)
		CType(Me.vsfUseInfo,System.ComponentModel.ISupportInitialize).EndInit
		Me.fraFrame2.ResumeLayout(false)
		Me.fraBunrui.ResumeLayout(false)
		Me.lblTtl13.ResumeLayout(false)
		Me.lblTtl8.ResumeLayout(false)
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdWFAction As Button
    Friend WithEvents fraActionReserve As Panel
    Friend WithEvents cmbWpID As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbProcessinfo As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbProduct As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents optYoyaku3 As RadioButton
    Friend WithEvents optYoyaku0 As RadioButton
    Friend WithEvents optYoyaku2 As RadioButton
    Friend WithEvents optYoyaku1 As RadioButton
    Friend WithEvents ltypWFMapInfo0 As GroupBox
    Friend WithEvents cmdSpecial As Button
    Friend WithEvents cmdDefult As Button
    Friend WithEvents cmdRework As Button
    Friend WithEvents cmdAlt As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents fraFrame3 As Panel
    Friend WithEvents optTrigger1 As RadioButton
    Friend WithEvents optTrigger0 As RadioButton
    Friend WithEvents vsfUseInfo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents calFromDate As SECalendarEx.CalendarEx
    Friend WithEvents calToDate As SECalendarEx.CalendarEx
    Friend WithEvents lblStepType As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblKara As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblStepCnt As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblFrame1 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblFrame0 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblFrame3 As Label
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraFrame2 As GroupBox
    Friend WithEvents cmdHoldUp As Button
    Friend WithEvents cmdHoldDown As Button
    Friend WithEvents cmdWorkMemoDown As Button
    Friend WithEvents cmdWorkMemoUp As Button
    Friend WithEvents fraBunrui As Panel
    Friend WithEvents optBunrui0 As RadioButton
    Friend WithEvents optBunrui2 As RadioButton
    Friend WithEvents optBunrui1 As RadioButton
    Friend WithEvents txtWorkDirect As SETextBoxEx.TextBoxEx
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents txtHoldComments As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbTechMan As SEComboBoxEx.ComboBoxEx
    Friend WithEvents calHoldTermDate As SECalendarEx.CalendarEx
    Friend WithEvents cmbMasHold As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtHoldPeriod As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblHoldLengthCount As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblFrame4 As Label
End Class
