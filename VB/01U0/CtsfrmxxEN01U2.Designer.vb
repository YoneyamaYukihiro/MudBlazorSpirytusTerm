<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01U2
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01U2))
		Me.cmdClear = New System.Windows.Forms.Button()
		Me.cmdClipPaste = New System.Windows.Forms.Button()
		Me.cmdClipCopy = New System.Windows.Forms.Button()
		Me.cmdCopy = New System.Windows.Forms.Button()
		Me.cmdRegist = New System.Windows.Forms.Button()
		Me.cmdClose = New System.Windows.Forms.Button()
		Me.vsfFbDataList = New C1.Win.C1FlexGrid.C1FlexGrid()
		Me.txtComments = New SETextBoxEx.TextBoxEx()
		Me.lblLengthCount = New System.Windows.Forms.Label()
		Me.lblTtl7 = New System.Windows.Forms.Label()
		Me.lblWpName = New System.Windows.Forms.Label()
		Me.lblReferencePhoto = New System.Windows.Forms.Label()
		Me.lblRecipe = New System.Windows.Forms.Label()
		Me.lblTitle0 = New System.Windows.Forms.Label()
		Me.lblTitle1 = New System.Windows.Forms.Label()
		Me.lblTitle2 = New System.Windows.Forms.Label()
		Me.lblTitle3 = New System.Windows.Forms.Label()
		Me.lblEmpName = New System.Windows.Forms.Label()
		Me.lblTitle4 = New System.Windows.Forms.Label()
		Me.lblEditTime = New System.Windows.Forms.Label()
		Me.lblBackGround = New System.Windows.Forms.Label()
		Me.lblShotSeparateFlag = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		CType(Me.vsfFbDataList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.lblTtl7.SuspendLayout
		Me.SuspendLayout
		'
		'cmdClear
		'
		Me.cmdClear.CausesValidation = false
		Me.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClear.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClear.Location = New System.Drawing.Point(120, 581)
		Me.cmdClear.Name = "cmdClear"
		Me.cmdClear.Size = New System.Drawing.Size(105, 57)
		Me.cmdClear.TabIndex = 2
		Me.cmdClear.Text = "表示クリア"
		'
		'cmdClipPaste
		'
		Me.cmdClipPaste.CausesValidation = false
		Me.cmdClipPaste.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClipPaste.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClipPaste.Location = New System.Drawing.Point(568, 581)
		Me.cmdClipPaste.Name = "cmdClipPaste"
		Me.cmdClipPaste.Size = New System.Drawing.Size(105, 57)
		Me.cmdClipPaste.TabIndex = 5
		Me.cmdClipPaste.Text = "ｸﾘｯﾌﾟﾎﾞｰﾄﾞ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ペースト"
		'
		'cmdClipCopy
		'
		Me.cmdClipCopy.CausesValidation = false
		Me.cmdClipCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClipCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClipCopy.Location = New System.Drawing.Point(456, 581)
		Me.cmdClipCopy.Name = "cmdClipCopy"
		Me.cmdClipCopy.Size = New System.Drawing.Size(105, 57)
		Me.cmdClipCopy.TabIndex = 4
		Me.cmdClipCopy.Text = "ｸﾘｯﾌﾟﾎﾞｰﾄﾞ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"コピー"
		'
		'cmdCopy
		'
		Me.cmdCopy.CausesValidation = false
		Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdCopy.Location = New System.Drawing.Point(232, 581)
		Me.cmdCopy.Name = "cmdCopy"
		Me.cmdCopy.Size = New System.Drawing.Size(105, 57)
		Me.cmdCopy.TabIndex = 3
		Me.cmdCopy.Text = "現在値"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"表示"
		'
		'cmdRegist
		'
		Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdRegist.Location = New System.Drawing.Point(836, 581)
		Me.cmdRegist.Name = "cmdRegist"
		Me.cmdRegist.Size = New System.Drawing.Size(105, 57)
		Me.cmdRegist.TabIndex = 6
		Me.cmdRegist.Text = "確　定"
		'
		'cmdClose
		'
		Me.cmdClose.CausesValidation = false
		Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.cmdClose.Location = New System.Drawing.Point(8, 581)
		Me.cmdClose.Name = "cmdClose"
		Me.cmdClose.Size = New System.Drawing.Size(105, 57)
		Me.cmdClose.TabIndex = 7
		Me.cmdClose.Text = "閉じる"
		'
		'vsfFbDataList
		'
		Me.vsfFbDataList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
		Me.vsfFbDataList.AllowEditing = false
		Me.vsfFbDataList.AutoSearchDelay = 2R
		Me.vsfFbDataList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
		Me.vsfFbDataList.ColumnInfo = resources.GetString("vsfFbDataList.ColumnInfo")
		Me.vsfFbDataList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
		Me.vsfFbDataList.ExtendLastCol = true
		Me.vsfFbDataList.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.vsfFbDataList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
		Me.vsfFbDataList.Location = New System.Drawing.Point(8, 120)
		Me.vsfFbDataList.Margin = New System.Windows.Forms.Padding(0)
		Me.vsfFbDataList.Name = "vsfFbDataList"
		Me.vsfFbDataList.Rows.Count = 10
		Me.vsfFbDataList.Rows.DefaultSize = 18
		Me.vsfFbDataList.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.vsfFbDataList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
		Me.vsfFbDataList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
		Me.vsfFbDataList.Size = New System.Drawing.Size(933, 361)
		Me.vsfFbDataList.StyleInfo = resources.GetString("vsfFbDataList.StyleInfo")
		Me.vsfFbDataList.TabIndex = 0
		'
		'txtComments
		'
		Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
		Me.txtComments.ChrMaxByte = 2048
		Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
		Me.txtComments.GotHighLight = false
		Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Off
		Me.txtComments.Location = New System.Drawing.Point(8, 508)
		Me.txtComments.MultiLineEx = true
		Me.txtComments.Name = "txtComments"
		Me.txtComments.NgChr = "'"
		Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
		Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
		Me.txtComments.SelectedText = ""
		Me.txtComments.Size = New System.Drawing.Size(933, 69)
		Me.txtComments.TabIndex = 1
		'
		'lblLengthCount
		'
		Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
		Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
		Me.lblLengthCount.Location = New System.Drawing.Point(659, 1)
		Me.lblLengthCount.Name = "lblLengthCount"
		Me.lblLengthCount.Size = New System.Drawing.Size(256, 17)
		Me.lblLengthCount.TabIndex = 20
		Me.lblLengthCount.Text = "（ 半角2048文字/半角2048文字 ）"
		Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
		'
		'lblTtl7
		'
		Me.lblTtl7.BackColor = System.Drawing.Color.Navy
		Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTtl7.Controls.Add(Me.lblLengthCount)
		Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
		Me.lblTtl7.Location = New System.Drawing.Point(8, 488)
		Me.lblTtl7.Name = "lblTtl7"
		Me.lblTtl7.Size = New System.Drawing.Size(933, 23)
		Me.lblTtl7.TabIndex = 19
		Me.lblTtl7.Text = "コメント"
		Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblWpName
		'
		Me.lblWpName.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblWpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblWpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblWpName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblWpName.Location = New System.Drawing.Point(16, 32)
		Me.lblWpName.Name = "lblWpName"
		Me.lblWpName.Size = New System.Drawing.Size(280, 25)
		Me.lblWpName.TabIndex = 10
		Me.lblWpName.Text = "フォトライン#1"
		'
		'lblReferencePhoto
		'
		Me.lblReferencePhoto.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblReferencePhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblReferencePhoto.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblReferencePhoto.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblReferencePhoto.Location = New System.Drawing.Point(16, 80)
		Me.lblReferencePhoto.Name = "lblReferencePhoto"
		Me.lblReferencePhoto.Size = New System.Drawing.Size(280, 25)
		Me.lblReferencePhoto.TabIndex = 12
		Me.lblReferencePhoto.Text = "フォトライン#1"
		'
		'lblRecipe
		'
		Me.lblRecipe.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblRecipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblRecipe.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblRecipe.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblRecipe.Location = New System.Drawing.Point(295, 32)
		Me.lblRecipe.Name = "lblRecipe"
		Me.lblRecipe.Size = New System.Drawing.Size(397, 25)
		Me.lblRecipe.TabIndex = 14
		Me.lblRecipe.Text = "DVD_JNH_PLYB-41"
		'
		'lblTitle0
		'
		Me.lblTitle0.BackColor = System.Drawing.Color.Navy
		Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle0.Location = New System.Drawing.Point(16, 16)
		Me.lblTitle0.Name = "lblTitle0"
		Me.lblTitle0.Size = New System.Drawing.Size(280, 17)
		Me.lblTitle0.TabIndex = 9
		Me.lblTitle0.Text = "フォト号機"
		Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle1
		'
		Me.lblTitle1.BackColor = System.Drawing.Color.Navy
		Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle1.Location = New System.Drawing.Point(16, 64)
		Me.lblTitle1.Name = "lblTitle1"
		Me.lblTitle1.Size = New System.Drawing.Size(280, 17)
		Me.lblTitle1.TabIndex = 11
		Me.lblTitle1.Text = "基準フォト号機"
		Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle2
		'
		Me.lblTitle2.BackColor = System.Drawing.Color.Navy
		Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle2.Location = New System.Drawing.Point(295, 16)
		Me.lblTitle2.Name = "lblTitle2"
		Me.lblTitle2.Size = New System.Drawing.Size(397, 17)
		Me.lblTitle2.TabIndex = 13
		Me.lblTitle2.Text = "レシピ"
		Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblTitle3
		'
		Me.lblTitle3.BackColor = System.Drawing.Color.Navy
		Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle3.Location = New System.Drawing.Point(720, 16)
		Me.lblTitle3.Name = "lblTitle3"
		Me.lblTitle3.Size = New System.Drawing.Size(204, 17)
		Me.lblTitle3.TabIndex = 15
		Me.lblTitle3.Text = "最終更新者"
		Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblEmpName
		'
		Me.lblEmpName.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblEmpName.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblEmpName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblEmpName.Location = New System.Drawing.Point(720, 32)
		Me.lblEmpName.Name = "lblEmpName"
		Me.lblEmpName.Size = New System.Drawing.Size(204, 25)
		Me.lblEmpName.TabIndex = 16
		'
		'lblTitle4
		'
		Me.lblTitle4.BackColor = System.Drawing.Color.Navy
		Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
		Me.lblTitle4.Location = New System.Drawing.Point(720, 64)
		Me.lblTitle4.Name = "lblTitle4"
		Me.lblTitle4.Size = New System.Drawing.Size(204, 17)
		Me.lblTitle4.TabIndex = 17
		Me.lblTitle4.Text = "更新日時時"
		Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblEditTime
		'
		Me.lblEditTime.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblEditTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblEditTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblEditTime.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblEditTime.Location = New System.Drawing.Point(720, 80)
		Me.lblEditTime.Name = "lblEditTime"
		Me.lblEditTime.Size = New System.Drawing.Size(204, 25)
		Me.lblEditTime.TabIndex = 18
		Me.lblEditTime.Text = "2017/01/20 17:15:01"
		'
		'lblBackGround
		'
		Me.lblBackGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblBackGround.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblBackGround.Location = New System.Drawing.Point(8, 8)
		Me.lblBackGround.Name = "lblBackGround"
		Me.lblBackGround.Size = New System.Drawing.Size(933, 105)
		Me.lblBackGround.TabIndex = 8
		'
		'lblShotSeparateFlag
		'
		Me.lblShotSeparateFlag.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lblShotSeparateFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblShotSeparateFlag.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.lblShotSeparateFlag.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblShotSeparateFlag.Location = New System.Drawing.Point(295, 80)
		Me.lblShotSeparateFlag.Name = "lblShotSeparateFlag"
		Me.lblShotSeparateFlag.Size = New System.Drawing.Size(80, 25)
		Me.lblShotSeparateFlag.TabIndex = 53
		'
		'Label1
		'
		Me.Label1.BackColor = System.Drawing.Color.Navy
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Yellow
		Me.Label1.Location = New System.Drawing.Point(295, 64)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(80, 17)
		Me.Label1.TabIndex = 52
		Me.Label1.Text = "Shot分離"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'frmxxEN01U2
		'
		Me.BackColor = System.Drawing.SystemColors.ControlLight
		Me.CancelButton = Me.cmdClose
		Me.ClientSize = New System.Drawing.Size(950, 642)
		Me.Controls.Add(Me.lblShotSeparateFlag)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.cmdClear)
		Me.Controls.Add(Me.cmdClipPaste)
		Me.Controls.Add(Me.cmdClipCopy)
		Me.Controls.Add(Me.cmdCopy)
		Me.Controls.Add(Me.cmdRegist)
		Me.Controls.Add(Me.cmdClose)
		Me.Controls.Add(Me.vsfFbDataList)
		Me.Controls.Add(Me.txtComments)
		Me.Controls.Add(Me.lblTtl7)
		Me.Controls.Add(Me.lblWpName)
		Me.Controls.Add(Me.lblReferencePhoto)
		Me.Controls.Add(Me.lblRecipe)
		Me.Controls.Add(Me.lblTitle0)
		Me.Controls.Add(Me.lblTitle1)
		Me.Controls.Add(Me.lblTitle2)
		Me.Controls.Add(Me.lblTitle3)
		Me.Controls.Add(Me.lblEmpName)
		Me.Controls.Add(Me.lblTitle4)
		Me.Controls.Add(Me.lblEditTime)
		Me.Controls.Add(Me.lblBackGround)
		Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
		Me.KeyPreview = true
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "frmxxEN01U2"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "フォトF/B patch分割パラメータ設定"
		CType(Me.vsfFbDataList,System.ComponentModel.ISupportInitialize).EndInit
		Me.lblTtl7.ResumeLayout(false)
		Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdClipPaste As Button
    Friend WithEvents cmdClipCopy As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents vsfFbDataList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblWpName As Label
    Friend WithEvents lblReferencePhoto As Label
    Friend WithEvents lblRecipe As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblEmpName As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblEditTime As Label
    Friend WithEvents lblBackGround As Label
    Friend WithEvents lblShotSeparateFlag As Label
    Friend WithEvents Label1 As Label
End Class
