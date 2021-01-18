using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrayInspection.UserControls;

namespace XrayInspection.PopUp
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-23
    /// 설        명  : 공통팝업
    /// 이        력  : 
    /// </summary>
    public partial class CS_CommonPopup : ParentsPop
    {
        #region 변수

        private string _procedureName = ""; // 프로시저명
        private string _type = ""; // 유형
        private string _parentCode = ""; // 상위코드
        private DBManager _dbManager = new DBManager(); // DB 접속정보    
        public string _returnCodeValue = ""; // 리턴코드값
        public string _returnNameValue = ""; // 리턴명값
        public string _returnCodeNameValue = ""; // 리턴코드+명값
        public bool _returnIsOK = false;

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="type"></param>
        /// <param name="parentCode"></param>
        public CS_CommonPopup(string procedure, string type, string gridTitle = "리스트", string parentCode = "Root")
        {
            InitializeComponent();
            InitializeGrid();
            InitializeControlSetting(procedure, type, gridTitle, parentCode);
            InitializeEvent();
        }

        #endregion

        #region 이벤트

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            grdMain.RowPostPaint += GrdMain_RowPostPaint;
            btnSearch.Click += BtnSearch_Click;
            btnOK.Click += BtnOK_Click;
            btnClose.Click += BtnClose_Click;
            grdMain.CellDoubleClick += GrdMain_CellDoubleClick;
        }

        /// <summary>
        /// 셀 더블클릭시 확인적용
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnOK_Click(null, null);
        }

        /// <summary>
        /// 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 확인
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            DataTable dt = grdMain.DataSource as DataTable;

            if (CommonFuction.IsNullOrWhiteSpace(grdMain.CurrentRow))
            {
                MessageBox.Show("선택된 항목이 없습니다.");
                return;
            }

            DataGridViewRow gRow = grdMain.CurrentRow;

            this._returnCodeValue = gRow.Cells["CODEID"].Value.ToString();
            this._returnNameValue = gRow.Cells["CODENAME"].Value.ToString();
            this._returnCodeNameValue = _returnCodeValue + " : " + _returnNameValue;
            this.DialogResult = DialogResult.OK;
        }

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
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, grdMain.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), grdMain.RowHeadersDefaultCellStyle.Font, rect, grdMain.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@DEFECTCODETYPE", _type)); // 불량타입
                parameters.Add(new SqlParameter("@PARENTDEFECTCODE", _parentCode)); // 부모불량코드
                parameters.Add(new SqlParameter("@SEARCHTEXT", txtSearchText.Text)); // 조회조건

                DataSet ds = _dbManager.CallSelectProcedure_ds(_procedureName, parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    grdMain.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error(ex.Message);
            }
        }

        #endregion

        #region 사용자 정의 함수

        /// <summary>
        /// 컨트롤 라벨세팅
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="type"></param>
        private void InitializeControlSetting(string procedure, string type, string gridTitle, string parentCode)
        {
            // Footer 안보이게 처리
            Footer.Visible = false;

            // 프로시저 및 유형세팅
            _procedureName = procedure;
            _type = type;
            _parentCode = parentCode;

            // 최초조회
            Search();

            switch (type)
            {
                case "TOP":
                    lblTitle.Text = "선택팝업";
                    lblSearchLabel.Text = "불량코드/명";
                    gbxMain.Text = gridTitle;
                    break;
                case "MIDDLE":
                    lblTitle.Text = "선택팝업";
                    lblSearchLabel.Text = "불량코드/명";
                    gbxMain.Text = gridTitle;
                    break;
                case "DETAIL":
                    lblTitle.Text = "선택팝업";
                    lblSearchLabel.Text = "불량코드/명";
                    gbxMain.Text = gridTitle;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        /// <param name="type"></param>
        private void InitializeGrid()
        {
            grdMain.AutoGenerateColumns = false;
            grdMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdMain.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdMain.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdMain, "코드", "CODEID", "CODEID", typeof(string), 150, true);
            CommonFuction.SetDataGridViewColumnStyle(grdMain, "이름", "CODENAME", "CODENAME", typeof(string), 250, true);
        }

        #endregion
    }
}
