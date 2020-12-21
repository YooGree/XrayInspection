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

namespace MaskManager.PopUp
{
    public partial class CS_CommonPopup : ParentsPop
    {
        #region 변수

        private string procedureName = ""; // 프로시저명
        private DBManager conn = new DBManager(); // DB 접속정보    
        public string returnCodeValue = ""; // 리턴코드값
        public string returnNameValue = ""; // 리턴명값
        public string returnCodeNameValue = ""; // 리턴코드+명값

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="type">팝업유형</param>
        public CS_CommonPopup(string type)
        {
            InitializeComponent();
            InitializeControlSetting(type);
            InitializeGrid(type);
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
            grdMain.CellContentDoubleClick += grdMain_CellContentDoubleClick;
        }

        /// <summary>
        /// 셀 더블클릭시 확인적용
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdMain_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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

            this.returnCodeValue = gRow.Cells["CODE"].Value.ToString();
            this.returnNameValue = gRow.Cells["NAME"].Value.ToString();
            this.returnCodeNameValue = returnCodeValue + " : " + returnNameValue;
            this.Close();
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
                parameters.Add(new SqlParameter("@SEARCHTEXT", txtSearchText.Text)); // 조회조건

                DataSet ds = conn.CallSelectProcedure_ds(procedureName, parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    DataTable dt = ds.Tables[0];
                    grdMain.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "닫기", ex.Message);
            }
        }

        #endregion

        #region 사용자 정의 함수

        /// <summary>
        /// 컨트롤 라벨세팅
        /// </summary>
        /// <param name="type"></param>
        private void InitializeControlSetting(string type)
        {
            Footer.Visible = false;

            switch(type)
            {
                case "JUDGMENTRESULT":
                    procedureName = "";
                    lblTitle.Text = "판독결과";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        /// <param name="type"></param>
        private void InitializeGrid(string type)
        {
            string codeColumn = "";
            string nameColumn = "";

            switch (type)
            {
                case "VENDER":
                    codeColumn = "venderid";
                    nameColumn = "vendername";
                    break;
                case "EQUIP":
                    codeColumn = "equipmentid";
                    nameColumn = "equipmentname";
                    break;
                case "USER":
                case "LOGIN":
                    codeColumn = "userid";
                    nameColumn = "username";
                    break;
                default:
                    break;
            }
            grdMain.AutoGenerateColumns = false;
            CommonFuction.SetDataGridViewColumnStyle(grdMain, "코드", codeColumn, "code", typeof(string), 150);
            CommonFuction.SetDataGridViewColumnStyle(grdMain, "이름", nameColumn, "name", typeof(string), 250);
        }

        #endregion
    }
}
