<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02P0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02P0))
        Me.frmClass = New System.Windows.Forms.Panel()
        Me.optClass0 = New System.Windows.Forms.RadioButton()
        Me.optClass1 = New System.Windows.Forms.RadioButton()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdBatchDele = New System.Windows.Forms.Button()
        Me.cmdLotDel = New System.Windows.Forms.Button()
        Me.cmdReleaseHold = New System.Windows.Forms.Button()
        Me.cmdLotIn = New System.Windows.Forms.Button()
        Me.cmdSameACarrier = New System.Windows.Forms.Button()
        Me.cmdHold = New System.Windows.Forms.Button()
        Me.cmdPosiUp = New System.Windows.Forms.Button()
        Me.cmdPosiDown = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.optMoni0 = New System.Windows.Forms.RadioButton()
        Me.optMoni1 = New System.Windows.Forms.RadioButton()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfInvLot = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfAldBatch = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbTapStickGr = New SECmbIchiran.ComboIchiran()
        Me.cmbPd = New SECmbIchiran.ComboIchiran()
        Me.cmbFlowClass = New SECmbIchiran.ComboIchiran()
        Me.dtpThrowInDate = New SECalendarEx.CalendarEx()
        Me.cmbAldBatch = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle12 = New System.Windows.Forms.Label()
        Me.lblEditable = New System.Windows.Forms.Label()
        Me.labStatus = New System.Windows.Forms.Label()
        Me.lblTitle11 = New System.Windows.Forms.Label()
        Me.labBatchFlowClass = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.labMoniter0 = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblDataCnt = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.frmClass.SuspendLayout
        CType(Me.vsfInvLot,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfAldBatch,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'frmClass
        '
        Me.frmClass.Controls.Add(Me.optClass0)
        Me.frmClass.Controls.Add(Me.optClass1)
        Me.frmClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.frmClass.Location = New System.Drawing.Point(408, 336)
        Me.frmClass.Name = "frmClass"
        Me.frmClass.Size = New System.Drawing.Size(169, 41)
        Me.frmClass.TabIndex = 40
        '
        'optClass0
        '
        Me.optClass0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optClass0.Location = New System.Drawing.Point(8, 6)
        Me.optClass0.Name = "optClass0"
        Me.optClass0.Size = New System.Drawing.Size(57, 18)
        Me.optClass0.TabIndex = 42
        Me.optClass0.Text = "製品"
        '
        'optClass1
        '
        Me.optClass1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optClass1.Location = New System.Drawing.Point(8, 24)
        Me.optClass1.Name = "optClass1"
        Me.optClass1.Size = New System.Drawing.Size(153, 18)
        Me.optClass1.TabIndex = 41
        Me.optClass1.Text = "ﾀﾞﾐｰ・ﾓﾆﾀｰ・品確"
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 292)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 14
        Me.cmdRegist.Text = "適用"
        '
        'cmdSave
        '
        Me.cmdSave.CausesValidation = false
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSave.Location = New System.Drawing.Point(800, 292)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(85, 40)
        Me.cmdSave.TabIndex = 13
        Me.cmdSave.Text = "登録"
        '
        'cmdEdit
        '
        Me.cmdEdit.CausesValidation = false
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEdit.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(712, 292)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(85, 40)
        Me.cmdEdit.TabIndex = 12
        Me.cmdEdit.Text = "編集"
        '
        'cmdBatchDele
        '
        Me.cmdBatchDele.CausesValidation = false
        Me.cmdBatchDele.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBatchDele.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdBatchDele.Location = New System.Drawing.Point(624, 292)
        Me.cmdBatchDele.Name = "cmdBatchDele"
        Me.cmdBatchDele.Size = New System.Drawing.Size(85, 40)
        Me.cmdBatchDele.TabIndex = 11
        Me.cmdBatchDele.Text = "削除"
        '
        'cmdLotDel
        '
        Me.cmdLotDel.CausesValidation = false
        Me.cmdLotDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotDel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotDel.Location = New System.Drawing.Point(96, 292)
        Me.cmdLotDel.Name = "cmdLotDel"
        Me.cmdLotDel.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotDel.TabIndex = 6
        Me.cmdLotDel.Text = "↓"
        '
        'cmdReleaseHold
        '
        Me.cmdReleaseHold.CausesValidation = false
        Me.cmdReleaseHold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReleaseHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdReleaseHold.Location = New System.Drawing.Point(208, 602)
        Me.cmdReleaseHold.Name = "cmdReleaseHold"
        Me.cmdReleaseHold.Size = New System.Drawing.Size(85, 40)
        Me.cmdReleaseHold.TabIndex = 22
        Me.cmdReleaseHold.Text = "保留解除"
        '
        'cmdLotIn
        '
        Me.cmdLotIn.CausesValidation = false
        Me.cmdLotIn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotIn.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotIn.Location = New System.Drawing.Point(8, 292)
        Me.cmdLotIn.Name = "cmdLotIn"
        Me.cmdLotIn.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotIn.TabIndex = 5
        Me.cmdLotIn.Text = "↑"
        '
        'cmdSameACarrier
        '
        Me.cmdSameACarrier.CausesValidation = false
        Me.cmdSameACarrier.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSameACarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSameACarrier.Location = New System.Drawing.Point(208, 292)
        Me.cmdSameACarrier.Name = "cmdSameACarrier"
        Me.cmdSameACarrier.Size = New System.Drawing.Size(85, 40)
        Me.cmdSameACarrier.TabIndex = 7
        Me.cmdSameACarrier.Text = "同一A"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ｷｬﾘｱ設定"
        '
        'cmdHold
        '
        Me.cmdHold.CausesValidation = false
        Me.cmdHold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHold.Location = New System.Drawing.Point(120, 602)
        Me.cmdHold.Name = "cmdHold"
        Me.cmdHold.Size = New System.Drawing.Size(85, 40)
        Me.cmdHold.TabIndex = 21
        Me.cmdHold.Text = "保　留"
        '
        'cmdPosiUp
        '
        Me.cmdPosiUp.CausesValidation = false
        Me.cmdPosiUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPosiUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdPosiUp.Location = New System.Drawing.Point(320, 292)
        Me.cmdPosiUp.Name = "cmdPosiUp"
        Me.cmdPosiUp.Size = New System.Drawing.Size(85, 40)
        Me.cmdPosiUp.TabIndex = 8
        Me.cmdPosiUp.Text = "ALD"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"処理部(↑)"
        '
        'cmdPosiDown
        '
        Me.cmdPosiDown.CausesValidation = false
        Me.cmdPosiDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdPosiDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdPosiDown.Location = New System.Drawing.Point(408, 292)
        Me.cmdPosiDown.Name = "cmdPosiDown"
        Me.cmdPosiDown.Size = New System.Drawing.Size(85, 40)
        Me.cmdPosiDown.TabIndex = 9
        Me.cmdPosiDown.Text = "ALD"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"処理部(↓)"
        '
        'cmdClear
        '
        Me.cmdClear.CausesValidation = false
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(520, 292)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdClear.TabIndex = 10
        Me.cmdClear.Text = "クリア"
        '
        'optMoni0
        '
        Me.optMoni0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optMoni0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optMoni0.Location = New System.Drawing.Point(304, 21)
        Me.optMoni0.Name = "optMoni0"
        Me.optMoni0.Size = New System.Drawing.Size(33, 18)
        Me.optMoni0.TabIndex = 2
        Me.optMoni0.Text = "有"
        Me.optMoni0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'optMoni1
        '
        Me.optMoni1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optMoni1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optMoni1.Location = New System.Drawing.Point(356, 21)
        Me.optMoni1.Name = "optMoni1"
        Me.optMoni1.Size = New System.Drawing.Size(33, 18)
        Me.optMoni1.TabIndex = 3
        Me.optMoni1.Text = "無"
        Me.optMoni1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(694, 340)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 18
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 602)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 20
        Me.cmdClose.Text = "閉じる"
        '
        'vsfInvLot
        '
        Me.vsfInvLot.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfInvLot.AllowEditing = false
        Me.vsfInvLot.AutoSearchDelay = 2R
        Me.vsfInvLot.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfInvLot.ColumnInfo = resources.GetString("vsfInvLot.ColumnInfo")
        Me.vsfInvLot.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.vsfInvLot.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfInvLot.ExtendLastCol = true
        Me.vsfInvLot.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfInvLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfInvLot.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfInvLot.Location = New System.Drawing.Point(8, 380)
        Me.vsfInvLot.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfInvLot.Name = "vsfInvLot"
        Me.vsfInvLot.Rows.Count = 11
        Me.vsfInvLot.Rows.DefaultSize = 18
        Me.vsfInvLot.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfInvLot.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfInvLot.Size = New System.Drawing.Size(963, 222)
        Me.vsfInvLot.StyleInfo = resources.GetString("vsfInvLot.StyleInfo")
        Me.vsfInvLot.TabIndex = 19
        '
        'vsfAldBatch
        '
        Me.vsfAldBatch.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfAldBatch.AllowEditing = false
        Me.vsfAldBatch.AutoSearchDelay = 2R
        Me.vsfAldBatch.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfAldBatch.ColumnInfo = resources.GetString("vsfAldBatch.ColumnInfo")
        Me.vsfAldBatch.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.vsfAldBatch.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfAldBatch.ExtendLastCol = true
        Me.vsfAldBatch.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfAldBatch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfAldBatch.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfAldBatch.Location = New System.Drawing.Point(8, 40)
        Me.vsfAldBatch.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfAldBatch.Name = "vsfAldBatch"
        Me.vsfAldBatch.Rows.Count = 12
        Me.vsfAldBatch.Rows.DefaultSize = 18
        Me.vsfAldBatch.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfAldBatch.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfAldBatch.Size = New System.Drawing.Size(963, 247)
        Me.vsfAldBatch.StyleInfo = resources.GetString("vsfAldBatch.StyleInfo")
        Me.vsfAldBatch.TabIndex = 4
        '
        'cmbTapStickGr
        '
        Me.cmbTapStickGr.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbTapStickGr.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbTapStickGr.GridForeColor = System.Drawing.Color.Black
        Me.cmbTapStickGr.Location = New System.Drawing.Point(8, 358)
        Me.cmbTapStickGr.Name = "cmbTapStickGr"
        Me.cmbTapStickGr.Size = New System.Drawing.Size(145, 22)
        Me.cmbTapStickGr.TabIndex = 15
        Me.cmbTapStickGr.Value = Nothing
        '
        'cmbPd
        '
        Me.cmbPd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPd.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPd.GridForeColor = System.Drawing.Color.Black
        Me.cmbPd.Location = New System.Drawing.Point(152, 358)
        Me.cmbPd.Name = "cmbPd"
        Me.cmbPd.Size = New System.Drawing.Size(121, 22)
        Me.cmbPd.TabIndex = 16
        Me.cmbPd.Value = Nothing
        '
        'cmbFlowClass
        '
        Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridForeColor = System.Drawing.Color.Black
        Me.cmbFlowClass.Location = New System.Drawing.Point(272, 358)
        Me.cmbFlowClass.Name = "cmbFlowClass"
        Me.cmbFlowClass.Size = New System.Drawing.Size(121, 22)
        Me.cmbFlowClass.TabIndex = 17
        Me.cmbFlowClass.Value = Nothing
        '
        'dtpThrowInDate
        '
        Me.dtpThrowInDate.DateCheckStatus = 0
        Me.dtpThrowInDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpThrowInDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpThrowInDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpThrowInDate.IsDate = true
        Me.dtpThrowInDate.Location = New System.Drawing.Point(170, 18)
        Me.dtpThrowInDate.Name = "dtpThrowInDate"
        Me.dtpThrowInDate.Size = New System.Drawing.Size(121, 22)
        Me.dtpThrowInDate.TabIndex = 1
        Me.dtpThrowInDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpThrowInDate.Value = "____/__/__"
        '
        'cmbAldBatch
        '
        Me.cmbAldBatch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbAldBatch.ForeColor = System.Drawing.Color.Black
        Me.cmbAldBatch.GetCol = 2
        Me.cmbAldBatch.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbAldBatch.GridForeColor = System.Drawing.Color.Black
        Me.cmbAldBatch.Location = New System.Drawing.Point(8, 18)
        Me.cmbAldBatch.Name = "cmbAldBatch"
        Me.cmbAldBatch.Size = New System.Drawing.Size(161, 22)
        Me.cmbAldBatch.TabIndex = 0
        Me.cmbAldBatch.Value = Nothing
        '
        'lblTitle12
        '
        Me.lblTitle12.BackColor = System.Drawing.Color.Navy
        Me.lblTitle12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle12.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle12.Location = New System.Drawing.Point(633, 2)
        Me.lblTitle12.Name = "lblTitle12"
        Me.lblTitle12.Size = New System.Drawing.Size(113, 17)
        Me.lblTitle12.TabIndex = 44
        Me.lblTitle12.Text = "編集可否"
        Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEditable
        '
        Me.lblEditable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEditable.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEditable.Location = New System.Drawing.Point(633, 18)
        Me.lblEditable.Name = "lblEditable"
        Me.lblEditable.Size = New System.Drawing.Size(113, 22)
        Me.lblEditable.TabIndex = 43
        '
        'labStatus
        '
        Me.labStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labStatus.Location = New System.Drawing.Point(520, 18)
        Me.labStatus.Name = "labStatus"
        Me.labStatus.Size = New System.Drawing.Size(113, 22)
        Me.labStatus.TabIndex = 39
        '
        'lblTitle11
        '
        Me.lblTitle11.BackColor = System.Drawing.Color.Navy
        Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle11.Location = New System.Drawing.Point(520, 2)
        Me.lblTitle11.Name = "lblTitle11"
        Me.lblTitle11.Size = New System.Drawing.Size(113, 17)
        Me.lblTitle11.TabIndex = 38
        Me.lblTitle11.Text = "状　態"
        Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labBatchFlowClass
        '
        Me.labBatchFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labBatchFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labBatchFlowClass.Location = New System.Drawing.Point(406, 18)
        Me.labBatchFlowClass.Name = "labBatchFlowClass"
        Me.labBatchFlowClass.Size = New System.Drawing.Size(113, 22)
        Me.labBatchFlowClass.TabIndex = 37
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(406, 2)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(113, 17)
        Me.lblTitle10.TabIndex = 36
        Me.lblTitle10.Text = "バッチ流動区分"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(292, 2)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(113, 17)
        Me.lblTitle7.TabIndex = 35
        Me.lblTitle7.Text = "モニタ"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Silver
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle9.ForeColor = System.Drawing.Color.Black
        Me.lblTitle9.Location = New System.Drawing.Point(592, 342)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(100, 19)
        Me.lblTitle9.TabIndex = 34
        Me.lblTitle9.Text = "バッチ編成済"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitle9.UseCompatibleTextRendering = true
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Yellow
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Black
        Me.lblTitle8.Location = New System.Drawing.Point(592, 360)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(100, 19)
        Me.lblTitle8.TabIndex = 33
        Me.lblTitle8.Text = "保留"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(170, 2)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle1.TabIndex = 24
        Me.lblTitle1.Text = "投入予定日"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(272, 342)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle4.TabIndex = 28
        Me.lblTitle4.Text = "種別"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(152, 342)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle3.TabIndex = 27
        Me.lblTitle3.Text = "機種"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(8, 342)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(145, 17)
        Me.lblTitle2.TabIndex = 26
        Me.lblTitle2.Text = "貼りグループ"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 2)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle0.TabIndex = 23
        Me.lblTitle0.Text = "バッチ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labMoniter0
        '
        Me.labMoniter0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labMoniter0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labMoniter0.Location = New System.Drawing.Point(292, 18)
        Me.labMoniter0.Name = "labMoniter0"
        Me.labMoniter0.Size = New System.Drawing.Size(113, 22)
        Me.labMoniter0.TabIndex = 25
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(899, 342)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle6.TabIndex = 31
        Me.lblTitle6.Text = "該当件数"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDataCnt
        '
        Me.lblDataCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDataCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDataCnt.Location = New System.Drawing.Point(899, 358)
        Me.lblDataCnt.Name = "lblDataCnt"
        Me.lblDataCnt.Size = New System.Drawing.Size(73, 21)
        Me.lblDataCnt.TabIndex = 32
        Me.lblDataCnt.Text = "0"
        Me.lblDataCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(782, 342)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle5.TabIndex = 29
        Me.lblTitle5.Text = "情報取得日時"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(782, 358)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 30
        Me.lblNowDate.Text = "08/01 16:30:25"
        '
        'frmxxEN02P0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.frmClass)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdBatchDele)
        Me.Controls.Add(Me.cmdLotDel)
        Me.Controls.Add(Me.cmdReleaseHold)
        Me.Controls.Add(Me.cmdLotIn)
        Me.Controls.Add(Me.cmdSameACarrier)
        Me.Controls.Add(Me.cmdHold)
        Me.Controls.Add(Me.cmdPosiUp)
        Me.Controls.Add(Me.cmdPosiDown)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.optMoni0)
        Me.Controls.Add(Me.optMoni1)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfInvLot)
        Me.Controls.Add(Me.vsfAldBatch)
        Me.Controls.Add(Me.cmbTapStickGr)
        Me.Controls.Add(Me.cmbPd)
        Me.Controls.Add(Me.cmbFlowClass)
        Me.Controls.Add(Me.dtpThrowInDate)
        Me.Controls.Add(Me.cmbAldBatch)
        Me.Controls.Add(Me.lblTitle12)
        Me.Controls.Add(Me.lblEditable)
        Me.Controls.Add(Me.labStatus)
        Me.Controls.Add(Me.lblTitle11)
        Me.Controls.Add(Me.labBatchFlowClass)
        Me.Controls.Add(Me.lblTitle10)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblTitle9)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.labMoniter0)
        Me.Controls.Add(Me.lblTitle6)
        Me.Controls.Add(Me.lblDataCnt)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblNowDate)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02P0"
        Me.Text = "バッチ_受入在庫"
        Me.frmClass.ResumeLayout(false)
        CType(Me.vsfInvLot,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfAldBatch,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents frmClass As Panel
    Friend WithEvents optClass0 As RadioButton
    Friend WithEvents optClass1 As RadioButton
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdBatchDele As Button
    Friend WithEvents cmdLotDel As Button
    Friend WithEvents cmdReleaseHold As Button
    Friend WithEvents cmdLotIn As Button
    Friend WithEvents cmdSameACarrier As Button
    Friend WithEvents cmdHold As Button
    Friend WithEvents cmdPosiUp As Button
    Friend WithEvents cmdPosiDown As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents optMoni0 As RadioButton
    Friend WithEvents optMoni1 As RadioButton
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfInvLot As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfAldBatch As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbTapStickGr As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbPd As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents dtpThrowInDate As SECalendarEx.CalendarEx
    Friend WithEvents cmbAldBatch As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle12 As Label
    Friend WithEvents lblEditable As Label
    Friend WithEvents labStatus As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents labBatchFlowClass As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents labMoniter0 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblDataCnt As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblNowDate As Label
End Class
