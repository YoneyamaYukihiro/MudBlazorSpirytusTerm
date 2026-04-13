<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxEN01B0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxEN01B0))
        Me.picRightAllow = New System.Windows.Forms.PictureBox()
        Me.cmdKakutei = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.txtCarrier = New SETextBoxEx.TextBoxEx()
        Me.lblTtl8 = New System.Windows.Forms.Label()
        Me.lblStepID = New System.Windows.Forms.Label()
        Me.lblOpID = New System.Windows.Forms.Label()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.lblTtl6 = New System.Windows.Forms.Label()
        Me.lblTtl4 = New System.Windows.Forms.Label()
        Me.lblStartDayTime = New System.Windows.Forms.Label()
        Me.lblS = New System.Windows.Forms.Label()
        Me.lblTtl5 = New System.Windows.Forms.Label()
        Me.lblTtl3 = New System.Windows.Forms.Label()
        Me.lblPdID = New System.Windows.Forms.Label()
        Me.lblLotManager = New System.Windows.Forms.Label()
        Me.lblTtl9 = New System.Windows.Forms.Label()
        Me.lblTimeLimit = New System.Windows.Forms.Label()
        Me.lblTtl10 = New System.Windows.Forms.Label()
        Me.lblWFNo = New System.Windows.Forms.Label()
        Me.lblWP = New System.Windows.Forms.Label()
        Me.lblNewStatus = New System.Windows.Forms.Label()
        Me.lblOldStatus = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.lblTtl7 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.lblFlowClass = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.lblTtl11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblGRB = New System.Windows.Forms.Label()
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'picRightAllow
        '
        Me.picRightAllow.Image = CType(resources.GetObject("picRightAllow.Image"),System.Drawing.Image)
        Me.picRightAllow.Location = New System.Drawing.Point(188, 188)
        Me.picRightAllow.Name = "picRightAllow"
        Me.picRightAllow.Size = New System.Drawing.Size(32, 32)
        Me.picRightAllow.TabIndex = 32
        Me.picRightAllow.TabStop = false
        '
        'cmdKakutei
        '
        Me.cmdKakutei.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKakutei.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdKakutei.Location = New System.Drawing.Point(872, 579)
        Me.cmdKakutei.Name = "cmdKakutei"
        Me.cmdKakutei.Size = New System.Drawing.Size(105, 57)
        Me.cmdKakutei.TabIndex = 1
        Me.cmdKakutei.Text = "確　定"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdClose.Location = New System.Drawing.Point(8, 579)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(105, 57)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "閉じる"
        '
        'txtCarrier
        '
        Me.txtCarrier.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrier.ChrMaxByte = 6
        Me.txtCarrier.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrier.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCarrier.Location = New System.Drawing.Point(16, 32)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrier.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrier.SelectedText = ""
        Me.txtCarrier.Size = New System.Drawing.Size(185, 30)
        Me.txtCarrier.TabIndex = 0
        '
        'lblTtl8
        '
        Me.lblTtl8.BackColor = System.Drawing.Color.Navy
        Me.lblTtl8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl8.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl8.Location = New System.Drawing.Point(408, 64)
        Me.lblTtl8.Name = "lblTtl8"
        Me.lblTtl8.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl8.TabIndex = 31
        Me.lblTtl8.Text = "小工程"
        Me.lblTtl8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStepID
        '
        Me.lblStepID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStepID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStepID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStepID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStepID.Location = New System.Drawing.Point(408, 80)
        Me.lblStepID.Name = "lblStepID"
        Me.lblStepID.Size = New System.Drawing.Size(281, 25)
        Me.lblStepID.TabIndex = 30
        Me.lblStepID.Text = "ﾅﾝﾊﾞﾘﾝｸﾞ"
        '
        'lblOpID
        '
        Me.lblOpID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOpID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOpID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOpID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOpID.Location = New System.Drawing.Point(408, 32)
        Me.lblOpID.Name = "lblOpID"
        Me.lblOpID.Size = New System.Drawing.Size(281, 25)
        Me.lblOpID.TabIndex = 29
        Me.lblOpID.Text = "投入"
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(408, 16)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(281, 17)
        Me.lblTtl2.TabIndex = 28
        Me.lblTtl2.Text = "大工程"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl6
        '
        Me.lblTtl6.BackColor = System.Drawing.Color.Navy
        Me.lblTtl6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl6.Location = New System.Drawing.Point(868, 16)
        Me.lblTtl6.Name = "lblTtl6"
        Me.lblTtl6.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl6.TabIndex = 27
        Me.lblTtl6.Text = "特殊特性"
        Me.lblTtl6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl4
        '
        Me.lblTtl4.BackColor = System.Drawing.Color.Navy
        Me.lblTtl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl4.Location = New System.Drawing.Point(688, 16)
        Me.lblTtl4.Name = "lblTtl4"
        Me.lblTtl4.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl4.TabIndex = 26
        Me.lblTtl4.Text = "処理開始日時"
        Me.lblTtl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStartDayTime
        '
        Me.lblStartDayTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStartDayTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDayTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStartDayTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStartDayTime.Location = New System.Drawing.Point(688, 32)
        Me.lblStartDayTime.Name = "lblStartDayTime"
        Me.lblStartDayTime.Size = New System.Drawing.Size(181, 25)
        Me.lblStartDayTime.TabIndex = 25
        Me.lblStartDayTime.Text = "2004/12/04 13:30"
        '
        'lblS
        '
        Me.lblS.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblS.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblS.Location = New System.Drawing.Point(868, 32)
        Me.lblS.Name = "lblS"
        Me.lblS.Size = New System.Drawing.Size(97, 25)
        Me.lblS.TabIndex = 24
        Me.lblS.Text = "なし"
        '
        'lblTtl5
        '
        Me.lblTtl5.BackColor = System.Drawing.Color.Navy
        Me.lblTtl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl5.Location = New System.Drawing.Point(312, 16)
        Me.lblTtl5.Name = "lblTtl5"
        Me.lblTtl5.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl5.TabIndex = 23
        Me.lblTtl5.Text = "数量"
        Me.lblTtl5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl3
        '
        Me.lblTtl3.BackColor = System.Drawing.Color.Navy
        Me.lblTtl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl3.Location = New System.Drawing.Point(216, 16)
        Me.lblTtl3.Name = "lblTtl3"
        Me.lblTtl3.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl3.TabIndex = 22
        Me.lblTtl3.Text = "機種"
        Me.lblTtl3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPdID
        '
        Me.lblPdID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPdID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPdID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPdID.Location = New System.Drawing.Point(216, 32)
        Me.lblPdID.Name = "lblPdID"
        Me.lblPdID.Size = New System.Drawing.Size(97, 25)
        Me.lblPdID.TabIndex = 21
        Me.lblPdID.Text = "GTA"
        '
        'lblLotManager
        '
        Me.lblLotManager.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotManager.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotManager.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotManager.Location = New System.Drawing.Point(688, 80)
        Me.lblLotManager.Name = "lblLotManager"
        Me.lblLotManager.Size = New System.Drawing.Size(181, 25)
        Me.lblLotManager.TabIndex = 20
        Me.lblLotManager.Text = "笹谷　伸司"
        '
        'lblTtl9
        '
        Me.lblTtl9.BackColor = System.Drawing.Color.Navy
        Me.lblTtl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl9.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl9.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl9.Location = New System.Drawing.Point(688, 64)
        Me.lblTtl9.Name = "lblTtl9"
        Me.lblTtl9.Size = New System.Drawing.Size(181, 17)
        Me.lblTtl9.TabIndex = 19
        Me.lblTtl9.Text = "ロット担当"
        Me.lblTtl9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTimeLimit
        '
        Me.lblTimeLimit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblTimeLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeLimit.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTimeLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTimeLimit.Location = New System.Drawing.Point(312, 80)
        Me.lblTimeLimit.Name = "lblTimeLimit"
        Me.lblTimeLimit.Size = New System.Drawing.Size(97, 25)
        Me.lblTimeLimit.TabIndex = 18
        Me.lblTimeLimit.Text = "無し"
        '
        'lblTtl10
        '
        Me.lblTtl10.BackColor = System.Drawing.Color.Navy
        Me.lblTtl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl10.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl10.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl10.Location = New System.Drawing.Point(312, 64)
        Me.lblTtl10.Name = "lblTtl10"
        Me.lblTtl10.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl10.TabIndex = 17
        Me.lblTtl10.Text = "時間制限"
        Me.lblTtl10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWFNo
        '
        Me.lblWFNo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWFNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWFNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWFNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWFNo.Location = New System.Drawing.Point(312, 32)
        Me.lblWFNo.Name = "lblWFNo"
        Me.lblWFNo.Size = New System.Drawing.Size(97, 25)
        Me.lblWFNo.TabIndex = 16
        Me.lblWFNo.Text = "8"
        Me.lblWFNo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblWP
        '
        Me.lblWP.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblWP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWP.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblWP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWP.Location = New System.Drawing.Point(8, 140)
        Me.lblWP.Name = "lblWP"
        Me.lblWP.Size = New System.Drawing.Size(231, 30)
        Me.lblWP.TabIndex = 15
        '
        'lblNewStatus
        '
        Me.lblNewStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNewStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNewStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblNewStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNewStatus.Location = New System.Drawing.Point(240, 197)
        Me.lblNewStatus.Name = "lblNewStatus"
        Me.lblNewStatus.Size = New System.Drawing.Size(161, 25)
        Me.lblNewStatus.TabIndex = 14
        Me.lblNewStatus.Text = "作業待ち"
        '
        'lblOldStatus
        '
        Me.lblOldStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblOldStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOldStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblOldStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOldStatus.Location = New System.Drawing.Point(7, 197)
        Me.lblOldStatus.Name = "lblOldStatus"
        Me.lblOldStatus.Size = New System.Drawing.Size(161, 25)
        Me.lblOldStatus.TabIndex = 13
        Me.lblOldStatus.Text = "前処理"
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(240, 181)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle3.TabIndex = 12
        Me.lblTitle3.Text = "再測定後"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(7, 181)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(161, 17)
        Me.lblTitle2.TabIndex = 11
        Me.lblTitle2.Text = "再測定前"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl7
        '
        Me.lblTtl7.BackColor = System.Drawing.Color.Navy
        Me.lblTtl7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl7.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl7.Location = New System.Drawing.Point(216, 64)
        Me.lblTtl7.Name = "lblTtl7"
        Me.lblTtl7.Size = New System.Drawing.Size(97, 17)
        Me.lblTtl7.TabIndex = 10
        Me.lblTtl7.Text = "状態"
        Me.lblTtl7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblStatus.Location = New System.Drawing.Point(216, 80)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(97, 25)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "待機中"
        '
        'lblLotID
        '
        Me.lblLotID.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLotID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLotID.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblLotID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLotID.Location = New System.Drawing.Point(16, 80)
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(121, 25)
        Me.lblLotID.TabIndex = 8
        Me.lblLotID.Text = "GTA1234-00"
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(16, 16)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl0.TabIndex = 7
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFlowClass
        '
        Me.lblFlowClass.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblFlowClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlowClass.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFlowClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFlowClass.Location = New System.Drawing.Point(136, 80)
        Me.lblFlowClass.Name = "lblFlowClass"
        Me.lblFlowClass.Size = New System.Drawing.Size(65, 25)
        Me.lblFlowClass.TabIndex = 6
        Me.lblFlowClass.Text = "ZZ"
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(16, 64)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(185, 17)
        Me.lblTtl1.TabIndex = 5
        Me.lblTtl1.Text = "ロットID"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblBack.Location = New System.Drawing.Point(8, 8)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(965, 105)
        Me.lblBack.TabIndex = 4
        '
        'lblTtl11
        '
        Me.lblTtl11.BackColor = System.Drawing.Color.Navy
        Me.lblTtl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblTtl11.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl11.Location = New System.Drawing.Point(8, 124)
        Me.lblTtl11.Name = "lblTtl11"
        Me.lblTtl11.Size = New System.Drawing.Size(231, 17)
        Me.lblTtl11.TabIndex = 3
        Me.lblTtl11.Text = "装置名"
        Me.lblTtl11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Navy
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(868, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 17)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "GRB"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGRB
        '
        Me.lblGRB.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblGRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGRB.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblGRB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGRB.Location = New System.Drawing.Point(868, 80)
        Me.lblGRB.Name = "lblGRB"
        Me.lblGRB.Size = New System.Drawing.Size(97, 25)
        Me.lblGRB.TabIndex = 34
        '
        'frmxxEN01B0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.lblGRB)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.picRightAllow)
        Me.Controls.Add(Me.cmdKakutei)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.lblTtl8)
        Me.Controls.Add(Me.lblStepID)
        Me.Controls.Add(Me.lblOpID)
        Me.Controls.Add(Me.lblTtl2)
        Me.Controls.Add(Me.lblTtl6)
        Me.Controls.Add(Me.lblTtl4)
        Me.Controls.Add(Me.lblStartDayTime)
        Me.Controls.Add(Me.lblS)
        Me.Controls.Add(Me.lblTtl5)
        Me.Controls.Add(Me.lblTtl3)
        Me.Controls.Add(Me.lblPdID)
        Me.Controls.Add(Me.lblLotManager)
        Me.Controls.Add(Me.lblTtl9)
        Me.Controls.Add(Me.lblTimeLimit)
        Me.Controls.Add(Me.lblTtl10)
        Me.Controls.Add(Me.lblWFNo)
        Me.Controls.Add(Me.lblWP)
        Me.Controls.Add(Me.lblNewStatus)
        Me.Controls.Add(Me.lblOldStatus)
        Me.Controls.Add(Me.lblTitle3)
        Me.Controls.Add(Me.lblTitle2)
        Me.Controls.Add(Me.lblTtl7)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblLotID)
        Me.Controls.Add(Me.lblTtl0)
        Me.Controls.Add(Me.lblFlowClass)
        Me.Controls.Add(Me.lblTtl1)
        Me.Controls.Add(Me.lblBack)
        Me.Controls.Add(Me.lblTtl11)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxEN01B0"
        Me.Text = "ロット再測定"
        CType(Me.picRightAllow,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents picRightAllow As PictureBox
    Friend WithEvents cmdKakutei As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtCarrier As SETextBoxEx.TextBoxEx
    Friend WithEvents lblTtl8 As Label
    Friend WithEvents lblStepID As Label
    Friend WithEvents lblOpID As Label
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents lblTtl6 As Label
    Friend WithEvents lblTtl4 As Label
    Friend WithEvents lblStartDayTime As Label
    Friend WithEvents lblS As Label
    Friend WithEvents lblTtl5 As Label
    Friend WithEvents lblTtl3 As Label
    Friend WithEvents lblPdID As Label
    Friend WithEvents lblLotManager As Label
    Friend WithEvents lblTtl9 As Label
    Friend WithEvents lblTimeLimit As Label
    Friend WithEvents lblTtl10 As Label
    Friend WithEvents lblWFNo As Label
    Friend WithEvents lblWP As Label
    Friend WithEvents lblNewStatus As Label
    Friend WithEvents lblOldStatus As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents lblTtl7 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblLotID As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents lblFlowClass As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblBack As Label
    Friend WithEvents lblTtl11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblGRB As Label
End Class
