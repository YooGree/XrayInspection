using MaskManager.PopUp;
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

namespace MaskManager.UserControls
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
        }

        #endregion

        #region 이벤트

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            btnExport.Click += BtnExport_Click;
            btnAddRow.Click += BtnAddRow_Click;
            btnDeleteRow.Click += BtnDeleteRow_Click;
            btnSearch.Click += BtnSearch_Click;
            btnSave.Click += BtnSave_Click;

            grdAIjubgmentHistory.RowPostPaint += GrdAIjubgmentHistory_RowPostPaint;
            grdAIjubgmentHistory.CellValueChanged += GrdAIjubgmentHistory_CellValueChanged;
            grdAIjubgmentHistory.CellBeginEdit += GrdAIjubgmentHistory_CellBeginEdit;
        }

        /// <summary>
        /// 키값 수정불가하도록 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIjubgmentHistory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            
            foreach (DataRow row in _OriginalSearchDt.Rows)
            {
                if (dgv.Rows[e.RowIndex].Cells["PRODUCTID"].Value.Equals(row["PRODUCTID"]))
                {
                    if (dgv.Columns[e.ColumnIndex].Name.Equals("PRODUCTID"))
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        /// <summary>
        /// 셀값을 변경할때 행을 수정상태로 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIjubgmentHistory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAIjubgmentHistory.Rows[e.RowIndex].Cells["ROWTYPE"].Value.ToString() == "NORMAL")
            {
                DataRow frRow = _OriginalSearchDt.Rows[e.RowIndex];
                DataRow toRow = _searchDt.Rows[e.RowIndex];

                if (!CompareDataRow(frRow, toRow))
                {
                    grdAIjubgmentHistory.Rows[e.RowIndex].Cells["ROWTYPE"].Value = rowChangeType.MODIFIY;
                    grdAIjubgmentHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Plum;
                }
            }
        }

        /// <summary>
        /// 최조 조회된 행과 변경된 행의 비교
        /// </summary>
        /// <param name="prevRow"></param>
        /// <param name="curRow"></param>
        /// <returns></returns>
        private bool CompareDataRow(DataRow prevRow, DataRow curRow)
        {
            bool rValue = true;

            foreach (DataColumn c in prevRow.Table.Columns)
            {
                string cName = c.ColumnName;

                if (prevRow[cName].Equals(curRow[cName]))
                    continue;
                else
                {
                    rValue = false;
                    break;
                }
            }
            return rValue;
        }

        /// <summary>
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIjubgmentHistory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            grdAIjubgmentHistory.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        /// <summary>
        /// 현재 선택된 Row 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            // 신규행이 아니라면 행타입만 바꿔주기
            if (grdAIjubgmentHistory.Rows[grdAIjubgmentHistory.CurrentCellAddress.Y].Cells["ROWTYPE"].Value.ToString() != "CREATE")
            {
                grdAIjubgmentHistory.Rows[grdAIjubgmentHistory.CurrentCellAddress.Y].Cells["ROWTYPE"].Value = rowChangeType.DELETE;
                grdAIjubgmentHistory.Rows[grdAIjubgmentHistory.CurrentCellAddress.Y].DefaultCellStyle.BackColor = Color.Crimson;
            }
            // 신규행이라면 행자체를 지우기
            else
            {
                for (int i = 0; i < grdAIjubgmentHistory.Rows.Count; i++)
                {
                    // 행 선택 여부
                    grdAIjubgmentHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    if (grdAIjubgmentHistory.Rows[i].Selected == true)
                    {
                        // 현재 선택된 인덱스에 해당된 Row 삭제
                        grdAIjubgmentHistory.Rows.Remove(grdAIjubgmentHistory.Rows[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Row 추가 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            _lastRowIndex = _searchDt.Rows.Count;

            if (_searchDt.Rows.Count == 0)
            {
                grdAIjubgmentHistory.Rows.Add();
                grdAIjubgmentHistory.EndEdit();
            }
            else
            {
                _searchDt.Rows.Add();
                grdAIjubgmentHistory.DataSource = _searchDt;
                grdAIjubgmentHistory.EndEdit();
            }

            grdAIjubgmentHistory.Rows[grdAIjubgmentHistory.Rows.Count - 1].Cells["ROWTYPE"].Value = rowChangeType.CREATE;
            grdAIjubgmentHistory.Rows[grdAIjubgmentHistory.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
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

            DialogResult result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "저장 되었습니다.");
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
        private void Search()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@CUSTOMERNAME", txtCustomerName.Text)); // 고객명
                parameters.Add(new SqlParameter("@PRODUCTNUMBER", txtProductNumber.Text)); // 도번
                parameters.Add(new SqlParameter("@FRDATE", dateFrom.Value)); // 조회일자(From)
                parameters.Add(new SqlParameter("@TODATE", dateTo.Value)); // 조회일자(To)
                parameters.Add(new SqlParameter("@LOTNUMBER", txtLotNumber.Text)); // LOT 번호

                // 전체조회
                if (radioAll.Checked == true)
                {
                    parameters.Add(new SqlParameter("@STATE", "ALL")); // 상태        
                }
                // 정상조회
                else if (radioNormal.Checked = true)
                {
                    parameters.Add(new SqlParameter("@STATE", "NORMAL")); // 상태
                }
                // 불량조회
                else
                {
                    parameters.Add(new SqlParameter("@STATE", "DEFECT")); // 상태
                }

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_AIJUBGMENTHISTORY");

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
                CustomMessageBox.Show(MessageBoxButtons.OK, "닫기", ex.Message);
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
                CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
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
                            CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "품목ID가 누락된 행이 있습니다.");
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
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                        return;
                    }
                    // 필수 키값이 입력되지 않았다면 Return
                    if ((grdAIjubgmentHistory.DataSource as DataTable).AsEnumerable().Where(r => r["PRODUCTID"].Equals(null)
                                                                                              || r["PRODUCTID"].Equals("")
                                                                                              || r["PRODUCTID"].Equals(DBNull.Value)).Count() > 0)
                    { 
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "품목ID가 누락된 행이 있습니다.");
                        return;
                    }
                }
            }

            if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "저장", "저장 하시겠습니까?") == DialogResult.OK)
            {
                DBManager dbManager = new DBManager();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SAVEDATATABLE", grdAIjubgmentHistory.DataSource as DataTable);

                SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_AIJUBGMENTHISTORY", sqlPamaters);

                if (SaveResult > 0)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장하였습니다.");
                    Search(); // 재조회
                }
                else
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장에 실패하였습니다.");
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

            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "No", "No", "No", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "품목ID", "PRODUCTID", "PRODUCTID", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "고객", "PRODUCTTYPE", "rackid", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "도번", "PRODUCTNAME", "durableid", typeof(int), 180, false, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "품번", "PRODUCTNO", "productname", typeof(string), 180, false, true, DataGridViewContentAlignment.MiddleCenter, 80);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "LOT번호", "CUSTOMERNAME", "inputdate", typeof(string), 250, false, true, DataGridViewContentAlignment.MiddleCenter, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "검사일자", "CREATOR", "inputresult", typeof(string), 200, false, true, DataGridViewContentAlignment.MiddleCenter, 35);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "최종판정", "CREATETIME", "usedate", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "AI판정", "MODIFIER", "usedate", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "불량유형", "MODIFIEDTIME", "usedate", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 60);
        }

        #endregion

    }
}
