using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager.PopUp
{
    /// <summary>
    /// 작성자 : 임한의
    /// 설명 : 일련번호를 스캐닝 후 각각의 정보를 텍스트박스에 불러오고 변경한 사람의 이름을 입력 후 폐기 버튼
    ///        클릭 시 폐기, 히스토리 테이블에 이력이 남는다.
    /// 함수목록 : SetEvent,MMScrapPop_Load, Btn_Cancel_Click, Btn_Ok_Click, 
    ///           Txt_Number_maskTextBoxKeyDownEvent, FindNum, ManagerScrap
    /// 프로시저 : ProcDurable&HistInMMScrapPop
    /// 이력 : 
    /// </summary>
    public partial class MMScrapPop : ParentsPop
    {
        DBManager db = new DBManager();
        DialogResult result;
        string sql;
        public MainForm resetRack;
        public MMScrapPop()
        {
            InitializeComponent();
            Load += MMScrapPop_Load;
        }

        private void MMScrapPop_Load(object sender, EventArgs e)
        {
            try
            {
                db.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            SetEvent();

            //2019-05-28 황지희 폼 로드 포커스 추가 
            ActiveControl = txtNumber;
        }
        /// <summary>
        /// 이벤트들 모음 함수
        /// 1.일련번호 텍스트박스 KeyDown이벤트
        /// 2.확인 버튼 클릭이벤트
        /// </summary>
        private void SetEvent()
        {
            txtNumber.maskTextBoxKeyDownEvent += Txt_Number_maskTextBoxKeyDownEvent;
            btnSave.Click += Btn_Ok_Click;
            btnClose.Click += Btn_Cancel_Click;
            btnNew.Click += BtnReset_Click;
            txtNumber.txtText.KeyPress += TxtText_KeyPress;

            this.txtNumber.txtText.CharacterCasing = CharacterCasing.Upper;

        }
        /// <summary>
        ///  2019-05-28 황지희 띄어쓰기 안되도록 변경 
        /// </summary>
        private void TxtText_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonFuction.TypingOnlyEngNum(sender, e, txtNumber);
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
                    BtnReset_Click();
                    return true;
                case Keys.F3:
                    Btn_Ok_Click();
                    break;
                case Keys.F4:
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        /// <summary>
        /// 모든 텍스트박스 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            BtnReset_Click();
        }
        /// <summary>
        /// 단축키 입력 및 버튼 입력시 실행되는 코드 
        /// </summary>
        public void BtnReset_Click()
        {
            foreach (Control ctrl in gbScrap.Controls)
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
        /// 취소버튼 클릭시 폼 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 확인 버튼클릭 시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            Btn_Ok_Click();
        }
        /// <summary>
        /// 단축키 입력 및 버튼 입력시 실행되는 코드 
        /// </summary>
        public void Btn_Ok_Click()
        {
            string ctrlname = "";
            if (!CommonFuction.CheckMandatory(gbScrap, ref ctrlname))
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", ctrlname + "을 확인해주세요");
                return;
            }
            else
            {
                if ( string.IsNullOrWhiteSpace(txtNumber.ucValue) == false&&string.IsNullOrWhiteSpace(txtRackId.ucValue) == true)
                {
                    result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "해당 모델은 이미 폐기되었습니다.");
                }
                else
                    try
                    {
                        sql = "ProcDurable&HistInMMScrapPop";
                        result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "폐기하시겠습니까?");
                        if (result == DialogResult.OK)
                        {
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@id", txtNumber.ucValue);
                            param.Add("@modifier", Program.CurrentUser);
                            param.Add("@comment", txtComment.ucValue);
                            DataTable table = db.ExecuteProcedure(sql, param);
                            result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "폐기되었습니다.");

                            resetRack.ResetRackStatus(true);
                            foreach (Control ctrl in gbScrap.Controls)
                            {
                                if (ctrl is UserControls.MaskTextBox)
                                {

                                    UserControls.MaskTextBox tb = (UserControls.MaskTextBox)ctrl;
                                    if (string.IsNullOrWhiteSpace(tb.ucValue) == false)
                                    {
                                        tb.ucValue = string.Empty;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        LogFactory.Log(ee);
                        CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다.\n 로그를 확인하세요.");
                    }
            }
        }
        /// <summary>
        /// 일련번호 텍스트박스의 값을 입력 후 엔터키를 누르면 
        /// 일련번호의 값과 매칭되는 각각의 값들을 불러오는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Number_maskTextBoxKeyDownEvent(object sender, EventArgs e)
        {
            if ((e as KeyEventArgs).KeyCode == Keys.Enter)
            {
                FindNum(txtNumber.ucValue);
            }

        }

        private void FindNum(string number)
        {
            List<SqlParameter> param =
                new List<SqlParameter>() { new SqlParameter("@id", number) };
            List<Dictionary<string, object>> varList =
                    db.CallSelectProcedure("SelectDurablebyId", param);
            if (varList.Count == 0)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "해당 Mask 일련번호가 없습니다.");
                BtnReset_Click();
            }
            else
            {
                txtName.ucValue = varList[0]["DURABLEPRODUCTID"].ToString();
                txtUseDate.ucValue = varList[0]["USEDATE"].ToString();
                txtTotUse.ucValue = varList[0]["TOTUSEQTY"].ToString();
                txtRackId.ucValue = varList[0]["RACKID"].ToString();
                txtDescript.ucValue = varList[0]["DESCRIPTION"].ToString();
                if (string.IsNullOrWhiteSpace(txtNumber.ucValue) == false&&string.IsNullOrWhiteSpace(txtRackId.ucValue) == true)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "해당모델은 이미 폐기되었습니다.");
                    foreach (Control ctrl in gbScrap.Controls)
                    {
                        if (ctrl is UserControls.MaskTextBox)
                        {

                            UserControls.MaskTextBox tb = (UserControls.MaskTextBox)ctrl;
                            if (string.IsNullOrWhiteSpace(tb.ucValue) == false)
                            {
                                tb.ucValue = string.Empty;
                            }
                        }
                    }
                }
            }

        }



        //관리대장에서 폐기 할 경우 2019-05-03 정송은 추가
        public void ManagerScrap(string id)
        {
            if (id.Equals(""))
            {
                result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "해당모델이 없습니다.");
                this.Close();
            }
            else
            {
                this.txtNumber.ucValue = id;
                FindNum(id);

                this.ShowDialog();
            }

        }
    }
}
