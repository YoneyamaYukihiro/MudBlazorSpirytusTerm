<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02O0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02O0))
        Me.fraRestrictFlow = New System.Windows.Forms.GroupBox()
        Me.vsfFlow = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraRestrictWp = New System.Windows.Forms.GroupBox()
        Me.vsfWp = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdKakutei = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbRestrictType = New SEComboBoxEx.ComboBoxEx()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblNowDateTitle = New System.Windows.Forms.Label()
        Me.lblRestrictNameTitle = New System.Windows.Forms.Label()
        Me.fraRestrictFlow.SuspendLayout
        CType(Me.vsfFlow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraRestrictWp.SuspendLayout
        CType(Me.vsfWp,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraRestrictFlow
        '
        Me.fraRestrictFlow.Controls.Add(Me.vsfFlow)
        Me.fraRestrictFlow.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraRestrictFlow.Location = New System.Drawing.Point(2, 70)
        Me.fraRestrictFlow.Name = "fraRestrictFlow"
        Me.fraRestrictFlow.Size = New System.Drawing.Size(975, 299)
        Me.fraRestrictFlow.TabIndex = 9
        Me.fraRestrictFlow.TabStop = false
        Me.fraRestrictFlow.Text = "ロット保留・設定"
        '
        'vsfFlow
        '
        Me.vsfFlow.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfFlow.AllowEditing = false
        Me.vsfFlow.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfFlow.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfFlow.AutoSearchDelay = 2R
        Me.vsfFlow.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfFlow.ColumnInfo = resources.GetString("vsfFlow.ColumnInfo")
        Me.vsfFlow.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfFlow.ExtendLastCol = true
        Me.vsfFlow.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfFlow.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.vsfFlow.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfFlow.Location = New System.Drawing.Point(4, 20)
        Me.vsfFlow.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFlow.Name = "vsfFlow"
        Me.vsfFlow.Rows.Count = 40
        Me.vsfFlow.Rows.DefaultSize = 18
        Me.vsfFlow.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFlow.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfFlow.Size = New System.Drawing.Size(965, 269)
        Me.vsfFlow.StyleInfo = resources.GetString("vsfFlow.StyleInfo")
        Me.vsfFlow.TabIndex = 10
        Me.vsfFlow.TabStop = false
        '
        'fraRestrictWp
        '
        Me.fraRestrictWp.Controls.Add(Me.vsfWp)
        Me.fraRestrictWp.Controls.Add(Me.lblInfo)
        Me.fraRestrictWp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraRestrictWp.Location = New System.Drawing.Point(2, 374)
        Me.fraRestrictWp.Name = "fraRestrictWp"
        Me.fraRestrictWp.Size = New System.Drawing.Size(975, 205)
        Me.fraRestrictWp.TabIndex = 7
        Me.fraRestrictWp.TabStop = false
        Me.fraRestrictWp.Text = "ロット保留解除・設定"
        '
        'vsfWp
        '
        Me.vsfWp.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWp.AllowEditing = false
        Me.vsfWp.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWp.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfWp.AutoSearchDelay = 2R
        Me.vsfWp.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWp.ColumnInfo = resources.GetString("vsfWp.ColumnInfo")
        Me.vsfWp.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWp.ExtendLastCol = true
        Me.vsfWp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWp.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.vsfWp.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWp.Location = New System.Drawing.Point(4, 26)
        Me.vsfWp.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWp.Name = "vsfWp"
        Me.vsfWp.Rows.Count = 40
        Me.vsfWp.Rows.DefaultSize = 18
        Me.vsfWp.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWp.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfWp.Size = New System.Drawing.Size(966, 171)
        Me.vsfWp.StyleInfo = resources.GetString("vsfWp.StyleInfo")
        Me.vsfWp.TabIndex = 8
        Me.vsfWp.TabStop = false
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInfo.Location = New System.Drawing.Point(480, 12)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(487, 11)
        Me.lblInfo.TabIndex = 11
        Me.lblInfo.Text = "時間制限・処理待在庫数：1-9"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(705, 7)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(105, 57)
        Me.cmdSearch.TabIndex = 2
        Me.cmdSearch.Text = "最新取得"
        '
        'cmdKakutei
        '
        Me.cmdKakutei.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKakutei.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKakutei.Location = New System.Drawing.Point(872, 581)
        Me.cmdKakutei.Name = "cmdKakutei"
        Me.cmdKakutei.Size = New System.Drawing.Size(101, 56)
        Me.cmdKakutei.TabIndex = 1
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
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "閉じる"
        '
        'cmbRestrictType
        '
        Me.cmbRestrictType.DirectInput = false
        Me.cmbRestrictType.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRestrictType.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRestrictType.Location = New System.Drawing.Point(8, 24)
        Me.cmbRestrictType.Name = "cmbRestrictType"
        Me.cmbRestrictType.Size = New System.Drawing.Size(683, 28)
        Me.cmbRestrictType.TabIndex = 6
        Me.cmbRestrictType.Value = Nothing
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(816, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(161, 30)
        Me.lblNowDate.TabIndex = 5
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
        Me.lblNowDateTitle.TabIndex = 4
        Me.lblNowDateTitle.Text = "情報取得日時"
        Me.lblNowDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRestrictNameTitle
        '
        Me.lblRestrictNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRestrictNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRestrictNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRestrictNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRestrictNameTitle.Location = New System.Drawing.Point(8, 8)
        Me.lblRestrictNameTitle.Name = "lblRestrictNameTitle"
        Me.lblRestrictNameTitle.Size = New System.Drawing.Size(683, 17)
        Me.lblRestrictNameTitle.TabIndex = 3
        Me.lblRestrictNameTitle.Text = "時間制限タイプ"
        Me.lblRestrictNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02O0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.fraRestrictFlow)
        Me.Controls.Add(Me.fraRestrictWp)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdKakutei)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmbRestrictType)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblNowDateTitle)
        Me.Controls.Add(Me.lblRestrictNameTitle)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02O0"
        Me.Text = "時間制限流動設定"
        Me.fraRestrictFlow.ResumeLayout(false)
        CType(Me.vsfFlow,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraRestrictWp.ResumeLayout(false)
        CType(Me.vsfWp,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraRestrictFlow As GroupBox
    Friend WithEvents vsfFlow As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraRestrictWp As GroupBox
    Friend WithEvents vsfWp As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblInfo As Label
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdKakutei As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmbRestrictType As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblNowDateTitle As Label
    Friend WithEvents lblRestrictNameTitle As Label
End Class
