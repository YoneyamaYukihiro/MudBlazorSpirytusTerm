<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00X0
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00X0))
        Me.imlMsg = New System.Windows.Forms.ImageList(Me.components)
        Me.lblInfomation2 = New System.Windows.Forms.Label()
        Me.lblInfomation1 = New System.Windows.Forms.Label()
        Me.imgMsg = New System.Windows.Forms.PictureBox()
        CType(Me.imgMsg,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'imlMsg
        '
        Me.imlMsg.ImageStream = CType(resources.GetObject("imlMsg.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imlMsg.TransparentColor = System.Drawing.Color.Transparent
        Me.imlMsg.Images.SetKeyName(0, "question")
        Me.imlMsg.Images.SetKeyName(1, "exclamation")
        Me.imlMsg.Images.SetKeyName(2, "information")
        '
        'lblInfomation2
        '
        Me.lblInfomation2.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInfomation2.Location = New System.Drawing.Point(52, 54)
        Me.lblInfomation2.Name = "lblInfomation2"
        Me.lblInfomation2.Size = New System.Drawing.Size(313, 27)
        Me.lblInfomation2.TabIndex = 1
        Me.lblInfomation2.Text = "しばらくお待ちください。"
        '
        'lblInfomation1
        '
        Me.lblInfomation1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblInfomation1.Location = New System.Drawing.Point(52, 18)
        Me.lblInfomation1.Name = "lblInfomation1"
        Me.lblInfomation1.Size = New System.Drawing.Size(345, 27)
        Me.lblInfomation1.TabIndex = 0
        Me.lblInfomation1.Text = "XXXX測定データ取得中です。"
        '
        'imgMsg
        '
        Me.imgMsg.Location = New System.Drawing.Point(4, 4)
        Me.imgMsg.Name = "imgMsg"
        Me.imgMsg.Size = New System.Drawing.Size(34, 31)
        Me.imgMsg.TabIndex = 2
        Me.imgMsg.TabStop = false
        '
        'frmxxCM00X0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(432, 110)
        Me.ControlBox = false
        Me.Controls.Add(Me.imgMsg)
        Me.Controls.Add(Me.lblInfomation2)
        Me.Controls.Add(Me.lblInfomation1)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00X0"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "処理終了"
        CType(Me.imgMsg,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents imlMsg As ImageList
    Friend WithEvents lblInfomation2 As Label
    Friend WithEvents lblInfomation1 As Label
    Friend WithEvents imgMsg As PictureBox
End Class
