<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00M0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00M0))
        Me.cmdVsfProductDisp = New System.Windows.Forms.Button()
        Me.cmdLotConnectedInfoDisp = New System.Windows.Forms.Button()
        Me.cmdDummySelect = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdLotList = New System.Windows.Forms.Button()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.cmdMonitorLotList = New System.Windows.Forms.Button()
        Me.fraBatList = New System.Windows.Forms.GroupBox()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.vsfBatList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraProduct = New System.Windows.Forms.GroupBox()
        Me.optKubun0 = New System.Windows.Forms.RadioButton()
        Me.optKubun2 = New System.Windows.Forms.RadioButton()
        Me.optKubun3 = New System.Windows.Forms.RadioButton()
        Me.optKubun1 = New System.Windows.Forms.RadioButton()
        Me.vsfProduct = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblBackReason = New System.Windows.Forms.Label()
        Me.lblProductWpList = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdKakutei = New System.Windows.Forms.Button()
        Me.cmbMcGpName = New SEComboBoxEx.ComboBoxEx()
        Me.fraBat = New System.Windows.Forms.GroupBox()
        Me.vsfBat = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmbWpName = New SEComboBoxEx.ComboBoxEx()
        Me.lblMethod = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblMesModeId = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.lblBatLotWFCntTitle = New System.Windows.Forms.Label()
        Me.lblVaConditionFlag = New System.Windows.Forms.Label()
        Me.lblVaConditionFlagTitle = New System.Windows.Forms.Label()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.lblBatLotWFCnt = New System.Windows.Forms.Label()
        Me.lblVaCondition = New System.Windows.Forms.Label()
        Me.lblVaConditionTitle = New System.Windows.Forms.Label()
        Me.lblMaxLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblBatchId = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblRecipeId = New System.Windows.Forms.Label()
        Me.lblTitleInspect = New System.Windows.Forms.Label()
        Me.lblTitleCfLot = New System.Windows.Forms.Label()
        Me.lblTitlePair = New System.Windows.Forms.Label()
        Me.lblLotListCnt = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.cmdMoveAll = New System.Windows.Forms.Button()
        Me.fraBatList.SuspendLayout
        CType(Me.vsfBatList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraProduct.SuspendLayout
        CType(Me.vsfProduct,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraBat.SuspendLayout
        CType(Me.vsfBat,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdVsfProductDisp
        '
        Me.cmdVsfProductDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfProductDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfProductDisp.Location = New System.Drawing.Point(200, 598)
        Me.cmdVsfProductDisp.Name = "cmdVsfProductDisp"
        Me.cmdVsfProductDisp.Size = New System.Drawing.Size(85, 40)
        Me.cmdVsfProductDisp.TabIndex = 53
        Me.cmdVsfProductDisp.Text = "表示切替"
        '
        'cmdLotConnectedInfoDisp
        '
        Me.cmdLotConnectedInfoDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotConnectedInfoDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotConnectedInfoDisp.Location = New System.Drawing.Point(392, 598)
        Me.cmdLotConnectedInfoDisp.Name = "cmdLotConnectedInfoDisp"
        Me.cmdLotConnectedInfoDisp.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotConnectedInfoDisp.TabIndex = 52
        Me.cmdLotConnectedInfoDisp.Text = "TFT/CF"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"情報表示"
        '
        'cmdDummySelect
        '
        Me.cmdDummySelect.CausesValidation = false
        Me.cmdDummySelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDummySelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDummySelect.Location = New System.Drawing.Point(699, 598)
        Me.cmdDummySelect.Name = "cmdDummySelect"
        Me.cmdDummySelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdDummySelect.TabIndex = 15
        Me.cmdDummySelect.Text = "ﾀﾞﾐｰ冶具"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdClear
        '
        Me.cmdClear.CausesValidation = false
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(793, 598)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "取　消"
        '
        'cmdLotList
        '
        Me.cmdLotList.CausesValidation = false
        Me.cmdLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotList.Location = New System.Drawing.Point(219, 5)
        Me.cmdLotList.Name = "cmdLotList"
        Me.cmdLotList.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotList.TabIndex = 17
        Me.cmdLotList.Text = "最新取得"
        '
        'cmdMove
        '
        Me.cmdMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMove.Location = New System.Drawing.Point(511, 258)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.Size = New System.Drawing.Size(85, 40)
        Me.cmdMove.TabIndex = 7
        Me.cmdMove.Text = ">"
        '
        'cmdRemove
        '
        Me.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRemove.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRemove.Location = New System.Drawing.Point(511, 322)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(85, 40)
        Me.cmdRemove.TabIndex = 8
        Me.cmdRemove.Text = "<"
        '
        'cmdMonitorLotList
        '
        Me.cmdMonitorLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMonitorLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMonitorLotList.Location = New System.Drawing.Point(603, 598)
        Me.cmdMonitorLotList.Name = "cmdMonitorLotList"
        Me.cmdMonitorLotList.Size = New System.Drawing.Size(85, 40)
        Me.cmdMonitorLotList.TabIndex = 16
        Me.cmdMonitorLotList.Text = "モニタ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'fraBatList
        '
        Me.fraBatList.Controls.Add(Me.cmdDelete)
        Me.fraBatList.Controls.Add(Me.cmdEdit)
        Me.fraBatList.Controls.Add(Me.vsfBatList)
        Me.fraBatList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraBatList.Location = New System.Drawing.Point(9, 468)
        Me.fraBatList.Name = "fraBatList"
        Me.fraBatList.Size = New System.Drawing.Size(495, 126)
        Me.fraBatList.TabIndex = 18
        Me.fraBatList.TabStop = false
        Me.fraBatList.Text = "バッチ編成一覧"
        '
        'cmdDelete
        '
        Me.cmdDelete.CausesValidation = false
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDelete.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(399, 75)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(85, 40)
        Me.cmdDelete.TabIndex = 20
        Me.cmdDelete.Text = "削　除"
        '
        'cmdEdit
        '
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEdit.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(399, 24)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(85, 40)
        Me.cmdEdit.TabIndex = 19
        Me.cmdEdit.Text = "編　集"
        '
        'vsfBatList
        '
        Me.vsfBatList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfBatList.AllowEditing = false
        Me.vsfBatList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfBatList.AutoResize = true
        Me.vsfBatList.AutoSearchDelay = 2R
        Me.vsfBatList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfBatList.ColumnInfo = resources.GetString("vsfBatList.ColumnInfo")
        Me.vsfBatList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfBatList.ExtendLastCol = true
        Me.vsfBatList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfBatList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfBatList.Location = New System.Drawing.Point(9, 24)
        Me.vsfBatList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfBatList.Name = "vsfBatList"
        Me.vsfBatList.Rows.Count = 10
        Me.vsfBatList.Rows.DefaultSize = 18
        Me.vsfBatList.Rows.MaxSize = 18
        Me.vsfBatList.Rows.MinSize = 18
        Me.vsfBatList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfBatList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfBatList.Size = New System.Drawing.Size(381, 92)
        Me.vsfBatList.StyleInfo = resources.GetString("vsfBatList.StyleInfo")
        Me.vsfBatList.TabIndex = 18
        '
        'fraProduct
        '
        Me.fraProduct.Controls.Add(Me.optKubun0)
        Me.fraProduct.Controls.Add(Me.optKubun2)
        Me.fraProduct.Controls.Add(Me.optKubun3)
        Me.fraProduct.Controls.Add(Me.optKubun1)
        Me.fraProduct.Controls.Add(Me.vsfProduct)
        Me.fraProduct.Controls.Add(Me.lblTitle8)
        Me.fraProduct.Controls.Add(Me.lblBackReason)
        Me.fraProduct.Controls.Add(Me.lblProductWpList)
        Me.fraProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraProduct.Location = New System.Drawing.Point(9, 51)
        Me.fraProduct.Name = "fraProduct"
        Me.fraProduct.Size = New System.Drawing.Size(495, 415)
        Me.fraProduct.TabIndex = 2
        Me.fraProduct.TabStop = false
        Me.fraProduct.Text = "製品ロット"
        '
        'optKubun0
        '
        Me.optKubun0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun0.Location = New System.Drawing.Point(65, 26)
        Me.optKubun0.Name = "optKubun0"
        Me.optKubun0.Size = New System.Drawing.Size(57, 16)
        Me.optKubun0.TabIndex = 2
        Me.optKubun0.Text = "全て"
        '
        'optKubun2
        '
        Me.optKubun2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optKubun2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun2.Location = New System.Drawing.Point(240, 26)
        Me.optKubun2.Name = "optKubun2"
        Me.optKubun2.Size = New System.Drawing.Size(118, 16)
        Me.optKubun2.TabIndex = 4
        Me.optKubun2.Text = "モニタロット"
        Me.optKubun2.UseVisualStyleBackColor = false
        '
        'optKubun3
        '
        Me.optKubun3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optKubun3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun3.Location = New System.Drawing.Point(359, 26)
        Me.optKubun3.Name = "optKubun3"
        Me.optKubun3.Size = New System.Drawing.Size(121, 16)
        Me.optKubun3.TabIndex = 5
        Me.optKubun3.Text = "ダミーロット"
        Me.optKubun3.UseVisualStyleBackColor = false
        '
        'optKubun1
        '
        Me.optKubun1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun1.Location = New System.Drawing.Point(131, 26)
        Me.optKubun1.Name = "optKubun1"
        Me.optKubun1.Size = New System.Drawing.Size(106, 16)
        Me.optKubun1.TabIndex = 3
        Me.optKubun1.Text = "製品ロット"
        '
        'vsfProduct
        '
        Me.vsfProduct.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfProduct.AllowEditing = false
        Me.vsfProduct.AutoResize = true
        Me.vsfProduct.AutoSearchDelay = 2R
        Me.vsfProduct.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfProduct.ColumnInfo = resources.GetString("vsfProduct.ColumnInfo")
        Me.vsfProduct.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfProduct.ExtendLastCol = true
        Me.vsfProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfProduct.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfProduct.Location = New System.Drawing.Point(9, 76)
        Me.vsfProduct.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfProduct.Name = "vsfProduct"
        Me.vsfProduct.Rows.DefaultSize = 18
        Me.vsfProduct.Rows.MaxSize = 18
        Me.vsfProduct.Rows.MinSize = 18
        Me.vsfProduct.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfProduct.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfProduct.Size = New System.Drawing.Size(474, 326)
        Me.vsfProduct.StyleInfo = resources.GetString("vsfProduct.StyleInfo")
        Me.vsfProduct.TabIndex = 6
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(9, 24)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(50, 19)
        Me.lblTitle8.TabIndex = 43
        Me.lblTitle8.Text = "表示"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBackReason
        '
        Me.lblBackReason.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBackReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackReason.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBackReason.Location = New System.Drawing.Point(59, 24)
        Me.lblBackReason.Name = "lblBackReason"
        Me.lblBackReason.Size = New System.Drawing.Size(424, 19)
        Me.lblBackReason.TabIndex = 42
        '
        'lblProductWpList
        '
        Me.lblProductWpList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductWpList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProductWpList.Location = New System.Drawing.Point(9, 51)
        Me.lblProductWpList.Name = "lblProductWpList"
        Me.lblProductWpList.Size = New System.Drawing.Size(474, 17)
        Me.lblProductWpList.TabIndex = 29
        Me.lblProductWpList.Text = "1：装置１　2：装置２　3：装置３　4：装置４　5：装置５　6：装置６"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 598)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 21
        Me.cmdClose.Text = "閉じる"
        '
        'cmdKakutei
        '
        Me.cmdKakutei.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKakutei.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKakutei.Location = New System.Drawing.Point(888, 598)
        Me.cmdKakutei.Name = "cmdKakutei"
        Me.cmdKakutei.Size = New System.Drawing.Size(85, 40)
        Me.cmdKakutei.TabIndex = 13
        Me.cmdKakutei.Text = "確　定"
        '
        'cmbMcGpName
        '
        Me.cmbMcGpName.DirectInput = false
        Me.cmbMcGpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGpName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGpName.Location = New System.Drawing.Point(8, 21)
        Me.cmbMcGpName.Name = "cmbMcGpName"
        Me.cmbMcGpName.Size = New System.Drawing.Size(204, 22)
        Me.cmbMcGpName.TabIndex = 0
        Me.cmbMcGpName.Value = Nothing
        '
        'fraBat
        '
        Me.fraBat.Controls.Add(Me.vsfBat)
        Me.fraBat.Controls.Add(Me.cmdCarrierSelect)
        Me.fraBat.Controls.Add(Me.cmdDown)
        Me.fraBat.Controls.Add(Me.cmdUp)
        Me.fraBat.Controls.Add(Me.cmbWpName)
        Me.fraBat.Controls.Add(Me.lblMethod)
        Me.fraBat.Controls.Add(Me.lblTitle10)
        Me.fraBat.Controls.Add(Me.lblMesModeId)
        Me.fraBat.Controls.Add(Me.lblTitle9)
        Me.fraBat.Controls.Add(Me.lblBatLotWFCntTitle)
        Me.fraBat.Controls.Add(Me.lblVaConditionFlag)
        Me.fraBat.Controls.Add(Me.lblVaConditionFlagTitle)
        Me.fraBat.Controls.Add(Me.lblInstruction)
        Me.fraBat.Controls.Add(Me.lblBatLotWFCnt)
        Me.fraBat.Controls.Add(Me.lblVaCondition)
        Me.fraBat.Controls.Add(Me.lblVaConditionTitle)
        Me.fraBat.Controls.Add(Me.lblMaxLotCnt)
        Me.fraBat.Controls.Add(Me.lblTitle6)
        Me.fraBat.Controls.Add(Me.lblTitle1)
        Me.fraBat.Controls.Add(Me.lblTitle3)
        Me.fraBat.Controls.Add(Me.lblBatchId)
        Me.fraBat.Controls.Add(Me.lblTitle2)
        Me.fraBat.Controls.Add(Me.lblRecipeId)
        Me.fraBat.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraBat.Location = New System.Drawing.Point(602, 51)
        Me.fraBat.Name = "fraBat"
        Me.fraBat.Size = New System.Drawing.Size(370, 543)
        Me.fraBat.TabIndex = 1
        Me.fraBat.TabStop = false
        Me.fraBat.Text = "バッチ編成"
        '
        'vsfBat
        '
        Me.vsfBat.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfBat.AllowEditing = false
        Me.vsfBat.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfBat.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfBat.AutoResize = true
        Me.vsfBat.AutoSearchDelay = 2R
        Me.vsfBat.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfBat.ColumnInfo = resources.GetString("vsfBat.ColumnInfo")
        Me.vsfBat.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfBat.ExtendLastCol = true
        Me.vsfBat.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfBat.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfBat.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfBat.Location = New System.Drawing.Point(7, 206)
        Me.vsfBat.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfBat.Name = "vsfBat"
        Me.vsfBat.Rows.Count = 20
        Me.vsfBat.Rows.DefaultSize = 18
        Me.vsfBat.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfBat.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfBat.Size = New System.Drawing.Size(357, 218)
        Me.vsfBat.StyleInfo = resources.GetString("vsfBat.StyleInfo")
        Me.vsfBat.TabIndex = 9
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.CausesValidation = false
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(279, 441)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect.TabIndex = 12
        Me.cmdCarrierSelect.Text = "ULDｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(93, 441)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(85, 40)
        Me.cmdDown.TabIndex = 11
        Me.cmdDown.Text = "↓"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp.Location = New System.Drawing.Point(7, 441)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(85, 40)
        Me.cmdUp.TabIndex = 10
        Me.cmdUp.Text = "↑"
        '
        'cmbWpName
        '
        Me.cmbWpName.DirectInput = false
        Me.cmbWpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpName.Location = New System.Drawing.Point(6, 36)
        Me.cmbWpName.Name = "cmbWpName"
        Me.cmbWpName.Size = New System.Drawing.Size(248, 22)
        Me.cmbWpName.TabIndex = 1
        Me.cmbWpName.Value = Nothing
        '
        'lblMethod
        '
        Me.lblMethod.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMethod.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMethod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMethod.Location = New System.Drawing.Point(260, 83)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(105, 21)
        Me.lblMethod.TabIndex = 51
        Me.lblMethod.Text = "手動/自動"
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(260, 66)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(105, 17)
        Me.lblTitle10.TabIndex = 50
        Me.lblTitle10.Text = "編成方式"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMesModeId
        '
        Me.lblMesModeId.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMesModeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMesModeId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMesModeId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMesModeId.Location = New System.Drawing.Point(260, 36)
        Me.lblMesModeId.Name = "lblMesModeId"
        Me.lblMesModeId.Size = New System.Drawing.Size(105, 21)
        Me.lblMesModeId.TabIndex = 49
        Me.lblMesModeId.Text = "M1/S1/S2"
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(260, 21)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(105, 17)
        Me.lblTitle9.TabIndex = 48
        Me.lblTitle9.Text = "運用モード"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBatLotWFCntTitle
        '
        Me.lblBatLotWFCntTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBatLotWFCntTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatLotWFCntTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatLotWFCntTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBatLotWFCntTitle.Location = New System.Drawing.Point(260, 112)
        Me.lblBatLotWFCntTitle.Name = "lblBatLotWFCntTitle"
        Me.lblBatLotWFCntTitle.Size = New System.Drawing.Size(105, 17)
        Me.lblBatLotWFCntTitle.TabIndex = 47
        Me.lblBatLotWFCntTitle.Text = "バッチ組WF数"
        Me.lblBatLotWFCntTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblVaConditionFlag
        '
        Me.lblVaConditionFlag.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblVaConditionFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVaConditionFlag.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVaConditionFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVaConditionFlag.Location = New System.Drawing.Point(255, 509)
        Me.lblVaConditionFlag.Name = "lblVaConditionFlag"
        Me.lblVaConditionFlag.Size = New System.Drawing.Size(109, 21)
        Me.lblVaConditionFlag.TabIndex = 46
        Me.lblVaConditionFlag.Text = "有効"
        '
        'lblVaConditionFlagTitle
        '
        Me.lblVaConditionFlagTitle.BackColor = System.Drawing.Color.Navy
        Me.lblVaConditionFlagTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVaConditionFlagTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVaConditionFlagTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblVaConditionFlagTitle.Location = New System.Drawing.Point(255, 492)
        Me.lblVaConditionFlagTitle.Name = "lblVaConditionFlagTitle"
        Me.lblVaConditionFlagTitle.Size = New System.Drawing.Size(109, 17)
        Me.lblVaConditionFlagTitle.TabIndex = 45
        Me.lblVaConditionFlagTitle.Text = "有効/無効"
        Me.lblVaConditionFlagTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblInstruction
        '
        Me.lblInstruction.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInstruction.ForeColor = System.Drawing.Color.Red
        Me.lblInstruction.Location = New System.Drawing.Point(11, 156)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(349, 42)
        Me.lblInstruction.TabIndex = 44
        Me.lblInstruction.Text = "<< 表面処理装置 バッチ組仕様 >>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"製品ロット ⇒ モニタロット ⇒ フィルダミーロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"の順でバッチ組してください。"
        '
        'lblBatLotWFCnt
        '
        Me.lblBatLotWFCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBatLotWFCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatLotWFCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatLotWFCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBatLotWFCnt.Location = New System.Drawing.Point(260, 129)
        Me.lblBatLotWFCnt.Name = "lblBatLotWFCnt"
        Me.lblBatLotWFCnt.Size = New System.Drawing.Size(105, 21)
        Me.lblBatLotWFCnt.TabIndex = 41
        Me.lblBatLotWFCnt.Text = "10"
        Me.lblBatLotWFCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVaCondition
        '
        Me.lblVaCondition.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblVaCondition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVaCondition.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVaCondition.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVaCondition.Location = New System.Drawing.Point(7, 509)
        Me.lblVaCondition.Name = "lblVaCondition"
        Me.lblVaCondition.Size = New System.Drawing.Size(249, 21)
        Me.lblVaCondition.TabIndex = 40
        Me.lblVaCondition.Text = "123456789012345678901234567890"
        '
        'lblVaConditionTitle
        '
        Me.lblVaConditionTitle.BackColor = System.Drawing.Color.Navy
        Me.lblVaConditionTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVaConditionTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVaConditionTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblVaConditionTitle.Location = New System.Drawing.Point(7, 492)
        Me.lblVaConditionTitle.Name = "lblVaConditionTitle"
        Me.lblVaConditionTitle.Size = New System.Drawing.Size(249, 17)
        Me.lblVaConditionTitle.TabIndex = 39
        Me.lblVaConditionTitle.Text = "蒸着処理条件"
        Me.lblVaConditionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMaxLotCnt
        '
        Me.lblMaxLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMaxLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMaxLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMaxLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMaxLotCnt.Location = New System.Drawing.Point(135, 83)
        Me.lblMaxLotCnt.Name = "lblMaxLotCnt"
        Me.lblMaxLotCnt.Size = New System.Drawing.Size(120, 21)
        Me.lblMaxLotCnt.TabIndex = 34
        Me.lblMaxLotCnt.Text = "10"
        Me.lblMaxLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(135, 66)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(120, 17)
        Me.lblTitle6.TabIndex = 33
        Me.lblTitle6.Text = "最大ロット数"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(6, 21)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(248, 17)
        Me.lblTitle1.TabIndex = 32
        Me.lblTitle1.Text = "装置名"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(7, 66)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(120, 17)
        Me.lblTitle3.TabIndex = 28
        Me.lblTitle3.Text = "バッチID"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBatchId
        '
        Me.lblBatchId.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBatchId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatchId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatchId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBatchId.Location = New System.Drawing.Point(7, 83)
        Me.lblBatchId.Name = "lblBatchId"
        Me.lblBatchId.Size = New System.Drawing.Size(120, 21)
        Me.lblBatchId.TabIndex = 27
        Me.lblBatchId.Text = "BMMDD999"
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(7, 112)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(248, 17)
        Me.lblTitle2.TabIndex = 26
        Me.lblTitle2.Text = "レシピ"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRecipeId
        '
        Me.lblRecipeId.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblRecipeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecipeId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRecipeId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRecipeId.Location = New System.Drawing.Point(7, 129)
        Me.lblRecipeId.Name = "lblRecipeId"
        Me.lblRecipeId.Size = New System.Drawing.Size(248, 21)
        Me.lblRecipeId.TabIndex = 25
        Me.lblRecipeId.Text = "123456789012345678901234567890"
        '
        'lblTitleInspect
        '
        Me.lblTitleInspect.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.lblTitleInspect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleInspect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleInspect.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTitleInspect.Location = New System.Drawing.Point(512, 24)
        Me.lblTitleInspect.Name = "lblTitleInspect"
        Me.lblTitleInspect.Size = New System.Drawing.Size(153, 17)
        Me.lblTitleInspect.TabIndex = 56
        Me.lblTitleInspect.Text = "異物検査S1未処理"
        Me.lblTitleInspect.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleCfLot
        '
        Me.lblTitleCfLot.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleCfLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleCfLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleCfLot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTitleCfLot.Location = New System.Drawing.Point(664, 24)
        Me.lblTitleCfLot.Name = "lblTitleCfLot"
        Me.lblTitleCfLot.Size = New System.Drawing.Size(57, 17)
        Me.lblTitleCfLot.TabIndex = 55
        Me.lblTitleCfLot.Text = "CFﾛｯﾄ"
        Me.lblTitleCfLot.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitlePair
        '
        Me.lblTitlePair.BackColor = System.Drawing.Color.Yellow
        Me.lblTitlePair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitlePair.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitlePair.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTitlePair.Location = New System.Drawing.Point(512, 8)
        Me.lblTitlePair.Name = "lblTitlePair"
        Me.lblTitlePair.Size = New System.Drawing.Size(209, 17)
        Me.lblTitlePair.TabIndex = 54
        Me.lblTitlePair.Text = "表面処理ﾊﾞｯﾁ確定"
        Me.lblTitlePair.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotListCnt
        '
        Me.lblLotListCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotListCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotListCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotListCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotListCnt.Location = New System.Drawing.Point(434, 22)
        Me.lblLotListCnt.Name = "lblLotListCnt"
        Me.lblLotListCnt.Size = New System.Drawing.Size(73, 22)
        Me.lblLotListCnt.TabIndex = 38
        Me.lblLotListCnt.Text = "10"
        Me.lblLotListCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(434, 5)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle5.TabIndex = 37
        Me.lblTitle5.Text = "該当件数"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(310, 22)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(121, 22)
        Me.lblNowDate.TabIndex = 36
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(310, 5)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle4.TabIndex = 35
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTitle7.Location = New System.Drawing.Point(740, 24)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(231, 21)
        Me.lblTitle7.TabIndex = 30
        Me.lblTitle7.Text = "△：候補　○：自動　◎：確定"
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 5)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(204, 17)
        Me.lblTitle0.TabIndex = 22
        Me.lblTitle0.Text = "バッチ装置グループ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdMoveAll
        '
        Me.cmdMoveAll.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMoveAll.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMoveAll.Location = New System.Drawing.Point(511, 189)
        Me.cmdMoveAll.Name = "cmdMoveAll"
        Me.cmdMoveAll.Size = New System.Drawing.Size(85, 40)
        Me.cmdMoveAll.TabIndex = 57
        Me.cmdMoveAll.Text = ">>"
        '
        'frmxxEN00M0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdMoveAll)
        Me.Controls.Add(Me.cmdVsfProductDisp)
        Me.Controls.Add(Me.cmdLotConnectedInfoDisp)
        Me.Controls.Add(Me.cmdDummySelect)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdLotList)
        Me.Controls.Add(Me.cmdMove)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdMonitorLotList)
        Me.Controls.Add(Me.fraBatList)
        Me.Controls.Add(Me.fraProduct)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdKakutei)
        Me.Controls.Add(Me.cmbMcGpName)
        Me.Controls.Add(Me.fraBat)
        Me.Controls.Add(Me.lblTitleInspect)
        Me.Controls.Add(Me.lblTitleCfLot)
        Me.Controls.Add(Me.lblTitlePair)
        Me.Controls.Add(Me.lblLotListCnt)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblTitle0)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00M0"
        Me.Text = "バッチ管理"
        Me.fraBatList.ResumeLayout(false)
        CType(Me.vsfBatList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraProduct.ResumeLayout(false)
        CType(Me.vsfProduct,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraBat.ResumeLayout(false)
        CType(Me.vsfBat,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdVsfProductDisp As Button
    Friend WithEvents cmdLotConnectedInfoDisp As Button
    Friend WithEvents cmdDummySelect As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdLotList As Button
    Friend WithEvents cmdMove As Button
    Friend WithEvents cmdRemove As Button
    Friend WithEvents cmdMonitorLotList As Button
    Friend WithEvents fraBatList As GroupBox
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents vsfBatList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraProduct As GroupBox
    Friend WithEvents optKubun0 As RadioButton
    Friend WithEvents optKubun2 As RadioButton
    Friend WithEvents optKubun3 As RadioButton
    Friend WithEvents optKubun1 As RadioButton
    Friend WithEvents vsfProduct As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblBackReason As Label
    Friend WithEvents lblProductWpList As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdKakutei As Button
    Friend WithEvents cmbMcGpName As SEComboBoxEx.ComboBoxEx
    Friend WithEvents fraBat As GroupBox
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents vsfBat As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbWpName As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblMethod As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblMesModeId As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblBatLotWFCntTitle As Label
    Friend WithEvents lblVaConditionFlag As Label
    Friend WithEvents lblVaConditionFlagTitle As Label
    Friend WithEvents lblInstruction As Label
    Friend WithEvents lblBatLotWFCnt As Label
    Friend WithEvents lblVaCondition As Label
    Friend WithEvents lblVaConditionTitle As Label
    Friend WithEvents lblMaxLotCnt As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblBatchId As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblRecipeId As Label
    Friend WithEvents lblTitleInspect As Label
    Friend WithEvents lblTitleCfLot As Label
    Friend WithEvents lblTitlePair As Label
    Friend WithEvents lblLotListCnt As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents cmdMoveAll As Button
End Class
