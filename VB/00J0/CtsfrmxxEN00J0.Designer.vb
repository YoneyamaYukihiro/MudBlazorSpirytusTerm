<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00J0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00J0))
        Me.cmdLotDetail = New System.Windows.Forms.Button()
        Me.cmdLotConnectedInfoDisp = New System.Windows.Forms.Button()
        Me.cmdLotList = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfMcAllLotlist = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbMcGroupName = New SECmbIchiran.ComboIchiran()
        Me.lblTitleChip = New System.Windows.Forms.Label()
        Me.lblTitleR = New System.Windows.Forms.Label()
        Me.lblTitleL = New System.Windows.Forms.Label()
        Me.lblTitleHT = New System.Windows.Forms.Label()
        Me.lblTitleD = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        CType(Me.vsfMcAllLotlist,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdLotDetail
        '
        Me.cmdLotDetail.CausesValidation = false
        Me.cmdLotDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotDetail.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotDetail.Location = New System.Drawing.Point(116, 581)
        Me.cmdLotDetail.Name = "cmdLotDetail"
        Me.cmdLotDetail.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotDetail.TabIndex = 19
        Me.cmdLotDetail.Text = "ロット情報"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"詳細表示"
        '
        'cmdLotConnectedInfoDisp
        '
        Me.cmdLotConnectedInfoDisp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotConnectedInfoDisp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotConnectedInfoDisp.Location = New System.Drawing.Point(224, 581)
        Me.cmdLotConnectedInfoDisp.Name = "cmdLotConnectedInfoDisp"
        Me.cmdLotConnectedInfoDisp.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotConnectedInfoDisp.TabIndex = 18
        Me.cmdLotConnectedInfoDisp.Text = "TFT/CF紐付"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"情報表示"
        '
        'cmdLotList
        '
        Me.cmdLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotList.Location = New System.Drawing.Point(566, 4)
        Me.cmdLotList.Name = "cmdLotList"
        Me.cmdLotList.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotList.TabIndex = 6
        Me.cmdLotList.Text = "最新取得"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 528)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(453, 49)
        Me.cmdLeft.TabIndex = 4
        Me.cmdLeft.Text = "<<"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(463, 528)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(453, 49)
        Me.cmdRight.TabIndex = 5
        Me.cmdRight.Text = ">>"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(915, 72)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 229)
        Me.cmdUP.TabIndex = 2
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(915, 300)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 229)
        Me.cmdDown.TabIndex = 3
        Me.cmdDown.Text = "▼"
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
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "閉じる"
        '
        'vsfMcAllLotlist
        '
        Me.vsfMcAllLotlist.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMcAllLotlist.AllowEditing = false
        Me.vsfMcAllLotlist.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMcAllLotlist.AutoSearchDelay = 2R
        Me.vsfMcAllLotlist.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMcAllLotlist.ColumnInfo = resources.GetString("vsfMcAllLotlist.ColumnInfo")
        Me.vsfMcAllLotlist.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMcAllLotlist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMcAllLotlist.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMcAllLotlist.Location = New System.Drawing.Point(8, 73)
        Me.vsfMcAllLotlist.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMcAllLotlist.Name = "vsfMcAllLotlist"
        Me.vsfMcAllLotlist.Rows.Count = 40
        Me.vsfMcAllLotlist.Rows.DefaultSize = 18
        Me.vsfMcAllLotlist.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMcAllLotlist.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMcAllLotlist.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMcAllLotlist.Size = New System.Drawing.Size(907, 455)
        Me.vsfMcAllLotlist.StyleInfo = resources.GetString("vsfMcAllLotlist.StyleInfo")
        Me.vsfMcAllLotlist.TabIndex = 1
        '
        'cmbMcGroupName
        '
        Me.cmbMcGroupName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.GridForeColor = System.Drawing.Color.Black
        Me.cmbMcGroupName.Location = New System.Drawing.Point(8, 24)
        Me.cmbMcGroupName.Name = "cmbMcGroupName"
        Me.cmbMcGroupName.Size = New System.Drawing.Size(349, 28)
        Me.cmbMcGroupName.TabIndex = 0
        Me.cmbMcGroupName.Value = Nothing
        '
        'lblTitleChip
        '
        Me.lblTitleChip.BackColor = System.Drawing.Color.White
        Me.lblTitleChip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleChip.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleChip.ForeColor = System.Drawing.Color.Blue
        Me.lblTitleChip.Location = New System.Drawing.Point(376, 24)
        Me.lblTitleChip.Name = "lblTitleChip"
        Me.lblTitleChip.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleChip.TabIndex = 17
        Me.lblTitleChip.Text = "青字：Chip品"
        Me.lblTitleChip.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleChip.UseMnemonic = false
        '
        'lblTitleR
        '
        Me.lblTitleR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblTitleR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleR.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleR.ForeColor = System.Drawing.Color.Black
        Me.lblTitleR.Location = New System.Drawing.Point(519, 24)
        Me.lblTitleR.Name = "lblTitleR"
        Me.lblTitleR.Size = New System.Drawing.Size(33, 19)
        Me.lblTitleR.TabIndex = 16
        Me.lblTitleR.Text = "R"
        Me.lblTitleR.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleR.UseMnemonic = false
        '
        'lblTitleL
        '
        Me.lblTitleL.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblTitleL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleL.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleL.ForeColor = System.Drawing.Color.Black
        Me.lblTitleL.Location = New System.Drawing.Point(487, 24)
        Me.lblTitleL.Name = "lblTitleL"
        Me.lblTitleL.Size = New System.Drawing.Size(33, 19)
        Me.lblTitleL.TabIndex = 15
        Me.lblTitleL.Text = "L"
        Me.lblTitleL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleL.UseMnemonic = false
        '
        'lblTitleHT
        '
        Me.lblTitleHT.BackColor = System.Drawing.Color.Yellow
        Me.lblTitleHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleHT.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleHT.ForeColor = System.Drawing.Color.Black
        Me.lblTitleHT.Location = New System.Drawing.Point(376, 42)
        Me.lblTitleHT.Name = "lblTitleHT"
        Me.lblTitleHT.Size = New System.Drawing.Size(112, 19)
        Me.lblTitleHT.TabIndex = 14
        Me.lblTitleHT.Text = "保留/停止"
        Me.lblTitleHT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitleD
        '
        Me.lblTitleD.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lblTitleD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitleD.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitleD.ForeColor = System.Drawing.Color.Black
        Me.lblTitleD.Location = New System.Drawing.Point(487, 42)
        Me.lblTitleD.Name = "lblTitleD"
        Me.lblTitleD.Size = New System.Drawing.Size(65, 19)
        Me.lblTitleD.TabIndex = 13
        Me.lblTitleD.Text = "ダミー"
        Me.lblTitleD.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTitleD.UseMnemonic = false
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(839, 4)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle2.TabIndex = 12
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(839, 20)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(74, 25)
        Me.lblLotCnt.TabIndex = 11
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(679, 4)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 10
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(679, 20)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 25)
        Me.lblNowDate.TabIndex = 9
        Me.lblNowDate.Text = "MM/dd HH:mm:ss"
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(349, 17)
        Me.lblTitle0.TabIndex = 8
        Me.lblTitle0.Text = "装置グループ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00J0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdLotDetail)
        Me.Controls.Add(Me.cmdLotConnectedInfoDisp)
        Me.Controls.Add(Me.cmdLotList)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfMcAllLotlist)
        Me.Controls.Add(Me.cmbMcGroupName)
        Me.Controls.Add(Me.lblTitleChip)
        Me.Controls.Add(Me.lblTitleR)
        Me.Controls.Add(Me.lblTitleL)
        Me.Controls.Add(Me.lblTitleHT)
        Me.Controls.Add(Me.lblTitleD)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle0)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00J0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "装置グループ別ロット一覧"
        CType(Me.vsfMcAllLotlist,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdLotDetail As Button
    Friend WithEvents cmdLotConnectedInfoDisp As Button
    Friend WithEvents cmdLotList As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfMcAllLotlist As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbMcGroupName As SECmbIchiran.ComboIchiran
    Friend WithEvents lblTitleChip As Label
    Friend WithEvents lblTitleR As Label
    Friend WithEvents lblTitleL As Label
    Friend WithEvents lblTitleHT As Label
    Friend WithEvents lblTitleD As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle0 As Label
End Class
