<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00E1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00E1))
        Me.cmdScanClear = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.vsfTateroImage = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtACarrierId = New SETextBoxEx.TextBoxEx()
        Me.lblATrayCnt = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblACarrierCnt = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblBg = New System.Windows.Forms.Label()
        CType(Me.vsfTateroImage,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdScanClear
        '
        Me.cmdScanClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdScanClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdScanClear.Location = New System.Drawing.Point(208, 16)
        Me.cmdScanClear.Name = "cmdScanClear"
        Me.cmdScanClear.Size = New System.Drawing.Size(105, 57)
        Me.cmdScanClear.TabIndex = 7
        Me.cmdScanClear.Text = "SCAN"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"全取消"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 480)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(528, 480)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 1
        Me.cmdRegist.Text = "確　定"
        '
        'vsfTateroImage
        '
        Me.vsfTateroImage.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfTateroImage.AllowEditing = false
        Me.vsfTateroImage.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfTateroImage.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfTateroImage.AutoResize = true
        Me.vsfTateroImage.AutoSearchDelay = 2R
        Me.vsfTateroImage.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfTateroImage.ColumnInfo = resources.GetString("vsfTateroImage.ColumnInfo")
        Me.vsfTateroImage.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfTateroImage.ExtendLastCol = true
        Me.vsfTateroImage.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfTateroImage.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfTateroImage.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfTateroImage.Location = New System.Drawing.Point(8, 112)
        Me.vsfTateroImage.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfTateroImage.Name = "vsfTateroImage"
        Me.vsfTateroImage.Rows.Count = 5
        Me.vsfTateroImage.Rows.DefaultSize = 18
        Me.vsfTateroImage.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfTateroImage.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfTateroImage.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfTateroImage.Size = New System.Drawing.Size(624, 356)
        Me.vsfTateroImage.StyleInfo = resources.GetString("vsfTateroImage.StyleInfo")
        Me.vsfTateroImage.TabIndex = 0
        '
        'txtACarrierId
        '
        Me.txtACarrierId.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtACarrierId.ChrMaxByte = 6
        Me.txtACarrierId.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtACarrierId.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtACarrierId.Location = New System.Drawing.Point(16, 32)
        Me.txtACarrierId.Name = "txtACarrierId"
        Me.txtACarrierId.NgChr = "'"
        Me.txtACarrierId.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtACarrierId.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtACarrierId.SelectedText = ""
        Me.txtACarrierId.Size = New System.Drawing.Size(185, 30)
        Me.txtACarrierId.TabIndex = 10
        '
        'lblATrayCnt
        '
        Me.lblATrayCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblATrayCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblATrayCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblATrayCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblATrayCnt.Location = New System.Drawing.Point(520, 32)
        Me.lblATrayCnt.Name = "lblATrayCnt"
        Me.lblATrayCnt.Size = New System.Drawing.Size(104, 25)
        Me.lblATrayCnt.TabIndex = 9
        Me.lblATrayCnt.Text = "0"
        Me.lblATrayCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(520, 16)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(104, 17)
        Me.lblTitle2.TabIndex = 8
        Me.lblTitle2.Text = "Aトレイ数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblACarrierCnt
        '
        Me.lblACarrierCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblACarrierCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblACarrierCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblACarrierCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblACarrierCnt.Location = New System.Drawing.Point(320, 32)
        Me.lblACarrierCnt.Name = "lblACarrierCnt"
        Me.lblACarrierCnt.Size = New System.Drawing.Size(192, 25)
        Me.lblACarrierCnt.TabIndex = 6
        Me.lblACarrierCnt.Text = "0"
        Me.lblACarrierCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(320, 16)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(192, 17)
        Me.lblTitle1.TabIndex = 5
        Me.lblTitle1.Text = "選択する Aキャリア数"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(16, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle0.TabIndex = 4
        Me.lblTitle0.Text = "AキャリアID　SCAN"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBg
        '
        Me.lblBg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBg.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBg.Location = New System.Drawing.Point(8, 8)
        Me.lblBg.Name = "lblBg"
        Me.lblBg.Size = New System.Drawing.Size(625, 73)
        Me.lblBg.TabIndex = 3
        '
        'frmxxCM00E1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(641, 548)
        Me.Controls.Add(Me.cmdScanClear)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.vsfTateroImage)
        Me.Controls.Add(Me.txtACarrierId)
        Me.Controls.Add(Me.lblATrayCnt)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblACarrierCnt)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblBg)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00E1"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aキャリア選択"
        CType(Me.vsfTateroImage,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdScanClear As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents vsfTateroImage As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtACarrierId As SETextBoxEx.TextBoxEx
    Friend WithEvents lblATrayCnt As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblACarrierCnt As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblBg As Label
End Class
