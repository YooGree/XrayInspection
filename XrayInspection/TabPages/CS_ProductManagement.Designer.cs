
namespace XrayInspection.UserControls
{
    partial class CS_ProductManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxSearchCondition = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.comboSearchType = new System.Windows.Forms.ComboBox();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductWeight = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblProductWeight = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblUsePlace = new System.Windows.Forms.Label();
            this.txtUsePlace = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboProductType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbxOriginalProduct = new System.Windows.Forms.GroupBox();
            this.grdOriginalProduct = new System.Windows.Forms.DataGridView();
            this.gbxNewProduct = new System.Windows.Forms.GroupBox();
            this.grdNewProduct = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxSearchCondition.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbxOriginalProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOriginalProduct)).BeginInit();
            this.gbxNewProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNewProduct)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 1);
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
            this.tableLayoutPanel2.Controls.Add(this.txtProductName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblProductName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboSearchType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSearchType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtProductCode, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtProductWeight, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtCustomer, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblProductCode, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblProductWeight, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblCustomer, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblProductType, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblUsePlace, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtUsePlace, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.comboProductType, 1, 4);
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(202, 561);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtProductName
            // 
            this.txtProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductName.Location = new System.Drawing.Point(83, 50);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(116, 21);
            this.txtProductName.TabIndex = 34;
            // 
            // lblProductName
            // 
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName.ForeColor = System.Drawing.Color.White;
            this.lblProductName.Location = new System.Drawing.Point(3, 43);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(3);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(74, 34);
            this.lblProductName.TabIndex = 33;
            this.lblProductName.Text = "제품명";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboSearchType
            // 
            this.comboSearchType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboSearchType.FormattingEnabled = true;
            this.comboSearchType.Location = new System.Drawing.Point(83, 10);
            this.comboSearchType.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboSearchType.Name = "comboSearchType";
            this.comboSearchType.Size = new System.Drawing.Size(116, 20);
            this.comboSearchType.TabIndex = 32;
            // 
            // lblSearchType
            // 
            this.lblSearchType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchType.ForeColor = System.Drawing.Color.Pink;
            this.lblSearchType.Location = new System.Drawing.Point(3, 3);
            this.lblSearchType.Margin = new System.Windows.Forms.Padding(3);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(74, 34);
            this.lblSearchType.TabIndex = 31;
            this.lblSearchType.Text = "조회구분";
            this.lblSearchType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductCode.Location = new System.Drawing.Point(83, 250);
            this.txtProductCode.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(116, 21);
            this.txtProductCode.TabIndex = 30;
            // 
            // txtProductWeight
            // 
            this.txtProductWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductWeight.Location = new System.Drawing.Point(83, 210);
            this.txtProductWeight.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtProductWeight.Name = "txtProductWeight";
            this.txtProductWeight.Size = new System.Drawing.Size(116, 21);
            this.txtProductWeight.TabIndex = 29;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomer.Location = new System.Drawing.Point(83, 90);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(116, 21);
            this.txtCustomer.TabIndex = 28;
            // 
            // lblProductCode
            // 
            this.lblProductCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductCode.Location = new System.Drawing.Point(3, 243);
            this.lblProductCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(74, 34);
            this.lblProductCode.TabIndex = 27;
            this.lblProductCode.Text = "도번";
            this.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductWeight
            // 
            this.lblProductWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductWeight.Location = new System.Drawing.Point(3, 203);
            this.lblProductWeight.Margin = new System.Windows.Forms.Padding(3);
            this.lblProductWeight.Name = "lblProductWeight";
            this.lblProductWeight.Size = new System.Drawing.Size(74, 34);
            this.lblProductWeight.TabIndex = 26;
            this.lblProductWeight.Text = "단중";
            this.lblProductWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomer.ForeColor = System.Drawing.Color.White;
            this.lblCustomer.Location = new System.Drawing.Point(3, 83);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(3);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(74, 34);
            this.lblCustomer.TabIndex = 24;
            this.lblCustomer.Text = "고객명";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductType
            // 
            this.lblProductType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductType.Location = new System.Drawing.Point(3, 163);
            this.lblProductType.Margin = new System.Windows.Forms.Padding(3);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(74, 34);
            this.lblProductType.TabIndex = 8;
            this.lblProductType.Text = "제품구분";
            this.lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsePlace
            // 
            this.lblUsePlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsePlace.Location = new System.Drawing.Point(3, 123);
            this.lblUsePlace.Margin = new System.Windows.Forms.Padding(3);
            this.lblUsePlace.Name = "lblUsePlace";
            this.lblUsePlace.Size = new System.Drawing.Size(74, 34);
            this.lblUsePlace.TabIndex = 0;
            this.lblUsePlace.Text = "사용처";
            this.lblUsePlace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsePlace
            // 
            this.txtUsePlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsePlace.Location = new System.Drawing.Point(83, 130);
            this.txtUsePlace.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtUsePlace.Name = "txtUsePlace";
            this.txtUsePlace.Size = new System.Drawing.Size(116, 21);
            this.txtUsePlace.TabIndex = 13;
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
            this.btnSearch.Location = new System.Drawing.Point(3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(196, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // comboProductType
            // 
            this.comboProductType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboProductType.FormattingEnabled = true;
            this.comboProductType.Location = new System.Drawing.Point(83, 170);
            this.comboProductType.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboProductType.Name = "comboProductType";
            this.comboProductType.Size = new System.Drawing.Size(116, 20);
            this.comboProductType.TabIndex = 25;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
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
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(777, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
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
            this.lblTitle.Text = "제품 등록";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(217, 43);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbxOriginalProduct);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbxNewProduct);
            this.splitContainer1.Size = new System.Drawing.Size(854, 581);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 4;
            // 
            // gbxOriginalProduct
            // 
            this.gbxOriginalProduct.Controls.Add(this.grdOriginalProduct);
            this.gbxOriginalProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxOriginalProduct.ForeColor = System.Drawing.Color.White;
            this.gbxOriginalProduct.Location = new System.Drawing.Point(0, 0);
            this.gbxOriginalProduct.Name = "gbxOriginalProduct";
            this.gbxOriginalProduct.Size = new System.Drawing.Size(854, 284);
            this.gbxOriginalProduct.TabIndex = 31;
            this.gbxOriginalProduct.TabStop = false;
            this.gbxOriginalProduct.Text = "기존 제품정보";
            // 
            // grdOriginalProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOriginalProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOriginalProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOriginalProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdOriginalProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOriginalProduct.EnableHeadersVisualStyles = false;
            this.grdOriginalProduct.Location = new System.Drawing.Point(3, 17);
            this.grdOriginalProduct.Name = "grdOriginalProduct";
            this.grdOriginalProduct.RowTemplate.Height = 23;
            this.grdOriginalProduct.Size = new System.Drawing.Size(848, 264);
            this.grdOriginalProduct.TabIndex = 0;
            // 
            // gbxNewProduct
            // 
            this.gbxNewProduct.Controls.Add(this.grdNewProduct);
            this.gbxNewProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxNewProduct.ForeColor = System.Drawing.Color.White;
            this.gbxNewProduct.Location = new System.Drawing.Point(0, 0);
            this.gbxNewProduct.Name = "gbxNewProduct";
            this.gbxNewProduct.Size = new System.Drawing.Size(854, 293);
            this.gbxNewProduct.TabIndex = 1;
            this.gbxNewProduct.TabStop = false;
            this.gbxNewProduct.Text = "신규 제품정보";
            // 
            // grdNewProduct
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdNewProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdNewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdNewProduct.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdNewProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNewProduct.EnableHeadersVisualStyles = false;
            this.grdNewProduct.Location = new System.Drawing.Point(3, 17);
            this.grdNewProduct.Name = "grdNewProduct";
            this.grdNewProduct.RowTemplate.Height = 23;
            this.grdNewProduct.Size = new System.Drawing.Size(848, 273);
            this.grdNewProduct.TabIndex = 0;
            // 
            // CS_ProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CS_ProductManagement";
            this.Size = new System.Drawing.Size(1074, 627);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbxSearchCondition.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbxOriginalProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOriginalProduct)).EndInit();
            this.gbxNewProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNewProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxSearchCondition;
        private System.Windows.Forms.GroupBox gbxNewProduct;
        private System.Windows.Forms.DataGridView grdNewProduct;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblUsePlace;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.TextBox txtUsePlace;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox comboProductType;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblProductWeight;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtProductWeight;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbxOriginalProduct;
        private System.Windows.Forms.DataGridView grdOriginalProduct;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.ComboBox comboSearchType;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
    }
}
