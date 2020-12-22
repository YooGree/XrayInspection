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
    /// 작   성   일  : 2020-12-14
    /// 설        명  : 불량코드 등록화면
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

            btnTopSave.Click += BtnSave_Click;
            btnMiddleSave.Click += BtnSave_Click;
            btnDetailSave.Click += BtnSave_Click;

            btnSearch.Click += BtnSearch_Click;

            grdTopCategory.RowPostPaint += Grd_RowPostPaint;
            grdMiddleCategory.RowPostPaint += Grd_RowPostPaint;
            grdDetailCategory.RowPostPaint += Grd_RowPostPaint;
            grdTopCategory.SelectionChanged += Grd_SelectionChanged;
            grdMiddleCategory.SelectionChanged += Grd_SelectionChanged;
            grdDetailCategory.SelectionChanged += Grd_SelectionChanged;
        }
        
        /// <summary>
        /// 행 변경시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grd_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            switch (view.Name)
            {
                case "grdTopCategory":
                    
                    txtTopCode.ReadOnly = true;
                    txtTopCode.Text = grdTopCategory.CurrentRow.Cells["DEFECTCODE"].Value.ToString();
                    txtTopName.Text = grdTopCategory.CurrentRow.Cells["DEFECTCODENAME"].Value.ToString();
                    comboTopValidState.SelectedValue = grdTopCategory.CurrentRow.Cells["VALIDSTATE"].Value.ToString();
                    Search("MIDDLE", grdTopCategory.CurrentRow.Cells["DEFECTCODE"].Value.ToString()); // 중분류 그리드 조회

                    // 중분류 그리드에 행이 한개도 없을때
                    if (grdMiddleCategory.CurrentRow == null)
                    {
                        // 중분류 입력란 초기화
                        txtMiddleCode.Clear();
                        txtMiddleName.Clear();
                        comboMiddleValidState.SelectedIndex = 0;

                        // 불량상세 그리드 및 입력란 초기화
                        grdDetailCategory.DataSource = null;
                        txtDetailCode.Clear();
                        txtDetailName.Clear();
                        comboDetailValidState.SelectedIndex = 0;
                    }
                    break;

                case "grdMiddleCategory":
                    txtMiddleCode.ReadOnly = true;
                    txtMiddleCode.Text = grdMiddleCategory.CurrentRow.Cells["DEFECTCODE"].Value.ToString();
                    txtMiddleName.Text = grdMiddleCategory.CurrentRow.Cells["DEFECTCODENAME"].Value.ToString();
                    comboMiddleValidState.SelectedValue = grdMiddleCategory.CurrentRow.Cells["VALIDSTATE"].Value.ToString();
                    Search("DETAIL", grdMiddleCategory.CurrentRow.Cells["DEFECTCODE"].Value.ToString()); // 불량상세 그리드 조회

                    // 불량상세 그리드에 행이 한개도 없을때
                    if (grdDetailCategory.CurrentRow == null)
                    {
                        // 불량상세 입력란 초기화
                        txtDetailCode.Clear();
                        txtDetailName.Clear();
                        comboDetailValidState.SelectedIndex = 0;
                    }
                    break;

                case "grdDetailCategory":
                    txtDetailCode.ReadOnly = true;
                    txtDetailCode.Text = grdDetailCategory.CurrentRow.Cells["DEFECTCODE"].Value.ToString();
                    txtDetailName.Text = grdDetailCategory.CurrentRow.Cells["DEFECTCODENAME"].Value.ToString();
                    comboDetailValidState.SelectedValue = grdDetailCategory.CurrentRow.Cells["VALIDSTATE"].Value.ToString();
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
        private void Grd_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView view = (DataGridView)sender;

            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, view.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), view.RowHeadersDefaultCellStyle.Font, rect, view.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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
        public void Search(string defectCodeType = "TOP", string parentDefectCode = "Root")
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@DEFECTCODETYPE", defectCodeType)); // 불량코드타입
                parameters.Add(new SqlParameter("@PARENTDEFECTCODE", parentDefectCode)); // 상위불량코드
                parameters.Add(new SqlParameter("@SEARCHLEVEL", comboSearchLevel.SelectedValue)); // 검색레벨
                parameters.Add(new SqlParameter("@VALIDSTATE", comboSearchValidState.SelectedValue)); // 사용여부
                parameters.Add(new SqlParameter("@DEFECTCODE", txtSearchDefectCode.Text)); // 불량코드
                parameters.Add(new SqlParameter("@DEFECTCODENAME", txtSearchDefectName.Text)); // 불량코드명

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_DEFECTCODEMANAGEMENT", parameters);

                 if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    if (defectCodeType == "TOP")
                    {
                        grdTopCategory.DataSource = ds.Tables[0];

                        // 대분류 그리드에 행이 한개도 없을때
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            // 대분류 입력란 초기화
                            txtTopCode.Clear();
                            txtTopName.Clear();
                            comboTopValidState.SelectedIndex = 0;

                            // 중분류 그리드 및 입력란 초기화
                            grdMiddleCategory.DataSource = null;
                            txtMiddleCode.Clear();
                            txtMiddleName.Clear();
                            comboMiddleValidState.SelectedIndex = 0;

                            // 불량상세 그리드 및 입력란 초기화
                            grdDetailCategory.DataSource = null;
                            txtDetailCode.Clear();
                            txtDetailName.Clear();
                            comboDetailValidState.SelectedIndex = 0;
                        }
                    }
                    else if (defectCodeType == "MIDDLE")
                    {
                        grdMiddleCategory.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        grdDetailCategory.DataSource = ds.Tables[0];
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
                Button btn = (Button)sender;

                Dictionary<string, object> parameters = new Dictionary<string, object>();

                // 대분류 저장
                if (btn.Name == "btnTopSave")
                {
                    // 불량코드 입력 필수조건
                    if (string.IsNullOrWhiteSpace(txtTopCode.Text))
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "불량코드는 필수입력입니다.");
                        return;
                    }
                    else
                    {
                        parameters.Add("@DEFECTCODETYPE", "TOP");
                        parameters.Add("@DEFECTCODE", txtTopCode.Text);
                        parameters.Add("@DEFECTCODENAME", txtTopName.Text);
                        parameters.Add("@PARENTDEFECTCODE", "Root");
                        parameters.Add("@VALIDSTATE", comboTopValidState.SelectedValue);

                        // 신규인지 수정인지 판별
                        if (txtTopCode.ReadOnly)
                            parameters.Add("@ROWTYPE", "MODIFIY");
                        else
                            parameters.Add("@ROWTYPE", "CREATE");
                    }
                }
                // 중분류 저장
                else if (btn.Name == "btnMiddleSave")
                {
                    // 불량코드 입력 필수조건
                    if (string.IsNullOrWhiteSpace(txtMiddleCode.Text))
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "불량코드는 필수입력입니다.");
                        return;
                    }
                    // 상위불량코드 선택 필수조건
                    else if (grdTopCategory.CurrentRow == null)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "상위 불량코드가 지정되지 않았습니다.");
                        return;
                    }
                    else
                    {
                        parameters.Add("@DEFECTCODETYPE", "MIDDLE");
                        parameters.Add("@DEFECTCODE", txtMiddleCode.Text);
                        parameters.Add("@DEFECTCODENAME", txtMiddleName.Text);
                        parameters.Add("@PARENTDEFECTCODE", grdTopCategory.CurrentRow.Cells["DEFECTCODE"].Value);
                        parameters.Add("@VALIDSTATE", comboMiddleValidState.SelectedValue);

                        // 신규인지 수정인지 판별
                        if (txtMiddleCode.ReadOnly)
                            parameters.Add("@ROWTYPE", "MODIFIY");
                        else
                            parameters.Add("@ROWTYPE", "CREATE");
                    }
                }
                // 불량상세 저장
                else
                {
                    // 불량코드 입력 필수조건
                    if (string.IsNullOrWhiteSpace(txtDetailCode.Text))
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "불량코드는 필수입력입니다.");
                        return;
                    }
                    // 상위불량코드 선택 필수조건
                    else if (grdMiddleCategory.CurrentRow == null)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "상위 불량코드가 지정되지 않았습니다.");
                        return;
                    }
                    else
                    {
                        parameters.Add("@DEFECTCODETYPE", "DETAIL");
                        parameters.Add("@DEFECTCODE", txtDetailCode.Text);
                        parameters.Add("@DEFECTCODENAME", txtDetailName.Text);
                        parameters.Add("@PARENTDEFECTCODE", grdMiddleCategory.CurrentRow.Cells["DEFECTCODE"].Value);
                        parameters.Add("@VALIDSTATE", comboDetailValidState.SelectedValue);

                        // 신규인지 수정인지 판별
                        if (txtDetailCode.ReadOnly)
                            parameters.Add("@ROWTYPE", "MODIFIY");
                        else
                            parameters.Add("@ROWTYPE", "CREATE");
                    }
                }

                if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "저장", "저장 하시겠습니까?") == DialogResult.OK)
                {
                    DBManager dbManager = new DBManager();
                    SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                    int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_DEFECTCODEMANAGEMENT", sqlPamaters);

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
            BindingList<object> levelList = new BindingList<object>();
            levelList.Add(new { Text = "대분류", Value = "TOP" });
            levelList.Add(new { Text = "중분류", Value = "MIDDLE" });
            levelList.Add(new { Text = "불량상세", Value = "DETAIL" });
            comboSearchLevel.DataSource = levelList;
            comboSearchLevel.DisplayMember = "Text";
            comboSearchLevel.ValueMember = "Value";
            comboSearchLevel.SelectedValue = "TOP";
            comboSearchLevel.DropDownStyle = ComboBoxStyle.DropDownList;

            BindingList<object> usableTypeList1 = new BindingList<object>();
            usableTypeList1.Add(new { Text = "유효", Value = "Valid" });
            usableTypeList1.Add(new { Text = "미유효", Value = "InValid" });
            comboSearchValidState.DataSource = usableTypeList1;
            comboSearchValidState.DisplayMember = "Text";
            comboSearchValidState.ValueMember = "Value";
            comboSearchValidState.SelectedValue = "Valid";
            comboSearchValidState.DropDownStyle = ComboBoxStyle.DropDownList;

            BindingList<object> usableTypeList2 = new BindingList<object>();
            usableTypeList2.Add(new { Text = "유효", Value = "Valid" });
            usableTypeList2.Add(new { Text = "미유효", Value = "InValid" });
            comboTopValidState.DataSource = usableTypeList2;
            comboTopValidState.DisplayMember = "Text";
            comboTopValidState.ValueMember = "Value";
            comboTopValidState.SelectedValue = "Valid";
            comboTopValidState.DropDownStyle = ComboBoxStyle.DropDownList;

            BindingList<object> usableTypeList3 = new BindingList<object>();
            usableTypeList3.Add(new { Text = "유효", Value = "Valid" });
            usableTypeList3.Add(new { Text = "미유효", Value = "InValid" });
            comboMiddleValidState.DataSource = usableTypeList3;
            comboMiddleValidState.DisplayMember = "Text";
            comboMiddleValidState.ValueMember = "Value";
            comboMiddleValidState.SelectedValue = "Valid";
            comboMiddleValidState.DropDownStyle = ComboBoxStyle.DropDownList;

            BindingList<object> usableTypeList4 = new BindingList<object>();
            usableTypeList4.Add(new { Text = "유효", Value = "Valid" });
            usableTypeList4.Add(new { Text = "미유효", Value = "InValid" });
            comboDetailValidState.DataSource = usableTypeList4;
            comboDetailValidState.DisplayMember = "Text";
            comboDetailValidState.ValueMember = "Value";
            comboDetailValidState.SelectedValue = "Valid";
            comboDetailValidState.DropDownStyle = ComboBoxStyle.DropDownList;
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
            grdTopCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdTopCategory.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            grdTopCategory.DefaultCellStyle.SelectionForeColor = Color.Black;

            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "불량코드", "DEFECTCODE", "DEFECTCODE", typeof(string), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "불량명", "DEFECTCODENAME", "DEFECTCODENAME", typeof(string), 180, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "유효여부", "VALIDSTATE", "VALIDSTATE", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "상위불량코드", "PARENTDEFECTCODE", "PARENTDEFECTCODE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "레벨", "LEVEL", "LEVEL", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdTopCategory, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);

            // 중분류
            grdMiddleCategory.AutoGenerateColumns = false;
            grdMiddleCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdMiddleCategory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdMiddleCategory.AllowUserToAddRows = false;
            grdMiddleCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdMiddleCategory.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            grdMiddleCategory.DefaultCellStyle.SelectionForeColor = Color.Black;

            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "불량코드", "DEFECTCODE", "DEFECTCODE", typeof(string), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "불량명", "DEFECTCODENAME", "DEFECTCODENAME", typeof(string), 180, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "유효여부", "VALIDSTATE", "VALIDSTATE", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "상위불량코드", "PARENTDEFECTCODE", "PARENTDEFECTCODE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "레벨", "LEVEL", "LEVEL", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdMiddleCategory, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);

            // 불량상세
            grdDetailCategory.AutoGenerateColumns = false;
            grdDetailCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdDetailCategory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdDetailCategory.AllowUserToAddRows = false;
            grdDetailCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdDetailCategory.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            grdDetailCategory.DefaultCellStyle.SelectionForeColor = Color.Black;

            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "불량코드", "DEFECTCODE", "DEFECTCODE", typeof(string), 120, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "불량명", "DEFECTCODENAME", "DEFECTCODENAME", typeof(string), 180, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "유효여부", "VALIDSTATE", "VALIDSTATE", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "상위불량코드", "PARENTDEFECTCODE", "PARENTDEFECTCODE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "레벨", "LEVEL", "LEVEL", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdDetailCategory, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, true, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        #endregion
    }
}
