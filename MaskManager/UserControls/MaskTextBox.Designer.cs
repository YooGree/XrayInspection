namespace MaskManager.UserControls
{
    partial class MaskTextBox
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblMandatory = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.lblMandatory);
            this.pnlMain.Controls.Add(this.lblText);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(247, 30);
            this.pnlMain.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtText);
            this.panel1.Location = new System.Drawing.Point(127, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 2);
            this.panel1.Size = new System.Drawing.Size(120, 30);
            this.panel1.TabIndex = 6;
            // 
            // txtText
            // 
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtText.Location = new System.Drawing.Point(2, 1);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(118, 27);
            this.txtText.TabIndex = 5;
            // 
            // lblMandatory
            // 
            this.lblMandatory.ForeColor = System.Drawing.Color.Red;
            this.lblMandatory.Location = new System.Drawing.Point(0, 1);
            this.lblMandatory.Name = "lblMandatory";
            this.lblMandatory.Size = new System.Drawing.Size(12, 22);
            this.lblMandatory.TabIndex = 5;
            this.lblMandatory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblText.Location = new System.Drawing.Point(12, 3);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(111, 22);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "TEXT";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaskTextBox
            // 
            this.Controls.Add(this.pnlMain);
            this.Name = "MaskTextBox";
            this.Size = new System.Drawing.Size(247, 30);
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblMandatory;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtText;
    }
}
