<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02J0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02J0))
        Me.picRightAllow = New System.Windows.Forms.PictureBox()
        Me.cmdDepoDataUpdate = New System.Windows.Forms.Button()
        Me.cmdUpdateNg = New System.Windows.Forms.Button()
        Me.cmdUpdateOk = New System.Windows.Forms.Button()
        Me.frmSerch0 = New System.Windows.Forms.GroupBox()
        Me.cmdSerch = New System.Windows.Forms.Button()
        Me.cmbWpId = New SEComboBoxEx.ComboBoxEx()
        Me.cmbRc = New SEComboBoxEx.ComboBoxEx()
        Me.cmbRecipe = New SEComboBoxEx.ComboBoxEx()
        Me.cmbEvent = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lbDepoDataCnt = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraLot = New System.Windows.Forms.GroupBox()
        Me.vsfFbList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtNewDepoData = New SETextBoxEx.TextBoxEx()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.lblOldDepoData = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.frmSerch0.SuspendLayout
        Me.fraLot.SuspendLayout
        CType(Me.vsfFbList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'picRightAllow
        '
        Me.picRightAllow.Image = CType(resources.GetObject("picRightAllow.Image"),System.Drawing.Image)
        Me.picRightAllow.Location = New System.Drawing.Point(800, 548)
        Me.picRightAllow.Name = "picRightAllow"
        Me.picRightAllow.Size = New System.Drawing.Size(32, 32)
        Me.picRightAllow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRightAllow.TabIndex = 24
        Me.picRightAllow.TabStop = false
        '
        'cmdDepoDataUpdate
        '
        Me.cmdDepoDataUpdate.CausesValidation = false
        Me.cmdDepoDataUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDepoDataUpdate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDepoDataUpdate.Location = New System.Drawing.Point(884, 599)
        Me.cmdDepoDataUpdate.Name = "cmdDepoDataUpdate"
        Me.cmdDepoDataUpdate.Size = New System.Drawing.Size(85, 40)
        Me.cmdDepoDataUpdate.TabIndex = 19
        Me.cmdDepoDataUpdate.Text = " 補正値 手動設定"
        '
        'cmdUpdateNg
        '
        Me.cmdUpdateNg.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpdateNg.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUpdateNg.Location = New System.Drawing.Point(476, 599)
        Me.cmdUpdateNg.Name = "cmdUpdateNg"
        Me.cmdUpdateNg.Size = New System.Drawing.Size(85, 40)
        Me.cmdUpdateNg.TabIndex = 3
        Me.cmdUpdateNg.Text = " 補正値 書換禁止"
        '
        'cmdUpdateOk
        '
        Me.cmdUpdateOk.CausesValidation = false
        Me.cmdUpdateOk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpdateOk.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUpdateOk.Location = New System.Drawing.Point(572, 599)
        Me.cmdUpdateOk.Name = "cmdUpdateOk"
        Me.cmdUpdateOk.Size = New System.Drawing.Size(85, 40)
        Me.cmdUpdateOk.TabIndex = 2
        Me.cmdUpdateOk.Text = " 補正値 書換許可"
        '
        'frmSerch0
        '
        Me.frmSerch0.Controls.Add(Me.cmdSerch)
        Me.frmSerch0.Controls.Add(Me.cmbWpId)
        Me.frmSerch0.Controls.Add(Me.cmbRc)
        Me.frmSerch0.Controls.Add(Me.cmbRecipe)
        Me.frmSerch0.Controls.Add(Me.cmbEvent)
        Me.frmSerch0.Controls.Add(Me.lblTitle5)
        Me.frmSerch0.Controls.Add(Me.lblTitle4)
        Me.frmSerch0.Controls.Add(Me.lblTitle3)
        Me.frmSerch0.Controls.Add(Me.lblTitle2)
        Me.frmSerch0.Controls.Add(Me.lblTitle6)
        Me.frmSerch0.Controls.Add(Me.lbDepoDataCnt)
        Me.frmSerch0.Controls.Add(Me.lblNowDate)
        Me.frmSerch0.Controls.Add(Me.lblTitle1)
        Me.frmSerch0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.frmSerch0.Location = New System.Drawing.Point(8, 8)
        Me.frmSerch0.Name = "frmSerch0"
        Me.frmSerch0.Size = New System.Drawing.Size(965, 125)
        Me.frmSerch0.TabIndex = 10
        Me.frmSerch0.TabStop = false
        Me.frmSerch0.Text = "検索条件"
        '
        'cmdSerch
        '
        Me.cmdSerch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSerch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSerch.Location = New System.Drawing.Point(872, 72)
        Me.cmdSerch.Name = "cmdSerch"
        Me.cmdSerch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSerch.TabIndex = 0
        Me.cmdSerch.Text = "検索"
        '
        'cmbWpId
        '
        Me.cmbWpId.DirectInput = false
        Me.cmbWpId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpId.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpId.GridForeColor = System.Drawing.Color.Black
        Me.cmbWpId.Location = New System.Drawing.Point(8, 44)
        Me.cmbWpId.Name = "cmbWpId"
        Me.cmbWpId.Size = New System.Drawing.Size(240, 22)
        Me.cmbWpId.TabIndex = 10
        Me.cmbWpId.Value = Nothing
        '
        'cmbRc
        '
        Me.cmbRc.DirectInput = false
        Me.cmbRc.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRc.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRc.GridForeColor = System.Drawing.Color.Black
        Me.cmbRc.Location = New System.Drawing.Point(255, 44)
        Me.cmbRc.Name = "cmbRc"
        Me.cmbRc.Size = New System.Drawing.Size(240, 22)
        Me.cmbRc.TabIndex = 12
        Me.cmbRc.Value = Nothing
        '
        'cmbRecipe
        '
        Me.cmbRecipe.DirectInput = false
        Me.cmbRecipe.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRecipe.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRecipe.GridForeColor = System.Drawing.Color.Black
        Me.cmbRecipe.Location = New System.Drawing.Point(500, 44)
        Me.cmbRecipe.Name = "cmbRecipe"
        Me.cmbRecipe.Size = New System.Drawing.Size(240, 22)
        Me.cmbRecipe.TabIndex = 15
        Me.cmbRecipe.Value = Nothing
        '
        'cmbEvent
        '
        Me.cmbEvent.DirectInput = false
        Me.cmbEvent.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbEvent.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbEvent.GridForeColor = System.Drawing.Color.Black
        Me.cmbEvent.Location = New System.Drawing.Point(8, 88)
        Me.cmbEvent.Name = "cmbEvent"
        Me.cmbEvent.Size = New System.Drawing.Size(240, 22)
        Me.cmbEvent.TabIndex = 17
        Me.cmbEvent.Value = Nothing
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(8, 72)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(240, 17)
        Me.lblTitle5.TabIndex = 16
        Me.lblTitle5.Text = "更新種別"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(500, 28)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(240, 17)
        Me.lblTitle4.TabIndex = 14
        Me.lblTitle4.Text = "レシピ"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(255, 28)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(240, 17)
        Me.lblTitle3.TabIndex = 13
        Me.lblTitle3.Text = "リアクタ"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(8, 28)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(240, 17)
        Me.lblTitle2.TabIndex = 11
        Me.lblTitle2.Text = "装置名"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(874, 28)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(81, 17)
        Me.lblTitle6.TabIndex = 7
        Me.lblTitle6.Text = "該当件数"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbDepoDataCnt
        '
        Me.lbDepoDataCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lbDepoDataCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbDepoDataCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lbDepoDataCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbDepoDataCnt.Location = New System.Drawing.Point(874, 44)
        Me.lbDepoDataCnt.Name = "lbDepoDataCnt"
        Me.lbDepoDataCnt.Size = New System.Drawing.Size(81, 21)
        Me.lbDepoDataCnt.TabIndex = 8
        Me.lbDepoDataCnt.Text = "0"
        Me.lbDepoDataCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(744, 44)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 6
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(744, 28)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle1.TabIndex = 5
        Me.lblTitle1.Text = "情報取得日時"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 599)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "閉じる"
        '
        'fraLot
        '
        Me.fraLot.Controls.Add(Me.vsfFbList)
        Me.fraLot.Controls.Add(Me.txtNewDepoData)
        Me.fraLot.Controls.Add(Me.lblTitle9)
        Me.fraLot.Controls.Add(Me.lblOldDepoData)
        Me.fraLot.Controls.Add(Me.lblTitle7)
        Me.fraLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot.Location = New System.Drawing.Point(8, 136)
        Me.fraLot.Name = "fraLot"
        Me.fraLot.Size = New System.Drawing.Size(965, 461)
        Me.fraLot.TabIndex = 18
        Me.fraLot.TabStop = false
        Me.fraLot.Text = "TEOS F/Bデータ"
        '
        'vsfFbList
        '
        Me.vsfFbList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfFbList.AllowEditing = false
        Me.vsfFbList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfFbList.AutoResize = true
        Me.vsfFbList.AutoSearchDelay = 2R
        Me.vsfFbList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfFbList.ColumnInfo = resources.GetString("vsfFbList.ColumnInfo")
        Me.vsfFbList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfFbList.ExtendLastCol = true
        Me.vsfFbList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfFbList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfFbList.Location = New System.Drawing.Point(4, 20)
        Me.vsfFbList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFbList.Name = "vsfFbList"
        Me.vsfFbList.Rows.Count = 3
        Me.vsfFbList.Rows.DefaultSize = 18
        Me.vsfFbList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfFbList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFbList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfFbList.Size = New System.Drawing.Size(953, 379)
        Me.vsfFbList.StyleInfo = resources.GetString("vsfFbList.StyleInfo")
        Me.vsfFbList.TabIndex = 18
        '
        'txtNewDepoData
        '
        Me.txtNewDepoData.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtNewDepoData.ChrMaxByte = 10
        Me.txtNewDepoData.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtNewDepoData.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtNewDepoData.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtNewDepoData.Location = New System.Drawing.Point(832, 424)
        Me.txtNewDepoData.Name = "txtNewDepoData"
        Me.txtNewDepoData.NgChr = "'"
        Me.txtNewDepoData.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_1_Decimal
        Me.txtNewDepoData.NumFormat = "##,##0.0"
        Me.txtNewDepoData.NumMax = New Decimal(New Integer() {999999, 0, 0, 65536})
        Me.txtNewDepoData.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtNewDepoData.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNewDepoData.SelectedText = ""
        Me.txtNewDepoData.Size = New System.Drawing.Size(125, 22)
        Me.txtNewDepoData.TabIndex = 22
        Me.txtNewDepoData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(832, 408)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle9.TabIndex = 23
        Me.lblTitle9.Text = "変更後DEPO時間"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOldDepoData
        '
        Me.lblOldDepoData.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOldDepoData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOldDepoData.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOldDepoData.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOldDepoData.Location = New System.Drawing.Point(660, 424)
        Me.lblOldDepoData.Name = "lblOldDepoData"
        Me.lblOldDepoData.Size = New System.Drawing.Size(124, 22)
        Me.lblOldDepoData.TabIndex = 21
        Me.lblOldDepoData.Text = "99999.9"
        Me.lblOldDepoData.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(660, 408)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(124, 17)
        Me.lblTitle7.TabIndex = 20
        Me.lblTitle7.Text = "変更前DEPO時間"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02J0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.picRightAllow)
        Me.Controls.Add(Me.cmdDepoDataUpdate)
        Me.Controls.Add(Me.cmdUpdateNg)
        Me.Controls.Add(Me.cmdUpdateOk)
        Me.Controls.Add(Me.frmSerch0)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraLot)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02J0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "TEOS　F/Bデータ変更/参照"
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).EndInit
        Me.frmSerch0.ResumeLayout(false)
        Me.fraLot.ResumeLayout(false)
        CType(Me.vsfFbList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents picRightAllow As PictureBox
    Friend WithEvents cmdDepoDataUpdate As Button
    Friend WithEvents cmdUpdateNg As Button
    Friend WithEvents cmdUpdateOk As Button
    Friend WithEvents frmSerch0 As GroupBox
    Friend WithEvents cmdSerch As Button
    Friend WithEvents cmbWpId As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbRc As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbRecipe As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbEvent As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lbDepoDataCnt As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraLot As GroupBox
    Friend WithEvents vsfFbList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtNewDepoData As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblOldDepoData As Label
    Friend WithEvents lblTitle7 As Label
End Class
