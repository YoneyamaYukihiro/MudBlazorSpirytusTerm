<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01T0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01T0))
        Me.cmbWP = New SEComboBoxEx.ComboBoxEx()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdLotSearch = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdProcEnd = New System.Windows.Forms.Button()
        Me.vsfFbParameterList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbDataKind = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        CType(Me.vsfFbParameterList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmbWP
        '
        Me.cmbWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWP.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWP.Location = New System.Drawing.Point(8, 24)
        Me.cmbWP.Name = "cmbWP"
        Me.cmbWP.Size = New System.Drawing.Size(419, 28)
        Me.cmbWP.TabIndex = 0
        Me.cmbWP.Value = Nothing
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(467, 532)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(459, 49)
        Me.cmdRight.TabIndex = 7
        Me.cmdRight.Text = ">>"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 532)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(459, 49)
        Me.cmdLeft.TabIndex = 6
        Me.cmdLeft.Text = "<<"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(925, 304)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 229)
        Me.cmdDown.TabIndex = 5
        Me.cmdDown.Text = "▼"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(925, 72)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 229)
        Me.cmdUP.TabIndex = 4
        Me.cmdUP.Text = "▲"
        '
        'cmdLotSearch
        '
        Me.cmdLotSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLotSearch.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLotSearch.Location = New System.Drawing.Point(637, 8)
        Me.cmdLotSearch.Name = "cmdLotSearch"
        Me.cmdLotSearch.Size = New System.Drawing.Size(105, 57)
        Me.cmdLotSearch.TabIndex = 2
        Me.cmdLotSearch.Text = "最新取得"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 582)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "閉じる"
        '
        'cmdProcEnd
        '
        Me.cmdProcEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdProcEnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdProcEnd.Location = New System.Drawing.Point(872, 582)
        Me.cmdProcEnd.Name = "cmdProcEnd"
        Me.cmdProcEnd.Size = New System.Drawing.Size(105, 57)
        Me.cmdProcEnd.TabIndex = 8
        Me.cmdProcEnd.Text = "確　定"
        '
        'vsfFbParameterList
        '
        Me.vsfFbParameterList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfFbParameterList.AllowEditing = false
        Me.vsfFbParameterList.AutoSearchDelay = 2R
        Me.vsfFbParameterList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfFbParameterList.ColumnInfo = resources.GetString("vsfFbParameterList.ColumnInfo")
        Me.vsfFbParameterList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfFbParameterList.ExtendLastCol = true
        Me.vsfFbParameterList.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfFbParameterList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfFbParameterList.Location = New System.Drawing.Point(8, 73)
        Me.vsfFbParameterList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFbParameterList.Name = "vsfFbParameterList"
        Me.vsfFbParameterList.Rows.Count = 40
        Me.vsfFbParameterList.Rows.DefaultSize = 18
        Me.vsfFbParameterList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfFbParameterList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFbParameterList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfFbParameterList.Size = New System.Drawing.Size(917, 459)
        Me.vsfFbParameterList.StyleInfo = resources.GetString("vsfFbParameterList.StyleInfo")
        Me.vsfFbParameterList.TabIndex = 3
        '
        'cmbDataKind
        '
        Me.cmbDataKind.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDataKind.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbDataKind.Location = New System.Drawing.Point(434, 24)
        Me.cmbDataKind.Name = "cmbDataKind"
        Me.cmbDataKind.Size = New System.Drawing.Size(193, 28)
        Me.cmbDataKind.TabIndex = 1
        Me.cmbDataKind.Value = Nothing
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(434, 8)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(193, 17)
        Me.lblTitle0.TabIndex = 15
        Me.lblTitle0.Text = "データ種別"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(419, 17)
        Me.lblTitle7.TabIndex = 14
        Me.lblTitle7.Text = "フォト号機"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(746, 24)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(151, 25)
        Me.lblNowDate.TabIndex = 13
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(746, 8)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(151, 17)
        Me.lblTitle4.TabIndex = 12
        Me.lblTitle4.Text = "情報取得日時"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(900, 24)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(74, 25)
        Me.lblLotCnt.TabIndex = 11
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(900, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(74, 17)
        Me.lblTitle1.TabIndex = 10
        Me.lblTitle1.Text = "該当件数"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN01T0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmbWP)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdLotSearch)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdProcEnd)
        Me.Controls.Add(Me.vsfFbParameterList)
        Me.Controls.Add(Me.cmbDataKind)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle7)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01T0"
        Me.Text = "フォトF/B装置パラメータ変更"
        CType(Me.vsfFbParameterList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmbWP As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdLotSearch As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdProcEnd As Button
    Friend WithEvents vsfFbParameterList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbDataKind As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle1 As Label
End Class
