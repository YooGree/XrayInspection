using System;

namespace XrayInspection.PopUp
{
    partial class MMWorkeUserChange
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
            this.cboShift = new XrayInspection.UserControls.MaskComboBox();
            this.cboWorker = new XrayInspection.UserControls.MaskComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(319, 30);
            this.lblTitle.Text = "작업자 변경";
            // 
            // lblFooter
            // 
            this.lblFooter.Size = new System.Drawing.Size(319, 30);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboShift);
            this.panel1.Controls.Add(this.cboWorker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 128);
            this.panel1.TabIndex = 3;
            // 
            // cboShift
            // 
            this.cboShift.ForeColor = System.Drawing.Color.White;
            this.cboShift.Location = new System.Drawing.Point(26, 27);
            this.cboShift.Name = "cboShift";
            this.cboShift.Size = new System.Drawing.Size(247, 30);
            this.cboShift.TabIndex = 4;
            this.cboShift.ucComboBoxDataSource = null;
            this.cboShift.ucComboBoxDisplayMember = "";
            this.cboShift.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboShift.ucComboBoxValueMember = "";
            this.cboShift.ucComboEnabled = true;
            this.cboShift.ucComboIndex = -1;
            this.cboShift.ucLabelText = "근무조";
            this.cboShift.ucMandatory = false;
            this.cboShift.ucReadOnly = false;
            this.cboShift.ucText = "";
            this.cboShift.ucValue = null;
            // 
            // cboWorker
            // 
            this.cboWorker.ForeColor = System.Drawing.Color.White;
            this.cboWorker.Location = new System.Drawing.Point(26, 72);
            this.cboWorker.Name = "cboWorker";
            this.cboWorker.Size = new System.Drawing.Size(247, 30);
            this.cboWorker.TabIndex = 3;
            this.cboWorker.ucComboBoxDataSource = null;
            this.cboWorker.ucComboBoxDisplayMember = "";
            this.cboWorker.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboWorker.ucComboBoxValueMember = "";
            this.cboWorker.ucComboEnabled = true;
            this.cboWorker.ucComboIndex = -1;
            this.cboWorker.ucLabelText = "작업자";
            this.cboWorker.ucMandatory = false;
            this.cboWorker.ucReadOnly = false;
            this.cboWorker.ucText = "";
            this.cboWorker.ucValue = null;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(219, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(122, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(319, 184);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 137);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(313, 44);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // MMWorkeUserChange
            // 
            this.Caption = "작업자 변경";
            this.ClientSize = new System.Drawing.Size(319, 244);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MMWorkeUserChange";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbox_1;
        private System.Windows.Forms.Panel MaskCleanPanel;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Close;
        private UserControls.MaskComboBox mcbmRack;
        private UserControls.MaskTextBox txt_MaskProdInfo;
        private UserControls.MaskTextBox txt_EqpName;
        private UserControls.MaskTextBox txt_EqpId;
        private UserControls.MaskTextBox txt_Comment;
        private UserControls.MaskTextBox txt_Date;
        private UserControls.MaskTextBox txt_UseQty;
        private UserControls.MaskTextBox txt_MaskProdName;
        private UserControls.MaskTextBox txt_Rack;
        private UserControls.MaskTextBox txt_TotUse;
        private UserControls.MaskComboBox cmb_InspResult;
        private UserControls.MaskTextBox txt_MaskProd;
        private UserControls.MaskTextBox txt_MaskNum;
        private UserControls.MaskTextBox mtxt_rack;
        private System.Windows.Forms.Panel panel1;
        private UserControls.MaskComboBox cboWorker;
        private UserControls.MaskComboBox cboShift;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}