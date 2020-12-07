namespace MaskManager
{
    partial class MainFrm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MMStoredInfoTabPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tlpUser = new System.Windows.Forms.TableLayoutPanel();
            this.lblCrrUser = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.lblUsing = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblCountEmpty = new System.Windows.Forms.Label();
            this.lblCountUsing = new System.Windows.Forms.Label();
            this.lblCountStock = new System.Windows.Forms.Label();
            this.lblCountWarning = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCleanInsp = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblInputDate = new System.Windows.Forms.Label();
            this.lblRecentUse = new System.Windows.Forms.Label();
            this.lblTotalUseQty = new System.Windows.Forms.Label();
            this.lblInputInsp = new System.Windows.Forms.Label();
            this.lblRackID = new System.Windows.Forms.Label();
            this.lblModelName = new System.Windows.Forms.Label();
            this.lblMaskID = new System.Windows.Forms.Label();
            this.lblDataMaskID = new System.Windows.Forms.Label();
            this.lblDataModelName = new System.Windows.Forms.Label();
            this.lblDataRackID = new System.Windows.Forms.Label();
            this.lblDataInputInsp = new System.Windows.Forms.Label();
            this.lblDataInputDate = new System.Windows.Forms.Label();
            this.lblDataRecentUse = new System.Windows.Forms.Label();
            this.lblDataTotalUse = new System.Windows.Forms.Label();
            this.lblDataCleanInsp = new System.Windows.Forms.Label();
            this.lblDataDescription = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MMManagedReportTabPage = new System.Windows.Forms.TabPage();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.pnlEmpty = new System.Windows.Forms.Panel();
            this.pnlUsing = new System.Windows.Forms.Panel();
            this.pnlStock = new System.Windows.Forms.Panel();
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVender = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDurable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEquipment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStorage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.MMStoredInfoPage = new MaskManager.TabPages.MMStoredInfo();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.MMStoredInfoTabPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tlpUser.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1006, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.MMStoredInfoTabPage);
            this.tabControl1.Controls.Add(this.MMManagedReportTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1006, 694);
            this.tabControl1.TabIndex = 1;
            // 
            // MMStoredInfoTabPage
            // 
            this.MMStoredInfoTabPage.BackColor = System.Drawing.Color.White;
            this.MMStoredInfoTabPage.Controls.Add(this.groupBox4);
            this.MMStoredInfoTabPage.Controls.Add(this.groupBox3);
            this.MMStoredInfoTabPage.Controls.Add(this.groupBox2);
            this.MMStoredInfoTabPage.Controls.Add(this.groupBox1);
            this.MMStoredInfoTabPage.Location = new System.Drawing.Point(4, 4);
            this.MMStoredInfoTabPage.Name = "MMStoredInfoTabPage";
            this.MMStoredInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MMStoredInfoTabPage.Size = new System.Drawing.Size(998, 665);
            this.MMStoredInfoTabPage.TabIndex = 0;
            this.MMStoredInfoTabPage.Text = "보관관리정보";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tlpUser);
            this.groupBox4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.Location = new System.Drawing.Point(744, 566);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(246, 71);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "현재 사용 유저";
            // 
            // tlpUser
            // 
            this.tlpUser.ColumnCount = 2;
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpUser.Controls.Add(this.lblCrrUser, 0, 0);
            this.tlpUser.Controls.Add(this.btnLogIn, 1, 0);
            this.tlpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUser.Location = new System.Drawing.Point(3, 23);
            this.tlpUser.Name = "tlpUser";
            this.tlpUser.RowCount = 1;
            this.tlpUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUser.Size = new System.Drawing.Size(240, 45);
            this.tlpUser.TabIndex = 0;
            // 
            // lblCrrUser
            // 
            this.lblCrrUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCrrUser.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCrrUser.ForeColor = System.Drawing.Color.Blue;
            this.lblCrrUser.Location = new System.Drawing.Point(3, 0);
            this.lblCrrUser.Name = "lblCrrUser";
            this.lblCrrUser.Size = new System.Drawing.Size(189, 45);
            this.lblCrrUser.TabIndex = 0;
            this.lblCrrUser.Text = "label1";
            this.lblCrrUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(744, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 229);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "생산 진행 정보";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.pnlEmpty, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlUsing, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pnlStock, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pnlWarning, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblEmpty, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblUsing, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblStock, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblWarning, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblCountEmpty, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCountUsing, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCountStock, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCountWarning, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 203);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblEmpty
            // 
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEmpty.Location = new System.Drawing.Point(111, 0);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(78, 50);
            this.lblEmpty.TabIndex = 4;
            this.lblEmpty.Text = "비어있음";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsing
            // 
            this.lblUsing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsing.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUsing.Location = new System.Drawing.Point(111, 50);
            this.lblUsing.Name = "lblUsing";
            this.lblUsing.Size = new System.Drawing.Size(78, 50);
            this.lblUsing.TabIndex = 5;
            this.lblUsing.Text = "사용중";
            this.lblUsing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStock
            // 
            this.lblStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStock.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStock.Location = new System.Drawing.Point(111, 100);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(78, 50);
            this.lblStock.TabIndex = 6;
            this.lblStock.Text = "보관중";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarning
            // 
            this.lblWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarning.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWarning.Location = new System.Drawing.Point(111, 150);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(78, 53);
            this.lblWarning.TabIndex = 7;
            this.lblWarning.Text = "사용제한횟수 임박";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountEmpty
            // 
            this.lblCountEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCountEmpty.Location = new System.Drawing.Point(195, 0);
            this.lblCountEmpty.Name = "lblCountEmpty";
            this.lblCountEmpty.Size = new System.Drawing.Size(42, 50);
            this.lblCountEmpty.TabIndex = 8;
            this.lblCountEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCountUsing
            // 
            this.lblCountUsing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCountUsing.Location = new System.Drawing.Point(195, 50);
            this.lblCountUsing.Name = "lblCountUsing";
            this.lblCountUsing.Size = new System.Drawing.Size(42, 50);
            this.lblCountUsing.TabIndex = 9;
            this.lblCountUsing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCountStock
            // 
            this.lblCountStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCountStock.Location = new System.Drawing.Point(195, 100);
            this.lblCountStock.Name = "lblCountStock";
            this.lblCountStock.Size = new System.Drawing.Size(42, 50);
            this.lblCountStock.TabIndex = 10;
            this.lblCountStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCountWarning
            // 
            this.lblCountWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCountWarning.Location = new System.Drawing.Point(195, 150);
            this.lblCountWarning.Name = "lblCountWarning";
            this.lblCountWarning.Size = new System.Drawing.Size(42, 53);
            this.lblCountWarning.TabIndex = 11;
            this.lblCountWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(744, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 321);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mask 상세 정보";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 295);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.lblCleanInsp, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblDescription, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblInputDate, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblRecentUse, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalUseQty, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblInputInsp, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblRackID, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblModelName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaskID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDataMaskID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDataModelName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDataRackID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDataInputInsp, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDataInputDate, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDataRecentUse, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDataTotalUse, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDataCleanInsp, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblDataDescription, 1, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 295);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCleanInsp
            // 
            this.lblCleanInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCleanInsp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCleanInsp.Location = new System.Drawing.Point(6, 227);
            this.lblCleanInsp.Name = "lblCleanInsp";
            this.lblCleanInsp.Size = new System.Drawing.Size(121, 29);
            this.lblCleanInsp.TabIndex = 8;
            this.lblCleanInsp.Text = "세척검사결과";
            this.lblCleanInsp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDescription.Location = new System.Drawing.Point(6, 259);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(121, 33);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Mask 사양정보";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInputDate
            // 
            this.lblInputDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInputDate.Location = new System.Drawing.Point(6, 131);
            this.lblInputDate.Name = "lblInputDate";
            this.lblInputDate.Size = new System.Drawing.Size(121, 29);
            this.lblInputDate.TabIndex = 6;
            this.lblInputDate.Text = "입고일자";
            this.lblInputDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecentUse
            // 
            this.lblRecentUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecentUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRecentUse.Location = new System.Drawing.Point(6, 163);
            this.lblRecentUse.Name = "lblRecentUse";
            this.lblRecentUse.Size = new System.Drawing.Size(121, 29);
            this.lblRecentUse.TabIndex = 5;
            this.lblRecentUse.Text = "최종사용일자";
            this.lblRecentUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalUseQty
            // 
            this.lblTotalUseQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalUseQty.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalUseQty.Location = new System.Drawing.Point(6, 195);
            this.lblTotalUseQty.Name = "lblTotalUseQty";
            this.lblTotalUseQty.Size = new System.Drawing.Size(121, 29);
            this.lblTotalUseQty.TabIndex = 4;
            this.lblTotalUseQty.Text = "총 사용횟수";
            this.lblTotalUseQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInputInsp
            // 
            this.lblInputInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputInsp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInputInsp.Location = new System.Drawing.Point(6, 99);
            this.lblInputInsp.Name = "lblInputInsp";
            this.lblInputInsp.Size = new System.Drawing.Size(121, 29);
            this.lblInputInsp.TabIndex = 3;
            this.lblInputInsp.Text = "수입검사결과";
            this.lblInputInsp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRackID
            // 
            this.lblRackID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRackID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRackID.Location = new System.Drawing.Point(6, 67);
            this.lblRackID.Name = "lblRackID";
            this.lblRackID.Size = new System.Drawing.Size(121, 29);
            this.lblRackID.TabIndex = 2;
            this.lblRackID.Text = "보관함 위치";
            this.lblRackID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblModelName
            // 
            this.lblModelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModelName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblModelName.Location = new System.Drawing.Point(6, 35);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(121, 29);
            this.lblModelName.TabIndex = 1;
            this.lblModelName.Text = "모델명";
            this.lblModelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaskID
            // 
            this.lblMaskID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaskID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMaskID.Location = new System.Drawing.Point(6, 3);
            this.lblMaskID.Name = "lblMaskID";
            this.lblMaskID.Size = new System.Drawing.Size(121, 29);
            this.lblMaskID.TabIndex = 0;
            this.lblMaskID.Text = "Mask 일련번호";
            this.lblMaskID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataMaskID
            // 
            this.lblDataMaskID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataMaskID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataMaskID.Location = new System.Drawing.Point(136, 3);
            this.lblDataMaskID.Name = "lblDataMaskID";
            this.lblDataMaskID.Size = new System.Drawing.Size(98, 29);
            this.lblDataMaskID.TabIndex = 9;
            this.lblDataMaskID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataModelName
            // 
            this.lblDataModelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataModelName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataModelName.Location = new System.Drawing.Point(136, 35);
            this.lblDataModelName.Name = "lblDataModelName";
            this.lblDataModelName.Size = new System.Drawing.Size(98, 29);
            this.lblDataModelName.TabIndex = 10;
            this.lblDataModelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataRackID
            // 
            this.lblDataRackID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataRackID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataRackID.Location = new System.Drawing.Point(136, 67);
            this.lblDataRackID.Name = "lblDataRackID";
            this.lblDataRackID.Size = new System.Drawing.Size(98, 29);
            this.lblDataRackID.TabIndex = 11;
            this.lblDataRackID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataInputInsp
            // 
            this.lblDataInputInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataInputInsp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataInputInsp.Location = new System.Drawing.Point(136, 99);
            this.lblDataInputInsp.Name = "lblDataInputInsp";
            this.lblDataInputInsp.Size = new System.Drawing.Size(98, 29);
            this.lblDataInputInsp.TabIndex = 12;
            this.lblDataInputInsp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataInputDate
            // 
            this.lblDataInputDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataInputDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataInputDate.Location = new System.Drawing.Point(136, 131);
            this.lblDataInputDate.Name = "lblDataInputDate";
            this.lblDataInputDate.Size = new System.Drawing.Size(98, 29);
            this.lblDataInputDate.TabIndex = 13;
            this.lblDataInputDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataRecentUse
            // 
            this.lblDataRecentUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataRecentUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataRecentUse.Location = new System.Drawing.Point(136, 163);
            this.lblDataRecentUse.Name = "lblDataRecentUse";
            this.lblDataRecentUse.Size = new System.Drawing.Size(98, 29);
            this.lblDataRecentUse.TabIndex = 14;
            this.lblDataRecentUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataTotalUse
            // 
            this.lblDataTotalUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataTotalUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataTotalUse.Location = new System.Drawing.Point(136, 195);
            this.lblDataTotalUse.Name = "lblDataTotalUse";
            this.lblDataTotalUse.Size = new System.Drawing.Size(98, 29);
            this.lblDataTotalUse.TabIndex = 15;
            this.lblDataTotalUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataCleanInsp
            // 
            this.lblDataCleanInsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataCleanInsp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataCleanInsp.Location = new System.Drawing.Point(136, 227);
            this.lblDataCleanInsp.Name = "lblDataCleanInsp";
            this.lblDataCleanInsp.Size = new System.Drawing.Size(98, 29);
            this.lblDataCleanInsp.TabIndex = 16;
            this.lblDataCleanInsp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataDescription
            // 
            this.lblDataDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataDescription.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDataDescription.Location = new System.Drawing.Point(136, 259);
            this.lblDataDescription.Name = "lblDataDescription";
            this.lblDataDescription.Size = new System.Drawing.Size(98, 33);
            this.lblDataDescription.TabIndex = 17;
            this.lblDataDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 659);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "보관함";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MMStoredInfoPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 633);
            this.panel1.TabIndex = 0;
            // 
            // MMManagedReportTabPage
            // 
            this.MMManagedReportTabPage.AutoScroll = true;
            this.MMManagedReportTabPage.Location = new System.Drawing.Point(4, 4);
            this.MMManagedReportTabPage.Name = "MMManagedReportTabPage";
            this.MMManagedReportTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MMManagedReportTabPage.Size = new System.Drawing.Size(998, 665);
            this.MMManagedReportTabPage.TabIndex = 1;
            this.MMManagedReportTabPage.Text = "관리대장";
            this.MMManagedReportTabPage.UseVisualStyleBackColor = true;
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackgroundImage = global::MaskManager.Properties.Resources.user;
            this.btnLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogIn.Location = new System.Drawing.Point(198, 3);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(39, 39);
            this.btnLogIn.TabIndex = 1;
            this.btnLogIn.UseVisualStyleBackColor = true;
            // 
            // pnlEmpty
            // 
            this.pnlEmpty.BackgroundImage = global::MaskManager.Properties.Resources.Rack_White;
            this.pnlEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmpty.Location = new System.Drawing.Point(3, 3);
            this.pnlEmpty.Name = "pnlEmpty";
            this.pnlEmpty.Size = new System.Drawing.Size(102, 44);
            this.pnlEmpty.TabIndex = 0;
            // 
            // pnlUsing
            // 
            this.pnlUsing.BackgroundImage = global::MaskManager.Properties.Resources.Rack_Blue;
            this.pnlUsing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlUsing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUsing.Location = new System.Drawing.Point(3, 53);
            this.pnlUsing.Name = "pnlUsing";
            this.pnlUsing.Size = new System.Drawing.Size(102, 44);
            this.pnlUsing.TabIndex = 1;
            // 
            // pnlStock
            // 
            this.pnlStock.BackgroundImage = global::MaskManager.Properties.Resources.Rack_Green;
            this.pnlStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStock.Location = new System.Drawing.Point(3, 103);
            this.pnlStock.Name = "pnlStock";
            this.pnlStock.Size = new System.Drawing.Size(102, 44);
            this.pnlStock.TabIndex = 2;
            // 
            // pnlWarning
            // 
            this.pnlWarning.BackgroundImage = global::MaskManager.Properties.Resources.Rack_Red;
            this.pnlWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarning.Location = new System.Drawing.Point(3, 153);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(102, 47);
            this.pnlWarning.TabIndex = 3;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUser,
            this.tsmVender,
            this.tsmDurable,
            this.tsmEquipment,
            this.tsmStorage});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(88, 24);
            this.toolStripSplitButton1.Text = "기준정보";
            // 
            // tsmUser
            // 
            this.tsmUser.Name = "tsmUser";
            this.tsmUser.Size = new System.Drawing.Size(144, 26);
            this.tsmUser.Text = "사용자";
            this.tsmUser.Click += new System.EventHandler(this.tsmUser_Click);
            // 
            // tsmVender
            // 
            this.tsmVender.Name = "tsmVender";
            this.tsmVender.Size = new System.Drawing.Size(144, 26);
            this.tsmVender.Text = "제작업체";
            this.tsmVender.Click += new System.EventHandler(this.TsmVender_Click);
            // 
            // tsmDurable
            // 
            this.tsmDurable.Name = "tsmDurable";
            this.tsmDurable.Size = new System.Drawing.Size(144, 26);
            this.tsmDurable.Text = "모델";
            this.tsmDurable.Click += new System.EventHandler(this.TsmDurable_Click);
            // 
            // tsmEquipment
            // 
            this.tsmEquipment.Name = "tsmEquipment";
            this.tsmEquipment.Size = new System.Drawing.Size(144, 26);
            this.tsmEquipment.Text = "설비";
            this.tsmEquipment.Click += new System.EventHandler(this.TsmEquipment_Click);
            // 
            // tsmStorage
            // 
            this.tsmStorage.Name = "tsmStorage";
            this.tsmStorage.Size = new System.Drawing.Size(144, 26);
            this.tsmStorage.Text = "적치대";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(114, 24);
            this.toolStripButton1.Text = "Mask 신규등록";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(108, 24);
            this.toolStripButton2.Text = "생산정보 입력";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(73, 24);
            this.toolStripButton3.Text = "세척검사";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(43, 24);
            this.toolStripButton4.Text = "폐기";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(68, 24);
            this.toolStripButton5.Text = "DB 관리";
            this.toolStripButton5.Click += new System.EventHandler(this.ToolStripButton5_Click);
            // 
            // MMStoredInfoPage
            // 
            this.MMStoredInfoPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MMStoredInfoPage.Location = new System.Drawing.Point(0, 0);
            this.MMStoredInfoPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MMStoredInfoPage.Name = "MMStoredInfoPage";
            this.MMStoredInfoPage.Size = new System.Drawing.Size(729, 633);
            this.MMStoredInfoPage.TabIndex = 0;
            // 
            // MainFrm
            // 
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainFrm";
            this.Text = "Mask Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.MMStoredInfoTabPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tlpUser.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmUser;
        private System.Windows.Forms.ToolStripMenuItem tsmVender;
        private System.Windows.Forms.ToolStripMenuItem tsmDurable;
        private System.Windows.Forms.ToolStripMenuItem tsmEquipment;
        private System.Windows.Forms.ToolStripMenuItem tsmStorage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MMStoredInfoTabPage;
        private System.Windows.Forms.TabPage MMManagedReportTabPage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.Panel panel1;
        private TabPages.MMStoredInfo MMStoredInfoPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMaskID;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Label lblCleanInsp;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblInputDate;
        private System.Windows.Forms.Label lblRecentUse;
        private System.Windows.Forms.Label lblTotalUseQty;
        private System.Windows.Forms.Label lblInputInsp;
        private System.Windows.Forms.Label lblRackID;
        private System.Windows.Forms.Label lblDataMaskID;
        private System.Windows.Forms.Label lblDataModelName;
        private System.Windows.Forms.Label lblDataRackID;
        private System.Windows.Forms.Label lblDataInputInsp;
        private System.Windows.Forms.Label lblDataInputDate;
        private System.Windows.Forms.Label lblDataRecentUse;
        private System.Windows.Forms.Label lblDataTotalUse;
        private System.Windows.Forms.Label lblDataCleanInsp;
        private System.Windows.Forms.Label lblDataDescription;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tlpUser;
        private System.Windows.Forms.Label lblCrrUser;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlEmpty;
        private System.Windows.Forms.Panel pnlUsing;
        private System.Windows.Forms.Panel pnlStock;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Label lblUsing;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblCountEmpty;
        private System.Windows.Forms.Label lblCountUsing;
        private System.Windows.Forms.Label lblCountStock;
        private System.Windows.Forms.Label lblCountWarning;
    }
}

