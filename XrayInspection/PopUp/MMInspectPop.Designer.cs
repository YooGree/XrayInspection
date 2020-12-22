using System;

namespace XrayInspection.PopUp
{
    partial class MMInspectPop
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
            this.grbox_1 = new System.Windows.Forms.GroupBox();
            this.mtxt_rack = new XrayInspection.UserControls.MaskTextBox();
            this.mcbmRack = new XrayInspection.UserControls.MaskComboBox();
            this.txt_MaskProdInfo = new XrayInspection.UserControls.MaskTextBox();
            this.txt_EqpName = new XrayInspection.UserControls.MaskTextBox();
            this.txt_EqpId = new XrayInspection.UserControls.MaskTextBox();
            this.txt_Comment = new XrayInspection.UserControls.MaskTextBox();
            this.txt_Date = new XrayInspection.UserControls.MaskTextBox();
            this.txt_UseQty = new XrayInspection.UserControls.MaskTextBox();
            this.txt_MaskProdName = new XrayInspection.UserControls.MaskTextBox();
            this.txt_Rack = new XrayInspection.UserControls.MaskTextBox();
            this.txt_TotUse = new XrayInspection.UserControls.MaskTextBox();
            this.cmb_InspResult = new XrayInspection.UserControls.MaskComboBox();
            this.txt_MaskProd = new XrayInspection.UserControls.MaskTextBox();
            this.txt_MaskNum = new XrayInspection.UserControls.MaskTextBox();
            this.MaskCleanPanel = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.grbox_1.SuspendLayout();
            this.MaskCleanPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(717, 30);
            // 
            // grbox_1
            // 
            this.grbox_1.Controls.Add(this.mtxt_rack);
            this.grbox_1.Controls.Add(this.mcbmRack);
            this.grbox_1.Controls.Add(this.txt_MaskProdInfo);
            this.grbox_1.Controls.Add(this.txt_EqpName);
            this.grbox_1.Controls.Add(this.txt_EqpId);
            this.grbox_1.Controls.Add(this.txt_Comment);
            this.grbox_1.Controls.Add(this.txt_Date);
            this.grbox_1.Controls.Add(this.txt_UseQty);
            this.grbox_1.Controls.Add(this.txt_MaskProdName);
            this.grbox_1.Controls.Add(this.txt_Rack);
            this.grbox_1.Controls.Add(this.txt_TotUse);
            this.grbox_1.Controls.Add(this.cmb_InspResult);
            this.grbox_1.Controls.Add(this.txt_MaskProd);
            this.grbox_1.Controls.Add(this.txt_MaskNum);
            this.grbox_1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grbox_1.Location = new System.Drawing.Point(24, 59);
            this.grbox_1.Name = "grbox_1";
            this.grbox_1.Size = new System.Drawing.Size(670, 400);
            this.grbox_1.TabIndex = 8;
            this.grbox_1.TabStop = false;
            // 
            // mtxt_rack
            // 
            this.mtxt_rack.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mtxt_rack.Location = new System.Drawing.Point(11, 130);
            this.mtxt_rack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxt_rack.Name = "mtxt_rack";
            this.mtxt_rack.Size = new System.Drawing.Size(300, 30);
            this.mtxt_rack.TabIndex = 58;
            this.mtxt_rack.ucLabelText = "보관함 위치";
            this.mtxt_rack.ucMandatory = true;
            this.mtxt_rack.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxt_rack.ucTextArea = false;
            this.mtxt_rack.ucTextReadOnly = true;
            this.mtxt_rack.ucValue = "";
            this.mtxt_rack.Visible = false;
            // 
            // mcbmRack
            // 
            this.mcbmRack.Location = new System.Drawing.Point(11, 93);
            this.mcbmRack.Name = "mcbmRack";
            this.mcbmRack.Size = new System.Drawing.Size(300, 30);
            this.mcbmRack.TabIndex = 57;
            this.mcbmRack.ucComboBoxDataSource = null;
            this.mcbmRack.ucComboBoxDisplayMember = "";
            this.mcbmRack.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.mcbmRack.ucComboBoxValueMember = "";
            this.mcbmRack.ucComboEnabled = true;
            this.mcbmRack.ucComboIndex = -1;
            this.mcbmRack.ucLabelText = "보관함 위치";
            this.mcbmRack.ucMandatory = false;
            this.mcbmRack.ucReadOnly = false;
            this.mcbmRack.ucText = "";
            this.mcbmRack.ucValue = null;
            // 
            // txt_MaskProdInfo
            // 
            this.txt_MaskProdInfo.Location = new System.Drawing.Point(11, 312);
            this.txt_MaskProdInfo.Name = "txt_MaskProdInfo";
            this.txt_MaskProdInfo.Size = new System.Drawing.Size(300, 67);
            this.txt_MaskProdInfo.TabIndex = 56;
            this.txt_MaskProdInfo.ucLabelText = "Mask 사양정보";
            this.txt_MaskProdInfo.ucMandatory = false;
            this.txt_MaskProdInfo.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MaskProdInfo.ucTextArea = true;
            this.txt_MaskProdInfo.ucTextReadOnly = true;
            this.txt_MaskProdInfo.ucValue = "";
            // 
            // txt_EqpName
            // 
            this.txt_EqpName.Location = new System.Drawing.Point(11, 58);
            this.txt_EqpName.Name = "txt_EqpName";
            this.txt_EqpName.Size = new System.Drawing.Size(300, 30);
            this.txt_EqpName.TabIndex = 55;
            this.txt_EqpName.ucLabelText = "설비명";
            this.txt_EqpName.ucMandatory = true;
            this.txt_EqpName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_EqpName.ucTextArea = false;
            this.txt_EqpName.ucTextReadOnly = true;
            this.txt_EqpName.ucValue = "";
            // 
            // txt_EqpId
            // 
            this.txt_EqpId.Location = new System.Drawing.Point(11, 22);
            this.txt_EqpId.Name = "txt_EqpId";
            this.txt_EqpId.Size = new System.Drawing.Size(300, 30);
            this.txt_EqpId.TabIndex = 54;
            this.txt_EqpId.ucLabelText = "설비 코드";
            this.txt_EqpId.ucMandatory = true;
            this.txt_EqpId.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_EqpId.ucTextArea = false;
            this.txt_EqpId.ucTextReadOnly = false;
            this.txt_EqpId.ucValue = "";
            // 
            // txt_Comment
            // 
            this.txt_Comment.Location = new System.Drawing.Point(349, 312);
            this.txt_Comment.Name = "txt_Comment";
            this.txt_Comment.Size = new System.Drawing.Size(311, 67);
            this.txt_Comment.TabIndex = 53;
            this.txt_Comment.ucLabelText = "특이사항";
            this.txt_Comment.ucMandatory = false;
            this.txt_Comment.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Comment.ucTextArea = true;
            this.txt_Comment.ucTextReadOnly = false;
            this.txt_Comment.ucValue = "";
            // 
            // txt_Date
            // 
            this.txt_Date.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Date.Location = new System.Drawing.Point(349, 131);
            this.txt_Date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Date.Name = "txt_Date";
            this.txt_Date.Size = new System.Drawing.Size(311, 30);
            this.txt_Date.TabIndex = 52;
            this.txt_Date.ucLabelText = "최근 사용 일자";
            this.txt_Date.ucMandatory = false;
            this.txt_Date.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Date.ucTextArea = false;
            this.txt_Date.ucTextReadOnly = true;
            this.txt_Date.ucValue = "";
            // 
            // txt_UseQty
            // 
            this.txt_UseQty.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_UseQty.Location = new System.Drawing.Point(349, 199);
            this.txt_UseQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_UseQty.Name = "txt_UseQty";
            this.txt_UseQty.Size = new System.Drawing.Size(311, 30);
            this.txt_UseQty.TabIndex = 51;
            this.txt_UseQty.ucLabelText = "사용 횟수";
            this.txt_UseQty.ucMandatory = false;
            this.txt_UseQty.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_UseQty.ucTextArea = false;
            this.txt_UseQty.ucTextReadOnly = true;
            this.txt_UseQty.ucValue = "";
            // 
            // txt_MaskProdName
            // 
            this.txt_MaskProdName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_MaskProdName.Location = new System.Drawing.Point(349, 93);
            this.txt_MaskProdName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaskProdName.Name = "txt_MaskProdName";
            this.txt_MaskProdName.Size = new System.Drawing.Size(311, 30);
            this.txt_MaskProdName.TabIndex = 50;
            this.txt_MaskProdName.ucLabelText = "모델명";
            this.txt_MaskProdName.ucMandatory = true;
            this.txt_MaskProdName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MaskProdName.ucTextArea = false;
            this.txt_MaskProdName.ucTextReadOnly = true;
            this.txt_MaskProdName.ucValue = "";
            // 
            // txt_Rack
            // 
            this.txt_Rack.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_Rack.Location = new System.Drawing.Point(349, 237);
            this.txt_Rack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Rack.Name = "txt_Rack";
            this.txt_Rack.Size = new System.Drawing.Size(311, 30);
            this.txt_Rack.TabIndex = 49;
            this.txt_Rack.ucLabelText = "보관함 위치";
            this.txt_Rack.ucMandatory = true;
            this.txt_Rack.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Rack.ucTextArea = false;
            this.txt_Rack.ucTextReadOnly = true;
            this.txt_Rack.ucValue = "";
            // 
            // txt_TotUse
            // 
            this.txt_TotUse.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_TotUse.Location = new System.Drawing.Point(349, 165);
            this.txt_TotUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_TotUse.Name = "txt_TotUse";
            this.txt_TotUse.Size = new System.Drawing.Size(311, 30);
            this.txt_TotUse.TabIndex = 48;
            this.txt_TotUse.ucLabelText = "누적 사용 횟수";
            this.txt_TotUse.ucMandatory = false;
            this.txt_TotUse.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_TotUse.ucTextArea = false;
            this.txt_TotUse.ucTextReadOnly = true;
            this.txt_TotUse.ucValue = "";
            // 
            // cmb_InspResult
            // 
            this.cmb_InspResult.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmb_InspResult.Location = new System.Drawing.Point(349, 275);
            this.cmb_InspResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_InspResult.Name = "cmb_InspResult";
            this.cmb_InspResult.Size = new System.Drawing.Size(311, 30);
            this.cmb_InspResult.TabIndex = 47;
            this.cmb_InspResult.ucComboBoxDataSource = null;
            this.cmb_InspResult.ucComboBoxDisplayMember = "";
            this.cmb_InspResult.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_InspResult.ucComboBoxValueMember = "";
            this.cmb_InspResult.ucComboEnabled = true;
            this.cmb_InspResult.ucComboIndex = -1;
            this.cmb_InspResult.ucLabelText = "세척검사 결과";
            this.cmb_InspResult.ucMandatory = true;
            this.cmb_InspResult.ucReadOnly = false;
            this.cmb_InspResult.ucText = "";
            this.cmb_InspResult.ucValue = null;
            // 
            // txt_MaskProd
            // 
            this.txt_MaskProd.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_MaskProd.Location = new System.Drawing.Point(349, 58);
            this.txt_MaskProd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaskProd.Name = "txt_MaskProd";
            this.txt_MaskProd.Size = new System.Drawing.Size(311, 30);
            this.txt_MaskProd.TabIndex = 46;
            this.txt_MaskProd.ucLabelText = "모델코드";
            this.txt_MaskProd.ucMandatory = true;
            this.txt_MaskProd.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MaskProd.ucTextArea = false;
            this.txt_MaskProd.ucTextReadOnly = true;
            this.txt_MaskProd.ucValue = "";
            // 
            // txt_MaskNum
            // 
            this.txt_MaskNum.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txt_MaskNum.Location = new System.Drawing.Point(349, 22);
            this.txt_MaskNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaskNum.Name = "txt_MaskNum";
            this.txt_MaskNum.Size = new System.Drawing.Size(311, 30);
            this.txt_MaskNum.TabIndex = 45;
            this.txt_MaskNum.ucLabelText = "Mask 일련번호";
            this.txt_MaskNum.ucMandatory = true;
            this.txt_MaskNum.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MaskNum.ucTextArea = false;
            this.txt_MaskNum.ucTextReadOnly = false;
            this.txt_MaskNum.ucValue = "";
            // 
            // MaskCleanPanel
            // 
            this.MaskCleanPanel.Controls.Add(this.btn_Close);
            this.MaskCleanPanel.Controls.Add(this.btn_Save);
            this.MaskCleanPanel.Controls.Add(this.btn_Add);
            this.MaskCleanPanel.Controls.Add(this.grbox_1);
            this.MaskCleanPanel.Location = new System.Drawing.Point(0, 30);
            this.MaskCleanPanel.Name = "MaskCleanPanel";
            this.MaskCleanPanel.Size = new System.Drawing.Size(717, 481);
            this.MaskCleanPanel.TabIndex = 11;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Close.Image = global::XrayInspection.Properties.Resources.close;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(614, 18);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 35);
            this.btn_Close.TabIndex = 22;
            this.btn_Close.Text = "     닫기";
            this.btn_Close.UseVisualStyleBackColor = false;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.SlateGray;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Save.Image = global::XrayInspection.Properties.Resources.save_white;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(105, 18);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(80, 35);
            this.btn_Save.TabIndex = 21;
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
            this.btn_Add.TabIndex = 20;
            this.btn_Add.Text = "신규";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // MMInspectPop
            // 
            this.ClientSize = new System.Drawing.Size(717, 512);
            this.Controls.Add(this.MaskCleanPanel);
            this.Name = "MMInspectPop";
            this.Text = "";
            this.Load += new System.EventHandler(this.MMInspectPop_Load);
            this.Controls.SetChildIndex(this.MaskCleanPanel, 0);
            this.grbox_1.ResumeLayout(false);
            this.MaskCleanPanel.ResumeLayout(false);
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
    }
}