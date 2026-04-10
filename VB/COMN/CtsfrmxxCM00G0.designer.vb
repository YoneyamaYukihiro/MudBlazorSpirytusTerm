<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00G0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00G0))
        Me.cmdVsfDownWF = New System.Windows.Forms.Button()
        Me.cmdVsfUpWF = New System.Windows.Forms.Button()
        Me.cmdVsfDownCollect = New System.Windows.Forms.Button()
        Me.cmdVsfUpCollect = New System.Windows.Forms.Button()
        Me.cmdVsfDownCollectValue = New System.Windows.Forms.Button()
        Me.cmdVsfUpCollectValue = New System.Windows.Forms.Button()
        Me.fraDataUnit = New System.Windows.Forms.Panel()
        Me.optDataUnit2 = New System.Windows.Forms.RadioButton()
        Me.optDataUnit1 = New System.Windows.Forms.RadioButton()
        Me.cmdLineInsert = New System.Windows.Forms.Button()
        Me.cmdLineDelete = New System.Windows.Forms.Button()
        Me.cmdNaInput = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.txtLot = New SETextBoxEx.TextBoxEx()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfCollect = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfCollectValue = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblRetainColor = New System.Windows.Forms.Label()
        Me.lblDataUnit = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblInputNoColor = New System.Windows.Forms.Label()
        Me.lblSumiColor = New System.Windows.Forms.Label()
        Me.lblWpName = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblMesMode = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.fraDataUnit.SuspendLayout
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfCollect,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfCollectValue,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdVsfDownWF
        '
        Me.cmdVsfDownWF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfDownWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfDownWF.Location = New System.Drawing.Point(202, 365)
        Me.cmdVsfDownWF.Name = "cmdVsfDownWF"
        Me.cmdVsfDownWF.Size = New System.Drawing.Size(49, 205)
        Me.cmdVsfDownWF.TabIndex = 37
        Me.cmdVsfDownWF.Text = "▼"
        '
        'cmdVsfUpWF
        '
        Me.cmdVsfUpWF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfUpWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfUpWF.Location = New System.Drawing.Point(202, 159)
        Me.cmdVsfUpWF.Name = "cmdVsfUpWF"
        Me.cmdVsfUpWF.Size = New System.Drawing.Size(49, 205)
        Me.cmdVsfUpWF.TabIndex = 36
        Me.cmdVsfUpWF.Text = "▲"
        '
        'cmdVsfDownCollect
        '
        Me.cmdVsfDownCollect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfDownCollect.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfDownCollect.Location = New System.Drawing.Point(920, 269)
        Me.cmdVsfDownCollect.Name = "cmdVsfDownCollect"
        Me.cmdVsfDownCollect.Size = New System.Drawing.Size(49, 111)
        Me.cmdVsfDownCollect.TabIndex = 35
        Me.cmdVsfDownCollect.Text = "▼"
        '
        'cmdVsfUpCollect
        '
        Me.cmdVsfUpCollect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfUpCollect.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfUpCollect.Location = New System.Drawing.Point(920, 158)
        Me.cmdVsfUpCollect.Name = "cmdVsfUpCollect"
        Me.cmdVsfUpCollect.Size = New System.Drawing.Size(49, 111)
        Me.cmdVsfUpCollect.TabIndex = 34
        Me.cmdVsfUpCollect.Text = "▲"
        '
        'cmdVsfDownCollectValue
        '
        Me.cmdVsfDownCollectValue.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfDownCollectValue.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfDownCollectValue.Location = New System.Drawing.Point(920, 482)
        Me.cmdVsfDownCollectValue.Name = "cmdVsfDownCollectValue"
        Me.cmdVsfDownCollectValue.Size = New System.Drawing.Size(49, 92)
        Me.cmdVsfDownCollectValue.TabIndex = 33
        Me.cmdVsfDownCollectValue.Text = "▼"
        '
        'cmdVsfUpCollectValue
        '
        Me.cmdVsfUpCollectValue.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfUpCollectValue.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfUpCollectValue.Location = New System.Drawing.Point(920, 390)
        Me.cmdVsfUpCollectValue.Name = "cmdVsfUpCollectValue"
        Me.cmdVsfUpCollectValue.Size = New System.Drawing.Size(49, 92)
        Me.cmdVsfUpCollectValue.TabIndex = 32
        Me.cmdVsfUpCollectValue.Text = "▲"
        '
        'fraDataUnit
        '
        Me.fraDataUnit.Controls.Add(Me.optDataUnit2)
        Me.fraDataUnit.Controls.Add(Me.optDataUnit1)
        Me.fraDataUnit.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraDataUnit.Location = New System.Drawing.Point(395, 123)
        Me.fraDataUnit.Name = "fraDataUnit"
        Me.fraDataUnit.Size = New System.Drawing.Size(233, 33)
        Me.fraDataUnit.TabIndex = 2
        '
        'optDataUnit2
        '
        Me.optDataUnit2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optDataUnit2.Location = New System.Drawing.Point(144, 8)
        Me.optDataUnit2.Name = "optDataUnit2"
        Me.optDataUnit2.Size = New System.Drawing.Size(77, 21)
        Me.optDataUnit2.TabIndex = 3
        Me.optDataUnit2.Text = "WF単位"
        '
        'optDataUnit1
        '
        Me.optDataUnit1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optDataUnit1.Location = New System.Drawing.Point(16, 8)
        Me.optDataUnit1.Name = "optDataUnit1"
        Me.optDataUnit1.Size = New System.Drawing.Size(106, 21)
        Me.optDataUnit1.TabIndex = 2
        Me.optDataUnit1.Text = "ロット単位"
        '
        'cmdLineInsert
        '
        Me.cmdLineInsert.CausesValidation = false
        Me.cmdLineInsert.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLineInsert.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLineInsert.Location = New System.Drawing.Point(600, 598)
        Me.cmdLineInsert.Name = "cmdLineInsert"
        Me.cmdLineInsert.Size = New System.Drawing.Size(85, 40)
        Me.cmdLineInsert.TabIndex = 8
        Me.cmdLineInsert.Text = "行挿入"
        '
        'cmdLineDelete
        '
        Me.cmdLineDelete.CausesValidation = false
        Me.cmdLineDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLineDelete.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLineDelete.Location = New System.Drawing.Point(696, 598)
        Me.cmdLineDelete.Name = "cmdLineDelete"
        Me.cmdLineDelete.Size = New System.Drawing.Size(85, 40)
        Me.cmdLineDelete.TabIndex = 9
        Me.cmdLineDelete.Text = "行削除"
        '
        'cmdNaInput
        '
        Me.cmdNaInput.CausesValidation = false
        Me.cmdNaInput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNaInput.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNaInput.Location = New System.Drawing.Point(792, 598)
        Me.cmdNaInput.Name = "cmdNaInput"
        Me.cmdNaInput.Size = New System.Drawing.Size(85, 40)
        Me.cmdNaInput.TabIndex = 10
        Me.cmdNaInput.Text = "値未入力"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"（N/A）"
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
        Me.cmdClose.TabIndex = 11
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 598)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 7
        Me.cmdRegist.Text = "確　定"
        '
        'txtCarrier
        '
        Me.txtCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'txtLot
        '
        Me.txtLot.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtLot.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLot.ChrMaxByte = 10
        Me.txtLot.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtLot.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLot.Location = New System.Drawing.Point(16, 80)
        Me.txtLot.Name = "txtLot"
        Me.txtLot.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLot.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLot.SelectedText = ""
        Me.txtLot.Size = New System.Drawing.Size(119, 30)
        Me.txtLot.TabIndex = 1
        '
        'vsfSlotMap
        '
        Me.vsfSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap.AllowEditing = false
        Me.vsfSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap.AutoSearchDelay = 2R
        Me.vsfSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap.ColumnInfo = resources.GetString("vsfSlotMap.ColumnInfo")
        Me.vsfSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap.Location = New System.Drawing.Point(8, 160)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 26
        Me.vsfSlotMap.Rows.DefaultSize = 18
        Me.vsfSlotMap.Rows.MaxSize = 38
        Me.vsfSlotMap.Rows.MinSize = 27
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap.Size = New System.Drawing.Size(197, 409)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 4
        '
        'vsfCollect
        '
        Me.vsfCollect.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCollect.AllowEditing = false
        Me.vsfCollect.AutoResize = true
        Me.vsfCollect.AutoSearchDelay = 2R
        Me.vsfCollect.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCollect.ColumnInfo = resources.GetString("vsfCollect.ColumnInfo")
        Me.vsfCollect.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCollect.ExtendLastCol = true
        Me.vsfCollect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCollect.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCollect.Location = New System.Drawing.Point(256, 160)
        Me.vsfCollect.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCollect.Name = "vsfCollect"
        Me.vsfCollect.Rows.DefaultSize = 18
        Me.vsfCollect.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfCollect.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCollect.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCollect.Size = New System.Drawing.Size(664, 219)
        Me.vsfCollect.StyleInfo = resources.GetString("vsfCollect.StyleInfo")
        Me.vsfCollect.TabIndex = 5
        '
        'vsfCollectValue
        '
        Me.vsfCollectValue.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCollectValue.AllowEditing = false
        Me.vsfCollectValue.AutoResize = true
        Me.vsfCollectValue.AutoSearchDelay = 2R
        Me.vsfCollectValue.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCollectValue.ColumnInfo = resources.GetString("vsfCollectValue.ColumnInfo")
        Me.vsfCollectValue.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCollectValue.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCollectValue.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCollectValue.Location = New System.Drawing.Point(256, 392)
        Me.vsfCollectValue.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCollectValue.Name = "vsfCollectValue"
        Me.vsfCollectValue.Rows.DefaultSize = 18
        Me.vsfCollectValue.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfCollectValue.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCollectValue.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfCollectValue.Size = New System.Drawing.Size(665, 181)
        Me.vsfCollectValue.StyleInfo = resources.GetString("vsfCollectValue.StyleInfo")
        Me.vsfCollectValue.TabIndex = 6
        '
        'lblRetainColor
        '
        Me.lblRetainColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblRetainColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRetainColor.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRetainColor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRetainColor.Location = New System.Drawing.Point(654, 123)
        Me.lblRetainColor.Name = "lblRetainColor"
        Me.lblRetainColor.Size = New System.Drawing.Size(86, 19)
        Me.lblRetainColor.TabIndex = 31
        Me.lblRetainColor.Text = "引継情報"
        Me.lblRetainColor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDataUnit
        '
        Me.lblDataUnit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDataUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataUnit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDataUnit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDataUnit.Location = New System.Drawing.Point(380, 120)
        Me.lblDataUnit.Name = "lblDataUnit"
        Me.lblDataUnit.Size = New System.Drawing.Size(251, 38)
        Me.lblDataUnit.TabIndex = 29
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(256, 120)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(125, 38)
        Me.lblTtl5.TabIndex = 28
        Me.lblTtl5.Text = "データ処理単位"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblInputNoColor
        '
        Me.lblInputNoColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.lblInputNoColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInputNoColor.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInputNoColor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInputNoColor.Location = New System.Drawing.Point(899, 123)
        Me.lblInputNoColor.Name = "lblInputNoColor"
        Me.lblInputNoColor.Size = New System.Drawing.Size(74, 19)
        Me.lblInputNoColor.TabIndex = 27
        Me.lblInputNoColor.Text = "入力不可"
        Me.lblInputNoColor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSumiColor
        '
        Me.lblSumiColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblSumiColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSumiColor.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSumiColor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSumiColor.Location = New System.Drawing.Point(737, 123)
        Me.lblSumiColor.Name = "lblSumiColor"
        Me.lblSumiColor.Size = New System.Drawing.Size(164, 19)
        Me.lblSumiColor.TabIndex = 26
        Me.lblSumiColor.Text = "収集不要／入力済み"
        Me.lblSumiColor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWpName
        '
        Me.lblWpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWpName.Location = New System.Drawing.Point(622, 32)
        Me.lblWpName.Name = "lblWpName"
        Me.lblWpName.Size = New System.Drawing.Size(343, 30)
        Me.lblWpName.TabIndex = 25
        Me.lblWpName.Text = "123456789012345678901234567890"
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(622, 16)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(343, 17)
        Me.lblTtl4.TabIndex = 24
        Me.lblTtl4.Text = "装置名"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(312, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(311, 17)
        Me.lblTtl3.TabIndex = 23
        Me.lblTtl3.Text = "大工程"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(312, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(311, 30)
        Me.lblOpID.TabIndex = 22
        Me.lblOpID.Text = "投入"
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(312, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(311, 30)
        Me.lblStepID.TabIndex = 21
        Me.lblStepID.Text = "ﾅﾝﾊﾞﾘﾝｸﾞ"
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(312, 64)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(311, 17)
        Me.lblTtl8.TabIndex = 20
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(216, 64)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl7.TabIndex = 19
        Me.lblTtl7.Text = "運用モード"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMesMode
        '
        Me.lblMesMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMesMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMesMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMesMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMesMode.Location = New System.Drawing.Point(216, 80)
        Me.lblMesMode.Name = "lblMesMode"
        Me.lblMesMode.Size = New System.Drawing.Size(97, 30)
        Me.lblMesMode.TabIndex = 18
        Me.lblMesMode.Text = "M1"
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl2.TabIndex = 17
        Me.lblTtl2.Text = "数量"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(216, 32)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 30)
        Me.lblWFNo.TabIndex = 16
        Me.lblWFNo.Text = "10"
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(16, 16)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl0.TabIndex = 15
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 30)
        Me.lblFlowClass.TabIndex = 14
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(16, 64)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 13
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 108)
        Me.lblBack.TabIndex = 12
        '
        'frmxxCM00G0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdVsfDownWF)
        Me.Controls.Add(Me.cmdVsfUpWF)
        Me.Controls.Add(Me.cmdVsfDownCollect)
        Me.Controls.Add(Me.cmdVsfUpCollect)
        Me.Controls.Add(Me.cmdVsfDownCollectValue)
        Me.Controls.Add(Me.cmdVsfUpCollectValue)
        Me.Controls.Add(Me.fraDataUnit)
        Me.Controls.Add(Me.cmdLineInsert)
        Me.Controls.Add(Me.cmdLineDelete)
        Me.Controls.Add(Me.cmdNaInput)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.txtLot)
        Me.Controls.Add(Me.vsfSlotMap)
        Me.Controls.Add(Me.vsfCollect)
        Me.Controls.Add(Me.vsfCollectValue)
        Me.Controls.Add(Me.lblRetainColor)
        Me.Controls.Add(Me.lblDataUnit)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblInputNoColor)
        Me.Controls.Add(Me.lblSumiColor)
        Me.Controls.Add(Me.lblWpName)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblMesMode)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00G0"
        Me.Text = "装置データ登録／参照"
        Me.fraDataUnit.ResumeLayout(false)
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfCollect,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfCollectValue,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdVsfDownWF As Button
    Friend WithEvents cmdVsfUpWF As Button
    Friend WithEvents cmdVsfDownCollect As Button
    Friend WithEvents cmdVsfUpCollect As Button
    Friend WithEvents cmdVsfDownCollectValue As Button
    Friend WithEvents cmdVsfUpCollectValue As Button
    Friend WithEvents fraDataUnit As Panel
    Friend WithEvents optDataUnit2 As RadioButton
    Friend WithEvents optDataUnit1 As RadioButton
    Friend WithEvents cmdLineInsert As Button
    Friend WithEvents cmdLineDelete As Button
    Friend WithEvents cmdNaInput As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents txtLot As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfCollect As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfCollectValue As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblRetainColor As Label
    Friend WithEvents lblDataUnit As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblInputNoColor As Label
    Friend WithEvents lblSumiColor As Label
    Friend WithEvents lblWpName As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblMesMode As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblBack As Label
End Class
