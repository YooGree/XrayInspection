namespace MaskManager.TabPages
{
    partial class MMStoredInfo
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
            this.tlpRack = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tlpRack
            // 
            this.tlpRack.AutoSize = true;
            this.tlpRack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpRack.ColumnCount = 2;
            this.tlpRack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRack.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpRack.Location = new System.Drawing.Point(0, 0);
            this.tlpRack.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRack.Name = "tlpRack";
            this.tlpRack.RowCount = 2;
            this.tlpRack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRack.Size = new System.Drawing.Size(0, 635);
            this.tlpRack.TabIndex = 0;
            // 
            // MMStoredInfo
            // 
            this.Controls.Add(this.tlpRack);
            this.Name = "MMStoredInfo";
            this.Size = new System.Drawing.Size(729, 635);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRack;
    }
}
