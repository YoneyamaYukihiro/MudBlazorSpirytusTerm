<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00M1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00M1))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdKakutei = New System.Windows.Forms.Button()
        Me.vsfLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblLotListCnt = New System.Windows.Forms.Label()
        Me.lblWpList = New System.Windows.Forms.Label()
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 441)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'cmdKakutei
        '
        Me.cmdKakutei.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKakutei.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKakutei.Location = New System.Drawing.Point(514, 441)
        Me.cmdKakutei.Name = "cmdKakutei"
        Me.cmdKakutei.Size = New System.Drawing.Size(85, 40)
        Me.cmdKakutei.TabIndex = 1
        Me.cmdKakutei.Text = "確　定"
        '
        'vsfLotList
        '
        Me.vsfLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotList.AllowEditing = false
        Me.vsfLotList.AutoResize = true
        Me.vsfLotList.AutoSearchDelay = 2R
        Me.vsfLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotList.ColumnInfo = resources.GetString("vsfLotList.ColumnInfo")
        Me.vsfLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotList.ExtendLastCol = true
        Me.vsfLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotList.Location = New System.Drawing.Point(8, 121)
        Me.vsfLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotList.Name = "vsfLotList"
        Me.vsfLotList.Rows.DefaultSize = 18
        Me.vsfLotList.Rows.MaxSize = 18
        Me.vsfLotList.Rows.MinSize = 18
        Me.vsfLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfLotList.Size = New System.Drawing.Size(591, 308)
        Me.vsfLotList.StyleInfo = resources.GetString("vsfLotList.StyleInfo")
        Me.vsfLotList.TabIndex = 0
        '
        'lblInstruction
        '
        Me.lblInstruction.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInstruction.ForeColor = System.Drawing.Color.Red
        Me.lblInstruction.Location = New System.Drawing.Point(9, 57)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(590, 31)
        Me.lblInstruction.TabIndex = 9
        Me.lblInstruction.Text = "<< 表面処理装置 バッチ組仕様 >>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"製品ロット ⇒ モニタロット ⇒ フィルダミーロットの順でバッチ組してください。"
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTitle7.Location = New System.Drawing.Point(12, 18)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(231, 21)
        Me.lblTitle7.TabIndex = 8
        Me.lblTitle7.Text = "△：候補　○：自動　◎：確定"
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(401, 6)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle4.TabIndex = 7
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(401, 22)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(121, 21)
        Me.lblNowDate.TabIndex = 6
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(526, 6)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(73, 17)
        Me.lblTitle5.TabIndex = 5
        Me.lblTitle5.Text = "該当件数"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotListCnt
        '
        Me.lblLotListCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotListCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotListCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotListCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotListCnt.Location = New System.Drawing.Point(526, 22)
        Me.lblLotListCnt.Name = "lblLotListCnt"
        Me.lblLotListCnt.Size = New System.Drawing.Size(73, 21)
        Me.lblLotListCnt.TabIndex = 4
        Me.lblLotListCnt.Text = "10"
        Me.lblLotListCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblWpList
        '
        Me.lblWpList.AutoSize = true
        Me.lblWpList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWpList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWpList.Location = New System.Drawing.Point(8, 94)
        Me.lblWpList.Name = "lblWpList"
        Me.lblWpList.Size = New System.Drawing.Size(521, 17)
        Me.lblWpList.TabIndex = 3
        Me.lblWpList.Text = "1：装置１　2：装置２　3：装置３　4：装置４　5：装置５　6：装置６"
        '
        'frmxxEN00M1
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(608, 491)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdKakutei)
        Me.Controls.Add(Me.vsfLotList)
        Me.Controls.Add(Me.lblInstruction)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.lblLotListCnt)
        Me.Controls.Add(Me.lblWpList)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00M1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "モニタロット一覧"
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdKakutei As Button
    Friend WithEvents vsfLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblInstruction As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblLotListCnt As Label
    Friend WithEvents lblWpList As Label
End Class
