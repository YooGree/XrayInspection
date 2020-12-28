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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XrayInspection.UserControls
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-08
    /// 설        명  : AI 판정이력 화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_AIjubgmentHistory : UserControl
    {
        #region 변수

        int _lastRowIndex = -1; // 마지막 행의 Index
        DataTable _OriginalSearchDt = new DataTable(); // 조회된 데이터 최초 테이블
        DataTable _searchDt = new DataTable(); // 조회후 행 추가를 하기위한 테이블

        /// <summary>
        /// 행 상태 타입
        /// </summary>
        private enum rowChangeType
        {
            NORMAL, 
            CREATE, 
            MODIFIY, 
            DELETE
        }

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public CS_AIjubgmentHistory()
        {
            InitializeComponent();
            InitializeControlSetting();
            InitializeGrid();
            InitializeEvent();
            Search();
        }

        #endregion

        #region 이벤트

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            btnExport.Click += BtnExport_Click;
            btnSearch.Click += BtnSearch_Click;

            grdAIjubgmentHistory.RowPostPaint += GrdAIjubgmentHistory_RowPostPaint;
        }

        /// <summary>
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIjubgmentHistory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, grdAIjubgmentHistory.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), grdAIjubgmentHistory.RowHeadersDefaultCellStyle.Font, rect, grdAIjubgmentHistory.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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
                if (grdAIjubgmentHistory.Rows.Count == 0)
                {
                    DialogResult result = MsgBoxHelper.Show("엑셀 데이터가 없습니다.");
                }
                else
                {
                    sfd.Filter = "csv(*.csv) | *.csv";

                    DialogResult result = MsgBoxHelper.Show("엑셀 저장 하시겠습니까?");

                    if (result == DialogResult.OK)
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            this.SaveCsv(sfd.FileName, grdAIjubgmentHistory, true);
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

            DialogResult result = MsgBoxHelper.Show("저장 되었습니다.");
        }

        #endregion

        #region 조회

        /// <summary>
        /// 조회버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 조회
        /// </summary>
        public void Search()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site
                parameters.Add(new SqlParameter("@CUSTOMERNAME", txtCustomerName.Text)); // 고객명
                parameters.Add(new SqlParameter("@PRODUCTNUMBER", txtProductNumber.Text)); // 도번
                parameters.Add(new SqlParameter("@FRDATE", dateFrom.Value.ToString("yyyy-MM-dd"))); // 조회일자(From)
                parameters.Add(new SqlParameter("@TODATE", dateTo.Value.ToString("yyyy-MM-dd"))); // 조회일자(To)
                parameters.Add(new SqlParameter("@LOTNUMBER", txtLotNumber.Text)); // LOT 번호

                // 전체조회
                if (radioAll.Checked == true)
                {
                    parameters.Add(new SqlParameter("@STATE", "ALL")); // 상태        
                }
                // 정상조회
                else if (radioNormal.Checked == true)
                {
                    parameters.Add(new SqlParameter("@STATE", "NORMAL")); // 상태
                }
                // 불량조회
                else
                {
                    parameters.Add(new SqlParameter("@STATE", "DEFECT")); // 상태
                }

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_AIJUBGMENTHISTORY", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    _searchDt = ds.Tables[0];
                    _OriginalSearchDt = _searchDt.Copy();
                    grdAIjubgmentHistory.DataSource = _searchDt;
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }

        }

        #endregion

        #region 저장

        /// <summary>
        /// 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 그리드뷰에 행이 한개도 없으면 Return
            if (grdAIjubgmentHistory.Rows.Count == 0)
            {
                MsgBoxHelper.Show("저장할 데이터가 없습니다.");
                return;
            }
            else
            {
                // 조회해온 데이터가 없을경우
                if (_searchDt.Rows.Count == 0)
                {
                    foreach (DataGridViewRow viewRow in grdAIjubgmentHistory.Rows)
                    {
                        if (viewRow.Cells["PRODUCTID"].Value == null)
                        {
                            MsgBoxHelper.Show("품목ID가 누락된 행이 있습니다.");
                            return;
                        }
                    }
                }
                // 조회해온 데이터가 있을경우
                else
                {
                    // 그리드에 신규, 수정, 삭제행이 없으면 Return
                    if ((grdAIjubgmentHistory.DataSource as DataTable).AsEnumerable().Where(r => r["ROWTYPE"].Equals("CREATE")
                                                                                              || r["ROWTYPE"].Equals("MODIFIY")
                                                                                              || r["ROWTYPE"].Equals("DELETE")).Count() == 0)
                    {
                        MsgBoxHelper.Show("저장할 데이터가 없습니다.");
                        return;
                    }
                    // 필수 키값이 입력되지 않았다면 Return
                    if ((grdAIjubgmentHistory.DataSource as DataTable).AsEnumerable().Where(r => r["PRODUCTID"].Equals(null)
                                                                                              || r["PRODUCTID"].Equals("")
                                                                                              || r["PRODUCTID"].Equals(DBNull.Value)).Count() > 0)
                    { 
                        MsgBoxHelper.Show("품목ID가 누락된 행이 있습니다.");
                        return;
                    }
                }
            }

            if (MsgBoxHelper.Show("저장 하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DBManager dbManager = new DBManager();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SAVEDATATABLE", grdAIjubgmentHistory.DataSource as DataTable);

                SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_AIJUBGMENTHISTORY", sqlPamaters);

                if (SaveResult > 0)
                {
                    MsgBoxHelper.Show("저장하였습니다.");
                    Search(); // 재조회
                }
                else
                {
                    MsgBoxHelper.Show("저장에 실패하였습니다.");
                }
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
            radioAll.Checked = true; // 조회조건 기본 전체로 세팅
            dateTo.Value = DateTime.Now; // 조회조건의 To 날짜는 오늘로 세팅
            dateFrom.Value = DateTime.Now.AddDays(-7); // 조회조건의 From 날짜는 To 날짜의 7일전으로 세팅
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdAIjubgmentHistory.AutoGenerateColumns = false;
            grdAIjubgmentHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdAIjubgmentHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdAIjubgmentHistory.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "Site", "SITE", "SITE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "고객", "CUSTOMER", "CUSTOMER", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "도번", "PRODUCTCODE", "PRODUCTCODE", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "품번", "PRODUCTID", "PRODUCTID", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "LOT번호", "LOTID", "LOTID", typeof(string), 250, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "검사일자", "INSPECTIONDATE", "INSPECTIONDATE", typeof(string), 200, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "최종판정", "LASTRESULT", "LASTRESULT", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "AI판정", "AIRESULT", "AIRESULT", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "불량유형", "DEFECTTYPE", "DEFECTTYPE", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        #endregion

        #region Test

        /// <summary>
        /// MSAccess 테스트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTest_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\05. 조선내화 프로젝트\02.Document\MSAccess\XDB.mdb";
            OleDbConnection conn = new OleDbConnection(connStr);

            string sqlStr = "SELECT * FROM T품명마스타";
            OleDbDataAdapter adp = new OleDbDataAdapter(sqlStr, conn);
            adp.Fill(ds);

            grdAIjubgmentHistory.DataSource = ds.Tables[0];
        }

        #endregion
    }
}
