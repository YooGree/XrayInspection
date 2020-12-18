﻿using MaskManager.TabPages;
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
            XrayDecipher, // Xray판독
            Setting, // 환경설정
            UserManagement, // 사용자등록
            DefectCodeManagement, // 불량코드등록
            ProductManagement, // 제품등록
            RegWorkorder, // 작업계획등록
            SearchWorkorder, // 작업계획조회
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

                // Xray판독 화면 보여주기
                if (value == selectedType.XrayDecipher)
                {
                    panelXrayDecipher.BringToFront();
                    btnXrayDecipher.Font = CommonFuction.BoldFont;

                    // 화면 이동시 자동조회
                    foreach (Control control in panelXrayDecipher.Controls)
                    {
                        CS_XrayDecipher XrayDecipher = (CS_XrayDecipher)control;
                        XrayDecipher.ProductInfoSearch();
                    }
                }
                // 환경설정 화면 보여주기
                else if (value == selectedType.Setting)
                {
                    panelSetting.BringToFront();
                    btnSetting.Font = CommonFuction.BoldFont;
                }
                // 사용자등록 화면 보여주기
                else if (value == selectedType.UserManagement)
                {
                    panelUserManagement.BringToFront();
                    btnUserManagement.Font = CommonFuction.BoldFont;
                }
                // 불량코드등록 화면 보여주기
                else if (value == selectedType.DefectCodeManagement)
                {
                    panelDefectCodeManagement.BringToFront();
                    btnDefectCodeManagement.Font = CommonFuction.BoldFont;
                }
                // 제품등록 화면 보여주기
                else if (value == selectedType.ProductManagement)
                {
                    panelProductManagement.BringToFront();
                    btnProductManagement.Font = CommonFuction.BoldFont;
                }
                // 작업계획등록 화면 보여주기
                else if (value == selectedType.RegWorkorder)
                {
                    panelRegWorkorder.BringToFront();
                    btnRegWorkorder.Font = CommonFuction.BoldFont;

                    // 화면 이동시 자동조회
                    foreach (Control control in panelRegWorkorder.Controls)
                    {
                        CS_RegWorkorder RegWorkorder1 = (CS_RegWorkorder)control;
                        RegWorkorder1.Search();
                    }
                }
                // 작업계획조회 화면 보여주기
                else if (value == selectedType.SearchWorkorder)
                {
                    panelSearchWorkorder.BringToFront();
                    btnSearchWorkorder.Font = CommonFuction.BoldFont;

                    // 화면 이동시 자동조회
                    foreach (Control control in panelSearchWorkorder.Controls)
                    {
                        CS_SelectWorkorder SelectWorkorder = (CS_SelectWorkorder)control;
                        SelectWorkorder.Search();
                    }
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
        }

        private void SetEvent()
        {
            btnMaskInfo.Click += Btn_MaskInfo_Click;
            btnInsp.Click += Btn_Insp_Click;
            btnScrap.Click += Btn_Scrap_Click;

            btnXrayDecipher.Click += BtnMenu_Click;
            btnSetting.Click += BtnMenu_Click;
            btnUserManagement.Click += BtnMenu_Click;
            btnDefectCodeManagement.Click += BtnMenu_Click;
            btnProductManagement.Click += BtnMenu_Click;
            btnRegWorkorder.Click += BtnMenu_Click;
            btnSearchWorkorder.Click += BtnMenu_Click;
            btnAIJubgmentInfo.Click += BtnMenu_Click;
            btnAIJubgmentHistory.Click += BtnMenu_Click;

            btnReport.Click += Btn_Report_Click;
            btnMaskInfoCancel.Click += BtnMaskInfoCancel_Click;
            this.KeyDown += CS_MainForm_KeyDown;
        }

        /// <summary>
        /// 조회버튼이 있는 화면은 F5 KeyDown시 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CS_MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                // 사용자등록
                if (btnUserManagement.Font.Bold)
                {
                    foreach (Control control in panelUserManagement.Controls)
                    {
                        CS_UserManagement screen = (CS_UserManagement)control;
                        screen.Search();
                    }
                }
                // 불량코드등록
                else if (btnDefectCodeManagement.Font.Bold)
                {
                    foreach (Control control in panelDefectCodeManagement.Controls)
                    {
                        CS_DefectCodeManagement screen = (CS_DefectCodeManagement)control;
                        screen.Search();
                    }
                }
                // 제품등록
                else if (btnProductManagement.Font.Bold)
                {
                    foreach (Control control in panelProductManagement.Controls)
                    {
                        CS_ProductManagement screen = (CS_ProductManagement)control;
                        screen.Search();
                    }
                }
            }
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

            // 로고 보이게 설정
            panelLogo_MICube.Visible = true;
            panelLogo_Chosun.Visible = true;

            // 초기화면 Xray판독화면으로 세팅
            panelXrayDecipher.BringToFront();
            btnXrayDecipher.Font = CommonFuction.BoldFont;

            btnList = new List<Button>() { btnXrayDecipher, btnSetting, btnUserManagement, btnDefectCodeManagement, btnProductManagement, btnRegWorkorder, btnSearchWorkorder, btnAIJubgmentInfo, btnAIJubgmentHistory, btnReport };

            // Xray판독화면 판넬에 세팅
            CS_XrayDecipher XrayDecipher = new CS_XrayDecipher();
            panelXrayDecipher.Controls.Add(XrayDecipher);

            // 환경설정화면 판넬에 세팅
            CS_Setting Setting = new CS_Setting();
            panelSetting.Controls.Add(Setting);

            // 사용자등록화면 판넬에 세팅
            CS_UserManagement UserManagement = new CS_UserManagement();
            panelUserManagement.Controls.Add(UserManagement);

            // 불량코드등록화면 판넬에 세팅
            CS_DefectCodeManagement DefectCodeManagement = new CS_DefectCodeManagement();
            panelDefectCodeManagement.Controls.Add(DefectCodeManagement);

            // 제품등록화면 판넬에 세팅
            CS_ProductManagement ProductManagement = new CS_ProductManagement();
            panelProductManagement.Controls.Add(ProductManagement);

            // 작업계획등록화면 판넬에 세팅
            CS_RegWorkorder RegWorkorder = new CS_RegWorkorder();
            panelRegWorkorder.Controls.Add(RegWorkorder);

            // 작업계획조회화면 판넬에 세팅
            CS_SelectWorkorder SearchWorkOrder = new CS_SelectWorkorder();
            panelSearchWorkorder.Controls.Add(SearchWorkOrder);

            // AI 판정정보화면 판넬에 세팅 
            CS_AIjubgmentInfo AIjubgmentInfo = new CS_AIjubgmentInfo();
            panelAIjubgmentInfo.Controls.Add(AIjubgmentInfo);

            // AI 판정이력화면 판넬에 세팅 
            CS_AIjubgmentHistory AIjubgmentHistory = new CS_AIjubgmentHistory();
            panelAIjubgmentHistory.Controls.Add(AIjubgmentHistory);

            MMManagedReportControl Report = new MMManagedReportControl();
            p_Report.Controls.Add(Report);

            btnXrayDecipher.Tag = selectedType.XrayDecipher; // Xray판독
            btnSetting.Tag = selectedType.Setting; // 환경설정
            btnUserManagement.Tag = selectedType.UserManagement; // 사용자등록
            btnDefectCodeManagement.Tag = selectedType.DefectCodeManagement; // 불량코드등록
            btnProductManagement.Tag = selectedType.ProductManagement; // 제품등록
            btnRegWorkorder.Tag = selectedType.RegWorkorder; // 작업계획등록
            btnSearchWorkorder.Tag = selectedType.SearchWorkorder; // 작업계획조회
            btnAIJubgmentInfo.Tag = selectedType.AIJubgmentInfo; // AI 판정정보
            btnAIJubgmentHistory.Tag = selectedType.AIJubgmentHistory; // AI 판정이력
            btnReport.Tag = selectedType.Report;
        }

        #endregion

    }
}
