<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01X7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01X7))
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.fraSearch = New System.Windows.Forms.Panel()
        Me.optSearch1 = New System.Windows.Forms.RadioButton()
        Me.optSearch0 = New System.Windows.Forms.RadioButton()
        Me.fraKisyu = New System.Windows.Forms.Panel()
        Me.optFlowClass2 = New System.Windows.Forms.RadioButton()
        Me.optFlowClass0 = New System.Windows.Forms.RadioButton()
        Me.optFlowClass1 = New System.Windows.Forms.RadioButton()
        Me.cmbFlowClass = New SECmbIchiran.ComboIchiran()
        Me.txtLotID = New SETextBoxEx.TextBoxEx()
        Me.cmbPD = New SECmbIchiran.ComboIchiran()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfLotListCp = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.fraSearch.SuspendLayout
        Me.fraKisyu.SuspendLayout
        CType(Me.vsfLotListCp,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(519, 64)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 9
        Me.cmdNowList.Text = "最新取得"
        '
        'fraSearch
        '
        Me.fraSearch.Controls.Add(Me.optSearch1)
        Me.fraSearch.Controls.Add(Me.optSearch0)
        Me.fraSearch.Controls.Add(Me.fraKisyu)
        Me.fraSearch.Controls.Add(Me.cmbFlowClass)
        Me.fraSearch.Controls.Add(Me.txtLotID)
        Me.fraSearch.Controls.Add(Me.cmbPD)
        Me.fraSearch.Controls.Add(Me.lblTitleChip)
        Me.fraSearch.Controls.Add(Me.lblTitleHT)
        Me.fraSearch.Controls.Add(Me.lblTitleR)
        Me.fraSearch.Controls.Add(Me.lblTitleL)
        Me.fraSearch.Controls.Add(Me.lblTitle8)
        Me.fraSearch.Controls.Add(Me.lblTitle1)
        Me.fraSearch.Controls.Add(Me.lblTitle0)
        Me.fraSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSearch.Location = New System.Drawing.Point(-4, 4)
        Me.fraSearch.Name = "fraSearch"
        Me.fraSearch.Size = New System.Drawing.Size(409, 103)
        Me.fraSearch.TabIndex = 0
        '
        'optSearch1
        '
        Me.optSearch1.Checked = true
        Me.optSearch1.Location = New System.Drawing.Point(14, 68)
        Me.optSearch1.Name = "optSearch1"
        Me.optSearch1.Size = New System.Drawing.Size(17, 25)
        Me.optSearch1.TabIndex = 1
        Me.optSearch1.TabStop = true
        '
        'optSearch0
        '
        Me.optSearch0.Location = New System.Drawing.Point(15, 16)
        Me.optSearch0.Name = "optSearch0"
        Me.optSearch0.Size = New System.Drawing.Size(17, 25)
        Me.optSearch0.TabIndex = 0
        '
        'fraKisyu
        '
        Me.fraKisyu.Controls.Add(Me.optFlowClass2)
        Me.fraKisyu.Controls.Add(Me.optFlowClass0)
        Me.fraKisyu.Controls.Add(Me.optFlowClass1)
        Me.fraKisyu.Location = New System.Drawing.Point(293, -2)
        Me.fraKisyu.Name = "fraKisyu"
        Me.fraKisyu.Size = New System.Drawing.Size(127, 71)
        Me.fraKisyu.TabIndex = 4
        '
        'optFlowClass2
        '
        Me.optFlowClass2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optFlowClass2.Location = New System.Drawing.Point(16, 44)
        Me.optFlowClass2.Name = "optFlowClass2"
        Me.optFlowClass2.Size = New System.Drawing.Size(101, 18)
        Me.optFlowClass2.TabIndex = 6
        Me.optFlowClass2.Text = "流動終了"
        '
        'optFlowClass0
        '
        Me.optFlowClass0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optFlowClass0.Location = New System.Drawing.Point(16, 4)
        Me.optFlowClass0.Name = "optFlowClass0"
        Me.optFlowClass0.Size = New System.Drawing.Size(101, 18)
        Me.optFlowClass0.TabIndex = 4
        Me.optFlowClass0.Text = "流動前"
        '
        'optFlowClass1
        '
        Me.optFlowClass1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optFlowClass1.Location = New System.Drawing.Point(16, 24)
        Me.optFlowClass1.Name = "optFlowClass1"
        Me.optFlowClass1.Size = New System.Drawing.Size(101, 18)
        Me.optFlowClass1.TabIndex = 5
        Me.optFlowClass1.Text = "流動中"
        '
        'cmbFlowClass
        '
        Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.Location = New System.Drawing.Point(167, 24)
        Me.cmbFlowClass.Name = "cmbFlowClass"
        Me.cmbFlowClass.Size = New System.Drawing.Size(125, 22)
        Me.cmbFlowClass.TabIndex = 3
        Me.cmbFlowClass.Value = Nothing
        '
        'txtLotID
        '
        Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLotID.ChrMaxByte = 10
        Me.txtLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotID.Location = New System.Drawing.Point(38, 76)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotID.SelectedText = ""
        Me.txtLotID.Size = New System.Drawing.Size(153, 22)
        Me.txtLotID.TabIndex = 7
        '
        'cmbPD
        '
        Me.cmbPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridForeColor = System.Drawing.Color.Black
        Me.cmbPD.Location = New System.Drawing.Point(39, 24)
        Me.cmbPD.Name = "cmbPD"
        Me.cmbPD.Size = New System.Drawing.Size(126, 22)
        Me.cmbPD.TabIndex = 2
        Me.cmbPD.Value = Nothing
        '
        'lblTitleChip
        '
        Me.lblTitleChip.AutoSize = true
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(290, 79)
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
        Me.lblTitleHT.Location = New System.Drawing.Point(206, 79)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(85, 18)
        Me.lblTitleHT.TabIndex = 23
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(250, 61)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(41, 19)
        Me.lblTitleR.TabIndex = 22
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
        Me.lblTitleL.Location = New System.Drawing.Point(206, 61)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(45, 19)
        Me.lblTitleL.TabIndex = 21
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(38, 60)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(153, 17)
        Me.lblTitle8.TabIndex = 16
        Me.lblTitle8.Text = "ロットID(前方一致)"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(167, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(125, 17)
        Me.lblTitle1.TabIndex = 15
        Me.lblTitle1.Text = "種別"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(39, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(126, 17)
        Me.lblTitle0.TabIndex = 14
        Me.lblTitle0.Text = "機種"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(520, 499)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 10
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 499)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 11
        Me.cmdClose.Text = "閉じる"
        '
        'vsfLotListCp
        '
        Me.vsfLotListCp.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotListCp.AllowEditing = false
        Me.vsfLotListCp.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotListCp.AutoSearchDelay = 2R
        Me.vsfLotListCp.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotListCp.ColumnInfo = resources.GetString("vsfLotListCp.ColumnInfo")
        Me.vsfLotListCp.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotListCp.ExtendLastCol = true
        Me.vsfLotListCp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotListCp.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotListCp.Location = New System.Drawing.Point(9, 114)
        Me.vsfLotListCp.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotListCp.Name = "vsfLotListCp"
        Me.vsfLotListCp.Rows.Count = 40
        Me.vsfLotListCp.Rows.DefaultSize = 18
        Me.vsfLotListCp.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotListCp.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotListCp.Size = New System.Drawing.Size(595, 382)
        Me.vsfLotListCp.StyleInfo = resources.GetString("vsfLotListCp.StyleInfo")
        Me.vsfLotListCp.TabIndex = 8
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(405, 27)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(121, 22)
        Me.lblNowDate.TabIndex = 20
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(405, 11)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle3.TabIndex = 19
        Me.lblTitle3.Text = "情報取得日時"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(530, 27)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(73, 22)
        Me.lblLotCnt.TabIndex = 18
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(530, 11)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle2.TabIndex = 17
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01X7
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(614, 546)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.fraSearch)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfLotListCp)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle2)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01X7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "コピー元　ロット工順選択"
        Me.fraSearch.ResumeLayout(false)
        Me.fraSearch.PerformLayout
        Me.fraKisyu.ResumeLayout(false)
        CType(Me.vsfLotListCp,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdNowList As Button
    Friend WithEvents fraSearch As Panel
    Friend WithEvents optSearch1 As RadioButton
    Friend WithEvents optSearch0 As RadioButton
    Friend WithEvents fraKisyu As Panel
    Friend WithEvents optFlowClass2 As RadioButton
    Friend WithEvents optFlowClass0 As RadioButton
    Friend WithEvents optFlowClass1 As RadioButton
    Friend WithEvents cmbFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbPD As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfLotListCp As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle2 As Label
End Class
