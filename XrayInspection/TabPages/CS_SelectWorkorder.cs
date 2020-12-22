using XrayInspection.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XrayInspection.UserControls
{
    /// <summary>
    /// 작   성   자  : 박세일
    /// 작   성   일  : 2020-12-10
    /// 설        명  : 작업지시 등록 조회
    ///                 근무조 변경후 작업계획 및 팔렛트 등록 정보 조회
    /// 이        력  : 
    /// </summary>
    public partial class CS_SelectWorkorder : UserControl
    {
        #region 변수

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
        public CS_SelectWorkorder()
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

            grdWorkorder.RowPostPaint += GrdWorkorder_RowPostPaint;
        }

        /// <summary>
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdWorkorder_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, view.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), view.RowHeadersDefaultCellStyle.Font, rect, view.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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
        /// Excel 내보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (grdWorkorder.Rows.Count == 0)
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
                            this.SaveCsv(sfd.FileName, grdWorkorder, true);
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
        /// 조회
        /// </summary>
        public void Search()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", "SITE01")); // 사이트 정보
                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_WORKORDERINFO", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    _searchDt = ds.Tables[0];
                    _OriginalSearchDt = _searchDt.Copy();
                    grdWorkorder.DataSource = _searchDt;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["LotState"].ToString() == "READY")
                        {
                            grdWorkorder.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                        }
                    }
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
            try
            {
                // 그리드뷰에 행이 한개도 없으면 Return
                if (grdWorkorder.Rows.Count == 0)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                    return;
                }
                else
                {
                    int icheckLotIDCount = 0;
                    bool isProductCode = true;

                    foreach(DataGridViewRow row in grdWorkorder.Rows)
                    {
                        
                        if(string.IsNullOrWhiteSpace(row.Cells["LotID"].Value.ToString()))
                        {
                            icheckLotIDCount++;
                        }
                        if (string.IsNullOrWhiteSpace(row.Cells["ProductCode"].Value.ToString()))
                        {
                            isProductCode = false;
                        }
                    }

                    if(icheckLotIDCount ==0 )
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                        return;
                    }

                    if(isProductCode ==false)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "제품등록이 되지 않았습니다. \r\n\r\n제품 등록후 진행 할 수 있습니다.");
                        return;
                    }
                }

                if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "저장", "저장 하시겠습니까?") == DialogResult.OK)
                {
                    DBManager dbManager = new DBManager();

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@SITE", "SITE01");
                    parameters.Add("@UserID", "SYSTEM");//변경필요

                    SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                    int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_REGWORKORDER", sqlPamaters);

                    if (SaveResult >= 0)
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
            catch (Exception ex)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "저장", ex.Message);
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

            // 조회조건 콤보박스 세팅
            BindingList<object> userTypeList = new BindingList<object>();
            userTypeList.Add(new { Text = "검사자", Value = "INSPECTOR" });
            userTypeList.Add(new { Text = "성형자", Value = "MOLDER" });
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdWorkorder.AutoGenerateColumns = false;
            grdWorkorder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grdWorkorder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdWorkorder.AllowUserToAddRows = false;
            grdWorkorder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "순번", "InspectSequence", "InspectSequence", typeof(int), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "거래처", "Customer", "Customer", typeof(string), 200, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "사용처", "UsedPlace", "UsedPlace", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "품명", "ProductID", "ProductID", typeof(string), 220, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "도번", "ProductCode", "ProductCode", typeof(string), 80, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "생산년도", "MakeYear", "MakeYear", typeof(string), 80, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "Input LotID", "InputLotID", "InputLotID", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "LotID", "LotID", "LotID", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "성형자", "Maker", "Maker", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "검사자", "Inspector", "Inspector", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "진행상태", "LotState", "LotState", typeof(string),80, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "판독결과", "LastResult", "LastResult", typeof(string), 80, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdWorkorder, "작업시간", "ModifiedTime", "ModifiedTime", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        #endregion


    }
}
