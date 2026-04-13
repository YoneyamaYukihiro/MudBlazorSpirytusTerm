<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0230
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0230))
        Me.cmdWorkMemoUp = New System.Windows.Forms.Button()
        Me.cmdWorkMemoDown = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfPartLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtNum = New SETextBoxEx.TextBoxEx()
        Me.cmbReason = New SEComboBoxEx.ComboBoxEx()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.cmbPart = New SEComboBoxEx.ComboBoxEx()
        Me.cmbPartClass = New SEComboBoxEx.ComboBoxEx()
        Me.fraKubun = New System.Windows.Forms.Panel()
        Me.optKubun5 = New System.Windows.Forms.RadioButton()
        Me.optKubun1 = New System.Windows.Forms.RadioButton()
        Me.optKubun0 = New System.Windows.Forms.RadioButton()
        Me.optKubun3 = New System.Windows.Forms.RadioButton()
        Me.optKubun2 = New System.Windows.Forms.RadioButton()
        Me.optKubun4 = New System.Windows.Forms.RadioButton()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.lblReasonName = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblBackReason = New System.Windows.Forms.Label()
        CType(Me.vsfPartLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraKubun.SuspendLayout
        Me.lblTtl15.SuspendLayout
        Me.SuspendLayout
        '
        'cmdWorkMemoUp
        '
        Me.cmdWorkMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkMemoUp.Location = New System.Drawing.Point(911, 475)
        Me.cmdWorkMemoUp.Name = "cmdWorkMemoUp"
        Me.cmdWorkMemoUp.Size = New System.Drawing.Size(25, 46)
        Me.cmdWorkMemoUp.TabIndex = 10
        Me.cmdWorkMemoUp.Text = "▲"
        '
        'cmdWorkMemoDown
        '
        Me.cmdWorkMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkMemoDown.Location = New System.Drawing.Point(911, 522)
        Me.cmdWorkMemoDown.Name = "cmdWorkMemoDown"
        Me.cmdWorkMemoDown.Size = New System.Drawing.Size(25, 46)
        Me.cmdWorkMemoDown.TabIndex = 11
        Me.cmdWorkMemoDown.Text = "▼"
        '
        'cmdCopy
        '
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(792, 597)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopy.TabIndex = 13
        Me.cmdCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 597)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 12
        Me.cmdRegist.Text = "確　定"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(683, 7)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 14
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "閉じる"
        '
        'vsfPartLotList
        '
        Me.vsfPartLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfPartLotList.AllowEditing = false
        Me.vsfPartLotList.AutoSearchDelay = 2R
        Me.vsfPartLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfPartLotList.ColumnInfo = resources.GetString("vsfPartLotList.ColumnInfo")
        Me.vsfPartLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfPartLotList.ExtendLastCol = true
        Me.vsfPartLotList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfPartLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfPartLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfPartLotList.Location = New System.Drawing.Point(8, 56)
        Me.vsfPartLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfPartLotList.Name = "vsfPartLotList"
        Me.vsfPartLotList.Rows.Count = 40
        Me.vsfPartLotList.Rows.DefaultSize = 18
        Me.vsfPartLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfPartLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfPartLotList.Size = New System.Drawing.Size(930, 382)
        Me.vsfPartLotList.StyleInfo = resources.GetString("vsfPartLotList.StyleInfo")
        Me.vsfPartLotList.TabIndex = 2
        '
        'txtNum
        '
        Me.txtNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtNum.ChrMaxByte = 8
        Me.txtNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtNum.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtNum.Location = New System.Drawing.Point(384, 546)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.NgChr = "'"
        Me.txtNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtNum.NumFormat = "##,###,###"
        Me.txtNum.NumMax = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtNum.NumMin = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtNum.SelectedText = ""
        Me.txtNum.Size = New System.Drawing.Size(121, 25)
        Me.txtNum.TabIndex = 7
        Me.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbReason
        '
        Me.cmbReason.BackColor = System.Drawing.Color.White
        Me.cmbReason.DirectInput = false
        Me.cmbReason.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbReason.ForeColor = System.Drawing.Color.Black
        Me.cmbReason.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbReason.GridForeColor = System.Drawing.Color.Black
        Me.cmbReason.Location = New System.Drawing.Point(8, 546)
        Me.cmbReason.Name = "cmbReason"
        Me.cmbReason.Size = New System.Drawing.Size(369, 22)
        Me.cmbReason.TabIndex = 8
        Me.cmbReason.Value = Nothing
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(512, 492)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(399, 75)
        Me.txtWorkMemo.TabIndex = 9
        '
        'cmbPart
        '
        Me.cmbPart.BackColor = System.Drawing.Color.White
        Me.cmbPart.DirectInput = false
        Me.cmbPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.ForeColor = System.Drawing.Color.Black
        Me.cmbPart.GetCol = 2
        Me.cmbPart.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridForeColor = System.Drawing.Color.Black
        Me.cmbPart.Location = New System.Drawing.Point(187, 24)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(490, 22)
        Me.cmbPart.TabIndex = 1
        Me.cmbPart.Value = Nothing
        '
        'cmbPartClass
        '
        Me.cmbPartClass.BackColor = System.Drawing.Color.White
        Me.cmbPartClass.DirectInput = false
        Me.cmbPartClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartClass.ForeColor = System.Drawing.Color.Black
        Me.cmbPartClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPartClass.GridForeColor = System.Drawing.Color.Black
        Me.cmbPartClass.Location = New System.Drawing.Point(8, 24)
        Me.cmbPartClass.Name = "cmbPartClass"
        Me.cmbPartClass.Size = New System.Drawing.Size(180, 22)
        Me.cmbPartClass.TabIndex = 0
        Me.cmbPartClass.Value = Nothing
        '
        'fraKubun
        '
        Me.fraKubun.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraKubun.Controls.Add(Me.optKubun5)
        Me.fraKubun.Controls.Add(Me.optKubun1)
        Me.fraKubun.Controls.Add(Me.optKubun0)
        Me.fraKubun.Controls.Add(Me.optKubun3)
        Me.fraKubun.Controls.Add(Me.optKubun2)
        Me.fraKubun.Controls.Add(Me.optKubun4)
        Me.fraKubun.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraKubun.Location = New System.Drawing.Point(15, 496)
        Me.fraKubun.Name = "fraKubun"
        Me.fraKubun.Size = New System.Drawing.Size(489, 18)
        Me.fraKubun.TabIndex = 3
        '
        'optKubun5
        '
        Me.optKubun5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optKubun5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun5.Location = New System.Drawing.Point(400, -3)
        Me.optKubun5.Name = "optKubun5"
        Me.optKubun5.Size = New System.Drawing.Size(90, 24)
        Me.optKubun5.TabIndex = 33
        Me.optKubun5.Text = "実験転用"
        Me.optKubun5.UseVisualStyleBackColor = false
        '
        'optKubun1
        '
        Me.optKubun1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optKubun1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun1.Location = New System.Drawing.Point(100, -3)
        Me.optKubun1.Name = "optKubun1"
        Me.optKubun1.Size = New System.Drawing.Size(65, 24)
        Me.optKubun1.TabIndex = 32
        Me.optKubun1.Text = "不良"
        Me.optKubun1.UseVisualStyleBackColor = false
        '
        'optKubun0
        '
        Me.optKubun0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun0.Location = New System.Drawing.Point(8, -3)
        Me.optKubun0.Name = "optKubun0"
        Me.optKubun0.Size = New System.Drawing.Size(93, 24)
        Me.optKubun0.TabIndex = 3
        Me.optKubun0.Text = "例外受入"
        '
        'optKubun3
        '
        Me.optKubun3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optKubun3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun3.Location = New System.Drawing.Point(236, -3)
        Me.optKubun3.Name = "optKubun3"
        Me.optKubun3.Size = New System.Drawing.Size(65, 24)
        Me.optKubun3.TabIndex = 5
        Me.optKubun3.Text = "保留"
        Me.optKubun3.UseVisualStyleBackColor = false
        '
        'optKubun2
        '
        Me.optKubun2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optKubun2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun2.Location = New System.Drawing.Point(168, -3)
        Me.optKubun2.Name = "optKubun2"
        Me.optKubun2.Size = New System.Drawing.Size(65, 24)
        Me.optKubun2.TabIndex = 4
        Me.optKubun2.Text = "払出"
        Me.optKubun2.UseVisualStyleBackColor = false
        '
        'optKubun4
        '
        Me.optKubun4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.optKubun4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optKubun4.Location = New System.Drawing.Point(304, -3)
        Me.optKubun4.Name = "optKubun4"
        Me.optKubun4.Size = New System.Drawing.Size(90, 24)
        Me.optKubun4.TabIndex = 6
        Me.optKubun4.Text = "保留解除"
        Me.optKubun4.UseVisualStyleBackColor = false
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(774, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
        Me.lblNowDate.TabIndex = 31
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(774, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle1.TabIndex = 30
        Me.lblTitle1.Text = "情報取得日時"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(8, 476)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(497, 17)
        Me.lblTtl11.TabIndex = 24
        Me.lblTtl11.Text = "処理区分"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Yellow
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Black
        Me.lblTitle5.Location = New System.Drawing.Point(896, 450)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(41, 17)
        Me.lblTitle5.TabIndex = 29
        Me.lblTitle5.Text = "保留"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(8, 8)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(180, 17)
        Me.lblTtl1.TabIndex = 28
        Me.lblTtl1.Text = "部品種別"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(187, 8)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(490, 17)
        Me.lblTtl0.TabIndex = 27
        Me.lblTtl0.Text = "部品"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(141, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(247, 17)
        Me.lblLengthCount.TabIndex = 25
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 448)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle0.TabIndex = 21
        Me.lblTitle0.Text = "合計数量"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNum
        '
        Me.lblNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNum.Location = New System.Drawing.Point(263, 448)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(114, 17)
        Me.lblNum.TabIndex = 20
        Me.lblNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReasonName
        '
        Me.lblReasonName.BackColor = System.Drawing.Color.Navy
        Me.lblReasonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReasonName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReasonName.ForeColor = System.Drawing.Color.Yellow
        Me.lblReasonName.Location = New System.Drawing.Point(8, 530)
        Me.lblReasonName.Name = "lblReasonName"
        Me.lblReasonName.Size = New System.Drawing.Size(369, 17)
        Me.lblReasonName.TabIndex = 19
        Me.lblReasonName.Text = "理由"
        Me.lblReasonName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(384, 530)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(121, 17)
        Me.lblTtl3.TabIndex = 18
        Me.lblTtl3.Text = " 数量 (増減値)"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(901, 8)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle3.TabIndex = 17
        Me.lblTitle3.Text = "該当件数"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(901, 24)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(73, 22)
        Me.lblLotCnt.TabIndex = 16
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Controls.Add(Me.lblLengthCount)
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(512, 476)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(399, 17)
        Me.lblTtl15.TabIndex = 26
        Me.lblTtl15.Text = "         作業メモ"
        '
        'lblBackReason
        '
        Me.lblBackReason.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBackReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBackReason.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBackReason.Location = New System.Drawing.Point(8, 492)
        Me.lblBackReason.Name = "lblBackReason"
        Me.lblBackReason.Size = New System.Drawing.Size(497, 25)
        Me.lblBackReason.TabIndex = 23
        '
        'frmxxEN0230
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdWorkMemoUp)
        Me.Controls.Add(Me.cmdWorkMemoDown)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfPartLotList)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.cmbReason)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.cmbPartClass)
        Me.Controls.Add(Me.fraKubun)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTtl11)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblNum)
        Me.Controls.Add(Me.lblReasonName)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.lblBackReason)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0230"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "部材管理"
        CType(Me.vsfPartLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraKubun.ResumeLayout(false)
        Me.lblTtl15.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdWorkMemoUp As Button
    Friend WithEvents cmdWorkMemoDown As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfPartLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtNum As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbReason As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbPart As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbPartClass As SEComboBoxEx.ComboBoxEx
    Friend WithEvents fraKubun As Panel
    Friend WithEvents optKubun5 As RadioButton
    Friend WithEvents optKubun1 As RadioButton
    Friend WithEvents optKubun0 As RadioButton
    Friend WithEvents optKubun3 As RadioButton
    Friend WithEvents optKubun2 As RadioButton
    Friend WithEvents optKubun4 As RadioButton
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblNum As Label
    Friend WithEvents lblReasonName As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblBackReason As Label
End Class
