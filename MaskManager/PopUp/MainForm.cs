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

namespace MaskManager.PopUp
{
    /// <summary>
    /// 작성자 : 황지희
    /// 파일명 : MainForm.CS
    /// 이  력 : 2019-05-14 디자인 수정으로 인한 신규작성
    /// </summary>
    public partial class MainForm : ParentsPop
    {
        DBManager conn = new DBManager();
        private string ProcedureName = "GetMaskDataByRack";
        private string ProcedureName2 = "SelectRackReport";
        private string ProcedureName3 = "SelectMaskChangeInfo";
        private string ProcedureName4 = "SaveMaskStateChange";

        private List<Button> btnList;
        DataModelPop dataModelPop = new DataModelPop(SelectedTabType.User);
        MMManufactureInfoPop _MManufactureInfoPop = new MMManufactureInfoPop();
        MMRegisterPop _registerPop = new MMRegisterPop();
        MMInspectPop _MInspectPop = new MMInspectPop();
        MMScrapPop _Scrap = new MMScrapPop();
        MMManufactureInfoChange _MMManufactureInfoChange = new MMManufactureInfoChange();



        public enum selectedType
        {
            Report,
            Main
        }

        public MainForm()
        {
            InitializeComponent();
            Caption = "Mask Manager";

            btnList = new List<Button>() { btnReport, btnMain };
            MMManagedReportControl Report = new MMManagedReportControl();
            p_Report.Controls.Add(Report);
            btnReport.Tag = selectedType.Report;
            btnMain.Tag = selectedType.Main;
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
            //MMManagedReportControl = new MMManagedReportControl();
           // MMManagedReportTabPage.Controls.Add(mMManagedReportControl);
            ResetRackStatus(true);
            this.txt_MaskNum.txtText.CharacterCasing = CharacterCasing.Upper;
        }

        private void SetEvent()
        {
            btnLogIn.Click += BtnLogIn_Click;
            btnBase.Click += Btn_Base_Click;
            btnRegister.Click += Btn_Register_Click;
            btnMaskInfo.Click += Btn_MaskInfo_Click;
            btnInsp.Click += Btn_Insp_Click;
            btnScrap.Click += Btn_Scrap_Click;
            btnDB.Click += Btn_DB_Click;
            btnClose.Click += BtnClose_Click;
            btnMain.Click += Btn_Main_Click;
            btnReport.Click += Btn_Report_Click;
            btnMaskInfoCancel.Click += BtnMaskInfoCancel_Click;
            txt_MaskNum.txtText.KeyDown += TxtText_KeyDown;
            txt_MaskNum.txtText.KeyPress += TxtText_KeyPress;
            //tsmStorage.Click += TsmStorage_Click;
            //toolStripButton1.Click += ToolStripButton1_Click;
        }


        /////////////////////////////////////////////////// KEY EVENT ///////////////////////////////////////    
        /// <summary>
        /// 2019-05-27 황지희 일련번호로 상태 변경 추가 
        /// </summary>

        private void TxtText_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonFuction.TypingOnlyEngNum(sender, e, txt_MaskNum);
        }


        private void TxtText_KeyDown(object sender, KeyEventArgs e)
        {
            string sMaskNum = (sender as TextBox).Text.ToString();

            if (e.KeyCode == Keys.Enter)
            {
                if (CommonFuction.IsNullOrWhiteSpace(sMaskNum))
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", txt_MaskNum.ucLabelText + "를 입력하세요.");
                    return;
                }

                try
                {
                    DataSet ds = new DataSet();

                    ds = conn.CallSelectProcedure_ds(ProcedureName3, new SqlParameter[] { new SqlParameter("durable_id", sMaskNum) });

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        if (dr["WORKSTATE"].Equals("WORKSTATE_WAIT") && dr["STATE"].Equals("STATE_ACTIVE"))
                        {
                            if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "", "상태 변경하시겠습니까?") == DialogResult.OK)
                            {
                                Dictionary<string, object> args = new Dictionary<string, object>();
                                args.Add("@DURABLEID", sMaskNum);
                                args.Add("@WORKSTATE", "WORKSTATE_USING");

                                conn.CallNonSelectProcedure(ProcedureName4, conn.GetSqlParameters(args));

                                CustomMessageBox.Show(MessageBoxButtons.OK, "SAVE", "저장하였습니다.");

                                txt_MaskNum.txtText.ResetText();
                                txt_MaskNum.Focus();
                                ResetRackStatus(true);
                            }
                        }
                        else
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 LOT의 상태를 변경할 수 없습니다.");
                            txt_MaskNum.txtText.ResetText();
                            txt_MaskNum.Focus();
                            return;
                        }
                    }
                    else
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 MASK 일련번호가 없습니다.");
                        txt_MaskNum.txtText.ResetText();
                        txt_MaskNum.Focus();
                        return;
                    }
                }
                catch (Exception ee)
                {
                    LogFactory.Log(ee);
                    CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
                }
            }
        }

        selectedType SelectedType
        {
            set
            {
                foreach (Button btn in btnList)
                {
                    btn.Font = CommonFuction.RegularFont;
                }

                if (value == selectedType.Report)
                {
                    p_Report.BringToFront();
                    btnReport.Font = CommonFuction.BoldFont;
                }
                else if (value == selectedType.Main)
                {
                    p_Main.BringToFront();
                    btnMain.Font = CommonFuction.BoldFont;
                }
            }
        }

        /////////////////////////////////////////////////// BUTTON EVENT ///////////////////////////////////////
        private void Btn_Base_Click(object sender, EventArgs e)
        {
            dataModelPop.WindowState = FormWindowState.Normal;
            if(dataModelPop.Visible == false) dataModelPop = new DataModelPop(SelectedTabType.User);
            dataModelPop.Show();
            _registerPop.resetRack = this;
            dataModelPop.Activate();
            //ResetRackStatus(false);
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            
            _registerPop.WindowState = FormWindowState.Normal;
            if (_registerPop.Visible == false)  _registerPop  =  new MMRegisterPop();
            _registerPop.Show();
            _registerPop.resetRack = this;
            _registerPop.Activate();
            //ResetRackStatus(true);
        }

        private void Btn_MaskInfo_Click(object sender, EventArgs e)
        {
            _MManufactureInfoPop.WindowState = FormWindowState.Normal;
            if (_MManufactureInfoPop.Visible == false) _MManufactureInfoPop = new MMManufactureInfoPop();
            _MManufactureInfoPop.Show();
            _MManufactureInfoPop.resetRack = this;
            _MManufactureInfoPop.Activate();
            //ResetRackStatus(false);
        }


        private void BtnMaskInfoCancel_Click(object sender, EventArgs e)
        {
            _MMManufactureInfoChange.WindowState = FormWindowState.Normal;
            if (_MMManufactureInfoChange.Visible == false) _MMManufactureInfoChange = new MMManufactureInfoChange();
            _MMManufactureInfoChange.Show();
            _MMManufactureInfoChange.resetRack = this;
            _MMManufactureInfoChange.Activate();
            //ResetRackStatus(true);
        }

        private void Btn_Insp_Click(object sender, EventArgs e)
        {
            _MInspectPop.WindowState = FormWindowState.Normal;
            if (_MInspectPop.Visible == false) _MInspectPop = new MMInspectPop();
            _MInspectPop.Show();
            _MInspectPop.resetRack = this;
            _MInspectPop.Activate();
            //ResetRackStatus(true);
        }

        private void Btn_Scrap_Click(object sender, EventArgs e)
        {
            _Scrap.WindowState = FormWindowState.Normal;
            if (_Scrap.Visible == false) _Scrap = new MMScrapPop();
            _Scrap.Show();
            _Scrap.resetRack = this;
            _Scrap.Activate();
            //ResetRackStatus(true);
        }

        private void Btn_DB_Click(object sender, EventArgs e)
        {
            DBConnSettingPop mms = new DBConnSettingPop();
            mms.WindowState = FormWindowState.Normal;
            mms.ShowDialog();
            ResetRackStatus(false);
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            MMCodeHelper CodeHelper = new MMCodeHelper("LOGIN");
            CodeHelper.WindowState = FormWindowState.Normal;
            CodeHelper.ShowDialog();
            Program.CurrentUser = CodeHelper.ReturnCodeValue;

            //2O19-05-15 황지희 관리자인 경우만 DB관리 버튼 VISIBLE 되도록수정 
            if (Program.CurrentUser.Equals("testadmin"))
            {
                lblCrrUser.Text = CodeHelper.ReturnNameValue;
                btnDB.Visible = true;

            } else
            {
                //2019-05-14 황지희 사용자 이름으로 보여주게 변경
                lblCrrUser.Text = CommonFuction.GetUserName(Program.CurrentUser);
                btnDB.Visible = false;
            }
        }


        private void Btn_Main_Click(object sender, EventArgs e)
        {
            var tag = ((Button)sender).Tag;
            this.SelectedType = (selectedType)tag;
        }

        private void Btn_Report_Click(object sender, EventArgs e)
        {
            var tag = ((Button)sender).Tag;
            this.SelectedType = (selectedType)tag;
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void tsmUser_Click(object sender, EventArgs e)
        //{
        //    dataModelPop = new DataModelPop(SelectedTabType.User);
        //    dataModelPop.WindowState = FormWindowState.Normal;
        //    dataModelPop.Show();
        //    ResetRackStatus(true);
        //}

        public void ResetRackStatus(bool InitYN)
        {
            MMStoredInfoPage.GetData();
            if (InitYN) MMStoredInfoPage.Initialization();
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

        public string SetMaskDatas(string RackId)
        {
            DataSet ds = new DataSet();

            ds = conn.CallSelectProcedure_ds(ProcedureName, new SqlParameter[] { new SqlParameter("rackid", RackId) });

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                lblDataMaskID.Text = dr["durableid"].ToString();
                lblDataModelCode.Text = dr["durableproductid"].ToString();
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
                if ((int)dr["totuseqty"] > 0)
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

    }
}
