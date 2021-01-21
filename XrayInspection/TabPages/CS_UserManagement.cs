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
    /// 작   성   일  : 2020-12-10
    /// 설        명  : 사용자 등록화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_UserManagement : UserControl
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
        public CS_UserManagement()
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
            btnAddRow.Click += BtnAddRow_Click;
            btnDeleteRow.Click += BtnDeleteRow_Click;
            btnSearch.Click += BtnSearch_Click;
            btnSave.Click += BtnSave_Click;

            grdUser.RowPostPaint += GrdUser_RowPostPaint;
            grdUser.CellValueChanged += GrdAIjubgmentHistory_CellValueChanged;
            grdUser.CellBeginEdit += GrdAIjubgmentHistory_CellBeginEdit;
            //grdUser.EditingControlShowing += GrdUser_EditingControlShowing;
            comboUserType.SelectedValueChanged += ComboUserType_SelectedValueChanged;
        }

        /// <summary>
        /// 사용자유형을 변경할때 자동조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboUserType_SelectedValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 특정셀에 숫자만 입력가능하도록 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdUser_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string name = grdUser.CurrentCell.OwningColumn.Name;

            // 순번
            if (name == "SEQUENCE")
                e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress_OnlyNumber);
            else
                e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress_OnlyNumber);

            // 사번
            if (name == "USERNUMBER")
                e.Control.KeyPress += new KeyPressEventHandler(txtCheckNumeric_KeyPress_OnlyNumberByUserNumber);
            else
                e.Control.KeyPress -= new KeyPressEventHandler(txtCheckNumeric_KeyPress_OnlyNumberByUserNumber);
        }

        /// <summary>
        /// 숫자만 입력가능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCheckNumeric_KeyPress_OnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        /// <summary>
        /// 숫자만 입력가능(8자리 제한)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCheckNumeric_KeyPress_OnlyNumberByUserNumber(object sender, KeyPressEventArgs e)
        {
            object value = grdUser.CurrentCell.EditedFormattedValue;

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) 
                e.Handled = true;
            else
            {
                if (value.ToString().Length > 6 && e.KeyChar != Convert.ToChar(Keys.Back))
                    e.Handled = true;
            }
        }

        /// <summary>
        /// 키값 수정불가하도록 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIjubgmentHistory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;

            //if (dgv.Columns[e.ColumnIndex].Name.Equals("SEQUENCE"))
            //{
            //    e.Cancel = true;
            //}
        }

        /// <summary>
        /// 셀값을 변경할때 행을 수정상태로 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIjubgmentHistory_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdUser.Rows[e.RowIndex].Cells["ROWTYPE"].Value.ToString() == "NORMAL")
            {
                DataRow frRow = _OriginalSearchDt.Rows[e.RowIndex];
                DataRow toRow = _searchDt.Rows[e.RowIndex];

                if (!CompareDataRow(frRow, toRow))
                {
                    grdUser.Rows[e.RowIndex].Cells["ROWTYPE"].Value = rowChangeType.MODIFIY;
                    grdUser.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Plum;
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
        private void GrdUser_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, grdUser.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), grdUser.RowHeadersDefaultCellStyle.Font, rect, grdUser.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 현재 선택된 Row 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = grdUser.SelectedRows;

            foreach (DataGridViewRow selectedRow in selectedRows)
            {
                // 신규행이 아니라면 행타입만 바꿔주기
                if (selectedRow.Cells["ROWTYPE"].Value.ToString() != "CREATE")
                {
                    selectedRow.Cells["ROWTYPE"].Value = rowChangeType.DELETE;
                    selectedRow.DefaultCellStyle.BackColor = Color.Crimson;
                }
                // 신규행이라면 행자체를 지우기
                else
                {
                    grdUser.Rows.Remove(selectedRow);
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
            _searchDt.Rows.Add();
            grdUser.DataSource = _searchDt;
            grdUser.EndEdit();

            //if (grdUser.Rows.Count == 0)
            //{
            //    grdUser.Rows.Add();
            //    grdUser.EndEdit();
            //}
            //else
            //{
            //    _searchDt.Rows.Add();
            //    grdUser.DataSource = _searchDt;
            //    grdUser.EndEdit();
            //}

            // 최초 행 생성시 사용자 순번생성
            //int maxSeq = 0;
            //if (grdUser.DataSource == null)
            //{
            //    grdUser.Rows[grdUser.Rows.Count - 1].Cells["SEQUENCE"].Value = 1;
            //}
            //else
            //{
            //    DataTable dt = grdUser.DataSource as DataTable;
            //    maxSeq = dt.AsEnumerable().Where(r => !r["SEQUENCE"].Equals(DBNull.Value)).Select(r => Convert.ToInt32(r["SEQUENCE"])).Max();
            //    grdUser.Rows[grdUser.Rows.Count - 1].Cells["SEQUENCE"].Value = maxSeq + 1;
            //}

            // 최초 행 생성시 행변경타입 CREATE
            grdUser.Rows[grdUser.Rows.Count - 1].Cells["ROWTYPE"].Value = rowChangeType.CREATE;
            grdUser.Rows[grdUser.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
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
                if (grdUser.Rows.Count == 0)
                {
                    DialogResult result = MsgBoxHelper.Show("엑셀 데이터가 없습니다.");
                }
                else
                {
                    sfd.FileName = lblTitle.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    sfd.Filter = "csv(*.csv) | *.csv";

                    DialogResult result = MsgBoxHelper.Show("엑셀 저장 하시겠습니까?", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            this.SaveCsv(sfd.FileName, grdUser, true);
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
                parameters.Add(new SqlParameter("@USERTYPE", comboUserType.SelectedValue)); // 사용자 유형
                parameters.Add(new SqlParameter("@USERNUMBER", txtUserNumber.Text)); // 사번
                parameters.Add(new SqlParameter("@USERNAME", txtUserName.Text)); // 사용자명

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_USERMANAGEMENT", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    _searchDt = ds.Tables[0];
                    _OriginalSearchDt = _searchDt.Copy();
                    grdUser.DataSource = _searchDt;
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
            if (grdUser.Rows.Count == 0)
            {
                MsgBoxHelper.Show("저장할 데이터가 없습니다.");
                return;
            }
            else
            {
                // 그리드에 신규, 수정, 삭제행이 없으면 Return
                if ((grdUser.DataSource as DataTable).AsEnumerable().Where(r => r["ROWTYPE"].Equals("CREATE")
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
                    parameters.Add("@USERTYPE", comboUserType.SelectedValue);
                    parameters.Add("@SAVEDATATABLE", grdUser.DataSource as DataTable);

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
                    if (ex.Message.Contains("중복 키"))
                    {
                        MsgBoxHelper.Error("중복된 순번이 존재합니다.");
                    }
                    else
                    {
                        MsgBoxHelper.Error(ex.Message);
                    }
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

            // 조회조건 콤보박스 세팅
            BindingList<object> userTypeList = new BindingList<object>();
            userTypeList.Add(new { Text = "검사자", Value = "INSPECTOR" });
            userTypeList.Add(new { Text = "성형자", Value = "MOLDER" });

            comboUserType.DataSource = userTypeList;
            comboUserType.DisplayMember = "Text";
            comboUserType.ValueMember = "Value";
            comboUserType.SelectedValue = "INSPECTOR";
            comboUserType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdUser.DefaultCellStyle.ForeColor = Color.Black;

            grdUser.AutoGenerateColumns = false;
            grdUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdUser.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdUser.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdUser, "순번", "SEQUENCE", "SEQUENCE", typeof(int), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdUser, "사번", "USERNUMBER", "USERNUMBER", typeof(int), 150, false, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdUser, "사용자명", "USERNAME", "USERNAME", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdUser, "재직유무", "EMPLOYMENTSTATUS", "EMPLOYMENTSTATUS", typeof(string), 120, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdUser, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);

            // 콤보박스컬럼 설정
            // 재직유무
            DataGridViewComboBoxCell comboCol = new DataGridViewComboBoxCell();
            BindingList<object> status = new BindingList<object>();
            status.Add(new { Text = "재직", Value = "재직" });
            status.Add(new { Text = "퇴사", Value = "퇴사" });
            comboCol.DataSource = status;
            comboCol.DisplayMember = "Text";
            comboCol.ValueMember = "Value";
            //comboCol.SelectedValue = "3";
            //comboCol.DropDownStyle = ComboBoxStyle.DropDownList;

            grdUser.Columns["EMPLOYMENTSTATUS"].CellTemplate = comboCol;
        }

        #endregion
    }
}
