<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02S0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02S0))
        Me.cmdClipCopy = New System.Windows.Forms.Button()
        Me.cmdLineDel = New System.Windows.Forms.Button()
        Me.cmdLineCopy = New System.Windows.Forms.Button()
        Me.cmdLineAdd = New System.Windows.Forms.Button()
        Me.cmdRegist0 = New System.Windows.Forms.Button()
        Me.cmdRegist2 = New System.Windows.Forms.Button()
        Me.cmdSDown = New System.Windows.Forms.Button()
        Me.cmdSUp = New System.Windows.Forms.Button()
        Me.cmdRegist1 = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.vsfATrayList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtComments = New SETextBoxEx.TextBoxEx()
        Me.cmbAtrayClass = New SECmbIchiran.ComboIchiran()
        Me.cmbTapeStickGr = New SECmbIchiran.ComboIchiran()
        Me.txtA_TrayId = New SETextBoxEx.TextBoxEx()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblGridCnt = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        CType(Me.vsfATrayList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.lblTitle5.SuspendLayout
        Me.SuspendLayout
        '
        'cmdClipCopy
        '
        Me.cmdClipCopy.CausesValidation = false
        Me.cmdClipCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClipCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClipCopy.Location = New System.Drawing.Point(408, 597)
        Me.cmdClipCopy.Name = "cmdClipCopy"
        Me.cmdClipCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdClipCopy.TabIndex = 6
        Me.cmdClipCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'cmdLineDel
        '
        Me.cmdLineDel.CausesValidation = false
        Me.cmdLineDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLineDel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLineDel.Location = New System.Drawing.Point(728, 597)
        Me.cmdLineDel.Name = "cmdLineDel"
        Me.cmdLineDel.Size = New System.Drawing.Size(85, 40)
        Me.cmdLineDel.TabIndex = 9
        Me.cmdLineDel.Text = "行削除"
        '
        'cmdLineCopy
        '
        Me.cmdLineCopy.CausesValidation = false
        Me.cmdLineCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLineCopy.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLineCopy.Location = New System.Drawing.Point(640, 597)
        Me.cmdLineCopy.Name = "cmdLineCopy"
        Me.cmdLineCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdLineCopy.TabIndex = 8
        Me.cmdLineCopy.Text = "行コピー"
        '
        'cmdLineAdd
        '
        Me.cmdLineAdd.CausesValidation = false
        Me.cmdLineAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLineAdd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdLineAdd.Location = New System.Drawing.Point(552, 597)
        Me.cmdLineAdd.Name = "cmdLineAdd"
        Me.cmdLineAdd.Size = New System.Drawing.Size(85, 40)
        Me.cmdLineAdd.TabIndex = 7
        Me.cmdLineAdd.Text = "行追加"
        '
        'cmdRegist0
        '
        Me.cmdRegist0.CausesValidation = false
        Me.cmdRegist0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist0.Location = New System.Drawing.Point(168, 597)
        Me.cmdRegist0.Name = "cmdRegist0"
        Me.cmdRegist0.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist0.TabIndex = 4
        Me.cmdRegist0.Text = "洗　浄"
        '
        'cmdRegist2
        '
        Me.cmdRegist2.CausesValidation = false
        Me.cmdRegist2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist2.Location = New System.Drawing.Point(888, 597)
        Me.cmdRegist2.Name = "cmdRegist2"
        Me.cmdRegist2.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist2.TabIndex = 10
        Me.cmdRegist2.Text = "確　定"
        '
        'cmdSDown
        '
        Me.cmdSDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSDown.Location = New System.Drawing.Point(947, 557)
        Me.cmdSDown.Name = "cmdSDown"
        Me.cmdSDown.Size = New System.Drawing.Size(25, 37)
        Me.cmdSDown.TabIndex = 12
        Me.cmdSDown.Text = "▼"
        '
        'cmdSUp
        '
        Me.cmdSUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSUp.Location = New System.Drawing.Point(947, 519)
        Me.cmdSUp.Name = "cmdSUp"
        Me.cmdSUp.Size = New System.Drawing.Size(25, 37)
        Me.cmdSUp.TabIndex = 11
        Me.cmdSUp.Text = "▲"
        '
        'cmdRegist1
        '
        Me.cmdRegist1.CausesValidation = false
        Me.cmdRegist1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist1.Location = New System.Drawing.Point(256, 597)
        Me.cmdRegist1.Name = "cmdRegist1"
        Me.cmdRegist1.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist1.TabIndex = 5
        Me.cmdRegist1.Text = "洗浄完了"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "閉じる"
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdNowList.Location = New System.Drawing.Point(678, 8)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 0
        Me.cmdNowList.Text = "最新取得"
        '
        'vsfATrayList
        '
        Me.vsfATrayList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfATrayList.AllowEditing = false
        Me.vsfATrayList.AutoSearchDelay = 2R
        Me.vsfATrayList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfATrayList.ColumnInfo = resources.GetString("vsfATrayList.ColumnInfo")
        Me.vsfATrayList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfATrayList.ExtendLastCol = true
        Me.vsfATrayList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfATrayList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfATrayList.Location = New System.Drawing.Point(8, 57)
        Me.vsfATrayList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfATrayList.Name = "vsfATrayList"
        Me.vsfATrayList.Rows.Count = 25
        Me.vsfATrayList.Rows.DefaultSize = 18
        Me.vsfATrayList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfATrayList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfATrayList.Size = New System.Drawing.Size(961, 449)
        Me.vsfATrayList.StyleInfo = resources.GetString("vsfATrayList.StyleInfo")
        Me.vsfATrayList.TabIndex = 1
        '
        'txtComments
        '
        Me.txtComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComments.ChrMaxByte = 0
        Me.txtComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtComments.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtComments.Location = New System.Drawing.Point(8, 535)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComments.SelectedText = ""
        Me.txtComments.Size = New System.Drawing.Size(940, 58)
        Me.txtComments.TabIndex = 2
        '
        'cmbAtrayClass
        '
        Me.cmbAtrayClass.AllSelectButton = true
        Me.cmbAtrayClass.DirectInput = false
        Me.cmbAtrayClass.DispCols = 2
        Me.cmbAtrayClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbAtrayClass.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbAtrayClass.GridForeColor = System.Drawing.Color.Black
        Me.cmbAtrayClass.GroupCols = 1
        Me.cmbAtrayClass.Location = New System.Drawing.Point(8, 24)
        Me.cmbAtrayClass.Name = "cmbAtrayClass"
        Me.cmbAtrayClass.SelectMode = 1
        Me.cmbAtrayClass.Size = New System.Drawing.Size(121, 22)
        Me.cmbAtrayClass.TabIndex = 22
        Me.cmbAtrayClass.Value = ""
        '
        'cmbTapeStickGr
        '
        Me.cmbTapeStickGr.AllSelectButton = true
        Me.cmbTapeStickGr.DirectInput = false
        Me.cmbTapeStickGr.DispCols = 2
        Me.cmbTapeStickGr.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbTapeStickGr.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbTapeStickGr.GridForeColor = System.Drawing.Color.Black
        Me.cmbTapeStickGr.GroupCols = 1
        Me.cmbTapeStickGr.Location = New System.Drawing.Point(128, 24)
        Me.cmbTapeStickGr.Name = "cmbTapeStickGr"
        Me.cmbTapeStickGr.SelectMode = 1
        Me.cmbTapeStickGr.Size = New System.Drawing.Size(169, 22)
        Me.cmbTapeStickGr.TabIndex = 23
        Me.cmbTapeStickGr.Value = ""
        '
        'txtA_TrayId
        '
        Me.txtA_TrayId.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtA_TrayId.ChrMaxByte = 0
        Me.txtA_TrayId.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtA_TrayId.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtA_TrayId.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtA_TrayId.Location = New System.Drawing.Point(296, 24)
        Me.txtA_TrayId.Name = "txtA_TrayId"
        Me.txtA_TrayId.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtA_TrayId.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtA_TrayId.SelectedText = ""
        Me.txtA_TrayId.Size = New System.Drawing.Size(153, 22)
        Me.txtA_TrayId.TabIndex = 24
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(296, 9)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(153, 17)
        Me.lblTitle2.TabIndex = 15
        Me.lblTitle2.Text = "AトレーID(部分可)"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLengthCount.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(686, 0)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(247, 17)
        Me.lblLengthCount.TabIndex = 21
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.Controls.Add(Me.lblLengthCount)
        Me.lblTitle5.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(8, 520)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(940, 17)
        Me.lblTitle5.TabIndex = 20
        Me.lblTitle5.Text = "コメント"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(889, 9)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(80, 17)
        Me.lblTitle4.TabIndex = 18
        Me.lblTitle4.Text = "該当件数"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGridCnt
        '
        Me.lblGridCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGridCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGridCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGridCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGridCnt.Location = New System.Drawing.Point(889, 25)
        Me.lblGridCnt.Name = "lblGridCnt"
        Me.lblGridCnt.Size = New System.Drawing.Size(80, 22)
        Me.lblGridCnt.TabIndex = 19
        Me.lblGridCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(765, 9)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle3.TabIndex = 16
        Me.lblTitle3.Text = "情報取得日時"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(765, 25)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(121, 22)
        Me.lblNowDate.TabIndex = 17
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(128, 9)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(169, 17)
        Me.lblTitle1.TabIndex = 14
        Me.lblTitle1.Text = "貼りグループ"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 9)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(121, 17)
        Me.lblTitle0.TabIndex = 13
        Me.lblTitle0.Text = "Aトレー区分"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02S0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblTitle5)
        Me.Controls.Add(Me.cmdClipCopy)
        Me.Controls.Add(Me.cmdLineDel)
        Me.Controls.Add(Me.cmdLineCopy)
        Me.Controls.Add(Me.cmdLineAdd)
        Me.Controls.Add(Me.cmdRegist0)
        Me.Controls.Add(Me.cmdRegist2)
        Me.Controls.Add(Me.cmdSDown)
        Me.Controls.Add(Me.cmdSUp)
        Me.Controls.Add(Me.cmdRegist1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdNowList)
        Me.Controls.Add(Me.vsfATrayList)
        Me.Controls.Add(Me.cmbAtrayClass)
        Me.Controls.Add(Me.cmbTapeStickGr)
        Me.Controls.Add(Me.txtA_TrayId)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTitle4)
        Me.Controls.Add(Me.lblGridCnt)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.txtComments)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02S0"
        Me.Text = "Aトレー管理"
        CType(Me.vsfATrayList,System.ComponentModel.ISupportInitialize).EndInit
        Me.lblTitle5.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdClipCopy As Button
    Friend WithEvents cmdLineDel As Button
    Friend WithEvents cmdLineCopy As Button
    Friend WithEvents cmdLineAdd As Button
    Friend WithEvents cmdRegist0 As Button
    Friend WithEvents cmdRegist2 As Button
    Friend WithEvents cmdSDown As Button
    Friend WithEvents cmdSUp As Button
    Friend WithEvents cmdRegist1 As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents vsfATrayList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtComments As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbAtrayClass As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbTapeStickGr As SECmbIchiran.ComboIchiran
    Friend WithEvents txtA_TrayId As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblGridCnt As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
End Class
