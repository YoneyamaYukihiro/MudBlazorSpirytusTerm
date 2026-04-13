<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02H1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02H1))
        Me.fraHoldList = New System.Windows.Forms.GroupBox()
        Me.cmdTxtUp = New System.Windows.Forms.Button()
        Me.cmdTxtDown = New System.Windows.Forms.Button()
        Me.vsfCFHistory = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.labEmpName = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.labProductLot = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.labParts = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.labThrowinNum = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblThrowinTime = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.fraHoldList.SuspendLayout
        CType(Me.vsfCFHistory,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'fraHoldList
        '
        Me.fraHoldList.Controls.Add(Me.cmdTxtUp)
        Me.fraHoldList.Controls.Add(Me.cmdTxtDown)
        Me.fraHoldList.Controls.Add(Me.vsfCFHistory)
        Me.fraHoldList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraHoldList.Location = New System.Drawing.Point(8, 76)
        Me.fraHoldList.Name = "fraHoldList"
        Me.fraHoldList.Size = New System.Drawing.Size(799, 413)
        Me.fraHoldList.TabIndex = 0
        Me.fraHoldList.TabStop = false
        Me.fraHoldList.Text = "払出履歴"
        '
        'cmdTxtUp
        '
        Me.cmdTxtUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtUp.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtUp.Location = New System.Drawing.Point(765, 19)
        Me.cmdTxtUp.Name = "cmdTxtUp"
        Me.cmdTxtUp.Size = New System.Drawing.Size(25, 192)
        Me.cmdTxtUp.TabIndex = 0
        Me.cmdTxtUp.Text = "▲"
        '
        'cmdTxtDown
        '
        Me.cmdTxtDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTxtDown.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdTxtDown.Location = New System.Drawing.Point(765, 212)
        Me.cmdTxtDown.Name = "cmdTxtDown"
        Me.cmdTxtDown.Size = New System.Drawing.Size(25, 191)
        Me.cmdTxtDown.TabIndex = 1
        Me.cmdTxtDown.Text = "▼"
        '
        'vsfCFHistory
        '
        Me.vsfCFHistory.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCFHistory.AllowEditing = false
        Me.vsfCFHistory.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfCFHistory.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfCFHistory.AutoResize = true
        Me.vsfCFHistory.AutoSearchDelay = 2R
        Me.vsfCFHistory.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCFHistory.ColumnInfo = resources.GetString("vsfCFHistory.ColumnInfo")
        Me.vsfCFHistory.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCFHistory.ExtendLastCol = true
        Me.vsfCFHistory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCFHistory.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCFHistory.Location = New System.Drawing.Point(8, 20)
        Me.vsfCFHistory.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCFHistory.Name = "vsfCFHistory"
        Me.vsfCFHistory.Rows.Count = 21
        Me.vsfCFHistory.Rows.DefaultSize = 18
        Me.vsfCFHistory.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfCFHistory.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCFHistory.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCFHistory.Size = New System.Drawing.Size(757, 382)
        Me.vsfCFHistory.StyleInfo = resources.GetString("vsfCFHistory.StyleInfo")
        Me.vsfCFHistory.TabIndex = 16
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 500)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(616, 16)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(181, 17)
        Me.lblTitle5.TabIndex = 13
        Me.lblTitle5.Text = "作業者"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labEmpName
        '
        Me.labEmpName.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labEmpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labEmpName.Location = New System.Drawing.Point(616, 32)
        Me.labEmpName.Name = "labEmpName"
        Me.labEmpName.Size = New System.Drawing.Size(181, 22)
        Me.labEmpName.TabIndex = 14
        Me.labEmpName.Text = "xxxxxxxxxxxx"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(508, 16)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(109, 17)
        Me.lblTitle4.TabIndex = 11
        Me.lblTitle4.Text = "製造ロットID"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labProductLot
        '
        Me.labProductLot.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labProductLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labProductLot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labProductLot.Location = New System.Drawing.Point(508, 32)
        Me.labProductLot.Name = "labProductLot"
        Me.labProductLot.Size = New System.Drawing.Size(109, 22)
        Me.labProductLot.TabIndex = 12
        Me.labProductLot.Text = "CF06032302--"
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(360, 16)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(149, 17)
        Me.lblTitle3.TabIndex = 9
        Me.lblTitle3.Text = "部品"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labParts
        '
        Me.labParts.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labParts.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labParts.Location = New System.Drawing.Point(360, 32)
        Me.labParts.Name = "labParts"
        Me.labParts.Size = New System.Drawing.Size(149, 22)
        Me.labParts.TabIndex = 10
        Me.labParts.Text = "1259381-----------"
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(288, 16)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle2.TabIndex = 7
        Me.lblTitle2.Text = "投入数量"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labThrowinNum
        '
        Me.labThrowinNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labThrowinNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labThrowinNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.labThrowinNum.Location = New System.Drawing.Point(288, 32)
        Me.labThrowinNum.Name = "labThrowinNum"
        Me.labThrowinNum.Size = New System.Drawing.Size(73, 22)
        Me.labThrowinNum.TabIndex = 8
        Me.labThrowinNum.Text = "500"
        Me.labThrowinNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(20, 16)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(105, 17)
        Me.lblTitle0.TabIndex = 3
        Me.lblTitle0.Text = "ロットID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(124, 16)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(165, 17)
        Me.lblTitle1.TabIndex = 5
        Me.lblTitle1.Text = "投入日時"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(20, 32)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(105, 22)
        Me.lblLotID.TabIndex = 4
        Me.lblLotID.Text = "CFBAH00001"
        '
        'lblThrowinTime
        '
        Me.lblThrowinTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblThrowinTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblThrowinTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblThrowinTime.Location = New System.Drawing.Point(124, 32)
        Me.lblThrowinTime.Name = "lblThrowinTime"
        Me.lblThrowinTime.Size = New System.Drawing.Size(165, 22)
        Me.lblThrowinTime.TabIndex = 6
        Me.lblThrowinTime.Text = "yyyy/mm/dd hh:mm:ss"
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(12, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(793, 52)
        Me.lblBack.TabIndex = 15
        '
        'frmxxEN02H1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(813, 548)
        Me.Controls.Add(Me.fraHoldList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.labEmpName)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.labProductLot)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.labParts)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.labThrowinNum)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblThrowinTime)
        Me.Controls.Add(Me.lblBack)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(341, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02H1"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "無機CFロット払出履歴"
        Me.fraHoldList.ResumeLayout(false)
        CType(Me.vsfCFHistory,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraHoldList As GroupBox
    Friend WithEvents cmdTxtUp As Button
    Friend WithEvents cmdTxtDown As Button
    Friend WithEvents vsfCFHistory As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdClose As Button
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents labEmpName As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents labProductLot As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents labParts As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents labThrowinNum As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblThrowinTime As Label
    Friend WithEvents lblBack As Label
End Class
