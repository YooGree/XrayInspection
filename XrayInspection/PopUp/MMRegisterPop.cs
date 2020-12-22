using XrayInspection.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XrayInspection.PopUp
{
    /// <summary>
    /// 작성자 : 윤보미
    /// 설명 : 
    /// 함수목록 : 
    /// 프로시저 : FindVenderName
    /// 이력 : 
    /// </summary>
    public partial class MMRegisterPop : ParentsPop
    {
        DBManager _dbManager;

        public MainForm resetRack;
        public DBManager dbManager
        {
            get
            {
                if (_dbManager == null)
                    _dbManager = new DBManager();
                return _dbManager;
            }
        }

        //DatagridView에서 선택한 Mask
        public MC_DURABLE SelectedDurable { get; set; }

        public MMRegisterPop()
        {
            InitializeComponent();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mcbmRack.cboCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            mcbmRack.cboCombo.AutoCompleteSource = AutoCompleteSource.ListItems;

            mcmbModelCode.cboCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            mcmbModelCode.cboCombo.AutoCompleteSource = AutoCompleteSource.ListItems;


            SetEvent();
            ListRefresh();
            SetComboBox();
        }

        List<String> EmptyEquipList { get; set; }
        List<String> ModelCodeList { get; set; }
        /// <summary>
        /// 콤보박스 아이템 세팅
        /// </summary>
        private void SetComboBox()
        {
            CommonFuction.SetInputResultList(ref mcbmbInputResult);
            EmptyEquipList = CommonFuction.GetEmptyEquipList();
            ModelCodeList = CommonFuction.ModelCodeList();

            if (EmptyEquipList.Count > 0)
            {
                mcbmRack.ucComboBoxDataSource = EmptyEquipList;
                mcbmRack.cboCombo.SelectedIndex = -1;

                mcmbModelCode.ucComboBoxDataSource = ModelCodeList;
                mcmbModelCode.cboCombo.SelectedIndex = -1;
            }
            else
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "현재 비어있는 보관함이 없어 신규 Mask를 생성 할 수 없습니다.");
                btnNew.Enabled = false;

            }
        }

        /// <summary>
        /// 이벤트 등록 함수
        /// </summary>
        void SetEvent()
        {
            btnClose.Click += BtnClose_Click;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnSave.EnabledChanged += BtnSave_EnabledChanged;
            dtgMain.SelectionChanged += DtgMain_SelectionChanged;
            mtxtCode.txtText.KeyPress += TxtText_KeyPress;
            mcmbModelCode.cboCombo.KeyPress += CboCombo_KeyPress;
            mcmbModelCode.cboCombo.SelectionChangeCommitted += CboCombo_SelectionChangeCommitted;
            mcmbModelCode.cboCombo.KeyDown += CboCombo_KeyDown;
            mcmbModelCode.cboCombo.SelectedIndexChanged += CboCombo_SelectedIndexChanged;

            //mtxtCode.txtText.KeyDown += TxtText_KeyDown;
        }

        private void CboCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 특수문자 입력 불가
            //string text = mcmbModelCode.cboCombo.Text.Trim();
            // string text2 = System.Text.RegularExpressions.Regex.Replace(text, "[^0-9a-zA-Zㄱ-힗]+", "");
            //mcmbModelCode.ucText = text2;
            //string text = mcmbModelCode.cboCombo.Text.Trim();
            //if (e.KeyChar == Keys.ControlKey)
           // {
             //   text = "3";
           // }
        }

        private void CboCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = mcmbModelCode.cboCombo.Text;
            SetData(code);
        }

        private void CboCombo_KeyDown(object sender, KeyEventArgs e)
        {
            // 특수문자 입력 불가
            string mtxtCodeTRIM = mcmbModelCode.cboCombo.SelectedText.Replace(" ", "");
            string text2 = "";
            string Pattern = "[^0-9a-zA-Zㄱ-힗]+";

            if (Regex.IsMatch(mtxtCodeTRIM, Pattern))
            {
                text2 = System.Text.RegularExpressions.Regex.Replace(mtxtCodeTRIM, Pattern, "");
            }

            if (e.KeyData == Keys.Enter)
            {
                if (text2.Equals(""))
                {
                    mcmbModelCode.cboCombo.SelectedText = mtxtCodeTRIM;
                    SetData(mtxtCodeTRIM);
                }
                else {
                    mcmbModelCode.cboCombo.SelectedText = text2;
                    SetData(text2);
                }
               
            }
            else {
                mcmbModelCode.cboCombo.SelectedText = mtxtCodeTRIM;
                SetData(text2);
            }
        }

        private void CboCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetData(mcmbModelCode.cboCombo.SelectedText);
        }


        private void BtnSave_EnabledChanged(object sender, EventArgs e)
        {

            if (btnSave.Enabled == true)
                btnSave.Image = Properties.Resources.save_white;
            else
                btnSave.Image = Properties.Resources.save_black;
        }

        //private void TxtText_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //        SetData(mtxtCode.ucValue);
        //}


        private void TxtText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 특수문자 입력 불가
            if (Char.IsDigit(e.KeyChar) == false && Char.IsLetter(e.KeyChar) == false && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                mtxtCode.Focus();
            }
        }


        /// <summary>
        ///  작성자 : 강선애
        ///  단축 키 지정 이벤트
        /// </summary>
        /// 
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
                case Keys.F4:
                    BtnClose_Click();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }



        /// <summary>
        /// 모델명 입력시 나머지 데이터를 자동으로 세팅
        ///mtxtName : 모델명
        ///mtxtVenderCode : 제작업체코드
        ///mtxtVenderName : 제작업체 명 
        ///mtxtDesc : 마스크 사양정보
        /// </summary>
        /// <param name="_durableProductID"></param>
        private void SetData(string _durableProductID)
        {

            mtxtName.ucValue = dbManager.FindProductInfo(_durableProductID, ColumnName.DURABLEPRODUCTNAME);
            mtxtCode.ucValue = _durableProductID;
            string _venderid = dbManager.FindProductInfo(_durableProductID, ColumnName.VENDERID);
            mtxtVenderCode.ucValue = _venderid;
            mtxtVenderName.ucValue = dbManager.FindVenderName(_venderid);
            mtxtDesc.ucValue = dbManager.FindProductInfo(_durableProductID, ColumnName.DESCRIPTION);
            mtxtCode.ucMandatory = !Enabled;

            if (string.IsNullOrWhiteSpace(mtxtName.ucValue) == false)
                GetProductInfo = true;
            else
                GetProductInfo = false;
        }

        bool GetProductInfo = false;

        private void DtgMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgMain.SelectedRows.Count > 0)
            {
                SetEnabled(false);
                SetReadOnly(true);

                SelectedDurable = dtgMain.SelectedRows[0].DataBoundItem as MC_DURABLE;

                mtxtID.ucValue = SelectedDurable.DURABLEID;

                mtxtCode.ucValue = SelectedDurable.DURABLEPRODUCTID;
                mtxtName.ucValue = SelectedDurable.DURABLEPRODUCTName;

                mtxtVenderName.ucValue = SelectedDurable.VENDERName;
                mtxtVenderCode.ucValue = SelectedDurable.VENDERID;

                mtxtInputResult.ucValue = SelectedDurable.INPUTRESULTName;
                mtxtDesc.ucValue = SelectedDurable.DESCRIPTION;
                mtxtRack.ucValue = SelectedDurable.RACKID;
                mdtpCreateDate.ucValue = SelectedDurable.CREATEDATE;
                mtxtCreator.ucValue = SelectedDurable.CREATORName;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BtnSave_Click();
        }

        /// <summary>
        ///  작성자 : 강선애
        ///  단축 키 지정 이벤트를 위한 함수 추가
        /// </summary>
        /// 

        private void BtnSave_Click()
        {
            if (SelectedDurable == null)
            {
                string saveResult = "";
                try
                {
                    if (GetProductInfo == false)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장 실패", "유효한 모델 코드가 아닙니다.");
                        return;
                    }

                    if (mdtpCreateDate.dtpDatePicker.Value > DateTime.Today.AddDays(1))
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장 실패", "유효한 입고날짜가 아닙니다.");
                        return;
                    }

                    if (CommonFuction.CheckMandatory(gbLeft, ref saveResult) == false)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장 실패", $"{saveResult} 항목을 확인해주세요.");
                        return;
                    }

                    var result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "저장하시겠습니까?");
                    if (result == DialogResult.OK)
                    {
                        if(mdtpCreateDate.ucValue.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
                        {
                            mdtpCreateDate.ucValue = DateTime.Now;
                        }
                        Dictionary<string, object> args = new Dictionary<string, object>();
                        args.Add("@DURABLEID", mtxtID.ucValue);
                        args.Add("@DURABLEPRODUCTID", mcmbModelCode.ucValue);
                        args.Add("@VENDERID", mtxtVenderCode.ucValue);
                        args.Add("@LIMITUSEQTY", CommonFuction.GetLIMITUSEQTY(mtxtCode.ucValue));
                        args.Add("@RACKID", mcbmRack.ucValue);
                        args.Add("@RACKUSEDATE", mdtpCreateDate.ucValue);
                        args.Add("@INPUTDATE", mdtpCreateDate.ucValue);
                        args.Add("@INPUTRESULT", mcbmbInputResult.ucValue);
                        args.Add("@CREATEDATE", DateTime.Now);
                        args.Add("@CREATOR", Program.CurrentUser);
                        args.Add("@EVENTDATE", DateTime.Now);
                        args.Add("@MODIFIER", Program.CurrentUser);

                        dbManager.CallNonSelectProcedure(ProcedureName.InsertDurable, dbManager.GetSqlParameters(args));

                        args.Add("@OBJECTID", Guid.NewGuid().ToString());
                        dbManager.CallNonSelectProcedure(ProcedureName.InsertDURABLE_HIST, dbManager.GetSqlParameters(args));

                        CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "저장하였습니다.");

                        resetRack.ResetRackStatus(true);
                    }
                }
                catch (Exception ee)
                {
                    LogFactory.Log(ee);
                    CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다. 로그를 확인하세요.");
                }

                SetComboBox();
                ClearInputBox();
                ListRefresh();
            }
        }


        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnNew_Click();
        }

        /// <summary>
        ///  작성자 : 강선애
        ///  단축 키 지정 이벤트를 위한 함수 추가
        /// </summary>
        /// 

        private void BtnNew_Click()
        {
            SelectedDurable = null;
            //mtxtCode.txtText.Focus();
            ClearInputBox();
        }



        /// <summary>
        /// 입력 컨트롤 전체 초기화 
        /// </summary>
        private void ClearInputBox()
        {
            try
            {
                SetEnabled(true);
                SetReadOnly(false);

                mtxtID.txtText.Text = CommonFuction.DurableIdCreator();
                mtxtName.txtText.ResetText();
                mtxtCode.txtText.ResetText();

                mtxtVenderName.txtText.ResetText();
                mtxtVenderCode.txtText.ResetText();

                mtxtCreator.ucValue = Program.CurrentUserName;
                mtxtDesc.txtText.ResetText();

                mcbmbInputResult.cboCombo.SelectedIndex = -1;
                mcbmRack.cboCombo.SelectedIndex = -1;
                mcmbModelCode.cboCombo.SelectedIndex = -1;


                txtCreateDate.ResetText();

                GetProductInfo = false;
            }

            catch (Exception ee)
            {
                LogFactory.Log(ee);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            BtnClose_Click();
        }


        /// <summary>
        ///  작성자 : 강선애
        ///  단축 키 지정 이벤트를 위한 함수 추가
        /// </summary>
        /// 

        private void BtnClose_Click()
        {
            this.Close();
        }





        /// <summary>
        /// Durable 목록 새로고침
        /// </summary>
        void ListRefresh()
        {
            var List = dbManager.CallSelectProcedure<MC_DURABLE>(ProcedureName.DurableBySelect);
            mCDURABLEBindingSource.DataSource = List;
        }

        /// <summary>
        /// 입력창의 Enabled를 설정
        /// </summary>
        /// <param name="Enabled"></param>
        void SetEnabled(bool Enabled)
        {
            btnSave.Enabled = Enabled;
            mdtpCreateDate.dtpDatePicker.Enabled = Enabled;
            mcbmbInputResult.Visible = Enabled;
            mcbmRack.Visible = Enabled;
            mcmbModelCode.Visible = Enabled;

            mtxtInputResult.Visible = !Enabled;
            mtxtRack.Visible = !Enabled;
            mtxtCode.Visible = !Enabled;

            mtxtCode.ucMandatory = Enabled;
            mdtpCreateDate.ucMandatory = Enabled;

            //  txtCreateDate.Visible = Enabled;
        }

        void SetReadOnly(bool ReadOnly)
        {
            mtxtCode.txtText.ReadOnly = ReadOnly;

        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.Style |= 0x40000;
        //        return cp;
        //    }
        //}
    }
}
