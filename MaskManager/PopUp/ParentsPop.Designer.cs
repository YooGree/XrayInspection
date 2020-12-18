namespace MaskManager.PopUp
{
    partial class ParentsPop
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.panelLogo_Chosun = new System.Windows.Forms.Panel();
            this.panelLogo_MICube = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.Controls.Add(this.panelLogo_MICube);
            this.pnlHeader.Controls.Add(this.panelLogo_Chosun);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(384, 30);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lblTitle.Size = new System.Drawing.Size(384, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TITLE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelFooter.Controls.Add(this.lblFooter);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 240);
            this.panelFooter.Margin = new System.Windows.Forms.Padding(0);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(384, 30);
            this.panelFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooter.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFooter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFooter.Location = new System.Drawing.Point(0, 0);
            this.lblFooter.Margin = new System.Windows.Forms.Padding(3);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Padding = new System.Windows.Forms.Padding(3);
            this.lblFooter.Size = new System.Drawing.Size(384, 30);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "FOOTER";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelLogo_Chosun
            // 
            this.panelLogo_Chosun.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelLogo_Chosun.BackgroundImage = global::MaskManager.Properties.Resources.chosun_label;
            this.panelLogo_Chosun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogo_Chosun.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogo_Chosun.Location = new System.Drawing.Point(0, 0);
            this.panelLogo_Chosun.Name = "panelLogo_Chosun";
            this.panelLogo_Chosun.Size = new System.Drawing.Size(143, 30);
            this.panelLogo_Chosun.TabIndex = 3;
            this.panelLogo_Chosun.Visible = false;
            // 
            // panelLogo_MICube
            // 
            this.panelLogo_MICube.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panelLogo_MICube.BackgroundImage = global::MaskManager.Properties.Resources.mic;
            this.panelLogo_MICube.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogo_MICube.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLogo_MICube.Location = new System.Drawing.Point(220, 0);
            this.panelLogo_MICube.Name = "panelLogo_MICube";
            this.panelLogo_MICube.Size = new System.Drawing.Size(164, 30);
            this.panelLogo_MICube.TabIndex = 4;
            this.panelLogo_MICube.Visible = false;
            // 
            // ParentsPop
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(384, 270);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ParentsPop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ParentsPop";
            this.pnlHeader.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFooter;
        public System.Windows.Forms.Label lblFooter;
        protected System.Windows.Forms.Panel panelLogo_MICube;
        protected System.Windows.Forms.Panel panelLogo_Chosun;
    }
}