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
    /// 작성자 : 임한의
    /// 설명 : 모델에서 기존 데이터들 확인,추가,변경,삭제를 할 수 있는 화면
    /// 함수목록 : DataGridViewProperties, SetEvent, TxtText_KeyPress, DurableProdTabPageControl_Load, AddParam
    ///           Dtg_DurableProd_Click, TableRefresh, MakeEmpty, BtnNew_Click, BtnSave_Click
    ///           DtgDurableProd_RowPostPaint
    /// 프로시저 : DeleteDurableProductId, ProcDurableProductInDurableProdTab, SelectDURABLEPRODUCT
    /// 이력 : 
    /// </summary>
    public partial class DurableProdTabPageControl : TabPageControl
    {
        DBManager db = new DBManager();
        DataTable table;
        bool state = false;
        string sql;
        DialogResult result;
        public DurableProdTabPageControl()
        {
            InitializeComponent();
            Load += DurableProdTabPageControl_Load;
            SetEvent();
        }
        private void DurableProdTabPageControl_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtProdId;
            CommonFuction.SetUseYNList(ref cbbUseYn);
            txtVender.ucReadOnly = true;

            try
            {
                sql = "SelectDURABLEPRODUCT";
                db.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                dtgDurableProd.DataSource = db.ExecuteProcedure(sql, param);
                DataGridViewProperties();
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다.\n 로그를 확인하세요.");
            }
        }
        /// <summary>
        /// 그리드뷰 정렬 및 헤더 한글
        /// </summary>
        private void DataGridViewProperties()
        {
            dtgDurableProd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDurableProd.Columns["DURABLEPRODUCTID"].HeaderText = "모델코드";
            dtgDurableProd.Columns["DURABLEPRODUCTNAME"].HeaderText = "모델명";
            dtgDurableProd.Columns["VENDERID"].HeaderText = "업체코드";
            dtgDurableProd.Columns["MASKSIZE"].HeaderText = "사이즈";
            dtgDurableProd.Columns["MASKTHICK"].HeaderText = "두께";
            dtgDurableProd.Columns["LIMITUSEQTY"].HeaderText = " 사용\n한계수량";
            dtgDurableProd.Columns["WARNINGUSEQTY"].HeaderText = " 사용\n경고수량";
            dtgDurableProd.Columns["USEYN"].HeaderText = "사용여부";
            dtgDurableProd.Columns["DESCRIPTION"].HeaderText = "Mask\n 사양정보";
            dtgDurableProd.Columns["COMMENT"].HeaderText = "특이사항";
            dtgDurableProd.Columns["CREATOR"].HeaderText = "생성자";
            dtgDurableProd.Columns["CREATEDATE"].HeaderText = "생성날짜";
            dtgDurableProd.Columns["EVENTDATE"].HeaderText = "변경날짜";
            dtgDurableProd.Columns["MODIFIER"].HeaderText = "변경자";

            dtgDurableProd.Columns["DURABLEPRODUCTID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDurableProd.Columns["MASKSIZE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDurableProd.Columns["MASKTHICK"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDurableProd.Columns["LIMITUSEQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDurableProd.Columns["WARNINGUSEQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDurableProd.Columns["COMMENT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }
        /// <summary>
        /// 이벤트 함수 모음
        /// 1. 그리드뷰 클릭 시 값 로드
        /// 2. 신규 클릭 시 기종코드 텍스트박스로 포커스
        /// 3. 변경 클릭 시 bool값에 따라 추가, 변경
        /// 4. 텍스트박스 키 입력 제한, 엔터키 입력 시 TAB키 반환
        /// 5. 행번호 추가이벤트
        /// </summary>
        private void SetEvent()
        {
            dtgDurableProd.Click += Dtg_DurableProd_Click;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            txtProdId.txtText.KeyPress += TxtText_KeyPress;
            txtProdName.txtText.KeyPress += TxtText_KeyPress;
            txtVender.txtText.KeyPress += TxtText_KeyPress;
            txtMaskSize.txtText.KeyPress += TxtText_KeyPress;
            txtMaskThick.txtText.KeyPress += TxtText_KeyPress;
            txtLimitUseQTY.txtText.KeyPress += TxtText_KeyPress;
            txtWarningUseQTY.txtText.KeyPress += TxtText_KeyPress;
            dtgDurableProd.RowPostPaint += DtgDurableProd_RowPostPaint;
            btnCopy.Click += BtnCopy_Click;

            this.dtgDurableProd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.txtProdId.txtText.CharacterCasing = CharacterCasing.Upper;

            txtProdId.txtText.KeyDown += DurableProdTabPageControl_KeyDown;
            txtProdName.txtText.KeyDown += DurableProdTabPageControl_KeyDown;
            txtVender.txtText.KeyDown += DurableProdTabPageControl_KeyDown;
            txtMaskSize.txtText.KeyDown += DurableProdTabPageControl_KeyDown;
            txtMaskThick.txtText.KeyDown += DurableProdTabPageControl_KeyDown;
            txtLimitUseQTY.txtText.KeyDown += DurableProdTabPageControl_KeyDown;
            txtWarningUseQTY.txtText.KeyDown += DurableProdTabPageControl_KeyDown;
            txtMaskThick.txtText.KeyPress += TxtText_KeyPress1;
        }

        private void TxtText_KeyPress1(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 5;
            int nPostLen = 3;

            TextBox editor = sender as TextBox;

            if (e.KeyChar == '\b') return;
            if (e.KeyChar == 22) return;

            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다) 
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치 
            int nCursor = editor.SelectionStart;
            //점과 숫자 이외의 값은 받아들이지 않음. 
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar)) e.Handled = true;
            //소숫점 이하 값이 없는 경우 
            else if (e.KeyChar == '.' && nPostLen < 1) e.Handled = true;
            //점이 포함되어 있을 경우 
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음. 
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음. 
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.') e.Handled = true;
                else
                {
                    //점의 위치를 구한다. 
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다. 
                    string[] sSep = editor.Text.Split('.');
                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음. 
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen) e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음. 
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen) { CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "소수점 3자리까지 입력하세요."); e.Handled = true; }
                    //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면 //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음. 
                    else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen) e.Handled = true;
                }
            }
                 else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen) e.Handled = true;
        }

        private void DurableProdTabPageControl_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Control temp = txt.Parent;
            MaskTextBox mtb = null;

            while (temp.Parent != null)
            {
                if (temp is MaskTextBox)
                {
                    mtb = temp as MaskTextBox;
                    break;
                }
                temp = temp.Parent;
            }
            if (mtb == null) return;

            if (e.Control && e.KeyCode == Keys.C)

            {
                //복사하기
                Clipboard.SetText(mtb.ucValue);
            }
        }


        /// <summary>
        /// * 함 수 명 : BtnCopy_Click
        /// * 개 요 : Datagridview 복사기능
        /// * 작 성 자 : 황지희
        /// </summary>
        /// 
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            if (this.dtgDurableProd.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {

                    DataObject dataObj = dtgDurableProd.GetClipboardContent();

                    Clipboard.SetDataObject(dataObj);
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {

                }
            }
        }

        /// <summary>
        /// 단축키 오버라이드 함수
        /// Ctrl + S = 저장버튼
        /// F5 = 신규버튼
        /// ESC = 닫기버튼
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.F2:
                    BtnNew_Click();
                    break;
                case Keys.F3:
                    BtnSave_Click();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// 행번호 추가 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtgDurableProd_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
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

        /// <summary>
        /// 텍스트박스 입력 키 제한,엔터키 입력시 TAB키 반환
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtText_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            Control temp = txt.Parent;
            MaskTextBox mtb = null;
            while (temp.Parent != null)
            {
                if (temp is MaskTextBox)
                {
                    mtb = temp as MaskTextBox;
                    break;
                }
                temp = temp.Parent;
            }
            if (mtb == null) return;

            switch (mtb.Name)
            {
                case "txtProdId":
                    CommonFuction.TypingOnlyEngNum(sender, e, txtProdId);

                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                
                case "txtMaskThick":
                    CommonFuction.TypingOnlyNumber(sender, e, true);
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                case "txtLimitUseQTY":
                case "txtWarningUseQTY":
                    CommonFuction.TypingOnlyNumber(sender, e, false);
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                case "txtProdName":
                case "txtMaskSize":
                    if (Char.IsLetter(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false && e.KeyChar != 8 && e.KeyChar == ',')
                    {
                        e.Handled = true;
                    }
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
            }
        }

        /// <summary>
        /// 버튼들의 이벤트가 발생 후 데이터그리드뷰를 새로고침 해주는 함수
        /// </summary>
        public void TableRefresh()
        {
            try
            {
                sql = "SelectDURABLEPRODUCT";
                table = new DataTable();
                Dictionary<string, object> param = new Dictionary<string, object>();
                dtgDurableProd.DataSource = db.ExecuteProcedure(sql, param);
                DataGridViewProperties();
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다.\n 로그를 확인하세요.");
            }
        }
        /// <summary>
        /// 공통적인 파라미터들의 값들을 저장하는 함수
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> AddParam()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("@Id", txtProdId.ucValue);
            param.Add("@Name", txtProdName.ucValue);
            param.Add("@VenderId", txtVender.ucValue);
            param.Add("@Size", txtMaskSize.ucValue);
            param.Add("@Thick", txtMaskThick.ucValue);
            param.Add("@Limit", txtLimitUseQTY.ucValue);
            param.Add("@Warning", txtWarningUseQTY.ucValue);
            param.Add("@Yn", cbbUseYn.ucText);
            param.Add("@Descript", txtDescript.ucValue);
            param.Add("@Comment", txtComment.ucValue);
            param.Add("@Creator", Program.CurrentUser);
            param.Add("@Modifier", Program.CurrentUser);
            return param;

        }
        /// <summary>
        /// 버튼의 이벤트들이 발생된 후 각각의 컨트롤러의 텍스트들을 초기화 해주는 함수
        /// </summary>
        public void MakeEmpty()
        {
            CommonFuction.SetUseYNList(ref cbbUseYn);
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is UserControls.MaskTextBox)
                {
                    UserControls.MaskTextBox tb = (UserControls.MaskTextBox)ctrl;
                    if (string.IsNullOrWhiteSpace(tb.ucValue) == false)
                    {
                        tb.ucValue = string.Empty;
                    }
                }
                if (ctrl is MaskCodeHelper)
                {
                    MaskCodeHelper ch = (MaskCodeHelper)ctrl;
                    if (string.IsNullOrWhiteSpace(ch.ucValue) == false)
                    {
                        ch.ucValue = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// 데이터뷰 행또는 셀 클릭시 그 행의 각 셀들의 값을 텍스트박스에 입력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dtg_DurableProd_Click(object sender, EventArgs e)
        {
            state = true;
            txtProdId.ucTextReadOnly = true;
            txtVender.ucReadOnly = false;
            txtProdId.ucValue = dtgDurableProd.CurrentRow.Cells["DURABLEPRODUCTID"].Value.ToString();
            txtProdName.ucValue = dtgDurableProd.CurrentRow.Cells["DURABLEPRODUCTNAME"].Value.ToString();
            txtVender.ucValue = dtgDurableProd.CurrentRow.Cells["VENDERID"].Value.ToString();
            txtMaskSize.ucValue = dtgDurableProd.CurrentRow.Cells["MASKSIZE"].Value.ToString();
            txtMaskThick.ucValue = dtgDurableProd.CurrentRow.Cells["MASKTHICK"].Value.ToString();
            txtLimitUseQTY.ucValue = dtgDurableProd.CurrentRow.Cells["LIMITUSEQTY"].Value.ToString();
            txtDescript.ucValue = dtgDurableProd.CurrentRow.Cells["DESCRIPTION"].Value.ToString();
            txtWarningUseQTY.ucValue = dtgDurableProd.CurrentRow.Cells["WARNINGUSEQTY"].Value.ToString();
            txtComment.ucValue = dtgDurableProd.CurrentRow.Cells["COMMENT"].Value.ToString();
            cbbUseYn.ucText = dtgDurableProd.CurrentRow.Cells["USEYN"].Value.ToString();
        }

        /// <summary>
        /// 저장버튼 클릭 시 
        /// 1. state가 true면 변경하시겠습니까 후 update프로시저 실행
        /// 2. state가 false면 추가하시겠습니까 후 insert프로시저 실행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void GridRowChange(int iRow) {
            int nRowIndex;
            if (iRow != -1)
            {
                nRowIndex = iRow;
            }
            else
            {
                nRowIndex = dtgDurableProd.Rows.Count - 1;
            }

            dtgDurableProd.ClearSelection();

            dtgDurableProd.Rows[nRowIndex].Selected = true;
            dtgDurableProd.Rows[nRowIndex].Cells[0].Selected = true;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            BtnSave_Click();
        }
        private void BtnSave_Click()
        {
            try
            {
                sql = "ProcDurableProductInDurableProdTab";
                string ctrlname = "";
                int iRow = -1;
                if (!CommonFuction.CheckMandatory(groupBox1, ref ctrlname))
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "확인", ctrlname + "을 확인해주세요");
                    return;
                }
                if (state == false)
                {
                    result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "저장하시겠습니까?");
                    if (result == DialogResult.OK)
                    {
                        table = db.ExecuteProcedure(sql, AddParam());
                        TableRefresh();
                        MakeEmpty();
                        GridRowChange(iRow);
                    }
                }
                else
                {
                    ctrlname = "";
                    if (!CommonFuction.CheckMandatory(groupBox1, ref ctrlname))
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "확인", ctrlname + "을 확인해주세요");
                        return;
                    }
                    result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "저장하시겠습니까?");
                    if (result == DialogResult.OK)
                    {
                        iRow = dtgDurableProd.CurrentRow.Index;
                        table = db.ExecuteProcedure(sql, AddParam());
                        TableRefresh();
                        MakeEmpty();
                        GridRowChange(iRow);
                    }
                }
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다.\n 로그를 확인하세요.");
            }
        }
        /// <summary>
        /// 신규버튼 클릭 시 
        /// 1.state값 false, 
        /// 2.텍스트박스값들 초기화,
        /// 3.커서 처음 텍스트박스로 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnNew_Click();
        }
        private void BtnNew_Click()
        {
            txtVender.ucReadOnly = false;
            txtProdId.ucTextReadOnly = false;
            state = false;
            MakeEmpty();

            this.ActiveControl = txtProdId;
            txtProdId.Focus();
        }
    }
}
