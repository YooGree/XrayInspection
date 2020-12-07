using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaskManager.PopUp;
using MaskManager.UserControls;

namespace MaskManager.TabPages
{
    /// <summary>
    ///  * 파 일 명 : UserTabPageControl.cs
    ///  * 작 성 자 : 강선애
    ///  * 설     명 : 기준정보 > 사용자 
    ///  * 이     력 : 2019-04-29 [강선애] : 신규추가	
    ///                2019-05-02 [강선애] : 
    /// </summary>
    public partial class UserTabPageControl : TabPageControl
    {
        DBManager conn = new DBManager();
        DataTable bSucc;
        DialogResult result;

        bool state;  // true 일 때 insert 프로시저
                     // false 일 때 update 프로시저


        // 사용 프로시저
        string SelectUser = "SelectUser";
        string InsertUser = "InsertUser";
        string UpdateUser = "UpdateUser";

        public UserTabPageControl()
        {
            InitializeComponent();
            SetEvent();
        }



        /// <summary>
        /// * 함 수 명 : SetEvent					
        /// * 개 요 : Event 함수 정의 								
        /// </summary>
        /// 

        void SetEvent()
        {
            Load += UserTabPageControl_Load;

            dtgUser.RowPostPaint += Dgv_User_RowPostPaint;
            dtgUser.CellClick += Dgv_User_CellClick;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnCopy.Click += BtnCopy_Click;
            mtxtUserID.txtText.KeyPress += MtxtUserID_KeyPress;
            mtxtUserName.txtText.KeyPress += MtxtUserName_KeyPress;
            mtxtEmail.txtText.KeyPress += MtxtEmail_KeyPress;
            this.mtxtUserID.txtText.KeyDown += UserTabPageControl_KeyDown;
            this.mtxtUserName.txtText.KeyDown += UserTabPageControl_KeyDown;
            this.mtxtEmail.txtText.KeyDown += UserTabPageControl_KeyDown;

            // this.dtgUser.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

        }

        /// <summary>
        /// 2019-05-29 황지희 복사하기 추가 
        /// </summary>
        private void UserTabPageControl_KeyDown(object sender, KeyEventArgs e)
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
            if (this.dtgUser.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {

                    DataObject dataObj = dtgUser.GetClipboardContent();

                    Clipboard.SetDataObject(dataObj);
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {

                }
            }
        }
 
        private void MtxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                mtxtComment.Focus();
            }
        }

        private void MtxtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 특수문자 입력 불가
            if (Char.IsDigit(e.KeyChar) == false && Char.IsLetter(e.KeyChar) == false && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                mtxtEmail.Focus();
            }
        }

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
        /// * 함 수 명 : DatagridviewInitial
        /// * 개 요 : Datagridview 초기 설정								
        /// </summary>
        /// 

        void DatagridviewInit()
        {
            try
            {
                dtgUser.ReadOnly = true;
                //dtgUser.MultiSelect = false;

                dtgUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 행 단위로 cell 선택
                                                                                 //dtgUser.Font = new Font("malgun gothic", 9, FontStyle.Regular); // 그리드뷰 폰트, 사이즈

                // 로드 시 첫번째 행 선택 
                dtgUser.CurrentCell = dtgUser.Rows[0].Cells[1];

                // 수정 가능한 상태
                state = false;

                //component 초기 입력
                mtxtUserID.txtText.Text = dtgUser.Rows[0].Cells["USERID"].Value.ToString();
                mtxtUserName.txtText.Text = dtgUser.Rows[0].Cells["USERNAME"].Value.ToString();
                mtxtEmail.txtText.Text = dtgUser.Rows[0].Cells["EMAIL"].Value.ToString();
                mcmbUseYN.cboCombo.Text = dtgUser.Rows[0].Cells["USEYN"].Value.ToString();
                mtxtComment.txtText.Text = dtgUser.Rows[0].Cells["COMMENT"].Value.ToString();

                mtxtUserID.ucTextReadOnly = true;

                this.ActiveControl = mtxtUserName; // Tap focus
                mtxtUserName.txtText.Focus();
                mtxtUserName.Focus();

                //Datagridview Header 가운데 정렬
                dtgUser.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //사용여부 Column 가운데 정렬 //++ 추가로 cell 데이터가 null 일 때 처리하는 것
                dtgUser.Columns["UseYN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch(Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
            }
            
        }


        private void UserTabPageControl_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                state = true;
                PreComboBox();
                if (conn.CheckConnectState() == false)
                    MessageBox.Show("연결 실패");
                Select_User();
                DatagridviewInit();
            }
            catch(Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
            }
            
        }



        /// <summary>
        /// * 함 수 명 : Select_User	
        /// * 개 요 : MC_USER 의 데이터 조회					
        /// </summary>
        /// 
        void Select_User()
        {
            try
            {
                bSucc = conn.ExecuteProcedure(SelectUser);
                if (bSucc == null)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "", "저장된 사용자 정보가 없습니다.");
                }
                else
                {

                    dtgUser.DataSource = bSucc;

                    //Datagridview Header 설정
                    dtgUser.Columns["USERID"].HeaderText = "사번";
                    dtgUser.Columns["USERNAME"].HeaderText = "이름";
                    dtgUser.Columns["EMAIL"].HeaderText = "이메일";
                    dtgUser.Columns["USEYN"].HeaderText = "사용여부";
                    dtgUser.Columns["CREATOR"].HeaderText = "생성자";
                    dtgUser.Columns["MODIFIER"].HeaderText = "수정자";
                    dtgUser.Columns["COMMENT"].HeaderText = "특이사항";
                    dtgUser.Columns["CREATEDATE"].HeaderText = "생성일";
                    dtgUser.Columns["EVENTDATE"].HeaderText = "수정일";
                }
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
            }
        }


        /// <summary>
        /// * 함 수 명 : PreComboBox
        /// * 개 요 : UseYN(사용여부) comboBox 초기화								
        /// </summary>
        
        void PreComboBox()
        {
            CommonFuction.SetUseYNList(ref mcmbUseYN);
        }



        /// <summary>
        /// * 함 수 명 : MtxtUserID_KeyPress
        /// * 개 요 : mtxtUserID -> 영문대문자, 숫자만 입력가능 							
        /// </summary>

        private void MtxtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonFuction.TypingOnlyEngNum(sender, e, mtxtUserID);
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                mtxtUserName.Focus();
            }
        }



        /// <summary>
        /// * 함 수 명 : BtnSave_Click
        /// * 개 요 : 1) state = true 일 때 신규 등록
        ///           2) state = false 일 때 수정
        /// </summary>
        /// 
        private void BtnSave_Click(object sender, EventArgs e)
        {
            BtnSave_Click();
            
        }

        private void BtnSave_Click()
        {
            try
            {
                string ctrlname = "";
                int iRow = -1;
                if (CommonFuction.CheckMandatory(groupBox1, ref ctrlname) == false)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "", ctrlname + "을 확인해주세요");
                    return;
                }
                if (state == true)
                {
                    result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "", "저장하시겠습니까?");
                    if (result == DialogResult.OK)
                    {
                        var param = new Dictionary<string, object>();
                        param.Add("@USERID", mtxtUserID.txtText.Text);
                        param.Add("@USERNAME", mtxtUserName.txtText.Text);
                        param.Add("@EMAIL", mtxtEmail.txtText.Text);
                        param.Add("@USEYN", mcmbUseYN.cboCombo.Text);
                        param.Add("@COMMENT", mtxtComment.txtText.Text);
                        param.Add("@CREATOR", Program.CurrentUser);
                        param.Add("@MODIFIER", Program.CurrentUser);
                        bSucc = conn.ExecuteProcedure(InsertUser, param);
                        if (bSucc == null)
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "", "신규 등록이 실패하였습니다.");
                        }
                        else
                            CustomMessageBox.Show(MessageBoxButtons.OK, "", "신규 등록이 완료되었습니다.");
                    }
                }
                else
                {
                    result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "", "저장하시겠습니까?");
                    if (result == DialogResult.OK)
                    {
                        iRow = dtgUser.CurrentRow.Index;
                        var param = new Dictionary<string, object>();
                        param.Add("@USERID", mtxtUserID.txtText.Text);
                        param.Add("@USERNAME", mtxtUserName.txtText.Text);
                        param.Add("@EMAIL", mtxtEmail.txtText.Text);
                        param.Add("@USEYN", mcmbUseYN.cboCombo.Text);
                        param.Add("@COMMENT", mtxtComment.txtText.Text);
                        param.Add("@MODIFIER", Program.CurrentUser);
                        bSucc = conn.ExecuteProcedure(UpdateUser, param);
                        if (bSucc == null)
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "", "수정이 실패하였습니다.");
                        }
                        else
                            CustomMessageBox.Show(MessageBoxButtons.OK, "", "수정이 완료되었습니다.");
                    }
                }
                Select_User();
                DatagridviewInit();
                GridRowChange(iRow);

            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
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
                nRowIndex = dtgUser.Rows.Count - 1;
            }

            dtgUser.ClearSelection();

            dtgUser.Rows[nRowIndex].Selected = true;
            dtgUser.Rows[nRowIndex].Cells[0].Selected = true;
        }
  

        /// <summary>
        /// * 함 수 명 : BtnNew_Click
        /// * 개 요 : 신규 버틀 클릭 시 모든 컴포넌트 초기화						
        /// </summary>
        /// 

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnNew_Click();
        } 

        private void BtnNew_Click()
        {
            state = true;
            Content_Clear();
        }


        /// <summary>
        /// * 함 수 명 : Content_Clear
        /// * 개 요 : component clear 신규 등록 가능한 상태							
        /// </summary>

        void Content_Clear()
        {
            mtxtUserID.txtText.Clear(); // 사번
            mtxtUserName.txtText.Clear(); // 이름
            mtxtEmail.txtText.Clear(); // 이메일
            mcmbUseYN.cboCombo.SelectedIndex = 0; // 사용여부
            mtxtComment.txtText.Clear(); // 비고

            mtxtUserID.ucTextReadOnly = false;

            mtxtUserID.Focus(); ;
        }



        /// <summary>
        /// * 함 수 명 : Dgv_User_RowPostPaint	
        /// * 개 요 : row header에 순서대로 행 번호 입력							
        /// </summary>

        private void Dgv_User_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        /// * 함 수 명 : Dgv_User_CellClick	
        /// * 개 요 : 셀 클릭시 컴포넌트에 클릭한 셀 데이터 삽입(수정 가능한 상태)					
        /// </summary>
        private void Dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview column header 클릭 시 처리
            if (e.RowIndex < 0)
                return;
            //girdview 선택한 행의 셀 값
            mtxtUserID.txtText.Text = dtgUser.Rows[e.RowIndex].Cells["USERID"].Value.ToString();
            mtxtUserName.txtText.Text = dtgUser.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();
            mtxtEmail.txtText.Text = dtgUser.Rows[e.RowIndex].Cells["EMAIL"].Value.ToString();
            mcmbUseYN.cboCombo.Text = dtgUser.Rows[e.RowIndex].Cells["USEYN"].Value.ToString();            
            mtxtComment.txtText.Text = dtgUser.Rows[e.RowIndex].Cells["COMMENT"].Value.ToString();

            // 수정되면 안되는 항목 -> 사번
            mtxtUserID.ucTextReadOnly = true;
            mtxtUserName.txtText.Focus();

            // update 가능한 상태
            state = false;
        }
    }
}