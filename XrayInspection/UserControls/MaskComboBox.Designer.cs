namespace XrayInspection.UserControls
{
    partial class MaskComboBox
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
            this.cboCombo = new System.Windows.Forms.ComboBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblMandatory = new System.Windows.Forms.Label();
            this.txtReadOnly = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtReadOnly);
            this.pnlMain.Controls.Add(this.cboCombo);
            this.pnlMain.Controls.Add(this.lblText);
            this.pnlMain.Controls.Add(this.lblMandatory);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(247, 30);
            this.pnlMain.TabIndex = 7;
            // 
            // cboCombo
            // 
            this.cboCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCombo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboCombo.FormattingEnabled = true;
            this.cboCombo.Location = new System.Drawing.Point(129, 1);
            this.cboCombo.MinimumSize = new System.Drawing.Size(115, 0);
            this.cboCombo.Name = "cboCombo";
            this.cboCombo.Size = new System.Drawing.Size(118, 28);
            this.cboCombo.TabIndex = 8;
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblText.Location = new System.Drawing.Point(12, 3);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(111, 22);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "lblText";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMandatory
            // 
            this.lblMandatory.ForeColor = System.Drawing.Color.Red;
            this.lblMandatory.Location = new System.Drawing.Point(0, 2);
            this.lblMandatory.Name = "lblMandatory";
            this.lblMandatory.Size = new System.Drawing.Size(12, 22);
            this.lblMandatory.TabIndex = 6;
            this.lblMandatory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReadOnly
            // 
            this.txtReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReadOnly.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtReadOnly.Location = new System.Drawing.Point(129, 1);
            this.txtReadOnly.Name = "txtReadOnly";
            this.txtReadOnly.ReadOnly = true;
            this.txtReadOnly.Size = new System.Drawing.Size(118, 27);
            this.txtReadOnly.TabIndex = 9;
            this.txtReadOnly.Visible = false;
            // 
            // MaskComboBox
            // 
            this.Controls.Add(this.pnlMain);
            this.Name = "MaskComboBox";
            this.Size = new System.Drawing.Size(247, 30);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        public System.Windows.Forms.ComboBox cboCombo;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblMandatory;
        private System.Windows.Forms.TextBox txtReadOnly;
    }
}
