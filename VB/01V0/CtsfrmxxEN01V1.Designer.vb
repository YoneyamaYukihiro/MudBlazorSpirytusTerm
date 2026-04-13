<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01V1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01V1))
        Me.cmbOrderID = New SECmbIchiran.ComboIchiran()
        Me.cmdNowDate = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.txtMaterialLotID = New SETextBoxEx.TextBoxEx()
        Me.calProductDate = New SECalendarEx.CalendarEx()
        Me.calAcceptDate = New SECalendarEx.CalendarEx()
        Me.txtConsecutiveNum = New SETextBoxEx.TextBoxEx()
        Me.calStartUseDate = New SECalendarEx.CalendarEx()
        Me.medTime = New System.Windows.Forms.MaskedTextBox()
        Me.txtOrderNum = New SETextBoxEx.TextBoxEx()
        Me.lblOrderNumTitle = New System.Windows.Forms.Label()
        Me.lblOrderIDTitle = New System.Windows.Forms.Label()
        Me.lblTitleStartUseTime = New System.Windows.Forms.Label()
        Me.lblHiphen = New System.Windows.Forms.Label()
        Me.lblTitleTxtConsecutiveNum = New System.Windows.Forms.Label()
        Me.lblTitleMaterialID = New System.Windows.Forms.Label()
        Me.lblTitleMaterialTypeID = New System.Windows.Forms.Label()
        Me.lblTitleMaterialLotID = New System.Windows.Forms.Label()
        Me.lblTitleAccept = New System.Windows.Forms.Label()
        Me.lblTitleProduct = New System.Windows.Forms.Label()
        Me.lblMaterialID = New System.Windows.Forms.Label()
        Me.lblMaterialTypeID = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'cmbOrderID
        '
        Me.cmbOrderID.AllSelectButton = true
        Me.cmbOrderID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOrderID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbOrderID.Location = New System.Drawing.Point(8, 130)
        Me.cmbOrderID.Name = "cmbOrderID"
        Me.cmbOrderID.Size = New System.Drawing.Size(254, 28)
        Me.cmbOrderID.TabIndex = 2
        Me.cmbOrderID.Value = Nothing
        '
        'cmdNowDate
        '
        Me.cmdNowDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowDate.Location = New System.Drawing.Point(298, 297)
        Me.cmdNowDate.Name = "cmdNowDate"
        Me.cmdNowDate.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowDate.TabIndex = 10
        Me.cmdNowDate.Text = "現在日時"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 369)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 12
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(298, 369)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 11
        Me.cmdRegist.Text = "確　定"
        '
        'txtMaterialLotID
        '
        Me.txtMaterialLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtMaterialLotID.ChrMaxByte = 20
        Me.txtMaterialLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtMaterialLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMaterialLotID.Location = New System.Drawing.Point(8, 192)
        Me.txtMaterialLotID.Name = "txtMaterialLotID"
        Me.txtMaterialLotID.NgChr = "'"
        Me.txtMaterialLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtMaterialLotID.NumMax = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtMaterialLotID.NumMin = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMaterialLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMaterialLotID.SelectedText = ""
        Me.txtMaterialLotID.Size = New System.Drawing.Size(254, 30)
        Me.txtMaterialLotID.TabIndex = 4
        '
        'calProductDate
        '
        Me.calProductDate.CalendarHeight = 378
        Me.calProductDate.CalendarWidth = 410
        Me.calProductDate.DateCheckStatus = 0
        Me.calProductDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calProductDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calProductDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calProductDate.IsDate = true
        Me.calProductDate.Location = New System.Drawing.Point(8, 253)
        Me.calProductDate.Name = "calProductDate"
        Me.calProductDate.Size = New System.Drawing.Size(193, 28)
        Me.calProductDate.TabIndex = 6
        Me.calProductDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calProductDate.Value = "____/__/__"
        '
        'calAcceptDate
        '
        Me.calAcceptDate.CalendarHeight = 378
        Me.calAcceptDate.CalendarWidth = 410
        Me.calAcceptDate.DateCheckStatus = 0
        Me.calAcceptDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calAcceptDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calAcceptDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calAcceptDate.IsDate = true
        Me.calAcceptDate.Location = New System.Drawing.Point(211, 253)
        Me.calAcceptDate.Name = "calAcceptDate"
        Me.calAcceptDate.Size = New System.Drawing.Size(193, 28)
        Me.calAcceptDate.TabIndex = 7
        Me.calAcceptDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calAcceptDate.Value = "____/__/__"
        '
        'txtConsecutiveNum
        '
        Me.txtConsecutiveNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtConsecutiveNum.ChrMaxByte = 2
        Me.txtConsecutiveNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtConsecutiveNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtConsecutiveNum.Location = New System.Drawing.Point(297, 192)
        Me.txtConsecutiveNum.Name = "txtConsecutiveNum"
        Me.txtConsecutiveNum.NgChr = "'"
        Me.txtConsecutiveNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtConsecutiveNum.NumMax = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtConsecutiveNum.NumMin = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtConsecutiveNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtConsecutiveNum.SelectedText = ""
        Me.txtConsecutiveNum.Size = New System.Drawing.Size(106, 30)
        Me.txtConsecutiveNum.TabIndex = 5
        '
        'calStartUseDate
        '
        Me.calStartUseDate.CalendarHeight = 378
        Me.calStartUseDate.CalendarWidth = 410
        Me.calStartUseDate.DateCheckStatus = 0
        Me.calStartUseDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartUseDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartUseDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartUseDate.IsDate = true
        Me.calStartUseDate.Location = New System.Drawing.Point(8, 314)
        Me.calStartUseDate.Name = "calStartUseDate"
        Me.calStartUseDate.Size = New System.Drawing.Size(193, 28)
        Me.calStartUseDate.TabIndex = 8
        Me.calStartUseDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStartUseDate.Value = "____/__/__"
        '
        'medTime
        '
        Me.medTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medTime.Location = New System.Drawing.Point(200, 314)
        Me.medTime.Mask = "00:00"
        Me.medTime.Name = "medTime"
        Me.medTime.Size = New System.Drawing.Size(86, 28)
        Me.medTime.TabIndex = 9
        Me.medTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txtOrderNum
        '
        Me.txtOrderNum.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtOrderNum.ChrMaxByte = 2
        Me.txtOrderNum.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtOrderNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtOrderNum.Location = New System.Drawing.Point(296, 130)
        Me.txtOrderNum.Name = "txtOrderNum"
        Me.txtOrderNum.NgChr = "'"
        Me.txtOrderNum.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtOrderNum.NumMax = New Decimal(New Integer() {99, 0, 0, 0})
        Me.txtOrderNum.NumMin = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtOrderNum.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOrderNum.SelectedText = ""
        Me.txtOrderNum.Size = New System.Drawing.Size(106, 30)
        Me.txtOrderNum.TabIndex = 3
        Me.txtOrderNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrderNumTitle
        '
        Me.lblOrderNumTitle.BackColor = System.Drawing.Color.Navy
        Me.lblOrderNumTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderNumTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOrderNumTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblOrderNumTitle.Location = New System.Drawing.Point(296, 114)
        Me.lblOrderNumTitle.Name = "lblOrderNumTitle"
        Me.lblOrderNumTitle.Size = New System.Drawing.Size(106, 17)
        Me.lblOrderNumTitle.TabIndex = 22
        Me.lblOrderNumTitle.Text = "発注数"
        Me.lblOrderNumTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOrderIDTitle
        '
        Me.lblOrderIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblOrderIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOrderIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblOrderIDTitle.Location = New System.Drawing.Point(8, 114)
        Me.lblOrderIDTitle.Name = "lblOrderIDTitle"
        Me.lblOrderIDTitle.Size = New System.Drawing.Size(254, 17)
        Me.lblOrderIDTitle.TabIndex = 15
        Me.lblOrderIDTitle.Text = "発注ID"
        Me.lblOrderIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleStartUseTime
        '
        Me.lblTitleStartUseTime.BackColor = System.Drawing.Color.Navy
        Me.lblTitleStartUseTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleStartUseTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleStartUseTime.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleStartUseTime.Location = New System.Drawing.Point(8, 298)
        Me.lblTitleStartUseTime.Name = "lblTitleStartUseTime"
        Me.lblTitleStartUseTime.Size = New System.Drawing.Size(278, 17)
        Me.lblTitleStartUseTime.TabIndex = 21
        Me.lblTitleStartUseTime.Text = "使用開始日時"
        Me.lblTitleStartUseTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHiphen
        '
        Me.lblHiphen.AutoSize = true
        Me.lblHiphen.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblHiphen.Location = New System.Drawing.Point(272, 198)
        Me.lblHiphen.Name = "lblHiphen"
        Me.lblHiphen.Size = New System.Drawing.Size(19, 19)
        Me.lblHiphen.TabIndex = 17
        Me.lblHiphen.Text = "-"
        Me.lblHiphen.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleTxtConsecutiveNum
        '
        Me.lblTitleTxtConsecutiveNum.BackColor = System.Drawing.Color.Navy
        Me.lblTitleTxtConsecutiveNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleTxtConsecutiveNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleTxtConsecutiveNum.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleTxtConsecutiveNum.Location = New System.Drawing.Point(297, 176)
        Me.lblTitleTxtConsecutiveNum.Name = "lblTitleTxtConsecutiveNum"
        Me.lblTitleTxtConsecutiveNum.Size = New System.Drawing.Size(106, 17)
        Me.lblTitleTxtConsecutiveNum.TabIndex = 18
        Me.lblTitleTxtConsecutiveNum.Text = "連番"
        Me.lblTitleTxtConsecutiveNum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleMaterialID
        '
        Me.lblTitleMaterialID.BackColor = System.Drawing.Color.Navy
        Me.lblTitleMaterialID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleMaterialID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleMaterialID.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleMaterialID.Location = New System.Drawing.Point(8, 61)
        Me.lblTitleMaterialID.Name = "lblTitleMaterialID"
        Me.lblTitleMaterialID.Size = New System.Drawing.Size(395, 17)
        Me.lblTitleMaterialID.TabIndex = 14
        Me.lblTitleMaterialID.Text = "部材"
        Me.lblTitleMaterialID.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleMaterialTypeID
        '
        Me.lblTitleMaterialTypeID.BackColor = System.Drawing.Color.Navy
        Me.lblTitleMaterialTypeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleMaterialTypeID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleMaterialTypeID.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleMaterialTypeID.Location = New System.Drawing.Point(8, 6)
        Me.lblTitleMaterialTypeID.Name = "lblTitleMaterialTypeID"
        Me.lblTitleMaterialTypeID.Size = New System.Drawing.Size(213, 17)
        Me.lblTitleMaterialTypeID.TabIndex = 13
        Me.lblTitleMaterialTypeID.Text = "部材種別"
        Me.lblTitleMaterialTypeID.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleMaterialLotID
        '
        Me.lblTitleMaterialLotID.BackColor = System.Drawing.Color.Navy
        Me.lblTitleMaterialLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleMaterialLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleMaterialLotID.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleMaterialLotID.Location = New System.Drawing.Point(8, 176)
        Me.lblTitleMaterialLotID.Name = "lblTitleMaterialLotID"
        Me.lblTitleMaterialLotID.Size = New System.Drawing.Size(254, 17)
        Me.lblTitleMaterialLotID.TabIndex = 16
        Me.lblTitleMaterialLotID.Text = "部材管理ID"
        Me.lblTitleMaterialLotID.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleAccept
        '
        Me.lblTitleAccept.BackColor = System.Drawing.Color.Navy
        Me.lblTitleAccept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleAccept.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleAccept.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleAccept.Location = New System.Drawing.Point(211, 237)
        Me.lblTitleAccept.Name = "lblTitleAccept"
        Me.lblTitleAccept.Size = New System.Drawing.Size(193, 17)
        Me.lblTitleAccept.TabIndex = 20
        Me.lblTitleAccept.Text = "受入日"
        Me.lblTitleAccept.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleProduct
        '
        Me.lblTitleProduct.BackColor = System.Drawing.Color.Navy
        Me.lblTitleProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleProduct.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleProduct.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitleProduct.Location = New System.Drawing.Point(8, 237)
        Me.lblTitleProduct.Name = "lblTitleProduct"
        Me.lblTitleProduct.Size = New System.Drawing.Size(193, 17)
        Me.lblTitleProduct.TabIndex = 19
        Me.lblTitleProduct.Text = "製造日"
        Me.lblTitleProduct.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMaterialID
        '
        Me.lblMaterialID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMaterialID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMaterialID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMaterialID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMaterialID.Location = New System.Drawing.Point(8, 77)
        Me.lblMaterialID.Name = "lblMaterialID"
        Me.lblMaterialID.Size = New System.Drawing.Size(395, 25)
        Me.lblMaterialID.TabIndex = 1
        '
        'lblMaterialTypeID
        '
        Me.lblMaterialTypeID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMaterialTypeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMaterialTypeID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMaterialTypeID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMaterialTypeID.Location = New System.Drawing.Point(8, 22)
        Me.lblMaterialTypeID.Name = "lblMaterialTypeID"
        Me.lblMaterialTypeID.Size = New System.Drawing.Size(213, 25)
        Me.lblMaterialTypeID.TabIndex = 0
        '
        'frmxxEN01V1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(411, 433)
        Me.Controls.Add(Me.lblTitleMaterialTypeID)
        Me.Controls.Add(Me.lblOrderIDTitle)
        Me.Controls.Add(Me.lblOrderNumTitle)
        Me.Controls.Add(Me.lblTitleMaterialLotID)
        Me.Controls.Add(Me.lblTitleTxtConsecutiveNum)
        Me.Controls.Add(Me.lblTitleProduct)
        Me.Controls.Add(Me.lblTitleAccept)
        Me.Controls.Add(Me.lblTitleStartUseTime)
        Me.Controls.Add(Me.cmbOrderID)
        Me.Controls.Add(Me.cmdNowDate)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.txtMaterialLotID)
        Me.Controls.Add(Me.calProductDate)
        Me.Controls.Add(Me.calAcceptDate)
        Me.Controls.Add(Me.txtConsecutiveNum)
        Me.Controls.Add(Me.calStartUseDate)
        Me.Controls.Add(Me.medTime)
        Me.Controls.Add(Me.txtOrderNum)
        Me.Controls.Add(Me.lblHiphen)
        Me.Controls.Add(Me.lblTitleMaterialID)
        Me.Controls.Add(Me.lblMaterialID)
        Me.Controls.Add(Me.lblMaterialTypeID)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(370, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01V1"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "装置使用部材登録"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmbOrderID As SECmbIchiran.ComboIchiran
    Friend WithEvents cmdNowDate As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents txtMaterialLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents calProductDate As SECalendarEx.CalendarEx
    Friend WithEvents calAcceptDate As SECalendarEx.CalendarEx
    Friend WithEvents txtConsecutiveNum As SETextBoxEx.TextBoxEx
    Friend WithEvents calStartUseDate As SECalendarEx.CalendarEx
    Friend WithEvents medTime As MaskedTextBox
    Friend WithEvents txtOrderNum As SETextBoxEx.TextBoxEx
    Friend WithEvents lblOrderNumTitle As Label
    Friend WithEvents lblOrderIDTitle As Label
    Friend WithEvents lblTitleStartUseTime As Label
    Friend WithEvents lblHiphen As Label
    Friend WithEvents lblTitleTxtConsecutiveNum As Label
    Friend WithEvents lblTitleMaterialID As Label
    Friend WithEvents lblTitleMaterialTypeID As Label
    Friend WithEvents lblTitleMaterialLotID As Label
    Friend WithEvents lblTitleAccept As Label
    Friend WithEvents lblTitleProduct As Label
    Friend WithEvents lblMaterialID As Label
    Friend WithEvents lblMaterialTypeID As Label
End Class
