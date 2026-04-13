<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptxxEN00F1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptxxEN00F1))
        Me.viwLotExamInfo = New C1.Win.FlexViewer.C1FlexViewer()
        Me.rptLotExamInfo = New C1.Win.FlexReport.C1FlexReport()
        CType(Me.viwLotExamInfo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'viwLotExamInfo
        '
        Me.viwLotExamInfo.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.viwLotExamInfo.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.viwLotExamInfo.Continuous = false
        Me.viwLotExamInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viwLotExamInfo.Location = New System.Drawing.Point(0, 0)
        Me.viwLotExamInfo.Name = "viwLotExamInfo"
        Me.viwLotExamInfo.Size = New System.Drawing.Size(985, 642)
        Me.viwLotExamInfo.TabIndex = 0
        '
        'rptLotExamInfo
        '
        Me.rptLotExamInfo.ReportDefinition = resources.GetString("rptLotExamInfo.ReportDefinition")
        Me.rptLotExamInfo.ReportName = "ロット検定表"
        '
        'rptxxEN00F1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.viwLotExamInfo)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "rptxxEN00F1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ロット検定表"
        CType(Me.viwLotExamInfo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

     Friend WithEvents viwLotExamInfo As C1.Win.FlexViewer.C1FlexViewer
     Friend WithEvents rptLotExamInfo As C1.Win.FlexReport.C1FlexReport
End Class
