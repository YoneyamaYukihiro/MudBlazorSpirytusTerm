<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01Z0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01Z0))
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdCopyInsert = New System.Windows.Forms.Button()
        Me.optSelectMode2 = New System.Windows.Forms.RadioButton()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.optSelectMode1 = New System.Windows.Forms.RadioButton()
        Me.optSelectMode0 = New System.Windows.Forms.RadioButton()
        Me.cmdNewEntry = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdMailSend = New System.Windows.Forms.Button()
        Me.cmdDiscon = New System.Windows.Forms.Button()
        Me.vsfMainteList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdApprove = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtInformation = New SETextBoxEx.TextBoxEx()
        Me.calStart = New SECalendarEx.CalendarEx()
        Me.calEnd = New SECalendarEx.CalendarEx()
        Me.cmbMcGroup = New SECmbIchiran.ComboIchiran()
        Me.cmbWP = New SECmbIchiran.ComboIchiran()
        Me.cmbCategory = New SECmbIchiran.ComboIchiran()
        Me.lblFromTitle = New System.Windows.Forms.Label()
        Me.lblWaveTitle = New System.Windows.Forms.Label()
        Me.lblToTitle = New System.Windows.Forms.Label()
        Me.lblMcGroupTitle = New System.Windows.Forms.Label()
        Me.lblWPTitle = New System.Windows.Forms.Label()
        Me.lblSelectMode = New System.Windows.Forms.Label()
        Me.lblDisabled = New System.Windows.Forms.Label()
        Me.lblCategoryTitle = New System.Windows.Forms.Label()
        Me.lblInformationTitle = New System.Windows.Forms.Label()
        Me.lblDataCntTitle = New System.Windows.Forms.Label()
        Me.lblDataCnt = New System.Windows.Forms.Label()
        Me.lblNowDateTitle = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        CType(Me.vsfMainteList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdDown
        '
        Me.cmdDown.Enabled = false
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Location = New System.Drawing.Point(948, 557)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(25, 36)
        Me.cmdDown.TabIndex = 12
        Me.cmdDown.Text = "▼"
        '
        'cmdUp
        '
        Me.cmdUp.Enabled = false
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Location = New System.Drawing.Point(948, 521)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(25, 36)
        Me.cmdUp.TabIndex = 11
        Me.cmdUp.Text = "▲"
        '
        'cmdCopyInsert
        '
        Me.cmdCopyInsert.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopyInsert.Location = New System.Drawing.Point(504, 597)
        Me.cmdCopyInsert.Name = "cmdCopyInsert"
        Me.cmdCopyInsert.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopyInsert.TabIndex = 17
        Me.cmdCopyInsert.Text = "ｺﾋﾟｰ登録"
        '
        'optSelectMode2
        '
        Me.optSelectMode2.Location = New System.Drawing.Point(390, 9)
        Me.optSelectMode2.Name = "optSelectMode2"
        Me.optSelectMode2.Size = New System.Drawing.Size(112, 24)
        Me.optSelectMode2.TabIndex = 2
        Me.optSelectMode2.Text = "保全記録"
        '
        'cmdSearch
        '
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Location = New System.Drawing.Point(528, 87)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSearch.TabIndex = 8
        Me.cmdSearch.Text = "検　索"
        '
        'optSelectMode1
        '
        Me.optSelectMode1.Location = New System.Drawing.Point(240, 9)
        Me.optSelectMode1.Name = "optSelectMode1"
        Me.optSelectMode1.Size = New System.Drawing.Size(132, 24)
        Me.optSelectMode1.TabIndex = 1
        Me.optSelectMode1.Text = "故障修理記録"
        '
        'optSelectMode0
        '
        Me.optSelectMode0.Location = New System.Drawing.Point(22, 9)
        Me.optSelectMode0.Name = "optSelectMode0"
        Me.optSelectMode0.Size = New System.Drawing.Size(189, 24)
        Me.optSelectMode0.TabIndex = 0
        Me.optSelectMode0.Text = "装置停止・メンテ計画"
        '
        'cmdNewEntry
        '
        Me.cmdNewEntry.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNewEntry.Location = New System.Drawing.Point(408, 597)
        Me.cmdNewEntry.Name = "cmdNewEntry"
        Me.cmdNewEntry.Size = New System.Drawing.Size(85, 40)
        Me.cmdNewEntry.TabIndex = 18
        Me.cmdNewEntry.Text = "新規登録"
        '
        'cmdCopy
        '
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Location = New System.Drawing.Point(200, 597)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopy.TabIndex = 19
        Me.cmdCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'cmdMailSend
        '
        Me.cmdMailSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMailSend.Location = New System.Drawing.Point(600, 597)
        Me.cmdMailSend.Name = "cmdMailSend"
        Me.cmdMailSend.Size = New System.Drawing.Size(85, 40)
        Me.cmdMailSend.TabIndex = 16
        Me.cmdMailSend.Text = "確認依頼"
        '
        'cmdDiscon
        '
        Me.cmdDiscon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDiscon.Location = New System.Drawing.Point(696, 597)
        Me.cmdDiscon.Name = "cmdDiscon"
        Me.cmdDiscon.Size = New System.Drawing.Size(85, 40)
        Me.cmdDiscon.TabIndex = 15
        Me.cmdDiscon.Text = "破　棄"
        '
        'vsfMainteList
        '
        Me.vsfMainteList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMainteList.AllowEditing = false
        Me.vsfMainteList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMainteList.AutoResize = true
        Me.vsfMainteList.AutoSearchDelay = 2R
        Me.vsfMainteList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMainteList.ColumnInfo = resources.GetString("vsfMainteList.ColumnInfo")
        Me.vsfMainteList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMainteList.ExtendLastCol = true
        Me.vsfMainteList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMainteList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMainteList.Location = New System.Drawing.Point(8, 134)
        Me.vsfMainteList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMainteList.Name = "vsfMainteList"
        Me.vsfMainteList.Rows.DefaultSize = 18
        Me.vsfMainteList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMainteList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMainteList.Size = New System.Drawing.Size(965, 379)
        Me.vsfMainteList.StyleInfo = resources.GetString("vsfMainteList.StyleInfo")
        Me.vsfMainteList.TabIndex = 9
        '
        'cmdApprove
        '
        Me.cmdApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdApprove.Location = New System.Drawing.Point(792, 597)
        Me.cmdApprove.Name = "cmdApprove"
        Me.cmdApprove.Size = New System.Drawing.Size(85, 40)
        Me.cmdApprove.TabIndex = 14
        Me.cmdApprove.Text = "承　認"
        '
        'cmdEdit
        '
        Me.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEdit.Location = New System.Drawing.Point(888, 597)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(85, 40)
        Me.cmdEdit.TabIndex = 13
        Me.cmdEdit.Text = "編　集"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 20
        Me.cmdClose.Text = "閉じる"
        '
        'txtInformation
        '
        Me.txtInformation.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtInformation.ChrMaxByte = 0
        Me.txtInformation.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtInformation.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtInformation.GotHighLight = false
        Me.txtInformation.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtInformation.Location = New System.Drawing.Point(8, 538)
        Me.txtInformation.MultiLineEx = true
        Me.txtInformation.Name = "txtInformation"
        Me.txtInformation.NgChr = "'"
        Me.txtInformation.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtInformation.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtInformation.SelectedText = ""
        Me.txtInformation.Size = New System.Drawing.Size(940, 54)
        Me.txtInformation.TabIndex = 10
        Me.txtInformation.TabStop = false
        '
        'calStart
        '
        Me.calStart.DateCheckStatus = 0
        Me.calStart.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStart.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStart.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStart.IsDate = true
        Me.calStart.Location = New System.Drawing.Point(244, 104)
        Me.calStart.Name = "calStart"
        Me.calStart.Size = New System.Drawing.Size(120, 22)
        Me.calStart.TabIndex = 6
        Me.calStart.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calStart.Value = "____/__/__"
        '
        'calEnd
        '
        Me.calEnd.DateCheckStatus = 0
        Me.calEnd.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEnd.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEnd.IsDate = true
        Me.calEnd.Location = New System.Drawing.Point(400, 104)
        Me.calEnd.Name = "calEnd"
        Me.calEnd.Size = New System.Drawing.Size(120, 22)
        Me.calEnd.TabIndex = 7
        Me.calEnd.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calEnd.Value = "____/__/__"
        '
        'cmbMcGroup
        '
        Me.cmbMcGroup.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroup.Location = New System.Drawing.Point(8, 59)
        Me.cmbMcGroup.Name = "cmbMcGroup"
        Me.cmbMcGroup.Size = New System.Drawing.Size(383, 22)
        Me.cmbMcGroup.TabIndex = 3
        Me.cmbMcGroup.Value = Nothing
        '
        'cmbWP
        '
        Me.cmbWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWP.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWP.Location = New System.Drawing.Point(400, 59)
        Me.cmbWP.Name = "cmbWP"
        Me.cmbWP.Size = New System.Drawing.Size(358, 22)
        Me.cmbWP.TabIndex = 4
        Me.cmbWP.Value = Nothing
        '
        'cmbCategory
        '
        Me.cmbCategory.DirectInput = false
        Me.cmbCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCategory.Location = New System.Drawing.Point(8, 104)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(211, 22)
        Me.cmbCategory.TabIndex = 5
        Me.cmbCategory.Value = Nothing
        Me.cmbCategory.ValueCol = 1
        '
        'lblFromTitle
        '
        Me.lblFromTitle.BackColor = System.Drawing.Color.Navy
        Me.lblFromTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFromTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblFromTitle.Location = New System.Drawing.Point(244, 88)
        Me.lblFromTitle.Name = "lblFromTitle"
        Me.lblFromTitle.Size = New System.Drawing.Size(120, 17)
        Me.lblFromTitle.TabIndex = 29
        Me.lblFromTitle.Text = "検索開始日"
        Me.lblFromTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWaveTitle
        '
        Me.lblWaveTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWaveTitle.Location = New System.Drawing.Point(370, 104)
        Me.lblWaveTitle.Name = "lblWaveTitle"
        Me.lblWaveTitle.Size = New System.Drawing.Size(23, 19)
        Me.lblWaveTitle.TabIndex = 30
        Me.lblWaveTitle.Text = "～"
        Me.lblWaveTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblToTitle
        '
        Me.lblToTitle.BackColor = System.Drawing.Color.Navy
        Me.lblToTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblToTitle.Location = New System.Drawing.Point(400, 88)
        Me.lblToTitle.Name = "lblToTitle"
        Me.lblToTitle.Size = New System.Drawing.Size(120, 17)
        Me.lblToTitle.TabIndex = 31
        Me.lblToTitle.Text = "検索終了日"
        Me.lblToTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMcGroupTitle
        '
        Me.lblMcGroupTitle.BackColor = System.Drawing.Color.Navy
        Me.lblMcGroupTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMcGroupTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblMcGroupTitle.Location = New System.Drawing.Point(8, 43)
        Me.lblMcGroupTitle.Name = "lblMcGroupTitle"
        Me.lblMcGroupTitle.Size = New System.Drawing.Size(383, 17)
        Me.lblMcGroupTitle.TabIndex = 22
        Me.lblMcGroupTitle.Text = "装置グループ"
        Me.lblMcGroupTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWPTitle
        '
        Me.lblWPTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWPTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWPTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWPTitle.Location = New System.Drawing.Point(400, 43)
        Me.lblWPTitle.Name = "lblWPTitle"
        Me.lblWPTitle.Size = New System.Drawing.Size(358, 17)
        Me.lblWPTitle.TabIndex = 23
        Me.lblWPTitle.Text = "装置名"
        Me.lblWPTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSelectMode
        '
        Me.lblSelectMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSelectMode.Location = New System.Drawing.Point(8, 6)
        Me.lblSelectMode.Name = "lblSelectMode"
        Me.lblSelectMode.Size = New System.Drawing.Size(511, 29)
        Me.lblSelectMode.TabIndex = 0
        '
        'lblDisabled
        '
        Me.lblDisabled.AutoSize = true
        Me.lblDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblDisabled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisabled.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDisabled.ForeColor = System.Drawing.Color.Black
        Me.lblDisabled.Location = New System.Drawing.Point(746, 88)
        Me.lblDisabled.Name = "lblDisabled"
        Me.lblDisabled.Size = New System.Drawing.Size(234, 34)
        Me.lblDisabled.TabIndex = 32
        Me.lblDisabled.Text = "起票から24時間経過し、"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"「未処置」状態のままの処理票"
        '
        'lblCategoryTitle
        '
        Me.lblCategoryTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCategoryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCategoryTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCategoryTitle.Location = New System.Drawing.Point(8, 88)
        Me.lblCategoryTitle.Name = "lblCategoryTitle"
        Me.lblCategoryTitle.Size = New System.Drawing.Size(211, 17)
        Me.lblCategoryTitle.TabIndex = 28
        Me.lblCategoryTitle.Text = "カテゴリ"
        Me.lblCategoryTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblInformationTitle
        '
        Me.lblInformationTitle.BackColor = System.Drawing.Color.Navy
        Me.lblInformationTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInformationTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblInformationTitle.Location = New System.Drawing.Point(8, 522)
        Me.lblInformationTitle.Name = "lblInformationTitle"
        Me.lblInformationTitle.Size = New System.Drawing.Size(940, 17)
        Me.lblInformationTitle.TabIndex = 33
        Me.lblInformationTitle.Text = "停止コメント"
        Me.lblInformationTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDataCntTitle
        '
        Me.lblDataCntTitle.BackColor = System.Drawing.Color.Navy
        Me.lblDataCntTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataCntTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblDataCntTitle.Location = New System.Drawing.Point(902, 43)
        Me.lblDataCntTitle.Name = "lblDataCntTitle"
        Me.lblDataCntTitle.Size = New System.Drawing.Size(73, 17)
        Me.lblDataCntTitle.TabIndex = 25
        Me.lblDataCntTitle.Text = "該当件数"
        Me.lblDataCntTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDataCnt
        '
        Me.lblDataCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDataCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDataCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDataCnt.Location = New System.Drawing.Point(902, 59)
        Me.lblDataCnt.Name = "lblDataCnt"
        Me.lblDataCnt.Size = New System.Drawing.Size(73, 22)
        Me.lblDataCnt.TabIndex = 27
        Me.lblDataCnt.Text = "0"
        Me.lblDataCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowDateTitle
        '
        Me.lblNowDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNowDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNowDateTitle.Location = New System.Drawing.Point(769, 43)
        Me.lblNowDateTitle.Name = "lblNowDateTitle"
        Me.lblNowDateTitle.Size = New System.Drawing.Size(122, 17)
        Me.lblNowDateTitle.TabIndex = 24
        Me.lblNowDateTitle.Text = "情報取得日時"
        Me.lblNowDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(769, 59)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
        Me.lblNowDate.TabIndex = 26
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'frmxxEN01Z0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblDataCntTitle)
        Me.Controls.Add(Me.lblNowDateTitle)
        Me.Controls.Add(Me.lblWPTitle)
        Me.Controls.Add(Me.lblMcGroupTitle)
        Me.Controls.Add(Me.lblCategoryTitle)
        Me.Controls.Add(Me.lblFromTitle)
        Me.Controls.Add(Me.lblToTitle)
        Me.Controls.Add(Me.lblInformationTitle)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.cmdCopyInsert)
        Me.Controls.Add(Me.optSelectMode2)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.optSelectMode1)
        Me.Controls.Add(Me.optSelectMode0)
        Me.Controls.Add(Me.cmdNewEntry)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdMailSend)
        Me.Controls.Add(Me.cmdDiscon)
        Me.Controls.Add(Me.vsfMainteList)
        Me.Controls.Add(Me.cmdApprove)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtInformation)
        Me.Controls.Add(Me.calStart)
        Me.Controls.Add(Me.calEnd)
        Me.Controls.Add(Me.cmbMcGroup)
        Me.Controls.Add(Me.cmbWP)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.lblWaveTitle)
        Me.Controls.Add(Me.lblSelectMode)
        Me.Controls.Add(Me.lblDisabled)
        Me.Controls.Add(Me.lblDataCnt)
        Me.Controls.Add(Me.lblNowDate)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01Z0"
        Me.Text = "装置メンテナンス記録票一覧"
        CType(Me.vsfMainteList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdCopyInsert As Button
    Friend WithEvents optSelectMode2 As RadioButton
    Friend WithEvents cmdSearch As Button
    Friend WithEvents optSelectMode1 As RadioButton
    Friend WithEvents optSelectMode0 As RadioButton
    Friend WithEvents cmdNewEntry As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdMailSend As Button
    Friend WithEvents cmdDiscon As Button
    Friend WithEvents vsfMainteList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdApprove As Button
    Friend WithEvents cmdEdit As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtInformation As SETextBoxEx.TextBoxEx
    Friend WithEvents calStart As SECalendarEx.CalendarEx
    Friend WithEvents calEnd As SECalendarEx.CalendarEx
    Friend WithEvents cmbMcGroup As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbWP As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbCategory As SECmbIchiran.ComboIchiran
    Friend WithEvents lblFromTitle As Label
    Friend WithEvents lblWaveTitle As Label
    Friend WithEvents lblToTitle As Label
    Friend WithEvents lblMcGroupTitle As Label
    Friend WithEvents lblWPTitle As Label
    Friend WithEvents lblSelectMode As Label
    Friend WithEvents lblDisabled As Label
    Friend WithEvents lblCategoryTitle As Label
    Friend WithEvents lblInformationTitle As Label
    Friend WithEvents lblDataCntTitle As Label
    Friend WithEvents lblDataCnt As Label
    Friend WithEvents lblNowDateTitle As Label
    Friend WithEvents lblNowDate As Label
End Class
