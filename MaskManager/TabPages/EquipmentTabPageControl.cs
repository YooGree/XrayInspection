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
    /// 설명 : 설비에서 기존 데이터들 확인,추가,변경,삭제를 할 수 있는 화면
    /// 함수목록 : DataGridViewProperties, SetEvent, TextBox_KeyPress, EquipmentTabPageControl_Load, AddParam
    ///           Dtg_EquipList_Click, TableRefresh, MakeEmpty, BtnNew_Click, BtnSave_Click
    ///           DtgEquipList_RowPostPaint
    /// 프로시저 : DeleteEquipmentId, ProcEquipmentInEquipmentTab, SelectEquipment
    /// 이력 : 
    /// </summary>
    public partial class EquipmentTabPageControl : TabPageControl
    {
        DBManager db = new DBManager();
        DataTable table;
        bool state = false; // 추가 변경 버튼
        string sql;
        DialogResult result;

        public EquipmentTabPageControl()
        {
            InitializeComponent();
            Load += EquipmentTabPageControl_Load;
        }

        private void EquipmentTabPageControl_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtEquipId;
            CommonFuction.SetEqpTypeList(ref cbbEquipmentType);
            CommonFuction.SetUseYNList(ref cbbUseYn);
            cbbEquipmentType.ucReadOnly = true;
            try
            {
                db.Open();
                sql = "SelectEquipment";
                Dictionary<string, object> param = new Dictionary<string, object>();
                dtgEquipList.DataSource = db.ExecuteProcedure(sql, param);
                DataGridViewProperties();
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다.\n 로그를 확인하세요.");
            }

            SetEvent();
        }
        /// <summary>
        /// 그리드뷰 정렬 및 헤더 한글
        /// </summary>
        private void DataGridViewProperties()
        {
            dtgEquipList.Columns["CODEVALUE"].HeaderText = "설비유형";
            dtgEquipList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEquipList.Columns["EQUIPMENTID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEquipList.Columns["EQUIPMENTID"].HeaderText = "설비코드";
            dtgEquipList.Columns["EQUIPMENTNAME"].HeaderText = "설비명";
            dtgEquipList.Columns["USEYN"].HeaderText = "사용여부";
            dtgEquipList.Columns["COMMENT"].HeaderText = "특이사항";
            dtgEquipList.Columns["CREATOR"].HeaderText = "생성자";
            dtgEquipList.Columns["CREATEDATE"].HeaderText = "생성날짜";
            dtgEquipList.Columns["EVENTDATE"].HeaderText = "변경날짜";
            dtgEquipList.Columns["MODIFIER"].HeaderText = "변경자";
            dtgEquipList.Columns["COMMENT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        /// <summary>
        /// 이벤트 함수 모음
        /// 1. 그리드뷰 클릭 시 값 로드
        /// 2. 신규 클릭 시 기종코드 텍스트박스로 포커스
        /// 3. 변경 클릭 시 bool값에 따라 추가, 변경
        /// 4. 텍스트박스 키 입력 제한, 엔터키 입력 시 TAB키 반환
        /// 5. 행번호 추가 이벤트
        /// </summary>
        private void SetEvent()
        {
            dtgEquipList.Click += Dtg_EquipList_Click;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            txtEquipId.txtText.KeyPress += TextBox_KeyPress;
            txtEquipName.txtText.KeyPress += TextBox_KeyPress;
            dtgEquipList.RowPostPaint += DtgEquipList_RowPostPaint;
            btnCopy.Click += BtnCopy_Click;
            this.dtgEquipList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            //복사하기 추가 
            txtEquipId.txtText.KeyDown += EquipmentTabPageControl_KeyDown;
            txtEquipName.txtText.KeyDown += EquipmentTabPageControl_KeyDown;
            txtComment.txtText.KeyDown += EquipmentTabPageControl_KeyDown;
        }

        private void EquipmentTabPageControl_KeyDown(object sender, KeyEventArgs e)
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
            if (this.dtgEquipList.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {

                    DataObject dataObj = dtgEquipList.GetClipboardContent();

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
        /// 행번호 추가이벤트
        /// </summary>
        /// <param name="sender"></param>
        private void DtgEquipList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                case "txtEquipId":
                    CommonFuction.TypingOnlyEngNum(sender, e, txtEquipId);
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        txtEquipName.Focus();
                    }
                    break;
                case "txtEquipName":
                    if (Char.IsLetter(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false && e.KeyChar != 8 && e.KeyChar == ',')
                    {
                        e.Handled = true;
                    }
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        txtComment.Focus();
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
                sql = "SelectEquipment";
                Dictionary<string, object> param = new Dictionary<string, object>();
                dtgEquipList.DataSource = db.ExecuteProcedure(sql, param);
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
            param.Add("@Type", cbbEquipmentType.ucValue);
            param.Add("@Id", txtEquipId.ucValue);
            param.Add("@Name", txtEquipName.ucValue);
            param.Add("@Yn", cbbUseYn.ucText);
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
            CommonFuction.SetEqpTypeList(ref cbbEquipmentType);
            CommonFuction.SetUseYNList(ref cbbUseYn);
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is UserControls.MaskTextBox)
                {

                    UserControls.MaskTextBox tb = (UserControls.MaskTextBox)ctrl;
                    if (tb.ucValue != string.Empty)
                    {
                        tb.ucValue = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// 저장버튼 클릭 시 
        /// 1. state가 true면 변경하시겠습니까 후 update프로시저 실행
        /// 2. state가 false면 추가하시겠습니까 후 insert프로시저 실행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            BtnSave_Click();
        }
        private void BtnSave_Click()
        {
            try
            {
                sql = "ProcEquipmentInEquipmentTab";
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
                        GridRowChange(iRow);
                        MakeEmpty();
                    }
                }
                else
                {
                    ctrlname = "";
                    iRow = dtgEquipList.CurrentRow.Index;
                    if (!CommonFuction.CheckMandatory(groupBox1, ref ctrlname))
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "확인", ctrlname + "을 확인해주세요");
                        return;
                    }
                    result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "저장하시겠습니까?");
                    if (result == DialogResult.OK)
                    {
                        table = db.ExecuteProcedure(sql, AddParam());
                        TableRefresh();
                        GridRowChange(iRow);
                        MakeEmpty();
                    }
                }
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다.\n 로그를 확인하세요.");
            }
        }

        private void GridRowChange(int iRow)
        {
            int nRowIndex;
            if (iRow != -1)
            {
                nRowIndex = iRow;
            }
            else
            {
                nRowIndex = dtgEquipList.Rows.Count - 1;
            }

            dtgEquipList.ClearSelection();

            dtgEquipList.Rows[nRowIndex].Selected = true;
            dtgEquipList.Rows[nRowIndex].Cells[0].Selected = true;
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
            txtEquipId.ucTextReadOnly = false;
            cbbEquipmentType.ucReadOnly = false;
            state = false;
            MakeEmpty();

            this.ActiveControl = txtEquipId;
            txtEquipId.Focus();
        }
        /// <summary>
        /// 데이터뷰 행또는 셀 클릭시 그 행의 각 셀들의 값을 텍스트박스에 입력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dtg_EquipList_Click(object sender, EventArgs e)
        {
            state = true;
            txtEquipId.ucTextReadOnly = true;
            cbbEquipmentType.ucReadOnly = true;
            cbbEquipmentType.ucText = dtgEquipList.CurrentRow.Cells["CODEVALUE"].Value.ToString();
            txtEquipId.ucValue = dtgEquipList.CurrentRow.Cells["EQUIPMENTID"].Value.ToString();
            txtEquipName.ucValue = dtgEquipList.CurrentRow.Cells["EQUIPMENTNAME"].Value.ToString();
            cbbUseYn.ucText = dtgEquipList.CurrentRow.Cells["USEYN"].Value.ToString();
            txtComment.ucValue = dtgEquipList.CurrentRow.Cells["COMMENT"].Value.ToString();

        }
    }
}
