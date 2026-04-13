<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00K0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00K0))
        Me.optLotNextSend0 = New System.Windows.Forms.RadioButton()
        Me.optLotNextSend1 = New System.Windows.Forms.RadioButton()
        Me.cmdTrouble = New System.Windows.Forms.Button()
        Me.cmdWorkRecord = New System.Windows.Forms.Button()
        Me.cmdCollectionInfo = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdTreatWF = New System.Windows.Forms.Button()
        Me.cmdNextDown = New System.Windows.Forms.Button()
        Me.cmdNextUP = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdCommntInput = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdTxtUp = New System.Windows.Forms.Button()
        Me.cmdTxtDown = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdActionDisp = New System.Windows.Forms.Button()
        Me.txtLotCommnt = New SETextBoxEx.TextBoxEx()
        Me.vsfBatList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.vsfNextStepInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.lblBack1 = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblLotNum = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblCarrierC = New System.Windows.Forms.Label()
        Me.lblWPName = New System.Windows.Forms.Label()
        Me.lblLotStatus = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblBatID = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblRecipe = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblBack0 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        CType(Me.vsfBatList,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfNextStepInfo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'optLotNextSend0
        '
        Me.optLotNextSend0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optLotNextSend0.Location = New System.Drawing.Point(822, 427)
        Me.optLotNextSend0.Name = "optLotNextSend0"
        Me.optLotNextSend0.Size = New System.Drawing.Size(147, 31)
        Me.optLotNextSend0.TabIndex = 12
        Me.optLotNextSend0.Text = "送出あり"
        '
        'optLotNextSend1
        '
        Me.optLotNextSend1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optLotNextSend1.Location = New System.Drawing.Point(822, 465)
        Me.optLotNextSend1.Name = "optLotNextSend1"
        Me.optLotNextSend1.Size = New System.Drawing.Size(147, 31)
        Me.optLotNextSend1.TabIndex = 13
        Me.optLotNextSend1.Text = "送出なし"
        '
        'cmdTrouble
        '
        Me.cmdTrouble.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTrouble.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTrouble.Location = New System.Drawing.Point(548, 579)
        Me.cmdTrouble.Name = "cmdTrouble"
        Me.cmdTrouble.Size = New System.Drawing.Size(105, 57)
        Me.cmdTrouble.TabIndex = 17
        Me.cmdTrouble.Text = "異常処理"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"票起案"
        '
        'cmdWorkRecord
        '
        Me.cmdWorkRecord.Enabled = false
        Me.cmdWorkRecord.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkRecord.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWorkRecord.Location = New System.Drawing.Point(872, 519)
        Me.cmdWorkRecord.Name = "cmdWorkRecord"
        Me.cmdWorkRecord.Size = New System.Drawing.Size(105, 57)
        Me.cmdWorkRecord.TabIndex = 19
        Me.cmdWorkRecord.Text = "作業記録"
        Me.cmdWorkRecord.Visible = false
        '
        'cmdCollectionInfo
        '
        Me.cmdCollectionInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCollectionInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCollectionInfo.Location = New System.Drawing.Point(440, 579)
        Me.cmdCollectionInfo.Name = "cmdCollectionInfo"
        Me.cmdCollectionInfo.Size = New System.Drawing.Size(105, 57)
        Me.cmdCollectionInfo.TabIndex = 16
        Me.cmdCollectionInfo.Text = "装置データ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"登録／参照"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(750, 438)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 11
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(750, 394)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoUp.TabIndex = 10
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdTreatWF
        '
        Me.cmdTreatWF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTreatWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTreatWF.Location = New System.Drawing.Point(656, 579)
        Me.cmdTreatWF.Name = "cmdTreatWF"
        Me.cmdTreatWF.Size = New System.Drawing.Size(105, 57)
        Me.cmdTreatWF.TabIndex = 18
        Me.cmdTreatWF.Text = "WF状態変更"
        '
        'cmdNextDown
        '
        Me.cmdNextDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNextDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNextDown.Location = New System.Drawing.Point(927, 335)
        Me.cmdNextDown.Name = "cmdNextDown"
        Me.cmdNextDown.Size = New System.Drawing.Size(49, 49)
        Me.cmdNextDown.TabIndex = 8
        Me.cmdNextDown.Text = "▼"
        '
        'cmdNextUP
        '
        Me.cmdNextUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNextUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNextUP.Location = New System.Drawing.Point(927, 287)
        Me.cmdNextUP.Name = "cmdNextUP"
        Me.cmdNextUP.Size = New System.Drawing.Size(49, 49)
        Me.cmdNextUP.TabIndex = 7
        Me.cmdNextUP.Text = "▲"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(468, 220)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(452, 49)
        Me.cmdRight.TabIndex = 5
        Me.cmdRight.Text = ">>"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(15, 220)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(452, 49)
        Me.cmdLeft.TabIndex = 4
        Me.cmdLeft.Text = "<<"
        '
        'cmdCommntInput
        '
        Me.cmdCommntInput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommntInput.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommntInput.Location = New System.Drawing.Point(332, 579)
        Me.cmdCommntInput.Name = "cmdCommntInput"
        Me.cmdCommntInput.Size = New System.Drawing.Size(105, 57)
        Me.cmdCommntInput.TabIndex = 15
        Me.cmdCommntInput.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(919, 144)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 77)
        Me.cmdDown.TabIndex = 3
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(919, 67)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 77)
        Me.cmdUP.TabIndex = 2
        Me.cmdUP.Text = "▲"
        '
        'cmdTxtUp
        '
        Me.cmdTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtUp.Location = New System.Drawing.Point(750, 489)
        Me.cmdTxtUp.Name = "cmdTxtUp"
        Me.cmdTxtUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdTxtUp.TabIndex = 20
        Me.cmdTxtUp.Text = "▲"
        '
        'cmdTxtDown
        '
        Me.cmdTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtDown.Location = New System.Drawing.Point(750, 533)
        Me.cmdTxtDown.Name = "cmdTxtDown"
        Me.cmdTxtDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdTxtDown.TabIndex = 21
        Me.cmdTxtDown.Text = "▼"
        '
        'txtCarrier
        '
        Me.txtCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
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
        Me.cmdClose.TabIndex = 22
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 579)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 6
        Me.cmdRegist.Text = "確　定"
        '
        'cmdActionDisp
        '
        Me.cmdActionDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdActionDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdActionDisp.Location = New System.Drawing.Point(116, 579)
        Me.cmdActionDisp.Name = "cmdActionDisp"
        Me.cmdActionDisp.Size = New System.Drawing.Size(105, 57)
        Me.cmdActionDisp.TabIndex = 14
        Me.cmdActionDisp.Text = "アクション"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"予約確認"
        '
        'txtLotCommnt
        '
        Me.txtLotCommnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotCommnt.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtLotCommnt.ChrMaxByte = 0
        Me.txtLotCommnt.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtLotCommnt.GotHighLight = false
        Me.txtLotCommnt.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotCommnt.Location = New System.Drawing.Point(8, 506)
        Me.txtLotCommnt.MultiLineEx = true
        Me.txtLotCommnt.Name = "txtLotCommnt"
        Me.txtLotCommnt.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotCommnt.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotCommnt.SelectedText = ""
        Me.txtLotCommnt.Size = New System.Drawing.Size(743, 69)
        Me.txtLotCommnt.TabIndex = 23
        '
        'vsfBatList
        '
        Me.vsfBatList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfBatList.AllowEditing = false
        Me.vsfBatList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfBatList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfBatList.AutoResize = true
        Me.vsfBatList.AutoSearchDelay = 2R
        Me.vsfBatList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfBatList.ColumnInfo = resources.GetString("vsfBatList.ColumnInfo")
        Me.vsfBatList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfBatList.ExtendLastCol = true
        Me.vsfBatList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfBatList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfBatList.Location = New System.Drawing.Point(16, 68)
        Me.vsfBatList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfBatList.Name = "vsfBatList"
        Me.vsfBatList.Rows.Count = 11
        Me.vsfBatList.Rows.DefaultSize = 18
        Me.vsfBatList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfBatList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfBatList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfBatList.Size = New System.Drawing.Size(903, 152)
        Me.vsfBatList.StyleInfo = resources.GetString("vsfBatList.StyleInfo")
        Me.vsfBatList.TabIndex = 1
        '
        'vsfNextStepInfo
        '
        Me.vsfNextStepInfo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfNextStepInfo.AllowEditing = false
        Me.vsfNextStepInfo.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfNextStepInfo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfNextStepInfo.AutoResize = true
        Me.vsfNextStepInfo.AutoSearchDelay = 2R
        Me.vsfNextStepInfo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfNextStepInfo.ColumnInfo = resources.GetString("vsfNextStepInfo.ColumnInfo")
        Me.vsfNextStepInfo.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfNextStepInfo.ExtendLastCol = true
        Me.vsfNextStepInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfNextStepInfo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfNextStepInfo.Location = New System.Drawing.Point(8, 288)
        Me.vsfNextStepInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfNextStepInfo.Name = "vsfNextStepInfo"
        Me.vsfNextStepInfo.Rows.DefaultSize = 18
        Me.vsfNextStepInfo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfNextStepInfo.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfNextStepInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfNextStepInfo.Size = New System.Drawing.Size(920, 95)
        Me.vsfNextStepInfo.StyleInfo = resources.GetString("vsfNextStepInfo.StyleInfo")
        Me.vsfNextStepInfo.TabIndex = 24
        Me.vsfNextStepInfo.TabStop = false
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 411)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
        Me.txtWorkMemo.TabIndex = 9
        '
        'lblBack1
        '
        Me.lblBack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack1.Location = New System.Drawing.Point(806, 411)
        Me.lblBack1.Name = "lblBack1"
        Me.lblBack1.Size = New System.Drawing.Size(169, 100)
        Me.lblBack1.TabIndex = 42
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(806, 395)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(169, 17)
        Me.lblTtl12.TabIndex = 41
        Me.lblTtl12.Text = "次工程"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(494, 396)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 39
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLotNum
        '
        Me.lblLotNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotNum.Location = New System.Drawing.Point(882, 32)
        Me.lblLotNum.Name = "lblLotNum"
        Me.lblLotNum.Size = New System.Drawing.Size(85, 30)
        Me.lblLotNum.TabIndex = 38
        Me.lblLotNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(882, 16)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(85, 17)
        Me.lblTtl8.TabIndex = 37
        Me.lblTtl8.Text = "ロット数"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCarrierC
        '
        Me.lblCarrierC.BackColor = System.Drawing.Color.Navy
        Me.lblCarrierC.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrierC.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblCarrierC.Location = New System.Drawing.Point(494, 491)
        Me.lblCarrierC.Name = "lblCarrierC"
        Me.lblCarrierC.Size = New System.Drawing.Size(249, 16)
        Me.lblCarrierC.TabIndex = 36
        Me.lblCarrierC.Text = "ｷｬﾘｱID:A00001"
        Me.lblCarrierC.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblWPName
        '
        Me.lblWPName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWPName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWPName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWPName.Location = New System.Drawing.Point(410, 32)
        Me.lblWPName.Name = "lblWPName"
        Me.lblWPName.Size = New System.Drawing.Size(209, 30)
        Me.lblWPName.TabIndex = 35
        '
        'lblLotStatus
        '
        Me.lblLotStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotStatus.Location = New System.Drawing.Point(314, 32)
        Me.lblLotStatus.Name = "lblLotStatus"
        Me.lblLotStatus.Size = New System.Drawing.Size(97, 30)
        Me.lblLotStatus.TabIndex = 34
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(314, 16)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl1.TabIndex = 33
        Me.lblTtl1.Text = "状態"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(410, 16)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(209, 17)
        Me.lblTtl2.TabIndex = 32
        Me.lblTtl2.Text = "装置名"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBatID
        '
        Me.lblBatID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblBatID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBatID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBatID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBatID.Location = New System.Drawing.Point(204, 32)
        Me.lblBatID.Name = "lblBatID"
        Me.lblBatID.Size = New System.Drawing.Size(111, 30)
        Me.lblBatID.TabIndex = 31
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(204, 16)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(111, 17)
        Me.lblTtl4.TabIndex = 30
        Me.lblTtl4.Text = "バッチID"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(618, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(265, 17)
        Me.lblTtl3.TabIndex = 29
        Me.lblTtl3.Text = "レシピ"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRecipe
        '
        Me.lblRecipe.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRecipe.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRecipe.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRecipe.Location = New System.Drawing.Point(618, 32)
        Me.lblRecipe.Name = "lblRecipe"
        Me.lblRecipe.Size = New System.Drawing.Size(265, 30)
        Me.lblRecipe.TabIndex = 28
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(8, 490)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl6.TabIndex = 27
        Me.lblTtl6.Text = "      コメント"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(16, 16)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl0.TabIndex = 26
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack0
        '
        Me.lblBack0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack0.Location = New System.Drawing.Point(8, 8)
        Me.lblBack0.Name = "lblBack0"
        Me.lblBack0.Size = New System.Drawing.Size(965, 273)
        Me.lblBack0.TabIndex = 25
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(8, 395)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl5.TabIndex = 40
        Me.lblTtl5.Text = "      作業メモ"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00K0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.optLotNextSend0)
        Me.Controls.Add(Me.optLotNextSend1)
        Me.Controls.Add(Me.cmdTrouble)
        Me.Controls.Add(Me.cmdWorkRecord)
        Me.Controls.Add(Me.cmdCollectionInfo)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdTreatWF)
        Me.Controls.Add(Me.cmdNextDown)
        Me.Controls.Add(Me.cmdNextUP)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdCommntInput)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdTxtUp)
        Me.Controls.Add(Me.cmdTxtDown)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdActionDisp)
        Me.Controls.Add(Me.txtLotCommnt)
        Me.Controls.Add(Me.vsfBatList)
        Me.Controls.Add(Me.vsfNextStepInfo)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.lblBack1)
        Me.Controls.Add(Me.lblTtl12)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblLotNum)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblCarrierC)
        Me.Controls.Add(Me.lblWPName)
        Me.Controls.Add(Me.lblLotStatus)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblBatID)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblRecipe)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblBack0)
        Me.Controls.Add(Me.lblTtl5)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00K0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "バッチ作業終了"
        CType(Me.vsfBatList,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfNextStepInfo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents optLotNextSend0 As RadioButton
    Friend WithEvents optLotNextSend1 As RadioButton
    Friend WithEvents cmdTrouble As Button
    Friend WithEvents cmdWorkRecord As Button
    Friend WithEvents cmdCollectionInfo As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdTreatWF As Button
    Friend WithEvents cmdNextDown As Button
    Friend WithEvents cmdNextUP As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdCommntInput As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdTxtUp As Button
    Friend WithEvents cmdTxtDown As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdActionDisp As Button
    Friend WithEvents txtLotCommnt As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfBatList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents vsfNextStepInfo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents lblBack1 As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblLotNum As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblCarrierC As Label
    Friend WithEvents lblWPName As Label
    Friend WithEvents lblLotStatus As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblBatID As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblRecipe As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblBack0 As Label
    Friend WithEvents lblTtl5 As Label
End Class
