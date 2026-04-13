<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0040
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0040))
        Me.fraBack = New System.Windows.Forms.Panel()
        Me.optOnlineflg1 = New System.Windows.Forms.RadioButton()
        Me.optOnlineflg0 = New System.Windows.Forms.RadioButton()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.cmbPartName = New SEComboBoxEx.ComboBoxEx()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdVenderLot = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdResvLot = New System.Windows.Forms.Button()
        Me.cmbPrioSel = New SEComboBoxEx.ComboBoxEx()
        Me.cmbThrowinWP = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblFrame1 = New System.Windows.Forms.Label()
        Me.lblTitle13 = New System.Windows.Forms.Label()
        Me.lblProductionLotID = New System.Windows.Forms.Label()
        Me.lblTitle12 = New System.Windows.Forms.Label()
        Me.lblTitle11 = New System.Windows.Forms.Label()
        Me.lblInvLotID = New System.Windows.Forms.Label()
        Me.lblVenderName = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblThrowinDate = New System.Windows.Forms.Label()
        Me.lblWF = New System.Windows.Forms.Label()
        Me.lblPD = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.lblInvNum = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblBackGround = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.labLaserMark = New System.Windows.Forms.Label()
        Me.fraBack.SuspendLayout
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraBack
        '
        Me.fraBack.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraBack.Controls.Add(Me.optOnlineflg1)
        Me.fraBack.Controls.Add(Me.optOnlineflg0)
        Me.fraBack.Location = New System.Drawing.Point(141, 457)
        Me.fraBack.Name = "fraBack"
        Me.fraBack.Size = New System.Drawing.Size(403, 51)
        Me.fraBack.TabIndex = 6
        '
        'optOnlineflg1
        '
        Me.optOnlineflg1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optOnlineflg1.Location = New System.Drawing.Point(13, 1)
        Me.optOnlineflg1.Name = "optOnlineflg1"
        Me.optOnlineflg1.Size = New System.Drawing.Size(178, 52)
        Me.optOnlineflg1.TabIndex = 6
        Me.optOnlineflg1.Text = "オンライン"
        '
        'optOnlineflg0
        '
        Me.optOnlineflg0.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optOnlineflg0.Location = New System.Drawing.Point(209, 1)
        Me.optOnlineflg0.Name = "optOnlineflg0"
        Me.optOnlineflg0.Size = New System.Drawing.Size(178, 52)
        Me.optOnlineflg0.TabIndex = 7
        Me.optOnlineflg0.Text = "オフライン"
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(8, 92)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdCarrierSelect.TabIndex = 1
        Me.cmdCarrierSelect.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmbPartName
        '
        Me.cmbPartName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartName.Location = New System.Drawing.Point(8, 176)
        Me.cmbPartName.Name = "cmbPartName"
        Me.cmbPartName.Size = New System.Drawing.Size(550, 28)
        Me.cmbPartName.TabIndex = 3
        Me.cmbPartName.Value = Nothing
        '
        'txtCarrierID
        '
        Me.txtCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID.ChrMaxByte = 6
        Me.txtCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID.Location = New System.Drawing.Point(136, 108)
        Me.txtCarrierID.Name = "txtCarrierID"
        Me.txtCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID.SelectedText = ""
        Me.txtCarrierID.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrierID.TabIndex = 2
        '
        'vsfSlotMap
        '
        Me.vsfSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSlotMap.AllowEditing = false
        Me.vsfSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfSlotMap.AutoResize = true
        Me.vsfSlotMap.AutoSearchDelay = 2R
        Me.vsfSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSlotMap.ColumnInfo = resources.GetString("vsfSlotMap.ColumnInfo")
        Me.vsfSlotMap.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.vsfSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap.ExtendLastCol = true
        Me.vsfSlotMap.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap.Location = New System.Drawing.Point(567, 159)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 25
        Me.vsfSlotMap.Rows.DefaultSize = 18
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfSlotMap.Size = New System.Drawing.Size(361, 409)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 9
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(926, 363)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 206)
        Me.cmdDown.TabIndex = 11
        Me.cmdDown.Text = "▼"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp.Location = New System.Drawing.Point(926, 158)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(49, 206)
        Me.cmdUp.TabIndex = 10
        Me.cmdUp.Text = "▲"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 574)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.Text = "閉じる"
        '
        'cmdVenderLot
        '
        Me.cmdVenderLot.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVenderLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVenderLot.Location = New System.Drawing.Point(8, 269)
        Me.cmdVenderLot.Name = "cmdVenderLot"
        Me.cmdVenderLot.Size = New System.Drawing.Size(105, 57)
        Me.cmdVenderLot.TabIndex = 4
        Me.cmdVenderLot.Text = "在庫ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 574)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 12
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClear
        '
        Me.cmdClear.CausesValidation = false
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(764, 574)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdClear.TabIndex = 13
        Me.cmdClear.Text = "全部取消"
        '
        'cmdResvLot
        '
        Me.cmdResvLot.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdResvLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdResvLot.Location = New System.Drawing.Point(16, 16)
        Me.cmdResvLot.Name = "cmdResvLot"
        Me.cmdResvLot.Size = New System.Drawing.Size(105, 57)
        Me.cmdResvLot.TabIndex = 0
        Me.cmdResvLot.Text = "投入予定"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ロット選択"
        '
        'cmbPrioSel
        '
        Me.cmbPrioSel.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPrioSel.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPrioSel.Location = New System.Drawing.Point(136, 392)
        Me.cmbPrioSel.Name = "cmbPrioSel"
        Me.cmbPrioSel.Size = New System.Drawing.Size(280, 28)
        Me.cmbPrioSel.TabIndex = 5
        Me.cmbPrioSel.Value = Nothing
        '
        'cmbThrowinWP
        '
        Me.cmbThrowinWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbThrowinWP.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbThrowinWP.Location = New System.Drawing.Point(136, 540)
        Me.cmbThrowinWP.Name = "cmbThrowinWP"
        Me.cmbThrowinWP.Size = New System.Drawing.Size(419, 28)
        Me.cmbThrowinWP.TabIndex = 8
        Me.cmbThrowinWP.Value = Nothing
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(136, 524)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(419, 17)
        Me.lblTitle7.TabIndex = 42
        Me.lblTitle7.Text = "投入装置"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(136, 436)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(419, 17)
        Me.lblTtl2.TabIndex = 40
        Me.lblTtl2.Text = "処理形態"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFrame1
        '
        Me.lblFrame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFrame1.Location = New System.Drawing.Point(136, 453)
        Me.lblFrame1.Name = "lblFrame1"
        Me.lblFrame1.Size = New System.Drawing.Size(419, 58)
        Me.lblFrame1.TabIndex = 39
        '
        'lblTitle13
        '
        Me.lblTitle13.BackColor = System.Drawing.Color.Navy
        Me.lblTitle13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle13.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle13.Location = New System.Drawing.Point(136, 322)
        Me.lblTitle13.Name = "lblTitle13"
        Me.lblTitle13.Size = New System.Drawing.Size(280, 17)
        Me.lblTitle13.TabIndex = 38
        Me.lblTitle13.Text = "製造ロットID"
        Me.lblTitle13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblProductionLotID
        '
        Me.lblProductionLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProductionLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductionLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProductionLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProductionLotID.Location = New System.Drawing.Point(136, 338)
        Me.lblProductionLotID.Name = "lblProductionLotID"
        Me.lblProductionLotID.Size = New System.Drawing.Size(280, 25)
        Me.lblProductionLotID.TabIndex = 37
        '
        'lblTitle12
        '
        Me.lblTitle12.BackColor = System.Drawing.Color.Navy
        Me.lblTitle12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle12.Location = New System.Drawing.Point(136, 376)
        Me.lblTitle12.Name = "lblTitle12"
        Me.lblTitle12.Size = New System.Drawing.Size(280, 17)
        Me.lblTitle12.TabIndex = 36
        Me.lblTitle12.Text = "優先度"
        Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle11
        '
        Me.lblTitle11.BackColor = System.Drawing.Color.Navy
        Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle11.Location = New System.Drawing.Point(256, 16)
        Me.lblTitle11.Name = "lblTitle11"
        Me.lblTitle11.Size = New System.Drawing.Size(65, 17)
        Me.lblTitle11.TabIndex = 35
        Me.lblTitle11.Text = "種別"
        Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblInvLotID
        '
        Me.lblInvLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblInvLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInvLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInvLotID.Location = New System.Drawing.Point(136, 285)
        Me.lblInvLotID.Name = "lblInvLotID"
        Me.lblInvLotID.Size = New System.Drawing.Size(281, 25)
        Me.lblInvLotID.TabIndex = 33
        '
        'lblVenderName
        '
        Me.lblVenderName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblVenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVenderName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVenderName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVenderName.Location = New System.Drawing.Point(8, 232)
        Me.lblVenderName.Name = "lblVenderName"
        Me.lblVenderName.Size = New System.Drawing.Size(550, 25)
        Me.lblVenderName.TabIndex = 32
        '
        'lblLotManager
        '
        Me.lblLotManager.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(660, 32)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(183, 25)
        Me.lblLotManager.TabIndex = 31
        '
        'lblThrowinDate
        '
        Me.lblThrowinDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblThrowinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowinDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowinDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblThrowinDate.Location = New System.Drawing.Point(480, 32)
        Me.lblThrowinDate.Name = "lblThrowinDate"
        Me.lblThrowinDate.Size = New System.Drawing.Size(181, 25)
        Me.lblThrowinDate.TabIndex = 30
        '
        'lblWF
        '
        Me.lblWF.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWF.Location = New System.Drawing.Point(384, 32)
        Me.lblWF.Name = "lblWF"
        Me.lblWF.Size = New System.Drawing.Size(97, 25)
        Me.lblWF.TabIndex = 29
        Me.lblWF.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPD
        '
        Me.lblPD.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPD.Location = New System.Drawing.Point(320, 32)
        Me.lblPD.Name = "lblPD"
        Me.lblPD.Size = New System.Drawing.Size(65, 25)
        Me.lblPD.TabIndex = 28
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(384, 16)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle2.TabIndex = 27
        Me.lblTitle2.Text = "数量"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(320, 16)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(65, 17)
        Me.lblTitle1.TabIndex = 26
        Me.lblTitle1.Text = "機種"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(480, 16)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(181, 17)
        Me.lblTitle3.TabIndex = 25
        Me.lblTitle3.Text = "投入予定日"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(660, 16)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(183, 17)
        Me.lblTitle4.TabIndex = 24
        Me.lblTitle4.Text = "ロット担当"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDivision
        '
        Me.lblDivision.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDivision.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDivision.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDivision.Location = New System.Drawing.Point(256, 32)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(65, 25)
        Me.lblDivision.TabIndex = 23
        '
        'lblInvNum
        '
        Me.lblInvNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblInvNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInvNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInvNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInvNum.Location = New System.Drawing.Point(414, 285)
        Me.lblInvNum.Name = "lblInvNum"
        Me.lblInvNum.Size = New System.Drawing.Size(144, 25)
        Me.lblInvNum.TabIndex = 22
        Me.lblInvNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(136, 92)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle5.TabIndex = 21
        Me.lblTitle5.Text = "キャリアID"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(8, 160)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(550, 17)
        Me.lblTitle6.TabIndex = 20
        Me.lblTitle6.Text = "利用部材"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(8, 216)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(550, 17)
        Me.lblTitle8.TabIndex = 19
        Me.lblTitle8.Text = "ベンダー"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(136, 269)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(281, 17)
        Me.lblTitle9.TabIndex = 18
        Me.lblTitle9.Text = "在庫ロットID"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(414, 269)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(144, 17)
        Me.lblTitle10.TabIndex = 17
        Me.lblTitle10.Text = "在庫数"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(136, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(124, 17)
        Me.lblTitle0.TabIndex = 16
        Me.lblTitle0.Text = "ロットID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(136, 32)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(124, 25)
        Me.lblLotID.TabIndex = 15
        '
        'lblBackGround
        '
        Me.lblBackGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackGround.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBackGround.Location = New System.Drawing.Point(8, 9)
        Me.lblBackGround.Name = "lblBackGround"
        Me.lblBackGround.Size = New System.Drawing.Size(966, 73)
        Me.lblBackGround.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Navy
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(842, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 17)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "ﾚｰｻﾞｰﾏｰｶｰ"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labLaserMark
        '
        Me.labLaserMark.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labLaserMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labLaserMark.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labLaserMark.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labLaserMark.Location = New System.Drawing.Point(842, 32)
        Me.labLaserMark.Name = "labLaserMark"
        Me.labLaserMark.Size = New System.Drawing.Size(115, 25)
        Me.labLaserMark.TabIndex = 44
        '
        'frmxxEN0040
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.labLaserMark)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblTitle11)
        Me.Controls.Add(Me.fraBack)
        Me.Controls.Add(Me.cmdCarrierSelect)
        Me.Controls.Add(Me.cmbPartName)
        Me.Controls.Add(Me.txtCarrierID)
        Me.Controls.Add(Me.vsfSlotMap)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdVenderLot)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdResvLot)
        Me.Controls.Add(Me.cmbPrioSel)
        Me.Controls.Add(Me.cmbThrowinWP)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblFrame1)
        Me.Controls.Add(Me.lblTitle13)
        Me.Controls.Add(Me.lblProductionLotID)
        Me.Controls.Add(Me.lblTitle12)
        Me.Controls.Add(Me.lblInvLotID)
        Me.Controls.Add(Me.lblVenderName)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblThrowinDate)
        Me.Controls.Add(Me.lblWF)
        Me.Controls.Add(Me.lblPD)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblDivision)
        Me.Controls.Add(Me.lblInvNum)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblTitle6)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblTitle9)
        Me.Controls.Add(Me.lblTitle10)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblBackGround)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0040"
        Me.Text = "ロット投入（基板）"
        Me.fraBack.ResumeLayout(false)
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraBack As Panel
    Friend WithEvents optOnlineflg1 As RadioButton
    Friend WithEvents optOnlineflg0 As RadioButton
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents cmbPartName As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdVenderLot As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdResvLot As Button
    Friend WithEvents cmbPrioSel As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbThrowinWP As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblFrame1 As Label
    Friend WithEvents lblTitle13 As Label
    Friend WithEvents lblProductionLotID As Label
    Friend WithEvents lblTitle12 As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents lblInvLotID As Label
    Friend WithEvents lblVenderName As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblThrowinDate As Label
    Friend WithEvents lblWF As Label
    Friend WithEvents lblPD As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents lblInvNum As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblBackGround As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents labLaserMark As Label
End Class
