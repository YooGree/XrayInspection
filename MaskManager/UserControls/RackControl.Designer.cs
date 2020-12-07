namespace MaskManager.UserControls
{
    partial class RackControl
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splRack = new System.Windows.Forms.SplitContainer();
            this.lblRackName = new System.Windows.Forms.Label();
            this.lblMaskName = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splRack)).BeginInit();
            this.splRack.Panel1.SuspendLayout();
            this.splRack.Panel2.SuspendLayout();
            this.splRack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = global::MaskManager.Properties.Resources.Rack_White_new;
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.splRack);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(150, 150);
            this.pnlMain.TabIndex = 0;
            // 
            // splRack
            // 
            this.splRack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splRack.IsSplitterFixed = true;
            this.splRack.Location = new System.Drawing.Point(0, 0);
            this.splRack.Margin = new System.Windows.Forms.Padding(0);
            this.splRack.Name = "splRack";
            this.splRack.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splRack.Panel1
            // 
            this.splRack.Panel1.Controls.Add(this.lblRackName);
            // 
            // splRack.Panel2
            // 
            this.splRack.Panel2.Controls.Add(this.lblMaskName);
            this.splRack.Size = new System.Drawing.Size(150, 150);
            this.splRack.SplitterDistance = 72;
            this.splRack.TabIndex = 0;
            // 
            // lblRackName
            // 
            this.lblRackName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRackName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRackName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblRackName.Location = new System.Drawing.Point(0, 0);
            this.lblRackName.Name = "lblRackName";
            this.lblRackName.Size = new System.Drawing.Size(150, 72);
            this.lblRackName.TabIndex = 0;
            this.lblRackName.Text = "Rack Name";
            this.lblRackName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaskName
            // 
            this.lblMaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaskName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMaskName.Location = new System.Drawing.Point(0, 0);
            this.lblMaskName.Name = "lblMaskName";
            this.lblMaskName.Size = new System.Drawing.Size(150, 74);
            this.lblMaskName.TabIndex = 0;
            this.lblMaskName.Text = "M/Mask Name";
            this.lblMaskName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RackControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlMain);
            this.Name = "RackControl";
            this.Resize += new System.EventHandler(this.RackControl_Resize);
            this.pnlMain.ResumeLayout(false);
            this.splRack.Panel1.ResumeLayout(false);
            this.splRack.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splRack)).EndInit();
            this.splRack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splRack;
        private System.Windows.Forms.Label lblRackName;
        private System.Windows.Forms.Label lblMaskName;
    }
}
