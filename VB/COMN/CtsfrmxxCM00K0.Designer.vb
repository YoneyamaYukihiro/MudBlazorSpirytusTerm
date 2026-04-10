<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00K0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00K0))
        Me.cmdLotList = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdChoice = New System.Windows.Forms.Button()
        Me.cmbCarrTyp = New SEComboBoxEx.ComboBoxEx()
        Me.vsfCarrierList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblBg = New System.Windows.Forms.Label()
        CType(Me.vsfCarrierList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdLotList
        '
        Me.cmdLotList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotList.Location = New System.Drawing.Point(232, 19)
        Me.cmdLotList.Name = "cmdLotList"
        Me.cmdLotList.Size = New System.Drawing.Size(86, 43)
        Me.cmdLotList.TabIndex = 3
        Me.cmdLotList.Text = "最新取得"
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
        'cmbCarrTyp
        '
        Me.cmbCarrTyp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCarrTyp.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCarrTyp.Location = New System.Drawing.Point(16, 36)
        Me.cmbCarrTyp.Name = "cmbCarrTyp"
        Me.cmbCarrTyp.Size = New System.Drawing.Size(195, 22)
        Me.cmbCarrTyp.TabIndex = 0
        Me.cmbCarrTyp.Value = Nothing
        '
        'vsfCarrierList
        '
        Me.vsfCarrierList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCarrierList.AllowEditing = false
        Me.vsfCarrierList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfCarrierList.AutoResize = true
        Me.vsfCarrierList.AutoSearchDelay = 2R
        Me.vsfCarrierList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCarrierList.ColumnInfo = "4,0,0,0,0,105,Columns:0{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"1{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"2{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)&"3{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfCarrierList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCarrierList.ExtendLastCol = true
        Me.vsfCarrierList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfCarrierList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCarrierList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCarrierList.Location = New System.Drawing.Point(8, 80)
        Me.vsfCarrierList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCarrierList.Name = "vsfCarrierList"
        Me.vsfCarrierList.Rows.Count = 40
        Me.vsfCarrierList.Rows.DefaultSize = 18
        Me.vsfCarrierList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCarrierList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCarrierList.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None
        Me.vsfCarrierList.Size = New System.Drawing.Size(530, 310)
        Me.vsfCarrierList.StyleInfo = resources.GetString("vsfCarrierList.StyleInfo")
        Me.vsfCarrierList.TabIndex = 1
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
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(16, 20)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(195, 17)
        Me.lblTitle0.TabIndex = 8
        Me.lblTitle0.Text = "キャリアタイプ"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(450, 36)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(81, 22)
        Me.lblLotCnt.TabIndex = 5
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'frmxxCM00K0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(546, 460)
        Me.Controls.Add(Me.cmdLotList)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdChoice)
        Me.Controls.Add(Me.cmbCarrTyp)
        Me.Controls.Add(Me.vsfCarrierList)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblBg)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00K0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "空きキャリア一覧"
        CType(Me.vsfCarrierList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdLotList As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdChoice As Button
    Friend WithEvents cmbCarrTyp As SEComboBoxEx.ComboBoxEx
    Friend WithEvents vsfCarrierList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblBg As Label
End Class
