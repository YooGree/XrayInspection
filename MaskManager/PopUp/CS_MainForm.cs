using MaskManager.TabPages;
using MaskManager.UserControls;
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
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-07
    /// 설        명  : 조선내화 메인화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_MainForm : ParentsPop
    {
        #region 변수

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

        /// <summary>
        /// 선택된 화면 키워드
        /// </summary>
        private enum selectedType
        {
            Setting, // 환경설정
            AIJubgmentInfo, // AI 판정정보
            AIJubgmentHistory, // AI 판정이력
            Report,
            Main
        }

        /// <summary>
        /// 선택된 화면 키워드에 따라 화면 호출
        /// </summary>
        private selectedType SelectedType
        {
            set
            {
                foreach (Button btn in btnList)
                {
                    btn.Font = CommonFuction.RegularFont;
                }

                // 환경설정 화면 보여주기
                if (value == selectedType.Setting)
                {
                    panelSetting.BringToFront();
                    btnSetting.Font = CommonFuction.BoldFont;
                }
                // 판정정보 화면 보여주기
                else if (value == selectedType.AIJubgmentInfo)
                {
                    panelAIjubgmentInfo.BringToFront();
                    btnAIJubgmentInfo.Font = CommonFuction.BoldFont;
                }
                // 판정이력 화면 보여주기
                else if (value == selectedType.AIJubgmentHistory)
                {
                    panelAIjubgmentHistory.BringToFront();
                    btnAIJubgmentHistory.Font = CommonFuction.BoldFont;
                }
                else if (value == selectedType.Report)
                {
                    p_Report.BringToFront();
                    btnReport.Font = CommonFuction.BoldFont;
                }
            }
        }

        #endregion

        #region 생성자

        public CS_MainForm()
        {
            InitializeComponent();
            InitializeControlSetting();
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetEvent();
            System.Configuration.AppSettingsReader temp = new System.Configuration.AppSettingsReader();

            if (string.IsNullOrEmpty(Program.CurrentUser))
            {
                BtnLogIn_Click(null, null);
            }
        }

        private void SetEvent()
        {
            btnMaskInfo.Click += Btn_MaskInfo_Click;
            btnInsp.Click += Btn_Insp_Click;
            btnScrap.Click += Btn_Scrap_Click;

            btnSetting.Click += BtnMenu_Click;
            btnAIJubgmentInfo.Click += BtnMenu_Click;
            btnAIJubgmentHistory.Click += BtnMenu_Click;

            btnReport.Click += Btn_Report_Click;
            btnMaskInfoCancel.Click += BtnMaskInfoCancel_Click;
            //tsmStorage.Click += TsmStorage_Click;
            //toolStripButton1.Click += ToolStripButton1_Click;
        }

        /// <summary>
        /// 버튼 태그별로 화면진입
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            var tag = ((Button)sender).Tag;
            this.SelectedType = (selectedType)tag;
        }

        /////////////////////////////////////////////////// KEY EVENT ///////////////////////////////////////    
        /// <summary>
        /// 2019-05-27 황지희 일련번호로 상태 변경 추가 
        /// </summary>

        //private void TxtText_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    CommonFuction.TypingOnlyEngNum(sender, e, txt_MaskNum);
        //}


        //private void TxtText_KeyDown(object sender, KeyEventArgs e)
        //{
        //    string sMaskNum = (sender as TextBox).Text.ToString();

        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (CommonFuction.IsNullOrWhiteSpace(sMaskNum))
        //        {
        //            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", txt_MaskNum.ucLabelText + "를 입력하세요.");
        //            return;
        //        }

        //        try
        //        {
        //            DataSet ds = new DataSet();

        //            ds = conn.CallSelectProcedure_ds(ProcedureName3, new SqlParameter[] { new SqlParameter("durable_id", sMaskNum) });

        //            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //            {
        //                DataRow dr = ds.Tables[0].Rows[0];
        //                if (dr["WORKSTATE"].Equals("WORKSTATE_WAIT") && dr["STATE"].Equals("STATE_ACTIVE"))
        //                {
        //                    if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "", "상태 변경하시겠습니까?") == DialogResult.OK)
        //                    {
        //                        Dictionary<string, object> args = new Dictionary<string, object>();
        //                        args.Add("@DURABLEID", sMaskNum);
        //                        args.Add("@WORKSTATE", "WORKSTATE_USING");

        //                        conn.CallNonSelectProcedure(ProcedureName4, conn.GetSqlParameters(args));

        //                        CustomMessageBox.Show(MessageBoxButtons.OK, "SAVE", "저장하였습니다.");

        //                        txt_MaskNum.txtText.ResetText();
        //                        txt_MaskNum.Focus();
        //                        ResetRackStatus(true);
        //                    }
        //                }
        //                else
        //                {
        //                    CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 LOT의 상태를 변경할 수 없습니다.");
        //                    txt_MaskNum.txtText.ResetText();
        //                    txt_MaskNum.Focus();
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 MASK 일련번호가 없습니다.");
        //                txt_MaskNum.txtText.ResetText();
        //                txt_MaskNum.Focus();
        //                return;
        //            }
        //        }
        //        catch (Exception ee)
        //        {
        //            LogFactory.Log(ee);
        //            CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
        //        }
        //    }
        //}

        /////////////////////////////////////////////////// BUTTON EVENT ///////////////////////////////////////
        private void Btn_Base_Click(object sender, EventArgs e)
        {
            dataModelPop.WindowState = FormWindowState.Normal;
            if(dataModelPop.Visible == false) dataModelPop = new DataModelPop(SelectedTabType.User);
            dataModelPop.Show();
            //_registerPop.resetRack = this;
            dataModelPop.Activate();
            //ResetRackStatus(false);
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            
            _registerPop.WindowState = FormWindowState.Normal;
            if (_registerPop.Visible == false)  _registerPop  =  new MMRegisterPop();
            _registerPop.Show();
            //_registerPop.resetRack = this;
            _registerPop.Activate();
            //ResetRackStatus(true);
        }

        private void Btn_MaskInfo_Click(object sender, EventArgs e)
        {
            _MManufactureInfoPop.WindowState = FormWindowState.Normal;
            if (_MManufactureInfoPop.Visible == false) _MManufactureInfoPop = new MMManufactureInfoPop();
            _MManufactureInfoPop.Show();
            //_MManufactureInfoPop.resetRack = this;
            _MManufactureInfoPop.Activate();
            //ResetRackStatus(false);
        }


        private void BtnMaskInfoCancel_Click(object sender, EventArgs e)
        {
            _MMManufactureInfoChange.WindowState = FormWindowState.Normal;
            if (_MMManufactureInfoChange.Visible == false) _MMManufactureInfoChange = new MMManufactureInfoChange();
            _MMManufactureInfoChange.Show();
            //_MMManufactureInfoChange.resetRack = this;
            _MMManufactureInfoChange.Activate();
            //ResetRackStatus(true);
        }

        private void Btn_Insp_Click(object sender, EventArgs e)
        {
            _MInspectPop.WindowState = FormWindowState.Normal;
            if (_MInspectPop.Visible == false) _MInspectPop = new MMInspectPop();
            _MInspectPop.Show();
            //_MInspectPop.resetRack = this;
            _MInspectPop.Activate();
            //ResetRackStatus(true);
        }

        private void Btn_Scrap_Click(object sender, EventArgs e)
        {
            _Scrap.WindowState = FormWindowState.Normal;
            if (_Scrap.Visible == false) _Scrap = new MMScrapPop();
            _Scrap.Show();
            //_Scrap.resetRack = this;
            _Scrap.Activate();
            //ResetRackStatus(true);
        }

        private void Btn_DB_Click(object sender, EventArgs e)
        {
            DBConnSettingPop mms = new DBConnSettingPop();
            mms.WindowState = FormWindowState.Normal;
            mms.ShowDialog();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            //MMCodeHelper CodeHelper = new MMCodeHelper("LOGIN");
            //CodeHelper.WindowState = FormWindowState.Normal;
            //CodeHelper.ShowDialog();
            //Program.CurrentUser = CodeHelper.ReturnCodeValue;

            ////2O19-05-15 황지희 관리자인 경우만 DB관리 버튼 VISIBLE 되도록수정 
            //if (Program.CurrentUser.Equals("testadmin"))
            //{
            //    //lblCrrUser.Text = CodeHelper.ReturnNameValue;
            //    btnDB.Visible = true;

            //} else
            //{
            //    //2019-05-14 황지희 사용자 이름으로 보여주게 변경
            //    //lblCrrUser.Text = CommonFuction.GetUserName(Program.CurrentUser);
            //    btnDB.Visible = false;
            //}
        }

        private void Btn_Report_Click(object sender, EventArgs e)
        {
            var tag = ((Button)sender).Tag;
            this.SelectedType = (selectedType)tag;
        }

        //private void tsmUser_Click(object sender, EventArgs e)
        //{
        //    dataModelPop = new DataModelPop(SelectedTabType.User);
        //    dataModelPop.WindowState = FormWindowState.Normal;
        //    dataModelPop.Show();
        //    ResetRackStatus(true);
        //}

        #region 사용자 정의 함수

        /// <summary>
        /// 메인폼 진입시 컨트롤 최초세팅
        /// </summary>
        private void InitializeControlSetting()
        {
            Caption = "제조데이터 분석기반 - 조선내화";
            FooterText = "최초 접속시간 : " + DateTime.Now.ToString();

            // 초기화면 환경설정화면으로 세팅
            panelSetting.BringToFront();

            btnList = new List<Button>() { btnSetting, btnAIJubgmentInfo, btnAIJubgmentHistory, btnReport };

            // 환경설정화면 판넬에 세팅
            CS_Setting Setting = new CS_Setting();
            panelSetting.Controls.Add(Setting);

            // AI 판정정보화면 판넬에 세팅 
            CS_AIjubgmentInfo AIjubgmentInfo = new CS_AIjubgmentInfo();
            panelAIjubgmentInfo.Controls.Add(AIjubgmentInfo);

            // AI 판정이력화면 판넬에 세팅 
            CS_AIjubgmentHistory AIjubgmentHistory = new CS_AIjubgmentHistory();
            panelAIjubgmentHistory.Controls.Add(AIjubgmentHistory);

            MMManagedReportControl Report = new MMManagedReportControl();
            p_Report.Controls.Add(Report);

            btnSetting.Tag = selectedType.Setting; // 환경설정
            btnAIJubgmentInfo.Tag = selectedType.AIJubgmentInfo; // AI 판정정보
            btnAIJubgmentHistory.Tag = selectedType.AIJubgmentHistory; // AI 판정이력
            btnReport.Tag = selectedType.Report;
        }

        #endregion

    }
}
