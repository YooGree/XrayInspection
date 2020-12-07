using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager.TabPages
{
    public class TabPageControl : UserControl
    {
        public GroupBox groupBox1;
        public Button btnNew;
        public Button btnSave;
        public Button btnCopy;
        public GroupBox groupBox2;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabPageControl));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(336, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 406);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "목록";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Location = new System.Drawing.Point(3, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 406);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상세정보";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.SlateGray;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnNew.FlatAppearance.BorderSize = 4;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(3, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 35);
            this.btnNew.TabIndex = 19;
            this.btnNew.Text = "신규";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SlateGray;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnSave.FlatAppearance.BorderSize = 4;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(175, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "     저장";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.SlateGray;
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnCopy.FlatAppearance.BorderSize = 4;
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopy.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(89, 5);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(80, 35);
            this.btnCopy.TabIndex = 20;
            this.btnCopy.Text = "복사";
            this.btnCopy.UseVisualStyleBackColor = false;
            // 
            // TabPageControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TabPageControl";
            this.Size = new System.Drawing.Size(880, 460);
            this.ResumeLayout(false);

        }
        public TabPageControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }
    }
}
