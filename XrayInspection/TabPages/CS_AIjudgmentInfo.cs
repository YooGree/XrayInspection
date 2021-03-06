﻿using XrayInspection.PopUp;
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

namespace XrayInspection.UserControls
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-08
    /// 설        명  : AI 판정정보 화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_AIjudgmentInfo : UserControl
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
        public CS_AIjudgmentInfo()
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
            //btnSearch.Click += BtnSearch_Click;
            //btnSave.Click += BtnSave_Click;

            grdFrameInfo.RowPostPaint += grdFrameInfo_RowPostPaint;
            grdFrameInfo.CellValueChanged += grdFrameInfo_CellValueChanged;
            grdFrameInfo.CellBeginEdit += GrdFrameInfo_CellBeginEdit;
        }

        /// <summary>
        /// 키값 수정불가하도록 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdFrameInfo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
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
        private void grdFrameInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdFrameInfo.Rows[e.RowIndex].Cells["ROWTYPE"].Value.ToString() == "NORMAL")
            {
                DataRow frRow = _OriginalSearchDt.Rows[e.RowIndex];
                DataRow toRow = _searchDt.Rows[e.RowIndex];

                if (!CompareDataRow(frRow, toRow))
                {
                    grdFrameInfo.Rows[e.RowIndex].Cells["ROWTYPE"].Value = rowChangeType.MODIFIY;
                    grdFrameInfo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Plum;
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

                if (!prevRow.Table.Columns.Contains(cName) || !curRow.Table.Columns.Contains(cName))
                    continue;

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
        private void grdFrameInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            grdFrameInfo.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        /// <summary>
        /// 현재 선택된 Row 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            // 신규행이 아니라면 행타입만 바꿔주기
            if (grdFrameInfo.Rows[grdFrameInfo.CurrentCellAddress.Y].Cells["ROWTYPE"].Value.ToString() != "CREATE")
            {
                grdFrameInfo.Rows[grdFrameInfo.CurrentCellAddress.Y].Cells["ROWTYPE"].Value = rowChangeType.DELETE;
                grdFrameInfo.Rows[grdFrameInfo.CurrentCellAddress.Y].DefaultCellStyle.BackColor = Color.Crimson;
            }
            // 신규행이라면 행자체를 지우기
            else
            {
                for (int i = 0; i < grdFrameInfo.Rows.Count; i++)
                {
                    // 행 선택 여부
                    grdFrameInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    if (grdFrameInfo.Rows[i].Selected == true)
                    {
                        // 현재 선택된 인덱스에 해당된 Row 삭제
                        grdFrameInfo.Rows.Remove(grdFrameInfo.Rows[i]);
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
            _searchDt.Rows.Add();
            grdFrameInfo.DataSource = _searchDt;

            grdFrameInfo.Rows[grdFrameInfo.Rows.Count - 1].Cells["ROWTYPE"].Value = rowChangeType.CREATE;
            grdFrameInfo.Rows[grdFrameInfo.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
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
                if (grdFrameInfo.Rows.Count == 0)
                {
                    DialogResult result = MsgBoxHelper.Show("엑셀 데이터가 없습니다.");
                }
                else
                {
                    sfd.Filter = "csv(*.csv) | *.csv";

                    DialogResult result = MsgBoxHelper.Show("엑셀 저장 하시겠습니까?", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            this.SaveCsv(sfd.FileName, grdFrameInfo, true);
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
        /// 조회
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
                    grdFrameInfo.DataSource = _searchDt;
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
            if (grdFrameInfo.Rows.Count == 0)
            {
                MsgBoxHelper.Show("저장할 데이터가 없습니다.");
                return;
            }
            else
            {
                // 조회해온 데이터가 없을경우
                if (_searchDt.Rows.Count == 0)
                {
                    foreach (DataGridViewRow viewRow in grdFrameInfo.Rows)
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
                    if ((grdFrameInfo.DataSource as DataTable).AsEnumerable().Where(r => r["ROWTYPE"].Equals("CREATE")
                                                                                      || r["ROWTYPE"].Equals("MODIFIY")
                                                                                      || r["ROWTYPE"].Equals("DELETE")).Count() == 0)
                    {
                        MsgBoxHelper.Show("저장할 데이터가 없습니다.");
                        return;
                    }
                    // 필수 키값이 입력되지 않았다면 Return
                    if ((grdFrameInfo.DataSource as DataTable).AsEnumerable().Where(r => r["PRODUCTID"].Equals(null)
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
                parameters.Add("@SAVEDATATABLE", grdFrameInfo.DataSource as DataTable);

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
            radioAll.Checked = true;
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdFrameInfo.DefaultCellStyle.ForeColor = Color.Black;

            grdFrameInfo.AutoGenerateColumns = false;
            grdFrameInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdFrameInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdFrameInfo.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "NO", "NO", "NO", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "시간", "PRODUCTTYPE", "rackid", typeof(string), 200, false, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "프레임", "PRODUCTNAME", "durableid", typeof(int), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "자동판정등급", "PRODUCTNO", "productname", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 80);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "불량유형", "CUSTOMERNAME", "inputdate", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "최종판정", "CREATOR", "inputresult", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 35);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "위치", "CREATETIME", "usedate", typeof(string), 500, false, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 60);
        }

        #endregion
    }
}
