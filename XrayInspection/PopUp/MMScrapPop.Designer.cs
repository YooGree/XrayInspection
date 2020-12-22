namespace XrayInspection.PopUp
{
    partial class MMScrapPop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MMScrapPop));
            this.txtUseDate = new XrayInspection.UserControls.MaskTextBox();
            this.txtTotUse = new XrayInspection.UserControls.MaskTextBox();
            this.txtRackId = new XrayInspection.UserControls.MaskTextBox();
            this.txtName = new XrayInspection.UserControls.MaskTextBox();
            this.txtNumber = new XrayInspection.UserControls.MaskTextBox();
            this.gbScrap = new System.Windows.Forms.GroupBox();
            this.txtDescript = new XrayInspection.UserControls.MaskTextBox();
            this.txtComment = new XrayInspection.UserControls.MaskTextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbScrap.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(349, 30);
            this.lblTitle.Text = "폐기";
            // 
            // txtUseDate
            // 
            this.txtUseDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtUseDate.Location = new System.Drawing.Point(6, 123);
            this.txtUseDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUseDate.Name = "txtUseDate";
            this.txtUseDate.Size = new System.Drawing.Size(312, 40);
            this.txtUseDate.TabIndex = 4;
            this.txtUseDate.ucLabelText = "최종 사용일";
            this.txtUseDate.ucMandatory = false;
            this.txtUseDate.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUseDate.ucTextArea = false;
            this.txtUseDate.ucTextReadOnly = true;
            this.txtUseDate.ucValue = "";
            // 
            // txtTotUse
            // 
            this.txtTotUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTotUse.Location = new System.Drawing.Point(6, 172);
            this.txtTotUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotUse.Name = "txtTotUse";
            this.txtTotUse.Size = new System.Drawing.Size(312, 40);
            this.txtTotUse.TabIndex = 3;
            this.txtTotUse.ucLabelText = "총 사용횟수";
            this.txtTotUse.ucMandatory = false;
            this.txtTotUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotUse.ucTextArea = false;
            this.txtTotUse.ucTextReadOnly = true;
            this.txtTotUse.ucValue = "";
            // 
            // txtRackId
            // 
            this.txtRackId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRackId.Location = new System.Drawing.Point(6, 220);
            this.txtRackId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRackId.Name = "txtRackId";
            this.txtRackId.Size = new System.Drawing.Size(312, 40);
            this.txtRackId.TabIndex = 2;
            this.txtRackId.ucLabelText = "보관함 번호";
            this.txtRackId.ucMandatory = false;
            this.txtRackId.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRackId.ucTextArea = false;
            this.txtRackId.ucTextReadOnly = true;
            this.txtRackId.ucValue = "";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(6, 75);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(312, 40);
            this.txtName.TabIndex = 1;
            this.txtName.ucLabelText = "모델명";
            this.txtName.ucMandatory = false;
            this.txtName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.ucTextArea = false;
            this.txtName.ucTextReadOnly = true;
            this.txtName.ucValue = "";
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNumber.Location = new System.Drawing.Point(6, 27);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(312, 40);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.ucLabelText = "Mask 일련번호";
            this.txtNumber.ucMandatory = true;
            this.txtNumber.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNumber.ucTextArea = false;
            this.txtNumber.ucTextReadOnly = false;
            this.txtNumber.ucValue = "";
            // 
            // gbScrap
            // 
            this.gbScrap.Controls.Add(this.txtDescript);
            this.gbScrap.Controls.Add(this.txtComment);
            this.gbScrap.Controls.Add(this.txtRackId);
            this.gbScrap.Controls.Add(this.txtNumber);
            this.gbScrap.Controls.Add(this.txtName);
            this.gbScrap.Controls.Add(this.txtTotUse);
            this.gbScrap.Controls.Add(this.txtUseDate);
            this.gbScrap.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbScrap.Location = new System.Drawing.Point(12, 92);
            this.gbScrap.Name = "gbScrap";
            this.gbScrap.Size = new System.Drawing.Size(324, 470);
            this.gbScrap.TabIndex = 8;
            this.gbScrap.TabStop = false;
            // 
            // txtDescript
            // 
            this.txtDescript.Location = new System.Drawing.Point(6, 267);
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.Size = new System.Drawing.Size(312, 63);
            this.txtDescript.TabIndex = 6;
            this.txtDescript.ucLabelText = "Mask 사양정보";
            this.txtDescript.ucMandatory = false;
            this.txtDescript.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescript.ucTextArea = true;
            this.txtDescript.ucTextReadOnly = true;
            this.txtDescript.ucValue = "";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(6, 337);
            this.txtComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(312, 63);
            this.txtComment.TabIndex = 5;
            this.txtComment.ucLabelText = "폐기 사유";
            this.txtComment.ucMandatory = false;
            this.txtComment.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtComment.ucTextArea = true;
            this.txtComment.ucTextReadOnly = false;
            this.txtComment.ucValue = "";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.SlateGray;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnNew.FlatAppearance.BorderSize = 4;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(18, 55);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 35);
            this.btnNew.TabIndex = 27;
            this.btnNew.Text = "신규";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SlateGray;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnSave.FlatAppearance.BorderSize = 4;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Image = global::XrayInspection.Properties.Resources.save_white;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(104, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "     저장";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SlateGray;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnClose.FlatAppearance.BorderSize = 4;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(250, 55);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "     닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // MMScrapPop
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Caption = "폐기";
            this.ClientSize = new System.Drawing.Size(349, 574);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.gbScrap);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MMScrapPop";
            this.Text = "폐기";
            this.Controls.SetChildIndex(this.gbScrap, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.gbScrap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.MaskTextBox txtNumber;
        private UserControls.MaskTextBox txtName;
        private UserControls.MaskTextBox txtRackId;
        private UserControls.MaskTextBox txtTotUse;
        private UserControls.MaskTextBox txtUseDate;
        private System.Windows.Forms.GroupBox gbScrap;
        private UserControls.MaskTextBox txtComment;
        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnClose;
        private UserControls.MaskTextBox txtDescript;
    }
}