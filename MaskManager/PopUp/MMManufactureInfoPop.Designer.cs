namespace MaskManager.PopUp
{
    partial class MMManufactureInfoPop
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
            this.txt_EqpName = new MaskManager.UserControls.MaskTextBox();
            this.txt_EqpId = new MaskManager.UserControls.MaskTextBox();
            this.txt_Inputdate = new MaskManager.UserControls.MaskTextBox();
            this.txt_ProdName = new MaskManager.UserControls.MaskTextBox();
            this.txt_NowUse = new MaskManager.UserControls.MaskTextBox();
            this.txt_Rack = new MaskManager.UserControls.MaskTextBox();
            this.txt_LimitUse = new MaskManager.UserControls.MaskTextBox();
            this.txt_IncomeInsp = new MaskManager.UserControls.MaskTextBox();
            this.txt_TotUse = new MaskManager.UserControls.MaskTextBox();
            this.txt_CleanInsp = new MaskManager.UserControls.MaskTextBox();
            this.txt_RecentDate = new MaskManager.UserControls.MaskTextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_ProdId = new MaskManager.UserControls.MaskTextBox();
            this.txt_MaskNum = new MaskManager.UserControls.MaskTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Comment = new MaskManager.UserControls.MaskTextBox();
            this.txt_MaskProdInfo = new MaskManager.UserControls.MaskTextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(717, 30);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_EqpName);
            this.panel1.Controls.Add(this.txt_EqpId);
            this.panel1.Controls.Add(this.txt_Inputdate);
            this.panel1.Controls.Add(this.txt_ProdName);
            this.panel1.Controls.Add(this.txt_NowUse);
            this.panel1.Controls.Add(this.txt_Rack);
            this.panel1.Controls.Add(this.txt_LimitUse);
            this.panel1.Controls.Add(this.txt_IncomeInsp);
            this.panel1.Controls.Add(this.txt_TotUse);
            this.panel1.Controls.Add(this.txt_CleanInsp);
            this.panel1.Controls.Add(this.txt_RecentDate);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.txt_ProdId);
            this.panel1.Controls.Add(this.txt_MaskNum);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 596);
            this.panel1.TabIndex = 9;
            // 
            // txt_EqpName
            // 
            this.txt_EqpName.Location = new System.Drawing.Point(29, 113);
            this.txt_EqpName.Name = "txt_EqpName";
            this.txt_EqpName.Size = new System.Drawing.Size(300, 30);
            this.txt_EqpName.TabIndex = 40;
            this.txt_EqpName.ucLabelText = "설비명";
            this.txt_EqpName.ucMandatory = true;
            this.txt_EqpName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_EqpName.ucTextArea = false;
            this.txt_EqpName.ucTextReadOnly = true;
            this.txt_EqpName.ucValue = "";
            // 
            // txt_EqpId
            // 
            this.txt_EqpId.Location = new System.Drawing.Point(29, 77);
            this.txt_EqpId.Name = "txt_EqpId";
            this.txt_EqpId.Size = new System.Drawing.Size(300, 30);
            this.txt_EqpId.TabIndex = 39;
            this.txt_EqpId.ucLabelText = "설비 코드";
            this.txt_EqpId.ucMandatory = true;
            this.txt_EqpId.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_EqpId.ucTextArea = false;
            this.txt_EqpId.ucTextReadOnly = false;
            this.txt_EqpId.ucValue = "";
            // 
            // txt_Inputdate
            // 
            this.txt_Inputdate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Inputdate.Location = new System.Drawing.Point(360, 304);
            this.txt_Inputdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Inputdate.Name = "txt_Inputdate";
            this.txt_Inputdate.Size = new System.Drawing.Size(311, 30);
            this.txt_Inputdate.TabIndex = 37;
            this.txt_Inputdate.ucLabelText = "입고일자";
            this.txt_Inputdate.ucMandatory = false;
            this.txt_Inputdate.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Inputdate.ucTextArea = false;
            this.txt_Inputdate.ucTextReadOnly = true;
            this.txt_Inputdate.ucValue = "";
            // 
            // txt_ProdName
            // 
            this.txt_ProdName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ProdName.Location = new System.Drawing.Point(361, 152);
            this.txt_ProdName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_ProdName.Name = "txt_ProdName";
            this.txt_ProdName.Size = new System.Drawing.Size(311, 30);
            this.txt_ProdName.TabIndex = 38;
            this.txt_ProdName.ucLabelText = "모델명";
            this.txt_ProdName.ucMandatory = true;
            this.txt_ProdName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_ProdName.ucTextArea = false;
            this.txt_ProdName.ucTextReadOnly = true;
            this.txt_ProdName.ucValue = "";
            // 
            // txt_NowUse
            // 
            this.txt_NowUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_NowUse.Location = new System.Drawing.Point(360, 456);
            this.txt_NowUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_NowUse.Name = "txt_NowUse";
            this.txt_NowUse.Size = new System.Drawing.Size(311, 30);
            this.txt_NowUse.TabIndex = 34;
            this.txt_NowUse.ucLabelText = "사용횟수";
            this.txt_NowUse.ucMandatory = true;
            this.txt_NowUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_NowUse.ucTextArea = false;
            this.txt_NowUse.ucTextReadOnly = false;
            this.txt_NowUse.ucValue = "";
            // 
            // txt_Rack
            // 
            this.txt_Rack.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Rack.Location = new System.Drawing.Point(360, 190);
            this.txt_Rack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Rack.Name = "txt_Rack";
            this.txt_Rack.Size = new System.Drawing.Size(311, 30);
            this.txt_Rack.TabIndex = 31;
            this.txt_Rack.ucLabelText = "보관함 위치";
            this.txt_Rack.ucMandatory = true;
            this.txt_Rack.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Rack.ucTextArea = false;
            this.txt_Rack.ucTextReadOnly = true;
            this.txt_Rack.ucValue = "";
            // 
            // txt_LimitUse
            // 
            this.txt_LimitUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_LimitUse.Location = new System.Drawing.Point(360, 380);
            this.txt_LimitUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_LimitUse.Name = "txt_LimitUse";
            this.txt_LimitUse.Size = new System.Drawing.Size(311, 30);
            this.txt_LimitUse.TabIndex = 33;
            this.txt_LimitUse.ucLabelText = "한계사용횟수";
            this.txt_LimitUse.ucMandatory = false;
            this.txt_LimitUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_LimitUse.ucTextArea = false;
            this.txt_LimitUse.ucTextReadOnly = true;
            this.txt_LimitUse.ucValue = "";
            // 
            // txt_IncomeInsp
            // 
            this.txt_IncomeInsp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_IncomeInsp.Location = new System.Drawing.Point(360, 228);
            this.txt_IncomeInsp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_IncomeInsp.Name = "txt_IncomeInsp";
            this.txt_IncomeInsp.Size = new System.Drawing.Size(311, 30);
            this.txt_IncomeInsp.TabIndex = 32;
            this.txt_IncomeInsp.ucLabelText = "수입검사결과";
            this.txt_IncomeInsp.ucMandatory = true;
            this.txt_IncomeInsp.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_IncomeInsp.ucTextArea = false;
            this.txt_IncomeInsp.ucTextReadOnly = true;
            this.txt_IncomeInsp.ucValue = "";
            // 
            // txt_TotUse
            // 
            this.txt_TotUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_TotUse.Location = new System.Drawing.Point(360, 418);
            this.txt_TotUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_TotUse.Name = "txt_TotUse";
            this.txt_TotUse.Size = new System.Drawing.Size(311, 30);
            this.txt_TotUse.TabIndex = 30;
            this.txt_TotUse.ucLabelText = "누적 사용횟수";
            this.txt_TotUse.ucMandatory = false;
            this.txt_TotUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_TotUse.ucTextArea = false;
            this.txt_TotUse.ucTextReadOnly = true;
            this.txt_TotUse.ucValue = "";
            // 
            // txt_CleanInsp
            // 
            this.txt_CleanInsp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_CleanInsp.Location = new System.Drawing.Point(360, 266);
            this.txt_CleanInsp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_CleanInsp.Name = "txt_CleanInsp";
            this.txt_CleanInsp.Size = new System.Drawing.Size(311, 30);
            this.txt_CleanInsp.TabIndex = 35;
            this.txt_CleanInsp.ucLabelText = "세척검사결과";
            this.txt_CleanInsp.ucMandatory = false;
            this.txt_CleanInsp.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_CleanInsp.ucTextArea = false;
            this.txt_CleanInsp.ucTextReadOnly = true;
            this.txt_CleanInsp.ucValue = "";
            // 
            // txt_RecentDate
            // 
            this.txt_RecentDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_RecentDate.Location = new System.Drawing.Point(360, 342);
            this.txt_RecentDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_RecentDate.Name = "txt_RecentDate";
            this.txt_RecentDate.Size = new System.Drawing.Size(311, 30);
            this.txt_RecentDate.TabIndex = 29;
            this.txt_RecentDate.ucLabelText = "최종사용일자";
            this.txt_RecentDate.ucMandatory = false;
            this.txt_RecentDate.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_RecentDate.ucTextArea = false;
            this.txt_RecentDate.ucTextReadOnly = true;
            this.txt_RecentDate.ucValue = "";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Close.Image = global::MaskManager.Properties.Resources.close;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(614, 18);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 35);
            this.btn_Close.TabIndex = 26;
            this.btn_Close.Text = "     닫기";
            this.btn_Close.UseVisualStyleBackColor = false;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Save.Image = global::MaskManager.Properties.Resources.save_white;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(105, 18);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(80, 35);
            this.btn_Save.TabIndex = 19;
            this.btn_Save.Text = "     저장";
            this.btn_Save.UseVisualStyleBackColor = false;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(24, 18);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 35);
            this.btn_Add.TabIndex = 18;
            this.btn_Add.Text = "신규";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // txt_ProdId
            // 
            this.txt_ProdId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ProdId.Location = new System.Drawing.Point(361, 112);
            this.txt_ProdId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_ProdId.Name = "txt_ProdId";
            this.txt_ProdId.Size = new System.Drawing.Size(311, 30);
            this.txt_ProdId.TabIndex = 10;
            this.txt_ProdId.ucLabelText = "모델코드";
            this.txt_ProdId.ucMandatory = true;
            this.txt_ProdId.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_ProdId.ucTextArea = false;
            this.txt_ProdId.ucTextReadOnly = true;
            this.txt_ProdId.ucValue = "";
            // 
            // txt_MaskNum
            // 
            this.txt_MaskNum.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_MaskNum.Location = new System.Drawing.Point(361, 77);
            this.txt_MaskNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaskNum.Name = "txt_MaskNum";
            this.txt_MaskNum.Size = new System.Drawing.Size(311, 30);
            this.txt_MaskNum.TabIndex = 9;
            this.txt_MaskNum.ucLabelText = "Mask 일련번호";
            this.txt_MaskNum.ucMandatory = true;
            this.txt_MaskNum.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MaskNum.ucTextArea = false;
            this.txt_MaskNum.ucTextReadOnly = false;
            this.txt_MaskNum.ucValue = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_MaskProdInfo);
            this.groupBox1.Controls.Add(this.txt_Comment);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(24, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 526);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // txt_Comment
            // 
            this.txt_Comment.Location = new System.Drawing.Point(337, 440);
            this.txt_Comment.Name = "txt_Comment";
            this.txt_Comment.Size = new System.Drawing.Size(311, 67);
            this.txt_Comment.TabIndex = 27;
            this.txt_Comment.ucLabelText = "특이사항";
            this.txt_Comment.ucMandatory = false;
            this.txt_Comment.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Comment.ucTextArea = true;
            this.txt_Comment.ucTextReadOnly = false;
            this.txt_Comment.ucValue = "";
            // 
            // txt_MaskProdInfo
            // 
            this.txt_MaskProdInfo.Location = new System.Drawing.Point(5, 440);
            this.txt_MaskProdInfo.Name = "txt_MaskProdInfo";
            this.txt_MaskProdInfo.Size = new System.Drawing.Size(300, 67);
            this.txt_MaskProdInfo.TabIndex = 28;
            this.txt_MaskProdInfo.ucLabelText = "Mask 사양정보";
            this.txt_MaskProdInfo.ucMandatory = false;
            this.txt_MaskProdInfo.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MaskProdInfo.ucTextArea = true;
            this.txt_MaskProdInfo.ucTextReadOnly = true;
            this.txt_MaskProdInfo.ucValue = "";
            // 
            // MMManufactureInfoPop
            // 
            this.ClientSize = new System.Drawing.Size(717, 627);
            this.Controls.Add(this.panel1);
            this.Name = "MMManufactureInfoPop";
            this.Text = "MMManufactureInfoPop";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UserControls.MaskTextBox txt_ProdId;
        private UserControls.MaskTextBox txt_MaskNum;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Close;
        private UserControls.MaskTextBox txt_Inputdate;
        private UserControls.MaskTextBox txt_ProdName;
        private UserControls.MaskTextBox txt_NowUse;
        private UserControls.MaskTextBox txt_Rack;
        private UserControls.MaskTextBox txt_LimitUse;
        private UserControls.MaskTextBox txt_IncomeInsp;
        private UserControls.MaskTextBox txt_TotUse;
        private UserControls.MaskTextBox txt_CleanInsp;
        private UserControls.MaskTextBox txt_RecentDate;
        private UserControls.MaskTextBox txt_Comment;
        private UserControls.MaskTextBox txt_EqpName;
        private UserControls.MaskTextBox txt_EqpId;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.MaskTextBox txt_MaskProdInfo;
    }
}