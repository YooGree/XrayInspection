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
            this.btnMini = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lblTitle.Size = new System.Drawing.Size(384, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TITLE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Location = new System.Drawing.Point(258, 50);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(27, 30);
            this.btnMini.TabIndex = 2;
            this.btnMini.TabStop = false;
            this.btnMini.Text = "--";
            this.btnMini.UseVisualStyleBackColor = false;
            // 
            // ParentsPop
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(384, 270);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ParentsPop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ParentsPop";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMini;
    }
}