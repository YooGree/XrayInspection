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
    public partial class CS_AIjudgmentStatus : UserControl
    {
        #region 변수

        DBManager _dbManager = new DBManager();

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public CS_AIjudgmentStatus()
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
            grdJobInfo.RowPostPaint += GrdJobInfo_RowPostPaint;
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
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdJobInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, grdJobInfo.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), grdJobInfo.RowHeadersDefaultCellStyle.Font, rect, grdJobInfo.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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
                if (grdJobInfo.Rows.Count == 0)
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
                            this.SaveCsv(sfd.FileName, grdJobInfo, true);
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
        private void InspectionCurrentStateSrarch()
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
        private void ProductInfoSearch()
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
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("제품정보 조회실패!");
            }
        }

        /// <summary>
        /// 작업현황 조회
        /// </summary>
        private void JobInfoSearch()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); 
                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_AIJUDGMENTSTATUS_WORKORDERINFO", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    grdJobInfo.DataSource = ds.Tables[0];

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["LotState"].ToString() == "READY")
                        {
                            grdJobInfo.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
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

            // 작업현황 조회
            JobInfoSearch();
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

            // 작업현황 조회
            JobInfoSearch();
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdJobInfo.DefaultCellStyle.ForeColor = Color.Black;

            grdJobInfo.AutoGenerateColumns = false;
            grdJobInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdJobInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdJobInfo.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "순번", "InspectSequence", "InspectSequence", typeof(int), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "거래처", "Customer", "Customer", typeof(string), 200, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "사용처", "UsedPlace", "UsedPlace", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "품명", "ProductID", "ProductID", typeof(string), 220, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "도번", "ProductCode", "ProductCode", typeof(string), 80, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "생산년도", "MakeYear", "MakeYear", typeof(string), 80, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "Input LotID", "InputLotID", "InputLotID", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "LotID", "LotID", "LotID", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "성형자", "Maker", "Maker", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "검사자", "Inspector", "Inspector", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "진행상태", "LotState", "LotState", typeof(string), 80, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "판독결과", "LastResult", "LastResult", typeof(string), 80, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdJobInfo, "작업시간", "ModifiedTime", "ModifiedTime", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        #endregion
    }
}
