<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxMN0001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxMN0001))
        Me.cmdSpace = New System.Windows.Forms.Button()
        Me.tabMenu2 = New System.Windows.Forms.TabControl()
        Me.Tab20 = New System.Windows.Forms.TabPage()
        Me.cmdFavoritesDown = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.cmdFavoritesUp = New System.Windows.Forms.Button()
        Me.vsfFavorites = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblScroll2 = New System.Windows.Forms.Label()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdConfirm = New System.Windows.Forms.Button()
        Me.tabMenu1 = New System.Windows.Forms.TabControl()
        Me.Tab10 = New System.Windows.Forms.TabPage()
        Me.cmdFlowDown = New System.Windows.Forms.Button()
        Me.cmdFlowUp = New System.Windows.Forms.Button()
        Me.vsfFlow = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblScroll0 = New System.Windows.Forms.Label()
        Me.Tab11 = New System.Windows.Forms.TabPage()
        Me.cmdToolDown = New System.Windows.Forms.Button()
        Me.cmdToolUp = New System.Windows.Forms.Button()
        Me.vsfTool = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblScroll1 = New System.Windows.Forms.Label()
        Me.chkMenu = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tabMenu2.SuspendLayout
        Me.Tab20.SuspendLayout
        CType(Me.vsfFavorites,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabMenu1.SuspendLayout
        Me.Tab10.SuspendLayout
        CType(Me.vsfFlow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab11.SuspendLayout
        CType(Me.vsfTool,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdSpace
        '
        Me.cmdSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSpace.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSpace.Location = New System.Drawing.Point(440, 174)
        Me.cmdSpace.Name = "cmdSpace"
        Me.cmdSpace.Size = New System.Drawing.Size(107, 57)
        Me.cmdSpace.TabIndex = 7
        Me.cmdSpace.Text = "空白行挿入"
        '
        'tabMenu2
        '
        Me.tabMenu2.Controls.Add(Me.Tab20)
        Me.tabMenu2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.tabMenu2.ItemSize = New System.Drawing.Size(285, 35)
        Me.tabMenu2.Location = New System.Drawing.Point(562, 8)
        Me.tabMenu2.Name = "tabMenu2"
        Me.tabMenu2.SelectedIndex = 0
        Me.tabMenu2.Size = New System.Drawing.Size(291, 593)
        Me.tabMenu2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabMenu2.TabIndex = 15
        Me.tabMenu2.TabStop = false
        '
        'Tab20
        '
        Me.Tab20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab20.Controls.Add(Me.cmdFavoritesDown)
        Me.Tab20.Controls.Add(Me.cmdMoveDown)
        Me.Tab20.Controls.Add(Me.cmdMoveUp)
        Me.Tab20.Controls.Add(Me.cmdFavoritesUp)
        Me.Tab20.Controls.Add(Me.vsfFavorites)
        Me.Tab20.Controls.Add(Me.lblScroll2)
        Me.Tab20.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab20.ForeColor = System.Drawing.Color.Black
        Me.Tab20.Location = New System.Drawing.Point(4, 39)
        Me.Tab20.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab20.Name = "Tab20"
        Me.Tab20.Size = New System.Drawing.Size(283, 550)
        Me.Tab20.TabIndex = 0
        Me.Tab20.Text = "お気に入り"
        '
        'cmdFavoritesDown
        '
        Me.cmdFavoritesDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFavoritesDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFavoritesDown.Location = New System.Drawing.Point(228, 496)
        Me.cmdFavoritesDown.Name = "cmdFavoritesDown"
        Me.cmdFavoritesDown.Size = New System.Drawing.Size(49, 49)
        Me.cmdFavoritesDown.TabIndex = 13
        Me.cmdFavoritesDown.Text = "▼"
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMoveDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMoveDown.Location = New System.Drawing.Point(228, 330)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(49, 49)
        Me.cmdMoveDown.TabIndex = 15
        Me.cmdMoveDown.Text = "↓"
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMoveUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMoveUp.Location = New System.Drawing.Point(228, 178)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(49, 49)
        Me.cmdMoveUp.TabIndex = 14
        Me.cmdMoveUp.Text = "↑"
        '
        'cmdFavoritesUp
        '
        Me.cmdFavoritesUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFavoritesUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFavoritesUp.Location = New System.Drawing.Point(228, 9)
        Me.cmdFavoritesUp.Name = "cmdFavoritesUp"
        Me.cmdFavoritesUp.Size = New System.Drawing.Size(49, 49)
        Me.cmdFavoritesUp.TabIndex = 12
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
        Me.vsfFavorites.Location = New System.Drawing.Point(4, 10)
        Me.vsfFavorites.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFavorites.Name = "vsfFavorites"
        Me.vsfFavorites.Rows.DefaultSize = 38
        Me.vsfFavorites.Rows.Fixed = 0
        Me.vsfFavorites.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfFavorites.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFavorites.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfFavorites.Size = New System.Drawing.Size(225, 534)
        Me.vsfFavorites.StyleInfo = resources.GetString("vsfFavorites.StyleInfo")
        Me.vsfFavorites.TabIndex = 11
        '
        'lblScroll2
        '
        Me.lblScroll2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScroll2.Location = New System.Drawing.Point(228, 10)
        Me.lblScroll2.Name = "lblScroll2"
        Me.lblScroll2.Size = New System.Drawing.Size(48, 535)
        Me.lblScroll2.TabIndex = 21
        Me.lblScroll2.Text = "Label1"
        '
        'cmdRemove
        '
        Me.cmdRemove.Enabled = false
        Me.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRemove.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRemove.Location = New System.Drawing.Point(440, 414)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(107, 57)
        Me.cmdRemove.TabIndex = 9
        Me.cmdRemove.Text = "削　除"
        '
        'cmdMove
        '
        Me.cmdMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 24!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMove.Location = New System.Drawing.Point(440, 294)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.Size = New System.Drawing.Size(107, 57)
        Me.cmdMove.TabIndex = 8
        Me.cmdMove.Text = ">"
        '
        'cmdClose
        '
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 584)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(107, 57)
        Me.cmdClose.TabIndex = 17
        Me.cmdClose.Text = "閉じる"
        '
        'cmdConfirm
        '
        Me.cmdConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdConfirm.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdConfirm.Location = New System.Drawing.Point(868, 584)
        Me.cmdConfirm.Name = "cmdConfirm"
        Me.cmdConfirm.Size = New System.Drawing.Size(107, 57)
        Me.cmdConfirm.TabIndex = 16
        Me.cmdConfirm.Text = "確　定"
        '
        'tabMenu1
        '
        Me.tabMenu1.Controls.Add(Me.Tab10)
        Me.tabMenu1.Controls.Add(Me.Tab11)
        Me.tabMenu1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.tabMenu1.ItemSize = New System.Drawing.Size(147, 35)
        Me.tabMenu1.Location = New System.Drawing.Point(130, 8)
        Me.tabMenu1.Name = "tabMenu1"
        Me.tabMenu1.SelectedIndex = 0
        Me.tabMenu1.Size = New System.Drawing.Size(297, 593)
        Me.tabMenu1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabMenu1.TabIndex = 6
        '
        'Tab10
        '
        Me.Tab10.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab10.Controls.Add(Me.cmdFlowDown)
        Me.Tab10.Controls.Add(Me.cmdFlowUp)
        Me.Tab10.Controls.Add(Me.vsfFlow)
        Me.Tab10.Controls.Add(Me.lblScroll0)
        Me.Tab10.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab10.ForeColor = System.Drawing.Color.Black
        Me.Tab10.Location = New System.Drawing.Point(4, 39)
        Me.Tab10.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab10.Name = "Tab10"
        Me.Tab10.Size = New System.Drawing.Size(289, 550)
        Me.Tab10.TabIndex = 0
        Me.Tab10.Text = "流動系"
        '
        'cmdFlowDown
        '
        Me.cmdFlowDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFlowDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFlowDown.Location = New System.Drawing.Point(236, 496)
        Me.cmdFlowDown.Name = "cmdFlowDown"
        Me.cmdFlowDown.Size = New System.Drawing.Size(49, 49)
        Me.cmdFlowDown.TabIndex = 2
        Me.cmdFlowDown.Text = "▼"
        '
        'cmdFlowUp
        '
        Me.cmdFlowUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdFlowUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdFlowUp.Location = New System.Drawing.Point(236, 9)
        Me.cmdFlowUp.Name = "cmdFlowUp"
        Me.cmdFlowUp.Size = New System.Drawing.Size(49, 49)
        Me.cmdFlowUp.TabIndex = 1
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
        Me.vsfFlow.Location = New System.Drawing.Point(4, 10)
        Me.vsfFlow.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFlow.Name = "vsfFlow"
        Me.vsfFlow.Rows.DefaultSize = 38
        Me.vsfFlow.Rows.Fixed = 0
        Me.vsfFlow.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfFlow.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFlow.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfFlow.Size = New System.Drawing.Size(233, 534)
        Me.vsfFlow.StyleInfo = resources.GetString("vsfFlow.StyleInfo")
        Me.vsfFlow.TabIndex = 0
        '
        'lblScroll0
        '
        Me.lblScroll0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScroll0.Location = New System.Drawing.Point(236, 10)
        Me.lblScroll0.Name = "lblScroll0"
        Me.lblScroll0.Size = New System.Drawing.Size(48, 535)
        Me.lblScroll0.TabIndex = 20
        Me.lblScroll0.Text = "Label1"
        '
        'Tab11
        '
        Me.Tab11.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab11.Controls.Add(Me.cmdToolDown)
        Me.Tab11.Controls.Add(Me.cmdToolUp)
        Me.Tab11.Controls.Add(Me.vsfTool)
        Me.Tab11.Controls.Add(Me.lblScroll1)
        Me.Tab11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab11.ForeColor = System.Drawing.Color.Black
        Me.Tab11.Location = New System.Drawing.Point(4, 39)
        Me.Tab11.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab11.Name = "Tab11"
        Me.Tab11.Size = New System.Drawing.Size(289, 550)
        Me.Tab11.TabIndex = 1
        Me.Tab11.Text = "ツール系"
        '
        'cmdToolDown
        '
        Me.cmdToolDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdToolDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdToolDown.Location = New System.Drawing.Point(236, 496)
        Me.cmdToolDown.Name = "cmdToolDown"
        Me.cmdToolDown.Size = New System.Drawing.Size(49, 49)
        Me.cmdToolDown.TabIndex = 5
        Me.cmdToolDown.Text = "▼"
        '
        'cmdToolUp
        '
        Me.cmdToolUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdToolUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdToolUp.Location = New System.Drawing.Point(236, 9)
        Me.cmdToolUp.Name = "cmdToolUp"
        Me.cmdToolUp.Size = New System.Drawing.Size(49, 49)
        Me.cmdToolUp.TabIndex = 4
        Me.cmdToolUp.Text = "▲"
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
        Me.vsfTool.Location = New System.Drawing.Point(4, 10)
        Me.vsfTool.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfTool.Name = "vsfTool"
        Me.vsfTool.Rows.DefaultSize = 38
        Me.vsfTool.Rows.Fixed = 0
        Me.vsfTool.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfTool.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfTool.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
        Me.vsfTool.Size = New System.Drawing.Size(233, 534)
        Me.vsfTool.StyleInfo = resources.GetString("vsfTool.StyleInfo")
        Me.vsfTool.TabIndex = 3
        '
        'lblScroll1
        '
        Me.lblScroll1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScroll1.Location = New System.Drawing.Point(236, 10)
        Me.lblScroll1.Name = "lblScroll1"
        Me.lblScroll1.Size = New System.Drawing.Size(48, 535)
        Me.lblScroll1.TabIndex = 19
        Me.lblScroll1.Text = "Label1"
        '
        'chkMenu
        '
        Me.chkMenu.Checked = true
        Me.chkMenu.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMenu.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkMenu.Location = New System.Drawing.Point(8, 12)
        Me.chkMenu.Name = "chkMenu"
        Me.chkMenu.Size = New System.Drawing.Size(125, 57)
        Me.chkMenu.TabIndex = 10
        Me.chkMenu.Text = "キャリアＩＤ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"引継ぎ"
        Me.chkMenu.Visible = false
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(2, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 121)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "　↑ 不具合№190によりｷｬﾘｱID引継ぎﾁｪｯｸﾎﾞｯｸｽをﾒﾆｭｰから移動したが、常にﾁｪｯｸを付けたまま非表示となった。後で必要と言われた時の為に削除せず"& _ 
    "残すことになりました（高野さんより）（11/04 三浦）"
        Me.Label1.Visible = false
        '
        'frmxxMN0001
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdSpace)
        Me.Controls.Add(Me.tabMenu2)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdMove)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdConfirm)
        Me.Controls.Add(Me.tabMenu1)
        Me.Controls.Add(Me.chkMenu)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxMN0001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "お気に入り登録"
        Me.tabMenu2.ResumeLayout(false)
        Me.Tab20.ResumeLayout(false)
        CType(Me.vsfFavorites,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabMenu1.ResumeLayout(false)
        Me.Tab10.ResumeLayout(false)
        CType(Me.vsfFlow,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab11.ResumeLayout(false)
        CType(Me.vsfTool,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdSpace As Button
    Friend WithEvents tabMenu2 As TabControl
    Friend WithEvents Tab20 As TabPage
    Friend WithEvents lblScroll2 As Label
    Friend WithEvents vsfFavorites As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdMoveDown As Button
    Friend WithEvents cmdMoveUp As Button
    Friend WithEvents cmdFavoritesUp As Button
    Friend WithEvents cmdFavoritesDown As Button
    Friend WithEvents cmdRemove As Button
    Friend WithEvents cmdMove As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdConfirm As Button
    Friend WithEvents tabMenu1 As TabControl
    Friend WithEvents Tab10 As TabPage
    Friend WithEvents lblScroll0 As Label
    Friend WithEvents vsfFlow As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdFlowDown As Button
    Friend WithEvents cmdFlowUp As Button
    Friend WithEvents Tab11 As TabPage
    Friend WithEvents cmdToolDown As Button
    Friend WithEvents cmdToolUp As Button
    Friend WithEvents vsfTool As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblScroll1 As Label
    Friend WithEvents chkMenu As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip As ToolTip
End Class
