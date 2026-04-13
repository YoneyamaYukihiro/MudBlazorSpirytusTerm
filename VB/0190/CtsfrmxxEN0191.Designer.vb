<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN0191
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN0191))
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdNextUP = New System.Windows.Forms.Button()
        Me.cmdNextDown = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfLotScrapInfo = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.labMikakutei = New System.Windows.Forms.Label()
        CType(Me.vsfLotScrapInfo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(418, 443)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(410, 49)
        Me.cmdRight.TabIndex = 4
        Me.cmdRight.Text = ">>"
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 443)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(410, 49)
        Me.cmdLeft.TabIndex = 3
        Me.cmdLeft.Text = "<<"
        '
        'cmdNextUP
        '
        Me.cmdNextUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNextUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNextUP.Location = New System.Drawing.Point(827, 6)
        Me.cmdNextUP.Name = "cmdNextUP"
        Me.cmdNextUP.Size = New System.Drawing.Size(49, 218)
        Me.cmdNextUP.TabIndex = 1
        Me.cmdNextUP.Text = "▲"
        '
        'cmdNextDown
        '
        Me.cmdNextDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNextDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNextDown.Location = New System.Drawing.Point(827, 226)
        Me.cmdNextDown.Name = "cmdNextDown"
        Me.cmdNextDown.Size = New System.Drawing.Size(49, 218)
        Me.cmdNextDown.TabIndex = 2
        Me.cmdNextDown.Text = "▼"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 500)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "閉じる"
        '
        'vsfLotScrapInfo
        '
        Me.vsfLotScrapInfo.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfLotScrapInfo.AllowEditing = false
        Me.vsfLotScrapInfo.AutoResize = true
        Me.vsfLotScrapInfo.AutoSearchDelay = 2R
        Me.vsfLotScrapInfo.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfLotScrapInfo.ColumnInfo = resources.GetString("vsfLotScrapInfo.ColumnInfo")
        Me.vsfLotScrapInfo.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfLotScrapInfo.ExtendLastCol = true
        Me.vsfLotScrapInfo.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfLotScrapInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfLotScrapInfo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfLotScrapInfo.Location = New System.Drawing.Point(8, 7)
        Me.vsfLotScrapInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfLotScrapInfo.Name = "vsfLotScrapInfo"
        Me.vsfLotScrapInfo.Rows.DefaultSize = 18
        Me.vsfLotScrapInfo.Rows.GlyphRow = 0
        Me.vsfLotScrapInfo.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfLotScrapInfo.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfLotScrapInfo.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfLotScrapInfo.Size = New System.Drawing.Size(819, 436)
        Me.vsfLotScrapInfo.StyleInfo = resources.GetString("vsfLotScrapInfo.StyleInfo")
        Me.vsfLotScrapInfo.TabIndex = 0
        '
        'labMikakutei
        '
        Me.labMikakutei.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.labMikakutei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labMikakutei.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labMikakutei.ForeColor = System.Drawing.Color.Red
        Me.labMikakutei.Location = New System.Drawing.Point(624, 504)
        Me.labMikakutei.Name = "labMikakutei"
        Me.labMikakutei.Size = New System.Drawing.Size(249, 36)
        Me.labMikakutei.TabIndex = 6
        Me.labMikakutei.Text = " 注意！！"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"「未確定」ウェハーがあります！！"
        Me.labMikakutei.Visible = false
        '
        'frmxxEN0191
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(885, 564)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdNextUP)
        Me.Controls.Add(Me.cmdNextDown)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfLotScrapInfo)
        Me.Controls.Add(Me.labMikakutei)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN0191"
        Me.Text = "現工程不良詳細"
        CType(Me.vsfLotScrapInfo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdNextUP As Button
    Friend WithEvents cmdNextDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfLotScrapInfo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents labMikakutei As Label
End Class
