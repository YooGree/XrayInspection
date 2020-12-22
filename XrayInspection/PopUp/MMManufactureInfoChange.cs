using XrayInspection.UserControls;
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

namespace XrayInspection.PopUp
{
    public partial class MMManufactureInfoChange : ParentsPop {

        DBManager DB = new DBManager();
        DataSet QueryList;

        public MainForm resetRack;
        int iNewTotUseQty;

        public MMManufactureInfoChange()
        {
            InitializeComponent();
            SetEvent();
            Caption = "생산 입력 정보 변경";
        }

        private void SetEvent()
        {
            Load += MMManufactureInfoChange_Load;
            btn_Add.Click += Btn_Add_Click; //신규 추가 버튼
            btn_Save.Click += Btn_Save_Click;   //저장 버튼
            btn_Close.Click += Btn_Close_Click;     //닫기
            txt_MaskNum.txtText.KeyDown += Txt_MaskNum_KeyDown; //Mask 일련번호
            txt_MaskNum.txtText.KeyPress += txt_KeyPress; //Mask 일련번호 대소문자 valid 체크
            txt_ChangeUse.txtText.KeyPress += txt_KeyPress;  //총사용횟수 숫자입력 valid 체크 
               

            //2019-05-28 황지희 공통 함수에 있던 오류 부분 각 화면으로 다시 설정 
            this.txt_MaskNum.txtText.CharacterCasing = CharacterCasing.Upper;

        }

        private void MMManufactureInfoChange_Load(object sender, EventArgs e)
        {
            //db connect
            DB.Open();

            ActiveControl = txt_MaskNum;
        }
        /// <summary>
        /// * 함 수 명 : InitReset				
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 각 컴포넌트 초기화 함수	
        /// </summary>
        private void InitReset()
        {
            this.txt_MaskNum.txtText.ResetText(); //Mask 일련번호
            this.txt_ProdId.txtText.ResetText(); //모델코드
            this.txt_ProdName.txtText.ResetText();   //모델명
            this.txt_Rack.txtText.ResetText(); //보관함 위치
            this.txt_IncomeInsp.txtText.ResetText(); //수입검사결과
            this.txt_CleanInsp.txtText.ResetText();  //세척검사결과
            this.txt_Inputdate.ucValue = "";   //입고일자
            this.txt_RecentDate.ucValue = ""; //최근 사용 일자
            this.txt_LimitUse.txtText.ResetText();  //한계 사용 횟수
            this.txt_TotUse.txtText.ResetText();  //누적 사용 횟수
            this.txt_NowUse.txtText.ResetText();  //최근 사용 횟수
            this.txt_ChangeUse.txtText.ResetText();  //변경 사용 횟수
            this.txt_Comment.txtText.ResetText();   //특이사항
            this.txt_objectid.txtText.ResetText(); //OBJECTID
            this.txt_ProdId.txtText.ReadOnly = true;
            this.txt_ChangeUse.txtText.ReadOnly = true;
            this.txt_ChangeUse.ucMandatory = false;
            QueryList = null;
            iNewTotUseQty = 0;
        }

        /// <summary>
        /// 사용횟수 valid 체크 
        /// </summary>
        public string Valid()
        {
            DataRow ValidRow = QueryList.Tables[0].Rows[0];

            int iLimitUseQty, iTotUseQty, iUseQty, iValidQty = 0;
            int iReUseQty = -1;

            iLimitUseQty = int.Parse(ValidRow["LIMITUSEQTY"].ToString()); //한계 횟수
            iTotUseQty = int.Parse(ValidRow["TOTUSEQTY"].ToString());   //누적 횟수
            iUseQty = int.Parse(ValidRow["USEQTY"].ToString());   //최근 저장된 사용횟수
            iReUseQty = int.Parse(txt_ChangeUse.txtText.Text.ToString());   //신규로 입력할 사용횟수
            iValidQty = iLimitUseQty - iTotUseQty;

            iNewTotUseQty = iTotUseQty - iUseQty + iReUseQty;  //기존 누적 횟수 - 입력된 사용횟수 + 신규 사용횟수

            //2019-05-09 황지희 1.사용횟수 0이상 입력하도록 변경
            //                  2.기존 누적횟수 + 신규로 입력된 사용횟수가 한도횟수보다 많을경우 LOT TEMINATED 여부 결정 후 진행하도록 변경 

            if (iReUseQty < 0)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", txt_ChangeUse.ucLabelText + "를 0이상 입력하세요.");
                txt_ChangeUse.txtText.Focus();
                txt_ChangeUse.txtText.SelectAll();
                return "SAVE_FALSE";
            }
            else
            {
                if (iReUseQty >= iValidQty)
                {
                    if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "TERMIATED", txt_LimitUse.ucLabelText + "보다 같거나 큰 상태입니다.\rLOT을 종료하시겠습니까?") == DialogResult.OK)
                    {
                        return "SAVE_TERMINATED";
                    }
                    else
                    {
                        txt_ChangeUse.txtText.Focus();
                        txt_ChangeUse.txtText.SelectAll();
                        return "SAVE_FALSE";
                    }
                }
            }
            return "SAVE_TRUE";
        }

        ///////////////////////////////////////////KEY Event ///////////////////////////////////////////
        /// <summary>
        /// * 함 수 명 : txt_KeyPress				
        /// * 작 성 자 : 황지희		
        /// * 개 요 : key 이벤트 영어(대문자), 숫자만 입력받도록 valid 체크 
        /// </summary>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
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
                case "txt_MaskNum":
                    CommonFuction.TypingOnlyEngNum(sender, e, txt_MaskNum);
                    break;

                case "txt_ChangeUse": 
                    CommonFuction.TypingOnlyNumber(sender, e, false);
                    break;

            }
        }

        public UserControl ucMa { get; }
        /// <summary>
        /// * 함 수 명 : Txt_MaskNum_KeyDown				
        /// * 작 성 자 : 황지희		
        /// * 개 요 : Mask 일련번호 Enter로 정보 출력 
        /// </summary>
        private void Txt_MaskNum_KeyDown(object sender, KeyEventArgs e)
        {
            string sMaskNum = (sender as TextBox).Text.ToString();


            if (e.KeyCode == Keys.Enter)
            {
                if (CommonFuction.IsNullOrWhiteSpace(sMaskNum))
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", txt_MaskNum.ucLabelText + "를 입력하세요.");
                    return;
                }
                else
                {
                    List<SqlParameter> Params = new List<SqlParameter>();
                    Params.Add(new SqlParameter("@durable_id", sMaskNum));

                    QueryList = null;
                    QueryList = DB.CallSelectProcedure_ds("SelectChangeDuralbleHistInfo", Params);
                    int Limit_Use_Qty, Tot_Use_Qty, Use_Qty = 0;

                    if (QueryList.Tables[0].Rows.Count != 0)
                    {
                        DataRow row = QueryList.Tables[0].Rows[0];

                        if (row["STATE"].Equals("STATE_ACTIVE") && row["WORKSTATE"].Equals("WORKSTATE_USED") || row["STATE"].Equals("STATE_CREATED") && row["WORKSTATE"].Equals("WORKSTATE_WAIT"))
                        {
                            this.txt_objectid.ucValue = row["OBJECTID"].ToString();
                            this.txt_MaskNum.ucValue = row["DURABLEID"].ToString();
                            this.txt_ProdId.ucValue = row["DURABLEPRODUCTID"].ToString();
                            this.txt_ProdName.ucValue = row["DURABLEPRODUCTNAME"].ToString();
                            this.txt_TotUse.ucValue = row["TOTUSEQTY"].ToString();
                            this.txt_Rack.ucValue = row["RACKID"].ToString();
                            this.txt_Inputdate.ucValue = row["INPUTDATE"].ToString();
                            this.txt_RecentDate.ucValue = row["USEDATE"].ToString();
                            //DateTime Use_Date = DateTime.Parse(row["USEDATE"].ToString());
                            //this.txt_RecentDate.ucValue = Use_Date.ToString();
                            int.TryParse(row["LIMITUSEQTY"].ToString(), out Limit_Use_Qty);
                            this.txt_LimitUse.ucValue = Limit_Use_Qty.ToString();
                            int.TryParse(row["TOTUSEQTY"].ToString(), out Tot_Use_Qty);
                            this.txt_TotUse.ucValue = Tot_Use_Qty.ToString();
                            int.TryParse(row["USEQTY"].ToString(), out Use_Qty);
                            this.txt_NowUse.ucValue = Use_Qty.ToString();
                            this.txt_CleanInsp.ucValue = row["CLEANRESULT"].ToString(); //세척검사결과
                            this.txt_IncomeInsp.ucValue = row["INPUTRESULT"].ToString(); //수입검사결과
                       //     this.txt_Comment.ucValue = row["COMMENT"].ToString();
                            this.txt_ChangeUse.Focus();

                            bool workstate = true;
                            if (row["STATE"].Equals("STATE_CREATED") && row["WORKSTATE"].Equals("WORKSTATE_WAIT"))
                            {
                                SelectChcck(workstate);
                            }
                            else
                            {
                                SelectChcck(!workstate);
                            }
                        }
                        else if (row["STATE"].ToString().Equals("STATE_SCRAPPED"))
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 일련번호는 폐기상태입니다.");
                            txt_MaskNum.txtText.SelectAll();
                            return;
                        }
                        else if (row["STATE"].ToString().Equals("STATE_TERMINATED"))
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 일련번호는 종료상태입니다.");
                            InitReset();
                            txt_MaskNum.txtText.SelectAll();
                            return;
                        }
                        else if (row["STATE"].ToString().Equals("STATE_ACTIVE") && row["WORKSTATE"].Equals("WORKSTATE_CLEANED") || row["STATE"].Equals("STATE_ACTIVE") && row["WORKSTATE"].Equals("WORKSTATE_USING"))
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "생산정보입력화면에서 진행하세요.");
                            InitReset();
                            txt_MaskNum.txtText.SelectAll();
                            return;
                        }
                        else
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "세척검사화면에서 진행하세요.");
                            InitReset();
                            txt_MaskNum.txtText.SelectAll();
                            return;
                        }
                    }
                    else
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 Mask 일련번호가 없습니다.");
                        InitReset();
                        txt_MaskNum.Focus();
                        return;
                    }
                }
            }//end if (key code) 
        }

        private void SelectChcck(bool workstate) {
            if(workstate)
            {
                txt_ProdId.Focus();
                this.txt_ProdId.txtText.ReadOnly = false;
                this.txt_ChangeUse.txtText.ReadOnly = true;
                this.txt_ChangeUse.ucMandatory = false;
             }else {
                txt_ChangeUse.Focus();
                this.txt_ProdId.txtText.ReadOnly = true;
                this.txt_ChangeUse.txtText.ReadOnly = false;
                this.txt_ChangeUse.ucMandatory = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);
            switch (key)
            {
                case Keys.F2:
                    Btn_Add_Click();
                    break;
                case Keys.F3:
                    Btn_Save_Click();
                    break;
                case Keys.F4:
                    Btn_Close_Click();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        ///////////////////////////////////////////Btn Event ///////////////////////////////////////////
        /// <summary>
        /// * 함 수 명 : Btn_Reset_Click			
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 저장
        /// </summary>
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Btn_Add_Click();
        }

        private void Btn_Add_Click()
        {
            string ctrlname = "";
            if (CommonFuction.CheckMandatory(groupBox1, ref ctrlname))
            {
                if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "신규", "신규 생성 하시겠습니까?") == DialogResult.OK)
                {
                    InitReset();
                }
            }
            else
            {
                InitReset();
            }
        }

        /// <summary>
        /// * 함 수 명 : Btn_Save_Click			
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 저장
        /// </summary>
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Btn_Save_Click();
        }

        private void Btn_Save_Click()
        {
            //필수 입력값 확인
            string ctrlname = "";
            if (!CommonFuction.CheckMandatory(groupBox1, ref ctrlname))
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", ctrlname + "을 확인해주세요.");
                return;
            }

            string sValidReslt = Valid();
            if (sValidReslt.Equals("SAVE_FALSE"))
            {
                return;
            }
            try { 
                if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "저장", "저장 하시겠습니까?") == DialogResult.OK)
                {

                    Dictionary<string, object> Params = new Dictionary<string, object>();
                    Params.Add("@objectid", this.txt_objectid.ucValue);  //Mask 일련번호
                    Params.Add("@durableid", this.txt_MaskNum.ucValue);  //Mask 일련번호
                    Params.Add("@durableproductid", this.txt_ProdId.ucValue); //모델코드
                    Params.Add("@useqty", this.txt_ChangeUse.ucValue);     //사용 횟수
                    Params.Add("@totuseqty", iNewTotUseQty);     //사용 횟수
                    Params.Add("@comment", this.txt_Comment.ucValue);    //사양 정보
                    Params.Add("@modifier", Program.CurrentUser);    //사용자
                    Params.Add("@workstate", "WORKSTATE_USED");    //WOKR STATE
                                                                   //Params.Add("@usedate",DateTime.Now);    //WOKR STATE
                                                                   //rams.Add("@state", "STATE_ACTIVE");    //LOT STATE

                    if (sValidReslt.Equals("SAVE_TERMINATED"))
                    {
                        Params.Add("@lotstate", "STATE_TERMINATED");    //LOT STATE
                        //2019-05-14 황지희 폐기일 경우 RACKID 빈값 파람 추가 
                        Params.Add("@rackid", "");    //RACK ID 
                    }
                    else
                    {
                        Params.Add("@lotstate", "STATE_ACTIVE");
                        Params.Add("@rackid", this.txt_Rack.ucValue);
                    }

                    var PamasArr = DB.GetSqlParameters(Params);

                    int SaveResult = DB.CallNonSelectProcedure("SaveChngeMaskInfoToDurableHist", PamasArr);

                    if (SaveResult > 0)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "SAVE", "저장하였습니다.");
                        //2019-05-08 황지희 저장후 MASK 일련번호로 포커스 추가 
                        txt_MaskNum.Focus();
                        InitReset();
                        resetRack.ResetRackStatus(true);
                    }
                }
            }catch(Exception ee)
            {
                LogFactory.Log(ee);
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "문제가 발생했습니다.\n 로그를 확인하세요.");
            }
        }



        /// <summary>
        /// 2019-05-03 황지희 닫기 버튼 event 추가
        /// </summary>
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Btn_Close_Click(); //ResetRackStatus
        }

        private void Btn_Close_Click()
        {
            this.Close();
        }
    }
}
