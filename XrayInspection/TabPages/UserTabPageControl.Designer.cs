using XrayInspection.UserControls;

namespace XrayInspection.TabPages
{
    partial class UserTabPageControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mtxtUserID = new XrayInspection.UserControls.MaskTextBox();
            this.mtxtUserName = new XrayInspection.UserControls.MaskTextBox();
            this.mtxtEmail = new XrayInspection.UserControls.MaskTextBox();
            this.mcmbUseYN = new XrayInspection.UserControls.MaskComboBox();
            this.mtxtComment = new XrayInspection.UserControls.MaskTextBox();
            this.dtgUser = new XrayInspection.UserControls.CustomDataGridViewControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxtComment);
            this.groupBox1.Controls.Add(this.mcmbUseYN);
            this.groupBox1.Controls.Add(this.mtxtEmail);
            this.groupBox1.Controls.Add(this.mtxtUserName);
            this.groupBox1.Controls.Add(this.mtxtUserID);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Size = new System.Drawing.Size(327, 674);
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnNew.FlatAppearance.BorderSize = 4;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnNew.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnSave.FlatAppearance.BorderSize = 4;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            // 
            // btnCopy
            // 
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnCopy.FlatAppearance.BorderSize = 4;
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgUser);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Size = new System.Drawing.Size(1274, 674);
            // 
            // mtxtUserID
            // 
            this.mtxtUserID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mtxtUserID.Location = new System.Drawing.Point(6, 21);
            this.mtxtUserID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxtUserID.Name = "mtxtUserID";
            this.mtxtUserID.Size = new System.Drawing.Size(315, 30);
            this.mtxtUserID.TabIndex = 0;
            this.mtxtUserID.ucLabelText = "사번";
            this.mtxtUserID.ucMandatory = true;
            this.mtxtUserID.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtUserID.ucTextArea = false;
            this.mtxtUserID.ucTextReadOnly = false;
            this.mtxtUserID.ucValue = "";
            // 
            // mtxtUserName
            // 
            this.mtxtUserName.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.mtxtUserName.Location = new System.Drawing.Point(6, 56);
            this.mtxtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxtUserName.Name = "mtxtUserName";
            this.mtxtUserName.Size = new System.Drawing.Size(315, 30);
            this.mtxtUserName.TabIndex = 1;
            this.mtxtUserName.ucLabelText = "이름";
            this.mtxtUserName.ucMandatory = true;
            this.mtxtUserName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtUserName.ucTextArea = false;
            this.mtxtUserName.ucTextReadOnly = false;
            this.mtxtUserName.ucValue = "";
            // 
            // mtxtEmail
            // 
            this.mtxtEmail.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.mtxtEmail.Location = new System.Drawing.Point(6, 92);
            this.mtxtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxtEmail.Name = "mtxtEmail";
            this.mtxtEmail.Size = new System.Drawing.Size(315, 30);
            this.mtxtEmail.TabIndex = 2;
            this.mtxtEmail.ucLabelText = "EMAIL";
            this.mtxtEmail.ucMandatory = false;
            this.mtxtEmail.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtEmail.ucTextArea = false;
            this.mtxtEmail.ucTextReadOnly = false;
            this.mtxtEmail.ucValue = "";
            // 
            // mcmbUseYN
            // 
            this.mcmbUseYN.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.mcmbUseYN.Location = new System.Drawing.Point(6, 130);
            this.mcmbUseYN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mcmbUseYN.Name = "mcmbUseYN";
            this.mcmbUseYN.Size = new System.Drawing.Size(315, 30);
            this.mcmbUseYN.TabIndex = 3;
            this.mcmbUseYN.ucComboBoxDataSource = null;
            this.mcmbUseYN.ucComboBoxDisplayMember = "";
            this.mcmbUseYN.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcmbUseYN.ucComboBoxValueMember = "";
            this.mcmbUseYN.ucComboEnabled = true;
            this.mcmbUseYN.ucComboIndex = -1;
            this.mcmbUseYN.ucLabelText = "사용여부";
            this.mcmbUseYN.ucMandatory = false;
            this.mcmbUseYN.ucReadOnly = false;
            this.mcmbUseYN.ucText = "";
            this.mcmbUseYN.ucValue = null;
            // 
            // mtxtComment
            // 
            this.mtxtComment.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.mtxtComment.Location = new System.Drawing.Point(6, 168);
            this.mtxtComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtxtComment.Name = "mtxtComment";
            this.mtxtComment.Size = new System.Drawing.Size(315, 85);
            this.mtxtComment.TabIndex = 6;
            this.mtxtComment.ucLabelText = "특이사항";
            this.mtxtComment.ucMandatory = false;
            this.mtxtComment.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtComment.ucTextArea = true;
            this.mtxtComment.ucTextReadOnly = false;
            this.mtxtComment.ucValue = "";
            // 
            // dtgUser
            // 
            this.dtgUser.AllowUserToAddRows = false;
            this.dtgUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dtgUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgUser.BackgroundColor = System.Drawing.Color.White;
            this.dtgUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgUser.EnableHeadersVisualStyles = false;
            this.dtgUser.Location = new System.Drawing.Point(3, 23);
            this.dtgUser.Name = "dtgUser";
            this.dtgUser.ReadOnly = true;
            this.dtgUser.RowTemplate.Height = 27;
            this.dtgUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUser.Size = new System.Drawing.Size(1268, 648);
            this.dtgUser.TabIndex = 0;
            // 
            // UserTabPageControl
            // 
            this.Name = "UserTabPageControl";
            this.Size = new System.Drawing.Size(1274, 674);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.MaskTextBox mtxtUserID;
        private UserControls.MaskComboBox mcmbUseYN;
        private UserControls.MaskTextBox mtxtEmail;
        private UserControls.MaskTextBox mtxtUserName;
        private UserControls.MaskTextBox mtxtComment;
        private CustomDataGridViewControl dtgUser;
    }
}
