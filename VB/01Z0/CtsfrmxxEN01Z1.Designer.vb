<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01Z1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01Z1))
        Me.pic4 = New System.Windows.Forms.PictureBox()
        Me.lblStartDateTitle = New System.Windows.Forms.Label()
        Me.cmdNowDate = New System.Windows.Forms.Button()
        Me.calStartDate = New SECalendarEx.CalendarEx()
        Me.medStartTime = New System.Windows.Forms.MaskedTextBox()
        Me.cmdCommentDown = New System.Windows.Forms.Button()
        Me.cmdCommentUp = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraMainteInfo = New System.Windows.Forms.GroupBox()
        Me.pic3 = New System.Windows.Forms.PictureBox()
        Me.lblStopDurationTitle = New System.Windows.Forms.Label()
        Me.lblEndDateTitle = New System.Windows.Forms.Label()
        Me.txtStopTime = New SETextBoxEx.TextBoxEx()
        Me.medEndTime = New System.Windows.Forms.MaskedTextBox()
        Me.calEndDate = New SECalendarEx.CalendarEx()
        Me.pic2 = New System.Windows.Forms.PictureBox()
        Me.lblPreserveCategoryTitle = New System.Windows.Forms.Label()
        Me.cmbPreserveCategory = New SECmbIchiran.ComboIchiran()
        Me.cmdAllClear = New System.Windows.Forms.Button()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.lblMcGroupTitle = New System.Windows.Forms.Label()
        Me.lblWPTitle = New System.Windows.Forms.Label()
        Me.cmbMcGroup = New SECmbIchiran.ComboIchiran()
        Me.cmbWP = New SECmbIchiran.ComboIchiran()
        Me.txtComment = New SETextBoxEx.TextBoxEx()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblCommentTitle = New System.Windows.Forms.Label()
        CType(Me.pic4,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic4.SuspendLayout
        Me.fraMainteInfo.SuspendLayout
        CType(Me.pic3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic3.SuspendLayout
        CType(Me.pic2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic2.SuspendLayout
        CType(Me.pic1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic1.SuspendLayout
        Me.lblCommentTitle.SuspendLayout
        Me.SuspendLayout
        '
        'pic4
        '
        Me.pic4.Controls.Add(Me.lblStartDateTitle)
        Me.pic4.Controls.Add(Me.cmdNowDate)
        Me.pic4.Controls.Add(Me.calStartDate)
        Me.pic4.Controls.Add(Me.medStartTime)
        Me.pic4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic4.Location = New System.Drawing.Point(1, 66)
        Me.pic4.Name = "pic4"
        Me.pic4.Size = New System.Drawing.Size(443, 65)
        Me.pic4.TabIndex = 26
        Me.pic4.TabStop = false
        '
        'lblStartDateTitle
        '
        Me.lblStartDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblStartDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblStartDateTitle.Location = New System.Drawing.Point(7, 5)
        Me.lblStartDateTitle.Name = "lblStartDateTitle"
        Me.lblStartDateTitle.Size = New System.Drawing.Size(306, 17)
        Me.lblStartDateTitle.TabIndex = 27
        Me.lblStartDateTitle.Text = "開始(予定)日時"
        Me.lblStartDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdNowDate
        '
        Me.cmdNowDate.CausesValidation = false
        Me.cmdNowDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowDate.Location = New System.Drawing.Point(321, 4)
        Me.cmdNowDate.Name = "cmdNowDate"
        Me.cmdNowDate.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowDate.TabIndex = 4
        Me.cmdNowDate.Text = "現在日時"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"取得"
        '
        'calStartDate
        '
        Me.calStartDate.CalendarHeight = 378
        Me.calStartDate.CalendarWidth = 410
        Me.calStartDate.DateCheckStatus = 0
        Me.calStartDate.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.IsDate = true
        Me.calStartDate.Location = New System.Drawing.Point(7, 21)
        Me.calStartDate.Name = "calStartDate"
        Me.calStartDate.Size = New System.Drawing.Size(207, 28)
        Me.calStartDate.TabIndex = 2
        Me.calStartDate.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartDate.Value = "____/__/__"
        '
        'medStartTime
        '
        Me.medStartTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medStartTime.Location = New System.Drawing.Point(213, 21)
        Me.medStartTime.Mask = "00:00"
        Me.medStartTime.Name = "medStartTime"
        Me.medStartTime.ResetOnSpace = false
        Me.medStartTime.Size = New System.Drawing.Size(100, 28)
        Me.medStartTime.TabIndex = 3
        Me.medStartTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'cmdCommentDown
        '
        Me.cmdCommentDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentDown.Location = New System.Drawing.Point(694, 304)
        Me.cmdCommentDown.Name = "cmdCommentDown"
        Me.cmdCommentDown.Size = New System.Drawing.Size(49, 76)
        Me.cmdCommentDown.TabIndex = 11
        Me.cmdCommentDown.Text = "▼"
        '
        'cmdCommentUp
        '
        Me.cmdCommentUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentUp.Location = New System.Drawing.Point(694, 228)
        Me.cmdCommentUp.Name = "cmdCommentUp"
        Me.cmdCommentUp.Size = New System.Drawing.Size(49, 76)
        Me.cmdCommentUp.TabIndex = 10
        Me.cmdCommentUp.Text = "▲"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 387)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(638, 387)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 12
        Me.cmdRegist.Text = "確　定"
        '
        'fraMainteInfo
        '
        Me.fraMainteInfo.Controls.Add(Me.pic3)
        Me.fraMainteInfo.Controls.Add(Me.pic2)
        Me.fraMainteInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraMainteInfo.Location = New System.Drawing.Point(4, 134)
        Me.fraMainteInfo.Name = "fraMainteInfo"
        Me.fraMainteInfo.Size = New System.Drawing.Size(739, 83)
        Me.fraMainteInfo.TabIndex = 5
        Me.fraMainteInfo.TabStop = false
        Me.fraMainteInfo.Text = "装置メンテナンス計画設定"
        '
        'pic3
        '
        Me.pic3.Controls.Add(Me.lblStopDurationTitle)
        Me.pic3.Controls.Add(Me.lblEndDateTitle)
        Me.pic3.Controls.Add(Me.txtStopTime)
        Me.pic3.Controls.Add(Me.medEndTime)
        Me.pic3.Controls.Add(Me.calEndDate)
        Me.pic3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic3.Location = New System.Drawing.Point(324, 15)
        Me.pic3.Name = "pic3"
        Me.pic3.Size = New System.Drawing.Size(407, 55)
        Me.pic3.TabIndex = 23
        Me.pic3.TabStop = false
        '
        'lblStopDurationTitle
        '
        Me.lblStopDurationTitle.BackColor = System.Drawing.Color.Navy
        Me.lblStopDurationTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStopDurationTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStopDurationTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblStopDurationTitle.Location = New System.Drawing.Point(7, 6)
        Me.lblStopDurationTitle.Name = "lblStopDurationTitle"
        Me.lblStopDurationTitle.Size = New System.Drawing.Size(117, 17)
        Me.lblStopDurationTitle.TabIndex = 24
        Me.lblStopDurationTitle.Text = "停止時間"
        Me.lblStopDurationTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEndDateTitle
        '
        Me.lblEndDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblEndDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEndDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEndDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblEndDateTitle.Location = New System.Drawing.Point(135, 6)
        Me.lblEndDateTitle.Name = "lblEndDateTitle"
        Me.lblEndDateTitle.Size = New System.Drawing.Size(263, 17)
        Me.lblEndDateTitle.TabIndex = 25
        Me.lblEndDateTitle.Text = "終了(予定)日時"
        Me.lblEndDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtStopTime
        '
        Me.txtStopTime.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Lower
        Me.txtStopTime.ChrMaxByte = 8
        Me.txtStopTime.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtStopTime.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtStopTime.Location = New System.Drawing.Point(7, 22)
        Me.txtStopTime.Name = "txtStopTime"
        Me.txtStopTime.NgChr = "'"
        Me.txtStopTime.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_2_Decimal
        Me.txtStopTime.NumFormat = "#,##0.00"
        Me.txtStopTime.NumMax = New Decimal(New Integer() {9999999, 0, 0, 131072})
        Me.txtStopTime.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtStopTime.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtStopTime.SelectedText = ""
        Me.txtStopTime.Size = New System.Drawing.Size(117, 28)
        Me.txtStopTime.TabIndex = 6
        Me.txtStopTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'medEndTime
        '
        Me.medEndTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medEndTime.Location = New System.Drawing.Point(308, 22)
        Me.medEndTime.Mask = "00:00"
        Me.medEndTime.Name = "medEndTime"
        Me.medEndTime.ResetOnSpace = false
        Me.medEndTime.Size = New System.Drawing.Size(90, 28)
        Me.medEndTime.TabIndex = 8
        Me.medEndTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'calEndDate
        '
        Me.calEndDate.CalendarHeight = 378
        Me.calEndDate.CalendarWidth = 410
        Me.calEndDate.DateCheckStatus = 0
        Me.calEndDate.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEndDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEndDate.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEndDate.IsDate = true
        Me.calEndDate.Location = New System.Drawing.Point(135, 22)
        Me.calEndDate.Name = "calEndDate"
        Me.calEndDate.Size = New System.Drawing.Size(174, 28)
        Me.calEndDate.TabIndex = 7
        Me.calEndDate.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEndDate.Value = "____/__/__"
        '
        'pic2
        '
        Me.pic2.Controls.Add(Me.lblPreserveCategoryTitle)
        Me.pic2.Controls.Add(Me.cmbPreserveCategory)
        Me.pic2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic2.Location = New System.Drawing.Point(7, 15)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(319, 55)
        Me.pic2.TabIndex = 19
        Me.pic2.TabStop = false
        '
        'lblPreserveCategoryTitle
        '
        Me.lblPreserveCategoryTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveCategoryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCategoryTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreserveCategoryTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveCategoryTitle.Location = New System.Drawing.Point(5, 6)
        Me.lblPreserveCategoryTitle.Name = "lblPreserveCategoryTitle"
        Me.lblPreserveCategoryTitle.Size = New System.Drawing.Size(307, 17)
        Me.lblPreserveCategoryTitle.TabIndex = 20
        Me.lblPreserveCategoryTitle.Text = "保全カテゴリ"
        Me.lblPreserveCategoryTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbPreserveCategory
        '
        Me.cmbPreserveCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPreserveCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPreserveCategory.Location = New System.Drawing.Point(5, 21)
        Me.cmbPreserveCategory.Name = "cmbPreserveCategory"
        Me.cmbPreserveCategory.Size = New System.Drawing.Size(307, 28)
        Me.cmbPreserveCategory.TabIndex = 5
        Me.cmbPreserveCategory.Value = Nothing
        '
        'cmdAllClear
        '
        Me.cmdAllClear.CausesValidation = false
        Me.cmdAllClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAllClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAllClear.Location = New System.Drawing.Point(525, 387)
        Me.cmdAllClear.Name = "cmdAllClear"
        Me.cmdAllClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdAllClear.TabIndex = 13
        Me.cmdAllClear.Text = "全部取消"
        '
        'pic1
        '
        Me.pic1.Controls.Add(Me.lblMcGroupTitle)
        Me.pic1.Controls.Add(Me.lblWPTitle)
        Me.pic1.Controls.Add(Me.cmbMcGroup)
        Me.pic1.Controls.Add(Me.cmbWP)
        Me.pic1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic1.Location = New System.Drawing.Point(3, 3)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(745, 58)
        Me.pic1.TabIndex = 16
        Me.pic1.TabStop = false
        '
        'lblMcGroupTitle
        '
        Me.lblMcGroupTitle.BackColor = System.Drawing.Color.Navy
        Me.lblMcGroupTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMcGroupTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMcGroupTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblMcGroupTitle.Location = New System.Drawing.Point(5, 5)
        Me.lblMcGroupTitle.Name = "lblMcGroupTitle"
        Me.lblMcGroupTitle.Size = New System.Drawing.Size(306, 17)
        Me.lblMcGroupTitle.TabIndex = 18
        Me.lblMcGroupTitle.Text = "装置グループ"
        Me.lblMcGroupTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWPTitle
        '
        Me.lblWPTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWPTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWPTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWPTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWPTitle.Location = New System.Drawing.Point(318, 5)
        Me.lblWPTitle.Name = "lblWPTitle"
        Me.lblWPTitle.Size = New System.Drawing.Size(422, 17)
        Me.lblWPTitle.TabIndex = 17
        Me.lblWPTitle.Text = "装置名"
        Me.lblWPTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbMcGroup
        '
        Me.cmbMcGroup.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.Location = New System.Drawing.Point(5, 21)
        Me.cmbMcGroup.Name = "cmbMcGroup"
        Me.cmbMcGroup.Size = New System.Drawing.Size(306, 28)
        Me.cmbMcGroup.TabIndex = 0
        Me.cmbMcGroup.Value = Nothing
        '
        'cmbWP
        '
        Me.cmbWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWP.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWP.Location = New System.Drawing.Point(318, 21)
        Me.cmbWP.Name = "cmbWP"
        Me.cmbWP.Size = New System.Drawing.Size(422, 28)
        Me.cmbWP.TabIndex = 1
        Me.cmbWP.Value = Nothing
        '
        'txtComment
        '
        Me.txtComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComment.ChrMaxByte = 0
        Me.txtComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtComment.GotHighLight = false
        Me.txtComment.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtComment.Location = New System.Drawing.Point(8, 245)
        Me.txtComment.MultiLineEx = true
        Me.txtComment.Name = "txtComment"
        Me.txtComment.NgChr = "'"
        Me.txtComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComment.SelectedText = ""
        Me.txtComment.Size = New System.Drawing.Size(686, 134)
        Me.txtComment.TabIndex = 9
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(427, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(256, 17)
        Me.lblLengthCount.TabIndex = 21
        Me.lblLengthCount.Text = "（ 半角2048文字/半角2048文字 ）"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCommentTitle
        '
        Me.lblCommentTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCommentTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCommentTitle.Controls.Add(Me.lblLengthCount)
        Me.lblCommentTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCommentTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCommentTitle.Location = New System.Drawing.Point(8, 229)
        Me.lblCommentTitle.Name = "lblCommentTitle"
        Me.lblCommentTitle.Size = New System.Drawing.Size(687, 17)
        Me.lblCommentTitle.TabIndex = 22
        Me.lblCommentTitle.Text = "コメント"
        Me.lblCommentTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01Z1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(751, 452)
        Me.Controls.Add(Me.pic4)
        Me.Controls.Add(Me.cmdCommentDown)
        Me.Controls.Add(Me.cmdCommentUp)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.fraMainteInfo)
        Me.Controls.Add(Me.cmdAllClear)
        Me.Controls.Add(Me.pic1)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.lblCommentTitle)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01Z1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "新規登録"
        CType(Me.pic4,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic4.ResumeLayout(false)
        Me.pic4.PerformLayout
        Me.fraMainteInfo.ResumeLayout(false)
        CType(Me.pic3,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic3.ResumeLayout(false)
        Me.pic3.PerformLayout
        CType(Me.pic2,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic2.ResumeLayout(false)
        CType(Me.pic1,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic1.ResumeLayout(false)
        Me.lblCommentTitle.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents pic4 As PictureBox
    Friend WithEvents cmdNowDate As Button
    Friend WithEvents calStartDate As SECalendarEx.CalendarEx
    Friend WithEvents medStartTime As MaskedTextBox
    Friend WithEvents lblStartDateTitle As Label
    Friend WithEvents cmdCommentDown As Button
    Friend WithEvents cmdCommentUp As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraMainteInfo As GroupBox
    Friend WithEvents pic3 As PictureBox
    Friend WithEvents txtStopTime As SETextBoxEx.TextBoxEx
    Friend WithEvents medEndTime As MaskedTextBox
    Friend WithEvents calEndDate As SECalendarEx.CalendarEx
    Friend WithEvents lblEndDateTitle As Label
    Friend WithEvents lblStopDurationTitle As Label
    Friend WithEvents pic2 As PictureBox
    Friend WithEvents cmbPreserveCategory As SECmbIchiran.ComboIchiran
    Friend WithEvents lblPreserveCategoryTitle As Label
    Friend WithEvents cmdAllClear As Button
    Friend WithEvents pic1 As PictureBox
    Friend WithEvents cmbMcGroup As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbWP As SECmbIchiran.ComboIchiran
    Friend WithEvents lblMcGroupTitle As Label
    Friend WithEvents lblWPTitle As Label
    Friend WithEvents txtComment As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblCommentTitle As Label
End Class
