<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02U1
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02U1))
		Me.cmdAfterJReserveList = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.cmdChoice = New System.Windows.Forms.Button()
		Me.vsfAfterJReserveList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.lblTitle4 = New System.Windows.Forms.Label()
		Me.lblTitle3 = New System.Windows.Forms.Label()
		Me.lblNowDate = New System.Windows.Forms.Label()
		Me.lblAfterJReserveCnt = New System.Windows.Forms.Label()
		Me.lblBg = New System.Windows.Forms.Label()
		CType(Me.vsfAfterJReserveList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'cmdAfterJReserveList
		'
		Me.cmdAfterJReserveList.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdAfterJReserveList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdAfterJReserveList.Location = New System.Drawing.Point(232, 19)
		Me.cmdAfterJReserveList.Name = "cmdAfterJReserveList"
		Me.cmdAfterJReserveList.Size = New System.Drawing.Size(86, 43)
		Me.cmdAfterJReserveList.TabIndex = 3
		Me.cmdAfterJReserveList.Text = "最新取得"
		'
		'cmdClose
		'
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(7, 403)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(86, 43)
		Me.cmdClose.TabIndex = 4
		Me.cmdClose.Text = "閉じる"
		'
		'cmdChoice
		'
		Me.cmdChoice.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdChoice.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdChoice.Location = New System.Drawing.Point(453, 403)
		Me.cmdChoice.Name = "cmdChoice"
		Me.cmdChoice.Size = New System.Drawing.Size(86, 43)
		Me.cmdChoice.TabIndex = 2
		Me.cmdChoice.Text = "確　定"
		'
		'vsfAfterJReserveList
		'
		Me.vsfAfterJReserveList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfAfterJReserveList.AllowEditing = false
		Me.vsfAfterJReserveList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
		Me.vsfAfterJReserveList.AutoResize = true
		Me.vsfAfterJReserveList.AutoSearchDelay = 2R
		Me.vsfAfterJReserveList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfAfterJReserveList.ColumnInfo = resources.GetString("vsfAfterJReserveList.ColumnInfo")
		Me.vsfAfterJReserveList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfAfterJReserveList.ExtendLastCol = true
		Me.vsfAfterJReserveList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
		Me.vsfAfterJReserveList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfAfterJReserveList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfAfterJReserveList.Location = New System.Drawing.Point(8, 80)
		Me.vsfAfterJReserveList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfAfterJReserveList.Name = "vsfAfterJReserveList"
		Me.vsfAfterJReserveList.Rows.Count = 40
		Me.vsfAfterJReserveList.Rows.DefaultSize = 18
		Me.vsfAfterJReserveList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfAfterJReserveList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfAfterJReserveList.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None
		Me.vsfAfterJReserveList.Size = New System.Drawing.Size(530, 310)
		Me.vsfAfterJReserveList.StyleInfo = resources.GetString("vsfAfterJReserveList.StyleInfo")
		Me.vsfAfterJReserveList.TabIndex = 1
		'
		'lblTitle4
		'
		Me.lblTitle4.BackColor = System.Drawing.Color.Navy
		Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle4.Location = New System.Drawing.Point(324, 20)
		Me.lblTitle4.Name = "lblTitle4"
		Me.lblTitle4.Size = New System.Drawing.Size(122, 17)
		Me.lblTitle4.TabIndex = 10
		Me.lblTitle4.Text = "情報取得日時"
		Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle3
		'
		Me.lblTitle3.BackColor = System.Drawing.Color.Navy
		Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle3.Location = New System.Drawing.Point(450, 20)
		Me.lblTitle3.Name = "lblTitle3"
		Me.lblTitle3.Size = New System.Drawing.Size(81, 17)
		Me.lblTitle3.TabIndex = 9
		Me.lblTitle3.Text = "該当件数"
		Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblNowDate
		'
		Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblNowDate.Location = New System.Drawing.Point(324, 36)
		Me.lblNowDate.Name = "lblNowDate"
		Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
		Me.lblNowDate.TabIndex = 6
		Me.lblNowDate.Text = "07/15 13:11:25"
		'
		'lblAfterJReserveCnt
		'
		Me.lblAfterJReserveCnt.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblAfterJReserveCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblAfterJReserveCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblAfterJReserveCnt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblAfterJReserveCnt.Location = New System.Drawing.Point(450, 36)
		Me.lblAfterJReserveCnt.Name = "lblAfterJReserveCnt"
		Me.lblAfterJReserveCnt.Size = New System.Drawing.Size(81, 22)
		Me.lblAfterJReserveCnt.TabIndex = 5
		Me.lblAfterJReserveCnt.Text = "0"
		Me.lblAfterJReserveCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblBg
		'
		Me.lblBg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblBg.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblBg.Location = New System.Drawing.Point(8, 8)
		Me.lblBg.Name = "lblBg"
		Me.lblBg.Size = New System.Drawing.Size(530, 65)
		Me.lblBg.TabIndex = 7
		'
		'frmxxEN02U1
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(546, 460)
		Me.Controls.Add(Me.cmdAfterJReserveList)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.cmdChoice)
		Me.Controls.Add(Me.vsfAfterJReserveList)
		Me.Controls.Add(Me.lblTitle4)
		Me.Controls.Add(Me.lblTitle3)
		Me.Controls.Add(Me.lblNowDate)
		Me.Controls.Add(Me.lblAfterJReserveCnt)
		Me.Controls.Add(Me.lblBg)
		Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN02U1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "蒸着後流動予約情報一覧"
		CType(Me.vsfAfterJReserveList,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdAfterJReserveList As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdChoice As Button
    Friend WithEvents vsfAfterJReserveList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblAfterJReserveCnt As Label
    Friend WithEvents lblBg As Label
End Class
