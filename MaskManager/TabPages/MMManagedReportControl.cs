using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using MaskManager.PopUp;
using System.Drawing.Printing;

namespace MaskManager.TabPages
{
    public partial class MMManagedReportControl : UserControl
    {
        DBManager manager = new DBManager();
        DataSet ds = new DataSet();
        int ColumnIndex = -1;
        int RowIndex = -1;
        int RowPos = 0;
        DialogResult result;
       

        public MMManagedReportControl()
        {
            InitializeComponent();
            InitGridView();
            this.Dock = DockStyle.Fill;
        }

        private void InitGridView()
        {
        
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;

            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight * 2;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            dataGridView1.Paint += DataGridView1_Paint;
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            dataGridView1.ColumnWidthChanged += DataGridView1_ColumnWidthChanged;
            dataGridView1.Scroll += DataGridView1_Scroll;

            btnExcel.Click += BtnExcel_Click;
            btnPrint.Click += BtnPrint_Click;
            btnSearch.Click += BtnSearch_Click;
            //컬럼명 setting
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "No", "No", "No", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleLeft, 10);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "보관위치", "rackid", "rackid", typeof(string), 70, true, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "Mask No", "durableid", "durableid", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 20);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "Mask Code", "productname", "productname", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleLeft, 80);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "입고일자", "inputdate", "inputdate", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "수입검사 결과", "inputresult", "inputresult", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleCenter, 35);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "사용일자", "usedate", "usedate", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "횟수", "totuseqty", "totuseqty", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleRight, 35);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "폐기일", "defectdate", "defectdate", typeof(string), 150, true, true, DataGridViewContentAlignment.MiddleLeft, 60);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "사유", "defectreason", "defectreason", typeof(string), 100, true, true, DataGridViewContentAlignment.MiddleLeft, 100);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "durableproductid", "durableproductid", "durableproductid", typeof(string), -1, false, false);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView1, "state", "state", "state", typeof(string), -1, false, false);
      
            //헤더 병합 안된 컬럼들 가운데 정렬하기
            dataGridView1.Columns["No"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["rackid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["durableid"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["productname"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["inputdate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["inputresult"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            CommonFuction.SetDataGridViewColumnStyle(dataGridView2, "날짜", "usedate", "usedate", typeof(DateTime), 130, true, true, DataGridViewContentAlignment.MiddleCenter);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView2, "횟수", "useqty", "useqty", typeof(string), 50, true, true, DataGridViewContentAlignment.MiddleRight);
            CommonFuction.SetDataGridViewColumnStyle(dataGridView2, "durableid", "durableid", "durableid", typeof(string), -1, false, false);

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var sBtnValue = "";

            if (radioButton1.Checked == true)
            {
                //전체
                sBtnValue = "all";
            }
            else if (radioButton2.Checked == true)
            {
                //폐기
                sBtnValue = "defect";
            }
            else if (radioButton3.Checked == true)
            {
                //재공
                sBtnValue = "active";
            }

            if (sBtnValue.Equals(""))
            {
                result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "조회 조건을 선택해주세요.");
            }
            else
            {
                SearchGrid(sBtnValue);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "인쇄 데이터가 없습니다.");

            }
            else
            {
                RowPos = 0;
                PrintDocument pd = new PrintDocument();
                //pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.PrintPage += new PrintPageEventHandler(MakePrintDocument);
                pd.BeginPrint += Pd_BeginPrint;

                //미리보기 생성
                PrintPreviewDialog ppv = new PrintPreviewDialog();
                ppv.Document = pd;

                pd.DefaultPageSettings.Landscape = true;
                ppv.ShowDialog();
            }
        }

        private void Pd_BeginPrint(object sender, PrintEventArgs e)
        {
            RowPos = 0;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "엑셀 데이터가 없습니다.");
                }
                else
                {
                    sfd.Filter = "csv(*.csv) | *.csv";

                    result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "엑셀 저장 하시겠습니까?");

                    if (result == DialogResult.OK)
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            this.SaveCsv(sfd.FileName, dataGridView1, true);
                        }
                    }

                }
            }
        }



        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            Bitmap resize = new Bitmap(bm, new Size(e.PageBounds.Width, e.PageBounds.Height));
            e.Graphics.DrawImage(resize, 0, 0);
        }

        private void MakePrintDocument(object sender, PrintPageEventArgs e)
        {
            int tmpWidth, i;
            int tmpTop = e.MarginBounds.Top;
            int tmpLeft = e.MarginBounds.Left;
            int HeaderHeight = 0;
            int PageNo = 1;
            List<int> ColumnWidths = new List<int>();
            List<int> ColumnLefts = new List<int>();
            List<string> ColumnTypes = new List<string>();
            string PrintTitle = "";
            int RowsPerPage = 0;
            bool NewPage = true;
            RowsPerPage = (int) Math.Ceiling((double)dataGridView1.Height / (double)e.MarginBounds.Height);
            DataGridView test = dataGridView1;
            test.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            try
            {
                // Before starting first page, it saves
                // Width & Height of Headers and CoulmnType
                if (PageNo == 1)
                {
                    foreach (DataGridViewColumn GridCol in test.Columns)
                    {
                        if (!GridCol.Visible) continue;

                        // Detemining whether the columns
                        // are fitted to the page or not.
                        if (test.Width > e.PageBounds.Width)
                            tmpWidth = (int)(Math.Floor((double)(
                                       (double)GridCol.Width*
                                       ((double)e.MarginBounds.Width /
                                        (double)test.Width))));
                        else
                            tmpWidth = GridCol.Width;

                        HeaderHeight =
                           (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, tmpWidth).Height) + 20;

                        // Save width & height of headres and ColumnType
                        ColumnLefts.Add(tmpLeft);
                        ColumnWidths.Add(tmpWidth);
                        ColumnTypes.Add(GridCol.CellType.Name);
                        tmpLeft += tmpWidth;
                    }
                }

                // Printing Current Page, Row by Row
                while (RowPos <= test.Rows.Count - 1)
                {
                    int CellHeight = 0;

                    DataGridViewRow GridRow = test.Rows[RowPos];
                    if (GridRow.IsNewRow)
                    {
                        RowPos++;
                        continue;
                    }

                    CellHeight = (int)Math.Floor((double)(GridRow.Height * 1.5));

                    if (tmpTop + CellHeight >=
                         e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        NewPage = true;
                        PageNo++;
                        e.HasMorePages = true;
                        tmpTop = e.MarginBounds.Top;
                        return;
                    }
                    else
                    {
                        if (NewPage)
                        {
                            // Draw Print Title
                            e.Graphics.DrawString(PrintTitle,
                                   new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left,
                                    e.MarginBounds.Top -
                                    e.Graphics.MeasureString(PrintTitle,
                                    new Font(dataGridView1.Font,
                                    FontStyle.Bold),
                                    e.MarginBounds.Width).Height - 20);

                            String s = DateTime.Now.ToLongDateString() + " " +
                                       DateTime.Now.ToShortTimeString();
                            // Draw Time and Date    
                            e.Graphics.DrawString(s,
                                    new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left +
                                    (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(s, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width),
                                    e.MarginBounds.Top -
                                    e.Graphics.MeasureString(PrintTitle,
                                    new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold),
                                    e.MarginBounds.Width).Height - 20);

                            // Draw Headers
                            tmpTop = e.MarginBounds.Top;
                            i = 0;
                            foreach (DataGridViewColumn GridCol in test.Columns)
                            {
                                if (!GridCol.Visible) continue;

                                e.Graphics.FillRectangle(new
                                    SolidBrush(Color.LightGray),
                                    new Rectangle((int)ColumnLefts[i], tmpTop,
                                    (int)ColumnWidths[i], HeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)ColumnLefts[i], tmpTop,
                                    (int)ColumnWidths[i], HeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)ColumnLefts[i], tmpTop,
                                    (int)ColumnWidths[i], HeaderHeight));
                                i++;
                            }
                            NewPage = false;
                            tmpTop += HeaderHeight;
                        }

                        // Draw Columns Contents
                        i = 0;
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (!Cel.OwningColumn.Visible) continue;

                            // For the TextBox Column
                            if (ColumnTypes[i] ==
                                 "DataGridViewTextBoxCell")
                            {
                                bool DrawCheck = true;
                                if (Cel.OwningColumn.HeaderText.Equals("폐기일"))
                                {
                                    if (Cel.Value.ToString().Equals("폐기"))
                                    {
                                        DrawCheck = false;
                                    }
                                }
                                if (DrawCheck)
                                {
                                    e.Graphics.DrawString(Cel.Value.ToString(),
                                            Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)ColumnLefts[i],
                                            (float)tmpTop,
                                            (int)ColumnWidths[i],
                                            CellHeight));
                                }
                            }
                            // Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)ColumnLefts[i],
                                    tmpTop, (int)ColumnWidths[i], CellHeight));

                            i++;

                        }
                        tmpTop += CellHeight;
                    }

                    RowPos++;
                    // For the first page it calculates Rows per Page
                    if (PageNo == 1) RowsPerPage++;
                }

                if (RowsPerPage == 0) return;


                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        //csv 파일 내보내기
        private void SaveCsv(string fileName, DataGridView dgv, bool header)
        {
            string delimiter = ",";
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs,Encoding.UTF8);

            if(dgv.Rows.Count == 0)
            {
                return;
            }

            if (header)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    //숨겨진 컬럼은 엑셀 내보내기 안되도록 수정
                    if (dgv.Columns[i].HeaderText.Equals("durableproductid") || dgv.Columns[i].HeaderText.Equals("state")) {
                        break;
                    }else{
                        csvExport.Write(dgv.Columns[i].HeaderText);
                    }

                    if (i != dgv.Columns.Count - 1)
                     {
                        csvExport.Write(delimiter);
                     }
                }
            }
            
            csvExport.Write(csvExport.NewLine);

            foreach(DataGridViewRow row in dgv.Rows)
            {
                for(int j=0; j<dgv.Columns.Count; j++)
                {

                    //숨겨진 컬럼은 row 엑셀에 내보내기 안되도록 수정
                    if (dgv.Columns[j].HeaderText.Equals("durableproductid") || dgv.Columns[j].HeaderText.Equals("state")){
                        break;
                    }else{
                        csvExport.Write(row.Cells[j].Value);
                    }
                    
                    if(j != dgv.Columns.Count - 1)
                    {
                        csvExport.Write(delimiter);
                    }
                }

                csvExport.Write(csvExport.NewLine);
            }

            csvExport.Flush();
            csvExport.Close();
            fs.Close();

            result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "저장 되었습니다.");
        }

        //csv 파일 생성하기


        private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(rtHeader);
        }

        //그리드 헤더 병합
        private void DataGridView1_Paint(object sender, PaintEventArgs e)
        {
           
            string[] sHeader = { "사용 이력", "폐기" };

            for (int i = 6; i < dataGridView1.Columns.Count - 1;)
            {
                Rectangle ra = this.dataGridView1.GetCellDisplayRectangle(i, -1, true);
                int width = this.dataGridView1.GetCellDisplayRectangle(i, -1, true).Width;

                ra.X += 1;
                ra.Y += 1;

                ra.Width = 0;
                //컬럼 사이즈에 맞춰서 헤더 width값 설정하기
                if (i.Equals(6))
                {
                    ra.Width = dataGridView1.Columns["usedate"].Width + dataGridView1.Columns["totuseqty"].Width -2;
                }
                else if (i.Equals(8)) {
                    ra.Width = dataGridView1.Columns["defectdate"].Width + dataGridView1.Columns["defectreason"].Width -2;
                }
                

                ra.Height = ra.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), ra);

                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                if (i.Equals(6))
                {
                    //사용이력
                    e.Graphics.DrawString(sHeader[0],
                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), ra, format);
                }
                else if (i.Equals(8))
                {
                    //폐기
                    e.Graphics.DrawString(sHeader[1],
                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), ra, format);
                }

                i += 2;
            }
        }



        //Data 조회 이벤트
        private void SearchGrid(String name)
        {
            if (name.Equals("all")){
                //전체인 경우 조회
                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(new SqlParameter("@state", ""));

                DataSet QueryList = manager.CallSelectProcedure_ds("ManagerListBySelect", Params);

                if (QueryList.Tables.Count == 0)
                {
                    MessageBox.Show("ERROR");
                }
                else
                {
                    dataGridView1.RowPostPaint += DataGridView1_RowPostPaint;
                    dataGridView1.DataSource = QueryList.Tables[0];

                   
                    for (int i = 0; i < QueryList.Tables[0].Rows.Count;)
                    {
     
                        //if (CommonFuction.IsNullOrWhiteSpace(QueryList.Tables[0].Rows[i]["DEFECTDATE"]))
                        if (!QueryList.Tables[0].Rows[i]["state"].ToString().Equals("STATE_SCRAPPED")
                            && !QueryList.Tables[0].Rows[i]["state"].ToString().Equals("STATE_TERMINATED"))
                        {
                            dataGridView1.Rows[i].Cells["DEFECTDATE"].Value = "";
                            dataGridView1.Rows[i].Cells["DEFECTDATE"] = new DataGridViewButtonCell();
                            dataGridView1.Rows[i].Cells["DEFECTDATE"].Value = "폐기";
                            dataGridView1.CellClick += DataGridView1_CellClick;
                        }

                        i += 1;
                        
                    }

                }
            }else if (name.Equals("defect")){
                //폐기인 경우 조회
                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(new SqlParameter("@state", "STATE_SCRAPPED,STATE_TERMINATED"));

                DataSet QueryList = manager.CallSelectProcedure_ds("ManagerListBySelect", Params);

                if (QueryList.Tables.Count == 0)
                {
                    MessageBox.Show("ERROR");
                }
                else
                {
                    dataGridView1.RowPostPaint += DataGridView1_RowPostPaint;
                    dataGridView1.DataSource = QueryList.Tables[0];

                    for(int j=0; j < QueryList.Tables[0].Rows.Count;)
                    {
                        if (CommonFuction.IsNullOrWhiteSpace(QueryList.Tables[0].Rows[j]["DEFECTDATE"]))
                        {
                            dataGridView1.Rows[j].Cells["DEFECTDATE"] = new DataGridViewButtonCell();
                            dataGridView1.Rows[j].Cells["DEFECTDATE"].Value = "폐기";

                            dataGridView1.CellClick += DataGridView1_CellClick;
                        }

                        j += 1;
                    }
                    
                }
            }else if (name.Equals("active")){
                //제공인 경우 조회
                List<SqlParameter> Params = new List<SqlParameter>();
                Params.Add(new SqlParameter("@state", "STATE_ACTIVE"));

                DataSet QueryList = manager.CallSelectProcedure_ds("ManagerListBySelect", Params);

                if (QueryList.Tables.Count == 0)
                {
                    MessageBox.Show("ERROR");
                }
                else
                {
                    dataGridView1.RowPostPaint += DataGridView1_RowPostPaint;
                    dataGridView1.DataSource = QueryList.Tables[0];

                    for (int t = 0; t < QueryList.Tables[0].Rows.Count;)
                    {
                        if (CommonFuction.IsNullOrWhiteSpace(QueryList.Tables[0].Rows[t]["DEFECTDATE"]))
                        {
                            dataGridView1.Rows[t].Cells["DEFECTDATE"] = new DataGridViewButtonCell();
                            dataGridView1.Rows[t].Cells["DEFECTDATE"].Value = "폐기";

                            dataGridView1.CellClick += DataGridView1_CellClick;
                        }

                        t += 1;
                    }
                }
            }
            dataGridView1.MouseClick += DataGridView1_MouseClick;
            
        }

        //폐기 버튼 누르면 폐기 팝업으로 이동
        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ColumnIndex > 0 && RowIndex > -1)
            {
                if (dataGridView1.Columns[ColumnIndex].Name.ToUpper() == "DEFECTDATE")
                {
                    if (dataGridView1.Rows[RowIndex].Cells["DEFECTDATE"].Value.Equals("폐기"))
                    {
                        PopUp.MMScrapPop mms = new PopUp.MMScrapPop();

                        mms.ManagerScrap(dataGridView1.Rows[RowIndex].Cells["durableid"].Value.ToString());
                        mms.StartPosition = FormStartPosition.CenterScreen;
                    }
                }
            }
        }

        private void DataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);
        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        //그리드에 행 번호 보여주기
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        //횟수 Row 선택하면 해당 사용이력 보여주기
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ColumnIndex = e.ColumnIndex;

            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                ColumnIndex = e.ColumnIndex;
                RowIndex = e.RowIndex;

               // if (dataGridView1.Columns[ColumnIndex].Name.ToUpper() == "TOTUSEQTY")
              //  {

                    List<SqlParameter> Params = new List<SqlParameter>();
                    Params.Add(new SqlParameter("@durableid", dataGridView1.Rows[e.RowIndex].Cells["durableid"].Value));

                    DataSet QueryList = manager.CallSelectProcedure_ds("ManagerUseListBySelect", Params);

                    if (QueryList.Tables.Count == 0)
                    {
                        MessageBox.Show("사용이력이 없습니다");
                    }
                    else
                    {
                        dataGridView2.DataSource = QueryList.Tables[0];
                        maskTextBox1.ucTextReadOnly = true;
                        maskTextBox1.ucValue = dataGridView1.Rows[e.RowIndex].Cells["totuseqty"].Value.ToString();

                    }
              //  }
            }
        }
    }
}
