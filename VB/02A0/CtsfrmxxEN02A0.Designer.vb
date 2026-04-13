<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02A0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02A0))
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdLotComment = New System.Windows.Forms.Button()
        Me.cmdWorkMemoChk = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfEventHistoryList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbRollBackOpID = New SEComboBoxEx.ComboBoxEx()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.cmbRollBackStepID = New SEComboBoxEx.ComboBoxEx()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblWorkMemoTitle = New System.Windows.Forms.Label()
        Me.lblRollBackStepIDTitle = New System.Windows.Forms.Label()
        Me.lblLotIDTitle = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblCarrierTitle = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblLotStatus = New System.Windows.Forms.Label()
        Me.lblLotStatusTitle = New System.Windows.Forms.Label()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.lblLimitTimeTitle = New System.Windows.Forms.Label()
        Me.lblLimitTime = New System.Windows.Forms.Label()
        Me.lblLotManagerTitle = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblPdIDTitle = New System.Windows.Forms.Label()
        Me.lblNumTitle = New System.Windows.Forms.Label()
        Me.lblSpecialFlag = New System.Windows.Forms.Label()
        Me.lblProcStartTime = New System.Windows.Forms.Label()
        Me.lblProcStartTimeTitle = New System.Windows.Forms.Label()
        Me.lblSpecialFlagTitle = New System.Windows.Forms.Label()
        Me.lblOpIDTitle = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblStepIDTitle = New System.Windows.Forms.Label()
        Me.lblHeaderInfo = New System.Windows.Forms.Label()
        Me.lblRollBackOpIDTitle1 = New System.Windows.Forms.Label()
        Me.lblGRBTitle = New System.Windows.Forms.Label()
        Me.lblGRB = New System.Windows.Forms.Label()
        CType(Me.vsfEventHistoryList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(924, 119)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 54)
        Me.cmdMemoUp.TabIndex = 4
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(924, 174)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 54)
        Me.cmdMemoDown.TabIndex = 5
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 579)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 7
        Me.cmdRegist.Text = "確　定"
        '
        'cmdLotComment
        '
        Me.cmdLotComment.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotComment.Location = New System.Drawing.Point(224, 579)
        Me.cmdLotComment.Name = "cmdLotComment"
        Me.cmdLotComment.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotComment.TabIndex = 9
        Me.cmdLotComment.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdWorkMemoChk
        '
        Me.cmdWorkMemoChk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkMemoChk.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWorkMemoChk.Location = New System.Drawing.Point(332, 579)
        Me.cmdWorkMemoChk.Name = "cmdWorkMemoChk"
        Me.cmdWorkMemoChk.Size = New System.Drawing.Size(105, 57)
        Me.cmdWorkMemoChk.TabIndex = 8
        Me.cmdWorkMemoChk.Text = "作業メモ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 579)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 10
        Me.cmdClose.Text = "閉じる"
        '
        'vsfEventHistoryList
        '
        Me.vsfEventHistoryList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfEventHistoryList.AllowEditing = false
        Me.vsfEventHistoryList.AutoSearchDelay = 2R
        Me.vsfEventHistoryList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfEventHistoryList.ColumnInfo = resources.GetString("vsfEventHistoryList.ColumnInfo")
        Me.vsfEventHistoryList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfEventHistoryList.ExtendLastCol = true
        Me.vsfEventHistoryList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfEventHistoryList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfEventHistoryList.Location = New System.Drawing.Point(8, 262)
        Me.vsfEventHistoryList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfEventHistoryList.Name = "vsfEventHistoryList"
        Me.vsfEventHistoryList.Rows.Count = 30
        Me.vsfEventHistoryList.Rows.DefaultSize = 18
        Me.vsfEventHistoryList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfEventHistoryList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfEventHistoryList.Size = New System.Drawing.Size(965, 311)
        Me.vsfEventHistoryList.StyleInfo = resources.GetString("vsfEventHistoryList.StyleInfo")
        Me.vsfEventHistoryList.TabIndex = 6
        '
        'cmbRollBackOpID
        '
        Me.cmbRollBackOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRollBackOpID.ForeColor = System.Drawing.Color.Black
        Me.cmbRollBackOpID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRollBackOpID.GridForeColor = System.Drawing.Color.Black
        Me.cmbRollBackOpID.Location = New System.Drawing.Point(8, 136)
        Me.cmbRollBackOpID.Name = "cmbRollBackOpID"
        Me.cmbRollBackOpID.Size = New System.Drawing.Size(305, 28)
        Me.cmbRollBackOpID.TabIndex = 1
        Me.cmbRollBackOpID.Value = Nothing
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NgChr = "'"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'cmbRollBackStepID
        '
        Me.cmbRollBackStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRollBackStepID.ForeColor = System.Drawing.Color.Black
        Me.cmbRollBackStepID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbRollBackStepID.GridForeColor = System.Drawing.Color.Black
        Me.cmbRollBackStepID.Location = New System.Drawing.Point(8, 197)
        Me.cmbRollBackStepID.Name = "cmbRollBackStepID"
        Me.cmbRollBackStepID.Size = New System.Drawing.Size(305, 28)
        Me.cmbRollBackStepID.TabIndex = 2
        Me.cmbRollBackStepID.Value = Nothing
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(320, 136)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(603, 91)
        Me.txtWorkMemo.TabIndex = 3
        '
        'lblInstructions
        '
        Me.lblInstructions.ForeColor = System.Drawing.Color.Red
        Me.lblInstructions.Location = New System.Drawing.Point(8, 239)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(423, 21)
        Me.lblInstructions.TabIndex = 38
        Me.lblInstructions.Text = "取消不可(灰色)の工程がある場合は、工程戻しできません"
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(666, 121)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 15)
        Me.lblLengthCount.TabIndex = 37
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblWorkMemoTitle
        '
        Me.lblWorkMemoTitle.BackColor = System.Drawing.Color.Navy
        Me.lblWorkMemoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWorkMemoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWorkMemoTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblWorkMemoTitle.Location = New System.Drawing.Point(320, 120)
        Me.lblWorkMemoTitle.Name = "lblWorkMemoTitle"
        Me.lblWorkMemoTitle.Size = New System.Drawing.Size(603, 17)
        Me.lblWorkMemoTitle.TabIndex = 36
        Me.lblWorkMemoTitle.Text = "作業メモ"
        Me.lblWorkMemoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRollBackStepIDTitle
        '
        Me.lblRollBackStepIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRollBackStepIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRollBackStepIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRollBackStepIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRollBackStepIDTitle.Location = New System.Drawing.Point(8, 181)
        Me.lblRollBackStepIDTitle.Name = "lblRollBackStepIDTitle"
        Me.lblRollBackStepIDTitle.Size = New System.Drawing.Size(305, 17)
        Me.lblRollBackStepIDTitle.TabIndex = 35
        Me.lblRollBackStepIDTitle.Text = "戻り小工程"
        Me.lblRollBackStepIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotIDTitle
        '
        Me.lblLotIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotIDTitle.Location = New System.Drawing.Point(16, 64)
        Me.lblLotIDTitle.Name = "lblLotIDTitle"
        Me.lblLotIDTitle.Size = New System.Drawing.Size(185, 17)
        Me.lblLotIDTitle.TabIndex = 34
        Me.lblLotIDTitle.Text = "ロットID"
        Me.lblLotIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 33
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblCarrierTitle
        '
        Me.lblCarrierTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCarrierTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCarrierTitle.Location = New System.Drawing.Point(16, 16)
        Me.lblCarrierTitle.Name = "lblCarrierTitle"
        Me.lblCarrierTitle.Size = New System.Drawing.Size(185, 17)
        Me.lblCarrierTitle.TabIndex = 32
        Me.lblCarrierTitle.Text = "キャリアID"
        Me.lblCarrierTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(16, 80)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 31
        Me.lblLotID.Text = "NNJZ000S00"
        '
        'lblLotStatus
        '
        Me.lblLotStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotStatus.Location = New System.Drawing.Point(216, 80)
        Me.lblLotStatus.Name = "lblLotStatus"
        Me.lblLotStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblLotStatus.TabIndex = 30
        Me.lblLotStatus.Text = "作業待ち"
        '
        'lblLotStatusTitle
        '
        Me.lblLotStatusTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotStatusTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotStatusTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotStatusTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotStatusTitle.Location = New System.Drawing.Point(216, 64)
        Me.lblLotStatusTitle.Name = "lblLotStatusTitle"
        Me.lblLotStatusTitle.Size = New System.Drawing.Size(97, 17)
        Me.lblLotStatusTitle.TabIndex = 29
        Me.lblLotStatusTitle.Text = "状態"
        Me.lblLotStatusTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNum
        '
        Me.lblNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNum.Location = New System.Drawing.Point(312, 32)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(97, 25)
        Me.lblNum.TabIndex = 28
        Me.lblNum.Text = "8"
        Me.lblNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLimitTimeTitle
        '
        Me.lblLimitTimeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLimitTimeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLimitTimeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLimitTimeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLimitTimeTitle.Location = New System.Drawing.Point(312, 64)
        Me.lblLimitTimeTitle.Name = "lblLimitTimeTitle"
        Me.lblLimitTimeTitle.Size = New System.Drawing.Size(97, 17)
        Me.lblLimitTimeTitle.TabIndex = 27
        Me.lblLimitTimeTitle.Text = "時間制限"
        Me.lblLimitTimeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLimitTime
        '
        Me.lblLimitTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLimitTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLimitTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLimitTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLimitTime.Location = New System.Drawing.Point(312, 80)
        Me.lblLimitTime.Name = "lblLimitTime"
        Me.lblLimitTime.Size = New System.Drawing.Size(97, 25)
        Me.lblLimitTime.TabIndex = 26
        Me.lblLimitTime.Text = "-12,345分"
        '
        'lblLotManagerTitle
        '
        Me.lblLotManagerTitle.BackColor = System.Drawing.Color.Navy
        Me.lblLotManagerTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManagerTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManagerTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblLotManagerTitle.Location = New System.Drawing.Point(688, 64)
        Me.lblLotManagerTitle.Name = "lblLotManagerTitle"
        Me.lblLotManagerTitle.Size = New System.Drawing.Size(181, 17)
        Me.lblLotManagerTitle.TabIndex = 25
        Me.lblLotManagerTitle.Text = "ロット担当"
        Me.lblLotManagerTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotManager
        '
        Me.lblLotManager.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(688, 80)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(181, 25)
        Me.lblLotManager.TabIndex = 24
        Me.lblLotManager.Text = "児島　徳幸"
        '
        'lblPdID
        '
        Me.lblPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(216, 32)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblPdID.TabIndex = 23
        Me.lblPdID.Text = "NNJ"
        '
        'lblPdIDTitle
        '
        Me.lblPdIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPdIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPdIDTitle.Location = New System.Drawing.Point(216, 16)
        Me.lblPdIDTitle.Name = "lblPdIDTitle"
        Me.lblPdIDTitle.Size = New System.Drawing.Size(97, 17)
        Me.lblPdIDTitle.TabIndex = 22
        Me.lblPdIDTitle.Text = "機種"
        Me.lblPdIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNumTitle
        '
        Me.lblNumTitle.BackColor = System.Drawing.Color.Navy
        Me.lblNumTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNumTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblNumTitle.Location = New System.Drawing.Point(312, 16)
        Me.lblNumTitle.Name = "lblNumTitle"
        Me.lblNumTitle.Size = New System.Drawing.Size(97, 17)
        Me.lblNumTitle.TabIndex = 21
        Me.lblNumTitle.Text = "数量"
        Me.lblNumTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSpecialFlag
        '
        Me.lblSpecialFlag.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblSpecialFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSpecialFlag.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSpecialFlag.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSpecialFlag.Location = New System.Drawing.Point(868, 32)
        Me.lblSpecialFlag.Name = "lblSpecialFlag"
        Me.lblSpecialFlag.Size = New System.Drawing.Size(97, 25)
        Me.lblSpecialFlag.TabIndex = 20
        Me.lblSpecialFlag.Text = "なし"
        '
        'lblProcStartTime
        '
        Me.lblProcStartTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProcStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcStartTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProcStartTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProcStartTime.Location = New System.Drawing.Point(688, 32)
        Me.lblProcStartTime.Name = "lblProcStartTime"
        Me.lblProcStartTime.Size = New System.Drawing.Size(181, 25)
        Me.lblProcStartTime.TabIndex = 19
        Me.lblProcStartTime.Text = "2008/05/12 13:30"
        '
        'lblProcStartTimeTitle
        '
        Me.lblProcStartTimeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblProcStartTimeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcStartTimeTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProcStartTimeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblProcStartTimeTitle.Location = New System.Drawing.Point(688, 16)
        Me.lblProcStartTimeTitle.Name = "lblProcStartTimeTitle"
        Me.lblProcStartTimeTitle.Size = New System.Drawing.Size(181, 17)
        Me.lblProcStartTimeTitle.TabIndex = 18
        Me.lblProcStartTimeTitle.Text = "処理開始日時"
        Me.lblProcStartTimeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSpecialFlagTitle
        '
        Me.lblSpecialFlagTitle.BackColor = System.Drawing.Color.Navy
        Me.lblSpecialFlagTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSpecialFlagTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSpecialFlagTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblSpecialFlagTitle.Location = New System.Drawing.Point(868, 16)
        Me.lblSpecialFlagTitle.Name = "lblSpecialFlagTitle"
        Me.lblSpecialFlagTitle.Size = New System.Drawing.Size(97, 17)
        Me.lblSpecialFlagTitle.TabIndex = 17
        Me.lblSpecialFlagTitle.Text = "特殊特性"
        Me.lblSpecialFlagTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpIDTitle
        '
        Me.lblOpIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblOpIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblOpIDTitle.Location = New System.Drawing.Point(408, 16)
        Me.lblOpIDTitle.Name = "lblOpIDTitle"
        Me.lblOpIDTitle.Size = New System.Drawing.Size(281, 17)
        Me.lblOpIDTitle.TabIndex = 16
        Me.lblOpIDTitle.Text = "大工程"
        Me.lblOpIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(408, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID.TabIndex = 15
        Me.lblOpID.Text = "投入"
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(408, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 14
        Me.lblStepID.Text = "03洗浄"
        '
        'lblStepIDTitle
        '
        Me.lblStepIDTitle.BackColor = System.Drawing.Color.Navy
        Me.lblStepIDTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepIDTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepIDTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblStepIDTitle.Location = New System.Drawing.Point(408, 64)
        Me.lblStepIDTitle.Name = "lblStepIDTitle"
        Me.lblStepIDTitle.Size = New System.Drawing.Size(281, 17)
        Me.lblStepIDTitle.TabIndex = 13
        Me.lblStepIDTitle.Text = "小工程"
        Me.lblStepIDTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHeaderInfo
        '
        Me.lblHeaderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeaderInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblHeaderInfo.Location = New System.Drawing.Point(8, 8)
        Me.lblHeaderInfo.Name = "lblHeaderInfo"
        Me.lblHeaderInfo.Size = New System.Drawing.Size(965, 105)
        Me.lblHeaderInfo.TabIndex = 12
        '
        'lblRollBackOpIDTitle1
        '
        Me.lblRollBackOpIDTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblRollBackOpIDTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRollBackOpIDTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRollBackOpIDTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblRollBackOpIDTitle1.Location = New System.Drawing.Point(8, 120)
        Me.lblRollBackOpIDTitle1.Name = "lblRollBackOpIDTitle1"
        Me.lblRollBackOpIDTitle1.Size = New System.Drawing.Size(305, 17)
        Me.lblRollBackOpIDTitle1.TabIndex = 11
        Me.lblRollBackOpIDTitle1.Text = "戻り大工程"
        Me.lblRollBackOpIDTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGRBTitle
        '
        Me.lblGRBTitle.BackColor = System.Drawing.Color.Navy
        Me.lblGRBTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRBTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRBTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblGRBTitle.Location = New System.Drawing.Point(868, 64)
        Me.lblGRBTitle.Name = "lblGRBTitle"
        Me.lblGRBTitle.Size = New System.Drawing.Size(97, 17)
        Me.lblGRBTitle.TabIndex = 39
        Me.lblGRBTitle.Text = "GRB"
        Me.lblGRBTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGRB
        '
        Me.lblGRB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGRB.Location = New System.Drawing.Point(868, 80)
        Me.lblGRB.Name = "lblGRB"
        Me.lblGRB.Size = New System.Drawing.Size(97, 25)
        Me.lblGRB.TabIndex = 40
        '
        'frmxxEN02A0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblGRB)
        Me.Controls.Add(Me.lblGRBTitle)
        Me.Controls.Add(Me.lblRollBackStepIDTitle)
        Me.Controls.Add(Me.lblRollBackOpIDTitle1)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdLotComment)
        Me.Controls.Add(Me.cmdWorkMemoChk)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfEventHistoryList)
        Me.Controls.Add(Me.cmbRollBackOpID)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.cmbRollBackStepID)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblWorkMemoTitle)
        Me.Controls.Add(Me.lblLotIDTitle)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblCarrierTitle)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblLotStatus)
        Me.Controls.Add(Me.lblLotStatusTitle)
        Me.Controls.Add(Me.lblNum)
        Me.Controls.Add(Me.lblLimitTimeTitle)
        Me.Controls.Add(Me.lblLimitTime)
        Me.Controls.Add(Me.lblLotManagerTitle)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblPdIDTitle)
        Me.Controls.Add(Me.lblNumTitle)
        Me.Controls.Add(Me.lblSpecialFlag)
        Me.Controls.Add(Me.lblProcStartTime)
        Me.Controls.Add(Me.lblProcStartTimeTitle)
        Me.Controls.Add(Me.lblSpecialFlagTitle)
        Me.Controls.Add(Me.lblOpIDTitle)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblStepIDTitle)
        Me.Controls.Add(Me.lblHeaderInfo)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02A0"
        Me.Text = "工程戻し"
        CType(Me.vsfEventHistoryList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdLotComment As Button
    Friend WithEvents cmdWorkMemoChk As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfEventHistoryList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbRollBackOpID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbRollBackStepID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents lblInstructions As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblWorkMemoTitle As Label
    Friend WithEvents lblRollBackStepIDTitle As Label
    Friend WithEvents lblLotIDTitle As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblCarrierTitle As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblLotStatus As Label
    Friend WithEvents lblLotStatusTitle As Label
    Friend WithEvents lblNum As Label
    Friend WithEvents lblLimitTimeTitle As Label
    Friend WithEvents lblLimitTime As Label
    Friend WithEvents lblLotManagerTitle As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblPdIDTitle As Label
    Friend WithEvents lblNumTitle As Label
    Friend WithEvents lblSpecialFlag As Label
    Friend WithEvents lblProcStartTime As Label
    Friend WithEvents lblProcStartTimeTitle As Label
    Friend WithEvents lblSpecialFlagTitle As Label
    Friend WithEvents lblOpIDTitle As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblStepIDTitle As Label
    Friend WithEvents lblHeaderInfo As Label
    Friend WithEvents lblRollBackOpIDTitle1 As Label
    Friend WithEvents lblGRBTitle As Label
    Friend WithEvents lblGRB As Label
End Class
