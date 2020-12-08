using MaskManager.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// 작   성   일  : 2020-12-08
    /// 설        명  : AI 판정이력 화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_AIjubgmentHistory : UserControl
    {
        #region 변수

        int _lastRowIndex = -1; // 마지막 행의 Index

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public CS_AIjubgmentHistory()
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
            grdAIjubgmentHistory.RowPostPaint += GrdAIjubgmentHistory_RowPostPaint;
        }

        /// <summary>
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdAIjubgmentHistory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            grdAIjubgmentHistory.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DBManager dbManager = new DBManager();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CUSTOMERNAME", txtCustomerName.Text)); // 고객명
            parameters.Add(new SqlParameter("@PRODUCTNUMBER", txtProductNumber.Text)); // 도번
            parameters.Add(new SqlParameter("@FRDATE", dateFrom.Value)); // 조회일자(From)
            parameters.Add(new SqlParameter("@TODATE", dateTo.Value)); // 조회일자(To)
            parameters.Add(new SqlParameter("@LOTNUMBER", txtLotNumber.Text)); // LOT 번호

            // 전체조회
            if (radioAll.Checked == true)
            {
                parameters.Add(new SqlParameter("@STATE", "ALL")); // 상태        
            }
            // 정상조회
            else if (radioNormal.Checked = true)
            {
                parameters.Add(new SqlParameter("@STATE", "NORMAL")); // 상태
            }
            // 불량조회
            else
            {
                parameters.Add(new SqlParameter("@STATE", "DEFECT")); // 상태
            }

            DataSet ds = dbManager.CallSelectProcedure_ds("PS_SELECTAIJUBGMENTHISTORY");

            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("Error");
            }
            else
            {
                grdAIjubgmentHistory.DataSource = ds.Tables[0];
            }
        }

        /// <summary>
        /// 현재 선택된 Row 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdAIjubgmentHistory.Rows.Count; i++)
            {
                // 행 선택 여부
                grdAIjubgmentHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (grdAIjubgmentHistory.Rows[i].Selected == true)
                {
                    // 현재 선택된 인덱스에 해당된 Row 삭제
                    grdAIjubgmentHistory.Rows.Remove(grdAIjubgmentHistory.Rows[i]);
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
            _lastRowIndex = grdAIjubgmentHistory.Rows.Count;
            grdAIjubgmentHistory.Rows.Add();
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
                if (grdAIjubgmentHistory.Rows.Count == 0)
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
                            this.SaveCsv(sfd.FileName, grdAIjubgmentHistory, true);
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
                    if (dgv.Columns[i].HeaderText.Equals("durableproductid") || dgv.Columns[i].HeaderText.Equals("state"))
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
                    if (dgv.Columns[j].HeaderText.Equals("durableproductid") || dgv.Columns[j].HeaderText.Equals("state"))
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

        #region 사용자 정의 함수

        /// <summary>
        /// 기본 컨트롤 세팅
        /// </summary>
        private void InitializeControlSetting()
        {
            this.Dock = DockStyle.Fill;
            radioAll.Checked = true; // 조회조건 기본 전체로 세팅
            dateTo.Value = DateTime.Now; // 조회조건의 To 날짜는 오늘로 세팅
            dateFrom.Value = DateTime.Now.AddDays(-7); // 조회조건의 From 날짜는 To 날짜의 7일전으로 세팅
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            //grdMain.AutoGenerateColumns = false;
            grdAIjubgmentHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdAIjubgmentHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdAIjubgmentHistory.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "No", "PRODUCTID", "No", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "고객", "PRODUCTTYPE", "rackid", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "도번", "PRODUCTNAME", "durableid", typeof(int), 180, false, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "품번", "PRODUCTNO", "productname", typeof(string), 180, false, true, DataGridViewContentAlignment.MiddleCenter, 80);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "LOT번호", "CUSTOMERNAME", "inputdate", typeof(string), 250, false, true, DataGridViewContentAlignment.MiddleCenter, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "검사일자", "CREATOR", "inputresult", typeof(string), 200, false, true, DataGridViewContentAlignment.MiddleCenter, 35);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "최종판정", "CREATETIME", "usedate", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "AI판정", "MODIFIER", "usedate", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdAIjubgmentHistory, "불량유형", "MODIFIEDTIME", "usedate", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleLeft, 60);
        }

        #endregion

    }
}
