using XrayInspection.UserControls;

namespace XrayInspection.TabPages
{
    partial class DurableProdTabPageControl
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
            this.dtgDurableProd = new XrayInspection.UserControls.CustomDataGridViewControl();
            this.cbbUseYn = new XrayInspection.UserControls.MaskComboBox();
            this.txtComment = new XrayInspection.UserControls.MaskTextBox();
            this.txtWarningUseQTY = new XrayInspection.UserControls.MaskTextBox();
            this.txtLimitUseQTY = new XrayInspection.UserControls.MaskTextBox();
            this.txtMaskThick = new XrayInspection.UserControls.MaskTextBox();
            this.txtMaskSize = new XrayInspection.UserControls.MaskTextBox();
            this.txtProdName = new XrayInspection.UserControls.MaskTextBox();
            this.txtProdId = new XrayInspection.UserControls.MaskTextBox();
            this.txtVender = new XrayInspection.UserControls.MaskCodeHelper();
            this.txtDescript = new XrayInspection.UserControls.MaskTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDurableProd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescript);
            this.groupBox1.Controls.Add(this.txtVender);
            this.groupBox1.Controls.Add(this.cbbUseYn);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.txtWarningUseQTY);
            this.groupBox1.Controls.Add(this.txtLimitUseQTY);
            this.groupBox1.Controls.Add(this.txtMaskThick);
            this.groupBox1.Controls.Add(this.txtMaskSize);
            this.groupBox1.Controls.Add(this.txtProdName);
            this.groupBox1.Controls.Add(this.txtProdId);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Size = new System.Drawing.Size(327, 557);
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
            this.groupBox2.Controls.Add(this.dtgDurableProd);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Size = new System.Drawing.Size(847, 557);
            // 
            // dtgDurableProd
            // 
            this.dtgDurableProd.AllowUserToAddRows = false;
            this.dtgDurableProd.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dtgDurableProd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDurableProd.BackgroundColor = System.Drawing.Color.White;
            this.dtgDurableProd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDurableProd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDurableProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDurableProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDurableProd.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgDurableProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDurableProd.EnableHeadersVisualStyles = false;
            this.dtgDurableProd.Location = new System.Drawing.Point(3, 23);
            this.dtgDurableProd.Name = "dtgDurableProd";
            this.dtgDurableProd.ReadOnly = true;
            this.dtgDurableProd.RowTemplate.Height = 27;
            this.dtgDurableProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDurableProd.Size = new System.Drawing.Size(841, 531);
            this.dtgDurableProd.TabIndex = 2;
            // 
            // cbbUseYn
            // 
            this.cbbUseYn.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbbUseYn.Location = new System.Drawing.Point(6, 273);
            this.cbbUseYn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbUseYn.Name = "cbbUseYn";
            this.cbbUseYn.Size = new System.Drawing.Size(315, 30);
            this.cbbUseYn.TabIndex = 11;
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
            this.txtComment.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(6, 383);
            this.txtComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(315, 63);
            this.txtComment.TabIndex = 10;
            this.txtComment.ucLabelText = "특이사항";
            this.txtComment.ucMandatory = false;
            this.txtComment.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtComment.ucTextArea = true;
            this.txtComment.ucTextReadOnly = false;
            this.txtComment.ucValue = "";
            // 
            // txtWarningUseQTY
            // 
            this.txtWarningUseQTY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWarningUseQTY.Location = new System.Drawing.Point(6, 237);
            this.txtWarningUseQTY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarningUseQTY.Name = "txtWarningUseQTY";
            this.txtWarningUseQTY.Size = new System.Drawing.Size(315, 30);
            this.txtWarningUseQTY.TabIndex = 9;
            this.txtWarningUseQTY.ucLabelText = "사용 경고수량";
            this.txtWarningUseQTY.ucMandatory = true;
            this.txtWarningUseQTY.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWarningUseQTY.ucTextArea = false;
            this.txtWarningUseQTY.ucTextReadOnly = false;
            this.txtWarningUseQTY.ucValue = "";
            // 
            // txtLimitUseQTY
            // 
            this.txtLimitUseQTY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLimitUseQTY.Location = new System.Drawing.Point(6, 201);
            this.txtLimitUseQTY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLimitUseQTY.Name = "txtLimitUseQTY";
            this.txtLimitUseQTY.Size = new System.Drawing.Size(315, 30);
            this.txtLimitUseQTY.TabIndex = 8;
            this.txtLimitUseQTY.ucLabelText = "사용 한계수량";
            this.txtLimitUseQTY.ucMandatory = true;
            this.txtLimitUseQTY.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLimitUseQTY.ucTextArea = false;
            this.txtLimitUseQTY.ucTextReadOnly = false;
            this.txtLimitUseQTY.ucValue = "";
            // 
            // txtMaskThick
            // 
            this.txtMaskThick.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMaskThick.Location = new System.Drawing.Point(6, 165);
            this.txtMaskThick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaskThick.Name = "txtMaskThick";
            this.txtMaskThick.Size = new System.Drawing.Size(315, 30);
            this.txtMaskThick.TabIndex = 7;
            this.txtMaskThick.ucLabelText = "두께";
            this.txtMaskThick.ucMandatory = true;
            this.txtMaskThick.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaskThick.ucTextArea = false;
            this.txtMaskThick.ucTextReadOnly = false;
            this.txtMaskThick.ucValue = "";
            // 
            // txtMaskSize
            // 
            this.txtMaskSize.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMaskSize.Location = new System.Drawing.Point(6, 129);
            this.txtMaskSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaskSize.Name = "txtMaskSize";
            this.txtMaskSize.Size = new System.Drawing.Size(315, 30);
            this.txtMaskSize.TabIndex = 6;
            this.txtMaskSize.ucLabelText = "사이즈";
            this.txtMaskSize.ucMandatory = true;
            this.txtMaskSize.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaskSize.ucTextArea = false;
            this.txtMaskSize.ucTextReadOnly = false;
            this.txtMaskSize.ucValue = "";
            // 
            // txtProdName
            // 
            this.txtProdName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProdName.Location = new System.Drawing.Point(6, 57);
            this.txtProdName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(315, 30);
            this.txtProdName.TabIndex = 4;
            this.txtProdName.ucLabelText = "모델명";
            this.txtProdName.ucMandatory = true;
            this.txtProdName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtProdName.ucTextArea = false;
            this.txtProdName.ucTextReadOnly = false;
            this.txtProdName.ucValue = "";
            // 
            // txtProdId
            // 
            this.txtProdId.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProdId.Location = new System.Drawing.Point(6, 21);
            this.txtProdId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(315, 30);
            this.txtProdId.TabIndex = 3;
            this.txtProdId.ucLabelText = "모델코드";
            this.txtProdId.ucMandatory = true;
            this.txtProdId.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtProdId.ucTextArea = false;
            this.txtProdId.ucTextReadOnly = true;
            this.txtProdId.ucValue = "";
            // 
            // txtVender
            // 
            this.txtVender.Location = new System.Drawing.Point(6, 95);
            this.txtVender.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVender.Name = "txtVender";
            this.txtVender.Size = new System.Drawing.Size(315, 30);
            this.txtVender.TabIndex = 12;
            this.txtVender.ucHelperType = XrayInspection.UserControls.MaskCodeHelper.HelperType.VENDER;
            this.txtVender.ucLabelText = "업체";
            this.txtVender.ucMandatory = true;
            this.txtVender.ucReadOnly = false;
            this.txtVender.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVender.ucTextReadOnly = true;
            this.txtVender.ucValue = "";
            // 
            // txtDescript
            // 
            this.txtDescript.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDescript.Location = new System.Drawing.Point(6, 312);
            this.txtDescript.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.Size = new System.Drawing.Size(315, 63);
            this.txtDescript.TabIndex = 13;
            this.txtDescript.ucLabelText = "Mask 사양정보";
            this.txtDescript.ucMandatory = false;
            this.txtDescript.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescript.ucTextArea = true;
            this.txtDescript.ucTextReadOnly = false;
            this.txtDescript.ucValue = "";
            // 
            // DurableProdTabPageControl
            // 
            this.Name = "DurableProdTabPageControl";
            this.Size = new System.Drawing.Size(1186, 607);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDurableProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomDataGridViewControl dtgDurableProd;
        private UserControls.MaskTextBox txtComment;
        private UserControls.MaskTextBox txtWarningUseQTY;
        private UserControls.MaskTextBox txtLimitUseQTY;
        private UserControls.MaskTextBox txtMaskThick;
        private UserControls.MaskTextBox txtMaskSize;
        private UserControls.MaskTextBox txtProdName;
        private UserControls.MaskTextBox txtProdId;
        private UserControls.MaskComboBox cbbUseYn;
        private MaskCodeHelper txtVender;
        private MaskTextBox txtDescript;
    }
}
