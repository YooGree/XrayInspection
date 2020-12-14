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
    public partial class CS_DefectCodeManagement : UserControl
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
        public CS_DefectCodeManagement()
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
            btnTopAdd.Click += BtnAdd_Click;
            btnMiddleAdd.Click += BtnAdd_Click;
            btnDetailAdd.Click += BtnAdd_Click;
             
            btnSearch.Click += BtnSearch_Click;
            btnTopSave.Click += BtnSave_Click;

            grdTopCategory.RowPostPaint += GrdAIjubgmentHistory_RowPostPaint;
            grdTopCategory.SelectionChanged += GrdTopCategory_SelectionChanged;
        }
        
        /// <summary>
        /// 행 변경시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdTopCategory_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            switch (view.Name)
            {
                case "grdTopCategory":
                    txtTopCode.ReadOnly = true;
                    txtTopCode.Text = grdTopCategory.CurrentRow.Cells["DEFECTCODE"].Value.ToString();
                    txtTopName.Text = grdTopCategory.CurrentRow.Cells["DEFECTCODENAME"].Value.ToString();
                    comboTopUsable.SelectedValue = grdTopCategory.CurrentRow.Cells["ISUSABLE"].Value.ToString();
                    break;

                case "grdMiddleCategory":
                    txtMiddleCode.ReadOnly = true;
                    txtMiddleCode.Text = grdMiddleCategory.CurrentRow.Cells["DEFECTCODE"].Value.ToString();
                    txtMiddleName.Text = grdMiddleCategory.CurrentRow.Cells["DEFECTCODENAME"].Value.ToString();
                    comboMiddleUsable.SelectedValue = grdMiddleCategory.CurrentRow.Cells["ISUSABLE"].Value.ToString();
                    break;

                case "grdDetailCategory":
                    txtDetailCode.ReadOnly = true;
                    txtDetailCode.Text = grdDetailCategory.CurrentRow.Cells["DEFECTCODE"].Value.ToString();
                    txtDetailName.Text = grdDetailCategory.CurrentRow.Cells["DEFECTCODENAME"].Value.ToString();
                    comboDetailUsable.SelectedValue = grdDetailCategory.CurrentRow.Cells["ISUSABLE"].Value.ToString();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIjubgmentHistory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            grdTopCategory.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        /// <summary>
        /// 불량코드 추가버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "btnTopAdd" :
                    txtTopCode.ReadOnly = false;
                    txtTopCode.Clear();
                    txtTopName.Clear();
                    break;

                case "btnMiddleAdd" :
                    txtMiddleCode.ReadOnly = false;
                    txtMiddleCode.Clear();
                    txtMiddleName.Clear();
                    break;

                case "btnDetailAdd" :
                    txtDetailCode.ReadOnly = false;
                    txtDetailCode.Clear();
                    txtDetailName.Clear();
                    break;

                default :
                    break;
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
        private void Search()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@DEFECTCODETYPE", "TOP")); // 불량코드타입
                parameters.Add(new SqlParameter("@PARENTDEFECTCODE", txtUserNumber.Text)); // 상위불량코드

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_DEFECTCODEMANAGEMENT", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    _searchDt = ds.Tables[0];
                    _OriginalSearchDt = _searchDt.Copy();
                    grdTopCategory.DataSource = _searchDt;
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
                if (grdTopCategory.Rows.Count == 0)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                    return;
                }
                else
                {
                    // 그리드에 신규, 수정, 삭제행이 없으면 Return
                    if ((grdTopCategory.DataSource as DataTable).AsEnumerable().Where(r => r["ROWTYPE"].Equals("CREATE")
                                                                                 || r["ROWTYPE"].Equals("MODIFIY")
                                                                                 || r["ROWTYPE"].Equals("DELETE")).Count() == 0)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                        return;
                    }
                }

                if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "저장", "저장 하시겠습니까?") == DialogResult.OK)
                {
                    DBManager dbManager = new DBManager();

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@USERTYPE", comboUsableType.SelectedValue);
                    parameters.Add("@SAVEDATATABLE", grdTopCategory.DataSource as DataTable);

                    SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                    int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_USERMANAGEMENT", sqlPamaters);

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

            // 콤보박스 데이터 세팅
            BindingList<object> usableTypeList1 = new BindingList<object>();
            usableTypeList1.Add(new { Text = "사용", Value = "USABLE" });
            usableTypeList1.Add(new { Text = "미사용", Value = "UNUSABLE" });
            comboUsableType.DataSource = usableTypeList1;
            comboUsableType.DisplayMember = "Text";
            comboUsableType.ValueMember = "Value";
            comboUsableType.SelectedValue = "USABLE";
            comboUsableType.DropDownStyle = ComboBoxStyle.DropDownList;

            BindingList<object> usableTypeList2 = new BindingList<object>();
            usableTypeList2.Add(new { Text = "사용", Value = "USABLE" });
            usableTypeList2.Add(new { Text = "미사용", Value = "UNUSABLE" });
            comboTopUsable.DataSource = usableTypeList2;
            comboTopUsable.DisplayMember = "Text";
            comboTopUsable.ValueMember = "Value";
            comboTopUsable.SelectedValue = "USABLE";
            comboTopUsable.DropDownStyle = ComboBoxStyle.DropDownList;

            BindingList<object> usableTypeList3 = new BindingList<object>();
            usableTypeList3.Add(new { Text = "사용", Value = "USABLE" });
            usableTypeList3.Add(new { Text = "미사용", Value = "UNUSABLE" });
            comboMiddleUsable.DataSource = usableTypeList3;
            comboMiddleUsable.DisplayMember = "Text";
            comboMiddleUsable.ValueMember = "Value";
            comboMiddleUsable.SelectedValue = "USABLE";
            comboMiddleUsable.DropDownStyle = ComboBoxStyle.DropDownList;

            BindingList<object> usableTypeList4 = new BindingList<object>();
            usableTypeList4.Add(new { Text = "사용", Value = "USABLE" });
            usableTypeList4.Add(new { Text = "미사용", Value = "UNUSABLE" });
            comboDetailUsable.DataSource = usableTypeList4;
            comboDetailUsable.DisplayMember = "Text";
            comboDetailUsable.ValueMember = "Value";
            comboDetailUsable.SelectedValue = "USABLE";
            comboDetailUsable.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            // 대분류
            grdTopCategory.AutoGenerateColumns = false;
            grdTopCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdTopCategory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdTopCategory.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "NO", "NO", "NO", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "불량코드", "DEFECTCODE", "DEFECTCODE", typeof(string), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "불량명", "DEFECTCODENAME", "DEFECTCODENAME", typeof(string), 180, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "사용여부", "ISUSABLE", "ISUSABLE", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);

            // 중분류
            grdMiddleCategory.AutoGenerateColumns = false;
            grdMiddleCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdMiddleCategory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdMiddleCategory.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "NO", "NO", "NO", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "불량코드", "DEFECTCODE", "DEFECTCODE", typeof(string), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "불량명", "DEFECTCODENAME", "DEFECTCODENAME", typeof(string), 180, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "사용여부", "ISUSABLE", "ISUSABLE", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);

            // 불량상세
            grdDetailCategory.AutoGenerateColumns = false;
            grdDetailCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdDetailCategory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdDetailCategory.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "NO", "NO", "NO", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "불량코드", "DEFECTCODE", "DEFECTCODE", typeof(string), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "불량명", "DEFECTCODENAME", "DEFECTCODENAME", typeof(string), 180, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "사용여부", "ISUSABLE", "ISUSABLE", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        #endregion
    }
}
