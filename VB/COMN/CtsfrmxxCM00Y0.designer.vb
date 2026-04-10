<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00Y0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00Y0))
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraRestrictPd = New System.Windows.Forms.GroupBox()
        Me.cmdDown2 = New System.Windows.Forms.Button()
        Me.cmdUP2 = New System.Windows.Forms.Button()
        Me.vsfRestrictPd = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdLeft = New System.Windows.Forms.Button()
        Me.cmdRight = New System.Windows.Forms.Button()
        Me.cmdUP = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.vsfUseMaterialList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblDifferencePd = New System.Windows.Forms.Label()
        Me.lblDisabled = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblPdRestrict = New System.Windows.Forms.Label()
        Me.fraRestrictPd.SuspendLayout
        CType(Me.vsfRestrictPd,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vsfUseMaterialList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(872, 580)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
        Me.cmdRegist.TabIndex = 5
        Me.cmdRegist.Text = "確　定"
        '
        'fraRestrictPd
        '
        Me.fraRestrictPd.Controls.Add(Me.cmdDown2)
        Me.fraRestrictPd.Controls.Add(Me.cmdUP2)
        Me.fraRestrictPd.Controls.Add(Me.vsfRestrictPd)
        Me.fraRestrictPd.Location = New System.Drawing.Point(8, 400)
        Me.fraRestrictPd.Name = "fraRestrictPd"
        Me.fraRestrictPd.Size = New System.Drawing.Size(376, 156)
        Me.fraRestrictPd.TabIndex = 7
        Me.fraRestrictPd.TabStop = false
        Me.fraRestrictPd.Text = "限定機種"
        '
        'cmdDown2
        '
        Me.cmdDown2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown2.Location = New System.Drawing.Point(265, 80)
        Me.cmdDown2.Name = "cmdDown2"
        Me.cmdDown2.Size = New System.Drawing.Size(49, 62)
        Me.cmdDown2.TabIndex = 10
        Me.cmdDown2.Text = "▼"
        '
        'cmdUP2
        '
        Me.cmdUP2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP2.Location = New System.Drawing.Point(265, 19)
        Me.cmdUP2.Name = "cmdUP2"
        Me.cmdUP2.Size = New System.Drawing.Size(49, 62)
        Me.cmdUP2.TabIndex = 9
        Me.cmdUP2.Text = "▲"
        '
        'vsfRestrictPd
        '
        Me.vsfRestrictPd.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfRestrictPd.AllowEditing = false
        Me.vsfRestrictPd.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfRestrictPd.AutoSearchDelay = 2R
        Me.vsfRestrictPd.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfRestrictPd.ColumnInfo = "1,0,0,0,0,110,Columns:0{Width:175;Caption:""機種"";Style:""TextAlign:LeftCenter;"";Styl"& _ 
    "eFixed:""TextAlign:CenterCenter;"";}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfRestrictPd.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfRestrictPd.ExtendLastCol = true
        Me.vsfRestrictPd.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfRestrictPd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfRestrictPd.Location = New System.Drawing.Point(18, 20)
        Me.vsfRestrictPd.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfRestrictPd.Name = "vsfRestrictPd"
        Me.vsfRestrictPd.Rows.Count = 40
        Me.vsfRestrictPd.Rows.DefaultSize = 18
        Me.vsfRestrictPd.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfRestrictPd.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfRestrictPd.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfRestrictPd.Size = New System.Drawing.Size(247, 121)
        Me.vsfRestrictPd.StyleInfo = resources.GetString("vsfRestrictPd.StyleInfo")
        Me.vsfRestrictPd.TabIndex = 8
        Me.vsfRestrictPd.TabStop = false
        '
        'cmdLeft
        '
        Me.cmdLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeft.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLeft.Location = New System.Drawing.Point(7, 338)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(460, 49)
        Me.cmdLeft.TabIndex = 3
        Me.cmdLeft.Text = "<<"
        '
        'cmdRight
        '
        Me.cmdRight.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRight.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRight.Location = New System.Drawing.Point(466, 338)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(460, 49)
        Me.cmdRight.TabIndex = 4
        Me.cmdRight.Text = ">>"
        '
        'cmdUP
        '
        Me.cmdUP.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUP.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdUP.Location = New System.Drawing.Point(925, 7)
        Me.cmdUP.Name = "cmdUP"
        Me.cmdUP.Size = New System.Drawing.Size(49, 167)
        Me.cmdUP.TabIndex = 1
        Me.cmdUP.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDown.Location = New System.Drawing.Point(925, 173)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(49, 167)
        Me.cmdDown.TabIndex = 2
        Me.cmdDown.Text = "▼"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 580)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "閉じる"
        '
        'vsfUseMaterialList
        '
        Me.vsfUseMaterialList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfUseMaterialList.AllowEditing = false
        Me.vsfUseMaterialList.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfUseMaterialList.AutoSearchDelay = 2R
        Me.vsfUseMaterialList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfUseMaterialList.ColumnInfo = resources.GetString("vsfUseMaterialList.ColumnInfo")
        Me.vsfUseMaterialList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfUseMaterialList.ExtendLastCol = true
        Me.vsfUseMaterialList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfUseMaterialList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfUseMaterialList.Location = New System.Drawing.Point(8, 8)
        Me.vsfUseMaterialList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfUseMaterialList.Name = "vsfUseMaterialList"
        Me.vsfUseMaterialList.Rows.Count = 40
        Me.vsfUseMaterialList.Rows.DefaultSize = 18
        Me.vsfUseMaterialList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfUseMaterialList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfUseMaterialList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfUseMaterialList.Size = New System.Drawing.Size(917, 330)
        Me.vsfUseMaterialList.StyleInfo = resources.GetString("vsfUseMaterialList.StyleInfo")
        Me.vsfUseMaterialList.TabIndex = 0
        Me.vsfUseMaterialList.TabStop = false
        '
        'lblDifferencePd
        '
        Me.lblDifferencePd.BackColor = System.Drawing.Color.Silver
        Me.lblDifferencePd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDifferencePd.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDifferencePd.ForeColor = System.Drawing.Color.Black
        Me.lblDifferencePd.Location = New System.Drawing.Point(604, 406)
        Me.lblDifferencePd.Name = "lblDifferencePd"
        Me.lblDifferencePd.Size = New System.Drawing.Size(108, 18)
        Me.lblDifferencePd.TabIndex = 14
        Me.lblDifferencePd.Text = "限定機種相違"
        Me.lblDifferencePd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDisabled
        '
        Me.lblDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblDisabled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDisabled.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblDisabled.ForeColor = System.Drawing.Color.Black
        Me.lblDisabled.Location = New System.Drawing.Point(498, 406)
        Me.lblDisabled.Name = "lblDisabled"
        Me.lblDisabled.Size = New System.Drawing.Size(108, 18)
        Me.lblDisabled.TabIndex = 13
        Me.lblDisabled.Text = "制約期限超過"
        Me.lblDisabled.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.Color.Yellow
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWarning.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Black
        Me.lblWarning.Location = New System.Drawing.Point(392, 406)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(108, 18)
        Me.lblWarning.TabIndex = 12
        Me.lblWarning.Text = "制約期限警告"
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdRestrict
        '
        Me.lblPdRestrict.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdRestrict.ForeColor = System.Drawing.Color.Red
        Me.lblPdRestrict.Location = New System.Drawing.Point(392, 435)
        Me.lblPdRestrict.Name = "lblPdRestrict"
        Me.lblPdRestrict.Size = New System.Drawing.Size(155, 32)
        Me.lblPdRestrict.TabIndex = 11
        Me.lblPdRestrict.Text = "機種限定あり"
        '
        'frmxxCM00Y0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.fraRestrictPd)
        Me.Controls.Add(Me.cmdLeft)
        Me.Controls.Add(Me.cmdRight)
        Me.Controls.Add(Me.cmdUP)
        Me.Controls.Add(Me.cmdDown)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.vsfUseMaterialList)
        Me.Controls.Add(Me.lblDifferencePd)
        Me.Controls.Add(Me.lblDisabled)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.lblPdRestrict)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00Y0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "使用部材選択"
        Me.fraRestrictPd.ResumeLayout(false)
        CType(Me.vsfRestrictPd,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vsfUseMaterialList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraRestrictPd As GroupBox
    Friend WithEvents cmdDown2 As Button
    Friend WithEvents cmdUP2 As Button
    Friend WithEvents vsfRestrictPd As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdLeft As Button
    Friend WithEvents cmdRight As Button
    Friend WithEvents cmdUP As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfUseMaterialList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblDifferencePd As Label
    Friend WithEvents lblDisabled As Label
    Friend WithEvents lblWarning As Label
    Friend WithEvents lblPdRestrict As Label
End Class
