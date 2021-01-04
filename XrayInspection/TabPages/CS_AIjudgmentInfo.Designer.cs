
namespace XrayInspection.UserControls
{
    partial class CS_AIjudgmentInfo
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxProductInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.txtLotNumber = new System.Windows.Forms.TextBox();
            this.txtProgressNumber = new System.Windows.Forms.TextBox();
            this.txtProductNumber = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtUse = new System.Windows.Forms.TextBox();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.lblProgressNumber = new System.Windows.Forms.Label();
            this.lblProductNumber = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblUse = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnJobClose = new System.Windows.Forms.Button();
            this.btnJobStart = new System.Windows.Forms.Button();
            this.gbxFrameInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.grdFrameInfo = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioNormal = new System.Windows.Forms.RadioButton();
            this.radioDefect = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxProductInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbxFrameInfo.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFrameInfo)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.gbxProductInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbxFrameInfo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1074, 627);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbxProductInfo
            // 
            this.gbxProductInfo.Controls.Add(this.tableLayoutPanel2);
            this.gbxProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxProductInfo.Location = new System.Drawing.Point(3, 43);
            this.gbxProductInfo.Name = "gbxProductInfo";
            this.gbxProductInfo.Size = new System.Drawing.Size(208, 581);
            this.gbxProductInfo.TabIndex = 0;
            this.gbxProductInfo.TabStop = false;
            this.gbxProductInfo.Text = "제품정보";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtLotNumber, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtProgressNumber, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtProductNumber, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtProductName, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtUse, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblLotNumber, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblProgressNumber, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblProductNumber, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblProductName, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblUse, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCustomerName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCustomerName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(202, 561);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // button2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.button2, 2);
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Location = new System.Drawing.Point(3, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 32);
            this.button2.TabIndex = 21;
            this.button2.Text = "작업 스케줄 조회";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLotNumber.Location = new System.Drawing.Point(83, 250);
            this.txtLotNumber.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.Size = new System.Drawing.Size(116, 21);
            this.txtLotNumber.TabIndex = 20;
            // 
            // txtProgressNumber
            // 
            this.txtProgressNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgressNumber.Location = new System.Drawing.Point(83, 210);
            this.txtProgressNumber.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtProgressNumber.Name = "txtProgressNumber";
            this.txtProgressNumber.Size = new System.Drawing.Size(116, 21);
            this.txtProgressNumber.TabIndex = 19;
            // 
            // txtProductNumber
            // 
            this.txtProductNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductNumber.Location = new System.Drawing.Point(83, 170);
            this.txtProductNumber.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtProductNumber.Name = "txtProductNumber";
            this.txtProductNumber.Size = new System.Drawing.Size(116, 21);
            this.txtProductNumber.TabIndex = 18;
            // 
            // txtProductName
            // 
            this.txtProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductName.Location = new System.Drawing.Point(83, 130);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(116, 21);
            this.txtProductName.TabIndex = 17;
            // 
            // txtUse
            // 
            this.txtUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUse.Location = new System.Drawing.Point(83, 90);
            this.txtUse.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtUse.Name = "txtUse";
            this.txtUse.Size = new System.Drawing.Size(116, 21);
            this.txtUse.TabIndex = 16;
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLotNumber.Location = new System.Drawing.Point(3, 243);
            this.lblLotNumber.Margin = new System.Windows.Forms.Padding(3);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(74, 34);
            this.lblLotNumber.TabIndex = 12;
            this.lblLotNumber.Text = "LOT 번호";
            this.lblLotNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgressNumber
            // 
            this.lblProgressNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgressNumber.Location = new System.Drawing.Point(3, 203);
            this.lblProgressNumber.Margin = new System.Windows.Forms.Padding(3);
            this.lblProgressNumber.Name = "lblProgressNumber";
            this.lblProgressNumber.Size = new System.Drawing.Size(74, 34);
            this.lblProgressNumber.TabIndex = 10;
            this.lblProgressNumber.Text = "진행순번";
            this.lblProgressNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductNumber
            // 
            this.lblProductNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductNumber.Location = new System.Drawing.Point(3, 163);
            this.lblProductNumber.Margin = new System.Windows.Forms.Padding(3);
            this.lblProductNumber.Name = "lblProductNumber";
            this.lblProductNumber.Size = new System.Drawing.Size(74, 34);
            this.lblProductNumber.TabIndex = 8;
            this.lblProductNumber.Text = "도번";
            this.lblProductNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName
            // 
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.Location = new System.Drawing.Point(3, 123);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(3);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(74, 34);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "품명";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUse
            // 
            this.lblUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUse.Location = new System.Drawing.Point(3, 83);
            this.lblUse.Margin = new System.Windows.Forms.Padding(3);
            this.lblUse.Name = "lblUse";
            this.lblUse.Size = new System.Drawing.Size(74, 34);
            this.lblUse.TabIndex = 4;
            this.lblUse.Text = "사용처";
            this.lblUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerName.Location = new System.Drawing.Point(3, 43);
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
            this.txtCustomerName.Location = new System.Drawing.Point(83, 50);
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
            this.tableLayoutPanel3.Controls.Add(this.btnJobClose, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnJobStart, 0, 0);
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
            // btnJobClose
            // 
            this.btnJobClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnJobClose.Location = new System.Drawing.Point(104, 5);
            this.btnJobClose.Name = "btnJobClose";
            this.btnJobClose.Size = new System.Drawing.Size(95, 32);
            this.btnJobClose.TabIndex = 4;
            this.btnJobClose.Text = "작업종료";
            this.btnJobClose.UseVisualStyleBackColor = true;
            // 
            // btnJobStart
            // 
            this.btnJobStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnJobStart.Location = new System.Drawing.Point(3, 5);
            this.btnJobStart.Name = "btnJobStart";
            this.btnJobStart.Size = new System.Drawing.Size(95, 32);
            this.btnJobStart.TabIndex = 3;
            this.btnJobStart.Text = "작업시작";
            this.btnJobStart.UseVisualStyleBackColor = true;
            // 
            // gbxFrameInfo
            // 
            this.gbxFrameInfo.Controls.Add(this.tableLayoutPanel4);
            this.gbxFrameInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxFrameInfo.Location = new System.Drawing.Point(217, 43);
            this.gbxFrameInfo.Name = "gbxFrameInfo";
            this.gbxFrameInfo.Size = new System.Drawing.Size(854, 581);
            this.gbxFrameInfo.TabIndex = 1;
            this.gbxFrameInfo.TabStop = false;
            this.gbxFrameInfo.Text = "Frame 정보";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.grdFrameInfo, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(848, 561);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // grdFrameInfo
            // 
            this.grdFrameInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFrameInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFrameInfo.Location = new System.Drawing.Point(0, 0);
            this.grdFrameInfo.Margin = new System.Windows.Forms.Padding(0);
            this.grdFrameInfo.Name = "grdFrameInfo";
            this.grdFrameInfo.RowTemplate.Height = 23;
            this.grdFrameInfo.Size = new System.Drawing.Size(848, 531);
            this.grdFrameInfo.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 531);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(848, 30);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.radioAll);
            this.flowLayoutPanel3.Controls.Add(this.radioNormal);
            this.flowLayoutPanel3.Controls.Add(this.radioDefect);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(339, 30);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // radioAll
            // 
            this.radioAll.Location = new System.Drawing.Point(3, 3);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(56, 24);
            this.radioAll.TabIndex = 1;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "전체";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // radioNormal
            // 
            this.radioNormal.Location = new System.Drawing.Point(65, 3);
            this.radioNormal.Name = "radioNormal";
            this.radioNormal.Size = new System.Drawing.Size(56, 24);
            this.radioNormal.TabIndex = 3;
            this.radioNormal.TabStop = true;
            this.radioNormal.Text = "정상";
            this.radioNormal.UseVisualStyleBackColor = true;
            // 
            // radioDefect
            // 
            this.radioDefect.Location = new System.Drawing.Point(127, 3);
            this.radioDefect.Name = "radioDefect";
            this.radioDefect.Size = new System.Drawing.Size(56, 24);
            this.radioDefect.TabIndex = 2;
            this.radioDefect.TabStop = true;
            this.radioDefect.Text = "불량";
            this.radioDefect.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(339, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(509, 30);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(461, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(370, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "총 Frame 수 :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(319, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(213, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "불량 Frame 수 :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteRow);
            this.flowLayoutPanel1.Controls.Add(this.btnAddRow);
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(214, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(860, 40);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(777, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(691, 3);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(80, 28);
            this.btnDeleteRow.TabIndex = 4;
            this.btnDeleteRow.Text = "행 삭제";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(605, 3);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(80, 28);
            this.btnAddRow.TabIndex = 5;
            this.btnAddRow.Text = "행 추가";
            this.btnAddRow.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(482, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 28);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "엑셀 내보내기";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "AI 판정정보";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CS_AIjubgmentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CS_AIjubgmentInfo";
            this.Size = new System.Drawing.Size(1074, 627);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbxProductInfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gbxFrameInfo.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFrameInfo)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxProductInfo;
        private System.Windows.Forms.GroupBox gbxFrameInfo;
        private System.Windows.Forms.DataGridView grdFrameInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.Label lblProgressNumber;
        private System.Windows.Forms.Label lblProductNumber;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblUse;
        private System.Windows.Forms.TextBox txtLotNumber;
        private System.Windows.Forms.TextBox txtProgressNumber;
        private System.Windows.Forms.TextBox txtProductNumber;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtUse;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnJobClose;
        private System.Windows.Forms.Button btnJobStart;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioNormal;
        private System.Windows.Forms.RadioButton radioDefect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
