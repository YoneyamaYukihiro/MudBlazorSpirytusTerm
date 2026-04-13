<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02C1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02C1))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdChoice = New System.Windows.Forms.Button()
        Me.txtJig = New SETextBoxEx.TextBoxEx()
        Me.vsfInvLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbPart = New SECmbIchiran.ComboIchiran()
        Me.lblPartTitle = New System.Windows.Forms.Label()
        Me.lblSlotNo = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabStuffCount = New System.Windows.Forms.Label()
        Me.lblThrowNumTitle = New System.Windows.Forms.Label()
        Me.lblThrowNum = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblBg = New System.Windows.Forms.Label()
        CType(Me.vsfInvLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 406)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(86, 43)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "閉じる"
        '
        'cmdChoice
        '
        Me.cmdChoice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChoice.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChoice.Location = New System.Drawing.Point(452, 406)
        Me.cmdChoice.Name = "cmdChoice"
        Me.cmdChoice.Size = New System.Drawing.Size(86, 43)
        Me.cmdChoice.TabIndex = 0
        Me.cmdChoice.Text = "確　定"
        '
        'txtJig
        '
        Me.txtJig.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtJig.ChrMaxByte = 10
        Me.txtJig.Enabled = false
        Me.txtJig.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtJig.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtJig.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtJig.Location = New System.Drawing.Point(88, 32)
        Me.txtJig.Name = "txtJig"
        Me.txtJig.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtJig.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtJig.SelectedText = ""
        Me.txtJig.Size = New System.Drawing.Size(91, 22)
        Me.txtJig.TabIndex = 9
        '
        'vsfInvLotList
        '
        Me.vsfInvLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfInvLotList.AllowEditing = false
        Me.vsfInvLotList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfInvLotList.AutoSearchDelay = 2R
        Me.vsfInvLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfInvLotList.ColumnInfo = resources.GetString("vsfInvLotList.ColumnInfo")
        Me.vsfInvLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfInvLotList.ExtendLastCol = true
        Me.vsfInvLotList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfInvLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfInvLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfInvLotList.Location = New System.Drawing.Point(8, 68)
        Me.vsfInvLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfInvLotList.Name = "vsfInvLotList"
        Me.vsfInvLotList.Rows.Count = 40
        Me.vsfInvLotList.Rows.DefaultSize = 18
        Me.vsfInvLotList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfInvLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfInvLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfInvLotList.Size = New System.Drawing.Size(530, 289)
        Me.vsfInvLotList.StyleInfo = resources.GetString("vsfInvLotList.StyleInfo")
        Me.vsfInvLotList.TabIndex = 10
        '
        'cmbPart
        '
        Me.cmbPart.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbPart.GridForeColor = System.Drawing.Color.Black
        Me.cmbPart.Location = New System.Drawing.Point(200, 32)
        Me.cmbPart.Name = "cmbPart"
        Me.cmbPart.Size = New System.Drawing.Size(225, 22)
        Me.cmbPart.TabIndex = 12
        Me.cmbPart.Value = Nothing
        '
        'lblPartTitle
        '
        Me.lblPartTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPartTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPartTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPartTitle.Location = New System.Drawing.Point(200, 16)
        Me.lblPartTitle.Name = "lblPartTitle"
        Me.lblPartTitle.Size = New System.Drawing.Size(225, 17)
        Me.lblPartTitle.TabIndex = 13
        Me.lblPartTitle.Text = "部品"
        Me.lblPartTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSlotNo
        '
        Me.lblSlotNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblSlotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSlotNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblSlotNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSlotNo.Location = New System.Drawing.Point(16, 32)
        Me.lblSlotNo.Name = "lblSlotNo"
        Me.lblSlotNo.Size = New System.Drawing.Size(59, 21)
        Me.lblSlotNo.TabIndex = 11
        Me.lblSlotNo.Text = "0"
        Me.lblSlotNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(88, 16)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(91, 17)
        Me.lblTitle1.TabIndex = 8
        Me.lblTitle1.Text = "蒸着治具ID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(366, 362)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "詰　数"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabStuffCount
        '
        Me.LabStuffCount.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LabStuffCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabStuffCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.LabStuffCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabStuffCount.Location = New System.Drawing.Point(366, 378)
        Me.LabStuffCount.Name = "LabStuffCount"
        Me.LabStuffCount.Size = New System.Drawing.Size(85, 22)
        Me.LabStuffCount.TabIndex = 6
        Me.LabStuffCount.Text = "0"
        Me.LabStuffCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblThrowNumTitle
        '
        Me.lblThrowNumTitle.BackColor = System.Drawing.Color.Navy
        Me.lblThrowNumTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowNumTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowNumTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblThrowNumTitle.Location = New System.Drawing.Point(454, 362)
        Me.lblThrowNumTitle.Name = "lblThrowNumTitle"
        Me.lblThrowNumTitle.Size = New System.Drawing.Size(85, 17)
        Me.lblThrowNumTitle.TabIndex = 5
        Me.lblThrowNumTitle.Text = "合　計"
        Me.lblThrowNumTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblThrowNum
        '
        Me.lblThrowNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblThrowNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblThrowNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblThrowNum.Location = New System.Drawing.Point(454, 378)
        Me.lblThrowNum.Name = "lblThrowNum"
        Me.lblThrowNum.Size = New System.Drawing.Size(85, 22)
        Me.lblThrowNum.TabIndex = 4
        Me.lblThrowNum.Text = "0"
        Me.lblThrowNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(16, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(59, 17)
        Me.lblTitle0.TabIndex = 3
        Me.lblTitle0.Text = "SLOT№"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBg
        '
        Me.lblBg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBg.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBg.Location = New System.Drawing.Point(8, 8)
        Me.lblBg.Name = "lblBg"
        Me.lblBg.Size = New System.Drawing.Size(530, 54)
        Me.lblBg.TabIndex = 9
        '
        'frmxxEN02C1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(546, 460)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdChoice)
        Me.Controls.Add(Me.txtJig)
        Me.Controls.Add(Me.vsfInvLotList)
        Me.Controls.Add(Me.cmbPart)
        Me.Controls.Add(Me.lblPartTitle)
        Me.Controls.Add(Me.lblSlotNo)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabStuffCount)
        Me.Controls.Add(Me.lblThrowNumTitle)
        Me.Controls.Add(Me.lblThrowNum)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblBg)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02C1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "混載編成"
        CType(Me.vsfInvLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdChoice As Button
    Friend WithEvents txtJig As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfInvLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbPart As SECmbIchiran.ComboIchiran
    Friend WithEvents lblPartTitle As Label
    Friend WithEvents lblSlotNo As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LabStuffCount As Label
    Friend WithEvents lblThrowNumTitle As Label
    Friend WithEvents lblThrowNum As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblBg As Label
End Class
