using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using XrayInspection.UserControls;

namespace XrayInspection.PopUp
{
    /// <summary>
    ///  * 파 일 명 : MMWorkeUserChange.cs 					
    ///  * 작 성 자 : 박세일					
    ///  * 설     명 : 작업자 정보 변경
    ///  * 이     력 : 2020-12-16 [박세일] : 신규추가	
    /// </summary>
    public partial class MMWorkeUserChange : ParentsPop
    {
        DBManager DB = new DBManager();

        public MMWorkeUserChange()
        {
            InitializeComponent();
            SetEvent();
        }

        private void MMWorkeUserChange_Load(object sender, EventArgs e)
        {
            Footer.Visible = false;
            
            DBManager dbManager = new DBManager();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@USERTYPE", "INSPECTOR")); // 사이트 정보
            DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_USERMANAGEMENT", parameters);

            cboWorker.ucComboBoxDataSource = ds.Tables[0];
            cboWorker.ucComboBoxDisplayMember = "USERNAME";
            cboWorker.ucComboBoxValueMember = "SEQUENCE";

            parameters.Clear();
            parameters.Add(new SqlParameter("@CODECLASSID", "SHIFT"));
            parameters.Add(new SqlParameter("@ISALL", "N")); 
            ds = dbManager.CallSelectProcedure_ds("USP_GET_CODELIST", parameters);
            cboShift.ucComboBoxDataSource = ds.Tables[0];
            cboShift.ucComboBoxDisplayMember = "CODENAME";
            cboShift.ucComboBoxValueMember = "CodeID";


            parameters.Clear();
            parameters.Add(new SqlParameter("@SITE", "SITE01"));
            ds = dbManager.CallSelectProcedure_ds("USP_SELECT_WORKUSER", parameters);

            cboWorker.ucValue = ds.Tables[0].Rows[0]["UserID"];
            cboShift.ucValue = ds.Tables[0].Rows[0]["ShiftID"];



        }
        /// <summary>
        /// * 함 수 명 : SetEvent					
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 각 Event 정의 								
        /// </summary>
        private void SetEvent()
        {
            Load += MMWorkeUserChange_Load;
            btnCancel.Click += BtnCancel_Click;
            btnSave.Click += BtnSave_Click;
        
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DBManager dbManager = new DBManager();

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@SITE", "SITE01");
            parameters.Add("@UserID", cboWorker.ucValue);
            parameters.Add("@ShiftID",cboShift.ucValue);

            SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

            int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_CHANGEWORKUSER", sqlPamaters);

            if (SaveResult >= 0)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장하였습니다.");
            }
            else
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장에 실패하였습니다.");
            }
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

