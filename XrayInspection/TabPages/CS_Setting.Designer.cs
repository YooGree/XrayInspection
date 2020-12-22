using XrayInspection.UserControls;

namespace XrayInspection.TabPages
{
    partial class CS_Setting
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbxSetting = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maskCodeHelper3 = new XrayInspection.UserControls.MaskCodeHelper();
            this.maskCodeHelper4 = new XrayInspection.UserControls.MaskCodeHelper();
            this.maskTextBox1 = new XrayInspection.UserControls.MaskTextBox();
            this.maskTextBox4 = new XrayInspection.UserControls.MaskTextBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbxSetting.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbxSetting, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1074, 627);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(214, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(860, 50);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(777, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 34);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 3);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 44);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "환경설정";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxSetting
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.gbxSetting, 2);
            this.gbxSetting.Controls.Add(this.panel2);
            this.gbxSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSetting.ForeColor = System.Drawing.Color.White;
            this.gbxSetting.Location = new System.Drawing.Point(3, 53);
            this.gbxSetting.Name = "gbxSetting";
            this.gbxSetting.Size = new System.Drawing.Size(1068, 571);
            this.gbxSetting.TabIndex = 8;
            this.gbxSetting.TabStop = false;
            this.gbxSetting.Text = "영상 및 이미지 저장정보";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.maskCodeHelper3);
            this.panel2.Controls.Add(this.maskCodeHelper4);
            this.panel2.Controls.Add(this.maskTextBox1);
            this.panel2.Controls.Add(this.maskTextBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1062, 551);
            this.panel2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(131, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "* AI 판정을 위한 초당 Frame 수입니다. (변경불가)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(131, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(316, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "* AI 판정 서버 정보입니다. (변경불가)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(131, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(316, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "* AI 판정을 위한 Frame의 이미지 저장 위치입니다.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(131, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(316, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "* X-RAY 동영상 저장 위치입니다.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maskCodeHelper3
            // 
            this.maskCodeHelper3.Location = new System.Drawing.Point(3, 110);
            this.maskCodeHelper3.Name = "maskCodeHelper3";
            this.maskCodeHelper3.Size = new System.Drawing.Size(600, 26);
            this.maskCodeHelper3.TabIndex = 5;
            this.maskCodeHelper3.ucHelperType = XrayInspection.UserControls.MaskCodeHelper.HelperType.NONE;
            this.maskCodeHelper3.ucLabelText = "이미지 저장 위치";
            this.maskCodeHelper3.ucMandatory = true;
            this.maskCodeHelper3.ucReadOnly = false;
            this.maskCodeHelper3.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskCodeHelper3.ucTextReadOnly = true;
            this.maskCodeHelper3.ucValue = "";
            // 
            // maskCodeHelper4
            // 
            this.maskCodeHelper4.Location = new System.Drawing.Point(3, 36);
            this.maskCodeHelper4.Name = "maskCodeHelper4";
            this.maskCodeHelper4.Size = new System.Drawing.Size(600, 26);
            this.maskCodeHelper4.TabIndex = 4;
            this.maskCodeHelper4.ucHelperType = XrayInspection.UserControls.MaskCodeHelper.HelperType.NONE;
            this.maskCodeHelper4.ucLabelText = "영상 저장 위치";
            this.maskCodeHelper4.ucMandatory = true;
            this.maskCodeHelper4.ucReadOnly = false;
            this.maskCodeHelper4.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskCodeHelper4.ucTextReadOnly = true;
            this.maskCodeHelper4.ucValue = "";
            // 
            // maskTextBox1
            // 
            this.maskTextBox1.Location = new System.Drawing.Point(3, 264);
            this.maskTextBox1.Name = "maskTextBox1";
            this.maskTextBox1.Size = new System.Drawing.Size(600, 26);
            this.maskTextBox1.TabIndex = 2;
            this.maskTextBox1.ucLabelText = "AI 서버 연결정보";
            this.maskTextBox1.ucMandatory = false;
            this.maskTextBox1.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskTextBox1.ucTextArea = false;
            this.maskTextBox1.ucTextReadOnly = true;
            this.maskTextBox1.ucValue = "";
            // 
            // maskTextBox4
            // 
            this.maskTextBox4.Location = new System.Drawing.Point(3, 187);
            this.maskTextBox4.Name = "maskTextBox4";
            this.maskTextBox4.Size = new System.Drawing.Size(600, 26);
            this.maskTextBox4.TabIndex = 1;
            this.maskTextBox4.ucLabelText = "초당 Frame 수";
            this.maskTextBox4.ucMandatory = false;
            this.maskTextBox4.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.maskTextBox4.ucTextArea = false;
            this.maskTextBox4.ucTextReadOnly = true;
            this.maskTextBox4.ucValue = "";
            // 
            // CS_Setting
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "CS_Setting";
            this.Size = new System.Drawing.Size(1074, 627);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbxSetting.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private MaskCodeHelper maskCodeHelper3;
        private MaskCodeHelper maskCodeHelper4;
        private MaskTextBox maskTextBox1;
        private MaskTextBox maskTextBox4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbxSetting;
    }
}
