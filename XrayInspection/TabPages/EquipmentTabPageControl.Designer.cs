using XrayInspection.UserControls;

namespace XrayInspection.TabPages
{
    partial class EquipmentTabPageControl
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
            this.txtEquipId = new XrayInspection.UserControls.MaskTextBox();
            this.txtEquipName = new XrayInspection.UserControls.MaskTextBox();
            this.cbbUseYn = new XrayInspection.UserControls.MaskComboBox();
            this.txtComment = new XrayInspection.UserControls.MaskTextBox();
            this.dtgEquipList = new XrayInspection.UserControls.CustomDataGridViewControl();
            this.cbbEquipmentType = new XrayInspection.UserControls.MaskComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEquipList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbEquipmentType);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.cbbUseYn);
            this.groupBox1.Controls.Add(this.txtEquipName);
            this.groupBox1.Controls.Add(this.txtEquipId);
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
            this.groupBox2.Controls.Add(this.dtgEquipList);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Size = new System.Drawing.Size(935, 624);
            // 
            // txtEquipId
            // 
            this.txtEquipId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtEquipId.Location = new System.Drawing.Point(6, 59);
            this.txtEquipId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEquipId.Name = "txtEquipId";
            this.txtEquipId.Size = new System.Drawing.Size(315, 30);
            this.txtEquipId.TabIndex = 1;
            this.txtEquipId.ucLabelText = "설비코드";
            this.txtEquipId.ucMandatory = true;
            this.txtEquipId.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEquipId.ucTextArea = false;
            this.txtEquipId.ucTextReadOnly = false;
            this.txtEquipId.ucValue = "";
            // 
            // txtEquipName
            // 
            this.txtEquipName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtEquipName.Location = new System.Drawing.Point(6, 95);
            this.txtEquipName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEquipName.Name = "txtEquipName";
            this.txtEquipName.Size = new System.Drawing.Size(315, 30);
            this.txtEquipName.TabIndex = 2;
            this.txtEquipName.ucLabelText = "설비명";
            this.txtEquipName.ucMandatory = true;
            this.txtEquipName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEquipName.ucTextArea = false;
            this.txtEquipName.ucTextReadOnly = false;
            this.txtEquipName.ucValue = "";
            // 
            // cbbUseYn
            // 
            this.cbbUseYn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbbUseYn.Location = new System.Drawing.Point(6, 131);
            this.cbbUseYn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbUseYn.Name = "cbbUseYn";
            this.cbbUseYn.Size = new System.Drawing.Size(315, 30);
            this.cbbUseYn.TabIndex = 7;
            this.cbbUseYn.ucComboBoxDataSource = null;
            this.cbbUseYn.ucComboBoxDisplayMember = "";
            this.cbbUseYn.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUseYn.ucComboBoxValueMember = "";
            this.cbbUseYn.ucComboEnabled = true;
            this.cbbUseYn.ucComboIndex = -1;
            this.cbbUseYn.ucLabelText = "사용여부";
            this.cbbUseYn.ucMandatory = false;
            this.cbbUseYn.ucReadOnly = false;
            this.cbbUseYn.ucText = "";
            this.cbbUseYn.ucValue = null;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(6, 167);
            this.txtComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComment.MinimumSize = new System.Drawing.Size(0, 85);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(315, 109);
            this.txtComment.TabIndex = 3;
            this.txtComment.ucLabelText = "특이사항";
            this.txtComment.ucMandatory = false;
            this.txtComment.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtComment.ucTextArea = true;
            this.txtComment.ucTextReadOnly = false;
            this.txtComment.ucValue = "";
            // 
            // dtgEquipList
            // 
            this.dtgEquipList.AllowUserToAddRows = false;
            this.dtgEquipList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dtgEquipList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEquipList.BackgroundColor = System.Drawing.Color.White;
            this.dtgEquipList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgEquipList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEquipList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgEquipList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgEquipList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgEquipList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEquipList.EnableHeadersVisualStyles = false;
            this.dtgEquipList.Location = new System.Drawing.Point(3, 23);
            this.dtgEquipList.Name = "dtgEquipList";
            this.dtgEquipList.ReadOnly = true;
            this.dtgEquipList.RowTemplate.Height = 27;
            this.dtgEquipList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEquipList.Size = new System.Drawing.Size(929, 598);
            this.dtgEquipList.TabIndex = 13;
            // 
            // cbbEquipmentType
            // 
            this.cbbEquipmentType.Location = new System.Drawing.Point(6, 23);
            this.cbbEquipmentType.Name = "cbbEquipmentType";
            this.cbbEquipmentType.Size = new System.Drawing.Size(315, 30);
            this.cbbEquipmentType.TabIndex = 8;
            this.cbbEquipmentType.ucComboBoxDataSource = null;
            this.cbbEquipmentType.ucComboBoxDisplayMember = "";
            this.cbbEquipmentType.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEquipmentType.ucComboBoxValueMember = "";
            this.cbbEquipmentType.ucComboEnabled = true;
            this.cbbEquipmentType.ucComboIndex = -1;
            this.cbbEquipmentType.ucLabelText = "설비유형";
            this.cbbEquipmentType.ucMandatory = true;
            this.cbbEquipmentType.ucReadOnly = false;
            this.cbbEquipmentType.ucText = "";
            this.cbbEquipmentType.ucValue = null;
            // 
            // EquipmentTabPageControl
            // 
            this.Name = "EquipmentTabPageControl";
            this.Size = new System.Drawing.Size(1274, 674);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEquipList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.MaskTextBox txtComment;
        private UserControls.MaskComboBox cbbUseYn;
        private UserControls.MaskTextBox txtEquipName;
        private UserControls.MaskTextBox txtEquipId;
        private CustomDataGridViewControl dtgEquipList;
        private MaskComboBox cbbEquipmentType;
    }
}
