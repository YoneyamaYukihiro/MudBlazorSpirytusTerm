<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01X3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01X3))
        Me.stbRecipe = New System.Windows.Forms.TabControl()
        Me.Tab0 = New System.Windows.Forms.TabPage()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.optRecipe2 = New System.Windows.Forms.RadioButton()
        Me.optRecipe3 = New System.Windows.Forms.RadioButton()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.vsfUseWP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfUseRecipe2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.fraUseRecipe = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecipeFilter = New SETextBoxEx.TextBoxEx()
        Me.cmdRowAdd = New System.Windows.Forms.Button()
        Me.optRecipe0 = New System.Windows.Forms.RadioButton()
        Me.optRecipe1 = New System.Windows.Forms.RadioButton()
        Me.cmdDelRecipe = New System.Windows.Forms.Button()
        Me.vsfUseRecipe1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.fraCondition = New System.Windows.Forms.GroupBox()
        Me.fraLabel = New System.Windows.Forms.Panel()
        Me.lblTVer = New System.Windows.Forms.Label()
        Me.lblTConditionId = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblConditionId = New System.Windows.Forms.Label()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblSkipFlag = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.fraLoader = New System.Windows.Forms.GroupBox()
        Me.lblTransMode = New System.Windows.Forms.Label()
        Me.lblAfterCarrierTypeName = New System.Windows.Forms.Label()
        Me.lblBeforeCarrierTypeName = New System.Windows.Forms.Label()
        Me.lblPortType = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.fraConData = New System.Windows.Forms.Panel()
        Me.txtWorkCondition = New SETextBoxEx.TextBoxEx()
        Me.lblOptionWordCount = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.stbRecipe.SuspendLayout
        Me.Tab0.SuspendLayout
        Me.Frame1.SuspendLayout
        CType(Me.vsfUseWP,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfUseRecipe2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab1.SuspendLayout
        Me.fraUseRecipe.SuspendLayout
        CType(Me.vsfUseRecipe1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCondition.SuspendLayout
        Me.fraLabel.SuspendLayout
        Me.fraLoader.SuspendLayout
        Me.fraConData.SuspendLayout
        Me.SuspendLayout
        '
        'stbRecipe
        '
        Me.stbRecipe.Controls.Add(Me.Tab0)
        Me.stbRecipe.Controls.Add(Me.Tab1)
        Me.stbRecipe.ItemSize = New System.Drawing.Size(480, 21)
        Me.stbRecipe.Location = New System.Drawing.Point(8, 318)
        Me.stbRecipe.Name = "stbRecipe"
        Me.stbRecipe.SelectedIndex = 0
        Me.stbRecipe.Size = New System.Drawing.Size(965, 279)
        Me.stbRecipe.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.stbRecipe.TabIndex = 29
        '
        'Tab0
        '
        Me.Tab0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab0.Controls.Add(Me.Frame1)
        Me.Tab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab0.ForeColor = System.Drawing.Color.Black
        Me.Tab0.Location = New System.Drawing.Point(4, 25)
        Me.Tab0.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab0.Name = "Tab0"
        Me.Tab0.Size = New System.Drawing.Size(957, 250)
        Me.Tab0.TabIndex = 0
        Me.Tab0.Text = "装置共通レシピ"
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.Command3)
        Me.Frame1.Controls.Add(Me.optRecipe2)
        Me.Frame1.Controls.Add(Me.optRecipe3)
        Me.Frame1.Controls.Add(Me.Command1)
        Me.Frame1.Controls.Add(Me.vsfUseWP)
        Me.Frame1.Controls.Add(Me.vsfUseRecipe2)
        Me.Frame1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Frame1.Location = New System.Drawing.Point(0, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(957, 252)
        Me.Frame1.TabIndex = 36
        Me.Frame1.TabStop = false
        '
        'Command3
        '
        Me.Command3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Command3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Command3.Location = New System.Drawing.Point(832, 100)
        Me.Command3.Name = "Command3"
        Me.Command3.Size = New System.Drawing.Size(85, 40)
        Me.Command3.TabIndex = 40
        Me.Command3.Text = "行追加"
        Me.Command3.Visible = false
        '
        'optRecipe2
        '
        Me.optRecipe2.Checked = true
        Me.optRecipe2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optRecipe2.Location = New System.Drawing.Point(831, 32)
        Me.optRecipe2.Name = "optRecipe2"
        Me.optRecipe2.Size = New System.Drawing.Size(124, 26)
        Me.optRecipe2.TabIndex = 39
        Me.optRecipe2.TabStop = true
        Me.optRecipe2.Text = "ロットレシピ"
        '
        'optRecipe3
        '
        Me.optRecipe3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optRecipe3.Location = New System.Drawing.Point(831, 63)
        Me.optRecipe3.Name = "optRecipe3"
        Me.optRecipe3.Size = New System.Drawing.Size(119, 26)
        Me.optRecipe3.TabIndex = 38
        Me.optRecipe3.Text = "枚葉レシピ"
        '
        'Command1
        '
        Me.Command1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Command1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Command1.Location = New System.Drawing.Point(832, 152)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(85, 40)
        Me.Command1.TabIndex = 37
        Me.Command1.Text = "行削除"
        Me.Command1.Visible = false
        '
        'vsfUseWP
        '
        Me.vsfUseWP.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfUseWP.AllowEditing = false
        Me.vsfUseWP.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfUseWP.AutoResize = true
        Me.vsfUseWP.AutoSearchDelay = 2R
        Me.vsfUseWP.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfUseWP.ColumnInfo = resources.GetString("vsfUseWP.ColumnInfo")
        Me.vsfUseWP.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfUseWP.ExtendLastCol = true
        Me.vsfUseWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfUseWP.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfUseWP.Location = New System.Drawing.Point(2, 10)
        Me.vsfUseWP.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfUseWP.Name = "vsfUseWP"
        Me.vsfUseWP.Rows.Count = 14
        Me.vsfUseWP.Rows.DefaultSize = 18
        Me.vsfUseWP.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfUseWP.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfUseWP.Size = New System.Drawing.Size(323, 236)
        Me.vsfUseWP.StyleInfo = resources.GetString("vsfUseWP.StyleInfo")
        Me.vsfUseWP.TabIndex = 41
        '
        'vsfUseRecipe2
        '
        Me.vsfUseRecipe2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfUseRecipe2.AllowEditing = false
        Me.vsfUseRecipe2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfUseRecipe2.AutoResize = true
        Me.vsfUseRecipe2.AutoSearchDelay = 2R
        Me.vsfUseRecipe2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfUseRecipe2.ColumnInfo = resources.GetString("vsfUseRecipe2.ColumnInfo")
        Me.vsfUseRecipe2.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfUseRecipe2.ExtendLastCol = true
        Me.vsfUseRecipe2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfUseRecipe2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfUseRecipe2.Location = New System.Drawing.Point(332, 10)
        Me.vsfUseRecipe2.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfUseRecipe2.Name = "vsfUseRecipe2"
        Me.vsfUseRecipe2.Rows.Count = 14
        Me.vsfUseRecipe2.Rows.DefaultSize = 18
        Me.vsfUseRecipe2.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfUseRecipe2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfUseRecipe2.Size = New System.Drawing.Size(489, 236)
        Me.vsfUseRecipe2.StyleInfo = resources.GetString("vsfUseRecipe2.StyleInfo")
        Me.vsfUseRecipe2.TabIndex = 42
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab1.Controls.Add(Me.fraUseRecipe)
        Me.Tab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab1.ForeColor = System.Drawing.Color.Black
        Me.Tab1.Location = New System.Drawing.Point(4, 25)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(957, 250)
        Me.Tab1.TabIndex = 1
        Me.Tab1.Text = "装置個別レシピ"
        '
        'fraUseRecipe
        '
        Me.fraUseRecipe.Controls.Add(Me.Label2)
        Me.fraUseRecipe.Controls.Add(Me.txtRecipeFilter)
        Me.fraUseRecipe.Controls.Add(Me.cmdRowAdd)
        Me.fraUseRecipe.Controls.Add(Me.optRecipe0)
        Me.fraUseRecipe.Controls.Add(Me.optRecipe1)
        Me.fraUseRecipe.Controls.Add(Me.cmdDelRecipe)
        Me.fraUseRecipe.Controls.Add(Me.vsfUseRecipe1)
        Me.fraUseRecipe.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraUseRecipe.Location = New System.Drawing.Point(0, 0)
        Me.fraUseRecipe.Name = "fraUseRecipe"
        Me.fraUseRecipe.Size = New System.Drawing.Size(957, 252)
        Me.fraUseRecipe.TabIndex = 30
        Me.fraUseRecipe.TabStop = false
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(831, 190)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "レシピフィルタ"
        '
        'txtRecipeFilter
        '
        Me.txtRecipeFilter.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtRecipeFilter.ChrMaxByte = 128
        Me.txtRecipeFilter.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtRecipeFilter.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
        Me.txtRecipeFilter.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtRecipeFilter.Location = New System.Drawing.Point(832, 206)
        Me.txtRecipeFilter.Name = "txtRecipeFilter"
        Me.txtRecipeFilter.NgChr = "'"
        Me.txtRecipeFilter.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtRecipeFilter.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRecipeFilter.SelectedText = ""
        Me.txtRecipeFilter.Size = New System.Drawing.Size(118, 21)
        Me.txtRecipeFilter.TabIndex = 36
        '
        'cmdRowAdd
        '
        Me.cmdRowAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRowAdd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRowAdd.Location = New System.Drawing.Point(832, 78)
        Me.cmdRowAdd.Name = "cmdRowAdd"
        Me.cmdRowAdd.Size = New System.Drawing.Size(85, 40)
        Me.cmdRowAdd.TabIndex = 34
        Me.cmdRowAdd.Text = "行追加"
        '
        'optRecipe0
        '
        Me.optRecipe0.Checked = true
        Me.optRecipe0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optRecipe0.Location = New System.Drawing.Point(831, 14)
        Me.optRecipe0.Name = "optRecipe0"
        Me.optRecipe0.Size = New System.Drawing.Size(124, 26)
        Me.optRecipe0.TabIndex = 33
        Me.optRecipe0.TabStop = true
        Me.optRecipe0.Text = "ロットレシピ"
        '
        'optRecipe1
        '
        Me.optRecipe1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optRecipe1.Location = New System.Drawing.Point(831, 41)
        Me.optRecipe1.Name = "optRecipe1"
        Me.optRecipe1.Size = New System.Drawing.Size(119, 26)
        Me.optRecipe1.TabIndex = 32
        Me.optRecipe1.Text = "枚葉レシピ"
        '
        'cmdDelRecipe
        '
        Me.cmdDelRecipe.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDelRecipe.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDelRecipe.Location = New System.Drawing.Point(832, 130)
        Me.cmdDelRecipe.Name = "cmdDelRecipe"
        Me.cmdDelRecipe.Size = New System.Drawing.Size(85, 40)
        Me.cmdDelRecipe.TabIndex = 31
        Me.cmdDelRecipe.Text = "行削除"
        '
        'vsfUseRecipe1
        '
        Me.vsfUseRecipe1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfUseRecipe1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfUseRecipe1.AutoResize = true
        Me.vsfUseRecipe1.AutoSearchDelay = 2R
        Me.vsfUseRecipe1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfUseRecipe1.ColumnInfo = resources.GetString("vsfUseRecipe1.ColumnInfo")
        Me.vsfUseRecipe1.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfUseRecipe1.ExtendLastCol = true
        Me.vsfUseRecipe1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfUseRecipe1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfUseRecipe1.Location = New System.Drawing.Point(2, 10)
        Me.vsfUseRecipe1.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfUseRecipe1.Name = "vsfUseRecipe1"
        Me.vsfUseRecipe1.Rows.Count = 14
        Me.vsfUseRecipe1.Rows.DefaultSize = 18
        Me.vsfUseRecipe1.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfUseRecipe1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfUseRecipe1.Size = New System.Drawing.Size(819, 236)
        Me.vsfUseRecipe1.StyleInfo = resources.GetString("vsfUseRecipe1.StyleInfo")
        Me.vsfUseRecipe1.TabIndex = 35
        '
        'cmdUpdate
        '
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpdate.Location = New System.Drawing.Point(888, 598)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(85, 40)
        Me.cmdUpdate.TabIndex = 1
        Me.cmdUpdate.Text = "確　定"
        '
        'fraCondition
        '
        Me.fraCondition.Controls.Add(Me.fraLabel)
        Me.fraCondition.Controls.Add(Me.cmdDown)
        Me.fraCondition.Controls.Add(Me.cmdUp)
        Me.fraCondition.Controls.Add(Me.fraLoader)
        Me.fraCondition.Controls.Add(Me.fraConData)
        Me.fraCondition.Controls.Add(Me.txtComments)
        Me.fraCondition.Controls.Add(Me.lblTtl15)
        Me.fraCondition.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCondition.Location = New System.Drawing.Point(8, 8)
        Me.fraCondition.Name = "fraCondition"
        Me.fraCondition.Size = New System.Drawing.Size(963, 304)
        Me.fraCondition.TabIndex = 0
        Me.fraCondition.TabStop = false
        Me.fraCondition.Text = "処理条件情報"
        '
        'fraLabel
        '
        Me.fraLabel.Controls.Add(Me.lblTVer)
        Me.fraLabel.Controls.Add(Me.lblTConditionId)
        Me.fraLabel.Controls.Add(Me.lblTitle2)
        Me.fraLabel.Controls.Add(Me.lblConditionId)
        Me.fraLabel.Controls.Add(Me.lblVer)
        Me.fraLabel.Controls.Add(Me.lblCategory)
        Me.fraLabel.Controls.Add(Me.lblSkipFlag)
        Me.fraLabel.Controls.Add(Me.lblTitle0)
        Me.fraLabel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLabel.Location = New System.Drawing.Point(16, 20)
        Me.fraLabel.Name = "fraLabel"
        Me.fraLabel.Size = New System.Drawing.Size(815, 41)
        Me.fraLabel.TabIndex = 20
        Me.fraLabel.Text = "Frame1"
        '
        'lblTVer
        '
        Me.lblTVer.BackColor = System.Drawing.Color.Navy
        Me.lblTVer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTVer.ForeColor = System.Drawing.Color.Yellow
        Me.lblTVer.Location = New System.Drawing.Point(272, 0)
        Me.lblTVer.Name = "lblTVer"
        Me.lblTVer.Size = New System.Drawing.Size(61, 17)
        Me.lblTVer.TabIndex = 28
        Me.lblTVer.Text = "Ver."
        Me.lblTVer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTConditionId
        '
        Me.lblTConditionId.BackColor = System.Drawing.Color.Navy
        Me.lblTConditionId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTConditionId.ForeColor = System.Drawing.Color.Yellow
        Me.lblTConditionId.Location = New System.Drawing.Point(0, 0)
        Me.lblTConditionId.Name = "lblTConditionId"
        Me.lblTConditionId.Size = New System.Drawing.Size(273, 17)
        Me.lblTConditionId.TabIndex = 27
        Me.lblTConditionId.Text = "処理条件ID"
        Me.lblTConditionId.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(340, 0)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(333, 17)
        Me.lblTitle2.TabIndex = 26
        Me.lblTitle2.Text = " カテゴリ"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblConditionId
        '
        Me.lblConditionId.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblConditionId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConditionId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblConditionId.Location = New System.Drawing.Point(0, 16)
        Me.lblConditionId.Name = "lblConditionId"
        Me.lblConditionId.Size = New System.Drawing.Size(273, 22)
        Me.lblConditionId.TabIndex = 25
        '
        'lblVer
        '
        Me.lblVer.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblVer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVer.Location = New System.Drawing.Point(272, 16)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(61, 22)
        Me.lblVer.TabIndex = 24
        Me.lblVer.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCategory
        '
        Me.lblCategory.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCategory.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCategory.Location = New System.Drawing.Point(340, 16)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(333, 22)
        Me.lblCategory.TabIndex = 23
        '
        'lblSkipFlag
        '
        Me.lblSkipFlag.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblSkipFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSkipFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSkipFlag.Location = New System.Drawing.Point(680, 16)
        Me.lblSkipFlag.Name = "lblSkipFlag"
        Me.lblSkipFlag.Size = New System.Drawing.Size(97, 22)
        Me.lblSkipFlag.TabIndex = 22
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(680, 0)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle0.TabIndex = 21
        Me.lblTitle0.Text = "工程ｽｷｯﾌﾟ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Location = New System.Drawing.Point(769, 268)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(25, 29)
        Me.cmdDown.TabIndex = 3
        Me.cmdDown.Text = "▼"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Location = New System.Drawing.Point(769, 241)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(25, 29)
        Me.cmdUp.TabIndex = 2
        Me.cmdUp.Text = "▲"
        '
        'fraLoader
        '
        Me.fraLoader.Controls.Add(Me.lblTransMode)
        Me.fraLoader.Controls.Add(Me.lblAfterCarrierTypeName)
        Me.fraLoader.Controls.Add(Me.lblBeforeCarrierTypeName)
        Me.fraLoader.Controls.Add(Me.lblPortType)
        Me.fraLoader.Controls.Add(Me.lblTitle5)
        Me.fraLoader.Controls.Add(Me.lblTitle1)
        Me.fraLoader.Controls.Add(Me.lblTitle6)
        Me.fraLoader.Controls.Add(Me.lblTitle7)
        Me.fraLoader.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLoader.Location = New System.Drawing.Point(16, 62)
        Me.fraLoader.Name = "fraLoader"
        Me.fraLoader.Size = New System.Drawing.Size(778, 111)
        Me.fraLoader.TabIndex = 10
        Me.fraLoader.TabStop = false
        Me.fraLoader.Text = "工程運用条件"
        '
        'lblTransMode
        '
        Me.lblTransMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTransMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTransMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTransMode.Location = New System.Drawing.Point(357, 36)
        Me.lblTransMode.Name = "lblTransMode"
        Me.lblTransMode.Size = New System.Drawing.Size(333, 22)
        Me.lblTransMode.TabIndex = 18
        '
        'lblAfterCarrierTypeName
        '
        Me.lblAfterCarrierTypeName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblAfterCarrierTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAfterCarrierTypeName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblAfterCarrierTypeName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAfterCarrierTypeName.Location = New System.Drawing.Point(357, 82)
        Me.lblAfterCarrierTypeName.Name = "lblAfterCarrierTypeName"
        Me.lblAfterCarrierTypeName.Size = New System.Drawing.Size(333, 22)
        Me.lblAfterCarrierTypeName.TabIndex = 11
        '
        'lblBeforeCarrierTypeName
        '
        Me.lblBeforeCarrierTypeName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBeforeCarrierTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBeforeCarrierTypeName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBeforeCarrierTypeName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBeforeCarrierTypeName.Location = New System.Drawing.Point(8, 82)
        Me.lblBeforeCarrierTypeName.Name = "lblBeforeCarrierTypeName"
        Me.lblBeforeCarrierTypeName.Size = New System.Drawing.Size(333, 22)
        Me.lblBeforeCarrierTypeName.TabIndex = 12
        '
        'lblPortType
        '
        Me.lblPortType.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPortType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPortType.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPortType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPortType.Location = New System.Drawing.Point(8, 36)
        Me.lblPortType.Name = "lblPortType"
        Me.lblPortType.Size = New System.Drawing.Size(333, 22)
        Me.lblPortType.TabIndex = 15
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(8, 20)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(333, 17)
        Me.lblTitle5.TabIndex = 17
        Me.lblTitle5.Text = "ポート属性"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(357, 20)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(333, 17)
        Me.lblTitle1.TabIndex = 16
        Me.lblTitle1.Text = "移載モード"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(8, 66)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(333, 17)
        Me.lblTitle6.TabIndex = 14
        Me.lblTitle6.Text = "移載元キャリアタイプ名"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(357, 66)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(333, 17)
        Me.lblTitle7.TabIndex = 13
        Me.lblTitle7.Text = "移載先キャリアタイプ名"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraConData
        '
        Me.fraConData.Controls.Add(Me.txtWorkCondition)
        Me.fraConData.Controls.Add(Me.lblOptionWordCount)
        Me.fraConData.Controls.Add(Me.lblTitle4)
        Me.fraConData.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraConData.Location = New System.Drawing.Point(16, 176)
        Me.fraConData.Name = "fraConData"
        Me.fraConData.Size = New System.Drawing.Size(777, 61)
        Me.fraConData.TabIndex = 1
        Me.fraConData.Text = "Frame1"
        '
        'txtWorkCondition
        '
        Me.txtWorkCondition.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkCondition.ChrMaxByte = 128
        Me.txtWorkCondition.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtWorkCondition.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkCondition.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkCondition.Location = New System.Drawing.Point(0, 20)
        Me.txtWorkCondition.Name = "txtWorkCondition"
        Me.txtWorkCondition.NgChr = "'"
        Me.txtWorkCondition.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkCondition.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkCondition.SelectedText = ""
        Me.txtWorkCondition.Size = New System.Drawing.Size(779, 40)
        Me.txtWorkCondition.TabIndex = 0
        '
        'lblOptionWordCount
        '
        Me.lblOptionWordCount.AutoSize = true
        Me.lblOptionWordCount.BackColor = System.Drawing.Color.Navy
        Me.lblOptionWordCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOptionWordCount.ForeColor = System.Drawing.Color.White
        Me.lblOptionWordCount.Location = New System.Drawing.Point(566, 5)
        Me.lblOptionWordCount.Name = "lblOptionWordCount"
        Me.lblOptionWordCount.Size = New System.Drawing.Size(207, 15)
        Me.lblOptionWordCount.TabIndex = 9
        Me.lblOptionWordCount.Text = "（半角0文字/半角128文字）"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(0, 4)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(777, 17)
        Me.lblTitle4.TabIndex = 8
        Me.lblTitle4.Text = "作業条件"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 0
        Me.txtComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtComments.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtComments.GotHighLight = false
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtComments.Location = New System.Drawing.Point(16, 258)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(753, 38)
        Me.txtComments.TabIndex = 5
        Me.txtComments.TabStop = false
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(16, 242)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(753, 17)
        Me.lblTtl15.TabIndex = 19
        Me.lblTtl15.Text = "コメント"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(9, 598)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxEN01X3
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.stbRecipe)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.fraCondition)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 36)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01X3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "処理条件編集 "
        Me.stbRecipe.ResumeLayout(false)
        Me.Tab0.ResumeLayout(false)
        Me.Frame1.ResumeLayout(false)
        CType(Me.vsfUseWP,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfUseRecipe2,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab1.ResumeLayout(false)
        Me.fraUseRecipe.ResumeLayout(false)
        Me.fraUseRecipe.PerformLayout
        CType(Me.vsfUseRecipe1,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCondition.ResumeLayout(false)
        Me.fraLabel.ResumeLayout(false)
        Me.fraLoader.ResumeLayout(false)
        Me.fraConData.ResumeLayout(false)
        Me.fraConData.PerformLayout
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents stbRecipe As TabControl
    Friend WithEvents Tab0 As TabPage
    Friend WithEvents Frame1 As GroupBox
    Friend WithEvents Command3 As Button
    Friend WithEvents optRecipe2 As RadioButton
    Friend WithEvents optRecipe3 As RadioButton
    Friend WithEvents Command1 As Button
    Friend WithEvents vsfUseWP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfUseRecipe2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Tab1 As TabPage
    Friend WithEvents fraUseRecipe As GroupBox
    Friend WithEvents cmdRowAdd As Button
    Friend WithEvents optRecipe0 As RadioButton
    Friend WithEvents optRecipe1 As RadioButton
    Friend WithEvents cmdDelRecipe As Button
    Friend WithEvents vsfUseRecipe1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents fraCondition As GroupBox
    Friend WithEvents fraLabel As Panel
    Friend WithEvents lblTVer As Label
    Friend WithEvents lblTConditionId As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblConditionId As Label
    Friend WithEvents lblVer As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSkipFlag As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents fraLoader As GroupBox
    Friend WithEvents lblTransMode As Label
    Friend WithEvents lblAfterCarrierTypeName As Label
    Friend WithEvents lblBeforeCarrierTypeName As Label
    Friend WithEvents lblPortType As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents fraConData As Panel
    Friend WithEvents txtWorkCondition As SETextBoxEx.TextBoxEx
    Friend WithEvents lblOptionWordCount As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtRecipeFilter As SETextBoxEx.TextBoxEx
    Friend WithEvents Label2 As Label
End Class
