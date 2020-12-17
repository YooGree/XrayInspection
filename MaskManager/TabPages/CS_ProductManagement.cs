using MaskManager.PopUp;
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

namespace MaskManager.UserControls
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-15
    /// 설        명  : 제품 등록화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_ProductManagement : UserControl
    {
        #region 변수

        DataTable _OriginalSearchDt = new DataTable(); // 조회된 데이터 최초 테이블
        DataTable _searchDt = new DataTable(); // 조회후 행 추가를 하기위한 테이블
        DataTable _searchDt2 = new DataTable();
        DateTimePicker _dtp = new DateTimePicker();
        Rectangle _rectangle;

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
        public CS_ProductManagement()
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
            btnSearch.Click += BtnSearch_Click;
            btnSave.Click += BtnSave_Click;

            grdOriginalProduct.RowPostPaint += Grd_RowPostPaint;
            grdNewProduct.RowPostPaint += Grd_RowPostPaint;
            grdNewProduct.CellValueChanged += GrdNewProduct_CellValueChanged;

            grdOriginalProduct.CellDoubleClick += Grd_CellDoubleClick;
            grdNewProduct.CellDoubleClick += Grd_CellDoubleClick;

            grdNewProduct.EditingControlShowing += GrdNewProduct_EditingControlShowing;

            grdNewProduct.CellClick += GrdNewProduct_CellClick;
        }

        /// <summary>
        /// DatePicker 컬럼 만들기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdNewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;

            switch (grdNewProduct.Columns[e.ColumnIndex].Name)
            {
                case "DWGUSEDATE":
                    _rectangle = grdNewProduct.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); 
                    _dtp.Size = new Size(_rectangle.Width, _rectangle.Height);  
                    _dtp.Location = new Point(_rectangle.X, _rectangle.Y);  
                    _dtp.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// 특정셀에 숫자만 입력가능하도록 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdNewProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = grdNewProduct.CurrentCell.OwningColumn.Name;

            if (name == "PRODUCTWEIGHT")      
                e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress);       
            else       
                e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress);        
        }
        
        /// <summary>
        /// .을 제외한 모든문자 입력불가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCheckNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                return;
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        /// <summary>
        /// 기존품목 그리드 행 더블클릭 -> 추가
        /// 신규품목 그리드 행 더블클릭 -> 원복
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow addViewRow = view.Rows[e.RowIndex];

            // 기존품목 그리드일때
            if (view.Name == "grdOriginalProduct")
            {
                // 신규품목 그리드에 행 추가
                DataRow addRow = _searchDt.NewRow();
                addRow["PRODUCTID"] = addViewRow.Cells["PRODUCTNAME"].Value; 
                addRow["PRODUCTNAME"] = addViewRow.Cells["PRODUCTNAME"].Value;
                addRow["PRODUCTCODE"] = addViewRow.Cells["PRODUCTCODE"].Value;
                addRow["CUSTOMER"] = addViewRow.Cells["CUSTOMER"].Value;
                addRow["USEDPLACE"] = addViewRow.Cells["USEDPLACE"].Value;
                addRow["SITE"] = "SITE01";
                addRow["INSPECTRATE"] = 0;
                addRow["WEIGHT"] = addViewRow.Cells["WEIGHT"].Value;
                addRow["ROWTYPE"] = rowChangeType.CREATE;
                _searchDt.Rows.Add(addRow);
                grdNewProduct.DataSource = _searchDt;
                grdNewProduct.Rows[grdNewProduct.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSkyBlue;

                // 기존품목 그리드에 행 삭제
                grdOriginalProduct.Rows.Remove(addViewRow);
            }
            // 신규품목 그리드일때
            else
            {
                if (addViewRow.Cells["ROWTYPE"].Value.Equals("CREATE") && e.ColumnIndex == -1)
                {
                    // 기존품목 그리드에 행 추가
                    DataRow addRow = _searchDt2.NewRow();
                    addRow["CUSTOMER"] = addViewRow.Cells["CUSTOMER"].Value;
                    addRow["USEDPLACE"] = addViewRow.Cells["USEDPLACE"].Value;
                    addRow["PRODUCTNAME"] = addViewRow.Cells["PRODUCTNAME"].Value;
                    addRow["PRODUCTCODE"] = addViewRow.Cells["PRODUCTCODE"].Value;
                    addRow["WEIGHT"] = addViewRow.Cells["WEIGHT"].Value;
                    addRow["ROWTYPE"] = rowChangeType.NORMAL;
                    _searchDt2.Rows.Add(addRow);
                    grdOriginalProduct.DataSource = _searchDt2;

                    // 신규품목 그리드에 행 삭제
                    grdNewProduct.Rows.Remove(addViewRow);

                    // DatePicker Control 숨김
                    _dtp.Visible = false;
                }
            }
        }

        /// <summary>
        /// 셀값을 변경할때 행을 수정상태로 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdNewProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdNewProduct.Rows[e.RowIndex].Cells["ROWTYPE"].Value.ToString() == "NORMAL")
            {
                DataRow frRow = _OriginalSearchDt.Rows[e.RowIndex];
                DataRow toRow = _searchDt.Rows[e.RowIndex];

                if (!CompareDataRow(frRow, toRow))
                {
                    grdNewProduct.Rows[e.RowIndex].Cells["ROWTYPE"].Value = rowChangeType.MODIFIY;
                    grdNewProduct.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Plum;
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
        private void Grd_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, view.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), view.RowHeadersDefaultCellStyle.Font, rect, view.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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
                parameters.Add(new SqlParameter("@SEARCHTYPE", comboSearchType.SelectedValue)); // 조회구분
                parameters.Add(new SqlParameter("@PRODUCTNAME", txtProductName.Text)); // 제품명
                parameters.Add(new SqlParameter("@CUSTOMER", txtCustomer.Text)); // 고객명
                parameters.Add(new SqlParameter("@USEDPLACE", txtUsePlace.Text)); // 사용처
                parameters.Add(new SqlParameter("@PRODUCTTYPE", comboProductType.SelectedValue)); // 제품구분
                parameters.Add(new SqlParameter("@PRODUCTWEIGHT", txtProductWeight.Text)); // 단중
                parameters.Add(new SqlParameter("@PRODUCTCODE", txtProductCode.Text)); // 도번

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_PRODUCTMANAGEMENT", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    // 기존제품 그리드 바인딩
                    _searchDt2 = ds.Tables[0];
                    grdOriginalProduct.DataSource = _searchDt2;
                       
                    // 신규제품 그리드 바인딩
                    _searchDt = ds.Tables[1];
                    _OriginalSearchDt = _searchDt.Copy();
                    grdNewProduct.DataSource = _searchDt;

                    // DatePicker Control 숨김
                    _dtp.Visible = false;
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
                if (grdNewProduct.Rows.Count == 0)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                    return;
                }
                else
                {
                    // 그리드에 신규, 수정, 삭제행이 없으면 Return
                    if ((grdNewProduct.DataSource as DataTable).AsEnumerable().Where(r => r["ROWTYPE"].Equals("CREATE")
                                                                                 || r["ROWTYPE"].Equals("MODIFIY")).Count() == 0)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                        return;
                    }
                }

                if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "저장", "저장 하시겠습니까?") == DialogResult.OK)
                {
                    DBManager dbManager = new DBManager();

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    DataTable saveDt = grdNewProduct.DataSource as DataTable;
                    if (saveDt.Columns.Contains("WEIGHT")) saveDt.Columns.Remove("WEIGHT");
                    parameters.Add("@SAVEDATATABLE", saveDt);

                    SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                    int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_PRODUCTMANAGEMENT", sqlPamaters);

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
            DBManager dbManager = new DBManager();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODECLASSID", "PRODUCT_TYPE")); // 제품구분
            parameters.Add(new SqlParameter("@ISALL", "Y")); // 전체여부
            DataSet ds = dbManager.CallSelectProcedure_ds("USP_GET_CODELIST", parameters);
            comboProductType.DataSource = ds.Tables[0];
            comboProductType.DisplayMember = "CODENAME";
            comboProductType.ValueMember = "CODEID";
            comboProductType.SelectedValue = "ALL";
            comboProductType.DropDownStyle = ComboBoxStyle.DropDownList;

            BindingList<object> searchTypeList = new BindingList<object>();
            searchTypeList.Add(new { Text = "기존", Value = "ORIGINAL" });
            searchTypeList.Add(new { Text = "신규", Value = "NEW" });
            comboSearchType.DataSource = searchTypeList;
            comboSearchType.DisplayMember = "Text";
            comboSearchType.ValueMember = "Value";
            comboSearchType.SelectedValue = "ORIGINAL";
            comboSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            // 기존제품 그리드
            grdOriginalProduct.AutoGenerateColumns = false;
            grdOriginalProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdOriginalProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdOriginalProduct.AllowUserToAddRows = false;
            grdOriginalProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdOriginalProduct.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            grdOriginalProduct.DefaultCellStyle.SelectionForeColor = Color.Black;

            CommonFuction.SetDataGridViewColumnStyle(grdOriginalProduct, "고객명", "CUSTOMER", "CUSTOMER", typeof(int), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdOriginalProduct, "사용처", "USEDPLACE", "USEDPLACE", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdOriginalProduct, "제품명", "PRODUCTNAME", "PRODUCTNAME", typeof(string), 250, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdOriginalProduct, "도번", "PRODUCTCODE", "PRODUCTCODE", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdOriginalProduct, "무게", "WEIGHT", "WEIGHT", typeof(float), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdOriginalProduct, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);

            // 신규제품 그리드
            grdNewProduct.AutoGenerateColumns = false;
            grdNewProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdNewProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdNewProduct.AllowUserToAddRows = false;
            grdNewProduct.SelectionMode = DataGridViewSelectionMode.CellSelect;

            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "제품명", "PRODUCTNAME", "PRODUCTNAME", typeof(string), 250, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "제품구분", "PRODUCTTYPE", "PRODUCTTYPE", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "도번", "PRODUCTCODE", "PRODUCTCODE", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "고객명", "CUSTOMER", "CUSTOMER", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "사용처", "USEDPLACE", "USEDPLACE", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "단중", "PRODUCTWEIGHT", "PRODUCTWEIGHT", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "도면구분", "DWGTYPE", "DWGTYPE", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "관리구분", "MANAGEMENTTYPE", "MANAGEMENTTYPE", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "도면개정일", "DWGUSEDATE", "DWGUSEDATE", typeof(string), 180, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            // 히든컬럼
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "검사수준", "INSPECTRATE", "INSPECTRATE", typeof(int), 100, false, false, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "Site", "SITE", "SITE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "무게", "WEIGHT", "WEIGHT", typeof(float), 100, true, false, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdNewProduct, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);

            // 콤보박스컬럼 설정
            // 제품구분
            DBManager dbManager = new DBManager();
            DataGridViewComboBoxCell comboCol = new DataGridViewComboBoxCell();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CODECLASSID", "PRODUCT_TYPE"));
            parameters.Add(new SqlParameter("@ISALL", "N"));
            DataSet ds = dbManager.CallSelectProcedure_ds("USP_GET_CODELIST", parameters);
            comboCol.DataSource = ds.Tables[0];
            comboCol.DisplayMember = "CODENAME";
            comboCol.ValueMember = "CODEID";
            grdNewProduct.Columns["PRODUCTTYPE"].CellTemplate = comboCol;

            // 도면구분
            DataGridViewComboBoxCell comboCol2 = new DataGridViewComboBoxCell();
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(new SqlParameter("@CODECLASSID", "DWG_TYPE"));
            parameters2.Add(new SqlParameter("@ISALL", "N"));
            DataSet ds2 = dbManager.CallSelectProcedure_ds("USP_GET_CODELIST", parameters2);
            comboCol2.DataSource = ds2.Tables[0];
            comboCol2.DisplayMember = "CODENAME";
            comboCol2.ValueMember = "CODEID";
            grdNewProduct.Columns["DWGTYPE"].CellTemplate = comboCol2;

            // 관리구분
            DataGridViewComboBoxCell comboCol3 = new DataGridViewComboBoxCell();
            List<SqlParameter> parameters3 = new List<SqlParameter>();
            parameters3.Add(new SqlParameter("@CODECLASSID", "MANAGE_TYPE"));
            parameters3.Add(new SqlParameter("@ISALL", "N"));
            DataSet ds3 = dbManager.CallSelectProcedure_ds("USP_GET_CODELIST", parameters3);
            comboCol3.DataSource = ds3.Tables[0];
            comboCol3.DisplayMember = "CODENAME";
            comboCol3.ValueMember = "CODEID";
            grdNewProduct.Columns["MANAGEMENTTYPE"].CellTemplate = comboCol3;

            // 날짜형식컬럼 설정
            SetDatePickerColumn();
        }

        /// <summary>
        /// 날짜형식컬럼 설정
        /// </summary>
        private void SetDatePickerColumn()
        {
            grdNewProduct.Controls.Add(_dtp);
            _dtp.Visible = false;
            _dtp.CustomFormat = "yyyy-MM-dd";
            _dtp.Format = DateTimePickerFormat.Custom;
            _dtp.TextChanged += new EventHandler(dtp_TextChange);            
        }

        /// <summary>
        /// 그리드 셀에 날짜값 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_TextChange(object sender, EventArgs e)
        {
            grdNewProduct.CurrentCell.Value = _dtp.Text.ToString();
        }

        #endregion
    }
}
