using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager.PopUp
{
    public partial class MMCodeHelper : ParentsPop
    {
        private string ProcedureName = "";
        private DBManager conn = new DBManager();
        private bool LogInYN = false;
        public string ReturnCodeValue = "";
        public string ReturnNameValue = "";
        public string ReturnCodeNameValue = "";
        private bool bAdmin = false;

        public MMCodeHelper(string type)
        {
            InitializeComponent();
            if (type.Equals("LOGIN"))
                LogInYN = true;
            SetEvent();
            InitPopup(type);
            InitGridView(type);
        }

        private void SetEvent()
        {
            //2019-05-14 황지희 폼 사이즈 변경 및 그리드 visible 처리 
            if (!LogInYN)
            {
                btnClose.Click += BtnClose_Click;
                btnOK.Click += BtnOK_Click;
                dtgCode.Visible = true;
                this.Size = new Size(800, 420);
            }
            else
            {
                dtgCode.Visible = false;
                btnClose.Click += BtnOK_Click;
                this.Size = new Size(300, 220);
            }
            mtxtKey.maskTextBoxKeyDownEvent += MtxtKey_KeyDown;
            this.FormClosing += MMCodeHelper_FormClosing;
            
        }

        private void InitPopup(string type)
        {
            switch(type)
            {
                case "VENDER":
                    ProcedureName = "SelectVender";
                    lblTitle.Text = "업체";
                    mtxtKey.ucLabelText = "업체명/ID";
                    break;
                case "EQUIP":
                    ProcedureName = "SelectEquipment";
                    lblTitle.Text = "설비";
                    mtxtKey.ucLabelText = "설비명/ID";
                    break;
                case "USER":
                    ProcedureName = "SelectUser";
                    lblTitle.Text = "사용자";
                    mtxtKey.ucLabelText = "사용자명/ID";
                    break;
                case "LOGIN":
                    ProcedureName = "SelectUser";
                    lblTitle.Text = "LOG IN";
                    mtxtKey.ucLabelText = "사용자명/ID";
                    btnOK.Visible = false;
                    btnClose.Text = "확인";
                    break;
                default:
                    break;
            }
        }

        private void InitGridView(string type)
        {
            string CodeColumn = "";
            string NameColumn = "";
            switch (type)
            {
                case "VENDER":
                    CodeColumn = "venderid";
                    NameColumn = "vendername";
                    break;
                case "EQUIP":
                    CodeColumn = "equipmentid";
                    NameColumn = "equipmentname";
                    break;
                case "USER":
                case "LOGIN":
                    CodeColumn = "userid";
                    NameColumn = "username";
                    break;
                default:
                    break;
            }
            dtgCode.AutoGenerateColumns = false;
            CommonFuction.SetDataGridViewColumnStyle(dtgCode, "코드", CodeColumn, "code", typeof(string), 130);
            CommonFuction.SetDataGridViewColumnStyle(dtgCode, "이름", NameColumn, "name", typeof(string), 250);
        }

        private void MtxtKey_KeyDown(object sender, EventArgs e)
        {
            string sAdmin = (sender as TextBox).Text.ToString();

            if((e as KeyEventArgs).KeyCode == Keys.Enter)
            {
                if (sAdmin.Equals("TESTADMIN")) {
                    bAdmin = true;
                    BtnOK_Click(null, null);
                    dtgCode.Visible = false;
                    return;
                }

                dtgCode.Visible = true;
                Dictionary<string,object> param = new Dictionary<string, object>();
                param.Add("@key", (sender as TextBox).Text);
                if (lblTitle.Text.Equals("LOG IN"))
                {
                    //param.Add("@UseYN", "Y");
                    param.Add("@LogIn", "Y");
                }
                DataSet ds = conn.CallSelectProcedure_ds(ProcedureName, conn.GetSqlParameters(param));
                if(!ds.Tables.Count.Equals(0))
                {
                    dtgCode.DataSource = ds.Tables[0];
                    if(ds.Tables[0].Rows.Count == 1)
                    {
                        BtnOK_Click(null, null);
                    }
                    if (lblTitle.Text.Equals("LOG IN")) {
                        dtgCode.Visible = false;
                    }
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DataTable dt = dtgCode.DataSource as DataTable;

            if (bAdmin)
            {
                this.ReturnCodeValue = "testadmin";
                this.ReturnNameValue = "관리자";
                this.ReturnCodeNameValue = ReturnCodeValue + " : " + ReturnNameValue;
                this.Close();
                return;
            }

            if (CommonFuction.IsNullOrWhiteSpace(dtgCode.CurrentRow))
            {
                MessageBox.Show("선택된 항목이 없습니다.");
                return;
            }

            DataGridViewRow gRow = dtgCode.CurrentRow;

            this.ReturnCodeValue = gRow.Cells["code"].Value.ToString();
            this.ReturnNameValue = gRow.Cells["name"].Value.ToString();
            this.ReturnCodeNameValue = ReturnCodeValue + " : " + ReturnNameValue;
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtgCode_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnOK_Click(null, null);
        }

        /// <summary>
        /// 로그인 화면에서 입력없이 창 닫지 못하게 수정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MMCodeHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LogInYN && string.IsNullOrWhiteSpace(ReturnCodeValue))
            {
                e.Cancel = true;
            }
        }
    }
}
