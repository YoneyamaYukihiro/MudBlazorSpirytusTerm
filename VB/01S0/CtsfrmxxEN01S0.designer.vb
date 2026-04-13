<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01S0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01S0))
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdCopyInsert = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdInsert = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.vsfPrOrderList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        CType(Me.vsfPrOrderList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Location = New System.Drawing.Point(682, 8)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 0
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdDelete
        '
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDelete.Location = New System.Drawing.Point(411, 596)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(85, 40)
        Me.cmdDelete.TabIndex = 5
        Me.cmdDelete.Text = "削　除"
        '
        'cmdCopyInsert
        '
        Me.cmdCopyInsert.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopyInsert.Location = New System.Drawing.Point(792, 596)
        Me.cmdCopyInsert.Name = "cmdCopyInsert"
        Me.cmdCopyInsert.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopyInsert.TabIndex = 3
        Me.cmdCopyInsert.Text = "コピー"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"登録"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Location = New System.Drawing.Point(910, 525)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(25, 57)
        Me.cmdDown.TabIndex = 8
        Me.cmdDown.Text = "▼"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Location = New System.Drawing.Point(910, 467)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(25, 57)
        Me.cmdUp.TabIndex = 7
        Me.cmdUp.Text = "▲"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpdate.Location = New System.Drawing.Point(601, 596)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(85, 40)
        Me.cmdUpdate.TabIndex = 4
        Me.cmdUpdate.Text = "修　正"
        '
        'cmdInsert
        '
        Me.cmdInsert.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdInsert.Location = New System.Drawing.Point(888, 596)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.Size = New System.Drawing.Size(85, 40)
        Me.cmdInsert.TabIndex = 2
        Me.cmdInsert.Text = "登　録"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 596)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "閉じる"
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 0
        Me.txtComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtComments.GotBackColor = System.Drawing.SystemColors.ControlLight
        Me.txtComments.GotHighLight = false
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtComments.Location = New System.Drawing.Point(8, 484)
        Me.txtComments.MultiLineEx = true
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(902, 97)
        Me.txtComments.TabIndex = 6
        Me.txtComments.TabStop = false
        '
        'vsfPrOrderList
        '
        Me.vsfPrOrderList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfPrOrderList.AllowEditing = false
        Me.vsfPrOrderList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfPrOrderList.AutoResize = true
        Me.vsfPrOrderList.AutoSearchDelay = 2R
        Me.vsfPrOrderList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfPrOrderList.ColumnInfo = resources.GetString("vsfPrOrderList.ColumnInfo")
        Me.vsfPrOrderList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfPrOrderList.ExtendLastCol = true
        Me.vsfPrOrderList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfPrOrderList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfPrOrderList.Location = New System.Drawing.Point(8, 56)
        Me.vsfPrOrderList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfPrOrderList.Name = "vsfPrOrderList"
        Me.vsfPrOrderList.Rows.Count = 22
        Me.vsfPrOrderList.Rows.DefaultSize = 18
        Me.vsfPrOrderList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfPrOrderList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfPrOrderList.Size = New System.Drawing.Size(964, 400)
        Me.vsfPrOrderList.StyleInfo = resources.GetString("vsfPrOrderList.StyleInfo")
        Me.vsfPrOrderList.TabIndex = 1
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(772, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 14
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(772, 8)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle4.TabIndex = 13
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(899, 24)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(73, 21)
        Me.lblLotCnt.TabIndex = 12
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(899, 8)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle2.TabIndex = 11
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(8, 468)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(902, 17)
        Me.lblTtl15.TabIndex = 10
        Me.lblTtl15.Text = "オーダーコメント"
        Me.lblTtl15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01S0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdCopyInsert)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUp)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdInsert)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.vsfPrOrderList)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTtl15)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(18, 25)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01S0"
        Me.Text = "P/Rオーダー管理"
        CType(Me.vsfPrOrderList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdCopyInsert As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents cmdInsert As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfPrOrderList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTtl15 As Label
End Class
