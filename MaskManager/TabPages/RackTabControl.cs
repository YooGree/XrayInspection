using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaskManager.UserControls;
using MaskManager.PopUp;

namespace MaskManager.TabPages
{
    /// <summary>
    ///  * 파 일 명 : UserTabPageControl.cs 					
    ///  * 작 성 자 : 강선애
    ///  * 설     명 : 기준정보 > 적치대
    ///  * 이     력 : 2019-05-02 [강선애] : 신규추가	
    ///               
    /// </summary>
    public partial class RackTabControl : UserControl
    {
        DBManager conn = new DBManager();
        DataTable bSucc;
        DialogResult result;

        // 사용 프로시저
        string EQUIPMENTID = "EQUIPMENTID";
        string SelectRackByLoc = "SelectRackByLoc";
        string SelectRackByID = "SelectRackByID";
        string ProcEquipmentInUserTab = "ProcEquipmentInUserTab";

        string MAXX = "MAXX";
        string MAXY = "MAXY";


        public RackTabControl()
        {
            InitializeComponent();
            SetEvent();
            Dock = DockStyle.Fill;
          

        }


        /// <summary>
        /// * 함 수 명 : SetEvent
        /// * 개 요 : 이벤트 함수 정의						
        /// </summary>
        /// 
        void SetEvent()
        {
            try
            {
                conn.Open();

                if (conn.CheckConnectState() == false)
                    MessageBox.Show("연결실패");


                Load += RackTabControl_Load;

                dtgRack.RowPostPaint += DtgRack_RowPostPaint; // 행 번호 이벤트

                btnDesign.Click += BtnDesign_Click; // datagridview 디자인
                btnSave.Click += BtnSave_Click; // 저장

                txtWidth.KeyPress += TxtWidth_KeyPress;
                txtHeight.KeyPress += TxtHeight_KeyPress;

                txtWidth.TextAlign = HorizontalAlignment.Center; // textbox 가운데 정렬
                txtHeight.TextAlign = HorizontalAlignment.Center; // textbox 가운데 정렬

                dtgRack.ReadOnly = false;

            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
            }
        }

        /// <summary>
        /// * 함 수 명 : TxtWidth_KeyPress
        /// * 개 요 : 숫자만 입력 가능 / 엔터 포커싱
        /// </summary>
        /// 
        private void TxtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonFuction.TypingOnlyNumber(sender, e, false);
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtHeight.Focus();
            }
        }


        /// <summary>
        /// * 함 수 명 : TxtHeight_KeyPress
        /// * 개 요 : 숫자만 입력 가능 / 엔터 포커싱
        /// </summary>
        /// 
        private void TxtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonFuction.TypingOnlyNumber(sender, e, false);
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDesign.Focus();
            }

        }


        /// <summary>
        ///  작성자 : 강선애
        ///  작성일 : 
        ///  단축 키 지정 이벤트 추가
        /// </summary>

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.F2:
                    BtnDesign_Click();
                    break;
                case Keys.F3:
                    BtnSave_Click();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        /// <summary>
        /// * 함 수 명 : RackInit
        /// * 개 요 : MaxX, MaxY 값으로 적치대를 디자인한다.
        ///           디자인된 화면에 위치한 EQUIPMENTID를 CELL에 삽입한다.
        /// </summary>
        /// 
        void RackInit()
        {
            try
            {

                dtgRack.ColumnCount = Program.MaxX; // 적치대 가로길이
                dtgRack.RowCount = Program.MaxY; // 적치대 세로길이

                txtWidth.Text = Program.MaxX.ToString();
                txtHeight.Text = Program.MaxY.ToString();

                for (int i = 0; i < Program.MaxX; i++)
                {
                    for (int j = 0; j < Program.MaxY; j++)
                    {
                        var param = new Dictionary<string, object>();
                        param.Add("@LOC_X", (i + 1));
                        param.Add("@LOC_Y", (j + 1));
                        bSucc = conn.ExecuteProcedure(SelectRackByID, param);

                        if (bSucc.Rows.Count > 0)
                            dtgRack.Rows[j].Cells[i].Value = bSucc.Rows[0][EQUIPMENTID];
                    }
                    dtgRack.Columns[i].HeaderText = (i + 1).ToString();
                }

                // 컬럼 헤더 클릭 시 sort 되지 않도록 설정
                foreach (DataGridViewColumn i in dtgRack.Columns)
                {
                    i.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                // Column Width 고정
                for (int i = 0; i < dtgRack.Columns.Count; i++)
                {
                    dtgRack.Columns[i].Width = (dtgRack.Width - 45) / dtgRack.Columns.Count;
                }
                dtgRack.CurrentCell = null;

            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
            }

        }


        /// <summary>
        /// * 함 수 명 : RackTabControl_Load
        /// * 개 요 : 기존 MC_EQUIPMENT에 저장되어있는 적치대 정보를
        ///           DATAGRIDVIEW CELL에 입력하도록 한다.
        ///           MC_EQUIPMENT TABLE LOCATIONX,LOCATIONY 사용
        ///           
        /// </summary>
        private void RackTabControl_Load(object sender, EventArgs e)
        {
            try
            {
                bSucc = conn.ExecuteProcedure(SelectRackByLoc);
                if (bSucc.Rows.Count < 0)
                {
                    //CustomMessageBox.Show(MessageBoxButtons.OK,"","화면을 디자인해주세요.");
                    dtgRack.ColumnCount = 0;
                    dtgRack.RowCount = 0;
                }
                Program.MaxX = (int)bSucc.Rows[0][MAXX];
                Program.MaxY = (int)bSucc.Rows[0][MAXY];

                RackInit();
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
            }
        }



        /// <summary>
        /// * 함 수 명 : BtnSave_Click
        /// * 개 요 : 현재 셀 데이터를 DB에 저장
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            BtnSave_Click();
        }

        private void BtnSave_Click()
        {
            try
            {
                result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "", "저장하시겠습니까?");
                if (result == DialogResult.OK)
                {
                    StringBuilder sBuilder = new StringBuilder();
                    //cell의  비어있지 않은 것만 insert or update 처리
                    for (int i = 0; i < dtgRack.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtgRack.Columns.Count; j++)
                        {
                            if (dtgRack.Rows[i].Cells[j].Value == null || dtgRack.Rows[i].Cells[j].Value == DBNull.Value)
                                continue;
                            else
                            {
                                sBuilder.Append(dtgRack.Rows[i].Cells[j].Value + "," + (j + 1) + "," + (i + 1) + "/");
                            }
                        }
                    }


                    var param = new Dictionary<string, object>();
                    param.Add("@objstr", sBuilder.ToString(0, sBuilder.Length - 1));
                    param.Add("@userid", Program.CurrentUser);
                    bSucc = conn.ExecuteProcedure(ProcEquipmentInUserTab, param);
                    // conn.CallNonSelectProcedure("RackByUpsert", conn.GetSqlParameters(param));

                    if (bSucc == null)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "", "저장할 항목이 없습니다.");
                    }

                    Program.MaxX = dtgRack.ColumnCount;
                    Program.MaxY = dtgRack.RowCount;

                    CustomMessageBox.Show(MessageBoxButtons.OK, "", "저장되었습니다.");
                    RackInit();
                }
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
            }

        }

        /// <summary>
        /// * 함 수 명 : BtnDesign_Click
        /// * 개 요 : TEXTBOX에 입력된 값을 가지고 그리드뷰 디자인
        /// </summary>
        private void BtnDesign_Click(object sender, EventArgs e)
        {
            BtnDesign_Click();
        }


        private void BtnDesign_Click()
        {
            this.dtgRack.Rows.Clear();

            try
            {
                string width = txtWidth.Text;
                string height = txtHeight.Text;

                if (string.IsNullOrWhiteSpace(width) == true || string.IsNullOrWhiteSpace(height) == true)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "", "빈칸에 숫자를 입력해주세요.");
                }
                
                else
                {
                    
                    result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "", "가로 : " + width +
                        " , 세로 : " + height + "(으)로 설정하시겠습니까? ");

                    if (result == DialogResult.OK)
                    {
                        Program.MaxX = int.Parse(width);
                        Program.MaxY = int.Parse(height);

                        dtgRack.ColumnCount = Program.MaxX;

                        int j = 1;
                        while (j <= Program.MaxY)
                        {
                            dtgRack.Rows.Add();
                            j++;
                        }
                    }
                }
                RackInit();
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
            }
        }



        /// <summary>
        /// * 함 수 명 : Dgv_User_RowPostPaint	
        /// * 개 요 : 행 해더에 순차적으로 숫자 입력							
        /// </summary>
        private void DtgRack_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //  dtgRack.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            // DataGridView 맨 왼쪽 첫 번째 열에 행 번호 나타내기
            DataGridView dataGridView = sender as DataGridView;
            string rowNumber = (e.RowIndex + 1).ToString();
            StringFormat stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            Rectangle drawRectangle = new Rectangle
            (
                e.RowBounds.Left,
                e.RowBounds.Top,
                dataGridView.RowHeadersWidth,
                e.RowBounds.Height
            );
            e.Graphics.DrawString(rowNumber, this.Font, SystemBrushes.ControlText, drawRectangle, stringFormat);
        }
    }
}