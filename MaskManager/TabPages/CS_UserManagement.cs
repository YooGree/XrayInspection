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

            grdUser.RowPostPaint += GrdAIjubgmentHistory_RowPostPaint;
            grdUser.CellValueChanged += GrdAIjubgmentHistory_CellValueChanged;
            grdUser.CellBeginEdit += GrdAIjubgmentHistory_CellBeginEdit;
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
                if (dgv.Rows[e.RowIndex].Cells["USERNUMBER"].Value.Equals(row["USERNUMBER"]))
                {
                    if (dgv.Columns[e.ColumnIndex].Name.Equals("USERNUMBER"))
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
            grdUser.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        /// <summary>
        /// 현재 선택된 Row 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            // 신규행이 아니라면 행타입만 바꿔주기
            if (grdUser.Rows[grdUser.CurrentCellAddress.Y].Cells["ROWTYPE"].Value.ToString() != "CREATE")
            {
                grdUser.Rows[grdUser.CurrentCellAddress.Y].Cells["ROWTYPE"].Value = rowChangeType.DELETE;
                grdUser.Rows[grdUser.CurrentCellAddress.Y].DefaultCellStyle.BackColor = Color.Crimson;
            }
            // 신규행이라면 행자체를 지우기
            else
            {
                for (int i = 0; i < grdUser.Rows.Count; i++)
                {
                    // 행 선택 여부
                    grdUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    if (grdUser.Rows[i].Selected == true)
                    {
                        // 현재 선택된 인덱스에 해당된 Row 삭제
                        grdUser.Rows.Remove(grdUser.Rows[i]);
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
                grdUser.Rows.Add();
                grdUser.EndEdit();
            }
            else
            {
                _searchDt.Rows.Add();
                grdUser.DataSource = _searchDt;
                grdUser.EndEdit();
            }

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
            if (grdUser.Rows.Count == 0)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                return;
            }
            else
            {
                // 조회해온 데이터가 없을경우
                if (_searchDt.Rows.Count == 0)
                {
                    foreach (DataGridViewRow viewRow in grdUser.Rows)
                    {
                        if (viewRow.Cells["INSPECTOR"].Value == null)
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
                    if ((grdUser.DataSource as DataTable).AsEnumerable().Where(r => r["ROWTYPE"].Equals("CREATE")
                                                                                 || r["ROWTYPE"].Equals("MODIFIY")
                                                                                 || r["ROWTYPE"].Equals("DELETE")).Count() == 0)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                        return;
                    }
                }
            }

            if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "저장", "저장 하시겠습니까?") == DialogResult.OK)
            {
                DBManager dbManager = new DBManager();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@SAVEDATATABLE", grdUser.DataSource as DataTable);

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
            grdUser.AutoGenerateColumns = false;
            grdUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdUser.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdUser.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdUser, "NO", "NO", "NO", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdUser, "순번", "SEQUENCE", "SEQUENCE", typeof(int), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdUser, "사번", "USERNUMBER", "USERNUMBER", typeof(string), 200, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdUser, "사용자명", "USERNAME", "USERNAME", typeof(string), 200, false, true, DataGridViewContentAlignment.MiddleCenter, 10);    
            CommonFuction.SetDataGridViewColumnStyle(grdUser, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        #endregion
    }
}
