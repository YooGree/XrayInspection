namespace MaskManager.UserControls
{
    partial class MaskCodeHelper
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
            this.btnHelper = new System.Windows.Forms.Button();
            this.lblMandatory = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnHelper);
            this.pnlMain.Controls.Add(this.lblMandatory);
            this.pnlMain.Controls.Add(this.txtText);
            this.pnlMain.Controls.Add(this.lblText);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(247, 30);
            this.pnlMain.TabIndex = 4;
            // 
            // btnHelper
            // 
            this.btnHelper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelper.BackColor = System.Drawing.Color.Transparent;
            this.btnHelper.BackgroundImage = global::MaskManager.Properties.Resources.search;
            this.btnHelper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelper.FlatAppearance.BorderSize = 0;
            this.btnHelper.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHelper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelper.Location = new System.Drawing.Point(218, 2);
            this.btnHelper.Name = "btnHelper";
            this.btnHelper.Size = new System.Drawing.Size(25, 21);
            this.btnHelper.TabIndex = 8;
            this.btnHelper.UseVisualStyleBackColor = false;
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
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtText.Location = new System.Drawing.Point(129, 1);
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(115, 27);
            this.txtText.TabIndex = 4;
            this.txtText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtText_KeyDown);
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblText.Location = new System.Drawing.Point(12, 4);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(111, 22);
            this.lblText.TabIndex = 3;
            this.lblText.Text = "TEXT";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaskCodeHelper
            // 
            this.Controls.Add(this.pnlMain);
            this.Name = "MaskCodeHelper";
            this.Size = new System.Drawing.Size(247, 30);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblMandatory;
        public System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnHelper;
    }
}
