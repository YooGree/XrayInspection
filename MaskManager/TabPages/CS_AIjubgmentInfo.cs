using MaskManager.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// 설        명  : AI 판정정보 화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_AIjubgmentInfo : UserControl
    {
        #region 변수

        int _lastRowIndex = -1; // 마지막 행의 Index

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public CS_AIjubgmentInfo()
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
        }

        /// <summary>
        /// 현재 선택된 Row 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdFrameInfo.Rows.Count; i++)
            {
                // 행 선택 여부
                grdFrameInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (grdFrameInfo.Rows[i].Selected == true)
                {
                    // 현재 선택된 인덱스에 해당된 Row 삭제
                    grdFrameInfo.Rows.Remove(grdFrameInfo.Rows[i]);
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
            _lastRowIndex = grdFrameInfo.Rows.Count;
            grdFrameInfo.Rows.Add();
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
                if (grdFrameInfo.Rows.Count == 0)
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
                            this.SaveCsv(sfd.FileName, grdFrameInfo, true);
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
            radioAll.Checked = true;
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            //grdMain.AutoGenerateColumns = false;
            grdFrameInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdFrameInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdFrameInfo.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "No", "PRODUCTID", "No", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "시간", "PRODUCTTYPE", "rackid", typeof(string), 200, false, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "프레임", "PRODUCTNAME", "durableid", typeof(int), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "자동판정등급", "PRODUCTNO", "productname", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 80);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "불량유형", "CUSTOMERNAME", "inputdate", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 60);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "최종판정", "CREATOR", "inputresult", typeof(string), 100, false, true, DataGridViewContentAlignment.MiddleCenter, 35);
            CommonFuction.SetDataGridViewColumnStyle(grdFrameInfo, "위치", "CREATETIME", "usedate", typeof(string), 500, false, true, DataGridViewContentAlignment.MiddleLeft, 60);
        }

        #endregion

    }
}
