<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01V0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01V0))
        Me.cmdHoldMain = New System.Windows.Forms.Button()
        Me.cmdHoldCancel = New System.Windows.Forms.Button()
        Me.cmdHold = New System.Windows.Forms.Button()
        Me.cmdUseWPMain = New System.Windows.Forms.Button()
        Me.cmdUseWP = New System.Windows.Forms.Button()
        Me.cmdMaterialDateChg = New System.Windows.Forms.Button()
        Me.cmdUseWPCancel = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdOrder = New System.Windows.Forms.Button()
        Me.cmdScrap = New System.Windows.Forms.Button()
        Me.cmdDivide = New System.Windows.Forms.Button()
        Me.cmdStartUse = New System.Windows.Forms.Button()
        Me.cmdAccept = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfMaterialList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbMaterialType = New SEComboBoxEx.ComboBoxEx()
        Me.cmbMaterial = New SEComboBoxEx.ComboBoxEx()
        Me.cmbWP = New SEComboBoxEx.ComboBoxEx()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.lblHold = New System.Windows.Forms.Label()
        Me.lblStockNum = New System.Windows.Forms.Label()
        Me.lblOrderNum = New System.Windows.Forms.Label()
        Me.lblTitle9 = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblOrderMaterial = New System.Windows.Forms.Label()
        Me.lblOrderRemeinNum = New System.Windows.Forms.Label()
        Me.lblMessageTitle = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblDisabled = New System.Windows.Forms.Label()
        Me.lblCannotUse = New System.Windows.Forms.Label()
        Me.lblWarningPeriod = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblTime3 = New System.Windows.Forms.Label()
        Me.lblDay1 = New System.Windows.Forms.Label()
        Me.lblTime1 = New System.Windows.Forms.Label()
        Me.lblDay2 = New System.Windows.Forms.Label()
        Me.lblTime2 = New System.Windows.Forms.Label()
        Me.lblVenderWarrantDays = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblUseValidPeriod = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblAcceptWarrantDays = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblUseInvalidPeriod = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblMaterialCnt = New System.Windows.Forms.Label()
        Me.cmdInvalid = New System.Windows.Forms.Button()
        CType(Me.vsfMaterialList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdHoldMain
        '
        Me.cmdHoldMain.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldMain.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHoldMain.Location = New System.Drawing.Point(498, 581)
        Me.cmdHoldMain.Name = "cmdHoldMain"
        Me.cmdHoldMain.Size = New System.Drawing.Size(95, 57)
        Me.cmdHoldMain.TabIndex = 54
        Me.cmdHoldMain.Text = "保留/"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"保留解除"
        '
        'cmdHoldCancel
        '
        Me.cmdHoldCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHoldCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHoldCancel.Location = New System.Drawing.Point(498, 581)
        Me.cmdHoldCancel.Name = "cmdHoldCancel"
        Me.cmdHoldCancel.Size = New System.Drawing.Size(95, 57)
        Me.cmdHoldCancel.TabIndex = 57
        Me.cmdHoldCancel.Text = "保留解除"
        '
        'cmdHold
        '
        Me.cmdHold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdHold.Location = New System.Drawing.Point(498, 581)
        Me.cmdHold.Name = "cmdHold"
        Me.cmdHold.Size = New System.Drawing.Size(95, 57)
        Me.cmdHold.TabIndex = 56
        Me.cmdHold.Text = "保　留"
        '
        'cmdUseWPMain
        '
        Me.cmdUseWPMain.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUseWPMain.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUseWPMain.Location = New System.Drawing.Point(593, 581)
        Me.cmdUseWPMain.Name = "cmdUseWPMain"
        Me.cmdUseWPMain.Size = New System.Drawing.Size(95, 57)
        Me.cmdUseWPMain.TabIndex = 55
        Me.cmdUseWPMain.Text = "装置使用"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"開始/解除"
        '
        'cmdUseWP
        '
        Me.cmdUseWP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUseWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUseWP.Location = New System.Drawing.Point(593, 581)
        Me.cmdUseWP.Name = "cmdUseWP"
        Me.cmdUseWP.Size = New System.Drawing.Size(95, 57)
        Me.cmdUseWP.TabIndex = 11
        Me.cmdUseWP.Text = "装置使用"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"開始"
        '
        'cmdMaterialDateChg
        '
        Me.cmdMaterialDateChg.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMaterialDateChg.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMaterialDateChg.Location = New System.Drawing.Point(114, 581)
        Me.cmdMaterialDateChg.Name = "cmdMaterialDateChg"
        Me.cmdMaterialDateChg.Size = New System.Drawing.Size(95, 57)
        Me.cmdMaterialDateChg.TabIndex = 15
        Me.cmdMaterialDateChg.Text = "部材日時"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"変更"
        '
        'cmdUseWPCancel
        '
        Me.cmdUseWPCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUseWPCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUseWPCancel.Location = New System.Drawing.Point(593, 581)
        Me.cmdUseWPCancel.Name = "cmdUseWPCancel"
        Me.cmdUseWPCancel.Size = New System.Drawing.Size(95, 57)
        Me.cmdUseWPCancel.TabIndex = 12
        Me.cmdUseWPCancel.Text = "装置使用"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"解除"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(921, 364)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 167)
        Me.cmdDown.TabIndex = 5
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(921, 193)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 167)
        Me.cmdUP.TabIndex = 4
        Me.cmdUP.Text = "▲"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(466, 532)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(456, 49)
        Me.cmdRight.TabIndex = 7
        Me.cmdRight.Text = ">>"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 532)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(456, 49)
        Me.cmdLeft.TabIndex = 6
        Me.cmdLeft.Text = "<<"
        '
        'cmdOrder
        '
        Me.cmdOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdOrder.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdOrder.Location = New System.Drawing.Point(881, 581)
        Me.cmdOrder.Name = "cmdOrder"
        Me.cmdOrder.Size = New System.Drawing.Size(95, 57)
        Me.cmdOrder.TabIndex = 8
        Me.cmdOrder.Text = "発　注"
        '
        'cmdScrap
        '
        Me.cmdScrap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScrap.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScrap.Location = New System.Drawing.Point(306, 581)
        Me.cmdScrap.Name = "cmdScrap"
        Me.cmdScrap.Size = New System.Drawing.Size(95, 57)
        Me.cmdScrap.TabIndex = 14
        Me.cmdScrap.Text = "廃　棄"
        '
        'cmdDivide
        '
        Me.cmdDivide.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDivide.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDivide.Location = New System.Drawing.Point(402, 581)
        Me.cmdDivide.Name = "cmdDivide"
        Me.cmdDivide.Size = New System.Drawing.Size(95, 57)
        Me.cmdDivide.TabIndex = 13
        Me.cmdDivide.Text = "分　割"
        '
        'cmdStartUse
        '
        Me.cmdStartUse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdStartUse.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdStartUse.Location = New System.Drawing.Point(689, 581)
        Me.cmdStartUse.Name = "cmdStartUse"
        Me.cmdStartUse.Size = New System.Drawing.Size(95, 57)
        Me.cmdStartUse.TabIndex = 10
        Me.cmdStartUse.Text = "使用開始"
        '
        'cmdAccept
        '
        Me.cmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAccept.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAccept.Location = New System.Drawing.Point(785, 581)
        Me.cmdAccept.Name = "cmdAccept"
        Me.cmdAccept.Size = New System.Drawing.Size(95, 57)
        Me.cmdAccept.TabIndex = 9
        Me.cmdAccept.Text = "受　入"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(630, 5)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowList.TabIndex = 18
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 581)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 17
        Me.cmdClose.Text = "閉じる"
        '
        'vsfMaterialList
        '
        Me.vsfMaterialList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMaterialList.AllowEditing = false
        Me.vsfMaterialList.AutoSearchDelay = 2R
        Me.vsfMaterialList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMaterialList.ColumnInfo = resources.GetString("vsfMaterialList.ColumnInfo")
        Me.vsfMaterialList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMaterialList.ExtendLastCol = true
        Me.vsfMaterialList.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMaterialList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMaterialList.Location = New System.Drawing.Point(8, 194)
        Me.vsfMaterialList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMaterialList.Name = "vsfMaterialList"
        Me.vsfMaterialList.Rows.Count = 30
        Me.vsfMaterialList.Rows.DefaultSize = 18
        Me.vsfMaterialList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMaterialList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMaterialList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMaterialList.Size = New System.Drawing.Size(913, 338)
        Me.vsfMaterialList.StyleInfo = resources.GetString("vsfMaterialList.StyleInfo")
        Me.vsfMaterialList.TabIndex = 3
        '
        'cmbMaterialType
        '
        Me.cmbMaterialType.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMaterialType.ForeColor = System.Drawing.Color.Black
        Me.cmbMaterialType.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMaterialType.GridForeColor = System.Drawing.Color.Black
        Me.cmbMaterialType.Location = New System.Drawing.Point(8, 23)
        Me.cmbMaterialType.Name = "cmbMaterialType"
        Me.cmbMaterialType.Size = New System.Drawing.Size(180, 28)
        Me.cmbMaterialType.TabIndex = 0
        Me.cmbMaterialType.Value = Nothing
        '
        'cmbMaterial
        '
        Me.cmbMaterial.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMaterial.ForeColor = System.Drawing.Color.Black
        Me.cmbMaterial.GetCol = 2
        Me.cmbMaterial.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMaterial.GridForeColor = System.Drawing.Color.Black
        Me.cmbMaterial.Location = New System.Drawing.Point(187, 23)
        Me.cmbMaterial.Name = "cmbMaterial"
        Me.cmbMaterial.Size = New System.Drawing.Size(436, 28)
        Me.cmbMaterial.TabIndex = 1
        Me.cmbMaterial.Value = Nothing
        '
        'cmbWP
        '
        Me.cmbWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWP.ForeColor = System.Drawing.Color.Black
        Me.cmbWP.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWP.GridForeColor = System.Drawing.Color.Black
        Me.cmbWP.Location = New System.Drawing.Point(8, 82)
        Me.cmbWP.Name = "cmbWP"
        Me.cmbWP.Size = New System.Drawing.Size(343, 28)
        Me.cmbWP.TabIndex = 2
        Me.cmbWP.Value = Nothing
        Me.cmbWP.ValueCol = 1
        '
        'cmdCopy
        '
        Me.cmdCopy.Enabled = false
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(210, 581)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(95, 57)
        Me.cmdCopy.TabIndex = 16
        Me.cmdCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        Me.cmdCopy.Visible = false
        '
        'lblHold
        '
        Me.lblHold.BackColor = System.Drawing.Color.Red
        Me.lblHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblHold.ForeColor = System.Drawing.Color.Black
        Me.lblHold.Location = New System.Drawing.Point(446, 173)
        Me.lblHold.Name = "lblHold"
        Me.lblHold.Size = New System.Drawing.Size(106, 18)
        Me.lblHold.TabIndex = 53
        Me.lblHold.Text = "保留"
        Me.lblHold.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStockNum
        '
        Me.lblStockNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStockNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStockNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStockNum.ForeColor = System.Drawing.Color.Red
        Me.lblStockNum.Location = New System.Drawing.Point(8, 139)
        Me.lblStockNum.Name = "lblStockNum"
        Me.lblStockNum.Size = New System.Drawing.Size(97, 30)
        Me.lblStockNum.TabIndex = 52
        Me.lblStockNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblOrderNum
        '
        Me.lblOrderNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOrderNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOrderNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOrderNum.Location = New System.Drawing.Point(104, 139)
        Me.lblOrderNum.Name = "lblOrderNum"
        Me.lblOrderNum.Size = New System.Drawing.Size(97, 30)
        Me.lblOrderNum.TabIndex = 51
        Me.lblOrderNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle9
        '
        Me.lblTitle9.BackColor = System.Drawing.Color.Navy
        Me.lblTitle9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle9.Location = New System.Drawing.Point(200, 123)
        Me.lblTitle9.Name = "lblTitle9"
        Me.lblTitle9.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle9.TabIndex = 50
        Me.lblTitle9.Text = "発注ﾎﾟｲﾝﾄ"
        Me.lblTitle9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(104, 123)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle8.TabIndex = 49
        Me.lblTitle8.Text = "発注済"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWarning
        '
        Me.lblWarning.AutoSize = true
        Me.lblWarning.BackColor = System.Drawing.Color.Yellow
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWarning.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Black
        Me.lblWarning.Location = New System.Drawing.Point(656, 173)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(106, 18)
        Me.lblWarning.TabIndex = 48
        Me.lblWarning.Text = "制約期限警告"
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOrderMaterial
        '
        Me.lblOrderMaterial.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblOrderMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderMaterial.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOrderMaterial.ForeColor = System.Drawing.Color.Black
        Me.lblOrderMaterial.Location = New System.Drawing.Point(551, 173)
        Me.lblOrderMaterial.Name = "lblOrderMaterial"
        Me.lblOrderMaterial.Size = New System.Drawing.Size(106, 18)
        Me.lblOrderMaterial.TabIndex = 47
        Me.lblOrderMaterial.Text = "発注済部材"
        Me.lblOrderMaterial.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOrderRemeinNum
        '
        Me.lblOrderRemeinNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOrderRemeinNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderRemeinNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOrderRemeinNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOrderRemeinNum.Location = New System.Drawing.Point(200, 139)
        Me.lblOrderRemeinNum.Name = "lblOrderRemeinNum"
        Me.lblOrderRemeinNum.Size = New System.Drawing.Size(97, 30)
        Me.lblOrderRemeinNum.TabIndex = 46
        Me.lblOrderRemeinNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMessageTitle
        '
        Me.lblMessageTitle.BackColor = System.Drawing.Color.Navy
        Me.lblMessageTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMessageTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMessageTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblMessageTitle.Location = New System.Drawing.Point(295, 123)
        Me.lblMessageTitle.Name = "lblMessageTitle"
        Me.lblMessageTitle.Size = New System.Drawing.Size(674, 17)
        Me.lblMessageTitle.TabIndex = 45
        Me.lblMessageTitle.Text = "メッセージ"
        Me.lblMessageTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(8, 123)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle7.TabIndex = 44
        Me.lblTitle7.Text = "未使用部材"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMessage.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(295, 139)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(674, 30)
        Me.lblMessage.TabIndex = 43
        '
        'lblDisabled
        '
        Me.lblDisabled.AutoSize = true
        Me.lblDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblDisabled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisabled.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDisabled.ForeColor = System.Drawing.Color.Black
        Me.lblDisabled.Location = New System.Drawing.Point(760, 173)
        Me.lblDisabled.Name = "lblDisabled"
        Me.lblDisabled.Size = New System.Drawing.Size(106, 18)
        Me.lblDisabled.TabIndex = 42
        Me.lblDisabled.Text = "制約期限超過"
        Me.lblDisabled.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCannotUse
        '
        Me.lblCannotUse.AutoSize = true
        Me.lblCannotUse.BackColor = System.Drawing.Color.Silver
        Me.lblCannotUse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCannotUse.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCannotUse.ForeColor = System.Drawing.Color.Black
        Me.lblCannotUse.Location = New System.Drawing.Point(864, 173)
        Me.lblCannotUse.Name = "lblCannotUse"
        Me.lblCannotUse.Size = New System.Drawing.Size(106, 18)
        Me.lblCannotUse.TabIndex = 41
        Me.lblCannotUse.Text = "使用禁止状態"
        Me.lblCannotUse.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWarningPeriod
        '
        Me.lblWarningPeriod.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWarningPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWarningPeriod.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWarningPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWarningPeriod.Location = New System.Drawing.Point(842, 81)
        Me.lblWarningPeriod.Name = "lblWarningPeriod"
        Me.lblWarningPeriod.Size = New System.Drawing.Size(79, 30)
        Me.lblWarningPeriod.TabIndex = 40
        Me.lblWarningPeriod.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(842, 65)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(126, 17)
        Me.lblTitle6.TabIndex = 39
        Me.lblTitle6.Text = "ﾜｰﾆﾝｸﾞ時間"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTime3
        '
        Me.lblTime3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTime3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTime3.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTime3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTime3.Location = New System.Drawing.Point(917, 81)
        Me.lblTime3.Name = "lblTime3"
        Me.lblTime3.Size = New System.Drawing.Size(51, 30)
        Me.lblTime3.TabIndex = 38
        Me.lblTime3.Text = "時間"
        Me.lblTime3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDay1
        '
        Me.lblDay1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDay1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDay1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay1.Location = New System.Drawing.Point(430, 81)
        Me.lblDay1.Name = "lblDay1"
        Me.lblDay1.Size = New System.Drawing.Size(51, 30)
        Me.lblDay1.TabIndex = 37
        Me.lblDay1.Text = "日"
        Me.lblDay1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTime1
        '
        Me.lblTime1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTime1.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTime1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTime1.Location = New System.Drawing.Point(673, 81)
        Me.lblTime1.Name = "lblTime1"
        Me.lblTime1.Size = New System.Drawing.Size(51, 30)
        Me.lblTime1.TabIndex = 36
        Me.lblTime1.Text = "時間"
        Me.lblTime1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDay2
        '
        Me.lblDay2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblDay2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDay2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDay2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDay2.Location = New System.Drawing.Point(549, 81)
        Me.lblDay2.Name = "lblDay2"
        Me.lblDay2.Size = New System.Drawing.Size(51, 30)
        Me.lblDay2.TabIndex = 35
        Me.lblDay2.Text = "日"
        Me.lblDay2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTime2
        '
        Me.lblTime2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTime2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTime2.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTime2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTime2.Location = New System.Drawing.Point(794, 81)
        Me.lblTime2.Name = "lblTime2"
        Me.lblTime2.Size = New System.Drawing.Size(51, 30)
        Me.lblTime2.TabIndex = 34
        Me.lblTime2.Text = "時間"
        Me.lblTime2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblVenderWarrantDays
        '
        Me.lblVenderWarrantDays.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblVenderWarrantDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVenderWarrantDays.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblVenderWarrantDays.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVenderWarrantDays.Location = New System.Drawing.Point(354, 81)
        Me.lblVenderWarrantDays.Name = "lblVenderWarrantDays"
        Me.lblVenderWarrantDays.Size = New System.Drawing.Size(79, 30)
        Me.lblVenderWarrantDays.TabIndex = 33
        Me.lblVenderWarrantDays.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(354, 65)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(123, 17)
        Me.lblTitle5.TabIndex = 32
        Me.lblTitle5.Text = "ﾒｰｶｰ保証期間"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblUseValidPeriod
        '
        Me.lblUseValidPeriod.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblUseValidPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUseValidPeriod.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUseValidPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUseValidPeriod.Location = New System.Drawing.Point(599, 81)
        Me.lblUseValidPeriod.Name = "lblUseValidPeriod"
        Me.lblUseValidPeriod.Size = New System.Drawing.Size(79, 30)
        Me.lblUseValidPeriod.TabIndex = 31
        Me.lblUseValidPeriod.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(598, 65)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(123, 17)
        Me.lblTitle4.TabIndex = 30
        Me.lblTitle4.Text = "使用可能時間"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAcceptWarrantDays
        '
        Me.lblAcceptWarrantDays.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblAcceptWarrantDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAcceptWarrantDays.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblAcceptWarrantDays.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAcceptWarrantDays.Location = New System.Drawing.Point(476, 81)
        Me.lblAcceptWarrantDays.Name = "lblAcceptWarrantDays"
        Me.lblAcceptWarrantDays.Size = New System.Drawing.Size(80, 30)
        Me.lblAcceptWarrantDays.TabIndex = 29
        Me.lblAcceptWarrantDays.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(476, 65)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(123, 17)
        Me.lblTitle2.TabIndex = 28
        Me.lblTitle2.Text = "受入制限期間"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(8, 66)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(343, 17)
        Me.lblTtl2.TabIndex = 27
        Me.lblTtl2.Text = "使用装置"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(720, 65)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(123, 17)
        Me.lblTitle0.TabIndex = 26
        Me.lblTitle0.Text = "使用禁止時間"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblUseInvalidPeriod
        '
        Me.lblUseInvalidPeriod.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblUseInvalidPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUseInvalidPeriod.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUseInvalidPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUseInvalidPeriod.Location = New System.Drawing.Point(720, 81)
        Me.lblUseInvalidPeriod.Name = "lblUseInvalidPeriod"
        Me.lblUseInvalidPeriod.Size = New System.Drawing.Size(79, 30)
        Me.lblUseInvalidPeriod.TabIndex = 25
        Me.lblUseInvalidPeriod.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(740, 22)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 30)
        Me.lblNowDate.TabIndex = 24
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(740, 6)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle1.TabIndex = 23
        Me.lblTitle1.Text = "情報取得日時"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(8, 7)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(180, 17)
        Me.lblTtl1.TabIndex = 22
        Me.lblTtl1.Text = "部材種別"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(187, 7)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(436, 17)
        Me.lblTtl0.TabIndex = 21
        Me.lblTtl0.Text = "部材"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(895, 6)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle3.TabIndex = 20
        Me.lblTitle3.Text = "該当件数"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMaterialCnt
        '
        Me.lblMaterialCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblMaterialCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMaterialCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblMaterialCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMaterialCnt.Location = New System.Drawing.Point(895, 22)
        Me.lblMaterialCnt.Name = "lblMaterialCnt"
        Me.lblMaterialCnt.Size = New System.Drawing.Size(74, 30)
        Me.lblMaterialCnt.TabIndex = 19
        Me.lblMaterialCnt.Text = "0"
        Me.lblMaterialCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdInvalid
        '
        Me.cmdInvalid.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdInvalid.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdInvalid.Location = New System.Drawing.Point(210, 581)
        Me.cmdInvalid.Name = "cmdInvalid"
        Me.cmdInvalid.Size = New System.Drawing.Size(95, 57)
        Me.cmdInvalid.TabIndex = 58
        Me.cmdInvalid.Text = "無　効"
        '
        'frmxxEN01V0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdInvalid)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdOrder)
        Me.Controls.Add(Me.cmdStartUse)
        Me.Controls.Add(Me.cmdAccept)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfMaterialList)
        Me.Controls.Add(Me.cmbMaterialType)
        Me.Controls.Add(Me.cmbMaterial)
        Me.Controls.Add(Me.cmbWP)
        Me.Controls.Add(Me.lblHold)
        Me.Controls.Add(Me.lblStockNum)
        Me.Controls.Add(Me.lblOrderNum)
        Me.Controls.Add(Me.lblTitle9)
        Me.Controls.Add(Me.lblTitle8)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.lblOrderMaterial)
        Me.Controls.Add(Me.lblOrderRemeinNum)
        Me.Controls.Add(Me.lblMessageTitle)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblDisabled)
        Me.Controls.Add(Me.lblCannotUse)
        Me.Controls.Add(Me.lblWarningPeriod)
        Me.Controls.Add(Me.lblTitle6)
        Me.Controls.Add(Me.lblTime3)
        Me.Controls.Add(Me.lblVenderWarrantDays)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblUseValidPeriod)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblAcceptWarrantDays)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblUseInvalidPeriod)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblMaterialCnt)
        Me.Controls.Add(Me.cmdHoldCancel)
        Me.Controls.Add(Me.cmdScrap)
        Me.Controls.Add(Me.lblTime2)
        Me.Controls.Add(Me.lblTime1)
        Me.Controls.Add(Me.lblDay1)
        Me.Controls.Add(Me.lblDay2)
        Me.Controls.Add(Me.cmdUseWPMain)
        Me.Controls.Add(Me.cmdUseWP)
        Me.Controls.Add(Me.cmdUseWPCancel)
        Me.Controls.Add(Me.cmdHold)
        Me.Controls.Add(Me.cmdHoldMain)
        Me.Controls.Add(Me.cmdDivide)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdMaterialDateChg)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01V0"
        Me.Text = "装置使用部材管理"
        CType(Me.vsfMaterialList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmdHoldMain As Button
    Friend WithEvents cmdHoldCancel As Button
    Friend WithEvents cmdHold As Button
    Friend WithEvents cmdUseWPMain As Button
    Friend WithEvents cmdUseWP As Button
    Friend WithEvents cmdMaterialDateChg As Button
    Friend WithEvents cmdUseWPCancel As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdOrder As Button
    Friend WithEvents cmdScrap As Button
    Friend WithEvents cmdDivide As Button
    Friend WithEvents cmdStartUse As Button
    Friend WithEvents cmdAccept As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfMaterialList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbMaterialType As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbMaterial As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbWP As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmdCopy As Button
    Friend WithEvents lblHold As Label
    Friend WithEvents lblStockNum As Label
    Friend WithEvents lblOrderNum As Label
    Friend WithEvents lblTitle9 As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblWarning As Label
    Friend WithEvents lblOrderMaterial As Label
    Friend WithEvents lblOrderRemeinNum As Label
    Friend WithEvents lblMessageTitle As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents lblDisabled As Label
    Friend WithEvents lblCannotUse As Label
    Friend WithEvents lblWarningPeriod As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTime3 As Label
    Friend WithEvents lblDay1 As Label
    Friend WithEvents lblTime1 As Label
    Friend WithEvents lblDay2 As Label
    Friend WithEvents lblTime2 As Label
    Friend WithEvents lblVenderWarrantDays As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblUseValidPeriod As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblAcceptWarrantDays As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblUseInvalidPeriod As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblMaterialCnt As Label
    Friend WithEvents cmdInvalid As Button
End Class
