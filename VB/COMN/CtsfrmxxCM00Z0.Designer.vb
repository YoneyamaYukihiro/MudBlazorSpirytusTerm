<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxxCM00Z0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmxxCM00Z0))
        Me.cmdDispose = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdApprove = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdMail = New System.Windows.Forms.Button()
        Me.tabMainteSheet = New System.Windows.Forms.TabControl()
        Me.Tab0 = New System.Windows.Forms.TabPage()
        Me.fraRepairBaseInfo = New System.Windows.Forms.Panel()
        Me.lblRepairEndDateTitle = New System.Windows.Forms.Label()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.calRepairEndDate = New SECalendarEx.CalendarEx()
        Me.medRepairEndTime = New System.Windows.Forms.MaskedTextBox()
        Me.cmdNowDate0 = New System.Windows.Forms.Button()
        Me.cmdCancel0 = New System.Windows.Forms.Button()
        Me.cmdSign0 = New System.Windows.Forms.Button()
        Me.cmdRepairNameSelect = New System.Windows.Forms.Button()
        Me.cmdUp0 = New System.Windows.Forms.Button()
        Me.cmdDown0 = New System.Windows.Forms.Button()
        Me.txtRepairName = New SETextBoxEx.TextBoxEx()
        Me.txtRepairContents = New SETextBoxEx.TextBoxEx()
        Me.vsfToEmpName0 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblSignName0 = New System.Windows.Forms.Label()
        Me.lblSignDate0 = New System.Windows.Forms.Label()
        Me.lblRepairContentsSignField = New System.Windows.Forms.Label()
        Me.lblRepairContentsSignTitle = New System.Windows.Forms.Label()
        Me.lblLengthCount1 = New System.Windows.Forms.Label()
        Me.lblLengthCount2 = New System.Windows.Forms.Label()
        Me.lblFromEmpName0 = New System.Windows.Forms.Label()
        Me.lblFromDate0 = New System.Windows.Forms.Label()
        Me.lblUpdateName0 = New System.Windows.Forms.Label()
        Me.lblUpdate0 = New System.Windows.Forms.Label()
        Me.lblRepairStartDate = New System.Windows.Forms.Label()
        Me.lblRepairPreserver = New System.Windows.Forms.Label()
        Me.lblFindEmpName = New System.Windows.Forms.Label()
        Me.lblRepairTitle = New System.Windows.Forms.Label()
        Me.lblHeaderInfo = New System.Windows.Forms.Label()
        Me.lblRepairBaseInfoTitle = New System.Windows.Forms.Label()
        Me.lblRepairWpNameTitle = New System.Windows.Forms.Label()
        Me.lblRepairStartDateTitle = New System.Windows.Forms.Label()
        Me.lblFindEmpNameTitle = New System.Windows.Forms.Label()
        Me.lblRepairPreserverTitle = New System.Windows.Forms.Label()
        Me.lblRepairNameInfo = New System.Windows.Forms.Label()
        Me.lblRepairNameTitle = New System.Windows.Forms.Label()
        Me.lblRepairContentsTitle = New System.Windows.Forms.Label()
        Me.lblRepairNoTitle = New System.Windows.Forms.Label()
        Me.lblRepairNo = New System.Windows.Forms.Label()
        Me.lblFindDeptNameTitle = New System.Windows.Forms.Label()
        Me.lblFindDeptName = New System.Windows.Forms.Label()
        Me.lblRepairWpName = New System.Windows.Forms.Label()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.fraRepairCauseInfo = New System.Windows.Forms.Panel()
        Me.lblRepairWorkCostTitle = New System.Windows.Forms.Label()
        Me.lblRepairPartCostTitle = New System.Windows.Forms.Label()
        Me.pic2 = New System.Windows.Forms.PictureBox()
        Me.optCopeDivision0 = New System.Windows.Forms.RadioButton()
        Me.optCopeDivision1 = New System.Windows.Forms.RadioButton()
        Me.pic3 = New System.Windows.Forms.PictureBox()
        Me.txtPartCost0 = New SETextBoxEx.TextBoxEx()
        Me.txtWorkCost0 = New SETextBoxEx.TextBoxEx()
        Me.lblRepairWorkCostUnit = New System.Windows.Forms.Label()
        Me.lblRepairPartCostUnit = New System.Windows.Forms.Label()
        Me.cmdSign6 = New System.Windows.Forms.Button()
        Me.cmdCancel6 = New System.Windows.Forms.Button()
        Me.cmdSign5 = New System.Windows.Forms.Button()
        Me.cmdCancel5 = New System.Windows.Forms.Button()
        Me.cmdSign4 = New System.Windows.Forms.Button()
        Me.cmdCancel4 = New System.Windows.Forms.Button()
        Me.cmdSign3 = New System.Windows.Forms.Button()
        Me.cmdCancel3 = New System.Windows.Forms.Button()
        Me.cmdSign2 = New System.Windows.Forms.Button()
        Me.cmdCancel2 = New System.Windows.Forms.Button()
        Me.cmdSign1 = New System.Windows.Forms.Button()
        Me.cmdCancel1 = New System.Windows.Forms.Button()
        Me.cmdDown2 = New System.Windows.Forms.Button()
        Me.cmdUp2 = New System.Windows.Forms.Button()
        Me.cmdDown1 = New System.Windows.Forms.Button()
        Me.cmdUp1 = New System.Windows.Forms.Button()
        Me.cmdDown3 = New System.Windows.Forms.Button()
        Me.cmdUp3 = New System.Windows.Forms.Button()
        Me.txtCause = New SETextBoxEx.TextBoxEx()
        Me.txtAnalysisContents = New SETextBoxEx.TextBoxEx()
        Me.txtMeasure = New SETextBoxEx.TextBoxEx()
        Me.lblRepairCopeDivision = New System.Windows.Forms.Label()
        Me.lblRepairCopeDivisionTitle = New System.Windows.Forms.Label()
        Me.lblRepairResultCostInfoTitle = New System.Windows.Forms.Label()
        Me.lblSignName6 = New System.Windows.Forms.Label()
        Me.lblSignDate6 = New System.Windows.Forms.Label()
        Me.lblSignName5 = New System.Windows.Forms.Label()
        Me.lblSignDate5 = New System.Windows.Forms.Label()
        Me.lblSignName4 = New System.Windows.Forms.Label()
        Me.lblSignDate4 = New System.Windows.Forms.Label()
        Me.lblSignName3 = New System.Windows.Forms.Label()
        Me.lblSignDate3 = New System.Windows.Forms.Label()
        Me.lblSignName2 = New System.Windows.Forms.Label()
        Me.lblSignDate2 = New System.Windows.Forms.Label()
        Me.lblSignName1 = New System.Windows.Forms.Label()
        Me.lblSignDate1 = New System.Windows.Forms.Label()
        Me.lblRepairProductLeaderSignTitle = New System.Windows.Forms.Label()
        Me.lblRepairProductLeaderSignField = New System.Windows.Forms.Label()
        Me.lblRepairPreserveLeaderSignTitle = New System.Windows.Forms.Label()
        Me.lblRepairPreserverLeaderSignField = New System.Windows.Forms.Label()
        Me.lblRepairPreserverSignTitle = New System.Windows.Forms.Label()
        Me.lblRepairPreserveEmpSignField = New System.Windows.Forms.Label()
        Me.lblMeasureSignTitle = New System.Windows.Forms.Label()
        Me.lblMeasureSignField = New System.Windows.Forms.Label()
        Me.lblCauseSignTitle = New System.Windows.Forms.Label()
        Me.lblCauseSignField = New System.Windows.Forms.Label()
        Me.lblAnalysisSignTitle = New System.Windows.Forms.Label()
        Me.lblAnalysisSignField = New System.Windows.Forms.Label()
        Me.lblRepairSignTitle = New System.Windows.Forms.Label()
        Me.lblLengthCount5 = New System.Windows.Forms.Label()
        Me.lblLengthCount4 = New System.Windows.Forms.Label()
        Me.lblLengthCount3 = New System.Windows.Forms.Label()
        Me.lblRepairCauseInfoTitle = New System.Windows.Forms.Label()
        Me.lblCauseTitle = New System.Windows.Forms.Label()
        Me.lblAnalysisContentsTitle = New System.Windows.Forms.Label()
        Me.lblRepairMeasureInfoTitle = New System.Windows.Forms.Label()
        Me.lblMeasureTitle = New System.Windows.Forms.Label()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.fraPreserveBaseInfo = New System.Windows.Forms.Panel()
        Me.lblPreserveEndDateTitle = New System.Windows.Forms.Label()
        Me.pic4 = New System.Windows.Forms.PictureBox()
        Me.calPreserveEndDate = New SECalendarEx.CalendarEx()
        Me.medPreserveEndTime = New System.Windows.Forms.MaskedTextBox()
        Me.cmdDown4 = New System.Windows.Forms.Button()
        Me.cmdUp4 = New System.Windows.Forms.Button()
        Me.cmdNowDate1 = New System.Windows.Forms.Button()
        Me.txtPreserveComment = New SETextBoxEx.TextBoxEx()
        Me.vsfToEmpName1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblLengthCount6 = New System.Windows.Forms.Label()
        Me.lblPreserveCategory = New System.Windows.Forms.Label()
        Me.lblPreserveCategoryTitle = New System.Windows.Forms.Label()
        Me.lblPreserveCommonInfoTitle = New System.Windows.Forms.Label()
        Me.lblPreserveWpName = New System.Windows.Forms.Label()
        Me.lblPreserveNo = New System.Windows.Forms.Label()
        Me.lblPreserveNoTitle = New System.Windows.Forms.Label()
        Me.lblPreserveCommentTitle = New System.Windows.Forms.Label()
        Me.lblPreserverTitle = New System.Windows.Forms.Label()
        Me.lblPreserveStartDateTitle = New System.Windows.Forms.Label()
        Me.lblPreserveWpNameTitle = New System.Windows.Forms.Label()
        Me.lblPreserveBaseInfoTitle = New System.Windows.Forms.Label()
        Me.lblPreserveTitle = New System.Windows.Forms.Label()
        Me.lblPreserver = New System.Windows.Forms.Label()
        Me.lblPreserveStartDate = New System.Windows.Forms.Label()
        Me.lblUpdate1 = New System.Windows.Forms.Label()
        Me.lblUpdateName1 = New System.Windows.Forms.Label()
        Me.lblFromDate1 = New System.Windows.Forms.Label()
        Me.lblFromEmpName1 = New System.Windows.Forms.Label()
        Me.lblPreserveHeaderInfo = New System.Windows.Forms.Label()
        Me.Tab3 = New System.Windows.Forms.TabPage()
        Me.fraPreserveItemInfo = New System.Windows.Forms.Panel()
        Me.lblPreserveWorkCostTitle = New System.Windows.Forms.Label()
        Me.lblPreservePartCostTitle = New System.Windows.Forms.Label()
        Me.pic5 = New System.Windows.Forms.PictureBox()
        Me.optCopeDivision2 = New System.Windows.Forms.RadioButton()
        Me.optCopeDivision3 = New System.Windows.Forms.RadioButton()
        Me.pic6 = New System.Windows.Forms.PictureBox()
        Me.txtPartCost1 = New SETextBoxEx.TextBoxEx()
        Me.txtWorkCost1 = New SETextBoxEx.TextBoxEx()
        Me.lblPreserveWorkCostUnit = New System.Windows.Forms.Label()
        Me.lblPreservePartCostUnit = New System.Windows.Forms.Label()
        Me.cmdUp7 = New System.Windows.Forms.Button()
        Me.cmdDown7 = New System.Windows.Forms.Button()
        Me.cmdUp5 = New System.Windows.Forms.Button()
        Me.cmdDown5 = New System.Windows.Forms.Button()
        Me.cmdUp6 = New System.Windows.Forms.Button()
        Me.cmdDown6 = New System.Windows.Forms.Button()
        Me.cmdCancel7 = New System.Windows.Forms.Button()
        Me.cmdSign7 = New System.Windows.Forms.Button()
        Me.cmdCancel8 = New System.Windows.Forms.Button()
        Me.cmdSign8 = New System.Windows.Forms.Button()
        Me.cmdCancel9 = New System.Windows.Forms.Button()
        Me.cmdSign9 = New System.Windows.Forms.Button()
        Me.txtPreserveContents = New SETextBoxEx.TextBoxEx()
        Me.txtPreserveItem = New SETextBoxEx.TextBoxEx()
        Me.txtPreservePurpose = New SETextBoxEx.TextBoxEx()
        Me.lblPreserveCopeDivision = New System.Windows.Forms.Label()
        Me.lblPreserveCopeDivisionTitle = New System.Windows.Forms.Label()
        Me.lblPreserveResultCostInfoTitle = New System.Windows.Forms.Label()
        Me.lblSignDate9 = New System.Windows.Forms.Label()
        Me.lblSignName9 = New System.Windows.Forms.Label()
        Me.lblSignDate8 = New System.Windows.Forms.Label()
        Me.lblSignName8 = New System.Windows.Forms.Label()
        Me.lblSignName7 = New System.Windows.Forms.Label()
        Me.lblSignDate7 = New System.Windows.Forms.Label()
        Me.lblPreserveCategory2 = New System.Windows.Forms.Label()
        Me.lblPreserveCategoryTitle2 = New System.Windows.Forms.Label()
        Me.lblLengthCount7 = New System.Windows.Forms.Label()
        Me.lblLengthCount8 = New System.Windows.Forms.Label()
        Me.lblLengthCount9 = New System.Windows.Forms.Label()
        Me.lblPreservePurposeTitle = New System.Windows.Forms.Label()
        Me.lblPreserveItemTitle = New System.Windows.Forms.Label()
        Me.lblPreserveContentsTitle = New System.Windows.Forms.Label()
        Me.lblPreserveItemInfo = New System.Windows.Forms.Label()
        Me.lblPreserveSignTitle = New System.Windows.Forms.Label()
        Me.lblPreserveEmpSignField = New System.Windows.Forms.Label()
        Me.lblPreserverSignTitle = New System.Windows.Forms.Label()
        Me.lblPreserverLeaderSignField = New System.Windows.Forms.Label()
        Me.lblPreserveLeaderSignTitle = New System.Windows.Forms.Label()
        Me.lblProductLeaderSignField = New System.Windows.Forms.Label()
        Me.lblProductLeaderSignTitle = New System.Windows.Forms.Label()
        Me.tabMainteSheet.SuspendLayout
        Me.Tab0.SuspendLayout
        Me.fraRepairBaseInfo.SuspendLayout
        CType(Me.pic1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic1.SuspendLayout
        CType(Me.vsfToEmpName0,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab1.SuspendLayout
        Me.fraRepairCauseInfo.SuspendLayout
        CType(Me.pic2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic2.SuspendLayout
        CType(Me.pic3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic3.SuspendLayout
        Me.Tab2.SuspendLayout
        Me.fraPreserveBaseInfo.SuspendLayout
        CType(Me.pic4,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic4.SuspendLayout
        CType(Me.vsfToEmpName1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Tab3.SuspendLayout
        Me.fraPreserveItemInfo.SuspendLayout
        CType(Me.pic5,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic5.SuspendLayout
        CType(Me.pic6,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pic6.SuspendLayout
        Me.SuspendLayout
        '
        'cmdDispose
        '
        Me.cmdDispose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDispose.Location = New System.Drawing.Point(600, 595)
        Me.cmdDispose.Name = "cmdDispose"
        Me.cmdDispose.Size = New System.Drawing.Size(85, 40)
        Me.cmdDispose.TabIndex = 64
        Me.cmdDispose.Text = "処　置"
        '
        'cmdSave
        '
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Location = New System.Drawing.Point(696, 595)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(85, 40)
        Me.cmdSave.TabIndex = 63
        Me.cmdSave.Text = "一時保存"
        '
        'cmdApprove
        '
        Me.cmdApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdApprove.Location = New System.Drawing.Point(888, 595)
        Me.cmdApprove.Name = "cmdApprove"
        Me.cmdApprove.Size = New System.Drawing.Size(85, 40)
        Me.cmdApprove.TabIndex = 61
        Me.cmdApprove.Text = "承　認"
        '
        'cmdClose
        '
        Me.cmdClose.CausesValidation = false
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(8, 595)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(85, 40)
        Me.cmdClose.TabIndex = 65
        Me.cmdClose.Text = "閉じる"
        '
        'cmdMail
        '
        Me.cmdMail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMail.Location = New System.Drawing.Point(792, 595)
        Me.cmdMail.Name = "cmdMail"
        Me.cmdMail.Size = New System.Drawing.Size(85, 40)
        Me.cmdMail.TabIndex = 62
        Me.cmdMail.Text = "確認依頼"
        '
        'tabMainteSheet
        '
        Me.tabMainteSheet.Controls.Add(Me.Tab0)
        Me.tabMainteSheet.Controls.Add(Me.Tab1)
        Me.tabMainteSheet.Controls.Add(Me.Tab2)
        Me.tabMainteSheet.Controls.Add(Me.Tab3)
        Me.tabMainteSheet.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.tabMainteSheet.ItemSize = New System.Drawing.Size(240, 23)
        Me.tabMainteSheet.Location = New System.Drawing.Point(8, 7)
        Me.tabMainteSheet.Name = "tabMainteSheet"
        Me.tabMainteSheet.SelectedIndex = 0
        Me.tabMainteSheet.Size = New System.Drawing.Size(965, 583)
        Me.tabMainteSheet.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabMainteSheet.TabIndex = 0
        '
        'Tab0
        '
        Me.Tab0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab0.Controls.Add(Me.fraRepairBaseInfo)
        Me.Tab0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab0.ForeColor = System.Drawing.Color.Black
        Me.Tab0.Location = New System.Drawing.Point(4, 27)
        Me.Tab0.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab0.Name = "Tab0"
        Me.Tab0.Size = New System.Drawing.Size(957, 552)
        Me.Tab0.TabIndex = 0
        Me.Tab0.Text = "故障　基本情報 / 現象"
        '
        'fraRepairBaseInfo
        '
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairEndDateTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.pic1)
        Me.fraRepairBaseInfo.Controls.Add(Me.cmdNowDate0)
        Me.fraRepairBaseInfo.Controls.Add(Me.cmdCancel0)
        Me.fraRepairBaseInfo.Controls.Add(Me.cmdSign0)
        Me.fraRepairBaseInfo.Controls.Add(Me.cmdRepairNameSelect)
        Me.fraRepairBaseInfo.Controls.Add(Me.cmdUp0)
        Me.fraRepairBaseInfo.Controls.Add(Me.cmdDown0)
        Me.fraRepairBaseInfo.Controls.Add(Me.txtRepairName)
        Me.fraRepairBaseInfo.Controls.Add(Me.txtRepairContents)
        Me.fraRepairBaseInfo.Controls.Add(Me.vsfToEmpName0)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblSignName0)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblSignDate0)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairContentsSignField)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairContentsSignTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblLengthCount1)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblLengthCount2)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblFromEmpName0)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblFromDate0)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblUpdateName0)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblUpdate0)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairStartDate)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairPreserver)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblFindEmpName)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblHeaderInfo)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairBaseInfoTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairWpNameTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairStartDateTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblFindEmpNameTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairPreserverTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairNameInfo)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairNameTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairContentsTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairNoTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairNo)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblFindDeptNameTitle)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblFindDeptName)
        Me.fraRepairBaseInfo.Controls.Add(Me.lblRepairWpName)
        Me.fraRepairBaseInfo.Location = New System.Drawing.Point(7, 11)
        Me.fraRepairBaseInfo.Name = "fraRepairBaseInfo"
        Me.fraRepairBaseInfo.Size = New System.Drawing.Size(953, 541)
        Me.fraRepairBaseInfo.TabIndex = 88
        '
        'lblRepairEndDateTitle
        '
        Me.lblRepairEndDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairEndDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairEndDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairEndDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairEndDateTitle.Location = New System.Drawing.Point(633, 221)
        Me.lblRepairEndDateTitle.Name = "lblRepairEndDateTitle"
        Me.lblRepairEndDateTitle.Size = New System.Drawing.Size(213, 18)
        Me.lblRepairEndDateTitle.TabIndex = 182
        Me.lblRepairEndDateTitle.Text = "修理完了日時"
        Me.lblRepairEndDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pic1
        '
        Me.pic1.Controls.Add(Me.calRepairEndDate)
        Me.pic1.Controls.Add(Me.medRepairEndTime)
        Me.pic1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic1.Location = New System.Drawing.Point(631, 220)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(218, 42)
        Me.pic1.TabIndex = 0
        Me.pic1.TabStop = false
        '
        'calRepairEndDate
        '
        Me.calRepairEndDate.DateCheckStatus = 0
        Me.calRepairEndDate.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calRepairEndDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calRepairEndDate.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calRepairEndDate.IsDate = true
        Me.calRepairEndDate.Location = New System.Drawing.Point(2, 18)
        Me.calRepairEndDate.Name = "calRepairEndDate"
        Me.calRepairEndDate.Size = New System.Drawing.Size(133, 22)
        Me.calRepairEndDate.TabIndex = 1
        Me.calRepairEndDate.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calRepairEndDate.Value = "____/__/__"
        '
        'medRepairEndTime
        '
        Me.medRepairEndTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medRepairEndTime.Location = New System.Drawing.Point(136, 18)
        Me.medRepairEndTime.Mask = "##:##"
        Me.medRepairEndTime.Name = "medRepairEndTime"
        Me.medRepairEndTime.Size = New System.Drawing.Size(79, 22)
        Me.medRepairEndTime.TabIndex = 2
        Me.medRepairEndTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'cmdNowDate0
        '
        Me.cmdNowDate0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowDate0.Location = New System.Drawing.Point(861, 220)
        Me.cmdNowDate0.Name = "cmdNowDate0"
        Me.cmdNowDate0.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowDate0.TabIndex = 3
        Me.cmdNowDate0.Text = "現在日時"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"取得"
        '
        'cmdCancel0
        '
        Me.cmdCancel0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel0.Location = New System.Drawing.Point(870, 412)
        Me.cmdCancel0.Name = "cmdCancel0"
        Me.cmdCancel0.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel0.TabIndex = 10
        Me.cmdCancel0.Text = "取　消"
        '
        'cmdSign0
        '
        Me.cmdSign0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign0.Location = New System.Drawing.Point(793, 412)
        Me.cmdSign0.Name = "cmdSign0"
        Me.cmdSign0.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign0.TabIndex = 9
        Me.cmdSign0.Text = "サイン"
        '
        'cmdRepairNameSelect
        '
        Me.cmdRepairNameSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRepairNameSelect.Location = New System.Drawing.Point(793, 323)
        Me.cmdRepairNameSelect.Name = "cmdRepairNameSelect"
        Me.cmdRepairNameSelect.Size = New System.Drawing.Size(85, 40)
        Me.cmdRepairNameSelect.TabIndex = 5
        Me.cmdRepairNameSelect.Text = "現象名"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"選択"
        '
        'cmdUp0
        '
        Me.cmdUp0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp0.Location = New System.Drawing.Point(756, 392)
        Me.cmdUp0.Name = "cmdUp0"
        Me.cmdUp0.Size = New System.Drawing.Size(25, 65)
        Me.cmdUp0.TabIndex = 7
        Me.cmdUp0.Text = "▲"
        '
        'cmdDown0
        '
        Me.cmdDown0.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown0.Location = New System.Drawing.Point(756, 459)
        Me.cmdDown0.Name = "cmdDown0"
        Me.cmdDown0.Size = New System.Drawing.Size(25, 65)
        Me.cmdDown0.TabIndex = 8
        Me.cmdDown0.Text = "▼"
        '
        'txtRepairName
        '
        Me.txtRepairName.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtRepairName.ChrMaxByte = 128
        Me.txtRepairName.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtRepairName.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtRepairName.GotHighLight = false
        Me.txtRepairName.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtRepairName.Location = New System.Drawing.Point(7, 340)
        Me.txtRepairName.MultiLineEx = true
        Me.txtRepairName.Name = "txtRepairName"
        Me.txtRepairName.NgChr = "'"
        Me.txtRepairName.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtRepairName.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRepairName.SelectedText = ""
        Me.txtRepairName.Size = New System.Drawing.Size(774, 37)
        Me.txtRepairName.TabIndex = 4
        '
        'txtRepairContents
        '
        Me.txtRepairContents.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtRepairContents.ChrMaxByte = 2048
        Me.txtRepairContents.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtRepairContents.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtRepairContents.GotHighLight = false
        Me.txtRepairContents.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtRepairContents.Location = New System.Drawing.Point(7, 410)
        Me.txtRepairContents.MultiLineEx = true
        Me.txtRepairContents.Name = "txtRepairContents"
        Me.txtRepairContents.NgChr = "'"
        Me.txtRepairContents.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtRepairContents.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtRepairContents.SelectedText = ""
        Me.txtRepairContents.Size = New System.Drawing.Size(748, 113)
        Me.txtRepairContents.TabIndex = 6
        '
        'vsfToEmpName0
        '
        Me.vsfToEmpName0.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfToEmpName0.AllowEditing = false
        Me.vsfToEmpName0.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfToEmpName0.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfToEmpName0.AutoSearchDelay = 2R
        Me.vsfToEmpName0.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfToEmpName0.ColumnInfo = "1,0,0,0,0,90,Columns:0{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfToEmpName0.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfToEmpName0.ExtendLastCol = true
        Me.vsfToEmpName0.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfToEmpName0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfToEmpName0.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfToEmpName0.Location = New System.Drawing.Point(781, 78)
        Me.vsfToEmpName0.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfToEmpName0.Name = "vsfToEmpName0"
        Me.vsfToEmpName0.Rows.Count = 3
        Me.vsfToEmpName0.Rows.DefaultSize = 18
        Me.vsfToEmpName0.Rows.Fixed = 0
        Me.vsfToEmpName0.Rows.MaxSize = 16
        Me.vsfToEmpName0.Rows.MinSize = 16
        Me.vsfToEmpName0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfToEmpName0.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfToEmpName0.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfToEmpName0.Size = New System.Drawing.Size(138, 50)
        Me.vsfToEmpName0.StyleInfo = resources.GetString("vsfToEmpName0.StyleInfo")
        Me.vsfToEmpName0.TabIndex = 66
        '
        'lblSignName0
        '
        Me.lblSignName0.AutoSize = true
        Me.lblSignName0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName0.Location = New System.Drawing.Point(804, 460)
        Me.lblSignName0.Name = "lblSignName0"
        Me.lblSignName0.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName0.TabIndex = 117
        Me.lblSignName0.Text = "大川原　門左衛門"
        '
        'lblSignDate0
        '
        Me.lblSignDate0.AutoSize = true
        Me.lblSignDate0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate0.Location = New System.Drawing.Point(804, 439)
        Me.lblSignDate0.Name = "lblSignDate0"
        Me.lblSignDate0.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate0.TabIndex = 104
        Me.lblSignDate0.Text = "2007/03/09"
        '
        'lblRepairContentsSignField
        '
        Me.lblRepairContentsSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairContentsSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairContentsSignField.Location = New System.Drawing.Point(793, 432)
        Me.lblRepairContentsSignField.Name = "lblRepairContentsSignField"
        Me.lblRepairContentsSignField.Size = New System.Drawing.Size(153, 55)
        Me.lblRepairContentsSignField.TabIndex = 103
        '
        'lblRepairContentsSignTitle
        '
        Me.lblRepairContentsSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairContentsSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairContentsSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairContentsSignTitle.Location = New System.Drawing.Point(793, 393)
        Me.lblRepairContentsSignTitle.Name = "lblRepairContentsSignTitle"
        Me.lblRepairContentsSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblRepairContentsSignTitle.TabIndex = 102
        Me.lblRepairContentsSignTitle.Text = "サイン"
        Me.lblRepairContentsSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount1
        '
        Me.lblLengthCount1.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount1.Location = New System.Drawing.Point(537, 324)
        Me.lblLengthCount1.Name = "lblLengthCount1"
        Me.lblLengthCount1.Size = New System.Drawing.Size(233, 15)
        Me.lblLengthCount1.TabIndex = 97
        Me.lblLengthCount1.Text = "( 半角128文字/半角128文字 )"
        Me.lblLengthCount1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount2
        '
        Me.lblLengthCount2.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount2.Location = New System.Drawing.Point(512, 394)
        Me.lblLengthCount2.Name = "lblLengthCount2"
        Me.lblLengthCount2.Size = New System.Drawing.Size(239, 15)
        Me.lblLengthCount2.TabIndex = 96
        Me.lblLengthCount2.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFromEmpName0
        '
        Me.lblFromEmpName0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromEmpName0.Location = New System.Drawing.Point(781, 65)
        Me.lblFromEmpName0.Name = "lblFromEmpName0"
        Me.lblFromEmpName0.Size = New System.Drawing.Size(138, 12)
        Me.lblFromEmpName0.TabIndex = 95
        Me.lblFromEmpName0.Text = "更新者 名前１"
        '
        'lblFromDate0
        '
        Me.lblFromDate0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromDate0.Location = New System.Drawing.Point(782, 52)
        Me.lblFromDate0.Name = "lblFromDate0"
        Me.lblFromDate0.Size = New System.Drawing.Size(138, 12)
        Me.lblFromDate0.TabIndex = 94
        Me.lblFromDate0.Text = "2007/02/02"
        '
        'lblUpdateName0
        '
        Me.lblUpdateName0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUpdateName0.Location = New System.Drawing.Point(781, 39)
        Me.lblUpdateName0.Name = "lblUpdateName0"
        Me.lblUpdateName0.Size = New System.Drawing.Size(138, 12)
        Me.lblUpdateName0.TabIndex = 93
        Me.lblUpdateName0.Text = "更新者 名前１"
        '
        'lblUpdate0
        '
        Me.lblUpdate0.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUpdate0.Location = New System.Drawing.Point(782, 26)
        Me.lblUpdate0.Name = "lblUpdate0"
        Me.lblUpdate0.Size = New System.Drawing.Size(138, 12)
        Me.lblUpdate0.TabIndex = 92
        Me.lblUpdate0.Text = "2007/02/02"
        '
        'lblRepairStartDate
        '
        Me.lblRepairStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairStartDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairStartDate.Location = New System.Drawing.Point(406, 238)
        Me.lblRepairStartDate.Name = "lblRepairStartDate"
        Me.lblRepairStartDate.Size = New System.Drawing.Size(213, 22)
        Me.lblRepairStartDate.TabIndex = 79
        Me.lblRepairStartDate.Text = "2007/02/02 17:54"
        '
        'lblRepairPreserver
        '
        Me.lblRepairPreserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairPreserver.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairPreserver.Location = New System.Drawing.Point(732, 183)
        Me.lblRepairPreserver.Name = "lblRepairPreserver"
        Me.lblRepairPreserver.Size = New System.Drawing.Size(213, 22)
        Me.lblRepairPreserver.TabIndex = 77
        Me.lblRepairPreserver.Text = "児島　徳幸"
        '
        'lblFindEmpName
        '
        Me.lblFindEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFindEmpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFindEmpName.Location = New System.Drawing.Point(263, 183)
        Me.lblFindEmpName.Name = "lblFindEmpName"
        Me.lblFindEmpName.Size = New System.Drawing.Size(213, 22)
        Me.lblFindEmpName.TabIndex = 75
        Me.lblFindEmpName.Text = "児島　徳幸"
        '
        'lblRepairTitle
        '
        Me.lblRepairTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairTitle.Location = New System.Drawing.Point(285, 25)
        Me.lblRepairTitle.Name = "lblRepairTitle"
        Me.lblRepairTitle.Size = New System.Drawing.Size(399, 47)
        Me.lblRepairTitle.TabIndex = 67
        Me.lblRepairTitle.Text = "故障修理記録シート"
        Me.lblRepairTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHeaderInfo
        '
        Me.lblHeaderInfo.AutoSize = true
        Me.lblHeaderInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.lblHeaderInfo.Location = New System.Drawing.Point(702, 26)
        Me.lblHeaderInfo.Name = "lblHeaderInfo"
        Me.lblHeaderInfo.Size = New System.Drawing.Size(77, 60)
        Me.lblHeaderInfo.TabIndex = 68
        Me.lblHeaderInfo.Text = "更　新　日："&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"更　新　者："&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認依頼日："&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認依頼元："&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認依頼先："
        '
        'lblRepairBaseInfoTitle
        '
        Me.lblRepairBaseInfoTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblRepairBaseInfoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairBaseInfoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairBaseInfoTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairBaseInfoTitle.Location = New System.Drawing.Point(7, 135)
        Me.lblRepairBaseInfoTitle.Name = "lblRepairBaseInfoTitle"
        Me.lblRepairBaseInfoTitle.Size = New System.Drawing.Size(939, 17)
        Me.lblRepairBaseInfoTitle.TabIndex = 69
        Me.lblRepairBaseInfoTitle.Text = "基本情報"
        Me.lblRepairBaseInfoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairWpNameTitle
        '
        Me.lblRepairWpNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairWpNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairWpNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairWpNameTitle.Location = New System.Drawing.Point(7, 221)
        Me.lblRepairWpNameTitle.Name = "lblRepairWpNameTitle"
        Me.lblRepairWpNameTitle.Size = New System.Drawing.Size(369, 18)
        Me.lblRepairWpNameTitle.TabIndex = 91
        Me.lblRepairWpNameTitle.Text = "装置名"
        Me.lblRepairWpNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairStartDateTitle
        '
        Me.lblRepairStartDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairStartDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairStartDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairStartDateTitle.Location = New System.Drawing.Point(406, 221)
        Me.lblRepairStartDateTitle.Name = "lblRepairStartDateTitle"
        Me.lblRepairStartDateTitle.Size = New System.Drawing.Size(213, 18)
        Me.lblRepairStartDateTitle.TabIndex = 90
        Me.lblRepairStartDateTitle.Text = "故障発生日時"
        Me.lblRepairStartDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFindEmpNameTitle
        '
        Me.lblFindEmpNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblFindEmpNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFindEmpNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblFindEmpNameTitle.Location = New System.Drawing.Point(263, 167)
        Me.lblFindEmpNameTitle.Name = "lblFindEmpNameTitle"
        Me.lblFindEmpNameTitle.Size = New System.Drawing.Size(213, 17)
        Me.lblFindEmpNameTitle.TabIndex = 71
        Me.lblFindEmpNameTitle.Text = "発見者"
        Me.lblFindEmpNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairPreserverTitle
        '
        Me.lblRepairPreserverTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairPreserverTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairPreserverTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairPreserverTitle.Location = New System.Drawing.Point(732, 167)
        Me.lblRepairPreserverTitle.Name = "lblRepairPreserverTitle"
        Me.lblRepairPreserverTitle.Size = New System.Drawing.Size(213, 17)
        Me.lblRepairPreserverTitle.TabIndex = 73
        Me.lblRepairPreserverTitle.Text = "保全実施者"
        Me.lblRepairPreserverTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairNameInfo
        '
        Me.lblRepairNameInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblRepairNameInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairNameInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairNameInfo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairNameInfo.Location = New System.Drawing.Point(7, 290)
        Me.lblRepairNameInfo.Name = "lblRepairNameInfo"
        Me.lblRepairNameInfo.Size = New System.Drawing.Size(939, 17)
        Me.lblRepairNameInfo.TabIndex = 80
        Me.lblRepairNameInfo.Text = "故障現象(現象名・詳細)"
        Me.lblRepairNameInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairNameTitle
        '
        Me.lblRepairNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairNameTitle.Location = New System.Drawing.Point(7, 323)
        Me.lblRepairNameTitle.Name = "lblRepairNameTitle"
        Me.lblRepairNameTitle.Size = New System.Drawing.Size(774, 18)
        Me.lblRepairNameTitle.TabIndex = 81
        Me.lblRepairNameTitle.Text = "故障現象名"
        Me.lblRepairNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairContentsTitle
        '
        Me.lblRepairContentsTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairContentsTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairContentsTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairContentsTitle.Location = New System.Drawing.Point(7, 393)
        Me.lblRepairContentsTitle.Name = "lblRepairContentsTitle"
        Me.lblRepairContentsTitle.Size = New System.Drawing.Size(748, 18)
        Me.lblRepairContentsTitle.TabIndex = 82
        Me.lblRepairContentsTitle.Text = "故障現象詳細"
        Me.lblRepairContentsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairNoTitle
        '
        Me.lblRepairNoTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairNoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairNoTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairNoTitle.Location = New System.Drawing.Point(7, 167)
        Me.lblRepairNoTitle.Name = "lblRepairNoTitle"
        Me.lblRepairNoTitle.Size = New System.Drawing.Size(213, 17)
        Me.lblRepairNoTitle.TabIndex = 70
        Me.lblRepairNoTitle.Text = "発行№"
        Me.lblRepairNoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairNo
        '
        Me.lblRepairNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairNo.Location = New System.Drawing.Point(7, 183)
        Me.lblRepairNo.Name = "lblRepairNo"
        Me.lblRepairNo.Size = New System.Drawing.Size(213, 22)
        Me.lblRepairNo.TabIndex = 74
        Me.lblRepairNo.Text = "12345-67890"
        '
        'lblFindDeptNameTitle
        '
        Me.lblFindDeptNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblFindDeptNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFindDeptNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblFindDeptNameTitle.Location = New System.Drawing.Point(475, 167)
        Me.lblFindDeptNameTitle.Name = "lblFindDeptNameTitle"
        Me.lblFindDeptNameTitle.Size = New System.Drawing.Size(213, 17)
        Me.lblFindDeptNameTitle.TabIndex = 72
        Me.lblFindDeptNameTitle.Text = "発見職場"
        Me.lblFindDeptNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFindDeptName
        '
        Me.lblFindDeptName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFindDeptName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFindDeptName.Location = New System.Drawing.Point(475, 183)
        Me.lblFindDeptName.Name = "lblFindDeptName"
        Me.lblFindDeptName.Size = New System.Drawing.Size(213, 22)
        Me.lblFindDeptName.TabIndex = 76
        Me.lblFindDeptName.Text = "TFTシステム推進部(SYSTEM)"
        '
        'lblRepairWpName
        '
        Me.lblRepairWpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairWpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairWpName.Location = New System.Drawing.Point(7, 238)
        Me.lblRepairWpName.Name = "lblRepairWpName"
        Me.lblRepairWpName.Size = New System.Drawing.Size(369, 22)
        Me.lblRepairWpName.TabIndex = 78
        Me.lblRepairWpName.Text = "フォトライン＃1"
        '
        'Tab1
        '
        Me.Tab1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab1.Controls.Add(Me.fraRepairCauseInfo)
        Me.Tab1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab1.ForeColor = System.Drawing.Color.Black
        Me.Tab1.Location = New System.Drawing.Point(4, 27)
        Me.Tab1.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Size = New System.Drawing.Size(957, 552)
        Me.Tab1.TabIndex = 1
        Me.Tab1.Text = "故障　原因・対策 / 費用"
        '
        'fraRepairCauseInfo
        '
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairWorkCostTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairPartCostTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.pic2)
        Me.fraRepairCauseInfo.Controls.Add(Me.pic3)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdSign6)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdCancel6)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdSign5)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdCancel5)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdSign4)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdCancel4)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdSign3)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdCancel3)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdSign2)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdCancel2)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdSign1)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdCancel1)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdDown2)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdUp2)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdDown1)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdUp1)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdDown3)
        Me.fraRepairCauseInfo.Controls.Add(Me.cmdUp3)
        Me.fraRepairCauseInfo.Controls.Add(Me.txtCause)
        Me.fraRepairCauseInfo.Controls.Add(Me.txtAnalysisContents)
        Me.fraRepairCauseInfo.Controls.Add(Me.txtMeasure)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairCopeDivision)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairCopeDivisionTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairResultCostInfoTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignName6)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignDate6)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignName5)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignDate5)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignName4)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignDate4)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignName3)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignDate3)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignName2)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignDate2)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignName1)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblSignDate1)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairProductLeaderSignTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairProductLeaderSignField)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairPreserveLeaderSignTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairPreserverLeaderSignField)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairPreserverSignTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairPreserveEmpSignField)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblMeasureSignTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblMeasureSignField)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblCauseSignTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblCauseSignField)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblAnalysisSignTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblAnalysisSignField)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairSignTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblLengthCount5)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblLengthCount4)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblLengthCount3)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairCauseInfoTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblCauseTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblAnalysisContentsTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblRepairMeasureInfoTitle)
        Me.fraRepairCauseInfo.Controls.Add(Me.lblMeasureTitle)
        Me.fraRepairCauseInfo.Location = New System.Drawing.Point(7, 11)
        Me.fraRepairCauseInfo.Name = "fraRepairCauseInfo"
        Me.fraRepairCauseInfo.Size = New System.Drawing.Size(953, 541)
        Me.fraRepairCauseInfo.TabIndex = 89
        '
        'lblRepairWorkCostTitle
        '
        Me.lblRepairWorkCostTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairWorkCostTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairWorkCostTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblRepairWorkCostTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairWorkCostTitle.Location = New System.Drawing.Point(192, 435)
        Me.lblRepairWorkCostTitle.Name = "lblRepairWorkCostTitle"
        Me.lblRepairWorkCostTitle.Size = New System.Drawing.Size(161, 20)
        Me.lblRepairWorkCostTitle.TabIndex = 189
        Me.lblRepairWorkCostTitle.Text = "作業費用"
        Me.lblRepairWorkCostTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairPartCostTitle
        '
        Me.lblRepairPartCostTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairPartCostTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairPartCostTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblRepairPartCostTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairPartCostTitle.Location = New System.Drawing.Point(192, 482)
        Me.lblRepairPartCostTitle.Name = "lblRepairPartCostTitle"
        Me.lblRepairPartCostTitle.Size = New System.Drawing.Size(161, 20)
        Me.lblRepairPartCostTitle.TabIndex = 188
        Me.lblRepairPartCostTitle.Text = "部品費用"
        Me.lblRepairPartCostTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pic2
        '
        Me.pic2.Controls.Add(Me.optCopeDivision0)
        Me.pic2.Controls.Add(Me.optCopeDivision1)
        Me.pic2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic2.Location = New System.Drawing.Point(14, 459)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(141, 62)
        Me.pic2.TabIndex = 26
        Me.pic2.TabStop = false
        '
        'optCopeDivision0
        '
        Me.optCopeDivision0.Checked = true
        Me.optCopeDivision0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.optCopeDivision0.Location = New System.Drawing.Point(4, 2)
        Me.optCopeDivision0.Name = "optCopeDivision0"
        Me.optCopeDivision0.Size = New System.Drawing.Size(94, 28)
        Me.optCopeDivision0.TabIndex = 26
        Me.optCopeDivision0.TabStop = true
        Me.optCopeDivision0.Text = "自主保全"
        '
        'optCopeDivision1
        '
        Me.optCopeDivision1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.optCopeDivision1.Location = New System.Drawing.Point(4, 31)
        Me.optCopeDivision1.Name = "optCopeDivision1"
        Me.optCopeDivision1.Size = New System.Drawing.Size(132, 28)
        Me.optCopeDivision1.TabIndex = 27
        Me.optCopeDivision1.Text = "メーカー保全"
        '
        'pic3
        '
        Me.pic3.Controls.Add(Me.txtPartCost0)
        Me.pic3.Controls.Add(Me.txtWorkCost0)
        Me.pic3.Controls.Add(Me.lblRepairWorkCostUnit)
        Me.pic3.Controls.Add(Me.lblRepairPartCostUnit)
        Me.pic3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic3.Location = New System.Drawing.Point(188, 429)
        Me.pic3.Name = "pic3"
        Me.pic3.Size = New System.Drawing.Size(179, 101)
        Me.pic3.TabIndex = 28
        Me.pic3.TabStop = false
        '
        'txtPartCost0
        '
        Me.txtPartCost0.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Lower
        Me.txtPartCost0.ChrMaxByte = 2048
        Me.txtPartCost0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPartCost0.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtPartCost0.GotHighLight = false
        Me.txtPartCost0.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPartCost0.Location = New System.Drawing.Point(4, 72)
        Me.txtPartCost0.MultiLineEx = true
        Me.txtPartCost0.Name = "txtPartCost0"
        Me.txtPartCost0.NgChr = "'"
        Me.txtPartCost0.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPartCost0.NumFormat = "#,##0"
        Me.txtPartCost0.NumMax = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.txtPartCost0.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPartCost0.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPartCost0.SelectedText = ""
        Me.txtPartCost0.Size = New System.Drawing.Size(135, 24)
        Me.txtPartCost0.TabIndex = 29
        Me.txtPartCost0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWorkCost0
        '
        Me.txtWorkCost0.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Lower
        Me.txtWorkCost0.ChrMaxByte = 2048
        Me.txtWorkCost0.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtWorkCost0.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtWorkCost0.GotHighLight = false
        Me.txtWorkCost0.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtWorkCost0.Location = New System.Drawing.Point(4, 25)
        Me.txtWorkCost0.MultiLineEx = true
        Me.txtWorkCost0.Name = "txtWorkCost0"
        Me.txtWorkCost0.NgChr = "'"
        Me.txtWorkCost0.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkCost0.NumFormat = "#,##0"
        Me.txtWorkCost0.NumMax = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.txtWorkCost0.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWorkCost0.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkCost0.SelectedText = ""
        Me.txtWorkCost0.Size = New System.Drawing.Size(135, 24)
        Me.txtWorkCost0.TabIndex = 28
        Me.txtWorkCost0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRepairWorkCostUnit
        '
        Me.lblRepairWorkCostUnit.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairWorkCostUnit.Location = New System.Drawing.Point(139, 30)
        Me.lblRepairWorkCostUnit.Name = "lblRepairWorkCostUnit"
        Me.lblRepairWorkCostUnit.Size = New System.Drawing.Size(27, 20)
        Me.lblRepairWorkCostUnit.TabIndex = 187
        Me.lblRepairWorkCostUnit.Text = "円"
        Me.lblRepairWorkCostUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairPartCostUnit
        '
        Me.lblRepairPartCostUnit.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairPartCostUnit.Location = New System.Drawing.Point(139, 76)
        Me.lblRepairPartCostUnit.Name = "lblRepairPartCostUnit"
        Me.lblRepairPartCostUnit.Size = New System.Drawing.Size(27, 20)
        Me.lblRepairPartCostUnit.TabIndex = 186
        Me.lblRepairPartCostUnit.Text = "円"
        Me.lblRepairPartCostUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdSign6
        '
        Me.cmdSign6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign6.Location = New System.Drawing.Point(793, 454)
        Me.cmdSign6.Name = "cmdSign6"
        Me.cmdSign6.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign6.TabIndex = 34
        Me.cmdSign6.Text = "サイン"
        '
        'cmdCancel6
        '
        Me.cmdCancel6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel6.Location = New System.Drawing.Point(870, 454)
        Me.cmdCancel6.Name = "cmdCancel6"
        Me.cmdCancel6.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel6.TabIndex = 35
        Me.cmdCancel6.Text = "取　消"
        '
        'cmdSign5
        '
        Me.cmdSign5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign5.Location = New System.Drawing.Point(608, 454)
        Me.cmdSign5.Name = "cmdSign5"
        Me.cmdSign5.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign5.TabIndex = 32
        Me.cmdSign5.Text = "サイン"
        '
        'cmdCancel5
        '
        Me.cmdCancel5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel5.Location = New System.Drawing.Point(685, 454)
        Me.cmdCancel5.Name = "cmdCancel5"
        Me.cmdCancel5.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel5.TabIndex = 33
        Me.cmdCancel5.Text = "取　消"
        '
        'cmdSign4
        '
        Me.cmdSign4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign4.Location = New System.Drawing.Point(422, 454)
        Me.cmdSign4.Name = "cmdSign4"
        Me.cmdSign4.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign4.TabIndex = 30
        Me.cmdSign4.Text = "サイン"
        '
        'cmdCancel4
        '
        Me.cmdCancel4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel4.Location = New System.Drawing.Point(499, 454)
        Me.cmdCancel4.Name = "cmdCancel4"
        Me.cmdCancel4.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel4.TabIndex = 31
        Me.cmdCancel4.Text = "取　消"
        '
        'cmdSign3
        '
        Me.cmdSign3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign3.Location = New System.Drawing.Point(793, 309)
        Me.cmdSign3.Name = "cmdSign3"
        Me.cmdSign3.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign3.TabIndex = 24
        Me.cmdSign3.Text = "サイン"
        '
        'cmdCancel3
        '
        Me.cmdCancel3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel3.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel3.Location = New System.Drawing.Point(870, 309)
        Me.cmdCancel3.Name = "cmdCancel3"
        Me.cmdCancel3.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel3.TabIndex = 25
        Me.cmdCancel3.Text = "取　消"
        '
        'cmdSign2
        '
        Me.cmdSign2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign2.Location = New System.Drawing.Point(793, 165)
        Me.cmdSign2.Name = "cmdSign2"
        Me.cmdSign2.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign2.TabIndex = 19
        Me.cmdSign2.Text = "サイン"
        '
        'cmdCancel2
        '
        Me.cmdCancel2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel2.Location = New System.Drawing.Point(870, 165)
        Me.cmdCancel2.Name = "cmdCancel2"
        Me.cmdCancel2.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel2.TabIndex = 20
        Me.cmdCancel2.Text = "取　消"
        '
        'cmdSign1
        '
        Me.cmdSign1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign1.Location = New System.Drawing.Point(793, 53)
        Me.cmdSign1.Name = "cmdSign1"
        Me.cmdSign1.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign1.TabIndex = 14
        Me.cmdSign1.Text = "サイン"
        '
        'cmdCancel1
        '
        Me.cmdCancel1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel1.Location = New System.Drawing.Point(870, 53)
        Me.cmdCancel1.Name = "cmdCancel1"
        Me.cmdCancel1.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel1.TabIndex = 15
        Me.cmdCancel1.Text = "取　消"
        '
        'cmdDown2
        '
        Me.cmdDown2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown2.Location = New System.Drawing.Point(755, 197)
        Me.cmdDown2.Name = "cmdDown2"
        Me.cmdDown2.Size = New System.Drawing.Size(25, 51)
        Me.cmdDown2.TabIndex = 18
        Me.cmdDown2.Text = "▼"
        '
        'cmdUp2
        '
        Me.cmdUp2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp2.Location = New System.Drawing.Point(755, 146)
        Me.cmdUp2.Name = "cmdUp2"
        Me.cmdUp2.Size = New System.Drawing.Size(25, 51)
        Me.cmdUp2.TabIndex = 17
        Me.cmdUp2.Text = "▲"
        '
        'cmdDown1
        '
        Me.cmdDown1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown1.Location = New System.Drawing.Point(755, 85)
        Me.cmdDown1.Name = "cmdDown1"
        Me.cmdDown1.Size = New System.Drawing.Size(25, 50)
        Me.cmdDown1.TabIndex = 13
        Me.cmdDown1.Text = "▼"
        '
        'cmdUp1
        '
        Me.cmdUp1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp1.Location = New System.Drawing.Point(755, 34)
        Me.cmdUp1.Name = "cmdUp1"
        Me.cmdUp1.Size = New System.Drawing.Size(25, 51)
        Me.cmdUp1.TabIndex = 12
        Me.cmdUp1.Text = "▲"
        '
        'cmdDown3
        '
        Me.cmdDown3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown3.Location = New System.Drawing.Point(755, 341)
        Me.cmdDown3.Name = "cmdDown3"
        Me.cmdDown3.Size = New System.Drawing.Size(25, 51)
        Me.cmdDown3.TabIndex = 23
        Me.cmdDown3.Text = "▼"
        '
        'cmdUp3
        '
        Me.cmdUp3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp3.Location = New System.Drawing.Point(755, 290)
        Me.cmdUp3.Name = "cmdUp3"
        Me.cmdUp3.Size = New System.Drawing.Size(25, 51)
        Me.cmdUp3.TabIndex = 22
        Me.cmdUp3.Text = "▲"
        '
        'txtCause
        '
        Me.txtCause.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtCause.ChrMaxByte = 2048
        Me.txtCause.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtCause.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtCause.GotHighLight = false
        Me.txtCause.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCause.Location = New System.Drawing.Point(7, 164)
        Me.txtCause.MultiLineEx = true
        Me.txtCause.Name = "txtCause"
        Me.txtCause.NgChr = "'"
        Me.txtCause.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtCause.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCause.SelectedText = ""
        Me.txtCause.Size = New System.Drawing.Size(747, 83)
        Me.txtCause.TabIndex = 16
        '
        'txtAnalysisContents
        '
        Me.txtAnalysisContents.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtAnalysisContents.ChrMaxByte = 2048
        Me.txtAnalysisContents.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtAnalysisContents.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtAnalysisContents.GotHighLight = false
        Me.txtAnalysisContents.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtAnalysisContents.Location = New System.Drawing.Point(7, 52)
        Me.txtAnalysisContents.MultiLineEx = true
        Me.txtAnalysisContents.Name = "txtAnalysisContents"
        Me.txtAnalysisContents.NgChr = "'"
        Me.txtAnalysisContents.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtAnalysisContents.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAnalysisContents.SelectedText = ""
        Me.txtAnalysisContents.Size = New System.Drawing.Size(747, 83)
        Me.txtAnalysisContents.TabIndex = 11
        '
        'txtMeasure
        '
        Me.txtMeasure.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtMeasure.ChrMaxByte = 2048
        Me.txtMeasure.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtMeasure.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtMeasure.GotHighLight = false
        Me.txtMeasure.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMeasure.Location = New System.Drawing.Point(7, 308)
        Me.txtMeasure.MultiLineEx = true
        Me.txtMeasure.Name = "txtMeasure"
        Me.txtMeasure.NgChr = "'"
        Me.txtMeasure.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtMeasure.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMeasure.SelectedText = ""
        Me.txtMeasure.Size = New System.Drawing.Size(747, 83)
        Me.txtMeasure.TabIndex = 21
        '
        'lblRepairCopeDivision
        '
        Me.lblRepairCopeDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairCopeDivision.Location = New System.Drawing.Point(7, 454)
        Me.lblRepairCopeDivision.Name = "lblRepairCopeDivision"
        Me.lblRepairCopeDivision.Size = New System.Drawing.Size(153, 71)
        Me.lblRepairCopeDivision.TabIndex = 177
        '
        'lblRepairCopeDivisionTitle
        '
        Me.lblRepairCopeDivisionTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairCopeDivisionTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairCopeDivisionTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairCopeDivisionTitle.Location = New System.Drawing.Point(7, 435)
        Me.lblRepairCopeDivisionTitle.Name = "lblRepairCopeDivisionTitle"
        Me.lblRepairCopeDivisionTitle.Size = New System.Drawing.Size(153, 20)
        Me.lblRepairCopeDivisionTitle.TabIndex = 176
        Me.lblRepairCopeDivisionTitle.Text = "対応区分"
        Me.lblRepairCopeDivisionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairResultCostInfoTitle
        '
        Me.lblRepairResultCostInfoTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblRepairResultCostInfoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairResultCostInfoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairResultCostInfoTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairResultCostInfoTitle.Location = New System.Drawing.Point(7, 406)
        Me.lblRepairResultCostInfoTitle.Name = "lblRepairResultCostInfoTitle"
        Me.lblRepairResultCostInfoTitle.Size = New System.Drawing.Size(346, 17)
        Me.lblRepairResultCostInfoTitle.TabIndex = 175
        Me.lblRepairResultCostInfoTitle.Text = "費用実績"
        Me.lblRepairResultCostInfoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSignName6
        '
        Me.lblSignName6.AutoSize = true
        Me.lblSignName6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName6.Location = New System.Drawing.Point(805, 501)
        Me.lblSignName6.Name = "lblSignName6"
        Me.lblSignName6.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName6.TabIndex = 129
        Me.lblSignName6.Text = "大川原　門左衛門"
        '
        'lblSignDate6
        '
        Me.lblSignDate6.AutoSize = true
        Me.lblSignDate6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate6.Location = New System.Drawing.Point(805, 480)
        Me.lblSignDate6.Name = "lblSignDate6"
        Me.lblSignDate6.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate6.TabIndex = 128
        Me.lblSignDate6.Text = "2007/03/09"
        '
        'lblSignName5
        '
        Me.lblSignName5.AutoSize = true
        Me.lblSignName5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName5.Location = New System.Drawing.Point(621, 500)
        Me.lblSignName5.Name = "lblSignName5"
        Me.lblSignName5.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName5.TabIndex = 127
        Me.lblSignName5.Text = "大川原　門左衛門"
        '
        'lblSignDate5
        '
        Me.lblSignDate5.AutoSize = true
        Me.lblSignDate5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate5.Location = New System.Drawing.Point(621, 479)
        Me.lblSignDate5.Name = "lblSignDate5"
        Me.lblSignDate5.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate5.TabIndex = 126
        Me.lblSignDate5.Text = "2007/03/09"
        '
        'lblSignName4
        '
        Me.lblSignName4.AutoSize = true
        Me.lblSignName4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName4.Location = New System.Drawing.Point(435, 500)
        Me.lblSignName4.Name = "lblSignName4"
        Me.lblSignName4.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName4.TabIndex = 125
        Me.lblSignName4.Text = "大川原　門左衛門"
        '
        'lblSignDate4
        '
        Me.lblSignDate4.AutoSize = true
        Me.lblSignDate4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate4.Location = New System.Drawing.Point(435, 479)
        Me.lblSignDate4.Name = "lblSignDate4"
        Me.lblSignDate4.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate4.TabIndex = 124
        Me.lblSignDate4.Text = "2007/03/09"
        '
        'lblSignName3
        '
        Me.lblSignName3.AutoSize = true
        Me.lblSignName3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName3.Location = New System.Drawing.Point(805, 356)
        Me.lblSignName3.Name = "lblSignName3"
        Me.lblSignName3.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName3.TabIndex = 123
        Me.lblSignName3.Text = "大川原　門左衛門"
        '
        'lblSignDate3
        '
        Me.lblSignDate3.AutoSize = true
        Me.lblSignDate3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate3.Location = New System.Drawing.Point(805, 335)
        Me.lblSignDate3.Name = "lblSignDate3"
        Me.lblSignDate3.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate3.TabIndex = 122
        Me.lblSignDate3.Text = "2007/03/09"
        '
        'lblSignName2
        '
        Me.lblSignName2.AutoSize = true
        Me.lblSignName2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName2.Location = New System.Drawing.Point(805, 212)
        Me.lblSignName2.Name = "lblSignName2"
        Me.lblSignName2.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName2.TabIndex = 121
        Me.lblSignName2.Text = "大川原　門左衛門"
        '
        'lblSignDate2
        '
        Me.lblSignDate2.AutoSize = true
        Me.lblSignDate2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate2.Location = New System.Drawing.Point(805, 191)
        Me.lblSignDate2.Name = "lblSignDate2"
        Me.lblSignDate2.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate2.TabIndex = 120
        Me.lblSignDate2.Text = "2007/03/09"
        '
        'lblSignName1
        '
        Me.lblSignName1.AutoSize = true
        Me.lblSignName1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName1.Location = New System.Drawing.Point(805, 101)
        Me.lblSignName1.Name = "lblSignName1"
        Me.lblSignName1.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName1.TabIndex = 119
        Me.lblSignName1.Text = "大川原　門左衛門"
        '
        'lblSignDate1
        '
        Me.lblSignDate1.AutoSize = true
        Me.lblSignDate1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate1.Location = New System.Drawing.Point(805, 80)
        Me.lblSignDate1.Name = "lblSignDate1"
        Me.lblSignDate1.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate1.TabIndex = 118
        Me.lblSignDate1.Text = "2007/03/09"
        '
        'lblRepairProductLeaderSignTitle
        '
        Me.lblRepairProductLeaderSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairProductLeaderSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairProductLeaderSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairProductLeaderSignTitle.Location = New System.Drawing.Point(793, 435)
        Me.lblRepairProductLeaderSignTitle.Name = "lblRepairProductLeaderSignTitle"
        Me.lblRepairProductLeaderSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblRepairProductLeaderSignTitle.TabIndex = 116
        Me.lblRepairProductLeaderSignTitle.Text = "作業長"
        Me.lblRepairProductLeaderSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairProductLeaderSignField
        '
        Me.lblRepairProductLeaderSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairProductLeaderSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairProductLeaderSignField.Location = New System.Drawing.Point(793, 474)
        Me.lblRepairProductLeaderSignField.Name = "lblRepairProductLeaderSignField"
        Me.lblRepairProductLeaderSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblRepairProductLeaderSignField.TabIndex = 115
        '
        'lblRepairPreserveLeaderSignTitle
        '
        Me.lblRepairPreserveLeaderSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairPreserveLeaderSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairPreserveLeaderSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairPreserveLeaderSignTitle.Location = New System.Drawing.Point(608, 435)
        Me.lblRepairPreserveLeaderSignTitle.Name = "lblRepairPreserveLeaderSignTitle"
        Me.lblRepairPreserveLeaderSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblRepairPreserveLeaderSignTitle.TabIndex = 114
        Me.lblRepairPreserveLeaderSignTitle.Text = "保全リーダー"
        Me.lblRepairPreserveLeaderSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairPreserverLeaderSignField
        '
        Me.lblRepairPreserverLeaderSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairPreserverLeaderSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairPreserverLeaderSignField.Location = New System.Drawing.Point(608, 474)
        Me.lblRepairPreserverLeaderSignField.Name = "lblRepairPreserverLeaderSignField"
        Me.lblRepairPreserverLeaderSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblRepairPreserverLeaderSignField.TabIndex = 113
        '
        'lblRepairPreserverSignTitle
        '
        Me.lblRepairPreserverSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblRepairPreserverSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairPreserverSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblRepairPreserverSignTitle.Location = New System.Drawing.Point(422, 435)
        Me.lblRepairPreserverSignTitle.Name = "lblRepairPreserverSignTitle"
        Me.lblRepairPreserverSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblRepairPreserverSignTitle.TabIndex = 112
        Me.lblRepairPreserverSignTitle.Text = "保全担当"
        Me.lblRepairPreserverSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairPreserveEmpSignField
        '
        Me.lblRepairPreserveEmpSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairPreserveEmpSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairPreserveEmpSignField.Location = New System.Drawing.Point(422, 474)
        Me.lblRepairPreserveEmpSignField.Name = "lblRepairPreserveEmpSignField"
        Me.lblRepairPreserveEmpSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblRepairPreserveEmpSignField.TabIndex = 111
        '
        'lblMeasureSignTitle
        '
        Me.lblMeasureSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblMeasureSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMeasureSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblMeasureSignTitle.Location = New System.Drawing.Point(793, 290)
        Me.lblMeasureSignTitle.Name = "lblMeasureSignTitle"
        Me.lblMeasureSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblMeasureSignTitle.TabIndex = 110
        Me.lblMeasureSignTitle.Text = "サイン"
        Me.lblMeasureSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMeasureSignField
        '
        Me.lblMeasureSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMeasureSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMeasureSignField.Location = New System.Drawing.Point(793, 329)
        Me.lblMeasureSignField.Name = "lblMeasureSignField"
        Me.lblMeasureSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblMeasureSignField.TabIndex = 109
        '
        'lblCauseSignTitle
        '
        Me.lblCauseSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCauseSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCauseSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCauseSignTitle.Location = New System.Drawing.Point(793, 146)
        Me.lblCauseSignTitle.Name = "lblCauseSignTitle"
        Me.lblCauseSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblCauseSignTitle.TabIndex = 108
        Me.lblCauseSignTitle.Text = "サイン"
        Me.lblCauseSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCauseSignField
        '
        Me.lblCauseSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCauseSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCauseSignField.Location = New System.Drawing.Point(793, 185)
        Me.lblCauseSignField.Name = "lblCauseSignField"
        Me.lblCauseSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblCauseSignField.TabIndex = 107
        '
        'lblAnalysisSignTitle
        '
        Me.lblAnalysisSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblAnalysisSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAnalysisSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblAnalysisSignTitle.Location = New System.Drawing.Point(793, 34)
        Me.lblAnalysisSignTitle.Name = "lblAnalysisSignTitle"
        Me.lblAnalysisSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblAnalysisSignTitle.TabIndex = 106
        Me.lblAnalysisSignTitle.Text = "サイン"
        Me.lblAnalysisSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAnalysisSignField
        '
        Me.lblAnalysisSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAnalysisSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAnalysisSignField.Location = New System.Drawing.Point(793, 73)
        Me.lblAnalysisSignField.Name = "lblAnalysisSignField"
        Me.lblAnalysisSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblAnalysisSignField.TabIndex = 105
        '
        'lblRepairSignTitle
        '
        Me.lblRepairSignTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblRepairSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairSignTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairSignTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairSignTitle.Location = New System.Drawing.Point(422, 406)
        Me.lblRepairSignTitle.Name = "lblRepairSignTitle"
        Me.lblRepairSignTitle.Size = New System.Drawing.Size(524, 17)
        Me.lblRepairSignTitle.TabIndex = 101
        Me.lblRepairSignTitle.Text = "確　認"
        Me.lblRepairSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount5
        '
        Me.lblLengthCount5.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount5.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount5.Location = New System.Drawing.Point(511, 292)
        Me.lblLengthCount5.Name = "lblLengthCount5"
        Me.lblLengthCount5.Size = New System.Drawing.Size(239, 15)
        Me.lblLengthCount5.TabIndex = 100
        Me.lblLengthCount5.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount4
        '
        Me.lblLengthCount4.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount4.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount4.Location = New System.Drawing.Point(512, 148)
        Me.lblLengthCount4.Name = "lblLengthCount4"
        Me.lblLengthCount4.Size = New System.Drawing.Size(239, 15)
        Me.lblLengthCount4.TabIndex = 99
        Me.lblLengthCount4.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount3
        '
        Me.lblLengthCount3.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount3.Location = New System.Drawing.Point(512, 36)
        Me.lblLengthCount3.Name = "lblLengthCount3"
        Me.lblLengthCount3.Size = New System.Drawing.Size(239, 15)
        Me.lblLengthCount3.TabIndex = 98
        Me.lblLengthCount3.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblRepairCauseInfoTitle
        '
        Me.lblRepairCauseInfoTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblRepairCauseInfoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairCauseInfoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairCauseInfoTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairCauseInfoTitle.Location = New System.Drawing.Point(7, 7)
        Me.lblRepairCauseInfoTitle.Name = "lblRepairCauseInfoTitle"
        Me.lblRepairCauseInfoTitle.Size = New System.Drawing.Size(939, 17)
        Me.lblRepairCauseInfoTitle.TabIndex = 83
        Me.lblRepairCauseInfoTitle.Text = "調査・分析 / 原因 "
        Me.lblRepairCauseInfoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCauseTitle
        '
        Me.lblCauseTitle.BackColor = System.Drawing.Color.Navy
        Me.lblCauseTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCauseTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblCauseTitle.Location = New System.Drawing.Point(7, 147)
        Me.lblCauseTitle.Name = "lblCauseTitle"
        Me.lblCauseTitle.Size = New System.Drawing.Size(747, 18)
        Me.lblCauseTitle.TabIndex = 85
        Me.lblCauseTitle.Text = "原因詳細"
        Me.lblCauseTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAnalysisContentsTitle
        '
        Me.lblAnalysisContentsTitle.BackColor = System.Drawing.Color.Navy
        Me.lblAnalysisContentsTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAnalysisContentsTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblAnalysisContentsTitle.Location = New System.Drawing.Point(7, 35)
        Me.lblAnalysisContentsTitle.Name = "lblAnalysisContentsTitle"
        Me.lblAnalysisContentsTitle.Size = New System.Drawing.Size(747, 18)
        Me.lblAnalysisContentsTitle.TabIndex = 84
        Me.lblAnalysisContentsTitle.Text = "調査/分析詳細"
        Me.lblAnalysisContentsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRepairMeasureInfoTitle
        '
        Me.lblRepairMeasureInfoTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblRepairMeasureInfoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRepairMeasureInfoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblRepairMeasureInfoTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRepairMeasureInfoTitle.Location = New System.Drawing.Point(7, 262)
        Me.lblRepairMeasureInfoTitle.Name = "lblRepairMeasureInfoTitle"
        Me.lblRepairMeasureInfoTitle.Size = New System.Drawing.Size(939, 17)
        Me.lblRepairMeasureInfoTitle.TabIndex = 86
        Me.lblRepairMeasureInfoTitle.Text = "対　策"
        Me.lblRepairMeasureInfoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMeasureTitle
        '
        Me.lblMeasureTitle.BackColor = System.Drawing.Color.Navy
        Me.lblMeasureTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMeasureTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblMeasureTitle.Location = New System.Drawing.Point(7, 291)
        Me.lblMeasureTitle.Name = "lblMeasureTitle"
        Me.lblMeasureTitle.Size = New System.Drawing.Size(747, 18)
        Me.lblMeasureTitle.TabIndex = 87
        Me.lblMeasureTitle.Text = "対策詳細"
        Me.lblMeasureTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Tab2
        '
        Me.Tab2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab2.Controls.Add(Me.fraPreserveBaseInfo)
        Me.Tab2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab2.ForeColor = System.Drawing.Color.Black
        Me.Tab2.Location = New System.Drawing.Point(4, 27)
        Me.Tab2.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Size = New System.Drawing.Size(957, 552)
        Me.Tab2.TabIndex = 2
        Me.Tab2.Text = "保全　基本情報"
        '
        'fraPreserveBaseInfo
        '
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveEndDateTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.pic4)
        Me.fraPreserveBaseInfo.Controls.Add(Me.cmdDown4)
        Me.fraPreserveBaseInfo.Controls.Add(Me.cmdUp4)
        Me.fraPreserveBaseInfo.Controls.Add(Me.cmdNowDate1)
        Me.fraPreserveBaseInfo.Controls.Add(Me.txtPreserveComment)
        Me.fraPreserveBaseInfo.Controls.Add(Me.vsfToEmpName1)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblLengthCount6)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveCategory)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveCategoryTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveCommonInfoTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveWpName)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveNo)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveNoTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveCommentTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserverTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveStartDateTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveWpNameTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveBaseInfoTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveTitle)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserver)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveStartDate)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblUpdate1)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblUpdateName1)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblFromDate1)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblFromEmpName1)
        Me.fraPreserveBaseInfo.Controls.Add(Me.lblPreserveHeaderInfo)
        Me.fraPreserveBaseInfo.Location = New System.Drawing.Point(7, 11)
        Me.fraPreserveBaseInfo.Name = "fraPreserveBaseInfo"
        Me.fraPreserveBaseInfo.Size = New System.Drawing.Size(953, 541)
        Me.fraPreserveBaseInfo.TabIndex = 130
        '
        'lblPreserveEndDateTitle
        '
        Me.lblPreserveEndDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveEndDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveEndDateTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblPreserveEndDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveEndDateTitle.Location = New System.Drawing.Point(447, 221)
        Me.lblPreserveEndDateTitle.Name = "lblPreserveEndDateTitle"
        Me.lblPreserveEndDateTitle.Size = New System.Drawing.Size(213, 18)
        Me.lblPreserveEndDateTitle.TabIndex = 184
        Me.lblPreserveEndDateTitle.Text = "終了(予定)日時"
        Me.lblPreserveEndDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pic4
        '
        Me.pic4.Controls.Add(Me.calPreserveEndDate)
        Me.pic4.Controls.Add(Me.medPreserveEndTime)
        Me.pic4.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic4.Location = New System.Drawing.Point(446, 220)
        Me.pic4.Name = "pic4"
        Me.pic4.Size = New System.Drawing.Size(218, 42)
        Me.pic4.TabIndex = 36
        Me.pic4.TabStop = false
        '
        'calPreserveEndDate
        '
        Me.calPreserveEndDate.DateCheckStatus = 0
        Me.calPreserveEndDate.DayFont = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPreserveEndDate.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPreserveEndDate.GridFont = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPreserveEndDate.IsDate = true
        Me.calPreserveEndDate.Location = New System.Drawing.Point(1, 18)
        Me.calPreserveEndDate.Name = "calPreserveEndDate"
        Me.calPreserveEndDate.Size = New System.Drawing.Size(133, 22)
        Me.calPreserveEndDate.TabIndex = 36
        Me.calPreserveEndDate.TitleFont = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.calPreserveEndDate.Value = "____/__/__"
        '
        'medPreserveEndTime
        '
        Me.medPreserveEndTime.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.medPreserveEndTime.Location = New System.Drawing.Point(134, 18)
        Me.medPreserveEndTime.Mask = "##:##"
        Me.medPreserveEndTime.Name = "medPreserveEndTime"
        Me.medPreserveEndTime.Size = New System.Drawing.Size(80, 22)
        Me.medPreserveEndTime.TabIndex = 37
        Me.medPreserveEndTime.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'cmdDown4
        '
        Me.cmdDown4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown4.Location = New System.Drawing.Point(921, 389)
        Me.cmdDown4.Name = "cmdDown4"
        Me.cmdDown4.Size = New System.Drawing.Size(25, 65)
        Me.cmdDown4.TabIndex = 41
        Me.cmdDown4.Text = "▼"
        '
        'cmdUp4
        '
        Me.cmdUp4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp4.Location = New System.Drawing.Point(921, 322)
        Me.cmdUp4.Name = "cmdUp4"
        Me.cmdUp4.Size = New System.Drawing.Size(25, 65)
        Me.cmdUp4.TabIndex = 40
        Me.cmdUp4.Text = "▲"
        '
        'cmdNowDate1
        '
        Me.cmdNowDate1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNowDate1.Location = New System.Drawing.Point(666, 220)
        Me.cmdNowDate1.Name = "cmdNowDate1"
        Me.cmdNowDate1.Size = New System.Drawing.Size(85, 40)
        Me.cmdNowDate1.TabIndex = 38
        Me.cmdNowDate1.Text = "現在日時"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"取得"
        '
        'txtPreserveComment
        '
        Me.txtPreserveComment.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtPreserveComment.ChrMaxByte = 2048
        Me.txtPreserveComment.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPreserveComment.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtPreserveComment.GotHighLight = false
        Me.txtPreserveComment.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPreserveComment.Location = New System.Drawing.Point(7, 340)
        Me.txtPreserveComment.MultiLineEx = true
        Me.txtPreserveComment.Name = "txtPreserveComment"
        Me.txtPreserveComment.NgChr = "'"
        Me.txtPreserveComment.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPreserveComment.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPreserveComment.SelectedText = ""
        Me.txtPreserveComment.Size = New System.Drawing.Size(913, 113)
        Me.txtPreserveComment.TabIndex = 39
        '
        'vsfToEmpName1
        '
        Me.vsfToEmpName1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.vsfToEmpName1.AllowEditing = false
        Me.vsfToEmpName1.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.vsfToEmpName1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.vsfToEmpName1.AutoSearchDelay = 2R
        Me.vsfToEmpName1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.vsfToEmpName1.ColumnInfo = "1,0,0,0,0,90,Columns:0{Width:72;}"&Global.Microsoft.VisualBasic.ChrW(9)
        Me.vsfToEmpName1.EditOptions = CType(((((C1.Win.C1FlexGrid.EditFlags.AutoSearch Or C1.Win.C1FlexGrid.EditFlags.CycleOnDoubleClick)  _
            Or C1.Win.C1FlexGrid.EditFlags.MultiCheck)  _
            Or C1.Win.C1FlexGrid.EditFlags.DelayedCommit)  _
            Or C1.Win.C1FlexGrid.EditFlags.EditOnRequest),C1.Win.C1FlexGrid.EditFlags)
        Me.vsfToEmpName1.ExtendLastCol = true
        Me.vsfToEmpName1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.vsfToEmpName1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.vsfToEmpName1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.vsfToEmpName1.Location = New System.Drawing.Point(781, 78)
        Me.vsfToEmpName1.Margin = New System.Windows.Forms.Padding(0)
        Me.vsfToEmpName1.Name = "vsfToEmpName1"
        Me.vsfToEmpName1.Rows.Count = 3
        Me.vsfToEmpName1.Rows.DefaultSize = 18
        Me.vsfToEmpName1.Rows.Fixed = 0
        Me.vsfToEmpName1.Rows.MaxSize = 16
        Me.vsfToEmpName1.Rows.MinSize = 16
        Me.vsfToEmpName1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.vsfToEmpName1.ScrollOptions = CType((C1.Win.C1FlexGrid.ScrollFlags.ScrollByRowColumn Or C1.Win.C1FlexGrid.ScrollFlags.DelayedScroll),C1.Win.C1FlexGrid.ScrollFlags)
        Me.vsfToEmpName1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.vsfToEmpName1.Size = New System.Drawing.Size(138, 50)
        Me.vsfToEmpName1.StyleInfo = resources.GetString("vsfToEmpName1.StyleInfo")
        Me.vsfToEmpName1.TabIndex = 131
        '
        'lblLengthCount6
        '
        Me.lblLengthCount6.BackColor = System.Drawing.Color.Navy
        Me.lblLengthCount6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount6.Location = New System.Drawing.Point(676, 324)
        Me.lblLengthCount6.Name = "lblLengthCount6"
        Me.lblLengthCount6.Size = New System.Drawing.Size(239, 15)
        Me.lblLengthCount6.TabIndex = 174
        Me.lblLengthCount6.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPreserveCategory
        '
        Me.lblPreserveCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCategory.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveCategory.Location = New System.Drawing.Point(7, 238)
        Me.lblPreserveCategory.Name = "lblPreserveCategory"
        Me.lblPreserveCategory.Size = New System.Drawing.Size(213, 22)
        Me.lblPreserveCategory.TabIndex = 169
        Me.lblPreserveCategory.Text = "予防保全"
        '
        'lblPreserveCategoryTitle
        '
        Me.lblPreserveCategoryTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveCategoryTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCategoryTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveCategoryTitle.Location = New System.Drawing.Point(7, 221)
        Me.lblPreserveCategoryTitle.Name = "lblPreserveCategoryTitle"
        Me.lblPreserveCategoryTitle.Size = New System.Drawing.Size(213, 18)
        Me.lblPreserveCategoryTitle.TabIndex = 168
        Me.lblPreserveCategoryTitle.Text = "保全カテゴリ"
        Me.lblPreserveCategoryTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveCommonInfoTitle
        '
        Me.lblPreserveCommonInfoTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblPreserveCommonInfoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCommonInfoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreserveCommonInfoTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveCommonInfoTitle.Location = New System.Drawing.Point(7, 290)
        Me.lblPreserveCommonInfoTitle.Name = "lblPreserveCommonInfoTitle"
        Me.lblPreserveCommonInfoTitle.Size = New System.Drawing.Size(939, 17)
        Me.lblPreserveCommonInfoTitle.TabIndex = 167
        Me.lblPreserveCommonInfoTitle.Text = "コメント"
        Me.lblPreserveCommonInfoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveWpName
        '
        Me.lblPreserveWpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveWpName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveWpName.Location = New System.Drawing.Point(447, 183)
        Me.lblPreserveWpName.Name = "lblPreserveWpName"
        Me.lblPreserveWpName.Size = New System.Drawing.Size(349, 22)
        Me.lblPreserveWpName.TabIndex = 147
        Me.lblPreserveWpName.Text = "フォトライン＃1"
        '
        'lblPreserveNo
        '
        Me.lblPreserveNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveNo.Location = New System.Drawing.Point(7, 183)
        Me.lblPreserveNo.Name = "lblPreserveNo"
        Me.lblPreserveNo.Size = New System.Drawing.Size(213, 22)
        Me.lblPreserveNo.TabIndex = 146
        Me.lblPreserveNo.Text = "12345-67890"
        '
        'lblPreserveNoTitle
        '
        Me.lblPreserveNoTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveNoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveNoTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveNoTitle.Location = New System.Drawing.Point(7, 167)
        Me.lblPreserveNoTitle.Name = "lblPreserveNoTitle"
        Me.lblPreserveNoTitle.Size = New System.Drawing.Size(213, 17)
        Me.lblPreserveNoTitle.TabIndex = 145
        Me.lblPreserveNoTitle.Text = "発行№"
        Me.lblPreserveNoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveCommentTitle
        '
        Me.lblPreserveCommentTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveCommentTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCommentTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveCommentTitle.Location = New System.Drawing.Point(7, 323)
        Me.lblPreserveCommentTitle.Name = "lblPreserveCommentTitle"
        Me.lblPreserveCommentTitle.Size = New System.Drawing.Size(913, 18)
        Me.lblPreserveCommentTitle.TabIndex = 144
        Me.lblPreserveCommentTitle.Text = "停止コメント"
        Me.lblPreserveCommentTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserverTitle
        '
        Me.lblPreserverTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserverTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserverTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserverTitle.Location = New System.Drawing.Point(227, 167)
        Me.lblPreserverTitle.Name = "lblPreserverTitle"
        Me.lblPreserverTitle.Size = New System.Drawing.Size(213, 17)
        Me.lblPreserverTitle.TabIndex = 143
        Me.lblPreserverTitle.Text = "保全実施者"
        Me.lblPreserverTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveStartDateTitle
        '
        Me.lblPreserveStartDateTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveStartDateTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveStartDateTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveStartDateTitle.Location = New System.Drawing.Point(227, 221)
        Me.lblPreserveStartDateTitle.Name = "lblPreserveStartDateTitle"
        Me.lblPreserveStartDateTitle.Size = New System.Drawing.Size(213, 18)
        Me.lblPreserveStartDateTitle.TabIndex = 142
        Me.lblPreserveStartDateTitle.Text = "開始(予定)日時"
        Me.lblPreserveStartDateTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveWpNameTitle
        '
        Me.lblPreserveWpNameTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveWpNameTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveWpNameTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveWpNameTitle.Location = New System.Drawing.Point(447, 167)
        Me.lblPreserveWpNameTitle.Name = "lblPreserveWpNameTitle"
        Me.lblPreserveWpNameTitle.Size = New System.Drawing.Size(349, 17)
        Me.lblPreserveWpNameTitle.TabIndex = 141
        Me.lblPreserveWpNameTitle.Text = "装置名"
        Me.lblPreserveWpNameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveBaseInfoTitle
        '
        Me.lblPreserveBaseInfoTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblPreserveBaseInfoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveBaseInfoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreserveBaseInfoTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveBaseInfoTitle.Location = New System.Drawing.Point(7, 135)
        Me.lblPreserveBaseInfoTitle.Name = "lblPreserveBaseInfoTitle"
        Me.lblPreserveBaseInfoTitle.Size = New System.Drawing.Size(939, 17)
        Me.lblPreserveBaseInfoTitle.TabIndex = 140
        Me.lblPreserveBaseInfoTitle.Text = "基本情報"
        Me.lblPreserveBaseInfoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveTitle
        '
        Me.lblPreserveTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreserveTitle.Location = New System.Drawing.Point(285, 25)
        Me.lblPreserveTitle.Name = "lblPreserveTitle"
        Me.lblPreserveTitle.Size = New System.Drawing.Size(399, 47)
        Me.lblPreserveTitle.TabIndex = 138
        Me.lblPreserveTitle.Text = "計画保全記録シート"
        Me.lblPreserveTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserver
        '
        Me.lblPreserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserver.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserver.Location = New System.Drawing.Point(227, 183)
        Me.lblPreserver.Name = "lblPreserver"
        Me.lblPreserver.Size = New System.Drawing.Size(213, 22)
        Me.lblPreserver.TabIndex = 137
        Me.lblPreserver.Text = "児島　徳幸"
        '
        'lblPreserveStartDate
        '
        Me.lblPreserveStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveStartDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveStartDate.Location = New System.Drawing.Point(227, 238)
        Me.lblPreserveStartDate.Name = "lblPreserveStartDate"
        Me.lblPreserveStartDate.Size = New System.Drawing.Size(213, 22)
        Me.lblPreserveStartDate.TabIndex = 136
        Me.lblPreserveStartDate.Text = "2007/02/02 17:54"
        '
        'lblUpdate1
        '
        Me.lblUpdate1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUpdate1.Location = New System.Drawing.Point(782, 26)
        Me.lblUpdate1.Name = "lblUpdate1"
        Me.lblUpdate1.Size = New System.Drawing.Size(138, 12)
        Me.lblUpdate1.TabIndex = 135
        Me.lblUpdate1.Text = "2007/02/02"
        '
        'lblUpdateName1
        '
        Me.lblUpdateName1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblUpdateName1.Location = New System.Drawing.Point(781, 39)
        Me.lblUpdateName1.Name = "lblUpdateName1"
        Me.lblUpdateName1.Size = New System.Drawing.Size(138, 12)
        Me.lblUpdateName1.TabIndex = 134
        Me.lblUpdateName1.Text = "更新者 名前１"
        '
        'lblFromDate1
        '
        Me.lblFromDate1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromDate1.Location = New System.Drawing.Point(782, 52)
        Me.lblFromDate1.Name = "lblFromDate1"
        Me.lblFromDate1.Size = New System.Drawing.Size(138, 12)
        Me.lblFromDate1.TabIndex = 133
        Me.lblFromDate1.Text = "2007/02/02"
        '
        'lblFromEmpName1
        '
        Me.lblFromEmpName1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblFromEmpName1.Location = New System.Drawing.Point(781, 65)
        Me.lblFromEmpName1.Name = "lblFromEmpName1"
        Me.lblFromEmpName1.Size = New System.Drawing.Size(138, 12)
        Me.lblFromEmpName1.TabIndex = 132
        Me.lblFromEmpName1.Text = "更新者 名前１"
        '
        'lblPreserveHeaderInfo
        '
        Me.lblPreserveHeaderInfo.AutoSize = true
        Me.lblPreserveHeaderInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.lblPreserveHeaderInfo.Location = New System.Drawing.Point(702, 26)
        Me.lblPreserveHeaderInfo.Name = "lblPreserveHeaderInfo"
        Me.lblPreserveHeaderInfo.Size = New System.Drawing.Size(77, 60)
        Me.lblPreserveHeaderInfo.TabIndex = 139
        Me.lblPreserveHeaderInfo.Text = "更　新　日："&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"更　新　者："&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認依頼日："&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認依頼元："&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"確認依頼先："
        '
        'Tab3
        '
        Me.Tab3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Tab3.Controls.Add(Me.fraPreserveItemInfo)
        Me.Tab3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Tab3.ForeColor = System.Drawing.Color.Black
        Me.Tab3.Location = New System.Drawing.Point(4, 27)
        Me.Tab3.Margin = New System.Windows.Forms.Padding(0)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Size = New System.Drawing.Size(957, 552)
        Me.Tab3.TabIndex = 3
        Me.Tab3.Text = "保全　項目・内容・目的 / 費用"
        '
        'fraPreserveItemInfo
        '
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveWorkCostTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreservePartCostTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.pic5)
        Me.fraPreserveItemInfo.Controls.Add(Me.pic6)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdUp7)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdDown7)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdUp5)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdDown5)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdUp6)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdDown6)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdCancel7)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdSign7)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdCancel8)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdSign8)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdCancel9)
        Me.fraPreserveItemInfo.Controls.Add(Me.cmdSign9)
        Me.fraPreserveItemInfo.Controls.Add(Me.txtPreserveContents)
        Me.fraPreserveItemInfo.Controls.Add(Me.txtPreserveItem)
        Me.fraPreserveItemInfo.Controls.Add(Me.txtPreservePurpose)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveCopeDivision)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveCopeDivisionTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveResultCostInfoTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblSignDate9)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblSignName9)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblSignDate8)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblSignName8)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblSignName7)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblSignDate7)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveCategory2)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveCategoryTitle2)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblLengthCount7)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblLengthCount8)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblLengthCount9)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreservePurposeTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveItemTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveContentsTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveItemInfo)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveSignTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveEmpSignField)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserverSignTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserverLeaderSignField)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblPreserveLeaderSignTitle)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblProductLeaderSignField)
        Me.fraPreserveItemInfo.Controls.Add(Me.lblProductLeaderSignTitle)
        Me.fraPreserveItemInfo.Location = New System.Drawing.Point(7, 11)
        Me.fraPreserveItemInfo.Name = "fraPreserveItemInfo"
        Me.fraPreserveItemInfo.Size = New System.Drawing.Size(953, 541)
        Me.fraPreserveItemInfo.TabIndex = 148
        '
        'lblPreserveWorkCostTitle
        '
        Me.lblPreserveWorkCostTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveWorkCostTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveWorkCostTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblPreserveWorkCostTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveWorkCostTitle.Location = New System.Drawing.Point(192, 435)
        Me.lblPreserveWorkCostTitle.Name = "lblPreserveWorkCostTitle"
        Me.lblPreserveWorkCostTitle.Size = New System.Drawing.Size(161, 20)
        Me.lblPreserveWorkCostTitle.TabIndex = 194
        Me.lblPreserveWorkCostTitle.Text = "作業費用"
        Me.lblPreserveWorkCostTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreservePartCostTitle
        '
        Me.lblPreservePartCostTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreservePartCostTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreservePartCostTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.lblPreservePartCostTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreservePartCostTitle.Location = New System.Drawing.Point(192, 482)
        Me.lblPreservePartCostTitle.Name = "lblPreservePartCostTitle"
        Me.lblPreservePartCostTitle.Size = New System.Drawing.Size(161, 20)
        Me.lblPreservePartCostTitle.TabIndex = 193
        Me.lblPreservePartCostTitle.Text = "部品費用"
        Me.lblPreservePartCostTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pic5
        '
        Me.pic5.Controls.Add(Me.optCopeDivision2)
        Me.pic5.Controls.Add(Me.optCopeDivision3)
        Me.pic5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic5.Location = New System.Drawing.Point(15, 459)
        Me.pic5.Name = "pic5"
        Me.pic5.Size = New System.Drawing.Size(141, 62)
        Me.pic5.TabIndex = 51
        Me.pic5.TabStop = false
        '
        'optCopeDivision2
        '
        Me.optCopeDivision2.Checked = true
        Me.optCopeDivision2.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.optCopeDivision2.Location = New System.Drawing.Point(3, 2)
        Me.optCopeDivision2.Name = "optCopeDivision2"
        Me.optCopeDivision2.Size = New System.Drawing.Size(94, 28)
        Me.optCopeDivision2.TabIndex = 51
        Me.optCopeDivision2.TabStop = true
        Me.optCopeDivision2.Text = "自主保全"
        '
        'optCopeDivision3
        '
        Me.optCopeDivision3.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.optCopeDivision3.Location = New System.Drawing.Point(3, 31)
        Me.optCopeDivision3.Name = "optCopeDivision3"
        Me.optCopeDivision3.Size = New System.Drawing.Size(132, 28)
        Me.optCopeDivision3.TabIndex = 52
        Me.optCopeDivision3.Text = "メーカー保全"
        '
        'pic6
        '
        Me.pic6.Controls.Add(Me.txtPartCost1)
        Me.pic6.Controls.Add(Me.txtWorkCost1)
        Me.pic6.Controls.Add(Me.lblPreserveWorkCostUnit)
        Me.pic6.Controls.Add(Me.lblPreservePartCostUnit)
        Me.pic6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.pic6.Location = New System.Drawing.Point(185, 430)
        Me.pic6.Name = "pic6"
        Me.pic6.Size = New System.Drawing.Size(179, 101)
        Me.pic6.TabIndex = 53
        Me.pic6.TabStop = false
        '
        'txtPartCost1
        '
        Me.txtPartCost1.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Lower
        Me.txtPartCost1.ChrMaxByte = 2048
        Me.txtPartCost1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPartCost1.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtPartCost1.GotHighLight = false
        Me.txtPartCost1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPartCost1.Location = New System.Drawing.Point(7, 71)
        Me.txtPartCost1.MultiLineEx = true
        Me.txtPartCost1.Name = "txtPartCost1"
        Me.txtPartCost1.NgChr = "'"
        Me.txtPartCost1.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPartCost1.NumFormat = "#,##0"
        Me.txtPartCost1.NumMax = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.txtPartCost1.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPartCost1.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPartCost1.SelectedText = ""
        Me.txtPartCost1.Size = New System.Drawing.Size(135, 24)
        Me.txtPartCost1.TabIndex = 54
        Me.txtPartCost1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWorkCost1
        '
        Me.txtWorkCost1.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Lower
        Me.txtWorkCost1.ChrMaxByte = 2048
        Me.txtWorkCost1.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtWorkCost1.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Numeric
        Me.txtWorkCost1.GotHighLight = false
        Me.txtWorkCost1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtWorkCost1.Location = New System.Drawing.Point(7, 24)
        Me.txtWorkCost1.MultiLineEx = true
        Me.txtWorkCost1.Name = "txtWorkCost1"
        Me.txtWorkCost1.NgChr = "'"
        Me.txtWorkCost1.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtWorkCost1.NumFormat = "#,##0"
        Me.txtWorkCost1.NumMax = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.txtWorkCost1.NumMin = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtWorkCost1.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtWorkCost1.SelectedText = ""
        Me.txtWorkCost1.Size = New System.Drawing.Size(135, 24)
        Me.txtWorkCost1.TabIndex = 53
        Me.txtWorkCost1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPreserveWorkCostUnit
        '
        Me.lblPreserveWorkCostUnit.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreserveWorkCostUnit.Location = New System.Drawing.Point(142, 29)
        Me.lblPreserveWorkCostUnit.Name = "lblPreserveWorkCostUnit"
        Me.lblPreserveWorkCostUnit.Size = New System.Drawing.Size(27, 20)
        Me.lblPreserveWorkCostUnit.TabIndex = 192
        Me.lblPreserveWorkCostUnit.Text = "円"
        Me.lblPreserveWorkCostUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreservePartCostUnit
        '
        Me.lblPreservePartCostUnit.Font = New System.Drawing.Font("ＭＳ ゴシック", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreservePartCostUnit.Location = New System.Drawing.Point(142, 75)
        Me.lblPreservePartCostUnit.Name = "lblPreservePartCostUnit"
        Me.lblPreservePartCostUnit.Size = New System.Drawing.Size(27, 20)
        Me.lblPreservePartCostUnit.TabIndex = 191
        Me.lblPreservePartCostUnit.Text = "円"
        Me.lblPreservePartCostUnit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdUp7
        '
        Me.cmdUp7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp7.Location = New System.Drawing.Point(921, 290)
        Me.cmdUp7.Name = "cmdUp7"
        Me.cmdUp7.Size = New System.Drawing.Size(25, 51)
        Me.cmdUp7.TabIndex = 49
        Me.cmdUp7.Text = "▲"
        '
        'cmdDown7
        '
        Me.cmdDown7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown7.Location = New System.Drawing.Point(921, 341)
        Me.cmdDown7.Name = "cmdDown7"
        Me.cmdDown7.Size = New System.Drawing.Size(25, 51)
        Me.cmdDown7.TabIndex = 50
        Me.cmdDown7.Text = "▼"
        '
        'cmdUp5
        '
        Me.cmdUp5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp5.Location = New System.Drawing.Point(921, 62)
        Me.cmdUp5.Name = "cmdUp5"
        Me.cmdUp5.Size = New System.Drawing.Size(25, 51)
        Me.cmdUp5.TabIndex = 43
        Me.cmdUp5.Text = "▲"
        '
        'cmdDown5
        '
        Me.cmdDown5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown5.Location = New System.Drawing.Point(921, 113)
        Me.cmdDown5.Name = "cmdDown5"
        Me.cmdDown5.Size = New System.Drawing.Size(25, 50)
        Me.cmdDown5.TabIndex = 44
        Me.cmdDown5.Text = "▼"
        '
        'cmdUp6
        '
        Me.cmdUp6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUp6.Location = New System.Drawing.Point(921, 176)
        Me.cmdUp6.Name = "cmdUp6"
        Me.cmdUp6.Size = New System.Drawing.Size(25, 51)
        Me.cmdUp6.TabIndex = 46
        Me.cmdUp6.Text = "▲"
        '
        'cmdDown6
        '
        Me.cmdDown6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDown6.Location = New System.Drawing.Point(921, 227)
        Me.cmdDown6.Name = "cmdDown6"
        Me.cmdDown6.Size = New System.Drawing.Size(25, 51)
        Me.cmdDown6.TabIndex = 47
        Me.cmdDown6.Text = "▼"
        '
        'cmdCancel7
        '
        Me.cmdCancel7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel7.Location = New System.Drawing.Point(499, 454)
        Me.cmdCancel7.Name = "cmdCancel7"
        Me.cmdCancel7.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel7.TabIndex = 56
        Me.cmdCancel7.Text = "取　消"
        '
        'cmdSign7
        '
        Me.cmdSign7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign7.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign7.Location = New System.Drawing.Point(422, 454)
        Me.cmdSign7.Name = "cmdSign7"
        Me.cmdSign7.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign7.TabIndex = 55
        Me.cmdSign7.Text = "サイン"
        '
        'cmdCancel8
        '
        Me.cmdCancel8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel8.Location = New System.Drawing.Point(684, 454)
        Me.cmdCancel8.Name = "cmdCancel8"
        Me.cmdCancel8.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel8.TabIndex = 58
        Me.cmdCancel8.Text = "取　消"
        '
        'cmdSign8
        '
        Me.cmdSign8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign8.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign8.Location = New System.Drawing.Point(607, 454)
        Me.cmdSign8.Name = "cmdSign8"
        Me.cmdSign8.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign8.TabIndex = 57
        Me.cmdSign8.Text = "サイン"
        '
        'cmdCancel9
        '
        Me.cmdCancel9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdCancel9.Location = New System.Drawing.Point(870, 454)
        Me.cmdCancel9.Name = "cmdCancel9"
        Me.cmdCancel9.Size = New System.Drawing.Size(76, 20)
        Me.cmdCancel9.TabIndex = 60
        Me.cmdCancel9.Text = "取　消"
        '
        'cmdSign9
        '
        Me.cmdSign9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSign9.Font = New System.Drawing.Font("ＭＳ ゴシック", 9!)
        Me.cmdSign9.Location = New System.Drawing.Point(793, 454)
        Me.cmdSign9.Name = "cmdSign9"
        Me.cmdSign9.Size = New System.Drawing.Size(77, 20)
        Me.cmdSign9.TabIndex = 59
        Me.cmdSign9.Text = "サイン"
        '
        'txtPreserveContents
        '
        Me.txtPreserveContents.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtPreserveContents.ChrMaxByte = 2048
        Me.txtPreserveContents.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPreserveContents.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtPreserveContents.GotHighLight = false
        Me.txtPreserveContents.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPreserveContents.Location = New System.Drawing.Point(7, 194)
        Me.txtPreserveContents.MultiLineEx = true
        Me.txtPreserveContents.Name = "txtPreserveContents"
        Me.txtPreserveContents.NgChr = "'"
        Me.txtPreserveContents.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPreserveContents.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPreserveContents.SelectedText = ""
        Me.txtPreserveContents.Size = New System.Drawing.Size(913, 83)
        Me.txtPreserveContents.TabIndex = 45
        '
        'txtPreserveItem
        '
        Me.txtPreserveItem.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtPreserveItem.ChrMaxByte = 2048
        Me.txtPreserveItem.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPreserveItem.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtPreserveItem.GotHighLight = false
        Me.txtPreserveItem.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPreserveItem.Location = New System.Drawing.Point(7, 80)
        Me.txtPreserveItem.MultiLineEx = true
        Me.txtPreserveItem.Name = "txtPreserveItem"
        Me.txtPreserveItem.NgChr = "'"
        Me.txtPreserveItem.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPreserveItem.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPreserveItem.SelectedText = ""
        Me.txtPreserveItem.Size = New System.Drawing.Size(913, 83)
        Me.txtPreserveItem.TabIndex = 42
        '
        'txtPreservePurpose
        '
        Me.txtPreservePurpose.ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_None_LowerUpper
        Me.txtPreservePurpose.ChrMaxByte = 2048
        Me.txtPreservePurpose.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.txtPreservePurpose.FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Zenkaku
        Me.txtPreservePurpose.GotHighLight = false
        Me.txtPreservePurpose.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPreservePurpose.Location = New System.Drawing.Point(7, 308)
        Me.txtPreservePurpose.MultiLineEx = true
        Me.txtPreservePurpose.Name = "txtPreservePurpose"
        Me.txtPreservePurpose.NgChr = "'"
        Me.txtPreservePurpose.NumDecimal = SETextBoxEx.TextBoxEx.typDecimal.CP_0_Decimal
        Me.txtPreservePurpose.PasswordChar = ""&Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPreservePurpose.SelectedText = ""
        Me.txtPreservePurpose.Size = New System.Drawing.Size(913, 83)
        Me.txtPreservePurpose.TabIndex = 48
        '
        'lblPreserveCopeDivision
        '
        Me.lblPreserveCopeDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCopeDivision.Location = New System.Drawing.Point(7, 454)
        Me.lblPreserveCopeDivision.Name = "lblPreserveCopeDivision"
        Me.lblPreserveCopeDivision.Size = New System.Drawing.Size(153, 71)
        Me.lblPreserveCopeDivision.TabIndex = 180
        '
        'lblPreserveCopeDivisionTitle
        '
        Me.lblPreserveCopeDivisionTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveCopeDivisionTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCopeDivisionTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveCopeDivisionTitle.Location = New System.Drawing.Point(7, 435)
        Me.lblPreserveCopeDivisionTitle.Name = "lblPreserveCopeDivisionTitle"
        Me.lblPreserveCopeDivisionTitle.Size = New System.Drawing.Size(153, 20)
        Me.lblPreserveCopeDivisionTitle.TabIndex = 179
        Me.lblPreserveCopeDivisionTitle.Text = "対応区分"
        Me.lblPreserveCopeDivisionTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveResultCostInfoTitle
        '
        Me.lblPreserveResultCostInfoTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblPreserveResultCostInfoTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveResultCostInfoTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreserveResultCostInfoTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveResultCostInfoTitle.Location = New System.Drawing.Point(7, 406)
        Me.lblPreserveResultCostInfoTitle.Name = "lblPreserveResultCostInfoTitle"
        Me.lblPreserveResultCostInfoTitle.Size = New System.Drawing.Size(346, 17)
        Me.lblPreserveResultCostInfoTitle.TabIndex = 178
        Me.lblPreserveResultCostInfoTitle.Text = "費用実績"
        Me.lblPreserveResultCostInfoTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSignDate9
        '
        Me.lblSignDate9.AutoSize = true
        Me.lblSignDate9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate9.Location = New System.Drawing.Point(805, 480)
        Me.lblSignDate9.Name = "lblSignDate9"
        Me.lblSignDate9.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate9.TabIndex = 150
        Me.lblSignDate9.Text = "2007/03/09"
        '
        'lblSignName9
        '
        Me.lblSignName9.AutoSize = true
        Me.lblSignName9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName9.Location = New System.Drawing.Point(805, 501)
        Me.lblSignName9.Name = "lblSignName9"
        Me.lblSignName9.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName9.TabIndex = 149
        Me.lblSignName9.Text = "大川原　門左衛門"
        '
        'lblSignDate8
        '
        Me.lblSignDate8.AutoSize = true
        Me.lblSignDate8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate8.Location = New System.Drawing.Point(620, 479)
        Me.lblSignDate8.Name = "lblSignDate8"
        Me.lblSignDate8.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate8.TabIndex = 152
        Me.lblSignDate8.Text = "2007/03/09"
        '
        'lblSignName8
        '
        Me.lblSignName8.AutoSize = true
        Me.lblSignName8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName8.Location = New System.Drawing.Point(620, 500)
        Me.lblSignName8.Name = "lblSignName8"
        Me.lblSignName8.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName8.TabIndex = 151
        Me.lblSignName8.Text = "大川原　門左衛門"
        '
        'lblSignName7
        '
        Me.lblSignName7.AutoSize = true
        Me.lblSignName7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignName7.Location = New System.Drawing.Point(435, 500)
        Me.lblSignName7.Name = "lblSignName7"
        Me.lblSignName7.Size = New System.Drawing.Size(135, 15)
        Me.lblSignName7.TabIndex = 173
        Me.lblSignName7.Text = "大川原　門左衛門"
        '
        'lblSignDate7
        '
        Me.lblSignDate7.AutoSize = true
        Me.lblSignDate7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSignDate7.Location = New System.Drawing.Point(435, 479)
        Me.lblSignDate7.Name = "lblSignDate7"
        Me.lblSignDate7.Size = New System.Drawing.Size(87, 15)
        Me.lblSignDate7.TabIndex = 172
        Me.lblSignDate7.Text = "2007/03/09"
        '
        'lblPreserveCategory2
        '
        Me.lblPreserveCategory2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.lblPreserveCategory2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCategory2.ForeColor = System.Drawing.Color.Black
        Me.lblPreserveCategory2.Location = New System.Drawing.Point(238, 5)
        Me.lblPreserveCategory2.Name = "lblPreserveCategory2"
        Me.lblPreserveCategory2.Size = New System.Drawing.Size(237, 17)
        Me.lblPreserveCategory2.TabIndex = 171
        Me.lblPreserveCategory2.Text = "予防保全"
        '
        'lblPreserveCategoryTitle2
        '
        Me.lblPreserveCategoryTitle2.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveCategoryTitle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveCategoryTitle2.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveCategoryTitle2.Location = New System.Drawing.Point(7, 5)
        Me.lblPreserveCategoryTitle2.Name = "lblPreserveCategoryTitle2"
        Me.lblPreserveCategoryTitle2.Size = New System.Drawing.Size(231, 17)
        Me.lblPreserveCategoryTitle2.TabIndex = 170
        Me.lblPreserveCategoryTitle2.Text = "保全カテゴリ"
        Me.lblPreserveCategoryTitle2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLengthCount7
        '
        Me.lblLengthCount7.BackColor = System.Drawing.Color.DarkBlue
        Me.lblLengthCount7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount7.Location = New System.Drawing.Point(677, 64)
        Me.lblLengthCount7.Name = "lblLengthCount7"
        Me.lblLengthCount7.Size = New System.Drawing.Size(239, 15)
        Me.lblLengthCount7.TabIndex = 162
        Me.lblLengthCount7.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount8
        '
        Me.lblLengthCount8.BackColor = System.Drawing.Color.DarkBlue
        Me.lblLengthCount8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount8.Location = New System.Drawing.Point(677, 178)
        Me.lblLengthCount8.Name = "lblLengthCount8"
        Me.lblLengthCount8.Size = New System.Drawing.Size(239, 15)
        Me.lblLengthCount8.TabIndex = 161
        Me.lblLengthCount8.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLengthCount9
        '
        Me.lblLengthCount9.BackColor = System.Drawing.Color.DarkBlue
        Me.lblLengthCount9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblLengthCount9.Location = New System.Drawing.Point(676, 292)
        Me.lblLengthCount9.Name = "lblLengthCount9"
        Me.lblLengthCount9.Size = New System.Drawing.Size(239, 15)
        Me.lblLengthCount9.TabIndex = 160
        Me.lblLengthCount9.Text = "( 半角2048文字/半角2048文字 )"
        Me.lblLengthCount9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPreservePurposeTitle
        '
        Me.lblPreservePurposeTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreservePurposeTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreservePurposeTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreservePurposeTitle.Location = New System.Drawing.Point(7, 291)
        Me.lblPreservePurposeTitle.Name = "lblPreservePurposeTitle"
        Me.lblPreservePurposeTitle.Size = New System.Drawing.Size(913, 18)
        Me.lblPreservePurposeTitle.TabIndex = 166
        Me.lblPreservePurposeTitle.Text = "実施目的/理由"
        Me.lblPreservePurposeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveItemTitle
        '
        Me.lblPreserveItemTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveItemTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveItemTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveItemTitle.Location = New System.Drawing.Point(7, 63)
        Me.lblPreserveItemTitle.Name = "lblPreserveItemTitle"
        Me.lblPreserveItemTitle.Size = New System.Drawing.Size(913, 18)
        Me.lblPreserveItemTitle.TabIndex = 165
        Me.lblPreserveItemTitle.Text = "実施項目"
        Me.lblPreserveItemTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveContentsTitle
        '
        Me.lblPreserveContentsTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveContentsTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveContentsTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveContentsTitle.Location = New System.Drawing.Point(7, 177)
        Me.lblPreserveContentsTitle.Name = "lblPreserveContentsTitle"
        Me.lblPreserveContentsTitle.Size = New System.Drawing.Size(913, 18)
        Me.lblPreserveContentsTitle.TabIndex = 164
        Me.lblPreserveContentsTitle.Text = "実施内容"
        Me.lblPreserveContentsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveItemInfo
        '
        Me.lblPreserveItemInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblPreserveItemInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveItemInfo.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreserveItemInfo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveItemInfo.Location = New System.Drawing.Point(7, 35)
        Me.lblPreserveItemInfo.Name = "lblPreserveItemInfo"
        Me.lblPreserveItemInfo.Size = New System.Drawing.Size(939, 17)
        Me.lblPreserveItemInfo.TabIndex = 163
        Me.lblPreserveItemInfo.Text = "実施項目、内容、目的/理由"
        Me.lblPreserveItemInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveSignTitle
        '
        Me.lblPreserveSignTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.lblPreserveSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveSignTitle.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.lblPreserveSignTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveSignTitle.Location = New System.Drawing.Point(422, 406)
        Me.lblPreserveSignTitle.Name = "lblPreserveSignTitle"
        Me.lblPreserveSignTitle.Size = New System.Drawing.Size(524, 17)
        Me.lblPreserveSignTitle.TabIndex = 159
        Me.lblPreserveSignTitle.Text = "確　認"
        Me.lblPreserveSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserveEmpSignField
        '
        Me.lblPreserveEmpSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveEmpSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserveEmpSignField.Location = New System.Drawing.Point(422, 474)
        Me.lblPreserveEmpSignField.Name = "lblPreserveEmpSignField"
        Me.lblPreserveEmpSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblPreserveEmpSignField.TabIndex = 158
        '
        'lblPreserverSignTitle
        '
        Me.lblPreserverSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserverSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserverSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserverSignTitle.Location = New System.Drawing.Point(422, 435)
        Me.lblPreserverSignTitle.Name = "lblPreserverSignTitle"
        Me.lblPreserverSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblPreserverSignTitle.TabIndex = 157
        Me.lblPreserverSignTitle.Text = "保全担当"
        Me.lblPreserverSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPreserverLeaderSignField
        '
        Me.lblPreserverLeaderSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserverLeaderSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPreserverLeaderSignField.Location = New System.Drawing.Point(607, 474)
        Me.lblPreserverLeaderSignField.Name = "lblPreserverLeaderSignField"
        Me.lblPreserverLeaderSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblPreserverLeaderSignField.TabIndex = 156
        '
        'lblPreserveLeaderSignTitle
        '
        Me.lblPreserveLeaderSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblPreserveLeaderSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreserveLeaderSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblPreserveLeaderSignTitle.Location = New System.Drawing.Point(607, 435)
        Me.lblPreserveLeaderSignTitle.Name = "lblPreserveLeaderSignTitle"
        Me.lblPreserveLeaderSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblPreserveLeaderSignTitle.TabIndex = 155
        Me.lblPreserveLeaderSignTitle.Text = "保全リーダー"
        Me.lblPreserveLeaderSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblProductLeaderSignField
        '
        Me.lblProductLeaderSignField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductLeaderSignField.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProductLeaderSignField.Location = New System.Drawing.Point(793, 474)
        Me.lblProductLeaderSignField.Name = "lblProductLeaderSignField"
        Me.lblProductLeaderSignField.Size = New System.Drawing.Size(153, 51)
        Me.lblProductLeaderSignField.TabIndex = 154
        '
        'lblProductLeaderSignTitle
        '
        Me.lblProductLeaderSignTitle.BackColor = System.Drawing.Color.Navy
        Me.lblProductLeaderSignTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProductLeaderSignTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblProductLeaderSignTitle.Location = New System.Drawing.Point(793, 435)
        Me.lblProductLeaderSignTitle.Name = "lblProductLeaderSignTitle"
        Me.lblProductLeaderSignTitle.Size = New System.Drawing.Size(153, 19)
        Me.lblProductLeaderSignTitle.TabIndex = 153
        Me.lblProductLeaderSignTitle.Text = "作業長"
        Me.lblProductLeaderSignTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmxxCM00Z0
        '
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(985, 642)
        Me.Controls.Add(Me.cmdDispose)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdApprove)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdMail)
        Me.Controls.Add(Me.tabMainteSheet)
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmxxCM00Z0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "装置メンテナンス記録票"
        Me.tabMainteSheet.ResumeLayout(false)
        Me.Tab0.ResumeLayout(false)
        Me.fraRepairBaseInfo.ResumeLayout(false)
        Me.fraRepairBaseInfo.PerformLayout
        CType(Me.pic1,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic1.ResumeLayout(false)
        Me.pic1.PerformLayout
        CType(Me.vsfToEmpName0,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab1.ResumeLayout(false)
        Me.fraRepairCauseInfo.ResumeLayout(false)
        Me.fraRepairCauseInfo.PerformLayout
        CType(Me.pic2,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic2.ResumeLayout(false)
        CType(Me.pic3,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic3.ResumeLayout(false)
        Me.Tab2.ResumeLayout(false)
        Me.fraPreserveBaseInfo.ResumeLayout(false)
        Me.fraPreserveBaseInfo.PerformLayout
        CType(Me.pic4,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic4.ResumeLayout(false)
        Me.pic4.PerformLayout
        CType(Me.vsfToEmpName1,System.ComponentModel.ISupportInitialize).EndInit
        Me.Tab3.ResumeLayout(false)
        Me.fraPreserveItemInfo.ResumeLayout(false)
        Me.fraPreserveItemInfo.PerformLayout
        CType(Me.pic5,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic5.ResumeLayout(false)
        CType(Me.pic6,System.ComponentModel.ISupportInitialize).EndInit
        Me.pic6.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents cmdDispose As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdApprove As Button
    Friend WithEvents cmdClose As Button
    Friend WithEvents cmdMail As Button
    Friend WithEvents tabMainteSheet As TabControl
    Friend WithEvents Tab0 As TabPage
    Friend WithEvents fraRepairBaseInfo As Panel
    Friend WithEvents pic1 As PictureBox
    Friend WithEvents calRepairEndDate As SECalendarEx.CalendarEx
    Friend WithEvents medRepairEndTime As MaskedTextBox
    Friend WithEvents lblRepairEndDateTitle As Label
    Friend WithEvents cmdNowDate0 As Button
    Friend WithEvents cmdCancel0 As Button
    Friend WithEvents cmdSign0 As Button
    Friend WithEvents cmdRepairNameSelect As Button
    Friend WithEvents cmdUp0 As Button
    Friend WithEvents cmdDown0 As Button
    Friend WithEvents txtRepairName As SETextBoxEx.TextBoxEx
    Friend WithEvents txtRepairContents As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfToEmpName0 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblSignName0 As Label
    Friend WithEvents lblSignDate0 As Label
    Friend WithEvents lblRepairContentsSignField As Label
    Friend WithEvents lblRepairContentsSignTitle As Label
    Friend WithEvents lblLengthCount1 As Label
    Friend WithEvents lblLengthCount2 As Label
    Friend WithEvents lblFromEmpName0 As Label
    Friend WithEvents lblFromDate0 As Label
    Friend WithEvents lblUpdateName0 As Label
    Friend WithEvents lblUpdate0 As Label
    Friend WithEvents lblRepairStartDate As Label
    Friend WithEvents lblRepairPreserver As Label
    Friend WithEvents lblFindEmpName As Label
    Friend WithEvents lblRepairTitle As Label
    Friend WithEvents lblHeaderInfo As Label
    Friend WithEvents lblRepairBaseInfoTitle As Label
    Friend WithEvents lblRepairWpNameTitle As Label
    Friend WithEvents lblRepairStartDateTitle As Label
    Friend WithEvents lblFindEmpNameTitle As Label
    Friend WithEvents lblRepairPreserverTitle As Label
    Friend WithEvents lblRepairNameInfo As Label
    Friend WithEvents lblRepairNameTitle As Label
    Friend WithEvents lblRepairContentsTitle As Label
    Friend WithEvents lblRepairNoTitle As Label
    Friend WithEvents lblRepairNo As Label
    Friend WithEvents lblFindDeptNameTitle As Label
    Friend WithEvents lblFindDeptName As Label
    Friend WithEvents lblRepairWpName As Label
    Friend WithEvents Tab1 As TabPage
    Friend WithEvents fraRepairCauseInfo As Panel
    Friend WithEvents pic2 As PictureBox
    Friend WithEvents optCopeDivision0 As RadioButton
    Friend WithEvents optCopeDivision1 As RadioButton
    Friend WithEvents pic3 As PictureBox
    Friend WithEvents txtPartCost0 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtWorkCost0 As SETextBoxEx.TextBoxEx
    Friend WithEvents lblRepairWorkCostTitle As Label
    Friend WithEvents lblRepairPartCostTitle As Label
    Friend WithEvents lblRepairWorkCostUnit As Label
    Friend WithEvents lblRepairPartCostUnit As Label
    Friend WithEvents cmdSign6 As Button
    Friend WithEvents cmdCancel6 As Button
    Friend WithEvents cmdSign5 As Button
    Friend WithEvents cmdCancel5 As Button
    Friend WithEvents cmdSign4 As Button
    Friend WithEvents cmdCancel4 As Button
    Friend WithEvents cmdSign3 As Button
    Friend WithEvents cmdCancel3 As Button
    Friend WithEvents cmdSign2 As Button
    Friend WithEvents cmdCancel2 As Button
    Friend WithEvents cmdSign1 As Button
    Friend WithEvents cmdCancel1 As Button
    Friend WithEvents cmdDown2 As Button
    Friend WithEvents cmdUp2 As Button
    Friend WithEvents cmdDown1 As Button
    Friend WithEvents cmdUp1 As Button
    Friend WithEvents cmdDown3 As Button
    Friend WithEvents cmdUp3 As Button
    Friend WithEvents txtCause As SETextBoxEx.TextBoxEx
    Friend WithEvents txtAnalysisContents As SETextBoxEx.TextBoxEx
    Friend WithEvents txtMeasure As SETextBoxEx.TextBoxEx
    Friend WithEvents lblRepairCopeDivision As Label
    Friend WithEvents lblRepairCopeDivisionTitle As Label
    Friend WithEvents lblRepairResultCostInfoTitle As Label
    Friend WithEvents lblSignName6 As Label
    Friend WithEvents lblSignDate6 As Label
    Friend WithEvents lblSignName5 As Label
    Friend WithEvents lblSignDate5 As Label
    Friend WithEvents lblSignName4 As Label
    Friend WithEvents lblSignDate4 As Label
    Friend WithEvents lblSignName3 As Label
    Friend WithEvents lblSignDate3 As Label
    Friend WithEvents lblSignName2 As Label
    Friend WithEvents lblSignDate2 As Label
    Friend WithEvents lblSignName1 As Label
    Friend WithEvents lblSignDate1 As Label
    Friend WithEvents lblRepairProductLeaderSignTitle As Label
    Friend WithEvents lblRepairProductLeaderSignField As Label
    Friend WithEvents lblRepairPreserveLeaderSignTitle As Label
    Friend WithEvents lblRepairPreserverLeaderSignField As Label
    Friend WithEvents lblRepairPreserverSignTitle As Label
    Friend WithEvents lblRepairPreserveEmpSignField As Label
    Friend WithEvents lblMeasureSignTitle As Label
    Friend WithEvents lblMeasureSignField As Label
    Friend WithEvents lblCauseSignTitle As Label
    Friend WithEvents lblCauseSignField As Label
    Friend WithEvents lblAnalysisSignTitle As Label
    Friend WithEvents lblAnalysisSignField As Label
    Friend WithEvents lblRepairSignTitle As Label
    Friend WithEvents lblLengthCount5 As Label
    Friend WithEvents lblLengthCount4 As Label
    Friend WithEvents lblLengthCount3 As Label
    Friend WithEvents lblRepairCauseInfoTitle As Label
    Friend WithEvents lblCauseTitle As Label
    Friend WithEvents lblAnalysisContentsTitle As Label
    Friend WithEvents lblRepairMeasureInfoTitle As Label
    Friend WithEvents lblMeasureTitle As Label
    Friend WithEvents Tab2 As TabPage
    Friend WithEvents fraPreserveBaseInfo As Panel
    Friend WithEvents pic4 As PictureBox
    Friend WithEvents calPreserveEndDate As SECalendarEx.CalendarEx
    Friend WithEvents medPreserveEndTime As MaskedTextBox
    Friend WithEvents lblPreserveEndDateTitle As Label
    Friend WithEvents cmdDown4 As Button
    Friend WithEvents cmdUp4 As Button
    Friend WithEvents cmdNowDate1 As Button
    Friend WithEvents txtPreserveComment As SETextBoxEx.TextBoxEx
    Friend WithEvents vsfToEmpName1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblLengthCount6 As Label
    Friend WithEvents lblPreserveCategory As Label
    Friend WithEvents lblPreserveCategoryTitle As Label
    Friend WithEvents lblPreserveCommonInfoTitle As Label
    Friend WithEvents lblPreserveWpName As Label
    Friend WithEvents lblPreserveNo As Label
    Friend WithEvents lblPreserveNoTitle As Label
    Friend WithEvents lblPreserveCommentTitle As Label
    Friend WithEvents lblPreserverTitle As Label
    Friend WithEvents lblPreserveStartDateTitle As Label
    Friend WithEvents lblPreserveWpNameTitle As Label
    Friend WithEvents lblPreserveBaseInfoTitle As Label
    Friend WithEvents lblPreserveHeaderInfo As Label
    Friend WithEvents lblPreserveTitle As Label
    Friend WithEvents lblPreserver As Label
    Friend WithEvents lblPreserveStartDate As Label
    Friend WithEvents lblUpdate1 As Label
    Friend WithEvents lblUpdateName1 As Label
    Friend WithEvents lblFromDate1 As Label
    Friend WithEvents lblFromEmpName1 As Label
    Friend WithEvents Tab3 As TabPage
    Friend WithEvents fraPreserveItemInfo As Panel
    Friend WithEvents pic5 As PictureBox
    Friend WithEvents optCopeDivision2 As RadioButton
    Friend WithEvents optCopeDivision3 As RadioButton
    Friend WithEvents pic6 As PictureBox
    Friend WithEvents txtPartCost1 As SETextBoxEx.TextBoxEx
    Friend WithEvents txtWorkCost1 As SETextBoxEx.TextBoxEx
    Friend WithEvents lblPreserveWorkCostTitle As Label
    Friend WithEvents lblPreserveWorkCostUnit As Label
    Friend WithEvents lblPreservePartCostUnit As Label
    Friend WithEvents cmdUp7 As Button
    Friend WithEvents cmdDown7 As Button
    Friend WithEvents cmdUp5 As Button
    Friend WithEvents cmdDown5 As Button
    Friend WithEvents cmdUp6 As Button
    Friend WithEvents cmdDown6 As Button
    Friend WithEvents cmdCancel7 As Button
    Friend WithEvents cmdSign7 As Button
    Friend WithEvents cmdCancel8 As Button
    Friend WithEvents cmdSign8 As Button
    Friend WithEvents cmdCancel9 As Button
    Friend WithEvents cmdSign9 As Button
    Friend WithEvents txtPreserveContents As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPreserveItem As SETextBoxEx.TextBoxEx
    Friend WithEvents txtPreservePurpose As SETextBoxEx.TextBoxEx
    Friend WithEvents lblPreserveCopeDivision As Label
    Friend WithEvents lblPreserveCopeDivisionTitle As Label
    Friend WithEvents lblPreserveResultCostInfoTitle As Label
    Friend WithEvents lblSignDate9 As Label
    Friend WithEvents lblSignName9 As Label
    Friend WithEvents lblSignDate8 As Label
    Friend WithEvents lblSignName8 As Label
    Friend WithEvents lblSignName7 As Label
    Friend WithEvents lblSignDate7 As Label
    Friend WithEvents lblPreserveCategory2 As Label
    Friend WithEvents lblPreserveCategoryTitle2 As Label
    Friend WithEvents lblLengthCount7 As Label
    Friend WithEvents lblLengthCount8 As Label
    Friend WithEvents lblLengthCount9 As Label
    Friend WithEvents lblPreservePurposeTitle As Label
    Friend WithEvents lblPreserveItemTitle As Label
    Friend WithEvents lblPreserveContentsTitle As Label
    Friend WithEvents lblPreserveItemInfo As Label
    Friend WithEvents lblPreserveSignTitle As Label
    Friend WithEvents lblPreserveEmpSignField As Label
    Friend WithEvents lblPreserverSignTitle As Label
    Friend WithEvents lblPreserverLeaderSignField As Label
    Friend WithEvents lblPreserveLeaderSignTitle As Label
    Friend WithEvents lblProductLeaderSignField As Label
    Friend WithEvents lblProductLeaderSignTitle As Label
    Friend WithEvents lblPreservePartCostTitle As Label
End Class
