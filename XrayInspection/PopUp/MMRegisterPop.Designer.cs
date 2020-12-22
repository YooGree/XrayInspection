using XrayInspection.UserControls;

namespace XrayInspection.PopUp
{
    partial class MMRegisterPop
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MMRegisterPop));
            this.gbLeft = new System.Windows.Forms.GroupBox();
            this.txtCreateDate = new System.Windows.Forms.TextBox();
            this.mtxtVenderName = new XrayInspection.UserControls.MaskTextBox();
            this.mtxtCode = new XrayInspection.UserControls.MaskTextBox();
            this.mtxtID = new XrayInspection.UserControls.MaskTextBox();
            this.mtxtName = new XrayInspection.UserControls.MaskTextBox();
            this.mtxtVenderCode = new XrayInspection.UserControls.MaskTextBox();
            this.mtxtDesc = new XrayInspection.UserControls.MaskTextBox();
            this.mtxtCreator = new XrayInspection.UserControls.MaskTextBox();
            this.mdtpCreateDate = new XrayInspection.UserControls.MaskDatePicker();
            this.mtxtRack = new XrayInspection.UserControls.MaskTextBox();
            this.mcbmRack = new XrayInspection.UserControls.MaskComboBox();
            this.mtxtInputResult = new XrayInspection.UserControls.MaskTextBox();
            this.mcbmbInputResult = new XrayInspection.UserControls.MaskComboBox();
            this.mcmbModelCode = new XrayInspection.UserControls.MaskComboBox();
            this.gbRight = new System.Windows.Forms.GroupBox();
            this.dtgMain = new XrayInspection.UserControls.CustomDataGridViewControl();
            this.dURABLEIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dURABLEPRODUCTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dURABLEPRODUCTNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vENDERIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vENDERNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rACKIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNPUTRESULTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNPUTRESULTNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATEDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cREATORNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPTIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mCDURABLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbLeft.SuspendLayout();
            this.gbRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCDURABLEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(1236, 30);
            this.lblTitle.Text = "신규 등록";
            // 
            // gbLeft
            // 
            this.gbLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbLeft.Controls.Add(this.txtCreateDate);
            this.gbLeft.Controls.Add(this.mtxtVenderName);
            this.gbLeft.Controls.Add(this.mtxtCode);
            this.gbLeft.Controls.Add(this.mtxtID);
            this.gbLeft.Controls.Add(this.mtxtName);
            this.gbLeft.Controls.Add(this.mtxtVenderCode);
            this.gbLeft.Controls.Add(this.mtxtDesc);
            this.gbLeft.Controls.Add(this.mtxtCreator);
            this.gbLeft.Controls.Add(this.mdtpCreateDate);
            this.gbLeft.Controls.Add(this.mtxtRack);
            this.gbLeft.Controls.Add(this.mcbmRack);
            this.gbLeft.Controls.Add(this.mtxtInputResult);
            this.gbLeft.Controls.Add(this.mcbmbInputResult);
            this.gbLeft.Controls.Add(this.mcmbModelCode);
            this.gbLeft.Location = new System.Drawing.Point(12, 81);
            this.gbLeft.Name = "gbLeft";
            this.gbLeft.Size = new System.Drawing.Size(327, 460);
            this.gbLeft.TabIndex = 0;
            this.gbLeft.TabStop = false;
            this.gbLeft.Text = "신규 정보 입력";
            // 
            // txtCreateDate
            // 
            this.txtCreateDate.Location = new System.Drawing.Point(149, 276);
            this.txtCreateDate.Multiline = true;
            this.txtCreateDate.Name = "txtCreateDate";
            this.txtCreateDate.ReadOnly = true;
            this.txtCreateDate.Size = new System.Drawing.Size(121, 27);
            this.txtCreateDate.TabIndex = 6;
            this.txtCreateDate.Text = "2019-04-26";
            // 
            // mtxtVenderName
            // 
            this.mtxtVenderName.Location = new System.Drawing.Point(20, 170);
            this.mtxtVenderName.Name = "mtxtVenderName";
            this.mtxtVenderName.Size = new System.Drawing.Size(290, 30);
            this.mtxtVenderName.TabIndex = 3;
            this.mtxtVenderName.ucLabelText = "제작업체 명";
            this.mtxtVenderName.ucMandatory = false;
            this.mtxtVenderName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtVenderName.ucTextArea = false;
            this.mtxtVenderName.ucTextReadOnly = true;
            this.mtxtVenderName.ucValue = "";
            // 
            // mtxtCode
            // 
            this.mtxtCode.Location = new System.Drawing.Point(20, 64);
            this.mtxtCode.Name = "mtxtCode";
            this.mtxtCode.Size = new System.Drawing.Size(290, 30);
            this.mtxtCode.TabIndex = 0;
            this.mtxtCode.ucLabelText = "모델 코드";
            this.mtxtCode.ucMandatory = true;
            this.mtxtCode.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtCode.ucTextArea = false;
            this.mtxtCode.ucTextReadOnly = true;
            this.mtxtCode.ucValue = "";
            // 
            // mtxtID
            // 
            this.mtxtID.Location = new System.Drawing.Point(20, 30);
            this.mtxtID.Name = "mtxtID";
            this.mtxtID.Size = new System.Drawing.Size(290, 30);
            this.mtxtID.TabIndex = 2;
            this.mtxtID.ucLabelText = "Mask 일련번호";
            this.mtxtID.ucMandatory = false;
            this.mtxtID.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtID.ucTextArea = false;
            this.mtxtID.ucTextReadOnly = true;
            this.mtxtID.ucValue = "";
            // 
            // mtxtName
            // 
            this.mtxtName.Location = new System.Drawing.Point(20, 100);
            this.mtxtName.Name = "mtxtName";
            this.mtxtName.Size = new System.Drawing.Size(290, 30);
            this.mtxtName.TabIndex = 1;
            this.mtxtName.ucLabelText = "모델명";
            this.mtxtName.ucMandatory = false;
            this.mtxtName.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtName.ucTextArea = false;
            this.mtxtName.ucTextReadOnly = true;
            this.mtxtName.ucValue = "";
            // 
            // mtxtVenderCode
            // 
            this.mtxtVenderCode.Location = new System.Drawing.Point(20, 135);
            this.mtxtVenderCode.Name = "mtxtVenderCode";
            this.mtxtVenderCode.Size = new System.Drawing.Size(290, 30);
            this.mtxtVenderCode.TabIndex = 2;
            this.mtxtVenderCode.ucLabelText = "제작업체 코드";
            this.mtxtVenderCode.ucMandatory = false;
            this.mtxtVenderCode.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtVenderCode.ucTextArea = false;
            this.mtxtVenderCode.ucTextReadOnly = true;
            this.mtxtVenderCode.ucValue = "";
            // 
            // mtxtDesc
            // 
            this.mtxtDesc.Location = new System.Drawing.Point(20, 345);
            this.mtxtDesc.Name = "mtxtDesc";
            this.mtxtDesc.Size = new System.Drawing.Size(290, 85);
            this.mtxtDesc.TabIndex = 8;
            this.mtxtDesc.ucLabelText = "Mask 사양정보";
            this.mtxtDesc.ucMandatory = false;
            this.mtxtDesc.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtDesc.ucTextArea = true;
            this.mtxtDesc.ucTextReadOnly = true;
            this.mtxtDesc.ucValue = "";
            // 
            // mtxtCreator
            // 
            this.mtxtCreator.Location = new System.Drawing.Point(20, 310);
            this.mtxtCreator.Name = "mtxtCreator";
            this.mtxtCreator.Size = new System.Drawing.Size(290, 30);
            this.mtxtCreator.TabIndex = 7;
            this.mtxtCreator.ucLabelText = "담당자";
            this.mtxtCreator.ucMandatory = false;
            this.mtxtCreator.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtCreator.ucTextArea = false;
            this.mtxtCreator.ucTextReadOnly = true;
            this.mtxtCreator.ucValue = "";
            // 
            // mdtpCreateDate
            // 
            this.mdtpCreateDate.Location = new System.Drawing.Point(20, 275);
            this.mdtpCreateDate.Name = "mdtpCreateDate";
            this.mdtpCreateDate.Size = new System.Drawing.Size(290, 35);
            this.mdtpCreateDate.TabIndex = 20;
            this.mdtpCreateDate.ucDatePickerCustomFormat = "";
            this.mdtpCreateDate.ucDatePickerEnabled = true;
            this.mdtpCreateDate.ucDatePickerFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mdtpCreateDate.ucLabelText = "입고일자";
            this.mdtpCreateDate.ucMandatory = true;
            this.mdtpCreateDate.ucTextBox = this.txtCreateDate;
            this.mdtpCreateDate.ucValue = new System.DateTime(2019, 4, 26, 15, 2, 1, 838);
            // 
            // mtxtRack
            // 
            this.mtxtRack.Location = new System.Drawing.Point(20, 205);
            this.mtxtRack.Name = "mtxtRack";
            this.mtxtRack.Size = new System.Drawing.Size(290, 30);
            this.mtxtRack.TabIndex = 4;
            this.mtxtRack.ucLabelText = "보관함 위치";
            this.mtxtRack.ucMandatory = false;
            this.mtxtRack.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtRack.ucTextArea = false;
            this.mtxtRack.ucTextReadOnly = true;
            this.mtxtRack.ucValue = "";
            // 
            // mcbmRack
            // 
            this.mcbmRack.Location = new System.Drawing.Point(20, 205);
            this.mcbmRack.Name = "mcbmRack";
            this.mcbmRack.Size = new System.Drawing.Size(290, 30);
            this.mcbmRack.TabIndex = 1;
            this.mcbmRack.ucComboBoxDataSource = null;
            this.mcbmRack.ucComboBoxDisplayMember = "";
            this.mcbmRack.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.mcbmRack.ucComboBoxValueMember = "";
            this.mcbmRack.ucComboEnabled = true;
            this.mcbmRack.ucComboIndex = -1;
            this.mcbmRack.ucLabelText = "보관함 위치";
            this.mcbmRack.ucMandatory = true;
            this.mcbmRack.ucReadOnly = false;
            this.mcbmRack.ucText = "";
            this.mcbmRack.ucValue = null;
            // 
            // mtxtInputResult
            // 
            this.mtxtInputResult.Location = new System.Drawing.Point(20, 240);
            this.mtxtInputResult.Name = "mtxtInputResult";
            this.mtxtInputResult.Size = new System.Drawing.Size(290, 30);
            this.mtxtInputResult.TabIndex = 5;
            this.mtxtInputResult.ucLabelText = "수입검사결과";
            this.mtxtInputResult.ucMandatory = false;
            this.mtxtInputResult.ucTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtxtInputResult.ucTextArea = false;
            this.mtxtInputResult.ucTextReadOnly = true;
            this.mtxtInputResult.ucValue = "";
            // 
            // mcbmbInputResult
            // 
            this.mcbmbInputResult.Location = new System.Drawing.Point(20, 240);
            this.mcbmbInputResult.Name = "mcbmbInputResult";
            this.mcbmbInputResult.Size = new System.Drawing.Size(290, 30);
            this.mcbmbInputResult.TabIndex = 2;
            this.mcbmbInputResult.ucComboBoxDataSource = null;
            this.mcbmbInputResult.ucComboBoxDisplayMember = "";
            this.mcbmbInputResult.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcbmbInputResult.ucComboBoxValueMember = "";
            this.mcbmbInputResult.ucComboEnabled = true;
            this.mcbmbInputResult.ucComboIndex = -1;
            this.mcbmbInputResult.ucLabelText = "수입검사결과";
            this.mcbmbInputResult.ucMandatory = true;
            this.mcbmbInputResult.ucReadOnly = false;
            this.mcbmbInputResult.ucText = "";
            this.mcbmbInputResult.ucValue = null;
            // 
            // mcmbModelCode
            // 
            this.mcmbModelCode.Location = new System.Drawing.Point(20, 64);
            this.mcmbModelCode.Name = "mcmbModelCode";
            this.mcmbModelCode.Size = new System.Drawing.Size(290, 30);
            this.mcmbModelCode.TabIndex = 21;
            this.mcmbModelCode.ucComboBoxDataSource = null;
            this.mcmbModelCode.ucComboBoxDisplayMember = "";
            this.mcmbModelCode.ucComboBoxDropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.mcmbModelCode.ucComboBoxValueMember = "";
            this.mcmbModelCode.ucComboEnabled = true;
            this.mcmbModelCode.ucComboIndex = -1;
            this.mcmbModelCode.ucLabelText = "모델코드";
            this.mcmbModelCode.ucMandatory = true;
            this.mcmbModelCode.ucReadOnly = false;
            this.mcmbModelCode.ucText = "";
            this.mcmbModelCode.ucValue = null;
            // 
            // gbRight
            // 
            this.gbRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRight.Controls.Add(this.dtgMain);
            this.gbRight.Location = new System.Drawing.Point(345, 81);
            this.gbRight.Name = "gbRight";
            this.gbRight.Size = new System.Drawing.Size(879, 460);
            this.gbRight.TabIndex = 22;
            this.gbRight.TabStop = false;
            this.gbRight.Text = "목록";
            // 
            // dtgMain
            // 
            this.dtgMain.AllowUserToAddRows = false;
            this.dtgMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dtgMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMain.AutoGenerateColumns = false;
            this.dtgMain.BackgroundColor = System.Drawing.Color.White;
            this.dtgMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dURABLEIDDataGridViewTextBoxColumn,
            this.dURABLEPRODUCTIDDataGridViewTextBoxColumn,
            this.dURABLEPRODUCTNameDataGridViewTextBoxColumn,
            this.vENDERIDDataGridViewTextBoxColumn,
            this.vENDERNameDataGridViewTextBoxColumn,
            this.rACKIDDataGridViewTextBoxColumn,
            this.iNPUTRESULTDataGridViewTextBoxColumn,
            this.iNPUTRESULTNameDataGridViewTextBoxColumn,
            this.cREATEDATEDataGridViewTextBoxColumn,
            this.cREATORDataGridViewTextBoxColumn,
            this.cREATORNameDataGridViewTextBoxColumn,
            this.dESCRIPTIONDataGridViewTextBoxColumn});
            this.dtgMain.DataSource = this.mCDURABLEBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMain.EnableHeadersVisualStyles = false;
            this.dtgMain.Location = new System.Drawing.Point(3, 23);
            this.dtgMain.Name = "dtgMain";
            this.dtgMain.ReadOnly = true;
            this.dtgMain.RowTemplate.Height = 27;
            this.dtgMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMain.Size = new System.Drawing.Size(873, 434);
            this.dtgMain.TabIndex = 0;
            // 
            // dURABLEIDDataGridViewTextBoxColumn
            // 
            this.dURABLEIDDataGridViewTextBoxColumn.DataPropertyName = "DURABLEID";
            this.dURABLEIDDataGridViewTextBoxColumn.HeaderText = "Mask 일련번호";
            this.dURABLEIDDataGridViewTextBoxColumn.Name = "dURABLEIDDataGridViewTextBoxColumn";
            this.dURABLEIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dURABLEPRODUCTIDDataGridViewTextBoxColumn
            // 
            this.dURABLEPRODUCTIDDataGridViewTextBoxColumn.DataPropertyName = "DURABLEPRODUCTID";
            this.dURABLEPRODUCTIDDataGridViewTextBoxColumn.HeaderText = "모델코드";
            this.dURABLEPRODUCTIDDataGridViewTextBoxColumn.Name = "dURABLEPRODUCTIDDataGridViewTextBoxColumn";
            this.dURABLEPRODUCTIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dURABLEPRODUCTNameDataGridViewTextBoxColumn
            // 
            this.dURABLEPRODUCTNameDataGridViewTextBoxColumn.DataPropertyName = "DURABLEPRODUCTName";
            this.dURABLEPRODUCTNameDataGridViewTextBoxColumn.HeaderText = "모델명";
            this.dURABLEPRODUCTNameDataGridViewTextBoxColumn.Name = "dURABLEPRODUCTNameDataGridViewTextBoxColumn";
            this.dURABLEPRODUCTNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vENDERIDDataGridViewTextBoxColumn
            // 
            this.vENDERIDDataGridViewTextBoxColumn.DataPropertyName = "VENDERID";
            this.vENDERIDDataGridViewTextBoxColumn.HeaderText = "VENDERID";
            this.vENDERIDDataGridViewTextBoxColumn.Name = "vENDERIDDataGridViewTextBoxColumn";
            this.vENDERIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.vENDERIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // vENDERNameDataGridViewTextBoxColumn
            // 
            this.vENDERNameDataGridViewTextBoxColumn.DataPropertyName = "VENDERName";
            this.vENDERNameDataGridViewTextBoxColumn.HeaderText = "제작업체";
            this.vENDERNameDataGridViewTextBoxColumn.Name = "vENDERNameDataGridViewTextBoxColumn";
            this.vENDERNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rACKIDDataGridViewTextBoxColumn
            // 
            this.rACKIDDataGridViewTextBoxColumn.DataPropertyName = "RACKID";
            this.rACKIDDataGridViewTextBoxColumn.HeaderText = "보관함위치";
            this.rACKIDDataGridViewTextBoxColumn.Name = "rACKIDDataGridViewTextBoxColumn";
            this.rACKIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iNPUTRESULTDataGridViewTextBoxColumn
            // 
            this.iNPUTRESULTDataGridViewTextBoxColumn.DataPropertyName = "INPUTRESULT";
            this.iNPUTRESULTDataGridViewTextBoxColumn.HeaderText = "INPUTRESULT";
            this.iNPUTRESULTDataGridViewTextBoxColumn.Name = "iNPUTRESULTDataGridViewTextBoxColumn";
            this.iNPUTRESULTDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNPUTRESULTDataGridViewTextBoxColumn.Visible = false;
            // 
            // iNPUTRESULTNameDataGridViewTextBoxColumn
            // 
            this.iNPUTRESULTNameDataGridViewTextBoxColumn.DataPropertyName = "INPUTRESULTName";
            this.iNPUTRESULTNameDataGridViewTextBoxColumn.HeaderText = "수입검사결과";
            this.iNPUTRESULTNameDataGridViewTextBoxColumn.Name = "iNPUTRESULTNameDataGridViewTextBoxColumn";
            this.iNPUTRESULTNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cREATEDATEDataGridViewTextBoxColumn
            // 
            this.cREATEDATEDataGridViewTextBoxColumn.DataPropertyName = "INPUTDATESTRING";
            this.cREATEDATEDataGridViewTextBoxColumn.HeaderText = "입고일자";
            this.cREATEDATEDataGridViewTextBoxColumn.Name = "cREATEDATEDataGridViewTextBoxColumn";
            this.cREATEDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cREATORDataGridViewTextBoxColumn
            // 
            this.cREATORDataGridViewTextBoxColumn.DataPropertyName = "CREATOR";
            this.cREATORDataGridViewTextBoxColumn.HeaderText = "CREATOR";
            this.cREATORDataGridViewTextBoxColumn.Name = "cREATORDataGridViewTextBoxColumn";
            this.cREATORDataGridViewTextBoxColumn.ReadOnly = true;
            this.cREATORDataGridViewTextBoxColumn.Visible = false;
            // 
            // cREATORNameDataGridViewTextBoxColumn
            // 
            this.cREATORNameDataGridViewTextBoxColumn.DataPropertyName = "CREATORName";
            this.cREATORNameDataGridViewTextBoxColumn.HeaderText = "담당자";
            this.cREATORNameDataGridViewTextBoxColumn.Name = "cREATORNameDataGridViewTextBoxColumn";
            this.cREATORNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dESCRIPTIONDataGridViewTextBoxColumn
            // 
            this.dESCRIPTIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPTION";
            this.dESCRIPTIONDataGridViewTextBoxColumn.HeaderText = "사양정보";
            this.dESCRIPTIONDataGridViewTextBoxColumn.Name = "dESCRIPTIONDataGridViewTextBoxColumn";
            this.dESCRIPTIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mCDURABLEBindingSource
            // 
            this.mCDURABLEBindingSource.DataSource = typeof(XrayInspection.DataModel.MC_DURABLE);
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
            this.btnNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(12, 40);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 35);
            this.btnNew.TabIndex = 26;
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
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Image = global::XrayInspection.Properties.Resources.save_white;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(98, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "     저장";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SlateGray;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.btnClose.FlatAppearance.BorderSize = 4;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateGray;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1138, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "     닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // MMRegisterPop
            // 
            this.Caption = "신규 등록";
            this.ClientSize = new System.Drawing.Size(1236, 553);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbRight);
            this.Controls.Add(this.gbLeft);
            this.MinimumSize = new System.Drawing.Size(1218, 440);
            this.Name = "MMRegisterPop";
            this.Text = "Mask 신규등록";
            this.Controls.SetChildIndex(this.gbLeft, 0);
            this.Controls.SetChildIndex(this.gbRight, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.gbLeft.ResumeLayout(false);
            this.gbLeft.PerformLayout();
            this.gbRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCDURABLEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLeft;
        private UserControls.MaskTextBox mtxtID;
        private UserControls.MaskTextBox mtxtName;
        private UserControls.MaskTextBox mtxtVenderCode;
        private UserControls.MaskComboBox mcbmRack;
        private UserControls.MaskComboBox mcbmbInputResult;
        private UserControls.MaskDatePicker mdtpCreateDate;
        private UserControls.MaskTextBox mtxtCreator;
        private System.Windows.Forms.GroupBox gbRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dURABLEPIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource mCDURABLEBindingSource;
        private MaskTextBox mtxtRack;
        private MaskTextBox mtxtInputResult;
        private MaskTextBox mtxtVenderName;
        private MaskTextBox mtxtCode;
        private System.Windows.Forms.TextBox txtCreateDate;
        private MaskTextBox mtxtDesc;
        private CustomDataGridViewControl dtgMain;
        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnClose;
        private MaskComboBox mcmbModelCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dURABLEIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dURABLEPRODUCTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dURABLEPRODUCTNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vENDERIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vENDERNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rACKIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNPUTRESULTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNPUTRESULTNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cREATORNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPTIONDataGridViewTextBoxColumn;
    }
}