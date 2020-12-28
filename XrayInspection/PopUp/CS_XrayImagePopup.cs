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
    /// 작   성   일  : 2020-12-23
    /// 설        명  : 공통팝업
    /// 이        력  : 
    /// </summary>
    public partial class CS_XrayImagePopup : ParentsPop
    {
        #region 변수

        private DataGridViewRow _currentRow;
        Mat _frame = new Mat();
        VideoCapture _video = null;
        bool _stopFlag = true;
        bool _endFlag = false;
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

            if (!_stopFlag && btnStartEnd.Text.Equals("정지"))
            {
                MsgBoxHelper.Show("정지 후 진행해주세요.");
                return;
            }           

            int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());
            _video.PosFrames = (int)(_video.PosFrames / saveCheckCount) * saveCheckCount - 1;
            _video.Read(_frame);
            picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);

            DirectoryInfo directory = new DirectoryInfo(_makeDirectory + "//bad");

            if (directory.Exists == false) directory.Create();
            
            string saveFileName = _makeDirectory + "//" + _video.PosFrames.ToString() + ".png";
            if (File.Exists(saveFileName)) File.Delete(saveFileName);
            
            string deleteFileName = directory + "//" + _video.PosFrames.ToString() + ".png";
            if (File.Exists(deleteFileName)) File.Delete(deleteFileName);

            _video.PosFrames = _video.PosFrames + saveCheckCount - 1;
            _video.Read(_frame);

            if (typeof(Mat).Equals(_frame))
            picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);

            lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();
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

            if (!_stopFlag && btnStartEnd.Text.Equals("정지"))
            {
                MsgBoxHelper.Show("정지 후 진행해주세요.");
                return;
            }

            int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());
            _video.PosFrames = (int)(_video.PosFrames / saveCheckCount) * saveCheckCount - saveCheckCount - 1;
            _video.Read(_frame);
            picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);

            lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();
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
                FileSlicing(_filePath, _fileName);
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

        /// <summary>
        /// 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {

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
            comboFrameCount.SelectedValue = "1";
            comboFrameCount.DropDownStyle = ComboBoxStyle.DropDownList;

            // 특정경로에 저장된 동영상파일 불러오기
            GetMediaFile();
        }

        /// <summary>
        /// 동영상 파일 불러오기
        /// </summary>
        private void GetMediaFile()
        {
            string fileName = _currentRow.Cells["LOTID"].Value.ToString() + ".mp4";
            string filePath = "D://05. 조선내화 프로젝트//01.Source//02.Server//videosource//bin//Debug//";
            _fileName = fileName;
            _filePath = filePath;
            lblFileName.Text = fileName;

            // 영상의 첫 프레임을 슬라이싱하여 썸네일로 보여주기
            _video = new VideoCapture(filePath + fileName);

            int saveCheckCount = 30 / int.Parse(comboFrameCount.SelectedValue.ToString());

            _makeDirectory = filePath + fileName.Substring(0, fileName.LastIndexOf(".")).Trim();

            DirectoryInfo directory = new DirectoryInfo(_makeDirectory);

            if (directory.Exists == false) directory.Create();
            
            _video.Read(_frame);
            lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();

            try
            {
                Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(_frame.Width, _frame.Height));

                string saveFileName = directory + "//" + _video.PosFrames.ToString() + ".png";
                picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);
                Cv2.ImWrite(saveFileName, _frame);

                string deleteFileName = _makeDirectory + "//bad//" + _video.PosFrames.ToString() + ".png";

                if (File.Exists(deleteFileName))
                {
                    File.Delete(deleteFileName);
                }

                Cv2.WaitKey(33);
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// 영상파일 이미지로 슬라이징 시작
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
            GetMediaFile();

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
                    Cv2.WaitKey(33);
                    continue;
                }

                _video.Read(_frame);

                lblFrame.Text = _video.PosFrames.ToString() + " / " + _video.FrameCount.ToString();

                if (!_frame.Empty())
                {
                    try
                    {
                        Cv2.Resize(_frame, _frame, new OpenCvSharp.Size(_frame.Width, _frame.Height));

                        if (_video.PosFrames % saveCheckCount == 0)
                        {
                            string saveFileName = directory + "//" + _video.PosFrames.ToString() + ".png";
                            picMain.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(_frame);
                            Cv2.ImWrite(saveFileName, _frame);

                            string deleteFileName = _makeDirectory + "//bad//" + _video.PosFrames.ToString() + ".png";

                            if (File.Exists(deleteFileName)) File.Delete(deleteFileName);
                            
                            Cv2.WaitKey(33);
                        }
                    }
                    catch 
                    {
                        MsgBoxHelper.Error("이미지 슬라이싱 실패");
                    }
                }
                else
                {
                    MsgBoxHelper.Show("이미지 슬라이싱 완료");
                    _stopFlag = true;
                    btnStartEnd.Text = "시작";
                    break;
                }
            }
        }

        #endregion
    }
}
