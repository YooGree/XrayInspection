﻿
namespace XrayInspection.UserControls
{
    partial class CS_AIjudgmentHistory
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxSearchCondition = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblJudgmentResult = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtLotNumber = new System.Windows.Forms.TextBox();
            this.txtProductNumber = new System.Windows.Forms.TextBox();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.lblSearchDate = new System.Windows.Forms.Label();
            this.lblProductNumber = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioNormal = new System.Windows.Forms.RadioButton();
            this.radioDefect = new System.Windows.Forms.RadioButton();
            this.gbxAIjubgmentHistory = new System.Windows.Forms.GroupBox();
            this.grdAIjubgmentHistory = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbxAIjubgmentHistory2 = new System.Windows.Forms.GroupBox();
            this.grdAIjubgmentHistory2 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxSearchCondition.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.gbxAIjubgmentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAIjubgmentHistory)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbxAIjubgmentHistory2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAIjubgmentHistory2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.gbxSearchCondition, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1074, 627);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbxSearchCondition
            // 
            this.gbxSearchCondition.Controls.Add(this.tableLayoutPanel2);
            this.gbxSearchCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSearchCondition.ForeColor = System.Drawing.Color.White;
            this.gbxSearchCondition.Location = new System.Drawing.Point(3, 43);
            this.gbxSearchCondition.Name = "gbxSearchCondition";
            this.gbxSearchCondition.Size = new System.Drawing.Size(208, 581);
            this.gbxSearchCondition.TabIndex = 0;
            this.gbxSearchCondition.TabStop = false;
            this.gbxSearchCondition.Text = "조회조건";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblJudgmentResult, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.dateFrom, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtLotNumber, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtProductNumber, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblLotNumber, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblSearchDate, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblProductNumber, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCustomerName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCustomerName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.dateTo, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel4, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(202, 561);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblJudgmentResult
            // 
            this.lblJudgmentResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJudgmentResult.Location = new System.Drawing.Point(3, 203);
            this.lblJudgmentResult.Margin = new System.Windows.Forms.Padding(3);
            this.lblJudgmentResult.Name = "lblJudgmentResult";
            this.lblJudgmentResult.Size = new System.Drawing.Size(74, 34);
            this.lblJudgmentResult.TabIndex = 26;
            this.lblJudgmentResult.Text = "판정결과";
            this.lblJudgmentResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFrom
            // 
            this.dateFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFrom.Location = new System.Drawing.Point(83, 90);
            this.dateFrom.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(116, 21);
            this.dateFrom.TabIndex = 25;
            this.dateFrom.Value = new System.DateTime(2020, 12, 1, 0, 0, 0, 0);
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLotNumber.Location = new System.Drawing.Point(83, 170);
            this.txtLotNumber.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.Size = new System.Drawing.Size(116, 21);
            this.txtLotNumber.TabIndex = 20;
            // 
            // txtProductNumber
            // 
            this.txtProductNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductNumber.Location = new System.Drawing.Point(83, 50);
            this.txtProductNumber.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtProductNumber.Name = "txtProductNumber";
            this.txtProductNumber.Size = new System.Drawing.Size(116, 21);
            this.txtProductNumber.TabIndex = 18;
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLotNumber.Location = new System.Drawing.Point(3, 163);
            this.lblLotNumber.Margin = new System.Windows.Forms.Padding(3);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(74, 34);
            this.lblLotNumber.TabIndex = 12;
            this.lblLotNumber.Text = "LOT 번호";
            this.lblLotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearchDate
            // 
            this.lblSearchDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchDate.Location = new System.Drawing.Point(3, 83);
            this.lblSearchDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblSearchDate.Name = "lblSearchDate";
            this.tableLayoutPanel2.SetRowSpan(this.lblSearchDate, 2);
            this.lblSearchDate.Size = new System.Drawing.Size(74, 74);
            this.lblSearchDate.TabIndex = 10;
            this.lblSearchDate.Text = "조회일자";
            this.lblSearchDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductNumber
            // 
            this.lblProductNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductNumber.Location = new System.Drawing.Point(3, 43);
            this.lblProductNumber.Margin = new System.Windows.Forms.Padding(3);
            this.lblProductNumber.Name = "lblProductNumber";
            this.lblProductNumber.Size = new System.Drawing.Size(74, 34);
            this.lblProductNumber.TabIndex = 8;
            this.lblProductNumber.Text = "도번";
            this.lblProductNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerName.Location = new System.Drawing.Point(3, 3);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(3);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(74, 34);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "고객명";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerName.Location = new System.Drawing.Point(83, 10);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(116, 21);
            this.txtCustomerName.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnSearch, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 521);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(202, 40);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel3.SetColumnSpan(this.btnSearch, 2);
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(196, 32);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // dateTo
            // 
            this.dateTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTo.Location = new System.Drawing.Point(83, 130);
            this.dateTo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(116, 21);
            this.dateTo.TabIndex = 24;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.radioAll);
            this.flowLayoutPanel4.Controls.Add(this.radioNormal);
            this.flowLayoutPanel4.Controls.Add(this.radioDefect);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(80, 205);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(122, 35);
            this.flowLayoutPanel4.TabIndex = 23;
            // 
            // radioAll
            // 
            this.radioAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioAll.Location = new System.Drawing.Point(12, 3);
            this.radioAll.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(56, 24);
            this.radioAll.TabIndex = 1;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "전체";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // radioNormal
            // 
            this.radioNormal.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioNormal.Location = new System.Drawing.Point(3, 33);
            this.radioNormal.Name = "radioNormal";
            this.radioNormal.Size = new System.Drawing.Size(56, 24);
            this.radioNormal.TabIndex = 3;
            this.radioNormal.TabStop = true;
            this.radioNormal.Text = "정상";
            this.radioNormal.UseVisualStyleBackColor = true;
            // 
            // radioDefect
            // 
            this.radioDefect.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioDefect.Location = new System.Drawing.Point(3, 63);
            this.radioDefect.Name = "radioDefect";
            this.radioDefect.Size = new System.Drawing.Size(56, 24);
            this.radioDefect.TabIndex = 4;
            this.radioDefect.TabStop = true;
            this.radioDefect.Text = "불량";
            this.radioDefect.UseVisualStyleBackColor = true;
            // 
            // gbxAIjubgmentHistory
            // 
            this.gbxAIjubgmentHistory.Controls.Add(this.grdAIjubgmentHistory);
            this.gbxAIjubgmentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxAIjubgmentHistory.ForeColor = System.Drawing.Color.White;
            this.gbxAIjubgmentHistory.Location = new System.Drawing.Point(0, 0);
            this.gbxAIjubgmentHistory.Name = "gbxAIjubgmentHistory";
            this.gbxAIjubgmentHistory.Size = new System.Drawing.Size(854, 358);
            this.gbxAIjubgmentHistory.TabIndex = 1;
            this.gbxAIjubgmentHistory.TabStop = false;
            this.gbxAIjubgmentHistory.Text = "판정 이력정보";
            // 
            // grdAIjubgmentHistory
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAIjubgmentHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdAIjubgmentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAIjubgmentHistory.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdAIjubgmentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAIjubgmentHistory.EnableHeadersVisualStyles = false;
            this.grdAIjubgmentHistory.Location = new System.Drawing.Point(3, 17);
            this.grdAIjubgmentHistory.Name = "grdAIjubgmentHistory";
            this.grdAIjubgmentHistory.RowTemplate.Height = 23;
            this.grdAIjubgmentHistory.Size = new System.Drawing.Size(848, 338);
            this.grdAIjubgmentHistory.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(214, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(860, 40);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DimGray;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(740, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 28);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "엑셀 내보내기";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "AI 판정이력";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(217, 43);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbxAIjubgmentHistory);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbxAIjubgmentHistory2);
            this.splitContainer2.Size = new System.Drawing.Size(854, 581);
            this.splitContainer2.SplitterDistance = 358;
            this.splitContainer2.TabIndex = 4;
            // 
            // gbxAIjubgmentHistory2
            // 
            this.gbxAIjubgmentHistory2.Controls.Add(this.grdAIjubgmentHistory2);
            this.gbxAIjubgmentHistory2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxAIjubgmentHistory2.ForeColor = System.Drawing.Color.White;
            this.gbxAIjubgmentHistory2.Location = new System.Drawing.Point(0, 0);
            this.gbxAIjubgmentHistory2.Name = "gbxAIjubgmentHistory2";
            this.gbxAIjubgmentHistory2.Size = new System.Drawing.Size(854, 219);
            this.gbxAIjubgmentHistory2.TabIndex = 2;
            this.gbxAIjubgmentHistory2.TabStop = false;
            this.gbxAIjubgmentHistory2.Text = "월별 판정 집계정보";
            // 
            // grdAIjubgmentHistory2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAIjubgmentHistory2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdAIjubgmentHistory2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAIjubgmentHistory2.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdAIjubgmentHistory2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAIjubgmentHistory2.EnableHeadersVisualStyles = false;
            this.grdAIjubgmentHistory2.Location = new System.Drawing.Point(3, 17);
            this.grdAIjubgmentHistory2.Name = "grdAIjubgmentHistory2";
            this.grdAIjubgmentHistory2.RowTemplate.Height = 23;
            this.grdAIjubgmentHistory2.Size = new System.Drawing.Size(848, 199);
            this.grdAIjubgmentHistory2.TabIndex = 0;
            // 
            // CS_AIjudgmentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CS_AIjudgmentHistory";
            this.Size = new System.Drawing.Size(1074, 627);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbxSearchCondition.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.gbxAIjubgmentHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAIjubgmentHistory)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbxAIjubgmentHistory2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAIjubgmentHistory2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxSearchCondition;
        private System.Windows.Forms.GroupBox gbxAIjubgmentHistory;
        private System.Windows.Forms.DataGridView grdAIjubgmentHistory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.Label lblSearchDate;
        private System.Windows.Forms.Label lblProductNumber;
        private System.Windows.Forms.TextBox txtLotNumber;
        private System.Windows.Forms.TextBox txtProductNumber;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioNormal;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblJudgmentResult;
        private System.Windows.Forms.RadioButton radioDefect;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbxAIjubgmentHistory2;
        private System.Windows.Forms.DataGridView grdAIjubgmentHistory2;
    }
}
