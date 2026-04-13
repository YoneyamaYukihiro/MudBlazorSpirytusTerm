<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01X0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01X0))
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdReturn = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdLotChoice = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraLotList = New System.Windows.Forms.GroupBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtUserID = New SETextBoxEx.TextBoxEx()
        Me.vsfProcCngList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitleFlowChange = New System.Windows.Forms.Label()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblListCnt = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblGetInfoDate = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.fraLotList.SuspendLayout
        CType(Me.vsfProcCngList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp.Location = New System.Drawing.Point(910, 467)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(25, 57)
        Me.cmdUp.TabIndex = 2
        Me.cmdUp.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(910, 526)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(25, 57)
        Me.cmdDown.TabIndex = 3
        Me.cmdDown.Text = "▼"
        '
        'cmdReturn
        '
        Me.cmdReturn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReturn.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdReturn.Location = New System.Drawing.Point(793, 595)
        Me.cmdReturn.Name = "cmdReturn"
        Me.cmdReturn.Size = New System.Drawing.Size(85, 40)
        Me.cmdReturn.TabIndex = 5
        Me.cmdReturn.Text = "差し戻し"
        '
        'cmdDelete
        '
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDelete.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(344, 595)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(85, 40)
        Me.cmdDelete.TabIndex = 6
        Me.cmdDelete.Text = "編集情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"削除"
        '
        'cmdLotChoice
        '
        Me.cmdLotChoice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotChoice.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotChoice.Location = New System.Drawing.Point(152, 595)
        Me.cmdLotChoice.Name = "cmdLotChoice"
        Me.cmdLotChoice.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotChoice.TabIndex = 8
        Me.cmdLotChoice.Text = "工順変更ﾛｯﾄ選択"
        '
        'cmdEdit
        '
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEdit.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdEdit.Location = New System.Drawing.Point(249, 595)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(85, 40)
        Me.cmdEdit.TabIndex = 7
        Me.cmdEdit.Text = "編　集"
        '
        'cmdApply
        '
        Me.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdApply.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdApply.Location = New System.Drawing.Point(888, 595)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(85, 40)
        Me.cmdApply.TabIndex = 4
        Me.cmdApply.Text = "適　用"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 595)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "閉じる"
        '
        'fraLotList
        '
        Me.fraLotList.Controls.Add(Me.cmdSearch)
        Me.fraLotList.Controls.Add(Me.txtUserID)
        Me.fraLotList.Controls.Add(Me.vsfProcCngList)
        Me.fraLotList.Controls.Add(Me.lblTitleFlowChange)
        Me.fraLotList.Controls.Add(Me.lblTitleChip)
        Me.fraLotList.Controls.Add(Me.lblTitleHT)
        Me.fraLotList.Controls.Add(Me.lblTitle2)
        Me.fraLotList.Controls.Add(Me.lblListCnt)
        Me.fraLotList.Controls.Add(Me.lblTitle4)
        Me.fraLotList.Controls.Add(Me.lblGetInfoDate)
        Me.fraLotList.Controls.Add(Me.lblTitleR)
        Me.fraLotList.Controls.Add(Me.lblTitleL)
        Me.fraLotList.Controls.Add(Me.lblUserName)
        Me.fraLotList.Controls.Add(Me.lblTitle1)
        Me.fraLotList.Controls.Add(Me.lblTitle0)
        Me.fraLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLotList.Location = New System.Drawing.Point(8, 8)
        Me.fraLotList.Name = "fraLotList"
        Me.fraLotList.Size = New System.Drawing.Size(961, 449)
        Me.fraLotList.TabIndex = 0
        Me.fraLotList.TabStop = false
        Me.fraLotList.Text = "工順変更中ロットリスト"
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(662, 22)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSearch.TabIndex = 9
        Me.cmdSearch.Text = "最新取得"
        '
        'txtUserID
        '
        Me.txtUserID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtUserID.ChrMaxByte = 7
        Me.txtUserID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtUserID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_ChrNumeric
        Me.txtUserID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtUserID.Location = New System.Drawing.Point(12, 40)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtUserID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUserID.SelectedText = ""
        Me.txtUserID.Size = New System.Drawing.Size(153, 22)
        Me.txtUserID.TabIndex = 0
        '
        'vsfProcCngList
        '
        Me.vsfProcCngList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfProcCngList.AllowEditing = false
        Me.vsfProcCngList.AutoResize = true
        Me.vsfProcCngList.AutoSearchDelay = 2R
        Me.vsfProcCngList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfProcCngList.ColumnInfo = resources.GetString("vsfProcCngList.ColumnInfo")
        Me.vsfProcCngList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfProcCngList.ExtendLastCol = true
        Me.vsfProcCngList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfProcCngList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfProcCngList.Location = New System.Drawing.Point(12, 72)
        Me.vsfProcCngList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfProcCngList.Name = "vsfProcCngList"
        Me.vsfProcCngList.Rows.Count = 20
        Me.vsfProcCngList.Rows.DefaultSize = 18
        Me.vsfProcCngList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfProcCngList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfProcCngList.Size = New System.Drawing.Size(935, 363)
        Me.vsfProcCngList.StyleInfo = resources.GetString("vsfProcCngList.StyleInfo")
        Me.vsfProcCngList.TabIndex = 1
        '
        'lblTitleFlowChange
        '
        Me.lblTitleFlowChange.BackColor = System.Drawing.Color.Red
        Me.lblTitleFlowChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleFlowChange.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleFlowChange.ForeColor = System.Drawing.Color.Black
        Me.lblTitleFlowChange.Location = New System.Drawing.Point(509, 24)
        Me.lblTitleFlowChange.Name = "lblTitleFlowChange"
        Me.lblTitleFlowChange.Size = New System.Drawing.Size(146, 18)
        Me.lblTitleFlowChange.TabIndex = 25
        Me.lblTitleFlowChange.Text = " №：工順変更あり "
        Me.lblTitleFlowChange.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleFlowChange.UseMnemonic = false
        '
        'lblTitleChip
        '
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(385, 43)
        Me.lblTitleChip.Name = "lblTitleChip"
        Me.lblTitleChip.Size = New System.Drawing.Size(106, 18)
        Me.lblTitleChip.TabIndex = 24
        Me.lblTitleChip.Text = "青字：Chip品"
        Me.lblTitleChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleChip.UseMnemonic = false
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(574, 43)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(81, 18)
        Me.lblTitleHT.TabIndex = 23
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(873, 23)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle2.TabIndex = 22
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblListCnt
        '
        Me.lblListCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblListCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblListCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblListCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblListCnt.Location = New System.Drawing.Point(873, 39)
        Me.lblListCnt.Name = "lblListCnt"
        Me.lblListCnt.Size = New System.Drawing.Size(73, 22)
        Me.lblListCnt.TabIndex = 21
        Me.lblListCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(749, 23)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle4.TabIndex = 20
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGetInfoDate
        '
        Me.lblGetInfoDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGetInfoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGetInfoDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGetInfoDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGetInfoDate.Location = New System.Drawing.Point(749, 39)
        Me.lblGetInfoDate.Name = "lblGetInfoDate"
        Me.lblGetInfoDate.Size = New System.Drawing.Size(121, 22)
        Me.lblGetInfoDate.TabIndex = 19
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(532, 43)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(43, 18)
        Me.lblTitleR.TabIndex = 18
        Me.lblTitleR.Text = "R"
        Me.lblTitleR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleR.UseMnemonic = false
        '
        'lblTitleL
        '
        Me.lblTitleL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleL.ForeColor = System.Drawing.Color.Black
        Me.lblTitleL.Location = New System.Drawing.Point(490, 43)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(43, 18)
        Me.lblTitleL.TabIndex = 17
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUserName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUserName.Location = New System.Drawing.Point(164, 40)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(169, 22)
        Me.lblUserName.TabIndex = 15
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(164, 24)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(169, 17)
        Me.lblTitle1.TabIndex = 14
        Me.lblTitle1.Text = "ユーザー名"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(12, 24)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(153, 17)
        Me.lblTitle0.TabIndex = 13
        Me.lblTitle0.Text = "ユーザーID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.txtComments.Location = New System.Drawing.Point(8, 484)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(902, 98)
        Me.txtComments.TabIndex = 11
        Me.txtComments.TabStop = false
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 468)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(902, 17)
        Me.lblTtl15.TabIndex = 16
        Me.lblTtl15.Text = "工順変更コメント"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01X0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdReturn)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdLotChoice)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraLotList)
        Me.Controls.Add(Me.txtComments)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01X0"
        Me.Text = "ロット工順変更"
        Me.fraLotList.ResumeLayout(false)
        CType(Me.vsfProcCngList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdReturn As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdLotChoice As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdApply As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraLotList As GroupBox
    Friend WithEvents cmdSearch As Button
    Friend WithEvents txtUserID As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfProcCngList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleFlowChange As Label
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblListCnt As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblGetInfoDate As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl15 As Label
End Class
