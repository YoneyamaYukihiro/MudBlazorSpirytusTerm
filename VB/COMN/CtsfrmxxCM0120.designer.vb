<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM0120
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM0120))
        Me.fraHoldSet = New System.Windows.Forms.GroupBox()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle12 = New System.Windows.Forms.Label()
        Me.lblTitle11 = New System.Windows.Forms.Label()
        Me.cmdHoldTxtUp = New System.Windows.Forms.Button()
        Me.cmdHoldTxtDown = New System.Windows.Forms.Button()
        Me.dtpHoldTermDate = New SECalendarEx.CalendarEx()
        Me.cmbMasHold = New SEComboBoxEx.ComboBoxEx()
        Me.cmbHoldEmpName = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitleHoldComment = New System.Windows.Forms.Label()
        Me.txtHoldComment = New SETextBoxEx.TextBoxEx()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.txtLotID = New SETextBoxEx.TextBoxEx()
        Me.fraHoldList = New System.Windows.Forms.GroupBox()
        Me.lblTitleHoldReleaseComment = New System.Windows.Forms.Label()
        Me.cmdVsfUP = New System.Windows.Forms.Button()
        Me.cmdVsfDown = New System.Windows.Forms.Button()
        Me.cmdTxtDown = New System.Windows.Forms.Button()
        Me.cmdTxtUp = New System.Windows.Forms.Button()
        Me.txtHoldCommentView = New SETextBoxEx.TextBoxEx()
        Me.vsfLotHoldList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblStartDayTime = New System.Windows.Forms.Label()
        Me.lblS = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblTimeLimit = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblGRB = New System.Windows.Forms.Label()
        Me.fraHoldSet.SuspendLayout
        Me.fraHoldList.SuspendLayout
        CType(Me.vsfLotHoldList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraHoldSet
        '
        Me.fraHoldSet.Controls.Add(Me.lblLengthCount)
        Me.fraHoldSet.Controls.Add(Me.lblTitle2)
        Me.fraHoldSet.Controls.Add(Me.lblTitle12)
        Me.fraHoldSet.Controls.Add(Me.lblTitle11)
        Me.fraHoldSet.Controls.Add(Me.cmdHoldTxtUp)
        Me.fraHoldSet.Controls.Add(Me.cmdHoldTxtDown)
        Me.fraHoldSet.Controls.Add(Me.dtpHoldTermDate)
        Me.fraHoldSet.Controls.Add(Me.cmbMasHold)
        Me.fraHoldSet.Controls.Add(Me.cmbHoldEmpName)
        Me.fraHoldSet.Controls.Add(Me.lblTitleHoldComment)
        Me.fraHoldSet.Controls.Add(Me.txtHoldComment)
        Me.fraHoldSet.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraHoldSet.Location = New System.Drawing.Point(8, 404)
        Me.fraHoldSet.Name = "fraHoldSet"
        Me.fraHoldSet.Size = New System.Drawing.Size(809, 168)
        Me.fraHoldSet.TabIndex = 2
        Me.fraHoldSet.TabStop = false
        Me.fraHoldSet.Text = "保留解除設定"
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(494, 75)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 43
        Me.lblLengthCount.Text = "（ 半角2048文字/半角2048文字 ）"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(448, 20)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(303, 17)
        Me.lblTitle2.TabIndex = 45
        Me.lblTitle2.Text = "保留責任者"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle12
        '
        Me.lblTitle12.BackColor = System.Drawing.Color.Navy
        Me.lblTitle12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle12.Location = New System.Drawing.Point(296, 20)
        Me.lblTitle12.Name = "lblTitle12"
        Me.lblTitle12.Size = New System.Drawing.Size(153, 17)
        Me.lblTitle12.TabIndex = 41
        Me.lblTitle12.Text = "保留期限"
        Me.lblTitle12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle11
        '
        Me.lblTitle11.BackColor = System.Drawing.Color.Navy
        Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle11.Location = New System.Drawing.Point(8, 20)
        Me.lblTitle11.Name = "lblTitle11"
        Me.lblTitle11.Size = New System.Drawing.Size(289, 17)
        Me.lblTitle11.TabIndex = 42
        Me.lblTitle11.Text = "保留理由"
        Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdHoldTxtUp
        '
        Me.cmdHoldTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldTxtUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHoldTxtUp.Location = New System.Drawing.Point(751, 74)
        Me.cmdHoldTxtUp.Name = "cmdHoldTxtUp"
        Me.cmdHoldTxtUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdHoldTxtUp.TabIndex = 12
        Me.cmdHoldTxtUp.Text = "▲"
        '
        'cmdHoldTxtDown
        '
        Me.cmdHoldTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldTxtDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHoldTxtDown.Location = New System.Drawing.Point(751, 117)
        Me.cmdHoldTxtDown.Name = "cmdHoldTxtDown"
        Me.cmdHoldTxtDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdHoldTxtDown.TabIndex = 13
        Me.cmdHoldTxtDown.Text = "▼"
        '
        'dtpHoldTermDate
        '
        Me.dtpHoldTermDate.DateCheckStatus = 0
        Me.dtpHoldTermDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpHoldTermDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpHoldTermDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpHoldTermDate.IsDate = true
        Me.dtpHoldTermDate.Location = New System.Drawing.Point(296, 36)
        Me.dtpHoldTermDate.Name = "dtpHoldTermDate"
        Me.dtpHoldTermDate.Size = New System.Drawing.Size(153, 28)
        Me.dtpHoldTermDate.TabIndex = 3
        Me.dtpHoldTermDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.dtpHoldTermDate.Value = "____/__/__"
        '
        'cmbMasHold
        '
        Me.cmbMasHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMasHold.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMasHold.Location = New System.Drawing.Point(8, 36)
        Me.cmbMasHold.Name = "cmbMasHold"
        Me.cmbMasHold.Size = New System.Drawing.Size(289, 28)
        Me.cmbMasHold.TabIndex = 2
        Me.cmbMasHold.Value = Nothing
        '
        'cmbHoldEmpName
        '
        Me.cmbHoldEmpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbHoldEmpName.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbHoldEmpName.Location = New System.Drawing.Point(448, 36)
        Me.cmbHoldEmpName.Name = "cmbHoldEmpName"
        Me.cmbHoldEmpName.Size = New System.Drawing.Size(303, 28)
        Me.cmbHoldEmpName.TabIndex = 4
        Me.cmbHoldEmpName.Value = Nothing
        '
        'lblTitleHoldComment
        '
        Me.lblTitleHoldComment.BackColor = System.Drawing.Color.Navy
        Me.lblTitleHoldComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHoldComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHoldComment.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleHoldComment.Location = New System.Drawing.Point(8, 74)
        Me.lblTitleHoldComment.Name = "lblTitleHoldComment"
        Me.lblTitleHoldComment.Size = New System.Drawing.Size(743, 18)
        Me.lblTitleHoldComment.TabIndex = 44
        Me.lblTitleHoldComment.Text = "      保留解除コメント"
        Me.lblTitleHoldComment.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtHoldComment
        '
        Me.txtHoldComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtHoldComment.ChrMaxByte = 0
        Me.txtHoldComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtHoldComment.GotHighLight = false
        Me.txtHoldComment.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtHoldComment.Location = New System.Drawing.Point(8, 90)
        Me.txtHoldComment.MultiLineEx = true
        Me.txtHoldComment.Name = "txtHoldComment"
        Me.txtHoldComment.NgChr = "'"
        Me.txtHoldComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtHoldComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHoldComment.SelectedText = ""
        Me.txtHoldComment.Size = New System.Drawing.Size(743, 69)
        Me.txtHoldComment.TabIndex = 11
        '
        'txtCarrierID
        '
        Me.txtCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID.ChrMaxByte = 6
        Me.txtCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrierID.Name = "txtCarrierID"
        Me.txtCarrierID.NgChr = "'"
        Me.txtCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID.SelectedText = ""
        Me.txtCarrierID.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrierID.TabIndex = 0
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 582)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 582)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 5
        Me.cmdRegist.Text = "確　定"
        '
        'txtLotID
        '
        Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLotID.ChrMaxByte = 10
        Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotID.Location = New System.Drawing.Point(16, 81)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.NgChr = "'"
        Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotID.SelectedText = ""
        Me.txtLotID.Size = New System.Drawing.Size(120, 30)
        Me.txtLotID.TabIndex = 1
        '
        'fraHoldList
        '
        Me.fraHoldList.Controls.Add(Me.lblTitleHoldReleaseComment)
        Me.fraHoldList.Controls.Add(Me.cmdVsfUP)
        Me.fraHoldList.Controls.Add(Me.cmdVsfDown)
        Me.fraHoldList.Controls.Add(Me.cmdTxtDown)
        Me.fraHoldList.Controls.Add(Me.cmdTxtUp)
        Me.fraHoldList.Controls.Add(Me.txtHoldCommentView)
        Me.fraHoldList.Controls.Add(Me.vsfLotHoldList)
        Me.fraHoldList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraHoldList.Location = New System.Drawing.Point(8, 124)
        Me.fraHoldList.Name = "fraHoldList"
        Me.fraHoldList.Size = New System.Drawing.Size(965, 273)
        Me.fraHoldList.TabIndex = 6
        Me.fraHoldList.TabStop = false
        Me.fraHoldList.Text = "保留情報"
        '
        'lblTitleHoldReleaseComment
        '
        Me.lblTitleHoldReleaseComment.BackColor = System.Drawing.Color.Navy
        Me.lblTitleHoldReleaseComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHoldReleaseComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHoldReleaseComment.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleHoldReleaseComment.Location = New System.Drawing.Point(8, 180)
        Me.lblTitleHoldReleaseComment.Name = "lblTitleHoldReleaseComment"
        Me.lblTitleHoldReleaseComment.Size = New System.Drawing.Size(743, 17)
        Me.lblTitleHoldReleaseComment.TabIndex = 39
        Me.lblTitleHoldReleaseComment.Text = "      保留コメント"
        Me.lblTitleHoldReleaseComment.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdVsfUP
        '
        Me.cmdVsfUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfUP.Location = New System.Drawing.Point(907, 19)
        Me.cmdVsfUP.Name = "cmdVsfUP"
        Me.cmdVsfUP.Size = New System.Drawing.Size(49, 77)
        Me.cmdVsfUP.TabIndex = 7
        Me.cmdVsfUP.Text = "▲"
        '
        'cmdVsfDown
        '
        Me.cmdVsfDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdVsfDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdVsfDown.Location = New System.Drawing.Point(907, 96)
        Me.cmdVsfDown.Name = "cmdVsfDown"
        Me.cmdVsfDown.Size = New System.Drawing.Size(49, 77)
        Me.cmdVsfDown.TabIndex = 8
        Me.cmdVsfDown.Text = "▼"
        '
        'cmdTxtDown
        '
        Me.cmdTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtDown.Location = New System.Drawing.Point(751, 222)
        Me.cmdTxtDown.Name = "cmdTxtDown"
        Me.cmdTxtDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdTxtDown.TabIndex = 10
        Me.cmdTxtDown.Text = "▼"
        '
        'cmdTxtUp
        '
        Me.cmdTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtUp.Location = New System.Drawing.Point(751, 179)
        Me.cmdTxtUp.Name = "cmdTxtUp"
        Me.cmdTxtUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdTxtUp.TabIndex = 9
        Me.cmdTxtUp.Text = "▲"
        '
        'txtHoldCommentView
        '
        Me.txtHoldCommentView.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtHoldCommentView.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtHoldCommentView.ChrMaxByte = 0
        Me.txtHoldCommentView.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtHoldCommentView.GotHighLight = false
        Me.txtHoldCommentView.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtHoldCommentView.Location = New System.Drawing.Point(8, 196)
        Me.txtHoldCommentView.MultiLineEx = true
        Me.txtHoldCommentView.Name = "txtHoldCommentView"
        Me.txtHoldCommentView.NgChr = "'"
        Me.txtHoldCommentView.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtHoldCommentView.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHoldCommentView.SelectedText = ""
        Me.txtHoldCommentView.Size = New System.Drawing.Size(743, 69)
        Me.txtHoldCommentView.TabIndex = 38
        Me.txtHoldCommentView.TabStop = false
        '
        'vsfLotHoldList
        '
        Me.vsfLotHoldList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotHoldList.AllowEditing = false
        Me.vsfLotHoldList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotHoldList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLotHoldList.AutoResize = true
        Me.vsfLotHoldList.AutoSearchDelay = 2R
        Me.vsfLotHoldList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotHoldList.ColumnInfo = resources.GetString("vsfLotHoldList.ColumnInfo")
        Me.vsfLotHoldList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotHoldList.ExtendLastCol = true
        Me.vsfLotHoldList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotHoldList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotHoldList.Location = New System.Drawing.Point(8, 20)
        Me.vsfLotHoldList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotHoldList.Name = "vsfLotHoldList"
        Me.vsfLotHoldList.Rows.Count = 5
        Me.vsfLotHoldList.Rows.DefaultSize = 18
        Me.vsfLotHoldList.Rows.MinSize = 21
        Me.vsfLotHoldList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfLotHoldList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotHoldList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotHoldList.Size = New System.Drawing.Size(899, 152)
        Me.vsfLotHoldList.StyleInfo = resources.GetString("vsfLotHoldList.StyleInfo")
        Me.vsfLotHoldList.TabIndex = 6
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(408, 64)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 36
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(408, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 31)
        Me.lblStepID.TabIndex = 35
        Me.lblStepID.Text = "ﾅﾝﾊﾞﾘﾝｸﾞ"
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(408, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 30)
        Me.lblOpID.TabIndex = 34
        Me.lblOpID.Text = "投入"
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(408, 16)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl2.TabIndex = 33
        Me.lblTtl2.Text = "大工程"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(868, 16)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl6.TabIndex = 32
        Me.lblTtl6.Text = "特殊特性"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStartTime
        '
        Me.lblStartTime.BackColor = System.Drawing.Color.Navy
        Me.lblStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartTime.ForeColor = System.Drawing.Color.Yellow
        Me.lblStartTime.Location = New System.Drawing.Point(688, 16)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(181, 17)
        Me.lblStartTime.TabIndex = 31
        Me.lblStartTime.Text = "処理開始日時"
        Me.lblStartTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStartDayTime
        '
        Me.lblStartDayTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStartDayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDayTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDayTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStartDayTime.Location = New System.Drawing.Point(688, 32)
        Me.lblStartDayTime.Name = "lblStartDayTime"
        Me.lblStartDayTime.Size = New System.Drawing.Size(181, 30)
        Me.lblStartDayTime.TabIndex = 30
        Me.lblStartDayTime.Text = "2004/12/04 13:30"
        '
        'lblS
        '
        Me.lblS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblS.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblS.Location = New System.Drawing.Point(868, 32)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(97, 30)
        Me.lblS.TabIndex = 29
        Me.lblS.Text = "なし"
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(312, 16)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl5.TabIndex = 28
        Me.lblTtl5.Text = "数量"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl3.TabIndex = 27
        Me.lblTtl3.Text = "機種"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdID
        '
        Me.lblPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(216, 32)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(97, 30)
        Me.lblPdID.TabIndex = 26
        Me.lblPdID.Text = "GTA"
        '
        'lblLotManager
        '
        Me.lblLotManager.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(688, 80)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(181, 31)
        Me.lblLotManager.TabIndex = 25
        Me.lblLotManager.Text = "笹谷　伸司"
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(688, 64)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl9.TabIndex = 24
        Me.lblTtl9.Text = "ロット担当"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTimeLimit
        '
        Me.lblTimeLimit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTimeLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTimeLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTimeLimit.Location = New System.Drawing.Point(312, 80)
        Me.lblTimeLimit.Name = "lblTimeLimit"
        Me.lblTimeLimit.Size = New System.Drawing.Size(97, 31)
        Me.lblTimeLimit.TabIndex = 23
        Me.lblTimeLimit.Text = "無し"
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(312, 64)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl10.TabIndex = 22
        Me.lblTtl10.Text = "時間制限"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(312, 32)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 30)
        Me.lblWFNo.TabIndex = 21
        Me.lblWFNo.Text = "8"
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(16, 64)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle1.TabIndex = 17
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(216, 64)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle7.TabIndex = 19
        Me.lblTitle7.Text = "状態"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(216, 80)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 31)
        Me.lblStatus.TabIndex = 18
        Me.lblStatus.Text = "待機中"
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(16, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle0.TabIndex = 16
        Me.lblTitle0.Text = "キャリアID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 31)
        Me.lblFlowClass.TabIndex = 15
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 110)
        Me.lblBack.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Navy
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Yellow
        Me.Label10.Location = New System.Drawing.Point(868, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 17)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "GRB"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGRB
        '
        Me.lblGRB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGRB.Location = New System.Drawing.Point(868, 80)
        Me.lblGRB.Name = "lblGRB"
        Me.lblGRB.Size = New System.Drawing.Size(97, 31)
        Me.lblGRB.TabIndex = 38
        '
        'frmxxCM0120
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblGRB)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.fraHoldSet)
        Me.Controls.Add(Me.txtCarrierID)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.txtLotID)
        Me.Controls.Add(Me.fraHoldList)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.lblStartDayTime)
        Me.Controls.Add(Me.lblS)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblTimeLimit)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM0120"
        Me.Text = "ロット保留/ロット保留解除"
        Me.fraHoldSet.ResumeLayout(false)
        Me.fraHoldList.ResumeLayout(false)
        CType(Me.vsfLotHoldList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraHoldSet As GroupBox
    Friend WithEvents cmdHoldTxtUp As Button
    Friend WithEvents cmdHoldTxtDown As Button
    Friend WithEvents txtHoldComment As SETextBoxEx.TextBoxEx
    Friend WithEvents dtpHoldTermDate As SECalendarEx.CalendarEx
    Friend WithEvents cmbMasHold As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbHoldEmpName As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents lblTitle12 As Label
    Friend WithEvents lblTitleHoldComment As Label
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents fraHoldList As GroupBox
    Friend WithEvents cmdVsfUP As Button
    Friend WithEvents cmdVsfDown As Button
    Friend WithEvents cmdTxtDown As Button
    Friend WithEvents cmdTxtUp As Button
    Friend WithEvents txtHoldCommentView As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfLotHoldList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitleHoldReleaseComment As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblStartTime As Label
    Friend WithEvents lblStartDayTime As Label
    Friend WithEvents lblS As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTimeLimit As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblGRB As Label
End Class
