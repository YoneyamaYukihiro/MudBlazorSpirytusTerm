<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptxxEN00F0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptxxEN00F0))
        Me.viwSendOrderList = New C1.Win.FlexViewer.C1FlexViewer()
        Me.rptSendOrderList = New C1.Win.FlexReport.C1FlexReport()
        CType(Me.viwSendOrderList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'viwSendOrderList
        '
        Me.viwSendOrderList.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.viwSendOrderList.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.viwSendOrderList.Continuous = false
        Me.viwSendOrderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viwSendOrderList.Location = New System.Drawing.Point(0, 0)
        Me.viwSendOrderList.Name = "viwSendOrderList"
        Me.viwSendOrderList.Size = New System.Drawing.Size(985, 642)
        Me.viwSendOrderList.TabIndex = 0
        '
        'rptSendOrderList
        '
        Me.rptSendOrderList.ReportDefinition = resources.GetString("rptSendOrderList.ReportDefinition")
        Me.rptSendOrderList.ReportName = "送品伝票"
        '
        'rptxxEN00F0
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.viwSendOrderList)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "rptxxEN00F0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "送品伝票"
        CType(Me.viwSendOrderList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

	Friend WithEvents viwSendOrderList As C1.Win.FlexViewer.C1FlexViewer
	Friend WithEvents rptSendOrderList As C1.Win.FlexReport.C1FlexReport
End Class
