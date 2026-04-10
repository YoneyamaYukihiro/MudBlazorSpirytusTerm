<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00I0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00I0))
        Me.fraWp = New System.Windows.Forms.GroupBox()
        Me.cmbMcGroupName = New SEComboBoxEx.ComboBoxEx()
        Me.cmbWpID = New SEComboBoxEx.ComboBoxEx()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.fraLot = New System.Windows.Forms.GroupBox()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.vsfLotList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtAddLotID = New SETextBoxEx.TextBoxEx()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.fraSelect = New System.Windows.Forms.GroupBox()
        Me.optAbnormal2 = New System.Windows.Forms.RadioButton()
        Me.optAbnormal1 = New System.Windows.Forms.RadioButton()
        Me.optAbnormal0 = New System.Windows.Forms.RadioButton()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.fraWp.SuspendLayout
        Me.fraLot.SuspendLayout
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraSelect.SuspendLayout
        Me.SuspendLayout
        '
        'fraWp
        '
        Me.fraWp.Controls.Add(Me.cmbMcGroupName)
        Me.fraWp.Controls.Add(Me.cmbWpID)
        Me.fraWp.Controls.Add(Me.lblTitle4)
        Me.fraWp.Controls.Add(Me.lblTitle3)
        Me.fraWp.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraWp.Location = New System.Drawing.Point(420, 152)
        Me.fraWp.Name = "fraWp"
        Me.fraWp.Size = New System.Drawing.Size(337, 169)
        Me.fraWp.TabIndex = 8
        Me.fraWp.TabStop = false
        Me.fraWp.Text = "装置選択"
        '
        'cmbMcGroupName
        '
        Me.cmbMcGroupName.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbMcGroupName.Location = New System.Drawing.Point(20, 52)
        Me.cmbMcGroupName.Name = "cmbMcGroupName"
        Me.cmbMcGroupName.Size = New System.Drawing.Size(297, 28)
        Me.cmbMcGroupName.TabIndex = 8
        Me.cmbMcGroupName.Value = Nothing
        '
        'cmbWpID
        '
        Me.cmbWpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWpID.Location = New System.Drawing.Point(20, 116)
        Me.cmbWpID.Name = "cmbWpID"
        Me.cmbWpID.Size = New System.Drawing.Size(297, 28)
        Me.cmbWpID.TabIndex = 9
        Me.cmbWpID.Value = Nothing
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(20, 100)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(297, 17)
        Me.lblTitle4.TabIndex = 17
        Me.lblTitle4.Text = "装置名"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(20, 36)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(297, 17)
        Me.lblTitle3.TabIndex = 16
        Me.lblTitle3.Text = "装置グループ"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraLot
        '
        Me.fraLot.Controls.Add(Me.cmdUP)
        Me.fraLot.Controls.Add(Me.cmdDown)
        Me.fraLot.Controls.Add(Me.cmdDel)
        Me.fraLot.Controls.Add(Me.vsfLotList)
        Me.fraLot.Controls.Add(Me.txtAddLotID)
        Me.fraLot.Controls.Add(Me.lblTitle0)
        Me.fraLot.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraLot.Location = New System.Drawing.Point(8, 152)
        Me.fraLot.Name = "fraLot"
        Me.fraLot.Size = New System.Drawing.Size(401, 345)
        Me.fraLot.TabIndex = 2
        Me.fraLot.TabStop = false
        Me.fraLot.Text = "起案ロットID"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(204, 99)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 109)
        Me.cmdUP.TabIndex = 5
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(204, 208)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 109)
        Me.cmdDown.TabIndex = 6
        Me.cmdDown.Text = "▼"
        '
        'cmdDel
        '
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDel.Location = New System.Drawing.Point(272, 100)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(105, 57)
        Me.cmdDel.TabIndex = 7
        Me.cmdDel.Text = "行削除"
        '
        'vsfLotList
        '
        Me.vsfLotList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotList.AllowEditing = false
        Me.vsfLotList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfLotList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfLotList.AutoResize = true
        Me.vsfLotList.AutoSearchDelay = 2R
        Me.vsfLotList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotList.ColumnInfo = "1,0,0,0,0,105,Columns:0{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfLotList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotList.ExtendLastCol = true
        Me.vsfLotList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotList.Location = New System.Drawing.Point(20, 100)
        Me.vsfLotList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotList.Name = "vsfLotList"
        Me.vsfLotList.Rows.DefaultSize = 18
        Me.vsfLotList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfLotList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfLotList.Size = New System.Drawing.Size(185, 216)
        Me.vsfLotList.StyleInfo = resources.GetString("vsfLotList.StyleInfo")
        Me.vsfLotList.TabIndex = 4
        '
        'txtAddLotID
        '
        Me.txtAddLotID.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtAddLotID.ChrMaxByte = 10
        Me.txtAddLotID.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtAddLotID.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtAddLotID.Location = New System.Drawing.Point(20, 53)
        Me.txtAddLotID.Name = "txtAddLotID"
        Me.txtAddLotID.NgChr = "'"
        Me.txtAddLotID.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtAddLotID.NumMax = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.txtAddLotID.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAddLotID.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAddLotID.SelectedText = ""
        Me.txtAddLotID.Size = New System.Drawing.Size(233, 30)
        Me.txtAddLotID.TabIndex = 3
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(20, 36)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(233, 17)
        Me.lblTitle0.TabIndex = 14
        Me.lblTitle0.Text = "追加ロットID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraSelect
        '
        Me.fraSelect.Controls.Add(Me.optAbnormal2)
        Me.fraSelect.Controls.Add(Me.optAbnormal1)
        Me.fraSelect.Controls.Add(Me.optAbnormal0)
        Me.fraSelect.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSelect.Location = New System.Drawing.Point(8, 8)
        Me.fraSelect.Name = "fraSelect"
        Me.fraSelect.Size = New System.Drawing.Size(749, 133)
        Me.fraSelect.TabIndex = 0
        Me.fraSelect.TabStop = false
        Me.fraSelect.Text = "処理選択"
        '
        'optAbnormal2
        '
        Me.optAbnormal2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optAbnormal2.Location = New System.Drawing.Point(384, 36)
        Me.optAbnormal2.Name = "optAbnormal2"
        Me.optAbnormal2.Size = New System.Drawing.Size(333, 25)
        Me.optAbnormal2.TabIndex = 2
        Me.optAbnormal2.Text = "工程異常処理票登録(装置)"
        '
        'optAbnormal1
        '
        Me.optAbnormal1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optAbnormal1.Location = New System.Drawing.Point(20, 84)
        Me.optAbnormal1.Name = "optAbnormal1"
        Me.optAbnormal1.Size = New System.Drawing.Size(333, 25)
        Me.optAbnormal1.TabIndex = 1
        Me.optAbnormal1.Text = "不適合品処理票登録(ロット)"
        '
        'optAbnormal0
        '
        Me.optAbnormal0.Checked = true
        Me.optAbnormal0.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.optAbnormal0.Location = New System.Drawing.Point(20, 36)
        Me.optAbnormal0.Name = "optAbnormal0"
        Me.optAbnormal0.Size = New System.Drawing.Size(333, 25)
        Me.optAbnormal0.TabIndex = 0
        Me.optAbnormal0.TabStop = true
        Me.optAbnormal0.Text = "工程異常処理票登録(ロット)"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(874, 574)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 10
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 574)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 11
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxCM00I0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.fraWp)
        Me.Controls.Add(Me.fraLot)
        Me.Controls.Add(Me.fraSelect)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00I0"
        Me.Text = "工程異常/不適合品処理票登録"
        Me.fraWp.ResumeLayout(false)
        Me.fraLot.ResumeLayout(false)
        CType(Me.vsfLotList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraSelect.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fraWp As GroupBox
    Friend WithEvents cmbMcGroupName As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbWpID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents fraLot As GroupBox
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdDel As Button
    Friend WithEvents vsfLotList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtAddLotID As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents fraSelect As GroupBox
    Friend WithEvents optAbnormal2 As RadioButton
    Friend WithEvents optAbnormal1 As RadioButton
    Friend WithEvents optAbnormal0 As RadioButton
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
End Class
