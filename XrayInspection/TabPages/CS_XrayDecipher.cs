using XrayInspection.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XrayInspection.UserControls
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-18
    /// 설        명  : Xray 판독화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_XrayDecipher : UserControl
    {
        #region 변수

        //TCPServer _tcpServer = new TCPServer(Properties.Settings.Default.TargetIP, Properties.Settings.Default.TargetPort);
        Socket _mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        DBManager _dbManager = new DBManager();
        bool _deleteFlag;        
        Timer _searchTimer = new Timer();
        //string _sh
        string _lotState; // 현재 LOT상태
        string _workorderNumber; // 현재 WorkOrder번호
        string _userShiftId; // 유저 부서번호

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public CS_XrayDecipher()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeControlSetting();
            InitializeEvent();
        }

        #endregion

        #region 이벤트

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            grdAIDecipherStatus.RowPostPaint += GrdUser_RowPostPaint;

            btnJudgmentResult.Click += CommonPopup_Click;
            btnContext.Click += CommonPopup_Click;
            btnPart.Click += CommonPopup_Click;

            btnStart.Click += BtnStart_Click;
            btnEnd.Click += BtnEnd_Click;
            btnJudgmentComplete.Click += BtnJudgmentComplete_Click;
            btnRefresh.Click += BtnRefresh_Click;
        }
        
        /// <summary>
        /// 새로고침
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Rebinding();
        }

        /// <summary>
        /// AI 판정결과 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnJudgmentComplete_Click(object sender, EventArgs e)
        {
            // 판정중인 데이터가 없다면 알림
            if (grdAIDecipherStatus.Rows.Count == 0)
            {
                MsgBoxHelper.Show("현재 판정중인 데이터가 없습니다." + Environment.NewLine + "먼저 판정을 시작, 종료한 후 진행해주세요.");
                return;
            }
            // 시작 진행중이라면 알림
            else if (!btnStart.Enabled && btnEnd.Enabled)
            {
                MsgBoxHelper.Show("현재 판정 진행중입니다." + Environment.NewLine + "판정을 종료한 후 진행해주세요.");
                return;
            }
            // 판독결과를 입력하지 않았다면 알림
            else if (string.IsNullOrWhiteSpace(txtJudgmentResult.Text))
            {
                MsgBoxHelper.Show("판독결과는 필수입력입니다.");
                return;
            }

            if (MsgBoxHelper.Show("판정완료 하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                // LOT크기 변경
                UpdateLotSize();

                // AI판정결과 저장
                UpdateAIJudgmentResult();

                // 데이터 재바인딩
                Rebinding();
            }
        }

        /// <summary>
        /// 영상녹화종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            // 녹화서버에 메세지 전송
            string sendData = "END " + txtLotNo.Text + "," + txtProductName.Text;
            OnSendData(sendData);

            // 버튼활성화, 비활성화
            btnStart.Enabled = true;
            btnEnd.Enabled = false;

            // 타이머 중지
            _searchTimer.Stop();
        }

        /// <summary>
        /// 영상녹화시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            _deleteFlag = true;

            // 녹화서버에 메세지 전송
            string sendData = "START " + txtLotNo.Text + "," + txtProductName.Text;
            OnSendData(sendData);

            // 버튼활성화, 비활성화
            btnStart.Enabled = false;
            btnEnd.Enabled = true;

            // 타이머 시작
            _searchTimer.Start();

            // LOT크기 변경
            UpdateLotSize();

            // LOT상태 RUN으로 변경
            if (_lotState != "RUN")
            {
                UpdateLotState();
            }
        }

        /// <summary>
        /// 공통팝업 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonPopup_Click(object sender, EventArgs e)
        {
            Button btnPop = (Button)sender;
            CS_CommonPopup commonPopup;

            switch (btnPop.Name)
            {
                // 판정결과(불량코드 대분류)
                case "btnJudgmentResult":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "TOP");
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    commonPopup.Show();
                    commonPopup.Activate();
                    commonPopup.FormClosed += (formSender, formE) =>
                    {
                        if (commonPopup._returnIsOK)
                        {
                            // 판독결과가 합격이라면 항목, 부위, 위치 Enable, ReadOnly
                            if (commonPopup._returnCodeValue == "0")
                            {
                                txtContext.Tag = "None";
                                txtContext.Text = "";
                                btnContext.Enabled = false;
                                txtPart.Tag = "None";
                                txtPart.Text = "";
                                btnPart.Enabled = false;
                                txtLocation.ReadOnly = true;
                            }
                            // 판독결과가 합격이 아니라면 항복, 부위, 위치 입력할 수 있도록
                            else
                            {
                                btnContext.Enabled = true;
                                btnPart.Enabled = true;
                                txtLocation.ReadOnly = false;
                            }

                            if (txtJudgmentResult.Tag.ToString() != commonPopup._returnCodeValue)
                            {
                                txtContext.Tag = "None";
                                txtContext.Text = "";
                                txtPart.Tag = "None";
                                txtPart.Text = "";
                            }

                            txtJudgmentResult.Tag = commonPopup._returnCodeValue;
                            txtJudgmentResult.Text = commonPopup._returnNameValue;
                        }
                    };
                    break;

                // 부위(불량코드 중분류)
                case "btnContext":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "MIDDLE", txtJudgmentResult.Tag.ToString());
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    commonPopup.Show();
                    commonPopup.Activate();
                    commonPopup.FormClosed += (formSender, formE) =>
                    {
                        if (commonPopup._returnIsOK)
                        {
                            if (txtContext.Tag.ToString() != commonPopup._returnCodeValue)
                            {
                                txtPart.Tag = "None";
                                txtPart.Text = "";
                            }
                            txtContext.Tag = commonPopup._returnCodeValue;
                            txtContext.Text = commonPopup._returnNameValue;
                        }
                    };
                    break;

                // 위치(불량코드 소분류)
                case "btnPart":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "DETAIL" , txtContext.Tag.ToString());
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    commonPopup.Show();
                    commonPopup.Activate();
                    commonPopup.FormClosed += (formSender, formE) =>
                    {
                        if (commonPopup._returnIsOK)
                        {
                            txtPart.Tag = commonPopup._returnCodeValue;
                            txtPart.Text = commonPopup._returnNameValue;
                        }
                    };
                    break;
            }
        }

        /// <summary>
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdUser_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, grdAIDecipherStatus.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), grdAIDecipherStatus.RowHeadersDefaultCellStyle.Font, rect, grdAIDecipherStatus.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// Excel 내보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (grdAIDecipherStatus.Rows.Count == 0)
                {
                    DialogResult result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "엑셀 데이터가 없습니다.");
                }
                else
                {
                    sfd.Filter = "csv(*.csv) | *.csv";

                    DialogResult result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "엑셀 저장 하시겠습니까?");

                    if (result == DialogResult.OK)
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            this.SaveCsv(sfd.FileName, grdAIDecipherStatus, true);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// CSV파일 내보내기
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dgv"></param>
        /// <param name="header"></param>
        private void SaveCsv(string fileName, DataGridView dgv, bool header)
        {
            string delimiter = ",";
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, Encoding.UTF8);

            if (dgv.Rows.Count == 0)
            {
                return;
            }

            if (header)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    // 숨겨진 컬럼은 엑셀 내보내기 안되도록 수정
                    if (dgv.Columns[i].HeaderText.Equals("ROWTYPE") || dgv.Columns[i].HeaderText.Equals("state"))
                    {
                        break;
                    }
                    else
                    {
                        csvExport.Write(dgv.Columns[i].HeaderText);
                    }

                    if (i != dgv.Columns.Count - 1)
                    {
                        csvExport.Write(delimiter);
                    }
                }
            }

            csvExport.Write(csvExport.NewLine);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {

                    // 숨겨진 컬럼은 row 엑셀에 내보내기 안되도록 수정
                    if (dgv.Columns[j].HeaderText.Equals("ROWTYPE") || dgv.Columns[j].HeaderText.Equals("state"))
                    {
                        break;
                    }
                    else
                    {
                        csvExport.Write(row.Cells[j].Value);
                    }

                    if (j != dgv.Columns.Count - 1)
                    {
                        csvExport.Write(delimiter);
                    }
                }

                csvExport.Write(csvExport.NewLine);
            }

            csvExport.Flush();
            csvExport.Close();
            fs.Close();

            DialogResult result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "저장 되었습니다.");
        }

        #endregion

        #region 조회

        /// <summary>
        /// 화면 최초 로드시 검사진행현황 조회
        /// </summary>
        public void InspectionCurrentStateSrarch()
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site

                DataSet ds = _dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_CURRENTSTATEINFO", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // 검사현황
                        lblCompleteCount.Text = ds.Tables[0].Rows[0]["COMPLETECOUNT"].ToString();
                        lblPassCount.Text = ds.Tables[0].Rows[0]["PASSCOUNT"].ToString();
                        lblNotPassCount.Text = ds.Tables[0].Rows[0]["NOTPASSCOUNT"].ToString();
                        lblDefectRateCount.Text = ds.Tables[0].Rows[0]["DEFECTRATE"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("검사현황 조회실패!");
            }
        }

        /// <summary>
        /// 화면 최초 로드시 제품정보 및 검사계획/진행현황 조회
        /// </summary>
        public void ProductInfoSearch()
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site

                DataSet ds = _dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_PRODUCTINFO", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // 제품정보
                        txtCustomer.Text = ds.Tables[0].Rows[0]["CUSTOMER"].ToString();
                        txtUsedPlace.Text = ds.Tables[0].Rows[0]["USEDPLACE"].ToString();
                        txtProductName.Text = ds.Tables[0].Rows[0]["PRODUCTNAME"].ToString();
                        txtProductCode.Text = ds.Tables[0].Rows[0]["PRODUCTCODE"].ToString();
                        txtUser.Text = ds.Tables[0].Rows[0]["MAKERNAME"].ToString();
                        txtLotNo.Text = ds.Tables[0].Rows[0]["LOTID"].ToString();

                        // 검사계획/진행현황
                        txtLotSize.Text = ds.Tables[0].Rows[0]["PRODUCTIONQTY"].ToString();
                        txtInspectionStd.Text = ds.Tables[0].Rows[0]["INSPECTRATE"].ToString();
                        txtPlanPageCount.Text = ds.Tables[0].Rows[0]["INSPECTQTY"].ToString();
                        txtProgressSequence.Text = ds.Tables[0].Rows[0]["INSPECTSEQUENCE"].ToString();

                        // 현재 LOT상태
                        _lotState = ds.Tables[0].Rows[0]["LOTSTATE"].ToString();
                        // WorkOrder 번호
                        _workorderNumber = ds.Tables[0].Rows[0]["WORKORDERNUMBER"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("제품정보 조회실패!");
            }
        }

        /// <summary>
        /// 화면 최초 로드시 검사자 조회
        /// </summary>
        public void InspectorInfoSearch()
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site

                DataSet ds = _dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_INSPECTORINFO", parameters);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    // 조회조건 콤보박스 세팅
                    comboInspector.DataSource = ds.Tables[0];
                    comboInspector.DisplayMember = "USERNAME";
                    comboInspector.ValueMember = "USERID";
                    comboInspector.SelectedIndex = 0;
                    comboInspector.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboInspector.SelectedValueChanged += (s, e) =>
                    {
                        string shiftId = ds.Tables[0].AsEnumerable().Where(r => r["USERID"].Equals(comboInspector.SelectedValue)).CopyToDataTable().Rows[0]["SHIFTID"].ToString();
                        comboInspector.Tag = shiftId;
                    };

                    if (ds.Tables.Count == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            comboInspector.SelectedValue = ds.Tables[0].Rows[0]["USERID"].ToString();
                            comboInspector.Text = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                            comboInspector.Tag = ds.Tables[0].Rows[0]["SHIFTID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("검사자정보 조회실패!");
            }
        }

        /// <summary>
        /// 화면 최초 로드시 AI판독정보 조회
        /// </summary>
        public void AIJudgmentInfoSearch()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site
                parameters.Add(new SqlParameter("@LOTNO", txtLotNo.Text)); // LOT NO

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_AIJUDGMENTINFO", parameters);

                if (ds.Tables.Count == 0) Console.WriteLine("AI 판독현황 조회실패!");
                else
                {
                    grdAIDecipherStatus.DataSource = ds.Tables[0];

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // NG가 한건이라도 있을시 AI판정결과 NG로 세팅
                        if (ds.Tables[0].AsEnumerable().Where(r => r["AIRESULT"].Equals("NG")).Count() > 0)
                        {
                            txtAiResult.Text = "NG";
                            txtAiResult.BackColor = Color.MediumVioletRed;
                        }
                        else
                        {
                            txtAiResult.Text = "OK";
                            txtAiResult.BackColor = Color.CornflowerBlue;
                        }
                    }
                    else
                    {
                        txtAiResult.Text = "None";
                        txtAiResult.BackColor = Color.Lavender;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("AI 판독정보 조회실패!");
            }
        }

        /// <summary>
        /// Xray 판독화면 전체데이터 리바인딩
        /// </summary>
        private void Rebinding()
        {
            // 검사실적현황 바인딩
            InspectionCurrentStateSrarch();

            // 제품정보 조회
            ProductInfoSearch();

            // 판정결과 - 검사자 조회
            InspectorInfoSearch();

            // 판정결과 - 바인딩 데이터 리셋
            txtJudgmentResult.Tag = "";
            txtJudgmentResult.Text = "";
            txtContext.Tag = "";
            txtContext.Text = "";
            txtPart.Tag = "";
            txtPart.Text = "";
            txtLocation.Text = "";

            // 검사계획/진행현황 조회(추가예정)

            // AI판독현황 리셋 및 AI결과 리셋
            AIJudgmentInfoSearch();

            if ((grdAIDecipherStatus.DataSource as DataTable).Rows.Count > 0)
            {
                // NG가 한건이라도 있을시 AI판정결과 NG로 세팅
                if ((grdAIDecipherStatus.DataSource as DataTable).AsEnumerable().Where(r => r["AIRESULT"].Equals("NG")).Count() > 0)
                {
                    txtAiResult.Text = "NG";
                    txtAiResult.BackColor = Color.HotPink;
                }
                else
                {
                    txtAiResult.Text = "OK";
                    txtAiResult.BackColor = Color.CornflowerBlue;
                }
            }
            else
            {
                txtAiResult.Text = "None";
                txtAiResult.BackColor = Color.Lavender;
            }
        }

        #endregion

        #region 저장

        /// <summary>
        /// 해당 제품의 LOT 상태가 Run이 아니라면 Run상태로 변경
        /// </summary>
        private void UpdateLotState()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SITE", Properties.Settings.Default.Site);
                parameters.Add("@LOTNO", txtLotNo.Text);

                SqlParameter[] sqlParameters = _dbManager.GetSqlParameters(parameters);

                int saveResult = _dbManager.CallNonSelectProcedure("USP_UPDATE_XRAYDECIPHER_LOTSTATE", sqlParameters);
                if (saveResult > 0) Console.WriteLine("LOT상태 수정성공!");
                else Console.WriteLine("LOT상태 수정실패!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// LOT크기 사용자가 입력한 크기로 변경
        /// </summary>
        private void UpdateLotSize()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SITE", Properties.Settings.Default.Site);
                parameters.Add("@WORKORDERNO", _workorderNumber);
                parameters.Add("@LOTSIZE", Convert.ToInt32(txtLotSize.Text));

                SqlParameter[] sqlParameters = _dbManager.GetSqlParameters(parameters);

                int saveResult = _dbManager.CallNonSelectProcedure("USP_UPDATE_XRAYDECIPHER_LOTSIZE", sqlParameters);
                if (saveResult > 0) Console.WriteLine("LOT크기 수정성공!");
                else Console.WriteLine("LOT크기 수정실패!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 해당 제품의 AI판정결과 저장
        /// </summary>
        private void UpdateAIJudgmentResult()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SITE", Properties.Settings.Default.Site);
                parameters.Add("@LOTNO", txtLotNo.Text);
                parameters.Add("@INSPECTORID", comboInspector.SelectedValue);
                parameters.Add("@INSPECTORNAME", comboInspector.Text);
                parameters.Add("@SHIFTID", comboInspector.Tag);
                parameters.Add("@TOPDEFECTCODE", txtJudgmentResult.Tag);
                parameters.Add("@TOPDEFECTCODENAME", txtJudgmentResult.Text);
                parameters.Add("@MIDDLEDEFECTCODE", txtContext.Tag);
                parameters.Add("@MIDDLEDEFECTCODENAME", txtContext.Text);
                parameters.Add("@DETAILDEFECTCODE", txtPart.Tag);
                parameters.Add("@DETAILDEFECTCODENAME", txtPart.Text);
                parameters.Add("@LOCATION", txtLocation.Text);
                parameters.Add("@AIRESULTCODE", "(TEST)CODE_OK");
                parameters.Add("@AIRESULTCODENAME", "(TEST)CODENAME_OK");
                

                SqlParameter[] sqlParameters = _dbManager.GetSqlParameters(parameters);

                int saveResult = _dbManager.CallNonSelectProcedure("USP_UPDATE_XRAYDECIPHER_AIJUDGMENTRESULT", sqlParameters);
                if (saveResult > 0)
                {
                    MsgBoxHelper.Show("해당 LOT에 대한 판정이 완료되었습니다.");
                    this.Refresh();
                }
                else
                {
                    MsgBoxHelper.Error("Error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region 사용자 정의 함수

        /// <summary>
        /// 기본 컨트롤 세팅
        /// </summary>
        private void InitializeControlSetting()
        {
            this.Dock = DockStyle.Fill;

            // 검사실적현황 바인딩
            InspectionCurrentStateSrarch();

            // 제품정보 및 검사계획/진행현황에 데이터 바인딩
            ProductInfoSearch();

            // 검사자 데이터 바인딩
            InspectorInfoSearch();

            // AI 판독현황에 데이터 바인딩
            AIJudgmentInfoSearch();

            // AI 판독현황 그리드 1초마다 조회될 수 있도록 타이머 설정
            _searchTimer.Interval = 1000;
            _searchTimer.Tick += SearchTimer_Tick;

            // TCP 서버시작
            //_tcpServer.BeginStartServer();

            // TCP 서버 - 클라이언트 연결
            OnConnectToServer();
        }

        /// <summary>
        /// 타이머 발생 조회 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            AIJudgmentInfoSearch();
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdAIDecipherStatus.AutoGenerateColumns = false;
            grdAIDecipherStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdAIDecipherStatus.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdAIDecipherStatus.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "Frame", "FRAMENO", "FRAMENO", typeof(int), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "AI판정", "AIRESULT", "AIRESULT", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "유형", "TYPE", "TYPE", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        #endregion

        #region TCP 클라이언트

        /// <summary>
        /// 열려있는 TCP 서버에 클라이언트를 연결
        /// </summary>
        private void OnConnectToServer()
        {
            if (_mainSocket.Connected)
            {
                MsgBoxHelper.Error("이미 연결되어 있습니다!");
                return;
            }

            try 
            { 
                _mainSocket.Connect(Properties.Settings.Default.TargetIP, Convert.ToInt32(Properties.Settings.Default.TargetPort)); 
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error("연결에 실패했습니다!\n오류 내용: {0}", MessageBoxButtons.OK, ex.Message);
                return;
            }

            // 연결 완료되었다는 메세지를 띄워준다.
            Console.WriteLine("서버와 연결되었습니다.");

            // 연결 완료, 서버에서 데이터가 올 수 있으므로 수신 대기한다.
            AsyncObject obj = new AsyncObject(4096);
            obj.WorkingSocket = _mainSocket;
            _mainSocket.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
        }

        /// <summary>
        /// TCP 서버에서 넘어오는 데이터 받기
        /// </summary>
        /// <param name="ar"></param>
        private void DataReceived(IAsyncResult ar)
        {
            try
            {
                // BeginReceive에서 추가적으로 넘어온 데이터를 AsyncObject 형식으로 변환한다.
                AsyncObject obj = (AsyncObject)ar.AsyncState;

                // 데이터 수신을 끝낸다.
                int received = obj.WorkingSocket.EndReceive(ar);

                // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
                if (received <= 0)
                {
                    obj.WorkingSocket.Close();
                    return;
                }

                // 텍스트로 변환한다.
                string text = Encoding.UTF8.GetString(obj.Buffer).TrimEnd('\0');

                // 0x01 기준으로 짜른다.
                // tokens[0] - 보낸 사람 IP
                // tokens[1] - 보낸 메세지
                string[] tokens = text.Split('\x01');
                string ip = tokens[0];
                string msg = tokens[1];

                // 텍스트박스에 추가해준다.
                // 비동기식으로 작업하기 때문에 폼의 UI 스레드에서 작업을 해줘야 한다.
                // 따라서 대리자를 통해 처리한다.
                Console.WriteLine(string.Format("[받음]{0}: {1}", ip, msg));

                // DB에 이미지 프레임별로 데이터 넣기
                InsertInspectionRecord(msg);

                // 클라이언트에선 데이터를 전달해줄 필요가 없으므로 바로 수신 대기한다.
                // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
                obj.ClearBuffer();

                // 수신 대기
                obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Warn(ex.Message);
            }
        }

        /// <summary>
        /// 클라이언트 -> TCP 서버로 데이터 보내기
        /// </summary>
        /// <param name="stringData"></param>
        private void OnSendData(string stringData)
        {
            // 서버가 대기중인지 확인한다.
            if (!_mainSocket.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            // 서버 ip 주소와 메세지를 담도록 만든다.
            IPEndPoint ip = (IPEndPoint)_mainSocket.LocalEndPoint;
            string addr = ip.Address.ToString();

            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] bDts = Encoding.UTF8.GetBytes(addr + '\x01' + stringData);

            // 서버에 전송한다.
            _mainSocket.Send(bDts);

            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            Console.WriteLine(string.Format("[보냄]{0}: {1}", addr, stringData));
        }

        /// <summary>
        /// 이미지 프레임별로 서버에서 넘어오는 데이터를 DB에 저장
        /// </summary>
        /// <param name="receiveMessage">서버에서 넘어온 메세지</param>
        private void InsertInspectionRecord(string receiveMessage)
        {
            try
            {
                string site = Properties.Settings.Default.Site;
                string lotNo = receiveMessage.Split(',')[0];
                string recordNo = receiveMessage.Split(',')[1];
                string fileName = receiveMessage.Split(',')[1] + ".png";
                int frameNo = Convert.ToInt32(receiveMessage.Split(',')[2]);

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SITE", site);
                parameters.Add("@RECORDNO", recordNo);
                parameters.Add("@LOTNO", lotNo);
                parameters.Add("@FILENAME", fileName);
                parameters.Add("@FRAMENO", frameNo);

                SqlParameter[] deleteSqlPamaters = _dbManager.GetSqlParameters(parameters);
                SqlParameter[] insertSqlPamaters = _dbManager.GetSqlParameters(parameters);

                int deleteResult;

                while (_deleteFlag)
                {
                    deleteResult = _dbManager.CallNonSelectProcedure("USP_DELETE_XRAYDECIPHER_INSPECTRECORD", deleteSqlPamaters);
                    if (deleteResult > 0) Console.WriteLine("프레임데이터 삭제성공!");                  
                    else Console.WriteLine("프레임데이터 삭제실패!");

                    _deleteFlag = false;
                }

                int saveResult = _dbManager.CallNonSelectProcedure("USP_INSERT_XRAYDECIPHER_INSPECTRECORD", insertSqlPamaters);
                if (saveResult > 0)  Console.WriteLine("프레임데이터 저장성공!");                
                else Console.WriteLine("프레임데이터 저장실패!");              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
