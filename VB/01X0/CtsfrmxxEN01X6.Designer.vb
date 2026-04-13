<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01X6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01X6))
        Me.fraApcType = New System.Windows.Forms.Panel()
        Me.cmbApcType = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.fraLimitProcess = New System.Windows.Forms.GroupBox()
        Me.picVector = New System.Windows.Forms.PictureBox()
        Me.vsfMeasStepList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblFromOpId = New System.Windows.Forms.Label()
        Me.lblFromStepId = New System.Windows.Forms.Label()
        Me.lblToOpId = New System.Windows.Forms.Label()
        Me.lblToStepId = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraFbNo = New System.Windows.Forms.Panel()
        Me.cmbNo = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblApcTergetEqType = New System.Windows.Forms.Label()
        Me.fraApcType.SuspendLayout
        Me.fraLimitProcess.SuspendLayout
        CType(Me.picVector,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfMeasStepList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraFbNo.SuspendLayout
        Me.SuspendLayout
        '
        'fraApcType
        '
        Me.fraApcType.Controls.Add(Me.cmbApcType)
        Me.fraApcType.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraApcType.Location = New System.Drawing.Point(8, 8)
        Me.fraApcType.Name = "fraApcType"
        Me.fraApcType.Size = New System.Drawing.Size(107, 41)
        Me.fraApcType.TabIndex = 0
        '
        'cmbApcType
        '
        Me.cmbApcType.DirectInput = false
        Me.cmbApcType.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbApcType.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbApcType.Location = New System.Drawing.Point(0, 16)
        Me.cmbApcType.Name = "cmbApcType"
        Me.cmbApcType.Size = New System.Drawing.Size(99, 22)
        Me.cmbApcType.TabIndex = 0
        Me.cmbApcType.Value = Nothing
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(99, 17)
        Me.lblTitle0.TabIndex = 16
        Me.lblTitle0.Text = "APCタイプ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraLimitProcess
        '
        Me.fraLimitProcess.Controls.Add(Me.picVector)
        Me.fraLimitProcess.Controls.Add(Me.vsfMeasStepList)
        Me.fraLimitProcess.Controls.Add(Me.lblFromOpId)
        Me.fraLimitProcess.Controls.Add(Me.lblFromStepId)
        Me.fraLimitProcess.Controls.Add(Me.lblToOpId)
        Me.fraLimitProcess.Controls.Add(Me.lblToStepId)
        Me.fraLimitProcess.Controls.Add(Me.lblTitle5)
        Me.fraLimitProcess.Controls.Add(Me.lblTitle3)
        Me.fraLimitProcess.Controls.Add(Me.lblTitle4)
        Me.fraLimitProcess.Controls.Add(Me.lblTitle6)
        Me.fraLimitProcess.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLimitProcess.Location = New System.Drawing.Point(8, 58)
        Me.fraLimitProcess.Name = "fraLimitProcess"
        Me.fraLimitProcess.Size = New System.Drawing.Size(569, 133)
        Me.fraLimitProcess.TabIndex = 7
        Me.fraLimitProcess.TabStop = false
        Me.fraLimitProcess.Text = "APC工程"
        '
        'picVector
        '
        Me.picVector.Image = CType(resources.GetObject("picVector.Image"),System.Drawing.Image)
        Me.picVector.Location = New System.Drawing.Point(266, 50)
        Me.picVector.Name = "picVector"
        Me.picVector.Size = New System.Drawing.Size(32, 32)
        Me.picVector.TabIndex = 14
        Me.picVector.TabStop = false
        '
        'vsfMeasStepList
        '
        Me.vsfMeasStepList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMeasStepList.AllowEditing = false
        Me.vsfMeasStepList.AutoResize = true
        Me.vsfMeasStepList.AutoSearchDelay = 2R
        Me.vsfMeasStepList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMeasStepList.ColumnInfo = resources.GetString("vsfMeasStepList.ColumnInfo")
        Me.vsfMeasStepList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMeasStepList.ExtendLastCol = true
        Me.vsfMeasStepList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMeasStepList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMeasStepList.Location = New System.Drawing.Point(302, 18)
        Me.vsfMeasStepList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMeasStepList.Name = "vsfMeasStepList"
        Me.vsfMeasStepList.Rows.Count = 2
        Me.vsfMeasStepList.Rows.DefaultSize = 18
        Me.vsfMeasStepList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMeasStepList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMeasStepList.Size = New System.Drawing.Size(256, 95)
        Me.vsfMeasStepList.StyleInfo = resources.GetString("vsfMeasStepList.StyleInfo")
        Me.vsfMeasStepList.TabIndex = 19
        Me.vsfMeasStepList.Visible = false
        '
        'lblFromOpId
        '
        Me.lblFromOpId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFromOpId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromOpId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFromOpId.Location = New System.Drawing.Point(8, 36)
        Me.lblFromOpId.Name = "lblFromOpId"
        Me.lblFromOpId.Size = New System.Drawing.Size(256, 17)
        Me.lblFromOpId.TabIndex = 3
        '
        'lblFromStepId
        '
        Me.lblFromStepId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFromStepId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromStepId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFromStepId.Location = New System.Drawing.Point(8, 92)
        Me.lblFromStepId.Name = "lblFromStepId"
        Me.lblFromStepId.Size = New System.Drawing.Size(256, 17)
        Me.lblFromStepId.TabIndex = 4
        '
        'lblToOpId
        '
        Me.lblToOpId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToOpId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblToOpId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblToOpId.Location = New System.Drawing.Point(302, 36)
        Me.lblToOpId.Name = "lblToOpId"
        Me.lblToOpId.Size = New System.Drawing.Size(256, 17)
        Me.lblToOpId.TabIndex = 5
        '
        'lblToStepId
        '
        Me.lblToStepId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblToStepId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblToStepId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblToStepId.Location = New System.Drawing.Point(302, 92)
        Me.lblToStepId.Name = "lblToStepId"
        Me.lblToStepId.Size = New System.Drawing.Size(256, 17)
        Me.lblToStepId.TabIndex = 6
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(302, 20)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle5.TabIndex = 11
        Me.lblTitle5.Text = "TO大工程"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(8, 20)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle3.TabIndex = 10
        Me.lblTitle3.Text = "FORM大工程"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(8, 76)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle4.TabIndex = 9
        Me.lblTitle4.Text = "FORM小工程"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(302, 76)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(256, 17)
        Me.lblTitle6.TabIndex = 8
        Me.lblTitle6.Text = "TO小工程"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 202)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'fraFbNo
        '
        Me.fraFbNo.Controls.Add(Me.cmbNo)
        Me.fraFbNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraFbNo.Location = New System.Drawing.Point(120, 8)
        Me.fraFbNo.Name = "fraFbNo"
        Me.fraFbNo.Size = New System.Drawing.Size(107, 41)
        Me.fraFbNo.TabIndex = 1
        '
        'cmbNo
        '
        Me.cmbNo.DirectInput = false
        Me.cmbNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbNo.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbNo.Location = New System.Drawing.Point(0, 16)
        Me.cmbNo.Name = "cmbNo"
        Me.cmbNo.Size = New System.Drawing.Size(98, 22)
        Me.cmbNo.TabIndex = 1
        Me.cmbNo.Value = Nothing
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(120, 8)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(98, 17)
        Me.lblTitle2.TabIndex = 13
        Me.lblTitle2.Text = "X/X番号"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(230, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(348, 17)
        Me.lblTitle1.TabIndex = 18
        Me.lblTitle1.Text = "APC対象"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblApcTergetEqType
        '
        Me.lblApcTergetEqType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblApcTergetEqType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblApcTergetEqType.Location = New System.Drawing.Point(230, 24)
        Me.lblApcTergetEqType.Name = "lblApcTergetEqType"
        Me.lblApcTergetEqType.Size = New System.Drawing.Size(348, 21)
        Me.lblApcTergetEqType.TabIndex = 17
        '
        'frmxxEN01X6
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(587, 249)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.fraApcType)
        Me.Controls.Add(Me.fraLimitProcess)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.fraFbNo)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblApcTergetEqType)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(16, 186)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01X6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "APC設定確認"
        Me.fraApcType.ResumeLayout(false)
        Me.fraLimitProcess.ResumeLayout(false)
        CType(Me.picVector,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfMeasStepList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraFbNo.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraApcType As Panel
    Friend WithEvents cmbApcType As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents fraLimitProcess As GroupBox
    Friend WithEvents picVector As PictureBox
    Friend WithEvents vsfMeasStepList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblFromOpId As Label
    Friend WithEvents lblFromStepId As Label
    Friend WithEvents lblToOpId As Label
    Friend WithEvents lblToStepId As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents fraFbNo As Panel
    Friend WithEvents cmbNo As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblApcTergetEqType As Label
End Class
