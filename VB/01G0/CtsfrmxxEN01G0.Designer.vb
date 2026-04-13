<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01G0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01G0))
        Me.cmdLotComment = New System.Windows.Forms.Button()
        Me.cmdWPRecipeList = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdLotSearch = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtCarrierID = New SETextBoxEx.TextBoxEx()
        Me.txtLotID = New SETextBoxEx.TextBoxEx()
        Me.vsfLotDetailList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblPD = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblHold = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        CType(Me.vsfLotDetailList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdLotComment
        '
        Me.cmdLotComment.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotComment.Location = New System.Drawing.Point(656, 579)
        Me.cmdLotComment.Name = "cmdLotComment"
        Me.cmdLotComment.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotComment.TabIndex = 7
        Me.cmdLotComment.Text = "ﾛｯﾄｺﾒﾝﾄ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"履歴"
        '
        'cmdWPRecipeList
        '
        Me.cmdWPRecipeList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWPRecipeList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdWPRecipeList.Location = New System.Drawing.Point(764, 579)
        Me.cmdWPRecipeList.Name = "cmdWPRecipeList"
        Me.cmdWPRecipeList.Size = New System.Drawing.Size(105, 57)
        Me.cmdWPRecipeList.TabIndex = 8
        Me.cmdWPRecipeList.Text = "装置レシピ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(467, 526)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(459, 49)
        Me.cmdRight.TabIndex = 6
        Me.cmdRight.Text = ">>"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 526)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(459, 49)
        Me.cmdLeft.TabIndex = 5
        Me.cmdLeft.Text = "<<"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(925, 315)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 212)
        Me.cmdDown.TabIndex = 4
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(925, 103)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 212)
        Me.cmdUP.TabIndex = 3
        Me.cmdUP.Text = "▲"
        '
        'cmdLotSearch
        '
        Me.cmdLotSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotSearch.Location = New System.Drawing.Point(715, 7)
        Me.cmdLotSearch.Name = "cmdLotSearch"
        Me.cmdLotSearch.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotSearch.TabIndex = 9
        Me.cmdLotSearch.Text = "最新取得"
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
        'txtCarrierID
        '
        Me.txtCarrierID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID.ChrMaxByte = 6
        Me.txtCarrierID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID.Location = New System.Drawing.Point(8, 24)
        Me.txtCarrierID.Name = "txtCarrierID"
        Me.txtCarrierID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID.SelectedText = ""
        Me.txtCarrierID.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrierID.TabIndex = 0
        '
        'txtLotID
        '
        Me.txtLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtLotID.ChrMaxByte = 10
        Me.txtLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtLotID.Location = New System.Drawing.Point(8, 72)
        Me.txtLotID.Name = "txtLotID"
        Me.txtLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtLotID.SelectedText = ""
        Me.txtLotID.Size = New System.Drawing.Size(185, 30)
        Me.txtLotID.TabIndex = 1
        '
        'vsfLotDetailList
        '
        Me.vsfLotDetailList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotDetailList.AllowEditing = false
        Me.vsfLotDetailList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotDetailList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLotDetailList.AutoSearchDelay = 2R
        Me.vsfLotDetailList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotDetailList.ColumnInfo = resources.GetString("vsfLotDetailList.ColumnInfo")
        Me.vsfLotDetailList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotDetailList.ExtendLastCol = true
        Me.vsfLotDetailList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotDetailList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotDetailList.Location = New System.Drawing.Point(8, 104)
        Me.vsfLotDetailList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotDetailList.Name = "vsfLotDetailList"
        Me.vsfLotDetailList.Rows.Count = 40
        Me.vsfLotDetailList.Rows.DefaultSize = 48
        Me.vsfLotDetailList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfLotDetailList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotDetailList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotDetailList.Size = New System.Drawing.Size(917, 422)
        Me.vsfLotDetailList.StyleInfo = resources.GetString("vsfLotDetailList.StyleInfo")
        Me.vsfLotDetailList.TabIndex = 2
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Gray
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Black
        Me.lblTitle0.Location = New System.Drawing.Point(778, 84)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(122, 18)
        Me.lblTitle0.TabIndex = 30
        Me.lblTitle0.Text = "流動対象外工程"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(312, 8)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(105, 17)
        Me.lblTtl4.TabIndex = 29
        Me.lblTtl4.Text = "機種"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPD
        '
        Me.lblPD.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPD.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPD.Location = New System.Drawing.Point(312, 24)
        Me.lblPD.Name = "lblPD"
        Me.lblPD.Size = New System.Drawing.Size(105, 30)
        Me.lblPD.TabIndex = 28
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Aqua
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Black
        Me.lblTitle5.Location = New System.Drawing.Point(826, 67)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(74, 18)
        Me.lblTitle5.TabIndex = 27
        Me.lblTitle5.Text = "現在工程"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(208, 24)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(105, 30)
        Me.lblWFNo.TabIndex = 26
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(208, 8)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(105, 17)
        Me.lblTtl5.TabIndex = 25
        Me.lblTtl5.Text = "数量"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(8, 56)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 24
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 8)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl0.TabIndex = 23
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(208, 72)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(105, 30)
        Me.lblStatus.TabIndex = 22
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(208, 56)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(105, 17)
        Me.lblTtl7.TabIndex = 21
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHold
        '
        Me.lblHold.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHold.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblHold.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblHold.Location = New System.Drawing.Point(312, 72)
        Me.lblHold.Name = "lblHold"
        Me.lblHold.Size = New System.Drawing.Size(105, 30)
        Me.lblHold.TabIndex = 20
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(312, 56)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(105, 17)
        Me.lblTtl3.TabIndex = 19
        Me.lblTtl3.Text = "保留・停止"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(416, 8)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl2.TabIndex = 18
        Me.lblTtl2.Text = "大工程"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(416, 24)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 30)
        Me.lblOpID.TabIndex = 17
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(416, 72)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 30)
        Me.lblStepID.TabIndex = 16
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(416, 56)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 15
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(823, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 30)
        Me.lblNowDate.TabIndex = 14
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(823, 8)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 13
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(902, 72)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(72, 30)
        Me.lblLotCnt.TabIndex = 12
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(902, 56)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(72, 17)
        Me.lblTitle1.TabIndex = 11
        Me.lblTitle1.Text = "工程数"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01G0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdLotComment)
        Me.Controls.Add(Me.cmdWPRecipeList)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdLotSearch)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtCarrierID)
        Me.Controls.Add(Me.txtLotID)
        Me.Controls.Add(Me.vsfLotDetailList)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblPD)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblHold)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01G0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ロット流動票"
        CType(Me.vsfLotDetailList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdLotComment As Button
    Friend WithEvents cmdWPRecipeList As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdLotSearch As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtCarrierID As SETextBoxEx.TextBoxEx
    Friend WithEvents txtLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfLotDetailList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblPD As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblHold As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle1 As Label
End Class
