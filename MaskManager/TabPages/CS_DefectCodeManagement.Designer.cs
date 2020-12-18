
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxSearchCondition = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboSearchLevel = new System.Windows.Forms.ComboBox();
            this.lblSearchLevel = new System.Windows.Forms.Label();
            this.comboSearchValidState = new System.Windows.Forms.ComboBox();
            this.lblSearchValidState = new System.Windows.Forms.Label();
            this.txtSearchDefectName = new System.Windows.Forms.TextBox();
            this.lblSearchDefectName = new System.Windows.Forms.Label();
            this.lblSearchDefectCode = new System.Windows.Forms.Label();
            this.txtSearchDefectCode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbxDefectCode = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.comboDetailValidState = new System.Windows.Forms.ComboBox();
            this.txtDetailName = new System.Windows.Forms.TextBox();
            this.txtDetailCode = new System.Windows.Forms.TextBox();
            this.lblDetailUseable = new System.Windows.Forms.Label();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.lblDetailCode = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.comboMiddleValidState = new System.Windows.Forms.ComboBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtMiddleCode = new System.Windows.Forms.TextBox();
            this.lblMiddleUseable = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblMiddleCode = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTopName = new System.Windows.Forms.TextBox();
            this.lblTopCode = new System.Windows.Forms.Label();
            this.lblTopName = new System.Windows.Forms.Label();
            this.lblTopUseable = new System.Windows.Forms.Label();
            this.txtTopCode = new System.Windows.Forms.TextBox();
            this.comboTopValidState = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxSearchCondition.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbxDefectCode.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
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
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
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
            this.tableLayoutPanel2.Controls.Add(this.comboSearchLevel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSearchLevel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboSearchValidState, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSearchValidState, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSearchDefectName, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblSearchDefectName, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblSearchDefectCode, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSearchDefectCode, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
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
            // comboSearchLevel
            // 
            this.comboSearchLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboSearchLevel.FormattingEnabled = true;
            this.comboSearchLevel.Location = new System.Drawing.Point(83, 10);
            this.comboSearchLevel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboSearchLevel.Name = "comboSearchLevel";
            this.comboSearchLevel.Size = new System.Drawing.Size(116, 20);
            this.comboSearchLevel.TabIndex = 27;
            // 
            // lblSearchLevel
            // 
            this.lblSearchLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchLevel.ForeColor = System.Drawing.Color.Pink;
            this.lblSearchLevel.Location = new System.Drawing.Point(3, 3);
            this.lblSearchLevel.Margin = new System.Windows.Forms.Padding(3);
            this.lblSearchLevel.Name = "lblSearchLevel";
            this.lblSearchLevel.Size = new System.Drawing.Size(74, 34);
            this.lblSearchLevel.TabIndex = 26;
            this.lblSearchLevel.Text = "조회구분";
            this.lblSearchLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboSearchValidState
            // 
            this.comboSearchValidState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboSearchValidState.FormattingEnabled = true;
            this.comboSearchValidState.Location = new System.Drawing.Point(83, 50);
            this.comboSearchValidState.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboSearchValidState.Name = "comboSearchValidState";
            this.comboSearchValidState.Size = new System.Drawing.Size(116, 20);
            this.comboSearchValidState.TabIndex = 25;
            // 
            // lblSearchValidState
            // 
            this.lblSearchValidState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchValidState.ForeColor = System.Drawing.Color.Pink;
            this.lblSearchValidState.Location = new System.Drawing.Point(3, 43);
            this.lblSearchValidState.Margin = new System.Windows.Forms.Padding(3);
            this.lblSearchValidState.Name = "lblSearchValidState";
            this.lblSearchValidState.Size = new System.Drawing.Size(74, 34);
            this.lblSearchValidState.TabIndex = 24;
            this.lblSearchValidState.Text = "유효여부";
            this.lblSearchValidState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchDefectName
            // 
            this.txtSearchDefectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchDefectName.Location = new System.Drawing.Point(83, 130);
            this.txtSearchDefectName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtSearchDefectName.Name = "txtSearchDefectName";
            this.txtSearchDefectName.Size = new System.Drawing.Size(116, 21);
            this.txtSearchDefectName.TabIndex = 18;
            // 
            // lblSearchDefectName
            // 
            this.lblSearchDefectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchDefectName.Location = new System.Drawing.Point(3, 123);
            this.lblSearchDefectName.Margin = new System.Windows.Forms.Padding(3);
            this.lblSearchDefectName.Name = "lblSearchDefectName";
            this.lblSearchDefectName.Size = new System.Drawing.Size(74, 34);
            this.lblSearchDefectName.TabIndex = 8;
            this.lblSearchDefectName.Text = "불량명";
            this.lblSearchDefectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearchDefectCode
            // 
            this.lblSearchDefectCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchDefectCode.Location = new System.Drawing.Point(3, 83);
            this.lblSearchDefectCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblSearchDefectCode.Name = "lblSearchDefectCode";
            this.lblSearchDefectCode.Size = new System.Drawing.Size(74, 34);
            this.lblSearchDefectCode.TabIndex = 0;
            this.lblSearchDefectCode.Text = "불량코드";
            this.lblSearchDefectCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchDefectCode
            // 
            this.txtSearchDefectCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchDefectCode.Location = new System.Drawing.Point(83, 90);
            this.txtSearchDefectCode.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtSearchDefectCode.Name = "txtSearchDefectCode";
            this.txtSearchDefectCode.Size = new System.Drawing.Size(116, 21);
            this.txtSearchDefectCode.TabIndex = 13;
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
            this.lblTitle.Text = "불량코드 등록";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxDefectCode
            // 
            this.gbxDefectCode.Controls.Add(this.tableLayoutPanel4);
            this.gbxDefectCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDefectCode.ForeColor = System.Drawing.Color.White;
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
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(848, 561);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(574, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 202);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.comboDetailValidState, 1, 2);
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
            this.tableLayoutPanel7.Size = new System.Drawing.Size(265, 182);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // comboDetailValidState
            // 
            this.comboDetailValidState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboDetailValidState.FormattingEnabled = true;
            this.comboDetailValidState.Location = new System.Drawing.Point(103, 90);
            this.comboDetailValidState.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboDetailValidState.Name = "comboDetailValidState";
            this.comboDetailValidState.Size = new System.Drawing.Size(159, 20);
            this.comboDetailValidState.TabIndex = 9;
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
            // lblDetailUseable
            // 
            this.lblDetailUseable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailUseable.ForeColor = System.Drawing.Color.White;
            this.lblDetailUseable.Location = new System.Drawing.Point(3, 83);
            this.lblDetailUseable.Margin = new System.Windows.Forms.Padding(3);
            this.lblDetailUseable.Name = "lblDetailUseable";
            this.lblDetailUseable.Size = new System.Drawing.Size(94, 34);
            this.lblDetailUseable.TabIndex = 3;
            this.lblDetailUseable.Text = "유효여부";
            this.lblDetailUseable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetailName
            // 
            this.lblDetailName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailName.ForeColor = System.Drawing.Color.White;
            this.lblDetailName.Location = new System.Drawing.Point(3, 43);
            this.lblDetailName.Margin = new System.Windows.Forms.Padding(3);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(94, 34);
            this.lblDetailName.TabIndex = 2;
            this.lblDetailName.Text = "불량명";
            this.lblDetailName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetailCode
            // 
            this.lblDetailCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailCode.ForeColor = System.Drawing.Color.Pink;
            this.lblDetailCode.Location = new System.Drawing.Point(3, 3);
            this.lblDetailCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblDetailCode.Name = "lblDetailCode";
            this.lblDetailCode.Size = new System.Drawing.Size(94, 34);
            this.lblDetailCode.TabIndex = 1;
            this.lblDetailCode.Text = "불량코드";
            this.lblDetailCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxTopCategory
            // 
            this.gbxTopCategory.Controls.Add(this.grdTopCategory);
            this.gbxTopCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxTopCategory.ForeColor = System.Drawing.Color.White;
            this.gbxTopCategory.Location = new System.Drawing.Point(3, 3);
            this.gbxTopCategory.Name = "gbxTopCategory";
            this.gbxTopCategory.Size = new System.Drawing.Size(269, 306);
            this.gbxTopCategory.TabIndex = 1;
            this.gbxTopCategory.TabStop = false;
            this.gbxTopCategory.Text = "대분류";
            // 
            // grdTopCategory
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTopCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTopCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTopCategory.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdTopCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTopCategory.EnableHeadersVisualStyles = false;
            this.grdTopCategory.Location = new System.Drawing.Point(3, 17);
            this.grdTopCategory.Name = "grdTopCategory";
            this.grdTopCategory.RowTemplate.Height = 23;
            this.grdTopCategory.Size = new System.Drawing.Size(263, 286);
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
            this.btnTopSave.BackColor = System.Drawing.Color.DimGray;
            this.btnTopSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopSave.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTopSave.Location = new System.Drawing.Point(192, 3);
            this.btnTopSave.Name = "btnTopSave";
            this.btnTopSave.Size = new System.Drawing.Size(80, 28);
            this.btnTopSave.TabIndex = 2;
            this.btnTopSave.Text = "저장";
            this.btnTopSave.UseVisualStyleBackColor = false;
            // 
            // btnTopAdd
            // 
            this.btnTopAdd.BackColor = System.Drawing.Color.DimGray;
            this.btnTopAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopAdd.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTopAdd.Location = new System.Drawing.Point(106, 3);
            this.btnTopAdd.Name = "btnTopAdd";
            this.btnTopAdd.Size = new System.Drawing.Size(80, 28);
            this.btnTopAdd.TabIndex = 5;
            this.btnTopAdd.Text = "추가";
            this.btnTopAdd.UseVisualStyleBackColor = false;
            // 
            // gbxMiddleCategory
            // 
            this.gbxMiddleCategory.Controls.Add(this.grdMiddleCategory);
            this.gbxMiddleCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMiddleCategory.ForeColor = System.Drawing.Color.White;
            this.gbxMiddleCategory.Location = new System.Drawing.Point(288, 3);
            this.gbxMiddleCategory.Name = "gbxMiddleCategory";
            this.gbxMiddleCategory.Size = new System.Drawing.Size(270, 306);
            this.gbxMiddleCategory.TabIndex = 2;
            this.gbxMiddleCategory.TabStop = false;
            this.gbxMiddleCategory.Text = "중분류";
            // 
            // grdMiddleCategory
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMiddleCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdMiddleCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMiddleCategory.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdMiddleCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMiddleCategory.EnableHeadersVisualStyles = false;
            this.grdMiddleCategory.Location = new System.Drawing.Point(3, 17);
            this.grdMiddleCategory.Name = "grdMiddleCategory";
            this.grdMiddleCategory.RowTemplate.Height = 23;
            this.grdMiddleCategory.Size = new System.Drawing.Size(264, 286);
            this.grdMiddleCategory.TabIndex = 0;
            // 
            // gbxDetailCategory
            // 
            this.gbxDetailCategory.Controls.Add(this.grdDetailCategory);
            this.gbxDetailCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDetailCategory.ForeColor = System.Drawing.Color.White;
            this.gbxDetailCategory.Location = new System.Drawing.Point(574, 3);
            this.gbxDetailCategory.Name = "gbxDetailCategory";
            this.gbxDetailCategory.Size = new System.Drawing.Size(271, 306);
            this.gbxDetailCategory.TabIndex = 3;
            this.gbxDetailCategory.TabStop = false;
            this.gbxDetailCategory.Text = "불량상세";
            // 
            // grdDetailCategory
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDetailCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdDetailCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDetailCategory.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdDetailCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetailCategory.EnableHeadersVisualStyles = false;
            this.grdDetailCategory.Location = new System.Drawing.Point(3, 17);
            this.grdDetailCategory.Name = "grdDetailCategory";
            this.grdDetailCategory.RowTemplate.Height = 23;
            this.grdDetailCategory.Size = new System.Drawing.Size(265, 286);
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
            this.btnMiddleSave.BackColor = System.Drawing.Color.DimGray;
            this.btnMiddleSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiddleSave.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMiddleSave.Location = new System.Drawing.Point(193, 3);
            this.btnMiddleSave.Name = "btnMiddleSave";
            this.btnMiddleSave.Size = new System.Drawing.Size(80, 28);
            this.btnMiddleSave.TabIndex = 2;
            this.btnMiddleSave.Text = "저장";
            this.btnMiddleSave.UseVisualStyleBackColor = false;
            // 
            // btnMiddleAdd
            // 
            this.btnMiddleAdd.BackColor = System.Drawing.Color.DimGray;
            this.btnMiddleAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiddleAdd.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMiddleAdd.Location = new System.Drawing.Point(107, 3);
            this.btnMiddleAdd.Name = "btnMiddleAdd";
            this.btnMiddleAdd.Size = new System.Drawing.Size(80, 28);
            this.btnMiddleAdd.TabIndex = 5;
            this.btnMiddleAdd.Text = "추가";
            this.btnMiddleAdd.UseVisualStyleBackColor = false;
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
            this.btnDetailSave.BackColor = System.Drawing.Color.DimGray;
            this.btnDetailSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailSave.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDetailSave.Location = new System.Drawing.Point(194, 3);
            this.btnDetailSave.Name = "btnDetailSave";
            this.btnDetailSave.Size = new System.Drawing.Size(80, 28);
            this.btnDetailSave.TabIndex = 2;
            this.btnDetailSave.Text = "저장";
            this.btnDetailSave.UseVisualStyleBackColor = false;
            // 
            // btnDetailAdd
            // 
            this.btnDetailAdd.BackColor = System.Drawing.Color.DimGray;
            this.btnDetailAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailAdd.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDetailAdd.Location = new System.Drawing.Point(108, 3);
            this.btnDetailAdd.Name = "btnDetailAdd";
            this.btnDetailAdd.Size = new System.Drawing.Size(80, 28);
            this.btnDetailAdd.TabIndex = 5;
            this.btnDetailAdd.Text = "추가";
            this.btnDetailAdd.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(288, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 202);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.comboMiddleValidState, 1, 2);
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
            this.tableLayoutPanel6.Size = new System.Drawing.Size(264, 182);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // comboMiddleValidState
            // 
            this.comboMiddleValidState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboMiddleValidState.FormattingEnabled = true;
            this.comboMiddleValidState.Location = new System.Drawing.Point(103, 90);
            this.comboMiddleValidState.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboMiddleValidState.Name = "comboMiddleValidState";
            this.comboMiddleValidState.Size = new System.Drawing.Size(158, 20);
            this.comboMiddleValidState.TabIndex = 8;
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
            // lblMiddleUseable
            // 
            this.lblMiddleUseable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleUseable.ForeColor = System.Drawing.Color.White;
            this.lblMiddleUseable.Location = new System.Drawing.Point(3, 83);
            this.lblMiddleUseable.Margin = new System.Windows.Forms.Padding(3);
            this.lblMiddleUseable.Name = "lblMiddleUseable";
            this.lblMiddleUseable.Size = new System.Drawing.Size(94, 34);
            this.lblMiddleUseable.TabIndex = 3;
            this.lblMiddleUseable.Text = "유효여부";
            this.lblMiddleUseable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleName.ForeColor = System.Drawing.Color.White;
            this.lblMiddleName.Location = new System.Drawing.Point(3, 43);
            this.lblMiddleName.Margin = new System.Windows.Forms.Padding(3);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(94, 34);
            this.lblMiddleName.TabIndex = 2;
            this.lblMiddleName.Text = "불량명";
            this.lblMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiddleCode
            // 
            this.lblMiddleCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleCode.ForeColor = System.Drawing.Color.Pink;
            this.lblMiddleCode.Location = new System.Drawing.Point(3, 3);
            this.lblMiddleCode.Margin = new System.Windows.Forms.Padding(3);
            this.lblMiddleCode.Name = "lblMiddleCode";
            this.lblMiddleCode.Size = new System.Drawing.Size(94, 34);
            this.lblMiddleCode.TabIndex = 1;
            this.lblMiddleCode.Text = "불량코드";
            this.lblMiddleCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 315);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 202);
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
            this.tableLayoutPanel5.Controls.Add(this.comboTopValidState, 1, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(263, 182);
            this.tableLayoutPanel5.TabIndex = 0;
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
            // lblTopCode
            // 
            this.lblTopCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTopCode.ForeColor = System.Drawing.Color.Pink;
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
            this.lblTopName.ForeColor = System.Drawing.Color.White;
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
            this.lblTopUseable.ForeColor = System.Drawing.Color.White;
            this.lblTopUseable.Location = new System.Drawing.Point(3, 83);
            this.lblTopUseable.Margin = new System.Windows.Forms.Padding(3);
            this.lblTopUseable.Name = "lblTopUseable";
            this.lblTopUseable.Size = new System.Drawing.Size(94, 34);
            this.lblTopUseable.TabIndex = 2;
            this.lblTopUseable.Text = "유효여부";
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
            // comboTopValidState
            // 
            this.comboTopValidState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboTopValidState.FormattingEnabled = true;
            this.comboTopValidState.Location = new System.Drawing.Point(103, 90);
            this.comboTopValidState.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.comboTopValidState.Name = "comboTopValidState";
            this.comboTopValidState.Size = new System.Drawing.Size(157, 20);
            this.comboTopValidState.TabIndex = 5;
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
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
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
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxSearchCondition;
        private System.Windows.Forms.GroupBox gbxTopCategory;
        private System.Windows.Forms.DataGridView grdTopCategory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblSearchDefectCode;
        private System.Windows.Forms.Label lblSearchDefectName;
        private System.Windows.Forms.TextBox txtSearchDefectName;
        private System.Windows.Forms.TextBox txtSearchDefectCode;
        private System.Windows.Forms.Button btnTopSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTopAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearchValidState;
        private System.Windows.Forms.ComboBox comboSearchValidState;
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
        private System.Windows.Forms.ComboBox comboTopValidState;
        private System.Windows.Forms.TextBox txtTopName;
        private System.Windows.Forms.Label lblDetailCode;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Label lblMiddleCode;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblMiddleUseable;
        private System.Windows.Forms.Label lblDetailUseable;
        private System.Windows.Forms.TextBox txtMiddleCode;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.ComboBox comboMiddleValidState;
        private System.Windows.Forms.TextBox txtDetailCode;
        private System.Windows.Forms.TextBox txtDetailName;
        private System.Windows.Forms.ComboBox comboDetailValidState;
        private System.Windows.Forms.Label lblSearchLevel;
        private System.Windows.Forms.ComboBox comboSearchLevel;
    }
}
