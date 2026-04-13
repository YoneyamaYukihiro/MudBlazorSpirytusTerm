<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02C0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02C0))
        Me.cmdScrap = New System.Windows.Forms.Button()
        Me.cmdKonsei = New System.Windows.Forms.Button()
        Me.fraThrowinWP = New System.Windows.Forms.GroupBox()
        Me.cmbThrowinWP = New SEComboBoxEx.ComboBoxEx()
        Me.lblThrowinWPTitle = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdAllClear = New System.Windows.Forms.Button()
        Me.fraThrow = New System.Windows.Forms.GroupBox()
        Me.lblPdTitle1 = New System.Windows.Forms.Label()
        Me.lblScreenSizeTitle = New System.Windows.Forms.Label()
        Me.lblPdTitle0 = New System.Windows.Forms.Label()
        Me.cmdEntry = New System.Windows.Forms.Button()
        Me.cmbScreenSize = New SEComboBoxEx.ComboBoxEx()
        Me.cmbPd = New SEComboBoxEx.ComboBoxEx()
        Me.cmbFlowClass = New SEComboBoxEx.ComboBoxEx()
        Me.lblEntryID = New System.Windows.Forms.Label()
        Me.lblEntryIDTitle = New System.Windows.Forms.Label()
        Me.fraCF = New System.Windows.Forms.GroupBox()
        Me.lblJigIDTitle = New System.Windows.Forms.Label()
        Me.lblLotManagerTitle = New System.Windows.Forms.Label()
        Me.cmdJigSelect = New System.Windows.Forms.Button()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.vsfJigList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtJig0 = New SETextBoxEx.TextBoxEx()
        Me.txtJig1 = New SETextBoxEx.TextBoxEx()
        Me.txtJig2 = New SETextBoxEx.TextBoxEx()
        Me.txtJig3 = New SETextBoxEx.TextBoxEx()
        Me.txtJig4 = New SETextBoxEx.TextBoxEx()
        Me.cmbLotManager = New SEComboBoxEx.ComboBoxEx()
        Me.lblNumberTitle = New System.Windows.Forms.Label()
        Me.lblTtl13 = New System.Windows.Forms.Label()
        Me.lblMaxNum = New System.Windows.Forms.Label()
        Me.lblThrowNum = New System.Windows.Forms.Label()
        Me.lblThrowNumTitle = New System.Windows.Forms.Label()
        Me.lblLotIDTitle = New System.Windows.Forms.Label()
        Me.lblCFLotID = New System.Windows.Forms.Label()
        Me.lblCarrierIDTitle = New System.Windows.Forms.Label()
        Me.txtNumber = New SETextBoxEx.TextBoxEx()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.fraPart = New System.Windows.Forms.GroupBox()
        Me.lblVenderName = New System.Windows.Forms.Label()
        Me.lblReworkTitle = New System.Windows.Forms.Label()
        Me.lblBoardThicknessTitle = New System.Windows.Forms.Label()
        Me.lblPartTitle = New System.Windows.Forms.Label()
        Me.cmbPart = New SECmbIchiran.ComboIchiran()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmbBoardThickness = New SEComboBoxEx.ComboBoxEx()
        Me.cmbRework = New SEComboBoxEx.ComboBoxEx()
        Me.vsfInvLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitleHT1 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblNowDateTitle = New System.Windows.Forms.Label()
        Me.lblLotCntTitle = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblVenderNameTitle = New System.Windows.Forms.Label()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraThrowinWP.SuspendLayout
        Me.fraThrow.SuspendLayout
        Me.fraCF.SuspendLayout
        CType(Me.vsfJigList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.lblTtl13.SuspendLayout
        Me.fraPart.SuspendLayout
        CType(Me.vsfInvLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdScrap
        '
        Me.cmdScrap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScrap.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScrap.Location = New System.Drawing.Point(200, 598)
        Me.cmdScrap.Name = "cmdScrap"
        Me.cmdScrap.Size = New System.Drawing.Size(85, 40)
        Me.cmdScrap.TabIndex = 56
        Me.cmdScrap.Text = "在庫不良入力"
        '
        'cmdKonsei
        '
        Me.cmdKonsei.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKonsei.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKonsei.Location = New System.Drawing.Point(504, 598)
        Me.cmdKonsei.Name = "cmdKonsei"
        Me.cmdKonsei.Size = New System.Drawing.Size(85, 40)
        Me.cmdKonsei.TabIndex = 24
        Me.cmdKonsei.Text = "混　成"
        '
        'fraThrowinWP
        '
        Me.fraThrowinWP.Controls.Add(Me.cmbThrowinWP)
        Me.fraThrowinWP.Controls.Add(Me.lblThrowinWPTitle)
        Me.fraThrowinWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraThrowinWP.Location = New System.Drawing.Point(8, 530)
        Me.fraThrowinWP.Name = "fraThrowinWP"
        Me.fraThrowinWP.Size = New System.Drawing.Size(465, 65)
        Me.fraThrowinWP.TabIndex = 9
        Me.fraThrowinWP.TabStop = false
        Me.fraThrowinWP.Text = "投入装置"
        '
        'cmbThrowinWP
        '
        Me.cmbThrowinWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbThrowinWP.ForeColor = System.Drawing.Color.Black
        Me.cmbThrowinWP.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbThrowinWP.GridForeColor = System.Drawing.Color.Black
        Me.cmbThrowinWP.Location = New System.Drawing.Point(8, 36)
        Me.cmbThrowinWP.Name = "cmbThrowinWP"
        Me.cmbThrowinWP.Size = New System.Drawing.Size(267, 22)
        Me.cmbThrowinWP.TabIndex = 9
        Me.cmbThrowinWP.Value = Nothing
        '
        'lblThrowinWPTitle
        '
        Me.lblThrowinWPTitle.BackColor = System.Drawing.Color.Navy
        Me.lblThrowinWPTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowinWPTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowinWPTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblThrowinWPTitle.Location = New System.Drawing.Point(8, 20)
        Me.lblThrowinWPTitle.Name = "lblThrowinWPTitle"
        Me.lblThrowinWPTitle.Size = New System.Drawing.Size(267, 17)
        Me.lblThrowinWPTitle.TabIndex = 54
        Me.lblThrowinWPTitle.Text = "装置"
        Me.lblThrowinWPTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClear
        '
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(600, 598)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdClear.TabIndex = 23
        Me.cmdClear.Text = "取　消"
        Me.cmdClear.Visible = false
        '
        'cmdAllClear
        '
        Me.cmdAllClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAllClear.Location = New System.Drawing.Point(792, 598)
        Me.cmdAllClear.Name = "cmdAllClear"
        Me.cmdAllClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdAllClear.TabIndex = 22
        Me.cmdAllClear.Text = "全部取消"
        '
        'fraThrow
        '
        Me.fraThrow.Controls.Add(Me.lblPdTitle1)
        Me.fraThrow.Controls.Add(Me.lblScreenSizeTitle)
        Me.fraThrow.Controls.Add(Me.lblPdTitle0)
        Me.fraThrow.Controls.Add(Me.cmdEntry)
        Me.fraThrow.Controls.Add(Me.cmbScreenSize)
        Me.fraThrow.Controls.Add(Me.cmbPd)
        Me.fraThrow.Controls.Add(Me.cmbFlowClass)
        Me.fraThrow.Controls.Add(Me.lblEntryID)
        Me.fraThrow.Controls.Add(Me.lblEntryIDTitle)
        Me.fraThrow.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraThrow.Location = New System.Drawing.Point(8, 8)
        Me.fraThrow.Name = "fraThrow"
        Me.fraThrow.Size = New System.Drawing.Size(465, 109)
        Me.fraThrow.TabIndex = 0
        Me.fraThrow.TabStop = false
        Me.fraThrow.Text = "投入予定"
        '
        'lblPdTitle1
        '
        Me.lblPdTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblPdTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblPdTitle1.Location = New System.Drawing.Point(8, 64)
        Me.lblPdTitle1.Name = "lblPdTitle1"
        Me.lblPdTitle1.Size = New System.Drawing.Size(105, 17)
        Me.lblPdTitle1.TabIndex = 32
        Me.lblPdTitle1.Text = "流動区分"
        Me.lblPdTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblScreenSizeTitle
        '
        Me.lblScreenSizeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblScreenSizeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScreenSizeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblScreenSizeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblScreenSizeTitle.Location = New System.Drawing.Point(8, 20)
        Me.lblScreenSizeTitle.Name = "lblScreenSizeTitle"
        Me.lblScreenSizeTitle.Size = New System.Drawing.Size(105, 17)
        Me.lblScreenSizeTitle.TabIndex = 29
        Me.lblScreenSizeTitle.Text = "画面サイズ"
        Me.lblScreenSizeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdTitle0
        '
        Me.lblPdTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblPdTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblPdTitle0.Location = New System.Drawing.Point(112, 20)
        Me.lblPdTitle0.Name = "lblPdTitle0"
        Me.lblPdTitle0.Size = New System.Drawing.Size(105, 17)
        Me.lblPdTitle0.TabIndex = 30
        Me.lblPdTitle0.Text = "機種"
        Me.lblPdTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdEntry
        '
        Me.cmdEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEntry.Location = New System.Drawing.Point(368, 20)
        Me.cmdEntry.Name = "cmdEntry"
        Me.cmdEntry.Size = New System.Drawing.Size(85, 40)
        Me.cmdEntry.TabIndex = 2
        Me.cmdEntry.Text = "エントリ"
        '
        'cmbScreenSize
        '
        Me.cmbScreenSize.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbScreenSize.ForeColor = System.Drawing.Color.Black
        Me.cmbScreenSize.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbScreenSize.GridForeColor = System.Drawing.Color.Black
        Me.cmbScreenSize.Location = New System.Drawing.Point(8, 36)
        Me.cmbScreenSize.Name = "cmbScreenSize"
        Me.cmbScreenSize.Size = New System.Drawing.Size(105, 22)
        Me.cmbScreenSize.TabIndex = 0
        Me.cmbScreenSize.Value = Nothing
        '
        'cmbPd
        '
        Me.cmbPd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPd.ForeColor = System.Drawing.Color.Black
        Me.cmbPd.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPd.GridForeColor = System.Drawing.Color.Black
        Me.cmbPd.Location = New System.Drawing.Point(112, 36)
        Me.cmbPd.Name = "cmbPd"
        Me.cmbPd.Size = New System.Drawing.Size(105, 22)
        Me.cmbPd.TabIndex = 1
        Me.cmbPd.Value = Nothing
        '
        'cmbFlowClass
        '
        Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.ForeColor = System.Drawing.Color.Black
        Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridForeColor = System.Drawing.Color.Black
        Me.cmbFlowClass.Location = New System.Drawing.Point(8, 80)
        Me.cmbFlowClass.Name = "cmbFlowClass"
        Me.cmbFlowClass.Size = New System.Drawing.Size(105, 22)
        Me.cmbFlowClass.TabIndex = 3
        Me.cmbFlowClass.Value = Nothing
        '
        'lblEntryID
        '
        Me.lblEntryID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEntryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEntryID.Location = New System.Drawing.Point(216, 36)
        Me.lblEntryID.Name = "lblEntryID"
        Me.lblEntryID.Size = New System.Drawing.Size(145, 22)
        Me.lblEntryID.TabIndex = 51
        '
        'lblEntryIDTitle
        '
        Me.lblEntryIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEntryIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEntryIDTitle.Location = New System.Drawing.Point(216, 20)
        Me.lblEntryIDTitle.Name = "lblEntryIDTitle"
        Me.lblEntryIDTitle.Size = New System.Drawing.Size(145, 17)
        Me.lblEntryIDTitle.TabIndex = 31
        Me.lblEntryIDTitle.Text = "エントリ"
        Me.lblEntryIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraCF
        '
        Me.fraCF.Controls.Add(Me.lblJigIDTitle)
        Me.fraCF.Controls.Add(Me.lblLotManagerTitle)
        Me.fraCF.Controls.Add(Me.cmdJigSelect)
        Me.fraCF.Controls.Add(Me.cmdCarrierSelect)
        Me.fraCF.Controls.Add(Me.vsfJigList)
        Me.fraCF.Controls.Add(Me.txtJig0)
        Me.fraCF.Controls.Add(Me.txtJig1)
        Me.fraCF.Controls.Add(Me.txtJig2)
        Me.fraCF.Controls.Add(Me.txtJig3)
        Me.fraCF.Controls.Add(Me.txtJig4)
        Me.fraCF.Controls.Add(Me.cmbLotManager)
        Me.fraCF.Controls.Add(Me.lblNumberTitle)
        Me.fraCF.Controls.Add(Me.lblTtl13)
        Me.fraCF.Controls.Add(Me.lblThrowNum)
        Me.fraCF.Controls.Add(Me.lblThrowNumTitle)
        Me.fraCF.Controls.Add(Me.lblLotIDTitle)
        Me.fraCF.Controls.Add(Me.lblCFLotID)
        Me.fraCF.Controls.Add(Me.lblCarrierIDTitle)
        Me.fraCF.Controls.Add(Me.txtNumber)
        Me.fraCF.Controls.Add(Me.txtCarrierID)
        Me.fraCF.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCF.Location = New System.Drawing.Point(482, 8)
        Me.fraCF.Name = "fraCF"
        Me.fraCF.Size = New System.Drawing.Size(489, 587)
        Me.fraCF.TabIndex = 10
        Me.fraCF.TabStop = false
        Me.fraCF.Text = "MKロット編成"
        '
        'lblJigIDTitle
        '
        Me.lblJigIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblJigIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJigIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblJigIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblJigIDTitle.Location = New System.Drawing.Point(392, 75)
        Me.lblJigIDTitle.Name = "lblJigIDTitle"
        Me.lblJigIDTitle.Size = New System.Drawing.Size(90, 18)
        Me.lblJigIDTitle.TabIndex = 50
        Me.lblJigIDTitle.Text = "蒸着治具ID"
        Me.lblJigIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotManagerTitle
        '
        Me.lblLotManagerTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotManagerTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManagerTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManagerTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotManagerTitle.Location = New System.Drawing.Point(8, 20)
        Me.lblLotManagerTitle.Name = "lblLotManagerTitle"
        Me.lblLotManagerTitle.Size = New System.Drawing.Size(189, 17)
        Me.lblLotManagerTitle.TabIndex = 52
        Me.lblLotManagerTitle.Text = "ロット担当"
        Me.lblLotManagerTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdJigSelect
        '
        Me.cmdJigSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdJigSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdJigSelect.Location = New System.Drawing.Point(397, 226)
        Me.cmdJigSelect.Name = "cmdJigSelect"
        Me.cmdJigSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdJigSelect.TabIndex = 20
        Me.cmdJigSelect.Text = "空治具"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(392, 20)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect.TabIndex = 13
        Me.cmdCarrierSelect.Text = "空ｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'vsfJigList
        '
        Me.vsfJigList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfJigList.AllowEditing = false
        Me.vsfJigList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfJigList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfJigList.AutoSearchDelay = 2R
        Me.vsfJigList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfJigList.ColumnInfo = resources.GetString("vsfJigList.ColumnInfo")
        Me.vsfJigList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfJigList.ExtendLastCol = true
        Me.vsfJigList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfJigList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfJigList.Location = New System.Drawing.Point(8, 72)
        Me.vsfJigList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfJigList.Name = "vsfJigList"
        Me.vsfJigList.Rows.Count = 40
        Me.vsfJigList.Rows.DefaultSize = 18
        Me.vsfJigList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfJigList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfJigList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfJigList.Size = New System.Drawing.Size(381, 454)
        Me.vsfJigList.StyleInfo = resources.GetString("vsfJigList.StyleInfo")
        Me.vsfJigList.TabIndex = 14
        '
        'txtJig0
        '
        Me.txtJig0.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtJig0.ChrMaxByte = 10
        Me.txtJig0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtJig0.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtJig0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtJig0.Location = New System.Drawing.Point(392, 92)
        Me.txtJig0.Name = "txtJig0"
        Me.txtJig0.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtJig0.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtJig0.SelectedText = ""
        Me.txtJig0.Size = New System.Drawing.Size(90, 26)
        Me.txtJig0.TabIndex = 15
        '
        'txtJig1
        '
        Me.txtJig1.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtJig1.ChrMaxByte = 10
        Me.txtJig1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtJig1.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtJig1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtJig1.Location = New System.Drawing.Point(392, 117)
        Me.txtJig1.Name = "txtJig1"
        Me.txtJig1.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtJig1.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtJig1.SelectedText = ""
        Me.txtJig1.Size = New System.Drawing.Size(90, 25)
        Me.txtJig1.TabIndex = 16
        '
        'txtJig2
        '
        Me.txtJig2.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtJig2.ChrMaxByte = 10
        Me.txtJig2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtJig2.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtJig2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtJig2.Location = New System.Drawing.Point(392, 141)
        Me.txtJig2.Name = "txtJig2"
        Me.txtJig2.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtJig2.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtJig2.SelectedText = ""
        Me.txtJig2.Size = New System.Drawing.Size(90, 25)
        Me.txtJig2.TabIndex = 17
        '
        'txtJig3
        '
        Me.txtJig3.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtJig3.ChrMaxByte = 10
        Me.txtJig3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtJig3.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtJig3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtJig3.Location = New System.Drawing.Point(392, 165)
        Me.txtJig3.Name = "txtJig3"
        Me.txtJig3.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtJig3.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtJig3.SelectedText = ""
        Me.txtJig3.Size = New System.Drawing.Size(90, 25)
        Me.txtJig3.TabIndex = 18
        '
        'txtJig4
        '
        Me.txtJig4.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtJig4.ChrMaxByte = 10
        Me.txtJig4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtJig4.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtJig4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtJig4.Location = New System.Drawing.Point(392, 189)
        Me.txtJig4.Name = "txtJig4"
        Me.txtJig4.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtJig4.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtJig4.SelectedText = ""
        Me.txtJig4.Size = New System.Drawing.Size(90, 25)
        Me.txtJig4.TabIndex = 19
        '
        'cmbLotManager
        '
        Me.cmbLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbLotManager.GridForeColor = System.Drawing.Color.Black
        Me.cmbLotManager.Location = New System.Drawing.Point(8, 36)
        Me.cmbLotManager.Name = "cmbLotManager"
        Me.cmbLotManager.Size = New System.Drawing.Size(189, 22)
        Me.cmbLotManager.TabIndex = 10
        Me.cmbLotManager.Value = Nothing
        '
        'lblNumberTitle
        '
        Me.lblNumberTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNumberTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumberTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNumberTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNumberTitle.Location = New System.Drawing.Point(292, 20)
        Me.lblNumberTitle.Name = "lblNumberTitle"
        Me.lblNumberTitle.Size = New System.Drawing.Size(93, 17)
        Me.lblNumberTitle.TabIndex = 43
        Me.lblNumberTitle.Text = "詰数"
        Me.lblNumberTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl13
        '
        Me.lblTtl13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTtl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl13.Controls.Add(Me.lblMaxNum)
        Me.lblTtl13.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl13.ForeColor = System.Drawing.Color.White
        Me.lblTtl13.Location = New System.Drawing.Point(344, 36)
        Me.lblTtl13.Name = "lblTtl13"
        Me.lblTtl13.Size = New System.Drawing.Size(41, 22)
        Me.lblTtl13.TabIndex = 49
        Me.lblTtl13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMaxNum
        '
        Me.lblMaxNum.BackColor = System.Drawing.Color.Transparent
        Me.lblMaxNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMaxNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMaxNum.Location = New System.Drawing.Point(-2, 2)
        Me.lblMaxNum.Name = "lblMaxNum"
        Me.lblMaxNum.Size = New System.Drawing.Size(40, 22)
        Me.lblMaxNum.TabIndex = 46
        Me.lblMaxNum.Text = "0"
        '
        'lblThrowNum
        '
        Me.lblThrowNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblThrowNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblThrowNum.Location = New System.Drawing.Point(300, 552)
        Me.lblThrowNum.Name = "lblThrowNum"
        Me.lblThrowNum.Size = New System.Drawing.Size(85, 22)
        Me.lblThrowNum.TabIndex = 48
        Me.lblThrowNum.Text = "0"
        Me.lblThrowNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblThrowNumTitle
        '
        Me.lblThrowNumTitle.BackColor = System.Drawing.Color.Navy
        Me.lblThrowNumTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowNumTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowNumTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblThrowNumTitle.Location = New System.Drawing.Point(300, 536)
        Me.lblThrowNumTitle.Name = "lblThrowNumTitle"
        Me.lblThrowNumTitle.Size = New System.Drawing.Size(85, 17)
        Me.lblThrowNumTitle.TabIndex = 47
        Me.lblThrowNumTitle.Text = "投入数"
        Me.lblThrowNumTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotIDTitle
        '
        Me.lblLotIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotIDTitle.Location = New System.Drawing.Point(126, 536)
        Me.lblLotIDTitle.Name = "lblLotIDTitle"
        Me.lblLotIDTitle.Size = New System.Drawing.Size(165, 17)
        Me.lblLotIDTitle.TabIndex = 45
        Me.lblLotIDTitle.Text = "ロットID"
        Me.lblLotIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCFLotID
        '
        Me.lblCFLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCFLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCFLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCFLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCFLotID.Location = New System.Drawing.Point(126, 552)
        Me.lblCFLotID.Name = "lblCFLotID"
        Me.lblCFLotID.Size = New System.Drawing.Size(165, 21)
        Me.lblCFLotID.TabIndex = 44
        '
        'lblCarrierIDTitle
        '
        Me.lblCarrierIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCarrierIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCarrierIDTitle.Location = New System.Drawing.Point(204, 20)
        Me.lblCarrierIDTitle.Name = "lblCarrierIDTitle"
        Me.lblCarrierIDTitle.Size = New System.Drawing.Size(89, 17)
        Me.lblCarrierIDTitle.TabIndex = 42
        Me.lblCarrierIDTitle.Text = "キャリアID"
        Me.lblCarrierIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtNumber
        '
        Me.txtNumber.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtNumber.ChrMaxByte = 3
        Me.txtNumber.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtNumber.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtNumber.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtNumber.Location = New System.Drawing.Point(292, 36)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtNumber.NumMax = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtNumber.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtNumber.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNumber.SelectedText = ""
        Me.txtNumber.Size = New System.Drawing.Size(53, 22)
        Me.txtNumber.TabIndex = 12
        Me.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCarrierID
        '
        Me.txtCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID.ChrMaxByte = 6
        Me.txtCarrierID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID.Location = New System.Drawing.Point(204, 36)
        Me.txtCarrierID.Name = "txtCarrierID"
        Me.txtCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID.SelectedText = ""
        Me.txtCarrierID.Size = New System.Drawing.Size(89, 22)
        Me.txtCarrierID.TabIndex = 11
        '
        'fraPart
        '
        Me.fraPart.Controls.Add(Me.lblVenderName)
        Me.fraPart.Controls.Add(Me.lblReworkTitle)
        Me.fraPart.Controls.Add(Me.lblBoardThicknessTitle)
        Me.fraPart.Controls.Add(Me.lblPartTitle)
        Me.fraPart.Controls.Add(Me.cmbPart)
        Me.fraPart.Controls.Add(Me.cmdSearch)
        Me.fraPart.Controls.Add(Me.cmbBoardThickness)
        Me.fraPart.Controls.Add(Me.cmbRework)
        Me.fraPart.Controls.Add(Me.vsfInvLotList)
        Me.fraPart.Controls.Add(Me.lblTitleHT1)
        Me.fraPart.Controls.Add(Me.lblNowDate)
        Me.fraPart.Controls.Add(Me.lblNowDateTitle)
        Me.fraPart.Controls.Add(Me.lblLotCntTitle)
        Me.fraPart.Controls.Add(Me.lblLotCnt)
        Me.fraPart.Controls.Add(Me.lblVenderNameTitle)
        Me.fraPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraPart.Location = New System.Drawing.Point(8, 122)
        Me.fraPart.Name = "fraPart"
        Me.fraPart.Size = New System.Drawing.Size(465, 400)
        Me.fraPart.TabIndex = 4
        Me.fraPart.TabStop = false
        Me.fraPart.Text = "利用部材"
        '
        'lblVenderName
        '
        Me.lblVenderName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblVenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVenderName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVenderName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVenderName.Location = New System.Drawing.Point(232, 34)
        Me.lblVenderName.Name = "lblVenderName"
        Me.lblVenderName.Size = New System.Drawing.Size(226, 22)
        Me.lblVenderName.TabIndex = 41
        '
        'lblReworkTitle
        '
        Me.lblReworkTitle.BackColor = System.Drawing.Color.Navy
        Me.lblReworkTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReworkTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReworkTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblReworkTitle.Location = New System.Drawing.Point(124, 62)
        Me.lblReworkTitle.Name = "lblReworkTitle"
        Me.lblReworkTitle.Size = New System.Drawing.Size(105, 17)
        Me.lblReworkTitle.TabIndex = 36
        Me.lblReworkTitle.Text = "リワーク回数"
        Me.lblReworkTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBoardThicknessTitle
        '
        Me.lblBoardThicknessTitle.BackColor = System.Drawing.Color.Navy
        Me.lblBoardThicknessTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBoardThicknessTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBoardThicknessTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblBoardThicknessTitle.Location = New System.Drawing.Point(8, 62)
        Me.lblBoardThicknessTitle.Name = "lblBoardThicknessTitle"
        Me.lblBoardThicknessTitle.Size = New System.Drawing.Size(105, 17)
        Me.lblBoardThicknessTitle.TabIndex = 35
        Me.lblBoardThicknessTitle.Text = "板厚"
        Me.lblBoardThicknessTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPartTitle
        '
        Me.lblPartTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPartTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPartTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPartTitle.Location = New System.Drawing.Point(8, 18)
        Me.lblPartTitle.Name = "lblPartTitle"
        Me.lblPartTitle.Size = New System.Drawing.Size(225, 17)
        Me.lblPartTitle.TabIndex = 33
        Me.lblPartTitle.Text = "部品"
        Me.lblPartTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbPart
        '
        Me.cmbPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridForeColor = System.Drawing.Color.Black
        Me.cmbPart.Location = New System.Drawing.Point(8, 34)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(225, 22)
        Me.cmbPart.TabIndex = 4
        Me.cmbPart.Value = Nothing
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(252, 62)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSearch.TabIndex = 7
        Me.cmdSearch.Text = "検　索"
        '
        'cmbBoardThickness
        '
        Me.cmbBoardThickness.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbBoardThickness.ForeColor = System.Drawing.Color.Black
        Me.cmbBoardThickness.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbBoardThickness.GridForeColor = System.Drawing.Color.Black
        Me.cmbBoardThickness.Location = New System.Drawing.Point(8, 78)
        Me.cmbBoardThickness.Name = "cmbBoardThickness"
        Me.cmbBoardThickness.Size = New System.Drawing.Size(105, 22)
        Me.cmbBoardThickness.TabIndex = 5
        Me.cmbBoardThickness.Value = Nothing
        '
        'cmbRework
        '
        Me.cmbRework.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRework.ForeColor = System.Drawing.Color.Black
        Me.cmbRework.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRework.GridForeColor = System.Drawing.Color.Black
        Me.cmbRework.Location = New System.Drawing.Point(124, 78)
        Me.cmbRework.Name = "cmbRework"
        Me.cmbRework.Size = New System.Drawing.Size(105, 22)
        Me.cmbRework.TabIndex = 6
        Me.cmbRework.Value = Nothing
        '
        'vsfInvLotList
        '
        Me.vsfInvLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfInvLotList.AllowEditing = false
        Me.vsfInvLotList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfInvLotList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfInvLotList.AutoSearchDelay = 2R
        Me.vsfInvLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfInvLotList.ColumnInfo = resources.GetString("vsfInvLotList.ColumnInfo")
        Me.vsfInvLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfInvLotList.ExtendLastCol = true
        Me.vsfInvLotList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfInvLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfInvLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfInvLotList.Location = New System.Drawing.Point(8, 149)
        Me.vsfInvLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfInvLotList.Name = "vsfInvLotList"
        Me.vsfInvLotList.Rows.Count = 40
        Me.vsfInvLotList.Rows.DefaultSize = 18
        Me.vsfInvLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfInvLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfInvLotList.Size = New System.Drawing.Size(451, 239)
        Me.vsfInvLotList.StyleInfo = resources.GetString("vsfInvLotList.StyleInfo")
        Me.vsfInvLotList.TabIndex = 8
        '
        'lblTitleHT1
        '
        Me.lblTitleHT1.AutoSize = true
        Me.lblTitleHT1.BackColor = System.Drawing.Color.Red
        Me.lblTitleHT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT1.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT1.Location = New System.Drawing.Point(10, 128)
        Me.lblTitleHT1.Name = "lblTitleHT1"
        Me.lblTitleHT1.Size = New System.Drawing.Size(106, 18)
        Me.lblTitleHT1.TabIndex = 55
        Me.lblTitleHT1.Text = "制限時間超過"
        Me.lblTitleHT1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(252, 123)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 39
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblNowDateTitle
        '
        Me.lblNowDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNowDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNowDateTitle.Location = New System.Drawing.Point(252, 107)
        Me.lblNowDateTitle.Name = "lblNowDateTitle"
        Me.lblNowDateTitle.Size = New System.Drawing.Size(122, 17)
        Me.lblNowDateTitle.TabIndex = 37
        Me.lblNowDateTitle.Text = "情報取得日時"
        Me.lblNowDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCntTitle
        '
        Me.lblLotCntTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotCntTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCntTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCntTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotCntTitle.Location = New System.Drawing.Point(385, 107)
        Me.lblLotCntTitle.Name = "lblLotCntTitle"
        Me.lblLotCntTitle.Size = New System.Drawing.Size(73, 17)
        Me.lblLotCntTitle.TabIndex = 38
        Me.lblLotCntTitle.Text = "該当件数"
        Me.lblLotCntTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(385, 123)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(73, 21)
        Me.lblLotCnt.TabIndex = 40
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVenderNameTitle
        '
        Me.lblVenderNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblVenderNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVenderNameTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVenderNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblVenderNameTitle.Location = New System.Drawing.Point(232, 18)
        Me.lblVenderNameTitle.Name = "lblVenderNameTitle"
        Me.lblVenderNameTitle.Size = New System.Drawing.Size(226, 17)
        Me.lblVenderNameTitle.TabIndex = 34
        Me.lblVenderNameTitle.Text = "ベンダー"
        Me.lblVenderNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 598)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 21
        Me.cmdRegist.Text = "確　定"
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
        Me.cmdClose.TabIndex = 25
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxEN02C0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdScrap)
        Me.Controls.Add(Me.cmdKonsei)
        Me.Controls.Add(Me.fraThrowinWP)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdAllClear)
        Me.Controls.Add(Me.fraThrow)
        Me.Controls.Add(Me.fraCF)
        Me.Controls.Add(Me.fraPart)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02C0"
        Me.Text = "MKロット編成"
        Me.fraThrowinWP.ResumeLayout(false)
        Me.fraThrow.ResumeLayout(false)
        Me.fraCF.ResumeLayout(false)
        CType(Me.vsfJigList,System.ComponentModel.ISupportInitialize).EndInit
        Me.lblTtl13.ResumeLayout(false)
        Me.fraPart.ResumeLayout(false)
        Me.fraPart.PerformLayout
        CType(Me.vsfInvLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdScrap As Button
    Friend WithEvents cmdKonsei As Button
    Friend WithEvents fraThrowinWP As GroupBox
    Friend WithEvents cmbThrowinWP As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblThrowinWPTitle As Label
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdAllClear As Button
    Friend WithEvents fraThrow As GroupBox
    Friend WithEvents cmdEntry As Button
    Friend WithEvents cmbScreenSize As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPd As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbFlowClass As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblPdTitle1 As Label
    Friend WithEvents lblEntryID As Label
    Friend WithEvents lblEntryIDTitle As Label
    Friend WithEvents lblPdTitle0 As Label
    Friend WithEvents lblScreenSizeTitle As Label
    Friend WithEvents fraCF As GroupBox
    Friend WithEvents cmdJigSelect As Button
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtNumber As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfJigList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtJig0 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtJig1 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtJig2 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtJig3 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtJig4 As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbLotManager As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblLotManagerTitle As Label
    Friend WithEvents lblJigIDTitle As Label
    Friend WithEvents lblMaxNum As Label
    Friend WithEvents lblNumberTitle As Label
    Friend WithEvents lblTtl13 As Label
    Friend WithEvents lblThrowNum As Label
    Friend WithEvents lblThrowNumTitle As Label
    Friend WithEvents lblLotIDTitle As Label
    Friend WithEvents lblCFLotID As Label
    Friend WithEvents lblCarrierIDTitle As Label
    Friend WithEvents fraPart As GroupBox
    Friend WithEvents cmbPart As SECmbIchiran.ComboIchiran
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmbBoardThickness As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbRework As SEComboBoxEx.ComboBoxEx
    Friend WithEvents vsfInvLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleHT1 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblNowDateTitle As Label
    Friend WithEvents lblLotCntTitle As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblBoardThicknessTitle As Label
    Friend WithEvents lblReworkTitle As Label
    Friend WithEvents lblVenderName As Label
    Friend WithEvents lblVenderNameTitle As Label
    Friend WithEvents lblPartTitle As Label
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
End Class
