<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0060
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0060))
        Me.cmdCFMove = New System.Windows.Forms.Button()
        Me.cmdODF = New System.Windows.Forms.Button()
        Me.cmdTreatCF = New System.Windows.Forms.Button()
        Me.optLotNextSend3 = New System.Windows.Forms.RadioButton()
        Me.cmdTpalCombRegist = New System.Windows.Forms.Button()
        Me.optLotNextSend0 = New System.Windows.Forms.RadioButton()
        Me.optLotNextSend1 = New System.Windows.Forms.RadioButton()
        Me.optLotNextSend2 = New System.Windows.Forms.RadioButton()
        Me.cmdTrouble = New System.Windows.Forms.Button()
        Me.cmdActionDisp = New System.Windows.Forms.Button()
        Me.cmdCFKIWorkEnd = New System.Windows.Forms.Button()
        Me.cmdTreatChip = New System.Windows.Forms.Button()
        Me.cmdTreatWF = New System.Windows.Forms.Button()
        Me.cmdCollectionInfo = New System.Windows.Forms.Button()
        Me.cmdCommntInput = New System.Windows.Forms.Button()
        Me.cmdNextUP = New System.Windows.Forms.Button()
        Me.cmdNextDown = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdCommentDown = New System.Windows.Forms.Button()
        Me.cmdCommentUp = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.vsfNextStepInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtLotCommnt = New SETextBoxEx.TextBoxEx()
        Me.lblBack1 = New System.Windows.Forms.Label()
        Me.lblTtl12 = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
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
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblBack0 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblGRB = New System.Windows.Forms.Label()
        CType(Me.vsfNextStepInfo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCFMove
        '
        Me.cmdCFMove.Enabled = false
        Me.cmdCFMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCFMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCFMove.Location = New System.Drawing.Point(332, 579)
        Me.cmdCFMove.Name = "cmdCFMove"
        Me.cmdCFMove.Size = New System.Drawing.Size(105, 57)
        Me.cmdCFMove.TabIndex = 54
        Me.cmdCFMove.Text = "CF移載"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"情報入力"
        '
        'cmdODF
        '
        Me.cmdODF.Enabled = false
        Me.cmdODF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdODF.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdODF.Location = New System.Drawing.Point(872, 339)
        Me.cmdODF.Name = "cmdODF"
        Me.cmdODF.Size = New System.Drawing.Size(105, 57)
        Me.cmdODF.TabIndex = 12
        Me.cmdODF.Text = "ODF貼り"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"合わせ登録"
        Me.cmdODF.Visible = false
        '
        'cmdTreatCF
        '
        Me.cmdTreatCF.Enabled = false
        Me.cmdTreatCF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTreatCF.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTreatCF.Location = New System.Drawing.Point(872, 519)
        Me.cmdTreatCF.Name = "cmdTreatCF"
        Me.cmdTreatCF.Size = New System.Drawing.Size(105, 57)
        Me.cmdTreatCF.TabIndex = 15
        Me.cmdTreatCF.Text = "対向基板"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"処置登録"
        '
        'optLotNextSend3
        '
        Me.optLotNextSend3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optLotNextSend3.Location = New System.Drawing.Point(820, 292)
        Me.optLotNextSend3.Name = "optLotNextSend3"
        Me.optLotNextSend3.Size = New System.Drawing.Size(147, 37)
        Me.optLotNextSend3.TabIndex = 5
        Me.optLotNextSend3.Text = "追加流動"
        '
        'cmdTpalCombRegist
        '
        Me.cmdTpalCombRegist.Enabled = false
        Me.cmdTpalCombRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTpalCombRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTpalCombRegist.Location = New System.Drawing.Point(872, 459)
        Me.cmdTpalCombRegist.Name = "cmdTpalCombRegist"
        Me.cmdTpalCombRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdTpalCombRegist.TabIndex = 14
        Me.cmdTpalCombRegist.Text = "TPAL貼り"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"合わせ登録"
        '
        'optLotNextSend0
        '
        Me.optLotNextSend0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optLotNextSend0.Location = New System.Drawing.Point(820, 148)
        Me.optLotNextSend0.Name = "optLotNextSend0"
        Me.optLotNextSend0.Size = New System.Drawing.Size(147, 37)
        Me.optLotNextSend0.TabIndex = 2
        Me.optLotNextSend0.Text = "送出あり"
        '
        'optLotNextSend1
        '
        Me.optLotNextSend1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optLotNextSend1.Location = New System.Drawing.Point(820, 194)
        Me.optLotNextSend1.Name = "optLotNextSend1"
        Me.optLotNextSend1.Size = New System.Drawing.Size(147, 37)
        Me.optLotNextSend1.TabIndex = 3
        Me.optLotNextSend1.Text = "送出なし"
        '
        'optLotNextSend2
        '
        Me.optLotNextSend2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optLotNextSend2.Location = New System.Drawing.Point(820, 244)
        Me.optLotNextSend2.Name = "optLotNextSend2"
        Me.optLotNextSend2.Size = New System.Drawing.Size(147, 37)
        Me.optLotNextSend2.TabIndex = 4
        Me.optLotNextSend2.Text = "リワーク"
        '
        'cmdTrouble
        '
        Me.cmdTrouble.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTrouble.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTrouble.Location = New System.Drawing.Point(548, 579)
        Me.cmdTrouble.Name = "cmdTrouble"
        Me.cmdTrouble.Size = New System.Drawing.Size(105, 57)
        Me.cmdTrouble.TabIndex = 9
        Me.cmdTrouble.Text = "異常処理"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"票起案"
        '
        'cmdActionDisp
        '
        Me.cmdActionDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdActionDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdActionDisp.Location = New System.Drawing.Point(116, 579)
        Me.cmdActionDisp.Name = "cmdActionDisp"
        Me.cmdActionDisp.Size = New System.Drawing.Size(105, 57)
        Me.cmdActionDisp.TabIndex = 7
        Me.cmdActionDisp.Text = "アクション"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"予約確認"
        '
        'cmdCFKIWorkEnd
        '
        Me.cmdCFKIWorkEnd.Enabled = false
        Me.cmdCFKIWorkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCFKIWorkEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCFKIWorkEnd.Location = New System.Drawing.Point(872, 399)
        Me.cmdCFKIWorkEnd.Name = "cmdCFKIWorkEnd"
        Me.cmdCFKIWorkEnd.Size = New System.Drawing.Size(105, 57)
        Me.cmdCFKIWorkEnd.TabIndex = 13
        Me.cmdCFKIWorkEnd.Text = "CFKI作業"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"終了入力"
        '
        'cmdTreatChip
        '
        Me.cmdTreatChip.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTreatChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTreatChip.Location = New System.Drawing.Point(764, 579)
        Me.cmdTreatChip.Name = "cmdTreatChip"
        Me.cmdTreatChip.Size = New System.Drawing.Size(105, 57)
        Me.cmdTreatChip.TabIndex = 11
        Me.cmdTreatChip.Text = "チップ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"状態変更"
        '
        'cmdTreatWF
        '
        Me.cmdTreatWF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTreatWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTreatWF.Location = New System.Drawing.Point(656, 579)
        Me.cmdTreatWF.Name = "cmdTreatWF"
        Me.cmdTreatWF.Size = New System.Drawing.Size(105, 57)
        Me.cmdTreatWF.TabIndex = 10
        Me.cmdTreatWF.Text = "WF状態変更"
        '
        'cmdCollectionInfo
        '
        Me.cmdCollectionInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCollectionInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCollectionInfo.Location = New System.Drawing.Point(440, 579)
        Me.cmdCollectionInfo.Name = "cmdCollectionInfo"
        Me.cmdCollectionInfo.Size = New System.Drawing.Size(105, 57)
        Me.cmdCollectionInfo.TabIndex = 8
        Me.cmdCollectionInfo.Text = "装置データ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"登録／参照"
        '
        'cmdCommntInput
        '
        Me.cmdCommntInput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommntInput.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommntInput.Location = New System.Drawing.Point(224, 579)
        Me.cmdCommntInput.Name = "cmdCommntInput"
        Me.cmdCommntInput.Size = New System.Drawing.Size(105, 57)
        Me.cmdCommntInput.TabIndex = 1
        Me.cmdCommntInput.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'cmdNextUP
        '
        Me.cmdNextUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNextUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNextUP.Location = New System.Drawing.Point(750, 123)
        Me.cmdNextUP.Name = "cmdNextUP"
        Me.cmdNextUP.Size = New System.Drawing.Size(49, 76)
        Me.cmdNextUP.TabIndex = 17
        Me.cmdNextUP.Text = "▲"
        '
        'cmdNextDown
        '
        Me.cmdNextDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNextDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNextDown.Location = New System.Drawing.Point(750, 199)
        Me.cmdNextDown.Name = "cmdNextDown"
        Me.cmdNextDown.Size = New System.Drawing.Size(49, 76)
        Me.cmdNextDown.TabIndex = 18
        Me.cmdNextDown.Text = "▼"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(750, 411)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoDown.TabIndex = 21
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(750, 367)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(49, 43)
        Me.cmdMemoUp.TabIndex = 20
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdCommentDown
        '
        Me.cmdCommentDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentDown.Location = New System.Drawing.Point(750, 520)
        Me.cmdCommentDown.Name = "cmdCommentDown"
        Me.cmdCommentDown.Size = New System.Drawing.Size(49, 55)
        Me.cmdCommentDown.TabIndex = 23
        Me.cmdCommentDown.Text = "▼"
        '
        'cmdCommentUp
        '
        Me.cmdCommentUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentUp.Location = New System.Drawing.Point(750, 463)
        Me.cmdCommentUp.Name = "cmdCommentUp"
        Me.cmdCommentUp.Size = New System.Drawing.Size(49, 55)
        Me.cmdCommentUp.TabIndex = 22
        Me.cmdCommentUp.Text = "▲"
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
        Me.txtCarrier.NgChr = "'"
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
        Me.cmdClose.TabIndex = 24
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
        'txtWorkMemo
        '
        Me.txtWorkMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 384)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(743, 69)
        Me.txtWorkMemo.TabIndex = 19
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
        Me.vsfNextStepInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfNextStepInfo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfNextStepInfo.Location = New System.Drawing.Point(8, 124)
        Me.vsfNextStepInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfNextStepInfo.Name = "vsfNextStepInfo"
        Me.vsfNextStepInfo.Rows.DefaultSize = 18
        Me.vsfNextStepInfo.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfNextStepInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfNextStepInfo.Size = New System.Drawing.Size(743, 150)
        Me.vsfNextStepInfo.StyleInfo = resources.GetString("vsfNextStepInfo.StyleInfo")
        Me.vsfNextStepInfo.TabIndex = 16
        Me.vsfNextStepInfo.TabStop = false
        '
        'txtLotCommnt
        '
        Me.txtLotCommnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLotCommnt.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtLotCommnt.ChrMaxByte = 0
        Me.txtLotCommnt.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtLotCommnt.GotHighLight = false
        Me.txtLotCommnt.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotCommnt.Location = New System.Drawing.Point(8, 481)
        Me.txtLotCommnt.MultiLineEx = true
        Me.txtLotCommnt.Name = "txtLotCommnt"
        Me.txtLotCommnt.NgChr = "'"
        Me.txtLotCommnt.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotCommnt.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotCommnt.SelectedText = ""
        Me.txtLotCommnt.Size = New System.Drawing.Size(743, 93)
        Me.txtLotCommnt.TabIndex = 53
        Me.txtLotCommnt.TabStop = false
        '
        'lblBack1
        '
        Me.lblBack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack1.Location = New System.Drawing.Point(804, 137)
        Me.lblBack1.Name = "lblBack1"
        Me.lblBack1.Size = New System.Drawing.Size(169, 200)
        Me.lblBack1.TabIndex = 52
        '
        'lblTtl12
        '
        Me.lblTtl12.BackColor = System.Drawing.Color.Navy
        Me.lblTtl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl12.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl12.Location = New System.Drawing.Point(804, 121)
        Me.lblTtl12.Name = "lblTtl12"
        Me.lblTtl12.Size = New System.Drawing.Size(169, 17)
        Me.lblTtl12.TabIndex = 51
        Me.lblTtl12.Text = "次工程"
        Me.lblTtl12.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblTtl8.TabIndex = 50
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
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 49
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
        Me.lblOpID.TabIndex = 48
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
        Me.lblTtl2.TabIndex = 47
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
        Me.lblTtl6.TabIndex = 46
        Me.lblTtl6.Text = "特殊特性"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(688, 16)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl4.TabIndex = 45
        Me.lblTtl4.Text = "処理開始日時"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStartDayTime
        '
        Me.lblStartDayTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStartDayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDayTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDayTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStartDayTime.Location = New System.Drawing.Point(688, 32)
        Me.lblStartDayTime.Name = "lblStartDayTime"
        Me.lblStartDayTime.Size = New System.Drawing.Size(181, 25)
        Me.lblStartDayTime.TabIndex = 44
        '
        'lblS
        '
        Me.lblS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblS.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblS.Location = New System.Drawing.Point(868, 32)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(97, 25)
        Me.lblS.TabIndex = 43
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
        Me.lblTtl5.TabIndex = 42
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
        Me.lblTtl3.TabIndex = 41
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
        Me.lblPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblPdID.TabIndex = 40
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
        Me.lblLotManager.TabIndex = 39
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
        Me.lblTtl9.TabIndex = 38
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
        Me.lblTimeLimit.Size = New System.Drawing.Size(97, 25)
        Me.lblTimeLimit.TabIndex = 37
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
        Me.lblTtl10.TabIndex = 36
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
        Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
        Me.lblWFNo.TabIndex = 35
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(494, 369)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 34
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 368)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl15.TabIndex = 33
        Me.lblTtl15.Text = "      作業メモ"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(8, 464)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(743, 17)
        Me.lblTtl11.TabIndex = 32
        Me.lblTtl11.Text = "      コメント"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(16, 64)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 30
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblFlowClass.TabIndex = 26
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
        Me.lblTtl0.TabIndex = 31
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblLotID.TabIndex = 29
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(216, 80)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblStatus.TabIndex = 28
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(216, 64)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl7.TabIndex = 27
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack0
        '
        Me.lblBack0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack0.Location = New System.Drawing.Point(8, 8)
        Me.lblBack0.Name = "lblBack0"
        Me.lblBack0.Size = New System.Drawing.Size(965, 105)
        Me.lblBack0.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Navy
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Yellow
        Me.Label13.Location = New System.Drawing.Point(868, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 17)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "GRB"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblGRB.TabIndex = 56
        '
        'frmxxEN0060
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblGRB)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmdCFMove)
        Me.Controls.Add(Me.cmdODF)
        Me.Controls.Add(Me.cmdTreatCF)
        Me.Controls.Add(Me.optLotNextSend3)
        Me.Controls.Add(Me.cmdTpalCombRegist)
        Me.Controls.Add(Me.optLotNextSend0)
        Me.Controls.Add(Me.optLotNextSend1)
        Me.Controls.Add(Me.optLotNextSend2)
        Me.Controls.Add(Me.cmdTrouble)
        Me.Controls.Add(Me.cmdActionDisp)
        Me.Controls.Add(Me.cmdCFKIWorkEnd)
        Me.Controls.Add(Me.cmdTreatChip)
        Me.Controls.Add(Me.cmdTreatWF)
        Me.Controls.Add(Me.cmdCollectionInfo)
        Me.Controls.Add(Me.cmdCommntInput)
        Me.Controls.Add(Me.cmdNextUP)
        Me.Controls.Add(Me.cmdNextDown)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdCommentDown)
        Me.Controls.Add(Me.cmdCommentUp)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.vsfNextStepInfo)
        Me.Controls.Add(Me.txtLotCommnt)
        Me.Controls.Add(Me.lblBack1)
        Me.Controls.Add(Me.lblTtl12)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblTtl4)
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
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblTtl15)
        Me.Controls.Add(Me.lblTtl11)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblBack0)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0060"
        Me.Text = "作業終了　（運用モード：OffLine,M1,M2,S1）"
        CType(Me.vsfNextStepInfo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCFMove As Button
    Friend WithEvents cmdODF As Button
    Friend WithEvents cmdTreatCF As Button
    Friend WithEvents optLotNextSend3 As RadioButton
    Friend WithEvents cmdTpalCombRegist As Button
    Friend WithEvents optLotNextSend0 As RadioButton
    Friend WithEvents optLotNextSend1 As RadioButton
    Friend WithEvents optLotNextSend2 As RadioButton
    Friend WithEvents cmdTrouble As Button
    Friend WithEvents cmdActionDisp As Button
    Friend WithEvents cmdCFKIWorkEnd As Button
    Friend WithEvents cmdTreatChip As Button
    Friend WithEvents cmdTreatWF As Button
    Friend WithEvents cmdCollectionInfo As Button
    Friend WithEvents cmdCommntInput As Button
    Friend WithEvents cmdNextUP As Button
    Friend WithEvents cmdNextDown As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdCommentDown As Button
    Friend WithEvents cmdCommentUp As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfNextStepInfo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtLotCommnt As SETextBoxEx.TextBoxEx
    Friend WithEvents lblBack1 As Label
    Friend WithEvents lblTtl12 As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl4 As Label
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
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblBack0 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblGRB As Label
End Class
