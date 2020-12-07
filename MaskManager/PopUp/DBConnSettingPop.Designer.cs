namespace MaskManager.PopUp
{
    partial class DBConnSettingPop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtxtPW = new MaskManager.UserControls.MaskTextBox();
            this.mtxtID = new MaskManager.UserControls.MaskTextBox();
            this.mtxtCatalog = new MaskManager.UserControls.MaskTextBox();
            this.mtxtIP = new MaskManager.UserControls.MaskTextBox();
            this.pnlHide = new System.Windows.Forms.Panel();
            this.mtxtAdmin = new MaskManager.UserControls.MaskTextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlHide.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(441, 30);
            this.lblTitle.Text = "DB세팅";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(441, 158);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(334, 86);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 64);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(334, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 64);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlHide);
            this.groupBox1.Controls.Add(this.mtxtPW);
            this.groupBox1.Controls.Add(this.mtxtID);
            this.groupBox1.Controls.Add(this.mtxtCatalog);
            this.groupBox1.Controls.Add(this.mtxtIP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB 세팅정보";
            // 
            // mtxtPW
            // 
            this.mtxtPW.Dock = System.Windows.Forms.DockStyle.Top;
            this.mtxtPW.Location = new System.Drawing.Point(3, 111);
            this.mtxtPW.Name = "mtxtPW";
            this.mtxtPW.Size = new System.Drawing.Size(315, 30);
            this.mtxtPW.TabIndex = 3;
            this.mtxtPW.ucLabelText = "P/W";
            this.mtxtPW.ucMandatory = true;
            this.mtxtPW.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtPW.ucTextArea = false;
            this.mtxtPW.ucTextReadOnly = false;
            this.mtxtPW.ucValue = "";
            // 
            // mtxtID
            // 
            this.mtxtID.Dock = System.Windows.Forms.DockStyle.Top;
            this.mtxtID.Location = new System.Drawing.Point(3, 81);
            this.mtxtID.Name = "mtxtID";
            this.mtxtID.Size = new System.Drawing.Size(315, 30);
            this.mtxtID.TabIndex = 2;
            this.mtxtID.ucLabelText = "ID";
            this.mtxtID.ucMandatory = true;
            this.mtxtID.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtID.ucTextArea = false;
            this.mtxtID.ucTextReadOnly = false;
            this.mtxtID.ucValue = "";
            // 
            // mtxtCatalog
            // 
            this.mtxtCatalog.Dock = System.Windows.Forms.DockStyle.Top;
            this.mtxtCatalog.Location = new System.Drawing.Point(3, 51);
            this.mtxtCatalog.Name = "mtxtCatalog";
            this.mtxtCatalog.Size = new System.Drawing.Size(315, 30);
            this.mtxtCatalog.TabIndex = 1;
            this.mtxtCatalog.ucLabelText = "Initial Catalog";
            this.mtxtCatalog.ucMandatory = true;
            this.mtxtCatalog.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtCatalog.ucTextArea = false;
            this.mtxtCatalog.ucTextReadOnly = false;
            this.mtxtCatalog.ucValue = "";
            // 
            // mtxtIP
            // 
            this.mtxtIP.Dock = System.Windows.Forms.DockStyle.Top;
            this.mtxtIP.Location = new System.Drawing.Point(3, 21);
            this.mtxtIP.Margin = new System.Windows.Forms.Padding(5);
            this.mtxtIP.Name = "mtxtIP";
            this.mtxtIP.Size = new System.Drawing.Size(315, 30);
            this.mtxtIP.TabIndex = 0;
            this.mtxtIP.ucLabelText = "IP";
            this.mtxtIP.ucMandatory = true;
            this.mtxtIP.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtIP.ucTextArea = false;
            this.mtxtIP.ucTextReadOnly = false;
            this.mtxtIP.ucValue = "";
            // 
            // pnlHide
            // 
            this.pnlHide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHide.Controls.Add(this.mtxtAdmin);
            this.pnlHide.Location = new System.Drawing.Point(-5, -5);
            this.pnlHide.Name = "pnlHide";
            this.pnlHide.Size = new System.Drawing.Size(328, 156);
            this.pnlHide.TabIndex = 4;
            // 
            // mtxtAdmin
            // 
            this.mtxtAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtAdmin.Location = new System.Drawing.Point(46, 56);
            this.mtxtAdmin.Name = "mtxtAdmin";
            this.mtxtAdmin.Size = new System.Drawing.Size(247, 30);
            this.mtxtAdmin.TabIndex = 0;
            this.mtxtAdmin.ucLabelText = "비밀번호입력";
            this.mtxtAdmin.ucMandatory = false;
            this.mtxtAdmin.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtAdmin.ucTextArea = false;
            this.mtxtAdmin.ucTextReadOnly = false;
            this.mtxtAdmin.ucValue = "";
            this.mtxtAdmin.maskTextBoxKeyDownEvent += new System.EventHandler(this.MtxtAdmin_maskTextBoxKeyDownEvent);
            // 
            // DBConnSettingPop
            // 
            this.Caption = "DB세팅";
            this.ClientSize = new System.Drawing.Size(441, 188);
            this.Controls.Add(this.panel1);
            this.Name = "DBConnSettingPop";
            this.Text = "DBConnSettingPop";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnlHide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.MaskTextBox mtxtPW;
        private UserControls.MaskTextBox mtxtID;
        private UserControls.MaskTextBox mtxtCatalog;
        private UserControls.MaskTextBox mtxtIP;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlHide;
        private UserControls.MaskTextBox mtxtAdmin;
    }
}