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
    public partial class CS_HandworkReg : UserControl
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
        public CS_HandworkReg()
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
            dt.Columns.Add("LOTNO", typeof(string));
            dt.Columns.Add("ROWTYPE", typeof(string));

            // 행은 50개씩 미리 세팅
            for (int i = 0; i < 50; i++)
            {
                DataRow dRow = dt.NewRow();
                dRow["PRODUCTID"] = txtProductName.Text = row.Cells["PRODUCTID"].Value.ToString();
                dRow["PRODUCTCODE"] = txtProductName.Text = row.Cells["PRODUCTCODE"].Value.ToString();
                dRow["ROWTYPE"] = rowChangeType.CREATE;

                dt.Rows.Add(dRow);
            }

            grdRegLot.DataSource = dt;

            foreach (DataGridViewRow vRow in grdRegLot.Rows)
            {
                vRow.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }
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
                if (string.IsNullOrWhiteSpace(grdRegLot.CurrentRow.Cells["MAKER"].Value.ToString())) return;

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
                selectedRow.Cells["PRODUCTID"].Value = string.Empty;
                selectedRow.Cells["PRODUCTCODE"].Value = string.Empty;
                selectedRow.Cells["ROWTYPE"].Value = rowChangeType.CREATE;
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


                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_HANDWORKREG", parameters);

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
            // 그리드뷰에 행이 한개도 없으면 Return
            if (grdRegLot.Rows.Count == 0)
            {
                MsgBoxHelper.Show("저장할 데이터가 없습니다.");
                return;
            }
            else
            {
                // 그리드에 신규, 수정, 삭제행이 없으면 Return
                if ((grdProduct.DataSource as DataTable).AsEnumerable().Where(r => r["ROWTYPE"].Equals("CREATE")
                                                                                || r["ROWTYPE"].Equals("MODIFIY")
                                                                                || r["ROWTYPE"].Equals("DELETE")).Count() == 0)
                {
                    MsgBoxHelper.Show("저장할 데이터가 없습니다.");
                    return;
                }
            }

            if (MsgBoxHelper.Show("저장하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try           
                {
                    DBManager dbManager = new DBManager();

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@SAVEDATATABLE", grdProduct.DataSource as DataTable);

                    SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                    int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_USERMANAGEMENT", sqlPamaters);

                    if (SaveResult > 0)
                    {
                        MsgBoxHelper.Show("저장하였습니다.");
                        Search(); // 재조회
                    }
                    else
                    {
                        MsgBoxHelper.Show("저장에 실패하였습니다");
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
