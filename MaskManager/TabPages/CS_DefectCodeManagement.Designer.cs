
namespace MaskManager.UserControls
{
    partial class CS_DefectCodeManagement
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
            this.gbxSearchCondition = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboUsableType = new System.Windows.Forms.ComboBox();
            this.lblUsableType = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserNumber = new System.Windows.Forms.Label();
            this.txtUserNumber = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbxDefectCode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbxTopCategory = new System.Windows.Forms.GroupBox();
            this.grdTopCategory = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTopSave = new System.Windows.Forms.Button();
            this.btnTopAdd = new System.Windows.Forms.Button();
            this.gbxMiddleCategory = new System.Windows.Forms.GroupBox();
            this.grdMiddleCategory = new System.Windows.Forms.DataGridView();
            this.gbxDetailCategory = new System.Windows.Forms.GroupBox();
            this.grdDetailCategory = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMiddleSave = new System.Windows.Forms.Button();
            this.btnMiddleAdd = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDetailSave = new System.Windows.Forms.Button();
            this.btnDetailAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTopCode = new System.Windows.Forms.Label();
            this.lblTopName = new System.Windows.Forms.Label();
            this.lblTopUseable = new System.Windows.Forms.Label();
            this.txtTopCode = new System.Windows.Forms.TextBox();
            this.comboTopUsable = new System.Windows.Forms.ComboBox();
            this.txtTopName = new System.Windows.Forms.TextBox();
            this.lblMiddleCode = new System.Windows.Forms.Label();
            this.lblDetailCode = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.lblMiddleUseable = new System.Windows.Forms.Label();
            this.lblDetailUseable = new System.Windows.Forms.Label();
            this.txtMiddleCode = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.comboMiddleUsable = new System.Windows.Forms.ComboBox();
            this.txtDetailCode = new System.Windows.Forms.TextBox();
            this.txtDetailName = new System.Windows.Forms.TextBox();
            this.comboDetailUsable = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxSearchCondition.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbxDefectCode.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbxTopCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTopCategory)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbxMiddleCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMiddleCategory)).BeginInit();
            this.gbxDetailCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailCategory)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.gbxSearchCondition, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbxDefectCode, 1, 1);
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
            this.tableLayoutPanel2.Controls.Add(this.comboUsableType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblUsableType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtUserName, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblUserName, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblUserNumber, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtUserNumber, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(202, 561);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // comboUsableType
            // 
            this.comboUsableType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboUsableType.FormattingEnabled = true;
            this.comboUsableType.Location = new System.Drawing.Point(83, 10);
            this.comboUsableType.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboUsableType.Name = "comboUsableType";
            this.comboUsableType.Size = new System.Drawing.Size(116, 20);
            this.comboUsableType.TabIndex = 25;
            // 
            // lblUsableType
            // 
            this.lblUsableType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsableType.ForeColor = System.Drawing.Color.Red;
            this.lblUsableType.Location = new System.Drawing.Point(3, 3);
            this.lblUsableType.Margin = new System.Windows.Forms.Padding(3);
            this.lblUsableType.Name = "lblUsableType";
            this.lblUsableType.Size = new System.Drawing.Size(74, 34);
            this.lblUsableType.TabIndex = 24;
            this.lblUsableType.Text = "사용여부";
            this.lblUsableType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserName
            // 
            this.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserName.Location = new System.Drawing.Point(83, 90);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(116, 21);
            this.txtUserName.TabIndex = 18;
            // 
            // lblUserName
            // 
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserName.Location = new System.Drawing.Point(3, 83);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(3);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(74, 34);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "사용자명";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserNumber
            // 
            this.lblUserNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserNumber.Location = new System.Drawing.Point(3, 43);
            this.lblUserNumber.Margin = new System.Windows.Forms.Padding(3);
            this.lblUserNumber.Name = "lblUserNumber";
            this.lblUserNumber.Size = new System.Drawing.Size(74, 34);
            this.lblUserNumber.TabIndex = 0;
            this.lblUserNumber.Text = "사번";
            this.lblUserNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserNumber
            // 
            this.txtUserNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserNumber.Location = new System.Drawing.Point(83, 50);
            this.txtUserNumber.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Size = new System.Drawing.Size(116, 21);
            this.txtUserNumber.TabIndex = 13;
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
            this.tableLayoutPanel3.SetColumnSpan(this.btnSearch, 2);
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.Location = new System.Drawing.Point(3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(196, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
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
            this.lblTitle.Text = "불량코드 등록";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxDefectCode
            // 
            this.gbxDefectCode.Controls.Add(this.tableLayoutPanel4);
            this.gbxDefectCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDefectCode.Location = new System.Drawing.Point(217, 43);
            this.gbxDefectCode.Name = "gbxDefectCode";
            this.gbxDefectCode.Size = new System.Drawing.Size(854, 581);
            this.gbxDefectCode.TabIndex = 4;
            this.gbxDefectCode.TabStop = false;
            this.gbxDefectCode.Text = "불량코드";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox3, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.gbxTopCategory, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.gbxMiddleCategory, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.gbxDetailCategory, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 4, 2);
            this.tableLayoutPanel4.Controls.Add(this.groupBox1, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(848, 561);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(574, 367);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 150);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // gbxTopCategory
            // 
            this.gbxTopCategory.Controls.Add(this.grdTopCategory);
            this.gbxTopCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxTopCategory.Location = new System.Drawing.Point(3, 3);
            this.gbxTopCategory.Name = "gbxTopCategory";
            this.gbxTopCategory.Size = new System.Drawing.Size(269, 358);
            this.gbxTopCategory.TabIndex = 1;
            this.gbxTopCategory.TabStop = false;
            this.gbxTopCategory.Text = "대분류";
            // 
            // grdTopCategory
            // 
            this.grdTopCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTopCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTopCategory.Location = new System.Drawing.Point(3, 17);
            this.grdTopCategory.Name = "grdTopCategory";
            this.grdTopCategory.RowTemplate.Height = 23;
            this.grdTopCategory.Size = new System.Drawing.Size(263, 338);
            this.grdTopCategory.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTopSave);
            this.flowLayoutPanel1.Controls.Add(this.btnTopAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 520);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(275, 41);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnTopSave
            // 
            this.btnTopSave.Location = new System.Drawing.Point(192, 3);
            this.btnTopSave.Name = "btnTopSave";
            this.btnTopSave.Size = new System.Drawing.Size(80, 28);
            this.btnTopSave.TabIndex = 2;
            this.btnTopSave.Text = "저장";
            this.btnTopSave.UseVisualStyleBackColor = true;
            // 
            // btnTopAdd
            // 
            this.btnTopAdd.Location = new System.Drawing.Point(106, 3);
            this.btnTopAdd.Name = "btnTopAdd";
            this.btnTopAdd.Size = new System.Drawing.Size(80, 28);
            this.btnTopAdd.TabIndex = 5;
            this.btnTopAdd.Text = "추가";
            this.btnTopAdd.UseVisualStyleBackColor = true;
            // 
            // gbxMiddleCategory
            // 
            this.gbxMiddleCategory.Controls.Add(this.grdMiddleCategory);
            this.gbxMiddleCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMiddleCategory.Location = new System.Drawing.Point(288, 3);
            this.gbxMiddleCategory.Name = "gbxMiddleCategory";
            this.gbxMiddleCategory.Size = new System.Drawing.Size(270, 358);
            this.gbxMiddleCategory.TabIndex = 2;
            this.gbxMiddleCategory.TabStop = false;
            this.gbxMiddleCategory.Text = "중분류";
            // 
            // grdMiddleCategory
            // 
            this.grdMiddleCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMiddleCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMiddleCategory.Location = new System.Drawing.Point(3, 17);
            this.grdMiddleCategory.Name = "grdMiddleCategory";
            this.grdMiddleCategory.RowTemplate.Height = 23;
            this.grdMiddleCategory.Size = new System.Drawing.Size(264, 338);
            this.grdMiddleCategory.TabIndex = 0;
            // 
            // gbxDetailCategory
            // 
            this.gbxDetailCategory.Controls.Add(this.grdDetailCategory);
            this.gbxDetailCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDetailCategory.Location = new System.Drawing.Point(574, 3);
            this.gbxDetailCategory.Name = "gbxDetailCategory";
            this.gbxDetailCategory.Size = new System.Drawing.Size(271, 358);
            this.gbxDetailCategory.TabIndex = 3;
            this.gbxDetailCategory.TabStop = false;
            this.gbxDetailCategory.Text = "불량상세";
            // 
            // grdDetailCategory
            // 
            this.grdDetailCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetailCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetailCategory.Location = new System.Drawing.Point(3, 17);
            this.grdDetailCategory.Name = "grdDetailCategory";
            this.grdDetailCategory.RowTemplate.Height = 23;
            this.grdDetailCategory.Size = new System.Drawing.Size(265, 338);
            this.grdDetailCategory.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnMiddleSave);
            this.flowLayoutPanel2.Controls.Add(this.btnMiddleAdd);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(285, 520);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(276, 41);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // btnMiddleSave
            // 
            this.btnMiddleSave.Location = new System.Drawing.Point(193, 3);
            this.btnMiddleSave.Name = "btnMiddleSave";
            this.btnMiddleSave.Size = new System.Drawing.Size(80, 28);
            this.btnMiddleSave.TabIndex = 2;
            this.btnMiddleSave.Text = "저장";
            this.btnMiddleSave.UseVisualStyleBackColor = true;
            // 
            // btnMiddleAdd
            // 
            this.btnMiddleAdd.Location = new System.Drawing.Point(107, 3);
            this.btnMiddleAdd.Name = "btnMiddleAdd";
            this.btnMiddleAdd.Size = new System.Drawing.Size(80, 28);
            this.btnMiddleAdd.TabIndex = 5;
            this.btnMiddleAdd.Text = "추가";
            this.btnMiddleAdd.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnDetailSave);
            this.flowLayoutPanel3.Controls.Add(this.btnDetailAdd);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(571, 520);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(277, 41);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // btnDetailSave
            // 
            this.btnDetailSave.Location = new System.Drawing.Point(194, 3);
            this.btnDetailSave.Name = "btnDetailSave";
            this.btnDetailSave.Size = new System.Drawing.Size(80, 28);
            this.btnDetailSave.TabIndex = 2;
            this.btnDetailSave.Text = "저장";
            this.btnDetailSave.UseVisualStyleBackColor = true;
            // 
            // btnDetailAdd
            // 
            this.btnDetailAdd.Location = new System.Drawing.Point(108, 3);
            this.btnDetailAdd.Name = "btnDetailAdd";
            this.btnDetailAdd.Size = new System.Drawing.Size(80, 28);
            this.btnDetailAdd.TabIndex = 5;
            this.btnDetailAdd.Text = "추가";
            this.btnDetailAdd.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(288, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 150);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 150);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.txtTopName, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblTopCode, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblTopName, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblTopUseable, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtTopCode, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.comboTopUsable, 1, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(263, 130);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.comboMiddleUsable, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.txtMiddleName, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.txtMiddleCode, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblMiddleUseable, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.lblMiddleName, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblMiddleCode, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(264, 130);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.comboDetailUsable, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.txtDetailName, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.txtDetailCode, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.lblDetailUseable, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.lblDetailName, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lblDetailCode, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(265, 130);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // lblTopCode
            // 
            this.lblTopCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTopCode.Location = new System.Drawing.Point(3, 3);
            this.lblTopCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblTopCode.Name = "lblTopCode";
            this.lblTopCode.Size = new System.Drawing.Size(94, 34);
            this.lblTopCode.TabIndex = 0;
            this.lblTopCode.Text = "불량코드";
            this.lblTopCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTopName
            // 
            this.lblTopName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTopName.Location = new System.Drawing.Point(3, 43);
            this.lblTopName.Margin = new System.Windows.Forms.Padding(3);
            this.lblTopName.Name = "lblTopName";
            this.lblTopName.Size = new System.Drawing.Size(94, 34);
            this.lblTopName.TabIndex = 1;
            this.lblTopName.Text = "불량명";
            this.lblTopName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTopUseable
            // 
            this.lblTopUseable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTopUseable.Location = new System.Drawing.Point(3, 83);
            this.lblTopUseable.Margin = new System.Windows.Forms.Padding(3);
            this.lblTopUseable.Name = "lblTopUseable";
            this.lblTopUseable.Size = new System.Drawing.Size(94, 34);
            this.lblTopUseable.TabIndex = 2;
            this.lblTopUseable.Text = "사용여부";
            this.lblTopUseable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTopCode
            // 
            this.txtTopCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTopCode.Location = new System.Drawing.Point(103, 10);
            this.txtTopCode.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtTopCode.Name = "txtTopCode";
            this.txtTopCode.ReadOnly = true;
            this.txtTopCode.Size = new System.Drawing.Size(157, 21);
            this.txtTopCode.TabIndex = 3;
            // 
            // comboTopUsable
            // 
            this.comboTopUsable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboTopUsable.FormattingEnabled = true;
            this.comboTopUsable.Location = new System.Drawing.Point(103, 90);
            this.comboTopUsable.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboTopUsable.Name = "comboTopUsable";
            this.comboTopUsable.Size = new System.Drawing.Size(157, 20);
            this.comboTopUsable.TabIndex = 5;
            // 
            // txtTopName
            // 
            this.txtTopName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTopName.Location = new System.Drawing.Point(103, 50);
            this.txtTopName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtTopName.Name = "txtTopName";
            this.txtTopName.Size = new System.Drawing.Size(157, 21);
            this.txtTopName.TabIndex = 6;
            // 
            // lblMiddleCode
            // 
            this.lblMiddleCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleCode.Location = new System.Drawing.Point(3, 3);
            this.lblMiddleCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblMiddleCode.Name = "lblMiddleCode";
            this.lblMiddleCode.Size = new System.Drawing.Size(94, 34);
            this.lblMiddleCode.TabIndex = 1;
            this.lblMiddleCode.Text = "불량코드";
            this.lblMiddleCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetailCode
            // 
            this.lblDetailCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailCode.Location = new System.Drawing.Point(3, 3);
            this.lblDetailCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblDetailCode.Name = "lblDetailCode";
            this.lblDetailCode.Size = new System.Drawing.Size(94, 34);
            this.lblDetailCode.TabIndex = 1;
            this.lblDetailCode.Text = "불량코드";
            this.lblDetailCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleName.Location = new System.Drawing.Point(3, 43);
            this.lblMiddleName.Margin = new System.Windows.Forms.Padding(3);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(94, 34);
            this.lblMiddleName.TabIndex = 2;
            this.lblMiddleName.Text = "불량명";
            this.lblMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetailName
            // 
            this.lblDetailName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailName.Location = new System.Drawing.Point(3, 43);
            this.lblDetailName.Margin = new System.Windows.Forms.Padding(3);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(94, 34);
            this.lblDetailName.TabIndex = 2;
            this.lblDetailName.Text = "불량명";
            this.lblDetailName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiddleUseable
            // 
            this.lblMiddleUseable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleUseable.Location = new System.Drawing.Point(3, 83);
            this.lblMiddleUseable.Margin = new System.Windows.Forms.Padding(3);
            this.lblMiddleUseable.Name = "lblMiddleUseable";
            this.lblMiddleUseable.Size = new System.Drawing.Size(94, 34);
            this.lblMiddleUseable.TabIndex = 3;
            this.lblMiddleUseable.Text = "사용여부";
            this.lblMiddleUseable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetailUseable
            // 
            this.lblDetailUseable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailUseable.Location = new System.Drawing.Point(3, 83);
            this.lblDetailUseable.Margin = new System.Windows.Forms.Padding(3);
            this.lblDetailUseable.Name = "lblDetailUseable";
            this.lblDetailUseable.Size = new System.Drawing.Size(94, 34);
            this.lblDetailUseable.TabIndex = 3;
            this.lblDetailUseable.Text = "사용여부";
            this.lblDetailUseable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMiddleCode
            // 
            this.txtMiddleCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMiddleCode.Location = new System.Drawing.Point(103, 10);
            this.txtMiddleCode.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtMiddleCode.Name = "txtMiddleCode";
            this.txtMiddleCode.ReadOnly = true;
            this.txtMiddleCode.Size = new System.Drawing.Size(158, 21);
            this.txtMiddleCode.TabIndex = 4;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMiddleName.Location = new System.Drawing.Point(103, 50);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(158, 21);
            this.txtMiddleName.TabIndex = 7;
            // 
            // comboMiddleUsable
            // 
            this.comboMiddleUsable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboMiddleUsable.FormattingEnabled = true;
            this.comboMiddleUsable.Location = new System.Drawing.Point(103, 90);
            this.comboMiddleUsable.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboMiddleUsable.Name = "comboMiddleUsable";
            this.comboMiddleUsable.Size = new System.Drawing.Size(158, 20);
            this.comboMiddleUsable.TabIndex = 8;
            // 
            // txtDetailCode
            // 
            this.txtDetailCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetailCode.Location = new System.Drawing.Point(103, 10);
            this.txtDetailCode.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtDetailCode.Name = "txtDetailCode";
            this.txtDetailCode.ReadOnly = true;
            this.txtDetailCode.Size = new System.Drawing.Size(159, 21);
            this.txtDetailCode.TabIndex = 5;
            // 
            // txtDetailName
            // 
            this.txtDetailName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetailName.Location = new System.Drawing.Point(103, 50);
            this.txtDetailName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtDetailName.Name = "txtDetailName";
            this.txtDetailName.Size = new System.Drawing.Size(159, 21);
            this.txtDetailName.TabIndex = 8;
            // 
            // comboDetailUsable
            // 
            this.comboDetailUsable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboDetailUsable.FormattingEnabled = true;
            this.comboDetailUsable.Location = new System.Drawing.Point(103, 90);
            this.comboDetailUsable.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboDetailUsable.Name = "comboDetailUsable";
            this.comboDetailUsable.Size = new System.Drawing.Size(159, 20);
            this.comboDetailUsable.TabIndex = 9;
            // 
            // CS_DefectCodeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CS_DefectCodeManagement";
            this.Size = new System.Drawing.Size(1074, 627);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbxSearchCondition.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gbxDefectCode.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gbxTopCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTopCategory)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbxMiddleCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMiddleCategory)).EndInit();
            this.gbxDetailCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetailCategory)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxSearchCondition;
        private System.Windows.Forms.GroupBox gbxTopCategory;
        private System.Windows.Forms.DataGridView grdTopCategory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblUserNumber;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Button btnTopSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTopAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblUsableType;
        private System.Windows.Forms.ComboBox comboUsableType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox gbxMiddleCategory;
        private System.Windows.Forms.DataGridView grdMiddleCategory;
        private System.Windows.Forms.GroupBox gbxDetailCategory;
        private System.Windows.Forms.DataGridView grdDetailCategory;
        private System.Windows.Forms.GroupBox gbxDefectCode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnMiddleSave;
        private System.Windows.Forms.Button btnMiddleAdd;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnDetailSave;
        private System.Windows.Forms.Button btnDetailAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblTopCode;
        private System.Windows.Forms.Label lblTopName;
        private System.Windows.Forms.Label lblTopUseable;
        private System.Windows.Forms.TextBox txtTopCode;
        private System.Windows.Forms.ComboBox comboTopUsable;
        private System.Windows.Forms.TextBox txtTopName;
        private System.Windows.Forms.Label lblDetailCode;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Label lblMiddleCode;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblMiddleUseable;
        private System.Windows.Forms.Label lblDetailUseable;
        private System.Windows.Forms.TextBox txtMiddleCode;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.ComboBox comboMiddleUsable;
        private System.Windows.Forms.TextBox txtDetailCode;
        private System.Windows.Forms.TextBox txtDetailName;
        private System.Windows.Forms.ComboBox comboDetailUsable;
    }
}
