<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01K0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01K0))
        Me.chkSamplingFlag = New System.Windows.Forms.CheckBox()
        Me.cmdProhibit = New System.Windows.Forms.Button()
        Me.cmdCancelProhibit = New System.Windows.Forms.Button()
        Me.cmdLotDisp = New System.Windows.Forms.Button()
        Me.cmdWPHistory = New System.Windows.Forms.Button()
        Me.fraAfterVerUpEntry = New System.Windows.Forms.GroupBox()
        Me.cmdEDown = New System.Windows.Forms.Button()
        Me.cmdEUp = New System.Windows.Forms.Button()
        Me.txtEntrytComments = New SETextBoxEx.TextBoxEx()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTitle11 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTitle10 = New System.Windows.Forms.Label()
        Me.lblEntryName = New System.Windows.Forms.Label()
        Me.lblEntryID = New System.Windows.Forms.Label()
        Me.lblApplyTime = New System.Windows.Forms.Label()
        Me.cmdSUp = New System.Windows.Forms.Button()
        Me.cmdSDown = New System.Windows.Forms.Button()
        Me.fraSearch = New System.Windows.Forms.Panel()
        Me.cmbFlowClass = New SECmbIchiran.ComboIchiran()
        Me.fraKisyu = New System.Windows.Forms.Panel()
        Me.optFlowClass1 = New System.Windows.Forms.RadioButton()
        Me.optFlowClass0 = New System.Windows.Forms.RadioButton()
        Me.optSearch0 = New System.Windows.Forms.RadioButton()
        Me.optSearch1 = New System.Windows.Forms.RadioButton()
        Me.txtLotID = New SETextBoxEx.TextBoxEx()
        Me.cmbPD = New SECmbIchiran.ComboIchiran()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfSearchResult = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.chkNewVersion = New System.Windows.Forms.CheckBox()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblProhibit = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblGetInfoDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblListCnt = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.fraAfterVerUpEntry.SuspendLayout
        Me.fraSearch.SuspendLayout
        Me.fraKisyu.SuspendLayout
        CType(Me.vsfSearchResult,System.ComponentModel.ISupportInitialize).BeginInit
        Me.lblTitle3.SuspendLayout
        Me.SuspendLayout
        '
        'chkSamplingFlag
        '
        Me.chkSamplingFlag.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkSamplingFlag.Location = New System.Drawing.Point(268, 62)
        Me.chkSamplingFlag.Name = "chkSamplingFlag"
        Me.chkSamplingFlag.Size = New System.Drawing.Size(234, 19)
        Me.chkSamplingFlag.TabIndex = 15
        Me.chkSamplingFlag.Text = "サンプリング設定を無視する"
        '
        'cmdProhibit
        '
        Me.cmdProhibit.CausesValidation = false
        Me.cmdProhibit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdProhibit.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdProhibit.Location = New System.Drawing.Point(504, 598)
        Me.cmdProhibit.Name = "cmdProhibit"
        Me.cmdProhibit.Size = New System.Drawing.Size(85, 40)
        Me.cmdProhibit.TabIndex = 13
        Me.cmdProhibit.Text = "VerUp"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"禁止設定"
        '
        'cmdCancelProhibit
        '
        Me.cmdCancelProhibit.CausesValidation = false
        Me.cmdCancelProhibit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancelProhibit.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCancelProhibit.Location = New System.Drawing.Point(600, 598)
        Me.cmdCancelProhibit.Name = "cmdCancelProhibit"
        Me.cmdCancelProhibit.Size = New System.Drawing.Size(85, 40)
        Me.cmdCancelProhibit.TabIndex = 12
        Me.cmdCancelProhibit.Text = "VerUp"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"禁止解除"
        '
        'cmdLotDisp
        '
        Me.cmdLotDisp.CausesValidation = false
        Me.cmdLotDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotDisp.Location = New System.Drawing.Point(696, 598)
        Me.cmdLotDisp.Name = "cmdLotDisp"
        Me.cmdLotDisp.Size = New System.Drawing.Size(85, 40)
        Me.cmdLotDisp.TabIndex = 11
        Me.cmdLotDisp.Text = "ﾛｯﾄ情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"詳細表示"
        '
        'cmdWPHistory
        '
        Me.cmdWPHistory.CausesValidation = false
        Me.cmdWPHistory.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWPHistory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWPHistory.Location = New System.Drawing.Point(792, 598)
        Me.cmdWPHistory.Name = "cmdWPHistory"
        Me.cmdWPHistory.Size = New System.Drawing.Size(85, 40)
        Me.cmdWPHistory.TabIndex = 10
        Me.cmdWPHistory.Text = "変更履歴"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認"
        '
        'fraAfterVerUpEntry
        '
        Me.fraAfterVerUpEntry.Controls.Add(Me.cmdEDown)
        Me.fraAfterVerUpEntry.Controls.Add(Me.cmdEUp)
        Me.fraAfterVerUpEntry.Controls.Add(Me.txtEntrytComments)
        Me.fraAfterVerUpEntry.Controls.Add(Me.lblTtl15)
        Me.fraAfterVerUpEntry.Controls.Add(Me.lblTitle11)
        Me.fraAfterVerUpEntry.Controls.Add(Me.lblTitle7)
        Me.fraAfterVerUpEntry.Controls.Add(Me.lblTitle10)
        Me.fraAfterVerUpEntry.Controls.Add(Me.lblEntryName)
        Me.fraAfterVerUpEntry.Controls.Add(Me.lblEntryID)
        Me.fraAfterVerUpEntry.Controls.Add(Me.lblApplyTime)
        Me.fraAfterVerUpEntry.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraAfterVerUpEntry.Location = New System.Drawing.Point(6, 488)
        Me.fraAfterVerUpEntry.Name = "fraAfterVerUpEntry"
        Me.fraAfterVerUpEntry.Size = New System.Drawing.Size(966, 107)
        Me.fraAfterVerUpEntry.TabIndex = 19
        Me.fraAfterVerUpEntry.TabStop = false
        Me.fraAfterVerUpEntry.Text = "バージョンアップ後 エントリ"
        '
        'cmdEDown
        '
        Me.cmdEDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdEDown.Location = New System.Drawing.Point(927, 63)
        Me.cmdEDown.Name = "cmdEDown"
        Me.cmdEDown.Size = New System.Drawing.Size(25, 38)
        Me.cmdEDown.TabIndex = 20
        Me.cmdEDown.Text = "▼"
        '
        'cmdEUp
        '
        Me.cmdEUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdEUp.Location = New System.Drawing.Point(927, 25)
        Me.cmdEUp.Name = "cmdEUp"
        Me.cmdEUp.Size = New System.Drawing.Size(25, 38)
        Me.cmdEUp.TabIndex = 19
        Me.cmdEUp.Text = "▲"
        '
        'txtEntrytComments
        '
        Me.txtEntrytComments.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtEntrytComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntrytComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtEntrytComments.ChrMaxByte = 0
        Me.txtEntrytComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtEntrytComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtEntrytComments.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtEntrytComments.GotHighLight = false
        Me.txtEntrytComments.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtEntrytComments.Location = New System.Drawing.Point(286, 42)
        Me.txtEntrytComments.MultiLineEx = true
        Me.txtEntrytComments.Name = "txtEntrytComments"
        Me.txtEntrytComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtEntrytComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEntrytComments.SelectedText = ""
        Me.txtEntrytComments.Size = New System.Drawing.Size(641, 58)
        Me.txtEntrytComments.TabIndex = 39
        Me.txtEntrytComments.TabStop = false
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(286, 26)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(641, 17)
        Me.lblTtl15.TabIndex = 40
        Me.lblTtl15.Text = "コメント"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle11
        '
        Me.lblTitle11.BackColor = System.Drawing.Color.Navy
        Me.lblTitle11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle11.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle11.Location = New System.Drawing.Point(8, 26)
        Me.lblTitle11.Name = "lblTitle11"
        Me.lblTitle11.Size = New System.Drawing.Size(137, 17)
        Me.lblTitle11.TabIndex = 38
        Me.lblTitle11.Text = "エントリ"
        Me.lblTitle11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(8, 62)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(279, 17)
        Me.lblTitle7.TabIndex = 37
        Me.lblTitle7.Text = "エントリ名"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle10
        '
        Me.lblTitle10.BackColor = System.Drawing.Color.Navy
        Me.lblTitle10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle10.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle10.Location = New System.Drawing.Point(144, 26)
        Me.lblTitle10.Name = "lblTitle10"
        Me.lblTitle10.Size = New System.Drawing.Size(143, 17)
        Me.lblTitle10.TabIndex = 36
        Me.lblTitle10.Text = "適用日時"
        Me.lblTitle10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEntryName
        '
        Me.lblEntryName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEntryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEntryName.Location = New System.Drawing.Point(8, 78)
        Me.lblEntryName.Name = "lblEntryName"
        Me.lblEntryName.Size = New System.Drawing.Size(279, 22)
        Me.lblEntryName.TabIndex = 35
        '
        'lblEntryID
        '
        Me.lblEntryID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEntryID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEntryID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblEntryID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEntryID.Location = New System.Drawing.Point(8, 42)
        Me.lblEntryID.Name = "lblEntryID"
        Me.lblEntryID.Size = New System.Drawing.Size(137, 22)
        Me.lblEntryID.TabIndex = 34
        '
        'lblApplyTime
        '
        Me.lblApplyTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblApplyTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApplyTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblApplyTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblApplyTime.Location = New System.Drawing.Point(144, 42)
        Me.lblApplyTime.Name = "lblApplyTime"
        Me.lblApplyTime.Size = New System.Drawing.Size(143, 22)
        Me.lblApplyTime.TabIndex = 33
        '
        'cmdSUp
        '
        Me.cmdSUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSUp.Location = New System.Drawing.Point(946, 405)
        Me.cmdSUp.Name = "cmdSUp"
        Me.cmdSUp.Size = New System.Drawing.Size(26, 38)
        Me.cmdSUp.TabIndex = 17
        Me.cmdSUp.Text = "▲"
        '
        'cmdSDown
        '
        Me.cmdSDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSDown.Location = New System.Drawing.Point(946, 443)
        Me.cmdSDown.Name = "cmdSDown"
        Me.cmdSDown.Size = New System.Drawing.Size(26, 38)
        Me.cmdSDown.TabIndex = 18
        Me.cmdSDown.Text = "▼"
        '
        'fraSearch
        '
        Me.fraSearch.Controls.Add(Me.cmbFlowClass)
        Me.fraSearch.Controls.Add(Me.fraKisyu)
        Me.fraSearch.Controls.Add(Me.optSearch0)
        Me.fraSearch.Controls.Add(Me.optSearch1)
        Me.fraSearch.Controls.Add(Me.txtLotID)
        Me.fraSearch.Controls.Add(Me.cmbPD)
        Me.fraSearch.Controls.Add(Me.lblTitle0)
        Me.fraSearch.Controls.Add(Me.lblTitle1)
        Me.fraSearch.Controls.Add(Me.lblTitle8)
        Me.fraSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.fraSearch.Location = New System.Drawing.Point(8, 0)
        Me.fraSearch.Name = "fraSearch"
        Me.fraSearch.Size = New System.Drawing.Size(619, 54)
        Me.fraSearch.TabIndex = 0
        '
        'cmbFlowClass
        '
        Me.cmbFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbFlowClass.Location = New System.Drawing.Point(154, 21)
        Me.cmbFlowClass.Name = "cmbFlowClass"
        Me.cmbFlowClass.Size = New System.Drawing.Size(126, 22)
        Me.cmbFlowClass.TabIndex = 3
        Me.cmbFlowClass.Value = Nothing
        '
        'fraKisyu
        '
        Me.fraKisyu.Controls.Add(Me.optFlowClass1)
        Me.fraKisyu.Controls.Add(Me.optFlowClass0)
        Me.fraKisyu.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraKisyu.Location = New System.Drawing.Point(296, 0)
        Me.fraKisyu.Name = "fraKisyu"
        Me.fraKisyu.Size = New System.Drawing.Size(82, 57)
        Me.fraKisyu.TabIndex = 4
        '
        'optFlowClass1
        '
        Me.optFlowClass1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optFlowClass1.Location = New System.Drawing.Point(8, 29)
        Me.optFlowClass1.Name = "optFlowClass1"
        Me.optFlowClass1.Size = New System.Drawing.Size(73, 18)
        Me.optFlowClass1.TabIndex = 5
        Me.optFlowClass1.Text = "流動中"
        '
        'optFlowClass0
        '
        Me.optFlowClass0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optFlowClass0.Location = New System.Drawing.Point(8, 5)
        Me.optFlowClass0.Name = "optFlowClass0"
        Me.optFlowClass0.Size = New System.Drawing.Size(73, 18)
        Me.optFlowClass0.TabIndex = 4
        Me.optFlowClass0.Text = "流動前"
        '
        'optSearch0
        '
        Me.optSearch0.Location = New System.Drawing.Point(1, 13)
        Me.optSearch0.Name = "optSearch0"
        Me.optSearch0.Size = New System.Drawing.Size(17, 25)
        Me.optSearch0.TabIndex = 0
        '
        'optSearch1
        '
        Me.optSearch1.Checked = true
        Me.optSearch1.Location = New System.Drawing.Point(416, 14)
        Me.optSearch1.Name = "optSearch1"
        Me.optSearch1.Size = New System.Drawing.Size(17, 25)
        Me.optSearch1.TabIndex = 1
        Me.optSearch1.TabStop = true
        '
        'txtLotID
        '
        Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLotID.ChrMaxByte = 10
        Me.txtLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Hankaku
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtLotID.Location = New System.Drawing.Point(440, 22)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotID.SelectedText = ""
        Me.txtLotID.Size = New System.Drawing.Size(153, 22)
        Me.txtLotID.TabIndex = 6
        '
        'cmbPD
        '
        Me.cmbPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPD.GridForeColor = System.Drawing.Color.Black
        Me.cmbPD.Location = New System.Drawing.Point(25, 21)
        Me.cmbPD.Name = "cmbPD"
        Me.cmbPD.Size = New System.Drawing.Size(126, 22)
        Me.cmbPD.TabIndex = 2
        Me.cmbPD.Value = Nothing
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(25, 6)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(126, 17)
        Me.lblTitle0.TabIndex = 30
        Me.lblTitle0.Text = "機種"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(154, 6)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(126, 17)
        Me.lblTitle1.TabIndex = 29
        Me.lblTitle1.Text = "種別"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(440, 6)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(153, 17)
        Me.lblTitle8.TabIndex = 27
        Me.lblTitle8.Text = "ロットID(前方一致)"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 598)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 9
        Me.cmdRegist.Text = "確　定"
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(633, 5)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSearch.TabIndex = 7
        Me.cmdSearch.Text = "最新取得"
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
        Me.cmdClose.TabIndex = 21
        Me.cmdClose.Text = "閉じる"
        '
        'vsfSearchResult
        '
        Me.vsfSearchResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfSearchResult.AllowEditing = false
        Me.vsfSearchResult.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfSearchResult.AutoSearchDelay = 2R
        Me.vsfSearchResult.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfSearchResult.ColumnInfo = resources.GetString("vsfSearchResult.ColumnInfo")
        Me.vsfSearchResult.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfSearchResult.ExtendLastCol = true
        Me.vsfSearchResult.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfSearchResult.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfSearchResult.Location = New System.Drawing.Point(6, 89)
        Me.vsfSearchResult.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfSearchResult.Name = "vsfSearchResult"
        Me.vsfSearchResult.Rows.Count = 2
        Me.vsfSearchResult.Rows.DefaultSize = 18
        Me.vsfSearchResult.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfSearchResult.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.vsfSearchResult.Size = New System.Drawing.Size(965, 309)
        Me.vsfSearchResult.StyleInfo = resources.GetString("vsfSearchResult.StyleInfo")
        Me.vsfSearchResult.TabIndex = 8
        '
        'txtComments
        '
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 2048
        Me.txtComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtComments.GotHighLight = false
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtComments.Location = New System.Drawing.Point(6, 422)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NgChr = "'"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(940, 58)
        Me.txtComments.TabIndex = 16
        '
        'chkNewVersion
        '
        Me.chkNewVersion.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.chkNewVersion.Location = New System.Drawing.Point(34, 62)
        Me.chkNewVersion.Name = "chkNewVersion"
        Me.chkNewVersion.Size = New System.Drawing.Size(234, 19)
        Me.chkNewVersion.TabIndex = 14
        Me.chkNewVersion.Text = "最新バージョンを表示しない"
        '
        'lblTitleChip
        '
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(611, 64)
        Me.lblTitleChip.Name = "lblTitleChip"
        Me.lblTitleChip.Size = New System.Drawing.Size(109, 19)
        Me.lblTitleChip.TabIndex = 47
        Me.lblTitleChip.Text = "青字：Chip品"
        Me.lblTitleChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleChip.UseMnemonic = false
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(803, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 19)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "VerUp不可"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblProhibit
        '
        Me.lblProhibit.BackColor = System.Drawing.Color.Red
        Me.lblProhibit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProhibit.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProhibit.ForeColor = System.Drawing.Color.Black
        Me.lblProhibit.Location = New System.Drawing.Point(719, 64)
        Me.lblProhibit.Name = "lblProhibit"
        Me.lblProhibit.Size = New System.Drawing.Size(85, 19)
        Me.lblProhibit.TabIndex = 45
        Me.lblProhibit.Text = "VerUp禁止"
        Me.lblProhibit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(887, 64)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(85, 19)
        Me.lblTitleHT.TabIndex = 44
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(578, 64)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(34, 19)
        Me.lblTitleR.TabIndex = 43
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
        Me.lblTitleL.Location = New System.Drawing.Point(545, 64)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(34, 19)
        Me.lblTitleL.TabIndex = 42
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(678, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(247, 17)
        Me.lblLengthCount.TabIndex = 41
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblGetInfoDate
        '
        Me.lblGetInfoDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGetInfoDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGetInfoDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGetInfoDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGetInfoDate.Location = New System.Drawing.Point(772, 21)
        Me.lblGetInfoDate.Name = "lblGetInfoDate"
        Me.lblGetInfoDate.Size = New System.Drawing.Size(121, 22)
        Me.lblGetInfoDate.TabIndex = 25
        Me.lblGetInfoDate.Text = "07/15 13:11:25"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(772, 5)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle4.TabIndex = 24
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblListCnt
        '
        Me.lblListCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblListCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblListCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblListCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblListCnt.Location = New System.Drawing.Point(899, 21)
        Me.lblListCnt.Name = "lblListCnt"
        Me.lblListCnt.Size = New System.Drawing.Size(73, 22)
        Me.lblListCnt.TabIndex = 23
        Me.lblListCnt.Text = "0"
        Me.lblListCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(899, 5)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle2.TabIndex = 22
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Controls.Add(Me.lblLengthCount)
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(6, 406)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(940, 17)
        Me.lblTitle3.TabIndex = 31
        Me.lblTitle3.Text = "作業メモ"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01K0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.chkSamplingFlag)
        Me.Controls.Add(Me.cmdProhibit)
        Me.Controls.Add(Me.cmdCancelProhibit)
        Me.Controls.Add(Me.cmdLotDisp)
        Me.Controls.Add(Me.cmdWPHistory)
        Me.Controls.Add(Me.fraAfterVerUpEntry)
        Me.Controls.Add(Me.cmdSUp)
        Me.Controls.Add(Me.cmdSDown)
        Me.Controls.Add(Me.fraSearch)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfSearchResult)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.chkNewVersion)
        Me.Controls.Add(Me.lblTitleChip)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblProhibit)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Controls.Add(Me.lblTitleR)
        Me.Controls.Add(Me.lblTitleL)
        Me.Controls.Add(Me.lblGetInfoDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblListCnt)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTitle3)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01K0"
        Me.Text = "流動票バージョンアップ"
        Me.fraAfterVerUpEntry.ResumeLayout(false)
        Me.fraSearch.ResumeLayout(false)
        Me.fraKisyu.ResumeLayout(false)
        CType(Me.vsfSearchResult,System.ComponentModel.ISupportInitialize).EndInit
        Me.lblTitle3.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents chkSamplingFlag As CheckBox
    Friend WithEvents cmdProhibit As Button
    Friend WithEvents cmdCancelProhibit As Button
    Friend WithEvents cmdLotDisp As Button
    Friend WithEvents cmdWPHistory As Button
    Friend WithEvents fraAfterVerUpEntry As GroupBox
    Friend WithEvents cmdEDown As Button
    Friend WithEvents cmdEUp As Button
    Friend WithEvents txtEntrytComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTitle11 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle10 As Label
    Friend WithEvents lblEntryName As Label
    Friend WithEvents lblEntryID As Label
    Friend WithEvents lblApplyTime As Label
    Friend WithEvents cmdSUp As Button
    Friend WithEvents cmdSDown As Button
    Friend WithEvents fraSearch As Panel
    Friend WithEvents cmbFlowClass As SECmbIchiran.ComboIchiran
    Friend WithEvents fraKisyu As Panel
    Friend WithEvents optFlowClass1 As RadioButton
    Friend WithEvents optFlowClass0 As RadioButton
    Friend WithEvents optSearch0 As RadioButton
    Friend WithEvents optSearch1 As RadioButton
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbPD As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdSearch As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfSearchResult As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents chkNewVersion As CheckBox
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblProhibit As Label
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblGetInfoDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblListCnt As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle3 As Label
End Class
