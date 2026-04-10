<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00C0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00C0))
        Me.cmdCarrierClean = New System.Windows.Forms.Button()
        Me.tabCarrier = New System.Windows.Forms.TabControl()
        Me.fraCarrierTab0 = New System.Windows.Forms.TabPage()
        Me.fraCarrier0 = New System.Windows.Forms.Panel()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdRegist = New System.Windows.Forms.Button()
        Me.calManuDate = New SECalendarEx.CalendarEx()
        Me.calUseStartDate = New SECalendarEx.CalendarEx()
        Me.txtCarrierID0 = New SETextBoxEx.TextBoxEx()
        Me.cmbSBID0 = New SEComboBoxEx.ComboBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitle02 = New System.Windows.Forms.Label()
        Me.lblTitle05 = New System.Windows.Forms.Label()
        Me.lblTitle03 = New System.Windows.Forms.Label()
        Me.lblTitle04 = New System.Windows.Forms.Label()
        Me.lblTitle01 = New System.Windows.Forms.Label()
        Me.lblTitle00 = New System.Windows.Forms.Label()
        Me.lblCarrierType = New System.Windows.Forms.Label()
        Me.lblWashDuraNum = New System.Windows.Forms.Label()
        Me.lblUseDuraNum = New System.Windows.Forms.Label()
        Me.lblTitle06 = New System.Windows.Forms.Label()
        Me.lblVendorName = New System.Windows.Forms.Label()
        Me.lblTitle07 = New System.Windows.Forms.Label()
        Me.lblSlotNum = New System.Windows.Forms.Label()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.txtDummy0 = New System.Windows.Forms.TextBox()
        Me.fraCarrierTab1 = New System.Windows.Forms.TabPage()
        Me.fraCarrier1 = New System.Windows.Forms.Panel()
        Me.cmdUp = New System.Windows.Forms.Button()
        Me.cmdDown = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdCarrierForcedmove = New System.Windows.Forms.Button()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.cmdNowList = New System.Windows.Forms.Button()
        Me.cmdClean = New System.Windows.Forms.Button()
        Me.cmbCarrType = New SEComboBoxEx.ComboBoxEx()
        Me.vsfCarrierList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmbSBID1 = New SEComboBoxEx.ComboBoxEx()
        Me.cmbStockerName = New SECmbIchiran.ComboIchiran()
        Me.cmbUseCategory = New SECmbIchiran.ComboIchiran()
        Me.txtCarrierComments = New SETextBoxEx.TextBoxEx()
        Me.lblCarrierLengthCount = New System.Windows.Forms.Label()
        Me.lblTitle8 = New System.Windows.Forms.Label()
        Me.lblTitle6 = New System.Windows.Forms.Label()
        Me.lblTitle5 = New System.Windows.Forms.Label()
        Me.lblTitle7 = New System.Windows.Forms.Label()
        Me.lblNowDate = New System.Windows.Forms.Label()
        Me.lblCarrierCnt = New System.Windows.Forms.Label()
        Me.lblTitle4 = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblTitle2 = New System.Windows.Forms.Label()
        Me.fraCarrierTab2 = New System.Windows.Forms.TabPage()
        Me.fraCarrier2 = New System.Windows.Forms.Panel()
        Me.txtCarrierID2 = New SETextBoxEx.TextBoxEx()
        Me.tabCarrierMnt = New System.Windows.Forms.TabControl()
        Me.fraCarrierMntTab0 = New System.Windows.Forms.TabPage()
        Me.fraCarrierMnt0 = New System.Windows.Forms.Panel()
        Me.cmdWFMove = New System.Windows.Forms.Button()
        Me.fraSlotMap2 = New System.Windows.Forms.GroupBox()
        Me.cmdCarrierSelect = New System.Windows.Forms.Button()
        Me.txtCarrierMnt = New SETextBoxEx.TextBoxEx()
        Me.vsfMoveSlotMap2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblTtl2 = New System.Windows.Forms.Label()
        Me.fraSlotMap1 = New System.Windows.Forms.GroupBox()
        Me.vsfMoveSlotMap = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.cmdMoveCancel = New System.Windows.Forms.Button()
        Me.fraCarrierMntTab1 = New System.Windows.Forms.TabPage()
        Me.fraCarrierMnt1 = New System.Windows.Forms.Panel()
        Me.fraSlotMap4 = New System.Windows.Forms.GroupBox()
        Me.cmdJigSelect = New System.Windows.Forms.Button()
        Me.vsfMoveSlotMap4 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraSlotMap3 = New System.Windows.Forms.GroupBox()
        Me.vsfMoveSlotMap3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmdUpper = New System.Windows.Forms.Button()
        Me.cmdLower = New System.Windows.Forms.Button()
        Me.cmdWFMove2 = New System.Windows.Forms.Button()
        Me.cmdMoveCancel2 = New System.Windows.Forms.Button()
        Me.cmdMove2 = New System.Windows.Forms.Button()
        Me.fraCarrierMntTab2 = New System.Windows.Forms.TabPage()
        Me.fraCarrierMnt2 = New System.Windows.Forms.Panel()
        Me.cmdWFAllSelect = New System.Windows.Forms.Button()
        Me.cmdCommentUp = New System.Windows.Forms.Button()
        Me.cmdCommentDown = New System.Windows.Forms.Button()
        Me.cmdWFScrap = New System.Windows.Forms.Button()
        Me.vsfMoveSlotMap5 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtComment = New SETextBoxEx.TextBoxEx()
        Me.lblLengthCount = New System.Windows.Forms.Label()
        Me.lblTtl15 = New System.Windows.Forms.Label()
        Me.fraCarrierMntTab3 = New System.Windows.Forms.TabPage()
        Me.fraCarrierMnt3 = New System.Windows.Forms.Panel()
        Me.picDownAllow = New System.Windows.Forms.PictureBox()
        Me.cmdChgStocker = New System.Windows.Forms.Button()
        Me.cmbChangePosiotionID = New SEComboBoxEx.ComboBoxEx()
        Me.lblCurrentPositionID = New System.Windows.Forms.Label()
        Me.lblTitle3 = New System.Windows.Forms.Label()
        Me.lblTitle31 = New System.Windows.Forms.Label()
        Me.fraCarrierMntTab4 = New System.Windows.Forms.TabPage()
        Me.fraCarrierMnt4 = New System.Windows.Forms.Panel()
        Me.fraSlotMap5 = New System.Windows.Forms.GroupBox()
        Me.vsfMoveSlotMap6 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fraSlotMap6 = New System.Windows.Forms.GroupBox()
        Me.fraWork = New System.Windows.Forms.Panel()
        Me.optOnline1 = New System.Windows.Forms.RadioButton()
        Me.optOnline0 = New System.Windows.Forms.RadioButton()
        Me.cmdCarrierSelect2 = New System.Windows.Forms.Button()
        Me.txtCarrierMnt2 = New SETextBoxEx.TextBoxEx()
        Me.vsfMoveSlotMap7 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblBack = New System.Windows.Forms.Label()
        Me.lblTtl1 = New System.Windows.Forms.Label()
        Me.lblTtl0 = New System.Windows.Forms.Label()
        Me.cmdExchange = New System.Windows.Forms.Button()
        Me.lblTitle30 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.tabCarrier.SuspendLayout
        Me.fraCarrierTab0.SuspendLayout
        Me.fraCarrier0.SuspendLayout
        Me.fraCarrierTab1.SuspendLayout
        Me.fraCarrier1.SuspendLayout
        CType(Me.vsfCarrierList,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCarrierTab2.SuspendLayout
        Me.fraCarrier2.SuspendLayout
        Me.tabCarrierMnt.SuspendLayout
        Me.fraCarrierMntTab0.SuspendLayout
        Me.fraCarrierMnt0.SuspendLayout
        Me.fraSlotMap2.SuspendLayout
        CType(Me.vsfMoveSlotMap2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraSlotMap1.SuspendLayout
        CType(Me.vsfMoveSlotMap,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCarrierMntTab1.SuspendLayout
        Me.fraCarrierMnt1.SuspendLayout
        Me.fraSlotMap4.SuspendLayout
        CType(Me.vsfMoveSlotMap4,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraSlotMap3.SuspendLayout
        CType(Me.vsfMoveSlotMap3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCarrierMntTab2.SuspendLayout
        Me.fraCarrierMnt2.SuspendLayout
        CType(Me.vsfMoveSlotMap5,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCarrierMntTab3.SuspendLayout
        Me.fraCarrierMnt3.SuspendLayout
        CType(Me.picDownAllow,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraCarrierMntTab4.SuspendLayout
        Me.fraCarrierMnt4.SuspendLayout
        Me.fraSlotMap5.SuspendLayout
        CType(Me.vsfMoveSlotMap6,System.ComponentModel.ISupportInitialize).BeginInit
        Me.fraSlotMap6.SuspendLayout
        Me.fraWork.SuspendLayout
        CType(Me.vsfMoveSlotMap7,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'cmdCarrierClean
        '
        Me.cmdCarrierClean.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierClean.Location = New System.Drawing.Point(120, 597)
        Me.cmdCarrierClean.Name = "cmdCarrierClean"
        Me.cmdCarrierClean.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierClean.TabIndex = 51
        Me.cmdCarrierClean.TabStop = false
        Me.cmdCarrierClean.Text = "キャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"指定洗浄"
        '
        'tabCarrier
        '
        Me.tabCarrier.Controls.Add(Me.fraCarrierTab0)
        Me.tabCarrier.Controls.Add(Me.fraCarrierTab1)
        Me.tabCarrier.Controls.Add(Me.fraCarrierTab2)
        Me.tabCarrier.ItemSize = New System.Drawing.Size(320, 21)
        Me.tabCarrier.Location = New System.Drawing.Point(8, 8)
        Me.tabCarrier.Name = "tabCarrier"
        Me.tabCarrier.SelectedIndex = 0
        Me.tabCarrier.Size = New System.Drawing.Size(965, 581)
        Me.tabCarrier.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabCarrier.TabIndex = 50
        '
        'fraCarrierTab0
        '
        Me.fraCarrierTab0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraCarrierTab0.Controls.Add(Me.fraCarrier0)
        Me.fraCarrierTab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrierTab0.ForeColor = System.Drawing.Color.Black
        Me.fraCarrierTab0.Location = New System.Drawing.Point(4, 25)
        Me.fraCarrierTab0.Margin = New System.Windows.Forms.Padding(0)
        Me.fraCarrierTab0.Name = "fraCarrierTab0"
        Me.fraCarrierTab0.Size = New System.Drawing.Size(957, 552)
        Me.fraCarrierTab0.TabIndex = 0
        Me.fraCarrierTab0.Text = "キャリア登録"
        '
        'fraCarrier0
        '
        Me.fraCarrier0.Controls.Add(Me.cmdDel)
        Me.fraCarrier0.Controls.Add(Me.cmdRegist)
        Me.fraCarrier0.Controls.Add(Me.calManuDate)
        Me.fraCarrier0.Controls.Add(Me.calUseStartDate)
        Me.fraCarrier0.Controls.Add(Me.txtCarrierID0)
        Me.fraCarrier0.Controls.Add(Me.cmbSBID0)
        Me.fraCarrier0.Controls.Add(Me.Label1)
        Me.fraCarrier0.Controls.Add(Me.lblTitle02)
        Me.fraCarrier0.Controls.Add(Me.lblTitle05)
        Me.fraCarrier0.Controls.Add(Me.lblTitle03)
        Me.fraCarrier0.Controls.Add(Me.lblTitle04)
        Me.fraCarrier0.Controls.Add(Me.lblTitle01)
        Me.fraCarrier0.Controls.Add(Me.lblTitle00)
        Me.fraCarrier0.Controls.Add(Me.lblCarrierType)
        Me.fraCarrier0.Controls.Add(Me.lblWashDuraNum)
        Me.fraCarrier0.Controls.Add(Me.lblUseDuraNum)
        Me.fraCarrier0.Controls.Add(Me.lblTitle06)
        Me.fraCarrier0.Controls.Add(Me.lblVendorName)
        Me.fraCarrier0.Controls.Add(Me.lblTitle07)
        Me.fraCarrier0.Controls.Add(Me.lblSlotNum)
        Me.fraCarrier0.Controls.Add(Me.lblTitle0)
        Me.fraCarrier0.Controls.Add(Me.txtDummy0)
        Me.fraCarrier0.Location = New System.Drawing.Point(0, 0)
        Me.fraCarrier0.Name = "fraCarrier0"
        Me.fraCarrier0.Size = New System.Drawing.Size(959, 555)
        Me.fraCarrier0.TabIndex = 54
        '
        'cmdDel
        '
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Location = New System.Drawing.Point(771, 504)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(85, 40)
        Me.cmdDel.TabIndex = 6
        Me.cmdDel.TabStop = false
        Me.cmdDel.Text = "キャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"削除"
        '
        'cmdRegist
        '
        Me.cmdRegist.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRegist.Location = New System.Drawing.Point(866, 504)
        Me.cmdRegist.Name = "cmdRegist"
        Me.cmdRegist.Size = New System.Drawing.Size(85, 40)
        Me.cmdRegist.TabIndex = 5
        Me.cmdRegist.Text = "確　定"
        '
        'calManuDate
        '
        Me.calManuDate.DateCheckStatus = 0
        Me.calManuDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calManuDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calManuDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calManuDate.IsDate = true
        Me.calManuDate.Location = New System.Drawing.Point(7, 200)
        Me.calManuDate.Name = "calManuDate"
        Me.calManuDate.Size = New System.Drawing.Size(172, 22)
        Me.calManuDate.TabIndex = 3
        Me.calManuDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calManuDate.Value = "____/__/__"
        '
        'calUseStartDate
        '
        Me.calUseStartDate.DateCheckStatus = 0
        Me.calUseStartDate.DayFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calUseStartDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calUseStartDate.GridFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calUseStartDate.IsDate = true
        Me.calUseStartDate.Location = New System.Drawing.Point(7, 144)
        Me.calUseStartDate.Name = "calUseStartDate"
        Me.calUseStartDate.Size = New System.Drawing.Size(172, 22)
        Me.calUseStartDate.TabIndex = 2
        Me.calUseStartDate.TitleFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calUseStartDate.Value = "____/__/__"
        '
        'txtCarrierID0
        '
        Me.txtCarrierID0.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID0.ChrMaxByte = 6
        Me.txtCarrierID0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierID0.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID0.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID0.Location = New System.Drawing.Point(6, 87)
        Me.txtCarrierID0.Name = "txtCarrierID0"
        Me.txtCarrierID0.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID0.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID0.SelectedText = ""
        Me.txtCarrierID0.Size = New System.Drawing.Size(172, 22)
        Me.txtCarrierID0.TabIndex = 1
        '
        'cmbSBID0
        '
        Me.cmbSBID0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbSBID0.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbSBID0.Location = New System.Drawing.Point(6, 29)
        Me.cmbSBID0.Name = "cmbSBID0"
        Me.cmbSBID0.Size = New System.Drawing.Size(172, 22)
        Me.cmbSBID0.TabIndex = 0
        Me.cmbSBID0.Value = Nothing
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(219, 431)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(703, 53)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "このタブを選んだままチェックインして下さい！！不具合№887"
        Me.Label1.Visible = false
        '
        'lblTitle02
        '
        Me.lblTitle02.BackColor = System.Drawing.Color.Navy
        Me.lblTitle02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle02.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle02.Location = New System.Drawing.Point(7, 184)
        Me.lblTitle02.Name = "lblTitle02"
        Me.lblTitle02.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle02.TabIndex = 68
        Me.lblTitle02.Text = "製造年月日"
        Me.lblTitle02.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle05
        '
        Me.lblTitle05.BackColor = System.Drawing.Color.Navy
        Me.lblTitle05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle05.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle05.Location = New System.Drawing.Point(7, 464)
        Me.lblTitle05.Name = "lblTitle05"
        Me.lblTitle05.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle05.TabIndex = 67
        Me.lblTitle05.Text = "使用耐用回数"
        Me.lblTitle05.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle03
        '
        Me.lblTitle03.BackColor = System.Drawing.Color.Navy
        Me.lblTitle03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle03.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle03.Location = New System.Drawing.Point(7, 240)
        Me.lblTitle03.Name = "lblTitle03"
        Me.lblTitle03.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle03.TabIndex = 66
        Me.lblTitle03.Text = "キャリアタイプ"
        Me.lblTitle03.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle04
        '
        Me.lblTitle04.BackColor = System.Drawing.Color.Navy
        Me.lblTitle04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle04.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle04.Location = New System.Drawing.Point(7, 408)
        Me.lblTitle04.Name = "lblTitle04"
        Me.lblTitle04.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle04.TabIndex = 65
        Me.lblTitle04.Text = "洗浄耐用回数"
        Me.lblTitle04.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle01
        '
        Me.lblTitle01.BackColor = System.Drawing.Color.Navy
        Me.lblTitle01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle01.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle01.Location = New System.Drawing.Point(7, 128)
        Me.lblTitle01.Name = "lblTitle01"
        Me.lblTitle01.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle01.TabIndex = 64
        Me.lblTitle01.Text = "利用開始日"
        Me.lblTitle01.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle00
        '
        Me.lblTitle00.BackColor = System.Drawing.Color.Navy
        Me.lblTitle00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle00.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle00.Location = New System.Drawing.Point(6, 71)
        Me.lblTitle00.Name = "lblTitle00"
        Me.lblTitle00.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle00.TabIndex = 63
        Me.lblTitle00.Text = "キャリアID"
        Me.lblTitle00.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCarrierType
        '
        Me.lblCarrierType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrierType.Location = New System.Drawing.Point(7, 256)
        Me.lblCarrierType.Name = "lblCarrierType"
        Me.lblCarrierType.Size = New System.Drawing.Size(172, 22)
        Me.lblCarrierType.TabIndex = 62
        '
        'lblWashDuraNum
        '
        Me.lblWashDuraNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWashDuraNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWashDuraNum.Location = New System.Drawing.Point(7, 424)
        Me.lblWashDuraNum.Name = "lblWashDuraNum"
        Me.lblWashDuraNum.Size = New System.Drawing.Size(172, 22)
        Me.lblWashDuraNum.TabIndex = 61
        Me.lblWashDuraNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUseDuraNum
        '
        Me.lblUseDuraNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUseDuraNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUseDuraNum.Location = New System.Drawing.Point(7, 480)
        Me.lblUseDuraNum.Name = "lblUseDuraNum"
        Me.lblUseDuraNum.Size = New System.Drawing.Size(172, 22)
        Me.lblUseDuraNum.TabIndex = 60
        Me.lblUseDuraNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle06
        '
        Me.lblTitle06.BackColor = System.Drawing.Color.Navy
        Me.lblTitle06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle06.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle06.Location = New System.Drawing.Point(7, 296)
        Me.lblTitle06.Name = "lblTitle06"
        Me.lblTitle06.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle06.TabIndex = 59
        Me.lblTitle06.Text = "ベンダー"
        Me.lblTitle06.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblVendorName
        '
        Me.lblVendorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVendorName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVendorName.Location = New System.Drawing.Point(7, 312)
        Me.lblVendorName.Name = "lblVendorName"
        Me.lblVendorName.Size = New System.Drawing.Size(172, 22)
        Me.lblVendorName.TabIndex = 58
        '
        'lblTitle07
        '
        Me.lblTitle07.BackColor = System.Drawing.Color.Navy
        Me.lblTitle07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle07.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle07.Location = New System.Drawing.Point(7, 352)
        Me.lblTitle07.Name = "lblTitle07"
        Me.lblTitle07.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle07.TabIndex = 57
        Me.lblTitle07.Text = "スロット数"
        Me.lblTitle07.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSlotNum
        '
        Me.lblSlotNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSlotNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSlotNum.Location = New System.Drawing.Point(7, 368)
        Me.lblSlotNum.Name = "lblSlotNum"
        Me.lblSlotNum.Size = New System.Drawing.Size(172, 22)
        Me.lblSlotNum.TabIndex = 56
        Me.lblSlotNum.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle0
        '
        Me.lblTitle0.BackColor = System.Drawing.Color.Navy
        Me.lblTitle0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle0.Location = New System.Drawing.Point(6, 13)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(172, 17)
        Me.lblTitle0.TabIndex = 55
        Me.lblTitle0.Text = "利用SB"
        Me.lblTitle0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDummy0
        '
        Me.txtDummy0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDummy0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDummy0.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtDummy0.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.txtDummy0.Location = New System.Drawing.Point(160, 259)
        Me.txtDummy0.Name = "txtDummy0"
        Me.txtDummy0.ReadOnly = true
        Me.txtDummy0.Size = New System.Drawing.Size(15, 15)
        Me.txtDummy0.TabIndex = 4
        '
        'fraCarrierTab1
        '
        Me.fraCarrierTab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraCarrierTab1.Controls.Add(Me.fraCarrier1)
        Me.fraCarrierTab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrierTab1.ForeColor = System.Drawing.Color.Black
        Me.fraCarrierTab1.Location = New System.Drawing.Point(4, 25)
        Me.fraCarrierTab1.Margin = New System.Windows.Forms.Padding(0)
        Me.fraCarrierTab1.Name = "fraCarrierTab1"
        Me.fraCarrierTab1.Size = New System.Drawing.Size(957, 552)
        Me.fraCarrierTab1.TabIndex = 1
        Me.fraCarrierTab1.Text = "キャリア一覧"
        '
        'fraCarrier1
        '
        Me.fraCarrier1.Controls.Add(Me.cmdUp)
        Me.fraCarrier1.Controls.Add(Me.cmdDown)
        Me.fraCarrier1.Controls.Add(Me.cmdUpdate)
        Me.fraCarrier1.Controls.Add(Me.cmdCopy)
        Me.fraCarrier1.Controls.Add(Me.cmdCarrierForcedmove)
        Me.fraCarrier1.Controls.Add(Me.cmdShip)
        Me.fraCarrier1.Controls.Add(Me.cmdNowList)
        Me.fraCarrier1.Controls.Add(Me.cmdClean)
        Me.fraCarrier1.Controls.Add(Me.cmbCarrType)
        Me.fraCarrier1.Controls.Add(Me.vsfCarrierList)
        Me.fraCarrier1.Controls.Add(Me.cmbSBID1)
        Me.fraCarrier1.Controls.Add(Me.cmbStockerName)
        Me.fraCarrier1.Controls.Add(Me.cmbUseCategory)
        Me.fraCarrier1.Controls.Add(Me.txtCarrierComments)
        Me.fraCarrier1.Controls.Add(Me.lblCarrierLengthCount)
        Me.fraCarrier1.Controls.Add(Me.lblTitle8)
        Me.fraCarrier1.Controls.Add(Me.lblTitle6)
        Me.fraCarrier1.Controls.Add(Me.lblTitle5)
        Me.fraCarrier1.Controls.Add(Me.lblTitle7)
        Me.fraCarrier1.Controls.Add(Me.lblNowDate)
        Me.fraCarrier1.Controls.Add(Me.lblCarrierCnt)
        Me.fraCarrier1.Controls.Add(Me.lblTitle4)
        Me.fraCarrier1.Controls.Add(Me.lblTitle1)
        Me.fraCarrier1.Controls.Add(Me.lblTitle2)
        Me.fraCarrier1.Location = New System.Drawing.Point(0, 0)
        Me.fraCarrier1.Name = "fraCarrier1"
        Me.fraCarrier1.Size = New System.Drawing.Size(959, 555)
        Me.fraCarrier1.TabIndex = 69
        Me.fraCarrier1.Text = "Frame1"
        '
        'cmdUp
        '
        Me.cmdUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp.Location = New System.Drawing.Point(926, 437)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(25, 28)
        Me.cmdUp.TabIndex = 12
        Me.cmdUp.Text = "▲"
        '
        'cmdDown
        '
        Me.cmdDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown.Location = New System.Drawing.Point(926, 466)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(25, 28)
        Me.cmdDown.TabIndex = 13
        Me.cmdDown.Text = "▼"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpdate.Location = New System.Drawing.Point(484, 504)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(85, 40)
        Me.cmdUpdate.TabIndex = 14
        Me.cmdUpdate.Text = "使用ｶﾃｺﾞﾘ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"/ｺﾒﾝﾄ変更"
        '
        'cmdCopy
        '
        Me.cmdCopy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCopy.Location = New System.Drawing.Point(580, 504)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(85, 40)
        Me.cmdCopy.TabIndex = 15
        Me.cmdCopy.Text = "ｸﾘｯﾌﾟ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ﾎﾞｰﾄﾞｺﾋﾟｰ"
        '
        'cmdCarrierForcedmove
        '
        Me.cmdCarrierForcedmove.CausesValidation = false
        Me.cmdCarrierForcedmove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierForcedmove.Location = New System.Drawing.Point(676, 504)
        Me.cmdCarrierForcedmove.Name = "cmdCarrierForcedmove"
        Me.cmdCarrierForcedmove.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierForcedmove.TabIndex = 16
        Me.cmdCarrierForcedmove.Text = "キャリア"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"強制交換"
        '
        'cmdShip
        '
        Me.cmdShip.CausesValidation = false
        Me.cmdShip.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdShip.Location = New System.Drawing.Point(771, 504)
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.Size = New System.Drawing.Size(85, 40)
        Me.cmdShip.TabIndex = 17
        Me.cmdShip.Text = "出庫指示"
        Me.cmdShip.Visible = false
        '
        'cmdNowList
        '
        Me.cmdNowList.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowList.Location = New System.Drawing.Point(654, 11)
        Me.cmdNowList.Name = "cmdNowList"
        Me.cmdNowList.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowList.TabIndex = 19
        Me.cmdNowList.Text = "最新取得"
        '
        'cmdClean
        '
        Me.cmdClean.CausesValidation = false
        Me.cmdClean.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClean.Location = New System.Drawing.Point(866, 504)
        Me.cmdClean.Name = "cmdClean"
        Me.cmdClean.Size = New System.Drawing.Size(85, 40)
        Me.cmdClean.TabIndex = 18
        Me.cmdClean.Text = "洗　浄"
        '
        'cmbCarrType
        '
        Me.cmbCarrType.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCarrType.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbCarrType.Location = New System.Drawing.Point(126, 28)
        Me.cmbCarrType.Name = "cmbCarrType"
        Me.cmbCarrType.Size = New System.Drawing.Size(168, 22)
        Me.cmbCarrType.TabIndex = 7
        Me.cmbCarrType.Value = Nothing
        '
        'vsfCarrierList
        '
        Me.vsfCarrierList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfCarrierList.AllowEditing = false
        Me.vsfCarrierList.AutoSearchDelay = 2R
        Me.vsfCarrierList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfCarrierList.ColumnInfo = resources.GetString("vsfCarrierList.ColumnInfo")
        Me.vsfCarrierList.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfCarrierList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy
        Me.vsfCarrierList.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfCarrierList.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfCarrierList.Location = New System.Drawing.Point(6, 61)
        Me.vsfCarrierList.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfCarrierList.Name = "vsfCarrierList"
        Me.vsfCarrierList.Rows.Count = 40
        Me.vsfCarrierList.Rows.DefaultSize = 18
        Me.vsfCarrierList.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfCarrierList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfCarrierList.Size = New System.Drawing.Size(945, 364)
        Me.vsfCarrierList.StyleInfo = resources.GetString("vsfCarrierList.StyleInfo")
        Me.vsfCarrierList.TabIndex = 10
        '
        'cmbSBID1
        '
        Me.cmbSBID1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbSBID1.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbSBID1.Location = New System.Drawing.Point(6, 28)
        Me.cmbSBID1.Name = "cmbSBID1"
        Me.cmbSBID1.Size = New System.Drawing.Size(117, 22)
        Me.cmbSBID1.TabIndex = 6
        Me.cmbSBID1.Value = Nothing
        '
        'cmbStockerName
        '
        Me.cmbStockerName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStockerName.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbStockerName.Location = New System.Drawing.Point(460, 28)
        Me.cmbStockerName.Name = "cmbStockerName"
        Me.cmbStockerName.Size = New System.Drawing.Size(191, 22)
        Me.cmbStockerName.TabIndex = 9
        Me.cmbStockerName.Value = Nothing
        '
        'cmbUseCategory
        '
        Me.cmbUseCategory.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbUseCategory.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbUseCategory.Location = New System.Drawing.Point(297, 28)
        Me.cmbUseCategory.Name = "cmbUseCategory"
        Me.cmbUseCategory.Size = New System.Drawing.Size(160, 22)
        Me.cmbUseCategory.TabIndex = 8
        Me.cmbUseCategory.Value = Nothing
        '
        'txtCarrierComments
        '
        Me.txtCarrierComments.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtCarrierComments.ChrMaxByte = 256
        Me.txtCarrierComments.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierComments.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_None_FormatMode
        Me.txtCarrierComments.GotHighLight = false
        Me.txtCarrierComments.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtCarrierComments.Location = New System.Drawing.Point(6, 455)
        Me.txtCarrierComments.MultiLineEx = true
        Me.txtCarrierComments.Name = "txtCarrierComments"
        Me.txtCarrierComments.NgChr = "'"
        Me.txtCarrierComments.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierComments.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierComments.SelectedText = ""
        Me.txtCarrierComments.Size = New System.Drawing.Size(920, 38)
        Me.txtCarrierComments.TabIndex = 11
        '
        'lblCarrierLengthCount
        '
        Me.lblCarrierLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblCarrierLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblCarrierLengthCount.Location = New System.Drawing.Point(667, 439)
        Me.lblCarrierLengthCount.Name = "lblCarrierLengthCount"
        Me.lblCarrierLengthCount.Size = New System.Drawing.Size(247, 17)
        Me.lblCarrierLengthCount.TabIndex = 104
        Me.lblCarrierLengthCount.Text = "( 半角256文字/半角256文字 )"
        Me.lblCarrierLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle8
        '
        Me.lblTitle8.BackColor = System.Drawing.Color.Navy
        Me.lblTitle8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle8.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle8.Location = New System.Drawing.Point(6, 438)
        Me.lblTitle8.Name = "lblTitle8"
        Me.lblTitle8.Size = New System.Drawing.Size(920, 18)
        Me.lblTitle8.TabIndex = 103
        Me.lblTitle8.Text = "コメント"
        Me.lblTitle8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle6
        '
        Me.lblTitle6.BackColor = System.Drawing.Color.Navy
        Me.lblTitle6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle6.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle6.Location = New System.Drawing.Point(297, 12)
        Me.lblTitle6.Name = "lblTitle6"
        Me.lblTitle6.Size = New System.Drawing.Size(160, 17)
        Me.lblTitle6.TabIndex = 102
        Me.lblTitle6.Text = "使用カテゴリ"
        Me.lblTitle6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle5
        '
        Me.lblTitle5.BackColor = System.Drawing.Color.Navy
        Me.lblTitle5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle5.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle5.Location = New System.Drawing.Point(460, 12)
        Me.lblTitle5.Name = "lblTitle5"
        Me.lblTitle5.Size = New System.Drawing.Size(191, 17)
        Me.lblTitle5.TabIndex = 97
        Me.lblTitle5.Text = "ストッカー"
        Me.lblTitle5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle7
        '
        Me.lblTitle7.BackColor = System.Drawing.Color.Navy
        Me.lblTitle7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle7.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle7.Location = New System.Drawing.Point(743, 12)
        Me.lblTitle7.Name = "lblTitle7"
        Me.lblTitle7.Size = New System.Drawing.Size(122, 17)
        Me.lblTitle7.TabIndex = 90
        Me.lblTitle7.Text = "情報取得日時"
        Me.lblTitle7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblNowDate
        '
        Me.lblNowDate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblNowDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNowDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNowDate.Location = New System.Drawing.Point(743, 28)
        Me.lblNowDate.Name = "lblNowDate"
        Me.lblNowDate.Size = New System.Drawing.Size(122, 22)
        Me.lblNowDate.TabIndex = 89
        Me.lblNowDate.Text = "07/15 13:11:25"
        '
        'lblCarrierCnt
        '
        Me.lblCarrierCnt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblCarrierCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCarrierCnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCarrierCnt.Location = New System.Drawing.Point(869, 28)
        Me.lblCarrierCnt.Name = "lblCarrierCnt"
        Me.lblCarrierCnt.Size = New System.Drawing.Size(81, 22)
        Me.lblCarrierCnt.TabIndex = 73
        Me.lblCarrierCnt.Text = "99999"
        Me.lblCarrierCnt.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTitle4
        '
        Me.lblTitle4.BackColor = System.Drawing.Color.Navy
        Me.lblTitle4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle4.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle4.Location = New System.Drawing.Point(869, 12)
        Me.lblTitle4.Name = "lblTitle4"
        Me.lblTitle4.Size = New System.Drawing.Size(81, 17)
        Me.lblTitle4.TabIndex = 72
        Me.lblTitle4.Text = "該当件数"
        Me.lblTitle4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.BackColor = System.Drawing.Color.Navy
        Me.lblTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle1.Location = New System.Drawing.Point(126, 12)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(168, 17)
        Me.lblTitle1.TabIndex = 71
        Me.lblTitle1.Text = "キャリアタイプ"
        Me.lblTitle1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle2
        '
        Me.lblTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle2.Location = New System.Drawing.Point(6, 12)
        Me.lblTitle2.Name = "lblTitle2"
        Me.lblTitle2.Size = New System.Drawing.Size(117, 17)
        Me.lblTitle2.TabIndex = 70
        Me.lblTitle2.Text = "利用SB"
        Me.lblTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraCarrierTab2
        '
        Me.fraCarrierTab2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraCarrierTab2.Controls.Add(Me.fraCarrier2)
        Me.fraCarrierTab2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrierTab2.ForeColor = System.Drawing.Color.Black
        Me.fraCarrierTab2.Location = New System.Drawing.Point(4, 25)
        Me.fraCarrierTab2.Margin = New System.Windows.Forms.Padding(0)
        Me.fraCarrierTab2.Name = "fraCarrierTab2"
        Me.fraCarrierTab2.Size = New System.Drawing.Size(957, 552)
        Me.fraCarrierTab2.TabIndex = 2
        Me.fraCarrierTab2.Text = "キャリアメンテナンス"
        '
        'fraCarrier2
        '
        Me.fraCarrier2.Controls.Add(Me.txtCarrierID2)
        Me.fraCarrier2.Controls.Add(Me.tabCarrierMnt)
        Me.fraCarrier2.Controls.Add(Me.lblTitle30)
        Me.fraCarrier2.Location = New System.Drawing.Point(0, 0)
        Me.fraCarrier2.Name = "fraCarrier2"
        Me.fraCarrier2.Size = New System.Drawing.Size(959, 555)
        Me.fraCarrier2.TabIndex = 74
        Me.fraCarrier2.Text = "Frame1"
        '
        'txtCarrierID2
        '
        Me.txtCarrierID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarrierID2.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierID2.ChrMaxByte = 6
        Me.txtCarrierID2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierID2.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierID2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierID2.Location = New System.Drawing.Point(6, 29)
        Me.txtCarrierID2.Name = "txtCarrierID2"
        Me.txtCarrierID2.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierID2.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierID2.SelectedText = ""
        Me.txtCarrierID2.Size = New System.Drawing.Size(92, 22)
        Me.txtCarrierID2.TabIndex = 20
        '
        'tabCarrierMnt
        '
        Me.tabCarrierMnt.CausesValidation = false
        Me.tabCarrierMnt.Controls.Add(Me.fraCarrierMntTab0)
        Me.tabCarrierMnt.Controls.Add(Me.fraCarrierMntTab1)
        Me.tabCarrierMnt.Controls.Add(Me.fraCarrierMntTab2)
        Me.tabCarrierMnt.Controls.Add(Me.fraCarrierMntTab3)
        Me.tabCarrierMnt.Controls.Add(Me.fraCarrierMntTab4)
        Me.tabCarrierMnt.ItemSize = New System.Drawing.Size(170, 21)
        Me.tabCarrierMnt.Location = New System.Drawing.Point(104, 0)
        Me.tabCarrierMnt.Name = "tabCarrierMnt"
        Me.tabCarrierMnt.SelectedIndex = 0
        Me.tabCarrierMnt.Size = New System.Drawing.Size(856, 554)
        Me.tabCarrierMnt.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabCarrierMnt.TabIndex = 49
        '
        'fraCarrierMntTab0
        '
        Me.fraCarrierMntTab0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraCarrierMntTab0.Controls.Add(Me.fraCarrierMnt0)
        Me.fraCarrierMntTab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrierMntTab0.ForeColor = System.Drawing.Color.Black
        Me.fraCarrierMntTab0.Location = New System.Drawing.Point(4, 25)
        Me.fraCarrierMntTab0.Margin = New System.Windows.Forms.Padding(0)
        Me.fraCarrierMntTab0.Name = "fraCarrierMntTab0"
        Me.fraCarrierMntTab0.Size = New System.Drawing.Size(848, 525)
        Me.fraCarrierMntTab0.TabIndex = 0
        Me.fraCarrierMntTab0.Text = "WF移動"
        '
        'fraCarrierMnt0
        '
        Me.fraCarrierMnt0.Controls.Add(Me.cmdWFMove)
        Me.fraCarrierMnt0.Controls.Add(Me.fraSlotMap2)
        Me.fraCarrierMnt0.Controls.Add(Me.fraSlotMap1)
        Me.fraCarrierMnt0.Controls.Add(Me.cmdMove)
        Me.fraCarrierMnt0.Controls.Add(Me.cmdMoveCancel)
        Me.fraCarrierMnt0.Enabled = false
        Me.fraCarrierMnt0.Location = New System.Drawing.Point(0, 1)
        Me.fraCarrierMnt0.Name = "fraCarrierMnt0"
        Me.fraCarrierMnt0.Size = New System.Drawing.Size(848, 523)
        Me.fraCarrierMnt0.TabIndex = 77
        Me.fraCarrierMnt0.Text = "Frame1"
        '
        'cmdWFMove
        '
        Me.cmdWFMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFMove.Location = New System.Drawing.Point(760, 479)
        Me.cmdWFMove.Name = "cmdWFMove"
        Me.cmdWFMove.Size = New System.Drawing.Size(85, 40)
        Me.cmdWFMove.TabIndex = 26
        Me.cmdWFMove.Text = "確　定"
        '
        'fraSlotMap2
        '
        Me.fraSlotMap2.Controls.Add(Me.cmdCarrierSelect)
        Me.fraSlotMap2.Controls.Add(Me.txtCarrierMnt)
        Me.fraSlotMap2.Controls.Add(Me.vsfMoveSlotMap2)
        Me.fraSlotMap2.Controls.Add(Me.lblTtl2)
        Me.fraSlotMap2.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotMap2.Location = New System.Drawing.Point(360, 0)
        Me.fraSlotMap2.Name = "fraSlotMap2"
        Me.fraSlotMap2.Size = New System.Drawing.Size(472, 472)
        Me.fraSlotMap2.TabIndex = 24
        Me.fraSlotMap2.TabStop = false
        Me.fraSlotMap2.Text = "統合／分割先"
        '
        'cmdCarrierSelect
        '
        Me.cmdCarrierSelect.CausesValidation = false
        Me.cmdCarrierSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect.Location = New System.Drawing.Point(8, 62)
        Me.cmdCarrierSelect.Name = "cmdCarrierSelect"
        Me.cmdCarrierSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect.TabIndex = 101
        Me.cmdCarrierSelect.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'txtCarrierMnt
        '
        Me.txtCarrierMnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarrierMnt.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierMnt.ChrMaxByte = 6
        Me.txtCarrierMnt.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierMnt.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierMnt.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierMnt.Location = New System.Drawing.Point(8, 34)
        Me.txtCarrierMnt.Name = "txtCarrierMnt"
        Me.txtCarrierMnt.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierMnt.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierMnt.SelectedText = ""
        Me.txtCarrierMnt.Size = New System.Drawing.Size(92, 22)
        Me.txtCarrierMnt.TabIndex = 24
        '
        'vsfMoveSlotMap2
        '
        Me.vsfMoveSlotMap2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMoveSlotMap2.AllowEditing = false
        Me.vsfMoveSlotMap2.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMoveSlotMap2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMoveSlotMap2.AutoResize = true
        Me.vsfMoveSlotMap2.AutoSearchDelay = 2R
        Me.vsfMoveSlotMap2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMoveSlotMap2.ColumnInfo = resources.GetString("vsfMoveSlotMap2.ColumnInfo")
        Me.vsfMoveSlotMap2.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMoveSlotMap2.ExtendLastCol = true
        Me.vsfMoveSlotMap2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMoveSlotMap2.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMoveSlotMap2.Location = New System.Drawing.Point(104, 17)
        Me.vsfMoveSlotMap2.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMoveSlotMap2.Name = "vsfMoveSlotMap2"
        Me.vsfMoveSlotMap2.Rows.Count = 26
        Me.vsfMoveSlotMap2.Rows.DefaultSize = 17
        Me.vsfMoveSlotMap2.Rows.MinSize = 17
        Me.vsfMoveSlotMap2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMoveSlotMap2.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMoveSlotMap2.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMoveSlotMap2.Size = New System.Drawing.Size(300, 444)
        Me.vsfMoveSlotMap2.StyleInfo = resources.GetString("vsfMoveSlotMap2.StyleInfo")
        Me.vsfMoveSlotMap2.TabIndex = 25
        '
        'lblTtl2
        '
        Me.lblTtl2.BackColor = System.Drawing.Color.Navy
        Me.lblTtl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl2.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl2.Location = New System.Drawing.Point(8, 18)
        Me.lblTtl2.Name = "lblTtl2"
        Me.lblTtl2.Size = New System.Drawing.Size(92, 17)
        Me.lblTtl2.TabIndex = 80
        Me.lblTtl2.Text = "キャリアID"
        Me.lblTtl2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraSlotMap1
        '
        Me.fraSlotMap1.Controls.Add(Me.vsfMoveSlotMap)
        Me.fraSlotMap1.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotMap1.Location = New System.Drawing.Point(8, 0)
        Me.fraSlotMap1.Name = "fraSlotMap1"
        Me.fraSlotMap1.Size = New System.Drawing.Size(247, 472)
        Me.fraSlotMap1.TabIndex = 21
        Me.fraSlotMap1.TabStop = false
        Me.fraSlotMap1.Text = "統合／分割元"
        '
        'vsfMoveSlotMap
        '
        Me.vsfMoveSlotMap.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMoveSlotMap.AllowEditing = false
        Me.vsfMoveSlotMap.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMoveSlotMap.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMoveSlotMap.AutoResize = true
        Me.vsfMoveSlotMap.AutoSearchDelay = 2R
        Me.vsfMoveSlotMap.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMoveSlotMap.ColumnInfo = resources.GetString("vsfMoveSlotMap.ColumnInfo")
        Me.vsfMoveSlotMap.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMoveSlotMap.ExtendLastCol = true
        Me.vsfMoveSlotMap.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMoveSlotMap.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMoveSlotMap.Location = New System.Drawing.Point(24, 17)
        Me.vsfMoveSlotMap.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMoveSlotMap.Name = "vsfMoveSlotMap"
        Me.vsfMoveSlotMap.Rows.Count = 26
        Me.vsfMoveSlotMap.Rows.DefaultSize = 17
        Me.vsfMoveSlotMap.Rows.MinSize = 17
        Me.vsfMoveSlotMap.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMoveSlotMap.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMoveSlotMap.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMoveSlotMap.Size = New System.Drawing.Size(207, 444)
        Me.vsfMoveSlotMap.StyleInfo = resources.GetString("vsfMoveSlotMap.StyleInfo")
        Me.vsfMoveSlotMap.TabIndex = 21
        '
        'cmdMove
        '
        Me.cmdMove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMove.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMove.Location = New System.Drawing.Point(264, 181)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.Size = New System.Drawing.Size(85, 40)
        Me.cmdMove.TabIndex = 22
        Me.cmdMove.Text = ">"
        '
        'cmdMoveCancel
        '
        Me.cmdMoveCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMoveCancel.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMoveCancel.Location = New System.Drawing.Point(264, 257)
        Me.cmdMoveCancel.Name = "cmdMoveCancel"
        Me.cmdMoveCancel.Size = New System.Drawing.Size(85, 40)
        Me.cmdMoveCancel.TabIndex = 23
        Me.cmdMoveCancel.Text = "<"
        '
        'fraCarrierMntTab1
        '
        Me.fraCarrierMntTab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraCarrierMntTab1.Controls.Add(Me.fraCarrierMnt1)
        Me.fraCarrierMntTab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrierMntTab1.ForeColor = System.Drawing.Color.Black
        Me.fraCarrierMntTab1.Location = New System.Drawing.Point(4, 25)
        Me.fraCarrierMntTab1.Margin = New System.Windows.Forms.Padding(0)
        Me.fraCarrierMntTab1.Name = "fraCarrierMntTab1"
        Me.fraCarrierMntTab1.Size = New System.Drawing.Size(848, 525)
        Me.fraCarrierMntTab1.TabIndex = 1
        Me.fraCarrierMntTab1.Text = "スロット情報変更"
        '
        'fraCarrierMnt1
        '
        Me.fraCarrierMnt1.Controls.Add(Me.fraSlotMap4)
        Me.fraCarrierMnt1.Controls.Add(Me.fraSlotMap3)
        Me.fraCarrierMnt1.Controls.Add(Me.cmdUpper)
        Me.fraCarrierMnt1.Controls.Add(Me.cmdLower)
        Me.fraCarrierMnt1.Controls.Add(Me.cmdWFMove2)
        Me.fraCarrierMnt1.Controls.Add(Me.cmdMoveCancel2)
        Me.fraCarrierMnt1.Controls.Add(Me.cmdMove2)
        Me.fraCarrierMnt1.Enabled = false
        Me.fraCarrierMnt1.Location = New System.Drawing.Point(0, 1)
        Me.fraCarrierMnt1.Name = "fraCarrierMnt1"
        Me.fraCarrierMnt1.Size = New System.Drawing.Size(848, 523)
        Me.fraCarrierMnt1.TabIndex = 76
        Me.fraCarrierMnt1.Text = "Frame1"
        '
        'fraSlotMap4
        '
        Me.fraSlotMap4.Controls.Add(Me.cmdJigSelect)
        Me.fraSlotMap4.Controls.Add(Me.vsfMoveSlotMap4)
        Me.fraSlotMap4.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotMap4.Location = New System.Drawing.Point(360, 0)
        Me.fraSlotMap4.Name = "fraSlotMap4"
        Me.fraSlotMap4.Size = New System.Drawing.Size(472, 472)
        Me.fraSlotMap4.TabIndex = 30
        Me.fraSlotMap4.TabStop = false
        Me.fraSlotMap4.Text = "変更後"
        '
        'cmdJigSelect
        '
        Me.cmdJigSelect.Enabled = false
        Me.cmdJigSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdJigSelect.Location = New System.Drawing.Point(9, 62)
        Me.cmdJigSelect.Name = "cmdJigSelect"
        Me.cmdJigSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdJigSelect.TabIndex = 105
        Me.cmdJigSelect.Text = "空治具"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'vsfMoveSlotMap4
        '
        Me.vsfMoveSlotMap4.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMoveSlotMap4.AllowEditing = false
        Me.vsfMoveSlotMap4.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMoveSlotMap4.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMoveSlotMap4.AutoResize = true
        Me.vsfMoveSlotMap4.AutoSearchDelay = 2R
        Me.vsfMoveSlotMap4.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMoveSlotMap4.ColumnInfo = resources.GetString("vsfMoveSlotMap4.ColumnInfo")
        Me.vsfMoveSlotMap4.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMoveSlotMap4.Enabled = false
        Me.vsfMoveSlotMap4.ExtendLastCol = true
        Me.vsfMoveSlotMap4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMoveSlotMap4.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMoveSlotMap4.Location = New System.Drawing.Point(104, 17)
        Me.vsfMoveSlotMap4.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMoveSlotMap4.Name = "vsfMoveSlotMap4"
        Me.vsfMoveSlotMap4.Rows.Count = 26
        Me.vsfMoveSlotMap4.Rows.DefaultSize = 17
        Me.vsfMoveSlotMap4.Rows.MinSize = 17
        Me.vsfMoveSlotMap4.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMoveSlotMap4.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMoveSlotMap4.Size = New System.Drawing.Size(300, 444)
        Me.vsfMoveSlotMap4.StyleInfo = resources.GetString("vsfMoveSlotMap4.StyleInfo")
        Me.vsfMoveSlotMap4.TabIndex = 30
        '
        'fraSlotMap3
        '
        Me.fraSlotMap3.Controls.Add(Me.vsfMoveSlotMap3)
        Me.fraSlotMap3.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotMap3.Location = New System.Drawing.Point(8, 0)
        Me.fraSlotMap3.Name = "fraSlotMap3"
        Me.fraSlotMap3.Size = New System.Drawing.Size(247, 472)
        Me.fraSlotMap3.TabIndex = 27
        Me.fraSlotMap3.TabStop = false
        Me.fraSlotMap3.Text = "変更前"
        '
        'vsfMoveSlotMap3
        '
        Me.vsfMoveSlotMap3.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMoveSlotMap3.AllowEditing = false
        Me.vsfMoveSlotMap3.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMoveSlotMap3.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMoveSlotMap3.AutoResize = true
        Me.vsfMoveSlotMap3.AutoSearchDelay = 2R
        Me.vsfMoveSlotMap3.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMoveSlotMap3.ColumnInfo = resources.GetString("vsfMoveSlotMap3.ColumnInfo")
        Me.vsfMoveSlotMap3.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMoveSlotMap3.Enabled = false
        Me.vsfMoveSlotMap3.ExtendLastCol = true
        Me.vsfMoveSlotMap3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMoveSlotMap3.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMoveSlotMap3.Location = New System.Drawing.Point(24, 17)
        Me.vsfMoveSlotMap3.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMoveSlotMap3.Name = "vsfMoveSlotMap3"
        Me.vsfMoveSlotMap3.Rows.Count = 26
        Me.vsfMoveSlotMap3.Rows.DefaultSize = 17
        Me.vsfMoveSlotMap3.Rows.MinSize = 17
        Me.vsfMoveSlotMap3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMoveSlotMap3.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMoveSlotMap3.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMoveSlotMap3.Size = New System.Drawing.Size(207, 444)
        Me.vsfMoveSlotMap3.StyleInfo = resources.GetString("vsfMoveSlotMap3.StyleInfo")
        Me.vsfMoveSlotMap3.TabIndex = 27
        '
        'cmdUpper
        '
        Me.cmdUpper.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpper.Location = New System.Drawing.Point(571, 479)
        Me.cmdUpper.Name = "cmdUpper"
        Me.cmdUpper.Size = New System.Drawing.Size(85, 40)
        Me.cmdUpper.TabIndex = 32
        Me.cmdUpper.Text = "上　詰"
        '
        'cmdLower
        '
        Me.cmdLower.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLower.Location = New System.Drawing.Point(666, 479)
        Me.cmdLower.Name = "cmdLower"
        Me.cmdLower.Size = New System.Drawing.Size(85, 40)
        Me.cmdLower.TabIndex = 33
        Me.cmdLower.Text = "下　詰"
        '
        'cmdWFMove2
        '
        Me.cmdWFMove2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFMove2.Location = New System.Drawing.Point(760, 479)
        Me.cmdWFMove2.Name = "cmdWFMove2"
        Me.cmdWFMove2.Size = New System.Drawing.Size(85, 40)
        Me.cmdWFMove2.TabIndex = 31
        Me.cmdWFMove2.Text = "確　定"
        '
        'cmdMoveCancel2
        '
        Me.cmdMoveCancel2.Enabled = false
        Me.cmdMoveCancel2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMoveCancel2.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMoveCancel2.Location = New System.Drawing.Point(264, 257)
        Me.cmdMoveCancel2.Name = "cmdMoveCancel2"
        Me.cmdMoveCancel2.Size = New System.Drawing.Size(85, 40)
        Me.cmdMoveCancel2.TabIndex = 29
        Me.cmdMoveCancel2.Text = "<"
        '
        'cmdMove2
        '
        Me.cmdMove2.Enabled = false
        Me.cmdMove2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMove2.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmdMove2.Location = New System.Drawing.Point(264, 181)
        Me.cmdMove2.Name = "cmdMove2"
        Me.cmdMove2.Size = New System.Drawing.Size(85, 40)
        Me.cmdMove2.TabIndex = 28
        Me.cmdMove2.Text = ">"
        '
        'fraCarrierMntTab2
        '
        Me.fraCarrierMntTab2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraCarrierMntTab2.Controls.Add(Me.fraCarrierMnt2)
        Me.fraCarrierMntTab2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrierMntTab2.ForeColor = System.Drawing.Color.Black
        Me.fraCarrierMntTab2.Location = New System.Drawing.Point(4, 25)
        Me.fraCarrierMntTab2.Margin = New System.Windows.Forms.Padding(0)
        Me.fraCarrierMntTab2.Name = "fraCarrierMntTab2"
        Me.fraCarrierMntTab2.Size = New System.Drawing.Size(848, 525)
        Me.fraCarrierMntTab2.TabIndex = 2
        Me.fraCarrierMntTab2.Text = "WF廃棄"
        '
        'fraCarrierMnt2
        '
        Me.fraCarrierMnt2.Controls.Add(Me.cmdWFAllSelect)
        Me.fraCarrierMnt2.Controls.Add(Me.cmdCommentUp)
        Me.fraCarrierMnt2.Controls.Add(Me.cmdCommentDown)
        Me.fraCarrierMnt2.Controls.Add(Me.cmdWFScrap)
        Me.fraCarrierMnt2.Controls.Add(Me.vsfMoveSlotMap5)
        Me.fraCarrierMnt2.Controls.Add(Me.txtComment)
        Me.fraCarrierMnt2.Controls.Add(Me.lblLengthCount)
        Me.fraCarrierMnt2.Controls.Add(Me.lblTtl15)
        Me.fraCarrierMnt2.Enabled = false
        Me.fraCarrierMnt2.Location = New System.Drawing.Point(0, 1)
        Me.fraCarrierMnt2.Name = "fraCarrierMnt2"
        Me.fraCarrierMnt2.Size = New System.Drawing.Size(848, 523)
        Me.fraCarrierMnt2.TabIndex = 81
        '
        'cmdWFAllSelect
        '
        Me.cmdWFAllSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFAllSelect.Location = New System.Drawing.Point(168, 479)
        Me.cmdWFAllSelect.Name = "cmdWFAllSelect"
        Me.cmdWFAllSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdWFAllSelect.TabIndex = 35
        Me.cmdWFAllSelect.Text = "全数選択"
        '
        'cmdCommentUp
        '
        Me.cmdCommentUp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentUp.Location = New System.Drawing.Point(816, 237)
        Me.cmdCommentUp.Name = "cmdCommentUp"
        Me.cmdCommentUp.Size = New System.Drawing.Size(25, 113)
        Me.cmdCommentUp.TabIndex = 38
        Me.cmdCommentUp.Text = "▲"
        '
        'cmdCommentDown
        '
        Me.cmdCommentDown.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCommentDown.Location = New System.Drawing.Point(816, 350)
        Me.cmdCommentDown.Name = "cmdCommentDown"
        Me.cmdCommentDown.Size = New System.Drawing.Size(25, 111)
        Me.cmdCommentDown.TabIndex = 39
        Me.cmdCommentDown.Text = "▼"
        '
        'cmdWFScrap
        '
        Me.cmdWFScrap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdWFScrap.Location = New System.Drawing.Point(760, 479)
        Me.cmdWFScrap.Name = "cmdWFScrap"
        Me.cmdWFScrap.Size = New System.Drawing.Size(85, 40)
        Me.cmdWFScrap.TabIndex = 36
        Me.cmdWFScrap.Text = "確　定"
        '
        'vsfMoveSlotMap5
        '
        Me.vsfMoveSlotMap5.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMoveSlotMap5.AllowEditing = false
        Me.vsfMoveSlotMap5.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMoveSlotMap5.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMoveSlotMap5.AutoResize = true
        Me.vsfMoveSlotMap5.AutoSearchDelay = 2R
        Me.vsfMoveSlotMap5.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMoveSlotMap5.ColumnInfo = resources.GetString("vsfMoveSlotMap5.ColumnInfo")
        Me.vsfMoveSlotMap5.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMoveSlotMap5.ExtendLastCol = true
        Me.vsfMoveSlotMap5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMoveSlotMap5.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMoveSlotMap5.Location = New System.Drawing.Point(32, 16)
        Me.vsfMoveSlotMap5.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMoveSlotMap5.Name = "vsfMoveSlotMap5"
        Me.vsfMoveSlotMap5.Rows.Count = 26
        Me.vsfMoveSlotMap5.Rows.DefaultSize = 17
        Me.vsfMoveSlotMap5.Rows.MinSize = 17
        Me.vsfMoveSlotMap5.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMoveSlotMap5.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMoveSlotMap5.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMoveSlotMap5.Size = New System.Drawing.Size(319, 444)
        Me.vsfMoveSlotMap5.StyleInfo = resources.GetString("vsfMoveSlotMap5.StyleInfo")
        Me.vsfMoveSlotMap5.TabIndex = 34
        '
        'txtComment
        '
        Me.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtComment.ChrMaxByte = 0
        Me.txtComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtComment.GotHighLight = false
        Me.txtComment.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtComment.Location = New System.Drawing.Point(354, 255)
        Me.txtComment.MultiLineEx = true
        Me.txtComment.Name = "txtComment"
        Me.txtComment.NgChr = "'"
        Me.txtComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtComment.SelectedText = ""
        Me.txtComment.Size = New System.Drawing.Size(462, 205)
        Me.txtComment.TabIndex = 37
        '
        'lblLengthCount
        '
        Me.lblLengthCount.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount.Location = New System.Drawing.Point(566, 240)
        Me.lblLengthCount.Name = "lblLengthCount"
        Me.lblLengthCount.Size = New System.Drawing.Size(247, 17)
        Me.lblLengthCount.TabIndex = 85
        Me.lblLengthCount.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTtl15
        '
        Me.lblTtl15.BackColor = System.Drawing.Color.Navy
        Me.lblTtl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl15.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl15.Location = New System.Drawing.Point(354, 239)
        Me.lblTtl15.Name = "lblTtl15"
        Me.lblTtl15.Size = New System.Drawing.Size(462, 17)
        Me.lblTtl15.TabIndex = 86
        Me.lblTtl15.Text = "                 コメント"
        '
        'fraCarrierMntTab3
        '
        Me.fraCarrierMntTab3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraCarrierMntTab3.Controls.Add(Me.fraCarrierMnt3)
        Me.fraCarrierMntTab3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrierMntTab3.ForeColor = System.Drawing.Color.Black
        Me.fraCarrierMntTab3.Location = New System.Drawing.Point(4, 25)
        Me.fraCarrierMntTab3.Margin = New System.Windows.Forms.Padding(0)
        Me.fraCarrierMntTab3.Name = "fraCarrierMntTab3"
        Me.fraCarrierMntTab3.Size = New System.Drawing.Size(848, 525)
        Me.fraCarrierMntTab3.TabIndex = 3
        Me.fraCarrierMntTab3.Text = "キャリア位置変更"
        '
        'fraCarrierMnt3
        '
        Me.fraCarrierMnt3.Controls.Add(Me.picDownAllow)
        Me.fraCarrierMnt3.Controls.Add(Me.cmdChgStocker)
        Me.fraCarrierMnt3.Controls.Add(Me.cmbChangePosiotionID)
        Me.fraCarrierMnt3.Controls.Add(Me.lblCurrentPositionID)
        Me.fraCarrierMnt3.Controls.Add(Me.lblTitle3)
        Me.fraCarrierMnt3.Controls.Add(Me.lblTitle31)
        Me.fraCarrierMnt3.Enabled = false
        Me.fraCarrierMnt3.Location = New System.Drawing.Point(0, 1)
        Me.fraCarrierMnt3.Name = "fraCarrierMnt3"
        Me.fraCarrierMnt3.Size = New System.Drawing.Size(848, 523)
        Me.fraCarrierMnt3.TabIndex = 82
        '
        'picDownAllow
        '
        Me.picDownAllow.Image = CType(resources.GetObject("picDownAllow.Image"),System.Drawing.Image)
        Me.picDownAllow.Location = New System.Drawing.Point(415, 200)
        Me.picDownAllow.Name = "picDownAllow"
        Me.picDownAllow.Size = New System.Drawing.Size(32, 32)
        Me.picDownAllow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDownAllow.TabIndex = 95
        Me.picDownAllow.TabStop = false
        '
        'cmdChgStocker
        '
        Me.cmdChgStocker.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdChgStocker.Location = New System.Drawing.Point(760, 479)
        Me.cmdChgStocker.Name = "cmdChgStocker"
        Me.cmdChgStocker.Size = New System.Drawing.Size(85, 40)
        Me.cmdChgStocker.TabIndex = 41
        Me.cmdChgStocker.Text = "確　定"
        '
        'cmbChangePosiotionID
        '
        Me.cmbChangePosiotionID.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbChangePosiotionID.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.cmbChangePosiotionID.Location = New System.Drawing.Point(280, 279)
        Me.cmbChangePosiotionID.Name = "cmbChangePosiotionID"
        Me.cmbChangePosiotionID.Size = New System.Drawing.Size(297, 22)
        Me.cmbChangePosiotionID.TabIndex = 40
        Me.cmbChangePosiotionID.Value = Nothing
        '
        'lblCurrentPositionID
        '
        Me.lblCurrentPositionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentPositionID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCurrentPositionID.Location = New System.Drawing.Point(280, 142)
        Me.lblCurrentPositionID.Name = "lblCurrentPositionID"
        Me.lblCurrentPositionID.Size = New System.Drawing.Size(297, 22)
        Me.lblCurrentPositionID.TabIndex = 53
        Me.lblCurrentPositionID.Text = "123456789012345678901234567890"
        '
        'lblTitle3
        '
        Me.lblTitle3.BackColor = System.Drawing.Color.Navy
        Me.lblTitle3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle3.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle3.Location = New System.Drawing.Point(280, 263)
        Me.lblTitle3.Name = "lblTitle3"
        Me.lblTitle3.Size = New System.Drawing.Size(297, 17)
        Me.lblTitle3.TabIndex = 88
        Me.lblTitle3.Text = "変更後位置"
        Me.lblTitle3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle31
        '
        Me.lblTitle31.BackColor = System.Drawing.Color.Navy
        Me.lblTitle31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle31.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle31.Location = New System.Drawing.Point(280, 126)
        Me.lblTitle31.Name = "lblTitle31"
        Me.lblTitle31.Size = New System.Drawing.Size(297, 17)
        Me.lblTitle31.TabIndex = 87
        Me.lblTitle31.Text = "現在位置"
        Me.lblTitle31.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fraCarrierMntTab4
        '
        Me.fraCarrierMntTab4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fraCarrierMntTab4.Controls.Add(Me.fraCarrierMnt4)
        Me.fraCarrierMntTab4.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraCarrierMntTab4.ForeColor = System.Drawing.Color.Black
        Me.fraCarrierMntTab4.Location = New System.Drawing.Point(4, 25)
        Me.fraCarrierMntTab4.Margin = New System.Windows.Forms.Padding(0)
        Me.fraCarrierMntTab4.Name = "fraCarrierMntTab4"
        Me.fraCarrierMntTab4.Size = New System.Drawing.Size(848, 525)
        Me.fraCarrierMntTab4.TabIndex = 4
        Me.fraCarrierMntTab4.Text = "キャリア交換"
        '
        'fraCarrierMnt4
        '
        Me.fraCarrierMnt4.Controls.Add(Me.fraSlotMap5)
        Me.fraCarrierMnt4.Controls.Add(Me.fraSlotMap6)
        Me.fraCarrierMnt4.Controls.Add(Me.cmdExchange)
        Me.fraCarrierMnt4.Enabled = false
        Me.fraCarrierMnt4.Location = New System.Drawing.Point(0, 1)
        Me.fraCarrierMnt4.Name = "fraCarrierMnt4"
        Me.fraCarrierMnt4.Size = New System.Drawing.Size(848, 523)
        Me.fraCarrierMnt4.TabIndex = 91
        Me.fraCarrierMnt4.Text = "Frame1"
        '
        'fraSlotMap5
        '
        Me.fraSlotMap5.Controls.Add(Me.vsfMoveSlotMap6)
        Me.fraSlotMap5.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotMap5.Location = New System.Drawing.Point(8, 0)
        Me.fraSlotMap5.Name = "fraSlotMap5"
        Me.fraSlotMap5.Size = New System.Drawing.Size(247, 472)
        Me.fraSlotMap5.TabIndex = 42
        Me.fraSlotMap5.TabStop = false
        Me.fraSlotMap5.Text = "交換元"
        '
        'vsfMoveSlotMap6
        '
        Me.vsfMoveSlotMap6.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMoveSlotMap6.AllowEditing = false
        Me.vsfMoveSlotMap6.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMoveSlotMap6.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMoveSlotMap6.AutoResize = true
        Me.vsfMoveSlotMap6.AutoSearchDelay = 2R
        Me.vsfMoveSlotMap6.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMoveSlotMap6.ColumnInfo = resources.GetString("vsfMoveSlotMap6.ColumnInfo")
        Me.vsfMoveSlotMap6.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMoveSlotMap6.ExtendLastCol = true
        Me.vsfMoveSlotMap6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMoveSlotMap6.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMoveSlotMap6.Location = New System.Drawing.Point(24, 16)
        Me.vsfMoveSlotMap6.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMoveSlotMap6.Name = "vsfMoveSlotMap6"
        Me.vsfMoveSlotMap6.Rows.Count = 26
        Me.vsfMoveSlotMap6.Rows.DefaultSize = 17
        Me.vsfMoveSlotMap6.Rows.MinSize = 17
        Me.vsfMoveSlotMap6.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMoveSlotMap6.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMoveSlotMap6.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMoveSlotMap6.Size = New System.Drawing.Size(207, 444)
        Me.vsfMoveSlotMap6.StyleInfo = resources.GetString("vsfMoveSlotMap6.StyleInfo")
        Me.vsfMoveSlotMap6.TabIndex = 42
        '
        'fraSlotMap6
        '
        Me.fraSlotMap6.Controls.Add(Me.fraWork)
        Me.fraSlotMap6.Controls.Add(Me.cmdCarrierSelect2)
        Me.fraSlotMap6.Controls.Add(Me.txtCarrierMnt2)
        Me.fraSlotMap6.Controls.Add(Me.vsfMoveSlotMap7)
        Me.fraSlotMap6.Controls.Add(Me.lblBack)
        Me.fraSlotMap6.Controls.Add(Me.lblTtl1)
        Me.fraSlotMap6.Controls.Add(Me.lblTtl0)
        Me.fraSlotMap6.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.fraSlotMap6.Location = New System.Drawing.Point(299, 0)
        Me.fraSlotMap6.Name = "fraSlotMap6"
        Me.fraSlotMap6.Size = New System.Drawing.Size(542, 472)
        Me.fraSlotMap6.TabIndex = 43
        Me.fraSlotMap6.TabStop = false
        Me.fraSlotMap6.Text = "交換先"
        '
        'fraWork
        '
        Me.fraWork.Controls.Add(Me.optOnline1)
        Me.fraWork.Controls.Add(Me.optOnline0)
        Me.fraWork.Location = New System.Drawing.Point(410, 363)
        Me.fraWork.Name = "fraWork"
        Me.fraWork.Size = New System.Drawing.Size(124, 93)
        Me.fraWork.TabIndex = 44
        '
        'optOnline1
        '
        Me.optOnline1.Enabled = false
        Me.optOnline1.Location = New System.Drawing.Point(4, 48)
        Me.optOnline1.Name = "optOnline1"
        Me.optOnline1.Size = New System.Drawing.Size(109, 41)
        Me.optOnline1.TabIndex = 45
        Me.optOnline1.Text = "オンライン"
        '
        'optOnline0
        '
        Me.optOnline0.Checked = true
        Me.optOnline0.Location = New System.Drawing.Point(4, 4)
        Me.optOnline0.Name = "optOnline0"
        Me.optOnline0.Size = New System.Drawing.Size(109, 41)
        Me.optOnline0.TabIndex = 44
        Me.optOnline0.TabStop = true
        Me.optOnline0.Text = "オフライン"
        '
        'cmdCarrierSelect2
        '
        Me.cmdCarrierSelect2.CausesValidation = false
        Me.cmdCarrierSelect2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCarrierSelect2.Location = New System.Drawing.Point(8, 62)
        Me.cmdCarrierSelect2.Name = "cmdCarrierSelect2"
        Me.cmdCarrierSelect2.Size = New System.Drawing.Size(85, 40)
        Me.cmdCarrierSelect2.TabIndex = 48
        Me.cmdCarrierSelect2.Text = "空きｷｬﾘｱ"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'txtCarrierMnt2
        '
        Me.txtCarrierMnt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCarrierMnt2.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper
        Me.txtCarrierMnt2.ChrMaxByte = 6
        Me.txtCarrierMnt2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCarrierMnt2.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num
        Me.txtCarrierMnt2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCarrierMnt2.Location = New System.Drawing.Point(8, 34)
        Me.txtCarrierMnt2.Name = "txtCarrierMnt2"
        Me.txtCarrierMnt2.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCarrierMnt2.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCarrierMnt2.SelectedText = ""
        Me.txtCarrierMnt2.Size = New System.Drawing.Size(92, 22)
        Me.txtCarrierMnt2.TabIndex = 43
        '
        'vsfMoveSlotMap7
        '
        Me.vsfMoveSlotMap7.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfMoveSlotMap7.AllowEditing = false
        Me.vsfMoveSlotMap7.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfMoveSlotMap7.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfMoveSlotMap7.AutoResize = true
        Me.vsfMoveSlotMap7.AutoSearchDelay = 2R
        Me.vsfMoveSlotMap7.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfMoveSlotMap7.ColumnInfo = resources.GetString("vsfMoveSlotMap7.ColumnInfo")
        Me.vsfMoveSlotMap7.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfMoveSlotMap7.ExtendLastCol = true
        Me.vsfMoveSlotMap7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfMoveSlotMap7.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfMoveSlotMap7.Location = New System.Drawing.Point(104, 16)
        Me.vsfMoveSlotMap7.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfMoveSlotMap7.Name = "vsfMoveSlotMap7"
        Me.vsfMoveSlotMap7.Rows.Count = 26
        Me.vsfMoveSlotMap7.Rows.DefaultSize = 17
        Me.vsfMoveSlotMap7.Rows.MinSize = 17
        Me.vsfMoveSlotMap7.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.vsfMoveSlotMap7.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfMoveSlotMap7.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.vsfMoveSlotMap7.Size = New System.Drawing.Size(300, 444)
        Me.vsfMoveSlotMap7.StyleInfo = resources.GetString("vsfMoveSlotMap7.StyleInfo")
        Me.vsfMoveSlotMap7.TabIndex = 46
        '
        'lblBack
        '
        Me.lblBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBack.Location = New System.Drawing.Point(408, 359)
        Me.lblBack.Name = "lblBack"
        Me.lblBack.Size = New System.Drawing.Size(129, 101)
        Me.lblBack.TabIndex = 44
        '
        'lblTtl1
        '
        Me.lblTtl1.BackColor = System.Drawing.Color.Navy
        Me.lblTtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl1.Location = New System.Drawing.Point(408, 343)
        Me.lblTtl1.Name = "lblTtl1"
        Me.lblTtl1.Size = New System.Drawing.Size(129, 17)
        Me.lblTtl1.TabIndex = 99
        Me.lblTtl1.Text = "処理状態"
        Me.lblTtl1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTtl0
        '
        Me.lblTtl0.BackColor = System.Drawing.Color.Navy
        Me.lblTtl0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTtl0.ForeColor = System.Drawing.Color.Yellow
        Me.lblTtl0.Location = New System.Drawing.Point(8, 18)
        Me.lblTtl0.Name = "lblTtl0"
        Me.lblTtl0.Size = New System.Drawing.Size(92, 17)
        Me.lblTtl0.TabIndex = 93
        Me.lblTtl0.Text = "キャリアID"
        Me.lblTtl0.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdExchange
        '
        Me.cmdExchange.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdExchange.Location = New System.Drawing.Point(760, 479)
        Me.cmdExchange.Name = "cmdExchange"
        Me.cmdExchange.Size = New System.Drawing.Size(85, 40)
        Me.cmdExchange.TabIndex = 47
        Me.cmdExchange.Text = "確　定"
        '
        'lblTitle30
        '
        Me.lblTitle30.BackColor = System.Drawing.Color.Navy
        Me.lblTitle30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle30.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle30.Location = New System.Drawing.Point(6, 13)
        Me.lblTitle30.Name = "lblTitle30"
        Me.lblTitle30.Size = New System.Drawing.Size(92, 17)
        Me.lblTitle30.TabIndex = 75
        Me.lblTitle30.Text = "キャリアID"
        Me.lblTitle30.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 597)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 52
        Me.cmdClose.Text = "閉じる"
        '
        'frmxxCM00C0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdCarrierClean)
        Me.Controls.Add(Me.tabCarrier)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00C0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "キャリア管理"
        Me.tabCarrier.ResumeLayout(false)
        Me.fraCarrierTab0.ResumeLayout(false)
        Me.fraCarrier0.ResumeLayout(false)
        Me.fraCarrier0.PerformLayout
        Me.fraCarrierTab1.ResumeLayout(false)
        Me.fraCarrier1.ResumeLayout(false)
        CType(Me.vsfCarrierList,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCarrierTab2.ResumeLayout(false)
        Me.fraCarrier2.ResumeLayout(false)
        Me.tabCarrierMnt.ResumeLayout(false)
        Me.fraCarrierMntTab0.ResumeLayout(false)
        Me.fraCarrierMnt0.ResumeLayout(false)
        Me.fraSlotMap2.ResumeLayout(false)
        CType(Me.vsfMoveSlotMap2,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraSlotMap1.ResumeLayout(false)
        CType(Me.vsfMoveSlotMap,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCarrierMntTab1.ResumeLayout(false)
        Me.fraCarrierMnt1.ResumeLayout(false)
        Me.fraSlotMap4.ResumeLayout(false)
        CType(Me.vsfMoveSlotMap4,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraSlotMap3.ResumeLayout(false)
        CType(Me.vsfMoveSlotMap3,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCarrierMntTab2.ResumeLayout(false)
        Me.fraCarrierMnt2.ResumeLayout(false)
        CType(Me.vsfMoveSlotMap5,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCarrierMntTab3.ResumeLayout(false)
        Me.fraCarrierMnt3.ResumeLayout(false)
        CType(Me.picDownAllow,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraCarrierMntTab4.ResumeLayout(false)
        Me.fraCarrierMnt4.ResumeLayout(false)
        Me.fraSlotMap5.ResumeLayout(false)
        CType(Me.vsfMoveSlotMap6,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraSlotMap6.ResumeLayout(false)
        Me.fraWork.ResumeLayout(false)
        CType(Me.vsfMoveSlotMap7,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdCarrierClean As Button
    Friend WithEvents tabCarrier As TabControl
    Friend WithEvents fraCarrierTab0 As TabPage
    Friend WithEvents fraCarrier0 As Panel
    Friend WithEvents cmdDel As Button
    Friend WithEvents cmdRegist As Button
    Friend WithEvents calManuDate As SECalendarEx.CalendarEx
    Friend WithEvents calUseStartDate As SECalendarEx.CalendarEx
    Friend WithEvents txtCarrierID0 As SETextBoxEx.TextBoxEx
    Friend WithEvents cmbSBID0 As SEComboBoxEx.ComboBoxEx
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTitle02 As Label
    Friend WithEvents lblTitle05 As Label
    Friend WithEvents lblTitle03 As Label
    Friend WithEvents lblTitle04 As Label
    Friend WithEvents lblTitle01 As Label
    Friend WithEvents lblTitle00 As Label
    Friend WithEvents lblCarrierType As Label
    Friend WithEvents lblWashDuraNum As Label
    Friend WithEvents lblUseDuraNum As Label
    Friend WithEvents lblTitle06 As Label
    Friend WithEvents lblVendorName As Label
    Friend WithEvents lblTitle07 As Label
    Friend WithEvents lblSlotNum As Label
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents fraCarrierTab1 As TabPage
    Friend WithEvents fraCarrier1 As Panel
    Friend WithEvents cmdUp As Button
    Friend WithEvents cmdDown As Button
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents cmdCarrierForcedmove As Button
    Friend WithEvents cmdShip As Button
    Friend WithEvents cmdNowList As Button
    Friend WithEvents cmdClean As Button
    Friend WithEvents cmbCarrType As SEComboBoxEx.ComboBoxEx
    Friend WithEvents vsfCarrierList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmbSBID1 As SEComboBoxEx.ComboBoxEx
    Friend WithEvents cmbStockerName As SECmbIchiran.ComboIchiran
    Friend WithEvents cmbUseCategory As SECmbIchiran.ComboIchiran
    Friend WithEvents txtCarrierComments As SETextBoxEx.TextBoxEx
    Friend WithEvents lblCarrierLengthCount As Label
    Friend WithEvents lblTitle8 As Label
    Friend WithEvents lblTitle6 As Label
    Friend WithEvents lblTitle5 As Label
    Friend WithEvents lblTitle7 As Label
    Friend WithEvents lblNowDate As Label
    Friend WithEvents lblCarrierCnt As Label
    Friend WithEvents lblTitle4 As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblTitle2 As Label
    Friend WithEvents fraCarrierTab2 As TabPage
    Friend WithEvents fraCarrier2 As Panel
    Friend WithEvents txtCarrierID2 As SETextBoxEx.TextBoxEx
    Friend WithEvents tabCarrierMnt As TabControl
    Friend WithEvents fraCarrierMntTab0 As TabPage
    Friend WithEvents fraCarrierMnt0 As Panel
    Friend WithEvents cmdWFMove As Button
    Friend WithEvents fraSlotMap2 As GroupBox
    Friend WithEvents cmdCarrierSelect As Button
    Friend WithEvents txtCarrierMnt As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfMoveSlotMap2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblTtl2 As Label
    Friend WithEvents fraSlotMap1 As GroupBox
    Friend WithEvents vsfMoveSlotMap As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdMove As Button
    Friend WithEvents cmdMoveCancel As Button
    Friend WithEvents fraCarrierMntTab1 As TabPage
    Friend WithEvents fraCarrierMnt1 As Panel
    Friend WithEvents fraSlotMap4 As GroupBox
    Friend WithEvents cmdJigSelect As Button
    Friend WithEvents vsfMoveSlotMap4 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraSlotMap3 As GroupBox
    Friend WithEvents vsfMoveSlotMap3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdUpper As Button
    Friend WithEvents cmdLower As Button
    Friend WithEvents cmdWFMove2 As Button
    Friend WithEvents cmdMoveCancel2 As Button
    Friend WithEvents cmdMove2 As Button
    Friend WithEvents fraCarrierMntTab2 As TabPage
    Friend WithEvents fraCarrierMnt2 As Panel
    Friend WithEvents cmdWFAllSelect As Button
    Friend WithEvents cmdCommentUp As Button
    Friend WithEvents cmdCommentDown As Button
    Friend WithEvents cmdWFScrap As Button
    Friend WithEvents vsfMoveSlotMap5 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtComment As SETextBoxEx.TextBoxEx
    Friend WithEvents lblLengthCount As Label
    Friend WithEvents lblTtl15 As Label
    Friend WithEvents fraCarrierMntTab3 As TabPage
    Friend WithEvents fraCarrierMnt3 As Panel
    Friend WithEvents picDownAllow As PictureBox
    Friend WithEvents cmdChgStocker As Button
    Friend WithEvents cmbChangePosiotionID As SEComboBoxEx.ComboBoxEx
    Friend WithEvents lblCurrentPositionID As Label
    Friend WithEvents lblTitle3 As Label
    Friend WithEvents lblTitle31 As Label
    Friend WithEvents fraCarrierMntTab4 As TabPage
    Friend WithEvents fraCarrierMnt4 As Panel
    Friend WithEvents fraSlotMap5 As GroupBox
    Friend WithEvents vsfMoveSlotMap6 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fraSlotMap6 As GroupBox
    Friend WithEvents fraWork As Panel
    Friend WithEvents optOnline1 As RadioButton
    Friend WithEvents optOnline0 As RadioButton
    Friend WithEvents cmdCarrierSelect2 As Button
    Friend WithEvents txtCarrierMnt2 As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfMoveSlotMap7 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblBack As Label
    Friend WithEvents lblTtl1 As Label
    Friend WithEvents lblTtl0 As Label
    Friend WithEvents cmdExchange As Button
    Friend WithEvents lblTitle30 As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents txtDummy0 As TextBox
End Class
