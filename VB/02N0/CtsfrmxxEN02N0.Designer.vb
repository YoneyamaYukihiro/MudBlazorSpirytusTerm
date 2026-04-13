<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02N0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02N0))
        Me.fraWaitingLotList = New System.Windows.Forms.GroupBox()
        Me.vsfLot = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblInfo2 = New System.Windows.Forms.Label()
        Me.lblInfo1 = New System.Windows.Forms.Label()
        Me.lblInfo0 = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdKakutei = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbBatchCompse = New SEComboBoxEx.ComboBoxEx()
        Me.vsfRecipe = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbMcGroup = New SEComboBoxEx.ComboBoxEx()
        Me.cmbWpName = New SEComboBoxEx.ComboBoxEx()
        Me.lblMesModeTitle = New System.Windows.Forms.Label()
        Me.lblMesMode = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblNowDateTitle = New System.Windows.Forms.Label()
        Me.lblMcGroupNameTitle = New System.Windows.Forms.Label()
        Me.lblWpIDTitle = New System.Windows.Forms.Label()
        Me.lblBatchComposeEmp = New System.Windows.Forms.Label()
        Me.lblBatchComposeEmpTitle = New System.Windows.Forms.Label()
        Me.lblBatchComposeDate = New System.Windows.Forms.Label()
        Me.lblBatchComposeDateTitle = New System.Windows.Forms.Label()
        Me.lblBatchComposeTitle = New System.Windows.Forms.Label()
        Me.fraWaitingLotList.SuspendLayout
        CType(Me.vsfLot,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfRecipe,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraWaitingLotList
        '
        Me.fraWaitingLotList.Controls.Add(Me.vsfLot)
        Me.fraWaitingLotList.Controls.Add(Me.lblInfo2)
        Me.fraWaitingLotList.Controls.Add(Me.lblInfo1)
        Me.fraWaitingLotList.Controls.Add(Me.lblInfo0)
        Me.fraWaitingLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraWaitingLotList.Location = New System.Drawing.Point(4, 314)
        Me.fraWaitingLotList.Name = "fraWaitingLotList"
        Me.fraWaitingLotList.Size = New System.Drawing.Size(971, 263)
        Me.fraWaitingLotList.TabIndex = 16
        Me.fraWaitingLotList.TabStop = false
        Me.fraWaitingLotList.Text = "バッチ編成待ちロット一覧"
        '
        'vsfLot
        '
        Me.vsfLot.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLot.AllowEditing = false
        Me.vsfLot.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLot.AutoSearchDelay = 2R
        Me.vsfLot.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLot.ColumnInfo = resources.GetString("vsfLot.ColumnInfo")
        Me.vsfLot.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLot.ExtendLastCol = true
        Me.vsfLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLot.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfLot.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLot.Location = New System.Drawing.Point(4, 32)
        Me.vsfLot.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLot.Name = "vsfLot"
        Me.vsfLot.Rows.Count = 40
        Me.vsfLot.Rows.DefaultSize = 18
        Me.vsfLot.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLot.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLot.Size = New System.Drawing.Size(964, 222)
        Me.vsfLot.StyleInfo = resources.GetString("vsfLot.StyleInfo")
        Me.vsfLot.TabIndex = 17
        '
        'lblInfo2
        '
        Me.lblInfo2.BackColor = System.Drawing.Color.Red
        Me.lblInfo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfo2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInfo2.ForeColor = System.Drawing.Color.Black
        Me.lblInfo2.Location = New System.Drawing.Point(724, 12)
        Me.lblInfo2.Name = "lblInfo2"
        Me.lblInfo2.Size = New System.Drawing.Size(149, 17)
        Me.lblInfo2.TabIndex = 22
        Me.lblInfo2.Text = "ｷｬﾘｱ位置：ｽﾄｯｶｰ外"
        Me.lblInfo2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblInfo1
        '
        Me.lblInfo1.BackColor = System.Drawing.Color.Silver
        Me.lblInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfo1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInfo1.ForeColor = System.Drawing.Color.Black
        Me.lblInfo1.Location = New System.Drawing.Point(570, 12)
        Me.lblInfo1.Name = "lblInfo1"
        Me.lblInfo1.Size = New System.Drawing.Size(153, 17)
        Me.lblInfo1.TabIndex = 21
        Me.lblInfo1.Text = "自動ﾊﾞｯﾁ編成対象外"
        Me.lblInfo1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblInfo0
        '
        Me.lblInfo0.BackColor = System.Drawing.Color.Yellow
        Me.lblInfo0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfo0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInfo0.ForeColor = System.Drawing.Color.Black
        Me.lblInfo0.Location = New System.Drawing.Point(874, 12)
        Me.lblInfo0.Name = "lblInfo0"
        Me.lblInfo0.Size = New System.Drawing.Size(91, 17)
        Me.lblInfo0.TabIndex = 20
        Me.lblInfo0.Text = "保留・停止"
        Me.lblInfo0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(705, 8)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(105, 57)
        Me.cmdSearch.TabIndex = 8
        Me.cmdSearch.Text = "最新取得"
        '
        'cmdKakutei
        '
        Me.cmdKakutei.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKakutei.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKakutei.Location = New System.Drawing.Point(872, 581)
        Me.cmdKakutei.Name = "cmdKakutei"
        Me.cmdKakutei.Size = New System.Drawing.Size(101, 56)
        Me.cmdKakutei.TabIndex = 7
        Me.cmdKakutei.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 581)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(101, 56)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "閉じる"
        '
        'cmbBatchCompse
        '
        Me.cmbBatchCompse.DirectInput = false
        Me.cmbBatchCompse.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbBatchCompse.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbBatchCompse.Location = New System.Drawing.Point(8, 82)
        Me.cmbBatchCompse.Name = "cmbBatchCompse"
        Me.cmbBatchCompse.Size = New System.Drawing.Size(151, 28)
        Me.cmbBatchCompse.TabIndex = 5
        Me.cmbBatchCompse.Value = Nothing
        '
        'vsfRecipe
        '
        Me.vsfRecipe.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfRecipe.AllowEditing = false
        Me.vsfRecipe.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfRecipe.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfRecipe.AutoSearchDelay = 2R
        Me.vsfRecipe.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfRecipe.ColumnInfo = resources.GetString("vsfRecipe.ColumnInfo")
        Me.vsfRecipe.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfRecipe.ExtendLastCol = true
        Me.vsfRecipe.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfRecipe.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never
        Me.vsfRecipe.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfRecipe.Location = New System.Drawing.Point(8, 122)
        Me.vsfRecipe.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfRecipe.Name = "vsfRecipe"
        Me.vsfRecipe.Rows.Count = 5
        Me.vsfRecipe.Rows.DefaultSize = 18
        Me.vsfRecipe.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfRecipe.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfRecipe.Size = New System.Drawing.Size(963, 181)
        Me.vsfRecipe.StyleInfo = resources.GetString("vsfRecipe.StyleInfo")
        Me.vsfRecipe.TabIndex = 13
        Me.vsfRecipe.TabStop = false
        '
        'cmbMcGroup
        '
        Me.cmbMcGroup.DirectInput = false
        Me.cmbMcGroup.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.Location = New System.Drawing.Point(8, 24)
        Me.cmbMcGroup.Name = "cmbMcGroup"
        Me.cmbMcGroup.Size = New System.Drawing.Size(335, 28)
        Me.cmbMcGroup.TabIndex = 14
        Me.cmbMcGroup.Value = Nothing
        '
        'cmbWpName
        '
        Me.cmbWpName.DirectInput = false
        Me.cmbWpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpName.Location = New System.Drawing.Point(342, 24)
        Me.cmbWpName.Name = "cmbWpName"
        Me.cmbWpName.Size = New System.Drawing.Size(360, 28)
        Me.cmbWpName.TabIndex = 15
        Me.cmbWpName.Value = Nothing
        '
        'lblMesModeTitle
        '
        Me.lblMesModeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblMesModeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMesModeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMesModeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblMesModeTitle.Location = New System.Drawing.Point(570, 66)
        Me.lblMesModeTitle.Name = "lblMesModeTitle"
        Me.lblMesModeTitle.Size = New System.Drawing.Size(97, 17)
        Me.lblMesModeTitle.TabIndex = 19
        Me.lblMesModeTitle.Text = "運用モード"
        Me.lblMesModeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMesMode
        '
        Me.lblMesMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMesMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMesMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMesMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMesMode.Location = New System.Drawing.Point(570, 82)
        Me.lblMesMode.Name = "lblMesMode"
        Me.lblMesMode.Size = New System.Drawing.Size(97, 26)
        Me.lblMesMode.TabIndex = 18
        Me.lblMesMode.Text = "M1/S1/S2"
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(816, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(161, 26)
        Me.lblNowDate.TabIndex = 12
        '
        'lblNowDateTitle
        '
        Me.lblNowDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNowDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNowDateTitle.Location = New System.Drawing.Point(816, 8)
        Me.lblNowDateTitle.Name = "lblNowDateTitle"
        Me.lblNowDateTitle.Size = New System.Drawing.Size(161, 17)
        Me.lblNowDateTitle.TabIndex = 11
        Me.lblNowDateTitle.Text = "情報取得日時"
        Me.lblNowDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMcGroupNameTitle
        '
        Me.lblMcGroupNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblMcGroupNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMcGroupNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMcGroupNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblMcGroupNameTitle.Location = New System.Drawing.Point(8, 8)
        Me.lblMcGroupNameTitle.Name = "lblMcGroupNameTitle"
        Me.lblMcGroupNameTitle.Size = New System.Drawing.Size(335, 17)
        Me.lblMcGroupNameTitle.TabIndex = 10
        Me.lblMcGroupNameTitle.Text = "バッチ装置グループ"
        Me.lblMcGroupNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWpIDTitle
        '
        Me.lblWpIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWpIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWpIDTitle.Location = New System.Drawing.Point(342, 8)
        Me.lblWpIDTitle.Name = "lblWpIDTitle"
        Me.lblWpIDTitle.Size = New System.Drawing.Size(360, 17)
        Me.lblWpIDTitle.TabIndex = 9
        Me.lblWpIDTitle.Text = "装置名"
        Me.lblWpIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBatchComposeEmp
        '
        Me.lblBatchComposeEmp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBatchComposeEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatchComposeEmp.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatchComposeEmp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBatchComposeEmp.Location = New System.Drawing.Point(372, 82)
        Me.lblBatchComposeEmp.Name = "lblBatchComposeEmp"
        Me.lblBatchComposeEmp.Size = New System.Drawing.Size(197, 26)
        Me.lblBatchComposeEmp.TabIndex = 4
        Me.lblBatchComposeEmp.Text = "エプソン　太郎"
        '
        'lblBatchComposeEmpTitle
        '
        Me.lblBatchComposeEmpTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBatchComposeEmpTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatchComposeEmpTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatchComposeEmpTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBatchComposeEmpTitle.Location = New System.Drawing.Point(372, 66)
        Me.lblBatchComposeEmpTitle.Name = "lblBatchComposeEmpTitle"
        Me.lblBatchComposeEmpTitle.Size = New System.Drawing.Size(197, 17)
        Me.lblBatchComposeEmpTitle.TabIndex = 3
        Me.lblBatchComposeEmpTitle.Text = "最終更新者"
        Me.lblBatchComposeEmpTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBatchComposeDate
        '
        Me.lblBatchComposeDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBatchComposeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatchComposeDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatchComposeDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBatchComposeDate.Location = New System.Drawing.Point(158, 82)
        Me.lblBatchComposeDate.Name = "lblBatchComposeDate"
        Me.lblBatchComposeDate.Size = New System.Drawing.Size(213, 26)
        Me.lblBatchComposeDate.TabIndex = 2
        Me.lblBatchComposeDate.Text = "2017/07/07 00:00:00"
        '
        'lblBatchComposeDateTitle
        '
        Me.lblBatchComposeDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBatchComposeDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatchComposeDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatchComposeDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBatchComposeDateTitle.Location = New System.Drawing.Point(158, 66)
        Me.lblBatchComposeDateTitle.Name = "lblBatchComposeDateTitle"
        Me.lblBatchComposeDateTitle.Size = New System.Drawing.Size(213, 17)
        Me.lblBatchComposeDateTitle.TabIndex = 1
        Me.lblBatchComposeDateTitle.Text = "最終更新日"
        Me.lblBatchComposeDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBatchComposeTitle
        '
        Me.lblBatchComposeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBatchComposeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatchComposeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatchComposeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBatchComposeTitle.Location = New System.Drawing.Point(8, 66)
        Me.lblBatchComposeTitle.Name = "lblBatchComposeTitle"
        Me.lblBatchComposeTitle.Size = New System.Drawing.Size(151, 17)
        Me.lblBatchComposeTitle.TabIndex = 0
        Me.lblBatchComposeTitle.Text = "編成方式"
        Me.lblBatchComposeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02N0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblBatchComposeDateTitle)
        Me.Controls.Add(Me.lblBatchComposeDate)
        Me.Controls.Add(Me.lblBatchComposeTitle)
        Me.Controls.Add(Me.lblWpIDTitle)
        Me.Controls.Add(Me.lblMcGroupNameTitle)
        Me.Controls.Add(Me.fraWaitingLotList)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdKakutei)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmbBatchCompse)
        Me.Controls.Add(Me.vsfRecipe)
        Me.Controls.Add(Me.cmbMcGroup)
        Me.Controls.Add(Me.cmbWpName)
        Me.Controls.Add(Me.lblMesModeTitle)
        Me.Controls.Add(Me.lblMesMode)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblNowDateTitle)
        Me.Controls.Add(Me.lblBatchComposeEmp)
        Me.Controls.Add(Me.lblBatchComposeEmpTitle)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02N0"
        Me.Text = "ﾊﾞｯﾁ編成設定"
        Me.fraWaitingLotList.ResumeLayout(false)
        CType(Me.vsfLot,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfRecipe,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraWaitingLotList As GroupBox
    Friend WithEvents vsfLot As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblInfo2 As Label
    Friend WithEvents lblInfo1 As Label
    Friend WithEvents lblInfo0 As Label
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdKakutei As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmbBatchCompse As SEComboBoxEx.ComboBoxEx
    Friend WithEvents vsfRecipe As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbMcGroup As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbWpName As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblMesModeTitle As Label
    Friend WithEvents lblMesMode As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblNowDateTitle As Label
    Friend WithEvents lblMcGroupNameTitle As Label
    Friend WithEvents lblWpIDTitle As Label
    Friend WithEvents lblBatchComposeEmp As Label
    Friend WithEvents lblBatchComposeEmpTitle As Label
    Friend WithEvents lblBatchComposeDate As Label
    Friend WithEvents lblBatchComposeDateTitle As Label
    Friend WithEvents lblBatchComposeTitle As Label
End Class
