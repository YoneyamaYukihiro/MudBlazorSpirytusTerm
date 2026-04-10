<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxMN0000
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxMN0000))
        Me.cmdExpand = New System.Windows.Forms.Button()
        Me.tabMenu = New System.Windows.Forms.TabControl()
        Me.Tab0 = New System.Windows.Forms.TabPage()
        Me.fravsfFlow = New System.Windows.Forms.Panel()
        Me.cmdVsfFlow = New System.Windows.Forms.Button()
        Me.cmdClose0 = New System.Windows.Forms.Button()
        Me.cmdFlowDown = New System.Windows.Forms.Button()
        Me.cmdFlowUp = New System.Windows.Forms.Button()
        Me.vsfFlow = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.fravsfTool = New System.Windows.Forms.Panel()
        Me.cmdVsfTool = New System.Windows.Forms.Button()
        Me.cmdClose1 = New System.Windows.Forms.Button()
        Me.cmdToolUp = New System.Windows.Forms.Button()
        Me.cmdToolDown = New System.Windows.Forms.Button()
        Me.vsfTool = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.fravsfFavorites = New System.Windows.Forms.Panel()
        Me.cmdVsfFavorites = New System.Windows.Forms.Button()
        Me.cmdFavoritesDown = New System.Windows.Forms.Button()
        Me.cmdFavoritesUp = New System.Windows.Forms.Button()
        Me.vsfFavorites = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdClose2 = New System.Windows.Forms.Button()
        Me.cmdFavorites = New System.Windows.Forms.Button()
        Me.picMenu = New System.Windows.Forms.PictureBox()
        Me.fraCarrier = New System.Windows.Forms.GroupBox()
        Me.picMenuBarChar1 = New System.Windows.Forms.PictureBox()
        Me.picMenuBarChar2 = New System.Windows.Forms.PictureBox()
        Me.picMenuBarChar3 = New System.Windows.Forms.PictureBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tabMenu.SuspendLayout
        Me.Tab0.SuspendLayout
        Me.fravsfFlow.SuspendLayout
        CType(Me.vsfFlow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab1.SuspendLayout
        Me.fravsfTool.SuspendLayout
        CType(Me.vsfTool,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab2.SuspendLayout
        Me.fravsfFavorites.SuspendLayout
        CType(Me.vsfFavorites,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picMenu,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picMenuBarChar1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picMenuBarChar2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picMenuBarChar3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdExpand
        '
        Me.cmdExpand.BackgroundImage = CType(resources.GetObject("cmdExpand.BackgroundImage"),System.Drawing.Image)
        Me.cmdExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdExpand.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte), true)
        Me.cmdExpand.Location = New System.Drawing.Point(3, 8)
        Me.cmdExpand.Name = "cmdExpand"
        Me.cmdExpand.Size = New System.Drawing.Size(35, 705)
        Me.cmdExpand.TabIndex = 0
        Me.cmdExpand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'tabMenu
        '
        Me.tabMenu.Controls.Add(Me.Tab0)
        Me.tabMenu.Controls.Add(Me.Tab1)
        Me.tabMenu.Controls.Add(Me.Tab2)
        Me.tabMenu.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.tabMenu.ItemSize = New System.Drawing.Size(156, 35)
        Me.tabMenu.Location = New System.Drawing.Point(38, 48)
        Me.tabMenu.Name = "tabMenu"
        Me.tabMenu.SelectedIndex = 0
        Me.tabMenu.Size = New System.Drawing.Size(473, 665)
        Me.tabMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabMenu.TabIndex = 1
        '
        'Tab0
        '
        Me.Tab0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab0.Controls.Add(Me.fravsfFlow)
        Me.Tab0.Controls.Add(Me.cmdClose0)
        Me.Tab0.Controls.Add(Me.cmdFlowDown)
        Me.Tab0.Controls.Add(Me.cmdFlowUp)
        Me.Tab0.Controls.Add(Me.vsfFlow)
        Me.Tab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab0.ForeColor = System.Drawing.Color.Black
        Me.Tab0.Location = New System.Drawing.Point(4, 39)
        Me.Tab0.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab0.Name = "Tab0"
        Me.Tab0.Size = New System.Drawing.Size(465, 622)
        Me.Tab0.TabIndex = 0
        Me.Tab0.Text = "流動系"
        '
        'fravsfFlow
        '
        Me.fravsfFlow.BackColor = System.Drawing.SystemColors.Control
        Me.fravsfFlow.Controls.Add(Me.cmdVsfFlow)
        Me.fravsfFlow.Location = New System.Drawing.Point(3, 10)
        Me.fravsfFlow.Name = "fravsfFlow"
        Me.fravsfFlow.Size = New System.Drawing.Size(38, 532)
        Me.fravsfFlow.TabIndex = 6
        '
        'cmdVsfFlow
        '
        Me.cmdVsfFlow.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdVsfFlow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdVsfFlow.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfFlow.Location = New System.Drawing.Point(-1, -1)
        Me.cmdVsfFlow.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdVsfFlow.Name = "cmdVsfFlow"
        Me.cmdVsfFlow.Size = New System.Drawing.Size(38, 38)
        Me.cmdVsfFlow.TabIndex = 15
        Me.cmdVsfFlow.Tag = "0"
        Me.cmdVsfFlow.UseVisualStyleBackColor = false
        '
        'cmdClose0
        '
        Me.cmdClose0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose0.Location = New System.Drawing.Point(344, 559)
        Me.cmdClose0.Name = "cmdClose0"
        Me.cmdClose0.Size = New System.Drawing.Size(114, 58)
        Me.cmdClose0.TabIndex = 5
        Me.cmdClose0.Text = "終　了"
        '
        'cmdFlowDown
        '
        Me.cmdFlowDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFlowDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFlowDown.Location = New System.Drawing.Point(408, 275)
        Me.cmdFlowDown.Name = "cmdFlowDown"
        Me.cmdFlowDown.Size = New System.Drawing.Size(51, 268)
        Me.cmdFlowDown.TabIndex = 4
        Me.cmdFlowDown.Text = "▼"
        '
        'cmdFlowUp
        '
        Me.cmdFlowUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFlowUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFlowUp.Location = New System.Drawing.Point(408, 8)
        Me.cmdFlowUp.Name = "cmdFlowUp"
        Me.cmdFlowUp.Size = New System.Drawing.Size(51, 268)
        Me.cmdFlowUp.TabIndex = 3
        Me.cmdFlowUp.Text = "▲"
        '
        'vsfFlow
        '
        Me.vsfFlow.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfFlow.AllowEditing = false
        Me.vsfFlow.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfFlow.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfFlow.AutoResize = true
        Me.vsfFlow.AutoSearchDelay = 2R
        Me.vsfFlow.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfFlow.ColumnInfo = "10,1,0,0,0,110,Columns:"
        Me.vsfFlow.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfFlow.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfFlow.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfFlow.Location = New System.Drawing.Point(2, 9)
        Me.vsfFlow.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFlow.Name = "vsfFlow"
        Me.vsfFlow.Rows.DefaultSize = 38
        Me.vsfFlow.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfFlow.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFlow.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfFlow.Size = New System.Drawing.Size(407, 534)
        Me.vsfFlow.StyleInfo = resources.GetString("vsfFlow.StyleInfo")
        Me.vsfFlow.TabIndex = 2
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab1.Controls.Add(Me.fravsfTool)
        Me.Tab1.Controls.Add(Me.cmdClose1)
        Me.Tab1.Controls.Add(Me.cmdToolUp)
        Me.Tab1.Controls.Add(Me.cmdToolDown)
        Me.Tab1.Controls.Add(Me.vsfTool)
        Me.Tab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab1.ForeColor = System.Drawing.Color.Black
        Me.Tab1.Location = New System.Drawing.Point(4, 39)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(465, 622)
        Me.Tab1.TabIndex = 1
        Me.Tab1.Text = "ツール系"
        '
        'fravsfTool
        '
        Me.fravsfTool.BackColor = System.Drawing.SystemColors.Control
        Me.fravsfTool.Controls.Add(Me.cmdVsfTool)
        Me.fravsfTool.Location = New System.Drawing.Point(3, 10)
        Me.fravsfTool.Name = "fravsfTool"
        Me.fravsfTool.Size = New System.Drawing.Size(38, 532)
        Me.fravsfTool.TabIndex = 10
        '
        'cmdVsfTool
        '
        Me.cmdVsfTool.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdVsfTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdVsfTool.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfTool.Location = New System.Drawing.Point(-1, -1)
        Me.cmdVsfTool.Name = "cmdVsfTool"
        Me.cmdVsfTool.Size = New System.Drawing.Size(38, 38)
        Me.cmdVsfTool.TabIndex = 17
        Me.cmdVsfTool.Tag = "0"
        Me.cmdVsfTool.UseVisualStyleBackColor = false
        '
        'cmdClose1
        '
        Me.cmdClose1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose1.Location = New System.Drawing.Point(344, 559)
        Me.cmdClose1.Name = "cmdClose1"
        Me.cmdClose1.Size = New System.Drawing.Size(114, 58)
        Me.cmdClose1.TabIndex = 9
        Me.cmdClose1.Text = "終　了"
        '
        'cmdToolUp
        '
        Me.cmdToolUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdToolUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdToolUp.Location = New System.Drawing.Point(408, 8)
        Me.cmdToolUp.Name = "cmdToolUp"
        Me.cmdToolUp.Size = New System.Drawing.Size(51, 268)
        Me.cmdToolUp.TabIndex = 8
        Me.cmdToolUp.Text = "▲"
        '
        'cmdToolDown
        '
        Me.cmdToolDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdToolDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdToolDown.Location = New System.Drawing.Point(408, 275)
        Me.cmdToolDown.Name = "cmdToolDown"
        Me.cmdToolDown.Size = New System.Drawing.Size(51, 268)
        Me.cmdToolDown.TabIndex = 7
        Me.cmdToolDown.Text = "▼"
        '
        'vsfTool
        '
        Me.vsfTool.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfTool.AllowEditing = false
        Me.vsfTool.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfTool.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfTool.AutoResize = true
        Me.vsfTool.AutoSearchDelay = 2R
        Me.vsfTool.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfTool.ColumnInfo = "10,1,0,0,0,110,Columns:"
        Me.vsfTool.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfTool.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfTool.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfTool.Location = New System.Drawing.Point(2, 9)
        Me.vsfTool.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfTool.Name = "vsfTool"
        Me.vsfTool.Rows.DefaultSize = 38
        Me.vsfTool.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfTool.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfTool.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
        Me.vsfTool.Size = New System.Drawing.Size(407, 534)
        Me.vsfTool.StyleInfo = resources.GetString("vsfTool.StyleInfo")
        Me.vsfTool.TabIndex = 6
        '
        'Tab2
        '
        Me.Tab2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab2.Controls.Add(Me.fravsfFavorites)
        Me.Tab2.Controls.Add(Me.cmdFavoritesDown)
        Me.Tab2.Controls.Add(Me.cmdFavoritesUp)
        Me.Tab2.Controls.Add(Me.vsfFavorites)
        Me.Tab2.Controls.Add(Me.cmdClose2)
        Me.Tab2.Controls.Add(Me.cmdFavorites)
        Me.Tab2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab2.ForeColor = System.Drawing.Color.Black
        Me.Tab2.Location = New System.Drawing.Point(4, 39)
        Me.Tab2.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Size = New System.Drawing.Size(465, 622)
        Me.Tab2.TabIndex = 2
        Me.Tab2.Text = "お気に入り"
        '
        'fravsfFavorites
        '
        Me.fravsfFavorites.BackColor = System.Drawing.SystemColors.Control
        Me.fravsfFavorites.Controls.Add(Me.cmdVsfFavorites)
        Me.fravsfFavorites.Location = New System.Drawing.Point(3, 10)
        Me.fravsfFavorites.Name = "fravsfFavorites"
        Me.fravsfFavorites.Size = New System.Drawing.Size(38, 532)
        Me.fravsfFavorites.TabIndex = 15
        '
        'cmdVsfFavorites
        '
        Me.cmdVsfFavorites.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdVsfFavorites.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.cmdVsfFavorites.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfFavorites.Location = New System.Drawing.Point(-1, -1)
        Me.cmdVsfFavorites.Name = "cmdVsfFavorites"
        Me.cmdVsfFavorites.Size = New System.Drawing.Size(38, 38)
        Me.cmdVsfFavorites.TabIndex = 18
        Me.cmdVsfFavorites.Tag = "0"
        Me.cmdVsfFavorites.UseVisualStyleBackColor = false
        '
        'cmdFavoritesDown
        '
        Me.cmdFavoritesDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFavoritesDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFavoritesDown.Location = New System.Drawing.Point(408, 275)
        Me.cmdFavoritesDown.Name = "cmdFavoritesDown"
        Me.cmdFavoritesDown.Size = New System.Drawing.Size(51, 268)
        Me.cmdFavoritesDown.TabIndex = 10
        Me.cmdFavoritesDown.Text = "▼"
        '
        'cmdFavoritesUp
        '
        Me.cmdFavoritesUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFavoritesUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFavoritesUp.Location = New System.Drawing.Point(408, 8)
        Me.cmdFavoritesUp.Name = "cmdFavoritesUp"
        Me.cmdFavoritesUp.Size = New System.Drawing.Size(51, 268)
        Me.cmdFavoritesUp.TabIndex = 11
        Me.cmdFavoritesUp.Text = "▲"
        '
        'vsfFavorites
        '
        Me.vsfFavorites.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfFavorites.AllowEditing = false
        Me.vsfFavorites.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfFavorites.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfFavorites.AutoResize = true
        Me.vsfFavorites.AutoSearchDelay = 2R
        Me.vsfFavorites.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfFavorites.ColumnInfo = "10,1,0,0,0,110,Columns:"
        Me.vsfFavorites.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfFavorites.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfFavorites.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfFavorites.Location = New System.Drawing.Point(2, 9)
        Me.vsfFavorites.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFavorites.Name = "vsfFavorites"
        Me.vsfFavorites.Rows.DefaultSize = 38
        Me.vsfFavorites.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfFavorites.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFavorites.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfFavorites.Size = New System.Drawing.Size(407, 534)
        Me.vsfFavorites.StyleInfo = resources.GetString("vsfFavorites.StyleInfo")
        Me.vsfFavorites.TabIndex = 12
        '
        'cmdClose2
        '
        Me.cmdClose2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose2.Location = New System.Drawing.Point(344, 559)
        Me.cmdClose2.Name = "cmdClose2"
        Me.cmdClose2.Size = New System.Drawing.Size(114, 58)
        Me.cmdClose2.TabIndex = 14
        Me.cmdClose2.Text = "終　了"
        '
        'cmdFavorites
        '
        Me.cmdFavorites.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFavorites.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFavorites.Location = New System.Drawing.Point(2, 559)
        Me.cmdFavorites.Name = "cmdFavorites"
        Me.cmdFavorites.Size = New System.Drawing.Size(114, 58)
        Me.cmdFavorites.TabIndex = 13
        Me.cmdFavorites.Text = "お気に入りの"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"整理"
        '
        'picMenu
        '
        Me.picMenu.BackColor = System.Drawing.SystemColors.Window
        Me.picMenu.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picMenu.Image = CType(resources.GetObject("picMenu.Image"),System.Drawing.Image)
        Me.picMenu.Location = New System.Drawing.Point(4, 1)
        Me.picMenu.Name = "picMenu"
        Me.picMenu.Size = New System.Drawing.Size(32, 32)
        Me.picMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMenu.TabIndex = 16
        Me.picMenu.TabStop = false
        Me.picMenu.Visible = false
        '
        'fraCarrier
        '
        Me.fraCarrier.Location = New System.Drawing.Point(36, 1)
        Me.fraCarrier.Name = "fraCarrier"
        Me.fraCarrier.Size = New System.Drawing.Size(472, 47)
        Me.fraCarrier.TabIndex = 19
        Me.fraCarrier.TabStop = false
        '
        'picMenuBarChar1
        '
        Me.picMenuBarChar1.BackColor = System.Drawing.SystemColors.Window
        Me.picMenuBarChar1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picMenuBarChar1.Image = CType(resources.GetObject("picMenuBarChar1.Image"),System.Drawing.Image)
        Me.picMenuBarChar1.Location = New System.Drawing.Point(34, 667)
        Me.picMenuBarChar1.Name = "picMenuBarChar1"
        Me.picMenuBarChar1.Size = New System.Drawing.Size(26, 255)
        Me.picMenuBarChar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMenuBarChar1.TabIndex = 20
        Me.picMenuBarChar1.TabStop = false
        Me.picMenuBarChar1.Visible = false
        '
        'picMenuBarChar2
        '
        Me.picMenuBarChar2.BackColor = System.Drawing.SystemColors.Window
        Me.picMenuBarChar2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picMenuBarChar2.Image = CType(resources.GetObject("picMenuBarChar2.Image"),System.Drawing.Image)
        Me.picMenuBarChar2.Location = New System.Drawing.Point(64, 667)
        Me.picMenuBarChar2.Name = "picMenuBarChar2"
        Me.picMenuBarChar2.Size = New System.Drawing.Size(26, 255)
        Me.picMenuBarChar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMenuBarChar2.TabIndex = 21
        Me.picMenuBarChar2.TabStop = false
        Me.picMenuBarChar2.Visible = false
        '
        'picMenuBarChar3
        '
        Me.picMenuBarChar3.BackColor = System.Drawing.SystemColors.Window
        Me.picMenuBarChar3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picMenuBarChar3.Image = CType(resources.GetObject("picMenuBarChar3.Image"),System.Drawing.Image)
        Me.picMenuBarChar3.Location = New System.Drawing.Point(93, 676)
        Me.picMenuBarChar3.Name = "picMenuBarChar3"
        Me.picMenuBarChar3.Size = New System.Drawing.Size(26, 255)
        Me.picMenuBarChar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMenuBarChar3.TabIndex = 22
        Me.picMenuBarChar3.TabStop = false
        Me.picMenuBarChar3.Visible = false
        '
        'frmxxMN0000
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(506, 737)
        Me.Controls.Add(Me.picMenu)
        Me.Controls.Add(Me.cmdExpand)
        Me.Controls.Add(Me.tabMenu)
        Me.Controls.Add(Me.fraCarrier)
        Me.Controls.Add(Me.picMenuBarChar1)
        Me.Controls.Add(Me.picMenuBarChar2)
        Me.Controls.Add(Me.picMenuBarChar3)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(971, 0)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxMN0000"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = " SPIRYTUS"
        Me.tabMenu.ResumeLayout(false)
        Me.Tab0.ResumeLayout(false)
        Me.fravsfFlow.ResumeLayout(false)
        CType(Me.vsfFlow,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab1.ResumeLayout(false)
        Me.fravsfTool.ResumeLayout(false)
        CType(Me.vsfTool,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab2.ResumeLayout(false)
        Me.fravsfFavorites.ResumeLayout(false)
        CType(Me.vsfFavorites,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picMenu,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picMenuBarChar1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picMenuBarChar2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picMenuBarChar3,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdExpand As Button
    Friend WithEvents tabMenu As TabControl
    Friend WithEvents Tab0 As TabPage
    Friend WithEvents vsfFlow As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdVsfFlow As Button
    Friend WithEvents cmdFlowUp As Button
    Friend WithEvents cmdFlowDown As Button
    Friend WithEvents cmdClose0 As Button
    Friend WithEvents Tab1 As TabPage
    Friend WithEvents vsfTool As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdVsfTool As Button
    Friend WithEvents cmdToolDown As Button
    Friend WithEvents cmdToolUp As Button
    Friend WithEvents cmdClose1 As Button
    Friend WithEvents Tab2 As TabPage
    Friend WithEvents vsfFavorites As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdVsfFavorites As Button
    Friend WithEvents cmdFavoritesDown As Button
    Friend WithEvents cmdFavoritesUp As Button
    Friend WithEvents cmdClose2 As Button
    Friend WithEvents cmdFavorites As Button
    Friend WithEvents picMenu As PictureBox
    Friend WithEvents fraCarrier As GroupBox
    Friend WithEvents picMenuBarChar1 As PictureBox
    Friend WithEvents picMenuBarChar2 As PictureBox
    Friend WithEvents picMenuBarChar3 As PictureBox
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents fravsfFlow As Panel
    Friend WithEvents fravsfTool As Panel
    Friend WithEvents fravsfFavorites As Panel
End Class
