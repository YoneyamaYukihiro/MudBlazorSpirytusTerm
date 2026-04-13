<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02I0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02I0))
        Me.cmdClipCopy = New System.Windows.Forms.Button()
        Me.cmdHidden = New System.Windows.Forms.Button()
        Me.cmdDetail = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.frmSerch0 = New System.Windows.Forms.GroupBox()
        Me.cmdSerchAdd = New System.Windows.Forms.Button()
        Me.optSerch4 = New System.Windows.Forms.RadioButton()
        Me.optSerch1 = New System.Windows.Forms.RadioButton()
        Me.optSerch0 = New System.Windows.Forms.RadioButton()
        Me.optSerch2 = New System.Windows.Forms.RadioButton()
        Me.cmdSerch = New System.Windows.Forms.Button()
        Me.txtLotID = New SETextBoxEx.TextBoxEx()
        Me.cmbOpId = New SEComboBoxEx.ComboBoxEx()
        Me.cmbWpId = New SEComboBoxEx.ComboBoxEx()
        Me.cmbProduct = New SECmbIchiran.ComboIchiran()
        Me.cmbStepID = New SEComboBoxEx.ComboBoxEx()
        Me.lblLot = New System.Windows.Forms.Label()
        Me.lblPd = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.cmdAllOn = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraLot = New System.Windows.Forms.GroupBox()
        Me.vsfLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.frmSerch0.SuspendLayout
        Me.fraLot.SuspendLayout
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdClipCopy
        '
        Me.cmdClipCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClipCopy.Location = New System.Drawing.Point(504, 597)
        Me.cmdClipCopy.Name = "cmdClipCopy"
        Me.cmdClipCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdClipCopy.TabIndex = 27
        Me.cmdClipCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'cmdHidden
        '
        Me.cmdHidden.CausesValidation = false
        Me.cmdHidden.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHidden.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHidden.Location = New System.Drawing.Point(296, 597)
        Me.cmdHidden.Name = "cmdHidden"
        Me.cmdHidden.Size = New System.Drawing.Size(85, 40)
        Me.cmdHidden.TabIndex = 16
        Me.cmdHidden.Text = "チェックOFF非表示"
        '
        'cmdDetail
        '
        Me.cmdDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDetail.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDetail.Location = New System.Drawing.Point(600, 597)
        Me.cmdDetail.Name = "cmdDetail"
        Me.cmdDetail.Size = New System.Drawing.Size(85, 40)
        Me.cmdDetail.TabIndex = 15
        Me.cmdDetail.Text = "詳細表示"
        '
        'cmdCopy
        '
        Me.cmdCopy.CausesValidation = false
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(200, 597)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopy.TabIndex = 17
        Me.cmdCopy.Text = "上の設定コピー"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 597)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 13
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClear
        '
        Me.cmdClear.CausesValidation = false
        Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClear.Location = New System.Drawing.Point(792, 597)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(85, 40)
        Me.cmdClear.TabIndex = 14
        Me.cmdClear.Text = "全部取消"
        '
        'frmSerch0
        '
        Me.frmSerch0.Controls.Add(Me.cmdSerchAdd)
        Me.frmSerch0.Controls.Add(Me.optSerch4)
        Me.frmSerch0.Controls.Add(Me.optSerch1)
        Me.frmSerch0.Controls.Add(Me.optSerch0)
        Me.frmSerch0.Controls.Add(Me.optSerch2)
        Me.frmSerch0.Controls.Add(Me.cmdSerch)
        Me.frmSerch0.Controls.Add(Me.txtLotID)
        Me.frmSerch0.Controls.Add(Me.cmbOpId)
        Me.frmSerch0.Controls.Add(Me.cmbWpId)
        Me.frmSerch0.Controls.Add(Me.cmbProduct)
        Me.frmSerch0.Controls.Add(Me.cmbStepID)
        Me.frmSerch0.Controls.Add(Me.lblLot)
        Me.frmSerch0.Controls.Add(Me.lblPd)
        Me.frmSerch0.Controls.Add(Me.lblTitle6)
        Me.frmSerch0.Controls.Add(Me.lblLotCnt)
        Me.frmSerch0.Controls.Add(Me.lblNowDate)
        Me.frmSerch0.Controls.Add(Me.lblTitle1)
        Me.frmSerch0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.frmSerch0.Location = New System.Drawing.Point(8, 4)
        Me.frmSerch0.Name = "frmSerch0"
        Me.frmSerch0.Size = New System.Drawing.Size(965, 125)
        Me.frmSerch0.TabIndex = 0
        Me.frmSerch0.TabStop = false
        Me.frmSerch0.Text = "ロット検索条件"
        '
        'cmdSerchAdd
        '
        Me.cmdSerchAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSerchAdd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSerchAdd.Location = New System.Drawing.Point(872, 20)
        Me.cmdSerchAdd.Name = "cmdSerchAdd"
        Me.cmdSerchAdd.Size = New System.Drawing.Size(85, 40)
        Me.cmdSerchAdd.TabIndex = 10
        Me.cmdSerchAdd.Text = "追加検索"
        '
        'optSerch4
        '
        Me.optSerch4.CausesValidation = false
        Me.optSerch4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optSerch4.Location = New System.Drawing.Point(556, 16)
        Me.optSerch4.Name = "optSerch4"
        Me.optSerch4.Size = New System.Drawing.Size(121, 40)
        Me.optSerch4.TabIndex = 8
        Me.optSerch4.Text = "設定あり全て"
        '
        'optSerch1
        '
        Me.optSerch1.CausesValidation = false
        Me.optSerch1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optSerch1.Location = New System.Drawing.Point(11, 48)
        Me.optSerch1.Name = "optSerch1"
        Me.optSerch1.Size = New System.Drawing.Size(73, 40)
        Me.optSerch1.TabIndex = 2
        Me.optSerch1.Text = "装置名"
        '
        'optSerch0
        '
        Me.optSerch0.CausesValidation = false
        Me.optSerch0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optSerch0.Location = New System.Drawing.Point(11, 16)
        Me.optSerch0.Name = "optSerch0"
        Me.optSerch0.Size = New System.Drawing.Size(89, 40)
        Me.optSerch0.TabIndex = 0
        Me.optSerch0.Text = "ロットID"
        '
        'optSerch2
        '
        Me.optSerch2.CausesValidation = false
        Me.optSerch2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optSerch2.Location = New System.Drawing.Point(11, 79)
        Me.optSerch2.Name = "optSerch2"
        Me.optSerch2.Size = New System.Drawing.Size(89, 40)
        Me.optSerch2.TabIndex = 4
        Me.optSerch2.Text = "特定工程"
        '
        'cmdSerch
        '
        Me.cmdSerch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSerch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSerch.Location = New System.Drawing.Point(780, 20)
        Me.cmdSerch.Name = "cmdSerch"
        Me.cmdSerch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSerch.TabIndex = 9
        Me.cmdSerch.Text = "検索"
        '
        'txtLotID
        '
        Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLotID.ChrMaxByte = 10
        Me.txtLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotID.Location = New System.Drawing.Point(100, 24)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.NgChr = "'"
        Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotID.SelectedText = ""
        Me.txtLotID.Size = New System.Drawing.Size(209, 22)
        Me.txtLotID.TabIndex = 1
        '
        'cmbOpId
        '
        Me.cmbOpId.DirectInput = false
        Me.cmbOpId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOpId.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOpId.GridForeColor = System.Drawing.Color.Black
        Me.cmbOpId.Location = New System.Drawing.Point(100, 88)
        Me.cmbOpId.Name = "cmbOpId"
        Me.cmbOpId.Size = New System.Drawing.Size(209, 22)
        Me.cmbOpId.TabIndex = 5
        Me.cmbOpId.Value = Nothing
        '
        'cmbWpId
        '
        Me.cmbWpId.DirectInput = false
        Me.cmbWpId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpId.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpId.GridForeColor = System.Drawing.Color.Black
        Me.cmbWpId.Location = New System.Drawing.Point(100, 56)
        Me.cmbWpId.Name = "cmbWpId"
        Me.cmbWpId.Size = New System.Drawing.Size(209, 22)
        Me.cmbWpId.TabIndex = 3
        Me.cmbWpId.Value = Nothing
        '
        'cmbProduct
        '
        Me.cmbProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbProduct.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbProduct.GridForeColor = System.Drawing.Color.Black
        Me.cmbProduct.Location = New System.Drawing.Point(572, 88)
        Me.cmbProduct.Name = "cmbProduct"
        Me.cmbProduct.Size = New System.Drawing.Size(157, 22)
        Me.cmbProduct.TabIndex = 7
        Me.cmbProduct.Value = Nothing
        '
        'cmbStepID
        '
        Me.cmbStepID.DirectInput = false
        Me.cmbStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStepID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStepID.GridForeColor = System.Drawing.Color.Black
        Me.cmbStepID.Location = New System.Drawing.Point(308, 88)
        Me.cmbStepID.Name = "cmbStepID"
        Me.cmbStepID.Size = New System.Drawing.Size(209, 22)
        Me.cmbStepID.TabIndex = 6
        Me.cmbStepID.Value = Nothing
        '
        'lblLot
        '
        Me.lblLot.AutoSize = true
        Me.lblLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLot.Location = New System.Drawing.Point(316, 28)
        Me.lblLot.Name = "lblLot"
        Me.lblLot.Size = New System.Drawing.Size(135, 15)
        Me.lblLot.TabIndex = 26
        Me.lblLot.Text = "(前方一致検索可)"
        '
        'lblPd
        '
        Me.lblPd.AutoSize = true
        Me.lblPd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPd.Location = New System.Drawing.Point(532, 92)
        Me.lblPd.Name = "lblPd"
        Me.lblPd.Size = New System.Drawing.Size(39, 15)
        Me.lblPd.TabIndex = 19
        Me.lblPd.Text = "機種"
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(874, 80)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(81, 17)
        Me.lblTitle6.TabIndex = 23
        Me.lblTitle6.Text = "該当件数"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(874, 96)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(81, 21)
        Me.lblLotCnt.TabIndex = 24
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(744, 96)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 22
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(744, 80)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle1.TabIndex = 21
        Me.lblTitle1.Text = "情報取得日時"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdAllOn
        '
        Me.cmdAllOn.CausesValidation = false
        Me.cmdAllOn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllOn.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAllOn.Location = New System.Drawing.Point(104, 597)
        Me.cmdAllOn.Name = "cmdAllOn"
        Me.cmdAllOn.Size = New System.Drawing.Size(85, 40)
        Me.cmdAllOn.TabIndex = 18
        Me.cmdAllOn.Text = "全てON"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 12
        Me.cmdClose.Text = "閉じる"
        '
        'fraLot
        '
        Me.fraLot.Controls.Add(Me.vsfLotList)
        Me.fraLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot.Location = New System.Drawing.Point(8, 152)
        Me.fraLot.Name = "fraLot"
        Me.fraLot.Size = New System.Drawing.Size(965, 441)
        Me.fraLot.TabIndex = 11
        Me.fraLot.TabStop = false
        Me.fraLot.Text = "区間優先設定"
        '
        'vsfLotList
        '
        Me.vsfLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotList.AllowEditing = false
        Me.vsfLotList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLotList.AutoResize = true
        Me.vsfLotList.AutoSearchDelay = 2R
        Me.vsfLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotList.ColumnInfo = resources.GetString("vsfLotList.ColumnInfo")
        Me.vsfLotList.EditOptions = CType((((C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotList.ExtendLastCol = true
        Me.vsfLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotList.Location = New System.Drawing.Point(8, 16)
        Me.vsfLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotList.Name = "vsfLotList"
        Me.vsfLotList.Rows.Count = 3
        Me.vsfLotList.Rows.DefaultSize = 18
        Me.vsfLotList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfLotList.Size = New System.Drawing.Size(951, 419)
        Me.vsfLotList.StyleInfo = resources.GetString("vsfLotList.StyleInfo")
        Me.vsfLotList.TabIndex = 11
        '
        'lblTitleHT
        '
        Me.lblTitleHT.AutoSize = true
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(891, 132)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(81, 17)
        Me.lblTitleHT.TabIndex = 28
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02I0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdClipCopy)
        Me.Controls.Add(Me.cmdHidden)
        Me.Controls.Add(Me.cmdDetail)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.frmSerch0)
        Me.Controls.Add(Me.cmdAllOn)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraLot)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02I0"
        Me.Text = "区間優先設定"
        Me.frmSerch0.ResumeLayout(false)
        Me.frmSerch0.PerformLayout
        Me.fraLot.ResumeLayout(false)
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmdClipCopy As Button
    Friend WithEvents cmdHidden As Button
    Friend WithEvents cmdDetail As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents frmSerch0 As GroupBox
    Friend WithEvents cmdSerchAdd As Button
    Friend WithEvents optSerch4 As RadioButton
    Friend WithEvents optSerch1 As RadioButton
    Friend WithEvents optSerch0 As RadioButton
    Friend WithEvents optSerch2 As RadioButton
    Friend WithEvents cmdSerch As Button
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbOpId As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbWpId As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbProduct As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbStepID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblLot As Label
    Friend WithEvents lblPd As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents cmdAllOn As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraLot As GroupBox
    Friend WithEvents vsfLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleHT As Label
End Class
