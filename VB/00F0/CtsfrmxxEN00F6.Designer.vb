<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00F6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00F6))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.fraFrame = New System.Windows.Forms.GroupBox()
        Me.vsfRework = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblReworkCount = New System.Windows.Forms.Label()
        Me.lblNowNum = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.fraFrame.SuspendLayout
        CType(Me.vsfRework,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCancel
        '
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(240, 368)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(85, 40)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "取　消"
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 368)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "閉じる"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(332, 368)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 1
        Me.cmdRegist.Text = "確　定"
        '
        'fraFrame
        '
        Me.fraFrame.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraFrame.Controls.Add(Me.vsfRework)
        Me.fraFrame.Controls.Add(Me.lblTitle2)
        Me.fraFrame.Controls.Add(Me.lblReworkCount)
        Me.fraFrame.Controls.Add(Me.lblNowNum)
        Me.fraFrame.Controls.Add(Me.lblTitle4)
        Me.fraFrame.Controls.Add(Me.lblCarrier)
        Me.fraFrame.Controls.Add(Me.lblTitle1)
        Me.fraFrame.Controls.Add(Me.lblTitle0)
        Me.fraFrame.Controls.Add(Me.lblLotID)
        Me.fraFrame.Controls.Add(Me.lblFlowClass)
        Me.fraFrame.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraFrame.Location = New System.Drawing.Point(8, 8)
        Me.fraFrame.Name = "fraFrame"
        Me.fraFrame.Size = New System.Drawing.Size(409, 349)
        Me.fraFrame.TabIndex = 0
        Me.fraFrame.TabStop = false
        Me.fraFrame.Text = "リワーク"
        '
        'vsfRework
        '
        Me.vsfRework.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfRework.AllowEditing = false
        Me.vsfRework.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfRework.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfRework.AutoSearchDelay = 2R
        Me.vsfRework.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfRework.ColumnInfo = "2,0,0,0,0,105,Columns:0{Width:72;Caption:""板厚"";StyleFixed:""TextAlign:CenterCenter;"& _ 
    """;}"&Global.Microsoft.VisualBasic.ChrW(9)&"1{Width:144;Caption:""リワーク数量"";StyleFixed:""TextAlign:CenterCenter;"";}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfRework.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfRework.ExtendLastCol = true
        Me.vsfRework.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfRework.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.vsfRework.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfRework.Location = New System.Drawing.Point(160, 72)
        Me.vsfRework.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfRework.Name = "vsfRework"
        Me.vsfRework.Rows.Count = 11
        Me.vsfRework.Rows.DefaultSize = 18
        Me.vsfRework.Rows.MaxSize = 27
        Me.vsfRework.Rows.MinSize = 20
        Me.vsfRework.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfRework.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfRework.Size = New System.Drawing.Size(238, 265)
        Me.vsfRework.StyleInfo = resources.GetString("vsfRework.StyleInfo")
        Me.vsfRework.TabIndex = 0
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(12, 72)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(137, 17)
        Me.lblTitle2.TabIndex = 13
        Me.lblTitle2.Text = "現リワーク回数"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblReworkCount
        '
        Me.lblReworkCount.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblReworkCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReworkCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblReworkCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblReworkCount.Location = New System.Drawing.Point(12, 88)
        Me.lblReworkCount.Name = "lblReworkCount"
        Me.lblReworkCount.Size = New System.Drawing.Size(137, 22)
        Me.lblReworkCount.TabIndex = 12
        Me.lblReworkCount.Text = "999,999"
        Me.lblReworkCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNowNum
        '
        Me.lblNowNum.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowNum.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowNum.Location = New System.Drawing.Point(304, 36)
        Me.lblNowNum.Name = "lblNowNum"
        Me.lblNowNum.Size = New System.Drawing.Size(93, 22)
        Me.lblNowNum.TabIndex = 11
        Me.lblNowNum.Text = "999,999"
        Me.lblNowNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(304, 20)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(93, 17)
        Me.lblTitle4.TabIndex = 10
        Me.lblTitle4.Text = "現在数量"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCarrier
        '
        Me.lblCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrier.Location = New System.Drawing.Point(12, 36)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(97, 22)
        Me.lblCarrier.TabIndex = 9
        Me.lblCarrier.Text = "GTA1234-00"
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(108, 20)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle1.TabIndex = 8
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(12, 20)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle0.TabIndex = 7
        Me.lblTitle0.Text = "キャリアID"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(108, 36)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 22)
        Me.lblLotID.TabIndex = 6
        Me.lblLotID.Text = "GTA1234-00"
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(228, 36)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 22)
        Me.lblFlowClass.TabIndex = 5
        Me.lblFlowClass.Text = "ZZ"
        '
        'frmxxEN00F6
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(428, 418)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.fraFrame)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(370, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00F6"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CF在庫リワーク"
        Me.fraFrame.ResumeLayout(false)
        CType(Me.vsfRework,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents fraFrame As GroupBox
    Friend WithEvents vsfRework As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblReworkCount As Label
    Friend WithEvents lblNowNum As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblCarrier As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblFlowClass As Label
End Class
