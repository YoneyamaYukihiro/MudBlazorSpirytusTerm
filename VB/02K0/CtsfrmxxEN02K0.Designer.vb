<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN02K0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN02K0))
        Me.cmdSerch = New System.Windows.Forms.Button()
        Me.cmdClipCopy = New System.Windows.Forms.Button()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmbWp = New SEComboBoxEx.ComboBoxEx()
        Me.cmbChanber = New SEComboBoxEx.ComboBoxEx()
        Me.vsfFrList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.labRefValue = New System.Windows.Forms.Label()
        Me.lblWarTime = New System.Windows.Forms.Label()
        Me.lblErrTime = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblLotCnt = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        CType(Me.vsfFrList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdSerch
        '
        Me.cmdSerch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSerch.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdSerch.Location = New System.Drawing.Point(672, 8)
        Me.cmdSerch.Name = "cmdSerch"
        Me.cmdSerch.Size = New System.Drawing.Size(85, 40)
        Me.cmdSerch.TabIndex = 2
        Me.cmdSerch.Text = "最新取得"
        '
        'cmdClipCopy
        '
        Me.cmdClipCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClipCopy.Location = New System.Drawing.Point(504, 599)
        Me.cmdClipCopy.Name = "cmdClipCopy"
        Me.cmdClipCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdClipCopy.TabIndex = 5
        Me.cmdClipCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'cmdDel
        '
        Me.cmdDel.CausesValidation = false
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdDel.Location = New System.Drawing.Point(296, 599)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(85, 40)
        Me.cmdDel.TabIndex = 4
        Me.cmdDel.Text = "行削除"
        '
        'cmdAdd
        '
        Me.cmdAdd.CausesValidation = false
        Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAdd.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(200, 599)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(85, 40)
        Me.cmdAdd.TabIndex = 3
        Me.cmdAdd.Text = "行追加"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdRegist.Location = New System.Drawing.Point(888, 599)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 6
        Me.cmdRegist.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 599)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "閉じる"
        '
        'cmbWp
        '
        Me.cmbWp.DirectInput = false
        Me.cmbWp.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWp.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbWp.GridForeColor = System.Drawing.Color.Black
        Me.cmbWp.Location = New System.Drawing.Point(8, 26)
        Me.cmbWp.Name = "cmbWp"
        Me.cmbWp.Size = New System.Drawing.Size(205, 22)
        Me.cmbWp.TabIndex = 0
        Me.cmbWp.Value = Nothing
        '
        'cmbChanber
        '
        Me.cmbChanber.DirectInput = false
        Me.cmbChanber.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbChanber.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbChanber.GridForeColor = System.Drawing.Color.Black
        Me.cmbChanber.Location = New System.Drawing.Point(216, 26)
        Me.cmbChanber.Name = "cmbChanber"
        Me.cmbChanber.Size = New System.Drawing.Size(205, 22)
        Me.cmbChanber.TabIndex = 1
        Me.cmbChanber.Value = Nothing
        '
        'vsfFrList
        '
        Me.vsfFrList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfFrList.AllowEditing = false
        Me.vsfFrList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfFrList.AutoResize = true
        Me.vsfFrList.AutoSearchDelay = 2R
        Me.vsfFrList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfFrList.ColumnInfo = resources.GetString("vsfFrList.ColumnInfo")
        Me.vsfFrList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfFrList.ExtendLastCol = true
        Me.vsfFrList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfFrList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfFrList.Location = New System.Drawing.Point(8, 72)
        Me.vsfFrList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfFrList.Name = "vsfFrList"
        Me.vsfFrList.Rows.Count = 30
        Me.vsfFrList.Rows.DefaultSize = 18
        Me.vsfFrList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfFrList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfFrList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.vsfFrList.Size = New System.Drawing.Size(967, 522)
        Me.vsfFrList.StyleInfo = resources.GetString("vsfFrList.StyleInfo")
        Me.vsfFrList.TabIndex = 8
        '
        'labRefValue
        '
        Me.labRefValue.BackColor = System.Drawing.SystemColors.ControlLight
        Me.labRefValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labRefValue.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.labRefValue.ForeColor = System.Drawing.Color.Black
        Me.labRefValue.Location = New System.Drawing.Point(473, 52)
        Me.labRefValue.Name = "labRefValue"
        Me.labRefValue.Size = New System.Drawing.Size(212, 17)
        Me.labRefValue.TabIndex = 17
        Me.labRefValue.Text = "FR異常差異基準値:100.2h "
        Me.labRefValue.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWarTime
        '
        Me.lblWarTime.BackColor = System.Drawing.Color.Yellow
        Me.lblWarTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWarTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWarTime.ForeColor = System.Drawing.Color.Black
        Me.lblWarTime.Location = New System.Drawing.Point(684, 52)
        Me.lblWarTime.Name = "lblWarTime"
        Me.lblWarTime.Size = New System.Drawing.Size(138, 17)
        Me.lblWarTime.TabIndex = 16
        Me.lblWarTime.Text = "警告時間:123.2h "
        Me.lblWarTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblErrTime
        '
        Me.lblErrTime.BackColor = System.Drawing.Color.Red
        Me.lblErrTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblErrTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblErrTime.ForeColor = System.Drawing.Color.Black
        Me.lblErrTime.Location = New System.Drawing.Point(821, 52)
        Me.lblErrTime.Name = "lblErrTime"
        Me.lblErrTime.Size = New System.Drawing.Size(154, 17)
        Me.lblErrTime.TabIndex = 15
        Me.lblErrTime.Text = "エラー時間:300.5h "
        Me.lblErrTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(216, 10)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(205, 25)
        Me.lblTitle1.TabIndex = 12
        Me.lblTitle1.Text = "処理部"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(8, 10)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(205, 25)
        Me.lblTitle0.TabIndex = 11
        Me.lblTitle0.Text = "装置"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(764, 10)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle2.TabIndex = 13
        Me.lblTitle2.Text = "情報取得日時"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(764, 26)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 21)
        Me.lblNowDate.TabIndex = 9
        '
        'lblLotCnt
        '
        Me.lblLotCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotCnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotCnt.Location = New System.Drawing.Point(894, 26)
        Me.lblLotCnt.Name = "lblLotCnt"
        Me.lblLotCnt.Size = New System.Drawing.Size(81, 21)
        Me.lblLotCnt.TabIndex = 10
        Me.lblLotCnt.Text = "0"
        Me.lblLotCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(894, 10)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(81, 17)
        Me.lblTitle3.TabIndex = 14
        Me.lblTitle3.Text = "該当件数"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxEN02K0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdSerch)
        Me.Controls.Add(Me.cmdClipCopy)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdRegist)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmbWp)
        Me.Controls.Add(Me.cmbChanber)
        Me.Controls.Add(Me.vsfFrList)
        Me.Controls.Add(Me.labRefValue)
        Me.Controls.Add(Me.lblWarTime)
        Me.Controls.Add(Me.lblErrTime)
        Me.Controls.Add(Me.lblTitle1)
        Me.Controls.Add(Me.lblTitle0)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblNowDate)
        Me.Controls.Add(Me.lblLotCnt)
        Me.Controls.Add(Me.lblTitle3)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN02K0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CONTエッチャーFR使用履歴"
        CType(Me.vsfFrList,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdSerch As Button
    Friend WithEvents cmdClipCopy As Button
    Friend WithEvents cmdDel As Button
    Friend WithEvents cmdAdd As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmbWp As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbChanber As SEComboBoxEx.ComboBoxEx
    Friend WithEvents vsfFrList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents labRefValue As Label
    Friend WithEvents lblWarTime As Label
    Friend WithEvents lblErrTime As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblLotCnt As Label
    Friend WithEvents lblTitle3 As Label
End Class
