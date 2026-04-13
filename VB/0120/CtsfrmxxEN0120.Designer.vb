<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0120
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0120))
        Me.cmdWFStockSelect = New System.Windows.Forms.Button()
        Me.cmdResvLot = New System.Windows.Forms.Button()
        Me.cmdUseChange = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmbPrioSel = New SEComboBoxEx.ComboBoxEx()
        Me.vsfSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle12 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblPD = New System.Windows.Forms.Label()
        Me.lblWF = New System.Windows.Forms.Label()
        Me.lblThrowinDate = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblTitle11 = New System.Windows.Forms.Label()
        Me.lblBackGround = New System.Windows.Forms.Label()
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdWFStockSelect
        '
        Me.cmdWFStockSelect.CausesValidation = false
        Me.cmdWFStockSelect.Enabled = false
        Me.cmdWFStockSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFStockSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWFStockSelect.Location = New System.Drawing.Point(8, 92)
        Me.cmdWFStockSelect.Name = "cmdWFStockSelect"
        Me.cmdWFStockSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdWFStockSelect.TabIndex = 1
        Me.cmdWFStockSelect.Text = "中間WF在庫"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
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
        'cmdUseChange
        '
        Me.cmdUseChange.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUseChange.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUseChange.Location = New System.Drawing.Point(872, 580)
        Me.cmdUseChange.Name = "cmdUseChange"
        Me.cmdUseChange.Size = New System.Drawing.Size(105, 57)
        Me.cmdUseChange.TabIndex = 4
        Me.cmdUseChange.Text = "確　定"
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
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "閉じる"
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(764, 580)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "全部取消"
        '
        'cmbPrioSel
        '
        Me.cmbPrioSel.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPrioSel.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPrioSel.Location = New System.Drawing.Point(136, 176)
        Me.cmbPrioSel.Name = "cmbPrioSel"
        Me.cmbPrioSel.Size = New System.Drawing.Size(185, 28)
        Me.cmbPrioSel.TabIndex = 3
        Me.cmbPrioSel.Value = Nothing
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
        Me.vsfSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSlotMap.ExtendLastCol = true
        Me.vsfSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSlotMap.Location = New System.Drawing.Point(433, 92)
        Me.vsfSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSlotMap.Name = "vsfSlotMap"
        Me.vsfSlotMap.Rows.Count = 26
        Me.vsfSlotMap.Rows.DefaultSize = 17
        Me.vsfSlotMap.Rows.MinSize = 17
        Me.vsfSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfSlotMap.Size = New System.Drawing.Size(407, 443)
        Me.vsfSlotMap.StyleInfo = resources.GetString("vsfSlotMap.StyleInfo")
        Me.vsfSlotMap.TabIndex = 21
        Me.vsfSlotMap.TabStop = false
        '
        'txtCarrierID
        '
        Me.txtCarrierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(136, 92)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle4.TabIndex = 22
        Me.lblTitle4.Text = "キャリアID"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle12
        '
        Me.lblTitle12.BackColor = System.Drawing.Color.Navy
        Me.lblTitle12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle12.Location = New System.Drawing.Point(136, 160)
        Me.lblTitle12.Name = "lblTitle12"
        Me.lblTitle12.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle12.TabIndex = 20
        Me.lblTitle12.Text = "優先度"
        Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(136, 32)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 19
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(136, 16)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle6.TabIndex = 18
        Me.lblTitle6.Text = "ロットID"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblDivision.TabIndex = 17
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(660, 16)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(181, 17)
        Me.lblTitle5.TabIndex = 16
        Me.lblTitle5.Text = "ロット担当"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTitle3.TabIndex = 15
        Me.lblTitle3.Text = "投入予定日"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(320, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(65, 17)
        Me.lblTitle0.TabIndex = 14
        Me.lblTitle0.Text = "機種"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTitle2.TabIndex = 13
        Me.lblTitle2.Text = "数量"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblPD.TabIndex = 12
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
        Me.lblWF.TabIndex = 11
        Me.lblWF.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.lblThrowinDate.TabIndex = 10
        '
        'lblLotManager
        '
        Me.lblLotManager.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(660, 32)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(181, 25)
        Me.lblLotManager.TabIndex = 9
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
        Me.lblTitle11.TabIndex = 8
        Me.lblTitle11.Text = "種別"
        Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBackGround
        '
        Me.lblBackGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackGround.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBackGround.Location = New System.Drawing.Point(8, 8)
        Me.lblBackGround.Name = "lblBackGround"
        Me.lblBackGround.Size = New System.Drawing.Size(965, 73)
        Me.lblBackGround.TabIndex = 7
        '
        'frmxxEN0120
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdWFStockSelect)
        Me.Controls.Add(Me.cmdResvLot)
        Me.Controls.Add(Me.cmdUseChange)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmbPrioSel)
        Me.Controls.Add(Me.vsfSlotMap)
        Me.Controls.Add(Me.txtCarrierID)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblTitle12)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTitle6)
        Me.Controls.Add(Me.lblDivision)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblPD)
        Me.Controls.Add(Me.lblWF)
        Me.Controls.Add(Me.lblThrowinDate)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblTitle11)
        Me.Controls.Add(Me.lblBackGround)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0120"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ロット編成(保留/払出WF)"
        CType(Me.vsfSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdWFStockSelect As Button
    Friend WithEvents cmdResvLot As Button
    Friend WithEvents cmdUseChange As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmbPrioSel As SEComboBoxEx.ComboBoxEx
    Friend WithEvents vsfSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle12 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblDivision As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblPD As Label
    Friend WithEvents lblWF As Label
    Friend WithEvents lblThrowinDate As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents lblBackGround As Label
End Class
