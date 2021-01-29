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
    /// 작   성   일  : 2021-01-28
    /// 설        명  : 수작업 등록화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_ManualInputLot : UserControl
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
        public CS_ManualInputLot()
        {
            InitializeComponent();
            InitializeControlSetting();
            InitializeGrid();
            InitializeRegGrid();
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
            btnDeleteRow.Click += BtnDeleteRow_Click;
            btnSearch.Click += BtnSearch_Click;
            btnSave.Click += BtnSave_Click;

            // 제품그리드
            grdProduct.RowPostPaint += GrdProduct_RowPostPaint;
            grdProduct.SelectionChanged += GrdProduct_SelectionChanged;

            // 등록그리드
            grdRegLot.RowPostPaint += GrdRegLot_RowPostPaint;
            grdRegLot.CellValueChanged += GrdRegLot_CellValueChanged;
           
        }

        /// <summary>
        /// 행 변경시 해당 행의 제품정보로 재바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdProduct_SelectionChanged(object sender, EventArgs e)
        {
            // 제품정보 상세 바인딩
            DataGridViewRow row = grdProduct.CurrentRow;
            txtProductName.Text = row.Cells["PRODUCTNAME"].Value.ToString();
            txtProductCode.Text = row.Cells["PRODUCTCODE"].Value.ToString();
            txtUsedPlace.Text = row.Cells["USEDPLACE"].Value.ToString();
            txtCustomer.Text = row.Cells["CUSTOMER"].Value.ToString();
            txtProductWeight.Text = row.Cells["PRODUCTWEIGHT"].Value.ToString();

            // 등록그리드 초기화
            DataTable dt = new DataTable();
            dt.Columns.Add("PRODUCTID", typeof(string));
            dt.Columns.Add("PRODUCTCODE", typeof(string));
            dt.Columns.Add("MAKER", typeof(string));
            dt.Columns.Add("MAKERNAME", typeof(string));
            dt.Columns.Add("LOTNO", typeof(string));
            dt.Columns.Add("ROWTYPE", typeof(string));

            // 행은 50개씩 미리 세팅
            for (int i = 0; i < 50; i++)
            {
                DataRow dRow = dt.NewRow();
                dRow["PRODUCTID"] = row.Cells["PRODUCTID"].Value.ToString();
                dRow["PRODUCTCODE"] = row.Cells["PRODUCTCODE"].Value.ToString();
                dRow["MAKER"] = string.Empty;
                dRow["MAKERNAME"] = string.Empty;
                dRow["LOTNO"] = string.Empty;
                dRow["ROWTYPE"] = rowChangeType.CREATE;

                dt.Rows.Add(dRow);
            }

            grdRegLot.DataSource = dt;
            grdRegLot.DefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        /// <summary>
        /// 성형자번호를 입력시 성형자명을 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdRegLot_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdRegLot.CurrentCell != null && grdRegLot.CurrentCell.OwningColumn.Name == "MAKER")
            {
                if (string.IsNullOrWhiteSpace(grdRegLot.CurrentRow.Cells["MAKER"].Value.ToString()))
                {
                    grdRegLot.CurrentRow.Cells["MAKERNAME"].Value = string.Empty;
                    return;
                }

                grdRegLot.CurrentRow.Cells["MAKERNAME"].Value = GetMakerName(grdRegLot.CurrentRow.Cells["MAKER"].Value);
            }        
        }

        /// <summary>
        /// 등록 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdRegLot_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, grdRegLot.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), grdRegLot.RowHeadersDefaultCellStyle.Font, rect, grdRegLot.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 제품 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, grdProduct.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), grdProduct.RowHeadersDefaultCellStyle.Font, rect, grdProduct.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 현재 선택된 Row 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = grdRegLot.SelectedRows;

            foreach (DataGridViewRow selectedRow in selectedRows)
            {
                selectedRow.Cells["MAKER"].Value = string.Empty;
                selectedRow.Cells["MAKERNAME"].Value = string.Empty;
                selectedRow.Cells["LOTNO"].Value = string.Empty;
            }
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
                parameters.Add(new SqlParameter("@PRODUCTCODE", txtSearchProductCode.Text)); // 도번


                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_MANUALINPUTLOT", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    _searchDt = ds.Tables[0];
                    _OriginalSearchDt = _searchDt.Copy();
                    grdProduct.DataSource = _searchDt;
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
            if ((grdRegLot.DataSource as DataTable).AsEnumerable().Where(r => !string.IsNullOrWhiteSpace(r["MAKER"].ToString())
                                                                           || !string.IsNullOrWhiteSpace(r["LOTNO"].ToString())).Count() < 1)
            {
                MsgBoxHelper.Show("저장할 데이터가 없습니다.");
                return;
            }

            // 저장할 DataTable 가공
            DataTable saveDt = (grdRegLot.DataSource as DataTable).AsEnumerable().Where(r => !string.IsNullOrWhiteSpace(r["MAKER"].ToString())
                                                                                          || !string.IsNullOrWhiteSpace(r["LOTNO"].ToString())).CopyToDataTable();

            foreach (DataRow saveRow in saveDt.Rows)
            {
                if (string.IsNullOrWhiteSpace(saveRow["MAKER"].ToString()) && string.IsNullOrWhiteSpace(saveRow["LOTNO"].ToString()))
                {
                    saveDt.Rows.Remove(saveRow);
                }
            }

            // 유효성 체크로직 시작
            // 성형자번호를 입력했는데 성형자명이 바인딩 되지 않은 행이 있다면 알림
            if (saveDt.AsEnumerable().Where(r => !string.IsNullOrWhiteSpace(r["MAKER"].ToString()) && string.IsNullOrWhiteSpace(r["MAKERNAME"].ToString())).Count() > 0)
            {
                MsgBoxHelper.Show("잘못된 성형자번호가 존재합니다. \n확인 후 저장해주세요.");
                return;
            }
            // 성형자는 입력했지만 LOT NO를 입력하지 않은 행이 있다면 알림
            else if (saveDt.AsEnumerable().Where(r => !string.IsNullOrWhiteSpace(r["MAKER"].ToString()) && string.IsNullOrWhiteSpace(r["LOTNO"].ToString())).Count() > 0)
            {
                MsgBoxHelper.Show("성형자가 입력됬지만, LOT NO가 입력되지 않은 행이 존재합니다. \n확인 후 저장해주세요.");
                return;
            }
            // LOT NO는 입력했지만 성형자를 입력하지 않은 행이 있다면 알림
            else if (saveDt.AsEnumerable().Where(r => !string.IsNullOrWhiteSpace(r["LOTNO"].ToString()) && string.IsNullOrWhiteSpace(r["MAKER"].ToString())).Count() > 0)
            {
                MsgBoxHelper.Show("LOT NO가 입력됬지만, 성형자가 입력되지 않은 행이 존재합니다. \n확인 후 저장해주세요.");
                return;
            }

            // 저장
            if (MsgBoxHelper.Show("저장하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try           
                {
                    string productName = txtProductName.Text; 
                    string makerList = "";  
                    string lotList = "";

                    foreach (DataRow saveRow in saveDt.Rows)
                    {
                        makerList += saveRow["MAKER"] + "#";
                        lotList += saveRow["LOTNO"] + "#";
                    }

                    DBManager dbManager = new DBManager();

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@SITE", Properties.Settings.Default.Site);
                    parameters.Add("@PRODUCTNAME", productName);
                    parameters.Add("@MAKERLIST", makerList);
                    parameters.Add("@LOTLIST", lotList);

                    SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                    int saveResult = dbManager.CallNonSelectProcedure("USP_INSERT_MANUALINPUTLOT", sqlPamaters);

                    if (saveResult > 0)
                    {
                        MsgBoxHelper.Show("저장하였습니다.");
                        Search(); // 재조회
                    }
                    else
                    {
                        MsgBoxHelper.Show("저장된 데이터가 없습니다.");
                    }
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.Error(ex.Message);                 
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
        }

        /// <summary>
        /// 조회 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdProduct.DefaultCellStyle.ForeColor = Color.Black;

            grdProduct.AutoGenerateColumns = false;
            grdProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdProduct.AllowUserToAddRows = false;
            grdProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdProduct.MultiSelect = false;
            grdProduct.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            grdProduct.DefaultCellStyle.SelectionForeColor = Color.Black;

            CommonFuction.SetDataGridViewColumnStyle(grdProduct, "도번", "PRODUCTCODE", "PRODUCTCODE", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdProduct, "제품명", "PRODUCTNAME", "PRODUCTNAME", typeof(string), 220, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdProduct, "거래처", "CUSTOMER", "CUSTOMER", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdProduct, "사용처", "USEDPLACE", "USEDPLACE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdProduct, "단중", "PRODUCTWEIGHT", "PRODUCTWEIGHT", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdProduct, "제품코드", "PRODUCTID", "PRODUCTID", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdProduct, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        /// <summary>
        /// 등록 그리드 세팅
        /// </summary>
        private void InitializeRegGrid()
        {
            grdRegLot.DefaultCellStyle.ForeColor = Color.Black;

            grdRegLot.AutoGenerateColumns = false;
            grdRegLot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdRegLot.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdRegLot.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdRegLot, "성형자번호", "MAKER", "MAKER", typeof(string), 80, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdRegLot, "성형자명", "MAKERNAME", "MAKERNAME", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdRegLot, "LOT NO", "LOTNO", "LOTNO", typeof(string), 250, false, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdRegLot, "제품코드", "PRODUCTID", "PRODUCTID", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdRegLot, "도번", "PRODUCTCODE", "PRODUCTCODE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdRegLot, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        /// <summary>
        /// 성형자 번호 입력시 성형자 이름을 조회
        /// </summary>
        /// <param name="makerId"></param>
        private string GetMakerName(object makerId)
        {
            string makerName = "";

            try
            {              
                if (makerId == DBNull.Value) return makerName;

                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site
                parameters.Add(new SqlParameter("@MAKER", makerId)); // 성형자번호


                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_MAKERINFO", parameters);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        makerName = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return makerName;
        }
        #endregion
    }
}
