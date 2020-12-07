namespace MaskManager.UserControls
{
    partial class MaskDatePicker
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
            this.dtpDatePicker = new System.Windows.Forms.DateTimePicker();
            this.lblText = new System.Windows.Forms.Label();
            this.lblMandatory = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dtpDatePicker);
            this.pnlMain.Controls.Add(this.lblText);
            this.pnlMain.Controls.Add(this.lblMandatory);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(247, 30);
            this.pnlMain.TabIndex = 5;
            // 
            // dtpDatePicker
            // 
            this.dtpDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDatePicker.CustomFormat = "";
            this.dtpDatePicker.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatePicker.Location = new System.Drawing.Point(129, 1);
            this.dtpDatePicker.Name = "dtpDatePicker";
            this.dtpDatePicker.Size = new System.Drawing.Size(115, 27);
            this.dtpDatePicker.TabIndex = 6;
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblText.Location = new System.Drawing.Point(12, 3);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(111, 22);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "lblText";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMandatory
            // 
            this.lblMandatory.ForeColor = System.Drawing.Color.Red;
            this.lblMandatory.Location = new System.Drawing.Point(0, 1);
            this.lblMandatory.Name = "lblMandatory";
            this.lblMandatory.Size = new System.Drawing.Size(12, 22);
            this.lblMandatory.TabIndex = 4;
            this.lblMandatory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaskDatePicker
            // 
            this.Controls.Add(this.pnlMain);
            this.Name = "MaskDatePicker";
            this.Size = new System.Drawing.Size(247, 30);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        public System.Windows.Forms.DateTimePicker dtpDatePicker;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblMandatory;
    }
}
