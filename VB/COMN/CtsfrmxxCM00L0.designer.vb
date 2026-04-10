<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00L0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00L0))
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdChoice = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfEntryList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblBg = New System.Windows.Forms.Label()
        CType(Me.vsfEntryList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(202, 20)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(86, 43)
        Me.cmdNowList.TabIndex = 2
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdChoice
        '
        Me.cmdChoice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChoice.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdChoice.Location = New System.Drawing.Point(422, 403)
        Me.cmdChoice.Name = "cmdChoice"
        Me.cmdChoice.Size = New System.Drawing.Size(86, 43)
        Me.cmdChoice.TabIndex = 1
        Me.cmdChoice.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 403)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(86, 43)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "閉じる"
        '
        'vsfEntryList
        '
        Me.vsfEntryList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfEntryList.AllowEditing = false
        Me.vsfEntryList.AutoResize = true
        Me.vsfEntryList.AutoSearchDelay = 2R
        Me.vsfEntryList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfEntryList.ColumnInfo = resources.GetString("vsfEntryList.ColumnInfo")
        Me.vsfEntryList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfEntryList.ExtendLastCol = true
        Me.vsfEntryList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfEntryList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfEntryList.Location = New System.Drawing.Point(8, 80)
        Me.vsfEntryList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfEntryList.Name = "vsfEntryList"
        Me.vsfEntryList.Rows.Count = 40
        Me.vsfEntryList.Rows.DefaultSize = 18
        Me.vsfEntryList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfEntryList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfEntryList.Size = New System.Drawing.Size(500, 305)
        Me.vsfEntryList.StyleInfo = resources.GetString("vsfEntryList.StyleInfo")
        Me.vsfEntryList.TabIndex = 0
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(420, 36)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(81, 22)
        Me.lblLotCnt.TabIndex = 7
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(294, 36)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
        Me.lblNowDate.TabIndex = 6
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(420, 20)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(81, 17)
        Me.lblTitle3.TabIndex = 5
        Me.lblTitle3.Text = "該当件数"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(294, 20)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle4.TabIndex = 4
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBg
        '
        Me.lblBg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBg.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBg.Location = New System.Drawing.Point(8, 8)
        Me.lblBg.Name = "lblBg"
        Me.lblBg.Size = New System.Drawing.Size(500, 65)
        Me.lblBg.TabIndex = 8
        '
        'frmxxCM00L0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(522, 460)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.cmdChoice)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfEntryList)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblBg)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00L0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "機種エントリ選択"
        CType(Me.vsfEntryList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdChoice As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfEntryList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblBg As Label
End Class
