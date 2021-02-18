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
using System.Text.RegularExpressions;
using OpenCvSharp;

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
        DBManager _dbManager = new DBManager(); // XRAY_DB 연결객체
        AIDBManager _aiDbManager = new AIDBManager(); // AI_DB 연결객체
        Timer _searchTimer = new Timer();
        string _lotState; // 현재 LOT상태
        string _originalLotId; // 최초검색 LOT ID
        string _workorderNumber; // 현재 WorkOrder번호
        string _customerName; // 고객명
        string _productType; // 제품구분
        string _productCode; // 도번
        string _productWeight; // 단중
        object _startTime; // 판독시작시간
        string _workuserCreatTime; // 근무조 변경시간  

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
            btnDetailClass.Click += CommonPopup_Click;
            btnDetailCode.Click += CommonPopup_Click;
            btnDetailPart.Click += CommonPopup_Click;

            btnStart.Click += BtnStart_Click;
            btnStart.EnabledChanged += BtnEnabledChanged;
            btnEnd.Click += BtnEnd_Click;
            btnEnd.EnabledChanged += BtnEnabledChanged;
            btnJudgmentComplete.Click += BtnJudgmentComplete_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnPass.Click += BtnPass_Click;
            btnModifiedLotNo.Click += BtnModifiedLotNo_Click;
            btnModifiedComment2.Click += BtnModifiedComment2_Click;

            txtLotSize.KeyPress += KeyPressRequiredInt;
            txtPlanPageCount.KeyPress += KeyPressRequiredInt;
            comboSaveVideoPath.SelectedValueChanged += ComboSaveVideoPath_SelectedValueChanged;
        }

        /// <summary>
        /// 드라이브 경로가 바뀔때마다 해당 경로의 용량을 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboSaveVideoPath_SelectedValueChanged(object sender, EventArgs e)
        {
            GetDriveSize(comboSaveVideoPath.Text);
        }

        /// <summary>
        /// 비고 수정팝업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModifiedComment2_Click(object sender, EventArgs e)
        {
            CS_ModifiedCommentPopup lotPopup = new CS_ModifiedCommentPopup(txtProductCode.Text, txtComment2.Text);
            lotPopup.WindowState = FormWindowState.Normal;
            lotPopup.StartPosition = FormStartPosition.CenterScreen;
            if (lotPopup.ShowDialog() == DialogResult.OK)
            {
                txtComment2.Text = lotPopup._currentComment;
                //Rebinding();
            }
        }

        /// <summary>
        /// LOT NO 수정팝업
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModifiedLotNo_Click(object sender, EventArgs e)
        {
            CS_ModifiedLotPopup lotPopup = new CS_ModifiedLotPopup(txtLotNo.Text);
            lotPopup.WindowState = FormWindowState.Normal;
            lotPopup.StartPosition = FormStartPosition.CenterScreen;
            if (lotPopup.ShowDialog() == DialogResult.OK)
            {
                Rebinding();
            }
        }

        /// <summary>
        /// 텍스트박스에서 숫자만 입력 가능하도록 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyPressRequiredInt(object sender, KeyPressEventArgs e)
        {
            // 숫자만 입력되도록 필터링(숫자와 백스페이스를 제외한 나머지를 바로 처리)
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 합격버튼으로 바로 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPass_Click(object sender, EventArgs e)
        {
            // 녹화중인 데이터가 없다면 알림
            if (grdAIDecipherStatus.Rows.Count == 0)
            {
                MsgBoxHelper.Show("현재 녹화중인 데이터가 없습니다." + Environment.NewLine + "먼저 녹화를 시작, 종료한 후 진행해주세요.");
                return;
            }
            // 녹화 진행중이라면 알림
            else if (!btnStart.Enabled && btnEnd.Enabled)
            {
                MsgBoxHelper.Show("현재 녹화 진행중입니다." + Environment.NewLine + "녹화를 종료한 후 진행해주세요.");
                return;
            }
            // LOT크기와 계획본수를 입력하지 않았다면 알림
            else if (txtLotSize.Text.Trim() == "0" || txtPlanPageCount.Text.Trim() == "0"
                    || txtLotSize.Text.Trim() == "" || txtPlanPageCount.Text.Trim() == "")
            {
                MsgBoxHelper.Show("LOT크기와 계획본수는 필수입력입니다.");
                return;
            }
            // 합격이 아닌 상태를 입력했는데 원클릭합격을 눌렀다면 알림
            else if (txtJudgmentResult.Tag.ToString().Trim() != "0" && txtJudgmentResult.Tag.ToString().Trim() != "")
            {
                MsgBoxHelper.Show("현재 입력된 판정결과가 합격(0)이 아닙니다. \n합격(0)이 아닌경우에는 판정완료 버튼을 눌러서 진행해주세요.");
                return;

                //if (MsgBoxHelper.Show("현재 입력된 판정결과가 합격(0)이 아닙니다. \n그래도 합격처리 하시겠습니까?", MessageBoxButtons.YesNo) == DialogResult.No)
                //{
                //    return;
                //}
            }
            // 계획본수 대비 진행순번이 초과한다면 알림
            //else if (Convert.ToInt32(txtPlanPageCount.Text.Trim()) < Convert.ToInt32(txtProgressSequence.Text.Trim()))
            //{
            //    MsgBoxHelper.Show("계획본수보다 진행순번이 높기때문에 진행 불가능합니다.");
            //    return;
            //}

            try
            {
                txtJudgmentResult.Tag = "0";
                txtJudgmentResult.Text = "합격";
                txtDetailClass.Tag = "";
                txtDetailClass.Text = "";
                txtDetailCode.Tag = "";
                txtDetailCode.Text = "";
                txtDetailPart.Tag = "";
                txtDetailPart.Text = "";

                CS_LoadingForm loadingForm = new CS_LoadingForm();
                BackgroundWorker worker = new BackgroundWorker(); 

                worker.DoWork += (doworkSender, args) =>
                {
                    // 크로스 쓰레드 문제 해결을 위한 Invoke
                    this.Invoke(new Action(delegate ()
                    {
                        JudgmentComplete(); // 백그라운드로 실행할 메소드 이벤트 생성                  
                    }));
                };

                worker.RunWorkerCompleted += (completeSender, args) =>
                {
                    System.Threading.Thread.Sleep(2000);
                    loadingForm.Close(); // 종료시 실행할 이벤트

                    if (string.IsNullOrWhiteSpace(txtProductCode.Text.Trim()))
                    {
                        MsgBoxHelper.Show("다음작업이 등록되어있지 않습니다. 작업계획을 등록해주세요.");
                    }
                };
                
                worker.RunWorkerAsync(); // 백그라운드로 비동기 실행
                loadingForm.ShowDialog(); // 로딩폼 나타내기
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// 녹화시작, 종료버튼 활성화 유무에 따라 색깔처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                // 녹화시작
                case "btnStart":
                    btn.Text = btn.Enabled == false ? "녹화중" : "녹화시작(-)";
                    btn.ForeColor = btn.Enabled == false ? Color.Black : Color.White;
                    btn.BackColor = btn.Enabled == false ? Color.Yellow : Color.Red;
                    break;

                // 녹화종료
                case "btnEnd":
                    btn.ForeColor = btn.Enabled == false ? Color.Black : Color.White;
                    btn.BackColor = btn.Enabled == false ? Color.Yellow : Color.Blue;
                    break;
            }
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
            // 녹화중인 데이터가 없다면 알림
            if (grdAIDecipherStatus.Rows.Count == 0)
            {
                MsgBoxHelper.Show("현재 녹화중인 데이터가 없습니다." + Environment.NewLine + "먼저 녹화를 시작, 종료한 후 진행해주세요.");
                return;
            }
            // 녹화 진행중이라면 알림
            else if (!btnStart.Enabled && btnEnd.Enabled)
            {
                MsgBoxHelper.Show("현재 녹화 진행중입니다." + Environment.NewLine + "녹화를 종료한 후 진행해주세요.");
                return;
            }
            // 판독결과를 입력하지 않았다면 알림
            else if (string.IsNullOrWhiteSpace(txtJudgmentResult.Text))
            {
                MsgBoxHelper.Show("판독결과는 필수입력입니다.");
                return;
            }
            // LOT크기와 계획본수를 입력하지 않았다면 알림
            else if (txtLotSize.Text.Trim() == "0" || txtPlanPageCount.Text.Trim() == "0" 
                    || txtLotSize.Text.Trim() == "" || txtPlanPageCount.Text.Trim() == "")
            {
                MsgBoxHelper.Show("LOT크기와 계획본수는 필수입력입니다.");
                return;
            }
            // 계획본수 대비 진행순번이 초과한다면 알림
            //else if (Convert.ToInt32(txtPlanPageCount.Text.Trim()) < Convert.ToInt32(txtProgressSequence.Text.Trim()))
            //{
            //    MsgBoxHelper.Show("계획본수보다 진행순번이 높기때문에 진행 불가능합니다.");
            //    return;
            //}
            // 판독결과가 합격(0)이 아닌경우, 항목, 세부항목, 부위 필수입력 알림
            else if (txtJudgmentResult.Tag.ToString().Trim() != "0")
            {
                if (string.IsNullOrWhiteSpace(txtDetailClass.Text)
                    || string.IsNullOrWhiteSpace(txtDetailCode.Text)
                    || string.IsNullOrWhiteSpace(txtDetailPart.Text))
                {
                    MsgBoxHelper.Show("판독결과가 합격(0)이 아닌경우 항목, 세부항목, 부위는 필수입력입니다.");
                    return;
                }
            }

            try
            {
                CS_LoadingForm loadingForm = new CS_LoadingForm();
                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += (doworkSender, args) =>
                {
                    // 크로스 쓰레드 문제 해결을 위한 Invoke
                    this.Invoke(new Action(delegate ()
                    {
                        JudgmentComplete(); // 백그라운드로 실행할 메소드 이벤트 생성
                    }));
                };

                worker.RunWorkerCompleted += (completeSender, args) =>
                {
                    System.Threading.Thread.Sleep(2000);
                    loadingForm.Close(); // 종료시 실행할 이벤트

                    if (string.IsNullOrWhiteSpace(txtProductCode.Text.Trim()))
                    {
                        MsgBoxHelper.Show("다음작업이 등록되어있지 않습니다. 작업계획을 등록해주세요.");
                    }
                };

                worker.RunWorkerAsync(); // 백그라운드로 비동기 실행
                loadingForm.ShowDialog(); // 로딩폼 나타내기
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// 영상녹화종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            EndRecording();
        }

        /// <summary>
        /// 영상녹화시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BtnStart_Click(object sender, EventArgs e)
        {
            // MC_LotInspect에 Ready인 데이터가 없다면 녹화시작 불가능
            if (string.IsNullOrWhiteSpace(txtProductCode.Text)
                || string.IsNullOrWhiteSpace(txtLotNo.Text))
            {
                MsgBoxHelper.Show("현재 시작 가능한 LOT이 없습니다. 작업계획을 등록해주세요.");
                return;
            }

            if (grdAIDecipherStatus.Rows.Count == 0)
            {
                StartRecording();
            }
            else
            {
                if (MsgBoxHelper.Show("이미 진행한 녹화가 있습니다. 다시 녹화를 시작하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    StartRecording();
                }
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
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "TOP", "판정결과");
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    if (commonPopup.ShowDialog() == DialogResult.OK)
                    {
                        // 판독결과가 합격이라면 항목, 세부항목, 부위, 위치 Enable, ReadOnly
                        if (commonPopup._returnCodeValue == "0")
                        {
                            // 항목
                            txtDetailClass.Tag = "";
                            txtDetailClass.Text = "";
                            btnDetailClass.Enabled = false;
                            // 세부항목
                            txtDetailCode.Tag = "";
                            txtDetailCode.Text = "";
                            btnDetailCode.Enabled = false;
                            // 부위
                            txtDetailPart.Tag = "";
                            txtDetailPart.Text = "";
                            btnDetailPart.Enabled = false;
                            // 위치
                            txtLocation.ReadOnly = true;
                            txtLocation.Text = "";
                        }
                        // 판독결과가 위에 해당하지 않는다면 항목, 세부항목, 부위, 위치 입력할 수 있도록
                        else
                        {
                            btnDetailClass.Enabled = true;
                            btnDetailCode.Enabled = true;
                            btnDetailPart.Enabled = true;
                            txtLocation.ReadOnly = false;
                        }

                        if (txtJudgmentResult.Tag.ToString() != commonPopup._returnCodeValue)
                        {
                            txtDetailClass.Tag = "";
                            txtDetailClass.Text = "";
                            txtDetailCode.Tag = "";
                            txtDetailCode.Text = "";
                            txtDetailPart.Tag = "";
                            txtDetailPart.Text = "";
                        }

                        txtJudgmentResult.Tag = commonPopup._returnCodeValue;
                        txtJudgmentResult.Text = commonPopup._returnNameValue;

                        // 2021-01-19 유태근 - 판독결과가 합격이 아니라면 그 이후 팝업 자동 호출될 수 있도록
                        if (commonPopup._returnCodeValue != "0") btnDetailClass.PerformClick();                   
                    }
                    break;

                // 항목(불량코드 중분류)
                case "btnDetailClass":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "MIDDLE", "항목", "4");
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    if (commonPopup.ShowDialog() == DialogResult.OK)
                    {
                        if (txtDetailClass.Tag.ToString() != commonPopup._returnCodeValue)
                        {
                            txtDetailCode.Tag = "";
                            txtDetailCode.Text = "";
                        }
                        txtDetailClass.Tag = commonPopup._returnCodeValue;
                        txtDetailClass.Text = commonPopup._returnNameValue;

                        // 2021-01-19 유태근 - 그 이후 팝업 자동 호출될 수 있도록
                        btnDetailCode.PerformClick();
                    }
                    break;

                // 세부항목(불량코드 소분류)
                case "btnDetailCode":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "DETAIL", "세부항목", txtDetailClass.Tag.ToString());
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    if (commonPopup.ShowDialog() == DialogResult.OK)
                    {
                        txtDetailCode.Tag = commonPopup._returnCodeValue;
                        txtDetailCode.Text = commonPopup._returnNameValue;

                        // 2021-01-19 유태근 - 그 이후 팝업 자동 호출될 수 있도록
                        btnDetailPart.PerformClick();
                    }
                    break;

                // 부위(불량코드 중분류)
                case "btnDetailPart":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "MIDDLE", "부위", "5");
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    if (commonPopup.ShowDialog() == DialogResult.OK)
                    {
                        txtDetailPart.Tag = commonPopup._returnCodeValue;
                        txtDetailPart.Text = commonPopup._returnNameValue;

                        // 2021-01-19 유태근 - 부위 최종선택 후 위치로 포커스 강제이동
                        txtLocation.Focus();
                    }
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
                Console.WriteLine(ex.Message);
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
                        txtUser.Tag = ds.Tables[0].Rows[0]["MAKERID"].ToString();
                        txtLotNo.Text = ds.Tables[0].Rows[0]["LOTID"].ToString();
                        txtSequenceByPallet.Text = ds.Tables[0].Rows[0]["INSPECTSEQUENCE"].ToString() + " / " + ds.Tables[0].Rows[0]["PALLETCOUNT"].ToString(); // 파렛트 순번

                        // 검사계획/진행현황
                        List<SqlParameter> parameters2 = new List<SqlParameter>();
                        parameters2.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site
                        parameters2.Add(new SqlParameter("@PRODUCTCODE", txtProductCode.Text)); // 도번
                        DataSet ds2 = _dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_SHIFTWORKINFO", parameters2);

                        txtLotSize.Text = "0";
                        txtInspectionStd.Text = "0";
                        txtPlanPageCount.Text = "0";
                        txtSequenceByProduct.Text = "1";
                        txtComment2.Text = "";

                        if (ds2.Tables.Count > 0)
                        {
                            if (ds2.Tables[0].Rows.Count > 0) 
                            {
                                txtLotSize.Text = ds2.Tables[0].Rows[0]["PRODUCTIONQTY"].ToString(); // LOT크기
                                txtInspectionStd.Text = ds2.Tables[0].Rows[0]["INSPECTRATE"].ToString(); // 검사기준(%)
                                txtPlanPageCount.Text = ds2.Tables[0].Rows[0]["INSPECTQTY"].ToString(); // 계획본수
                                txtSequenceByProduct.Text = ds2.Tables[0].Rows[0]["INSPECTSEQUENCE"].ToString() + " / " + ds2.Tables[0].Rows[0]["INSPECTQTY"].ToString(); // 제품별 순번
                                txtComment2.Text = ds2.Tables[0].Rows[0]["COMMENTS"].ToString(); // 비고
                            }
                        }

                        _lotState = ds.Tables[0].Rows[0]["LOTSTATE"].ToString(); // 현재 LOT상태
                        _originalLotId = ds.Tables[0].Rows[0]["LOTID"].ToString(); // 최초 검색 LOT ID
                        _workorderNumber = ds.Tables[0].Rows[0]["WORKORDERNUMBER"].ToString(); // WorkOrder 번호
                        _customerName = ds.Tables[0].Rows[0]["CUSTOMERNAME"].ToString(); // 고객명
                        _productType = ds.Tables[0].Rows[0]["PRODUCTTYPE"].ToString(); // 제품타입
                        _productCode = ds.Tables[0].Rows[0]["PRODUCTCODE"].ToString(); // 도번
                        _productWeight = ds.Tables[0].Rows[0]["PRODUCTWEIGHT"].ToString(); // 단중
                        if (!ds.Tables[0].Rows[0]["STARTTIME"].Equals(DBNull.Value))
                            _startTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["STARTTIME"]).ToString("yyyyMMddHHmmss"); // 판독시작시간
                        else
                            _startTime = DBNull.Value;
                    }
                    else
                    {
                        txtCustomer.Text = "";
                        txtUsedPlace.Text = "";
                        txtProductName.Text = "";
                        txtProductCode.Text = "";
                        txtUser.Text = "";
                        txtUser.Tag = "";
                        txtLotNo.Text = "";
                        txtSequenceByPallet.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    // 2021-01-05 유태근 - 검사자의 근무조는 작업계획등록에서 바꾸지 않는 한 판정화면에서는 고정
                    string shiftiD = ds.Tables[0].AsEnumerable().Where(r => r["USERID"].Equals(comboInspector.SelectedValue)).CopyToDataTable().Rows[0]["SHIFTID"].ToString();
                    comboInspector.Tag = shiftiD;
                    txtShift.Text = shiftiD;
                    _workuserCreatTime = ds.Tables[0].AsEnumerable().Where(r => r["USERID"].Equals(comboInspector.SelectedValue)).CopyToDataTable().Rows[0]["WORKUSERCREATEDTIME"].ToString();

                    //comboInspector.SelectedValueChanged += (s, e) =>
                    //{
                    //    string shiftId = ds.Tables[0].AsEnumerable().Where(r => r["USERID"].Equals(comboInspector.SelectedValue)).CopyToDataTable().Rows[0]["SHIFTID"].ToString();
                    //    comboInspector.Tag = shiftId;
                    //};

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
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 화면 최초 로드시 합격경로 조회
        /// </summary>
        public void SavePassVideoPathSearch()
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site
                parameters.Add(new SqlParameter("@TYPE", "OK")); 

                DataSet ds = _dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_SAVEVIDEOPATH", parameters);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // 조회조건 콤보박스 세팅
                        comboSaveVideoPath.DataSource = ds.Tables[0];
                        comboSaveVideoPath.Tag = ds.Tables[0].Rows[0]["RELATIVEPATH"];
                        comboSaveVideoPath.DisplayMember = "PATH";
                        comboSaveVideoPath.ValueMember = "SEQUENCE";
                        comboSaveVideoPath.SelectedIndex = 0;
                        comboSaveVideoPath.DropDownStyle = ComboBoxStyle.DropDownList;
                        comboSaveVideoPath.SelectedValueChanged += (s, e) =>
                        {
                            comboSaveVideoPath.Tag = ds.Tables[0].AsEnumerable().Where(r => r["SEQUENCE"].Equals(comboSaveVideoPath.SelectedValue)).CopyToDataTable().Rows[0]["RELATIVEPATH"].ToString();
                        };
                    }

                    // 드라이브 용량 가져오기 
                    GetDriveSize(ds.Tables[0].Rows[0]["PATH"].ToString());
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 드라이브 찾기
        /// </summary>
        private void GetDriveSize(string path)
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                string selectDriveName = string.Empty;

                // 본사 내부 테스트용(로컬 드라이브 기준)
                if (path.Contains("C:/")) selectDriveName = "C";
                else if (path.Contains("D:/")) selectDriveName = "D";

                // 조선내화 프로그램 적용(네트워크 드라이브 기준)
                //if (path.Contains("//J//")) selectDriveName = "J";
                //else if (path.Contains("//G//")) selectDriveName = "G";
                //else if (path.Contains("//H//")) selectDriveName = "H";
                //else if (path.Contains("//I//")) selectDriveName = "I";
                //else if (path.Contains("//K//")) selectDriveName = "K";

                foreach (DriveInfo drive in drives)
                {
                    if (drive.DriveType == DriveType.Fixed)
                    //if (drive.DriveType == DriveType.Network)
                    {
                        if (drive.Name.Contains(selectDriveName))
                        {
                            SetDriveSize(drive, proDriveSize, lblDriveSize);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 드라이브 전체용량, 사용량, 남은용량 구하기
        /// </summary>
        private void SetDriveSize(DriveInfo drive, ProgressBar pro, Label lb)
        {
            string driveName = string.Empty;
            string totalSize = string.Empty;
            string freeSize = string.Empty;
            string usage = string.Empty;

            try
            {
                driveName = drive.Name.Substring(0, 1);
                totalSize = Convert.ToInt32(drive.TotalSize / 1024 / 1024 / 1024).ToString(); // 전체용량
                freeSize = Convert.ToInt32(drive.AvailableFreeSpace / 1024 / 1024 / 1024).ToString(); // 남은용량
                usage = (Convert.ToInt32(totalSize) - Convert.ToInt32(freeSize)).ToString(); // 사용용량

                pro.Maximum = Convert.ToInt32(totalSize);
                pro.Value = Convert.ToInt32(usage);

                lb.Text = string.Format("{0}GB 중 {1}GB 사용가능", totalSize, freeSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Xray 판독화면 전체데이터 리바인딩
        /// </summary>
        public void Rebinding()
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
            txtDetailClass.Tag = "";
            txtDetailClass.Text = "";
            txtDetailCode.Tag = "";
            txtDetailCode.Text = "";
            txtDetailPart.Tag = "";
            txtDetailPart.Text = "";
            txtLocation.Text = "";
            txtComment.Text = "";

            // 검사계획/진행현황 조회(추가예정)

            // 2021-01-20 유태근 - 녹화경로 조회추가
            SavePassVideoPathSearch();

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
        /// 검사계획/진행현황 변경
        /// </summary>
        private void UpdateInspectPlan()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@INSERFLAG", txtSequenceByProduct.Text == "1" ? "Y" : "N");
                parameters.Add("@SITE", Properties.Settings.Default.Site);
                parameters.Add("@SHIFTID", comboInspector.Tag);
                parameters.Add("@PRODUCTCODE", _productCode);
                parameters.Add("@LOTSIZE", Convert.ToInt32(txtLotSize.Text));
                parameters.Add("@INSPECTQTY", txtPlanPageCount.Text);
                parameters.Add("@INSPECTRATE", Convert.ToInt32(txtInspectionStd.Text));
                parameters.Add("@COMMENTS", txtComment2.Text);

                SqlParameter[] sqlParameters = _dbManager.GetSqlParameters(parameters);

                int saveResult = _dbManager.CallNonSelectProcedure("USP_UPSERT_XRAYDECIPHER_INSPECTPLAN", sqlParameters);
                if (saveResult > 0) Console.WriteLine("검사계획 수정성공!");
                else Console.WriteLine("검사계획 수정실패!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 합격동영상 경로 변경
        /// </summary>
        private void UpdateSaveVideoPath()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SITE", Properties.Settings.Default.Site);
                parameters.Add("@SEQUENCE", comboSaveVideoPath.SelectedValue);

                SqlParameter[] sqlParameters = _dbManager.GetSqlParameters(parameters);

                int saveResult = _dbManager.CallNonSelectProcedure("USP_UPDATE_XRAYDECIPHER_SAVEVIDEOPATH", sqlParameters);
                if (saveResult > 0) Console.WriteLine("동영상 저장경로 수정성공!");
                else Console.WriteLine("동영상 저장경로 수정실패!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }     

        /// <summary>
        /// 기존 LOTID 사용자가 입력한 LOTID로 변경
        /// </summary>
        private void UpdateLotNo()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SITE", Properties.Settings.Default.Site);
                parameters.Add("@ORIGINALLOTNO", _originalLotId.Trim());
                parameters.Add("@CURRENTLOTNO", txtLotNo.Text.Trim());

                SqlParameter[] sqlParameters = _dbManager.GetSqlParameters(parameters);

                int saveResult = _dbManager.CallNonSelectProcedure("USP_UPDATE_XRAYDECIPHER_LOTNO", sqlParameters);
                if (saveResult > 0)
                {
                    Console.WriteLine("LOTID 수정성공!");
                    _originalLotId = txtLotNo.Text.Trim();
                } 
                else Console.WriteLine("LOTID 수정실패!");
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
                // MSAccessDB에 데이터 저장
                InsertMSAccessDataByNonProduct();

                string filePath = "";

                if (txtJudgmentResult.Tag.Equals("3")) filePath = Properties.Settings.Default.NGVideoPath;
                else filePath = comboSaveVideoPath.Text;

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SITE", Properties.Settings.Default.Site);
                parameters.Add("@LOTNO", txtLotNo.Text);
                parameters.Add("@INSPECTORID", comboInspector.SelectedValue);
                parameters.Add("@INSPECTORNAME", comboInspector.Text);
                parameters.Add("@SHIFTID", comboInspector.Tag);
                parameters.Add("@JUDGMENTRESULTID", txtJudgmentResult.Tag);
                parameters.Add("@JUDGMENTRESULTNAME", txtJudgmentResult.Text);
                parameters.Add("@DETAILCLASSID", txtDetailClass.Tag);
                parameters.Add("@DETAILCLASSNAME", txtDetailClass.Text);
                parameters.Add("@DETAILCODEID", txtDetailCode.Tag);
                parameters.Add("@DETAILCODENAME", txtDetailCode.Text);
                parameters.Add("@DETAILPARTID", txtDetailPart.Tag);
                parameters.Add("@DETAILPARTNAME", txtDetailPart.Text);
                parameters.Add("@LOCATION", txtLocation.Text);
                parameters.Add("@COMMENT", txtComment.Text);
                parameters.Add("@AIRESULTCODE", "(TEST)CODE_OK");
                parameters.Add("@AIRESULTCODENAME", "(TEST)CODENAME_OK");
                parameters.Add("@FILEPATH", filePath);

                SqlParameter[] sqlParameters = _dbManager.GetSqlParameters(parameters);

                int saveResult = _dbManager.CallNonSelectProcedure("USP_UPDATE_XRAYDECIPHER_AIJUDGMENTRESULT", sqlParameters);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// 영상녹화 시작시 해당 LOT의 레코드 데이터 최초삭제
        /// </summary>
        private void DeleteInspectionRecord()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SITE", Properties.Settings.Default.Site);
                parameters.Add("@LOTNO", txtLotNo.Text.Trim());

                SqlParameter[] deleteSqlPamaters = _dbManager.GetSqlParameters(parameters);

                int deleteResult = _dbManager.CallNonSelectProcedure("USP_DELETE_XRAYDECIPHER_INSPECTRECORD", deleteSqlPamaters);
                if (deleteResult > 0) Console.WriteLine("프레임데이터 삭제성공!");
                else Console.WriteLine("프레임데이터 삭제실패!");
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
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

            // 2021-01-20 유태근 - 녹화경로 조회추가
            SavePassVideoPathSearch();

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

            if (btnStart.Text.Contains("..."))
            {
                btnStart.Text = btnStart.Text.Replace(".", "");
            }
            else
            {
                btnStart.Text += ".";
            }
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdAIDecipherStatus.DefaultCellStyle.ForeColor = Color.Black;

            grdAIDecipherStatus.AutoGenerateColumns = false;
            grdAIDecipherStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdAIDecipherStatus.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdAIDecipherStatus.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "Frame", "FRAMENO", "FRAMENO", typeof(int), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "AI판정", "AIRESULT", "AIRESULT", typeof(string), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "유형", "TYPE", "TYPE", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        /// <summary>
        /// 영상녹화시작 메서드
        /// </summary>
        private void StartRecording()
        {
            // 최초조회 LOT ID랑 현재 TextBox의 LOT ID랑 다른지 Check
            if (!_originalLotId.Trim().Equals(txtLotNo.Text.Trim()))
            {
                // 현재 MC_Lotinspect 테이블에 중복되는 LOT ID가 있는지 Check
                if (!IsOverlapLotId(txtLotNo.Text.Trim()))
                {
                    // MC_LotInspect의 LOT ID 수정
                    UpdateLotNo();
                }
                else
                {
                    MsgBoxHelper.Show("현재 수정하려는 LOTID는 이미 존재하는 LOTID입니다.");
                    return;
                }
            }

            // 녹화중에는 LOT ID 수정불가능
            // txtLotNo.ReadOnly = true;

            // 시작시간이 없다면 화면에서 시작버튼을 누른 시간을 시작시간으로 세팅
            if (_startTime.Equals(DBNull.Value))
            {
                _startTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else
            {
                if (_startTime is DateTime)
                    _startTime = Convert.ToDateTime(_startTime).ToString("yyyyMMddHHmmss");
            }

            // MC_InspectRecord 테이블에 해당 LOT에 해당하는 데이터 삭제
            DeleteInspectionRecord();

            // 녹화서버에 메세지 전송
            string sendData = "START " + txtLotNo.Text + "," + txtProductName.Text;
            OnSendData(sendData);

            // 버튼활성화, 비활성화
            btnStart.Enabled = false;
            btnEnd.Enabled = true;

            // 타이머 시작
            _searchTimer.Start();

            // LOT상태 RUN으로 변경 및 시작시간 변경
            UpdateLotState();
        }

        /// <summary>
        /// 영상녹화종료 메서드
        /// </summary>
        private void EndRecording()
        {
            // LOT ID 수정가능
            // txtLotNo.ReadOnly = false;

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
        /// MC_LotInspect에 중복되는 LOT ID가 있는지 체크
        /// </summary>
        /// <param name="lotNo"></param>
        /// <returns></returns>
        private bool IsOverlapLotId(string lotNo)
        {
            bool returnFlag = true;

            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); 
                parameters.Add(new SqlParameter("@LOTNO", lotNo)); 

                DataSet ds = _dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_ISOVERLAPLOTID", parameters);

                if (ds.Tables.Count > 0)
                {
                    Console.WriteLine("중복 LOT ID 검색성공");

                    if (ds.Tables[0].Rows.Count > 0) returnFlag = true;
                    else returnFlag = false;
                }
                else
                {
                    Console.WriteLine("중복 LOT ID 검색실패");
                    returnFlag = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnFlag;
        }

        /// <summary>
        /// 판정결과를 토대로 동영상 파일의 OK, NG 폴더로 분기(복사)
        /// </summary>
        private void VideoMoveDirectory()
        {
            try
            {
                string OriginalPath = Properties.Settings.Default.VideoPath + txtLotNo.Text + ".mp4";
                string CopyPath;

                // 비디오가 해당경로에 재생가능한 상태인지 체크
                // if (!VideoFileCheck(OriginalPath)) return;

                // 합격(OK)
                if (txtJudgmentResult.Tag.Equals("0") || txtJudgmentResult.Tag.Equals("1") || txtJudgmentResult.Tag.Equals("2"))

                {
                    //CopyPath = Properties.Settings.Default.OKVideoPath + txtLotNo.Text + ".mpeg";
                    CopyPath = comboSaveVideoPath.Text + txtLotNo.Text + ".mpeg";
                    File.Copy(OriginalPath, CopyPath, true);
                    File.Delete(OriginalPath);
                }
                // 불합격(NG)
                else
                {
                    CopyPath = Properties.Settings.Default.NGVideoPath + txtLotNo.Text + ".mpeg";
                    File.Copy(OriginalPath, CopyPath, true);
                    File.Delete(OriginalPath);
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// 비디오가 해당 영상경로에 재생 가능한 상태로 존재하는지 확인
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool VideoFileCheck(string filePath)
        {
            bool flag = true;

            for (int i = 0; i < 5; i++)
            {
                VideoCapture video = new VideoCapture(filePath);
                Mat frame = new Mat();

                video.Read(frame);

                if (frame.Empty()) flag = false;
                else
                {
                    flag = true;
                    
                    video.Dispose();
                    break;
                }
                
                video.Dispose();
                System.Threading.Thread.Sleep(1000);
            }

            if (!flag)
            {
                MessageBox.Show("영상파일에 문제가 있습니다. \n재녹화가 필요합니다.");
            }

            return flag;
        }

        /// <summary>
        /// MSAccess DataBase에 검사정보를 넣는다.
        /// - 전제조건 : (MSAccess)T품목마스타 테이블의 F품명과 (MSSQL)MC_Product 테이블의 ProductID가 일치하는 데이터가 없으면 품명KEY를 9999로 넣어준다.
        /// </summary>
        private void InsertMSAccessDataByNonProduct()
        {
            // MSAccess DB 연결여부가 True일때만 분기
            if (Properties.Settings.Default.IsMSAccessConnect)
            {
                try
                {
                    DataSet ds = new DataSet();

                    string connStr = Properties.Settings.Default.MSAccessPath;
                    OleDbConnection conn = new OleDbConnection(connStr);
                    OleDbDataAdapter adp;

                    // TXRAY검사정보 테이블에 현재 날짜, 근무조, 도번에 해당하는 데이터가 있는지 확인
                    string InspectionInfoSelectSql = "SELECT  FMKEY " +
                                                     "FROM    TXRAY검사정보 " +
                                                     "WHERE   F검사일시 = '" + _workuserCreatTime.Trim() + "' " +
                                                     "AND     F근무조 = '" + txtShift.Text.Trim() + "' " +
                                                     "AND     F도번 = '" + _productCode.Trim() + "' ";

                    // TXRAY실데이타 테이블의 FMKEY컬럼
                    int fmKey = -1;

                    adp = new OleDbDataAdapter(InspectionInfoSelectSql, conn);
                    adp.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        // TXRAY검사정보 테이블에 데이터를 넣기위한 분기
                        if (ds.Tables[0].Rows.Count < 1)
                        {
                            DataSet productDs = new DataSet();

                            // T품목마스타 테이블에서 현재 품목명에 해당하는 F품명KEY를 조회(현재는 테이블에 키가 잡혀있지 않아 여러행이 검색됨)
                            string productSelectSql = "SELECT  FID " +
                                                      "FROM    T품명마스타 " +
                                                      "WHERE   F도번 = '" + txtProductCode.Text.Trim() + "'";

                            adp = new OleDbDataAdapter(productSelectSql, conn);
                            adp.Fill(productDs);

                            int fid = 0;

                            if (productDs.Tables.Count > 0)
                            {
                                // T품목마스타에 조회된 F품명KEY가 있으면 해당 F품명KEY로 세팅
                                if (productDs.Tables[0].Rows.Count > 0)
                                    fid = productDs.Tables[0].Rows[0].Field<int>("FID");
                                // T품목마스타에 조회된 F품명KEY가 없으면 9999로 F품명KEY로 세팅
                                else
                                    fid = 9999;
                            }

                            conn.Open();
                            string InspectionInfoInsertSql = "INSERT INTO TXRAY검사정보 (F품명KEY, F검사일시, F근무조, F고객명, F사용처, F제품구분, F품명, F도번, F단중, FLOT크기, FCIP, F검사기준, F도면재개정일, FWORKORDERNO) " +
                                                             "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                            var comm = new OleDbCommand(InspectionInfoInsertSql, conn);
                            comm.Parameters.AddWithValue("@F품명KEY", fid);
                            comm.Parameters.AddWithValue("@F검사일시", _workuserCreatTime);
                            comm.Parameters.AddWithValue("@F근무조", comboInspector.Tag);
                            comm.Parameters.AddWithValue("@F고객명", _customerName);
                            comm.Parameters.AddWithValue("@F사용처", txtUsedPlace.Text);
                            comm.Parameters.AddWithValue("@F제품구분", _productType);
                            comm.Parameters.AddWithValue("@F품명", txtProductName.Text);
                            comm.Parameters.AddWithValue("@F도번", _productCode);
                            comm.Parameters.AddWithValue("@F단중", _productWeight);
                            comm.Parameters.AddWithValue("@FLOT크기", Convert.ToInt32(txtLotSize.Text));
                            comm.Parameters.AddWithValue("@FCIP", "1");
                            comm.Parameters.AddWithValue("@F검사기준", "100");
                            comm.Parameters.AddWithValue("@F도면재개정", DateTime.Now.ToString("yyyyMMdd"));
                            comm.Parameters.AddWithValue("@FWORKORDERNO", _workorderNumber);

                            int cnt = comm.ExecuteNonQuery();
                            conn.Close();

                            // 다시 TXRAY검사정보 테이블을 조회하여 FMKEY세팅
                            DataSet newDs = new DataSet();

                            string InspectionInfoReSelectSql = "SELECT  FMKEY " +
                                                               "FROM    TXRAY검사정보 " +
                                                               "WHERE   F검사일시 = '" + _workuserCreatTime.Trim() + "' " +
                                                               "AND     F근무조 = '" + txtShift.Text.Trim() + "' " +
                                                               "AND     F도번 = '" + _productCode.Trim() + "' ";

                            adp = new OleDbDataAdapter(InspectionInfoReSelectSql, conn);
                            adp.Fill(newDs);

                            if (newDs.Tables.Count > 0)
                            {
                                if (newDs.Tables[0].Rows.Count > 0)
                                {
                                    fmKey = newDs.Tables[0].Rows[0].Field<int>("FMKEY");
                                }
                            }
                        }
                        // TXRAY검사정보 테이블에 이미 데이터가 있기때문에 FMKEY만 세팅
                        else
                        {
                            fmKey = ds.Tables[0].Rows[0].Field<int>("FMKEY");
                        }

                        // 2021-01-19 유태근 - LOT크기, 비고 TXRAY검사정보 테이블에 업데이트
                        DataSet updateDs = new DataSet();

                        string InspectionInfoUpdateSql = "UPDATE TXRAY검사정보 " +
                                                         "SET    FLOT크기 = '" + Convert.ToInt32(txtLotSize.Text.Trim()) + "' " +
                                                         "      ,F비고 = '" + txtComment2.Text + "' " +
                                                         "WHERE  F검사일시 = '" + _workuserCreatTime.Trim() + "' " +
                                                         "AND    F근무조 = '" + txtShift.Text.Trim() + "' " +
                                                         "AND    F도번 = '" + _productCode.Trim() + "' ";

                        adp = new OleDbDataAdapter(InspectionInfoUpdateSql, conn);
                        adp.Fill(updateDs);
                    }

                    // FMKEY가 삽입됬다면 XRAY실데이타 테이블에 데이터 삽입
                    if (fmKey != -1)
                    {
                        string pCnt = Regex.Replace(txtJudgmentResult.Tag.ToString().Trim(), @"[^0-9]", "");
                        string iCnt = Regex.Replace(txtDetailClass.Tag.ToString().Trim(), @"[^0-9]", "");
                        string passCntColumn = "F합격" + pCnt;
                        string itemCntColumn = txtDetailClass.Tag.ToString().Trim().Equals("") ? "F항목0" : "F항목" + iCnt;
                        string lastResult = (txtJudgmentResult.Tag.ToString().Trim() == "3") ? "부적합" : "합격";
                        string filePath = lastResult == "합격" ? comboSaveVideoPath.Tag + txtLotNo.Text + ".mpeg" : @".\DBMOVIE_E\" + txtLotNo.Text + ".mpeg";
                        //string filePath = lastResult == "합격" ? @".\DBMOVIE_J\" + txtLotNo.Text + ".mpeg" : @".\DBMOVIE_E\" + txtLotNo.Text + ".mpeg";
                        string contents = "";

                        if (string.IsNullOrWhiteSpace(txtDetailClass.Text) && string.IsNullOrWhiteSpace(txtDetailCode.Text))
                        {
                            contents = "";
                        }
                        else if (!string.IsNullOrWhiteSpace(txtDetailClass.Text) && string.IsNullOrWhiteSpace(txtDetailCode.Text))
                        {
                            contents = txtDetailClass.Text;
                        }
                        else if (!string.IsNullOrWhiteSpace(txtDetailClass.Text) && !string.IsNullOrWhiteSpace(txtDetailCode.Text))
                        {
                            contents = txtDetailClass.Text + "(" + txtDetailCode.Text + ")";
                        }
                        else if (string.IsNullOrWhiteSpace(txtDetailClass.Text) && !string.IsNullOrWhiteSpace(txtDetailCode.Text))
                        {
                            contents = "(" + txtDetailCode.Text + ")";
                        }

                        conn.Open();
                        string InspectionDataInsertSql = "INSERT INTO TXRAY실데이타 (FMKEY, F검사원, F성형자, F제품구분, F근무조, F검사일시, FLOTNO, F판독결과, " + passCntColumn + ", " + itemCntColumn + ", " + "F확인사항_항목, F확인사항_재질, F확인사항_위치, F판정, FPATH, F측정시작시간, F측정종료시간) " +
                                                         "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                        var comm = new OleDbCommand(InspectionDataInsertSql, conn);
                        comm.Parameters.AddWithValue("@FMKEY", fmKey);
                        comm.Parameters.AddWithValue("@F검사원", comboInspector.Text);
                        comm.Parameters.AddWithValue("@F성형자", txtUser.Tag.ToString());
                        comm.Parameters.AddWithValue("@F제품구분", _productType);
                        comm.Parameters.AddWithValue("@F근무조", comboInspector.Tag.ToString());
                        comm.Parameters.AddWithValue("@F검사일시", _workuserCreatTime);
                        comm.Parameters.AddWithValue("@FLOTNO", txtLotNo.Text);
                        comm.Parameters.AddWithValue("@F판독결과", Convert.ToInt32(txtJudgmentResult.Tag));
                        comm.Parameters.AddWithValue(passCntColumn, 1);
                        comm.Parameters.AddWithValue(itemCntColumn, txtDetailClass.Tag.ToString().Equals("") ? 0 : 1);
                        comm.Parameters.AddWithValue("@F확인사항_항목", contents);
                        comm.Parameters.AddWithValue("@F확인사항_재질", txtDetailPart.Text);
                        comm.Parameters.AddWithValue("@F확인사항_위치", txtLocation.Text);
                        comm.Parameters.AddWithValue("@F판정", lastResult);
                        comm.Parameters.AddWithValue("@FPATH", filePath);
                        comm.Parameters.AddWithValue("@F측정시작시간", _startTime);
                        comm.Parameters.AddWithValue("@F측정종료시간", DateTime.Now.ToString("yyyyMMddHHmmss"));

                        int cnt = comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    else return;
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.Error(ex.Message);
                }
            }
        }

        /// <summary>
        /// 판정완료 처리
        /// </summary>
        private void JudgmentComplete()
        {
            string OriginalPath = Properties.Settings.Default.VideoPath + txtLotNo.Text + ".mp4";

            // 비디오가 해당경로에 재생가능한 상태인지 체크
            if (!VideoFileCheck(OriginalPath)) return;

            // 판정결과 판단하여 동영상 OK 혹은 NG 폴더로 분기
            VideoMoveDirectory();

            // 검사계획/진행현황 변경
            UpdateInspectPlan();

            // 합격 동영상 저장경로 변경
            UpdateSaveVideoPath();

            // AI판정결과 저장 및 MSAccess DB 접근 
            UpdateAIJudgmentResult();

            // 데이터 재바인딩
            Rebinding();
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
                
                // 2021-01-20 최초 녹화시작시 중복키 에러로 주석처리(서버로부터 데이터를 받기 전 삭제처리로 수정)
                // 데이터 삭제
                //SqlParameter[] deleteSqlPamaters = _dbManager.GetSqlParameters(parameters);              

                //while (_deleteFlag)
                //{
                //    int deleteResult = _dbManager.CallNonSelectProcedure("USP_DELETE_XRAYDECIPHER_INSPECTRECORD", deleteSqlPamaters);
                //    if (deleteResult > 0) Console.WriteLine("프레임데이터 삭제성공!");                  
                //    else Console.WriteLine("프레임데이터 삭제실패!");

                //    _deleteFlag = false;
                //}

                SqlParameter[] insertSqlPamaters = _dbManager.GetSqlParameters(parameters);

                // 데이터 저장
                int saveResult = _dbManager.CallNonSelectProcedure("USP_INSERT_XRAYDECIPHER_INSPECTRECORD", insertSqlPamaters);              
                if (saveResult > 0)
                {
                    Console.WriteLine("프레임데이터 저장성공!");

                    // 2021-01-28 유태근 - AI Server 연결여부가 True일때 처리
                    if (Properties.Settings.Default.IsAIServerConnect)
                    {
                        string path = Properties.Settings.Default.ImagePath + lotNo + "_" + frameNo.ToString() + ".png";
                        string base64FileData = GetImage(path);

                        // AI_DB에 이미지 데이터 저장
                        Dictionary<string, object> aiParameters = new Dictionary<string, object>();
                        aiParameters.Add("@FILENAME", fileName);
                        aiParameters.Add("@FILEDATA", base64FileData);
                        aiParameters.Add("@TXNID", "XRAY_INSPECT");
                        aiParameters.Add("@USERID", "admin");
                        aiParameters.Add("@MACHINE", "1");
                        aiParameters.Add("@PRODID", txtProductCode.Text);
                        aiParameters.Add("@LOTID", lotNo);

                        SqlParameter[] aiSqlParameters = _aiDbManager.GetSqlParameters(aiParameters);

                        int aiSaveResult = _aiDbManager.CallNonSelectProcedure("AI_SET_IBA_RECORD_IMAGE", aiSqlParameters);
                        if (aiSaveResult > 0) Console.WriteLine("AI 데이터 저장성공!");
                        else Console.WriteLine("AI 데이터 저장실패!");
                    }
                }                            
                else Console.WriteLine("프레임데이터 저장실패!");              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        /// <summary>
        /// 이미지 파일을 byte[] 형식으로 변환한 뒤 Base64로 변형하여 저장
        /// </summary>
        /// <param name="path">파일경로</param>
        /// <returns></returns>
        private string GetImage(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] image = reader.ReadBytes((int)stream.Length);
            reader.Close();
            stream.Close();

            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(image);

            return base64String;
        }

        #endregion
    }
}
