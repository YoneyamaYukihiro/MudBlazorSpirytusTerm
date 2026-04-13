<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN00F4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN00F4))
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdCommentUp = New System.Windows.Forms.Button()
        Me.cmdCommentDown = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtComment = New SETextBoxEx.TextBoxEx()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblCarrier = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'cmdRegist
        '
        Me.cmdRegist.CausesValidation = false
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(666, 272)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 3
        Me.cmdRegist.Text = "確　定"
        '
        'cmdCommentUp
        '
        Me.cmdCommentUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentUp.Location = New System.Drawing.Point(726, 56)
        Me.cmdCommentUp.Name = "cmdCommentUp"
        Me.cmdCommentUp.Size = New System.Drawing.Size(25, 103)
        Me.cmdCommentUp.TabIndex = 1
        Me.cmdCommentUp.Text = "▲"
        '
        'cmdCommentDown
        '
        Me.cmdCommentDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentDown.Location = New System.Drawing.Point(726, 159)
        Me.cmdCommentDown.Name = "cmdCommentDown"
        Me.cmdCommentDown.Size = New System.Drawing.Size(25, 103)
        Me.cmdCommentDown.TabIndex = 2
        Me.cmdCommentDown.Text = "▼"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 272)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "閉じる"
        '
        'txtComment
        '
        Me.txtComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComment.ChrMaxByte = 2048
        Me.txtComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 13.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtComment.GotHighLight = false
        Me.txtComment.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtComment.Location = New System.Drawing.Point(8, 73)
        Me.txtComment.MultiLineEx = true
        Me.txtComment.Name = "txtComment"
        Me.txtComment.NgChr = "'"
        Me.txtComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComment.SelectedText = ""
        Me.txtComment.Size = New System.Drawing.Size(718, 189)
        Me.txtComment.TabIndex = 0
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(8, 8)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(97, 17)
        Me.lblTitle2.TabIndex = 11
        Me.lblTitle2.Text = "キャリアID"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCarrier
        '
        Me.lblCarrier.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrier.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblCarrier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrier.Location = New System.Drawing.Point(8, 24)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(97, 22)
        Me.lblCarrier.TabIndex = 10
        Me.lblCarrier.Text = "GTA1234-00"
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(224, 24)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 22)
        Me.lblFlowClass.TabIndex = 9
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(104, 24)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 22)
        Me.lblLotID.TabIndex = 8
        Me.lblLotID.Text = "GTA1234-00"
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(104, 8)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(185, 17)
        Me.lblTitle1.TabIndex = 7
        Me.lblTitle1.Text = "ロットID"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(460, 57)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(249, 15)
        Me.lblLengthCount.TabIndex = 6
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 56)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(718, 17)
        Me.lblTitle0.TabIndex = 5
        Me.lblTitle0.Text = "コメント"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN00F4
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(762, 319)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdCommentUp)
        Me.Controls.Add(Me.cmdCommentDown)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblCarrier)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblLengthCount)
        Me.Controls.Add(Me.lblTitle0)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN00F4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "コメント"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdCommentUp As Button
    Friend WithEvents cmdCommentDown As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtComment As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblCarrier As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle0 As Label
End Class
