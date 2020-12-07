namespace MaskManager.PopUp
{
    partial class MMManufactureInfoChange
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
            this.txt_NowUse = new MaskManager.UserControls.MaskTextBox();
            this.txt_Comment = new MaskManager.UserControls.MaskTextBox();
            this.txt_Inputdate = new MaskManager.UserControls.MaskTextBox();
            this.txt_MaskNum = new MaskManager.UserControls.MaskTextBox();
            this.txt_ChangeUse = new MaskManager.UserControls.MaskTextBox();
            this.txt_ProdName = new MaskManager.UserControls.MaskTextBox();
            this.txt_ProdId = new MaskManager.UserControls.MaskTextBox();
            this.txt_RecentDate = new MaskManager.UserControls.MaskTextBox();
            this.txt_Rack = new MaskManager.UserControls.MaskTextBox();
            this.txt_CleanInsp = new MaskManager.UserControls.MaskTextBox();
            this.txt_LimitUse = new MaskManager.UserControls.MaskTextBox();
            this.txt_TotUse = new MaskManager.UserControls.MaskTextBox();
            this.txt_IncomeInsp = new MaskManager.UserControls.MaskTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.txt_objectid = new MaskManager.UserControls.MaskTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(382, 30);
            // 
            // txt_NowUse
            // 
            this.txt_NowUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_NowUse.Location = new System.Drawing.Point(20, 347);
            this.txt_NowUse.Name = "txt_NowUse";
            this.txt_NowUse.Size = new System.Drawing.Size(278, 33);
            this.txt_NowUse.TabIndex = 58;
            this.txt_NowUse.ucLabelText = "입력 사용횟수";
            this.txt_NowUse.ucMandatory = true;
            this.txt_NowUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_NowUse.ucTextArea = false;
            this.txt_NowUse.ucTextReadOnly = true;
            this.txt_NowUse.ucValue = "";
            // 
            // txt_Comment
            // 
            this.txt_Comment.Location = new System.Drawing.Point(20, 412);
            this.txt_Comment.Name = "txt_Comment";
            this.txt_Comment.Size = new System.Drawing.Size(278, 52);
            this.txt_Comment.TabIndex = 48;
            this.txt_Comment.ucLabelText = "특이사항";
            this.txt_Comment.ucMandatory = false;
            this.txt_Comment.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Comment.ucTextArea = true;
            this.txt_Comment.ucTextReadOnly = false;
            this.txt_Comment.ucValue = "";
            // 
            // txt_Inputdate
            // 
            this.txt_Inputdate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Inputdate.Location = new System.Drawing.Point(20, 218);
            this.txt_Inputdate.Name = "txt_Inputdate";
            this.txt_Inputdate.Size = new System.Drawing.Size(278, 33);
            this.txt_Inputdate.TabIndex = 56;
            this.txt_Inputdate.ucLabelText = "입고일자";
            this.txt_Inputdate.ucMandatory = false;
            this.txt_Inputdate.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Inputdate.ucTextArea = false;
            this.txt_Inputdate.ucTextReadOnly = true;
            this.txt_Inputdate.ucValue = "";
            // 
            // txt_MaskNum
            // 
            this.txt_MaskNum.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_MaskNum.Location = new System.Drawing.Point(20, 23);
            this.txt_MaskNum.Name = "txt_MaskNum";
            this.txt_MaskNum.Size = new System.Drawing.Size(278, 33);
            this.txt_MaskNum.TabIndex = 46;
            this.txt_MaskNum.ucLabelText = "Mask 일련번호";
            this.txt_MaskNum.ucMandatory = true;
            this.txt_MaskNum.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MaskNum.ucTextArea = false;
            this.txt_MaskNum.ucTextReadOnly = false;
            this.txt_MaskNum.ucValue = "";
            // 
            // txt_ChangeUse
            // 
            this.txt_ChangeUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ChangeUse.Location = new System.Drawing.Point(20, 380);
            this.txt_ChangeUse.Name = "txt_ChangeUse";
            this.txt_ChangeUse.Size = new System.Drawing.Size(278, 33);
            this.txt_ChangeUse.TabIndex = 54;
            this.txt_ChangeUse.ucLabelText = "변경 사용횟수";
            this.txt_ChangeUse.ucMandatory = true;
            this.txt_ChangeUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ChangeUse.ucTextArea = false;
            this.txt_ChangeUse.ucTextReadOnly = false;
            this.txt_ChangeUse.ucValue = "";
            // 
            // txt_ProdName
            // 
            this.txt_ProdName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ProdName.Location = new System.Drawing.Point(20, 89);
            this.txt_ProdName.Name = "txt_ProdName";
            this.txt_ProdName.Size = new System.Drawing.Size(278, 33);
            this.txt_ProdName.TabIndex = 57;
            this.txt_ProdName.ucLabelText = "모델명";
            this.txt_ProdName.ucMandatory = true;
            this.txt_ProdName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_ProdName.ucTextArea = false;
            this.txt_ProdName.ucTextReadOnly = true;
            this.txt_ProdName.ucValue = "";
            // 
            // txt_ProdId
            // 
            this.txt_ProdId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_ProdId.Location = new System.Drawing.Point(20, 57);
            this.txt_ProdId.Name = "txt_ProdId";
            this.txt_ProdId.Size = new System.Drawing.Size(278, 33);
            this.txt_ProdId.TabIndex = 47;
            this.txt_ProdId.ucLabelText = "모델코드";
            this.txt_ProdId.ucMandatory = true;
            this.txt_ProdId.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_ProdId.ucTextArea = false;
            this.txt_ProdId.ucTextReadOnly = true;
            this.txt_ProdId.ucValue = "";
            // 
            // txt_RecentDate
            // 
            this.txt_RecentDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_RecentDate.Location = new System.Drawing.Point(20, 251);
            this.txt_RecentDate.Name = "txt_RecentDate";
            this.txt_RecentDate.Size = new System.Drawing.Size(278, 33);
            this.txt_RecentDate.TabIndex = 49;
            this.txt_RecentDate.ucLabelText = "최종사용일자";
            this.txt_RecentDate.ucMandatory = false;
            this.txt_RecentDate.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_RecentDate.ucTextArea = false;
            this.txt_RecentDate.ucTextReadOnly = true;
            this.txt_RecentDate.ucValue = "";
            // 
            // txt_Rack
            // 
            this.txt_Rack.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Rack.Location = new System.Drawing.Point(20, 121);
            this.txt_Rack.Name = "txt_Rack";
            this.txt_Rack.Size = new System.Drawing.Size(278, 33);
            this.txt_Rack.TabIndex = 51;
            this.txt_Rack.ucLabelText = "보관함 위치";
            this.txt_Rack.ucMandatory = true;
            this.txt_Rack.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Rack.ucTextArea = false;
            this.txt_Rack.ucTextReadOnly = true;
            this.txt_Rack.ucValue = "";
            // 
            // txt_CleanInsp
            // 
            this.txt_CleanInsp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_CleanInsp.Location = new System.Drawing.Point(19, 186);
            this.txt_CleanInsp.Name = "txt_CleanInsp";
            this.txt_CleanInsp.Size = new System.Drawing.Size(278, 33);
            this.txt_CleanInsp.TabIndex = 55;
            this.txt_CleanInsp.ucLabelText = "세척검사결과";
            this.txt_CleanInsp.ucMandatory = false;
            this.txt_CleanInsp.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_CleanInsp.ucTextArea = false;
            this.txt_CleanInsp.ucTextReadOnly = true;
            this.txt_CleanInsp.ucValue = "";
            // 
            // txt_LimitUse
            // 
            this.txt_LimitUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_LimitUse.Location = new System.Drawing.Point(20, 283);
            this.txt_LimitUse.Name = "txt_LimitUse";
            this.txt_LimitUse.Size = new System.Drawing.Size(278, 33);
            this.txt_LimitUse.TabIndex = 53;
            this.txt_LimitUse.ucLabelText = "한계사용횟수";
            this.txt_LimitUse.ucMandatory = false;
            this.txt_LimitUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_LimitUse.ucTextArea = false;
            this.txt_LimitUse.ucTextReadOnly = true;
            this.txt_LimitUse.ucValue = "";
            // 
            // txt_TotUse
            // 
            this.txt_TotUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_TotUse.Location = new System.Drawing.Point(20, 315);
            this.txt_TotUse.Name = "txt_TotUse";
            this.txt_TotUse.Size = new System.Drawing.Size(278, 33);
            this.txt_TotUse.TabIndex = 50;
            this.txt_TotUse.ucLabelText = "누적 사용횟수";
            this.txt_TotUse.ucMandatory = false;
            this.txt_TotUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_TotUse.ucTextArea = false;
            this.txt_TotUse.ucTextReadOnly = true;
            this.txt_TotUse.ucValue = "";
            // 
            // txt_IncomeInsp
            // 
            this.txt_IncomeInsp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_IncomeInsp.Location = new System.Drawing.Point(20, 154);
            this.txt_IncomeInsp.Name = "txt_IncomeInsp";
            this.txt_IncomeInsp.Size = new System.Drawing.Size(278, 33);
            this.txt_IncomeInsp.TabIndex = 52;
            this.txt_IncomeInsp.ucLabelText = "수입검사결과";
            this.txt_IncomeInsp.ucMandatory = true;
            this.txt_IncomeInsp.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_IncomeInsp.ucTextArea = false;
            this.txt_IncomeInsp.ucTextReadOnly = true;
            this.txt_IncomeInsp.ucValue = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_objectid);
            this.groupBox1.Controls.Add(this.txt_MaskNum);
            this.groupBox1.Controls.Add(this.txt_ProdId);
            this.groupBox1.Controls.Add(this.txt_IncomeInsp);
            this.groupBox1.Controls.Add(this.txt_Comment);
            this.groupBox1.Controls.Add(this.txt_NowUse);
            this.groupBox1.Controls.Add(this.txt_TotUse);
            this.groupBox1.Controls.Add(this.txt_LimitUse);
            this.groupBox1.Controls.Add(this.txt_Inputdate);
            this.groupBox1.Controls.Add(this.txt_CleanInsp);
            this.groupBox1.Controls.Add(this.txt_ChangeUse);
            this.groupBox1.Controls.Add(this.txt_Rack);
            this.groupBox1.Controls.Add(this.txt_ProdName);
            this.groupBox1.Controls.Add(this.txt_RecentDate);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(29, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 475);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Close.Image = global::MaskManager.Properties.Resources.close;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(274, 48);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 35);
            this.btn_Close.TabIndex = 61;
            this.btn_Close.Text = "     닫기";
            this.btn_Close.UseVisualStyleBackColor = false;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Save.Image = global::MaskManager.Properties.Resources.save_white;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(110, 48);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(80, 35);
            this.btn_Save.TabIndex = 60;
            this.btn_Save.Text = "     저장";
            this.btn_Save.UseVisualStyleBackColor = false;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(29, 48);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 35);
            this.btn_Add.TabIndex = 59;
            this.btn_Add.Text = "신규";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // txt_objectid
            // 
            this.txt_objectid.Location = new System.Drawing.Point(284, 38);
            this.txt_objectid.Name = "txt_objectid";
            this.txt_objectid.Size = new System.Drawing.Size(12, 9);
            this.txt_objectid.TabIndex = 62;
            this.txt_objectid.ucLabelText = "TEXT";
            this.txt_objectid.ucMandatory = false;
            this.txt_objectid.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_objectid.ucTextArea = false;
            this.txt_objectid.ucTextReadOnly = false;
            this.txt_objectid.ucValue = "";
            this.txt_objectid.Visible = false;
            // 
            // MMManufactureInfoChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 579);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "MMManufactureInfoChange";
            this.Text = "MMManufactureInfoChange";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btn_Add, 0);
            this.Controls.SetChildIndex(this.btn_Save, 0);
            this.Controls.SetChildIndex(this.btn_Close, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.MaskTextBox txt_NowUse;
        private UserControls.MaskTextBox txt_Comment;
        private UserControls.MaskTextBox txt_Inputdate;
        private UserControls.MaskTextBox txt_MaskNum;
        private UserControls.MaskTextBox txt_ChangeUse;
        private UserControls.MaskTextBox txt_ProdName;
        private UserControls.MaskTextBox txt_ProdId;
        private UserControls.MaskTextBox txt_RecentDate;
        private UserControls.MaskTextBox txt_Rack;
        private UserControls.MaskTextBox txt_CleanInsp;
        private UserControls.MaskTextBox txt_LimitUse;
        private UserControls.MaskTextBox txt_TotUse;
        private UserControls.MaskTextBox txt_IncomeInsp;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btn_Close;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Add;
        private UserControls.MaskTextBox txt_objectid;
    }
}