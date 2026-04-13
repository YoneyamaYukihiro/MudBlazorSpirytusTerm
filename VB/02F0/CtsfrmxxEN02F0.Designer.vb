<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02F0
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02F0))
		Me.cmdJigSelect = New System.Windows.Forms.Button()
		Me.txtWfScan = New SETextBoxEx.TextBoxEx()
		Me.cmdEasyDivide = New System.Windows.Forms.Button()
		Me.cmdUpStck = New System.Windows.Forms.Button()
		Me.fraFromLot = New System.Windows.Forms.GroupBox()
		Me.vsfSlotMapStck = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.cmdClear = New System.Windows.Forms.Button()
		Me.cmdDownStck = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.cmdRegist = New System.Windows.Forms.Button()
		Me.txtCarrier = New SETextBoxEx.TextBoxEx()
		Me.lblTtl2 = New System.Windows.Forms.Label()
		Me.lblTtl1 = New System.Windows.Forms.Label()
		Me.lblFlowClass = New System.Windows.Forms.Label()
		Me.lblTtl0 = New System.Windows.Forms.Label()
		Me.lblLotID = New System.Windows.Forms.Label()
		Me.lblWFNo = New System.Windows.Forms.Label()
		Me.lblTtl5 = New System.Windows.Forms.Label()
		Me.lblTtl7 = New System.Windows.Forms.Label()
		Me.lblOpID = New System.Windows.Forms.Label()
		Me.lblStepID = New System.Windows.Forms.Label()
		Me.lblTtl8 = New System.Windows.Forms.Label()
		Me.lblStatus = New System.Windows.Forms.Label()
		Me.lblTtl14 = New System.Windows.Forms.Label()
		Me.lblBack = New System.Windows.Forms.Label()
		Me.cmdWorkStart = New System.Windows.Forms.Button()
		Me.cmdWorkEnd = New System.Windows.Forms.Button()
		Me.fraFromLot.SuspendLayout
		CType(Me.vsfSlotMapStck,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'cmdJigSelect
		'
		Me.cmdJigSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdJigSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdJigSelect.Location = New System.Drawing.Point(656, 580)
		Me.cmdJigSelect.Name = "cmdJigSelect"
		Me.cmdJigSelect.Size = New System.Drawing.Size(105, 57)
		Me.cmdJigSelect.TabIndex = 8
		Me.cmdJigSelect.Text = "空治具"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
		'
		'txtWfScan
		'
		Me.txtWfScan.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
		Me.txtWfScan.ChrMaxByte = 10
		Me.txtWfScan.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
		Me.txtWfScan.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtWfScan.Location = New System.Drawing.Point(616, 48)
		Me.txtWfScan.Name = "txtWfScan"
		Me.txtWfScan.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtWfScan.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtWfScan.SelectedText = ""
		Me.txtWfScan.Size = New System.Drawing.Size(297, 30)
		Me.txtWfScan.TabIndex = 1
		'
		'cmdEasyDivide
		'
		Me.cmdEasyDivide.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdEasyDivide.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdEasyDivide.Location = New System.Drawing.Point(480, 580)
		Me.cmdEasyDivide.Name = "cmdEasyDivide"
		Me.cmdEasyDivide.Size = New System.Drawing.Size(105, 57)
		Me.cmdEasyDivide.TabIndex = 7
		Me.cmdEasyDivide.Text = "簡　易"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"分　割"
		'
		'cmdUpStck
		'
		Me.cmdUpStck.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdUpStck.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdUpStck.Location = New System.Drawing.Point(921, 124)
		Me.cmdUpStck.Name = "cmdUpStck"
		Me.cmdUpStck.Size = New System.Drawing.Size(49, 225)
		Me.cmdUpStck.TabIndex = 3
		Me.cmdUpStck.Text = "▲"
		'
		'fraFromLot
		'
		Me.fraFromLot.Controls.Add(Me.vsfSlotMapStck)
		Me.fraFromLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.fraFromLot.Location = New System.Drawing.Point(8, 117)
		Me.fraFromLot.Name = "fraFromLot"
		Me.fraFromLot.Size = New System.Drawing.Size(913, 457)
		Me.fraFromLot.TabIndex = 2
		Me.fraFromLot.TabStop = false
		Me.fraFromLot.Text = "TFTロット情報"
		'
		'vsfSlotMapStck
		'
		Me.vsfSlotMapStck.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfSlotMapStck.AllowEditing = false
		Me.vsfSlotMapStck.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfSlotMapStck.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
		Me.vsfSlotMapStck.AutoSearchDelay = 2R
		Me.vsfSlotMapStck.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfSlotMapStck.ColumnInfo = resources.GetString("vsfSlotMapStck.ColumnInfo")
		Me.vsfSlotMapStck.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
		Me.vsfSlotMapStck.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfSlotMapStck.ExtendLastCol = true
		Me.vsfSlotMapStck.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfSlotMapStck.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
		Me.vsfSlotMapStck.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfSlotMapStck.Location = New System.Drawing.Point(8, 32)
		Me.vsfSlotMapStck.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfSlotMapStck.Name = "vsfSlotMapStck"
		Me.vsfSlotMapStck.Rows.Count = 25
		Me.vsfSlotMapStck.Rows.DefaultSize = 24
		Me.vsfSlotMapStck.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfSlotMapStck.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfSlotMapStck.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfSlotMapStck.Size = New System.Drawing.Size(895, 406)
		Me.vsfSlotMapStck.StyleInfo = resources.GetString("vsfSlotMapStck.StyleInfo")
		Me.vsfSlotMapStck.TabIndex = 2
		'
		'cmdClear
		'
		Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClear.Location = New System.Drawing.Point(764, 580)
		Me.cmdClear.Name = "cmdClear"
		Me.cmdClear.Size = New System.Drawing.Size(105, 57)
		Me.cmdClear.TabIndex = 9
		Me.cmdClear.Text = "紐付け解除"
		'
		'cmdDownStck
		'
		Me.cmdDownStck.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdDownStck.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdDownStck.Location = New System.Drawing.Point(921, 350)
		Me.cmdDownStck.Name = "cmdDownStck"
		Me.cmdDownStck.Size = New System.Drawing.Size(49, 225)
		Me.cmdDownStck.TabIndex = 4
		Me.cmdDownStck.Text = "▼"
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(8, 580)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(105, 57)
		Me.cmdClose.TabIndex = 11
		Me.cmdClose.Text = "閉じる"
		'
		'cmdRegist
		'
		Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdRegist.Location = New System.Drawing.Point(872, 580)
		Me.cmdRegist.Name = "cmdRegist"
		Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
		Me.cmdRegist.TabIndex = 10
		Me.cmdRegist.Text = "確　定"
		'
		'txtCarrier
		'
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
		'lblTtl2
		'
		Me.lblTtl2.BackColor = System.Drawing.Color.Navy
		Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl2.Location = New System.Drawing.Point(616, 32)
		Me.lblTtl2.Name = "lblTtl2"
		Me.lblTtl2.Size = New System.Drawing.Size(297, 17)
		Me.lblTtl2.TabIndex = 23
		Me.lblTtl2.Text = "WAFER スキャン"
		Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
		Me.lblTtl1.TabIndex = 22
		Me.lblTtl1.Text = "ロットID"
		Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblFlowClass
		'
		Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
		Me.lblFlowClass.Name = "lblFlowClass"
		Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
		Me.lblFlowClass.TabIndex = 21
		Me.lblFlowClass.Text = "ZZ"
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
		Me.lblTtl0.TabIndex = 20
		Me.lblTtl0.Text = "キャリアID"
		Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblLotID
		'
		Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblLotID.Location = New System.Drawing.Point(16, 80)
		Me.lblLotID.Name = "lblLotID"
		Me.lblLotID.Size = New System.Drawing.Size(121, 25)
		Me.lblLotID.TabIndex = 19
		Me.lblLotID.Text = "GTA1234-00"
		'
		'lblWFNo
		'
		Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblWFNo.Location = New System.Drawing.Point(216, 32)
		Me.lblWFNo.Name = "lblWFNo"
		Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
		Me.lblWFNo.TabIndex = 18
		Me.lblWFNo.Text = "8"
		Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTtl5
		'
		Me.lblTtl5.BackColor = System.Drawing.Color.Navy
		Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl5.Location = New System.Drawing.Point(216, 16)
		Me.lblTtl5.Name = "lblTtl5"
		Me.lblTtl5.Size = New System.Drawing.Size(97, 17)
		Me.lblTtl5.TabIndex = 17
		Me.lblTtl5.Text = "数量"
		Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTtl7
		'
		Me.lblTtl7.BackColor = System.Drawing.Color.Navy
		Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl7.Location = New System.Drawing.Point(312, 16)
		Me.lblTtl7.Name = "lblTtl7"
		Me.lblTtl7.Size = New System.Drawing.Size(281, 17)
		Me.lblTtl7.TabIndex = 16
		Me.lblTtl7.Text = "大工程"
		Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblOpID
		'
		Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblOpID.Location = New System.Drawing.Point(312, 32)
		Me.lblOpID.Name = "lblOpID"
		Me.lblOpID.Size = New System.Drawing.Size(281, 25)
		Me.lblOpID.TabIndex = 15
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
		Me.lblStepID.Size = New System.Drawing.Size(281, 25)
		Me.lblStepID.TabIndex = 14
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
		Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
		Me.lblTtl8.TabIndex = 13
		Me.lblTtl8.Text = "小工程"
		Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblStatus
		'
		Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblStatus.Location = New System.Drawing.Point(216, 80)
		Me.lblStatus.Name = "lblStatus"
		Me.lblStatus.Size = New System.Drawing.Size(97, 25)
		Me.lblStatus.TabIndex = 12
		Me.lblStatus.Text = "前処理"
		'
		'lblTtl14
		'
		Me.lblTtl14.BackColor = System.Drawing.Color.Navy
		Me.lblTtl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl14.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl14.Location = New System.Drawing.Point(216, 64)
		Me.lblTtl14.Name = "lblTtl14"
		Me.lblTtl14.Size = New System.Drawing.Size(97, 17)
		Me.lblTtl14.TabIndex = 11
		Me.lblTtl14.Text = "状態"
		Me.lblTtl14.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblBack
		'
		Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblBack.Location = New System.Drawing.Point(8, 8)
		Me.lblBack.Name = "lblBack"
		Me.lblBack.Size = New System.Drawing.Size(965, 105)
		Me.lblBack.TabIndex = 10
		'
		'cmdWorkStart
		'
		Me.cmdWorkStart.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdWorkStart.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdWorkStart.Location = New System.Drawing.Point(182, 580)
		Me.cmdWorkStart.Name = "cmdWorkStart"
		Me.cmdWorkStart.Size = New System.Drawing.Size(105, 57)
		Me.cmdWorkStart.TabIndex = 5
		Me.cmdWorkStart.Text = "作業開始"
		'
		'cmdWorkEnd
		'
		Me.cmdWorkEnd.CausesValidation = false
		Me.cmdWorkEnd.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdWorkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdWorkEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdWorkEnd.Location = New System.Drawing.Point(293, 580)
		Me.cmdWorkEnd.Name = "cmdWorkEnd"
		Me.cmdWorkEnd.Size = New System.Drawing.Size(105, 57)
		Me.cmdWorkEnd.TabIndex = 6
		Me.cmdWorkEnd.Text = "作業終了"
		'
		'frmxxEN02F0
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(985, 642)
		Me.Controls.Add(Me.cmdWorkEnd)
		Me.Controls.Add(Me.cmdWorkStart)
		Me.Controls.Add(Me.cmdJigSelect)
		Me.Controls.Add(Me.txtWfScan)
		Me.Controls.Add(Me.cmdEasyDivide)
		Me.Controls.Add(Me.cmdUpStck)
		Me.Controls.Add(Me.fraFromLot)
		Me.Controls.Add(Me.cmdClear)
		Me.Controls.Add(Me.cmdDownStck)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.cmdRegist)
		Me.Controls.Add(Me.txtCarrier)
		Me.Controls.Add(Me.lblTtl2)
		Me.Controls.Add(Me.lblTtl1)
		Me.Controls.Add(Me.lblFlowClass)
		Me.Controls.Add(Me.lblTtl0)
		Me.Controls.Add(Me.lblLotID)
		Me.Controls.Add(Me.lblWFNo)
		Me.Controls.Add(Me.lblTtl5)
		Me.Controls.Add(Me.lblTtl7)
		Me.Controls.Add(Me.lblOpID)
		Me.Controls.Add(Me.lblStepID)
		Me.Controls.Add(Me.lblTtl8)
		Me.Controls.Add(Me.lblStatus)
		Me.Controls.Add(Me.lblTtl14)
		Me.Controls.Add(Me.lblBack)
		Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN02F0"
		Me.Text = "治具ウェハーセット"
		Me.fraFromLot.ResumeLayout(false)
		CType(Me.vsfSlotMapStck,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdJigSelect As Button
    Friend WithEvents txtWfScan As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdEasyDivide As Button
    Friend WithEvents cmdUpStck As Button
    Friend WithEvents fraFromLot As GroupBox
    Friend WithEvents vsfSlotMapStck As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdDownStck As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl14 As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents cmdWorkStart As Button
    Friend WithEvents cmdWorkEnd As Button
End Class
