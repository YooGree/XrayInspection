using MaskManager.PopUp;
using MaskManager.TabPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager
{
    public partial class MainFrm : Form
    {
        DataModelPop dataModelPop;
        MMManagedReportControl mMManagedReportControl;
        DBManager conn = new DBManager();
        private string ProcedureName = "GetMaskDataByRack";
        private string ProcedureName2 = "SelectRackReport";

        public MainFrm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetEvent();
            System.Configuration.AppSettingsReader temp = new System.Configuration.AppSettingsReader();
            lblCrrUser.Text = CommonFuction.GetUserName(Program.CurrentUser);
            if (string.IsNullOrEmpty(Program.CurrentUser))
            {
                BtnLogIn_Click(null, null);
            }
            mMManagedReportControl = new MMManagedReportControl();
            MMManagedReportTabPage.Controls.Add(mMManagedReportControl);
            ResetRackStatus(true);
        }

        private void SetEvent()
        {
            btnLogIn.Click += BtnLogIn_Click;
            tsmStorage.Click += TsmStorage_Click;
            toolStripButton1.Click += ToolStripButton1_Click;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            MMRegisterPop _registerPop = new MMRegisterPop();
            _registerPop.ShowDialog();
            ResetRackStatus(false);
        }

        private void TsmStorage_Click(object sender, EventArgs e)
        {
            dataModelPop = new DataModelPop(SelectedTabType.Rack);
            dataModelPop.ShowDialog();
            ResetRackStatus(true);
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            MMCodeHelper CodeHelper = new MMCodeHelper("LOGIN");
            CodeHelper.ShowDialog();
            Program.CurrentUser = CodeHelper.ReturnCodeValue;
            //2019-05-14 황지희 사용자 이름으로 보여주게 변경
            lblCrrUser.Text = CommonFuction.GetUserName(Program.CurrentUser);
        }

        private void tsmUser_Click(object sender, EventArgs e)
        {
            dataModelPop = new DataModelPop(SelectedTabType.User);

            dataModelPop.ShowDialog();
            ResetRackStatus(true);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MMManufactureInfoPop mMManufactureInfoPop = new MMManufactureInfoPop();
            mMManufactureInfoPop.ShowDialog();
            ResetRackStatus(false);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MMInspectPop mMInspectPop = new MMInspectPop();
            mMInspectPop.ShowDialog();
            ResetRackStatus(false);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MMScrapPop mms = new MMScrapPop();
            mms.ShowDialog();
            ResetRackStatus(false);
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            //new ButtonSample().Show();
            DBConnSettingPop mms = new DBConnSettingPop();
            mms.ShowDialog();
            ResetRackStatus(false);
        }
        private void TsmVender_Click(object sender, EventArgs e)
        {
            dataModelPop = new DataModelPop(SelectedTabType.Vender);

            dataModelPop.ShowDialog();
            ResetRackStatus(true);
        }

        public string SetMaskDatas(string RackId)
        {
            DataSet ds = new DataSet();

            ds = conn.CallSelectProcedure_ds(ProcedureName, new SqlParameter[] { new SqlParameter("rackid", RackId) });

            if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                lblDataMaskID.Text = dr["durableid"].ToString();
                lblDataModelName.Text = dr["durableproductname"].ToString();
                lblDataRackID.Text = dr["equipmentid"].ToString();
                lblDataInputInsp.Text = dr["inputresult"].ToString();
                if (!CommonFuction.IsNullOrWhiteSpace(dr["inputdate"]))
                {
                    lblDataInputDate.Text = dr["inputdate"].ToString();
                }
                else
                {
                    lblDataInputDate.Text = "";
                }
                if (!CommonFuction.IsNullOrWhiteSpace(dr["usedate"]))
                { 
                    lblDataRecentUse.Text = dr["usedate"].ToString();
                }
                else
                {
                    lblDataRecentUse.Text = "";
                }
                if ((int)dr["totuseqty"]> 0)
                { 
                    lblDataTotalUse.Text = dr["totuseqty"].ToString();
                 }
                else
                {
                    lblDataTotalUse.Text = "";
                }
                lblDataCleanInsp.Text = dr["cleanresult"].ToString();
                lblDataDescription.Text = dr["description"].ToString();

            }

            return ds.Tables.Count.ToString();
        }

        private void TsmDurable_Click(object sender, EventArgs e)
        {
            dataModelPop = new DataModelPop(SelectedTabType.DurableProd);

            dataModelPop.ShowDialog();
            ResetRackStatus(true);
        }

        private void TsmEquipment_Click(object sender, EventArgs e)
        {
            dataModelPop = new DataModelPop(SelectedTabType.Equipment);

            dataModelPop.ShowDialog();
            ResetRackStatus(true);
        }

        private void ResetRackStatus(bool InitYN)
        {
            MMStoredInfoPage.GetData();
            if(InitYN) MMStoredInfoPage.Initialization();
            MMStoredInfoPage.DrawRacks();
            SetRackReport();
        }

        private void SetRackReport()
        {
            try
            {
                DataSet ds = conn.CallSelectProcedure_ds(ProcedureName2, conn.GetSqlParameters(new Dictionary<string, object>()));
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    lblCountEmpty.Text = dr["EMPTY"].ToString();
                    lblCountStock.Text = dr["STOCK"].ToString();
                    lblCountUsing.Text = dr["RUN"].ToString();
                    lblCountWarning.Text = dr["WARNING"].ToString();
                }
            }
            catch (Exception e)
            {
                LogFactory.Log(e);
            }
        }

    }
}
