<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02Q0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02Q0))
        Me.cmdLabelScan = New System.Windows.Forms.Button()
        Me.cmdCommentDown = New System.Windows.Forms.Button()
        Me.cmdCommentUp = New System.Windows.Forms.Button()
        Me.cmdMemoDown = New System.Windows.Forms.Button()
        Me.cmdMemoUp = New System.Windows.Forms.Button()
        Me.cmdACarrierMoQuFdSelect = New System.Windows.Forms.Button()
        Me.cmdACarrierSelect = New System.Windows.Forms.Button()
        Me.cmdWorkRecord = New System.Windows.Forms.Button()
        Me.cmdCollectionInfo = New System.Windows.Forms.Button()
        Me.cmdTrouble = New System.Windows.Forms.Button()
        Me.cmdTreatWF = New System.Windows.Forms.Button()
        Me.cmdTreatChip = New System.Windows.Forms.Button()
        Me.optLotNextSend1 = New System.Windows.Forms.RadioButton()
        Me.optLotNextSend0 = New System.Windows.Forms.RadioButton()
        Me.cmdSelectMaterial = New System.Windows.Forms.Button()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.cmdCommntInput = New System.Windows.Forms.Button()
        Me.txtOpeCond = New SETextBoxEx.TextBoxEx()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.cmdRecipeChange = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdActionDisp = New System.Windows.Forms.Button()
        Me.txtLotCommnt = New SETextBoxEx.TextBoxEx()
        Me.txtWorkMemo = New SETextBoxEx.TextBoxEx()
        Me.vsfWp = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtUnloaderCarrier = New SETextBoxEx.TextBoxEx()
        Me.vsfLot = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtACarrierList = New SETextBoxEx.TextBoxEx()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblBack1 = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblProcessUnit = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblOvenBatchId = New System.Windows.Forms.Label()
        Me.lblALDBatchId = New System.Windows.Forms.Label()
        Me.lblTapeBatchId = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        CType(Me.vsfWp,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfLot,System.ComponentModel.ISupportInitialize).BeginInit
        Me.lblTtl8.SuspendLayout
        Me.SuspendLayout
        '
        'cmdLabelScan
        '
        Me.cmdLabelScan.Enabled = false
        Me.cmdLabelScan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLabelScan.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLabelScan.Location = New System.Drawing.Point(872, 464)
        Me.cmdLabelScan.Name = "cmdLabelScan"
        Me.cmdLabelScan.Size = New System.Drawing.Size(105, 57)
        Me.cmdLabelScan.TabIndex = 45
        Me.cmdLabelScan.Text = "現品票"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SCAN"
        '
        'cmdCommentDown
        '
        Me.cmdCommentDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentDown.Location = New System.Drawing.Point(720, 535)
        Me.cmdCommentDown.Name = "cmdCommentDown"
        Me.cmdCommentDown.Size = New System.Drawing.Size(33, 39)
        Me.cmdCommentDown.TabIndex = 42
        Me.cmdCommentDown.Text = "▼"
        '
        'cmdCommentUp
        '
        Me.cmdCommentUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommentUp.Location = New System.Drawing.Point(720, 495)
        Me.cmdCommentUp.Name = "cmdCommentUp"
        Me.cmdCommentUp.Size = New System.Drawing.Size(33, 39)
        Me.cmdCommentUp.TabIndex = 41
        Me.cmdCommentUp.Text = "▲"
        '
        'cmdMemoDown
        '
        Me.cmdMemoDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoDown.Location = New System.Drawing.Point(720, 451)
        Me.cmdMemoDown.Name = "cmdMemoDown"
        Me.cmdMemoDown.Size = New System.Drawing.Size(33, 39)
        Me.cmdMemoDown.TabIndex = 40
        Me.cmdMemoDown.Text = "▼"
        '
        'cmdMemoUp
        '
        Me.cmdMemoUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMemoUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMemoUp.Location = New System.Drawing.Point(720, 407)
        Me.cmdMemoUp.Name = "cmdMemoUp"
        Me.cmdMemoUp.Size = New System.Drawing.Size(33, 39)
        Me.cmdMemoUp.TabIndex = 39
        Me.cmdMemoUp.Text = "▲"
        '
        'cmdACarrierMoQuFdSelect
        '
        Me.cmdACarrierMoQuFdSelect.Enabled = false
        Me.cmdACarrierMoQuFdSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdACarrierMoQuFdSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdACarrierMoQuFdSelect.Location = New System.Drawing.Point(760, 400)
        Me.cmdACarrierMoQuFdSelect.Name = "cmdACarrierMoQuFdSelect"
        Me.cmdACarrierMoQuFdSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdACarrierMoQuFdSelect.TabIndex = 38
        Me.cmdACarrierMoQuFdSelect.Text = "Aキャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択(MO/QU/FD)"
        '
        'cmdACarrierSelect
        '
        Me.cmdACarrierSelect.Enabled = false
        Me.cmdACarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdACarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdACarrierSelect.Location = New System.Drawing.Point(760, 336)
        Me.cmdACarrierSelect.Name = "cmdACarrierSelect"
        Me.cmdACarrierSelect.Size = New System.Drawing.Size(105, 57)
        Me.cmdACarrierSelect.TabIndex = 37
        Me.cmdACarrierSelect.Text = "Aキャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdWorkRecord
        '
        Me.cmdWorkRecord.Enabled = false
        Me.cmdWorkRecord.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWorkRecord.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWorkRecord.Location = New System.Drawing.Point(872, 400)
        Me.cmdWorkRecord.Name = "cmdWorkRecord"
        Me.cmdWorkRecord.Size = New System.Drawing.Size(105, 57)
        Me.cmdWorkRecord.TabIndex = 36
        Me.cmdWorkRecord.Text = "作業記録"
        '
        'cmdCollectionInfo
        '
        Me.cmdCollectionInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCollectionInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCollectionInfo.Location = New System.Drawing.Point(440, 580)
        Me.cmdCollectionInfo.Name = "cmdCollectionInfo"
        Me.cmdCollectionInfo.Size = New System.Drawing.Size(105, 57)
        Me.cmdCollectionInfo.TabIndex = 35
        Me.cmdCollectionInfo.Text = "装置データ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"登録／参照"
        '
        'cmdTrouble
        '
        Me.cmdTrouble.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTrouble.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTrouble.Location = New System.Drawing.Point(548, 580)
        Me.cmdTrouble.Name = "cmdTrouble"
        Me.cmdTrouble.Size = New System.Drawing.Size(105, 57)
        Me.cmdTrouble.TabIndex = 34
        Me.cmdTrouble.Text = "異常処理"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"票起案"
        '
        'cmdTreatWF
        '
        Me.cmdTreatWF.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTreatWF.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTreatWF.Location = New System.Drawing.Point(656, 580)
        Me.cmdTreatWF.Name = "cmdTreatWF"
        Me.cmdTreatWF.Size = New System.Drawing.Size(105, 57)
        Me.cmdTreatWF.TabIndex = 33
        Me.cmdTreatWF.Text = "WF状態変更"
        '
        'cmdTreatChip
        '
        Me.cmdTreatChip.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTreatChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTreatChip.Location = New System.Drawing.Point(764, 580)
        Me.cmdTreatChip.Name = "cmdTreatChip"
        Me.cmdTreatChip.Size = New System.Drawing.Size(105, 57)
        Me.cmdTreatChip.TabIndex = 32
        Me.cmdTreatChip.Text = "チップ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"状態変更"
        '
        'optLotNextSend1
        '
        Me.optLotNextSend1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optLotNextSend1.Location = New System.Drawing.Point(872, 288)
        Me.optLotNextSend1.Name = "optLotNextSend1"
        Me.optLotNextSend1.Size = New System.Drawing.Size(91, 25)
        Me.optLotNextSend1.TabIndex = 31
        Me.optLotNextSend1.Text = "送出なし"
        '
        'optLotNextSend0
        '
        Me.optLotNextSend0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optLotNextSend0.Location = New System.Drawing.Point(872, 248)
        Me.optLotNextSend0.Name = "optLotNextSend0"
        Me.optLotNextSend0.Size = New System.Drawing.Size(91, 25)
        Me.optLotNextSend0.TabIndex = 30
        Me.optLotNextSend0.Text = "送出あり"
        '
        'cmdSelectMaterial
        '
        Me.cmdSelectMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSelectMaterial.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSelectMaterial.Location = New System.Drawing.Point(872, 336)
        Me.cmdSelectMaterial.Name = "cmdSelectMaterial"
        Me.cmdSelectMaterial.Size = New System.Drawing.Size(105, 57)
        Me.cmdSelectMaterial.TabIndex = 6
        Me.cmdSelectMaterial.Text = "使用部材"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.Enabled = false
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(867, 6)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(105, 52)
        Me.cmdCarrierSelect.TabIndex = 4
        Me.cmdCarrierSelect.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdCommntInput
        '
        Me.cmdCommntInput.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommntInput.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCommntInput.Location = New System.Drawing.Point(224, 580)
        Me.cmdCommntInput.Name = "cmdCommntInput"
        Me.cmdCommntInput.Size = New System.Drawing.Size(105, 57)
        Me.cmdCommntInput.TabIndex = 7
        Me.cmdCommntInput.Text = "ロット"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コメント"
        '
        'txtOpeCond
        '
        Me.txtOpeCond.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtOpeCond.ChrMaxByte = 128
        Me.txtOpeCond.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtOpeCond.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtOpeCond.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtOpeCond.Location = New System.Drawing.Point(8, 352)
        Me.txtOpeCond.Name = "txtOpeCond"
        Me.txtOpeCond.NgChr = "'"
        Me.txtOpeCond.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtOpeCond.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtOpeCond.SelectedText = ""
        Me.txtOpeCond.Size = New System.Drawing.Size(711, 49)
        Me.txtOpeCond.TabIndex = 9
        Me.txtOpeCond.TabStop = false
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrier.Location = New System.Drawing.Point(8, 24)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NgChr = "'"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(121, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'cmdRecipeChange
        '
        Me.cmdRecipeChange.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRecipeChange.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRecipeChange.Location = New System.Drawing.Point(332, 580)
        Me.cmdRecipeChange.Name = "cmdRecipeChange"
        Me.cmdRecipeChange.Size = New System.Drawing.Size(105, 57)
        Me.cmdRecipeChange.TabIndex = 2
        Me.cmdRecipeChange.Text = "レシピ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"設定変更"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 580)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 12
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 580)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 5
        Me.cmdRegist.Text = "確　定"
        '
        'cmdActionDisp
        '
        Me.cmdActionDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdActionDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdActionDisp.Location = New System.Drawing.Point(116, 580)
        Me.cmdActionDisp.Name = "cmdActionDisp"
        Me.cmdActionDisp.Size = New System.Drawing.Size(105, 57)
        Me.cmdActionDisp.TabIndex = 8
        Me.cmdActionDisp.Text = "アクション"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"予約確認"
        '
        'txtLotCommnt
        '
        Me.txtLotCommnt.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtLotCommnt.ChrMaxByte = 0
        Me.txtLotCommnt.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtLotCommnt.GotHighLight = false
        Me.txtLotCommnt.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotCommnt.Location = New System.Drawing.Point(8, 512)
        Me.txtLotCommnt.MultiLineEx = true
        Me.txtLotCommnt.Name = "txtLotCommnt"
        Me.txtLotCommnt.NgChr = "'"
        Me.txtLotCommnt.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotCommnt.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotCommnt.SelectedText = ""
        Me.txtLotCommnt.Size = New System.Drawing.Size(711, 61)
        Me.txtLotCommnt.TabIndex = 11
        Me.txtLotCommnt.TabStop = false
        '
        'txtWorkMemo
        '
        Me.txtWorkMemo.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtWorkMemo.ChrMaxByte = 0
        Me.txtWorkMemo.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtWorkMemo.GotHighLight = false
        Me.txtWorkMemo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtWorkMemo.Location = New System.Drawing.Point(8, 424)
        Me.txtWorkMemo.MultiLineEx = true
        Me.txtWorkMemo.Name = "txtWorkMemo"
        Me.txtWorkMemo.NgChr = "'"
        Me.txtWorkMemo.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkMemo.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkMemo.SelectedText = ""
        Me.txtWorkMemo.Size = New System.Drawing.Size(711, 65)
        Me.txtWorkMemo.TabIndex = 10
        '
        'vsfWp
        '
        Me.vsfWp.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfWp.AllowEditing = false
        Me.vsfWp.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfWp.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfWp.AutoResize = true
        Me.vsfWp.AutoSearchDelay = 2R
        Me.vsfWp.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfWp.ColumnInfo = "10,1,0,0,0,110,Columns:"
        Me.vsfWp.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfWp.ExtendLastCol = true
        Me.vsfWp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfWp.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfWp.Location = New System.Drawing.Point(8, 216)
        Me.vsfWp.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfWp.Name = "vsfWp"
        Me.vsfWp.Rows.DefaultSize = 18
        Me.vsfWp.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfWp.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfWp.Size = New System.Drawing.Size(711, 111)
        Me.vsfWp.StyleInfo = resources.GetString("vsfWp.StyleInfo")
        Me.vsfWp.TabIndex = 1
        '
        'txtUnloaderCarrier
        '
        Me.txtUnloaderCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtUnloaderCarrier.ChrMaxByte = 6
        Me.txtUnloaderCarrier.Enabled = false
        Me.txtUnloaderCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtUnloaderCarrier.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtUnloaderCarrier.Location = New System.Drawing.Point(738, 24)
        Me.txtUnloaderCarrier.Name = "txtUnloaderCarrier"
        Me.txtUnloaderCarrier.NgChr = "'"
        Me.txtUnloaderCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtUnloaderCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUnloaderCarrier.SelectedText = ""
        Me.txtUnloaderCarrier.Size = New System.Drawing.Size(121, 30)
        Me.txtUnloaderCarrier.TabIndex = 3
        '
        'vsfLot
        '
        Me.vsfLot.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLot.AllowEditing = false
        Me.vsfLot.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLot.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLot.AutoResize = true
        Me.vsfLot.AutoSearchDelay = 2R
        Me.vsfLot.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLot.ColumnInfo = resources.GetString("vsfLot.ColumnInfo")
        Me.vsfLot.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLot.ExtendLastCol = true
        Me.vsfLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLot.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLot.Location = New System.Drawing.Point(8, 64)
        Me.vsfLot.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLot.Name = "vsfLot"
        Me.vsfLot.Rows.DefaultSize = 18
        Me.vsfLot.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLot.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLot.Size = New System.Drawing.Size(967, 143)
        Me.vsfLot.StyleInfo = resources.GetString("vsfLot.StyleInfo")
        Me.vsfLot.TabIndex = 22
        '
        'txtACarrierList
        '
        Me.txtACarrierList.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtACarrierList.ChrMaxByte = 0
        Me.txtACarrierList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtACarrierList.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtACarrierList.GotHighLight = false
        Me.txtACarrierList.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtACarrierList.Location = New System.Drawing.Point(728, 232)
        Me.txtACarrierList.MultiLineEx = true
        Me.txtACarrierList.Name = "txtACarrierList"
        Me.txtACarrierList.NgChr = "'"
        Me.txtACarrierList.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtACarrierList.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtACarrierList.SelectedText = ""
        Me.txtACarrierList.Size = New System.Drawing.Size(121, 95)
        Me.txtACarrierList.TabIndex = 43
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(728, 216)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(121, 17)
        Me.lblTtl10.TabIndex = 44
        Me.lblTtl10.Text = "Aキャリア"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack1
        '
        Me.lblBack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack1.Location = New System.Drawing.Point(856, 232)
        Me.lblBack1.Name = "lblBack1"
        Me.lblBack1.Size = New System.Drawing.Size(121, 96)
        Me.lblBack1.TabIndex = 29
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(856, 216)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(121, 17)
        Me.lblTtl7.TabIndex = 28
        Me.lblTtl7.Text = "次工程"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(543, 8)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(147, 17)
        Me.lblTtl4.TabIndex = 27
        Me.lblTtl4.Text = "ALDバッチID"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(393, 8)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(147, 17)
        Me.lblTtl3.TabIndex = 26
        Me.lblTtl3.Text = "オーブンバッチID"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(243, 8)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(147, 17)
        Me.lblTtl2.TabIndex = 25
        Me.lblTtl2.Text = "テープバッチID"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblProcessUnit
        '
        Me.lblProcessUnit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProcessUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProcessUnit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblProcessUnit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProcessUnit.Location = New System.Drawing.Point(135, 24)
        Me.lblProcessUnit.Name = "lblProcessUnit"
        Me.lblProcessUnit.Size = New System.Drawing.Size(106, 30)
        Me.lblProcessUnit.TabIndex = 24
        Me.lblProcessUnit.Text = "aaaaaaaa"
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(135, 8)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(106, 17)
        Me.lblTtl1.TabIndex = 23
        Me.lblTtl1.Text = "装置処理単位"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(738, 9)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(121, 17)
        Me.lblTtl6.TabIndex = 21
        Me.lblTtl6.Text = "ULキャリアID"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOvenBatchId
        '
        Me.lblOvenBatchId.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOvenBatchId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOvenBatchId.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOvenBatchId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOvenBatchId.Location = New System.Drawing.Point(393, 24)
        Me.lblOvenBatchId.Name = "lblOvenBatchId"
        Me.lblOvenBatchId.Size = New System.Drawing.Size(147, 30)
        Me.lblOvenBatchId.TabIndex = 20
        Me.lblOvenBatchId.Text = "aaaaaa"
        '
        'lblALDBatchId
        '
        Me.lblALDBatchId.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblALDBatchId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblALDBatchId.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblALDBatchId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblALDBatchId.Location = New System.Drawing.Point(543, 24)
        Me.lblALDBatchId.Name = "lblALDBatchId"
        Me.lblALDBatchId.Size = New System.Drawing.Size(146, 30)
        Me.lblALDBatchId.TabIndex = 19
        Me.lblALDBatchId.Text = "aaaaaaa"
        '
        'lblTapeBatchId
        '
        Me.lblTapeBatchId.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTapeBatchId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTapeBatchId.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTapeBatchId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTapeBatchId.Location = New System.Drawing.Point(243, 24)
        Me.lblTapeBatchId.Name = "lblTapeBatchId"
        Me.lblTapeBatchId.Size = New System.Drawing.Size(147, 30)
        Me.lblTapeBatchId.TabIndex = 18
        Me.lblTapeBatchId.Text = "aaaaaaa"
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(456, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 17)
        Me.lblLengthCount.TabIndex = 16
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(8, 496)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(711, 17)
        Me.lblTtl9.TabIndex = 15
        Me.lblTtl9.Text = "      コメント"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 8)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(121, 17)
        Me.lblTtl0.TabIndex = 14
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(8, 336)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(711, 17)
        Me.lblTtl5.TabIndex = 13
        Me.lblTtl5.Text = "      作業条件"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Controls.Add(Me.lblLengthCount)
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(8, 408)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(711, 17)
        Me.lblTtl8.TabIndex = 17
        Me.lblTtl8.Text = "      作業メモ"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02Q0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdLabelScan)
        Me.Controls.Add(Me.cmdCommentDown)
        Me.Controls.Add(Me.cmdCommentUp)
        Me.Controls.Add(Me.cmdMemoDown)
        Me.Controls.Add(Me.cmdMemoUp)
        Me.Controls.Add(Me.cmdACarrierMoQuFdSelect)
        Me.Controls.Add(Me.cmdACarrierSelect)
        Me.Controls.Add(Me.cmdWorkRecord)
        Me.Controls.Add(Me.cmdCollectionInfo)
        Me.Controls.Add(Me.cmdTrouble)
        Me.Controls.Add(Me.cmdTreatWF)
        Me.Controls.Add(Me.cmdTreatChip)
        Me.Controls.Add(Me.optLotNextSend1)
        Me.Controls.Add(Me.optLotNextSend0)
        Me.Controls.Add(Me.cmdSelectMaterial)
        Me.Controls.Add(Me.cmdCarrierSelect)
        Me.Controls.Add(Me.cmdCommntInput)
        Me.Controls.Add(Me.txtOpeCond)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.cmdRecipeChange)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdActionDisp)
        Me.Controls.Add(Me.txtLotCommnt)
        Me.Controls.Add(Me.txtWorkMemo)
        Me.Controls.Add(Me.vsfWp)
        Me.Controls.Add(Me.txtUnloaderCarrier)
        Me.Controls.Add(Me.vsfLot)
        Me.Controls.Add(Me.txtACarrierList)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblBack1)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblProcessUnit)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblOvenBatchId)
        Me.Controls.Add(Me.lblALDBatchId)
        Me.Controls.Add(Me.lblTapeBatchId)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblTtl8)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02Q0"
        Me.Text = "防湿ALDロット流動"
        CType(Me.vsfWp,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfLot,System.ComponentModel.ISupportInitialize).EndInit
        Me.lblTtl8.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdLabelScan As Button
    Friend WithEvents cmdCommentDown As Button
    Friend WithEvents cmdCommentUp As Button
    Friend WithEvents cmdMemoDown As Button
    Friend WithEvents cmdMemoUp As Button
    Friend WithEvents cmdACarrierMoQuFdSelect As Button
    Friend WithEvents cmdACarrierSelect As Button
    Friend WithEvents cmdWorkRecord As Button
    Friend WithEvents cmdCollectionInfo As Button
    Friend WithEvents cmdTrouble As Button
    Friend WithEvents cmdTreatWF As Button
    Friend WithEvents cmdTreatChip As Button
    Friend WithEvents optLotNextSend1 As RadioButton
    Friend WithEvents optLotNextSend0 As RadioButton
    Friend WithEvents cmdSelectMaterial As Button
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents cmdCommntInput As Button
    Friend WithEvents txtOpeCond As SETextBoxEx.TextBoxEx
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents cmdRecipeChange As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdActionDisp As Button
    Friend WithEvents txtLotCommnt As SETextBoxEx.TextBoxEx
    Friend WithEvents txtWorkMemo As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfWp As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtUnloaderCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfLot As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtACarrierList As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblBack1 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblProcessUnit As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblOvenBatchId As Label
    Friend WithEvents lblALDBatchId As Label
    Friend WithEvents lblTapeBatchId As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl8 As Label
End Class
