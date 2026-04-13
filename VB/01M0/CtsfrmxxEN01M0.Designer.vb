<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01M0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01M0))
        Me.tabReticle = New System.Windows.Forms.TabControl()
        Me.Tab0 = New System.Windows.Forms.TabPage()
        Me.fraWpLot = New System.Windows.Forms.Panel()
        Me.cmdReticleMove = New System.Windows.Forms.Button()
        Me.cmdStockerMove = New System.Windows.Forms.Button()
        Me.cmdWpDown = New System.Windows.Forms.Button()
        Me.cmdWpUP = New System.Windows.Forms.Button()
        Me.cmdNowListWpLot = New System.Windows.Forms.Button()
        Me.vsfWP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbWplistWpLot = New SECmbIchiran.ComboIchiran()
        Me.cmbStockerWpLot = New SECmbIchiran.ComboIchiran()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSmif = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblStatusWpLot = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblModeWpLot = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblFtsModeWpLot = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblNowDateWplot = New System.Windows.Forms.Label()
        Me.lblLotCntWp = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.fraSmif = New System.Windows.Forms.Panel()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.cmdSmifDown = New System.Windows.Forms.Button()
        Me.cmdSmifUP = New System.Windows.Forms.Button()
        Me.cmdNowListSmif = New System.Windows.Forms.Button()
        Me.cmdWpMove = New System.Windows.Forms.Button()
        Me.vsfSMIF = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbWplistSmif = New SECmbIchiran.ComboIchiran()
        Me.cmbStockerSmif = New SECmbIchiran.ComboIchiran()
        Me.lblTitle14 = New System.Windows.Forms.Label()
        Me.lblStatusSmif = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblModeSmif = New System.Windows.Forms.Label()
        Me.lblTitle13 = New System.Windows.Forms.Label()
        Me.lblTitle12 = New System.Windows.Forms.Label()
        Me.lblFtsModeSmif = New System.Windows.Forms.Label()
        Me.lblTitle11 = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblLotCntSmif = New System.Windows.Forms.Label()
        Me.lblNowDateSmif = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.tabReticle.SuspendLayout
        Me.Tab0.SuspendLayout
        Me.fraWpLot.SuspendLayout
        CType(Me.vsfWP,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab1.SuspendLayout
        Me.fraSmif.SuspendLayout
        CType(Me.vsfSMIF,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'tabReticle
        '
        Me.tabReticle.CausesValidation = false
        Me.tabReticle.Controls.Add(Me.Tab0)
        Me.tabReticle.Controls.Add(Me.Tab1)
        Me.tabReticle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.tabReticle.ItemSize = New System.Drawing.Size(486, 37)
        Me.tabReticle.Location = New System.Drawing.Point(2, 8)
        Me.tabReticle.Name = "tabReticle"
        Me.tabReticle.SelectedIndex = 0
        Me.tabReticle.Size = New System.Drawing.Size(975, 574)
        Me.tabReticle.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabReticle.TabIndex = 16
        '
        'Tab0
        '
        Me.Tab0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab0.Controls.Add(Me.fraWpLot)
        Me.Tab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab0.ForeColor = System.Drawing.Color.Black
        Me.Tab0.Location = New System.Drawing.Point(4, 41)
        Me.Tab0.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab0.Name = "Tab0"
        Me.Tab0.Size = New System.Drawing.Size(967, 529)
        Me.Tab0.TabIndex = 0
        Me.Tab0.Text = "装置　→　ストッカー"
        '
        'fraWpLot
        '
        Me.fraWpLot.Controls.Add(Me.cmdReticleMove)
        Me.fraWpLot.Controls.Add(Me.cmdStockerMove)
        Me.fraWpLot.Controls.Add(Me.cmdWpDown)
        Me.fraWpLot.Controls.Add(Me.cmdWpUP)
        Me.fraWpLot.Controls.Add(Me.cmdNowListWpLot)
        Me.fraWpLot.Controls.Add(Me.vsfWP)
        Me.fraWpLot.Controls.Add(Me.cmbWplistWpLot)
        Me.fraWpLot.Controls.Add(Me.cmbStockerWpLot)
        Me.fraWpLot.Controls.Add(Me.Label1)
        Me.fraWpLot.Controls.Add(Me.lblSmif)
        Me.fraWpLot.Controls.Add(Me.lblTitle7)
        Me.fraWpLot.Controls.Add(Me.lblTitle6)
        Me.fraWpLot.Controls.Add(Me.lblStatusWpLot)
        Me.fraWpLot.Controls.Add(Me.lblTitle4)
        Me.fraWpLot.Controls.Add(Me.lblModeWpLot)
        Me.fraWpLot.Controls.Add(Me.lblTitle1)
        Me.fraWpLot.Controls.Add(Me.lblTitle0)
        Me.fraWpLot.Controls.Add(Me.lblFtsModeWpLot)
        Me.fraWpLot.Controls.Add(Me.lblTitle5)
        Me.fraWpLot.Controls.Add(Me.lblTitle3)
        Me.fraWpLot.Controls.Add(Me.lblNowDateWplot)
        Me.fraWpLot.Controls.Add(Me.lblLotCntWp)
        Me.fraWpLot.Controls.Add(Me.lblTitle2)
        Me.fraWpLot.Location = New System.Drawing.Point(8, 5)
        Me.fraWpLot.Name = "fraWpLot"
        Me.fraWpLot.Size = New System.Drawing.Size(957, 523)
        Me.fraWpLot.TabIndex = 18
        '
        'cmdReticleMove
        '
        Me.cmdReticleMove.CausesValidation = false
        Me.cmdReticleMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReticleMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdReticleMove.Location = New System.Drawing.Point(736, 464)
        Me.cmdReticleMove.Name = "cmdReticleMove"
        Me.cmdReticleMove.Size = New System.Drawing.Size(105, 57)
        Me.cmdReticleMove.TabIndex = 7
        Me.cmdReticleMove.Text = "レチクル"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"払い出し"
        '
        'cmdStockerMove
        '
        Me.cmdStockerMove.CausesValidation = false
        Me.cmdStockerMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdStockerMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdStockerMove.Location = New System.Drawing.Point(846, 464)
        Me.cmdStockerMove.Name = "cmdStockerMove"
        Me.cmdStockerMove.Size = New System.Drawing.Size(105, 57)
        Me.cmdStockerMove.TabIndex = 6
        Me.cmdStockerMove.Text = "ストッカー"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"へ搬送"
        '
        'cmdWpDown
        '
        Me.cmdWpDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWpDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWpDown.Location = New System.Drawing.Point(902, 289)
        Me.cmdWpDown.Name = "cmdWpDown"
        Me.cmdWpDown.Size = New System.Drawing.Size(49, 166)
        Me.cmdWpDown.TabIndex = 5
        Me.cmdWpDown.Text = "▼"
        '
        'cmdWpUP
        '
        Me.cmdWpUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWpUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWpUP.Location = New System.Drawing.Point(902, 123)
        Me.cmdWpUP.Name = "cmdWpUP"
        Me.cmdWpUP.Size = New System.Drawing.Size(49, 166)
        Me.cmdWpUP.TabIndex = 4
        Me.cmdWpUP.Text = "▲"
        '
        'cmdNowListWpLot
        '
        Me.cmdNowListWpLot.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowListWpLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowListWpLot.Location = New System.Drawing.Point(604, 62)
        Me.cmdNowListWpLot.Name = "cmdNowListWpLot"
        Me.cmdNowListWpLot.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowListWpLot.TabIndex = 2
        Me.cmdNowListWpLot.Text = "最新取得"
        '
        'vsfWP
        '
        Me.vsfWP.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWP.AllowEditing = false
        Me.vsfWP.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWP.AutoSearchDelay = 2R
        Me.vsfWP.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWP.ColumnInfo = resources.GetString("vsfWP.ColumnInfo")
        Me.vsfWP.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWP.ExtendLastCol = true
        Me.vsfWP.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWP.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWP.Location = New System.Drawing.Point(0, 124)
        Me.vsfWP.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWP.Name = "vsfWP"
        Me.vsfWP.Rows.Count = 11
        Me.vsfWP.Rows.DefaultSize = 18
        Me.vsfWP.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfWP.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWP.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfWP.Size = New System.Drawing.Size(902, 330)
        Me.vsfWP.StyleInfo = resources.GetString("vsfWP.StyleInfo")
        Me.vsfWP.TabIndex = 3
        '
        'cmbWplistWpLot
        '
        Me.cmbWplistWpLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWplistWpLot.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWplistWpLot.GridForeColor = System.Drawing.Color.Black
        Me.cmbWplistWpLot.Location = New System.Drawing.Point(0, 23)
        Me.cmbWplistWpLot.Name = "cmbWplistWpLot"
        Me.cmbWplistWpLot.Size = New System.Drawing.Size(428, 28)
        Me.cmbWplistWpLot.TabIndex = 0
        Me.cmbWplistWpLot.Value = Nothing
        '
        'cmbStockerWpLot
        '
        Me.cmbStockerWpLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStockerWpLot.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStockerWpLot.Location = New System.Drawing.Point(0, 77)
        Me.cmbStockerWpLot.Name = "cmbStockerWpLot"
        Me.cmbStockerWpLot.Size = New System.Drawing.Size(428, 28)
        Me.cmbStockerWpLot.TabIndex = 1
        Me.cmbStockerWpLot.Value = Nothing
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(6, 504)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(385, 15)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "このタブを選んだままチェックインして下さい。"
        Me.Label1.Visible = false
        '
        'lblSmif
        '
        Me.lblSmif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSmif.ForeColor = System.Drawing.Color.Black
        Me.lblSmif.Location = New System.Drawing.Point(562, 23)
        Me.lblSmif.Name = "lblSmif"
        Me.lblSmif.Size = New System.Drawing.Size(127, 30)
        Me.lblSmif.TabIndex = 42
        Me.lblSmif.Text = "F30001"
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(562, 6)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(127, 17)
        Me.lblTitle7.TabIndex = 41
        Me.lblTitle7.Text = "SMIF"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(431, 6)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(127, 17)
        Me.lblTitle6.TabIndex = 40
        Me.lblTitle6.Text = "ﾚﾁｸﾙﾎﾟｰﾄ状態"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatusWpLot
        '
        Me.lblStatusWpLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusWpLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatusWpLot.ForeColor = System.Drawing.Color.Black
        Me.lblStatusWpLot.Location = New System.Drawing.Point(431, 23)
        Me.lblStatusWpLot.Name = "lblStatusWpLot"
        Me.lblStatusWpLot.Size = New System.Drawing.Size(127, 30)
        Me.lblStatusWpLot.TabIndex = 39
        Me.lblStatusWpLot.Text = "搬送可能"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(0, 60)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(428, 17)
        Me.lblTitle4.TabIndex = 38
        Me.lblTitle4.Text = "搬送先ストッカー"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblModeWpLot
        '
        Me.lblModeWpLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModeWpLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblModeWpLot.ForeColor = System.Drawing.Color.Black
        Me.lblModeWpLot.Location = New System.Drawing.Point(693, 23)
        Me.lblModeWpLot.Name = "lblModeWpLot"
        Me.lblModeWpLot.Size = New System.Drawing.Size(127, 30)
        Me.lblModeWpLot.TabIndex = 28
        Me.lblModeWpLot.Text = "S1"
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(693, 6)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(127, 17)
        Me.lblTitle1.TabIndex = 27
        Me.lblTitle1.Text = "運用モード"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(824, 6)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(131, 17)
        Me.lblTitle0.TabIndex = 26
        Me.lblTitle0.Text = "搬送モード"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFtsModeWpLot
        '
        Me.lblFtsModeWpLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFtsModeWpLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFtsModeWpLot.ForeColor = System.Drawing.Color.Black
        Me.lblFtsModeWpLot.Location = New System.Drawing.Point(824, 23)
        Me.lblFtsModeWpLot.Name = "lblFtsModeWpLot"
        Me.lblFtsModeWpLot.Size = New System.Drawing.Size(131, 30)
        Me.lblFtsModeWpLot.TabIndex = 25
        Me.lblFtsModeWpLot.Text = "搬送指示不可"
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(0, 6)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(428, 17)
        Me.lblTitle5.TabIndex = 24
        Me.lblTitle5.Text = "レチクル使用装置"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(715, 62)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle3.TabIndex = 23
        Me.lblTitle3.Text = "情報取得日時"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDateWplot
        '
        Me.lblNowDateWplot.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDateWplot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateWplot.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDateWplot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDateWplot.Location = New System.Drawing.Point(715, 79)
        Me.lblNowDateWplot.Name = "lblNowDateWplot"
        Me.lblNowDateWplot.Size = New System.Drawing.Size(151, 30)
        Me.lblNowDateWplot.TabIndex = 22
        Me.lblNowDateWplot.Text = "07/15 14:11:25"
        '
        'lblLotCntWp
        '
        Me.lblLotCntWp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCntWp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntWp.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCntWp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCntWp.Location = New System.Drawing.Point(870, 79)
        Me.lblLotCntWp.Name = "lblLotCntWp"
        Me.lblLotCntWp.Size = New System.Drawing.Size(85, 30)
        Me.lblLotCntWp.TabIndex = 21
        Me.lblLotCntWp.Text = "0"
        Me.lblLotCntWp.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(870, 62)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(85, 17)
        Me.lblTitle2.TabIndex = 20
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab1.Controls.Add(Me.fraSmif)
        Me.Tab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab1.ForeColor = System.Drawing.Color.Black
        Me.Tab1.Location = New System.Drawing.Point(4, 41)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(967, 529)
        Me.Tab1.TabIndex = 1
        Me.Tab1.Text = "ストッカー　→　装置"
        '
        'fraSmif
        '
        Me.fraSmif.Controls.Add(Me.cmdShip)
        Me.fraSmif.Controls.Add(Me.cmdSmifDown)
        Me.fraSmif.Controls.Add(Me.cmdSmifUP)
        Me.fraSmif.Controls.Add(Me.cmdNowListSmif)
        Me.fraSmif.Controls.Add(Me.cmdWpMove)
        Me.fraSmif.Controls.Add(Me.vsfSMIF)
        Me.fraSmif.Controls.Add(Me.cmbWplistSmif)
        Me.fraSmif.Controls.Add(Me.cmbStockerSmif)
        Me.fraSmif.Controls.Add(Me.lblTitle14)
        Me.fraSmif.Controls.Add(Me.lblStatusSmif)
        Me.fraSmif.Controls.Add(Me.lblTitle8)
        Me.fraSmif.Controls.Add(Me.lblModeSmif)
        Me.fraSmif.Controls.Add(Me.lblTitle13)
        Me.fraSmif.Controls.Add(Me.lblTitle12)
        Me.fraSmif.Controls.Add(Me.lblFtsModeSmif)
        Me.fraSmif.Controls.Add(Me.lblTitle11)
        Me.fraSmif.Controls.Add(Me.lblTitle10)
        Me.fraSmif.Controls.Add(Me.lblLotCntSmif)
        Me.fraSmif.Controls.Add(Me.lblNowDateSmif)
        Me.fraSmif.Controls.Add(Me.lblTitle9)
        Me.fraSmif.Location = New System.Drawing.Point(8, 5)
        Me.fraSmif.Name = "fraSmif"
        Me.fraSmif.Size = New System.Drawing.Size(957, 523)
        Me.fraSmif.TabIndex = 19
        Me.fraSmif.Text = "Frame1"
        '
        'cmdShip
        '
        Me.cmdShip.CausesValidation = false
        Me.cmdShip.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdShip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdShip.Location = New System.Drawing.Point(846, 464)
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.Size = New System.Drawing.Size(105, 57)
        Me.cmdShip.TabIndex = 14
        Me.cmdShip.Text = "出庫指示"
        '
        'cmdSmifDown
        '
        Me.cmdSmifDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSmifDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSmifDown.Location = New System.Drawing.Point(902, 289)
        Me.cmdSmifDown.Name = "cmdSmifDown"
        Me.cmdSmifDown.Size = New System.Drawing.Size(49, 166)
        Me.cmdSmifDown.TabIndex = 13
        Me.cmdSmifDown.Text = "▼"
        '
        'cmdSmifUP
        '
        Me.cmdSmifUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSmifUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSmifUP.Location = New System.Drawing.Point(902, 123)
        Me.cmdSmifUP.Name = "cmdSmifUP"
        Me.cmdSmifUP.Size = New System.Drawing.Size(49, 166)
        Me.cmdSmifUP.TabIndex = 12
        Me.cmdSmifUP.Text = "▲"
        '
        'cmdNowListSmif
        '
        Me.cmdNowListSmif.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowListSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowListSmif.Location = New System.Drawing.Point(604, 62)
        Me.cmdNowListSmif.Name = "cmdNowListSmif"
        Me.cmdNowListSmif.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowListSmif.TabIndex = 10
        Me.cmdNowListSmif.Text = "最新取得"
        '
        'cmdWpMove
        '
        Me.cmdWpMove.CausesValidation = false
        Me.cmdWpMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWpMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWpMove.Location = New System.Drawing.Point(736, 464)
        Me.cmdWpMove.Name = "cmdWpMove"
        Me.cmdWpMove.Size = New System.Drawing.Size(105, 57)
        Me.cmdWpMove.TabIndex = 15
        Me.cmdWpMove.Text = "装置へ搬送"
        '
        'vsfSMIF
        '
        Me.vsfSMIF.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSMIF.AllowEditing = false
        Me.vsfSMIF.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSMIF.AutoSearchDelay = 2R
        Me.vsfSMIF.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSMIF.ColumnInfo = resources.GetString("vsfSMIF.ColumnInfo")
        Me.vsfSMIF.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSMIF.ExtendLastCol = true
        Me.vsfSMIF.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfSMIF.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSMIF.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSMIF.Location = New System.Drawing.Point(0, 124)
        Me.vsfSMIF.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSMIF.Name = "vsfSMIF"
        Me.vsfSMIF.Rows.Count = 30
        Me.vsfSMIF.Rows.DefaultSize = 18
        Me.vsfSMIF.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSMIF.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSMIF.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSMIF.Size = New System.Drawing.Size(902, 330)
        Me.vsfSMIF.StyleInfo = resources.GetString("vsfSMIF.StyleInfo")
        Me.vsfSMIF.TabIndex = 11
        '
        'cmbWplistSmif
        '
        Me.cmbWplistSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWplistSmif.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWplistSmif.GridForeColor = System.Drawing.Color.Black
        Me.cmbWplistSmif.Location = New System.Drawing.Point(0, 23)
        Me.cmbWplistSmif.Name = "cmbWplistSmif"
        Me.cmbWplistSmif.Size = New System.Drawing.Size(428, 28)
        Me.cmbWplistSmif.TabIndex = 8
        Me.cmbWplistSmif.Value = Nothing
        '
        'cmbStockerSmif
        '
        Me.cmbStockerSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStockerSmif.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStockerSmif.Location = New System.Drawing.Point(0, 77)
        Me.cmbStockerSmif.Name = "cmbStockerSmif"
        Me.cmbStockerSmif.Size = New System.Drawing.Size(428, 28)
        Me.cmbStockerSmif.TabIndex = 9
        Me.cmbStockerSmif.Value = Nothing
        '
        'lblTitle14
        '
        Me.lblTitle14.BackColor = System.Drawing.Color.Navy
        Me.lblTitle14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle14.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle14.Location = New System.Drawing.Point(0, 60)
        Me.lblTitle14.Name = "lblTitle14"
        Me.lblTitle14.Size = New System.Drawing.Size(428, 17)
        Me.lblTitle14.TabIndex = 45
        Me.lblTitle14.Text = "出庫先ストッカー"
        Me.lblTitle14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatusSmif
        '
        Me.lblStatusSmif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatusSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatusSmif.ForeColor = System.Drawing.Color.Black
        Me.lblStatusSmif.Location = New System.Drawing.Point(431, 23)
        Me.lblStatusSmif.Name = "lblStatusSmif"
        Me.lblStatusSmif.Size = New System.Drawing.Size(127, 30)
        Me.lblStatusSmif.TabIndex = 44
        Me.lblStatusSmif.Text = "搬送可能"
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(431, 6)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(127, 17)
        Me.lblTitle8.TabIndex = 43
        Me.lblTitle8.Text = "ﾚﾁｸﾙﾎﾟｰﾄ状態"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblModeSmif
        '
        Me.lblModeSmif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModeSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblModeSmif.ForeColor = System.Drawing.Color.Black
        Me.lblModeSmif.Location = New System.Drawing.Point(693, 23)
        Me.lblModeSmif.Name = "lblModeSmif"
        Me.lblModeSmif.Size = New System.Drawing.Size(127, 30)
        Me.lblModeSmif.TabIndex = 37
        Me.lblModeSmif.Text = "S1"
        '
        'lblTitle13
        '
        Me.lblTitle13.BackColor = System.Drawing.Color.Navy
        Me.lblTitle13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle13.Location = New System.Drawing.Point(693, 6)
        Me.lblTitle13.Name = "lblTitle13"
        Me.lblTitle13.Size = New System.Drawing.Size(127, 17)
        Me.lblTitle13.TabIndex = 36
        Me.lblTitle13.Text = "運用モード"
        Me.lblTitle13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle12
        '
        Me.lblTitle12.BackColor = System.Drawing.Color.Navy
        Me.lblTitle12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle12.Location = New System.Drawing.Point(824, 6)
        Me.lblTitle12.Name = "lblTitle12"
        Me.lblTitle12.Size = New System.Drawing.Size(131, 17)
        Me.lblTitle12.TabIndex = 35
        Me.lblTitle12.Text = "搬送モード"
        Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFtsModeSmif
        '
        Me.lblFtsModeSmif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFtsModeSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFtsModeSmif.ForeColor = System.Drawing.Color.Black
        Me.lblFtsModeSmif.Location = New System.Drawing.Point(824, 23)
        Me.lblFtsModeSmif.Name = "lblFtsModeSmif"
        Me.lblFtsModeSmif.Size = New System.Drawing.Size(131, 30)
        Me.lblFtsModeSmif.TabIndex = 34
        Me.lblFtsModeSmif.Text = "搬送指示可"
        '
        'lblTitle11
        '
        Me.lblTitle11.BackColor = System.Drawing.Color.Navy
        Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle11.Location = New System.Drawing.Point(0, 6)
        Me.lblTitle11.Name = "lblTitle11"
        Me.lblTitle11.Size = New System.Drawing.Size(428, 17)
        Me.lblTitle11.TabIndex = 33
        Me.lblTitle11.Text = "搬送先レチクル装置"
        Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(870, 62)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(85, 17)
        Me.lblTitle10.TabIndex = 32
        Me.lblTitle10.Text = "該当件数"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCntSmif
        '
        Me.lblLotCntSmif.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCntSmif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCntSmif.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCntSmif.Location = New System.Drawing.Point(870, 79)
        Me.lblLotCntSmif.Name = "lblLotCntSmif"
        Me.lblLotCntSmif.Size = New System.Drawing.Size(85, 30)
        Me.lblLotCntSmif.TabIndex = 31
        Me.lblLotCntSmif.Text = "0"
        Me.lblLotCntSmif.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowDateSmif
        '
        Me.lblNowDateSmif.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDateSmif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateSmif.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDateSmif.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDateSmif.Location = New System.Drawing.Point(715, 79)
        Me.lblNowDateSmif.Name = "lblNowDateSmif"
        Me.lblNowDateSmif.Size = New System.Drawing.Size(151, 30)
        Me.lblNowDateSmif.TabIndex = 30
        Me.lblNowDateSmif.Text = "07/15 14:11:25"
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(715, 62)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle9.TabIndex = 29
        Me.lblTitle9.Text = "情報取得日時"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 583)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 17
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxEN01M0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.tabReticle)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01M0"
        Me.Text = "レチクルマニュアル搬送"
        Me.tabReticle.ResumeLayout(false)
        Me.Tab0.ResumeLayout(false)
        Me.fraWpLot.ResumeLayout(false)
        CType(Me.vsfWP,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab1.ResumeLayout(false)
        Me.fraSmif.ResumeLayout(false)
        CType(Me.vsfSMIF,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents tabReticle As TabControl
    Friend WithEvents Tab0 As TabPage
    Friend WithEvents fraWpLot As Panel
    Friend WithEvents cmdReticleMove As Button
    Friend WithEvents cmdStockerMove As Button
    Friend WithEvents cmdWpDown As Button
    Friend WithEvents cmdWpUP As Button
    Friend WithEvents cmdNowListWpLot As Button
    Friend WithEvents vsfWP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbWplistWpLot As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbStockerWpLot As SECmbIchiran.ComboIchiran
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSmif As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblStatusWpLot As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblModeWpLot As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblFtsModeWpLot As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblNowDateWplot As Label
    Friend WithEvents lblLotCntWp As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents Tab1 As TabPage
    Friend WithEvents fraSmif As Panel
    Friend WithEvents cmdShip As Button
    Friend WithEvents cmdSmifDown As Button
    Friend WithEvents cmdSmifUP As Button
    Friend WithEvents cmdNowListSmif As Button
    Friend WithEvents cmdWpMove As Button
    Friend WithEvents vsfSMIF As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbWplistSmif As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbStockerSmif As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTitle14 As Label
    Friend WithEvents lblStatusSmif As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblModeSmif As Label
    Friend WithEvents lblTitle13 As Label
    Friend WithEvents lblTitle12 As Label
    Friend WithEvents lblFtsModeSmif As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblLotCntSmif As Label
    Friend WithEvents lblNowDateSmif As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents cmdClose As Button
End Class
