using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrayInspection.UserControls;

namespace XrayInspection.PopUp
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-28
    /// 설        명  : Xray 이미지 판독화면
    /// 이        력  : 2021-01-14 유태근 / 이력에서 수정할 수 있도록 기능추가
    /// </summary>
    public partial class CS_XrayImagePopup : ParentsPop
    {
        #region 변수

        DBManager _dbManager = new DBManager(); // XRAY_DB 연결객체
        private DataGridViewRow _currentRow;
        Mat _frame = new Mat();
        VideoCapture _video = null;
        bool _stopFlag = true;
        bool _endFlag = true;
        string _makeDirectory = string.Empty;
        string _fileName = string.Empty;
        string _filePath = string.Empty;

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public CS_XrayImagePopup(DataGridViewRow currentRow)
        {
            _currentRow = currentRow;
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
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;

            btnStartEnd.Click += BtnStart_Click;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;

            btnJudgmentResult.Click += CommonPopup_Click;
            btnDetailClass.Click += CommonPopup_Click;
            btnDetailCode.Click += CommonPopup_Click;
            btnDetailPart.Click += CommonPopup_Click;

            grdAIDecipherStatus.SelectionChanged += GrdAIDecipherStatus_SelectionChanged;
        }

        /// <summary>
        /// AI 판정이력 그리드의 행 변경시 해당 프레임에 해당하는 이미지 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIDecipherStatus_SelectionChanged(object sender, EventArgs e)
        {
            int frameNo;

            // 마지막 프레임일때
            if (grdAIDecipherStatus.CurrentRow.Index == 0)
            {
                frameNo = _video.FrameCount;
            }
            // 그 외의 프레임일때
            else
            {
                frameNo = Convert.ToInt32(grdAIDecipherStatus.CurrentRow.Cells["FRAMENO"].Value);
            }

            try
            {
                int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());
                _video.PosFrames = frameNo - 1;
                //_video.PosFrames = (int)(_video.PosFrames / saveCheckCount) * saveCheckCount - saveCheckCount - 1;
                _video.Read(_frame);

                Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(picMain.Width, picMain.Height));

                picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);

                lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 앞으로
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            //_stopFlag = true;
            //btnStartEnd.Text = "시작";

            try
            {
                if (!_stopFlag && btnStartEnd.Text.Equals("정지"))
                {
                    MsgBoxHelper.Show("정지 후 진행해주세요.");
                    return;
                }

                int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());
                _video.PosFrames = (int)(_video.PosFrames / saveCheckCount) * saveCheckCount - 1;
                _video.Read(_frame);

                Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(picMain.Width, picMain.Height));

                picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);

                //DirectoryInfo directory = new DirectoryInfo(_makeDirectory + "//bad");

                //if (directory.Exists == false) directory.Create();

                //string saveFileName = _makeDirectory + "//" + _video.PosFrames.ToString() + ".png";
                //if (File.Exists(saveFileName)) File.Delete(saveFileName);

                //string deleteFileName = directory + "//" + _video.PosFrames.ToString() + ".png";
                //if (File.Exists(deleteFileName)) File.Delete(deleteFileName);

                if (_video.FrameCount - _video.PosFrames < saveCheckCount)
                    _video.PosFrames = _video.FrameCount - 1;
                else
                    _video.PosFrames = _video.PosFrames + saveCheckCount - 1;

                _video.Read(_frame);

                Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(picMain.Width, picMain.Height));

                if (typeof(Mat).Equals(_frame))
                    picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);

                lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 뒤로
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            //_stopFlag = true;
            //btnStartEnd.Text = "시작";

            try
            {
                if (!_stopFlag && btnStartEnd.Text.Equals("정지"))
                {
                    MsgBoxHelper.Show("정지 후 진행해주세요.");
                    return;
                }

                int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());
                _video.PosFrames = (int)(_video.PosFrames / saveCheckCount) * saveCheckCount - saveCheckCount - 1;
                _video.Read(_frame);

                Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(picMain.Width, picMain.Height));

                picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);

                lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 시작/멈춤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            // 시작 -> 정지(시작상태)
            if (_stopFlag)
            {
                _stopFlag = false;
                btnStartEnd.Text = "정지";

                // 이미지 슬라이싱
                FileSlicing();
            }
            // 정지 -> 시작(정지상태)
            else
            {
                _stopFlag = true;
                btnStartEnd.Text = "시작";
            }
        }

        /// <summary>
        /// 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            _endFlag = true;
            this.Close();
        }

        #endregion

        #region 조회

        /// <summary>
        /// 화면 최초 로드시 AI판독정보 조회
        /// </summary>
        public void AIJudgmentInfoFrameRecordSearch()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site
                parameters.Add(new SqlParameter("@LOTNO", _currentRow.Cells["LOTID"].Value)); // LOT NO

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_AIJUDGMENTINFO", parameters);

                if (ds.Tables.Count == 0) Console.WriteLine("AI 판독현황 조회실패!");
                else grdAIDecipherStatus.DataSource = ds.Tables[0];              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region 저장

        /// <summary>
        /// AI 판독결과 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MsgBoxHelper.Show("저장 하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@SITE", Properties.Settings.Default.Site);
                    parameters.Add("@LOTNO", _currentRow.Cells["LOTID"].Value.ToString());
                    parameters.Add("@INSPECTORID", comboInspector.SelectedValue);
                    parameters.Add("@MAKERID", comboMaker.SelectedValue);
                    parameters.Add("@JUDGMENTRESULTID", txtJudgmentResult.Tag);
                    parameters.Add("@DETAILCLASSID", txtDetailClass.Tag);
                    parameters.Add("@DETAILCLASSNAME", txtDetailClass.Text);
                    parameters.Add("@DETAILCODEID", txtDetailCode.Tag);
                    parameters.Add("@DETAILCODENAME", txtDetailCode.Text);
                    parameters.Add("@DETAILPARTID", txtDetailPart.Tag);
                    parameters.Add("@DETAILPARTNAME", txtDetailPart.Text);
                    parameters.Add("@LOCATION", txtLocation.Text);
                    parameters.Add("@COMMENT", txtComment.Text);

                    SqlParameter[] sqlParameters = _dbManager.GetSqlParameters(parameters);

                    int saveResult = _dbManager.CallNonSelectProcedure("USP_UPDATE_AIJUBGMENTHISTORY_AIJUDGMENTRESULT", sqlParameters);
                    if (saveResult > 0)
                    {
                        Console.WriteLine("AI 판독결과 수정성공!");
                        _endFlag = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else Console.WriteLine("AI 판독결과 수정실패!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion

        #region 사용자 정의 함수

        /// <summary>
        /// 컨트롤 라벨세팅
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="type"></param>
        private void InitializeControlSetting()
        {
            // Footer 안보이게 처리
            Footer.Visible = false;

            // 폼 제목 설정
            lblTitle.Text = "X-Ray 이미지 조회 및 이미지 판정";

            // 라벨 - 정상인지 불량인지 표시
            lblResult.Text = _currentRow.Cells["LASTRESULT"].Value.ToString();
            if (_currentRow.Cells["LASTRESULT"].Value.ToString() == "합격")
                lblResult.ForeColor = Color.CornflowerBlue;
            else
                lblResult.ForeColor = Color.Crimson;

            // 콤보박스 설정
            BindingList<object> frameCount = new BindingList<object>();
            frameCount.Add(new { Text = "1", Value = "1" });
            frameCount.Add(new { Text = "2", Value = "2" });
            frameCount.Add(new { Text = "3", Value = "3" });
            frameCount.Add(new { Text = "6", Value = "6" });
            frameCount.Add(new { Text = "9", Value = "9" });
            frameCount.Add(new { Text = "15", Value = "15" });
            frameCount.Add(new { Text = "30", Value = "30" });
            comboFrameCount.DataSource = frameCount;
            comboFrameCount.DisplayMember = "Text";
            comboFrameCount.ValueMember = "Value";
            comboFrameCount.SelectedValue = "3";
            comboFrameCount.DropDownStyle = ComboBoxStyle.DropDownList;

            // 검사자 콤보박스 데이터 바인딩
            InspectorInfoSearch();

            // 성형자 콤보박스 데이터 바인딩
            MakerInfoSearch();

            // 특정경로에 저장된 동영상파일 불러오기
            GetMediaFile();

            // AI 판독결과 프레임 레코드 데이터 조회
            AIJudgmentInfoFrameRecordSearch();

            // AI 판독결과 데이터 바인딩
            AIJudgmentInfoSearch();
        }

        /// <summary>
        /// 동영상 파일 불러오기
        /// </summary>
        private void GetMediaFile()
        {
            string fileName = _currentRow.Cells["LOTID"].Value.ToString() + ".mp4";
            string filePath = Properties.Settings.Default.VideoPath;

            // 테스트 필요
            //NG일때
            //if (_currentRow.Cells["LASTRESULTCODE"].Value.ToString() == "3")
            //{
            //    filePath = Properties.Settings.Default.NGVideoPath;
            //}
            //OK일때
            //else
            //{
            //    filePath = Properties.Settings.Default.OKVideoPath;
            //}

            _fileName = fileName;
            _filePath = filePath;
            lblFileName.Text = fileName;

            // 영상의 첫 프레임을 슬라이싱하여 썸네일로 보여주기
            _video = new VideoCapture(filePath + fileName);

            int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());

            //_makeDirectory = filePath + fileName.Substring(0, fileName.LastIndexOf(".")).Trim();

            //DirectoryInfo directory = new DirectoryInfo(_makeDirectory);

            //if (directory.Exists == false) directory.Create();
            
            _video.Read(_frame);
            lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();

            try
            {
                //Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(_frame.Width, _frame.Height));
                Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(picMain.Width, picMain.Height));

                //string saveFileName = directory + "//" + _video.PosFrames.ToString() + ".png";
                picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);
                //Cv2.ImWrite(saveFileName, _frame);

                //string deleteFileName = _makeDirectory + "//bad//" + _video.PosFrames.ToString() + ".png";

                //if (File.Exists(deleteFileName))
                //{
                //    File.Delete(deleteFileName);
                //}

                Cv2.WaitKey(150);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// 영상파일 이미지로 슬라이징 시작(이미지 파일로 저장 안하는 Ver)
        /// </summary>
        private void FileSlicing()
        {
            // 동영상 썸네일 다시세팅
            if (_endFlag)
            {
                GetMediaFile();
                _endFlag = false;
            }

            // 슬라이싱 시작
            int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());

            while (true)
            {
                if (_endFlag)
                {
                    return;
                }

                if (_stopFlag)
                {
                    Cv2.WaitKey(150);
                    continue;
                }

                _video.Read(_frame);

                lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();

                if (!_frame.Empty())
                {
                    try
                    {
                        Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(picMain.Width, picMain.Height));

                        if (_video.PosFrames % saveCheckCount == 0)
                        {
                            picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);
                            Cv2.WaitKey(150);
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.Error(ex.Message);
                    }
                }
                else
                {
                    _stopFlag = true;
                    _endFlag = true;
                    btnStartEnd.Text = "시작";
                    break;
                }
            }
        }

        /// <summary>
        /// 영상파일 이미지로 슬라이징 시작(이미지 파일로 저장 Ver)
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        private void FileSlicing(string filePath, string fileName)
        {
            // 해당 디렉터리의 파일모두 삭제
            DirectoryInfo dir = new DirectoryInfo(_makeDirectory);
            FileInfo[] files = dir.GetFiles("*.*", SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                file.Attributes = FileAttributes.Normal;
                file.Delete();
            }

            // 동영상 썸네일 다시세팅
            if (_endFlag)
            {
                GetMediaFile();
                _endFlag = false;
            }

            // 슬라이싱 시작
            int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());

            _makeDirectory = filePath + fileName.Substring(0, fileName.LastIndexOf(".")).Trim();

            DirectoryInfo directory = new DirectoryInfo(_makeDirectory);

            if (directory.Exists == false) directory.Create();
            
            while (true)
            {
                if (_endFlag)
                {
                    return;
                }

                if (_stopFlag)
                {
                    Cv2.WaitKey(150);
                    continue;
                }

                _video.Read(_frame);

                lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();

                if (!_frame.Empty())
                {
                    try
                    {
                        Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(picMain.Width, picMain.Height));

                        if (_video.PosFrames % saveCheckCount == 0)
                        {
                            string saveFileName = directory + "//" + _video.PosFrames.ToString() + ".png";
                            picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);
                            Cv2.ImWrite(saveFileName, _frame);

                            string deleteFileName = _makeDirectory + "//bad//" + _video.PosFrames.ToString() + ".png";

                            if (File.Exists(deleteFileName)) File.Delete(deleteFileName);
                            
                            Cv2.WaitKey(150);
                        }
                    }
                    catch (Exception ex) 
                    {
                        MsgBoxHelper.Error(ex.Message);
                    }
                }
                else
                {
                    //MsgBoxHelper.Show("이미지 슬라이싱 완료");
                    _stopFlag = true;
                    _endFlag = true;
                    btnStartEnd.Text = "시작";
                    break;
                }
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
            grdAIDecipherStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdAIDecipherStatus.MultiSelect = false;
            grdAIDecipherStatus.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            grdAIDecipherStatus.DefaultCellStyle.SelectionForeColor = Color.Black;

            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "Frame", "FRAMENO", "FRAMENO", typeof(int), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "AI판정", "AIRESULT", "AIRESULT", typeof(string), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "유형", "TYPE", "TYPE", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
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
        /// 화면 최초 로드시 성형자 조회
        /// </summary>
        public void MakerInfoSearch()
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site

                DataSet ds = _dbManager.CallSelectProcedure_ds("USP_SELECT_MAKERINFO", parameters);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    // 조회조건 콤보박스 세팅
                    comboMaker.DataSource = ds.Tables[0];
                    comboMaker.DisplayMember = "USERNAME";
                    comboMaker.ValueMember = "USERID";
                    comboMaker.SelectedIndex = 0;
                    comboMaker.DropDownStyle = ComboBoxStyle.DropDownList;

                    if (ds.Tables.Count == 0)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            comboMaker.SelectedValue = ds.Tables[0].Rows[0]["USERID"].ToString();
                            comboMaker.Text = ds.Tables[0].Rows[0]["USERNAME"].ToString();
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
        /// AI 판독결과 바인딩
        /// </summary>
       private void AIJudgmentInfoSearch()
        {
            comboInspector.SelectedValue = _currentRow.Cells["INSPECTORID"].Value;
            comboMaker.SelectedValue = _currentRow.Cells["MAKERID"].Value;
            txtJudgmentResult.Tag = _currentRow.Cells["LASTRESULTCODE"].Value;
            txtJudgmentResult.Text = _currentRow.Cells["LASTRESULT"].Value.ToString();
            txtDetailClass.Tag = _currentRow.Cells["DETAILCLASSID"].Value;
            txtDetailClass.Text = _currentRow.Cells["DETAILCLASSTEXT"].Value.ToString();
            txtDetailCode.Tag = _currentRow.Cells["DETAILCODE"].Value;
            txtDetailCode.Text = _currentRow.Cells["DETAILTEXT"].Value.ToString();
            txtDetailPart.Tag = _currentRow.Cells["DEFECTPART"].Value;
            txtDetailPart.Text = _currentRow.Cells["DEFECTPARTTEXT"].Value.ToString();
            txtLocation.Text = _currentRow.Cells["LOCATION"].Value.ToString();
            txtComment.Text = _currentRow.Cells["COMMENTS"].Value.ToString();
        }

        #endregion

        #region 공통팝업

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
                    commonPopup.Show();
                    commonPopup.Activate();
                    commonPopup.FormClosed += (formSender, formE) =>
                    {
                        if (commonPopup._returnIsOK)
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
                        }
                    };
                    break;

                // 항목(불량코드 중분류)
                case "btnDetailClass":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "MIDDLE", "항목", "4");
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    commonPopup.Show();
                    commonPopup.Activate();
                    commonPopup.FormClosed += (formSender, formE) =>
                    {
                        if (commonPopup._returnIsOK)
                        {
                            if (txtDetailClass.Tag.ToString() != commonPopup._returnCodeValue)
                            {
                                txtDetailCode.Tag = "";
                                txtDetailCode.Text = "";
                            }
                            txtDetailClass.Tag = commonPopup._returnCodeValue;
                            txtDetailClass.Text = commonPopup._returnNameValue;
                        }
                    };
                    break;

                // 세부항목(불량코드 소분류)
                case "btnDetailCode":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "DETAIL", "세부항목", txtDetailClass.Tag.ToString());
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    commonPopup.Show();
                    commonPopup.Activate();
                    commonPopup.FormClosed += (formSender, formE) =>
                    {
                        if (commonPopup._returnIsOK)
                        {
                            txtDetailCode.Tag = commonPopup._returnCodeValue;
                            txtDetailCode.Text = commonPopup._returnNameValue;
                        }
                    };
                    break;

                // 부위(불량코드 중분류)
                case "btnDetailPart":
                    commonPopup = new CS_CommonPopup("USP_SELECT_XRAYDECIPHER_POPUP_AIJUDGMENTRESULT", "MIDDLE", "부위", "5");
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    commonPopup.Show();
                    commonPopup.Activate();
                    commonPopup.FormClosed += (formSender, formE) =>
                    {
                        if (commonPopup._returnIsOK)
                        {
                            txtDetailPart.Tag = commonPopup._returnCodeValue;
                            txtDetailPart.Text = commonPopup._returnNameValue;
                        }
                    };
                    break;
            }
        }

        #endregion
    }
}
