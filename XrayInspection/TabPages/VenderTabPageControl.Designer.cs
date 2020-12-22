using XrayInspection.UserControls;

namespace XrayInspection.TabPages
{
    partial class VenderTabPageControl
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
            this.dtgVenderList = new XrayInspection.UserControls.CustomDataGridViewControl();
            this.txtVenderID = new XrayInspection.UserControls.MaskTextBox();
            this.txtVenderName = new XrayInspection.UserControls.MaskTextBox();
            this.cbbUseYN = new XrayInspection.UserControls.MaskComboBox();
            this.txtComment = new XrayInspection.UserControls.MaskTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVenderList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.cbbUseYN);
            this.groupBox1.Controls.Add(this.txtVenderName);
            this.groupBox1.Controls.Add(this.txtVenderID);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Size = new System.Drawing.Size(327, 624);
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
            this.groupBox2.Controls.Add(this.dtgVenderList);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Size = new System.Drawing.Size(935, 624);
            // 
            // dtgVenderList
            // 
            this.dtgVenderList.AllowUserToAddRows = false;
            this.dtgVenderList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dtgVenderList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgVenderList.BackgroundColor = System.Drawing.Color.White;
            this.dtgVenderList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgVenderList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgVenderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgVenderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgVenderList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgVenderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgVenderList.EnableHeadersVisualStyles = false;
            this.dtgVenderList.Location = new System.Drawing.Point(3, 23);
            this.dtgVenderList.Name = "dtgVenderList";
            this.dtgVenderList.ReadOnly = true;
            this.dtgVenderList.RowTemplate.Height = 27;
            this.dtgVenderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVenderList.Size = new System.Drawing.Size(929, 598);
            this.dtgVenderList.TabIndex = 0;
            // 
            // txtVenderID
            // 
            this.txtVenderID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtVenderID.Location = new System.Drawing.Point(6, 21);
            this.txtVenderID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVenderID.Name = "txtVenderID";
            this.txtVenderID.Size = new System.Drawing.Size(315, 30);
            this.txtVenderID.TabIndex = 1;
            this.txtVenderID.ucLabelText = "업체코드";
            this.txtVenderID.ucMandatory = true;
            this.txtVenderID.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVenderID.ucTextArea = false;
            this.txtVenderID.ucTextReadOnly = false;
            this.txtVenderID.ucValue = "";
            // 
            // txtVenderName
            // 
            this.txtVenderName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtVenderName.Location = new System.Drawing.Point(6, 57);
            this.txtVenderName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVenderName.Name = "txtVenderName";
            this.txtVenderName.Size = new System.Drawing.Size(315, 30);
            this.txtVenderName.TabIndex = 2;
            this.txtVenderName.ucLabelText = "업체명";
            this.txtVenderName.ucMandatory = true;
            this.txtVenderName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVenderName.ucTextArea = false;
            this.txtVenderName.ucTextReadOnly = false;
            this.txtVenderName.ucValue = "";
            // 
            // cbbUseYN
            // 
            this.cbbUseYN.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbbUseYN.Location = new System.Drawing.Point(6, 93);
            this.cbbUseYN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbUseYN.Name = "cbbUseYN";
            this.cbbUseYN.Size = new System.Drawing.Size(315, 30);
            this.cbbUseYN.TabIndex = 3;
            this.cbbUseYN.ucComboBoxDataSource = null;
            this.cbbUseYN.ucComboBoxDisplayMember = "";
            this.cbbUseYN.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUseYN.ucComboBoxValueMember = "";
            this.cbbUseYN.ucComboEnabled = true;
            this.cbbUseYN.ucComboIndex = -1;
            this.cbbUseYN.ucLabelText = "사용여부";
            this.cbbUseYN.ucMandatory = false;
            this.cbbUseYN.ucReadOnly = false;
            this.cbbUseYN.ucText = "";
            this.cbbUseYN.ucValue = null;
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(6, 129);
            this.txtComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(315, 85);
            this.txtComment.TabIndex = 3;
            this.txtComment.ucLabelText = "특이사항";
            this.txtComment.ucMandatory = false;
            this.txtComment.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtComment.ucTextArea = true;
            this.txtComment.ucTextReadOnly = false;
            this.txtComment.ucValue = "";
            // 
            // VenderTabPageControl
            // 
            this.Name = "VenderTabPageControl";
            this.Size = new System.Drawing.Size(1274, 674);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVenderList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.MaskTextBox txtVenderName;
        private UserControls.MaskTextBox txtVenderID;
        private CustomDataGridViewControl dtgVenderList;
        private UserControls.MaskComboBox cbbUseYN;
        private UserControls.MaskTextBox txtComment;
    }
}
