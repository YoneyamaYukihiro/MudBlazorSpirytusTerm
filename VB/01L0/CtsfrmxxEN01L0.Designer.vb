<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01L0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01L0))
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.fraMachineList = New System.Windows.Forms.GroupBox()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.vsfMachineStatusList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraFtsMode = New System.Windows.Forms.GroupBox()
        Me.picTitleChange0 = New System.Windows.Forms.PictureBox()
        Me.cmbNewMode = New SEComboBoxEx.ComboBoxEx()
        Me.lblModeMove = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblOldMode = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblListCnt = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.fraMachineList.SuspendLayout
        CType(Me.vsfMachineStatusList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraFtsMode.SuspendLayout
        CType(Me.picTitleChange0,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(646, 14)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(105, 57)
        Me.cmdNowList.TabIndex = 1
        Me.cmdNowList.Text = "最新取得"
        '
        'fraMachineList
        '
        Me.fraMachineList.Controls.Add(Me.cmdDown)
        Me.fraMachineList.Controls.Add(Me.cmdUp)
        Me.fraMachineList.Controls.Add(Me.vsfMachineStatusList)
        Me.fraMachineList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraMachineList.Location = New System.Drawing.Point(7, 106)
        Me.fraMachineList.Name = "fraMachineList"
        Me.fraMachineList.Size = New System.Drawing.Size(902, 467)
        Me.fraMachineList.TabIndex = 2
        Me.fraMachineList.TabStop = false
        Me.fraMachineList.Text = "機器状態"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(838, 236)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 206)
        Me.cmdDown.TabIndex = 4
        Me.cmdDown.Text = "▼"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUp.Location = New System.Drawing.Point(838, 31)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(49, 206)
        Me.cmdUp.TabIndex = 3
        Me.cmdUp.Text = "▲"
        '
        'vsfMachineStatusList
        '
        Me.vsfMachineStatusList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMachineStatusList.AllowEditing = false
        Me.vsfMachineStatusList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMachineStatusList.AutoResize = true
        Me.vsfMachineStatusList.AutoSearchDelay = 2R
        Me.vsfMachineStatusList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMachineStatusList.ColumnInfo = resources.GetString("vsfMachineStatusList.ColumnInfo")
        Me.vsfMachineStatusList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMachineStatusList.ExtendLastCol = true
        Me.vsfMachineStatusList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfMachineStatusList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMachineStatusList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMachineStatusList.Location = New System.Drawing.Point(13, 32)
        Me.vsfMachineStatusList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMachineStatusList.Name = "vsfMachineStatusList"
        Me.vsfMachineStatusList.Rows.Count = 30
        Me.vsfMachineStatusList.Rows.DefaultSize = 18
        Me.vsfMachineStatusList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMachineStatusList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMachineStatusList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMachineStatusList.Size = New System.Drawing.Size(825, 409)
        Me.vsfMachineStatusList.StyleInfo = resources.GetString("vsfMachineStatusList.StyleInfo")
        Me.vsfMachineStatusList.TabIndex = 2
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
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 579)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 5
        Me.cmdRegist.Text = "確　定"
        '
        'fraFtsMode
        '
        Me.fraFtsMode.Controls.Add(Me.picTitleChange0)
        Me.fraFtsMode.Controls.Add(Me.cmbNewMode)
        Me.fraFtsMode.Controls.Add(Me.lblModeMove)
        Me.fraFtsMode.Controls.Add(Me.lblTitle1)
        Me.fraFtsMode.Controls.Add(Me.lblTitle5)
        Me.fraFtsMode.Controls.Add(Me.lblTitle4)
        Me.fraFtsMode.Controls.Add(Me.lblOldMode)
        Me.fraFtsMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraFtsMode.Location = New System.Drawing.Point(7, 6)
        Me.fraFtsMode.Name = "fraFtsMode"
        Me.fraFtsMode.Size = New System.Drawing.Size(633, 85)
        Me.fraFtsMode.TabIndex = 0
        Me.fraFtsMode.TabStop = false
        Me.fraFtsMode.Text = "搬送モード変更"
        '
        'picTitleChange0
        '
        Me.picTitleChange0.Image = CType(resources.GetObject("picTitleChange0.Image"),System.Drawing.Image)
        Me.picTitleChange0.Location = New System.Drawing.Point(393, 31)
        Me.picTitleChange0.Name = "picTitleChange0"
        Me.picTitleChange0.Size = New System.Drawing.Size(32, 32)
        Me.picTitleChange0.TabIndex = 11
        Me.picTitleChange0.TabStop = false
        '
        'cmbNewMode
        '
        Me.cmbNewMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbNewMode.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbNewMode.Location = New System.Drawing.Point(445, 41)
        Me.cmbNewMode.Name = "cmbNewMode"
        Me.cmbNewMode.Size = New System.Drawing.Size(175, 28)
        Me.cmbNewMode.TabIndex = 0
        Me.cmbNewMode.Value = Nothing
        '
        'lblModeMove
        '
        Me.lblModeMove.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblModeMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModeMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblModeMove.ForeColor = System.Drawing.Color.Black
        Me.lblModeMove.Location = New System.Drawing.Point(13, 40)
        Me.lblModeMove.Name = "lblModeMove"
        Me.lblModeMove.Size = New System.Drawing.Size(175, 30)
        Me.lblModeMove.TabIndex = 16
        Me.lblModeMove.Text = "OnlineProcessing"
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(13, 24)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(175, 17)
        Me.lblTitle1.TabIndex = 15
        Me.lblTitle1.Text = "運用状態"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(445, 24)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(175, 17)
        Me.lblTitle5.TabIndex = 10
        Me.lblTitle5.Text = "変更後"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(198, 24)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(175, 17)
        Me.lblTitle4.TabIndex = 9
        Me.lblTitle4.Text = "現在の搬送モード"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOldMode
        '
        Me.lblOldMode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOldMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOldMode.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOldMode.ForeColor = System.Drawing.Color.Black
        Me.lblOldMode.Location = New System.Drawing.Point(198, 40)
        Me.lblOldMode.Name = "lblOldMode"
        Me.lblOldMode.Size = New System.Drawing.Size(175, 30)
        Me.lblOldMode.TabIndex = 8
        Me.lblOldMode.Text = "NoTransfer"
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(834, 64)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle2.TabIndex = 18
        Me.lblTitle2.Text = "該当件数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblListCnt
        '
        Me.lblListCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblListCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblListCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblListCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblListCnt.Location = New System.Drawing.Point(834, 80)
        Me.lblListCnt.Name = "lblListCnt"
        Me.lblListCnt.Size = New System.Drawing.Size(74, 25)
        Me.lblListCnt.TabIndex = 17
        Me.lblListCnt.Text = "0"
        Me.lblListCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(756, 30)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 25)
        Me.lblNowDate.TabIndex = 14
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(756, 14)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle0.TabIndex = 13
        Me.lblTitle0.Text = "情報取得日時"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01L0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.fraMachineList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.fraFtsMode)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblListCnt)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle0)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(-4, 152)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01L0"
        Me.Text = "搬送モード変更"
        Me.fraMachineList.ResumeLayout(false)
        CType(Me.vsfMachineStatusList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraFtsMode.ResumeLayout(false)
        CType(Me.picTitleChange0,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdNowList As Button
    Friend WithEvents fraMachineList As GroupBox
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUp As Button
    Friend WithEvents vsfMachineStatusList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraFtsMode As GroupBox
    Friend WithEvents picTitleChange0 As PictureBox
    Friend WithEvents cmbNewMode As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblModeMove As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblOldMode As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblListCnt As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle0 As Label
End Class
