<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM0080
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM0080))
        Me.cmdNowStepNG = New System.Windows.Forms.Button()
        Me.vsfWFMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdComments = New System.Windows.Forms.Button()
        Me.fraProcessKbn = New System.Windows.Forms.Panel()
        Me.optProcessKbn1 = New System.Windows.Forms.RadioButton()
        Me.optProcessKbn2 = New System.Windows.Forms.RadioButton()
        Me.optProcessKbn3 = New System.Windows.Forms.RadioButton()
        Me.cmdHyouri = New System.Windows.Forms.Button()
        Me.cmdMapDownLoad = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.cmdTekiyouClear = New System.Windows.Forms.Button()
        Me.cmdDisplayKbn = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdFuryouTekiyou = New System.Windows.Forms.Button()
        Me.cmdKeikouTekiyou = New System.Windows.Forms.Button()
        Me.vsfChipMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfScpList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfChipCnt = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtDmCode = New SETextBoxEx.TextBoxEx()
        Me.labTokusyu = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblHaraidashi = New System.Windows.Forms.Label()
        Me.lblHaraidashiNew = New System.Windows.Forms.Label()
        Me.lblHaraidashiOld = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblProcessKbn = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblKeikou = New System.Windows.Forms.Label()
        Me.lblChipNo = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblNotti = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblOpName = New System.Windows.Forms.Label()
        Me.lblStepName = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.lblWF = New System.Windows.Forms.Label()
        Me.lblFuryou = New System.Windows.Forms.Label()
        Me.lblFuryouNew = New System.Windows.Forms.Label()
        Me.lblFuryouOld = New System.Windows.Forms.Label()
        Me.lblKeikouNew = New System.Windows.Forms.Label()
        Me.lblKeikouOld = New System.Windows.Forms.Label()
        Me.lblPanelInspectType = New System.Windows.Forms.Label()
        CType(Me.vsfWFMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraProcessKbn.SuspendLayout
        CType(Me.vsfChipMap,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfScpList,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfChipCnt,System.ComponentModel.ISupportInitialize).BeginInit
        Me.lblWF.SuspendLayout
        Me.SuspendLayout
        '
        'cmdNowStepNG
        '
        Me.cmdNowStepNG.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowStepNG.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowStepNG.Location = New System.Drawing.Point(340, 609)
        Me.cmdNowStepNG.Name = "cmdNowStepNG"
        Me.cmdNowStepNG.Size = New System.Drawing.Size(84, 32)
        Me.cmdNowStepNG.TabIndex = 44
        Me.cmdNowStepNG.Text = "現不良"
        '
        'vsfWFMap
        '
        Me.vsfWFMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWFMap.AllowEditing = false
        Me.vsfWFMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWFMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfWFMap.AutoResize = true
        Me.vsfWFMap.AutoSearchDelay = 2R
        Me.vsfWFMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWFMap.ColumnInfo = resources.GetString("vsfWFMap.ColumnInfo")
        Me.vsfWFMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWFMap.ExtendLastCol = true
        Me.vsfWFMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfWFMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWFMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWFMap.Location = New System.Drawing.Point(3, 39)
        Me.vsfWFMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWFMap.Name = "vsfWFMap"
        Me.vsfWFMap.Rows.Count = 26
        Me.vsfWFMap.Rows.DefaultSize = 18
        Me.vsfWFMap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfWFMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWFMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfWFMap.Size = New System.Drawing.Size(121, 570)
        Me.vsfWFMap.StyleInfo = resources.GetString("vsfWFMap.StyleInfo")
        Me.vsfWFMap.TabIndex = 5
        '
        'cmdComments
        '
        Me.cmdComments.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdComments.Location = New System.Drawing.Point(93, 609)
        Me.cmdComments.Name = "cmdComments"
        Me.cmdComments.Size = New System.Drawing.Size(84, 32)
        Me.cmdComments.TabIndex = 9
        Me.cmdComments.Text = "コメント"
        '
        'fraProcessKbn
        '
        Me.fraProcessKbn.Controls.Add(Me.optProcessKbn1)
        Me.fraProcessKbn.Controls.Add(Me.optProcessKbn2)
        Me.fraProcessKbn.Controls.Add(Me.optProcessKbn3)
        Me.fraProcessKbn.Location = New System.Drawing.Point(380, 42)
        Me.fraProcessKbn.Name = "fraProcessKbn"
        Me.fraProcessKbn.Size = New System.Drawing.Size(236, 19)
        Me.fraProcessKbn.TabIndex = 2
        '
        'optProcessKbn1
        '
        Me.optProcessKbn1.Checked = true
        Me.optProcessKbn1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optProcessKbn1.Location = New System.Drawing.Point(6, 0)
        Me.optProcessKbn1.Name = "optProcessKbn1"
        Me.optProcessKbn1.Size = New System.Drawing.Size(90, 19)
        Me.optProcessKbn1.TabIndex = 2
        Me.optProcessKbn1.TabStop = true
        Me.optProcessKbn1.Text = "ﾁｯﾌﾟ登録"
        '
        'optProcessKbn2
        '
        Me.optProcessKbn2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optProcessKbn2.Location = New System.Drawing.Point(99, 0)
        Me.optProcessKbn2.Name = "optProcessKbn2"
        Me.optProcessKbn2.Size = New System.Drawing.Size(62, 19)
        Me.optProcessKbn2.TabIndex = 3
        Me.optProcessKbn2.Text = "電特"
        '
        'optProcessKbn3
        '
        Me.optProcessKbn3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optProcessKbn3.Location = New System.Drawing.Point(162, 0)
        Me.optProcessKbn3.Name = "optProcessKbn3"
        Me.optProcessKbn3.Size = New System.Drawing.Size(67, 19)
        Me.optProcessKbn3.TabIndex = 4
        Me.optProcessKbn3.Text = "WAIST"
        '
        'cmdHyouri
        '
        Me.cmdHyouri.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHyouri.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHyouri.Location = New System.Drawing.Point(182, 609)
        Me.cmdHyouri.Name = "cmdHyouri"
        Me.cmdHyouri.Size = New System.Drawing.Size(63, 32)
        Me.cmdHyouri.TabIndex = 10
        Me.cmdHyouri.Text = "表"
        '
        'cmdMapDownLoad
        '
        Me.cmdMapDownLoad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMapDownLoad.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMapDownLoad.Location = New System.Drawing.Point(429, 609)
        Me.cmdMapDownLoad.Name = "cmdMapDownLoad"
        Me.cmdMapDownLoad.Size = New System.Drawing.Size(105, 32)
        Me.cmdMapDownLoad.TabIndex = 12
        Me.cmdMapDownLoad.Text = "マップ読込"
        '
        'txtCarrier
        '
        Me.txtCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCarrier.Location = New System.Drawing.Point(90, 6)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(67, 28)
        Me.txtCarrier.TabIndex = 0
        '
        'cmdTekiyouClear
        '
        Me.cmdTekiyouClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTekiyouClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTekiyouClear.Location = New System.Drawing.Point(717, 609)
        Me.cmdTekiyouClear.Name = "cmdTekiyouClear"
        Me.cmdTekiyouClear.Size = New System.Drawing.Size(84, 32)
        Me.cmdTekiyouClear.TabIndex = 15
        Me.cmdTekiyouClear.Text = "適用取消"
        '
        'cmdDisplayKbn
        '
        Me.cmdDisplayKbn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDisplayKbn.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDisplayKbn.Location = New System.Drawing.Point(250, 609)
        Me.cmdDisplayKbn.Name = "cmdDisplayKbn"
        Me.cmdDisplayKbn.Size = New System.Drawing.Size(84, 32)
        Me.cmdDisplayKbn.TabIndex = 11
        Me.cmdDisplayKbn.Text = "全体表示"
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(806, 609)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(84, 32)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "取　消"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(895, 609)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(84, 32)
        Me.cmdRegist.TabIndex = 8
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(4, 609)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(84, 32)
        Me.cmdClose.TabIndex = 17
        Me.cmdClose.Text = "閉じる"
        '
        'cmdFuryouTekiyou
        '
        Me.cmdFuryouTekiyou.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFuryouTekiyou.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFuryouTekiyou.Location = New System.Drawing.Point(539, 609)
        Me.cmdFuryouTekiyou.Name = "cmdFuryouTekiyou"
        Me.cmdFuryouTekiyou.Size = New System.Drawing.Size(84, 32)
        Me.cmdFuryouTekiyou.TabIndex = 13
        Me.cmdFuryouTekiyou.Text = "不良適用"
        '
        'cmdKeikouTekiyou
        '
        Me.cmdKeikouTekiyou.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKeikouTekiyou.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKeikouTekiyou.Location = New System.Drawing.Point(628, 609)
        Me.cmdKeikouTekiyou.Name = "cmdKeikouTekiyou"
        Me.cmdKeikouTekiyou.Size = New System.Drawing.Size(84, 32)
        Me.cmdKeikouTekiyou.TabIndex = 14
        Me.cmdKeikouTekiyou.Text = "傾向適用"
        '
        'vsfChipMap
        '
        Me.vsfChipMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfChipMap.AllowEditing = false
        Me.vsfChipMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfChipMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfChipMap.AutoSearchDelay = 2R
        Me.vsfChipMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfChipMap.ColumnInfo = resources.GetString("vsfChipMap.ColumnInfo")
        Me.vsfChipMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfChipMap.ExtendLastCol = true
        Me.vsfChipMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfChipMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfChipMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfChipMap.Location = New System.Drawing.Point(335, 67)
        Me.vsfChipMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfChipMap.Name = "vsfChipMap"
        Me.vsfChipMap.Rows.Count = 20
        Me.vsfChipMap.Rows.DefaultSize = 18
        Me.vsfChipMap.Rows.MinSize = 27
        Me.vsfChipMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfChipMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfChipMap.Size = New System.Drawing.Size(646, 542)
        Me.vsfChipMap.StyleInfo = resources.GetString("vsfChipMap.StyleInfo")
        Me.vsfChipMap.TabIndex = 7
        '
        'vsfScpList
        '
        Me.vsfScpList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfScpList.AllowEditing = false
        Me.vsfScpList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfScpList.AutoResize = true
        Me.vsfScpList.AutoSearchDelay = 2R
        Me.vsfScpList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfScpList.ColumnInfo = resources.GetString("vsfScpList.ColumnInfo")
        Me.vsfScpList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfScpList.ExtendLastCol = true
        Me.vsfScpList.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfScpList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfScpList.Location = New System.Drawing.Point(125, 208)
        Me.vsfScpList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfScpList.Name = "vsfScpList"
        Me.vsfScpList.Rows.Count = 20
        Me.vsfScpList.Rows.DefaultSize = 18
        Me.vsfScpList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfScpList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfScpList.Size = New System.Drawing.Size(209, 401)
        Me.vsfScpList.StyleInfo = resources.GetString("vsfScpList.StyleInfo")
        Me.vsfScpList.TabIndex = 6
        '
        'vsfChipCnt
        '
        Me.vsfChipCnt.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfChipCnt.AllowEditing = false
        Me.vsfChipCnt.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfChipCnt.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfChipCnt.AutoResize = true
        Me.vsfChipCnt.AutoSearchDelay = 2R
        Me.vsfChipCnt.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfChipCnt.ColumnInfo = resources.GetString("vsfChipCnt.ColumnInfo")
        Me.vsfChipCnt.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfChipCnt.Enabled = false
        Me.vsfChipCnt.ExtendLastCol = true
        Me.vsfChipCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfChipCnt.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfChipCnt.Location = New System.Drawing.Point(125, 67)
        Me.vsfChipCnt.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfChipCnt.Name = "vsfChipCnt"
        Me.vsfChipCnt.Rows.Count = 6
        Me.vsfChipCnt.Rows.DefaultSize = 18
        Me.vsfChipCnt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfChipCnt.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfChipCnt.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfChipCnt.Size = New System.Drawing.Size(209, 139)
        Me.vsfChipCnt.StyleInfo = resources.GetString("vsfChipCnt.StyleInfo")
        Me.vsfChipCnt.TabIndex = 31
        Me.vsfChipCnt.TabStop = false
        '
        'txtDmCode
        '
        Me.txtDmCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDmCode.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtDmCode.ChrMaxByte = 11
        Me.txtDmCode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtDmCode.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
        Me.txtDmCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtDmCode.Location = New System.Drawing.Point(208, 38)
        Me.txtDmCode.Name = "txtDmCode"
        Me.txtDmCode.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtDmCode.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDmCode.SelectedText = ""
        Me.txtDmCode.Size = New System.Drawing.Size(126, 28)
        Me.txtDmCode.TabIndex = 1
        '
        'labTokusyu
        '
        Me.labTokusyu.BackColor = System.Drawing.Color.Yellow
        Me.labTokusyu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labTokusyu.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labTokusyu.ForeColor = System.Drawing.Color.Red
        Me.labTokusyu.Location = New System.Drawing.Point(479, 6)
        Me.labTokusyu.Name = "labTokusyu"
        Me.labTokusyu.Size = New System.Drawing.Size(222, 28)
        Me.labTokusyu.TabIndex = 49
        Me.labTokusyu.Text = "特別検査1"
        Me.labTokusyu.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdID
        '
        Me.lblPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(361, 6)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(62, 28)
        Me.lblPdID.TabIndex = 48
        '
        'lblHaraidashi
        '
        Me.lblHaraidashi.BackColor = System.Drawing.Color.Transparent
        Me.lblHaraidashi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHaraidashi.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblHaraidashi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblHaraidashi.Location = New System.Drawing.Point(632, 39)
        Me.lblHaraidashi.Name = "lblHaraidashi"
        Me.lblHaraidashi.Size = New System.Drawing.Size(42, 23)
        Me.lblHaraidashi.TabIndex = 47
        Me.lblHaraidashi.Text = "払出"
        Me.lblHaraidashi.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHaraidashiNew
        '
        Me.lblHaraidashiNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblHaraidashiNew.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblHaraidashiNew.Location = New System.Drawing.Point(632, 50)
        Me.lblHaraidashiNew.Name = "lblHaraidashiNew"
        Me.lblHaraidashiNew.Size = New System.Drawing.Size(42, 12)
        Me.lblHaraidashiNew.TabIndex = 46
        '
        'lblHaraidashiOld
        '
        Me.lblHaraidashiOld.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblHaraidashiOld.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblHaraidashiOld.Location = New System.Drawing.Point(632, 39)
        Me.lblHaraidashiOld.Name = "lblHaraidashiOld"
        Me.lblHaraidashiOld.Size = New System.Drawing.Size(42, 12)
        Me.lblHaraidashiOld.TabIndex = 45
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(126, 38)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(83, 28)
        Me.lblTtl9.TabIndex = 43
        Me.lblTtl9.Text = "ｽｷｬﾅ入力"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblProcessKbn
        '
        Me.lblProcessKbn.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProcessKbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcessKbn.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProcessKbn.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProcessKbn.Location = New System.Drawing.Point(375, 39)
        Me.lblProcessKbn.Name = "lblProcessKbn"
        Me.lblProcessKbn.Size = New System.Drawing.Size(251, 23)
        Me.lblProcessKbn.TabIndex = 37
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(335, 39)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(46, 23)
        Me.lblTtl6.TabIndex = 36
        Me.lblTtl6.Text = "処理"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblKeikou
        '
        Me.lblKeikou.BackColor = System.Drawing.Color.Transparent
        Me.lblKeikou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblKeikou.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblKeikou.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblKeikou.Location = New System.Drawing.Point(714, 39)
        Me.lblKeikou.Name = "lblKeikou"
        Me.lblKeikou.Size = New System.Drawing.Size(42, 23)
        Me.lblKeikou.TabIndex = 35
        Me.lblKeikou.Text = "傾向"
        Me.lblKeikou.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblChipNo
        '
        Me.lblChipNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblChipNo.Location = New System.Drawing.Point(818, 40)
        Me.lblChipNo.Name = "lblChipNo"
        Me.lblChipNo.Size = New System.Drawing.Size(32, 18)
        Me.lblChipNo.TabIndex = 33
        Me.lblChipNo.Text = "123"
        '
        'lblTtl5
        '
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.Location = New System.Drawing.Point(756, 40)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(74, 18)
        Me.lblTtl5.TabIndex = 32
        Me.lblTtl5.Text = "ﾁｯﾌﾟ№："
        '
        'lblNotti
        '
        Me.lblNotti.BackColor = System.Drawing.Color.Transparent
        Me.lblNotti.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNotti.Location = New System.Drawing.Point(14, 20)
        Me.lblNotti.Name = "lblNotti"
        Me.lblNotti.Size = New System.Drawing.Size(14, 19)
        Me.lblNotti.TabIndex = 29
        Me.lblNotti.Text = "△"
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(851, 38)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(42, 23)
        Me.lblTtl7.TabIndex = 28
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(887, 38)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(95, 23)
        Me.lblStatus.TabIndex = 27
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(156, 6)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(74, 28)
        Me.lblTtl1.TabIndex = 26
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(334, 6)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(31, 28)
        Me.lblFlowClass.TabIndex = 25
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(4, 6)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(90, 28)
        Me.lblTtl0.TabIndex = 24
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(226, 6)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(115, 28)
        Me.lblLotID.TabIndex = 23
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(420, 6)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(58, 28)
        Me.lblTtl3.TabIndex = 22
        Me.lblTtl3.Text = "大工程"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpName
        '
        Me.lblOpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpName.Location = New System.Drawing.Point(477, 6)
        Me.lblOpName.Name = "lblOpName"
        Me.lblOpName.Size = New System.Drawing.Size(224, 28)
        Me.lblOpName.TabIndex = 21
        '
        'lblStepName
        '
        Me.lblStepName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepName.Location = New System.Drawing.Point(757, 6)
        Me.lblStepName.Name = "lblStepName"
        Me.lblStepName.Size = New System.Drawing.Size(224, 28)
        Me.lblStepName.TabIndex = 20
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(700, 6)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(58, 28)
        Me.lblTtl8.TabIndex = 19
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Location = New System.Drawing.Point(2, 2)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(981, 35)
        Me.lblBack.TabIndex = 18
        '
        'lblWF
        '
        Me.lblWF.Controls.Add(Me.lblNotti)
        Me.lblWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWF.Location = New System.Drawing.Point(628, 34)
        Me.lblWF.Name = "lblWF"
        Me.lblWF.Size = New System.Drawing.Size(40, 34)
        Me.lblWF.TabIndex = 30
        Me.lblWF.Text = "○"
        '
        'lblFuryou
        '
        Me.lblFuryou.BackColor = System.Drawing.Color.Transparent
        Me.lblFuryou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFuryou.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFuryou.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFuryou.Location = New System.Drawing.Point(673, 39)
        Me.lblFuryou.Name = "lblFuryou"
        Me.lblFuryou.Size = New System.Drawing.Size(42, 23)
        Me.lblFuryou.TabIndex = 34
        Me.lblFuryou.Text = "不良"
        Me.lblFuryou.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFuryouNew
        '
        Me.lblFuryouNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblFuryouNew.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFuryouNew.Location = New System.Drawing.Point(673, 50)
        Me.lblFuryouNew.Name = "lblFuryouNew"
        Me.lblFuryouNew.Size = New System.Drawing.Size(42, 12)
        Me.lblFuryouNew.TabIndex = 40
        '
        'lblFuryouOld
        '
        Me.lblFuryouOld.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblFuryouOld.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFuryouOld.Location = New System.Drawing.Point(673, 39)
        Me.lblFuryouOld.Name = "lblFuryouOld"
        Me.lblFuryouOld.Size = New System.Drawing.Size(42, 12)
        Me.lblFuryouOld.TabIndex = 39
        '
        'lblKeikouNew
        '
        Me.lblKeikouNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(223,Byte),Integer), CType(CType(223,Byte),Integer), CType(CType(96,Byte),Integer))
        Me.lblKeikouNew.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblKeikouNew.Location = New System.Drawing.Point(714, 50)
        Me.lblKeikouNew.Name = "lblKeikouNew"
        Me.lblKeikouNew.Size = New System.Drawing.Size(42, 12)
        Me.lblKeikouNew.TabIndex = 42
        '
        'lblKeikouOld
        '
        Me.lblKeikouOld.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblKeikouOld.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblKeikouOld.Location = New System.Drawing.Point(714, 39)
        Me.lblKeikouOld.Name = "lblKeikouOld"
        Me.lblKeikouOld.Size = New System.Drawing.Size(42, 12)
        Me.lblKeikouOld.TabIndex = 41
        '
        'lblPanelInspectType
        '
        Me.lblPanelInspectType.BackColor = System.Drawing.Color.Yellow
        Me.lblPanelInspectType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPanelInspectType.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPanelInspectType.ForeColor = System.Drawing.Color.Red
        Me.lblPanelInspectType.Location = New System.Drawing.Point(30, 76)
        Me.lblPanelInspectType.Name = "lblPanelInspectType"
        Me.lblPanelInspectType.Size = New System.Drawing.Size(83, 59)
        Me.lblPanelInspectType.TabIndex = 50
        Me.lblPanelInspectType.Text = "全数検査"
        Me.lblPanelInspectType.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxCM0080
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblPanelInspectType)
        Me.Controls.Add(Me.labTokusyu)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.cmdNowStepNG)
        Me.Controls.Add(Me.vsfWFMap)
        Me.Controls.Add(Me.cmdComments)
        Me.Controls.Add(Me.fraProcessKbn)
        Me.Controls.Add(Me.cmdHyouri)
        Me.Controls.Add(Me.cmdMapDownLoad)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.cmdTekiyouClear)
        Me.Controls.Add(Me.cmdDisplayKbn)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdFuryouTekiyou)
        Me.Controls.Add(Me.cmdKeikouTekiyou)
        Me.Controls.Add(Me.vsfChipMap)
        Me.Controls.Add(Me.vsfScpList)
        Me.Controls.Add(Me.vsfChipCnt)
        Me.Controls.Add(Me.txtDmCode)
        Me.Controls.Add(Me.lblHaraidashi)
        Me.Controls.Add(Me.lblHaraidashiNew)
        Me.Controls.Add(Me.lblHaraidashiOld)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblProcessKbn)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblKeikou)
        Me.Controls.Add(Me.lblChipNo)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblOpName)
        Me.Controls.Add(Me.lblStepName)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblBack)
        Me.Controls.Add(Me.lblWF)
        Me.Controls.Add(Me.lblFuryou)
        Me.Controls.Add(Me.lblFuryouNew)
        Me.Controls.Add(Me.lblFuryouOld)
        Me.Controls.Add(Me.lblKeikouNew)
        Me.Controls.Add(Me.lblKeikouOld)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM0080"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "チップ状態変更登録"
        CType(Me.vsfWFMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraProcessKbn.ResumeLayout(false)
        CType(Me.vsfChipMap,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfScpList,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfChipCnt,System.ComponentModel.ISupportInitialize).EndInit
        Me.lblWF.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdNowStepNG As Button
    Friend WithEvents vsfWFMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdComments As Button
    Friend WithEvents fraProcessKbn As Panel
    Friend WithEvents optProcessKbn1 As RadioButton
    Friend WithEvents optProcessKbn2 As RadioButton
    Friend WithEvents optProcessKbn3 As RadioButton
    Friend WithEvents cmdHyouri As Button
    Friend WithEvents cmdMapDownLoad As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdTekiyouClear As Button
    Friend WithEvents cmdDisplayKbn As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdFuryouTekiyou As Button
    Friend WithEvents cmdKeikouTekiyou As Button
    Friend WithEvents vsfChipMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfScpList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfChipCnt As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtDmCode As SETextBoxEx.TextBoxEx
    Friend WithEvents labTokusyu As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblHaraidashi As Label
    Friend WithEvents lblHaraidashiNew As Label
    Friend WithEvents lblHaraidashiOld As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblProcessKbn As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblKeikou As Label
    Friend WithEvents lblChipNo As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblNotti As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblOpName As Label
    Friend WithEvents lblStepName As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents lblWF As Label
    Friend WithEvents lblFuryou As Label
    Friend WithEvents lblFuryouNew As Label
    Friend WithEvents lblFuryouOld As Label
    Friend WithEvents lblKeikouNew As Label
    Friend WithEvents lblKeikouOld As Label
    Friend WithEvents lblPanelInspectType As Label
End Class
